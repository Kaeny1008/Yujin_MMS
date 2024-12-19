Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_Material_CheckRequirements2

    Dim excelApp As Object

    Private Sub frm_Material_CheckRequirements2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CB_CustomerName.SelectedIndex = 0

        Grid_Setting()

    End Sub

    Private Sub Grid_Setting()

        With Grid_Excel
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 8
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            '.Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            .AutoClipboard = True
            .ExtendLastCol = False
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
            .DragMode = DragModeEnum.Manual
            .DropMode = DropModeEnum.Manual
        End With

        Grid_Excel(0, 0) = "No"
        Grid_Excel(0, 1) = "납품 요청일자"
        Grid_Excel(0, 2) = "ModelCode"
        Grid_Excel(0, 3) = "품번"
        Grid_Excel(0, 4) = "품명"
        Grid_Excel(0, 5) = "주문량"
        Grid_Excel(0, 6) = "관리번호"
        Grid_Excel(0, 7) = "생산가능"

        Grid_Excel.AutoSizeCols()

    End Sub

    Private Sub BTN_FileSelect_Click(sender As Object, e As EventArgs) Handles BTN_FileSelect.Click

        Dim openFile As New System.Windows.Forms.OpenFileDialog

        With openFile
            .Filter = "Excel (*.xls, *.xlsx)|*.xls;*.xlsx"
            .AddExtension() = True
        End With

        If openFile.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then Exit Sub

        TB_File_Path.Text = openFile.FileName

        Grid_Excel.Redraw = False
        Grid_Excel.Rows.Count = 1
        Grid_Excel.Redraw = True

        CB_SheetName.Enabled = True
        CB_SheetName.Items.Clear()

        Dim sheetList() As String = Grid_Excel.LoadExcelSheetNames(TB_File_Path.Text)

        For i = 0 To sheetList.Count - 1
            CB_SheetName.Items.Add(sheetList(i))
        Next

        MSG_Information(Me, "해당 시트를 선택하여 주십시오.")

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub CB_SheetName_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_SheetName.SelectionChangeCommitted

        frm_Order_Excel_Modify.Label1.Text = "File Name : " & TB_File_Path.Text
        frm_Order_Excel_Modify.fileName = TB_File_Path.Text
        frm_Order_Excel_Modify.Label2.Text = "Sheet Name : " & CB_SheetName.Text
        frm_Order_Excel_Modify.sheetName = CB_SheetName.Text
        If Not frm_Order_Excel_Modify.Visible Then frm_Order_Excel_Modify.Show()
        frm_Order_Excel_Modify.Focus()

    End Sub

    Public Sub Load_ModelCode()

        Thread_LoadingFormStart(Me)

        Grid_Excel.Redraw = False

        Dim totalItemCode As String = String.Empty

        For i = 1 To Grid_Excel.Rows.Count - 1
            If totalItemCode.Equals(String.Empty) Then
                totalItemCode = "'" & Grid_Excel(i, 3) & "'"
            Else
                totalItemCode += ", '" & Grid_Excel(i, 3) & "'"
            End If
        Next

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "select model_code"
        strSQL += ", item_code"
        strSQL += " from tb_model_list"
        strSQL += " where customer_code = '" & TB_CustomerCode.Text & "'"
        strSQL += " and item_code in (" & totalItemCode & ")"
        strSQL += ";"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim now_ItemCode As String = sqlDR("item_code")
            Dim now_ModelCode As String = sqlDR("model_code")

            For i = 1 To Grid_Excel.Rows.Count - 1
                If Grid_Excel(i, 3).Equals(now_ItemCode) Then
                    Grid_Excel(i, 2) = now_ModelCode
                End If
            Next
        Loop
        sqlDR.Close()

        DBClose()

        Grid_Excel.AutoSizeCols()
        Grid_Excel.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Dim orgRow As Integer

    Private Sub Grid_Excel_BeforeMouseDown(sender As Object, e As BeforeMouseDownEventArgs) Handles Grid_Excel.BeforeMouseDown

        Dim hti As HitTestInfo = Grid_Excel.HitTest(e.X, e.Y)
        orgRow = hti.Row
        Grid_Excel.Select(orgRow, 0, orgRow, Grid_Excel.Cols.Count - 1, False)
        Dim dd As DragDropEffects = Grid_Excel.DoDragDrop(Grid_Excel.Clip, DragDropEffects.Move)

    End Sub

    Private Sub Grid_Excel_DragDrop(sender As Object, e As DragEventArgs) Handles Grid_Excel.DragDrop
        Dim pt As Point = Grid_Excel.PointToClient(New Point(e.X, e.Y))
        Dim hti As HitTestInfo = Grid_Excel.HitTest(pt.X, pt.Y)
        Dim index As Integer = hti.Row
        Grid_Excel.Rows.Move(orgRow, index)
    End Sub

    Private Sub Grid_Excel_DragOver(sender As Object, e As DragEventArgs) Handles Grid_Excel.DragOver
        If e.Data.GetDataPresent(GetType(String)) Then
            e.Effect = DragDropEffects.Move
        End If
    End Sub
End Class