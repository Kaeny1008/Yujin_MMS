<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SMD_Magazine_Kitting
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
        Me.BTN_Exit = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TB_MagazineQty = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TB_Note = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LB_HistoryIndex = New System.Windows.Forms.Label()
        Me.TB_ItemCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TB_ItemName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TB_PONo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TB_TotalQty = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TB_SMDLine = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TB_TB = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TB_Process = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LB_ModelCode = New System.Windows.Forms.Label()
        Me.LB_CustomerCode = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BTN_Exit
        '
        Me.BTN_Exit.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_Exit.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.BTN_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_Exit.Location = New System.Drawing.Point(335, 422)
        Me.BTN_Exit.Name = "BTN_Exit"
        Me.BTN_Exit.Size = New System.Drawing.Size(144, 53)
        Me.BTN_Exit.TabIndex = 22
        Me.BTN_Exit.Text = "저장 및 발행"
        Me.BTN_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_Exit.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(9, 206)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(161, 26)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "라벨발행 여부"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_MagazineQty
        '
        Me.TB_MagazineQty.BackColor = System.Drawing.SystemColors.Window
        Me.TB_MagazineQty.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_MagazineQty.Location = New System.Drawing.Point(170, 234)
        Me.TB_MagazineQty.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_MagazineQty.Name = "TB_MagazineQty"
        Me.TB_MagazineQty.Size = New System.Drawing.Size(309, 26)
        Me.TB_MagazineQty.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 234)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 26)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Magazine 수량"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.RadioButton1.ForeColor = System.Drawing.Color.White
        Me.RadioButton1.Location = New System.Drawing.Point(3, 3)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(58, 20)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "발행"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.RadioButton2.ForeColor = System.Drawing.Color.White
        Me.RadioButton2.Location = New System.Drawing.Point(113, 3)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(74, 20)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "미발행"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RadioButton1)
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Location = New System.Drawing.Point(170, 206)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(309, 26)
        Me.Panel1.TabIndex = 23
        '
        'TB_Note
        '
        Me.TB_Note.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Note.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_Note.Location = New System.Drawing.Point(170, 262)
        Me.TB_Note.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_Note.Multiline = True
        Me.TB_Note.Name = "TB_Note"
        Me.TB_Note.Size = New System.Drawing.Size(309, 146)
        Me.TB_Note.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(9, 262)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(161, 146)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "특이사항"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LB_HistoryIndex
        '
        Me.LB_HistoryIndex.AutoSize = True
        Me.LB_HistoryIndex.Location = New System.Drawing.Point(12, 422)
        Me.LB_HistoryIndex.Name = "LB_HistoryIndex"
        Me.LB_HistoryIndex.Size = New System.Drawing.Size(80, 12)
        Me.LB_HistoryIndex.TabIndex = 19
        Me.LB_HistoryIndex.Text = "history_index"
        '
        'TB_ItemCode
        '
        Me.TB_ItemCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ItemCode.Enabled = False
        Me.TB_ItemCode.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_ItemCode.Location = New System.Drawing.Point(170, 10)
        Me.TB_ItemCode.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_ItemCode.Name = "TB_ItemCode"
        Me.TB_ItemCode.Size = New System.Drawing.Size(309, 26)
        Me.TB_ItemCode.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(9, 10)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(161, 26)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "ItemCode"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_ItemName
        '
        Me.TB_ItemName.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ItemName.Enabled = False
        Me.TB_ItemName.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_ItemName.Location = New System.Drawing.Point(170, 38)
        Me.TB_ItemName.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_ItemName.Name = "TB_ItemName"
        Me.TB_ItemName.Size = New System.Drawing.Size(309, 26)
        Me.TB_ItemName.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(9, 38)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(161, 26)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "ItemName"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_PONo
        '
        Me.TB_PONo.BackColor = System.Drawing.SystemColors.Window
        Me.TB_PONo.Enabled = False
        Me.TB_PONo.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_PONo.Location = New System.Drawing.Point(170, 66)
        Me.TB_PONo.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_PONo.Name = "TB_PONo"
        Me.TB_PONo.Size = New System.Drawing.Size(309, 26)
        Me.TB_PONo.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(9, 66)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(161, 26)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "PO No."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_TotalQty
        '
        Me.TB_TotalQty.BackColor = System.Drawing.SystemColors.Window
        Me.TB_TotalQty.Enabled = False
        Me.TB_TotalQty.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_TotalQty.Location = New System.Drawing.Point(170, 94)
        Me.TB_TotalQty.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_TotalQty.Name = "TB_TotalQty"
        Me.TB_TotalQty.Size = New System.Drawing.Size(309, 26)
        Me.TB_TotalQty.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(9, 94)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(161, 26)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Total Q'ty"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_SMDLine
        '
        Me.TB_SMDLine.BackColor = System.Drawing.SystemColors.Window
        Me.TB_SMDLine.Enabled = False
        Me.TB_SMDLine.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_SMDLine.Location = New System.Drawing.Point(170, 122)
        Me.TB_SMDLine.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_SMDLine.Name = "TB_SMDLine"
        Me.TB_SMDLine.Size = New System.Drawing.Size(309, 26)
        Me.TB_SMDLine.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(9, 122)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(161, 26)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "SMD Line"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_TB
        '
        Me.TB_TB.BackColor = System.Drawing.SystemColors.Window
        Me.TB_TB.Enabled = False
        Me.TB_TB.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_TB.Location = New System.Drawing.Point(170, 150)
        Me.TB_TB.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_TB.Name = "TB_TB"
        Me.TB_TB.Size = New System.Drawing.Size(309, 26)
        Me.TB_TB.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(9, 150)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(161, 26)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "TOP / Bottom"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Process
        '
        Me.TB_Process.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Process.Enabled = False
        Me.TB_Process.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_Process.Location = New System.Drawing.Point(170, 178)
        Me.TB_Process.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_Process.Name = "TB_Process"
        Me.TB_Process.Size = New System.Drawing.Size(309, 26)
        Me.TB_Process.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(9, 178)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(161, 26)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Process"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LB_ModelCode
        '
        Me.LB_ModelCode.AutoSize = True
        Me.LB_ModelCode.Location = New System.Drawing.Point(12, 434)
        Me.LB_ModelCode.Name = "LB_ModelCode"
        Me.LB_ModelCode.Size = New System.Drawing.Size(74, 12)
        Me.LB_ModelCode.TabIndex = 20
        Me.LB_ModelCode.Text = "model_code"
        '
        'LB_CustomerCode
        '
        Me.LB_CustomerCode.AutoSize = True
        Me.LB_CustomerCode.Location = New System.Drawing.Point(12, 446)
        Me.LB_CustomerCode.Name = "LB_CustomerCode"
        Me.LB_CustomerCode.Size = New System.Drawing.Size(88, 12)
        Me.LB_CustomerCode.TabIndex = 21
        Me.LB_CustomerCode.Text = "customerCode"
        '
        'frm_SMD_Magazine_Kitting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSlateGray
        Me.ClientSize = New System.Drawing.Size(497, 502)
        Me.Controls.Add(Me.LB_CustomerCode)
        Me.Controls.Add(Me.LB_ModelCode)
        Me.Controls.Add(Me.TB_Process)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TB_TB)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TB_SMDLine)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TB_TotalQty)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TB_PONo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TB_ItemName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TB_ItemCode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LB_HistoryIndex)
        Me.Controls.Add(Me.TB_Note)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TB_MagazineQty)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BTN_Exit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_SMD_Magazine_Kitting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SMD 생산내역 등록"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BTN_Exit As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents TB_MagazineQty As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TB_Note As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents LB_HistoryIndex As Label
    Friend WithEvents TB_ItemCode As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TB_ItemName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TB_PONo As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TB_TotalQty As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TB_SMDLine As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TB_TB As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TB_Process As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents LB_ModelCode As Label
    Friend WithEvents LB_CustomerCode As Label
End Class
