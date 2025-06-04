Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions

Public Class md_SH256
    Public Shared ReadOnly Property HashedPassword(ByVal passStr As String) As String
        Get
            'Dim hashedEmptyPassword1 As String = PasswordPolicy._hashedEmptyPassword
            'Dim result As String = hashedEmptyPassword1
            'If hashedEmptyPassword1.Equals(String.Empty) Then
            '    Dim text As String = New PasswordPolicy().HashPassword(passStr)
            '    result = text
            '    PasswordPolicy._hashedEmptyPassword = text
            'End If
            'Return result
            Dim text As String = New md_SH256().HashPassword(passStr)
            Return text
        End Get
    End Property

    Public Function HashPassword(password As String) As String
        If password Is Nothing Then
            Throw New ArgumentNullException("password")
        End If
        'If Not PasswordPolicy.IsPasswordHashed Then
        '    Return password
        'End If
        Return Me.HashPasswordForth(password)
    End Function

    Public Function HashPasswordForth(password As String) As String
        Dim bytes As Byte() = Me._utf8Encoding.GetBytes(password + "t-solution")
        Return Convert.ToBase64String(Me._sha256.ComputeHash(bytes))
    End Function

    Public Shared ReadOnly Property UnHashedPassword(ByVal passStr As String) As String
        Get
            Dim text As String = New md_SH256().UnHashPassword(passStr)
            Return text
        End Get
    End Property

    Public Function UnHashPassword(password As String) As String
        If password Is Nothing Then
            Throw New ArgumentNullException("password")
        End If
        Return Me.UnHashPasswordForth(password)
    End Function

    Public Function UnHashPasswordForth(password As String) As String
        'Dim bytes As Byte() = Me._utf8Encoding.GetBytes(password + "t-solution")
        'Return Convert.ToBase64String(Me._sha256.ComputeHash(bytes))
        'Return Me._sha256.Hash
    End Function

    Public Shared Function IsPasswordHashedDBVer(dbVersion As Double, nPackageType As Integer) As Boolean
        Try
            If nPackageType = 1 Then
                Return Convert.ToDouble(md_SH256.MinDBVersionForHashedPasswordT1.ToString()) <= dbVersion
            End If
            If nPackageType = 2 OrElse nPackageType = 3 Then
                Return Convert.ToDouble(md_SH256.MinDBVersionForHashedPasswordT2.ToString()) <= dbVersion
            End If
        Catch
        End Try
        Return False
    End Function

    Public Shared Function CheckPasswordStrength(password As String) As PasswordStrength
        If password.Length < 8 Then
            Return PasswordStrength.VeryWeak
        End If
        Dim num As Integer = 0
        If password.Length >= 14 Then
            num += 1
        End If
        If Regex.IsMatch(password, "[a-z]+") Then
            num += 1
        End If
        If Regex.IsMatch(password, "[A-Z]+") Then
            num += 1
        End If
        If Regex.IsMatch(password, "\d+") Then
            num += 1
        End If
        If Regex.IsMatch(password, "[^a-zA-Z\d]+") Then
            num += 1
        End If
        If num = 0 Then
            Return PasswordStrength.VeryWeak
        End If
        If num = 1 Then
            Return PasswordStrength.Weak
        End If
        If num = 2 Then
            Return PasswordStrength.Medium
        End If
        If num = 3 Then
            Return PasswordStrength.Strong
        End If
        Return PasswordStrength.VeryStrong
    End Function

    Public Shared Function IsPasswordChangeRecommended(password As String) As Boolean
        Select Case md_SH256.CheckPasswordStrength(password)
            Case PasswordStrength.VeryWeak, PasswordStrength.Weak, PasswordStrength.Medium
                Return True
            Case Else
                Return False
        End Select
    End Function

    ' Token: 0x04000017 RID: 23
    Private Shared _hashedEmptyPassword As String = String.Empty

    ' Token: 0x04000018 RID: 24
    Public Shared IsPasswordHashed As Boolean = False

    ' Token: 0x04000019 RID: 25
    Private _utf8Encoding As UTF8Encoding = New UTF8Encoding()

    ' Token: 0x0400001A RID: 26
    Private _sha256 As SHA256 = New SHA256Managed()

    ' Token: 0x0400001B RID: 27
    Private Shared MinDBVersionForHashedPasswordT1 As Version = New Version("1.48")

    ' Token: 0x0400001C RID: 28
    Public Shared MinDBVersionForHashedPasswordT2 As Version = New Version("2.71")

    Public Enum PasswordStrength
        ' Token: 0x04000012 RID: 18
        VeryWeak
        ' Token: 0x04000013 RID: 19
        Weak
        ' Token: 0x04000014 RID: 20
        Medium
        ' Token: 0x04000015 RID: 21
        Strong
        ' Token: 0x04000016 RID: 22
        VeryStrong
    End Enum
End Class
