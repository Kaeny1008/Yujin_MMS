Imports System.IO
Imports C1.Win.C1FlexGrid
Imports MySqlConnector

Public Class frm_OQC_Falult_Register
    Private Sub frm_SMD_Fault_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.TopMost = True

        Grid_Setting()

        Load_DefectList()

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
            .Cols.Count = 9
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = True
            .ShowCursor = True
            .Cols(1).Visible = False
            .Cols(3).ComboList = "공정불량|원자재불량"
            .Cols(5).DataType = GetType(Integer)
            .Cols(5).Visible = False
        End With

        Grid_Fault(0, 0) = "No"
        Grid_Fault(0, 1) = "defect_index"
        Grid_Fault(0, 2) = "Board No."
        Grid_Fault(0, 3) = "불량구분"
        Grid_Fault(0, 4) = "불량명"
        Grid_Fault(0, 5) = "Array No."
        Grid_Fault(0, 6) = "Ref(Location)"
        Grid_Fault(0, 7) = "Inspector"
        Grid_Fault(0, 8) = "비고"

        Grid_Fault.AutoSizeCols()

    End Sub

    Private Sub Load_DefectList()

        Grid_Fault.Redraw = False
        Grid_Fault.Rows.Count = 1

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_oqc(5"
        strSQL += ", '" & LB_OrderIndex.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = Grid_Fault.Rows.Count & vbTab &
                sqlDR("defect_index") & vbTab &
                sqlDR("board_no") & vbTab &
                sqlDR("defect_classification") & vbTab &
                sqlDR("defect_name") & vbTab &
                sqlDR("board_array") & vbTab &
                sqlDR("ref") & vbTab &
                sqlDR("oqc_inspector") & vbTab &
                sqlDR("defect_note")

            GridWriteText(insertString, Me, Grid_Fault, Color.Black)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_Fault.AutoSizeCols()
        Grid_Fault.Redraw = True

    End Sub

    Private Sub frm_SMD_Fault_Register_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Console.WriteLine("KeyValue : " & e.KeyValue & ", KeyCode : " & e.KeyCode)

        If e.KeyCode = 112 Then
            BTN_RowAdd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = 114 Then

        End If

    End Sub

    Private Sub BTN_Exit_Click(sender As Object, e As EventArgs) Handles BTN_Exit.Click

        For i = 1 To Grid_Fault.Rows.Count - 1
            If Grid_Fault(i, 0) = "N" Then
                If Grid_Fault(i, 1) = String.Empty Or
                    Grid_Fault(i, 2) = String.Empty Or
                    Grid_Fault(i, 3) = String.Empty Or
                    Grid_Fault(i, 4) = String.Empty Or
                    Grid_Fault(i, 6) = String.Empty Then
                    If MessageBox.Show("필수 입력값이 누락되었습니다." &
                                       vbCrLf &
                                       "저장하지 않고 창을 닫으시겠습니까?",
                                       msg_form,
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question) = DialogResult.Yes Then
                        Me.Dispose()
                        Exit Sub
                    Else
                        Exit Sub
                    End If
                End If
                'If WriteData(i) = False Then Exit Sub
                'Exit For
            End If
        Next

        If WriteData() = False Then Exit Sub

        'frm_SMD_Production_End.CB_Line_SelectionChangeCommitted(Nothing, Nothing)

        Me.Dispose()

    End Sub

    Private Function WriteData() As Boolean

        If DBConnect() = False Then
            Return False
            Exit Function
        End If

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
        Try
            For i = 1 To Grid_Fault.Rows.Count - 1
                If Grid_Fault(i, 0) = "N" Then
                    strSQL += "insert into tb_mms_oqc_defect("
                    strSQL += "defect_index, order_index, defect_classification, defect_name, board_array, ref, defect_note"
                    strSQL += ", write_date, write_id, history_index, oqc_inspector, board_no"
                    strSQL += ") values ("
                    strSQL += "'" & Grid_Fault(i, 1) & "'"
                    strSQL += ",'" & LB_OrderIndex.Text & "'"
                    strSQL += ",'" & Grid_Fault(i, 3) & "'"
                    strSQL += ",'" & Grid_Fault(i, 4) & "'"
                    strSQL += ",'" & Grid_Fault(i, 5) & "'"
                    strSQL += ",'" & Grid_Fault(i, 6) & "'"
                    strSQL += ",'" & Grid_Fault(i, 8) & "'"
                    strSQL += ",'" & writeDate & "'"
                    strSQL += ",'" & loginID & "'"
                    strSQL += ",'" & LB_HistoryIndex.Text & "'"
                    strSQL += ",'" & Grid_Fault(i, 7) & "'"
                    strSQL += ",'" & Grid_Fault(i, 2) & "'"
                    strSQL += ");"
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
            Return False
        End Try

        DBClose()

        Return True

    End Function

    Private Sub BTN_RowAdd_Click(sender As Object, e As EventArgs) Handles BTN_RowAdd.Click

        Grid_Fault.AddItem("N" & vbTab &
                           Format(Now, "yyMMddHHmmssfff") & vbTab &
                           vbTab &
                           vbTab &
                           vbTab &
                           vbTab &
                           vbTab &
                           frm_OQC_Register.TB_Inspector.Text)
        Grid_Fault.AutoSizeCols()

    End Sub

    Dim beforeString As String

    Private Sub Grid_Fault_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Grid_Fault.BeforeEdit

        beforeString = Grid_Fault(e.Row, e.Col)

    End Sub

    Private Sub Grid_Fault_AfterEdit(sender As Object, e As RowColEventArgs) Handles Grid_Fault.AfterEdit

        If e.Row < 0 Or e.Col < 0 Then Exit Sub

        If beforeString = Grid_Fault(e.Row, e.Col) Then Exit Sub

        Select Case e.Col
            Case 3
                '불량구분이 변경되었고 SMD불량이라면 불량명을 불러온다.
                If Grid_Fault(e.Row, 3) = "공정불량" Then
                    Grid_Fault(e.Row, 4) = String.Empty
                    Load_ComboList_SMD_Fault()
                Else
                    Grid_Fault(e.Row, 4) = String.Empty
                    Load_ComboList_Material_Fault()
                End If
            Case 2
                Grid_Fault(e.Row, 5) = Grid_Fault(e.Row, 2).ToString.Substring(Grid_Fault(e.Row, 2).ToString.Length - 2, 2)
        End Select

        Grid_Fault.AutoSizeCols()

    End Sub

    Private Sub Grid_Fault_RowColChange(sender As Object, e As EventArgs) Handles Grid_Fault.RowColChange

        If Grid_Fault.Row < 0 Then Exit Sub

        If Grid_Fault(Grid_Fault.Row, 0) = "N" Then
            Grid_Fault.AllowEditing = True
        Else
            Grid_Fault.AllowEditing = False
        End If

    End Sub

    Private Sub Load_ComboList_SMD_Fault()

        Thread_LoadingFormStart(Me)

        If DBConnect() = False Then Exit Sub

        Dim comboList As String = "|"

        Dim strSQL As String = "call sp_mms_smd_production_end(1"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
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

        Grid_Fault.Cols(4).ComboList = comboList

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_ComboList_Material_Fault()

        Thread_LoadingFormStart(Me)

        If DBConnect() = False Then Exit Sub

        Dim comboList As String = "|"

        Dim strSQL As String = "call sp_mms_smd_production_end(2"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
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

        Grid_Fault.Cols(4).ComboList = comboList

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_Fault_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_Fault.MouseClick

        Dim selRow As Integer = Grid_Fault.MouseRow

        If selRow > 0 And e.Button = MouseButtons.Right Then
            Grid_Fault.Row = selRow
            If Grid_Fault(selRow, 0) = "N" Then
                BTN_RowDelete.Enabled = True
            Else
                BTN_RowDelete.Enabled = False
            End If
            Grid_Menu.Show(Grid_Fault, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub BTN_RowDelete_Click(sender As Object, e As EventArgs) Handles BTN_RowDelete.Click

    End Sub
End Class