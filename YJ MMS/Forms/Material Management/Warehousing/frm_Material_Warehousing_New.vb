Imports System.IO
Imports C1.Win.C1FlexGrid
Imports MySqlConnector

Public Class frm_Material_Warehousing_New
    Private Sub frm_Material_Warehousing_With_Label_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        DTP_Start.Value = Format(Now, "yyyy-MM-01 00:00:00")
        DTP_End.Value = Format(Now, "yyyy-MM-dd 23:59:59")

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

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
                Panel2.Enabled = False
            Else
                Panel2.Enabled = True
            End If

            Thread_LoadingFormEnd()
        End If

    End Sub

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

    Private Sub TB_BarcodeScan_MouseClick(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub TB_BarcodeScan_TextChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub TB_BarcodeScan_GotFocus(sender As Object, e As EventArgs)

    End Sub

    Private Sub TB_BarcodeScan_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub TB_BarcodeScan_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub

    Private Sub BTN_ListAdd_Click(sender As Object, e As EventArgs)

    End Sub
End Class