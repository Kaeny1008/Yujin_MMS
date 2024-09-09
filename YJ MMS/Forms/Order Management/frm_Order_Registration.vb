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

        DateTimePicker1.Value = Format(Now(), "yyyy-MM-01")
        DateTimePicker2.Value = DateAdd(DateInterval.Day, -1, CDate(Format(DateAdd(DateInterval.Month, 3, Now), "yyyy-MM-01")))

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
            .Cols.Count = 17
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            .Cols(14).Visible = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            '.Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            .AutoClipboard = True
            .ExtendLastCol = False
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .Cols(8).DataType = GetType(Date)
            .Cols(8).Format = "yyyy-MM-dd"
            .Cols(9).DataType = GetType(Integer)
            .Cols(9).Format = "#,##0"
            .Cols(11).DataType = GetType(Date)
            .Cols(11).Format = "yyyy-MM-dd"
        End With

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
        Grid_Excel(0, 15) = "대조결과"
        Grid_Excel(0, 16) = "주문상태"

        Grid_Excel.AutoSizeCols()

    End Sub

    Private Sub BTN_NewOrder_Click(sender As Object, e As EventArgs) Handles BTN_NewOrder.Click

        Dim question_Text As String = RadioButton2.Text
        If RadioButton1.Checked = True Then question_Text = RadioButton1.Text
        If RadioButton3.Checked = True Then question_Text = RadioButton3.Text
        Dim showString As String = "선택된 자료 유형을 확인하여 주십시오." & vbCrLf & vbCrLf &
            "### " & question_Text & " ###" & vbCrLf & vbCrLf &
            "계속 진행하시겠습니까?"
        If MSG_Question(Me, showString) = False Then Exit Sub

        If Not IsNothing(excelApp) Then
            excelApp.WorkBooks(1).Close()
            excelApp.Quit()
            ReleaseObject(excelApp)
            excelApp = Nothing
        End If

        BTN_Save.Enabled = True
        CB_CustomerName.Enabled = True

        CB_CustomerName.SelectedIndex = -1
        CB_SheetName.SelectedIndex = -1
        TB_File_Path.Text = String.Empty
        TB_CustomerCode.Text = String.Empty

        Grid_Excel.Redraw = False
        Grid_Excel.Rows.Count = 1
        Grid_Excel.Redraw = True

        Load_CustomerList()

        If RadioButton3.Checked = True Then
            BTN_FileSelect.Enabled = False
        Else
            BTN_FileSelect.Enabled = True
        End If

        BTN_RowAdd.Enabled = False
        BTN_RowDelete.Enabled = False

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

        Load_Basic_PO(DateTimePicker1.Value,
                      DateTimePicker2.Value,
                      "개발")

        If RadioButton3.Checked = True Then
            BTN_RowAdd.Enabled = True
            BTN_RowDelete.Enabled = True
        End If

    End Sub

    Private Sub BTN_FileSelect_Click(sender As Object, e As EventArgs) Handles BTN_FileSelect.Click

        'Dim question_Text As String = RadioButton2.Text

        'If RadioButton1.Checked = True Then question_Text = RadioButton1.Text

        If Not IsNothing(excelApp) Then
            excelApp.WorkBooks(1).Close()
            excelApp.Quit()
            ReleaseObject(excelApp)
            excelApp = Nothing
        End If

        If Trim(CB_CustomerName.Text) = String.Empty Then
            MSG_Information(Me, "고객사를 먼저 선택하여 주십시오.")
            Exit Sub
        End If

        If RadioButton1.Checked = False And RadioButton2.Checked = False Then
            MSG_Information(Me, "자료 유형을 먼저 선택하여 주십시오.")
            Exit Sub
        End If

        'Dim showString As String = "선택된 자료 유형을 확인하여 주십시오." & vbCrLf & vbCrLf &
        '    "### " & question_Text & " ###" & vbCrLf & vbCrLf &
        '    "계속 진행하시겠습니까?"
        'If MSG_Question(Me, showString) = False Then Exit Sub

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

        Try
            excelApp = CreateObject("Excel.Application")
            excelApp.DisplayAlerts = False
            excelApp.WorkBooks.Open(TB_File_Path.Text)
            excelApp.Visible = False
        Catch ex As Exception
            excelApp.WorkBooks().Close()
            excelApp.Quit()
            ReleaseObject(excelApp)
            excelApp = Nothing
            MSG_Error(Me, ex.Message)
            Exit Sub
        End Try

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

        Thread_LoadingFormStart(Me, "Excel Open...")

        For i = 1 To excelApp.ActiveWorkbook.Sheets.Count
            ComboBoxItemAdd(excelApp.ActiveWorkbook.Sheets(i).Name, Me, CB_SheetName)
        Next

        Thread_LoadingFormEnd()

        MSG_Information(Me, "해당 시트를 선택하여 주십시오.")

        ComboBoxEnabled(True, Me, CB_SheetName)

    End Sub

    Private Sub CB_SheetName_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_SheetName.SelectionChangeCommitted

        If RadioButton1.Checked = True Then
            'SRM_Excel_Process()
            Etc_Excel_Process("모터")
        Else
            Etc_Excel_Process("제어")
        End If

    End Sub

    Private Sub Etc_Excel_Process(ByVal item_section As String)

        If Not IsNothing(excelApp) Then
            excelApp.WorkBooks(1).Close()
            excelApp.Quit()
            ReleaseObject(excelApp)
            excelApp = Nothing
        End If

        frm_Order_Excel_File_Open.fileName = TB_File_Path.Text
        frm_Order_Excel_File_Open.sheetName = CB_SheetName.Text
        frm_Order_Excel_File_Open.item_section = item_section
        frm_Order_Excel_File_Open.Show()

    End Sub

    Private Sub SRM_Excel_Process()

        Thread_LoadingFormStart(Me, "기존 주문 확인중...")

        Grid_Excel.Redraw = False
        Grid_Excel.Rows.Count = 1

        Load_Basic_PO(Format(DateTimePicker1.Value, "yyyy-MM-dd 00:00:00"),
                      Format(DateTimePicker2.Value, "yyyy-MM-dd 23:59:59"),
                      "모터")

        Grid_Excel.Redraw = True

        Thread_LoadingFormEnd()

        Application.DoEvents()

        CB_SheetName.Enabled = False
        thread_ExcelRead = New Thread(AddressOf Load_SRM_Data)
        thread_ExcelRead.IsBackground = True
        thread_ExcelRead.SetApartmentState(ApartmentState.STA) 'OpenFileDialog를 사용하기위해선 STA로 해야되던데...
        thread_ExcelRead.Name = "ExcelRead Thread"
        thread_ExcelRead.Start()

    End Sub

    Private Sub Load_SRM_Data()

        Thread_LoadingFormStart(Me, "Excel Open...")

        GridRedraw(False, Me, Grid_Excel)

        Dim loaderPCB_Add As Boolean = False

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
                    Dim orderQuantity As Double = .Cells(i, 9).Value
                    Dim deliveryPlace As String = .Cells(i, 14).Value
                    Dim dateOfDelivery As Date = Format(.Cells(i, 15).Value, "yyyy-MM-dd")
                    Dim aList As New List(Of String)
                    Dim indexList As New List(Of String)

                    For j = 1 To Grid_Excel.Rows.Count - 1
                        aList.Add(Grid_Excel(j, 7))
                    Next

                    Dim itemFind As Boolean = False
                    For x = 1 To Grid_Excel.Rows.Count - 1
                        If dateOfDelivery = Grid_Excel(x, 11) And itemCode = Grid_Excel(x, 3) Then
                            Dim registerQty As Double = Grid_Excel(x, 9)
                            If Not registerQty = orderQuantity Then
                                Grid_Excel(x, 0) = "M"
                                Grid_Excel(x, 15) = "수량변경"
                                Grid_Excel(x, 9) = orderQuantity
                            Else
                                Grid_Excel(x, 0) = x
                                Grid_Excel(x, 15) = String.Empty
                            End If
                            itemFind = True
                            Exit For
                        End If
                    Next

                    '동일한 주문번호가 있다면
                    '저장된 마지막 order_index를 불러 온다.
                    'For j = 1 To Grid_Excel.Rows.Count - 1
                    '    If Grid_Excel(j, 7) = orderNumber Then
                    '        indexList.Add(Grid_Excel(j, 14))
                    '    End If
                    'Next

                    'MsgBox(indexList.Max.ToString)


                    'If Not Same_PONo_Check(orderNumber) = String.Empty Then

                    'End If
                    If itemFind = False Then
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
                                      orderNumber & "-" & Format(aList.FindAll(Function(x) x.Equals(orderNumber)).Count + 1, "0000") & vbTab &
                                      "신규",
                                      Me,
                                      Grid_Excel,
                                      Color.Blue)
                        'Dim loaderPCB As String = RegistrationCheck(itemCode, Grid_Excel.Rows.Count - 1)
                        'If Not loaderPCB = String.Empty Then
                        '    GridWriteText("N" & vbTab &
                        '                  vbTab &
                        '                  vbTab &
                        '                  loaderPCB & vbTab &
                        '                  vbTab &
                        '                  vbTab &
                        '                  vbTab &
                        '                  orderNumber & vbTab &
                        '                  orderDate & vbTab &
                        '                  orderQuantity & vbTab &
                        '                  deliveryPlace & vbTab &
                        '                  dateOfDelivery & vbTab &
                        '                  vbTab &
                        '                  vbTab &
                        '                  orderNumber & "-" & Format(aList.FindAll(Function(x) x.Equals(orderNumber)).Count + 2, "0000"),
                        '                  Me,
                        '                  Grid_Excel,
                        '                  Color.Blue)
                        '    RegistrationCheck(loaderPCB, Grid_Excel.Rows.Count - 1)
                        '    loaderPCB_Add = True
                        'End If
                    End If
                Next
            End With
        Catch ex As Exception
            MSG_Error(Me, ex.Message)
        End Try

        If Not IsNothing(excelApp) Then
            excelApp.WorkBooks(1).Close()
            excelApp.Quit()
            ReleaseObject(excelApp)
            excelApp = Nothing
        End If

        GridColsAutoSize(Me, Grid_Excel)
        GridRowsAutoSize(1, Grid_Excel.Rows.Count - 1, Me, Grid_Excel)

        GridRedraw(True, Me, Grid_Excel)

        'If loaderPCB_Add = True Then
        '    MessageBox.Show(Me,
        '                    "Loader PCB를 사용하는 주문이 있습니다." & vbCrLf &
        '                    "Loader PCB PO를 자동으로 추가 하였습니다.",
        '                    msg_form,
        '                    MessageBoxButtons.OK,
        '                    MessageBoxIcon.Information)
        'End If

        Thread_LoadingFormEnd()

        Application.DoEvents()

        ETC_Excel_Last_Step()

    End Sub

    Private Function Same_PONo_Check(ByVal order_number As String) As String

        DBConnect()

        Dim strSQL As String = "call sp_mms_order_registration(6"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & order_number & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim returnString As String = String.Empty

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            returnString = sqlDR("order_index")
        Loop

        DBClose()

        Return returnString

    End Function

    Private Function RegistrationCheck(ByVal itemCode As String, ByVal rowNum As Integer) As String

        DBConnect()

        Dim existCheck() As String = Load_ExistCheck(itemCode).Split("|")
        Dim itemRegister As String = existCheck(0)
        Dim itemBOM As String = existCheck(1)
        Dim modelCode As String = existCheck(2)
        Dim itemSpec As String = existCheck(3)
        Dim itemName As String = existCheck(4)
        Dim loaderPCB As String = existCheck(5)

        Dim foreColor As Color = Color.Black

        If GridReadText(Me, Grid_Excel, rowNum, 15) = "신규" Then
            foreColor = Color.Blue
        ElseIf GridReadText(Me, Grid_Excel, rowNum, 15) = "수량변경" Then
            foreColor = Color.Red
        ElseIf GridReadText(Me, Grid_Excel, rowNum, 15) = "삭제" Then
            foreColor = Color.darkgray
        End If
        GridWriteText(modelCode, rowNum, 1, Me, Grid_Excel, foreColor)
        GridWriteText(itemRegister, rowNum, 12, Me, Grid_Excel, foreColor)
        If itemRegister = "O" Then
            GridWriteText(itemName, rowNum, 4, Me, Grid_Excel, foreColor)
            GridWriteText(itemSpec, rowNum, 5, Me, Grid_Excel, foreColor)
        End If
        GridWriteText(itemBOM, rowNum, 13, Me, Grid_Excel, foreColor)

        DBClose()

        If loaderPCB = String.Empty Then
            Return String.Empty
        Else
            Return loaderPCB
        End If

    End Function

    Private Function Load_ExistCheck(ByVal itemCode As String) As String

        Dim modelExist As String = "X"
        Dim bomExist As String = "X"
        Dim model_Code As String = String.Empty
        Dim item_name As String = String.Empty
        Dim item_spec As String = String.Empty
        Dim loaderPCB As String = String.Empty

        Dim strSQL As String = "call sp_mms_order_registration(0"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ", '" & itemCode & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
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
                loaderPCB = sqlDR("loader_pcb")
            End If
            If Not sqlDR("bom_exist") = 0 Then
                bomExist = "O"
            End If
        Loop

        Return modelExist & "|" & bomExist & "|" & model_Code & "|" & item_spec & "|" & item_name & "|" & loaderPCB

    End Function

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click, BTN_Save2.Click

        For i = 1 To Grid_Excel.Rows.Count - 1
            If Grid_Excel(i, 12) = "X" Then
                MSG_Information(Me, "모델 등록되지 않은 항목이 존재합니다." & vbCrLf & "모델등록을 먼저 해주십시오.")
                Exit Sub
            ElseIf Grid_Excel(i, 3).Equals("") Then
                MSG_Information(Me, "품번이 입력되지 않은 항목이 존재합니다.")
                Exit Sub
            ElseIf IsNothing(Grid_Excel(i, 9)) Then
                MSG_Information(Me, "주문수량이 입력되지 않은 항목이 존재 합니다.")
                Exit Sub
            ElseIf IsNothing(Grid_Excel(i, 11)) Then
                MSG_Information(Me, "납기일자가 입력되지 않은 항목이 존재 합니다.")
                Exit Sub
            End If
        Next

        If MSG_Question(Me, "저장 하시겠습니까?") = False Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim itemSection As String = "모터"
            If RadioButton2.Checked = True Then
                itemSection = "제어"
            ElseIf RadioButton3.Checked = True Then
                itemSection = "개발"
            End If

            For i = 1 To Grid_Excel.Rows.Count - 1
                If Grid_Excel(i, 0).ToString = "N" Then
                    strSQL += "insert into tb_mms_order_register_list("
                    strSQL += "order_index, customer_code, model_code, unit, order_no, order_date"
                    strSQL += ", order_quantity, modify_order_quantity, delivery_place, date_of_delivery, order_status, write_date, write_id, item_section"
                    strSQL += ") values ("
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
                    strSQL += ",'" & itemSection & "'"
                    'strSQL += " from dual where not exists"
                    'strSQL += " (select * from tb_mms_order_register_list"
                    'strSQL += " where order_no = '" & Grid_Excel(i, 7) & "'"
                    'strSQL += " and model_code = '" & Grid_Excel(i, 1) & "')"
                    strSQL += ");"
                    '위는 중복적으로 저장되는걸 방지 (같은 PO No.와 모델코드)
                ElseIf Grid_Excel(i, 0).ToString = "D" Then
                    If Not Grid_Excel(i, 16) = "Order Confirm" Then
                        Thread_LoadingFormEnd()
                        MessageBox.Show(Me,
                                        "소요량 산출이상 진행된 주문은 삭제 할 수 없습니다." & vbCrLf & "현재 행번호 : " & Grid_Excel(i, 0),
                                        msg_form,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    strSQL += "delete from tb_mms_order_register_list"
                    strSQL += " where order_index = '" & Grid_Excel(i, 14) & "'"
                    strSQL += ";"
                ElseIf Grid_Excel(i, 0).ToString = "M" Then
                    If Not Grid_Excel(i, 16) = "Order Confirm" Then
                        Thread_LoadingFormEnd()
                        MessageBox.Show(Me,
                                        "소요량 산출이상 진행된 주문은 변경 할 수 없습니다." & vbCrLf & "현재 행번호 : " & Grid_Excel(i, 0),
                                        msg_form,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    strSQL += "update tb_mms_order_register_list set"
                    strSQL += " modify_order_quantity = '" & Grid_Excel(i, 9) & "'"
                    strSQL += " where order_index = '" & Grid_Excel(i, 14) & "'"
                    strSQL += ";"
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

            MSG_Error(Me, ex.Message)
            Exit Sub
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        MSG_Information(Me, "저장완료.")

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

        If MSG_Question(Me, "신규 모델을 등록 하시겠습니까?") = False Then Exit Sub

        Dim selRow As Integer = Grid_Excel.Row

        Grid_Excel(selRow, 1) = Search_NewModelCode()
        Grid_Excel(selRow, 12) = "O"

        For i = 1 To Grid_Excel.Rows.Count - 1
            If Grid_Excel(i, 3) = Grid_Excel(selRow, 3) Then
                Grid_Excel(i, 1) = Grid_Excel(selRow, 1)
                Grid_Excel(i, 12) = "O"
            End If
        Next

        If Grid_Excel(selRow, 1) = String.Empty Then
            MSG_Information(Me, "신규 모델코드를 찾지 못했습니다.")
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

            Grid_Excel(selRow, 1) = String.Empty
            Grid_Excel(selRow, 12) = "X"

            Thread_LoadingFormEnd()

            MSG_Error(Me, ex.Message)
            Exit Sub
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        MSG_Information(Me, "신규모델을 저장하였습니다.")

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

        If e.Button = MouseButtons.Right And selRow > -1 Then
            Grid_Excel.Row = selRow
            If selRow = 0 Then
                BTN_NewModelRegistration.Enabled = False
                BTN_Save2.Enabled = False
                BTN_RowDelete.Enabled = False
            Else
                If Grid_Excel(selRow, 12) = "X" Then
                    BTN_NewModelRegistration.Enabled = True
                Else
                    BTN_NewModelRegistration.Enabled = False
                End If
                BTN_Save2.Enabled = True
                BTN_RowDelete.Enabled = True
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
        strSQL += ", null"
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

    Private Sub CB_SheetName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_SheetName.SelectedIndexChanged

    End Sub
    Public Sub ETC_Excel_Last_Step()

        Dim loaderPCB_Add As Boolean = False

        Thread_LoadingFormStart(Me, "자료 확인 중...")

        Dim totalNew As Integer = 0
        Dim totalDelete As Integer = 0
        Dim totalModify As Integer = 0

        If Grid_Excel.InvokeRequired Then
            Grid_Excel.Invoke(New Action(AddressOf ETC_Excel_Last_Step))
        Else
            Grid_Excel.Redraw = False

            For i = 1 To Grid_Excel.Rows.Count - 1

                If Grid_Excel(i, 15) = "신규" Then
                    totalNew += 1
                ElseIf Grid_Excel(i, 15) = "수량변경" Then
                    totalModify += 1
                ElseIf Grid_Excel(i, 15) = "삭제" Then
                    totalDelete += 1
                End If

                Dim loaderPCB As String = RegistrationCheck(Grid_Excel(i, 3), i)

                If Grid_Excel(i, 15) = "신규" Then
                    Grid_Excel(i, 7) = Load_PONo(Grid_Excel(i, 11))

                    Dim aList As New List(Of String)
                    For j = 1 To Grid_Excel.Rows.Count - 1
                        aList.Add(Grid_Excel(j, 7))
                    Next

                    Dim orderNumber As String = Grid_Excel(i, 7)
                    Grid_Excel(i, 14) = orderNumber & "-" & Format(aList.FindAll(Function(x) x.Equals(orderNumber)).Count, "0000")

                    If Not loaderPCB = String.Empty Then
                        LoaderPCB_Grid_Add(loaderPCB, i)
                        loaderPCB_Add = True
                    End If
                ElseIf Grid_Excel(i, 15) = String.Empty And Not loaderPCB = String.Empty Then
                    Dim loaderRow As Integer = Grid_Excel.FindRow(Grid_Excel(i, 14) & "-L", 1, 14, True)
                    If loaderRow > 1 Then
                        Grid_Excel(loaderRow, 15) = String.Empty
                        Grid_Excel(loaderRow, 0) = i
                        Grid_Excel.Rows(loaderRow).StyleNew.ForeColor = Color.Black
                    Else
                        LoaderPCB_Grid_Add(loaderPCB, i)
                        loaderPCB_Add = True
                    End If
                ElseIf Grid_Excel(i, 15) = "수량변경" And Not loaderPCB = String.Empty Then
                    Dim loaderRow As Integer = Grid_Excel.FindRow(Grid_Excel(i, 14) & "-L", 1, 14, True)
                    If loaderRow > 1 Then
                        Grid_Excel(loaderRow, 9) = Grid_Excel(i, 9)
                        Grid_Excel(loaderRow, 15) = "수량변경"
                        Grid_Excel(loaderRow, 0) = i
                        Grid_Excel.Rows(loaderRow).StyleNew.ForeColor = Color.Red
                    Else
                        LoaderPCB_Grid_Add(loaderPCB, i)
                        'GridWriteText("N" & vbTab &
                        '              vbTab &
                        '              vbTab &
                        '              loaderPCB & vbTab &
                        '              vbTab &
                        '              vbTab &
                        '              vbTab &
                        '              Grid_Excel(i, 7) & vbTab &
                        '              Grid_Excel(i, 8) & vbTab &
                        '              Grid_Excel(i, 9) & vbTab &
                        '              vbTab &
                        '              Grid_Excel(i, 11) & vbTab &
                        '              vbTab &
                        '              vbTab &
                        '              Grid_Excel(i, 14) & "-L" & vbTab &
                        '              "신규",
                        '              Me,
                        '              Grid_Excel,
                        '              Color.Blue)
                        'RegistrationCheck(loaderPCB, Grid_Excel.Rows.Count - 1)
                        loaderPCB_Add = True
                    End If
                End If
            Next
            Grid_Excel.AutoSizeCols()
            Grid_Excel.Redraw = True
        End If

        Thread_LoadingFormEnd()

        If loaderPCB_Add = True Then
            MSG_Information(Me,
                            "Loader PCB를 사용하는 주문이 있습니다." & vbCrLf &
                            "Loader PCB PO를 자동으로 추가 하였습니다.")
        End If

        Dim showString As String = "신규 : " & totalNew & " 건"
        showString += vbCrLf & "수량변경 : " & totalModify & " 건"
        showString += vbCrLf & "삭제 : " & totalDelete & " 건"
        showString += vbCrLf & "이 확인 되었습니다."

        MSG_Information(Me, showString)

    End Sub

    Private Sub LoaderPCB_Grid_Add(ByVal loaderPCB As String, ByVal referenceRow As Integer)

        GridWriteText("N" & vbTab &
                      vbTab &
                      vbTab &
                      loaderPCB & vbTab &
                      vbTab &
                      vbTab &
                      vbTab &
                      Grid_Excel(referenceRow, 7) & vbTab &
                      Grid_Excel(referenceRow, 8) & vbTab &
                      Grid_Excel(referenceRow, 9) & vbTab &
                      vbTab &
                      Grid_Excel(referenceRow, 11) & vbTab &
                      vbTab &
                      vbTab &
                      Grid_Excel(referenceRow, 14) & "-L" & vbTab &
                      "신규",
                      Me,
                      Grid_Excel,
                      Color.Blue)
        RegistrationCheck(loaderPCB, Grid_Excel.Rows.Count - 1)

    End Sub

    Private Function Load_PONo(ByVal nowDate As String) As String

        DBConnect()

        Dim returnString As String = String.Empty

        Dim strSQL As String = "select f_mms_po_no('" & nowDate & "') as po_no"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            returnString = sqlDR("po_no")
        Loop
        sqlDR.Close()

        DBClose()

        Return returnString

    End Function

    Private Function Load_PO_Check(ByVal modelCode As String, ByVal deliveryDate As Date, ByVal nowRow As Integer) As Integer

        DBConnect()

        Dim orderIndex As String = String.Empty
        Dim orderQty As Integer = 0

        Dim strSQL As String = "call sp_mms_order_registration(3"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & modelCode & "'"
        strSQL += ", '" & deliveryDate & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            orderIndex = sqlDR("order_index")
            orderQty = sqlDR("modify_order_quantity")
        Loop
        sqlDR.Close()

        DBClose()

        Return orderQty

    End Function

    Public Sub Load_Basic_PO(ByVal startDate As Date, ByVal endDate As Date, ByVal itemSection As String)

        DBConnect()

        'Dim findIndex As Integer = 4
        'If itemSection = "제어" Then
        '    findIndex = 4
        'ElseIf itemSection = "모터" Then
        '    findIndex = 5
        'End If

        Dim basicCheckString As String = "삭제"
        Dim rowColor As Color = Color.DarkGray
        If itemSection.Equals("개발") Then
            basicCheckString = String.Empty
            rowColor = Color.Black
        End If

        Dim strSQL As String = "call sp_mms_order_registration(4"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & Format(startDate, "yyyy-MM-dd 00:00:00") & "'"
        strSQL += ", '" & Format(endDate, "yyyy-MM-dd 23:59:59") & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ",'" & itemSection & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            'Dim rowName As String = Grid_Excel.Rows.Count
            Dim insert_String As String = "D" & vbTab &
                                          sqlDR("model_code") & vbTab &
                                          sqlDR("spg") & vbTab &
                                          sqlDR("item_code") & vbTab &
                                          sqlDR("item_name") & vbTab &
                                          sqlDR("item_spec") & vbTab &
                                          sqlDR("unit") & vbTab &
                                          sqlDR("order_no") & vbTab &
                                          sqlDR("order_date") & vbTab &
                                          sqlDR("modify_order_quantity") & vbTab &
                                          sqlDR("delivery_place") & vbTab &
                                          sqlDR("date_of_delivery") & vbTab &
                                          vbTab &
                                          vbTab &
                                          sqlDR("order_index") & vbTab &
                                          basicCheckString & vbTab &
                                          sqlDR("order_status")
            GridWriteText(insert_String, Me, Grid_Excel, rowColor)
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged

        If RadioButton3.Checked = True Then
            Panel2.Enabled = True
            Grid_Excel.AllowEditing = True
        Else
            Panel2.Enabled = False
            Grid_Excel.AllowEditing = False
        End If

        Grid_Excel.Rows.Count = 1
        CB_CustomerName.SelectedIndex = -1
        TB_CustomerCode.Text = String.Empty
        TB_File_Path.Text = String.Empty
        CB_SheetName.SelectedIndex = -1

    End Sub

    Private Sub CB_CustomerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_CustomerName.SelectedIndexChanged

    End Sub

    Private Sub BTN_RowAdd_Click(sender As Object, e As EventArgs) Handles BTN_RowAdd.Click

        Dim selRow As Integer = Grid_Excel.Row

        Grid_Excel.AddItem("N" & vbTab &
                           vbTab &
                           vbTab &
                           vbTab &
                           vbTab &
                           vbTab &
                           vbTab &
                           vbTab &
                           Now & vbTab &
                           vbTab &
                           vbTab &
                           vbTab &
                           vbTab &
                           vbTab &
                           vbTab &
                           "신규",
                           selRow + 1)
        Grid_Excel.Rows(selRow + 1).StyleNew.ForeColor = Color.Blue

        Grid_Excel.AutoSizeCols()

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

        Grid_Excel.Rows.Count = 1
        CB_CustomerName.SelectedIndex = -1
        TB_CustomerCode.Text = String.Empty
        TB_File_Path.Text = String.Empty
        CB_SheetName.SelectedIndex = -1

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

        Grid_Excel.Rows.Count = 1
        CB_CustomerName.SelectedIndex = -1
        TB_CustomerCode.Text = String.Empty
        TB_File_Path.Text = String.Empty
        CB_SheetName.SelectedIndex = -1

    End Sub

    Private Sub Grid_Excel_RowColChange(sender As Object, e As EventArgs) Handles Grid_Excel.RowColChange

        If Grid_Excel.Row > 1 Or Grid_Excel.Col > 1 Then Exit Sub

        Select Case Grid_Excel.Col
            Case 3, 9, 11
                If Grid_Excel(Grid_Excel.Row, 0).ToString = "D" Then
                    Grid_Excel.AllowEditing = False
                Else
                    If RadioButton3.Checked = True Then
                        Grid_Excel.AllowEditing = True
                    Else
                        Grid_Excel.AllowEditing = False
                    End If
                End If
            Case Else
                Grid_Excel.AllowEditing = False
        End Select

    End Sub

    Dim beforeString As String

    Private Sub Grid_Excel_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Grid_Excel.BeforeEdit

        beforeString = Grid_Excel(e.Row, e.Col)

    End Sub

    Private Sub Grid_Excel_AfterEdit(sender As Object, e As RowColEventArgs) Handles Grid_Excel.AfterEdit

        If e.Row < 0 Or e.Col < 0 Then Exit Sub

        If beforeString = Grid_Excel(e.Row, e.Col) Then Exit Sub

        Grid_Excel.Redraw = False

        Select Case e.Col
            Case 3
                Dim loaderPCB_Add As Boolean = False
                Dim loaderPCB As String = RegistrationCheck(Grid_Excel(e.Row, 3), e.Row)

                If Not loaderPCB = String.Empty Then
                    LoaderPCB_Grid_Add(loaderPCB, e.Row)
                    loaderPCB_Add = True
                End If

                If loaderPCB_Add = True Then
                    MSG_Information(Me,
                                    "Loader PCB PO를 자동으로 추가 하였습니다.")
                End If
            Case 11
                Grid_Excel(e.Row, 7) = Load_PONo(Grid_Excel(e.Row, 11))

                Dim aList As New List(Of String)
                For j = 1 To Grid_Excel.Rows.Count - 1
                    aList.Add(Grid_Excel(j, 7))
                Next

                Dim orderNumber As String = Grid_Excel(e.Row, 7)
                Grid_Excel(e.Row, 14) = orderNumber & "-" & Format(aList.FindAll(Function(x) x.Equals(orderNumber)).Count, "0000")
        End Select

        If IsNumeric(Grid_Excel(e.Row, 0)) Then
            Grid_Excel(e.Row, 0) = "M"
            Grid_Excel.Rows(e.Row).StyleNew.ForeColor = Color.Red
        End If

        Grid_Excel.AutoSizeCols()
        Grid_Excel.Redraw = True

    End Sub
End Class