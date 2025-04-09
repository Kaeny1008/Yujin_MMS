Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Material_Split

    Dim mwNo As String
    Dim partType As String

    Private Sub frm_Material_Split_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        DateTimePicker1.Value = Now
        DateTimePicker2.Value = Now

        Load_CustomerList()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub Grid_Setting()

        With Grid_SplitList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 10
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            Grid_SplitList(0, 0) = "No"
            Grid_SplitList(0, 1) = "Index"
            Grid_SplitList(0, 2) = "일자"
            Grid_SplitList(0, 3) = "자재코드"
            Grid_SplitList(0, 4) = "제조사"
            Grid_SplitList(0, 5) = "Part No."
            Grid_SplitList(0, 6) = "Lot No."
            Grid_SplitList(0, 7) = "기존수량"
            Grid_SplitList(0, 8) = "분할수량"
            Grid_SplitList(0, 9) = "잔량"
            .Cols(1).Visible = True
            .Cols(2).DataType = GetType(DateTime)
            .Cols(2).Format = "yyyy-MM-dd HH:mm:ss"
            .Cols(7).DataType = GetType(Double)
            .Cols(7).Format = "#,##0"
            .Cols(8).DataType = GetType(Double)
            .Cols(8).Format = "#,##0"
            .Cols(9).DataType = GetType(Double)
            .Cols(9).Format = "#,##0"
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

    Private Sub Load_CustomerList()

        Thread_LoadingFormStart(Me)

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

        Thread_LoadingFormEnd()

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

        TB_BarcodeScan.Focus()
        TB_BarcodeScan.SelectAll()

    End Sub

    Private Sub Control_Init()

        TB_CustomerPartCode.Text = String.Empty
        TB_PartNo.Text = String.Empty
        TB_LotNo.Text = String.Empty
        TB_Qty.Text = String.Empty
        TB_Vendor.Text = String.Empty
        TB_1stQty.Text = String.Empty
        TB_2ndQty.Text = String.Empty

    End Sub

    Private Sub TB_BarcodeScan_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_BarcodeScan.KeyDown

        If e.KeyCode = 13 And Not Trim(TB_BarcodeScan.Text) = String.Empty Then
            If TB_CustomerCode.Text = String.Empty Then
                MSG_Information(Me, "고객사를 먼저 선택하여 주십시오.")
                Exit Sub
            End If

            '바코드를 분해한다.
            If Barcode_Split() = False Then
                TB_BarcodeScan.SelectAll()
                Exit Sub
            End If

            TB_BarcodeScan.Clear()

            '그리드에 동일한 자재가 등록되어 있는지 확인 한다.
            'If Grid_ExistCheck() = True Then
            '    frm_Material_Transfer_Warning.Label1.Text = "※※※등록 실패※※※" &
            '        vbCrLf &
            '        vbCrLf &
            '        "이미 등록된 자재입니다."
            '    frm_Material_Transfer_Warning.ShowDialog()
            '    Control_Init()
            '    TB_BarcodeScan.Focus()
            '    Exit Sub
            'End If

            '입고번호를 불러온다.
            mwNo = Load_MW_No()

            If mwNo = String.Empty Then
                MSG_Information(Me, "자재의 고유번호(MW No.)를 찾을 수 없습니다.")
                Control_Init()
                Exit Sub
            End If

            If partType.Equals("SMD") Then
                'SMD 자재일 경우 전산수량과 다를 경우가 있다.
                TB_Qty.Text = TB_ServerQty.Text
                If MSG_Question(Me,
                                "!!!!!!!!!! 주의 !!!!!!!!!!" & vbCrLf &
                                "SMD 자재의 경우 전산수량과 상이 할 수 있으므로" & vbCrLf &
                                "자재 수량이 전산수량으로 대체 됩니다." & vbCrLf &
                                "기존 자재의 수량을 무시하십시오." & vbCrLf &
                                "이해 하셨습니까?") = False Then
                    MSG_Information(Me, "초기화 되었습니다.")
                    Control_Init()
                    Exit Sub
                End If
            Else
                If Not TB_Qty.Text.Equals(TB_ServerQty.Text) Then
                    MSG_Information(Me, "전산 등록된 수량과 라벨 수량이 다릅니다.")
                    Control_Init()
                    Exit Sub
                End If
            End If

            TB_1stQty.Focus()
        End If

    End Sub

    Private Function Barcode_Split() As Boolean

        Thread_LoadingFormStart(Me)

        Dim splitResult As Boolean = False

        Try
            TB_BarcodeScan.Text = TB_BarcodeScan.Text.Replace(vbCrLf, String.Empty)
            Dim splitBarcode() As String = TB_BarcodeScan.Text.Split("!")
            TB_CustomerPartCode.Text = splitBarcode(0)
            TB_PartNo.Text = splitBarcode(1)
            TB_LotNo.Text = splitBarcode(2)
            TB_Qty.Text = Format(CDbl(splitBarcode(3)), "#,##0")
            TB_Vendor.Text = splitBarcode(4)
            TB_BarcodeScan.Clear()
            splitResult = True
        Catch ex As Exception
            Thread_LoadingFormEnd()
            MSG_Error(Me, ex.Message)
        End Try

        Thread_LoadingFormEnd()

        Return splitResult

    End Function

    'Private Function Grid_ExistCheck() As Boolean

    '    Dim exist As Boolean = False

    '    For i = 1 To Grid_SplitList.Rows.Count - 1
    '        If Grid_SplitList(i, 4) = TB_CustomerPartCode.Text And
    '            Grid_SplitList(i, 6) = TB_PartNo.Text And
    '            Grid_SplitList(i, 7) = TB_LotNo.Text Then
    '            exist = True
    '        End If
    '    Next

    '    Return exist

    'End Function

    Private Function Load_MW_No() As String

        Dim mwNo As String = String.Empty

        If DBConnect() = False Then
            Return mwNo
            Exit Function
        End If

        Dim strSQL As String = "call sp_mms_material_transfer("
        strSQL += "1"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ", '" & TB_CustomerPartCode.Text & "'"
        strSQL += ", '" & TB_LotNo.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & Replace(TB_PartNo.Text, "'", "\'") & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            mwNo = sqlDR("mw_no")
            TB_InDate.Text = Format(sqlDR("write_date"), "yyyy-MM-dd HH:mm:ss")
            TextBox1.Text = sqlDR("split_count")
            TB_ServerQty.Text = Format(sqlDR("part_qty"), "#,##0")
            partType = sqlDR("part_type").ToString.ToUpper
        Loop
        sqlDR.Close()

        DBClose()

        Return mwNo

    End Function

    Private Sub TB_1stQty_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_1stQty.KeyDown

        If Not TB_1stQty.Text = String.Empty And e.KeyCode = 13 Then
            If CB_AutoCal.Checked = True And Not TB_Qty.Text = String.Empty Then
                TB_2ndQty.Text = CDbl(TB_Qty.Text) - CDbl(TB_1stQty.Text)
                BTN_Save_Click(Nothing, Nothing)
            Else
                TB_2ndQty.SelectAll()
                TB_2ndQty.Focus()
            End If
        End If

    End Sub

    Private Sub TB_2ndQty_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_2ndQty.KeyDown

        If Not TB_2ndQty.Text = String.Empty And Not TB_2ndQty.Text = String.Empty And e.KeyCode = 13 Then
            If (CDbl(TB_1stQty.Text) + CDbl(TB_2ndQty.Text)) > CDbl(TB_Qty.Text) Then
                MSG_Error(Me, "출고+보관 수량이 입고 수량보다 큽니다.")
                Exit Sub
            End If
            BTN_Save_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        If (Math.Abs(CDbl(TB_1stQty.Text)) + Math.Abs(CDbl(TB_2ndQty.Text))) > CDbl(TB_Qty.Text) Then
            MSG_Error(Me, "출고+보관 수량이 입고 수량보다 큽니다.")
            Exit Sub
        End If
        If MSG_Question(Me,
                        "※※※※출고, 보관수량을 확인하여 주십시오.※※※※" & vbCrLf &
                        "즉시 데이터(분할내용)가 저장됩니다." & vbCrLf &
                        "분할 작업을 등록하시겠습니까?" & vbCrLf &
                        "(첫번째 경고)") = False Then Exit Sub

        If MSG_Question(Me,
                        "※※※※출고, 보관수량을 확인하여 주십시오.※※※※" & vbCrLf &
                        "즉시 데이터(분할내용)가 저장됩니다." & vbCrLf &
                        "분할 작업을 등록하시겠습니까?" & vbCrLf &
                        "(두번째 경고)") = False Then Exit Sub

        Dim splitCount As Integer = CInt(TextBox1.Text)
        Dim newLotNo As String = TB_LotNo.Text & "-S" & (splitCount + 1)
        '분할내용 서버저장

        Dim dbResult As Boolean = SplitData_DB_Write(newLotNo)

        If dbResult = True Then
            Material_PrintLabel(TB_CustomerPartCode.Text,
                                TB_PartNo.Text,
                                TB_LotNo.Text,
                                TB_2ndQty.Text,
                                TB_Vendor.Text,
                                1,
                                CB_CustomerName.Text,
                                Format(CDate(TB_InDate.Text), "yyyy.MM.dd"),
                                True,
                                newLotNo,
                                TB_1stQty.Text)
        Else
            Exit Sub
        End If

        Control_Init()
        BTN_Search_Click(Nothing, Nothing)
        TB_BarcodeScan.Focus()

    End Sub

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
            strSQL += ", '" & TB_CustomerPartCode.Text & "'"
            strSQL += ", '" & TB_Vendor.Text & "'"
            strSQL += ", '" & Replace(TB_PartNo.Text, "'", "\'") & "'"
            strSQL += ", '" & TB_LotNo.Text & "'"
            strSQL += ", " & CDbl(TB_Qty.Text) & ""
            strSQL += ", " & CDbl(TB_1stQty.Text) & ""
            strSQL += ", " & CDbl(TB_2ndQty.Text) & ""
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
            strSQL += ", '" & TB_CustomerPartCode.Text & "'"
            strSQL += ", '" & TB_Vendor.Text & "'"
            strSQL += ", '" & Replace(TB_PartNo.Text, "'", "\'") & "'"
            strSQL += ", '" & newLotNo & "'"
            strSQL += ", " & CDbl(TB_1stQty.Text) & ""
            strSQL += ", '" & TB_InDate.Text & "'"
            strSQL += ", '" & loginID & "'"
            strSQL += ", " & CDbl(TB_1stQty.Text) & ""
            strSQL += ");"
            '기존자재수량에 현재 분할된 자재수량을 차감
            strSQL += "update tb_mms_material_warehousing set part_qty = " & CDbl(TB_Qty.Text) - CDbl(TB_1stQty.Text) & ""
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

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        If DBConnect() = False Then
            Exit Sub
        End If

        Grid_SplitList.Redraw = False
        Grid_SplitList.Rows.Count = 1

        Dim strSQL As String = "call sp_mms_material_transfer("
        strSQL += "8"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & Format(DateTimePicker1.Value, "yyyy-MM-dd 00:00:00") & "'"
        strSQL += ", '" & Format(DateTimePicker2.Value, "yyyy-MM-dd 23:59:59") & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = Grid_SplitList.Rows.Count & vbTab &
                sqlDR("history_index") & vbTab &
                sqlDR("write_date") & vbTab &
                sqlDR("part_code") & vbTab &
                sqlDR("part_vendor") & vbTab &
                sqlDR("part_no") & vbTab &
                sqlDR("part_lot_no") & vbTab &
                sqlDR("history_qty") & vbTab &
                sqlDR("split_1stqty") & vbTab &
                sqlDR("split_2ndqty")
            GridWriteText(insertString, Me, Grid_SplitList, Color.Black)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_SplitList.AutoSizeCols()
        Grid_SplitList.TopRow = Grid_SplitList.Rows.Count - 1
        Grid_SplitList.Redraw = True

    End Sub

    Private Sub BTN_New_Split_Click(sender As Object, e As EventArgs) Handles BTN_New_Split.Click

        Control_Init()

    End Sub
End Class