Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frm_WS_Magazine_Kitting

    Public lastWorkingCount As Integer
    Public totalDefectCount As Integer
    Public workingCount As Integer
    Dim modelTB As String

    Private Sub frm_SMD_Magazine_Kitting_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.TopMost = True

        Load_Process()
        Load_TopBottom()

    End Sub

    Private Sub Load_Process()

        DBConnect()

        Dim strSQL As String = "call sp_mms_smd_production_end(5"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & LB_ModelCode.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            If TB_Process.Text = String.Empty Then
                TB_Process.Text = sqlDR("process_name")
            Else
                TB_Process.Text += ">" & sqlDR("process_name")
            End If
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub Load_TopBottom()

        DBConnect()

        Dim strSQL As String = "call sp_mms_smd_production_end(6"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & LB_ModelCode.Text & "'"
        strSQL += ", '" & LB_CustomerCode.Text & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim workSite As String = "Bottom / Top"

            If IsDBNull(sqlDR("Bottom")) And
                Not IsDBNull(sqlDR("Top")) Then
                workSite = "Top"
            ElseIf Not IsDBNull(sqlDR("Bottom")) And
                IsDBNull(sqlDR("Top")) Then
                workSite = "Bottom"
            End If

            modelTB = workSite
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub BTN_Exit_Click(sender As Object, e As EventArgs) Handles BTN_Exit.Click

        If TB_MagazineQty.Text = String.Empty Then
            MessageBox.Show(Me,
                            "Magazine 수량이 입력되지 않았습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk)
            TB_MagazineQty.SelectAll()
            TB_MagazineQty.Focus()
            Exit Sub
        End If

        If lastWorkingCount + TB_MagazineQty.Text > workingCount Then
            MessageBox.Show(Me,
                            "총 생산수량보다 큽니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk)
            TB_MagazineQty.SelectAll()
            TB_MagazineQty.Focus()
            Exit Sub
        End If

        Dim workingEnd As Boolean = False
        If lastWorkingCount + TB_MagazineQty.Text = workingCount Then
            If CheckReinspection() = False Then
                MessageBox.Show(Me,
                                "수리품 재검사가 완료되지 않았습니다.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk)
                Exit Sub
            End If
            workingEnd = True
        End If

        If MessageBox.Show(Me,
                           "생산내역을 등록 하시겠습니까?",
                           msg_form,
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
        Try
            If workingEnd = False Then
                strSQL = "insert into tb_mms_smd_production_history("
                strSQL += "order_index, smd_start_date, smd_operater"
                strSQL += ", smd_inspecter, start_quantity, work_side, working_status"
                strSQL += ") select order_index"
                strSQL += ", '" & writeDate & "'"
                strSQL += ", smd_operater"
                strSQL += ", '" & frm_SMD_Production_End.TB_Inspector.Text & "'"
                strSQL += ", start_quantity + '" & TB_MagazineQty.Text & "', work_side, working_status"
                strSQL += " from tb_mms_smd_production_history"
                strSQL += " where history_index = " & LB_HistoryIndex.Text
                strSQL += ";"
            Else
                If modelTB = "Bottom / Top" And TB_TB.Text = "Top" Then
                    strSQL += "update tb_mms_order_register_list set order_status = 'SMD Process Completed'"
                    strSQL += " where order_index = '" & TB_PONo.Text & "';"
                ElseIf modelTB = "Bottom" Or modelTB = "Top" Then
                    strSQL += "update tb_mms_order_register_list set order_status = 'SMD Process Completed'"
                    strSQL += " where order_index = '" & TB_PONo.Text & "';"
                End If
            End If

            strSQL += "update tb_mms_smd_production_history set"
            strSQL += " smd_end_date = '" & writeDate & "'"
            strSQL += ", end_quantity = '" & TB_MagazineQty.Text & "'"
            strSQL += ", working_status = concat(work_side, ' Completed')"
            strSQL += ", history_note = '" & TB_Note.Text & "'"
            strSQL += ", smd_inspecter = '" & frm_SMD_Production_End.TB_Inspector.Text & "'"
            strSQL += " where history_index = " & LB_HistoryIndex.Text
            strSQL += ";"

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
                            MessageBoxIcon.Error)

            Exit Sub
        End Try

        DBClose()

        If RadioButton1.Checked = True Then
            PrintLabel(writeDate, modelTB)
        End If

        frm_SMD_Production_End.CB_Line_SelectionChangeCommitted(Nothing, Nothing)

        Me.Dispose()

    End Sub

    Private Function CheckReinspection() As Boolean

        Dim not_inspect As Integer = 0

        DBConnect()

        Dim strSQL As String = "call sp_mms_smd_production_end(7"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_PONo.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            not_inspect += sqlDR("not_inspect")
        Loop
        sqlDR.Close()

        DBClose()

        If not_inspect = 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub PrintLabel(ByVal writeDate As String, ByVal modelTB As String)

        Dim readyTop As Boolean = False

        If modelTB = "Bottom / Top" Then
            If TB_TB.Text = "Bottom" Then
                readyTop = True
            End If
        End If

        If File.Exists(Application.StartupPath & "\print.txt") Then File.Delete(Application.StartupPath & "\print.txt")

        Dim swFile As StreamWriter =
            New StreamWriter(Application.StartupPath & "\print.txt", True, System.Text.Encoding.GetEncoding(949))

        swFile.WriteLine("^XZ~JA^XZ")
        swFile.WriteLine("^XA^LH" & printerLeftPosition & ",0^LT" & printerTopPosition) 'LH : 가로위치, LT : 세로위치
        swFile.WriteLine("^MD25") '진하기
        swFile.WriteLine("^SEE:UHANGUL.DAT^FS")
        swFile.WriteLine("^CW1,E:KFONT3.FNT^CI26^FS")

        swFile.WriteLine("^FO0008,0162^GB0694,0302,2,B,1^FS")

        swFile.WriteLine("^FO0008,0200^GB0694,0000,2,B,0^FS")
        swFile.WriteLine("^FO0008,0238^GB0694,0000,2,B,0^FS")
        swFile.WriteLine("^FO0008,0276^GB0694,0000,2,B,0^FS")
        swFile.WriteLine("^FO0008,0314^GB0694,0000,2,B,0^FS")

        swFile.WriteLine("^FO0162,0162^GB0000,0302,2,B,0^FS")
        swFile.WriteLine("^FO0352,0200^GB0000,0116,2,B,0^FS")
        swFile.WriteLine("^FO0510,0200^GB0000,0116,2,B,0^FS")

        swFile.WriteLine("^FO0300,0008^A1N,70,50^FDSMD현품표^FS")
        swFile.WriteLine("^FO0172,0080^A0,40,20^FDItemCode : ^FS")
        swFile.WriteLine("^FO0264,0080^A0,40,20^FD" & TB_ItemCode.Text & "^FS")
        swFile.WriteLine("^FO0172,0120^A0,40,20^FDItemName : ^FS")
        swFile.WriteLine("^FO0272,0120^A0,40,20^FD" & TB_ItemName.Text & "^FS")

        swFile.WriteLine("^FO0016,0170^A0,30,20^FDPO No.^FS")
        swFile.WriteLine("^FO0170,0170^A0,30,20^FD" & TB_PONo.Text & " ( " & LB_HistoryIndex.Text & " )^FS")

        swFile.WriteLine("^FO0016,0208^A0,30,20^FDTotal Q'ty^FS")
        swFile.WriteLine("^FO0170,0208^A0,30,20^FD" & TB_TotalQty.Text & " EA^FS")
        swFile.WriteLine("^FO0360,0208^A0,30,20^FDMagazine Q'ty^FS")
        swFile.WriteLine("^FO0518,0208^A0,30,20^FD" & TB_MagazineQty.Text & " EA^FS")

        swFile.WriteLine("^FO0016,0246^A0,30,20^FDSMD Line^FS")
        swFile.WriteLine("^FO0170,0246^A0,30,20^FD" & TB_SMDLine.Text & "^FS")
        swFile.WriteLine("^FO0360,0246^A0,30,20^FDTop / Bottom^FS")
        swFile.WriteLine("^FO0518,0246^A0,30,20^FD" & TB_TB.Text & "^FS")
        swFile.WriteLine("^FO0016,0284^A0,30,20^FDSMD Date^FS")
        swFile.WriteLine("^FO0170,0284^A0,30,18^FD" & writeDate & "^FS")
        If readyTop = True Then
            swFile.WriteLine("^FO0016,0324^A1N,30,20^FD비고^FS")
            swFile.WriteLine("^FO0170,0324^A1N,70,50^FDTop 작업대기품^FS")
        Else
            swFile.WriteLine("^FO0016,0324^A0,30,20^FDProcess^FS")
            swFile.WriteLine("^FO0170,0324^A1N,30,20^FD" & TB_Process.Text & "^FS")
        End If

        swFile.WriteLine("^FO020,0020^BXN,3,200,44,44^FD" & TB_PONo.Text & "!" & LB_HistoryIndex.Text & "^FS")

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

    Private Sub TB_MagazineQty_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_MagazineQty.KeyDown

        If Not TB_MagazineQty.Text = String.Empty And e.KeyCode = 13 Then
            BTN_Exit_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub TB_MagazineQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TB_MagazineQty.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "," Then
            e.Handled = True
        End If

    End Sub
End Class