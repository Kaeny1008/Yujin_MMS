Imports System.Data
Imports System.Net
Imports MySql.Data.MySqlClient

Module ServerConn

    Public registryEdit As New RegistryEdit.RegReadWrite '레지스트리 편집
    Public DBConnect1 As MySqlConnection

    Public serverIP As String = registryEdit.ReadRegKey("Software\Yujin", "server.IP", "125.137.78.158")
    Public serverPORT As String = registryEdit.ReadRegKey("Software\Yujin", "server.PORT", 10522)
    Public serverID As String = registryEdit.ReadRegKey("Software\Yujin", "server.ID", "yujin_MySQL")
    Public serverPSWD As String = registryEdit.ReadRegKey("Software\Yujin", "server.PSWD", "Dbwlswjswk1!")
    Public connectionTimeOut As String = registryEdit.ReadRegKey("Software\Yujin", "ConnectionTimeOut", 5)
    Public dbName As String = registryEdit.ReadRegKey("Software\Yujin", "dbName", "yj_mms")
    Public updateCheckTime As Integer = registryEdit.ReadRegKey("Software\Yujin\Message_Server", "Update Check Time", 60)
    Public httpUrl As String = "https://" & serverIP & ":" & registryEdit.ReadRegKey("Software\Yujin", "http.Port", 10523)
    Public httpPort As Integer = registryEdit.ReadRegKey("Software\Yujin", "http.Port", 10523)

    'Public ipHostInfo As IPHostEntry = Dns.Resolve(Dns.GetHostName())
    'Public ipAddress As IPAddress = ipHostInfo.AddressList(0)
    Public ipAddress As IPAddress = IPAddress.Parse(registryEdit.ReadRegKey("Software\Yujin\Message_Server", "my.IP", "192.168.0.173"))

    Public Function DBConnect() As Boolean

        Dim returnValue As Boolean = True

        DBConnect1 = New MySqlConnection

        DBConnect1.ConnectionString = "Database=" & dbName &
            ";Data Source=" & serverIP &
            ";PORT=" & serverPORT &
            ";User Id=" & serverID &
            ";Password=" & serverPSWD &
            ";Connection Timeout=" & connectionTimeOut &
            ";CharSet=utf8" &
            ";sslmode=Required" &
            ";certificatefile=" & Application.StartupPath & "\mysql_ca-cert.pem"

        Try
            DBConnect1.Open()
            'DBConnect1 연결되어있지 않다면
            'If Not DBConnect1.State = ConnectionState.Open Then
            '        MessageBox.Show("DB 연결 실패", "DB 테스트", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
            'Dim strSql As String = "SET Names euckr;"
            'Dim sqlCmd As New MySqlCommand(strSql, DBConnect1)
        Catch ex As Exception
            returnValue = False
            'MessageBox.Show(ex.Message, "Server Connection", MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Dim file As System.IO.StreamWriter
            'file = My.Computer.FileSystem.OpenTextFileWriter("c:\test.txt", True)
            'file.WriteLine("Here is the first string.")
            'file.Close()
            MainForm.ServerMSGListAdd("Error : DB Server Connection Fail.")
        End Try

        Return returnValue

    End Function

    'DB 종료 함수
    Public Sub DBClose()
        If DBConnect1.State = ConnectionState.Open Then
            DBConnect1.Close()
            DBConnect1.Dispose()
        End If
    End Sub

    Public Function TocharReplace(ByVal ReplaceData As String) As String

        ReplaceData = Format(CDate(ReplaceData), "yyyy-MM-dd HH:mm:ss")
        TocharReplace = "to_char('" & ReplaceData & "', 'yyyy-mm-dd hh24:mi:ss')"

        Return TocharReplace

    End Function

    Public Function TodateReplace(ByVal ReplaceData As String) As String

        ReplaceData = Format(CDate(ReplaceData), "yyyy-MM-dd HH:mm:ss")
        TodateReplace = "to_date('" & ReplaceData & "', 'yyyy-mm-dd hh24:mi:ss')"

        Return TodateReplace

    End Function
End Module
