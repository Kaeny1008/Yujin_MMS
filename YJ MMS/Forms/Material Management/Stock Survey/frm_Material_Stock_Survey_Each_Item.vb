Imports System.ComponentModel
Imports C1.Win.C1FlexGrid
Imports MySqlConnector

Public Class frm_Material_Stock_Survey_Each_Item

    Dim tooltip1 As ToolTip

    Private Sub frm_Material_Stock_Survey_Each_Item_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tooltip1 = New ToolTip

        Grid_Setting()

        DateTimePicker2.Value = Format(Now, "yyyy-MM-01 00:00:00")
        DateTimePicker3.Value = Format(Now)

    End Sub

    Private Sub Grid_Setting()

        With Grid_PlanList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 5
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
        End With

        Grid_PlanList(0, 0) = "No"
        Grid_PlanList(0, 1) = "계획일자"
        Grid_PlanList(0, 2) = "고객사"
        Grid_PlanList(0, 3) = "재고조사번호"
        Grid_PlanList(0, 4) = "상태"
        Grid_PlanList.AutoSizeCols()

        With Grid_MaterialList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 9
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .DrawMode = DrawModeEnum.Normal
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .Cols(1).Visible = False
            .Cols(6).DataType = GetType(Double)
            .Cols(6).Format = "#,##0"
            .Cols(8).DataType = GetType(DateTime)
            .Cols(8).Format = "yyyy-MM-dd HH:mm:ss"
        End With

        Grid_MaterialList(0, 0) = "No"
        Grid_MaterialList(0, 1) = "Action Content No"
        Grid_MaterialList(0, 2) = "Part Code"
        Grid_MaterialList(0, 3) = "Vendor"
        Grid_MaterialList(0, 4) = "Part No."
        Grid_MaterialList(0, 5) = "Lot No."
        Grid_MaterialList(0, 6) = "Qty"
        Grid_MaterialList(0, 7) = "Checker"
        Grid_MaterialList(0, 8) = "Check Date"
        Grid_MaterialList.AutoSizeCols()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart(Me)

        Grid_PlanList.Redraw = False
        Grid_PlanList.Rows.Count = 1

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_material_stock_survey(5"
        strSQL += ", null"
        strSQL += ", '" & Format(DateTimePicker2.Value, "yyyy-MM-dd 00:00:00") & "'"
        strSQL += ", '" & Format(DateTimePicker3.Value, "yyyy-MM-dd 23:59:59") & "'"
        strSQL += ", '" & TextBox1.Text & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = String.Empty
            insert_String = Grid_PlanList.Rows.Count & vbTab &
                Format(sqlDR("plan_date"), "yyyy-MM-dd") & vbTab &
                sqlDR("customer_name") & vbTab &
                sqlDR("plan_no") & vbTab &
                sqlDR("plan_status")
            Grid_PlanList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_PlanList.AutoSizeCols()
        Grid_PlanList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_PlanList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Grid_PlanList.MouseDoubleClick

        Dim selRow As Integer = Grid_PlanList.MouseRow

        If e.Button = MouseButtons.Left And selRow > 0 Then
            If Grid_PlanList(selRow, 4) = "완료" Then
                Label2.Visible = True
            Else
                Label2.Visible = False
            End If

            Load_Action_Data(Grid_PlanList(selRow, 3))
        End If

    End Sub

    Private Sub Load_Action_Data(ByVal plan_no As String)

        Thread_LoadingFormStart(Me)

        Grid_MaterialList.Redraw = False
        Grid_MaterialList.Rows.Count = 1

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_material_stock_survey(10"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & plan_no & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = Grid_MaterialList.Rows.Count
            insertString += vbTab & sqlDR("action_content_no")
            insertString += vbTab & sqlDR("part_code")
            insertString += vbTab & sqlDR("vendor")
            insertString += vbTab & sqlDR("part_no")
            insertString += vbTab & sqlDR("lot_no")
            insertString += vbTab & sqlDR("stock_qty")
            insertString += vbTab & sqlDR("checker")
            insertString += vbTab & sqlDR("check_date")

            Grid_MaterialList.AddItem(insertString)
        Loop
        sqlDR.Close()

        DBClose()

        If CheckBox2.Checked = True Then
            Update_Total()
        Else
            Grid_MaterialList.Subtotal(AggregateEnum.Clear)
        End If

        Grid_MaterialList.AutoSizeCols()
        Grid_MaterialList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Update_Total()

        Grid_MaterialList.Redraw = False
        'set up styles
        Dim s As CellStyle = Grid_MaterialList.Styles(CellStyleEnum.Subtotal0)
        s.BackColor = Color.LightGray
        s.ForeColor = Color.Black
        s.Font = New Font(Grid_MaterialList.Font, FontStyle.Bold)

        s = Grid_MaterialList.Styles(CellStyleEnum.Subtotal1)
        s.BackColor = Color.LightBlue
        s.ForeColor = Color.Black
        s = Grid_MaterialList.Styles(CellStyleEnum.Subtotal2)
        s.BackColor = Color.AliceBlue
        s.ForeColor = Color.Black

        Grid_MaterialList.Subtotal(AggregateEnum.Clear)
        Grid_MaterialList.Tree.Column = 2
        Grid_MaterialList.SubtotalPosition = SubtotalPositionEnum.AboveData

        Grid_MaterialList.Subtotal(AggregateEnum.Sum, 0, 2, 6, "Total for ( {0} )")
        Grid_MaterialList.AutoSizeCols()
        Grid_MaterialList.Redraw = True

    End Sub

    Private Sub Grid_MaterialList_RowColChange(sender As Object, e As EventArgs) Handles Grid_MaterialList.RowColChange

        Select Case Grid_MaterialList.Col
            Case 6
                If Label2.Visible = False Then
                    Grid_MaterialList.AllowEditing = True
                Else
                    Grid_MaterialList.AllowEditing = False
                End If
            Case Else
                Grid_MaterialList.AllowEditing = False
        End Select

    End Sub

    Dim beforeText As String

    Private Sub Grid_MaterialList_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Grid_MaterialList.BeforeEdit

        beforeText = Grid_MaterialList(e.Row, e.Col)

    End Sub

    Private Sub Grid_MaterialList_AfterEdit(sender As Object, e As RowColEventArgs) Handles Grid_MaterialList.AfterEdit

        If e.Row < 0 Or Not e.Col = 6 Then Exit Sub

        If e.Col = 6 Then
            Grid_MaterialList(e.Row, 0) = "M"
            Grid_MaterialList.Rows(e.Row).StyleNew.ForeColor = Color.Red
        End If

    End Sub

    Private Sub BTN_Delete_Click(sender As Object, e As EventArgs) Handles BTN_Delete.Click

        Dim selRow As Integer = Grid_MaterialList.Row

        If IsNumeric(Grid_MaterialList(selRow, 0)) Then
            Grid_MaterialList(selRow, 0) = "D"
            Grid_MaterialList.Rows(selRow).StyleNew.ForeColor = Color.DarkGray
        End If

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        If MSG_Question(Me, "저장 하시겠습니까?") = False Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        If DBConnect() = False Then Exit Sub

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Dim dateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

        Try
            For i = 1 To Grid_MaterialList.Rows.Count - 1
                If Grid_MaterialList(i, 0).ToString.Equals("M") Then
                    strSQL += "update tb_mms_material_stock_survey_action_content set stock_qty = " & CDbl(Grid_MaterialList(i, 6))
                    strSQL += ", checker = '" & loginID & "'"
                    strSQL += ", check_date = '" & dateTime & "'"
                    strSQL += " where action_content_no = '" & Grid_MaterialList(i, 1) & "';"
                ElseIf Grid_MaterialList(i, 0).ToString.Equals("D") Then
                    strSQL += "delete from tb_mms_material_stock_survey_action_content"
                    strSQL += " where action_content_no = '" & Grid_MaterialList(i, 1) & "';"
                End If
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

            Thread_LoadingFormEnd()
            MessageBox.Show(frm_Main,
                            ex.Message,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Exit Sub
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        MSG_Information(Me, "저장완료.")

    End Sub

    Private Sub Grid_MaterialList_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_MaterialList.MouseClick

        Dim selRow As Integer = Grid_MaterialList.MouseRow

        If selRow < 1 Then Exit Sub

        If e.Button = MouseButtons.Right Then
            If Label2.Visible = False Then
                Grid_MaterialList.Row = selRow
                Grid_Menu.Show(Grid_MaterialList, New Point(e.X, e.Y))
            End If
        ElseIf e.Button = MouseButtons.Left Then
            If CheckBox1.Checked = True Then
                Dim abcd As Form = New frm_Material_Stock_Survey_Part_Detail
                abcd.Show()
                Dim ctls() As Control = abcd.Controls.Find("Grid_List", True)
                'If ctls.Length > 0 AndAlso TypeOf ctls(0) Is C1FlexGrid Then
                Dim ts As C1FlexGrid = DirectCast(ctls(0), C1FlexGrid)
                'End If
                ts.Redraw = False
                Dim selPartCode As String = Grid_MaterialList(selRow, 2)
                For i = 1 To Grid_MaterialList.Rows.Count - 1
                    If Grid_MaterialList(i, 2).ToString.Equals(selPartCode) Then
                        Dim insertString As String = ts.Rows.Count & vbTab & Grid_MaterialList(i, 1)
                        For j = 2 To Grid_MaterialList.Cols.Count - 1
                            insertString += vbTab & Grid_MaterialList(i, j)
                        Next
                        ts.AddItem(insertString)
                    End If
                Next
                'set up styles
                Dim s As CellStyle = ts.Styles(CellStyleEnum.Subtotal0)
                s.BackColor = Color.LightGray
                s.ForeColor = Color.Black
                s.Font = New Font(ts.Font, FontStyle.Bold)

                s = ts.Styles(CellStyleEnum.Subtotal1)
                s.BackColor = Color.LightBlue
                s.ForeColor = Color.Black
                s = ts.Styles(CellStyleEnum.Subtotal2)
                s.BackColor = Color.AliceBlue
                s.ForeColor = Color.Black

                ts.Subtotal(AggregateEnum.Clear)
                ts.Tree.Column = 2
                ts.SubtotalPosition = SubtotalPositionEnum.AboveData

                ts.Subtotal(AggregateEnum.Sum, 0, 2, 6, "Total for ( {0} )")

                ts.AutoSizeCols()
                ts.Redraw = True
            End If
        End If

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged

        If CheckBox2.Checked = True Then
            Update_Total()
        Else
            Grid_MaterialList.Redraw = False
            Grid_MaterialList.Subtotal(AggregateEnum.Clear)
            Grid_MaterialList.Redraw = True
        End If

    End Sub

    Private Sub Grid_MaterialList_MouseMove(sender As Object, e As MouseEventArgs) Handles Grid_MaterialList.MouseMove

        If sender.MouseRow > 0 And
            e.Button = MouseButtons.Left Then

            md_ETC.cellCal(sender, Nothing)
        End If

    End Sub

    Private Sub Grid_MaterialList_LostFocus(sender As Object, e As EventArgs) Handles Grid_MaterialList.LostFocus

        frm_Main.lb_Status.Text = String.Empty

    End Sub

    Private Sub Grid_MaterialListt_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid_MaterialList.KeyDown

        If e.Shift Then
            md_ETC.cellCal(sender, Nothing)
        Else
            frm_Main.lb_Status.Text = String.Empty
        End If

    End Sub

    Private Sub BTN_PartSearch_Click(sender As Object, e As EventArgs) Handles BTN_PartSearch.Click

        If Trim(TB_SearchPartCode.Text) = String.Empty Then
            Grid_MaterialList.FilterDefinition = String.Empty
        Else
            ' Enable filtering in the grid
            Grid_MaterialList.AllowFiltering = True

            ' Create a new ConditionFilter
            Dim Filter As C1.Win.C1FlexGrid.ConditionFilter
            Filter = New C1.Win.C1FlexGrid.ConditionFilter()

            ' Create a filter to narrow down items that have Germany
            Filter.Condition1.[Operator] = C1.Win.C1FlexGrid.ConditionOperator.Equals
            Filter.Condition1.Parameter = TB_SearchPartCode.Text

            ' Assign the new filter to "ShipCountry" column
            Grid_MaterialList.Cols(2).Filter = Filter

            ' Apply the filter
            Grid_MaterialList.ApplyFilters()
        End If

    End Sub

    Private Sub Grid_MaterialList_BeforeFilter(sender As Object, e As CancelEventArgs) Handles Grid_MaterialList.BeforeFilter

        Grid_MaterialList.BeginUpdate()

    End Sub

    Private Sub Grid_MaterialList_AfterFilter(sender As Object, e As EventArgs) Handles Grid_MaterialList.AfterFilter

        '아래 주석부분은 숨기기 대신에 스타일 지정하는 코드임.

        'Dim cs = Grid_MaterialList.Styles.Add("filteredOut")
        'cs.BackColor = Color.LightGray
        'cs.ForeColor = Color.DarkGray

        '' get style used to show filtered out rows
        'Dim cs = Grid_MaterialList.Styles("filteredOut")

        '' apply style to all rows
        'For r = Grid_MaterialList.Rows.Fixed To Grid_MaterialList.Rows.Count - 1
        '    Dim row = Grid_MaterialList.Rows(r)

        '    If row.Visible Then
        '        ' normal row, reset style
        '        row.Style = Nothing
        '    Else
        '        ' filtered row, make visible and apply style
        '        row.Visible = True
        '        row.Style = cs
        '    End If
        'Next

        ' resume updates
        Grid_MaterialList.Redraw = False
        Grid_MaterialList.AutoSizeCols()
        Grid_MaterialList.EndUpdate()
        Grid_MaterialList.Redraw = True

    End Sub

    Private Sub TB_SearchPartCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_SearchPartCode.KeyDown

        BTN_PartSearch_Click(Nothing, Nothing)

    End Sub

    Private Sub BTN_SamePart_Click(sender As Object, e As EventArgs) Handles BTN_SamePart.Click

        Dim partCode As String = String.Empty
        Dim partNo As String = String.Empty
        Dim lotNo As String = String.Empty

        For i = 1 To Grid_MaterialList.Rows.Count - 1
            frm_Main.lb_Status.Text = i & " 행 진행중.."
            Application.DoEvents()
            partCode = Grid_MaterialList(i, 2)
            partNo = Grid_MaterialList(i, 4)
            lotNo = Grid_MaterialList(i, 5)
            For j = i To Grid_MaterialList.Rows.Count - 1
                If Not i = j Then
                    If partCode = Grid_MaterialList(j, 2) And partNo = Grid_MaterialList(j, 4) And lotNo = Grid_MaterialList(j, 5) Then
                        Grid_MaterialList.Rows(j).StyleNew.ForeColor = Color.DarkGray
                        Grid_MaterialList(j, 0) = "D"
                        Grid_MaterialList(j, 2) = Grid_MaterialList(j, 2) & " - 삭제"
                    End If
                End If
            Next
        Next

        frm_Main.lb_Status.Text = String.Empty

    End Sub
End Class