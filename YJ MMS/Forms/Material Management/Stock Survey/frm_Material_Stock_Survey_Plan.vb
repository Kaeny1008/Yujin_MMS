Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Material_Stock_Survey_Plan
    Private Sub frm_Material_Stock_Survey_Plan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
            rngM.Data = "단가(\)"
            rngM = .GetCellRange(0, 6, 1, 6)
            rngM.Data = "공급사"
            rngM = .GetCellRange(0, 7, 0, 15)
            rngM.Data = "재고"
            Grid_MaterialList(1, 7) = "기초재고"
            Grid_MaterialList(1, 8) = "입고"
            Grid_MaterialList(1, 9) = "Loss"
            Grid_MaterialList(1, 10) = "납품"
            Grid_MaterialList(1, 11) = "계획대기"
            Grid_MaterialList(1, 12) = "생산 중"
            Grid_MaterialList(1, 13) = "생산 완료"
            Grid_MaterialList(1, 14) = "품번전환"
            Grid_MaterialList(1, 15) = "반출"
            rngM = .GetCellRange(0, 16, 1, 16)
            rngM.Data = "전산재고"
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

    Private Sub BTN_NewPlan_Click(sender As Object, e As EventArgs) Handles BTN_NewPlan.Click

        CB_CustomerName.Enabled = True
        TB_Purpose.Enabled = True
        Panel2.Enabled = True
        LB_InspectionNo.Text = Load_PlanNo()
        LB_ID.Text = loginID
        DTP_PlanDate.Enabled = True
        DTP_PlanDate.Value = Now
        BTN_MaterialSearch.Enabled = True
        BTN_Print.Enabled = False
        BTN_PlanConfirm.Enabled = False

        Grid_MaterialList.Rows.Count = 2

        Load_CustomerList()

    End Sub

    Private Function Load_PlanNo() As String

        Thread_LoadingFormStart(Me)

        DBConnect()

        Dim planNo As String = String.Empty
        Dim strSQL As String = "select f_mms_new_material_survey_no('" & Format(Now, "yyyy-MM-dd") & "') as plan_no"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            planNo = sqlDR("plan_no")
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

        Return planNo

    End Function

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

    Private Sub BTN_MaterialSearch_Click(sender As Object, e As EventArgs) Handles BTN_MaterialSearch.Click

        If TB_CustomerCode.Text = String.Empty Then
            MSG_Information(Me, "고객사를 먼저 선택하여 주십시오.")
            Exit Sub
        End If

        Thread_LoadingFormStart(Me)

        Grid_MaterialList.Redraw = False
        Grid_MaterialList.Rows.Count = 2

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_stock_survey(0"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
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
                sqlDR("part_type") & vbTab &
                sqlDR("part_spec") & vbTab &
                sqlDR("part_category") & vbTab &
                Format(sqlDR("unit_price"), "#,##0.000") & vbTab &
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

            Dim stock_qty As Double = sqlDR("basic_stock") +
                sqlDR("in_qty") -
                sqlDR("loss_qty") -
                sqlDR("delivery_qty") -
                sqlDR("ready_qty") -
                sqlDR("run_qty") -
                sqlDR("completed_qty") -
                sqlDR("code_change_qty") -
                sqlDR("return_qty")
            insert_String += vbTab & Format((stock_qty), "#,##0")

            If Not stock_qty = 0 Then
                Grid_MaterialList.AddItem(insert_String)
            End If

            'If stock_qty < 0 Then
            '    Grid_MaterialList.Rows(Grid_MaterialList.Rows.Count - 1).StyleNew.ForeColor = Color.Red
            'ElseIf stock_qty = 0 Then
            '    Grid_MaterialList.Rows(Grid_MaterialList.Rows.Count - 1).StyleNew.ForeColor = Color.Blue
            'ElseIf stock_qty > 0 Then
            '    Grid_MaterialList.Rows(Grid_MaterialList.Rows.Count - 1).StyleNew.ForeColor = Color.Black
            'End If
        Loop
        sqlDR.Close()

        DBClose()

        Grid_MaterialList.AutoSizeCols()
        Grid_MaterialList.Redraw = True

        If Grid_MaterialList.Rows.Count > 2 Then
            BTN_MaterialSearch.Enabled = False
            'BTN_Print.Enabled = True
            BTN_PlanConfirm.Enabled = True
            Label8.Text = Format(Grid_MaterialList.Rows.Count - 2, "#,##0 EA")
        Else
            Label8.Text = "0 EA"
        End If

        Thread_LoadingFormEnd()

    End Sub

    Private Sub BTN_PlanConfirm_Click(sender As Object, e As EventArgs) Handles BTN_PlanConfirm.Click

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
        msgString += vbCrLf & vbCrLf & "재고조사 계획을 확정 하시겠습니까?"

        If MSG_Question(Me, msg_form) = False Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            strSQL += "insert into tb_mms_material_stock_survey_plan("
            strSQL += "plan_no, plan_date, plan_class, plan_purpose"
            strSQL += ", customer_code, write_date, write_id, plan_status"
            strSQL += ") values ("
            strSQL += "'" & LB_InspectionNo.Text & "'"
            strSQL += ",'" & Format(DTP_PlanDate.Value, "yyyy-MM-dd") & "'"
            If RadioButton1.Checked Then
                strSQL += ",'" & RadioButton1.Text & "'"
            ElseIf RadioButton2.Checked Then
                strSQL += ",'" & RadioButton2.Text & "'"
            End If
            strSQL += ",'" & TB_Purpose.Text & "'"
            strSQL += ",'" & TB_CustomerCode.Text & "'"
            strSQL += ",'" & writeDate & "'"
            strSQL += ",'" & LB_ID.Text & "'"
            strSQL += ", 'Run'"
            strSQL += ");"

            For i = 2 To Grid_MaterialList.Rows.Count - 1
                strSQL += "insert into tb_mms_material_stock_survey_plan_content("
                strSQL += "content_no, part_code, unit_price, basic_qty, in_qty, loss_qty, delivery_qty, plan_ready_qty"
                strSQL += ", production_qty, production_completed_qty, code_change_qty, return_qty, stock_qty"
                strSQL += ") values ("
                strSQL += "'" & LB_InspectionNo.Text & Format(CDbl(Grid_MaterialList(i, 0)), "0000") & "'"
                strSQL += ",'" & Grid_MaterialList(i, 1) & "'"
                strSQL += "," & CDbl(Grid_MaterialList(i, 5)) & ""
                strSQL += "," & CDbl(Grid_MaterialList(i, 7)) & ""
                strSQL += "," & CDbl(Grid_MaterialList(i, 8)) & ""
                strSQL += "," & CDbl(Grid_MaterialList(i, 9)) & ""
                strSQL += "," & CDbl(Grid_MaterialList(i, 10)) & ""
                strSQL += "," & CDbl(Grid_MaterialList(i, 11)) & ""
                strSQL += "," & CDbl(Grid_MaterialList(i, 12)) & ""
                strSQL += "," & CDbl(Grid_MaterialList(i, 13)) & ""
                strSQL += "," & CDbl(Grid_MaterialList(i, 14)) & ""
                strSQL += "," & CDbl(Grid_MaterialList(i, 15)) & ""
                strSQL += "," & CDbl(Grid_MaterialList(i, 16)) & ""
                strSQL += ");"
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

        BTN_PlanConfirm.Enabled = False
        BTN_PlanCancel.Enabled = True
        TB_Purpose.Enabled = False
        Panel2.Enabled = False
        CB_CustomerName.Enabled = False

        MSG_Information(Me, "계획 확정완료.")

    End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart(Me)

        Grid_PlanList.Redraw = False
        Grid_PlanList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_stock_survey(1"
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
            Load_Plan_Content(Grid_PlanList(selRow, 3))

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
            If sqlDR("plan_status") = "Run" Then
                BTN_PlanCancel.Enabled = True
            Else
                BTN_PlanCancel.Enabled = False
            End If
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub Load_Plan_Content(ByVal paln_no As String)

        Grid_MaterialList.Redraw = False
        Grid_MaterialList.Rows.Count = 2

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_stock_survey(3"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & paln_no & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = Grid_MaterialList.Rows.Count - 1 &
                vbTab & sqlDR("part_code") &
                vbTab & sqlDR("part_type") &
                vbTab & sqlDR("part_specification") &
                vbTab & sqlDR("part_category") &
                vbTab & Format(sqlDR("unit_price"), "#,##0.000") &
                vbTab & sqlDR("supplier") &
                vbTab & Format(sqlDR("basic_qty"), "#,##0") &
                vbTab & Format(sqlDR("in_qty"), "#,##0") &
                vbTab & Format(sqlDR("loss_qty"), "#,##0") &
                vbTab & Format(sqlDR("delivery_qty"), "#,##0") &
                vbTab & Format(sqlDR("plan_ready_qty"), "#,##0") &
                vbTab & Format(sqlDR("production_qty"), "#,##0") &
                vbTab & Format(sqlDR("production_completed_qty"), "#,##0") &
                vbTab & Format(sqlDR("code_change_qty"), "#,##0") &
                vbTab & Format(sqlDR("return_qty"), "#,##0") &
                vbTab & Format(sqlDR("stock_qty"), "#,##0")
            Grid_MaterialList.AddItem(insertString)
        Loop
        sqlDR.Close()

        DBClose()

        Label8.Text = Grid_MaterialList.Rows.Count - 2 & " EA"

        Grid_MaterialList.AutoSizeCols()
        Grid_MaterialList.Redraw = True

    End Sub

    Private Sub BTN_PlanCancel_Click(sender As Object, e As EventArgs) Handles BTN_PlanCancel.Click

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
        msgString += vbCrLf & vbCrLf & "재고조사 계획을 취소 하시겠습니까?"

        If MSG_Question(Me, msg_form) = False Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            strSQL = "update tb_mms_material_stock_survey_plan set"
            strSQL += " plan_status = 'Cancel'"
            strSQL += " where plan_no = '" & LB_InspectionNo.Text & "'"
            strSQL += ";"

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
            MessageBox.Show(frm_Main,
                            ex.Message,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Exit Sub
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        Control_Init()

        MSG_Information(Me, "계획 취소완료.")

        BTN_Search_Click(Nothing, Nothing)

    End Sub

    Private Sub Control_Init()

        LB_InspectionNo.Text = String.Empty
        LB_ID.Text = String.Empty
        RadioButton1.Checked = True
        Panel2.Enabled = False
        TB_Purpose.Text = String.Empty
        TB_Purpose.Enabled = False
        CB_CustomerName.Items.Clear()
        TB_CustomerCode.Text = String.Empty

        Grid_MaterialList.Rows.Count = 2

        Label8.Text = "0 EA"

        BTN_MaterialSearch.Enabled = False
        BTN_PlanConfirm.Enabled = False
        BTN_Print.Enabled = False
        BTN_PlanCancel.Enabled = False

    End Sub
End Class