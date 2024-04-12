<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Wave_Selective_Production
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Wave_Selective_Production))
        Me.TS_MainBar = New System.Windows.Forms.ToolStrip()
        Me.Form_CLose = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Grid_History = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.CB_Process = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CB_Line = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CB_Department = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TB_Barcode = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TB_WorkingQty = New System.Windows.Forms.TextBox()
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
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
        Me.TS_MainBar.TabIndex = 3
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_WorkingQty)
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
        Me.SplitContainer1.SplitterDistance = 194
        Me.SplitContainer1.TabIndex = 4
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
        Me.Grid_History.Size = New System.Drawing.Size(1264, 550)
        Me.Grid_History.StyleInfo = resources.GetString("Grid_History.StyleInfo")
        Me.Grid_History.TabIndex = 6
        Me.Grid_History.UseCompatibleTextRendering = True
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
        Me.CB_Process.TabIndex = 11
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
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "공정선택"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.CB_Line.TabIndex = 15
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
        Me.Label2.TabIndex = 14
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
        Me.CB_Department.TabIndex = 13
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
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "동"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Barcode
        '
        Me.TB_Barcode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Barcode.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_Barcode.Location = New System.Drawing.Point(138, 97)
        Me.TB_Barcode.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_Barcode.Name = "TB_Barcode"
        Me.TB_Barcode.Size = New System.Drawing.Size(545, 26)
        Me.TB_Barcode.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(9, 97)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 26)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Barcode Scan"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_WorkingQty
        '
        Me.TB_WorkingQty.BackColor = System.Drawing.SystemColors.Window
        Me.TB_WorkingQty.Enabled = False
        Me.TB_WorkingQty.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_WorkingQty.Location = New System.Drawing.Point(826, 156)
        Me.TB_WorkingQty.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_WorkingQty.Name = "TB_WorkingQty"
        Me.TB_WorkingQty.Size = New System.Drawing.Size(331, 26)
        Me.TB_WorkingQty.TabIndex = 50
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
        Me.Label10.TabIndex = 49
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
        Me.TB_OrderIndex.Size = New System.Drawing.Size(331, 26)
        Me.TB_OrderIndex.TabIndex = 42
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
        Me.Label4.TabIndex = 41
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
        Me.TB_ItemName.TabIndex = 40
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
        Me.TB_ItemCode.TabIndex = 39
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
        Me.TB_ModelCode.TabIndex = 38
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
        Me.Label5.TabIndex = 37
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
        Me.TB_CustomerName.TabIndex = 36
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
        Me.TB_CustomerCode.TabIndex = 35
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
        Me.Label17.TabIndex = 34
        Me.Label17.Text = "고객사"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("굴림", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.Location = New System.Drawing.Point(693, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 21)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "[생산정보]"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("굴림", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 21)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "[공정정보]"
        '
        'frm_Wave_Selective_Production
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 773)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TS_MainBar)
        Me.Name = "frm_Wave_Selective_Production"
        Me.Text = "Wave / Selective Soldering 공정 생산등록"
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
    Friend WithEvents Grid_History As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents CB_Process As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CB_Line As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CB_Department As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_Barcode As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TB_WorkingQty As TextBox
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
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
End Class
