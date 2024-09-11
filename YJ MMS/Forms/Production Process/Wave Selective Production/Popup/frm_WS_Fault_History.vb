Imports C1.Win.C1FlexGrid
Imports MySqlConnector

Public Class frm_WS_Fault_History

    Public nowHistoryNo As String

    Private Sub frm_SMD_Fault_History_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        Load_FaultList()

    End Sub

    Private Sub Grid_Setting()

        With Grid_HistoryList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.Columns
            .AllowMergingFixed = AllowMergingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 13
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
            .Cols(5).DataType = GetType(DateTime)
            .Cols(5).Format = "yyyy-MM-dd HH:mm:ss"
            .Cols(7).DataType = GetType(DateTime)
            .Cols(7).Format = "yyyy-MM-dd HH:mm:ss"
            .Cols(10).DataType = GetType(DateTime)
            .Cols(10).Format = "yyyy-MM-dd HH:mm:ss"
        End With

        Grid_HistoryList(0, 0) = "No."
        Grid_HistoryList(0, 1) = "Board No."
        Grid_HistoryList(0, 2) = "구분"
        Grid_HistoryList(0, 3) = "불량명"
        Grid_HistoryList(0, 4) = "Ref(Location)"
        Grid_HistoryList(0, 5) = "검사일자"
        Grid_HistoryList(0, 6) = "검사자"
        Grid_HistoryList(0, 7) = "수리일자"
        Grid_HistoryList(0, 8) = "수리사"
        Grid_HistoryList(0, 9) = "수리방법"
        Grid_HistoryList(0, 10) = "재검일자"
        Grid_HistoryList(0, 11) = "재검자"
        Grid_HistoryList(0, 12) = "재검결과"

        For i = 0 To Grid_HistoryList.Cols.Count - 1
            Grid_HistoryList.Cols(i).StyleNew.TextAlign = TextAlignEnum.CenterCenter
        Next

        Grid_HistoryList.AutoSizeCols()

    End Sub

    Private Sub Load_FaultList()

        Thread_LoadingFormStart(Me)

        Grid_HistoryList.Redraw = False
        Grid_HistoryList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_ws_production_history(1"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ",'" & nowHistoryNo & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_HistoryList.Rows.Count
            insert_String += vbTab & sqlDR("board_no")
            insert_String += vbTab & sqlDR("defect_classification")
            insert_String += vbTab & sqlDR("defect_name")
            insert_String += vbTab & sqlDR("ref")
            insert_String += vbTab & sqlDR("write_date")
            insert_String += vbTab & sqlDR("ws_inspector")
            insert_String += vbTab & sqlDR("repair_date")
            insert_String += vbTab & sqlDR("repairman")
            insert_String += vbTab & sqlDR("repair_action")
            insert_String += vbTab & sqlDR("reinspect_date")
            insert_String += vbTab & sqlDR("reinspect_inspector")
            insert_String += vbTab & sqlDR("reinspect_result")

            Grid_HistoryList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_HistoryList.AutoSizeCols()
        Grid_HistoryList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub
End Class