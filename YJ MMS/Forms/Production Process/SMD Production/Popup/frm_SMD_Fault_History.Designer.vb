<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SMD_Fault_History
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_SMD_Fault_History))
        Me.Grid_HistoryList = New C1.Win.C1FlexGrid.C1FlexGrid()
        CType(Me.Grid_HistoryList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid_HistoryList
        '
        Me.Grid_HistoryList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_HistoryList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_HistoryList.Location = New System.Drawing.Point(0, 0)
        Me.Grid_HistoryList.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_HistoryList.Name = "Grid_HistoryList"
        Me.Grid_HistoryList.Rows.Count = 2
        Me.Grid_HistoryList.Rows.DefaultSize = 20
        Me.Grid_HistoryList.Size = New System.Drawing.Size(1264, 450)
        Me.Grid_HistoryList.StyleInfo = resources.GetString("Grid_HistoryList.StyleInfo")
        Me.Grid_HistoryList.TabIndex = 6
        Me.Grid_HistoryList.UseCompatibleTextRendering = True
        '
        'frm_SMD_Fault_History
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 450)
        Me.Controls.Add(Me.Grid_HistoryList)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_SMD_Fault_History"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SMD 불량내역"
        CType(Me.Grid_HistoryList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grid_HistoryList As C1.Win.C1FlexGrid.C1FlexGrid
End Class
