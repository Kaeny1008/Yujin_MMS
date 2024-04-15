Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Wave_Selective_Production_Inspection

    Dim historyIndex As String

    Private Sub frm_Wave_Selective_Production_Inspection_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GridSetting()

        Load_ComboBox_Data()

        TB_Barcode.SelectAll()
        TB_Barcode.Focus()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub Load_ComboBox_Data()

        CB_Process.Text = registryEdit.ReadRegKey("Software\Yujin\MMS\WS Production", "Process", String.Empty)
        CB_Department.Text = registryEdit.ReadRegKey("Software\Yujin\MMS\WS Production", "Department", String.Empty)
        CB_Line.Text = registryEdit.ReadRegKey("Software\Yujin\MMS\WS Production", "Line", String.Empty)

    End Sub

    Private Sub GridSetting()

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

    End Sub

    Private Sub TB_Inspector_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_Inspector.KeyDown

        If Not Trim(TB_Inspector.Text) = String.Empty And e.KeyCode = 13 Then
            TB_Barcode.SelectAll()
            TB_Barcode.Focus()
        End If

    End Sub

    Private Sub TB_Barcode_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_Barcode.KeyDown

        If Not Trim(TB_Barcode.Text) = String.Empty And e.KeyCode = 13 Then
            If CB_Process.Text = String.Empty Then
                MessageBox.Show("공정이 선택되지 않았습니다.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If CB_Department.Text = String.Empty Then
                MessageBox.Show("작업동이 선택되지 않았습니다.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If CB_Line.Text = String.Empty Then
                MessageBox.Show("라인이 선택되지 않았습니다.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Trim(TB_Inspector.Text) = String.Empty Then
                MessageBox.Show("작업자가 입력되지 않았습니다.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
                TB_Inspector.SelectAll()
                TB_Inspector.Focus()
                Exit Sub
            End If

            Thread_LoadingFormStart()

            Control_Initialize()

            Try
                Dim splitBarcode() As String = TB_Barcode.Text.Split("!")
                Dim orderIndex As String = splitBarcode(0)
                Dim historyIndex As String = splitBarcode(1)

                TB_OrderIndex.Text = orderIndex
                TB_SMD_HistoryNo.Text = historyIndex

                Load_OrderInformation(orderIndex, historyIndex)
            Catch ex As Exception
                Thread_LoadingFormEnd()
                MessageBox.Show("Barcode를 인식 할 수 없습니다.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                TB_Barcode.SelectAll()
                TB_Barcode.Focus()
                Exit Sub
            End Try

            If TB_CustomerCode.Text = String.Empty Then
                Thread_LoadingFormEnd()
                MessageBox.Show("해당 주문을 확인 할 수 없습니다.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TB_Barcode.Text = String.Empty
                TB_Barcode.Focus()
                Exit Sub
            End If

            If Load_Process() = 0 Then
                Thread_LoadingFormEnd()
                MessageBox.Show("선택된 공정이 모델정보에 등록되어 있지 않습니다.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Control_Initialize()
                TB_Barcode.Text = String.Empty
                TB_Barcode.Focus()
                Exit Sub
            End If

            Thread_LoadingFormEnd()

            historyIndex = FirstWokringCheck()

            If historyIndex = String.Empty Then
                MessageBox.Show("투입 등록이 되지 않은 주문입니다." & vbCrLf & "투입 절차를 먼저 시작하여 주십시오.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                Control_Initialize()
            Else
                Load_InspectList()
            End If

            TB_Barcode.Text = String.Empty
            TB_Barcode.Focus()
        End If

    End Sub

    Public Sub Load_InspectList()

        Grid_History.Redraw = False
        Grid_History.Rows.Count = 2

        DBConnect()

        Dim strSQL As String = "call sp_mms_wave_selective_production(6"
        strSQL += ", '" & TB_OrderIndex.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

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
        Loop
        sqlDR.Close()

        DBClose()

        Grid_History.AutoSizeCols()
        Grid_History.AutoSizeRows(2, 0, Grid_History.Rows.Count - 1, Grid_History.Cols.Count - 1, 0, AutoSizeFlags.None)
        Grid_History.Redraw = True

    End Sub

    Private Sub Control_Initialize()

        TB_OrderIndex.Text = String.Empty
        TB_SMD_HistoryNo.Text = String.Empty
        TB_CustomerCode.Text = String.Empty
        TB_CustomerName.Text = String.Empty
        TB_ModelCode.Text = String.Empty
        TB_ItemCode.Text = String.Empty
        TB_ItemName.Text = String.Empty
        TB_TotalQty.Text = String.Empty

    End Sub

    Private Sub Load_OrderInformation(ByVal orderIndex As String, ByVal historyIndex As Integer)

        DBConnect()

        Dim strSQL As String = "call sp_mms_wave_selective_production(0"
        strSQL += ", '" & orderIndex & "'"
        strSQL += ", '" & historyIndex & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            'PO202404030001-0001!42
            TB_CustomerCode.Text = sqlDR("customer_code")
            TB_CustomerName.Text = sqlDR("customer_name")
            TB_ModelCode.Text = sqlDR("model_code")
            TB_ItemCode.Text = sqlDR("item_code")
            TB_ItemName.Text = sqlDR("item_name")
            TB_TotalQty.Text = Format(sqlDR("modify_order_quantity"), "#,##0")
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Function Load_Process() As Integer

        DBConnect()

        Dim strSQL As String = "call sp_mms_wave_selective_production(1"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_ModelCode.Text & "'"
        strSQL += ", '" & CB_Line.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader
        Dim processCheck As Integer = 0

        Do While sqlDR.Read
            processCheck = sqlDR("exist_process")
        Loop
        sqlDR.Close()

        DBClose()

        Return processCheck

    End Function

    Private Function FirstWokringCheck() As String

        DBConnect()

        Dim strSQL As String = "call sp_mms_wave_selective_production(5"
        strSQL += ", '" & TB_OrderIndex.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader
        Dim orderCheck As String = String.Empty

        Do While sqlDR.Read
            orderCheck = sqlDR("history_index")
        Loop
        sqlDR.Close()

        DBClose()

        Return orderCheck

    End Function

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
            Exit Sub
        End If

        Dim totalDefectCount As Integer = 0

        For i = 2 To Grid_History.Rows.Count - 1
            totalDefectCount += Grid_History(i, 6)
        Next

        frm_WS_Magazine_Kitting.lastWorkingCount = Grid_History(Grid_History.Rows.Count - 1, 5)
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
End Class