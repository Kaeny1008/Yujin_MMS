<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Main
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Main))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.lb_LoginID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pgbMain = New System.Windows.Forms.ToolStripProgressBar()
        Me.lb_Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.btnHome = New System.Windows.Forms.ToolStripButton()
        Me.btnSetting = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btn_SQLConn = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_CodeManager = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_UserManager = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_PrinterSetting = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_PGUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_BasicInformation = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btn_CustomerMNG = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_CustomerResistration = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_ModelMNG = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_ModelResistration = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btn_ModelDocument = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip.Size = New System.Drawing.Size(1123, 24)
        Me.MenuStrip.TabIndex = 11
        Me.MenuStrip.Text = "MenuStrip"
        Me.MenuStrip.Visible = False
        '
        'StatusStrip
        '
        Me.StatusStrip.BackColor = System.Drawing.SystemColors.Control
        Me.StatusStrip.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lb_LoginID, Me.pgbMain, Me.lb_Status})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 713)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip.Size = New System.Drawing.Size(1123, 35)
        Me.StatusStrip.TabIndex = 14
        Me.StatusStrip.Text = "StatusStrip"
        '
        'lb_LoginID
        '
        Me.lb_LoginID.AutoSize = False
        Me.lb_LoginID.Name = "lb_LoginID"
        Me.lb_LoginID.Size = New System.Drawing.Size(300, 30)
        Me.lb_LoginID.Text = "Login ID : "
        Me.lb_LoginID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pgbMain
        '
        Me.pgbMain.Name = "pgbMain"
        Me.pgbMain.Size = New System.Drawing.Size(100, 29)
        Me.pgbMain.Visible = False
        '
        'lb_Status
        '
        Me.lb_Status.AutoSize = False
        Me.lb_Status.Name = "lb_Status"
        Me.lb_Status.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lb_Status.Size = New System.Drawing.Size(806, 30)
        Me.lb_Status.Spring = True
        Me.lb_Status.Text = "lb_Status"
        Me.lb_Status.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStrip
        '
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnHome, Me.btnSetting, Me.ToolStripSeparator1, Me.btn_BasicInformation})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1123, 31)
        Me.ToolStrip.TabIndex = 13
        Me.ToolStrip.Text = "ToolStrip"
        '
        'btnHome
        '
        Me.btnHome.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnHome.Image = Global.YJ_MMS.My.Resources.Resources.home
        Me.btnHome.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(80, 28)
        Me.btnHome.Text = "Home"
        '
        'btnSetting
        '
        Me.btnSetting.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_SQLConn, Me.btn_CodeManager, Me.btn_UserManager, Me.btn_PrinterSetting, Me.btn_PGUpdate})
        Me.btnSetting.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnSetting.Image = Global.YJ_MMS.My.Resources.Resources.sitemap
        Me.btnSetting.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(76, 28)
        Me.btnSetting.Text = "설정"
        '
        'btn_SQLConn
        '
        Me.btn_SQLConn.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.btn_SQLConn.Name = "btn_SQLConn"
        Me.btn_SQLConn.Size = New System.Drawing.Size(206, 22)
        Me.btn_SQLConn.Text = "SQL Connection Setting"
        '
        'btn_CodeManager
        '
        Me.btn_CodeManager.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.btn_CodeManager.Name = "btn_CodeManager"
        Me.btn_CodeManager.Size = New System.Drawing.Size(206, 22)
        Me.btn_CodeManager.Text = "Code 관리"
        '
        'btn_UserManager
        '
        Me.btn_UserManager.Enabled = False
        Me.btn_UserManager.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.btn_UserManager.Name = "btn_UserManager"
        Me.btn_UserManager.Size = New System.Drawing.Size(206, 22)
        Me.btn_UserManager.Text = "사용자 관리"
        '
        'btn_PrinterSetting
        '
        Me.btn_PrinterSetting.Enabled = False
        Me.btn_PrinterSetting.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.btn_PrinterSetting.Name = "btn_PrinterSetting"
        Me.btn_PrinterSetting.Size = New System.Drawing.Size(206, 22)
        Me.btn_PrinterSetting.Text = "라벨 프린터 설정"
        '
        'btn_PGUpdate
        '
        Me.btn_PGUpdate.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.btn_PGUpdate.Name = "btn_PGUpdate"
        Me.btn_PGUpdate.Size = New System.Drawing.Size(206, 22)
        Me.btn_PGUpdate.Text = "프로그램 파일 Upload"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'btn_BasicInformation
        '
        Me.btn_BasicInformation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn_BasicInformation.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_CustomerMNG, Me.btn_ModelMNG})
        Me.btn_BasicInformation.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btn_BasicInformation.Image = CType(resources.GetObject("btn_BasicInformation.Image"), System.Drawing.Image)
        Me.btn_BasicInformation.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_BasicInformation.Name = "btn_BasicInformation"
        Me.btn_BasicInformation.Size = New System.Drawing.Size(117, 28)
        Me.btn_BasicInformation.Text = "기초정보 관리"
        '
        'btn_CustomerMNG
        '
        Me.btn_CustomerMNG.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_CustomerResistration})
        Me.btn_CustomerMNG.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.btn_CustomerMNG.Name = "btn_CustomerMNG"
        Me.btn_CustomerMNG.Size = New System.Drawing.Size(180, 22)
        Me.btn_CustomerMNG.Text = "고객사 관리"
        '
        'btn_CustomerResistration
        '
        Me.btn_CustomerResistration.Name = "btn_CustomerResistration"
        Me.btn_CustomerResistration.Size = New System.Drawing.Size(138, 22)
        Me.btn_CustomerResistration.Text = "고객사 등록"
        '
        'btn_ModelMNG
        '
        Me.btn_ModelMNG.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_ModelResistration, Me.btn_ModelDocument})
        Me.btn_ModelMNG.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.btn_ModelMNG.Name = "btn_ModelMNG"
        Me.btn_ModelMNG.Size = New System.Drawing.Size(180, 22)
        Me.btn_ModelMNG.Text = "모델 관리"
        '
        'btn_ModelResistration
        '
        Me.btn_ModelResistration.Name = "btn_ModelResistration"
        Me.btn_ModelResistration.Size = New System.Drawing.Size(180, 22)
        Me.btn_ModelResistration.Text = "모델 등록"
        '
        'btn_ModelDocument
        '
        Me.btn_ModelDocument.Name = "btn_ModelDocument"
        Me.btn_ModelDocument.Size = New System.Drawing.Size(180, 22)
        Me.btn_ModelDocument.Text = "모델별 자료"
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1123, 748)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "frm_Main"
        Me.Text = "Yujin Manufacturing Management System"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents lb_LoginID As ToolStripStatusLabel
    Friend WithEvents lb_Status As ToolStripStatusLabel
    Friend WithEvents ToolStrip As ToolStrip
    Friend WithEvents btnHome As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btn_BasicInformation As ToolStripDropDownButton
    Friend WithEvents btnSetting As ToolStripDropDownButton
    Friend WithEvents btn_SQLConn As ToolStripMenuItem
    Friend WithEvents btn_CodeManager As ToolStripMenuItem
    Friend WithEvents btn_UserManager As ToolStripMenuItem
    Friend WithEvents btn_PrinterSetting As ToolStripMenuItem
    Friend WithEvents btn_PGUpdate As ToolStripMenuItem
    Friend WithEvents pgbMain As ToolStripProgressBar
    Friend WithEvents Timer1 As Timer
    Friend WithEvents btn_CustomerMNG As ToolStripMenuItem
    Friend WithEvents btn_ModelMNG As ToolStripMenuItem
    Friend WithEvents btn_CustomerResistration As ToolStripMenuItem
    Friend WithEvents btn_ModelResistration As ToolStripMenuItem
    Friend WithEvents btn_ModelDocument As ToolStripMenuItem
End Class
