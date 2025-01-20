Public Class Setting

    Dim LineCode As String

    Private Sub Setting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TextBox1.Text = registryEdit.ReadRegKey("Software\Yujin\Message_Server", "my.IP", "192.168.0.174")
        Port.Text = registryEdit.ReadRegKey("Software\Yujin\Message_Server", "Socket Port", 10521)
        Time.Text = registryEdit.ReadRegKey("Software\Yujin\Message_Server", "Check Time", 10)
        Recheck.Text = registryEdit.ReadRegKey("Software\Yujin\Message_Server", "ReCheck", 1)
        TB_UpdateCheckTime.Text = updateCheckTime
        TB_DBIP.Text = serverIP
        TB_DBPort.Text = serverPORT
        TB_DBID.Text = serverID
        TB_DBPass.Text = serverPSWD
        TB_dbName.Text = dbName


    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave1.Click

        registryEdit.WriteRegKey("Software\Yujin\Message_Server", "Update Check Time", CInt(TB_UpdateCheckTime.Text))
        registryEdit.WriteRegKey("Software\Yujin\Message_Server", "Socket Port", Port.Text)
        registryEdit.WriteRegKey("Software\Yujin\Message_Server", "Check Time", Time.Text)
        registryEdit.WriteRegKey("Software\Yujin\Message_Server", "ReCheck", Recheck.Text)
        registryEdit.WriteRegKey("Software\Yujin\Message_Server", "my.IP", TextBox1.Text)

        MsgBox("프로그램을 재시작하여 주십시오...", MsgBoxStyle.Information, "Setting")

        MainForm.Dispose()

        Me.Close()

    End Sub

    Private Sub btnSave3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave3.Click

        registryEdit.WriteRegKey("Software\Yujin", "server.IP", TB_DBIP.Text)
        registryEdit.WriteRegKey("Software\Yujin", "server.PORT", TB_DBPort.Text)
        registryEdit.WriteRegKey("Software\Yujin", "server.ID", TB_DBID.Text)
        registryEdit.WriteRegKey("Software\Yujin", "server.PSWD", TB_DBPass.Text)
        registryEdit.WriteRegKey("Software\Yujin", "dbName", TB_dbName.Text)

        MsgBox("저장완료" & vbCrLf & "프로그램을 다시 시작하여 주십시오.", MsgBoxStyle.Information, "Setting")
        Me.Dispose()
        MainForm.Dispose()

    End Sub

    Private Sub Line_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Line.DropDown

        'Line.Items.Clear()

        'Dim iSQl As String
        'Dim RC1 As ADODB.Recordset

        'iSQl = "select * from CodeManager where CodeMark = 'SMD Line Name' order by CodeName"

        'RC1 = New ADODB.Recordset
        'RC1.Open(iSQl, dbConnection1)

        'If RC1.RecordCount > 0 Then
        '    RC1.MoveFirst()
        '    For i = 1 To RC1.RecordCount
        '        Line.Items.Add(RC1.Fields("CodeName").Value)
        '        RC1.MoveNext()
        '    Next
        'End If
        'RC1.Close()

    End Sub

    Private Sub Line_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Line.SelectedIndexChanged

        'LineCode = ""

        'Dim iSQl As String
        'Dim RC1 As ADODB.Recordset

        'iSQl = "select * from CodeManager where CodeMark = 'SMD Line Name' and CodeName = '" & Line.Text & "' order by CodeName"

        'RC1 = New ADODB.Recordset
        'RC1.Open(iSQl, dbConnection1)

        'If RC1.RecordCount > 0 Then
        '    LineCode = RC1.Fields("Code").Value
        'End If
        'RC1.Close()

        'iSQl = "select * from DIO_Address where Line = '" & Line.Text & "'"

        'RC1 = New ADODB.Recordset
        'RC1.Open(iSQl, dbConnection1)

        'If RC1.RecordCount > 0 Then
        '    IP.Text = RC1.Fields("IP").Value
        'Else
        '    IP.Text = ""
        'End If
        'RC1.Close()

    End Sub

    Private Sub btnSave2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave2.Click

        'If Line.Text = "" Then
        '    MsgBox("라인이 선택되지 않았습니다.", MsgBoxStyle.Information, "Setting")
        '    Exit Sub
        'End If

        'If IP.Text = "" Then
        '    MsgBox("IP 주소가 입력되지 않았습니다.", MsgBoxStyle.Information, "Setting")
        '    Exit Sub
        'End If


        'Dim strSQL As String = "delete from DIO_Address where LineCode = '" & LineCode & "'"
        'Connserver.Execute(strSQL)

        'strSQL = "Insert into DIO_Address values('" & LineCode & "','" & Line.Text & "','" & IP.Text & "')"

        'Connserver.Execute(strSQL)

        'MsgBox("라인 : " & Line.Text & " 가 IP 주소 : " & IP.Text & " 로 변경 되었습니다.", MsgBoxStyle.Information,
        '       "Message Server")

    End Sub
End Class
