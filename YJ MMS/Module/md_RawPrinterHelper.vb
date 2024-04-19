Imports System.Runtime.InteropServices
Imports System.IO

Public Class md_RawPrinterHelper
    ' Structure and API declarions:
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
    Public Class DOCINFOA
        <MarshalAs(UnmanagedType.LPStr)>
        Public pDocName As String
        <MarshalAs(UnmanagedType.LPStr)>
        Public pOutputFile As String
        <MarshalAs(UnmanagedType.LPStr)>
        Public pDataType As String
    End Class

    <DllImport("winspool.Drv", EntryPoint:="OpenPrinterA", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function OpenPrinter(<MarshalAs(UnmanagedType.LPStr)> ByVal szPrinter As String, <Out> ByRef hPrinter As IntPtr, ByVal pd As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="ClosePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="StartDocPrinterA", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal level As Int32,
    <[In], MarshalAs(UnmanagedType.LPStruct)> ByVal di As DOCINFOA) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="EndDocPrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function EndDocPrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="StartPagePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function StartPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="EndPagePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function EndPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="WritePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function WritePrinter(ByVal hPrinter As IntPtr, ByVal pBytes As IntPtr, ByVal dwCount As Int32, <Out> ByRef dwWritten As Int32) As Boolean
    End Function

    ' SendBytesToPrinter()
    ' When the function Is given a printer name And an unmanaged array
    ' of bytes, the function sends those bytes to the print queue.
    ' Returns true on success, false on failure.
    Public Function SendBytesToPrinter(ByVal szPrinterName As String, ByVal pBytes As IntPtr, ByVal dwCount As Int32) As Boolean

        Dim dwError As Int32 = 0, dwWritten As Int32 = 0
        Dim hPrinter As IntPtr = New IntPtr(0)
        Dim di As DOCINFOA = New DOCINFOA()
        Dim bSuccess As Boolean = False 'Assume failure unless you specifically succeed.
        di.pDocName = "My VB.NET RAW Document"
        di.pDataType = "RAW"
        'Open the printer.
        If OpenPrinter(szPrinterName.Normalize(), hPrinter, IntPtr.Zero) Then
            'Start a document.
            If StartDocPrinter(hPrinter, 1, di) Then
                'Start a page.
                If StartPagePrinter(hPrinter) Then
                    'Write your bytes.
                    bSuccess = WritePrinter(hPrinter, pBytes, dwCount, dwWritten)
                    EndPagePrinter(hPrinter)
                End If
                EndDocPrinter(hPrinter)
            End If
            ClosePrinter(hPrinter)
        End If
        'If you did Not succeed, GetLastError may give more information
        'about why Not.
        If bSuccess = False Then
            dwError = Marshal.GetLastWin32Error()
        End If

        Return bSuccess

    End Function

    Public Function SendFileToPrinter(ByVal szPrinterName As String, ByVal szFileName As String) As Boolean

        'Open the file.
        Dim fs As FileStream = New FileStream(szFileName, FileMode.Open)
        'Create a BinaryReader on the file.
        Dim br As BinaryReader = New BinaryReader(fs)
        'Dim an array of bytes big enough to hold the file's contents.
        Dim bytes As Byte() = New Byte(fs.Length - 1) {}
        Dim bSuccess As Boolean = False
        'Your unmanaged pointer
        Dim pUnmanagedBytes As IntPtr = New IntPtr(0)
        Dim nLength As Integer

        nLength = Convert.ToInt32(fs.Length)
        'Read the contents of the file into the array.
        bytes = br.ReadBytes(nLength)
        'Allocate some unmanaged memory for those bytes.
        pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength)
        'Copy the managed byte array into the unmanaged array.
        Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength)
        'Send the unmanaged bytes to the printer.
        bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength)
        'Free the unmanaged memory that you allocated earlier.
        Marshal.FreeCoTaskMem(pUnmanagedBytes)

        Return bSuccess

    End Function

    Public Function SendStringToPrinter(ByVal szPrinterName As String, ByVal szString As String) As Boolean

        Dim pBytes As IntPtr
        Dim dwCount As Int32

        'How many characters are in the string?
        'Fix from Nicholas Piasecki:
        'dwCount = szString.Length;
        dwCount = (szString.Length + 1) * Marshal.SystemMaxDBCSCharSize

        'Assume that the printer Is expecting ANSI text, And then convert
        'the string to ANSI text.
        pBytes = Marshal.StringToCoTaskMemAnsi(szString)
        'Send the converted ANSI string to the printer.
        SendBytesToPrinter(szPrinterName, pBytes, dwCount)
        Marshal.FreeCoTaskMem(pBytes)

        Return True

    End Function
End Class
