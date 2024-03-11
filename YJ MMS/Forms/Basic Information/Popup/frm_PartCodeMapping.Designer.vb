<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_PartCodeMapping
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_PartCodeMapping))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TB_CustomerCode = New System.Windows.Forms.TextBox()
        Me.TB_Customer = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TB_PartCode = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TB_Specification = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TB_MainCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TB_Vendor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Grid_PartList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cms_Menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_NewParts = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_RowDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.COL_VIEW = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_Save = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Grid_PartList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms_Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(18, 28)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 21)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "고객사명"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_CustomerCode
        '
        Me.TB_CustomerCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerCode.Enabled = False
        Me.TB_CustomerCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_CustomerCode.Location = New System.Drawing.Point(139, 28)
        Me.TB_CustomerCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerCode.Name = "TB_CustomerCode"
        Me.TB_CustomerCode.Size = New System.Drawing.Size(100, 21)
        Me.TB_CustomerCode.TabIndex = 1
        '
        'TB_Customer
        '
        Me.TB_Customer.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Customer.Enabled = False
        Me.TB_Customer.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_Customer.Location = New System.Drawing.Point(239, 28)
        Me.TB_Customer.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Customer.Name = "TB_Customer"
        Me.TB_Customer.Size = New System.Drawing.Size(150, 21)
        Me.TB_Customer.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(18, 51)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 21)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "자재코드"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_PartCode
        '
        Me.TB_PartCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_PartCode.Enabled = False
        Me.TB_PartCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_PartCode.Location = New System.Drawing.Point(139, 51)
        Me.TB_PartCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_PartCode.Name = "TB_PartCode"
        Me.TB_PartCode.Size = New System.Drawing.Size(250, 21)
        Me.TB_PartCode.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TB_Specification)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TB_MainCode)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TB_Vendor)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TB_PartCode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TB_Customer)
        Me.GroupBox1.Controls.Add(Me.TB_CustomerCode)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(776, 114)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "선택 자재 정보"
        '
        'TB_Specification
        '
        Me.TB_Specification.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Specification.Enabled = False
        Me.TB_Specification.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_Specification.Location = New System.Drawing.Point(139, 74)
        Me.TB_Specification.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Specification.Name = "TB_Specification"
        Me.TB_Specification.Size = New System.Drawing.Size(621, 21)
        Me.TB_Specification.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(18, 74)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 21)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "사양"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_MainCode
        '
        Me.TB_MainCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_MainCode.Enabled = False
        Me.TB_MainCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_MainCode.Location = New System.Drawing.Point(510, 28)
        Me.TB_MainCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_MainCode.Name = "TB_MainCode"
        Me.TB_MainCode.Size = New System.Drawing.Size(250, 21)
        Me.TB_MainCode.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(389, 28)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 21)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "MainCode"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Vendor
        '
        Me.TB_Vendor.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Vendor.Enabled = False
        Me.TB_Vendor.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_Vendor.Location = New System.Drawing.Point(510, 51)
        Me.TB_Vendor.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Vendor.Name = "TB_Vendor"
        Me.TB_Vendor.Size = New System.Drawing.Size(250, 21)
        Me.TB_Vendor.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(389, 51)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 21)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Vendor"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Grid_PartList
        '
        Me.Grid_PartList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_PartList.Location = New System.Drawing.Point(12, 132)
        Me.Grid_PartList.Name = "Grid_PartList"
        Me.Grid_PartList.Rows.Count = 2
        Me.Grid_PartList.Rows.DefaultSize = 20
        Me.Grid_PartList.Size = New System.Drawing.Size(776, 306)
        Me.Grid_PartList.StyleInfo = resources.GetString("Grid_PartList.StyleInfo")
        Me.Grid_PartList.TabIndex = 8
        '
        'cms_Menu
        '
        Me.cms_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_NewParts, Me.BTN_RowDelete, Me.COL_VIEW, Me.BTN_Save})
        Me.cms_Menu.Name = "GRID_Menu"
        Me.cms_Menu.Size = New System.Drawing.Size(181, 98)
        '
        'BTN_NewParts
        '
        Me.BTN_NewParts.Image = Global.YJ_MMS.My.Resources.Resources.plus_blue
        Me.BTN_NewParts.Name = "BTN_NewParts"
        Me.BTN_NewParts.Size = New System.Drawing.Size(180, 22)
        Me.BTN_NewParts.Text = "신규 등록"
        '
        'BTN_RowDelete
        '
        Me.BTN_RowDelete.Image = Global.YJ_MMS.My.Resources.Resources.minus_blue
        Me.BTN_RowDelete.Name = "BTN_RowDelete"
        Me.BTN_RowDelete.Size = New System.Drawing.Size(180, 22)
        Me.BTN_RowDelete.Text = "등록 삭제(취소)"
        '
        'COL_VIEW
        '
        Me.COL_VIEW.Name = "COL_VIEW"
        Me.COL_VIEW.Size = New System.Drawing.Size(177, 6)
        '
        'BTN_Save
        '
        Me.BTN_Save.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(180, 22)
        Me.BTN_Save.Text = "저장"
        '
        'frm_PartCodeMapping
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Grid_PartList)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_PartCodeMapping"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Code Mapping"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Grid_PartList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms_Menu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents TB_CustomerCode As TextBox
    Friend WithEvents TB_Customer As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_PartCode As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Grid_PartList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cms_Menu As ContextMenuStrip
    Friend WithEvents BTN_NewParts As ToolStripMenuItem
    Friend WithEvents BTN_RowDelete As ToolStripMenuItem
    Friend WithEvents COL_VIEW As ToolStripSeparator
    Friend WithEvents BTN_Save As ToolStripMenuItem
    Friend WithEvents TB_Vendor As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TB_MainCode As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TB_Specification As TextBox
    Friend WithEvents Label5 As Label
End Class
