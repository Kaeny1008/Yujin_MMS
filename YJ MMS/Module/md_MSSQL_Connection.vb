Imports System.Data.SqlClient

Module md_MSSQL_Connection

    Public dbConnection_MSSQL As SqlConnection

    'DB 연결 함수
    Public Function DBConnect_MSSQL() As Boolean

        Dim returnValue As Boolean = True
        dbConnection_MSSQL = New SqlConnection
        dbConnection_MSSQL.ConnectionString = "Database=SQUAD" &
            ";Data Source=" & serverIP & ",10524" &
            ";User Id=t-admin" &
            ";Password=t-admin123!" &
            ";Connection Timeout=" & connectionTimeOut &
            ";Persist Security Info=True"

        Try
            dbConnection_MSSQL.Open()
        Catch ex As Exception
            returnValue = False
            Thread_LoadingFormEnd()
            MessageBox.Show(ex.Message, "MS SQL Server Connection", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return returnValue

    End Function

    'DB 종료 함수
    Public Sub DBClose_MSSQL()

        If dbConnection_MSSQL.State = ConnectionState.Open Then
            dbConnection_MSSQL.Close()
            dbConnection_MSSQL.Dispose()
        End If

    End Sub
End Module
