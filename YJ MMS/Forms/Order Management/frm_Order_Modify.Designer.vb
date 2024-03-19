<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Order_Modify
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Order_Modify))
        Me.TS_MainBar = New System.Windows.Forms.ToolStrip()
        Me.BTN_Search = New System.Windows.Forms.ToolStripButton()
        Me.Form_CLose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_Save = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Grid_OrderList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TB_OrderNo_Search = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.DTP_End = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DTP_Start = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Grid_Excel = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TB_CustomerName = New System.Windows.Forms.TextBox()
        Me.TB_CustomerCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TB_OrderNo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CMS_GridMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_OrderCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Resume = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_Save2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TS_MainBar.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Grid_OrderList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.Grid_Excel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.CMS_GridMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TS_MainBar
        '
        Me.TS_MainBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Search, Me.Form_CLose, Me.ToolStripSeparator1, Me.BTN_Save})
        Me.TS_MainBar.Location = New System.Drawing.Point(0, 0)
        Me.TS_MainBar.Name = "TS_MainBar"
        Me.TS_MainBar.Size = New System.Drawing.Size(1264, 25)
        Me.TS_MainBar.TabIndex = 30
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Grid_OrderList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel5)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Grid_Excel)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1264, 748)
        Me.SplitContainer1.SplitterDistance = 426
        Me.SplitContainer1.TabIndex = 31
        '
        'Grid_OrderList
        '
        Me.Grid_OrderList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_OrderList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_OrderList.Location = New System.Drawing.Point(0, 85)
        Me.Grid_OrderList.Name = "Grid_OrderList"
        Me.Grid_OrderList.Rows.Count = 2
        Me.Grid_OrderList.Rows.DefaultSize = 20
        Me.Grid_OrderList.Size = New System.Drawing.Size(426, 663)
        Me.Grid_OrderList.StyleInfo = resources.GetString("Grid_OrderList.StyleInfo")
        Me.Grid_OrderList.TabIndex = 32
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel5.Controls.Add(Me.TB_OrderNo_Search)
        Me.Panel5.Controls.Add(Me.Label17)
        Me.Panel5.Controls.Add(Me.DTP_End)
        Me.Panel5.Controls.Add(Me.Label15)
        Me.Panel5.Controls.Add(Me.DTP_Start)
        Me.Panel5.Controls.Add(Me.Label16)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(426, 85)
        Me.Panel5.TabIndex = 31
        '
        'TB_OrderNo_Search
        '
        Me.TB_OrderNo_Search.BackColor = System.Drawing.SystemColors.Window
        Me.TB_OrderNo_Search.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_OrderNo_Search.Location = New System.Drawing.Point(85, 47)
        Me.TB_OrderNo_Search.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_OrderNo_Search.Name = "TB_OrderNo_Search"
        Me.TB_OrderNo_Search.Size = New System.Drawing.Size(242, 21)
        Me.TB_OrderNo_Search.TabIndex = 23
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(9, 47)
        Me.Label17.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(76, 21)
        Me.Label17.TabIndex = 21
        Me.Label17.Text = "주문번호"
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
        Me.Label16.Text = "접수일자"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Grid_Excel
        '
        Me.Grid_Excel.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_Excel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_Excel.Location = New System.Drawing.Point(0, 85)
        Me.Grid_Excel.Name = "Grid_Excel"
        Me.Grid_Excel.Rows.Count = 2
        Me.Grid_Excel.Rows.DefaultSize = 20
        Me.Grid_Excel.Size = New System.Drawing.Size(834, 663)
        Me.Grid_Excel.StyleInfo = resources.GetString("Grid_Excel.StyleInfo")
        Me.Grid_Excel.TabIndex = 24
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TB_CustomerName)
        Me.Panel1.Controls.Add(Me.TB_CustomerCode)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TB_OrderNo)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(834, 85)
        Me.Panel1.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Yellow
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(9, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(303, 12)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "※ 납기일자 변경시 MMS에도 필히 수정하여 주십시오."
        '
        'TB_CustomerName
        '
        Me.TB_CustomerName.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerName.Enabled = False
        Me.TB_CustomerName.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_CustomerName.Location = New System.Drawing.Point(181, 17)
        Me.TB_CustomerName.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerName.Name = "TB_CustomerName"
        Me.TB_CustomerName.Size = New System.Drawing.Size(311, 21)
        Me.TB_CustomerName.TabIndex = 34
        '
        'TB_CustomerCode
        '
        Me.TB_CustomerCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerCode.Enabled = False
        Me.TB_CustomerCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_CustomerCode.Location = New System.Drawing.Point(492, 17)
        Me.TB_CustomerCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerCode.Name = "TB_CustomerCode"
        Me.TB_CustomerCode.Size = New System.Drawing.Size(162, 21)
        Me.TB_CustomerCode.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 21)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "고객사"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_OrderNo
        '
        Me.TB_OrderNo.BackColor = System.Drawing.SystemColors.Window
        Me.TB_OrderNo.Enabled = False
        Me.TB_OrderNo.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_OrderNo.Location = New System.Drawing.Point(181, 40)
        Me.TB_OrderNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_OrderNo.Name = "TB_OrderNo"
        Me.TB_OrderNo.Size = New System.Drawing.Size(473, 21)
        Me.TB_OrderNo.TabIndex = 27
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(11, 40)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(170, 21)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "File Name"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CMS_GridMenu
        '
        Me.CMS_GridMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_OrderCancel, Me.BTN_Resume, Me.ToolStripSeparator4, Me.BTN_Save2})
        Me.CMS_GridMenu.Name = "CMS_GridMenu"
        Me.CMS_GridMenu.Size = New System.Drawing.Size(123, 76)
        '
        'BTN_OrderCancel
        '
        Me.BTN_OrderCancel.Name = "BTN_OrderCancel"
        Me.BTN_OrderCancel.Size = New System.Drawing.Size(122, 22)
        Me.BTN_OrderCancel.Text = "주문취소"
        '
        'BTN_Resume
        '
        Me.BTN_Resume.Name = "BTN_Resume"
        Me.BTN_Resume.Size = New System.Drawing.Size(122, 22)
        Me.BTN_Resume.Text = "재등록"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(119, 6)
        '
        'BTN_Save2
        '
        Me.BTN_Save2.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.BTN_Save2.Name = "BTN_Save2"
        Me.BTN_Save2.Size = New System.Drawing.Size(122, 22)
        Me.BTN_Save2.Text = "저장"
        '
        'frm_Order_Modify
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 773)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TS_MainBar)
        Me.Name = "frm_Order_Modify"
        Me.Text = "주문 확인 / 변경"
        Me.TS_MainBar.ResumeLayout(False)
        Me.TS_MainBar.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Grid_OrderList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.Grid_Excel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.CMS_GridMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TS_MainBar As ToolStrip
    Friend WithEvents BTN_Search As ToolStripButton
    Friend WithEvents Form_CLose As ToolStripButton
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Panel5 As Panel
    Friend WithEvents TB_OrderNo_Search As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents DTP_End As DateTimePicker
    Friend WithEvents Label15 As Label
    Friend WithEvents DTP_Start As DateTimePicker
    Friend WithEvents Label16 As Label
    Friend WithEvents Grid_OrderList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Grid_Excel As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BTN_Save As ToolStripButton
    Friend WithEvents CMS_GridMenu As ContextMenuStrip
    Friend WithEvents BTN_Save2 As ToolStripMenuItem
    Friend WithEvents BTN_OrderCancel As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents BTN_Resume As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TB_CustomerName As TextBox
    Friend WithEvents TB_CustomerCode As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_OrderNo As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label2 As Label
End Class
