<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Material_Data_Update
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Material_Data_Update))
        Me.BTN_Start = New System.Windows.Forms.Button()
        Me.CB_SheetName = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Grid_ExcelUpper = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TB_FileName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMS_RowMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_StartRow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_LastRow = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_ColumnMenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_Price = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Supplier = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Category = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_PartCode = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_FileSelect = New System.Windows.Forms.Button()
        Me.Grid_ExcelLower = New C1.Win.C1FlexGrid.C1FlexGrid()
        CType(Me.Grid_ExcelUpper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_RowMenu.SuspendLayout()
        Me.CMS_ColumnMenu1.SuspendLayout()
        CType(Me.Grid_ExcelLower, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.BTN_Start.TabIndex = 18
        Me.BTN_Start.Text = "등록"
        Me.BTN_Start.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_Start.UseVisualStyleBackColor = True
        '
        'CB_SheetName
        '
        Me.CB_SheetName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_SheetName.FormattingEnabled = True
        Me.CB_SheetName.Location = New System.Drawing.Point(182, 56)
        Me.CB_SheetName.Name = "CB_SheetName"
        Me.CB_SheetName.Size = New System.Drawing.Size(701, 20)
        Me.CB_SheetName.TabIndex = 17
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
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Sheet 선택"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.Grid_ExcelUpper.TabIndex = 15
        '
        'TB_FileName
        '
        Me.TB_FileName.BackColor = System.Drawing.SystemColors.Window
        Me.TB_FileName.Enabled = False
        Me.TB_FileName.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_FileName.Location = New System.Drawing.Point(182, 33)
        Me.TB_FileName.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_FileName.Name = "TB_FileName"
        Me.TB_FileName.Size = New System.Drawing.Size(626, 21)
        Me.TB_FileName.TabIndex = 14
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
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "File Path"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CMS_RowMenu
        '
        Me.CMS_RowMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_StartRow, Me.ToolStripSeparator2, Me.BTN_LastRow})
        Me.CMS_RowMenu.Name = "CMS_Menu"
        Me.CMS_RowMenu.Size = New System.Drawing.Size(123, 54)
        '
        'BTN_StartRow
        '
        Me.BTN_StartRow.Name = "BTN_StartRow"
        Me.BTN_StartRow.Size = New System.Drawing.Size(122, 22)
        Me.BTN_StartRow.Text = "시작행"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(119, 6)
        '
        'BTN_LastRow
        '
        Me.BTN_LastRow.Name = "BTN_LastRow"
        Me.BTN_LastRow.Size = New System.Drawing.Size(122, 22)
        Me.BTN_LastRow.Text = "마지막행"
        '
        'CMS_ColumnMenu1
        '
        Me.CMS_ColumnMenu1.BackColor = System.Drawing.SystemColors.Control
        Me.CMS_ColumnMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Price, Me.BTN_Supplier, Me.BTN_Category, Me.ToolStripSeparator1, Me.BTN_PartCode})
        Me.CMS_ColumnMenu1.Name = "CMS_Menu"
        Me.CMS_ColumnMenu1.Size = New System.Drawing.Size(128, 98)
        '
        'BTN_Price
        '
        Me.BTN_Price.Name = "BTN_Price"
        Me.BTN_Price.Size = New System.Drawing.Size(127, 22)
        Me.BTN_Price.Text = "단가"
        '
        'BTN_Supplier
        '
        Me.BTN_Supplier.Name = "BTN_Supplier"
        Me.BTN_Supplier.Size = New System.Drawing.Size(127, 22)
        Me.BTN_Supplier.Text = "공급사"
        '
        'BTN_Category
        '
        Me.BTN_Category.Name = "BTN_Category"
        Me.BTN_Category.Size = New System.Drawing.Size(127, 22)
        Me.BTN_Category.Text = "사/도급"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(124, 6)
        '
        'BTN_PartCode
        '
        Me.BTN_PartCode.Name = "BTN_PartCode"
        Me.BTN_PartCode.Size = New System.Drawing.Size(127, 22)
        Me.BTN_PartCode.Text = "Part Code"
        '
        'BTN_FileSelect
        '
        Me.BTN_FileSelect.Location = New System.Drawing.Point(808, 32)
        Me.BTN_FileSelect.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.BTN_FileSelect.Name = "BTN_FileSelect"
        Me.BTN_FileSelect.Size = New System.Drawing.Size(75, 23)
        Me.BTN_FileSelect.TabIndex = 31
        Me.BTN_FileSelect.Text = "파일선택"
        Me.BTN_FileSelect.UseVisualStyleBackColor = True
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
        Me.Grid_ExcelLower.TabIndex = 34
        '
        'frm_Material_Data_Update
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(899, 689)
        Me.Controls.Add(Me.Grid_ExcelLower)
        Me.Controls.Add(Me.BTN_FileSelect)
        Me.Controls.Add(Me.BTN_Start)
        Me.Controls.Add(Me.CB_SheetName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Grid_ExcelUpper)
        Me.Controls.Add(Me.TB_FileName)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Material_Data_Update"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "자료 업데이트"
        CType(Me.Grid_ExcelUpper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_RowMenu.ResumeLayout(False)
        Me.CMS_ColumnMenu1.ResumeLayout(False)
        CType(Me.Grid_ExcelLower, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BTN_Start As Button
    Friend WithEvents CB_SheetName As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Grid_ExcelUpper As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TB_FileName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CMS_RowMenu As ContextMenuStrip
    Friend WithEvents BTN_StartRow As ToolStripMenuItem
    Friend WithEvents CMS_ColumnMenu1 As ContextMenuStrip
    Friend WithEvents BTN_Price As ToolStripMenuItem
    Friend WithEvents BTN_Supplier As ToolStripMenuItem
    Friend WithEvents BTN_Category As ToolStripMenuItem
    Friend WithEvents BTN_FileSelect As Button
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BTN_PartCode As ToolStripMenuItem
    Friend WithEvents Grid_ExcelLower As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents BTN_LastRow As ToolStripMenuItem
End Class
