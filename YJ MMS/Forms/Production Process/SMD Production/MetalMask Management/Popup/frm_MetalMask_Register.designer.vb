<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MetalMask_Register
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Rb_Not_Use = New System.Windows.Forms.RadioButton()
        Me.Rb_Use = New System.Windows.Forms.RadioButton()
        Me.Tb_Note = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TB_MakingCompany = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Tb_Revision = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Tb_MaskSN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tb_modelCode = New System.Windows.Forms.TextBox()
        Me.Cb_modelName = New System.Windows.Forms.ComboBox()
        Me.Tb_customerCode = New System.Windows.Forms.TextBox()
        Me.Cb_customerName = New System.Windows.Forms.ComboBox()
        Me.Cb_Thickness = New System.Windows.Forms.ComboBox()
        Me.DT_MakingDate = New System.Windows.Forms.DateTimePicker()
        Me.Dt_InDate = New System.Windows.Forms.DateTimePicker()
        Me.CB_MaskSize = New System.Windows.Forms.ComboBox()
        Me.Nud_UsingCount = New System.Windows.Forms.NumericUpDown()
        Me.Btn_Save = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cb_WorkSide = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TB_CheckResult = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.Nud_UsingCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Rb_Not_Use)
        Me.Panel1.Controls.Add(Me.Rb_Use)
        Me.Panel1.Location = New System.Drawing.Point(429, 10)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(166, 21)
        Me.Panel1.TabIndex = 3
        '
        'Rb_Not_Use
        '
        Me.Rb_Not_Use.AutoSize = True
        Me.Rb_Not_Use.Location = New System.Drawing.Point(56, 3)
        Me.Rb_Not_Use.Name = "Rb_Not_Use"
        Me.Rb_Not_Use.Size = New System.Drawing.Size(47, 16)
        Me.Rb_Not_Use.TabIndex = 1
        Me.Rb_Not_Use.Text = "폐기"
        Me.Rb_Not_Use.UseVisualStyleBackColor = True
        '
        'Rb_Use
        '
        Me.Rb_Use.AutoSize = True
        Me.Rb_Use.Checked = True
        Me.Rb_Use.Location = New System.Drawing.Point(3, 3)
        Me.Rb_Use.Name = "Rb_Use"
        Me.Rb_Use.Size = New System.Drawing.Size(47, 16)
        Me.Rb_Use.TabIndex = 0
        Me.Rb_Use.TabStop = True
        Me.Rb_Use.Text = "사용"
        Me.Rb_Use.UseVisualStyleBackColor = True
        '
        'Tb_Note
        '
        Me.Tb_Note.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_Note.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_Note.Location = New System.Drawing.Point(136, 194)
        Me.Tb_Note.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_Note.Multiline = True
        Me.Tb_Note.Name = "Tb_Note"
        Me.Tb_Note.Size = New System.Drawing.Size(458, 75)
        Me.Tb_Note.TabIndex = 31
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.SteelBlue
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(9, 194)
        Me.Label15.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(127, 75)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "비고"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(302, 171)
        Me.Label14.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(127, 21)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "사용횟수"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SteelBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(9, 171)
        Me.Label13.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(127, 21)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "사이즈(*)"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TB_MakingCompany
        '
        Me.TB_MakingCompany.BackColor = System.Drawing.SystemColors.Window
        Me.TB_MakingCompany.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_MakingCompany.Location = New System.Drawing.Point(429, 148)
        Me.TB_MakingCompany.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_MakingCompany.Name = "TB_MakingCompany"
        Me.TB_MakingCompany.Size = New System.Drawing.Size(166, 21)
        Me.TB_MakingCompany.TabIndex = 25
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SteelBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(302, 148)
        Me.Label12.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(127, 21)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "제작업체"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.SteelBlue
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(9, 148)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 21)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "입고일자(*)"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.SteelBlue
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(302, 125)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(127, 21)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "제작일자(*)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SteelBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(9, 125)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(127, 21)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "두께(*)"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tb_Revision
        '
        Me.Tb_Revision.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_Revision.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_Revision.Location = New System.Drawing.Point(136, 102)
        Me.Tb_Revision.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_Revision.Name = "Tb_Revision"
        Me.Tb_Revision.Size = New System.Drawing.Size(166, 21)
        Me.Tb_Revision.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(9, 102)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(127, 21)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Rev."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(9, 79)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 21)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "모델명(*)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(9, 56)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 21)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "고객사(*)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(302, 10)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 21)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "사용여부"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tb_MaskSN
        '
        Me.Tb_MaskSN.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_MaskSN.Enabled = False
        Me.Tb_MaskSN.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_MaskSN.Location = New System.Drawing.Point(136, 10)
        Me.Tb_MaskSN.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_MaskSN.Name = "Tb_MaskSN"
        Me.Tb_MaskSN.Size = New System.Drawing.Size(166, 21)
        Me.Tb_MaskSN.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(9, 10)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 21)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "관리번호(*)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tb_modelCode
        '
        Me.Tb_modelCode.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_modelCode.Enabled = False
        Me.Tb_modelCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_modelCode.Location = New System.Drawing.Point(136, 79)
        Me.Tb_modelCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_modelCode.Name = "Tb_modelCode"
        Me.Tb_modelCode.Size = New System.Drawing.Size(131, 21)
        Me.Tb_modelCode.TabIndex = 11
        '
        'Cb_modelName
        '
        Me.Cb_modelName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_modelName.Font = New System.Drawing.Font("굴림", 9.75!)
        Me.Cb_modelName.FormattingEnabled = True
        Me.Cb_modelName.Location = New System.Drawing.Point(267, 79)
        Me.Cb_modelName.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Cb_modelName.Name = "Cb_modelName"
        Me.Cb_modelName.Size = New System.Drawing.Size(324, 21)
        Me.Cb_modelName.TabIndex = 12
        '
        'Tb_customerCode
        '
        Me.Tb_customerCode.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_customerCode.Enabled = False
        Me.Tb_customerCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_customerCode.Location = New System.Drawing.Point(136, 56)
        Me.Tb_customerCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_customerCode.Name = "Tb_customerCode"
        Me.Tb_customerCode.Size = New System.Drawing.Size(131, 21)
        Me.Tb_customerCode.TabIndex = 7
        '
        'Cb_customerName
        '
        Me.Cb_customerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_customerName.Font = New System.Drawing.Font("굴림", 9.75!)
        Me.Cb_customerName.FormattingEnabled = True
        Me.Cb_customerName.Location = New System.Drawing.Point(267, 56)
        Me.Cb_customerName.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Cb_customerName.Name = "Cb_customerName"
        Me.Cb_customerName.Size = New System.Drawing.Size(324, 21)
        Me.Cb_customerName.TabIndex = 8
        '
        'Cb_Thickness
        '
        Me.Cb_Thickness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_Thickness.Font = New System.Drawing.Font("굴림", 9.75!)
        Me.Cb_Thickness.FormattingEnabled = True
        Me.Cb_Thickness.Items.AddRange(New Object() {"0.08T", "0.10T", "0.12T", "0.15T"})
        Me.Cb_Thickness.Location = New System.Drawing.Point(136, 125)
        Me.Cb_Thickness.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Cb_Thickness.Name = "Cb_Thickness"
        Me.Cb_Thickness.Size = New System.Drawing.Size(165, 21)
        Me.Cb_Thickness.TabIndex = 19
        '
        'DT_MakingDate
        '
        Me.DT_MakingDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DT_MakingDate.Location = New System.Drawing.Point(429, 125)
        Me.DT_MakingDate.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.DT_MakingDate.Name = "DT_MakingDate"
        Me.DT_MakingDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DT_MakingDate.Size = New System.Drawing.Size(166, 21)
        Me.DT_MakingDate.TabIndex = 21
        '
        'Dt_InDate
        '
        Me.Dt_InDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dt_InDate.Location = New System.Drawing.Point(135, 148)
        Me.Dt_InDate.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Dt_InDate.Name = "Dt_InDate"
        Me.Dt_InDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Dt_InDate.Size = New System.Drawing.Size(166, 21)
        Me.Dt_InDate.TabIndex = 23
        '
        'CB_MaskSize
        '
        Me.CB_MaskSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_MaskSize.Font = New System.Drawing.Font("굴림", 9.75!)
        Me.CB_MaskSize.FormattingEnabled = True
        Me.CB_MaskSize.Items.AddRange(New Object() {"650*550", "736*736"})
        Me.CB_MaskSize.Location = New System.Drawing.Point(136, 171)
        Me.CB_MaskSize.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.CB_MaskSize.Name = "CB_MaskSize"
        Me.CB_MaskSize.Size = New System.Drawing.Size(165, 21)
        Me.CB_MaskSize.TabIndex = 27
        '
        'Nud_UsingCount
        '
        Me.Nud_UsingCount.Location = New System.Drawing.Point(429, 171)
        Me.Nud_UsingCount.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Nud_UsingCount.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Nud_UsingCount.Name = "Nud_UsingCount"
        Me.Nud_UsingCount.Size = New System.Drawing.Size(166, 21)
        Me.Nud_UsingCount.TabIndex = 29
        Me.Nud_UsingCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Btn_Save
        '
        Me.Btn_Save.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Btn_Save.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.Btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Save.Location = New System.Drawing.Point(498, 273)
        Me.Btn_Save.Name = "Btn_Save"
        Me.Btn_Save.Size = New System.Drawing.Size(93, 58)
        Me.Btn_Save.TabIndex = 34
        Me.Btn_Save.Text = "저장"
        Me.Btn_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Save.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 270)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 12)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "(*)는 필수 입력 항목입니다."
        '
        'Cb_WorkSide
        '
        Me.Cb_WorkSide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb_WorkSide.Font = New System.Drawing.Font("굴림", 9.75!)
        Me.Cb_WorkSide.FormattingEnabled = True
        Me.Cb_WorkSide.Items.AddRange(New Object() {"Bottom", "Top"})
        Me.Cb_WorkSide.Location = New System.Drawing.Point(429, 102)
        Me.Cb_WorkSide.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Cb_WorkSide.Name = "Cb_WorkSide"
        Me.Cb_WorkSide.Size = New System.Drawing.Size(165, 21)
        Me.Cb_WorkSide.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(302, 102)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 21)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "작업면(*)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(12, 288)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(385, 24)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "현재 마스크의 사용이력이 존재하므로 사용횟수를 수정할 수 없습니다." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "필요시 관리자에게 요청하십시오."
        Me.Label7.Visible = False
        '
        'TB_CheckResult
        '
        Me.TB_CheckResult.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CheckResult.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_CheckResult.Location = New System.Drawing.Point(136, 33)
        Me.TB_CheckResult.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CheckResult.Name = "TB_CheckResult"
        Me.TB_CheckResult.Size = New System.Drawing.Size(455, 21)
        Me.TB_CheckResult.TabIndex = 5
        Me.TB_CheckResult.Text = "이상 무"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.SteelBlue
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(9, 33)
        Me.Label16.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(127, 21)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "검사결과(*)"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frm_MetalMask_Register
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(603, 336)
        Me.Controls.Add(Me.TB_CheckResult)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Cb_WorkSide)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_Save)
        Me.Controls.Add(Me.Nud_UsingCount)
        Me.Controls.Add(Me.CB_MaskSize)
        Me.Controls.Add(Me.Dt_InDate)
        Me.Controls.Add(Me.DT_MakingDate)
        Me.Controls.Add(Me.Cb_Thickness)
        Me.Controls.Add(Me.Tb_modelCode)
        Me.Controls.Add(Me.Cb_modelName)
        Me.Controls.Add(Me.Tb_customerCode)
        Me.Controls.Add(Me.Cb_customerName)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Tb_Note)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TB_MakingCompany)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Tb_Revision)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Tb_MaskSN)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_MetalMask_Register"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "신규 마스크 등록"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Nud_UsingCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Rb_Not_Use As RadioButton
    Friend WithEvents Rb_Use As RadioButton
    Friend WithEvents Tb_Note As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TB_MakingCompany As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Tb_Revision As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Tb_MaskSN As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Tb_modelCode As TextBox
    Friend WithEvents Cb_modelName As ComboBox
    Friend WithEvents Tb_customerCode As TextBox
    Friend WithEvents Cb_customerName As ComboBox
    Friend WithEvents Cb_Thickness As ComboBox
    Friend WithEvents DT_MakingDate As DateTimePicker
    Friend WithEvents Dt_InDate As DateTimePicker
    Friend WithEvents CB_MaskSize As ComboBox
    Friend WithEvents Nud_UsingCount As NumericUpDown
    Friend WithEvents Btn_Save As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Cb_WorkSide As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TB_CheckResult As TextBox
    Friend WithEvents Label16 As Label
End Class
