<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Material_Use_Information
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Material_Use_Information))
        Me.TB_PartCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Grid_Ready = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Grid_Run = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Grid_Completed = New C1.Win.C1FlexGrid.C1FlexGrid()
        CType(Me.Grid_Ready, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid_Run, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid_Completed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TB_PartCode
        '
        Me.TB_PartCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_PartCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_PartCode.ImeMode = System.Windows.Forms.ImeMode.Close
        Me.TB_PartCode.Location = New System.Drawing.Point(136, 10)
        Me.TB_PartCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_PartCode.Name = "TB_PartCode"
        Me.TB_PartCode.Size = New System.Drawing.Size(301, 21)
        Me.TB_PartCode.TabIndex = 42
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.RoyalBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 21)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Part Code"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Grid_Ready
        '
        Me.Grid_Ready.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_Ready.Location = New System.Drawing.Point(9, 64)
        Me.Grid_Ready.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_Ready.Name = "Grid_Ready"
        Me.Grid_Ready.Rows.Count = 2
        Me.Grid_Ready.Rows.DefaultSize = 20
        Me.Grid_Ready.Size = New System.Drawing.Size(782, 155)
        Me.Grid_Ready.StyleInfo = resources.GetString("Grid_Ready.StyleInfo")
        Me.Grid_Ready.TabIndex = 43
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 42)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 10, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(782, 21)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "생산계획 확정"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(9, 229)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 10, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(782, 21)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "생산중"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Grid_Run
        '
        Me.Grid_Run.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_Run.Location = New System.Drawing.Point(9, 251)
        Me.Grid_Run.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_Run.Name = "Grid_Run"
        Me.Grid_Run.Rows.Count = 2
        Me.Grid_Run.Rows.DefaultSize = 20
        Me.Grid_Run.Size = New System.Drawing.Size(782, 155)
        Me.Grid_Run.StyleInfo = resources.GetString("Grid_Run.StyleInfo")
        Me.Grid_Run.TabIndex = 45
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(9, 416)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 10, 0, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(782, 21)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "생산완료"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Grid_Completed
        '
        Me.Grid_Completed.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_Completed.Location = New System.Drawing.Point(9, 438)
        Me.Grid_Completed.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_Completed.Name = "Grid_Completed"
        Me.Grid_Completed.Rows.Count = 2
        Me.Grid_Completed.Rows.DefaultSize = 20
        Me.Grid_Completed.Size = New System.Drawing.Size(782, 155)
        Me.Grid_Completed.StyleInfo = resources.GetString("Grid_Completed.StyleInfo")
        Me.Grid_Completed.TabIndex = 47
        '
        'frm_Material_Use_Information
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(800, 606)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Grid_Completed)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Grid_Run)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Grid_Ready)
        Me.Controls.Add(Me.TB_PartCode)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Material_Use_Information"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "사용대기, 사용이력 확인"
        CType(Me.Grid_Ready, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid_Run, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid_Completed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TB_PartCode As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Grid_Ready As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Grid_Run As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label4 As Label
    Friend WithEvents Grid_Completed As C1.Win.C1FlexGrid.C1FlexGrid
End Class
