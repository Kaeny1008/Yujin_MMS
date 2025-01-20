<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Production_Material_Request
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Production_Material_Request))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTN_Cancel = New System.Windows.Forms.Button()
        Me.LB_OrderIndex = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LB_ItemCode = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Grid_BottomList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Grid_TopList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Grid_menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_Delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_DeleteCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_MRCanel = New System.Windows.Forms.Button()
        CType(Me.Grid_BottomList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid_TopList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grid_menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(22, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "주문번호"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BTN_Cancel
        '
        Me.BTN_Cancel.Location = New System.Drawing.Point(657, 395)
        Me.BTN_Cancel.Name = "BTN_Cancel"
        Me.BTN_Cancel.Size = New System.Drawing.Size(67, 43)
        Me.BTN_Cancel.TabIndex = 8
        Me.BTN_Cancel.Text = "닫기"
        Me.BTN_Cancel.UseVisualStyleBackColor = True
        '
        'LB_OrderIndex
        '
        Me.LB_OrderIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_OrderIndex.Location = New System.Drawing.Point(140, 20)
        Me.LB_OrderIndex.Margin = New System.Windows.Forms.Padding(0)
        Me.LB_OrderIndex.Name = "LB_OrderIndex"
        Me.LB_OrderIndex.Size = New System.Drawing.Size(584, 26)
        Me.LB_OrderIndex.TabIndex = 1
        Me.LB_OrderIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(22, 46)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 26)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "품번"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LB_ItemCode
        '
        Me.LB_ItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LB_ItemCode.Location = New System.Drawing.Point(140, 46)
        Me.LB_ItemCode.Margin = New System.Windows.Forms.Padding(0)
        Me.LB_ItemCode.Name = "LB_ItemCode"
        Me.LB_ItemCode.Size = New System.Drawing.Size(584, 26)
        Me.LB_ItemCode.TabIndex = 3
        Me.LB_ItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(511, 395)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(67, 43)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "요청"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Grid_BottomList
        '
        Me.Grid_BottomList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_BottomList.Location = New System.Drawing.Point(22, 72)
        Me.Grid_BottomList.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_BottomList.Name = "Grid_BottomList"
        Me.Grid_BottomList.Rows.Count = 2
        Me.Grid_BottomList.Rows.DefaultSize = 20
        Me.Grid_BottomList.Size = New System.Drawing.Size(351, 303)
        Me.Grid_BottomList.StyleInfo = resources.GetString("Grid_BottomList.StyleInfo")
        Me.Grid_BottomList.TabIndex = 4
        Me.Grid_BottomList.UseCompatibleTextRendering = True
        '
        'Grid_TopList
        '
        Me.Grid_TopList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_TopList.Location = New System.Drawing.Point(373, 72)
        Me.Grid_TopList.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_TopList.Name = "Grid_TopList"
        Me.Grid_TopList.Rows.Count = 2
        Me.Grid_TopList.Rows.DefaultSize = 20
        Me.Grid_TopList.Size = New System.Drawing.Size(351, 303)
        Me.Grid_TopList.StyleInfo = resources.GetString("Grid_TopList.StyleInfo")
        Me.Grid_TopList.TabIndex = 5
        Me.Grid_TopList.UseCompatibleTextRendering = True
        '
        'Grid_menu
        '
        Me.Grid_menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Delete, Me.BTN_DeleteCancel})
        Me.Grid_menu.Name = "Grid_menu"
        Me.Grid_menu.Size = New System.Drawing.Size(127, 48)
        '
        'BTN_Delete
        '
        Me.BTN_Delete.Name = "BTN_Delete"
        Me.BTN_Delete.Size = New System.Drawing.Size(126, 22)
        Me.BTN_Delete.Text = "삭제"
        '
        'BTN_DeleteCancel
        '
        Me.BTN_DeleteCancel.Name = "BTN_DeleteCancel"
        Me.BTN_DeleteCancel.Size = New System.Drawing.Size(126, 22)
        Me.BTN_DeleteCancel.Text = "삭제 취소"
        '
        'BTN_MRCanel
        '
        Me.BTN_MRCanel.Location = New System.Drawing.Point(584, 395)
        Me.BTN_MRCanel.Name = "BTN_MRCanel"
        Me.BTN_MRCanel.Size = New System.Drawing.Size(67, 43)
        Me.BTN_MRCanel.TabIndex = 7
        Me.BTN_MRCanel.Text = "요청취소"
        Me.BTN_MRCanel.UseVisualStyleBackColor = True
        '
        'frm_Production_Material_Request
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(742, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_MRCanel)
        Me.Controls.Add(Me.Grid_TopList)
        Me.Controls.Add(Me.Grid_BottomList)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LB_ItemCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LB_OrderIndex)
        Me.Controls.Add(Me.BTN_Cancel)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm_Production_Material_Request"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "주문별 SMD 자재요청"
        CType(Me.Grid_BottomList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid_TopList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grid_menu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents BTN_Cancel As Button
    Friend WithEvents LB_OrderIndex As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LB_ItemCode As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Grid_BottomList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Grid_TopList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Grid_menu As ContextMenuStrip
    Friend WithEvents BTN_Delete As ToolStripMenuItem
    Friend WithEvents BTN_DeleteCancel As ToolStripMenuItem
    Friend WithEvents BTN_MRCanel As Button
End Class
