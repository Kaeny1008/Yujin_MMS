'############################################################################################################
'############################################################################################################

'##### 작성일자 : 2024-02-15
'##### 수정일자 : 2024-02-15
'##### 수정자   : 박시현
'##### 참고     : 
'##### 설명     : 고객사별 모델을 등록 한다.

'############################################################################################################

Imports System.Threading
Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_ModelResistration
    Private Sub frm_CustomerResistration_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        Timer1.Interval = 1000
        Timer1.Enabled = False

    End Sub

    Private Sub Grid_Setting()

        With grid_ModelList
            .AllowEditing = True
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 9
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            grid_ModelList(0, 0) = "No"
            grid_ModelList(0, 1) = "모델코드(*)"
            grid_ModelList(0, 2) = "고객사 코드(*)"
            grid_ModelList(0, 3) = "고객사명"
            grid_ModelList(0, 4) = "SPG"
            grid_ModelList(0, 5) = "품번(*)"
            grid_ModelList(0, 6) = "품명"
            grid_ModelList(0, 7) = "규격"
            grid_ModelList(0, 8) = "비고"
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            .ExtendLastCol = True
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
        End With

    End Sub

    Private Sub grid_ModelList_RowColChange(sender As Object, e As EventArgs) Handles grid_ModelList.RowColChange

        If grid_ModelList.Row < 0 Then Exit Sub

        Select Case grid_ModelList.Col
            Case 1, 2
                grid_ModelList.AllowEditing = False
                'grid_ModelList.Cols(4).ComboList = load_ModelSeries(grid_ModelList(grid_ModelList.Row, 2))
            Case Else
                If IsNothing(grid_ModelList(grid_ModelList.Row, 0)) Then Exit Sub
                If grid_ModelList(grid_ModelList.Row, 0).ToString.Equals("D") Then
                    grid_ModelList.AllowEditing = False
                Else
                    grid_ModelList.AllowEditing = True
                End If
        End Select

        grid_ModelList.Cols(4).ComboList = load_ModelSeries(grid_ModelList(grid_ModelList.Row, 2))
        load_CustomerList(grid_ModelList(grid_ModelList.Row, 3))

    End Sub

    Private Sub grid_ModelList_BeforeEdit(sender As Object, e As RowColEventArgs) Handles grid_ModelList.BeforeEdit

        before_griddata = grid_ModelList(e.Row, e.Col)

    End Sub

    Private Sub grid_ModelList_AfterEdit(sender As Object, e As RowColEventArgs) Handles grid_ModelList.AfterEdit

        If grid_ModelList(e.Row, 0).Equals("D") Then Exit Sub

        If before_griddata = grid_ModelList(e.Row, e.Col) Then Exit Sub

        grid_ModelList.Redraw = False

        If IsNumeric(grid_ModelList(e.Row, 0)) Then
            grid_ModelList(e.Row, 0) = "M"
        End If

        Dim cs As CellStyle = grid_ModelList.Styles.Add("Yellow_Cell")
        cs.BackColor = Color.Yellow
        cs.ForeColor = Color.Red
        Dim cs2 As CellStyle = grid_ModelList.Styles.Add("Normal_Cell")
        cs2.BackColor = Color.White
        cs2.ForeColor = Color.Black

        grid_ModelList.SetCellStyle(e.Row, e.Col, cs)

        Select Case e.Col
            Case 3
                grid_ModelList.SetCellStyle(e.Row, 2, cs)
                grid_ModelList(e.Row, 2) = load_CustomerCode(grid_ModelList(e.Row, 3))
                grid_ModelList.Cols(4).ComboList = load_ModelSeries(grid_ModelList(e.Row, 2))
                For i = 4 To grid_ModelList.Cols.Count - 1
                    grid_ModelList.SetCellStyle(e.Row, i, cs2)
                    grid_ModelList(e.Row, i) = String.Empty
                Next
        End Select

        grid_ModelList.AutoSizeCols()

        grid_ModelList.Redraw = True

    End Sub

    Private Function load_CustomerCode(ByVal customerName As String) As String

        DBConnect()

        Dim strSQL As String = "select customer_code"
        strSQL += " From tb_customer_list"
        strSQL += " where customer_name = '" & customerName & "'"
        strSQL += " order By customer_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Dim customerCode As String = String.Empty

        Do While sqlDR.Read
            customerCode = sqlDR("customer_code")
        Loop
        sqlDR.Close()

        DBClose()

        Return customerCode

    End Function

    Private Sub grid_ModelList_MouseClick(sender As Object, e As MouseEventArgs) Handles grid_ModelList.MouseClick

        If grid_ModelList.Row > 0 And
                e.Button = MouseButtons.Right Then
            Dim selRow As Integer = grid_ModelList.Row

            cms_Menu.Show(grid_ModelList, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub btn_RowDelete_Click(sender As Object, e As EventArgs) Handles btn_RowDelete.Click

        MessageBox.Show(Me,
                        "현재 삭제 기능을 사용할 수 없습니다." & vbCrLf & "(모델 자료 삭제 기능 제작필요)",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
        Exit Sub

        Dim sel_Row As Integer = grid_ModelList.Row

        If grid_ModelList(sel_Row, 0).ToString = "N" Then
            grid_ModelList.RemoveItem(sel_Row)
        Else
            grid_ModelList(sel_Row, 0) = "D"
            grid_ModelList.Rows(sel_Row).StyleNew.ForeColor = Color.LightGray
        End If

    End Sub

    Private Sub grid_ModelList_KeyDown(sender As Object, e As KeyEventArgs) Handles grid_ModelList.KeyDown

        If grid_ModelList(grid_ModelList.Row, 0).Equals("D") Then
            MsgBox("삭제 대기중인 모델 내용은 수정 할 수 없습니다.",
                   MsgBoxStyle.Information,
                   msg_form)
        End If

    End Sub

    Private Sub grid_ModelList_MouseMove(sender As Object, e As MouseEventArgs) Handles grid_ModelList.MouseMove

        If grid_ModelList.MouseRow > -1 Then
            Timer1.Enabled = False
            Timer1.Enabled = True
            Select Case grid_ModelList.MouseCol
                Case 1
                    ToolTip1.SetToolTip(grid_ModelList,
                                        "모델 코드는 자동으로 입력되며 수정할 수 없습니다.")
                Case 2
                    ToolTip1.SetToolTip(grid_ModelList,
                                        "고객사 코드는 자동으로 입력되며 수정할 수 없습니다.")
                Case Else
                    ToolTip1.SetToolTip(grid_ModelList, String.Empty)
            End Select
        Else
            ToolTip1.SetToolTip(grid_ModelList, String.Empty)
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ToolTip1.SetToolTip(grid_ModelList, String.Empty)
        Timer1.Enabled = False

    End Sub

    Private Sub tb_SearchText_KeyDown(sender As Object, e As KeyEventArgs) Handles tb_SearchCustomer.KeyDown,
            tb_SearchModel.KeyDown

        If e.KeyCode = 13 Then
            btn_Search_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub btn_NewCustomer_Click(sender As Object, e As EventArgs) Handles btn_NewCustomer.Click

        Dim customerCode As String = newModelCode()

        grid_ModelList.AddItem("N" & vbTab &
            customerCode)
        grid_ModelList.TopRow = grid_ModelList.Rows.Count - 1
        grid_ModelList.Rows(grid_ModelList.Rows.Count - 1).StyleNew.ForeColor = Color.Blue
        grid_ModelList.Select(grid_ModelList.Rows.Count - 1, 3)

        grid_ModelList.Redraw = False
        load_CustomerList(Nothing)
        grid_ModelList.AutoSizeCols()
        grid_ModelList.Redraw = True

    End Sub

    Private Function newModelCode() As String

        newModelCode = String.Empty

        DBConnect()

        Dim strSQL As String = "select model_code from tb_model_list order by model_code desc limit 1"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            newModelCode = sqlDR("model_code")
        Loop
        sqlDR.Close()

        DBClose()

        If newModelCode = String.Empty Then
            newModelCode = "MC00000001"
        Else
            Dim addOrder As Integer = CInt(newModelCode.Substring(2, 8)) + 1
            newModelCode = "MC" & Format(addOrder, "00000000")
        End If

        Dim last_code() As Integer = {}
        ReDim last_code(grid_ModelList.Rows.Count - 1)

        For i = 1 To grid_ModelList.Rows.Count - 1
            last_code(i) = grid_ModelList(i, 1).ToString.Substring(2, 8)
        Next

        If Not last_code.Length = 0 Then
            Dim first_code As String = newModelCode.Substring(0, 2)
            Dim second_code As Integer = newModelCode.Substring(2, 8)
            If second_code <= last_code.Max Then
                newModelCode = first_code + Format(last_code.Max + 1, "00000000")
            End If
        End If

        Return newModelCode

    End Function

    Private Sub load_CustomerList(ByVal orgCustomer As String)

        DBConnect()

        Dim strSQL As String = "select customer_name"
        strSQL += " From tb_customer_list"
        strSQL += " order By customer_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Dim customerList As String = String.Empty

        Do While sqlDR.Read
            If customerList = String.Empty Then
                customerList = sqlDR("customer_name")
            Else
                customerList += "|" & sqlDR("customer_name")
            End If
        Loop
        sqlDR.Close()

        DBClose()

        grid_ModelList.Cols(3).ComboList = customerList

    End Sub

    Private Function load_ModelSeries(ByVal customer_code) As String

        DBConnect()

        Dim strSQL As String = "select spg"
        strSQL += " From tb_customer_list"
        strSQL += " where customer_code = '" & customer_code & "'"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        load_ModelSeries = String.Empty

        Do While sqlDR.Read
            load_ModelSeries = sqlDR("spg")
        Loop
        sqlDR.Close()

        DBClose()

        Console.WriteLine(load_ModelSeries)

        Return load_ModelSeries

    End Function

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click,
            btn_Save2.Click

        For i = 1 To grid_ModelList.Rows.Count - 1
            If grid_ModelList(i, 2) = String.Empty Then
                MsgBox("고객사명이 입력력되지 않은 항목이 있습니다.",
                       vbInformation,
                       msg_form)
                Exit Sub
            ElseIf grid_ModelList(i, 5) = String.Empty Then
                MsgBox("모델명이 입력력되지 않은 항목이 있습니다.",
                       vbInformation,
                       msg_form)
                Exit Sub
            End If
        Next

        If MsgBox("저장 하시겠습니까?",
                  MsgBoxStyle.Question + MsgBoxStyle.YesNo,
                  msg_form) = MsgBoxResult.No Then Exit Sub

        Thread_LoadingFormStart("Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            For i = 1 To grid_ModelList.Rows.Count - 1
                If grid_ModelList(i, 0).ToString = "N" Then
                    strSQL += "insert into tb_model_list(model_code, customer_code, spg"
                    strSQL += ", item_code, item_name, item_spec, item_note, write_date, write_id) values("
                    strSQL += "'" & grid_ModelList(i, 1) & "'"
                    strSQL += ",'" & grid_ModelList(i, 2) & "'"
                    strSQL += ",'" & Replace(grid_ModelList(i, 4), "'", "\'") & "'"
                    strSQL += ",'" & Replace(grid_ModelList(i, 5), "'", "\'") & "'"
                    strSQL += ",'" & Replace(grid_ModelList(i, 6), "'", "\'") & "'"
                    strSQL += ",'" & Replace(grid_ModelList(i, 7), "'", "\'") & "'"
                    strSQL += ",'" & grid_ModelList(i, 8) & "'"
                    strSQL += ",'" & writeDate & "'"
                    strSQL += ",'" & loginID & "');"
                ElseIf grid_ModelList(i, 0).ToString = "M" Then
                    strSQL += "update tb_model_list set"
                    strSQL += " customer_code = '" & grid_ModelList(i, 2) & "'"
                    strSQL += ", spg = '" & Replace(grid_ModelList(i, 4), "'", "\'") & "'"
                    strSQL += ", item_code = '" & Replace(grid_ModelList(i, 5), "'", "\'") & "'"
                    strSQL += ", item_name = '" & Replace(grid_ModelList(i, 6), "'", "\'") & "'"
                    strSQL += ", item_spec = '" & Replace(grid_ModelList(i, 7), "'", "\'") & "'"
                    strSQL += ", item_note = '" & grid_ModelList(i, 8) & "'"
                    strSQL += ", modify_date = '" & writeDate & "'"
                    strSQL += ", modify_id = '" & loginID & "'"
                    strSQL += " where model_code = '" & grid_ModelList(i, 1) & "';"
                ElseIf grid_ModelList(i, 0).ToString = "D" Then
                    strSQL += "delete from tb_model_list"
                    strSQL += " where model_code = '" & grid_ModelList(i, 1) & "';"
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
            MessageBox.Show(Me,
                            ex.Message,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

        DBClose()

        Thread_LoadingFormEnd()
        MessageBox.Show(Me,
                        "저장완료.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1)

        btn_Search_Click(Nothing, Nothing)

    End Sub

    Private Sub btn_Search_Click(sender As Object, e As EventArgs) Handles btn_Search.Click

        Thread_LoadingFormStart()

        grid_ModelList.Redraw = False
        grid_ModelList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "select a.model_code, a.customer_code, a.spg, a.item_code, a.item_name, a.item_spec, a.item_note, b.customer_name"
        strSQL += " from tb_model_list a"
        strSQL += " left join tb_customer_list b on a.customer_code = b.customer_code"
        strSQL += " where (a.customer_code like concat('%', '" & tb_SearchCustomer.Text & "', '%')"
        strSQL += " or b.customer_name like concat('%', '" & tb_SearchCustomer.Text & "', '%'))"
        strSQL += " and (a.model_code like concat('%', '" & tb_SearchModel.Text & "', '%')"
        strSQL += " or a.item_code like concat('%', '" & tb_SearchModel.Text & "', '%'))"
        strSQL += " order by a.item_code"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = grid_ModelList.Rows.Count & vbTab &
                                          sqlDR("model_code") & vbTab &
                                          sqlDR("customer_code") & vbTab &
                                          sqlDR("customer_name") & vbTab &
                                          sqlDR("spg") & vbTab &
                                          sqlDR("item_code") & vbTab &
                                          sqlDR("item_name") & vbTab &
                                          sqlDR("item_spec") & vbTab &
                                          sqlDR("item_note")
            grid_ModelList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        grid_ModelList.AutoSizeCols()
        grid_ModelList.Redraw = True

        thread_LoadingFormEnd()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub
End Class