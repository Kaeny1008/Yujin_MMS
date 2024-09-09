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

        CB_Cable2.Text = printerCable2
        If printerCable2 = "USB" Then PrinterListLoad(Me, CB_PrinterList2)
        CB_PrinterList2.Text = printerName2
        TB_Port2.Text = printerPort2
        TB_LEFT_Loc2.Text = printerLeftPosition2
        TB_TOP_Loc2.Text = printerTopPosition2
        TB_BaudRate2.Text = printerBaudRate2
        TB_DataBits2.Text = printerDataBits2
        TB_Parity2.Text = printerParity2
        TB_StopBits2.Text = printerStopBits2
        TB_MediaDarkness2.Text = printerMD2

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

    Private Sub CB_Cable2_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CB_Cable2.SelectionChangeCommitted

        If CB_Cable2.Text = "USB" Then
            PrinterListLoad(Me, CB_PrinterList2)
            CB_PrinterList2.Enabled = True
        Else
            CB_PrinterList2.Text = String.Empty
            CB_PrinterList2.Enabled = False
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

        registryEdit.WriteRegKey("Software\Yujin\MMS\Label Printer2", "COM/LPT", CB_Cable2.Text)
        registryEdit.WriteRegKey("Software\Yujin\MMS\Label Printer2", "Printer Name", CB_PrinterList2.Text)
        registryEdit.WriteRegKey("Software\Yujin\MMS\Label Printer2", "Port", CInt(TB_Port2.Text))
        registryEdit.WriteRegKey("Software\Yujin\MMS\Label Printer2", "Width", CInt(TB_LEFT_Loc2.Text))
        registryEdit.WriteRegKey("Software\Yujin\MMS\Label Printer2", "Height", CInt(TB_TOP_Loc2.Text))
        registryEdit.WriteRegKey("Software\Yujin\MMS\Label Printer2", "BaudRate", CInt(TB_BaudRate2.Text))
        registryEdit.WriteRegKey("Software\Yujin\MMS\Label Printer2", "DataBits", CInt(TB_DataBits2.Text))
        registryEdit.WriteRegKey("Software\Yujin\MMS\Label Printer2", "Parity", CInt(TB_Parity2.Text))
        registryEdit.WriteRegKey("Software\Yujin\MMS\Label Printer2", "StopBits", CInt(TB_StopBits2.Text))
        registryEdit.WriteRegKey("Software\Yujin\MMS\Label Printer2", "Media Darkness", CInt(TB_MediaDarkness2.Text))

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

        printerCable2 = CB_Cable2.Text
        printerName2 = CB_PrinterList2.Text
        printerPort2 = TB_Port2.Text
        printerLeftPosition2 = TB_LEFT_Loc2.Text
        printerTopPosition2 = TB_TOP_Loc2.Text
        printerBaudRate2 = TB_BaudRate2.Text
        printerDataBits2 = TB_DataBits2.Text
        printerParity2 = TB_Parity2.Text
        printerStopBits2 = TB_StopBits2.Text
        printerMD2 = TB_MediaDarkness2.Text

        Me.Dispose()

    End Sub

    Private Sub BTN_TestLabelPrint_Click(sender As Object, e As EventArgs) Handles BTN_TestLabelPrint.Click

        Dim testResult As String = TestPrinter(CB_Cable.Text,
                                               CB_PrinterList.Text,
                                               TB_Port.Text,
                                               TB_LEFT_Loc.Text,
                                               TB_TOP_Loc.Text,
                                               TB_BaudRate.Text,
                                               TB_DataBits.Text,
                                               TB_Parity.Text,
                                               TB_StopBits.Text,
                                               TB_MediaDarkness.Text)

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
        TB_MediaDarkness.KeyPress, TB_BaudRate2.KeyPress,
                TB_DataBits2.KeyPress,
        TB_LEFT_Loc2.KeyPress,
        TB_TOP_Loc2.KeyPress,
        TB_Parity2.KeyPress,
        TB_Port2.KeyPress,
        TB_StopBits2.KeyPress,
        TB_MediaDarkness2.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." And Not e.KeyChar = "-" Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim testResult As String = TestPrinter2(CB_Cable2.Text,
                                                CB_PrinterList2.Text,
                                                TB_Port2.Text,
                                                TB_LEFT_Loc2.Text,
                                                TB_TOP_Loc2.Text,
                                                TB_BaudRate2.Text,
                                                TB_DataBits2.Text,
                                                TB_Parity2.Text,
                                                TB_StopBits2.Text,
                                                TB_MediaDarkness2.Text)

        If Not testResult = "Success" Then
            MessageBox.Show("프린트에 실패 하였습니다." & vbCrLf & testResult, msg_form, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show("테스트 프린트 완료.", msg_form, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
End Class