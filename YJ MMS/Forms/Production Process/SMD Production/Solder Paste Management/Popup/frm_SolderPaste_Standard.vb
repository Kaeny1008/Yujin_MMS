Imports MySqlConnector

Public Class frm_SolderPaste_Standard
    Private Sub frm_SolderPaste_Standard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Load_Standards()

    End Sub

    Private Sub Load_Standards()

        DBConnect()

        Dim strSQL As String = "select aging_min, limit_of_use_time, mixing_time"
        strSQL += " from tb_mms_solder_standards"
        strSQL += ";"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            NumericUpDown1.Value = sqlDR("aging_min")
            NumericUpDown2.Value = sqlDR("limit_of_use_time")
            NumericUpDown3.Value = sqlDR("mixing_time")
        Loop

        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        Thread_LoadingFormStart(Me, "Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            strSQL += "update tb_mms_solder_standards set "
            strSQL += "aging_min = " & NumericUpDown1.Value
            strSQL += ", limit_of_use_time = " & NumericUpDown2.Value
            strSQL += ", mixing_time = " & NumericUpDown3.Value
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

        MessageBox.Show(frm_Main, "저장완료.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

        frm_SolderPaste_Use.LB_Aging_Min.Text = NumericUpDown1.Value
        frm_SolderPaste_Use.LB_Limit_Of_Use_Time.Text = NumericUpDown2.Value
        frm_SolderPaste_Use.LB_Mixing_Time.Text = NumericUpDown3.Value

        Me.Dispose()

    End Sub
End Class