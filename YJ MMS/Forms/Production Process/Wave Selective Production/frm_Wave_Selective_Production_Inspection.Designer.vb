<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Wave_Selective_Production_Inspection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Wave_Selective_Production_Inspection))
        Me.TS_MainBar = New System.Windows.Forms.ToolStrip()
        Me.Form_CLose = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BTN_RepairCheck = New System.Windows.Forms.Button()
        Me.BTN_PauseRegister = New System.Windows.Forms.Button()
        Me.BTN_FaultRegister = New System.Windows.Forms.Button()
        Me.TB_Inspector = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TB_SMD_HistoryNo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TB_TotalQty = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TB_OrderIndex = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TB_ItemName = New System.Windows.Forms.TextBox()
        Me.TB_ItemCode = New System.Windows.Forms.TextBox()
        Me.TB_ModelCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TB_CustomerName = New System.Windows.Forms.TextBox()
        Me.TB_CustomerCode = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TB_Barcode = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CB_Line = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CB_Department = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CB_Process = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Grid_History = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TS_MainBar.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Grid_History, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TS_MainBar
        '
        Me.TS_MainBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Form_CLose})
        Me.TS_MainBar.Location = New System.Drawing.Point(0, 0)
        Me.TS_MainBar.Name = "TS_MainBar"
        Me.TS_MainBar.Size = New System.Drawing.Size(1264, 25)
        Me.TS_MainBar.TabIndex = 0
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label13)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label12)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label14)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BTN_RepairCheck)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BTN_PauseRegister)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BTN_FaultRegister)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_Inspector)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_SMD_HistoryNo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_TotalQty)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_OrderIndex)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_ItemName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_ItemCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_ModelCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_CustomerName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_CustomerCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label17)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_Barcode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CB_Line)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CB_Department)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CB_Process)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Grid_History)
        Me.SplitContainer1.Size = New System.Drawing.Size(1264, 748)
        Me.SplitContainer1.SplitterDistance = 241
        Me.SplitContainer1.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(250, 169)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(103, 12)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "(불량이 있을경우)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(144, 169)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 12)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "(메거진 단위)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(34, 169)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 12)
        Me.Label14.TabIndex = 11
        Me.Label14.Text = "(불량기록)"
        '
        'BTN_RepairCheck
        '
        Me.BTN_RepairCheck.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_RepairCheck.Image = Global.YJ_MMS.My.Resources.Resources._Stop
        Me.BTN_RepairCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_RepairCheck.Location = New System.Drawing.Point(245, 183)
        Me.BTN_RepairCheck.Name = "BTN_RepairCheck"
        Me.BTN_RepairCheck.Size = New System.Drawing.Size(112, 53)
        Me.BTN_RepairCheck.TabIndex = 16
        Me.BTN_RepairCheck.Text = "수리결과" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "확인"
        Me.BTN_RepairCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_RepairCheck.UseVisualStyleBackColor = True
        '
        'BTN_PauseRegister
        '
        Me.BTN_PauseRegister.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_PauseRegister.Image = Global.YJ_MMS.My.Resources.Resources.order_history_32
        Me.BTN_PauseRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_PauseRegister.Location = New System.Drawing.Point(127, 183)
        Me.BTN_PauseRegister.Name = "BTN_PauseRegister"
        Me.BTN_PauseRegister.Size = New System.Drawing.Size(112, 53)
        Me.BTN_PauseRegister.TabIndex = 14
        Me.BTN_PauseRegister.Text = "생산내역" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "등록"
        Me.BTN_PauseRegister.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_PauseRegister.UseVisualStyleBackColor = True
        '
        'BTN_FaultRegister
        '
        Me.BTN_FaultRegister.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_FaultRegister.Image = Global.YJ_MMS.My.Resources.Resources.ordering_32
        Me.BTN_FaultRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_FaultRegister.Location = New System.Drawing.Point(9, 183)
        Me.BTN_FaultRegister.Name = "BTN_FaultRegister"
        Me.BTN_FaultRegister.Size = New System.Drawing.Size(112, 53)
        Me.BTN_FaultRegister.TabIndex = 12
        Me.BTN_FaultRegister.Text = "불량내역" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "등록"
        Me.BTN_FaultRegister.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_FaultRegister.UseVisualStyleBackColor = True
        '
        'TB_Inspector
        '
        Me.TB_Inspector.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Inspector.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TB_Inspector.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_Inspector.Location = New System.Drawing.Point(138, 97)
        Me.TB_Inspector.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_Inspector.Name = "TB_Inspector"
        Me.TB_Inspector.Size = New System.Drawing.Size(545, 26)
        Me.TB_Inspector.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.SteelBlue
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(9, 97)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(129, 26)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "검사자"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_SMD_HistoryNo
        '
        Me.TB_SMD_HistoryNo.BackColor = System.Drawing.SystemColors.Window
        Me.TB_SMD_HistoryNo.Enabled = False
        Me.TB_SMD_HistoryNo.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_SMD_HistoryNo.Location = New System.Drawing.Point(1099, 45)
        Me.TB_SMD_HistoryNo.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_SMD_HistoryNo.Name = "TB_SMD_HistoryNo"
        Me.TB_SMD_HistoryNo.Size = New System.Drawing.Size(58, 26)
        Me.TB_SMD_HistoryNo.TabIndex = 20
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("굴림", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 21)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "[공정정보]"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("굴림", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.Location = New System.Drawing.Point(693, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 21)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "[생산정보]"
        '
        'TB_TotalQty
        '
        Me.TB_TotalQty.BackColor = System.Drawing.SystemColors.Window
        Me.TB_TotalQty.Enabled = False
        Me.TB_TotalQty.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_TotalQty.Location = New System.Drawing.Point(826, 156)
        Me.TB_TotalQty.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_TotalQty.Name = "TB_TotalQty"
        Me.TB_TotalQty.Size = New System.Drawing.Size(331, 26)
        Me.TB_TotalQty.TabIndex = 29
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(697, 156)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(129, 26)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "작업수량"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_OrderIndex
        '
        Me.TB_OrderIndex.BackColor = System.Drawing.SystemColors.Window
        Me.TB_OrderIndex.Enabled = False
        Me.TB_OrderIndex.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_OrderIndex.Location = New System.Drawing.Point(826, 45)
        Me.TB_OrderIndex.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_OrderIndex.Name = "TB_OrderIndex"
        Me.TB_OrderIndex.Size = New System.Drawing.Size(273, 26)
        Me.TB_OrderIndex.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(697, 45)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 26)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "주문번호"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_ItemName
        '
        Me.TB_ItemName.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ItemName.Enabled = False
        Me.TB_ItemName.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_ItemName.Location = New System.Drawing.Point(826, 128)
        Me.TB_ItemName.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_ItemName.Name = "TB_ItemName"
        Me.TB_ItemName.Size = New System.Drawing.Size(331, 26)
        Me.TB_ItemName.TabIndex = 27
        '
        'TB_ItemCode
        '
        Me.TB_ItemCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ItemCode.Enabled = False
        Me.TB_ItemCode.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_ItemCode.Location = New System.Drawing.Point(931, 101)
        Me.TB_ItemCode.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_ItemCode.Name = "TB_ItemCode"
        Me.TB_ItemCode.Size = New System.Drawing.Size(226, 26)
        Me.TB_ItemCode.TabIndex = 26
        '
        'TB_ModelCode
        '
        Me.TB_ModelCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ModelCode.Enabled = False
        Me.TB_ModelCode.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_ModelCode.Location = New System.Drawing.Point(826, 101)
        Me.TB_ModelCode.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_ModelCode.Name = "TB_ModelCode"
        Me.TB_ModelCode.Size = New System.Drawing.Size(105, 26)
        Me.TB_ModelCode.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(697, 101)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 53)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "모델"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_CustomerName
        '
        Me.TB_CustomerName.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerName.Enabled = False
        Me.TB_CustomerName.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_CustomerName.Location = New System.Drawing.Point(931, 73)
        Me.TB_CustomerName.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerName.Name = "TB_CustomerName"
        Me.TB_CustomerName.Size = New System.Drawing.Size(226, 26)
        Me.TB_CustomerName.TabIndex = 23
        '
        'TB_CustomerCode
        '
        Me.TB_CustomerCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerCode.Enabled = False
        Me.TB_CustomerCode.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_CustomerCode.Location = New System.Drawing.Point(826, 73)
        Me.TB_CustomerCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerCode.Name = "TB_CustomerCode"
        Me.TB_CustomerCode.Size = New System.Drawing.Size(105, 26)
        Me.TB_CustomerCode.TabIndex = 22
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(697, 73)
        Me.Label17.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(129, 26)
        Me.Label17.TabIndex = 21
        Me.Label17.Text = "고객사"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Barcode
        '
        Me.TB_Barcode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Barcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TB_Barcode.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_Barcode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_Barcode.Location = New System.Drawing.Point(138, 125)
        Me.TB_Barcode.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_Barcode.Name = "TB_Barcode"
        Me.TB_Barcode.Size = New System.Drawing.Size(545, 26)
        Me.TB_Barcode.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(9, 125)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 26)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Barcode Scan"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CB_Line
        '
        Me.CB_Line.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Line.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CB_Line.FormattingEnabled = True
        Me.CB_Line.Items.AddRange(New Object() {"Wave Soldering", "Selective Soldering"})
        Me.CB_Line.Location = New System.Drawing.Point(428, 71)
        Me.CB_Line.Margin = New System.Windows.Forms.Padding(0)
        Me.CB_Line.Name = "CB_Line"
        Me.CB_Line.Size = New System.Drawing.Size(255, 24)
        Me.CB_Line.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(352, 71)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 24)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Line"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CB_Department
        '
        Me.CB_Department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Department.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CB_Department.FormattingEnabled = True
        Me.CB_Department.Items.AddRange(New Object() {"D동"})
        Me.CB_Department.Location = New System.Drawing.Point(138, 71)
        Me.CB_Department.Margin = New System.Windows.Forms.Padding(0)
        Me.CB_Department.Name = "CB_Department"
        Me.CB_Department.Size = New System.Drawing.Size(214, 24)
        Me.CB_Department.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 71)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "동"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CB_Process
        '
        Me.CB_Process.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Process.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CB_Process.FormattingEnabled = True
        Me.CB_Process.Items.AddRange(New Object() {"Wave", "Selective"})
        Me.CB_Process.Location = New System.Drawing.Point(138, 45)
        Me.CB_Process.Margin = New System.Windows.Forms.Padding(0)
        Me.CB_Process.Name = "CB_Process"
        Me.CB_Process.Size = New System.Drawing.Size(214, 24)
        Me.CB_Process.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 45)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 24)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "공정선택"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.Grid_History.Size = New System.Drawing.Size(1264, 503)
        Me.Grid_History.StyleInfo = resources.GetString("Grid_History.StyleInfo")
        Me.Grid_History.TabIndex = 1
        Me.Grid_History.UseCompatibleTextRendering = True
        '
        'frm_Wave_Selective_Production_Inspection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 773)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TS_MainBar)
        Me.Name = "frm_Wave_Selective_Production_Inspection"
        Me.Text = "Wave / Selective Soldering 공정 검사내역 등록"
        Me.TS_MainBar.ResumeLayout(False)
        Me.TS_MainBar.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Grid_History, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TS_MainBar As ToolStrip
    Friend WithEvents Form_CLose As ToolStripButton
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TB_SMD_HistoryNo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TB_TotalQty As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TB_OrderIndex As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TB_ItemName As TextBox
    Friend WithEvents TB_ItemCode As TextBox
    Friend WithEvents TB_ModelCode As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TB_CustomerName As TextBox
    Friend WithEvents TB_CustomerCode As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents TB_Barcode As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents CB_Line As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CB_Department As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CB_Process As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Grid_History As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TB_Inspector As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents BTN_RepairCheck As Button
    Friend WithEvents BTN_PauseRegister As Button
    Friend WithEvents BTN_FaultRegister As Button
End Class
