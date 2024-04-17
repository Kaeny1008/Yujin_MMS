<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SolderPaste_Warehousing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_SolderPaste_Warehousing))
        Me.TS_MainBar = New System.Windows.Forms.ToolStrip()
        Me.BTN_New = New System.Windows.Forms.ToolStripButton()
        Me.Form_CLose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_Save = New System.Windows.Forms.ToolStripButton()
        Me.Grid_SolderList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TB_Barcode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CB_Weight = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CB_Product = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CB_Vendor = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TS_MainBar.SuspendLayout()
        CType(Me.Grid_SolderList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TS_MainBar
        '
        Me.TS_MainBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_New, Me.Form_CLose, Me.ToolStripSeparator1, Me.BTN_Save})
        Me.TS_MainBar.Location = New System.Drawing.Point(0, 0)
        Me.TS_MainBar.Name = "TS_MainBar"
        Me.TS_MainBar.Size = New System.Drawing.Size(1264, 25)
        Me.TS_MainBar.TabIndex = 3
        Me.TS_MainBar.Text = "ToolStrip1"
        '
        'BTN_New
        '
        Me.BTN_New.Image = Global.YJ_MMS.My.Resources.Resources.plus_blue
        Me.BTN_New.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_New.Name = "BTN_New"
        Me.BTN_New.Size = New System.Drawing.Size(75, 22)
        Me.BTN_New.Text = "신규입고"
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
        'Grid_SolderList
        '
        Me.Grid_SolderList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_SolderList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_SolderList.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Grid_SolderList.Location = New System.Drawing.Point(0, 118)
        Me.Grid_SolderList.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_SolderList.Name = "Grid_SolderList"
        Me.Grid_SolderList.Rows.Count = 2
        Me.Grid_SolderList.Rows.DefaultSize = 20
        Me.Grid_SolderList.Size = New System.Drawing.Size(1264, 603)
        Me.Grid_SolderList.StyleInfo = resources.GetString("Grid_SolderList.StyleInfo")
        Me.Grid_SolderList.TabIndex = 6
        Me.Grid_SolderList.UseCompatibleTextRendering = True
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel5.Controls.Add(Me.DateTimePicker1)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.TB_Barcode)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.CB_Weight)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.CB_Product)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.CB_Vendor)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 25)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1264, 93)
        Me.Panel5.TabIndex = 5
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.DateTimePicker1.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(100, 46)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(0)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(146, 26)
        Me.DateTimePicker1.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(9, 46)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 26)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "유효기간"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Barcode
        '
        Me.TB_Barcode.Enabled = False
        Me.TB_Barcode.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_Barcode.Location = New System.Drawing.Point(368, 46)
        Me.TB_Barcode.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_Barcode.Name = "TB_Barcode"
        Me.TB_Barcode.Size = New System.Drawing.Size(392, 26)
        Me.TB_Barcode.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(246, 46)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 26)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Lot No.(Serial)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CB_Weight
        '
        Me.CB_Weight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Weight.Enabled = False
        Me.CB_Weight.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CB_Weight.FormattingEnabled = True
        Me.CB_Weight.Items.AddRange(New Object() {"250g", "500g"})
        Me.CB_Weight.Location = New System.Drawing.Point(653, 20)
        Me.CB_Weight.Margin = New System.Windows.Forms.Padding(0)
        Me.CB_Weight.Name = "CB_Weight"
        Me.CB_Weight.Size = New System.Drawing.Size(107, 24)
        Me.CB_Weight.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(577, 20)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 24)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "중량"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CB_Product
        '
        Me.CB_Product.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Product.Enabled = False
        Me.CB_Product.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CB_Product.FormattingEnabled = True
        Me.CB_Product.Location = New System.Drawing.Point(368, 20)
        Me.CB_Product.Margin = New System.Windows.Forms.Padding(0)
        Me.CB_Product.Name = "CB_Product"
        Me.CB_Product.Size = New System.Drawing.Size(209, 24)
        Me.CB_Product.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(292, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 24)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "제품명"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CB_Vendor
        '
        Me.CB_Vendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Vendor.Enabled = False
        Me.CB_Vendor.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CB_Vendor.FormattingEnabled = True
        Me.CB_Vendor.Location = New System.Drawing.Point(100, 20)
        Me.CB_Vendor.Margin = New System.Windows.Forms.Padding(0)
        Me.CB_Vendor.Name = "CB_Vendor"
        Me.CB_Vendor.Size = New System.Drawing.Size(192, 24)
        Me.CB_Vendor.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 20)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 24)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "제조사"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 721)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1264, 52)
        Me.Panel1.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Location = New System.Drawing.Point(214, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(191, 26)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "총 중량 : 0 g"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Location = New System.Drawing.Point(12, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(204, 26)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "입고수량 : 0 EA"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frm_SolderPaste_Warehousing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 773)
        Me.Controls.Add(Me.Grid_SolderList)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.TS_MainBar)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frm_SolderPaste_Warehousing"
        Me.Text = "솔더관리 - 입고등록"
        Me.TS_MainBar.ResumeLayout(False)
        Me.TS_MainBar.PerformLayout()
        CType(Me.Grid_SolderList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TS_MainBar As ToolStrip
    Friend WithEvents BTN_New As ToolStripButton
    Friend WithEvents Form_CLose As ToolStripButton
    Friend WithEvents Grid_SolderList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel5 As Panel
    Friend WithEvents CB_Weight As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CB_Product As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CB_Vendor As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BTN_Save As ToolStripButton
    Friend WithEvents TB_Barcode As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label7 As Label
End Class
