'############################################################################################################
'############################################################################################################

'##### 작성일자 : 2024-02-19
'##### 수정일자 : 2024-02-19
'##### 수정자   : 박시현
'##### 참고     : 
'##### 설명     : 모델별 자료를 등록 한다.
'                 BOM, 좌표데이터, PCB Metal Gerber, Metal Mask Gerber, 참고자료 1, 2, 3 등등

'############################################################################################################

Imports System.Text.RegularExpressions
Imports System.Threading
Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Model_Document

    Dim _al As ArrayList = New ArrayList()
    Friend BTN(21) As Button
    Dim runProcess As Thread

    Public ref_col, part_col, spec_col, x_col, y_col, a_col, tb_col, type_col As Integer
    Public start_row, last_row As Integer
    Public sheet_name As String

    Private Sub frm_ModelDocument_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Label11.Text = String.Empty
        Label12.Text = String.Empty
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
                _al.Add(New md_HostedControl(Grid_Documents, BTN(IndexButton), i, j))
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
            .Cols.Count = 5
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            Grid_BOM(0, 0) = "No"
            Grid_BOM(0, 1) = "Ref( Location )"
            Grid_BOM(0, 2) = "Part No.( Part Code )"
            Grid_BOM(0, 3) = "Material Type"
            Grid_BOM(0, 4) = "Loader PCB Check"
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
        End With

        With Grid_Coordinates
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 6
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            Grid_Coordinates(0, 0) = "No"
            Grid_Coordinates(0, 1) = "Ref( Location )"
            Grid_Coordinates(0, 2) = "X"
            Grid_Coordinates(0, 3) = "Y"
            Grid_Coordinates(0, 4) = "A"
            Grid_Coordinates(0, 5) = "Top / Bottom"
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
        End With

        With Grid_BOM_Total
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 9
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            Grid_BOM_Total(0, 0) = "No"
            Grid_BOM_Total(0, 1) = "Ref( Location )"
            Grid_BOM_Total(0, 2) = "Part No.( Part Code )"
            Grid_BOM_Total(0, 3) = "X"
            Grid_BOM_Total(0, 4) = "Y"
            Grid_BOM_Total(0, 5) = "A"
            Grid_BOM_Total(0, 6) = "Top / Bottom"
            Grid_BOM_Total(0, 7) = "타입"
            Grid_BOM_Total(0, 8) = "Loader PCB Check"
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            '.SelectionMode = SelectionModeEnum.Row
        End With

        With Grid_Process
            .AllowEditing = True
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowDragging = AllowDraggingEnum.Columns
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 1
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 2
            Grid_Process(0, 0) = "No"
            Grid_Process(1, 0) = "공정명"
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            '.SelectionMode = SelectionModeEnum.Row
        End With

    End Sub

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If CB_ManagementNo.Text = String.Empty Then
            MessageBox.Show(Me, "관리번호를 먼저 선택하여 주십시오.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim bt As Button = CType(sender, Button)
        '업로드다운로드지우기
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
                Coordinate_Modify()
            Case Else
                Exit Sub
        End Select

    End Sub

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

        frm_ExcelModify.callMode = "BOM"
        frm_ExcelModify.TB_File_Path.Text = Grid_Documents(1, 2)

        If frm_ExcelModify.ShowDialog() = DialogResult.OK Then
            runProcess = New Thread(AddressOf Load_BOM_List)
            runProcess.IsBackground = True
            runProcess.SetApartmentState(ApartmentState.STA)
            runProcess.Start()
        End If

    End Sub

    Private Sub Load_BOM_List()

        Dim selectFile As String = Application.StartupPath & "\Temp\"

        Thread_LoadingFormStart("Excel Load...")

        GridRedraw(False, Me, Grid_BOM)

        Dim excelApp As Object

        excelApp = CreateObject("Excel.Application")
        excelApp.DisplayAlerts = False
        excelApp.WorkBooks.Open(selectFile & Grid_Documents(1, 2))

        excelApp.Visible = False

        LabelTextUpdate(String.Empty, Me, Label11)

        Try
            With excelApp.ActiveWorkbook.Sheets(sheet_name)
                For i = start_row To last_row
                    Dim refString As String = Trim(.Cells(i, ref_col).Value)
                    Dim partString As String = Trim(.Cells(i, part_col).Value)
                    Dim typeString As String = String.Empty
                    Dim isLoaderPCB As String = String.Empty

                    If Not type_col = 0 Then
                        typeString = Trim(.Cells(i, type_col).Value)
                    End If

                    If typeString.ToUpper = "ASS'Y" Or typeString.ToUpper = "ASS’Y" Then
                        If MessageBox.Show(frm_Main,
                                        "Loader PCB가 검색 되었습니다." & vbCrLf &
                                        "Loader PCB 사용으로 변경 하시겠습니까?" & vbCrLf &
                                        "Part No. : " & partString & " 를 확인 후" & vbCrLf &
                                        "Loader PCB 사용여부를 확인 하여 주십시오.",
                                        msg_form,
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question
                                        ) = DialogResult.Yes Then
                            RadioButtonChecked(True, Me, RadioButton4)
                            isLoaderPCB = "Yes"
                        Else
                            RadioButtonChecked(True, Me, RadioButton3)
                        End If
                    End If

                    'If partString.Equals("1203020601") Then
                    '    For j = 0 To refString.Length - 1
                    '        Console.WriteLine(Asc(refString.Substring(j, 1)))
                    '    Next
                    'End If

                    If Not refString.Equals(String.Empty) Then
                        'Console.WriteLine(refString)
                        refString = refString.Replace(" ", ",")
                        refString = refString.Replace(vbLf, String.Empty)
                        refString = refString.Replace(vbCr, String.Empty)
                        refString = refString.Replace(vbCrLf, String.Empty)

                        Dim split_Ref() As String = refString.Split(",")
                        Dim lcSplit() As String
                        Dim lName As String = String.Empty
                        Dim fNumber, fNumber2 As Integer

                        If UBound(split_Ref) > 0 Then
                            For j = 0 To UBound(split_Ref)
                                If InStr(split_Ref(j), "~") > 0 Then
                                    lcSplit = Split(split_Ref(j), "~")
                                    lName = Microsoft.VisualBasic.Left(lcSplit(0), InStr(lcSplit(0), Regex.Replace(lcSplit(0), "\D", "")) - 1)
                                    fNumber = CInt(Regex.Replace(lcSplit(0), "\D", "")) '처음 시작하는 숫자
                                    fNumber2 = CInt(Regex.Replace(lcSplit(UBound(Split(split_Ref(j), "~"))), "\D", "")) '마지막 숫자
                                    For jj = fNumber To fNumber2
                                        GridWriteText(Grid_BOM.Rows.Count & vbTab &
                                                      (lName & jj) & vbTab &
                                                      partString & vbTab &
                                                      typeString & vbTab &
                                                      isLoaderPCB, Me, Grid_BOM, Color.Black)
                                    Next
                                Else
                                    GridWriteText(Grid_BOM.Rows.Count & vbTab &
                                                  split_Ref(j) & vbTab &
                                                  partString & vbTab &
                                                  typeString & vbTab &
                                                  isLoaderPCB, Me, Grid_BOM, Color.Black)
                                End If
                            Next
                        Else
                            If InStr(split_Ref(0), "~") > 0 Then
                                lcSplit = Split(split_Ref(0), "~")
                                lName = Microsoft.VisualBasic.Left(lcSplit(0), InStr(lcSplit(0), Regex.Replace(lcSplit(0), "\D", "")) - 1)
                                fNumber = CInt(Regex.Replace(lcSplit(0), "\D", "")) '처음 시작하는 숫자
                                fNumber2 = CInt(Regex.Replace(lcSplit(UBound(Split(split_Ref(0), "~"))), "\D", "")) '마지막 숫자
                                For jj = fNumber To fNumber2
                                    GridWriteText(Grid_BOM.Rows.Count & vbTab &
                                                  (lName & jj) & vbTab &
                                                  partString & vbTab &
                                                  typeString & vbTab &
                                                  isLoaderPCB, Me, Grid_BOM, Color.Black)
                                Next
                            Else
                                GridWriteText(Grid_BOM.Rows.Count & vbTab &
                                              split_Ref(0) & vbTab &
                                              partString & vbTab &
                                              typeString & vbTab &
                                              isLoaderPCB, Me, Grid_BOM, Color.Black)
                            End If
                        End If
                    Else
                        GridWriteText(Grid_BOM.Rows.Count & vbTab &
                                      refString & vbTab &
                                      partString & vbTab &
                                      typeString & vbTab &
                                      isLoaderPCB, Me, Grid_BOM, Color.Black)
                    End If

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

        'FormDispose(frm_ExcelModify)
        LabelTextUpdate("총 Point  : " & Format(Grid_BOM.Rows.Count - 1, "#,##0 EA"), Me, Label11)

        GridColsAutoSize(Me, Grid_BOM)
        GridRedraw(True, Me, Grid_BOM)
        Thread_LoadingFormEnd()

        runProcess.Abort()

    End Sub

    Private Sub Coordinate_Modify()

        MessageBox.Show(frm_Main,
                        "해당 첨부자료(좌표데이터)는 자료가공이 필요합니다.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)

        TabControl1.SelectedIndex = 2
        Grid_Coordinates.Redraw = False
        Grid_Coordinates.Rows.Count = 1
        Grid_Coordinates.Redraw = True

        frm_ExcelModify.callMode = "Coordinates"
        frm_ExcelModify.TB_File_Path.Text = Grid_Documents(2, 2)

        If frm_ExcelModify.ShowDialog() = DialogResult.OK Then
            runProcess = New Thread(AddressOf Load_Coorinates_List)
            runProcess.IsBackground = True
            runProcess.SetApartmentState(ApartmentState.STA)
            runProcess.Start()
        End If

    End Sub

    Private Sub Load_Coorinates_List()

        Dim selectFile As String = Application.StartupPath & "\Temp\"

        Thread_LoadingFormStart("Excel Load...")

        GridRedraw(False, Me, Grid_Coordinates)

        Dim excelApp As Object

        excelApp = CreateObject("Excel.Application")
        excelApp.DisplayAlerts = False
        excelApp.WorkBooks.Open(selectFile & Grid_Documents(2, 2))

        excelApp.Visible = False

        LabelTextUpdate(String.Empty, Me, Label12)

        Try
            With excelApp.ActiveWorkbook.Sheets(sheet_name)
                For i = start_row To last_row
                    Dim refString As String = Trim(.Cells(i, ref_col).Value)
                    Dim xString As Double = Trim(.Cells(i, x_col).Value)
                    Dim yString As Double = Trim(.Cells(i, y_col).Value)
                    Dim aString As Double = Trim(.Cells(i, a_col).Value)
                    Dim tbString As String = Trim(.Cells(i, tb_col).Value)

                    GridWriteText(Grid_Coordinates.Rows.Count & vbTab &
                                  refString & vbTab &
                                  xString & vbTab &
                                  yString & vbTab &
                                  aString & vbTab &
                                  tbString,
                                  Me, Grid_Coordinates, Color.Black)
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

        'FormDispose(frm_ExcelModify)
        LabelTextUpdate("총 Point  : " & Format(Grid_Coordinates.Rows.Count - 1, "#,##0 EA"), Me, Label12)

        GridColsAutoSize(Me, Grid_Coordinates)
        GridRedraw(True, Me, Grid_Coordinates)
        Thread_LoadingFormEnd()

        runProcess.Abort()

    End Sub

    Private Delegate Sub Sub_SetPGStatus(ByVal statusText As String)
    Private d_SetPGStatus = New Sub_SetPGStatus(AddressOf PG_Status)

    Private Sub PG_Status(ByVal statusText As String)

        frm_Main.lb_Status.Text = statusText
        frm_Main.lb_Status.GetCurrentParent.Refresh()

    End Sub

    Public Sub FileDelete_Ready(ByVal u_row As Integer)

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
        For Each hosted As md_HostedControl In _al
            hosted.UpdatePosition()
        Next
    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub btn_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart()

        Control_Initiallize()

        Grid_ModelList.Redraw = False
        Grid_ModelList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "select a.model_code, a.customer_code, a.spg, a.item_code, a.item_name, a.item_note, b.customer_name"
        strSQL += " from tb_model_list a"
        strSQL += " left join tb_customer_list b on a.customer_code = b.customer_code"
        strSQL += " where (a.customer_code like concat('%', '" & TB_SearchCustomer.Text & "', '%')"
        strSQL += " or b.customer_name like concat('%', '" & TB_SearchCustomer.Text & "', '%'))"
        strSQL += " and (a.model_code like concat('%', '" & TB_SearchModel.Text & "', '%')"
        strSQL += " or a.item_code like concat('%', '" & TB_SearchModel.Text & "', '%'))"
        strSQL += " order by a.item_code"

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

    Private Sub TB_SearchText_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_SearchCustomer.KeyDown,
            TB_SearchModel.KeyDown

        If e.KeyCode = 13 Then
            btn_Search_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub Grid_ModelList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Grid_ModelList.MouseDoubleClick

        If Grid_ModelList.MouseRow < 1 Then Exit Sub

        Thread_LoadingFormStart()

        Control_Initiallize()

        Dim selRow As Integer = Grid_ModelList.MouseRow

        Load_ModelInformation(Grid_ModelList(selRow, 2), Grid_ModelList(selRow, 1))
        Load_ManagementNo(Grid_ModelList(selRow, 2), Grid_ModelList(selRow, 1))
        Load_Process(Grid_ModelList(selRow, 2), Grid_ModelList(selRow, 1))

        BTN_Save.Enabled = True

        SplitContainer1.Panel2Collapsed = False

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Load_Process(ByVal customerCode As String,
                             ByVal modelCode As String)


        DBConnect()

        Dim strSQL As String = "call sp_model_document(7"
        strSQL += ",'" & customerCode & "'"
        strSQL += ",'" & modelCode & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Grid_Process.Cols.Add()
            Grid_Process(0, Grid_Process.Cols.Count - 1) = CStr(Grid_Process.Cols.Count - 1) & " 공정"
            Grid_Process(1, Grid_Process.Cols.Count - 1) = sqlDR("process_name")
        Loop
        sqlDR.Close()

        DBClose()

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
            TB_ModelName.Text = sqlDR("item_code")
            TB_ItemName.Text = sqlDR("item_name")
            TB_BarcodeString.Text = sqlDR("barcode_string")

            If sqlDR("use_bond") = "사용" Then
                RadioButton1.Checked = True
            Else
                RadioButton2.Checked = True
            End If

            If sqlDR("loader_pcb") = "사용" Then
                RadioButton4.Checked = True
            Else
                RadioButton3.Checked = True
            End If

            If sqlDR("is_loader_pcb") = "Yes" Then
                RadioButton6.Checked = True
            Else
                RadioButton5.Checked = True
            End If

            TextBox1.Text = sqlDR("etc_text")
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

    Private Sub BTN_Result_Click(sender As Object, e As EventArgs) Handles BTN_Result.Click

        If Grid_BOM.Rows.Count = 1 Then
            MessageBox.Show(frm_Main, "BOM을 먼저 불러 오십시오.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Grid_Coordinates.Rows.Count = 1 Then
            MessageBox.Show(frm_Main, "좌표데이터를 먼저 불러 오십시오.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Grid_BOM_Total.Redraw = False
        Grid_BOM_Total.Rows.Count = 1

        Dim findFault As Boolean = False
        frm_Coordinate_Find_Fault.Show(frm_Main)

        For i = 1 To Grid_BOM.Rows.Count - 1
            Dim nowRef As String = Grid_BOM(i, 1)
            Dim nowPart As String = Grid_BOM(i, 2)
            Dim nowType As String = Grid_BOM(i, 3)
            Dim nowIsLoaderPCB As String = Grid_BOM(i, 4)
            Dim coodinatesRow As Integer = Grid_Coordinates.FindRow(nowRef, 1, 1, True)
            Dim nowX As String = String.Empty
            Dim nowY As String = String.Empty
            Dim nowA As String = String.Empty
            Dim nowTB As String = String.Empty

            If coodinatesRow > 0 Then
                nowX = Grid_Coordinates(coodinatesRow, 2)
                nowY = Grid_Coordinates(coodinatesRow, 3)
                nowA = Grid_Coordinates(coodinatesRow, 4)
                nowTB = Grid_Coordinates(coodinatesRow, 5)
            Else
                findFault = True
                GridWriteText(frm_Coordinate_Find_Fault.Grid_BOM.Rows.Count & vbTab &
                              nowRef & vbTab &
                              nowPart,
                              frm_Coordinate_Find_Fault,
                              frm_Coordinate_Find_Fault.Grid_BOM,
                              Color.Blue)
                'frm_Coordinate_Find_Fault.Grid_BOM.AddItem(frm_Coordinate_Find_Fault.Grid_BOM.Rows.Count & vbTab & nowRef & vbTab & nowPart)
            End If

            Grid_BOM_Total.AddItem(Grid_BOM_Total.Rows.Count & vbTab &
                                   nowRef & vbTab &
                                   nowPart & vbTab &
                                   nowX & vbTab &
                                   nowY & vbTab &
                                   nowA & vbTab &
                                   nowTB & vbTab &
                                   nowType & vbTab &
                                   nowIsLoaderPCB
                                   )

        Next

        Grid_BOM_Total.AutoSizeCols()
        Grid_BOM_Total.Redraw = True

        '좌표를 찾지 못했다면..
        If findFault = True Then
            frm_Coordinate_Find_Fault.Grid_Coordinates.Redraw = False
            For i = 1 To Grid_Coordinates.Rows.Count - 1
                If Grid_BOM_Total.FindRow(Grid_Coordinates(i, 1), 1, 1, True) < 0 Then
                    frm_Coordinate_Find_Fault.Grid_Coordinates.AddItem(frm_Coordinate_Find_Fault.Grid_Coordinates.Rows.Count & vbTab &
                                                                       Grid_Coordinates(i, 1) & vbTab &
                                                                       Grid_Coordinates(i, 2) & vbTab &
                                                                       Grid_Coordinates(i, 3) & vbTab &
                                                                       Grid_Coordinates(i, 4) & vbTab &
                                                                       Grid_Coordinates(i, 5))
                End If
            Next
            frm_Coordinate_Find_Fault.Grid_Coordinates.AutoSizeCols()
            frm_Coordinate_Find_Fault.Grid_Coordinates.Redraw = True

            MessageBox.Show(frm_Main,
                            "좌표를 찾지 못한 Ref가 존재합니다." & vbCrLf & "확인하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            frm_Coordinate_Find_Fault.Focus()
        Else
            frm_Coordinate_Find_Fault.Close()
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

        Grid_BOM.Rows.Count = 1
        Grid_Coordinates.Rows.Count = 1
        Grid_BOM_Total.Rows.Count = 1

        Grid_Process.Cols.Count = 1

        TabControl1.SelectedIndex = 0

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

        If Grid_Process.Cols.Count = 1 Then
            MessageBox.Show("공정 흐름을 등록하여 주십시오.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Exit Sub
        End If

        If MsgBox("저장 하시겠습니까?",
                  MsgBoxStyle.Question + MsgBoxStyle.YesNo,
                  msg_form) = MsgBoxResult.No Then Exit Sub

        Thread_LoadingFormStart("Saving...")

        Dim dbWrite_Result As String = Process_DB_Write()
        Dim result_Message As String = String.Empty

        If dbWrite_Result.Equals("No Change") Then
            Thread_LoadingFormEnd()
            MessageBox.Show(Me,
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
            MessageBox.Show(Me,
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

        TabControl1.SelectedIndex = 0
        MessageBox.Show("저장 완료.",
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

            If Not Grid_Documents(1, 1) = "등록필요" Then
                strSQL += "delete from tb_model_bom"
                strSQL += " where customer_code = '" & TB_CustomerCode.Text & "'"
                strSQL += " and model_code = '" & TB_ModelCode.Text & "'"
                strSQL += " and management_no;"
                For i = 1 To Grid_BOM.Rows.Count - 1
                    strSQL += "insert into tb_model_bom("
                    strSQL += "customer_code, model_code, management_no, ref, part_no, material_type, is_loader_pcb) values("
                    strSQL += "'" & TB_CustomerCode.Text & "'"
                    strSQL += ",'" & TB_ModelCode.Text & "'"
                    strSQL += ",'" & CB_ManagementNo.Text & "'"
                    strSQL += ",'" & Grid_BOM(i, 1) & "'"
                    strSQL += ",'" & Grid_BOM(i, 2) & "'"
                    strSQL += ",'" & Replace(Grid_BOM(i, 3), "'", "\'") & "'"
                    strSQL += ",'" & Grid_BOM(i, 4) & "'"
                    strSQL += ");"
                Next
            End If

            If Not Grid_Documents(1, 2) = "등록필요" = True Then
                strSQL += "delete from tb_model_coordinates"
                strSQL += " where customer_code = '" & TB_CustomerCode.Text & "'"
                strSQL += " and model_code = '" & TB_ModelCode.Text & "'"
                strSQL += " and management_no;"
                For i = 1 To Grid_Coordinates.Rows.Count - 1
                    strSQL += "insert into tb_model_coordinates("
                    strSQL += "customer_code, model_code, management_no, ref, x_mm, y_mm, angle, tb) values("
                    strSQL += "'" & TB_CustomerCode.Text & "'"
                    strSQL += ",'" & TB_ModelCode.Text & "'"
                    strSQL += ",'" & CB_ManagementNo.Text & "'"
                    strSQL += ",'" & Grid_Coordinates(i, 1) & "'"
                    strSQL += ",'" & Grid_Coordinates(i, 2) & "'"
                    strSQL += ",'" & Grid_Coordinates(i, 3) & "'"
                    strSQL += ",'" & Grid_Coordinates(i, 4) & "'"
                    strSQL += ",'" & Grid_Coordinates(i, 5) & "'"
                    strSQL += ");"
                Next
            End If

            Dim useBond As String = RadioButton2.Text
            Dim useLoaderPCB As String = RadioButton3.Text
            Dim isLoaderPCB As String = "No"

            If RadioButton1.Checked = True Then
                useBond = RadioButton1.Text
            End If

            If RadioButton4.Checked = True Then
                useLoaderPCB = RadioButton4.Text
            End If

            If RadioButton6.Checked = True Then
                isLoaderPCB = "Yes"
            End If

            '특이사항 기록
            strSQL += "update tb_model_list set use_bond = '" & useBond & "'"
            strSQL += ", etc_text = '" & TextBox1.Text & "'"
            strSQL += ", loader_pcb = '" & useLoaderPCB & "'"
            strSQL += ", barcode_string = '" & TB_BarcodeString.Text & "'"
            strSQL += ", is_loader_pcb = '" & isLoaderPCB & "'"
            strSQL += " where customer_code = '" & TB_CustomerCode.Text & "'"
            strSQL += " and model_code = '" & TB_ModelCode.Text & "';"

            '공정순서 기록
            strSQL += "delete from tb_model_process"
            strSQL += " where customer_code = '" & TB_CustomerCode.Text & "'"
            strSQL += " and model_code = '" & TB_ModelCode.Text & "';"

            For i = 1 To Grid_Process.Cols.Count - 1
                strSQL += "insert into tb_model_process("
                strSQL += "customer_code, model_code, process_number, process_name"
                strSQL += ") values("
                strSQL += "'" & TB_CustomerCode.Text & "'"
                strSQL += ",'" & TB_ModelCode.Text & "'"
                strSQL += "," & i
                strSQL += ",'" & Grid_Process(1, i) & "'"
                strSQL += ");"
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

                '모델 폴더에서 관리번호 폴더가 존재하는지 검색 후 존재하지 않으면 생성
                DirectoryExists = False
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

        Load_Documents()
        Load_BOM()
        Load_Coodirnates()
        Load_BOM_Total()
        'thread_LoadingFormEnd()

    End Sub

    Private Sub Load_Documents()

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
                    GridWriteText("등록됨", i, 1, Me, Grid_Documents, Color.Black)
                    GridWriteText(sqlDR("file_name"), i, 2, Me, Grid_Documents, Color.Black)
                    Exit For
                End If
            Next
        Loop
        sqlDR.Close()

        DBClose()

        Grid_Documents.Redraw = True

    End Sub


    Private Sub Load_BOM()

        Grid_BOM.Redraw = False

        DBConnect()

        Dim strSQL As String = "call sp_model_document(4"
        strSQL += ",'" & TB_CustomerCode.Text & "'"
        strSQL += ",'" & TB_ModelCode.Text & "'"
        strSQL += ",'" & CB_ManagementNo.Text & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            GridWriteText(Grid_BOM.Rows.Count & vbTab &
                          sqlDR("ref") & vbTab &
                          sqlDR("part_no") & vbTab &
                          sqlDR("material_type") & vbTab &
                          sqlDR("is_loader_pcb"),
                          Me,
                          Grid_BOM,
                          Color.Black)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_BOM.AutoSizeCols()

        Grid_BOM.Redraw = True

    End Sub

    Private Sub Load_Coodirnates()

        Grid_Coordinates.Redraw = False

        DBConnect()

        Dim strSQL As String = "call sp_model_document(5"
        strSQL += ",'" & TB_CustomerCode.Text & "'"
        strSQL += ",'" & TB_ModelCode.Text & "'"
        strSQL += ",'" & CB_ManagementNo.Text & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            GridWriteText(Grid_Coordinates.Rows.Count & vbTab &
                          sqlDR("ref") & vbTab &
                          sqlDR("x_mm") & vbTab &
                          sqlDR("y_mm") & vbTab &
                          sqlDR("angle") & vbTab &
                          sqlDR("tb"),
                          Me,
                          Grid_Coordinates,
                          Color.Black)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_Coordinates.AutoSizeCols()

        Grid_Coordinates.Redraw = True

    End Sub

    Private Sub Load_BOM_Total()

        Grid_BOM_Total.Redraw = False

        DBConnect()

        Dim strSQL As String = "call sp_model_document(6"
        strSQL += ",'" & TB_CustomerCode.Text & "'"
        strSQL += ",'" & TB_ModelCode.Text & "'"
        strSQL += ",'" & CB_ManagementNo.Text & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            GridWriteText(Grid_BOM_Total.Rows.Count & vbTab &
                          sqlDR("ref") & vbTab &
                          sqlDR("part_no") & vbTab &
                          sqlDR("x_mm") & vbTab &
                          sqlDR("y_mm") & vbTab &
                          sqlDR("angle") & vbTab &
                          sqlDR("tb") & vbTab &
                          sqlDR("part_type") & vbTab &
                          sqlDR("is_loader_pcb"),
                          Me,
                          Grid_BOM_Total,
                          Color.Black)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_BOM_Total.AutoSizeCols()

        Grid_BOM_Total.Redraw = True

    End Sub

    Private Sub Grid_Process_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_Process.MouseClick

        Dim selCol As Integer = Grid_Process.MouseCol
        Grid_Process.Col = selCol

        If e.Button = MouseButtons.Right And selCol > -1 Then
            CMS_GridMenu.Show(Grid_Process, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub BTN_ProcessAdd_Click(sender As Object, e As EventArgs) Handles BTN_ProcessAdd.Click

        Dim selCol As Integer = Grid_Process.Col

        Grid_Process.Cols.Add()
        Grid_Process.Cols(Grid_Process.Cols.Count - 1).Move(selCol + 1)

        For i = 1 To Grid_Process.Cols.Count - 1
            Grid_Process(0, i) = CStr(i) + " 공정"
        Next

        Grid_ComboList_Process()
        'Console.WriteLine("Process List : " & processList)
        For i = 1 To Grid_Process.Cols.Count - 1
            Grid_Process.Cols(i).ComboList = processList
        Next

        Grid_Process.AutoSizeCols()

    End Sub

    Private Sub BTN_ProcessDelete_Click(sender As Object, e As EventArgs) Handles BTN_ProcessDelete.Click

        Dim selCol As Integer = Grid_Process.Col

        If selCol = 0 Then Exit Sub

        Grid_Process.Cols.Remove(selCol)

        For i = 1 To Grid_Process.Cols.Count - 1
            Grid_Process(0, i) = CStr(i) + " 공정"
        Next

        Grid_Process.AutoSizeCols()

    End Sub

    Dim processList As String

    Private Sub Grid_ComboList_Process()

        processList = String.Empty

        DBConnect()

        Dim strSQL As String = "select sub_code_name"
        strSQL += " from tb_code_sub"
        strSQL += " where main_code = 'MC00000002'"
        strSQL += " order by sub_code_name"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            If processList = String.Empty Then
                processList = sqlDR("sub_code_name")
            Else
                processList += "|" & sqlDR("sub_code_name")
            End If
        Loop
        sqlDR.Close()

        DBClose()

    End Sub

    Private Sub Grid_Process_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Grid_Process.BeforeEdit

        before_griddata = Grid_Process(e.Row, e.Col)

    End Sub

    Private Sub Grid_Process_AfterEdit(sender As Object, e As RowColEventArgs) Handles Grid_Process.AfterEdit

        If before_griddata = Grid_Process(e.Row, e.Col) Then Exit Sub

        Grid_Process.AutoSizeCols()

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        If TabControl1.SelectedIndex = 4 Then
            Grid_ComboList_Process()
            'Console.WriteLine("Process List : " & processList)
            For i = 1 To Grid_Process.Cols.Count - 1
                Grid_Process.Cols(i).ComboList = processList
            Next
        End If

    End Sub
End Class