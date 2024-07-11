Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Delivery_History

    Dim selDeliveryNo As String

    Private Sub frm_Delivery_History_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DateTimePicker1.Value = Format(Now, "yyyy-MM-01")
        DateTimePicker2.Value = Format(Now, "yyyy-MM-dd")

        Grid_Setting()

        Load_CustomerList()

    End Sub

    Private Sub Grid_Setting()

        With Grid_POList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 11
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
        Grid_POList(0, 9) = "납품수량"
        Grid_POList(0, 10) = "비고"
        Grid_POList.AutoSizeCols()

        With Grid_ShipList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 4
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
            .Cols(3).DataType = GetType(Date)
            .Cols(3).Format = "yyyy-MM-dd HH:mm:ss"
            .Cols(3).StyleNew.TextAlign = TextAlignEnum.CenterCenter
        End With

        Grid_ShipList(0, 0) = "No"
        Grid_ShipList(0, 1) = "전표번호"
        Grid_ShipList(0, 2) = "고객사"
        Grid_ShipList(0, 3) = "납품일자"
        Grid_ShipList.AutoSizeCols()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

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

        Dim strSQL As String = "select customer_code"
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

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart(Me)

        Grid_ShipList.Redraw = False
        Grid_ShipList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_delivery(3"
        strSQL += ",'" & TB_CustomerCode.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & Format(DateTimePicker1.Value, "yyyy-MM-dd 00:00:00") & "'"
        strSQL += ", '" & Format(DateTimePicker2.Value, "yyyy-MM-dd 23:59:59") & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_ShipList.Rows.Count
            insert_String += vbTab & sqlDR("delivery_no")
            insert_String += vbTab & sqlDR("customer_name")
            insert_String += vbTab & sqlDR("write_date")
            Grid_ShipList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_ShipList.AutoSizeCols()
        Grid_ShipList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_ShipList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Grid_ShipList.MouseDoubleClick

        Dim selRow As Integer = Grid_ShipList.MouseRow

        If e.Button = MouseButtons.Left And selRow > 0 Then
            selDeliveryNo = Grid_ShipList(selRow, 1)
            Thread_LoadingFormStart(Me)

            Grid_POList.Redraw = False
            Grid_POList.Rows.Count = 1

            DBConnect()

            Dim strSQL As String = "call sp_mms_delivery(4"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", '" & selDeliveryNo & "'"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ")"

            Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
            Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

            Do While sqlDR.Read
                Dim insert_String As String = Grid_POList.Rows.Count
                insert_String += vbTab & sqlDR("po_split")
                insert_String += vbTab & sqlDR("po_no")
                insert_String += vbTab & sqlDR("item_code")
                insert_String += vbTab & sqlDR("item_name")
                insert_String += vbTab & sqlDR("item_spec")
                insert_String += vbTab & sqlDR("order_date")
                insert_String += vbTab & sqlDR("date_of_delivery")
                insert_String += vbTab & sqlDR("modify_order_quantity")
                insert_String += vbTab & sqlDR("delivery_qty")
                insert_String += vbTab & sqlDR("history_note")

                Grid_POList.AddItem(insert_String)
            Loop
            sqlDR.Close()

            DBClose()

            Grid_POList.AutoSizeCols()
            Grid_POList.Redraw = True

            Thread_LoadingFormEnd()
        End If

    End Sub

    Private Sub Grid_POList_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_POList.MouseClick

        If e.Button = MouseButtons.Right Then
            If Not Grid_POList.Rows.Count = 1 Then
                Grid_Menu.Show(Grid_POList, New Point(e.X, e.Y))
            End If
        End If

    End Sub

    Private Sub BTN_Reprint_Click(sender As Object, e As EventArgs) Handles BTN_Reprint.Click

        If MSG_Question(Me, "전표를 재발행 하시겠습니까?") = False Then Exit Sub

        Ship_Report_Print(selDeliveryNo)

    End Sub
End Class