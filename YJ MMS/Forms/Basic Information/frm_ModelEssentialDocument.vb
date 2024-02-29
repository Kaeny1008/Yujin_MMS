'############################################################################################################
'############################################################################################################

'##### 작성일자 : 2024-02-29
'##### 수정일자 : 2024-02-29
'##### 수정자   : 박시현
'##### 참고     : 
'##### 설명     : 모델별 BOM, 좌표데이터를 실제 사용할 수 있게 편집한다.

'############################################################################################################

Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_ModelEssentialDocument

    Private Sub frm_ModelEssentialDocument_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()
        SplitContainer1.Panel2Collapsed = True

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
            Grid_ModelList(0, 5) = "모델명"
            Grid_ModelList(0, 6) = "품목명"
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

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart()

        Control_Initiallize()

        Grid_ModelList.Redraw = False
        Grid_ModelList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "select a.model_code, a.customer_code, a.model_series, a.model_name, a.item_name, a.model_note, b.customer_name"
        strSQL += " from tb_model_list a"
        strSQL += " left join tb_customer_list b on a.customer_code = b.customer_code"
        strSQL += " where (a.customer_code like concat('%', '" & TB_SearchCustomer.Text & "', '%')"
        strSQL += " or b.customer_name like concat('%', '" & TB_SearchCustomer.Text & "', '%'))"
        strSQL += " and (a.model_code like concat('%', '" & TB_SearchModel.Text & "', '%')"
        strSQL += " or a.model_name like concat('%', '" & TB_SearchModel.Text & "', '%'))"
        strSQL += " order by a.model_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_ModelList.Rows.Count & vbTab &
                                          sqlDR("model_code") & vbTab &
                                          sqlDR("customer_code") & vbTab &
                                          sqlDR("customer_name") & vbTab &
                                          sqlDR("model_series") & vbTab &
                                          sqlDR("model_name") & vbTab &
                                          sqlDR("item_name") & vbTab &
                                          sqlDR("model_note")
            Grid_ModelList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_ModelList.AutoSizeCols()
        Grid_ModelList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_ModelList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Grid_ModelList.MouseDoubleClick

        If Grid_ModelList.MouseRow < 1 Then Exit Sub

        thread_LoadingFormStart()

        Control_Initiallize()

        Dim selRow As Integer = Grid_ModelList.MouseRow

        Load_ModelInformation(Grid_ModelList(selRow, 2), Grid_ModelList(selRow, 1))
        Load_ManagementNo(Grid_ModelList(selRow, 2), Grid_ModelList(selRow, 1))

        BTN_Save.Enabled = True

        SplitContainer1.Panel2Collapsed = False

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_ModelInformation(ByVal customerCode As String,
                                      ByVal modelCode As String)


        DBConnect()

        Dim strSQL As String = "call sp_model_document(0"
        strSQL += ",'" & customerCode & "'"
        strSQL += ",'" & modelCode & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            'TB_CustomerCode.Text = sqlDR("customer_code")
            'TB_CustomerName.Text = sqlDR("customer_name")
            'TB_ModelCode.Text = sqlDR("model_code")
            'TB_ModelName.Text = sqlDR("model_name")
            'TB_ItemName.Text = sqlDR("item_name")
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub Load_ManagementNo(ByVal customerCode As String,
                                  ByVal modelCode As String)

        DBConnect()

        Dim strSQL As String = "call sp_model_document(1"
        strSQL += ",'" & customerCode & "'"
        strSQL += ",'" & modelCode & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            'CB_ManagementNo.Items.Add(sqlDR("management_no"))
        Loop
        sqlDR.Close()

        DBClose()

        'CB_ManagementNo.SelectedIndex = CB_ManagementNo.Items.Count - 1

    End Sub

    Private Sub Control_Initiallize()

        SplitContainer1.Panel2Collapsed = True

    End Sub
End Class