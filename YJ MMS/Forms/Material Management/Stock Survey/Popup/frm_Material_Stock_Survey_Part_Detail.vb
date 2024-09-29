Imports C1.Win.C1FlexGrid

Public Class frm_Material_Stock_Survey_Part_Detail
    Private Sub frm_Material_Stock_Survey_Part_Detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

    End Sub

    Private Sub Grid_Setting()

        With Grid_List
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 9
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .DrawMode = DrawModeEnum.Normal
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .Cols(1).Visible = False
            .Cols(6).DataType = GetType(Double)
            .Cols(6).Format = "#,##0"
            .Cols(8).DataType = GetType(DateTime)
            .Cols(8).Format = "yyyy-MM-dd HH:mm:ss"
        End With

        Grid_List(0, 0) = "No"
        Grid_List(0, 1) = "Action Content No"
        Grid_List(0, 2) = "Part Code"
        Grid_List(0, 3) = "Vendor"
        Grid_List(0, 4) = "Part No."
        Grid_List(0, 5) = "Lot No."
        Grid_List(0, 6) = "Qty"
        Grid_List(0, 7) = "Checker"
        Grid_List(0, 8) = "Check Date"
        Grid_List.AutoSizeCols()

    End Sub
End Class