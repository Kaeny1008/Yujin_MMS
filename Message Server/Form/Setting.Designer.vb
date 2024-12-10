<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Setting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Setting))
        Me.gbConnection = New System.Windows.Forms.GroupBox()
        Me.lbRecheckTip = New System.Windows.Forms.Label()
        Me.Recheck = New System.Windows.Forms.TextBox()
        Me.lbReCheck = New System.Windows.Forms.Label()
        Me.lbTimeTip2 = New System.Windows.Forms.Label()
        Me.btnSave1 = New System.Windows.Forms.Button()
        Me.lbTimeTip = New System.Windows.Forms.Label()
        Me.lbPortTip = New System.Windows.Forms.Label()
        Me.Time = New System.Windows.Forms.TextBox()
        Me.lbTime = New System.Windows.Forms.Label()
        Me.Port = New System.Windows.Forms.TextBox()
        Me.lbPort = New System.Windows.Forms.Label()
        Me.gbLineDIO = New System.Windows.Forms.GroupBox()
        Me.btnSave2 = New System.Windows.Forms.Button()
        Me.Line = New System.Windows.Forms.ComboBox()
        Me.IP = New System.Windows.Forms.TextBox()
        Me.lbIP = New System.Windows.Forms.Label()
        Me.lbLine = New System.Windows.Forms.Label()
        Me.gbDBServer = New System.Windows.Forms.GroupBox()
        Me.dbName = New System.Windows.Forms.TextBox()
        Me.lbDBName = New System.Windows.Forms.Label()
        Me.DBID = New System.Windows.Forms.TextBox()
        Me.DBPass = New System.Windows.Forms.TextBox()
        Me.lbDBPassword = New System.Windows.Forms.Label()
        Me.lbDBID = New System.Windows.Forms.Label()
        Me.DBIP = New System.Windows.Forms.TextBox()
        Me.btnSave3 = New System.Windows.Forms.Button()
        Me.DBPort = New System.Windows.Forms.TextBox()
        Me.lbDBPort = New System.Windows.Forms.Label()
        Me.lbDBIP = New System.Windows.Forms.Label()
        Me.gbConnection.SuspendLayout()
        Me.gbLineDIO.SuspendLayout()
        Me.gbDBServer.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbConnection
        '
        Me.gbConnection.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gbConnection.Controls.Add(Me.lbRecheckTip)
        Me.gbConnection.Controls.Add(Me.Recheck)
        Me.gbConnection.Controls.Add(Me.lbReCheck)
        Me.gbConnection.Controls.Add(Me.lbTimeTip2)
        Me.gbConnection.Controls.Add(Me.btnSave1)
        Me.gbConnection.Controls.Add(Me.lbTimeTip)
        Me.gbConnection.Controls.Add(Me.lbPortTip)
        Me.gbConnection.Controls.Add(Me.Time)
        Me.gbConnection.Controls.Add(Me.lbTime)
        Me.gbConnection.Controls.Add(Me.Port)
        Me.gbConnection.Controls.Add(Me.lbPort)
        Me.gbConnection.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.gbConnection.ForeColor = System.Drawing.Color.White
        Me.gbConnection.Location = New System.Drawing.Point(0, 12)
        Me.gbConnection.Margin = New System.Windows.Forms.Padding(0)
        Me.gbConnection.Name = "gbConnection"
        Me.gbConnection.Size = New System.Drawing.Size(492, 151)
        Me.gbConnection.TabIndex = 0
        Me.gbConnection.TabStop = False
        Me.gbConnection.Text = "Connection"
        '
        'lbRecheckTip
        '
        Me.lbRecheckTip.AutoSize = True
        Me.lbRecheckTip.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbRecheckTip.ForeColor = System.Drawing.Color.White
        Me.lbRecheckTip.Location = New System.Drawing.Point(191, 113)
        Me.lbRecheckTip.Margin = New System.Windows.Forms.Padding(0)
        Me.lbRecheckTip.Name = "lbRecheckTip"
        Me.lbRecheckTip.Size = New System.Drawing.Size(174, 12)
        Me.lbRecheckTip.TabIndex = 14
        Me.lbRecheckTip.Text = "※ Client Health Check Numer"
        '
        'Recheck
        '
        Me.Recheck.BackColor = System.Drawing.Color.MediumBlue
        Me.Recheck.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Recheck.ForeColor = System.Drawing.Color.White
        Me.Recheck.Location = New System.Drawing.Point(88, 108)
        Me.Recheck.Margin = New System.Windows.Forms.Padding(0)
        Me.Recheck.Name = "Recheck"
        Me.Recheck.Size = New System.Drawing.Size(100, 22)
        Me.Recheck.TabIndex = 13
        '
        'lbReCheck
        '
        Me.lbReCheck.BackColor = System.Drawing.Color.DarkBlue
        Me.lbReCheck.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbReCheck.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbReCheck.ForeColor = System.Drawing.Color.White
        Me.lbReCheck.Location = New System.Drawing.Point(6, 109)
        Me.lbReCheck.Margin = New System.Windows.Forms.Padding(0)
        Me.lbReCheck.Name = "lbReCheck"
        Me.lbReCheck.Size = New System.Drawing.Size(82, 21)
        Me.lbReCheck.TabIndex = 12
        Me.lbReCheck.Text = "Recheck :"
        Me.lbReCheck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbTimeTip2
        '
        Me.lbTimeTip2.AutoSize = True
        Me.lbTimeTip2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbTimeTip2.ForeColor = System.Drawing.Color.White
        Me.lbTimeTip2.Location = New System.Drawing.Point(191, 93)
        Me.lbTimeTip2.Margin = New System.Windows.Forms.Padding(0)
        Me.lbTimeTip2.Name = "lbTimeTip2"
        Me.lbTimeTip2.Size = New System.Drawing.Size(62, 12)
        Me.lbTimeTip2.TabIndex = 11
        Me.lbTimeTip2.Text = "   (5 ~ 60)"
        '
        'btnSave1
        '
        Me.btnSave1.BackColor = System.Drawing.Color.LightBlue
        Me.btnSave1.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnSave1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSave1.Image = CType(resources.GetObject("btnSave1.Image"), System.Drawing.Image)
        Me.btnSave1.Location = New System.Drawing.Point(369, 11)
        Me.btnSave1.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSave1.Name = "btnSave1"
        Me.btnSave1.Size = New System.Drawing.Size(120, 138)
        Me.btnSave1.TabIndex = 10
        Me.btnSave1.Text = "저장"
        Me.btnSave1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave1.UseVisualStyleBackColor = False
        '
        'lbTimeTip
        '
        Me.lbTimeTip.AutoSize = True
        Me.lbTimeTip.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbTimeTip.ForeColor = System.Drawing.Color.White
        Me.lbTimeTip.Location = New System.Drawing.Point(191, 78)
        Me.lbTimeTip.Margin = New System.Windows.Forms.Padding(0)
        Me.lbTimeTip.Name = "lbTimeTip"
        Me.lbTimeTip.Size = New System.Drawing.Size(165, 12)
        Me.lbTimeTip.TabIndex = 5
        Me.lbTimeTip.Text = "※ Client Health Check Time"
        '
        'lbPortTip
        '
        Me.lbPortTip.AutoSize = True
        Me.lbPortTip.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbPortTip.Location = New System.Drawing.Point(191, 41)
        Me.lbPortTip.Margin = New System.Windows.Forms.Padding(0)
        Me.lbPortTip.Name = "lbPortTip"
        Me.lbPortTip.Size = New System.Drawing.Size(134, 12)
        Me.lbPortTip.TabIndex = 4
        Me.lbPortTip.Text = "※ Server Connect Port"
        '
        'Time
        '
        Me.Time.BackColor = System.Drawing.Color.MediumBlue
        Me.Time.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Time.ForeColor = System.Drawing.Color.White
        Me.Time.Location = New System.Drawing.Point(88, 73)
        Me.Time.Margin = New System.Windows.Forms.Padding(0)
        Me.Time.Name = "Time"
        Me.Time.Size = New System.Drawing.Size(100, 22)
        Me.Time.TabIndex = 3
        '
        'lbTime
        '
        Me.lbTime.BackColor = System.Drawing.Color.DarkBlue
        Me.lbTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbTime.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbTime.ForeColor = System.Drawing.Color.White
        Me.lbTime.Location = New System.Drawing.Point(6, 74)
        Me.lbTime.Margin = New System.Windows.Forms.Padding(0)
        Me.lbTime.Name = "lbTime"
        Me.lbTime.Size = New System.Drawing.Size(82, 21)
        Me.lbTime.TabIndex = 2
        Me.lbTime.Text = "Time :"
        Me.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Port
        '
        Me.Port.BackColor = System.Drawing.Color.MediumBlue
        Me.Port.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Port.ForeColor = System.Drawing.Color.White
        Me.Port.Location = New System.Drawing.Point(88, 36)
        Me.Port.Margin = New System.Windows.Forms.Padding(0)
        Me.Port.Name = "Port"
        Me.Port.Size = New System.Drawing.Size(100, 22)
        Me.Port.TabIndex = 1
        '
        'lbPort
        '
        Me.lbPort.BackColor = System.Drawing.Color.DarkBlue
        Me.lbPort.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbPort.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbPort.ForeColor = System.Drawing.Color.White
        Me.lbPort.Location = New System.Drawing.Point(6, 37)
        Me.lbPort.Margin = New System.Windows.Forms.Padding(0)
        Me.lbPort.Name = "lbPort"
        Me.lbPort.Size = New System.Drawing.Size(82, 21)
        Me.lbPort.TabIndex = 0
        Me.lbPort.Text = "Port :"
        Me.lbPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbLineDIO
        '
        Me.gbLineDIO.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gbLineDIO.Controls.Add(Me.btnSave2)
        Me.gbLineDIO.Controls.Add(Me.Line)
        Me.gbLineDIO.Controls.Add(Me.IP)
        Me.gbLineDIO.Controls.Add(Me.lbIP)
        Me.gbLineDIO.Controls.Add(Me.lbLine)
        Me.gbLineDIO.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.gbLineDIO.ForeColor = System.Drawing.Color.White
        Me.gbLineDIO.Location = New System.Drawing.Point(0, 174)
        Me.gbLineDIO.Margin = New System.Windows.Forms.Padding(0)
        Me.gbLineDIO.Name = "gbLineDIO"
        Me.gbLineDIO.Size = New System.Drawing.Size(492, 85)
        Me.gbLineDIO.TabIndex = 7
        Me.gbLineDIO.TabStop = False
        Me.gbLineDIO.Text = "Line-DIO"
        '
        'btnSave2
        '
        Me.btnSave2.BackColor = System.Drawing.Color.LightBlue
        Me.btnSave2.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnSave2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSave2.Image = CType(resources.GetObject("btnSave2.Image"), System.Drawing.Image)
        Me.btnSave2.Location = New System.Drawing.Point(369, 11)
        Me.btnSave2.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSave2.Name = "btnSave2"
        Me.btnSave2.Size = New System.Drawing.Size(120, 72)
        Me.btnSave2.TabIndex = 9
        Me.btnSave2.Text = "저장"
        Me.btnSave2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave2.UseVisualStyleBackColor = False
        '
        'Line
        '
        Me.Line.BackColor = System.Drawing.Color.MediumBlue
        Me.Line.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Line.ForeColor = System.Drawing.Color.White
        Me.Line.FormattingEnabled = True
        Me.Line.Location = New System.Drawing.Point(88, 25)
        Me.Line.Margin = New System.Windows.Forms.Padding(0)
        Me.Line.Name = "Line"
        Me.Line.Size = New System.Drawing.Size(181, 21)
        Me.Line.TabIndex = 6
        '
        'IP
        '
        Me.IP.BackColor = System.Drawing.Color.MediumBlue
        Me.IP.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.IP.ForeColor = System.Drawing.Color.White
        Me.IP.Location = New System.Drawing.Point(88, 51)
        Me.IP.Margin = New System.Windows.Forms.Padding(0)
        Me.IP.Name = "IP"
        Me.IP.Size = New System.Drawing.Size(181, 22)
        Me.IP.TabIndex = 3
        '
        'lbIP
        '
        Me.lbIP.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbIP.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbIP.ForeColor = System.Drawing.Color.White
        Me.lbIP.Location = New System.Drawing.Point(6, 52)
        Me.lbIP.Margin = New System.Windows.Forms.Padding(0)
        Me.lbIP.Name = "lbIP"
        Me.lbIP.Size = New System.Drawing.Size(263, 21)
        Me.lbIP.TabIndex = 2
        Me.lbIP.Text = "IP :"
        Me.lbIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLine
        '
        Me.lbLine.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lbLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbLine.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbLine.ForeColor = System.Drawing.Color.White
        Me.lbLine.Location = New System.Drawing.Point(6, 25)
        Me.lbLine.Margin = New System.Windows.Forms.Padding(0)
        Me.lbLine.Name = "lbLine"
        Me.lbLine.Size = New System.Drawing.Size(263, 21)
        Me.lbLine.TabIndex = 0
        Me.lbLine.Text = "Line :"
        Me.lbLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbDBServer
        '
        Me.gbDBServer.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gbDBServer.Controls.Add(Me.dbName)
        Me.gbDBServer.Controls.Add(Me.lbDBName)
        Me.gbDBServer.Controls.Add(Me.DBID)
        Me.gbDBServer.Controls.Add(Me.DBPass)
        Me.gbDBServer.Controls.Add(Me.lbDBPassword)
        Me.gbDBServer.Controls.Add(Me.lbDBID)
        Me.gbDBServer.Controls.Add(Me.DBIP)
        Me.gbDBServer.Controls.Add(Me.btnSave3)
        Me.gbDBServer.Controls.Add(Me.DBPort)
        Me.gbDBServer.Controls.Add(Me.lbDBPort)
        Me.gbDBServer.Controls.Add(Me.lbDBIP)
        Me.gbDBServer.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.gbDBServer.ForeColor = System.Drawing.Color.White
        Me.gbDBServer.Location = New System.Drawing.Point(0, 270)
        Me.gbDBServer.Margin = New System.Windows.Forms.Padding(0)
        Me.gbDBServer.Name = "gbDBServer"
        Me.gbDBServer.Size = New System.Drawing.Size(492, 168)
        Me.gbDBServer.TabIndex = 10
        Me.gbDBServer.TabStop = False
        Me.gbDBServer.Text = "DB Server"
        '
        'dbName
        '
        Me.dbName.BackColor = System.Drawing.Color.MediumBlue
        Me.dbName.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.dbName.ForeColor = System.Drawing.Color.White
        Me.dbName.Location = New System.Drawing.Point(95, 135)
        Me.dbName.Margin = New System.Windows.Forms.Padding(0)
        Me.dbName.Name = "dbName"
        Me.dbName.Size = New System.Drawing.Size(181, 22)
        Me.dbName.TabIndex = 16
        '
        'lbDBName
        '
        Me.lbDBName.BackColor = System.Drawing.Color.DarkBlue
        Me.lbDBName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbDBName.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbDBName.ForeColor = System.Drawing.Color.White
        Me.lbDBName.Location = New System.Drawing.Point(6, 136)
        Me.lbDBName.Margin = New System.Windows.Forms.Padding(0)
        Me.lbDBName.Name = "lbDBName"
        Me.lbDBName.Size = New System.Drawing.Size(263, 21)
        Me.lbDBName.TabIndex = 15
        Me.lbDBName.Text = "DB :"
        Me.lbDBName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DBID
        '
        Me.DBID.BackColor = System.Drawing.Color.MediumBlue
        Me.DBID.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.DBID.ForeColor = System.Drawing.Color.White
        Me.DBID.Location = New System.Drawing.Point(95, 80)
        Me.DBID.Margin = New System.Windows.Forms.Padding(0)
        Me.DBID.Name = "DBID"
        Me.DBID.Size = New System.Drawing.Size(181, 22)
        Me.DBID.TabIndex = 14
        '
        'DBPass
        '
        Me.DBPass.BackColor = System.Drawing.Color.MediumBlue
        Me.DBPass.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.DBPass.ForeColor = System.Drawing.Color.White
        Me.DBPass.Location = New System.Drawing.Point(95, 107)
        Me.DBPass.Margin = New System.Windows.Forms.Padding(0)
        Me.DBPass.Name = "DBPass"
        Me.DBPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.DBPass.Size = New System.Drawing.Size(181, 22)
        Me.DBPass.TabIndex = 13
        '
        'lbDBPassword
        '
        Me.lbDBPassword.BackColor = System.Drawing.Color.DarkBlue
        Me.lbDBPassword.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbDBPassword.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbDBPassword.ForeColor = System.Drawing.Color.White
        Me.lbDBPassword.Location = New System.Drawing.Point(6, 108)
        Me.lbDBPassword.Margin = New System.Windows.Forms.Padding(0)
        Me.lbDBPassword.Name = "lbDBPassword"
        Me.lbDBPassword.Size = New System.Drawing.Size(263, 21)
        Me.lbDBPassword.TabIndex = 12
        Me.lbDBPassword.Text = "Password :"
        Me.lbDBPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbDBID
        '
        Me.lbDBID.BackColor = System.Drawing.Color.DarkBlue
        Me.lbDBID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbDBID.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbDBID.ForeColor = System.Drawing.Color.White
        Me.lbDBID.Location = New System.Drawing.Point(6, 81)
        Me.lbDBID.Margin = New System.Windows.Forms.Padding(0)
        Me.lbDBID.Name = "lbDBID"
        Me.lbDBID.Size = New System.Drawing.Size(263, 21)
        Me.lbDBID.TabIndex = 11
        Me.lbDBID.Text = "ID :"
        Me.lbDBID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DBIP
        '
        Me.DBIP.BackColor = System.Drawing.Color.MediumBlue
        Me.DBIP.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.DBIP.ForeColor = System.Drawing.Color.White
        Me.DBIP.Location = New System.Drawing.Point(95, 24)
        Me.DBIP.Margin = New System.Windows.Forms.Padding(0)
        Me.DBIP.Name = "DBIP"
        Me.DBIP.Size = New System.Drawing.Size(181, 22)
        Me.DBIP.TabIndex = 10
        '
        'btnSave3
        '
        Me.btnSave3.BackColor = System.Drawing.Color.LightBlue
        Me.btnSave3.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnSave3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSave3.Image = CType(resources.GetObject("btnSave3.Image"), System.Drawing.Image)
        Me.btnSave3.Location = New System.Drawing.Point(369, 11)
        Me.btnSave3.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSave3.Name = "btnSave3"
        Me.btnSave3.Size = New System.Drawing.Size(120, 155)
        Me.btnSave3.TabIndex = 9
        Me.btnSave3.Text = "저장"
        Me.btnSave3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave3.UseVisualStyleBackColor = False
        '
        'DBPort
        '
        Me.DBPort.BackColor = System.Drawing.Color.MediumBlue
        Me.DBPort.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.DBPort.ForeColor = System.Drawing.Color.White
        Me.DBPort.Location = New System.Drawing.Point(95, 51)
        Me.DBPort.Margin = New System.Windows.Forms.Padding(0)
        Me.DBPort.Name = "DBPort"
        Me.DBPort.Size = New System.Drawing.Size(181, 22)
        Me.DBPort.TabIndex = 3
        '
        'lbDBPort
        '
        Me.lbDBPort.BackColor = System.Drawing.Color.DarkBlue
        Me.lbDBPort.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbDBPort.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbDBPort.ForeColor = System.Drawing.Color.White
        Me.lbDBPort.Location = New System.Drawing.Point(6, 52)
        Me.lbDBPort.Margin = New System.Windows.Forms.Padding(0)
        Me.lbDBPort.Name = "lbDBPort"
        Me.lbDBPort.Size = New System.Drawing.Size(263, 21)
        Me.lbDBPort.TabIndex = 2
        Me.lbDBPort.Text = "Port :"
        Me.lbDBPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbDBIP
        '
        Me.lbDBIP.BackColor = System.Drawing.Color.DarkBlue
        Me.lbDBIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbDBIP.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbDBIP.ForeColor = System.Drawing.Color.White
        Me.lbDBIP.Location = New System.Drawing.Point(6, 25)
        Me.lbDBIP.Margin = New System.Windows.Forms.Padding(0)
        Me.lbDBIP.Name = "lbDBIP"
        Me.lbDBIP.Size = New System.Drawing.Size(263, 21)
        Me.lbDBIP.TabIndex = 0
        Me.lbDBIP.Text = "IP :"
        Me.lbDBIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Setting
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(493, 442)
        Me.Controls.Add(Me.gbDBServer)
        Me.Controls.Add(Me.gbLineDIO)
        Me.Controls.Add(Me.gbConnection)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Setting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setting"
        Me.gbConnection.ResumeLayout(False)
        Me.gbConnection.PerformLayout()
        Me.gbLineDIO.ResumeLayout(False)
        Me.gbLineDIO.PerformLayout()
        Me.gbDBServer.ResumeLayout(False)
        Me.gbDBServer.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbConnection As System.Windows.Forms.GroupBox
    Friend WithEvents Port As System.Windows.Forms.TextBox
    Friend WithEvents lbPort As System.Windows.Forms.Label
    Friend WithEvents lbPortTip As System.Windows.Forms.Label
    Friend WithEvents Time As System.Windows.Forms.TextBox
    Friend WithEvents lbTime As System.Windows.Forms.Label
    Friend WithEvents lbTimeTip As System.Windows.Forms.Label
    Friend WithEvents gbLineDIO As System.Windows.Forms.GroupBox
    Friend WithEvents IP As System.Windows.Forms.TextBox
    Friend WithEvents lbIP As System.Windows.Forms.Label
    Friend WithEvents lbLine As System.Windows.Forms.Label
    Friend WithEvents Line As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave2 As System.Windows.Forms.Button
    Friend WithEvents btnSave1 As System.Windows.Forms.Button
    Friend WithEvents lbTimeTip2 As System.Windows.Forms.Label
    Friend WithEvents lbRecheckTip As System.Windows.Forms.Label
    Friend WithEvents Recheck As System.Windows.Forms.TextBox
    Friend WithEvents lbReCheck As System.Windows.Forms.Label
    Friend WithEvents gbDBServer As System.Windows.Forms.GroupBox
    Friend WithEvents DBIP As System.Windows.Forms.TextBox
    Friend WithEvents btnSave3 As System.Windows.Forms.Button
    Friend WithEvents DBPort As System.Windows.Forms.TextBox
    Friend WithEvents lbDBPort As System.Windows.Forms.Label
    Friend WithEvents lbDBIP As System.Windows.Forms.Label
    Friend WithEvents DBID As System.Windows.Forms.TextBox
    Friend WithEvents DBPass As System.Windows.Forms.TextBox
    Friend WithEvents lbDBPassword As System.Windows.Forms.Label
    Friend WithEvents lbDBID As System.Windows.Forms.Label
    Friend WithEvents dbName As System.Windows.Forms.TextBox
    Friend WithEvents lbDBName As System.Windows.Forms.Label
End Class
