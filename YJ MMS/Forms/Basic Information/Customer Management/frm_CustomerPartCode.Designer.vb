<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_CustomerPartCode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_CustomerPartCode))
        Me.ts_MainBar = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TB_Specification = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TB_CustomerPartCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CB_CustomerName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TB_CustomerCode = New System.Windows.Forms.TextBox()
        Me.Grid_PartList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cms_Menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.COL_VIEW = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_CodeMapping = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Search = New System.Windows.Forms.ToolStripButton()
        Me.BTN_Part_Update = New System.Windows.Forms.ToolStripButton()
        Me.BTN_NewMultiPartsCode = New System.Windows.Forms.ToolStripButton()
        Me.BTN_Save = New System.Windows.Forms.ToolStripButton()
        Me.Form_CLose = New System.Windows.Forms.ToolStripButton()
        Me.BTN_NewPartsCode2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_RowDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_Save2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ts_MainBar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Grid_PartList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms_Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'ts_MainBar
        '
        Me.ts_MainBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ts_MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Search, Me.ToolStripSeparator1, Me.BTN_Part_Update, Me.BTN_NewMultiPartsCode, Me.ToolStripSeparator2, Me.BTN_Save, Me.Form_CLose})
        Me.ts_MainBar.Location = New System.Drawing.Point(0, 0)
        Me.ts_MainBar.Name = "ts_MainBar"
        Me.ts_MainBar.Size = New System.Drawing.Size(1264, 25)
        Me.ts_MainBar.TabIndex = 4
        Me.ts_MainBar.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.TB_Specification)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TB_CustomerPartCode)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.CB_CustomerName)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TB_CustomerCode)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1264, 55)
        Me.Panel1.TabIndex = 6
        '
        'TB_Specification
        '
        Me.TB_Specification.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Specification.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_Specification.Location = New System.Drawing.Point(832, 24)
        Me.TB_Specification.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Specification.Name = "TB_Specification"
        Me.TB_Specification.Size = New System.Drawing.Size(250, 25)
        Me.TB_Specification.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(711, 24)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 25)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "사양"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_CustomerPartCode
        '
        Me.TB_CustomerPartCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerPartCode.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_CustomerPartCode.Location = New System.Drawing.Point(561, 24)
        Me.TB_CustomerPartCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerPartCode.Name = "TB_CustomerPartCode"
        Me.TB_CustomerPartCode.Size = New System.Drawing.Size(150, 25)
        Me.TB_CustomerPartCode.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(440, 24)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 25)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "자재 코드"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(14, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(177, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "고객사명을 먼저 선택 하십시오."
        '
        'CB_CustomerName
        '
        Me.CB_CustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_CustomerName.Font = New System.Drawing.Font("굴림", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CB_CustomerName.FormattingEnabled = True
        Me.CB_CustomerName.Location = New System.Drawing.Point(137, 24)
        Me.CB_CustomerName.Margin = New System.Windows.Forms.Padding(0)
        Me.CB_CustomerName.Name = "CB_CustomerName"
        Me.CB_CustomerName.Size = New System.Drawing.Size(183, 25)
        Me.CB_CustomerName.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "고객사명"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_CustomerCode
        '
        Me.TB_CustomerCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerCode.Enabled = False
        Me.TB_CustomerCode.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_CustomerCode.Location = New System.Drawing.Point(320, 24)
        Me.TB_CustomerCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerCode.Name = "TB_CustomerCode"
        Me.TB_CustomerCode.Size = New System.Drawing.Size(120, 25)
        Me.TB_CustomerCode.TabIndex = 1
        '
        'Grid_PartList
        '
        Me.Grid_PartList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_PartList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_PartList.Location = New System.Drawing.Point(0, 80)
        Me.Grid_PartList.Name = "Grid_PartList"
        Me.Grid_PartList.Rows.Count = 2
        Me.Grid_PartList.Rows.DefaultSize = 20
        Me.Grid_PartList.Size = New System.Drawing.Size(1264, 693)
        Me.Grid_PartList.StyleInfo = resources.GetString("Grid_PartList.StyleInfo")
        Me.Grid_PartList.TabIndex = 7
        '
        'cms_Menu
        '
        Me.cms_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_NewPartsCode2, Me.btn_RowDelete, Me.COL_VIEW, Me.btn_Save2, Me.ToolStripSeparator3, Me.BTN_CodeMapping})
        Me.cms_Menu.Name = "GRID_Menu"
        Me.cms_Menu.Size = New System.Drawing.Size(159, 104)
        '
        'COL_VIEW
        '
        Me.COL_VIEW.Name = "COL_VIEW"
        Me.COL_VIEW.Size = New System.Drawing.Size(155, 6)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(155, 6)
        '
        'BTN_CodeMapping
        '
        Me.BTN_CodeMapping.Name = "BTN_CodeMapping"
        Me.BTN_CodeMapping.Size = New System.Drawing.Size(158, 22)
        Me.BTN_CodeMapping.Text = "Code Mapping"
        '
        'BTN_Search
        '
        Me.BTN_Search.Image = Global.YJ_MMS.My.Resources.Resources.search_121
        Me.BTN_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_Search.Name = "BTN_Search"
        Me.BTN_Search.Size = New System.Drawing.Size(51, 22)
        Me.BTN_Search.Text = "검색"
        '
        'BTN_Part_Update
        '
        Me.BTN_Part_Update.Image = Global.YJ_MMS.My.Resources.Resources.ordering_12
        Me.BTN_Part_Update.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_Part_Update.Name = "BTN_Part_Update"
        Me.BTN_Part_Update.Size = New System.Drawing.Size(103, 22)
        Me.BTN_Part_Update.Text = "자료 업데이트"
        '
        'BTN_NewMultiPartsCode
        '
        Me.BTN_NewMultiPartsCode.Enabled = False
        Me.BTN_NewMultiPartsCode.Image = Global.YJ_MMS.My.Resources.Resources.ordering_12
        Me.BTN_NewMultiPartsCode.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_NewMultiPartsCode.Name = "BTN_NewMultiPartsCode"
        Me.BTN_NewMultiPartsCode.Size = New System.Drawing.Size(75, 22)
        Me.BTN_NewMultiPartsCode.Text = "다중등록"
        '
        'BTN_Save
        '
        Me.BTN_Save.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.BTN_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(51, 22)
        Me.BTN_Save.Text = "저장"
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
        'BTN_NewPartsCode2
        '
        Me.BTN_NewPartsCode2.Image = Global.YJ_MMS.My.Resources.Resources.plus_blue
        Me.BTN_NewPartsCode2.Name = "BTN_NewPartsCode2"
        Me.BTN_NewPartsCode2.Size = New System.Drawing.Size(158, 22)
        Me.BTN_NewPartsCode2.Text = "신규 등록"
        '
        'btn_RowDelete
        '
        Me.btn_RowDelete.Image = Global.YJ_MMS.My.Resources.Resources.minus_blue
        Me.btn_RowDelete.Name = "btn_RowDelete"
        Me.btn_RowDelete.Size = New System.Drawing.Size(158, 22)
        Me.btn_RowDelete.Text = "등록 삭제(취소)"
        '
        'btn_Save2
        '
        Me.btn_Save2.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.btn_Save2.Name = "btn_Save2"
        Me.btn_Save2.Size = New System.Drawing.Size(158, 22)
        Me.btn_Save2.Text = "저장"
        '
        'frm_CustomerPartCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 773)
        Me.Controls.Add(Me.Grid_PartList)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ts_MainBar)
        Me.Name = "frm_CustomerPartCode"
        Me.Text = "고객사 자재코드 관리"
        Me.ts_MainBar.ResumeLayout(False)
        Me.ts_MainBar.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Grid_PartList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms_Menu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ts_MainBar As ToolStrip
    Friend WithEvents BTN_Search As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents BTN_Save As ToolStripButton
    Friend WithEvents Form_CLose As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents CB_CustomerName As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_CustomerCode As TextBox
    Friend WithEvents Grid_PartList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BTN_NewMultiPartsCode As ToolStripButton
    Friend WithEvents TB_CustomerPartCode As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cms_Menu As ContextMenuStrip
    Friend WithEvents btn_RowDelete As ToolStripMenuItem
    Friend WithEvents COL_VIEW As ToolStripSeparator
    Friend WithEvents btn_Save2 As ToolStripMenuItem
    Friend WithEvents BTN_NewPartsCode2 As ToolStripMenuItem
    Friend WithEvents TB_Specification As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents BTN_CodeMapping As ToolStripMenuItem
    Friend WithEvents BTN_Part_Update As ToolStripButton
End Class
