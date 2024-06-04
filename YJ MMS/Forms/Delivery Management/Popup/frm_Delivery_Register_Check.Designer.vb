<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Delivery_Register_Check
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Delivery_Register_Check))
        Me.Grid_POList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TS_MainBar = New System.Windows.Forms.ToolStrip()
        Me.BTN_Save = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        CType(Me.Grid_POList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TS_MainBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grid_POList
        '
        Me.Grid_POList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_POList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_POList.Location = New System.Drawing.Point(0, 25)
        Me.Grid_POList.Name = "Grid_POList"
        Me.Grid_POList.Rows.Count = 2
        Me.Grid_POList.Rows.DefaultSize = 20
        Me.Grid_POList.Size = New System.Drawing.Size(987, 514)
        Me.Grid_POList.StyleInfo = resources.GetString("Grid_POList.StyleInfo")
        Me.Grid_POList.TabIndex = 10
        '
        'TS_MainBar
        '
        Me.TS_MainBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Save, Me.ToolStripSeparator1, Me.ToolStripLabel2, Me.ToolStripLabel1})
        Me.TS_MainBar.Location = New System.Drawing.Point(0, 0)
        Me.TS_MainBar.Name = "TS_MainBar"
        Me.TS_MainBar.Size = New System.Drawing.Size(987, 25)
        Me.TS_MainBar.TabIndex = 11
        Me.TS_MainBar.Text = "ToolStrip1"
        '
        'BTN_Save
        '
        Me.BTN_Save.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.BTN_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(147, 22)
        Me.BTN_Save.Text = "납품전표 발행 및 저장"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(95, 22)
        Me.ToolStripLabel1.Text = "DN2406040001"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripLabel2.Text = "전표번호 :"
        '
        'frm_Delivery_Register_Check
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(987, 539)
        Me.Controls.Add(Me.Grid_POList)
        Me.Controls.Add(Me.TS_MainBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Delivery_Register_Check"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "납품목록 확인"
        CType(Me.Grid_POList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TS_MainBar.ResumeLayout(False)
        Me.TS_MainBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Grid_POList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TS_MainBar As ToolStrip
    Friend WithEvents BTN_Save As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
End Class
