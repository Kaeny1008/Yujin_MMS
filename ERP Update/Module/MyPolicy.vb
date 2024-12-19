Imports System.IO

Public Class MyPolicy
    Public Sub CertificateValidationCallback()

        System.Net.ServicePointManager.ServerCertificateValidationCallback =
                New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidateCertificate)

    End Sub

    Public Function ValidateCertificate(ByVal sender As Object,
                                        ByVal certificate As System.Security.Cryptography.X509Certificates.X509Certificate,
                                        ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain,
                                        ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean

        ' Allow anything with no errors
        If (sslPolicyErrors = System.Net.Security.SslPolicyErrors.None) Then
            'WriteToLog("Allow anything with no errors")
            Return True
        End If

        ' Allow any requests to serverIP
        If (sender.GetType() Is GetType(System.Net.FtpWebRequest)) Then
            If (CType(sender, System.Net.FtpWebRequest).RequestUri.Host = frm_Main.serverIP) Then
                'WriteToLog("접속하려는 IP와 동일하므로 허용")
                Return True
            End If
        ElseIf (sender.GetType() Is GetType(System.Net.HttpWebRequest)) Then
            If (CType(sender, System.Net.HttpWebRequest).Address.Host = frm_Main.serverIP) Then
                Return True
            End If
        End If

        Return False

    End Function

    '*************************************************************
    'NAME:          WriteToErrorLog
    'PURPOSE:       Open or create an error log and submit error message
    'PARAMETERS:    msg - message to be written to error file
    '               stkTrace - stack trace from error message
    '               title - title of the error file entry
    'RETURNS:       Nothing
    '*************************************************************
    Public Sub WriteToErrorLog(ByVal msg As String,
           ByVal stkTrace As String, ByVal title As String)

        'check and make the directory if necessary; this is set to look in 
        'the application folder, you may wish to place the error log in 
        'another location depending upon the user's role and write access to 
        'different areas of the file system
        If Not System.IO.Directory.Exists(Application.StartupPath & "\Errors\") Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\Errors\")
        End If

        'check the file
        Dim fs As FileStream = New FileStream(Application.StartupPath & "\Errors\errlog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim s As StreamWriter = New StreamWriter(fs)
        s.Close()
        fs.Close()

        'log it
        Dim fs1 As FileStream = New FileStream(Application.StartupPath & "\Errors\errlog.txt", FileMode.Append, FileAccess.Write)
        Dim s1 As StreamWriter = New StreamWriter(fs1)
        s1.Write("Title: " & title & vbCrLf)
        s1.Write("Message: " & msg & vbCrLf)
        s1.Write("StackTrace: " & stkTrace & vbCrLf)
        s1.Write("Date/Time: " & DateTime.Now.ToString() & vbCrLf)
        s1.Write("================================================" & vbCrLf)
        s1.Close()
        fs1.Close()

    End Sub
End Class
