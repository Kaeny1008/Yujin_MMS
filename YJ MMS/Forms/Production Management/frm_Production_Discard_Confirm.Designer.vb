<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Production_Discard_Confirm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Production_Discard_Confirm))
        Me.TS_MainBar = New System.Windows.Forms.ToolStrip()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.CB_ConfirmStatus = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TB_ItemCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CB_CustomerName = New System.Windows.Forms.ComboBox()
        Me.TB_CustomerCode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Grid_ConfirmList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Grid_Menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_Confirm = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Search = New System.Windows.Forms.ToolStripButton()
        Me.Form_CLose = New System.Windows.Forms.ToolStripButton()
        Me.TS_MainBar.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.Grid_ConfirmList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grid_Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TS_MainBar
        '
        Me.TS_MainBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Search, Me.Form_CLose})
        Me.TS_MainBar.Location = New System.Drawing.Point(0, 0)
        Me.TS_MainBar.Name = "TS_MainBar"
        Me.TS_MainBar.Size = New System.Drawing.Size(1264, 25)
        Me.TS_MainBar.TabIndex = 3
        Me.TS_MainBar.Text = "ToolStrip1"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel5.Controls.Add(Me.CB_ConfirmStatus)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.TB_ItemCode)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.DateTimePicker2)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.DateTimePicker1)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.CB_CustomerName)
        Me.Panel5.Controls.Add(Me.TB_CustomerCode)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 25)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1264, 59)
        Me.Panel5.TabIndex = 4
        '
        'CB_ConfirmStatus
        '
        Me.CB_ConfirmStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_ConfirmStatus.FormattingEnabled = True
        Me.CB_ConfirmStatus.Items.AddRange(New Object() {"모두", "확정", "미확정"})
        Me.CB_ConfirmStatus.Location = New System.Drawing.Point(85, 30)
        Me.CB_ConfirmStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.CB_ConfirmStatus.Name = "CB_ConfirmStatus"
        Me.CB_ConfirmStatus.Size = New System.Drawing.Size(329, 20)
        Me.CB_ConfirmStatus.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(9, 30)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 21)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "상태"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_ItemCode
        '
        Me.TB_ItemCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ItemCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_ItemCode.Location = New System.Drawing.Point(490, 30)
        Me.TB_ItemCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_ItemCode.Name = "TB_ItemCode"
        Me.TB_ItemCode.Size = New System.Drawing.Size(260, 21)
        Me.TB_ItemCode.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(414, 30)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 21)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "품번"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(627, 9)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(123, 21)
        Me.DateTimePicker2.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(613, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 12)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "~"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(490, 8)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(123, 21)
        Me.DateTimePicker1.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(414, 7)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 21)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "일자"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CB_CustomerName
        '
        Me.CB_CustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_CustomerName.FormattingEnabled = True
        Me.CB_CustomerName.Location = New System.Drawing.Point(85, 7)
        Me.CB_CustomerName.Margin = New System.Windows.Forms.Padding(0)
        Me.CB_CustomerName.Name = "CB_CustomerName"
        Me.CB_CustomerName.Size = New System.Drawing.Size(213, 20)
        Me.CB_CustomerName.TabIndex = 3
        '
        'TB_CustomerCode
        '
        Me.TB_CustomerCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerCode.Enabled = False
        Me.TB_CustomerCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_CustomerCode.Location = New System.Drawing.Point(298, 7)
        Me.TB_CustomerCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerCode.Name = "TB_CustomerCode"
        Me.TB_CustomerCode.Size = New System.Drawing.Size(116, 21)
        Me.TB_CustomerCode.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 7)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 21)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "고객사"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Grid_ConfirmList
        '
        Me.Grid_ConfirmList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_ConfirmList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_ConfirmList.Location = New System.Drawing.Point(0, 84)
        Me.Grid_ConfirmList.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_ConfirmList.Name = "Grid_ConfirmList"
        Me.Grid_ConfirmList.Rows.Count = 2
        Me.Grid_ConfirmList.Rows.DefaultSize = 20
        Me.Grid_ConfirmList.Size = New System.Drawing.Size(1264, 689)
        Me.Grid_ConfirmList.StyleInfo = resources.GetString("Grid_ConfirmList.StyleInfo")
        Me.Grid_ConfirmList.TabIndex = 6
        Me.Grid_ConfirmList.UseCompatibleTextRendering = True
        '
        'Grid_Menu
        '
        Me.Grid_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Confirm})
        Me.Grid_Menu.Name = "Grid_Menu"
        Me.Grid_Menu.Size = New System.Drawing.Size(181, 48)
        '
        'BTN_Confirm
        '
        Me.BTN_Confirm.Name = "BTN_Confirm"
        Me.BTN_Confirm.Size = New System.Drawing.Size(180, 22)
        Me.BTN_Confirm.Text = "승인 / 거절"
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
        'frm_Production_Discard_Confirm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 773)
        Me.Controls.Add(Me.Grid_ConfirmList)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.TS_MainBar)
        Me.Name = "frm_Production_Discard_Confirm"
        Me.Text = "폐기등록 승인"
        Me.TS_MainBar.ResumeLayout(False)
        Me.TS_MainBar.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.Grid_ConfirmList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grid_Menu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TS_MainBar As ToolStrip
    Friend WithEvents BTN_Search As ToolStripButton
    Friend WithEvents Form_CLose As ToolStripButton
    Friend WithEvents Panel5 As Panel
    Friend WithEvents TB_ItemCode As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents CB_CustomerName As ComboBox
    Friend WithEvents TB_CustomerCode As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CB_ConfirmStatus As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Grid_ConfirmList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Grid_Menu As ContextMenuStrip
    Friend WithEvents BTN_Confirm As ToolStripMenuItem
End Class
