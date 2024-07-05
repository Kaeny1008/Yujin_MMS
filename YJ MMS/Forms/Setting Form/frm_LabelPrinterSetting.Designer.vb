<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_LabelPrinterSetting
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.CB_PrinterList = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TB_MediaDarkness = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TB_StopBits = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.TB_Parity = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.CB_Cable = New System.Windows.Forms.ComboBox()
        Me.TB_DataBits = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TB_TOP_Loc = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TB_BaudRate = New System.Windows.Forms.TextBox()
        Me.TB_LEFT_Loc = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.TB_Port = New System.Windows.Forms.TextBox()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.BTN_TestLabelPrint = New System.Windows.Forms.Button()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.White
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label32.Font = New System.Drawing.Font("굴림", 16.0!, System.Drawing.FontStyle.Bold)
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(9, 10)
        Me.Label32.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(482, 47)
        Me.Label32.TabIndex = 0
        Me.Label32.Text = "프린터 설정"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel5.Controls.Add(Me.CB_PrinterList)
        Me.Panel5.Controls.Add(Me.Label23)
        Me.Panel5.Controls.Add(Me.TB_MediaDarkness)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.TB_StopBits)
        Me.Panel5.Controls.Add(Me.Label34)
        Me.Panel5.Controls.Add(Me.TB_Parity)
        Me.Panel5.Controls.Add(Me.Label33)
        Me.Panel5.Controls.Add(Me.CB_Cable)
        Me.Panel5.Controls.Add(Me.TB_DataBits)
        Me.Panel5.Controls.Add(Me.Label26)
        Me.Panel5.Controls.Add(Me.Label27)
        Me.Panel5.Controls.Add(Me.Label28)
        Me.Panel5.Controls.Add(Me.TB_TOP_Loc)
        Me.Panel5.Controls.Add(Me.Label29)
        Me.Panel5.Controls.Add(Me.TB_BaudRate)
        Me.Panel5.Controls.Add(Me.TB_LEFT_Loc)
        Me.Panel5.Controls.Add(Me.Label30)
        Me.Panel5.Controls.Add(Me.Label31)
        Me.Panel5.Controls.Add(Me.TB_Port)
        Me.Panel5.Location = New System.Drawing.Point(9, 61)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(482, 300)
        Me.Panel5.TabIndex = 1
        '
        'CB_PrinterList
        '
        Me.CB_PrinterList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_PrinterList.Font = New System.Drawing.Font("굴림", 13.75!, System.Drawing.FontStyle.Bold)
        Me.CB_PrinterList.FormattingEnabled = True
        Me.CB_PrinterList.Location = New System.Drawing.Point(180, 36)
        Me.CB_PrinterList.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.CB_PrinterList.Name = "CB_PrinterList"
        Me.CB_PrinterList.Size = New System.Drawing.Size(285, 26)
        Me.CB_PrinterList.TabIndex = 3
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.SlateGray
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(9, 36)
        Me.Label23.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(171, 26)
        Me.Label23.TabIndex = 2
        Me.Label23.Text = "Printer 목록"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_MediaDarkness
        '
        Me.TB_MediaDarkness.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_MediaDarkness.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_MediaDarkness.Location = New System.Drawing.Point(180, 260)
        Me.TB_MediaDarkness.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_MediaDarkness.Name = "TB_MediaDarkness"
        Me.TB_MediaDarkness.Size = New System.Drawing.Size(285, 26)
        Me.TB_MediaDarkness.TabIndex = 17
        Me.TB_MediaDarkness.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 260)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(171, 26)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "StopBits"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_StopBits
        '
        Me.TB_StopBits.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_StopBits.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_StopBits.Location = New System.Drawing.Point(180, 232)
        Me.TB_StopBits.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_StopBits.Name = "TB_StopBits"
        Me.TB_StopBits.Size = New System.Drawing.Size(285, 26)
        Me.TB_StopBits.TabIndex = 17
        Me.TB_StopBits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.SlateGray
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label34.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.Location = New System.Drawing.Point(9, 232)
        Me.Label34.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(171, 26)
        Me.Label34.TabIndex = 16
        Me.Label34.Text = "StopBits"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Parity
        '
        Me.TB_Parity.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_Parity.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_Parity.Location = New System.Drawing.Point(180, 204)
        Me.TB_Parity.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Parity.Name = "TB_Parity"
        Me.TB_Parity.Size = New System.Drawing.Size(285, 26)
        Me.TB_Parity.TabIndex = 15
        Me.TB_Parity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.SlateGray
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(9, 204)
        Me.Label33.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(171, 26)
        Me.Label33.TabIndex = 14
        Me.Label33.Text = "Parity"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CB_Cable
        '
        Me.CB_Cable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Cable.Font = New System.Drawing.Font("굴림", 13.75!, System.Drawing.FontStyle.Bold)
        Me.CB_Cable.FormattingEnabled = True
        Me.CB_Cable.Items.AddRange(New Object() {"COM", "LPT", "USB"})
        Me.CB_Cable.Location = New System.Drawing.Point(180, 8)
        Me.CB_Cable.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.CB_Cable.Name = "CB_Cable"
        Me.CB_Cable.Size = New System.Drawing.Size(285, 26)
        Me.CB_Cable.TabIndex = 1
        '
        'TB_DataBits
        '
        Me.TB_DataBits.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_DataBits.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_DataBits.Location = New System.Drawing.Point(180, 176)
        Me.TB_DataBits.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_DataBits.Name = "TB_DataBits"
        Me.TB_DataBits.Size = New System.Drawing.Size(285, 26)
        Me.TB_DataBits.TabIndex = 13
        Me.TB_DataBits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.SlateGray
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label26.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(9, 8)
        Me.Label26.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(171, 26)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "COM / LPT / USB"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.SlateGray
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label27.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(9, 176)
        Me.Label27.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(171, 26)
        Me.Label27.TabIndex = 12
        Me.Label27.Text = "DataBits"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.SlateGray
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(9, 120)
        Me.Label28.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(171, 26)
        Me.Label28.TabIndex = 8
        Me.Label28.Text = "인쇄위치(세로)"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_TOP_Loc
        '
        Me.TB_TOP_Loc.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_TOP_Loc.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_TOP_Loc.Location = New System.Drawing.Point(180, 120)
        Me.TB_TOP_Loc.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_TOP_Loc.Name = "TB_TOP_Loc"
        Me.TB_TOP_Loc.Size = New System.Drawing.Size(285, 26)
        Me.TB_TOP_Loc.TabIndex = 9
        Me.TB_TOP_Loc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.SlateGray
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(9, 148)
        Me.Label29.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(171, 26)
        Me.Label29.TabIndex = 10
        Me.Label29.Text = "BaudRate"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_BaudRate
        '
        Me.TB_BaudRate.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_BaudRate.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_BaudRate.Location = New System.Drawing.Point(180, 148)
        Me.TB_BaudRate.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_BaudRate.Name = "TB_BaudRate"
        Me.TB_BaudRate.Size = New System.Drawing.Size(285, 26)
        Me.TB_BaudRate.TabIndex = 11
        Me.TB_BaudRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TB_LEFT_Loc
        '
        Me.TB_LEFT_Loc.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_LEFT_Loc.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_LEFT_Loc.Location = New System.Drawing.Point(180, 92)
        Me.TB_LEFT_Loc.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_LEFT_Loc.Name = "TB_LEFT_Loc"
        Me.TB_LEFT_Loc.Size = New System.Drawing.Size(285, 26)
        Me.TB_LEFT_Loc.TabIndex = 7
        Me.TB_LEFT_Loc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.SlateGray
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label30.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(9, 64)
        Me.Label30.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(171, 26)
        Me.Label30.TabIndex = 4
        Me.Label30.Text = "Port"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.SlateGray
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.Location = New System.Drawing.Point(9, 92)
        Me.Label31.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(171, 26)
        Me.Label31.TabIndex = 6
        Me.Label31.Text = "인쇄위치(가로)"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Port
        '
        Me.TB_Port.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_Port.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_Port.Location = New System.Drawing.Point(180, 64)
        Me.TB_Port.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Port.Name = "TB_Port"
        Me.TB_Port.Size = New System.Drawing.Size(285, 26)
        Me.TB_Port.TabIndex = 5
        Me.TB_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BTN_Save
        '
        Me.BTN_Save.BackColor = System.Drawing.Color.Red
        Me.BTN_Save.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_Save.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.BTN_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_Save.Location = New System.Drawing.Point(323, 384)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(168, 87)
        Me.BTN_Save.TabIndex = 3
        Me.BTN_Save.Text = "저장 및 닫기"
        Me.BTN_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_Save.UseVisualStyleBackColor = True
        '
        'BTN_TestLabelPrint
        '
        Me.BTN_TestLabelPrint.BackColor = System.Drawing.Color.Red
        Me.BTN_TestLabelPrint.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_TestLabelPrint.Image = Global.YJ_MMS.My.Resources.Resources.barcode
        Me.BTN_TestLabelPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_TestLabelPrint.Location = New System.Drawing.Point(95, 384)
        Me.BTN_TestLabelPrint.Name = "BTN_TestLabelPrint"
        Me.BTN_TestLabelPrint.Size = New System.Drawing.Size(222, 87)
        Me.BTN_TestLabelPrint.TabIndex = 2
        Me.BTN_TestLabelPrint.Text = "테스트 라벨 발행"
        Me.BTN_TestLabelPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_TestLabelPrint.UseVisualStyleBackColor = True
        '
        'frm_LabelPrinterSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 483)
        Me.Controls.Add(Me.BTN_Save)
        Me.Controls.Add(Me.BTN_TestLabelPrint)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Panel5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_LabelPrinterSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "라벨 프린터 설정"
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BTN_TestLabelPrint As Button
    Friend WithEvents Label32 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents CB_PrinterList As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents TB_StopBits As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents TB_Parity As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents CB_Cable As ComboBox
    Friend WithEvents TB_DataBits As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents TB_TOP_Loc As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents TB_BaudRate As TextBox
    Friend WithEvents TB_LEFT_Loc As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents TB_Port As TextBox
    Friend WithEvents BTN_Save As Button
    Friend WithEvents TB_MediaDarkness As TextBox
    Friend WithEvents Label1 As Label
End Class
