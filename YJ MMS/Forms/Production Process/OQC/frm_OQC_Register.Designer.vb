<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_OQC_Register
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_OQC_Register))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TB_InspectedQty = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TB_ModelCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TB_LastProcess = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TB_POQty = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TB_ItemSpec = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TB_ItemName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TB_ItemCode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TB_OrderIndex = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TB_MagazineBarcode = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RB_NotUseSerial = New System.Windows.Forms.RadioButton()
        Me.RB_UseSerial = New System.Windows.Forms.RadioButton()
        Me.C1DockingTab1 = New C1.Win.C1Command.C1DockingTab()
        Me.C1DockingTabPage1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.Grid_BoxList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1DockingTabPage2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.TB_BoxQty = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LB_New_Update = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BTN_NewBox = New System.Windows.Forms.ToolStripButton()
        Me.BTN_Save = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_Fault_Register = New System.Windows.Forms.ToolStripButton()
        Me.BTN_Reinspector = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TB_Inspector = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RB_Inspection_NG = New System.Windows.Forms.RadioButton()
        Me.RB_Inspection_OK = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TB_OQC_No = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TB_SerialNo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Grid_History = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TS_MainBar = New System.Windows.Forms.ToolStrip()
        Me.Form_CLose = New System.Windows.Forms.ToolStripButton()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.BTN_Discard_Register = New System.Windows.Forms.ToolStripButton()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TB_CustomerCode = New System.Windows.Forms.TextBox()
        Me.TB_CustomerName = New System.Windows.Forms.TextBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.C1DockingTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1DockingTab1.SuspendLayout()
        Me.C1DockingTabPage1.SuspendLayout()
        CType(Me.Grid_BoxList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1DockingTabPage2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Grid_History, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TS_MainBar.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Grid_History)
        Me.SplitContainer1.Size = New System.Drawing.Size(1264, 748)
        Me.SplitContainer1.SplitterDistance = 771
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Panel3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.TB_MagazineBarcode)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.GroupBox3)
        Me.SplitContainer2.Panel2.Controls.Add(Me.C1DockingTab1)
        Me.SplitContainer2.Panel2.Controls.Add(Me.LB_New_Update)
        Me.SplitContainer2.Panel2.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer2.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer2.Panel2.Controls.Add(Me.TB_OQC_No)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label14)
        Me.SplitContainer2.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainer2.Size = New System.Drawing.Size(771, 748)
        Me.SplitContainer2.SplitterDistance = 248
        Me.SplitContainer2.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(7, 7)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 25)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "현품표 바코드"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TB_CustomerName)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.TB_CustomerCode)
        Me.Panel3.Controls.Add(Me.TB_InspectedQty)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.TB_ModelCode)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.TB_LastProcess)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.TB_POQty)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.TB_ItemSpec)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.TB_ItemName)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.TB_ItemCode)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.TB_OrderIndex)
        Me.Panel3.Location = New System.Drawing.Point(128, 34)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(625, 203)
        Me.Panel3.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(325, 149)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(105, 16)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "누적 검사수량 :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_InspectedQty
        '
        Me.TB_InspectedQty.Enabled = False
        Me.TB_InspectedQty.Location = New System.Drawing.Point(436, 147)
        Me.TB_InspectedQty.Name = "TB_InspectedQty"
        Me.TB_InspectedQty.Size = New System.Drawing.Size(184, 21)
        Me.TB_InspectedQty.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(10, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "모델코드 :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_ModelCode
        '
        Me.TB_ModelCode.Enabled = False
        Me.TB_ModelCode.Location = New System.Drawing.Point(121, 55)
        Me.TB_ModelCode.Name = "TB_ModelCode"
        Me.TB_ModelCode.Size = New System.Drawing.Size(499, 21)
        Me.TB_ModelCode.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(10, 172)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "마지막 공정 :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_LastProcess
        '
        Me.TB_LastProcess.Enabled = False
        Me.TB_LastProcess.Location = New System.Drawing.Point(121, 170)
        Me.TB_LastProcess.Name = "TB_LastProcess"
        Me.TB_LastProcess.Size = New System.Drawing.Size(499, 21)
        Me.TB_LastProcess.TabIndex = 13
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(10, 149)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(105, 16)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "주문수량 :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_POQty
        '
        Me.TB_POQty.Enabled = False
        Me.TB_POQty.Location = New System.Drawing.Point(121, 147)
        Me.TB_POQty.Name = "TB_POQty"
        Me.TB_POQty.Size = New System.Drawing.Size(184, 21)
        Me.TB_POQty.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(10, 126)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 16)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "규격 :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_ItemSpec
        '
        Me.TB_ItemSpec.Enabled = False
        Me.TB_ItemSpec.Location = New System.Drawing.Point(121, 124)
        Me.TB_ItemSpec.Name = "TB_ItemSpec"
        Me.TB_ItemSpec.Size = New System.Drawing.Size(499, 21)
        Me.TB_ItemSpec.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(10, 103)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(105, 16)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "품명 :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_ItemName
        '
        Me.TB_ItemName.Enabled = False
        Me.TB_ItemName.Location = New System.Drawing.Point(121, 101)
        Me.TB_ItemName.Name = "TB_ItemName"
        Me.TB_ItemName.Size = New System.Drawing.Size(499, 21)
        Me.TB_ItemName.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(10, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 16)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "품번 :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_ItemCode
        '
        Me.TB_ItemCode.Enabled = False
        Me.TB_ItemCode.Location = New System.Drawing.Point(121, 78)
        Me.TB_ItemCode.Name = "TB_ItemCode"
        Me.TB_ItemCode.Size = New System.Drawing.Size(499, 21)
        Me.TB_ItemCode.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(10, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "주문번호 :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_OrderIndex
        '
        Me.TB_OrderIndex.Enabled = False
        Me.TB_OrderIndex.Location = New System.Drawing.Point(121, 8)
        Me.TB_OrderIndex.Name = "TB_OrderIndex"
        Me.TB_OrderIndex.Size = New System.Drawing.Size(499, 21)
        Me.TB_OrderIndex.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(7, 34)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 203)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "생산정보"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_MagazineBarcode
        '
        Me.TB_MagazineBarcode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_MagazineBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TB_MagazineBarcode.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_MagazineBarcode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_MagazineBarcode.Location = New System.Drawing.Point(128, 7)
        Me.TB_MagazineBarcode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_MagazineBarcode.Name = "TB_MagazineBarcode"
        Me.TB_MagazineBarcode.Size = New System.Drawing.Size(625, 25)
        Me.TB_MagazineBarcode.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RB_NotUseSerial)
        Me.GroupBox3.Controls.Add(Me.RB_UseSerial)
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.Location = New System.Drawing.Point(315, 33)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(123, 92)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Serial No."
        '
        'RB_NotUseSerial
        '
        Me.RB_NotUseSerial.AutoSize = True
        Me.RB_NotUseSerial.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold)
        Me.RB_NotUseSerial.Location = New System.Drawing.Point(6, 54)
        Me.RB_NotUseSerial.Name = "RB_NotUseSerial"
        Me.RB_NotUseSerial.Size = New System.Drawing.Size(41, 19)
        Me.RB_NotUseSerial.TabIndex = 2
        Me.RB_NotUseSerial.TabStop = True
        Me.RB_NotUseSerial.Text = "無"
        Me.RB_NotUseSerial.UseVisualStyleBackColor = True
        '
        'RB_UseSerial
        '
        Me.RB_UseSerial.AutoSize = True
        Me.RB_UseSerial.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold)
        Me.RB_UseSerial.Location = New System.Drawing.Point(6, 29)
        Me.RB_UseSerial.Name = "RB_UseSerial"
        Me.RB_UseSerial.Size = New System.Drawing.Size(41, 19)
        Me.RB_UseSerial.TabIndex = 1
        Me.RB_UseSerial.TabStop = True
        Me.RB_UseSerial.Text = "有"
        Me.RB_UseSerial.UseVisualStyleBackColor = True
        '
        'C1DockingTab1
        '
        Me.C1DockingTab1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1DockingTab1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.C1DockingTab1.Controls.Add(Me.C1DockingTabPage1)
        Me.C1DockingTab1.Controls.Add(Me.C1DockingTabPage2)
        Me.C1DockingTab1.Location = New System.Drawing.Point(10, 159)
        Me.C1DockingTab1.Name = "C1DockingTab1"
        Me.C1DockingTab1.SelectedTabBold = True
        Me.C1DockingTab1.Size = New System.Drawing.Size(743, 323)
        Me.C1DockingTab1.TabIndex = 3
        Me.C1DockingTab1.TabsSpacing = -11
        Me.C1DockingTab1.TabStyle = C1.Win.C1Command.TabStyleEnum.Sloping
        '
        'C1DockingTabPage1
        '
        Me.C1DockingTabPage1.Controls.Add(Me.Label17)
        Me.C1DockingTabPage1.Controls.Add(Me.Grid_BoxList)
        Me.C1DockingTabPage1.Enabled = False
        Me.C1DockingTabPage1.Location = New System.Drawing.Point(1, 25)
        Me.C1DockingTabPage1.Name = "C1DockingTabPage1"
        Me.C1DockingTabPage1.Size = New System.Drawing.Size(741, 297)
        Me.C1DockingTabPage1.TabIndex = 0
        Me.C1DockingTabPage1.Text = "Serial No. 有"
        '
        'Grid_BoxList
        '
        Me.Grid_BoxList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid_BoxList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_BoxList.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Grid_BoxList.Location = New System.Drawing.Point(10, 28)
        Me.Grid_BoxList.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_BoxList.Name = "Grid_BoxList"
        Me.Grid_BoxList.Rows.Count = 2
        Me.Grid_BoxList.Rows.DefaultSize = 20
        Me.Grid_BoxList.Size = New System.Drawing.Size(719, 260)
        Me.Grid_BoxList.StyleInfo = resources.GetString("Grid_BoxList.StyleInfo")
        Me.Grid_BoxList.TabIndex = 0
        Me.Grid_BoxList.UseCompatibleTextRendering = True
        '
        'C1DockingTabPage2
        '
        Me.C1DockingTabPage2.Controls.Add(Me.TB_BoxQty)
        Me.C1DockingTabPage2.Controls.Add(Me.Label16)
        Me.C1DockingTabPage2.Enabled = False
        Me.C1DockingTabPage2.Location = New System.Drawing.Point(1, 25)
        Me.C1DockingTabPage2.Name = "C1DockingTabPage2"
        Me.C1DockingTabPage2.Size = New System.Drawing.Size(741, 297)
        Me.C1DockingTabPage2.TabIndex = 1
        Me.C1DockingTabPage2.Text = "Serial No. 無"
        '
        'TB_BoxQty
        '
        Me.TB_BoxQty.BackColor = System.Drawing.SystemColors.Window
        Me.TB_BoxQty.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_BoxQty.Location = New System.Drawing.Point(138, 28)
        Me.TB_BoxQty.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_BoxQty.Name = "TB_BoxQty"
        Me.TB_BoxQty.Size = New System.Drawing.Size(147, 25)
        Me.TB_BoxQty.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(17, 28)
        Me.Label16.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(121, 25)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "박스구성 수량"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LB_New_Update
        '
        Me.LB_New_Update.AutoSize = True
        Me.LB_New_Update.Location = New System.Drawing.Point(10, 117)
        Me.LB_New_Update.Name = "LB_New_Update"
        Me.LB_New_Update.Size = New System.Drawing.Size(124, 12)
        Me.LB_New_Update.TabIndex = 6
        Me.LB_New_Update.Text = "New_Update_Section"
        Me.LB_New_Update.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_NewBox, Me.BTN_Save, Me.ToolStripSeparator1, Me.BTN_Fault_Register, Me.BTN_Reinspector, Me.BTN_Discard_Register})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(767, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BTN_NewBox
        '
        Me.BTN_NewBox.Image = Global.YJ_MMS.My.Resources.Resources.plus_blue
        Me.BTN_NewBox.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_NewBox.Name = "BTN_NewBox"
        Me.BTN_NewBox.Size = New System.Drawing.Size(103, 22)
        Me.BTN_NewBox.Text = "신규박스 구성"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BTN_Fault_Register
        '
        Me.BTN_Fault_Register.Enabled = False
        Me.BTN_Fault_Register.Image = Global.YJ_MMS.My.Resources.Resources.ordering_32
        Me.BTN_Fault_Register.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_Fault_Register.Name = "BTN_Fault_Register"
        Me.BTN_Fault_Register.Size = New System.Drawing.Size(103, 22)
        Me.BTN_Fault_Register.Text = "불량내역 등록"
        '
        'BTN_Reinspector
        '
        Me.BTN_Reinspector.Enabled = False
        Me.BTN_Reinspector.Image = Global.YJ_MMS.My.Resources.Resources.stop_16
        Me.BTN_Reinspector.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_Reinspector.Name = "BTN_Reinspector"
        Me.BTN_Reinspector.Size = New System.Drawing.Size(103, 22)
        Me.BTN_Reinspector.Text = "수리결과 확인"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TB_Inspector)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(297, 93)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "검사결과 입력"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(16, 28)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 25)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "외관 검사"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Inspector
        '
        Me.TB_Inspector.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Inspector.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_Inspector.Location = New System.Drawing.Point(137, 55)
        Me.TB_Inspector.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Inspector.Name = "TB_Inspector"
        Me.TB_Inspector.Size = New System.Drawing.Size(147, 25)
        Me.TB_Inspector.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RB_Inspection_NG)
        Me.Panel2.Controls.Add(Me.RB_Inspection_OK)
        Me.Panel2.Location = New System.Drawing.Point(137, 28)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(147, 25)
        Me.Panel2.TabIndex = 1
        '
        'RB_Inspection_NG
        '
        Me.RB_Inspection_NG.AutoSize = True
        Me.RB_Inspection_NG.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold)
        Me.RB_Inspection_NG.Location = New System.Drawing.Point(79, 3)
        Me.RB_Inspection_NG.Name = "RB_Inspection_NG"
        Me.RB_Inspection_NG.Size = New System.Drawing.Size(57, 19)
        Me.RB_Inspection_NG.TabIndex = 1
        Me.RB_Inspection_NG.TabStop = True
        Me.RB_Inspection_NG.Text = "불량"
        Me.RB_Inspection_NG.UseVisualStyleBackColor = True
        '
        'RB_Inspection_OK
        '
        Me.RB_Inspection_OK.AutoSize = True
        Me.RB_Inspection_OK.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold)
        Me.RB_Inspection_OK.Location = New System.Drawing.Point(12, 3)
        Me.RB_Inspection_OK.Name = "RB_Inspection_OK"
        Me.RB_Inspection_OK.Size = New System.Drawing.Size(57, 19)
        Me.RB_Inspection_OK.TabIndex = 0
        Me.RB_Inspection_OK.TabStop = True
        Me.RB_Inspection_OK.Text = "양품"
        Me.RB_Inspection_OK.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(16, 55)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(121, 25)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "검사자"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_OQC_No
        '
        Me.TB_OQC_No.BackColor = System.Drawing.SystemColors.Window
        Me.TB_OQC_No.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TB_OQC_No.Enabled = False
        Me.TB_OQC_No.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_OQC_No.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_OQC_No.Location = New System.Drawing.Point(128, 130)
        Me.TB_OQC_No.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_OQC_No.Name = "TB_OQC_No"
        Me.TB_OQC_No.Size = New System.Drawing.Size(625, 25)
        Me.TB_OQC_No.TabIndex = 4
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(7, 130)
        Me.Label14.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(121, 25)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "출하검사번호"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.TB_SerialNo)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(444, 33)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(309, 93)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "박스구성"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label12.Location = New System.Drawing.Point(14, 64)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(245, 12)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "※ 제품에 부착된 라벨을 스캔하여 주십시오."
        '
        'TB_SerialNo
        '
        Me.TB_SerialNo.BackColor = System.Drawing.SystemColors.Window
        Me.TB_SerialNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TB_SerialNo.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_SerialNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_SerialNo.Location = New System.Drawing.Point(137, 28)
        Me.TB_SerialNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_SerialNo.Name = "TB_SerialNo"
        Me.TB_SerialNo.Size = New System.Drawing.Size(156, 25)
        Me.TB_SerialNo.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(16, 28)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 25)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "제품 일련번호"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Grid_History
        '
        Me.Grid_History.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_History.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_History.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Grid_History.Location = New System.Drawing.Point(0, 0)
        Me.Grid_History.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_History.Name = "Grid_History"
        Me.Grid_History.Rows.Count = 2
        Me.Grid_History.Rows.DefaultSize = 20
        Me.Grid_History.Size = New System.Drawing.Size(489, 748)
        Me.Grid_History.StyleInfo = resources.GetString("Grid_History.StyleInfo")
        Me.Grid_History.TabIndex = 0
        Me.Grid_History.UseCompatibleTextRendering = True
        '
        'TS_MainBar
        '
        Me.TS_MainBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Form_CLose})
        Me.TS_MainBar.Location = New System.Drawing.Point(0, 0)
        Me.TS_MainBar.Name = "TS_MainBar"
        Me.TS_MainBar.Size = New System.Drawing.Size(1264, 25)
        Me.TS_MainBar.TabIndex = 0
        Me.TS_MainBar.Text = "ToolStrip1"
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
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(15, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(95, 12)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "현재 수량 : 0 EA"
        '
        'BTN_Discard_Register
        '
        Me.BTN_Discard_Register.Enabled = False
        Me.BTN_Discard_Register.Image = Global.YJ_MMS.My.Resources.Resources.delete2
        Me.BTN_Discard_Register.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_Discard_Register.Name = "BTN_Discard_Register"
        Me.BTN_Discard_Register.Size = New System.Drawing.Size(91, 22)
        Me.BTN_Discard_Register.Text = "폐기품 등록"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(10, 34)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(105, 16)
        Me.Label18.TabIndex = 16
        Me.Label18.Text = "고객사 :"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_CustomerCode
        '
        Me.TB_CustomerCode.Enabled = False
        Me.TB_CustomerCode.Location = New System.Drawing.Point(121, 32)
        Me.TB_CustomerCode.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_CustomerCode.Name = "TB_CustomerCode"
        Me.TB_CustomerCode.Size = New System.Drawing.Size(98, 21)
        Me.TB_CustomerCode.TabIndex = 17
        '
        'TB_CustomerName
        '
        Me.TB_CustomerName.Enabled = False
        Me.TB_CustomerName.Location = New System.Drawing.Point(219, 32)
        Me.TB_CustomerName.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_CustomerName.Name = "TB_CustomerName"
        Me.TB_CustomerName.Size = New System.Drawing.Size(401, 21)
        Me.TB_CustomerName.TabIndex = 18
        '
        'frm_OQC_Register
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 773)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TS_MainBar)
        Me.Name = "frm_OQC_Register"
        Me.Text = "출하검사 등록"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.C1DockingTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1DockingTab1.ResumeLayout(False)
        Me.C1DockingTabPage1.ResumeLayout(False)
        Me.C1DockingTabPage1.PerformLayout()
        CType(Me.Grid_BoxList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1DockingTabPage2.ResumeLayout(False)
        Me.C1DockingTabPage2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Grid_History, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TS_MainBar.ResumeLayout(False)
        Me.TS_MainBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TB_MagazineBarcode As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents TB_POQty As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TB_ItemSpec As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TB_ItemName As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TB_ItemCode As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TB_OrderIndex As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TB_LastProcess As TextBox
    Friend WithEvents TS_MainBar As ToolStrip
    Friend WithEvents Form_CLose As ToolStripButton
    Friend WithEvents Grid_History As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label4 As Label
    Friend WithEvents TB_ModelCode As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents RB_Inspection_NG As RadioButton
    Friend WithEvents RB_Inspection_OK As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents TB_Inspector As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TB_SerialNo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents Grid_BoxList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TB_OQC_No As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BTN_NewBox As ToolStripButton
    Friend WithEvents BTN_Save As ToolStripButton
    Friend WithEvents Label15 As Label
    Friend WithEvents TB_InspectedQty As TextBox
    Friend WithEvents LB_New_Update As Label
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BTN_Fault_Register As ToolStripButton
    Friend WithEvents BTN_Reinspector As ToolStripButton
    Friend WithEvents C1DockingTab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents C1DockingTabPage1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents C1DockingTabPage2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents RB_NotUseSerial As RadioButton
    Friend WithEvents RB_UseSerial As RadioButton
    Friend WithEvents TB_BoxQty As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents BTN_Discard_Register As ToolStripButton
    Friend WithEvents TB_CustomerName As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents TB_CustomerCode As TextBox
End Class
