Imports C1.Win.C1FlexGrid

Public Class frm_Coordinate_Find_Fault
    Private Sub frm_Coordinate_Find_Fault_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

    End Sub

    Private Sub Grid_Setting()

        With Grid_BOM
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 3
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            Grid_BOM(0, 0) = "No"
            Grid_BOM(0, 1) = "Ref( Location )"
            Grid_BOM(0, 2) = "Part No.( Part Code )"
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .SelectionMode = SelectionModeEnum.Row
        End With

        With Grid_Coordinates
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 6
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            Grid_Coordinates(0, 0) = "No"
            Grid_Coordinates(0, 1) = "Ref( Location )"
            Grid_Coordinates(0, 2) = "X"
            Grid_Coordinates(0, 3) = "Y"
            Grid_Coordinates(0, 4) = "A"
            Grid_Coordinates(0, 5) = "Top / Bottom"
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .SelectionMode = SelectionModeEnum.Row
        End With

    End Sub

    Private Sub frm_Coordinate_Find_Fault_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        Me.Dispose()

    End Sub

    Private Sub Grid_BOM_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_BOM.MouseClick

        If e.Button = MouseButtons.Left And Grid_BOM.MouseRow > 0 Then
            Grid_BOM.RowSel = Grid_BOM.MouseRow
        End If

    End Sub

    Private Sub Grid_Coordinates_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Grid_Coordinates.MouseDoubleClick

        Exit Sub

        If e.Button = MouseButtons.Left And Grid_Coordinates.MouseRow > 0 Then
            Dim selRow As Integer = Grid_Coordinates.MouseRow
            Dim findRow As Integer = frm_Model_Document.Grid_BOM_Total.FindRow(Grid_BOM(Grid_BOM.Row, 1), 0, 1, True)
            'frm_ModelDocument.Grid_BOM_Total(findRow, 1) = Grid_Coordinates(selRow, 1)
            frm_Model_Document.Grid_BOM_Total(findRow, 3) = Grid_Coordinates(selRow, 2)
            frm_Model_Document.Grid_BOM_Total(findRow, 4) = Grid_Coordinates(selRow, 3)
            frm_Model_Document.Grid_BOM_Total(findRow, 5) = Grid_Coordinates(selRow, 4)
            frm_Model_Document.Grid_BOM_Total(findRow, 6) = Grid_Coordinates(selRow, 5)
            frm_Model_Document.Grid_BOM_Total.TopRow = findRow
            Grid_Coordinates.Rows(selRow).StyleNew.ForeColor = Color.DarkGray
            Grid_BOM.Rows(Grid_BOM.RowSel).StyleNew.ForeColor = Color.DarkGray
            MessageBox.Show(Me, "좌표를 입력하였습니다.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
End Class