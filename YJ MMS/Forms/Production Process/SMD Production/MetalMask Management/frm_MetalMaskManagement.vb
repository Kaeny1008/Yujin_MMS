Imports System.IO
Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_MetalMaskManagement
    Private Sub MaskManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GridSetting()

    End Sub

    Private Sub GridSetting()

        With Grid_List
            .AllowEditing = False
            .AllowFiltering = True
            .AutoClipboard = True
            .AllowSorting = AllowSortingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 15
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            Grid_List(0, 0) = "No"
            Grid_List(0, 1) = "사용여부"
            Grid_List(0, 2) = "입고검사 결과"
            Grid_List(0, 3) = "관리번호"
            Grid_List(0, 4) = "고객사"
            Grid_List(0, 5) = "모델명"
            Grid_List(0, 6) = "작업면"
            Grid_List(0, 7) = "Rev."
            Grid_List(0, 8) = "두께"
            Grid_List(0, 9) = "제작일자"
            Grid_List(0, 10) = "입고일자"
            Grid_List(0, 11) = "제작업체"
            Grid_List(0, 12) = "사이즈"
            Grid_List(0, 13) = "사용횟수"
            Grid_List(0, 14) = "비고"
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .Cols(Grid_List.Cols.Count - 1).TextAlign = TextAlignEnum.LeftCenter
            .AutoSizeCols()
            .ExtendLastCol = True
        End With

    End Sub

    Private Sub Btn_NewMask_Click(sender As Object, e As EventArgs) Handles Btn_NewMask.Click

        Dim maskSN As String = NumberConvert(CInt(Format(Now, "yy"))) &
            NumberConvert(CInt(Format(Now, "MM"))) &
            NumberConvert(CInt(Format(Now, "dd")))
        maskSN = LastMaskSN(maskSN)

        frm_MetalMask_Register.Rb_Use.Checked = True
        frm_MetalMask_Register.Rb_Not_Use.Enabled = False
        frm_MetalMask_Register.Text = "신규 마스크 등록"
        frm_MetalMask_Register.Tb_MaskSN.Text = maskSN
        frm_MetalMask_Register.Btn_Save.Text = "저장"
        frm_MetalMask_Register.Nud_UsingCount.Enabled = True
        frm_MetalMask_Register.Label7.Visible = False

        If frm_MetalMask_Register.ShowDialog() = DialogResult.Yes Then
            MsgBox("신규 마스크 저장완료.", MsgBoxStyle.Information, msg_form)
            BTN_Search_Click(Nothing, Nothing)
        End If

    End Sub

    Private Function LastMaskSN(ByVal nowDateConverter As String) As String

        LastMaskSN = "MMAAA0000"

        DBConnect()

        Dim strSQL As String = "select mask_sn from tb_mmms_metal_mask_list"
        strSQL += " where mask_sn like 'MM" & nowDateConverter & "%'"
        strSQL += " order by mask_sn desc limit 1"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            LastMaskSN = sqlDR("mask_sn")
        Loop
        sqlDR.Close()

        DBClose()

        LastMaskSN = "MM" & nowDateConverter & Format(CInt(LastMaskSN.Substring(5, 4)) + 1, "0000")


        Return LastMaskSN

    End Function

    Private Sub Cb_customerName_DropDown(sender As Object, e As EventArgs) Handles CB_CustomerName.DropDown

        Dim cb_old_string As String = CB_CustomerName.Text

        CB_CustomerName.Items.Clear()

        DBConnect()

        Dim strSQL As String = "select customer_name from tb_customer_list"
        strSQL += " order by customer_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            CB_CustomerName.Items.Add(sqlDR("customer_name"))
        Loop
        sqlDR.Close()

        DBClose()

        CB_CustomerName.Text = cb_old_string

    End Sub

    Private Sub Cb_customerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_CustomerName.SelectedIndexChanged

        TB_CustomerCode.Text = String.Empty

        DBConnect()

        Dim strSQL As String = "select customer_code from tb_customer_list"
        strSQL += " where customer_name = '" & CB_CustomerName.Text & "'"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_CustomerCode.Text = sqlDR("customer_code")
        Loop
        sqlDR.Close()

        DBClose()

        TB_ModelCode.Text = String.Empty
        CB_ModelName.SelectedIndex = -1
        CB_WorkSide.SelectedIndex = -1
        Grid_List.Rows.Count = 1

    End Sub

    Private Sub Cb_modelName_DropDown(sender As Object, e As EventArgs) Handles CB_ModelName.DropDown


        Dim cb_old_string As String = CB_ModelName.Text

        CB_ModelName.Items.Clear()

        DBConnect()

        Dim strSQL As String = "select item_code from tb_model_list"
        strSQL += " where customer_code = '" & TB_CustomerCode.Text & "'"
        strSQL += " order by item_code"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            CB_ModelName.Items.Add(sqlDR("item_code"))
        Loop
        sqlDR.Close()

        DBClose()

        CB_ModelName.Text = cb_old_string

    End Sub

    Private Sub Cb_modelName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_ModelName.SelectedIndexChanged

        TB_ModelCode.Text = String.Empty

        DBConnect()

        Dim strSQL As String = "select model_code from tb_model_list"
        strSQL += " where item_code = '" & CB_ModelName.Text & "'"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_ModelCode.Text = sqlDR("model_code")
        Loop
        sqlDR.Close()

        DBClose()

        CB_WorkSide.SelectedIndex = -1
        Grid_List.Rows.Count = 1

    End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Grid_List.Redraw = False
        Grid_List.Rows.Count = 1
        DBConnect()

        Dim strSQL As String = "call sp_mmms_metalmask_list(0"
        strSQL += ",'" & TB_CustomerCode.Text & "'"
        strSQL += ",'" & TB_ModelCode.Text & "'"
        strSQL += ",'" & CB_WorkSide.Text & "'"
        strSQL += ",'" & TB_MaskSN.Text & "'"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim usable As String = "O"
            If sqlDR("mask_usable") = "No" Then usable = "X"
            Dim insertString As String = Grid_List.Rows.Count & vbTab &
                usable & vbTab &
                sqlDR("first_unique_note") & vbTab &
                sqlDR("mask_sn") & vbTab &
                sqlDR("customer_name") & vbTab &
                sqlDR("item_code") & vbTab &
                sqlDR("work_side") & vbTab &
                sqlDR("revision") & vbTab &
                sqlDR("thickness") & vbTab &
                sqlDR("making_date") & vbTab &
                sqlDR("in_date") & vbTab &
                sqlDR("making_company") & vbTab &
                sqlDR("wh_size") & vbTab &
                Format(sqlDR("using_count"), "#,##0") & vbTab &
                sqlDR("mask_note")
            Grid_List.AddItem(insertString)
        Loop
        sqlDR.Close()

        DBClose()
        Grid_List.AutoSizeCols()
        Grid_List.AutoSizeRows(1, 0, Grid_List.Rows.Count - 1, Grid_List.Cols.Count - 1, 0, AutoSizeFlags.None)
        Grid_List.Redraw = True

    End Sub

    Private Sub Tb_MaskSN_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_MaskSN.KeyDown

        If e.KeyCode = 13 Then
            BTN_Search_Click(Nothing, Nothing)
            TB_MaskSN.SelectAll()
        End If

    End Sub

    Private Sub Tb_MaskSN_GotFocus(sender As Object, e As EventArgs) Handles TB_MaskSN.GotFocus

        TB_MaskSN.SelectAll()

    End Sub

    Private Sub Tb_MaskSN_MouseClick(sender As Object, e As MouseEventArgs) Handles TB_MaskSN.MouseClick

        TB_MaskSN.SelectAll()

    End Sub

    Private Sub Cms_MaskEdit_Click(sender As Object, e As EventArgs) Handles Cms_MaskEdit.Click

        Dim maskSN As String = Grid_List(Grid_List.Row, 3)

        frm_MetalMask_Register.Rb_Not_Use.Enabled = False
        frm_MetalMask_Register.Text = "마스크 데이터 수정"
        frm_MetalMask_Register.Tb_MaskSN.Text = maskSN
        frm_MetalMask_Register.Btn_Save.Text = "수정"

        If frm_MetalMask_Register.ShowDialog() = DialogResult.Yes Then
            MsgBox("마스크 데이터 수정완료.", MsgBoxStyle.Information, msg_form)
            BTN_Search_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub Grid_MASK_LIST_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_List.MouseClick

        Grid_List.Row = Grid_List.MouseRow

        If e.Button = MouseButtons.Right And Grid_List.Row > 0 Then
            If Grid_List(Grid_List.Row, 1) = "O" Then
                Cms_MaskEdit.Enabled = True
                Cms_MaskClose.Enabled = True
                Cms_MaskClose_Cancel.Enabled = False
            Else
                Cms_MaskEdit.Enabled = False
                Cms_MaskClose.Enabled = False
                Cms_MaskClose_Cancel.Enabled = True
            End If
            Grid_Menu.Show(Grid_List, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub Cms_MaskClose_Click(sender As Object, e As EventArgs) Handles Cms_MaskClose.Click

        Dim maskSN As String = Grid_List(Grid_List.Row, 3)

        frm_MetalMask_Close.Tb_MaskSN.Text = maskSN

        If frm_MetalMask_Close.ShowDialog() = DialogResult.Yes Then
            MsgBox("마스크 폐기등록 완료.", MsgBoxStyle.Information, msg_form)
            BTN_Search_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub Cms_MaskDelete_Click(sender As Object, e As EventArgs) Handles Cms_MaskDelete.Click

        Dim maskSN As String = Grid_List(Grid_List.Row, 3)

        If MsgBox("중요!!!" & vbCrLf & "삭제하면 데이터를 복구할 수 없습니다." & vbCrLf & "삭제 하시겠습니까?",
                  MsgBoxStyle.Information + MsgBoxStyle.YesNo,
                  msg_form) = MsgBoxResult.No Then Exit Sub

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            strSQL = "delete from tb_mmms_metal_mask_list"
            strSQL += " where mask_sn = '" & maskSN & "';"
            strSQL += "delete from tb_mmms_metal_mask_history"
            strSQL += " where mask_sn = '" & maskSN & "';"
            strSQL += "delete from tb_mmms_metal_mask_close"
            strSQL += " where mask_sn = '" & maskSN & "';"

            If Not strSQL = String.Empty Then
                sqlCmd = New MySqlCommand(strSQL, dbConnection1)
                sqlCmd.Transaction = sqlTran
                sqlCmd.ExecuteNonQuery()

                sqlTran.Commit()
            End If
        Catch ex As MySqlException
            sqlTran.Rollback()
            MsgBox(ex.Message, MsgBoxStyle.Critical, msg_form)
        End Try

        DBClose()

        MsgBox("삭제 되었습니다.", MsgBoxStyle.Information, msg_form)

        BTN_Search_Click(Nothing, Nothing)

    End Sub

    Private Sub Cms_MaskClose_Cancel_Click(sender As Object, e As EventArgs) Handles Cms_MaskClose_Cancel.Click

        Dim maskSN As String = Grid_List(Grid_List.Row, 3)

        If MsgBox("폐기된 정보를 지우고 사용항목으로 변경 하시겠습니까?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, msg_form) = MsgBoxResult.No Then Exit Sub

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            Dim write_date As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            strSQL = "delete from tb_mmms_metal_mask_close"
            strSQL += " where mask_sn = '" & maskSN & "';"

            strSQL += "delete from tb_mmms_metal_mask_history"
            strSQL += " where mask_sn = '" & maskSN & "'"
            strSQL += " and WRITE_OPTIOn = 'Event'"
            strSQL += " and UNIQUE_NOTE = '폐기 등록 되었습니다.';"

            strSQL += "update tb_mmms_metal_mask_list set mask_usable = 'Yes'"
            strSQL += " where mask_sn = '" & maskSN & "';"

            If Not strSQL = String.Empty Then
                sqlCmd = New MySqlCommand(strSQL, dbConnection1)
                sqlCmd.Transaction = sqlTran
                sqlCmd.ExecuteNonQuery()

                sqlTran.Commit()
            End If
        Catch ex As MySqlException
            sqlTran.Rollback()
            MsgBox(ex.Message, MsgBoxStyle.Critical, msg_form)
        End Try

        DBClose()

        MsgBox("폐기 정보가 삭제 되었습니다.", MsgBoxStyle.Information, msg_form)
        BTN_Search_Click(Nothing, Nothing)

    End Sub

    Private Sub Cms_History_Click(sender As Object, e As EventArgs) Handles Cms_History.Click

        If Not frm_MetalMaskHistory.Visible Then frm_MetalMaskHistory.Show()
        frm_MetalMaskHistory.Focus()

        frm_MetalMaskHistory.Tb_MaskSN.Text = Grid_List(Grid_List.Row, 3)
        frm_MetalMaskHistory.BTN_Search_Click(Nothing, Nothing)
        frm_MetalMaskHistory.Focus()

    End Sub

    Private Sub Btn_PrinterSetting_Click(sender As Object, e As EventArgs) Handles Btn_PrinterSetting.Click

    End Sub
End Class