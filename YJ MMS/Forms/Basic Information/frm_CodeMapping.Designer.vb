<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_CodeMapping
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
        Me.ts_MainBar = New System.Windows.Forms.ToolStrip()
        Me.btn_Search = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_NewCustomer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_Save = New System.Windows.Forms.ToolStripButton()
        Me.Form_CLose = New System.Windows.Forms.ToolStripButton()
        Me.ts_MainBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'ts_MainBar
        '
        Me.ts_MainBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ts_MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_Search, Me.ToolStripSeparator1, Me.btn_NewCustomer, Me.ToolStripSeparator2, Me.btn_Save, Me.Form_CLose})
        Me.ts_MainBar.Location = New System.Drawing.Point(0, 0)
        Me.ts_MainBar.Name = "ts_MainBar"
        Me.ts_MainBar.Size = New System.Drawing.Size(1264, 25)
        Me.ts_MainBar.TabIndex = 4
        Me.ts_MainBar.Text = "ToolStrip1"
        '
        'btn_Search
        '
        Me.btn_Search.Image = Global.YJ_MMS.My.Resources.Resources.search_121
        Me.btn_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Search.Name = "btn_Search"
        Me.btn_Search.Size = New System.Drawing.Size(51, 22)
        Me.btn_Search.Text = "검색"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btn_NewCustomer
        '
        Me.btn_NewCustomer.Image = Global.YJ_MMS.My.Resources.Resources.plus_blue
        Me.btn_NewCustomer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_NewCustomer.Name = "btn_NewCustomer"
        Me.btn_NewCustomer.Size = New System.Drawing.Size(75, 22)
        Me.btn_NewCustomer.Text = "신규등록"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btn_Save
        '
        Me.btn_Save.Image = Global.YJ_MMS.My.Resources.Resources.save_5
        Me.btn_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(51, 22)
        Me.btn_Save.Text = "저장"
        '
        'Form_CLose
        '
        Me.Form_CLose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Form_CLose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Form_CLose.Image = Global.YJ_MMS.My.Resources.Resources.close
        Me.Form_CLose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Form_CLose.Name = "Form_CLose"
        Me.Form_CLose.Size = New System.Drawing.Size(23, 22)
        Me.Form_CLose.Text = "폼 닫기"
        '
        'frm_CodeMapping
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 773)
        Me.Controls.Add(Me.ts_MainBar)
        Me.Name = "frm_CodeMapping"
        Me.Text = "Code Mapping"
        Me.ts_MainBar.ResumeLayout(False)
        Me.ts_MainBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ts_MainBar As ToolStrip
    Friend WithEvents btn_Search As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btn_NewCustomer As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btn_Save As ToolStripButton
    Friend WithEvents Form_CLose As ToolStripButton
End Class
