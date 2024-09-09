Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Order_Split

    Public orderIndex As String
    Dim splitCount As Integer

    Private Sub frm_Order_Split_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        Load_Order_Information()

    End Sub

    Private Sub Grid_Setting()

        With Grid_ManagementNo
            .AllowEditing = False
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 7
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .Cols(6).DataType = GetType(Boolean)
        End With

        Grid_ManagementNo(0, 0) = "No"
        Grid_ManagementNo(0, 1) = "관리번호"
        Grid_ManagementNo(0, 2) = "시방번호"
        Grid_ManagementNo(0, 3) = "발행일자"
        Grid_ManagementNo(0, 4) = "변경구분"
        Grid_ManagementNo(0, 5) = "적용시기"
        Grid_ManagementNo(0, 6) = "선택"

        Grid_ManagementNo.AutoSizeCols()

    End Sub

    Private Sub Load_Order_Information()

        DBConnect()

        Dim strSQL As String = "call sp_mms_order_registration(7"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & orderIndex & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_CustomerCode.Text = sqlDR("customer_code")
            TB_CustomerName.Text = sqlDR("customer_name")
            TB_ItemCode.Text = sqlDR("item_code")
            TB_ItemName.Text = sqlDR("item_name")
            TB_ItemSpec.Text = sqlDR("item_spec")
            TB_ModelCode.Text = sqlDR("model_code")
            TB_Order_Quantity.Text = Format(sqlDR("modify_order_quantity"), "#,##0")
            TB_Date_Of_Delivery.Text = Format(sqlDR("date_of_delivery"), "yyyy-MM-dd")
            TB_OrderIndex.Text = sqlDR("order_index")
            splitCount = sqlDR("split_count")
        Loop
        sqlDR.Close()

        DBClose()

        Load_ManagementNo()

    End Sub

    Private Sub Load_ManagementNo()

        Grid_ManagementNo.Redraw = False
        Grid_ManagementNo.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_order_registration(8"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_ModelCode.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String
            insertString = Grid_ManagementNo.Rows.Count
            insertString += vbTab & sqlDR("management_no")
            insertString += vbTab & sqlDR("specification_number")
            insertString += vbTab & Format(sqlDR("issue_date"), "yyyy-MM-dd")
            insertString += vbTab & sqlDR("gubun")
            insertString += vbTab & sqlDR("time_of_change")
            Grid_ManagementNo.AddItem(insertString)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_ManagementNo.AutoSizeCols()
        Grid_ManagementNo.Redraw = True

    End Sub

    Private Sub TB_Split_Quantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TB_Split_Quantity.KeyPress

        If Not Char.IsDigit(e.KeyChar) And
            Not Char.IsControl(e.KeyChar) And
            Not e.KeyChar = "." And
            Not e.KeyChar = "," Then
            e.Handled = True
        End If

    End Sub

    Private Sub Grid_ManagementNo_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_ManagementNo.MouseClick

        If e.Button = MouseButtons.Left Then
            Dim selRow As Integer = Grid_ManagementNo.MouseRow
            For i = 1 To Grid_ManagementNo.Rows.Count - 1
                If Grid_ManagementNo.GetCellCheck(i, 6) = CheckEnum.Checked Then
                    Grid_ManagementNo.SetCellCheck(i, 6, CheckEnum.Unchecked)
                End If
            Next
            Grid_ManagementNo.SetCellCheck(selRow, 6, CheckEnum.Checked)
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked = True Then
            TB_Split_Quantity.Enabled = False
            TB_Split_Quantity.Text = TB_Order_Quantity.Text
        Else
            TB_Split_Quantity.Enabled = True
            TB_Split_Quantity.SelectAll()
            TB_Split_Quantity.Focus()
        End If

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        Dim managementNo As String = String.Empty
        For i = 1 To Grid_ManagementNo.Rows.Count - 1
            If Grid_ManagementNo.GetCellCheck(i, 6) = CheckEnum.Checked Then
                managementNo = Grid_ManagementNo(i, 1)
            End If
        Next

        If managementNo = String.Empty Then
            MSG_Information(Me, "적용할 관리번호를 선택하여 주십시오.")
            Exit Sub
        End If

        If TB_Split_Quantity.Text = String.Empty Then
            MSG_Information(Me, "분할할 수량을 입력하여 주십시오.")
            TB_Split_Quantity.SelectAll()
            TB_Split_Quantity.Focus()
            Exit Sub
        End If

        If MSG_Question(Me, "변경 내용을 저장 하시겠습니까?") = False Then Exit Sub

        If DB_Write(managementNo) = False Then Exit Sub

        MSG_Information(Me, "저장 완료." & vbCrLf & "창이 닫힙니다.")

        Me.Dispose()

    End Sub

    Private Function DB_Write(ByVal managementNo As String) As Boolean

        Thread_LoadingFormStart(Me, "Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            If CheckBox1.Checked = True Then
                strSQL += "update tb_mms_order_register_list set management_no = '" & managementNo & "'"
                strSQL += " where order_index = '" & TB_OrderIndex.Text & "';"
            Else
                strSQL = "insert into tb_mms_order_register_list("
                strSQL += "order_index, customer_code, model_code, unit, order_no, order_date, order_quantity"
                strSQL += ", delivery_place, date_of_delivery, order_status, write_date"
                strSQL += ", write_id, modify_order_quantity, management_no, item_section"
                strSQL += ") "
                strSQL += "select "
                strSQL += "'" & TB_OrderIndex.Text & "-" & splitCount & "'"
                strSQL += ", customer_code"
                strSQL += ", model_code"
                strSQL += ", unit"
                strSQL += ", order_no"
                strSQL += ", order_date"
                strSQL += ", " & CInt(TB_Split_Quantity.Text) & ""
                strSQL += ", delivery_place"
                strSQL += ", date_of_delivery"
                strSQL += ", 'Order Confirm'"
                strSQL += ", '" & writeDate & "'"
                strSQL += ", '" & loginID & "'"
                strSQL += ", " & CInt(TB_Split_Quantity.Text) & ""
                strSQL += ", '" & managementNo & "'"
                strSQL += ", item_section"
                strSQL += " from tb_mms_order_register_list"
                strSQL += " where order_index = '" & TB_OrderIndex.Text & "';"

                strSQL += "update tb_mms_order_register_list set modify_order_quantity = " & CInt(TB_Order_Quantity.Text) - CInt(TB_Split_Quantity.Text) & ""
                strSQL += " where order_index = '" & TB_OrderIndex.Text & "';"
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
            MSG_Error(Me, ex.Message)
            Return False
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        Return True

    End Function
End Class