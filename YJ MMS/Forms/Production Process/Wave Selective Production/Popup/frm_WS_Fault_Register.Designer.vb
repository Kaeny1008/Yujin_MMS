<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_WS_Fault_Register
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_WS_Fault_Register))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LB_SMDLine = New System.Windows.Forms.Label()
        Me.LB_ItemName = New System.Windows.Forms.Label()
        Me.LB_ItemCode = New System.Windows.Forms.Label()
        Me.LB_HistoryIndex = New System.Windows.Forms.Label()
        Me.LB_OrderIndex = New System.Windows.Forms.Label()
        Me.BTN_Exit = New System.Windows.Forms.Button()
        Me.BTN_RowAdd = New System.Windows.Forms.Button()
        Me.Grid_Fault = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Grid_Menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_RowDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        CType(Me.Grid_Fault, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grid_Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Panel1.Controls.Add(Me.LB_SMDLine)
        Me.Panel1.Controls.Add(Me.LB_ItemName)
        Me.Panel1.Controls.Add(Me.LB_ItemCode)
        Me.Panel1.Controls.Add(Me.LB_HistoryIndex)
        Me.Panel1.Controls.Add(Me.LB_OrderIndex)
        Me.Panel1.Controls.Add(Me.BTN_Exit)
        Me.Panel1.Controls.Add(Me.BTN_RowAdd)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 62)
        Me.Panel1.TabIndex = 0
        '
        'LB_SMDLine
        '
        Me.LB_SMDLine.AutoSize = True
        Me.LB_SMDLine.Location = New System.Drawing.Point(276, 26)
        Me.LB_SMDLine.Name = "LB_SMDLine"
        Me.LB_SMDLine.Size = New System.Drawing.Size(60, 12)
        Me.LB_SMDLine.TabIndex = 36
        Me.LB_SMDLine.Text = "SMD Line"
        Me.LB_SMDLine.Visible = False
        '
        'LB_ItemName
        '
        Me.LB_ItemName.AutoSize = True
        Me.LB_ItemName.Location = New System.Drawing.Point(188, 38)
        Me.LB_ItemName.Name = "LB_ItemName"
        Me.LB_ItemName.Size = New System.Drawing.Size(63, 12)
        Me.LB_ItemName.TabIndex = 35
        Me.LB_ItemName.Text = "itemName"
        Me.LB_ItemName.Visible = False
        '
        'LB_ItemCode
        '
        Me.LB_ItemCode.AutoSize = True
        Me.LB_ItemCode.Location = New System.Drawing.Point(188, 26)
        Me.LB_ItemCode.Name = "LB_ItemCode"
        Me.LB_ItemCode.Size = New System.Drawing.Size(59, 12)
        Me.LB_ItemCode.TabIndex = 34
        Me.LB_ItemCode.Text = "itemCode"
        Me.LB_ItemCode.Visible = False
        '
        'LB_HistoryIndex
        '
        Me.LB_HistoryIndex.AutoSize = True
        Me.LB_HistoryIndex.Location = New System.Drawing.Point(25, 38)
        Me.LB_HistoryIndex.Name = "LB_HistoryIndex"
        Me.LB_HistoryIndex.Size = New System.Drawing.Size(80, 12)
        Me.LB_HistoryIndex.TabIndex = 33
        Me.LB_HistoryIndex.Text = "history_index"
        Me.LB_HistoryIndex.Visible = False
        '
        'LB_OrderIndex
        '
        Me.LB_OrderIndex.AutoSize = True
        Me.LB_OrderIndex.Location = New System.Drawing.Point(25, 26)
        Me.LB_OrderIndex.Name = "LB_OrderIndex"
        Me.LB_OrderIndex.Size = New System.Drawing.Size(67, 12)
        Me.LB_OrderIndex.TabIndex = 32
        Me.LB_OrderIndex.Text = "oder_index"
        Me.LB_OrderIndex.Visible = False
        '
        'BTN_Exit
        '
        Me.BTN_Exit.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_Exit.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.BTN_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_Exit.Location = New System.Drawing.Point(644, 12)
        Me.BTN_Exit.Name = "BTN_Exit"
        Me.BTN_Exit.Size = New System.Drawing.Size(144, 37)
        Me.BTN_Exit.TabIndex = 31
        Me.BTN_Exit.Text = "창 닫기(저장)"
        Me.BTN_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_Exit.UseVisualStyleBackColor = True
        '
        'BTN_RowAdd
        '
        Me.BTN_RowAdd.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_RowAdd.Image = Global.YJ_MMS.My.Resources.Resources.plus_blue
        Me.BTN_RowAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_RowAdd.Location = New System.Drawing.Point(526, 12)
        Me.BTN_RowAdd.Name = "BTN_RowAdd"
        Me.BTN_RowAdd.Size = New System.Drawing.Size(112, 37)
        Me.BTN_RowAdd.TabIndex = 30
        Me.BTN_RowAdd.Text = "행추가(F1)"
        Me.BTN_RowAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_RowAdd.UseVisualStyleBackColor = True
        '
        'Grid_Fault
        '
        Me.Grid_Fault.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_Fault.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_Fault.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Grid_Fault.Location = New System.Drawing.Point(0, 62)
        Me.Grid_Fault.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_Fault.Name = "Grid_Fault"
        Me.Grid_Fault.Rows.Count = 2
        Me.Grid_Fault.Rows.DefaultSize = 20
        Me.Grid_Fault.Size = New System.Drawing.Size(800, 388)
        Me.Grid_Fault.StyleInfo = resources.GetString("Grid_Fault.StyleInfo")
        Me.Grid_Fault.TabIndex = 6
        Me.Grid_Fault.UseCompatibleTextRendering = True
        '
        'Grid_Menu
        '
        Me.Grid_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_RowDelete})
        Me.Grid_Menu.Name = "Grid_Menu"
        Me.Grid_Menu.Size = New System.Drawing.Size(181, 48)
        '
        'BTN_RowDelete
        '
        Me.BTN_RowDelete.Name = "BTN_RowDelete"
        Me.BTN_RowDelete.Size = New System.Drawing.Size(180, 22)
        Me.BTN_RowDelete.Text = "행 삭제"
        '
        'frm_WS_Fault_Register
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Grid_Fault)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_WS_Fault_Register"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Wave / Selective 불량내역 등록"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Grid_Fault, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grid_Menu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Grid_Fault As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BTN_RowAdd As Button
    Friend WithEvents LB_OrderIndex As Label
    Friend WithEvents BTN_Exit As Button
    Friend WithEvents LB_HistoryIndex As Label
    Friend WithEvents LB_ItemName As Label
    Friend WithEvents LB_ItemCode As Label
    Friend WithEvents LB_SMDLine As Label
    Friend WithEvents Grid_Menu As ContextMenuStrip
    Friend WithEvents BTN_RowDelete As ToolStripMenuItem
End Class
