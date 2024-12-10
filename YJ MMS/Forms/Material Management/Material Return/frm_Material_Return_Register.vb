Imports C1.Win.C1FlexGrid
Imports MySqlConnector

Public Class frm_Material_Return_Register

    Dim mwNo As String

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
            .Cols.Count = 8
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
        Grid_History(0, 7) = "MW No"

    End Sub

    Private Sub Make_ReturnNo()

        If DBConnect() = False Then Exit Sub

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

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "select customer_name"
        strSQL += " from tb_customer_list"
        strSQL += " order by customer_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            CB_CustomerName.Items.Add(sqlDR("customer_name"))
            Console.WriteLine("고객사 추가 : " & sqlDR("customer_name"))
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
                MSG_Information(Me, "고객사를 먼저 선택하여 주십시오.")
                TB_Barcode.Text = String.Empty
                Exit Sub
            End If
            Dim splitBarcode() As String = TB_Barcode.Text.Split("!")
            '140500199!STW4N150!81G28FBJ0010!89!STM
            '130600027!SN65C1168PWR!20240503001!2000!TI!2024.05.03
            '140300272!SMAJ9.0CA-13-F!1933-883931J9L17.E!5000!DIODES!2024.04.05
            Try
                Load_Information(splitBarcode(0),
                                 splitBarcode(1),
                                 splitBarcode(2),
                                 CInt(splitBarcode(3))
                                 )
            Catch ex As Exception
                MSG_Error(Me, "Barcode를 정상적으로 인식하지 못하였습니다.")
                TB_Barcode.Text = String.Empty
                Exit Sub
            End Try

            If TB_Vendor.Text = String.Empty Then
                MSG_Exclamation(Me, "자재 정보를 찾지 못했습니다.")
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

        Thread_LoadingFormStart(Me)

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_material_return(0"
        strSQL += ", '" & part_code & "'"
        strSQL += ", '" & part_no & "'"
        strSQL += ", '" & lot_no & "'"
        strSQL += ", '" & qty & "'"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ",  null"
        strSQL += ",  null"
        strSQL += ",  null"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_Vendor.Text = sqlDR("part_vendor")
            TextBox1.Text = sqlDR("split_count")
            TB_InDate.Text = Format(sqlDR("write_date"), "yyyy-MM-dd HH:mm:ss")
            mwNo = sqlDR("mw_no")
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        If Grid_History.Rows.Count = 1 Then
            MSG_Information(Me, "등록된 반출 목록이 없습니다.")
            Exit Sub
        End If

        If MSG_Question(Me, "반출 등록을 하시겠습니까?") = False Then Exit Sub

        TempCode_Making()
        Dim dbResult As Boolean = DB_Write()

        If dbResult = True Then
            If MSG_Question(Me, "저장완료." & vbCrLf & "자재반납 전표를 출력 하시겠습니까?") = True Then
                '반납전표 출력
                Material_Return_Report_Print(Label14.Text)
            End If
        End If

        Me.Dispose()

    End Sub

    Dim tnNo As String

    Private Sub TempCode_Making()

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "select f_mms_material_transfer_no("
        strSQL += "'" & Format(Now, "yyyy-MM-dd") & "'"
        strSQL += ",'Out'"
        strSQL += ") as tn_no"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            tnNo = sqlDR("tn_no")
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Function DB_Write() As Boolean

        Thread_LoadingFormStart(Me, "Saving...")

        If DBConnect() = False Then
            Thread_LoadingFormEnd()
            Return False
            Exit Function
        End If

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
            strSQL += ");"

            strSQL += "update tb_mms_material_transfer set"
            strSQL += " write_date = '" & writeDate & "'"
            strSQL += ", write_id = '" & loginID & "'"
            strSQL += " where tn_no = '" & tnNo & "';"

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

                strSQL += "insert into tb_mms_material_transfer_out_content("
                strSQL += "mw_no, tn_no, part_status, tn_note, part_qty"
                strSQL += ") values("
                strSQL += "'" & Grid_History(i, 7) & "'"
                strSQL += ",'" & tnNo & "'"
                strSQL += ", 'Run'"
                strSQL += ",'반출등록에서 등록됨'"
                strSQL += "," & CDbl(Grid_History(i, 5))
                strSQL += ");"

                'Grid_History(0, 1) = "자재코드"
                'Grid_History(0, 2) = "Vendor"
                'Grid_History(0, 3) = "Vendor Code"
                'Grid_History(0, 4) = "Lot No."

                'strSQL += "update tb_mms_material_warehousing set available_qty = available_qty - " & CDbl(Grid_History(i, 5))
                'strSQL += " where customer_code = '" & TB_CustomerCode.Text & "'"
                'strSQL += " and part_code = '" & Grid_History(i, 1) & "'"
                'strSQL += " and part_no = '" & Grid_History(i, 3) & "'"
                'strSQL += " and part_lot_no = '" & Grid_History(i, 4) & "'"
                'strSQL += ";"
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
            MSG_Error(Me, ex.Message & vbCrLf & "Error No. : " & ex.Number)
            Return False
        Finally

        End Try

        DBClose()

        Thread_LoadingFormEnd()

        Return True

    End Function

    Private Sub BTN_Grid_Add_Click(sender As Object, e As EventArgs) Handles BTN_Grid_Add.Click

        If TB_Vendor.Text = String.Empty Then
            MSG_Information(Me, "등록할 자재를 먼저 스캔하여 주십시오.")
            TB_Barcode.Focus()
            Exit Sub
        End If

        If TB_ReturnQty.Text = String.Empty Then
            MSG_Information(Me, "반납수량을 입력하여 주십시오.")
            TB_ReturnQty.Focus()
            Exit Sub
        End If

        If TB_Reason.Text = String.Empty Then
            MSG_Information(Me, "반출사유를 입력하여 주십시오.")
            TB_Reason.Focus()
            Exit Sub
        End If

        Dim newLotNo As String = TB_LotNo.Text
        Dim newMwNo As String = String.Empty

        If Not CDbl(TB_Qty.Text) - CDbl(TB_ReturnQty.Text) = 0 Then
            '모든수량 반출이 아닐경우
            If MSG_Question(Me,
                            "모든수량 반출이 아닙니다." & vbCrLf &
                            "즉시 데이터(분할내용)가 저장되므로" & vbCrLf &
                            "반출수량을 확인하여 주십시오." & vbCrLf &
                            "반출목록에 등록하시겠습니까?") = False Then Exit Sub

            Dim splitCount As Integer = CInt(TextBox1.Text)
            newLotNo = TB_LotNo.Text & "-S" & (splitCount + 1)

            '분할내용 서버저장
            Dim dbResult As Boolean = SplitData_DB_Write(newLotNo)

            If dbResult = True Then
                Material_PrintLabel(TB_ItemCode.Text,
                                        TB_PartNo.Text,
                                        TB_LotNo.Text,
                                        CDbl(TB_Qty.Text) - CDbl(TB_ReturnQty.Text),
                                        TB_Vendor.Text,
                                        1,
                                        CB_CustomerName.Text,
                                        Format(CDate(TB_InDate.Text), "yyyy.MM.dd"),
                                        True,
                                        newLotNo,
                                        CDbl(TB_ReturnQty.Text))
            Else
                Exit Sub
            End If

            newMwNo = Load_New_MW_No(newLotNo)

            If newMwNo = String.Empty Then
                MSG_Error(Me, "자재의 고유번호(MW No.)를 찾을 수 없습니다.")
                Exit Sub
            End If
        End If

        '이미 반출된 자재인지 검증
        If Load_ExistData(newLotNo) > 0 Then
            MSG_Error(Me, "이미 반출된 자재입니다.")
            ControlReset()
            Exit Sub
        End If

        Dim insertString As String
        insertString = Grid_History.Rows.Count
        insertString += vbTab & TB_ItemCode.Text
        insertString += vbTab & TB_Vendor.Text
        insertString += vbTab & TB_PartNo.Text
        insertString += vbTab & newLotNo
        insertString += vbTab & TB_ReturnQty.Text
        insertString += vbTab & TB_Reason.Text
        If Not newMwNo = String.Empty Then
            insertString += vbTab & newMwNo
        Else
            insertString += vbTab & mwNo
        End If

        Grid_History.AddItem(insertString)
        Grid_History.AutoSizeCols()

        ControlReset()

        TB_Barcode.SelectAll()
        TB_Barcode.Focus()

    End Sub

    Private Function Load_ExistData(ByVal newLotNo As String) As Integer

        Dim exitData As Integer = 0

        If DBConnect() = False Then
            Return exitData
            Exit Function
        End If

        '같이쓰자 (따로 작성하지말고)
        Dim strSQL As String = "call sp_mms_material_return(7"
        strSQL += ", '" & TB_ItemCode.Text & "'"
        strSQL += ", '" & TB_PartNo.Text & "'"
        strSQL += ", '" & newLotNo & "'"
        strSQL += ", null"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ",  null"
        strSQL += ",  null"
        strSQL += ",  null"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            exitData = sqlDR("exist_data")
        Loop
        sqlDR.Close()

        DBClose()

        Return exitData

    End Function

    Private Function Load_New_MW_No(ByVal newLotNo As String) As String

        Dim newMwNo As String = String.Empty

        If DBConnect() = False Then
            Return newMwNo
            Exit Function
        End If

        '같이쓰자 (따로 작성하지말고)
        Dim strSQL As String = "call sp_mms_material_transfer("
        strSQL += "1"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ", '" & TB_ItemCode.Text & "'"
        strSQL += ", '" & newLotNo & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_PartNo.Text & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            newMwNo = sqlDR("mw_no")
        Loop
        sqlDR.Close()

        DBClose()

        Return newMwNo

    End Function

    Private Function SplitData_DB_Write(ByVal newLotNo As String) As Boolean

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
            'History에 등록
            strSQL = "insert into tb_mms_material_history("
            strSQL += "history_index, category, write_date, writer, customer_code, part_code"
            strSQL += ", part_vendor, part_no, part_lot_no, history_qty, split_1stqty, split_2ndqty, org_in_date"
            strSQL += ") values ("
            strSQL += "f_mms_material_history_no('" & Format(CDate(writeDate), "yyyy-MM-dd") & "')"
            strSQL += ", '자재분할'"
            strSQL += ", '" & writeDate & "'"
            strSQL += ", '" & loginID & "'"
            strSQL += ", '" & TB_CustomerCode.Text & "'"
            strSQL += ", '" & TB_ItemCode.Text & "'"
            strSQL += ", '" & TB_Vendor.Text & "'"
            strSQL += ", '" & TB_PartNo.Text & "'"
            strSQL += ", '" & TB_LotNo.Text & "'"
            strSQL += ", " & CDbl(TB_Qty.Text) & ""
            strSQL += ", " & CDbl(TB_ReturnQty.Text) & ""
            strSQL += ", " & CDbl(TB_Qty.Text) - CDbl(TB_ReturnQty.Text) & ""
            strSQL += ", '" & TB_InDate.Text & "'"
            strSQL += ");"
            '입고등록
            strSQL += "insert into tb_mms_material_warehousing("
            strSQL += "mw_no, in_no, document_no, customer_code, part_code, part_vendor"
            strSQL += ", part_no, part_lot_no, part_qty, write_date, write_id, available_qty"
            strSQL += ") values ("
            strSQL += "f_mms_new_mw_no(f_mms_new_in_no('" & Format(CDate(writeDate), "yyyy-MM-dd") & "', 'WD" & Format(CDate(writeDate), "yyMMdd") & "-XX'))"
            strSQL += ", f_mms_new_in_no('" & Format(CDate(writeDate), "yyyy-MM-dd") & "', 'WD" & Format(CDate(writeDate), "yyMMdd") & "-XX')"
            strSQL += ", 'WD" & Format(CDate(writeDate), "yyMMdd") & "-XX'"
            strSQL += ", '" & TB_CustomerCode.Text & "'"
            strSQL += ", '" & TB_ItemCode.Text & "'"
            strSQL += ", '" & TB_Vendor.Text & "'"
            strSQL += ", '" & TB_PartNo.Text & "'"
            strSQL += ", '" & newLotNo & "'"
            strSQL += ", " & CDbl(TB_ReturnQty.Text) & ""
            strSQL += ", '" & TB_InDate.Text & "'"
            strSQL += ", '" & loginID & "'"
            strSQL += ", " & CDbl(TB_ReturnQty.Text) & ""
            strSQL += ");"
            '기존자재수량에 현재 분할된 자재수량을 차감
            strSQL += "update tb_mms_material_warehousing set part_qty = " & CDbl(TB_Qty.Text) - CDbl(TB_ReturnQty.Text) & ""
            'strSQL += ", available_qty = available_qty - " & CDbl(TB_ReturnQty.Text) & ""
            strSQL += ", split_count = " & CInt(TextBox1.Text) + 1 & ""
            strSQL += " where mw_no = '" & mwNo & "';"

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
            Return False
        Finally

        End Try

        DBClose()

        Thread_LoadingFormEnd()

        Return True

    End Function

    Private Sub ControlReset()

        TB_Barcode.Text = String.Empty
        TB_ItemCode.Text = String.Empty
        TB_Vendor.Text = String.Empty
        TB_PartNo.Text = String.Empty
        TB_LotNo.Text = String.Empty
        TB_ReturnQty.Text = String.Empty
        'TB_Reason.Text = String.Empty
        TB_Qty.Text = String.Empty
        TextBox1.Text = String.Empty
        TB_InDate.Text = String.Empty

    End Sub

    Private Sub TB_ReturnQty_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_ReturnQty.KeyDown

        If Not Trim(TB_ReturnQty.Text) = String.Empty And e.KeyCode = 13 Then
            If Not IsNumeric(TB_ReturnQty.Text) Then
                MSG_Information(Me, "반출수량은 숫자만 입력하여 주십시오.")
                Exit Sub
            End If

            If CDbl(TB_ReturnQty.Text).Equals(0) Then
                MSG_Information(Me, "1이상 숫자를 입력하여 주십시오.")
                TB_ReturnQty.SelectAll()
                TB_ReturnQty.Focus()
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