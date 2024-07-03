Public Class frm_DiscardAlarm
    Private Sub frm_DiscardAlarm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim x As Integer
        Dim y As Integer
        x = Screen.PrimaryScreen.WorkingArea.Width
        y = Screen.PrimaryScreen.WorkingArea.Height - Me.Height - 10

        Me.ShowInTaskbar = False

        Do Until x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width - 20
            x = x - 1
            Me.Location = New Point(x, y)
        Loop

    End Sub

    Private Sub frm_DiscardAlarm_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick

        frm_Production_Discard_Confirm.MdiParent = frm_Main
        If Not frm_Production_Discard_Confirm.Visible Then frm_Production_Discard_Confirm.Show()
        frm_Production_Discard_Confirm.CB_ConfirmStatus.SelectedIndex = 2
        frm_Production_Discard_Confirm.BTN_Search_Click(Nothing, Nothing)
        frm_Production_Discard_Confirm.Focus()

        Me.Close()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

        frm_Production_Discard_Confirm.MdiParent = frm_Main
        If Not frm_Production_Discard_Confirm.Visible Then frm_Production_Discard_Confirm.Show()
        frm_Production_Discard_Confirm.CB_ConfirmStatus.SelectedIndex = 2
        frm_Production_Discard_Confirm.BTN_Search_Click(Nothing, Nothing)
        frm_Production_Discard_Confirm.Focus()

        Me.Close()

    End Sub

    Private Sub frm_DiscardAlarm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing



    End Sub
End Class