<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Popup_MultiPartsCode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Popup_MultiPartsCode))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TB_PartType = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TB_PartCategory = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TB_Vendor = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TB_Specification = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TB_PartCode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TB_StartRow = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTN_FileSelect = New System.Windows.Forms.Button()
        Me.TB_File_Path = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Grid_Excel = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CB_SheetName = New System.Windows.Forms.ComboBox()
        Me.BTN_Start = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TB_PartSupplier = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Grid_Excel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox1.Controls.Add(Me.TB_PartSupplier)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TB_PartType)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TB_PartCategory)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.TB_Vendor)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TB_Specification)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TB_PartCode)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TB_StartRow)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(12, 330)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(871, 76)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "위치 설정"
        '
        'TB_PartType
        '
        Me.TB_PartType.BackColor = System.Drawing.SystemColors.Window
        Me.TB_PartType.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_PartType.Location = New System.Drawing.Point(243, 23)
        Me.TB_PartType.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_PartType.Name = "TB_PartType"
        Me.TB_PartType.Size = New System.Drawing.Size(50, 21)
        Me.TB_PartType.TabIndex = 27
        Me.TB_PartType.Text = "3"
        Me.TB_PartType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(151, 23)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 21)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "타입"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TB_PartCategory
        '
        Me.TB_PartCategory.BackColor = System.Drawing.SystemColors.Window
        Me.TB_PartCategory.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_PartCategory.Location = New System.Drawing.Point(811, 23)
        Me.TB_PartCategory.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_PartCategory.Name = "TB_PartCategory"
        Me.TB_PartCategory.Size = New System.Drawing.Size(50, 21)
        Me.TB_PartCategory.TabIndex = 25
        Me.TB_PartCategory.Text = "3"
        Me.TB_PartCategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(719, 23)
        Me.Label14.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(92, 21)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "사/도급"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TB_Vendor
        '
        Me.TB_Vendor.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Vendor.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_Vendor.Location = New System.Drawing.Point(669, 23)
        Me.TB_Vendor.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Vendor.Name = "TB_Vendor"
        Me.TB_Vendor.Size = New System.Drawing.Size(50, 21)
        Me.TB_Vendor.TabIndex = 7
        Me.TB_Vendor.Text = "5"
        Me.TB_Vendor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(577, 23)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 21)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Vendor"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TB_Specification
        '
        Me.TB_Specification.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Specification.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_Specification.Location = New System.Drawing.Point(527, 23)
        Me.TB_Specification.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Specification.Name = "TB_Specification"
        Me.TB_Specification.Size = New System.Drawing.Size(50, 21)
        Me.TB_Specification.TabIndex = 5
        Me.TB_Specification.Text = "4"
        Me.TB_Specification.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(435, 23)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 21)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "사양"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TB_PartCode
        '
        Me.TB_PartCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_PartCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_PartCode.Location = New System.Drawing.Point(385, 23)
        Me.TB_PartCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_PartCode.Name = "TB_PartCode"
        Me.TB_PartCode.Size = New System.Drawing.Size(50, 21)
        Me.TB_PartCode.TabIndex = 3
        Me.TB_PartCode.Text = "3"
        Me.TB_PartCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(293, 23)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 21)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "자재코드"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TB_StartRow
        '
        Me.TB_StartRow.BackColor = System.Drawing.SystemColors.Window
        Me.TB_StartRow.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_StartRow.Location = New System.Drawing.Point(101, 23)
        Me.TB_StartRow.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_StartRow.Name = "TB_StartRow"
        Me.TB_StartRow.Size = New System.Drawing.Size(50, 21)
        Me.TB_StartRow.TabIndex = 1
        Me.TB_StartRow.Text = "2"
        Me.TB_StartRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 23)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "시작행"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BTN_FileSelect
        '
        Me.BTN_FileSelect.Location = New System.Drawing.Point(808, 9)
        Me.BTN_FileSelect.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.BTN_FileSelect.Name = "BTN_FileSelect"
        Me.BTN_FileSelect.Size = New System.Drawing.Size(75, 23)
        Me.BTN_FileSelect.TabIndex = 8
        Me.BTN_FileSelect.Text = "파일선택"
        Me.BTN_FileSelect.UseVisualStyleBackColor = True
        '
        'TB_File_Path
        '
        Me.TB_File_Path.BackColor = System.Drawing.SystemColors.Window
        Me.TB_File_Path.Enabled = False
        Me.TB_File_Path.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_File_Path.Location = New System.Drawing.Point(182, 10)
        Me.TB_File_Path.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_File_Path.Name = "TB_File_Path"
        Me.TB_File_Path.Size = New System.Drawing.Size(626, 21)
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
        Me.CB_SheetName.Size = New System.Drawing.Size(626, 20)
        Me.CB_SheetName.TabIndex = 11
        '
        'BTN_Start
        '
        Me.BTN_Start.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_Start.Image = Global.YJ_MMS.My.Resources.Resources.sitemap
        Me.BTN_Start.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_Start.Location = New System.Drawing.Point(778, 435)
        Me.BTN_Start.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.BTN_Start.Name = "BTN_Start"
        Me.BTN_Start.Size = New System.Drawing.Size(105, 51)
        Me.BTN_Start.TabIndex = 12
        Me.BTN_Start.Text = "다중등록"
        Me.BTN_Start.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_Start.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(680, 439)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 48)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "1. 파일선택" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2. 시트선택" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3. 위치설정" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "4. 다중등록 버튼"
        '
        'TB_PartSupplier
        '
        Me.TB_PartSupplier.BackColor = System.Drawing.SystemColors.Window
        Me.TB_PartSupplier.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_PartSupplier.Location = New System.Drawing.Point(101, 46)
        Me.TB_PartSupplier.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_PartSupplier.Name = "TB_PartSupplier"
        Me.TB_PartSupplier.Size = New System.Drawing.Size(50, 21)
        Me.TB_PartSupplier.TabIndex = 29
        Me.TB_PartSupplier.Text = "3"
        Me.TB_PartSupplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(9, 46)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 21)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "공급사"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frm_Popup_MultiPartsCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(899, 498)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.BTN_Start)
        Me.Controls.Add(Me.CB_SheetName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Grid_Excel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BTN_FileSelect)
        Me.Controls.Add(Me.TB_File_Path)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Popup_MultiPartsCode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "자재코드 다중등록"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Grid_Excel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TB_PartCategory As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TB_Vendor As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TB_Specification As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TB_PartCode As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TB_StartRow As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BTN_FileSelect As Button
    Friend WithEvents TB_File_Path As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Grid_Excel As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label6 As Label
    Friend WithEvents CB_SheetName As ComboBox
    Friend WithEvents BTN_Start As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents TB_PartType As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TB_PartSupplier As TextBox
    Friend WithEvents Label9 As Label
End Class
