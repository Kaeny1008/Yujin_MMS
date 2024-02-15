'############################################################################################################
'############################################################################################################

'##### 작성일자 : 2024-02-15
'##### 수정일자 : 2024-02-15
'##### 수정자   : 박시현
'##### 참고     : 
'##### 설명     : 고객사별 모델을 등록 한다.

'############################################################################################################

Imports C1.Win.C1FlexGrid

Public Class frm_ModelResistration
    Private Sub frm_CustomerResistration_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

    End Sub

    Private Sub Grid_Setting()

        With grid_CustomerList
            .AllowEditing = True
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 8
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            grid_CustomerList(0, 0) = "No"
            grid_CustomerList(0, 1) = "모델코드"
            grid_CustomerList(0, 2) = "고객사 코드"
            grid_CustomerList(0, 3) = "고객사명"
            grid_CustomerList(0, 4) = "모델구분"
            grid_CustomerList(0, 5) = "모델명"
            grid_CustomerList(0, 6) = "품목명"
            grid_CustomerList(0, 7) = "비고"
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            .ExtendLastCol = True
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
        End With

    End Sub
End Class