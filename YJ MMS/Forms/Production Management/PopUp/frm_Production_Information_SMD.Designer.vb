<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Production_Information_SMD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Production_Information_SMD))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Grid_MagazineList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.Grid_MagazineList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(213, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "[ Magazine 단위별 현황 ]"
        '
        'Grid_MagazineList
        '
        Me.Grid_MagazineList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_MagazineList.Location = New System.Drawing.Point(26, 51)
        Me.Grid_MagazineList.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_MagazineList.Name = "Grid_MagazineList"
        Me.Grid_MagazineList.Rows.Count = 2
        Me.Grid_MagazineList.Rows.DefaultSize = 20
        Me.Grid_MagazineList.Size = New System.Drawing.Size(1019, 203)
        Me.Grid_MagazineList.StyleInfo = resources.GetString("Grid_MagazineList.StyleInfo")
        Me.Grid_MagazineList.TabIndex = 5
        Me.Grid_MagazineList.UseCompatibleTextRendering = True
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.C1FlexGrid1.Location = New System.Drawing.Point(26, 366)
        Me.C1FlexGrid1.Margin = New System.Windows.Forms.Padding(0)
        Me.C1FlexGrid1.Name = "C1FlexGrid1"
        Me.C1FlexGrid1.Rows.Count = 2
        Me.C1FlexGrid1.Rows.DefaultSize = 20
        Me.C1FlexGrid1.Size = New System.Drawing.Size(1019, 203)
        Me.C1FlexGrid1.StyleInfo = resources.GetString("C1FlexGrid1.StyleInfo")
        Me.C1FlexGrid1.TabIndex = 7
        Me.C1FlexGrid1.UseCompatibleTextRendering = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 336)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "[ 불량내역 ]"
        '
        'frm_Production_Information_SMD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1070, 623)
        Me.Controls.Add(Me.C1FlexGrid1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Grid_MagazineList)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Production_Information_SMD"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SMD 생산정보"
        CType(Me.Grid_MagazineList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Grid_MagazineList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label2 As Label
End Class
