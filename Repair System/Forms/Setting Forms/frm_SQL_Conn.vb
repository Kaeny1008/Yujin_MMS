Public Class frm_SQL_Conn
    Private Sub frm_SQL_Conn_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tbIP.Text = registryEdit.ReadRegKey("Software\Yujin", "Server.IP", "192.168.0.222")
        tbPort.Text = registryEdit.ReadRegKey("Software\Yujin", "Server.PORT", 10522)
        tbID.Text = registryEdit.ReadRegKey("Software\Yujin", "Server.ID", "yujin_MySQL")
        tbPSWD.Text = registryEdit.ReadRegKey("Software\Yujin", "Server.PSWD", "Dbwlswjswk1!")
        tbTimeOut.Text = registryEdit.ReadRegKey("Software\Yujin", "ConnectionTimeOut", 5)

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        serverID = tbID.Text
        serverPORT = tbPort.Text
        serverIP = tbIP.Text
        serverPSWD = tbPSWD.Text

        DBConnect()
        If dbConnection1.State = 1 Then
            DBClose()
        Else
            '접속 테스트 실패시 원래되로 돌린다.
            serverIP = registryEdit.ReadRegKey("Software\Yujin", "Server.IP", "192.168.0.222")
            serverPORT = registryEdit.ReadRegKey("Software\Yujin", "Server.PORT", 10522)
            serverID = registryEdit.ReadRegKey("Software\Yujin", "Server.ID", "yujin_MySQL")
            serverPSWD = registryEdit.ReadRegKey("Software\Yujin", "Server.PSWD", "Dbwlswjswk1!")
            connectionTimeOut = registryEdit.ReadRegKey("Software\Yujinm", "ConnectionTimeOut", 5)
            Exit Sub
        End If

        '접속 테스트 결과 이상없으면 레지스트리에 저정한다.
        MsgBox("접속성공", MsgBoxStyle.Information, "Server Connection")
        registryEdit.WriteRegKey("Software\Yujin", "Server.IP", tbIP.Text)
        registryEdit.WriteRegKey("Software\Yujin", "Server.PORT", CDbl(tbPort.Text))
        registryEdit.WriteRegKey("Software\Yujin", "Server.ID", tbID.Text)
        registryEdit.WriteRegKey("Software\Yujin", "Server.PSWD", tbPSWD.Text)
        registryEdit.WriteRegKey("Software\Yujin", "ConnectionTimeOut", CDbl(tbTimeOut.Text))

    End Sub
End Class