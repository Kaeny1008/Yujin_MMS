<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Discard_Register
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
        Me.TB_OrderQty = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TB_Workside = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TB_Inspector = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TB_OrderIndex = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TB_ItemName = New System.Windows.Forms.TextBox()
        Me.TB_ItemCode = New System.Windows.Forms.TextBox()
        Me.TB_ModelCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TB_CustomerName = New System.Windows.Forms.TextBox()
        Me.TB_CustomerCode = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TB_Process = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TB_Discard_Resone = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TB_BoardNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BTN_Discard_Save = New System.Windows.Forms.Button()
        Me.TB_HistoryNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TB_OrderQty
        '
        Me.TB_OrderQty.BackColor = System.Drawing.SystemColors.Window
        Me.TB_OrderQty.Enabled = False
        Me.TB_OrderQty.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_OrderQty.Location = New System.Drawing.Point(520, 38)
        Me.TB_OrderQty.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_OrderQty.Name = "TB_OrderQty"
        Me.TB_OrderQty.Size = New System.Drawing.Size(158, 26)
        Me.TB_OrderQty.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(431, 38)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 26)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "주문수량"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Workside
        '
        Me.TB_Workside.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Workside.Enabled = False
        Me.TB_Workside.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_Workside.Location = New System.Drawing.Point(520, 10)
        Me.TB_Workside.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_Workside.Name = "TB_Workside"
        Me.TB_Workside.Size = New System.Drawing.Size(158, 26)
        Me.TB_Workside.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(431, 10)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 26)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "작업면"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Inspector
        '
        Me.TB_Inspector.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Inspector.Enabled = False
        Me.TB_Inspector.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_Inspector.Location = New System.Drawing.Point(520, 66)
        Me.TB_Inspector.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_Inspector.Name = "TB_Inspector"
        Me.TB_Inspector.Size = New System.Drawing.Size(158, 26)
        Me.TB_Inspector.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(431, 66)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 26)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Inspector"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_OrderIndex
        '
        Me.TB_OrderIndex.BackColor = System.Drawing.SystemColors.Window
        Me.TB_OrderIndex.Enabled = False
        Me.TB_OrderIndex.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_OrderIndex.Location = New System.Drawing.Point(100, 10)
        Me.TB_OrderIndex.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_OrderIndex.Name = "TB_OrderIndex"
        Me.TB_OrderIndex.Size = New System.Drawing.Size(331, 26)
        Me.TB_OrderIndex.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(11, 10)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 26)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "주문번호"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_ItemName
        '
        Me.TB_ItemName.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ItemName.Enabled = False
        Me.TB_ItemName.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_ItemName.Location = New System.Drawing.Point(100, 93)
        Me.TB_ItemName.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_ItemName.Name = "TB_ItemName"
        Me.TB_ItemName.Size = New System.Drawing.Size(331, 26)
        Me.TB_ItemName.TabIndex = 12
        '
        'TB_ItemCode
        '
        Me.TB_ItemCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ItemCode.Enabled = False
        Me.TB_ItemCode.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_ItemCode.Location = New System.Drawing.Point(205, 66)
        Me.TB_ItemCode.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_ItemCode.Name = "TB_ItemCode"
        Me.TB_ItemCode.Size = New System.Drawing.Size(226, 26)
        Me.TB_ItemCode.TabIndex = 11
        '
        'TB_ModelCode
        '
        Me.TB_ModelCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ModelCode.Enabled = False
        Me.TB_ModelCode.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_ModelCode.Location = New System.Drawing.Point(100, 66)
        Me.TB_ModelCode.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_ModelCode.Name = "TB_ModelCode"
        Me.TB_ModelCode.Size = New System.Drawing.Size(105, 26)
        Me.TB_ModelCode.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(11, 66)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 53)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "모델"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_CustomerName
        '
        Me.TB_CustomerName.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerName.Enabled = False
        Me.TB_CustomerName.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_CustomerName.Location = New System.Drawing.Point(205, 38)
        Me.TB_CustomerName.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerName.Name = "TB_CustomerName"
        Me.TB_CustomerName.Size = New System.Drawing.Size(226, 26)
        Me.TB_CustomerName.TabIndex = 6
        '
        'TB_CustomerCode
        '
        Me.TB_CustomerCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerCode.Enabled = False
        Me.TB_CustomerCode.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_CustomerCode.Location = New System.Drawing.Point(100, 38)
        Me.TB_CustomerCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerCode.Name = "TB_CustomerCode"
        Me.TB_CustomerCode.Size = New System.Drawing.Size(105, 26)
        Me.TB_CustomerCode.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(11, 38)
        Me.Label17.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(89, 26)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "고객사"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Process
        '
        Me.TB_Process.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Process.Enabled = False
        Me.TB_Process.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_Process.Location = New System.Drawing.Point(520, 93)
        Me.TB_Process.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_Process.Name = "TB_Process"
        Me.TB_Process.Size = New System.Drawing.Size(158, 26)
        Me.TB_Process.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(431, 93)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 26)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "발생공정"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Discard_Resone
        '
        Me.TB_Discard_Resone.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Discard_Resone.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_Discard_Resone.Location = New System.Drawing.Point(100, 177)
        Me.TB_Discard_Resone.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_Discard_Resone.Multiline = True
        Me.TB_Discard_Resone.Name = "TB_Discard_Resone"
        Me.TB_Discard_Resone.Size = New System.Drawing.Size(578, 128)
        Me.TB_Discard_Resone.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(11, 177)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 128)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "폐기사유"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_BoardNo
        '
        Me.TB_BoardNo.BackColor = System.Drawing.SystemColors.Window
        Me.TB_BoardNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TB_BoardNo.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_BoardNo.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TB_BoardNo.Location = New System.Drawing.Point(100, 149)
        Me.TB_BoardNo.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_BoardNo.Name = "TB_BoardNo"
        Me.TB_BoardNo.Size = New System.Drawing.Size(578, 26)
        Me.TB_BoardNo.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(11, 149)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 26)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Board No."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BTN_Discard_Save
        '
        Me.BTN_Discard_Save.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_Discard_Save.Location = New System.Drawing.Point(582, 348)
        Me.BTN_Discard_Save.Name = "BTN_Discard_Save"
        Me.BTN_Discard_Save.Size = New System.Drawing.Size(97, 57)
        Me.BTN_Discard_Save.TabIndex = 23
        Me.BTN_Discard_Save.Text = "폐기등록"
        Me.BTN_Discard_Save.UseVisualStyleBackColor = True
        '
        'TB_HistoryNo
        '
        Me.TB_HistoryNo.BackColor = System.Drawing.SystemColors.Window
        Me.TB_HistoryNo.Enabled = False
        Me.TB_HistoryNo.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.TB_HistoryNo.Location = New System.Drawing.Point(100, 121)
        Me.TB_HistoryNo.Margin = New System.Windows.Forms.Padding(0)
        Me.TB_HistoryNo.Name = "TB_HistoryNo"
        Me.TB_HistoryNo.Size = New System.Drawing.Size(578, 26)
        Me.TB_HistoryNo.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 12.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(11, 121)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 26)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "History No."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frm_Discard_Register
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 417)
        Me.Controls.Add(Me.TB_HistoryNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BTN_Discard_Save)
        Me.Controls.Add(Me.TB_BoardNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TB_Discard_Resone)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TB_Process)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TB_OrderQty)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TB_Workside)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TB_Inspector)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TB_OrderIndex)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TB_ItemName)
        Me.Controls.Add(Me.TB_ItemCode)
        Me.Controls.Add(Me.TB_ModelCode)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TB_CustomerName)
        Me.Controls.Add(Me.TB_CustomerCode)
        Me.Controls.Add(Me.Label17)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Discard_Register"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "공정불량 (폐기) 등록"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TB_OrderQty As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TB_Workside As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TB_Inspector As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TB_OrderIndex As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TB_ItemName As TextBox
    Friend WithEvents TB_ItemCode As TextBox
    Friend WithEvents TB_ModelCode As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TB_CustomerName As TextBox
    Friend WithEvents TB_CustomerCode As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents TB_Process As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_Discard_Resone As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TB_BoardNo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents BTN_Discard_Save As Button
    Friend WithEvents TB_HistoryNo As TextBox
    Friend WithEvents Label2 As Label
End Class
