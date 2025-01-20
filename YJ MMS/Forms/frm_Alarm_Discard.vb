Public Class frm_Alarm_Discard
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

        Click_Action()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

        Click_Action()

    End Sub

    Private Sub Click_Action()

        frm_Production_Discard_Confirm.MdiParent = frm_Main
        If Not frm_Production_Discard_Confirm.Visible Then frm_Production_Discard_Confirm.Show()
        frm_Production_Discard_Confirm.CB_ConfirmStatus.SelectedIndex = 2
        frm_Production_Discard_Confirm.BTN_Search_Click(Nothing, Nothing)
        frm_Production_Discard_Confirm.Focus()

        Me.Close()

    End Sub
End Class