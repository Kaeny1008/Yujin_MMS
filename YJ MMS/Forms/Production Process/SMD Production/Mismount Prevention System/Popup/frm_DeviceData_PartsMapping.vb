Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_DeviceData_PartsMapping

    Dim form_Msgbox_String As String = "대치자재 관리"
    Public ddMainCode As String

    Private Sub DeviceData_Sub_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GridSetting()

        Data_Load()

    End Sub

    Private Sub GridSetting()

        With Grid_DeviceData
            .AllowEditing = True
            .AllowFiltering = True
            .AutoClipboard = True
            .AllowSorting = AllowSortingEnum.None
            .Rows(0).Height = 30
            .Rows.DefaultSize = 20
            .Cols.Count = 6
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            Grid_DeviceData(0, 0) = "No"
            Grid_DeviceData(0, 1) = "Code"
            Grid_DeviceData(0, 2) = "Vendor"
            Grid_DeviceData(0, 3) = "Part No."
            Grid_DeviceData(0, 4) = "실제바코드 스캔위치"
            Grid_DeviceData(0, 5) = "비고"
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .Cols(.Cols.Count - 1).TextAlign = TextAlignEnum.LeftCenter
            .Cols(2).ComboList = Maker_List()
            .AutoSizeCols()
            .ExtendLastCol = True
        End With

    End Sub

    Private Sub Data_Load()

        'DBConnect()

        'Grid_DeviceData.Redraw = False
        'Grid_DeviceData.Rows.Count = 1

        'Dim strSQL As String = String.Empty
        'strSQL = "select ds_code, part_maker, part_no, ds_note from tb_mmps_device_data_sub2"
        'strSQL += " where main_part_no = '" & Tb_mainParts.Text & "' and customer = '" & Tb_Customer.Text & "' order by part_no"

        'Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        'Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        'Do While sqlDR.Read
        '    Dim insert_string As String = Grid_DeviceData.Rows.Count & vbTab &
        '                                      sqlDR("ds_code") & vbTab &
        '                                      sqlDR("part_maker") & vbTab &
        '                                      sqlDR("part_no") & vbTab &
        '                                      vbTab &
        '                                      sqlDR("ds_note")
        '    Grid_DeviceData.AddItem(insert_string)
        'Loop
        'sqlDR.Close()

        'If Grid_DeviceData.Rows.Count = 1 Then
        '    Grid_DeviceData.AddItem("N" & vbTab & NEW_Code())
        '    Grid_DeviceData.Rows(1).StyleNew.ForeColor = Color.Blue
        'End If

        'Grid_DeviceData.AutoSizeCols()
        'Grid_DeviceData.Redraw = True

        'DBClose()

        Grid_DeviceData.Redraw = False
        Grid_DeviceData.Rows.Count = 1

        DBConnect()

        Dim strSQL As String = "call sp_mms_customer_part_code(1"
        strSQL += ",'" & TB_CustomerCode.Text & "'"
        strSQL += ",'" & TB_PartCode.Text & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_DeviceData.Rows.Count & vbTab &
                                          sqlDR("part_subcode") & vbTab &
                                          sqlDR("part_vendor") & vbTab &
                                          sqlDR("part_no") & vbTab &
                                          sqlDR("part_org") & vbTab &
                                          sqlDR("mapping_note")
            Grid_DeviceData.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_DeviceData.AutoSizeCols()
        Grid_DeviceData.Redraw = True

    End Sub

    Private Sub Grid_DeviceData_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid_DeviceData.MouseClick

        Dim row As Integer = Grid_DeviceData.MouseRow

        If e.Button = MouseButtons.Right And row > -1 Then
            BTN_deleteLine.Enabled = True
            BTN_Save.Enabled = True
            If row = 0 Then
                BTN_deleteLine.Enabled = False
                BTN_Save.Enabled = False
            Else
                If Grid_DeviceData(row, 0).ToString = "D" Then
                    BTN_deleteLine.Text = "삭제취소"
                Else
                    BTN_deleteLine.Text = "삭제"
                End If
            End If
            Grid_DeviceData.Row = row
            CMS_gridMenu.Show(Grid_DeviceData, New Point(e.X, e.Y))
        End If

    End Sub

    Private Function NEW_Code() As String

        Dim newCode As String = String.Empty

        DBConnect()

        Dim strSQL As String = "select ds_code from tb_mmps_device_data_sub2 order by ds_code desc limit 1"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            newCode = sqlDR("ds_code")
        Loop
        sqlDR.Close()

        DBClose()

        If newCode = String.Empty Then
            newCode = "DS00000001"
        Else
            newCode = "DS" & Format(CInt(newCode.Substring(2, 8)) + 1, "00000000")
        End If

        Dim last_code() As Integer = {}
        ReDim last_code(Grid_DeviceData.Rows.Count - 1)

        For i = 1 To Grid_DeviceData.Rows.Count - 1
            last_code(i) = Grid_DeviceData(i, 1).ToString.Substring(2, 8)
        Next

        If Not last_code.Length = 0 Then
            Dim first_code As String = newCode.Substring(0, 2)
            Dim second_code As Integer = newCode.Substring(2, 8)
            If second_code <= last_code.Max Then
                newCode = first_code + Format(last_code.Max + 1, "00000000")
            End If
        End If

        Return newCode

    End Function

    Private Sub BTN_newLine_Click(sender As Object, e As EventArgs) Handles BTN_newLine.Click

        Dim insertRow As Integer = 0
        If Grid_DeviceData.Row < 1 Then
            insertRow = 1
        Else
            insertRow = Grid_DeviceData.Row + 1
        End If

        Grid_DeviceData.Redraw = False

        Grid_DeviceData.AddItem("N" & vbTab & NEW_Code(), insertRow)
        Grid_DeviceData.Rows(insertRow).StyleNew.ForeColor = Color.Blue

        Grid_DeviceData.AutoSizeCols()

        Grid_DeviceData.Redraw = True

    End Sub

    Private Sub BTN_deleteLine_Click(sender As Object, e As EventArgs) Handles BTN_deleteLine.Click

        Dim row As Integer = Grid_DeviceData.Row

        If Grid_DeviceData(row, 0).ToString = "D" Then
            Grid_DeviceData.Rows(row).StyleNew.ForeColor = Color.Black
            Grid_DeviceData(row, 0) = row
        ElseIf Grid_DeviceData(row, 0).ToString = "N" Then
            Grid_DeviceData.Rows.Remove(row)
        Else
            Grid_DeviceData(row, 0) = "D"
            Grid_DeviceData.Rows(row).StyleNew.ForeColor = Color.DarkGray
        End If

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        'If MsgBox("저장 하시겠습니까?",
        '          MsgBoxStyle.Question + MsgBoxStyle.YesNo,
        '          form_Msgbox_String) = MsgBoxResult.No Then Exit Sub

        'DBConnect()

        'Dim sqlTran As MySqlTransaction
        'Dim sqlCmd As MySqlCommand
        'Dim strSQL As String = String.Empty

        'sqlTran = dbConnection1.BeginTransaction

        'Try
        '    Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

        '    For i = 1 To Grid_DeviceData.Rows.Count - 1
        '        If Grid_DeviceData(i, 0).ToString = "N" Then
        '            strSQL += "Insert Into tb_mmps_device_data_sub2("
        '            strSQL += "ds_code, CUSTOMER, main_part_maker, main_part_no, part_maker, part_no, ds_note"
        '            strSQL += ") values("
        '            strSQL += "'" & Grid_DeviceData(i, 1) & "'"
        '            strSQL += ",'" & Tb_Customer.Text & "'"
        '            strSQL += ",'" & TB_mainParts_Maker.Text & "'"
        '            strSQL += ",'" & TB_PartCode.Text & "'"
        '            strSQL += ",'" & Grid_DeviceData(i, 2) & "'"
        '            strSQL += ",'" & Grid_DeviceData(i, 3) & "'"
        '            strSQL += ",'" & Grid_DeviceData(i, 5) & "');"
        '        ElseIf Grid_DeviceData(i, 0).ToString = "M" Then
        '            strSQL += "update tb_mmps_device_data_sub2 set"
        '            strSQL += " part_maker = '" & Grid_DeviceData(i, 2) & "'"
        '            strSQL += ", part_no = '" & Grid_DeviceData(i, 3) & "'"
        '            strSQL += ", ds_note = '" & Grid_DeviceData(i, 5) & "'"
        '            strSQL += " where ds_code = '" & Grid_DeviceData(i, 1) & "'"
        '            strSQL += " and customer = '" & Tb_Customer.Text & "';"
        '        ElseIf Grid_DeviceData(i, 0).ToString = "D" Then
        '            strSQL += "delete from tb_mmps_device_data_sub2"
        '            strSQL += " where ds_code = '" & Grid_DeviceData(i, 1) & "'"
        '            strSQL += " and customer = '" & Tb_Customer.Text & "';"
        '        End If
        '    Next

        '    If Not strSQL = String.Empty Then
        '        sqlCmd = New MySqlCommand(strSQL, dbConnection1)
        '        sqlCmd.Transaction = sqlTran
        '        sqlCmd.ExecuteNonQuery()

        '        sqlTran.Commit()
        '    End If
        'Catch ex As MySqlException
        '    sqlTran.Rollback()
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, form_Msgbox_String)
        '    Exit Sub
        'End Try

        'DBClose()

        'MsgBox("저장완료.", MsgBoxStyle.Information, form_Msgbox_String)

        'Data_Load()

        If MsgBox("저장 하시겠습니까?",
                  MsgBoxStyle.Question + MsgBoxStyle.YesNo,
                  msg_form) = MsgBoxResult.No Then Exit Sub

        Thread_LoadingFormStart(Me, "Saving...")

        DBConnect()

        Dim sqlTran As MySqlTransaction
        Dim sqlCmd As MySqlCommand
        Dim strSQL As String = String.Empty

        sqlTran = dbConnection1.BeginTransaction

        Try
            Dim writeDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            For i = 1 To Grid_DeviceData.Rows.Count - 1
                If Grid_DeviceData(i, 0).ToString = "N" Then
                    strSQL += "insert into tb_mms_part_mapping("
                    strSQL += "part_subcode, customer_code, part_code"
                    strSQL += ", part_vendor, part_no, part_org, mapping_note, write_date, write_id"
                    strSQL += ") values("
                    strSQL += "'" & Replace(Grid_DeviceData(i, 1), "'", "\'") & "'"
                    strSQL += ",'" & TB_CustomerCode.Text & "'"
                    strSQL += ",'" & TB_PartCode.Text & "'"
                    strSQL += ", '" & Replace(Grid_DeviceData(i, 2), "'", "\'") & "'"
                    strSQL += ", '" & Replace(Grid_DeviceData(i, 3), "'", "\'") & "'"
                    strSQL += ", '" & Replace(Grid_DeviceData(i, 4), "'", "\'") & "'"
                    strSQL += ", '" & Replace(Grid_DeviceData(i, 5), "'", "\'") & "'"
                    strSQL += ", '" & writeDate & "'"
                    strSQL += ", '" & loginID & "');"
                ElseIf Grid_DeviceData(i, 0).ToString = "M" Then
                    strSQL += "update tb_mms_part_mapping set"
                    strSQL += " part_vendor = '" & Replace(Grid_DeviceData(i, 2), "'", "\'") & "'"
                    strSQL += ", part_no = '" & Replace(Grid_DeviceData(i, 3), "'", "\'") & "'"
                    strSQL += ", part_org = '" & Replace(Grid_DeviceData(i, 4), "'", "\'") & "'"
                    strSQL += ", mapping_note = '" & Replace(Grid_DeviceData(i, 5), "'", "\'") & "'"
                    strSQL += ", write_date = '" & writeDate & "'"
                    strSQL += ", write_id = '" & loginID & "'"
                    strSQL += " where part_subcode = '" & Grid_DeviceData(i, 1) & "';"
                ElseIf Grid_DeviceData(i, 0).ToString = "D" Then
                    strSQL += "delete from tb_mms_part_mapping"
                    strSQL += " where part_subcode = '" & Grid_DeviceData(i, 1) & "';"
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

        Data_Load()

        MessageBox.Show("저장 완료.",
                        msg_form,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly)

    End Sub

    Private Sub Grid_DeviceData_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Grid_DeviceData.AfterEdit

        If before_text = Grid_DeviceData(e.Row, e.Col) Then Exit Sub

        If IsNumeric(Grid_DeviceData(e.Row, 0)) Then
            Grid_DeviceData(e.Row, 0) = "M"
            Grid_DeviceData.Rows(e.Row).StyleNew.ForeColor = Color.Red
        End If

        Select Case e.Col
            Case 4
                If Grid_DeviceData(e.Row, 2) = String.Empty Then
                    MessageBox.Show(Me,
                                    "Vendor를 먼저 선택하여 주십시오.",
                                    msg_form,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation)
                    e.Cancel = True
                Else
                    Dim splitResult As String = Load_PHP(phpUrl & phpRootFolder &
                                                         "/barcodesplit.php?barcode=" &
                                                         Grid_DeviceData(e.Row, 4) &
                                                         "&maker=" &
                                                         Grid_DeviceData(e.Row, 2),
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
                            Grid_DeviceData(e.Row, 3) = partNo
                        Else
                            Grid_DeviceData(e.Row, 3) = org
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
                Grid_DeviceData.AutoSizeCols()
        End Select

    End Sub

    Dim before_text As String

    Private Sub Grid_DeviceData_BeforeEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Grid_DeviceData.BeforeEdit

        before_text = Grid_DeviceData(e.Row, e.Col)

    End Sub

    Private Sub Grid_DeviceData_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid_DeviceData.KeyDown

        If Grid_DeviceData(Grid_DeviceData.Row, 0).ToString = "D" Then
            e.SuppressKeyPress = True
        End If

    End Sub

    Private Sub DeviceData_Sub_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Me.DialogResult = DialogResult.OK

    End Sub

    Private Sub Grid_DeviceData_ComboDropDown(sender As Object, e As RowColEventArgs) Handles Grid_DeviceData.ComboDropDown

        If e.Col = 2 Then
            Grid_DeviceData.Cols(2).ComboList = Maker_List()
        End If

    End Sub

    Private Function Maker_List() As String

        Dim makerList As String = String.Empty

        DBConnect()

        Dim strSQL As String = "call sp_mmps_maker_list("
        strSQL += "'" & TB_CustomerCode.Text & "'"
        strSQL += ",'" & TB_PartCode.Text & "'"
        strSQL += ");"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            makerList = sqlDR("part_vendor")
        Loop
        sqlDR.Close()

        DBClose()

        makerList = makerList.Replace("/", "|")

        Return makerList

    End Function

    Private Sub Grid_DeviceData_RowColChange(sender As Object, e As EventArgs) Handles Grid_DeviceData.RowColChange

        Select Case Grid_DeviceData.Col
            Case 1
                Grid_DeviceData.AllowEditing = False
            Case 2, 3, 4, 5
                Grid_DeviceData.AllowEditing = True
        End Select

    End Sub
End Class