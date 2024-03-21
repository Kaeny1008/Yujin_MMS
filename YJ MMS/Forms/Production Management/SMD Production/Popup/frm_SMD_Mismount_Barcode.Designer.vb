<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SMD_Mismount_Barcode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_SMD_Mismount_Barcode))
        Me.C1QRCode1 = New C1.Win.C1BarCode.C1QRCode()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Grid_DeviceData = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.BTN_CheckResult = New System.Windows.Forms.Button()
        CType(Me.Grid_DeviceData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1QRCode1
        '
        Me.C1QRCode1.Location = New System.Drawing.Point(506, 99)
        Me.C1QRCode1.Name = "C1QRCode1"
        Me.C1QRCode1.Size = New System.Drawing.Size(211, 211)
        Me.C1QRCode1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.C1QRCode1.SymbolSize = 10
        Me.C1QRCode1.TabIndex = 0
        Me.C1QRCode1.Text = "ReadyBarcode"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(71, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(271, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "총 0대의 Device Data가 존재 합니다."
        '
        'Grid_DeviceData
        '
        Me.Grid_DeviceData.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_DeviceData.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Grid_DeviceData.Location = New System.Drawing.Point(74, 99)
        Me.Grid_DeviceData.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_DeviceData.Name = "Grid_DeviceData"
        Me.Grid_DeviceData.Rows.Count = 2
        Me.Grid_DeviceData.Rows.DefaultSize = 20
        Me.Grid_DeviceData.Size = New System.Drawing.Size(358, 263)
        Me.Grid_DeviceData.StyleInfo = resources.GetString("Grid_DeviceData.StyleInfo")
        Me.Grid_DeviceData.TabIndex = 5
        Me.Grid_DeviceData.UseCompatibleTextRendering = True
        '
        'BTN_CheckResult
        '
        Me.BTN_CheckResult.Location = New System.Drawing.Point(528, 336)
        Me.BTN_CheckResult.Name = "BTN_CheckResult"
        Me.BTN_CheckResult.Size = New System.Drawing.Size(162, 48)
        Me.BTN_CheckResult.TabIndex = 6
        Me.BTN_CheckResult.Text = "완료 등록"
        Me.BTN_CheckResult.UseVisualStyleBackColor = True
        '
        'frm_SMD_Mismount_Barcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTN_CheckResult)
        Me.Controls.Add(Me.Grid_DeviceData)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.C1QRCode1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_SMD_Mismount_Barcode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "오삽방지 시스템 DeviceData"
        CType(Me.Grid_DeviceData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents C1QRCode1 As C1.Win.C1BarCode.C1QRCode
    Friend WithEvents Label1 As Label
    Friend WithEvents Grid_DeviceData As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BTN_CheckResult As Button
End Class
