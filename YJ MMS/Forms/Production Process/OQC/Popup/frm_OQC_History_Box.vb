Imports C1.Win.C1FlexGrid
Imports MySqlConnector

Public Class frm_OQC_History_Box

    Public orderIndex As String
    Dim firstChange As Boolean

    Private Sub frm_OQC_History_Box_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        firstChange = False

        Grid_Setting()

        Load_Basic_Information()
        Load_Box_Information()
        Load_SerialNo_Information()

    End Sub

    Private Sub Grid_Setting()

        With Grid_BoxList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.Columns
            .AllowMergingFixed = AllowMergingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 7
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Cols(1).DataType = GetType(DateTime)
            .Cols(1).Format = "yyyy-MM-dd HH:mm:ss"
            .Cols(4).DataType = GetType(Integer)
            .Cols(4).Format = "#,##0"
        End With

        Grid_BoxList(0, 0) = "No."
        Grid_BoxList(0, 1) = "일자"
        Grid_BoxList(0, 2) = "Box No."
        Grid_BoxList(0, 3) = "검사결과"
        Grid_BoxList(0, 4) = "수량"
        Grid_BoxList(0, 5) = "검사자"
        Grid_BoxList(0, 6) = "비고"

        For i = 0 To Grid_BoxList.Cols.Count - 1
            Grid_BoxList.Cols(i).StyleNew.TextAlign = TextAlignEnum.CenterCenter
        Next

        Grid_BoxList.AutoSizeCols()

        With C1FlexGrid1
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.Columns
            .AllowMergingFixed = AllowMergingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 4
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Cols(1).DataType = GetType(DateTime)
            .Cols(1).Format = "yyyy-MM-dd HH:mm:ss"
        End With

        C1FlexGrid1(0, 0) = "No."
        C1FlexGrid1(0, 1) = "일자"
        C1FlexGrid1(0, 2) = "Serial No."
        C1FlexGrid1(0, 3) = "Box No."

        For i = 0 To C1FlexGrid1.Cols.Count - 1
            C1FlexGrid1.Cols(i).StyleNew.TextAlign = TextAlignEnum.CenterCenter
        Next

        C1FlexGrid1.AutoSizeCols()

    End Sub

    Private Sub Load_Basic_Information()

        Thread_LoadingFormStart(Me)

        DBConnect()

        Dim strSQL As String = "call sp_mms_oqc_history(1"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & orderIndex & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_OrderIndex.Text = sqlDR("order_index")
            TB_ModelCode.Text = sqlDR("model_code")
            TB_ItemCode.Text = sqlDR("item_code")
            TB_ItemName.Text = sqlDR("item_name")
            TB_OrderQty.Text = Format(sqlDR("modify_order_quantity"), "#,##0")
            TB_DiscardQty.Text = Format(sqlDR("discard_quantity"), "#,##0")
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_Box_Information()

        Thread_LoadingFormStart(Me)

        Grid_BoxList.Redraw = False
        Grid_BoxList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_oqc_history(2"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & orderIndex & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = Grid_BoxList.Rows.Count
            insertString += vbTab & sqlDR("write_date")
            insertString += vbTab & sqlDR("oqc_no")
            insertString += vbTab & sqlDR("inspect_result")
            insertString += vbTab & sqlDR("box_qty")
            insertString += vbTab & sqlDR("inspector")
            insertString += vbTab & sqlDR("oqc_note")

            Grid_BoxList.AddItem(insertString)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_BoxList.AutoSizeCols()
        Grid_BoxList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_SerialNo_Information()

        Thread_LoadingFormStart(Me)

        C1FlexGrid1.Redraw = False
        C1FlexGrid1.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_oqc_history(3"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & orderIndex & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insertString As String = C1FlexGrid1.Rows.Count
            insertString += vbTab & sqlDR("register_date")
            insertString += vbTab & sqlDR("serial_no")
            insertString += vbTab & sqlDR("oqc_no")

            C1FlexGrid1.AddItem(insertString)
        Loop
        sqlDR.Close()

        DBClose()

        C1FlexGrid1.AutoSizeCols()
        C1FlexGrid1.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged

        If firstChange = False Then
            firstChange = True
            Exit Sub
        End If

        If RadioButton1.Checked = True Then
            C1FlexGrid1.Sort(SortFlags.Ascending, 1)
        ElseIf RadioButton2.Checked = True Then
            C1FlexGrid1.Sort(SortFlags.Ascending, 2)
        End If

        For i = 1 To C1FlexGrid1.Rows.Count - 1
            C1FlexGrid1(i, 0) = i
        Next

    End Sub

    Private Sub Grid_BoxList_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_BoxList.MouseClick

        Dim selRow As Integer = Grid_BoxList.MouseRow

        If selRow > 0 And e.Button = MouseButtons.Left Then
            Dim selBoxNo As String = Grid_BoxList(selRow, 2)

            For i = 1 To C1FlexGrid1.Rows.Count - 1
                If C1FlexGrid1(i, 3) = selBoxNo Then
                    C1FlexGrid1.Rows(i).StyleNew.BackColor = Color.LightBlue
                Else
                    C1FlexGrid1.Rows(i).StyleNew.BackColor = Color.White
                End If
            Next
        End If

    End Sub
End Class