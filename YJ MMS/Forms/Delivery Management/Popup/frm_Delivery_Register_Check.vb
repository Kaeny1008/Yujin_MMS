Imports C1.Win.C1FlexGrid
Imports CrystalDecisions.CrystalReports.Engine
Imports MySqlConnector

Public Class frm_Delivery_Register_Check
    Private Sub frm_Delivery_Register_Check_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Load_DeliveryNo()

        Grid_Setting()

    End Sub

    Private Sub Grid_Setting()

        With Grid_POList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 13
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .Cols(1).DataType = GetType(Boolean)
            .Cols(6).DataType = GetType(Date)
            .Cols(6).Format = "yyyy-MM-dd"
            .Cols(6).StyleNew.TextAlign = TextAlignEnum.CenterCenter
            .Cols(7).DataType = GetType(Date)
            .Cols(7).Format = "yyyy-MM-dd"
            .Cols(7).StyleNew.TextAlign = TextAlignEnum.CenterCenter
            .Cols(8).DataType = GetType(Integer)
            .Cols(8).Format = "#,##0"
            .Cols(9).DataType = GetType(Integer)
            .Cols(9).Format = "#,##0"
            .Cols(10).DataType = GetType(Integer)
            .Cols(10).Format = "#,##0"
            .Cols(11).DataType = GetType(Integer)
            .Cols(11).Format = "#,##0"
        End With

        Grid_POList(0, 0) = "No"
        Grid_POList(0, 1) = "분할납품"
        Grid_POList(0, 2) = "주문번호"
        Grid_POList(0, 3) = "품번"
        Grid_POList(0, 4) = "품명"
        Grid_POList(0, 5) = "규격"
        Grid_POList(0, 6) = "주문일자"
        Grid_POList(0, 7) = "요청 납품일자"
        Grid_POList(0, 8) = "주문수량"
        Grid_POList(0, 9) = "납품잔량"
        Grid_POList(0, 10) = "납품수량"
        Grid_POList(0, 11) = "납품후 잔량"
        Grid_POList(0, 12) = "비고"
        Grid_POList.AutoSizeCols()

    End Sub

    Private Sub Load_DeliveryNo()

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "select f_mms_delivery_no('" & Format(Now, "yyyy-MM-dd") & "') as delivery_no"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            ToolStripLabel1.Text = sqlDR("delivery_no")
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub Grid_POList_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_POList.MouseClick

        Dim selRow As Integer = Grid_POList.MouseRow
        Dim selCol As Integer = Grid_POList.MouseCol

        If e.Button = MouseButtons.Left And selRow > 0 And selCol = 1 Then
            If Grid_POList.GetCellCheck(selRow, 1) = CheckEnum.Checked Then
                Grid_POList.SetCellCheck(selRow, 1, CheckEnum.Unchecked)
                Grid_POList.Rows(selRow).StyleNew.BackColor = Color.White
            Else
                Grid_POList.SetCellCheck(selRow, 1, CheckEnum.Checked)
                Grid_POList.Rows(selRow).StyleNew.BackColor = Color.LightBlue
            End If
        End If

    End Sub

    Private Sub Grid_POList_RowColChange(sender As Object, e As EventArgs) Handles Grid_POList.RowColChange

        Dim selCol As Integer = Grid_POList.Col
        Dim selRow As Integer = Grid_POList.Row

        Select Case selCol
            Case 12
                Grid_POList.AllowEditing = True
            Case 10
                If Grid_POList.GetCellCheck(selRow, 1) = CheckEnum.Checked Then
                    Grid_POList.AllowEditing = True
                Else
                    Grid_POList.AllowEditing = False
                End If
            Case Else
                Grid_POList.AllowEditing = False
        End Select

    End Sub

    Dim beforeText As String

    Private Sub Grid_POList_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Grid_POList.BeforeEdit

        beforeText = Grid_POList(e.Row, e.Col)

    End Sub

    Private Sub Grid_POList_AfterEdit(sender As Object, e As RowColEventArgs) Handles Grid_POList.AfterEdit

        If e.Row < 1 Then Exit Sub

        If beforeText = Grid_POList(e.Row, e.Col) Then Exit Sub

        Select Case e.Col
            Case 10
                If Grid_POList(e.Row, 10) = 0 Then
                    Grid_POList(e.Row, 10) = CDbl(beforeText)
                    MSG_Information(Me, "납품수량은 0이 될 수 없습니다.")
                ElseIf Grid_POList(e.Row, 10) < 0 Then
                    Grid_POList(e.Row, 10) = CDbl(beforeText)
                    MSG_Information(Me, "납품수량은 음수값이 될 수 없습니다.")
                Else
                    Grid_POList(e.Row, 11) = Grid_POList(e.Row, 9) - Grid_POList(e.Row, 10)
                End If
        End Select

        Grid_POList.AutoSizeCols()

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        'For i = 1 To Grid_POList.Rows.Count - 1
        '    If Grid_POList.GetCellCheck(i, 1) = CheckEnum.Checked Then
        '        MSG_Exclamation(Me, "현재 분할 납품을 할 수 없습니다.")
        '        Exit Sub
        '    End If
        'Next

        If MSG_Question(Me, "저장 하시겠습니까?") = False Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        Dim saveResult As String = Save_Data()

        If Not saveResult = String.Empty Then
            MSG_Exclamation(Me, saveResult)
            Exit Sub
        End If

        Thread_LoadingFormEnd()

        MSG_Information(Me, "저장완료.")

        If MSG_Question(Me, "전표를 인쇄 하시겠습니까?") = False Then
            frm_Delivery_Register.BTN_Search_Click(Nothing, Nothing)
            Me.Dispose()
            Exit Sub
        End If

        DeliveryItem_Print()

        frm_Delivery_Register.BTN_Search_Click(Nothing, Nothing)

        Me.Dispose()

    End Sub

    Private Function Save_Data() As String

        If DBConnect() = False Then
            Return "Server Connect Fail"
            Exit Function
        End If

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            Dim nowTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            strSQL = "insert into tb_mms_delivery_history("
            strSQL += "delivery_no, customer_code, write_date, write_id"
            strSQL += ") values("
            strSQL += "'" & ToolStripLabel1.Text & "'"
            strSQL += ",'" & frm_Delivery_Register.TB_CustomerCode.Text & "'"
            strSQL += ",'" & nowTime & "'"
            strSQL += ",'" & loginID & "'"
            strSQL += ");"

            For i = 1 To Grid_POList.Rows.Count - 1
                If Grid_POList(i, 11) = 0 Then
                    '납품이 완료되었을 경우만...
                    strSQL += "update tb_mms_order_register_list set order_status = 'Delivery Completed'"
                    strSQL += " where order_index = '" & Grid_POList(i, 2) & "';"
                End If
                Dim splitPO As String = "No"
                If Grid_POList.GetCellCheck(i, 1) = CheckEnum.Checked Then
                    splitPO = "Yes"
                End If
                strSQL += "insert into tb_mms_delivery_history_content("
                strSQL += "history_no, delivery_no, po_split, po_no, delivery_qty, history_note, write_date, write_id"
                strSQL += ") values("
                strSQL += "'" & ToolStripLabel1.Text & "-" & Format(CInt(i), "00") & "'"
                strSQL += ",'" & ToolStripLabel1.Text & "'"
                strSQL += ",'" & splitPO & "'"
                strSQL += ",'" & Grid_POList(i, 2) & "'"
                strSQL += "," & Grid_POList(i, 10) & ""
                strSQL += ",'" & Grid_POList(i, 12) & "'"
                strSQL += ",'" & nowTime & "'"
                strSQL += ",'" & loginID & "'"
                strSQL += ");"
            Next

            If Not strSQL = String.Empty Then
                sqlCmd = New MySqlCommand(strSQL, dbConnection1)
                sqlCmd.Transaction = sqlTran
                sqlCmd.ExecuteNonQuery()

                sqlTran.Commit()
            End If
        Catch ex As MySqlException
            sqlTran.Rollback()
            DBClose()
            Return ex.Message
        End Try

        DBClose()

        Return String.Empty

    End Function

    Private Sub DeliveryItem_Print()

        Ship_Report_Print(ToolStripLabel1.Text)

    End Sub
End Class