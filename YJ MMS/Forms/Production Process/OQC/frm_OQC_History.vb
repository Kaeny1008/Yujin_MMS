Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_OQC_History
    Private Sub frm_OQC_History_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        Load_CustomerList()

        DateTimePicker1.Value = Format(Now, "yyyy-MM-01")
        DateTimePicker2.Value = Now

    End Sub

    Private Sub Grid_Setting()

        With Grid_HistoryList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.Columns
            .AllowMergingFixed = AllowMergingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 8
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
            .Cols(5).DataType = GetType(Integer)
            .Cols(5).Format = "#,##0"
            .Cols(6).DataType = GetType(Integer)
            .Cols(6).Format = "#,##0"
            .Cols(7).DataType = GetType(Integer)
            .Cols(7).Format = "#,##0"
        End With

        Grid_HistoryList(0, 0) = "No."
        Grid_HistoryList(0, 1) = "주문번호"
        Grid_HistoryList(0, 2) = "고객사"
        Grid_HistoryList(0, 3) = "품번"
        Grid_HistoryList(0, 4) = "품명"
        Grid_HistoryList(0, 5) = "주문수량"
        Grid_HistoryList(0, 6) = "검사수량"
        Grid_HistoryList(0, 7) = "폐기수량"

        For i = 0 To Grid_HistoryList.Cols.Count - 1
            Grid_HistoryList.Cols(i).StyleNew.TextAlign = TextAlignEnum.CenterCenter
        Next

        Grid_HistoryList.AutoSizeCols()

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

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart()

        Grid_HistoryList.Redraw = False
        Grid_HistoryList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_oqc_history(0"
        strSQL += ",'" & TextBox1.Text & "'"
        strSQL += ",'" & Format(DateTimePicker1.Value, "yyyy-MM-dd 00:00:00") & "'"
        strSQL += ",'" & Format(DateTimePicker2.Value, "yyyy-MM-dd 23:59:59") & "'"
        strSQL += ",'" & TB_CustomerCode.Text & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_HistoryList.Rows.Count
            insert_String += vbTab & sqlDR("order_index")
            insert_String += vbTab & sqlDR("customer_name")
            insert_String += vbTab & sqlDR("item_code")
            insert_String += vbTab & sqlDR("item_name")
            insert_String += vbTab & sqlDR("modify_order_quantity")
            insert_String += vbTab & sqlDR("completed_quantity")
            insert_String += vbTab & sqlDR("discard_quantity")
            insert_String += vbTab & sqlDR("inspector")

            Grid_HistoryList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_HistoryList.AutoSizeCols()
        Grid_HistoryList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_HistoryList_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_HistoryList.MouseClick

        Dim selRow As Integer = Grid_HistoryList.MouseRow

        If selRow > 0 And e.Button = MouseButtons.Right Then
            Grid_HistoryList.Row = selRow
            Grid_Menu.Show(Grid_HistoryList, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub BTN_BoxInformation_Click(sender As Object, e As EventArgs) Handles BTN_BoxInformation.Click

        Dim orderIndex As String = Grid_HistoryList(Grid_HistoryList.Row, 1)
        frm_OQC_History_Box.orderIndex = orderIndex
        frm_OQC_History_Box.Show()

    End Sub
End Class