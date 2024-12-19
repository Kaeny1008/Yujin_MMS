Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Order_Excel_Modify

    Public fileName As String
    Public sheetName As String
    Public item_section As String

    Dim startRow, endRow, dateRow As Integer
    Dim itemCode, itemName, startDate, endDate As Integer

    Private Sub frm_Order_Excel_File_Open_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Thread_LoadingFormStart(Me)

        startRow = 0
        endRow = 0
        dateRow = 0
        itemCode = 0
        itemName = 0
        startDate = 0
        endDate = 0

        Grid_Excel.Redraw = False
        Grid_Excel.LoadExcel(fileName, sheetName, FileFlags.None)
        For i = 0 To Grid_Excel.Cols.Count - 1
            Grid_Excel(0, i) = i
        Next

        For i = 0 To Grid_Excel.Rows.Count - 1
            Grid_Excel(i, 0) = i
        Next
        Grid_Excel.AutoSizeCols()
        Grid_Excel.AutoSizeRows()
        Grid_Excel.AllowSorting = AllowSortingEnum.None
        Grid_Excel.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub BTN_POChange_Click(sender As Object, e As EventArgs) Handles BTN_POChange.Click

        If startRow = 0 Or endRow = 0 Or itemCode = 0 Or itemName = 0 Or startDate = 0 Or endDate = 0 Or dateRow = 0 Then
            MSG_Information(Me, "필수 항목이 모두 선택되지 않았습니다.")
            Exit Sub
        End If

        Thread_LoadingFormStart(Me, "변환중...")

        With frm_Material_CheckRequirements2.Grid_Excel
            .Redraw = False
            .Rows.Count = 1
        End With

        Dim orderDate As String = Format(Now, "yyyy-MM-dd")
        Dim newRowNum As Integer = 1

        For j = startDate To endDate
            Dim nowDate As Date = CDate(Grid_Excel(dateRow, j))
            For i = startRow To endRow
                If Not Grid_Excel(i, 0).ToString.Equals("행 제외") Then
                    If Grid_Excel.GetCellStyle(i, j).BackColor.Equals(Color.Beige) And IsNumeric(Grid_Excel(i, j)) Then
                        GridWriteText(newRowNum & vbTab &
                                      nowDate & vbTab &
                                      vbTab &
                                      Grid_Excel(i, itemCode) & vbTab &
                                      Grid_Excel(i, itemName) & vbTab &
                                      Grid_Excel(i, j) & vbTab &
                                      "미지정",
                                      frm_Material_CheckRequirements2,
                                      frm_Material_CheckRequirements2.Grid_Excel,
                                      Color.Black)
                        newRowNum += 1
                    End If
                End If
            Next
        Next

        With frm_Material_CheckRequirements2.Grid_Excel
            .AutoSizeCols()
            .Redraw = True
        End With

        Thread_LoadingFormEnd()

        Application.DoEvents()

        Me.Dispose()

        frm_Material_CheckRequirements2.Load_ModelCode()

    End Sub

    Dim selStartRow, selEndRow As Integer
    Dim selStartCol, selEndCol As Integer
    Dim selRow As Integer
    Dim selCol As Integer

    Private Sub Grid_Excel_MouseDown(sender As Object, e As MouseEventArgs) Handles Grid_Excel.MouseDown

        If e.Button = MouseButtons.Left Then
            selStartRow = Grid_Excel.MouseRow
            selStartCol = Grid_Excel.MouseCol
        End If

    End Sub

    Private Sub Grid_Excel_MouseUp(sender As Object, e As MouseEventArgs) Handles Grid_Excel.MouseUp

        If e.Button = MouseButtons.Left Then
            selEndRow = Grid_Excel.MouseRow
            selEndCol = Grid_Excel.MouseCol
        End If

    End Sub

    Private Sub Grid_Excel_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_Excel.MouseClick

        If e.Button = MouseButtons.Right Then
            selRow = Grid_Excel.MouseRow
            selCol = Grid_Excel.MouseCol

            If selRow < 0 Or selCol < 0 Then Exit Sub

            'Grid_Excel.Row = selRow
            'Grid_Excel.Col = selCol
            If selRow = 0 And selCol > 0 Then
                Grid_ColMenu.Show(Grid_Excel, New Point(e.X, e.Y))
            ElseIf selRow > 0 And selCol = 0 Then
                If IsNothing(Grid_Excel(selRow, 0)) Then
                    BTN_RowDelete.Text = "행 제외"
                Else
                    If Grid_Excel(selRow, 0).ToString.Equals("행 제외") Then
                        BTN_RowDelete.Text = "제외 취소"
                    Else
                        BTN_RowDelete.Text = "행 제외"
                    End If
                End If
                Grid_RowMenu.Show(Grid_Excel, New Point(e.X, e.Y))
            End If
        End If

    End Sub

    Private Sub BTN_RowMenu_Click(sender As Object, e As EventArgs) Handles BTN_StartRow.Click,
        BTN_EndRow.Click,
        BTN_DateRow.Click

        Dim selName As String = sender.ToString

        For i = 1 To Grid_Excel.Rows.Count - 1
            If Not IsNothing(Grid_Excel(i, 0)) Then
                If CStr(Grid_Excel(i, 0)) = selName Then
                    Grid_Excel(i, 0) = i
                End If
            End If
        Next

        Grid_Excel(selRow, 0) = selName
        Grid_Excel.AutoSizeCols(0, 0, 0)

        If selName = BTN_StartRow.Text Then
            startRow = selRow
        ElseIf selName = BTN_EndRow.Text Then
            endRow = selRow
        ElseIf selName = BTN_DateRow.Text Then
            dateRow = selRow
        End If

    End Sub

    Private Sub BTN_RowDelete_Click(sender As Object, e As EventArgs) Handles BTN_RowDelete.Click

        If BTN_RowDelete.Text = "제외 취소" Then
            For i = selStartRow To selEndRow
                Grid_Excel(i, 0) = Grid_Excel.Row - 1
                Grid_Excel.AutoSizeCols()
            Next
        Else
            For i = selStartRow To selEndRow
                Grid_Excel(i, 0) = "행 제외"
                Grid_Excel.AutoSizeCols()
            Next
        End If

    End Sub

    Private Sub BTN_ColMenu_Click(sender As Object, e As EventArgs) Handles BTN_ItemCode.Click,
        BTN_ItemName.Click,
        BTN_StartDate.Click,
        BTN_EndDate.Click

        Dim selName As String = sender.ToString

        For i = 1 To Grid_Excel.Cols.Count - 1
            If Not IsNothing(Grid_Excel(0, i)) Then
                If CStr(Grid_Excel(0, i)) = selName Then
                    Grid_Excel(0, i) = i
                End If
            End If
        Next

        Grid_Excel(0, selCol) = selName
        Grid_Excel.AutoSizeCols()

        If selName = BTN_ItemCode.Text Then
            itemCode = selCol
        ElseIf selName = BTN_ItemName.Text Then
            itemName = selCol
        ElseIf selName = BTN_StartDate.Text Then
            startDate = selCol
        ElseIf selName = BTN_EndDate.Text Then
            endDate = selCol
        End If

    End Sub
End Class