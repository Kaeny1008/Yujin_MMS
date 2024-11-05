<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Material_Transfer
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Material_Transfer))
        Me.TS_MainBar = New System.Windows.Forms.ToolStrip()
        Me.BTN_Search = New System.Windows.Forms.ToolStripButton()
        Me.Form_CLose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_New_Transfer = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Grid_TNList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Grid_History = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TB_TN_No = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.BTN_ListAdd = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TB_2ndQty = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TB_1stQty = New System.Windows.Forms.TextBox()
        Me.CB_PartsSplit = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.CB_AutoAdd = New System.Windows.Forms.CheckBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TB_InDate = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TB_Vendor = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TB_CustomerPartCode = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TB_Qty = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TB_LotNo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TB_PartNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TB_BarcodeScan = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CB_CustomerName = New System.Windows.Forms.ComboBox()
        Me.TB_CustomerCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Grid_Menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_RowDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.TS_MainBar.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Grid_TNList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.Grid_History, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Grid_Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TS_MainBar
        '
        Me.TS_MainBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Search, Me.Form_CLose, Me.ToolStripSeparator1, Me.BTN_New_Transfer})
        Me.TS_MainBar.Location = New System.Drawing.Point(0, 0)
        Me.TS_MainBar.Name = "TS_MainBar"
        Me.TS_MainBar.Size = New System.Drawing.Size(1564, 25)
        Me.TS_MainBar.TabIndex = 8
        Me.TS_MainBar.Text = "ToolStrip1"
        '
        'BTN_Search
        '
        Me.BTN_Search.Image = Global.YJ_MMS.My.Resources.Resources.search_121
        Me.BTN_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_Search.Name = "BTN_Search"
        Me.BTN_Search.Size = New System.Drawing.Size(51, 22)
        Me.BTN_Search.Text = "검색"
        '
        'Form_CLose
        '
        Me.Form_CLose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Form_CLose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Form_CLose.Image = Global.YJ_MMS.My.Resources.Resources.close
        Me.Form_CLose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Form_CLose.Name = "Form_CLose"
        Me.Form_CLose.Size = New System.Drawing.Size(23, 22)
        Me.Form_CLose.Text = "폼 닫기"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BTN_New_Transfer
        '
        Me.BTN_New_Transfer.Image = Global.YJ_MMS.My.Resources.Resources.order_history_32
        Me.BTN_New_Transfer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_New_Transfer.Name = "BTN_New_Transfer"
        Me.BTN_New_Transfer.Size = New System.Drawing.Size(75, 22)
        Me.BTN_New_Transfer.Text = "신규등록"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Grid_TNList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel4)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Grid_History)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1564, 748)
        Me.SplitContainer1.SplitterDistance = 421
        Me.SplitContainer1.TabIndex = 9
        '
        'Grid_TNList
        '
        Me.Grid_TNList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_TNList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_TNList.Location = New System.Drawing.Point(0, 75)
        Me.Grid_TNList.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_TNList.Name = "Grid_TNList"
        Me.Grid_TNList.Rows.Count = 2
        Me.Grid_TNList.Rows.DefaultSize = 20
        Me.Grid_TNList.Size = New System.Drawing.Size(421, 673)
        Me.Grid_TNList.StyleInfo = resources.GetString("Grid_TNList.StyleInfo")
        Me.Grid_TNList.TabIndex = 11
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel4.Controls.Add(Me.RadioButton5)
        Me.Panel4.Controls.Add(Me.RadioButton3)
        Me.Panel4.Controls.Add(Me.RadioButton4)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.DateTimePicker3)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.DateTimePicker2)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(421, 75)
        Me.Panel4.TabIndex = 12
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Checked = True
        Me.RadioButton5.Location = New System.Drawing.Point(245, 43)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton5.TabIndex = 46
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "전체"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(192, 43)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton3.TabIndex = 45
        Me.RadioButton3.Text = "입고"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(139, 43)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton4.TabIndex = 44
        Me.RadioButton4.Text = "출고"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.RoyalBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(9, 41)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 21)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "구분"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker3.Location = New System.Drawing.Point(262, 18)
        Me.DateTimePicker3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(97, 21)
        Me.DateTimePicker3.TabIndex = 42
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(236, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(23, 21)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "~"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(136, 18)
        Me.DateTimePicker2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(97, 21)
        Me.DateTimePicker2.TabIndex = 40
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.RoyalBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(9, 18)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 21)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "입출고일자"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Grid_History
        '
        Me.Grid_History.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_History.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_History.Location = New System.Drawing.Point(0, 469)
        Me.Grid_History.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_History.Name = "Grid_History"
        Me.Grid_History.Rows.Count = 2
        Me.Grid_History.Rows.DefaultSize = 20
        Me.Grid_History.Size = New System.Drawing.Size(1139, 279)
        Me.Grid_History.StyleInfo = resources.GetString("Grid_History.StyleInfo")
        Me.Grid_History.TabIndex = 10
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightBlue
        Me.Panel2.Controls.Add(Me.TB_TN_No)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Enabled = False
        Me.Panel2.Location = New System.Drawing.Point(0, 413)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1139, 56)
        Me.Panel2.TabIndex = 11
        '
        'TB_TN_No
        '
        Me.TB_TN_No.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TB_TN_No.Enabled = False
        Me.TB_TN_No.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TB_TN_No.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_TN_No.Location = New System.Drawing.Point(175, 15)
        Me.TB_TN_No.Multiline = True
        Me.TB_TN_No.Name = "TB_TN_No"
        Me.TB_TN_No.Size = New System.Drawing.Size(620, 25)
        Me.TB_TN_No.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 25)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "입출고번호"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.NumericUpDown1)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.BTN_Save)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.TB_BarcodeScan)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.CB_CustomerName)
        Me.Panel1.Controls.Add(Me.TB_CustomerCode)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1139, 413)
        Me.Panel1.TabIndex = 0
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(608, 370)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(183, 12)
        Me.Label19.TabIndex = 42
        Me.Label19.Text = "※ 선입선출 유예기간(최대 30일)"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(671, 386)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(120, 21)
        Me.NumericUpDown1.TabIndex = 41
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(175, 358)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(363, 49)
        Me.TextBox2.TabIndex = 40
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(10, 358)
        Me.Label18.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(165, 49)
        Me.Label18.TabIndex = 39
        Me.Label18.Text = "6. 비고"
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.CheckBox1)
        Me.Panel6.Controls.Add(Me.TextBox1)
        Me.Panel6.Controls.Add(Me.BTN_ListAdd)
        Me.Panel6.Controls.Add(Me.Label17)
        Me.Panel6.Controls.Add(Me.TB_2ndQty)
        Me.Panel6.Controls.Add(Me.Label16)
        Me.Panel6.Controls.Add(Me.TB_1stQty)
        Me.Panel6.Controls.Add(Me.CB_PartsSplit)
        Me.Panel6.Location = New System.Drawing.Point(175, 278)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(620, 78)
        Me.Panel6.TabIndex = 38
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(118, 17)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(72, 16)
        Me.CheckBox1.TabIndex = 44
        Me.CheckBox1.Text = "자동계산"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(512, 11)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(41, 21)
        Me.TextBox1.TabIndex = 43
        '
        'BTN_ListAdd
        '
        Me.BTN_ListAdd.Location = New System.Drawing.Point(559, 3)
        Me.BTN_ListAdd.Name = "BTN_ListAdd"
        Me.BTN_ListAdd.Size = New System.Drawing.Size(56, 70)
        Me.BTN_ListAdd.TabIndex = 42
        Me.BTN_ListAdd.Text = "목록" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "추가"
        Me.BTN_ListAdd.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(285, 44)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(124, 16)
        Me.Label17.TabIndex = 41
        Me.Label17.Text = "2번 자재 수량(보관) :"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TB_2ndQty
        '
        Me.TB_2ndQty.Enabled = False
        Me.TB_2ndQty.Location = New System.Drawing.Point(411, 42)
        Me.TB_2ndQty.Name = "TB_2ndQty"
        Me.TB_2ndQty.Size = New System.Drawing.Size(142, 21)
        Me.TB_2ndQty.TabIndex = 40
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(11, 44)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(124, 16)
        Me.Label16.TabIndex = 39
        Me.Label16.Text = "1번 자재 수량(출고) :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TB_1stQty
        '
        Me.TB_1stQty.Enabled = False
        Me.TB_1stQty.Location = New System.Drawing.Point(137, 42)
        Me.TB_1stQty.Name = "TB_1stQty"
        Me.TB_1stQty.Size = New System.Drawing.Size(142, 21)
        Me.TB_1stQty.TabIndex = 38
        '
        'CB_PartsSplit
        '
        Me.CB_PartsSplit.AutoSize = True
        Me.CB_PartsSplit.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CB_PartsSplit.Location = New System.Drawing.Point(12, 17)
        Me.CB_PartsSplit.Name = "CB_PartsSplit"
        Me.CB_PartsSplit.Size = New System.Drawing.Size(100, 16)
        Me.CB_PartsSplit.TabIndex = 37
        Me.CB_PartsSplit.Text = "자재분할 사용"
        Me.CB_PartsSplit.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(10, 278)
        Me.Label15.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(165, 78)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "5. 자재분할 선택"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.RadioButton6)
        Me.Panel5.Controls.Add(Me.CB_AutoAdd)
        Me.Panel5.Controls.Add(Me.RadioButton2)
        Me.Panel5.Controls.Add(Me.RadioButton1)
        Me.Panel5.Location = New System.Drawing.Point(175, 16)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(620, 25)
        Me.Panel5.TabIndex = 35
        '
        'CB_AutoAdd
        '
        Me.CB_AutoAdd.AutoSize = True
        Me.CB_AutoAdd.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CB_AutoAdd.Location = New System.Drawing.Point(263, 4)
        Me.CB_AutoAdd.Name = "CB_AutoAdd"
        Me.CB_AutoAdd.Size = New System.Drawing.Size(100, 16)
        Me.CB_AutoAdd.TabIndex = 38
        Me.CB_AutoAdd.Text = "자동목록 추가"
        Me.CB_AutoAdd.UseVisualStyleBackColor = False
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(66, 4)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "입고"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(13, 4)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.Text = "출고"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(10, 16)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 25)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "1. 구분"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BTN_Save
        '
        Me.BTN_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_Save.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_Save.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.BTN_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_Save.Location = New System.Drawing.Point(1035, 341)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(98, 66)
        Me.BTN_Save.TabIndex = 33
        Me.BTN_Save.Text = "저장"
        Me.BTN_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_Save.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.TB_InDate)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.TB_Vendor)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.TB_CustomerPartCode)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.TB_Qty)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.TB_LotNo)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.TB_PartNo)
        Me.Panel3.Location = New System.Drawing.Point(175, 97)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(620, 179)
        Me.Panel3.TabIndex = 32
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(10, 145)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 16)
        Me.Label14.TabIndex = 11
        Me.Label14.Text = "입고일자 :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_InDate
        '
        Me.TB_InDate.Enabled = False
        Me.TB_InDate.Location = New System.Drawing.Point(77, 143)
        Me.TB_InDate.Name = "TB_InDate"
        Me.TB_InDate.Size = New System.Drawing.Size(529, 21)
        Me.TB_InDate.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(10, 118)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 16)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Vendor :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_Vendor
        '
        Me.TB_Vendor.Enabled = False
        Me.TB_Vendor.Location = New System.Drawing.Point(77, 116)
        Me.TB_Vendor.Name = "TB_Vendor"
        Me.TB_Vendor.Size = New System.Drawing.Size(529, 21)
        Me.TB_Vendor.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(10, 91)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 16)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "자재코드 :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_CustomerPartCode
        '
        Me.TB_CustomerPartCode.Enabled = False
        Me.TB_CustomerPartCode.Location = New System.Drawing.Point(77, 89)
        Me.TB_CustomerPartCode.Name = "TB_CustomerPartCode"
        Me.TB_CustomerPartCode.Size = New System.Drawing.Size(529, 21)
        Me.TB_CustomerPartCode.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(10, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 16)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "수량 :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_Qty
        '
        Me.TB_Qty.Enabled = False
        Me.TB_Qty.Location = New System.Drawing.Point(77, 62)
        Me.TB_Qty.Name = "TB_Qty"
        Me.TB_Qty.Size = New System.Drawing.Size(529, 21)
        Me.TB_Qty.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(10, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 16)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Lot No. :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_LotNo
        '
        Me.TB_LotNo.Enabled = False
        Me.TB_LotNo.Location = New System.Drawing.Point(77, 35)
        Me.TB_LotNo.Name = "TB_LotNo"
        Me.TB_LotNo.Size = New System.Drawing.Size(529, 21)
        Me.TB_LotNo.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(10, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 16)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Part No. :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_PartNo
        '
        Me.TB_PartNo.Enabled = False
        Me.TB_PartNo.Location = New System.Drawing.Point(77, 8)
        Me.TB_PartNo.Name = "TB_PartNo"
        Me.TB_PartNo.Size = New System.Drawing.Size(529, 21)
        Me.TB_PartNo.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(10, 97)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(165, 179)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "4. Scan 결과"
        '
        'TB_BarcodeScan
        '
        Me.TB_BarcodeScan.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TB_BarcodeScan.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_BarcodeScan.Location = New System.Drawing.Point(175, 70)
        Me.TB_BarcodeScan.Multiline = True
        Me.TB_BarcodeScan.Name = "TB_BarcodeScan"
        Me.TB_BarcodeScan.Size = New System.Drawing.Size(620, 25)
        Me.TB_BarcodeScan.TabIndex = 30
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(10, 70)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(165, 25)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "3. Barcode Scan"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CB_CustomerName
        '
        Me.CB_CustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_CustomerName.Font = New System.Drawing.Font("굴림", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CB_CustomerName.FormattingEnabled = True
        Me.CB_CustomerName.Location = New System.Drawing.Point(175, 43)
        Me.CB_CustomerName.Margin = New System.Windows.Forms.Padding(0)
        Me.CB_CustomerName.Name = "CB_CustomerName"
        Me.CB_CustomerName.Size = New System.Drawing.Size(475, 25)
        Me.CB_CustomerName.TabIndex = 27
        '
        'TB_CustomerCode
        '
        Me.TB_CustomerCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerCode.Enabled = False
        Me.TB_CustomerCode.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_CustomerCode.Location = New System.Drawing.Point(650, 43)
        Me.TB_CustomerCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerCode.Name = "TB_CustomerCode"
        Me.TB_CustomerCode.Size = New System.Drawing.Size(145, 25)
        Me.TB_CustomerCode.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(10, 43)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(165, 25)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "2. 사용고객사"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Grid_Menu
        '
        Me.Grid_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_RowDelete})
        Me.Grid_Menu.Name = "Grid_Menu"
        Me.Grid_Menu.Size = New System.Drawing.Size(183, 26)
        '
        'BTN_RowDelete
        '
        Me.BTN_RowDelete.Name = "BTN_RowDelete"
        Me.BTN_RowDelete.Size = New System.Drawing.Size(182, 22)
        Me.BTN_RowDelete.Text = "선택 삭제(목록삭제)"
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Location = New System.Drawing.Point(119, 4)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(91, 16)
        Me.RadioButton6.TabIndex = 39
        Me.RadioButton6.Text = "Loss분 출고"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'frm_Material_Transfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1564, 773)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TS_MainBar)
        Me.Name = "frm_Material_Transfer"
        Me.Text = "자재 이동"
        Me.TS_MainBar.ResumeLayout(False)
        Me.TS_MainBar.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Grid_TNList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.Grid_History, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Grid_Menu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TS_MainBar As ToolStrip
    Friend WithEvents BTN_Search As ToolStripButton
    Friend WithEvents Form_CLose As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Grid_History As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents CB_CustomerName As ComboBox
    Friend WithEvents TB_CustomerCode As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TB_BarcodeScan As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents TB_Vendor As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TB_CustomerPartCode As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TB_Qty As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TB_LotNo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TB_PartNo As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Grid_TNList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BTN_Save As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TB_TN_No As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BTN_New_Transfer As ToolStripButton
    Friend WithEvents Panel4 As Panel
    Friend WithEvents DateTimePicker3 As DateTimePicker
    Friend WithEvents Label12 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TB_InDate As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents CB_PartsSplit As CheckBox
    Friend WithEvents Label17 As Label
    Friend WithEvents TB_2ndQty As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TB_1stQty As TextBox
    Friend WithEvents CB_AutoAdd As CheckBox
    Friend WithEvents BTN_ListAdd As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Grid_Menu As ContextMenuStrip
    Friend WithEvents BTN_RowDelete As ToolStripMenuItem
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents RadioButton6 As RadioButton
End Class
