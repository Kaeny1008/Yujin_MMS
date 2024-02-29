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
        Me.Grid_Excel = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CB_SheetName = New System.Windows.Forms.ComboBox()
        Me.BTN_Start = New System.Windows.Forms.Button()
        Me.CMS_ColumnMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_Ref = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_PartNo = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_RowMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_RowSelect = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Grid_Excel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_ColumnMenu.SuspendLayout()
        Me.CMS_RowMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TB_File_Path
        '
        Me.TB_File_Path.BackColor = System.Drawing.SystemColors.Window
        Me.TB_File_Path.Enabled = False
        Me.TB_File_Path.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_File_Path.Location = New System.Drawing.Point(182, 10)
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
        Me.Label2.Location = New System.Drawing.Point(12, 10)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(170, 21)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "File Path"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Grid_Excel
        '
        Me.Grid_Excel.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_Excel.Location = New System.Drawing.Point(12, 63)
        Me.Grid_Excel.Name = "Grid_Excel"
        Me.Grid_Excel.Rows.Count = 2
        Me.Grid_Excel.Rows.DefaultSize = 20
        Me.Grid_Excel.Size = New System.Drawing.Size(871, 261)
        Me.Grid_Excel.StyleInfo = resources.GetString("Grid_Excel.StyleInfo")
        Me.Grid_Excel.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(12, 33)
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
        Me.CB_SheetName.Location = New System.Drawing.Point(182, 33)
        Me.CB_SheetName.Name = "CB_SheetName"
        Me.CB_SheetName.Size = New System.Drawing.Size(701, 20)
        Me.CB_SheetName.TabIndex = 11
        '
        'BTN_Start
        '
        Me.BTN_Start.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_Start.Image = CType(resources.GetObject("BTN_Start.Image"), System.Drawing.Image)
        Me.BTN_Start.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_Start.Location = New System.Drawing.Point(808, 328)
        Me.BTN_Start.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.BTN_Start.Name = "BTN_Start"
        Me.BTN_Start.Size = New System.Drawing.Size(75, 51)
        Me.BTN_Start.TabIndex = 12
        Me.BTN_Start.Text = "등록"
        Me.BTN_Start.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_Start.UseVisualStyleBackColor = True
        '
        'CMS_ColumnMenu
        '
        Me.CMS_ColumnMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Ref, Me.BTN_PartNo})
        Me.CMS_ColumnMenu.Name = "CMS_Menu"
        Me.CMS_ColumnMenu.Size = New System.Drawing.Size(188, 70)
        '
        'BTN_Ref
        '
        Me.BTN_Ref.Name = "BTN_Ref"
        Me.BTN_Ref.Size = New System.Drawing.Size(187, 22)
        Me.BTN_Ref.Text = "Ref( Location )"
        '
        'BTN_PartNo
        '
        Me.BTN_PartNo.Name = "BTN_PartNo"
        Me.BTN_PartNo.Size = New System.Drawing.Size(187, 22)
        Me.BTN_PartNo.Text = "Part No.( Part Code )"
        '
        'CMS_RowMenu
        '
        Me.CMS_RowMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_RowSelect})
        Me.CMS_RowMenu.Name = "CMS_Menu"
        Me.CMS_RowMenu.Size = New System.Drawing.Size(111, 26)
        '
        'BTN_RowSelect
        '
        Me.BTN_RowSelect.Name = "BTN_RowSelect"
        Me.BTN_RowSelect.Size = New System.Drawing.Size(110, 22)
        Me.BTN_RowSelect.Text = "시작행"
        '
        'frm_ExcelModify
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(899, 394)
        Me.Controls.Add(Me.BTN_Start)
        Me.Controls.Add(Me.CB_SheetName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Grid_Excel)
        Me.Controls.Add(Me.TB_File_Path)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_ExcelModify"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "자료등록"
        CType(Me.Grid_Excel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_ColumnMenu.ResumeLayout(False)
        Me.CMS_RowMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TB_File_Path As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Grid_Excel As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label6 As Label
    Friend WithEvents CB_SheetName As ComboBox
    Friend WithEvents BTN_Start As Button
    Friend WithEvents CMS_ColumnMenu As ContextMenuStrip
    Friend WithEvents BTN_Ref As ToolStripMenuItem
    Friend WithEvents BTN_PartNo As ToolStripMenuItem
    Friend WithEvents CMS_RowMenu As ContextMenuStrip
    Friend WithEvents BTN_RowSelect As ToolStripMenuItem
End Class
