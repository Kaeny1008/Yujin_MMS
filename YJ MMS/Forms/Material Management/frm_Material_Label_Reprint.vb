Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Material_Label_Reprint
    Private Sub frm_Material_Label_Reprint_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
            .Cols.Count = 7
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
        End With

        Grid_History(0, 0) = "No."
        Grid_History(0, 1) = "입고일자"
        Grid_History(0, 2) = "자재코드"
        Grid_History(0, 3) = "제조사"
        Grid_History(0, 4) = "품명"
        Grid_History(0, 5) = "로트넘버"
        Grid_History(0, 6) = "수량"

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

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart()

        Grid_History.Redraw = False
        Grid_History.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_label_reprint(0"
        strSQL += ",'" & TB_CustomerCode.Text & "'"
        strSQL += ",'" & TB_PartCode.Text & "'"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = Grid_History.Rows.Count & vbTab &
                Format(sqlDR("write_date"), "yyyy-MM-dd HH:mm:ss") & vbTab &
                sqlDR("part_code") & vbTab &
                sqlDR("part_vendor") & vbTab &
                sqlDR("part_no") & vbTab &
                sqlDR("part_lot_no") & vbTab &
                Format(sqlDR("part_qty"), "#,##0")
            Grid_History.AddItem(insertString)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_History.AutoSizeCols()
        Grid_History.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_History_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_History.MouseClick

        Dim selRow As Integer = Grid_History.MouseRow
        Grid_History.Row = selRow
        If e.Button = MouseButtons.Right And selRow > 0 Then
            CMS_Menu.Show(Grid_History, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub BTN_Reprint_Click(sender As Object, e As EventArgs) Handles BTN_Reprint.Click

        Dim selRow As Integer = Grid_History.Row

        Dim msgString As String = "입고일자 : " & Grid_History(selRow, 1) & vbCrLf &
            "자재코드 : " & Grid_History(selRow, 2) & vbCrLf &
            "제조사 : " & Grid_History(selRow, 3) & vbCrLf &
            "품명 : " & Grid_History(selRow, 4) & vbCrLf &
            "로트넘버 : " & Grid_History(selRow, 5) & vbCrLf &
            "수량 : " & Grid_History(selRow, 6)

        If MSG_Question(Me, msgString & vbCrLf & vbCrLf & "재발행 하시겠습니까?") = False Then Exit Sub

        Material_PrintLabel(Grid_History(selRow, 2),
                            Grid_History(selRow, 4),
                            Grid_History(selRow, 5),
                            Grid_History(selRow, 6),
                            Grid_History(selRow, 3),
                            1,
                            CB_CustomerName.Text,
                            Format(CDate(Grid_History(selRow, 1)), "yyyy.MM.dd"),
                            False,
                            String.Empty,
                            0)

    End Sub

    Private Sub TB_PartCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_PartCode.KeyDown

        If e.KeyCode = 13 And Not Trim(TB_PartCode.Text) = String.Empty Then
            BTN_Search_Click(Nothing, Nothing)
        End If

    End Sub
End Class