<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Material_Stock_Survey_Input
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Material_Stock_Survey_Input))
        Me.TS_MainBar = New System.Windows.Forms.ToolStrip()
        Me.BTN_Search = New System.Windows.Forms.ToolStripButton()
        Me.Form_CLose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_Save = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Grid_PlanList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Grid_MaterialList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TB_Barcode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.LB_totalCount = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LB_checkCount = New System.Windows.Forms.Label()
        Me.LB_InspectionNo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TS_MainBar.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Grid_PlanList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.Grid_MaterialList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TS_MainBar
        '
        Me.TS_MainBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Search, Me.Form_CLose, Me.ToolStripSeparator1, Me.BTN_Save})
        Me.TS_MainBar.Location = New System.Drawing.Point(0, 0)
        Me.TS_MainBar.Name = "TS_MainBar"
        Me.TS_MainBar.Size = New System.Drawing.Size(1264, 25)
        Me.TS_MainBar.TabIndex = 3
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
        'BTN_Save
        '
        Me.BTN_Save.Enabled = False
        Me.BTN_Save.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.BTN_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(51, 22)
        Me.BTN_Save.Text = "저장"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Grid_PlanList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Grid_MaterialList)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1264, 748)
        Me.SplitContainer1.SplitterDistance = 421
        Me.SplitContainer1.TabIndex = 4
        '
        'Grid_PlanList
        '
        Me.Grid_PlanList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_PlanList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_PlanList.Location = New System.Drawing.Point(0, 74)
        Me.Grid_PlanList.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_PlanList.Name = "Grid_PlanList"
        Me.Grid_PlanList.Rows.Count = 2
        Me.Grid_PlanList.Rows.DefaultSize = 20
        Me.Grid_PlanList.Size = New System.Drawing.Size(421, 674)
        Me.Grid_PlanList.StyleInfo = resources.GetString("Grid_PlanList.StyleInfo")
        Me.Grid_PlanList.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.DateTimePicker3)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.DateTimePicker2)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(421, 74)
        Me.Panel1.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TextBox1.Location = New System.Drawing.Point(136, 38)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(277, 21)
        Me.TextBox1.TabIndex = 40
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.RoyalBlue
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(9, 38)
        Me.Label13.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(127, 21)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "재고조사번호"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker3.Location = New System.Drawing.Point(262, 15)
        Me.DateTimePicker3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(97, 21)
        Me.DateTimePicker3.TabIndex = 38
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(236, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(23, 21)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "~"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(136, 15)
        Me.DateTimePicker2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(97, 21)
        Me.DateTimePicker2.TabIndex = 36
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.RoyalBlue
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(9, 15)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 21)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "계획수립일자"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Grid_MaterialList
        '
        Me.Grid_MaterialList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_MaterialList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_MaterialList.Location = New System.Drawing.Point(0, 108)
        Me.Grid_MaterialList.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_MaterialList.Name = "Grid_MaterialList"
        Me.Grid_MaterialList.Rows.Count = 2
        Me.Grid_MaterialList.Rows.DefaultSize = 20
        Me.Grid_MaterialList.Size = New System.Drawing.Size(839, 640)
        Me.Grid_MaterialList.StyleInfo = resources.GetString("Grid_MaterialList.StyleInfo")
        Me.Grid_MaterialList.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.Controls.Add(Me.TB_Barcode)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.LB_totalCount)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.LB_checkCount)
        Me.Panel2.Controls.Add(Me.LB_InspectionNo)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(839, 108)
        Me.Panel2.TabIndex = 2
        '
        'TB_Barcode
        '
        Me.TB_Barcode.Location = New System.Drawing.Point(141, 74)
        Me.TB_Barcode.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_Barcode.Name = "TB_Barcode"
        Me.TB_Barcode.Size = New System.Drawing.Size(409, 21)
        Me.TB_Barcode.TabIndex = 46
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.RoyalBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(14, 74)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 21)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Barcode"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(206, 42)
        Me.Label17.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(28, 21)
        Me.Label17.TabIndex = 43
        Me.Label17.Text = "/"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LB_totalCount
        '
        Me.LB_totalCount.BackColor = System.Drawing.Color.LightYellow
        Me.LB_totalCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_totalCount.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.LB_totalCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LB_totalCount.Location = New System.Drawing.Point(234, 42)
        Me.LB_totalCount.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.LB_totalCount.Name = "LB_totalCount"
        Me.LB_totalCount.Size = New System.Drawing.Size(65, 21)
        Me.LB_totalCount.TabIndex = 44
        Me.LB_totalCount.Text = "0"
        Me.LB_totalCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.PowderBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(14, 42)
        Me.Label14.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(127, 21)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "진행사항(수량)"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LB_checkCount
        '
        Me.LB_checkCount.BackColor = System.Drawing.Color.LightYellow
        Me.LB_checkCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_checkCount.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.LB_checkCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LB_checkCount.Location = New System.Drawing.Point(141, 42)
        Me.LB_checkCount.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.LB_checkCount.Name = "LB_checkCount"
        Me.LB_checkCount.Size = New System.Drawing.Size(65, 21)
        Me.LB_checkCount.TabIndex = 42
        Me.LB_checkCount.Text = "0"
        Me.LB_checkCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LB_InspectionNo
        '
        Me.LB_InspectionNo.BackColor = System.Drawing.Color.Bisque
        Me.LB_InspectionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_InspectionNo.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.LB_InspectionNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LB_InspectionNo.Location = New System.Drawing.Point(141, 15)
        Me.LB_InspectionNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.LB_InspectionNo.Name = "LB_InspectionNo"
        Me.LB_InspectionNo.Size = New System.Drawing.Size(409, 25)
        Me.LB_InspectionNo.TabIndex = 40
        Me.LB_InspectionNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.PowderBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(14, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 25)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "재고조사번호"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frm_Material_Stock_Survey_Input
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 773)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TS_MainBar)
        Me.Name = "frm_Material_Stock_Survey_Input"
        Me.Text = "재고조사 결과 입력"
        Me.TS_MainBar.ResumeLayout(False)
        Me.TS_MainBar.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Grid_PlanList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Grid_MaterialList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TS_MainBar As ToolStrip
    Friend WithEvents BTN_Search As ToolStripButton
    Friend WithEvents Form_CLose As ToolStripButton
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents DateTimePicker3 As DateTimePicker
    Friend WithEvents Label12 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label11 As Label
    Friend WithEvents Grid_PlanList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents LB_totalCount As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents LB_checkCount As Label
    Friend WithEvents LB_InspectionNo As Label
    Friend WithEvents Grid_MaterialList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BTN_Save As ToolStripButton
    Friend WithEvents TB_Barcode As TextBox
    Friend WithEvents Label2 As Label
End Class
