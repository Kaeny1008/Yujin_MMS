Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Repair_Management
    Private Sub frm_SMD_Defect_ReInspection_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub Grid_Setting()

        With Grid_RepairList
            .AllowEditing = True
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 12
            .Cols.Fixed = 1
            .Rows.Count = 2
            .Rows.Fixed = 2
            For i = 0 To .Cols.Count - 1
                .Cols(i).AllowMerging = True
            Next
            For i = 0 To .Rows.Count - 1
                .Rows(i).AllowMerging = True
            Next
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            '.ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            '.Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            '.Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            '.SelectionMode = SelectionModeEnum.Default
            .Cols(1).Visible = False
            Dim rngM As CellRange = .GetCellRange(0, 0, 1, 0)
            rngM.Data = "No"
            rngM = .GetCellRange(0, 1, 1, 1)
            rngM.Data = "defect_index"
            rngM = .GetCellRange(0, 2, 1, 7)
            rngM.Data = "검사내역"
            Grid_RepairList(1, 2) = "Board No."
            Grid_RepairList(1, 3) = "불량구분"
            Grid_RepairList(1, 4) = "불량명"
            Grid_RepairList(1, 5) = "Array No."
            Grid_RepairList(1, 6) = "Ref"
            Grid_RepairList(1, 7) = "비고"
            rngM = .GetCellRange(0, 8, 1, 11)
            rngM.Data = "수리내역"
            Grid_RepairList(1, 8) = "수리일자"
            Grid_RepairList(1, 9) = "작업내역"
            Grid_RepairList(1, 10) = "수리사"
            Grid_RepairList(1, 11) = "비고"
        End With

        Grid_RepairList.AutoSizeCols()

    End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart()

        Grid_RepairList.Redraw = False
        Grid_RepairList.Rows.Count = 2

        DBConnect()

        Dim searchString As String = "전체"
        If RadioButton2.Checked Then
            searchString = "완료"
        ElseIf RadioButton3.Checked Then
            searchString = "미완료"
        End If

        Dim findIndex As Integer = 99
        If CB_Process.Text = "SMD" Then
            findIndex = 1
        ElseIf CB_Process.Text = "Selective Soldering" Then
            findIndex = 2
        ElseIf CB_Process.Text = "Wave Soldering" Then
            findIndex = 3
        End If

        Dim strSQL As String = "call sp_mms_repair_management("
        strSQL += "" & findIndex & ""
        strSQL += ", '" & TextBox1.Text & "'"
        strSQL += ", '" & searchString & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = Grid_RepairList.Rows.Count - 1 & vbTab &
                sqlDR("defect_index") & vbTab &
                sqlDR("board_no") & vbTab &
                sqlDR("defect_classification") & vbTab &
                sqlDR("defect_name") & vbTab &
                sqlDR("board_array") & vbTab &
                sqlDR("ref") & vbTab &
                sqlDR("defect_note") & vbTab &
                Format(sqlDR("repair_date"), "yyyy-MM-dd HH:mm:ss") & vbTab &
                sqlDR("repair_action") & vbTab &
                sqlDR("repairman") & vbTab &
                sqlDR("repair_note")
            GridWriteText(insertString, Me, Grid_RepairList, Color.Black)
            GridColsAutoSize(Me, Grid_RepairList)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_RepairList.Redraw = True

        Load_RepairAction()

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_RepairList_RowColChange(sender As Object, e As EventArgs) Handles Grid_RepairList.RowColChange

        Select Case Grid_RepairList.Col
            Case 9, 10, 11
                Grid_RepairList.AllowEditing = True
            Case Else
                Grid_RepairList.AllowEditing = False
        End Select

    End Sub

    Dim beforeText As String

    Private Sub Grid_RepairList_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Grid_RepairList.BeforeEdit

        If e.Row < 2 Or e.Col < 9 Then Exit Sub

        If CheckBox1.Checked Then
            If TextBox2.Text = String.Empty Then
                'MessageBox.Show("수리사를 입력하여 주십시오.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'e.Cancel = true
            End If
        End If

        beforeText = Grid_RepairList(e.Row, e.Col)

    End Sub

    Private Sub Grid_RepairList_AfterEdit(sender As Object, e As RowColEventArgs) Handles Grid_RepairList.AfterEdit

        If e.Row < 2 Or e.Col < 9 Then Exit Sub
        If IsNothing(Grid_RepairList(e.Row, e.Col)) Then Exit Sub
        If Grid_RepairList(e.Row, e.Col).Equals(beforeText) Then Exit Sub

        Grid_RepairList.Redraw = False

        If IsNumeric(Grid_RepairList(e.Row, 0)) Then
            Grid_RepairList(e.Row, 0) = "M"
            Grid_RepairList.Rows(e.Row).StyleNew.ForeColor = Color.Blue
        End If

        Grid_RepairList(e.Row, 8) = Format(Now, "yyyy-MM-dd HH:mm:ss")
        If CheckBox1.Checked Then Grid_RepairList(e.Row, 10) = TextBox2.Text

        Grid_RepairList.AutoSizeCols()
        Grid_RepairList.Redraw = True

    End Sub

    Private Sub Load_RepairAction()

        Thread_LoadingFormStart()

        DBConnect()

        Dim comboList As String = "|"

        Dim strSQL As String = "call sp_mms_repair_management(0"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            If comboList = String.Empty Then
                comboList = sqlDR("sub_code_name")
            Else
                comboList += "|" & sqlDR("sub_code_name")
            End If
        Loop
        sqlDR.Close()

        DBClose()

        Grid_RepairList.Cols(9).ComboList = comboList

        Thread_LoadingFormEnd()

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        If MessageBox.Show("수리내역을 저장 하시겠습니까?",
                           msg_form,
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        For i = 2 To Grid_RepairList.Rows.Count - 1
            If Grid_RepairList(i, 0) = "M" Then
                If Grid_RepairList(i, 8) = String.Empty Or
                    Grid_RepairList(i, 9) = String.Empty Or
                    Grid_RepairList(i, 10) = String.Empty Then
                    MessageBox.Show("필수 입력항목이 누락되었습니다." & vbCrLf & "번호 : " & i-1,
                                    msg_form,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
        Next

        Thread_LoadingFormStart()

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
        Dim updateTable As String = String.Empty
        If CB_Process.Text = "SMD" Then
            updateTable = "tb_mms_smd_defect"
        ElseIf CB_Process.Text = "Selective Soldering" Then
            updateTable = String.Empty
        ElseIf CB_Process.Text = "Wave Soldering" Then
            updateTable = String.Empty
        End If

        Try
            For i = 2 To Grid_RepairList.Rows.Count - 1
                If Grid_RepairList(i, 0) = "M" Then
                    strSQL = "update " & updateTable
                    strSQL += " set"
                    strSQL += " repair_date = '" & Grid_RepairList(i, 8) & "'"
                    strSQL += ", repair_action = '" & Grid_RepairList(i, 9) & "'"
                    strSQL += ", repairman = '" & Grid_RepairList(i, 10) & "'"
                    strSQL += ", repair_note = '" & Grid_RepairList(i, 11) & "'"
                    strSQL += " where defect_index = '" & Grid_RepairList(i, 1) & "'"
                    strSQL += ";"
                End If
            Next

            If Not strSQL = String.Empty Then
                sqlCmd = New MySqlCommand(strSQL, dbConnection1)
                sqlCmd.Transaction = sqlTran
                sqlCmd.ExecuteNonQuery()

                sqlTran.Commit()
            End If
        Catch ex As MySqlException
            sqlTran.Rollback()

            DBClose()

            Thread_LoadingFormEnd()
            MessageBox.Show(ex.Message,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

            Exit Sub
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        MessageBox.Show("저장 완료.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)

        BTN_Search_Click(Nothing, Nothing)

    End Sub
End Class