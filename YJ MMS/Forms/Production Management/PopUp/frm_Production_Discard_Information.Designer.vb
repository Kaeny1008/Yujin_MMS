<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Production_Discard_Information
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Production_Discard_Information))
        Me.TB_ManagementNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TB_BoardNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TB_Discard_Resone = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TB_Process = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TB_OrderQty = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TB_Workside = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TB_Inspector = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TB_OrderIndex = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TB_ItemName = New System.Windows.Forms.TextBox()
        Me.TB_ItemCode = New System.Windows.Forms.TextBox()
        Me.TB_ModelCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TB_CustomerName = New System.Windows.Forms.TextBox()
        Me.TB_CustomerCode = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Grid_SMD_Bottom = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.CB_SMD_Bottom = New System.Windows.Forms.CheckBox()
        Me.CB_SMD_Top = New System.Windows.Forms.CheckBox()
        Me.Grid_SMD_Top = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.CB_Dip = New System.Windows.Forms.CheckBox()
        Me.Grid_Dip = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BTN_Confirm = New System.Windows.Forms.Button()
        Me.Grid_Etc = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BTN_Cancel = New System.Windows.Forms.Button()
        Me.Grid_Menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_Move_SMD_Bottom = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Move_SMD_Top = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Move_Dip = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Move_ETC = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.Grid_SMD_Bottom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid_SMD_Top, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid_Dip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid_Etc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grid_Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TB_ManagementNo
        '
        Me.TB_ManagementNo.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ManagementNo.Enabled = False
        Me.TB_ManagementNo.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_ManagementNo.Location = New System.Drawing.Point(126, 121)
        Me.TB_ManagementNo.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_ManagementNo.Name = "TB_ManagementNo"
        Me.TB_ManagementNo.Size = New System.Drawing.Size(578, 26)
        Me.TB_ManagementNo.TabIndex = 48
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(9, 121)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 26)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "관리번호"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_BoardNo
        '
        Me.TB_BoardNo.BackColor = System.Drawing.SystemColors.Window
        Me.TB_BoardNo.Enabled = False
        Me.TB_BoardNo.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_BoardNo.Location = New System.Drawing.Point(126, 149)
        Me.TB_BoardNo.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_BoardNo.Name = "TB_BoardNo"
        Me.TB_BoardNo.Size = New System.Drawing.Size(578, 26)
        Me.TB_BoardNo.TabIndex = 44
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(9, 149)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 26)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Board No."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Discard_Resone
        '
        Me.TB_Discard_Resone.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Discard_Resone.Enabled = False
        Me.TB_Discard_Resone.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_Discard_Resone.Location = New System.Drawing.Point(126, 177)
        Me.TB_Discard_Resone.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_Discard_Resone.Multiline = True
        Me.TB_Discard_Resone.Name = "TB_Discard_Resone"
        Me.TB_Discard_Resone.Size = New System.Drawing.Size(578, 128)
        Me.TB_Discard_Resone.TabIndex = 46
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 177)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 128)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "폐기사유"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Process
        '
        Me.TB_Process.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Process.Enabled = False
        Me.TB_Process.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_Process.Location = New System.Drawing.Point(546, 93)
        Me.TB_Process.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_Process.Name = "TB_Process"
        Me.TB_Process.Size = New System.Drawing.Size(158, 26)
        Me.TB_Process.TabIndex = 42
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(457, 93)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 26)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "발생공정"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_OrderQty
        '
        Me.TB_OrderQty.BackColor = System.Drawing.SystemColors.Window
        Me.TB_OrderQty.Enabled = False
        Me.TB_OrderQty.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_OrderQty.Location = New System.Drawing.Point(546, 38)
        Me.TB_OrderQty.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_OrderQty.Name = "TB_OrderQty"
        Me.TB_OrderQty.Size = New System.Drawing.Size(158, 26)
        Me.TB_OrderQty.TabIndex = 34
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(457, 38)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 26)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "주문수량"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Workside
        '
        Me.TB_Workside.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Workside.Enabled = False
        Me.TB_Workside.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_Workside.Location = New System.Drawing.Point(546, 10)
        Me.TB_Workside.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_Workside.Name = "TB_Workside"
        Me.TB_Workside.Size = New System.Drawing.Size(158, 26)
        Me.TB_Workside.TabIndex = 29
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(457, 10)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 26)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "작업면"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Inspector
        '
        Me.TB_Inspector.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Inspector.Enabled = False
        Me.TB_Inspector.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_Inspector.Location = New System.Drawing.Point(546, 66)
        Me.TB_Inspector.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_Inspector.Name = "TB_Inspector"
        Me.TB_Inspector.Size = New System.Drawing.Size(158, 26)
        Me.TB_Inspector.TabIndex = 40
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(457, 66)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 26)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "Inspector"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_OrderIndex
        '
        Me.TB_OrderIndex.BackColor = System.Drawing.SystemColors.Window
        Me.TB_OrderIndex.Enabled = False
        Me.TB_OrderIndex.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_OrderIndex.Location = New System.Drawing.Point(126, 10)
        Me.TB_OrderIndex.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_OrderIndex.Name = "TB_OrderIndex"
        Me.TB_OrderIndex.Size = New System.Drawing.Size(331, 26)
        Me.TB_OrderIndex.TabIndex = 27
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(9, 10)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 26)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "주문번호"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_ItemName
        '
        Me.TB_ItemName.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ItemName.Enabled = False
        Me.TB_ItemName.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_ItemName.Location = New System.Drawing.Point(126, 93)
        Me.TB_ItemName.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_ItemName.Name = "TB_ItemName"
        Me.TB_ItemName.Size = New System.Drawing.Size(331, 26)
        Me.TB_ItemName.TabIndex = 38
        '
        'TB_ItemCode
        '
        Me.TB_ItemCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ItemCode.Enabled = False
        Me.TB_ItemCode.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_ItemCode.Location = New System.Drawing.Point(231, 66)
        Me.TB_ItemCode.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_ItemCode.Name = "TB_ItemCode"
        Me.TB_ItemCode.Size = New System.Drawing.Size(226, 26)
        Me.TB_ItemCode.TabIndex = 37
        '
        'TB_ModelCode
        '
        Me.TB_ModelCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ModelCode.Enabled = False
        Me.TB_ModelCode.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_ModelCode.Location = New System.Drawing.Point(126, 66)
        Me.TB_ModelCode.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_ModelCode.Name = "TB_ModelCode"
        Me.TB_ModelCode.Size = New System.Drawing.Size(105, 26)
        Me.TB_ModelCode.TabIndex = 36
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(9, 66)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 53)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "모델"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_CustomerName
        '
        Me.TB_CustomerName.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerName.Enabled = False
        Me.TB_CustomerName.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_CustomerName.Location = New System.Drawing.Point(231, 38)
        Me.TB_CustomerName.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerName.Name = "TB_CustomerName"
        Me.TB_CustomerName.Size = New System.Drawing.Size(226, 26)
        Me.TB_CustomerName.TabIndex = 32
        '
        'TB_CustomerCode
        '
        Me.TB_CustomerCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerCode.Enabled = False
        Me.TB_CustomerCode.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_CustomerCode.Location = New System.Drawing.Point(126, 38)
        Me.TB_CustomerCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerCode.Name = "TB_CustomerCode"
        Me.TB_CustomerCode.Size = New System.Drawing.Size(105, 26)
        Me.TB_CustomerCode.TabIndex = 31
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(9, 38)
        Me.Label17.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(117, 26)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "고객사"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Grid_SMD_Bottom
        '
        Me.Grid_SMD_Bottom.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_SMD_Bottom.Location = New System.Drawing.Point(9, 362)
        Me.Grid_SMD_Bottom.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_SMD_Bottom.Name = "Grid_SMD_Bottom"
        Me.Grid_SMD_Bottom.Rows.Count = 2
        Me.Grid_SMD_Bottom.Rows.DefaultSize = 20
        Me.Grid_SMD_Bottom.Size = New System.Drawing.Size(350, 342)
        Me.Grid_SMD_Bottom.StyleInfo = resources.GetString("Grid_SMD_Bottom.StyleInfo")
        Me.Grid_SMD_Bottom.TabIndex = 49
        Me.Grid_SMD_Bottom.UseCompatibleTextRendering = True
        '
        'CB_SMD_Bottom
        '
        Me.CB_SMD_Bottom.AutoSize = True
        Me.CB_SMD_Bottom.Location = New System.Drawing.Point(12, 343)
        Me.CB_SMD_Bottom.Name = "CB_SMD_Bottom"
        Me.CB_SMD_Bottom.Size = New System.Drawing.Size(118, 16)
        Me.CB_SMD_Bottom.TabIndex = 50
        Me.CB_SMD_Bottom.Text = "SMD Bottom List"
        Me.CB_SMD_Bottom.UseVisualStyleBackColor = True
        '
        'CB_SMD_Top
        '
        Me.CB_SMD_Top.AutoSize = True
        Me.CB_SMD_Top.Location = New System.Drawing.Point(362, 343)
        Me.CB_SMD_Top.Name = "CB_SMD_Top"
        Me.CB_SMD_Top.Size = New System.Drawing.Size(101, 16)
        Me.CB_SMD_Top.TabIndex = 52
        Me.CB_SMD_Top.Text = "SMD Top List"
        Me.CB_SMD_Top.UseVisualStyleBackColor = True
        '
        'Grid_SMD_Top
        '
        Me.Grid_SMD_Top.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_SMD_Top.Location = New System.Drawing.Point(359, 362)
        Me.Grid_SMD_Top.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_SMD_Top.Name = "Grid_SMD_Top"
        Me.Grid_SMD_Top.Rows.Count = 2
        Me.Grid_SMD_Top.Rows.DefaultSize = 20
        Me.Grid_SMD_Top.Size = New System.Drawing.Size(350, 342)
        Me.Grid_SMD_Top.StyleInfo = resources.GetString("Grid_SMD_Top.StyleInfo")
        Me.Grid_SMD_Top.TabIndex = 51
        Me.Grid_SMD_Top.UseCompatibleTextRendering = True
        '
        'CB_Dip
        '
        Me.CB_Dip.AutoSize = True
        Me.CB_Dip.Location = New System.Drawing.Point(712, 343)
        Me.CB_Dip.Name = "CB_Dip"
        Me.CB_Dip.Size = New System.Drawing.Size(66, 16)
        Me.CB_Dip.TabIndex = 54
        Me.CB_Dip.Text = "Dip List"
        Me.CB_Dip.UseVisualStyleBackColor = True
        '
        'Grid_Dip
        '
        Me.Grid_Dip.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_Dip.Location = New System.Drawing.Point(709, 362)
        Me.Grid_Dip.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_Dip.Name = "Grid_Dip"
        Me.Grid_Dip.Rows.Count = 2
        Me.Grid_Dip.Rows.DefaultSize = 20
        Me.Grid_Dip.Size = New System.Drawing.Size(350, 342)
        Me.Grid_Dip.StyleInfo = resources.GetString("Grid_Dip.StyleInfo")
        Me.Grid_Dip.TabIndex = 53
        Me.Grid_Dip.UseCompatibleTextRendering = True
        '
        'BTN_Confirm
        '
        Me.BTN_Confirm.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.BTN_Confirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_Confirm.Location = New System.Drawing.Point(744, 248)
        Me.BTN_Confirm.Name = "BTN_Confirm"
        Me.BTN_Confirm.Size = New System.Drawing.Size(110, 56)
        Me.BTN_Confirm.TabIndex = 55
        Me.BTN_Confirm.Text = "폐기 승인"
        Me.BTN_Confirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_Confirm.UseVisualStyleBackColor = True
        '
        'Grid_Etc
        '
        Me.Grid_Etc.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_Etc.Location = New System.Drawing.Point(1059, 362)
        Me.Grid_Etc.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_Etc.Name = "Grid_Etc"
        Me.Grid_Etc.Rows.Count = 2
        Me.Grid_Etc.Rows.DefaultSize = 20
        Me.Grid_Etc.Size = New System.Drawing.Size(350, 342)
        Me.Grid_Etc.StyleInfo = resources.GetString("Grid_Etc.StyleInfo")
        Me.Grid_Etc.TabIndex = 57
        Me.Grid_Etc.UseCompatibleTextRendering = True
        '
        'BTN_Cancel
        '
        Me.BTN_Cancel.Image = Global.YJ_MMS.My.Resources.Resources._Stop
        Me.BTN_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_Cancel.Location = New System.Drawing.Point(860, 249)
        Me.BTN_Cancel.Name = "BTN_Cancel"
        Me.BTN_Cancel.Size = New System.Drawing.Size(110, 56)
        Me.BTN_Cancel.TabIndex = 58
        Me.BTN_Cancel.Text = "폐기 거절"
        Me.BTN_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_Cancel.UseVisualStyleBackColor = True
        '
        'Grid_Menu
        '
        Me.Grid_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Move_SMD_Bottom, Me.BTN_Move_SMD_Top, Me.BTN_Move_Dip, Me.BTN_Move_ETC})
        Me.Grid_Menu.Name = "Grid_Menu"
        Me.Grid_Menu.Size = New System.Drawing.Size(174, 92)
        '
        'BTN_Move_SMD_Bottom
        '
        Me.BTN_Move_SMD_Bottom.Name = "BTN_Move_SMD_Bottom"
        Me.BTN_Move_SMD_Bottom.Size = New System.Drawing.Size(173, 22)
        Me.BTN_Move_SMD_Bottom.Text = "SMD Bottom 이동"
        '
        'BTN_Move_SMD_Top
        '
        Me.BTN_Move_SMD_Top.Name = "BTN_Move_SMD_Top"
        Me.BTN_Move_SMD_Top.Size = New System.Drawing.Size(173, 22)
        Me.BTN_Move_SMD_Top.Text = "SMD Top 이동"
        '
        'BTN_Move_Dip
        '
        Me.BTN_Move_Dip.Name = "BTN_Move_Dip"
        Me.BTN_Move_Dip.Size = New System.Drawing.Size(173, 22)
        Me.BTN_Move_Dip.Text = "Dip 이동"
        '
        'BTN_Move_ETC
        '
        Me.BTN_Move_ETC.Name = "BTN_Move_ETC"
        Me.BTN_Move_ETC.Size = New System.Drawing.Size(173, 22)
        Me.BTN_Move_ETC.Text = "기타 이동"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1068, 343)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(217, 12)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "자동으로 찾지 못한 항목을 옮기십시오."
        '
        'frm_Production_Discard_Information
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1420, 709)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.BTN_Cancel)
        Me.Controls.Add(Me.Grid_Etc)
        Me.Controls.Add(Me.BTN_Confirm)
        Me.Controls.Add(Me.CB_Dip)
        Me.Controls.Add(Me.Grid_Dip)
        Me.Controls.Add(Me.CB_SMD_Top)
        Me.Controls.Add(Me.Grid_SMD_Top)
        Me.Controls.Add(Me.CB_SMD_Bottom)
        Me.Controls.Add(Me.Grid_SMD_Bottom)
        Me.Controls.Add(Me.TB_ManagementNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TB_BoardNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TB_Discard_Resone)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TB_Process)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TB_OrderQty)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TB_Workside)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TB_Inspector)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TB_OrderIndex)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TB_ItemName)
        Me.Controls.Add(Me.TB_ItemCode)
        Me.Controls.Add(Me.TB_ModelCode)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TB_CustomerName)
        Me.Controls.Add(Me.TB_CustomerCode)
        Me.Controls.Add(Me.Label17)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Production_Discard_Information"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "폐기항목 정보"
        CType(Me.Grid_SMD_Bottom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid_SMD_Top, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid_Dip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid_Etc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grid_Menu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TB_ManagementNo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TB_BoardNo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TB_Discard_Resone As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TB_Process As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_OrderQty As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TB_Workside As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TB_Inspector As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TB_OrderIndex As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TB_ItemName As TextBox
    Friend WithEvents TB_ItemCode As TextBox
    Friend WithEvents TB_ModelCode As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TB_CustomerName As TextBox
    Friend WithEvents TB_CustomerCode As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Grid_SMD_Bottom As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents CB_SMD_Bottom As CheckBox
    Friend WithEvents CB_SMD_Top As CheckBox
    Friend WithEvents Grid_SMD_Top As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents CB_Dip As CheckBox
    Friend WithEvents Grid_Dip As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BTN_Confirm As Button
    Friend WithEvents Grid_Etc As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BTN_Cancel As Button
    Friend WithEvents Grid_Menu As ContextMenuStrip
    Friend WithEvents BTN_Move_SMD_Bottom As ToolStripMenuItem
    Friend WithEvents BTN_Move_SMD_Top As ToolStripMenuItem
    Friend WithEvents BTN_Move_Dip As ToolStripMenuItem
    Friend WithEvents BTN_Move_ETC As ToolStripMenuItem
    Friend WithEvents Label7 As Label
End Class
