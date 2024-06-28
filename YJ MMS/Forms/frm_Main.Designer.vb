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
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnHome = New System.Windows.Forms.ToolStripButton()
        Me.btnSetting = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btn_SQLConn = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_CodeManager = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_UserManager = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_LabelPrinterSetting = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_PGUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_BasicInformation = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btn_CustomerMNG = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_CustomerResistration = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_ModelMNG = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_ModelResistration = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_ModelDocument = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Model_Process_Documents = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_PartCodeManager = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_CustomerPartCode = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.BTN_OrderRegistration = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_OrderModify = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Warehousing_Document = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_Material_Warehousing_List = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Material_Warehousing = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_MaterialWarehousing_History = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_Material_Label_Reprint = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_Material_Move = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Material_Transfer = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Material_Return = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_Material_CheckRequirements = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_MaterialStock = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_MRP = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_MaterialCode_Change = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.재고조사ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Material_Stock_Survay_Plan = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Material_Stock_Survay_Input = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Material_Stock_Survay_Result = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.BTN_ProductionPlan = New System.Windows.Forms.ToolStripMenuItem()
        Me.생산현황ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropDownButton3 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.SMD생산ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_SMD_ProductionStart = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_SMD_Inspection = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_MMPS_DeviceData = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_MMPS_History = New System.Windows.Forms.ToolStripMenuItem()
        Me.솔더관리시스템ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_SolderPaste_Warehousing = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_SolderPaste_Use = New System.Windows.Forms.ToolStripMenuItem()
        Me.MetalMask관리ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_MetalMask_Management = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_MetalMask_History = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SMD완료품ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_WSProduction_Start_SMD = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_WSProduction_Start_First = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_WSProduction_Inspection = New System.Windows.Forms.ToolStripMenuItem()
        Me.출하ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_OQC = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_Repair_Management = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_AssyLabelPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropDownButton4 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.BTN_Delivery_Register = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_Delivery_History = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnHome, Me.btnSetting, Me.ToolStripSeparator1, Me.btn_BasicInformation, Me.ToolStripSplitButton1, Me.ToolStripDropDownButton1, Me.ToolStripDropDownButton2, Me.ToolStripSeparator4, Me.ToolStripDropDownButton3, Me.ToolStripSeparator13, Me.ToolStripDropDownButton4})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1123, 31)
        Me.ToolStrip.TabIndex = 13
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 31)
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
        Me.btn_ModelMNG.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_ModelResistration, Me.btn_ModelDocument, Me.BTN_Model_Process_Documents})
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
        Me.btn_ModelDocument.Text = "모델별 기초자료"
        '
        'BTN_Model_Process_Documents
        '
        Me.BTN_Model_Process_Documents.Name = "BTN_Model_Process_Documents"
        Me.BTN_Model_Process_Documents.Size = New System.Drawing.Size(166, 22)
        Me.BTN_Model_Process_Documents.Text = "모델 공정별 자료"
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
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_OrderRegistration, Me.ToolStripSeparator14, Me.BTN_OrderModify})
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
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(162, 6)
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
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox1, Me.ToolStripSeparator2, Me.BTN_Material_Move, Me.ToolStripSeparator12, Me.BTN_Material_CheckRequirements, Me.BTN_MaterialStock, Me.BTN_MRP, Me.ToolStripSeparator8, Me.BTN_MaterialCode_Change, Me.ToolStripSeparator9, Me.재고조사ToolStripMenuItem})
        Me.ToolStripDropDownButton1.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(82, 28)
        Me.ToolStripDropDownButton1.Text = "자재관리"
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Warehousing_Document, Me.ToolStripSeparator6, Me.BTN_Material_Warehousing_List, Me.BTN_Material_Warehousing, Me.ToolStripSeparator7, Me.BTN_MaterialWarehousing_History, Me.ToolStripSeparator11, Me.BTN_Material_Label_Reprint})
        Me.ToolStripComboBox1.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripComboBox1.Text = "입고"
        Me.ToolStripComboBox1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BTN_Warehousing_Document
        '
        Me.BTN_Warehousing_Document.Name = "BTN_Warehousing_Document"
        Me.BTN_Warehousing_Document.Size = New System.Drawing.Size(182, 22)
        Me.BTN_Warehousing_Document.Text = "입고 리스트 등록"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(179, 6)
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
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(179, 6)
        '
        'BTN_MaterialWarehousing_History
        '
        Me.BTN_MaterialWarehousing_History.Name = "BTN_MaterialWarehousing_History"
        Me.BTN_MaterialWarehousing_History.Size = New System.Drawing.Size(182, 22)
        Me.BTN_MaterialWarehousing_History.Text = "입고 현황"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(179, 6)
        '
        'BTN_Material_Label_Reprint
        '
        Me.BTN_Material_Label_Reprint.Name = "BTN_Material_Label_Reprint"
        Me.BTN_Material_Label_Reprint.Size = New System.Drawing.Size(182, 22)
        Me.BTN_Material_Label_Reprint.Text = "라벨 재발행"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(149, 6)
        '
        'BTN_Material_Move
        '
        Me.BTN_Material_Move.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Material_Transfer, Me.BTN_Material_Return})
        Me.BTN_Material_Move.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.BTN_Material_Move.Name = "BTN_Material_Move"
        Me.BTN_Material_Move.Size = New System.Drawing.Size(152, 22)
        Me.BTN_Material_Move.Text = "자재 이동"
        '
        'BTN_Material_Transfer
        '
        Me.BTN_Material_Transfer.Name = "BTN_Material_Transfer"
        Me.BTN_Material_Transfer.Size = New System.Drawing.Size(141, 22)
        Me.BTN_Material_Transfer.Text = "현장 입,출고"
        '
        'BTN_Material_Return
        '
        Me.BTN_Material_Return.Name = "BTN_Material_Return"
        Me.BTN_Material_Return.Size = New System.Drawing.Size(141, 22)
        Me.BTN_Material_Return.Text = "반출"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(149, 6)
        '
        'BTN_Material_CheckRequirements
        '
        Me.BTN_Material_CheckRequirements.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.BTN_Material_CheckRequirements.Name = "BTN_Material_CheckRequirements"
        Me.BTN_Material_CheckRequirements.Size = New System.Drawing.Size(152, 22)
        Me.BTN_Material_CheckRequirements.Text = "소요량 확인"
        '
        'BTN_MaterialStock
        '
        Me.BTN_MaterialStock.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.BTN_MaterialStock.Name = "BTN_MaterialStock"
        Me.BTN_MaterialStock.Size = New System.Drawing.Size(152, 22)
        Me.BTN_MaterialStock.Text = "재고 확인"
        '
        'BTN_MRP
        '
        Me.BTN_MRP.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.BTN_MRP.Name = "BTN_MRP"
        Me.BTN_MRP.Size = New System.Drawing.Size(152, 22)
        Me.BTN_MRP.Text = "소요량 계획"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(149, 6)
        '
        'BTN_MaterialCode_Change
        '
        Me.BTN_MaterialCode_Change.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.BTN_MaterialCode_Change.Name = "BTN_MaterialCode_Change"
        Me.BTN_MaterialCode_Change.Size = New System.Drawing.Size(152, 22)
        Me.BTN_MaterialCode_Change.Text = "품목코드 변경"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(149, 6)
        '
        '재고조사ToolStripMenuItem
        '
        Me.재고조사ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Material_Stock_Survay_Plan, Me.BTN_Material_Stock_Survay_Input, Me.BTN_Material_Stock_Survay_Result})
        Me.재고조사ToolStripMenuItem.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.재고조사ToolStripMenuItem.Name = "재고조사ToolStripMenuItem"
        Me.재고조사ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.재고조사ToolStripMenuItem.Text = "재고조사"
        '
        'BTN_Material_Stock_Survay_Plan
        '
        Me.BTN_Material_Stock_Survay_Plan.Name = "BTN_Material_Stock_Survay_Plan"
        Me.BTN_Material_Stock_Survay_Plan.Size = New System.Drawing.Size(241, 22)
        Me.BTN_Material_Stock_Survay_Plan.Text = "계획수립"
        '
        'BTN_Material_Stock_Survay_Input
        '
        Me.BTN_Material_Stock_Survay_Input.Enabled = False
        Me.BTN_Material_Stock_Survay_Input.Name = "BTN_Material_Stock_Survay_Input"
        Me.BTN_Material_Stock_Survay_Input.Size = New System.Drawing.Size(241, 22)
        Me.BTN_Material_Stock_Survay_Input.Text = "조사결과 입력(사용X PDA활용)"
        Me.BTN_Material_Stock_Survay_Input.Visible = False
        '
        'BTN_Material_Stock_Survay_Result
        '
        Me.BTN_Material_Stock_Survay_Result.Name = "BTN_Material_Stock_Survay_Result"
        Me.BTN_Material_Stock_Survay_Result.Size = New System.Drawing.Size(241, 22)
        Me.BTN_Material_Stock_Survay_Result.Text = "조사결과 확인"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_ProductionPlan, Me.생산현황ToolStripMenuItem})
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
        '생산현황ToolStripMenuItem
        '
        Me.생산현황ToolStripMenuItem.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.생산현황ToolStripMenuItem.Name = "생산현황ToolStripMenuItem"
        Me.생산현황ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.생산현황ToolStripMenuItem.Text = "생산현황"
        '
        'ToolStripDropDownButton3
        '
        Me.ToolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMD생산ToolStripMenuItem, Me.ToolStripMenuItem1, Me.출하ToolStripMenuItem, Me.ToolStripSeparator3, Me.BTN_Repair_Management, Me.ToolStripSeparator10, Me.BTN_AssyLabelPrint})
        Me.ToolStripDropDownButton3.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripDropDownButton3.Image = CType(resources.GetObject("ToolStripDropDownButton3.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton3.Name = "ToolStripDropDownButton3"
        Me.ToolStripDropDownButton3.Size = New System.Drawing.Size(82, 28)
        Me.ToolStripDropDownButton3.Text = "생산공정"
        '
        'SMD생산ToolStripMenuItem
        '
        Me.SMD생산ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_SMD_ProductionStart, Me.BTN_SMD_Inspection, Me.ToolStripSeparator5, Me.ToolStripMenuItem2, Me.솔더관리시스템ToolStripMenuItem, Me.MetalMask관리ToolStripMenuItem})
        Me.SMD생산ToolStripMenuItem.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.SMD생산ToolStripMenuItem.Name = "SMD생산ToolStripMenuItem"
        Me.SMD생산ToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.SMD생산ToolStripMenuItem.Text = "SMD"
        '
        'BTN_SMD_ProductionStart
        '
        Me.BTN_SMD_ProductionStart.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.BTN_SMD_ProductionStart.Name = "BTN_SMD_ProductionStart"
        Me.BTN_SMD_ProductionStart.Size = New System.Drawing.Size(162, 22)
        Me.BTN_SMD_ProductionStart.Text = "생산등록"
        '
        'BTN_SMD_Inspection
        '
        Me.BTN_SMD_Inspection.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.BTN_SMD_Inspection.Name = "BTN_SMD_Inspection"
        Me.BTN_SMD_Inspection.Size = New System.Drawing.Size(162, 22)
        Me.BTN_SMD_Inspection.Text = "검사내역 등록"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(159, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_MMPS_DeviceData, Me.BTN_MMPS_History})
        Me.ToolStripMenuItem2.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(162, 22)
        Me.ToolStripMenuItem2.Text = "오삽방지 시스템"
        '
        'BTN_MMPS_DeviceData
        '
        Me.BTN_MMPS_DeviceData.Name = "BTN_MMPS_DeviceData"
        Me.BTN_MMPS_DeviceData.Size = New System.Drawing.Size(174, 22)
        Me.BTN_MMPS_DeviceData.Text = "Device Data 등록"
        '
        'BTN_MMPS_History
        '
        Me.BTN_MMPS_History.Name = "BTN_MMPS_History"
        Me.BTN_MMPS_History.Size = New System.Drawing.Size(174, 22)
        Me.BTN_MMPS_History.Text = "오삽방지 이력보기"
        '
        '솔더관리시스템ToolStripMenuItem
        '
        Me.솔더관리시스템ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_SolderPaste_Warehousing, Me.BTN_SolderPaste_Use})
        Me.솔더관리시스템ToolStripMenuItem.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.솔더관리시스템ToolStripMenuItem.Name = "솔더관리시스템ToolStripMenuItem"
        Me.솔더관리시스템ToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.솔더관리시스템ToolStripMenuItem.Text = "솔더관리"
        '
        'BTN_SolderPaste_Warehousing
        '
        Me.BTN_SolderPaste_Warehousing.Name = "BTN_SolderPaste_Warehousing"
        Me.BTN_SolderPaste_Warehousing.Size = New System.Drawing.Size(122, 22)
        Me.BTN_SolderPaste_Warehousing.Text = "입고등록"
        '
        'BTN_SolderPaste_Use
        '
        Me.BTN_SolderPaste_Use.Name = "BTN_SolderPaste_Use"
        Me.BTN_SolderPaste_Use.Size = New System.Drawing.Size(122, 22)
        Me.BTN_SolderPaste_Use.Text = "사용등록"
        '
        'MetalMask관리ToolStripMenuItem
        '
        Me.MetalMask관리ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_MetalMask_Management, Me.BTN_MetalMask_History})
        Me.MetalMask관리ToolStripMenuItem.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.MetalMask관리ToolStripMenuItem.Name = "MetalMask관리ToolStripMenuItem"
        Me.MetalMask관리ToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.MetalMask관리ToolStripMenuItem.Text = "MetalMask 관리"
        '
        'BTN_MetalMask_Management
        '
        Me.BTN_MetalMask_Management.Name = "BTN_MetalMask_Management"
        Me.BTN_MetalMask_Management.Size = New System.Drawing.Size(135, 22)
        Me.BTN_MetalMask_Management.Text = "등록 / 관리"
        '
        'BTN_MetalMask_History
        '
        Me.BTN_MetalMask_History.Name = "BTN_MetalMask_History"
        Me.BTN_MetalMask_History.Size = New System.Drawing.Size(135, 22)
        Me.BTN_MetalMask_History.Text = "이력확인"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMD완료품ToolStripMenuItem, Me.BTN_WSProduction_Inspection})
        Me.ToolStripMenuItem1.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(220, 22)
        Me.ToolStripMenuItem1.Text = "Wave / Selective Soldering"
        '
        'SMD완료품ToolStripMenuItem
        '
        Me.SMD완료품ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_WSProduction_Start_SMD, Me.BTN_WSProduction_Start_First})
        Me.SMD완료품ToolStripMenuItem.Name = "SMD완료품ToolStripMenuItem"
        Me.SMD완료품ToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.SMD완료품ToolStripMenuItem.Text = "생산등록"
        '
        'BTN_WSProduction_Start_SMD
        '
        Me.BTN_WSProduction_Start_SMD.Name = "BTN_WSProduction_Start_SMD"
        Me.BTN_WSProduction_Start_SMD.Size = New System.Drawing.Size(138, 22)
        Me.BTN_WSProduction_Start_SMD.Text = "공정 인계품"
        '
        'BTN_WSProduction_Start_First
        '
        Me.BTN_WSProduction_Start_First.Name = "BTN_WSProduction_Start_First"
        Me.BTN_WSProduction_Start_First.Size = New System.Drawing.Size(138, 22)
        Me.BTN_WSProduction_Start_First.Text = "공정 시작품"
        '
        'BTN_WSProduction_Inspection
        '
        Me.BTN_WSProduction_Inspection.Name = "BTN_WSProduction_Inspection"
        Me.BTN_WSProduction_Inspection.Size = New System.Drawing.Size(150, 22)
        Me.BTN_WSProduction_Inspection.Text = "검사내역 등록"
        '
        '출하ToolStripMenuItem
        '
        Me.출하ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_OQC})
        Me.출하ToolStripMenuItem.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.출하ToolStripMenuItem.Name = "출하ToolStripMenuItem"
        Me.출하ToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
        Me.출하ToolStripMenuItem.Text = "출하"
        '
        'BTN_OQC
        '
        Me.BTN_OQC.Name = "BTN_OQC"
        Me.BTN_OQC.Size = New System.Drawing.Size(150, 22)
        Me.BTN_OQC.Text = "출하검사 등록"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(217, 6)
        '
        'BTN_Repair_Management
        '
        Me.BTN_Repair_Management.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.BTN_Repair_Management.Name = "BTN_Repair_Management"
        Me.BTN_Repair_Management.Size = New System.Drawing.Size(220, 22)
        Me.BTN_Repair_Management.Text = "수리내역 등록"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(217, 6)
        '
        'BTN_AssyLabelPrint
        '
        Me.BTN_AssyLabelPrint.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.BTN_AssyLabelPrint.Name = "BTN_AssyLabelPrint"
        Me.BTN_AssyLabelPrint.Size = New System.Drawing.Size(220, 22)
        Me.BTN_AssyLabelPrint.Text = "PCB Ass'y Label 발행"
        '
        'ToolStripDropDownButton4
        '
        Me.ToolStripDropDownButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Delivery_Register, Me.BTN_Delivery_History})
        Me.ToolStripDropDownButton4.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripDropDownButton4.Image = CType(resources.GetObject("ToolStripDropDownButton4.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton4.Name = "ToolStripDropDownButton4"
        Me.ToolStripDropDownButton4.Size = New System.Drawing.Size(82, 28)
        Me.ToolStripDropDownButton4.Text = "납품관리"
        '
        'BTN_Delivery_Register
        '
        Me.BTN_Delivery_Register.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.BTN_Delivery_Register.Name = "BTN_Delivery_Register"
        Me.BTN_Delivery_Register.Size = New System.Drawing.Size(124, 22)
        Me.BTN_Delivery_Register.Text = "납품등록"
        '
        'BTN_Delivery_History
        '
        Me.BTN_Delivery_History.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.BTN_Delivery_History.Name = "BTN_Delivery_History"
        Me.BTN_Delivery_History.Size = New System.Drawing.Size(124, 22)
        Me.BTN_Delivery_History.Text = "납품이력"
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
    Friend WithEvents BTN_MaterialStock As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripDropDownButton3 As ToolStripDropDownButton
    Friend WithEvents SMD생산ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BTN_SMD_ProductionStart As ToolStripMenuItem
    Friend WithEvents BTN_SMD_Inspection As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents BTN_Repair_Management As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents BTN_MMPS_DeviceData As ToolStripMenuItem
    Friend WithEvents BTN_MMPS_History As ToolStripMenuItem
    Friend WithEvents 솔더관리시스템ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MetalMask관리ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents BTN_SolderPaste_Warehousing As ToolStripMenuItem
    Friend WithEvents BTN_SolderPaste_Use As ToolStripMenuItem
    Friend WithEvents BTN_MetalMask_Management As ToolStripMenuItem
    Friend WithEvents BTN_MetalMask_History As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents BTN_MaterialCode_Change As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents 재고조사ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BTN_Material_Stock_Survay_Plan As ToolStripMenuItem
    Friend WithEvents BTN_Material_Stock_Survay_Input As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents BTN_Material_Label_Reprint As ToolStripMenuItem
    Friend WithEvents SMD완료품ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BTN_WSProduction_Start_SMD As ToolStripMenuItem
    Friend WithEvents BTN_WSProduction_Inspection As ToolStripMenuItem
    Friend WithEvents BTN_WSProduction_Start_First As ToolStripMenuItem
    Friend WithEvents BTN_Material_Stock_Survay_Result As ToolStripMenuItem
    Friend WithEvents 출하ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BTN_OQC As ToolStripMenuItem
    Friend WithEvents BTN_Material_Move As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator13 As ToolStripSeparator
    Friend WithEvents ToolStripDropDownButton4 As ToolStripDropDownButton
    Friend WithEvents BTN_Delivery_Register As ToolStripMenuItem
    Friend WithEvents BTN_Delivery_History As ToolStripMenuItem
    Friend WithEvents BTN_Material_Transfer As ToolStripMenuItem
    Friend WithEvents BTN_Material_Return As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents BTN_AssyLabelPrint As ToolStripMenuItem
    Friend WithEvents BTN_MRP As ToolStripMenuItem
    Friend WithEvents BTN_Model_Process_Documents As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator14 As ToolStripSeparator
    Friend WithEvents 생산현황ToolStripMenuItem As ToolStripMenuItem
End Class
