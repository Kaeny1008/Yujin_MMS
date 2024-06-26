Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Wave_Selective_Production_End

    Public historyIndex As String

    Private Sub frm_Wave_Selective_Production_End_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
            .Cols.Count = 8
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
            rngM.Data = "Inspector"
            rngM = .GetCellRange(0, 4, 1, 6)
            rngM.Data = "수량"
            Grid_History(1, 4) = "시작"
            Grid_History(1, 5) = "불량"
            Grid_History(1, 6) = "종료"
            rngM = .GetCellRange(0, 7, 1, 7)
            rngM.Data = "비고"
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
            .SelectionMode = SelectionModeEnum.Default
        End With

        With Grid_OrderList
            .AllowEditing = False
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 9
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = True
            .ShowCursor = True
            '.ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            '.Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            '.Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            '.SelectionMode = SelectionModeEnum.Default
            .Cols(2).Visible = False
            .Cols(4).Visible = False
            .Cols(8).Visible = False
        End With

        Grid_OrderList(0, 0) = "No"
        Grid_OrderList(0, 1) = "주문번호"
        Grid_OrderList(0, 2) = "고객사 코드"
        Grid_OrderList(0, 3) = "고객사"
        Grid_OrderList(0, 4) = "모델코드"
        Grid_OrderList(0, 5) = "품번"
        Grid_OrderList(0, 6) = "품명"
        Grid_OrderList(0, 7) = "작업수량"
        Grid_OrderList(0, 8) = "history_index"

        Grid_OrderList.AutoSizeCols()

    End Sub

    Public Sub CB_Line_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_Line.SelectionChangeCommitted

        Thread_LoadingFormStart()

        TB_OrderIndex.Text = String.Empty
        TB_CustomerCode.Text = String.Empty
        TB_CustomerName.Text = String.Empty
        TB_ModelCode.Text = String.Empty
        TB_ItemCode.Text = String.Empty
        TB_ItemName.Text = String.Empty
        TB_TotalQty.Text = String.Empty
        Grid_OrderList.Rows.Count = 1
        Grid_History.Rows.Count = 2

        Load_OrderInformation()

        If Grid_OrderList.Rows.Count = 1 Then
            Thread_LoadingFormEnd()
            MessageBox.Show("생산진행 중인 내역이 없습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Exit Sub
        End If

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_OrderInformation()

        Grid_OrderList.Redraw = False
        Grid_OrderList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_wave_selective_production(12"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & CB_Line.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = Grid_OrderList.Rows.Count & vbTab &
                sqlDR("order_index") & vbTab &
                sqlDR("customer_code") & vbTab &
                sqlDR("customer_name") & vbTab &
                sqlDR("model_code") & vbTab &
                sqlDR("item_code") & vbTab &
                sqlDR("item_name") & vbTab &
                Format(sqlDR("modify_order_quantity"), "#,##0") & vbTab &
                sqlDR("history_index")
            GridWriteText(insertString, Me, Grid_OrderList, Color.Black)
            GridColsAutoSize(Me, Grid_OrderList)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_OrderList.Redraw = True

        If Grid_OrderList.Rows.Count > 1 Then
            Dim findRow As Integer = 1
            If Not historyIndex = String.Empty Then
                findRow = Grid_OrderList.FindRow(historyIndex, 1, 8, False)
                'For i = 1 To Grid_OrderList.Rows.Count - 1
                '    Console.WriteLine(historyIndex & ", " & Grid_OrderList(i, 10) & ", " & Grid_OrderList(i, 10).Equals(CStr(historyIndex)))
                'Next
                If findRow = -1 Then
                    findRow = 1
                End If
            End If
            TB_OrderIndex.Text = Grid_OrderList(findRow, 1)
            TB_CustomerCode.Text = Grid_OrderList(findRow, 2)
            TB_CustomerName.Text = Grid_OrderList(findRow, 3)
            TB_ModelCode.Text = Grid_OrderList(findRow, 4)
            TB_ItemCode.Text = Grid_OrderList(findRow, 5)
            TB_ItemName.Text = Grid_OrderList(findRow, 6)
            TB_TotalQty.Text = Grid_OrderList(findRow, 7)
            historyIndex = Grid_OrderList(findRow, 8)
            Load_InspectList()
        End If

    End Sub

    Public Sub Control_Initialize()

        Grid_History.Rows.Count = 2

        TB_OrderIndex.Text = String.Empty
        TB_CustomerCode.Text = String.Empty
        TB_CustomerName.Text = String.Empty
        TB_ModelCode.Text = String.Empty
        TB_ItemCode.Text = String.Empty
        TB_ItemName.Text = String.Empty
        TB_TotalQty.Text = String.Empty

    End Sub

    Public Sub Load_InspectList()

        Grid_History.Redraw = False
        Grid_History.Rows.Count = 2

        DBConnect()

        Dim strSQL As String = "call sp_mms_wave_selective_production(13"
        strSQL += ", '" & TB_OrderIndex.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader
        Dim workingCompletedQty As Integer = 0

        Do While sqlDR.Read
            Dim endDate As String = String.Empty
            If Not IsDBNull(sqlDR("ws_end_date")) Then
                endDate = Format(sqlDR("ws_end_date"), "yyyy-MM-dd HH:mm:ss")
            End If
            Dim insertString As String = Grid_History.Rows.Count - 1 & vbTab &
                Format(sqlDR("ws_start_date"), "yyyy-MM-dd HH:mm:ss") & vbTab &
                endDate & vbTab &
                sqlDR("ws_inspector") & vbTab &
                sqlDR("start_quantity") & vbTab &
                sqlDR("fault_quantity") & vbTab &
                sqlDR("end_quantity") & vbTab &
                sqlDR("history_note")

            GridWriteText(insertString, Me, Grid_History, Color.Black)

            If Not sqlDR("ws_inspector") = String.Empty Then
                TB_Inspector.Text = sqlDR("ws_inspector")
            End If

            workingCompletedQty += sqlDR("end_quantity")
        Loop
        sqlDR.Close()

        DBClose()

        Grid_History.AutoSizeCols()
        Grid_History.AutoSizeRows(2, 0, Grid_History.Rows.Count - 1, Grid_History.Cols.Count - 1, 0, AutoSizeFlags.None)
        Grid_History.Redraw = True

        If workingCompletedQty = CDbl(TB_TotalQty.Text) Then
            MessageBox.Show("생산이 완료된 주문입니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Control_Initialize()
        End If

    End Sub

    Private Sub BTN_Reload_Click(sender As Object, e As EventArgs) Handles BTN_Reload.Click

        CB_Line_SelectionChangeCommitted(Nothing, Nothing)

    End Sub

    Private Sub Grid_OrderList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Grid_OrderList.MouseDoubleClick

        Dim selRow As Integer = Grid_OrderList.MouseRow
        If e.Button = MouseButtons.Left And selRow > 0 Then
            TB_OrderIndex.Text = Grid_OrderList(selRow, 1)
            TB_CustomerCode.Text = Grid_OrderList(selRow, 2)
            TB_CustomerName.Text = Grid_OrderList(selRow, 3)
            TB_ModelCode.Text = Grid_OrderList(selRow, 4)
            TB_ItemCode.Text = Grid_OrderList(selRow, 5)
            TB_ItemName.Text = Grid_OrderList(selRow, 6)
            TB_TotalQty.Text = Grid_OrderList(selRow, 7)
            historyIndex = Grid_OrderList(selRow, 8)
            Load_InspectList()
        End If

    End Sub

    Private Sub BTN_FaultRegister_Click(sender As Object, e As EventArgs) Handles BTN_FaultRegister.Click

        If TB_OrderIndex.Text = String.Empty Then
            MessageBox.Show("생산중인 모델이 없습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Exit Sub
        End If

        If TB_Inspector.Text = String.Empty Then
            MessageBox.Show("검사자를 입력하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            TB_Inspector.Focus()
            Exit Sub
        End If

        frm_WS_Fault_Register.LB_OrderIndex.Text = TB_OrderIndex.Text
        frm_WS_Fault_Register.LB_HistoryIndex.Text = historyIndex
        frm_WS_Fault_Register.LB_ItemCode.Text = TB_ItemCode.Text
        frm_WS_Fault_Register.LB_ItemName.Text = TB_ItemName.Text
        frm_WS_Fault_Register.LB_SMDLine.Text = CB_Line.Text
        If Not frm_WS_Fault_Register.Visible Then frm_WS_Fault_Register.Show()
        frm_WS_Fault_Register.Focus()

    End Sub

    Private Sub BTN_PauseRegister_Click(sender As Object, e As EventArgs) Handles BTN_PauseRegister.Click

        If TB_OrderIndex.Text = String.Empty Then
            MessageBox.Show("생산중인 모델이 없습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Exit Sub
        End If

        If TB_Inspector.Text = String.Empty Then
            MessageBox.Show("검사자를 입력하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            TB_Inspector.Focus()
            Exit Sub
        End If

        Dim totalDefectCount As Integer = 0

        For i = 2 To Grid_History.Rows.Count - 1
            totalDefectCount += Grid_History(i, 5)
        Next

        frm_WS_Magazine_Kitting.lastWorkingCount = Grid_History(Grid_History.Rows.Count - 1, 4)
        frm_WS_Magazine_Kitting.totalDefectCount = totalDefectCount
        frm_WS_Magazine_Kitting.workingCount = TB_TotalQty.Text
        frm_WS_Magazine_Kitting.TB_TotalQty.Text = TB_TotalQty.Text
        frm_WS_Magazine_Kitting.TB_ItemCode.Text = TB_ItemCode.Text
        frm_WS_Magazine_Kitting.TB_ItemName.Text = TB_ItemName.Text
        frm_WS_Magazine_Kitting.TB_PONo.Text = TB_OrderIndex.Text
        frm_WS_Magazine_Kitting.TB_SMDLine.Text = CB_Line.Text
        frm_WS_Magazine_Kitting.LB_HistoryIndex.Text = historyIndex
        frm_WS_Magazine_Kitting.LB_ModelCode.Text = TB_ModelCode.Text
        frm_WS_Magazine_Kitting.LB_CustomerCode.Text = TB_CustomerCode.Text
        If Not frm_WS_Magazine_Kitting.Visible Then frm_WS_Magazine_Kitting.Show()
        frm_WS_Magazine_Kitting.Focus()

    End Sub

    Private Sub BTN_RepairCheck_Click(sender As Object, e As EventArgs) Handles BTN_RepairCheck.Click

        If TB_OrderIndex.Text = String.Empty Then
            MessageBox.Show("생산중인 모델이 없습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Exit Sub
        End If

        If TB_Inspector.Text = String.Empty Then
            MessageBox.Show("검사자를 입력하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            TB_Inspector.Focus()
            Exit Sub
        End If

        frm_WS_Reinspection.LB_OrderIndex.Text = TB_OrderIndex.Text
        frm_WS_Reinspection.TB_Inspector.Text = TB_Inspector.Text
        If Not frm_WS_Reinspection.Visible Then frm_WS_Reinspection.Show()
        frm_WS_Reinspection.Focus()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frm_asdadsads.Show()
    End Sub
End Class