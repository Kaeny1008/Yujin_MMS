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

    Private Sub frm_Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If MsgBox("정말 종료하시겠습니까?", vbYesNo + vbQuestion, msg_form) = vbYes Then '메세지박스 띄우기
            End '종료
        Else
            e.Cancel = True
        End If

        If IO.Directory.Exists(Application.StartupPath & "\TEMP_FILE") Then
            IO.Directory.Delete(Application.StartupPath & "\TEMP_FILE", True)
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
        'If MsgBox("프로그램을 종료 하시겠습니까?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, form_msgbox_string) = MsgBoxResult.Yes Then Application.Exit()

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
End Class
