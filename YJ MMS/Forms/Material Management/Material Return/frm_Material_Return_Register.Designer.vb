<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Material_Return_Register
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Material_Return_Register))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TB_CustomerCode = New System.Windows.Forms.TextBox()
        Me.TB_Barcode = New System.Windows.Forms.TextBox()
        Me.CB_CustomerName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TB_Qty = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TB_LotNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TB_PartNo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TB_ItemCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TB_Vendor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TB_ReturnQty = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TB_Reason = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Grid_History = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BTN_Grid_Add = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TB_InDate = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.Grid_History, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TB_CustomerCode)
        Me.Panel1.Controls.Add(Me.TB_Barcode)
        Me.Panel1.Controls.Add(Me.CB_CustomerName)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 69)
        Me.Panel1.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(15, 10)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 21)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "고객사"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_CustomerCode
        '
        Me.TB_CustomerCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerCode.Enabled = False
        Me.TB_CustomerCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_CustomerCode.Location = New System.Drawing.Point(357, 10)
        Me.TB_CustomerCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerCode.Name = "TB_CustomerCode"
        Me.TB_CustomerCode.Size = New System.Drawing.Size(133, 21)
        Me.TB_CustomerCode.TabIndex = 2
        '
        'TB_Barcode
        '
        Me.TB_Barcode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Barcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TB_Barcode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_Barcode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_Barcode.Location = New System.Drawing.Point(91, 33)
        Me.TB_Barcode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Barcode.Name = "TB_Barcode"
        Me.TB_Barcode.Size = New System.Drawing.Size(399, 21)
        Me.TB_Barcode.TabIndex = 4
        '
        'CB_CustomerName
        '
        Me.CB_CustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_CustomerName.FormattingEnabled = True
        Me.CB_CustomerName.Location = New System.Drawing.Point(91, 10)
        Me.CB_CustomerName.Margin = New System.Windows.Forms.Padding(0)
        Me.CB_CustomerName.Name = "CB_CustomerName"
        Me.CB_CustomerName.Size = New System.Drawing.Size(266, 20)
        Me.CB_CustomerName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(15, 33)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 21)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Barcode"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BTN_Save
        '
        Me.BTN_Save.BackColor = System.Drawing.Color.BurlyWood
        Me.BTN_Save.Image = Global.YJ_MMS.My.Resources.Resources.checkmark
        Me.BTN_Save.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_Save.Location = New System.Drawing.Point(678, 269)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(96, 59)
        Me.BTN_Save.TabIndex = 5
        Me.BTN_Save.Text = "반출 목록 저장"
        Me.BTN_Save.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_Save.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 259)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(273, 12)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "※ 수량은 사용이력으로 인해 상이할 수 있습니다."
        '
        'TB_Qty
        '
        Me.TB_Qty.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Qty.Enabled = False
        Me.TB_Qty.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_Qty.Location = New System.Drawing.Point(91, 210)
        Me.TB_Qty.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Qty.Name = "TB_Qty"
        Me.TB_Qty.Size = New System.Drawing.Size(238, 21)
        Me.TB_Qty.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(15, 210)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 21)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Qty"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_LotNo
        '
        Me.TB_LotNo.BackColor = System.Drawing.SystemColors.Window
        Me.TB_LotNo.Enabled = False
        Me.TB_LotNo.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_LotNo.Location = New System.Drawing.Point(91, 187)
        Me.TB_LotNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_LotNo.Name = "TB_LotNo"
        Me.TB_LotNo.Size = New System.Drawing.Size(238, 21)
        Me.TB_LotNo.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(15, 187)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 21)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Lot No."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_PartNo
        '
        Me.TB_PartNo.BackColor = System.Drawing.SystemColors.Window
        Me.TB_PartNo.Enabled = False
        Me.TB_PartNo.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_PartNo.Location = New System.Drawing.Point(91, 164)
        Me.TB_PartNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_PartNo.Name = "TB_PartNo"
        Me.TB_PartNo.Size = New System.Drawing.Size(238, 21)
        Me.TB_PartNo.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(15, 164)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 21)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Part No."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_ItemCode
        '
        Me.TB_ItemCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ItemCode.Enabled = False
        Me.TB_ItemCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_ItemCode.Location = New System.Drawing.Point(91, 141)
        Me.TB_ItemCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_ItemCode.Name = "TB_ItemCode"
        Me.TB_ItemCode.Size = New System.Drawing.Size(238, 21)
        Me.TB_ItemCode.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(15, 141)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 21)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Item Code"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 16)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "[ 자재 정보 ]"
        '
        'TB_Vendor
        '
        Me.TB_Vendor.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Vendor.Enabled = False
        Me.TB_Vendor.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_Vendor.Location = New System.Drawing.Point(91, 118)
        Me.TB_Vendor.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Vendor.Name = "TB_Vendor"
        Me.TB_Vendor.Size = New System.Drawing.Size(238, 21)
        Me.TB_Vendor.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(15, 118)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 21)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Vendor"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.Location = New System.Drawing.Point(404, 84)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 16)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "[ 반출 정보 ]"
        '
        'TB_ReturnQty
        '
        Me.TB_ReturnQty.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ReturnQty.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_ReturnQty.Location = New System.Drawing.Point(483, 118)
        Me.TB_ReturnQty.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_ReturnQty.Name = "TB_ReturnQty"
        Me.TB_ReturnQty.Size = New System.Drawing.Size(238, 21)
        Me.TB_ReturnQty.TabIndex = 26
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.CadetBlue
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(407, 118)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 21)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Qty"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Reason
        '
        Me.TB_Reason.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Reason.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_Reason.Location = New System.Drawing.Point(483, 141)
        Me.TB_Reason.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Reason.Name = "TB_Reason"
        Me.TB_Reason.Size = New System.Drawing.Size(238, 21)
        Me.TB_Reason.TabIndex = 28
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.CadetBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(407, 141)
        Me.Label12.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 21)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "반출사유"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label13.Location = New System.Drawing.Point(14, 312)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 16)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "[ 반출 목록 ]"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Grid_History)
        Me.Panel2.Location = New System.Drawing.Point(12, 331)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(762, 256)
        Me.Panel2.TabIndex = 30
        '
        'Grid_History
        '
        Me.Grid_History.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_History.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_History.Location = New System.Drawing.Point(0, 0)
        Me.Grid_History.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_History.Name = "Grid_History"
        Me.Grid_History.Rows.Count = 2
        Me.Grid_History.Rows.DefaultSize = 20
        Me.Grid_History.Size = New System.Drawing.Size(762, 256)
        Me.Grid_History.StyleInfo = resources.GetString("Grid_History.StyleInfo")
        Me.Grid_History.TabIndex = 10
        '
        'BTN_Grid_Add
        '
        Me.BTN_Grid_Add.Image = Global.YJ_MMS.My.Resources.Resources.arrow_down
        Me.BTN_Grid_Add.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_Grid_Add.Location = New System.Drawing.Point(407, 176)
        Me.BTN_Grid_Add.Name = "BTN_Grid_Add"
        Me.BTN_Grid_Add.Size = New System.Drawing.Size(96, 53)
        Me.BTN_Grid_Add.TabIndex = 31
        Me.BTN_Grid_Add.Text = "반출 목록 등록"
        Me.BTN_Grid_Add.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTN_Grid_Add.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(184, 312)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 12)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "Label14"
        Me.Label14.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TextBox1.Location = New System.Drawing.Point(285, 256)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(44, 21)
        Me.TextBox1.TabIndex = 33
        '
        'TB_InDate
        '
        Me.TB_InDate.BackColor = System.Drawing.SystemColors.Window
        Me.TB_InDate.Enabled = False
        Me.TB_InDate.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_InDate.Location = New System.Drawing.Point(91, 233)
        Me.TB_InDate.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_InDate.Name = "TB_InDate"
        Me.TB_InDate.Size = New System.Drawing.Size(238, 21)
        Me.TB_InDate.TabIndex = 35
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.SteelBlue
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(15, 233)
        Me.Label15.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 21)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "입고일자"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frm_Material_Return_Register
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(786, 599)
        Me.Controls.Add(Me.TB_InDate)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.BTN_Save)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.BTN_Grid_Add)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TB_Reason)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TB_ReturnQty)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TB_Qty)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TB_LotNo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TB_PartNo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TB_ItemCode)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TB_Vendor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frm_Material_Return_Register"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "자재 반출등록"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.Grid_History, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BTN_Save As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TB_CustomerCode As TextBox
    Friend WithEvents TB_Barcode As TextBox
    Friend WithEvents CB_CustomerName As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TB_Qty As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TB_LotNo As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TB_PartNo As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TB_ItemCode As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TB_Vendor As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TB_ReturnQty As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TB_Reason As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Grid_History As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BTN_Grid_Add As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TB_InDate As TextBox
    Friend WithEvents Label15 As Label
End Class
