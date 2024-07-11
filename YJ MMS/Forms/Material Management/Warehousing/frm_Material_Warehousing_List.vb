'############################################################################################################
'############################################################################################################

'##### 작성일자 : 2024-03-05
'##### 수정일자 : 2024-03-05
'##### 수정자   : 박시현
'##### 참고     : 
'##### 설명     : 고객사별 자재입고리스트를 등록 한다.

'############################################################################################################

Imports System.IO
Imports System.Threading
Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Material_Warehousing_List

    Dim barcode1 As String
    Dim barcode2 As String
    Dim barcode3 As String
    Dim usePartCode As String = String.Empty

    Private Sub frm_Material_Warehousing_List_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()
        Lock_Control()
        Load_CustomerList()

        Label12.Visible = False
        Timer1.Interval = 3000
        Timer1.Stop()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub Grid_Setting()

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

    Private Sub Load_CustomerList()

        CB_CustomerName.Items.Clear()
        CB_CustomerName.Items.Add(String.Empty)

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
            usePartCode = sqlDR("use_part_code")
        Loop
        sqlDR.Close()

        DBClose()

        If Not usePartCode = "사용" Then
            RB_VendorCode.Checked = True
        Else
            Load_VendorList()
            RB_CustomerCode.Checked = True
        End If

    End Sub

    Private Sub Load_VendorList()

        CB_Vendor.Items.Clear()

        DBConnect()

        Dim strSQL As String = "select part_vendor"
        strSQL += " from tb_mms_customer_part_code"
        strSQL += " where customer_code = '" & TB_CustomerCode.Text & "'"
        strSQL += " group by part_vendor"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            If InStr(sqlDR("part_vendor"), ",") > 0 Or
                InStr(sqlDR("part_vendor"), "|") > 0 Or
                InStr(sqlDR("part_vendor"), "/") > 0 Then
                Dim separators() As String = {",", "|", "/"}
                Dim splitVendor() As String = sqlDR("part_vendor").ToString.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                For i = 0 To UBound(splitVendor)
                    CB_Vendor.Items.Add(splitVendor(i))
                Next
            Else
                CB_Vendor.Items.Add(sqlDR("part_vendor"))
            End If
        Loop
        sqlDR.Close()

        DBClose()

        Combo_Duplicate_Remove(CB_Vendor)

    End Sub

    Private Sub Combo_Duplicate_Remove(ByVal cbb As ComboBox)

        Dim list As List(Of String) = New List(Of String)
        Dim o As String
        For Each o In cbb.Items
            If Not list.Contains(o) Then
                list.Add(o)
            End If
        Next
        cbb.Items.Clear()
        cbb.Items.AddRange(list.ToArray())
        cbb.Sorted = True

    End Sub

    Private Sub TB_BarcodeScan_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_BarcodeScan.KeyDown

        If e.KeyCode = 13 Then

            Thread_LoadingFormStart(Me)

            Dim splitResult As String = Load_PHP(phpUrl & phpRootFolder &
                                                 "/barcodesplit.php?barcode=" &
                                                 sender.Text &
                                                 "&maker=" &
                                                 CB_Vendor.Text.ToUpper,
                                                 "BarcodeSplitResult",
                                                 "returnStr")

            If splitResult.Split("!@")(0) = "Success" Then
                Dim resultSplit() As String = splitResult.Split("!@")
                If UBound(resultSplit) = 4 Then
                    Dim partNo As String = resultSplit(1).Replace("@P:", String.Empty)
                    Dim lotNo As String = resultSplit(2).Replace("@L:", String.Empty)
                    Dim qty As String = resultSplit(3).Replace("@Q:", String.Empty)
                    Dim org As String = resultSplit(4).Replace("@ORG:", String.Empty)

                    'Console.WriteLine(partNo)
                    'Console.WriteLine(lotNo)
                    'Console.WriteLine(qty)
                    'Console.WriteLine(org)

                    If org = String.Empty Then
                        If TB_PartNo.Text = String.Empty Then TB_PartNo.Text = partNo
                        If TB_LotNo.Text = String.Empty Then TB_LotNo.Text = lotNo
                        If TB_Qty.Text = String.Empty Then TB_Qty.Text = qty
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
                    MessageBox.Show(Me,
                                    resultSplit(1).Replace("@", String.Empty),
                                    msg_form,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                End If
            Else
                Thread_LoadingFormEnd()
                MessageBox.Show(Me,
                                splitResult.Split("!@")(1).Replace("@", String.Empty),
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                TB_BarcodeScan.Focus()
                TB_BarcodeScan.SelectAll()
                Exit Sub

            End If
            TB_BarcodeScan.Focus()
            TB_BarcodeScan.SelectAll()

            If RB_CustomerCode.Checked Then Load_CustomerPartCode()

            If barcode1 = String.Empty Then
                barcode1 = TB_BarcodeScan.Text
            ElseIf barcode2 = String.Empty Then
                barcode2 = TB_BarcodeScan.Text
            ElseIf barcode3 = String.Empty Then
                barcode3 = TB_BarcodeScan.Text
            End If

            Thread_LoadingFormEnd()
        End If

    End Sub

    Private Sub Load_CustomerPartCode()

        TB_CustomerPartCode.Text = String.Empty

        DBConnect()

        Dim strSQL As String = "select part_code"
        strSQL += " from tb_mms_part_mapping"
        strSQL += " where customer_code = '" & TB_CustomerCode.Text & "'"
        strSQL += " and part_no = '" & TB_PartNo.Text & "'"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_CustomerPartCode.Text = sqlDR("part_code")
        Loop
        sqlDR.Close()

        DBClose()

        If usePartCode = "사용" And
            TB_CustomerPartCode.Text = String.Empty Then
            MessageBox.Show("고객사 자재코드를 사용하지만" & vbCrLf & "현재 자재의 고객사 자재코드를 찾을 수 없습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly)
            barcode1 = String.Empty
            barcode2 = String.Empty
            barcode3 = String.Empty
            TB_PartNo.Text = String.Empty
            TB_LotNo.Text = String.Empty
            TB_Qty.Text = String.Empty
            TB_BarcodeScan.Focus()
            TB_BarcodeScan.SelectAll()
            Exit Sub
        End If

    End Sub

    Private Sub TB_BarcodeScan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TB_BarcodeScan.KeyPress

        '숫자만 입력
        'If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
        '    e.Handled = True
        'End If

    End Sub

    Private Sub TB_BarcodeScan_GotFocus(sender As Object, e As EventArgs) Handles TB_BarcodeScan.GotFocus

        TB_BarcodeScan.SelectAll()

    End Sub

    Private Sub TB_BarcodeScan_MouseClick(sender As Object, e As MouseEventArgs) Handles TB_BarcodeScan.MouseClick

        TB_BarcodeScan.SelectAll()

    End Sub

    Private Sub BTN_ListAdd_Click(sender As Object, e As EventArgs) Handles BTN_ListAdd.Click

        If (TB_PartNo.Text = String.Empty) Or
            (TB_Qty.Text = String.Empty) Then
            MessageBox.Show(Me,
                            "Scan 결과 Part No.와 수량을 필수 입력되어야 합니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            TB_BarcodeScan.Focus()
            TB_BarcodeScan.SelectAll()
            Label12.Text = "등록실패"
            Label12.ForeColor = Color.Red
            Exit Sub
        End If

        If usePartCode = "사용" And
            TB_CustomerPartCode.Text = String.Empty Then
            MessageBox.Show(Me,
                            "고객사 자재코드를 사용하지만" & vbCrLf & "현재 자재의 고객사 자재코드를 찾을 수 없습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            TB_BarcodeScan.Focus()
            TB_BarcodeScan.SelectAll()
            Label12.Text = "등록실패"
            Label12.ForeColor = Color.Red
            Exit Sub
        End If

        Thread_LoadingFormStart(Me, "Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim writeDate2 As String = Format(Now, "yyyy-MM-dd")

            strSQL = "insert into tb_mms_material_warehousing("
            strSQL += "mw_no, in_no, customer_code, part_code, part_vendor, part_no, part_lot_no"
            strSQL += ", part_qty, barcode1,barcode2, barcode3, write_date, write_id"
            strSQL += ") values("
            strSQL += "f_mms_new_mw_no('" & TB_HSNo.Text & "')"
            strSQL += ", '" & TB_HSNo.Text & "'"
            strSQL += ", '" & TB_CustomerCode.Text & "'"
            strSQL += ", '" & TB_CustomerPartCode.Text & "'"
            strSQL += ", '" & CB_Vendor.Text & "'"
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
            Label12.Visible = True
            Label12.Text = "등록실패"
            Label12.ForeColor = Color.Red
            TB_BarcodeScan.Focus()
            TB_BarcodeScan.SelectAll()
            Exit Sub
        Finally
            Timer1.Start()
            Label12.Visible = True
            Label12.Text = "등록성공"
            Label12.ForeColor = Color.Yellow
        End Try

        DBClose()

        If RB_PrintUse.Checked Then PrintLabel()

        Thread_LoadingFormEnd()

        BTN_Search_Click(Nothing, Nothing)

        TB_BarcodeScan.Focus()
        TB_BarcodeScan.SelectAll()
        TB_PartNo.Text = String.Empty
        TB_LotNo.Text = String.Empty
        TB_Qty.Text = String.Empty
        TB_CustomerPartCode.Text = String.Empty
        barcode1 = String.Empty
        barcode2 = String.Empty
        barcode3 = String.Empty

    End Sub

    Private Sub PrintLabel()

        'If File.Exists(Application.StartupPath & "\print.txt") Then File.Delete(Application.StartupPath & "\print.txt")

        If Directory.Exists(Application.StartupPath & "\Print Text") = False Then
            Directory.CreateDirectory(Application.StartupPath & "\Print Text")
        End If

        Dim folderName As String = Application.StartupPath & "\Print Text"
        Dim fileName As String = folderName & "\Material Label Print_" & Format(Now, "yyMMddHHmmssfff") & ".txt"

        Dim swFile As StreamWriter =
            New StreamWriter(fileName, True, System.Text.Encoding.GetEncoding(949))

        swFile.WriteLine("^XZ~JA^XZ")
        swFile.WriteLine("^XA^LH" & printerLeftPosition & ",0^LT" & printerTopPosition) 'LH : 가로위치, LT : 세로위치
        swFile.WriteLine("^MD" & printerMD) '진하기
        'swFile.WriteLine("^XA")
        'swFile.WriteLine("^BY2,2.0^FS")
        swFile.WriteLine("^SEE:UHANGUL.DAT^FS")
        swFile.WriteLine("^CW1,E:KFONT3.FNT^CI26^FS")
        swFile.WriteLine("^FO180,0000^A0,60,40^FDPart Code : " & TB_CustomerPartCode.Text & "^FS")
        swFile.WriteLine("^FO180,0060^A0,40,30^FDVendor Code : " & TB_PartNo.Text & "^FS")
        swFile.WriteLine("^FO180,0095^A0,40,30^FDLot No : " & TB_LotNo.Text & "^FS")
        swFile.WriteLine("^FO180,0130^A0,40,30^FDQty : " & Format(CInt(TB_Qty.Text), "#,##0") & "^FS")
        'swFile.WriteLine("^FO550,0140^A1N,30,20^FD" & CB_CustomerName.Text & "^FS")
        swFile.WriteLine("^FO550,0140^A1N,30,20^FD" & CB_CustomerName.Text & "^FS")
        Dim barcodeString As String = TB_CustomerPartCode.Text & "!" & TB_PartNo.Text & "!" & TB_LotNo.Text & "!" & TB_Qty.Text & "!" & TB_CustomerCode.Text & "!" & CB_Vendor.Text
        swFile.WriteLine("^FO020,0020^BXN,3,200,44,44^FD" & barcodeString & "^FS")
        swFile.WriteLine("^PQ1^FS") 'PQ : 발행수량
        swFile.WriteLine("^XZ")
        swFile.Close()

        Dim printResult As String = LabelPrint(fileName)

        If Not printResult = "Success" Then
            MessageBox.Show("라벨 발행에 실패 하였습니다. 재 발행하여 주십시오." & vbCrLf &
                            "재입고 금지 - 재발행 할것" &
                            printResult,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1)
        End If

    End Sub

    Private Sub Lock_Control()

        TB_HSNo.Enabled = False
        TB_HSNo.Text = String.Empty
        CB_CustomerName.Enabled = False
        CB_CustomerName.SelectedIndex = -1
        TB_CustomerCode.Enabled = False
        TB_CustomerCode.Text = String.Empty
        Panel1.Enabled = False
        Panel2.Enabled = False
        CB_Vendor.Enabled = False
        CB_Vendor.SelectedIndex = -1
        TB_BarcodeScan.Enabled = False
        TB_BarcodeScan.Text = String.Empty
        TB_PartNo.Enabled = False
        TB_PartNo.Text = String.Empty
        TB_LotNo.Enabled = False
        TB_LotNo.Text = String.Empty
        TB_Qty.Enabled = False
        TB_Qty.Text = String.Empty
        BTN_ListAdd.Enabled = False

    End Sub

    Private Sub Initiallize_Control()

        TB_HSNo.Text = String.Empty
        CB_CustomerName.SelectedIndex = -1
        TB_CustomerCode.Text = String.Empty
        CB_Vendor.SelectedIndex = -1
        TB_BarcodeScan.Text = String.Empty
        TB_PartNo.Text = String.Empty
        TB_LotNo.Text = String.Empty
        TB_Qty.Text = String.Empty
        Label12.Visible = False

    End Sub

    Private Sub Release_Control()

        'TB_HSNo.Enabled = True
        CB_CustomerName.Enabled = True
        'TB_CustomerCode.Enabled = True
        Panel1.Enabled = True
        Panel2.Enabled = True
        CB_Vendor.Enabled = True
        TB_BarcodeScan.Enabled = True
        TB_PartNo.Enabled = True
        TB_LotNo.Enabled = True
        TB_Qty.Enabled = True
        BTN_ListAdd.Enabled = True

    End Sub

    Private Sub BTN_NewList_Click(sender As Object, e As EventArgs) Handles BTN_NewList.Click

        If Not TB_HSNo.Text = String.Empty Then
            If MessageBox.Show("입고 No.가 변경이 됩니다." & vbCrLf & "신규등록 하시겠습니까?",
                   msg_form,
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        End If

        Thread_LoadingFormStart(Me)

        Release_Control()
        Initiallize_Control()

        DBConnect()

        Dim strSQL As String = "select f_mms_new_in_no("
        strSQL += "'" & Format(Now, "yyyy-MM-dd") & "'"
        strSQL += ", null) as new_in_no"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_HSNo.Text = sqlDR("new_in_no")
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Label12.Visible = True Then
            Label12.Visible = False
            Timer1.Stop()
        End If

    End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart(Me)

        Grid_PartList.Redraw = False
        Grid_PartList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_warehousing_list(0"
        strSQL += ",'" & Format(Now, "yyyy-MM-dd") & "'"
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
        Loop
        sqlDR.Close()

        DBClose()

        Grid_PartList.AutoSizeCols()
        Grid_PartList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub CB_CustomerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_CustomerName.SelectedIndexChanged

    End Sub

    Private Sub TB_BarcodeScan_TextChanged(sender As Object, e As EventArgs) Handles TB_BarcodeScan.TextChanged

    End Sub
End Class