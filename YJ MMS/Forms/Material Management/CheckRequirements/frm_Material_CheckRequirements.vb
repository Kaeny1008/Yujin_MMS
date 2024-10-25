Imports C1.Win.C1FlexGrid
Imports MySqlConnector

Public Class frm_Material_CheckRequirements

    Dim saveOK As Boolean = False

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
            .Cols.Count = 10
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
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
            .Cols(1).DataType = GetType(Boolean)
            .Cols(2).Visible = False
        End With

        Grid_OrderList(0, 0) = "No"
        Grid_OrderList(0, 1) = "선택"
        Grid_OrderList(0, 2) = "Order Index"
        Grid_OrderList(0, 3) = "납기일자"
        Grid_OrderList(0, 4) = "고객사"
        Grid_OrderList(0, 5) = "모델코드"
        Grid_OrderList(0, 6) = "품번"
        Grid_OrderList(0, 7) = "주문수량"
        Grid_OrderList(0, 8) = "관리번호"
        Grid_OrderList(0, 9) = "상위모델"

        With Grid_MaterialList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 18
            .Cols.Fixed = 1
            .Rows.Count = 4
            .Rows.Fixed = 4
            For i = 0 To .Cols.Count - 1
                .Cols(i).AllowMerging = True
            Next
            .Rows(0).AllowMerging = True
            '.Rows(1).AllowMerging = True
            '.Rows(2).AllowMerging = True
            Dim rngM As CellRange = .GetCellRange(0, 0, 3, 0)
            rngM.Data = "No"
            rngM = .GetCellRange(0, 1, 3, 1)
            rngM.Data = "자재코드"
            rngM = .GetCellRange(0, 2, 3, 2)
            rngM.Data = "타입"
            rngM = .GetCellRange(0, 3, 3, 3)
            rngM.Data = "품명"
            rngM = .GetCellRange(0, 4, 3, 4)
            rngM.Data = "사/도급"
            rngM = .GetCellRange(0, 5, 3, 5)
            rngM.Data = "공급사"
            rngM = .GetCellRange(0, 6, 0, 15)
            rngM.Data = "재고"
            rngM = .GetCellRange(1, 6, 3, 6)
            rngM.Data = "기초재고"
            rngM = .GetCellRange(1, 7, 3, 7)
            rngM.Data = "입고"
            rngM = .GetCellRange(1, 8, 3, 8)
            rngM.Data = "Loss"
            rngM = .GetCellRange(1, 9, 3, 9)
            rngM.Data = "납품"
            rngM = .GetCellRange(1, 10, 3, 10)
            rngM.Data = "계획대기"
            rngM = .GetCellRange(1, 11, 3, 11)
            rngM.Data = "생산 중"
            rngM = .GetCellRange(1, 12, 3, 12)
            rngM.Data = "생산 완료"
            rngM = .GetCellRange(1, 13, 3, 13)
            rngM.Data = "품번전환"
            rngM = .GetCellRange(1, 14, 3, 14)
            rngM.Data = "반출"
            rngM = .GetCellRange(1, 15, 3, 15)
            rngM.Data = "폐기"
            rngM = .GetCellRange(0, 16, 3, 16)
            rngM.Data = "필요수량"
            rngM = .GetCellRange(0, 17, 3, 17)
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
            For i = 6 To .Cols.Count - 1
                .Cols(i).DataType = GetType(Double)
                .Cols(i).Format = "#,##0"
            Next
        End With

    End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        If TB_CustomerCode.Text = String.Empty Then
            MSG_Information(Me, "고객사를 먼저 선택하여 주십시오.")
            Exit Sub
        End If

        Thread_LoadingFormStart(Me)

        Grid_Setting()

        saveOK = False

        Grid_OrderList.Redraw = False
        Grid_OrderList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_check_requirements(0"
        strSQL += ", null"
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
                                          sqlDR("date_of_delivery") & vbTab &
                                          sqlDR("customer_name") & vbTab &
                                          sqlDR("model_code") & vbTab &
                                          sqlDR("item_code") & vbTab &
                                          Format(sqlDR("modify_order_quantity"), "#,##0") & vbTab &
                                          sqlDR("management_no") & vbTab &
                                          sqlDR("main_item_code")
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
        Dim selCol As Integer = Grid_OrderList.MouseCol

        If selRow < 0 Then Exit Sub

        Grid_OrderList.Row = selRow

        If e.Button = MouseButtons.Left Then
            If Grid_OrderList.GetCellCheck(selRow, 1) = CheckEnum.Checked Then
                Grid_OrderList.SetCellCheck(selRow, 1, CheckEnum.Unchecked)
                Grid_OrderList.Rows(selRow).StyleNew.BackColor = Color.White
            Else
                Grid_OrderList.SetCellCheck(selRow, 1, CheckEnum.Checked)
                Grid_OrderList.Rows(selRow).StyleNew.BackColor = Color.LightSkyBlue
            End If
        ElseIf e.Button = MouseButtons.Right Then
            CMS_Menu.Show(Grid_OrderList, New Point(e.X, e.Y))
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

        Thread_LoadingFormStart(Me)

        BTN_Confirm.Enabled = True
        Grid_MaterialList.Redraw = False
        Grid_MaterialList.Rows.Count = 4
        Grid_MaterialList.Cols.Count = 18

        Dim checkCount As Integer = 0
        Dim checkModelCode As String = String.Empty
        Dim checkManagementNo As String = String.Empty

        For i = 1 To Grid_OrderList.Rows.Count - 1
            If Grid_OrderList.GetCellCheck(i, 1) = CheckEnum.Checked Then
                'checkCount += 1
                'If checkModelCode = String.Empty Then
                '    checkModelCode = Grid_OrderList(i, 5)
                'Else
                '    checkModelCode += "|" & Grid_OrderList(i, 5)
                'End If
                Dim nowModelCode As String = Grid_OrderList(i, 5)
                Dim nowManagementNo As String = Grid_OrderList(i, 8)
                Dim nowOrderQty As String = Grid_OrderList(i, 7)
                Dim nowItemCode As String = Grid_OrderList(i, 6)
                Dim findItem As Boolean = False
                For j = 17 To Grid_MaterialList.Cols.Count - 1
                    If Grid_MaterialList(0, j) = nowModelCode And
                        Grid_MaterialList(1, j) = nowManagementNo Then
                        Grid_MaterialList(3, j) = CInt(Grid_MaterialList(3, j)) + CInt(nowOrderQty)
                        findItem = True
                        Exit For
                    End If
                Next
                If findItem = False Then
                    Grid_MaterialList.Cols.Add()
                    Grid_MaterialList(0, Grid_MaterialList.Cols.Count - 1) = nowModelCode
                    Grid_MaterialList(1, Grid_MaterialList.Cols.Count - 1) = nowManagementNo
                    Grid_MaterialList(2, Grid_MaterialList.Cols.Count - 1) = nowItemCode
                    Grid_MaterialList(3, Grid_MaterialList.Cols.Count - 1) = nowOrderQty
                End If
            End If
        Next

        For i = 18 To Grid_MaterialList.Cols.Count - 1
            checkCount += 1
            If checkModelCode = String.Empty Then
                checkModelCode = Grid_MaterialList(0, i)
                checkManagementNo = Grid_MaterialList(1, i)
            Else
                checkModelCode += "|" & Grid_MaterialList(0, i)
                checkManagementNo += "|" & Grid_MaterialList(1, i)
            End If
        Next

        'Grid_MaterialList.Redraw = True
        'Thread_LoadingFormEnd()
        'Exit Sub

        Dim nowCode() As String = checkModelCode.Split("|")
        Dim nowManage() As String = checkManagementNo.Split("|")

        If checkCount = 0 Then
            Thread_LoadingFormEnd()
            MSG_Information(Me, "산출하려는 모델을 선택하여 주십시오.")
            Exit Sub
        End If

        For i = 1 To Grid_OrderList.Rows.Count - 1
            If Trim(Grid_OrderList(i, 4)) = String.Empty Or
                Trim(Grid_OrderList(i, 5)) = String.Empty Or
                Trim(Grid_OrderList(i, 6)) = String.Empty Or
                Trim(Grid_OrderList(i, 7)) = String.Empty Then
                Thread_LoadingFormEnd()
                MSG_Information(Me, "입력되지 않은 항목이 존재 합니다.")
                Exit Sub
            End If
        Next

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_check_requirements(1"
        strSQL += ", " & checkCount & ""
        strSQL += ", '" & checkModelCode & "'"
        strSQL += ", '" & checkManagementNo & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = String.Empty
            Dim insert_String2 As String = String.Empty
            Dim rowColor As Color = Color.White

            insert_String = Grid_MaterialList.Rows.Count - 3 & vbTab &
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
                Format(sqlDR("completed_qty"), "#,##0") & vbTab &
                Format(sqlDR("code_change_qty"), "#,##0") & vbTab &
                Format(sqlDR("return_qty"), "#,##0") & vbTab &
                Format(sqlDR("discard_qty"), "#,##0")

            Dim totalAmount As Double = 0
            For i As Integer = 0 To UBound(nowCode)
                totalAmount += (sqlDR(nowCode(i) & "_" & nowManage(i)) * Grid_MaterialList(3, i + 18)) '총 사용수량
            Next
            insert_String += vbTab & Format(totalAmount, "#,##0")

            Dim stock_qty As Double = sqlDR("basic_stock") +
                sqlDR("in_qty") -
                sqlDR("loss_qty") -
                sqlDR("delivery_qty") -
                sqlDR("ready_qty") -
                sqlDR("run_qty") -
                sqlDR("completed_qty") -
                sqlDR("code_change_qty") -
                sqlDR("return_qty") -
                sqlDR("discard_qty")
            insert_String += vbTab & Format((stock_qty - totalAmount), "#,##0")

            For i As Integer = 0 To UBound(nowCode)
                insert_String += vbTab & Format(sqlDR(nowCode(i) & "_" & nowManage(i)), "#,##0") '모델별 사용수량
            Next

            Grid_MaterialList.AddItem(insert_String)
            If stock_qty - totalAmount < 0 Then
                Grid_MaterialList.Rows(Grid_MaterialList.Rows.Count - 1).StyleNew.ForeColor = Color.Red
            ElseIf stock_qty - totalAmount = 0 Then
                Grid_MaterialList.Rows(Grid_MaterialList.Rows.Count - 1).StyleNew.ForeColor = Color.Blue
            ElseIf stock_qty - totalAmount > 0 Then
                Grid_MaterialList.Rows(Grid_MaterialList.Rows.Count - 1).StyleNew.ForeColor = Color.black
            End If
        Loop
        sqlDR.Close()

        DBClose()

        Grid_MaterialList.AutoSizeCols()
        Grid_MaterialList.Redraw = True
        saveOK = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub BTN_Confirm_Click(sender As Object, e As EventArgs) Handles BTN_Confirm.Click

        If saveOK = False Then Exit Sub

        Dim lowMaterial As Boolean = False
        For i = 4 To Grid_MaterialList.Rows.Count - 1
            If Grid_MaterialList(i, 16) < 0 Then
                lowMaterial = True
                Exit For
            End If
        Next

        If lowMaterial = True Then
            If MSG_Question(Me, "계획대비 부족한 자재가 존재 합니다." & vbCrLf & "무시 후 확정 하시겠습니까?") = False Then Exit Sub
        End If

        For i = 1 To Grid_OrderList.Rows.Count - 1
            If Grid_OrderList(i, 0) = "T" Then
                MSG_Information(Me, "주문외 데이터가 존재하므로 저장 할 수 없습니다.")
                Exit Sub
            End If
        Next

        If MSG_Question(Me, "확인 완료로 등록 하시겠습니까?." & vbCrLf & "확인 완료로 변경시 생산계획 수립을 할 수 있습니다.") = False Then Exit Sub


        Thread_LoadingFormStart(Me, "Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            For i = 1 To Grid_OrderList.Rows.Count - 1
                If Grid_OrderList.GetCellCheck(i, 1) = CheckEnum.Checked Then
                    strSQL += "update tb_mms_order_register_list set order_status = 'Confirmation completed'"
                    strSQL += ", management_no = (select max(management_no) from tb_model_bom where model_code = '" & Grid_OrderList(i, 5) & "')"
                    strSQL += " where order_index = '" & Grid_OrderList(i, 2) & "';"
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
            BTN_Confirm.Enabled = False
            Thread_LoadingFormEnd()
            MSG_Error(Me, ex.Message & vbCrLf & "Error No. : " & ex.Number)
            Exit Sub
        End Try

        DBClose()

        BTN_Confirm.Enabled = False
        saveOK = False

        Thread_LoadingFormEnd()

        MSG_Information(Me, "저장완료.")

        BTN_Search_Click(Nothing, Nothing)

    End Sub

    Private Sub CB_CustomerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_CustomerName.SelectedIndexChanged

    End Sub

    Private Sub BTN_AllCheck_Click(sender As Object, e As EventArgs) Handles BTN_AllCheck.Click

        For i = 1 To Grid_OrderList.Rows.Count - 1
            Grid_OrderList.SetCellCheck(i, 1, CheckEnum.Checked)
        Next

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked = True Then
            BTN_RowAdd.Enabled = True
            BTN_RowDelete.Enabled = True
        Else
            BTN_RowAdd.Enabled = False
            BTN_RowDelete.Enabled = False

            For i = Grid_OrderList.Rows.Count - 1 To 1 Step -1
                If Grid_OrderList(i, 0).ToString.Equals("T") Then
                    Grid_OrderList.RemoveItem(i)
                End If
            Next
        End If

    End Sub

    Private Sub BTN_RowAdd_Click(sender As Object, e As EventArgs) Handles BTN_RowAdd.Click

        Grid_OrderList.AddItem("T")

    End Sub

    Private Sub Grid_OrderList_RowColChange(sender As Object, e As EventArgs) Handles Grid_OrderList.RowColChange

        If CheckBox1.Checked = True Then
            Select Case Grid_OrderList.Col
                Case 6, 7
                    Grid_OrderList.AllowEditing = True
                Case Else
                    Grid_OrderList.AllowEditing = False
            End Select
        End If

    End Sub

    Dim beforeText As String

    Private Sub Grid_OrderList_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Grid_OrderList.BeforeEdit

        If e.Row < 0 Or e.Col < 0 Then Exit Sub
        beforeText = Grid_OrderList(e.Row, e.Col)

    End Sub

    Private Sub Grid_OrderList_AfterEdit(sender As Object, e As RowColEventArgs) Handles Grid_OrderList.AfterEdit

        If e.Row < 0 Or e.Col < 0 Then Exit Sub

        If beforeText = Grid_OrderList(e.Row, e.Col) Then Exit Sub

        Select Case e.Col
            Case 6
                Grid_OrderList(e.Row, 4) = CB_CustomerName.Text
                Grid_OrderList(e.Row, 5) = Load_ItemCode(Grid_OrderList(e.Row, 6))
                Grid_OrderList(e.Row, 8) = "미지정"
        End Select

    End Sub

    Private Function Load_ItemCode(ByVal itemCode As String) As String

        Dim returnString As String = String.Empty

        DBConnect()

        Dim strSQL As String = "SELECT model_code"
        strSQL += " FROM tb_model_list"
        strSQL += " WHERE customer_code = '" & TB_CustomerCode.Text & "'"
        strSQL += " AND item_code = '" & itemCode & "'"
        strSQL += ";"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            returnString = sqlDR("model_code")
        Loop
        sqlDR.Close()

        DBClose()

        Return returnString

    End Function
End Class