Public Class Setting

    Dim LineCode As String

    Private Sub Setting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Port.Text = registryEdit.ReadRegKey("Software\Yujin\Message_Server\Setting", "Socket Port", 10521)
        Time.Text = registryEdit.ReadRegKey("Software\Yujin\Message_Server\Setting", "Check Time", 10)
        Recheck.Text = registryEdit.ReadRegKey("Software\Yujin\Message_Server\Setting", "ReCheck", 1)
        DBIP.Text = registryEdit.ReadRegKey("Software\Yujin\Message_Server\Setting", "db IP", "125.137.78.158")
        DBPort.Text = registryEdit.ReadRegKey("Software\Yujin\Message_Server\Setting", "db Port", 10522)
        DBID.Text = registryEdit.ReadRegKey("Software\Yujin\Message_Server\Setting", "db ID", "yujin_MySQL")
        DBPass.Text = registryEdit.ReadRegKey("Software\Yujin\Message_Server\Setting", "db Password", "Dbwlswjswk1!")
        dbName.Text = registryEdit.ReadRegKey("Software\Yujin\Message_Server\Setting", "db Name", "yj_mms")

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave1.Click

        registryEdit.WriteRegKey("Software\Yujin\Message_Server\Setting", "Socket Port", Port.Text)
        registryEdit.WriteRegKey("Software\Yujin\Message_Server\Setting", "Check Time", Time.Text)
        registryEdit.WriteRegKey("Software\Yujin\Message_Server\Setting", "ReCheck", Recheck.Text)

        MsgBox("프로그램을 재시작하여 주십시오...", MsgBoxStyle.Information, "Setting")

        MainForm.Dispose()

        Me.Close()

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

    Private Sub btnSave3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave3.Click

        registryEdit.WriteRegKey("Software\Yujin\Message_Server\Setting", "db IP", DBIP.Text)
        registryEdit.WriteRegKey("Software\Yujin\Message_Server\Setting", "db Port", DBPort.Text)
        registryEdit.WriteRegKey("Software\Yujin\Message_Server\Setting", "db ID", DBID.Text)
        registryEdit.WriteRegKey("Software\Yujin\Message_Server\Setting", "db Password", DBPass.Text)
        registryEdit.WriteRegKey("Software\Yujin\Message_Server\Setting", "db Name", dbName.Text)

        MsgBox("저장완료" & vbCrLf & "프로그램을 다시 시작하여 주십시오.", MsgBoxStyle.Information, "Setting")
        Me.Dispose()
        MainForm.Dispose()

    End Sub
End Class
