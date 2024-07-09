Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_OQC_Register

    Dim nowDiscardQty As Integer

    Private Sub frm_OQC_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub Grid_Setting()

        With Grid_History
            .AllowEditing = False
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 7
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = True
            .ShowCursor = True
        End With

        Grid_History(0, 0) = "No"
        Grid_History(0, 1) = "등록일자"
        Grid_History(0, 2) = "출하검사번호"
        Grid_History(0, 3) = "외관검사 결과"
        Grid_History(0, 4) = "수량"
        Grid_History(0, 5) = "검사자"
        Grid_History(0, 6) = "비고"

        Grid_History.AutoSizeCols()

        With Grid_BoxList
            .AllowEditing = False
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 4
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = True
            .ShowCursor = True
        End With

        Grid_BoxList(0, 0) = "No"
        Grid_BoxList(0, 1) = "제품 일련번호"
        Grid_BoxList(0, 2) = "등록일시"
        Grid_BoxList(0, 3) = "비고"

        Grid_BoxList.AutoSizeCols()

    End Sub

    Private Sub Control_Init()

        TB_OrderIndex.Text = String.Empty
        TB_LastProcess.Text = String.Empty
        TB_ItemCode.Text = String.Empty
        TB_ItemName.Text = String.Empty
        TB_ItemSpec.Text = String.Empty
        TB_POQty.Text = String.Empty
        TB_ModelCode.Text = String.Empty
        TB_OQC_No.Text = String.Empty
        TB_BoxQty.Text = String.Empty

        Grid_BoxList.Rows.Count = 1
        Grid_History.Rows.Count = 1

    End Sub

    Private Sub TB_MagazineBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_MagazineBarcode.KeyDown

        If e.KeyCode = 13 And Not Trim(TB_MagazineBarcode.Text) = String.Empty Then
            'PO202404010002-0004!WSO2405160856453858!Wave Soldering

            Control_Init()

            Try
                Dim splitBarcode() As String = TB_MagazineBarcode.Text.Split("!")
                TB_OrderIndex.Text = splitBarcode(0)
                TB_LastProcess.Text = splitBarcode(2)
            Catch ex As Exception
                MessageBox.Show(Me,
                                "유진 공정라벨을 스캔하여 주십시오.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                TB_MagazineBarcode.SelectAll()
                TB_MagazineBarcode.Focus()
                Exit Sub
            End Try

            TB_MagazineBarcode.Text = String.Empty

            'PO 정보를 불러온다.
            Load_Po_Information()
            If TB_ItemCode.Text = String.Empty Then
                MessageBox.Show(Me,
                                "모델 정보를 불러오지 못했습니다.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                Control_Init()
                TB_MagazineBarcode.SelectAll()
                TB_MagazineBarcode.Focus()
            End If

            '모델 공정상 마지막 공정 라벨인지 확인
            If Load_LastPorcess() = False Then
                MessageBox.Show(Me,
                                "공정이 완료되지 않은 라벨입니다.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                Control_Init()
                TB_MagazineBarcode.SelectAll()
                TB_MagazineBarcode.Focus()
            End If

            TB_SerialNo.SelectAll()
            TB_SerialNo.Focus()

            '출하검사 이력을 불러온다.
            Load_OQCList()

            If CDbl(TB_POQty.Text) = CDbl(TB_InspectedQty.Text) Then
                MessageBox.Show(Me, "이미 검사완료된 주문번호 입니다.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Control_Init()

                Grid_History.Redraw = False
                Grid_History.Rows.Count = 1
                Grid_History.Redraw = True

                TB_MagazineBarcode.SelectAll()
                TB_MagazineBarcode.Focus()

                BTN_NewBox.Enabled = False
                BTN_Save.Enabled = False
            Else
                BTN_NewBox.Enabled = True
                BTN_Save.Enabled = False
            End If
        End If

    End Sub

    Private Sub Load_OQCList()

        Thread_LoadingFormStart()

        Grid_History.Redraw = False
        Grid_History.Rows.Count = 1

        TB_InspectedQty.Text = 0

        DBConnect()

        Dim strSQL As String = "call sp_mms_oqc(2"
        strSQL += ", '" & TB_OrderIndex.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = Grid_History.Rows.Count
            insertString += vbTab & Format(sqlDR("write_date"), "yyyy-MM-dd HH:mm:ss")
            insertString += vbTab & sqlDR("oqc_no")
            insertString += vbTab & sqlDR("inspect_result")
            insertString += vbTab & Format(sqlDR("box_qty"), "#,##0")
            insertString += vbTab & sqlDR("inspector")
            insertString += vbTab & sqlDR("oqc_note")

            Grid_History.AddItem(insertString)

            TB_InspectedQty.Text = Format(CDbl(TB_InspectedQty.Text) + sqlDR("box_qty"), "#,##0")
        Loop
        sqlDR.Close()

        DBClose()

        Grid_History.AutoSizeCols()
        Grid_History.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_Po_Information()

        Thread_LoadingFormStart()

        DBConnect()

        Dim strSQL As String = "call sp_mms_oqc(0"
        strSQL += ", '" & TB_OrderIndex.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_ItemCode.Text = sqlDR("item_code")
            TB_ItemName.Text = sqlDR("item_name")
            TB_ItemSpec.Text = sqlDR("item_spec")
            TB_POQty.Text = sqlDR("modify_order_quantity")
            TB_ModelCode.Text = sqlDR("model_code")
            If sqlDR("barcode_string").ToString.Equals("Use") Then
                RB_UseSerial.Checked = True
            Else
                RB_NotUseSerial.Checked = True
            End If
            nowDiscardQty = sqlDR("discard_quantity")
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

    End Sub

    Private Function Load_LastPorcess() As Boolean

        Thread_LoadingFormStart()

        DBConnect()

        Dim checkOK As Boolean = False

        Dim strSQL As String = "call sp_mms_oqc(1"
        strSQL += ", null"
        strSQL += ", '" & TB_ModelCode.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            If sqlDR("process_name").ToString.ToUpper = TB_LastProcess.Text Then
                checkOK = True
            End If
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

        Return checkOK

    End Function

    Private Sub TB_SerialNo_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_SerialNo.KeyDown

        If e.KeyCode = 13 And Not Trim(TB_SerialNo.Text) = String.Empty Then

            If BTN_Save.Enabled = False Then
                MessageBox.Show(Me,
                                "출하검사번호를 먼저 생성하여 주십시오.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                TB_SerialNo.SelectAll()
                TB_SerialNo.Focus()
                Exit Sub
            End If

            If RB_NotUseSerial.Checked = True Then
                MessageBox.Show(Me,
                                "제품 시리얼번호가 존재하지 않은 모델입니다.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                TB_SerialNo.SelectAll()
                TB_SerialNo.Focus()
                Exit Sub
            End If

            Dim checkSerial As String = String.Empty
            Try
                checkSerial = TB_SerialNo.Text.Substring(0, TB_SerialNo.Text.Length - 10)
            Catch ex As Exception
                MessageBox.Show(Me,
                                "바코드를 인식 할 수 없습니다.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                TB_SerialNo.SelectAll()
                TB_SerialNo.Focus()
                Exit Sub
            End Try

            If Not TB_ItemCode.Text.Equals(checkSerial) Then
                MessageBox.Show(Me,
                                "현품표 제품번호와 제품일련번호 확인이 불일치 합니다.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                TB_SerialNo.SelectAll()
                TB_SerialNo.Focus()
                Exit Sub
            End If

            For i = 1 To Grid_BoxList.Rows.Count - 1
                If Grid_BoxList(i, 1).ToString.Equals(TB_SerialNo.Text) Then
                    MessageBox.Show(Me,
                                    "이미 등록된 제품 일련번호 입니다.",
                                    msg_form,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
                    TB_SerialNo.SelectAll()
                    TB_SerialNo.Focus()
                    Exit Sub
                End If
            Next

            If Load_ExistCheck() = True Then
                MessageBox.Show(Me,
                                "이미 박스 구성된 제품 일련번호 입니다.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                TB_SerialNo.SelectAll()
                TB_SerialNo.Focus()
                Exit Sub
            End If

            Dim newRow As Integer = 0

            For i = 1 To Grid_BoxList.Rows.Count - 1
                If CStr(Grid_BoxList(i, 0)).ToString.Equals("N") Then
                    newRow += 1
                End If
            Next

            If CDbl(TB_POQty.Text) = (CDbl(TB_InspectedQty.Text) + newRow + 1) Then
                MessageBox.Show(Me,
                            "주문수량과 총 검사결과 수량이 같습니다." & vbCrLf & "최종 수량이 맞는지 확인 하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            End If

            Dim insertString As String = "N"
            insertString += vbTab & TB_SerialNo.Text
            insertString += vbTab & Format(Now, "yyyy-MM-dd HH:mm:ss")
            Grid_BoxList.Redraw = False
            Grid_BoxList.AddItem(insertString)
            Grid_BoxList.AutoSizeCols()
            Grid_BoxList.Redraw = True

            TB_SerialNo.Text = String.Empty
            TB_SerialNo.Focus()
        End If

    End Sub

    Private Function Load_ExistCheck() As Boolean

        Thread_LoadingFormStart()

        DBConnect()

        Dim checkOK As Boolean = False

        Dim strSQL As String = "call sp_mms_oqc(3"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_SerialNo.Text & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            If sqlDR("serial_no") = TB_SerialNo.Text Then
                checkOK = True
            End If
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

        Return checkOK

    End Function

    Private Sub BTN_NewBox_Click(sender As Object, e As EventArgs) Handles BTN_NewBox.Click

        If Trim(TB_OrderIndex.Text) = String.Empty Then
            MessageBox.Show(Me,
                            "제품을 선택(현품표 스캔)을 먼저 하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        TB_OQC_No.Text = String.Empty

        Thread_LoadingFormStart()

        DBConnect()

        Dim checkOK As Boolean = False

        Dim strSQL As String = "select f_mms_oqc_no("
        strSQL += "'" & Format(Now, "yyyy-MM-dd") & "'"
        strSQL += ")"
        strSQL += " as new_oqc_no"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_OQC_No.Text = sqlDR("new_oqc_no")
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

        If TB_OQC_No.Text = String.Empty Then
            MessageBox.Show(Me,
                            "출하검사번호를 생성하지 못하였습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        LB_New_Update.Visible = True
        LB_New_Update.Text = "신규"
        BTN_NewBox.Enabled = False
        BTN_Save.Enabled = True
        BTN_Fault_Register.Enabled = True
        BTN_Reinspector.Enabled = True

        Grid_BoxList.Redraw = False
        Grid_BoxList.Rows.Count = 1
        Grid_BoxList.Redraw = True

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        If RB_UseSerial.Checked = True And Grid_BoxList.Rows.Count = 1 Then
            MessageBox.Show(Me,
                            "박스 구성된 제품이 없습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
            Exit Sub
        ElseIf RB_NotUseSerial.Checked = True Then
            If Trim(TB_BoxQty.Text) = String.Empty Then
                MessageBox.Show(Me,
                                "박스 구성 수량을 입력하여 주십시오.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                TB_BoxQty.SelectAll()
                TB_BoxQty.Focus()
                Exit Sub
            End If
        End If

        If Not RB_Inspection_OK.Checked And Not RB_Inspection_NG.Checked Then
            MessageBox.Show(Me,
                            "외관검사 결과를 선택하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Trim(TB_Inspector.Text) = String.Empty Then
            MessageBox.Show(Me,
                            "검사자를 입력하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
            TB_Inspector.SelectAll()
            TB_Inspector.Focus()
            Exit Sub
        End If

        Dim poEnd As Boolean = False

        Dim newRow As Integer = 0

        If RB_UseSerial.Checked = True Then
            For i = 1 To Grid_BoxList.Rows.Count - 1
                If CStr(Grid_BoxList(i, 0)).ToString.Equals("N") Then
                    newRow += 1
                End If
            Next
        Else
            newRow = CInt(TB_BoxQty.Text)
        End If

        If CDbl(TB_POQty.Text) < (CDbl(TB_InspectedQty.Text) + newRow + nowDiscardQty) Then
            MessageBox.Show(Me,
                            "주문수량 보다 검사결과 수량이 많습니다." & vbCrLf & "확인하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
            Exit Sub
        ElseIf CDbl(TB_POQty.Text) = (CDbl(TB_InspectedQty.Text) + newRow + nowDiscardQty) Then
            If CheckReinspection() = False Then
                MessageBox.Show(Me,
                                "수리품 재검사가 완료되지 않았습니다.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk)
                Exit Sub
            End If
            poEnd = True
        End If


        If MessageBox.Show(Me,
                           "저장 하시겠습니까?",
                           msg_form,
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Dim writeResult As String = Write_Data(poEnd)

        If Not writeResult = String.Empty Then
            MessageBox.Show(Me,
                            writeResult,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Exit Sub
        End If

        BTN_NewBox.Enabled = True
        BTN_Save.Enabled = False
        BTN_Reinspector.Enabled = False
        BTN_Fault_Register.Enabled = False

        If poEnd = True Then
            MessageBox.Show(Me,
                            "현재 주문번호의 생산이 완료되었습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Control_Init()
            TB_MagazineBarcode.SelectAll()
            TB_MagazineBarcode.Focus()
        Else
            MessageBox.Show(Me,
                            "저장완료.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

            Grid_BoxList.Redraw = False
            Grid_BoxList.Rows.Count = 1
            Grid_BoxList.Redraw = True

            TB_BoxQty.Text = String.Empty

            TB_OQC_No.Text = String.Empty

            LB_New_Update.Visible = False

            Load_OQCList()
        End If

    End Sub

    Private Function CheckReinspection() As Boolean

        Dim not_inspect As Integer = 0

        DBConnect()

        Dim strSQL As String = "call sp_mms_oqc(6"
        strSQL += ", '" & TB_OrderIndex.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            not_inspect += sqlDR("not_inspect")
        Loop
        sqlDR.Close()

        DBClose()

        If not_inspect = 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Function Write_Data(ByVal poEnd As Boolean) As String

        Dim writeSuccess As String = String.Empty

        Thread_LoadingFormStart("Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim inspectResult As String = "OK"
            If RB_Inspection_NG.Checked Then
                inspectResult = "NG"
            End If

            If LB_New_Update.Text = "신규" Then
                strSQL = "insert into tb_mms_oqc_list("
                strSQL += "oqc_no, po_no, inspect_result, box_qty, inspector, oqc_note, write_date"
                strSQL += ") values("
                strSQL += "'" & TB_OQC_No.Text & "'"
                strSQL += ",'" & TB_OrderIndex.Text & "'"
                strSQL += ",'" & inspectResult & "'"
                If RB_UseSerial.Checked = True Then
                    strSQL += "," & Grid_BoxList.Rows.Count - 1 & ""
                Else
                    strSQL += "," & CInt(TB_BoxQty.Text) & ""
                End If
                strSQL += ",'" & TB_Inspector.Text & "'"
                strSQL += ",''"
                strSQL += ",'" & writeDate & "'"
                strSQL += ");"
            Else
                strSQL = "update tb_mms_oqc_list set"
                strSQL += " inspect_result = '" & inspectResult & "'"
                If RB_UseSerial.Checked = True Then
                    strSQL += ", box_qty = " & Grid_BoxList.Rows.Count - 1 & ""
                Else
                    strSQL += ", box_qty = " & CInt(TB_BoxQty.Text) & ""
                End If
                strSQL += ", inspector = '" & TB_Inspector.Text & "'"
                strSQL += " where oqc_no = '" & TB_OQC_No.Text & "'"
                strSQL += ";"
            End If

            If RB_UseSerial.Checked = True Then
                For i = 1 To Grid_BoxList.Rows.Count - 1
                    If CStr(Grid_BoxList(i, 0)).ToString.Equals("N") Then
                        strSQL += "insert into tb_mms_oqc_list_content("
                        strSQL += "content_no, oqc_no, serial_no, register_date, content_note"
                        strSQL += ") values("
                        strSQL += "'" & TB_OQC_No.Text & "-" & Format(i, "000") & "'"
                        strSQL += ",'" & TB_OQC_No.Text & "'"
                        strSQL += ",'" & Grid_BoxList(i, 1) & "'"
                        strSQL += ",'" & Grid_BoxList(i, 2) & "'"
                        strSQL += ",'" & Grid_BoxList(i, 3) & "'"
                        strSQL += ");"
                    End If
                Next
            End If

            If poEnd = True Then
                strSQL += "update tb_mms_order_register_list set order_status = 'All Process Completed'"
                strSQL += ", completed_quantity = " & CDbl(TB_POQty.Text) - nowDiscardQty
                strSQL += " where order_index = '" & TB_OrderIndex.Text & "'"
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

            writeSuccess = ex.Message
            Return writeSuccess
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        Return writeSuccess

    End Function

    Private Sub Grid_History_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Grid_History.MouseDoubleClick

        Dim selRow As Integer = Grid_History.MouseRow

        If e.Button = MouseButtons.Left And selRow > 0 Then
            LB_New_Update.Visible = True
            LB_New_Update.Text = "수정"

            BTN_NewBox.Enabled = True
            BTN_Save.Enabled = True

            Grid_BoxList.Redraw = False
            Grid_BoxList.Rows.Count = 1
            Grid_BoxList.Redraw = True

            RB_Inspection_OK.Checked = False
            RB_Inspection_NG.Checked = False

            TB_OQC_No.Text = Grid_History(selRow, 2)

            TB_SerialNo.SelectAll()
            TB_SerialNo.Focus()

            Load_BoxList(Grid_History(selRow, 2))
        End If

    End Sub

    Private Sub Load_BoxList(ByVal sel_OQCNo As String)

        Thread_LoadingFormStart()

        Grid_BoxList.Redraw = False
        Grid_BoxList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_oqc(4"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & sel_OQCNo & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = Grid_BoxList.Rows.Count
            insertString += vbTab & sqlDR("serial_no")
            insertString += vbTab & Format(sqlDR("register_date"), "yyyy-MM-dd HH:mm:ss")
            insertString += vbTab & sqlDR("content_note")

            Grid_BoxList.AddItem(insertString)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_BoxList.AutoSizeCols()
        Grid_BoxList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub BTN_Fault_Register_Click(sender As Object, e As EventArgs) Handles BTN_Fault_Register.Click

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
            TB_Inspector.SelectAll()
            TB_Inspector.Focus()
            Exit Sub
        End If

        frm_OQC_Falult_Register.LB_OrderIndex.Text = TB_OrderIndex.Text
        frm_OQC_Falult_Register.LB_HistoryIndex.Text = TB_OQC_No.Text
        frm_OQC_Falult_Register.LB_ItemCode.Text = TB_ItemCode.Text
        frm_OQC_Falult_Register.LB_ItemName.Text = TB_ItemName.Text
        If Not frm_OQC_Falult_Register.Visible Then frm_OQC_Falult_Register.Show()
        frm_OQC_Falult_Register.Focus()

    End Sub

    Private Sub BTN_Reinspector_Click(sender As Object, e As EventArgs) Handles BTN_Reinspector.Click

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
            TB_Inspector.SelectAll()
            TB_Inspector.Focus()
            Exit Sub
        End If

        frm_OQC_Reinspection.LB_OrderIndex.Text = TB_OrderIndex.Text
        frm_OQC_Reinspection.TB_Inspector.Text = TB_Inspector.Text
        If Not frm_OQC_Reinspection.Visible Then frm_OQC_Reinspection.Show()
        frm_OQC_Reinspection.Focus()

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RB_UseSerial.CheckedChanged, RB_NotUseSerial.CheckedChanged

        If RB_UseSerial.Checked = True Then
            C1DockingTabPage1.Enabled = True
            C1DockingTabPage2.Enabled = False
            C1DockingTabPage1.Focus()
            C1DockingTab1.SelectedTab = C1DockingTabPage1
        Else
            C1DockingTabPage1.Enabled = False
            C1DockingTabPage2.Enabled = True
            C1DockingTab1.SelectedTab = C1DockingTabPage2
        End If

    End Sub

    Private Sub TB_BoxQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TB_BoxQty.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "," Then
            e.Handled = True
        End If

    End Sub

    Private Sub TB_MagazineBarcode_MouseCaptureChanged(sender As Object, e As EventArgs) Handles TB_MagazineBarcode.MouseCaptureChanged

    End Sub
End Class