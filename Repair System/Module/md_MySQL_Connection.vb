Imports MySql.Data.MySqlClient

Module md_MySQL_Connection

    Public registryEdit As New RegistryEdit.RegReadWrite '레지스트리 편집
    Public dbConnection1 As MySqlConnection
    Public mdbConnection1 As OleDb.OleDbConnection

    Public serverIP As String = registryEdit.ReadRegKey("Software\Yujin", "server.IP", "125.137.78.158")
    Public serverPORT As String = registryEdit.ReadRegKey("Software\Yujin", "server.PORT", 10522)
    Public serverID As String = registryEdit.ReadRegKey("Software\Yujin\Repair System", "server.ID", "yujin_REPAIR")
    Public serverPSWD As String = registryEdit.ReadRegKey("Software\Yujin\Repair System", "server.PSWD", "Dbwlswjswk1!")
    Public connectionTimeOut As String = registryEdit.ReadRegKey("Software\Yujin", "ConnectionTimeOut", 5)
    Public dbName As String = registryEdit.ReadRegKey("Software\Yujin\Repair System", "dbName", "repair_system")

    Public dbConnection2 As MySqlConnection
    Public serverID2 As String = registryEdit.ReadRegKey("Software\Yujin", "server.ID", "yujin_MySQL")
    Public serverPSWD2 As String = registryEdit.ReadRegKey("Software\Yujin", "server.PSWD", "Dbwlswjswk1!")
    Public dbName2 As String = registryEdit.ReadRegKey("Software\Yujin", "dbName", "yj_mms")

    'DB 연결 함수
    Public Sub DBConnect()

        dbConnection1 = New MySqlConnection
        dbConnection1.ConnectionString = "Database=" & dbName &
                                         ";Data Source=" & serverIP &
                                         ";PORT=" & serverPORT &
                                         ";User Id=" & serverID &
                                         ";Password=" & serverPSWD &
                                         ";Connection Timeout=" & connectionTimeOut &
                                         ";allow user variables=true"

        Try
            dbConnection1.Open()
            'DBConnect1 연결되어있지 않다면
            'If Not DBConnect1.State = ConnectionState.Open Then
            '        MessageBox.Show("DB 연결 실패", "DB 테스트", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
            Dim strSql As String = "SET Names euckr;"
            Dim sqlCmd As New MySqlCommand(strSql, dbConnection1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Server Connection", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'DB 종료 함수
    Public Sub DBClose()

        If dbConnection1.State = ConnectionState.Open Then
            dbConnection1.Close()
        End If

    End Sub

    'DB 연결 함수
    Public Sub DBConnect_HO()

        dbConnection2 = New MySqlConnection
        dbConnection2.ConnectionString = "Database=" & dbName2 &
                                         ";Data Source=" & serverIP &
                                         ";PORT=" & serverPORT &
                                         ";User Id=" & serverID2 &
                                         ";Password=" & serverPSWD2 &
                                         ";Connection Timeout=" & connectionTimeOut &
                                         ";allow user variables=true"

        Try
            dbConnection2.Open()
            'DBConnect1 연결되어있지 않다면
            'If Not DBConnect1.State = ConnectionState.Open Then
            '        MessageBox.Show("DB 연결 실패", "DB 테스트", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
            Dim strSql As String = "SET Names euckr;"
            Dim sqlCmd As New MySqlCommand(strSql, dbConnection2)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Server Connection", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'DB 종료 함수
    Public Sub DBClose_HO()

        If dbConnection2.State = ConnectionState.Open Then
            dbConnection2.Close()
        End If

    End Sub

    'DB 연결 함수
    Public Sub Mdbconnect()

        mdbConnection1 = New OleDb.OleDbConnection
        mdbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath + "\TempDB\TempDB.mdb" & ";Jet OLEDB:Database Password='dbwlspark'"

        Try
            mdbConnection1.Open()
            'MDBConnect1 연결되어있지 않다면
            If Not mdbConnection1.State = ConnectionState.Open Then
                MessageBox.Show("MDB 연결 실패", "MDB 테스트", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Dim strSql As String = "select * from LOT_INFO"
            Dim sqlCmd As New OleDb.OleDbCommand(strSql, mdbConnection1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "MDB 테스트", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'DB 종료 함수
    Public Sub MDBClose()
        If mdbConnection1.State = ConnectionState.Open Then
            mdbConnection1.Close()
        End If
    End Sub

End Module

