<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Code_Manager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Code_Manager))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.grid_MainCode = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tb_Name = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_Code = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.grid_SubCode = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grid_LastCode = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GRID_Menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btn_Row_Add = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_Row_Delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_Save = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btn_Search = New System.Windows.Forms.ToolStripButton()
        Me.Form_CLose = New System.Windows.Forms.ToolStripButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.grid_MainCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.grid_SubCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid_LastCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GRID_Menu.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.grid_MainCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1264, 748)
        Me.SplitContainer1.SplitterDistance = 530
        Me.SplitContainer1.TabIndex = 0
        '
        'grid_MainCode
        '
        Me.grid_MainCode.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.grid_MainCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid_MainCode.Location = New System.Drawing.Point(0, 83)
        Me.grid_MainCode.Name = "grid_MainCode"
        Me.grid_MainCode.Rows.Count = 2
        Me.grid_MainCode.Rows.DefaultSize = 20
        Me.grid_MainCode.Size = New System.Drawing.Size(530, 665)
        Me.grid_MainCode.StyleInfo = resources.GetString("grid_MainCode.StyleInfo")
        Me.grid_MainCode.TabIndex = 3
        Me.grid_MainCode.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.tb_Name)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.tb_Code)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(530, 83)
        Me.Panel1.TabIndex = 0
        '
        'tb_Name
        '
        Me.tb_Name.BackColor = System.Drawing.SystemColors.Window
        Me.tb_Name.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.tb_Name.Location = New System.Drawing.Point(113, 54)
        Me.tb_Name.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.tb_Name.Name = "tb_Name"
        Me.tb_Name.Size = New System.Drawing.Size(141, 21)
        Me.tb_Name.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(8, 54)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 21)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "이름"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tb_Code
        '
        Me.tb_Code.BackColor = System.Drawing.SystemColors.Window
        Me.tb_Code.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.tb_Code.Location = New System.Drawing.Point(113, 31)
        Me.tb_Code.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.tb_Code.Name = "tb_Code"
        Me.tb_Code.Size = New System.Drawing.Size(141, 21)
        Me.tb_Code.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(8, 31)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 21)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "CODE"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.grid_SubCode)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label5)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.grid_LastCode)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label6)
        Me.SplitContainer2.Size = New System.Drawing.Size(730, 748)
        Me.SplitContainer2.SplitterDistance = 509
        Me.SplitContainer2.TabIndex = 6
        '
        'grid_SubCode
        '
        Me.grid_SubCode.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.grid_SubCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid_SubCode.Location = New System.Drawing.Point(0, 86)
        Me.grid_SubCode.Name = "grid_SubCode"
        Me.grid_SubCode.Rows.Count = 2
        Me.grid_SubCode.Rows.DefaultSize = 20
        Me.grid_SubCode.Size = New System.Drawing.Size(509, 662)
        Me.grid_SubCode.StyleInfo = resources.GetString("grid_SubCode.StyleInfo")
        Me.grid_SubCode.TabIndex = 4
        Me.grid_SubCode.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(509, 43)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "상위 Code : "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(509, 43)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "[ 대분류 ]"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grid_LastCode
        '
        Me.grid_LastCode.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.grid_LastCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid_LastCode.Location = New System.Drawing.Point(0, 86)
        Me.grid_LastCode.Name = "grid_LastCode"
        Me.grid_LastCode.Rows.Count = 2
        Me.grid_LastCode.Rows.DefaultSize = 20
        Me.grid_LastCode.Size = New System.Drawing.Size(217, 662)
        Me.grid_LastCode.StyleInfo = resources.GetString("grid_LastCode.StyleInfo")
        Me.grid_LastCode.TabIndex = 6
        Me.grid_LastCode.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.CadetBlue
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(0, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(217, 43)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "상위 Code : "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.DarkCyan
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(217, 43)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "[ 중분류 ]"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GRID_Menu
        '
        Me.GRID_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_Row_Add, Me.btn_Row_Delete, Me.ToolStripSeparator1, Me.btn_Save})
        Me.GRID_Menu.Name = "GRID_Menu"
        Me.GRID_Menu.Size = New System.Drawing.Size(115, 76)
        '
        'btn_Row_Add
        '
        Me.btn_Row_Add.Image = Global.YJ_MMS.My.Resources.Resources.plus_blue
        Me.btn_Row_Add.Name = "btn_Row_Add"
        Me.btn_Row_Add.Size = New System.Drawing.Size(114, 22)
        Me.btn_Row_Add.Text = "행 추가"
        '
        'btn_Row_Delete
        '
        Me.btn_Row_Delete.Image = Global.YJ_MMS.My.Resources.Resources.minus_blue
        Me.btn_Row_Delete.Name = "btn_Row_Delete"
        Me.btn_Row_Delete.Size = New System.Drawing.Size(114, 22)
        Me.btn_Row_Delete.Text = "행 삭제"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(111, 6)
        '
        'btn_Save
        '
        Me.btn_Save.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(114, 22)
        Me.btn_Save.Text = "저장"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_Search, Me.Form_CLose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1264, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_Search
        '
        Me.btn_Search.Image = Global.YJ_MMS.My.Resources.Resources.search_121
        Me.btn_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Search.Name = "btn_Search"
        Me.btn_Search.Size = New System.Drawing.Size(51, 22)
        Me.btn_Search.Text = "검색"
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
        'frm_Code_Manager
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1264, 773)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.KeyPreview = True
        Me.Name = "frm_Code_Manager"
        Me.Text = "Code 관리"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.grid_MainCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.grid_SubCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid_LastCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GRID_Menu.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents grid_MainCode As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents grid_SubCode As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label1 As Label
    Friend WithEvents GRID_Menu As ContextMenuStrip
    Friend WithEvents btn_Row_Add As ToolStripMenuItem
    Friend WithEvents btn_Row_Delete As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btn_Save As ToolStripMenuItem
    Friend WithEvents tb_Code As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tb_Name As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents grid_LastCode As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btn_Search As ToolStripButton
    Friend WithEvents Form_CLose As ToolStripButton
End Class
