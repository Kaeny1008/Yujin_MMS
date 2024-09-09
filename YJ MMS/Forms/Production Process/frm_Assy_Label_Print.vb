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

        With Grid_NonePO_LabelList
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

        Grid_NonePO_LabelList(0, 0) = "No"
        Grid_NonePO_LabelList(0, 1) = "품목명"
        Grid_NonePO_LabelList(0, 2) = "품목코드"
        Grid_NonePO_LabelList(0, 3) = "제조년월일"
        Grid_NonePO_LabelList(0, 4) = "Serial No."

        Grid_NonePO_LabelList.AutoSizeCols()

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
            .Cols.Count = 11
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
        Grid_ReprintList(0, 10) = "사유"

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
        TextBox7.Text = String.Empty
        TB_NowQty.Text = String.Empty

        BTN_SaveAndPrint.Enabled = False

        Grid_LabelList.Rows.Count = 1

        CheckBox1.Checked = False
        CheckBox2.Checked = False
        TB_Label_ItemName.Text = String.Empty
        TB_Label_FW.Text = String.Empty
        TB_Label_Boot.Text = String.Empty
        TB_Label_FPGA.Text = String.Empty

        CheckBox5.Checked = False
        TextBox8.Text = String.Empty

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
                MSG_Information(Me, "현재 모델의 품목명을 불러 올 수 없습니다.")
                Control_Init()
                TB_MagazineBarcode.SelectAll()
                TB_MagazineBarcode.Focus()
                Exit Sub
            Else
                If TB_ItemCode.Text = String.Empty Then
                    MSG_Information(Me, "모델 정보를 불러오지 못했습니다.")
                    Control_Init()
                    TB_MagazineBarcode.SelectAll()
                    TB_MagazineBarcode.Focus()
                    Exit Sub
                End If
            End If

            If Load_PrintTotalQty() = CInt(TB_POQty.Text) And CB_Reprint.Checked = False Then
                MSG_Information(Me, "이미 발행을 완료한 주문번호 입니다.")
                Control_Init()
                TB_MagazineBarcode.SelectAll()
                TB_MagazineBarcode.Focus()
                Exit Sub
            End If

            'History를 확인한다(현품표 수량확인)
            Load_History_Information(TB_HistoryNo.Text)
            If TB_NowQty.Text = String.Empty Then
                MSG_Information(Me, "공정현품표를 확인 할 수 없습니다.")
                Control_Init()
                TB_MagazineBarcode.SelectAll()
                TB_MagazineBarcode.Focus()
                Exit Sub
            End If

            Dim rePrintDate As DateTime = Now
            If CB_Reprint.Checked = True Then
                Dim returnString As String = Load_History_Print_Content()
                If returnString = "1999-12-31" Then
                    MSG_Information(Me, "발행내역이 조회되지 않았습니다.")
                    Control_Init()
                    TB_MagazineBarcode.SelectAll()
                    TB_MagazineBarcode.Focus()
                    Exit Sub
                Else
                    rePrintDate = Format(CDate(returnString), "yyyy-MM-dd")
                End If
                Label38.Text = rePrintDate
            Else
                '중복발행 체크
                If Check_Print() = False Then
                    MSG_Information(Me, "이미 발행한 현품표입니다.")
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
                If CheckBox1.Checked = True Then
                    insertString += vbTab & TB_Label_ItemName.Text
                Else
                    insertString += vbTab
                End If
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

        Thread_LoadingFormStart(Me)

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

        If writeDate = String.Empty Then
            writeDate = "1999-12-31"
        End If

        Return writeDate

    End Function

    Private Function Load_Po_Information() As Boolean

        Thread_LoadingFormStart(Me)

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
            If sqlDR("assy_label_use2") = 1 Then
                CheckBox5.Checked = True
                TextBox8.Text = TB_ItemCode.Text
            End If
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

        Thread_LoadingFormStart(Me)

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

        Thread_LoadingFormStart(Me)

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
        strSQL += ", '" & TB_ModelCode.Text & "'"
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

        Thread_LoadingFormStart(Me)

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

        Thread_LoadingFormStart(Me)

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
            MSG_Information(Me, "발행자를 입력하여 주십시오.")
            TextBox2.Focus()
            Exit Sub
        End If

        If Grid_LabelList.Rows.Count = 1 Then
            MSG_Information(Me, "라벨 발행내용이 없습니다.")
            Exit Sub
        End If

        If MSG_Question(Me, "라벨을 발행 하시겠습니까?") = False Then Exit Sub

        Dim wirteResult As String = String.Empty
        If CB_Reprint.Checked = True Then
            wirteResult = DB_Write_All_Reprint()
        Else
            wirteResult = DB_Write()
        End If

        If Not wirteResult = String.Empty Then
            MSG_Error(Me, wirteResult)
            Exit Sub
        End If

        Dim workingDate As Date = Now

        If CB_Reprint.Checked = True Then
            workingDate = CDate(Label38.Text)
        End If

        If CheckBox1.Checked = True Or CheckBox2.Checked = True Then
            PrintLabel(TB_Label_ItemName.Text,
                       TB_ItemCode.Text,
                       CInt(TextBox3.Text),
                       CInt(TB_NowQty.Text),
                       CheckBox1.Checked,
                       CheckBox2.Checked,
                       TB_Label_FW.Text,
                       TB_Label_Boot.Text,
                       TB_Label_FPGA.Text,
                       workingDate)
        ElseIf CheckBox5.Checked = True Then
            'PO202408260004-0003!377!SMD
            PrintLabel_Mini(TB_ItemCode.Text,
                            CInt(TextBox3.Text),
                            CInt(TB_NowQty.Text),
                            workingDate)
        End If

        MSG_Information(Me, "발행 및 저장완료.")
        CB_Reprint.Checked = False
        Control_Init()

    End Sub

    Private Function DB_Write_All_Reprint() As String

        Dim writeResult As String = String.Empty

        Thread_LoadingFormStart(Me, "Saving...")

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
                strSQL += ", label_date, serial_no, write_date, write_id, reason"
                strSQL += ") values("
                strSQL += "f_mms_assy_label_reprint_no('" & nowDate & "')"
                strSQL += ",'" & TextBox4.Text & "'"
                strSQL += ",'" & TB_ModelCode.Text & "'"
                strSQL += ",'" & Grid_LabelList(i, 3) & "'"
                strSQL += "," & Grid_LabelList(i, 4) & ""
                strSQL += ",'" & nowTime & "'"
                strSQL += ",'" & TextBox2.Text & "'"
                strSQL += ",'" & TextBox7.Text & "'"
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

        Thread_LoadingFormStart(Me, "Saving...")

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

    Private Sub PrintLabel(ByVal label_ItemName As String,
                           ByVal label_ItemCode As String,
                           ByVal label_FirstSerial As Integer,
                           ByVal printQty As Integer,
                           ByVal serialLabel As Boolean,
                           ByVal fwLabel As Boolean,
                           ByVal fwString As String,
                           ByVal bootString As String,
                           ByVal fpgaString As String,
                           ByVal workingDate As Date)

        'If File.Exists(Application.StartupPath & "\print.txt") Then File.Delete(Application.StartupPath & "\print.txt")

        If Directory.Exists(Application.StartupPath & "\Print Text") = False Then
            Directory.CreateDirectory(Application.StartupPath & "\Print Text")
        End If

        Dim folderName As String = Application.StartupPath & "\Print Text"
        Dim fileName As String = folderName & "\Assy Label Print_" & Format(Now, "yyMMddHHmmssfff") & ".txt"

        Dim swFile As StreamWriter =
            New StreamWriter(fileName, True, System.Text.Encoding.GetEncoding(949))

        Dim serialNo As String = Format(workingDate, "yyMMdd") & Format(label_FirstSerial + 1, "0000")
        Dim barcodeString As String = label_ItemCode & serialNo
        Dim itemCodeLength As Integer = label_ItemCode.Length
        Dim continueChar As String = String.Empty

        For i = 1 To itemCodeLength + 9 '제조년월일 + QR에 필요한 문자 3자리 추가
            continueChar += "%"
        Next

        continueChar += "dddd"

        swFile.WriteLine("^XZ~JA^XZ")

        If serialLabel = True Then
            swFile.WriteLine("^XA^LH" & printerLeftPosition & ",0^LT" & printerTopPosition) 'LH : 가로위치, LT : 세로위치
            swFile.WriteLine("^MD" & printerMD) '진하기
            swFile.WriteLine("^FO0004,0012^A0,25,18^FD" & label_ItemName & "^FS")
            swFile.WriteLine("^FO0004,0041^A0,25,18^FD" & label_ItemCode & "^FS")
            swFile.WriteLine("^FO0004,0070^A0,25,18^FD" & serialNo & "^SF%%%%%%dddd,1^FS")
            swFile.WriteLine("^FO0150,0002^BQN,2,3^FDHA," & barcodeString & "^SF" & continueChar & ",1^FS")
            swFile.WriteLine("^PQ" & printQty & "^FS") 'PQ : 발행수량
            swFile.WriteLine("^XZ")
        End If

        If fwLabel = True Then
            Dim lineCount As Integer = 0
            Dim firstLine As String = String.Empty
            Dim secondLine As String = String.Empty
            Dim thirdLine As String = String.Empty
            If Not fwString = String.Empty Then
                lineCount += 1
                firstLine = "FW : V" & fwString
            End If
            If Not bootString = String.Empty Then
                lineCount += 1
                If firstLine = String.Empty Then
                    firstLine = "Boot : V" & bootString
                Else
                    secondLine = "Boot : V" & bootString
                End If
            End If
            If Not fpgaString = String.Empty Then
                lineCount += 1
                If firstLine = String.Empty Then
                    firstLine = "FPGA : V" & fpgaString
                ElseIf secondLine = String.Empty Then
                    secondLine = "FPGA : V" & fpgaString
                ElseIf thirdLine = String.Empty Then
                    thirdLine = "FPGA : V" & fpgaString
                End If
            End If

            swFile.WriteLine("^XA^LH" & printerLeftPosition & ",0^LT" & printerTopPosition) 'LH : 가로위치, LT : 세로위치
            swFile.WriteLine("^MD" & printerMD) '진하기
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
            swFile.WriteLine("^PQ" & printQty & "^FS") 'PQ : 발행수량
            swFile.WriteLine("^XZ")
        End If

        swFile.Close()

        Dim printResult As String = LabelPrint(fileName, 1)

        If Not printResult = "Success" Then
            MSG_Error(Me, "라벨 발행에 실패 하였습니다.")
        End If

    End Sub

    Private Sub PrintLabel_Mini(ByVal label_ItemCode As String,
                                ByVal label_FirstSerial As Integer,
                                ByVal printQty As Integer,
                                ByVal workingDate As Date)

        'If File.Exists(Application.StartupPath & "\print.txt") Then File.Delete(Application.StartupPath & "\print.txt")

        If Directory.Exists(Application.StartupPath & "\Print Text") = False Then
            Directory.CreateDirectory(Application.StartupPath & "\Print Text")
        End If

        Dim folderName As String = Application.StartupPath & "\Print Text"
        Dim fileName As String = folderName & "\Assy Label Print Mini_" & Format(Now, "yyMMddHHmmssfff") & ".txt"

        Dim swFile As StreamWriter =
            New StreamWriter(fileName, True, System.Text.Encoding.GetEncoding(949))

        swFile.WriteLine("^XZ~JA^XZ")

        Dim orgQty As Integer = printQty
        Dim realQty As Integer = Math.Abs(orgQty / 4)
        Dim remainingValue As Double = orgQty Mod 4

        Dim replaceWorkingDate As String = Format(workingDate, "yyMMdd")
        Dim firstSeial As Integer = label_FirstSerial + 1

        For i = 1 To realQty
            swFile.WriteLine("^XA^LH" & printerLeftPosition2 & ",0^LT" & printerTopPosition2) 'LH : 가로위치, LT : 세로위치
            swFile.WriteLine("^MD" & printerMD2) '진하기
            swFile.WriteLine("^FO0000,0000^A0,16,20^FD" & label_ItemCode & "^FS")
            swFile.WriteLine("^FO0000,0016^A0,16,20^FD" & replaceWorkingDate & Format(firstSeial, "0000") & "^FS")
            swFile.WriteLine("^FO0012,0025^BQN,2,3^FDAAA" & label_ItemCode & replaceWorkingDate & Format(firstSeial, "0000") & "^FS")

            swFile.WriteLine("^FO0176,0000^A0,16,20^FD" & label_ItemCode & "^FS")
            swFile.WriteLine("^FO0176,0016^A0,16,20^FD" & replaceWorkingDate & Format(firstSeial + 1, "0000") & "^FS")
            swFile.WriteLine("^FO0188,0025^BQN,2,3^FDAAA" & label_ItemCode & replaceWorkingDate & Format(firstSeial + 1, "0000") & "^FS")

            swFile.WriteLine("^FO0352,0000^A0,16,20^FD" & label_ItemCode & "^FS")
            swFile.WriteLine("^FO0352,0016^A0,16,20^FD" & replaceWorkingDate & Format(firstSeial + 2, "0000") & "^FS")
            swFile.WriteLine("^FO0364,0025^BQN,2,3^FDAAA" & label_ItemCode & replaceWorkingDate & Format(firstSeial + 2, "0000") & "^FS")

            swFile.WriteLine("^FO0528,0000^A0,16,20^FD" & label_ItemCode & "^FS")
            swFile.WriteLine("^FO0528,0016^A0,16,20^FD" & replaceWorkingDate & Format(firstSeial + 3, "0000") & "^FS")
            swFile.WriteLine("^FO0540,0025^BQN,2,3^FDAAA" & label_ItemCode & replaceWorkingDate & Format(firstSeial + 3, "0000") & "^FS")

            swFile.WriteLine("^PQ" & 1 & "^FS") 'PQ : 발행수량
            swFile.WriteLine("^XZ")

            firstSeial += 4
        Next

        If remainingValue > 0 Then
            swFile.WriteLine("^XA^LH" & printerLeftPosition & ",0^LT" & printerTopPosition) 'LH : 가로위치, LT : 세로위치
            swFile.WriteLine("^MD" & printerMD) '진하기
            If remainingValue > 0 Then
                swFile.WriteLine("^FO0000,0000^A0,16,20^FD" & label_ItemCode & "^FS")
                swFile.WriteLine("^FO0000,0016^A0,16,20^FD" & replaceWorkingDate & Format(firstSeial, "0000") & "^FS")
                swFile.WriteLine("^FO0012,0025^BQN,2,3^FDAAA" & label_ItemCode & replaceWorkingDate & Format(firstSeial, "0000") & "^FS")
            End If

            If remainingValue > 1 Then
                swFile.WriteLine("^FO0176,0000^A0,16,20^FD" & label_ItemCode & "^FS")
                swFile.WriteLine("^FO0176,0016^A0,16,20^FD" & replaceWorkingDate & Format(firstSeial + 1, "0000") & "^FS")
                swFile.WriteLine("^FO0188,0025^BQN,2,3^FDAAA" & label_ItemCode & replaceWorkingDate & Format(firstSeial + 1, "0000") & "^FS")
            End If

            If remainingValue > 2 Then
                swFile.WriteLine("^FO0352,0000^A0,16,20^FD" & label_ItemCode & "^FS")
                swFile.WriteLine("^FO0352,0016^A0,16,20^FD" & replaceWorkingDate & Format(firstSeial + 2, "0000") & "^FS")
                swFile.WriteLine("^FO0364,0025^BQN,2,3^FDAAA" & label_ItemCode & replaceWorkingDate & Format(firstSeial + 2, "0000") & "^FS")
            End If

            swFile.WriteLine("^PQ" & 1 & "^FS") 'PQ : 발행수량
            swFile.WriteLine("^XZ")
        End If

        swFile.Close()

        Dim printResult As String = LabelPrint(fileName, 2)

        If Not printResult = "Success" Then
            MSG_Error(Me, "라벨 발행에 실패 하였습니다.")
        End If

    End Sub

    Private Sub C1DockingTab1_SelectedTabChanged(sender As Object, e As EventArgs) Handles C1DockingTab1.SelectedTabChanged

        If C1DockingTab1.SelectedIndex = 1 Then
            Load_CustomerList(CB_CustomerName)
        ElseIf C1DockingTab1.SelectedIndex = 2 Then
            Load_CustomerList(CB_Reprint_CustomerName)
            Load_CustomerList(CB_Reprint_Search_CustomerName)
        ElseIf C1DockingTab1.SelectedIndex = 3 Then
            Load_CustomerList(CB_NonePO_CustomerName)
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

        Thread_LoadingFormStart(Me)

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

        Thread_LoadingFormStart(Me)

        TB_Reprint_ItemName.Text = String.Empty
        TB_Reprint_ItemSpec.Text = String.Empty
        TB_Reprint_Unique.Text = String.Empty
        TB_Reprint_ModelCode.Text = String.Empty

        Load_Reprint_Basic_Information("Reprint")

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_Reprint_Basic_Information(ByVal section As String)

        DBConnect()
        Dim customerCode As String = TB_Reprint_CustomerCode.Text
        Dim itemCode As String = TB_Reprint_ItemCode.Text

        If section = "NonePO" Then
            customerCode = TB_NonePO_CustomerCode.Text
            itemCode = TB_NonePO_ItemCode.Text
        End If

        Dim strSQL As String = "call sp_mms_assy_label_history(7"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & customerCode & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & itemCode & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            If section = "Reprint" Then
                TB_Reprint_ItemName.Text = sqlDR("item_name")
                TB_Reprint_ItemSpec.Text = sqlDR("item_spec")
                'TB_Reprint_Unique.Text = sqlDR("barcode_string")
                TB_Reprint_ModelCode.Text = sqlDR("model_code")
            ElseIf section = "NonePO" Then
                TB_NonePO_ItemName.Text = sqlDR("item_name")
                TB_NonePO_ItemSpec.Text = sqlDR("item_spec")
                'TB_Reprint_Unique.Text = sqlDR("barcode_string")
                TB_NonePO_ModelCode.Text = sqlDR("model_code")
            End If
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

        If Trim(TextBox6.Text) = String.Empty Then
            MessageBox.Show(Me,
                            "재발행 사유가 입력되지 않았습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            TextBox6.SelectAll()
            TextBox6.Focus()
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

        If TB_Reprint_ItemCode.Text = TB_Reprint_Unique.Text Then
            RePrintLabel_Mini()
        Else
            RePrintLabel()
        End If

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
        TextBox6.Text = String.Empty


        BTN_Reprint_List_Click(Nothing, Nothing)

    End Sub

    Private Sub Reprint_Load_ItemName(ByVal managementNo As String)

        Thread_LoadingFormStart(Me)

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
            If sqlDR("assy_label_use") = 1 Then
                TB_Reprint_Unique.Text = sqlDR("item_name")
            ElseIf sqlDR("assy_label_use2") = 1 Then
                TB_Reprint_Unique.Text = TB_Reprint_ItemCode.Text
            End If
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

    End Sub

    Private Function Reprint_IndexCheck() As String

        Thread_LoadingFormStart(Me)

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

    Private Sub TB_Reprint_Unique_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_Reprint_Unique.KeyDown

        If e.KeyCode = 13 And Not TB_Reprint_Unique.Text.Equals("") Then
            TB_Reprintor.SelectAll()
            TB_Reprintor.Focus()
        End If

    End Sub

    Private Function DB_Reprint_Write() As String

        Dim writeResult As String = String.Empty

        Thread_LoadingFormStart(Me, "Saving...")

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
            strSQL += ", label_date, serial_no, write_date, write_id, reason"
            strSQL += ") values("
            strSQL += "f_mms_assy_label_reprint_no('" & nowDate & "')"
            strSQL += ",'" & TB_Reprint_CustomerCode.Text & "'"
            strSQL += ",'" & TB_Reprint_ModelCode.Text & "'"
            strSQL += ",'" & TB_Reprint_Date.Text & "'"
            strSQL += "," & TB_Reprint_Serial.Text & ""
            strSQL += ",'" & nowTime & "'"
            strSQL += ",'" & TB_Reprintor.Text & "'"
            strSQL += ",'" & TextBox6.Text & "'"
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

        'If File.Exists(Application.StartupPath & "\print.txt") Then File.Delete(Application.StartupPath & "\print.txt")

        If Directory.Exists(Application.StartupPath & "\Print Text") = False Then
            Directory.CreateDirectory(Application.StartupPath & "\Print Text")
        End If

        Dim folderName As String = Application.StartupPath & "\Print Text"
        Dim fileName As String = folderName & "\Assy Label RePrint_" & Format(Now, "yyMMddHHmmssfff") & ".txt"

        Dim swFile As StreamWriter =
            New StreamWriter(fileName, True, System.Text.Encoding.GetEncoding(949))

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
        swFile.WriteLine("^MD" & printerMD) '진하기
        'If TB_Reprint_ItemCode.Text = TB_Reprint_Unique.Text Then
        'swFile.WriteLine("^FO0000,0000^A0,16,20^FD" & TB_Reprint_Unique.Text & "^FS")
        'swFile.WriteLine("^FO0000,0016^A0,16,20^FD" & TB_Reprint_Date.Text & Format(TB_Reprint_Serial.Text, "0000") & "^FS")
        'swFile.WriteLine("^FO0012,0025^BQN,2,3^FDAAA" & TB_Reprint_Unique.Text & TB_Reprint_Date.Text & Format(TB_Reprint_Serial.Text, "0000") & "^FS")
        'Else
        swFile.WriteLine("^FO0004,0012^A0,25,18^FD" & TB_Reprint_Unique.Text & "^FS")
        swFile.WriteLine("^FO0004,0041^A0,25,18^FD" & TB_Reprint_ItemCode.Text & "^FS")
        swFile.WriteLine("^FO0004,0070^A0,25,18^FD" & serialNo & "^SF%%%%%%dddd,1^FS")
        swFile.WriteLine("^FO0150,0000^BQN,2,3^FDHA," & barcodeString & "^SF" & continueChar & ",1^FS")
        'End If
        swFile.WriteLine("^PQ" & 1 & "^FS") 'PQ : 발행수량
        swFile.WriteLine("^XZ")
        swFile.Close()

        Dim printResult As String = LabelPrint(fileName, 1)

        If Not printResult = "Success" Then
            MessageBox.Show(frm_Main,
                            "라벨 발행에 실패 하였습니다." & vbCrLf &
                            printResult,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub RePrintLabel_Mini()

        'If File.Exists(Application.StartupPath & "\print.txt") Then File.Delete(Application.StartupPath & "\print.txt")

        If Directory.Exists(Application.StartupPath & "\Print Text") = False Then
            Directory.CreateDirectory(Application.StartupPath & "\Print Text")
        End If

        Dim folderName As String = Application.StartupPath & "\Print Text"
        Dim fileName As String = folderName & "\Assy Label RePrint Mini_" & Format(Now, "yyMMddHHmmssfff") & ".txt"

        Dim swFile As StreamWriter =
            New StreamWriter(fileName, True, System.Text.Encoding.GetEncoding(949))

        swFile.WriteLine("^XZ~JA^XZ")
        swFile.WriteLine("^XA^LH" & printerLeftPosition2 & ",0^LT" & printerTopPosition2) 'LH : 가로위치, LT : 세로위치
        swFile.WriteLine("^MD" & printerMD2) '진하기

        swFile.WriteLine("^FO0000,0000^A0,16,20^FD" & TB_Reprint_Unique.Text & "^FS")
        swFile.WriteLine("^FO0000,0016^A0,16,20^FD" & TB_Reprint_Date.Text & Format(TB_Reprint_Serial.Text, "0000") & "^FS")
        swFile.WriteLine("^FO0012,0025^BQN,2,3^FDAAA" & TB_Reprint_Unique.Text & TB_Reprint_Date.Text & Format(TB_Reprint_Serial.Text, "0000") & "^FS")

        swFile.WriteLine("^PQ" & 1 & "^FS") 'PQ : 발행수량
        swFile.WriteLine("^XZ")
        swFile.Close()

        Dim printResult As String = LabelPrint(fileName, 2)

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

        Thread_LoadingFormStart(Me)

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
            insertString += vbTab & sqlDR("reason")

            Grid_ReprintList.AddItem(insertString)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_ReprintList.AutoSizeCols()
        Grid_ReprintList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub CB_Reprint_CustomerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Reprint_CustomerName.SelectedIndexChanged

    End Sub

    Private Sub CB_NonePO_CustomerName_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_NonePO_CustomerName.SelectionChangeCommitted

        TB_NonePO_CustomerCode.Text = String.Empty

        DBConnect()

        Dim strSQL As String = "select customer_code"
        strSQL += " from tb_customer_list"
        strSQL += " where customer_name = '" & CB_NonePO_CustomerName.Text & "'"
        strSQL += " order by customer_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_NonePO_CustomerCode.Text = sqlDR("customer_code")
        Loop
        sqlDR.Close()

        DBClose()

        TB_NonePO_ItemCode.SelectAll()
        TB_NonePO_ItemCode.Focus()

    End Sub

    Private Sub TB_NonePO_ItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_NonePO_ItemCode.KeyDown

        If e.KeyCode = 13 And Not Trim(TB_NonePO_ItemCode.Text) = String.Empty Then
            BTN_NonePO_PrintCodeSelect_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub NonePO_Control_Initialize()

        TB_NonePO_ItemName.Text = String.Empty
        TB_NonePO_ItemSpec.Text = String.Empty
        TB_NonePO_ModelCode.Text = String.Empty
        TextBox5.Text = String.Empty
        TB_NonePO_Label_FPGA.Text = String.Empty
        TB_NonePO_Label_Boot.Text = String.Empty
        TB_NonePO_Label_FW.Text = String.Empty
        TB_NonePO_Label_ItemName.Text = String.Empty
        CheckBox3.Checked = False
        CheckBox4.Checked = False

        Grid_NonePO_LabelList.Rows.Count = 1

    End Sub

    Private Sub BTN_NonePO_PrintCodeSelect_Click(sender As Object, e As EventArgs) Handles BTN_NonePO_PrintCodeSelect.Click

        Thread_LoadingFormStart(Me)

        NonePO_Control_Initialize()

        Load_Reprint_Basic_Information("NonePO")

        If TB_NonePO_ItemCode.Text = String.Empty Then
            MSG_Information(Me, "정보를 불러 오지 못했습니다.")
            NonePO_Control_Initialize()
            TB_NonePO_ItemCode.SelectAll()
            TB_NonePO_ItemCode.Focus()
            Exit Sub
        End If

        Load_NonePO_LastNo()
        If TextBox5.Text = String.Empty Then
            TextBox5.Text = 0
        End If

        Load_NonePO_Label_Information()
        If CheckBox3.Checked = False And CheckBox4.Checked = False Then
            MSG_Information(Me, "라벨 발행 정보가 없습니다.")
            NonePO_Control_Initialize()
            TB_NonePO_ItemCode.SelectAll()
            TB_NonePO_ItemCode.Focus()
            Exit Sub
        End If

        MSG_Information(Me, "라벨 발행 수량을 입력하여 주십시오.")

        TB_NonePO_PrintQty.SelectAll()
        TB_NonePO_PrintQty.Focus()

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_NonePO_LastNo()

        Thread_LoadingFormStart(Me)

        DBConnect()

        Dim strSQL As String = "call sp_mms_assy_label_history(12"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_NonePO_ModelCode.Text & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TextBox5.Text = sqlDR("end_no")
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_NonePO_Label_Information()

        Thread_LoadingFormStart(Me)

        DBConnect()

        Dim strSQL As String = "call sp_mms_assy_label_history(13"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_NonePO_ModelCode.Text & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            If sqlDR("assy_label_use") = 1 Then
                CheckBox4.Checked = True
                TB_NonePO_Label_ItemName.Text = sqlDR("item_name")
            End If
            If sqlDR("sw_label_use") = 1 Then
                CheckBox3.Checked = True
                TB_NonePO_Label_FW.Text = sqlDR("fw_os_label")
                TB_NonePO_Label_Boot.Text = sqlDR("boot_label")
                TB_NonePO_Label_FPGA.Text = sqlDR("fpga_label")
            End If
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

    End Sub

    Private Sub TB_NonePO_PrintQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TB_NonePO_PrintQty.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "," Then
            e.Handled = True
        End If

    End Sub

    Private Sub TB_NonePO_PrintQty_LostFocus(sender As Object, e As EventArgs) Handles TB_NonePO_PrintQty.LostFocus

        If Not TB_NonePO_PrintQty.Text = String.Empty Then
            Grid_NonePO_LabelList.Redraw = False
            Grid_NonePO_LabelList.Rows.Count = 1
            Dim startNo As Integer = CInt(TextBox5.Text)
            For i = 1 To CInt(TB_NonePO_PrintQty.Text)
                startNo += 1
                Dim insertString As String = Grid_NonePO_LabelList.Rows.Count
                insertString += vbTab & TB_NonePO_Label_ItemName.Text
                insertString += vbTab & TB_NonePO_ItemCode.Text
                insertString += vbTab & Format(Now, "yyMMdd")
                insertString += vbTab & Format(startNo, "0000")
                Grid_NonePO_LabelList.AddItem(insertString)
            Next
            Grid_NonePO_LabelList.Redraw = True
            Grid_NonePO_LabelList.AutoSizeCols()
        End If

    End Sub

    Private Sub TB_NonePO_PrintQty_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_NonePO_PrintQty.KeyDown

        If Not TB_NonePO_PrintQty.Text = String.Empty And e.KeyCode = 13 Then
            TB_NonePO_Printor.SelectAll()
            TB_NonePO_Printor.Focus()
        End If

    End Sub

    Private Sub BTN_NonePO_Save_Click(sender As Object, e As EventArgs) Handles BTN_NonePO_Save.Click

        If TB_NonePO_Printor.Text = String.Empty Then
            MSG_Information(Me, "발행자를 입력하여 주십시오.")
            TB_NonePO_Printor.Focus()
            Exit Sub
        End If

        If Grid_NonePO_LabelList.Rows.Count = 1 Then
            MSG_Information(Me, "라벨 발행 내용이 없습니다.")
            Exit Sub
        End If

        If CheckBox4.Checked = False And CheckBox3.Checked = False Then
            MSG_Information(Me, "라벨 내용을 선택하여 주십시오." & vbCrLf & "A'ssy / Software")
            Exit Sub
        End If

        If Trim(TB_NonePO_PrintQty.Text) = String.Empty Then
            MSG_Information(Me, "발행 수량을 입력하여 주십시오.") '
            TB_NonePO_PrintQty.Focus()
            Exit Sub
        End If

        If MSG_Question(Me, "라벨을 발행 하시겠습니까?") = False Then Exit Sub

        If CheckBox4.Checked = True Then
            Dim wirteResult As String = NonePO_DB_Write()

            If Not wirteResult = String.Empty Then
                MSG_Error(Me, wirteResult)
                Exit Sub
            End If
        End If

        PrintLabel(TB_NonePO_Label_ItemName.Text,
                   TB_NonePO_ItemCode.Text,
                   CInt(TextBox5.Text),
                   CInt(TB_NonePO_PrintQty.Text),
                   CheckBox4.Checked,
                   CheckBox3.Checked,
                   TB_NonePO_Label_FW.Text,
                   TB_NonePO_Label_Boot.Text,
                   TB_NonePO_Label_FPGA.Text,
                   Now)

        MSG_Information(Me, "발행 및 저장완료.")
        CB_Reprint.Checked = False
        NonePO_Control_Initialize()

    End Sub

    Private Function NonePO_DB_Write() As String

        Dim writeResult As String = String.Empty

        Thread_LoadingFormStart(Me, "Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Dim nowTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
        Dim nowDate As String = Format(Now, "yyyy-MM-dd")

        Try
            strSQL += "insert into tb_mms_assy_label_history_none_po("
            strSQL += "history_no, model_code, print_qty, start_no, end_no, write_date, write_id"
            strSQL += ") values("
            strSQL += "f_mms_assy_label_none_po_history_no('" & nowDate & "')"
            strSQL += ",'" & TB_NonePO_ModelCode.Text & "'"
            strSQL += ",'" & TB_NonePO_PrintQty.Text & "'"
            strSQL += "," & CInt(TextBox5.Text) + 1 & ""
            strSQL += "," & CInt(TextBox5.Text) + CInt(TB_NonePO_PrintQty.Text) & ""
            strSQL += ",'" & nowTime & "'"
            strSQL += ",'" & TB_NonePO_Printor.Text & "'"
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

    Private Sub CB_Reprint_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Reprint.CheckedChanged

        If CB_Reprint.Checked = True Then
            Label51.Visible = True
            TextBox7.Visible = True
        Else
            Label51.Visible = False
            TextBox7.Visible = False
        End If

    End Sub
End Class