Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_WorkSite_Transfer_Material_List
    Private Sub frm_WorkSite_Transfer_Material_List_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DateTimePicker2.Value = Format(Now, "yyyy-MM-01")
        DateTimePicker3.Value = Format(Now, "yyyy-MM-dd")

        Grid_Setting()
        Load_CustomerList()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub Grid_Setting()

        With Grid_MaterialList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.Both
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            '.AllowResizing = True
            .AllowDragging = AllowDraggingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 5
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
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .Cols(2).DataType = GetType(Double)
            .Cols(2).Format = "#,##0"
            .Cols(3).DataType = GetType(Double)
            .Cols(3).Format = "#,##0"
            .Cols(4).DataType = GetType(Double)
            .Cols(4).Format = "#,##0"
        End With

        Grid_MaterialList(0, 0) = "No"
        Grid_MaterialList(0, 1) = "Part Code"
        Grid_MaterialList(0, 2) = "출고수량"
        Grid_MaterialList(0, 3) = "재입고 수량"
        Grid_MaterialList(0, 4) = "현장 재고수량"
        Grid_MaterialList.AutoSizeCols()

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

    End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart(Me)

        Grid_MaterialList.Redraw = False
        Grid_MaterialList.Rows.Count = 1

        Load_OutList()
        Load_InList()

        Grid_MaterialList.Redraw = True
        Grid_MaterialList.AutoSizeCols()

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_OutList()

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_material_transfer("
        strSQL += "6"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
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
            Dim insertString As String = Grid_MaterialList.Rows.Count
            insertString += vbTab & sqlDR("part_code")
            insertString += vbTab & sqlDR("out_total")
            insertString += vbTab & 0
            insertString += vbTab & sqlDR("out_total")
            Grid_MaterialList.AddItem(insertString)
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub Load_InList()

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_material_transfer("
        strSQL += "7"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
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
            Dim insertString As String = Grid_MaterialList.Rows.Count
            insertString += vbTab & sqlDR("part_code")
            insertString += vbTab & sqlDR("in_total")

            Dim existPartRow As Integer = Grid_MaterialList.FindRow(sqlDR("part_code"), 1, 1, True)
            If Not existPartRow = -1 Then
                Grid_MaterialList(existPartRow, 3) = sqlDR("in_total")
                Grid_MaterialList(existPartRow, 4) = Grid_MaterialList(existPartRow, 2) - Grid_MaterialList(existPartRow, 3)
            Else
                Grid_MaterialList.AddItem(insertString)
            End If
        Loop
        sqlDR.Close()

        DBClose()

    End Sub
End Class