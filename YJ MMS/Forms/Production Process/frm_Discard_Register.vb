Imports MySql.Data.MySqlClient

Public Class frm_Discard_Register

    Private Sub frm_Discard_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Private Function Load_Process() As String

        Dim processList As String = String.Empty

        DBConnect()

        Dim strSQL As String = "call sp_mms_discard_register(0"
        strSQL += ", '" & TB_OrderIndex.Text & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            processList = sqlDR("process_list")
        Loop
        sqlDR.Close()

        DBClose()

        Return processList

    End Function

    Private Sub BTN_Discard_Save_Click(sender As Object, e As EventArgs) Handles BTN_Discard_Save.Click

        If TB_BoardNo.Text = String.Empty Then
            MessageBox.Show(Me, "Board No.가 입력되지 않았습니다.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
            TB_BoardNo.SelectAll()
            TB_BoardNo.Focus()
            Exit Sub
        End If

        If TB_Discard_Resone.Text = String.Empty Then
            MessageBox.Show(Me, "폐기 사유가 입력되지 않았습니다.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
            TB_Discard_Resone.SelectAll()
            TB_Discard_Resone.Focus()
            Exit Sub
        End If

        If MessageBox.Show(Me,
                           "폐기등록 하시겠습니까?",
                           msg_form,
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

        Try

            strSQL = "insert into tb_mms_production_discard_list("
            strSQL += "discard_index, order_index, process_name, work_side"
            strSQL += ", board_no, discard_reason, write_date, write_id, history_index"
            strSQL += ") "
            strSQL += "select f_mms_production_discard_no('2024-07-02')"
            strSQL += ",'" & TB_OrderIndex.Text & "'"
            strSQL += ",'" & TB_Process.Text & "'"
            strSQL += ",'" & TB_Workside.Text & "'"
            strSQL += ",'" & TB_BoardNo.Text & "'"
            strSQL += ",'" & TB_Discard_Resone.Text & "'"
            strSQL += ",'" & writeDate & "'"
            strSQL += ",'" & loginID & "'"
            strSQL += ",'" & TB_HistoryNo.Text & "'"
            strSQL += ";"

            strSQL += "update tb_mms_order_register_list set discard_quantity = discard_quantity + 1"
            strSQL += " where order_index = '" & TB_OrderIndex.Text & "'"
            strSQL += ";"

            Dim updateTable As String = "tb_mms_smd_production_history"

            If Not TB_Process.Text.Equals("SMD") Then
                updateTable = "tb_mms_ws_output_history"
            End If

            strSQL += "update " & updateTable & " set discard_quantity = discard_quantity + 1"
            strSQL += " where history_index = '" & TB_HistoryNo.Text & "'"
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

        Thread_LoadingFormEnd()

        MessageBox.Show(Me, "저장 완료." & vbCrLf & "창이 닫힙니다.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Dispose()

    End Sub
End Class