﻿Imports MySqlConnector

Module ServerConn

    Public registryEdit As New RegistryEdit.RegReadWrite '레지스트리 편집
    Public dbConnection1 As MySqlConnection

    Public serverIP As String = registryEdit.ReadRegKey("Software\Yujin", "server.IP", "125.137.78.158")
    Public serverPORT As String = registryEdit.ReadRegKey("Software\Yujin", "server.PORT", 10522)
    Public serverID As String = registryEdit.ReadRegKey("Software\Yujin", "server.ID", "yujin_MySQL")
    Public serverPSWD As String = registryEdit.ReadRegKey("Software\Yujin", "server.PSWD", "Dbwlswjswk1!")
    Public connectionTimeOut As String = registryEdit.ReadRegKey("Software\Yujin", "ConnectionTimeOut", 5)
    Public dbName As String = registryEdit.ReadRegKey("Software\Yujin", "dbName", "yj_mms")

    Public Function ServerConnDatabase() As Boolean

        Dim returnValue As Boolean = True

        dbConnection1 = New MySqlConnection

        dbConnection1.ConnectionString = "Database=" & dbName &
                                         ";Data Source=" & serverIP &
                                         ";PORT=" & serverPORT &
                                         ";User Id=" & serverID &
                                         ";Password=" & serverPSWD &
                                         ";Connection Timeout=" & connectionTimeOut &
                                         ";CharSet=utf8" &
                                         ";SslMode=none"

        Try
            dbConnection1.Open()
            'DBConnect1 연결되어있지 않다면
            'If Not DBConnect1.State = ConnectionState.Open Then
            '        MessageBox.Show("DB 연결 실패", "DB 테스트", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
            Dim strSql As String = "SET Names euckr;"
            Dim sqlCmd As New MySqlCommand(strSql, dbConnection1)
        Catch ex As Exception
            returnValue = False
            MessageBox.Show(ex.Message, "Server Connection", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return returnValue

    End Function

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