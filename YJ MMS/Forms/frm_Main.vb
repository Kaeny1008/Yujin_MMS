Imports System.ComponentModel
Imports System.Threading

Public Class frm_Main

    Public form_name As Form

    Private Sub frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "Yujin Manufacturing Management System (Build " &
            System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() &
            ")"

        lb_LoginID.Text = lb_LoginID.Text & loginID

        frm_Sub.MdiParent = Me
        frm_Sub.Show()

        lb_Status.Text = String.Empty

        Me.WindowState = FormWindowState.Maximized

        UpdatePG_Run()

        'If Not loginID = "ADMIN" Then
        'menu_Monthly_Production_Report.Visible = False
        'End If

        Timer1.Interval = 1000
        Timer1.Enabled = True

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

        If IO.Directory.Exists(Application.StartupPath & "\Temp") Then
            IO.Directory.Delete(Application.StartupPath & "\Temp", True)
        End If

        Dim ucProcess() As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessesByName("UpdateChecker")

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

        frm_code_manager.MdiParent = Me
        If Not frm_code_manager.Visible Then frm_code_manager.Show()
        frm_code_manager.Focus()

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

        frm_ModelResistration.MdiParent = Me
        If Not frm_ModelResistration.Visible Then frm_ModelResistration.Show()
        frm_ModelResistration.Focus()

    End Sub

    Private Sub btn_ModelDocument_Click(sender As Object, e As EventArgs) Handles btn_ModelDocument.Click

        frm_ModelDocument.MdiParent = Me
        If Not frm_ModelDocument.Visible Then frm_ModelDocument.Show()
        frm_ModelDocument.Focus()

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

        frm_Material_Warehousing.MdiParent = Me
        If Not frm_Material_Warehousing.Visible Then frm_Material_Warehousing.Show()
        frm_Material_Warehousing.Focus()

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

    Private Sub BTN_SMD_ProductionEnd_Click(sender As Object, e As EventArgs) Handles BTN_SMD_Inspection.Click

        frm_SMD_Production_End.MdiParent = Me
        If Not frm_SMD_Production_End.Visible Then frm_SMD_Production_End.Show()
        frm_SMD_Production_End.Focus()

    End Sub

    Private Sub BTN_Repair_Management_Click(sender As Object, e As EventArgs) Handles BTN_Repair_Management.Click

        frm_Repair_Management.MdiParent = Me
        If Not frm_Repair_Management.Visible Then frm_Repair_Management.Show()
        frm_Repair_Management.Focus()

    End Sub

    Private Sub BTN_WSProduction_Click(sender As Object, e As EventArgs) Handles BTN_WSProduction.Click

        frm_Wave_Selective_Production.MdiParent = Me
        If Not frm_Wave_Selective_Production.Visible Then frm_Wave_Selective_Production.Show()
        frm_Wave_Selective_Production.Focus()

    End Sub
End Class