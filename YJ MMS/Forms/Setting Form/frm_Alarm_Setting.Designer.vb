<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Alarm_Setting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Alarm_Setting))
        Me.Grid_AlarmList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Grid_Menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_RowAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_RowDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_Save = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Grid_AlarmList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grid_Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grid_AlarmList
        '
        Me.Grid_AlarmList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_AlarmList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_AlarmList.Location = New System.Drawing.Point(0, 0)
        Me.Grid_AlarmList.Name = "Grid_AlarmList"
        Me.Grid_AlarmList.Rows.Count = 2
        Me.Grid_AlarmList.Rows.DefaultSize = 20
        Me.Grid_AlarmList.Size = New System.Drawing.Size(800, 450)
        Me.Grid_AlarmList.StyleInfo = resources.GetString("Grid_AlarmList.StyleInfo")
        Me.Grid_AlarmList.TabIndex = 4
        '
        'Grid_Menu
        '
        Me.Grid_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_RowAdd, Me.BTN_RowDelete, Me.ToolStripSeparator1, Me.BTN_Save})
        Me.Grid_Menu.Name = "Grid_Menu"
        Me.Grid_Menu.Size = New System.Drawing.Size(127, 76)
        '
        'BTN_RowAdd
        '
        Me.BTN_RowAdd.Enabled = False
        Me.BTN_RowAdd.Name = "BTN_RowAdd"
        Me.BTN_RowAdd.Size = New System.Drawing.Size(126, 22)
        Me.BTN_RowAdd.Text = "알람 추가"
        '
        'BTN_RowDelete
        '
        Me.BTN_RowDelete.Enabled = False
        Me.BTN_RowDelete.Name = "BTN_RowDelete"
        Me.BTN_RowDelete.Size = New System.Drawing.Size(126, 22)
        Me.BTN_RowDelete.Text = "알람 삭제"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(123, 6)
        '
        'BTN_Save
        '
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(126, 22)
        Me.BTN_Save.Text = "저장"
        '
        'frm_Alarm_Setting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Grid_AlarmList)
        Me.Name = "frm_Alarm_Setting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "알림 설정"
        CType(Me.Grid_AlarmList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grid_Menu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grid_AlarmList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Grid_Menu As ContextMenuStrip
    Friend WithEvents BTN_RowAdd As ToolStripMenuItem
    Friend WithEvents BTN_RowDelete As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BTN_Save As ToolStripMenuItem
End Class
