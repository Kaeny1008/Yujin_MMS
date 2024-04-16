Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Material_Stock_Information
    Private Sub frm_Material_Stock_Information_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        Load_CustomerList()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub Grid_Setting()

        With Grid_MaterialList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 14
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
            rngM = .GetCellRange(0, 6, 0, 12)
            rngM.Data = "재고"
            Grid_MaterialList(1, 6) = "기초재고"
            Grid_MaterialList(1, 7) = "입고"
            Grid_MaterialList(1, 8) = "Loss"
            Grid_MaterialList(1, 9) = "납품"
            Grid_MaterialList(1, 10) = "계획대기"
            Grid_MaterialList(1, 11) = "생산 중"
            Grid_MaterialList(1, 12) = "생산 완료"
            rngM = .GetCellRange(0, 13, 1, 13)
            rngM.Data = "미과출(재고)"
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

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        If TB_CustomerCode.Text = String.Empty Then
            MessageBox.Show("고객사를 먼저 선택하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Exit Sub
        End If

        Thread_LoadingFormStart()

        Grid_MaterialList.Redraw = False
        Grid_MaterialList.Rows.Count = 2

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_stock_information(0"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
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
                Format(sqlDR("in_qty"), "#,##0") & vbTab &
                Format(sqlDR("loss_qty"), "#,##0") & vbTab &
                Format(sqlDR("delivery_qty"), "#,##0") & vbTab &
                Format(sqlDR("ready_qty"), "#,##0") & vbTab &
                Format(sqlDR("run_qty"), "#,##0") & vbTab &
                Format(sqlDR("completed_qty"), "#,##0")

            'Dim totalAmount As Double = 0
            'For i As Integer = 0 To UBound(nowCode)
            '    totalAmount += (sqlDR(nowCode(i)) * Grid_MaterialList(1, i + 15)) '총 사용수량
            'Next
            'insert_String += vbTab & Format(totalAmount, "#,##0")

            Dim stock_qty As Double = sqlDR("basic_stock") +
                sqlDR("in_qty") -
                sqlDR("loss_qty") -
                sqlDR("delivery_qty") -
                sqlDR("ready_qty") -
                sqlDR("run_qty") -
                sqlDR("completed_qty")
            insert_String += vbTab & Format((stock_qty), "#,##0")

            'For i As Integer = 0 To UBound(nowCode)
            '    insert_String += vbTab & Format(sqlDR(nowCode(i)), "#,##0") '모델별 사용수량
            'Next

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

        Grid_MaterialList.AutoSizeCols()
        Grid_MaterialList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub
End Class