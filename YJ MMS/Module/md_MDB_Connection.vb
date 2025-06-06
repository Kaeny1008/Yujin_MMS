﻿Module md_MDB_Connection

    Public MDBConnect1 As OleDb.OleDbConnection

    'DB 연결 함수
    Public Sub MDBConnect()

        mdbConnection1 = New OleDb.OleDbConnection
        mdbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath + "\TempDB\TempDB.mdb" & ";Jet OLEDB:Database Password='dbwlspark'"
        'mdbConnection1.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath + "\TempDB\TempDB.mdb" & ";Jet OLEDB:Database Password='dbwlspark'"
        'x64, x86따라 위내용을 수정해야 한다.
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
