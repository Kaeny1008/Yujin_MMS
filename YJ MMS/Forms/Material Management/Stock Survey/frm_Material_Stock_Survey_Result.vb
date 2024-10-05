Imports C1.Win.C1FlexGrid
Imports MySqlConnector

Public Class frm_Material_Stock_Survey_Result
    Private Sub frm_Material_Stock_Survey_Result_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        DateTimePicker2.Value = Format(Now, "yyyy-MM-01 00:00:00")
        DateTimePicker3.Value = Format(Now)

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
            .Cols.Count = 22
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
            rngM.Data = "단가(\)"
            rngM = .GetCellRange(0, 6, 1, 6)
            rngM.Data = "공급사"
            rngM = .GetCellRange(0, 7, 0, 16)
            rngM.Data = "재고"
            rngM = .GetCellRange(0, 17, 1, 17)
            rngM.Data = "전산재고"
            rngM = .GetCellRange(0, 18, 1, 18)
            rngM.Data = "결과"
            rngM = .GetCellRange(0, 19, 1, 19)
            rngM.Data = "차이"
            rngM = .GetCellRange(0, 20, 1, 20)
            rngM.Data = "Loss금액"
            rngM = .GetCellRange(0, 21, 1, 21)
            rngM.Data = "사유"
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
            For i = 7 To 19
                .Cols(i).DataType = GetType(Double)
                .Cols(i).Format = "#,##0"
            Next
            .Cols(20).DataType = GetType(Double)
            .Cols(20).Format = "#,##0.000"
            .SelectionMode = SelectionModeEnum.Default
        End With
        Grid_MaterialList(1, 7) = "기초재고"
        Grid_MaterialList(1, 8) = "입고"
        Grid_MaterialList(1, 9) = "Loss"
        Grid_MaterialList(1, 10) = "납품"
        Grid_MaterialList(1, 11) = "계획대기"
        Grid_MaterialList(1, 12) = "생산 중"
        Grid_MaterialList(1, 13) = "생산 완료"
        Grid_MaterialList(1, 14) = "품번전환"
        Grid_MaterialList(1, 15) = "반출"
        Grid_MaterialList(1, 16) = "폐기"
        Grid_MaterialList.AutoSizeCols()

        With Grid_PlanList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 5
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            Grid_PlanList(0, 0) = "No"
            Grid_PlanList(0, 1) = "계획일자"
            Grid_PlanList(0, 2) = "고객사"
            Grid_PlanList(0, 3) = "재고조사번호"
            Grid_PlanList(0, 4) = "상태"
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

        Thread_LoadingFormStart(Me)

        Grid_PlanList.Redraw = False
        Grid_PlanList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_stock_survey(5"
        strSQL += ", null"
        strSQL += ", '" & Format(DateTimePicker2.Value, "yyyy-MM-dd 00:00:00") & "'"
        strSQL += ", '" & Format(DateTimePicker3.Value, "yyyy-MM-dd 23:59:59") & "'"
        strSQL += ", '" & TextBox1.Text & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = String.Empty
            insert_String = Grid_PlanList.Rows.Count & vbTab &
                Format(sqlDR("plan_date"), "yyyy-MM-dd") & vbTab &
                sqlDR("customer_name") & vbTab &
                sqlDR("plan_no") & vbTab &
                sqlDR("plan_status")
            Grid_PlanList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_PlanList.AutoSizeCols()
        Grid_PlanList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_PlanList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Grid_PlanList.MouseDoubleClick

        Dim selRow As Integer = Grid_PlanList.MouseRow

        If e.Button = MouseButtons.Left And selRow > 0 Then
            Thread_LoadingFormStart(Me)
            Load_Plan(Grid_PlanList(selRow, 3))
            Load_Plan_Content(Grid_PlanList(selRow, 3), Grid_PlanList(selRow, 4))
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            Thread_LoadingFormEnd()
        End If

    End Sub

    Private Sub Load_Plan(ByVal paln_no As String)

        CB_CustomerName.Items.Clear()

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_stock_survey(2"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & paln_no & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            LB_InspectionNo.Text = sqlDR("plan_no")
            LB_ID.Text = sqlDR("write_id")
            DTP_PlanDate.Value = sqlDR("plan_date")
            If sqlDR("plan_class") = "정기" Then
                RadioButton1.Checked = True
            Else
                RadioButton2.Checked = True
            End If
            TB_Purpose.Text = sqlDR("plan_purpose")
            CB_CustomerName.Items.Add(sqlDR("customer_name"))
            CB_CustomerName.SelectedIndex = 0
            TB_CustomerCode.Text = sqlDR("customer_code")
            Label4.Text = sqlDR("completed_date")
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub Load_Plan_Content(ByVal paln_no As String, ByVal check_Status As String)

        Grid_MaterialList.Redraw = False
        Grid_MaterialList.ClearFilter()
        Grid_MaterialList.Rows.Count = 2

        DBConnect()

        Dim loadIndex As Integer = 6

        If check_Status = "완료" Then
            loadIndex = 7
            BTN_Completed.Enabled = False
            BTN_TempSave.Enabled = False
            BTN_CompletedCancel.Enabled = True
        Else
            BTN_Completed.Enabled = True
            BTN_TempSave.Enabled = True
            BTN_CompletedCancel.Enabled = False
        End If

        Dim strSQL As String = "call sp_mms_material_stock_survey(" & loadIndex
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & paln_no & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim diff_Qty As Integer = Format(sqlDR("check_qty") - sqlDR("stock_qty"), "#,##0")
            Dim insertString As String = Grid_MaterialList.Rows.Count - 1 &
                vbTab & sqlDR("part_code") &
                vbTab & sqlDR("part_type") &
                vbTab & sqlDR("part_specification") &
                vbTab & sqlDR("part_category") &
                vbTab & Format(sqlDR("unit_price"), "#,##0.000") &
                vbTab & sqlDR("supplier") &
                vbTab & sqlDR("basic_qty") &
                vbTab & sqlDR("in_qty") &
                vbTab & sqlDR("loss_qty") &
                vbTab & sqlDR("delivery_qty") &
                vbTab & sqlDR("plan_ready_qty") &
                vbTab & sqlDR("production_qty") &
                vbTab & sqlDR("production_completed_qty") &
                vbTab & sqlDR("code_change_qty") &
                vbTab & sqlDR("return_qty") &
                vbTab & sqlDR("discard_qty") &
                vbTab & sqlDR("stock_qty") &
                vbTab & sqlDR("check_qty") &
                vbTab & diff_Qty &
                vbTab & sqlDR("unit_price") * diff_Qty &
                vbTab & sqlDR("check_reason")

            Grid_MaterialList.AddItem(insertString)
        Loop
        sqlDR.Close()

        DBClose()

        Label8.Text = Grid_MaterialList.Rows.Count - 2 & " EA"

        Grid_MaterialList.AutoSizeCols()
        Grid_MaterialList.Redraw = True

    End Sub

    Dim beforeString As String

    Private Sub Grid_MaterialList_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Grid_MaterialList.BeforeEdit

        beforeString = Grid_MaterialList(e.Row, e.Col)

    End Sub

    Private Sub Grid_MaterialList_AfterEdit(sender As Object, e As RowColEventArgs) Handles Grid_MaterialList.AfterEdit

        If e.Row < 2 Then Exit Sub

        Select Case e.Col
            Case 18
                Grid_MaterialList(e.Row, 19) = Format(CDbl(Grid_MaterialList(e.Row, 18)) - CDbl(Grid_MaterialList(e.Row, 17)), "#,##0")
        End Select

        Grid_MaterialList.Redraw = False
        If IsNumeric(Grid_MaterialList(e.Row, 0)) Then
            Grid_MaterialList(e.Row, 0) = "M"
        End If
        Grid_MaterialList.AutoSizeCols()
        Grid_MaterialList.Redraw = True

    End Sub

    Private Sub BTN_TempSave_Click(sender As Object, e As EventArgs) Handles BTN_TempSave.Click

        Dim msgString As String
        msgString = "재고조사번호 : " & LB_InspectionNo.Text
        msgString += vbCrLf & "계획일자 : " & Format(DTP_PlanDate.Value, "yyyy-MM-dd")
        msgString += vbCrLf & "조사구분 : "
        If RadioButton1.Checked Then
            msgString += RadioButton1.Text
        ElseIf RadioButton2.Checked Then
            msgString += RadioButton2.Text
        End If
        msgString += vbCrLf & "조사목적 : " & TB_Purpose.Text
        msgString += vbCrLf & "고객사 : " & CB_CustomerName.Text
        msgString += vbCrLf & vbCrLf & "임시저장 하시겠습니까?"

        If MSG_Question(Me, msg_form) = False Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            For i = 2 To Grid_MaterialList.Rows.Count - 1
                If Grid_MaterialList(i, 0).ToString.Equals("M") Then
                    Grid_MaterialList(i, 0) = i - 1
                    strSQL += "update tb_mms_material_stock_survey_plan_content set"
                    strSQL += " check_reason = '" & Grid_MaterialList(i, 21) & "'"
                    strSQL += ", temp_qty = '" & Grid_MaterialList(i, 18) & "'"
                    strSQL += " where content_no like concat('" & LB_InspectionNo.Text & "', '%')"
                    strSQL += " and part_code = '" & Grid_MaterialList(i, 1) & "'"
                    strSQL += ";"
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

            Thread_LoadingFormEnd()

            MSG_Error(Me, ex.Message)
            Exit Sub
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        MSG_Information(Me, "임시 저장완료.")

    End Sub

    Private Sub BTN_Completed_Click(sender As Object, e As EventArgs) Handles BTN_Completed.Click

        Dim msgString As String
        msgString = "재고조사번호 : " & LB_InspectionNo.Text
        msgString += vbCrLf & "계획일자 : " & Format(DTP_PlanDate.Value, "yyyy-MM-dd")
        msgString += vbCrLf & "조사구분 : "
        If RadioButton1.Checked Then
            msgString += RadioButton1.Text
        ElseIf RadioButton2.Checked Then
            msgString += RadioButton2.Text
        End If
        msgString += vbCrLf & "조사목적 : " & TB_Purpose.Text
        msgString += vbCrLf & "고객사 : " & CB_CustomerName.Text
        msgString += vbCrLf & vbCrLf & "차이가 전산재고보다 많은 경우 많은수량은 잉여자재로 저장되며,"
        msgString += vbCrLf & "외 목록은 결과 값이 기초재공으로 저장됩니다."

        msgString += vbCrLf & vbCrLf & "결과를 확정 하시겠습니까?"

        If MSG_Question(Me, msgString) = False Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        'strSQL += "update tb_mms_material_transfer_out_content set part_status = 'Closed'"
        'strSQL += " where mw_no in (select mw_no from tb_mms_material_warehousing where customer_code = '" & TB_CustomerCode.Text & "');"
        '스캔완료된 항목의 출고기록을 되돌린다.
        Dim writeResult As String = Return_PartsOutData()

        If Not writeResult = "Success" Then
            Thread_LoadingFormEnd()
            MSG_Error(Me, writeResult)
            Exit Sub
        End If

        '스캔된 데이터를 warehousing의 available_qty로 업데이트한다.
        'writeResult = Replace_PartsQty()
        'If Not writeResult = "Success" Then
        '    Thread_LoadingFormEnd()
        '    MSG_Error(Me, writeResult)
        '    Exit Sub
        'End If

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Dim dateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

        strSQL += "update tb_mms_order_register_list set clearance_date = '" & dateTime & "'"
        strSQL += " where not order_status = 'Order Confirm'"
        strSQL += " and clearance_date is null"
        strSQL += ";"

        strSQL += "update tb_mms_material_stock_survey_plan set plan_status = 'Completed'"
        strSQL += ", completed_date = '" & dateTime & "'"
        strSQL += ", completed_id = '" & loginID & "'"
        strSQL += " where plan_no = '" & LB_InspectionNo.Text & "'"
        strSQL += ";"

        Try
            For i = 2 To Grid_MaterialList.Rows.Count - 1
                Grid_MaterialList(i, 0) = i - 1
                '기초재고를 입력한다.
                If CDbl(Grid_MaterialList(i, 19)) > 0 Then
                    '결과값이 + 인경우 재고수량보다 많으니까
                    '전산수량을 기초재고로 잡고 나머지수량을 기록한다.
                    strSQL += "insert into tb_mms_material_basic_inventory("
                    strSQL += "clearance_date, customer_code, part_code, available_qty, over_cut"
                    strSQL += ") values("
                    strSQL += "'" & dateTime & "'"
                    strSQL += ",'" & TB_CustomerCode.Text & "'"
                    strSQL += ",'" & Grid_MaterialList(i, 1) & "'"
                    strSQL += "," & CDbl(Grid_MaterialList(i, 17)) & ""
                    strSQL += "," & CDbl(Grid_MaterialList(i, 19)) & ""
                    strSQL += ");"
                Else
                    strSQL += "insert into tb_mms_material_basic_inventory("
                    strSQL += "clearance_date, customer_code, part_code, available_qty, over_cut"
                    strSQL += ") values("
                    strSQL += "'" & dateTime & "'"
                    strSQL += ",'" & TB_CustomerCode.Text & "'"
                    strSQL += ",'" & Grid_MaterialList(i, 1) & "'"
                    strSQL += "," & CDbl(Grid_MaterialList(i, 18)) & ""
                    strSQL += ", 0"
                    strSQL += ");"
                End If

                '재고조사 각항목을 업데이트 한다.
                strSQL += "update tb_mms_material_stock_survey_plan_content set"
                strSQL += " check_reason = '" & Grid_MaterialList(i, 21) & "'"
                strSQL += ", check_qty = " & CDbl(Grid_MaterialList(i, 18)) & ""
                strSQL += " where content_no like concat('" & LB_InspectionNo.Text & "', '%')"
                strSQL += " and part_code = '" & Grid_MaterialList(i, 1) & "'"
                strSQL += ";"
            Next

            If Not strSQL = String.Empty Then
                sqlCmd = New MySqlCommand(strSQL, dbConnection1)
                'Console.WriteLine(strSQL)
                sqlCmd.Transaction = sqlTran
                sqlCmd.ExecuteNonQuery()

                sqlTran.Commit()
            End If
        Catch ex As MySqlException
            sqlTran.Rollback()

            DBClose()

            Thread_LoadingFormEnd()

            MSG_Error(Me, ex.Message)
            Exit Sub
        End Try

        DBClose()

        BTN_TempSave.Enabled = False
        BTN_Completed.Enabled = False
        BTN_CompletedCancel.Enabled = True

        Thread_LoadingFormEnd()

        Label4.Text = dateTime

        MSG_Information(Me, "결과 확정완료.")

        BTN_Search_Click(Nothing, Nothing)

    End Sub

    Private Function Return_PartsOutData() As String

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            strSQL += "call sp_mms_material_stock_survey(8"
            strSQL += ", '" & TB_CustomerCode.Text & "'"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", '" & LB_InspectionNo.Text & "'"
            strSQL += ");"

            If Not strSQL = String.Empty Then
                sqlCmd = New MySqlCommand(strSQL, dbConnection1)
                sqlCmd.Transaction = sqlTran
                sqlCmd.ExecuteNonQuery()

                sqlTran.Commit()
            End If
        Catch ex As MySqlException
            sqlTran.Rollback()

            DBClose()

            Thread_LoadingFormEnd()

            'MSG_Error(Me, ex.Message)
            DBClose()
            Return ex.Message
        End Try

        DBClose()

        Return "Success"

    End Function

    Private Function Replace_PartsQty() As String

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            strSQL += "call sp_mms_material_stock_survey(9"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", '" & LB_InspectionNo.Text & "'"
            strSQL += ");"

            If Not strSQL = String.Empty Then
                sqlCmd = New MySqlCommand(strSQL, dbConnection1)
                sqlCmd.Transaction = sqlTran
                sqlCmd.ExecuteNonQuery()

                sqlTran.Commit()
            End If
        Catch ex As MySqlException
            sqlTran.Rollback()

            DBClose()

            Thread_LoadingFormEnd()

            DBClose()
            Return ex.Message
        End Try

        DBClose()

        Return "Success"

    End Function

    Private Sub BTN_CompletedCancel_Click(sender As Object, e As EventArgs) Handles BTN_CompletedCancel.Click

        Dim msgString As String
        msgString = "재고조사번호 : " & LB_InspectionNo.Text
        msgString += vbCrLf & "계획일자 : " & Format(DTP_PlanDate.Value, "yyyy-MM-dd")
        msgString += vbCrLf & "조사구분 : "
        If RadioButton1.Checked Then
            msgString += RadioButton1.Text
        ElseIf RadioButton2.Checked Then
            msgString += RadioButton2.Text
        End If
        msgString += vbCrLf & "조사목적 : " & TB_Purpose.Text
        msgString += vbCrLf & "고객사 : " & CB_CustomerName.Text
        msgString += vbCrLf & vbCrLf & "확정을 취소 하시겠습니까?"

        If MSG_Question(Me, msgString) = False Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Dim dateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

        strSQL = "update tb_mms_material_stock_survey_plan set plan_status = 'Run'"
        strSQL += ", completed_date = null"
        strSQL += ", completed_id = null"
        strSQL += " where plan_no = '" & LB_InspectionNo.Text & "'"
        strSQL += ";"

        strSQL += "delete from tb_mms_material_basic_inventory"
        strSQL += " where clearance_date = '" & Format(CDate(Label4.Text), "yyyy-MM-dd") & "'"
        strSQL += ";"

        Try
            For i = 2 To Grid_MaterialList.Rows.Count - 1
                '재고조사 각항목을 업데이트 한다.
                strSQL += "update tb_mms_material_stock_survey_plan_content set"
                strSQL += " check_qty = 0"
                strSQL += " where content_no like concat('" & LB_InspectionNo.Text & "', '%')"
                strSQL += " and part_code = '" & Grid_MaterialList(i, 1) & "'"
                strSQL += ";"
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

            Thread_LoadingFormEnd()

            MSG_Error(Me, ex.Message)
            Exit Sub
        End Try

        DBClose()

        BTN_TempSave.Enabled = True
        BTN_Completed.Enabled = True
        BTN_CompletedCancel.Enabled = False

        Thread_LoadingFormEnd()

        MSG_Information(Me, "결과 확정이 취소 되었습니다..")

        BTN_Search_Click(Nothing, Nothing)

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged, CheckBox2.CheckedChanged

        ' configure filter
        Dim filter = New C1.Win.C1FlexGrid.ConditionFilter()

        If CheckBox1.Checked And IsNumeric(TB_MinQty.Text) Then
            If CDbl(TB_MinQty.Text) < 0 Then
                filter.Condition1.Operator = C1.Win.C1FlexGrid.ConditionOperator.LessThanOrEqualTo
            Else
                filter.Condition1.Operator = C1.Win.C1FlexGrid.ConditionOperator.LessThanOrEqualTo
            End If
            filter.Condition1.Parameter = CDbl(TB_MinQty.Text)
        Else
            filter.Condition1.Operator = C1.Win.C1FlexGrid.ConditionOperator.None
        End If

        If CheckBox2.Checked And IsNumeric(TB_MinPrice.Text) Then
            If CDbl(TB_MinPrice.Text) < 0 Then
                filter.Condition2.Operator = C1.Win.C1FlexGrid.ConditionOperator.LessThanOrEqualTo
            Else
                filter.Condition2.Operator = C1.Win.C1FlexGrid.ConditionOperator.GreaterThanOrEqualTo
            End If
            filter.Condition2.Parameter = CDbl(TB_MinPrice.Text)
        Else
            filter.Condition2.Operator = C1.Win.C1FlexGrid.ConditionOperator.None
        End If

        ' apply filter
        Dim showRow As Integer = 0
        Grid_MaterialList.BeginUpdate()
        Grid_MaterialList.ClearFilter()
        For r = 2 To Grid_MaterialList.Rows.Count - 1
            Dim visible1 As Boolean = False
            Dim visible2 As Boolean = False

            If CheckBox1.Checked Then
                If filter.Condition1.Apply(CDbl(Grid_MaterialList(r, 18))) Then
                    visible1 = True
                Else
                    visible1 = False
                End If
            End If

            If CheckBox2.Checked Then
                If filter.Condition2.Apply(CDbl(Grid_MaterialList(r, 19))) Then
                    visible2 = True
                Else
                    visible2 = False
                End If
            End If

            If CheckBox1.Checked = True And CheckBox2.Checked = False Then
                Grid_MaterialList.Rows(r).Visible = visible1
                If visible1 = True Then showRow += 1
            ElseIf CheckBox1.Checked = False And CheckBox2.Checked = True Then
                Grid_MaterialList.Rows(r).Visible = visible2
                If visible2 = True Then showRow += 1
            ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True Then
                If visible1 = True And visible2 = True Then
                    Grid_MaterialList.Rows(r).Visible = True
                    showRow += 1
                Else
                    Grid_MaterialList.Rows(r).Visible = False
                End If
            End If
        Next
        Grid_MaterialList.EndUpdate()

        If CheckBox1.Checked Or CheckBox2.Checked Then
            Label6.Text = "표시행 : " & Format(showRow, "#,##0")
            Label6.Visible = True
        Else
            Label6.Visible = False
        End If

    End Sub

    Private Sub TB_MinQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TB_MinQty.KeyPress

        If Not Char.IsDigit(e.KeyChar) And
            Not Char.IsControl(e.KeyChar) And
            Not e.KeyChar = "," And
            Not e.KeyChar = "-" Then
            e.Handled = True
        End If

    End Sub

    Private Sub TB_MinPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TB_MinPrice.KeyPress

        If Not Char.IsDigit(e.KeyChar) And
            Not Char.IsControl(e.KeyChar) And
            Not e.KeyChar = "," And
            Not e.KeyChar = "-" Then
            e.Handled = True
        End If

    End Sub

    Private Sub TB_MinQty_TextChanged(sender As Object, e As EventArgs) Handles TB_MinQty.TextChanged, TB_MinPrice.TextChanged

        If IsNumeric(sender.text) Then
            CheckBox1_CheckedChanged(Nothing, Nothing)
        Else
            Grid_MaterialList.ClearFilter()
            Label6.Text = "표시행 : " & Format(Grid_MaterialList.Rows.Count - 2, "#,##0")
        End If

    End Sub

    Dim selCol As Integer

    Private Sub Grid_MaterialList_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid_MaterialList.KeyDown

        If e.KeyCode = Keys.V AndAlso e.Modifiers = Keys.Control Then
            For i = 1 To Grid_MaterialList.Rows.Count - 1
                'Console.WriteLine("선택된 행 : " & Grid_MaterialList.IsCellSelected(i, selCol))
                If Grid_MaterialList.IsCellSelected(i, selCol) And Grid_MaterialList.Rows(i).Visible = True Then
                    Grid_MaterialList(i, selCol) = Clipboard.GetText
                End If
            Next
        End If

    End Sub

    Private Sub Grid_MaterialList_RowColChange(sender As Object, e As EventArgs) Handles Grid_MaterialList.RowColChange

        selCol = Grid_MaterialList.Col

        Select Case Grid_MaterialList.Col
            Case 18
                MSG_Information(Me, "임의 수정금지로 변경함." & vbCrLf & "스캔 데이터가 자재 창고로 업데이트 되므로 스캔데이터를 수정해야함.")
            Case 21
                Grid_MaterialList.AllowEditing = True
            Case Else
                Grid_MaterialList.AllowEditing = False
        End Select

    End Sub

    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Short

    Dim selectRow() As Integer
    Dim selectCol() As Integer
    Dim selStart_Row As Integer
    Dim selEnd_Row As Integer
    Dim selStart_Col As Integer
    Dim selEnd_Col As Integer

    Private Sub Grid_MaterialList_MouseDown(sender As Object, e As MouseEventArgs) Handles Grid_MaterialList.MouseDown

        'Dim mRow As Integer = Grid_MaterialList.MouseRow
        'Dim mCol As Integer = Grid_MaterialList.MouseCol
        'selStart_Row = mRow
        'selStart_Col = mCol

    End Sub

    Private Sub Grid_MaterialList_MouseUp(sender As Object, e As MouseEventArgs) Handles Grid_MaterialList.MouseUp

        'Dim mRow As Integer = Grid_MaterialList.MouseRow
        'Dim mCol As Integer = Grid_MaterialList.MouseCol
        'selEnd_Row = mRow
        'selEnd_Col = mCol

        'Dim cs As CellStyle = Grid_MaterialList.Styles.Add("select_style")
        'cs.BackColor = Color.LightBlue

        'If e.Button = MouseButtons.Left And GetAsyncKeyState(17) Then
        '    If Not selStart_Row = selEnd_Row And selStart_Col = selEnd_Col Then
        '        '세로로 이동
        '        For i = selStart_Row To selEnd_Row
        '            Grid_MaterialList.SetCellStyle(i, mCol, cs)
        '            If IsNothing(selectRow) Then
        '                ReDim selectRow(0)
        '                ReDim selectCol(0)
        '            Else
        '                ReDim Preserve selectRow(selectRow.Length)
        '                ReDim Preserve selectCol(selectCol.Length)
        '            End If
        '            selectRow(selectRow.Length - 1) = i
        '            selectCol(selectCol.Length - 1) = mCol
        '        Next
        '    ElseIf selStart_Row = selEnd_Row And Not selStart_Col = selEnd_Col Then
        '        '가로로 이동
        '        For i = selStart_Col To selEnd_Col
        '            Grid_MaterialList.SetCellStyle(mRow, i, cs)
        '            If IsNothing(selectRow) Then
        '                ReDim selectRow(0)
        '                ReDim selectCol(0)
        '            Else
        '                ReDim Preserve selectRow(selectRow.Length)
        '                ReDim Preserve selectCol(selectCol.Length)
        '            End If
        '            selectRow(selectRow.Length - 1) = mRow
        '            selectCol(selectCol.Length - 1) = i
        '        Next
        '    ElseIf selStart_Row = selEnd_Row And selStart_Col = selEnd_Col Then
        '        '제자리 클릭
        '        Grid_MaterialList.SetCellStyle(mRow, mCol, cs)
        '        If IsNothing(selectRow) Then
        '            ReDim selectRow(0)
        '            ReDim selectCol(0)
        '        Else
        '            ReDim Preserve selectRow(selectRow.Length)
        '            ReDim Preserve selectCol(selectCol.Length)
        '        End If
        '        selectRow(selectRow.Length - 1) = mRow
        '        selectCol(selectCol.Length - 1) = mCol
        '    Else
        '        '가로, 세로 모두 이동
        '        For i = selStart_Row To selEnd_Row
        '            For j = selStart_Col To selEnd_Col
        '                Grid_MaterialList.SetCellStyle(i, j, cs)
        '                If IsNothing(selectRow) Then
        '                    ReDim selectRow(0)
        '                    ReDim selectCol(0)
        '                Else
        '                    ReDim Preserve selectRow(selectRow.Length)
        '                    ReDim Preserve selectCol(selectCol.Length)
        '                End If
        '                selectRow(selectRow.Length - 1) = i
        '                selectCol(selectCol.Length - 1) = j
        '            Next
        '        Next
        '    End If
        '    Console.WriteLine(selectRow.ToString & ", " & selectCol.ToString)
        'Else
        '    selectRow = Nothing
        '    selectCol = Nothing
        'End If

    End Sub

    Private Sub Grid_PlanList_Layout(sender As Object, e As LayoutEventArgs) Handles Grid_PlanList.Layout

    End Sub
End Class