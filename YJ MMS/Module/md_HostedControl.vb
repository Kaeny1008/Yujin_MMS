Imports C1.Win.C1FlexGrid

Friend Class md_HostedControl
    Friend _flex As C1FlexGrid
    Friend _ctl As Control
    Friend _row As Row
    Friend _col As Column

    Friend Sub New(ByVal flex As C1FlexGrid, ByVal hosted As Control, ByVal row As Integer, ByVal col As Integer)
        _flex = flex
        _ctl = hosted
        _row = flex.Rows(row)
        _col = flex.Cols(col)
        _flex.Controls.Add(_ctl)
    End Sub

    Friend Function UpdatePosition() As Boolean
        Dim r As Integer = _row.Index
        Dim c As Integer = _col.Index
        If r < 0 OrElse c < 0 Then Return False
        Dim rc As Rectangle = _flex.GetCellRect(r, c, False)

        If rc.Width <= 0 OrElse rc.Height <= 0 OrElse Not rc.IntersectsWith(_flex.ClientRectangle) Then
            _ctl.Visible = False
            Return True
        End If

        _ctl.Bounds = rc
        _ctl.Visible = True
        Return True
    End Function
End Class
