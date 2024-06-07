Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_MaterialCode_Change
    Private Sub frm_MaterialCode_Change_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

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
            .AllowMergingFixed = AllowMergingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 13
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .Cols(12).Visible = False
        End With

        Grid_History(0, 0) = "No."
        Grid_History(0, 1) = "전환일자"
        Grid_History(0, 2) = "전환 작업자"
        Grid_History(0, 3) = "고객사명"
        Grid_History(0, 4) = "고객사코드"
        Grid_History(0, 5) = "변경전 Code"
        Grid_History(0, 6) = "Vendor"
        Grid_History(0, 7) = "Vendor Code"
        Grid_History(0, 8) = "Lot No."
        Grid_History(0, 9) = "전환수량"
        Grid_History(0, 10) = "변경후 Code"
        Grid_History(0, 11) = "변경 사유"
        Grid_History(0, 12) = "입고일자"

    End Sub

    Private Sub Load_CustomerList()

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

    End Sub

    Private Sub BTN_Change_Click(sender As Object, e As EventArgs) Handles BTN_Change.Click

        If Not frm_CodeChange.Visible Then frm_CodeChange.Show()
        frm_CodeChange.Focus()

    End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        If TB_CustomerCode.Text = String.Empty Then
            MessageBox.Show("고객사를 먼저 선택하여 주십시오.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Thread_LoadingFormStart()

        Grid_History.Redraw = False
        Grid_History.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_code_change(2"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = Grid_History.Rows.Count & vbTab &
                Format(sqlDR("write_date"), "yyyy-MM-dd HH:mm:ss") & vbTab &
                sqlDR("writer") & vbTab &
                sqlDR("customer_name") & vbTab &
                sqlDR("customer_code") & vbTab &
                sqlDR("part_code") & vbTab &
                sqlDR("part_vendor") & vbTab &
                sqlDR("part_no") & vbTab &
                sqlDR("part_lot_no") & vbTab &
                Format(sqlDR("history_qty"), "#,##0") & vbTab &
                sqlDR("change_part_code") & vbTab &
                sqlDR("change_reason") & vbTab &
                Format(sqlDR("write_date"), "yyyy-MM-dd HH:mm:ss")

            GridWriteText(insertString, Me, Grid_History, Color.Black)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_History.AutoSizeCols()
        Grid_History.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_History_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_History.MouseClick

        Dim selRow As Integer = Grid_History.MouseRow

        If e.Button = MouseButtons.Right And selRow > 0 Then
            Grid_History.Row = selRow
            CMS_Menu.Show(Grid_History, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub BTN_RePrint_Click(sender As Object, e As EventArgs) Handles BTN_RePrint.Click

        If MessageBox.Show("재발행 하시겠습니까?", msg_form, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Dim selRow As Integer = Grid_History.Row
        Material_PrintLabel(Grid_History(selRow, 10),
                            Grid_History(selRow, 7),
                            Grid_History(selRow, 8),
                            Grid_History(selRow, 9),
                            Grid_History(selRow, 6),
                            1,
                            CB_CustomerName.Text,
                            Format(CDate(Grid_History(selRow, 12)), "yyyy.MM.dd"),
                            False,
                            String.Empty,
                            0)

    End Sub
End Class