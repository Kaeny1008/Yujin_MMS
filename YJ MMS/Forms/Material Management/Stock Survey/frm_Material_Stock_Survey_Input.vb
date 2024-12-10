Imports C1.Win.C1FlexGrid
Imports MySqlConnector

Public Class frm_Material_Stock_Survey_Input

    Dim selCustomer As String
    Private Sub frm_Material_Stock_Survey_Input_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub Grid_Setting()

        With Grid_MaterialList
            .AllowEditing = True
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 19
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
            rngM = .GetCellRange(0, 15, 1, 17)
            rngM.Data = "재고"
            Grid_MaterialList(1, 15) = "전산재고"
            Grid_MaterialList(1, 16) = "실사수량"
            Grid_MaterialList(1, 17) = "차이"
            rngM = .GetCellRange(0, 18, 1, 18)
            rngM.Data = "Modify"
            For i = 6 To 17
                .Cols(i).DataType = GetType(Integer)
                .Cols(i).Format = "#,##0"
            Next
            .Cols(15).StyleNew.BackColor = Color.LightYellow
            .Cols(16).StyleNew.BackColor = Color.Bisque
            .Cols(18).Visible = False
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

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart(Me)

        Grid_PlanList.Redraw = False
        Grid_PlanList.Rows.Count = 1

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_material_stock_survey(4"
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
            LB_InspectionNo.Text = Grid_PlanList(selRow, 3)
            Load_Plan_Content(Grid_PlanList(selRow, 3))
            BTN_Save.Enabled = True
            TB_Barcode.SelectAll()
            TB_Barcode.Focus()
            selCustomer = Grid_PlanList(selRow, 2)
            Thread_LoadingFormEnd()
        End If

    End Sub

    Private Sub Load_Plan_Content(ByVal paln_no As String)

        Grid_MaterialList.Redraw = False
        Grid_MaterialList.Rows.Count = 2

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_material_stock_survey(3"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & paln_no & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim checkString As String
            If CDbl(sqlDR("check_qty")) = 0 Then
                checkString = Format(sqlDR("stock_qty") * -1, "#,##0")
            Else
                checkString = Format(sqlDR("check_qty") - sqlDR("stock_qty"), "#,##0")
            End If
            Dim insertString As String = Grid_MaterialList.Rows.Count - 1 &
                vbTab & sqlDR("part_code") &
                vbTab & sqlDR("part_type") &
                vbTab & sqlDR("part_specification") &
                vbTab & sqlDR("part_category") &
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
                vbTab & Format(sqlDR("stock_qty"), "#,##0") &
                vbTab & Format(sqlDR("check_qty"), "#,##0") &
                vbTab & checkString
            Grid_MaterialList.AddItem(insertString)
            If sqlDR("check_qty") - sqlDR("stock_qty") = 0 Then
                Grid_MaterialList.Rows(Grid_MaterialList.Rows.Count - 1).StyleNew.ForeColor = Color.Black
            ElseIf sqlDR("check_qty") - sqlDR("stock_qty") < 0 Then
                Grid_MaterialList.Rows(Grid_MaterialList.Rows.Count - 1).StyleNew.ForeColor = Color.Red
            ElseIf sqlDR("check_qty") - sqlDR("stock_qty") > 0 Then
                Grid_MaterialList.Rows(Grid_MaterialList.Rows.Count - 1).StyleNew.ForeColor = Color.Blue
            End If

        Loop
        sqlDR.Close()

        DBClose()

        LB_totalCount.Text = Grid_MaterialList.Rows.Count - 2

        Grid_MaterialList.AutoSizeCols()
        Grid_MaterialList.Redraw = True

    End Sub

    Private Sub Grid_MaterialList_RowColChange(sender As Object, e As EventArgs) Handles Grid_MaterialList.RowColChange

        Select Case Grid_MaterialList.Col
            Case 16
                Grid_MaterialList.AllowEditing = True
            Case Else
                Grid_MaterialList.AllowEditing = False
        End Select

    End Sub

    Private Sub TB_Barcode_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_Barcode.KeyDown

        If (e.KeyCode = 13) And
            (Not TB_Barcode.Text = String.Empty) Then
            If selCustomer = String.Empty Then
                MessageBox.Show(Me,
                                "사용 고객사를 먼저 선택하여 주십시오.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                TB_Barcode.SelectAll()
                Exit Sub
            End If

            If selCustomer = "LS Mecapion" Then
                Try
                    Dim splitBarcode() As String = TB_Barcode.Text.Split("!")
                    Dim partCode As String = splitBarcode(0)

                    Dim findRow As Integer = Grid_MaterialList.FindRow(partCode, 2, 1, True)

                    If findRow = -1 Then
                        MessageBox.Show("리스트에서 해당 자재를 찾을 수 없습니다.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        TB_Barcode.SelectAll()
                        TB_Barcode.Focus()
                        Exit Sub
                    End If

                    Grid_MaterialList.TopRow = findRow
                    Grid_MaterialList.Row = findRow
                    Grid_MaterialList.Select(findRow, 16)
                    Grid_MaterialList.StartEditing(findRow, 16)

                Catch ex As Exception
                    MessageBox.Show(Me,
                                    ex.Message,
                                    msg_form,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    Exit Sub
                End Try
            Else
                MsgBox("현재 LS Mecapion외 지원되지 않습니다.")
            End If
        End If

    End Sub

    Private Sub Grid_MaterialList_AfterEdit(sender As Object, e As RowColEventArgs) Handles Grid_MaterialList.AfterEdit

        If e.Col = 16 Then
            Dim orgCount As Integer = Grid_MaterialList(e.Row, 15)
            Dim checkCount As Integer = Grid_MaterialList(e.Row, 16)

            Grid_MaterialList(e.Row, 17) = checkCount - orgCount

            If Grid_MaterialList(e.Row, 17) = 0 Then
                Grid_MaterialList.Rows(e.Row).StyleNew.ForeColor = Color.Black
            ElseIf Grid_MaterialList(e.Row, 17) > 0 Then
                Grid_MaterialList.Rows(e.Row).StyleNew.ForeColor = Color.Blue
            ElseIf Grid_MaterialList(e.Row, 17) < 0 Then
                Grid_MaterialList.Rows(e.Row).StyleNew.ForeColor = Color.Red
            End If
            Grid_MaterialList(e.Row, 18) = "Modify"
            TB_Barcode.SelectAll()
            TB_Barcode.Focus()
        End If

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        If MessageBox.Show("저장 하시겠습니까?", msg_form, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        If DBConnect() = False Then Exit Sub

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            For i = 2 To Grid_MaterialList.Rows.Count - 1
                If Grid_MaterialList(i, 18) = "Modify" Then
                    strSQL += "update tb_mms_material_stock_survey_plan_content set"
                    strSQL += " check_qty = " & CDbl(Grid_MaterialList(i, 16))
                    strSQL += ", check_result = " & CDbl(Grid_MaterialList(i, 17))
                    strSQL += ", check_date = '" & writeDate & "'"
                    strSQL += ", check_id = '" & loginID & "'"
                    strSQL += " where content_no = '" & LB_InspectionNo.Text & Format(CDbl(Grid_MaterialList(i, 0)), "0000") & "'"
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
            MessageBox.Show(frm_Main,
                            ex.Message,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Exit Sub
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        MessageBox.Show(frm_Main,
                        "저장완료.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

    End Sub
End Class