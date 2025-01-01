<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SQL_Conn
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
        Me.btnSave = New System.Windows.Forms.Button()
        Me.tbPSWD = New System.Windows.Forms.TextBox()
        Me.LB_PW = New System.Windows.Forms.Label()
        Me.tbID = New System.Windows.Forms.TextBox()
        Me.LB_ID = New System.Windows.Forms.Label()
        Me.tbPort = New System.Windows.Forms.TextBox()
        Me.LB_PORT = New System.Windows.Forms.Label()
        Me.tbIP = New System.Windows.Forms.TextBox()
        Me.LB_IP = New System.Windows.Forms.Label()
        Me.tbTimeOut = New System.Windows.Forms.TextBox()
        Me.lb_TimeOut = New System.Windows.Forms.Label()
        Me.TB_MessagePort = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TB_MessageIP = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnSave.Image = Global.YJ_MMS.My.Resources.Resources.save
        Me.btnSave.Location = New System.Drawing.Point(367, 140)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(121, 90)
        Me.btnSave.TabIndex = 19
        Me.btnSave.Text = "저장(테스트)"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'tbPSWD
        '
        Me.tbPSWD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbPSWD.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.tbPSWD.Location = New System.Drawing.Point(169, 106)
        Me.tbPSWD.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.tbPSWD.Name = "tbPSWD"
        Me.tbPSWD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbPSWD.Size = New System.Drawing.Size(171, 26)
        Me.tbPSWD.TabIndex = 18
        '
        'LB_PW
        '
        Me.LB_PW.BackColor = System.Drawing.Color.SteelBlue
        Me.LB_PW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_PW.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LB_PW.ForeColor = System.Drawing.Color.White
        Me.LB_PW.Location = New System.Drawing.Point(9, 106)
        Me.LB_PW.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.LB_PW.Name = "LB_PW"
        Me.LB_PW.Size = New System.Drawing.Size(160, 26)
        Me.LB_PW.TabIndex = 17
        Me.LB_PW.Text = "SQL P/W :"
        Me.LB_PW.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbID
        '
        Me.tbID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbID.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.tbID.Location = New System.Drawing.Point(169, 74)
        Me.tbID.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.tbID.Name = "tbID"
        Me.tbID.Size = New System.Drawing.Size(171, 26)
        Me.tbID.TabIndex = 16
        '
        'LB_ID
        '
        Me.LB_ID.BackColor = System.Drawing.Color.SteelBlue
        Me.LB_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_ID.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LB_ID.ForeColor = System.Drawing.Color.White
        Me.LB_ID.Location = New System.Drawing.Point(9, 74)
        Me.LB_ID.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.LB_ID.Name = "LB_ID"
        Me.LB_ID.Size = New System.Drawing.Size(160, 26)
        Me.LB_ID.TabIndex = 15
        Me.LB_ID.Text = "SQL ID :"
        Me.LB_ID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbPort
        '
        Me.tbPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbPort.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.tbPort.Location = New System.Drawing.Point(169, 42)
        Me.tbPort.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.tbPort.Name = "tbPort"
        Me.tbPort.Size = New System.Drawing.Size(171, 26)
        Me.tbPort.TabIndex = 14
        '
        'LB_PORT
        '
        Me.LB_PORT.BackColor = System.Drawing.Color.SteelBlue
        Me.LB_PORT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_PORT.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LB_PORT.ForeColor = System.Drawing.Color.White
        Me.LB_PORT.Location = New System.Drawing.Point(9, 42)
        Me.LB_PORT.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.LB_PORT.Name = "LB_PORT"
        Me.LB_PORT.Size = New System.Drawing.Size(160, 26)
        Me.LB_PORT.TabIndex = 13
        Me.LB_PORT.Text = "SQL Port :"
        Me.LB_PORT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbIP
        '
        Me.tbIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbIP.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.tbIP.Location = New System.Drawing.Point(169, 10)
        Me.tbIP.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.tbIP.Name = "tbIP"
        Me.tbIP.Size = New System.Drawing.Size(171, 26)
        Me.tbIP.TabIndex = 12
        '
        'LB_IP
        '
        Me.LB_IP.BackColor = System.Drawing.Color.SteelBlue
        Me.LB_IP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_IP.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LB_IP.ForeColor = System.Drawing.Color.White
        Me.LB_IP.Location = New System.Drawing.Point(9, 10)
        Me.LB_IP.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.LB_IP.Name = "LB_IP"
        Me.LB_IP.Size = New System.Drawing.Size(160, 26)
        Me.LB_IP.TabIndex = 11
        Me.LB_IP.Text = "SQL IP :"
        Me.LB_IP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbTimeOut
        '
        Me.tbTimeOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbTimeOut.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.tbTimeOut.Location = New System.Drawing.Point(169, 141)
        Me.tbTimeOut.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.tbTimeOut.Name = "tbTimeOut"
        Me.tbTimeOut.Size = New System.Drawing.Size(171, 26)
        Me.tbTimeOut.TabIndex = 21
        '
        'lb_TimeOut
        '
        Me.lb_TimeOut.BackColor = System.Drawing.Color.SteelBlue
        Me.lb_TimeOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lb_TimeOut.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lb_TimeOut.ForeColor = System.Drawing.Color.White
        Me.lb_TimeOut.Location = New System.Drawing.Point(9, 141)
        Me.lb_TimeOut.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.lb_TimeOut.Name = "lb_TimeOut"
        Me.lb_TimeOut.Size = New System.Drawing.Size(160, 26)
        Me.lb_TimeOut.TabIndex = 20
        Me.lb_TimeOut.Text = "SQL TimeOut :"
        Me.lb_TimeOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_MessagePort
        '
        Me.TB_MessagePort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TB_MessagePort.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TB_MessagePort.Location = New System.Drawing.Point(169, 206)
        Me.TB_MessagePort.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_MessagePort.Name = "TB_MessagePort"
        Me.TB_MessagePort.Size = New System.Drawing.Size(171, 26)
        Me.TB_MessagePort.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.CadetBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 206)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 26)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Message Port :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TB_MessageIP
        '
        Me.TB_MessageIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TB_MessageIP.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TB_MessageIP.Location = New System.Drawing.Point(169, 174)
        Me.TB_MessageIP.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_MessageIP.Name = "TB_MessageIP"
        Me.TB_MessageIP.Size = New System.Drawing.Size(171, 26)
        Me.TB_MessageIP.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.CadetBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(9, 174)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 26)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Message IP :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frm_SQL_Conn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(500, 242)
        Me.Controls.Add(Me.TB_MessagePort)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TB_MessageIP)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbTimeOut)
        Me.Controls.Add(Me.lb_TimeOut)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.tbPSWD)
        Me.Controls.Add(Me.LB_PW)
        Me.Controls.Add(Me.tbID)
        Me.Controls.Add(Me.LB_ID)
        Me.Controls.Add(Me.tbPort)
        Me.Controls.Add(Me.LB_PORT)
        Me.Controls.Add(Me.tbIP)
        Me.Controls.Add(Me.LB_IP)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_SQL_Conn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SQL Connection Setting"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As Button
    Friend WithEvents tbPSWD As TextBox
    Friend WithEvents LB_PW As Label
    Friend WithEvents tbID As TextBox
    Friend WithEvents LB_ID As Label
    Friend WithEvents tbPort As TextBox
    Friend WithEvents LB_PORT As Label
    Friend WithEvents tbIP As TextBox
    Friend WithEvents LB_IP As Label
    Friend WithEvents tbTimeOut As TextBox
    Friend WithEvents lb_TimeOut As Label
    Friend WithEvents TB_MessagePort As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_MessageIP As TextBox
    Friend WithEvents Label2 As Label
End Class
