'############################################################################################################
'############################################################################################################

'##### 작성일자 : 2024-02-19
'##### 수정일자 : 2024-02-19
'##### 수정자   : 박시현
'##### 참고     : 
'##### 설명     : 모델별 자료를 등록 한다.
'                 BOM, 좌표데이터, PCB Metal Gerber, Metal Mask Gerber, 참고자료 1, 2, 3 등등

'############################################################################################################

Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_ModelDocument

    Dim _al As ArrayList = New ArrayList()
    Friend BTN(21) As Button

    Private Sub frm_ModelDocument_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        With Grid_Documents
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 6
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 8
            Grid_Documents(0, 0) = "구분"
            Grid_Documents(0, 1) = "상태"
            Grid_Documents(0, 2) = "파일명"
            Grid_Documents(0, 3) = "Upload"
            Grid_Documents(0, 4) = "Download"
            Grid_Documents(0, 5) = "Delete"
            Grid_Documents(1, 0) = "BOM"
            Grid_Documents(2, 0) = "좌표데이터"
            Grid_Documents(3, 0) = "PCB Metal Gerber"
            Grid_Documents(4, 0) = "Metal Mask Gerber"
            Grid_Documents(5, 0) = "참고자료 1"
            Grid_Documents(6, 0) = "참고자료 2"
            Grid_Documents(7, 0) = "참고자료 3"
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .Cols(0).Width = 150
            .Cols(1).Width = 100
            .Cols(2).Width = 400
            .Cols(3).Width = 70
            .Cols(4).Width = 70
            .Cols(5).Width = 70
        End With

        Dim IndexButton As Integer = 0

        For j = 3 To 5
            For i = 1 To 7
                Dim ButtonText As String = String.Empty
                If j = 3 Then
                    ButtonText = "Upload"
                ElseIf j = 4 Then
                    ButtonText = "Download"
                ElseIf j = 5 Then
                    ButtonText = "Delete"
                End If
                BTN(IndexButton) = New Button()
                BTN(IndexButton).BackColor = SystemColors.Control
                BTN(IndexButton).Text = ButtonText
                BTN(IndexButton).Tag = IndexButton
                Controls.AddRange(New Control() {BTN(IndexButton)})
                AddHandler BTN(IndexButton).Click, AddressOf Button_Click
                _al.Add(New HostedControl(Grid_Documents, BTN(IndexButton), i, j))
                IndexButton += 1
            Next
        Next


    End Sub

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim bt As Button = CType(sender, Button)

        Select Case CInt(bt.Tag)
            Case 0 To 6
                'Upload
                FileUpload_Ready(CInt(bt.Tag) + 1)
            Case 7 To 13
                'Download
                MsgBox("다운로드 기능 만들어야된다.")
            Case 14 To 20
                'Delete
                FileDelete_Ready(CInt(bt.Tag) - 13)
        End Select

    End Sub

    Private Sub FileUpload_Ready(ByVal u_row As Integer)

        Dim openFile As New System.Windows.Forms.OpenFileDialog

        With openFile
            .Filter = "ALL Files (*.*)|*.*"
            .AddExtension() = True
        End With

        openFile.ShowDialog()

        If openFile.FileName = "" Then Exit Sub

        Grid_Documents.Rows(u_row).StyleNew.ForeColor = Color.Blue
        Grid_Documents(u_row, 1) = "Upload 대기"

        Dim tempFileFolder As String = Application.StartupPath & "\Temp"

        '폴더가 없으면 만들기
        If My.Computer.FileSystem.DirectoryExists(tempFileFolder) = False Then
            My.Computer.FileSystem.CreateDirectory(tempFileFolder)
        End If

        '선택한 파일을 임시폴더에 저장
        My.Computer.FileSystem.CopyFile(openFile.FileName, tempFileFolder & "\" & openFile.FileName.Split("\")(UBound(openFile.FileName.Split("\"))), True)

        Grid_Documents(u_row, 2) = openFile.FileName.Split("\")(UBound(openFile.FileName.Split("\")))

    End Sub

    Private Sub FileDelete_Ready(ByVal u_row As Integer)

        Dim tempFileFolder As String = Application.StartupPath & "\Temp"

        If Grid_Documents(u_row, 1) = "등록됨" Then
            Grid_Documents.Rows(u_row).StyleNew.ForeColor = Color.Red
            Grid_Documents(u_row, 1) = "Delete 대기"
        ElseIf Grid_Documents(u_row, 1) = "Upload 대기" Then
            My.Computer.FileSystem.DeleteFile(tempFileFolder & "\" & Grid_Documents(u_row, 2))
            Grid_Documents.Rows(u_row).StyleNew.ForeColor = Color.Black
            Reload_Document(u_row)
            MsgBox("삭제한뒤 원래 데이터를 불러 오는지 확인이 필요함.")
        ElseIf Grid_Documents(u_row, 1) = "등록필요" Then
            Exit Sub
        End If

    End Sub

    Private Sub Reload_Document(ByVal r_row As Integer)

        Dim findName As String = String.Empty

        Select Case r_row
            Case 1
                findName = "bom"
            Case 2
                findName = "coordinate"
            Case 3
                findName = "pcb_metal_gerber"
            Case 4
                findName = "metal_mask_gerber"
            Case 5
                findName = "etc1"
            Case 6
                findName = "etc2"
            Case 7
                findName = "etc3"
        End Select

        DBConnect()

        Dim strSQL As String = "call sp_model_document(2"
        strSQL += ",'" & TB_CustomerCode.Text & "'"
        strSQL += ",'" & TB_ModelCode.Text & "'"
        strSQL += ",'" & CB_ManagementNo.Text & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader
        Dim recordCount As Integer = 0

        Do While sqlDR.Read
            If sqlDR(findName).Equals(String.Empty) Then
                Grid_Documents(r_row, 1) = "등록필요"
                Grid_Documents(r_row, 2) = String.Empty
            Else
                Grid_Documents(r_row, 2) = sqlDR(findName)
            End If
            recordCount += 1
        Loop
        sqlDR.Close()

        DBClose()

        If recordCount = 0 Then
            Grid_Documents(r_row, 1) = "등록필요"
            Grid_Documents(r_row, 2) = String.Empty
        End If

    End Sub

    Private Sub Grid_Documents_Paint(sender As Object, e As PaintEventArgs) Handles Grid_Documents.Paint
        For Each hosted As HostedControl In _al
            hosted.UpdatePosition()
        Next
    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub btn_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        thread_LoadingFormStart()

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

        thread_LoadingFormEnd()

    End Sub

    Private Sub TB_SearchText_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_SearchCustomer.KeyDown,
            TB_SearchModel.KeyDown

        If e.KeyCode = 13 Then
            btn_Search_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub Grid_ModelList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Grid_ModelList.MouseDoubleClick

        If Grid_ModelList.MouseRow < 1 Then Exit Sub

        thread_LoadingFormStart()

        Control_Initiallize()

        Dim selRow As Integer = Grid_ModelList.MouseRow

        Load_ModelInformation(Grid_ModelList(selRow, 2), Grid_ModelList(selRow, 1))
        Load_ManagementNo(Grid_ModelList(selRow, 2), Grid_ModelList(selRow, 1))

        BTN_Save.Enabled = True

        thread_LoadingFormEnd()

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
            TB_CustomerCode.Text = sqlDR("customer_code")
            TB_CustomerName.Text = sqlDR("customer_name")
            TB_ModelCode.Text = sqlDR("model_code")
            TB_ModelName.Text = sqlDR("model_name")
            TB_ItemName.Text = sqlDR("item_name")
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
            CB_ManagementNo.Items.Add(sqlDR("management_no"))
        Loop
        sqlDR.Close()

        DBClose()

        If CB_ManagementNo.Items.Count = 0 Then
            BTN_NewManagementNo.Visible = True
        End If

    End Sub

    Private Sub Control_Initiallize()

        TB_CustomerCode.Text = String.Empty
        TB_CustomerName.Text = String.Empty
        TB_ModelCode.Text = String.Empty
        TB_ModelName.Text = String.Empty
        TB_ItemName.Text = String.Empty

        BTN_NewManagementNo.Visible = False
        BTN_Save.Enabled = False
        CB_ManagementNo.Items.Clear()

        For i = 1 To 7
            Grid_Documents(i, 1) = "등록필요"
            Grid_Documents.Rows(i).StyleNew.ForeColor = Color.Black
        Next

        For i = 1 To 7
            Grid_Documents(i, 2) = String.Empty
            Grid_Documents.Rows(i).StyleNew.ForeColor = Color.Black
        Next

    End Sub

    Private Sub BTN_NewManagementNo_Click(sender As Object, e As EventArgs) Handles BTN_NewManagementNo.Click

        Dim newNo As String = Format(Now, "yyMMddHHmmssff")

        CB_ManagementNo.Items.Add(newNo)
        CB_ManagementNo.Text = newNo

        BTN_NewManagementNo.Visible = False

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        If TB_ModelCode.Text.Equals(String.Empty) Then Exit Sub



        MsgBox("저장 완료.", MsgBoxStyle.Information, msg_form)

        Control_Initiallize()

    End Sub

    Private Sub C1FlexGrid1_Click(sender As Object, e As EventArgs)

    End Sub
End Class