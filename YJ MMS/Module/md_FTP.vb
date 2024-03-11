﻿Imports System.IO
Imports System.Net

Module md_FTP
    '************************************
    '* 설  명 : FTP Up/Down
    '* 작성일 : 2014-11-01
    '* 수정일 : 2014-11-01
    '* 작성자 : 박시현
    '************************************
    Dim downloading As Boolean

    '임시로 고정...
    'Public ftpUrl As String = "ftp://192.168.0.222:21"
    'Public ftpPort As Integer = 21
    'Public ftpID As String = "yujin_ftp"
    'Public ftpPassword As String = "Yujin_ftp!"

    Public ftpPort As Integer = registryEdit.ReadRegKey("Software\Yujin", "FtpPort", 1052)
    Public ftpUrl As String = "ftp://" & serverIP & ":" & ftpPort
    Public ftpID As String = registryEdit.ReadRegKey("Software\Yujin", "FtpID", "yujin_ftp")
    Public ftpPassword As String = registryEdit.ReadRegKey("Software\Yujin", "FtpPSWD", "Yujin_ftp!")

    Public Sub ftpFolderMake(ByVal ftpURL As String)

        Try
            Dim WriteDirectory As FtpWebRequest = WebRequest.Create(ftpURL)
            WriteDirectory.Credentials = New NetworkCredential(ftpID, ftpPassword)
            WriteDirectory.Method = WebRequestMethods.Ftp.MakeDirectory
            WriteDirectory.UsePassive = True
            WriteDirectory.KeepAlive = False
            WriteDirectory.UseBinary = False
            Dim listResponse As FtpWebResponse = WriteDirectory.GetResponse()
        Catch ex As UriFormatException
            MsgBox(ex.Message, MsgBoxStyle.Information, msg_form & "_ftpFolderMake")
        Catch ex As WebException
            MsgBox(ex.Message, MsgBoxStyle.Information, msg_form & "_ftpFolderMake")
        End Try

    End Sub

    Public Function ftpFolderSearch(ByVal ftpURL As String) As String

        '************************* FTP 서버내 폴더 리스트 검색 시작 ***************************
        Dim reader As StreamReader = Nothing
        Dim DirectoryInfo As String = ""

        Try
            Dim listRequest As FtpWebRequest = WebRequest.Create(ftpURL)
            listRequest.Credentials = New NetworkCredential(ftpID, ftpPassword)
            listRequest.Method = WebRequestMethods.Ftp.ListDirectory
            listRequest.UsePassive = True
            listRequest.KeepAlive = False
            listRequest.UseBinary = False
            Dim listResponse As FtpWebResponse = listRequest.GetResponse()
            reader = New StreamReader(listResponse.GetResponseStream())
            DirectoryInfo = reader.ReadToEnd
            listRequest = Nothing
        Catch ex As UriFormatException
            MsgBox(ex.Message, MsgBoxStyle.Information, msg_form & "_ftpFolderSearch")
        Catch ex As WebException
            MsgBox(ex.Message, MsgBoxStyle.Information, msg_form & "_ftpFolderSearch")
        Finally
            If reader IsNot Nothing Then
                reader.Close()
            End If
        End Try

        Return DirectoryInfo
        '************************* FTP 서버내 폴더 리스트 검색 종료 ***************************

        'Dim abcd As String = String.Empty

        '' Get the object used to communicate with the server.
        'Dim request As FtpWebRequest = CType(WebRequest.Create(ftpURL), FtpWebRequest)
        'request.Method = WebRequestMethods.Ftp.ListDirectory

        '' This example assumes the FTP site uses anonymous logon.
        'request.Credentials = New NetworkCredential(ftpID, ftpPassword)

        'Dim response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)

        'Dim responseStream As Stream = response.GetResponseStream()
        'Dim reader As StreamReader = New StreamReader(responseStream)

        'abcd = reader.ReadToEnd
        ''Console.WriteLine(reader.ReadToEnd())

        ''    Console.WriteLine($"Directory List Complete, status {response.StatusDescription}")

        'reader.Close()
        'response.Close()

        'Return abcd

    End Function

    Public Function ftpExistFolderSearch(ByVal ftpURL As String) As String

        '************************* FTP 서버내 폴더 리스트 검색 시작 ***************************
        Dim reader As StreamReader = Nothing
        Dim list_File As String = ""

        Try
            Dim listRequest As FtpWebRequest = WebRequest.Create(ftpURL)
            listRequest.Credentials = New NetworkCredential(ftpID, ftpPassword)
            listRequest.Method = WebRequestMethods.Ftp.ListDirectory
            listRequest.UsePassive = True
            listRequest.KeepAlive = False
            listRequest.UseBinary = False
            Dim listResponse As FtpWebResponse = listRequest.GetResponse()
            reader = New StreamReader(listResponse.GetResponseStream())
            list_File = reader.ReadToEnd
            listRequest = Nothing
        Catch ex As UriFormatException
            MsgBox(ex.Message, MsgBoxStyle.Information, msg_form & "_ftpExistFolderSearch")
        Catch ex As WebException
            MsgBox(ex.Message, MsgBoxStyle.Information, msg_form & "_ftpExistFolderSearch")
        Finally
            If reader IsNot Nothing Then
                reader.Close()
            End If
        End Try

        Return list_File

    End Function

    Public Sub ftpFileUpload(ByVal ftpURL As String, ByVal FileName As String)

        '**************************** 파일전송 시작 *****************************

        Dim fileInf As FileInfo = New FileInfo(FileName) '전송할 File을 설정
        Dim sftp As String = ftpURL & "/" & fileInf.Name '전송할 FTP 경로를 설정
        Dim upFTP As FtpWebRequest = FtpWebRequest.Create(New Uri(sftp))

        upFTP.Credentials = New NetworkCredential(ftpID, ftpPassword) 'FTP접속 계정 설정
        upFTP.Method = WebRequestMethods.Ftp.UploadFile '작업유형 설정
        upFTP.UsePassive = True
        upFTP.KeepAlive = False
        upFTP.UseBinary = False
        upFTP.ContentLength = fileInf.Length

        Dim bBuffer(1023) As Byte '버퍼설정
        Dim iLength As Integer
        Dim fs As FileStream = fileInf.OpenRead

        Dim stm As Stream = upFTP.GetRequestStream

        iLength = fs.Read(bBuffer, 0, 1024)

        Dim run_count As Integer = 0
        Dim total_count As Integer = fileInf.Length
        frm_Main.pgbMain.Maximum = 100
        frm_Main.pgbMain.Value = 1
        frm_Main.pgbMain.Visible = True

        While (iLength <> 0) '전송할 파일 크기만큼 1024씩 전송
            stm.Write(bBuffer, 0, iLength)
            iLength = fs.Read(bBuffer, 0, 1024)
            run_count += iLength
            frm_Main.pgbMain.Value = run_count / total_count * 100
            'Console.WriteLine(run_count / total_count * 100 & " % Upload")
            Application.DoEvents()
        End While

        frm_Main.pgbMain.Visible = False

        stm.Close() '전송이 끝나면 닫기
        fs.Close()

        '**************************** 파일전송 종료 *****************************

    End Sub

    Public Function ftpFileDownload(ByVal ftpURL As String, ByVal filePath As String, ByVal fileName As String) As String

        '****************************  파일다운로드 관련부분 *********************************************************
        Dim localPath_download As String = filePath & "\" '다운로드 받을 경로

        'While fileName IsNot Nothing '무조건 다운로드할때 이걸써라.(항목수 상관없이)
        Dim requestFileDownload As FtpWebRequest = Nothing
        Dim responseFileDownload As FtpWebResponse = Nothing

        Try
            'Console.WriteLine(fileName)
            requestFileDownload = DirectCast(WebRequest.Create(ftpURL & "/" & fileName), FtpWebRequest)
            requestFileDownload.Credentials = New NetworkCredential(ftpID, ftpPassword)
            requestFileDownload.UsePassive = True
            requestFileDownload.KeepAlive = False
            requestFileDownload.UseBinary = False
            requestFileDownload.Method = WebRequestMethods.Ftp.DownloadFile
            responseFileDownload = DirectCast(requestFileDownload.GetResponse(), FtpWebResponse)

            Dim responseStream As Stream = responseFileDownload.GetResponseStream()
            Dim writeStream As New FileStream(localPath_download & fileName, FileMode.Create)

            Dim Length As Integer = 2048
            Dim buffer As [Byte]() = New [Byte](Length - 1) {}
            Dim bytesRead As Integer = responseStream.Read(buffer, 0, Length)

            '#####파일의 크기를 알아보기 위해...#####
            Dim requestFileSize As FtpWebRequest = Nothing
            requestFileSize = DirectCast(WebRequest.Create(ftpURL & "/" & fileName), FtpWebRequest)
            requestFileSize.Credentials = New NetworkCredential(ftpID, ftpPassword)
            requestFileSize.Method = WebRequestMethods.Ftp.GetFileSize
            '프로그래스바의 최대를 알아본다.
            Dim run_count As Integer = 0
            Dim total_count As Integer = requestFileSize.GetResponse.ContentLength
            frm_Main.pgbMain.Maximum = 100
            frm_Main.pgbMain.Value = 1
            frm_Main.pgbMain.Visible = True
            requestFileSize = Nothing

            While bytesRead > 0
                writeStream.Write(buffer, 0, bytesRead)
                bytesRead = responseStream.Read(buffer, 0, Length)
                run_count += bytesRead
                frm_Main.pgbMain.Value = run_count / total_count * 100
                'Console.WriteLine(run_count / total_count * 100 & " % Download")
                Application.DoEvents()
            End While
            writeStream.Close()
            frm_Main.pgbMain.Visible = False

        Catch exceptionObj As Exception
            Return exceptionObj.Message
        Finally
            requestFileDownload = Nothing
            responseFileDownload = Nothing
            frm_Main.pgbMain.Visible = False
        End Try

        'End While

        '****************************  파일다운로드 관련부분 *********************************************************

        Return "Completed"

    End Function

    Public Sub ftpFileDelete(ByVal ftpURL As String, ByVal fileName As String)

        '####################### ftp에 있는 파일 삭제하기 기능###################

        Dim requestFileDelete As FtpWebRequest = Nothing
        Dim responseFileDelete As FtpWebResponse = Nothing

        Try
            requestFileDelete = DirectCast(WebRequest.Create(ftpURL & "/" & fileName), FtpWebRequest)
            requestFileDelete.Credentials = New NetworkCredential(ftpID, ftpPassword)
            requestFileDelete.Method = WebRequestMethods.Ftp.DeleteFile
            responseFileDelete = DirectCast(requestFileDelete.GetResponse(), FtpWebResponse)
            'Console.WriteLine("Delete status: {0}", responseFileDelete.StatusDescription)
        Catch exceptionObj As Exception
            MsgBox(exceptionObj.Message.ToString(), MsgBoxStyle.Critical, msg_form & "_ftpFileDelete")
        Finally
            responseFileDelete = Nothing
            requestFileDelete = Nothing
        End Try
        '####################### ftp에 있는 파일 삭제하기 기능###################

        '추가로 삭제된 폴더가 비어 있다면 폴더 삭제
        Dim check_existFile As String = ftpExistFolderSearch(ftpURL)
        If check_existFile = Nothing Then
            ftpFolderDelete(ftpURL)
        End If

    End Sub

    Public Sub ftpFolderDelete(ByVal ftpURL As String)

        If InStr(ftpURL, "ROOT") > 0 Then Exit Sub

        '####################### ftp에 있는 파일 삭제하기 기능###################

        Dim requestFolderDelete As FtpWebRequest = Nothing
        Dim responseFileDelete As FtpWebResponse = Nothing

        Try
            requestFolderDelete = DirectCast(WebRequest.Create(ftpURL), FtpWebRequest)
            requestFolderDelete.Credentials = New NetworkCredential(ftpID, ftpPassword)
            requestFolderDelete.Method = WebRequestMethods.Ftp.RemoveDirectory
            requestFolderDelete.UsePassive = True
            requestFolderDelete.KeepAlive = False
            requestFolderDelete.UseBinary = False
            responseFileDelete = DirectCast(requestFolderDelete.GetResponse(), FtpWebResponse)
            'Console.WriteLine("Delete status: {0}", responseFileDelete.StatusDescription)
        Catch exceptionObj As Exception
            MsgBox(exceptionObj.Message.ToString(), MsgBoxStyle.Critical, msg_form & "_ftpFolderDelete")
        Finally
            responseFileDelete = Nothing
            requestFolderDelete = Nothing
        End Try
        '####################### ftp에 있는 파일 삭제하기 기능###################

    End Sub

End Module


