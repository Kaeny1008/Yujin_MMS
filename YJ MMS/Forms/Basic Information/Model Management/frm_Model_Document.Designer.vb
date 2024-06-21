<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Model_Document
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Model_Document))
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
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TB_BarcodeString = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
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
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TB_Time_Of_Change = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TB_Specification_Number = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.DTP_Issue_Date = New System.Windows.Forms.DateTimePicker()
        Me.CB_Gubun = New System.Windows.Forms.ComboBox()
        Me.CB_Change_Notification = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
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
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.Grid_Process, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.CMS_GridMenu.SuspendLayout()
        Me.Panel7.SuspendLayout()
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
        Me.TabControl1.Location = New System.Drawing.Point(0, 348)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(697, 400)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Grid_Documents)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(689, 374)
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
        Me.Grid_Documents.Size = New System.Drawing.Size(683, 368)
        Me.Grid_Documents.StyleInfo = resources.GetString("Grid_Documents.StyleInfo")
        Me.Grid_Documents.TabIndex = 0
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
        Me.TabPage5.Controls.Add(Me.Panel6)
        Me.TabPage5.Controls.Add(Me.Label19)
        Me.TabPage5.Controls.Add(Me.TB_BarcodeString)
        Me.TabPage5.Controls.Add(Me.Label18)
        Me.TabPage5.Controls.Add(Me.Panel5)
        Me.TabPage5.Controls.Add(Me.Label17)
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
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.RadioButton5)
        Me.Panel6.Controls.Add(Me.RadioButton6)
        Me.Panel6.Location = New System.Drawing.Point(150, 449)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(246, 22)
        Me.Panel6.TabIndex = 14
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Checked = True
        Me.RadioButton5.Location = New System.Drawing.Point(56, 3)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(59, 16)
        Me.RadioButton5.TabIndex = 1
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "아니오"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Location = New System.Drawing.Point(3, 3)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(35, 16)
        Me.RadioButton6.TabIndex = 0
        Me.RadioButton6.Text = "예"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(26, 454)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(113, 12)
        Me.Label19.TabIndex = 13
        Me.Label19.Text = "- Loader PCB인가?"
        '
        'TB_BarcodeString
        '
        Me.TB_BarcodeString.Location = New System.Drawing.Point(150, 416)
        Me.TB_BarcodeString.Name = "TB_BarcodeString"
        Me.TB_BarcodeString.Size = New System.Drawing.Size(246, 21)
        Me.TB_BarcodeString.TabIndex = 12
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(28, 420)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(85, 12)
        Me.Label18.TabIndex = 11
        Me.Label18.Text = "- 품목명(라벨)"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.RadioButton3)
        Me.Panel5.Controls.Add(Me.RadioButton4)
        Me.Panel5.Location = New System.Drawing.Point(150, 382)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(246, 22)
        Me.Panel5.TabIndex = 10
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Location = New System.Drawing.Point(56, 3)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(59, 16)
        Me.RadioButton3.TabIndex = 1
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "미사용"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(3, 3)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton4.TabIndex = 0
        Me.RadioButton4.Text = "사용"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(26, 387)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(83, 12)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "- Loader PCB"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(150, 215)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(246, 147)
        Me.TextBox1.TabIndex = 8
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
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.RadioButton2)
        Me.Panel4.Controls.Add(Me.RadioButton1)
        Me.Panel4.Location = New System.Drawing.Point(150, 174)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(246, 22)
        Me.Panel4.TabIndex = 6
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
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(26, 179)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(74, 12)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "- Chip Bond"
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
        Me.Panel3.Controls.Add(Me.Panel7)
        Me.Panel3.Controls.Add(Me.BTN_NewManagementNo)
        Me.Panel3.Controls.Add(Me.CB_ManagementNo)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(697, 348)
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
        Me.Label9.TabIndex = 10
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
        Me.TB_ItemName.TabIndex = 0
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
        Me.Label22.TabIndex = 8
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
        Me.TB_ModelName.TabIndex = 9
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
        Me.TB_ModelCode.TabIndex = 7
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
        Me.Label2.TabIndex = 6
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
        Me.Label7.TabIndex = 4
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
        Me.TB_CustomerName.TabIndex = 5
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
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel7.Controls.Add(Me.CB_Change_Notification)
        Me.Panel7.Controls.Add(Me.Label20)
        Me.Panel7.Controls.Add(Me.CB_Gubun)
        Me.Panel7.Controls.Add(Me.DTP_Issue_Date)
        Me.Panel7.Controls.Add(Me.Label21)
        Me.Panel7.Controls.Add(Me.TB_Time_Of_Change)
        Me.Panel7.Controls.Add(Me.Label23)
        Me.Panel7.Controls.Add(Me.Label24)
        Me.Panel7.Controls.Add(Me.TB_Specification_Number)
        Me.Panel7.Controls.Add(Me.Label25)
        Me.Panel7.Controls.Add(Me.Label26)
        Me.Panel7.Location = New System.Drawing.Point(19, 220)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(561, 119)
        Me.Panel7.TabIndex = 5
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(7, 83)
        Me.Label21.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(120, 21)
        Me.Label21.TabIndex = 9
        Me.Label21.Text = "변경시점"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Time_Of_Change
        '
        Me.TB_Time_Of_Change.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Time_Of_Change.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_Time_Of_Change.Location = New System.Drawing.Point(127, 83)
        Me.TB_Time_Of_Change.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Time_Of_Change.Name = "TB_Time_Of_Change"
        Me.TB_Time_Of_Change.Size = New System.Drawing.Size(420, 21)
        Me.TB_Time_Of_Change.TabIndex = 10
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(7, 60)
        Me.Label23.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(120, 21)
        Me.Label23.TabIndex = 5
        Me.Label23.Text = "변경구분"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(3, 6)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(132, 24)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "[ 시방변경정보 ]"
        '
        'TB_Specification_Number
        '
        Me.TB_Specification_Number.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Specification_Number.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_Specification_Number.Location = New System.Drawing.Point(127, 37)
        Me.TB_Specification_Number.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Specification_Number.Name = "TB_Specification_Number"
        Me.TB_Specification_Number.Size = New System.Drawing.Size(150, 21)
        Me.TB_Specification_Number.TabIndex = 2
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label25.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(277, 37)
        Me.Label25.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(120, 21)
        Me.Label25.TabIndex = 3
        Me.Label25.Text = "발행일자"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label26.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(7, 37)
        Me.Label26.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(120, 21)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "시방번호"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DTP_Issue_Date
        '
        Me.DTP_Issue_Date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_Issue_Date.Location = New System.Drawing.Point(397, 37)
        Me.DTP_Issue_Date.Margin = New System.Windows.Forms.Padding(0)
        Me.DTP_Issue_Date.Name = "DTP_Issue_Date"
        Me.DTP_Issue_Date.Size = New System.Drawing.Size(150, 21)
        Me.DTP_Issue_Date.TabIndex = 4
        '
        'CB_Gubun
        '
        Me.CB_Gubun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Gubun.Font = New System.Drawing.Font("굴림", 9.5!)
        Me.CB_Gubun.FormattingEnabled = True
        Me.CB_Gubun.Items.AddRange(New Object() {"정식", "임시"})
        Me.CB_Gubun.Location = New System.Drawing.Point(127, 60)
        Me.CB_Gubun.Name = "CB_Gubun"
        Me.CB_Gubun.Size = New System.Drawing.Size(150, 21)
        Me.CB_Gubun.TabIndex = 6
        '
        'CB_Change_Notification
        '
        Me.CB_Change_Notification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Change_Notification.Font = New System.Drawing.Font("굴림", 9.5!)
        Me.CB_Change_Notification.FormattingEnabled = True
        Me.CB_Change_Notification.Items.AddRange(New Object() {"필요", "불필요"})
        Me.CB_Change_Notification.Location = New System.Drawing.Point(397, 60)
        Me.CB_Change_Notification.Name = "CB_Change_Notification"
        Me.CB_Change_Notification.Size = New System.Drawing.Size(150, 21)
        Me.CB_Change_Notification.TabIndex = 8
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(277, 60)
        Me.Label20.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(120, 21)
        Me.Label20.TabIndex = 7
        Me.Label20.Text = "4M 변경신고"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frm_Model_Document
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1364, 773)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TS_MainBar)
        Me.Name = "frm_Model_Document"
        Me.Text = "모델별 기초자료"
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
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.Grid_Process, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.CMS_GridMenu.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
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
    Friend WithEvents Panel5 As Panel
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents Label17 As Label
    Friend WithEvents TB_BarcodeString As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents RadioButton6 As RadioButton
    Friend WithEvents Label19 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents CB_Change_Notification As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents CB_Gubun As ComboBox
    Friend WithEvents DTP_Issue_Date As DateTimePicker
    Friend WithEvents Label21 As Label
    Friend WithEvents TB_Time_Of_Change As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents TB_Specification_Number As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
End Class
