Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Delivery_Register
    Private Sub frm_Delivery_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
            .Cols.Count = 12
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
            .Cols(9).Format = "#,##0"
        End With

        Grid_POList(0, 0) = "No"
        Grid_POList(0, 1) = "선택"
        Grid_POList(0, 2) = "주문번호"
        Grid_POList(0, 3) = "품번"
        Grid_POList(0, 4) = "품명"
        Grid_POList(0, 5) = "규격"
        Grid_POList(0, 6) = "주문일자"
        Grid_POList(0, 7) = "요청 납품일자"
        Grid_POList(0, 8) = "주문수량"
        Grid_POList(0, 9) = "출하검사 완료수량"
        Grid_POList(0, 10) = "납품잔량"
        Grid_POList(0, 11) = "Loader PCB 사용여부"
        Grid_POList.AutoSizeCols()

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

    Public Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        If TB_CustomerCode.Text = String.Empty Then
            MSG_Information(Me, "고객사를 먼저 선택하여 주십시오.")
            Exit Sub
        End If

        Thread_LoadingFormStart(Me)

        Grid_POList.Redraw = False
        Grid_POList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_delivery(0"
        strSQL += ",'" & TB_CustomerCode.Text & "'"
        strSQL += ",'" & TB_ItemCode.Text & "'"
        strSQL += ",'" & TB_ItemName.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_POList.Rows.Count
            insert_String += vbTab
            insert_String += vbTab & sqlDR("order_index")
            insert_String += vbTab & sqlDR("item_code")
            insert_String += vbTab & sqlDR("item_name")
            insert_String += vbTab & sqlDR("item_spec")
            insert_String += vbTab & sqlDR("order_date")
            insert_String += vbTab & sqlDR("date_of_delivery")
            insert_String += vbTab & sqlDR("modify_order_quantity")
            insert_String += vbTab & sqlDR("completed_quantity")
            insert_String += vbTab & sqlDR("remaining_qty")
            insert_String += vbTab & sqlDR("loader_pcb")
            Grid_POList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_POList.AutoSizeCols()
        Grid_POList.Redraw = True

        BTN_Save.Enabled = True

        Thread_LoadingFormEnd()

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

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        Dim a As frm_Delivery_Register_Check = New frm_Delivery_Register_Check
        a.Show()
        a.Visible = False

        Dim checkCount As Integer = 0
        Dim loaderPCB_Add As Boolean = False

        For i = 1 To Grid_POList.Rows.Count - 1
            If Grid_POList.GetCellCheck(i, 1) = CheckEnum.Checked Then
                Dim insertString As String
                insertString = a.Grid_POList.Rows.Count
                insertString += vbTab
                insertString += vbTab & Grid_POList(i, 2)
                insertString += vbTab & Grid_POList(i, 3)
                insertString += vbTab & Grid_POList(i, 4)
                insertString += vbTab & Grid_POList(i, 5)
                insertString += vbTab & Grid_POList(i, 6)
                insertString += vbTab & Grid_POList(i, 7)
                insertString += vbTab & Grid_POList(i, 8)
                insertString += vbTab & Grid_POList(i, 10)
                insertString += vbTab & Grid_POList(i, 10)
                insertString += vbTab & 0

                a.Grid_POList.AddItem(insertString)
                checkCount += 1

                'Loader Pcb사용의 경우 해당 PO를 불러와서 추가한다.
                If Grid_POList(i, 11) = "사용" Then
                    Dim loaderPCB_OrderIndex As String = Grid_POList(i, 2) & "-L"
                    Dim loadSplit() As String = Load_LoaderPCB_Order(loaderPCB_OrderIndex).Split(vbTab)
                    insertString = a.Grid_POList.Rows.Count
                    insertString += vbTab
                    insertString += vbTab & loadSplit(0)
                    insertString += vbTab & loadSplit(1)
                    insertString += vbTab & loadSplit(2)
                    insertString += vbTab & loadSplit(3)
                    insertString += vbTab & loadSplit(4)
                    insertString += vbTab & loadSplit(5)
                    insertString += vbTab & loadSplit(6)
                    insertString += vbTab & loadSplit(9)
                    insertString += vbTab & loadSplit(9)
                    insertString += vbTab & 0

                    a.Grid_POList.AddItem(insertString)
                    checkCount += 1
                    loaderPCB_Add = True
                End If
            End If
        Next
        a.Grid_POList.AutoSizeCols()

        If checkCount > 99 Then
            a.Dispose()
            MSG_Information(Me, "총 주문 선택은 99개를 넘을수 없습니다.")
        End If

        If a.Grid_POList.Rows.Count = 1 Then
            a.Dispose()
            MSG_Information(Me, "선택된 주문이 없습니다.")
        Else
            If loaderPCB_Add = True Then
                MSG_Information(Me, "Loader PCB 주문이 자동 추가되었습니다." & vbCrLf &
                                "주문번호 일치여부를 확인하여 주십시오." & vbCrLf & vbCrLf &
                                "예) 선택 : PO202404010002-0005" & vbCrLf &
                                "자동추가 : PO202404010002-0005-L")
            End If
            a.Visible = True
            'a.TopMost = True
        End If

    End Sub

    Private Function Load_LoaderPCB_Order(ByVal order_index As String) As String

        DBConnect()
        Dim insert_String As String = String.Empty

        Dim strSQL As String = "call sp_mms_delivery(5"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & order_index & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            insert_String = sqlDR("order_index")
            insert_String += vbTab & sqlDR("item_code")
            insert_String += vbTab & sqlDR("item_name")
            insert_String += vbTab & sqlDR("item_spec")
            insert_String += vbTab & sqlDR("order_date")
            insert_String += vbTab & sqlDR("date_of_delivery")
            insert_String += vbTab & sqlDR("modify_order_quantity")
            insert_String += vbTab & sqlDR("completed_quantity")
            insert_String += vbTab & sqlDR("loader_pcb")
            insert_String += vbTab & sqlDR("remaining_qty")
        Loop
        sqlDR.Close()

        DBClose()

        Return insert_String

    End Function
End Class