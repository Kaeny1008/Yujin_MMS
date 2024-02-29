Public Class frm_LoadingImage
    Private Sub frm_LoadingImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Interval = 1
        Timer1.Start()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If th_FormClose = True Then
            DialogResult = DialogResult.OK
            Timer1.Stop()
        End If

    End Sub
End Class