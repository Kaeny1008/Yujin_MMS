Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_SMD_Production_End

    Dim selFactoryCode As String
    Dim historyIndex As Integer

    Private Sub frm_SMD_Production_End_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Close()

    End Sub

    Private Sub Grid_Setting()

        With Grid_History
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 9
            .Cols.Fixed = 1
            .Rows.Count = 2
            .Rows.Fixed = 2
            For i = 0 To .Cols.Count - 1
                .Cols(i).AllowMerging = True
            Next
            For i = 0 To .Rows.Count - 1
                .Rows(i).AllowMerging = True
            Next
            Dim rngM As CellRange = .GetCellRange(0, 0, 1, 0)
            rngM.Data = "No"
            rngM = .GetCellRange(0, 1, 1, 2)
            rngM.Data = "생산일자"
            Grid_History(1, 1) = "시작"
            Grid_History(1, 2) = "종료"
            rngM = .GetCellRange(0, 3, 1, 3)
            rngM.Data = "Operator"
            rngM = .GetCellRange(0, 4, 1, 4)
            rngM.Data = "Inspector"
            rngM = .GetCellRange(0, 5, 1, 7)
            rngM.Data = "수량"
            Grid_History(1, 5) = "시작"
            Grid_History(1, 6) = "불량"
            Grid_History(1, 7) = "종료"
            rngM = .GetCellRange(0, 8, 1, 8)
            rngM.Data = "비고"
            '.Rows(0).StyleNew.Font = New Font("굴림", 12, FontStyle.Bold)
            '.Rows(1).StyleNew.Font = New Font("굴림", 12, FontStyle.Bold)
            '.Rows(2).StyleNew.Font = New Font("굴림", 12, FontStyle.Bold)
            '.Font = New Font("굴림", 12, FontStyle.Regular)
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            .ExtendLastCol = True
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            '.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
            '.DragMode = C1.Win.C1FlexGrid.DragModeEnum.Manual
            '.DropMode = C1.Win.C1FlexGrid.DropModeEnum.Manual
            .SelectionMode = SelectionModeEnum.Default
        End With

    End Sub

    Private Sub CB_Department_DropDown(sender As Object, e As EventArgs) Handles CB_Department.DropDown

        CB_Department.Items.Clear()

        DBConnect()

        Dim strSQL As String = "select sub_code_name from tb_code_sub"
        strSQL += " where main_code = 'MC00000001' order by sub_code_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            CB_Department.Items.Add(sqlDR("sub_code_name"))
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub CB_Department_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_Department.SelectionChangeCommitted

        DBConnect()

        Dim strSQL As String = "select sub_code from tb_code_sub"
        strSQL += " where sub_code_name = '" & CB_Department.Text & "'"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            selFactoryCode = sqlDR("sub_code")
        Loop
        sqlDR.Close()

        DBClose()

        CB_Line.SelectedIndex = -1

    End Sub

    Private Sub CB_Line_DropDown(sender As Object, e As EventArgs) Handles CB_Line.DropDown

        CB_Line.Items.Clear()

        DBConnect()

        Dim strSQL As String = "select last_code_name from tb_code_last"
        strSQL += " where sub_code = '" & selFactoryCode & "' order by last_code_name"


        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            CB_Line.Items.Add(sqlDR("last_code_name"))
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub CB_Line_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_Line.SelectionChangeCommitted



    End Sub

    Private Sub BTN_LineSelect_Click(sender As Object, e As EventArgs) Handles BTN_LineSelect.Click

        Thread_LoadingFormStart()

        Grid_History.Redraw = False
        Grid_History.Rows.Count = 2
        TB_OrderIndex.Text = String.Empty
        TB_CustomerCode.Text = String.Empty
        TB_CustomerName.Text = String.Empty
        TB_ModelCode.Text = String.Empty
        TB_ItemCode.Text = String.Empty
        TB_ItemName.Text = String.Empty
        TB_Workside.Text = String.Empty
        TB_WorkingQty.Text = String.Empty
        TB_Operator.Text = String.Empty

        Load_OrderInformation()
        Load_InspectList()


        If TB_OrderIndex.Text = String.Empty Then
            Thread_LoadingFormEnd()
            MessageBox.Show("생산진행 중인 내역이 없습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Exit Sub
        End If

        Grid_History.AutoSizeCols()
        Grid_History.Redraw = True
        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_OrderInformation()

        DBConnect()

        Dim strSQL As String = "call sp_mms_smd_production_end(0"
        strSQL += ", '" & CB_Department.Text & "'"
        strSQL += ", '" & CB_Line.Text & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_OrderIndex.Text = sqlDR("order_index")
            TB_CustomerCode.Text = sqlDR("customer_code")
            TB_CustomerName.Text = sqlDR("customer_name")
            TB_ModelCode.Text = sqlDR("model_code")
            TB_ItemCode.Text = sqlDR("item_code")
            TB_ItemName.Text = sqlDR("item_name")
            TB_Workside.Text = sqlDR("work_side")
            TB_WorkingQty.Text = Format(sqlDR("modify_order_quantity"), "#,##0")
            TB_Operator.Text = sqlDR("smd_operater")
            historyIndex = sqlDR("history_index")
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub Load_InspectList()

        Grid_History.Redraw = False
        Grid_History.Rows.Count = 2

        DBConnect()

        Dim strSQL As String = "call sp_mms_smd_production_end(3"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_OrderIndex.Text & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim endDate As String = sqlDR("smd_end_date")
            If Not endDate = String.Empty Then
                Format(sqlDR("smd_end_date"), "yyyy-MM-dd HH:mm:ss")
            End If
            Dim insertString As String = Grid_History.Rows.Count - 1 & vbTab &
                Format(sqlDR("smd_start_date"), "yyyy-MM-dd HH:mm:ss") & vbTab &
                endDate & vbTab &
                sqlDR("smd_operater") & vbTab &
                sqlDR("smd_inspecter") & vbTab &
                sqlDR("start_quantity") & vbTab &
                sqlDR("fault_quantity") & vbTab &
                sqlDR("end_quantity")

            GridWriteText(insertString, Me, Grid_History, Color.Black)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_History.AutoSizeCols()
        Grid_History.Redraw = True

    End Sub

    Private Sub BTN_FaultRegister_Click(sender As Object, e As EventArgs) Handles BTN_FaultRegister.Click

        If TB_OrderIndex.Text = String.Empty Then
            MessageBox.Show("생산중인 모델이 없습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Exit Sub
        End If

        If TB_Inspecter.Text = String.Empty Then
            MessageBox.Show("검사자를 입력하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Exit Sub
        End If

        frm_SMD_Fault_Register.Label1.Text = TB_OrderIndex.Text
        frm_SMD_Fault_Register.Label2.Text = historyIndex
        If Not frm_SMD_Fault_Register.Visible Then frm_SMD_Fault_Register.Show()
        frm_SMD_Fault_Register.Focus()

    End Sub

    Private Sub BTN_PauseRegister_Click(sender As Object, e As EventArgs) Handles BTN_PauseRegister.Click

        'If TB_OrderIndex.Text = String.Empty Then
        '    MessageBox.Show("생산중인 모델이 없습니다.",
        '                    msg_form,
        '                    MessageBoxButtons.OK,
        '                    MessageBoxIcon.Information)
        '    Exit Sub
        'End If

    End Sub

    Private Sub BTN_EndRegister_Click(sender As Object, e As EventArgs) Handles BTN_EndRegister.Click

        'If TB_OrderIndex.Text = String.Empty Then
        '    MessageBox.Show("생산중인 모델이 없습니다.",
        '                    msg_form,
        '                    MessageBoxButtons.OK,
        '                    MessageBoxIcon.Information)
        '    Exit Sub
        'End If

    End Sub
End Class