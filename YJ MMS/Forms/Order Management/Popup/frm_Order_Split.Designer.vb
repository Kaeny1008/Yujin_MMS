<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Order_Split
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Order_Split))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TB_Date_Of_Delivery = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TB_Order_Quantity = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TB_ModelCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TB_ItemSpec = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TB_ItemName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TB_ItemCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TB_CustomerName = New System.Windows.Forms.TextBox()
        Me.TB_CustomerCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TB_Split_Quantity = New System.Windows.Forms.TextBox()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.Grid_ManagementNo = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TB_OrderIndex = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Grid_ManagementNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TB_OrderIndex)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.TB_Date_Of_Delivery)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TB_Order_Quantity)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TB_ModelCode)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TB_ItemSpec)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TB_ItemName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TB_ItemCode)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TB_CustomerName)
        Me.GroupBox1.Controls.Add(Me.TB_CustomerCode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(15, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(678, 223)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "주문정보"
        '
        'TB_Date_Of_Delivery
        '
        Me.TB_Date_Of_Delivery.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Date_Of_Delivery.Enabled = False
        Me.TB_Date_Of_Delivery.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_Date_Of_Delivery.Location = New System.Drawing.Point(182, 167)
        Me.TB_Date_Of_Delivery.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Date_Of_Delivery.Name = "TB_Date_Of_Delivery"
        Me.TB_Date_Of_Delivery.Size = New System.Drawing.Size(473, 21)
        Me.TB_Date_Of_Delivery.TabIndex = 50
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(12, 167)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(170, 21)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "납기일자"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_Order_Quantity
        '
        Me.TB_Order_Quantity.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Order_Quantity.Enabled = False
        Me.TB_Order_Quantity.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_Order_Quantity.Location = New System.Drawing.Point(182, 144)
        Me.TB_Order_Quantity.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_Order_Quantity.Name = "TB_Order_Quantity"
        Me.TB_Order_Quantity.Size = New System.Drawing.Size(473, 21)
        Me.TB_Order_Quantity.TabIndex = 48
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(12, 144)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(170, 21)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "주문수량"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_ModelCode
        '
        Me.TB_ModelCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ModelCode.Enabled = False
        Me.TB_ModelCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_ModelCode.Location = New System.Drawing.Point(182, 121)
        Me.TB_ModelCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_ModelCode.Name = "TB_ModelCode"
        Me.TB_ModelCode.Size = New System.Drawing.Size(473, 21)
        Me.TB_ModelCode.TabIndex = 46
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(12, 121)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(170, 21)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "모델코드"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_ItemSpec
        '
        Me.TB_ItemSpec.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ItemSpec.Enabled = False
        Me.TB_ItemSpec.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_ItemSpec.Location = New System.Drawing.Point(182, 98)
        Me.TB_ItemSpec.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_ItemSpec.Name = "TB_ItemSpec"
        Me.TB_ItemSpec.Size = New System.Drawing.Size(473, 21)
        Me.TB_ItemSpec.TabIndex = 44
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 98)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(170, 21)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "규격"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_ItemName
        '
        Me.TB_ItemName.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ItemName.Enabled = False
        Me.TB_ItemName.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_ItemName.Location = New System.Drawing.Point(182, 75)
        Me.TB_ItemName.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_ItemName.Name = "TB_ItemName"
        Me.TB_ItemName.Size = New System.Drawing.Size(473, 21)
        Me.TB_ItemName.TabIndex = 42
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 75)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(170, 21)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "품명"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_ItemCode
        '
        Me.TB_ItemCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ItemCode.Enabled = False
        Me.TB_ItemCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_ItemCode.Location = New System.Drawing.Point(182, 52)
        Me.TB_ItemCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_ItemCode.Name = "TB_ItemCode"
        Me.TB_ItemCode.Size = New System.Drawing.Size(473, 21)
        Me.TB_ItemCode.TabIndex = 40
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 52)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(170, 21)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "품번"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_CustomerName
        '
        Me.TB_CustomerName.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerName.Enabled = False
        Me.TB_CustomerName.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_CustomerName.Location = New System.Drawing.Point(182, 29)
        Me.TB_CustomerName.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerName.Name = "TB_CustomerName"
        Me.TB_CustomerName.Size = New System.Drawing.Size(311, 21)
        Me.TB_CustomerName.TabIndex = 37
        '
        'TB_CustomerCode
        '
        Me.TB_CustomerCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_CustomerCode.Enabled = False
        Me.TB_CustomerCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_CustomerCode.Location = New System.Drawing.Point(493, 29)
        Me.TB_CustomerCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_CustomerCode.Name = "TB_CustomerCode"
        Me.TB_CustomerCode.Size = New System.Drawing.Size(162, 21)
        Me.TB_CustomerCode.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 29)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 21)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "고객사"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Tomato
        Me.Label8.Location = New System.Drawing.Point(24, 482)
        Me.Label8.Margin = New System.Windows.Forms.Padding(3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(276, 15)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "2. 분할할 수량을 입력하여 주십시오."
        '
        'TB_Split_Quantity
        '
        Me.TB_Split_Quantity.BackColor = System.Drawing.SystemColors.Window
        Me.TB_Split_Quantity.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_Split_Quantity.Location = New System.Drawing.Point(27, 501)
        Me.TB_Split_Quantity.Margin = New System.Windows.Forms.Padding(1)
        Me.TB_Split_Quantity.Name = "TB_Split_Quantity"
        Me.TB_Split_Quantity.Size = New System.Drawing.Size(252, 25)
        Me.TB_Split_Quantity.TabIndex = 51
        '
        'BTN_Save
        '
        Me.BTN_Save.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BTN_Save.Location = New System.Drawing.Point(581, 534)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(112, 63)
        Me.BTN_Save.TabIndex = 52
        Me.BTN_Save.Text = "분할내용" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "저장하기"
        Me.BTN_Save.UseVisualStyleBackColor = True
        '
        'Grid_ManagementNo
        '
        Me.Grid_ManagementNo.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_ManagementNo.Location = New System.Drawing.Point(27, 283)
        Me.Grid_ManagementNo.Name = "Grid_ManagementNo"
        Me.Grid_ManagementNo.Rows.Count = 2
        Me.Grid_ManagementNo.Rows.DefaultSize = 20
        Me.Grid_ManagementNo.Size = New System.Drawing.Size(666, 193)
        Me.Grid_ManagementNo.StyleInfo = resources.GetString("Grid_ManagementNo.StyleInfo")
        Me.Grid_ManagementNo.TabIndex = 53
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Tomato
        Me.Label9.Location = New System.Drawing.Point(24, 262)
        Me.Label9.Margin = New System.Windows.Forms.Padding(3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(308, 15)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "1. 적용할 관리번호를 선택하여 주십시오."
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(27, 534)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(100, 16)
        Me.CheckBox1.TabIndex = 55
        Me.CheckBox1.Text = "주문전체 적용"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Yellow
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(492, 479)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(201, 12)
        Me.Label10.TabIndex = 56
        Me.Label10.Text = "※ 하위번호가 최신 시방번호입니다."
        '
        'TB_OrderIndex
        '
        Me.TB_OrderIndex.BackColor = System.Drawing.SystemColors.Window
        Me.TB_OrderIndex.Enabled = False
        Me.TB_OrderIndex.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_OrderIndex.Location = New System.Drawing.Point(182, 190)
        Me.TB_OrderIndex.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_OrderIndex.Name = "TB_OrderIndex"
        Me.TB_OrderIndex.Size = New System.Drawing.Size(473, 21)
        Me.TB_OrderIndex.TabIndex = 52
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(12, 190)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(170, 21)
        Me.Label11.TabIndex = 51
        Me.Label11.Text = "Order Index"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frm_Order_Split
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(714, 609)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Grid_ManagementNo)
        Me.Controls.Add(Me.BTN_Save)
        Me.Controls.Add(Me.TB_Split_Quantity)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Order_Split"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "주문 분리"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Grid_ManagementNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TB_CustomerName As TextBox
    Friend WithEvents TB_CustomerCode As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TB_ItemSpec As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TB_ItemName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TB_ItemCode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TB_Date_Of_Delivery As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TB_Order_Quantity As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TB_ModelCode As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TB_Split_Quantity As TextBox
    Friend WithEvents BTN_Save As Button
    Friend WithEvents Grid_ManagementNo As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label9 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TB_OrderIndex As TextBox
    Friend WithEvents Label11 As Label
End Class
