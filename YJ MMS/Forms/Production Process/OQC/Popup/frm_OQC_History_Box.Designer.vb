<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_OQC_History_Box
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_OQC_History_Box))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Grid_BoxList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TB_OrderQty = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TB_ItemName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TB_ItemCode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TB_ModelCode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TB_DiscardQty = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TB_OrderIndex = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.Grid_BoxList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 320)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "[ Box List ]"
        '
        'Grid_BoxList
        '
        Me.Grid_BoxList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_BoxList.Location = New System.Drawing.Point(16, 347)
        Me.Grid_BoxList.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_BoxList.Name = "Grid_BoxList"
        Me.Grid_BoxList.Rows.Count = 2
        Me.Grid_BoxList.Rows.DefaultSize = 20
        Me.Grid_BoxList.Size = New System.Drawing.Size(553, 364)
        Me.Grid_BoxList.StyleInfo = resources.GetString("Grid_BoxList.StyleInfo")
        Me.Grid_BoxList.TabIndex = 6
        Me.Grid_BoxList.UseCompatibleTextRendering = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_OrderQty)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_ItemName)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_ItemCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_ModelCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_DiscardQty)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TB_OrderIndex)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Grid_BoxList)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.C1FlexGrid1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1046, 720)
        Me.SplitContainer1.SplitterDistance = 581
        Me.SplitContainer1.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(181, 16)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "[ Order Information ]"
        '
        'TB_OrderQty
        '
        Me.TB_OrderQty.Enabled = False
        Me.TB_OrderQty.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_OrderQty.Location = New System.Drawing.Point(157, 130)
        Me.TB_OrderQty.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_OrderQty.Name = "TB_OrderQty"
        Me.TB_OrderQty.Size = New System.Drawing.Size(412, 22)
        Me.TB_OrderQty.TabIndex = 42
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(16, 130)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(141, 22)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "Order Quantity"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_ItemName
        '
        Me.TB_ItemName.Enabled = False
        Me.TB_ItemName.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_ItemName.Location = New System.Drawing.Point(157, 106)
        Me.TB_ItemName.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_ItemName.Name = "TB_ItemName"
        Me.TB_ItemName.Size = New System.Drawing.Size(412, 22)
        Me.TB_ItemName.TabIndex = 40
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(16, 106)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(141, 22)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "Item Name"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_ItemCode
        '
        Me.TB_ItemCode.Enabled = False
        Me.TB_ItemCode.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_ItemCode.Location = New System.Drawing.Point(157, 82)
        Me.TB_ItemCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_ItemCode.Name = "TB_ItemCode"
        Me.TB_ItemCode.Size = New System.Drawing.Size(412, 22)
        Me.TB_ItemCode.TabIndex = 38
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(16, 82)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(141, 22)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Item Code"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_ModelCode
        '
        Me.TB_ModelCode.Enabled = False
        Me.TB_ModelCode.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_ModelCode.Location = New System.Drawing.Point(157, 58)
        Me.TB_ModelCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_ModelCode.Name = "TB_ModelCode"
        Me.TB_ModelCode.Size = New System.Drawing.Size(412, 22)
        Me.TB_ModelCode.TabIndex = 36
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(16, 58)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(141, 22)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Model Code"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_DiscardQty
        '
        Me.TB_DiscardQty.Enabled = False
        Me.TB_DiscardQty.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_DiscardQty.Location = New System.Drawing.Point(157, 154)
        Me.TB_DiscardQty.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_DiscardQty.Name = "TB_DiscardQty"
        Me.TB_DiscardQty.Size = New System.Drawing.Size(412, 22)
        Me.TB_DiscardQty.TabIndex = 34
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(16, 154)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 22)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Amount Of Discard"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_OrderIndex
        '
        Me.TB_OrderIndex.Enabled = False
        Me.TB_OrderIndex.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TB_OrderIndex.Location = New System.Drawing.Point(157, 34)
        Me.TB_OrderIndex.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_OrderIndex.Name = "TB_OrderIndex"
        Me.TB_OrderIndex.Size = New System.Drawing.Size(412, 22)
        Me.TB_OrderIndex.TabIndex = 32
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(16, 34)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 22)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Order Index"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.C1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1FlexGrid1.Location = New System.Drawing.Point(0, 56)
        Me.C1FlexGrid1.Margin = New System.Windows.Forms.Padding(0)
        Me.C1FlexGrid1.Name = "C1FlexGrid1"
        Me.C1FlexGrid1.Rows.Count = 2
        Me.C1FlexGrid1.Rows.DefaultSize = 20
        Me.C1FlexGrid1.Size = New System.Drawing.Size(461, 664)
        Me.C1FlexGrid1.StyleInfo = resources.GetString("C1FlexGrid1.StyleInfo")
        Me.C1FlexGrid1.TabIndex = 7
        Me.C1FlexGrid1.UseCompatibleTextRendering = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Controls.Add(Me.RadioButton1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(461, 56)
        Me.Panel1.TabIndex = 8
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(122, 20)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(107, 16)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "Serial No. 정렬"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(20, 20)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(87, 16)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "등록순 정렬"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(152, 324)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(317, 12)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "※ 박스번호 선택시 등록된 Serial No, 색상이 변경됩니다."
        '
        'frm_OQC_History_Box
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1046, 720)
        Me.Controls.Add(Me.SplitContainer1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_OQC_History_Box"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Box Information"
        CType(Me.Grid_BoxList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Grid_BoxList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Label3 As Label
    Friend WithEvents TB_OrderQty As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TB_ItemName As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TB_ItemCode As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TB_ModelCode As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TB_DiscardQty As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TB_OrderIndex As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel1 As Panel
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Label5 As Label
End Class
