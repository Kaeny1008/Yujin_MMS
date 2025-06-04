<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Encrypt_Decrypt
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.TB_MK_String = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.TB_MK_Hex = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CB_Bit = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CB_CryptType = New System.Windows.Forms.ComboBox()
        Me.TB_InPut = New System.Windows.Forms.TextBox()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 24)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(455, 21)
        Me.TextBox1.TabIndex = 0
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(473, 24)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(248, 21)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Text = "12345678"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Data"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(471, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Key"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(471, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Key"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Data"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(473, 63)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(248, 21)
        Me.TextBox3.TabIndex = 5
        Me.TextBox3.Text = "12345678"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(12, 63)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(455, 21)
        Me.TextBox4.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(727, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "암호화"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(727, 63)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "복호화"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(12, 160)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(893, 196)
        Me.TextBox5.TabIndex = 10
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(808, 24)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(97, 23)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "SHA256 암호화"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(727, 102)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(86, 23)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "Text to Hex"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(12, 102)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(709, 21)
        Me.TextBox6.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 12)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Data"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(819, 102)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(86, 23)
        Me.Button5.TabIndex = 13
        Me.Button5.Text = "Hex to Text"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(727, 131)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(86, 23)
        Me.Button6.TabIndex = 14
        Me.Button6.Text = "생성"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(656, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "PartStation"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(819, 131)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(86, 23)
        Me.Button7.TabIndex = 16
        Me.Button7.Text = "키테스트"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'TB_MK_String
        '
        Me.TB_MK_String.Location = New System.Drawing.Point(12, 385)
        Me.TB_MK_String.Name = "TB_MK_String"
        Me.TB_MK_String.Size = New System.Drawing.Size(248, 21)
        Me.TB_MK_String.TabIndex = 5
        Me.TB_MK_String.Text = "samsung s techwinner w 5tkattjd!"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 370)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 12)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Master Key"
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(727, 385)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(86, 23)
        Me.Button9.TabIndex = 18
        Me.Button9.Text = "Text to Hex"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'TB_MK_Hex
        '
        Me.TB_MK_Hex.Location = New System.Drawing.Point(266, 385)
        Me.TB_MK_Hex.Name = "TB_MK_Hex"
        Me.TB_MK_Hex.Size = New System.Drawing.Size(455, 21)
        Me.TB_MK_Hex.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 413)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 12)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Key Bits"
        '
        'CB_Bit
        '
        Me.CB_Bit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Bit.FormattingEnabled = True
        Me.CB_Bit.Items.AddRange(New Object() {"128", "192", "256"})
        Me.CB_Bit.Location = New System.Drawing.Point(70, 409)
        Me.CB_Bit.Name = "CB_Bit"
        Me.CB_Bit.Size = New System.Drawing.Size(121, 20)
        Me.CB_Bit.TabIndex = 21
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(197, 413)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 12)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Crypt Type"
        '
        'CB_CryptType
        '
        Me.CB_CryptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_CryptType.FormattingEnabled = True
        Me.CB_CryptType.Items.AddRange(New Object() {"Encrypt", "Decrypt"})
        Me.CB_CryptType.Location = New System.Drawing.Point(271, 409)
        Me.CB_CryptType.Name = "CB_CryptType"
        Me.CB_CryptType.Size = New System.Drawing.Size(121, 20)
        Me.CB_CryptType.TabIndex = 23
        '
        'TB_InPut
        '
        Me.TB_InPut.Location = New System.Drawing.Point(94, 435)
        Me.TB_InPut.Multiline = True
        Me.TB_InPut.Name = "TB_InPut"
        Me.TB_InPut.Size = New System.Drawing.Size(811, 87)
        Me.TB_InPut.TabIndex = 24
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(94, 528)
        Me.TextBox10.Multiline = True
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(811, 87)
        Me.TextBox10.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 472)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 12)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Input"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 565)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 12)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Output(Hex)"
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(819, 409)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(86, 23)
        Me.Button8.TabIndex = 28
        Me.Button8.Text = "Crypt"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'frm_Encrypt_Decrypt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 640)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextBox10)
        Me.Controls.Add(Me.TB_InPut)
        Me.Controls.Add(Me.CB_CryptType)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.CB_Bit)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TB_MK_Hex)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TB_MK_String)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "frm_Encrypt_Decrypt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "암호화 / 복호화"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents TB_MK_String As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Button9 As Button
    Friend WithEvents TB_MK_Hex As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents CB_Bit As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents CB_CryptType As ComboBox
    Friend WithEvents TB_InPut As TextBox
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Button8 As Button
End Class
