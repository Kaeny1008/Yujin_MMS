'Imports MySql.Data.MySqlClient

'Module MySQL

'    Public registryEdit As New RegistryEdit.RegReadWrite '레지스트리 편집
'    Public DBConnect1 As MySqlConnection
'    Public serverIP As String = registryEdit.ReadRegKey("Software\Yujin", "Server.IP", "125.137.78.158")
'    Public serverPORT As String = registryEdit.ReadRegKey("Software\Yujin", "server.PORT", "10522")
'    Public serverID As String = registryEdit.ReadRegKey("Software\Yujin", "server.ID", "yujin_MySQL")
'    Public serverPSWD As String = registryEdit.ReadRegKey("Software\Yujin", "server.PSWD", "Dbwlswjswk1!")
'    Public dbName As String = registryEdit.ReadRegKey("Software\Yujin", "dbName", "yj_mms")
'    Public connectionTimeOut As String = registryEdit.ReadRegKey("Software\Yujin", "ConnectionTimeOut", 5)

'    'DB 연결 함수
'    Public Function DBConnect() As Boolean

'        Dim returnValue As Boolean = True

'        DBConnect1 = New MySqlConnection
'        DBConnect1.ConnectionString = "Database=" & dbName &
'                                       ";Data Source=" & serverIP &
'                                       ";PORT=" & serverPORT &
'                                       ";User Id=" & serverID &
'                                       ";Password=" & serverPSWD &
'                                       ";Connection Timeout=" & connectionTimeOut &
'                                       ";CharSet=utf8" &
'                                       ";SslMode=none"

'        Try
'            DBConnect1.Open()
'            'DBConnect1 연결되어있지 않다면
'            'If Not DBConnect1.State = ConnectionState.Open Then
'            '        MessageBox.Show("DB 연결 실패", "DB 테스트", MessageBoxButtons.OK, MessageBoxIcon.Error)
'            'End If
'            Dim strSQL As String = "SET Names euckr;"
'            Dim sqlCmd As New MySqlCommand(strSQL, DBConnect1)
'        Catch ex As Exception
'            returnValue = False
'            'MessageBox.Show("DB 연결 실패", "DB 테스트", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try

'        Return returnValue

'    End Function

'    'DB 종료 함수
'    Public Sub DBClose()
'        If DBConnect1.State = ConnectionState.Open Then
'            DBConnect1.Close()
'        End If
'    End Sub
'End Module
