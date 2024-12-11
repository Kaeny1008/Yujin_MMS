Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Text
Imports MySqlConnector
Imports System.IO

Public Class MainForm

    Dim iSQL As String
    Dim RC1 As ADODB.Recordset
    Dim WriteData As String
    Dim strSQL As String
    Dim RCnt As Integer
    Public DBName As String
    Dim FDLocation() As String

#Region "소켓통신"

    Private allDone As New ManualResetEvent(False)
    Private serverThread As Thread

    Private ServerListener As Socket = Nothing
    Private bytes() As Byte = New [Byte](1024) {}

    Private Sub ServerStart()

        'CheckForIllegalCrossThreadCalls = False
        serverThread = New Thread(New ThreadStart(AddressOf StartListening))
        serverThread.IsBackground = True
        serverThread.Start()

    End Sub

    Private Sub StartListening()

        ServerListener = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

        'Dim ipHostInfo As IPHostEntry = Dns.Resolve(Dns.GetHostName())
        'Dim ipAddress As IPAddress = ipHostInfo.AddressList(1)
        Dim Port As Integer = registryEdit.ReadRegKey("Software\Yujin\Message_Server", "Socket Port", 10521)
        Dim localEndPoint As New IPEndPoint(ipAddress, Port)

        Try

            If ServerListener.Connected = True Then ServerListener.Close()
            ServerListener.Bind(localEndPoint)
            ServerListener.Listen(30)

            While True
                ' Set the event to nonsignaled state.
                allDone.Reset()
                ' Start an asynchronous socket to listen for connections.
                ServerListener.BeginAccept(New AsyncCallback(AddressOf AcceptCallback), ServerListener)
                ' Wait until a connection is made before continuing.
                allDone.WaitOne()
            End While
        Catch e As ThreadAbortException
            'MessageBox.Show(e.Message, "Thread Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch e As Exception
            MessageBox.Show(e.Message, "Lisner Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub 'StartListening

    Private Sub AcceptCallback(ByVal ar As IAsyncResult)

        ' Signal the main thread to continue.
        allDone.Set()

        Try
            ' Get the socket that handles the client request.
            Dim listener As Socket = CType(ar.AsyncState, Socket)
            Dim handler As Socket = listener.EndAccept(ar)

            ' Create the state object.
            Dim state As New StateObject
            state.workSocket = handler

            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        New AsyncCallback(AddressOf ReadCallback), state)

            '###연결내용 등록
            'Dim aaa As IPEndPoint = handler.RemoteEndPoint
            'Console.WriteLine(aaa.Address.ToString & ", " & aaa.Port.ToString & " Connected")
            Dim lvi As ListViewItem = New ListViewItem(handler.RemoteEndPoint.ToString)
            lvi.Tag = handler
            BeginInvoke(New EventHandler(AddressOf ClientJoin), lvi)
            Send(handler, "Server Accept")
            '###
        Catch ex As ObjectDisposedException
            '여긴 그냥 무시.... 재시작...;;
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub 'AcceptCallback

    Private Sub ReadCallback(ByVal ar As IAsyncResult)

        Dim content As [String] = [String].Empty
        Dim state As StateObject = CType(ar.AsyncState, StateObject)
        Dim handler As Socket = state.workSocket

        Dim bytesRead As Integer

        Try
            bytesRead = handler.EndReceive(ar)
            Dim aaa As IPEndPoint = handler.RemoteEndPoint

            If bytesRead > 0 Then
                content = Encoding.Default.GetString(state.buffer, 0, bytesRead)
                '수신응답부분인지 데이터 전송부분인지 구분
                If content.Substring(0, 1) = Chr(18) Then
                    'BeginInvoke(New EventHandler(AddressOf ClientResponse), aaa.Address.ToString & "||" & content) '응답내용 전송
                    BeginInvoke(New EventHandler(AddressOf ClientResponse), aaa) '응답내용 전송
                    'ElseIf content = "Client Connect" Then
                    '    'MsgBox("client ok")
                    '    Send(handler, "Server Accept")
                    '    'Send(handler, "Server Accept")
                Else
                    If Asc(content.Substring(0, 1)) > 31 Then 'ascii 32이하면 응답부분이므로 무시
                        BeginInvoke(New EventHandler(AddressOf ClientData), aaa.Address.ToString & "||" & content & "||" & aaa.ToString) '수신내용 전송
                    End If
                End If
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize,
                                    0, New AsyncCallback(AddressOf ReadCallback), state)
            Else
                '수신데이터가 없다면 종료
                'Console.WriteLine(aaa.Address.ToString & ", " & aaa.Port.ToString & " Disconnected")
                '###연결내용 삭제
                Dim lvi As ListViewItem = New ListViewItem(handler.RemoteEndPoint.ToString)
                lvi.Tag = handler
                BeginInvoke(New EventHandler(AddressOf ClientRemove), lvi)
                '###
                handler.Shutdown(SocketShutdown.Both)
                handler.Close()
            End If
        Catch ex As ObjectDisposedException

        Catch ex As SocketException
            'MessageBox.Show(ex.ErrorCode & ex.Message, "socket", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub 'ReadCallback

    Private Sub Send(ByVal client As Socket, ByVal SendData As String)

        Dim data() As Byte = Encoding.ASCII.GetBytes(SendData)
        Try
            client.BeginSend(data, 0, data.Length, SocketFlags.None, New AsyncCallback(AddressOf SendCallback), client)
        Catch ex As ObjectDisposedException
            '몰라 그냥 비워둬..
        Catch ex As Exception
            '몰라 그냥 비워둬..
        End Try

    End Sub 'Send

    Private Sub SendCallback(ByVal ar As IAsyncResult)

        'Retrieve the socket from the state object.
        Dim handler As Socket = CType(ar.AsyncState, Socket)

        ' Complete sending the data to the remote device.
        Try
            Dim bytesSent As Integer = handler.EndSend(ar)
        Catch ex As ObjectDisposedException
        End Try

    End Sub 'SendCallback

