<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Material_Warehousing_With_Label
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Material_Warehousing_With_Label))
        Me.Grid_PartList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Grid_MaterialList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.TB_Supplier = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TB_DocumentNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TB_BarcodeScan = New System.Windows.Forms.TextBox()
        Me.TB_ItemCode = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CB_Vendor = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.RB_Supplier = New System.Windows.Forms.RadioButton()
        Me.RB_Vendor = New System.Windows.Forms.RadioButton()
        Me.BTN_ListAdd = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TB_InNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TB_CustomerCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TS_MainBar = New System.Windows.Forms.ToolStrip()
        Me.BTN_Search = New System.Windows.Forms.ToolStripButton()
        Me.Form_CLose = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Grid_DocumentsList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.DTP_End = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DTP_Start = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Grid_Menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_RePrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.TB_CustomerName = New System.Windows.Forms.TextBox()
        CType(Me.Grid_PartList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.Grid_MaterialList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TS_MainBar.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Grid_DocumentsList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Grid_Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grid_PartList
        '
        Me.Grid_PartList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_PartList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_PartList.Location = New System.Drawing.Point(0, 297)
        Me.Grid_PartList.Name = "Grid_PartList"
        Me.Grid_PartList.Rows.Count = 2
        Me.Grid_PartList.Rows.DefaultSize = 20
        Me.Grid_PartList.Size = New System.Drawing.Size(1025, 451)
        Me.Grid_PartList.StyleInfo = resources.GetString("Grid_PartList.StyleInfo")
        Me.Grid_PartList.TabIndex = 2
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer2.Panel1.Controls.Add(Me.Grid_MaterialList)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Grid_PartList)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer2.Size = New System.Drawing.Size(1519, 748)
        Me.SplitContainer2.SplitterDistance = 490
        Me.SplitContainer2.TabIndex = 3
        '
        'Grid_MaterialList
        '
        Me.Grid_MaterialList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_MaterialList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_MaterialList.Location = New System.Drawing.Point(0, 71)
        Me.Grid_MaterialList.Name = "Grid_MaterialList"
        Me.Grid_MaterialList.Rows.Count = 2
        Me.Grid_MaterialList.Rows.DefaultSize = 20
        Me.Grid_MaterialList.Size = New System.Drawing.Size(490, 677)
        Me.Grid_MaterialList.StyleInfo = resources.GetString("Grid_MaterialList.StyleInfo")
        Me.Grid_MaterialList.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BTN_Save)
        Me.Panel1.Controls.Add(Me.TB_Supplier)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TB_DocumentNo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(490, 71)
        Me.Panel1.TabIndex = 31
        '
        'BTN_Save
        '
        Me.BTN_Save.Enabled = False
        Me.BTN_Save.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_Save.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.BTN_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_Save.Location = New System.Drawing.Point(370, 6)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(117, 52)
        Me.BTN_Save.TabIndex = 35
        Me.BTN_Save.Text = "확인저장"
        Me.BTN_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_Save.UseVisualStyleBackColor = True
        '
        'TB_Supplier
        '
        Me.TB_Supplier.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Supplier.Enabled = False
        Me.TB_Supplier.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TB_Supplier.Location = New System.Drawing.Point(108, 33)
        Me.TB_Supplier.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Supplier.Name = "TB_Supplier"
        Me.TB_Supplier.Size = New System.Drawing.Size(238, 25)
        Me.TB_Supplier.TabIndex = 33
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(8, 33)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 25)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "공급사"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_DocumentNo
        '
        Me.TB_DocumentNo.BackColor = System.Drawing.SystemColors.Window
        Me.TB_DocumentNo.Enabled = False
        Me.TB_DocumentNo.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TB_DocumentNo.Location = New System.Drawing.Point(108, 6)
        Me.TB_DocumentNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_DocumentNo.Name = "TB_DocumentNo"
        Me.TB_DocumentNo.Size = New System.Drawing.Size(238, 25)
        Me.TB_DocumentNo.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 6)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 25)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "문서번호"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.Controls.Add(Me.TB_CustomerName)
        Me.Panel2.Controls.Add(Me.CheckBox1)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.TB_BarcodeScan)
        Me.Panel2.Controls.Add(Me.TB_ItemCode)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.CB_Vendor)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.BTN_ListAdd)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.TB_InNo)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.TB_CustomerCode)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1025, 297)
        Me.Panel2.TabIndex = 32
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(467, 121)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(128, 16)
        Me.CheckBox1.TabIndex = 30
        Me.CheckBox1.Text = "수량 자동입력 금지"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TextBox1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TextBox1.Location = New System.Drawing.Point(464, 87)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(194, 25)
        Me.TextBox1.TabIndex = 29
        '
        'TB_BarcodeScan
        '
        Me.TB_BarcodeScan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TB_BarcodeScan.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TB_BarcodeScan.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_BarcodeScan.Location = New System.Drawing.Point(181, 114)
        Me.TB_BarcodeScan.Multiline = True
        Me.TB_BarcodeScan.Name = "TB_BarcodeScan"
        Me.TB_BarcodeScan.Size = New System.Drawing.Size(280, 25)
        Me.TB_BarcodeScan.TabIndex = 28
        '
        'TB_ItemCode
        '
        Me.TB_ItemCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ItemCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TB_ItemCode.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_ItemCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_ItemCode.Location = New System.Drawing.Point(181, 60)
        Me.TB_ItemCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_ItemCode.Name = "TB_ItemCode"
        Me.TB_ItemCode.Size = New System.Drawing.Size(280, 25)
        Me.TB_ItemCode.TabIndex = 27
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(16, 60)
        Me.Label12.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(165, 25)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "3. 자재코드(고객사)"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CB_Vendor
        '
        Me.CB_Vendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Vendor.Font = New System.Drawing.Font("굴림", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CB_Vendor.FormattingEnabled = True
        Me.CB_Vendor.Location = New System.Drawing.Point(181, 87)
        Me.CB_Vendor.Margin = New System.Windows.Forms.Padding(0)
        Me.CB_Vendor.Name = "CB_Vendor"
        Me.CB_Vendor.Size = New System.Drawing.Size(280, 25)
        Me.CB_Vendor.TabIndex = 25
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(16, 87)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(165, 25)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "4. 제조사"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("굴림", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Yellow
        Me.Label14.Location = New System.Drawing.Point(465, 219)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(160, 60)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "등록 성공"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Panel7)
        Me.GroupBox1.Location = New System.Drawing.Point(464, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(191, 76)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Barcode 설정"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(68, 51)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(52, 21)
        Me.NumericUpDown1.TabIndex = 24
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 55)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 12)
        Me.Label18.TabIndex = 23
        Me.Label18.Text = "발행매수"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel7.Controls.Add(Me.Label19)
        Me.Panel7.Controls.Add(Me.RB_Supplier)
        Me.Panel7.Controls.Add(Me.RB_Vendor)
        Me.Panel7.Location = New System.Drawing.Point(11, 20)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(168, 25)
        Me.Panel7.TabIndex = 22
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(5, 7)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(29, 12)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "구분"
        '
        'RB_Supplier
        '
        Me.RB_Supplier.AutoSize = True
        Me.RB_Supplier.Checked = True
        Me.RB_Supplier.Location = New System.Drawing.Point(108, 5)
        Me.RB_Supplier.Name = "RB_Supplier"
        Me.RB_Supplier.Size = New System.Drawing.Size(59, 16)
        Me.RB_Supplier.TabIndex = 7
        Me.RB_Supplier.TabStop = True
        Me.RB_Supplier.Text = "공급사"
        Me.RB_Supplier.UseVisualStyleBackColor = True
        '
        'RB_Vendor
        '
        Me.RB_Vendor.AutoSize = True
        Me.RB_Vendor.Location = New System.Drawing.Point(43, 5)
        Me.RB_Vendor.Name = "RB_Vendor"
        Me.RB_Vendor.Size = New System.Drawing.Size(59, 16)
        Me.RB_Vendor.TabIndex = 6
        Me.RB_Vendor.Text = "제조사"
        Me.RB_Vendor.UseVisualStyleBackColor = True
        '
        'BTN_ListAdd
        '
        Me.BTN_ListAdd.Enabled = False
        Me.BTN_ListAdd.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_ListAdd.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.BTN_ListAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_ListAdd.Location = New System.Drawing.Point(471, 149)
        Me.BTN_ListAdd.Name = "BTN_ListAdd"
        Me.BTN_ListAdd.Size = New System.Drawing.Size(120, 71)
        Me.BTN_ListAdd.TabIndex = 20
        Me.BTN_ListAdd.Text = "입고등록"
        Me.BTN_ListAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ListAdd.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.Panel3.Location = New System.Drawing.Point(181, 141)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(280, 145)
        Me.Panel3.TabIndex = 19
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
        Me.TB_Vendor.Location = New System.Drawing.Point(77, 116)
        Me.TB_Vendor.Name = "TB_Vendor"
        Me.TB_Vendor.Size = New System.Drawing.Size(194, 21)
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
        Me.TB_CustomerPartCode.Location = New System.Drawing.Point(77, 89)
        Me.TB_CustomerPartCode.Name = "TB_CustomerPartCode"
        Me.TB_CustomerPartCode.Size = New System.Drawing.Size(194, 21)
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
        Me.TB_Qty.Location = New System.Drawing.Point(77, 62)
        Me.TB_Qty.Name = "TB_Qty"
        Me.TB_Qty.Size = New System.Drawing.Size(194, 21)
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
        Me.TB_LotNo.Location = New System.Drawing.Point(77, 35)
        Me.TB_LotNo.Name = "TB_LotNo"
        Me.TB_LotNo.Size = New System.Drawing.Size(194, 21)
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
        Me.TB_PartNo.Location = New System.Drawing.Point(77, 8)
        Me.TB_PartNo.Name = "TB_PartNo"
        Me.TB_PartNo.Size = New System.Drawing.Size(194, 21)
        Me.TB_PartNo.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(16, 141)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(165, 145)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "6. Scan 결과"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(16, 114)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(165, 25)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "5. Barcode Scan"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_InNo
        '
        Me.TB_InNo.BackColor = System.Drawing.SystemColors.Window
        Me.TB_InNo.Enabled = False
        Me.TB_InNo.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_InNo.Location = New System.Drawing.Point(181, 6)
        Me.TB_InNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_InNo.Name = "TB_InNo"
        Me.TB_InNo.Size = New System.Drawing.Size(280, 25)
        Me.TB_InNo.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 6)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 25)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "1. 입고 No."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_CustomerCode
        '
        Me.TB_CustomerCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerCode.Enabled = False
        Me.TB_CustomerCode.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_CustomerCode.Location = New System.Drawing.Point(341, 33)
        Me.TB_CustomerCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerCode.Name = "TB_CustomerCode"
        Me.TB_CustomerCode.Size = New System.Drawing.Size(120, 25)
        Me.TB_CustomerCode.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(16, 33)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(165, 25)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "2. 사용고객사"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TS_MainBar
        '
        Me.TS_MainBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Search, Me.Form_CLose})
        Me.TS_MainBar.Location = New System.Drawing.Point(0, 0)
        Me.TS_MainBar.Name = "TS_MainBar"
        Me.TS_MainBar.Size = New System.Drawing.Size(1864, 25)
        Me.TS_MainBar.TabIndex = 28
        Me.TS_MainBar.Text = "ToolStrip1"
        '
        'BTN_Search
        '
        Me.BTN_Search.Image = Global.YJ_MMS.My.Resources.Resources.search_121
        Me.BTN_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_Search.Name = "BTN_Search"
        Me.BTN_Search.Size = New System.Drawing.Size(115, 22)
        Me.BTN_Search.Text = "입고리스트 검색"
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
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Grid_DocumentsList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel5)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1864, 748)
        Me.SplitContainer1.SplitterDistance = 341
        Me.SplitContainer1.TabIndex = 29
        '
        'Grid_DocumentsList
        '
        Me.Grid_DocumentsList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_DocumentsList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_DocumentsList.Location = New System.Drawing.Point(0, 94)
        Me.Grid_DocumentsList.Name = "Grid_DocumentsList"
        Me.Grid_DocumentsList.Rows.Count = 2
        Me.Grid_DocumentsList.Rows.DefaultSize = 20
        Me.Grid_DocumentsList.Size = New System.Drawing.Size(341, 654)
        Me.Grid_DocumentsList.StyleInfo = resources.GetString("Grid_DocumentsList.StyleInfo")
        Me.Grid_DocumentsList.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Controls.Add(Me.Label17)
        Me.Panel5.Controls.Add(Me.DTP_End)
        Me.Panel5.Controls.Add(Me.Label15)
        Me.Panel5.Controls.Add(Me.DTP_Start)
        Me.Panel5.Controls.Add(Me.Label16)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(341, 94)
        Me.Panel5.TabIndex = 2
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.RadioButton3)
        Me.Panel6.Controls.Add(Me.RadioButton2)
        Me.Panel6.Controls.Add(Me.RadioButton1)
        Me.Panel6.Location = New System.Drawing.Point(85, 49)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(242, 21)
        Me.Panel6.TabIndex = 25
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Location = New System.Drawing.Point(178, 1)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(59, 16)
        Me.RadioButton3.TabIndex = 27
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "미완료"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(92, 1)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton2.TabIndex = 26
        Me.RadioButton2.Text = "완료"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(6, 1)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton1.TabIndex = 25
        Me.RadioButton1.Text = "전체"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(9, 49)
        Me.Label17.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(76, 21)
        Me.Label17.TabIndex = 21
        Me.Label17.Text = "완료구분"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DTP_End
        '
        Me.DTP_End.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_End.Location = New System.Drawing.Point(225, 22)
        Me.DTP_End.Name = "DTP_End"
        Me.DTP_End.Size = New System.Drawing.Size(102, 21)
        Me.DTP_End.TabIndex = 20
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(199, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(14, 12)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "~"
        '
        'DTP_Start
        '
        Me.DTP_Start.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_Start.Location = New System.Drawing.Point(85, 22)
        Me.DTP_Start.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.DTP_Start.Name = "DTP_Start"
        Me.DTP_Start.Size = New System.Drawing.Size(102, 21)
        Me.DTP_Start.TabIndex = 18
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(9, 22)
        Me.Label16.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 21)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "입고일자"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        '
        'Grid_Menu
        '
        Me.Grid_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_RePrint})
        Me.Grid_Menu.Name = "Grid_Menu"
        Me.Grid_Menu.Size = New System.Drawing.Size(111, 26)
        '
        'BTN_RePrint
        '
        Me.BTN_RePrint.Name = "BTN_RePrint"
        Me.BTN_RePrint.Size = New System.Drawing.Size(110, 22)
        Me.BTN_RePrint.Text = "재발행"
        '
        'TB_CustomerName
        '
        Me.TB_CustomerName.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerName.Enabled = False
        Me.TB_CustomerName.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_CustomerName.Location = New System.Drawing.Point(181, 33)
        Me.TB_CustomerName.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerName.Name = "TB_CustomerName"
        Me.TB_CustomerName.Size = New System.Drawing.Size(160, 25)
        Me.TB_CustomerName.TabIndex = 31
        '
        'frm_Material_Warehousing_With_Label
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1864, 773)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TS_MainBar)
        Me.Name = "frm_Material_Warehousing_With_Label"
        Me.Text = "자재입고(라벨발행)"
        CType(Me.Grid_PartList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.Grid_MaterialList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TS_MainBar.ResumeLayout(False)
        Me.TS_MainBar.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Grid_DocumentsList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Grid_Menu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grid_PartList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents TS_MainBar As ToolStrip
    Friend WithEvents BTN_Search As ToolStripButton
    Friend WithEvents Form_CLose As ToolStripButton
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Grid_DocumentsList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Grid_MaterialList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TB_Supplier As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TB_DocumentNo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TB_InNo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TB_CustomerCode As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents TB_CustomerPartCode As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TB_Qty As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TB_LotNo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TB_PartNo As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents BTN_ListAdd As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TB_Vendor As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents BTN_Save As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Label17 As Label
    Friend WithEvents DTP_End As DateTimePicker
    Friend WithEvents Label15 As Label
    Friend WithEvents DTP_Start As DateTimePicker
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label19 As Label
    Friend WithEvents RB_Supplier As RadioButton
    Friend WithEvents RB_Vendor As RadioButton
    Friend WithEvents TB_ItemCode As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents CB_Vendor As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TB_BarcodeScan As TextBox
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label18 As Label
    Friend WithEvents Grid_Menu As ContextMenuStrip
    Friend WithEvents BTN_RePrint As ToolStripMenuItem
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents TB_CustomerName As TextBox
End Class
