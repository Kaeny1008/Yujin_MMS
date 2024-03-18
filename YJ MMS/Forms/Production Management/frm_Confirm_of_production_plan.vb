Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Confirm_of_production_plan

    Private MouseIsDown As Boolean = False

    Private Sub frm_Confirm_of_production_plan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        Load_CustomerList()

    End Sub

    Private Sub Load_CustomerList()

        CB_CustomerName.Items.Clear()

        DBConnect()

        Dim strSQL As String = "select customer_name"
        strSQL += " from tb_customer_list"
        strSQL += " order by customer_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            CB_CustomerName.Items.Add(sqlDR("customer_name"))
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub CB_CustomerName_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_CustomerName.SelectionChangeCommitted

        TB_CustomerCode.Text = String.Empty

        DBConnect()

        Dim strSQL As String = "select customer_code, ifnull(use_part_code, '') as use_part_code"
        strSQL += " from tb_customer_list"
        strSQL += " where customer_name = '" & CB_CustomerName.Text & "'"
        strSQL += " order by customer_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_CustomerCode.Text = sqlDR("customer_code")
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub Grid_Setting()

        With Grid_OrderList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 8
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            Grid_OrderList(0, 0) = "No"
            Grid_OrderList(0, 1) = "선택"
            Grid_OrderList(0, 2) = "Order Index"
            Grid_OrderList(0, 3) = "납기일자"
            Grid_OrderList(0, 4) = "고객사"
            Grid_OrderList(0, 5) = "모델코드"
            Grid_OrderList(0, 6) = "품번"
            Grid_OrderList(0, 7) = "주문수량"
            .Cols(1).DataType = GetType(Boolean)
            .Cols(2).Visible = False
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            '.Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            .ExtendLastCol = False
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
            .DragMode = C1.Win.C1FlexGrid.DragModeEnum.Manual
            .DropMode = C1.Win.C1FlexGrid.DropModeEnum.Manual
        End With

        C1FlexGrid1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        C1FlexGrid1.DragMode = C1.Win.C1FlexGrid.DragModeEnum.Manual
        C1FlexGrid1.DropMode = C1.Win.C1FlexGrid.DropModeEnum.Manual

    End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        If TB_CustomerCode.Text = String.Empty Then
            MessageBox.Show(Me,
                            "고객사를 먼저 선택하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Exit Sub
        End If

        Thread_LoadingFormStart()

        Grid_Setting()

        Grid_OrderList.Redraw = False
        Grid_OrderList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_check_requirements(0"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_OrderNo.Text & "'"
        strSQL += ", '" & TB_ItemCode.Text & "'"
        strSQL += ", '" & TB_ItemName.Text & "'"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_OrderList.Rows.Count & vbTab &
                                          vbTab &
                                          sqlDR("order_index") & vbTab &
                                          sqlDR("date_of_delivery") & vbTab &
                                          sqlDR("customer_name") & vbTab &
                                          sqlDR("model_code") & vbTab &
                                          sqlDR("item_code") & vbTab &
                                          Format(sqlDR("modify_order_quantity"), "#,##0")
            Grid_OrderList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_OrderList.AutoSizeCols()
        Grid_OrderList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_OrderList_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Grid_OrderList.DragEnter

        If e.Data.GetDataPresent(GetType(C1.Win.C1FlexGrid.CellRange)) Then
            ' user dragging cell
            e.Effect = DragDropEffects.Copy
        End If

    End Sub

    Dim _ptDown As Point
    Dim _cellDrag As C1.Win.C1FlexGrid.CellRange
    Dim _cellDrop As C1.Win.C1FlexGrid.CellRange

    'Private Sub Grid_OrderList_DragDrop(sender As Object, e As DragEventArgs) Handles Grid_OrderList.DragDrop

    '    ' check that the drop range is valid
    '    _cellDrop = Grid_OrderList.GetCellRange(Grid_OrderList.MouseRow, Grid_OrderList.MouseCol)
    '    If _cellDrop.r1 > -1 AndAlso _cellDrop.c1 > -1 Then
    '        If e.Data.GetDataPresent(GetType(C1.Win.C1FlexGrid.CellRange)) Then
    '            If _cellDrop.Contains(_cellDrag.r1, _cellDrag.c1) Then
    '                ' drag and drop are the same, cancel
    '                e.Effect = DragDropEffects.None
    '            Else
    '                ' user dragged cell, copy value from original cell
    '                _cellDrop.Data = _cellDrag.Data
    '                e.Effect = DragDropEffects.Copy
    '            End If
    '        End If
    '        ' select drop cell
    '        Grid_OrderList.Select(_cellDrop)
    '    End If

    'End Sub

    Private Sub Grid_OrderList_MouseDown(sender As Object, e As MouseEventArgs) Handles Grid_OrderList.MouseDown

        _ptDown = New Point(e.X, e.Y)
        _cellDrag = Grid_OrderList.GetCellRange(Grid_OrderList.MouseRow, Grid_OrderList.MouseCol)

    End Sub

    Private Sub Grid_OrderList_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grid_OrderList.MouseMove

        ' check if we should start dragging
        If e.Button And MouseButtons.Left Then
            ' check that the mouse is over the same cell where it started
            ' and that the cell is not empty
            If _cellDrag.r1 = Grid_OrderList.MouseRow AndAlso _cellDrag.c1 = Grid_OrderList.MouseCol AndAlso
                _cellDrag.r1 > -1 And _cellDrag.c1 > -1 AndAlso
                Not (_cellDrag.Data Is Nothing) Then
                ' check that the mouse has moved past the threshold, then start dragging
                If Math.Abs(_ptDown.X - e.X) + Math.Abs(_ptDown.Y - e.Y) > 5 Then
                    ' do drag-drop operation
                    Dim data As New DataObject(_cellDrag)
                    Dim effects As DragDropEffects = Grid_OrderList.DoDragDrop(data, DragDropEffects.Copy)
                    ' if it was a move, clear the original value
                    If effects = DragDropEffects.Move Then
                        _cellDrag.Data = Nothing
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub C1FlexGrid1_DragDrop(sender As Object, e As DragEventArgs) Handles C1FlexGrid1.DragDrop

        ' check that the drop range is valid
        _cellDrop = C1FlexGrid1.GetCellRange(C1FlexGrid1.MouseRow, C1FlexGrid1.MouseCol)
        If _cellDrop.r1 > -1 AndAlso _cellDrop.c1 > -1 Then
            If e.Data.GetDataPresent(GetType(C1.Win.C1FlexGrid.CellRange)) Then
                If _cellDrop.Contains(_cellDrag.r1, _cellDrag.c1) Then
                    ' drag and drop are the same, cancel
                    e.Effect = DragDropEffects.None
                Else
                    ' user dragged cell, copy value from original cell
                    _cellDrop.Data = _cellDrag.Data '실제데이터
                    e.Effect = DragDropEffects.Copy
                End If
            End If
            ' select drop cell
            C1FlexGrid1.Select(_cellDrop)
        End If

    End Sub

    Private Sub C1FlexGrid1_DragEnter(sender As Object, e As DragEventArgs) Handles C1FlexGrid1.DragEnter

        If e.Data.GetDataPresent(GetType(C1.Win.C1FlexGrid.CellRange)) Then
            ' user dragging cell
            e.Effect = DragDropEffects.Copy
        End If

    End Sub
End Class