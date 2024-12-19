Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Material_Use_Information
    Private Sub frm_Material_Use_Information_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting(Grid_Ready)
        Grid_Setting(Grid_Run)
        Grid_Setting(Grid_Completed)

        If Not TB_PartCode.Text.Equals(String.Empty) Then
            Load_Information(Grid_Ready, 0)
            Load_Information(Grid_Run, 1)
            Load_Information(Grid_Completed, 2)
        End If

    End Sub

    Private Sub Grid_Setting(ByVal gridName As C1FlexGrid)

        With gridName
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 7
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            '.Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            .ExtendLastCol = False
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .Cols(5).DataType = GetType(Integer)
            .Cols(5).Format = "#,##0"
            .Cols(6).DataType = GetType(Integer)
            .Cols(6).Format = "#,##0"
        End With

        gridName(0, 0) = "No"
        gridName(0, 1) = "Model Code"
        gridName(0, 2) = "품번"
        gridName(0, 3) = "주문번호"
        gridName(0, 4) = "주문수량"
        gridName(0, 5) = "1 Array 사용"
        gridName(0, 6) = "Total 사용"

    End Sub

    Private Sub Load_Information(ByVal gridName As C1FlexGrid, ByVal findIndex As Integer)

        If TB_PartCode.Text.Equals(String.Empty) Then
            MSG_Information(Me, "Part Code를 입력하여 주십시오.")
            TB_PartCode.SelectAll()
            TB_PartCode.Focus()
            Exit Sub
        End If

        Thread_LoadingFormStart(Me)

        gridName.Redraw = False
        gridName.Rows.Count = 1

        If DBConnect() = False Then
            Thread_LoadingFormEnd()
            Exit Sub
        End If

        Dim strSQL As String = "call sp_mms_material_use_information("
        strSQL += "" & findIndex
        strSQL += ", '" & TB_PartCode.Text & "'"
        strSQL += ")"


        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader
        Dim totalUse As Double = 0

        Do While sqlDR.Read
            Dim insertString As String = gridName.Rows.Count
            insertString += vbTab & sqlDR("model_code")
            insertString += vbTab & sqlDR("item_code")
            insertString += vbTab & sqlDR("order_index")
            insertString += vbTab & sqlDR("modify_order_quantity")
            insertString += vbTab & sqlDR("each_count")
            insertString += vbTab & sqlDR("use_qty")
            totalUse += sqlDR("use_qty")
            GridWriteText(insertString, Me, gridName, Color.Black, Color.White)
        Loop
        sqlDR.Close()

        DBClose()

        Dim totalInsert As String = String.Empty
        totalInsert += vbTab
        totalInsert += vbTab
        totalInsert += vbTab
        totalInsert += vbTab
        totalInsert += vbTab
        totalInsert += vbTab & totalUse
        GridWriteText(totalInsert, Me, gridName, 1, Color.Black, Color.AliceBlue)

        gridName.AutoSizeCols()
        gridName.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub TB_PartCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_PartCode.KeyDown

        If Not TB_PartCode.Text.Equals(String.Empty) And e.KeyCode = 13 Then
            Load_Information(Grid_Ready, 0)
            Load_Information(Grid_Run, 1)
            Load_Information(Grid_Completed, 2)
        End If

    End Sub
End Class