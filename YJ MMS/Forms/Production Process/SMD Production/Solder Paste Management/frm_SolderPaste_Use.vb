Imports C1.Win.C1FlexGrid

Public Class frm_SolderPaste_Use
    Private Sub frm_SolderPaste_Use_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GridSetting()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub GridSetting()

        With Grid_StockList
            .AllowEditing = False
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.None
            .Cols.Count = 6
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .SelectionMode = SelectionModeEnum.Default
        End With

        Grid_StockList(0, 0) = "No."
        Grid_StockList(0, 1) = "제조사"
        Grid_StockList(0, 2) = "제품명"
        Grid_StockList(0, 3) = "중량(g)"
        Grid_StockList(0, 4) = "유효기간"
        Grid_StockList(0, 5) = "Lot No.(Serial)"
        Grid_StockList.AutoSizeCols()

        With Grid_AgingList
            .AllowEditing = False
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            .Cols.Count = 10
            .Cols.Fixed = 1
            .Rows.Count = 2
            .Rows.Fixed = 2
            For i = 0 To .Cols.Count - 1
                .Cols(i).AllowMerging = True
            Next
            For i = 0 To .Rows.Count - 1
                .Rows(i).AllowMerging = True
            Next
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .SelectionMode = SelectionModeEnum.Default
            Dim rngM As CellRange = .GetCellRange(0, 0, 1, 0)
            rngM.Data = "No"
            rngM = .GetCellRange(0, 1, 1, 1)
            rngM.Data = "제조사"
            rngM = .GetCellRange(0, 2, 1, 2)
            rngM.Data = "제품명"
            rngM = .GetCellRange(0, 3, 1, 3)
            rngM.Data = "중량(g)"
            rngM = .GetCellRange(0, 4, 1, 4)
            rngM.Data = "유효기간"
            rngM = .GetCellRange(0, 5, 1, 5)
            rngM.Data = "Lot No.(Serial)"
            rngM = .GetCellRange(0, 6, 1, 8)
            rngM.Data = "시간"
            Grid_AgingList(1, 6) = "기준"
            Grid_AgingList(1, 7) = "시작"
            Grid_AgingList(1, 8) = "종료"
            rngM = .GetCellRange(0, 9, 1, 9)
            rngM.Data = "작업자"
            .AutoSizeCols()
        End With

        With Grid_UseList
            .AllowEditing = False
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            .Cols.Count = 9
            .Cols.Fixed = 1
            .Rows.Count = 2
            .Rows.Fixed = 2
            For i = 0 To .Cols.Count - 1
                .Cols(i).AllowMerging = True
            Next
            For i = 0 To .Rows.Count - 1
                .Rows(i).AllowMerging = True
            Next
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .SelectionMode = SelectionModeEnum.Default
            Dim rngM As CellRange = .GetCellRange(0, 0, 1, 0)
            rngM.Data = "No"
            rngM = .GetCellRange(0, 1, 1, 1)
            rngM.Data = "제조사"
            rngM = .GetCellRange(0, 2, 1, 2)
            rngM.Data = "제품명"
            rngM = .GetCellRange(0, 3, 1, 3)
            rngM.Data = "중량(g)"
            rngM = .GetCellRange(0, 4, 1, 4)
            rngM.Data = "유효기간"
            rngM = .GetCellRange(0, 5, 1, 5)
            rngM.Data = "Lot No.(Serial)"
            rngM = .GetCellRange(0, 6, 1, 8)
            rngM.Data = "사용정보"
            Grid_UseList(1, 6) = "동"
            Grid_UseList(1, 7) = "라인"
            Grid_UseList(1, 8) = "작업자"
            .AutoSizeCols()
        End With


    End Sub

    Private Sub BTN_SolderPaste_Standard_Click(sender As Object, e As EventArgs) Handles BTN_SolderPaste_Standard.Click

        If Not frm_SolderPaste_Standard.Visible Then frm_SolderPaste_Standard.Show()
        frm_SolderPaste_Standard.Focus()

    End Sub
End Class