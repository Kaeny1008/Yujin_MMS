<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Material_Warehousing_List
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Material_Warehousing_List))
        Me.TS_MainBar = New System.Windows.Forms.ToolStrip()
        Me.BTN_NewList = New System.Windows.Forms.ToolStripButton()
        Me.Form_CLose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_Search = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.BTN_ListAdd = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TB_CustomerPartCode = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TB_Qty = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TB_LotNo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TB_PartNo = New System.Windows.Forms.TextBox()
        Me.TB_BarcodeScan = New System.Windows.Forms.TextBox()
        Me.CB_Vendor = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RB_PrintNotUse = New System.Windows.Forms.RadioButton()
        Me.RB_PrintUse = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RB_VendorCode = New System.Windows.Forms.RadioButton()
        Me.RB_CustomerCode = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TB_HSNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CB_CustomerName = New System.Windows.Forms.ComboBox()
        Me.TB_CustomerCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Grid_PartList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TS_MainBar.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Grid_PartList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TS_MainBar
        '
        Me.TS_MainBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_NewList, Me.Form_CLose, Me.ToolStripSeparator1, Me.BTN_Search})
        Me.TS_MainBar.Location = New System.Drawing.Point(0, 0)
        Me.TS_MainBar.Name = "TS_MainBar"
        Me.TS_MainBar.Size = New System.Drawing.Size(1264, 25)
        Me.TS_MainBar.TabIndex = 0
        Me.TS_MainBar.Text = "ToolStrip1"
        '
        'BTN_NewList
        '
        Me.BTN_NewList.Image = Global.YJ_MMS.My.Resources.Resources.plus_blue
        Me.BTN_NewList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_NewList.Name = "BTN_NewList"
        Me.BTN_NewList.Size = New System.Drawing.Size(75, 22)
        Me.BTN_NewList.Text = "신규등록"
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
        'BTN_Search
        '
        Me.BTN_Search.Image = Global.YJ_MMS.My.Resources.Resources.search_121
        Me.BTN_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_Search.Name = "BTN_Search"
        Me.BTN_Search.Size = New System.Drawing.Size(107, 22)
        Me.BTN_Search.Text = "검색(오늘입고)"
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
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label12)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BTN_ListAdd)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_BarcodeScan)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CB_Vendor)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_HSNo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CB_CustomerName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_CustomerCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Grid_PartList)
        Me.SplitContainer1.Size = New System.Drawing.Size(1264, 748)
        Me.SplitContainer1.SplitterDistance = 458
        Me.SplitContainer1.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("굴림", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Yellow
        Me.Label12.Location = New System.Drawing.Point(71, 400)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(328, 125)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "등록 성공"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BTN_ListAdd
        '
        Me.BTN_ListAdd.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_ListAdd.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.BTN_ListAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_ListAdd.Location = New System.Drawing.Point(334, 297)
        Me.BTN_ListAdd.Name = "BTN_ListAdd"
        Me.BTN_ListAdd.Size = New System.Drawing.Size(120, 71)
        Me.BTN_ListAdd.TabIndex = 16
        Me.BTN_ListAdd.Text = "입고등록"
        Me.BTN_ListAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_ListAdd.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.TB_CustomerPartCode)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.TB_Qty)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.TB_LotNo)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.TB_PartNo)
        Me.Panel3.Location = New System.Drawing.Point(174, 171)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(280, 120)
        Me.Panel3.TabIndex = 15
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(10, 91)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 16)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "자재코드 :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_CustomerPartCode
        '
        Me.TB_CustomerPartCode.Enabled = False
        Me.TB_CustomerPartCode.Location = New System.Drawing.Point(77, 89)
        Me.TB_CustomerPartCode.Name = "TB_CustomerPartCode"
        Me.TB_CustomerPartCode.Size = New System.Drawing.Size(194, 21)
        Me.TB_CustomerPartCode.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(10, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 16)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "수량 :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_Qty
        '
        Me.TB_Qty.Location = New System.Drawing.Point(77, 62)
        Me.TB_Qty.Name = "TB_Qty"
        Me.TB_Qty.Size = New System.Drawing.Size(194, 21)
        Me.TB_Qty.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(10, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 16)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Lot No. :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_LotNo
        '
        Me.TB_LotNo.Location = New System.Drawing.Point(77, 35)
        Me.TB_LotNo.Name = "TB_LotNo"
        Me.TB_LotNo.Size = New System.Drawing.Size(194, 21)
        Me.TB_LotNo.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(10, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 16)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Part No. :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_PartNo
        '
        Me.TB_PartNo.Location = New System.Drawing.Point(77, 8)
        Me.TB_PartNo.Name = "TB_PartNo"
        Me.TB_PartNo.Size = New System.Drawing.Size(194, 21)
        Me.TB_PartNo.TabIndex = 0
        '
        'TB_BarcodeScan
        '
        Me.TB_BarcodeScan.BackColor = System.Drawing.SystemColors.Window
        Me.TB_BarcodeScan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TB_BarcodeScan.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_BarcodeScan.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_BarcodeScan.Location = New System.Drawing.Point(174, 144)
        Me.TB_BarcodeScan.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_BarcodeScan.Name = "TB_BarcodeScan"
        Me.TB_BarcodeScan.Size = New System.Drawing.Size(280, 25)
        Me.TB_BarcodeScan.TabIndex = 14
        '
        'CB_Vendor
        '
        Me.CB_Vendor.Font = New System.Drawing.Font("굴림", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CB_Vendor.FormattingEnabled = True
        Me.CB_Vendor.Location = New System.Drawing.Point(174, 117)
        Me.CB_Vendor.Margin = New System.Windows.Forms.Padding(0)
        Me.CB_Vendor.Name = "CB_Vendor"
        Me.CB_Vendor.Size = New System.Drawing.Size(280, 25)
        Me.CB_Vendor.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(9, 171)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(165, 120)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "7. Scan 결과"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(9, 144)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(165, 25)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "6. Barcode Scan"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(9, 117)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(165, 25)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "5. Vendor 선택"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.Controls.Add(Me.RB_PrintNotUse)
        Me.Panel2.Controls.Add(Me.RB_PrintUse)
        Me.Panel2.Location = New System.Drawing.Point(174, 90)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(280, 25)
        Me.Panel2.TabIndex = 9
        '
        'RB_PrintNotUse
        '
        Me.RB_PrintNotUse.AutoSize = True
        Me.RB_PrintNotUse.Checked = True
        Me.RB_PrintNotUse.Location = New System.Drawing.Point(142, 6)
        Me.RB_PrintNotUse.Name = "RB_PrintNotUse"
        Me.RB_PrintNotUse.Size = New System.Drawing.Size(59, 16)
        Me.RB_PrintNotUse.TabIndex = 7
        Me.RB_PrintNotUse.TabStop = True
        Me.RB_PrintNotUse.Text = "미발행"
        Me.RB_PrintNotUse.UseVisualStyleBackColor = True
        '
        'RB_PrintUse
        '
        Me.RB_PrintUse.AutoSize = True
        Me.RB_PrintUse.Location = New System.Drawing.Point(17, 6)
        Me.RB_PrintUse.Name = "RB_PrintUse"
        Me.RB_PrintUse.Size = New System.Drawing.Size(47, 16)
        Me.RB_PrintUse.TabIndex = 6
        Me.RB_PrintUse.Text = "발행"
        Me.RB_PrintUse.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 90)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 25)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "4. Label 발행여부"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.RB_VendorCode)
        Me.Panel1.Controls.Add(Me.RB_CustomerCode)
        Me.Panel1.Location = New System.Drawing.Point(174, 63)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(280, 25)
        Me.Panel1.TabIndex = 7
        '
        'RB_VendorCode
        '
        Me.RB_VendorCode.AutoSize = True
        Me.RB_VendorCode.Checked = True
        Me.RB_VendorCode.Location = New System.Drawing.Point(142, 6)
        Me.RB_VendorCode.Name = "RB_VendorCode"
        Me.RB_VendorCode.Size = New System.Drawing.Size(97, 16)
        Me.RB_VendorCode.TabIndex = 7
        Me.RB_VendorCode.TabStop = True
        Me.RB_VendorCode.Text = "Vendor Code"
        Me.RB_VendorCode.UseVisualStyleBackColor = True
        '
        'RB_CustomerCode
        '
        Me.RB_CustomerCode.AutoSize = True
        Me.RB_CustomerCode.Location = New System.Drawing.Point(17, 6)
        Me.RB_CustomerCode.Name = "RB_CustomerCode"
        Me.RB_CustomerCode.Size = New System.Drawing.Size(93, 16)
        Me.RB_CustomerCode.TabIndex = 6
        Me.RB_CustomerCode.Text = "고객사 Code"
        Me.RB_CustomerCode.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(9, 63)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 25)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "3. Barcode 유형"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_HSNo
        '
        Me.TB_HSNo.BackColor = System.Drawing.SystemColors.Window
        Me.TB_HSNo.Enabled = False
        Me.TB_HSNo.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_HSNo.Location = New System.Drawing.Point(174, 9)
        Me.TB_HSNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_HSNo.Name = "TB_HSNo"
        Me.TB_HSNo.Size = New System.Drawing.Size(280, 25)
        Me.TB_HSNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "1. 입고 No."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CB_CustomerName
        '
        Me.CB_CustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_CustomerName.Font = New System.Drawing.Font("굴림", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CB_CustomerName.FormattingEnabled = True
        Me.CB_CustomerName.Location = New System.Drawing.Point(174, 36)
        Me.CB_CustomerName.Margin = New System.Windows.Forms.Padding(0)
        Me.CB_CustomerName.Name = "CB_CustomerName"
        Me.CB_CustomerName.Size = New System.Drawing.Size(160, 25)
        Me.CB_CustomerName.TabIndex = 3
        '
        'TB_CustomerCode
        '
        Me.TB_CustomerCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerCode.Enabled = False
        Me.TB_CustomerCode.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_CustomerCode.Location = New System.Drawing.Point(334, 36)
        Me.TB_CustomerCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerCode.Name = "TB_CustomerCode"
        Me.TB_CustomerCode.Size = New System.Drawing.Size(120, 25)
        Me.TB_CustomerCode.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(9, 36)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(165, 25)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "2. 사용고객사"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Grid_PartList
        '
        Me.Grid_PartList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_PartList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_PartList.Location = New System.Drawing.Point(0, 0)
        Me.Grid_PartList.Name = "Grid_PartList"
        Me.Grid_PartList.Rows.Count = 2
        Me.Grid_PartList.Rows.DefaultSize = 20
        Me.Grid_PartList.Size = New System.Drawing.Size(802, 748)
        Me.Grid_PartList.StyleInfo = resources.GetString("Grid_PartList.StyleInfo")
        Me.Grid_PartList.TabIndex = 0
        '
        'Timer1
        '
        '
        'frm_Material_Warehousing_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 773)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TS_MainBar)
        Me.Name = "frm_Material_Warehousing_List"
        Me.Text = "자재입고(라벨발행)"
        Me.TS_MainBar.ResumeLayout(False)
        Me.TS_MainBar.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Grid_PartList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TS_MainBar As ToolStrip
    Friend WithEvents BTN_NewList As ToolStripButton
    Friend WithEvents Form_CLose As ToolStripButton
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Grid_PartList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TB_CustomerCode As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents CB_CustomerName As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents RB_PrintNotUse As RadioButton
    Friend WithEvents RB_PrintUse As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents RB_VendorCode As RadioButton
    Friend WithEvents RB_CustomerCode As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents TB_HSNo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_BarcodeScan As TextBox
    Friend WithEvents CB_Vendor As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents TB_CustomerPartCode As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TB_Qty As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TB_LotNo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TB_PartNo As TextBox
    Friend WithEvents BTN_ListAdd As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BTN_Search As ToolStripButton
End Class
