'############################################################################################################
'############################################################################################################

'##### 작성일자 : 2024-02-15
'##### 수정일자 : 2024-02-15
'##### 수정자   : 박시현
'##### 참고     : 
'##### 설명     : 고객사를 등록 한다.

'############################################################################################################

Imports System.Threading
Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_CustomerResistration
    Private Sub frm_CustomerResistration_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

    End Sub

    Private Sub Grid_Setting()

        With grid_CustomerList
            .AllowEditing = True
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 6
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            grid_CustomerList(0, 0) = "No"
            grid_CustomerList(0, 1) = "고객코드"
            grid_CustomerList(0, 2) = "고객사명"
            grid_CustomerList(0, 3) = "모델구분(구분자 ;)"
            grid_CustomerList(0, 4) = "등록 모델 수"
            grid_CustomerList(0, 5) = "비고"
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

    Private Sub btn_NewCustomer_Click(sender As Object, e As EventArgs) Handles btn_NewCustomer.Click

        Dim customerCode As String = newCustomerCode()

        grid_CustomerList.AddItem("N" & vbTab &
            customerCode)
        grid_CustomerList.TopRow = grid_CustomerList.Rows.Count - 1
        grid_CustomerList.Rows(grid_CustomerList.Rows.Count - 1).StyleNew.ForeColor = Color.Blue
        grid_CustomerList.Select(grid_CustomerList.Rows.Count - 1, 2)

        grid_CustomerList.Redraw = False
        grid_CustomerList.AutoSizeCols()
        grid_CustomerList.Redraw = True

    End Sub

    Private Sub grid_CustomerList_RowColChange(sender As Object, e As EventArgs) Handles grid_CustomerList.RowColChange

        Select Case grid_CustomerList.Col
            Case 1, 4
                grid_CustomerList.AllowEditing = False
            Case Else
                grid_CustomerList.AllowEditing = True
        End Select

        If grid_CustomerList.Row < 1 Then Exit Sub

        Select Case grid_CustomerList(grid_CustomerList.Row, 0)
            Case "D"
                grid_CustomerList.AllowEditing = False
            Case Else
                grid_CustomerList.AllowEditing = True
        End Select

    End Sub

    Private Sub grid_CustomerList_AfterEdit(sender As Object, e As RowColEventArgs) Handles grid_CustomerList.AfterEdit

        If grid_CustomerList(e.Row, 0).Equals("D") Then Exit Sub

        grid_CustomerList.Redraw = False

        If IsNumeric(grid_CustomerList(e.Row, 0)) Then
            grid_CustomerList(e.Row, 0) = "M"
        End If

        Dim cs As CellStyle = grid_CustomerList.Styles.Add("red")
        cs.BackColor = Color.Yellow

        grid_CustomerList.SetCellStyle(e.Row, e.Col, cs)
        grid_CustomerList.Rows(e.Row).StyleNew.ForeColor = Color.Red
        grid_CustomerList.AutoSizeCols()

        grid_CustomerList.Redraw = True

    End Sub

    Private Function newCustomerCode() As String

        newCustomerCode = String.Empty

        DBConnect()

        Dim strSQL As String = "select customer_code from tb_customer_list order by customer_code desc limit 1"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            newCustomerCode = sqlDR("customer_code")
        Loop
        sqlDR.Close()

        DBClose()

        If newCustomerCode = String.Empty Then
            newCustomerCode = "CC00000001"
        Else
            Dim addOrder As Integer = CInt(newCustomerCode.Substring(2, 8)) + 1
            newCustomerCode = "CC" & Format(addOrder, "00000000")
        End If

        Dim last_code() As Integer = {}
        ReDim last_code(grid_CustomerList.Rows.Count - 1)

        For i = 1 To grid_CustomerList.Rows.Count - 1
            last_code(i) = grid_CustomerList(i, 1).ToString.Substring(2, 8)
        Next

        If Not last_code.Length = 0 Then
            Dim first_code As String = newCustomerCode.Substring(0, 2)
            Dim second_code As Integer = newCustomerCode.Substring(2, 8)
            If second_code <= last_code.Max Then
                newCustomerCode = first_code + Format(last_code.Max + 1, "00000000")
            End If
        End If

        Return newCustomerCode

    End Function

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click,
            btn_Save2.Click

        For i = 1 To grid_CustomerList.Rows.Count - 1
            If grid_CustomerList(i, 2) = String.Empty Then
                MsgBox("고객사명이 이력되지 않은 항목이 있습니다.",
                       vbInformation,
                       msg_form)
                Exit Sub
            End If
        Next

        If MsgBox("저장 하시겠습니까?",
                  MsgBoxStyle.Question + MsgBoxStyle.YesNo,
                  msg_form) = MsgBoxResult.No Then Exit Sub

        thread_LoadingFormStart()

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            For i = 1 To grid_CustomerList.Rows.Count - 1
                If grid_CustomerList(i, 0).ToString = "N" Then
                    strSQL += "insert into tb_customer_list(customer_code, customer_name, model_gubun"
                    strSQL += ", customer_note, write_date, write_id) values("
                    strSQL += "'" & grid_CustomerList(i, 1) & "'"
                    strSQL += ", '" & grid_CustomerList(i, 2) & "'"
                    strSQL += ", '" & grid_CustomerList(i, 3) & "'"
                    strSQL += ", '" & grid_CustomerList(i, 5) & "'"
                    strSQL += ", '" & writeDate & "'"
                    strSQL += ", '" & loginID & "');"
                ElseIf grid_CustomerList(i, 0).ToString = "M" Then
                    strSQL += "update tb_customer_list set"
                    strSQL += " customer_name = '" & grid_CustomerList(i, 2) & "'"
                    strSQL += ", model_gubun = '" & grid_CustomerList(i, 3) & "'"
                    strSQL += ", customer_note = '" & grid_CustomerList(i, 5) & "'"
                    strSQL += ", write_date = '" & writeDate & "'"
                    strSQL += ", write_id = '" & loginID & "'"
                    strSQL += " where customer_code = '" & grid_CustomerList(i, 1) & "';"
                ElseIf grid_CustomerList(i, 0).ToString = "D" Then
                    strSQL += "delete from tb_customer_list"
                    strSQL += " where customer_code = '" & grid_CustomerList(i, 1) & "';"
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, msg_form)
            Exit Sub
        End Try

        DBClose()

        thread_LoadingFormEnd()
        Thread.Sleep(100)
        MsgBox("저장완료.", MsgBoxStyle.Information, msg_form)

        btn_Search_Click(Nothing, Nothing)

    End Sub

    Private Sub btn_Search_Click(sender As Object, e As EventArgs) Handles btn_Search.Click

        thread_LoadingFormStart()

        grid_CustomerList.Redraw = False
        grid_CustomerList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "select customer_code, customer_name, model_gubun, customer_note"
        strSQL += " from tb_customer_list"
        strSQL += " order by customer_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = grid_CustomerList.Rows.Count & vbTab &
                                          sqlDR("customer_code") & vbTab &
                                          sqlDR("customer_name") & vbTab &
                                          sqlDR("model_gubun") & vbTab &
                                          vbTab &
                                          sqlDR("customer_note")
            grid_CustomerList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        grid_CustomerList.AutoSizeCols()
        grid_CustomerList.Redraw = True

        thread_LoadingFormEnd()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub grid_CustomerList_MouseClick(sender As Object, e As MouseEventArgs) Handles grid_CustomerList.MouseClick

        If grid_CustomerList.Row > 0 And
                e.Button = MouseButtons.Right Then
            Dim selRow As Integer = grid_CustomerList.Row

            cms_Menu.Show(grid_CustomerList, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub btn_RowDelete_Click(sender As Object, e As EventArgs) Handles btn_RowDelete.Click

        Dim sel_Row As Integer = grid_CustomerList.Row

        If grid_CustomerList(sel_Row, 0).ToString = "N" Then
            grid_CustomerList.RemoveItem(sel_Row)
        Else
            grid_CustomerList(sel_Row, 0) = "D"
            grid_CustomerList.Rows(sel_Row).StyleNew.ForeColor = Color.LightGray
        End If

    End Sub

    Private Sub grid_CustomerList_KeyDown(sender As Object, e As KeyEventArgs) Handles grid_CustomerList.KeyDown

        If grid_CustomerList(grid_CustomerList.Row, 0).Equals("D") Then
            MsgBox("삭제 대기중인 고객사 내용은 수정 할 수 없습니다.",
                   MsgBoxStyle.Information,
                   msg_form)
        End If

    End Sub
End Class