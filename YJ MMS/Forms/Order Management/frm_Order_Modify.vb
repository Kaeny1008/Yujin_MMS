Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Order_Modify

    Private Sub frm_Order_Registration_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        DTP_Start.Value = Format(Now, "yyyy-MM-01 00:00:00")
        DTP_End.Value = Format(Now, "yyyy-MM-dd 23:59:59")

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub Grid_Setting()

        With Grid_Excel
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 18
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            Grid_Excel(0, 0) = "No"
            Grid_Excel(0, 1) = "모델코드"
            Grid_Excel(0, 2) = "SPG"
            Grid_Excel(0, 3) = "품번"
            Grid_Excel(0, 4) = "품명"
            Grid_Excel(0, 5) = "규격"
            Grid_Excel(0, 6) = "단위"
            Grid_Excel(0, 7) = "주문번호"
            Grid_Excel(0, 8) = "주문일자"
            Grid_Excel(0, 9) = "최초 주문량"
            Grid_Excel(0, 10) = "변경 주문량"
            Grid_Excel(0, 11) = "납입장소"
            Grid_Excel(0, 12) = "납기일자"
            Grid_Excel(0, 13) = "모델등록"
            Grid_Excel(0, 14) = "BOM등록"
            Grid_Excel(0, 15) = "상태"
            Grid_Excel(0, 16) = "Order Index"
            Grid_Excel(0, 17) = "지정 관리번호"
            .Cols(16).Visible = True
            .Cols(12).DataType = GetType(Date)
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            '.Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            .ExtendLastCol = False
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
        End With

        With Grid_OrderList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 6
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            Grid_OrderList(0, 0) = "No"
            Grid_OrderList(0, 1) = "주문번호"
            Grid_OrderList(0, 2) = "등록일자"
            Grid_OrderList(0, 3) = "고객사"
            Grid_OrderList(0, 4) = "총 모델수"
            Grid_OrderList(0, 5) = "납품일자"
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            '.Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            '.ExtendLastCol = True
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
        End With

    End Sub

    Private Function Load_ExistCheck(ByVal itemCode As String) As String

        Dim modelExist As String = "X"
        Dim bomExist As String = "X"
        Dim model_Code As String = String.Empty
        Dim item_name As String = String.Empty
        Dim item_spec As String = String.Empty

        Dim strSQL As String = "call sp_mms_order_registration(0"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ", '" & itemCode & "'"
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
            If Not sqlDR("model_exist") = 0 Then
                modelExist = "O"
                model_Code = sqlDR("model_code")
                item_name = sqlDR("item_name")
                item_spec = sqlDR("item_spec")
            End If
            If Not sqlDR("bom_exist") = 0 Then
                bomExist = "O"
            End If
        Loop
        sqlDR.Close()

        Return modelExist & "|" & bomExist & "|" & model_Code & "|" & item_spec & "|" & item_name

    End Function

    Private Sub RegistrationCheck()

        'Thread_LoadingFormStart(Me)

        DBConnect()

        For i = 1 To Grid_Excel.Rows.Count - 1
            Dim existCheck() As String = Load_ExistCheck(Grid_Excel(i, 3)).Split("|")
            Dim itemRegister As String = existCheck(0)
            Dim itemBOM As String = existCheck(1)
            Dim modelCode As String = existCheck(2)
            Dim itemSpec As String = existCheck(3)
            Dim itemName As String = existCheck(4)

            Grid_Excel(i, 1) = modelCode
            Grid_Excel(i, 13) = itemRegister
            If itemRegister = "O" Then
                Grid_Excel(i, 4) = itemName
                Grid_Excel(i, 5) = itemSpec
            End If
            Grid_Excel(i, 14) = itemBOM
        Next

        DBClose()

        'Thread_LoadingFormEnd()

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click, BTN_Save2.Click

        For i = 1 To Grid_Excel.Rows.Count - 1
            If Grid_Excel(i, 13) = "X" Then
                MSG_Information(Me, "모델 등록되지 않은 항목이 존재합니다." & vbCrLf & "모델등록을 먼저 해주십시오.")
                Exit Sub
            End If
        Next

        If MSG_Question(Me, "저장 하시겠습니까?") = False Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            For i = 1 To Grid_Excel.Rows.Count - 1
                If Grid_Excel(i, 0).ToString = "X" Then
                    strSQL += "update tb_mms_order_register_list set"
                    strSQL += " order_status = 'Order Cancel'"
                    strSQL += ", modify_date = '" & writeDate & "'"
                    strSQL += ", modify_id = '" & loginID & "'"
                    strSQL += " where order_index = '" & Grid_Excel(i, 16) & "';"
                ElseIf Grid_Excel(i, 0).ToString = "R" Then
                    strSQL += "update tb_mms_order_register_list set"
                    strSQL += " order_status = 'Order Confirm'"
                    strSQL += ", modify_date = '" & writeDate & "'"
                    strSQL += ", modify_id = '" & loginID & "'"
                    strSQL += " where order_index = '" & Grid_Excel(i, 16) & "';"
                ElseIf Grid_Excel(i, 0).ToString = "M" Then
                    strSQL += "update tb_mms_order_register_list set"
                    strSQL += " date_of_delivery = '" & Grid_Excel(i, 12) & "'"
                    strSQL += ", modify_order_quantity = '" & CDbl(Grid_Excel(i, 10)) & "'"
                    strSQL += ", modify_date = '" & writeDate & "'"
                    strSQL += ", modify_id = '" & loginID & "'"
                    strSQL += " where order_index = '" & Grid_Excel(i, 16) & "';"
                ElseIf Grid_Excel(i, 0).ToString = "D" Then
                    strSQL += "delete from tb_mms_order_register_list"
                    strSQL += " where order_index = '" & Grid_Excel(i, 16) & "';"
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

            MSG_Error(Me, ex.Message)
            Exit Sub
        End Try

        DBClose()

        BTN_Save.Enabled = False

        Thread_LoadingFormEnd()

        MSG_Information(Me, "저장완료.")

        Load_OrderNo(TB_OrderNo.Text)
        RegistrationCheck()

    End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart(Me)

        BTN_Save.Enabled = False

        Grid_Excel.Redraw = False
        Grid_Excel.Rows.Count = 1
        Grid_Excel.Redraw = True

        Grid_OrderList.Redraw = False
        Grid_OrderList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_order_registration(1"
        strSQL += ", null"
        strSQL += ", '" & TextBox1.Text & "'"
        strSQL += ", '" & TB_OrderNo_Search.Text & "'"
        strSQL += ", '" & Format(DTP_Start.Value, "yyyy-MM-dd 00:00:00") & "'"
        strSQL += ", '" & Format(DTP_End.Value, "yyyy-MM-dd 23:59:59") & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & ComboBox1.Text & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_OrderList.Rows.Count & vbTab &
                                          sqlDR("order_no") & vbTab &
                                          sqlDR("order_date") & vbTab &
                                          sqlDR("customer_name") & vbTab &
                                          sqlDR("total_order") & vbTab &
                                          Format(sqlDR("date_of_delivery"), "yyyy-MM-dd")
            Grid_OrderList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_OrderList.AutoSizeCols()
        Grid_OrderList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_Excel_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_Excel.MouseClick

        Dim selRow As Integer = Grid_Excel.MouseRow

        If e.Button = MouseButtons.Right And selRow > 0 Then
            Grid_Excel.Row = selRow
            Select Case Grid_Excel(selRow, 0)
                Case "N"
                    BTN_OrderCancel.Enabled = False
                    BTN_Resume.Enabled = False
                Case "X"
                    BTN_OrderCancel.Enabled = False
                    BTN_Resume.Enabled = True
                Case Else
                    BTN_OrderCancel.Enabled = True
                    BTN_Resume.Enabled = False
            End Select
            CMS_GridMenu.Show(Grid_Excel, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub Grid_OrderList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Grid_OrderList.MouseDoubleClick

        Dim selRow As Integer = Grid_OrderList.MouseRow

        If Not e.Button = MouseButtons.Left Or selRow < 0 Then Exit Sub

        Thread_LoadingFormStart(Me)
        
        Load_OrderNo(Grid_OrderList(selRow, 1))
        TB_OrderNo.Text = Grid_OrderList(selRow, 1)

        RegistrationCheck()

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_OrderNo(ByVal orderNo As String)

        BTN_Save.Enabled = True

        Grid_Excel.Redraw = False
        Grid_Excel.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_order_registration(2"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & orderNo & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & ComboBox1.Text & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_CustomerCode.Text = sqlDR("customer_code")
            TB_CustomerName.Text = sqlDR("customer_name")
            Dim rowName As String = Grid_Excel.Rows.Count
            Dim rowColor As Color = Color.Black
            If sqlDR("order_status") = "Order Cancel" Then
                rowName = "X"
                rowColor = Color.Coral
            ElseIf sqlDR("order_status") = "Completed" Then
                rowColor = Color.OliveDrab
            End If
            Dim insert_String As String = rowName & vbTab &
                                          sqlDR("model_code") & vbTab &
                                          sqlDR("spg") & vbTab &
                                          sqlDR("item_code") & vbTab &
                                          sqlDR("item_name") & vbTab &
                                          sqlDR("item_spec") & vbTab &
                                          sqlDR("unit") & vbTab &
                                          sqlDR("order_no") & vbTab &
                                          sqlDR("order_date") & vbTab &
                                          sqlDR("order_quantity") & vbTab &
                                          sqlDR("modify_order_quantity") & vbTab &
                                          sqlDR("delivery_place") & vbTab &
                                          sqlDR("date_of_delivery") & vbTab &
                                          vbTab &
                                          vbTab &
                                          sqlDR("order_status") & vbTab &
                                          sqlDR("order_index") & vbTab &
                                          sqlDR("management_no")

            GridWriteText(insert_String, Me, Grid_Excel, rowColor)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_Excel.AutoSizeCols()
        Grid_Excel.Redraw = True

    End Sub

    Private Sub BTN_OrderCancel_Click(sender As Object, e As EventArgs) Handles BTN_OrderCancel.Click

        Dim selRow As Integer = Grid_Excel.Row

        If MSG_Question(Me,
                        "주문 취소 하시겠습니까?" & vbCrLf &
                        "품번 : " & Grid_Excel(selRow, 3) & vbCrLf &
                        "품명 : " & Grid_Excel(selRow, 4) & vbCrLf &
                        "주문량 : " & Grid_Excel(selRow, 9) & " " & Grid_Excel(selRow, 6)
                        ) = False Then Exit Sub

        Grid_Excel(selRow, 0) = "X"
        Grid_Excel.Rows(selRow).StyleNew.ForeColor = Color.Coral

    End Sub

    Private Sub BTN_Resume_Click(sender As Object, e As EventArgs) Handles BTN_Resume.Click

        Dim selRow As Integer = Grid_Excel.Row

        If MSG_Question(Me,
                        "재등록 하시겠습니까?" & vbCrLf &
                        "품번 : " & Grid_Excel(selRow, 3) & vbCrLf &
                        "품명 : " & Grid_Excel(selRow, 4) & vbCrLf &
                        "주문량 : " & Grid_Excel(selRow, 9) & " " & Grid_Excel(selRow, 6)
                        ) = False Then Exit Sub

        Grid_Excel(selRow, 0) = "R"
        Grid_Excel.Rows(selRow).StyleNew.ForeColor = Color.Black

    End Sub

    Private Sub Grid_Excel_RowColChange(sender As Object, e As EventArgs) Handles Grid_Excel.RowColChange

        If Grid_Excel.Row < 0 Then Exit Sub

        Select Case Grid_Excel.Col
            Case 10, 12
                If Not Grid_Excel(Grid_Excel.Row, 0) = "X" Or Not Grid_Excel(Grid_Excel.Row, 0) = "R" Then
                    Grid_Excel.AllowEditing = True
                Else
                    Grid_Excel.AllowEditing = False
                End If
            Case Else
                Grid_Excel.AllowEditing = False
        End Select

    End Sub

    Private Sub Grid_Excel_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Grid_Excel.BeforeEdit

        before_griddata = Grid_Excel(e.Row, e.Col)

    End Sub

    Private Sub Grid_Excel_AfterEdit(sender As Object, e As RowColEventArgs) Handles Grid_Excel.AfterEdit

        If Grid_Excel(e.Row, 0).Equals("D") Then Exit Sub

        If before_griddata = Grid_Excel(e.Row, e.Col) Then Exit Sub

        Select Case e.Col
            Case 10
                If Not Grid_Excel(e.Row, 15) = "Order Confirm" Then
                    '주문접수된 상태가 아닐때
                    Grid_Excel(e.Row, e.Col) = before_griddata
                    MSG_Exclamation(Me, "주문접수 상태가 아니므로 변경 할 수 없습니다." & vbCrLf & "기존 주문수량으로 변경됩니다.")
                    Exit Sub
                End If

                'If CDbl(before_griddata) < CDbl(Grid_Excel(e.Row, e.Col)) Then
                '    If Not Grid_Excel(e.Row, 15) = "Order Confirm" Then
                '        Grid_Excel(e.Row, e.Col) = before_griddata
                '        MessageBox.Show(Me,
                '                        "자재 소요량 확정된 주문은 기존 주문수량보다 클 수 없습니다." & vbCrLf & "기존 주문수량으로 변경됩니다.",
                '                        msg_form,
                '                        MessageBoxButtons.OK,
                '                        MessageBoxIcon.Exclamation)
                '        Exit Sub
                '    End If
                'End If
        End Select

        Grid_Excel.Redraw = False

        If IsNumeric(Grid_Excel(e.Row, 0)) Then
            Grid_Excel(e.Row, 0) = "M"
        End If

        Select Case e.Col
            Case 10
                Grid_Excel(e.Row, e.Col) = Format(cdbl(Grid_Excel(e.Row, e.Col)), "#,##0")
        End Select

        Dim cs As CellStyle = Grid_Excel.Styles.Add("Yellow_Cell")
        cs.BackColor = Color.Yellow
        cs.ForeColor = Color.Red

        Grid_Excel.SetCellStyle(e.Row, e.Col, cs)

        Grid_Excel.AutoSizeCols()

        Grid_Excel.Redraw = True

    End Sub

    Private Sub Grid_Excel_KeyPressEdit(sender As Object, e As KeyPressEditEventArgs) Handles Grid_Excel.KeyPressEdit

        If Not Char.IsDigit(e.KeyChar) And
            Not Char.IsControl(e.KeyChar) And
            Not e.KeyChar = "." And
            Not e.KeyChar = "," Then
            e.Handled = True
        End If

    End Sub

    Private Sub BTN_PO_Split_Click(sender As Object, e As EventArgs) Handles BTN_PO_Split.Click

        Dim selRow As Integer = Grid_Excel.Row
        Dim selPONo As String = Grid_Excel(selRow, 16)

        If selPONo.Substring(selPONo.Length - 2, 2) Like "-#" Then
            MSG_Information(Me, "분할된 주문에서 재 분할 할 수 없습니다.")
            Exit Sub
        End If

        Dim showString As String = "품번 : " & Grid_Excel(selRow, 3)
        showString += vbCrLf & "품명 : " & Grid_Excel(selRow, 4)
        showString += vbCrLf & "주문번호 : " & Grid_Excel(selRow, 7)
        showString += vbCrLf & vbCrLf & "를 주문 분리(수량) 또는 관리번호를 지정 하시겠습니까?"

        If MSG_Question(Me, showString) = False Then Exit Sub

        frm_Order_Split.orderIndex = Grid_Excel(selRow, 16)
        If Not frm_Order_Split.Visible Then frm_Order_Split.Show()
        frm_Order_Split.Focus()

    End Sub
End Class