Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_SolderPaste_Use

    Private Sub frm_SolderPaste_Use_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GridSetting()

        CheckTimer.Interval = 1000
        CheckTimer.Start()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub GridSetting()

        With Grid_StatusList
            .AllowEditing = False
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.None
            .Cols.Count = 6
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
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

        Grid_StatusList(0, 0) = "No."
        Grid_StatusList(0, 1) = "제조사"
        Grid_StatusList(0, 2) = "제품명"
        Grid_StatusList(0, 3) = "재고"
        Grid_StatusList(0, 4) = "상온방치"
        Grid_StatusList(0, 5) = "사용"
        Grid_StatusList.AutoSizeCols()

        With Grid_StockList
            .AllowEditing = False
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.None
            .Cols.Count = 8
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
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

        Grid_StockList(0, 0) = "No."
        Grid_StockList(0, 1) = "입고일자"
        Grid_StockList(0, 2) = "사용순번"
        Grid_StockList(0, 3) = "제조사"
        Grid_StockList(0, 4) = "제품명"
        Grid_StockList(0, 5) = "중량(g)"
        Grid_StockList(0, 6) = "유효기간"
        Grid_StockList(0, 7) = "Lot No.(Serial)"
        Grid_StockList.AutoSizeCols()

        With Grid_AgingList
            .AllowEditing = False
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            .Cols.Count = 10
            .Cols.Fixed = 1
            .Rows.Count = 2
            .Rows.Fixed = 2
            For i = 0 To .Cols.Count - 1
                .Cols(i).AllowMerging = True
            Next
            For i = 0 To .Rows.Count - 1
                .Rows(i).AllowMerging = True
            Next
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .SelectionMode = SelectionModeEnum.Default
            Dim rngM As CellRange = .GetCellRange(0, 0, 1, 0)
            rngM.Data = "No"
            rngM = .GetCellRange(0, 1, 1, 1)
            rngM.Data = "제조사"
            rngM = .GetCellRange(0, 2, 1, 2)
            rngM.Data = "제품명"
            rngM = .GetCellRange(0, 3, 1, 3)
            rngM.Data = "중량(g)"
            rngM = .GetCellRange(0, 4, 1, 4)
            rngM.Data = "유효기간"
            rngM = .GetCellRange(0, 5, 1, 5)
            rngM.Data = "Lot No.(Serial)"
            rngM = .GetCellRange(0, 6, 1, 8)
            rngM.Data = "시간"
            Grid_AgingList(1, 6) = "기준(hr)"
            Grid_AgingList(1, 7) = "시작"
            Grid_AgingList(1, 8) = "종료"
            rngM = .GetCellRange(0, 9, 1, 9)
            rngM.Data = "작업자"
            .AutoSizeCols()
        End With

        With Grid_UseList
            .AllowEditing = False
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
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
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .SelectionMode = SelectionModeEnum.Default
            Dim rngM As CellRange = .GetCellRange(0, 0, 1, 0)
            rngM.Data = "No"
            rngM = .GetCellRange(0, 1, 1, 1)
            rngM.Data = "제조사"
            rngM = .GetCellRange(0, 2, 1, 2)
            rngM.Data = "제품명"
            rngM = .GetCellRange(0, 3, 1, 3)
            rngM.Data = "중량(g)"
            rngM = .GetCellRange(0, 4, 1, 4)
            rngM.Data = "유효기간"
            rngM = .GetCellRange(0, 5, 1, 5)
            rngM.Data = "Lot No.(Serial)"
            rngM = .GetCellRange(0, 6, 1, 10)
            rngM.Data = "사용정보"
            Grid_UseList(1, 6) = "동"
            Grid_UseList(1, 7) = "라인"
            Grid_UseList(1, 8) = "작업자"
            Grid_UseList(1, 9) = "사용한계시간"
            Grid_UseList(1, 10) = "교반시간(sec)"
            .AutoSizeCols()
        End With


    End Sub

    Private Sub BTN_SolderPaste_Standard_Click(sender As Object, e As EventArgs) Handles BTN_SolderPaste_Standard.Click

        If Not frm_SolderPaste_Standard.Visible Then frm_SolderPaste_Standard.Show()
        frm_SolderPaste_Standard.Focus()

    End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart(Me)

        Load_Status()
        Load_Standards()
        Load_Warehousing()
        Load_Aging()
        Load_Use()

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_Status()

        Grid_StatusList.Redraw = False
        Grid_StatusList.Rows.Count = 1

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_solder_paste_management(1"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim stockWeight As String = sqlDR("stock_weight")
            Dim agingWeight As String = sqlDR("aging_weight")
            Dim useWeight As String = sqlDR("use_weight")

            If stockWeight.Length < 4 Then
                stockWeight += " g"
            ElseIf stockWeight.Length >= 4 Then
                stockWeight = Format(CDbl(stockWeight) / 1000, "#,##0.00") & " Kg"
            End If

            If agingWeight.Length < 4 Then
                agingWeight += " g"
            ElseIf agingWeight.Length >= 4 Then
                agingWeight = Format(CDbl(agingWeight) / 1000, "#,##0.00") & " Kg"
            End If

            If useWeight.Length < 4 Then
                useWeight += " g"
            ElseIf useWeight.Length >= 4 Then
                useWeight = Format(CDbl(useWeight) / 1000, "#,##0.00") & " Kg"
            End If

            Dim insertString As String = Grid_StatusList.Rows.Count & vbTab &
                sqlDR("vendor") & vbTab &
                sqlDR("product") & vbTab &
                stockWeight & vbTab &
                agingWeight & vbTab &
                useWeight
            GridWriteText(insertString, Me, Grid_StatusList, Color.Black)
            GridColsAutoSize(Me, Grid_StatusList)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_StatusList.Redraw = True

    End Sub

    Private Sub Load_Standards()

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "select aging_min, limit_of_use_time, mixing_time"
        strSQL += " from tb_mms_solder_standards"
        strSQL += ";"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            LB_Aging_Min.Text = sqlDR("aging_min")
            LB_Limit_Of_Use_Time.Text = sqlDR("limit_of_use_time")
            LB_Mixing_Time.Text = sqlDR("mixing_time")
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub Load_Warehousing()

        Grid_StockList.Redraw = False
        Grid_StockList.Rows.Count = 1

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_solder_paste_management(0"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = Grid_StockList.Rows.Count & vbTab &
                Format(sqlDR("date_of_warehousing"), "yyyy-MM-dd HH:mm:ss") & vbTab &
                sqlDR("house_no") & vbTab &
                sqlDR("vendor") & vbTab &
                sqlDR("product") & vbTab &
                sqlDR("weight") & vbTab &
                Format(sqlDR("date_of_validity"), "yyyy-MM-dd") & vbTab &
                sqlDR("lot_no")
            GridWriteText(insertString, Me, Grid_StockList, Color.Black)
            GridColsAutoSize(Me, Grid_StockList)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_StockList.Redraw = True

    End Sub

    Private Sub Load_Aging()

        Grid_AgingList.Redraw = False
        Grid_AgingList.Rows.Count = 2

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_solder_paste_management(2"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = Grid_AgingList.Rows.Count - 1 & vbTab &
                sqlDR("vendor") & vbTab &
                sqlDR("product") & vbTab &
                sqlDR("weight") & vbTab &
                Format(sqlDR("date_of_validity"), "yyyy-MM-dd") & vbTab &
                sqlDR("lot_no") & vbTab &
                sqlDR("standard_time") & vbTab &
                Format(sqlDR("start_date"), "yyyy-MM-dd HH:mm:ss") & vbTab &
                Format(sqlDR("end_date"), "yyyy-MM-dd HH:mm:ss") & vbTab &
                sqlDR("worker")
            GridWriteText(insertString, Me, Grid_AgingList, Color.Black)
            GridColsAutoSize(Me, Grid_AgingList)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_AgingList.Redraw = True

    End Sub

    Private Sub Load_Use()

        Grid_UseList.Redraw = False
        Grid_UseList.Rows.Count = 2

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_solder_paste_management(4"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = Grid_UseList.Rows.Count - 1 & vbTab &
                sqlDR("vendor") & vbTab &
                sqlDR("product") & vbTab &
                sqlDR("weight") & vbTab &
                Format(sqlDR("date_of_validity"), "yyyy-MM-dd") & vbTab &
                sqlDR("lot_no") & vbTab &
                sqlDR("department") & vbTab &
                sqlDR("line") & vbTab &
                sqlDR("worker") & vbTab &
                Format(sqlDR("limit_of_use_time"), "yyyy-MM-dd HH:mm:ss") & vbTab &
                sqlDR("mixing_time")
            GridWriteText(insertString, Me, Grid_UseList, Color.Black)
            GridColsAutoSize(Me, Grid_UseList)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_UseList.Redraw = True

    End Sub

    Private Function Load_FastHouseNo(ByVal lotNo As String, ByVal status As String) As String

        Dim first_LotNo As String = String.Empty

        If DBConnect() = False Then
            Return first_LotNo
            Exit Function
        End If

        Dim strSQL As String = "call sp_mms_solder_paste_management(3"
        strSQL += ", '" & lotNo & "'"
        strSQL += ", '" & status & "'"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            first_LotNo = sqlDR("lot_no")
        Loop
        sqlDR.Close()

        DBClose()

        Return first_LotNo

    End Function

    Private Sub BTN_AgingStart_Click(sender As Object, e As EventArgs) Handles BTN_AgingStart.Click

        If Not Trim(TB_Aging_Worker.Text) = String.Empty And
            Not Trim(TB_Aging_LotNo.Text) = String.Empty Then

            If Grid_StatusList.Rows.Count = 1 Then
                BTN_Search_Click(Nothing, Nothing)
            End If

            Thread_LoadingFormStart(Me, "Saving...")

            Dim findRow As Integer = Grid_StockList.FindRow(TB_Aging_LotNo.Text, 1, 7, True)
            If findRow < 1 Then
                Thread_LoadingFormEnd()
                MSG_Information(Me, "재고목록중 해당 Lot No.를 찾을 수 없습니다.")
                TB_Aging_LotNo.SelectAll()
                TB_Aging_LotNo.Focus()
                Exit Sub
            End If

            Dim fastLotNo As String = Load_FastHouseNo(TB_Aging_LotNo.Text, "Warehousing")

            If Not fastLotNo = String.Empty Then
                Thread_LoadingFormEnd()
                MSG_Exclamation(Me,
                                "********* 선입선출 *********" & vbCrLf & vbCrLf &
                                "우선 입고된 Lot No.가 있습니다." & vbCrLf &
                                "Lot No. : " & fastLotNo & vbCrLf & vbCrLf &
                                "********* 선입선출 *********")
                TB_Aging_LotNo.SelectAll()
                TB_Aging_LotNo.Focus()
                Exit Sub
            End If

            If AgingStartWrite() = False Then
                Thread_LoadingFormEnd()
                TB_Aging_LotNo.SelectAll()
                TB_Aging_LotNo.Focus()
                Exit Sub
            End If

            Thread_LoadingFormEnd()

            MSG_Information(Me, "상온방치 시작등록 완료.")

            BTN_Search_Click(Nothing, Nothing)

            TB_Aging_Worker.Text = String.Empty
            TB_Aging_LotNo.Text = String.Empty
            TB_Aging_LotNo.Focus()
        ElseIf Trim(TB_Aging_Worker.Text) = String.Empty Then
            MSG_Information(Me, "작업자를 입력하여 주십시오.")
            TB_Aging_Worker.Focus()
        ElseIf Trim(TB_Aging_LotNo.Text) = String.Empty Then
            MSG_Information(Me, "Lot No.를 입력하여 주십시오.")
            TB_Aging_LotNo.Focus()
        End If

    End Sub

    Private Function AgingStartWrite() As Boolean

        If DBConnect() = False Then
            Return False
            Exit Function
        End If

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty
        Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

        sqlTran = dbConnection1.BeginTransaction

        Try
            strSQL = "update tb_mms_solder_warehouse set solder_status = 'Aging'"
            strSQL += "where lot_no = '" & TB_Aging_LotNo.Text & "'"
            strSQL += ";"

            strSQL += "insert into tb_mms_solder_aging_history("
            strSQL += "lot_no, standard_time, start_date, end_date, worker"
            strSQL += ") values ("
            strSQL += "'" & TB_Aging_LotNo.Text & "'"
            strSQL += ",'" & CInt(LB_Aging_Min.Text) & "'"
            strSQL += ",'" & writeDate & "'"
            strSQL += ",'" & Format(DateAdd(DateInterval.Hour, CInt(LB_Aging_Min.Text), CDate(writeDate)), "yyyy-MM-dd HH:mm:ss") & "'"
            strSQL += ",'" & TB_Aging_Worker.Text & "'"
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

            MSG_Error(Me, ex.Message)
            Return False
        End Try

        DBClose()

        Return True

    End Function

    Private Sub TB_Aging_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_Aging_LotNo.KeyDown,
        TB_Aging_Worker.KeyDown

        If Not Trim(TB_Aging_Worker.Text) = String.Empty And
            Not Trim(TB_Aging_LotNo.Text) = String.Empty And
            e.KeyCode = 13 Then

            BTN_AgingStart_Click(Nothing, Nothing)
        Else
            If sender.name = TB_Aging_LotNo.Name And e.KeyCode = 13 And Not Trim(TB_Aging_LotNo.Text) = String.Empty Then
                TB_Aging_Worker.SelectAll()
                TB_Aging_Worker.Focus()
            ElseIf sender.name = TB_Aging_Worker.Name And e.KeyCode = 13 And Not Trim(TB_Aging_Worker.Text) = String.Empty Then
                TB_Aging_LotNo.SelectAll()
                TB_Aging_LotNo.Focus()
            End If
        End If

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

        Dim selFactoryCode As String = String.Empty

        Dim strSQL As String = "select sub_code from tb_code_sub"
        strSQL += " where sub_code_name = '" & CB_Department.Text & "'"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            selFactoryCode = sqlDR("sub_code")
        Loop
        sqlDR.Close()

        CB_Line.Items.Clear()

        strSQL = "select last_code_name from tb_code_last"
        strSQL += " where sub_code = '" & selFactoryCode & "' order by last_code_name"


        sqlCmd = New MySqlCommand(strSQL, dbConnection1)
        sqlDR = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            CB_Line.Items.Add(sqlDR("last_code_name"))
        Loop
        sqlDR.Close()

        DBClose()

        CB_Line.SelectedIndex = -1

    End Sub

    Private Sub CB_Line_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_Line.SelectionChangeCommitted

        TB_Use_LotNo.SelectAll()
        TB_Use_LotNo.Focus()

    End Sub

    Private Sub TB_Use_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_Use_LotNo.KeyDown,
        TB_Use_Worker.KeyDown

        If Not Trim(TB_Use_Worker.Text) = String.Empty And
            Not Trim(TB_Use_LotNo.Text) = String.Empty And
            Not CB_Department.Text = String.Empty And
            Not CB_Line.Text = String.Empty And
            e.KeyCode = 13 Then

            BTN_UseStart_Click(Nothing, Nothing)
        Else
            If sender.name = TB_Use_LotNo.Name And e.KeyCode = 13 And Not Trim(TB_Use_LotNo.Text) = String.Empty Then
                TB_Use_Worker.SelectAll()
                TB_Use_Worker.Focus()
            ElseIf sender.name = TB_Use_Worker.Name And e.KeyCode = 13 And Not Trim(TB_Use_Worker.Text) = String.Empty Then
                TB_Use_LotNo.SelectAll()
                TB_Use_LotNo.Focus()
            End If
        End If

    End Sub

    Private Sub BTN_UseStart_Click(sender As Object, e As EventArgs) Handles BTN_UseStart.Click

        If Not Trim(TB_Use_Worker.Text) = String.Empty And
            Not Trim(TB_Use_LotNo.Text) = String.Empty And
            Not CB_Department.Text = String.Empty And
            Not CB_Line.Text = String.Empty Then

            If Grid_StatusList.Rows.Count = 1 Then
                BTN_Search_Click(Nothing, Nothing)
            End If

            MSG_Information(Me, "교반시간 : " & LB_Mixing_Time.Text & "초 입니다." & vbCrLf & "교반시간을 준수 하여 주십시오.")

            Thread_LoadingFormStart(Me, "Saving...")

            Dim findRow As Integer = Grid_AgingList.FindRow(TB_Use_LotNo.Text, 1, 5, True)
            If findRow < 1 Then
                Thread_LoadingFormEnd()
                MSG_Information(Me, "상온 방치 목록중 해당 Lot No.를 찾을 수 없습니다.")
                TB_Use_LotNo.SelectAll()
                TB_Use_LotNo.Focus()
                Exit Sub
            Else
                If CDate(Grid_AgingList(findRow, 8)) > Now Then
                    Thread_LoadingFormEnd()
                    MSG_Information(Me, "상온 방치 시간이 충족되지 않은 솔더 입니다.")
                    TB_Use_LotNo.SelectAll()
                    TB_Use_LotNo.Focus()
                    Exit Sub
                End If
            End If

            Dim fastLotNo As String = Load_FastHouseNo(TB_Use_LotNo.Text, "Aging")

            If Not fastLotNo = String.Empty Then
                Thread_LoadingFormEnd()
                MSG_Exclamation(Me,
                                "********* 선입선출 *********" & vbCrLf & vbCrLf &
                                "우선 입고된 Lot No.가 있습니다." & vbCrLf &
                                "Lot No. : " & fastLotNo & vbCrLf & vbCrLf &
                                "********* 선입선출 *********")
                TB_Use_LotNo.SelectAll()
                TB_Use_LotNo.Focus()
                Exit Sub
            End If

            If UseStartWrite() = False Then
                Thread_LoadingFormEnd()
                TB_Use_LotNo.SelectAll()
                TB_Use_LotNo.Focus()
                Exit Sub
            End If

            Thread_LoadingFormEnd()

            MSG_Information(Me, "사용등록 완료.")

            BTN_Search_Click(Nothing, Nothing)

            TB_Use_Worker.Text = String.Empty
            TB_Use_LotNo.Text = String.Empty
            TB_Use_LotNo.Focus()
        ElseIf Trim(CB_Department.Text) = String.Empty Then
            MSG_Information(Me, "작업 동을 선택하여 주십시오.")
        ElseIf Trim(CB_Line.Text) = String.Empty Then
            MSG_Information(Me, "작업 라인을 선택하여 주십시오.")
        ElseIf Trim(TB_Use_LotNo.Text) = String.Empty Then
            MSG_Information(Me, "Lot No.를 입력하여 주십시오.")
            TB_Use_LotNo.Focus()
        ElseIf Trim(TB_Use_Worker.Text) = String.Empty Then
            MSG_Information(Me, "작업자를 입력하여 주십시오.")
            TB_Use_Worker.Focus()
        End If

    End Sub

    Private Function UseStartWrite() As Boolean

        If DBConnect() = False Then
            Return False
            Exit Function
        End If

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty
        Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

        sqlTran = dbConnection1.BeginTransaction

        Try
            strSQL = "update tb_mms_solder_warehouse set solder_status = 'Use'"
            strSQL += "where lot_no = '" & TB_Use_LotNo.Text & "'"
            strSQL += ";"

            strSQL += "insert into tb_mms_solder_use_history("
            strSQL += "lot_no, department, line, worker, limit_of_use_time, mixing_time, work_date"
            strSQL += ") values ("
            strSQL += "'" & TB_Use_LotNo.Text & "'"
            strSQL += ",'" & CB_Department.Text & "'"
            strSQL += ",'" & CB_Line.Text & "'"
            strSQL += ",'" & TB_Use_Worker.Text & "'"
            strSQL += ",'" & Format(DateAdd(DateInterval.Hour, CInt(LB_Limit_Of_Use_Time.Text), CDate(writeDate)), "yyyy-MM-dd HH:mm:ss") & "'"
            strSQL += ",'" & LB_Mixing_Time.Text & "'"
            strSQL += ",'" & writeDate & "'"
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
            MSG_Error(Me, ex.Message)
            Return False
        End Try

        DBClose()

        Return True

    End Function

    Private Sub CheckTimer_Tick(sender As Object, e As EventArgs) Handles CheckTimer.Tick

        Dim nowTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

        Grid_AgingList.Redraw = False
        Grid_UseList.Redraw = False

        For i = 2 To Grid_AgingList.Rows.Count - 1
            If Format(CDate(Grid_AgingList(i, 8)), "yyyy-MM-dd HH:mm:ss") <= nowTime Then
                Grid_AgingList.Rows(i).StyleNew.BackColor = Color.LightBlue
            End If
        Next

        For i = 2 To Grid_UseList.Rows.Count - 1
            If Format(CDate(Grid_UseList(i, 9)), "yyyy-MM-dd HH:mm:ss") <= nowTime Then
                Grid_UseList.Rows(i).StyleNew.BackColor = Color.LightBlue
            End If
        Next

        Grid_AgingList.Redraw = True
        Grid_UseList.Redraw = True

    End Sub

    Private Sub BTN_Scrap_Click(sender As Object, e As EventArgs) Handles BTN_Scrap.Click

        If Not Trim(TB_Scrap_Worker.Text) = String.Empty And
            Not Trim(TB_Scrap_LotNo.Text) = String.Empty Then

            If Grid_StatusList.Rows.Count = 1 Then
                BTN_Search_Click(Nothing, Nothing)
            End If

            Thread_LoadingFormStart(Me, "Saving...")

            Dim findRow As Integer = Grid_UseList.FindRow(TB_Scrap_LotNo.Text, 1, 5, True)
            If findRow < 1 Then
                Thread_LoadingFormEnd()
                MSG_Information(Me, "사용목록중 해당 Lot No.를 찾을 수 없습니다.")
                TB_Scrap_LotNo.SelectAll()
                TB_Scrap_LotNo.Focus()
                Exit Sub
            End If

            If ScrapWrite() = False Then
                Thread_LoadingFormEnd()
                TB_Scrap_LotNo.SelectAll()
                TB_Scrap_LotNo.Focus()
                Exit Sub
            End If

            Thread_LoadingFormEnd()

            MSG_Information(Me, "폐기등록 완료.")

            BTN_Search_Click(Nothing, Nothing)

            TB_Scrap_Worker.Text = String.Empty
            TB_Scrap_LotNo.Text = String.Empty
            TB_Scrap_LotNo.Focus()
        ElseIf Trim(TB_scrap_LotNo.Text) = String.Empty Then
            MSG_Information(Me, "Lot No.를 입력하여 주십시오.")
            TB_Scrap_LotNo.Focus()
        ElseIf Trim(TB_scrap_Worker.Text) = String.Empty Then
            MSG_Information(Me, "작업자를 입력하여 주십시오.")
            TB_Scrap_Worker.Focus()
        End If

    End Sub

    Private Function ScrapWrite() As Boolean

        If DBConnect() = False Then
            Return False
            Exit Function
        End If

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty
        Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

        sqlTran = dbConnection1.BeginTransaction

        Try
            strSQL = "update tb_mms_solder_warehouse set solder_status = 'Close'"
            strSQL += "where lot_no = '" & TB_Scrap_LotNo.Text & "'"
            strSQL += ";"

            strSQL += "insert into tb_mms_solder_scrap_history("
            strSQL += "lot_no, worker, scrap_date"
            strSQL += ") values ("
            strSQL += "'" & TB_Scrap_LotNo.Text & "'"
            strSQL += ",'" & TB_Scrap_Worker.Text & "'"
            strSQL += ",'" & writeDate & "'"
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
            MSG_Error(Me, ex.Message)
            Return False
        End Try

        DBClose()

        Return True

    End Function

    Private Sub TB_Scrap_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_Scrap_LotNo.KeyDown,
        TB_Scrap_Worker.KeyDown

        If Not Trim(TB_Scrap_Worker.Text) = String.Empty And
            Not Trim(TB_Scrap_LotNo.Text) = String.Empty And
            e.KeyCode = 13 Then

            BTN_Scrap_Click(Nothing, Nothing)
        Else
            If sender.name = TB_Scrap_LotNo.Name And e.KeyCode = 13 And Not Trim(TB_Scrap_LotNo.Text) = String.Empty Then
                TB_Scrap_Worker.SelectAll()
                TB_Scrap_Worker.Focus()
            ElseIf sender.name = TB_scrap_Worker.Name And e.KeyCode = 13 And Not Trim(TB_scrap_Worker.Text) = String.Empty Then
                TB_Scrap_LotNo.SelectAll()
                TB_Scrap_LotNo.Focus()
            End If
        End If

    End Sub
End Class