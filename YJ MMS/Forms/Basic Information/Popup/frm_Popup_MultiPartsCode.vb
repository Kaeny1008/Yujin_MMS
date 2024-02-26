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

Public Class frm_Popup_MultiPartsCode

    Dim runProcess As Thread

    Private Sub frm_Popup_MultiPartsCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        Load_ExcelColumn()

    End Sub

    Private Sub Grid_Setting()

        With Grid_Excel
            .AllowEditing = False
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 20
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

    Private Sub Load_ExcelColumn()

        TB_StartRow.Text = registryEdit.ReadRegKey("Software\Yujin\MMS\Customer Part Code", "Start Row", 3)
        TB_PartCode.Text = registryEdit.ReadRegKey("Software\Yujin\MMS\Customer Part Code", "Part Code", 4)
        TB_Specification.Text = registryEdit.ReadRegKey("Software\Yujin\MMS\Customer Part Code", "Part Specification", 5)
        TB_Vendor.Text = registryEdit.ReadRegKey("Software\Yujin\MMS\Customer Part Code", "Part Vendor", 6)
        TB_PartCategory.Text = registryEdit.ReadRegKey("Software\Yujin\MMS\Customer Part Code", "Part Category", 7)
        TB_PartType.Text = registryEdit.ReadRegKey("Software\Yujin\MMS\Customer Part Code", "Part Type", 8)

    End Sub

    Private Sub BTN_FileSelect_Click(sender As Object, e As EventArgs) Handles BTN_FileSelect.Click

        Dim openFile As New System.Windows.Forms.OpenFileDialog

        With openFile
            .Filter = "Excel (*.xls, *.xlsx)|*.xls;*.xlsx"
            .AddExtension() = True
        End With

        If openFile.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then Exit Sub

        TB_File_Path.Text = openFile.FileName

        Load_SheetList()

    End Sub

    Private Sub Load_SheetList()

        runProcess = New Thread(AddressOf File_Open)
        runProcess.IsBackground = True
        runProcess.SetApartmentState(ApartmentState.STA) 'OpenFileDialog를 사용하기위해선 STA로 해야되던데...
        runProcess.Start()

    End Sub

    Private Sub File_Open()

        thread_LoadingFormStart("Excel Open...")

        Dim excelApp As Object

        excelApp = CreateObject("Excel.Application")
        excelApp.WorkBooks.Open(TB_File_Path.Text)
        excelApp.Visible = False
        'Console.WriteLine(TB_File_Path.Text & " : 파일을 열었습니다." & vbCrLf & "시트 목록을 불러 옵니다.")
        'Console.WriteLine("현재 문서의 총 시트 수는 : " & excelApp.ActiveWorkbook.Sheets.Count & "개 입니다.")
        For i = 1 To excelApp.ActiveWorkbook.Sheets.Count
            'Invoke(ComboBox_Item_Add, excelApp.ActiveWorkbook.Sheets(i).Name)
            ComboBox_Item_Add(excelApp.ActiveWorkbook.Sheets(i).Name)
        Next
        'Console.WriteLine("모든 시트 이름을 불러 왔습니다.")
        excelApp.WorkBooks(1).Close()
        excelApp.Quit()
        excelApp = Nothing

        thread_LoadingFormEnd()

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

        Invoke(d_FormFocus)
        'Console.WriteLine("스레드를 종료합니다.")
        runProcess.Abort()

    End Sub

    Private Sub CB_SheetName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_SheetName.SelectedIndexChanged

        runProcess = New Thread(AddressOf Load_TempData)
        runProcess.IsBackground = True
        runProcess.SetApartmentState(ApartmentState.STA) 'OpenFileDialog를 사용하기위해선 STA로 해야되던데...
        runProcess.Start()

    End Sub

    Private Sub Load_TempData()

        thread_LoadingFormStart("Excel Open...")

        Invoke(d_GridRedraw, False)

        Dim excelApp As Object

        excelApp = CreateObject("Excel.Application")
        excelApp.WorkBooks.Open(TB_File_Path.Text)

        excelApp.Visible = False

        Try
            Dim sheetName As String = Invoke(d_CB_SheetNameText)

            With excelApp.ActiveWorkbook.Sheets(sheetName)
                For i = 1 To 20
                    For j = 1 To 10
                        WriteTextSafe(.Cells(j, i).Value, j, i)
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

        Invoke(d_GriAutoSize, "Col")
        Invoke(d_GriAutoSize, "Row")

        Invoke(d_GridRedraw, True)

        thread_LoadingFormEnd()

        runProcess.Abort()

    End Sub

    Private Sub WriteTextSafe(ByVal text As String, ByVal row As Integer, ByVal col As Integer)

        If Grid_Excel.InvokeRequired Then
            Invoke(New Action(Of String, Integer, Integer)(AddressOf WriteTextSafe), text, row, col)
        Else
            Grid_Excel(row, col) = text
        End If

    End Sub

    Private Sub ComboBox_Item_Add(ByVal itemName As String)

        If CB_SheetName.InvokeRequired Then
            Invoke(New Action(Of String)(AddressOf ComboBox_Item_Add), itemName)
        Else
            CB_SheetName.Items.Add(itemName)
        End If

    End Sub

    Private Sub BTN_Start_Click(sender As Object, e As EventArgs) Handles BTN_Start.Click

        registryEdit.WriteRegKey("Software\Yujin\MMS\Customer Part Code", "Start Row", TB_StartRow.Text)
        registryEdit.WriteRegKey("Software\Yujin\MMS\Customer Part Code", "Part Code", TB_PartCode.Text)
        registryEdit.WriteRegKey("Software\Yujin\MMS\Customer Part Code", "Part Specification", TB_Specification.Text)
        registryEdit.WriteRegKey("Software\Yujin\MMS\Customer Part Code", "Part Vendor", TB_Vendor.Text)
        registryEdit.WriteRegKey("Software\Yujin\MMS\Customer Part Code", "Part Category", TB_PartCategory.Text)
        registryEdit.WriteRegKey("Software\Yujin\MMS\Customer Part Code", "Part Type", TB_PartType.Text)

        DialogResult = DialogResult.OK
        Me.Hide()

    End Sub

