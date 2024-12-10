<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Material_Warehousing_New
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Material_Warehousing_New))
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
        Me.Grid_Menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_RePrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_RowDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TB_CustomerName = New System.Windows.Forms.TextBox()
        Me.TB_CustomerCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.C1DockingTab1 = New C1.Win.C1Command.C1DockingTab()
        Me.C1DockingTabPage1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.C1DockingTabPage2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.TB_BarcodeScan = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TB_CustomerPartCode = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TB_Qty = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TB_LotNo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TB_PartNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.C1DockingTabPage3 = New C1.Win.C1Command.C1DockingTabPage()
        Me.BTN_Reload_Vendor = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.BTN_ListAdd = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        CType(Me.Grid_PartList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.Grid_MaterialList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TS_MainBar.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Grid_DocumentsList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Grid_Menu.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.C1DockingTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1DockingTab1.SuspendLayout()
        Me.C1DockingTabPage1.SuspendLayout()
        Me.C1DockingTabPage2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.C1DockingTabPage3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grid_PartList
        '
        Me.Grid_PartList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_PartList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_PartList.Location = New System.Drawing.Point(0, 315)
        Me.Grid_PartList.Name = "Grid_PartList"
        Me.Grid_PartList.Rows.Count = 2
        Me.Grid_PartList.Rows.DefaultSize = 20
        Me.Grid_PartList.Size = New System.Drawing.Size(1025, 433)
        Me.Grid_PartList.StyleInfo = resources.GetString("Grid_PartList.StyleInfo")
        Me.Grid_PartList.TabIndex = 0
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
        Me.Grid_MaterialList.TabIndex = 1
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
        Me.Panel1.TabIndex = 0
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
        Me.BTN_Save.TabIndex = 4
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
        Me.TB_Supplier.TabIndex = 3
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
        Me.Label2.TabIndex = 2
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
        Me.TB_DocumentNo.TabIndex = 1
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
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "문서번호"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.Controls.Add(Me.C1DockingTab1)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1025, 315)
        Me.Panel2.TabIndex = 32
        '
        'TS_MainBar
        '
        Me.TS_MainBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Search, Me.Form_CLose})
        Me.TS_MainBar.Location = New System.Drawing.Point(0, 0)
        Me.TS_MainBar.Name = "TS_MainBar"
        Me.TS_MainBar.Size = New System.Drawing.Size(1864, 25)
        Me.TS_MainBar.TabIndex = 0
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
        Me.Panel5.TabIndex = 0
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
        Me.Panel6.TabIndex = 0
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Location = New System.Drawing.Point(178, 1)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(59, 16)
        Me.RadioButton3.TabIndex = 1
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
        Me.RadioButton2.TabIndex = 0
        Me.RadioButton2.Text = "완료"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(6, 1)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton1.TabIndex = 0
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
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "완료구분"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DTP_End
        '
        Me.DTP_End.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_End.Location = New System.Drawing.Point(225, 22)
        Me.DTP_End.Name = "DTP_End"
        Me.DTP_End.Size = New System.Drawing.Size(102, 21)
        Me.DTP_End.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(199, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(14, 12)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "~"
        '
        'DTP_Start
        '
        Me.DTP_Start.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_Start.Location = New System.Drawing.Point(85, 22)
        Me.DTP_Start.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.DTP_Start.Name = "DTP_Start"
        Me.DTP_Start.Size = New System.Drawing.Size(102, 21)
        Me.DTP_Start.TabIndex = 1
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
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "입고일자"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Grid_Menu
        '
        Me.Grid_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_RePrint, Me.ToolStripSeparator1, Me.BTN_RowDelete})
        Me.Grid_Menu.Name = "Grid_Menu"
        Me.Grid_Menu.Size = New System.Drawing.Size(159, 54)
        '
        'BTN_RePrint
        '
        Me.BTN_RePrint.Name = "BTN_RePrint"
        Me.BTN_RePrint.Size = New System.Drawing.Size(158, 22)
        Me.BTN_RePrint.Text = "재발행"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(155, 6)
        '
        'BTN_RowDelete
        '
        Me.BTN_RowDelete.Name = "BTN_RowDelete"
        Me.BTN_RowDelete.Size = New System.Drawing.Size(158, 22)
        Me.BTN_RowDelete.Text = "입고 취소(삭제)"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.BTN_ListAdd)
        Me.Panel3.Controls.Add(Me.CheckBox3)
        Me.Panel3.Controls.Add(Me.TB_CustomerName)
        Me.Panel3.Controls.Add(Me.TB_CustomerCode)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1025, 43)
        Me.Panel3.TabIndex = 0
        '
        'TB_CustomerName
        '
        Me.TB_CustomerName.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerName.Enabled = False
        Me.TB_CustomerName.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_CustomerName.Location = New System.Drawing.Point(179, 10)
        Me.TB_CustomerName.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerName.Name = "TB_CustomerName"
        Me.TB_CustomerName.Size = New System.Drawing.Size(160, 25)
        Me.TB_CustomerName.TabIndex = 1
        '
        'TB_CustomerCode
        '
        Me.TB_CustomerCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerCode.Enabled = False
        Me.TB_CustomerCode.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_CustomerCode.Location = New System.Drawing.Point(339, 10)
        Me.TB_CustomerCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerCode.Name = "TB_CustomerCode"
        Me.TB_CustomerCode.Size = New System.Drawing.Size(120, 25)
        Me.TB_CustomerCode.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.CadetBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(14, 10)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(165, 25)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "사용고객사"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'C1DockingTab1
        '
        Me.C1DockingTab1.Controls.Add(Me.C1DockingTabPage1)
        Me.C1DockingTab1.Controls.Add(Me.C1DockingTabPage2)
        Me.C1DockingTab1.Controls.Add(Me.C1DockingTabPage3)
        Me.C1DockingTab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1DockingTab1.Location = New System.Drawing.Point(0, 43)
        Me.C1DockingTab1.Name = "C1DockingTab1"
        Me.C1DockingTab1.SelectedTabBold = True
        Me.C1DockingTab1.ShowToolTips = True
        Me.C1DockingTab1.Size = New System.Drawing.Size(1025, 272)
        Me.C1DockingTab1.TabAreaBackColor = System.Drawing.Color.LightSteelBlue
        Me.C1DockingTab1.TabIndex = 1
        Me.C1DockingTab1.TabsSpacing = -11
        Me.C1DockingTab1.TabStyle = C1.Win.C1Command.TabStyleEnum.Sloping
        Me.C1DockingTab1.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
        '
        'C1DockingTabPage1
        '
        Me.C1DockingTabPage1.BackColor = System.Drawing.Color.AliceBlue
        Me.C1DockingTabPage1.CaptionText = "제조사 바코드가 있을 경우 이탭을 선택하십시오."
        Me.C1DockingTabPage1.Controls.Add(Me.CheckBox2)
        Me.C1DockingTabPage1.Controls.Add(Me.Label18)
        Me.C1DockingTabPage1.Controls.Add(Me.ListBox1)
        Me.C1DockingTabPage1.Controls.Add(Me.CheckBox1)
        Me.C1DockingTabPage1.Controls.Add(Me.TextBox1)
        Me.C1DockingTabPage1.Controls.Add(Me.Label12)
        Me.C1DockingTabPage1.Controls.Add(Me.Label4)
        Me.C1DockingTabPage1.Controls.Add(Me.BTN_Reload_Vendor)
        Me.C1DockingTabPage1.Controls.Add(Me.ComboBox1)
        Me.C1DockingTabPage1.Controls.Add(Me.Label3)
        Me.C1DockingTabPage1.Controls.Add(Me.Panel4)
        Me.C1DockingTabPage1.Controls.Add(Me.Label7)
        Me.C1DockingTabPage1.Controls.Add(Me.TB_BarcodeScan)
        Me.C1DockingTabPage1.Controls.Add(Me.Label6)
        Me.C1DockingTabPage1.Location = New System.Drawing.Point(1, 25)
        Me.C1DockingTabPage1.Name = "C1DockingTabPage1"
        Me.C1DockingTabPage1.Size = New System.Drawing.Size(1023, 246)
        Me.C1DockingTabPage1.TabBackColor = System.Drawing.Color.LightSteelBlue
        Me.C1DockingTabPage1.TabBackColorSelected = System.Drawing.Color.SteelBlue
        Me.C1DockingTabPage1.TabForeColorSelected = System.Drawing.Color.White
        Me.C1DockingTabPage1.TabIndex = 0
        Me.C1DockingTabPage1.Text = "제조사(바코드 有)"
        '
        'C1DockingTabPage2
        '
        Me.C1DockingTabPage2.BackColor = System.Drawing.Color.AliceBlue
        Me.C1DockingTabPage2.CaptionText = "제조사 바코드가 없을 경우 이탭을 선택 하십시오."
        Me.C1DockingTabPage2.Controls.Add(Me.TextBox5)
        Me.C1DockingTabPage2.Controls.Add(Me.Label22)
        Me.C1DockingTabPage2.Controls.Add(Me.TextBox4)
        Me.C1DockingTabPage2.Controls.Add(Me.Label21)
        Me.C1DockingTabPage2.Controls.Add(Me.Label20)
        Me.C1DockingTabPage2.Controls.Add(Me.TextBox3)
        Me.C1DockingTabPage2.Controls.Add(Me.Label19)
        Me.C1DockingTabPage2.Controls.Add(Me.ComboBox2)
        Me.C1DockingTabPage2.Controls.Add(Me.Label14)
        Me.C1DockingTabPage2.Controls.Add(Me.TextBox2)
        Me.C1DockingTabPage2.Controls.Add(Me.Label13)
        Me.C1DockingTabPage2.Location = New System.Drawing.Point(1, 25)
        Me.C1DockingTabPage2.Name = "C1DockingTabPage2"
        Me.C1DockingTabPage2.Size = New System.Drawing.Size(1023, 246)
        Me.C1DockingTabPage2.TabBackColor = System.Drawing.Color.LightSteelBlue
        Me.C1DockingTabPage2.TabBackColorSelected = System.Drawing.Color.SteelBlue
        Me.C1DockingTabPage2.TabForeColorSelected = System.Drawing.Color.White
        Me.C1DockingTabPage2.TabIndex = 1
        Me.C1DockingTabPage2.Text = "제조사(바코드 無)"
        '
        'TB_BarcodeScan
        '
        Me.TB_BarcodeScan.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TB_BarcodeScan.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_BarcodeScan.Location = New System.Drawing.Point(178, 58)
        Me.TB_BarcodeScan.Multiline = True
        Me.TB_BarcodeScan.Name = "TB_BarcodeScan"
        Me.TB_BarcodeScan.Size = New System.Drawing.Size(280, 25)
        Me.TB_BarcodeScan.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(13, 58)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(165, 25)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Barcode Scan"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.TB_CustomerPartCode)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.TB_Qty)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.TB_LotNo)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.TB_PartNo)
        Me.Panel4.Enabled = False
        Me.Panel4.Location = New System.Drawing.Point(178, 87)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(280, 121)
        Me.Panel4.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(10, 91)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 16)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "자재코드 :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_CustomerPartCode
        '
        Me.TB_CustomerPartCode.Location = New System.Drawing.Point(77, 89)
        Me.TB_CustomerPartCode.Name = "TB_CustomerPartCode"
        Me.TB_CustomerPartCode.Size = New System.Drawing.Size(194, 21)
        Me.TB_CustomerPartCode.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(10, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 16)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "수량 :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_Qty
        '
        Me.TB_Qty.Location = New System.Drawing.Point(77, 62)
        Me.TB_Qty.Name = "TB_Qty"
        Me.TB_Qty.Size = New System.Drawing.Size(194, 21)
        Me.TB_Qty.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(10, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 16)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Lot No. :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_LotNo
        '
        Me.TB_LotNo.Location = New System.Drawing.Point(77, 35)
        Me.TB_LotNo.Name = "TB_LotNo"
        Me.TB_LotNo.Size = New System.Drawing.Size(194, 21)
        Me.TB_LotNo.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(10, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Part No. :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_PartNo
        '
        Me.TB_PartNo.Location = New System.Drawing.Point(77, 8)
        Me.TB_PartNo.Name = "TB_PartNo"
        Me.TB_PartNo.Size = New System.Drawing.Size(194, 21)
        Me.TB_PartNo.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(13, 87)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(165, 121)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Scan 결과"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 31)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 23)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Vendor"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(178, 31)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(280, 23)
        Me.ComboBox1.TabIndex = 1
        '
        'C1DockingTabPage3
        '
        Me.C1DockingTabPage3.BackColor = System.Drawing.Color.AliceBlue
        Me.C1DockingTabPage3.CaptionText = "공급사 바코드가 있을 경우 이탭을 선택 하십시오."
        Me.C1DockingTabPage3.Controls.Add(Me.Label30)
        Me.C1DockingTabPage3.Controls.Add(Me.TextBox11)
        Me.C1DockingTabPage3.Controls.Add(Me.Label29)
        Me.C1DockingTabPage3.Controls.Add(Me.Panel7)
        Me.C1DockingTabPage3.Controls.Add(Me.Label28)
        Me.C1DockingTabPage3.Controls.Add(Me.TextBox6)
        Me.C1DockingTabPage3.Controls.Add(Me.Label23)
        Me.C1DockingTabPage3.Location = New System.Drawing.Point(1, 25)
        Me.C1DockingTabPage3.Name = "C1DockingTabPage3"
        Me.C1DockingTabPage3.Size = New System.Drawing.Size(1023, 246)
        Me.C1DockingTabPage3.TabBackColor = System.Drawing.Color.LightSteelBlue
        Me.C1DockingTabPage3.TabBackColorSelected = System.Drawing.Color.SteelBlue
        Me.C1DockingTabPage3.TabForeColorSelected = System.Drawing.Color.White
        Me.C1DockingTabPage3.TabIndex = 2
        Me.C1DockingTabPage3.Text = "공급사"
        '
        'BTN_Reload_Vendor
        '
        Me.BTN_Reload_Vendor.Location = New System.Drawing.Point(321, 7)
        Me.BTN_Reload_Vendor.Name = "BTN_Reload_Vendor"
        Me.BTN_Reload_Vendor.Size = New System.Drawing.Size(137, 19)
        Me.BTN_Reload_Vendor.TabIndex = 6
        Me.BTN_Reload_Vendor.Text = "제조사 다시불러오기"
        Me.BTN_Reload_Vendor.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(459, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(359, 27)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "※ 자재코드를 찾지 못했습니다. 품번을 입력 하십시오." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    수동입력된 품번의 자재 사양과 일치 하는지 확인 하십시오."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(99, 211)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(359, 12)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "※ 바코드를 제대로 읽지 못했습니다."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TextBox1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TextBox1.Location = New System.Drawing.Point(626, 58)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(192, 25)
        Me.TextBox1.TabIndex = 10
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.Color.LightSlateGray
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Location = New System.Drawing.Point(461, 58)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(165, 25)
        Me.CheckBox1.TabIndex = 11
        Me.CheckBox1.Text = "품번 수동입력"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.ForeColor = System.Drawing.Color.Red
        Me.Label18.Location = New System.Drawing.Point(459, 105)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(359, 12)
        Me.Label18.TabIndex = 16
        Me.Label18.Text = "※ 자재코드를 2개 이상 찾았습니다. 선택하십시오."
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(626, 120)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(192, 88)
        Me.ListBox1.TabIndex = 14
        '
        'CheckBox2
        '
        Me.CheckBox2.BackColor = System.Drawing.Color.LightSlateGray
        Me.CheckBox2.Enabled = False
        Me.CheckBox2.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CheckBox2.ForeColor = System.Drawing.Color.White
        Me.CheckBox2.Location = New System.Drawing.Point(461, 120)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(165, 88)
        Me.CheckBox2.TabIndex = 17
        Me.CheckBox2.Text = "품번 선택"
        Me.CheckBox2.UseVisualStyleBackColor = False
        '
        'CheckBox3
        '
        Me.CheckBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(755, 17)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(156, 16)
        Me.CheckBox3.TabIndex = 3
        Me.CheckBox3.Text = "나를 믿고 즉시 등록하기"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'BTN_ListAdd
        '
        Me.BTN_ListAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_ListAdd.Enabled = False
        Me.BTN_ListAdd.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_ListAdd.Image = Global.YJ_MMS.My.Resources.Resources.plus_blue
        Me.BTN_ListAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_ListAdd.Location = New System.Drawing.Point(917, 9)
        Me.BTN_ListAdd.Name = "BTN_ListAdd"
        Me.BTN_ListAdd.Size = New System.Drawing.Size(105, 28)
        Me.BTN_ListAdd.TabIndex = 21
        Me.BTN_ListAdd.Text = "입고등록"
        Me.BTN_ListAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ListAdd.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox2.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TextBox2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TextBox2.Location = New System.Drawing.Point(178, 13)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(280, 25)
        Me.TextBox2.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(13, 13)
        Me.Label13.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(165, 25)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "자재품번"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold)
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(178, 40)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(280, 23)
        Me.ComboBox2.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(13, 40)
        Me.Label14.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(165, 23)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Vendor"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.Enabled = False
        Me.TextBox3.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TextBox3.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TextBox3.Location = New System.Drawing.Point(178, 65)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(834, 25)
        Me.TextBox3.TabIndex = 9
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(13, 65)
        Me.Label19.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(165, 25)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "Part No.(사양)"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.Red
        Me.Label20.Location = New System.Drawing.Point(176, 93)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(301, 24)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "※ 입력된 품번의 자재 사양입니다. 확인하여 주십시오." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    규격이 다를 경우, 관리자에게 문의 하십시오."
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TextBox4.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TextBox4.Location = New System.Drawing.Point(178, 120)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(280, 25)
        Me.TextBox4.TabIndex = 12
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(13, 120)
        Me.Label21.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(165, 25)
        Me.Label21.TabIndex = 11
        Me.Label21.Text = "Lot No."
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TextBox5.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TextBox5.Location = New System.Drawing.Point(178, 149)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(280, 25)
        Me.TextBox5.TabIndex = 14
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(13, 149)
        Me.Label22.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(165, 25)
        Me.Label22.TabIndex = 13
        Me.Label22.Text = "수량"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox6
        '
        Me.TextBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox6.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TextBox6.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TextBox6.Location = New System.Drawing.Point(178, 13)
        Me.TextBox6.Multiline = True
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(834, 25)
        Me.TextBox6.TabIndex = 5
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(13, 13)
        Me.Label23.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(165, 25)
        Me.Label23.TabIndex = 4
        Me.Label23.Text = "Barcode Scan"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.Label24)
        Me.Panel7.Controls.Add(Me.TextBox7)
        Me.Panel7.Controls.Add(Me.Label25)
        Me.Panel7.Controls.Add(Me.TextBox8)
        Me.Panel7.Controls.Add(Me.Label26)
        Me.Panel7.Controls.Add(Me.TextBox9)
        Me.Panel7.Controls.Add(Me.Label27)
        Me.Panel7.Controls.Add(Me.TextBox10)
        Me.Panel7.Enabled = False
        Me.Panel7.Location = New System.Drawing.Point(178, 40)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(834, 121)
        Me.Panel7.TabIndex = 7
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(10, 91)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(61, 16)
        Me.Label24.TabIndex = 6
        Me.Label24.Text = "자재코드 :"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(77, 89)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(327, 21)
        Me.TextBox7.TabIndex = 7
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(10, 64)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 16)
        Me.Label25.TabIndex = 4
        Me.Label25.Text = "수량 :"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(77, 62)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(327, 21)
        Me.TextBox8.TabIndex = 5
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(10, 37)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(61, 16)
        Me.Label26.TabIndex = 2
        Me.Label26.Text = "Lot No. :"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(77, 35)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(327, 21)
        Me.TextBox9.TabIndex = 3
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(10, 10)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(61, 16)
        Me.Label27.TabIndex = 0
        Me.Label27.Text = "Part No. :"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(77, 8)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(327, 21)
        Me.TextBox10.TabIndex = 1
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(13, 40)
        Me.Label28.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(165, 121)
        Me.Label28.TabIndex = 6
        Me.Label28.Text = "Scan 결과"
        '
        'TextBox11
        '
        Me.TextBox11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox11.Enabled = False
        Me.TextBox11.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold)
        Me.TextBox11.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TextBox11.Location = New System.Drawing.Point(178, 163)
        Me.TextBox11.Multiline = True
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(834, 25)
        Me.TextBox11.TabIndex = 11
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(13, 163)
        Me.Label29.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(165, 25)
        Me.Label29.TabIndex = 10
        Me.Label29.Text = "사양"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.Color.Red
        Me.Label30.Location = New System.Drawing.Point(176, 191)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(301, 24)
        Me.Label30.TabIndex = 12
        Me.Label30.Text = "※ 입력된 품번의 자재 사양입니다. 확인하여 주십시오." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    규격이 다를 경우, 관리자에게 문의 하십시오."
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frm_Material_Warehousing_New
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1864, 773)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TS_MainBar)
        Me.Name = "frm_Material_Warehousing_New"
        Me.Text = "자재입고(라벨발행)_New"
        CType(Me.Grid_PartList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.Grid_MaterialList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
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
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.C1DockingTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1DockingTab1.ResumeLayout(False)
        Me.C1DockingTabPage1.ResumeLayout(False)
        Me.C1DockingTabPage1.PerformLayout()
        Me.C1DockingTabPage2.ResumeLayout(False)
        Me.C1DockingTabPage2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.C1DockingTabPage3.ResumeLayout(False)
        Me.C1DockingTabPage3.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
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
    Friend WithEvents Grid_Menu As ContextMenuStrip
    Friend WithEvents BTN_RePrint As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BTN_RowDelete As ToolStripMenuItem
    Friend WithEvents Panel3 As Panel
    Friend WithEvents C1DockingTab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents C1DockingTabPage1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents C1DockingTabPage2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents TB_CustomerName As TextBox
    Friend WithEvents TB_CustomerCode As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TB_BarcodeScan As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents TB_CustomerPartCode As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TB_Qty As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TB_LotNo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TB_PartNo As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents C1DockingTabPage3 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents BTN_Reload_Vendor As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents Label18 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents BTN_ListAdd As Button
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label24 As Label
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents TextBox11 As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
End Class
