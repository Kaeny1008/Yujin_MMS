Public Class SQL_Connection

    Private Sub SQL_Connection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TB_IP.Text = registryEdit.ReadRegKey("Software\Yujin", "server.IP", "125.137.78.158")
        TB_PORT.Text = registryEdit.ReadRegKey("Software\Yujin", "server.PORT", 1052)
        TB_ID.Text = registryEdit.ReadRegKey("Software\Yujin", "server.ID", "yujin_MySQL")
        TB_PW.Text = registryEdit.ReadRegKey("Software\Yujin", "server.PSWD", "Dbwlswjswk1!")

    End Sub

    Private Sub BTN_SAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_SAVE.Click

        registryEdit.WriteRegKey("Software\Yujin", "server.IP", TB_IP.Text)
        registryEdit.WriteRegKey("Software\Yujin", "server.PORT", TB_PORT.Text)
        registryEdit.WriteRegKey("Software\Yujin", "server.ID", TB_ID.Text)
        registryEdit.WriteRegKey("Software\Yujin", "server.PSWD", TB_PW.Text)
        serverID = TB_ID.Text
        serverPORT = TB_PORT.Text
        serverIP = TB_IP.Text
        serverPSWD = TB_PW.Text

        If DBConnect() = False Then Exit Sub

        If DBConnect1.State = 1 Then
            DBClose()
            MsgBox("접속성공", MsgBoxStyle.Information, "자산관리")
            Me.Dispose()
        End If

    End Sub
End Class