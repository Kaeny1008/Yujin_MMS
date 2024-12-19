Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Wave_Selective_Production_First_Start
    Private Sub frm_Wave_Selective_Production_First_Start_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub Grid_Setting()

        With Grid_OrderList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.None
            .Cols.Count = 11
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .Rows(0).Height = 40
            .Rows.DefaultSize = 30
            .Cols(1).Visible = True
            .Cols(3).Visible = True
            .Cols(9).DataType = GetType(Date)
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .Cols(9).TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            '.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
            '.DragMode = C1.Win.C1FlexGrid.DragModeEnum.Manual
            '.DropMode = C1.Win.C1FlexGrid.DropModeEnum.Manual
            .SelectionMode = SelectionModeEnum.Default
        End With

        Grid_OrderList(0, 0) = "No"
        Grid_OrderList(0, 1) = "Order Index"
        Grid_OrderList(0, 2) = "납기일자"
        Grid_OrderList(0, 3) = "고객사 코드"
        Grid_OrderList(0, 4) = "고객사"
        Grid_OrderList(0, 5) = "모델코드"
        Grid_OrderList(0, 6) = "품번"
        Grid_OrderList(0, 7) = "품명"
        Grid_OrderList(0, 8) = "주문수량"
        Grid_OrderList(0, 9) = "계획 시작일"
        Grid_OrderList(0, 10) = "생산"
        Grid_OrderList.AutoSizeCols()

    End Sub

    Friend userButton() As Button
    Dim _al As ArrayList = New ArrayList()

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        If CB_Line.Text = String.Empty Then
            MessageBox.Show("라인을 먼저 선택하여 주십시오.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Thread_LoadingFormStart(Me)

        Grid_OrderList.Redraw = False
        Grid_OrderList.Rows.Count = 1

        'userButton을 초기화 한다.
        If IsNothing(userButton) = False Then
            For i = userButton.Count - 1 To 0 Step -1
                Grid_OrderList.Controls.Remove(userButton(i))
            Next
        End If
        userButton = Nothing

        Load_OrderList() '리스트를 불러온다.

        Grid_OrderList.AutoSizeCols()
        Grid_OrderList.Cols(10).Width = 80
        Grid_OrderList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_OrderList()

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_wave_selective_production(11"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & CB_Line.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_OrderList.Rows.Count & vbTab &
                                          sqlDR("order_index") & vbTab &
                                          sqlDR("date_of_delivery") & vbTab &
                                          sqlDR("customer_code") & vbTab &
                                          sqlDR("customer_name") & vbTab &
                                          sqlDR("model_code") & vbTab &
                                          sqlDR("item_code") & vbTab &
                                          sqlDR("item_name") & vbTab &
                                          Format(sqlDR("modify_order_quantity"), "#,##0") & vbTab &
                                          sqlDR("start_date")
            Grid_OrderList.AddItem(insert_String)
            If sqlDR("order_status") = "Confirmation of production plan" Then
                Grid_ButtonAdd(Grid_OrderList.Rows.Count - 1, Grid_OrderList.Rows.Count - 1, 10, "생산시작", SystemColors.Control)
            ElseIf sqlDR("order_status") Like "Production in *" Then
                Grid_ButtonAdd(Grid_OrderList.Rows.Count - 1, Grid_OrderList.Rows.Count - 1, 10, "생산종료", Color.Yellow)
            End If
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub Grid_ButtonAdd(ByVal i As Integer,
                               ByVal row As Integer,
                               ByVal col As Integer,
                               ByVal buttonText As String,
                               ByVal backColor As Color)

        If IsNothing(userButton) Then
            ReDim userButton(0)
        Else
            ReDim Preserve userButton(userButton.Length + 1)
        End If

        userButton(userButton.Length - 1) = New Button()
        userButton(userButton.Length - 1).BackColor = backColor
        userButton(userButton.Length - 1).Text = buttonText
        userButton(userButton.Length - 1).Tag = i
        Controls.AddRange(New Control() {userButton(userButton.Length - 1)})
        AddHandler userButton(userButton.Length - 1).Click, AddressOf UserButton_Bottom_Click

        _al.Add(New md_HostedControl(Grid_OrderList, userButton(userButton.Length - 1), row, col))

    End Sub

    Private Sub Grid_OrderList_Paint(sender As Object, e As PaintEventArgs) Handles Grid_OrderList.Paint
        For Each hosted As md_HostedControl In _al
            hosted.UpdatePosition()
        Next
    End Sub

    Private Sub UserButton_Bottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim bt As Button = CType(sender, Button)
        Dim selRow As Integer = CInt(bt.Tag.ToString)
        Dim workFlag As String = bt.Text

        If workFlag = "생산시작" Then
            WorkingStart(selRow)
        ElseIf workFlag = "생산종료" Then
            WorkingEnd(selRow)
        End If

    End Sub

    Private Sub WorkingStart(ByVal selRow As Integer)

        If Trim(TB_Worker.Text) = String.Empty Then
            MessageBox.Show(Me,
                            "작업자를 입력하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            TB_Worker.Focus()
            Exit Sub
        End If

        If MessageBox.Show(Me,
                           "주문번호 : " & Grid_OrderList(selRow, 1) & vbCrLf &
                           "Item Code : " & Grid_OrderList(selRow, 6) & vbCrLf &
                           "Item Name : " & Grid_OrderList(selRow, 7) & vbCrLf &
                           "생산시작 등록을 하시겠습니까?",
                           msg_form,
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Dim warning As Boolean = False
        For i = 1 To Grid_OrderList.Rows.Count - 1
            If CDate(Grid_OrderList(i, 2)) < CDate(Grid_OrderList(selRow, 2)) Then
                warning = True
                Exit For
            End If
        Next

        If warning = True Then
            If MessageBox.Show(Me,
                               "납기일자가 더 빠른 주문이 존재 합니다." & vbCrLf &
                               "생산시작 등록을 계속 하시겠습니까?",
                               msg_form,
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        End If

        If StartWrite(Grid_OrderList(selRow, 1)) = False Then
            MessageBox.Show(Me,
                            "시작 등록을 실패 하였습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Exit Sub
        End If

        MessageBox.Show(Me,
                        "시작등록을 완료 하였습니다." & vbCrLf &
                        "생산을 시작하여 주십시오.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

        BTN_Search_Click(Nothing, Nothing)

    End Sub

    Private Function StartWrite(ByVal oder_index As String) As Boolean

        Dim writeSuccess As Boolean = True

        Thread_LoadingFormStart(Me, "Saving...")

        If DBConnect() = False Then
            Return False
            Exit Function
        End If

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            '검사시작 등록
            strSQL = "insert into tb_mms_ws_output_history("
            strSQL += "history_index, order_index, process_name, ws_start_date, working_status"
            strSQL += ") values("
            strSQL += "'WSO" & Format(Now, "yyMMddHHmmssfff") & "'"
            strSQL += ",'" & oder_index & "'"
            strSQL += ",'" & CB_Line.Text & "'"
            strSQL += ",'" & writeDate & "'"
            strSQL += ",'Running'"
            strSQL += ");"
            '주문상태 변경
            strSQL += "update tb_mms_order_register_list set order_status = 'Production in " & CB_Line.Text & "'"
            strSQL += " where order_index = '" & oder_index & "';"
            '생산계획 시작일 등록
            Dim processColumn As String = "wave_start"
            If CB_Line.Text = "Selective Soldering" Then
                processColumn = "selective_start"
            End If
            strSQL += "update tb_mms_production_plan set " & processColumn & " = '" & writeDate & "'"
            strSQL += " where order_index = '" & oder_index & "';"

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
            writeSuccess = False
            MessageBox.Show(Me,
                            ex.Message,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Return writeSuccess
        End Try

        DBClose()
        writeSuccess = True

        Thread_LoadingFormEnd()

        Return writeSuccess

    End Function

    Private Sub WorkingEnd(ByVal selRow As Integer)

        If MessageBox.Show(Me,
                           "주문번호 : " & Grid_OrderList(selRow, 1) & vbCrLf &
                           "Item Code : " & Grid_OrderList(selRow, 6) & vbCrLf &
                           "Item Name : " & Grid_OrderList(selRow, 7) & vbCrLf &
                           "생산종료 등록을 하시겠습니까?",
                           msg_form,
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        If EndWrite(Grid_OrderList(selRow, 1)) = False Then
            MessageBox.Show(Me,
                            "종료 등록을 실패 하였습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Exit Sub
        End If

        MessageBox.Show(Me,
                        "종료등록을 완료 하였습니다.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

        BTN_Search_Click(Nothing, Nothing)

    End Sub

    Private Function EndWrite(ByVal oder_index As String) As Boolean

        Dim writeSuccess As Boolean = True

        Thread_LoadingFormStart(Me, "Saving...")

        If DBConnect() = False Then
            Return False
            Exit Function
        End If

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            '생산종료일 등록
            Dim processColumn As String = "wave_end"
            If CB_Line.Text = "Selective Soldering" Then
                processColumn = "selective_end"
            End If
            strSQL += "update tb_mms_production_plan set " & processColumn & " = '" & writeDate & "'"
            strSQL += " where order_index = '" & oder_index & "';"
            strSQL += "update tb_mms_order_register_list set order_status = '" & frm_Wave_Selective_Production_End.CB_Line.Text & " Process Completed'"
            strSQL += " where order_index = '" & oder_index & "';"

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
            writeSuccess = False
            MessageBox.Show(Me,
                            ex.Message,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Return writeSuccess
        End Try

        DBClose()
        writeSuccess = True

        Thread_LoadingFormEnd()

        Return writeSuccess

    End Function

    Private Sub CB_Line_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Line.SelectedIndexChanged

    End Sub

    Private Sub CB_Line_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_Line.SelectionChangeCommitted

        BTN_Search_Click(Nothing, Nothing)

    End Sub
End Class