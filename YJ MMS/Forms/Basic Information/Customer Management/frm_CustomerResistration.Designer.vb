<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_CustomerResistration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_CustomerResistration))
        Me.ts_MainBar = New System.Windows.Forms.ToolStrip()
        Me.btn_Search = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_NewCustomer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_Save = New System.Windows.Forms.ToolStripButton()
        Me.Form_CLose = New System.Windows.Forms.ToolStripButton()
        Me.grid_CustomerList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tb_SearchText = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cms_Menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btn_RowDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.COL_VIEW = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_Save2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ts_MainBar.SuspendLayout()
        CType(Me.grid_CustomerList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.cms_Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'ts_MainBar
        '
        Me.ts_MainBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ts_MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_Search, Me.ToolStripSeparator1, Me.btn_NewCustomer, Me.ToolStripSeparator2, Me.btn_Save, Me.Form_CLose})
        Me.ts_MainBar.Location = New System.Drawing.Point(0, 0)
        Me.ts_MainBar.Name = "ts_MainBar"
        Me.ts_MainBar.Size = New System.Drawing.Size(1264, 25)
        Me.ts_MainBar.TabIndex = 3
        Me.ts_MainBar.Text = "ToolStrip1"
        '
        'btn_Search
        '
        Me.btn_Search.Image = Global.YJ_MMS.My.Resources.Resources.search_121
        Me.btn_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Search.Name = "btn_Search"
        Me.btn_Search.Size = New System.Drawing.Size(51, 22)
        Me.btn_Search.Text = "검색"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btn_NewCustomer
        '
        Me.btn_NewCustomer.Image = Global.YJ_MMS.My.Resources.Resources.plus_blue
        Me.btn_NewCustomer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_NewCustomer.Name = "btn_NewCustomer"
        Me.btn_NewCustomer.Size = New System.Drawing.Size(75, 22)
        Me.btn_NewCustomer.Text = "신규등록"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btn_Save
        '
        Me.btn_Save.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.btn_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(51, 22)
        Me.btn_Save.Text = "저장"
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
        'grid_CustomerList
        '
        Me.grid_CustomerList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.grid_CustomerList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid_CustomerList.Location = New System.Drawing.Point(0, 59)
        Me.grid_CustomerList.Name = "grid_CustomerList"
        Me.grid_CustomerList.Rows.Count = 2
        Me.grid_CustomerList.Rows.DefaultSize = 20
        Me.grid_CustomerList.Size = New System.Drawing.Size(1264, 714)
        Me.grid_CustomerList.StyleInfo = resources.GetString("grid_CustomerList.StyleInfo")
        Me.grid_CustomerList.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.tb_SearchText)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1264, 34)
        Me.Panel1.TabIndex = 4
        '
        'tb_SearchText
        '
        Me.tb_SearchText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tb_SearchText.BackColor = System.Drawing.SystemColors.Window
        Me.tb_SearchText.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.tb_SearchText.Location = New System.Drawing.Point(122, 6)
        Me.tb_SearchText.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.tb_SearchText.Name = "tb_SearchText"
        Me.tb_SearchText.Size = New System.Drawing.Size(1142, 21)
        Me.tb_SearchText.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(1, 6)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 21)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "검색 내용"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cms_Menu
        '
        Me.cms_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_RowDelete, Me.COL_VIEW, Me.btn_Save2})
        Me.cms_Menu.Name = "GRID_Menu"
        Me.cms_Menu.Size = New System.Drawing.Size(181, 76)
        '
        'btn_RowDelete
        '
        Me.btn_RowDelete.Image = Global.YJ_MMS.My.Resources.Resources.minus_blue
        Me.btn_RowDelete.Name = "btn_RowDelete"
        Me.btn_RowDelete.Size = New System.Drawing.Size(180, 22)
        Me.btn_RowDelete.Text = "등록 삭제(취소)"
        '
        'COL_VIEW
        '
        Me.COL_VIEW.Name = "COL_VIEW"
        Me.COL_VIEW.Size = New System.Drawing.Size(177, 6)
        '
        'btn_Save2
        '
        Me.btn_Save2.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.btn_Save2.Name = "btn_Save2"
        Me.btn_Save2.Size = New System.Drawing.Size(180, 22)
        Me.btn_Save2.Text = "저장"
        '
        'Timer1
        '
        '
        'frm_CustomerResistration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 773)
        Me.Controls.Add(Me.grid_CustomerList)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ts_MainBar)
        Me.Name = "frm_CustomerResistration"
        Me.Text = "고객사 관리"
        Me.ts_MainBar.ResumeLayout(False)
        Me.ts_MainBar.PerformLayout()
        CType(Me.grid_CustomerList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.cms_Menu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ts_MainBar As ToolStrip
    Friend WithEvents btn_Search As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btn_NewCustomer As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btn_Save As ToolStripButton
    Friend WithEvents Form_CLose As ToolStripButton
    Friend WithEvents grid_CustomerList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel1 As Panel
    Friend WithEvents tb_SearchText As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cms_Menu As ContextMenuStrip
    Friend WithEvents btn_RowDelete As ToolStripMenuItem
    Friend WithEvents COL_VIEW As ToolStripSeparator
    Friend WithEvents btn_Save2 As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ToolTip1 As ToolTip
End Class
