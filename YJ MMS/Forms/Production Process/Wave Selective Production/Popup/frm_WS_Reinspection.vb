Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_WS_Reinspection
    Private Sub frm_WS_Reinspection_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.TopMost = True
        CB_Result.SelectedIndex = 0

        Grid_Setting()

    End Sub

    Private Sub Grid_Setting()

        With Grid_Information
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
            Grid_Information(1, 2) = "Board No."
            Grid_Information(1, 3) = "불량구분"
            Grid_Information(1, 4) = "불량명"
            Grid_Information(1, 5) = "Array No."
            Grid_Information(1, 6) = "Ref"
            Grid_Information(1, 7) = "비고"
            rngM = .GetCellRange(0, 8, 1, 11)
            rngM.Data = "수리내역"
            Grid_Information(1, 8) = "수리일자"
            Grid_Information(1, 9) = "작업내역"
            Grid_Information(1, 10) = "수리사"
            Grid_Information(1, 11) = "비고"
        End With

        Grid_Information.AutoSizeCols()

    End Sub

    Private Sub TB_BoardNo_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_BoardNo.KeyDown

        If Not TB_BoardNo.Text = String.Empty And e.KeyCode = 13 Then
            Thread_LoadingFormStart()

            Grid_Information.Redraw = False
            Grid_Information.Rows.Count = 2

            DBConnect()

            Dim strSQL As String = "call sp_mms_wave_selective_reinspection("
            strSQL += "'" & TB_BoardNo.Text & "'"
            strSQL += ",'" & LB_OrderIndex.Text & "'"
            strSQL += ")"

            Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
            Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

            Dim repair_action As String = String.Empty
            Dim reinspect_date As String = String.Empty
            Dim ngCheck As Boolean = False

            Do While sqlDR.Read
                Dim repair_date As String = String.Empty
                If Not IsDBNull(sqlDR("repair_date")) Then
                    repair_date = Format(sqlDR("repair_date"), "yyyy-MM-dd HH:mm:ss")
                End If
                Dim insertString As String = Grid_Information.Rows.Count - 1 & vbTab &
                    sqlDR("defect_index") & vbTab &
                    sqlDR("board_no") & vbTab &
                    sqlDR("defect_classification") & vbTab &
                    sqlDR("defect_name") & vbTab &
                    sqlDR("board_array") & vbTab &
                    sqlDR("ref") & vbTab &
                    sqlDR("defect_note") & vbTab &
                    repair_date & vbTab &
                    sqlDR("repair_action") & vbTab &
                    sqlDR("repairman") & vbTab &
                    sqlDR("repair_note")

                If IsDBNull(sqlDR("repair_action")) Then
                    Thread_LoadingFormEnd()
                    ngCheck = True
                    MessageBox.Show("수리기록이 확인되지 않습니다.",
                                    msg_form,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information)
                    Exit Do
                End If
                If Not IsDBNull(sqlDR("reinspect_date")) Then
                    Thread_LoadingFormEnd()
                    ngCheck = True
                    MessageBox.Show("이미 재검사 기록이 등록 되었습니다.",
                                    msg_form,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information)
                    Exit Do
                End If
                GridWriteText(insertString, Me, Grid_Information, Color.Black)
                GridColsAutoSize(Me, Grid_Information)
            Loop
            sqlDR.Close()

            DBClose()

            Grid_Information.Redraw = True

            Thread_LoadingFormEnd()

            If Grid_Information.Rows.Count = 2 And ngCheck = False Then
                MessageBox.Show("불량 기록을 확인 할 수 없습니다.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        If Grid_Information.Rows.Count < 3 Then
            MessageBox.Show("Board No.가 확인되지 않았습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Exit Sub
        End If

        If TB_Inspector.Text = String.Empty Then
            MessageBox.Show("검사자가 입력되지 않았습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Exit Sub
        End If

        If MessageBox.Show("검사내역을 저장 하시겠습니까?",
                           msg_form,
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Thread_LoadingFormStart("Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

        Try

            strSQL = "update tb_mms_ws_defect"
            strSQL += " set"
            strSQL += " reinspect_date = '" & writeDate & "'"
            strSQL += ", reinspect_result = '" & CB_Result.Text & "'"
            strSQL += ", reinspect_inspector = '" & TB_Inspector.Text & "'"
            strSQL += " where defect_index = '" & Grid_Information(2, 1) & "'"
            strSQL += ";"

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

        MessageBox.Show(Me,
                        "저장 완료.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

        Me.Dispose()

    End Sub
End Class