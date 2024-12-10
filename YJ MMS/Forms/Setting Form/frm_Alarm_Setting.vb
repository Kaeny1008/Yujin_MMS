Imports C1.Win.C1FlexGrid

Public Class frm_Alarm_Setting
    Private Sub frm_Alarm_Setting_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        Load_Alarm_List()

    End Sub

    Private Sub Grid_Setting()

        With Grid_AlarmList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 4
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .Cols(2).DataType = GetType(Integer)
            .Cols(2).Format = "#,##0"
            .Cols(3).DataType = GetType(Boolean)
        End With

        Grid_AlarmList(0, 0) = "No"
        Grid_AlarmList(0, 1) = "알람내용"
        Grid_AlarmList(0, 2) = "재탐색 시간"
        Grid_AlarmList(0, 3) = "사용"
        Grid_AlarmList.AutoSizeCols()

    End Sub

    Private Sub Load_Alarm_List()

        Grid_AlarmList.Redraw = False
        Grid_AlarmList.Rows.Count = 1

        MDBConnect()

        Dim strSQL As String = "select alarm_name, interval_time, use_alarm from tb_alarm_list"

        Dim sqlCmd As New OleDb.OleDbCommand(strSQL, mdbConnection1)
        Dim sqlDR As OleDb.OleDbDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = Grid_AlarmList.Rows.Count
            insertString += vbTab & sqlDR("alarm_name")
            insertString += vbTab & sqlDR("interval_time")
            insertString += vbTab & sqlDR("use_alarm")

            Grid_AlarmList.AddItem(insertString)
        Loop
        sqlDR.Close()

        MDBClose()

        Grid_AlarmList.AutoSizeCols()
        Grid_AlarmList.Redraw = True

    End Sub

    Private Sub Grid_AlarmList_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_AlarmList.MouseClick

        Dim selRow As Integer = Grid_AlarmList.MouseRow
        Dim selCol As Integer = Grid_AlarmList.MouseCol

        If e.Button = MouseButtons.Right And selRow > 0 Then
            Grid_AlarmList.Row = selRow
            Grid_Menu.Show(Grid_AlarmList, New Point(e.X, e.Y))
        ElseIf e.Button = MouseButtons.Left And selRow > 0 And selCol = 3 Then
            'If Grid_AlarmList.GetCellCheck(selRow, 3) = CheckEnum.Checked Then
            '    Grid_AlarmList.SetCellCheck(selRow, 3, CheckEnum.Unchecked)
            'Else
            '    Grid_AlarmList.SetCellCheck(selRow, 3, CheckEnum.Checked)
            'End If
        End If

    End Sub

    Private Sub BTN_RowAdd_Click(sender As Object, e As EventArgs) Handles BTN_RowAdd.Click

        Dim addRow As Integer = Grid_AlarmList.Row + 1

        Grid_AlarmList.AddItem("N", Grid_AlarmList.Row + 1)
        Grid_AlarmList.Rows(addRow).StyleNew.ForeColor = Color.Blue

    End Sub

    Private Sub BTN_RowDelete_Click(sender As Object, e As EventArgs) Handles BTN_RowDelete.Click



    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        Dim strSQL As String = String.Empty

        'MySQL DB에서 정보를 불러오기전에 기존 내용 삭제
        MDBConnect()

        Dim sqlTran_MDB As OleDb.OleDbTransaction
        Dim sqlCmd_MDB As OleDb.OleDbCommand

        sqlTran_MDB = mdbConnection1.BeginTransaction

        Try
            For i = 1 To Grid_AlarmList.Rows.Count - 1
                If Grid_AlarmList(i, 0) = "M" Then
                    strSQL = "update tb_alarm_list set"
                    strSQL += " interval_time = " & Grid_AlarmList(i, 2) & ""
                    strSQL += ", use_alarm = " & Grid_AlarmList(i, 3) & ""
                    strSQL += " where alarm_name = '" & Grid_AlarmList(i, 1) & "'"
                    strSQL += ";"

                    sqlCmd_MDB = New OleDb.OleDbCommand(strSQL, mdbConnection1)
                    sqlCmd_MDB.Transaction = sqlTran_MDB
                    sqlCmd_MDB.ExecuteNonQuery()
                End If

                If Grid_AlarmList(i, 1).Equals("폐기등록 알림") Then
                    If Grid_AlarmList(i, 3) = True Then
                        frm_Main.Timer1.Interval = CDbl(Grid_AlarmList(i, 2)) * 1000
                        frm_Main.Timer1.Start()
                    Else
                        frm_Main.Timer1.Stop()
                    End If
                ElseIf Grid_AlarmList(i, 1).Equals("프린터 텍스트 삭제") Then
                    If Grid_AlarmList(i, 3) = True Then
                        frm_Main.Timer2.Interval = CDbl(Grid_AlarmList(i, 2)) * 1000
                        frm_Main.Timer2.Start()
                    Else
                        frm_Main.Timer2.Stop()
                    End If
                End If
            Next

            sqlTran_MDB.Commit()

        Catch ex As OleDb.OleDbException
            sqlTran_MDB.Rollback()
            MsgBox(ex.Message, MsgBoxStyle.Critical, msg_form)
            Exit Sub
        End Try

        MDBClose()

        MessageBox.Show(Me, "저장완료.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Load_Alarm_List()

    End Sub

    Private Sub Grid_AlarmList_RowColChange(sender As Object, e As EventArgs) Handles Grid_AlarmList.RowColChange

        Dim selCol As Integer = Grid_AlarmList.Col

        Select Case selCol
            Case 1
                Grid_AlarmList.AllowEditing = False
            Case Else
                Grid_AlarmList.AllowEditing = True
        End Select

    End Sub

    Dim beforeText As String

    Private Sub Grid_AlarmList_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Grid_AlarmList.BeforeEdit

        beforeText = Grid_AlarmList(e.Row, e.Col)

    End Sub

    Private Sub Grid_AlarmList_AfterEdit(sender As Object, e As RowColEventArgs) Handles Grid_AlarmList.AfterEdit

        If beforeText = Grid_AlarmList(e.Row, e.Col) Then Exit Sub

        Grid_AlarmList.Rows(e.Row).StyleNew.ForeColor = Color.Red
        Grid_AlarmList(e.Row, 0) = "M"

    End Sub
End Class