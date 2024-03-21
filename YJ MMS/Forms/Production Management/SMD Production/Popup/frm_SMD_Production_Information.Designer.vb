<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SMD_Production_Information
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TB_Factory = New System.Windows.Forms.TextBox()
        Me.TB_Line = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TB_OrderIndex = New System.Windows.Forms.TextBox()
        Me.TB_Operater = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BTN_OK = New System.Windows.Forms.Button()
        Me.BTN_Cancel = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TB_ModelCode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TB_ItemCode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TB_ItemName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TB_WorkSide = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(21, 75)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 26)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Factory"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Factory
        '
        Me.TB_Factory.Enabled = False
        Me.TB_Factory.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_Factory.Location = New System.Drawing.Point(131, 75)
        Me.TB_Factory.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Factory.Name = "TB_Factory"
        Me.TB_Factory.Size = New System.Drawing.Size(100, 26)
        Me.TB_Factory.TabIndex = 6
        '
        'TB_Line
        '
        Me.TB_Line.Enabled = False
        Me.TB_Line.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_Line.Location = New System.Drawing.Point(307, 75)
        Me.TB_Line.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Line.Name = "TB_Line"
        Me.TB_Line.Size = New System.Drawing.Size(182, 26)
        Me.TB_Line.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(231, 75)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 26)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Line"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(21, 47)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 26)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Order Index"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_OrderIndex
        '
        Me.TB_OrderIndex.Enabled = False
        Me.TB_OrderIndex.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_OrderIndex.Location = New System.Drawing.Point(131, 47)
        Me.TB_OrderIndex.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_OrderIndex.Name = "TB_OrderIndex"
        Me.TB_OrderIndex.Size = New System.Drawing.Size(358, 26)
        Me.TB_OrderIndex.TabIndex = 10
        '
        'TB_Operater
        '
        Me.TB_Operater.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_Operater.Location = New System.Drawing.Point(131, 215)
        Me.TB_Operater.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Operater.Name = "TB_Operater"
        Me.TB_Operater.Size = New System.Drawing.Size(358, 26)
        Me.TB_Operater.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(21, 215)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 26)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Operater"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.Location = New System.Drawing.Point(250, 319)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(256, 16)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "생산 시작 등록을 하시겠습니까?"
        '
        'BTN_OK
        '
        Me.BTN_OK.Location = New System.Drawing.Point(370, 351)
        Me.BTN_OK.Name = "BTN_OK"
        Me.BTN_OK.Size = New System.Drawing.Size(119, 52)
        Me.BTN_OK.TabIndex = 14
        Me.BTN_OK.Text = "확인"
        Me.BTN_OK.UseVisualStyleBackColor = True
        '
        'BTN_Cancel
        '
        Me.BTN_Cancel.Location = New System.Drawing.Point(245, 351)
        Me.BTN_Cancel.Name = "BTN_Cancel"
        Me.BTN_Cancel.Size = New System.Drawing.Size(119, 52)
        Me.BTN_Cancel.TabIndex = 15
        Me.BTN_Cancel.Text = "취소"
        Me.BTN_Cancel.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(241, 12)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "생산정보 확인 후 Operater를 기록하십시오."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.YJ_MMS.My.Resources.Resources.blue_question_mark
        Me.PictureBox1.Location = New System.Drawing.Point(209, 309)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'TB_ModelCode
        '
        Me.TB_ModelCode.Enabled = False
        Me.TB_ModelCode.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_ModelCode.Location = New System.Drawing.Point(131, 103)
        Me.TB_ModelCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_ModelCode.Name = "TB_ModelCode"
        Me.TB_ModelCode.Size = New System.Drawing.Size(358, 26)
        Me.TB_ModelCode.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(21, 103)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 26)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Model Code"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_ItemCode
        '
        Me.TB_ItemCode.Enabled = False
        Me.TB_ItemCode.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_ItemCode.Location = New System.Drawing.Point(131, 131)
        Me.TB_ItemCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_ItemCode.Name = "TB_ItemCode"
        Me.TB_ItemCode.Size = New System.Drawing.Size(358, 26)
        Me.TB_ItemCode.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(21, 131)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 26)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Item Code"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_ItemName
        '
        Me.TB_ItemName.Enabled = False
        Me.TB_ItemName.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_ItemName.Location = New System.Drawing.Point(131, 159)
        Me.TB_ItemName.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_ItemName.Name = "TB_ItemName"
        Me.TB_ItemName.Size = New System.Drawing.Size(358, 26)
        Me.TB_ItemName.TabIndex = 23
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(21, 159)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 26)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Item Name"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.Location = New System.Drawing.Point(212, 290)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(294, 16)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "납기일자가 더 빠른 주문이 존재 합니다."
        Me.Label10.Visible = False
        '
        'TB_WorkSide
        '
        Me.TB_WorkSide.Enabled = False
        Me.TB_WorkSide.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_WorkSide.Location = New System.Drawing.Point(131, 187)
        Me.TB_WorkSide.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_WorkSide.Name = "TB_WorkSide"
        Me.TB_WorkSide.Size = New System.Drawing.Size(358, 26)
        Me.TB_WorkSide.TabIndex = 26
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(21, 187)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 26)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Work Side"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frm_SMD_Production_Information
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(516, 415)
        Me.ControlBox = False
        Me.Controls.Add(Me.TB_WorkSide)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TB_ItemName)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TB_ItemCode)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TB_ModelCode)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BTN_Cancel)
        Me.Controls.Add(Me.BTN_OK)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TB_Operater)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TB_OrderIndex)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TB_Line)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TB_Factory)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_SMD_Production_Information"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SMD 생산정보 입력"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents TB_Factory As TextBox
    Friend WithEvents TB_Line As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TB_OrderIndex As TextBox
    Friend WithEvents TB_Operater As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents BTN_OK As Button
    Friend WithEvents BTN_Cancel As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TB_ModelCode As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TB_ItemCode As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TB_ItemName As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TB_WorkSide As TextBox
    Friend WithEvents Label11 As Label
End Class
