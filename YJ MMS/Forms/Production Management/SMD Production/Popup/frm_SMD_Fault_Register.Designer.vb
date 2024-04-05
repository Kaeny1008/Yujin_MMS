<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SMD_Fault_Register
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_SMD_Fault_Register))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTN_Exit = New System.Windows.Forms.Button()
        Me.BTN_RowDelete = New System.Windows.Forms.Button()
        Me.BTN_RowAdd = New System.Windows.Forms.Button()
        Me.Grid_Fault = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.Grid_Fault, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.BTN_Exit)
        Me.Panel1.Controls.Add(Me.BTN_RowDelete)
        Me.Panel1.Controls.Add(Me.BTN_RowAdd)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 62)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 12)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "oder_index"
        Me.Label1.Visible = False
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
        'BTN_RowDelete
        '
        Me.BTN_RowDelete.Enabled = False
        Me.BTN_RowDelete.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_RowDelete.Image = Global.YJ_MMS.My.Resources.Resources.minus_blue
        Me.BTN_RowDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_RowDelete.Location = New System.Drawing.Point(526, 12)
        Me.BTN_RowDelete.Name = "BTN_RowDelete"
        Me.BTN_RowDelete.Size = New System.Drawing.Size(112, 37)
        Me.BTN_RowDelete.TabIndex = 31
        Me.BTN_RowDelete.Text = "행삭제(F3)"
        Me.BTN_RowDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_RowDelete.UseVisualStyleBackColor = True
        '
        'BTN_RowAdd
        '
        Me.BTN_RowAdd.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_RowAdd.Image = Global.YJ_MMS.My.Resources.Resources.plus_blue
        Me.BTN_RowAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_RowAdd.Location = New System.Drawing.Point(408, 12)
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 12)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "history_index"
        Me.Label2.Visible = False
        '
        'frm_SMD_Fault_Register
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
        Me.Name = "frm_SMD_Fault_Register"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SMD 불량내역 등록"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Grid_Fault, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Grid_Fault As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BTN_RowDelete As Button
    Friend WithEvents BTN_RowAdd As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents BTN_Exit As Button
    Friend WithEvents Label2 As Label
End Class
