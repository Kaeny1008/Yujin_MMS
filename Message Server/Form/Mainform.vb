Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Text

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
    Private ipHostInfo As IPHostEntry = Dns.Resolve(Dns.GetHostName())
    Private ipAddress As IPAddress = ipHostInfo.AddressList(0)

    Private Sub ServerStart()

        'CheckForIllegalCrossThreadCalls = False
        serverThread = New Thread(New ThreadStart(AddressOf StartListening))
        serverThread.IsBackground = True
        serverThread.Start()

    End Sub

    Private Sub StartListening()

        ServerListener = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

        Dim Port As Integer = registryEdit.ReadRegKey("Software\Yujin\Message_Server\Setting", "Socket Port", 10522)
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
                    BeginInvoke(New EventHandler(AddressOf ClientResponse), aaa.Address.ToString & "||" & content) '응답내용 전송
                ElseIf content = "Client Connect" Then
                    'MsgBox("client ok")
                    Send(handler, "Server Accept")
                    Send(handler, "Server Accept")
                Else
                    If Asc(content.Substring(0, 1)) > 31 Then 'ascii 32이하면 응답부분이므로 무시
                        BeginInvoke(New EventHandler(AddressOf ClientData), aaa.Address.ToString & "||" & content) '수신내용 전송
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

    Private Sub ClientList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Text = "Message Server : " & My.Application.Info.Version.ToString

        ServerStart()

        ClientCheckingTimer.Enabled = False
        ClientCheckingTimer.Interval = registryEdit.ReadRegKey("Software\Yujin\Message_Server\Setting", "Check Time", 10) * 1000
        ClientRemoveTimer.Enabled = False
        ClientRemoveTimer.Interval = 5000

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
        Dim Line As String = "E"
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

        If Trim(msgSplit(1)).ToUpper = "PartsChange".ToUpper Then '자재교체에서 전송된거라면..
            'If Trim(Trim(msgSplit(2))).ToUpper = "PGNo".ToUpper Then 'Partno를 찾는 것이라면..
            '    PartNoSearch(Trim(msgSplit(3)), Trim(msgSplit(4)), Trim(msgSplit(5)), DIO)
            'ElseIf Trim(Trim(msgSplit(2))).ToUpper = "PONo".ToUpper Then 'Rank를 찾는 것이라면..
            '    RankSearch(Trim(msgSplit(3)), Trim(msgSplit(4)), Trim(msgSplit(5)), DIO)
            'ElseIf Trim(Trim(msgSplit(2))).ToUpper = "Parts Change".ToUpper Then '자재교체
            '    MisMountReCheck(sender.ToString)
            'ElseIf Trim(Trim(msgSplit(2))).ToUpper = "Parts Change2".ToUpper Then '자재교체 신규
            '    NewMisMountReCheck(sender.ToString)
            'ElseIf Trim(msgSplit(2)).ToUpper = "Alarm Stop".ToUpper Then '알람해제 이면
            '    If Trim(msgSplit(7)).ToUpper = "Not Save".ToUpper Then
            '        AlarmStopMSG(Trim(msgSplit(3)), Trim(msgSplit(4)), Trim(msgSplit(5)), DIO, Trim(msgSplit(6)), "PartsChange", True)
            '    Else
            '        AlarmStopMSG(Trim(msgSplit(3)), Trim(msgSplit(4)), Trim(msgSplit(5)), DIO, Trim(msgSplit(6)), "PartsChange", False)
            '    End If
            'End If
        End If

    End Sub

    '### : 수신응답
    Private Sub ClientResponse(ByVal sender As System.Object, ByVal e As EventArgs)

        Dim msgSplit() As String = Split(sender.ToString, "||")

        For i = 0 To ClientList.Items.Count - 1 '수신된 IP를 찾는다.
            Dim ListIP() As String = Split(ClientList.Items(i).Text, ":")
            If Trim(ListIP(0)) = Trim(msgSplit(0)) Then
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

    End Sub

    '접속확인 횟수
    Dim Recheck As Integer = registryEdit.ReadRegKey("Software\Yujin\Message_Server\Setting", "ReCheck", 1)
    Dim CheckingCount As Integer

    Private Sub ClientCheckingTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientCheckingTimer.Tick

        ClientCheckingTimer.Enabled = False

        ClientCheckingTimer.Interval = registryEdit.ReadRegKey("Software\Yujin\Message_Server\Setting", "Check Time", 10) * 1000
        'Console.WriteLine("Client Checking : Start")
        For i = 0 To ClientList.Items.Count - 1
            ClientList.Items(i).SubItems(4).Text = "Disconnected"
            Send(ClientList.Items(i).Tag, Chr(17) & Chr(4) & Chr(0) & Chr(0) & Chr(1) & Chr(0) & Chr(0) & Chr(0) & _
            Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(1) & Chr(1) & Chr(0) & Chr(0) & _
            Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & _
            Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(14) & Chr(0) & Chr(0) & Chr(0) & _
            Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & _
            Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0) & Chr(0))
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
        For i = 0 To ClientList.Items.Count - 1
            Dim abc As ListViewItem = ClientList.FindItemWithText("Disconnected")
            If Not abc Is Nothing Then
                Dim DeleteClient As Socket = ClientList.Items(abc.Index).Tag
                DeleteClient.Shutdown(SocketShutdown.Both)
                DeleteClient.Close()
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
End Class

Public Class StateObject

    ' Client  socket.
    Public workSocket As Socket = Nothing
    Public Const BufferSize As Integer = 1024
    Public buffer(BufferSize) As Byte
    Public sb As New StringBuilder

End Class 'StateObject