<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SolderPaste_Use
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_SolderPaste_Use))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.C1DockingTab1 = New C1.Win.C1Command.C1DockingTab()
        Me.C1DockingTabPage1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.C1DockingTabPage2 = New C1.Win.C1Command.C1DockingTabPage()
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
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.C1DockingTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1DockingTab1.SuspendLayout()
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
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1264, 748)
        Me.SplitContainer1.SplitterDistance = 421
        Me.SplitContainer1.TabIndex = 0
        '
        'C1DockingTab1
        '
        Me.C1DockingTab1.Controls.Add(Me.C1DockingTabPage1)
        Me.C1DockingTab1.Controls.Add(Me.C1DockingTabPage2)
        Me.C1DockingTab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1DockingTab1.Location = New System.Drawing.Point(0, 0)
        Me.C1DockingTab1.Name = "C1DockingTab1"
        Me.C1DockingTab1.SelectedTabBold = True
        Me.C1DockingTab1.Size = New System.Drawing.Size(421, 748)
        Me.C1DockingTab1.TabAreaBackColor = System.Drawing.Color.LightSteelBlue
        Me.C1DockingTab1.TabIndex = 0
        Me.C1DockingTab1.TabsSpacing = -11
        Me.C1DockingTab1.TabStyle = C1.Win.C1Command.TabStyleEnum.Sloping
        Me.C1DockingTab1.VisualStyle = C1.Win.C1Command.VisualStyle.Custom
        '
        'C1DockingTabPage1
        '
        Me.C1DockingTabPage1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.C1DockingTabPage1.Image = Global.YJ_MMS.My.Resources.Resources._121_16
        Me.C1DockingTabPage1.Location = New System.Drawing.Point(1, 25)
        Me.C1DockingTabPage1.Name = "C1DockingTabPage1"
        Me.C1DockingTabPage1.Size = New System.Drawing.Size(419, 722)
        Me.C1DockingTabPage1.TabBackColor = System.Drawing.Color.LightSteelBlue
        Me.C1DockingTabPage1.TabBackColorSelected = System.Drawing.Color.LightSteelBlue
        Me.C1DockingTabPage1.TabIndex = 0
        Me.C1DockingTabPage1.Text = "상온방치 등록"
        '
        'C1DockingTabPage2
        '
        Me.C1DockingTabPage2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.C1DockingTabPage2.Image = Global.YJ_MMS.My.Resources.Resources._102_16
        Me.C1DockingTabPage2.Location = New System.Drawing.Point(1, 25)
        Me.C1DockingTabPage2.Name = "C1DockingTabPage2"
        Me.C1DockingTabPage2.Size = New System.Drawing.Size(419, 722)
        Me.C1DockingTabPage2.TabBackColor = System.Drawing.Color.LightSteelBlue
        Me.C1DockingTabPage2.TabBackColorSelected = System.Drawing.Color.LightSteelBlue
        Me.C1DockingTabPage2.TabIndex = 1
        Me.C1DockingTabPage2.Text = "사용등록"
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(839, 748)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Grid_UseList)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(3, 564)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(833, 181)
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
        Me.Grid_UseList.Size = New System.Drawing.Size(827, 156)
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
        Me.GroupBox2.Size = New System.Drawing.Size(833, 181)
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
        Me.Grid_AgingList.Size = New System.Drawing.Size(827, 156)
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
        Me.GroupBox1.Size = New System.Drawing.Size(833, 368)
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
        Me.Grid_StockList.Size = New System.Drawing.Size(827, 343)
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
End Class
