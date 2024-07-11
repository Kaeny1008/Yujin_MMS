Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Production_Information_WS

    Public orderIndex As String

    Private Sub frm_Production_Information_SMD_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        Load_Magazine_Information()
        Load_Fault_Information()
        Load_WorkingTime()

    End Sub

    Private Sub Grid_Setting()

        With Grid_MagazineList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 8
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = False
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Cols(2).DataType = GetType(DateTime)
            .Cols(2).Format = "yyyy-MM-dd HH:mm:ss"
            .Cols(3).DataType = GetType(DateTime)
            .Cols(3).Format = "yyyy-MM-dd HH:mm:ss"
            .Cols(5).DataType = GetType(Integer)
            .Cols(5).Format = "#,##0"
            .Cols(6).DataType = GetType(Integer)
            .Cols(6).Format = "#,##0"
            .Cols(7).DataType = GetType(Integer)
            .Cols(7).Format = "#,##0"
            .Cols(1).Visible = False
        End With

        Grid_MagazineList(0, 0) = "No"
        Grid_MagazineList(0, 1) = "History Index"
        Grid_MagazineList(0, 2) = "시작시간"
        Grid_MagazineList(0, 3) = "종료시간"
        Grid_MagazineList(0, 4) = "Inspector"
        Grid_MagazineList(0, 5) = "시작수량"
        Grid_MagazineList(0, 6) = "불량수량"
        Grid_MagazineList(0, 7) = "종료수량(생산수량)"

        For i = 0 To Grid_MagazineList.Cols.Count - 1
            Grid_MagazineList.Cols(i).StyleNew.TextAlign = TextAlignEnum.CenterCenter
        Next

        Grid_MagazineList.AutoSizeCols()

        With C1FlexGrid1
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 8
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = False
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Cols(2).DataType = GetType(DateTime)
            .Cols(2).Format = "yyyy-MM-dd HH:mm:ss"
            .Cols(1).Visible = False
        End With

        C1FlexGrid1(0, 0) = "No"
        C1FlexGrid1(0, 1) = "History Index"
        C1FlexGrid1(0, 2) = "검사시간"
        C1FlexGrid1(0, 3) = "Board No."
        C1FlexGrid1(0, 4) = "불량구분"
        C1FlexGrid1(0, 5) = "불량명"
        C1FlexGrid1(0, 6) = "Ref(Location)"
        C1FlexGrid1(0, 7) = "검사자"

        For i = 0 To C1FlexGrid1.Cols.Count - 1
            C1FlexGrid1.Cols(i).StyleNew.TextAlign = TextAlignEnum.CenterCenter
        Next

        C1FlexGrid1.AutoSizeCols()

    End Sub

    Private Sub Load_Magazine_Information()

        Thread_LoadingFormStart(Me)

        Grid_MagazineList.Redraw = False
        Grid_MagazineList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_order_status(4"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & orderIndex & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_MagazineList.Rows.Count
            insert_String += vbTab & sqlDR("history_index")
            insert_String += vbTab & sqlDR("ws_start_date")
            insert_String += vbTab & sqlDR("ws_end_date")
            insert_String += vbTab & sqlDR("ws_inspector")
            insert_String += vbTab & sqlDR("start_quantity")
            insert_String += vbTab & sqlDR("fault_quantity")
            insert_String += vbTab & sqlDR("end_quantity")

            Grid_MagazineList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_MagazineList.AutoSizeCols()
        Grid_MagazineList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_Fault_Information()

        Thread_LoadingFormStart(Me)

        C1FlexGrid1.Redraw = False
        C1FlexGrid1.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_order_status(5"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & orderIndex & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = C1FlexGrid1.Rows.Count
            insert_String += vbTab & sqlDR("history_index")
            insert_String += vbTab & sqlDR("write_date")
            insert_String += vbTab & sqlDR("board_no")
            insert_String += vbTab & sqlDR("defect_classification")
            insert_String += vbTab & sqlDR("defect_name")
            insert_String += vbTab & sqlDR("ref")
            insert_String += vbTab & sqlDR("ws_inspector")

            C1FlexGrid1.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        C1FlexGrid1.AutoSizeCols()
        C1FlexGrid1.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_WorkingTime()

        Thread_LoadingFormStart(Me)

        DBConnect()

        Dim strSQL As String = "call sp_mms_order_status(6"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & orderIndex & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            If Not sqlDR("working_status") = "Running" Then
                TB_Top_WorkingTime.Text = Format(DateDiff(DateInterval.Minute, sqlDR("start_date"), sqlDR("end_date")) / 60, "0.00")
                TB_Top_ppm.Text = Format(sqlDR("fault_quantity") / sqlDR("end_quantity") * 1000000, "#,##0")
            End If
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_MagazineList_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_MagazineList.MouseClick

        Dim selRow As Integer = Grid_MagazineList.MouseRow

        If selRow < 1 Then Exit Sub

        Dim historyIndex As String = Grid_MagazineList(selRow, 1)

        For i = 1 To C1FlexGrid1.Rows.Count - 1
            If C1FlexGrid1(i, 1) = historyIndex Then
                C1FlexGrid1.Rows(i).StyleNew.BackColor = Color.LightBlue
            Else
                C1FlexGrid1.Rows(i).StyleNew.BackColor = Color.White
            End If
        Next

    End Sub
End Class