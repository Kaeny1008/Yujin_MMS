﻿Imports System.Threading
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

        Load_Supplier()

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
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .Cols(4).DataType = GetType(Double)
            .Cols(4).Format = "#,##0"
        End With
        Grid_MaterialList(0, 0) = "No"
        Grid_MaterialList(0, 1) = "자재코드"
        Grid_MaterialList(0, 2) = "Part No."
        Grid_MaterialList(0, 3) = "제조사"
        Grid_MaterialList(0, 4) = "입고수량"
        Grid_MaterialList.AutoSizeCols()

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

    Private Sub Load_Supplier()

        CB_CustomerName.Items.Clear()

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "select sub_code_name"
        strSQL += " from tb_code_sub"
        strSQL += " where main_code = 'MC00000007'"
        strSQL += " order by sub_code_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            CB_Supplier.Items.Add(sqlDR("sub_code_name"))
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub Load_CustomerList()

        CB_CustomerName.Items.Clear()

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "select customer_name"
        strSQL += " from tb_customer_list"
        strSQL += " order by customer_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            CB_CustomerName.Items.Add(sqlDR("customer_name"))
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub CB_CustomerName_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_CustomerName.SelectionChangeCommitted

        TB_CustomerCode.Text = String.Empty

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "select customer_code"
        strSQL += " from tb_customer_list"
        strSQL += " where customer_name = '" & CB_CustomerName.Text & "'"
        strSQL += " order by customer_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_CustomerCode.Text = sqlDR("customer_code")
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub BTN_FileSelect_Click(sender As Object, e As EventArgs) Handles BTN_FileSelect.Click

        If Trim(CB_Supplier.Text) = String.Empty Then
            MSG_Information(Me, "거래처를 먼저 선택(입력)하여 주십시오.")
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

        Dim excelSheet() As String = Grid_Excel.LoadExcelSheetNames(openFile.FileName)

        For i = 0 To excelSheet.Length - 1
            CB_SheetName.Items.Add(excelSheet(i))
        Next

        MSG_Information(Me, "해당 시트를 선택하여 주십시오.")

        CB_SheetName.Enabled = True

        Exit Sub

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

        Thread_LoadingFormStart(Me, "Excel Open...")

        For i = 1 To excelApp.ActiveWorkbook.Sheets.Count
            ComboBoxItemAdd(excelApp.ActiveWorkbook.Sheets(i).Name, Me, CB_SheetName)
        Next

        Thread_LoadingFormEnd()

        MSG_Information(Me, "해당 시트를 선택하여 주십시오.")

        ComboBoxEnabled(True, Me, CB_SheetName)

    End Sub

    Private Sub CB_SheetName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_SheetName.SelectedIndexChanged

        Grid_Excel.LoadExcel(TB_File_Path.Text, CB_SheetName.Text, FileFlags.None)

        For i = 1 To Grid_Excel.Cols.Count - 1
            Grid_Excel(0, i) = i
        Next

        For i = 1 To Grid_Excel.Rows.Count - 1
            Grid_Excel(i, 0) = i
        Next

        Grid_Excel.AutoSizeCols()

        BTN_ExcelToGrid.Enabled = True

        Exit Sub

        thread_ExcelRead = New Thread(AddressOf Load_TempData)
        thread_ExcelRead.IsBackground = True
        thread_ExcelRead.SetApartmentState(ApartmentState.STA) 'OpenFileDialog를 사용하기위해선 STA로 해야되던데...
        thread_ExcelRead.Name = "ExcelRead Thread"
        thread_ExcelRead.Start()

    End Sub

    Private Sub Load_TempData()

        Thread_LoadingFormStart(Me, "Excel Open...")

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
            MSG_Error(Me, ex.Message)
        End Try

        GridColsAutoSize(Me, Grid_Excel)
        GridRowsAutoSize(1, Grid_Excel.Rows.Count - 1, Me, Grid_Excel)

        GridRedraw(True, Me, Grid_Excel)

        Thread_LoadingFormEnd()
        ButtonEnabled(True, Me, BTN_ExcelToGrid)

        MSG_Information(Me, "각 항목의 위치를 선택하여 주십시오.")

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
    Dim row_End As Integer = 0

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

    Private Sub BTN_RowStart_Click(sender As Object, e As EventArgs) Handles BTN_RowStart.Click, BTN_RowEnd.Click

        Dim selName As String = sender.ToString

        For i = 1 To Grid_Excel.Rows.Count - 1
            If Not IsNumeric(Grid_Excel(i, 0)) Then
                If Grid_Excel(i, 0) = selName Then
                    Grid_Excel(i, 0) = i
                End If
            End If
        Next

        Grid_Excel(Grid_Excel.Row, 0) = selName
        Grid_Excel.AutoSizeCols()

        If selName = BTN_RowStart.Text Then
            row_Start = Grid_Excel.Row
        ElseIf selName = BTN_Rowend.Text Then
            row_End = Grid_Excel.Row
        End If

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

        If row_End = 0 Then
            msgString = "종료 행이 지정되지 않았습니다."
        End If

        If Not msgString = String.Empty Then
            MSG_Information(Me, msgString)
            Exit Sub
        End If

        Dim totalQty As Double = 0

        Grid_MaterialList.Redraw = False
        Grid_MaterialList.Rows.Count = 1

        For i = row_Start To row_End
            Dim partCode As String = String.Empty
            If Not col_PartCode = 0 Then partCode = Trim(Grid_Excel(i, col_PartCode))
            Dim partNo As String = String.Empty
            If Not col_PartNo = 0 Then partNo = Trim(Grid_Excel(i, col_PartNo))

            If Not partCode = String.Empty Or Not partNo = String.Empty Then
                Dim qty As Double = 0
                If Not Trim(Grid_Excel(i, col_Qty)) = String.Empty Then qty = Trim(Grid_Excel(i, col_Qty))
                Dim vendor As String = String.Empty
                If Not col_vendor = 0 Then vendor = Trim(Grid_Excel(i, col_vendor))
                If Not qty = 0 Then
                    '아이템코드나 파트넘버가 비어 있다면 입력하지 않는다.
                    '수량이 0인것도 입력 X
                    Dim sameCode As Integer = 0
                    If Not col_PartCode = 0 And Not col_PartNo = 0 Then
                        sameCode = Grid_MaterialList.FindRow(partCode, 1, 1, True)
                    ElseIf Not col_PartCode = 0 And col_PartNo = 0 Then
                        sameCode = Grid_MaterialList.FindRow(partCode, 1, 1, True)
                    ElseIf col_PartCode = 0 And Not col_PartNo = 0 Then
                        sameCode = Grid_MaterialList.FindRow(partCode, 1, 2, True)
                    End If
                    If sameCode > 0 Then
                        Grid_MaterialList(sameCode, 4) += qty
                    Else
                        GridWriteText(Grid_MaterialList.Rows.Count & vbTab &
                                      partCode & vbTab &
                                      partNo & vbTab &
                                      vendor & vbTab &
                                      Format(qty, "#,##0"),
                                      Me,
                                      Grid_MaterialList, Color.Black)
                    End If
                    totalQty += qty
                End If
            End If
        Next

        Grid_MaterialList.AutoSizeCols()
        Grid_MaterialList.Redraw = True

        MSG_Information(Me, "총 입고수량 : " & Format(totalQty, "#,##0") & " EA입니다." & vbCrLf & "입고수량을 확인하여 주십시오.")

        Exit Sub

        thread_ExcelToGrid = New Thread(AddressOf ExcelToGrid)
        thread_ExcelToGrid.IsBackground = True
        thread_ExcelToGrid.SetApartmentState(ApartmentState.STA) 'OpenFileDialog를 사용하기위해선 STA로 해야되던데...
        thread_ExcelToGrid.Name = "ExcelToGrid Thread"
        thread_ExcelToGrid.Start()

    End Sub

    Private Sub ExcelToGrid()

        Thread_LoadingFormStart(Me, "Excel Load...")

        GridRedraw(False, Me, Grid_MaterialList)
        GridRowReset(1, Me, Grid_MaterialList)

        Try
            With excelApp.ActiveWorkbook.Sheets(ComboBoxTextReading(Me, CB_SheetName))
                Dim totalQty As Double = 0
                Console.WriteLine("사용된 행수 : " & .UsedRange.Rows.Count)
                For i = row_Start To .UsedRange.Rows.Count
                    Dim partCode As String = String.Empty
                    If Not col_PartCode = 0 Then partCode = Trim(.Cells(i, col_PartCode).Value)
                    Dim partNo As String = String.Empty
                    If Not col_PartNo = 0 Then partNo = Trim(.Cells(i, col_PartNo).Value)

                    If Not partCode = String.Empty Or Not partNo = String.Empty Then
                        Dim qty As Double = 0
                        If Not Trim(.Cells(i, col_Qty).Value) = String.Empty Then qty = Trim(.Cells(i, col_Qty).Value)
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
                MSG_Information(Me, "총 입고수량 : " & Format(totalQty, "#,##0") & " EA입니다." & vbCrLf & "입고수량을 확인하여 주십시오.")
            End With
        Catch ex As Exception
            MSG_Error(Me, ex.Message)
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

        CB_CustomerName.Enabled = True

        NewControlSetting()
        Load_CustomerList()

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        If TB_CustomerCode.Text = String.Empty Then
            MSG_Information(Me, "고객사를 선택하여 주십시오.")
            Exit Sub
        End If

        If MSG_Question(Me, "저장 하시겠습니까?") = False Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        If DBConnect() = False Then Exit Sub

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
                strSQL += "wd_no, document_no, supplier, part_code, part_no, vendor, part_qty, customer_code, write_date, write_id"
                strSQL += ") values("
                strSQL += "'" & documentNo & "-" & Format(i, "0000") & "'"
                strSQL += ", '" & documentNo & "'"
                strSQL += ", '" & CB_Supplier.Text & "'"
                strSQL += ", '" & Grid_MaterialList(i, 1) & "'"
                strSQL += ", '" & Grid_MaterialList(i, 2).ToString.Replace("'", "\'")  & "'"
                strSQL += ", '" & Grid_MaterialList(i, 3).ToString.Replace("'", "\'") & "'"
                strSQL += ", '" & CInt(Grid_MaterialList(i, 4)) & "'"
                strSQL += ", '" & TB_CustomerCode.Text & "'"
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

            MSG_Error(Me, ex.Message & vbCrLf & "Error No. : " & ex.Number)
            Exit Sub
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        BTN_Save.Enabled = False
        BTN_FileSelect.Enabled = False
        CB_SheetName.Enabled = False
        CB_Supplier.Enabled = False
        BTN_ExcelToGrid.Enabled = False
        CB_CustomerName.SelectedIndex = -1
        CB_CustomerName.Enabled = False
        TB_CustomerCode.Text = String.Empty

        If Not IsNothing(excelApp) Then
            excelApp.WorkBooks(1).Close()
            excelApp.Quit()
            ReleaseObject(excelApp)
            excelApp = Nothing
        End If

        BTN_Search_Click(Nothing, Nothing)

        MSG_Information(Me, "저장 완료.")

    End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart(Me)

        Grid_DocumentsList.Redraw = False
        Grid_DocumentsList.Rows.Count = 1

        If DBConnect() = False Then Exit Sub

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
            Thread_LoadingFormStart(Me)

            NewControlSetting()
            CB_Supplier.Enabled = False

            Grid_MaterialList.Redraw = False
            Grid_MaterialList.Rows.Count = 1

            If DBConnect() = False Then Exit Sub

            Dim strSQL As String = "select part_code, part_no, part_qty, vendor"
            strSQL += " from tb_mms_material_warehousing_document"
            strSQL += " where document_no = '" & Grid_DocumentsList(gridRow, 1) & "'"
            strSQL += " order by wd_no"

            Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
            Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

            Do While sqlDR.Read
                Dim insert_String As String = Grid_MaterialList.Rows.Count & vbTab &
                                              sqlDR("part_code") & vbTab &
                                              sqlDR("part_no") & vbTab &
                                              sqlDR("vendor") & vbTab &
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

    Private Sub Grid_DocumentsList_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_DocumentsList.MouseClick

        Dim selRow As Integer = Grid_DocumentsList.MouseRow

        If e.Button = MouseButtons.Right And selRow > 0 Then
            Grid_DocumentsList.Row = selRow
            Grid_Menu.Show(Grid_DocumentsList, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub BTN_RowDelete_Click(sender As Object, e As EventArgs) Handles BTN_RowDelete.Click

        Dim selRow As Integer = Grid_DocumentsList.Row
        Dim documentNo As String = Grid_DocumentsList(selRow, 1)

        If Material_Exist_Check(documentNo) = True Then
            MSG_Exclamation(Me, "입고 기록이 존재합니다")
            Exit Sub
        End If

        Dim showString As String = "문서번호 : " & documentNo
        showString += vbCrLf & "를 삭제 하시겠습니까?"

        If MSG_Question(Me, showString) = False Then Exit Sub

        If DBConnect() = False Then Exit Sub

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            strSQL += "delete from tb_mms_material_warehousing_document"
            strSQL += " where document_no = '" & documentNo & "';"

            If Not strSQL = String.Empty Then
                sqlCmd = New MySqlCommand(strSQL, dbConnection1)
                sqlCmd.Transaction = sqlTran
                sqlCmd.ExecuteNonQuery()

                sqlTran.Commit()
            End If
        Catch ex As MySqlException
            sqlTran.Rollback()
            MSG_Exclamation(Me, ex.Message)
        End Try

        DBClose()

        MSG_Information(Me, "삭제완료.")

        BTN_Search_Click(Nothing, Nothing)

    End Sub

    Private Function Material_Exist_Check(ByVal documentNo As String) As Boolean

        Dim returnValue As Boolean = False

        If DBConnect() = False Then
            Return returnValue
            Exit Function
        End If

        Dim strSQL As String = "select if(count(*)= 0, 'Not Exist', 'Exist') as material_exist"
        strSQL += " from tb_mms_material_warehousing"
        strSQL += " where document_no = '" & documentNo & "';"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            If sqlDR("material_exist") = "Exist" Then returnValue = True
        Loop
        sqlDR.Close()

        DBClose()

        Return returnValue

    End Function
End Class