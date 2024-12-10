'############################################################################################################

'작성일자 : 2019-08-27
'수정일자 : 2019-08-27
'수정자   : 박시현
'참고     : 
'설명     : 기준 코드를 관리하는 폼

'############################################################################################################

Imports C1.Win.C1FlexGrid
Imports MySqlConnector

Public Class frm_Code_Manager

    Dim form_Msgbox_String As String = "Code 관리"

    Private Sub CODE_MANAGER_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GRID_Setting()

        SplitContainer2.SplitterDistance = SplitContainer2.Width / 2+300

    End Sub

    Private Sub GRID_Setting()

        With grid_MainCode
            .AllowEditing = True
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 5
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            grid_MainCode(0, 0) = "No"
            grid_MainCode(0, 1) = "등록일자"
            grid_MainCode(0, 2) = "Code"
            grid_MainCode(0, 3) = "이름"
            grid_MainCode(0, 4) = "비고"
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            .AutoSizeCols()
            .ShowCursor = True
        End With

        With grid_SubCode
            .AllowEditing = True
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 5
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            grid_SubCode(0, 0) = "No"
            grid_SubCode(0, 1) = "등록일자"
            grid_SubCode(0, 2) = "Code"
            grid_SubCode(0, 3) = "이름"
            grid_SubCode(0, 4) = "비고"
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            .AutoSizeCols()
            .ShowCursor = True
        End With

        With grid_LastCode
            .AllowEditing = True
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 5
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            grid_LastCode(0, 0) = "No"
            grid_LastCode(0, 1) = "등록일자"
            grid_LastCode(0, 2) = "Code"
            grid_LastCode(0, 3) = "이름"
            grid_LastCode(0, 4) = "비고"
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            .AutoSizeCols()
            .ShowCursor = True
        End With

    End Sub

    Private Sub GRID_MouseClick(sender As Object, e As MouseEventArgs) Handles grid_MainCode.MouseClick,
                                                                               grid_SubCode.MouseClick,
                                                                               grid_LastCode.MouseClick

        Dim sel_grid As C1FlexGrid = CType(sender, C1FlexGrid)
        Dim row As Integer = sel_grid.MouseRow

        If e.Button = MouseButtons.Right And row > -1 Then
            sel_grid.Row = row
            'If sel_grid.AllowEditing = False And sel_grid.Name = GRID_main_code.Name Then
            '    BTN_Row_Add.Enabled = False
            '    BTN_Row_Delete.Enabled = False
            'Else
            '    BTN_Row_Add.Enabled = True
            '    BTN_Row_Delete.Enabled = True
            'End If
            GRID_Menu.Show(sel_grid, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub ROW_Index(ByVal sel_grid As C1FlexGrid)

        For i = 1 To sel_grid.Rows.Count - 1
            If IsNumeric(sel_grid(i, 0)) Then
                sel_grid(i, 0) = i
            Else
                If sel_grid(i, 0).ToString = "N" Then
                    sel_grid.Rows(i).StyleNew.ForeColor = Color.Blue
                ElseIf sel_grid(i, 0).ToString = "M" Then
                    sel_grid.Rows(i).StyleNew.ForeColor = Color.Red
                ElseIf sel_grid(i, 0).ToString = "D" Then
                    sel_grid.Rows(i).StyleNew.ForeColor = Color.DarkGray
                End If
            End If
        Next

        sel_grid.AutoSizeCols()

    End Sub

    Private Sub BTN_Row_Add_Click(sender As Object, e As EventArgs) Handles btn_Row_Add.Click

        Dim sel_grid As C1FlexGrid = CType(GRID_Menu.SourceControl, C1FlexGrid)

        If sel_grid.Name = grid_SubCode.Name Then
            If Label1.Text = "상위 Code : " Then
                MsgBox("먼저 상위 Code를 선택하여 주십시오.", MsgBoxStyle.Information, form_Msgbox_String)
                Exit Sub
            End If
        End If

        Dim main_code As String = Split(Label1.Text, " : ")(1)
        'If main_code = "MC00000001" Then
        '    MsgBox("신규 추가할 수 없습니다.", MsgBoxStyle.Information, form_Msgbox_String)
        '    Exit Sub
        'End If

        Dim new_code As String = String.Empty

        If sel_grid.Name = grid_MainCode.Name Then
            new_code = Code_Maker("Main")
        ElseIf sel_grid.Name = grid_SubCode.Name Then
            new_code = Code_Maker("Sub")
        ElseIf sel_grid.Name = grid_LastCode.Name Then
            new_code = Code_Maker("Last")
        End If


        sel_grid.AddItem("N" & vbTab &
                         Format(Now, "yyyy-MM-dd HH:mm:ss") & vbTab &
                         new_code, sel_grid.Row + 1)

        ROW_Index(sel_grid)

    End Sub

    Private Function Code_Maker(ByVal main_sub As String) As String

        Code_Maker = String.Empty

        If DBConnect() = False Then
            Return Code_Maker
            Exit Function
        End If

        Dim strSQL As String = String.Empty

        If main_sub = "Main" Then
            strSQL = "select main_code as last_code from tb_code_main"
            strSQL += " order by main_code desc limit 1;"
        ElseIf main_sub = "Sub" Then
            strSQL = "select sub_code as last_code from tb_code_sub"
            strSQL += " where sub_code like 'SC%'"
            strSQL += " order by sub_code desc limit 1;"
        ElseIf main_sub = "Last" Then
            strSQL = "select last_code as last_code from tb_code_last"
            strSQL += " where last_code like 'LC%'"
            strSQL += " order by last_code desc limit 1;"
        End If

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Code_Maker = sqlDR("last_code")
        Loop
        sqlDR.Close()

        DBClose()

        If Code_Maker = String.Empty Then
            If main_sub = "Main" Then
                Code_Maker = "MC00000001"
            ElseIf main_sub = "Sub" Then
                Code_Maker = "SC00000001"
            ElseIf main_sub = "Last" Then
                Code_Maker = "LC00000001"
            End If
        Else
            Dim first_code As String = Code_Maker.Substring(0, 2)
            Dim second_code As Integer = Code_Maker.Substring(2, 8)
            Code_Maker = first_code + Format(second_code + 1, "00000000")
        End If

        Dim last_code() As Integer = {}

        If main_sub = "Main" Then
            ReDim last_code(grid_MainCode.Rows.Count - 1)
            For i = 1 To grid_MainCode.Rows.Count - 1
                last_code(i) = grid_MainCode(i, 2).ToString.Substring(2, 8)
            Next
        ElseIf main_sub = "Sub" Then
            ReDim last_code(grid_SubCode.Rows.Count - 1)
            For i = 1 To grid_SubCode.Rows.Count - 1
                last_code(i) = grid_SubCode(i, 2).ToString.Substring(2, 8)
            Next
        ElseIf main_sub = "Last" Then
            ReDim last_code(grid_LastCode.Rows.Count - 1)
            For i = 1 To grid_LastCode.Rows.Count - 1
                last_code(i) = grid_LastCode(i, 2).ToString.Substring(2, 8)
            Next
        End If

        If Not last_code.Length = 0 Then
            Dim first_code As String = Code_Maker.Substring(0, 2)
            Dim second_code As Integer = Code_Maker.Substring(2, 8)
            If second_code <= last_code.Max Then
                Code_Maker = first_code + Format(last_code.Max + 1, "00000000")
            End If
        End If

        Return Code_Maker

    End Function

    Private Sub BTN_Row_Delete_Click(sender As Object, e As EventArgs) Handles btn_Row_Delete.Click

        Dim main_code As String = Split(Label1.Text, " : ")(1)
        If main_code = "MC0001" Then
            MsgBox("삭제할 수 없습니다.", MsgBoxStyle.Information, form_Msgbox_String)
            Exit Sub
        End If

        Dim sel_grid As C1FlexGrid = CType(GRID_Menu.SourceControl, C1FlexGrid)

        If sel_grid(sel_grid.Row, 0).ToString = "N" Then
            sel_grid.RemoveItem(sel_grid.Row)
        Else
            sel_grid(sel_grid.Row, 0) = "D"
        End If

        ROW_Index(sel_grid)

    End Sub

    Dim before_text_Main As String
    Dim before_text_Sub As String
    Dim before_text_Last As String

    Private Sub GRID_sub_code_BeforeEdit(sender As Object, e As RowColEventArgs) Handles grid_SubCode.BeforeEdit

        before_text_Sub = grid_SubCode(e.Row, e.Col)

    End Sub

    Private Sub GRID_sub_code_AfterEdit(sender As Object, e As RowColEventArgs) Handles grid_SubCode.AfterEdit

        If before_text_Sub = grid_SubCode(e.Row, e.Col) Then Exit Sub

        If IsNumeric(grid_SubCode(e.Row, 0)) Then
            grid_SubCode(e.Row, 0) = "M"
        End If

        ROW_Index(grid_SubCode)

        grid_SubCode.AutoSizeCols()

    End Sub

    Private Sub GRID_main_code_BeforeEdit(sender As Object, e As RowColEventArgs) Handles grid_MainCode.BeforeEdit

        before_text_Main = grid_MainCode(e.Row, e.Col)

    End Sub

    Private Sub GRID_main_code_AfterEdit(sender As Object, e As RowColEventArgs) Handles grid_MainCode.AfterEdit

        If before_text_Main = grid_MainCode(e.Row, e.Col) Then Exit Sub

        If IsNumeric(grid_MainCode(e.Row, 0)) Then
            grid_MainCode(e.Row, 0) = "M"
        End If

        ROW_Index(grid_MainCode)

        grid_MainCode.AutoSizeCols()

    End Sub

    Private Sub GRID_last_code_BeforeEdit(sender As Object, e As RowColEventArgs) Handles grid_LastCode.BeforeEdit

        before_text_Last = grid_LastCode(e.Row, e.Col)

    End Sub

    Private Sub GRID_last_code_AfterEdit(sender As Object, e As RowColEventArgs) Handles grid_LastCode.AfterEdit

        If before_text_Last = grid_LastCode(e.Row, e.Col) Then Exit Sub

        If IsNumeric(grid_LastCode(e.Row, 0)) Then
            grid_LastCode(e.Row, 0) = "M"
        End If

        ROW_Index(grid_LastCode)

        grid_LastCode.AutoSizeCols()

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click

        Dim sel_grid As C1FlexGrid = CType(GRID_Menu.SourceControl, C1FlexGrid)

        If sel_grid.Name = grid_MainCode.Name Then
            DB_Write_Main()
        ElseIf sel_grid.Name = grid_SubCode.Name Then
            DB_Write_Sub()
        ElseIf sel_grid.Name = grid_LastCode.Name Then
            DB_Write_Last()
        End If

    End Sub

    Private Sub DB_Write_Main()

        If MsgBox("저장 하시겠습니까?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, form_Msgbox_String) = MsgBoxResult.No Then Exit Sub

        If DBConnect() = False Then Exit Sub

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            For i = 1 To grid_MainCode.Rows.Count - 1
                If grid_MainCode(i, 0).ToString = "N" Then
                    strSQL += "insert into tb_code_main(write_date, main_code, main_code_name, main_code_note) values"
                    strSQL += "('" & Format(CDate(grid_MainCode(i, 1)), "yyyy-MM-dd HH:mm:ss") & "'"
                    strSQL += ",'" & grid_MainCode(i, 2) & "'"
                    strSQL += ",'" & grid_MainCode(i, 3) & "'"
                    strSQL += ",'" & grid_MainCode(i, 4) & "');"
                ElseIf grid_MainCode(i, 0).ToString = "M" Then
                    strSQL += "update tb_code_main set write_date = '" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "'"
                    strSQL += ", main_code_name ='" & grid_MainCode(i, 3) & "'"
                    strSQL += ", main_code_note ='" & grid_MainCode(i, 4) & "'"
                    strSQL += " where main_code = '" & grid_MainCode(i, 2) & "';"
                ElseIf grid_MainCode(i, 0).ToString = "D" Then
                    strSQL += "delete from tb_code_main where main_code = '" & grid_MainCode(i, 2) & "';"
                    strSQL += "delete from tb_code_sub where main_code = '" & grid_MainCode(i, 2) & "';"
                    strSQL += "delete from tb_code_last where main_code = '" & grid_MainCode(i, 2) & "';"
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, form_Msgbox_String)
            Exit Sub
        End Try

        DBClose()

        MsgBox("저장완료.", MsgBoxStyle.Information, form_Msgbox_String)

        BTN_Search_Click(Nothing, Nothing)

    End Sub

    Private Sub DB_Write_Sub()

        If MsgBox("저장 하시겠습니까?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, form_Msgbox_String) = MsgBoxResult.No Then Exit Sub

        If DBConnect() = False Then Exit Sub

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            Dim main_code As String = Split(Label1.Text, " : ")(1)

            If main_code = "MC0001" Then
                For i = 1 To grid_SubCode.Rows.Count - 1
                    If grid_SubCode(i, 0).ToString = "M" Then
                        strSQL += "update tb_code_sub set write_date = '" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "'"
                        strSQL += ", sub_code_NAME ='" & grid_SubCode(i, 3) & "'"
                        strSQL += ", sub_code_NOTE ='" & grid_SubCode(i, 4) & "'"
                        strSQL += " where sub_code = '" & grid_SubCode(i, 2) & "';"

                        strSQL += "update TB_CUSTOMER_LIST set customer_name = '" & grid_SubCode(i, 3) & "'"
                        strSQL += ", write_date = '" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "'"
                        strSQL += ", write_id = '" & loginID & "'"
                        strSQL += " where customer_code = '" & grid_SubCode(i, 2) & "';"
                    End If
                Next
            Else
                For i = 1 To grid_SubCode.Rows.Count - 1
                    If grid_SubCode(i, 0).ToString = "N" Then
                        strSQL += "insert into tb_code_sub(write_date, sub_code, sub_code_NAME, sub_code_NOTE, main_code) values"
                        strSQL += "('" & Format(CDate(grid_SubCode(i, 1)), "yyyy-MM-dd HH:mm:ss") & "'"
                        strSQL += ",'" & grid_SubCode(i, 2) & "'"
                        strSQL += ",'" & grid_SubCode(i, 3) & "'"
                        strSQL += ",'" & grid_SubCode(i, 4) & "'"
                        strSQL += ",'" & main_code & "');"
                    ElseIf grid_SubCode(i, 0).ToString = "M" Then
                        strSQL += "update tb_code_sub set write_date = '" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "'"
                        strSQL += ", sub_code_NAME ='" & grid_SubCode(i, 3) & "'"
                        strSQL += ", sub_code_NOTE ='" & grid_SubCode(i, 4) & "'"
                        strSQL += " where sub_code = '" & grid_SubCode(i, 2) & "';"
                    ElseIf grid_SubCode(i, 0).ToString = "D" Then
                        strSQL += "delete from tb_code_sub where sub_code = '" & grid_SubCode(i, 2) & "';"
                        strSQL += "delete from tb_code_last where sub_code = '" & grid_SubCode(i, 2) & "';"
                    End If
                Next
            End If

            If Not strSQL = String.Empty Then
                sqlCmd = New MySqlCommand(strSQL, dbConnection1)
                sqlCmd.Transaction = sqlTran
                sqlCmd.ExecuteNonQuery()

                sqlTran.Commit()
            End If
        Catch ex As MySqlException
            sqlTran.Rollback()
            MsgBox(ex.Message, MsgBoxStyle.Critical, form_Msgbox_String)
            Exit Sub
        End Try

        DBClose()

        MsgBox("저장완료.", MsgBoxStyle.Information, form_Msgbox_String)
        BTN_Search_Click(Nothing, Nothing)

    End Sub

    Private Sub DB_Write_Last()

        If MsgBox("저장 하시겠습니까?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, form_Msgbox_String) = MsgBoxResult.No Then Exit Sub

        If DBConnect() = False Then Exit Sub

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            Dim main_code As String = Split(Label1.Text, " : ")(1)
            Dim sub_code As String = Split(Label4.Text, " : ")(1)

            If main_code = "MC0001" Then
                For i = 1 To grid_LastCode.Rows.Count - 1
                    If grid_LastCode(i, 0).ToString = "M" Then
                        strSQL += "update tb_code_last set write_date = '" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "'"
                        strSQL += ", last_code_name ='" & grid_LastCode(i, 3) & "'"
                        strSQL += ", last_code_note ='" & grid_LastCode(i, 4) & "'"
                        strSQL += " where last_code = '" & grid_LastCode(i, 2) & "';"

                        strSQL += "update tb_mmps_model_list set model_name = '" & grid_LastCode(i, 3) & "'"
                        strSQL += ", write_date = '" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "'"
                        strSQL += ", write_id = '" & loginID & "'"
                        strSQL += " where model_code = '" & grid_LastCode(i, 2) & "';"
                    ElseIf grid_LastCode(i, 0).ToString = "D" Then
                        '삭제 금지
                        '신규 추가 금지
                        'strSQL += "delete from tb_code_last where last_code = '" & GRID_last_code(i, 2) & "';"
                    End If
                Next
            Else
                For i = 1 To grid_LastCode.Rows.Count - 1
                    If grid_LastCode(i, 0).ToString = "N" Then
                        strSQL += "insert into tb_code_last(write_date, last_code, last_code_name, last_code_note, sub_code, main_code) values"
                        strSQL += "('" & Format(CDate(grid_LastCode(i, 1)), "yyyy-MM-dd HH:mm:ss") & "'"
                        strSQL += ",'" & grid_LastCode(i, 2) & "'"
                        strSQL += ",'" & grid_LastCode(i, 3) & "'"
                        strSQL += ",'" & grid_LastCode(i, 4) & "'"
                        strSQL += ",'" & sub_code & "'"
                        strSQL += ",'" & main_code & "');"
                    ElseIf grid_LastCode(i, 0).ToString = "M" Then
                        strSQL += "update tb_code_last set write_date = '" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "'"
                        strSQL += ", last_code_name ='" & grid_LastCode(i, 3) & "'"
                        strSQL += ", last_code_note ='" & grid_LastCode(i, 4) & "'"
                        strSQL += " where last_code = '" & grid_LastCode(i, 2) & "';"
                    ElseIf grid_LastCode(i, 0).ToString = "D" Then
                        strSQL += "delete from tb_code_last where last_code = '" & grid_LastCode(i, 2) & "';"
                    End If
                Next
            End If

            If Not strSQL = String.Empty Then
                sqlCmd = New MySqlCommand(strSQL, dbConnection1)
                sqlCmd.Transaction = sqlTran
                sqlCmd.ExecuteNonQuery()

                sqlTran.Commit()
            End If
        Catch ex As MySqlException
            sqlTran.Rollback()
            MsgBox(ex.Message, MsgBoxStyle.Critical, form_Msgbox_String)
            Exit Sub
        End Try

        DBClose()

        MsgBox("저장완료.", MsgBoxStyle.Information, form_Msgbox_String)
        BTN_Search_Click(Nothing, Nothing)

    End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles btn_Search.Click

        grid_SubCode.Rows.Count = 1
        grid_LastCode.Rows.Count = 1
        Label1.Text = "상위 Code : "
        Label4.Text = "상위 Code : "

        grid_MainCode.Redraw = False
        grid_MainCode.Rows.Count = 1

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "select write_date, main_code, main_code_name, main_code_note from tb_code_main"

        If Not tb_Code.Text = String.Empty Then
            strSQL += " where main_code like '%" & tb_Code.Text & "%'"
        End If

        If Not tb_Name.Text = String.Empty Then
            If tb_Code.Text = String.Empty Then
                strSQL += " where main_code_name like '%" & tb_Name.Text & "%'"
            Else
                strSQL += " and main_code_name like '%" & tb_Name.Text & "%'"
            End If
        End If

        strSQL += " order by main_code_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_string As String = grid_MainCode.Rows.Count & vbTab &
                                          Format(sqlDR("write_date"), "yyyy-MM-dd HH:mm:ss") & vbTab &
                                          sqlDR("main_code") & vbTab &
                                          sqlDR("main_code_name") & vbTab &
                                          sqlDR("main_code_note")
            grid_MainCode.AddItem(insert_string)
        Loop
        sqlDR.Close()

        DBClose()

        grid_MainCode.AutoSizeCols()
        grid_MainCode.Redraw = True

    End Sub

    Private Sub GRID_main_code_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles grid_MainCode.MouseDoubleClick

        Dim row As Integer = grid_MainCode.MouseRow

        If row < 1 Then Exit Sub

        Label1.Text = "상위 Code : " & grid_MainCode(row, 2)

        sub_code_Load(grid_MainCode(row, 2))

    End Sub

    Private Sub sub_code_Load(ByVal main_code As String)

        grid_LastCode.Rows.Count = 1
        Label4.Text = "상위 Code : "
        grid_SubCode.Redraw = False
        grid_SubCode.Rows.Count = 1

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "select write_date, sub_code, sub_code_NAME, sub_code_NOTE from tb_code_sub"
        strSQL += " where main_code = '" & main_code & "' order by sub_code_NAME"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_string As String = grid_SubCode.Rows.Count & vbTab &
                                          Format(sqlDR("write_date"), "yyyy-MM-dd HH:mm:ss") & vbTab &
                                          sqlDR("sub_code") & vbTab &
                                          sqlDR("sub_code_NAME") & vbTab &
                                          sqlDR("sub_code_NOTE")
            grid_SubCode.AddItem(insert_string)
        Loop
        sqlDR.Close()

        DBClose()

        grid_SubCode.AutoSizeCols()
        grid_SubCode.Redraw = True

    End Sub

    Private Sub GRID_sub_code_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles grid_SubCode.MouseDoubleClick

        Dim row As Integer = grid_SubCode.MouseRow

        If row < 1 Then Exit Sub

        Label4.Text = "상위 Code : " & grid_SubCode(row, 2)

        last_code_Load(grid_SubCode(row, 2))

    End Sub

    Private Sub last_code_Load(ByVal sub_code As String)

        grid_LastCode.Redraw = False
        grid_LastCode.Rows.Count = 1

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "select write_date, last_code, last_code_name, last_code_note from tb_code_last"
        strSQL += " where sub_code = '" & sub_code & "' order by last_code_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_string As String = grid_LastCode.Rows.Count & vbTab &
                                          Format(sqlDR("write_date"), "yyyy-MM-dd HH:mm:ss") & vbTab &
                                          sqlDR("last_code") & vbTab &
                                          sqlDR("last_code_name") & vbTab &
                                          sqlDR("last_code_note")
            grid_LastCode.AddItem(insert_string)
        Loop
        sqlDR.Close()

        DBClose()

        grid_LastCode.AutoSizeCols()
        grid_LastCode.Redraw = True

    End Sub

    Private Sub ToolStrip1_MouseDoubleClick(sender As Object, e As MouseEventArgs)

        If grid_MainCode.AllowEditing = True Then grid_MainCode.AllowEditing = False

        If InputBox("비밀번호를 입력하여 주십시오." & vbCrLf & "(힌트:개발자)", "상위코드 수정") = "qkrtlgus" Then
            grid_MainCode.AllowEditing = True
        End If

    End Sub

    Private Sub CODE_MANAGER_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = 112 Then 'F1
            If grid_SubCode.Focused Then
                GRID_Menu.Show(grid_SubCode, New Point(0, 0))
                BTN_Row_Add_Click(Nothing, Nothing)
                GRID_Menu.Close()
            End If
        End If

    End Sub

    Private Sub GRID_RowColChange(sender As Object, e As EventArgs) Handles grid_SubCode.RowColChange,
                                                                            grid_MainCode.RowColChange,
                                                                            grid_LastCode.RowColChange

        Dim c1f As C1FlexGrid = CType(sender, C1FlexGrid)

        Select Case c1f.Col
            Case 1, 2
                c1f.AllowEditing = False
            Case Else
                c1f.AllowEditing = True
        End Select

    End Sub

    Private Sub CodeManager_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        frm_Main.form_name = Me

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub
End Class