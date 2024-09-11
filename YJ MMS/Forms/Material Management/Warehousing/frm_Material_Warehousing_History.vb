Imports C1.Win.C1FlexGrid
Imports MySqlConnector

Public Class frm_Material_Warehousing_History
    Private Sub frm_Material_Warehousing_History_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DTP_Start.Value = Format(Now, "yyyy-MM-01")
        DTP_End.Value = Format(Now, "yyyy-MM-dd")
        Grid_Setting()

        Load_CustomerList()

    End Sub

    Private Sub Grid_Setting()

        Grid_History.Redraw = False

        With Grid_History
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 25
            '.Cols.Count = (DTP_End.Value.Day - DTP_Start.Value.Day) + 1 + 6
            .Cols.Count = DateDiff(DateInterval.Day, DTP_Start.Value, DTP_End.Value) + 1 + 6
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            '.Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            '.ExtendLastCol = True
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .Cols.Frozen = 5
        End With

        Grid_History(0, 0) = "No"
        Grid_History(0, 1) = "자재코드"
        Grid_History(0, 2) = "타입"
        Grid_History(0, 3) = "사양"
        Grid_History(0, 4) = "사/도급"
        Grid_History(0, 5) = "총 입고수량"

        Dim start_day As DateTime = DTP_Start.Value

        For i = 6 To Grid_History.Cols.Count - 1
            If Weekday(start_day) = 7 Then
                Grid_History.Cols(i).StyleFixedNew.ForeColor = Color.Blue
            ElseIf Weekday(start_day) = 1 Then
                Grid_History.Cols(i).StyleFixedNew.ForeColor = Color.Red
            End If
            Grid_History(0, i) = Format(start_day, "MM-dd")
            start_day = DateAdd(DateInterval.Day, 1, start_day)
        Next

        Grid_History.AutoSizeCols()

        Grid_History.Redraw = True

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

        If CB_CustomerName.Text = String.Empty Then
            MSG_Information(Me, "고객사를 먼저 선택하여 주십시오.")
            Exit Sub
        End If

        Thread_LoadingFormStart(Me)

        Grid_Setting()

        Load_ItemList()
        Load_Warehousing()

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_ItemList()

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_warehousing_history(0"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ", '" & Format(DTP_Start.Value, "yyyy-MM-dd 00:00:00") & "'"
        strSQL += ", '" & Format(DTP_End.Value, "yyyy-MM-dd hh:mm:ss") & "'"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_History.Rows.Count & vbTab &
                                          sqlDR("part_code") & vbTab &
                                          sqlDR("part_type") & vbTab &
                                          sqlDR("part_specification") & vbTab &
                                          sqlDR("part_category")
            Grid_History.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_History.AutoSizeCols()
        Grid_History.Redraw = True

    End Sub

    Private Sub Load_Warehousing()

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_warehousing_history(1"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ", '" & Format(DTP_Start.Value, "yyyy-MM-dd 00:00:00") & "'"
        strSQL += ", '" & Format(DTP_End.Value, "yyyy-MM-dd hh:mm:ss") & "'"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim itemRow As Integer = Grid_History.FindRow(sqlDR("part_code"), 1, 1, True)
            If itemRow > 0 Then
                Dim itemDate As String = Format(CDate(sqlDR("write_date")), "MM-dd")
                Dim itemCol As Integer = 0
                Dim itemTotal As Integer = CInt(Grid_History(itemRow, 5)) + sqlDR("total_qty")
                For i = 6 To Grid_History.Cols.Count - 1
                    If Grid_History(0, i) = itemDate Then
                        itemCol = i
                        Exit For
                    End If
                Next

                Grid_History(itemRow, itemCol) = Format(sqlDR("total_qty"), "#,##0")
                Grid_History(itemRow, 5) = Format(itemTotal, "#,##0")
            End If
        Loop
        sqlDR.Close()

        DBClose()

        Grid_History.AutoSizeCols()
        Grid_History.Redraw = True

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub
End Class