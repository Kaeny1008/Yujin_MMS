Imports System.IO
Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Assy_Label_Print
    Private Sub frm_Assy_Label_Print_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        DTP_Start.Value = Format(Now, "yyyy-MM-01")
        DTP_End.Value = Format(Now, "yyyy-MM-dd")
        DTP_ReprintDate.Value = Format(Now, "yyyy-MM-dd")
        DateTimePicker1.Value = Format(Now, "yyyy-MM-01")
        DateTimePicker2.Value = Format(Now, "yyyy-MM-dd")

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub Grid_Setting()

        With Grid_LabelList
            .AllowEditing = False
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 5
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
        End With

        Grid_LabelList(0, 0) = "No"
        Grid_LabelList(0, 1) = "품목명"
        Grid_LabelList(0, 2) = "품목코드"
        Grid_LabelList(0, 3) = "제조년월일"
        Grid_LabelList(0, 4) = "Serial No."

        Grid_LabelList.AutoSizeCols()

        With Grid_History
            .AllowEditing = False
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 13
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .Cols(7).DataType = GetType(Integer)
            .Cols(7).Format = "#,##0"
            .Cols(8).DataType = GetType(Integer)
            .Cols(8).Format = "#,##0"
            .Cols(9).DataType = GetType(Integer)
            .Cols(9).Format = "#,##0"
            .Cols(10).DataType = GetType(Integer)
            .Cols(10).Format = "#,##0"
            .Cols(11).DataType = GetType(DateTime)
            .Cols(11).Format = "yyyy-MM-dd HH:mm:ss"
            .Cols(11).TextAlign = TextAlignEnum.CenterCenter
        End With

        Grid_History(0, 0) = "No"
        Grid_History(0, 1) = "History No"
        Grid_History(0, 2) = "주문번호"
        Grid_History(0, 3) = "고객사"
        Grid_History(0, 4) = "품번"
        Grid_History(0, 5) = "품명"
        Grid_History(0, 6) = "규격"
        Grid_History(0, 7) = "주문수량"
        Grid_History(0, 8) = "발행수"
        Grid_History(0, 9) = "시작번호"
        Grid_History(0, 10) = "종료번호"
        Grid_History(0, 11) = "발행일자"
        Grid_History(0, 12) = "발행자"

        Grid_History.AutoSizeCols()

        With Grid_ReprintList
            .AllowEditing = False
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 10
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .Cols(6).DataType = GetType(DateTime)
            .Cols(6).Format = "yyyy-MM-dd"
            .Cols(6).TextAlign = TextAlignEnum.CenterCenter
            .Cols(7).DataType = GetType(Integer)
            .Cols(7).Format = "#,##0"
            .Cols(8).DataType = GetType(DateTime)
            .Cols(8).Format = "yyyy-MM-dd HH:mm:ss"
            .Cols(8).TextAlign = TextAlignEnum.CenterCenter
        End With

        Grid_ReprintList(0, 0) = "No"
        Grid_ReprintList(0, 1) = "History No"
        Grid_ReprintList(0, 2) = "고객사"
        Grid_ReprintList(0, 3) = "품번"
        Grid_ReprintList(0, 4) = "품명"
        Grid_ReprintList(0, 5) = "규격"
        Grid_ReprintList(0, 6) = "생산일자"
        Grid_ReprintList(0, 7) = "생산순번"
        Grid_ReprintList(0, 8) = "재발행일자"
        Grid_ReprintList(0, 9) = "재발행자"

        Grid_ReprintList.AutoSizeCols()

    End Sub

    Private Sub Control_Init()

        TB_OrderIndex.Text = String.Empty
        TB_LastProcess.Text = String.Empty
        TB_ItemCode.Text = String.Empty
        TB_ItemName.Text = String.Empty
        TB_ItemSpec.Text = String.Empty
        TB_POQty.Text = String.Empty
        TB_ModelCode.Text = String.Empty
        TextBox3.Text = String.Empty
        TB_HistoryNo.Text = String.Empty

        BTN_SaveAndPrint.Enabled = False

        Grid_LabelList.Rows.Count = 1

        CheckBox1.Checked = False
        CheckBox2.Checked = False
        TB_Label_ItemName.Text = String.Empty
        TB_Label_FW.Text = String.Empty
        TB_Label_Boot.Text = String.Empty
        TB_Label_FPGA.Text = String.Empty

    End Sub

    Private Sub TB_MagazineBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_MagazineBarcode.KeyDown

        If e.KeyCode = 13 And Not Trim(TB_MagazineBarcode.Text) = String.Empty Then
            'PO202404010002-0011!51!SMD
            'PO202404010002-0004!WSO2405160856453858!WAVE SOLDERING
            Control_Init()

            Try
                Dim splitBarcode() As String = TB_MagazineBarcode.Text.Split("!")
                TB_OrderIndex.Text = splitBarcode(0)
                TB_HistoryNo.Text = splitBarcode(1)
                TB_LastProcess.Text = splitBarcode(2)
            Catch ex As Exception
                MessageBox.Show(Me,
                                    "유진 공정라벨을 스캔하여 주십시오.",
                                    msg_form,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
                TB_MagazineBarcode.SelectAll()
                TB_MagazineBarcode.Focus()
                Exit Sub
            End Try

            TB_MagazineBarcode.Text = String.Empty

            'PO 정보를 불러온다.
            If Load_Po_Information() = False Then
                MessageBox.Show(Me,
                                    "현재 모델의 품목명을 불러 올 수 없습니다.",
                                    msg_form,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
                Control_Init()
                TB_MagazineBarcode.SelectAll()
                TB_MagazineBarcode.Focus()
                Exit Sub
            Else
                If TB_ItemCode.Text = String.Empty Then
                    MessageBox.Show(Me,
                                        "모델 정보를 불러오지 못했습니다.",
                                        msg_form,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation)
                    Control_Init()
                    TB_MagazineBarcode.SelectAll()
                    TB_MagazineBarcode.Focus()
                    Exit Sub
                End If
            End If

            If Load_PrintTotalQty() = CInt(TB_POQty.Text) Then
                MessageBox.Show(Me,
                                        "이미 발행을 완료한 주문번호 입니다.",
                                        msg_form,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation)
                Control_Init()
                TB_MagazineBarcode.SelectAll()
                TB_MagazineBarcode.Focus()
                Exit Sub
            End If

            'History를 확인한다(현품표 수량확인)
            Load_History_Information(TB_HistoryNo.Text)
            If TB_NowQty.Text = String.Empty Then
                MessageBox.Show(Me,
                                    "공정현품표를 확인 할 수 없습니다.",
                                    msg_form,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
                Control_Init()
                TB_MagazineBarcode.SelectAll()
                TB_MagazineBarcode.Focus()
                Exit Sub
            End If

            Dim rePrintDate As DateTime = Now
            If CB_Reprint.Checked = True Then
                rePrintDate = Load_History_Print_Content()
            Else
                '중복발행 체크
                If Check_Print() = False Then
                    MessageBox.Show(Me,
                                        "이미 발행한 현품표입니다.",
                                        msg_form,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation)
                    Control_Init()
                    TB_MagazineBarcode.SelectAll()
                    TB_MagazineBarcode.Focus()
                    Exit Sub
                End If

                '마지막 발행No를 불러 온다.
                Load_LastNo()
                If TextBox3.Text = String.Empty Then
                    TextBox3.Text = 0
                End If
            End If

            Grid_LabelList.Redraw = False
            Dim startNo As Integer = CInt(TextBox3.Text)
            For i = 1 To CInt(TB_NowQty.Text)
                startNo += 1
                Dim insertString As String = Grid_LabelList.Rows.Count
                insertString += vbTab & TB_Label_ItemName.Text
                insertString += vbTab & TB_ItemCode.Text
                insertString += vbTab & Format(rePrintDate, "yyMMdd")
                insertString += vbTab & Format(startNo, "0000")
                Grid_LabelList.AddItem(insertString)
            Next
            Grid_LabelList.Redraw = True
            Grid_LabelList.AutoSizeCols()

            BTN_SaveAndPrint.Enabled = True
        End If

    End Sub

    Private Function Load_History_Print_Content() As DateTime

        Thread_LoadingFormStart()

        DBConnect()

        Dim writeDate As String = String.Empty

        Dim strSQL As String = "call sp_mms_assy_label_history(11"
        strSQL += ", '" & TB_OrderIndex.Text & "'"
        strSQL += ", '" & TB_HistoryNo.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
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
            TextBox3.Text = CDbl(sqlDR("start_no")) - 1
            writeDate = sqlDR("write_date")
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

        Return writeDate

    End Function

    Private Function Load_Po_Information() As Boolean

        Thread_LoadingFormStart()

        DBConnect()

        Dim strSQL As String = "call sp_mms_assy_label_history(0"
        strSQL += ", '" & TB_OrderIndex.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
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
            TB_ItemCode.Text = sqlDR("item_code")
            TB_ItemName.Text = sqlDR("item_name")
            TB_ItemSpec.Text = sqlDR("item_spec")
            TB_POQty.Text = sqlDR("modify_order_quantity")
            TB_ModelCode.Text = sqlDR("model_code")
            If sqlDR("assy_label_use") = 1 Then
                CheckBox1.Checked = True
                TB_Label_ItemName.Text = sqlDR("item_name_label")
            End If
            If sqlDR("sw_label_use") = 1 Then
                CheckBox2.Checked = True
                TB_Label_FW.Text = sqlDR("fw_os_label")
                TB_Label_Boot.Text = sqlDR("boot_label")
                TB_Label_FPGA.Text = sqlDR("fpga_label")
            End If
            TextBox1.Text = sqlDR("customer_name")
            TextBox4.Text = sqlDR("customer_code")
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

        If TB_ModelCode.Text = String.Empty Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub Load_History_Information(ByVal historyNo As String)

        Thread_LoadingFormStart()

        DBConnect()

        Dim indexSelect As Integer = 1

        If Not TB_LastProcess.Text = "SMD" Then
            indexSelect = 2
        End If

        Dim strSQL As String = "call sp_mms_assy_label_history(" & indexSelect
        strSQL += ", null"
        strSQL += ", '" & historyNo & "'"
        strSQL += ", null"
        strSQL += ", null"
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
            TB_NowQty.Text = sqlDR("end_quantity")
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_LastNo()

        Thread_LoadingFormStart()

        DBConnect()

        Dim strSQL As String = "call sp_mms_assy_label_history(3"
        strSQL += ", '" & TB_OrderIndex.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
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
            TextBox3.Text = sqlDR("end_no")
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

    End Sub

    Private Function Check_Print() As Boolean

        Dim existHistory As String = String.Empty

        Thread_LoadingFormStart()

        DBConnect()

        Dim strSQL As String = "call sp_mms_assy_label_history(4"
        strSQL += ", '" & TB_OrderIndex.Text & "'"
        strSQL += ", '" & TB_HistoryNo.Text & "'"
        strSQL += ", '" & TB_LastProcess.Text & "'"
        strSQL += ", null"
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
            existHistory = sqlDR("history_no")
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

        If existHistory = String.Empty Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Function Load_PrintTotalQty() As Integer

        Dim printQty As Integer = 0

        Thread_LoadingFormStart()

        DBConnect()

        Dim strSQL As String = "call sp_mms_assy_label_history(6"
        strSQL += ", '" & TB_OrderIndex.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
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
            printQty = sqlDR("print_qty")
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

        Return printQty

    End Function

    Private Sub BTN_SaveAndPrint_Click(sender As Object, e As EventArgs) Handles BTN_SaveAndPrint.Click

        If TextBox2.Text = String.Empty Then
            MessageBox.Show(Me,
                            "발행자를 입력하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            TextBox2.Focus()
            Exit Sub
        End If

        If MessageBox.Show(Me,
                           "라벨을 발행 하시겠습니까?",
                           msg_form,
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Dim wirteResult As String = String.Empty
        If CB_Reprint.Checked = True Then
            wirteResult = DB_Write_All_Reprint()
        Else
            wirteResult = DB_Write()
        End If

        If Not wirteResult = String.Empty Then
            MessageBox.Show(Me,
                                wirteResult,
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
            Exit Sub
        End If

        PrintLabel()

        MessageBox.Show(Me,
                        "발행 및 저장완료.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
        CB_Reprint.Checked = False
        Control_Init()

    End Sub

    Private Function DB_Write_All_Reprint() As String

        Dim writeResult As String = String.Empty

        Thread_LoadingFormStart("Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Dim nowTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
        Dim nowDate As String = Format(Now, "yyyy-MM-dd")

        Try
            For i = 1 To Grid_LabelList.Rows.Count - 1
                strSQL += "insert into tb_mms_assy_label_reprint("
                strSQL += "history_index, customer_code, model_code"
                strSQL += ", label_date, serial_no, write_date, write_id"
                strSQL += ") values("
                strSQL += "f_mms_assy_label_reprint_no('" & nowDate & "')"
                strSQL += ",'" & TextBox4.Text & "'"
                strSQL += ",'" & TB_ModelCode.Text & "'"
                strSQL += ",'" & Grid_LabelList(i, 3) & "'"
                strSQL += "," & Grid_LabelList(i, 4) & ""
                strSQL += ",'" & nowTime & "'"
                strSQL += ",'" & TextBox2.Text & "'"
                strSQL += ");"
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
            writeResult = ex.Message

            Return writeResult
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        Return writeResult

    End Function

    Private Function DB_Write() As String

        Dim writeResult As String = String.Empty

        Thread_LoadingFormStart("Writing...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Dim nowTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
        Dim nowDate As String = Format(Now, "yyyy-MM-dd")

        Try
            strSQL += "insert into tb_mms_assy_label_history("
            strSQL += "history_no, order_index, process_name, process_history"
            strSQL += ", print_qty, start_no, end_no, write_date, write_id"
            strSQL += ") values("
            strSQL += "f_mms_assy_label_history_no('" & nowDate & "')"
            strSQL += ",'" & TB_OrderIndex.Text & "'"
            strSQL += ",'" & TB_LastProcess.Text & "'"
            strSQL += ",'" & TB_HistoryNo.Text & "'"
            strSQL += ",'" & TB_NowQty.Text & "'"
            strSQL += "," & CInt(TextBox3.Text) + 1 & ""
            strSQL += "," & CInt(TextBox3.Text) + CInt(TB_NowQty.Text) & ""
            strSQL += ",'" & nowTime & "'"
            strSQL += ",'" & TextBox2.Text & "'"
            strSQL += ");"

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
            writeResult = ex.Message

            Return writeResult
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        Return writeResult

    End Function

    Private Sub PrintLabel()

        If File.Exists(Application.StartupPath & "\print.txt") Then File.Delete(Application.StartupPath & "\print.txt")

        Dim swFile As StreamWriter =
            New StreamWriter(Application.StartupPath & "\print.txt", True, System.Text.Encoding.GetEncoding(949))

        Dim serialNo As String = Format(Now, "yyMMdd") & Format(CInt(TextBox3.Text) + 1, "0000")
        Dim barcodeString As String = TB_ItemCode.Text & serialNo
        Dim itemCodeLength As Integer = TB_ItemCode.Text.Length
        Dim continueChar As String = String.Empty

        For i = 1 To itemCodeLength + 9 '제조년월일 + QR에 필요한 문자 3자리 추가
            continueChar += "%"
        Next

        continueChar += "dddd"

        If CheckBox1.Checked = True Then
            swFile.WriteLine("^XZ~JA^XZ")
            swFile.WriteLine("^XA^LH" & printerLeftPosition & ",0^LT" & printerTopPosition) 'LH : 가로위치, LT : 세로위치
            swFile.WriteLine("^MD25") '진하기
            swFile.WriteLine("^FO0004,0012^A0,25,18^FD" & TB_Label_ItemName.Text & "^FS")
            swFile.WriteLine("^FO0004,0041^A0,25,18^FD" & TB_ItemCode.Text & "^FS")
            swFile.WriteLine("^FO0004,0070^A0,25,18^FD" & serialNo & "^SF%%%%%%dddd,1^FS")
            swFile.WriteLine("^FO0150,0002^BQN,2,3^FDHA," & barcodeString & "^SF" & continueChar & ",1^FS")
            swFile.WriteLine("^PQ" & CInt(TB_NowQty.Text) & "^FS") 'PQ : 발행수량
            swFile.WriteLine("^XZ")
        End If

        If CheckBox2.Checked = True Then
            Dim lineCount As Integer = 0
            Dim firstLine As String = String.Empty
            Dim secondLine As String = String.Empty
            Dim thirdLine As String = String.Empty
            If Not TB_Label_FW.Text = String.Empty Then
                lineCount += 1
                firstLine = "FW : V" & TB_Label_FW.Text
            End If
            If Not TB_Label_Boot.Text = String.Empty Then
                lineCount += 1
                If firstLine = String.Empty Then
                    firstLine = "Boot : V" & TB_Label_Boot.Text
                Else
                    secondLine = "Boot : V" & TB_Label_Boot.Text
                End If
            End If
            If Not TB_Label_FPGA.Text = String.Empty Then
                lineCount += 1
                If firstLine = String.Empty Then
                    firstLine = "FPGA : V" & TB_Label_FPGA.Text
                ElseIf secondLine = String.Empty Then
                    secondLine = "FPGA : V" & TB_Label_FPGA.Text
                ElseIf thirdLine = String.Empty Then
                    thirdLine = "FPGA : V" & TB_Label_FPGA.Text
                End If
            End If

            swFile.WriteLine("^XZ~JA^XZ")
            swFile.WriteLine("^XA^LH" & printerLeftPosition & ",0^LT" & printerTopPosition) 'LH : 가로위치, LT : 세로위치
            swFile.WriteLine("^MD25") '진하기
            If lineCount = 3 Then
                swFile.WriteLine("^FO0020,0012^A0,25,25^FD" & firstLine & "^FS")
                swFile.WriteLine("^FO0020,0041^A0,25,25^FD" & secondLine & "^FS")
                swFile.WriteLine("^FO0020,0070^A0,25,25^FD" & thirdLine & "^FS")
            ElseIf lineCount = 2 Then
                swFile.WriteLine("^FO0020,0025^A0,25,25^FD" & firstLine & "^FS")
                swFile.WriteLine("^FO0020,0055^A0,25,25^FD" & secondLine & "^FS")
            ElseIf lineCount = 1 Then
                swFile.WriteLine("^FO0020,0041^A0,25,25^FD" & firstLine & "^FS")
            End If
            swFile.WriteLine("^PQ" & CInt(TB_NowQty.Text) & "^FS") 'PQ : 발행수량
            swFile.WriteLine("^XZ")
        End If

        swFile.Close()

        Dim printResult As String = LabelPrint()

        If Not printResult = "Success" Then
            MessageBox.Show(frm_Main,
                            "라벨 발행에 실패 하였습니다." & vbCrLf &
                            printResult,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub C1DockingTab1_SelectedTabChanged(sender As Object, e As EventArgs) Handles C1DockingTab1.SelectedTabChanged

        If C1DockingTab1.SelectedIndex = 1 Then
            Load_CustomerList(CB_CustomerName)
        ElseIf C1DockingTab1.SelectedIndex = 2 Then
            Load_CustomerList(CB_Reprint_CustomerName)
            Load_CustomerList(CB_Reprint_Search_CustomerName)
        End If

    End Sub

    Private Sub Load_CustomerList(ByVal cb As ComboBox)

        cb.Items.Clear()

        DBConnect()

        Dim strSQL As String = "select customer_name"
        strSQL += " from tb_customer_list"
        strSQL += " order by customer_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            cb.Items.Add(sqlDR("customer_name"))
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub CB_CustomerName_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_CustomerName.SelectionChangeCommitted

        TB_CustomerCode.Text = String.Empty

        DBConnect()

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

    Private Sub CB_Reprint_CustomerName_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_Reprint_CustomerName.SelectionChangeCommitted

        TB_Reprint_CustomerCode.Text = String.Empty

        DBConnect()

        Dim strSQL As String = "select customer_code"
        strSQL += " from tb_customer_list"
        strSQL += " where customer_name = '" & CB_Reprint_CustomerName.Text & "'"
        strSQL += " order by customer_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_Reprint_CustomerCode.Text = sqlDR("customer_code")
        Loop
        sqlDR.Close()

        DBClose()

        TB_Reprint_ItemCode.SelectAll()
        TB_Reprint_ItemCode.Focus()

    End Sub

    Private Sub CB_Reprint_Search_CustomerName_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_Reprint_Search_CustomerName.SelectionChangeCommitted

        TB_Reprint_Search_CustomerCode.Text = String.Empty

        DBConnect()

        Dim strSQL As String = "select customer_code"
        strSQL += " from tb_customer_list"
        strSQL += " where customer_name = '" & CB_Reprint_Search_CustomerName.Text & "'"
        strSQL += " order by customer_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_Reprint_Search_CustomerCode.Text = sqlDR("customer_code")
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub BTN_HistorySearch_Click(sender As Object, e As EventArgs) Handles BTN_HistorySearch.Click

        Thread_LoadingFormStart()

        Grid_History.Redraw = False
        Grid_History.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_assy_label_history(5"
        strSQL += ", '" & TB_SearchOrderIndex.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ", '" & Format(DTP_Start.Value, "yyyy-MM-dd 00:00:00") & "'"
        strSQL += ", '" & Format(DTP_End.Value, "yyyy-MM-dd 23:59:59") & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = Grid_History.Rows.Count
            insertString += vbTab & sqlDR("history_no")
            insertString += vbTab & sqlDR("order_index")
            insertString += vbTab & sqlDR("customer_name")
            insertString += vbTab & sqlDR("item_code")
            insertString += vbTab & sqlDR("item_name")
            insertString += vbTab & sqlDR("item_spec")
            insertString += vbTab & sqlDR("modify_order_quantity")
            insertString += vbTab & sqlDR("print_qty")
            insertString += vbTab & sqlDR("start_no")
            insertString += vbTab & sqlDR("end_no")
            insertString += vbTab & sqlDR("write_date")
            insertString += vbTab & sqlDR("write_id")

            Grid_History.AddItem(insertString)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_History.AutoSizeCols()
        Grid_History.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub TB_Reprint_ItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_Reprint_ItemCode.KeyDown

        If e.KeyCode = 13 And Not Trim(TB_Reprint_ItemCode.Text) = String.Empty Then
            BTN_PrintCodeSelect_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub BTN_PrintCodeSelect_Click(sender As Object, e As EventArgs) Handles BTN_PrintCodeSelect.Click

        Thread_LoadingFormStart()

        TB_Reprint_ItemName.Text = String.Empty
        TB_Reprint_ItemSpec.Text = String.Empty
        TB_Reprint_Unique.Text = String.Empty

        Load_Reprint_Basic_Information()

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_Reprint_Basic_Information()

        DBConnect()

        Dim strSQL As String = "call sp_mms_assy_label_history(7"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_Reprint_CustomerCode.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_Reprint_ItemCode.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_Reprint_ItemName.Text = sqlDR("item_name")
            TB_Reprint_ItemSpec.Text = sqlDR("item_spec")
            'TB_Reprint_Unique.Text = sqlDR("barcode_string")
            TB_Reprint_ModelCode.Text = sqlDR("model_code")
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub DTP_ReprintDate_ValueChanged(sender As Object, e As EventArgs) Handles DTP_ReprintDate.ValueChanged

        TB_Reprint_Date.Text = Format(DTP_ReprintDate.Value, "yyMMdd")

    End Sub

    Private Sub TB_Reprint_Serial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TB_Reprint_Serial.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "," Then
            e.Handled = True
        End If

    End Sub

    Private Sub BTN_Reprint_Click(sender As Object, e As EventArgs) Handles BTN_Reprint.Click

        If Trim(TB_Reprint_Serial.Text) = String.Empty Then
            MessageBox.Show(Me,
                            "생산순번이 입력되지 않았습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            TB_Reprint_Serial.SelectAll()
            TB_Reprint_Serial.Focus()
            Exit Sub
        End If

        If CInt(TB_Reprint_Serial.Text) > 9999 Then
            MessageBox.Show(Me,
                            "생산순번은 9,999를 초과할 수 없습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            TB_Reprint_Serial.SelectAll()
            TB_Reprint_Serial.Focus()
            Exit Sub
        End If

        If Trim(TB_Reprintor.Text) = String.Empty Then
            MessageBox.Show(Me,
                            "발행자가 입력되지 않았습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            TB_Reprintor.SelectAll()
            TB_Reprintor.Focus()
            Exit Sub
        End If

        '라벨 발행 이력이 있는지 검증
        Dim managementNo As String = Reprint_IndexCheck()
        If managementNo = String.Empty Then
            MessageBox.Show(Me,
                            "생산이력을 확인 할 수 없습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Exit Sub
        End If

        Reprint_Load_ItemName(managementNo)

        If TB_Reprint_Unique.Text = String.Empty Then
            MessageBox.Show(Me,
                            "품목명을 찾을 수 없습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            TB_Reprint_ItemCode.SelectAll()
            TB_Reprint_ItemCode.Focus()
            Exit Sub
        End If

        If MessageBox.Show(Me,
                           "라벨을 재발행 하시겠습니까?",
                           msg_form,
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Dim wirteResult As String = DB_Reprint_Write()
        If Not wirteResult = String.Empty Then
            MessageBox.Show(Me,
                            wirteResult,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Exit Sub
        End If

        RePrintLabel()

        MessageBox.Show(Me,
                        "발행 및 저장완료.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

        TB_Reprint_ItemCode.Text = String.Empty
        TB_Reprint_ItemName.Text = String.Empty
        TB_Reprint_ItemSpec.Text = String.Empty
        TB_Reprint_ModelCode.Text = String.Empty
        TB_Reprint_Unique.Text = String.Empty
        TB_Reprint_Serial.Text = String.Empty


        BTN_Reprint_List_Click(Nothing, Nothing)

    End Sub

    Private Sub Reprint_Load_ItemName(ByVal managementNo As String)

        Thread_LoadingFormStart()

        DBConnect()

        Dim strSQL As String = "call sp_mms_assy_label_history(10"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_Reprint_ModelCode.Text & "'"
        strSQL += ", '" & managementNo & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_Reprint_Unique.Text = sqlDR("item_name")
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

    End Sub

    Private Function Reprint_IndexCheck() As String

        Thread_LoadingFormStart()

        Dim maxSerial As Integer = 0
        Dim managementNo As String = String.Empty

        DBConnect()

        Dim strSQL As String = "call sp_mms_assy_label_history(9"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & Format(DTP_ReprintDate.Value, "yyyy-MM-dd") & "'"
        strSQL += ", '" & TB_Reprint_ModelCode.Text & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            maxSerial = sqlDR("end_no")
            managementNo = sqlDR("management_no")
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

        If CInt(TB_Reprint_Serial.Text) > maxSerial Then
            Return String.Empty
        Else
            Return managementNo
        End If

    End Function

    Private Function DB_Reprint_Write() As String

        Dim writeResult As String = String.Empty

        Thread_LoadingFormStart("Writing...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Dim nowTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
        Dim nowDate As String = Format(Now, "yyyy-MM-dd")

        Try
            strSQL += "insert into tb_mms_assy_label_reprint("
            strSQL += "history_index, customer_code, model_code"
            strSQL += ", label_date, serial_no, write_date, write_id"
            strSQL += ") values("
            strSQL += "f_mms_assy_label_reprint_no('" & nowDate & "')"
            strSQL += ",'" & TB_Reprint_CustomerCode.Text & "'"
            strSQL += ",'" & TB_Reprint_ModelCode.Text & "'"
            strSQL += ",'" & TB_Reprint_Date.Text & "'"
            strSQL += "," & TB_Reprint_Serial.Text & ""
            strSQL += ",'" & nowTime & "'"
            strSQL += ",'" & TB_Reprintor.Text & "'"
            strSQL += ");"

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
            writeResult = ex.Message

            Return writeResult
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        Return writeResult

    End Function

    Private Sub RePrintLabel()

        If File.Exists(Application.StartupPath & "\print.txt") Then File.Delete(Application.StartupPath & "\print.txt")

        Dim swFile As StreamWriter =
            New StreamWriter(Application.StartupPath & "\print.txt", True, System.Text.Encoding.GetEncoding(949))

        Dim serialNo As String = TB_Reprint_Date.Text & Format(CInt(TB_Reprint_Serial.Text), "0000")
        Dim barcodeString As String = TB_Reprint_ItemCode.Text & serialNo
        Dim itemCodeLength As Integer = TB_Reprint_ItemCode.Text.Length
        Dim continueChar As String = String.Empty

        For i = 1 To itemCodeLength + 9 '제조년월일 + QR에 필요한 문자 3자리 추가
            continueChar += "%"
        Next

        continueChar += "dddd"

        swFile.WriteLine("^XZ~JA^XZ")
        swFile.WriteLine("^XA^LH" & printerLeftPosition & ",0^LT" & printerTopPosition) 'LH : 가로위치, LT : 세로위치
        swFile.WriteLine("^MD25") '진하기
        swFile.WriteLine("^FO0004,0012^A0,25,18^FD" & TB_Reprint_Unique.Text & "^FS")
        swFile.WriteLine("^FO0004,0041^A0,25,18^FD" & TB_Reprint_ItemCode.Text & "^FS")
        swFile.WriteLine("^FO0004,0070^A0,25,18^FD" & serialNo & "^SF%%%%%%dddd,1^FS")
        swFile.WriteLine("^FO0150,0000^BQN,2,3^FDHA," & barcodeString & "^SF" & continueChar & ",1^FS")
        swFile.WriteLine("^PQ" & 1 & "^FS") 'PQ : 발행수량
        swFile.WriteLine("^XZ")
        swFile.Close()

        Dim printResult As String = LabelPrint()

        If Not printResult = "Success" Then
            MessageBox.Show(frm_Main,
                            "라벨 발행에 실패 하였습니다." & vbCrLf &
                            printResult,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub BTN_Reprint_List_Click(sender As Object, e As EventArgs) Handles BTN_Reprint_List.Click

        Thread_LoadingFormStart()

        Grid_ReprintList.Redraw = False
        Grid_ReprintList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_assy_label_history(8"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_Reprint_Search_CustomerCode.Text & "'"
        strSQL += ", '" & Format(DateTimePicker1.Value, "yyyy-MM-dd 00:00:00") & "'"
        strSQL += ", '" & Format(DateTimePicker2.Value, "yyyy-MM-dd 23:59:59") & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = Grid_ReprintList.Rows.Count
            insertString += vbTab & sqlDR("history_index")
            insertString += vbTab & sqlDR("customer_name")
            insertString += vbTab & sqlDR("item_code")
            insertString += vbTab & sqlDR("item_name")
            insertString += vbTab & sqlDR("item_spec")
            insertString += vbTab & sqlDR("label_date")
            insertString += vbTab & sqlDR("serial_no")
            insertString += vbTab & sqlDR("write_date")
            insertString += vbTab & sqlDR("write_id")

            Grid_ReprintList.AddItem(insertString)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_ReprintList.AutoSizeCols()
        Grid_ReprintList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub TB_MagazineBarcode_LostFocus(sender As Object, e As EventArgs) Handles TB_MagazineBarcode.LostFocus

    End Sub
End Class