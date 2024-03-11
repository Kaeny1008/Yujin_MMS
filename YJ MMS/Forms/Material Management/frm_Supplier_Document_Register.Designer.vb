<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Supplier_Document_Register
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Supplier_Document_Register))
        Me.TS_MainBar = New System.Windows.Forms.ToolStrip()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Grid_DocumentsList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.CB_SheetName = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Grid_Excel = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TB_File_Path = New System.Windows.Forms.TextBox()
        Me.BTN_FileSelect = New System.Windows.Forms.Button()
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.CMS_RowMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_RowSelect = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_ExcelToGrid2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_ColumnMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_PartCode = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_PartNo = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Qty = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_ExcelToGrid = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_Search = New System.Windows.Forms.ToolStripButton()
        Me.Form_CLose = New System.Windows.Forms.ToolStripButton()
        Me.BTN_NewDocuments = New System.Windows.Forms.ToolStripButton()
        Me.CB_Supplier = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BTN_Save = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.TS_MainBar.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Grid_DocumentsList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.Grid_Excel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_RowMenu.SuspendLayout()
        Me.CMS_ColumnMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TS_MainBar
        '
        Me.TS_MainBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Search, Me.Form_CLose, Me.ToolStripSeparator3, Me.BTN_NewDocuments, Me.ToolStripSeparator4, Me.BTN_Save})
        Me.TS_MainBar.Location = New System.Drawing.Point(0, 0)
        Me.TS_MainBar.Name = "TS_MainBar"
        Me.TS_MainBar.Size = New System.Drawing.Size(1464, 25)
        Me.TS_MainBar.TabIndex = 1
        Me.TS_MainBar.Text = "ToolStrip1"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Grid_DocumentsList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1464, 748)
        Me.SplitContainer1.SplitterDistance = 421
        Me.SplitContainer1.TabIndex = 2
        '
        'Grid_DocumentsList
        '
        Me.Grid_DocumentsList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_DocumentsList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_DocumentsList.Location = New System.Drawing.Point(0, 60)
        Me.Grid_DocumentsList.Name = "Grid_DocumentsList"
        Me.Grid_DocumentsList.Rows.Count = 2
        Me.Grid_DocumentsList.Rows.DefaultSize = 20
        Me.Grid_DocumentsList.Size = New System.Drawing.Size(421, 688)
        Me.Grid_DocumentsList.StyleInfo = resources.GetString("Grid_DocumentsList.StyleInfo")
        Me.Grid_DocumentsList.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.DateTimePicker2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(421, 60)
        Me.Panel1.TabIndex = 2
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(270, 8)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(102, 21)
        Me.DateTimePicker2.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(244, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 12)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "~"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(130, 8)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(102, 21)
        Me.DateTimePicker1.TabIndex = 14
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TextBox1.Location = New System.Drawing.Point(130, 31)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(242, 21)
        Me.TextBox1.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 31)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 21)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "공급사"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 8)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 21)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "입고일자"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer2.Panel1.Controls.Add(Me.CB_SheetName)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Grid_Excel)
        Me.SplitContainer2.Panel1.Controls.Add(Me.TB_File_Path)
        Me.SplitContainer2.Panel1.Controls.Add(Me.BTN_FileSelect)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.C1FlexGrid1)
        Me.SplitContainer2.Size = New System.Drawing.Size(1039, 748)
        Me.SplitContainer2.SplitterDistance = 352
        Me.SplitContainer2.TabIndex = 3
        '
        'CB_SheetName
        '
        Me.CB_SheetName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_SheetName.Enabled = False
        Me.CB_SheetName.FormattingEnabled = True
        Me.CB_SheetName.Location = New System.Drawing.Point(176, 52)
        Me.CB_SheetName.Name = "CB_SheetName"
        Me.CB_SheetName.Size = New System.Drawing.Size(626, 20)
        Me.CB_SheetName.TabIndex = 25
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(6, 52)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(170, 21)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Sheet 선택"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(6, 29)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(170, 21)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "File Path"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Grid_Excel
        '
        Me.Grid_Excel.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_Excel.Location = New System.Drawing.Point(6, 82)
        Me.Grid_Excel.Name = "Grid_Excel"
        Me.Grid_Excel.Rows.Count = 2
        Me.Grid_Excel.Rows.DefaultSize = 20
        Me.Grid_Excel.Size = New System.Drawing.Size(871, 261)
        Me.Grid_Excel.StyleInfo = resources.GetString("Grid_Excel.StyleInfo")
        Me.Grid_Excel.TabIndex = 23
        '
        'TB_File_Path
        '
        Me.TB_File_Path.BackColor = System.Drawing.SystemColors.Window
        Me.TB_File_Path.Enabled = False
        Me.TB_File_Path.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_File_Path.Location = New System.Drawing.Point(176, 29)
        Me.TB_File_Path.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_File_Path.Name = "TB_File_Path"
        Me.TB_File_Path.Size = New System.Drawing.Size(626, 21)
        Me.TB_File_Path.TabIndex = 21
        '
        'BTN_FileSelect
        '
        Me.BTN_FileSelect.Enabled = False
        Me.BTN_FileSelect.Location = New System.Drawing.Point(802, 28)
        Me.BTN_FileSelect.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.BTN_FileSelect.Name = "BTN_FileSelect"
        Me.BTN_FileSelect.Size = New System.Drawing.Size(75, 23)
        Me.BTN_FileSelect.TabIndex = 22
        Me.BTN_FileSelect.Text = "파일선택"
        Me.BTN_FileSelect.UseVisualStyleBackColor = True
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.C1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FlexGrid1.Location = New System.Drawing.Point(0, 0)
        Me.C1FlexGrid1.Name = "C1FlexGrid1"
        Me.C1FlexGrid1.Rows.Count = 2
        Me.C1FlexGrid1.Rows.DefaultSize = 20
        Me.C1FlexGrid1.Size = New System.Drawing.Size(1039, 392)
        Me.C1FlexGrid1.StyleInfo = resources.GetString("C1FlexGrid1.StyleInfo")
        Me.C1FlexGrid1.TabIndex = 2
        '
        'CMS_RowMenu
        '
        Me.CMS_RowMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_RowSelect, Me.ToolStripSeparator1, Me.BTN_ExcelToGrid2})
        Me.CMS_RowMenu.Name = "CMS_Menu"
        Me.CMS_RowMenu.Size = New System.Drawing.Size(111, 54)
        '
        'BTN_RowSelect
        '
        Me.BTN_RowSelect.Name = "BTN_RowSelect"
        Me.BTN_RowSelect.Size = New System.Drawing.Size(110, 22)
        Me.BTN_RowSelect.Text = "시작행"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(107, 6)
        '
        'BTN_ExcelToGrid2
        '
        Me.BTN_ExcelToGrid2.Name = "BTN_ExcelToGrid2"
        Me.BTN_ExcelToGrid2.Size = New System.Drawing.Size(110, 22)
        Me.BTN_ExcelToGrid2.Text = "변환"
        '
        'CMS_ColumnMenu
        '
        Me.CMS_ColumnMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_PartCode, Me.BTN_PartNo, Me.BTN_Qty, Me.ToolStripSeparator2, Me.BTN_ExcelToGrid})
        Me.CMS_ColumnMenu.Name = "CMS_Menu"
        Me.CMS_ColumnMenu.Size = New System.Drawing.Size(123, 98)
        '
        'BTN_PartCode
        '
        Me.BTN_PartCode.Name = "BTN_PartCode"
        Me.BTN_PartCode.Size = New System.Drawing.Size(122, 22)
        Me.BTN_PartCode.Text = "자재코드"
        '
        'BTN_PartNo
        '
        Me.BTN_PartNo.Name = "BTN_PartNo"
        Me.BTN_PartNo.Size = New System.Drawing.Size(122, 22)
        Me.BTN_PartNo.Text = "Part No"
        '
        'BTN_Qty
        '
        Me.BTN_Qty.Name = "BTN_Qty"
        Me.BTN_Qty.Size = New System.Drawing.Size(122, 22)
        Me.BTN_Qty.Text = "입고수량"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(119, 6)
        '
        'BTN_ExcelToGrid
        '
        Me.BTN_ExcelToGrid.Name = "BTN_ExcelToGrid"
        Me.BTN_ExcelToGrid.Size = New System.Drawing.Size(122, 22)
        Me.BTN_ExcelToGrid.Text = "변환"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'BTN_NewDocuments
        '
        Me.BTN_NewDocuments.Image = Global.YJ_MMS.My.Resources.Resources.plus_blue
        Me.BTN_NewDocuments.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_NewDocuments.Name = "BTN_NewDocuments"
        Me.BTN_NewDocuments.Size = New System.Drawing.Size(75, 22)
        Me.BTN_NewDocuments.Text = "신규등록"
        '
        'CB_Supplier
        '
        Me.CB_Supplier.Enabled = False
        Me.CB_Supplier.FormattingEnabled = True
        Me.CB_Supplier.Location = New System.Drawing.Point(601, 31)
        Me.CB_Supplier.Name = "CB_Supplier"
        Me.CB_Supplier.Size = New System.Drawing.Size(626, 20)
        Me.CB_Supplier.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(431, 31)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(170, 21)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "공급사"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'frm_Supplier_Document_Register
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1464, 773)
        Me.Controls.Add(Me.CB_Supplier)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TS_MainBar)
        Me.Name = "frm_Supplier_Document_Register"
        Me.Text = "입고 리스트 등록"
        Me.TS_MainBar.ResumeLayout(False)
        Me.TS_MainBar.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Grid_DocumentsList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.Grid_Excel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_RowMenu.ResumeLayout(False)
        Me.CMS_ColumnMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TS_MainBar As ToolStrip
    Friend WithEvents Form_CLose As ToolStripButton
    Friend WithEvents BTN_Search As ToolStripButton
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Grid_DocumentsList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents CB_SheetName As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Grid_Excel As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TB_File_Path As TextBox
    Friend WithEvents BTN_FileSelect As Button
    Friend WithEvents CMS_RowMenu As ContextMenuStrip
    Friend WithEvents BTN_RowSelect As ToolStripMenuItem
    Friend WithEvents CMS_ColumnMenu As ContextMenuStrip
    Friend WithEvents BTN_PartCode As ToolStripMenuItem
    Friend WithEvents BTN_PartNo As ToolStripMenuItem
    Friend WithEvents BTN_Qty As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BTN_ExcelToGrid2 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents BTN_ExcelToGrid As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents BTN_NewDocuments As ToolStripButton
    Friend WithEvents CB_Supplier As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents BTN_Save As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
End Class
