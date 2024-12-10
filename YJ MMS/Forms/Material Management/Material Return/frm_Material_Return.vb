Imports C1.Win.C1FlexGrid
Imports MySqlConnector

Public Class frm_Material_Return

    Dim selReturnNo As String

    Private Sub frm_Material_Return_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        Load_CustomerList()

        DateTimePicker1.Value = Format(Now, "yyyy-MM-01")
        DateTimePicker2.Value = Format(Now)

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub Grid_Setting()

        With Grid_ReturnList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.None
            .Rows(0).Height = 30
            .Rows.DefaultSize = 20
            .Cols.Count = 4
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
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .Cols(3).DataType = GetType(Date)
            .Cols(3).Format = "yyyy-MM-dd"
            .Cols(3).StyleNew.TextAlign = TextAlignEnum.CenterCenter
        End With

        Grid_ReturnList(0, 0) = "No."
        Grid_ReturnList(0, 1) = "전표번호"
        Grid_ReturnList(0, 2) = "고객사"
        Grid_ReturnList(0, 3) = "반출일자"
        Grid_ReturnList.AutoSizeCols()

        With Grid_History
            .AllowEditing = False
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
            .ExtendLastCol = False
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .Cols(5).DataType = GetType(Integer)
            .Cols(5).Format = "#,##0"
            .Cols(7).Visible = False
            .Cols(8).Visible = False
        End With

        Grid_History(0, 0) = "No."
        Grid_History(0, 1) = "자재코드"
        Grid_History(0, 2) = "Vendor"
        Grid_History(0, 3) = "Vendor Code"
        Grid_History(0, 4) = "Lot No."
        Grid_History(0, 5) = "수량"
        Grid_History(0, 6) = "반출 사유"
        Grid_History(0, 7) = "History Index"
        Grid_History(0, 8) = "MW No."

    End Sub

    Private Sub Load_CustomerList()

        CB_CustomerName.Items.Clear()

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "select customer_name"
        strSQL += " from tb_customer_list"
        strSQL += " order by customer_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            CB_CustomerName.Items.Add(sqlDR("customer_name"))
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub CB_CustomerName_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_CustomerName.SelectionChangeCommitted

        TB_CustomerCode.Text = String.Empty

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "select customer_code, ifnull(use_part_code, '') as use_part_code"
        strSQL += " from tb_customer_list"
        strSQL += " where customer_name = '" & CB_CustomerName.Text & "'"
        strSQL += " order by customer_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_CustomerCode.Text = sqlDR("customer_code")
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub BTN_Change_Click(sender As Object, e As EventArgs) Handles BTN_Change.Click

        If Not frm_Material_Return_Register.Visible Then frm_Material_Return_Register.Show()
        frm_Material_Return_Register.Focus()

    End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart(Me)

        Grid_ReturnList.Redraw = False
        Grid_ReturnList.Rows.Count = 1

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_material_return(5"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ",  '" & TB_CustomerCode.Text & "'"
        strSQL += ", null"
        strSQL += ", '" & Format(DateTimePicker1.Value, "yyyy-MM-dd 00:00:00") & "'"
        strSQL += ", '" & Format(DateTimePicker2.Value, "yyyy-MM-dd 23:59:59") & "'"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_ReturnList.Rows.Count
            insert_String += vbTab & sqlDR("return_no")
            insert_String += vbTab & sqlDR("customer_name")
            insert_String += vbTab & sqlDR("write_date")
            Grid_ReturnList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_ReturnList.AutoSizeCols()
        Grid_ReturnList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_ReturnList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Grid_ReturnList.MouseDoubleClick

        Dim selRow As Integer = Grid_ReturnList.MouseRow

        If e.Button = MouseButtons.Left And selRow > 0 Then
            selReturnNo = Grid_ReturnList(selRow, 1)
            Thread_LoadingFormStart(Me)

            Grid_History.Redraw = False
            Grid_History.Rows.Count = 1

            If DBConnect() = False Then Exit Sub

            Dim strSQL As String = "call sp_mms_material_return(6"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", '" & selReturnNo & "'"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ");"

            Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
            Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

            Do While sqlDR.Read
                Dim insert_String As String = Grid_History.Rows.Count
                insert_String += vbTab & sqlDR("part_code")
                insert_String += vbTab & sqlDR("part_vendor")
                insert_String += vbTab & sqlDR("part_no")
                insert_String += vbTab & sqlDR("part_lot_no")
                insert_String += vbTab & sqlDR("history_qty")
                insert_String += vbTab & sqlDR("return_reason")
                insert_String += vbTab & sqlDR("history_index")
                insert_String += vbTab & sqlDR("mw_no")
                Grid_History.AddItem(insert_String)
            Loop
            sqlDR.Close()

            DBClose()

            Grid_History.AutoSizeCols()
            Grid_History.Redraw = True

            Thread_LoadingFormEnd()
        End If

    End Sub

    Private Sub Grid_History_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_History.MouseClick

        Dim selRow As Integer = Grid_History.MouseRow

        If e.Button = MouseButtons.Right Then
            Grid_History.Row = selRow
            Grid_Menu.Show(Grid_History, New Point(e.X, e.Y))
        End If


    End Sub

    Private Sub BTN_RePrint_Click(sender As Object, e As EventArgs) Handles BTN_RePrint.Click

        Material_Return_Report_Print(selReturnNo)

    End Sub

    Private Sub BTN_ReturnCancel_Click(sender As Object, e As EventArgs) Handles BTN_ReturnCancel.Click

        Dim selRow As Integer = Grid_History.Row
        Dim partCode As String = Grid_History(selRow, 1)
        Dim partNo As String = Grid_History(selRow, 3)
        Dim lotNo As String = Grid_History(selRow, 4)
        Dim qty As Double = Grid_History(selRow, 5)

        If MSG_Question(Me, "Part Code : " & partCode & vbCrLf &
                        "Part No. : " & partNo & vbCrLf &
                        "Lot No. : " & lotNo & vbCrLf &
                        "Qty : " & Format(qty, "#,##0") & vbCrLf &
                        vbCrLf & "반출등록을 취소 하시겠습니까?") = False Then Exit Sub

        Dim historyIndex As String = Grid_History(selRow, 7)
        Dim mwNo As String = Grid_History(selRow, 8)

        Thread_LoadingFormStart(Me, "Saving...")

        If DBConnect() = False Then Exit Sub

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            strSQL = "delete from tb_mms_material_history"
            strSQL += " where history_index = '" & historyIndex & "'"
            strSQL += ";"

            strSQL += "delete from tb_mms_material_transfer_out_content"
            strSQL += " where mw_no = '" & mwNo & "'"
            strSQL += " order by table_index desc limit 1"
            strSQL += ";"

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
            MSG_Error(Me, ex.Message & vbCrLf & "Error No. : " & ex.Number)
            Exit Sub
        Finally

        End Try

        DBClose()

        Thread_LoadingFormEnd()

        MSG_Information(Me, "반출등록 취소 완료." & vbCrLf & "해당 자재를 자재창고로 이동하여 주십시오.")

    End Sub
End Class