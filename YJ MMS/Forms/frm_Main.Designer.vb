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
        Me.btn_PartsManager = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btn_Material_In_Add = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_Module_In_Add = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_Lot_Residence_Time = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_Lot_Total_Information = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_Material_Lot_Information = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_Material_Total_Information = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_OMS_WIP_Data = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
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
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnHome, Me.btnSetting, Me.ToolStripSeparator1, Me.btn_PartsManager})
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
        'btn_PartsManager
        '
        Me.btn_PartsManager.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn_PartsManager.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_Material_In_Add, Me.btn_Module_In_Add, Me.ToolStripSeparator5, Me.btn_Lot_Residence_Time, Me.btn_Lot_Total_Information, Me.ToolStripSeparator7, Me.btn_Material_Lot_Information, Me.ToolStripMenuItem1, Me.btn_Material_Total_Information, Me.ToolStripSeparator2, Me.btn_OMS_WIP_Data})
        Me.btn_PartsManager.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btn_PartsManager.Image = CType(resources.GetObject("btn_PartsManager.Image"), System.Drawing.Image)
        Me.btn_PartsManager.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_PartsManager.Name = "btn_PartsManager"
        Me.btn_PartsManager.Size = New System.Drawing.Size(99, 28)
        Me.btn_PartsManager.Text = "입고 / 재공"
        '
        'btn_Material_In_Add
        '
        Me.btn_Material_In_Add.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.btn_Material_In_Add.Name = "btn_Material_In_Add"
        Me.btn_Material_In_Add.Size = New System.Drawing.Size(219, 22)
        Me.btn_Material_In_Add.Text = "자재 입고 등록"
        '
        'btn_Module_In_Add
        '
        Me.btn_Module_In_Add.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.btn_Module_In_Add.Name = "btn_Module_In_Add"
        Me.btn_Module_In_Add.Size = New System.Drawing.Size(219, 22)
        Me.btn_Module_In_Add.Text = "Module / Comp 입고 등록"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(216, 6)
        '
        'btn_Lot_Residence_Time
        '
        Me.btn_Lot_Residence_Time.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.btn_Lot_Residence_Time.Name = "btn_Lot_Residence_Time"
        Me.btn_Lot_Residence_Time.Size = New System.Drawing.Size(219, 22)
        Me.btn_Lot_Residence_Time.Text = "Lot 정체일(현장출고 후)"
        '
        'btn_Lot_Total_Information
        '
        Me.btn_Lot_Total_Information.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.btn_Lot_Total_Information.Name = "btn_Lot_Total_Information"
        Me.btn_Lot_Total_Information.Size = New System.Drawing.Size(219, 22)
        Me.btn_Lot_Total_Information.Text = "Module Lot 정보보기"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(216, 6)
        '
        'btn_Material_Lot_Information
        '
        Me.btn_Material_Lot_Information.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.btn_Material_Lot_Information.Name = "btn_Material_Lot_Information"
        Me.btn_Material_Lot_Information.Size = New System.Drawing.Size(219, 22)
        Me.btn_Material_Lot_Information.Text = "자재 Lot별 정보보기"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(219, 22)
        Me.ToolStripMenuItem1.Text = "자재 Part No.별 정보보기"
        '
        'btn_Material_Total_Information
        '
        Me.btn_Material_Total_Information.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.btn_Material_Total_Information.Name = "btn_Material_Total_Information"
        Me.btn_Material_Total_Information.Size = New System.Drawing.Size(219, 22)
        Me.btn_Material_Total_Information.Text = "자재 종합정보"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(216, 6)
        '
        'btn_OMS_WIP_Data
        '
        Me.btn_OMS_WIP_Data.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.btn_OMS_WIP_Data.Name = "btn_OMS_WIP_Data"
        Me.btn_OMS_WIP_Data.Size = New System.Drawing.Size(219, 22)
        Me.btn_OMS_WIP_Data.Text = "OMS 재공데이터 생성"
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
    Friend WithEvents btn_PartsManager As ToolStripDropDownButton
    Friend WithEvents btn_Module_In_Add As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btn_OMS_WIP_Data As ToolStripMenuItem
    Friend WithEvents btn_Material_In_Add As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btn_Lot_Total_Information As ToolStripMenuItem
    Friend WithEvents btn_Material_Lot_Information As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents btn_Material_Total_Information As ToolStripMenuItem
    Friend WithEvents btnSetting As ToolStripDropDownButton
    Friend WithEvents btn_SQLConn As ToolStripMenuItem
    Friend WithEvents btn_CodeManager As ToolStripMenuItem
    Friend WithEvents btn_UserManager As ToolStripMenuItem
    Friend WithEvents btn_PrinterSetting As ToolStripMenuItem
    Friend WithEvents btn_PGUpdate As ToolStripMenuItem
    Friend WithEvents pgbMain As ToolStripProgressBar
    Friend WithEvents Timer1 As Timer
    Friend WithEvents btn_Lot_Residence_Time As ToolStripMenuItem
End Class
