﻿Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_SMD_Production_Start

    Dim selFactoryCode As String

    Private Sub frm_SMD_Production_Start_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

    End Sub

    Private Sub Grid_Setting()

        With Grid_OrderList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 15
            .Cols.Fixed = 1
            .Rows.Count = 3
            .Rows.Fixed = 3
            For i = 0 To .Cols.Count - 1
                .Cols(i).AllowMerging = True
            Next
            For i = 0 To .Rows.Count - 1
                .Rows(i).AllowMerging = True
            Next
            Dim rngM As CellRange = .GetCellRange(0, 0, 2, 0)
            rngM.Data = "No"
            rngM = .GetCellRange(0, 1, 2, 1)
            rngM.Data = "Order Index"
            rngM = .GetCellRange(0, 2, 2, 2)
            rngM.Data = "납기일자"
            rngM = .GetCellRange(0, 3, 2, 3)
            rngM.Data = "고객사 코드"
            rngM = .GetCellRange(0, 4, 2, 4)
            rngM.Data = "고객사"
            rngM = .GetCellRange(0, 5, 2, 5)
            rngM.Data = "모델코드"
            rngM = .GetCellRange(0, 6, 2, 6)
            rngM.Data = "품번"
            rngM = .GetCellRange(0, 7, 2, 7)
            rngM.Data = "품명"
            rngM = .GetCellRange(0, 8, 2, 8)
            rngM.Data = "주문수량"
            rngM = .GetCellRange(0, 9, 2, 11)
            rngM.Data = "생산계획"
            rngM = .GetCellRange(1, 9, 2, 9)
            rngM.Data = "생산시작일"
            rngM = .GetCellRange(1, 10, 1, 11)
            rngM.Data = "SMD"
            Grid_OrderList(2, 10) = "동"
            Grid_OrderList(2, 11) = "Line"
            rngM = .GetCellRange(0, 12, 0, 14)
            rngM.Data = "작업구분"
            rngM = .GetCellRange(1, 12, 2, 12)
            rngM.Data = "BOM 확인"
            rngM = .GetCellRange(1, 13, 2, 13)
            rngM.Data = "Bottom"
            rngM = .GetCellRange(1, 14, 2, 14)
            rngM.Data = "Top"

            'Grid_OrderList(2, 12) = "BOM 확인"
            'Grid_OrderList(2, 13) = "Bottom"
            'Grid_OrderList(2, 14) = "Top"
            '.Rows(0).StyleNew.Font = New Font("굴림", 12, FontStyle.Bold)
            '.Rows(1).StyleNew.Font = New Font("굴림", 12, FontStyle.Bold)
            '.Rows(2).StyleNew.Font = New Font("굴림", 12, FontStyle.Bold)
            '.Font = New Font("굴림", 12, FontStyle.Regular)
            .Cols(1).Visible = True
            .Cols(3).Visible = True
            .Cols(9).DataType = GetType(Date)
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .Cols(9).TextAlign = TextAlignEnum.CenterCenter
            '.Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            .ExtendLastCol = False
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            '.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
            '.DragMode = C1.Win.C1FlexGrid.DragModeEnum.Manual
            '.DropMode = C1.Win.C1FlexGrid.DropModeEnum.Manual
            .SelectionMode = SelectionModeEnum.Default
        End With

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub CB_Department_DropDown(sender As Object, e As EventArgs) Handles CB_Department.DropDown

        CB_Department.Items.Clear()

        DBConnect()

        Dim strSQL As String = "select sub_code_name from tb_code_sub"
        strSQL += " where main_code = 'MC00000001' order by sub_code_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            CB_Department.Items.Add(sqlDR("sub_code_name"))
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub CB_Department_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_Department.SelectionChangeCommitted

        DBConnect()

        Dim strSQL As String = "select sub_code from tb_code_sub"
        strSQL += " where sub_code_name = '" & CB_Department.Text & "'"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            selFactoryCode = sqlDR("sub_code")
        Loop
        sqlDR.Close()

        DBClose()

        CB_Line.SelectedIndex = -1

    End Sub

    Private Sub CB_Line_DropDown(sender As Object, e As EventArgs) Handles CB_Line.DropDown

        CB_Line.Items.Clear()

        DBConnect()

        Dim strSQL As String = "select last_code_name from tb_code_last"
        strSQL += " where sub_code = '" & selFactoryCode & "' order by last_code_name"


        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            CB_Line.Items.Add(sqlDR("last_code_name"))
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart()

        Grid_OrderList.Redraw = False
        Grid_OrderList.Rows.Count = 3

        Load_OrderList() '리스트를 불러온다.
        Load_TopBottom() 'Top/Bottom 작업 구분을 한다.

        Grid_OrderList.AutoSizeCols()
        Grid_OrderList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_OrderList()

        DBConnect()

        Dim strSQL As String = "call sp_mms_smd_production_start(0"
        strSQL += ", '" & CB_Department.Text & "'"
        strSQL += ", '" & CB_Line.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_OrderList.Rows.Count - 2 & vbTab &
                                          sqlDR("order_index") & vbTab &
                                          sqlDR("date_of_delivery") & vbTab &
                                          sqlDR("customer_code") & vbTab &
                                          sqlDR("customer_name") & vbTab &
                                          sqlDR("model_code") & vbTab &
                                          sqlDR("item_code") & vbTab &
                                          sqlDR("item_name") & vbTab &
                                          Format(sqlDR("modify_order_quantity"), "#,##0") & vbTab &
                                          sqlDR("start_date") & vbTab &
                                          sqlDR("smd_department") & vbTab &
                                          sqlDR("smd_line")
            Grid_OrderList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Friend userButton() As Button
    Friend userButton2() As Button
    Dim _al As ArrayList = New ArrayList()

    Private Sub Load_TopBottom()

        DBConnect()

        For i = 3 To Grid_OrderList.Rows.Count - 1
            Dim strSQL As String = "call sp_mms_smd_production_start(1"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", '" & Grid_OrderList(i, 5) & "'"
            strSQL += ", '" & Grid_OrderList(i, 3) & "'"
            strSQL += ", null"
            strSQL += ")"

            Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
            Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

            Do While sqlDR.Read
                Dim workSite As String = "Bottom / Top"

                If IsDBNull(sqlDR("Bottom")) And
                    Not IsDBNull(sqlDR("Top")) Then
                    workSite = "Top"
                ElseIf Not IsDBNull(sqlDR("Bottom")) And
                    IsDBNull(sqlDR("Top")) Then
                    workSite = "Bottom"
                End If

                Grid_OrderList(i, 12) = workSite
            Loop
            sqlDR.Close()
        Next

        DBClose()

        ReDim userButton(Grid_OrderList.Rows.Count - 4)
        ReDim userButton2(Grid_OrderList.Rows.Count - 4)

        For i = 3 To Grid_OrderList.Rows.Count - 1
            userButton(i - 3) = New Button()
            userButton(i - 3).BackColor = SystemColors.Control
            userButton(i - 3).Text = "생산시작"
            userButton(i - 3).Tag = i
            Controls.AddRange(New Control() {userButton(i - 3)})
            AddHandler userButton(i - 3).Click, AddressOf UserButton_Bottom_Click
            _al.Add(New HostedControl(Grid_OrderList, userButton(i - 3), i, 13))

            userButton2(i - 3) = New Button()
            userButton2(i - 3).BackColor = SystemColors.Control
            userButton2(i - 3).Text = "생산시작"
            userButton2(i - 3).Tag = i
            Controls.AddRange(New Control() {userButton2(i - 3)})
            AddHandler userButton2(i - 3).Click, AddressOf UserButton_Top_Click
            _al.Add(New HostedControl(Grid_OrderList, userButton2(i - 3), i, 14))
        Next

    End Sub

    Private Sub Grid_OrderList_Paint(sender As Object, e As PaintEventArgs) Handles Grid_OrderList.Paint
        For Each hosted As HostedControl In _al
            hosted.UpdatePosition()
        Next
    End Sub

    Private Sub UserButton_Bottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim bt As Button = CType(sender, Button)
        Dim selRow As Integer = CInt(bt.Tag)

        frm_SMD_Mismount_Barcode.modelCode = Grid_OrderList(selRow, 5)
        frm_SMD_Mismount_Barcode.factoryName = Grid_OrderList(selRow, 10)
        frm_SMD_Mismount_Barcode.lineName = Grid_OrderList(selRow, 11)
        frm_SMD_Mismount_Barcode.workSide = "Bottom"
        If Not frm_SMD_Mismount_Barcode.ShowDialog = DialogResult.OK Then
            'MessageBox.Show(Me,
            '                "알 수 없는 오류가 발생하였습니다.",
            '                msg_form,
            '                MessageBoxButtons.OK,
            '                MessageBoxIcon.Error)
            frm_SMD_Mismount_Barcode.Dispose()
            Exit Sub
        End If
        frm_SMD_Mismount_Barcode.Dispose()

        Dim warning As Boolean = False

        For i = 3 To Grid_OrderList.Rows.Count - 1
            If CDate(Grid_OrderList(i, 2)) < CDate(Grid_OrderList(selRow, 2)) Then
                warning = True
                Exit For
            End If
        Next

        If warning = True Then
            frm_SMD_Production_Information.warning = True
        Else
            frm_SMD_Production_Information.warning = False
        End If

        frm_SMD_Production_Information.TB_OrderIndex.Text = Grid_OrderList(selRow, 1)
        frm_SMD_Production_Information.TB_Factory.Text = CB_Department.Text
        frm_SMD_Production_Information.TB_Line.Text = CB_Line.Text
        frm_SMD_Production_Information.TB_ModelCode.Text = Grid_OrderList(selRow, 5)
        frm_SMD_Production_Information.TB_ItemCode.Text = Grid_OrderList(selRow, 6)
        frm_SMD_Production_Information.TB_ItemName.Text = Grid_OrderList(selRow, 7)
        frm_SMD_Production_Information.TB_WorkSide.Text = "Bottom"

        If frm_SMD_Production_Information.ShowDialog = DialogResult.OK Then
            If StartWrite(frm_SMD_Production_Information.TB_Operater.Text,
                          Grid_OrderList(selRow, 1), "Bottom") = False Then
                MessageBox.Show(Me,
                                "시작 등록을 실패 하였습니다.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                Exit Sub
            End If
        Else
            Exit Sub
        End If
        frm_SMD_Production_Information.Dispose()

        MessageBox.Show(Me,
                        "시작등록을 최종 완료 하였습니다." & vbCrLf & "생산을 시작하여 주십시오.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

        BTN_Search_Click(Nothing, Nothing)

    End Sub

    Private Sub UserButton_Top_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("Top 시작")
    End Sub

    Private Sub Grid_OrderList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Grid_OrderList.MouseDoubleClick
        'Cell버튼이 아래 역할을 수행한다.
        '아래 코드를 실행하지 않아도 된다.
        'Dim selRow As Integer = Grid_OrderList.MouseRow

        'If e.Button = MouseButtons.Left And selRow > 2 Then

        '    frm_SMD_Mismount_Barcode.modelCode = Grid_OrderList(selRow, 5)
        '    frm_SMD_Mismount_Barcode.factoryName = Grid_OrderList(selRow, 10)
        '    frm_SMD_Mismount_Barcode.lineName = Grid_OrderList(selRow, 11)
        '    If Not frm_SMD_Mismount_Barcode.ShowDialog = DialogResult.OK Then
        '        'MessageBox.Show(Me,
        '        '                "알 수 없는 오류가 발생하였습니다.",
        '        '                msg_form,
        '        '                MessageBoxButtons.OK,
        '        '                MessageBoxIcon.Error)
        '        frm_SMD_Mismount_Barcode.Dispose()
        '        Exit Sub
        '    End If
        '    frm_SMD_Mismount_Barcode.Dispose()

        '    Dim warning As Boolean = False

        '    For i = 3 To Grid_OrderList.Rows.Count - 1
        '        If CDate(Grid_OrderList(i, 2)) < CDate(Grid_OrderList(selRow, 2)) Then
        '            warning = True
        '            Exit For
        '        End If
        '    Next

        '    If warning = True Then
        '        frm_SMD_Production_Information.warning = True
        '    Else
        '        frm_SMD_Production_Information.warning = False
        '    End If

        '    frm_SMD_Production_Information.TB_OrderIndex.Text = Grid_OrderList(selRow, 1)
        '    frm_SMD_Production_Information.TB_Factory.Text = CB_Department.Text
        '    frm_SMD_Production_Information.TB_Line.Text = CB_Line.Text
        '    frm_SMD_Production_Information.TB_ModelCode.Text = Grid_OrderList(selRow, 5)
        '    frm_SMD_Production_Information.TB_ItemCode.Text = Grid_OrderList(selRow, 6)
        '    frm_SMD_Production_Information.TB_ItemName.Text = Grid_OrderList(selRow, 7)

        '    If frm_SMD_Production_Information.ShowDialog = DialogResult.OK Then
        '        If StartWrite(frm_SMD_Production_Information.TB_Operater.Text, Grid_OrderList(selRow, 1)) = False Then
        '            MessageBox.Show(Me,
        '                            "시작 등록을 실패 하였습니다.",
        '                            msg_form,
        '                            MessageBoxButtons.OK,
        '                            MessageBoxIcon.Error)
        '            Exit Sub
        '        End If
        '    Else
        '        Exit Sub
        '    End If
        '    frm_SMD_Production_Information.Dispose()

        '    MessageBox.Show(Me,
        '                    "시작등록을 최종 완료 하였습니다." & vbCrLf & "생산을 시작하여 주십시오.",
        '                    msg_form,
        '                    MessageBoxButtons.OK,
        '                    MessageBoxIcon.Information)

        '    BTN_Search_Click(Nothing, Nothing)
        'End If

    End Sub

    Private Function StartWrite(ByVal smd_operater As String,
                                ByVal oder_index As String,
                                ByVal work_side As String) As Boolean

        Dim writeSuccess As Boolean = True

        Thread_LoadingFormStart("Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            strSQL += "insert into tb_mms_smd_production_history("
            strSQL += "order_index, smd_start_date, smd_operater, start_quantity, work_side"
            strSQL += ") values("
            strSQL += "'" & oder_index & "'"
            strSQL += ",'" & writeDate & "'"
            strSQL += ",'" & smd_operater & "'"
            strSQL += ",'" & 0 & "'"
            strSQL += ",'" & work_side & "'"
            strSQL += ");"
            strSQL += "update tb_mms_order_register_list set order_status = 'Production in SMD'"
            strSQL += " where order_index = '" & oder_index & "';"

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
            writeSuccess = False
            MessageBox.Show(Me,
                            ex.Message,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Return writeSuccess
        End Try

        DBClose()
        writeSuccess = True

        Thread_LoadingFormEnd()

        Return writeSuccess

    End Function

    Private Sub CB_Department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Department.SelectedIndexChanged

    End Sub
End Class