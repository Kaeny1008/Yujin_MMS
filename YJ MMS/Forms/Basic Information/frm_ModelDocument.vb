'############################################################################################################
'############################################################################################################

'##### 작성일자 : 2024-02-19
'##### 수정일자 : 2024-02-19
'##### 수정자   : 박시현
'##### 참고     : 
'##### 설명     : 모델별 자료를 등록 한다.
'                 BOM, 좌표데이터, PCB Metal Gerber, Metal Mask Gerber, 참고자료 1, 2, 3 등등

'############################################################################################################

Imports System.Threading
Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_ModelDocument

    Dim _al As ArrayList = New ArrayList()
    Friend BTN(21) As Button
    Dim runProcess As Thread

    Private Sub frm_ModelDocument_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        With Grid_BOM
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 3
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            Grid_BOM(0, 0) = "No"
            Grid_BOM(0, 1) = "Ref( Location )"
            Grid_BOM(0, 2) = "Part No.( Part Code )"
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
        End With

    End Sub

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim bt As Button = CType(sender, Button)

        Select Case CInt(bt.Tag)
            Case 0 To 6
                'Upload
                FileUpload_Ready(CInt(bt.Tag) + 1)
            Case 7 To 13
                'Download
                FileDownload(CInt(bt.Tag) - 6)
            Case 14 To 20
                'Delete
                FileDelete_Ready(CInt(bt.Tag) - 13)
        End Select

    End Sub

    Private Sub FileDownload(ByVal d_row As Integer)

        If Grid_Documents(d_row, 2) = String.Empty Then Exit Sub

        Dim saveFile As New System.Windows.Forms.SaveFileDialog

        With saveFile
            .FileName = Grid_Documents(d_row, 2)
            .Filter = "ALL Files (*.*)|*.*"
            .AddExtension() = True
        End With

        If saveFile.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        Dim strTemp() As String, strFolder As String
        strTemp = Split(saveFile.FileName, "\")
        Array.Resize(strTemp, strTemp.Length - 1)
        strFolder = String.Join("\", strTemp)

        Dim downloadResult As String = ftpFileDownload(ftpUrl & "/Model_Documents/" & TB_CustomerCode.Text & "/" & TB_ModelCode.Text & "/" & CB_ManagementNo.Text,
                                                       strFolder,
                                                       Grid_Documents(d_row, 2))

        If Not downloadResult.Equals("Completed") Then
            MsgBox("Download 실패" & vbCrLf & downloadResult, MsgBoxStyle.Critical, msg_form)
        Else
            MsgBox("File Download.", MsgBoxStyle.Information, msg_form)
        End If

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

        '파일명을 그리드에 표시
        Grid_Documents(u_row, 2) = openFile.FileName.Split("\")(UBound(openFile.FileName.Split("\")))

        Select Case u_row
            Case 1
                BOM_Modify()
            Case 2
                TabControl1.SelectedIndex = 2
                MessageBox.Show(frm_Main,
                                "해당 첨부자료(좌표데이터)는 자료가공이 필요합니다.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning)
            Case Else
                Exit Sub
        End Select

    End Sub

    Public ref_col, part_col, spec_col As Integer
    Public start_row As Integer
    Public sheet_name As String

    Private Sub BOM_Modify()

        MessageBox.Show(frm_Main,
                        "해당 첨부자료(BOM)는 자료가공이 필요합니다." & vbCrLf &
                        "Ref 구분은 ','로만 되어있어야 합니다." & vbCrLf &
                        "','구분이 아닐 경우 결과값이 상이할 수 있습니다.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)

        TabControl1.SelectedIndex = 1
        Grid_BOM.Redraw = False
        Grid_BOM.Rows.Count = 1
        Grid_BOM.Redraw = True

        frm_ExcelModify.TB_File_Path.Text = Grid_Documents(1, 2)

        If frm_ExcelModify.ShowDialog() = DialogResult.OK Then
            runProcess = New Thread(AddressOf Load_List)
            runProcess.IsBackground = True
            runProcess.SetApartmentState(ApartmentState.STA)
            runProcess.Start()
        End If

    End Sub

    Private Sub Load_List()

        Dim selectFile As String = Application.StartupPath & "\Temp\"

        Thread_LoadingFormStart("Excel Load...")

        GridRedraw(False, Me, Grid_BOM)

        Dim excelApp As Object

        excelApp = CreateObject("Excel.Application")
        excelApp.WorkBooks.Open(selectFile & Grid_Documents(1, 2))

        excelApp.Visible = False

        Try
            With excelApp.ActiveWorkbook.Sheets(sheet_name)
                For i = start_row To .UsedRange.Rows.Count
                    Dim refString As String = Trim(.Cells(i, ref_col).Value)
                    Dim partString As String = Trim(.Cells(i, part_col).Value)

                    If InStr(refString, " ") > 0 Then
                        refString = refString.Replace(" ", ",")
                    End If

                    '문자만 추출, '-'가 포함되었을경우 등등

                    GridWriteText("N" & vbTab & refString & vbTab & partString,
                                  Me,
                                  Grid_BOM)

                    Invoke(d_SetPGStatus,
                           "데이터를 불러오고 있습니다.     " &
                           Format(i - start_row + 1, "#,##0") & " / " &
                           Format(.UsedRange.Rows.Count - start_row + 1, "#,##0") & " 행")
                Next
            End With
        Catch ex As Exception
            MessageBox.Show(frm_Main,
                            ex.Message,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        Finally
            excelApp.WorkBooks(1).Close()
            excelApp.Quit()
            excelApp = Nothing
            Invoke(d_SetPGStatus, String.Empty)
        End Try

        GridColsAutoSize(Me, Grid_BOM)
        GridRedraw(True, Me, Grid_BOM)
        Thread_LoadingFormEnd()

        runProcess.Abort()

    End Sub

    Private Delegate Sub Sub_SetPGStatus(ByVal statusText As String)
    Private d_SetPGStatus = New Sub_SetPGStatus(AddressOf PG_Status)

    Private Sub PG_Status(ByVal statusText As String)

        frm_Main.lb_Status.Text = statusText
        frm_Main.lb_Status.GetCurrentParent.Refresh()

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
            'MsgBox("삭제한뒤 원래 데이터를 불러 오는지 확인이 필요함.")
        ElseIf Grid_Documents(u_row, 1) = "등록필요" Then
            Exit Sub
        End If

    End Sub

    Private Sub Reload_Document(ByVal r_row As Integer)

        DBConnect()

        Dim strSQL As String = "call sp_model_document(2"
        strSQL += ",'" & TB_CustomerCode.Text & "'"
            strSQL += ",'" & TB_ModelCode.Text & "'"
        strSQL += ",'" & CB_ManagementNo.Text & "'"
        strSQL += ",'" & Grid_Documents(r_row, 0) & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader
        Dim recordCount As Integer = 0

        Do While sqlDR.Read
            Grid_Documents(r_row, 1) = "등록됨"
            Grid_Documents(r_row, 2) = sqlDR("file_name")
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
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            CB_ManagementNo.Items.Add(sqlDR("management_no"))
        Loop
        sqlDR.Close()

        DBClose()

        BTN_NewManagementNo.Visible = True
        CB_ManagementNo.SelectedIndex = CB_ManagementNo.Items.Count - 1

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

        SplitContainer1.Panel2Collapsed = True

    End Sub

    Private Sub BTN_NewManagementNo_Click(sender As Object, e As EventArgs) Handles BTN_NewManagementNo.Click

        Dim newNo As String = Format(Now, "yyMMddHHmmssff")

        CB_ManagementNo.Items.Add(newNo)
        CB_ManagementNo.Text = newNo

        BTN_NewManagementNo.Visible = False

        For i = 1 To 7
            Grid_Documents(i, 1) = "등록필요"
            Grid_Documents.Rows(i).StyleNew.ForeColor = Color.Black
        Next

        For i = 1 To 7
            Grid_Documents(i, 2) = String.Empty
            Grid_Documents.Rows(i).StyleNew.ForeColor = Color.Black
        Next

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        If TB_ModelCode.Text.Equals(String.Empty) Then Exit Sub

        If MsgBox("저장 하시겠습니까?",
                  MsgBoxStyle.Question + MsgBoxStyle.YesNo,
                  msg_form) = MsgBoxResult.No Then Exit Sub

        thread_LoadingFormStart("Saving...")

        Dim dbWrite_Result As String = Process_DB_Write()
        Dim result_Message As String = String.Empty

        If dbWrite_Result.Equals("No Change") Then
            Thread_LoadingFormEnd()
            MessageBox.Show(frm_Main,
                            "변경사항이 없습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf dbWrite_Result.Equals("Completed") Then
            GoTo FTP_Control
        Else
            Thread_LoadingFormEnd()
            MessageBox.Show(frm_Main,
                            dbWrite_Result,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

FTP_Control:
        Process_FTP_UpDelete()

        Thread_LoadingFormEnd()
        MessageBox.Show(frm_Main,
                        "저장 완료.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1)

    End Sub

    Private Function Process_DB_Write() As String

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            For i = 1 To Grid_Documents.Rows.Count - 1
                If Grid_Documents(i, 1).Equals("Upload 대기") Then
                    '기존 등록된 내용이 있다면 지운다
                    strSQL += "delete from tb_model_document_information"
                    strSQL += " where customer_code = '" & TB_CustomerCode.Text & "'"
                    strSQL += " and model_code = '" & TB_ModelCode.Text & "'"
                    strSQL += " and management_no = '" & CB_ManagementNo.Text & "'"
                    strSQL += " and file_type = '" & Grid_Documents(i, 0) & "';"

                    '새로운 내용을 기록한다.
                    strSQL += "insert into tb_model_document_information("
                    strSQL += "management_no, customer_code, model_code"
                    strSQL += ", file_type, file_name, write_date, write_id"
                    strSQL += ") values("
                    strSQL += "'" & CB_ManagementNo.Text & "'"
                    strSQL += ",'" & TB_CustomerCode.Text & "'"
                    strSQL += ",'" & TB_ModelCode.Text & "'"
                    strSQL += ",'" & Grid_Documents(i, 0) & "'"
                    strSQL += ",'" & Replace(Grid_Documents(i, 2), "'", "\'") & "'"
                    strSQL += ",'" & writeDate & "'"
                    strSQL += ",'" & loginID & "');"
                ElseIf Grid_Documents(i, 1).Equals("Delete 대기") Then
                    strSQL += "delete from tb_model_document_information"
                    strSQL += " where customer_code = '" & TB_CustomerCode.Text & "'"
                    strSQL += " and model_code = '" & TB_ModelCode.Text & "'"
                    strSQL += " and management_no = '" & CB_ManagementNo.Text & "'"
                    strSQL += " and file_type = '" & Grid_Documents(i, 0) & "';"
                End If
            Next

            If strSQL = String.Empty Then
                DBClose()
                Return "No Change"
            End If

            sqlCmd = New MySqlCommand(strSQL, dbConnection1)
            sqlCmd.Transaction = sqlTran
            sqlCmd.ExecuteNonQuery()

            sqlTran.Commit()
        Catch ex As MySqlException
            sqlTran.Rollback()
            DBClose()
            'MsgBox(ex.Message, MsgBoxStyle.Critical, msg_form)
            Return ex.Message
        End Try

        DBClose()

        Return "Completed"

    End Function

    Private Sub Process_FTP_UpDelete()

        For i = 1 To Grid_Documents.Rows.Count - 1
            If Grid_Documents(i, 1).Equals("Upload 대기") Then
                Dim tempFileFolder As String = Application.StartupPath & "\Temp"

                'ROOT 폴더에서 고객사 폴더가 존재하는지 검색 후 존재하지 않으면 생성
                Dim rootFolder As String = ftpUrl & "/Model_Documents/"
                Dim ftpFolder As String = ftpFolderSearch(rootFolder) '고객사 폴더를 검색할 위치의 리스트를 저장

                Dim DirectoryName() As String = Split(ftpFolder, vbCrLf)
                Dim DirectoryExists As Boolean

                For j = 0 To UBound(DirectoryName) - 1
                    If TB_CustomerCode.Text = Trim(DirectoryName(j)) Then
                        DirectoryExists = True
                        Exit For
                    Else
                        DirectoryExists = False
                    End If
                Next

                If DirectoryExists = False Then
                    ftpFolderMake(ftpUrl & "/Model_Documents/" & TB_CustomerCode.Text)
                End If

                '고객사 폴더에서 모델 폴더가 존재하는지 검색 후 존재하지 않으면 생성
                ftpFolder = ftpFolderSearch(rootFolder & TB_CustomerCode.Text & "/") '모델 폴더를 검색할 위치의 리스트를 저장
                DirectoryName = Split(ftpFolder, vbCrLf)

                For j = 0 To UBound(DirectoryName) - 1
                    If TB_ModelCode.Text = Trim(DirectoryName(j)) Then
                        DirectoryExists = True
                        Exit For
                    Else
                        DirectoryExists = False
                    End If
                Next

                If DirectoryExists = False Then
                    ftpFolderMake(ftpUrl & "/Model_Documents/" & TB_CustomerCode.Text & "/" & TB_ModelCode.Text)
                End If

                '모델 폴더에서 관리번호 폴더가 존재하는지 검색 후 존재하지 않으면 생성
                ftpFolder = ftpFolderSearch(rootFolder & TB_CustomerCode.Text & "/" & TB_ModelCode.Text & "/") '관리번호 폴더를 검색할 위치의 리스트를 저장
                DirectoryName = Split(ftpFolder, vbCrLf)

                For j = 0 To UBound(DirectoryName) - 1
                    If CB_ManagementNo.Text = Trim(DirectoryName(j)) Then
                        DirectoryExists = True
                        Exit For
                    Else
                        DirectoryExists = False
                    End If
                Next

                If DirectoryExists = False Then
                    ftpFolderMake(ftpUrl & "/Model_Documents/" & TB_CustomerCode.Text & "/" & TB_ModelCode.Text & "/" & CB_ManagementNo.Text)
                End If

                '파일 업로드
                ftpFileUpload(ftpUrl & "/Model_Documents/" & TB_CustomerCode.Text & "/" & TB_ModelCode.Text & "/" & CB_ManagementNo.Text,
                              tempFileFolder & "\" & Grid_Documents(i, 2))

                '임시저장 파일 삭제
                If My.Computer.FileSystem.FileExists(tempFileFolder & "\" & Grid_Documents(i, 2)) Then _
                            My.Computer.FileSystem.DeleteFile(tempFileFolder & "\" & Grid_Documents(i, 2))
                Grid_Documents(i, 1) = "등록됨"
                Grid_Documents.Rows(i).StyleNew.ForeColor = Color.Black
            ElseIf Grid_Documents(i, 1).Equals("Delete 대기") Then
                '파일 삭제
                ftpFileDelete(ftpUrl & "/Model_Documents/" & TB_CustomerCode.Text & "/" & TB_ModelCode.Text & "/" & CB_ManagementNo.Text,
                              Grid_Documents(i, 2))
                Grid_Documents(i, 1) = "등록필요"
                Grid_Documents(i, 2) = String.Empty
                Grid_Documents.Rows(i).StyleNew.ForeColor = Color.Black
            End If
        Next

    End Sub

    Private Sub CB_ManagementNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_ManagementNo.SelectedIndexChanged

        'thread_LoadingFormStart()

        Grid_Documents.Redraw = False

        For i = 1 To 7
            Grid_Documents(i, 1) = "등록필요"
            Grid_Documents.Rows(i).StyleNew.ForeColor = Color.Black
        Next

        For i = 1 To 7
            Grid_Documents(i, 2) = String.Empty
            Grid_Documents.Rows(i).StyleNew.ForeColor = Color.Black
        Next

        DBConnect()

        Dim strSQL As String = "call sp_model_document(3"
        strSQL += ",'" & TB_CustomerCode.Text & "'"
        strSQL += ",'" & TB_ModelCode.Text & "'"
        strSQL += ",'" & CB_ManagementNo.Text & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            For i = 1 To Grid_Documents.Rows.Count - 1
                If sqlDR("file_type").Equals(Grid_Documents(i, 0)) Then
                    Grid_Documents(i, 1) = "등록됨"
                    Grid_Documents(i, 2) = sqlDR("file_name")
                    Exit For
                End If
            Next
        Loop
        sqlDR.Close()

        DBClose()

        Grid_Documents.Redraw = True

        'thread_LoadingFormEnd()

    End Sub
End Class