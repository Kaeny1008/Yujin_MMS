Imports C1.Win.C1FlexGrid
Imports MySqlConnector

Public Class frm_Model_Process_Documents
    Private Sub frm_Model_Process_Documents_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

    End Sub

    Private Sub Grid_Setting()

        With Grid_ModelList
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
            Grid_ModelList(0, 0) = "No"
            Grid_ModelList(0, 1) = "모델코드"
            Grid_ModelList(0, 2) = "고객사 코드"
            Grid_ModelList(0, 3) = "고객사명"
            Grid_ModelList(0, 4) = "모델구분"
            Grid_ModelList(0, 5) = "품번"
            Grid_ModelList(0, 6) = "품명"
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            .ExtendLastCol = True
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .Cols(1).Visible = False
            .Cols(2).Visible = False
        End With

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart(Me)

        'Control_Initiallize()

        Grid_ModelList.Redraw = False
        Grid_ModelList.Rows.Count = 1

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_model_process_documents("
        strSQL += "0"
        strSQL += ", '" & TB_SearchCustomer.Text & "'"
        strSQL += ", '" & TB_SearchModel.Text & "'"
        strSQL += ", null"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_ModelList.Rows.Count & vbTab &
                                          sqlDR("model_code") & vbTab &
                                          sqlDR("customer_code") & vbTab &
                                          sqlDR("customer_name") & vbTab &
                                          sqlDR("spg") & vbTab &
                                          sqlDR("item_code") & vbTab &
                                          sqlDR("item_name") & vbTab &
                                          sqlDR("item_note")
            Grid_ModelList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_ModelList.AutoSizeCols()
        Grid_ModelList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_ModelList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Grid_ModelList.MouseDoubleClick

        Dim selRow As Integer = Grid_ModelList.MouseRow

        If e.Button = MouseButtons.Left And selRow > 0 Then
            Dim modelCode As String = Grid_ModelList(selRow, 1)

            frm_Model_Document_List.TB_ModelCode.Text = Grid_ModelList(selRow, 1)
            frm_Model_Document_List.TB_CustomerCode.Text = Grid_ModelList(selRow, 2)
            frm_Model_Document_List.TB_CustomerName.Text = Grid_ModelList(selRow, 3)
            frm_Model_Document_List.TB_ItemCode.Text = Grid_ModelList(selRow, 5)
            frm_Model_Document_List.TB_ItemName.Text = Grid_ModelList(selRow, 6)
            frm_Model_Document_List.Show()
            frm_Model_Document_List.Focus()
        End If

    End Sub
End Class