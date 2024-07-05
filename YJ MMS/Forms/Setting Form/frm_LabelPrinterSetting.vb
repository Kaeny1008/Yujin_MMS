Public Class frm_LabelPrinterSetting
    Private Sub frm_LabelPrinterSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Load_PrinterSetting()

    End Sub

    Private Sub Load_PrinterSetting()

        CB_Cable.Text = printerCable
        If printerCable = "USB" Then PrinterListLoad(Me, CB_PrinterList)
        CB_PrinterList.Text = printerName
        TB_Port.Text = printerPort
        TB_LEFT_Loc.Text = printerLeftPosition
        TB_TOP_Loc.Text = printerTopPosition
        TB_BaudRate.Text = printerBaudRate
        TB_DataBits.Text = printerDataBits
        TB_Parity.Text = printerParity
        TB_StopBits.Text = printerStopBits
        TB_MediaDarkness.Text = printerMD

    End Sub

    Private Sub CB_Cable_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_Cable.SelectionChangeCommitted

        If CB_Cable.Text = "USB" Then
            PrinterListLoad(Me, CB_PrinterList)
            CB_PrinterList.Enabled = True
        Else
            CB_PrinterList.Text = String.Empty
            CB_PrinterList.Enabled = False
        End If

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        'Registry 기록
        registryEdit.WriteRegKey("Software\Yujin\MMS\Label Printer", "COM/LPT", CB_Cable.Text)
        registryEdit.WriteRegKey("Software\Yujin\MMS\Label Printer", "Printer Name", CB_PrinterList.Text)
        registryEdit.WriteRegKey("Software\Yujin\MMS\Label Printer", "Port", CInt(TB_Port.Text))
        registryEdit.WriteRegKey("Software\Yujin\MMS\Label Printer", "Width", CInt(TB_LEFT_Loc.Text))
        registryEdit.WriteRegKey("Software\Yujin\MMS\Label Printer", "Height", CInt(TB_TOP_Loc.Text))
        registryEdit.WriteRegKey("Software\Yujin\MMS\Label Printer", "BaudRate", CInt(TB_BaudRate.Text))
        registryEdit.WriteRegKey("Software\Yujin\MMS\Label Printer", "DataBits", CInt(TB_DataBits.Text))
        registryEdit.WriteRegKey("Software\Yujin\MMS\Label Printer", "Parity", CInt(TB_Parity.Text))
        registryEdit.WriteRegKey("Software\Yujin\MMS\Label Printer", "StopBits", CInt(TB_StopBits.Text))
        registryEdit.WriteRegKey("Software\Yujin\MMS\Label Printer", "Media Darkness", CInt(TB_MediaDarkness.Text))

        '변수에 현재 상태를 저장
        printerCable = CB_Cable.Text
        printerName = CB_PrinterList.Text
        printerPort = TB_Port.Text
        printerLeftPosition = TB_LEFT_Loc.Text
        printerTopPosition = TB_TOP_Loc.Text
        printerBaudRate = TB_BaudRate.Text
        printerDataBits = TB_DataBits.Text
        printerParity = TB_Parity.Text
        printerStopBits = TB_StopBits.Text
        printerMD = TB_MediaDarkness.Text

        Me.Dispose()

    End Sub

    Private Sub BTN_TestLabelPrint_Click(sender As Object, e As EventArgs) Handles BTN_TestLabelPrint.Click

        Dim testResult As String = TestPrinter(CB_Cable.Text, CB_PrinterList.Text, TB_Port.Text, TB_LEFT_Loc.Text, TB_TOP_Loc.Text, TB_BaudRate.Text, TB_DataBits.Text, TB_Parity.Text, TB_StopBits.Text)

        If Not testResult = "Success" Then
            MessageBox.Show("프린트에 실패 하였습니다." & vbCrLf & testResult, msg_form, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show("테스트 프린트 완료.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub OnlyNumberPress(sender As Object, e As KeyPressEventArgs) Handles TB_BaudRate.KeyPress,
        TB_DataBits.KeyPress,
        TB_LEFT_Loc.KeyPress,
        TB_TOP_Loc.KeyPress,
        TB_Parity.KeyPress,
        TB_Port.KeyPress,
        TB_StopBits.KeyPress,
        TB_MediaDarkness.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." And Not e.KeyChar = "-" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TB_TOP_Loc_GotFocus(sender As Object, e As EventArgs) Handles TB_BaudRate.GotFocus,
        TB_DataBits.GotFocus,
        TB_LEFT_Loc.GotFocus,
        TB_TOP_Loc.GotFocus,
        TB_Parity.GotFocus,
        TB_Port.GotFocus,
        TB_StopBits.GotFocus,
        TB_MediaDarkness.GotFocus

        sender.SelectAll()

    End Sub

    Private Sub TB_TOP_Loc_MouseClick(sender As Object, e As MouseEventArgs) Handles TB_BaudRate.MouseClick,
        TB_DataBits.MouseClick,
        TB_LEFT_Loc.MouseClick,
        TB_TOP_Loc.MouseClick,
        TB_Parity.MouseClick,
        TB_Port.MouseClick,
        TB_StopBits.MouseClick,
        TB_MediaDarkness.MouseClick

        sender.SelectAll()

    End Sub

    Private Sub TB_StopBits_TextChanged(sender As Object, e As EventArgs) Handles TB_StopBits.TextChanged

    End Sub
End Class