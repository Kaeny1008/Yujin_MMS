<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_WS_Reinspection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_WS_Reinspection))
        Me.TB_BoardNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Grid_Information = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CB_Result = New System.Windows.Forms.ComboBox()
        Me.TB_Inspector = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LB_OrderIndex = New System.Windows.Forms.Label()
        Me.BTN_Save = New System.Windows.Forms.Button()
        CType(Me.Grid_Information, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TB_BoardNo
        '
        Me.TB_BoardNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_BoardNo.Location = New System.Drawing.Point(109, 142)
        Me.TB_BoardNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_BoardNo.MaxLength = 20
        Me.TB_BoardNo.Name = "TB_BoardNo"
        Me.TB_BoardNo.Size = New System.Drawing.Size(553, 21)
        Me.TB_BoardNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 142)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Board No."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(9, 10)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 98)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "검사 및 수리정보"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Grid_Information
        '
        Me.Grid_Information.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Grid_Information.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_Information.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Grid_Information.Location = New System.Drawing.Point(109, 10)
        Me.Grid_Information.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Grid_Information.Name = "Grid_Information"
        Me.Grid_Information.Rows.Count = 2
        Me.Grid_Information.Rows.DefaultSize = 20
        Me.Grid_Information.Size = New System.Drawing.Size(799, 98)
        Me.Grid_Information.StyleInfo = resources.GetString("Grid_Information.StyleInfo")
        Me.Grid_Information.TabIndex = 3
        Me.Grid_Information.UseCompatibleTextRendering = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 165)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "검사결과"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CB_Result
        '
        Me.CB_Result.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Result.FormattingEnabled = True
        Me.CB_Result.Items.AddRange(New Object() {"OK", "NG"})
        Me.CB_Result.Location = New System.Drawing.Point(109, 165)
        Me.CB_Result.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.CB_Result.Name = "CB_Result"
        Me.CB_Result.Size = New System.Drawing.Size(553, 20)
        Me.CB_Result.TabIndex = 5
        '
        'TB_Inspector
        '
        Me.TB_Inspector.Location = New System.Drawing.Point(109, 187)
        Me.TB_Inspector.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Inspector.Name = "TB_Inspector"
        Me.TB_Inspector.Size = New System.Drawing.Size(553, 21)
        Me.TB_Inspector.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(9, 187)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 21)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "검사자"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LB_OrderIndex
        '
        Me.LB_OrderIndex.AutoSize = True
        Me.LB_OrderIndex.Location = New System.Drawing.Point(12, 209)
        Me.LB_OrderIndex.Name = "LB_OrderIndex"
        Me.LB_OrderIndex.Size = New System.Drawing.Size(71, 12)
        Me.LB_OrderIndex.TabIndex = 8
        Me.LB_OrderIndex.Text = "order_index"
        Me.LB_OrderIndex.Visible = False
        '
        'BTN_Save
        '
        Me.BTN_Save.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.BTN_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_Save.Location = New System.Drawing.Point(809, 151)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(99, 57)
        Me.BTN_Save.TabIndex = 9
        Me.BTN_Save.Text = "결과저장"
        Me.BTN_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_Save.UseVisualStyleBackColor = True
        '
        'frm_WS_Reinspection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(915, 224)
        Me.Controls.Add(Me.BTN_Save)
        Me.Controls.Add(Me.LB_OrderIndex)
        Me.Controls.Add(Me.TB_Inspector)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CB_Result)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Grid_Information)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TB_BoardNo)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_WS_Reinspection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Wave / Selective Soldering 수리결과 확인"
        CType(Me.Grid_Information, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TB_BoardNo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Grid_Information As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label3 As Label
    Friend WithEvents CB_Result As ComboBox
    Friend WithEvents TB_Inspector As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents LB_OrderIndex As Label
    Friend WithEvents BTN_Save As Button
End Class
