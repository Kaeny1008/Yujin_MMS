<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_CodeChange
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
        Me.CB_CustomerName = New System.Windows.Forms.ComboBox()
        Me.TB_CustomerCode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TB_Barcode = New System.Windows.Forms.TextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TB_LastStockSuvey = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TB_WarehousingDate = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
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
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TB_Reason = New System.Windows.Forms.TextBox()
        Me.TB_AfterSpec = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TB_AfterVendor = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BTN_Check = New System.Windows.Forms.Button()
        Me.TB_AfterQty = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TB_AfterItemCode = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BTN_Save = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
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
        'TB_Barcode
        '
        Me.TB_Barcode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Barcode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_Barcode.Location = New System.Drawing.Point(91, 33)
        Me.TB_Barcode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Barcode.Name = "TB_Barcode"
        Me.TB_Barcode.Size = New System.Drawing.Size(399, 21)
        Me.TB_Barcode.TabIndex = 4
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 69)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_LastStockSuvey)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label18)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_WarehousingDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label12)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_Qty)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_LotNo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_PartNo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_ItemCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_Vendor)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.AntiqueWhite
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label16)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TB_Reason)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TB_AfterSpec)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label17)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TB_AfterVendor)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label15)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label14)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BTN_Check)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TB_AfterQty)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label13)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TB_AfterItemCode)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label11)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label10)
        Me.SplitContainer1.Size = New System.Drawing.Size(956, 381)
        Me.SplitContainer1.SplitterDistance = 486
        Me.SplitContainer1.TabIndex = 1
        '
        'TB_LastStockSuvey
        '
        Me.TB_LastStockSuvey.BackColor = System.Drawing.SystemColors.Window
        Me.TB_LastStockSuvey.Enabled = False
        Me.TB_LastStockSuvey.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_LastStockSuvey.Location = New System.Drawing.Point(15, 338)
        Me.TB_LastStockSuvey.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_LastStockSuvey.Name = "TB_LastStockSuvey"
        Me.TB_LastStockSuvey.Size = New System.Drawing.Size(238, 21)
        Me.TB_LastStockSuvey.TabIndex = 15
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.SteelBlue
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(15, 315)
        Me.Label18.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(238, 21)
        Me.Label18.TabIndex = 14
        Me.Label18.Text = "최근 재고조사일자"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_WarehousingDate
        '
        Me.TB_WarehousingDate.BackColor = System.Drawing.SystemColors.Window
        Me.TB_WarehousingDate.Enabled = False
        Me.TB_WarehousingDate.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_WarehousingDate.Location = New System.Drawing.Point(91, 172)
        Me.TB_WarehousingDate.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_WarehousingDate.Name = "TB_WarehousingDate"
        Me.TB_WarehousingDate.Size = New System.Drawing.Size(238, 21)
        Me.TB_WarehousingDate.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SteelBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(15, 172)
        Me.Label12.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 21)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "입고일자"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 197)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(273, 12)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "※ 수량은 사용이력으로 인해 상이할 수 있습니다."
        '
        'TB_Qty
        '
        Me.TB_Qty.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Qty.Enabled = False
        Me.TB_Qty.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_Qty.Location = New System.Drawing.Point(91, 148)
        Me.TB_Qty.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Qty.Name = "TB_Qty"
        Me.TB_Qty.Size = New System.Drawing.Size(238, 21)
        Me.TB_Qty.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(15, 148)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 21)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Qty"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_LotNo
        '
        Me.TB_LotNo.BackColor = System.Drawing.SystemColors.Window
        Me.TB_LotNo.Enabled = False
        Me.TB_LotNo.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_LotNo.Location = New System.Drawing.Point(91, 125)
        Me.TB_LotNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_LotNo.Name = "TB_LotNo"
        Me.TB_LotNo.Size = New System.Drawing.Size(238, 21)
        Me.TB_LotNo.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(15, 125)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 21)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Lot No."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_PartNo
        '
        Me.TB_PartNo.BackColor = System.Drawing.SystemColors.Window
        Me.TB_PartNo.Enabled = False
        Me.TB_PartNo.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_PartNo.Location = New System.Drawing.Point(91, 102)
        Me.TB_PartNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_PartNo.Name = "TB_PartNo"
        Me.TB_PartNo.Size = New System.Drawing.Size(238, 21)
        Me.TB_PartNo.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(15, 102)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 21)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Part No."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_ItemCode
        '
        Me.TB_ItemCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ItemCode.Enabled = False
        Me.TB_ItemCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_ItemCode.Location = New System.Drawing.Point(91, 79)
        Me.TB_ItemCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_ItemCode.Name = "TB_ItemCode"
        Me.TB_ItemCode.Size = New System.Drawing.Size(238, 21)
        Me.TB_ItemCode.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(15, 79)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 21)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Item Code"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(146, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "[ 기존품번 정보 ]"
        '
        'TB_Vendor
        '
        Me.TB_Vendor.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Vendor.Enabled = False
        Me.TB_Vendor.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_Vendor.Location = New System.Drawing.Point(91, 56)
        Me.TB_Vendor.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Vendor.Name = "TB_Vendor"
        Me.TB_Vendor.Size = New System.Drawing.Size(238, 21)
        Me.TB_Vendor.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(15, 56)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 21)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Vendor"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(15, 194)
        Me.Label16.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(88, 21)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "전환사유"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Reason
        '
        Me.TB_Reason.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Reason.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_Reason.Location = New System.Drawing.Point(103, 194)
        Me.TB_Reason.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Reason.Name = "TB_Reason"
        Me.TB_Reason.Size = New System.Drawing.Size(238, 21)
        Me.TB_Reason.TabIndex = 12
        '
        'TB_AfterSpec
        '
        Me.TB_AfterSpec.BackColor = System.Drawing.SystemColors.Window
        Me.TB_AfterSpec.Enabled = False
        Me.TB_AfterSpec.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_AfterSpec.Location = New System.Drawing.Point(103, 148)
        Me.TB_AfterSpec.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_AfterSpec.Name = "TB_AfterSpec"
        Me.TB_AfterSpec.Size = New System.Drawing.Size(238, 21)
        Me.TB_AfterSpec.TabIndex = 8
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.SteelBlue
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(15, 148)
        Me.Label17.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 21)
        Me.Label17.TabIndex = 7
        Me.Label17.Text = "Specification"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_AfterVendor
        '
        Me.TB_AfterVendor.BackColor = System.Drawing.SystemColors.Window
        Me.TB_AfterVendor.Enabled = False
        Me.TB_AfterVendor.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_AfterVendor.Location = New System.Drawing.Point(103, 125)
        Me.TB_AfterVendor.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_AfterVendor.Name = "TB_AfterVendor"
        Me.TB_AfterVendor.Size = New System.Drawing.Size(238, 21)
        Me.TB_AfterVendor.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.SteelBlue
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(15, 125)
        Me.Label15.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 21)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Vendor"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(101, 82)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(309, 24)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "- 변경할 Item Code를 입력한 후 확인버튼을 눌러주세요" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "   불러온 정보를 확인 후 수량을 입력하여 주십시오."
        '
        'BTN_Check
        '
        Me.BTN_Check.Location = New System.Drawing.Point(344, 54)
        Me.BTN_Check.Name = "BTN_Check"
        Me.BTN_Check.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Check.TabIndex = 3
        Me.BTN_Check.Text = "확인"
        Me.BTN_Check.UseVisualStyleBackColor = True
        '
        'TB_AfterQty
        '
        Me.TB_AfterQty.BackColor = System.Drawing.SystemColors.Window
        Me.TB_AfterQty.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_AfterQty.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_AfterQty.Location = New System.Drawing.Point(103, 171)
        Me.TB_AfterQty.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_AfterQty.Name = "TB_AfterQty"
        Me.TB_AfterQty.Size = New System.Drawing.Size(238, 21)
        Me.TB_AfterQty.TabIndex = 10
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(15, 171)
        Me.Label13.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 21)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Qty"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_AfterItemCode
        '
        Me.TB_AfterItemCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_AfterItemCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TB_AfterItemCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_AfterItemCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_AfterItemCode.Location = New System.Drawing.Point(103, 55)
        Me.TB_AfterItemCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_AfterItemCode.Name = "TB_AfterItemCode"
        Me.TB_AfterItemCode.Size = New System.Drawing.Size(238, 21)
        Me.TB_AfterItemCode.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(15, 55)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 21)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "ItemCode"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(146, 16)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "[ 변경품번 정보 ]"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.BTN_Save)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TB_CustomerCode)
        Me.Panel1.Controls.Add(Me.TB_Barcode)
        Me.Panel1.Controls.Add(Me.CB_CustomerName)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(956, 69)
        Me.Panel1.TabIndex = 0
        '
        'BTN_Save
        '
        Me.BTN_Save.Location = New System.Drawing.Point(836, 10)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(108, 53)
        Me.BTN_Save.TabIndex = 5
        Me.BTN_Save.Text = "변경내용 저장 및 프린트"
        Me.BTN_Save.UseVisualStyleBackColor = True
        '
        'frm_CodeChange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(956, 450)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_CodeChange"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "품번전환"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CB_CustomerName As ComboBox
    Friend WithEvents TB_CustomerCode As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_Barcode As TextBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Panel1 As Panel
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
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TB_AfterItemCode As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TB_AfterQty As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents BTN_Check As Button
    Friend WithEvents TB_AfterSpec As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents TB_AfterVendor As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents BTN_Save As Button
    Friend WithEvents TB_Reason As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TB_WarehousingDate As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TB_LastStockSuvey As TextBox
    Friend WithEvents Label18 As Label
End Class
