Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_MetalMaskHistory
    Private Sub MaskHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized

        GridSetting()

    End Sub

    Private Sub GridSetting()

        With Grid_MASK_LIST
            .AllowEditing = False
            .AllowFiltering = True
            .AutoClipboard = True
            .AllowSorting = AllowSortingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 11
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            Grid_MASK_LIST(0, 0) = "No"
            Grid_MASK_LIST(0, 1) = "구분"
            Grid_MASK_LIST(0, 2) = "사용일자"
            Grid_MASK_LIST(0, 3) = "사용횟수"
            Grid_MASK_LIST(0, 4) = "누계(일)"
            Grid_MASK_LIST(0, 5) = "누계(전체)"
            Grid_MASK_LIST(0, 6) = "검사결과"
            Grid_MASK_LIST(0, 7) = "확인" & vbCrLf & "[담당자]"
            Grid_MASK_LIST(0, 8) = "작업공장"
            Grid_MASK_LIST(0, 9) = "작업라인"
            Grid_MASK_LIST(0, 10) = "비고"
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .Cols(Grid_MASK_LIST.Cols.Count - 1).TextAlign = TextAlignEnum.LeftCenter
            .AutoSizeCols()
            .ExtendLastCol = True
        End With

    End Sub

    Public Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        If Tb_MaskSN.Text = String.Empty Then
            MsgBox("Metal Mask Serial No를 먼저 입력하여 주십시오.", MsgBoxStyle.Information, msg_form)
            Tb_MaskSN.Focus()
            Tb_MaskSN.SelectAll()
            Exit Sub
        End If

        Control_Init()

        MaskInfo_Load()
        MaskClose_Load()
        MaskHistory_Load()

        If Tb_ModelCode.Text = String.Empty Then
            MsgBox("조회된 데이터가 없습니다.", MsgBoxStyle.Information, msg_form)
        End If

    End Sub

    Private Sub Control_Init()

        Tb_CustomerCode.Text = String.Empty
        Tb_CustomerName.Text = String.Empty
        Tb_ModelCode.Text = String.Empty
        Tb_ModelName.Text = String.Empty
        Tb_WorkSide.Text = String.Empty
        Tb_Revision.Text = String.Empty
        Tb_Thickness.Text = String.Empty
        Tb_MakingDate.Text = String.Empty
        Tb_InDate.Text = String.Empty
        TB_MakingCompany.Text = String.Empty
        Tb_MaskSize.Text = String.Empty
        Tb_UsingCount.Text = String.Empty
        Tb_Note.Text = String.Empty
        Tb_MaskCloseReason.Text = String.Empty

        Grid_MASK_LIST.Rows.Count = 1

    End Sub

    Private Sub MaskInfo_Load()

        DBConnect()

        Dim strSQL As String = "call sp_mmms_metalmask_list(1, null, null, null, '" & Tb_MaskSN.Text & "');"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            If sqlDR("mask_usable") = "Yes" Then
                Rb_Use.Checked = True
            Else
                Rb_Not_Use.Checked = True
            End If
            Tb_CustomerCode.Text = sqlDR("customer_code")
            Tb_CustomerName.Text = sqlDR("customer_name")
            Tb_ModelCode.Text = sqlDR("model_code")
            Tb_ModelName.Text = sqlDR("item_code")
            Tb_WorkSide.Text = sqlDR("work_side")
            Tb_Revision.Text = sqlDR("revision")
            Tb_Thickness.Text = sqlDR("thickness")
            Tb_MakingDate.Text = Format(sqlDR("making_date"), "yyyy-MM-dd")
            Tb_InDate.Text = Format(sqlDR("in_date"), "yyyy-MM-dd")
            TB_MakingCompany.Text = sqlDR("making_company")
            Tb_MaskSize.Text = sqlDR("wh_size")
            Tb_UsingCount.Text = Format(sqlDR("using_count"), "#,##0")
            Tb_Note.Text = sqlDR("mask_note")
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub MaskClose_Load()

        DBConnect()

        Dim strSQL As String = "call sp_mmms_metalmask_list(2, null, null, null, '" & Tb_MaskSN.Text & "');"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Tb_MaskCloseReason.Text = sqlDR("close_reason")
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub MaskHistory_Load()

        Dim startDate As String = Format(DateTimePicker1.Value, "yyyy-MM-dd 00:00:00")
        Dim endDate As String = Format(DateTimePicker2.Value, "yyyy-MM-dd 23:59:59")
        Dim searchSelect As String = "All"
        Dim searchOption As String = String.Empty

        If RadioButton2.Checked Then
            searchOption = "Working"
        ElseIf RadioButton3.Checked Then
            searchOption = "Working2"
        ElseIf RadioButton1.Checked Then
            searchOption = "All"
        End If

        If Rb_Month.Checked Then
            searchSelect = "Month"
        ElseIf Rb_Select.Checked Then
            searchSelect = "Select"
        End If

        Grid_MASK_LIST.Redraw = False

        DBConnect()

        Dim strSQL As String = "call sp_mmms_metalmask_history('" & Tb_MaskSN.Text & "'" &
            ", '" & startDate & "'" &
            ", '" & endDate & "'" &
            ", '" & searchSelect & "'" &
            ", '" & searchOption & "')"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertSTR As String = Grid_MASK_LIST.Rows.Count & vbTab &
                sqlDR("gubun") & vbTab &
                Format(sqlDR("write_date"), "yyyy-MM-dd HH:mm:ss") & vbTab &
                Format(sqlDR("use_count"), "#,##0") & vbTab &
                Format(sqlDR("daily_use_count"), "#,##0") & vbTab &
                Format(sqlDR("total_use_count"), "#,##0") & vbTab &
                sqlDR("unique_note") & vbTab &
                sqlDR("write_id") & vbTab &
                sqlDR("work_factory") & vbTab &
                sqlDR("work_line") & vbTab &
                sqlDR("mask_note")
            Grid_MASK_LIST.AddItem(insertSTR)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_MASK_LIST.AutoSizeCols()
        Grid_MASK_LIST.AutoSizeRows(1, 0, Grid_MASK_LIST.Rows.Count - 1, Grid_MASK_LIST.Cols.Count - 1, 0, AutoSizeFlags.None)
        Grid_MASK_LIST.Redraw = True

    End Sub

    Private Sub Btn_Print_Click(sender As Object, e As EventArgs) Handles Btn_Print.Click



    End Sub

    Private Sub Rb_CheckedChanged(sender As Object, e As EventArgs) Handles Rb_All.CheckedChanged,
                                                                            Rb_Month.CheckedChanged,
                                                                            Rb_Select.CheckedChanged

        If Rb_Select.Checked Then
            DateTimePicker1.Enabled = True
            DateTimePicker2.Enabled = True
        Else
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If

    End Sub

    Private Sub Tb_MaskSN_KeyDown(sender As Object, e As KeyEventArgs) Handles Tb_MaskSN.KeyDown

        If e.KeyCode = 13 Then
            BTN_Search_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub Tb_MaskSN_GotFocus(sender As Object, e As EventArgs) Handles Tb_MaskSN.GotFocus

        Tb_MaskSN.SelectAll()

    End Sub

    Private Sub Tb_MaskSN_MouseClick(sender As Object, e As MouseEventArgs) Handles Tb_MaskSN.MouseClick

        Tb_MaskSN.SelectAll()

    End Sub
End Class