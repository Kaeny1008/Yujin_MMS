Public Class frm_asdadsads
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim scr() As Screen = Screen.AllScreens
        If scr.Length > 1 Then
            'Debug.Print("frm_main X : " & frm_Main.Location.X & ", frm_main Y : " & frm_Main.Location.Y)
            Dim screen2 As Screen = If((scr(0).WorkingArea.Contains(Me.Location)), scr(1), scr(0))
            Me.Location = screen2.Bounds.Location
        End If
    End Sub
End Class