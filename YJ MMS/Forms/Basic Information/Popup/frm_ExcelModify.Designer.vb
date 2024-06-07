<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_ExcelModify
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ExcelModify))
        Me.TB_File_Path = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Grid_ExcelUpper = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CB_SheetName = New System.Windows.Forms.ComboBox()
        Me.BTN_Start = New System.Windows.Forms.Button()
        Me.CMS_ColumnMenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_Ref1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_PartNo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Type = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_RowMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_StartRow = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_ColumnMenu2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_Ref2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_X = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Y = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_A = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_TB = New System.Windows.Forms.ToolStripMenuItem()
        Me.Grid_ExcelLower = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_LastRow = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Grid_ExcelUpper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_ColumnMenu1.SuspendLayout()
        Me.CMS_RowMenu.SuspendLayout()
        Me.CMS_ColumnMenu2.SuspendLayout()
        CType(Me.Grid_ExcelLower, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TB_File_Path
        '
        Me.TB_File_Path.BackColor = System.Drawing.SystemColors.Window
        Me.TB_File_Path.Enabled = False
        Me.TB_File_Path.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_File_Path.Location = New System.Drawing.Point(182, 33)
        Me.TB_File_Path.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_File_Path.Name = "TB_File_Path"
        Me.TB_File_Path.Size = New System.Drawing.Size(701, 21)
        Me.TB_File_Path.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 33)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(170, 21)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "File Path"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Grid_ExcelUpper
        '
        Me.Grid_ExcelUpper.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_ExcelUpper.Location = New System.Drawing.Point(12, 86)
        Me.Grid_ExcelUpper.Name = "Grid_ExcelUpper"
        Me.Grid_ExcelUpper.Rows.Count = 2
        Me.Grid_ExcelUpper.Rows.DefaultSize = 20
        Me.Grid_ExcelUpper.Size = New System.Drawing.Size(871, 261)
        Me.Grid_ExcelUpper.StyleInfo = resources.GetString("Grid_ExcelUpper.StyleInfo")
        Me.Grid_ExcelUpper.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(12, 56)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(170, 21)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Sheet 선택"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CB_SheetName
        '
        Me.CB_SheetName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_SheetName.FormattingEnabled = True
        Me.CB_SheetName.Location = New System.Drawing.Point(182, 56)
        Me.CB_SheetName.Name = "CB_SheetName"
        Me.CB_SheetName.Size = New System.Drawing.Size(701, 20)
        Me.CB_SheetName.TabIndex = 11
        '
        'BTN_Start
        '
        Me.BTN_Start.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_Start.Image = CType(resources.GetObject("BTN_Start.Image"), System.Drawing.Image)
        Me.BTN_Start.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_Start.Location = New System.Drawing.Point(808, 628)
        Me.BTN_Start.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.BTN_Start.Name = "BTN_Start"
        Me.BTN_Start.Size = New System.Drawing.Size(75, 51)
        Me.BTN_Start.TabIndex = 12
        Me.BTN_Start.Text = "등록"
        Me.BTN_Start.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_Start.UseVisualStyleBackColor = True
        '
        'CMS_ColumnMenu1
        '
        Me.CMS_ColumnMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Ref1, Me.BTN_PartNo, Me.BTN_Type})
        Me.CMS_ColumnMenu1.Name = "CMS_Menu"
        Me.CMS_ColumnMenu1.Size = New System.Drawing.Size(188, 70)
        '
        'BTN_Ref1
        '
        Me.BTN_Ref1.Name = "BTN_Ref1"
        Me.BTN_Ref1.Size = New System.Drawing.Size(187, 22)
        Me.BTN_Ref1.Text = "Ref( Location )"
        '
        'BTN_PartNo
        '
        Me.BTN_PartNo.Name = "BTN_PartNo"
        Me.BTN_PartNo.Size = New System.Drawing.Size(187, 22)
        Me.BTN_PartNo.Text = "Part No.( Part Code )"
        '
        'BTN_Type
        '
        Me.BTN_Type.Name = "BTN_Type"
        Me.BTN_Type.Size = New System.Drawing.Size(187, 22)
        Me.BTN_Type.Text = "Material Type"
        '
        'CMS_RowMenu
        '
        Me.CMS_RowMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_StartRow, Me.ToolStripTextBox1, Me.BTN_LastRow})
        Me.CMS_RowMenu.Name = "CMS_Menu"
        Me.CMS_RowMenu.Size = New System.Drawing.Size(181, 76)
        '
        'BTN_StartRow
        '
        Me.BTN_StartRow.Name = "BTN_StartRow"
        Me.BTN_StartRow.Size = New System.Drawing.Size(180, 22)
        Me.BTN_StartRow.Text = "시작행"
        '
        'CMS_ColumnMenu2
        '
        Me.CMS_ColumnMenu2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Ref2, Me.BTN_X, Me.BTN_Y, Me.BTN_A, Me.BTN_TB})
        Me.CMS_ColumnMenu2.Name = "CMS_Menu"
        Me.CMS_ColumnMenu2.Size = New System.Drawing.Size(154, 114)
        '
        'BTN_Ref2
        '
        Me.BTN_Ref2.Name = "BTN_Ref2"
        Me.BTN_Ref2.Size = New System.Drawing.Size(153, 22)
        Me.BTN_Ref2.Text = "Ref( Location )"
        '
        'BTN_X
        '
        Me.BTN_X.Name = "BTN_X"
        Me.BTN_X.Size = New System.Drawing.Size(153, 22)
        Me.BTN_X.Text = "X"
        '
        'BTN_Y
        '
        Me.BTN_Y.Name = "BTN_Y"
        Me.BTN_Y.Size = New System.Drawing.Size(153, 22)
        Me.BTN_Y.Text = "Y"
        '
        'BTN_A
        '
        Me.BTN_A.Name = "BTN_A"
        Me.BTN_A.Size = New System.Drawing.Size(153, 22)
        Me.BTN_A.Text = "A"
        '
        'BTN_TB
        '
        Me.BTN_TB.Name = "BTN_TB"
        Me.BTN_TB.Size = New System.Drawing.Size(153, 22)
        Me.BTN_TB.Text = "Top / Bottom"
        '
        'Grid_ExcelLower
        '
        Me.Grid_ExcelLower.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_ExcelLower.Location = New System.Drawing.Point(12, 353)
        Me.Grid_ExcelLower.Name = "Grid_ExcelLower"
        Me.Grid_ExcelLower.Rows.Count = 2
        Me.Grid_ExcelLower.Rows.DefaultSize = 20
        Me.Grid_ExcelLower.Size = New System.Drawing.Size(871, 261)
        Me.Grid_ExcelLower.StyleInfo = resources.GetString("Grid_ExcelLower.StyleInfo")
        Me.Grid_ExcelLower.TabIndex = 35
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(177, 6)
        '
        'BTN_LastRow
        '
        Me.BTN_LastRow.Name = "BTN_LastRow"
        Me.BTN_LastRow.Size = New System.Drawing.Size(180, 22)
        Me.BTN_LastRow.Text = "마지막행"
        '
        'frm_ExcelModify
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(899, 689)
        Me.Controls.Add(Me.Grid_ExcelLower)
        Me.Controls.Add(Me.BTN_Start)
        Me.Controls.Add(Me.CB_SheetName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Grid_ExcelUpper)
        Me.Controls.Add(Me.TB_File_Path)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_ExcelModify"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "자료등록"
        CType(Me.Grid_ExcelUpper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_ColumnMenu1.ResumeLayout(False)
        Me.CMS_RowMenu.ResumeLayout(False)
        Me.CMS_ColumnMenu2.ResumeLayout(False)
        CType(Me.Grid_ExcelLower, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TB_File_Path As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Grid_ExcelUpper As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label6 As Label
    Friend WithEvents CB_SheetName As ComboBox
    Friend WithEvents BTN_Start As Button
    Friend WithEvents CMS_ColumnMenu1 As ContextMenuStrip
    Friend WithEvents BTN_Ref1 As ToolStripMenuItem
    Friend WithEvents BTN_PartNo As ToolStripMenuItem
    Friend WithEvents CMS_RowMenu As ContextMenuStrip
    Friend WithEvents BTN_StartRow As ToolStripMenuItem
    Friend WithEvents CMS_ColumnMenu2 As ContextMenuStrip
    Friend WithEvents BTN_Ref2 As ToolStripMenuItem
    Friend WithEvents BTN_X As ToolStripMenuItem
    Friend WithEvents BTN_Y As ToolStripMenuItem
    Friend WithEvents BTN_A As ToolStripMenuItem
    Friend WithEvents BTN_TB As ToolStripMenuItem
    Friend WithEvents BTN_Type As ToolStripMenuItem
    Friend WithEvents Grid_ExcelLower As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ToolStripTextBox1 As ToolStripSeparator
    Friend WithEvents BTN_LastRow As ToolStripMenuItem
End Class
