Imports System.IO
Imports System.Net

Module md_WebClient

    Public httpPort As Integer = registryEdit.ReadRegKey("Software\Yujin", "http.Port", 10523)
    Public httpUrl As String = "https://" & serverIP & ":" & httpPort
    Public callForm As Form

    Public Sub FileDownload_Https(ByVal selectFolder As String, ByVal FileName As String, ByVal saveFolder As String)

        Dim wbClient As New WebClient
        Dim strDownUrl As String = httpUrl & "/" & selectFolder & "/" & FileName
        Dim strDownFolder As String = saveFolder & "\" & FileName

        '파일다운로드
        wbClient.DownloadFileAsync(New Uri(strDownUrl), strDownFolder)

        AddHandler wbClient.DownloadProgressChanged, AddressOf File_DownLoading_Handler
        AddHandler wbClient.DownloadFileCompleted, AddressOf File_UpDown_Completed_Handler

    End Sub

    Private Sub File_DownLoading_Handler(sender As System.Object, e As DownloadProgressChangedEventArgs)

        Dim StrTxt As String = String.Format("DownLoad  {0} 중 {1} Mb ( {2}% )",
                                             (e.TotalBytesToReceive / 1024D / 1024D).ToString("0.00"),
                                             (e.BytesReceived / 1024D / 1024D).ToString("0.00"),
                                             Format(e.BytesReceived / e.TotalBytesToReceive * 100, "##0.00"))


        With frm_Main.pgbMain
            .Maximum = e.TotalBytesToReceive  '프로그래스바에 최대범위를 파일용량으로 넣음
            .Value = e.BytesReceived          '가져오는 바이트양을 넣음
        End With

    End Sub

    Private Sub File_UpDown_Completed_Handler(sender As System.Object, e As System.ComponentModel.AsyncCompletedEventArgs)

        MSG_Information(callForm, "Download Completed.")

    End Sub

    Public Sub FileUpload_Https(ByVal UpFolder As String, ByVal FileName As String)

        '이거 작동이 안된다.....
        '두번째 문제 폴더 권한이없어서 더더욱 안된다.
        Dim wbClient As New WebClient
        Dim strUpUrl As String = httpUrl & UpFolder
        Dim strUpFolder As String = FileName

        wbClient.UploadFileAsync(New Uri(strUpUrl), strUpFolder)
        Console.WriteLine(strUpUrl)
        Console.WriteLine(strUpFolder)

        AddHandler wbClient.UploadProgressChanged, AddressOf File_UpLoading_Handler
        AddHandler wbClient.UploadFileCompleted, AddressOf File_UpDown_Completed_Handler

    End Sub

    Private Sub File_UpLoading_Handler(sender As System.Object, e As UploadProgressChangedEventArgs)

        Dim StrTxt As String = String.Format("DownLoad  {0} 중 {1} Mb ( {2}% )",
                                             (e.TotalBytesToSend / 1024D / 1024D).ToString("0.00"),
                                             (e.BytesSent / 1024D / 1024D).ToString("0.00"),
                                             Format(e.BytesSent / e.TotalBytesToSend * 100, "##0.00"))


        With frm_Main.pgbMain
            .Maximum = e.TotalBytesToSend   '프로그래스바에 최대범위를 파일용량으로 넣음
            .Value = e.BytesSent           '가져오는 바이트양을 넣음
        End With

    End Sub
End Module
