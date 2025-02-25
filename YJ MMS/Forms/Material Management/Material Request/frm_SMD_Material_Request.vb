Imports System.Threading
Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_SMD_Material_Request
    Private Sub frm_SMD_Material_Request_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CB_S_Status.SelectedIndex = 0

        Grid_Setting()

    End Sub

    Private Sub Grid_Setting()

        With Grid_RequestList
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
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            '.Cols(.Cols.Count - 1).StyleNew.TextAlign = TextAlignEnum.LeftCenter
            .ExtendLastCol = False
            .AutoSizeCols()
            .ShowCursor = True
            .ShowCellLabels = True '마우스 커서가 셀 위로 올라가면 셀 내용을 라벨로 보여준다.(Trimming일 때)
            .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '글자 수가 넓이보다 크면 ...으로 표시
            .Styles.Fixed.Trimming = StringTrimming.None '위 기능을 사용하지 않도록 한다.
        End With

        Grid_RequestList(0, 0) = "No"
        Grid_RequestList(0, 1) = "요청번호"
        Grid_RequestList(0, 2) = "주문번호"
        Grid_RequestList(0, 3) = "품번"
        Grid_RequestList(0, 4) = "완료"
        Grid_RequestList.AutoSizeCols()

        With Grid_MaterialList
            .AllowEditing = False
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 4
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
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
        End With

        Grid_MaterialList(0, 0) = "No"
        Grid_MaterialList(0, 1) = "작업면"
        Grid_MaterialList(0, 2) = "자재코드"
        Grid_MaterialList(0, 3) = "상태"
        Grid_MaterialList.AutoSizeCols()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Public Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        Thread_LoadingFormStart(Me)

        Grid_MaterialList.Rows.Count = 1
        TB_OrderIndex.Text = String.Empty
        TB_ItemCode.Text = String.Empty
        TextBox1.Text = String.Empty

        Grid_RequestList.Redraw = False
        Grid_RequestList.Rows.Count = 1

        If DBConnect() = False Then
            Thread_LoadingFormEnd()
            Exit Sub
        End If

        Dim strSQL As String = "call sp_mms_smd_material_request(0"
        strSQL += ", '" & TB_S_OrderIndex.Text & "'"
        strSQL += ", '" & TB_S_ItemCode.Text & "'"
        strSQL += ", '" & CB_S_Status.Text & "'"
        strSQL += ", null"
        strSQL += ", '" & TB_S_RequestNo.Text & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_RequestList.Rows.Count & vbTab &
                                          sqlDR("require_no") & vbTab &
                                          sqlDR("order_index") & vbTab &
                                          sqlDR("item_code") & vbTab &
                                          sqlDR("require_status")
            GridWriteText(insert_String, Me, Grid_RequestList, Color.Black)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_RequestList.AutoSizeCols()
        Grid_RequestList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Private Sub Grid_RequestList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Grid_RequestList.MouseDoubleClick

        Dim selRow As Integer = Grid_RequestList.MouseRow

        If selRow > 0 And e.Button = MouseButtons.Left Then
            Dim requestNo As String = Grid_RequestList(selRow, 1)
            Dim orderIndex As String = Grid_RequestList(selRow, 2)
            Dim itemCode As String = Grid_RequestList(selRow, 3)
            Dim requestStatus As String = Grid_RequestList(selRow, 4)

            TextBox1.Text = requestNo
            TB_OrderIndex.Text = orderIndex
            TB_ItemCode.Text = itemCode
            OrderQuantity_Load(orderIndex)
            DetailLoad(requestNo)

            BTN_ExcelConvert.Enabled = True
            If requestStatus.Equals("미완료") Then
                BTN_RequestCompleted.Enabled = True
            Else
                BTN_RequestCompleted.Enabled = False
            End If
        End If

    End Sub

    Private Sub OrderQuantity_Load(ByVal orderIndex As String)

        Thread_LoadingFormStart(Me)

        If DBConnect() = False Then
            Thread_LoadingFormEnd()
            Exit Sub
        End If

        Dim strSQL As String = "call sp_mms_smd_material_request(2"
        strSQL += ", '" & orderIndex & "'"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TextBox2.Text = Format(sqlDR("modify_order_quantity"), "#,##0")
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

    End Sub

    Private Sub DetailLoad(ByVal requestNo As String)

        Thread_LoadingFormStart(Me)

        Grid_MaterialList.Redraw = False
        Grid_MaterialList.Rows.Count = 1

        If DBConnect() = False Then
            Thread_LoadingFormEnd()
            Exit Sub
        End If

        Dim strSQL As String = "call sp_mms_smd_material_request(1"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", null"
        strSQL += ", '" & requestNo & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_MaterialList.Rows.Count & vbTab &
                                          sqlDR("work_side") & vbTab &
                                          sqlDR("part_code") & vbTab &
                                          sqlDR("detail_status")
            GridWriteText(insert_String, Me, Grid_MaterialList, Color.Black)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_MaterialList.AutoSizeCols()
        Grid_MaterialList.Redraw = True

        Thread_LoadingFormEnd()

    End Sub

    Dim runProcess As Thread

    Private Sub BTN_ExcelConvert_Click(sender As Object, e As EventArgs) Handles BTN_ExcelConvert.Click

        runProcess = New Thread(AddressOf Excel_Write)
        runProcess.IsBackground = True
        runProcess.SetApartmentState(ApartmentState.STA) 'OpenFileDialog를 사용하기위해선 STA로 해야되던데...
        runProcess.Start()

    End Sub

    Private Sub Excel_Write()

        MSG_Information(Me, "전환 작업을 시작합니다." & vbCrLf & "잠시만 기다려 주십시오.")

        Dim orgFile As String = Application.StartupPath & "\Reports\SMD_Material_Request.xlsx"
        Dim newFile As String = Application.StartupPath & "\Temp\SMD_Material_Request_" & TextBox1.Text & ".xlsx"

        Try
            If System.IO.Directory.Exists(Application.StartupPath & "\Temp") = False Then
                System.IO.Directory.CreateDirectory(Application.StartupPath & "\Temp")
            End If
            System.IO.File.Copy(orgFile, newFile, True)
        Catch ex As Exception
            If Err.Number = 53 Then
                MSG_Error(Me, "원본 파일을 찾을 수 없습니다.")
            Else
                MSG_Error(Me, ex.Message)
            End If
            Exit Sub
        End Try

        Dim XlApp As Object = CreateObject("Excel.Application")
        XlApp.Workbooks.Open(newFile)
        XlApp.Visible = False
        'XlApp.DisplayAlerts = False
        'XlApp.ActiveWorkbook.Sheets("Lot별 재고현황").Delete '지난 시트를 삭제 한다.
        'XlApp.ActiveWorkbook.Sheets("Lot별 재고현황_SAMPLE").Copy(after:=XlApp.ActiveWorkbook.Sheets(1)) '시트를 복사한뒤
        'XlApp.ActiveWorkbook.Sheets(2).Name = "Lot별 재고현황" '이름을 바꿔준다.
        'XlApp.DisplayAlerts = True

        With XlApp.ActiveWorkbook.Sheets("Sheet1")
            '기본정보 입력
            .Cells(3, 3) = "*" & TextBox1.Text & "*"
            .Cells(4, 3) = TB_OrderIndex.Text
            .Cells(5, 3) = TB_ItemCode.Text & " ( 주문수량 : " & Format(CDbl(TextBox2.Text), "#,##0") & " )"

            Dim firstRow As Integer = 8

            Dim totalRow As Integer = Grid_MaterialList.Rows.Count - 1
            Dim vipectus_width As Integer = Math.Ceiling(totalRow / 36) * 3 - 1 '세로의 길이가 최고36
            Dim vipectus_height As Integer = 71
            Dim vipectus(vipectus_height, vipectus_width) As String
            Dim workSideCol As Integer = 0 '처음시작하는 Col No.
            Dim partCodeCol As Integer = workSideCol + 1
            Dim checkCol As Integer = workSideCol + 2
            Dim insertRow As Integer = 0
            Dim nextWorking As Boolean = False

            For i = 1 To totalRow
                vipectus(insertRow, workSideCol) = Trim(Grid_MaterialList(i, 1))
                vipectus(insertRow, partCodeCol) = Trim(Grid_MaterialList(i, 2))
                vipectus(insertRow, checkCol) = String.Empty
                insertRow += 1
                If (i Mod 36) = 0 Then
                    workSideCol += 3
                    partCodeCol += 3
                    checkCol += 3
                    insertRow = 0
                    If checkCol > 8 Then
                        nextWorking = True
                        Exit For
                    End If
                End If
            Next

            If nextWorking = True Then
                workSideCol = 0
                partCodeCol = 1
                checkCol = 2
                insertRow = 36
                For i = 109 To totalRow
                    vipectus(insertRow, workSideCol) = Trim(Grid_MaterialList(i, 1))
                    vipectus(insertRow, partCodeCol) = Trim(Grid_MaterialList(i, 2))
                    vipectus(insertRow, checkCol) = String.Empty
                    insertRow += 1
                    If (i Mod 36) = 0 Then
                        workSideCol += 3
                        partCodeCol += 3
                        checkCol += 3
                        insertRow = 0
                        If checkCol > 8 Then
                            nextWorking = True
                            Exit For
                        End If
                    End If
                Next
            End If

            .Range(.Cells(firstRow, 1), .Cells(firstRow + 71, 9)) = vipectus '값입력

            For i = firstRow To firstRow + 71
                For j = 1 To 9
                    'Console.WriteLine(CStr(.Cells(i, j).Value))
                    If CStr(.Cells(i, j).Value) = "-2146826246" Then
                        .Cells(i, j) = String.Empty
                    End If
                Next
            Next

            If totalRow < 109 Then
                '실제 삽입되지 않은 행은 삭제 할것.
                .Range(.Cells(44, 1), .Cells(90, 9)).EntireRow.Delete
            End If
        End With

        XlApp.Activeworkbook.Save
        XlApp.Workbooks(1).Close()
        XlApp.Quit()
        XlApp = Nothing

        MSG_Information(Me, "전환이 완료 되었습니다." & vbCrLf & "Excel이 자동으로 실행됩니다.")

        Process.Start(newFile)
        runProcess.Abort()

    End Sub

    Private Sub TB_S_RequestNo_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_S_RequestNo.KeyDown

        If Not TB_S_RequestNo.Text.Equals(String.Empty) And e.KeyCode = 13 Then
            BTN_Search_Click(Nothing, Nothing)
            TB_S_RequestNo.Text = String.Empty
        End If

    End Sub

    Private Sub BTN_RequestCompleted_Click(sender As Object, e As EventArgs) Handles BTN_RequestCompleted.Click

        If MSG_Question(Me, "요청번호를 출고 완료 하시겠습니까?") = False Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        If DBConnect() = False Then Exit Sub

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try

            strSQL += "update tb_mms_smd_production_material_require_list"
            strSQL += " set require_status = 'Completed'"
            strSQL += " where require_no = '" & TextBox1.Text & "';"

            If Not strSQL = String.Empty Then
                sqlCmd = New MySqlCommand(strSQL, dbConnection1)
                sqlCmd.Transaction = sqlTran
                sqlCmd.ExecuteNonQuery()

                sqlTran.Commit()
            End If
        Catch ex As MySqlException
            sqlTran.Rollback()

            DBClose()

            Thread_LoadingFormEnd()

            MSG_Error(Me, ex.Message)
            Exit Sub
        End Try

        Try
            Dim newFile As String = Application.StartupPath & "\Temp\SMD_Material_Request_" & TextBox1.Text & ".xlsx"
            System.IO.File.Delete(newFile)
        Catch ex As Exception
            MSG_Error(Me, ex.Message & vbCrLf & "파일은 삭제 하지 못하였지만 출고완료 처리하였습니다.")
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        BTN_Search_Click(Nothing, Nothing)

    End Sub
End Class