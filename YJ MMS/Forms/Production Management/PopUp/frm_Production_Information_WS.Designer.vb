<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Production_Information_WS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Production_Information_WS))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Grid_MagazineList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TB_Top_WorkingTime = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TB_Top_ppm = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.Grid_MagazineList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(213, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "[ Magazine 단위별 현황 ]"
        '
        'Grid_MagazineList
        '
        Me.Grid_MagazineList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_MagazineList.Location = New System.Drawing.Point(26, 125)
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
        'TB_Top_WorkingTime
        '
        Me.TB_Top_WorkingTime.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Top_WorkingTime.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_Top_WorkingTime.Location = New System.Drawing.Point(162, 33)
        Me.TB_Top_WorkingTime.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Top_WorkingTime.Name = "TB_Top_WorkingTime"
        Me.TB_Top_WorkingTime.Size = New System.Drawing.Size(151, 21)
        Me.TB_Top_WorkingTime.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(26, 33)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 21)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "소요시간(H)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Top_ppm
        '
        Me.TB_Top_ppm.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Top_ppm.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_Top_ppm.Location = New System.Drawing.Point(449, 33)
        Me.TB_Top_ppm.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Top_ppm.Name = "TB_Top_ppm"
        Me.TB_Top_ppm.Size = New System.Drawing.Size(151, 21)
        Me.TB_Top_ppm.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(313, 33)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 21)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "불량율(ppm)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frm_Production_Information_WS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1070, 623)
        Me.Controls.Add(Me.TB_Top_ppm)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TB_Top_WorkingTime)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.C1FlexGrid1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Grid_MagazineList)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Production_Information_WS"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Wave / Selective 생산정보"
        CType(Me.Grid_MagazineList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Grid_MagazineList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label2 As Label
    Friend WithEvents TB_Top_WorkingTime As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TB_Top_ppm As TextBox
    Friend WithEvents Label6 As Label
End Class
