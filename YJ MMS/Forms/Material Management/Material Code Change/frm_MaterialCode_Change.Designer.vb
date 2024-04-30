<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_MaterialCode_Change
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_MaterialCode_Change))
        Me.TS_MainBar = New System.Windows.Forms.ToolStrip()
        Me.BTN_Search = New System.Windows.Forms.ToolStripButton()
        Me.Form_CLose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_Change = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CB_CustomerName = New System.Windows.Forms.ComboBox()
        Me.TB_CustomerCode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Grid_History = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.CMS_Menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_RePrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.TS_MainBar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Grid_History, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TS_MainBar
        '
        Me.TS_MainBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Search, Me.Form_CLose, Me.ToolStripSeparator1, Me.BTN_Change})
        Me.TS_MainBar.Location = New System.Drawing.Point(0, 0)
        Me.TS_MainBar.Name = "TS_MainBar"
        Me.TS_MainBar.Size = New System.Drawing.Size(1264, 25)
        Me.TS_MainBar.TabIndex = 2
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
        'BTN_Change
        '
        Me.BTN_Change.Image = Global.YJ_MMS.My.Resources.Resources.arrow_double
        Me.BTN_Change.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_Change.Name = "BTN_Change"
        Me.BTN_Change.Size = New System.Drawing.Size(75, 22)
        Me.BTN_Change.Text = "품번전환"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.CB_CustomerName)
        Me.Panel1.Controls.Add(Me.TB_CustomerCode)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1264, 47)
        Me.Panel1.TabIndex = 5
        '
        'CB_CustomerName
        '
        Me.CB_CustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_CustomerName.FormattingEnabled = True
        Me.CB_CustomerName.Location = New System.Drawing.Point(85, 11)
        Me.CB_CustomerName.Margin = New System.Windows.Forms.Padding(0)
        Me.CB_CustomerName.Name = "CB_CustomerName"
        Me.CB_CustomerName.Size = New System.Drawing.Size(266, 20)
        Me.CB_CustomerName.TabIndex = 6
        '
        'TB_CustomerCode
        '
        Me.TB_CustomerCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerCode.Enabled = False
        Me.TB_CustomerCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_CustomerCode.Location = New System.Drawing.Point(351, 11)
        Me.TB_CustomerCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerCode.Name = "TB_CustomerCode"
        Me.TB_CustomerCode.Size = New System.Drawing.Size(176, 21)
        Me.TB_CustomerCode.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 11)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 21)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "고객사"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Grid_History
        '
        Me.Grid_History.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_History.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_History.Location = New System.Drawing.Point(0, 72)
        Me.Grid_History.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_History.Name = "Grid_History"
        Me.Grid_History.Rows.Count = 2
        Me.Grid_History.Rows.DefaultSize = 20
        Me.Grid_History.Size = New System.Drawing.Size(1264, 701)
        Me.Grid_History.StyleInfo = resources.GetString("Grid_History.StyleInfo")
        Me.Grid_History.TabIndex = 6
        '
        'CMS_Menu
        '
        Me.CMS_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_RePrint})
        Me.CMS_Menu.Name = "CMS_Menu"
        Me.CMS_Menu.Size = New System.Drawing.Size(181, 48)
        '
        'BTN_RePrint
        '
        Me.BTN_RePrint.Name = "BTN_RePrint"
        Me.BTN_RePrint.Size = New System.Drawing.Size(180, 22)
        Me.BTN_RePrint.Text = "재발행"
        '
        'frm_MaterialCode_Change
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 773)
        Me.Controls.Add(Me.Grid_History)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TS_MainBar)
        Me.Name = "frm_MaterialCode_Change"
        Me.Text = "자재 품목코드 변경"
        Me.TS_MainBar.ResumeLayout(False)
        Me.TS_MainBar.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Grid_History, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_Menu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TS_MainBar As ToolStrip
    Friend WithEvents BTN_Search As ToolStripButton
    Friend WithEvents Form_CLose As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CB_CustomerName As ComboBox
    Friend WithEvents TB_CustomerCode As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Grid_History As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BTN_Change As ToolStripButton
    Friend WithEvents CMS_Menu As ContextMenuStrip
    Friend WithEvents BTN_RePrint As ToolStripMenuItem
End Class
