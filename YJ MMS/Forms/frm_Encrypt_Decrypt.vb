﻿Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports T_Engine

Public Class frm_Encrypt_Decrypt
    Private Sub frm_Encrypt_Decrypt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Function EncryptData(strKey As String, strData As String) As String
        Try
            Dim transform As ICryptoTransform = New DESCryptoServiceProvider() With {.Key = Encoding.ASCII.GetBytes(strKey), .IV = Encoding.ASCII.GetBytes(strKey)}.CreateEncryptor()
            Dim memoryStream As MemoryStream = New MemoryStream()
            Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, transform, CryptoStreamMode.Write)
            Dim bytes As Byte() = Encoding.Unicode.GetBytes(strData)
            Try
                cryptoStream.Write(bytes, 0, bytes.Length)
            Catch
            End Try
            cryptoStream.FlushFinalBlock()
            Dim result As String
            If memoryStream.Length = 0L Then
                result = ""
            Else
                Dim array As Byte() = memoryStream.ToArray()
                result = Convert.ToBase64String(array, 0, array.Length)
            End If
            Try
                cryptoStream.Close()
            Catch
            End Try
            Return result
        Catch ex As Exception
            MSG_Error(Me, ex.Message)
            Return String.Empty
        End Try
    End Function

    Private Function DecryptData(strKey As String, strData As String) As String
        Try
            Dim transform As ICryptoTransform = New DESCryptoServiceProvider() With {.Key = Encoding.ASCII.GetBytes(strKey), .IV = Encoding.ASCII.GetBytes(strKey)}.CreateDecryptor()
            Dim memoryStream As MemoryStream = New MemoryStream()
            Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, transform, CryptoStreamMode.Write)
            Dim array As Char() = strData.ToCharArray()
            Dim array2 As Byte() = Convert.FromBase64CharArray(array, 0, array.Length)
            Try
                cryptoStream.Write(array2, 0, array2.Length)
            Catch
            End Try
            cryptoStream.FlushFinalBlock()
            Dim [string] As String = New UnicodeEncoding().GetString(memoryStream.ToArray())
            Try
                cryptoStream.Close()
            Catch
            End Try
            Return [string]
        Catch ex As Exception
            MSG_Error(Me, ex.Message)
            Return String.Empty
        End Try
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim new_Crypt As Cryptography = New Cryptography()
        TextBox5.Text = new_Crypt.GetEncoding(TextBox2.Text, TextBox1.Text)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim new_Crypt As Cryptography = New Cryptography()
        TextBox5.Text = new_Crypt.GetDecoding(TextBox3.Text, TextBox4.Text)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim passwordPolicy As PasswordPolicy = New PasswordPolicy()
        PasswordPolicy.IsPasswordHashed = True
        TextBox5.Text = passwordPolicy.HashPassword(TextBox1.Text)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim AscChars As Char() = TextBox6.Text.Replace("?", vbLf)
        Dim HexValue As String = String.Empty
        'Dim sb As New System.Text.StringBuilder
        TextBox5.Text = String.Empty

        For Each c As Char In AscChars
            HexValue = Convert.ToString(Convert.ToInt32(c), 16)
            'sb.Clear()
            'sb.AppendLine(String.Format("ASC: {0}", CStr(c)))
            'sb.AppendLine(String.Format("HEX: {0}", HexValue))
            'MessageBox.Show(sb.ToString, "Character conversion")
            TextBox5.Text += HexValue
        Next c

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim strHex As String = TextBox6.Text
        TextBox5.Text = String.Empty

        For i = 0 To Len(strHex) \ 2 - 1
            Dim nowHex As String = strHex.Substring(i * 2, 2)
            nowHex = Convert.ToByte(nowHex, 16)
            TextBox5.Text += Chr(nowHex)
        Next
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        GenaraterKey()

    End Sub

    Private Sub GenaraterKey()

        Dim hwinfoMacAddressList As List(Of String) = THwInfo.GetHWInfoMacAddressList()
        Dim hwinfoCpuId As String = THwInfo.GetHWInfoCpuId()
        Dim ui As Integer = 1010

        TextBox5.Text = "PartStation GenaraterKey..."
        TextBox5.Text += vbCrLf & vbCrLf & "1. CPU ID               : " & hwinfoCpuId

        For i = 0 To hwinfoMacAddressList.Count - 1
            TextBox5.Text += vbCrLf
            TextBox5.Text += vbCrLf & "2. MacAddress List : " & String.Format("{0}", hwinfoMacAddressList(i))
            TextBox5.Text += vbCrLf & "3. Serial No.           : " & TCrypto.GenerateKey(hwinfoMacAddressList(i), hwinfoCpuId, Format(Now, "yyMMdd"), 240, 1, ui)
        Next

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        'TextBox5.Text = CheckSWLicense(TextBox5.Text)
        Dim serialNo() As String = TextBox5.Text.Split(vbCrLf)
        Dim newText As String = "Serial Number Checking..." & vbCrLf
        TextBox5.Text = newText
        Application.DoEvents()
        For i = 0 To UBound(serialNo)
            If serialNo(i).Contains("Serial No.           : ") Then
                Dim nowSerialNo() As String = serialNo(i).Split(":")
                If CheckSWLicense(Trim(nowSerialNo(1))) Then
                    newText += vbCrLf & Trim(nowSerialNo(1)) & "      ... OK"
                End If
            End If
            Application.DoEvents()
        Next

        TextBox5.Text = newText & vbCrLf & vbCrLf & "Serial number verification completed."

    End Sub

    Private Function CheckSWLicense(ByVal key As String) As Boolean

        Dim result As Boolean = False
        Dim tpartLicenseInfo As TCrypto.TPartLicenseInfo = TCrypto.CheckTPartLicense(key)
        If tpartLicenseInfo.eCode = TCrypto.TPartLicenseInfo.Code.OK AndAlso tpartLicenseInfo.bUseTPart Then
            result = True
        End If
        Return result

    End Function

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        Dim AscChars As Char() = TB_MK_String.Text
        Dim HexValue As String = String.Empty
        TB_MK_Hex.Text = String.Empty

        For Each c As Char In AscChars
            HexValue = Convert.ToString(Convert.ToInt32(c), 16)
            TB_MK_Hex.Text += HexValue
        Next c

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        If CB_Bit.Text.Equals(String.Empty) Or CB_CryptType.Text.Equals(String.Empty) Then
            MSG_Information(Me, "모든 항목을 선택하여 주십시오.")
        End If

        Select Case CB_CryptType.Text
            Case "Encrypt"
                TextBox10.Text = Encrypt(TB_InPut.Text, TB_MK_String.Text, CInt(CB_Bit.Text)) '바이트로 전송하면 된다.
            Case "Decrypt"
                TextBox10.Text = Decrypt(TB_InPut.Text, TB_MK_String.Text, CInt(CB_Bit.Text)) '바이트로 전송하면 된다.
        End Select

    End Sub

    Protected Shared Function Encrypt(textToEncrypt As String, key As String, ByVal bit As Integer) As String

        Dim cipher As ARIAEngine = New ARIAEngine(bit)
        cipher.SetKey(Encoding.UTF8.GetBytes(key.Substring(0, 32)))
        Return cipher.SetEnc(textToEncrypt)

    End Function

    Protected Shared Function Decrypt(textToEncrypt As String, key As String, ByVal bit As Integer) As String

        Dim cipher As ARIAEngine = New ARIAEngine(bit)
        cipher.SetKey(Encoding.UTF8.GetBytes(key.Substring(0, 32)))
        Return cipher.SetDec(textToEncrypt)

    End Function

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click

        GenaraterKey_TMS()

    End Sub

    Private Sub GenaraterKey_TMS()

        Dim hwinfoMacAddressList As List(Of String) = THwInfo_TMS.GeTHwInfo_TMSMacAddressList()
        Dim hwinfoCpuId As String = THwInfo_TMS.GeTHwInfo_TMSCpuId()
        Dim ui As Integer = 10111

        TextBox5.Text = "TMS GenaraterKey..."
        TextBox5.Text += vbCrLf & vbCrLf & "1. CPU ID               : " & hwinfoCpuId

        For i = 0 To hwinfoMacAddressList.Count - 1
            TextBox5.Text += vbCrLf
            TextBox5.Text += vbCrLf & "2. MacAddress List : " & String.Format("{0}", hwinfoMacAddressList(i))
            TextBox5.Text += vbCrLf & "3. Serial No.           : " & TCrypto_TMS.GenerateKey(hwinfoMacAddressList(i), hwinfoCpuId, Format(Now, "yyMMdd"), 240, 1, ui)
        Next

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        Dim serialNo() As String = TextBox5.Text.Split(vbCrLf)
        Dim newText As String = "Serial Number Checking..." & vbCrLf
        TextBox5.Text = newText
        Application.DoEvents()
        For i = 0 To UBound(serialNo)
            If serialNo(i).Contains("Serial No.           : ") Then
                Dim nowSerialNo() As String = serialNo(i).Split(":")
                If CheckSWLicense_TMS(Trim(nowSerialNo(1))) Then
                    newText += vbCrLf & Trim(nowSerialNo(1)) & "      ... OK"
                Else
                    newText += vbCrLf & Trim(nowSerialNo(1)) & "      ... NG"
                End If
            End If
            Application.DoEvents()
        Next

        TextBox5.Text = newText & vbCrLf & vbCrLf & "Serial number verification completed."

    End Sub

    Private Function CheckSWLicense_TMS(ByVal key As String) As Boolean

        Dim result As Boolean = False
        Dim tpartLicenseInfo As TCrypto_TMS.TMSLicenseInfo = TCrypto_TMS.CheckTMSLicense(key)
        If tpartLicenseInfo.eCode = TCrypto_TMS.TMSLicenseInfo.Code.OK AndAlso tpartLicenseInfo.bUseTMS Then
            Console.WriteLine("SmartApp : " + tpartLicenseInfo.bUseSmartApp.ToString)
            Console.WriteLine("SmartRack : " + tpartLicenseInfo.bUseSmartRack.ToString)
            Console.WriteLine("SmartStorage : " + tpartLicenseInfo.bUseSmartStorage.ToString)
            Console.WriteLine("SmartLink : " + tpartLicenseInfo.bUseSmartLink.ToString)
            Console.WriteLine("SmartGate : " + tpartLicenseInfo.bUseSmartGate.ToString)
            Console.WriteLine("SmartBarcode : " + tpartLicenseInfo.bUseSmartBarcode.ToString)
            result = True
        End If
        Return result

    End Function

    '한화 OLP 재밌는거
    'samsung s techwinner w 5tkattjd!

    'keybit - 256
    'masterkey - 73616D73756E672073207465636877696E6E657220772035746B6174746A6421
    'hardlock - 4F2BD93F~2025/06/02 00:00:00~2300/08/31 23:59:59
    'hardlock Ex)FDD2AEEE09431E9004D0839F9088E8442E0FC2E702816B18DAA2B200231E1705E947E8FC8EF053C62F24B52D9CA72D77
    'keystatus Ex)317E323032352F30362F30322030393A30383A35320000000000000000000000
End Class