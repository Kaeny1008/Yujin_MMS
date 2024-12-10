Imports System.IO
Imports C1.Win.C1FlexGrid
Imports MySqlConnector

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
            .Cols.Count = 11
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
            rngM = .GetCellRange(0, 1, 1, 1)
            rngM.Data = "History No."
            rngM = .GetCellRange(0, 2, 1, 3)
            rngM.Data = "생산일자"
            Grid_History(1, 2) = "시작"
            Grid_History(1, 3) = "종료"
            rngM = .GetCellRange(0, 4, 1, 4)
            rngM.Data = "Operator"
            rngM = .GetCellRange(0, 5, 1, 5)
            rngM.Data = "Inspector"
            rngM = .GetCellRange(0, 6, 1, 9)
            rngM.Data = "수량"
            rngM = .GetCellRange(0, 10, 1, 10)
            rngM.Data = "비고"
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            .ExtendLastCol = True
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .SelectionMode = SelectionModeEnum.Default
            .Cols(6).DataType = GetType(Double)
            .Cols(6).Format = "#,##0"
            .Cols(7).DataType = GetType(Double)
            .Cols(7).Format = "#,##0"
            .Cols(8).DataType = GetType(Double)
            .Cols(8).Format = "#,##0"
            .Cols(9).DataType = GetType(Double)
            .Cols(9).Format = "#,##0"
        End With

        Grid_History(1, 6) = "시작"
        Grid_History(1, 7) = "불량"
        Grid_History(1, 8) = "종료"
        Grid_History(1, 9) = "폐기"
        Grid_History.AutoSizeCols()

        With Grid_OrderList
            .AllowEditing = False
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 11
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = True
            .ShowCursor = True
            .Cols(3).Visible = False
            .Cols(5).Visible = False
            .Cols(10).Visible = False
        End With

        Grid_OrderList(0, 0) = "No"
        Grid_OrderList(0, 1) = "history_index"
        Grid_OrderList(0, 2) = "주문번호"
        Grid_OrderList(0, 3) = "고객사 코드"
        Grid_OrderList(0, 4) = "고객사"
        Grid_OrderList(0, 5) = "모델코드"
        Grid_OrderList(0, 6) = "품번"
        Grid_OrderList(0, 7) = "품명"
        Grid_OrderList(0, 8) = "작업면"
        Grid_OrderList(0, 9) = "작업수량"
        Grid_OrderList(0, 10) = "Operator"

        Grid_OrderList.AutoSizeCols()

    End Sub

    Private Sub CB_Department_DropDown(sender As Object, e As EventArgs) Handles CB_Department.DropDown

        CB_Department.Items.Clear()

        If DBConnect() = False Then Exit Sub

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

        If DBConnect() = False Then Exit Sub

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

        If DBConnect() = False Then Exit Sub

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

    Private Sub BTN_Reload_Click(sender As Object, e As EventArgs) Handles BTN_Reload.Click

        CB_Line_SelectionChangeCommitted(Nothing, Nothing)

    End Sub

    Private Sub CB_Line_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Line.SelectedIndexChanged

    End Sub

    Public Sub CB_Line_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_Line.SelectionChangeCommitted

        Thread_LoadingFormStart(Me)

        TB_OrderIndex.Text = String.Empty
        TB_CustomerCode.Text = String.Empty
        TB_CustomerName.Text = String.Empty
        TB_ModelCode.Text = String.Empty
        TB_ItemCode.Text = String.Empty
        TB_ItemName.Text = String.Empty
        TB_Workside.Text = String.Empty
        TB_OrderQty.Text = String.Empty
        TB_Operator.Text = String.Empty
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

        'MSG_Information(Me, "해당 주문을 더블클릭으로 선택하여 주십시오.")

        '왠지 Application.DoEvents() 이거때문에 멈추는거 같다.
        MessageBox.Show("해당 주문을 더블클릭으로 선택하여 주십시오.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

    End Sub

    Private Sub Load_OrderInformation()

        Grid_OrderList.Redraw = False
        Grid_OrderList.Rows.Count = 1

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_smd_production_end(0"
        strSQL += ", '" & CB_Department.Text & "'"
        strSQL += ", '" & CB_Line.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = Grid_OrderList.Rows.Count & vbTab &
                sqlDR("history_index") & vbTab &
                sqlDR("order_index") & vbTab &
                sqlDR("customer_code") & vbTab &
                sqlDR("customer_name") & vbTab &
                sqlDR("model_code") & vbTab &
                sqlDR("item_code") & vbTab &
                sqlDR("item_name") & vbTab &
                sqlDR("work_side") & vbTab &
                Format(sqlDR("modify_order_quantity"), "#,##0") & vbTab &
                sqlDR("smd_operater")
            GridWriteText(insertString, Me, Grid_OrderList, Color.Black)
            GridColsAutoSize(Me, Grid_OrderList)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_OrderList.AutoSizeCols()
        Grid_OrderList.Redraw = True

        If Grid_OrderList.Rows.Count > 1 Then
            'Dim findRow As Integer = 1
            'If Not historyIndex = 0 Then
            '    findRow = Grid_OrderList.FindRow(CStr(historyIndex), 1, 10, False)
            '    If findRow = -1 Then
            '        findRow = 1
            '    End If
            'End If
            'TB_OrderIndex.Text = Grid_OrderList(findRow, 1)
            'TB_CustomerCode.Text = Grid_OrderList(findRow, 2)
            'TB_CustomerName.Text = Grid_OrderList(findRow, 3)
            'TB_ModelCode.Text = Grid_OrderList(findRow, 4)
            'TB_ItemCode.Text = Grid_OrderList(findRow, 5)
            'TB_ItemName.Text = Grid_OrderList(findRow, 6)
            'TB_Workside.Text = Grid_OrderList(findRow, 7)
            'TB_OrderQty.Text = Grid_OrderList(findRow, 8)
            'TB_Operator.Text = Grid_OrderList(findRow, 9)
            'historyIndex = Grid_OrderList(findRow, 10)
            'Load_InspectList()
        End If

    End Sub

    Private Sub Grid_OrderList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Grid_OrderList.MouseDoubleClick

        Dim selRow As Integer = Grid_OrderList.MouseRow
        If e.Button = MouseButtons.Left And selRow > 0 Then
            TB_OrderIndex.Text = Grid_OrderList(selRow, 2)
            TB_CustomerCode.Text = Grid_OrderList(selRow, 3)
            TB_CustomerName.Text = Grid_OrderList(selRow, 4)
            TB_ModelCode.Text = Grid_OrderList(selRow, 5)
            TB_ItemCode.Text = Grid_OrderList(selRow, 6)
            TB_ItemName.Text = Grid_OrderList(selRow, 7)
            TB_Workside.Text = Grid_OrderList(selRow, 8)
            TB_OrderQty.Text = Grid_OrderList(selRow, 9)
            TB_Operator.Text = Grid_OrderList(selRow, 10)
            'historyIndex = Grid_OrderList(selRow, 10)
            'historyIndex = Lastest_HistoryIndex()
            Load_InspectList()
            MSG_Information(Me, "주문을 변경하였습니다.")
        End If

    End Sub

    Private Function Lastest_HistoryIndex() As String

        Dim returnString As String = String.Empty

        If DBConnect() = False Then
            Return returnString
            Exit Function
        End If

        Dim strSQL As String = "call sp_mms_smd_production_end(9"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_OrderIndex.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            returnString = sqlDR("history_index")
        Loop
        sqlDR.Close()

        DBClose()

        Return returnString

    End Function

    Public Sub Load_InspectList()

        Grid_History.Redraw = False
        Grid_History.Rows.Count = 2

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_smd_production_end(3"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_OrderIndex.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_Workside.Text & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim endDate As String = sqlDR("smd_end_date")
            If Not endDate = String.Empty Then
                endDate = Format(CDate(sqlDR("smd_end_date")), "yyyy-MM-dd HH:mm:ss")
            End If
            Dim insertString As String = Grid_History.Rows.Count - 1 & vbTab &
                sqlDR("history_index") & vbTab &
                Format(sqlDR("smd_start_date"), "yyyy-MM-dd HH:mm:ss") & vbTab &
                endDate & vbTab &
                sqlDR("smd_operater") & vbTab &
                sqlDR("smd_inspecter") & vbTab &
                sqlDR("start_quantity") & vbTab &
                sqlDR("fault_quantity") & vbTab &
                sqlDR("end_quantity") & vbTab &
                sqlDR("discard_quantity") & vbTab &
                sqlDR("history_note")

            GridWriteText(insertString, Me, Grid_History, Color.Black)
            TB_Inspector.Text = sqlDR("smd_inspecter")
        Loop
        sqlDR.Close()

        DBClose()

        Grid_History.AutoSizeCols()
        Grid_History.AutoSizeRows(2, 0, Grid_History.Rows.Count - 1, Grid_History.Cols.Count - 1, 0, AutoSizeFlags.None)
        Grid_History.Redraw = True

        If Grid_History.Rows.Count > 2 Then
            historyIndex = Grid_History(Grid_History.Rows.Count - 1, 1)
        End If

        'MSG_Information(Me, historyIndex)

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
            Exit Sub
        End If

        frm_SMD_Fault_Register.LB_OrderIndex.Text = TB_OrderIndex.Text
        frm_SMD_Fault_Register.LB_HistoryIndex.Text = historyIndex
        frm_SMD_Fault_Register.LB_ItemCode.Text = TB_ItemCode.Text
        frm_SMD_Fault_Register.LB_ItemName.Text = TB_ItemName.Text
        frm_SMD_Fault_Register.LB_SMDLine.Text = CB_Line.Text
        frm_SMD_Fault_Register.LB_WorkSide.Text = TB_Workside.Text
        If Not frm_SMD_Fault_Register.Visible Then frm_SMD_Fault_Register.Show()
        frm_SMD_Fault_Register.Focus()

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
            Exit Sub
        End If

        Dim totalDefectCount As Integer = 0

        For i = 2 To Grid_History.Rows.Count - 1
            totalDefectCount += Grid_History(i, 7)
        Next

        frm_SMD_Magazine_Kitting.lastWorkingCount = Grid_History(Grid_History.Rows.Count - 1, 6)
        frm_SMD_Magazine_Kitting.totalDefectCount = totalDefectCount
        frm_SMD_Magazine_Kitting.workingCount = TB_OrderQty.Text
        frm_SMD_Magazine_Kitting.TB_TotalQty.Text = TB_OrderQty.Text
        frm_SMD_Magazine_Kitting.TB_ItemCode.Text = TB_ItemCode.Text
        frm_SMD_Magazine_Kitting.TB_ItemName.Text = TB_ItemName.Text
        frm_SMD_Magazine_Kitting.TB_PONo.Text = TB_OrderIndex.Text
        frm_SMD_Magazine_Kitting.TB_SMDLine.Text = CB_Line.Text
        frm_SMD_Magazine_Kitting.TB_TB.Text = TB_Workside.Text
        frm_SMD_Magazine_Kitting.LB_HistoryIndex.Text = historyIndex
        frm_SMD_Magazine_Kitting.LB_ModelCode.Text = TB_ModelCode.Text
        frm_SMD_Magazine_Kitting.LB_CustomerCode.Text = TB_CustomerCode.Text
        frm_SMD_Magazine_Kitting.orderIndex = TB_OrderIndex.Text
        If Not frm_SMD_Magazine_Kitting.Visible Then frm_SMD_Magazine_Kitting.Show()
        frm_SMD_Magazine_Kitting.Focus()

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
            Exit Sub
        End If

        frm_SMD_Reinspection.LB_OrderIndex.Text = TB_OrderIndex.Text
        frm_SMD_Reinspection.TB_Inspector.Text = TB_Inspector.Text
        frm_SMD_Reinspection.LB_WorkSide.Text = TB_Workside.Text
        If Not frm_SMD_Reinspection.Visible Then frm_SMD_Reinspection.Show()
        frm_SMD_Reinspection.Focus()

    End Sub

    Private Sub Grid_History_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_History.MouseClick

        Dim selRow As Integer = Grid_History.MouseRow

        If e.Button = MouseButtons.Right And selRow > 0 Then
            Grid_History.Row = selRow
            Grid_Menu.Show(Grid_History, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub BTN_Reprint_Click(sender As Object, e As EventArgs) Handles BTN_Reprint.Click

        If MessageBox.Show(Me, "현품표를 재발행 하시겠습니까?", msg_form, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Dim selRow As Integer = Grid_History.Row

        Dim nowWriteDate As String = Grid_History(selRow, 1)
        Dim nowHistoryNo As String = Grid_History(selRow, 9)
        Dim nowProductionQty As String = Grid_History(selRow, 7)
        Dim nowTotalQty As String = CDbl(Grid_History(selRow, 5)) + CDbl(Grid_History(selRow, 7))

        PrintLabel(nowWriteDate, nowHistoryNo, nowProductionQty, nowTotalQty)

    End Sub

    Private Sub PrintLabel(ByVal writeDate As String,
                           ByVal historyNo As String,
                           ByVal productionQty As String,
                           ByVal totalQty As String
                           )

        Dim readyTop As Boolean = False

        If Load_TopBottom() = "Bottom / Top" Then
            If TB_Workside.Text = "Bottom" Then
                readyTop = True
            End If
        End If

        'If File.Exists(Application.StartupPath & "\print.txt") Then File.Delete(Application.StartupPath & "\print.txt")

        If Directory.Exists(Application.StartupPath & "\Print Text") = False Then
            Directory.CreateDirectory(Application.StartupPath & "\Print Text")
        End If

        Dim folderName As String = Application.StartupPath & "\Print Text"
        Dim fileName As String = folderName & "\SMD Label Print_" & Format(Now, "yyMMddHHmmssfff") & ".txt"

        Dim swFile As StreamWriter =
            New StreamWriter(fileName, True, System.Text.Encoding.GetEncoding(949))

        swFile.WriteLine("^XZ~JA^XZ")
        swFile.WriteLine("^XA^LH" & printerLeftPosition & ",0^LT" & printerTopPosition) 'LH : 가로위치, LT : 세로위치
        swFile.WriteLine("^MD" & printerMD) '진하기
        swFile.WriteLine("^SEE:UHANGUL.DAT^FS")
        swFile.WriteLine("^CW1,E:KFONT3.FNT^CI26^FS")

        swFile.WriteLine("^FO0008,0162^GB0694,0302,2,B,1^FS")

        swFile.WriteLine("^FO0008,0200^GB0694,0000,2,B,0^FS")
        swFile.WriteLine("^FO0008,0238^GB0694,0000,2,B,0^FS")
        swFile.WriteLine("^FO0008,0276^GB0694,0000,2,B,0^FS")
        swFile.WriteLine("^FO0008,0314^GB0694,0000,2,B,0^FS")

        swFile.WriteLine("^FO0162,0162^GB0000,0302,2,B,0^FS")
        swFile.WriteLine("^FO0352,0200^GB0000,0116,2,B,0^FS")
        swFile.WriteLine("^FO0510,0200^GB0000,0116,2,B,0^FS")

        swFile.WriteLine("^FO0300,0008^A1N,70,50^FDSMD현품표^FS")
        swFile.WriteLine("^FO0172,0080^A0,40,20^FDItemCode : ^FS")
        swFile.WriteLine("^FO0264,0080^A0,40,20^FD" & TB_ItemCode.Text & "^FS")
        swFile.WriteLine("^FO0172,0120^A0,40,20^FDItemName : ^FS")
        swFile.WriteLine("^FO0272,0120^A0,40,20^FD" & TB_ItemName.Text & "^FS")

        swFile.WriteLine("^FO0016,0170^A0,30,20^FDPO No.^FS")
        swFile.WriteLine("^FO0170,0170^A0,30,20^FD" & TB_OrderIndex.Text & " ( " & historyNo & " )^FS")

        swFile.WriteLine("^FO0016,0208^A0,30,20^FDTotal Q'ty^FS")
        swFile.WriteLine("^FO0170,0208^A0,30,20^FD" & totalQty & " EA^FS")
        swFile.WriteLine("^FO0360,0208^A0,30,20^FDMagazine Q'ty^FS")
        swFile.WriteLine("^FO0518,0208^A0,30,20^FD" & productionQty & " EA^FS")

        swFile.WriteLine("^FO0016,0246^A0,30,20^FDSMD Line^FS")
        swFile.WriteLine("^FO0170,0246^A0,30,20^FD" & CB_Line.Text & "^FS")
        swFile.WriteLine("^FO0360,0246^A0,30,20^FDTop / Bottom^FS")
        swFile.WriteLine("^FO0518,0246^A0,30,20^FD" & TB_Workside.Text & "^FS")
        swFile.WriteLine("^FO0016,0284^A0,30,20^FDSMD Date^FS")
        swFile.WriteLine("^FO0170,0284^A0,30,18^FD" & writeDate & "^FS")
        If readyTop = True Then
            swFile.WriteLine("^FO0016,0324^A1N,30,20^FD비고^FS")
            swFile.WriteLine("^FO0170,0324^A1N,70,50^FDTop 작업대기품^FS")
        Else
            swFile.WriteLine("^FO0016,0324^A0,30,20^FDProcess^FS")
            swFile.WriteLine("^FO0170,0324^A1N,30,20^FD" & Load_Process() & "^FS")
        End If

        swFile.WriteLine("^FO020,0020^BXN,3,200,44,44^FD" & TB_OrderIndex.Text & "!" & historyNo & "!SMD^FS")

        swFile.WriteLine("^PQ" & 1 & "^FS") 'PQ : 발행수량
        swFile.WriteLine("^XZ")
        swFile.Close()

        Dim printResult As String = LabelPrint(fileName, 1)

        If Not printResult = "Success" Then
            MessageBox.Show(frm_Main,
                            "라벨 발행에 실패 하였습니다." & vbCrLf &
                            printResult,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End If

    End Sub

    Private Function Load_TopBottom()

        Dim returnString As String = String.Empty

        If DBConnect() = False Then
            Return returnString
            Exit Function
        End If

        Dim strSQL As String = "call sp_mms_smd_production_end(6"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_ModelCode.Text & "'"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim workSite As String = "Bottom / Top"

            If IsDBNull(sqlDR("Bottom")) And
                Not IsDBNull(sqlDR("Top")) Then
                workSite = "Top"
            ElseIf Not IsDBNull(sqlDR("Bottom")) And
                IsDBNull(sqlDR("Top")) Then
                workSite = "Bottom"
            End If

            returnString = workSite
        Loop
        sqlDR.Close()

        DBClose()

        Return returnString

    End Function

    Private Function Load_Process() As String

        Dim returnString As String = String.Empty

        If DBConnect() = False Then
            Return returnString
            Exit Function
        End If

        Dim strSQL As String = "call sp_mms_smd_production_end(5"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_ModelCode.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            If returnString = String.Empty Then
                returnString = sqlDR("process_name")
            Else
                returnString += ">" & sqlDR("process_name")
            End If
        Loop
        sqlDR.Close()

        DBClose()

        Return returnString

    End Function

    Private Sub BTN_Discard_Register_Click(sender As Object, e As EventArgs) Handles BTN_Discard_Register.Click

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
            Exit Sub
        End If

        With frm_Discard_Register
            .TB_CustomerCode.Text = TB_CustomerCode.Text
            .TB_CustomerName.Text = TB_CustomerName.Text
            .TB_Inspector.Text = TB_Inspector.Text
            .TB_ItemCode.Text = TB_ItemCode.Text
            .TB_ItemName.Text = TB_ItemName.Text
            .TB_OrderIndex.Text = TB_OrderIndex.Text
            .TB_Workside.Text = TB_Workside.Text
            .TB_OrderQty.Text = TB_OrderQty.Text
            .TB_ModelCode.Text = TB_ModelCode.Text
            .TB_Process.Text = "SMD"
            .TB_HistoryNo.Text = historyIndex

            If .ShowDialog() = DialogResult.OK Then
                Load_InspectList()
            End If
        End With

    End Sub

    Public Sub Control_Initialize()

        TB_OrderIndex.Text = String.Empty
        TB_Workside.Text = String.Empty
        TB_CustomerCode.Text = String.Empty
        TB_CustomerName.Text = String.Empty
        TB_OrderQty.Text = String.Empty
        TB_ModelCode.Text = String.Empty
        TB_ItemCode.Text = String.Empty
        TB_Operator.Text = String.Empty
        TB_ItemName.Text = String.Empty
        TB_Inspector.Text = String.Empty


        Grid_History.Rows.Count = 2

    End Sub
End Class