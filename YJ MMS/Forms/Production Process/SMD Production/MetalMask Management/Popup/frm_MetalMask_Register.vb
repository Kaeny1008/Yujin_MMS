Imports MySqlConnector

Public Class frm_MetalMask_Register

    Dim org_UsingCount As Integer

    Private Sub MM_Popup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Btn_Save.Text = "수정" Then
            Mask_Data_Load()
        End If

    End Sub

    Private Sub Mask_Data_Load()

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mmms_metalmask_list(1"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & Tb_MaskSN.Text & "'"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            If sqlDR("mask_usable") = "Yes" Then
                Rb_Use.Checked = True
            Else
                Rb_Not_Use.Checked = True
            End If
            Tb_customerCode.Text = sqlDR("customer_code")
            Cb_customerName_DropDown("notClose", Nothing)
            Cb_customerName.Text = sqlDR("customer_name")
            Tb_modelCode.Text = sqlDR("model_name")
            'Cb_modelName_DropDown("notClose", Nothing)
            'Cb_modelName.Text = sqlDR("model_name")
            Cb_WorkSide.Text = sqlDR("work_side")
            Tb_Revision.Text = sqlDR("revision")
            Cb_Thickness.Text = sqlDR("thickness")
            DT_MakingDate.Value = Format(sqlDR("making_date"), "yyyy-MM-dd")
            Dt_InDate.Value = Format(sqlDR("in_date"), "yyyy-MM-dd")
            TB_MakingCompany.Text = sqlDR("making_company")
            CB_MaskSize.Text = sqlDR("wh_size")
            Nud_UsingCount.Value = sqlDR("using_count")
            org_UsingCount = sqlDR("using_count")
            Tb_Note.Text = sqlDR("mask_note")
            TB_CheckResult.Text = sqlDR("first_unique_note")
            If CInt(sqlDR("history_count")) > 1 Then
                Nud_UsingCount.Enabled = False
                TB_CheckResult.Enabled = False
                Label7.Visible = True
            Else
                Nud_UsingCount.Enabled = True
                TB_CheckResult.Enabled = True
                Label7.Visible = False
            End If
            TB_Storage_Box.Text = sqlDR("storage_box")
            TB_Storage_No.Text = sqlDR("storage_no")
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub Cb_customerName_DropDown(sender As Object, e As EventArgs) Handles Cb_customerName.DropDown

        Dim cb_old_string As String = Cb_customerName.Text

        Cb_customerName.Items.Clear()

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "select customer_name from tb_customer_list"
        strSQL += " order by customer_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Cb_customerName.Items.Add(sqlDR("customer_name"))
        Loop
        sqlDR.Close()

        DBClose()

        Cb_customerName.Text = cb_old_string

    End Sub

    Private Sub Cb_customerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_customerName.SelectedIndexChanged

        Tb_customerCode.Text = String.Empty

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "select customer_code from tb_customer_list"
        strSQL += " where customer_name = '" & Cb_customerName.Text & "'"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Tb_customerCode.Text = sqlDR("customer_code")
        Loop
        sqlDR.Close()

        DBClose()

        Tb_modelCode.Text = String.Empty
        'Cb_modelName.SelectedIndex = -1

    End Sub

    'Private Sub Cb_modelName_DropDown(sender As Object, e As EventArgs) Handles Cb_modelName.DropDown


    '    Dim cb_old_string As String = Cb_modelName.Text

    '    Cb_modelName.Items.Clear()

    '    If DBConnect() = False Then Exit Sub

    '    Dim strSQL As String = "select item_code from tb_model_list"
    '    strSQL += " where customer_code = '" & Tb_customerCode.Text & "'"
    '    strSQL += " order by item_code"

    '    Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
    '    Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

    '    Do While sqlDR.Read
    '        Cb_modelName.Items.Add(sqlDR("item_code"))
    '    Loop
    '    sqlDR.Close()

    '    DBClose()

    '    Cb_modelName.Text = cb_old_string

    'End Sub

    'Private Sub Cb_modelName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cb_modelName.SelectedIndexChanged

    '    Tb_modelCode.Text = String.Empty

    '    If DBConnect() = False Then Exit Sub

    '    Dim strSQL As String = "select model_code from tb_model_list"
    '    strSQL += " where item_code = '" & Cb_modelName.Text & "'"

    '    Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
    '    Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

    '    Do While sqlDR.Read
    '        Tb_modelCode.Text = sqlDR("model_code")
    '    Loop
    '    sqlDR.Close()

    '    DBClose()

    'End Sub

    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click

        If Tb_MaskSN.Text = String.Empty Or
            Tb_customerCode.Text = String.Empty Or
            Tb_modelCode.Text = String.Empty Or
            Cb_Thickness.Text = String.Empty Or
            CB_MaskSize.Text = String.Empty Or
            Cb_WorkSide.Text = String.Empty Or
            TB_CheckResult.Text = String.Empty Then
            MsgBox("필수 입력 항목이 누락되었습니다.", MsgBoxStyle.Information, msg_form)
            Exit Sub
        End If

        If Btn_Save.Text = "저장" Then
            If NewMaskSave() = True Then
                MessageBox.Show("Metal Mask QR Label을 발행 합니다.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Brother_Printer(Tb_MaskSN.Text)
                Me.DialogResult = DialogResult.Yes
                Me.Dispose()
            End If
        ElseIf Btn_Save.Text = "수정" Then
            If EditMaskSave() = True Then
                Me.DialogResult = DialogResult.Yes
                Me.Dispose()
            End If
        End If

    End Sub

    Private Function EditMaskSave() As Boolean

        Dim result As Boolean = True

        If DBConnect() = False Then
            Return False
            Exit Function
        End If

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            Dim write_date As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            Dim maskStatus As String = "No"
            If Rb_Use.Checked Then
                maskStatus = "Yes"
            End If

            strSQL = "update tb_mmms_metal_mask_list"
            strSQL += " set mask_usable = '" & maskStatus & "'"
            strSQL += ", customer_code = '" & Tb_customerCode.Text & "'"
            strSQL += ", model_name = '" & Tb_modelCode.Text & "'"
            strSQL += ", revision = '" & Tb_Revision.Text & "'"
            strSQL += ", thickness = '" & Cb_Thickness.Text & "'"
            strSQL += ", making_date = '" & Format(DT_MakingDate.Value, "yyyy-MM-dd") & "'"
            strSQL += ", in_date = '" & Format(Dt_InDate.Value, "yyyy-MM-dd") & "'"
            strSQL += ", making_company = '" & TB_MakingCompany.Text & "'"
            strSQL += ", wh_size = '" & CB_MaskSize.Text & "'"
            strSQL += ", using_count = '" & Nud_UsingCount.Value & "'"
            strSQL += ", mask_note = '" & Tb_Note.Text & "'"
            strSQL += ", work_side = '" & Cb_WorkSide.Text & "'"
            strSQL += ", first_unique_note = '" & TB_CheckResult.Text & "'"
            strSQL += ", storage_box = '" & TB_Storage_Box.Text & "'"
            strSQL += ", storage_no = " & CInt(TB_Storage_No.Text) & ""
            strSQL += " where mask_sn = '" & Tb_MaskSN.Text & "';"

            strSQL += "update tb_mmms_metal_mask_history"
            strSQL += " set total_use_count = '" & Nud_UsingCount.Value & "'"
            strSQL += ", unique_note = '" & TB_CheckResult.Text & "'"
            strSQL += " where mask_sn = '" & Tb_MaskSN.Text & "'"
            strSQL += " order by history_no limit 1;"

            If Not strSQL = String.Empty Then
                sqlCmd = New MySqlCommand(strSQL, dbConnection1)
                sqlCmd.Transaction = sqlTran
                sqlCmd.ExecuteNonQuery()

                sqlTran.Commit()
            End If
        Catch ex As MySqlException
            sqlTran.Rollback()
            result = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, msg_form)
        End Try

        DBClose()

        Return result

    End Function

    Private Function NewMaskSave() As Boolean

        Dim result As Boolean = True

        If DBConnect() = False Then
            Return False
            Exit Function
        End If

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            Dim write_date As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            strSQL = "insert into tb_mmms_metal_mask_list("
            strSQL += "mask_sn, mask_usable, first_unique_note, customer_code"
            strSQL += ", model_name, revision, thickness, making_date, in_date, making_company"
            strSQL += ", wh_size, using_count, mask_note, work_side, write_id, write_date, storage_box, storage_no"
            strSQL += ") values("
            strSQL += "'" & Tb_MaskSN.Text & "'"
            If Rb_Use.Checked Then
                strSQL += ",'Yes'"
            Else
                strSQL += ",'No'"
            End If
            strSQL += ",'" & TB_CheckResult.Text & "'"
            strSQL += ",'" & Tb_customerCode.Text & "'"
            strSQL += ",'" & Tb_modelCode.Text & "'"
            strSQL += ",'" & Tb_Revision.Text & "'"
            strSQL += ",'" & Cb_Thickness.Text & "'"
            strSQL += ",'" & Format(DT_MakingDate.Value, "yyyy-MM-dd") & "'"
            strSQL += ",'" & Format(Dt_InDate.Value, "yyyy-MM-dd") & "'"
            strSQL += ",'" & TB_MakingCompany.Text & "'"
            strSQL += ",'" & CB_MaskSize.Text & "'"
            strSQL += ",'" & Nud_UsingCount.Value & "'"
            strSQL += ",'" & Tb_Note.Text & "'"
            strSQL += ",'" & Cb_WorkSide.Text & "'"
            strSQL += ",'" & loginID & "'"
            strSQL += ",'" & write_date & "'"
            strSQL += ",'" & TB_Storage_Box.Text & "'"
            strSQL += "," & CInt(TB_Storage_No.Text) & ""
            strSQL += ");"

            strSQL += "insert into tb_mmms_metal_mask_history("
            strSQL += "write_option, mask_sn, use_count, daily_use_count, total_use_count"
            strSQL += ", gubun, unique_note, write_id, write_date, mask_note"
            strSQL += ") values("
            strSQL += "'Event'"
            strSQL += ",'" & Tb_MaskSN.Text & "'"
            strSQL += ",0"
            strSQL += ",0"
            strSQL += "," & Nud_UsingCount.Value
            strSQL += ",'신규입고'"
            strSQL += ",'" & TB_CheckResult.Text & "'"
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
            result = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, msg_form)
        End Try

        DBClose()

        Return result

    End Function

    Private Sub MM_Popup_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Me.Dispose()

    End Sub
End Class