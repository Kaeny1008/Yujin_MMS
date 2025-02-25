Imports System.IO
Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient


Public Class frm_Material_Warehousing_With_Label

    Dim barcode1 As String
    Dim barcode2 As String
    Dim barcode3 As String

    Dim beforeVendor As String
    Dim beforePartCode As String

    Private Sub frm_Material_Warehousing_With_Label_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        TB_CustomerName.Text = String.Empty
        TB_CustomerCode.Text = String.Empty
        TB_BarcodeScan.Text = String.Empty
        TB_CustomerPartCode.Text = String.Empty
        TB_PartNo.Text = String.Empty
        TB_LotNo.Text = String.Empty
        TB_Qty.Text = String.Empty
        TB_Vendor.Text = String.Empty

        Thread_LoadingFormStart(Me)

        Grid_DocumentsList.Redraw = False
        Grid_DocumentsList.Rows.Count = 1

        If DBConnect() = False Then Exit Sub

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
        strSQL += " , null"
        strSQL += " , null"
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
            Thread_LoadingFormStart(Me)

            TB_ItemCode.Text = String.Empty
            CB_Vendor.SelectedIndex = -1
            TB_BarcodeScan.Text = String.Empty
            TB_CustomerPartCode.Text = String.Empty
            TB_Vendor.Text = String.Empty
            TB_PartNo.Text = String.Empty
            TB_LotNo.Text = String.Empty
            TB_Qty.Text = String.Empty

            Grid_MaterialList.Redraw = False
            Grid_MaterialList.Rows.Count = 1

            If DBConnect() = False Then Exit Sub

            'Load_CustomerList()
            Load_MaterialList(Grid_DocumentsList(gridRow, 1))
            Load_CustomerName()
            'Load_NewInNo(Grid_DocumentsList(gridRow, 1))
            Load_MaterialList_Detail(Grid_DocumentsList(gridRow, 1))

            DBClose()

            Grid_MaterialList.AutoSizeCols()
            Grid_MaterialList.Redraw = True

            TB_DocumentNo.Text = Grid_DocumentsList(gridRow, 1)
            TB_Supplier.Text = Grid_DocumentsList(gridRow, 2)

            If Grid_DocumentsList(gridRow, 4) = "완료" Then
                BTN_Save.Enabled = False
                BTN_ListAdd.Enabled = False
                'CB_CustomerName.Enabled = False
                TB_BarcodeScan.Enabled = False
            Else
                BTN_Save.Enabled = True
                BTN_ListAdd.Enabled = True
                'CB_CustomerName.Enabled = True
                TB_BarcodeScan.Enabled = True
            End If

            Thread_LoadingFormEnd()
        End If

    End Sub

    'Private Sub Load_CustomerList()

    '    CB_CustomerName.Items.Clear()

    '    Dim strSQL As String = "select customer_name"
    '    strSQL += " from tb_customer_list"
    '    strSQL += " order by customer_name"

    '    Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
    '    Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

    '    Do While sqlDR.Read
    '        CB_CustomerName.Items.Add(sqlDR("customer_name"))
    '    Loop
    '    sqlDR.Close()

    'End Sub

    Private Sub Load_MaterialList(ByVal documentNo As String)

        Dim strSQL As String = "call sp_mms_material_warehousing(1"
        strSQL += ",'" & documentNo & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += " , null"
        strSQL += " , null"
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
            TB_CustomerCode.Text = sqlDR("customer_code")
        Loop
        sqlDR.Close()

    End Sub

    Private Sub Load_CustomerName()

        Dim strSQL As String = "select customer_name"
        strSQL += " from tb_customer_list"
        strSQL += " where customer_code = '" & TB_CustomerCode.Text & "'"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_CustomerName.Text = sqlDR("customer_name")
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

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_material_warehousing(2"
        strSQL += ",'" & documentNo & "'"
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
            'CB_CustomerName_SelectionChangeCommitted(Nothing, Nothing)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_PartList.AutoSizeCols()
        Grid_PartList.Redraw = True

    End Sub

    'Private Sub CB_CustomerName_SelectionChangeCommitted(sender As Object, e As EventArgs)

    '    TB_CustomerCode.Text = String.Empty

    '    If DBConnect() = False Then Exit Sub

    '    Dim strSQL As String = "select customer_code, ifnull(use_part_code, '') as use_part_code"
    '    strSQL += " from tb_customer_list"
    '    strSQL += " where customer_name = '" & CB_CustomerName.Text & "'"
    '    strSQL += " order by customer_name"

    '    Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
    '    Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

    '    Do While sqlDR.Read
    '        TB_CustomerCode.Text = sqlDR("customer_code")
    '    Loop
    '    sqlDR.Close()

    '    DBClose()

    '    'If CB_CustomerName.Text = "LS Mecapion" Then
    '    '    RB_2DType.Checked = True
    '    '    TB_SplitChar.Text = "!"
    '    'End If

    '    TB_BarcodeScan.Focus()
    '    TB_BarcodeScan.SelectAll()

    'End Sub

    Private Sub TB_BarcodeScan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TB_BarcodeScan.KeyPress
        Console.WriteLine("Key : " & e.KeyChar & " , ascii : " & Asc(e.KeyChar))
        If Asc(e.KeyChar) = 29 Then e.KeyChar = "!"
        If Asc(e.KeyChar) = 35 Then e.KeyChar = "!" '#
    End Sub

    Private Sub TB_BarcodeScan_TextChanged_1(sender As Object, e As EventArgs) Handles TB_BarcodeScan.TextChanged

    End Sub

    Private Sub TB_BarcodeScan_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_BarcodeScan.KeyDown

        If (e.KeyCode = 13) And
            (Not TB_BarcodeScan.Text = String.Empty) Then

            Dim asciiTest As Integer = System.Text.Encoding.ASCII.GetByteCount(TB_BarcodeScan.Text)
            Dim unicodeTest As Integer = System.Text.Encoding.UTF8.GetByteCount(TB_BarcodeScan.Text)

            If asciiTest <> unicodeTest Then
                MSG_Exclamation(Me, "특수문자를 입력할 수 없습니다.")
                TB_BarcodeScan.SelectAll()
                TB_BarcodeScan.Focus()
                Exit Sub
            End If

            If TB_CustomerName.Text = "LS Mecapion" Then
                If RB_Supplier.Checked Then
                    SplitBarcode_Supplier()
                ElseIf RB_Vendor.Checked Then
                    If CB_Vendor.Text = String.Empty Then
                        MSG_Information(Me, "제조사를 먼저 선택하여 주십시오.")
                        Exit Sub
                    End If
                    Dim replaceBarcode As String = TB_BarcodeScan.Text.Replace(vbCrLf, "!")
                    SplitBarcode_Vendor(replaceBarcode, CB_Vendor.Text)
                End If
            Else
                MSG_Information(Me, "현재 LS Mecapion외 지원되지 않습니다.")
                Exit Sub
            End If

            'TB_BarcodeScan.SelectAll()
            'TB_BarcodeScan.Focus()
            TB_BarcodeScan.Multiline = False
            TB_BarcodeScan.Text = String.Empty
            TB_BarcodeScan.Multiline = True

            If TB_CustomerPartCode.Text = String.Empty Or
                TB_PartNo.Text = String.Empty Or
                TB_Qty.Text = String.Empty Or
                TB_LotNo.Text = String.Empty Then
                Thread_LoadingFormEnd()
                Exit Sub
            End If

            If Find_DocumentList() = False Then
                MSG_Error(Me, "입고 리스트에서 해당 자재를 찾지 못했습니다.")
                TB_CustomerPartCode.Text = String.Empty
                TB_PartNo.Text = String.Empty
                TB_LotNo.Text = String.Empty
                TB_Qty.Text = String.Empty
                TB_Vendor.Text = String.Empty
                Exit Sub
            End If

            If barcode1 = String.Empty Then
                barcode1 = TB_BarcodeScan.Text
            ElseIf barcode2 = String.Empty Then
                barcode2 = TB_BarcodeScan.Text
            ElseIf barcode3 = String.Empty Then
                barcode3 = TB_BarcodeScan.Text
            End If

            BTN_ListAdd_Click(Nothing, Nothing)
        End If

    End Sub

    Private Function Check_Lot_No() As String

        If DBConnect() = False Then
            Return "Server Connect Fail"
            Exit Function
        End If

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

    Private Sub SplitBarcode_Supplier()

        Thread_LoadingFormStart(Me)

        Try
            '140300358!MSS1P3-M3/89A!20240328001!4,500!VISHAY!2024.03.28
            Dim splitBarcode() As String = TB_BarcodeScan.Text.Split("!")
            TB_CustomerPartCode.Text = Trim(splitBarcode(0))
            TB_PartNo.Text = Trim(splitBarcode(1))
            TB_LotNo.Text = Trim(splitBarcode(2))
            If CheckBox1.Checked = False Then
                TB_Qty.Text = Format(CInt(Trim(splitBarcode(3))), "#,##0")
            End If
            TB_Vendor.Text = Trim(splitBarcode(4))
        Catch ex As Exception
            MSG_Error(Me, ex.Message)
            TB_CustomerPartCode.Text = String.Empty
            TB_PartNo.Text = String.Empty
            TB_LotNo.Text = String.Empty
            TB_Qty.Text = String.Empty
            TB_Vendor.Text = String.Empty
        End Try

        Thread_LoadingFormEnd()

    End Sub

    Private Sub SplitBarcode_Vendor(ByVal barcode As String, ByVal vendor As String)

        Console.WriteLine(barcode)
        Dim splitResult As String = Load_PHP(phpUrl & phpRootFolder &
                                             "/barcodesplit.php?barcode=" &
                                             barcode &
                                             "&maker=" &
                                             vendor.ToUpper,
                                             "BarcodeSplitResult",
                                             "returnStr")

        Console.WriteLine(splitResult)
        If splitResult.Split("!@")(0) = "Success" Then
            Dim resultSplit() As String = splitResult.Split("!@")
            If UBound(resultSplit) = 4 Then
                Dim partNo As String = resultSplit(1).Replace("@P:", String.Empty)
                Dim lotNo As String = resultSplit(2).Replace("@L:", String.Empty)
                Dim qty As String = resultSplit(3).Replace("@Q:", String.Empty)
                Dim org As String = resultSplit(4).Replace("@ORG:", String.Empty)

                'Console.WriteLine(splitResult)
                'Console.WriteLine(partNo)
                'Console.WriteLine(lotNo)
                'Console.WriteLine(qty)
                'Console.WriteLine(org)

                If org = String.Empty Then
                    If TB_PartNo.Text = String.Empty Then TB_PartNo.Text = partNo
                    If TB_LotNo.Text = String.Empty Then TB_LotNo.Text = lotNo
                    If CheckBox1.Checked = False Then
                        If TB_Qty.Text = String.Empty Then TB_Qty.Text = qty
                    End If
                Else
                    If TB_PartNo.Text = String.Empty Then
                        TB_PartNo.Text = org
                    ElseIf TB_LotNo.Text = String.Empty Then
                        TB_LotNo.Text = org
                    ElseIf TB_Qty.Text = String.Empty Then
                        TB_Qty.Text = org
                    End If
                End If
            Else
                If resultSplit(1).Replace("@", String.Empty).Equals("Not found vendor") Then
                    MSG_Error(Me, "Vendor를 찾을 수 없습니다.")
                Else
                    MSG_Error(Me, resultSplit(1).Replace("@", String.Empty))
                End If
            End If
        Else
            Thread_LoadingFormEnd()
            MSG_Error(Me, splitResult.Split("!@")(1).Replace("@", String.Empty))
            TB_BarcodeScan.Focus()
            TB_BarcodeScan.SelectAll()
            Exit Sub

        End If
        TB_BarcodeScan.Focus()
        TB_BarcodeScan.SelectAll()

        'If RB_CustomerCode.Checked Then Load_CustomerPartCode()
        TB_CustomerPartCode.Text = TB_ItemCode.Text
        TB_Vendor.Text = CB_Vendor.Text

        If barcode1 = String.Empty Then
            barcode1 = TB_BarcodeScan.Text
        ElseIf barcode2 = String.Empty Then
            barcode2 = TB_BarcodeScan.Text
        ElseIf barcode3 = String.Empty Then
            barcode3 = TB_BarcodeScan.Text
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
                TB_LotNo.Text = String.Empty Or
            TB_Qty.Text = String.Empty Or
            TB_CustomerPartCode.Text = String.Empty Then
            Exit Sub
        End If

        If Not Check_Lot_No() = "Not Exist" Then
            'If CB_Vendor.Text = "KEC" Or CB_Vendor.Text = "NEXPERIA" Then
            Dim reelIndex As String = InputBox("Lot No.가 중복 되었습니다." & vbCrLf &
                                               "Reel 번호를 입력하십시오." & vbCrLf & vbCrLf &
                                               "※주의 : 실제 저장된 데이터 일 수 있습니다.(라벨 미부착으로)" & vbCrLf &
                                               "정확히 확인하여 구분되는 Reel 번호를 입력하여 주십시오.",
                                               msg_form, String.Empty)
            If reelIndex = String.Empty Then
                Exit Sub
            End If
            TB_LotNo.Text += "-" & reelIndex
            BTN_ListAdd_Click(Nothing, Nothing)
            Exit Sub
            'Else
            '    MSG_Error(Me, "중복된 Lot No.입니다.")
            '    TB_CustomerPartCode.Text = String.Empty
            '    TB_PartNo.Text = String.Empty
            '    TB_LotNo.Text = String.Empty
            '    TB_Qty.Text = String.Empty
            '    TB_Vendor.Text = String.Empty
            '    Exit Sub
            'End If
        End If

        Thread_LoadingFormStart(Me, "Saving...")

        If DBConnect() = False Then Exit Sub

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim writeDate2 As String = Format(Now, "yyyy-MM-dd")

            strSQL = "insert into tb_mms_material_warehousing("
            strSQL += "mw_no, in_no, document_no, customer_code, part_code, part_vendor, part_no, part_lot_no"
            strSQL += ", part_qty, barcode1,barcode2, barcode3, write_date, write_id, available_qty"
            strSQL += ") "
            strSQL += "select f_mms_new_mw_no(f_mms_new_in_no(date_format(now(), '%Y-%m-%d'), '" & TB_DocumentNo.Text & "'))"
            strSQL += ", f_mms_new_in_no(date_format(now(), '%Y-%m-%d'), '" & TB_DocumentNo.Text & "')"
            strSQL += ", '" & TB_DocumentNo.Text & "'"
            strSQL += ", '" & TB_CustomerCode.Text & "'"
            strSQL += ", '" & TB_CustomerPartCode.Text & "'"
            strSQL += ", '" & TB_Vendor.Text & "'"
            strSQL += ", '" & Replace(TB_PartNo.Text, "'", "\'") & "'"
            strSQL += ", '" & TB_LotNo.Text & "'"
            strSQL += ", '" & CInt(TB_Qty.Text) & "'"
            strSQL += ", '" & Replace(barcode1, "'", "\'") & "'"
            strSQL += ", '" & Replace(barcode2, "'", "\'") & "'"
            strSQL += ", '" & Replace(barcode3, "'", "\'") & "'"
            strSQL += ", '" & writeDate & "'"
            strSQL += ", '" & loginID & "'"
            strSQL += ", '" & CInt(TB_Qty.Text) & "'"
            strSQL += ";"

            strSQL += "INSERT INTO tb_mms_material_basic_inventory("
            strSQL += "clearance_date, customer_code, part_code, available_qty, over_cut, in_q"
            strSQL += ") VALUES ("
            strSQL += "f_mms_clearance_date()"
            strSQL += ", '" & TB_CustomerCode.Text & "'"
            strSQL += ", '" & TB_CustomerPartCode.Text & "'"
            strSQL += ", 0"
            strSQL += ", 0"
            strSQL += ", " & CInt(TB_Qty.Text)
            strSQL += ")"
            strSQL += " ON DUPLICATE KEY"
            strSQL += " UPDATE in_q = ifnull(in_q, 0) + " & CInt(TB_Qty.Text)
            strSQL += ";"

            '맵핑을 자동으로 등록하도록 한다.
            '중복된 값이 있으면 저장X
            strSQL += "insert into tb_mms_part_mapping("
            strSQL += "part_subcode, customer_code, part_code"
            strSQL += ", part_vendor, part_no, part_org, mapping_note, write_date, write_id"
            strSQL += ") select "
            strSQL += "'" & Format(Now, "yyMMddHHmmssfff") & "'"
            strSQL += ",'" & TB_CustomerCode.Text & "'"
            strSQL += ",'" & TB_CustomerPartCode.Text & "'"
            strSQL += ", '" & TB_Vendor.Text & "'"
            strSQL += ", '" & Replace(TB_PartNo.Text, "'", "\'") & "'"
            strSQL += ", '" & TB_BarcodeScan.Text & "'"
            strSQL += ", ''"
            strSQL += ", '" & writeDate & "'"
            strSQL += ", '" & loginID & "'"
            strSQL += " from dual where not exists"
            strSQL += " (select * from tb_mms_part_mapping"
            strSQL += " where customer_code = '" & TB_CustomerCode.Text & "'"
            strSQL += " and part_code = '" & TB_CustomerPartCode.Text & "'"
            strSQL += " and part_no = '" & Replace(TB_PartNo.Text, "'", "\'") & "')"
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

        Dim find_PartCode As Integer = Grid_MaterialList.FindRow(TB_CustomerPartCode.Text, 1, 1, True)
        'Dim find_PartNo As Integer = Grid_MaterialList.FindRow(TB_PartNo.Text, 1, 2, True)

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
            'Else
            '    Grid_MaterialList(find_PartNo, 4) = Format(CInt(Grid_MaterialList(find_PartNo, 4)) + CInt(TB_Qty.Text), "#,##0")
            '    Grid_MaterialList(find_PartNo, 5) = Format(CInt(Grid_MaterialList(find_PartNo, 4)) - CInt(Grid_MaterialList(find_PartNo, 3)), "#,##0")
            '    If Grid_MaterialList(find_PartNo, 5) > 0 Then
            '        Grid_MaterialList.Rows(find_PartNo).StyleNew.ForeColor = Color.Red
            '        Grid_MaterialList.Rows(find_PartNo).StyleNew.BackColor = Color.Yellow
            '    ElseIf Grid_MaterialList(find_PartNo, 5) = 0 Then
            '        Grid_MaterialList.Rows(find_PartNo).StyleNew.ForeColor = Color.Blue
            '        Grid_MaterialList.Rows(find_PartNo).StyleNew.BackColor = Color.White
            '    End If
        End If

        If RB_Vendor.Checked = True Then
            Material_PrintLabel(TB_CustomerPartCode.Text,
                                TB_PartNo.Text,
                                TB_LotNo.Text,
                                CInt(TB_Qty.Text),
                                TB_Vendor.Text,
                                NumericUpDown1.Value,
                                TB_CustomerName.Text,
                                Format(Now, "yyyy.MM.dd"),
                                False,
                                String.Empty,
                                0)
        End If

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
        TB_ItemCode.Text = String.Empty
        CB_Vendor.SelectedIndex = -1
        TextBox1.Text = String.Empty

        If RB_Supplier.Checked = True Then
            TB_BarcodeScan.Focus()
            TB_BarcodeScan.SelectAll()
        Else
            TB_ItemCode.Focus()
            TB_ItemCode.SelectAll()
        End If

        Grid_PartList.TopRow = Grid_PartList.Rows.Count - 1


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Label14.Visible = True Then
            Label14.Visible = False
            Timer1.Stop()
        End If

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub TB_BarcodeScan_TextChanged(sender As Object, e As EventArgs)

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
            'MSG_Error(Me, msgString)
            If MSG_Question(Me, msgString & vbCrLf & vbCrLf & "무시후 저장 하시겠습니까?") = False Then Exit Sub
            'Exit Sub
        Else
            If MSG_Question(Me, "저장 하시겠습니까?") = False Then Exit Sub
        End If

        Thread_LoadingFormStart(Me, "Saving...")

        If DBConnect() = False Then Exit Sub

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
            MSG_Error(Me, ex.Message & vbCrLf & "Error No. : " & ex.Number)
            Exit Sub
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        MSG_Information(Me, "저장완료.")

        BTN_Save.Enabled = False
        BTN_ListAdd.Enabled = False

        BTN_Search_Click(Nothing, Nothing)

    End Sub

    Private Sub TB_ItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_ItemCode.KeyDown

        If Not TB_ItemCode.Text = String.Empty And e.KeyCode = 13 Then

            Thread_LoadingFormStart(Me)

            CB_Vendor.Items.Clear()
            TextBox1.Text = String.Empty

            If DBConnect() = False Then Exit Sub

            Dim strSQL As String = "call sp_mms_material_warehousing_with_label(0"
            strSQL += ",'" & TB_ItemCode.Text & "'"
            strSQL += ")"

            Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
            Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

            Do While sqlDR.Read
                Dim vendorList() As String = sqlDR("part_vendor").ToString.Split("/")
                For i = 0 To vendorList.Count - 1
                    CB_Vendor.Items.Add(vendorList(i))
                Next
                TextBox1.Text = sqlDR("part_specification")
                'If Not vendorList.Count = 0 Then
                '    CB_Vendor.SelectedIndex = 0
                'End If
            Loop
            sqlDR.Close()

            DBClose()

            Thread_LoadingFormEnd()

            If CB_Vendor.Items.Count = 0 Then
                MSG_Information(Me, "고객사 코드를 찾을 수 없습니다..")
                TB_ItemCode.SelectAll()
                TB_ItemCode.Focus()
            ElseIf CB_Vendor.Items.Count = 1 Then
                CB_Vendor.SelectedIndex = 0
            End If

            If beforePartCode = TB_ItemCode.Text Then
                CB_Vendor.Text = beforeVendor
                TB_BarcodeScan.SelectAll()
                TB_BarcodeScan.Focus()
            Else
                beforePartCode = TB_ItemCode.Text
            End If

        End If

    End Sub

    Private Sub RB_Supplier_CheckedChanged(sender As Object, e As EventArgs) Handles RB_Supplier.CheckedChanged

        If RB_Supplier.Checked = True Then
            TB_ItemCode.Text = String.Empty
            TB_ItemCode.Enabled = False
            CB_Vendor.SelectedIndex = -1
            CB_Vendor.Enabled = False
            TB_BarcodeScan.SelectAll()
            TB_BarcodeScan.Focus()
        Else
            TB_ItemCode.Enabled = True
            CB_Vendor.Enabled = True
            TB_ItemCode.SelectAll()
            TB_ItemCode.Focus()
        End If

    End Sub

    Private Sub TB_BarcodeScan_GiveFeedback(sender As Object, e As GiveFeedbackEventArgs)

    End Sub

    Private Sub Grid_PartList_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_PartList.MouseClick

        Dim selRow As Integer = Grid_PartList.MouseRow

        If e.Button = MouseButtons.Right And selRow > 0 Then
            Grid_PartList.Row = selRow
            If BTN_ListAdd.Enabled = False Then
                BTN_RowDelete.Enabled = False
            Else
                BTN_RowDelete.Enabled = True
            End If
            Grid_Menu.Show(Grid_PartList, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub BTN_RePrint_Click(sender As Object, e As EventArgs) Handles BTN_RePrint.Click

        If MSG_Question(Me, "재발행 하시겠습니까?") = False Then Exit Sub

        Dim selRow As Integer = Grid_PartList.Row

        Material_PrintLabel(Grid_PartList(selRow, 5),
                            Grid_PartList(selRow, 8),
                            Grid_PartList(selRow, 9),
                            CInt(Grid_PartList(selRow, 10)),
                            Grid_PartList(selRow, 7),
                            1,
                            TB_CustomerName.Text,
                            Format(Now, "yyyy.MM.dd"),
                            False,
                            String.Empty,
                            0)

    End Sub

    Private Sub CB_Vendor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Vendor.SelectedIndexChanged

        Dim asciiTest As Integer = System.Text.Encoding.ASCII.GetByteCount(CB_Vendor.Text)
        Dim unicodeTest As Integer = System.Text.Encoding.UTF8.GetByteCount(CB_Vendor.Text)

        If asciiTest <> unicodeTest Then
            MSG_Exclamation(Me, "Vendor명에 한글을 입력할 수 없습니다.(Barcode)")
            CB_Vendor.SelectedIndex = -1
            Exit Sub
        End If

        TB_BarcodeScan.SelectAll()
        TB_BarcodeScan.Focus()

    End Sub

    Private Sub CB_Vendor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_Vendor.SelectionChangeCommitted

        Dim asciiTest As Integer = System.Text.Encoding.ASCII.GetByteCount(CB_Vendor.Text)
        Dim unicodeTest As Integer = System.Text.Encoding.UTF8.GetByteCount(CB_Vendor.Text)

        If asciiTest <> unicodeTest Then
            MSG_Exclamation(Me, "Vendor명에 한글을 입력할 수 없습니다.(Barcode)")
            CB_Vendor.SelectedIndex = -1
            Exit Sub
        End If

        TB_BarcodeScan.SelectAll()
        TB_BarcodeScan.Focus()

        '이건 여기에서만 자동으로 변경될때 기록되면 안됨.
        beforeVendor = CB_Vendor.Text

    End Sub

    Private Sub BTN_RowDelete_Click(sender As Object, e As EventArgs) Handles BTN_RowDelete.Click

        Dim selRow As Integer = Grid_PartList.Row
        Dim mwNo As String = Grid_PartList(selRow, 1)
        Dim nowPartCode As String = Grid_PartList(selRow, 5)
        Dim nowQty As String = Grid_PartList(selRow, 10)

        If MSG_Question(Me, "입고번호(MW No.) : " & mwNo & vbCrLf & "를 삭제 하시겠습니까?") = False Then Exit Sub

        If DBConnect() = False Then Exit Sub

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            strSQL = "delete from tb_mms_material_warehousing"
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
            Exit Sub
        End Try

        DBClose()

        Dim find_PartCode As Integer = Grid_MaterialList.FindRow(nowPartCode, 1, 1, True)

        If find_PartCode > 0 Then
            Grid_MaterialList(find_PartCode, 4) = Format(CDbl(Grid_MaterialList(find_PartCode, 4)) - CDbl(nowQty), "#,##0")
            Grid_MaterialList(find_PartCode, 5) = Format(CDbl(Grid_MaterialList(find_PartCode, 4)) - CDbl(Grid_MaterialList(find_PartCode, 3)), "#,##0")
            If Grid_MaterialList(find_PartCode, 5) > 0 Then
                Grid_MaterialList.Rows(find_PartCode).StyleNew.ForeColor = Color.Red
                Grid_MaterialList.Rows(find_PartCode).StyleNew.BackColor = Color.Yellow
            ElseIf Grid_MaterialList(find_PartCode, 5) = 0 Then
                Grid_MaterialList.Rows(find_PartCode).StyleNew.ForeColor = Color.Blue
                Grid_MaterialList.Rows(find_PartCode).StyleNew.BackColor = Color.White
            End If
        End If

        Grid_PartList.RemoveItem(selRow)

        MSG_Information(Me, "삭제완료.")

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown

        'If e.KeyCode = 13 Then
        '    Dim asciiTest As Integer = System.Text.Encoding.ASCII.GetByteCount(TextBox1.Text)
        '    Dim unicodeTest As Integer = System.Text.Encoding.UTF8.GetByteCount(TextBox1.Text)

        '    If asciiTest <> unicodeTest Then
        '        MSG_Exclamation(Me, "특수문자를 입력할 수 없습니다.")
        '        TextBox1.SelectAll()
        '        TextBox1.Focus()
        '        Exit Sub
        '    End If
        'End If

        'If e.KeyCode = 13 Then
        '    For i = 0 To TextBox1.Text.Length - 1
        '        Console.WriteLine(TextBox1.Text.Substring(i, 1) & " : " & Asc(TextBox1.Text.Substring(i, 1)))
        '    Next
        'End If

    End Sub
End Class