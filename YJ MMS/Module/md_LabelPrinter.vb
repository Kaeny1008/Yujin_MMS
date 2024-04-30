Imports System.IO

Module md_LabelPrinter
    Public Sub Material_PrintLabel(ByVal custPartCode As String,
                                   ByVal partNo As String,
                                   ByVal lotNo As String,
                                   ByVal qty As Integer,
                                   ByVal vendor As String,
                                   ByVal printQty As Integer,
                                   ByVal customerName As String)

        If File.Exists(Application.StartupPath & "\print.txt") Then File.Delete(Application.StartupPath & "\print.txt")

        Dim swFile As StreamWriter =
            New StreamWriter(Application.StartupPath & "\print.txt", True, System.Text.Encoding.GetEncoding(949))

        swFile.WriteLine("^XZ~JA^XZ")
        swFile.WriteLine("^XA^LH" & printerLeftPosition & ",0^LT" & printerTopPosition) 'LH : 가로위치, LT : 세로위치
        swFile.WriteLine("^MD25") '진하기
        'swFile.WriteLine("^XA")
        'swFile.WriteLine("^BY2,2.0^FS")
        swFile.WriteLine("^SEE:UHANGUL.DAT^FS")
        swFile.WriteLine("^CW1,E:KFONT3.FNT^CI26^FS")
        swFile.WriteLine("^FO180,0000^A0,60,40^FDPart Code : " & custPartCode & "^FS")
        swFile.WriteLine("^FO180,0060^A0,40,30^FDVendor Code : " & partNo & "^FS")
        swFile.WriteLine("^FO180,0095^A0,40,30^FDLot No : " & lotNo & "^FS")
        swFile.WriteLine("^FO180,0130^A0,40,30^FDQty : " & Format(qty, "#,##0") & "^FS")
        swFile.WriteLine("^FO550,0140^A1N,30,20^FD" & customerName & "^FS")
        Dim barcodeString As String = custPartCode & "!" & partNo & "!" & lotNo & "!" & qty & "!" & vendor
        swFile.WriteLine("^FO020,0020^BXN,3,200,44,44^FD" & barcodeString & "^FS")
        swFile.WriteLine("^PQ" & printQty & "^FS") 'PQ : 발행수량
        swFile.WriteLine("^XZ")
        swFile.Close()

        Dim printResult As String = LabelPrint()

        If Not printResult = "Success" Then
            MessageBox.Show("라벨 발행에 실패 하였습니다. 재 발행하여 주십시오." & vbCrLf &
                            "재입고 금지 - 재발행 할것" &
                            printResult,
                            msg_form,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1)
        End If

    End Sub

    Dim sPath = Application.StartupPath & "\QR Label Layout\Label.lbx"
    Public Sub Brother_Printer(ByVal barcodeString As String)
        'LabelTest_Process()
        Dim objDoc As bpac.Document
        objDoc = CreateObject("bpac.Document")
        If (objDoc.Open(sPath) <> False) Then
            objDoc.GetObject("Barcode1").Text = barcodeString

            'objDoc.SetMediaByName(objDoc.Printer.GetMediaName, True)
            objDoc.StartPrint("", bpac.PrintOptionConstants.bpoDefault)
            objDoc.PrintOut(1, bpac.PrintOptionConstants.bpoDefault)
            objDoc.EndPrint()
            objDoc.Close()
        End If
    End Sub
End Module
