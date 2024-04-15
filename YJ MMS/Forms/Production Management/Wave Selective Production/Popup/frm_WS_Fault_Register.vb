Imports System.IO
Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_WS_Fault_Register
    Private Sub frm_WS_Fault_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
            '.ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            '.Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            '.Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            '.SelectionMode = SelectionModeEnum.Default
            .Cols(1).Visible = False
            .Cols(3).ComboList = "공정불량|원자재불량"
            .Cols(5).DataType = GetType(Integer)
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

        DBConnect()

        Dim strSQL As String = "call sp_mms_wave_selective_production(7"
        strSQL += ", '" & LB_OrderIndex.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
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
                sqlDR("ws_inspector") & vbTab &
                sqlDR("defect_note")

            GridWriteText(insertString, Me, Grid_Fault, Color.Black)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_Fault.AutoSizeCols()
        Grid_Fault.Redraw = True

    End Sub

    Private Sub frm_WS_Fault_Register_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

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
                    CStr(Grid_Fault(i, 5)) = String.Empty Or
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
                If WriteData(i) = False Then Exit Sub

                Exit For
            End If
        Next

        frm_Wave_Selective_Production_Inspection.Load_InspectList()

        Me.Dispose()

    End Sub

    'Private Sub PrintLabel(ByVal writeDate As String, ByVal rowNum As Integer)

    '    If File.Exists(Application.StartupPath & "\print.txt") Then File.Delete(Application.StartupPath & "\print.txt")

    '    Dim swFile As StreamWriter =
    '        New StreamWriter(Application.StartupPath & "\print.txt", True, System.Text.Encoding.GetEncoding(949))

    '    swFile.WriteLine("^XZ~JA^XZ")
    '    swFile.WriteLine("^XA^LH" & printerLeftPosition & ",0^LT" & printerTopPosition) 'LH : 가로위치, LT : 세로위치
    '    swFile.WriteLine("^MD25") '진하기
    '    swFile.WriteLine("^SEE:UHANGUL.DAT^FS")
    '    swFile.WriteLine("^CW1,E:KFONT3.FNT^CI26^FS")

    '    swFile.WriteLine("^FO0008,0162^GB0694,0302,2,B,1^FS")

    '    swFile.WriteLine("^FO0008,0200^GB0694,0000,2,B,0^FS")
    '    swFile.WriteLine("^FO0008,0238^GB0694,0000,2,B,0^FS")
    '    swFile.WriteLine("^FO0008,0276^GB0694,0000,2,B,0^FS")

    '    swFile.WriteLine("^FO0162,0162^GB0000,0302,2,B,0^FS")
    '    swFile.WriteLine("^FO0352,0200^GB0000,0076,2,B,0^FS")
    '    swFile.WriteLine("^FO0510,0200^GB0000,0076,2,B,0^FS")

    '    swFile.WriteLine("^FO0380,0008^A1N,70,50^FD불량현황^FS")
    '    swFile.WriteLine("^FO0172,0080^A0,40,20^FDItemCode : ^FS")
    '    swFile.WriteLine("^FO0264,0080^A0,40,20^FD" & LB_ItemCode.Text & "^FS")
    '    swFile.WriteLine("^FO0172,0120^A0,40,20^FDItemName : ^FS")
    '    swFile.WriteLine("^FO0272,0120^A0,40,20^FD" & LB_ItemName.Text & "^FS")

    '    swFile.WriteLine("^FO0016,0170^A0,30,20^FDPO No.^FS")
    '    swFile.WriteLine("^FO0170,0170^A0,30,20^FD" & LB_OrderIndex.Text & "^FS")

    '    swFile.WriteLine("^FO0016,0208^A0,30,20^FDSMD Line^FS")
    '    swFile.WriteLine("^FO0170,0208^A0,30,20^FD" & LB_SMDLine.Text & "^FS")
    '    swFile.WriteLine("^FO0360,0208^A0,30,20^FDTop / Bottom^FS")
    '    swFile.WriteLine("^FO0518,0208^A0,30,20^FD" & LB_WorkSide.Text & "^FS")

    '    swFile.WriteLine("^FO0016,0246^A0,30,20^FDSMD Date^FS")
    '    swFile.WriteLine("^FO0170,0246^A0,30,18^FD" & writeDate & "^FS")
    '    swFile.WriteLine("^FO0016,0284^A1N,30,20^FD불량내용^FS")
    '    swFile.WriteLine("^FO0170,0284^A1N,30,18^FD구분 : " & Grid_Fault(rowNum, 3) & "^FS")
    '    swFile.WriteLine("^FO0170,0324^A1N,30,20^FD불량명 : " & Grid_Fault(rowNum, 4) & "^FS")
    '    swFile.WriteLine("^FO0170,0364^A1N,30,20^FDArray : " & Grid_Fault(rowNum, 5) & "^FS")
    '    swFile.WriteLine("^FO0170,0404^A1N,30,20^FDRef : " & Grid_Fault(rowNum, 6) & "^FS")

    '    swFile.WriteLine("^FO020,0020^BXN,3,200,44,44^FD" & LB_OrderIndex.Text & "!" & Grid_Fault(rowNum, 1) & "^FS")

    '    swFile.WriteLine("^PQ" & 1 & "^FS") 'PQ : 발행수량
    '    swFile.WriteLine("^XZ")
    '    swFile.Close()

    '    Dim printResult As String = LabelPrint()

    '    If Not printResult = "Success" Then
    '        MessageBox.Show(frm_Main,
    '                        "라벨 발행에 실패 하였습니다." & vbCrLf &
    '                        printResult,
    '                        msg_form,
    '                        MessageBoxButtons.OK,
    '                        MessageBoxIcon.Error)
    '    End If

    'End Sub

    Private Function WriteData(ByVal rowNum As Integer) As Boolean

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
        Try
            strSQL = "insert into tb_mms_ws_defect("
            strSQL += "defect_index, order_index, defect_classification, defect_name, board_array, ref, defect_note"
            strSQL += ", write_date, write_id, history_index, ws_inspector, board_no"
            strSQL += ") values ("
            strSQL += "'" & Grid_Fault(rowNum, 1) & "'"
            strSQL += ",'" & LB_OrderIndex.Text & "'"
            strSQL += ",'" & Grid_Fault(rowNum, 3) & "'"
            strSQL += ",'" & Grid_Fault(rowNum, 4) & "'"
            strSQL += ",'" & Grid_Fault(rowNum, 5) & "'"
            strSQL += ",'" & Grid_Fault(rowNum, 6) & "'"
            strSQL += ",'" & Grid_Fault(rowNum, 8) & "'"
            strSQL += ",'" & writeDate & "'"
            strSQL += ",'" & loginID & "'"
            strSQL += ",'" & LB_HistoryIndex.Text & "'"
            strSQL += ",'" & Grid_Fault(rowNum, 7) & "'"
            strSQL += ",'" & Grid_Fault(rowNum, 2) & "'"
            strSQL += ");"

            strSQL += "update tb_mms_ws_output_history set "
            strSQL += " fault_quantity = fault_quantity + 1"
            strSQL += " where history_index = '" & LB_HistoryIndex.Text & "';"

            If Grid_Fault.Rows.Count = 2 Then
                strSQL += "update tb_mms_ws_output_history set "
                strSQL += " ws_inspector = '" & frm_Wave_Selective_Production_Inspection.TB_Inspector.Text & "'"
                strSQL += " where history_index = '" & LB_HistoryIndex.Text & "';"
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

        '현재는 사용하지 않음
        'PrintLabel(writeDate, rowNum)

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
                           frm_Wave_Selective_Production_Inspection.TB_Inspector.Text)
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

        Thread_LoadingFormStart()

        DBConnect()

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

        Thread_LoadingFormStart()

        DBConnect()

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
End Class