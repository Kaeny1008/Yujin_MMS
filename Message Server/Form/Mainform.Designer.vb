<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.ClientList = New System.Windows.Forms.ListView()
        Me.IPPort = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.JoinTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Line = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LineCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Response = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ClientCheckingTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ClientRemoveTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ClientListPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MessageList = New System.Windows.Forms.ListView()
        Me.ListNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListSender = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListMemo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MessageListPanel = New System.Windows.Forms.Panel()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AlarmList = New System.Windows.Forms.ListView()
        Me.AlarmNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AlarmTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AlarmLine = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AlarmStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AlarmListPanel = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonPanel = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnMessageClear = New System.Windows.Forms.Button()
        Me.btnAlarmClear = New System.Windows.Forms.Button()
        Me.btnSetting = New System.Windows.Forms.Button()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.NIMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnMinimum = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ClientListPanel.SuspendLayout()
        Me.MessageListPanel.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AlarmListPanel.SuspendLayout()
        Me.ButtonPanel.SuspendLayout()
        Me.NIMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'ClientList
        '
        Me.ClientList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IPPort, Me.JoinTime, Me.Line, Me.LineCode, Me.Response})
        Me.ClientList.GridLines = True
        Me.ClientList.HideSelection = False
        Me.ClientList.Location = New System.Drawing.Point(0, 30)
        Me.ClientList.Margin = New System.Windows.Forms.Padding(0)
        Me.ClientList.Name = "ClientList"
        Me.ClientList.Size = New System.Drawing.Size(647, 225)
        Me.ClientList.TabIndex = 7
        Me.ClientList.UseCompatibleStateImageBehavior = False
        Me.ClientList.View = System.Windows.Forms.View.Details
        '
        'IPPort
        '
        Me.IPPort.Text = "IP Address : Port"
        Me.IPPort.Width = 150
        '
        'JoinTime
        '
        Me.JoinTime.Text = "연결시간"
        Me.JoinTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.JoinTime.Width = 160
        '
        'Line
        '
        Me.Line.Text = "Line(Login ID)"
        Me.Line.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Line.Width = 100
        '
        'LineCode
        '
        Me.LineCode.Text = "LineCode"
        Me.LineCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.LineCode.Width = 100
        '
        'Response
        '
        Me.Response.Text = "상태"
        Me.Response.Width = 120
        '
        'ClientCheckingTimer
        '
        '
        'ClientRemoveTimer
        '
        '
        'ClientListPanel
        '
        Me.ClientListPanel.BackColor = System.Drawing.Color.LightBlue
        Me.ClientListPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ClientListPanel.Controls.Add(Me.Label1)
        Me.ClientListPanel.ForeColor = System.Drawing.Color.White
        Me.ClientListPanel.Location = New System.Drawing.Point(0, 0)
        Me.ClientListPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.ClientListPanel.Name = "ClientListPanel"
        Me.ClientListPanel.Size = New System.Drawing.Size(647, 30)
        Me.ClientListPanel.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 29)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Client List"
        '
        'MessageList
        '
        Me.MessageList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ListNo, Me.ListTime, Me.ListSender, Me.ListMemo})
        Me.MessageList.GridLines = True
        Me.MessageList.HideSelection = False
        Me.MessageList.Location = New System.Drawing.Point(0, 285)
        Me.MessageList.Margin = New System.Windows.Forms.Padding(0)
        Me.MessageList.Name = "MessageList"
        Me.MessageList.Size = New System.Drawing.Size(1075, 219)
        Me.MessageList.TabIndex = 15
        Me.MessageList.UseCompatibleStateImageBehavior = False
        Me.MessageList.View = System.Windows.Forms.View.Details
        '
        'ListNo
        '
        Me.ListNo.Text = "No"
        Me.ListNo.Width = 30
        '
        'ListTime
        '
        Me.ListTime.Text = "Time"
        Me.ListTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ListTime.Width = 140
        '
        'ListSender
        '
        Me.ListSender.Text = "Sender"
        Me.ListSender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ListSender.Width = 110
        '
        'ListMemo
        '
        Me.ListMemo.Text = "Message"
        Me.ListMemo.Width = 470
        '
        'MessageListPanel
        '
        Me.MessageListPanel.BackColor = System.Drawing.Color.LightBlue
        Me.MessageListPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MessageListPanel.Controls.Add(Me.NumericUpDown1)
        Me.MessageListPanel.Controls.Add(Me.Label4)
        Me.MessageListPanel.Controls.Add(Me.Label2)
        Me.MessageListPanel.ForeColor = System.Drawing.Color.White
        Me.MessageListPanel.Location = New System.Drawing.Point(0, 255)
        Me.MessageListPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.MessageListPanel.Name = "MessageListPanel"
        Me.MessageListPanel.Size = New System.Drawing.Size(1075, 30)
        Me.MessageListPanel.TabIndex = 14
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(986, 4)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(83, 21)
        Me.NumericUpDown1.TabIndex = 12
        Me.NumericUpDown1.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(830, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 12)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Message List 자동정리 수"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(164, 29)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Message List"
        '
        'AlarmList
        '
        Me.AlarmList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.AlarmNo, Me.AlarmTime, Me.AlarmLine, Me.AlarmStatus})
        Me.AlarmList.GridLines = True
        Me.AlarmList.HideSelection = False
        Me.AlarmList.Location = New System.Drawing.Point(647, 30)
        Me.AlarmList.Margin = New System.Windows.Forms.Padding(0)
        Me.AlarmList.Name = "AlarmList"
        Me.AlarmList.Size = New System.Drawing.Size(428, 225)
        Me.AlarmList.TabIndex = 16
        Me.AlarmList.UseCompatibleStateImageBehavior = False
        Me.AlarmList.View = System.Windows.Forms.View.Details
        '
        'AlarmNo
        '
        Me.AlarmNo.Text = "No"
        Me.AlarmNo.Width = 30
        '
        'AlarmTime
        '
        Me.AlarmTime.Text = "Time"
        Me.AlarmTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.AlarmTime.Width = 120
        '
        'AlarmLine
        '
        Me.AlarmLine.Text = "Line"
        Me.AlarmLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.AlarmLine.Width = 100
        '
        'AlarmStatus
        '
        Me.AlarmStatus.Text = "Status"
        Me.AlarmStatus.Width = 160
        '
        'AlarmListPanel
        '
        Me.AlarmListPanel.BackColor = System.Drawing.Color.LightBlue
        Me.AlarmListPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AlarmListPanel.Controls.Add(Me.Label3)
        Me.AlarmListPanel.ForeColor = System.Drawing.Color.White
        Me.AlarmListPanel.Location = New System.Drawing.Point(647, 0)
        Me.AlarmListPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.AlarmListPanel.Name = "AlarmListPanel"
        Me.AlarmListPanel.Size = New System.Drawing.Size(428, 30)
        Me.AlarmListPanel.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 29)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Alarm List"
        '
        'ButtonPanel
        '
        Me.ButtonPanel.BackColor = System.Drawing.Color.LightBlue
        Me.ButtonPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ButtonPanel.Controls.Add(Me.Button1)
        Me.ButtonPanel.Controls.Add(Me.btnClose)
        Me.ButtonPanel.Controls.Add(Me.btnMessageClear)
        Me.ButtonPanel.Controls.Add(Me.btnAlarmClear)
        Me.ButtonPanel.Controls.Add(Me.btnSetting)
        Me.ButtonPanel.Location = New System.Drawing.Point(0, 505)
        Me.ButtonPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonPanel.Name = "ButtonPanel"
        Me.ButtonPanel.Size = New System.Drawing.Size(1075, 32)
        Me.ButtonPanel.TabIndex = 18
        '
        'Button1
        '
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(932, 0)
        Me.Button1.Margin = New System.Windows.Forms.Padding(0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(141, 30)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Update 재전송"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Image = Global.Message_Server.My.Resources.Resources.Close
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(340, 0)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(63, 30)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnMessageClear
        '
        Me.btnMessageClear.Image = Global.Message_Server.My.Resources.Resources.mail2_message
        Me.btnMessageClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMessageClear.Location = New System.Drawing.Point(199, 0)
        Me.btnMessageClear.Margin = New System.Windows.Forms.Padding(0)
        Me.btnMessageClear.Name = "btnMessageClear"
        Me.btnMessageClear.Size = New System.Drawing.Size(141, 30)
        Me.btnMessageClear.TabIndex = 2
        Me.btnMessageClear.Text = "Message List Clear"
        Me.btnMessageClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMessageClear.UseVisualStyleBackColor = True
        '
        'btnAlarmClear
        '
        Me.btnAlarmClear.Image = Global.Message_Server.My.Resources.Resources.alarm
        Me.btnAlarmClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAlarmClear.Location = New System.Drawing.Point(71, 0)
        Me.btnAlarmClear.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAlarmClear.Name = "btnAlarmClear"
        Me.btnAlarmClear.Size = New System.Drawing.Size(128, 30)
        Me.btnAlarmClear.TabIndex = 1
        Me.btnAlarmClear.Text = "Alaram List Clear"
        Me.btnAlarmClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAlarmClear.UseVisualStyleBackColor = True
        '
        'btnSetting
        '
        Me.btnSetting.Image = Global.Message_Server.My.Resources.Resources.settings
        Me.btnSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSetting.Location = New System.Drawing.Point(0, 0)
        Me.btnSetting.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(71, 30)
        Me.btnSetting.TabIndex = 0
        Me.btnSetting.Text = "Setting"
        Me.btnSetting.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSetting.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.NIMenu
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Message Server"
        Me.NotifyIcon1.Visible = True
        '
        'NIMenu
        '
        Me.NIMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnMinimum, Me.mnExit})
        Me.NIMenu.Name = "NIMenu"
        Me.NIMenu.Size = New System.Drawing.Size(111, 48)
        '
        'mnMinimum
        '
        Me.mnMinimum.Name = "mnMinimum"
        Me.mnMinimum.Size = New System.Drawing.Size(110, 22)
        Me.mnMinimum.Text = "최소화"
        '
        'mnExit
        '
        Me.mnExit.Name = "mnExit"
        Me.mnExit.Size = New System.Drawing.Size(110, 22)
        Me.mnExit.Text = "종료"
        '
        'Timer1
        '
        '
        'MainForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1074, 537)
        Me.Controls.Add(Me.ButtonPanel)
        Me.Controls.Add(Me.AlarmList)
        Me.Controls.Add(Me.AlarmListPanel)
        Me.Controls.Add(Me.MessageList)
        Me.Controls.Add(Me.MessageListPanel)
        Me.Controls.Add(Me.ClientList)
        Me.Controls.Add(Me.ClientListPanel)
        Me.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(30, 20)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Message Server"
        Me.ClientListPanel.ResumeLayout(False)
        Me.ClientListPanel.PerformLayout()
        Me.MessageListPanel.ResumeLayout(False)
        Me.MessageListPanel.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AlarmListPanel.ResumeLayout(False)
        Me.AlarmListPanel.PerformLayout()
        Me.ButtonPanel.ResumeLayout(False)
        Me.NIMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ClientList As System.Windows.Forms.ListView
    Friend WithEvents JoinTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents IPPort As System.Windows.Forms.ColumnHeader
    Friend WithEvents Line As System.Windows.Forms.ColumnHeader
    Friend WithEvents LineCode As System.Windows.Forms.ColumnHeader
    Friend WithEvents Response As System.Windows.Forms.ColumnHeader
    Friend WithEvents ClientCheckingTimer As System.Windows.Forms.Timer
    Friend WithEvents ClientRemoveTimer As System.Windows.Forms.Timer
    Friend WithEvents ClientListPanel As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MessageList As System.Windows.Forms.ListView
    Friend WithEvents ListNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListSender As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListMemo As System.Windows.Forms.ColumnHeader
    Friend WithEvents MessageListPanel As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AlarmList As System.Windows.Forms.ListView
    Friend WithEvents AlarmNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents AlarmTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents AlarmLine As System.Windows.Forms.ColumnHeader
    Friend WithEvents AlarmStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents AlarmListPanel As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ButtonPanel As System.Windows.Forms.Panel
    Friend WithEvents btnSetting As System.Windows.Forms.Button
    Friend WithEvents btnMessageClear As System.Windows.Forms.Button
    Friend WithEvents btnAlarmClear As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents NIMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnMinimum As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label4 As Label
End Class