#Region "Delegate"

    Private Delegate Function Sub_CB_SheetNameText()
    Private d_CB_SheetNameText = New Sub_CB_SheetNameText(AddressOf CB_SheetNameText)

    Private Function CB_SheetNameText()

        Return CB_SheetName.Text

    End Function

    Private Delegate Sub Sub_GriAutoSize(ByVal rowcol As String)
    Private d_GriAutoSize = New Sub_GriAutoSize(AddressOf Grid_AutoSizeColRow)

    Private Sub Grid_AutoSizeColRow(ByVal rowcol As String)

        If rowcol.Equals("Row") Then
            Grid_Excel.AutoSizeRows()
        ElseIf rowcol.Equals("Col") Then
            Grid_Excel.AutoSizeCols()
        End If

    End Sub

    Private Delegate Sub Sub_GridRedraw(ByVal status As Boolean)
    Private d_GridRedraw = New Sub_GridRedraw(AddressOf GridRedraw)

    Private Sub GridRedraw(ByVal status As Boolean)

        Grid_Excel.Redraw = status

    End Sub

    Private Delegate Sub Sub_FormFocus()
    Private d_FormFocus = New Sub_FormFocus(AddressOf Focus)

    'Private Delegate Sub Sub_ComboboxItemAdd(ByVal itemName As String)
    'Private d_ComboboxItemAdd = New Sub_ComboboxItemAdd(AddressOf ComboBox_Item_Add)

    'Private Sub ComboBox_Item_Add(ByVal itemName As String)

    '    CB_SheetName.Items.Add(itemName)

    'End Sub

    'Private Delegate Sub Sub_MsgBox(ByVal textString As String, ByVal msgButton As MessageBoxButtons, ByVal msgICon As MessageBoxIcon)
    'Private d_MsgBox = New Sub_MsgBox(AddressOf MsgShow)

    'Private Sub MsgShow(ByVal textString As String, ByVal msgButton As MessageBoxButtons, ByVal msgICon As MessageBoxIcon)

    '    MessageBox.Show(New Form With {.TopMost = True},
    '                    textString,
    '                    msg_form,
    '                    msgButton,
    '                    msgICon)

    'End Sub

    'Private Delegate Sub Sub_LodingFormStart(ByVal loadingString As String)
    'Private d_LodingFormStart = New Sub_LodingFormStart(AddressOf thread_LoadingFormStart)
    'Private Delegate Sub Sub_LodingFormEnd()
    'Private d_LodingFormEnd = New Sub_LodingFormEnd(AddressOf thread_LoadingFormEnd)
#End Region
End Class