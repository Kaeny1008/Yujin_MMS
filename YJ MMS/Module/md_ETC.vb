Imports System.Drawing.Printing
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Threading
Imports C1.Win.C1FlexGrid

Module md_ETC

    '접속ID
    Public loginID As String = registryEdit.ReadRegKey("Software\Yujin\Login", "User ID", "user")
    Public msg_form As String = "YJ MMS"
    Public before_griddata As String

    Public Function GetWeekOfYear(ByVal targetDate As DateTime) As Integer
        Return GetWeekOfYear(targetDate, Nothing)
    End Function

    Public Function GetWeekOfYear(ByVal targetDate As DateTime, ByVal culture As CultureInfo) As Integer
        If culture Is Nothing Then culture = CultureInfo.CurrentCulture
        Dim weekRule As CalendarWeekRule = culture.DateTimeFormat.CalendarWeekRule
        Dim firstDayOfWeek As DayOfWeek = culture.DateTimeFormat.FirstDayOfWeek
        Return culture.Calendar.GetWeekOfYear(targetDate, weekRule, firstDayOfWeek)
    End Function

    Public Sub cellCal(sender As Object, e As MouseEventArgs)

        Dim tip As String = String.Empty
        Dim total_Qty As Double = 0
        Dim total_Number_Cell As Integer = 0
        Dim total_Char_Cell As Integer = 0
        Dim total_NumericCell As Integer = 0
        For i = sender.Selection.TopRow To sender.Selection.BottomRow
            For j = sender.Selection.LeftCol To sender.Selection.RightCol
                If IsNumeric(sender(i, j)) Then
                    total_Qty += sender(i, j)
                    total_NumericCell += 1
                End If
                If Not Trim(sender(i, j)) = String.Empty Then
                    If IsNumeric(sender(i, j)) Then
                        total_Number_Cell += 1
                    Else
                        total_Char_Cell += 1
                    End If
                End If
            Next
        Next

        If Not total_Char_Cell = 0 Then
            tip = "개수(문자) : " & Format(total_Char_Cell, "#,##0.########")
        End If

        If Not total_Number_Cell = 0 Then
            tip += "    개수(숫자) : " & Format(total_Number_Cell, "#,##0.########")
        End If

        If Not total_Qty = 0 Then
            tip += "    합계 : " & Format(total_Qty, "#,##0.########")
            tip += "    평균 : " & Format(total_Qty / total_NumericCell, "#,##0.########")
        End If

        frm_Main.lb_Status.Text = tip & "                                                              "

    End Sub

    Dim th_LoadingWindow As Thread
    ReadOnly thread_SleepTime As Integer = 0

    Public Sub Thread_LoadingFormStart()

        th_FormClose = False
        th_LoadingWindow = New Thread(AddressOf Load_LoadWindow)
        th_LoadingWindow.IsBackground = True
        th_LoadingWindow.SetApartmentState(ApartmentState.STA)
        th_LoadingWindow.Name = "Normal Thread"
        th_LoadingWindow.Start()

    End Sub

    Public Sub Thread_LoadingFormStart(ByVal showText As String)

        th_FormClose = False
        th_LoadingWindow = New Thread(AddressOf Load_LoadWindow2)
        th_LoadingWindow.IsBackground = True
        th_LoadingWindow.SetApartmentState(ApartmentState.STA)
        th_LoadingWindow.Name = "ShowText Thread"
        th_LoadingWindow.Start(showText)

    End Sub

    Private Sub Load_LoadWindow()

        Try
            Console.WriteLine("(Loading Form) '{0}' Staring thread...",
                              Thread.CurrentThread.Name)
            If (frm_LoadingImage.ShowDialog(frm_Main) = DialogResult.OK) Then
                Console.WriteLine("(Loading Form) '{0}' Aborting thread...",
                                  Thread.CurrentThread.Name)
                'th_LoadingWindow.Abort() '강제종료는 프로그램 종료시나 써야할듯.. abortexception이 생김
                'Console.WriteLine("(Loading Form) '{0}' Waiting until thread stop...",
                '                  Thread.CurrentThread.Name)
                ' th_LoadingWindow.Join()
                Console.WriteLine("(Loading Form) '{0}' Finished...",
                                  Thread.CurrentThread.Name)

            End If
        Catch ex As ThreadAbortException
            Console.WriteLine("(Loading Form) '{0}' ThreadAbortException : " & ex.Message,
                              Thread.CurrentThread.Name)
        Catch ex2 As Exception
            Console.WriteLine("(Loading Form) '{0}' Exception : " & ex2.Message,
                              Thread.CurrentThread.Name)
        End Try

    End Sub

    Private Sub Load_LoadWindow2(ByVal showText As String)

        Try
            Console.WriteLine("(Loading Form) '{0}' Staring thread...",
                              Thread.CurrentThread.Name)
            frm_LoadingImage.Label1.Text = showText
            If (frm_LoadingImage.ShowDialog(frm_Main) = DialogResult.OK) Then
                Console.WriteLine("(Loading Form) '{0}' Aborting thread...",
                                  Thread.CurrentThread.Name)
                Console.WriteLine("(Loading Form) '{0}' Finished...",
                                  Thread.CurrentThread.Name)
            End If
        Catch ex As ThreadAbortException
            Console.WriteLine("(Loading Form) '{0}' ThreadAbortException : " & ex.Message,
                              Thread.CurrentThread.Name)
        Catch ex2 As Exception
            Console.WriteLine("(Loading Form) '{0}'Exception : " & ex2.Message,
                              Thread.CurrentThread.Name)
        End Try

    End Sub

    Public th_FormClose As Boolean = False

    Public Sub Thread_LoadingFormEnd()

        th_FormClose = True

    End Sub

    Public Sub RadioButtonChecked(ByVal status As Boolean, ByVal formName As Form, ByVal radioButton As RadioButton)

        Dim ctls() As Control = formName.Controls.Find(radioButton.Name, True)
        If ctls.Length > 0 AndAlso TypeOf ctls(0) Is RadioButton Then
            Dim ts As RadioButton = DirectCast(ctls(0), RadioButton)
            If ts.InvokeRequired Then
                ts.Invoke(New Action(Of Boolean, Form, RadioButton)(AddressOf RadioButtonChecked), status, formName, radioButton)
            Else
                radioButton.Checked = status
            End If
        End If

    End Sub

    Public Sub GridRowReset(ByVal rownum As Integer, ByVal formName As Form, ByVal grid As C1FlexGrid)

        Dim ctls() As Control = formName.Controls.Find(grid.Name, True)
        If ctls.Length > 0 AndAlso TypeOf ctls(0) Is C1FlexGrid Then
            Dim ts As C1FlexGrid = DirectCast(ctls(0), C1FlexGrid)
            If ts.InvokeRequired Then
                ts.Invoke(New Action(Of Integer, Form, C1FlexGrid)(AddressOf GridRowReset), rownum, formName, grid)
            Else
                grid.Rows.Count = rownum
            End If
        End If

    End Sub

    Public Sub GridRedraw(ByVal status As Boolean, ByVal formName As Form, ByVal grid As C1FlexGrid)

        Dim ctls() As Control = formName.Controls.Find(grid.Name, True)
        If ctls.Length > 0 AndAlso TypeOf ctls(0) Is C1FlexGrid Then
            Dim ts As C1FlexGrid = DirectCast(ctls(0), C1FlexGrid)
            If ts.InvokeRequired Then
                ts.Invoke(New Action(Of Boolean, Form, C1FlexGrid)(AddressOf GridRedraw), status, formName, grid)
            Else
                grid.Redraw = status
            End If
        End If

    End Sub

    Public Sub GridColsAutoSize(ByVal formName As Form, ByVal grid As C1FlexGrid)

        Dim ctls() As Control = formName.Controls.Find(grid.Name, True)
        If ctls.Length > 0 AndAlso TypeOf ctls(0) Is C1FlexGrid Then
            Dim ts As C1FlexGrid = DirectCast(ctls(0), C1FlexGrid)
            If ts.InvokeRequired Then
                ts.Invoke(New Action(Of Form, C1FlexGrid)(AddressOf GridColsAutoSize), formName, grid)
            Else
                ts.AutoSizeCols()
            End If
        End If

    End Sub

    Public Sub GridRowsAutoSize(ByVal startRow As Integer, ByVal endRow As Integer, ByVal formName As Form, ByVal grid As C1FlexGrid)

        Dim ctls() As Control = formName.Controls.Find(grid.Name, True)
        If ctls.Length > 0 AndAlso TypeOf ctls(0) Is C1FlexGrid Then
            Dim ts As C1FlexGrid = DirectCast(ctls(0), C1FlexGrid)
            If ts.InvokeRequired Then
                ts.Invoke(New Action(Of Integer, Integer, Form, C1FlexGrid)(AddressOf GridRowsAutoSize), startRow, endRow, formName, grid)
            Else
                ts.AutoSizeRows(startRow, 0, endRow, ts.Cols.Count - 1, 0, AutoSizeFlags.None)
            End If
        End If

    End Sub

    Public Sub GridWriteText(ByVal text As String,
                             ByVal row As Integer,
                             ByVal col As Integer,
                             ByVal formName As Form,
                             ByVal grid As C1FlexGrid,
                             ByVal rowForeColor As Color)

        Dim ctls() As Control = formName.Controls.Find(grid.Name, True)
        If ctls.Length > 0 AndAlso TypeOf ctls(0) Is C1FlexGrid Then
            Dim ts As C1FlexGrid = DirectCast(ctls(0), C1FlexGrid)
            If ts.InvokeRequired Then
                ts.Invoke(New Action(Of String, Integer, Integer, Form, C1FlexGrid, Color)(AddressOf GridWriteText),
                          text, row, col, formName, grid, rowForeColor)
            Else
                ts(row, col) = text
                ts.Rows(row).StyleNew.ForeColor = rowForeColor
            End If
        End If

    End Sub

    Public Sub GridWriteText(ByVal text As String,
                             ByVal row As Integer,
                             ByVal col As Integer,
                             ByVal formName As Form,
                             ByVal grid As C1FlexGrid,
                             ByVal foreColor As Color,
                             ByVal backColor As Color)

        Dim ctls() As Control = formName.Controls.Find(grid.Name, True)
        If ctls.Length > 0 AndAlso TypeOf ctls(0) Is C1FlexGrid Then
            Dim ts As C1FlexGrid = DirectCast(ctls(0), C1FlexGrid)
            If ts.InvokeRequired Then
                ts.Invoke(New Action(Of String, Integer, Integer, Form, C1FlexGrid, Color, Color)(AddressOf GridWriteText),
                          text, row, col, formName, grid, foreColor, backColor)
            Else
                ts(row, col) = text
                Dim cs As CellStyle = ts.Styles.Add("new_style")
                cs.BackColor = backColor
                cs.ForeColor = foreColor

                ts.SetCellStyle(row, col, cs)
            End If
        End If

    End Sub

    Public Sub GridWriteText(ByVal text As String, ByVal formName As Form, ByVal grid As C1FlexGrid, ByVal rowColor As Color)

        Dim ctls() As Control = formName.Controls.Find(grid.Name, True)
        If ctls.Length > 0 AndAlso TypeOf ctls(0) Is C1FlexGrid Then
            Dim ts As C1FlexGrid = DirectCast(ctls(0), C1FlexGrid)
            If ts.InvokeRequired Then
                ts.Invoke(New Action(Of String, Form, C1FlexGrid, Color)(AddressOf GridWriteText), text, formName, grid, rowColor)
            Else
                ts.AddItem(text)
                ts.Rows(ts.Rows.Count - 1).StyleNew.ForeColor = rowColor
            End If
        End If

    End Sub

    Public Function GridReadText(ByVal formName As Form, ByVal cb As C1FlexGrid, ByVal row As Integer, ByVal col As Integer) As String

        Dim ctls() As Control = formName.Controls.Find(cb.Name, True)
        If ctls.Length > 0 AndAlso TypeOf ctls(0) Is C1FlexGrid Then
            Dim ts As C1FlexGrid = DirectCast(ctls(0), C1FlexGrid)
            If ts.InvokeRequired Then
                Return ts.Invoke(New Func(Of String)(Function() GridReadText(formName, cb, row, col)))
            Else
                Dim findText As String = cb(row, col)
                Return findText
            End If
        Else
            Return String.Empty
        End If

    End Function

    Public Function GridFindRow(ByVal formName As Form, ByVal cb As C1FlexGrid, ByVal findText As String, ByVal findCol As Integer) As Integer

        Dim ctls() As Control = formName.Controls.Find(cb.Name, True)
        If ctls.Length > 0 AndAlso TypeOf ctls(0) Is C1FlexGrid Then
            Dim ts As C1FlexGrid = DirectCast(ctls(0), C1FlexGrid)
            If ts.InvokeRequired Then
                Return ts.Invoke(New Func(Of Integer)(Function() GridFindRow(formName, cb, findText, findCol)))
            Else
                Dim findRow As Integer = cb.FindRow(findText, 1, findCol, True)
                Return findrow
            End If
        Else
            Return -99
        End If

    End Function

    Public Sub ComboBoxItemAdd(ByVal itemName As String, ByVal formName As Form, ByVal cb As ComboBox)

        Dim ctls() As Control = formName.Controls.Find(cb.Name, True)
        If ctls.Length > 0 AndAlso TypeOf ctls(0) Is ComboBox Then
            Dim ts As ComboBox = DirectCast(ctls(0), ComboBox)
            If ts.InvokeRequired Then
                ts.Invoke(New Action(Of String, Form, ComboBox)(AddressOf ComboBoxItemAdd), itemName, formName, cb)
            Else
                ts.Items.Add(itemName)
            End If
        End If

    End Sub

    Public Sub ComboBoxEnabled(ByVal status As Boolean, ByVal formName As Form, ByVal cb As ComboBox)

        Dim ctls() As Control = formName.Controls.Find(cb.Name, True)
        If ctls.Length > 0 AndAlso TypeOf ctls(0) Is ComboBox Then
            Dim ts As ComboBox = DirectCast(ctls(0), ComboBox)
            If ts.InvokeRequired Then
                ts.Invoke(New Action(Of Boolean, Form, ComboBox)(AddressOf ComboBoxEnabled), status, formName, cb)
            Else
                ts.Enabled = status
            End If
        End If

    End Sub

    Public Sub ButtonEnabled(ByVal status As Boolean, ByVal formName As Form, ByVal cb As Button)

        Dim ctls() As Control = formName.Controls.Find(cb.Name, True)
        If ctls.Length > 0 AndAlso TypeOf ctls(0) Is Button Then
            Dim ts As Button = DirectCast(ctls(0), Button)
            If ts.InvokeRequired Then
                ts.Invoke(New Action(Of Boolean, Form, Button)(AddressOf ButtonEnabled), status, formName, cb)
            Else
                ts.Enabled = status
            End If
        End If

    End Sub

    Public Sub LabelTextUpdate(ByVal testString As String, ByVal formName As Form, ByVal lb As Label)

        Dim ctls() As Control = formName.Controls.Find(lb.Name, True)
        If ctls.Length > 0 AndAlso TypeOf ctls(0) Is Label Then
            Dim ts As Label = DirectCast(ctls(0), Label)
            If ts.InvokeRequired Then
                ts.Invoke(New Action(Of String, Form, Label)(AddressOf LabelTextUpdate), testString, formName, lb)
            Else
                ts.Text = testString
            End If
        End If

    End Sub

    Public Sub TextBoxTextUpdate(ByVal testString As String, ByVal formName As Form, ByVal lb As TextBox)

        Dim ctls() As Control = formName.Controls.Find(lb.Name, True)
        If ctls.Length > 0 AndAlso TypeOf ctls(0) Is TextBox Then
            Dim ts As TextBox = DirectCast(ctls(0), TextBox)
            If ts.InvokeRequired Then
                ts.Invoke(New Action(Of String, Form, TextBox)(AddressOf TextBoxTextUpdate), testString, formName, lb)
            Else
                ts.Text = testString
            End If
        End If

    End Sub

    Public Function ComboBoxTextReading(ByVal formName As Form, ByVal cb As ComboBox) As String

        Dim ctls() As Control = formName.Controls.Find(cb.Name, True)
        If ctls.Length > 0 AndAlso TypeOf ctls(0) Is ComboBox Then
            Dim ts As ComboBox = DirectCast(ctls(0), ComboBox)
            If ts.InvokeRequired Then
                Return ts.Invoke(New Func(Of String)(Function() ComboBoxTextReading(formName, cb)))
            Else
                Return ts.Text
            End If
        Else
            Return String.Empty
        End If

    End Function

    Public Sub FormDispose(ByVal formName As Form)

        If formName.InvokeRequired Then
            formName.Invoke(New Action(Of Form)(AddressOf FormDispose), formName)
        Else
            formName.Dispose()
            Console.WriteLine(formName.Name & " 창을 닫았습니다.")
        End If

    End Sub

    Public Sub PrinterListLoad(ByVal formName As Form, ByVal cb As ComboBox)

        Dim ctls() As Control = formName.Controls.Find(cb.Name, True)
        If ctls.Length > 0 AndAlso TypeOf ctls(0) Is ComboBox Then
            Dim ts As ComboBox = DirectCast(ctls(0), ComboBox)
            If ts.InvokeRequired Then
                ts.Invoke(New Action(Of Form, ComboBox)(AddressOf PrinterListLoad), formName, cb)
            Else
                cb.Items.Clear()
                For i = 0 To Printing.PrinterSettings.InstalledPrinters.Count - 1
                    Dim printers As String = Printing.PrinterSettings.InstalledPrinters.Item(i)
                    cb.Items.Add(printers)
                Next
                cb.Sorted = True
            End If
        End If

    End Sub

    Private WithEvents ComPort As New Ports.SerialPort
    Public printerCable As String = registryEdit.ReadRegKey("Software\Yujin\MMS\Label Printer", "COM/LPT", "COM")
    Public printerName As String = registryEdit.ReadRegKey("Software\Yujin\MMS\Label Printer", "Printer Name", "")
    Public printerPort As Integer = registryEdit.ReadRegKey("Software\Yujin\MMS\Label Printer", "Port", 1)
    Public printerLeftPosition As Integer = registryEdit.ReadRegKey("Software\Yujin\MMS\Label Printer", "Width", 0)
    Public printerTopPosition As Integer = registryEdit.ReadRegKey("Software\Yujin\MMS\Label Printer", "Height", 0)
    Public printerBaudRate As Integer = registryEdit.ReadRegKey("Software\Yujin\MMS\Label Printer", "BaudRate", 9600)
    Public printerDataBits As Integer = registryEdit.ReadRegKey("Software\Yujin\MMS\Label Printer", "DataBits", 8)
    Public printerParity As Integer = registryEdit.ReadRegKey("Software\Yujin\MMS\Label Printer", "Parity", 0)
    Public printerStopBits As Integer = registryEdit.ReadRegKey("Software\Yujin\MMS\Label Printer", "StopBits", 1)
    Public printerMD As Integer = registryEdit.ReadRegKey("Software\Yujin\MMS\Label Printer", "Media Darkness", 25)

    Public Function TestPrinter(ByVal testCable As String,
                                ByVal testName As String,
                                ByVal testPort As Integer,
                                ByVal testLeftPosition As Integer,
                                ByVal testTopPosition As Integer,
                                ByVal testBaudRate As Integer,
                                ByVal testDataBits As Integer,
                                ByVal testParity As Integer,
                                ByVal testStopBits As Integer) As String

        TestPrinter = String.Empty

        '##### 프린터로 전송하는 부분

        If Directory.Exists(Application.StartupPath & "\Print Text") = False Then
            Directory.CreateDirectory(Application.StartupPath & "\Print Text")
        End If

        Dim folderName As String = Application.StartupPath & "\Print Text"
        Dim fileName As String = folderName & "\Test Label Print_" & Format(Now, "yyMMddHHmmssfff") & ".txt"

        Dim swFile As StreamWriter =
            New StreamWriter(fileName, True, System.Text.Encoding.GetEncoding(949))

        Try

            'If File.Exists(Application.StartupPath & "\print.txt") Then
            '    File.Delete(Application.StartupPath & "\print.txt")
            'End If

            swFile.WriteLine("^XZ~JA^XZ")
            swFile.WriteLine("^XA^LH" & testLeftPosition & ",0^LT" & testTopPosition) 'LH : 가로위치, LT : 세로위치
            swFile.WriteLine("^MD" & printerMD) '진하기
            swFile.WriteLine("^SEE:UHANGUL.DAT^FS")
            swFile.WriteLine("^CW1,E:KFONT3.FNT^CI26^FS")
            swFile.WriteLine("^FO180,0000^A0,60,40^FDPart Code : 000000000^FS")
            swFile.WriteLine("^FO180,0060^A0,40,30^FDVendor Code : ABCDEFGHIJKLMN^FS")
            swFile.WriteLine("^FO180,0095^A0,40,30^FDLot No : A1B2C3D4E5^FS")
            swFile.WriteLine("^FO180,0130^A0,40,30^FDQty : " & Format(CInt(9999), "#,##0") & "^FS")
            swFile.WriteLine("^FO550,0140^A1N,30,20^FD한글고객사^FS")
            Dim barcodeString As String = "000000000!ABCDEFGHIJKLMN!A1B2C3D4E5!9999!VENDOR"
            swFile.WriteLine("^FO020,0020^BXN,3,200,44,44^FD" & barcodeString & "^FS")
            swFile.WriteLine("^PQ1^FS") 'PQ : 발행수량
            swFile.WriteLine("^XZ")
            swFile.Close()

            If testCable = "LPT" Then
                'File.Copy(Application.StartupPath & "\print.txt", "LPT" & testPort)
                File.Copy(fileName, "LPT" & testPort)
            ElseIf testCable = "COM" Then
                ComPort.PortName = "COM" & testPort
                ComPort.BaudRate = testBaudRate
                ComPort.Parity = testParity
                ComPort.DataBits = testDataBits
                ComPort.StopBits = testStopBits
                ComPort.Encoding = System.Text.Encoding.Default
                'ComPort.Handshake = 

                Call ComPort.Open()
                Dim fs As System.IO.FileStream
                Dim sr As System.IO.StreamReader
                'fs = System.IO.File.Open(Application.StartupPath & "\print.txt", IO.FileMode.Open) ' 파일 열기
                fs = System.IO.File.Open(fileName, IO.FileMode.Open) ' 파일 열기
                sr = New System.IO.StreamReader(fs) ' 스트림리더에 연결
                Dim str As String = String.Empty

                While sr.Peek() >= 0
                    str = sr.ReadLine() ' 한줄씩 읽기
                    ComPort.WriteLine(str)
                End While

                sr.Close()
                ComPort.Close()
            ElseIf testCable = "USB" Then
                Dim p As New md_RawPrinterHelper
                'Dim s As New StringBuilder
                'Dim fs As System.IO.FileStream
                'Dim sr As System.IO.StreamReader
                'fs = System.IO.File.Open(Application.StartupPath & "\print.txt", IO.FileMode.Open) ' 파일 열기
                'sr = New System.IO.StreamReader(fs, System.Text.Encoding.GetEncoding(949)) ' 스트림리더에 연결
                'Dim str As String = String.Empty

                'While sr.Peek() >= 0
                '    str = sr.ReadLine() ' 한줄씩 읽기
                '    s.AppendLine(str)
                'End While

                'sr.Close()
                'If Not p.SendStringToPrinter(printerName, s.ToString) = True Then
                '    TestPrinter = "프린터가 정상적으로 작동하지 않았습니다."
                'End If
                If Not p.SendFileToPrinter(printerName, fileName) = True Then
                    TestPrinter = "프린터가 정상적으로 작동하지 않았습니다."
                End If
            End If
            'File.Delete(fileName)
            TestPrinter = "Success"
        Catch ex As Exception
            swFile.Close()
            'File.Delete(filename)
            TestPrinter = ex.Message
        End Try

        Return TestPrinter

    End Function

    Public Function LabelPrint(ByVal fileName As String) As String

        Dim printResult As String = String.Empty

        Try
            If printerCable = "LPT" Then
                'File.Copy(Application.StartupPath & "\print.txt", "LPT" & printerPort)
                File.Copy(fileName, "LPT" & printerPort)
            ElseIf printerCable = "COM" Then
                ComPort.PortName = "COM" & printerPort
                ComPort.BaudRate = printerBaudRate
                ComPort.Parity = printerParity
                ComPort.DataBits = printerDataBits
                ComPort.StopBits = printerStopBits
                ComPort.Encoding = System.Text.Encoding.Default
                'ComPort.Handshake = 

                Call ComPort.Open()
                Dim fs As System.IO.FileStream
                Dim sr As System.IO.StreamReader
                'fs = System.IO.File.Open(Application.StartupPath & "\print.txt", IO.FileMode.Open) ' 파일 열기
                fs = System.IO.File.Open(fileName, IO.FileMode.Open) ' 파일 열기
                sr = New System.IO.StreamReader(fs) ' 스트림리더에 연결
                Dim str As String = String.Empty

                While sr.Peek() >= 0
                    str = sr.ReadLine() ' 한줄씩 읽기
                    ComPort.WriteLine(str)
                End While

                sr.Close()
                ComPort.Close()
            ElseIf printerCable = "USB" Then
                Dim p As New md_RawPrinterHelper
                'Dim s As New StringBuilder
                'Dim fs As System.IO.FileStream
                'Dim sr As System.IO.StreamReader
                'fs = System.IO.File.Open(Application.StartupPath & "\print.txt", IO.FileMode.Open) ' 파일 열기
                'sr = New System.IO.StreamReader(fs, System.Text.Encoding.GetEncoding(949)) ' 스트림리더에 연결
                'Dim str As String = String.Empty

                'While sr.Peek() >= 0
                '    str = sr.ReadLine() ' 한줄씩 읽기
                '    s.AppendLine(str)
                'End While

                'sr.Close()

                'If Not p.SendStringToPrinter(printerName, s.ToString) = True Then
                '    printResult = "프린터가 정상적으로 작동하지 않았습니다."
                'End If
                If Not p.SendFileToPrinter(printerName, fileName) = True Then
                    printResult = "프린터가 정상적으로 작동하지 않았습니다."
                End If
            End If
            'File.Delete(fileName)
            printResult = "Success"
        Catch ex As Exception
            'File.Delete(fileName)
            printResult = ex.Message
        End Try

        Return printResult

    End Function

    Public Sub ReleaseObject(ByVal obj As Object)

        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try

    End Sub

    Public Sub MSG_Information(ByVal frm As Form, ByVal showString As String)

        If frm.InvokeRequired Then
            frm.Invoke(New Action(Of Form, String)(AddressOf MSG_Information), frm, showString)
        Else
            MessageBox.Show(frm, showString, msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Public Sub MSG_Exclamation(ByVal frm As Form, ByVal showString As String)

        If frm.InvokeRequired Then
            frm.Invoke(New Action(Of Form, String)(AddressOf MSG_Information), frm, showString)
        Else
            MessageBox.Show(frm, showString, msg_form, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Public Sub MSG_Error(ByVal frm As Form, ByVal showString As String)

        Application.DoEvents()

        If frm.InvokeRequired Then
            frm.Invoke(New Action(Of Form, String)(AddressOf MSG_Information), frm, showString)
        Else
            MessageBox.Show(frm, showString, msg_form, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Public Function MSG_Question(ByVal frm As Form, ByVal questionString As String) As Boolean

        Application.DoEvents()

        Dim returnValue As Boolean = False

        If frm.InvokeRequired Then
            frm.Invoke(New Action(Of Form, String)(AddressOf MSG_Information), frm, questionString)
        Else
            If MessageBox.Show(frm, questionString, msg_form, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                returnValue = True
            End If
        End If

        Return returnValue

    End Function
End Module
