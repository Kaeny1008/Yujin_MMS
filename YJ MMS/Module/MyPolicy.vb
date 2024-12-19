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
            If (CType(sender, System.Net.FtpWebRequest).RequestUri.Host = serverIP) Then
                'WriteToLog("접속하려는 IP와 동일하므로 허용")
                Return True
            End If
        ElseIf (sender.GetType() Is GetType(System.Net.HttpWebRequest)) Then
            If (CType(sender, System.Net.HttpWebRequest).Address.Host = serverIP) Then
                Return True
            End If
        End If

        Return False

    End Function
End Class
