Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Numerics

Public Class TCrypto
    ' Token: 0x06000032 RID: 50 RVA: 0x00004E00 File Offset: 0x00003000
    Public Shared Function GenerateKey(mac As ULong, cpu_id As String, due_date As String, using_month As Integer, machines As Integer, ui As Integer) As String
        Dim result As String
        Try
            If Not THwInfo.IsCpuIdValid(cpu_id) Then
                result = Nothing
            ElseIf Not TCrypto.IsDueDateValid(due_date) Then
                result = Nothing
            Else
                Dim text As String = TCrypto.GenerateCharacterSetKey(mac)
                Dim key_tokens As List(Of String) = TCrypto.EncryptEachKeys(text, mac, cpu_id, due_date, using_month, machines, ui)
                Dim num As Integer = (Convert.ToInt32(due_date) + using_month + machines + ui) Mod TCrypto.charset_len
                Dim str As String = TCrypto.ShuffleKeys(num, key_tokens)
                Dim text2 As String = text + TCrypto.Base35Encode(num, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXY") + str
                result = String.Concat(New String() {text2.Substring(0, 4), "-", text2.Substring(4, 5), "-", text2.Substring(9, 5), "-", text2.Substring(14, 4)})
            End If
        Catch
            result = Nothing
        End Try
        Return result
    End Function

    ' Token: 0x06000033 RID: 51 RVA: 0x00004EE0 File Offset: 0x000030E0
    Public Shared Function GenerateKey(mac_str As String, cpu_id As String, due_date As String, using_month As Integer, machines As Integer, ui As Integer) As String
        If Not THwInfo.IsMacAddressValid(mac_str) Then
            Return Nothing
        End If
        mac_str = mac_str.Replace("-", String.Empty)
        Return TCrypto.GenerateKey(Convert.ToUInt64(mac_str, 16), cpu_id, due_date, using_month, machines, ui)
    End Function

    ' Token: 0x06000034 RID: 52 RVA: 0x00004F14 File Offset: 0x00003114
    Public Shared Function DecryptKey(encryptedText As String) As String()
        Dim result As String()
        Try
            encryptedText = encryptedText.ToUpper()
            If Not TCrypto.IsValidEncryptedKeyFormat(encryptedText) Then
                result = Nothing
            Else
                Dim text As String = encryptedText.Replace("-", String.Empty)
                Dim keysetKey As Char = text(0) '0
                Dim shuffleKey As Char = text(1) '5
                text = text.Substring(2) 'ZPOEUJ8EDJN16RWV
                Dim encodedTextList As List(Of String) = TCrypto.Unshuffle(shuffleKey, text)
                Dim list As List(Of String) = TCrypto.DecodeEachKeys(keysetKey, encodedTextList)
                result = New String() {list(0), String.Concat(New String() {list(1), ", ", list(2), ", ", list(3)})}
            End If
        Catch
            result = Nothing
        End Try
        Return result '1277991 // 1174, 177, 21534
    End Function

    ' Token: 0x06000035 RID: 53 RVA: 0x00004FD4 File Offset: 0x000031D4
    Private Shared Function EncryptEachKeys(characterSetKey As String, mac As ULong, cpu_id As String, due_date As String, using_month As Integer, machines As Integer, ui As Integer) As List(Of String)
        Dim text As String = TCrypto.Base35Encode(mac, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXY")
        Dim num As Integer = CInt(TCrypto.Base35Decode(characterSetKey, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXY"))
        Dim str As String = TCrypto.Base35Encode(CULng(TCrypto.Base35Decode(text.Substring(text.Length - 3), "0123456789ABCDEFGHIJKLMNOPQRSTUVWXY")), TCrypto.rcharset.Substring(num * TCrypto.charset_len, TCrypto.charset_len)).PadLeft(3, TCrypto.padChar)
        Dim text2 As String = TCrypto.Base35Encode(cpu_id, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXY")
        Dim str2 As String = TCrypto.Base35Encode(CULng(TCrypto.Base35Decode(text2.Substring(text2.Length - 2), "0123456789ABCDEFGHIJKLMNOPQRSTUVWXY")), TCrypto.rcharset.Substring(num * TCrypto.charset_len, TCrypto.charset_len)).PadLeft(2, TCrypto.padChar)
        num = (num + 1) Mod TCrypto.charset_len
        Dim item As String = TCrypto.Base35Encode(Convert.ToUInt64(due_date), TCrypto.rcharset.Substring(num * TCrypto.charset_len, TCrypto.charset_len))
        num = (num + 1) Mod TCrypto.charset_len
        Dim item2 As String = TCrypto.Base35Encode(using_month, TCrypto.rcharset.Substring(num * TCrypto.charset_len, TCrypto.charset_len)).PadLeft(2, TCrypto.padChar)
        num = (num + 1) Mod TCrypto.charset_len
        Dim item3 As String = TCrypto.Base35Encode(machines, TCrypto.rcharset.Substring(num * TCrypto.charset_len, TCrypto.charset_len)).PadLeft(2, TCrypto.padChar)
        num = (num + 1) Mod TCrypto.charset_len
        Dim item4 As String = TCrypto.Base35Encode(ui, TCrypto.rcharset.Substring(num * TCrypto.charset_len, TCrypto.charset_len)).PadLeft(3, TCrypto.padChar)
        Return New List(Of String)() From {str + str2, item, item2, item3, item4}
    End Function

    ' Token: 0x06000036 RID: 54 RVA: 0x0000517C File Offset: 0x0000337C
    Private Shared Function ShuffleKeys(shuffleKey As Integer, key_tokens As List(Of String)) As String
        Dim text As String = TCrypto.rshuffle.Substring(shuffleKey * 5, 5)
        Dim text2 As String = ""
        For i As Integer = 1 To 5
            text2 += key_tokens(text.IndexOf(i.ToString()))
        Next
        Return text2
    End Function

    ' Token: 0x06000037 RID: 55 RVA: 0x000051C8 File Offset: 0x000033C8
    Private Shared Function Unshuffle(shuffleKey As Char, shuffledText As String) As List(Of String)
        '5
        'ZPOEUJ8EDJN16RWV
        Dim text As String = TCrypto.LoadShuffleSet(CInt(TCrypto.Base35Decode(shuffleKey.ToString(), "0123456789ABCDEFGHIJKLMNOPQRSTUVWXY")))
        Dim list As List(Of String) = New List(Of String)()
        For i As Integer = 1 To 6 - 1
            Dim num As Integer = TCrypto.keyLengths(text.IndexOf(i.ToString()))
            list.Add(shuffledText.Substring(0, num))
            shuffledText = shuffledText.Substring(num)
        Next
        Dim list2 As List(Of String) = New List(Of String)()
        For j As Integer = 0 To text.Length - 1
            list2.Add(list(TCrypto.CharToInt32(text(j)) - 1))
        Next
        Return list2
    End Function

    ' Token: 0x06000038 RID: 56 RVA: 0x00005264 File Offset: 0x00003464
    Private Shared Function Base35Encode(decimalNumber As Integer, Optional alphabet As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXY") As String
        Return TCrypto.Base35Encode(CULng(CLng(decimalNumber)), alphabet)
    End Function

    ' Token: 0x06000039 RID: 57 RVA: 0x0000526E File Offset: 0x0000346E
    Private Shared Function Base35Encode(hexString As String, Optional alphabet As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXY") As String
        If hexString.Length <= 0 Then
            Return ""
        End If
        Return TCrypto.Base35Encode(Convert.ToUInt64(hexString, 16), alphabet)
    End Function

    ' Token: 0x0600003A RID: 58 RVA: 0x00005290 File Offset: 0x00003490
    Private Shared Function Base35Encode(decimalNumber As ULong, Optional alphabet As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXY") As String
        Dim text As String = ""
        If 0UL <= decimalNumber AndAlso decimalNumber < CULng(CLng(alphabet.Length)) Then
            Return alphabet(CInt(decimalNumber)).ToString()
        End If
        Dim dividend As BigInteger = decimalNumber
        While Not dividend.IsZero
            Dim value As BigInteger
            dividend = BigInteger.DivRem(dividend, alphabet.Length, value)
            text = alphabet(CInt(value)).ToString() + text
        End While
        Return text
    End Function

    ' Token: 0x0600003B RID: 59 RVA: 0x00005308 File Offset: 0x00003508
    Private Shared Function Base35Decode(base35 As String, Optional alphabet As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXY") As Long
        Dim text As String = base35
        If text.Length <= 0 Then
            Return 0L
        End If
        Dim flag As Boolean = False
        If text.Substring(0, 1) = "-" Then
            flag = True
            text = text.Substring(1)
        End If
        Dim num As Long = 0L
        While 1 < text.Length
            num += CLng(alphabet.IndexOf(text.Substring(0, 1)))
            text = text.Substring(1)
            num *= 35L
        End While
        num += CLng(alphabet.IndexOf(text.Substring(0, 1)))
        If flag Then
            num = -num
        End If
        Return num
    End Function

    ' Token: 0x0600003C RID: 60 RVA: 0x0000538A File Offset: 0x0000358A
    Private Shared Function LoadKeySet(idx As Integer) As String
        Return TCrypto.rcharset.Substring(idx * TCrypto.charset_len, TCrypto.charset_len)
    End Function

    ' Token: 0x0600003D RID: 61 RVA: 0x000053A2 File Offset: 0x000035A2
    Private Shared Function LoadShuffleSet(idx As Integer) As String
        Return TCrypto.rshuffle.Substring(idx * TCrypto.keys, TCrypto.keys)
    End Function

    ' Token: 0x0600003E RID: 62 RVA: 0x000053BA File Offset: 0x000035BA
    Private Shared Function Base35DecodeWithPadChar(value As String, [set] As String) As Integer
        While value.Length > 0 AndAlso value(0) = "Z"c
            value = value.Substring(1)
        End While
        Return CInt(TCrypto.Base35Decode(value, [set]))
    End Function

    ' Token: 0x0600003F RID: 63 RVA: 0x000053E4 File Offset: 0x000035E4
    Private Shared Function IsDueDateValid(due_date As String) As Boolean
        '1277991
        Dim dateTime As DateTime
        Return DateTime.TryParseExact(due_date, "yyMMdd", Nothing, DateTimeStyles.None, dateTime)
    End Function

    ' Token: 0x06000040 RID: 64 RVA: 0x00005405 File Offset: 0x00003605
    Public Shared Function IsValidEncryptedKeyFormat(encryptedKey As String) As Boolean
        Return THwInfo.IsStringValidForFormat(encryptedKey, "ZZZZ-ZZZZZ-ZZZZZ-ZZZZ")
    End Function

    ' Token: 0x06000041 RID: 65 RVA: 0x00005414 File Offset: 0x00003614
    Private Shared Function DecodeEachKeys(keysetKey As Char, encodedTextList As List(Of String)) As List(Of String)
        Dim num As Integer = CInt(TCrypto.Base35Decode(keysetKey.ToString(), "0123456789ABCDEFGHIJKLMNOPQRSTUVWXY"))
        num = (num + 1) Mod TCrypto.charset_len
        Dim list As List(Of String) = New List(Of String)()
        For i As Integer = 1 To encodedTextList.Count - 1
            Dim value As String = encodedTextList(i)
            list.Add(TCrypto.Base35DecodeWithPadChar(value, TCrypto.LoadKeySet(num)).ToString())
            num = (num + 1) Mod TCrypto.charset_len
        Next
        Return list
    End Function

    ' Token: 0x06000042 RID: 66 RVA: 0x00005483 File Offset: 0x00003683
    Private Shared Function CharToInt32(ch As Char) As Integer
        Return Convert.ToInt32(ch.ToString())
    End Function

    ' Token: 0x06000043 RID: 67 RVA: 0x00005491 File Offset: 0x00003691
    Private Shared Function GenerateCharacterSetKey(mac As ULong) As String
        Return TCrypto.Base35Encode(CULng((TCrypto.Base35Decode(TCrypto.Base35Encode(mac, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXY").Substring(0, 4), "0123456789ABCDEFGHIJKLMNOPQRSTUVWXY") Mod CLng(TCrypto.charset_len))), "0123456789ABCDEFGHIJKLMNOPQRSTUVWXY")
    End Function

    ' Token: 0x06000044 RID: 68 RVA: 0x000054C0 File Offset: 0x000036C0
    Private Shared Function IsValidHardwareInfoInKey(strEncrypted As String) As Boolean
        Dim hwinfoMacAddressList As List(Of String) = THwInfo.GetHWInfoMacAddressList()
        If hwinfoMacAddressList.Count < 1 Then
            Return False
        End If
        For i As Integer = 0 To hwinfoMacAddressList.Count - 1
            If TCrypto.IsValidHardwareInfoInKeyWithMacAddress(strEncrypted, hwinfoMacAddressList(i)) Then
                Return True
            End If
        Next
        Return False
    End Function

    ' Token: 0x06000045 RID: 69 RVA: 0x00005504 File Offset: 0x00003704
    Private Shared Function IsValidHardwareInfoInKeyWithMacAddress(strEncrypted As String, strMAC As String) As Boolean
        strEncrypted = strEncrypted.ToUpper()
        Dim text As String = strEncrypted.Replace("-", String.Empty)
        Dim num As ULong = Convert.ToUInt64(strMAC.Replace("-", String.Empty), 16)
        Dim c As Char = text(0)
        Dim text2 As String = TCrypto.GenerateCharacterSetKey(num).ToUpper()
        If c.ToString() <> text2 Then
            Return False
        End If
        Dim num2 As Integer = CInt(TCrypto.Base35Decode(text2, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXY"))
        Dim text3 As String = TCrypto.Base35Encode(num, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXY")
        Dim str As String = TCrypto.Base35Encode(CULng(TCrypto.Base35Decode(text3.Substring(text3.Length - 3), "0123456789ABCDEFGHIJKLMNOPQRSTUVWXY")), TCrypto.rcharset.Substring(num2 * TCrypto.charset_len, TCrypto.charset_len)).PadLeft(3, TCrypto.padChar)
        Dim text4 As String = TCrypto.Base35Encode(THwInfo.GetHWInfoCpuId(), "0123456789ABCDEFGHIJKLMNOPQRSTUVWXY")
        Dim str2 As String = TCrypto.Base35Encode(CULng(TCrypto.Base35Decode(text4.Substring(text4.Length - 2), "0123456789ABCDEFGHIJKLMNOPQRSTUVWXY")), TCrypto.rcharset.Substring(num2 * TCrypto.charset_len, TCrypto.charset_len)).PadLeft(2, TCrypto.padChar)
        Return text.IndexOf(str + str2) >= 1
    End Function

    ' Token: 0x06000046 RID: 70 RVA: 0x00005624 File Offset: 0x00003824
    Public Shared Function CheckTPartLicense(strEncrypted As String) As TCrypto.TPartLicenseInfo
        Dim tpartLicenseInfo As TCrypto.TPartLicenseInfo = New TCrypto.TPartLicenseInfo()
        Try
            strEncrypted = strEncrypted.ToUpper()
            If Not TCrypto.IsValidEncryptedKeyFormat(strEncrypted) Then
                tpartLicenseInfo.eCode = TCrypto.TPartLicenseInfo.Code.ERR_FORMAT
                Throw New Exception("Invalid key format")
            End If
            If Not TCrypto.IsValidHardwareInfoInKey(strEncrypted) Then
                tpartLicenseInfo.eCode = TCrypto.TPartLicenseInfo.Code.ERR_HARDWARE
                Throw New Exception("Hardware info is NOT valid")
            End If
            Dim array As String() = TCrypto.DecryptKey(strEncrypted)
            If array Is Nothing Then '1277991 // 1174, 177, 21534
                tpartLicenseInfo.eCode = TCrypto.TPartLicenseInfo.Code.FAIL_DECRYPT
                Throw New Exception("decrypted string is null")
            End If
            Dim array2 As String() = array(1).Split(New Char() {","c})
            Dim text As String = array(0) '1277991
            Dim value As String = array2(0).Trim() '1174
            Dim value2 As String = array2(1).Trim() '177
            Dim value3 As String = array2(2).Trim() '21534
            Dim num As Integer = Convert.ToInt32(value)
            Dim num2 As Integer = Convert.ToInt32(value2)
            Dim num3 As Integer = Convert.ToInt32(value3)
            If Not TCrypto.IsDueDateValid(text) Then
                tpartLicenseInfo.eCode = TCrypto.TPartLicenseInfo.Code.USING_OVER
                Throw New Exception("Invalid due-date")
            End If
            Dim d As DateTime = DateTime.ParseExact(text, "yyMMdd", CultureInfo.InvariantCulture).AddMonths(num)
            Dim timeSpan As TimeSpan = DateTime.Now.[Date] - d
            Dim num4 As Integer = If((num = 0), 99999, (-1 * timeSpan.Days))
            Dim days As Integer = timeSpan.Days
            Dim hwinfoMacAddressList As List(Of String) = THwInfo.GetHWInfoMacAddressList()
            Dim hwinfoCpuId As String = THwInfo.GetHWInfoCpuId()
            Dim flag As Boolean = False
            For Each mac_str As String In hwinfoMacAddressList
                flag = TCrypto.GenerateKey(mac_str, hwinfoCpuId, text, num, num2, num3).Equals(strEncrypted)
                If flag Then
                    Exit For
                End If
            Next
            tpartLicenseInfo.bUseTMS = True
            tpartLicenseInfo.nLeftDays = num4
            tpartLicenseInfo.strDueDate = text
            tpartLicenseInfo.nUsingMonth = num
            tpartLicenseInfo.nMachines = If((num2 = 0), 99999, num2)
            tpartLicenseInfo.nUI = num3
            tpartLicenseInfo.strServer = THwInfo.GetHWInfoMacAddress()
            tpartLicenseInfo.strHardware = hwinfoCpuId
            If Not flag Then
                tpartLicenseInfo.eCode = TCrypto.TPartLicenseInfo.Code.ERR_ETC
                Throw New Exception("information of Server, Hardware, etc have problems")
            End If
            If num4 < 0 Then
                tpartLicenseInfo.eCode = TCrypto.TPartLicenseInfo.Code.USING_OVER
                Throw New Exception("using month over")
            End If
        Catch ex As Exception
            tpartLicenseInfo.eCode = TCrypto.TPartLicenseInfo.Code.ERR_ETC
            tpartLicenseInfo.bUseTMS = False
            tpartLicenseInfo.strDesc = ex.Message
        End Try
        Return tpartLicenseInfo
    End Function

    ' Token: 0x04000027 RID: 39
    Private Shared rcharset As String = "VRIG1WTB84L37MN6Y90SDPCOJUAE2KHF5QXLDBTRX1ISE6CONKAQ4YPH5GV923F8J0MWU7SWG3K5OMRU96I27QTX0NYB8CDF1PVAE4HJLGN6D71854AXY3UP9BCKRMS0OVHTJE2WQIFLPI2CTAL49VN35U6SXRMBW08KGJ1Q7DEOFYH0WO92148XSJ7MDUPRHYEBTKQIFGN3LAV56C0U2VLHIE1PBQ8AXY54F9STKMWCG3NJR6DO7X8VJEAUHP27FW13CL640IYOBRDNQGKMST59OSP0MDKCG8NHR75BLF623WEQJ4XYV1T9UAIJLH598OD0WNS7BGU42Y6EAQ1FIKPMRTV3CX6GK4MQBWD8IF1OASR2CHPXT3VU5JL9E0Y7NJ8CYP13GQKAT4VHI5XN2DMB7069WSLEFROUPMXF3TL7IYQESDROCB5N4901G6WJK8UVHA2CQ5I72MKRPG1D4SAXBN309HJLV6OWYU8FET2LUGNHJW9YT16D7XOESRBIQ3V5M8AFC0KP4P19FKT0M8XVIL7Q4NSWOUAEBR6Y3D25CHGJ6GFUY8H2TMCPB4E9RKI73D01QXANSV5LOJWVPJB51XHERA8UFO0Y72NK3TLCISW6DMG49QXP890YCWRSIQFN152BMED3KUGOA46V7THLJFBW3MLXQHG9UEJD6IP701NRTCYOVKSA8452TQVE9BS41M283KDY0LJFN6ICXUGPHO57RWA1PVIYXFHD7WOBMUR5T84ES623JK9G0ANLCQ5F71CREYMVAU3N0GLX4STH9POI6W2DQBK8JQJ1MEN2YIUP3F09CD4GV56OTK8RHSL7XAWB7Y0ORSXVH9QTUJ1B3DWM5FNCAKPGE42L6I8OG1LU3T8YPWB2VFK7N5JQSA94HDEIMC6XR0P5HA63FXW7NMD12EB0QGJS8ORL4IU9CTYKV5NVB9WL4GC81SFP30EHKQ27AIOYUJM6XDRTS1TQNKV7WYUB9HE2RPI0865F4J3AMOGXLCDRW7QXTKLBVG6MJ1PN8O3H5SCU9D20YFA4EIA0EQBNXF48MRT1YLC2GOD5J3IP69HUVWSK71ELUISV32R8ONH5TXAQ96WC7D0GPFJKBMY4B9IFJCEXO176G4ST8KWVYAH30UMPNR5DLQ2YKU03MC1PDL62XEO94GWSBH8VINAJ7TQRF5EBWHAKXN9231IYSOJQR70CM8GFUDVT45P6L"

    ' Token: 0x04000028 RID: 40
    Private Shared rshuffle As String = "1432513254351421543253241123452315431245153422345153241215433254115243532414215312354542311543232541531422541335421412353421545132531244312513245425132514352143512434123513542"

    ' Token: 0x04000029 RID: 41
    Private Shared padChar As Char = "Z"c

    ' Token: 0x0400002A RID: 42
    Private Shared charset_len As Integer = 35

    ' Token: 0x0400002B RID: 43
    Private Shared keyLengths As Integer() = New Integer() {5, 4, 2, 2, 3}

    ' Token: 0x0400002C RID: 44
    Private Shared keys As Integer = 5

    ' Token: 0x0200002C RID: 44
    Public Class TPartLicenseInfo
        ' Token: 0x060002F4 RID: 756 RVA: 0x0001FCD0 File Offset: 0x0001DED0
        Public Sub New()
            Me.eCode = TCrypto.TPartLicenseInfo.Code.OK
            Me.bUseTMS = False
            Me.nLeftDays = -1
            Me.strDesc = ""
            Me.strDueDate = ""
            Me.nUsingMonth = -1
            Me.nMachines = -1
            Me.nUI = -1
            Me.strServer = ""
            Me.strHardware = ""
            Me.bUseTPart = False
        End Sub

        ' Token: 0x1700004A RID: 74
        ' (get) Token: 0x060002F5 RID: 757 RVA: 0x0001FD40 File Offset: 0x0001DF40
        ' (set) Token: 0x060002F6 RID: 758 RVA: 0x0001FD48 File Offset: 0x0001DF48
        Public Property nUI As Integer
            Get
                Return Me._ui
            End Get
            Set(value As Integer)
                Me._ui = value
                If value = 0 Then
                    Return
                End If
                If value = 1010 Then
                    Me.bUseTPart = True
                End If
            End Set
        End Property

        ' Token: 0x0400023A RID: 570
        Public Const TPartFeature As Integer = 1010

        ' Token: 0x0400023B RID: 571
        Public bUseTMS As Boolean

        ' Token: 0x0400023C RID: 572
        Public nLeftDays As Integer

        ' Token: 0x0400023D RID: 573
        Public strDesc As String

        ' Token: 0x0400023E RID: 574
        Public eCode As TCrypto.TPartLicenseInfo.Code

        ' Token: 0x0400023F RID: 575
        Public strDueDate As String

        ' Token: 0x04000240 RID: 576
        Public nUsingMonth As Integer

        ' Token: 0x04000241 RID: 577
        Public nMachines As Integer

        ' Token: 0x04000242 RID: 578
        Private _ui As Integer

        ' Token: 0x04000243 RID: 579
        Public strServer As String

        ' Token: 0x04000244 RID: 580
        Public strHardware As String

        ' Token: 0x04000245 RID: 581
        Public bUseTPart As Boolean

        ' Token: 0x0200004B RID: 75
        Public Enum Code
            ' Token: 0x0400027D RID: 637
            OK
            ' Token: 0x0400027E RID: 638
            ERR_FORMAT = 1000
            ' Token: 0x0400027F RID: 639
            ERR_HARDWARE = 2000
            ' Token: 0x04000280 RID: 640
            FAIL_DECRYPT = 3000
            ' Token: 0x04000281 RID: 641
            USING_OVER = 4000
            ' Token: 0x04000282 RID: 642
            ERR_ETC = 9000
        End Enum
    End Class
End Class
