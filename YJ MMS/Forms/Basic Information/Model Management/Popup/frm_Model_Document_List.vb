Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Model_Document_List

    Public modelCode As String
    Dim oldFileName As String

    Dim _al As ArrayList = New ArrayList()
    Friend BTN() As Button

    Private Sub frm_Model_Document_View_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Dim openFile As New System.Windows.Forms.OpenFileDialog

        'With openFile
        '    .Filter = "PDF Files(*.pdf)|*.pdf|All Files(*.*)|*.*"
        '    .AddExtension() = True
        'End With

        'If openFile.ShowDialog() = DialogResult.OK Then
        '    frm_PDF_Viewer.WebBrowser1.Navigate(openFile.FileName)
        '    frm_PDF_Viewer.Show()
        'End If

        Grid_Setting()

        Load_DocumentList()

    End Sub

    Private Sub Grid_Setting()

        With Grid_Document
            .AllowEditing = False
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowResizing = AllowResizingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 9
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .Cols(0).Width = 50
            .Cols(1).Width = 80
            .Cols(2).Width = 150
            .Cols(2).ComboList = "SMD|Wave Soldering|Selective Soldering"
            .Cols(3).Width = 80
            .Cols(3).ComboList = "투입|검사"
            .Cols(4).Width = 80
            .Cols(4).ComboList = "1|2|3"
            .Cols(4).DataType = GetType(Integer)
            .Cols(5).Width = 450
            .Cols(6).Width = 70
            .Cols(7).Width = 70
            .Cols(8).Width = 70
        End With

        Grid_Document(0, 0) = "No"
        Grid_Document(0, 1) = "자료번호"
        Grid_Document(0, 2) = "공정명"
        Grid_Document(0, 3) = "위치"
        Grid_Document(0, 4) = "대상작업자"
        Grid_Document(0, 5) = "파일명"
        Grid_Document(0, 6) = "Upload"
        Grid_Document(0, 7) = "Download"
        Grid_Document(0, 8) = "Delete"

    End Sub

    Private Sub Load_DocumentList()

        Thread_LoadingFormStart(Me)

        Grid_Document.Redraw = False
        Grid_Document.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_model_process_documents("
        strSQL += "1"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & TB_ModelCode.Text & "'"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_Document.Rows.Count & vbTab &
                                          sqlDR("document_no") & vbTab &
                                          sqlDR("process_name") & vbTab &
                                          sqlDR("process_inout") & vbTab &
                                          sqlDR("people_no") & vbTab &
                                          sqlDR("file_name")
            Grid_Document.AddItem(insert_String)

            If IsNothing(BTN) Then
                ReDim BTN(2)
            Else
                ReDim Preserve BTN(BTN.Count + 2)
            End If

            Dim firstIndex As Integer = BTN.Count - 3
            Grid_Document(Grid_Document.Rows.Count - 1, 6) = firstIndex

            For i = 1 To 3
                Dim buttonText As String = "Delete"
                If i = 1 Then
                    buttonText = "Upload"
                ElseIf i = 2 Then
                    buttonText = "Download"
                End If
                BTN(firstIndex) = New Button()
                BTN(firstIndex).BackColor = SystemColors.Control
                BTN(firstIndex).Text = buttonText
                BTN(firstIndex).Tag = sqlDR("document_no")
                Controls.AddRange(New Control() {BTN(firstIndex)})
                AddHandler BTN(firstIndex).Click, AddressOf Button_Click
                _al.Add(New md_HostedControl(Grid_Document, BTN(firstIndex), Grid_Document.Rows.Count - 1, i + 5))
                firstIndex += 1
            Next
        Loop
        sqlDR.Close()

        DBClose()

        Grid_Document.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_Document_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_Document.MouseClick

        Dim selRow As Integer = Grid_Document.MouseRow

        If e.Button = MouseButtons.Right And selRow > -1 Then
            Grid_Document.Row = selRow
            'Debug.Print(selrow)
            Grid_Menu.Show(Grid_Document, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub Grid_Document_RowColChange(sender As Object, e As EventArgs) Handles Grid_Document.RowColChange

        If Grid_Document.Row < 1 Then Exit Sub
        If Grid_Document.Col < 1 Then Exit Sub

        Select Case Grid_Document.Col
            Case 2, 3, 4
                If IsNumeric(Grid_Document(Grid_Document.Row, 0)) Then
                    Grid_Document.AllowEditing = False
                Else
                    Grid_Document.AllowEditing = True
                End If
            Case Else
                Grid_Document.AllowEditing = False
        End Select

    End Sub

    Dim beforeText As String

    Private Sub Grid_Document_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Grid_Document.BeforeEdit

        beforeText = Grid_Document(e.Row, e.Col)

    End Sub

    Private Sub Grid_Document_AfterEdit(sender As Object, e As RowColEventArgs) Handles Grid_Document.AfterEdit

        If beforeText = Grid_Document(e.Row, e.Col) Then Exit Sub

    End Sub

    Private Sub Grid_Document_Paint(sender As Object, e As PaintEventArgs) Handles Grid_Document.Paint
        For Each hosted As md_HostedControl In _al
            hosted.UpdatePosition()
        Next
    End Sub

    Private Sub BTN_RowAdd_Click(sender As Object, e As EventArgs) Handles BTN_RowAdd.Click

        If IsNothing(BTN) Then
            ReDim BTN(2)
        Else
            ReDim Preserve BTN(BTN.Count + 2)
        End If

        Dim firstIndex As Integer = BTN.Count - 3

        Dim insertRow As Integer = Grid_Document.Row + 1
        Dim documentNo As String = "PD" & Format(Now, "yyMMddHHmmssfff")

        Grid_Document.AddItem("N" & vbTab & documentNo, Grid_Document.Row + 1)
        Grid_Document.Rows(insertRow).StyleNew.ForeColor = Color.Blue
        Grid_Document(insertRow, 6) = firstIndex

        For i = 1 To 3
            Dim buttonText As String = "Delete"
            If i = 1 Then
                buttonText = "Upload"
            ElseIf i = 2 Then
                buttonText = "Download"
            End If
            BTN(firstIndex) = New Button()
            BTN(firstIndex).BackColor = SystemColors.Control
            BTN(firstIndex).Text = buttonText
            BTN(firstIndex).Tag = documentNo
            Controls.AddRange(New Control() {BTN(firstIndex)})
            AddHandler BTN(firstIndex).Click, AddressOf Button_Click
            _al.Add(New md_HostedControl(Grid_Document, BTN(firstIndex), insertRow, i + 5))
            firstIndex += 1
        Next

    End Sub

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim bt As Button = CType(sender, Button)

        For i = 1 To Grid_Document.Rows.Count - 1
            If Grid_Document(i, 1).Equals(bt.Tag) Then
                Select Case bt.Text
                    Case "Upload"
                        If Grid_Document(i, 2) = String.Empty Or Grid_Document(i, 3) = String.Empty Or CStr(Grid_Document(i, 4)) = String.Empty Then
                            MSG_Information(Me, "필수항목을 먼저 입력하여 주십시오.")
                        Else
                            File_Upload_Process(i)
                        End If
                    Case "Download"
                        File_Download(i)
                    Case "Delete"
                        If IsNumeric(Grid_Document(i, 0)) Then
                            File_Delete_Process(i)
                        Else
                            Dim firstIndex As Integer = CInt(Grid_Document(i, 6))
                            For j = 0 To 2
                                Grid_Document.Controls.Remove(BTN(firstIndex + j))
                            Next
                            Grid_Document.RemoveItem(i)
                        End If
                End Select
                Exit For
            End If
        Next

    End Sub

    Private Sub File_Upload_Process(ByVal selRow As Integer)

        Dim openFile As New System.Windows.Forms.OpenFileDialog

        With openFile
            .Filter = "ALL Files (*.*)|*.*"
            .AddExtension() = True
        End With

        openFile.ShowDialog()

        If openFile.FileName = "" Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        Dim tempFileFolder As String = Application.StartupPath & "\Temp"

        '폴더가 없으면 만들기
        If My.Computer.FileSystem.DirectoryExists(tempFileFolder) = False Then
            My.Computer.FileSystem.CreateDirectory(tempFileFolder)
        End If

        '선택한 파일을 임시폴더에 저장
        My.Computer.FileSystem.CopyFile(openFile.FileName, tempFileFolder & "\" & openFile.FileName.Split("\")(UBound(openFile.FileName.Split("\"))), True)

        '파일명을 그리드에 표시
        oldFileName = Grid_Document(selRow, 5)
        Grid_Document(selRow, 5) = openFile.FileName.Split("\")(UBound(openFile.FileName.Split("\")))

        Dim dbWrite_Result As String = Process_DB_Write(selRow)

        If Not dbWrite_Result.Equals("Completed") Then
            MSG_Error(Me, dbWrite_Result)
            Grid_Document(selRow, 5) = String.Empty
            Exit Sub
        End If

        If Not oldFileName = String.Empty Then Process_FTP_Delete(oldFileName)
        Process_FTP_UpLoad(Grid_Document(selRow, 5))

        Grid_Document(selRow, 0) = selRow
        Grid_Document.Rows(selRow).StyleNew.ForeColor = Color.Black
        Thread_LoadingFormEnd()

        'MessageBox.Show(Me,
        '                "저장 완료.",
        '                msg_form,
        '                MessageBoxButtons.OK,
        '                MessageBoxIcon.Information)
        MSG_Information(Me, "저장완료.")

    End Sub

    Private Function Process_DB_Write(ByVal selRow As Integer) As String

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            If IsNumeric(Grid_Document(selRow, 0)) Then
                strSQL = "update tb_model_process_document set file_name = '" & Grid_Document(selRow, 5).ToString.Replace("'", "\'") & "'"
                strSQL += " where document_no = '" & Grid_Document(selRow, 1) & "'"
                strSQL += ";"
            Else
                strSQL = "insert into tb_model_process_document("
                strSQL += "document_no, model_code, process_name, process_inout, people_no, file_name"
                strSQL += ") values("
                strSQL += "'" & Grid_Document(selRow, 1) & "'"
                strSQL += ",'" & TB_ModelCode.Text & "'"
                strSQL += ",'" & Grid_Document(selRow, 2) & "'"
                strSQL += ",'" & Grid_Document(selRow, 3) & "'"
                strSQL += "," & Grid_Document(selRow, 4) & ""
                strSQL += ",'" & Grid_Document(selRow, 5).ToString.Replace("'", "\'") & "'"
                strSQL += ");"
            End If

            If Not strSQL = String.Empty Then
                sqlCmd = New MySqlCommand(strSQL, dbConnection1)
                sqlCmd.Transaction = sqlTran
                sqlCmd.ExecuteNonQuery()

                sqlTran.Commit()
            End If
        Catch ex As MySqlException
            sqlTran.Rollback()
            DBClose()
            Return ex.Message
        End Try

        DBClose()

        Return "Completed"

    End Function

    Private Sub Process_FTP_UpLoad(ByVal fileName As String)

        Dim tempFileFolder As String = Application.StartupPath & "\Temp"

        'ROOT 폴더에서 고객사 폴더가 존재하는지 검색 후 존재하지 않으면 생성
        Dim rootFolder As String = ftpUrl & "/Model_Documents/"
        Dim ftpFolder As String = ftpFolderSearch(rootFolder) '고객사 폴더를 검색할 위치의 리스트를 저장

        Dim DirectoryName() As String = Split(ftpFolder, vbCrLf)
        Dim DirectoryExists As Boolean = False

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
        DirectoryExists = False
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

        '파일 업로드
        ftpFileUpload(ftpUrl & "/Model_Documents/" & TB_CustomerCode.Text & "/" & TB_ModelCode.Text,
                              tempFileFolder & "\" & fileName)

        '임시저장 파일 삭제
        If My.Computer.FileSystem.FileExists(tempFileFolder & "\" & fileName) Then _
                            My.Computer.FileSystem.DeleteFile(tempFileFolder & "\" & fileName)

    End Sub

    Private Sub File_Delete_Process(ByVal selRow As Integer)

        If MSG_Question(Me, "삭제 하시겠습니까?") = False Then Exit Sub

        Thread_LoadingFormStart(Me, "Deleting...")

        Dim dbWrite_Result As String = Process_DB_Delete(selRow)

        If Not dbWrite_Result.Equals("Completed") Then
            MSG_Error(Me, dbWrite_Result)
            Exit Sub
        End If

        Process_FTP_Delete(Grid_Document(selRow, 5))
        Dim firstIndex As Integer = CInt(Grid_Document(selRow, 6))
        For i = 0 To 2
            Grid_Document.Controls.Remove(BTN(firstIndex + i))
        Next
        Grid_Document.RemoveItem(selRow)

        For i = 1 To Grid_Document.Rows.Count - 1
            If IsNumeric(Grid_Document(i, 0)) Then
                Grid_Document(i, 0) = i
            End If
        Next

        Thread_LoadingFormEnd()

    End Sub

    Private Function Process_DB_Delete(ByVal selRow As Integer) As String

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            strSQL = "delete from tb_model_process_document"
            strSQL += " where document_no = '" & Grid_Document(selRow, 1) & "'"
            strSQL += ";"

            If Not strSQL = String.Empty Then
                sqlCmd = New MySqlCommand(strSQL, dbConnection1)
                sqlCmd.Transaction = sqlTran
                sqlCmd.ExecuteNonQuery()

                sqlTran.Commit()
            End If
        Catch ex As MySqlException
            sqlTran.Rollback()
            DBClose()
            Return ex.Message
        End Try

        DBClose()

        Return "Completed"

    End Function

    Private Sub Process_FTP_Delete(ByVal fileName As String)

        '파일 삭제
        ftpFileDelete(ftpUrl & "/Model_Documents/" & TB_CustomerCode.Text & "/" & TB_ModelCode.Text,
                      fileName)

    End Sub

    Private Sub File_Download(ByVal d_row As Integer)

        If Grid_Document(d_row, 5) = String.Empty Then Exit Sub

        Dim saveFile As New System.Windows.Forms.SaveFileDialog

        With saveFile
            .FileName = Grid_Document(d_row, 5)
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

        Dim downloadResult As String = ftpFileDownload(ftpUrl & "/Model_Documents/" & TB_CustomerCode.Text & "/" & TB_ModelCode.Text,
                                                       strFolder,
                                                       Grid_Document(d_row, 5))

        If Not downloadResult.Equals("Completed") Then
            MSG_Exclamation(Me, "Download 실패")
        Else
            MSG_Information(Me, "File Download.")
        End If

    End Sub
End Class