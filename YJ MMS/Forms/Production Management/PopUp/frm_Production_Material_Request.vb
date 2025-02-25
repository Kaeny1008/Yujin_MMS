Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Production_Material_Request

    Dim now_RequireNo As String
    Dim completed As Boolean = False '현재 요청서가 완료 되어 있는지 확인
    Dim bottomNo As Integer = 1 '불러온 Bot자재 수량
    Dim TopNo As Integer = 1 '불러온 Top자재 수량

    Private Sub frm_Production_Material_Request_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        Require_No_Load()

        If now_RequireNo = String.Empty Then
            Require_No_Make()
            Require_No_Load()
            If now_RequireNo = String.Empty Then
                MSG_Error(Me, "요청번호 생성에 실패 하였습니다.")
                Me.Dispose()
            End If
        Else
            Require_List_Load()
        End If

        'MsgBox(completed)

    End Sub

    Private Sub Grid_Setting()

        With Grid_BottomList
            .AllowEditing = True
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 2
            .Cols.Fixed = 1
            .Rows.Count = 109
            .Rows.Fixed = 1
            .AutoClipboard = False
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Cols(1).Width = 200
        End With

        Grid_BottomList(0, 0) = "No"
        Grid_BottomList(0, 1) = "Part Code"

        For i = 1 To Grid_BottomList.Rows.Count - 1
            Grid_BottomList(i, 0) = "N"
        Next

        With Grid_TopList
            .AllowEditing = True
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 2
            .Cols.Fixed = 1
            .Rows.Count = 109
            .Rows.Fixed = 1
            .AutoClipboard = False
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Cols(1).Width = 200
        End With

        Grid_TopList(0, 0) = "No"
        Grid_TopList(0, 1) = "Part Code"

        For i = 1 To Grid_TopList.Rows.Count - 1
            Grid_TopList(i, 0) = "N"
        Next

    End Sub

    Private Sub Require_No_Make()

        If DBConnect() = False Then Exit Sub

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            strSQL = "insert into tb_mms_smd_production_material_require_list("
            strSQL += "require_no, order_index, require_status, write_date, write_id"
            strSQL += ") values ("
            strSQL += "f_mms_smd_material_require_no('" & Format(CDate(writeDate), "yyyy-MM-dd") & "')"
            strSQL += ", '" & LB_OrderIndex.Text & "'"
            strSQL += ", 'Run'"
            strSQL += ", '" & writeDate & "'"
            strSQL += ", '" & loginID & "'"
            strSQL += ");"

            If Not strSQL = String.Empty Then
                sqlCmd = New MySqlCommand(strSQL, dbConnection1)
                sqlCmd.Transaction = sqlTran
                sqlCmd.ExecuteNonQuery()

                sqlTran.Commit()
            End If
        Catch ex As MySqlException
            sqlTran.Rollback()
        End Try

        DBClose()

    End Sub

    Private Sub Require_No_Load()

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "select require_no, require_status"
        strSQL += " from tb_mms_smd_production_material_require_list"
        strSQL += " where order_index = '" & LB_OrderIndex.Text & "'"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            now_RequireNo = sqlDR("require_no")
            If sqlDR("require_status").Equals("Completed") Then
                completed = True
            End If
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub Require_List_Load()

        If DBConnect() = False Then Exit Sub
        Dim lastWriteRow_Bottom As Integer = 1
        Dim lastWriteRow_Top As Integer = 1

        Dim strSQL As String = "select work_side, part_code"
        strSQL += " from tb_mms_smd_production_material_require_detail"
        strSQL += " where require_no = '" & now_RequireNo & "'"
        strSQL += " order by detail_no"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            If sqlDR("work_side").Equals("Bottom") Then
                Grid_BottomList(lastWriteRow_Bottom, 0) = lastWriteRow_Bottom
                Grid_BottomList(lastWriteRow_Bottom, 1) = sqlDR("part_code")
                lastWriteRow_Bottom += 1
                bottomNo += 1
            ElseIf sqlDR("work_side").Equals("Top") Then
                Grid_TopList(lastWriteRow_Top, 0) = lastWriteRow_Top
                Grid_TopList(lastWriteRow_Top, 1) = sqlDR("part_code")
                lastWriteRow_Top += 1
                TopNo += 1
            End If
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub BTN_Cancel_Click(sender As Object, e As EventArgs) Handles BTN_Cancel.Click

        Me.DialogResult = DialogResult.No
        Me.Dispose()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If MSG_Question(Me, "요청서 작성을 완료 하시겠습니까?") = False Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        If DBConnect() = False Then Exit Sub

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty
        Dim insertSQL As String = String.Empty
        Dim updateSQL As String = String.Empty
        Dim deleteSQL As String = String.Empty
        Dim firstWrite As Integer = 0
        Dim sendResult As DialogResult = DialogResult.None

        sqlTran = dbConnection1.BeginTransaction

        Try

            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            insertSQL = "insert into tb_mms_smd_production_material_require_detail("
            insertSQL += "require_no, detail_no, work_side, part_code, write_date, write_id, detail_status"
            insertSQL += ") values"

            For i = 1 To Grid_BottomList.Rows.Count - 1
                If Not Trim(Grid_BottomList(i, 1)).ToString.Equals(String.Empty) Then
                    If Grid_BottomList(i, 0).ToString.Equals("N") Then
                        If Not firstWrite = 0 Then
                            insertSQL += ","
                        End If
                        insertSQL += "("
                        insertSQL += "'" & now_RequireNo & "'"
                        insertSQL += ", '" & now_RequireNo & "-B-" & bottomNo & "'"
                        insertSQL += ", 'Bottom'"
                        insertSQL += ", '" & Grid_BottomList(i, 1) & "'"
                        insertSQL += ", '" & writeDate & "'"
                        insertSQL += ", '" & loginID & "'"
                        If completed = True Then
                            insertSQL += ", '추가'"
                        Else
                            insertSQL += ", ''"
                        End If
                        insertSQL += ")"
                        firstWrite += 1
                        bottomNo += 1
                    ElseIf Grid_BottomList(i, 0).ToString.Equals("M") Then
                        updateSQL += "update tb_mms_smd_production_material_require_detail"
                        updateSQL += " set part_code = '" & Grid_BottomList(i, 1) & "'"
                        updateSQL += ", detail_status = '수정'"
                        updateSQL += " where detail_no = '" & now_RequireNo & "-B-" & i & "';"
                    ElseIf Grid_BottomList(i, 0).ToString.Equals("D") Then
                        deleteSQL += "delete from tb_mms_smd_production_material_require_detail"
                        deleteSQL += " where detail_no = '" & now_RequireNo & "-B-" & i & "';"
                    End If
                End If
            Next

            For i = 1 To Grid_TopList.Rows.Count - 1
                If Not Trim(Grid_TopList(i, 1)).ToString.Equals(String.Empty) Then
                    If Grid_TopList(i, 0).ToString.Equals("N") Then
                        If Not firstWrite = 0 Then
                            insertSQL += ","
                        End If
                        insertSQL += "("
                        insertSQL += "'" & now_RequireNo & "'"
                        insertSQL += ", '" & now_RequireNo & "-T-" & TopNo & "'"
                        insertSQL += ", 'Top'"
                        insertSQL += ", '" & Grid_TopList(i, 1) & "'"
                        insertSQL += ", '" & writeDate & "'"
                        insertSQL += ", '" & loginID & "'"
                        If completed = True Then
                            insertSQL += ", '추가'"
                        Else
                            insertSQL += ", ''"
                        End If
                        insertSQL += ")"
                        firstWrite += 1
                        TopNo += 1
                    ElseIf Grid_TopList(i, 0).ToString.Equals("M") Then
                        updateSQL += "update tb_mms_smd_production_material_require_detail"
                        updateSQL += " set part_code = '" & Grid_TopList(i, 1) & "'"
                        updateSQL += ", detail_status = '수정'"
                        updateSQL += " where detail_no = '" & now_RequireNo & "-T-" & i & "';"
                    ElseIf Grid_TopList(i, 0).ToString.Equals("D") Then
                        deleteSQL += "delete from tb_mms_smd_production_material_require_detail"
                        deleteSQL += " where detail_no = '" & now_RequireNo & "-T-" & i & "';"
                    End If
                End If
            Next
            insertSQL += ";"

            If firstWrite = 0 Then
                strSQL = updateSQL & deleteSQL
            Else
                strSQL = insertSQL & updateSQL & deleteSQL
            End If

            If Not strSQL = String.Empty Then
                strSQL += "update tb_mms_smd_production_material_require_list"
                strSQL += " set require_status = 'Run'"
                strSQL += " where require_no = '" & now_RequireNo & "';"
                sqlCmd = New MySqlCommand(strSQL, dbConnection1)
                sqlCmd.Transaction = sqlTran
                sqlCmd.ExecuteNonQuery()

                sqlTran.Commit()
            Else
                sendResult = DialogResult.No
            End If
        Catch ex As MySqlException
            sqlTran.Rollback()

            DBClose()

            Thread_LoadingFormEnd()

            MSG_Error(Me, ex.Message)
            Exit Sub
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        If sendResult = DialogResult.None Then
            sendResult = DialogResult.OK
        End If

        Me.DialogResult = sendResult
        Me.Dispose()

    End Sub

    Private Sub Grid_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid_BottomList.KeyDown,
        Grid_TopList.KeyDown

        Dim c1 As C1FlexGrid = sender
        'Console.WriteLine(c1.name)

        Dim selRow As Integer = c1.Row

        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V Then
            Dim clipText() As String = My.Computer.Clipboard.GetText().Replace(vbLf, String.Empty).Split(vbCrLf)
            For i = 0 To UBound(clipText)
                If Not clipText(i).ToString.Equals(String.Empty) And
                    Not clipText(i).ToString.Equals("###############") And
                    Not clipText(i).ToString.Equals("---------------") Then

                    Do While Not IsNothing(c1(selRow, 1))
                        Console.WriteLine(c1(selRow, 1))
                        selRow += 1
                    Loop


                    c1(selRow, 1) = clipText(i)
                    'Console.WriteLine(c1(selRow, 1) & " : " & clipText(i))
                    selRow += 1
                End If
            Next
        End If

    End Sub

    Private Sub Grid_AfterEdit(sender As Object, e As RowColEventArgs) Handles Grid_BottomList.AfterEdit, Grid_TopList.AfterEdit

        Dim c1 As C1FlexGrid = sender

        If e.Row < 1 Or e.Col < 1 Then Exit Sub

        If IsNumeric(c1(e.Row, 0)) Then
            c1(e.Row, 0) = "M"
            c1.Rows(e.Row).StyleNew.ForeColor = Color.Red
        End If

    End Sub

    Dim c1 As C1FlexGrid

    Private Sub Grid_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_TopList.MouseClick, Grid_BottomList.MouseClick

        c1 = sender

        Dim selRow As Integer = c1.MouseRow

        If selRow < 1 Then Exit Sub

        If e.Button = MouseButtons.Right Then
            If IsNumeric(c1(selRow, 0)) Then
                BTN_DeleteCancel.Enabled = False
                BTN_Delete.Enabled = True
            ElseIf c1(selRow, 0).ToString.Equals("D") Then
                BTN_DeleteCancel.Enabled = True
                BTN_Delete.Enabled = False
            Else
                Exit Sub
            End If
            c1.Row = selRow
            Grid_menu.Show(c1, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub BTN_Delete_Click(sender As Object, e As EventArgs) Handles BTN_Delete.Click

        c1(c1.Row, 0) = "D"
        c1.Rows(c1.Row).StyleNew.ForeColor = Color.DarkGray

    End Sub

    Private Sub BTN_DeleteCancel_Click(sender As Object, e As EventArgs) Handles BTN_DeleteCancel.Click

        c1(c1.Row, 0) = c1.Row
        c1.Rows(c1.Row).StyleNew.ForeColor = Color.Black

    End Sub

    Private Sub BTN_MRCanel_Click(sender As Object, e As EventArgs) Handles BTN_MRCanel.Click

        If MSG_Question(Me, "요청을 취소 하시겠습니까?") = False Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        If DBConnect() = False Then Exit Sub

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            strSQL = "delete from tb_mms_smd_production_material_require_list"
            strSQL += " where require_no = '" & now_RequireNo & "';"
            strSQL += "delete from tb_mms_smd_production_material_require_detail"
            strSQL += " where require_no = '" & now_RequireNo & "';"

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

            MSG_Error(Me, ex.Message)
            Exit Sub
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        Me.DialogResult = DialogResult.Abort
        Me.Dispose()

    End Sub
End Class