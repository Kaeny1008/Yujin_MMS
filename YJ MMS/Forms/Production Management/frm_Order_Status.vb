Imports C1.Win.C1FlexGrid
Imports MySqlConnector

Public Class frm_Order_Status
    Private Sub frm_Order_Status_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        Load_CustomerList()

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
            .Cols.Count = 13
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Cols(8).DataType = GetType(Date)
            .Cols(8).Format = "yyyy-MM-dd"
            .Cols(9).DataType = GetType(Date)
            .Cols(9).Format = "yyyy-MM-dd"
            .Cols(10).DataType = GetType(Integer)
            .Cols(10).Format = "#,##0"
        End With

        Grid_OrderList(0, 0) = "No"
        Grid_OrderList(0, 1) = "주문번호"
        Grid_OrderList(0, 2) = "고객사 코드"
        Grid_OrderList(0, 3) = "고객사"
        Grid_OrderList(0, 4) = "고객사"
        Grid_OrderList(0, 5) = "품번코드"
        Grid_OrderList(0, 6) = "품번"
        Grid_OrderList(0, 7) = "품명"
        Grid_OrderList(0, 8) = "등록일자"
        Grid_OrderList(0, 9) = "납품 요청일자"
        Grid_OrderList(0, 10) = "주문수량"
        Grid_OrderList(0, 11) = "주문상태"
        Grid_OrderList(0, 12) = "관리번호"

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

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart(Me)

        Grid_Setting()

        Grid_OrderList.Redraw = False
        Grid_OrderList.Rows.Count = 1

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_order_status(7"
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
            insert_String += vbTab & sqlDR("customer_code")
            insert_String += vbTab & sqlDR("customer_name")
            insert_String += vbTab & sqlDR("item_section")
            insert_String += vbTab & sqlDR("model_code")
            insert_String += vbTab & sqlDR("item_code")
            insert_String += vbTab & sqlDR("item_name")
            insert_String += vbTab & sqlDR("write_date")
            insert_String += vbTab & sqlDR("date_of_delivery")
            insert_String += vbTab & sqlDR("modify_order_quantity")
            insert_String += vbTab & sqlDR("order_status")
            insert_String += vbTab & sqlDR("management_no")

            Grid_OrderList.AddItem(insert_String)
            Dim rowColor As Color = Color.White
            If sqlDR("order_status").Equals("생산완료") Then
                rowColor = Color.Cornsilk 
            ElseIf sqlDR("order_status").Equals("생산중") Then
                rowColor = Color.LightCoral 
            End If
            Grid_OrderList.Rows(Grid_OrderList.Rows.Count - 1).StyleNew.BackColor = rowColor
        Loop
        sqlDR.Close()

        DBClose()

        Grid_OrderList.AutoSizeCols()
        Grid_OrderList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub Grid_OrderList_MouseEnter(sender As Object, e As EventArgs) Handles Grid_OrderList.MouseEnter

    End Sub

    Private Sub Grid_OrderList_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_OrderList.MouseClick

        Dim selRow As Integer = Grid_OrderList.MouseRow

        If selRow < 1 Then Exit Sub

        If e.Button = MouseButtons.Right Then
            Grid_OrderList.Row = selRow
            Grid_Menu.Show(Grid_OrderList, New Point(e.X, e.Y))
        End If

    End Sub
End Class