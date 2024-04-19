<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MetalMaskHistory
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MetalMaskHistory))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Tb_MaskCloseReason = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Rb_All = New System.Windows.Forms.RadioButton()
        Me.Rb_Month = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Rb_Select = New System.Windows.Forms.RadioButton()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Tb_UsingCount = New System.Windows.Forms.TextBox()
        Me.Tb_MaskSize = New System.Windows.Forms.TextBox()
        Me.Tb_InDate = New System.Windows.Forms.TextBox()
        Me.Tb_MakingDate = New System.Windows.Forms.TextBox()
        Me.Tb_Thickness = New System.Windows.Forms.TextBox()
        Me.Tb_WorkSide = New System.Windows.Forms.TextBox()
        Me.Tb_ModelName = New System.Windows.Forms.TextBox()
        Me.Tb_CustomerName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Tb_ModelCode = New System.Windows.Forms.TextBox()
        Me.Tb_CustomerCode = New System.Windows.Forms.TextBox()
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
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Tb_MaskSN = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Grid_MASK_LIST = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.BTN_Search = New System.Windows.Forms.ToolStripButton()
        Me.Btn_Print = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CMS_gridMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_newLine = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_deleteLine = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_Save = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_DataPrint = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Grid_MASK_LIST, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.CMS_gridMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label24)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tb_MaskCloseReason)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label23)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tb_UsingCount)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tb_MaskSize)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tb_InDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tb_MakingDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tb_Thickness)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tb_WorkSide)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tb_ModelName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tb_CustomerName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tb_ModelCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tb_CustomerCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tb_Note)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label15)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label14)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label13)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_MakingCompany)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label12)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tb_Revision)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label16)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label17)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tb_MaskSN)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label18)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel2.Controls.Add(Me.Grid_MASK_LIST)
        Me.SplitContainer1.Size = New System.Drawing.Size(1264, 748)
        Me.SplitContainer1.SplitterDistance = 604
        Me.SplitContainer1.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.RadioButton3)
        Me.Panel3.Controls.Add(Me.RadioButton2)
        Me.Panel3.Controls.Add(Me.RadioButton1)
        Me.Panel3.Location = New System.Drawing.Point(136, 59)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(395, 21)
        Me.Panel3.TabIndex = 207
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(167, 2)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(133, 16)
        Me.RadioButton3.TabIndex = 200
        Me.RadioButton3.Text = "생산이력(시작 제외)"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(56, 2)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(105, 16)
        Me.RadioButton2.TabIndex = 199
        Me.RadioButton2.Text = "생산이력(전체)"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(3, 3)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton1.TabIndex = 198
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "전체"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.CadetBlue
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(9, 59)
        Me.Label24.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(127, 21)
        Me.Label24.TabIndex = 216
        Me.Label24.Text = "검색 설정"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tb_MaskCloseReason
        '
        Me.Tb_MaskCloseReason.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_MaskCloseReason.Enabled = False
        Me.Tb_MaskCloseReason.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_MaskCloseReason.Location = New System.Drawing.Point(136, 415)
        Me.Tb_MaskCloseReason.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_MaskCloseReason.Multiline = True
        Me.Tb_MaskCloseReason.Name = "Tb_MaskCloseReason"
        Me.Tb_MaskCloseReason.Size = New System.Drawing.Size(459, 75)
        Me.Tb_MaskCloseReason.TabIndex = 215
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.SteelBlue
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(9, 415)
        Me.Label23.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(127, 75)
        Me.Label23.TabIndex = 214
        Me.Label23.Text = "폐기사유" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(폐기시 작성된 내용)"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(9, 538)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(586, 198)
        Me.GroupBox1.TabIndex = 213
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "* 참고사항 *"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label21.Location = New System.Drawing.Point(23, 116)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(469, 36)
        Me.Label21.TabIndex = 218
        Me.Label21.Text = "* 개구부 파손 : 단 1개라도 있으면 NG" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "* Sus 표면 찌그러짐 : 1mm 이상의 찌그러짐이 1개소 이상" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "* Sus 표면 흠집 : 평면에" &
    " 폭 0.1mm, 길이 10mm 이상의 흠집이 1개소라도 있으면 NG"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label22.Location = New System.Drawing.Point(23, 104)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(76, 12)
        Me.Label22.TabIndex = 217
        Me.Label22.Text = "[검사 기준]"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label19.Location = New System.Drawing.Point(174, 67)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(130, 12)
        Me.Label19.TabIndex = 216
        Me.Label19.Text = "* Model Change / 1회" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label20.Location = New System.Drawing.Point(174, 55)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(76, 12)
        Me.Label20.TabIndex = 215
        Me.Label20.Text = "[작성 주기]"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.Location = New System.Drawing.Point(23, 67)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(133, 24)
        Me.Label7.TabIndex = 214
        Me.Label7.Text = "* 검사 : 매월 1회" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "* 폐기 : 100K회 사용 후"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.Location = New System.Drawing.Point(23, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 12)
        Me.Label4.TabIndex = 213
        Me.Label4.Text = "[검사 주기]"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Rb_All)
        Me.Panel2.Controls.Add(Me.Rb_Month)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Rb_Select)
        Me.Panel2.Controls.Add(Me.DateTimePicker2)
        Me.Panel2.Controls.Add(Me.DateTimePicker1)
        Me.Panel2.Location = New System.Drawing.Point(136, 36)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(395, 21)
        Me.Panel2.TabIndex = 206
        '
        'Rb_All
        '
        Me.Rb_All.AutoSize = True
        Me.Rb_All.Location = New System.Drawing.Point(3, 3)
        Me.Rb_All.Name = "Rb_All"
        Me.Rb_All.Size = New System.Drawing.Size(47, 16)
        Me.Rb_All.TabIndex = 198
        Me.Rb_All.Text = "전체"
        Me.Rb_All.UseVisualStyleBackColor = True
        '
        'Rb_Month
        '
        Me.Rb_Month.AutoSize = True
        Me.Rb_Month.Checked = True
        Me.Rb_Month.Location = New System.Drawing.Point(56, 3)
        Me.Rb_Month.Name = "Rb_Month"
        Me.Rb_Month.Size = New System.Drawing.Size(47, 16)
        Me.Rb_Month.TabIndex = 200
        Me.Rb_Month.TabStop = True
        Me.Rb_Month.Text = "당월"
        Me.Rb_Month.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(266, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 12)
        Me.Label2.TabIndex = 204
        Me.Label2.Text = "~"
        '
        'Rb_Select
        '
        Me.Rb_Select.AutoSize = True
        Me.Rb_Select.Location = New System.Drawing.Point(109, 3)
        Me.Rb_Select.Name = "Rb_Select"
        Me.Rb_Select.Size = New System.Drawing.Size(47, 16)
        Me.Rb_Select.TabIndex = 201
        Me.Rb_Select.Text = "선택"
        Me.Rb_Select.UseVisualStyleBackColor = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Enabled = False
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(286, 1)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(98, 21)
        Me.DateTimePicker2.TabIndex = 203
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(162, 1)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(98, 21)
        Me.DateTimePicker1.TabIndex = 202
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("굴림", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(226, 24)
        Me.Label3.TabIndex = 205
        Me.Label3.Text = "<메탈마스크 정보>"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.CadetBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 36)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 21)
        Me.Label1.TabIndex = 199
        Me.Label1.Text = "이력 기간"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tb_UsingCount
        '
        Me.Tb_UsingCount.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_UsingCount.Enabled = False
        Me.Tb_UsingCount.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_UsingCount.Location = New System.Drawing.Point(429, 315)
        Me.Tb_UsingCount.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_UsingCount.Name = "Tb_UsingCount"
        Me.Tb_UsingCount.Size = New System.Drawing.Size(166, 21)
        Me.Tb_UsingCount.TabIndex = 197
        '
        'Tb_MaskSize
        '
        Me.Tb_MaskSize.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_MaskSize.Enabled = False
        Me.Tb_MaskSize.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_MaskSize.Location = New System.Drawing.Point(136, 315)
        Me.Tb_MaskSize.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_MaskSize.Name = "Tb_MaskSize"
        Me.Tb_MaskSize.Size = New System.Drawing.Size(166, 21)
        Me.Tb_MaskSize.TabIndex = 196
        '
        'Tb_InDate
        '
        Me.Tb_InDate.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_InDate.Enabled = False
        Me.Tb_InDate.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_InDate.Location = New System.Drawing.Point(136, 292)
        Me.Tb_InDate.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_InDate.Name = "Tb_InDate"
        Me.Tb_InDate.Size = New System.Drawing.Size(166, 21)
        Me.Tb_InDate.TabIndex = 195
        '
        'Tb_MakingDate
        '
        Me.Tb_MakingDate.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_MakingDate.Enabled = False
        Me.Tb_MakingDate.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_MakingDate.Location = New System.Drawing.Point(429, 269)
        Me.Tb_MakingDate.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_MakingDate.Name = "Tb_MakingDate"
        Me.Tb_MakingDate.Size = New System.Drawing.Size(166, 21)
        Me.Tb_MakingDate.TabIndex = 194
        '
        'Tb_Thickness
        '
        Me.Tb_Thickness.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_Thickness.Enabled = False
        Me.Tb_Thickness.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_Thickness.Location = New System.Drawing.Point(136, 269)
        Me.Tb_Thickness.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_Thickness.Name = "Tb_Thickness"
        Me.Tb_Thickness.Size = New System.Drawing.Size(166, 21)
        Me.Tb_Thickness.TabIndex = 193
        '
        'Tb_WorkSide
        '
        Me.Tb_WorkSide.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_WorkSide.Enabled = False
        Me.Tb_WorkSide.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_WorkSide.Location = New System.Drawing.Point(429, 246)
        Me.Tb_WorkSide.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_WorkSide.Name = "Tb_WorkSide"
        Me.Tb_WorkSide.Size = New System.Drawing.Size(166, 21)
        Me.Tb_WorkSide.TabIndex = 192
        '
        'Tb_ModelName
        '
        Me.Tb_ModelName.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_ModelName.Enabled = False
        Me.Tb_ModelName.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_ModelName.Location = New System.Drawing.Point(211, 223)
        Me.Tb_ModelName.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_ModelName.Name = "Tb_ModelName"
        Me.Tb_ModelName.Size = New System.Drawing.Size(384, 21)
        Me.Tb_ModelName.TabIndex = 191
        '
        'Tb_CustomerName
        '
        Me.Tb_CustomerName.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_CustomerName.Enabled = False
        Me.Tb_CustomerName.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_CustomerName.Location = New System.Drawing.Point(211, 200)
        Me.Tb_CustomerName.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_CustomerName.Name = "Tb_CustomerName"
        Me.Tb_CustomerName.Size = New System.Drawing.Size(384, 21)
        Me.Tb_CustomerName.TabIndex = 190
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(302, 246)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 21)
        Me.Label5.TabIndex = 179
        Me.Label5.Text = "작업면"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tb_ModelCode
        '
        Me.Tb_ModelCode.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_ModelCode.Enabled = False
        Me.Tb_ModelCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_ModelCode.Location = New System.Drawing.Point(136, 223)
        Me.Tb_ModelCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_ModelCode.Name = "Tb_ModelCode"
        Me.Tb_ModelCode.Size = New System.Drawing.Size(75, 21)
        Me.Tb_ModelCode.TabIndex = 176
        '
        'Tb_CustomerCode
        '
        Me.Tb_CustomerCode.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_CustomerCode.Enabled = False
        Me.Tb_CustomerCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_CustomerCode.Location = New System.Drawing.Point(136, 200)
        Me.Tb_CustomerCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_CustomerCode.Name = "Tb_CustomerCode"
        Me.Tb_CustomerCode.Size = New System.Drawing.Size(75, 21)
        Me.Tb_CustomerCode.TabIndex = 174
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Rb_Not_Use)
        Me.Panel1.Controls.Add(Me.Rb_Use)
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(136, 177)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(166, 21)
        Me.Panel1.TabIndex = 189
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
        Me.Tb_Note.Enabled = False
        Me.Tb_Note.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_Note.Location = New System.Drawing.Point(136, 338)
        Me.Tb_Note.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_Note.Multiline = True
        Me.Tb_Note.Name = "Tb_Note"
        Me.Tb_Note.Size = New System.Drawing.Size(459, 75)
        Me.Tb_Note.TabIndex = 188
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.SteelBlue
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(9, 338)
        Me.Label15.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(127, 75)
        Me.Label15.TabIndex = 187
        Me.Label15.Text = "비고"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(302, 315)
        Me.Label14.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(127, 21)
        Me.Label14.TabIndex = 186
        Me.Label14.Text = "사용횟수"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SteelBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(9, 315)
        Me.Label13.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(127, 21)
        Me.Label13.TabIndex = 185
        Me.Label13.Text = "사이즈"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TB_MakingCompany
        '
        Me.TB_MakingCompany.BackColor = System.Drawing.SystemColors.Window
        Me.TB_MakingCompany.Enabled = False
        Me.TB_MakingCompany.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_MakingCompany.Location = New System.Drawing.Point(429, 292)
        Me.TB_MakingCompany.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_MakingCompany.Name = "TB_MakingCompany"
        Me.TB_MakingCompany.Size = New System.Drawing.Size(166, 21)
        Me.TB_MakingCompany.TabIndex = 184
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SteelBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(302, 292)
        Me.Label12.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(127, 21)
        Me.Label12.TabIndex = 183
        Me.Label12.Text = "제작업체"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.SteelBlue
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(9, 292)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 21)
        Me.Label11.TabIndex = 182
        Me.Label11.Text = "입고일자"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.SteelBlue
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(302, 269)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(127, 21)
        Me.Label10.TabIndex = 181
        Me.Label10.Text = "제작일자"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SteelBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(9, 269)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(127, 21)
        Me.Label9.TabIndex = 180
        Me.Label9.Text = "두께"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tb_Revision
        '
        Me.Tb_Revision.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_Revision.Enabled = False
        Me.Tb_Revision.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_Revision.Location = New System.Drawing.Point(136, 246)
        Me.Tb_Revision.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_Revision.Name = "Tb_Revision"
        Me.Tb_Revision.Size = New System.Drawing.Size(166, 21)
        Me.Tb_Revision.TabIndex = 178
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(9, 246)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(127, 21)
        Me.Label8.TabIndex = 177
        Me.Label8.Text = "Rev."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(9, 223)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 21)
        Me.Label6.TabIndex = 175
        Me.Label6.Text = "모델명"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.SteelBlue
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(9, 200)
        Me.Label16.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(127, 21)
        Me.Label16.TabIndex = 173
        Me.Label16.Text = "고객사"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.SteelBlue
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(9, 177)
        Me.Label17.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(127, 21)
        Me.Label17.TabIndex = 172
        Me.Label17.Text = "사용여부"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tb_MaskSN
        '
        Me.Tb_MaskSN.BackColor = System.Drawing.SystemColors.Window
        Me.Tb_MaskSN.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Tb_MaskSN.Location = New System.Drawing.Point(136, 13)
        Me.Tb_MaskSN.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Tb_MaskSN.Name = "Tb_MaskSN"
        Me.Tb_MaskSN.Size = New System.Drawing.Size(384, 21)
        Me.Tb_MaskSN.TabIndex = 171
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.CadetBlue
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(9, 13)
        Me.Label18.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(127, 21)
        Me.Label18.TabIndex = 170
        Me.Label18.Text = "관리번호"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Grid_MASK_LIST
        '
        Me.Grid_MASK_LIST.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_MASK_LIST.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_MASK_LIST.Location = New System.Drawing.Point(0, 0)
        Me.Grid_MASK_LIST.Name = "Grid_MASK_LIST"
        Me.Grid_MASK_LIST.Rows.Count = 2
        Me.Grid_MASK_LIST.Rows.DefaultSize = 20
        Me.Grid_MASK_LIST.Size = New System.Drawing.Size(656, 748)
        Me.Grid_MASK_LIST.StyleInfo = resources.GetString("Grid_MASK_LIST.StyleInfo")
        Me.Grid_MASK_LIST.TabIndex = 7
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.BTN_Search, Me.Btn_Print})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1264, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("맑은 고딕", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(0, 22)
        '
        'BTN_Search
        '
        Me.BTN_Search.Image = Global.YJ_MMS.My.Resources.Resources.search
        Me.BTN_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_Search.Name = "BTN_Search"
        Me.BTN_Search.Size = New System.Drawing.Size(51, 22)
        Me.BTN_Search.Text = "검색"
        '
        'Btn_Print
        '
        Me.Btn_Print.Image = Global.YJ_MMS.My.Resources.Resources.printer_blue
        Me.Btn_Print.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_Print.Name = "Btn_Print"
        Me.Btn_Print.Size = New System.Drawing.Size(75, 22)
        Me.Btn_Print.Text = "이력출력"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(160, 6)
        '
        'CMS_gridMenu
        '
        Me.CMS_gridMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_newLine, Me.BTN_deleteLine, Me.ToolStripSeparator1, Me.BTN_Save, Me.ToolStripSeparator2, Me.BTN_DataPrint})
        Me.CMS_gridMenu.Name = "CMS_gridMenu"
        Me.CMS_gridMenu.Size = New System.Drawing.Size(164, 104)
        '
        'BTN_newLine
        '
        Me.BTN_newLine.Name = "BTN_newLine"
        Me.BTN_newLine.Size = New System.Drawing.Size(163, 22)
        Me.BTN_newLine.Text = "신규등록"
        '
        'BTN_deleteLine
        '
        Me.BTN_deleteLine.Name = "BTN_deleteLine"
        Me.BTN_deleteLine.Size = New System.Drawing.Size(163, 22)
        Me.BTN_deleteLine.Text = "삭제"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(160, 6)
        '
        'BTN_Save
        '
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(163, 22)
        Me.BTN_Save.Text = "저장"
        '
        'BTN_DataPrint
        '
        Me.BTN_DataPrint.Name = "BTN_DataPrint"
        Me.BTN_DataPrint.Size = New System.Drawing.Size(163, 22)
        Me.BTN_DataPrint.Text = "DeviceData 출력"
        '
        'frm_MetalMaskHistory
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1264, 773)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frm_MetalMaskHistory"
        Me.Text = "MetalMask 이력확인"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Grid_MASK_LIST, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.CMS_gridMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents BTN_Search As ToolStripButton
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents CMS_gridMenu As ContextMenuStrip
    Friend WithEvents BTN_newLine As ToolStripMenuItem
    Friend WithEvents BTN_deleteLine As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BTN_Save As ToolStripMenuItem
    Friend WithEvents BTN_DataPrint As ToolStripMenuItem
    Friend WithEvents Tb_UsingCount As TextBox
    Friend WithEvents Tb_MaskSize As TextBox
    Friend WithEvents Tb_InDate As TextBox
    Friend WithEvents Tb_MakingDate As TextBox
    Friend WithEvents Tb_Thickness As TextBox
    Friend WithEvents Tb_WorkSide As TextBox
    Friend WithEvents Tb_ModelName As TextBox
    Friend WithEvents Tb_CustomerName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Tb_ModelCode As TextBox
    Friend WithEvents Tb_CustomerCode As TextBox
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
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Tb_MaskSN As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents Grid_MASK_LIST As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label2 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Rb_Select As RadioButton
    Friend WithEvents Rb_Month As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Rb_All As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Tb_MaskCloseReason As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Btn_Print As ToolStripButton
    Friend WithEvents Panel3 As Panel
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Label24 As Label
End Class
