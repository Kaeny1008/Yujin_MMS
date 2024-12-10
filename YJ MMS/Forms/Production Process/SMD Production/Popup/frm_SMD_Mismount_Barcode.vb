Imports C1.Win.C1FlexGrid
Imports MySqlConnector

Public Class frm_SMD_Mismount_Barcode

    Public modelCode As String
    Public factoryName As String
    Public lineName As String
    Public workSide As String

    Dim totalBarcode As String

    Private Sub frm_SMD_Mismount_Barcode_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

        C1QRCode1.Text = "ReadyBarcode"

        LoadBarcode()

        If Grid_DeviceData.Rows.Count = 1 Then
            Me.DialogResult = DialogResult.Cancel
        Else
            C1QRCode1.Text = Grid_DeviceData(1, 2)
        End If

    End Sub

    Private Sub Grid_Setting()

        With Grid_DeviceData
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
            Grid_DeviceData(0, 0) = "No"
            Grid_DeviceData(0, 1) = "Machine No."
            Grid_DeviceData(0, 2) = "Device No."
            Grid_DeviceData(0, 3) = "확인결과"
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

    End Sub

    Private Sub LoadBarcode()

        Thread_LoadingFormStart(Me)

        Grid_DeviceData.Redraw = False
        Grid_DeviceData.Rows.Count = 1

        If DBConnect() = False Then Exit Sub

        Dim strSQL As String = "call sp_mms_smd_production_start(2"
        strSQL += ", '" & factoryName & "'"
        strSQL += ", '" & lineName & "'"
        strSQL += ", '" & modelCode & "'"
        strSQL += ", null"
        strSQL += ", '" & workSide & "'"
        strSQL += ", null"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            Dim insert_String As String = Grid_DeviceData.Rows.Count &
                vbTab & sqlDR("machine_no") &
                vbTab & sqlDR("device_no")
            Grid_DeviceData.AddItem(insert_String)
        Loop
        sqlDR.Close()

        DBClose()

        Grid_DeviceData.AutoSizeCols()
        Grid_DeviceData.Redraw = True

        Label1.Text = "총 " & Grid_DeviceData.Rows.Count - 1 & "대의 Device Data가 존재 합니다."

        Thread_LoadingFormEnd()

    End Sub

    Private Sub frm_SMD_Mismount_Barcode_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            MessageBox.Show(Me,
                            "강제로 창을 닫을 수 없습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub BTN_CheckResult_Click(sender As Object, e As EventArgs) Handles BTN_CheckResult.Click

        Dim machineNo As String = String.Empty
        Dim lastRow As Integer = 0

        For i = 1 To Grid_DeviceData.Rows.Count - 1
            If Grid_DeviceData(i, 3) = String.Empty Then
                machineNo = Grid_DeviceData(i, 1)
                lastRow = i
                Exit For
            End If
        Next

        If MessageBox.Show(Me,
                           "Machine No. : " & machineNo & vbCrLf & "자재확인을 완료 하였습니까?",
                           msg_form,
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Grid_DeviceData(lastRow, 3) = "OK"

        If lastRow + 1 = Grid_DeviceData.Rows.Count Then
            MessageBox.Show(Me,
                            "모든 설비의 자재확인을 완료 하였습니다.",
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
        Else
            C1QRCode1.Text = Grid_DeviceData(lastRow + 1, 2)
        End If

    End Sub
End Class