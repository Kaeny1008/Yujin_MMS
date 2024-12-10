Imports C1.Win.C1FlexGrid
Imports MySqlConnector

Public Class frm_Production_Discard_Information

    Public discardIndex As String
    Public historyIndex As String

    Private Sub frm_Production_Discard_Information_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        Load_Basic_Information()

        Load_Material_Information()

    End Sub

    Private Sub Grid_Setting()

        With Grid_SMD_Bottom
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.Columns
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 6
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Cols(1).DataType = GetType(Boolean)
        End With

        Grid_SMD_Bottom(0, 0) = "No"
        Grid_SMD_Bottom(0, 1) = "선택"
        Grid_SMD_Bottom(0, 2) = "Part Code"
        Grid_SMD_Bottom(0, 3) = "사용수량"
        Grid_SMD_Bottom(0, 4) = "작업면"
        Grid_SMD_Bottom(0, 5) = "Type"

        Grid_SMD_Bottom.AutoSizeCols()

        With Grid_SMD_Top
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.Columns
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 6
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Cols(1).DataType = GetType(Boolean)
        End With

        Grid_SMD_Top(0, 0) = "No"
        Grid_SMD_Top(0, 1) = "선택"
        Grid_SMD_Top(0, 2) = "Part Code"
        Grid_SMD_Top(0, 3) = "사용수량"
        Grid_SMD_Top(0, 4) = "작업면"
        Grid_SMD_Top(0, 5) = "Type"

        Grid_SMD_Top.AutoSizeCols()

        With Grid_Dip
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.Columns
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 6
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Cols(1).DataType = GetType(Boolean)
        End With

        Grid_Dip(0, 0) = "No"
        Grid_Dip(0, 1) = "선택"
        Grid_Dip(0, 2) = "Part Code"
        Grid_Dip(0, 3) = "사용수량"
        Grid_Dip(0, 4) = "작업면"
        Grid_Dip(0, 5) = "Type"

        Grid_Dip.AutoSizeCols()

        With Grid_Etc
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.Columns
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 6
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Cols(1).DataType = GetType(Boolean)
        End With

        Grid_Etc(0, 0) = "No"
        Grid_Etc(0, 1) = "선택"
        Grid_Etc(0, 2) = "Part Code"
        Grid_Etc(0, 3) = "사용수량"
        Grid_Etc(0, 4) = "작업면"
        Grid_Etc(0, 5) = "Type"

        Grid_Etc.AutoSizeCols()

    End Sub

    Private Sub Load_Basic_Information()

        Thread_LoadingFormStart(Me)

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_discard_register(2"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & discardIndex & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_OrderIndex.Text = sqlDR("order_index")
            TB_Workside.Text = sqlDR("work_side")
            TB_CustomerName.Text = sqlDR("customer_name")
            TB_CustomerCode.Text = sqlDR("customer_code")
            TB_OrderQty.Text = sqlDR("modify_order_quantity")
            TB_ModelCode.Text = sqlDR("model_code")
            TB_ItemCode.Text = sqlDR("item_code")
            TB_ItemName.Text = sqlDR("item_name")
            TB_Inspector.Text = sqlDR("write_id")
            TB_Process.Text = sqlDR("process_name")
            TB_ManagementNo.Text = sqlDR("management_no")
            TB_BoardNo.Text = sqlDR("board_no")
            TB_Discard_Resone.Text = sqlDR("discard_reason")
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_Material_Information()

        Thread_LoadingFormStart(Me)

        Grid_SMD_Bottom.Redraw = False
        Grid_SMD_Top.Redraw = False
        Grid_Dip.Redraw = False
        Grid_Etc.Redraw = False

        Grid_SMD_Bottom.Rows.Count = 1
        Grid_SMD_Top.Rows.Count = 1
        Grid_Dip.Rows.Count = 1
        Grid_Etc.Rows.Count = 1

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_discard_register(3"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_ModelCode.Text & "'"
        strSQL += ", '" & TB_ManagementNo.Text & "'"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = String.Empty
            If sqlDR("part_type").ToString.ToUpper.Equals("SMD") And
                sqlDR("tb").ToString.ToUpper.Equals("BOTTOM") Then
                insertString = Grid_SMD_Bottom.Rows.Count
                insertString += vbTab
                insertString += vbTab & sqlDR("part_no")
                insertString += vbTab & sqlDR("use_count")
                insertString += vbTab & sqlDR("tb")
                insertString += vbTab & sqlDR("part_type")
                Grid_SMD_Bottom.AddItem(insertString)
            ElseIf sqlDR("part_type").ToString.ToUpper.Equals("SMD") And
                sqlDR("tb").ToString.ToUpper.Equals("TOP") Then
                insertString = Grid_SMD_Top.Rows.Count
                insertString += vbTab
                insertString += vbTab & sqlDR("part_no")
                insertString += vbTab & sqlDR("use_count")
                insertString += vbTab & sqlDR("tb")
                insertString += vbTab & sqlDR("part_type")
                Grid_SMD_Top.AddItem(insertString)
            ElseIf sqlDR("part_type").ToString.ToUpper.Equals("DIP") Then
                insertString = Grid_Dip.Rows.Count
                insertString += vbTab
                insertString += vbTab & sqlDR("part_no")
                insertString += vbTab & sqlDR("use_count")
                insertString += vbTab & sqlDR("tb")
                insertString += vbTab & sqlDR("part_type")
                Grid_Dip.AddItem(insertString)
            Else
                insertString = Grid_Etc.Rows.Count
                insertString += vbTab
                insertString += vbTab & sqlDR("part_no")
                insertString += vbTab & sqlDR("use_count")
                insertString += vbTab & sqlDR("tb")
                insertString += vbTab & sqlDR("part_type")
                Grid_Etc.AddItem(insertString)
            End If
        Loop
        sqlDR.Close()

        DBClose()

        Grid_SMD_Bottom.AutoSizeCols()
        Grid_SMD_Top.AutoSizeCols()
        Grid_Dip.AutoSizeCols()
        Grid_Etc.AutoSizeCols()

        Grid_SMD_Bottom.Redraw = True
        Grid_SMD_Top.Redraw = True
        Grid_Dip.Redraw = True
        Grid_Etc.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Dim selGrid As C1FlexGrid

    Private Sub Grid_Etc_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_Etc.MouseClick

        Dim selRow As Integer = Grid_Etc.MouseRow

        If selRow < 1 Then Exit Sub

        selGrid = Grid_Etc
        If e.Button = MouseButtons.Right Then
            BTN_Move_Dip.Enabled = True
            BTN_Move_SMD_Bottom.Enabled = True
            BTN_Move_SMD_Top.Enabled = True
            BTN_Move_ETC.Enabled = False
            Grid_Menu.Show(Grid_Etc, New Point(e.X, e.Y))
        ElseIf e.Button = MouseButtons.Left Then
            If Grid_Etc.GetCellCheck(selRow, 1) = CheckEnum.Checked Then
                Grid_Etc.SetCellCheck(selRow, 1, CheckEnum.Unchecked)
            Else
                Grid_Etc.SetCellCheck(selRow, 1, CheckEnum.Checked)
            End If
        End If

    End Sub

    Private Sub Grid_SMD_Bottom_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_SMD_Bottom.MouseClick

        Dim selRow As Integer = Grid_SMD_Bottom.MouseRow

        If selRow < 1 Then Exit Sub

        selGrid = Grid_SMD_Bottom
        If e.Button = MouseButtons.Right Then
            BTN_Move_Dip.Enabled = True
            BTN_Move_SMD_Bottom.Enabled = False
            BTN_Move_SMD_Top.Enabled = True
            BTN_Move_ETC.Enabled = True
            Grid_Menu.Show(Grid_SMD_Bottom, New Point(e.X, e.Y))
        ElseIf e.Button = MouseButtons.Left Then
            If Grid_SMD_Bottom.GetCellCheck(selRow, 1) = CheckEnum.Checked Then
                Grid_SMD_Bottom.SetCellCheck(selRow, 1, CheckEnum.Unchecked)
            Else
                Grid_SMD_Bottom.SetCellCheck(selRow, 1, CheckEnum.Checked)
            End If
        End If

    End Sub

    Private Sub Grid_SMD_Top_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_SMD_Top.MouseClick

        Dim selRow As Integer = Grid_SMD_Top.MouseRow

        If selRow < 1 Then Exit Sub

        selGrid = Grid_SMD_Top
        If e.Button = MouseButtons.Right Then
            BTN_Move_Dip.Enabled = True
            BTN_Move_SMD_Bottom.Enabled = True
            BTN_Move_SMD_Top.Enabled = False
            BTN_Move_ETC.Enabled = True
            Grid_Menu.Show(Grid_SMD_Top, New Point(e.X, e.Y))
        ElseIf e.Button = MouseButtons.Left Then
            If Grid_SMD_Top.GetCellCheck(selRow, 1) = CheckEnum.Checked Then
                Grid_SMD_Top.SetCellCheck(selRow, 1, CheckEnum.Unchecked)
            Else
                Grid_SMD_Top.SetCellCheck(selRow, 1, CheckEnum.Checked)
            End If
        End If

    End Sub

    Private Sub Grid_Dip_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_Dip.MouseClick

        Dim selRow As Integer = Grid_Dip.MouseRow

        If selRow < 1 Then Exit Sub

        selGrid = Grid_Dip
        If e.Button = MouseButtons.Right Then
            BTN_Move_Dip.Enabled = False
            BTN_Move_SMD_Bottom.Enabled = True
            BTN_Move_SMD_Top.Enabled = True
            BTN_Move_ETC.Enabled = True
            Grid_Menu.Show(Grid_Dip, New Point(e.X, e.Y))
        ElseIf e.Button = MouseButtons.Left Then
            If Grid_Dip.GetCellCheck(selRow, 1) = CheckEnum.Checked Then
                Grid_Dip.SetCellCheck(selRow, 1, CheckEnum.Unchecked)
            Else
                Grid_Dip.SetCellCheck(selRow, 1, CheckEnum.Checked)
            End If
        End If

    End Sub

    Private Sub BTN_Move_SMD_Bottom_Click(sender As Object, e As EventArgs) Handles BTN_Move_SMD_Bottom.Click,
        BTN_Move_SMD_Top.Click,
        BTN_Move_Dip.Click,
        BTN_Move_ETC.Click

        Dim grid As C1FlexGrid = Grid_SMD_Bottom

        If sender.ToString = "SMD Top 이동" Then
            grid = Grid_SMD_Top
        ElseIf sender.ToString = "Dip 이동" Then
            grid = Grid_Dip
        ElseIf sender.ToString = "기타 이동" Then
            grid = Grid_Etc
        End If

        Dim insertCount As Integer = 0

        grid.Redraw = False

        For i = selGrid.Rows.Count - 1 To 1 Step -1
            If selGrid.GetCellCheck(i, 1) = CheckEnum.Checked Then
                insertCount += 1
                Dim insertString As String = grid.Rows.Count
                insertString += vbTab
                insertString += vbTab & selGrid(i, 2)
                insertString += vbTab & selGrid(i, 3)
                insertString += vbTab & selGrid(i, 4)
                insertString += vbTab & selGrid(i, 5)
                grid.AddItem(insertString)
                selGrid.RemoveItem(i)
            End If
        Next

        grid.AutoSizeCols()
        grid.Redraw = True

        If insertCount = 0 Then
            MSG_Information(Me, "선택된 항목이 없습니다.")
        End If

    End Sub

    Private Sub BTN_Confirm_Click(sender As Object, e As EventArgs) Handles BTN_Confirm.Click

        If CB_SMD_Bottom.Checked = False And
            CB_SMD_Top.Checked = False And
            CB_Dip.Checked = False Then
            MSG_Information(Me, "Loss 처리할 항목이 선택되지 않았습니다.")
            Exit Sub
        End If

        If Grid_Etc.Rows.Count > 1 Then
            If MSG_Question(Me, "자동으로 찾지 못한 항목이 있습니다." & vbCrLf & "계속 진행 하시겠습니까?") = False Then Exit Sub
        End If

        If MSG_Question(Me, "폐기 승인 하시겠습니까?") = False Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        If DBConnect() = False Then Exit Sub

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

        Try

            If CB_SMD_Bottom.Checked = True Then
                strSQL += write_strSQL(Grid_SMD_Bottom, writeDate)
            End If
            If CB_SMD_Top.Checked = True Then
                strSQL += write_strSQL(Grid_SMD_Top, writeDate)
            End If
            If CB_Dip.Checked = True Then
                strSQL += write_strSQL(Grid_Dip, writeDate)
            End If

            strSQL += "update tb_mms_production_discard_list set confirm_date = '" & writeDate & "'"
            strSQL += ", confirm_id = '" & loginID & "'"
            strSQL += " where discard_index = '" & discardIndex & "';"

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

        MSG_Information(Me, "승인 되었습니다." & vbCrLf & "창이 닫힙니다.")

        Me.Dispose()

    End Sub

    Private Function write_strSQL(ByVal c1 As C1FlexGrid, ByVal writeDate As String) As String

        Dim strSQL As String = String.Empty

        For i = 1 To c1.Rows.Count - 1
            If c1.GetCellCheck(i, 1) = CheckEnum.Checked Then
                strSQL += "insert into tb_mms_material_discard("
                strSQL += "m_discard_index, discard_index, customer_code"
                strSQL += ", part_code, discard_quantity, write_date, write_id"
                strSQL += ")"
                strSQL += " select f_mms_material_discard_no('" & Format(Now, "yyyy-MM-dd") & "')"
                strSQL += ",'" & discardIndex & "'"
                strSQL += ",'" & TB_CustomerCode.Text & "'"
                strSQL += ",'" & c1(i, 2) & "'"
                strSQL += "," & c1(i, 3)
                strSQL += ",'" & writeDate & "'"
                strSQL += ",'" & loginID & "'"
                strSQL += ";"
            End If

            'Lot No.구분을 하지 못해 여기서 업데이트는 불가할듯 
            'strSQL += "update tb_mms_material_warehousing set available_qty = available_qty - " & c1(i, 3)
            'strSQL += " where customer_code = '" & TB_CustomerCode.Text & "'"
            'strSQL += " and part_code = '" & 
        Next

        Return strSQL

    End Function

    Private Sub BTN_Cancel_Click(sender As Object, e As EventArgs) Handles BTN_Cancel.Click

        If MSG_Question(Me, "폐기 거절 하시겠습니까?" & vbCrLf & "등록 내용이 사라지므로 양품으로 인계하십시오.") = False Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        If DBConnect() = False Then Exit Sub

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

        Try
            strSQL += "update tb_mms_production_discard_list set cancel_date = '" & writeDate & "'"
            strSQL += ", cancel_id = '" & loginID & "'"
            strSQL += " where discard_index = '" & discardIndex & "';"

            strSQL += "update tb_mms_order_register_list set discard_quantity = discard_quantity - 1"
            strSQL += " where order_index = '" & TB_OrderIndex.Text & "';"

            Dim tableName As String = "tb_mms_smd_production_history"

            If Not TB_Process.Text.ToUpper.Equals("SMD") Then
                tableName = "tb_mms_ws_output_history"
            End If

            strSQL += "update " & tableName & " set discard_quantity = discard_quantity - 1"
            strSQL += " where history_index = '" & historyIndex & "';"


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

        MSG_Information(Me, "거절 되었습니다." & vbCrLf & "창이 닫힙니다.")

        Me.Dispose()

    End Sub

    Private Sub CB_SMD_Bottom_CheckedChanged(sender As Object, e As EventArgs) Handles CB_SMD_Bottom.CheckedChanged

        Dim checkEnum As CheckEnum = CheckEnum.Checked

        If CB_SMD_Bottom.Checked = True Then
            checkEnum = CheckEnum.Checked
        Else
            checkEnum = CheckEnum.Unchecked
        End If

        For i = 1 To Grid_SMD_Bottom.Rows.Count - 1
            Grid_SMD_Bottom.SetCellCheck(i, 1, checkEnum)
        Next

    End Sub

    Private Sub CB_SMD_Top_CheckedChanged(sender As Object, e As EventArgs) Handles CB_SMD_Top.CheckedChanged

        Dim checkEnum As CheckEnum = CheckEnum.Checked

        If CB_SMD_Top.Checked = True Then
            checkEnum = CheckEnum.Checked
        Else
            checkEnum = CheckEnum.Unchecked
        End If

        For i = 1 To Grid_SMD_Top.Rows.Count - 1
            Grid_SMD_Top.SetCellCheck(i, 1, checkEnum)
        Next

    End Sub

    Private Sub CB_Dip_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Dip.CheckedChanged

        Dim checkEnum As CheckEnum = CheckEnum.Checked

        If CB_Dip.Checked = True Then
            checkEnum = CheckEnum.Checked
        Else
            checkEnum = CheckEnum.Unchecked
        End If

        For i = 1 To Grid_Dip.Rows.Count - 1
            Grid_Dip.SetCellCheck(i, 1, checkEnum)
        Next

    End Sub
End Class