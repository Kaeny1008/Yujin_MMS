Imports System.Globalization
Imports System.Threading

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
End Module
