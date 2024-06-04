Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Material_Transfer

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
            Dim mwNo As String = Load_MW_No()

            If RadioButton1.Checked Then
                If WorkSite_Move(mwNo) = False Then Exit Sub
            Else
                If Warehouse_Move(mwNo) = False Then Exit Sub
            End If

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

            Control_Init()
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
End Class