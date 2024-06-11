<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_MetalMaskManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MetalMaskManagement))
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BTN_Search = New System.Windows.Forms.ToolStripButton()
        Me.Btn_NewMask = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Btn_PrinterSetting = New System.Windows.Forms.ToolStripButton()
        Me.TB_ModelCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TB_CustomerCode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CB_CustomerName = New System.Windows.Forms.ComboBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TB_MaskSN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CB_WorkSide = New System.Windows.Forms.ComboBox()
        Me.Grid_List = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Grid_Menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Cms_MaskEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cms_MaskClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.Cms_MaskClose_Cancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cms_MaskDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cms_LabelPrinter = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cms_History = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Grid_List, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grid_Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Search, Me.ToolStripSeparator3, Me.Btn_NewMask, Me.ToolStripSeparator2, Me.Btn_PrinterSetting})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1264, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BTN_Search
        '
        Me.BTN_Search.Image = Global.YJ_MMS.My.Resources.Resources.search
        Me.BTN_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_Search.Name = "BTN_Search"
        Me.BTN_Search.Size = New System.Drawing.Size(51, 22)
        Me.BTN_Search.Text = "검색"
        '
        'Btn_NewMask
        '
        Me.Btn_NewMask.Image = Global.YJ_MMS.My.Resources.Resources.plus_blue
        Me.Btn_NewMask.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_NewMask.Name = "Btn_NewMask"
        Me.Btn_NewMask.Size = New System.Drawing.Size(75, 22)
        Me.Btn_NewMask.Text = "신규등록"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'Btn_PrinterSetting
        '
        Me.Btn_PrinterSetting.Image = Global.YJ_MMS.My.Resources.Resources.print
        Me.Btn_PrinterSetting.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn_PrinterSetting.Name = "Btn_PrinterSetting"
        Me.Btn_PrinterSetting.Size = New System.Drawing.Size(136, 22)
        Me.Btn_PrinterSetting.Text = "Label Printer Setting"
        Me.Btn_PrinterSetting.Visible = False
        '
        'TB_ModelCode
        '
        Me.TB_ModelCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ModelCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_ModelCode.Location = New System.Drawing.Point(136, 34)
        Me.TB_ModelCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_ModelCode.Name = "TB_ModelCode"
        Me.TB_ModelCode.Size = New System.Drawing.Size(392, 21)
        Me.TB_ModelCode.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.RoyalBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 34)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 21)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "모델명"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TB_CustomerCode
        '
        Me.TB_CustomerCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerCode.Enabled = False
        Me.TB_CustomerCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_CustomerCode.Location = New System.Drawing.Point(136, 10)
        Me.TB_CustomerCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerCode.Name = "TB_CustomerCode"
        Me.TB_CustomerCode.Size = New System.Drawing.Size(75, 21)
        Me.TB_CustomerCode.TabIndex = 22
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.RoyalBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(9, 10)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(127, 21)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "고객사"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CB_CustomerName
        '
        Me.CB_CustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_CustomerName.Font = New System.Drawing.Font("굴림", 9.75!)
        Me.CB_CustomerName.FormattingEnabled = True
        Me.CB_CustomerName.Location = New System.Drawing.Point(211, 10)
        Me.CB_CustomerName.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.CB_CustomerName.Name = "CB_CustomerName"
        Me.CB_CustomerName.Size = New System.Drawing.Size(317, 21)
        Me.CB_CustomerName.TabIndex = 12
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_MaskSN)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CB_WorkSide)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_ModelCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_CustomerCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CB_CustomerName)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Grid_List)
        Me.SplitContainer1.Size = New System.Drawing.Size(1264, 748)
        Me.SplitContainer1.SplitterDistance = 62
        Me.SplitContainer1.TabIndex = 2
        '
        'TB_MaskSN
        '
        Me.TB_MaskSN.BackColor = System.Drawing.SystemColors.Window
        Me.TB_MaskSN.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_MaskSN.Location = New System.Drawing.Point(655, 33)
        Me.TB_MaskSN.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_MaskSN.Name = "TB_MaskSN"
        Me.TB_MaskSN.Size = New System.Drawing.Size(141, 21)
        Me.TB_MaskSN.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.RoyalBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(528, 33)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 21)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "관리번호"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.RoyalBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(528, 10)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 21)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "작업면"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CB_WorkSide
        '
        Me.CB_WorkSide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_WorkSide.Font = New System.Drawing.Font("굴림", 9.75!)
        Me.CB_WorkSide.FormattingEnabled = True
        Me.CB_WorkSide.Items.AddRange(New Object() {"Bottom", "Top"})
        Me.CB_WorkSide.Location = New System.Drawing.Point(655, 10)
        Me.CB_WorkSide.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.CB_WorkSide.Name = "CB_WorkSide"
        Me.CB_WorkSide.Size = New System.Drawing.Size(141, 21)
        Me.CB_WorkSide.TabIndex = 33
        '
        'Grid_List
        '
        Me.Grid_List.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_List.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_List.Location = New System.Drawing.Point(0, 0)
        Me.Grid_List.Name = "Grid_List"
        Me.Grid_List.Rows.Count = 2
        Me.Grid_List.Rows.DefaultSize = 20
        Me.Grid_List.Size = New System.Drawing.Size(1264, 682)
        Me.Grid_List.StyleInfo = resources.GetString("Grid_List.StyleInfo")
        Me.Grid_List.TabIndex = 6
        '
        'Grid_Menu
        '
        Me.Grid_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Cms_MaskEdit, Me.ToolStripSeparator4, Me.Cms_MaskClose, Me.Cms_MaskClose_Cancel, Me.ToolStripSeparator5, Me.Cms_MaskDelete, Me.ToolStripSeparator1, Me.Cms_LabelPrinter, Me.ToolStripSeparator6, Me.Cms_History})
        Me.Grid_Menu.Name = "ContextMenuStrip1"
        Me.Grid_Menu.Size = New System.Drawing.Size(181, 182)
        '
        'Cms_MaskEdit
        '
        Me.Cms_MaskEdit.Image = Global.YJ_MMS.My.Resources.Resources.index
        Me.Cms_MaskEdit.Name = "Cms_MaskEdit"
        Me.Cms_MaskEdit.Size = New System.Drawing.Size(154, 22)
        Me.Cms_MaskEdit.Text = "정보 수정"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(151, 6)
        '
        'Cms_MaskClose
        '
        Me.Cms_MaskClose.Image = Global.YJ_MMS.My.Resources.Resources.delete2
        Me.Cms_MaskClose.Name = "Cms_MaskClose"
        Me.Cms_MaskClose.Size = New System.Drawing.Size(154, 22)
        Me.Cms_MaskClose.Text = "폐기 등록"
        '
        'Cms_MaskClose_Cancel
        '
        Me.Cms_MaskClose_Cancel.Name = "Cms_MaskClose_Cancel"
        Me.Cms_MaskClose_Cancel.Size = New System.Drawing.Size(154, 22)
        Me.Cms_MaskClose_Cancel.Text = "폐기 등록 취소"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(151, 6)
        '
        'Cms_MaskDelete
        '
        Me.Cms_MaskDelete.Image = Global.YJ_MMS.My.Resources.Resources.close
        Me.Cms_MaskDelete.Name = "Cms_MaskDelete"
        Me.Cms_MaskDelete.Size = New System.Drawing.Size(154, 22)
        Me.Cms_MaskDelete.Text = "삭제"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(151, 6)
        '
        'Cms_LabelPrinter
        '
        Me.Cms_LabelPrinter.Name = "Cms_LabelPrinter"
        Me.Cms_LabelPrinter.Size = New System.Drawing.Size(180, 22)
        Me.Cms_LabelPrinter.Text = "Label 인쇄"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(151, 6)
        '
        'Cms_History
        '
        Me.Cms_History.Image = Global.YJ_MMS.My.Resources.Resources.deviceData2
        Me.Cms_History.Name = "Cms_History"
        Me.Cms_History.Size = New System.Drawing.Size(154, 22)
        Me.Cms_History.Text = "이력 보기"
        '
        'frm_MetalMaskManagement
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1264, 773)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frm_MetalMaskManagement"
        Me.Text = "MetalMask 등록 / 관리"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Grid_List, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grid_Menu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents BTN_Search As ToolStripButton
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents TB_ModelCode As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_CustomerCode As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents CB_CustomerName As ComboBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Label3 As Label
    Friend WithEvents CB_WorkSide As ComboBox
    Friend WithEvents Grid_List As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Btn_NewMask As ToolStripButton
    Friend WithEvents TB_MaskSN As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Grid_Menu As ContextMenuStrip
    Friend WithEvents Cms_MaskEdit As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents Cms_MaskClose As ToolStripMenuItem
    Friend WithEvents Cms_MaskClose_Cancel As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents Cms_MaskDelete As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents Btn_PrinterSetting As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Cms_LabelPrinter As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents Cms_History As ToolStripMenuItem
End Class
