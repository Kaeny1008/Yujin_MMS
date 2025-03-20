Imports System.IO
Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Wave_Selective_Production_Start
    Private Sub frm_Wave_Selective_Production_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GridSetting()

        Load_ComboBox_Data()

        DTP_Start.Value = Format(Now, "yyyy-MM-dd 00:00:00")
        DTP_End.Value = Format(Now, "yyyy-MM-dd 23:59:59")

        TB_Barcode.SelectAll()
        TB_Barcode.Focus()

        Timer1.Interval = 1000
        Timer1.Start()

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
            .AllowMergingFixed = AllowMergingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 10
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .SelectionMode = SelectionModeEnum.Default
        End With

        Grid_History(0, 0) = "No"
        Grid_History(0, 1) = "History No."
        Grid_History(0, 2) = "Order No."
        Grid_History(0, 3) = "SMD History No."
        Grid_History(0, 4) = "고객사"
        Grid_History(0, 5) = "품번"
        Grid_History(0, 6) = "품명"
        Grid_History(0, 7) = "투입일자"
        Grid_History(0, 8) = "투입수량"
        Grid_History(0, 9) = "작업자"
        Grid_History.AutoSizeCols()

    End Sub

    Private Sub ComboBox_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_Department.SelectionChangeCommitted,
        CB_Line.SelectionChangeCommitted,
        CB_Process.SelectionChangeCommitted

        TB_Barcode.SelectAll()
        TB_Barcode.Focus()

        If sender.name = CB_Process.Name Then
            CB_Department.SelectedIndex = -1
            CB_Line.SelectedIndex = -1
        ElseIf sender.name = CB_Department.Name Then
            CB_Line.SelectedIndex = -1
        End If

        registryEdit.WriteRegKey("Software\Yujin\MMS\WS Production", "Process", CB_Process.Text)
        registryEdit.WriteRegKey("Software\Yujin\MMS\WS Production", "Department", CB_Department.Text)
        registryEdit.WriteRegKey("Software\Yujin\MMS\WS Production", "Line", CB_Line.Text)

    End Sub

    Private Sub CB_Line_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Line.SelectedIndexChanged

        'Load_WorkingList()

    End Sub

    Private Sub Load_WorkingList()

        If CB_Process.Text = String.Empty Or
            CB_Department.Text = String.Empty Or
            CB_Line.Text = String.Empty Then
            MessageBox.Show("공정, 동, 라인을 선택하여 주십시오.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Thread_LoadingFormStart(Me)

        Grid_History.Redraw = False
        Grid_History.Rows.Count = 1

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_wave_selective_production(4"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & CB_Line.Text & "'"
        strSQL += ", '" & Format(DTP_Start.Value, "yyyy-MM-dd 00:00:00") & "'"
        strSQL += ", '" & Format(DTP_End.Value, "yyyy-MM-dd 23:59:59") & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = Grid_History.Rows.Count & vbTab &
                sqlDR("history_index") & vbTab &
                sqlDR("order_index") & vbTab &
                sqlDR("smd_history_index") & vbTab &
                sqlDR("customer_name") & vbTab &
                sqlDR("item_code") & vbTab &
                sqlDR("item_name") & vbTab &
                Format(sqlDR("input_date"), "yyyy-MM-dd HH:mm:ss") & vbTab &
                Format(sqlDR("working_quantity"), "#,##0") & vbTab &
                sqlDR("worker")
            Grid_History.AddItem(insertString)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_History.AutoSizeCols()
        Grid_History.Redraw = True

        Thread_LoadingFormEnd()

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

            If Trim(TB_Worker.Text) = String.Empty Then
                MessageBox.Show("작업자가 입력되지 않았습니다.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
                TB_Worker.SelectAll()
                TB_Worker.Focus()
                Exit Sub
            End If

            Thread_LoadingFormStart(Me)

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
                MessageBox.Show("해당 주문을 확인 할 수 없습니다.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                TB_Barcode.Text = String.Empty
                TB_Barcode.Focus()
                Exit Sub
            End If

            If Load_Process() = 0 Then
                Thread_LoadingFormEnd()
                TB_Barcode.Text = String.Empty
                TB_Barcode.Focus()
                MessageBox.Show("선택된 공정이 모델정보에 등록되어 있지 않습니다.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                Control_Initialize()
                Exit Sub
            End If

            If Not SMDHistoryCheck() = 0 Then
                Thread_LoadingFormEnd()
                TB_Barcode.SelectAll()
                TB_Barcode.Focus()
                MessageBox.Show("이미 생산등록된 No.입니다." & vbCrLf & "확인하여 주십시오.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Thread_LoadingFormEnd()

            TB_Barcode.SelectAll()
            TB_Barcode.Focus()

            If MessageBox.Show("생산 시작(투입) 등록을 하시겠습니까?",
                               msg_form,
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            '최종 투입인지 확인
            '현재까지 투입수량 + 폐기수량 + 현재투입수량 = 주문수량
            Dim updateOK As Boolean = False
            If LastInputCheck() + Load_Discard_Quantity() + CDbl(TB_WorkingQty.Text) >= CDbl(TB_TotalQty.Text) Then
                If Material_Update_Exist_Check() = 0 Then updateOK = True
            End If
            Production_Start_Register(FirstWokringCheck(), updateOK)

            TB_Barcode.Text = String.Empty
            TB_Barcode.Focus()
        End If

    End Sub

    Private Function Material_Update_Exist_Check() As Integer

        Dim orderCheck As Integer = 0

        If DBConnect() = False Then
            Return orderCheck
            Exit Function
        End If

        Dim nowColumn As String = "selective_end"
        If CB_Line.Text = "Wave Soldering" Then
            nowColumn = "wave_end"
        End If

        Dim strSQL As String = "select " & nowColumn & " from tb_mms_material_use_update_check"
        strSQL += " where order_index = '" & TB_OrderIndex.Text & "'"
        strSQL += ";"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            orderCheck = sqlDR(nowColumn)
        Loop
        sqlDR.Close()

        DBClose()

        Return orderCheck

    End Function

    Private Function LastInputCheck() As Integer

        Dim orderCheck As Integer = 0

        If DBConnect() = False Then
            Return orderCheck
            Exit Function
        End If

        Dim strSQL As String = "call sp_mms_wave_selective_production(19"
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

        Do While sqlDR.Read
            orderCheck = sqlDR("completed_qty")
        Loop
        sqlDR.Close()

        DBClose()

        Return orderCheck

    End Function

    Private Function Load_Discard_Quantity() As Integer

        Dim orderCheck As Integer = 0

        If DBConnect() = False Then
            Return orderCheck
            Exit Function
        End If

        Dim strSQL As String = "call sp_mms_wave_selective_production(14"
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

        Do While sqlDR.Read
            orderCheck = sqlDR("discard_quantity")
        Loop
        sqlDR.Close()

        DBClose()

        Return orderCheck

    End Function

    Private Function SMDHistoryCheck() As Integer

        Dim orderCheck As Integer = 0

        If DBConnect() = False Then
            Return orderCheck
            Exit Function
        End If

        Dim strSQL As String = "call sp_mms_wave_selective_production(3"
        strSQL += ", '" & TB_OrderIndex.Text & "'"
        strSQL += ", '" & TB_SMD_HistoryNo.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            orderCheck = sqlDR("exist_history")
        Loop
        sqlDR.Close()

        DBClose()

        Return orderCheck

    End Function

    Private Function FirstWokringCheck() As Integer

        Dim orderCheck As Integer = 0

        If DBConnect() = False Then
            Return orderCheck
            Exit Function
        End If

        Dim strSQL As String = "call sp_mms_wave_selective_production(2"
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

        Do While sqlDR.Read
            orderCheck = sqlDR("exist_order")
        Loop
        sqlDR.Close()

        DBClose()

        Return orderCheck

    End Function

    Private Sub Production_Start_Register(ByVal firstWorking As Integer, ByVal materialUse_Update As Boolean)

        Thread_LoadingFormStart(Me, "Saving...")

        If DBConnect() = False Then Exit Sub

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
        Try
            'History에 등록
            strSQL = "insert into tb_mms_ws_input_history("
            strSQL += "history_index, order_index, smd_history_index"
            strSQL += ", process_name, input_date, working_quantity, worker"
            strSQL += ") values ("
            strSQL += "'WSI" & Format(Now, "yyMMddHHmmssfff") & "'"
            strSQL += ",'" & TB_OrderIndex.Text & "'"
            strSQL += ",'" & TB_SMD_HistoryNo.Text & "'"
            strSQL += ",'" & CB_Line.Text & "'"
            strSQL += ",'" & writeDate & "'"
            strSQL += ",'" & TB_WorkingQty.Text & "'"
            strSQL += ",'" & TB_Worker.Text & "'"
            strSQL += ");"
            If firstWorking = 0 Then
                '주문현황에 상태 Update
                strSQL += "update tb_mms_order_register_list"
                strSQL += " set order_status = 'Production in " & CB_Process.Text & "'"
                strSQL += " where order_index = '" & TB_OrderIndex.Text & "'"
                strSQL += ";"
                '생산현황에 상태 Update
                strSQL += "update tb_mms_production_plan"
                strSQL += " set " & CB_Process.Text.ToLower & "_start = '" & writeDate & "'"
                strSQL += " where order_index = '" & TB_OrderIndex.Text & "'"
                strSQL += ";"
                '검사시작 등록
                strSQL += "insert into tb_mms_ws_output_history("
                strSQL += "history_index, order_index, process_name, ws_start_date, working_status"
                strSQL += ") values("
                strSQL += "'WSO" & Format(Now, "yyMMddHHmmssfff") & "'"
                strSQL += ",'" & TB_OrderIndex.Text & "'"
                strSQL += ",'" & CB_Line.Text & "'"
                strSQL += ",'" & writeDate & "'"
                strSQL += ",'Running'"
                strSQL += ");"
                '자재사용내용 등록
                strSQL += "call sp_mms_material_start_update("
                strSQL += "'" & TB_OrderIndex.Text & "'"
                strSQL += ", '" & CB_Line.Text & "'"
                strSQL += ", null"
                strSQL += ", 0"
                strSQL += ");"
            End If

            If materialUse_Update = True Then
                '자재사용내용 등록
                strSQL += "call sp_mms_material_complete_update("
                strSQL += "'" & TB_OrderIndex.Text & "'"
                strSQL += ", '" & CB_Line.Text & "'"
                strSQL += ", null"
                strSQL += ", 0"
                strSQL += ");"

                '중복 등록 방지하기위해 디비기록
                Dim processTable As String = "selective_end"
                If CB_Line.Text = "Wave Soldering" Then
                    processTable = "wave_end"
                End If
                strSQL += "insert into tb_mms_material_use_update_check(order_index, " & processTable & ")"
                strSQL += " values("
                strSQL += "'" & TB_OrderIndex.Text & "'"
                strSQL += ", 1"
                strSQL += ") on DUPLICATE key"
                strSQL += " update " & processTable & " = ifnull(" & processTable & ", 0) + values(" & processTable & ")"
                strSQL += ";"
            End If

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
            MessageBox.Show(ex.Message,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

            Exit Sub
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        Load_WorkingList()

    End Sub

    Private Sub Load_OrderInformation(ByVal orderIndex As String, ByVal historyIndex As Integer)

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_wave_selective_production(0"
        strSQL += ", '" & orderIndex & "'"
        strSQL += ", '" & historyIndex & "'"
        strSQL += ", null"
        strSQL += ", null"
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
            TB_WorkingQty.Text = Format(sqlDR("end_quantity"), "#,##0")
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Function Load_Process() As Integer

        Dim processCheck As Integer = 0

        If DBConnect() = False Then
            Return processCheck
            Exit Function
        End If

        Dim strSQL As String = "call sp_mms_wave_selective_production(1"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_ModelCode.Text & "'"
        strSQL += ", '" & CB_Line.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            processCheck = sqlDR("exist_process")
        Loop
        sqlDR.Close()

        DBClose()

        Return processCheck

    End Function

    Private Sub Control_Initialize()

        TB_OrderIndex.Text = String.Empty
        TB_SMD_HistoryNo.Text = String.Empty
        TB_CustomerCode.Text = String.Empty
        TB_CustomerName.Text = String.Empty
        TB_ModelCode.Text = String.Empty
        TB_ItemCode.Text = String.Empty
        TB_ItemName.Text = String.Empty
        TB_TotalQty.Text = String.Empty
        TB_WorkingQty.Text = String.Empty

    End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Load_WorkingList()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Format(Now, "HH:mm:ss") = "00:00:00" Then
            DTP_Start.Value = Format(Now, "yyyy-MM-dd 00:00:00")
            DTP_End.Value = Format(Now, "yyyy-MM-dd 23:59:59")
            BTN_Search_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub TB_Worker_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_Worker.KeyDown

        If Not Trim(TB_Worker.Text) = String.Empty And e.KeyCode = 13 Then
            TB_Barcode.SelectAll()
            TB_Barcode.Focus()
        End If

    End Sub

    Private Sub CB_Process_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Process.SelectedIndexChanged

    End Sub

    Private Sub BTN_DocumentDownload_Click(sender As Object, e As EventArgs) Handles BTN_DocumentDownload.Click

        Thread_LoadingFormStart(Me)
        Load_Document()
        Application.DoEvents()
        Load_BOM()
        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_BOM()

        frm_Production_BOM.orderIndex = TB_OrderIndex.Text

        If Not frm_Production_BOM.Visible Then frm_Production_BOM.Show()
        frm_Production_BOM.Focus()

    End Sub

    Private Sub Load_Document()

        If DBConnect() = False Then Exit Sub

        Dim fineName As String = String.Empty

        Dim strSQL As String = "call sp_mms_wave_selective_production(15"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_ModelCode.Text & "'"
        strSQL += ", '" & CB_Line.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '투입'"
        strSQL += ", 1"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            fineName = sqlDR("file_name")
        Loop
        sqlDR.Close()

        DBClose()

        File_Download(fineName)

    End Sub

    Private Sub File_Download(ByVal fileName As String)

        Dim modelFolder As String = Application.StartupPath & "\Model Documents\" & TB_ModelCode.Text

        '모델폴더 생성(있으면 안만들어짐)
        Directory.CreateDirectory(modelFolder)

        If Not File.Exists(modelFolder & "\" & fileName) Then
            Dim downloadResult As String = ftpFileDownload(ftpUrl & "/Model_Documents/" & TB_CustomerCode.Text & "/" & TB_ModelCode.Text,
                                               modelFolder,
                                               fileName)

            If Not downloadResult.Equals("Completed") Then
                MSG_Exclamation(Me, "Download 실패" & vbCrLf & downloadResult)
                Exit Sub
            End If
        End If

        '화면 옮기기 나중에 활용
        'Dim scr() As Screen = Screen.AllScreens
        'If scr.Length > 1 Then
        '    Dim screen2 As Screen = If((scr(0).WorkingArea.Contains(Me.Location)), scr(1), scr(0))
        '    Me.Location = screen2.Bounds.Location
        'End If

        frm_Documents_Viewer.WB_PDF.Navigate(modelFolder & "\" & fileName)
        frm_Documents_Viewer.Show()

    End Sub
End Class