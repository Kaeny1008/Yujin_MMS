Imports System.IO
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
            rngM = .GetCellRange(0, 3, 1, 3)
            rngM.Data = "Inspector"
            rngM = .GetCellRange(0, 4, 1, 7)
            rngM.Data = "수량"
            rngM = .GetCellRange(0, 8, 1, 8)
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
            .Cols(4).DataType = GetType(Double)
            .Cols(4).Format = "#,##0"
            .Cols(5).DataType = GetType(Double)
            .Cols(5).Format = "#,##0"
            .Cols(6).DataType = GetType(Double)
            .Cols(6).Format = "#,##0"
            .Cols(7).DataType = GetType(Double)
            .Cols(7).Format = "#,##0"
        End With

        Grid_History(1, 1) = "시작"
        Grid_History(1, 2) = "종료"
        Grid_History(1, 4) = "시작"
        Grid_History(1, 5) = "불량"
        Grid_History(1, 6) = "종료"
        Grid_History(1, 7) = "폐기"
        Grid_History.AutoSizeCols()

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
        TB_OrderQty.Text = String.Empty
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
            TB_OrderQty.Text = Grid_OrderList(findRow, 7)
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
        TB_OrderQty.Text = String.Empty

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
                sqlDR("discard_quantity") & vbTab &
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

        If workingCompletedQty = CDbl(TB_OrderQty.Text) Then
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
            TB_OrderQty.Text = Grid_OrderList(selRow, 7)
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
        frm_WS_Magazine_Kitting.workingCount = TB_OrderQty.Text
        frm_WS_Magazine_Kitting.TB_TotalQty.Text = TB_OrderQty.Text
        frm_WS_Magazine_Kitting.TB_ItemCode.Text = TB_ItemCode.Text
        frm_WS_Magazine_Kitting.TB_ItemName.Text = TB_ItemName.Text
        frm_WS_Magazine_Kitting.TB_PONo.Text = TB_OrderIndex.Text
        frm_WS_Magazine_Kitting.TB_SMDLine.Text = CB_Line.Text
        frm_WS_Magazine_Kitting.LB_HistoryIndex.Text = historyIndex
        frm_WS_Magazine_Kitting.LB_ModelCode.Text = TB_ModelCode.Text
        frm_WS_Magazine_Kitting.LB_CustomerCode.Text = TB_CustomerCode.Text
        frm_WS_Magazine_Kitting.orderIndex = TB_OrderIndex.Text
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
        frm_PDF_Viewer.Show()
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

        'If File.Exists(Application.StartupPath & "\print.txt") Then File.Delete(Application.StartupPath & "\print.txt")

        If Directory.Exists(Application.StartupPath & "\Print Text") = False Then
            Directory.CreateDirectory(Application.StartupPath & "\Print Text")
        End If

        Dim folderName As String = Application.StartupPath & "\Print Text"
        Dim fileName As String = folderName & "\WS Label Print_" & Format(Now, "yyMMddHHmmssfff") & ".txt"

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

        swFile.WriteLine("^FO0170,0008^A1N,60,40^FD" & CB_Line.Text & " 현품표^FS")
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

        swFile.WriteLine("^FO0016,0246^A0,30,20^FDLine^FS")
        swFile.WriteLine("^FO0170,0246^A0,30,20^FD" & CB_Line.Text & "^FS")
        'swFile.WriteLine("^FO0360,0246^A0,30,20^FDTop / Bottom^FS")
        'swFile.WriteLine("^FO0518,0246^A0,30,20^FD" & TB_TB.Text & "^FS")
        swFile.WriteLine("^FO0016,0284^A0,30,20^FDDate^FS")
        swFile.WriteLine("^FO0170,0284^A0,30,18^FD" & writeDate & "^FS")
        swFile.WriteLine("^FO0016,0324^A0,30,20^FDProcess^FS")
        swFile.WriteLine("^FO0170,0324^A1N,30,20^FD" & Load_Process() & "^FS")

        swFile.WriteLine("^FO020,0020^BXN,3,200,44,44^FD" & TB_OrderIndex.Text & "!" & historyNo & "!" & CB_Line.Text & "^FS")

        swFile.WriteLine("^PQ" & 1 & "^FS") 'PQ : 발행수량
        swFile.WriteLine("^XZ")
        swFile.Close()

        Dim printResult As String = LabelPrint(fileName)

        If Not printResult = "Success" Then
            MessageBox.Show(frm_Main,
                            "라벨 발행에 실패 하였습니다." & vbCrLf &
                            printResult,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End If

    End Sub

    Private Function Load_Process() As String

        DBConnect()

        Dim returnString As String = String.Empty

        Dim strSQL As String = "call sp_mms_wave_selective_production(8"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_ModelCode.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
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
            .TB_OrderQty.Text = TB_OrderQty.Text
            .TB_ModelCode.Text = TB_ModelCode.Text
            .TB_Process.Text = CB_Line.Text
            .TB_HistoryNo.Text = historyIndex

            If .ShowDialog() = DialogResult.OK Then
                Load_InspectList()
            End If
        End With

    End Sub
End Class