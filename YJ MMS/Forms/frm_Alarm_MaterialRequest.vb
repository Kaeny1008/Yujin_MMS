Public Class frm_Alarm_MaterialRequest
    Private Sub frm_Alarm_MaterialRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    Private Sub frm_Alarm_MaterialRequest_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Me.MouseDoubleClick

        Click_Action()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

        Click_Action()

    End Sub

    Private Sub Click_Action()

        frm_SMD_Material_Request.MdiParent = frm_Main
        If Not frm_SMD_Material_Request.Visible Then frm_SMD_Material_Request.Show()

        frm_SMD_Material_Request.TB_S_OrderIndex.Text = String.Empty
        frm_SMD_Material_Request.TB_S_ItemCode.Text = String.Empty
        frm_SMD_Material_Request.CB_S_Status.SelectedIndex = 2
        frm_SMD_Material_Request.BTN_Search_Click(Nothing, Nothing)

        Me.Close()

    End Sub
End Class