Imports System.Threading
Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Order_Registration

    Dim excelApp As Object
    Dim thread_ExcelOpen As Thread
    Dim thread_ExcelRead As Thread
    Dim thread_ExcelToGrid As Thread

    Private Sub frm_Order_Registration_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

    End Sub

    Private Sub frm_Order_Registration_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

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

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub Grid_Setting()

        With Grid_Excel
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 15
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            Grid_Excel(0, 0) = "No"
            Grid_Excel(0, 1) = "모델코드"
            Grid_Excel(0, 2) = "SPG"
            Grid_Excel(0, 3) = "품번"
            Grid_Excel(0, 4) = "품명"
            Grid_Excel(0, 5) = "규격"
            Grid_Excel(0, 6) = "단위"
            Grid_Excel(0, 7) = "주문번호"
            Grid_Excel(0, 8) = "주문일자"
            Grid_Excel(0, 9) = "주문량"
            Grid_Excel(0, 10) = "납입장소"
            Grid_Excel(0, 11) = "납기일자"
            Grid_Excel(0, 12) = "모델등록"
            Grid_Excel(0, 13) = "BOM등록"
            Grid_Excel(0, 14) = "Order Index"
            .Cols(14).Visible = False
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            '.Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            .ExtendLastCol = False
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
        End With

    End Sub

    Private Sub BTN_NewOrder_Click(sender As Object, e As EventArgs) Handles BTN_NewOrder.Click

        If Not IsNothing(excelApp) Then
            excelApp.WorkBooks(1).Close()
            excelApp.Quit()
            ReleaseObject(excelApp)
            excelApp = Nothing
        End If

        BTN_Save.Enabled = True
        BTN_FileSelect.Enabled = True
        CB_CustomerName.Enabled = True

        CB_CustomerName.SelectedIndex = -1
        CB_SheetName.SelectedIndex = -1
        TB_File_Path.Text = String.Empty
        TB_CustomerCode.Text = String.Empty

        Grid_Excel.Redraw = False
        Grid_Excel.Rows.Count = 1
        Grid_Excel.Redraw = True

        Load_CustomerList()

    End Sub

    Private Sub Load_CustomerList()

        CB_CustomerName.Items.Clear()

        DBConnect()

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

        DBConnect()

        Dim strSQL As String = "select customer_code, ifnull(use_part_code, '') as use_part_code"
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

        If Not IsNothing(excelApp) Then
            excelApp.WorkBooks(1).Close()
            excelApp.Quit()
            ReleaseObject(excelApp)
            excelApp = Nothing
        End If

        If Trim(CB_CustomerName.Text) = String.Empty Then
            MessageBox.Show(Me,
                            "고객사를 먼저 선택하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If Not CB_CustomerName.Text = "LS Mecapion" Then
            MessageBox.Show(Me,
                "현재는 LS Mecapion외 사용할 수 없습니다.",
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

        TB_File_Path.Text = openFile.FileName

        Grid_Excel.Redraw = False
        Grid_Excel.Rows.Count = 1
        Grid_Excel.Redraw = True

        excelApp = CreateObject("Excel.Application")
        excelApp.WorkBooks.Open(TB_File_Path.Text)
        excelApp.Visible = False

        Load_SheetList()

    End Sub

    Private Sub Load_SheetList()

        CB_SheetName.Enabled = True
        CB_SheetName.Items.Clear()

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

        MessageBox.Show("해당 시트를 선택하여 주십시오.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly)

        ComboBoxEnabled(True, Me, CB_SheetName)

    End Sub

    Private Sub CB_SheetName_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_SheetName.SelectionChangeCommitted

        CB_SheetName.Enabled = False
        thread_ExcelRead = New Thread(AddressOf Load_TempData)
        thread_ExcelRead.IsBackground = True
        thread_ExcelRead.SetApartmentState(ApartmentState.STA) 'OpenFileDialog를 사용하기위해선 STA로 해야되던데...
        thread_ExcelRead.Name = "ExcelRead Thread"
        thread_ExcelRead.Start()

    End Sub

    Private Sub CB_SheetName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_SheetName.SelectedIndexChanged



    End Sub

    Private Sub Load_TempData()

        Thread_LoadingFormStart("Excel Open...")

        GridRedraw(False, Me, Grid_Excel)

        Try
            Dim sheetName As String = ComboBoxTextReading(Me, CB_SheetName)

            With excelApp.ActiveWorkbook.Sheets(sheetName)
                For i = 2 To .UsedRange.Rows.Count - 1
                    Dim itemSPG As String = .Cells(i, 2).Value
                    Dim itemCode As String = .Cells(i, 3).Value
                    Dim itemName As String = .Cells(i, 4).Value
                    Dim itemSpec As String = .Cells(i, 5).Value
                    Dim itemUnit As String = .Cells(i, 6).Value
                    Dim orderNumber As String = .Cells(i, 7).Value
                    Dim orderDate As Date = Format(.Cells(i, 8).Value, "yyyy-MM-dd")
                    Dim orderQuantity As Integer = .Cells(i, 9).Value
                    Dim deliveryPlace As String = .Cells(i, 14).Value
                    Dim dateOfDelivery As Date = Format(.Cells(i, 15).Value, "yyyy-MM-dd")
                    'Dim existCheck() As String = Load_ExistCheck(itemCode).Split(",")
                    'Dim itemRegister As String = existCheck(0)
                    'Dim itemBOM As String = existCheck(1)
                    Dim aList As New List(Of String)

                    For j = 1 To Grid_Excel.Rows.Count - 1
                        aList.Add(Grid_Excel(j, 7))
                    Next

                    GridWriteText("N" & vbTab &
                                  vbTab &
                                  itemSPG & vbTab &
                                  itemCode & vbTab &
                                  itemName & vbTab &
                                  itemSpec & vbTab &
                                  itemUnit & vbTab &
                                  orderNumber & vbTab &
                                  orderDate & vbTab &
                                  orderQuantity & vbTab &
                                  deliveryPlace & vbTab &
                                  dateOfDelivery & vbTab &
                                  vbTab &
                                  vbTab &
                                  orderNumber & "-" & Format(aList.FindAll(Function(x) x.Equals(orderNumber)).Count + 1, "0000"),
                                  Me,
                                  Grid_Excel,
                                  Color.Blue)
                Next
            End With
        Catch ex As Exception
            MessageBox.Show(New Form With {.TopMost = True},
                            ex.Message,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try

        RegistrationCheck()

        GridColsAutoSize(Me, Grid_Excel)
        GridRowsAutoSize(1, Grid_Excel.Rows.Count - 1, Me, Grid_Excel)

        GridRedraw(True, Me, Grid_Excel)

        Thread_LoadingFormEnd()

    End Sub

    Private Function Load_ExistCheck(ByVal itemCode As String) As String

        Dim modelExist As String = "X"
        Dim bomExist As String = "X"
        Dim model_Code As String = String.Empty
        Dim item_name As String = String.Empty
        Dim item_spec As String = String.Empty

        Dim strSQL As String = "call sp_mms_order_registration(0"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ", '" & itemCode & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            If Not sqlDR("model_exist") = 0 Then
                modelExist = "O"
                model_Code = sqlDR("model_code")
                item_name = sqlDR("item_name")
                item_spec = sqlDR("item_spec")
            End If
            If Not sqlDR("bom_exist") = 0 Then
                bomExist = "O"
            End If
        Loop
        sqlDR.Close()

        Return modelExist & "|" & bomExist & "|" & model_Code & "|" & item_spec & "|" & item_name

    End Function

    Private Sub RegistrationCheck()

        'Thread_LoadingFormStart()

        DBConnect()

        For i = 1 To Grid_Excel.Rows.Count - 1
            Dim existCheck() As String = Load_ExistCheck(Grid_Excel(i, 3)).Split("|")
            Dim itemRegister As String = existCheck(0)
            Dim itemBOM As String = existCheck(1)
            Dim modelCode As String = existCheck(2)
            Dim itemSpec As String = existCheck(3)
            Dim itemName As String = existCheck(4)

            Grid_Excel(i, 1) = modelCode
            Grid_Excel(i, 12) = itemRegister
            If itemRegister = "O" Then
                Grid_Excel(i, 4) = itemName
                Grid_Excel(i, 5) = itemSpec
            End If
            Grid_Excel(i, 13) = itemBOM
        Next

        DBClose()

        If Not IsNothing(excelApp) Then
            excelApp.WorkBooks(1).Close()
            excelApp.Quit()
            ReleaseObject(excelApp)
            excelApp = Nothing
        End If

        'Thread_LoadingFormEnd()

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click, BTN_Save2.Click

        For i = 1 To Grid_Excel.Rows.Count - 1
            If Grid_Excel(i, 12) = "X" Then
                MessageBox.Show(Me,
                                "모델 등록되지 않은 항목이 존재합니다." & vbCrLf & "모델등록을 먼저 해주십시오.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        Next

        If MsgBox("저장 하시겠습니까?",
                  MsgBoxStyle.Question + MsgBoxStyle.YesNo,
                  msg_form) = MsgBoxResult.No Then Exit Sub

        Thread_LoadingFormStart("Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim arrayPO(1, 1) As String

            For i = 1 To Grid_Excel.Rows.Count - 1
                If Grid_Excel(i, 0).ToString = "N" Then
                    strSQL += "insert into tb_mms_order_register_list("
                    strSQL += "order_index, customer_code, model_code, unit, order_no, order_date"
                    strSQL += ", order_quantity, modify_order_quantity, delivery_place, date_of_delivery, order_status, write_date, write_id"
                    strSQL += ") select "
                    strSQL += "'" & Grid_Excel(i, 14) & "'"
                    strSQL += ",'" & TB_CustomerCode.Text & "'"
                    strSQL += ",'" & Grid_Excel(i, 1) & "'"
                    strSQL += ",'" & Grid_Excel(i, 6) & "'"
                    strSQL += ",'" & Grid_Excel(i, 7) & "'"
                    strSQL += ",'" & Grid_Excel(i, 8) & "'"
                    strSQL += ",'" & Grid_Excel(i, 9) & "'"
                    strSQL += ",'" & Grid_Excel(i, 9) & "'"
                    strSQL += ",'" & Grid_Excel(i, 10) & "'"
                    strSQL += ",'" & Grid_Excel(i, 11) & "'"
                    strSQL += ",'Order Confirm'"
                    strSQL += ",'" & writeDate & "'"
                    strSQL += ",'" & loginID & "'"
                    strSQL += " from dual where not exists"
                    strSQL += " (select * from tb_mms_order_register_list"
                    strSQL += " where order_no = '" & Grid_Excel(i, 7) & "'"
                    strSQL += " and model_code = '" & Grid_Excel(i, 1) & "')"
                    strSQL += ";"
                    '위는 중복적으로 저장되는걸 방지 (같은 PO No.와 모델코드)
                End If
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
                            ex.Message,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

        DBClose()

        Thread_LoadingFormEnd()
        MessageBox.Show(Me,
                        "저장완료.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1)

        BTN_Save.Enabled = False
        BTN_FileSelect.Enabled = False
        CB_CustomerName.Enabled = False

        CB_CustomerName.SelectedIndex = -1
        CB_SheetName.SelectedIndex = -1
        TB_File_Path.Text = String.Empty
        TB_CustomerCode.Text = String.Empty

        Grid_Excel.Redraw = False
        Grid_Excel.Rows.Count = 1
        Grid_Excel.Redraw = True

    End Sub

    Private Sub BTN_NewModelRegistration_Click(sender As Object, e As EventArgs) Handles BTN_NewModelRegistration.Click

        If MessageBox.Show(Me,
                           "신규 모델을 등록 하시겠습니까?",
                           msg_form,
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Dim selRow As Integer = Grid_Excel.Row

        Grid_Excel(selRow, 1) = Search_NewModelCode()

        If Grid_Excel(selRow, 1) = String.Empty Then
            MessageBox.Show(Me,
                           "신규 모델코드를 찾지 못했습니다.",
                           msg_form,
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            strSQL += "insert into tb_model_list(model_code, customer_code, spg"
            strSQL += ", item_code, item_name, item_spec, item_note, use_bond, etc_text, write_date, write_id) values("
            strSQL += "'" & Grid_Excel(selRow, 1) & "'"
            strSQL += ",'" & TB_CustomerCode.Text & "'"
            strSQL += ",'" & Grid_Excel(selRow, 2) & "'"
            strSQL += ",'" & Replace(Grid_Excel(selRow, 3), "'", "\'") & "'"
            strSQL += ",'" & Replace(Grid_Excel(selRow, 4), "'", "\'") & "'"
            strSQL += ",'" & Replace(Grid_Excel(selRow, 5), "'", "\'") & "'"
            strSQL += ",''"
            strSQL += ",'No'"
            strSQL += ",''"
            strSQL += ",'" & writeDate & "'"
            strSQL += ",'" & loginID & "');"

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
            MessageBox.Show(ex.Message,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

        DBClose()

        Thread_LoadingFormEnd()
        MessageBox.Show("신규모델을 저장하였습니다.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1)

        Grid_Excel(selRow, 12) = "O"

    End Sub

    Private Function Search_NewModelCode() As String

        Search_NewModelCode = String.Empty

        DBConnect()

        Dim strSQL As String = "select model_code from tb_model_list order by model_code desc limit 1"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Search_NewModelCode = sqlDR("model_code")
        Loop
        sqlDR.Close()

        DBClose()

        If Search_NewModelCode = String.Empty Then
            Search_NewModelCode = "MC00000001"
        Else
            Dim addOrder As Integer = CInt(Search_NewModelCode.Substring(2, 8)) + 1
            Search_NewModelCode = "MC" & Format(addOrder, "00000000")
        End If

        Return Search_NewModelCode

    End Function

    Private Sub Grid_Excel_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_Excel.MouseClick

        Dim selRow As Integer = Grid_Excel.MouseRow

        If e.Button = MouseButtons.Right And selRow > 0 Then
            Grid_Excel.Row = selRow
            If Grid_Excel(selRow, 12) = "X" Then
                BTN_NewModelRegistration.Enabled = True
            Else
                BTN_NewModelRegistration.Enabled = False
            End If

            CMS_GridMenu.Show(Grid_Excel, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub Load_OrderNo(ByVal orderNo As String)

        BTN_Save.Enabled = False
        BTN_FileSelect.Enabled = False
        CB_CustomerName.Enabled = False
        CB_SheetName.SelectedIndex = -1
        CB_CustomerName.SelectedIndex = -1
        TB_File_Path.Text = String.Empty
        TB_CustomerCode.Text = String.Empty

        Grid_Excel.Redraw = False
        Grid_Excel.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_order_registration(2"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & orderNo & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_CustomerCode.Text = sqlDR("customer_code")
            CB_CustomerName.Items.Add(sqlDR("customer_name"))
            CB_CustomerName.Text = sqlDR("customer_name")
            Dim rowName As String = Grid_Excel.Rows.Count
            Dim rowColor As Color = Color.Black
            If sqlDR("order_status") = "Cancel" Then
                rowName = "X"
                rowColor = Color.Coral
            ElseIf sqlDR("order_status") = "Completed" Then
                rowColor = Color.OliveDrab
            End If
            Dim insert_String As String = rowName & vbTab &
                                          sqlDR("model_code") & vbTab &
                                          sqlDR("spg") & vbTab &
                                          sqlDR("item_code") & vbTab &
                                          sqlDR("item_name") & vbTab &
                                          sqlDR("item_spec") & vbTab &
                                          sqlDR("unit") & vbTab &
                                          sqlDR("order_no") & vbTab &
                                          sqlDR("order_date") & vbTab &
                                          sqlDR("order_quantity") & vbTab &
                                          sqlDR("delivery_place") & vbTab &
                                          sqlDR("date_of_delivery") & vbTab &
                                          vbTab &
                                          vbTab &
                                          sqlDR("order_index")

            GridWriteText(insert_String, Me, Grid_Excel, rowColor)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_Excel.AutoSizeCols()
        Grid_Excel.Redraw = True

    End Sub
End Class