﻿'############################################################################################################
'############################################################################################################

'##### 작성일자 : 2024-02-23
'##### 수정일자 : 2024-02-23
'##### 수정자   : 박시현
'##### 참고     : 
'##### 설명     : 자재코드 다중 등록을 위한 폼

'############################################################################################################

Imports System.Threading
Imports C1.Win.C1FlexGrid

Public Class frm_ExcelModify

    Dim runProcess As Thread
    Public ref_col, part_col, x_col, y_col, a_col, tb_col As Integer
    Public start_row As Integer
    Public callMode As String

    Private Sub frm_Popup_MultiPartsCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ref_col = 0
        part_col = 0
        start_row = 0

        Grid_Setting()

        Load_SheetList()
        'file_open

    End Sub

    Private Sub Grid_Setting()

        With Grid_Excel
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

        For i = 1 To Grid_Excel.Rows.Count - 1
            Grid_Excel(i, 0) = i
        Next

        For i = 1 To Grid_Excel.Cols.Count - 1
            Grid_Excel(0, i) = i
        Next

        Grid_Excel.AutoSizeCols()

    End Sub

    Private Sub Load_SheetList()

        runProcess = New Thread(AddressOf File_Open)
        runProcess.IsBackground = True
        runProcess.SetApartmentState(ApartmentState.STA) 'OpenFileDialog를 사용하기위해선 STA로 해야되던데...
        runProcess.Start()

    End Sub

    Private Sub File_Open()

        Thread_LoadingFormStart("Excel Open...")

        Dim excelApp As Object
        Dim selectFile As String = Application.StartupPath & "\Temp\" & TB_File_Path.Text

        excelApp = CreateObject("Excel.Application")
        excelApp.WorkBooks.Open(selectFile)
        excelApp.Visible = False
        'Console.WriteLine(TB_File_Path.Text & " : 파일을 열었습니다." & vbCrLf & "시트 목록을 불러 옵니다.")
        'Console.WriteLine("현재 문서의 총 시트 수는 : " & excelApp.ActiveWorkbook.Sheets.Count & "개 입니다.")
        For i = 1 To excelApp.ActiveWorkbook.Sheets.Count
            'Invoke(ComboBox_Item_Add, excelApp.ActiveWorkbook.Sheets(i).Name)
            ComboBoxItemAdd(excelApp.ActiveWorkbook.Sheets(i).Name, Me, CB_SheetName)
        Next
        'Console.WriteLine("모든 시트 이름을 불러 왔습니다.")
        excelApp.WorkBooks(1).Close()
        excelApp.Quit()
        excelApp = Nothing

        Thread_LoadingFormEnd()

        'MessageBox.Show(New Form With {.TopMost = True},
        '                "해당 시트를 선택하여 주십시오.",
        '                msg_form,
        '                MessageBoxButtons.OK,
        '                MessageBoxIcon.Information)

        MessageBox.Show("해당 시트를 선택하여 주십시오.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly)
        'MsgBox("해당 시트를 선택하여 주십시오.", MsgBoxStyle.Information, msg_form)

        runProcess.Abort()

    End Sub

    Private Sub CB_SheetName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_SheetName.SelectedIndexChanged

        runProcess = New Thread(AddressOf Load_TempData)
        runProcess.IsBackground = True
        runProcess.SetApartmentState(ApartmentState.STA) 'OpenFileDialog를 사용하기위해선 STA로 해야되던데...
        runProcess.Start()

    End Sub

    Private Sub Load_TempData()

        Thread_LoadingFormStart("Excel Open...")

        GridRedraw(False, Me, Grid_Excel)

        Dim excelApp As Object
        Dim selectFile As String = Application.StartupPath & "\Temp\" & TB_File_Path.Text

        excelApp = CreateObject("Excel.Application")
        excelApp.WorkBooks.Open(selectFile)

        excelApp.Visible = False

        Try
            Dim sheetName As String = ComboBoxTextReading(Me, CB_SheetName)

            With excelApp.ActiveWorkbook.Sheets(sheetName)
                For i = 1 To 20
                    For j = 1 To 10
                        GridWriteText(.Cells(j, i).Value, j, i, Me, Grid_Excel, Color.Black)
                    Next
                Next
            End With
        Catch ex As Exception
            MessageBox.Show(New Form With {.TopMost = True},
                            ex.Message,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        Finally
            excelApp.WorkBooks(1).Close()
            excelApp.Quit()
            excelApp = Nothing
        End Try

        GridColsAutoSize(Me, Grid_Excel)
        GridRowsAutoSize(1, Grid_Excel.Rows.Count - 1, Me, Grid_Excel)

        GridRedraw(True, Me, Grid_Excel)

        Thread_LoadingFormEnd()

        runProcess.Abort()

    End Sub

    Private Sub BTN_Start_Click(sender As Object, e As EventArgs) Handles BTN_Start.Click

        If callMode = "BOM" Then
            If ref_col = 0 Or part_col = 0 Or start_row = 0 Then
                MessageBox.Show(Me,
                            "해당위치가 선택되지 않았습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
                Exit Sub
            End If
            frm_ModelDocument.ref_col = ref_col
            frm_ModelDocument.part_col = part_col
            frm_ModelDocument.start_row = start_row
            frm_ModelDocument.sheet_name = CB_SheetName.Text
        ElseIf callMode = "Coordinates" Then
            If ref_col = 0 Or x_col = 0 Or y_col = 0 Or a_col = 0 Or tb_col = 0 Or start_row = 0 Then
                MessageBox.Show(Me,
                            "해당위치가 선택되지 않았습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
                Exit Sub
            End If
            frm_ModelDocument.ref_col = ref_col
            frm_ModelDocument.x_col = x_col
            frm_ModelDocument.y_col = y_col
            frm_ModelDocument.a_col = a_col
            frm_ModelDocument.tb_col = tb_col
            frm_ModelDocument.start_row = start_row
            frm_ModelDocument.sheet_name = CB_SheetName.Text
        End If

        DialogResult = DialogResult.OK

    End Sub

    Private Sub Grid_Excel_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_Excel.MouseClick

        If Not e.Button = MouseButtons.Right Then Exit Sub

        Dim selRow As Integer = Grid_Excel.MouseRow
        Dim selCol As Integer = Grid_Excel.MouseCol

        If selRow = 0 And selCol > 0 Then
            Grid_Excel.Select(selRow, selCol)
            If callMode = "BOM" Then
                CMS_ColumnMenu1.Show(Grid_Excel, New Point(e.X, e.Y))
            ElseIf callMode = "Coordinates" Then
                CMS_ColumnMenu2.Show(Grid_Excel, New Point(e.X, e.Y))
            End If
        ElseIf selRow > 0 And selCol = 0 Then
            Grid_Excel.Select(selRow, selCol)
            CMS_RowMenu.Show(Grid_Excel, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub BTN_RowSelect_Click(sender As Object, e As EventArgs) Handles BTN_RowSelect.Click

        For i = 1 To Grid_Excel.Rows.Count - 1
            Grid_Excel(i, 0) = i
        Next

        start_row = Grid_Excel.Row
        Grid_Excel(Grid_Excel.Row, 0) = BTN_RowSelect.Text
        Grid_Excel.AutoSizeCols()

    End Sub

    Private Sub BTN_Ref_Click(sender As Object, e As EventArgs) Handles BTN_Ref1.Click,
        BTN_PartNo.Click,
        BTN_Ref2.Click,
        BTN_X.Click,
        BTN_Y.Click,
        BTN_A.Click,
        BTN_TB.Click

        Dim selName As String = sender.ToString

        For i = 1 To Grid_Excel.Cols.Count - 1
            If Not IsNumeric(Grid_Excel(0, i)) Then
                If Grid_Excel(0, i) = selName Then
                    Grid_Excel(0, i) = i
                End If
            End If
        Next

        Grid_Excel(0, Grid_Excel.Col) = selName
        Grid_Excel.AutoSizeCols()

        If selName = BTN_Ref1.Text Then
            ref_col = Grid_Excel.Col
        ElseIf selName = BTN_PartNo.Text Then
            part_col = Grid_Excel.Col
        ElseIf selName = BTN_Ref2.Text Then
            ref_col = Grid_Excel.Col
        ElseIf selName = BTN_x.Text Then
            x_col = Grid_Excel.Col
        ElseIf selName = BTN_y.Text Then
            y_col = Grid_Excel.Col
        ElseIf selName = BTN_a.Text Then
            a_col = Grid_Excel.Col
        ElseIf selName = BTN_tb.Text Then
            tb_col = Grid_Excel.Col
        End If

    End Sub

    Private Sub frm_ExcelModify_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        If e.CloseReason = 3 Then
            frm_ModelDocument.TabControl1.SelectedIndex = 0
            If callMode = "BOM" Then
                frm_ModelDocument.FileDelete_Ready(1)
            ElseIf callMode = "Coordinates" Then
                frm_ModelDocument.FileDelete_Ready(2)
            End If
        End If

        Me.Dispose()

    End Sub
End Class