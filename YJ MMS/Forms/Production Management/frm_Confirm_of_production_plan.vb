Imports System.Runtime.InteropServices
Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient


Public Class frm_Production_plan

    Private MouseIsDown As Boolean = False

    Private Sub frm_Confirm_of_production_plan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        Load_CustomerList()

    End Sub

    Private Sub Grid_Setting()

        With Grid_OrderList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 14
            .Cols.Fixed = 1
            .Rows.Count = 3
            .Rows.Fixed = 3
            For i = 0 To .Cols.Count - 1
                .Cols(i).AllowMerging = True
            Next
            For i = 0 To .Rows.Count - 1
                .Rows(i).AllowMerging = True
            Next
            Dim rngM As CellRange = .GetCellRange(0, 0, 2, 0)
            rngM.Data = "No"
            rngM = .GetCellRange(0, 1, 2, 1)
            rngM.Data = "Order Index"
            rngM = .GetCellRange(0, 2, 2, 2)
            rngM.Data = "납기일자"
            rngM = .GetCellRange(0, 3, 2, 3)
            rngM.Data = "고객사 코드"
            rngM = .GetCellRange(0, 4, 2, 4)
            rngM.Data = "고객사"
            rngM = .GetCellRange(0, 5, 2, 5)
            rngM.Data = "모델코드"
            rngM = .GetCellRange(0, 6, 2, 6)
            rngM.Data = "품번"
            rngM = .GetCellRange(0, 7, 2, 7)
            rngM.Data = "품명"
            rngM = .GetCellRange(0, 8, 2, 8)
            rngM.Data = "주문수량"
            rngM = .GetCellRange(0, 9, 2, 9)
            rngM.Data = "공정순서"
            rngM = .GetCellRange(0, 10, 0, 12)
            rngM.Data = "생산계획"
            rngM = .GetCellRange(1, 10, 2, 10)
            rngM.Data = "생산시작일"
            rngM = .GetCellRange(1, 11, 1, 12)
            rngM.Data = "SMD"
            Grid_OrderList(2, 11) = "동"
            Grid_OrderList(2, 12) = "Line"
            rngM = .GetCellRange(0, 13, 2, 13)
            rngM.Data = "비고(라벨 인쇄됨)"
            .Cols(1).Visible = True
            .Cols(3).Visible = True
            .Cols(8).DataType = GetType(Double)
            .Cols(8).Format = "#,##0"
            .Cols(10).DataType = GetType(Date)
            .AutoClipboard = False
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .Cols(10).TextAlign = TextAlignEnum.CenterCenter
            '.Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            .ExtendLastCol = False
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            '.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
            '.DragMode = C1.Win.C1FlexGrid.DragModeEnum.Manual
            '.DropMode = C1.Win.C1FlexGrid.DropModeEnum.Manual
            .SelectionMode = SelectionModeEnum.ListBox
        End With

    End Sub

    Private Sub Load_CustomerList()

        CB_CustomerName.Items.Clear()

        If DBConnect() = False Then Exit Sub

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

        If DBConnect() = False Then Exit Sub

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

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        If TB_CustomerCode.Text = String.Empty Then
            MessageBox.Show(Me,
                            "고객사를 먼저 선택하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Exit Sub
        End If

        Thread_LoadingFormStart(Me)

        Grid_Setting()

        Grid_OrderList.Redraw = False
        Grid_OrderList.Rows.Count = 3

        If DBConnect() = False Then Exit Sub

        Dim statusString As String = RadioButton1.Text
        If RadioButton2.Checked Then
            statusString = RadioButton2.Text
        ElseIf RadioButton3.Checked Then
            statusString = RadioButton3.Text
        End If

        Dim strSQL As String = "call sp_mms_production_plan(0"
        strSQL += ", '" & TB_Search.Text & "'"
        strSQL += ", '" & statusString & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_OrderList.Rows.Count - 2
            insert_String += vbTab & sqlDR("order_index")
            insert_String += vbTab & sqlDR("date_of_delivery")
            insert_String += vbTab & sqlDR("customer_code")
            insert_String += vbTab & sqlDR("customer_name")
            insert_String += vbTab & sqlDR("model_code")
            insert_String += vbTab & sqlDR("item_code")
            insert_String += vbTab & sqlDR("item_name")
            insert_String += vbTab & sqlDR("modify_order_quantity")
            insert_String += vbTab & sqlDR("process_list")
            insert_String += vbTab & sqlDR("start_date")
            insert_String += vbTab & sqlDR("smd_department")
            insert_String += vbTab & sqlDR("smd_line")
            insert_String += vbTab & sqlDR("order_note")
            Grid_OrderList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_OrderList.AutoSizeCols()
        Grid_OrderList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_OrderList_RowColChange(sender As Object, e As EventArgs) Handles Grid_OrderList.RowColChange

        If Grid_OrderList.Row < 3 Or Grid_OrderList.Col < 1 Then Exit Sub

        Select Case Grid_OrderList.Col
            Case 10, 13
                Grid_OrderList.AllowEditing = True
            Case 11
                Grid_OrderList.AllowEditing = True
                Grid_OrderList.Cols(11).ComboList = Load_Department()
            Case 12
                Grid_OrderList.AllowEditing = True
                Grid_OrderList.Cols(12).ComboList = Load_Line(Grid_OrderList(Grid_OrderList.Row, 11))
            Case Else
                Grid_OrderList.AllowEditing = False
        End Select

    End Sub

    Private Function Load_Department() As String

        Dim comboList As String = String.Empty

        If DBConnect() = False Then
            Return comboList
            Exit Function
        End If

        Dim strSQL As String = "select sub_code_name"
        strSQL += " from tb_code_sub"
        strSQL += " where main_code = 'MC00000001';"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            If comboList = String.Empty Then
                comboList = sqlDR("sub_code_name")
            Else
                comboList += "|" & sqlDR("sub_code_name")
            End If
        Loop
        sqlDR.Close()

        DBClose()

        Return comboList

    End Function

    Private Function Load_Line(ByVal department As String) As String

        Dim comboList As String = String.Empty
        Dim departmentCode As String = String.Empty

        If DBConnect() = False Then
            Return comboList
            Exit Function
        End If

        Dim strSQL As String = "select sub_code"
        strSQL += " from tb_code_sub"
        strSQL += " where main_code = 'MC00000001'"
        strSQL += " and sub_code_name = '" & department & "';"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            departmentCode = sqlDR("sub_code")
        Loop
        sqlDR.Close()

        strSQL = "select last_code_name"
        strSQL += " from tb_code_last"
        strSQL += " where main_code = 'MC00000001'"
        strSQL += " and sub_code = '" & departmentCode & "';"

        sqlCmd = New MySqlCommand(strSQL, dbConnection1)
        sqlDR = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            If comboList = String.Empty Then
                comboList = sqlDR("last_code_name")
            Else
                comboList += "|" & sqlDR("last_code_name")
            End If
        Loop
        sqlDR.Close()

        DBClose()

        Return comboList

    End Function

    Dim beforeString As String
    Dim beforeDate As String
    Dim beforeDepartment As String
    Dim beforeLine As String

    Private Sub Grid_OrderList_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Grid_OrderList.BeforeEdit

        If e.Row < 3 Or e.Col < 1 Then Exit Sub

        beforeString = Grid_OrderList(e.Row, e.Col)
        beforeDate = Grid_OrderList(e.Row, 10)
        beforeDepartment = Grid_OrderList(e.Row, 11)
        beforeLine = Grid_OrderList(e.Row, 12)

    End Sub

    Private Sub Grid_OrderList_AfterEdit(sender As Object, e As RowColEventArgs) Handles Grid_OrderList.AfterEdit

        If e.Row < 3 Or e.Col < 1 Then Exit Sub

        If beforeString = Grid_OrderList(e.Row, e.Col) Then Exit Sub

        Grid_OrderList.Redraw = False

        If IsNumeric(Grid_OrderList(e.Row, 0)) Then
            If beforeDate = String.Empty And
                beforeDepartment = String.Empty And
                beforeLine = String.Empty Then
                Grid_OrderList(e.Row, 0) = "N"
            Else
                Grid_OrderList(e.Row, 0) = "M"
            End If
        End If

        Dim cs As CellStyle = Grid_OrderList.Styles.Add("Yellow_Cell")
        cs.BackColor = Color.Yellow
        cs.ForeColor = Color.Red
        Dim cs2 As CellStyle = Grid_OrderList.Styles.Add("Normal_Cell")
        cs2.BackColor = Color.White
        cs2.ForeColor = Color.Black

        Grid_OrderList.SetCellStyle(e.Row, e.Col, cs)

        Select Case e.Col
            Case 11
                Grid_OrderList(Grid_OrderList.Row, 12) = String.Empty
        End Select

        Grid_OrderList.AutoSizeCols()

        Grid_OrderList.Redraw = True

        beforeDate = String.Empty
        beforeDepartment = String.Empty
        beforeLine = String.Empty

    End Sub

    Private Sub Grid_OrderList_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_OrderList.MouseClick

        Dim rowSel As Integer = Grid_OrderList.MouseRow
        Grid_OrderList.Row = rowSel

        If e.Button = MouseButtons.Right And rowSel > 2 Then
            'If buttonDisable = True Then
            '    BTN_CellCopy.Enabled = False
            'Else
            '    BTN_CellCopy.Enabled = True
            'End If
            CMS_GridMenu.Show(Grid_OrderList, New Point(e.X, e.Y))
        End If

    End Sub

    Dim copyDate As String = String.Empty
    Dim copyDepartment As String = String.Empty
    Dim copyLine As String = String.Empty
    'Dim buttonDisable As Boolean = False

    Private Sub BTN_CellCopy_Click(sender As Object, e As EventArgs) Handles BTN_CellCopy.Click

        Dim rowSel As Integer = Grid_OrderList.Row

        copyDate = Grid_OrderList(rowSel, 10)
        copyDepartment = Grid_OrderList(rowSel, 11)
        copyLine = Grid_OrderList(rowSel, 12)
        'buttonDisable = True

    End Sub

    Private Sub BTN_CellPaste_Click(sender As Object, e As EventArgs) Handles BTN_CellPaste.Click

        Dim cs As CellStyle = Grid_OrderList.Styles.Add("Yellow_Cell")
        cs.BackColor = Color.Yellow
        cs.ForeColor = Color.Red

        Grid_OrderList.Redraw = False

        For i = 3 To Grid_OrderList.Rows.Count - 1
            If Grid_OrderList.IsCellSelected(i, 1) Then

                'No가 숫자이며 각 셀이 비어 있다면 신규
                If IsNumeric(Grid_OrderList(i, 0)) Then
                    If Grid_OrderList(i, 10) = String.Empty And
                        Grid_OrderList(i, 11) = String.Empty And
                        Grid_OrderList(i, 12) = String.Empty Then
                        Grid_OrderList(i, 0) = "N"
                    Else
                        Grid_OrderList(i, 0) = "M"
                    End If
                End If

                If copyDate = String.Empty Then
                    Grid_OrderList(i, 10) = String.Empty
                Else
                    Grid_OrderList(i, 10) = Format(CDate(copyDate), "yyyy-MM-dd")
                End If
                Grid_OrderList.SetCellStyle(i, 10, cs)
                Grid_OrderList(i, 11) = copyDepartment
                Grid_OrderList.SetCellStyle(i, 10, cs)
                Grid_OrderList(i, 12) = copyLine
                Grid_OrderList.SetCellStyle(i, 12, cs)
            End If
        Next

        Grid_OrderList.AutoSizeCols()
        Grid_OrderList.Redraw = True

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click, BTN_Save2.Click

        For i = 3 To Grid_OrderList.Rows.Count - 1
            If Grid_OrderList(i, 0) = "N" Then
                'If Not IsDate(Grid_OrderList(i, 10)) Or Grid_OrderList(i, 11) = String.Empty Or Grid_OrderList(i, 12) = String.Empty Then
                If Not IsDate(Grid_OrderList(i, 10)) Then
                    MessageBox.Show(Me,
                                    "입력되지 않은 항목이 있습니다." & vbCrLf & "행 번호 : " & i - 2,
                                    msg_form,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
        Next

        If MessageBox.Show(Me,
                           "저장 하시겠습니까?",
                           msg_form,
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        If DBConnect() = False Then Exit Sub

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            For i = 1 To Grid_OrderList.Rows.Count - 1
                If Grid_OrderList(i, 0).ToString = "N" Then
                    strSQL += "insert into tb_mms_production_plan("
                    strSQL += "order_index, start_date, smd_department, smd_line, start_process, order_note, write_date, write_id"
                    strSQL += ") values("
                    strSQL += "'" & Grid_OrderList(i, 1) & "'"
                    strSQL += ",'" & Grid_OrderList(i, 10) & "'"
                    strSQL += ",'" & Grid_OrderList(i, 11) & "'"
                    strSQL += ",'" & Grid_OrderList(i, 12) & "'"
                    strSQL += ",'" & Trim(Grid_OrderList(i, 9).ToString.Split(">")(0)) & "'"
                    strSQL += ",'" & Grid_OrderList(i, 13) & "'"
                    strSQL += ",'" & writeDate & "'"
                    strSQL += ",'" & loginID & "');"
                    strSQL += "update tb_mms_order_register_list set order_status = 'Confirmation of production plan'"
                    strSQL += " where order_index = '" & Grid_OrderList(i, 1) & "';"
                ElseIf Grid_OrderList(i, 0).ToString = "M" Then
                    strSQL += "update tb_mms_production_plan set"
                    strSQL += " start_date = '" & Format(Grid_OrderList(i, 10), "yyyy-MM-dd") & "'"
                    strSQL += ", smd_department = '" & Grid_OrderList(i, 11) & "'"
                    strSQL += ", smd_line = '" & Grid_OrderList(i, 12) & "'"
                    strSQL += ", order_note = '" & Grid_OrderList(i, 13) & "'"
                    strSQL += ", write_date = '" & writeDate & "'"
                    strSQL += ", write_id = '" & loginID & "'"
                    strSQL += " where order_index = '" & Grid_OrderList(i, 1) & "';"
                ElseIf Grid_OrderList(i, 0).ToString = "D" Then
                    strSQL += "delete from tb_mms_production_plan"
                    strSQL += " where order_index = '" & Grid_OrderList(i, 1) & "';"
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

            MSG_Error(Me, ex.Message)
            Exit Sub
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        MSG_Information(Me, "저장완료.")

        'If MSG_Question(Me, "저장완료." & vbCrLf & "생산에 필요한 자재를 요청 하시겠습니까?") = True Then
        '    If frm_Production_Material_Request.ShowDialog = Then

        '    End If
        'End If

        BTN_Search_Click(Nothing, Nothing)
        'WindowClose("") '나중에 활용.

    End Sub

    Public Shared Function searchForm(ByVal formname As String) As Form

        For Each frm As Form In Application.OpenForms
            If frm.Name = formname Then Return frm
        Next

        Return Nothing

    End Function

    Private Sub frm_Production_plan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.C Then
            Dim rowSel As Integer = Grid_OrderList.Row

            copyDate = Grid_OrderList(rowSel, 10)
            copyDepartment = Grid_OrderList(rowSel, 11)
            copyLine = Grid_OrderList(rowSel, 12)
        ElseIf e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V Then
            Dim cs As CellStyle = Grid_OrderList.Styles.Add("Yellow_Cell")
            cs.BackColor = Color.Yellow
            cs.ForeColor = Color.Red

            Grid_OrderList.Redraw = False

            For i = 3 To Grid_OrderList.Rows.Count - 1
                If Grid_OrderList.IsCellSelected(i, 1) Then

                    'No가 숫자이며 각 셀이 비어 있다면 신규
                    If IsNumeric(Grid_OrderList(i, 0)) Then
                        If CStr(Grid_OrderList(i, 10)) = String.Empty And
                        Grid_OrderList(i, 11) = String.Empty And
                        Grid_OrderList(i, 12) = String.Empty Then
                            Grid_OrderList(i, 0) = "N"
                        Else
                            Grid_OrderList(i, 0) = "M"
                        End If
                    End If

                    If copyDate = String.Empty Then
                        Grid_OrderList(i, 10) = String.Empty
                    Else
                        Grid_OrderList(i, 10) = Format(CDate(copyDate), "yyyy-MM-dd")
                    End If
                    Grid_OrderList.SetCellStyle(i, 10, cs)
                    Grid_OrderList(i, 11) = copyDepartment
                    Grid_OrderList.SetCellStyle(i, 11, cs)
                    Grid_OrderList(i, 12) = copyLine
                    Grid_OrderList.SetCellStyle(i, 12, cs)
                End If
            Next

            Grid_OrderList.AutoSizeCols()
            Grid_OrderList.Redraw = True
        End If

    End Sub

    Private Sub BTN_POCancel_Click(sender As Object, e As EventArgs) Handles BTN_POCancel.Click

        Dim rowSel As Integer = Grid_OrderList.Row
        Dim orderIndex As String = Grid_OrderList(rowSel, 1)

        If MSG_Question(Me, orderIndex & " 을 주문접수 상태로 되돌리시겠습니까?") = False Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        If DBConnect() = False Then Exit Sub

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            strSQL += "call sp_mms_ready_material_downdate('" & orderIndex & "');"

            strSQL = "update tb_mms_order_register_list"
            strSQL += " set management_no = null"
            strSQL += " , order_status = 'Order Confirm'"
            strSQL += " where order_index = '" & orderIndex & "'"
            strSQL += ";"

            strSQL += "delete from tb_mms_production_plan"
            strSQL += " where order_index = '" & orderIndex & "'"
            strSQL += ";"

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
            MessageBox.Show(Me,
                            ex.Message,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Exit Sub
        End Try

        DBClose()

        Thread_LoadingFormEnd()
        MessageBox.Show(Me,
                        "저장완료.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

        BTN_Search_Click(Nothing, Nothing)

    End Sub

    Private Sub BTN_Material_Request_Click(sender As Object, e As EventArgs) Handles BTN_Material_Request.Click

        Dim rowSel As Integer = Grid_OrderList.Row
        Dim orderIndex As String = Grid_OrderList(rowSel, 1)
        Dim itemCode As String = Grid_OrderList(rowSel, 6)

        frm_Production_Material_Request.LB_ItemCode.Text = itemCode
        frm_Production_Material_Request.LB_OrderIndex.Text = orderIndex

        Dim dialogResult As DialogResult = frm_Production_Material_Request.ShowDialog

        If dialogResult = DialogResult.OK Then
            MSG_Information(Me, "요청을 완료 하였습니다.")
        ElseIf dialogResult = DialogResult.Abort Then
            MSG_Information(Me, "요청이 취소 되었습니다.")
        ElseIf dialogResult = DialogResult.No Then
            '닫기를 눌러 창을 닫았을때
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        frm_DeviceData.MdiParent = frm_Main
        If Not frm_DeviceData.Visible Then frm_DeviceData.Show()
        frm_DeviceData.Focus()

    End Sub


    'Dim _ptDown As Point
    'Dim _cellDrag As C1.Win.C1FlexGrid.CellRange
    'Dim _cellRow As C1.Win.C1FlexGrid.CellRange
    'Dim _sendGrid As C1FlexGrid

    'Private Sub Grid_OrderList_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Grid_OrderList.DragEnter

    '    If e.Data.GetDataPresent(GetType(C1.Win.C1FlexGrid.CellRange)) Then
    '        ' 사용자 셀 드래그
    '        e.Effect = DragDropEffects.Move
    '    End If

    'End Sub

    'Private Sub Grid_OrderList_MouseDown(sender As Object, e As MouseEventArgs) Handles Grid_OrderList.MouseDown

    '    _ptDown = New Point(e.X, e.Y)
    '    _cellDrag = sender.GetCellRange(sender.MouseRow, sender.MouseCol)
    '    _cellRow = sender.GetCellRange(sender.MouseRow, 0, sender.MouseRow, sender.Cols.Count - 1)
    '    _sendGrid = sender

    'End Sub

    'Private Sub Grid_OrderList_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Grid_OrderList.MouseMove

    '    ' 드래그를 시작해야 하는지 확인합니다
    '    If e.Button And MouseButtons.Left Then
    '        ' 마우스가 시작된 동일한 셀 위에 있는지, 셀이 비어 있지 않은지 확인합니다
    '        If _cellDrag.r1 = sender.MouseRow AndAlso _cellDrag.c1 = sender.MouseCol AndAlso
    '            _cellDrag.r1 > 0 And _cellDrag.c1 > -1 AndAlso
    '            Not (_cellDrag.Data Is Nothing) Then
    '            ' 마우스가 임계값을 넘어 이동했는지 확인한 다음 드래그를 시작합니다
    '            If Math.Abs(_ptDown.X - e.X) + Math.Abs(_ptDown.Y - e.Y) > 5 Then
    '                ' 끌어서 놓기 작업을 수행합니다
    '                Dim data As New DataObject(_cellDrag)
    '                Dim effects As DragDropEffects = sender.DoDragDrop(data, DragDropEffects.Move)
    '                ' 이동한 경우 원래 값을 지웁니다(여기서 수정 행을 삭제)
    '                If effects = DragDropEffects.Move Then
    '                    '_cellDrag.Data = Nothing
    '                    'sender.RemoveItem(_cellDrag.r1)
    '                End If
    '            End If
    '        End If
    '    End If

    'End Sub

    'Private Sub C1FlexGrid1_DragDrop(sender As Object, e As DragEventArgs) Handles Grid_OrderList.DragDrop

    '    If _sendGrid.Name = sender.Name Then
    '        MsgBox("같은 그리드다")
    '    Else
    '        MsgBox(_cellRow.Clip.ToString.Split(vbTab)(4))
    '        _sendGrid.RemoveItem(_cellDrag.r1)
    '    End If

    'End Sub

    'Private newLabel() As Label

    'Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

    '    If IsNothing(newLabel) Then
    '        ReDim newLabel(0)
    '        newLabel(0) = New Label
    '        newLabel(0).Font = New Font("굴림", 9)
    '        newLabel(0).Text = "ABCD"
    '        newLabel(0).Parent = SplitContainer1.Panel2
    '        newLabel(0).Location = New Point(33, 290)
    '        newLabel(0).AutoSize = True
    '        Me.SplitContainer1.Panel2.Controls.Add(newLabel(0))
    '    Else
    '        ReDim Preserve newLabel(newLabel.Length)
    '        newLabel(newLabel.Length - 1) = New Label
    '        newLabel(newLabel.Length - 1).Font = New Font("굴림", 9)
    '        newLabel(newLabel.Length - 1).Text = "ABCD"
    '        newLabel(newLabel.Length - 1).Parent = SplitContainer1.Panel2
    '        newLabel(newLabel.Length - 1).Location = New Point(33, 290)
    '        newLabel(newLabel.Length - 1).AutoSize = True
    '        Me.SplitContainer1.Panel2.Controls.Add(newLabel(newLabel.Length - 1))
    '    End If

    'End Sub
End Class