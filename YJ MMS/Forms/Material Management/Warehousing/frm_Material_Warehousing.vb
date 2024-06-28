Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Material_Warehousing

    Dim barcode1 As String
    Dim barcode2 As String
    Dim barcode3 As String

    Private Sub frm_Material_Warehousing_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()
        Timer1.Interval = 3000
        Timer1.Stop()
        Label14.Visible = False

        DTP_Start.Value = Format(Now, "yyyy-MM-01 00:00:00")
        DTP_End.Value = Format(Now, "yyyy-MM-dd 23:59:59")

    End Sub

    Private Sub Grid_Setting()

        With Grid_DocumentsList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 5
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            Grid_DocumentsList(0, 0) = "No"
            Grid_DocumentsList(0, 1) = "문서번호"
            Grid_DocumentsList(0, 2) = "공급사"
            Grid_DocumentsList(0, 3) = "입고품목 수"
            Grid_DocumentsList(0, 4) = "완료여부"
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

        With Grid_MaterialList
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
            Grid_MaterialList(0, 0) = "No"
            Grid_MaterialList(0, 1) = "자재코드"
            Grid_MaterialList(0, 2) = "Part No."
            Grid_MaterialList(0, 3) = "입고수량"
            Grid_MaterialList(0, 4) = "확인수량"
            Grid_MaterialList(0, 5) = "미과출"
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

        With Grid_PartList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 14
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            Grid_PartList(0, 0) = "No"
            Grid_PartList(0, 1) = "YJ Part Code(LOT)"
            Grid_PartList(0, 2) = "입고 No."
            Grid_PartList(0, 3) = "고객사코드"
            Grid_PartList(0, 4) = "고객사"
            Grid_PartList(0, 5) = "자재코드"
            Grid_PartList(0, 6) = "타입"
            Grid_PartList(0, 7) = "Vendor"
            Grid_PartList(0, 8) = "Part No."
            Grid_PartList(0, 9) = "Lot No."
            Grid_PartList(0, 10) = "수량"
            Grid_PartList(0, 11) = "Barcode1"
            Grid_PartList(0, 12) = "Barcode2"
            Grid_PartList(0, 13) = "Barcode3"
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

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        TB_DocumentNo.Text = String.Empty
        TB_Supplier.Text = String.Empty

        Grid_PartList.Rows.Count = 1
        Grid_MaterialList.Rows.Count = 1

        TB_InNo.Text = String.Empty
        CB_CustomerName.SelectedIndex = -1
        TB_CustomerCode.Text = String.Empty
        TB_BarcodeScan.Text = String.Empty
        TB_CustomerPartCode.Text = String.Empty
        TB_PartNo.Text = String.Empty
        TB_LotNo.Text = String.Empty
        TB_Qty.Text = String.Empty
        TB_Vendor.Text = String.Empty

        Thread_LoadingFormStart()

        Grid_DocumentsList.Redraw = False
        Grid_DocumentsList.Rows.Count = 1

        DBConnect()

        Dim checkResult As String = String.Empty
        If RadioButton1.Checked Then
            checkResult = RadioButton1.Text
        ElseIf RadioButton2.Checked Then
            checkResult = RadioButton2.Text
        ElseIf RadioButton3.Checked Then
            checkResult = RadioButton3.Text
        End If

        Dim strSQL As String = "call sp_mms_material_warehousing(0"
        strSQL += ", null"
        strSQL += ", '" & checkResult & "'"
        strSQL += ", '" & Format(DTP_Start.Value, "yyyy-MM-dd 00:00:00") & "'"
        strSQL += ", '" & Format(DTP_End.Value, "yyyy-MM-dd HH:mm:ss") & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += " , null"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_DocumentsList.Rows.Count & vbTab &
                                          sqlDR("document_no") & vbTab &
                                          sqlDR("supplier") & vbTab &
                                          Format(sqlDR("in_count"), "#,##0") & vbTab &
                                          sqlDR("check_result")
            Grid_DocumentsList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_DocumentsList.AutoSizeCols()
        Grid_DocumentsList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_DocumentsList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Grid_DocumentsList.MouseDoubleClick

        Dim gridRow As Integer = Grid_DocumentsList.MouseRow

        If gridRow > 0 And e.Button = MouseButtons.Left Then
            Thread_LoadingFormStart()

            Grid_MaterialList.Redraw = False
            Grid_MaterialList.Rows.Count = 1

            DBConnect()

            Load_CustomerList()
            Load_MaterialList(Grid_DocumentsList(gridRow, 1))
            Load_NewInNo(Grid_DocumentsList(gridRow, 1))
            Load_MaterialList_Detail(Grid_DocumentsList(gridRow, 1))

            DBClose()

            Grid_MaterialList.AutoSizeCols()
            Grid_MaterialList.Redraw = True

            TB_DocumentNo.Text = Grid_DocumentsList(gridRow, 1)
            TB_Supplier.Text = Grid_DocumentsList(gridRow, 2)

            If Grid_DocumentsList(gridRow, 4) = "완료" Then
                BTN_Save.Enabled = False
                BTN_ListAdd.Enabled = False
                CB_CustomerName.Enabled = False
                TB_BarcodeScan.Enabled = False
            Else
                BTN_Save.Enabled = True
                BTN_ListAdd.Enabled = True
                CB_CustomerName.Enabled = True
                TB_BarcodeScan.Enabled = True
            End If

            Thread_LoadingFormEnd()
        End If

    End Sub

    Private Sub Load_CustomerList()

        CB_CustomerName.Items.Clear()

        Dim strSQL As String = "select customer_name"
        strSQL += " from tb_customer_list"
        strSQL += " order by customer_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            CB_CustomerName.Items.Add(sqlDR("customer_name"))
        Loop
        sqlDR.Close()

    End Sub

    Private Sub Load_MaterialList(ByVal documentNo As String)

        Dim strSQL As String = "call sp_mms_material_warehousing(1"
        strSQL += ",'" & documentNo & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += " , null"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_MaterialList.Rows.Count & vbTab &
                                          sqlDR("part_code") & vbTab &
                                          sqlDR("part_no") & vbTab &
                                          Format(sqlDR("part_qty"), "#,##0") & vbTab &
                                          Format(sqlDR("in_qty"), "#,##0") & vbTab &
                                          Format(sqlDR("in_qty") - sqlDR("part_qty"), "#,##0")
            Grid_MaterialList.AddItem(insert_String)
            If (sqlDR("in_qty") - sqlDR("part_qty")) = 0 Then
                Grid_MaterialList.Rows(Grid_MaterialList.Rows.Count - 1).StyleNew.ForeColor = Color.Blue
                Grid_MaterialList.Rows(Grid_MaterialList.Rows.Count - 1).StyleNew.BackColor = Color.White
            ElseIf (sqlDR("in_qty") - sqlDR("part_qty")) > 0 Then
                Grid_MaterialList.Rows(Grid_MaterialList.Rows.Count - 1).StyleNew.ForeColor = Color.Red
                Grid_MaterialList.Rows(Grid_MaterialList.Rows.Count - 1).StyleNew.BackColor = Color.Yellow
            End If
        Loop
        sqlDR.Close()

    End Sub

    Private Sub Load_NewInNo(ByVal documentNo As String)

        Dim strSQL As String = "select f_mms_new_in_no("
        strSQL += "'" & Format(Now, "yyyy-MM-dd") & "'"
        strSQL += ",'" & documentNo & "'"
        strSQL += ") as new_in_no"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_InNo.Text = sqlDR("new_in_no")
        Loop
        sqlDR.Close()

    End Sub

    Private Sub Load_MaterialList_Detail(ByVal documentNo As String)

        Grid_PartList.Redraw = False
        Grid_PartList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_warehousing(2"
        strSQL += ",'" & documentNo & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += " , null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_PartList.Rows.Count & vbTab &
                                          sqlDR("mw_no") & vbTab &
                                          sqlDR("in_no") & vbTab &
                                          sqlDR("customer_code") & vbTab &
                                          sqlDR("customer_name") & vbTab &
                                          sqlDR("part_code") & vbTab &
                                          sqlDR("part_type") & vbTab &
                                          sqlDR("part_vendor") & vbTab &
                                          sqlDR("part_no") & vbTab &
                                          sqlDR("part_lot_no") & vbTab &
                                          sqlDR("part_qty") & vbTab &
                                          sqlDR("barcode1") & vbTab &
                                          sqlDR("barcode2") & vbTab &
                                          sqlDR("barcode3")
            Grid_PartList.AddItem(insert_String)
            CB_CustomerName.Text = sqlDR("customer_name")
            CB_CustomerName_SelectionChangeCommitted(Nothing, Nothing)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_PartList.AutoSizeCols()
        Grid_PartList.Redraw = True

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

        If CB_CustomerName.Text = "LS Mecapion" Then
            RB_2DType.Checked = True
            TB_SplitChar.Text = "!"
        End If

        TB_BarcodeScan.Focus()
        TB_BarcodeScan.SelectAll()

    End Sub

    Private Sub TB_BarcodeScan_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_BarcodeScan.KeyDown

        If (e.KeyCode = 13) And
            (Not TB_BarcodeScan.Text = String.Empty) Then
            If CB_CustomerName.Text = String.Empty Then
                MessageBox.Show(Me,
                                "사용 고객사를 먼저 선택하여 주십시오.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                TB_BarcodeScan.SelectAll()
                Exit Sub
            End If

            If CB_CustomerName.Text = "LS Mecapion" Then
                Try
                    Dim splitBarcode() As String = TB_BarcodeScan.Text.Split(TB_SplitChar.Text)
                    TB_CustomerPartCode.Text = splitBarcode(0)
                    TB_PartNo.Text = splitBarcode(1)
                    TB_LotNo.Text = splitBarcode(2)
                    TB_Qty.Text = Format(CInt(splitBarcode(3)), "#,##0")
                    TB_Vendor.Text = splitBarcode(4)
                Catch ex As Exception
                    MessageBox.Show(Me,
                                    ex.Message,
                                    msg_form,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    TB_CustomerPartCode.Text = String.Empty
                    TB_PartNo.Text = String.Empty
                    TB_LotNo.Text = String.Empty
                    TB_Qty.Text = String.Empty
                    TB_Vendor.Text = String.Empty
                    Exit Sub
                End Try
            Else
                MsgBox("현재 LS Mecapion외 지원되지 않습니다.")
            End If

            If Find_DocumentList() = False Then
                MessageBox.Show(Me,
                                "입고 리스트에서 해당 자재를 찾지 못했습니다.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                TB_CustomerPartCode.Text = String.Empty
                TB_PartNo.Text = String.Empty
                TB_LotNo.Text = String.Empty
                TB_Qty.Text = String.Empty
                TB_Vendor.Text = String.Empty
                TB_BarcodeScan.SelectAll()
                Exit Sub
            Else
                Dim find_PartCode As Integer = Grid_MaterialList.FindRow(TB_CustomerPartCode.Text, 1, 1, True)
                Dim find_PartNo As Integer = Grid_MaterialList.FindRow(TB_PartNo.Text, 1, 2, True)

                If find_PartCode > 0 Then
                    Grid_MaterialList(find_PartCode, 4) = Format(CInt(Grid_MaterialList(find_PartCode, 4)) + CInt(TB_Qty.Text), "#,##0")
                    Grid_MaterialList(find_PartCode, 5) = Format(CInt(Grid_MaterialList(find_PartCode, 4)) - CInt(Grid_MaterialList(find_PartCode, 3)), "#,##0")
                    If Grid_MaterialList(find_PartCode, 5) > 0 Then
                        Grid_MaterialList.Rows(find_PartCode).StyleNew.ForeColor = Color.Red
                        Grid_MaterialList.Rows(find_PartCode).StyleNew.BackColor = Color.Yellow
                    ElseIf Grid_MaterialList(find_PartCode, 5) = 0 Then
                        Grid_MaterialList.Rows(find_PartCode).StyleNew.ForeColor = Color.Blue
                        Grid_MaterialList.Rows(find_PartCode).StyleNew.BackColor = Color.White
                    End If
                Else
                    Grid_MaterialList(find_PartNo, 4) = Format(CInt(Grid_MaterialList(find_PartNo, 4)) + CInt(TB_Qty.Text), "#,##0")
                    Grid_MaterialList(find_PartNo, 5) = Format(CInt(Grid_MaterialList(find_PartNo, 4)) - CInt(Grid_MaterialList(find_PartNo, 3)), "#,##0")
                    If Grid_MaterialList(find_PartNo, 5) > 0 Then
                        Grid_MaterialList.Rows(find_PartNo).StyleNew.ForeColor = Color.Red
                        Grid_MaterialList.Rows(find_PartNo).StyleNew.BackColor = Color.Yellow
                    ElseIf Grid_MaterialList(find_PartNo, 5) = 0 Then
                        Grid_MaterialList.Rows(find_PartNo).StyleNew.ForeColor = Color.Blue
                        Grid_MaterialList.Rows(find_PartNo).StyleNew.BackColor = Color.White
                    End If
                End If
            End If

            If barcode1 = String.Empty Then
                barcode1 = TB_BarcodeScan.Text
            ElseIf barcode2 = String.Empty Then
                barcode2 = TB_BarcodeScan.Text
            ElseIf barcode3 = String.Empty Then
                barcode3 = TB_BarcodeScan.Text
            End If

            BTN_ListAdd_Click(Nothing, Nothing)
            TB_BarcodeScan.SelectAll()
        End If

    End Sub

    Private Function Find_DocumentList() As Boolean

        Find_DocumentList = False

        Dim find_PartCode As Integer = Grid_MaterialList.FindRow(TB_CustomerPartCode.Text, 1, 1, True)
        Dim find_PartNo As Integer = Grid_MaterialList.FindRow(TB_PartNo.Text, 1, 2, True)

        If (find_PartCode > 0) Or
            (find_PartCode > 0) Then
            Find_DocumentList = True
        End If

        Return Find_DocumentList

    End Function

    Private Sub TB_BarcodeScan_GotFocus(sender As Object, e As EventArgs) Handles TB_BarcodeScan.GotFocus

        TB_BarcodeScan.SelectAll()

    End Sub

    Private Sub TB_BarcodeScan_MouseClick(sender As Object, e As MouseEventArgs) Handles TB_BarcodeScan.MouseClick

        TB_BarcodeScan.SelectAll()

    End Sub

    Private Sub BTN_ListAdd_Click(sender As Object, e As EventArgs) Handles BTN_ListAdd.Click

        If TB_PartNo.Text = String.Empty Or
            TB_Qty.Text = String.Empty Or
            TB_CustomerPartCode.Text = String.Empty Then
            Exit Sub
        End If

        If Not Check_Lot_No() = "Not Exist" Then
            MessageBox.Show(Me,
                            "중복된 Lot No.입니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            TB_CustomerPartCode.Text = String.Empty
            TB_PartNo.Text = String.Empty
            TB_LotNo.Text = String.Empty
            TB_Qty.Text = String.Empty
            TB_Vendor.Text = String.Empty
            Exit Sub
        End If

        Thread_LoadingFormStart("Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim writeDate2 As String = Format(Now, "yyyy-MM-dd")

            strSQL = "insert into tb_mms_material_warehousing("
            strSQL += "mw_no, in_no, document_no, customer_code, part_code, part_vendor, part_no, part_lot_no"
            strSQL += ", part_qty, barcode1,barcode2, barcode3, write_date, write_id"
            strSQL += ") values("
            strSQL += "f_mms_new_mw_no('" & TB_InNo.Text & "')"
            strSQL += ", '" & TB_InNo.Text & "'"
            strSQL += ", '" & TB_DocumentNo.Text & "'"
            strSQL += ", '" & TB_CustomerCode.Text & "'"
            strSQL += ", '" & TB_CustomerPartCode.Text & "'"
            strSQL += ", '" & TB_Vendor.Text & "'"
            strSQL += ", '" & TB_PartNo.Text & "'"
            strSQL += ", '" & TB_LotNo.Text & "'"
            strSQL += ", '" & CInt(TB_Qty.Text) & "'"
            strSQL += ", '" & barcode1 & "'"
            strSQL += ", '" & barcode2 & "'"
            strSQL += ", '" & barcode3 & "'"
            strSQL += ", '" & writeDate & "'"
            strSQL += ", '" & loginID & "');"

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
            MessageBox.Show(ex.Message & vbCrLf & "Error No. : " & ex.Number,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1)
            Timer1.Start()
            Label14.Visible = True
            Label14.Text = "등록실패"
            Label14.ForeColor = Color.Red
            TB_BarcodeScan.Focus()
            TB_BarcodeScan.SelectAll()
            Exit Sub
        Finally
            Timer1.Start()
            Label14.Visible = True
            Label14.Text = "등록성공"
            Label14.ForeColor = Color.Yellow
        End Try

        DBClose()

        Load_MaterialList_Detail(TB_DocumentNo.Text)

        Thread_LoadingFormEnd()

        TB_PartNo.Text = String.Empty
        TB_LotNo.Text = String.Empty
        TB_Qty.Text = String.Empty
        TB_CustomerPartCode.Text = String.Empty
        TB_Vendor.Text = String.Empty
        barcode1 = String.Empty
        barcode2 = String.Empty
        barcode3 = String.Empty
        TB_BarcodeScan.Focus()
        TB_BarcodeScan.SelectAll()

    End Sub

    Private Function Check_Lot_No() As String

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_warehousing(3"
        strSQL += ", null"
        strSQL += " , null"
        strSQL += " , null"
        strSQL += " , null"
        strSQL += " , '" & TB_CustomerPartCode.Text & "'"
        strSQL += " , '" & TB_PartNo.Text.Replace("'", "\'") & "'"
        strSQL += " , '" & TB_LotNo.Text & "'"
        strSQL += ");"

        Dim returnString As String = "Not Exist"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            returnString = sqlDR("exist_same_lot")
        Loop
        sqlDR.Close()

        DBClose()

        Return returnString

    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Label14.Visible = True Then
            Label14.Visible = False
            Timer1.Stop()
        End If

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub TB_BarcodeScan_TextChanged(sender As Object, e As EventArgs) Handles TB_BarcodeScan.TextChanged

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        Dim notInput As String = String.Empty
        Dim overinput As String = String.Empty

        For i = 1 To Grid_MaterialList.Rows.Count - 1
            If Grid_MaterialList(i, 5) < 0 Then
                If notInput = String.Empty Then
                    notInput = i
                Else
                    notInput += ", " & i
                End If
            ElseIf Grid_MaterialList(i, 5) > 0 Then
                If overinput = String.Empty Then
                    overinput = i
                Else
                    overinput += ", " & i
                End If
            End If
        Next

        If (Not notInput = String.Empty) Or
            (Not overinput = String.Empty) Then
            Dim msgString As String = String.Empty
            If Not notInput = String.Empty Then
                msgString = "미출인 항목이 존재합니다." & vbCrLf & "행번호 : " & notInput
            End If
            If Not overinput = String.Empty Then
                If msgString = String.Empty Then
                    msgString = "과출인 항목이 존재합니다." & vbCrLf & "행번호 : " & overinput
                Else
                    msgString += vbCrLf & vbCrLf & "과출인 항목이 존재합니다." & vbCrLf & "행번호 : " & overinput
                End If
            End If
            MessageBox.Show(Me,
                            msgString,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Exit Sub
        Else
            If MessageBox.Show(Me,
                   "저장 하시겠습니까?",
                   msg_form,
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        End If

        Thread_LoadingFormStart("Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            strSQL = "update tb_mms_material_warehousing_document set"
            strSQL += " check_date = '" & writeDate & "'"
            strSQL += ", check_id = '" & loginID & "'"
            strSQL += " where document_no = '" & TB_DocumentNo.Text & "';"

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
                            ex.Message & vbCrLf & "Error No. : " & ex.Number,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Exit Sub
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        MessageBox.Show(Me,
                        "저장완료.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

        BTN_Save.Enabled = False
        BTN_ListAdd.Enabled = False

        BTN_Search_Click(Nothing, Nothing)

    End Sub
End Class