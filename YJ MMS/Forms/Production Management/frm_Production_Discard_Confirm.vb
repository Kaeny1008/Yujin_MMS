Imports C1.Win.C1FlexGrid
Imports MySqlConnector

Public Class frm_Production_Discard_Confirm
    Private Sub frm_Production_Discard_Confirm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        frm_Main.Timer1.Stop()
        If frm_DiscardAlarm.Visible Then frm_DiscardAlarm.Close()

        DateTimePicker1.Value = Format(Now, "yyyy-MM-01")
        DateTimePicker2.Value = Format(Now, "yyyy-MM-dd")

        CB_ConfirmStatus.SelectedIndex = 0

        Grid_Setting()

        Load_CustomerList()

    End Sub

    Private Sub Grid_Setting()

        With Grid_ConfirmList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.Columns
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 16
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = False
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Cols(2).DataType = GetType(DateTime)
            .Cols(2).Format = "yyyy-MM-dd HH:mm:ss"
            .Cols(11).DataType = GetType(DateTime)
            .Cols(11).Format = "yyyy-MM-dd HH:mm:ss"
            .Cols(13).DataType = GetType(DateTime)
            .Cols(13).Format = "yyyy-MM-dd HH:mm:ss"
            .Cols(15).Visible = False
        End With

        Grid_ConfirmList(0, 0) = "No"
        Grid_ConfirmList(0, 1) = "관리번호"
        Grid_ConfirmList(0, 2) = "등록일자"
        Grid_ConfirmList(0, 3) = "모델코드"
        Grid_ConfirmList(0, 4) = "고객사"
        Grid_ConfirmList(0, 5) = "품번"
        Grid_ConfirmList(0, 6) = "품명"
        Grid_ConfirmList(0, 7) = "발생 공정"
        Grid_ConfirmList(0, 8) = "작업면"
        Grid_ConfirmList(0, 9) = "Board No."
        Grid_ConfirmList(0, 10) = "등록자"
        Grid_ConfirmList(0, 11) = "확정일자"
        Grid_ConfirmList(0, 12) = "확정자"
        Grid_ConfirmList(0, 13) = "거절일자"
        Grid_ConfirmList(0, 14) = "거절자"
        Grid_ConfirmList(0, 15) = "History Index"

        Grid_ConfirmList.AutoSizeCols()

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

    Public Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart(Me)

        Grid_ConfirmList.Redraw = False
        Grid_ConfirmList.Rows.Count = 1

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_discard_register(1"
        strSQL += ", '" & CB_ConfirmStatus.Text & "'"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ", '" & Format(DateTimePicker1.Value, "yyyy-MM-dd 00:00:00") & "'"
        strSQL += ", '" & Format(DateTimePicker2.Value, "yyyy-MM-dd 23:59:59") & "'"
        strSQL += ", '" & TB_ItemCode.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = Grid_ConfirmList.Rows.Count
            insertString += vbTab & sqlDR("discard_index")
            insertString += vbTab & sqlDR("write_date")
            insertString += vbTab & sqlDR("model_code")
            insertString += vbTab & sqlDR("customer_name")
            insertString += vbTab & sqlDR("item_code")
            insertString += vbTab & sqlDR("item_name")
            insertString += vbTab & sqlDR("process_name")
            insertString += vbTab & sqlDR("work_side")
            insertString += vbTab & sqlDR("board_no")
            insertString += vbTab & sqlDR("write_id")
            insertString += vbTab & sqlDR("confirm_date")
            insertString += vbTab & sqlDR("confirm_id")
            insertString += vbTab & sqlDR("cancel_date")
            insertString += vbTab & sqlDR("cancel_id")
            insertString += vbTab & sqlDR("history_index")

            Grid_ConfirmList.AddItem(insertString)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_ConfirmList.AutoSizeCols()
        Grid_ConfirmList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_ConfirmList_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_ConfirmList.MouseClick

        Dim selRow As Integer = Grid_ConfirmList.MouseRow

        If e.Button = MouseButtons.Right And selRow > 0 Then
            Grid_ConfirmList.Row = selRow
            Grid_Menu.Show(Grid_ConfirmList, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub BTN_Confirm_Click(sender As Object, e As EventArgs) Handles BTN_Confirm.Click

        Dim selRow As Integer = Grid_ConfirmList.Row
        Dim discardIndex As String = Grid_ConfirmList(selRow, 1)
        Dim historyIndex As String = Grid_ConfirmList(selRow, 15)

        frm_Production_Discard_Information.discardIndex = discardIndex
        frm_Production_Discard_Information.historyIndex = historyIndex

        If Not frm_Production_Discard_Information.Visible Then frm_Production_Discard_Information.Show()
        frm_Production_Discard_Information.Focus()

    End Sub

    Private Sub frm_Production_Discard_Confirm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If frm_Main.discard_Alarm = True Then
            frm_Main.Timer1.Start()
        End If

    End Sub

    Private Sub frm_Production_Discard_Confirm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

        If frm_Main.discard_Alarm = True Then
            frm_Main.Timer1.Start()
        End If

    End Sub

    Private Sub frm_Production_Discard_Confirm_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate

        If frm_Main.discard_Alarm = True Then
            frm_Main.Timer1.Start()
        End If

    End Sub
End Class