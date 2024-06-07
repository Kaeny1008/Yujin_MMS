Imports MySql.Data.MySqlClient

Public Class frm_CodeChange
    Private Sub frm_CodeChange_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SplitContainer1.SplitterDistance = SplitContainer1.Width / 2
        SplitContainer1.IsSplitterFixed = True

        Load_CustomerList()

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
            TB_AfterItemCode.SelectAll()
            TB_AfterItemCode.Focus()
        End If

    End Sub

    Private Sub Load_Information(ByVal part_code As String,
                                 ByVal part_no As String,
                                 ByVal lot_no As String,
                                 ByVal qty As Integer)

        Thread_LoadingFormStart()

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_code_change(0"
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
            TextBox1.Text = Format(sqlDR("write_date"), "yyyy-MM-dd HH:mm:ss")
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

    End Sub

    Private Sub BTN_Check_Click(sender As Object, e As EventArgs) Handles BTN_Check.Click

        If Trim(TB_AfterItemCode.Text) = String.Empty Then
            MessageBox.Show("변경하려는 Item Code를 입력하여 주십시오.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
            TB_AfterItemCode.SelectAll()
            TB_AfterItemCode.Focus()
            Exit Sub
        End If

        Load_AfterInformation(TB_AfterItemCode.Text)

        If Trim(TB_AfterSpec.Text) = String.Empty Then
            MessageBox.Show("변경하려는 Item Code의 정보를 찾지 못하였습니다.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            TB_AfterItemCode.SelectAll()
            TB_AfterItemCode.Focus()
        Else
            TB_AfterQty.Focus()
        End If

    End Sub

    Private Sub Load_AfterInformation(ByVal part_code As String)

        Thread_LoadingFormStart()

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_code_change(1"
        strSQL += ", '" & part_code & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_AfterVendor.Text = sqlDR("part_vendor")
            TB_AfterSpec.Text = sqlDR("part_specification")
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

    End Sub

    Private Sub TB_AfterQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TB_AfterQty.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "," Then
            e.Handled = True
        End If

    End Sub

    Private Sub TB_AfterItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_AfterItemCode.KeyDown

        If Not Trim(TB_AfterItemCode.Text) = String.Empty And e.KeyCode = 13 Then
            BTN_Check_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        If Not TB_Vendor.Text = String.Empty And
            Not TB_AfterSpec.Text = String.Empty And
            Not Trim(TB_Reason.Text) = String.Empty Then

            If (MessageBox.Show("품번 전환을 하시겠습니까?", msg_form, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.No Then Exit Sub

            Dim dbResult As Boolean = DB_Write()

            If dbResult = True Then
                Material_PrintLabel(TB_AfterItemCode.Text,
                                    TB_PartNo.Text,
                                    TB_LotNo.Text,
                                    TB_AfterQty.Text,
                                    TB_Vendor.Text,
                                    1,
                                    CB_CustomerName.Text,
                                    Format(CDate(TextBox1.Text), "yyyy.MM.dd"),
                                    False,
                                    String.Empty,
                                    0)
                MessageBox.Show("저장완료.(라벨을 확인하여 주십시오.)" & vbCrLf & "창이 닫힙니다.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Dispose()
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

            strSQL = "insert into tb_mms_material_history("
            strSQL += "history_index, category, write_date, writer, customer_code, part_code"
            strSQL += ", part_vendor, part_no, part_lot_no, history_qty, change_part_code, change_reason, org_in_date"
            strSQL += ") values ("
            strSQL += "f_mms_material_history_no('" & Format(CDate(writeDate), "yyyy-MM-dd") & "')"
            strSQL += ", '품번변경'"
            strSQL += ", '" & writeDate & "'"
            strSQL += ", '" & loginID & "'"
            strSQL += ", '" & TB_CustomerCode.Text & "'"
            strSQL += ", '" & TB_ItemCode.Text & "'"
            strSQL += ", '" & TB_Vendor.Text & "'"
            strSQL += ", '" & TB_PartNo.Text & "'"
            strSQL += ", '" & TB_LotNo.Text & "'"
            strSQL += ", '" & TB_AfterQty.Text & "'"
            strSQL += ", '" & TB_AfterItemCode.Text & "'"
            strSQL += ", '" & TB_Reason.Text & "'"
            strSQL += ", '" & TextBox1.Text & "'"
            strSQL += ");"

            strSQL += "insert into tb_mms_material_warehousing("
            strSQL += "mw_no, in_no, document_no, customer_code, part_code, part_vendor"
            strSQL += ", part_no, part_lot_no, part_qty, write_date, write_id"
            strSQL += ") values ("
            strSQL += "f_mms_new_mw_no(f_mms_new_in_no('" & Format(CDate(writeDate), "yyyy-MM-dd") & "', 'WD" & Format(CDate(writeDate), "yyMMdd") & "-XX'))"
            strSQL += ", f_mms_new_in_no('" & Format(CDate(writeDate), "yyyy-MM-dd") & "', 'WD" & Format(CDate(writeDate), "yyMMdd") & "-XX')"
            strSQL += ", 'WD" & Format(CDate(writeDate), "yyMMdd") & "-XX'"
            strSQL += ", '" & TB_CustomerCode.Text & "'"
            strSQL += ", '" & TB_AfterItemCode.Text & "'"
            strSQL += ", '" & TB_Vendor.Text & "'"
            strSQL += ", '" & TB_PartNo.Text & "'"
            strSQL += ", '" & TB_LotNo.Text & "'"
            strSQL += ", '" & TB_AfterQty.Text & "'"
            strSQL += ", '" & TextBox1.Text & "'"
            strSQL += ", '" & loginID & "'"
            strSQL += ");"

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
End Class