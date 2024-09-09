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
            .Cols.Count = 10
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = True
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
        End With

        Grid_MaterialList(0, 0) = "No"
        Grid_MaterialList(0, 1) = "현장 출고일자"
        Grid_MaterialList(0, 2) = "자재 입고일자"
        Grid_MaterialList(0, 3) = "고객사"
        Grid_MaterialList(0, 4) = "제조사"
        Grid_MaterialList(0, 5) = "Part Code."
        Grid_MaterialList(0, 6) = "Part No."
        Grid_MaterialList(0, 7) = "Lot No."
        Grid_MaterialList(0, 8) = "Specification"
        Grid_MaterialList(0, 9) = "비고"
        Grid_MaterialList.AutoSizeCols()

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

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart(Me)

        Grid_MaterialList.Redraw = False
        Grid_MaterialList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_material_transfer("
        strSQL += "5"
        strSQL += ", '" & TB_CustomerCode.Text & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ",'" & Format(DateTimePicker2.Value, "yyyy-MM-dd 00:00:00") & "'"
        strSQL += ",'" & Format(DateTimePicker3.Value, "yyyy-MM-dd 23:59:59") & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Dim firstColor As Color = Color.LightBlue
        Dim secondColor As Color = Color.White
        Dim beforePartNo As String = String.Empty
        Dim nowColor As Color = firstColor

        Do While sqlDR.Read
            Dim insertString As String
            insertString = Grid_MaterialList.Rows.Count
            insertString += vbTab & Format(sqlDR("write_date"), "yyyy-MM-dd HH:mm:ss")
            insertString += vbTab & Format(sqlDR("in_date"), "yyyy-MM-dd HH:mm:ss")
            insertString += vbTab & sqlDR("customer_name")
            insertString += vbTab & sqlDR("part_code")
            insertString += vbTab & sqlDR("part_vendor")
            insertString += vbTab & sqlDR("part_no")
            insertString += vbTab & sqlDR("part_lot_no")
            insertString += vbTab & sqlDR("part_specification")
            insertString += vbTab & sqlDR("tn_note")
            Grid_MaterialList.AddItem(insertString)

            If Not sqlDR("part_code") = beforePartNo Then
                If nowColor = firstColor Then
                    nowColor = secondColor
                Else
                    nowColor = firstColor
                End If
                Grid_MaterialList.Rows(Grid_MaterialList.Rows.Count - 1).StyleNew.BackColor = nowColor
            Else
                Grid_MaterialList.Rows(Grid_MaterialList.Rows.Count - 1).StyleNew.BackColor = nowColor
            End If
            beforePartNo = sqlDR("part_code")
        Loop
        sqlDR.Close()

        DBClose()

        Grid_MaterialList.Redraw = True
        Grid_MaterialList.AutoSizeCols()

        Thread_LoadingFormEnd()

    End Sub
End Class