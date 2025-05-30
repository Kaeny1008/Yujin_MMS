﻿Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient


Public Class frm_Material_CheckRequirements_back

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
            .Cols.Count = 9
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            Grid_OrderList(0, 0) = "No"
            Grid_OrderList(0, 1) = "선택"
            Grid_OrderList(0, 2) = "Order Index"
            Grid_OrderList(0, 3) = "납기일자"
            Grid_OrderList(0, 4) = "고객사"
            Grid_OrderList(0, 5) = "모델코드"
            Grid_OrderList(0, 6) = "품번"
            Grid_OrderList(0, 7) = "주문수량"
            Grid_OrderList(0, 8) = "관리번호"
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
            .Cols.Count = 17
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
            rngM = .GetCellRange(0, 6, 0, 14)
            rngM.Data = "재고"
            Grid_MaterialList(1, 6) = "기초재고"
            Grid_MaterialList(1, 7) = "입고"
            Grid_MaterialList(1, 8) = "Loss"
            Grid_MaterialList(1, 9) = "납품"
            Grid_MaterialList(1, 10) = "계획대기"
            Grid_MaterialList(1, 11) = "생산 중"
            Grid_MaterialList(1, 12) = "생산 완료"
            Grid_MaterialList(1, 13) = "품번전환"
            Grid_MaterialList(1, 14) = "반출"
            rngM = .GetCellRange(0, 15, 1, 15)
            rngM.Data = "필요수량"
            rngM = .GetCellRange(0, 16, 1, 16)
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

        If TB_CustomerCode.Text = String.Empty Then
            MessageBox.Show(Me,
                            "고객사를 먼저 선택하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Exit Sub
        End If

        Thread_LoadingFormStart(Me)

        Grid_Setting()

        saveOK = False

        Grid_OrderList.Redraw = False
        Grid_OrderList.Rows.Count = 1

        If DBConnect() = False Then Exit Sub

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
                                          sqlDR("date_of_delivery") & vbTab &
                                          sqlDR("customer_name") & vbTab &
                                          sqlDR("model_code") & vbTab &
                                          sqlDR("item_code") & vbTab &
                                          Format(sqlDR("modify_order_quantity"), "#,##0") & vbTab &
                                          sqlDR("management_no")
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

        If selRow < 1 Then Exit Sub

        If e.Button = MouseButtons.Left And selCol = 1 Then
            If Grid_OrderList.GetCellCheck(selRow, 1) = CheckEnum.Checked Then
                Grid_OrderList.SetCellCheck(selRow, 1, CheckEnum.Unchecked)
            Else
                Grid_OrderList.SetCellCheck(selRow, 1, CheckEnum.Checked)
            End If
        End If

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

    Private Sub BTN_Check_Click(sender As Object, e As EventArgs) Handles BTN_Check.Click

        Thread_LoadingFormStart(Me)

        BTN_Confirm.Enabled = True
        Grid_MaterialList.Redraw = False
        Grid_MaterialList.Rows.Count = 2
        Grid_MaterialList.Cols.Count = 17

        Dim checkCount As Integer = 0
        Dim checkModelCode As String = String.Empty

        For i = 1 To Grid_OrderList.Rows.Count - 1
            If Grid_OrderList.GetCellCheck(i, 1) = CheckEnum.Checked Then
                checkCount += 1
                If checkModelCode = String.Empty Then
                    checkModelCode = Grid_OrderList(i, 5)
                Else
                    checkModelCode += "|" & Grid_OrderList(i, 5)
                End If
                Grid_MaterialList.Cols.Add()
                Grid_MaterialList(0, Grid_MaterialList.Cols.Count - 1) = Grid_OrderList(i, 6)
                Grid_MaterialList(1, Grid_MaterialList.Cols.Count - 1) = Grid_OrderList(i, 7)
            End If
        Next

        'Grid_MaterialList.Redraw = True
        'Thread_LoadingFormEnd()
        'Exit Sub

        Dim nowCode() As String = checkModelCode.Split("|")

        If checkCount = 0 Then
            Thread_LoadingFormEnd()
            MessageBox.Show(Me, "산출하려는 모델을 선택하여 주십시오.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_material_check_requirements(1"
        strSQL += ", " & checkCount & ""
        strSQL += ", '" & checkModelCode & "'"
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
                Format(sqlDR("completed_qty"), "#,##0") & vbTab &
                Format(sqlDR("code_change_qty"), "#,##0") & vbTab &
                Format(sqlDR("return_qty"), "#,##0")

            Dim totalAmount As Double = 0
            For i As Integer = 0 To UBound(nowCode)
                totalAmount += (sqlDR(nowCode(i)) * Grid_MaterialList(1, i + 17)) '총 사용수량
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
                sqlDR("return_qty")
            insert_String += vbTab & Format((stock_qty - totalAmount), "#,##0")

            For i As Integer = 0 To UBound(nowCode)
                insert_String += vbTab & Format(sqlDR(nowCode(i)), "#,##0") '모델별 사용수량
            Next

            Grid_MaterialList.AddItem(insert_String)
            If stock_qty - totalAmount < 0 Then
                Grid_MaterialList.Rows(Grid_MaterialList.Rows.Count - 1).StyleNew.ForeColor = Color.Red
            ElseIf stock_qty - totalAmount = 0 Then
                Grid_MaterialList.Rows(Grid_MaterialList.Rows.Count - 1).StyleNew.ForeColor = Color.Blue
            ElseIf stock_qty - totalAmount > 0 Then
                Grid_MaterialList.Rows(Grid_MaterialList.Rows.Count - 1).StyleNew.ForeColor = Color.Black
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

        For i = 2 To Grid_MaterialList.Rows.Count - 1
            If Grid_MaterialList(i, 16) < 0 Then
                MessageBox.Show(Me,
                                "계획대비 부족한 자재가 존재 합니다.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning)
                Exit Sub
            End If
        Next

        If MessageBox.Show(Me,
                           "확인 완료로 등록 하시겠습니까?." & vbCrLf & "확인 완료로 변경시 생산계획 수립을 할 수 있습니다.",
                           msg_form,
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.No Then Exit Sub


        Thread_LoadingFormStart(Me, "Saving...")

        If DBConnect() = False Then Exit Sub

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
            MessageBox.Show(Me,
                            ex.Message & vbCrLf & "Error No. : " & ex.Number,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Exit Sub
        End Try

        DBClose()

        BTN_Confirm.Enabled = False
        saveOK = False

        Thread_LoadingFormEnd()

        MessageBox.Show(Me,
                        "저장완료.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

        BTN_Search_Click(Nothing, Nothing)

    End Sub

    Private Sub CB_CustomerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_CustomerName.SelectedIndexChanged

    End Sub
End Class