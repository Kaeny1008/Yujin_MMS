<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Change_ItemParts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Change_ItemParts))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Grid_ModelList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TB_ItemLike = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Grid_ChangeList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Grid_Menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_RowAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_RowDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.ts_MainBar = New System.Windows.Forms.ToolStrip()
        Me.Form_CLose = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Grid_ModelList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Grid_ChangeList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grid_Menu.SuspendLayout()
        Me.ts_MainBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Grid_ModelList)
        Me.GroupBox1.Controls.Add(Me.TB_ItemLike)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(26, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(453, 355)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "1. 품번 선택"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.Location = New System.Drawing.Point(136, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(189, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "품번입력 후 엔터키를 누르십시오."
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(15, 109)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(122, 24)
        Me.Label24.TabIndex = 6
        Me.Label24.Text = "[ 선택된 품번 ]"
        '
        'Grid_ModelList
        '
        Me.Grid_ModelList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_ModelList.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Grid_ModelList.Location = New System.Drawing.Point(153, 109)
        Me.Grid_ModelList.Name = "Grid_ModelList"
        Me.Grid_ModelList.Rows.Count = 2
        Me.Grid_ModelList.Rows.DefaultSize = 20
        Me.Grid_ModelList.Size = New System.Drawing.Size(280, 232)
        Me.Grid_ModelList.StyleInfo = resources.GetString("Grid_ModelList.StyleInfo")
        Me.Grid_ModelList.TabIndex = 5
        '
        'TB_ItemLike
        '
        Me.TB_ItemLike.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ItemLike.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_ItemLike.Location = New System.Drawing.Point(133, 32)
        Me.TB_ItemLike.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_ItemLike.Name = "TB_ItemLike"
        Me.TB_ItemLike.Size = New System.Drawing.Size(300, 21)
        Me.TB_ItemLike.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(13, 32)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 21)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "품번"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox2.Controls.Add(Me.Grid_ChangeList)
        Me.GroupBox2.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(485, 53)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(453, 355)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "2. 변경자재 입력"
        '
        'Grid_ChangeList
        '
        Me.Grid_ChangeList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_ChangeList.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Grid_ChangeList.Location = New System.Drawing.Point(21, 32)
        Me.Grid_ChangeList.Name = "Grid_ChangeList"
        Me.Grid_ChangeList.Rows.Count = 2
        Me.Grid_ChangeList.Rows.DefaultSize = 20
        Me.Grid_ChangeList.Size = New System.Drawing.Size(415, 309)
        Me.Grid_ChangeList.StyleInfo = resources.GetString("Grid_ChangeList.StyleInfo")
        Me.Grid_ChangeList.TabIndex = 5
        '
        'Grid_Menu
        '
        Me.Grid_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_RowAdd, Me.BTN_RowDelete})
        Me.Grid_Menu.Name = "Grid_Menu"
        Me.Grid_Menu.Size = New System.Drawing.Size(99, 48)
        '
        'BTN_RowAdd
        '
        Me.BTN_RowAdd.Name = "BTN_RowAdd"
        Me.BTN_RowAdd.Size = New System.Drawing.Size(98, 22)
        Me.BTN_RowAdd.Text = "추가"
        '
        'BTN_RowDelete
        '
        Me.BTN_RowDelete.Name = "BTN_RowDelete"
        Me.BTN_RowDelete.Size = New System.Drawing.Size(98, 22)
        Me.BTN_RowDelete.Text = "삭제"
        '
        'BTN_Save
        '
        Me.BTN_Save.Location = New System.Drawing.Point(744, 426)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(194, 40)
        Me.BTN_Save.TabIndex = 9
        Me.BTN_Save.Text = "3. 저장하기"
        Me.BTN_Save.UseVisualStyleBackColor = True
        '
        'ts_MainBar
        '
        Me.ts_MainBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ts_MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Form_CLose})
        Me.ts_MainBar.Location = New System.Drawing.Point(0, 0)
        Me.ts_MainBar.Name = "ts_MainBar"
        Me.ts_MainBar.Size = New System.Drawing.Size(1264, 25)
        Me.ts_MainBar.TabIndex = 10
        Me.ts_MainBar.Text = "ToolStrip1"
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
        'frm_Change_ItemParts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1264, 773)
        Me.Controls.Add(Me.ts_MainBar)
        Me.Controls.Add(Me.BTN_Save)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frm_Change_ItemParts"
        Me.Text = "대치자재 일괄 변경"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Grid_ModelList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.Grid_ChangeList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grid_Menu.ResumeLayout(False)
        Me.ts_MainBar.ResumeLayout(False)
        Me.ts_MainBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TB_ItemLike As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Grid_ModelList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label3 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Grid_ChangeList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Grid_Menu As ContextMenuStrip
    Friend WithEvents BTN_RowAdd As ToolStripMenuItem
    Friend WithEvents BTN_RowDelete As ToolStripMenuItem
    Friend WithEvents BTN_Save As Button
    Friend WithEvents ts_MainBar As ToolStrip
    Friend WithEvents Form_CLose As ToolStripButton
End Class
