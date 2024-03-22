Public Class frm_SMD_Production_Information

    'Public warning As Boolean

    Private Sub BTN_Cancel_Click(sender As Object, e As EventArgs) Handles BTN_Cancel.Click

        Me.DialogResult = DialogResult.Cancel

    End Sub

    Private Sub BTN_OK_Click(sender As Object, e As EventArgs) Handles BTN_OK.Click

        If Trim(TB_Operater.Text) = String.Empty Then
            MessageBox.Show(Me, "Operater를 입력하여 주십시오.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Me.DialogResult = DialogResult.OK

    End Sub

    Private Sub frm_SMD_Production_Information_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'If warning = True Then
        '    Label10.Visible = True
        'End If

    End Sub

    Private Sub TB_Operater_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_Operater.KeyDown

        If e.KeyCode = 13 Then
            BTN_OK_Click(Nothing, Nothing)
        End If

    End Sub
End Class