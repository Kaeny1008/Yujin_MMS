<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Material_Stock_Survey_Part_Detail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Material_Stock_Survey_Part_Detail))
        Me.Grid_List = New C1.Win.C1FlexGrid.C1FlexGrid()
        CType(Me.Grid_List, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid_List
        '
        Me.Grid_List.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_List.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_List.Location = New System.Drawing.Point(0, 0)
        Me.Grid_List.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_List.Name = "Grid_List"
        Me.Grid_List.Rows.Count = 2
        Me.Grid_List.Rows.DefaultSize = 20
        Me.Grid_List.Size = New System.Drawing.Size(1100, 450)
        Me.Grid_List.StyleInfo = resources.GetString("Grid_List.StyleInfo")
        Me.Grid_List.TabIndex = 40
        '
        'frm_Material_Stock_Survey_Part_Detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 450)
        Me.Controls.Add(Me.Grid_List)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Material_Stock_Survey_Part_Detail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "자세히 보기"
        CType(Me.Grid_List, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grid_List As C1.Win.C1FlexGrid.C1FlexGrid
End Class
