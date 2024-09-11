Imports MySqlConnector

Module MySQL

    Public registryEdit As New RegistryEdit.RegReadWrite '레지스트리 편집
    Public DBConnect1 As MySqlConnection
    Public MDBConnect1 As OleDb.OleDbConnection
    Public serverIP As String = registryEdit.ReadRegKey("Software\Yujin", "Server.IP", "125.137.78.158")
    Public serverPORT As String = registryEdit.ReadRegKey("Software\Yujin", "server.PORT", "10522")
    Public serverID As String = registryEdit.ReadRegKey("Software\Yujin", "Server.ID", "yujin_MySQL")
    Public serverPSWD As String = registryEdit.ReadRegKey("Software\Yujin", "Server.PSWD", "Dbwlswjswk1!")
    Public DBName As String = registryEdit.ReadRegKey("Software\Yujin", "yj_mms", "yj_mms")
    Public connectionTimeOut As String = registryEdit.ReadRegKey("Software\Yujin", "ConnectionTimeOut", 5)

    'DB 연결 함수
    Public Sub DBConnect()

        DBConnect1 = New MySqlConnection
        DBConnect1.ConnectionString = "Database=" & DBName &
                                       ";Data Source=" & serverIP &
                                       ";PORT=" & serverPORT &
                                       ";User Id=" & serverID &
                                       ";Password=" & serverPSWD &
                                       ";Connection Timeout=" & connectionTimeOut &
                                       ";CharSet=utf8" &
                                       ";SslMode=none"

        Try
            DBConnect1.Open()
            'DBConnect1 연결되어있지 않다면
            'If Not DBConnect1.State = ConnectionState.Open Then
            '        MessageBox.Show("DB 연결 실패", "DB 테스트", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
            Dim strSql As String = "SET Names euckr;"
            Dim sqlCmd As New MySqlCommand(strSql, DBConnect1)
        Catch ex As Exception
            MessageBox.Show("DB 연결 실패", "DB 테스트", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'DB 종료 함수
    Public Sub DBClose()
        If DBConnect1.State = ConnectionState.Open Then
            DBConnect1.Close()
        End If
    End Sub

    ''DB 연결 함수
    'Public Sub MDBConnect()

    '    MDBConnect1 = New OleDb.OleDbConnection
    '    MDBConnect1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath + "\TempDB\TempDB.mdb" & ";Jet OLEDB:Database Password='dbwlspark'"

    '    Try
    '        MDBConnect1.Open()
    '        'MDBConnect1 연결되어있지 않다면
    '        If Not MDBConnect1.State = ConnectionState.Open Then
    '            MessageBox.Show("MDB 연결 실패", "MDB 테스트", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If
    '        Dim strSql As String = "select * from LOT_INFO"
    '        Dim sqlCmd As New OleDb.OleDbCommand(strSql, MDBConnect1)
    '    Catch ex As Exception
    '        MessageBox.Show("MDB 연결 실패", "MDB 테스트", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    ''DB 종료 함수
    'Public Sub MDBClose()
    '    If MDBConnect1.State = ConnectionState.Open Then
    '        MDBConnect1.Close()
    '    End If
    'End Sub

End Module
