<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_MetalMask_Close
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Rb_Not_Use = New System.Windows.Forms.RadioButton()
        Me.Rb_Use = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Tb_MaskSN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Btn_Save = New System.Windows.Forms.Button()
        Me.TB_MaskSize = New System.Windows.Forms.TextBox()
        Me.Tb_InDate = New System.Windows.Forms.TextBox()
        Me.Tb_Thickness = New System.Windows.Forms.TextBox()
        Me.Tb_ModelName = New System.Windows.Forms.TextBox()
        Me.Tb_CustomerName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Tb_ModelCode = New System.Windows.Forms.TextBox()
        Me.Tb_CustomerCode = New System.Windows.Forms.TextBox()
        Me.Tb_Note = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Tb_Revision = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Tb_UsingCount = New System.Windows.Forms.TextBox()
        Me.Tb_MakingDate = New System.Windows.Forms.TextBox()
        Me.Tb_WorkSide = New System.Windows.Forms.TextBox()
        Me.TB_MakingCompany = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Rb_Not_Use)
        Me.Panel1.Controls.Add(Me.Rb_Use)
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(429, 10)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(166, 21)
        Me.Panel1.TabIndex = 75
        '
        'Rb_Not_Use
        '
        Me.Rb_Not_Use.AutoSize = True
        Me.Rb_Not_Use.Checked = True
        Me.Rb_Not_Use.Location = New System.Drawing.Point(56, 3)
        Me.Rb_Not_Use.Name = "Rb_Not_Use"
        Me.Rb_Not_Use.Size = New System.Drawing.Size(47, 16)
        Me.Rb_Not_Use.TabIndex = 1
        Me.Rb_Not_Use.TabStop = True
        Me.Rb_Not_Use.Text = "폐기"
        Me.Rb_Not_Use.UseVisualStyleBackColor = True
        '
        'Rb_Use
        '
        Me.Rb_Use.AutoSize = True
        Me.Rb_Use.Location = New System.Drawing.Point(3, 3)
        Me.Rb_Use.Name = "Rb_Use"
        Me.Rb_Use.Size = New System.Drawing.Size(47, 16)
        Me.Rb_Use.TabIndex = 0
        Me.Rb_Use.Text = "사용"
        Me.Rb_Use.UseVisualStyleBackColor = True
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
        Me.Label2.Text = "관리번호"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Btn_Save
        '
        Me.Btn_Save.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Btn_Save.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.Btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Save.Location = New System.Drawing.Point(498, 280)
        Me.Btn_Save.Name = "Btn_Save"
        Me.Btn_Save.Size = New System.Drawing.Size(93, 58)
        Me.Btn_Save.TabIndex = 30
        Me.Btn_Save.Text = "저장"
        Me.Btn_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Save.UseVisualStyleBackColor = True
        '
        'TB_MaskSize
        '
        Me.TB_MaskSize.BackColor = System.Drawing.SystemColors.Window
        Me.TB_MaskSize.Enabled = False
        Me.TB_MaskSize.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_MaskSize.Location = New System.Drawing.Point(136, 148)
        Me.TB_MaskSize.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_MaskSize.Name = "TB_MaskSize"
        Me.TB_MaskSize.Size = New System.Drawing.Size(166, 21)
        Me.TB_MaskSize.TabIndex = 216
        '
        'Tb_InDate
        '
        Me.Tb_InDate.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_InDate.Enabled = False
        Me.Tb_InDate.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_InDate.Location = New System.Drawing.Point(136, 125)
        Me.Tb_InDate.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_InDate.Name = "Tb_InDate"
        Me.Tb_InDate.Size = New System.Drawing.Size(166, 21)
        Me.Tb_InDate.TabIndex = 215
        '
        'Tb_Thickness
        '
        Me.Tb_Thickness.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_Thickness.Enabled = False
        Me.Tb_Thickness.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_Thickness.Location = New System.Drawing.Point(136, 102)
        Me.Tb_Thickness.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_Thickness.Name = "Tb_Thickness"
        Me.Tb_Thickness.Size = New System.Drawing.Size(166, 21)
        Me.Tb_Thickness.TabIndex = 214
        '
        'Tb_ModelName
        '
        Me.Tb_ModelName.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_ModelName.Enabled = False
        Me.Tb_ModelName.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_ModelName.Location = New System.Drawing.Point(211, 56)
        Me.Tb_ModelName.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_ModelName.Name = "Tb_ModelName"
        Me.Tb_ModelName.Size = New System.Drawing.Size(384, 21)
        Me.Tb_ModelName.TabIndex = 213
        '
        'Tb_CustomerName
        '
        Me.Tb_CustomerName.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_CustomerName.Enabled = False
        Me.Tb_CustomerName.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_CustomerName.Location = New System.Drawing.Point(211, 33)
        Me.Tb_CustomerName.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_CustomerName.Name = "Tb_CustomerName"
        Me.Tb_CustomerName.Size = New System.Drawing.Size(384, 21)
        Me.Tb_CustomerName.TabIndex = 212
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(302, 79)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 21)
        Me.Label5.TabIndex = 203
        Me.Label5.Text = "작업면"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tb_ModelCode
        '
        Me.Tb_ModelCode.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_ModelCode.Enabled = False
        Me.Tb_ModelCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_ModelCode.Location = New System.Drawing.Point(136, 56)
        Me.Tb_ModelCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_ModelCode.Name = "Tb_ModelCode"
        Me.Tb_ModelCode.Size = New System.Drawing.Size(75, 21)
        Me.Tb_ModelCode.TabIndex = 200
        '
        'Tb_CustomerCode
        '
        Me.Tb_CustomerCode.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_CustomerCode.Enabled = False
        Me.Tb_CustomerCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_CustomerCode.Location = New System.Drawing.Point(136, 33)
        Me.Tb_CustomerCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_CustomerCode.Name = "Tb_CustomerCode"
        Me.Tb_CustomerCode.Size = New System.Drawing.Size(75, 21)
        Me.Tb_CustomerCode.TabIndex = 198
        '
        'Tb_Note
        '
        Me.Tb_Note.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_Note.Enabled = False
        Me.Tb_Note.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_Note.Location = New System.Drawing.Point(136, 171)
        Me.Tb_Note.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_Note.Multiline = True
        Me.Tb_Note.Name = "Tb_Note"
        Me.Tb_Note.Size = New System.Drawing.Size(459, 75)
        Me.Tb_Note.TabIndex = 211
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.SteelBlue
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(9, 171)
        Me.Label15.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(127, 75)
        Me.Label15.TabIndex = 210
        Me.Label15.Text = "비고"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(302, 148)
        Me.Label14.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(127, 21)
        Me.Label14.TabIndex = 209
        Me.Label14.Text = "사용횟수"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SteelBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(9, 148)
        Me.Label13.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(127, 21)
        Me.Label13.TabIndex = 208
        Me.Label13.Text = "사이즈"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SteelBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(302, 125)
        Me.Label12.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(127, 21)
        Me.Label12.TabIndex = 207
        Me.Label12.Text = "제작업체"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.SteelBlue
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(9, 125)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 21)
        Me.Label11.TabIndex = 206
        Me.Label11.Text = "입고일자"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.SteelBlue
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(302, 102)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(127, 21)
        Me.Label10.TabIndex = 205
        Me.Label10.Text = "제작일자"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SteelBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(9, 102)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(127, 21)
        Me.Label9.TabIndex = 204
        Me.Label9.Text = "두께"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tb_Revision
        '
        Me.Tb_Revision.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_Revision.Enabled = False
        Me.Tb_Revision.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_Revision.Location = New System.Drawing.Point(136, 79)
        Me.Tb_Revision.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_Revision.Name = "Tb_Revision"
        Me.Tb_Revision.Size = New System.Drawing.Size(166, 21)
        Me.Tb_Revision.TabIndex = 202
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(9, 79)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(127, 21)
        Me.Label8.TabIndex = 201
        Me.Label8.Text = "Rev."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(9, 56)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 21)
        Me.Label6.TabIndex = 199
        Me.Label6.Text = "모델명"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Label16.TabIndex = 197
        Me.Label16.Text = "고객사"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tb_UsingCount
        '
        Me.Tb_UsingCount.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_UsingCount.Enabled = False
        Me.Tb_UsingCount.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_UsingCount.Location = New System.Drawing.Point(429, 148)
        Me.Tb_UsingCount.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_UsingCount.Name = "Tb_UsingCount"
        Me.Tb_UsingCount.Size = New System.Drawing.Size(166, 21)
        Me.Tb_UsingCount.TabIndex = 220
        '
        'Tb_MakingDate
        '
        Me.Tb_MakingDate.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_MakingDate.Enabled = False
        Me.Tb_MakingDate.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_MakingDate.Location = New System.Drawing.Point(429, 102)
        Me.Tb_MakingDate.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_MakingDate.Name = "Tb_MakingDate"
        Me.Tb_MakingDate.Size = New System.Drawing.Size(166, 21)
        Me.Tb_MakingDate.TabIndex = 219
        '
        'Tb_WorkSide
        '
        Me.Tb_WorkSide.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_WorkSide.Enabled = False
        Me.Tb_WorkSide.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_WorkSide.Location = New System.Drawing.Point(429, 79)
        Me.Tb_WorkSide.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_WorkSide.Name = "Tb_WorkSide"
        Me.Tb_WorkSide.Size = New System.Drawing.Size(166, 21)
        Me.Tb_WorkSide.TabIndex = 218
        '
        'TB_MakingCompany
        '
        Me.TB_MakingCompany.BackColor = System.Drawing.SystemColors.Window
        Me.TB_MakingCompany.Enabled = False
        Me.TB_MakingCompany.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_MakingCompany.Location = New System.Drawing.Point(429, 125)
        Me.TB_MakingCompany.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_MakingCompany.Name = "TB_MakingCompany"
        Me.TB_MakingCompany.Size = New System.Drawing.Size(166, 21)
        Me.TB_MakingCompany.TabIndex = 217
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TextBox1.Location = New System.Drawing.Point(136, 280)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(359, 57)
        Me.TextBox1.TabIndex = 222
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.CadetBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 280)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 57)
        Me.Label1.TabIndex = 221
        Me.Label1.Text = "폐기사유"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MM_Stop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(603, 347)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Tb_UsingCount)
        Me.Controls.Add(Me.Tb_MakingDate)
        Me.Controls.Add(Me.Tb_WorkSide)
        Me.Controls.Add(Me.TB_MakingCompany)
        Me.Controls.Add(Me.TB_MaskSize)
        Me.Controls.Add(Me.Tb_InDate)
        Me.Controls.Add(Me.Tb_Thickness)
        Me.Controls.Add(Me.Tb_ModelName)
        Me.Controls.Add(Me.Tb_CustomerName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Tb_ModelCode)
        Me.Controls.Add(Me.Tb_CustomerCode)
        Me.Controls.Add(Me.Tb_Note)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Tb_Revision)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Btn_Save)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Tb_MaskSN)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MM_Stop"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "마스크 폐기 등록"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Rb_Not_Use As RadioButton
    Friend WithEvents Rb_Use As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents Tb_MaskSN As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Btn_Save As Button
    Friend WithEvents TB_MaskSize As TextBox
    Friend WithEvents Tb_InDate As TextBox
    Friend WithEvents Tb_Thickness As TextBox
    Friend WithEvents Tb_ModelName As TextBox
    Friend WithEvents Tb_CustomerName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Tb_ModelCode As TextBox
    Friend WithEvents Tb_CustomerCode As TextBox
    Friend WithEvents Tb_Note As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Tb_Revision As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Tb_UsingCount As TextBox
    Friend WithEvents Tb_MakingDate As TextBox
    Friend WithEvents Tb_WorkSide As TextBox
    Friend WithEvents TB_MakingCompany As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
End Class
