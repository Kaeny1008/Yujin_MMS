<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Coordinate_Find_Fault
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Coordinate_Find_Fault))
        Me.Grid_BOM = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Grid_Coordinates = New C1.Win.C1FlexGrid.C1FlexGrid()
        CType(Me.Grid_BOM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid_Coordinates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid_BOM
        '
        Me.Grid_BOM.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_BOM.Location = New System.Drawing.Point(0, 25)
        Me.Grid_BOM.Name = "Grid_BOM"
        Me.Grid_BOM.Rows.Count = 2
        Me.Grid_BOM.Rows.DefaultSize = 20
        Me.Grid_BOM.Size = New System.Drawing.Size(308, 425)
        Me.Grid_BOM.StyleInfo = resources.GetString("Grid_BOM.StyleInfo")
        Me.Grid_BOM.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(800, 25)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "해당 항목을 선택 후 오른쪽 좌표데이터를 더블 클릭하십시오.(※※※※※※현재는 사용하지 않음)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Grid_Coordinates
        '
        Me.Grid_Coordinates.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_Coordinates.Location = New System.Drawing.Point(314, 25)
        Me.Grid_Coordinates.Name = "Grid_Coordinates"
        Me.Grid_Coordinates.Rows.Count = 2
        Me.Grid_Coordinates.Rows.DefaultSize = 20
        Me.Grid_Coordinates.Size = New System.Drawing.Size(486, 425)
        Me.Grid_Coordinates.StyleInfo = resources.GetString("Grid_Coordinates.StyleInfo")
        Me.Grid_Coordinates.TabIndex = 12
        '
        'frm_Coordinate_Find_Fault
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Grid_Coordinates)
        Me.Controls.Add(Me.Grid_BOM)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Coordinate_Find_Fault"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BOM 리스트"
        CType(Me.Grid_BOM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid_Coordinates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grid_BOM As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label1 As Label
    Friend WithEvents Grid_Coordinates As C1.Win.C1FlexGrid.C1FlexGrid
End Class
