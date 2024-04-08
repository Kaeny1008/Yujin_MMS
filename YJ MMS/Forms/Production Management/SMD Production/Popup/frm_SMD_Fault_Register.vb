Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_SMD_Fault_Register
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
            .Cols.Count = 7
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = True
            .ShowCursor = True
            '.ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            '.Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            '.Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            '.SelectionMode = SelectionModeEnum.Default
            .Cols(1).Visible = False
            .Cols(2).ComboList = "SMD불량|원자재불량"
        End With

        Grid_Fault(0, 0) = "No"
        Grid_Fault(0, 1) = "FalutIndex"
        Grid_Fault(0, 2) = "불량구분"
        Grid_Fault(0, 3) = "불량명"
        Grid_Fault(0, 4) = "Ref(Location)"
        Grid_Fault(0, 5) = "Inspector"
        Grid_Fault(0, 6) = "비고"

        Grid_Fault.autosizecols

    End Sub

    Private Sub Load_DefectList()

        Grid_Fault.Redraw = False
        Grid_Fault.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_smd_production_end(4"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & Label2.Text & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = Grid_Fault.Rows.Count & vbTab &
                sqlDR("defect_index") & vbTab &
                sqlDR("defect_classification") & vbTab &
                sqlDR("defect_name") & vbTab &
                sqlDR("ref") & vbTab &
                sqlDR("smd_inspector") & vbTab &
                sqlDR("defect_note")

            GridWriteText(insertString, Me, Grid_Fault, Color.Black)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_Fault.AutoSizeCols()
        Grid_Fault.Redraw = True

    End Sub

    Private Sub frm_SMD_Fault_Register_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        Console.WriteLine("KeyValue : " & e.KeyValue & ", KeyCode : " & e.KeyCode)

        If e.KeyCode = 112 Then
            BTN_RowAdd_Click(Nothing, Nothing)
        ElseIf e.KeyCode = 114 Then

        End If

    End Sub

    Private Sub BTN_Exit_Click(sender As Object, e As EventArgs) Handles BTN_Exit.Click

        For i = 1 To Grid_Fault.Rows.Count - 1
            If Grid_Fault(i, 0) = "N" Then
                If Grid_Fault(i, 2) = String.Empty Or
                    Grid_Fault(i, 3) = String.Empty Or
                    Grid_Fault(i, 4) = String.empty Then
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
                If WriteData(i) = False Then Exit Sub
                Exit For
            End If
        Next

        frm_SMD_Production_End.BTN_LineSelect_Click(Nothing, Nothing)

        Me.Dispose()

    End Sub

    Private Function WriteData(ByVal rowNum As Integer) As Boolean

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            strSQL = "insert into tb_mms_smd_defect("
            strSQL += "defect_index, order_index, defect_classification, defect_name, ref, defect_note"
            strSQL += ", write_date, write_id, history_index, smd_inspector"
            strSQL += ") values ("
            strSQL += "'" & Grid_Fault(rowNum, 1) & "'"
            strSQL += ",'" & Label1.Text & "'"
            strSQL += ",'" & Grid_Fault(rowNum, 2) & "'"
            strSQL += ",'" & Grid_Fault(rowNum, 3) & "'"
            strSQL += ",'" & Grid_Fault(rowNum, 4) & "'"
            strSQL += ",'" & Grid_Fault(rowNum, 6) & "'"
            strSQL += ",'" & writeDate & "'"
            strSQL += ",'" & loginID & "'"
            strSQL += ",'" & Label2.Text & "'"
            strSQL += ",'" & Grid_Fault(rowNum, 5) & "'"
            strSQL += ");"

            strSQL += "update tb_mms_smd_production_history set "
            strSQL += " fault_quantity = fault_quantity + 1"
            strSQL += " where history_index = '" & Label2.Text & "';"

            If Grid_Fault.Rows.Count = 2 Then
                strSQL += "update tb_mms_smd_production_history set "
                strSQL += " smd_inspecter = '" & frm_SMD_Production_End.TB_Inspector.Text & "'"
                strSQL += " where history_index = '" & Label2.Text & "';"
            End If

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
                           Format(Now, "yyMMddHHmmssfff") &
                           vbTab &
                           vbTab &
                           vbTab &
                           vbTab &
                           frm_SMD_Production_End.TB_Inspector.Text)
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
            Case 2
                '불량구분이 변경되었고 SMD불량이라면 불량명을 불러온다.
                If Grid_Fault(e.Row, 2) = "SMD불량" Then
                    Grid_Fault(e.Row, 3) = String.Empty
                    Load_ComboList_SMD_Fault()
                Else
                    Grid_Fault(e.Row, 3) = String.Empty
                    Load_ComboList_Material_Fault()
                End If
        End Select

        Grid_Fault.autosizecols

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

        Thread_LoadingFormStart()

        DBConnect()

        Dim comboList As String = "|"

        Dim strSQL As String = "call sp_mms_smd_production_end(1"
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

        Grid_Fault.Cols(3).ComboList = comboList

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_ComboList_Material_Fault()

        Thread_LoadingFormStart()

        DBConnect()

        Dim comboList As String = "|"

        Dim strSQL As String = "call sp_mms_smd_production_end(2"
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

        Grid_Fault.Cols(3).ComboList = comboList

        Thread_LoadingFormEnd()

    End Sub
End Class