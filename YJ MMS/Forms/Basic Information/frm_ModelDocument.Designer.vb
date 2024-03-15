<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_ModelDocument
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ModelDocument))
        Me.TS_MainBar = New System.Windows.Forms.ToolStrip()
        Me.BTN_Search = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_Save = New System.Windows.Forms.ToolStripButton()
        Me.Form_CLose = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Grid_ModelList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TB_SearchModel = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TB_SearchCustomer = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Grid_Documents = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Grid_BOM = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Grid_Coordinates = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Grid_BOM_Total = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BTN_Result = New System.Windows.Forms.Button()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Grid_Process = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BTN_NewManagementNo = New System.Windows.Forms.Button()
        Me.CB_ManagementNo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TB_ItemName = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TB_ModelName = New System.Windows.Forms.TextBox()
        Me.TB_ModelCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TB_CustomerCode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TB_CustomerName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CMS_GridMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_ProcessAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_ProcessDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TS_MainBar.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Grid_ModelList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.Grid_Documents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.Grid_BOM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.Grid_Coordinates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.Grid_BOM_Total, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.Grid_Process, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.CMS_GridMenu.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TS_MainBar
        '
        Me.TS_MainBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Search, Me.ToolStripSeparator2, Me.BTN_Save, Me.Form_CLose})
        Me.TS_MainBar.Location = New System.Drawing.Point(0, 0)
        Me.TS_MainBar.Name = "TS_MainBar"
        Me.TS_MainBar.Size = New System.Drawing.Size(1364, 25)
        Me.TS_MainBar.TabIndex = 0
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'BTN_Save
        '
        Me.BTN_Save.Enabled = False
        Me.BTN_Save.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.BTN_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(51, 22)
        Me.BTN_Save.Text = "저장"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Grid_ModelList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.Beige
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1364, 748)
        Me.SplitContainer1.SplitterDistance = 663
        Me.SplitContainer1.TabIndex = 2
        '
        'Grid_ModelList
        '
        Me.Grid_ModelList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_ModelList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_ModelList.Location = New System.Drawing.Point(0, 81)
        Me.Grid_ModelList.Name = "Grid_ModelList"
        Me.Grid_ModelList.Rows.Count = 2
        Me.Grid_ModelList.Rows.DefaultSize = 20
        Me.Grid_ModelList.Size = New System.Drawing.Size(663, 667)
        Me.Grid_ModelList.StyleInfo = resources.GetString("Grid_ModelList.StyleInfo")
        Me.Grid_ModelList.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TB_SearchModel)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TB_SearchCustomer)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(663, 81)
        Me.Panel1.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(323, 12)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "해당 모델을 더블클릭(왼쪽) 하시면 자료를 볼 수 있습니다."
        '
        'TB_SearchModel
        '
        Me.TB_SearchModel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_SearchModel.BackColor = System.Drawing.SystemColors.Window
        Me.TB_SearchModel.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_SearchModel.Location = New System.Drawing.Point(122, 29)
        Me.TB_SearchModel.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_SearchModel.Name = "TB_SearchModel"
        Me.TB_SearchModel.Size = New System.Drawing.Size(541, 21)
        Me.TB_SearchModel.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1, 29)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 21)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "모델명"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_SearchCustomer
        '
        Me.TB_SearchCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_SearchCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.TB_SearchCustomer.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_SearchCustomer.Location = New System.Drawing.Point(122, 6)
        Me.TB_SearchCustomer.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_SearchCustomer.Name = "TB_SearchCustomer"
        Me.TB_SearchCustomer.Size = New System.Drawing.Size(541, 21)
        Me.TB_SearchCustomer.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(1, 6)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 21)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "고객사명"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 234)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(697, 514)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Grid_Documents)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(689, 488)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "자료목록"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Grid_Documents
        '
        Me.Grid_Documents.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_Documents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_Documents.Location = New System.Drawing.Point(3, 3)
        Me.Grid_Documents.Name = "Grid_Documents"
        Me.Grid_Documents.Rows.Count = 2
        Me.Grid_Documents.Rows.DefaultSize = 20
        Me.Grid_Documents.Size = New System.Drawing.Size(683, 482)
        Me.Grid_Documents.StyleInfo = resources.GetString("Grid_Documents.StyleInfo")
        Me.Grid_Documents.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Grid_BOM)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(689, 488)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "BOM(PL)"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Grid_BOM
        '
        Me.Grid_BOM.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_BOM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_BOM.Location = New System.Drawing.Point(3, 15)
        Me.Grid_BOM.Name = "Grid_BOM"
        Me.Grid_BOM.Rows.Count = 2
        Me.Grid_BOM.Rows.DefaultSize = 20
        Me.Grid_BOM.Size = New System.Drawing.Size(683, 470)
        Me.Grid_BOM.StyleInfo = resources.GetString("Grid_BOM.StyleInfo")
        Me.Grid_BOM.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label11.Location = New System.Drawing.Point(3, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 12)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Label11"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Grid_Coordinates)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(689, 488)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "좌표데이터"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Grid_Coordinates
        '
        Me.Grid_Coordinates.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_Coordinates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_Coordinates.Location = New System.Drawing.Point(0, 12)
        Me.Grid_Coordinates.Name = "Grid_Coordinates"
        Me.Grid_Coordinates.Rows.Count = 2
        Me.Grid_Coordinates.Rows.DefaultSize = 20
        Me.Grid_Coordinates.Size = New System.Drawing.Size(689, 476)
        Me.Grid_Coordinates.StyleInfo = resources.GetString("Grid_Coordinates.StyleInfo")
        Me.Grid_Coordinates.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label12.Location = New System.Drawing.Point(0, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 12)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Label12"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Grid_BOM_Total)
        Me.TabPage4.Controls.Add(Me.BTN_Result)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(689, 488)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "BOM+좌표데이터"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Grid_BOM_Total
        '
        Me.Grid_BOM_Total.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_BOM_Total.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_BOM_Total.Location = New System.Drawing.Point(0, 50)
        Me.Grid_BOM_Total.Name = "Grid_BOM_Total"
        Me.Grid_BOM_Total.Rows.Count = 2
        Me.Grid_BOM_Total.Rows.DefaultSize = 20
        Me.Grid_BOM_Total.Size = New System.Drawing.Size(689, 438)
        Me.Grid_BOM_Total.StyleInfo = resources.GetString("Grid_BOM_Total.StyleInfo")
        Me.Grid_BOM_Total.TabIndex = 3
        '
        'BTN_Result
        '
        Me.BTN_Result.Dock = System.Windows.Forms.DockStyle.Top
        Me.BTN_Result.Location = New System.Drawing.Point(0, 0)
        Me.BTN_Result.Name = "BTN_Result"
        Me.BTN_Result.Size = New System.Drawing.Size(689, 50)
        Me.BTN_Result.TabIndex = 4
        Me.BTN_Result.Text = "BOM+좌표데이터 합치기"
        Me.BTN_Result.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.TextBox1)
        Me.TabPage5.Controls.Add(Me.Label16)
        Me.TabPage5.Controls.Add(Me.Panel4)
        Me.TabPage5.Controls.Add(Me.Label15)
        Me.TabPage5.Controls.Add(Me.Label14)
        Me.TabPage5.Controls.Add(Me.Label13)
        Me.TabPage5.Controls.Add(Me.Grid_Process)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(689, 488)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "공정 및 특이사항"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label13.Location = New System.Drawing.Point(13, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 12)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "1. 공정흐름"
        '
        'Grid_Process
        '
        Me.Grid_Process.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_Process.Location = New System.Drawing.Point(28, 36)
        Me.Grid_Process.Name = "Grid_Process"
        Me.Grid_Process.Rows.Count = 2
        Me.Grid_Process.Rows.DefaultSize = 20
        Me.Grid_Process.Rows.MaxSize = 40
        Me.Grid_Process.Rows.MinSize = 30
        Me.Grid_Process.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.Grid_Process.ScrollOptions = C1.Win.C1FlexGrid.ScrollFlags.AlwaysVisible
        Me.Grid_Process.Size = New System.Drawing.Size(653, 93)
        Me.Grid_Process.StyleInfo = resources.GetString("Grid_Process.StyleInfo")
        Me.Grid_Process.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel3.Controls.Add(Me.BTN_NewManagementNo)
        Me.Panel3.Controls.Add(Me.CB_ManagementNo)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(697, 234)
        Me.Panel3.TabIndex = 0
        '
        'BTN_NewManagementNo
        '
        Me.BTN_NewManagementNo.Image = Global.YJ_MMS.My.Resources.Resources.plus_blue
        Me.BTN_NewManagementNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_NewManagementNo.Location = New System.Drawing.Point(319, 195)
        Me.BTN_NewManagementNo.Margin = New System.Windows.Forms.Padding(0)
        Me.BTN_NewManagementNo.Name = "BTN_NewManagementNo"
        Me.BTN_NewManagementNo.Size = New System.Drawing.Size(85, 22)
        Me.BTN_NewManagementNo.TabIndex = 4
        Me.BTN_NewManagementNo.Text = "신규생성"
        Me.BTN_NewManagementNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_NewManagementNo.UseVisualStyleBackColor = True
        Me.BTN_NewManagementNo.Visible = False
        '
        'CB_ManagementNo
        '
        Me.CB_ManagementNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_ManagementNo.FormattingEnabled = True
        Me.CB_ManagementNo.Location = New System.Drawing.Point(139, 196)
        Me.CB_ManagementNo.Name = "CB_ManagementNo"
        Me.CB_ManagementNo.Size = New System.Drawing.Size(180, 20)
        Me.CB_ManagementNo.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(19, 196)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 20)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "관리번호"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.TB_ItemName)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.TB_ModelName)
        Me.Panel2.Controls.Add(Me.TB_ModelCode)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.TB_CustomerCode)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.TB_CustomerName)
        Me.Panel2.Location = New System.Drawing.Point(10, 65)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(619, 119)
        Me.Panel2.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(7, 83)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 21)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "품목명"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_ItemName
        '
        Me.TB_ItemName.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ItemName.Enabled = False
        Me.TB_ItemName.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_ItemName.Location = New System.Drawing.Point(127, 83)
        Me.TB_ItemName.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_ItemName.Name = "TB_ItemName"
        Me.TB_ItemName.Size = New System.Drawing.Size(480, 21)
        Me.TB_ItemName.TabIndex = 10
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(307, 60)
        Me.Label22.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(120, 21)
        Me.Label22.TabIndex = 7
        Me.Label22.Text = "모델명"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_ModelName
        '
        Me.TB_ModelName.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ModelName.Enabled = False
        Me.TB_ModelName.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_ModelName.Location = New System.Drawing.Point(427, 60)
        Me.TB_ModelName.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_ModelName.Name = "TB_ModelName"
        Me.TB_ModelName.Size = New System.Drawing.Size(180, 21)
        Me.TB_ModelName.TabIndex = 8
        '
        'TB_ModelCode
        '
        Me.TB_ModelCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ModelCode.Enabled = False
        Me.TB_ModelCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_ModelCode.Location = New System.Drawing.Point(127, 60)
        Me.TB_ModelCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_ModelCode.Name = "TB_ModelCode"
        Me.TB_ModelCode.Size = New System.Drawing.Size(180, 21)
        Me.TB_ModelCode.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(7, 60)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 21)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "모델 코드"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(3, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 24)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "[ 기본정보 ]"
        '
        'TB_CustomerCode
        '
        Me.TB_CustomerCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerCode.Enabled = False
        Me.TB_CustomerCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_CustomerCode.Location = New System.Drawing.Point(127, 37)
        Me.TB_CustomerCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerCode.Name = "TB_CustomerCode"
        Me.TB_CustomerCode.Size = New System.Drawing.Size(180, 21)
        Me.TB_CustomerCode.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(307, 37)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 21)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "고객사명"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(7, 37)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 21)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "고객사 코드"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_CustomerName
        '
        Me.TB_CustomerName.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerName.Enabled = False
        Me.TB_CustomerName.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_CustomerName.Location = New System.Drawing.Point(427, 37)
        Me.TB_CustomerName.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerName.Name = "TB_CustomerName"
        Me.TB_CustomerName.Size = New System.Drawing.Size(180, 21)
        Me.TB_CustomerName.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.RoyalBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("굴림", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(10, 10)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(221, 32)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "모델별 자료 관리"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CMS_GridMenu
        '
        Me.CMS_GridMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_ProcessAdd, Me.BTN_ProcessDelete})
        Me.CMS_GridMenu.Name = "ContextMenuStrip1"
        Me.CMS_GridMenu.Size = New System.Drawing.Size(171, 48)
        '
        'BTN_ProcessAdd
        '
        Me.BTN_ProcessAdd.Name = "BTN_ProcessAdd"
        Me.BTN_ProcessAdd.Size = New System.Drawing.Size(170, 22)
        Me.BTN_ProcessAdd.Text = "공정 추가(오른쪽)"
        '
        'BTN_ProcessDelete
        '
        Me.BTN_ProcessDelete.Name = "BTN_ProcessDelete"
        Me.BTN_ProcessDelete.Size = New System.Drawing.Size(170, 22)
        Me.BTN_ProcessDelete.Text = "공정 삭제"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label14.Location = New System.Drawing.Point(13, 153)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 12)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "2. 기타"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(26, 179)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(74, 12)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "- Chip Bond"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.RadioButton2)
        Me.Panel4.Controls.Add(Me.RadioButton1)
        Me.Panel4.Location = New System.Drawing.Point(106, 174)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(246, 22)
        Me.Panel4.TabIndex = 6
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(3, 3)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.Text = "사용"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(56, 3)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(59, 16)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "미사용"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(26, 215)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 12)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = "- 특이사항"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(106, 215)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(246, 147)
        Me.TextBox1.TabIndex = 8
        '
        'frm_ModelDocument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1364, 773)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TS_MainBar)
        Me.Name = "frm_ModelDocument"
        Me.Text = "모델별 자료 등록"
        Me.TS_MainBar.ResumeLayout(False)
        Me.TS_MainBar.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Grid_ModelList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.Grid_Documents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.Grid_BOM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.Grid_Coordinates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.Grid_BOM_Total, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.Grid_Process, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.CMS_GridMenu.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TS_MainBar As ToolStrip
    Friend WithEvents BTN_Search As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents BTN_Save As ToolStripButton
    Friend WithEvents Form_CLose As ToolStripButton
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TB_SearchModel As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_SearchCustomer As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Grid_ModelList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label22 As Label
    Friend WithEvents TB_ModelName As TextBox
    Friend WithEvents TB_ModelCode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TB_CustomerCode As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TB_CustomerName As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TB_ItemName As TextBox
    Friend WithEvents CB_ManagementNo As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents BTN_NewManagementNo As Button
    Friend WithEvents Grid_Documents As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label5 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents Grid_BOM As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label11 As Label
    Friend WithEvents Grid_Coordinates As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Grid_BOM_Total As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label12 As Label
    Friend WithEvents BTN_Result As Button
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents Label13 As Label
    Friend WithEvents Grid_Process As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents CMS_GridMenu As ContextMenuStrip
    Friend WithEvents BTN_ProcessAdd As ToolStripMenuItem
    Friend WithEvents BTN_ProcessDelete As ToolStripMenuItem
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Label15 As Label
End Class
