Imports System.Globalization
Imports System.Threading
Imports C1.Win.C1FlexGrid

Module md_ETC

    '접속ID
    Public loginID As String = registryEdit.ReadRegKey("Software\Yujin\Login", "User ID", "user")
    Public msg_form As String = "YJ MMS"

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
            If (frm_LoadingImage.ShowDialog() = DialogResult.OK) Then
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
            If (frm_LoadingImage.ShowDialog() = DialogResult.OK) Then
                Console.WriteLine("(Loading Form) '{0}' Aborting thread...",
                                  Thread.CurrentThread.Name)
                'th_LoadingWindow.Abort()
                'Console.WriteLine("(Loading Form) '{0}' Waiting until thread stop...",
                '                  Thread.CurrentThread.Name)
                'th_LoadingWindow.Join()
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
                             ByVal rowColor As Color)

        Dim ctls() As Control = formName.Controls.Find(grid.Name, True)
        If ctls.Length > 0 AndAlso TypeOf ctls(0) Is C1FlexGrid Then
            Dim ts As C1FlexGrid = DirectCast(ctls(0), C1FlexGrid)
            If ts.InvokeRequired Then
                ts.Invoke(New Action(Of String, Integer, Integer, Form, C1FlexGrid, Color)(AddressOf GridWriteText),
                          text, row, col, formName, grid, rowColor)
            Else
                ts(row, col) = text
                ts.Rows(row).StyleNew.ForeColor = rowColor
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
End Module
