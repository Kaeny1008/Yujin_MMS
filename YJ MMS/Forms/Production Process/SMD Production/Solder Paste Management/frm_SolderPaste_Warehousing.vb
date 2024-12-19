Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_SolderPaste_Warehousing
    Private Sub frm_SolderPaste_Warehousing_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GridSetting()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub GridSetting()

        With Grid_SolderList
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

        Grid_SolderList(0, 0) = "No."
        Grid_SolderList(0, 1) = "제조사"
        Grid_SolderList(0, 2) = "제품명"
        Grid_SolderList(0, 3) = "중량(g)"
        Grid_SolderList(0, 4) = "유효기간"
        Grid_SolderList(0, 5) = "Lot No.(Serial)"
        Grid_SolderList.AutoSizeCols()

    End Sub

    Private Sub BTN_New_Click(sender As Object, e As EventArgs) Handles BTN_New.Click

        CB_Vendor.Enabled = True
        CB_Product.Enabled = True
        CB_Weight.Enabled = True
        TB_Barcode.Enabled = True
        BTN_Save.Enabled = True

        Label5.Text = "입고수량 : 0 EA"
        Label6.Text = "총 중량 : 0 g"

        Grid_SolderList.Rows.Count = 1
        Grid_SolderList.Rows.Count = 1
        CB_Vendor.SelectedIndex = -1
        CB_Product.SelectedIndex = -1
        CB_Weight.SelectedIndex = -1

        Load_Vendor()

    End Sub

    Private Sub ControlLock()

        CB_Vendor.Enabled = False
        CB_Product.Enabled = False
        CB_Weight.Enabled = False
        TB_Barcode.Enabled = False
        BTN_Save.Enabled = False

        Label5.Text = "입고수량 : 0 EA"
        Label6.Text = "총 중량 : 0 g"

        Grid_SolderList.Rows.Count = 1
        CB_Vendor.SelectedIndex = -1
        CB_Product.SelectedIndex = -1
        CB_Weight.SelectedIndex = -1

    End Sub

    Private Sub Load_Vendor()

        CB_Vendor.Items.Clear()

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "select sub_code_name from tb_code_sub"
        strSQL += " where main_code = 'MC00000006' order by sub_code_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            CB_Vendor.Items.Add(sqlDR("sub_code_name"))
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub CB_Vendor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_Vendor.SelectionChangeCommitted

        If DBConnect() = False Then Exit Sub
        CB_Product.Items.Clear()

        Dim strSQL As String = "select sub_code from tb_code_sub"
        strSQL += " where sub_code_name = '" & CB_Vendor.Text & "'"
        strSQL += " and main_code = 'MC00000006'"
        Dim subCode As String = String.Empty

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            subCode = sqlDR("sub_code")
        Loop
        sqlDR.Close()

        strSQL = "select last_code_name from tb_code_last"
        strSQL += " where sub_code = '" & subCode & "'"
        strSQL += " order by last_code_name"

        sqlCmd = New MySqlCommand(strSQL, dbConnection1)
        sqlDR = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            CB_Product.Items.Add(sqlDR("last_code_name"))
        Loop
        sqlDR.Close()

        DBClose()

        CB_Product.SelectedIndex = -1

    End Sub

    Private Sub TB_Barcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TB_Barcode.KeyPress

        If CB_Vendor.Text = String.Empty Or CB_Product.Text = String.Empty Or CB_Weight.Text = String.Empty Then
            e.KeyChar = Nothing
            MSG_Information(Me, "필수 사항을 먼저 선택하여 주십시오.")
        End If

    End Sub

    Private Sub TB_Barcode_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_Barcode.KeyDown

        If e.KeyCode = 13 And Not Trim(TB_Barcode.Text).Equals(String.Empty) Then
            '중복검사
            Dim existSolder As Boolean = False
            Dim TotalWeight As Double = 0
            For i = 1 To Grid_SolderList.Rows.Count - 1
                If Grid_SolderList(i, 5).ToString.Equals(Trim(TB_Barcode.Text)) Then
                    existSolder = True
                End If
                TotalWeight += CDbl(Grid_SolderList(i, 3).ToString.Replace("g", String.Empty))
            Next

            If existSolder = True Then
                MSG_Information(Me, "이미 등록된 Lot No.(Serial) 입니다.")
                TB_Barcode.SelectAll()
                TB_Barcode.Focus()
                Exit Sub
            End If

            '중복이 없다면 등록
            Dim insertString As String = Grid_SolderList.Rows.Count & vbTab &
                CB_Vendor.Text & vbTab &
                CB_Product.Text & vbTab &
                CB_Weight.Text & vbTab &
                Format(DateTimePicker1.Value, "yyyy-MM-dd") & vbTab &
                Trim(TB_Barcode.Text)
            GridWriteText(insertString, Me, Grid_SolderList, Color.Blue)
            GridColsAutoSize(Me, Grid_SolderList)

            '입고 수량 증가
            TotalWeight += CDbl(CB_Weight.Text.Replace("g", String.Empty))
            Label5.Text = "입고수량 : " & Format(Grid_SolderList.Rows.Count - 1, "#,##0") & " EA"
            If TotalWeight.ToString.Length < 4 Then
                Label6.Text = "총 중량 : " & Format(TotalWeight, "#,##0") & " g"
            ElseIf TotalWeight.ToString.Length = 4 Then
                Label6.Text = "총 중량 : " & Format(TotalWeight / 1000, "#.00") & " Kg"
            End If

            TB_Barcode.Text = String.Empty
            TB_Barcode.Focus()
        End If

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        If MSG_Question(Me, "유효기간을 필히 확인하여 주십시오." & vbCrLf & "저장 하시겠습니까?") = False Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        If DBConnect() = False Then Exit Sub

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            'Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            For i = 1 To Grid_SolderList.Rows.Count - 1
                strSQL += "insert into tb_mms_solder_warehouse("
                strSQL += "date_of_warehousing, house_no, vendor, product"
                strSQL += ", weight, date_of_validity, lot_no, solder_status"
                strSQL += ") values ("
                strSQL += "'" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "'"
                strSQL += ",'" & Grid_SolderList(i, 0) & "'"
                strSQL += ",'" & Grid_SolderList(i, 1) & "'"
                strSQL += ",'" & Grid_SolderList(i, 2) & "'"
                strSQL += ",'" & Grid_SolderList(i, 3) & "'"
                strSQL += ",'" & Format(cdate(Grid_SolderList(i, 4)), "yyyy-MM-dd") & "'"
                strSQL += ",'" & Grid_SolderList(i, 5) & "'"
                strSQL += ",'Warehousing'"
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

            MSG_Exclamation(Me, ex.Message)
            Exit Sub
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        MSG_Information(Me, "저장완료.")

        Grid_SolderList.Redraw = False
        Grid_SolderList.Rows.Count = 1
        Grid_SolderList.Redraw = True

        ControlLock()

    End Sub
End Class