<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Production_plan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Production_plan))
        Me.TS_MainBar = New System.Windows.Forms.ToolStrip()
        Me.BTN_Search = New System.Windows.Forms.ToolStripButton()
        Me.Form_CLose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_Save = New System.Windows.Forms.ToolStripButton()
        Me.Grid_OrderList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.CB_CustomerName = New System.Windows.Forms.ComboBox()
        Me.TB_CustomerCode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TB_Search = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CMS_GridMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_CellCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_CellPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_Save2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_POCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.TS_MainBar.SuspendLayout()
        CType(Me.Grid_OrderList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.CMS_GridMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TS_MainBar
        '
        Me.TS_MainBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Search, Me.Form_CLose, Me.ToolStripSeparator1, Me.BTN_Save})
        Me.TS_MainBar.Location = New System.Drawing.Point(0, 0)
        Me.TS_MainBar.Name = "TS_MainBar"
        Me.TS_MainBar.Size = New System.Drawing.Size(1264, 25)
        Me.TS_MainBar.TabIndex = 1
        Me.TS_MainBar.Text = "ToolStrip1"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BTN_Save
        '
        Me.BTN_Save.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.BTN_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(51, 22)
        Me.BTN_Save.Text = "저장"
        '
        'Grid_OrderList
        '
        Me.Grid_OrderList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_OrderList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_OrderList.Location = New System.Drawing.Point(0, 84)
        Me.Grid_OrderList.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_OrderList.Name = "Grid_OrderList"
        Me.Grid_OrderList.Rows.Count = 2
        Me.Grid_OrderList.Rows.DefaultSize = 20
        Me.Grid_OrderList.Size = New System.Drawing.Size(1264, 689)
        Me.Grid_OrderList.StyleInfo = resources.GetString("Grid_OrderList.StyleInfo")
        Me.Grid_OrderList.TabIndex = 2
        Me.Grid_OrderList.UseCompatibleTextRendering = True
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel5.Controls.Add(Me.GroupBox1)
        Me.Panel5.Controls.Add(Me.CB_CustomerName)
        Me.Panel5.Controls.Add(Me.TB_CustomerCode)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.TB_Search)
        Me.Panel5.Controls.Add(Me.Label17)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 25)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1264, 59)
        Me.Panel5.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(530, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(278, 44)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "검색구분"
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Location = New System.Drawing.Point(112, 20)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(59, 16)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "미완료"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(59, 20)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "완료"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(6, 20)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(47, 16)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.Text = "전체"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'CB_CustomerName
        '
        Me.CB_CustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_CustomerName.FormattingEnabled = True
        Me.CB_CustomerName.Location = New System.Drawing.Point(85, 7)
        Me.CB_CustomerName.Margin = New System.Windows.Forms.Padding(0)
        Me.CB_CustomerName.Name = "CB_CustomerName"
        Me.CB_CustomerName.Size = New System.Drawing.Size(266, 20)
        Me.CB_CustomerName.TabIndex = 3
        '
        'TB_CustomerCode
        '
        Me.TB_CustomerCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerCode.Enabled = False
        Me.TB_CustomerCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_CustomerCode.Location = New System.Drawing.Point(351, 7)
        Me.TB_CustomerCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerCode.Name = "TB_CustomerCode"
        Me.TB_CustomerCode.Size = New System.Drawing.Size(176, 21)
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
        'TB_Search
        '
        Me.TB_Search.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Search.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_Search.Location = New System.Drawing.Point(85, 30)
        Me.TB_Search.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Search.Name = "TB_Search"
        Me.TB_Search.Size = New System.Drawing.Size(442, 21)
        Me.TB_Search.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(9, 30)
        Me.Label17.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(76, 21)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "검색"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CMS_GridMenu
        '
        Me.CMS_GridMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_CellCopy, Me.ToolStripSeparator2, Me.BTN_CellPaste, Me.ToolStripSeparator3, Me.BTN_Save2, Me.ToolStripSeparator4, Me.BTN_POCancel})
        Me.CMS_GridMenu.Name = "CMS_GridMenu"
        Me.CMS_GridMenu.Size = New System.Drawing.Size(249, 132)
        '
        'BTN_CellCopy
        '
        Me.BTN_CellCopy.Name = "BTN_CellCopy"
        Me.BTN_CellCopy.Size = New System.Drawing.Size(248, 22)
        Me.BTN_CellCopy.Text = "선택 내용 복사(일자, 동, 라인)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(245, 6)
        '
        'BTN_CellPaste
        '
        Me.BTN_CellPaste.Name = "BTN_CellPaste"
        Me.BTN_CellPaste.Size = New System.Drawing.Size(248, 22)
        Me.BTN_CellPaste.Text = "선택 행 붙혀넣기(일자, 동, 라인)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(245, 6)
        '
        'BTN_Save2
        '
        Me.BTN_Save2.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.BTN_Save2.Name = "BTN_Save2"
        Me.BTN_Save2.Size = New System.Drawing.Size(248, 22)
        Me.BTN_Save2.Text = "저장"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(245, 6)
        '
        'BTN_POCancel
        '
        Me.BTN_POCancel.Name = "BTN_POCancel"
        Me.BTN_POCancel.Size = New System.Drawing.Size(248, 22)
        Me.BTN_POCancel.Text = "취소(소요량 산출로 되돌리기)"
        '
        'frm_Production_plan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 773)
        Me.Controls.Add(Me.Grid_OrderList)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.TS_MainBar)
        Me.KeyPreview = True
        Me.Name = "frm_Production_plan"
        Me.Text = "생산계획 수립"
        Me.TS_MainBar.ResumeLayout(False)
        Me.TS_MainBar.PerformLayout()
        CType(Me.Grid_OrderList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.CMS_GridMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TS_MainBar As ToolStrip
    Friend WithEvents BTN_Search As ToolStripButton
    Friend WithEvents Form_CLose As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Panel5 As Panel
    Friend WithEvents CB_CustomerName As ComboBox
    Friend WithEvents TB_CustomerCode As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TB_Search As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Grid_OrderList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BTN_Save As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents CMS_GridMenu As ContextMenuStrip
    Friend WithEvents BTN_CellCopy As ToolStripMenuItem
    Friend WithEvents BTN_CellPaste As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents BTN_Save2 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents BTN_POCancel As ToolStripMenuItem
End Class
