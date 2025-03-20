Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient


Public Class frm_Change_ItemParts
    Private Sub frm_Change_ItemParts_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GridSetting()

    End Sub

    Private Sub GridSetting()

        With Grid_ModelList
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
            .ExtendLastCol = True
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
        End With

        Grid_ModelList(0, 0) = "No"
        Grid_ModelList(0, 1) = "모델코드"
        Grid_ModelList(0, 2) = "품명"
        Grid_ModelList(0, 3) = "변경이력"

        Grid_ModelList.AutoSizeCols()

        With Grid_ChangeList
            .AllowEditing = True
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 4
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 2
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
        End With

        Grid_ChangeList(0, 0) = "No"
        Grid_ChangeList(1, 0) = "1"
        Grid_ChangeList(0, 1) = "변경 전"
        Grid_ChangeList(0, 2) = "변경 후"
        Grid_ChangeList(0, 3) = "결과"

        Grid_ChangeList.AutoSizeCols()

    End Sub

    Private Sub Control_Initiallize()

        Grid_ModelList.Rows.Count = 1
        Grid_ChangeList.Rows.Count = 1
        Grid_ChangeList.AddItem(Grid_ChangeList.Rows.Count)

    End Sub

    Private Sub TB_ItemLike_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_ItemLike.KeyDown

        If Not Trim(TB_ItemLike.Text).Equals(String.Empty) And e.KeyCode = 13 Then
            Load_ItemList()
        End If

    End Sub

    Private Sub Load_ItemList()

        Thread_LoadingFormStart(Me)

        Control_Initiallize()

        Grid_ModelList.Redraw = False

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_change_item_parts("
        strSQL += "0"
        strSQL += ", '" & TB_ItemLike.Text & "'"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim changeDate As String = sqlDR("change_parts")
            If Not changeDate = String.Empty Then
                changeDate = Format(CDate(changeDate), "yyyy-MM-dd HH:mm:ss")
            End If
            Dim insert_String As String = Grid_ModelList.Rows.Count
            insert_String += vbTab & sqlDR("model_code")
            insert_String += vbTab & sqlDR("item_code")
            insert_String += vbTab & changeDate
            Grid_ModelList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_ModelList.AutoSizeCols()
        Grid_ModelList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_ChangeList_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_ChangeList.MouseClick

        Dim selRow As Integer = Grid_ChangeList.MouseRow

        If selRow < 1 Then Exit Sub

        If e.Button = MouseButtons.Right Then
            Grid_ChangeList.Row = selRow
            Grid_Menu.Show(Grid_ChangeList, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub BTN_RowAdd_Click(sender As Object, e As EventArgs) Handles BTN_RowAdd.Click

        Grid_ChangeList.AddItem(Grid_ChangeList.Rows.Count)

    End Sub

    Private Sub BTN_RowDelete_Click(sender As Object, e As EventArgs) Handles BTN_RowDelete.Click

        If Grid_ChangeList.Rows.Count = 2 Then
            Grid_ChangeList.RemoveItem(Grid_ChangeList.Row)
            Grid_ChangeList.AddItem(Grid_ChangeList.Rows.Count)
        Else
            Grid_ChangeList.RemoveItem(Grid_ChangeList.Row)
        End If

        For i = 1 To Grid_ChangeList.Rows.Count - 1
            Grid_ChangeList(i, 0) = i
        Next

    End Sub

    Private Sub Grid_ChangeList_AfterEdit(sender As Object, e As RowColEventArgs) Handles Grid_ChangeList.AfterEdit

        Grid_ChangeList.AutoSizeCols()

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        If MSG_Question(Me, "저장 하시겠습니까?") = False Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        Grid_ChangeList.Redraw = False

        For i = 1 To Grid_ChangeList.Rows.Count - 1
            Grid_ChangeList(i, 3) = String.Empty
        Next

        Dim writeResult As String = DB_Write2()
        Thread_LoadingFormEnd()

        If Not writeResult.Equals("Success") And
                Not writeResult.Equals("Fail") Then
            MSG_Error(Me, writeResult)
            Exit Sub
        End If

        Grid_ChangeList.AutoSizeCols()
        Grid_ChangeList.Redraw = True

        MSG_Information(Me, "저장완료.")

        'Control_Initiallize()
        'TB_ItemLike.Text = String.Empty

    End Sub

    Private Function DB_Write2() As String

        If DBConnect() = False Then
            Return "Fail"
            Exit Function
        End If

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            For i = 1 To Grid_ChangeList.Rows.Count - 1
                If Not Grid_ChangeList(i, 1).Equals(String.Empty) And
                    Not Grid_ChangeList(i, 2).Equals(String.Empty) Then
                    For ii = 1 To Grid_ModelList.Rows.Count - 1
                        strSQL = "UPDATE tb_model_bom"
                        strSQL += " SET part_no = '" & Grid_ChangeList(i, 2) & "'"
                        strSQL += " WHERE model_code = '" & Grid_ModelList(ii, 1) & "'"
                        strSQL += " AND part_no = '" & Grid_ChangeList(i, 1) & "'"
                        strSQL += ";"

                        sqlCmd = New MySqlCommand(strSQL, dbConnection1)
                        sqlCmd.Transaction = sqlTran
                        Dim modifyRow As Integer = sqlCmd.ExecuteNonQuery()
                        If Grid_ChangeList(i, 3).Equals(String.Empty) Then
                            Grid_ChangeList(i, 3) = Format(modifyRow, "#,##0")
                        Else
                            Grid_ChangeList(i, 3) += ", " & Format(modifyRow, "#,##0")
                        End If
                    Next
                End If
            Next

            For i = 1 To Grid_ModelList.Rows.Count - 1
                strSQL = "update tb_model_list"
                strSQL += " set change_parts = '" & writeDate & "'"
                strSQL += " where model_code = '" & Grid_ModelList(i, 1) & "'"
                strSQL += ";"

                sqlCmd = New MySqlCommand(strSQL, dbConnection1)
                sqlCmd.Transaction = sqlTran
                sqlCmd.ExecuteNonQuery()
            Next

            sqlTran.Commit()
        Catch ex As MySqlException
            sqlTran.Rollback()
            DBClose()

            Return ex.Message
            Exit Function
        End Try

        DBClose()

        Return "Success"

    End Function

    Private Function DB_Write() As String

        If DBConnect() = False Then
            Return "Fail"
            Exit Function
        End If

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            For j = 1 To Grid_ChangeList.Rows.Count - 1
                strSQL += "UPDATE tb_model_bom"
                strSQL += " SET part_no = '" & Grid_ChangeList(j, 2) & "'"
                strSQL += " where (model_code = '" & Grid_ModelList(1, 1) & "'"
                If Grid_ChangeList.Rows.Count > 2 Then
                    For i = 2 To Grid_ModelList.Rows.Count - 1
                        strSQL += " or model_code = '" & Grid_ModelList(i, 1) & "'"
                    Next
                End If
                strSQL += ")"
                strSQL += " AND part_no = '" & Grid_ChangeList(j, 1) & "'"
                strSQL += ";"
            Next

            For i = 1 To Grid_ModelList.Rows.Count - 1
                strSQL += "update tb_model_list"
                strSQL += " set change_parts = '" & writeDate & "'"
                strSQL += " where model_code = '" & Grid_ModelList(i, 1) & "'"
                strSQL += ";"
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

            Return ex.Message
            Exit Function
        End Try

        DBClose()

        Return "Success"

    End Function

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub
End Class