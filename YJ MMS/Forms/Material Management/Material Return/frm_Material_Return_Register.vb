Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Material_Return_Register
    Private Sub frm_Material_Return_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Load_CustomerList()

        Grid_Setting()

        Make_ReturnNo()

    End Sub

    Private Sub Grid_Setting()

        With Grid_History
            .AllowEditing = False
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
            .ExtendLastCol = False
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .Cols(5).DataType = GetType(Integer)
            .Cols(5).Format = "#,##0"
        End With

        Grid_History(0, 0) = "No."
        Grid_History(0, 1) = "자재코드"
        Grid_History(0, 2) = "Vendor"
        Grid_History(0, 3) = "Vendor Code"
        Grid_History(0, 4) = "Lot No."
        Grid_History(0, 5) = "수량"
        Grid_History(0, 6) = "반출 사유"

    End Sub

    Private Sub Make_ReturnNo()

        CB_CustomerName.Items.Clear()

        DBConnect()

        Dim strSQL As String = "select f_mms_material_return_no("
        strSQL += "'" & Format(Now, "yyyy-MM-dd") & "'"
        strSQL += ") as return_no;"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Label14.Text = sqlDR("return_no")
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub Load_CustomerList()

        CB_CustomerName.Items.Clear()

        DBConnect()

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

        DBConnect()

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

        TB_Barcode.SelectAll()
        TB_Barcode.Focus()

    End Sub

    Private Sub TB_ReturnQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TB_ReturnQty.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "," Then
            e.Handled = True
        End If

    End Sub

    Private Sub TB_Barcode_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_Barcode.KeyDown

        If Not Trim(TB_Barcode.Text) = String.Empty And e.KeyCode = 13 Then
            If TB_CustomerCode.Text = String.Empty Then
                MessageBox.Show("고객사를 먼저 선택하여 주십시오.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                TB_Barcode.Text = String.Empty
                Exit Sub
            End If
            Dim splitBarcode() As String = TB_Barcode.Text.Split("!")
            '140500199!STW4N150!81G28FBJ0010!89!STM
            Try
                Load_Information(splitBarcode(0),
                                 splitBarcode(1),
                                 splitBarcode(2),
                                 CInt(splitBarcode(3))
                                 )
            Catch ex As Exception
                MessageBox.Show("Barcode를 정상적으로 인식하지 못하였습니다.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Error)
                TB_Barcode.Text = String.Empty
                Exit Sub
            End Try

            If TB_Vendor.Text = String.Empty Then
                MessageBox.Show("자재 정보를 찾지 못했습니다.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                TB_ItemCode.Text = splitBarcode(0)
                TB_PartNo.Text = splitBarcode(1)
                TB_LotNo.Text = splitBarcode(2)
                TB_Qty.Text = splitBarcode(3)
            End If

            TB_Barcode.Text = String.Empty
            TB_ReturnQty.SelectAll()
            TB_ReturnQty.Focus()
        End If

    End Sub

    Private Sub Load_Information(ByVal part_code As String,
                                 ByVal part_no As String,
                                 ByVal lot_no As String,
                                 ByVal qty As Integer)

        Thread_LoadingFormStart()

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_return(0"
        strSQL += ", '" & part_code & "'"
        strSQL += ", '" & part_no & "'"
        strSQL += ", '" & lot_no & "'"
        strSQL += ", '" & qty & "'"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_Vendor.Text = sqlDR("part_vendor")
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        If Not TB_Vendor.Text = String.Empty And
            Not TB_ReturnQty.Text = String.Empty And
            Not Trim(TB_Reason.Text) = String.Empty Then

            If (MessageBox.Show("반출 등록을 하시겠습니까?",
                                msg_form,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question)) = DialogResult.No Then Exit Sub

            Dim dbResult As Boolean = DB_Write()

            If dbResult = True Then
                If MessageBox.Show("저장완료." & vbCrLf & "자재반납 전표를 출력 하시겠습니까?",
                                   msg_form,
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question) = DialogResult.Yes Then
                    '반납전표 출력
                Else
                    Me.Dispose()
                End If
            End If
        End If

    End Sub

    Private Function DB_Write() As Boolean

        Thread_LoadingFormStart("Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            strSQL = "insert into tb_mms_material_return("
            strSQL += "return_no, customer_code, write_date, write_id"
            strSQL += ") values("
            strSQL += "'" & Label14.Text & "'"
            strSQL += ",'" & TB_CustomerCode.Text & "'"
            strSQL += ",'" & writeDate & "'"
            strSQL += ",'" & loginID & "'"

            For i = 1 To Grid_History.Rows.Count - 1
                strSQL += "insert into tb_mms_material_history("
                strSQL += "history_index, category, write_date, writer, customer_code, part_code"
                strSQL += ", part_vendor, part_no, part_lot_no, history_qty, return_reason, return_no"
                strSQL += ") values ("
                strSQL += "f_mms_material_history_no('" & Format(CDate(writeDate), "yyyy-MM-dd") & "')"
                strSQL += ", '자재반출'"
                strSQL += ", '" & writeDate & "'"
                strSQL += ", '" & loginID & "'"
                strSQL += ", '" & TB_CustomerCode.Text & "'"
                strSQL += ", '" & Grid_History(i, 1) & "'"
                strSQL += ", '" & Grid_History(i, 2) & "'"
                strSQL += ", '" & Grid_History(i, 3) & "'"
                strSQL += ", '" & Grid_History(i, 4) & "'"
                strSQL += ", '" & Grid_History(i, 5) & "'"
                strSQL += ", '" & Grid_History(i, 6) & "'"
                strSQL += ", '" & Label14.Text & "'"
                strSQL += ");"
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
            MessageBox.Show(frm_Main,
                            ex.Message & vbCrLf & "Error No. : " & ex.Number,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1)
            Return False
        Finally

        End Try

        DBClose()

        Thread_LoadingFormEnd()

        Return True

    End Function

    Private Sub BTN_Grid_Add_Click(sender As Object, e As EventArgs) Handles BTN_Grid_Add.Click

        If TB_Vendor.Text = String.Empty Then
            MessageBox.Show("등록할 자재를 먼저 스캔하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            TB_Barcode.Focus()
            Exit Sub
        End If

        If TB_ReturnQty.Text = String.Empty Then
            MessageBox.Show("반납수량을 입력하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            TB_ReturnQty.Focus()
            Exit Sub
        End If

        If TB_Reason.Text = String.Empty Then
            MessageBox.Show("반출사유를 입력하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            TB_Reason.Focus()
            Exit Sub
        End If

        Dim insertString As String
        insertString = Grid_History.Rows.Count
        insertString += vbTab & TB_ItemCode.Text
        insertString += vbTab & TB_Vendor.Text
        insertString += vbTab & TB_PartNo.Text
        insertString += vbTab & TB_LotNo.Text
        insertString += vbTab & TB_ReturnQty.Text
        insertString += vbTab & TB_Reason.Text

        Grid_History.AddItem(insertString)
        Grid_History.AutoSizeCols()

        ControlReset()

    End Sub

    Private Sub ControlReset()

        TB_Barcode.Text = String.Empty
        TB_ItemCode.Text = String.Empty
        TB_Vendor.Text = String.Empty
        TB_PartNo.Text = String.Empty
        TB_LotNo.Text = String.Empty
        TB_ReturnQty.Text = String.Empty
        'TB_Reason.Text = String.Empty
        TB_Qty.Text = String.Empty

    End Sub

    Private Sub TB_ReturnQty_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_ReturnQty.KeyDown

        If Not Trim(TB_ReturnQty.Text) = String.Empty And e.KeyCode = 13 Then
            If Not IsNumeric(TB_ReturnQty.Text) Then
                MessageBox.Show("반출수량은 숫자만 입력하여 주십시오.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            TB_Reason.SelectAll()
            TB_Reason.Focus()
        End If

    End Sub

    Private Sub TB_Reason_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_Reason.KeyDown

        If Not Trim(TB_Reason.Text) = String.Empty And e.KeyCode = 13 Then
            BTN_Grid_Add_Click(Nothing, Nothing)
        End If

    End Sub
End Class