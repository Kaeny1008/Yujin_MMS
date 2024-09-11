Imports C1.Win.C1FlexGrid
Imports MySqlConnector

Public Class frm_Production_BOM

    Public orderIndex As String

    Private Sub frm_Production_BOM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GridSetting()

        Load_BOM()

    End Sub

    Private Sub GridSetting()

        With Grid_BOM
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 5
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .SelectionMode = SelectionModeEnum.Default
            .Cols(4).DataType = GetType(Integer)
            .Cols(4).Format = "#,##0"
        End With

        Grid_BOM(0, 0) = "No"
        Grid_BOM(0, 1) = "Part Code"
        Grid_BOM(0, 2) = "Specification"
        Grid_BOM(0, 3) = "Ref(Location)"
        Grid_BOM(0, 4) = "사용수량"
        Grid_BOM.AutoSizeCols()

    End Sub

    Private Sub Load_BOM()

        Grid_BOM.Redraw = False
        Grid_BOM.Rows.Count = 1

        DBConnect()

        Dim fineName As String = String.Empty

        Dim strSQL As String = "call sp_mms_wave_selective_production(16"
        strSQL += ", '" & orderIndex & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = Grid_BOM.Rows.Count
            insertString += vbTab & sqlDR("part_no")
            insertString += vbTab & sqlDR("part_specification")
            insertString += vbTab & sqlDR("ref")
            insertString += vbTab & sqlDR("use_count")
            Grid_BOM.AddItem(insertString )
        Loop
        sqlDR.Close()

        DBClose()

        Grid_BOM.AutoSizeCols()
        Grid_BOM.Redraw = True

    End Sub
End Class