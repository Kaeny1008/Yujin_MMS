Public Class frm_SQL_Conn
    Private Sub frm_SQL_Conn_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tbIP.Text = registryEdit.ReadRegKey("Software\Yujin", "Server.IP", "125.137.78.158")
        tbPort.Text = registryEdit.ReadRegKey("Software\Yujin", "Server.PORT", 10522)
        tbID.Text = registryEdit.ReadRegKey("Software\Yujin", "Server.ID", "yujin_MySQL")
        tbPSWD.Text = registryEdit.ReadRegKey("Software\Yujin", "Server.PSWD", "Dbwlswjswk1!")
        tbTimeOut.Text = registryEdit.ReadRegKey("Software\Yujin", "ConnectionTimeOut", 5)
        TB_MessageIP.Text = registryEdit.ReadRegKey("Software\Yujin", "MessageServer.IP", "125.137.78.158")
        TB_MessagePort.Text = registryEdit.ReadRegKey("Software\Yujin", "MessageServer.Port", 10521)

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        serverID = tbID.Text
        serverPORT = tbPort.Text
        serverIP = tbIP.Text
        serverPSWD = tbPSWD.Text
        messageIP = TB_MessageIP.Text
        messagePort = TB_MessagePort.Text

        If DBConnect() = False Then
            '접속 테스트 실패시 원래되로 돌린다.
            '어차피 메세지 안내는 필요없다. 접속시도시에 알람이 떴으니까
            'MessageBox.Show(New Form With {.TopMost = True},
            '                "접속 실패.",
            '                "Server Connected",
            '                MessageBoxButtons.OK,
            '                MessageBoxIcon.Information,
            '                MessageBoxDefaultButton.Button1)
            serverIP = registryEdit.ReadRegKey("Software\Yujin", "Server.IP", "192.168.0.222")
            serverPORT = registryEdit.ReadRegKey("Software\Yujin", "Server.PORT", 10522)
            serverID = registryEdit.ReadRegKey("Software\Yujin", "Server.ID", "yujin_MySQL")
            serverPSWD = registryEdit.ReadRegKey("Software\Yujin", "Server.PSWD", "Dbwlswjswk1!")
            connectionTimeOut = registryEdit.ReadRegKey("Software\Yujinm", "ConnectionTimeOut", 5)
            messageIP = registryEdit.ReadRegKey("Software\Yujin", "MessageServer.IP", "125.137.78.158")
            messagePort = registryEdit.ReadRegKey("Software\Yujin", "MessageServer.Port", 10521)
            Exit Sub
        End If

        '접속 테스트 결과 이상없으면 레지스트리에 저정한다.
        registryEdit.WriteRegKey("Software\Yujin", "Server.IP", tbIP.Text)
        registryEdit.WriteRegKey("Software\Yujin", "Server.PORT", CDbl(tbPort.Text))
        registryEdit.WriteRegKey("Software\Yujin", "Server.ID", tbID.Text)
        registryEdit.WriteRegKey("Software\Yujin", "Server.PSWD", tbPSWD.Text)
        registryEdit.WriteRegKey("Software\Yujin", "ConnectionTimeOut", CDbl(tbTimeOut.Text))
        registryEdit.WriteRegKey("Software\Yujin", "MessageServer.IP", TB_MessageIP.Text)
        registryEdit.WriteRegKey("Software\Yujin", "MessageServer.PORT", CDbl(TB_MessagePort.Text))

        MessageBox.Show(New Form With {.TopMost = True},
                        "접속 성공." & vbCrLf &
                        "(접속 정보가 자동 저장되었습니다.)" & vbCrLf &
                        "Update Checker를 재 시작합니다.",
                        "Server Connected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1)

        Dim ucProcess() As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessesByName("Update Checker")
        If ucProcess.Length > 0 Then
            ucProcess(0).Kill()
        End If

        Try
            Shell(Application.StartupPath & "\Update Checker.exe", AppWinStyle.Hide)
        Catch ex As Exception
            If MsgBox("업데이트 확인 프로그램을 실행 할 수 없습니다." & vbCrLf &
                      "무시 후 계속 진행하시겠습니까?" & vbCrLf &
                      "( " & Application.StartupPath & "\Update Checker.exe" & " )",
                        MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Update Checker") = MsgBoxResult.No Then
            End If
        End Try

        Me.Dispose()

    End Sub
End Class