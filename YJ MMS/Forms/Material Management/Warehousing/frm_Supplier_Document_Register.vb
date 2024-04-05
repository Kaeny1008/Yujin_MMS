Imports System.Threading
Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Supplier_Document_Register

    Dim thread_ExcelOpen As Thread
    Dim thread_ExcelRead As Thread
    Dim thread_ExcelToGrid As Thread
    Dim excelApp As Object

    Private Sub frm_Supplier_Document_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DateTimePicker1.Value = Format(Now, "yyyy-MM-01 00:00:00.000")
        DateTimePicker2.Value = Format(Now, "yyyy-MM-dd 23:59:59.999")

        Grid_Setting()

    End Sub

    Private Sub Grid_Setting()

        With Grid_MaterialList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 5
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            Grid_MaterialList(0, 0) = "No"
            Grid_MaterialList(0, 1) = "자재코드"
            Grid_MaterialList(0, 2) = "Part No."
            Grid_MaterialList(0, 3) = "제조사"
            Grid_MaterialList(0, 4) = "입고수량"
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            '.Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            '.ExtendLastCol = True
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
        End With

        With Grid_DocumentsList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 4
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            Grid_DocumentsList(0, 0) = "No"
            Grid_DocumentsList(0, 1) = "문서번호"
            Grid_DocumentsList(0, 2) = "공급사"
            Grid_DocumentsList(0, 3) = "입고품목 수"
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            '.Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            '.ExtendLastCol = True
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
        End With

        With Grid_Excel
            .AllowEditing = False
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 20
            .Rows.DefaultSize = 20
            .Cols.Count = 21
            .Rows.Count = 11
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .AutoSizeCols()
            .ShowCursor = False
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
        End With

        For i = 1 To Grid_Excel.Rows.Count - 1
            Grid_Excel(i, 0) = i
        Next

        For i = 1 To Grid_Excel.Cols.Count - 1
            Grid_Excel(0, i) = i
        Next

        Grid_Excel.AutoSizeCols()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub BTN_FileSelect_Click(sender As Object, e As EventArgs) Handles BTN_FileSelect.Click

        If Trim(CB_Supplier.Text) = String.Empty Then
            MessageBox.Show(Me,
                            "거래처를 먼저 선택(입력)하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        Dim openFile As New System.Windows.Forms.OpenFileDialog

        With openFile
            .Filter = "Excel (*.xls, *.xlsx)|*.xls;*.xlsx"
            .AddExtension() = True
        End With

        If openFile.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then Exit Sub

        If Not IsNothing(excelApp) Then
            excelApp.WorkBooks(1).Close()
            excelApp.Quit()
            ReleaseObject(excelApp)
            excelApp = Nothing
        End If

        NewControlSetting()

        TB_File_Path.Text = openFile.FileName

        excelApp = CreateObject("Excel.Application")
        excelApp.WorkBooks.Open(TB_File_Path.Text)
        excelApp.Visible = False

        Load_SheetList()

    End Sub

    Private Sub Load_SheetList()

        thread_ExcelOpen = New Thread(AddressOf File_Open)
        thread_ExcelOpen.IsBackground = True
        thread_ExcelOpen.SetApartmentState(ApartmentState.STA) 'openfiledialog를 사용하기위해선 sta로 해야되던데...
        thread_ExcelOpen.Name = "ExcelOpen Thread"
        thread_ExcelOpen.Start()

    End Sub

    Private Sub File_Open()

        Thread_LoadingFormStart("Excel Open...")

        For i = 1 To excelApp.ActiveWorkbook.Sheets.Count
            ComboBoxItemAdd(excelApp.ActiveWorkbook.Sheets(i).Name, Me, CB_SheetName)
        Next

        Thread_LoadingFormEnd()

        'MessageBox.Show(New Form With {.TopMost = True},
        '                "해당 시트를 선택하여 주십시오.",
        '                msg_form,
        '                MessageBoxButtons.OK,
        '                MessageBoxIcon.Information)

        MessageBox.Show("해당 시트를 선택하여 주십시오.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly)

        ComboBoxEnabled(True, Me, CB_SheetName)

    End Sub

    Private Sub CB_SheetName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_SheetName.SelectedIndexChanged

        thread_ExcelRead = New Thread(AddressOf Load_TempData)
        thread_ExcelRead.IsBackground = True
        thread_ExcelRead.SetApartmentState(ApartmentState.STA) 'OpenFileDialog를 사용하기위해선 STA로 해야되던데...
        thread_ExcelRead.Name = "ExcelRead Thread"
        thread_ExcelRead.Start()

    End Sub

    Private Sub Load_TempData()

        Thread_LoadingFormStart("Excel Open...")

        GridRedraw(False, Me, Grid_Excel)

        Try
            Dim sheetName As String = ComboBoxTextReading(Me, CB_SheetName)

            With excelApp.ActiveWorkbook.Sheets(sheetName)
                For i = 1 To 20
                    For j = 1 To 10
                        GridWriteText(.Cells(j, i).Value, j, i, Me, Grid_Excel, Color.Black)
                    Next
                Next
            End With
        Catch ex As Exception
            MessageBox.Show(New Form With {.TopMost = True},
                            ex.Message,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try

        GridColsAutoSize(Me, Grid_Excel)
        GridRowsAutoSize(1, Grid_Excel.Rows.Count - 1, Me, Grid_Excel)

        GridRedraw(True, Me, Grid_Excel)

        Thread_LoadingFormEnd()
        ButtonEnabled(True, Me, BTN_ExcelToGrid)

        MessageBox.Show("각 항목의 위치를 선택하여 주십시오.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly)

    End Sub

    Private Sub frm_Supplier_Document_Register_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

        If Not IsNothing(excelApp) Then
            excelApp.WorkBooks(1).Close()
            excelApp.Quit()
            ReleaseObject(excelApp)
            excelApp = Nothing
        End If

        If Not IsNothing(thread_ExcelOpen) Then
            Console.WriteLine("'{0}' Finished...",
                                  thread_ExcelOpen.Name)
            thread_ExcelOpen.Abort()
            thread_ExcelOpen = Nothing
        End If

        If Not IsNothing(thread_ExcelRead) Then
            Console.WriteLine("'{0}' Finished...",
                                  thread_ExcelRead.Name)
            thread_ExcelRead.Abort()
            thread_ExcelRead = Nothing
        End If

        If Not IsNothing(thread_ExcelToGrid) Then
            Console.WriteLine("'{0}' Finished...",
                                  thread_ExcelToGrid.Name)
            thread_ExcelToGrid.Abort()
            thread_ExcelToGrid = Nothing
        End If

    End Sub

    Private Sub Grid_Excel_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_Excel.MouseClick

        Grid_Excel.Row = Grid_Excel.MouseRow
        Grid_Excel.Col = Grid_Excel.MouseCol

        If e.Button = MouseButtons.Right And Grid_Excel.Row = 0 Then
            CMS_ColumnMenu.Show(Grid_Excel, New Point(e.X, e.Y))
        ElseIf e.Button = MouseButtons.Right And Grid_Excel.Col = 0 Then
            CMS_RowMenu.Show(Grid_Excel, New Point(e.X, e.Y))
        End If

    End Sub

    Dim col_PartCode As Integer = 0
    Dim col_PartNo As Integer = 0
    Dim col_Qty As Integer = 0
    Dim col_vendor As Integer = 0
    Dim row_Start As Integer = 0

    Private Sub Button_Click(sender As Object, e As EventArgs) Handles BTN_PartCode.Click,
        BTN_PartNo.Click,
        BTN_Qty.Click,
        BTN_Vendor.Click

        Dim selName As String = sender.ToString

        For i = 1 To Grid_Excel.Cols.Count - 1
            If Not IsNumeric(Grid_Excel(0, i)) Then
                If Grid_Excel(0, i) = selName Then
                    Grid_Excel(0, i) = i
                End If
            End If
        Next

        Grid_Excel(0, Grid_Excel.Col) = selName
        Grid_Excel.AutoSizeCols()

        If selName = BTN_PartCode.Text Then
            col_PartCode = Grid_Excel.Col
        ElseIf selName = BTN_PartNo.Text Then
            col_PartNo = Grid_Excel.Col
        ElseIf selName = BTN_Qty.Text Then
            col_Qty = Grid_Excel.Col
        ElseIf selName = BTN_vendor.Text Then
            col_vendor = Grid_Excel.Col
        End If

    End Sub

    Private Sub BTN_RowSelect_Click(sender As Object, e As EventArgs) Handles BTN_RowSelect.Click

        For i = 1 To Grid_Excel.Rows.Count - 1
            Grid_Excel(i, 0) = i
        Next

        row_Start = Grid_Excel.Row
        Grid_Excel(Grid_Excel.Row, 0) = BTN_RowSelect.Text
        Grid_Excel.AutoSizeCols()

    End Sub

    Private Sub BTN_ExcelToGrid_Click(sender As Object, e As EventArgs) Handles BTN_ExcelToGrid.Click

        Dim msgString As String = String.Empty

        If col_PartCode = 0 And col_PartNo = 0 Then
            msgString = "자재코드 또는 Part No. 열이 지정되지 않았습니다."
        End If

        If col_Qty = 0 Then
            msgString = "수량 열이 지정되지 않았습니다."
        End If

        If row_Start = 0 Then
            msgString = "시작 행이 지정되지 않았습니다."
        End If

        If Not msgString = String.Empty Then
            MessageBox.Show(Me,
                            msgString,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        thread_ExcelToGrid = New Thread(AddressOf ExcelToGrid)
        thread_ExcelToGrid.IsBackground = True
        thread_ExcelToGrid.SetApartmentState(ApartmentState.STA) 'OpenFileDialog를 사용하기위해선 STA로 해야되던데...
        thread_ExcelToGrid.Name = "ExcelToGrid Thread"
        thread_ExcelToGrid.Start()

    End Sub

    Private Sub ExcelToGrid()

        Thread_LoadingFormStart("Excel Load...")

        GridRedraw(False, Me, Grid_MaterialList)
        GridRowReset(1, Me, Grid_MaterialList)

        Try
            With excelApp.ActiveWorkbook.Sheets(ComboBoxTextReading(Me, CB_SheetName))
                Dim totalQty As Double = 0
                For i = row_Start To .UsedRange.Rows.Count
                    Dim partCode As String = String.Empty
                    If Not col_PartCode = 0 Then partCode = Trim(.Cells(i, col_PartCode).Value)
                    Dim partNo As String = String.Empty
                    If Not col_PartNo = 0 Then partNo = Trim(.Cells(i, col_PartNo).Value)

                    If Not partCode = String.Empty Or Not partNo = String.Empty Then
                        Dim qty As Double = 0
                        If not Trim(.Cells(i, col_Qty).Value) = String.Empty Then qty =Trim(.Cells(i, col_Qty).Value)
                        Dim vendor As String = String.Empty
                        If Not col_vendor = 0 Then vendor = Trim(.Cells(i, col_vendor).Value)
                        If Not qty = 0 Then
                            '아이템코드나 파트넘버가 비어 있다면 입력하지 않는다.
                            '수량이 0인것도 입력 X
                            GridWriteText(Grid_MaterialList.Rows.Count & vbTab &
                                          partCode & vbTab &
                                          partNo & vbTab &
                                          vendor & vbTab &
                                          Format(qty, "#,##0"),
                                          Me,
                                          Grid_MaterialList, Color.Black)
                            totalQty += qty
                        End If
                    End If
                Next
                MessageBox.Show(frm_Main,
                                "총 입고수량 : " & totalQty & " EA입니다." & vbCrLf & "입고수량을 확인하여 주십시오.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
            End With
        Catch ex As Exception
            MessageBox.Show(frm_Main,
                            ex.Message,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try

        GridColsAutoSize(Me, Grid_MaterialList)
        GridRedraw(True, Me, Grid_MaterialList)

        Thread_LoadingFormEnd()

    End Sub

    Private Sub NewControlSetting()

        CB_SheetName.Items.Clear()
        CB_SheetName.Enabled = False

        col_PartCode = 0
        col_PartNo = 0
        col_Qty = 0
        row_Start = 0

        For i = 1 To Grid_Excel.Rows.Count - 1
            Grid_Excel(i, 0) = i
        Next

        For i = 1 To Grid_Excel.Cols.Count - 1
            Grid_Excel(0, i) = i
        Next

        For i = 1 To Grid_Excel.Rows.Count - 1
            For j = 1 To Grid_Excel.Cols.Count - 1
                Grid_Excel(i, j) = String.Empty
            Next
        Next

        Grid_Excel.AutoSizeCols()

        Grid_MaterialList.Rows.Count = 1
        Grid_MaterialList.AutoSizeCols()

        TB_File_Path.Text = String.Empty

    End Sub

    Private Sub BTN_NewDocuments_Click(sender As Object, e As EventArgs) Handles BTN_NewDocuments.Click

        col_PartCode = 0
        col_PartNo = 0
        col_Qty = 0
        col_vendor = 0
        row_Start = 0

        CB_Supplier.Enabled = True

        BTN_FileSelect.Enabled = True
        BTN_Save.Enabled = True

        NewControlSetting()

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        If MessageBox.Show(Me,
                           "저장 하시겠습니까?",
                           msg_form,
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button1) = DialogResult.No Then Exit Sub

        Thread_LoadingFormStart("Saving...")

        DBConnect()

        Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
        Dim documentNo As String = String.Empty
        Dim strSQL As String = "select f_mms_material_warehousing_document_no('" & writeDate & "') as document_no"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            documentNo = sqlDR("document_no")
        Loop
        sqlDR.Close()

        Dim sqlTran As MySqlTransaction
        strSQL = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            For i = 1 To Grid_MaterialList.Rows.Count - 1
                strSQL += "insert into tb_mms_material_warehousing_document("
                strSQL += "wd_no, document_no, supplier, part_code, part_no, vendor, part_qty, write_date, write_id"
                strSQL += ") values("
                strSQL += "'" & documentNo & "-" & Format(i, "0000") & "'"
                strSQL += ", '" & documentNo & "'"
                strSQL += ", '" & CB_Supplier.Text & "'"
                strSQL += ", '" & Grid_MaterialList(i, 1) & "'"
                strSQL += ", '" & Grid_MaterialList(i, 2) & "'"
                strSQL += ", '" & Grid_MaterialList(i, 3) & "'"
                strSQL += ", '" & CInt(Grid_MaterialList(i, 4)) & "'"
                strSQL += ", '" & writeDate & "'"
                strSQL += ", '" & loginID & "');"
            Next

            If Not strSQL = String.Empty Then
                sqlCmd = New MySqlCommand(strSQL, dbConnection1)
                sqlCmd.Transaction = sqlTran
                sqlCmd.ExecuteNonQuery()

                sqlTran.Commit()
            End If
        Catch ex As MySqlException
            sqlTran.Rollback()
            DBClose()
            Thread_LoadingFormEnd()

            MessageBox.Show(Me,
                            ex.Message & vbCrLf & "Error No. : " & ex.Number,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        BTN_Save.Enabled = False
        BTN_FileSelect.Enabled = False
        CB_SheetName.Enabled = False
        CB_Supplier.Enabled = False
        BTN_ExcelToGrid.Enabled = False

        If Not IsNothing(excelApp) Then
            excelApp.WorkBooks(1).Close()
            excelApp.Quit()
            ReleaseObject(excelApp)
            excelApp = Nothing
        End If

        BTN_Search_Click(Nothing, Nothing)

        MessageBox.Show("저장 완료.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly)

    End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart()

        Grid_DocumentsList.Redraw = False
        Grid_DocumentsList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "select document_no, supplier, count(wd_no) as in_count"
        strSQL += " from tb_mms_material_warehousing_document"
        strSQL += " where write_date between '" & Format(DateTimePicker1.Value, "yyyy-MM-dd 00:00:00") & "'"
        strSQL += " and '" & Format(DateTimePicker2.Value, "yyyy-MM-dd 23:59:59") & "'"
        strSQL += " and supplier like concat('" & TextBox1.Text & "', '%')"
        strSQL += " group by document_no , supplier"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_DocumentsList.Rows.Count & vbTab &
                                          sqlDR("document_no") & vbTab &
                                          sqlDR("supplier") & vbTab &
                                          Format(sqlDR("in_count"), "#,##0")
            Grid_DocumentsList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_DocumentsList.AutoSizeCols()
        Grid_DocumentsList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_DocumentsList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Grid_DocumentsList.MouseDoubleClick

        Dim gridRow As Integer = Grid_DocumentsList.MouseRow

        If gridRow > 0 And e.Button = MouseButtons.Left Then
            Thread_LoadingFormStart()

            NewControlSetting()
            CB_Supplier.Enabled = False

            Grid_MaterialList.Redraw = False
            Grid_MaterialList.Rows.Count = 1

            DBConnect()

            Dim strSQL As String = "select part_code, part_no, part_qty"
            strSQL += " from tb_mms_material_warehousing_document"
            strSQL += " where document_no = '" & Grid_DocumentsList(gridRow, 1) & "'"
            strSQL += " order by wd_no"

            Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
            Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

            Do While sqlDR.Read
                Dim insert_String As String = Grid_MaterialList.Rows.Count & vbTab &
                                              sqlDR("part_code") & vbTab &
                                              sqlDR("part_no") & vbTab &
                                              Format(sqlDR("part_qty"), "#,##0")
                Grid_MaterialList.AddItem(insert_String)
            Loop
            sqlDR.Close()

            DBClose()

            Grid_MaterialList.AutoSizeCols()
            Grid_MaterialList.Redraw = True

            CB_Supplier.Text = Grid_DocumentsList(gridRow, 2)

            Thread_LoadingFormEnd()
        End If

    End Sub
End Class