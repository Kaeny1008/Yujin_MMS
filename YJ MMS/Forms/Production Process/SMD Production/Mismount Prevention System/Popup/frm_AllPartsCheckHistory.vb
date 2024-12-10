Imports C1.Win.C1FlexGrid
Imports MySqlConnector

Public Class frm_AllPartsCheckHistory

    Public checkCode As String

    Private Sub AllPartsCheckHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GridSetting()

        DataLoad()

    End Sub

    Private Sub GridSetting()

        With Grid_historyList
            .Redraw = False
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.Both
            .AllowDragging = AllowDraggingEnum.None
            .AllowResizing = AllowResizingEnum.None
            .KeyActionEnter = KeyActionEnum.MoveDown
            .KeyActionTab = KeyActionEnum.MoveAcross
            .Cols.Count = 9
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .Rows(0).Height = 30
            .Rows.DefaultSize = 20
            Grid_historyList(0, 0) = "No"
            Grid_historyList(0, 1) = "작업일자"
            Grid_historyList(0, 2) = "Machine No."
            Grid_historyList(0, 3) = "Feeder No."
            Grid_historyList(0, 4) = "Part Code"
            Grid_historyList(0, 5) = "Part No."
            Grid_historyList(0, 6) = "Lot No."
            Grid_historyList(0, 7) = "수량"
            Grid_historyList(0, 8) = "작업자"
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            '.Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter '비고란은 좌측 정렬
            .ExtendLastCol = False '마지막 열 확장
            .AutoSizeCols()
            .ShowCursor = True
            .Cols.Frozen = 0
            .FocusRect = FocusRectEnum.Light
            .Redraw = True
        End With

    End Sub

    Private Sub DataLoad()

        Grid_historyList.Redraw = False
        Grid_historyList.Rows.Count = 1

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mmps_history(2"
        strSQL += ",null"
        strSQL += ",null"
        strSQL += ",null"
        strSQL += ",null"
        strSQL += ",null"
        strSQL += ",null"
        strSQL += ",null"
        strSQL += ",'" & checkCode & "'"
        strSQL += ",null"
        strSQL += ",null)"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert As String = String.Empty
            Dim insertQty As String = String.Empty
            If IsNumeric(sqlDR("check_qty")) Then
                insertQty = Format(CDbl(sqlDR("check_qty")), "#,##0")
            Else
                insertQty = sqlDR("check_qty")
            End If
            insert = Grid_historyList.Rows.Count &
                vbTab & Format(sqlDR("check_date"), "yyyy-MM-dd HH:mm:ss") &
                vbTab & sqlDR("machine_no") &
                vbTab & sqlDR("feeder_no") &
                vbTab & sqlDR("check_part_code") &
                vbTab & sqlDR("check_part_no") &
                vbTab & sqlDR("check_lot_no") &
                vbTab & insertQty &
                vbTab & sqlDR("user_name")
            Grid_historyList.AddItem(insert)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_historyList.AutoSizeCols()
        Grid_historyList.Redraw = True

    End Sub
End Class