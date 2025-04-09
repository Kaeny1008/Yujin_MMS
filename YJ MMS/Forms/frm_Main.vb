Imports System.ComponentModel
Imports System.IO
Imports System.Threading
Imports MySql.Data.MySqlClient

Public Class frm_Main

    Public form_name As Form
    Public discard_Alarm As Boolean = False
    Dim thread_FileDelete As Thread
    Public material_FIFO As Boolean = False

    Private Sub frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not loginID.Equals("Admin") Then
            registryEdit.WriteRegKey("software\yujin", "server.ip", "192.168.0.174")
            registryEdit.WriteRegKey("software\yujin", "messageserver.ip", "192.168.0.173")
            serverIP = registryEdit.ReadRegKey("software\yujin", "server.ip", "192.168.0.174")
            messageIP = registryEdit.ReadRegKey("software\yujin", "messageserver.ip", "192.168.0.173")
            '########### 나중에 삭제해야함. 강제로 IP변경하기 위해....
        End If

        Me.Text = "Yujin Manufacturing Management System (Build " &
            System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() &
            ")"

        lb_LoginID.Text = lb_LoginID.Text & loginID

        frm_Sub.MdiParent = Me
        frm_Sub.Show()

        lb_Status.Text = String.Empty

        Me.WindowState = FormWindowState.Maximized

        UpdatePG_Run()

        Load_AlarmList_Check()
        Load_AlarmList()

        'FTP TLS/SSL 관련 인증서 무시 하기 위해 추가
        Dim mpv As New MyPolicy
        mpv.CertificateValidationCallback()

    End Sub

    Private Sub Print_RawFile_Delete()

        Dim path As String = Application.StartupPath & "\Print Text"
        If Directory.Exists(path) Then
            Dim directory As DirectoryInfo = New DirectoryInfo(path)

            Dim file As FileInfo
            For Each file In directory.GetFiles()
                Debug.Print(file.Name & ", " & file.CreationTime)
                If file.CreationTime < DateAdd(DateInterval.Minute, -30, Now()) Then
                    file.Delete()
                    Debug.Print(file.Name & ", 삭제")
                End If
            Next

            'Dim dir As DirectoryInfo
            'For Each dir In directory.GetDirectories()
            '    dir.Delete(True)
            'Next
        End If

    End Sub

    Private Sub Load_AlarmList_Check()

        MDBConnect()

        Dim checkResult As Boolean = False
        Dim strSQL As String = "select alarm_name from tb_alarm_list"

        Dim sqlCmd As New OleDb.OleDbCommand(strSQL, mdbConnection1)
        Dim sqlDR As OleDb.OleDbDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            If sqlDR("alarm_name").Equals("선입선출 사용") Then
                checkResult = True
            End If
        Loop
        sqlDR.Close()

        If checkResult = False Then
            Dim sqlTran_MDB As OleDb.OleDbTransaction
            Dim sqlCmd_MDB As OleDb.OleDbCommand

            sqlTran_MDB = mdbConnection1.BeginTransaction

            Try
                strSQL = "insert into tb_alarm_list(alarm_name, interval_time, use_alarm)"
                strSQL += " values("
                strSQL += "'선입선출 사용'"
                strSQL += ", 0"
                strSQL += ", false"
                strSQL += ")"

                sqlCmd_MDB = New OleDb.OleDbCommand(strSQL, mdbConnection1)
                sqlCmd_MDB.Transaction = sqlTran_MDB
                sqlCmd_MDB.ExecuteNonQuery()

                sqlTran_MDB.Commit()
            Catch ex As OleDb.OleDbException
                sqlTran_MDB.Rollback()
                MSG_Error(Me, ex.Message)
            End Try
        End If

        MDBClose()

    End Sub

    Private Sub Load_AlarmList()

        MDBConnect()

        Dim strSQL As String = "select alarm_name, interval_time from tb_alarm_list where use_alarm = true"

        Dim sqlCmd As New OleDb.OleDbCommand(strSQL, mdbConnection1)
        Dim sqlDR As OleDb.OleDbDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            If sqlDR("alarm_name").Equals("폐기등록 알림") Then
                discard_Alarm = True
                Timer_Discard_Alarm.Interval = sqlDR("interval_time") * 1000
                Timer_Discard_Alarm.Start()
            ElseIf sqlDR("alarm_name").Equals("프린터 텍스트 삭제") Then
                Timer_FileDelete.Interval = sqlDR("interval_time") * 1000
                Timer_FileDelete.Start()
            ElseIf sqlDR("alarm_name").Equals("SMD 자재요청") Then
                Timer_SMD_Material.Interval = sqlDR("interval_time") * 1000
                Timer_SMD_Material.Start()
            ElseIf sqlDR("alarm_name").Equals("선입선출 사용") Then
                material_FIFO = True
            End If
        Loop
        sqlDR.Close()

        MDBClose()

    End Sub

    Private Sub UpdatePG_Run()

        Dim pgClose As Boolean = False
        If UBound(Diagnostics.Process.GetProcessesByName("Update Checker")) < 0 Then
            Try
                Shell(Application.StartupPath & "\Update Checker.exe", AppWinStyle.Hide)
            Catch ex As Exception
                If MsgBox("업데이트 확인 프로그램을 실행 할 수 없습니다." & vbCrLf &
                          "무시 후 계속 진행하시겠습니까?" & vbCrLf &
                          "( " & Application.StartupPath & "\Update Checker.exe" & " )",
                            MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Update Checker") = MsgBoxResult.No Then
                    pgClose = True
                End If
            End Try
        End If

        If pgClose = True Then Me.Close()

    End Sub

    Private Sub frm_Main_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing



    End Sub

    Private Sub frm_Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        'If MsgBox("정말 종료하시겠습니까?",
        '          MsgBoxStyle.Question + MsgBoxStyle.YesNo,
        '          msg_form) = MsgBoxResult.No Then
        '    e.Cancel = True
        'End If

        If MessageBox.Show(Me,
                           "정말 종료 하시겠습니까",
                           msg_form, MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.No Then
            e.Cancel = True
            Exit Sub
        End If

        Try
            If IO.Directory.Exists(Application.StartupPath & "\Temp") Then
                IO.Directory.Delete(Application.StartupPath & "\Temp", True)
            End If

            Dim ucProcess() As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessesByName("Update Checker")

            '아래 목록은 YJ 프로그램이 실행된 상태인지 확인 후 하나라도 켜져 있다면 업데이트체커 프로그램을 끄지 않도록 한다.
            '현재 내자신(프로그램)을 제외하고 실행되었는지 확인 후 없다면 업데이트체커 프로그램을 종료시킨다.
            Dim process_RepairSystem() As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessesByName("Repair System")
            Dim process_YJ_MMS_MMPS() As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessesByName("YJ MMS MMPS")

            If ucProcess.Length > 0 Then
                If process_RepairSystem.Length = 0 And
                    process_YJ_MMS_MMPS.Length = 0 Then
                    ucProcess(0).Kill()
                End If
            End If
        Catch ex As Exception
            MSG_Information(Me, ex.Message)
            'e.Cancel = True
        End Try

        Me.Dispose()

    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click

        frm_Sub.Focus()
        form_name = Nothing

    End Sub

    Private Sub btn_SQLConn_Click(sender As Object, e As EventArgs) Handles btn_SQLConn.Click

        frm_SQL_Conn.ShowDialog()

    End Sub

    Private Sub btn_CodeManager_Click(sender As Object, e As EventArgs) Handles btn_CodeManager.Click

        frm_Code_Manager.MdiParent = Me
        If Not frm_Code_Manager.Visible Then frm_Code_Manager.Show()
        frm_Code_Manager.Focus()

    End Sub

    Private Sub btn_PGUpdate_Click(sender As Object, e As EventArgs) Handles btn_PGUpdate.Click

        frm_PG_Upload.MdiParent = Me
        If Not frm_PG_Upload.Visible Then frm_PG_Upload.Show()
        frm_PG_Upload.Focus()

    End Sub

    Private Sub btn_CustomerResistration_Click(sender As Object, e As EventArgs) Handles btn_CustomerResistration.Click

        frm_CustomerResistration.MdiParent = Me
        If Not frm_CustomerResistration.Visible Then frm_CustomerResistration.Show()
        frm_CustomerResistration.Focus()

    End Sub

    Private Sub btn_ModelResistration_Click(sender As Object, e As EventArgs) Handles btn_ModelResistration.Click

        frm_Model_Resistration.MdiParent = Me
        If Not frm_Model_Resistration.Visible Then frm_Model_Resistration.Show()
        frm_Model_Resistration.Focus()

    End Sub

    Private Sub btn_ModelDocument_Click(sender As Object, e As EventArgs) Handles btn_ModelDocument.Click

        frm_Model_Document.MdiParent = Me
        If Not frm_Model_Document.Visible Then frm_Model_Document.Show()
        frm_Model_Document.Focus()

    End Sub

    Private Sub BTN_CustomerPartCode_Click(sender As Object, e As EventArgs) Handles BTN_CustomerPartCode.Click

        frm_CustomerPartCode.MdiParent = Me
        If Not frm_CustomerPartCode.Visible Then frm_CustomerPartCode.Show()
        frm_CustomerPartCode.Focus()

    End Sub

    Private Sub BTN_Material_Warehousing_List_Click(sender As Object, e As EventArgs) Handles BTN_Material_Warehousing_List.Click

        frm_Material_Warehousing_With_Label.MdiParent = Me
        If Not frm_Material_Warehousing_With_Label.Visible Then frm_Material_Warehousing_With_Label.Show()
        frm_Material_Warehousing_With_Label.Focus()

    End Sub

    Private Sub BTN_LabelPrinterSetting_Click(sender As Object, e As EventArgs) Handles BTN_LabelPrinterSetting.Click

        'frm_LabelPrinterSetting.MdiParent = Me
        If Not frm_LabelPrinterSetting.Visible Then frm_LabelPrinterSetting.Show()
        frm_LabelPrinterSetting.Focus()

    End Sub

    Private Sub BTN_Warehousing_Document_Click(sender As Object, e As EventArgs) Handles BTN_Warehousing_Document.Click

        frm_Supplier_Document_Register.MdiParent = Me
        If Not frm_Supplier_Document_Register.Visible Then frm_Supplier_Document_Register.Show()
        frm_Supplier_Document_Register.Focus()

    End Sub

    Private Sub BTN_Material_Warehousing_Click(sender As Object, e As EventArgs) Handles BTN_Material_Warehousing.Click

        'frm_Material_Warehousing.MdiParent = Me
        'If Not frm_Material_Warehousing.Visible Then frm_Material_Warehousing.Show()
        'frm_Material_Warehousing.Focus()

        frm_Material_Warehousing_New.MdiParent = Me
        If Not frm_Material_Warehousing_New.Visible Then frm_Material_Warehousing_New.Show()
        frm_Material_Warehousing_New.Focus()

    End Sub

    Private Sub BTN_MaterialWarehousing_History_Click(sender As Object, e As EventArgs) Handles BTN_MaterialWarehousing_History.Click

        frm_Material_Warehousing_History.MdiParent = Me
        If Not frm_Material_Warehousing_History.Visible Then frm_Material_Warehousing_History.Show()
        frm_Material_Warehousing_History.Focus()

    End Sub

    Private Sub BTN_OrderRegistration_Click(sender As Object, e As EventArgs) Handles BTN_OrderRegistration.Click

        frm_Order_Registration.MdiParent = Me
        If Not frm_Order_Registration.Visible Then frm_Order_Registration.Show()
        frm_Order_Registration.Focus()

    End Sub

    Private Sub BTN_OrderModify_Click(sender As Object, e As EventArgs) Handles BTN_OrderModify.Click

        frm_Order_Modify.MdiParent = Me
        If Not frm_Order_Modify.Visible Then frm_Order_Modify.Show()
        frm_Order_Modify.Focus()

    End Sub

    Private Sub BTN_Material_CheckRequirements_Click(sender As Object, e As EventArgs) Handles BTN_Material_CheckRequirements.Click

        frm_Material_CheckRequirements.MdiParent = Me
        If Not frm_Material_CheckRequirements.Visible Then frm_Material_CheckRequirements.Show()
        frm_Material_CheckRequirements.Focus()

    End Sub

    Private Sub BTN_ProductionPlan_Click(sender As Object, e As EventArgs) Handles BTN_ProductionPlan.Click

        frm_Production_plan.MdiParent = Me
        If Not frm_Production_plan.Visible Then frm_Production_plan.Show()
        frm_Production_plan.Focus()

    End Sub

    Private Sub BTN_MMPS_DeviceData_Click(sender As Object, e As EventArgs) Handles BTN_MMPS_DeviceData.Click

        frm_DeviceData.MdiParent = Me
        If Not frm_DeviceData.Visible Then frm_DeviceData.Show()
        frm_DeviceData.Focus()

    End Sub

    Private Sub BTN_MMPS_History_Click(sender As Object, e As EventArgs) Handles BTN_MMPS_History.Click

        frm_MMPS_History.MdiParent = Me
        If Not frm_MMPS_History.Visible Then frm_MMPS_History.Show()
        frm_MMPS_History.Focus()

    End Sub

    Private Sub BTN_SMD_ProductionStart_Click(sender As Object, e As EventArgs) Handles BTN_SMD_ProductionStart.Click

        frm_SMD_Production_Start.MdiParent = Me
        If Not frm_SMD_Production_Start.Visible Then frm_SMD_Production_Start.Show()
        frm_SMD_Production_Start.Focus()

    End Sub

    Private Sub BTN_SMD_Inspection_Click(sender As Object, e As EventArgs) Handles BTN_SMD_Inspection.Click

        frm_SMD_Production_End.MdiParent = Me
        If Not frm_SMD_Production_End.Visible Then frm_SMD_Production_End.Show()
        frm_SMD_Production_End.Focus()

    End Sub

    Private Sub BTN_Repair_Management_Click(sender As Object, e As EventArgs) Handles BTN_Repair_Management.Click

        frm_Repair_Management.MdiParent = Me
        If Not frm_Repair_Management.Visible Then frm_Repair_Management.Show()
        frm_Repair_Management.Focus()

    End Sub

    Private Sub BTN_WSProduction_Start_SMD_Click(sender As Object, e As EventArgs) Handles BTN_WSProduction_Start_SMD.Click

        frm_Wave_Selective_Production_Start.MdiParent = Me
        If Not frm_Wave_Selective_Production_Start.Visible Then frm_Wave_Selective_Production_Start.Show()
        frm_Wave_Selective_Production_Start.Focus()

    End Sub

    Private Sub BTN_WSProduction_Start_First_Click(sender As Object, e As EventArgs) Handles BTN_WSProduction_Start_First.Click

        frm_Wave_Selective_Production_First_Start.MdiParent = Me
        If Not frm_Wave_Selective_Production_First_Start.Visible Then frm_Wave_Selective_Production_First_Start.Show()
        frm_Wave_Selective_Production_First_Start.Focus()

    End Sub

    Private Sub BTN_WSProduction_Inspection_Click(sender As Object, e As EventArgs) Handles BTN_WSProduction_Inspection.Click

        frm_Wave_Selective_Production_End.MdiParent = Me
        If Not frm_Wave_Selective_Production_End.Visible Then frm_Wave_Selective_Production_End.Show()
        frm_Wave_Selective_Production_End.Focus()

    End Sub

    Private Sub BTN_MaterialStock_Click(sender As Object, e As EventArgs) Handles BTN_MaterialStock.Click

        frm_Material_Stock_Information.MdiParent = Me
        If Not frm_Material_Stock_Information.Visible Then frm_Material_Stock_Information.Show()
        frm_Material_Stock_Information.Focus()

    End Sub

    Private Sub BTN_SolderPaste_Warehousing_Click(sender As Object, e As EventArgs) Handles BTN_SolderPaste_Warehousing.Click

        frm_SolderPaste_Warehousing.MdiParent = Me
        If Not frm_SolderPaste_Warehousing.Visible Then frm_SolderPaste_Warehousing.Show()
        frm_SolderPaste_Warehousing.Focus()

    End Sub

    Private Sub BTN_SolderPaste_Use_Click(sender As Object, e As EventArgs) Handles BTN_SolderPaste_Use.Click

        frm_SolderPaste_Use.MdiParent = Me
        If Not frm_SolderPaste_Use.Visible Then frm_SolderPaste_Use.Show()
        frm_SolderPaste_Use.Focus()

    End Sub

    Private Sub BTN_MetalMask_Management_Click(sender As Object, e As EventArgs) Handles BTN_MetalMask_Management.Click

        frm_MetalMaskManagement.MdiParent = Me
        If Not frm_MetalMaskManagement.Visible Then frm_MetalMaskManagement.Show()
        frm_MetalMaskManagement.Focus()

    End Sub

    Private Sub BTN_MetalMask_History_Click(sender As Object, e As EventArgs) Handles BTN_MetalMask_History.Click

        frm_MetalMaskHistory.MdiParent = Me
        If Not frm_MetalMaskHistory.Visible Then frm_MetalMaskHistory.Show()
        frm_MetalMaskHistory.Focus()

    End Sub

    Private Sub BTN_MaterialCode_Change_Click(sender As Object, e As EventArgs) Handles BTN_MaterialCode_Change.Click

        frm_MaterialCode_Change.MdiParent = Me
        If Not frm_MaterialCode_Change.Visible Then frm_MaterialCode_Change.Show()
        frm_MaterialCode_Change.Focus()

    End Sub

    Private Sub BTN_Material_Stock_Survay_Plan_Click(sender As Object, e As EventArgs) Handles BTN_Material_Stock_Survay_Plan.Click

        frm_Material_Stock_Survey_Plan.MdiParent = Me
        If Not frm_Material_Stock_Survey_Plan.Visible Then frm_Material_Stock_Survey_Plan.Show()
        frm_Material_Stock_Survey_Plan.Focus()

    End Sub

    Private Sub BTN_Material_Stock_Survay_Input_Click(sender As Object, e As EventArgs) Handles BTN_Material_Stock_Survay_Input.Click

        frm_Material_Stock_Survey_Input.MdiParent = Me
        If Not frm_Material_Stock_Survey_Input.Visible Then frm_Material_Stock_Survey_Input.Show()
        frm_Material_Stock_Survey_Input.Focus()

    End Sub

    Private Sub BTN_Material_Label_Reprint_Click(sender As Object, e As EventArgs) Handles BTN_Material_Label_Reprint.Click

        frm_Material_Label_Reprint.MdiParent = Me
        If Not frm_Material_Label_Reprint.Visible Then frm_Material_Label_Reprint.Show()
        frm_Material_Label_Reprint.Focus()

    End Sub

    Private Sub BTN_Material_Stock_Survay_Result_Click(sender As Object, e As EventArgs) Handles BTN_Material_Stock_Survay_Result.Click

        frm_Material_Stock_Survey_Result.MdiParent = Me
        If Not frm_Material_Stock_Survey_Result.Visible Then frm_Material_Stock_Survey_Result.Show()
        frm_Material_Stock_Survey_Result.Focus()

    End Sub

    Private Sub BTN_OQC_Click(sender As Object, e As EventArgs) Handles BTN_OQC.Click

        frm_OQC_Register.MdiParent = Me
        If Not frm_OQC_Register.Visible Then frm_OQC_Register.Show()
        frm_OQC_Register.Focus()

    End Sub

    Private Sub BTN_Delivery_Register_Click(sender As Object, e As EventArgs) Handles BTN_Delivery_Register.Click

        frm_Delivery_Register.MdiParent = Me
        If Not frm_Delivery_Register.Visible Then frm_Delivery_Register.Show()
        frm_Delivery_Register.Focus()

    End Sub

    Private Sub BTN_Delivery_History_Click(sender As Object, e As EventArgs) Handles BTN_Delivery_History.Click

        frm_Delivery_History.MdiParent = Me
        If Not frm_Delivery_History.Visible Then frm_Delivery_History.Show()
        frm_Delivery_History.Focus()

    End Sub

    Private Sub BTN_Material_Return_Click(sender As Object, e As EventArgs) Handles BTN_Material_Return.Click

        frm_Material_Return.MdiParent = Me
        If Not frm_Material_Return.Visible Then frm_Material_Return.Show()
        frm_Material_Return.Focus()

    End Sub

    Private Sub BTN_Material_Transfer_Click(sender As Object, e As EventArgs) Handles BTN_Material_Transfer.Click

        frm_Material_Transfer.MdiParent = Me
        If Not frm_Material_Transfer.Visible Then frm_Material_Transfer.Show()
        frm_Material_Transfer.Focus()

    End Sub

    Private Sub BTN_AssyLabelPrint_Click(sender As Object, e As EventArgs) Handles BTN_AssyLabelPrint.Click

        frm_Assy_Label_Print.MdiParent = Me
        If Not frm_Assy_Label_Print.Visible Then frm_Assy_Label_Print.Show()
        frm_Assy_Label_Print.Focus()

    End Sub

    Private Sub BTN_MRP_Click(sender As Object, e As EventArgs) Handles BTN_MRP.Click

        frm_MRP.MdiParent = Me
        If Not frm_MRP.Visible Then frm_MRP.Show()
        frm_MRP.Focus()

    End Sub

    Private Sub BTN_Model_Process_Documents_Click(sender As Object, e As EventArgs) Handles BTN_Model_Process_Documents.Click

        frm_Model_Process_Documents.MdiParent = Me
        If Not frm_Model_Process_Documents.Visible Then frm_Model_Process_Documents.Show()
        frm_Model_Process_Documents.Focus()

    End Sub

    Private Sub 생산현황ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 생산현황ToolStripMenuItem.Click

        frm_Production_Status.MdiParent = Me
        If Not frm_Production_Status.Visible Then frm_Production_Status.Show()
        frm_Production_Status.Focus()

    End Sub

    Private Sub BTN_SMD_Production_History_Click(sender As Object, e As EventArgs) Handles BTN_SMD_Production_History.Click

        frm_SMD_Production_History.MdiParent = Me
        If Not frm_SMD_Production_History.Visible Then frm_SMD_Production_History.Show()
        frm_SMD_Production_History.Focus()

    End Sub

    Private Sub BTN_AlarmSetting_Click(sender As Object, e As EventArgs) Handles BTN_AlarmSetting.Click

        If Not frm_Alarm_Setting.Visible Then frm_Alarm_Setting.Show()
        frm_Alarm_Setting.Focus()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer_Discard_Alarm.Tick

        Try
            If DBConnect() = False Then Exit Sub

            Dim strSQL As String = "call sp_mms_discard_register(0"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ");"

            Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
            Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

            Do While sqlDR.Read
                If Not sqlDR("not_confirm_count") = 0 Then
                    If Not frm_Alarm_Discard.Visible Then frm_Alarm_Discard.Show()
                End If
            Loop
            sqlDR.Close()

            DBClose()

        Catch ex As Exception
            MSG_Error(Me, ex.Message)
        End Try

    End Sub

    Private Sub Timer_SMD_Material_Tick(sender As Object, e As EventArgs) Handles Timer_SMD_Material.Tick

        Try
            If DBConnect() = False Then Exit Sub

            Dim strSQL As String = "select count(*) as request_count"
            strSQL += " from tb_mms_smd_production_material_require_list"
            strSQL += " where require_status = 'Run'"
            strSQL += ";"

            Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
            Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

            Do While sqlDR.Read
                If Not sqlDR("request_count") = 0 Then
                    If Not frm_Alarm_MaterialRequest.Visible Then frm_Alarm_MaterialRequest.Show()
                End If
            Loop
            sqlDR.Close()

            DBClose()

        Catch ex As Exception
            MSG_Error(Me, ex.Message)
        End Try

    End Sub

    Private Sub BTN_Production_Discard_Confirm_Click(sender As Object, e As EventArgs) Handles BTN_Production_Discard_Confirm.Click

        frm_Production_Discard_Confirm.MdiParent = Me
        If Not frm_Production_Discard_Confirm.Visible Then frm_Production_Discard_Confirm.Show()
        frm_Production_Discard_Confirm.Focus()

    End Sub

    Private Sub BTN_WSProduction_History_Click(sender As Object, e As EventArgs) Handles BTN_WSProduction_History.Click

        frm_Wave_Selective_Production_History.MdiParent = Me
        If Not frm_Wave_Selective_Production_History.Visible Then frm_Wave_Selective_Production_History.Show()
        frm_Wave_Selective_Production_History.Focus()

    End Sub

    Private Sub BTN_OutTransfer_List_Click(sender As Object, e As EventArgs) Handles BTN_OutTransfer_List.Click

        frm_WorkSite_Transfer_Material_List.MdiParent = Me
        If Not frm_WorkSite_Transfer_Material_List.Visible Then frm_WorkSite_Transfer_Material_List.Show()
        frm_WorkSite_Transfer_Material_List.Focus()

    End Sub

    Private Sub BTN_Material_Stock_Survay_EachItem_Click(sender As Object, e As EventArgs) Handles BTN_Material_Stock_Survay_EachItem.Click

        frm_Material_Stock_Survey_Each_Item.MdiParent = Me
        If Not frm_Material_Stock_Survey_Each_Item.Visible Then frm_Material_Stock_Survey_Each_Item.Show()
        frm_Material_Stock_Survey_Each_Item.Focus()

    End Sub

    Private Sub BTN_OQC_History_Click(sender As Object, e As EventArgs) Handles BTN_OQC_History.Click

        frm_OQC_History.MdiParent = Me
        If Not frm_OQC_History.Visible Then frm_OQC_History.Show()
        frm_OQC_History.Focus()

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer_FileDelete.Tick

        '너무 지져분해지니까 Print Text File들을 삭제 하자.
        thread_FileDelete = New Thread(AddressOf Print_RawFile_Delete)
        thread_FileDelete.IsBackground = True
        thread_FileDelete.SetApartmentState(ApartmentState.STA) 'OpenFileDialog를 사용하기위해선 STA로 해야되던데...
        thread_FileDelete.Name = "FileDelete Thread"
        thread_FileDelete.Start()

    End Sub

    Private Sub BTN_OrderStatus_Click(sender As Object, e As EventArgs) Handles BTN_OrderStatus.Click

        frm_Order_Status.MdiParent = Me
        If Not frm_Order_Status.Visible Then frm_Order_Status.Show()
        frm_Order_Status.Focus()

    End Sub

    Private Sub BTN_ChangeItemParts_Click(sender As Object, e As EventArgs) Handles BTN_ChangeItemParts.Click

        frm_Change_ItemParts.MdiParent = Me
        If Not frm_Change_ItemParts.Visible Then frm_Change_ItemParts.Show()
        frm_Change_ItemParts.Focus()

    End Sub

    Private Sub BTN_Material_CheckRequirements2_Click(sender As Object, e As EventArgs) Handles BTN_Material_CheckRequirements2.Click

        frm_Material_CheckRequirements2.MdiParent = Me
        If Not frm_Material_CheckRequirements2.Visible Then frm_Material_CheckRequirements2.Show()
        frm_Material_CheckRequirements2.Focus()

    End Sub

    Private Sub BTN_SMD_Material_Request_Click(sender As Object, e As EventArgs) Handles BTN_SMD_Material_Request.Click

        frm_SMD_Material_Request.MdiParent = Me
        If Not frm_SMD_Material_Request.Visible Then frm_SMD_Material_Request.Show()
        frm_SMD_Material_Request.Focus()

    End Sub

    Private Sub BTN_MaterialSplit_Click(sender As Object, e As EventArgs) Handles BTN_MaterialSplit.Click

        frm_Material_Split.MdiParent = Me
        If Not frm_Material_Split.Visible Then frm_Material_Split.Show()
        frm_Material_Split.Focus()

    End Sub
End Class