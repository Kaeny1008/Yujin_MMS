Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Management
Imports System.Text

Public Class THwInfo
    Public Shared Function GenerateAccessTokenFor(macAddress As String, cpuId As String) As String
        Dim result As String
        Try
            macAddress = macAddress.ToUpper()
            If Not THwInfo.IsMacAddressValid(macAddress) Then
                result = Nothing
            Else
                cpuId = cpuId.ToUpper()
                If Not THwInfo.IsCpuIdValid(cpuId) Then
                    result = Nothing
                Else
                    Dim textToEncrypt As String = "Info A: " + macAddress + vbLf & "Info B: " + cpuId
                    Dim key As String = "sujeong.daekyun.changhwan.dekhan.heesung"
                    result = THwInfo.Encrypt(textToEncrypt, key)
                End If
            End If
        Catch
            result = Nothing
        End Try
        Return result
    End Function

    Public Shared Function GenerateAccessTokenForThisPc() As String
        Dim hwinfoMacAddress As String = THwInfo.GetHWInfoMacAddress()
        Dim hwinfoCpuId As String = THwInfo.GetHWInfoCpuId()
        Return THwInfo.GenerateAccessTokenFor(hwinfoMacAddress, hwinfoCpuId)
    End Function

    Public Shared Function GetHWInfoMacAddress() As String
        Dim result As String
        Try
            Dim hwinfoMacAddressList As List(Of String) = THwInfo.GetHWInfoMacAddressList()
            If hwinfoMacAddressList.Count < 1 Then
                result = Nothing
            Else
                result = hwinfoMacAddressList(0)
            End If
        Catch
            result = Nothing
        End Try
        Return result
    End Function

    Public Shared Function GetHWInfoMacAddressList() As List(Of String)
        Dim list As List(Of String) = New List(Of String)()
        Dim result As List(Of String)
        Try
            list = THwInfo.GetMacAddressListByWmiQuery()
            For i As Integer = 0 To list.Count - 1
                list(i) = list(i).Replace(":"c, "-"c)
            Next
            result = list
        Catch
            result = list
        End Try
        Return result
    End Function

    Public Shared Function GetHWInfoCpuId() As String
        Dim result As String
        Try
            result = THwInfo.GetCpuIdByWmiQuery()
        Catch
            result = Nothing
        End Try
        Return result
    End Function

    Protected Shared Function GetFirstValueString(multiLineString As String) As String
        Dim text As String = multiLineString
        If text.IndexOf(vbLf) > -1 Then
            text = text.Substring(text.IndexOf(vbLf) + 1)
        End If
        If text.IndexOf(" "c) > -1 Then
            text = text.Substring(0, text.IndexOf(" "c))
        End If
        Return text
    End Function

    Protected Shared Function Encrypt(textToEncrypt As String, key As String) As String
        Dim ariaengine As ARIAEngine = New ARIAEngine(256)
        ariaengine.SetKey(Encoding.UTF8.GetBytes(key.Substring(0, 32)))
        Return ariaengine.SetEncForSWLicense(textToEncrypt)
    End Function

    Public Shared Function IsMacAddressValid(macAddress As String) As Boolean
        Return THwInfo.IsStringValidForFormat(macAddress, "XX-XX-XX-XX-XX-XX")
    End Function

    Public Shared Function IsCpuIdValid(cpuId As String) As Boolean
        Return THwInfo.IsStringValidForFormat(cpuId, "XXXXXXXXXXXXXXXX")
    End Function

    Private Shared Function ExecuteWmic(wmicCommandString As String) As String
        Dim result As String
        Try
            Dim process As Process = Process.Start(New ProcessStartInfo("wmic") With {.Arguments = wmicCommandString, .WindowStyle = ProcessWindowStyle.Hidden, .UseShellExecute = False, .RedirectStandardOutput = True})
            Dim milliseconds As Integer = 20000
            If Not process.WaitForExit(milliseconds) Then
                result = Nothing
            Else
                result = process.StandardOutput.ReadToEnd()
            End If
        Catch
            result = Nothing
        End Try
        Return result
    End Function

    Private Shared Function GetCpuIdByWmiQuery() As String
        Dim text As String = Nothing
        Dim result As String
        Try
            'New ManagementScope()
            Dim managementScope As ManagementScope = New ManagementScope("\\localhost\root\CIMV2")
            managementScope.Connect()
            Dim query As SelectQuery = New SelectQuery("SELECT * FROM Win32_Processor")
            Using managementObjectCollection As ManagementObjectCollection = New ManagementObjectSearcher(managementScope, query).[Get]()
                For Each managementBaseObject As ManagementBaseObject In managementObjectCollection
                    Dim managementObject As ManagementObject = CType(managementBaseObject, ManagementObject)
                    text = String.Format("{0}", managementObject("ProcessorId"))
                Next
            End Using
            result = text
        Catch
            result = Nothing
        End Try
        Return result
    End Function

    Private Shared Function GetMacAddressByWmiQuery() As String
        Dim text As String = Nothing
        Dim result As String
        Try
            'New ManagementScope()
            Dim managementScope As ManagementScope = New ManagementScope("\\localhost\root\CIMV2")
            managementScope.Connect()
            Dim query As SelectQuery = New SelectQuery("SELECT * FROM Win32_NetworkAdapter where (AdapterTypeID=0 and netconnectionstatus=2 and not netconnectionid like '%Virtual%' and netenabled=true)")
            Using managementObjectCollection As ManagementObjectCollection = New ManagementObjectSearcher(managementScope, query).[Get]()
                For Each managementBaseObject As ManagementBaseObject In managementObjectCollection
                    Dim managementObject As ManagementObject = CType(managementBaseObject, ManagementObject)
                    text = String.Format("{0}", managementObject("MACAddress"))
                Next
            End Using
            result = text
        Catch
            result = Nothing
        End Try
        Return result
    End Function

    Private Shared Function GetMacAddressListByWmiQuery() As List(Of String)
        Dim list As List(Of String) = New List(Of String)()
        Dim result As List(Of String)
        Try
            'New ManagementScope()
            Dim managementScope As ManagementScope = New ManagementScope("\\localhost\root\CIMV2")
            managementScope.Connect()
            Dim query As SelectQuery = New SelectQuery("SELECT * FROM Win32_NetworkAdapter where (AdapterTypeID=0 and not netconnectionid like '%Virtual%' and not netconnectionid like '%Bluetooth%')")
            Using managementObjectCollection As ManagementObjectCollection = New ManagementObjectSearcher(managementScope, query).[Get]()
                For Each managementBaseObject As ManagementBaseObject In managementObjectCollection
                    Dim managementObject As ManagementObject = CType(managementBaseObject, ManagementObject)
                    list.Add(String.Format("{0}", managementObject("MACAddress")))
                    String.Format("{0}", managementObject("AdapterType"))
                    String.Format("{0}", managementObject("Caption"))
                    String.Format("{0}", managementObject("Manufacturer"))
                    String.Format("{0}", managementObject("Status"))
                    String.Format("{0}", managementObject("AdapterTypeID"))
                    String.Format("{0}", managementObject("NetConnectionID"))
                    String.Format("{0}", managementObject("NetConnectionStatus"))
                    String.Format("{0}", managementObject("Installed"))
                    String.Format("{0}", managementObject("Availability"))
                    String.Format("{0}", managementObject("NetEnabled"))
                Next
            End Using
            result = list
        Catch
            result = Nothing
        End Try
        Return result
    End Function

    Public Shared Function IsStringValidForFormat(input As String, format As String) As Boolean
        If format Is Nothing Then
            Return False
        End If
        If input Is Nothing Then
            Return False
        End If
        If input.Length <> format.Length Then
            Return False
        End If
        For i As Integer = 0 To format.Length - 1
            Dim c As Char = format(i)
            If c <> "-"c Then
                If c = "X"c Then
                    Try
                        Convert.ToInt32(input(i).ToString(), 16)
                        GoTo IL_75
                    Catch
                        Return False
                    End Try
                    Return False
                End If
                If c = "Z"c Then
                    If Not Char.IsLetterOrDigit(input(i)) Then
                        Return False
                    End If
                    GoTo IL_75
                End If
                Return False
            End If
            If input(i) <> "-"c Then
                Return False
            End If
IL_75:
        Next
        Return True
    End Function

    Public Const IS_FAST_TEST As Boolean = False
End Class
