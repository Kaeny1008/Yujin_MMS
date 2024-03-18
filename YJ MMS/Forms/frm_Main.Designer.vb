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
        Me.BTN_LabelPrinterSetting = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_PGUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_BasicInformation = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btn_CustomerMNG = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_CustomerResistration = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_ModelMNG = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_ModelResistration = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_ModelDocument = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_PartCodeManager = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_CustomerPartCode = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.BTN_OrderRegistration = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_OrderModify = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Warehousing_Document = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Material_Warehousing_List = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Material_Warehousing = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_MaterialWarehousing_History = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Material_CheckRequirements = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.BTN_ProductionPlan = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnHome, Me.btnSetting, Me.ToolStripSeparator1, Me.btn_BasicInformation, Me.ToolStripSplitButton1, Me.ToolStripDropDownButton1, Me.ToolStripDropDownButton2})
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
        Me.btnSetting.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_SQLConn, Me.btn_CodeManager, Me.btn_UserManager, Me.BTN_LabelPrinterSetting, Me.btn_PGUpdate})
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
        'BTN_LabelPrinterSetting
        '
        Me.BTN_LabelPrinterSetting.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.BTN_LabelPrinterSetting.Name = "BTN_LabelPrinterSetting"
        Me.BTN_LabelPrinterSetting.Size = New System.Drawing.Size(206, 22)
        Me.BTN_LabelPrinterSetting.Text = "라벨 프린터 설정"
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
        Me.btn_BasicInformation.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_CustomerMNG, Me.btn_ModelMNG, Me.BTN_PartCodeManager})
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
        Me.btn_CustomerMNG.Size = New System.Drawing.Size(152, 22)
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
        Me.btn_ModelMNG.Size = New System.Drawing.Size(152, 22)
        Me.btn_ModelMNG.Text = "모델 관리"
        '
        'btn_ModelResistration
        '
        Me.btn_ModelResistration.Name = "btn_ModelResistration"
        Me.btn_ModelResistration.Size = New System.Drawing.Size(166, 22)
        Me.btn_ModelResistration.Text = "모델 등록"
        '
        'btn_ModelDocument
        '
        Me.btn_ModelDocument.Name = "btn_ModelDocument"
        Me.btn_ModelDocument.Size = New System.Drawing.Size(166, 22)
        Me.btn_ModelDocument.Text = "모델별 자료 등록"
        '
        'BTN_PartCodeManager
        '
        Me.BTN_PartCodeManager.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_CustomerPartCode})
        Me.BTN_PartCodeManager.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.BTN_PartCodeManager.Name = "BTN_PartCodeManager"
        Me.BTN_PartCodeManager.Size = New System.Drawing.Size(152, 22)
        Me.BTN_PartCodeManager.Text = "자재코드 관리"
        '
        'BTN_CustomerPartCode
        '
        Me.BTN_CustomerPartCode.Name = "BTN_CustomerPartCode"
        Me.BTN_CustomerPartCode.Size = New System.Drawing.Size(190, 22)
        Me.BTN_CustomerPartCode.Text = "고객사 자재코드 관리"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_OrderRegistration, Me.BTN_OrderModify})
        Me.ToolStripSplitButton1.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(82, 28)
        Me.ToolStripSplitButton1.Text = "주문관리"
        '
        'BTN_OrderRegistration
        '
        Me.BTN_OrderRegistration.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.BTN_OrderRegistration.Name = "BTN_OrderRegistration"
        Me.BTN_OrderRegistration.Size = New System.Drawing.Size(165, 22)
        Me.BTN_OrderRegistration.Text = "주문 접수"
        '
        'BTN_OrderModify
        '
        Me.BTN_OrderModify.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.BTN_OrderModify.Name = "BTN_OrderModify"
        Me.BTN_OrderModify.Size = New System.Drawing.Size(165, 22)
        Me.BTN_OrderModify.Text = "주문 확인 / 변경"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox1, Me.BTN_Material_CheckRequirements})
        Me.ToolStripDropDownButton1.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(82, 28)
        Me.ToolStripDropDownButton1.Text = "자재관리"
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Warehousing_Document, Me.BTN_Material_Warehousing_List, Me.BTN_Material_Warehousing, Me.BTN_MaterialWarehousing_History})
        Me.ToolStripComboBox1.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripComboBox1.Text = "입고"
        Me.ToolStripComboBox1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BTN_Warehousing_Document
        '
        Me.BTN_Warehousing_Document.Name = "BTN_Warehousing_Document"
        Me.BTN_Warehousing_Document.Size = New System.Drawing.Size(182, 22)
        Me.BTN_Warehousing_Document.Text = "입고 리스트 등록"
        '
        'BTN_Material_Warehousing_List
        '
        Me.BTN_Material_Warehousing_List.Name = "BTN_Material_Warehousing_List"
        Me.BTN_Material_Warehousing_List.Size = New System.Drawing.Size(182, 22)
        Me.BTN_Material_Warehousing_List.Text = "입고 등록(라벨발행)"
        '
        'BTN_Material_Warehousing
        '
        Me.BTN_Material_Warehousing.Name = "BTN_Material_Warehousing"
        Me.BTN_Material_Warehousing.Size = New System.Drawing.Size(182, 22)
        Me.BTN_Material_Warehousing.Text = "입고 등록"
        '
        'BTN_MaterialWarehousing_History
        '
        Me.BTN_MaterialWarehousing_History.Name = "BTN_MaterialWarehousing_History"
        Me.BTN_MaterialWarehousing_History.Size = New System.Drawing.Size(182, 22)
        Me.BTN_MaterialWarehousing_History.Text = "입고 현황"
        '
        'BTN_Material_CheckRequirements
        '
        Me.BTN_Material_CheckRequirements.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.BTN_Material_CheckRequirements.Name = "BTN_Material_CheckRequirements"
        Me.BTN_Material_CheckRequirements.Size = New System.Drawing.Size(180, 22)
        Me.BTN_Material_CheckRequirements.Text = "소요량 확인"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_ProductionPlan})
        Me.ToolStripDropDownButton2.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(82, 28)
        Me.ToolStripDropDownButton2.Text = "생산관리"
        '
        'BTN_ProductionPlan
        '
        Me.BTN_ProductionPlan.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.BTN_ProductionPlan.Name = "BTN_ProductionPlan"
        Me.BTN_ProductionPlan.Size = New System.Drawing.Size(180, 22)
        Me.BTN_ProductionPlan.Text = "생산계획 수립"
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
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
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
    Friend WithEvents BTN_LabelPrinterSetting As ToolStripMenuItem
    Friend WithEvents btn_PGUpdate As ToolStripMenuItem
    Friend WithEvents pgbMain As ToolStripProgressBar
    Friend WithEvents Timer1 As Timer
    Friend WithEvents btn_CustomerMNG As ToolStripMenuItem
    Friend WithEvents btn_ModelMNG As ToolStripMenuItem
    Friend WithEvents btn_CustomerResistration As ToolStripMenuItem
    Friend WithEvents btn_ModelResistration As ToolStripMenuItem
    Friend WithEvents btn_ModelDocument As ToolStripMenuItem
    Friend WithEvents BTN_PartCodeManager As ToolStripMenuItem
    Friend WithEvents BTN_CustomerPartCode As ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents ToolStripSplitButton1 As ToolStripDropDownButton
    Friend WithEvents BTN_OrderRegistration As ToolStripMenuItem
    Friend WithEvents BTN_OrderModify As ToolStripMenuItem
    Friend WithEvents ToolStripComboBox1 As ToolStripMenuItem
    Friend WithEvents BTN_Warehousing_Document As ToolStripMenuItem
    Friend WithEvents BTN_Material_Warehousing_List As ToolStripMenuItem
    Friend WithEvents BTN_Material_Warehousing As ToolStripMenuItem
    Friend WithEvents BTN_MaterialWarehousing_History As ToolStripMenuItem
    Friend WithEvents BTN_Material_CheckRequirements As ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton2 As ToolStripDropDownButton
    Friend WithEvents BTN_ProductionPlan As ToolStripMenuItem
End Class
