<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Documents_Viewer
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
        Me.WB_PDF = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'WB_PDF
        '
        Me.WB_PDF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WB_PDF.Location = New System.Drawing.Point(0, 0)
        Me.WB_PDF.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WB_PDF.Name = "WB_PDF"
        Me.WB_PDF.Size = New System.Drawing.Size(800, 450)
        Me.WB_PDF.TabIndex = 0
        '
        'frm_Documents_Viewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.WB_PDF)
        Me.Name = "frm_Documents_Viewer"
        Me.Text = "작업지도서"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WB_PDF As WebBrowser
End Class
