'############################################################################################################
'############################################################################################################

'##### 작성일자 : 2024-02-23
'##### 수정일자 : 2024-02-23
'##### 수정자   : 박시현
'##### 참고     : 
'##### 설명     : 자재코드 다중 등록을 위한 폼

'############################################################################################################

Imports System.Threading
Imports C1.Win.C1FlexGrid

Public Class frm_Material_Data_Update

    Dim excelApp As Object
    Dim thread_ExcelOpen, thread_ExcelRead As Thread
    Dim priceCol, supplierCol, categoryCol, partCodeCol As Integer
    Dim start_row, last_row As Integer
    Dim lower_firstRow As Integer

    Private Sub frm_Popup_MultiPartsCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        priceCol = 0
        supplierCol = 0
        start_row = 0
        partCodeCol = 0

        Grid_Setting(Grid_ExcelUpper)
        Grid_Setting(Grid_ExcelLower)

        'Load_SheetList()

    End Sub

    Private Sub Grid_Setting(ByVal grid As C1FlexGrid)

        With grid
            .AllowEditing = False
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 21
            .Rows.Count = 11
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = False
            .AutoSizeCols()
            .ShowCursor = False
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
        End With

        For i = 1 To grid.Rows.Count - 1
            grid(i, 0) = i
        Next

        For i = 1 To grid.Cols.Count - 1
            grid(0, i) = i
        Next

        grid.AutoSizeCols()

    End Sub

    Private Sub BTN_FileSelect_Click(sender As Object, e As EventArgs) Handles BTN_FileSelect.Click

        CB_SheetName.Items.Clear()

        If Not IsNothing(excelApp) Then
            excelApp.WorkBooks(1).Close()
            excelApp.Quit()
            ReleaseObject(excelApp)
            excelApp = Nothing
        End If

        Dim openFile As New System.Windows.Forms.OpenFileDialog

        With openFile
            .Filter = "Excel (*.xls, *.xlsx)|*.xls;*.xlsx"
            .AddExtension() = True
        End With

        If openFile.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then Exit Sub

        TB_FileName.Text = openFile.FileName.Split("\")(UBound(openFile.FileName.Split("\")))



        Dim tempFileFolder As String = Application.StartupPath & "\TEMP_FILE"

        '폴더가 없으면 만들기
        If My.Computer.FileSystem.DirectoryExists(tempFileFolder) = False Then
            My.Computer.FileSystem.CreateDirectory(tempFileFolder)
        End If

        '선택한 파일을 임시폴더에 저장
        My.Computer.FileSystem.CopyFile(openFile.FileName, tempFileFolder & "\" & openFile.FileName.Split("\")(UBound(openFile.FileName.Split("\"))), True)

        Load_SheetList()

    End Sub

    Private Sub Load_SheetList()

        excelApp = CreateObject("Excel.Application")
        excelApp.DisplayAlerts = False
        excelApp.WorkBooks.Open(Application.StartupPath & "\TEMP_FILE\" & TB_FileName.Text)
        excelApp.Visible = False

        thread_ExcelOpen = New Thread(AddressOf File_Open)
        thread_ExcelOpen.IsBackground = True
        thread_ExcelOpen.SetApartmentState(ApartmentState.STA) 'OpenFileDialog를 사용하기위해선 STA로 해야되던데...
        thread_ExcelOpen.Name = "ExcelOpen Thread"
        thread_ExcelOpen.Start()

    End Sub

    Private Sub File_Open()

        Thread_LoadingFormStart(Me, "Excel Open...")

        For i = 1 To excelApp.ActiveWorkbook.Sheets.Count
            ComboBoxItemAdd(excelApp.ActiveWorkbook.Sheets(i).Name, Me, CB_SheetName)
        Next

        Thread_LoadingFormEnd()

        MSG_Information(Me, "해당 시트를 선택하여 주십시오.")

    End Sub

    Private Sub CB_SheetName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_SheetName.SelectedIndexChanged

        thread_ExcelRead = New Thread(AddressOf Load_TempData)
        thread_ExcelRead.IsBackground = True
        thread_ExcelRead.SetApartmentState(ApartmentState.STA) 'OpenFileDialog를 사용하기위해선 STA로 해야되던데...
        thread_ExcelRead.Name = "ExcelRead Thread"
        thread_ExcelRead.Start()

    End Sub

    Private Sub Load_TempData()

        Thread_LoadingFormStart(Me, "Excel Open...")

        '상위 표시
        GridRedraw(False, Me, Grid_ExcelUpper)
        Dim sheetName As String = ComboBoxTextReading(Me, CB_SheetName)

        Try
            With excelApp.ActiveWorkbook.Sheets(sheetName)
                For i = 1 To 20
                    For j = 1 To 10
                        GridWriteText(.Cells(j, i).Value, j, i, Me, Grid_ExcelUpper, Color.Black)
                    Next
                Next
            End With

            GridColsAutoSize(Me, Grid_ExcelUpper)
            GridRowsAutoSize(1, Grid_ExcelUpper.Rows.Count - 1, Me, Grid_ExcelUpper)

            GridRedraw(True, Me, Grid_ExcelUpper)
        Catch ex As Exception
            MessageBox.Show(ex.Message,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly)
        End Try

        '하위표시
        GridRedraw(False, Me, Grid_ExcelLower)

        Try
            With excelApp.ActiveWorkbook.Sheets(sheetName)
                Dim grid_row As Integer = 1
                lower_firstRow = .UsedRange.Rows.Count - 1
                For i = .UsedRange.Rows.Count - 1 To .UsedRange.Rows.Count + 8
                    GridWriteText(i, grid_row, 0, Me, Grid_ExcelLower, Color.Black)
                    For j = 1 To 20
                        GridWriteText(.Cells(i, j).Value, grid_row, j, Me, Grid_ExcelLower, Color.Black)
                        'Console.WriteLine("Grid 행 : " & grid_row & ", 열 : " & j & ",   엑셀 행 : " & i & ", 열 : " & j & ",    입력문자 : " & .Cells(i, j).Value)
                    Next
                    grid_row += 1
                Next
            End With


            GridColsAutoSize(Me, Grid_ExcelLower)
            GridRowsAutoSize(1, Grid_ExcelLower.Rows.Count - 1, Me, Grid_ExcelLower)

            GridRedraw(True, Me, Grid_ExcelLower)

            'TextBoxTextUpdate(excelApp.ActiveWorkbook.Sheets(sheetName).UsedRange.Rows.Count, Me, TB_LastRow)
        Catch ex As Exception
            Thread_LoadingFormEnd()
            MSG_Error(Me, ex.Message)
        End Try

        Thread_LoadingFormEnd()

    End Sub

    Private Sub BTN_Start_Click(sender As Object, e As EventArgs) Handles BTN_Start.Click

        If partCodeCol = 0 Or start_row = 0 Or last_row = 0 Then
            MSG_Information(Me, "필수 위치가 선택되지 않았습니다.")
            Exit Sub
        End If

        If priceCol = 0 And supplierCol = 0 And categoryCol = 0 Then
            MSG_Information(Me, "Update 위치가 선택되지 않았습니다.")
            Exit Sub
        End If

        frm_CustomerPartCode.priceCol = priceCol
        frm_CustomerPartCode.categoryCol = categoryCol
        frm_CustomerPartCode.supplierCol = supplierCol
        frm_CustomerPartCode.partCodeCol = partCodeCol
        frm_CustomerPartCode.start_Row = start_row
        frm_CustomerPartCode.last_Row = last_row
        frm_CustomerPartCode.sheetName = CB_SheetName.Text
        frm_CustomerPartCode.fileName = TB_FileName.Text

        DialogResult = DialogResult.OK

        Me.Dispose()

    End Sub

    Private Sub Grid_ExcelUpper_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_ExcelUpper.MouseClick

        If Not e.Button = MouseButtons.Right Then Exit Sub

        Dim selRow As Integer = Grid_ExcelUpper.MouseRow
        Dim selCol As Integer = Grid_ExcelUpper.MouseCol

        If selRow = 0 And selCol > 0 Then
            Grid_ExcelUpper.Select(selRow, selCol)
            CMS_ColumnMenu1.Show(Grid_ExcelUpper, New Point(e.X, e.Y))
        ElseIf selRow > 0 And selCol = 0 Then
            Grid_ExcelUpper.Select(selRow, selCol)
            BTN_LastRow.Enabled = False
            BTN_Start.Enabled = True
            CMS_RowMenu.Show(Grid_ExcelUpper, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub Grid_ExcelLower_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_ExcelLower.MouseClick

        If Not e.Button = MouseButtons.Right Then Exit Sub

        Dim selRow As Integer = Grid_ExcelLower.MouseRow
        Dim selCol As Integer = Grid_ExcelLower.MouseCol

        If selRow > 0 And selCol = 0 Then
            Grid_ExcelLower.Select(selRow, selCol)
            BTN_LastRow.Enabled = True
            BTN_StartRow.Enabled = False
            CMS_RowMenu.Show(Grid_ExcelLower, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub BTN_StartRow_Click(sender As Object, e As EventArgs) Handles BTN_StartRow.Click

        For i = 1 To Grid_ExcelUpper.Rows.Count - 1
            Grid_ExcelUpper(i, 0) = i
        Next

        start_row = Grid_ExcelUpper.Row
        Grid_ExcelUpper(Grid_ExcelUpper.Row, 0) = BTN_StartRow.Text
        Grid_ExcelUpper.AutoSizeCols()

    End Sub

    Private Sub BTN_LastRow_Click(sender As Object, e As EventArgs) Handles BTN_LastRow.Click

        For i = 1 To Grid_ExcelLower.Rows.Count - 1
            Grid_ExcelLower(i, 0) = lower_firstRow
            lower_firstRow += 1
        Next

        last_row = Grid_ExcelLower(Grid_ExcelLower.Row, 0)
        Grid_ExcelLower(Grid_ExcelLower.Row, 0) = BTN_LastRow.Text
        Grid_ExcelLower.AutoSizeCols()

    End Sub

    Private Sub BTN_Ref_Click(sender As Object, e As EventArgs) Handles BTN_Price.Click,
        BTN_Supplier.Click,
        BTN_Category.Click,
        BTN_PartCode.Click

        Dim selName As String = sender.ToString

        For i = 1 To Grid_ExcelUpper.Cols.Count - 1
            If Not IsNumeric(Grid_ExcelUpper(0, i)) Then
                If Grid_ExcelUpper(0, i) = selName Then
                    Grid_ExcelUpper(0, i) = i
                End If
            End If
        Next

        Grid_ExcelUpper(0, Grid_ExcelUpper.Col) = selName
        Grid_ExcelUpper.AutoSizeCols()

        If selName = BTN_Price.Text Then
            priceCol = Grid_ExcelUpper.Col
        ElseIf selName = BTN_Supplier.Text Then
            supplierCol = Grid_ExcelUpper.Col
        ElseIf selName = BTN_Category.Text Then
            categoryCol = Grid_ExcelUpper.Col
        ElseIf selName = BTN_PartCode.Text Then
            partCodeCol = Grid_ExcelUpper.Col
        End If

    End Sub

    Private Sub frm_ExcelModify_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        If Not IsNothing(excelApp) Then
            excelApp.WorkBooks(1).Close()
            excelApp.Quit()
            ReleaseObject(excelApp)
            excelApp = Nothing
        End If

        If Not IsNothing(thread_ExcelRead) Then
            Console.WriteLine("'{0}' Finished...",
                                  thread_ExcelRead.Name)
            thread_ExcelRead.Abort()
            thread_ExcelRead = Nothing
        End If

        If Not IsNothing(thread_ExcelOpen) Then
            Console.WriteLine("'{0}' Finished...",
                                  thread_ExcelOpen.Name)
            thread_ExcelOpen.Abort()
            thread_ExcelOpen = Nothing
        End If

        Me.Dispose()

    End Sub

    Private Sub TB_LastRow_KeyPress(sender As Object, e As KeyPressEventArgs)

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "," Then
            e.Handled = True
        End If

    End Sub
End Class