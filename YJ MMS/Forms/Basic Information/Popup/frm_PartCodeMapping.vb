Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_PartCodeMapping

    Dim informationChange As Boolean

    Private Sub frm_PartCodeMapping_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        informationChange = False

        Grid_Setting()

        Dim vendorList As String = Trim(TB_Vendor.Text)
        vendorList = vendorList.Replace("/", "|")
        'vendorList = vendorList.Replace(" ", "|") '현재 확인결과 띄워쓰기가 되어 있는 제조사 이름이 있음.
        vendorList = vendorList.Replace(",", "|")

        Grid_PartList.Cols(2).ComboList = vendorList

        Load_List()

    End Sub

    Private Sub frm_PartCodeMapping_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If informationChange = False Then
            '사용자가 임의로 폼을 닫았을 경우
            Me.DialogResult = DialogResult.No
        Else
            Me.DialogResult = DialogResult.Yes
        End If

    End Sub

    Private Sub Grid_Setting()

        With Grid_PartList
            .AllowEditing = True
            .AllowFiltering = True
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 6
            .Cols.Fixed = 1
            .Rows.Fixed = 1
            .Rows.Count = 1
            Grid_PartList(0, 0) = "No"
            Grid_PartList(0, 1) = "SubCode"
            Grid_PartList(0, 2) = "Vendor"
            Grid_PartList(0, 3) = "Part No."
            Grid_PartList(0, 4) = "실제바코드 스캔위치"
            Grid_PartList(0, 5) = "비고"
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

    End Sub

    Dim before_Data As String

    Private Sub Grid_PartList_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Grid_PartList.BeforeEdit

        before_Data = Grid_PartList(e.Row, e.Col)

    End Sub

    Private Sub Grid_PartList_AfterEdit(sender As Object, e As RowColEventArgs) Handles Grid_PartList.AfterEdit

        If Grid_PartList(e.Row, 0).Equals("D") Then Exit Sub

        If before_Data = Grid_PartList(e.Row, e.Col) Then Exit Sub

        Grid_PartList.Redraw = False

        If IsNumeric(Grid_PartList(e.Row, 0)) Then
            Grid_PartList(e.Row, 0) = "M"
        End If

        Dim cs As CellStyle = Grid_PartList.Styles.Add("st_Red")
        cs.BackColor = Color.Yellow
        cs.ForeColor = Color.Red

        Grid_PartList.SetCellStyle(e.Row, e.Col, cs)

        Select Case e.Col
            Case 4
                If Grid_PartList(e.Row, 2) = String.Empty Then
                    Dim cs2 As CellStyle = Grid_PartList.Styles.Add("st_Normal")
                    cs.BackColor = Color.White
                    cs.ForeColor = Color.Black
                    Grid_PartList.SetCellStyle(e.Row, e.Col, cs2)
                    MessageBox.Show(Me,
                                    "Vendor를 먼저 선택하여 주십시오.",
                                    msg_form,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
                    e.Cancel = True
                Else
                    Dim splitResult As String = Load_PHP(phpUrl & phpRootFolder &
                                                         "/barcodesplit.php?barcode=" &
                                                         Grid_PartList(e.Row, 4) &
                                                         "&maker=" &
                                                         Grid_PartList(e.Row, 2),
                                                         "BarcodeSplitResult",
                                                         "returnStr")

                    If splitResult.Split("!@")(0) = "Success" Then
                        Dim resultSplit() As String = splitResult.Split("!@")
                        Dim partNo As String = resultSplit(1).Replace("@P:", String.Empty)
                        Dim lotNo As String = resultSplit(2).Replace("@L:", String.Empty)
                        Dim qty As String = resultSplit(3).Replace("@Q:", String.Empty)
                        Dim org As String = resultSplit(4).Replace("@ORG:", String.Empty)

                        'Console.WriteLine(partNo)
                        'Console.WriteLine(lotNo)
                        'Console.WriteLine(qty)
                        'Console.WriteLine(org)

                        If org = String.Empty Then
                            Grid_PartList(e.Row, 3) = partNo
                        Else
                            Grid_PartList(e.Row, 3) = org
                        End If
                    Else
                        MessageBox.Show(Me,
                                        splitResult.Split("!@")(1),
                                        msg_form,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error)
                    End If
                End If
            Case Else
                Grid_PartList.AutoSizeCols()
        End Select

        Grid_PartList.Redraw = True

    End Sub

    Private Sub Grid_PartList_RowColChange(sender As Object, e As EventArgs) Handles Grid_PartList.RowColChange

        Select Case Grid_PartList.Col
            Case 1
                Grid_PartList.AllowEditing = False
            Case Else
                Grid_PartList.AllowEditing = True
        End Select

    End Sub

    Private Sub Load_List()

        Grid_PartList.Redraw = False
        Grid_PartList.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_customer_part_code(1"
        strSQL += ",'" & TB_CustomerCode.Text & "'"
        strSQL += ",'" & TB_PartCode.Text & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_PartList.Rows.Count & vbTab &
                                          sqlDR("part_subcode") & vbTab &
                                          sqlDR("part_vendor") & vbTab &
                                          sqlDR("part_no") & vbTab &
                                          sqlDR("part_org") & vbTab &
                                          sqlDR("mapping_note")
            Grid_PartList.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_PartList.AutoSizeCols()
        Grid_PartList.Redraw = True

    End Sub

    Private Sub BTN_NewParts_Click(sender As Object, e As EventArgs) Handles BTN_NewParts.Click

        Grid_PartList.Redraw = False

        Grid_PartList.AddItem("N" & vbTab & Format(Now, "yyMMddHHmmssfff"), Grid_PartList.Row + 1)
        Grid_PartList.Rows(Grid_PartList.Rows.Count - 1).StyleNew.ForeColor = Color.Blue
        Grid_PartList.Select(Grid_PartList.Row, 2)

        Grid_PartList.AutoSizeCols()
        Grid_PartList.Redraw = True

    End Sub

    Private Sub Grid_PartList_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_PartList.MouseClick

        Dim selRow As Integer = Grid_PartList.MouseRow
        Grid_PartList.Row = selRow

        If e.Button = MouseButtons.Right And selRow > -1 Then
            cms_Menu.Show(Grid_PartList, New Point(e.X, e.Y))
        End If

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        If MsgBox("저장 하시겠습니까?",
                  MsgBoxStyle.Question + MsgBoxStyle.YesNo,
                  msg_form) = MsgBoxResult.No Then Exit Sub

        Thread_LoadingFormStart("Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            For i = 1 To Grid_PartList.Rows.Count - 1
                If Grid_PartList(i, 0).ToString = "N" Then
                    strSQL += "insert into tb_mms_part_mapping("
                    strSQL += "part_subcode, customer_code, part_code"
                    strSQL += ", part_vendor, part_no, part_org, mapping_note, write_date, write_id"
                    strSQL += ") values("
                    strSQL += "'" & Replace(Grid_PartList(i, 1), "'", "\'") & "'"
                    strSQL += ",'" & TB_CustomerCode.Text & "'"
                    strSQL += ",'" & TB_PartCode.Text & "'"
                    strSQL += ", '" & Replace(Grid_PartList(i, 2), "'", "\'") & "'"
                    strSQL += ", '" & Replace(Grid_PartList(i, 3), "'", "\'") & "'"
                    strSQL += ", '" & Replace(Grid_PartList(i, 4), "'", "\'") & "'"
                    strSQL += ", '" & Replace(Grid_PartList(i, 5), "'", "\'") & "'"
                    strSQL += ", '" & writeDate & "'"
                    strSQL += ", '" & loginID & "');"
                ElseIf Grid_PartList(i, 0).ToString = "M" Then
                    strSQL += "update tb_mms_part_mapping set"
                    strSQL += " part_vendor = '" & Replace(Grid_PartList(i, 2), "'", "\'") & "'"
                    strSQL += ", part_no = '" & Replace(Grid_PartList(i, 3), "'", "\'") & "'"
                    strSQL += ", part_org = '" & Replace(Grid_PartList(i, 4), "'", "\'") & "'"
                    strSQL += ", mapping_note = '" & Replace(Grid_PartList(i, 5), "'", "\'") & "'"
                    strSQL += ", write_date = '" & writeDate & "'"
                    strSQL += ", write_id = '" & loginID & "'"
                    strSQL += " where part_subcode = '" & Grid_PartList(i, 1) & "';"
                ElseIf Grid_PartList(i, 0).ToString = "D" Then
                    strSQL += "delete from tb_mms_part_mapping"
                    strSQL += " where part_subcode = '" & Grid_PartList(i, 1) & "';"
                End If
            Next

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
            MessageBox.Show(ex.Message & vbCrLf & "Error No. : " & ex.Number,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

        DBClose()

        Thread_LoadingFormEnd()

        Load_List()

        MessageBox.Show("저장 완료.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly)

        informationChange = True

    End Sub

    Private Sub BTN_RowDelete_Click(sender As Object, e As EventArgs) Handles BTN_RowDelete.Click

        Dim sel_Row As Integer = Grid_PartList.Row

        If Grid_PartList(sel_Row, 0).ToString = "N" Then
            Grid_PartList.RemoveItem(sel_Row)
        Else
            Grid_PartList(sel_Row, 0) = "D"
            Grid_PartList.Rows(sel_Row).StyleNew.ForeColor = Color.LightGray
        End If

    End Sub
End Class