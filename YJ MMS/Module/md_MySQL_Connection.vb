Imports MySql.Data.MySqlClient

Module md_MySQL_Connection

    Public registryEdit As New RegistryEdit.RegReadWrite '레지스트리 편집
    Public dbConnection1 As MySqlConnection
    Public mdbConnection1 As OleDb.OleDbConnection

    Public serverIP As String = registryEdit.ReadRegKey("Software\Yujin", "server.IP", "125.137.78.158")
    Public serverPORT As String = registryEdit.ReadRegKey("Software\Yujin", "server.PORT", 10522)
    Public serverID As String = registryEdit.ReadRegKey("Software\Yujin", "server.ID", "yujin_MySQL")
    Public serverPSWD As String = registryEdit.ReadRegKey("Software\Yujin", "server.PSWD", "Dbwlswjswk1!")
    Public connectionTimeOut As String = registryEdit.ReadRegKey("Software\Yujin", "ConnectionTimeOut", 5)
    Public dbName As String = registryEdit.ReadRegKey("Software\Yujin", "dbName", "yj_mms")

    Public messageIP As String = registryEdit.ReadRegKey("Software\Yujin", "MessageServer.IP", "125.137.78.158")
    Public messagePort As Integer = registryEdit.ReadRegKey("Software\Yujin", "MessageServer.Port", 10521)

    'DB 연결 함수
    Public Function DBConnect() As Boolean

        Dim returnValue As Boolean = True

        dbConnection1 = New MySqlConnection
        'dbConnection1.ConnectionString = "Database=" & dbName &
        '                                 ";Data Source=" & serverIP &
        '                                 ";PORT=" & serverPORT &
        '                                 ";User Id=" & serverID &
        '                                 ";Password=" & serverPSWD &
        '                                 ";Connection Timeout=" & connectionTimeOut &
        '                                 ";SSLMode=None"

        dbConnection1.ConnectionString = "Database=" & dbName &
                                         ";Data Source=" & serverIP &
                                         ";PORT=" & serverPORT &
                                         ";User Id=" & serverID &
                                         ";Password=" & serverPSWD &
                                         ";Connection Timeout=" & connectionTimeOut &
                                         ";CharSet=utf8" &
                                         ";sslmode=Required" &
                                         ";certificatefile=" & Application.StartupPath & "\mysql_ca-cert.pem"
        Try
            dbConnection1.Open()
            'DBConnect1 연결되어있지 않다면
            'If Not DBConnect1.State = ConnectionState.Open Then
            '        MessageBox.Show("DB 연결 실패", "DB 테스트", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
            'Dim strSql As String = "SET Names euckr;"
            'Dim strsQL As String = "show status like 'Ssl_version';"
            'Dim sqlCmd As New MySqlCommand(strsQL, dbConnection1)

            'Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

            'Do While sqlDR.Read
            '    Console.WriteLine("SSL 접속여부(SSL Version) : " & sqlDR("value"))
            'Loop
            'sqlDR.Close()
        Catch ex As Exception
            returnValue = False
            Thread_LoadingFormEnd()
            MessageBox.Show(ex.Message, "Server Connection", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return returnValue

    End Function

    'DB 종료 함수
    Public Sub DBClose()

        If dbConnection1.State = ConnectionState.Open Then
            dbConnection1.Close()
            dbConnection1.Dispose()
        End If

    End Sub
End Module

