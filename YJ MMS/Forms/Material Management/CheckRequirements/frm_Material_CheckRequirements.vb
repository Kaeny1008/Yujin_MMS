Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Material_CheckRequirements
    Private Sub frm_Material_CheckRequirements_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()
        Load_CustomerList()

    End Sub

    Private Sub Grid_Setting()

        With Grid_OrderList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 7
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            Grid_OrderList(0, 0) = "No"
            Grid_OrderList(0, 1) = "선택"
            Grid_OrderList(0, 2) = "Order Index"
            Grid_OrderList(0, 3) = "고객사"
            Grid_OrderList(0, 4) = "모델코드"
            Grid_OrderList(0, 5) = "품번"
            Grid_OrderList(0, 6) = "주문수량"
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
        End With

        With Grid_MaterialList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 10
            .Cols.Fixed = 1
            .Rows.Count = 2
            .Rows.Fixed = 2
            For i = 0 To .Cols.Count - 1
                .Cols(i).AllowMerging = True
            Next
            .Rows(0).AllowMerging = True
            '.Rows(1).AllowMerging = True
            Dim rngM As CellRange = .GetCellRange(0, 0, 1, 0)
            rngM.Data = "No"
            rngM = .GetCellRange(0, 1, 1, 1)
            rngM.Data = "자재코드"
            rngM = .GetCellRange(0, 2, 0, 7)
            rngM.Data = "재고"
            Grid_MaterialList(1, 2) = "기초재고"
            Grid_MaterialList(1, 3) = "입고"
            Grid_MaterialList(1, 4) = "Loss"
            Grid_MaterialList(1, 5) = "납품"
            Grid_MaterialList(1, 6) = "계획대기"
            Grid_MaterialList(1, 7) = "생산(중, 완료)"
            rngM = .GetCellRange(0, 8, 1, 8)
            rngM.Data = "필요수량"
            rngM = .GetCellRange(0, 9, 1, 9)
            rngM.Data = "미과출"
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
        End With

    End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

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

    Private Sub Grid_OrderList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Grid_OrderList.MouseDoubleClick

        Dim selRow As Integer = Grid_OrderList.MouseRow

        If e.Button = MouseButtons.Left And selRow > 0 Then
            If Grid_OrderList.GetCellCheck(selRow, 1) = CheckEnum.Checked Then
                Grid_OrderList.SetCellCheck(selRow, 1, CheckEnum.Unchecked)
            Else
                Grid_OrderList.SetCellCheck(selRow, 1, CheckEnum.Checked)
            End If
        End If

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

    Private Sub BTN_Check_Click(sender As Object, e As EventArgs) Handles BTN_Check.Click

        Thread_LoadingFormStart()

        Grid_MaterialList.Redraw = False
        Grid_MaterialList.Rows.Count = 2
        Grid_MaterialList.Cols.Count = 10

        Dim checkCount As Integer = 0
        Dim checkModelCode As String = String.Empty

        For i = 1 To Grid_OrderList.Rows.Count - 1
            If Grid_OrderList.GetCellCheck(i, 1) = CheckEnum.Checked Then
                checkCount += 1
                If checkModelCode = String.Empty Then
                    checkModelCode = Grid_OrderList(i, 4)
                Else
                    checkModelCode += "|" & Grid_OrderList(i, 4)
                End If
                Grid_MaterialList.Cols.Add()
                Grid_MaterialList(0, Grid_MaterialList.Cols.Count - 1) = Grid_OrderList(i, 5)
                Grid_MaterialList(1, Grid_MaterialList.Cols.Count - 1) = Grid_OrderList(i, 6)
            End If
        Next

        Dim nowCode() As String = checkModelCode.Split("|")

        If checkCount = 0 Then
            Thread_LoadingFormEnd()
            MessageBox.Show(Me, "산출하려는 모델을 선택하여 주십시오.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_check_requirements(1"
        strSQL += ", " & checkCount & ""
        strSQL += ", '" & checkModelCode & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = String.Empty
            Dim insert_String2 As String = String.Empty
            Dim rowColor As Color = Color.White

            insert_String = Grid_MaterialList.Rows.Count - 1 & vbTab &
                sqlDR("part_code") & vbTab &
                sqlDR("basic_stock") & vbTab &
                sqlDR("in_qty") & vbTab &
                sqlDR("loss_qty") & vbTab &
                sqlDR("delivery_qty") & vbTab &
                sqlDR("ready_qty") & vbTab &
                sqlDR("run_completed_qty")
            Dim totalAmount As Double = 0
            For i As Integer = 0 To UBound(nowCode)
                totalAmount += (sqlDR(nowCode(i)) * Grid_MaterialList(1, i + 10))
            Next
            insert_String += vbTab & totalAmount & vbTab
            For i As Integer = 0 To UBound(nowCode)
                insert_String += vbTab & sqlDR(nowCode(i))
            Next
            Grid_MaterialList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_MaterialList.Rows.Fixed = 2
        Grid_MaterialList.AllowMerging = AllowMergingEnum.Custom
        Dim crCellRange As CellRange = Grid_MaterialList.GetCellRange(1, 0, 1, 3)
        Grid_MaterialList.MergedRanges.Add(crCellRange)

        Grid_MaterialList.AutoSizeCols()
        Grid_MaterialList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub
End Class