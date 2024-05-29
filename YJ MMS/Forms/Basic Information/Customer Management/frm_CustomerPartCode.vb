'############################################################################################################
'############################################################################################################

'##### 작성일자 : 2024-02-22
'##### 수정일자 : 2024-02-22
'##### 수정자   : 박시현
'##### 참고     : 
'##### 설명     : 고객사별 자재코드를 등록 한다.

'############################################################################################################

Imports System.Threading
Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_CustomerPartCode

    Dim runProcess As Thread

    Private Sub frm_CustomerPartCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        Load_CustomerList()

    End Sub

    Private Sub Grid_Setting()

        With Grid_PartList
            .AllowEditing = True
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 11
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            Grid_PartList(0, 0) = "No"
            Grid_PartList(0, 1) = "MainCode"
            Grid_PartList(0, 2) = "타입"
            Grid_PartList(0, 3) = "자재코드"
            Grid_PartList(0, 4) = "사양"
            Grid_PartList(0, 5) = "Vendor"
            Grid_PartList(0, 6) = "사/도급"
            Grid_PartList(0, 7) = "단가(\)"
            Grid_PartList(0, 8) = "공급사"
            Grid_PartList(0, 9) = "연결된 자재"
            Grid_PartList(0, 10) = "비고"
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            .ExtendLastCol = True
            .Cols(6).ComboList = "유상|무상|도급"
            .Cols(1).Visible = True
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
        End With

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

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

        Dim usePartCode As String = String.Empty

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
            MessageBox.Show(Me,
                            "선택된 고객사는 고객사 코드를 사용하지 않습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            CB_CustomerName.Text = String.Empty
            TB_CustomerCode.Text = String.Empty
        End If

    End Sub

    Private Sub BTN_NewMultiPartsCode_Click(sender As Object, e As EventArgs) Handles BTN_NewMultiPartsCode.Click

        If TB_CustomerCode.Text = String.Empty Then
            MessageBox.Show(Me,
                            "고객사를 먼저 선택 하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Exit Sub
        End If

        If frm_Popup_MultiPartsCode.ShowDialog() = DialogResult.OK Then
            runProcess = New Thread(AddressOf Load_List)
            runProcess.IsBackground = True
            runProcess.SetApartmentState(ApartmentState.STA)
            runProcess.Start()
        End If

    End Sub

    Private Sub Load_List()

        thread_LoadingFormStart("Excel Load...")

        Invoke(d_GridRedraw, False)

        Dim excelApp As Object

        excelApp = CreateObject("Excel.Application")
        excelApp.WorkBooks.Open(Invoke(d_TB_FileName))

        excelApp.Visible = False

        Try
            Dim sheetName As String = Invoke(d_CB_SheetNameText)
            Dim startRow As Integer = registryEdit.ReadRegKey("Software\Yujin\MMS\Customer Part Code", "Start Row", 3)
            Dim partCode As Integer = registryEdit.ReadRegKey("Software\Yujin\MMS\Customer Part Code", "Part Code", 4)
            Dim partSpecification As Integer = registryEdit.ReadRegKey("Software\Yujin\MMS\Customer Part Code", "Part Specification", 5)
            Dim partVendor As Integer = registryEdit.ReadRegKey("Software\Yujin\MMS\Customer Part Code", "Part Vendor", 6)
            Dim partCategory As Integer = registryEdit.ReadRegKey("Software\Yujin\MMS\Customer Part Code", "Part Category", 7)
            Dim partType As Integer = registryEdit.ReadRegKey("Software\Yujin\MMS\Customer Part Code", "Part Type", 8)
            Dim partSupplier As Integer = registryEdit.ReadRegKey("Software\Yujin\MMS\Customer Part Code", "Part Supplier", 8)

            With excelApp.ActiveWorkbook.Sheets(sheetName)
                For i = startRow To .UsedRange.Rows.Count
                    Invoke(d_Sub_RowAdd, Format(Now, "yyMMddHHmmssfff") & vbTab &
                                         .Cells(i, partType).Value & vbTab &
                                         .Cells(i, partCode).Value & vbTab &
                                         .Cells(i, partSpecification).Value & vbTab &
                                         .Cells(i, partVendor).Value & vbTab &
                                         .Cells(i, partCategory).Value & vbTab &
                                         .Cells(i, partSupplier))
                    Invoke(d_SetPGStatus,
                           "데이터를 불러오고 있습니다.     " &
                           Format(i - startRow + 1, "#,##0") & " / " &
                           Format(.UsedRange.Rows.Count - startRow + 1, "#,##0") & " 행")
                Next
            End With
        Catch ex As Exception
            MessageBox.Show(New Form With {.TopMost = True},
                            ex.Message,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        Finally
            excelApp.WorkBooks(1).Close()
            excelApp.Quit()
            excelApp = Nothing
        End Try

        Invoke(d_GriAutoSize, "Col")
        'Invoke(d_GriAutoSize, "Row")

        Invoke(d_GridRedraw, True)

        thread_LoadingFormEnd()

        Invoke(d_FormClose)

        Invoke(d_SetPGStatus,
               String.Empty)

        runProcess.Abort()

    End Sub

#Region "Delegate"
    Private Delegate Sub Sub_SetPGStatus(ByVal statusText As String)
    Private d_SetPGStatus = New Sub_SetPGStatus(AddressOf PG_Status)

    Private Sub PG_Status(ByVal statusText As String)

        frm_Main.lb_Status.Text = statusText

    End Sub

    Private Delegate Sub Sub_RowAdd(ByVal addString As String)
    Private d_Sub_RowAdd = New Sub_RowAdd(AddressOf RowAdd)

    Private Sub RowAdd(ByVal addString As String)

        Grid_PartList.AddItem("N" & vbTab & addString)
        Grid_PartList.Rows(Grid_PartList.Rows.Count - 1).StyleNew.ForeColor = Color.Blue

    End Sub

    Private Delegate Sub Sub_FormClose()
    Private d_FormClose = New Sub_FormClose(AddressOf formClose)

    Private Sub formClose()

        frm_Popup_MultiPartsCode.Dispose()

    End Sub

    Private Delegate Function Sub_TB_FileName()
    Private d_TB_FileName = New Sub_TB_FileName(AddressOf TB_FileName)

    Private Function TB_FileName()

        Return frm_Popup_MultiPartsCode.TB_File_Path.Text

    End Function

    Private Delegate Function Sub_CB_SheetNameText()
    Private d_CB_SheetNameText = New Sub_CB_SheetNameText(AddressOf CB_SheetNameText)

    Private Function CB_SheetNameText()

        Return frm_Popup_MultiPartsCode.CB_SheetName.Text

    End Function

    Private Delegate Sub Sub_GriAutoSize(ByVal rowcol As String)
    Private d_GriAutoSize = New Sub_GriAutoSize(AddressOf Grid_AutoSizeColRow)

    Private Sub Grid_AutoSizeColRow(ByVal rowcol As String)

        If rowcol.Equals("Row") Then
            Grid_PartList.AutoSizeRows()
        ElseIf rowcol.Equals("Col") Then
            Grid_PartList.AutoSizeCols()
        End If

    End Sub

    Private Delegate Sub Sub_GridRedraw(ByVal status As Boolean)
    Private d_GridRedraw = New Sub_GridRedraw(AddressOf GridRedraw)

    Private Sub GridRedraw(ByVal status As Boolean)

        Grid_PartList.Redraw = status

    End Sub

    Private Delegate Sub Sub_FormFocus()
    Private d_FormFocus = New Sub_FormFocus(AddressOf Focus)
#End Region

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        If TB_CustomerCode.Text = String.Empty Then
            MessageBox.Show("고객사를 먼저 선택 하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        Thread_LoadingFormStart()

        Grid_PartList.Redraw = False
        Grid_PartList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_customer_part_code(0"
        strSQL += ",'" & TB_CustomerCode.Text & "'"
        strSQL += ",'" & TB_CustomerPartCode.Text & "'"
        strSQL += ",'" & TB_Specification.Text & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_PartList.Rows.Count & vbTab &
                                          sqlDR("part_maincode") & vbTab &
                                          sqlDR("part_type") & vbTab &
                                          sqlDR("part_code") & vbTab &
                                          sqlDR("part_specification") & vbTab &
                                          sqlDR("part_vendor") & vbTab &
                                          sqlDR("part_category") & vbTab &
                                          Format(sqlDR("unit_price"), "#,##0.000") & vbTab &
                                          sqlDR("supplier") & vbTab &
                                          sqlDR("registered_qty") & vbTab &
                                          sqlDR("part_code_note")
            Grid_PartList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_PartList.AutoSizeCols()
        Grid_PartList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click,
        btn_Save2.Click

        If MsgBox("저장 하시겠습니까?",
                  MsgBoxStyle.Question + MsgBoxStyle.YesNo,
                  msg_form) = MsgBoxResult.No Then Exit Sub

        thread_LoadingFormStart("Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            For i = 1 To Grid_PartList.Rows.Count - 1
                If Grid_PartList(i, 0).ToString = "N" Then
                    strSQL += "insert into tb_mms_customer_part_code("
                    strSQL += "part_maincode, part_code, customer_code, part_type, part_specification"
                    strSQL += ", part_vendor, part_category, unit_price, supplier, part_code_note, write_date, write_id"
                    strSQL += ") values("
                    strSQL += "'" & Grid_PartList(i, 1) & "'"
                    strSQL += ", '" & Replace(Grid_PartList(i, 3), "'", "\'") & "'"
                    strSQL += ", '" & TB_CustomerCode.Text & "'"
                    strSQL += ", '" & Replace(Grid_PartList(i, 2), "'", "\'") & "'"
                    strSQL += ", '" & Replace(Grid_PartList(i, 4), "'", "\'") & "'"
                    strSQL += ", '" & Replace(Grid_PartList(i, 5), "'", "\'") & "'"
                    strSQL += ", '" & Replace(Grid_PartList(i, 6), "'", "\'") & "'"
                    strSQL += ", '" & Replace(Grid_PartList(i, 7), "'", "\'") & "'"
                    strSQL += ", '" & Replace(Grid_PartList(i, 8), "'", "\'") & "'"
                    strSQL += ", '" & Replace(Grid_PartList(i, 10), "'", "\'") & "'"
                    strSQL += ", '" & writeDate & "'"
                    strSQL += ", '" & loginID & "');"
                ElseIf Grid_PartList(i, 0).ToString = "M" Then
                    strSQL += "update tb_mms_customer_part_code set"
                    strSQL += " part_code = '" & Replace(Grid_PartList(i, 3), "'", "\'") & "'"
                    strSQL += ", part_type = '" & Replace(Grid_PartList(i, 2), "'", "\'") & "'"
                    strSQL += ", part_specification = '" & Replace(Grid_PartList(i, 4), "'", "\'") & "'"
                    strSQL += ", part_vendor = '" & Replace(Grid_PartList(i, 5), "'", "\'") & "'"
                    strSQL += ", part_category = '" & Replace(Grid_PartList(i, 6), "'", "\'") & "'"
                    strSQL += ", unit_price = '" & Replace(Grid_PartList(i, 7), "'", "\'") & "'"
                    strSQL += ", supplier = '" & Replace(Grid_PartList(i, 8), "'", "\'") & "'"
                    strSQL += ", part_code_note = '" & Replace(Grid_PartList(i, 10), "'", "\'") & "'"
                    strSQL += ", write_date = '" & writeDate & "'"
                    strSQL += ", write_id = '" & loginID & "'"
                    strSQL += " where part_maincode = '" & Grid_PartList(i, 1) & "';"
                ElseIf Grid_PartList(i, 0).ToString = "D" Then
                    strSQL += "delete from tb_mms_customer_part_code"
                    strSQL += " where part_maincode = '" & Grid_PartList(i, 1) & "';"
                End If
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
            thread_LoadingFormEnd()
            MessageBox.Show(Me,
                            ex.Message & vbCrLf & "Error No. : " & ex.Number,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Exit Sub
        End Try

        DBClose()

        thread_LoadingFormEnd()
        MessageBox.Show(Me,
                        "저장 완료.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)



        BTN_Search_Click(Nothing, Nothing)

    End Sub

    Private Sub Grid_PartList_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_PartList.MouseClick

        If Grid_PartList.MouseRow > -1 And
            e.Button = MouseButtons.Right Then
            Grid_PartList.Row = Grid_PartList.MouseRow
            cms_Menu.Show(Grid_PartList, New Point(e.X, e.Y))
        End If

    End Sub

    Dim before_Data As String

    Private Sub Grid_PartList_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Grid_PartList.BeforeEdit

        before_Data = Grid_PartList(e.Row, e.Col)

    End Sub

    Private Sub Grid_PartList_AfterEdit(sender As Object, e As RowColEventArgs) Handles Grid_PartList.AfterEdit

        If Grid_PartList(e.Row, 0).Equals("D") Then Exit Sub

        If before_Data = Grid_PartList(e.Row, e.Col) Then Exit Sub

        Grid_PartList.Redraw = False

        If IsNumeric(Grid_PartList(e.Row, 0)) Then
            Grid_PartList(e.Row, 0) = "M"
        End If

        Dim cs As CellStyle = Grid_PartList.Styles.Add("red")
        cs.BackColor = Color.Yellow
        cs.ForeColor = Color.Red

        Grid_PartList.SetCellStyle(e.Row, e.Col, cs)

        Grid_PartList.AutoSizeCols()

        Grid_PartList.Redraw = True

    End Sub

    Private Sub btn_RowDelete_Click(sender As Object, e As EventArgs) Handles btn_RowDelete.Click

        Dim sel_Row As Integer = Grid_PartList.Row

        If Grid_PartList(sel_Row, 0).ToString = "N" Then
            Grid_PartList.RemoveItem(sel_Row)
        Else
            Grid_PartList(sel_Row, 0) = "D"
            Grid_PartList.Rows(sel_Row).StyleNew.ForeColor = Color.LightGray
        End If

    End Sub

    Private Sub BTN_NewPartsCode2_Click(sender As Object, e As EventArgs) Handles BTN_NewPartsCode2.Click

        Grid_PartList.Redraw = False

        Grid_PartList.AddItem("N" & vbTab & Format(Now, "yyMMddHHmmssfff"), Grid_PartList.Row + 1)
        Grid_PartList.Rows(Grid_PartList.Rows.Count - 1).StyleNew.ForeColor = Color.Blue
        Grid_PartList.Select(Grid_PartList.Row + 1, 2)

        Grid_PartList.AutoSizeCols()
        Grid_PartList.Redraw = True

    End Sub

    Private Sub TB_CustomerPartCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_CustomerPartCode.KeyDown,
        TB_Specification.KeyDown

        If e.KeyCode = 13 Then
            BTN_Search_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub CB_CustomerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_CustomerName.SelectedIndexChanged

        BTN_Search_Click(Nothing, Nothing)

    End Sub

    Private Sub BTN_CodeMapping_Click(sender As Object, e As EventArgs) Handles BTN_CodeMapping.Click

        frm_PartCodeMapping.TB_CustomerCode.Text = TB_CustomerCode.Text
        frm_PartCodeMapping.TB_Customer.Text = CB_CustomerName.Text
        frm_PartCodeMapping.TB_MainCode.Text = Grid_PartList(Grid_PartList.Row, 1)

        frm_PartCodeMapping.TB_PartCode.Text = Grid_PartList(Grid_PartList.Row, 3)
        frm_PartCodeMapping.TB_Specification.Text = Grid_PartList(Grid_PartList.Row, 4)
        frm_PartCodeMapping.TB_Vendor.Text = Grid_PartList(Grid_PartList.Row, 5)

        If frm_PartCodeMapping.ShowDialog = DialogResult.Yes Then
            BTN_Search_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub Grid_PartList_RowColChange(sender As Object, e As EventArgs) Handles Grid_PartList.RowColChange

        Select Case Grid_PartList.Col
            Case 1, 9
                Grid_PartList.AllowEditing = False
            Case Else
                Grid_PartList.AllowEditing = True
        End Select

    End Sub
End Class