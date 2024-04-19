<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_SolderPaste_Use
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_SolderPaste_Use))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.C1DockingTab1 = New C1.Win.C1Command.C1DockingTab()
        Me.C1DockingTabPage1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.BTN_AgingStart = New System.Windows.Forms.Button()
        Me.TB_Aging_Worker = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TB_Aging_LotNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.C1DockingTabPage2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.CB_Line = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CB_Department = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BTN_UseStart = New System.Windows.Forms.Button()
        Me.TB_Use_Worker = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TB_Use_LotNo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.C1DockingTabPage3 = New C1.Win.C1Command.C1DockingTabPage()
        Me.BTN_Scrap = New System.Windows.Forms.Button()
        Me.TB_Scrap_Worker = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TB_Scrap_LotNo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LB_Mixing_Time = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Grid_StatusList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LB_Limit_Of_Use_Time = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LB_Aging_Min = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Grid_UseList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Grid_AgingList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Grid_StockList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TS_MainBar = New System.Windows.Forms.ToolStrip()
        Me.Form_CLose = New System.Windows.Forms.ToolStripButton()
        Me.BTN_Search = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_SolderPaste_Standard = New System.Windows.Forms.ToolStripButton()
        Me.CheckTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.C1DockingTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1DockingTab1.SuspendLayout()
        Me.C1DockingTabPage1.SuspendLayout()
        Me.C1DockingTabPage2.SuspendLayout()
        Me.C1DockingTabPage3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Grid_StatusList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Grid_UseList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Grid_AgingList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Grid_StockList, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.C1DockingTab1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1264, 748)
        Me.SplitContainer1.SplitterDistance = 593
        Me.SplitContainer1.TabIndex = 0
        '
        'C1DockingTab1
        '
        Me.C1DockingTab1.Controls.Add(Me.C1DockingTabPage1)
        Me.C1DockingTab1.Controls.Add(Me.C1DockingTabPage2)
        Me.C1DockingTab1.Controls.Add(Me.C1DockingTabPage3)
        Me.C1DockingTab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1DockingTab1.Location = New System.Drawing.Point(0, 344)
        Me.C1DockingTab1.Name = "C1DockingTab1"
        Me.C1DockingTab1.SelectedTabBold = True
        Me.C1DockingTab1.Size = New System.Drawing.Size(593, 404)
        Me.C1DockingTab1.TabAreaBackColor = System.Drawing.Color.LightSteelBlue
        Me.C1DockingTab1.TabIndex = 0
        Me.C1DockingTab1.TabsSpacing = -11
        Me.C1DockingTab1.TabStyle = C1.Win.C1Command.TabStyleEnum.Sloping
        Me.C1DockingTab1.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
        '
        'C1DockingTabPage1
        '
        Me.C1DockingTabPage1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.C1DockingTabPage1.Controls.Add(Me.BTN_AgingStart)
        Me.C1DockingTabPage1.Controls.Add(Me.TB_Aging_Worker)
        Me.C1DockingTabPage1.Controls.Add(Me.Label2)
        Me.C1DockingTabPage1.Controls.Add(Me.TB_Aging_LotNo)
        Me.C1DockingTabPage1.Controls.Add(Me.Label1)
        Me.C1DockingTabPage1.Image = Global.YJ_MMS.My.Resources.Resources._121_16
        Me.C1DockingTabPage1.Location = New System.Drawing.Point(1, 25)
        Me.C1DockingTabPage1.Name = "C1DockingTabPage1"
        Me.C1DockingTabPage1.Size = New System.Drawing.Size(591, 378)
        Me.C1DockingTabPage1.TabBackColor = System.Drawing.Color.LightSteelBlue
        Me.C1DockingTabPage1.TabBackColorSelected = System.Drawing.Color.LightSteelBlue
        Me.C1DockingTabPage1.TabIndex = 0
        Me.C1DockingTabPage1.Text = "상온방치 등록"
        '
        'BTN_AgingStart
        '
        Me.BTN_AgingStart.Location = New System.Drawing.Point(407, 8)
        Me.BTN_AgingStart.Name = "BTN_AgingStart"
        Me.BTN_AgingStart.Size = New System.Drawing.Size(126, 43)
        Me.BTN_AgingStart.TabIndex = 6
        Me.BTN_AgingStart.Text = "상온방치 시작"
        Me.BTN_AgingStart.UseVisualStyleBackColor = True
        '
        'TB_Aging_Worker
        '
        Me.TB_Aging_Worker.Location = New System.Drawing.Point(108, 30)
        Me.TB_Aging_Worker.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.TB_Aging_Worker.MaxLength = 20
        Me.TB_Aging_Worker.Name = "TB_Aging_Worker"
        Me.TB_Aging_Worker.Size = New System.Drawing.Size(272, 21)
        Me.TB_Aging_Worker.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(8, 30)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 21)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "작업자"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Aging_LotNo
        '
        Me.TB_Aging_LotNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TB_Aging_LotNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_Aging_LotNo.Location = New System.Drawing.Point(108, 8)
        Me.TB_Aging_LotNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.TB_Aging_LotNo.MaxLength = 20
        Me.TB_Aging_LotNo.Name = "TB_Aging_LotNo"
        Me.TB_Aging_LotNo.Size = New System.Drawing.Size(272, 21)
        Me.TB_Aging_LotNo.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 21)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Lot No."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'C1DockingTabPage2
        '
        Me.C1DockingTabPage2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.C1DockingTabPage2.Controls.Add(Me.CB_Line)
        Me.C1DockingTabPage2.Controls.Add(Me.Label10)
        Me.C1DockingTabPage2.Controls.Add(Me.CB_Department)
        Me.C1DockingTabPage2.Controls.Add(Me.Label9)
        Me.C1DockingTabPage2.Controls.Add(Me.BTN_UseStart)
        Me.C1DockingTabPage2.Controls.Add(Me.TB_Use_Worker)
        Me.C1DockingTabPage2.Controls.Add(Me.Label6)
        Me.C1DockingTabPage2.Controls.Add(Me.TB_Use_LotNo)
        Me.C1DockingTabPage2.Controls.Add(Me.Label8)
        Me.C1DockingTabPage2.Image = Global.YJ_MMS.My.Resources.Resources._102_16
        Me.C1DockingTabPage2.Location = New System.Drawing.Point(1, 25)
        Me.C1DockingTabPage2.Name = "C1DockingTabPage2"
        Me.C1DockingTabPage2.Size = New System.Drawing.Size(591, 378)
        Me.C1DockingTabPage2.TabBackColor = System.Drawing.Color.LightSteelBlue
        Me.C1DockingTabPage2.TabBackColorSelected = System.Drawing.Color.LightSteelBlue
        Me.C1DockingTabPage2.TabIndex = 1
        Me.C1DockingTabPage2.Text = "사용등록"
        '
        'CB_Line
        '
        Me.CB_Line.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Line.FormattingEnabled = True
        Me.CB_Line.Location = New System.Drawing.Point(295, 8)
        Me.CB_Line.Name = "CB_Line"
        Me.CB_Line.Size = New System.Drawing.Size(84, 20)
        Me.CB_Line.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(195, 8)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Line"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CB_Department
        '
        Me.CB_Department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Department.FormattingEnabled = True
        Me.CB_Department.Location = New System.Drawing.Point(108, 8)
        Me.CB_Department.Name = "CB_Department"
        Me.CB_Department.Size = New System.Drawing.Size(84, 20)
        Me.CB_Department.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(8, 8)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "동"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BTN_UseStart
        '
        Me.BTN_UseStart.Location = New System.Drawing.Point(407, 8)
        Me.BTN_UseStart.Name = "BTN_UseStart"
        Me.BTN_UseStart.Size = New System.Drawing.Size(126, 43)
        Me.BTN_UseStart.TabIndex = 11
        Me.BTN_UseStart.Text = "사용등록"
        Me.BTN_UseStart.UseVisualStyleBackColor = True
        '
        'TB_Use_Worker
        '
        Me.TB_Use_Worker.Location = New System.Drawing.Point(108, 52)
        Me.TB_Use_Worker.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.TB_Use_Worker.MaxLength = 20
        Me.TB_Use_Worker.Name = "TB_Use_Worker"
        Me.TB_Use_Worker.Size = New System.Drawing.Size(271, 21)
        Me.TB_Use_Worker.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(8, 52)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 21)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "작업자"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Use_LotNo
        '
        Me.TB_Use_LotNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TB_Use_LotNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_Use_LotNo.Location = New System.Drawing.Point(108, 30)
        Me.TB_Use_LotNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.TB_Use_LotNo.MaxLength = 20
        Me.TB_Use_LotNo.Name = "TB_Use_LotNo"
        Me.TB_Use_LotNo.Size = New System.Drawing.Size(271, 21)
        Me.TB_Use_LotNo.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(8, 30)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 21)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Lot No."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'C1DockingTabPage3
        '
        Me.C1DockingTabPage3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.C1DockingTabPage3.Controls.Add(Me.BTN_Scrap)
        Me.C1DockingTabPage3.Controls.Add(Me.TB_Scrap_Worker)
        Me.C1DockingTabPage3.Controls.Add(Me.Label11)
        Me.C1DockingTabPage3.Controls.Add(Me.TB_Scrap_LotNo)
        Me.C1DockingTabPage3.Controls.Add(Me.Label12)
        Me.C1DockingTabPage3.Image = Global.YJ_MMS.My.Resources.Resources.stop_16
        Me.C1DockingTabPage3.Location = New System.Drawing.Point(1, 25)
        Me.C1DockingTabPage3.Name = "C1DockingTabPage3"
        Me.C1DockingTabPage3.Size = New System.Drawing.Size(591, 378)
        Me.C1DockingTabPage3.TabBackColor = System.Drawing.Color.LightSteelBlue
        Me.C1DockingTabPage3.TabBackColorSelected = System.Drawing.Color.LightSteelBlue
        Me.C1DockingTabPage3.TabIndex = 2
        Me.C1DockingTabPage3.Text = "폐기"
        '
        'BTN_Scrap
        '
        Me.BTN_Scrap.Location = New System.Drawing.Point(407, 8)
        Me.BTN_Scrap.Name = "BTN_Scrap"
        Me.BTN_Scrap.Size = New System.Drawing.Size(126, 43)
        Me.BTN_Scrap.TabIndex = 11
        Me.BTN_Scrap.Text = "폐기등록"
        Me.BTN_Scrap.UseVisualStyleBackColor = True
        '
        'TB_Scrap_Worker
        '
        Me.TB_Scrap_Worker.Location = New System.Drawing.Point(108, 30)
        Me.TB_Scrap_Worker.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.TB_Scrap_Worker.MaxLength = 20
        Me.TB_Scrap_Worker.Name = "TB_Scrap_Worker"
        Me.TB_Scrap_Worker.Size = New System.Drawing.Size(272, 21)
        Me.TB_Scrap_Worker.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(8, 30)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 21)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "작업자"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Scrap_LotNo
        '
        Me.TB_Scrap_LotNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TB_Scrap_LotNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_Scrap_LotNo.Location = New System.Drawing.Point(108, 8)
        Me.TB_Scrap_LotNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.TB_Scrap_LotNo.MaxLength = 20
        Me.TB_Scrap_LotNo.Name = "TB_Scrap_LotNo"
        Me.TB_Scrap_LotNo.Size = New System.Drawing.Size(272, 21)
        Me.TB_Scrap_LotNo.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(8, 8)
        Me.Label12.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 21)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Lot No."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.LB_Mixing_Time)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Grid_StatusList)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.LB_Limit_Of_Use_Time)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.LB_Aging_Min)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(593, 344)
        Me.Panel1.TabIndex = 1
        '
        'LB_Mixing_Time
        '
        Me.LB_Mixing_Time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_Mixing_Time.Location = New System.Drawing.Point(210, 88)
        Me.LB_Mixing_Time.Margin = New System.Windows.Forms.Padding(0)
        Me.LB_Mixing_Time.Name = "LB_Mixing_Time"
        Me.LB_Mixing_Time.Size = New System.Drawing.Size(200, 26)
        Me.LB_Mixing_Time.TabIndex = 13
        Me.LB_Mixing_Time.Text = "0"
        Me.LB_Mixing_Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Location = New System.Drawing.Point(10, 88)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(200, 26)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "3. 교반 시간(sec / 1,000rpm)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Grid_StatusList
        '
        Me.Grid_StatusList.BackColor = System.Drawing.Color.White
        Me.Grid_StatusList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_StatusList.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Grid_StatusList.Location = New System.Drawing.Point(10, 124)
        Me.Grid_StatusList.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_StatusList.Name = "Grid_StatusList"
        Me.Grid_StatusList.Rows.Count = 2
        Me.Grid_StatusList.Rows.DefaultSize = 20
        Me.Grid_StatusList.Size = New System.Drawing.Size(569, 208)
        Me.Grid_StatusList.StyleInfo = resources.GetString("Grid_StatusList.StyleInfo")
        Me.Grid_StatusList.TabIndex = 11
        Me.Grid_StatusList.UseCompatibleTextRendering = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(165, 12)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "※ 현재 설정된 솔더사용 기준"
        '
        'LB_Limit_Of_Use_Time
        '
        Me.LB_Limit_Of_Use_Time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_Limit_Of_Use_Time.Location = New System.Drawing.Point(210, 62)
        Me.LB_Limit_Of_Use_Time.Margin = New System.Windows.Forms.Padding(0)
        Me.LB_Limit_Of_Use_Time.Name = "LB_Limit_Of_Use_Time"
        Me.LB_Limit_Of_Use_Time.Size = New System.Drawing.Size(200, 26)
        Me.LB_Limit_Of_Use_Time.TabIndex = 9
        Me.LB_Limit_Of_Use_Time.Text = "0"
        Me.LB_Limit_Of_Use_Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Location = New System.Drawing.Point(10, 36)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(200, 26)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "1. 상온방치 시간(Hr)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LB_Aging_Min
        '
        Me.LB_Aging_Min.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_Aging_Min.Location = New System.Drawing.Point(210, 36)
        Me.LB_Aging_Min.Margin = New System.Windows.Forms.Padding(0)
        Me.LB_Aging_Min.Name = "LB_Aging_Min"
        Me.LB_Aging_Min.Size = New System.Drawing.Size(200, 26)
        Me.LB_Aging_Min.TabIndex = 8
        Me.LB_Aging_Min.Text = "0"
        Me.LB_Aging_Min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(10, 62)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(200, 26)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "2. 개봉 후 사용한계 시간(Hr)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(667, 748)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Grid_UseList)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(3, 564)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(661, 181)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "사용(중) 목록"
        '
        'Grid_UseList
        '
        Me.Grid_UseList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_UseList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_UseList.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Grid_UseList.Location = New System.Drawing.Point(3, 22)
        Me.Grid_UseList.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_UseList.Name = "Grid_UseList"
        Me.Grid_UseList.Rows.Count = 2
        Me.Grid_UseList.Rows.DefaultSize = 20
        Me.Grid_UseList.Size = New System.Drawing.Size(655, 156)
        Me.Grid_UseList.StyleInfo = resources.GetString("Grid_UseList.StyleInfo")
        Me.Grid_UseList.TabIndex = 7
        Me.Grid_UseList.UseCompatibleTextRendering = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Grid_AgingList)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(3, 377)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(661, 181)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "상온방치 목록"
        '
        'Grid_AgingList
        '
        Me.Grid_AgingList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_AgingList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_AgingList.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Grid_AgingList.Location = New System.Drawing.Point(3, 22)
        Me.Grid_AgingList.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_AgingList.Name = "Grid_AgingList"
        Me.Grid_AgingList.Rows.Count = 2
        Me.Grid_AgingList.Rows.DefaultSize = 20
        Me.Grid_AgingList.Size = New System.Drawing.Size(655, 156)
        Me.Grid_AgingList.StyleInfo = resources.GetString("Grid_AgingList.StyleInfo")
        Me.Grid_AgingList.TabIndex = 7
        Me.Grid_AgingList.UseCompatibleTextRendering = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Grid_StockList)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(661, 368)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "재고목록"
        '
        'Grid_StockList
        '
        Me.Grid_StockList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_StockList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_StockList.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Grid_StockList.Location = New System.Drawing.Point(3, 22)
        Me.Grid_StockList.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_StockList.Name = "Grid_StockList"
        Me.Grid_StockList.Rows.Count = 2
        Me.Grid_StockList.Rows.DefaultSize = 20
        Me.Grid_StockList.Size = New System.Drawing.Size(655, 343)
        Me.Grid_StockList.StyleInfo = resources.GetString("Grid_StockList.StyleInfo")
        Me.Grid_StockList.TabIndex = 7
        Me.Grid_StockList.UseCompatibleTextRendering = True
        '
        'TS_MainBar
        '
        Me.TS_MainBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Form_CLose, Me.BTN_Search, Me.ToolStripSeparator1, Me.BTN_SolderPaste_Standard})
        Me.TS_MainBar.Location = New System.Drawing.Point(0, 0)
        Me.TS_MainBar.Name = "TS_MainBar"
        Me.TS_MainBar.Size = New System.Drawing.Size(1264, 25)
        Me.TS_MainBar.TabIndex = 4
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
        'BTN_Search
        '
        Me.BTN_Search.Image = Global.YJ_MMS.My.Resources.Resources.search_121
        Me.BTN_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_Search.Name = "BTN_Search"
        Me.BTN_Search.Size = New System.Drawing.Size(51, 22)
        Me.BTN_Search.Text = "조회"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BTN_SolderPaste_Standard
        '
        Me.BTN_SolderPaste_Standard.Image = Global.YJ_MMS.My.Resources.Resources.ordering_32
        Me.BTN_SolderPaste_Standard.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_SolderPaste_Standard.Name = "BTN_SolderPaste_Standard"
        Me.BTN_SolderPaste_Standard.Size = New System.Drawing.Size(103, 22)
        Me.BTN_SolderPaste_Standard.Text = "사용기준 관리"
        '
        'CheckTimer
        '
        '
        'frm_SolderPaste_Use
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 773)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TS_MainBar)
        Me.Name = "frm_SolderPaste_Use"
        Me.Text = "솔더관리 - 사용등록"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.C1DockingTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1DockingTab1.ResumeLayout(False)
        Me.C1DockingTabPage1.ResumeLayout(False)
        Me.C1DockingTabPage1.PerformLayout()
        Me.C1DockingTabPage2.ResumeLayout(False)
        Me.C1DockingTabPage2.PerformLayout()
        Me.C1DockingTabPage3.ResumeLayout(False)
        Me.C1DockingTabPage3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Grid_StatusList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.Grid_UseList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.Grid_AgingList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.Grid_StockList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TS_MainBar.ResumeLayout(False)
        Me.TS_MainBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TS_MainBar As ToolStrip
    Friend WithEvents Form_CLose As ToolStripButton
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Grid_UseList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Grid_AgingList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Grid_StockList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BTN_Search As ToolStripButton
    Friend WithEvents C1DockingTab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents C1DockingTabPage1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents C1DockingTabPage2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BTN_SolderPaste_Standard As ToolStripButton
    Friend WithEvents TB_Aging_LotNo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_Aging_Worker As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LB_Limit_Of_Use_Time As Label
    Friend WithEvents LB_Aging_Min As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Grid_StatusList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BTN_AgingStart As Button
    Friend WithEvents LB_Mixing_Time As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CB_Line As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents CB_Department As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents BTN_UseStart As Button
    Friend WithEvents TB_Use_Worker As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TB_Use_LotNo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents CheckTimer As Timer
    Friend WithEvents C1DockingTabPage3 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents BTN_Scrap As Button
    Friend WithEvents TB_Scrap_Worker As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TB_Scrap_LotNo As TextBox
    Friend WithEvents Label12 As Label
End Class
