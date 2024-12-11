Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class frm_Main

#Region "소켓접속"

    Dim ReConnect As Boolean
    Public registryEdit As New RegistryEdit.RegReadWrite '레지스트리 편집
    'the socket we will be using
    Dim clientSocket As Socket
    Dim byteData(1023) As Byte
    Dim ServerIP As String = registryEdit.ReadRegKey("Software\Yujin", "server.IP", "125.137.78.158")
    Dim ServerPort As Integer = registryEdit.ReadRegKey("Software\Yujin", "MessageServer.Port", "10521")
    Dim loginID As String = registryEdit.ReadRegKey("Software\Yujin\Login", "User ID", "user")

    Private Sub ServerConnect()

        BeginInvoke(New EventHandler(AddressOf ConnectStatus), "Update Checker : Connecting...")
        'create a new socket
        clientSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        'the ip we are connecting to will be our own
        Dim ipAddress As IPAddress = IPAddress.Parse(ServerIP)
        'create an endpoint this time telling it
        'the IP to look for.
        Dim ipEndPoint As IPEndPoint = New IPEndPoint(ipAddress, ServerPort)
        'try to connect
        clientSocket.BeginConnect(ipEndPoint, New AsyncCallback(AddressOf OnConnect), Nothing)

    End Sub

    Private Sub OnConnect(ByVal ar As IAsyncResult)

        'once connected stop trying and begin listening for data
        Try
            clientSocket.EndConnect(ar)
            clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, New AsyncCallback(AddressOf OnRecieve), clientSocket)
            'Send("Client Connect", clientSocket)
            ReConnect = False
        Catch ex As ObjectDisposedException
            ReConnect = True '재접속 신호 On
            MsgBox("Socket Release : " & ex.Message, MsgBoxStyle.OkOnly, "Connection Error" & vbCrLf & ex.Message)
        Catch ex As Exception
            ReConnect = True '재접속 신호 On
            Try
                BeginInvoke(New EventHandler(AddressOf ConnectStatus), "Connection Error" & vbCrLf & ex.Message)
            Catch
                '에러 났을때 처리하는건데.. 그냥 무시...
            End Try
            'MsgBox("서버 접속 오류" & vbCrLf & "메세지 서버를 확인하여 주십시오.", MsgBoxStyle.OkOnly, "소켓접속 오류")
        End Try

    End Sub

    Private Sub OnRecieve(ByVal ar As IAsyncResult)

        'once data is recieved create a temp socket
        'to use while getting the data.
        Dim client As Socket = ar.AsyncState

        Try
            'stop receiveing on the clientsocket
            Dim byteRead As Integer = client.EndReceive(ar)
            'swap bytes into a new array
            Dim bytesRec As Byte() = byteData
            'get the string representation
            Dim message As String = Encoding.ASCII.GetString(bytesRec, 0, byteRead)
            'send message to sub to do work
            If message = "Server Accept" Then
                'Send("Connection Check OK.", clientSocket)
                'BeginInvoke(New EventHandler(AddressOf ConnectStatus), "!! Parts Check Time compliance !!")
                BeginInvoke(New EventHandler(AddressOf ConnectStatus), "Update Checker : Server Connect OK")
                Send("MyID||" & loginID, clientSocket)
            Else
                Read(message)
            End If
            'start recieving again
            clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, New AsyncCallback(AddressOf OnRecieve), clientSocket)
        Catch ex As ObjectDisposedException
            'MsgBox(ex.Message, MsgBoxStyle.Information, "Parts Change1")
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information, "Parts Change")
            ReConnect = True
            BeginInvoke(New EventHandler(AddressOf ConnectStatus), "Connection Error")
        End Try

    End Sub

    Dim lastAliveCheck As DateTime

    Private Sub Read(ByVal msg As String)

        If Trim(msg) = "" Then Exit Sub
        Dim msgSplit() As String = Split(msg, "||")
        If msg.Substring(0, 1) = Chr(17) Then
            '응답확인부분이라면
            lastAliveCheck = Now
            BeginInvoke(New EventHandler(AddressOf Timer2_Enable))
            Console.WriteLine("Update Checker : Live Check Received.")
            Console.WriteLine("Update Checker : Live Check Send.")
            Send("Connection Check OK.", clientSocket)
            Send(Chr(18) & Chr(4), clientSocket)
        Else
            BeginInvoke(New EventHandler(AddressOf ReadData), msg)
        End If

    End Sub

    '===========================메세지 전송 부분==================================
    Private Sub Send(ByVal msg As String, ByVal client As Socket)

        Dim sendBytes As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(msg)

        clientSocket.BeginSend(sendBytes, 0, sendBytes.Length, SocketFlags.None, New AsyncCallback(AddressOf OnSend), clientSocket)

    End Sub

    Private Sub OnSend(ByVal ar As IAsyncResult)

        'create a temp socket to use for our client
        Dim client As Socket = ar.AsyncState

        Try
            client.EndSend(ar)
        Catch ex As SocketException
            ConnectClose()
            ReConnect = True
            BeginInvoke(New EventHandler(AddressOf ConnectStatus), "Connection Error")
            'MsgBox(ex.Message, MsgBoxStyle.Information, "메세지 전송 오류")
        End Try

    End Sub

    Private Sub msg_sender(ByVal msgString As String)

        Send(msgString, clientSocket)

    End Sub

    Private Sub ConnectClose()

        If clientSocket.Connected Then
            clientSocket.Shutdown(SocketShutdown.Both)
            clientSocket.Close()
        End If

    End Sub

    Private Sub ConnectStatus(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'lbStatus.Text = sender.ToString
        Console.WriteLine(sender.ToString)

    End Sub
#End Region

    Private Sub ReadData(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim msgSplit() As String = Split(sender.ToString, "||")

        If msgSplit(0).ToUpper = "Server Restart".ToUpper Then
            ConnectClose()
            ReConnect = True
            'lbStatus.Text = "Connection closed"
            Console.WriteLine("Update Checker : Server Restart Received. Connection closed.")
        ElseIf msgSplit(0).ToUpper = "Server Stop".ToUpper Then
            ConnectClose()
            ReConnect = True
            'lbStatus.Text = "Connection closed"
            Console.WriteLine("Update Checker : Server Stop Received. Connection closed.")
        ElseIf msgSplit(0).ToUpper = "Update Alarm".ToUpper Then
            Console.WriteLine("Update Checker : Update Alarm Received.")
            MessageBox.Show(New Form() With {.TopMost = True},
                            "프로그램 업데이트가 있습니다." & vbCrLf &
                            "업데이트 하지 않고 사용시 심각한 오류가 발생할 수 있습니다." & vbCrLf &
                            "확인 버튼을 눌러 프로그램을 업데이트 하십시오.",
                            "Update Checker",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            Try
                Dim myProgram As String = "ERP Update, YJ Login, Repair System, YJ MMS, YJ MMS MMPS, Message Server"
                Dim myProgram2() As String = Split(myProgram, ", ")
                For i = 0 To UBound(myProgram2)
                    Dim pcProcess() As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessesByName(myProgram2(i))
                    If pcProcess.Length > 0 Then
                        pcProcess(0).Kill()
                    End If
                Next
                'Shell(Application.StartupPath & "\ERP Update.exe")
                'Shell(Application.StartupPath & "\ERP Update.exe", AppWinStyle.NormalFocus)
                CreateObject("WScript.Shell").Run(Chr(34) & Application.StartupPath & "\ERP Update.exe" & Chr(34), True)
                Me.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message & vbCrLf & Application.StartupPath & "\ERP Update.exe", MsgBoxStyle.Critical, "Update Checker")
                Me.Dispose()
            End Try
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Hide()
        Me.Visible = False
        Me.Opacity = 0

        Timer1.Interval = 10000
        Timer1.Enabled = True

        ServerConnect() '서버접속

    End Sub

    Private Sub frm_Main_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

        ConnectClose()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        '어차피 Timer2가 재연결 시도를 한다.
        'If ReConnect = True Then
        '    ServerConnect()
        'End If

    End Sub

    Private Sub Timer2_Enable(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Timer2.Interval = 10000
        Timer2.Enabled = True

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'Console.WriteLine("Update Check 최종 확인 시간 : " & (DateAdd(DateInterval.Second, 65, lastAliveCheck)))
        If DateAdd(DateInterval.Second, 65, lastAliveCheck) < Now Then
            Console.WriteLine("Update Check : 마지막 연결 확인 시간보다 65초가 지났지만 신규 확인이 없으므로 재연결 합니다.")
            ServerConnect()
        End If

    End Sub

    'Dim pg_ver As String = String.Empty
    'Dim form_msgbox_string As String = "Update Checker"
    'Dim update_check_time As Integer = CInt(registryEdit.ReadRegKey("Software\Yujin", "Update Check", 10000))

    'Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    '    'VER_OPEN()
    '    '이게 왜 있지? 241129 주석처리

    '    Timer1.Interval = 1000
    '    Timer1.Enabled = True
    '    Timer2.Interval = update_check_time
    '    Timer2.Enabled = True
    '    Timer3.Interval = 60000
    '    Timer3.Enabled = True

    '    Me.Hide()
    '    Me.Visible = False
    '    Me.Opacity = 0

    'End Sub

    'Private Sub VER_OPEN()

    '    '현재 프로그램의 버전을 기록하기 위함.
    '    pg_ver = String.Empty

    '    Dim ReadOk As Integer
    '    Dim openFileDialog1 As New OpenFileDialog
    '    '새로운파일버젼 확인
    '    openFileDialog1.FileName = Application.StartupPath & "\CheckVer.ini"

    '    Dim fs As System.IO.FileStream
    '    Dim sr As System.IO.StreamReader
    '    fs = System.IO.File.Open(openFileDialog1.FileName, IO.FileMode.Open) ' 파일 열기
    '    sr = New System.IO.StreamReader(fs) ' 스트림리더에 연결

    '    Dim str As String
    '    Dim NewVer() As String

    '    'While sr.EndOfStream <> False ' 끝까지 읽기
    '    While sr.Peek() >= 0
    '        str = sr.ReadLine() ' 한줄씩 읽기
    '        If str = "[AUTO UPDATE]" Then ReadOk = 1 '파일읽기 시작
    '        If str = "[/]" Then ReadOk = 0 '파일읽기 종료

    '        NewVer = Split(str, "=")

    '        If ReadOk = 1 And NewVer.Length > 1 Then '읽시 시작이 Ok면
    '            If pg_ver = String.Empty Then
    '                '파일명,폴더명,버전
    '                pg_ver = NewVer(0) & "::" & NewVer(2) & "::" & NewVer(1)
    '            Else
    '                '파일명,폴더명,버전
    '                pg_ver += "//" & NewVer(0) & "::" & NewVer(2) & "::" & NewVer(1)
    '            End If
    '            'Console.WriteLine(pg_ver)
    '        End If
    '    End While
    '    sr.Close()

    'End Sub

    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    '    If CDate(Format(Now, "yyyy-MM-dd HH:mm:ss")) > CDate(after_alarm) Then
    '        If next_alarm = True Then Timer2.Enabled = True
    '    End If

    'End Sub

    'Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

    '    RealCheck()

    'End Sub

    'Private Sub RealCheck()

    '    VER_OPEN()
    '    Console.WriteLine("PC에 저장된 버전 파일을 열었습니다.")

    '    '업데이트 체크 시간을 강제로 변경... 차후에 다시 돌려놓자
    '    '10초마다 체크는 비효율적일듯.
    '    'registryEdit.WriteRegKey("Software\Yujin\MMS", "Update Check", 60000)

    '    'PG_STATUS.Text = "Program Ver. 비교가 시작 되었습니다."

    '    If DBConnect() = False Then Exit Sub

    '    Dim strSql As String = "select file_name, folder_name, upload_date from tb_execute_file_update_manager order by folder_name, file_code"

    '    Dim sqlCmd As New MySqlCommand(strSql, DBConnect1)
    '    Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader
    '    Dim module_name As String = String.Empty

    '    Console.WriteLine("버전 비교가 시작되었습니다.")
    '    Do While sqlDR.Read
    '        Dim pg_ver2() As String = Split(pg_ver, "//")
    '        Dim name_find As Boolean = False
    '        For i = 0 To UBound(pg_ver2)
    '            Dim pg_ver3() As String = Split(pg_ver2(i), "::") '::로 분할하여 업데이트 시간이 동일한지 검사
    '            If pg_ver3(0) = sqlDR("file_name") Then '파일명이 동일하다면
    '                'Console.WriteLine(pg_ver3(2) = Format(sqlDR("upload_date"), "yyyy-MM-dd HH:mm:ss"))
    '                If Not pg_ver3(2) = Format(sqlDR("upload_date"), "yyyy-MM-dd HH:mm:ss") Then
    '                    '업데이트 시간이 동일하지 않다면...
    '                    If module_name = String.Empty Then
    '                        module_name = pg_ver3(0)
    '                    Else
    '                        module_name += vbCrLf & "               " & pg_ver3(0)
    '                    End If
    '                End If
    '                name_find = True
    '                Exit For
    '            End If
    '        Next
    '        If name_find = False Then
    '            If module_name = String.Empty Then
    '                module_name = sqlDR("file_name")
    '            Else
    '                module_name += vbCrLf & "               " & sqlDR("FILE_NAME")
    '            End If
    '        End If
    '    Loop
    '    DBClose()
    '    Console.WriteLine("버전 비교가 종료 되었습니다.")

    '    'PG_STATUS.Text = "Program Ver. 비교가 완료 되었습니다."

    '    If Not module_name = String.Empty Then
    '        Console.WriteLine("업데이트된 내용 : " & module_name)
    '        UPDATE_ALARM(module_name)
    '    End If

    'End Sub

    'Dim after_alarm As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
    'Dim next_alarm As Boolean = False

    'Private Sub UPDATE_ALARM(ByVal module_name As String)

    '    Timer2.Enabled = False
    '    next_alarm = False

    '    Dim message As String = "프로그램 업데이트가 있습니다." & vbCrLf &
    '                            "업데이트 하지 않고 사용시 심각한 오류가 발생할 수 있습니다." & vbCrLf &
    '                            "지금 업데이트 하시겠습니까?" & vbCrLf &
    '                            "(해당 모든 프로그램이 종료됩니다.)" & vbCrLf &
    '                            "File Name : " & module_name

    '    Using form = New Form() With {.TopMost = True} ' 최상위로 포커스
    '        If MessageBox.Show(form, message, form_msgbox_string, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
    '            after_alarm = Format(DateAdd(DateInterval.Hour, 1, Now), "yyyy-MM-dd HH:mm:ss")
    '            next_alarm = True '재알림을 방지하기 위해!!
    '            MsgBox("업데이트가 1시간 연장 되었습니다." & vbCrLf &
    '               "1시간 뒤 알람이 재발생합니다.", MsgBoxStyle.Information, form_msgbox_string)
    '        Else
    '            MsgBox("프로그램이 종료되고 업데이트가 실행 됩니다.", MsgBoxStyle.Information, form_msgbox_string)
    '            Try
    '                Dim myProgram As String = "ERP Update, YJ Login, Repair System, YJ MMS, YJ MMS MMPS"
    '                Dim myProgram2() As String = Split(myProgram, ", ")
    '                For i = 0 To UBound(myProgram2)
    '                    Dim pcProcess() As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessesByName(myProgram2(i))
    '                    If pcProcess.Length > 0 Then
    '                        pcProcess(0).Kill()
    '                    End If
    '                Next
    '                'Shell(Application.StartupPath & "\ERP Update.exe")
    '                'Shell(Application.StartupPath & "\ERP Update.exe", AppWinStyle.NormalFocus)
    '                CreateObject("WScript.Shell").Run(Chr(34) & Application.StartupPath & "\ERP Update.exe" & Chr(34), True)
    '                Me.Close()
    '            Catch ex As Exception
    '                MsgBox(ex.Message & vbCrLf & Application.StartupPath & "\ERP Update.exe", MsgBoxStyle.Critical, form_msgbox_string)
    '                Me.Dispose()
    '            End Try
    '        End If
    '    End Using

    '    'If MsgBox("프로그램 업데이트가 있습니다." & vbCrLf &
    '    '          "업데이트 하지 않고 사용시 심각한 오류가 발생할 수 있습니다." & vbCrLf &
    '    '          "지금 업데이트 하시겠습니까?" & vbCrLf &
    '    '          "(해당 모든 프로그램이 종료됩니다.)" & vbCrLf &
    '    '          "File Name : " & module_name, MsgBoxStyle.Question + MsgBoxStyle.YesNo, form_msgbox_string) = MsgBoxResult.No Then
    '    '    after_alarm = Format(DateAdd(DateInterval.Hour, 1, Now), "yyyy-MM-dd HH:mm:ss")
    '    '    next_alarm = True '재알림을 방지하기 위해!!
    '    '    MsgBox("업데이트가 1시간 연장 되었습니다." & vbCrLf &
    '    '           "1시간 뒤 알람이 재발생합니다.", MsgBoxStyle.Information, form_msgbox_string)
    '    'Else
    '    '    MsgBox("프로그램이 종료되고 업데이트가 실행 됩니다.", MsgBoxStyle.Information, form_msgbox_string)
    '    '    Try
    '    '        Dim myProgram As String = "YJ MMS, YJ MMS Asset, YJ MMS Label Printer, YJ MMS 3rd, YJ MMS MMPS, YJ MMS MMS"
    '    '        Dim myProgram2() As String = Split(myProgram, ", ")
    '    '        For i = 0 To UBound(myProgram2)
    '    '            Dim pcProcess() As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessesByName(myProgram2(i))
    '    '            If pcProcess.Length > 0 Then
    '    '                pcProcess(0).Kill()
    '    '            End If
    '    '        Next

    '    '        Shell(Application.StartupPath & "\ERP Update.exe")
    '    '        Me.Close()
    '    '    Catch ex As Exception
    '    '        MsgBox(ex.Message, MsgBoxStyle.Critical, form_msgbox_string)
    '    '    End Try
    '    'End If

    'End Sub

    'Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick

    '    Timer2.Interval = CInt(registryEdit.ReadRegKey("Software\Yujin", "Update Check", 10000))

    'End Sub
End Class
