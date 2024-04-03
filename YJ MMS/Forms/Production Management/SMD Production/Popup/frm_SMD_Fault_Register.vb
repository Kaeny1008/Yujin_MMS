Imports C1.Win.C1FlexGrid

Public Class frm_SMD_Fault_Register
    Private Sub frm_SMD_Fault_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.TopMost = True

        Grid_Setting()

    End Sub

    Private Sub Grid_Setting()

        With Grid_Fault
            .AllowEditing = True
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 6
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = True
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .SelectionMode = SelectionModeEnum.Default
            .Cols(1).Visible = True
        End With

        Grid_Fault(0, 0) = "No"
        Grid_Fault(0, 1) = "FalutIndex"
        Grid_Fault(0, 2) = "불량구분"
        Grid_Fault(0, 3) = "불량명"
        Grid_Fault(0, 4) = "Ref(Location)"
        Grid_Fault(0, 5) = "비고"

    End Sub

    Private Sub frm_SMD_Fault_Register_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        Console.WriteLine("KeyValue : " & e.KeyValue & ", KeyCode : " & e.KeyCode)

        If e.KeyCode = 112 Then
            BTN_RowAdd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = 114 Then

        End If

    End Sub

    Private Sub BTN_Exit_Click(sender As Object, e As EventArgs) Handles BTN_Exit.Click

        Me.Dispose()

    End Sub

    Private Sub BTN_RowAdd_Click(sender As Object, e As EventArgs) Handles BTN_RowAdd.Click

        Grid_Fault.AddItem(Grid_Fault.Rows.Count & vbTab & Format(Now, "yyMMddHHmmssfff"))

    End Sub
End Class