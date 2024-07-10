Imports System.IO
Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Wave_Selective_Production_History
    Private Sub frm_SMD_Production_History_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        Load_CustomerList()

        DateTimePicker1.Value = Now
        DateTimePicker2.Value = Now

    End Sub

    Private Sub Grid_Setting()

        With Grid_HistoryList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.Columns
            .AllowMergingFixed = AllowMergingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 17
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = False
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = True
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Cols(7).DataType = GetType(DateTime)
            .Cols(7).Format = "yyyy-MM-dd HH:mm:ss"
            .Cols(8).DataType = GetType(DateTime)
            .Cols(8).Format = "yyyy-MM-dd HH:mm:ss"
            .Cols(9).DataType = GetType(Double)
            .Cols(9).Format = "0.00"
            .Cols(11).DataType = GetType(Integer)
            .Cols(11).Format = "#,##0"
            .Cols(12).DataType = GetType(Integer)
            .Cols(12).Format = "#,##0"
            .Cols(1).Visible = False
            .Cols(14).Visible = False
            .Cols(15).Visible = False
            .Cols(16).Visible = False
        End With

        Grid_HistoryList(0, 0) = "No."
        Grid_HistoryList(0, 1) = "History Index"
        Grid_HistoryList(0, 2) = "공정명"
        Grid_HistoryList(0, 3) = "주문번호"
        Grid_HistoryList(0, 4) = "고객사"
        Grid_HistoryList(0, 5) = "품번"
        Grid_HistoryList(0, 6) = "품명"
        Grid_HistoryList(0, 7) = "시작시간"
        Grid_HistoryList(0, 8) = "종료시간"
        Grid_HistoryList(0, 9) = "소요시간(H)"
        Grid_HistoryList(0, 10) = "Inspector"
        Grid_HistoryList(0, 11) = "작업수량"
        Grid_HistoryList(0, 12) = "불량수량"
        Grid_HistoryList(0, 13) = "비고"
        Grid_HistoryList(0, 14) = "Customer Code"
        Grid_HistoryList(0, 15) = "시작수량"
        Grid_HistoryList(0, 16) = "Model Code"

        For i = 0 To Grid_HistoryList.Cols.Count - 1
            Grid_HistoryList.Cols(i).StyleNew.TextAlign = TextAlignEnum.CenterCenter
        Next

        Grid_HistoryList.AutoSizeCols()

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

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart()

        Grid_HistoryList.Redraw = False
        Grid_HistoryList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_ws_production_history(0"
        strSQL += ",'" & TB_CustomerCode.Text & "'"
        strSQL += ",'" & Format(DateTimePicker1.Value, "yyyy-MM-dd 00:00:00") & "'"
        strSQL += ",'" & Format(DateTimePicker2.Value, "yyyy-MM-dd 23:59:59") & "'"
        strSQL += ",'" & TextBox1.Text & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_HistoryList.Rows.Count
            insert_String += vbTab & sqlDR("history_index")
            insert_String += vbTab & sqlDR("process_name")
            insert_String += vbTab & sqlDR("order_index")
            insert_String += vbTab & sqlDR("customer_name")
            insert_String += vbTab & sqlDR("item_code")
            insert_String += vbTab & sqlDR("item_name")
            insert_String += vbTab & sqlDR("ws_start_date")
            insert_String += vbTab & sqlDR("ws_end_date")
            insert_String += vbTab & DateDiff(DateInterval.Minute, sqlDR("ws_start_date"), sqlDR("ws_end_date")) / 60
            insert_String += vbTab & sqlDR("ws_inspector")
            insert_String += vbTab & sqlDR("end_quantity")
            insert_String += vbTab & sqlDR("fault_quantity")
            insert_String += vbTab & sqlDR("history_note")
            insert_String += vbTab & sqlDR("customer_code")
            insert_String += vbTab & sqlDR("start_quantity")
            insert_String += vbTab & sqlDR("model_code")

            Grid_HistoryList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        UpdateTotals()

        Grid_HistoryList.AutoSizeCols()
        Grid_HistoryList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub UpdateTotals()

        'set up styles
        Dim s As CellStyle = Grid_HistoryList.Styles(CellStyleEnum.Subtotal0)
        s.BackColor = Color.LightGray
        s.ForeColor = Color.Black
        s.Font = New Font(Grid_HistoryList.Font, FontStyle.Bold)

        s = Grid_HistoryList.Styles(CellStyleEnum.Subtotal1)
        s.BackColor = Color.LightBlue
        s.ForeColor = Color.Black
        s = Grid_HistoryList.Styles(CellStyleEnum.Subtotal2)
        s.BackColor = Color.AliceBlue
        s.ForeColor = Color.Black

        Grid_HistoryList.Subtotal(AggregateEnum.Clear)
        Grid_HistoryList.Tree.Column = 2
        Grid_HistoryList.SubtotalPosition = SubtotalPositionEnum.AboveData

        'Grid_HistoryList.Subtotal(AggregateEnum.Sum, 0, -1, 13, "Grand Total")
        Grid_HistoryList.Subtotal(AggregateEnum.Sum, 1, 5, 11, "Total for ( {0} )")
        Grid_HistoryList.Subtotal(AggregateEnum.Sum, 1, 5, 12, "Total for ( {0} )")

        'Grid_HistoryList.Subtotal(AggregateEnum.Sum, 2, 7, 13, "Total for ( {0} )")
        'Grid_HistoryList.Subtotal(AggregateEnum.Sum, 2, 7, 14, "Total for ( {0} )")

    End Sub

    Private Sub Grid_HistoryList_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_HistoryList.MouseClick

        Dim selRow As Integer = Grid_HistoryList.MouseRow

        If e.Button = MouseButtons.Right And selRow > 0 Then
            Grid_HistoryList.Row = selRow
            If Not IsNothing(Grid_HistoryList(selRow, 1)) Then
                Grid_Menu.Show(Grid_HistoryList, New Point(e.X, e.Y))
            End If
        End If

    End Sub

    Private Sub BTN_Reprint_Click(sender As Object, e As EventArgs) Handles BTN_Reprint.Click

        If MessageBox.Show(Me, "현품표를 재발행 하시겠습니까?", msg_form, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Dim selRow As Integer = Grid_HistoryList.Row

        Dim nowWriteDate As String = Grid_HistoryList(selRow, 8)
        Dim nowHistoryNo As String = Grid_HistoryList(selRow, 1)
        Dim nowProductionQty As String = Grid_HistoryList(selRow, 11)
        Dim nowTotalQty As String = CDbl(Grid_HistoryList(selRow, 11)) + CDbl(Grid_HistoryList(selRow, 15))
        Dim nowItemCode As String = Grid_HistoryList(selRow, 5)
        Dim nowItemName As String = Grid_HistoryList(selRow, 6)
        Dim nowOrderIndex As String = Grid_HistoryList(selRow, 3)
        Dim nowCustomerCode As String = Grid_HistoryList(selRow, 14)
        Dim nowModelCode As String = Grid_HistoryList(selRow, 16)
        Dim nowProcessName As String = Grid_HistoryList(selRow, 2)

        PrintLabel(nowWriteDate,
                   nowHistoryNo,
                   nowProductionQty,
                   nowTotalQty,
                   nowItemCode,
                   nowItemName,
                   nowOrderIndex,
                   nowCustomerCode,
                   nowModelCode,
                   nowProcessName)

    End Sub

    Private Sub PrintLabel(ByVal writeDate As String,
                           ByVal historyNo As String,
                           ByVal productionQty As String,
                           ByVal totalQty As String,
                           ByVal itemCode As String,
                           ByVal itemName As String,
                           ByVal orderIndex As String,
                           ByVal customerCode As String,
                           ByVal modelCode As String,
                           ByVal processName As String
                           )

        'If File.Exists(Application.StartupPath & "\print.txt") Then File.Delete(Application.StartupPath & "\print.txt")

        If Directory.Exists(Application.StartupPath & "\Print Text") = False Then
            Directory.CreateDirectory(Application.StartupPath & "\Print Text")
        End If

        Dim folderName As String = Application.StartupPath & "\Print Text"
        Dim fileName As String = folderName & "\WS Label Print_" & Format(Now, "yyMMddHHmmssfff") & ".txt"

        Dim swFile As StreamWriter =
            New StreamWriter(fileName, True, System.Text.Encoding.GetEncoding(949))

        swFile.WriteLine("^XZ~JA^XZ")
        swFile.WriteLine("^XA^LH" & printerLeftPosition & ",0^LT" & printerTopPosition) 'LH : 가로위치, LT : 세로위치
        swFile.WriteLine("^MD" & printerMD) '진하기
        swFile.WriteLine("^SEE:UHANGUL.DAT^FS")
        swFile.WriteLine("^CW1,E:KFONT3.FNT^CI26^FS")

        swFile.WriteLine("^FO0008,0162^GB0694,0302,2,B,1^FS")

        swFile.WriteLine("^FO0008,0200^GB0694,0000,2,B,0^FS")
        swFile.WriteLine("^FO0008,0238^GB0694,0000,2,B,0^FS")
        swFile.WriteLine("^FO0008,0276^GB0694,0000,2,B,0^FS")
        swFile.WriteLine("^FO0008,0314^GB0694,0000,2,B,0^FS")

        swFile.WriteLine("^FO0162,0162^GB0000,0302,2,B,0^FS")
        swFile.WriteLine("^FO0352,0200^GB0000,0116,2,B,0^FS")
        swFile.WriteLine("^FO0510,0200^GB0000,0116,2,B,0^FS")

        swFile.WriteLine("^FO0170,0008^A1N,60,40^FD" & processName & " 현품표^FS")
        swFile.WriteLine("^FO0172,0080^A0,40,20^FDItemCode : ^FS")
        swFile.WriteLine("^FO0264,0080^A0,40,20^FD" & itemCode & "^FS")
        swFile.WriteLine("^FO0172,0120^A0,40,20^FDItemName : ^FS")
        swFile.WriteLine("^FO0272,0120^A0,40,20^FD" & itemName & "^FS")

        swFile.WriteLine("^FO0016,0170^A0,30,20^FDPO No.^FS")
        swFile.WriteLine("^FO0170,0170^A0,30,20^FD" & orderIndex & " ( " & historyNo & " )^FS")

        swFile.WriteLine("^FO0016,0208^A0,30,20^FDTotal Q'ty^FS")
        swFile.WriteLine("^FO0170,0208^A0,30,20^FD" & totalQty & " EA^FS")
        swFile.WriteLine("^FO0360,0208^A0,30,20^FDMagazine Q'ty^FS")
        swFile.WriteLine("^FO0518,0208^A0,30,20^FD" & productionQty & " EA^FS")

        swFile.WriteLine("^FO0016,0246^A0,30,20^FDLine^FS")
        swFile.WriteLine("^FO0170,0246^A0,30,20^FD" & processName & "^FS")
        'swFile.WriteLine("^FO0360,0246^A0,30,20^FDTop / Bottom^FS")
        'swFile.WriteLine("^FO0518,0246^A0,30,20^FD" & TB_TB.Text & "^FS")
        swFile.WriteLine("^FO0016,0284^A0,30,20^FDDate^FS")
        swFile.WriteLine("^FO0170,0284^A0,30,18^FD" & writeDate & "^FS")
        swFile.WriteLine("^FO0016,0324^A0,30,20^FDProcess^FS")
        swFile.WriteLine("^FO0170,0324^A1N,30,20^FD" & Load_Process(modelCode) & "^FS")

        swFile.WriteLine("^FO020,0020^BXN,3,200,44,44^FD" & orderIndex & "!" & historyNo & "!" & processName & "^FS")

        swFile.WriteLine("^PQ" & 1 & "^FS") 'PQ : 발행수량
        swFile.WriteLine("^XZ")
        swFile.Close()

        Dim printResult As String = LabelPrint(fileName)

        If Not printResult = "Success" Then
            MessageBox.Show(frm_Main,
                            "라벨 발행에 실패 하였습니다." & vbCrLf &
                            printResult,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End If

    End Sub

    Private Function Load_Process(ByVal modelCode As String) As String

        DBConnect()

        Dim returnString As String = String.Empty

        Dim strSQL As String = "call sp_mms_smd_production_end(5"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & modelCode & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            If returnString = String.Empty Then
                returnString = sqlDR("process_name")
            Else
                returnString += ">" & sqlDR("process_name")
            End If
        Loop
        sqlDR.Close()

        DBClose()

        Return returnString

    End Function

    Private Sub BTN_FaultHistory_Click(sender As Object, e As EventArgs) Handles BTN_FaultHistory.Click

        Dim selRow As Integer = Grid_HistoryList.Row

        Dim nowHistoryNo As String = Grid_HistoryList(selRow, 1)

        frm_WS_Fault_History.nowHistoryNo = nowHistoryNo

        If Not frm_WS_Fault_History.Visible Then frm_WS_Fault_History.Show()
        frm_WS_Fault_History.Focus()

    End Sub
End Class