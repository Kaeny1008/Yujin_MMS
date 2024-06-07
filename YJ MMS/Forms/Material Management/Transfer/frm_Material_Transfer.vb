Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Material_Transfer

    Dim mwNo As String

    Private Sub frm_Material_WorkSite_Transfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        DateTimePicker2.Value = Format(Now, "yyyy-MM-01")
        DateTimePicker3.Value = Format(Now, "yyyy-MM-dd")

        Load_CustomerList()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub Grid_Setting()

        With Grid_History
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 7
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            Grid_History(0, 0) = "No"
            Grid_History(0, 1) = "자재코드"
            Grid_History(0, 2) = "Vendor"
            Grid_History(0, 3) = "Part No."
            Grid_History(0, 4) = "Lot No."
            Grid_History(0, 5) = "수량"
            Grid_History(0, 6) = "mw_no"
            .Cols(6).Visible = False
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            '.Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            '.ExtendLastCol = True
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
        End With

        With Grid_TNList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 4
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            Grid_TNList(0, 0) = "No"
            Grid_TNList(0, 1) = "입,출고번호"
            Grid_TNList(0, 2) = "구분"
            Grid_TNList(0, 3) = "일자"
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            '.Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            '.ExtendLastCol = True
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
        End With

    End Sub

    Private Sub Load_CustomerList()

        Thread_LoadingFormStart()

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

        Thread_LoadingFormEnd()

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

        TB_BarcodeScan.Focus()
        TB_BarcodeScan.SelectAll()

    End Sub

    Private Sub Control_Init()

        TB_CustomerPartCode.Text = String.Empty
        TB_PartNo.Text = String.Empty
        TB_LotNo.Text = String.Empty
        TB_Qty.Text = String.Empty
        TB_Vendor.Text = String.Empty
        TB_1stQty.Text = String.Empty
        TB_2ndQty.Text = String.Empty

    End Sub

    Private Sub TB_BarcodeScan_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_BarcodeScan.KeyDown

        If e.KeyCode = 13 And Not Trim(TB_BarcodeScan.Text) = String.Empty Then

            If RadioButton1.Checked = False And RadioButton2.Checked = False Then
                MessageBox.Show(Me,
                                "구분(입, 출고)를 먼저 선택하여 주십시오.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Exit Sub
            End If

            If TB_CustomerCode.Text = String.Empty Then
                MessageBox.Show(Me,
                                "고객사를 먼저 선택하여 주십시오.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Exit Sub
            End If

            '바코드를 분해한다.
            If Barcode_Split() = False Then Exit Sub

            '그리드에 동일한 자재가 등록되어 있는지 확인 한다.
            If Grid_ExistCheck() = True Then
                frm_Material_Transfer_Warning.Label1.Text = "※※※등록 실패※※※" &
                    vbCrLf &
                    vbCrLf &
                    "이미 등록된 자재입니다."
                frm_Material_Transfer_Warning.ShowDialog()
                Control_Init()
                TB_BarcodeScan.Focus()
                Exit Sub
            End If

            '입고번호를 불러온다.
            '현장에 출고된 자재라고 명시하기 위해.
            mwNo = Load_MW_No()

            If RadioButton1.Checked Then
                If WorkSite_Move(mwNo) = False Then Exit Sub
            Else
                If Warehouse_Move(mwNo) = False Then Exit Sub
            End If

            If CB_AutoAdd.Checked = True Then
                BTN_ListAdd_Click(Nothing, Nothing)
            End If

            TB_BarcodeScan.Focus()
        End If

    End Sub

    Private Function Warehouse_Move(ByVal mwNo As String) As Boolean

        '현장에 출고된 자재인지 확인한다.
        If Not Check_MW_No(mwNo, "In") = "Run" Then
            frm_Material_Transfer_Warning.Label1.Text = "※※※입고등록 실패※※※" &
                vbCrLf &
                vbCrLf &
                "현장출고 되지않은 자재 입니다."
            frm_Material_Transfer_Warning.ShowDialog()
            Control_Init()
            TB_BarcodeScan.Focus()
            Return False
        End If

        Return True

    End Function

    Private Function WorkSite_Move(ByVal mwNo As String) As Boolean

        '선입선출 확인 한다.
        Dim showString As String = PartIndex_Check()
        If Not showString = String.Empty Then
            frm_Material_Transfer_Warning.Label1.Text = "※※※출고등록 실패※※※" &
                vbCrLf &
                vbCrLf &
                showString &
                vbCrLf &
                vbCrLf &
                "우선 입고된 자재가 존재합니다."
            frm_Material_Transfer_Warning.ShowDialog()
            'MessageBox.Show(Me,
            '                showString & vbCrLf & vbCrLf & "우선 입고된 자재가 존재합니다.",
            '                msg_form & "(선입선출)",
            '                MessageBoxButtons.OK,
            '                MessageBoxIcon.Exclamation)
            Control_Init()
            TB_BarcodeScan.Focus()
            Return False
        End If

        '현장에 출고된 자재인지 확인한다.
        If Check_MW_No(mwNo, "Out") = "Run" Then
            frm_Material_Transfer_Warning.Label1.Text = "※※※출고등록 실패※※※" &
                vbCrLf &
                vbCrLf &
                "이미 현장 출고된 자재입니다."
            frm_Material_Transfer_Warning.ShowDialog()
            Control_Init()
            TB_BarcodeScan.Focus()
            Return False
        End If

        Return True

    End Function

    Private Function Grid_ExistCheck() As Boolean

        Dim exist As Boolean = False

        For i = 1 To Grid_History.Rows.Count - 1
            If Grid_History(i, 1) = TB_CustomerPartCode.Text And
                Grid_History(i, 3) = TB_PartNo.Text And
                Grid_History(i, 4) = TB_LotNo.Text Then
                exist = True
            End If
        Next

        Return exist

    End Function

    Private Function Barcode_Split() As Boolean

        Thread_LoadingFormStart()

        Dim splitResult As Boolean = False

        Try
            '110400017!WR12X36R0FTL!106951338-5860!5000!WALSIN!2024.03.28
            'For i = 0 To TB_BarcodeScan.Text.Length - 1
            '    If Asc(TB_BarcodeScan.Text.Substring(i, 1)) = 13 Then
            '        MsgBox("검출")
            '    End If
            'Next
            TB_BarcodeScan.Text = TB_BarcodeScan.Text.Replace(vbCrLf, String.Empty)
            Dim splitBarcode() As String = Trim(TB_BarcodeScan.Text).Split("!")
            TB_CustomerPartCode.Text = Trim(splitBarcode(0))
            TB_PartNo.Text = Trim(splitBarcode(1))
            TB_LotNo.Text = Trim(splitBarcode(2))
            TB_Qty.Text = Format(CInt(Trim(splitBarcode(3))), "#,##0")
            TB_Vendor.Text = Trim(splitBarcode(4))
            'TB_InDate.Text = Trim(splitBarcode(5)) <-서버에서 일자시간까지 불러오는걸로 변경
            TB_BarcodeScan.Clear()
            splitResult = True
        Catch ex As Exception
            Thread_LoadingFormEnd()
            MessageBox.Show(Me,
                            ex.Message,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Control_Init()
            TB_BarcodeScan.Clear()
            TB_BarcodeScan.Focus()
        End Try

        Thread_LoadingFormEnd()

        Return splitResult

    End Function

    Private Function PartIndex_Check() As String

        DBConnect()

        Dim checkResult As String = String.Empty

        Dim strSQL As String = "call sp_mms_material_transfer("
        strSQL += "0"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ", '" & TB_CustomerPartCode.Text & "'"
        strSQL += ", '" & TB_LotNo.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            checkResult = "입고일자 : " & Format(sqlDR("write_date"), "yyyy-MM-dd HH:mm:ss")
            checkResult += vbCrLf & "Vendor : " & sqlDR("part_vendor")
            checkResult += vbCrLf & "Part No. : " & sqlDR("part_no")
            checkResult += vbCrLf & "Lot No. : " & sqlDR("part_lot_no")
            checkResult += vbCrLf & "수량 : " & sqlDR("part_qty")
        Loop
        sqlDR.Close()

        DBClose()

        Return checkResult

    End Function

    Private Function Load_MW_No() As String

        Dim mwNo As String = String.Empty

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_transfer("
        strSQL += "1"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ", '" & TB_CustomerPartCode.Text & "'"
        strSQL += ", '" & TB_LotNo.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            mwNo = sqlDR("mw_no")
            TB_InDate.Text = Format(sqlDR("write_date"), "yyyy-MM-dd HH:mm:ss")
            TextBox1.Text = sqlDR("split_count")
            TB_Qty.Text = Format(sqlDR("part_qty"), "#,##0")
        Loop
        sqlDR.Close()

        DBClose()

        Return mwNo

    End Function

    Private Function Check_MW_No(ByVal mw_no As String, ByVal status As String) As String

        Dim part_status As String = String.Empty

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_transfer("
        strSQL += "2"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & mw_no & "'"
            strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & status & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            part_status = sqlDR("part_status")
        Loop
        sqlDR.Close()

        DBClose()

        Return part_status

    End Function

    Private Sub BTN_New_Transfer_Click(sender As Object, e As EventArgs) Handles BTN_New_Transfer.Click

        TB_TN_No.Text = String.Empty
        SplitContainer1.Panel2.Enabled = True
        RadioButton1.Checked = False
        RadioButton2.Checked = False

        Grid_History.Redraw = False
        Grid_History.Rows.Count = 1
        Grid_History.Redraw = True

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        If MessageBox.Show(Me,
                           "저장 하시겠습니까?",
                           msg_form,
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Thread_LoadingFormStart("Saving...")

        TempCode_Making()
        Dim saveResult As String = Save_Data()

        If Not saveResult = String.Empty Then
            MessageBox.Show(Me,
                            saveResult,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Control_Init()
        TB_CustomerCode.Text = String.Empty
        CB_CustomerName.SelectedIndex = -1
        TB_TN_No.Text = String.Empty
        SplitContainer1.Panel2.Enabled = False

        Thread_LoadingFormEnd()

        MessageBox.Show(Me,
                        "저장완료",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

        BTN_Search_Click(Nothing, Nothing)

    End Sub

    Private Sub TempCode_Making()

        Dim status As String = "Out"

        If RadioButton2.Checked Then
            status = "In"
        End If

        DBConnect()

        Dim strSQL As String = "select f_mms_material_transfer_no("
        strSQL += "'" & Format(Now, "yyyy-MM-dd") & "'"
        strSQL += ",'" & status & "'"
        strSQL += ") as tn_no"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_TN_No.Text = sqlDR("tn_no")
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Function Save_Data() As String

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            Dim nowTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            strSQL = "update tb_mms_material_transfer set"
            strSQL += " write_date = '" & nowTime & "'"
            strSQL += ", write_id = '" & loginID & "'"
            strSQL += " where tn_no = '" & TB_TN_No.Text & "';"

            For i = 1 To Grid_History.Rows.Count - 1

                strSQL += "insert into tb_mms_material_transfer_out_content("
                strSQL += "mw_no, tn_no, part_status"
                strSQL += ") values("
                strSQL += "'" & Grid_History(i, 6) & "'"
                strSQL += ",'" & TB_TN_No.Text & "'"
                If RadioButton1.Checked Then
                    strSQL += ", 'Run'"
                Else
                    strSQL += ", 'Closed'"
                End If
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
            Return ex.Message
        End Try

        DBClose()

        Return String.Empty

    End Function

    'Private Sub frm_Material_WorkSite_Transfer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    '    Delete_TempCode()

    'End Sub

    'Private Sub frm_Material_WorkSite_Transfer_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

    '    Delete_TempCode()

    'End Sub

    'Private Sub Delete_TempCode()

    '    If tempCode_Delete = True Then
    '        DBConnect()

    '        Dim sqlTran As MySqlTransaction
    '        Dim sqlCmd As MySqlCommand
    '        Dim strSQL As String = String.Empty

    '        sqlTran = dbConnection1.BeginTransaction

    '        Try

    '            strSQL = "delete from tb_mms_material_transfer"
    '            strSQL += " where tn_no = '" & tempCode & "';"

    '            If Not strSQL = String.Empty Then
    '                sqlCmd = New MySqlCommand(strSQL, dbConnection1)
    '                sqlCmd.Transaction = sqlTran
    '                sqlCmd.ExecuteNonQuery()

    '                sqlTran.Commit()
    '            End If
    '        Catch ex As MySqlException
    '            sqlTran.Rollback()

    '            DBClose()

    '            MessageBox.Show(frm_Main,
    '                            ex.Message,
    '                            msg_form,
    '                            MessageBoxButtons.OK,
    '                            MessageBoxIcon.Error)
    '            Exit Sub
    '        End Try

    '        DBClose()
    '    End If

    'End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart()

        Grid_TNList.Redraw = False
        Grid_TNList.Rows.Count = 1

        Dim section As String = "All"
        If RadioButton4.Checked Then section = "Out"
        If RadioButton3.Checked Then section = "In"

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_transfer("
        strSQL += "3"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ",'" & Format(DateTimePicker2.Value, "yyyy-MM-dd 00:00:00") & "'"
        strSQL += ",'" & Format(DateTimePicker3.Value, "yyyy-MM-dd 23:59:59") & "'"
        strSQL += ", null"
        strSQL += ", '" & section & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String
            insertString = Grid_TNList.Rows.Count
            insertString += vbTab & sqlDR("tn_no")
            insertString += vbTab & sqlDR("section")
            insertString += vbTab & Format(sqlDR("write_date"), "yyyy-MM-dd HH:mm:ss")
            Grid_TNList.AddItem(insertString)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_TNList.Redraw = True
        Grid_TNList.AutoSizeCols()

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_TNList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Grid_TNList.MouseDoubleClick

        Dim selRow As Integer = Grid_TNList.MouseRow
        If e.Button = MouseButtons.Left And selRow > 0 Then
            Thread_LoadingFormStart()

            'Delete_TempCode()

            TB_TN_No.Text = Grid_TNList(selRow, 1)

            If Grid_TNList(selRow, 2) = "입고" Then
                RadioButton2.Checked = True
            Else
                RadioButton1.Checked = True
            End If

            Grid_History.Redraw = False
            Grid_History.Rows.Count = 1

            DBConnect()

            Dim strSQL As String = "call sp_mms_material_transfer("
            strSQL += "4"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", '" & Grid_TNList(selRow, 1) & "'"
            strSQL += ", null"
            strSQL += ")"

            Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
            Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

            Do While sqlDR.Read
                Dim insertString As String
                insertString = Grid_History.Rows.Count
                insertString += vbTab & sqlDR("part_code")
                insertString += vbTab & sqlDR("part_vendor")
                insertString += vbTab & sqlDR("part_no")
                insertString += vbTab & sqlDR("part_lot_no")
                insertString += vbTab & sqlDR("part_qty")
                insertString += vbTab & sqlDR("mw_no")
                Grid_History.AddItem(insertString)
            Loop
            sqlDR.Close()

            DBClose()

            Grid_History.Redraw = True
            Grid_History.AutoSizeCols()

            Control_Init()
            SplitContainer1.Panel2.Enabled = False

            Thread_LoadingFormEnd()
        End If

    End Sub

    Private Sub CB_PartsSplit_CheckedChanged(sender As Object, e As EventArgs) Handles CB_PartsSplit.CheckedChanged

        If CB_PartsSplit.Checked = True Then
            TB_1stQty.Enabled = True
            TB_2ndQty.Enabled = True
            TB_1stQty.SelectAll()
            TB_1stQty.Focus()
        Else
            TB_1stQty.Enabled = False
            TB_2ndQty.Enabled = False
        End If

    End Sub

    Private Sub TB_Qty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TB_1stQty.KeyPress, TB_2ndQty.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "," Then
            e.Handled = True
        End If

    End Sub

    Private Sub CB_AutoAdd_CheckedChanged(sender As Object, e As EventArgs) Handles CB_AutoAdd.CheckedChanged

        If CB_AutoAdd.Checked = True Then
            CB_PartsSplit.Checked = False
            CB_PartsSplit.Enabled = False
            BTN_ListAdd.Enabled = False
        Else
            CB_PartsSplit.Enabled = True
            BTN_ListAdd.Enabled = True
        End If

    End Sub

    Private Sub TB_1stQty_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_1stQty.KeyDown

        If Not TB_1stQty.Text = String.Empty And e.KeyCode = 13 Then
            TB_2ndQty.SelectAll()
            TB_2ndQty.Focus()
        End If

    End Sub

    Private Sub TB_2ndQty_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_2ndQty.KeyDown

        If Not TB_2ndQty.Text = String.Empty And e.KeyCode = 13 Then

            If (CDbl(TB_1stQty.Text) + CDbl(TB_2ndQty.Text)) > CDbl(TB_Qty.Text) Then
                MessageBox.Show(Me,
                                "출고+보관 수량이 입고 수량보다 큽니다.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

    End Sub

    Private Sub BTN_ListAdd_Click(sender As Object, e As EventArgs) Handles BTN_ListAdd.Click

        If CB_PartsSplit.Checked = True Then
            If MessageBox.Show(Me,
                               "출고, 보관수량을 확인하여 주십시오." & vbCrLf & "분할작업은 즉시 데이터가 저장됩니다." & vbCrLf & "출고목록에 등록하시겠습니까?",
                               msg_form,
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

            Dim splitCount As Integer = CInt(TextBox1.Text)
            Dim newLotNo As String = TB_LotNo.Text & "-S" & (splitCount + 1)
            '분할내용 서버저장
            Dim dbResult As Boolean = DB_Write(newLotNo)

            If dbResult = True Then
                Material_PrintLabel(TB_CustomerPartCode.Text,
                                    TB_PartNo.Text,
                                    TB_LotNo.Text,
                                    TB_2ndQty.Text,
                                    TB_Vendor.Text,
                                    1,
                                    CB_CustomerName.Text,
                                    Format(CDate(TB_InDate.Text), "yyyy.MM.dd"),
                                    True,
                                    newLotNo,
                                    TB_1stQty.Text)
            Else
                Exit Sub
            End If

            Dim newMwNo As String = Load_New_MW_No()

            '그리드에 임시저장 리스트를 등록한다.
            Dim insertString As String
            insertString = Grid_History.Rows.Count
            insertString += vbTab & TB_CustomerPartCode.Text
            insertString += vbTab & TB_Vendor.Text
            insertString += vbTab & TB_PartNo.Text
            insertString += vbTab & newLotNo
            insertString += vbTab & TB_1stQty.Text
            insertString += vbTab & newMwNo

            Grid_History.AddItem(insertString)
            Grid_History.AutoSizeCols()
        Else
            '그리드에 임시저장 리스트를 등록한다.
            Dim insertString As String
            insertString = Grid_History.Rows.Count
            insertString += vbTab & TB_CustomerPartCode.Text
            insertString += vbTab & TB_Vendor.Text
            insertString += vbTab & TB_PartNo.Text
            insertString += vbTab & TB_LotNo.Text
            insertString += vbTab & TB_Qty.Text
            insertString += vbTab & mwNo

            Grid_History.AddItem(insertString)
            Grid_History.AutoSizeCols()
        End If

        Control_Init()
        TB_BarcodeScan.Focus()

    End Sub

    Private Function DB_Write(ByVal newLotNo As String) As Boolean

        Thread_LoadingFormStart("Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            'History에 등록
            strSQL = "insert into tb_mms_material_history("
            strSQL += "history_index, category, write_date, writer, customer_code, part_code"
            strSQL += ", part_vendor, part_no, part_lot_no, history_qty, split_1stqty, split_2ndqty, org_in_date"
            strSQL += ") values ("
            strSQL += "f_mms_material_history_no('" & Format(CDate(writeDate), "yyyy-MM-dd") & "')"
            strSQL += ", '자재분할'"
            strSQL += ", '" & writeDate & "'"
            strSQL += ", '" & loginID & "'"
            strSQL += ", '" & TB_CustomerCode.Text & "'"
            strSQL += ", '" & TB_CustomerPartCode.Text & "'"
            strSQL += ", '" & TB_Vendor.Text & "'"
            strSQL += ", '" & TB_PartNo.Text & "'"
            strSQL += ", '" & TB_LotNo.Text & "'"
            strSQL += ", " & CDbl(TB_Qty.Text) & ""
            strSQL += ", " & CDbl(TB_1stQty.Text) & ""
            strSQL += ", " & CDbl(TB_2ndQty.Text) & ""
            strSQL += ", '" & TB_InDate.Text & "'"
            strSQL += ");"
            '입고등록
            strSQL += "insert into tb_mms_material_warehousing("
            strSQL += "mw_no, in_no, document_no, customer_code, part_code, part_vendor"
            strSQL += ", part_no, part_lot_no, part_qty, write_date, write_id"
            strSQL += ") values ("
            strSQL += "f_mms_new_mw_no(f_mms_new_in_no('" & Format(CDate(writeDate), "yyyy-MM-dd") & "', 'WD" & Format(CDate(writeDate), "yyMMdd") & "-XX'))"
            strSQL += ", f_mms_new_in_no('" & Format(CDate(writeDate), "yyyy-MM-dd") & "', 'WD" & Format(CDate(writeDate), "yyMMdd") & "-XX')"
            strSQL += ", 'WD" & Format(CDate(writeDate), "yyMMdd") & "-XX'"
            strSQL += ", '" & TB_CustomerCode.Text & "'"
            strSQL += ", '" & TB_CustomerPartCode.Text & "'"
            strSQL += ", '" & TB_Vendor.Text & "'"
            strSQL += ", '" & TB_PartNo.Text & "'"
            strSQL += ", '" & newLotNo & "'"
            strSQL += ", " & CDbl(TB_1stQty.Text) & ""
            strSQL += ", '" & TB_InDate.Text & "'"
            strSQL += ", '" & loginID & "'"
            strSQL += ");"
            '기존자재수량에 현재 분할된 자재수량을 차감
            strSQL += "update tb_mms_material_warehousing set part_qty = " & CDbl(TB_Qty.Text) - CDbl(TB_1stQty.Text) & ""
            strSQL += ", split_count = " & CInt(TextBox1.Text) + 1 & ""
            strSQL += " where mw_no = '" & mwNo & "';"

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
                            ex.Message & vbCrLf & "Error No. : " & ex.Number,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1)
            Return False
        Finally

        End Try

        DBClose()

        Thread_LoadingFormEnd()

        Return True

    End Function

    Private Function Load_New_MW_No() As String

        Dim newMwNo As String = String.Empty

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_transfer("
        strSQL += "1"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ", '" & TB_CustomerPartCode.Text & "'"
        strSQL += ", '" & TB_LotNo.Text & "-S" & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            newMwNo = sqlDR("mw_no")
        Loop
        sqlDR.Close()

        DBClose()

        Return newMwNo

    End Function

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

        If RadioButton2.Checked = True Then
            CB_PartsSplit.Checked = False
            CB_PartsSplit.Enabled = False
        Else
            CB_PartsSplit.Enabled = True
        End If

    End Sub
End Class