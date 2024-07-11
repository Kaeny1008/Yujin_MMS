Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_MRP
    Private Sub frm_MRP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        Load_CustomerList()

        DateTimePicker1.Value = DateAdd(DateInterval.Day, -1, CDate(Format(DateAdd(DateInterval.Month, 3, Now), "yyyy-MM-01")))

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub Grid_Setting()

        With Grid_MaterialList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.Both
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            '.AllowResizing = True
            .AllowDragging = AllowDraggingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 15
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
            rngM = .GetCellRange(0, 2, 1, 2)
            rngM.Data = "타입"
            rngM = .GetCellRange(0, 3, 1, 3)
            rngM.Data = "품명"
            rngM = .GetCellRange(0, 4, 1, 4)
            rngM.Data = "사/도급"
            rngM = .GetCellRange(0, 5, 1, 5)
            rngM.Data = "공급사"
            rngM = .GetCellRange(0, 6, 0, 13)
            rngM.Data = "재고"
            Grid_MaterialList(1, 6) = "기초재고"
            Grid_MaterialList(1, 7) = "잉여재고"
            Grid_MaterialList(1, 8) = "입고"
            Grid_MaterialList(1, 9) = "Loss"
            Grid_MaterialList(1, 10) = "품번전환"
            Grid_MaterialList(1, 11) = "반출"
            Grid_MaterialList(1, 12) = "생산 완료"
            Grid_MaterialList(1, 13) = "납품"
            rngM = .GetCellRange(0, 14, 1, 14)
            rngM.Data = "미과출(재고)"
            For i = 6 To 14
                .Cols(i).DataType = GetType(Double)
                .Cols(i).Format = "#,##0"
            Next
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
            .Cols.Frozen() = 14
        End With

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

        Load_Clearance_Date()

    End Sub

    Private Sub Load_Clearance_Date()

        DBConnect()

        Dim strSQL As String = "select clearance_date"
        strSQL += " from tb_mms_material_basic_inventory"
        strSQL += " where customer_code = '" & TB_CustomerCode.Text & "'"
        strSQL += " group by clearance_date"
        strSQL += " order by clearance_date desc"
        strSQL += " limit 1;"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_Base_Date.Text = sqlDR("clearance_date")
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        If TB_CustomerCode.Text = String.Empty Then
            MSG_Information(Me, "고객사를 먼저 선택하여 주십시오.")
            Exit Sub
        End If

        Thread_LoadingFormStart(Me)
        Grid_MaterialList.Redraw = False
        Grid_MaterialList.Rows.Count = 2
        Grid_MaterialList.Cols.Count = 15

        '######### 1. 그리드를 초기화한다.
        Dim cols_Count As Integer = 0
        cols_Count = DateDiff(DateInterval.Day, CDate(TB_Base_Date.Text), DateTimePicker1.Value) + 1
        Dim baseDate As Date = CDate(TB_Base_Date.Text)
        For i = 0 To cols_Count - 1
            Grid_MaterialList.Cols.Add()
            Grid_MaterialList(0, Grid_MaterialList.Cols.Count - 1) = Format(DateAdd(DateInterval.Day, i, baseDate), "yyyy-MM-dd")
            Grid_MaterialList(1, Grid_MaterialList.Cols.Count - 1) = Format(DateAdd(DateInterval.Day, i, baseDate), "yyyy-MM-dd")
        Next

        For i = 15 To Grid_MaterialList.Cols.Count - 1
            Grid_MaterialList.Cols(i).AllowMerging = True
            Grid_MaterialList.Cols(i).DataType = GetType(Double)
            Grid_MaterialList.Cols(i).Format = "#,##0"
        Next

        '######### 2. 자재의 기본정보 및 재고수량을 불러 온다.
        Load_1st()

        '######### 3. 생산해야할 모델을 불러온다.
        Load_2st()
        Load_3st()

        '######### 4. 부족분 확인
        Load_4st()

        Grid_MaterialList.AutoSizeCols()
        Grid_MaterialList.Redraw = True
        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_1st()

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_requirements_planning(0"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
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
                sqlDR("part_type") & vbTab &
                sqlDR("part_spec") & vbTab &
                sqlDR("part_category") & vbTab &
                sqlDR("part_supplier") & vbTab &
                Format(sqlDR("basic_stock"), "#,##0") & vbTab &
                Format(sqlDR("over_cut"), "#,##0") & vbTab &
                Format(sqlDR("in_qty"), "#,##0") & vbTab &
                Format(sqlDR("loss_qty"), "#,##0") & vbTab &
                Format(sqlDR("code_change_qty"), "#,##0") & vbTab &
                Format(sqlDR("return_qty"), "#,##0") & vbTab &
                Format(sqlDR("completed_qty"), "#,##0") & vbTab &
                Format(sqlDR("delivery_qty"), "#,##0")

            Dim stock_qty As Double = sqlDR("basic_stock") +
                sqlDR("over_cut") +
                sqlDR("in_qty") -
                sqlDR("loss_qty") -
                sqlDR("delivery_qty") -
                sqlDR("ready_qty") -
                sqlDR("run_qty") -
                sqlDR("completed_qty") -
                sqlDR("code_change_qty") -
                sqlDR("return_qty")
            insert_String += vbTab & Format((stock_qty), "#,##0")

            Grid_MaterialList.AddItem(insert_String)
            If stock_qty < 0 Then
                Grid_MaterialList.Rows(Grid_MaterialList.Rows.Count - 1).StyleNew.ForeColor = Color.Red
            ElseIf stock_qty = 0 Then
                Grid_MaterialList.Rows(Grid_MaterialList.Rows.Count - 1).StyleNew.ForeColor = Color.Blue
            ElseIf stock_qty > 0 Then
                Grid_MaterialList.Rows(Grid_MaterialList.Rows.Count - 1).StyleNew.ForeColor = Color.Black
            End If
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub Load_2st()

        DBConnect()

        For j = 15 To Grid_MaterialList.Cols.Count - 1
            Dim strSQL As String = "call sp_mms_material_requirements_planning(1"
            strSQL += ", null"
            strSQL += ", '" & Grid_MaterialList(0, j) & "'"
            strSQL += ", null"
            strSQL += ")"

            Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
            Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

            Do While sqlDR.Read
                Dim part_no As String = sqlDR("part_no")
                Dim work_qty As Double = sqlDR("use_count")
                For i = 2 To Grid_MaterialList.Rows.Count - 1
                    If Grid_MaterialList(i, 1).Equals(part_no) Then
                        Dim orgQty As Double = CDbl(Grid_MaterialList(i, j))
                        Grid_MaterialList(i, j) = orgQty + work_qty
                        Exit For
                    End If
                Next
            Loop
            sqlDR.Close()
        Next

        DBClose()

    End Sub

    Private Sub Load_3st()

        DBConnect()

        For j = 15 To Grid_MaterialList.Cols.Count - 1
            Dim strSQL As String = "call sp_mms_material_requirements_planning(2"
            strSQL += ", null"
            strSQL += ", '" & Grid_MaterialList(0, j) & "'"
            strSQL += ", null"
            strSQL += ")"

            Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
            Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

            Do While sqlDR.Read
                Dim part_no As String = sqlDR("part_no")
                Dim work_qty As Double = sqlDR("use_count")
                For i = 2 To Grid_MaterialList.Rows.Count - 1
                    If Grid_MaterialList(i, 1).Equals(part_no) Then
                        Dim orgQty As Double = CDbl(Grid_MaterialList(i, j))
                        Grid_MaterialList(i, j) = orgQty + work_qty
                        Exit For
                    End If
                Next
            Loop
            sqlDR.Close()
        Next

        DBClose()

    End Sub

    Private Sub Load_4st()

        For i = 2 To Grid_MaterialList.Rows.Count - 1
            Dim baseQty As Double = CDbl(Grid_MaterialList(i, 14))
            For j = 15 To Grid_MaterialList.Cols.Count - 1
                If IsNothing (Grid_MaterialList(i, j)) Then Grid_MaterialList(i, j) = 0
                baseQty -= Grid_MaterialList(i, j)
                If baseQty < 0 Then
                    Dim cs As CellStyle = Grid_MaterialList.Styles.Add("new_style")
                    cs.BackColor = Color.MediumVioletRed
                    cs.ForeColor = Color.Yellow
                    Grid_MaterialList.SetCellStyle(i, j, cs)
                End If
                Grid_MaterialList(i, j) = baseQty
            Next
        Next

    End Sub

    Private Sub Grid_MaterialList_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_MaterialList.MouseClick

        Dim selRow As Integer = Grid_MaterialList.MouseRow
        Dim selCol As Integer = Grid_MaterialList.MouseCol

        If (selRow = 0 Or selRow = 1) And e.Button = MouseButtons.Right Then
            CMS_Menu.Show(Grid_MaterialList, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub BTN_HideCol_Click(sender As Object, e As EventArgs) Handles BTN_HideCol.Click

        For i = 1 To Grid_MaterialList.Cols.Count - 1
            If Grid_MaterialList.IsCellSelected(2, i) Then
                Grid_MaterialList.Cols(i).Visible = False
            End If
        Next

    End Sub

    Private Sub BTN_HideCancel_Click(sender As Object, e As EventArgs) Handles BTN_HideCancel.Click

        For i = 1 To Grid_MaterialList.Cols.Count - 1
            Grid_MaterialList.Cols(i).Visible = True
        Next

    End Sub
End Class