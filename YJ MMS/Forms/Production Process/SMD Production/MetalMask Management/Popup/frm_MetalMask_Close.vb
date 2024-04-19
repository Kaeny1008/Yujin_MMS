Imports MySql.Data.MySqlClient

Public Class frm_MetalMask_Close
    Private Sub MM_Popup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Mask_Data_Load()

    End Sub

    Private Sub Mask_Data_Load()

        DBConnect()

        Dim strSQL As String = "call sp_mmms_metalmask_list(1, null, null, null, '" & Tb_MaskSN.Text & "');"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Tb_CustomerCode.Text = sqlDR("customer_code")
            Tb_CustomerName.Text = sqlDR("customer_name")
            Tb_ModelCode.Text = sqlDR("model_code")
            Tb_ModelName.Text = sqlDR("item_code")
            Tb_WorkSide.Text = sqlDR("work_side")
            Tb_Revision.Text = sqlDR("revision")
            Tb_Thickness.Text = sqlDR("thickness")
            Tb_MakingDate.Text = Format(sqlDR("making_date"), "yyyy-MM-dd")
            Tb_InDate.Text = Format(sqlDR("in_date"), "yyyy-MM-dd")
            TB_MakingCompany.Text = sqlDR("making_company")
            TB_MaskSize.Text = sqlDR("wh_size")
            Tb_UsingCount.Text = sqlDR("using_count")
            Tb_Note.Text = sqlDR("mask_note")
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub MM_Stop_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Me.Dispose()

    End Sub

    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click

        If MsgBox("현재 마스크를 폐기등록 하시겠습니까?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, msg_form) = MsgBoxResult.No Then Exit Sub

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            Dim write_date As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            strSQL = "insert into tb_mmms_metal_mask_close(mask_sn, write_id, write_date, close_reason) values"
            strSQL += "('" & Tb_MaskSN.Text & "'"
            strSQL += ",'" & loginID & "'"
            strSQL += ",'" & write_date & "'"
            strSQL += ",'" & TextBox1.Text & "');"

            strSQL += "update tb_mmms_metal_mask_list set mask_usable = 'No'"
            strSQL += " where mask_sn = '" & Tb_MaskSN.Text & "';"

            strSQL += "insert into tb_mmms_metal_mask_history(write_option, mask_sn, use_count, daily_use_count, total_use_count"
            strSQL += ", unique_note, write_id, write_date, mask_note) values"
            strSQL += "('Event'"
            strSQL += ",'" & Tb_MaskSN.Text & "'"
            strSQL += ",0"
            strSQL += ",0"
            strSQL += "," & Tb_UsingCount.Text
            strSQL += ",'폐기 등록 되었습니다.'"
            strSQL += ",'" & loginID & "'"
            strSQL += ",'" & write_date & "'"
            strSQL += ",'" & Tb_Note.Text & "');"

            If Not strSQL = String.Empty Then
                sqlCmd = New MySqlCommand(strSQL, dbConnection1)
                sqlCmd.Transaction = sqlTran
                sqlCmd.ExecuteNonQuery()

                sqlTran.Commit()
            End If
        Catch ex As MySqlException
            sqlTran.Rollback()
            MsgBox(ex.Message, MsgBoxStyle.Critical, msg_form)
        End Try

        DBClose()

        Me.DialogResult = DialogResult.Yes
        Me.Close()

    End Sub
End Class