#End Region

    Dim ftpUrl As String = "ftp://" & registryEdit.ReadRegKey("Software\Yujin", "Server.IP", "125.137.78.158") & ":" & registryEdit.ReadRegKey("Software\Yujin\FTP", "ftpPort", 1052)
    Dim ftpPort As Integer = registryEdit.ReadRegKey("Software\Yujin\FTP", "ftpPort", 1052)
    Dim ftpID As String = registryEdit.ReadRegKey("Software\Yujin\FTP", "ftpID", "yujin_ftp")
    Dim ftpPassword As String = registryEdit.ReadRegKey("Software\Yujin\FTP", "ftpPassword", "Yujin_ftp!")

    Private Sub ClientList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'MsgBox(UBound(Diagnostics.Process.GetProcessesByName("Update Checker")))
        If UBound(Diagnostics.Process.GetProcessesByName("Update Checker")) = 0 Then
            'UpdateChecker가 켜져 있다면 종료
            Dim ucProcess() As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessesByName("Update Checker")
            If ucProcess.Length > 0 Then
                ucProcess(0).Kill()
            End If
        End If

        'Me.Text = "Message Server : " & My.Application.Info.Version.ToString
        Me.Text = "Message Server (Build : " & System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() & " )"

        NumericUpDown1.Value = registryEdit.ReadRegKey("Software\Yujin\Message_Server", "Message AutoClean Count", 500)

        ServerStart()

        ClientCheckingTimer.Enabled = True
        ClientCheckingTimer.Interval = registryEdit.ReadRegKey("Software\Yujin\Message_Server", "Check Time", 10) * 1000
        ClientRemoveTimer.Enabled = False
        ClientRemoveTimer.Interval = 5000
        Timer1.Interval = 30000
        Timer1.Enabled = True

    End Sub

    Private Sub ServerStop()

        'Restart Message 전송
        For i = 0 To ClientList.Items.Count - 1
            If ClientList.Items(i).SubItems(4).Text = "Connected" And ClientList.Items(i).SubItems(2).Text = "" Then
                Dim abc As Socket = ClientList.Items(i).Tag
                Send(abc, "Server Stop")
            End If
        Next

        For i = 0 To ClientList.Items.Count - 1
            If ClientList.Items(i).SubItems(4).Text = "Connected" And Not ClientList.Items(i).SubItems(2).Text = "" Then
                Dim abc As Socket = ClientList.Items(i).Tag
                abc.Shutdown(SocketShutdown.Both)
                abc.Close()
            End If
        Next

        If serverThread.IsAlive Then
            serverThread.Abort()
        End If

        ClientList.Items.Clear()

        ServerListener.Close()

    End Sub

    Private Sub ClientRemove(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim SenderSplit() As String = Split(sender.ToString, ":")
        Dim ClientIP As String = Replace(SenderSplit(1), "{", "")
        Dim ClientPort As String = Replace(SenderSplit(2), "}", "")

        Dim abc As ListViewItem = ClientList.FindItemWithText(Trim(ClientIP) & ":" & Trim(ClientPort))

        If Not abc Is Nothing Then
            ClientList.Items(abc.Index).Remove()
        End If

    End Sub

    Private Sub ClientList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        ServerStop()

    End Sub

    Private Sub ClientJoin(ByVal sender As System.Object, ByVal e As EventArgs)

        Dim senderSplit() As String = Split(sender.ToString, ":")
        Dim ClientIP As String = Replace(senderSplit(1), "{", "")
        Dim ClientPort As Integer = Replace(senderSplit(2), "}", "")
        Dim Line As String = ""
        Dim LineCode As String = ""

        ClientList.Items.Add(sender)
        ClientList.Items(ClientList.Items.Count - 1).SubItems.Add(Format(Now, "yyyy-MM-dd HH:mm:ss"))
        ClientList.Items(ClientList.Items.Count - 1).SubItems.Add(Line)
        ClientList.Items(ClientList.Items.Count - 1).SubItems.Add(LineCode)
        ClientList.Items(ClientList.Items.Count - 1).SubItems.Add("Connected")

    End Sub

    '### : 메세지 수신
    Private Sub ClientData(ByVal sender As System.Object, ByVal e As EventArgs)

        Dim msgSplit() As String = Split(sender.ToString, "||")

        If UBound(msgSplit) = 0 Then Exit Sub

        Dim DIO As Integer

        For i = 0 To ClientList.Items.Count - 1 '수신된 IP를 찾는다.
            Dim ListIP() As String = Split(ClientList.Items(i).Text, ":")
            If Trim(ListIP(0)) = Trim(msgSplit(0)) Then
                DIO = i
                Exit For
            End If
        Next

        '수신 메세지 저장
        MessageList.Items.Add(MessageList.Items.Count + 1)
        MessageList.Items(MessageList.Items.Count - 1).SubItems.Add(Format(Now, "yyyy-MM-dd HH:mm:ss"))
        MessageList.Items(MessageList.Items.Count - 1).SubItems.Add(msgSplit(0))
        MessageList.Items(MessageList.Items.Count - 1).SubItems.Add(Replace(sender.ToString, msgSplit(0) & "||", ""))
        MessageList.EnsureVisible(MessageList.Items.Count - 1)

        If Trim(msgSplit(1)).ToUpper = "MyID".ToUpper Then '자재교체에서 전송된거라면..
            For i = 0 To ClientList.Items.Count - 1 '수신된 IP를 찾는다.
                'Dim ListIP() As String = Split(ClientList.Items(i).Text, ":")
                'If Trim(ListIP(0)) = Trim(msgSplit(0)) Then
                '    ClientList.Items(i).SubItems(2).Text = msgSplit(2)
                '    Exit For
                'End If
                If ClientList.Items(i).Text = msgSplit(3) Then
                    ClientList.Items(i).SubItems(2).Text = msgSplit(2)
                    Exit For
                End If
            Next
        End If

    End Sub

    '### : 수신응답
    Private Sub ClientResponse(ByVal sender As System.Object, ByVal e As EventArgs)

        'Dim msgSplit() As String = Split(sender.ToString, "||")

        For i = 0 To ClientList.Items.Count - 1 '수신된 IP를 찾는다.
            'Dim ListIP() As String = Split(ClientList.Items(i).Text, ":")
            'If Trim(ListIP(0)) = sender.ToString Then
            '    ClientList.Items(i).SubItems(4).Text = "Connected"
            '    Exit For
            'End If
            If ClientList.Items(i).Text = sender.ToString Then
                ClientList.Items(i).SubItems(4).Text = "Connected"
                Exit For
            End If
        Next

    End Sub

    Private Sub ServerMSGListAdd(ByVal MSGString As String)

        MessageList.Items.Add(MessageList.Items.Count + 1)
        MessageList.Items(MessageList.Items.Count - 1).SubItems.Add(Format(Now, "yyyy-MM-dd HH:mm:ss"))
        MessageList.Items(MessageList.Items.Count - 1).SubItems.Add("Server")
        MessageList.Items(MessageList.Items.Count - 1).SubItems.Add(MSGString)
        MessageList.EnsureVisible(MessageList.Items.Count - 1)

    End Sub

    '접속확인 횟수
    Dim Recheck As Integer = registryEdit.ReadRegKey("Software\Yujin\Message_Server", "ReCheck", 1)
    Dim CheckingCount As Integer

    Private Sub ClientCheckingTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientCheckingTimer.Tick

        ClientCheckingTimer.Enabled = False

        ClientCheckingTimer.Interval = registryEdit.ReadRegKey("Software\Yujin\Message_Server", "Check Time", 10) * 1000
        'Console.WriteLine("Client Checking : Start")
        For i = 0 To ClientList.Items.Count - 1
            ClientList.Items(i).SubItems(4).Text = "Disconnected"
            Send(ClientList.Items(i).Tag, Chr(17) & Chr(4) & Chr(0) & Chr(0) & Chr(1) & Chr(0) & Chr(0) & Chr(0) &
            Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(1) & Chr(1) & Chr(0) & Chr(0) &
            Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) &
            Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(14) & Chr(0) & Chr(0) & Chr(0) &
            Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) &
            Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0))
            ServerMSGListAdd(ClientList.Items(i).SubItems(0).Text & " Alive Check Send.")
        Next
        'Console.WriteLine("Client Checking : Stop")
        CheckingCount = CheckingCount + 1

        ClientRemoveTimer.Enabled = True

    End Sub

    Private Sub ClientRemoveTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientRemoveTimer.Tick

        ClientRemoveTimer.Enabled = False

        If Not CheckingCount = Recheck Then
            ClientCheckingTimer_Tick(Nothing, Nothing)
            Exit Sub
        Else
            CheckingCount = 0
        End If
        'Console.WriteLine("Client Delete : Start, " & ClientList.Items.Count)
        'On Error Resume Next '어차피 삭제 목록이니까 오류나도 괜찮
        For i = ClientList.Items.Count - 1 To 0 Step -1
            Dim abc As ListViewItem = ClientList.FindItemWithText("Disconnected")
            If Not abc Is Nothing Then
                Dim DeleteClient As Socket = ClientList.Items(abc.Index).Tag
                DeleteClient.Shutdown(SocketShutdown.Both)
                DeleteClient.Close()
                ServerMSGListAdd(ClientList.Items(i).SubItems(0).Text & " Alive Check NG. Delete Completed.")
                ClientList.Items.Remove(abc)
            End If
        Next
        'Console.WriteLine("Client Delete : Stop")
        ClientCheckingTimer.Enabled = True

    End Sub

    Private Sub MainForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        AlarmListPanel.Width = Me.Width - 657
        AlarmList.Width = Me.Width - 657
        AlarmList.Columns(3).Width = AlarmList.Width - (AlarmList.Columns(0).Width + AlarmList.Columns(1).Width + AlarmList.Columns(2).Width) - 20
        MessageListPanel.Width = Me.Width - 15
        MessageList.Width = Me.Width - 15
        MessageList.Columns(3).Width = MessageList.Width - (MessageList.Columns(0).Width + MessageList.Columns(1).Width + MessageList.Columns(2).Width) - 20
        MessageList.Height = Me.Height - 355
        ButtonPanel.Width = Me.Width - 15
        ButtonPanel.Top = MessageList.Top + MessageList.Height

        If Me.WindowState = FormWindowState.Maximized Then
            Me.Visible = True
            mnMinimum.Text = "최소화"
        ElseIf Me.WindowState = FormWindowState.Minimized Then
            Me.Visible = False
            mnMinimum.Text = "최대화"
        End If

    End Sub

    Private Sub btnSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetting.Click

        If Not Setting.Visible Then Setting.Show()
        Setting.Focus()

    End Sub

    Public Sub RestartServer()

        ClientRemoveTimer.Enabled = False
        ClientCheckingTimer.Enabled = False

        'Restart Message 전송
        For i = 0 To ClientList.Items.Count - 1
            If ClientList.Items(i).SubItems(4).Text = "Connected" Then
                Dim abc As Socket = ClientList.Items(i).Tag
                Send(abc, "Server Restart")
            End If
        Next

        For i = 0 To ClientList.Items.Count - 1
            If ClientList.Items(i).SubItems(4).Text = "Connected" Then
                Dim abc As Socket = ClientList.Items(i).Tag
                abc.Shutdown(SocketShutdown.Both)
                abc.Close()
            End If
        Next

        If serverThread.IsAlive Then
            serverThread.Abort()
        End If

        ClientList.Items.Clear()

        ServerListener.Close()

        Thread.Sleep(3000) '틈을 주기위해 잠시 멈췄다가..

        ServerStart()

        ClientCheckingTimer.Enabled = True

    End Sub

    Private Sub btnAlarmClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlarmClear.Click

        AlarmList.Items.Clear()

    End Sub

    Private Sub btnMessageClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMessageClear.Click

        MessageList.Items.Clear()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        Me.Dispose()

    End Sub

    Private Sub mnMinimum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnMinimum.Click

        If mnMinimum.Text = "최소화" Then
            mnMinimum.Text = "최대화"
            Me.Visible = False
        ElseIf mnMinimum.Text = "최대화" Then
            mnMinimum.Text = "최소화"
            Me.Visible = True
            Me.TopLevel = True
        End If

    End Sub

    Private Sub mnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnExit.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        For i = 0 To ClientList.Items.Count - 1
            Send(ClientList.Items(i).Tag, "Update Alarm")
            ServerMSGListAdd(ClientList.Items(i).SubItems(0).Text & " Update Alarm Send.")
        Next

    End Sub

    Dim pg_ver As String = String.Empty

    Private Sub VER_OPEN()

        '현재 프로그램의 버전을 기록하기 위함.
        pg_ver = String.Empty

        Dim ReadOk As Integer
        Dim openFileDialog1 As New OpenFileDialog
        '새로운파일버젼 확인
        openFileDialog1.FileName = Application.StartupPath & "\CheckVer.ini"

        Dim fs As System.IO.FileStream
        Dim sr As System.IO.StreamReader
        fs = System.IO.File.Open(openFileDialog1.FileName, IO.FileMode.Open) ' 파일 열기
        sr = New System.IO.StreamReader(fs) ' 스트림리더에 연결

        Dim str As String
        Dim NewVer() As String

        'While sr.EndOfStream <> False ' 끝까지 읽기
        While sr.Peek() >= 0
            str = sr.ReadLine() ' 한줄씩 읽기
            If str = "[AUTO UPDATE]" Then ReadOk = 1 '파일읽기 시작
            If str = "[/]" Then ReadOk = 0 '파일읽기 종료

            NewVer = Split(str, "=")

            If ReadOk = 1 And NewVer.Length > 1 Then '읽시 시작이 Ok면
                If pg_ver = String.Empty Then
                    '파일명,폴더명,버전
                    pg_ver = NewVer(0) & "::" & NewVer(2) & "::" & NewVer(1)
                Else
                    '파일명,폴더명,버전
                    pg_ver += "//" & NewVer(0) & "::" & NewVer(2) & "::" & NewVer(1)
                End If
                'Console.WriteLine(pg_ver)
            End If
        End While
        sr.Close()

    End Sub

    Private Sub RealCheck()

        VER_OPEN()
        Console.WriteLine("PC에 저장된 버전 파일을 열었습니다.")

        If DBConnect() = False Then Exit Sub

        Dim strSql As String = "select file_name, folder_name, upload_date from tb_execute_file_update_manager order by folder_name, file_code"

        Dim sqlCmd As New MySqlCommand(strSql, DBConnect1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader
        Dim module_name As String = String.Empty

        Console.WriteLine("버전 비교가 시작되었습니다.")
        Do While sqlDR.Read
            Dim pg_ver2() As String = Split(pg_ver, "//")
            Dim name_find As Boolean = False
            For i = 0 To UBound(pg_ver2)
                Dim pg_ver3() As String = Split(pg_ver2(i), "::") '::로 분할하여 업데이트 시간이 동일한지 검사
                If pg_ver3(0) = sqlDR("file_name") Then '파일명이 동일하다면
                    'Console.WriteLine(pg_ver3(2) = Format(sqlDR("upload_date"), "yyyy-MM-dd HH:mm:ss"))
                    If Not pg_ver3(2) = Format(sqlDR("upload_date"), "yyyy-MM-dd HH:mm:ss") Then
                        '업데이트 시간이 동일하지 않다면...
                        If module_name = String.Empty Then
                            module_name = pg_ver3(0)
                        Else
                            module_name += vbCrLf & "               " & pg_ver3(0)
                        End If
                    End If
                    name_find = True
                    Exit For
                End If
            Next
            If name_find = False Then
                If module_name = String.Empty Then
                    module_name = sqlDR("file_name")
                Else
                    module_name += vbCrLf & "               " & sqlDR("FILE_NAME")
                End If
            End If
        Loop
        DBClose()
        Console.WriteLine("버전 비교가 종료 되었습니다.")

        If Not module_name = String.Empty Then
            Console.WriteLine("업데이트된 내용 : " & module_name)
            For i = 0 To ClientList.Items.Count - 1
                Send(ClientList.Items(i).Tag, "Update Alarm")
                ServerMSGListAdd(ClientList.Items(i).SubItems(0).Text & " Update Alarm Send.")
            Next
            CheckVerDownload(ftpUrl & "/Run_File/", "NEWCheckVer.ini", True)
            Console.WriteLine("신규 체크버전 파일을 다운로드 합니다.")
        End If

    End Sub

    '************************* FTP 서버내 Ver. CheckFile 다운로드 ***************************
    Private Sub CheckVerDownload(ByVal ftpURL As String, ByVal FileName As String, ByVal RunContinue As Boolean)

        Dim localPath_download As String = Application.StartupPath & "\" '다운로드 받을 경로

        'While fileName IsNot Nothing '무조건 다운로드할때 이걸써라.(항목수 상관없이)
        Dim requestFileDelete As FtpWebRequest = Nothing
        Dim responseFileDelete As FtpWebResponse = Nothing

        Dim requestFileDownload As FtpWebRequest = Nothing
        Dim responseFileDownload As FtpWebResponse = Nothing

        '파일존재여부 확인
        'If My.Computer.FileSystem.FileExists(localPath_download & "\" & fileName) Then
        '    Try
        '        Kill(localPath_download & "\" & fileName)
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, Loginsite_Hangul)
        '    End Try
        'End If

        Try
            'Console.WriteLine(fileName)

            requestFileDownload = DirectCast(WebRequest.Create(ftpURL & FileName), FtpWebRequest)
            requestFileDownload.Credentials = New NetworkCredential(ftpID, ftpPassword)
            requestFileDownload.Method = WebRequestMethods.Ftp.DownloadFile
            requestFileDownload.UsePassive = True
            requestFileDownload.KeepAlive = False
            requestFileDownload.UseBinary = False
            responseFileDownload = DirectCast(requestFileDownload.GetResponse(), FtpWebResponse)

            Dim responseStream As Stream = responseFileDownload.GetResponseStream()
            Dim writeStream As New FileStream(localPath_download & FileName, FileMode.Create)
            Dim Length As Integer = 2048
            Dim buffer As [Byte]() = New [Byte](Length - 1) {}
            Dim bytesRead As Integer = responseStream.Read(buffer, 0, Length)

            '#####파일의 크기를 알아보기 위해...#####
            Dim requestFileSize As FtpWebRequest = Nothing
            requestFileSize = DirectCast(WebRequest.Create(ftpURL & "/" & FileName), FtpWebRequest)
            requestFileSize.Credentials = New NetworkCredential(ftpID, ftpPassword)
            requestFileSize.Method = WebRequestMethods.Ftp.GetFileSize
            requestFileSize = Nothing

            While bytesRead > 0
                writeStream.Write(buffer, 0, bytesRead)
                bytesRead = responseStream.Read(buffer, 0, Length)
            End While
            writeStream.Close()

        Catch exceptionObj As Exception
            MsgBox(exceptionObj.Message.ToString())
        Finally
            responseFileDelete = Nothing
            requestFileDelete = Nothing

            requestFileDownload = Nothing
            responseFileDownload = Nothing
        End Try

        'End While

        '############################  파일다운로드 관련부분 #########################################################

        Dim oldFile As String = Application.StartupPath & "\CheckVer.ini"
        Dim newFile As String = Application.StartupPath & "\NEWCheckVer.ini"
        File.Delete(oldFile)
        FileSystem.Rename(newFile, oldFile)
        File.Delete(newFile)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If UBound(Diagnostics.Process.GetProcessesByName("Update Checker")) = 0 Then
            'UpdateChecker가 켜져 있다면 종료
            Dim ucProcess() As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessesByName("Update Checker")
            If ucProcess.Length > 0 Then
                ucProcess(0).Kill()
            End If
        End If

        If MessageList.Items.Count > NumericUpDown1.Value Then
            MessageList.Items.Clear()
        End If

        RealCheck()

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged

        registryEdit.WriteRegKey("Software\Yujin\Message_Server", "Message AutoClean Count", NumericUpDown1.Value)

    End Sub
End Class

Public Class StateObject

    ' Client  socket.
    Public workSocket As Socket = Nothing
    Public Const BufferSize As Integer = 1024
    Public buffer(BufferSize) As Byte
    Public sb As New StringBuilder

End Class 'StateObject