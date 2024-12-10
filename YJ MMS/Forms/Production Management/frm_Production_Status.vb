Imports C1.Win.C1FlexGrid
Imports MySqlConnector

Public Class frm_Production_Status
    Private Sub frm_Production_Status_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        Load_CustomerList()

        ComboBox1.SelectedIndex = 0

        DateTimePicker1.Value = Format(Now, "yyyy-MM-01")
        DateTimePicker2.Value = DateAdd(DateInterval.Day, -1, CDate(Format(DateAdd(DateInterval.Month, 1, Now), "yyyy-MM-01")))

    End Sub

    Private Sub Grid_Setting()

        With Grid_OrderList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.Columns
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 19
            .Cols.Fixed = 1
            .Rows.Count = 2
            .Rows.Fixed = 2
            For i = 0 To .Cols.Count - 1
                .Cols(i).AllowMerging = True
                .Cols(i).StyleNew.TextAlign = TextAlignEnum.CenterCenter
            Next
            For i = 0 To .Rows.Count - 1
                .Rows(i).AllowMerging = True
            Next
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Cols(5).DataType = GetType(Integer)
            .Cols(5).Format = "#,##0"
            .Cols(6).DataType = GetType(Date)
            .Cols(6).Format = "yyyy-MM-dd"
            .Cols(8).DataType = GetType(Integer)
            .Cols(8).Format = "#,##0"
            .Cols(9).DataType = GetType(Integer)
            .Cols(9).Format = "#,##0"
            .Cols(10).DataType = GetType(Integer)
            .Cols(10).Format = "#,##0"
            .Cols(11).DataType = GetType(DateTime)
            .Cols(11).Format = "yyyy-MM-dd HH:mm:ss"
            .Cols(12).DataType = GetType(DateTime)
            .Cols(12).Format = "yyyy-MM-dd HH:mm:ss"
            .Cols(14).DataType = GetType(Integer)
            .Cols(14).Format = "#,##0"
            .Cols(15).DataType = GetType(Integer)
            .Cols(16).Format = "#,##0"
            .Cols(16).DataType = GetType(Integer)
            .Cols(16).Format = "#,##0"
            .Cols(17).DataType = GetType(DateTime)
            .Cols(17).Format = "yyyy-MM-dd HH:mm:ss"
            .Cols(18).DataType = GetType(DateTime)
            .Cols(18).Format = "yyyy-MM-dd HH:mm:ss"
            .Cols.Frozen = 7
        End With

        With Grid_OrderList
            Dim rngM As CellRange = .GetCellRange(0, 0, 1, 0)
            rngM.Data = "No"
            rngM = .GetCellRange(0, 1, 1, 1)
            rngM.Data = "주문번호"
            rngM = .GetCellRange(0, 2, 1, 2)
            rngM.Data = "고객사"
            rngM = .GetCellRange(0, 3, 1, 3)
            rngM.Data = "품번"
            rngM = .GetCellRange(0, 4, 1, 4)
            rngM.Data = "품명"
            rngM = .GetCellRange(0, 5, 1, 5)
            rngM.Data = "주문수량"
            rngM = .GetCellRange(0, 6, 1, 6)
            rngM.Data = "납품요청일자"
            rngM = .GetCellRange(0, 7, 1, 7)
            rngM.Data = "상태"
            rngM = .GetCellRange(0, 8, 0, 13)
            rngM.Data = "SMD"
            rngM = .GetCellRange(0, 14, 0, 18)
            rngM.Data = "Wave/Selective"
        End With

        Grid_OrderList(1, 8) = "생산수량"
        Grid_OrderList(1, 9) = "불량수량"
        Grid_OrderList(1, 10) = "공정불량 PPM"
        Grid_OrderList(1, 11) = "시작일자"
        Grid_OrderList(1, 12) = "종료일자"
        Grid_OrderList(1, 13) = "SMD Line"
        Grid_OrderList(1, 14) = "생산수량"
        Grid_OrderList(1, 15) = "불량수량"
        Grid_OrderList(1, 16) = "공정불량 PPM"
        Grid_OrderList(1, 17) = "시작일자"
        Grid_OrderList(1, 18) = "종료일자"

        For i = 0 To Grid_OrderList.Cols.Count - 1
            Grid_OrderList.Cols(i).StyleNew.TextAlign = TextAlignEnum.CenterCenter
        Next

        Grid_OrderList.AutoSizeCols()

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

        'If TB_CustomerCode.Text = String.Empty Then
        '    MessageBox.Show(Me,
        '                    "고객사를 먼저 선택하여 주십시오.",
        '                    msg_form,
        '                    MessageBoxButtons.OK,
        '                    MessageBoxIcon.Information)
        '    Exit Sub
        'End If

        Thread_LoadingFormStart(Me)

        Grid_Setting()

        Grid_OrderList.Redraw = False
        Grid_OrderList.Rows.Count = 2

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_order_status(0"
        strSQL += ",'" & TB_CustomerCode.Text & "'"
        strSQL += ",'" & ComboBox1.Text & "'"
        strSQL += ",'" & Format(DateTimePicker1.Value, "yyyy-MM-dd 00:00:00") & "'"
        strSQL += ",'" & Format(DateTimePicker2.Value, "yyyy-MM-dd 23:59:59") & "'"
        strSQL += ",'" & TextBox1.Text & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_OrderList.Rows.Count - 1
            insert_String += vbTab & sqlDR("order_index")
            insert_String += vbTab & sqlDR("customer_name")
            insert_String += vbTab & sqlDR("item_code")
            insert_String += vbTab & sqlDR("item_name")
            insert_String += vbTab & sqlDR("modify_order_quantity")
            insert_String += vbTab & sqlDR("date_of_delivery")
            insert_String += vbTab & sqlDR("order_status")
            insert_String += vbTab & sqlDR("smd_production_qty")
            insert_String += vbTab & sqlDR("smd_fault_qty")
            insert_String += vbTab & (CDbl(sqlDR("smd_fault_qty")) / CDbl(sqlDR("smd_production_qty"))) * 1000000
            insert_String += vbTab & sqlDR("smd_start_date")
            insert_String += vbTab & sqlDR("smd_end_date")
            insert_String += vbTab & sqlDR("smd_line")
            insert_String += vbTab & sqlDR("ws_production_qty")
            insert_String += vbTab & sqlDR("ws_fault_qty")
            insert_String += vbTab & (CDbl(sqlDR("ws_fault_qty")) / CDbl(sqlDR("ws_production_qty"))) * 1000000
            insert_String += vbTab & sqlDR("ws_start_date")
            insert_String += vbTab & sqlDR("ws_end_date")

            Grid_OrderList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_OrderList.AutoSizeCols()
        Grid_OrderList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_OrderList_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_OrderList.MouseClick

        Dim selRow As Integer = Grid_OrderList.MouseRow

        If selRow > 1 And e.Button = MouseButtons.Right Then
            Grid_OrderList.Row = selRow
            Grid_Menu.Show(Grid_OrderList, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub BTN_SMD_Information_Click(sender As Object, e As EventArgs) Handles BTN_SMD_Information.Click

        Dim selRow As Integer = Grid_OrderList.Row
        Dim orderIndex As String = Grid_OrderList(selRow, 1)

        frm_Production_Information_SMD.orderIndex = orderIndex
        If Not frm_Production_Information_SMD.Visible Then frm_Production_Information_SMD.Show()
        frm_Production_Information_SMD.Focus()

    End Sub

    Private Sub BTN_WS_Information_Click(sender As Object, e As EventArgs) Handles BTN_WS_Information.Click

        Dim selRow As Integer = Grid_OrderList.Row
        Dim orderIndex As String = Grid_OrderList(selRow, 1)

        frm_Production_Information_WS.orderIndex = orderIndex
        If Not frm_Production_Information_WS.Visible Then frm_Production_Information_WS.Show()
        frm_Production_Information_WS.Focus()

    End Sub
End Class