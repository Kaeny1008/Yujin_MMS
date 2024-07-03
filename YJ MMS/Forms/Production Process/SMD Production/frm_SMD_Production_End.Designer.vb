<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SMD_Production_End
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_SMD_Production_End))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.BTN_Reload = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Grid_OrderList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TB_OrderQty = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BTN_RepairCheck = New System.Windows.Forms.Button()
        Me.BTN_PauseRegister = New System.Windows.Forms.Button()
        Me.BTN_FaultRegister = New System.Windows.Forms.Button()
        Me.TB_Workside = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TB_Inspector = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TB_Operator = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TB_OrderIndex = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TB_ItemName = New System.Windows.Forms.TextBox()
        Me.TB_ItemCode = New System.Windows.Forms.TextBox()
        Me.TB_ModelCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TB_CustomerName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TB_CustomerCode = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CB_Line = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CB_Department = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Grid_History = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TS_MainBar = New System.Windows.Forms.ToolStrip()
        Me.Form_CLose = New System.Windows.Forms.ToolStripButton()
        Me.Grid_Menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_Reprint = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.BTN_Discard_Register = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Grid_OrderList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid_History, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TS_MainBar.SuspendLayout()
        Me.Grid_Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label15)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BTN_Discard_Register)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BTN_Reload)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label14)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Grid_OrderList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label13)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label12)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_OrderQty)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BTN_RepairCheck)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BTN_PauseRegister)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BTN_FaultRegister)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_Workside)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_Inspector)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_Operator)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_OrderIndex)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_ItemName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_ItemCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_ModelCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_CustomerName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_CustomerCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label17)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CB_Line)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CB_Department)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel2.Controls.Add(Me.Grid_History)
        Me.SplitContainer1.Size = New System.Drawing.Size(1264, 750)
        Me.SplitContainer1.SplitterDistance = 229
        Me.SplitContainer1.TabIndex = 0
        '
        'BTN_Reload
        '
        Me.BTN_Reload.Location = New System.Drawing.Point(572, 43)
        Me.BTN_Reload.Name = "BTN_Reload"
        Me.BTN_Reload.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Reload.TabIndex = 39
        Me.BTN_Reload.Text = "재확인"
        Me.BTN_Reload.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 210)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(325, 12)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "여러개의 주문이 있을 경우 해당 주문을 더블클릭 하십시오."
        '
        'Grid_OrderList
        '
        Me.Grid_OrderList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid_OrderList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_OrderList.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Grid_OrderList.Location = New System.Drawing.Point(16, 74)
        Me.Grid_OrderList.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_OrderList.Name = "Grid_OrderList"
        Me.Grid_OrderList.Rows.Count = 2
        Me.Grid_OrderList.Rows.DefaultSize = 20
        Me.Grid_OrderList.Size = New System.Drawing.Size(553, 135)
        Me.Grid_OrderList.StyleInfo = resources.GetString("Grid_OrderList.StyleInfo")
        Me.Grid_OrderList.TabIndex = 37
        Me.Grid_OrderList.UseCompatibleTextRendering = True
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(842, 155)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(103, 12)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "(불량이 있을경우)"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(736, 155)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 12)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "(메거진 단위)"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(626, 155)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 12)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "(불량기록)"
        '
        'TB_OrderQty
        '
        Me.TB_OrderQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_OrderQty.BackColor = System.Drawing.SystemColors.Window
        Me.TB_OrderQty.Enabled = False
        Me.TB_OrderQty.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_OrderQty.Location = New System.Drawing.Point(1097, 70)
        Me.TB_OrderQty.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_OrderQty.Name = "TB_OrderQty"
        Me.TB_OrderQty.Size = New System.Drawing.Size(158, 26)
        Me.TB_OrderQty.TabIndex = 33
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(1008, 70)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 26)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "주문수량"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BTN_RepairCheck
        '
        Me.BTN_RepairCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_RepairCheck.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_RepairCheck.Image = Global.YJ_MMS.My.Resources.Resources._Stop
        Me.BTN_RepairCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_RepairCheck.Location = New System.Drawing.Point(837, 169)
        Me.BTN_RepairCheck.Name = "BTN_RepairCheck"
        Me.BTN_RepairCheck.Size = New System.Drawing.Size(112, 53)
        Me.BTN_RepairCheck.TabIndex = 31
        Me.BTN_RepairCheck.Text = "수리결과" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "확인"
        Me.BTN_RepairCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_RepairCheck.UseVisualStyleBackColor = True
        '
        'BTN_PauseRegister
        '
        Me.BTN_PauseRegister.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_PauseRegister.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_PauseRegister.Image = Global.YJ_MMS.My.Resources.Resources.order_history_32
        Me.BTN_PauseRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_PauseRegister.Location = New System.Drawing.Point(719, 169)
        Me.BTN_PauseRegister.Name = "BTN_PauseRegister"
        Me.BTN_PauseRegister.Size = New System.Drawing.Size(112, 53)
        Me.BTN_PauseRegister.TabIndex = 30
        Me.BTN_PauseRegister.Text = "생산내역" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "등록"
        Me.BTN_PauseRegister.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_PauseRegister.UseVisualStyleBackColor = True
        '
        'BTN_FaultRegister
        '
        Me.BTN_FaultRegister.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_FaultRegister.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_FaultRegister.Image = Global.YJ_MMS.My.Resources.Resources.ordering_32
        Me.BTN_FaultRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_FaultRegister.Location = New System.Drawing.Point(601, 169)
        Me.BTN_FaultRegister.Name = "BTN_FaultRegister"
        Me.BTN_FaultRegister.Size = New System.Drawing.Size(112, 53)
        Me.BTN_FaultRegister.TabIndex = 29
        Me.BTN_FaultRegister.Text = "불량내역" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "등록"
        Me.BTN_FaultRegister.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_FaultRegister.UseVisualStyleBackColor = True
        '
        'TB_Workside
        '
        Me.TB_Workside.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Workside.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Workside.Enabled = False
        Me.TB_Workside.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_Workside.Location = New System.Drawing.Point(1097, 42)
        Me.TB_Workside.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_Workside.Name = "TB_Workside"
        Me.TB_Workside.Size = New System.Drawing.Size(158, 26)
        Me.TB_Workside.TabIndex = 28
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(1008, 42)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 26)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "작업면"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Inspector
        '
        Me.TB_Inspector.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Inspector.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Inspector.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_Inspector.Location = New System.Drawing.Point(1097, 125)
        Me.TB_Inspector.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_Inspector.Name = "TB_Inspector"
        Me.TB_Inspector.Size = New System.Drawing.Size(158, 26)
        Me.TB_Inspector.TabIndex = 26
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(1008, 125)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 26)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Inspector"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Operator
        '
        Me.TB_Operator.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_Operator.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Operator.Enabled = False
        Me.TB_Operator.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_Operator.Location = New System.Drawing.Point(1097, 98)
        Me.TB_Operator.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_Operator.Name = "TB_Operator"
        Me.TB_Operator.Size = New System.Drawing.Size(158, 26)
        Me.TB_Operator.TabIndex = 24
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(1008, 98)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 26)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Operator"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_OrderIndex
        '
        Me.TB_OrderIndex.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_OrderIndex.BackColor = System.Drawing.SystemColors.Window
        Me.TB_OrderIndex.Enabled = False
        Me.TB_OrderIndex.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_OrderIndex.Location = New System.Drawing.Point(677, 42)
        Me.TB_OrderIndex.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_OrderIndex.Name = "TB_OrderIndex"
        Me.TB_OrderIndex.Size = New System.Drawing.Size(331, 26)
        Me.TB_OrderIndex.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(601, 42)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 26)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "주문번호"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_ItemName
        '
        Me.TB_ItemName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_ItemName.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ItemName.Enabled = False
        Me.TB_ItemName.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_ItemName.Location = New System.Drawing.Point(677, 125)
        Me.TB_ItemName.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_ItemName.Name = "TB_ItemName"
        Me.TB_ItemName.Size = New System.Drawing.Size(331, 26)
        Me.TB_ItemName.TabIndex = 19
        '
        'TB_ItemCode
        '
        Me.TB_ItemCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_ItemCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ItemCode.Enabled = False
        Me.TB_ItemCode.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_ItemCode.Location = New System.Drawing.Point(782, 98)
        Me.TB_ItemCode.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_ItemCode.Name = "TB_ItemCode"
        Me.TB_ItemCode.Size = New System.Drawing.Size(226, 26)
        Me.TB_ItemCode.TabIndex = 18
        '
        'TB_ModelCode
        '
        Me.TB_ModelCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_ModelCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ModelCode.Enabled = False
        Me.TB_ModelCode.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_ModelCode.Location = New System.Drawing.Point(677, 98)
        Me.TB_ModelCode.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_ModelCode.Name = "TB_ModelCode"
        Me.TB_ModelCode.Size = New System.Drawing.Size(105, 26)
        Me.TB_ModelCode.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(601, 98)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 53)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "모델"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_CustomerName
        '
        Me.TB_CustomerName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_CustomerName.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerName.Enabled = False
        Me.TB_CustomerName.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_CustomerName.Location = New System.Drawing.Point(782, 70)
        Me.TB_CustomerName.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerName.Name = "TB_CustomerName"
        Me.TB_CustomerName.Size = New System.Drawing.Size(226, 26)
        Me.TB_CustomerName.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("굴림", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.Location = New System.Drawing.Point(597, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 21)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "[생산정보]"
        '
        'TB_CustomerCode
        '
        Me.TB_CustomerCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB_CustomerCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerCode.Enabled = False
        Me.TB_CustomerCode.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_CustomerCode.Location = New System.Drawing.Point(677, 70)
        Me.TB_CustomerCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerCode.Name = "TB_CustomerCode"
        Me.TB_CustomerCode.Size = New System.Drawing.Size(105, 26)
        Me.TB_CustomerCode.TabIndex = 13
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(601, 70)
        Me.Label17.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(76, 26)
        Me.Label17.TabIndex = 12
        Me.Label17.Text = "고객사"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CB_Line
        '
        Me.CB_Line.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Line.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CB_Line.FormattingEnabled = True
        Me.CB_Line.Location = New System.Drawing.Point(314, 42)
        Me.CB_Line.Margin = New System.Windows.Forms.Padding(0)
        Me.CB_Line.Name = "CB_Line"
        Me.CB_Line.Size = New System.Drawing.Size(255, 24)
        Me.CB_Line.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(238, 42)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 24)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Line"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CB_Department
        '
        Me.CB_Department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Department.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CB_Department.FormattingEnabled = True
        Me.CB_Department.Location = New System.Drawing.Point(92, 42)
        Me.CB_Department.Margin = New System.Windows.Forms.Padding(0)
        Me.CB_Department.Name = "CB_Department"
        Me.CB_Department.Size = New System.Drawing.Size(146, 24)
        Me.CB_Department.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 42)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 24)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "동"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("굴림", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "[라인 선택]"
        '
        'Grid_History
        '
        Me.Grid_History.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_History.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_History.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Grid_History.Location = New System.Drawing.Point(0, 0)
        Me.Grid_History.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_History.Name = "Grid_History"
        Me.Grid_History.Rows.Count = 2
        Me.Grid_History.Rows.DefaultSize = 20
        Me.Grid_History.Size = New System.Drawing.Size(1264, 517)
        Me.Grid_History.StyleInfo = resources.GetString("Grid_History.StyleInfo")
        Me.Grid_History.TabIndex = 5
        Me.Grid_History.UseCompatibleTextRendering = True
        '
        'TS_MainBar
        '
        Me.TS_MainBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Form_CLose})
        Me.TS_MainBar.Location = New System.Drawing.Point(0, 0)
        Me.TS_MainBar.Name = "TS_MainBar"
        Me.TS_MainBar.Size = New System.Drawing.Size(1264, 25)
        Me.TS_MainBar.TabIndex = 2
        Me.TS_MainBar.Text = "ToolStrip1"
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
        'Grid_Menu
        '
        Me.Grid_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Reprint})
        Me.Grid_Menu.Name = "Grid_Menu"
        Me.Grid_Menu.Size = New System.Drawing.Size(151, 26)
        '
        'BTN_Reprint
        '
        Me.BTN_Reprint.Name = "BTN_Reprint"
        Me.BTN_Reprint.Size = New System.Drawing.Size(150, 22)
        Me.BTN_Reprint.Text = "현품표 재발행"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(960, 155)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(103, 12)
        Me.Label15.TabIndex = 41
        Me.Label15.Text = "(폐기가 있을경우)"
        '
        'BTN_Discard_Register
        '
        Me.BTN_Discard_Register.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_Discard_Register.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_Discard_Register.Image = Global.YJ_MMS.My.Resources.Resources.delete2
        Me.BTN_Discard_Register.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_Discard_Register.Location = New System.Drawing.Point(955, 169)
        Me.BTN_Discard_Register.Name = "BTN_Discard_Register"
        Me.BTN_Discard_Register.Size = New System.Drawing.Size(112, 53)
        Me.BTN_Discard_Register.TabIndex = 40
        Me.BTN_Discard_Register.Text = "폐기품" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "등록"
        Me.BTN_Discard_Register.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_Discard_Register.UseVisualStyleBackColor = True
        '
        'frm_SMD_Production_End
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 775)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TS_MainBar)
        Me.Name = "frm_SMD_Production_End"
        Me.Text = "SMD 검사내역 등록"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Grid_OrderList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid_History, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TS_MainBar.ResumeLayout(False)
        Me.TS_MainBar.PerformLayout()
        Me.Grid_Menu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Label1 As Label
    Friend WithEvents CB_Line As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CB_Department As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TS_MainBar As ToolStrip
    Friend WithEvents Form_CLose As ToolStripButton
    Friend WithEvents TB_OrderIndex As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TB_ItemName As TextBox
    Friend WithEvents TB_ItemCode As TextBox
    Friend WithEvents TB_ModelCode As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TB_CustomerName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TB_CustomerCode As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents TB_Inspector As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TB_Operator As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TB_Workside As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents BTN_FaultRegister As Button
    Friend WithEvents BTN_PauseRegister As Button
    Friend WithEvents BTN_RepairCheck As Button
    Friend WithEvents Grid_History As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TB_OrderQty As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Grid_OrderList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BTN_Reload As Button
    Friend WithEvents Grid_Menu As ContextMenuStrip
    Friend WithEvents BTN_Reprint As ToolStripMenuItem
    Friend WithEvents Label15 As Label
    Friend WithEvents BTN_Discard_Register As Button
End Class
