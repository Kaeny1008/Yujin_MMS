<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_SMD_Material_Request
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_SMD_Material_Request))
        Me.TS_MainBar = New System.Windows.Forms.ToolStrip()
        Me.BTN_Search = New System.Windows.Forms.ToolStripButton()
        Me.Form_CLose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Grid_RequestList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TB_S_RequestNo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CB_S_Status = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TB_S_ItemCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TB_S_OrderIndex = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Grid_MaterialList = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.BTN_RequestCompleted = New System.Windows.Forms.Button()
        Me.BTN_ExcelConvert = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TB_ItemCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TB_OrderIndex = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TS_MainBar.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Grid_RequestList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.Grid_MaterialList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TS_MainBar
        '
        Me.TS_MainBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TS_MainBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_Search, Me.Form_CLose, Me.ToolStripSeparator1})
        Me.TS_MainBar.Location = New System.Drawing.Point(0, 0)
        Me.TS_MainBar.Name = "TS_MainBar"
        Me.TS_MainBar.Size = New System.Drawing.Size(1264, 25)
        Me.TS_MainBar.TabIndex = 0
        Me.TS_MainBar.Text = "ToolStrip1"
        '
        'BTN_Search
        '
        Me.BTN_Search.Image = Global.YJ_MMS.My.Resources.Resources.search_121
        Me.BTN_Search.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTN_Search.Name = "BTN_Search"
        Me.BTN_Search.Size = New System.Drawing.Size(51, 22)
        Me.BTN_Search.Text = "검색"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Grid_RequestList)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Grid_MaterialList)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel5)
        Me.SplitContainer1.Size = New System.Drawing.Size(1264, 748)
        Me.SplitContainer1.SplitterDistance = 421
        Me.SplitContainer1.TabIndex = 2
        '
        'Grid_RequestList
        '
        Me.Grid_RequestList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_RequestList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_RequestList.Location = New System.Drawing.Point(0, 106)
        Me.Grid_RequestList.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_RequestList.Name = "Grid_RequestList"
        Me.Grid_RequestList.Rows.Count = 2
        Me.Grid_RequestList.Rows.DefaultSize = 20
        Me.Grid_RequestList.Size = New System.Drawing.Size(421, 642)
        Me.Grid_RequestList.StyleInfo = resources.GetString("Grid_RequestList.StyleInfo")
        Me.Grid_RequestList.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.TB_S_RequestNo)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.CB_S_Status)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TB_S_ItemCode)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TB_S_OrderIndex)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(421, 106)
        Me.Panel1.TabIndex = 0
        '
        'TB_S_RequestNo
        '
        Me.TB_S_RequestNo.BackColor = System.Drawing.SystemColors.Window
        Me.TB_S_RequestNo.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_S_RequestNo.Location = New System.Drawing.Point(85, 77)
        Me.TB_S_RequestNo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_S_RequestNo.Name = "TB_S_RequestNo"
        Me.TB_S_RequestNo.Size = New System.Drawing.Size(326, 21)
        Me.TB_S_RequestNo.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(9, 77)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 21)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "요청번호"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CB_S_Status
        '
        Me.CB_S_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_S_Status.FormattingEnabled = True
        Me.CB_S_Status.Items.AddRange(New Object() {"모두", "완료", "미완료"})
        Me.CB_S_Status.Location = New System.Drawing.Point(85, 55)
        Me.CB_S_Status.Name = "CB_S_Status"
        Me.CB_S_Status.Size = New System.Drawing.Size(326, 20)
        Me.CB_S_Status.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(9, 55)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "상태"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_S_ItemCode
        '
        Me.TB_S_ItemCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_S_ItemCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_S_ItemCode.Location = New System.Drawing.Point(85, 32)
        Me.TB_S_ItemCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_S_ItemCode.Name = "TB_S_ItemCode"
        Me.TB_S_ItemCode.Size = New System.Drawing.Size(326, 21)
        Me.TB_S_ItemCode.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(9, 32)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 21)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "품번"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_S_OrderIndex
        '
        Me.TB_S_OrderIndex.BackColor = System.Drawing.SystemColors.Window
        Me.TB_S_OrderIndex.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_S_OrderIndex.Location = New System.Drawing.Point(85, 9)
        Me.TB_S_OrderIndex.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_S_OrderIndex.Name = "TB_S_OrderIndex"
        Me.TB_S_OrderIndex.Size = New System.Drawing.Size(326, 21)
        Me.TB_S_OrderIndex.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 9)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 21)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "주문번호"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Grid_MaterialList
        '
        Me.Grid_MaterialList.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_MaterialList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_MaterialList.Location = New System.Drawing.Point(0, 106)
        Me.Grid_MaterialList.Margin = New System.Windows.Forms.Padding(0)
        Me.Grid_MaterialList.Name = "Grid_MaterialList"
        Me.Grid_MaterialList.Rows.Count = 2
        Me.Grid_MaterialList.Rows.DefaultSize = 20
        Me.Grid_MaterialList.Size = New System.Drawing.Size(839, 642)
        Me.Grid_MaterialList.StyleInfo = resources.GetString("Grid_MaterialList.StyleInfo")
        Me.Grid_MaterialList.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel5.Controls.Add(Me.TextBox2)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.BTN_RequestCompleted)
        Me.Panel5.Controls.Add(Me.BTN_ExcelConvert)
        Me.Panel5.Controls.Add(Me.TextBox1)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.TB_ItemCode)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.TB_OrderIndex)
        Me.Panel5.Controls.Add(Me.Label17)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(839, 106)
        Me.Panel5.TabIndex = 0
        '
        'BTN_RequestCompleted
        '
        Me.BTN_RequestCompleted.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_RequestCompleted.Enabled = False
        Me.BTN_RequestCompleted.Image = Global.YJ_MMS.My.Resources.Resources.ordering_32
        Me.BTN_RequestCompleted.Location = New System.Drawing.Point(737, 55)
        Me.BTN_RequestCompleted.Name = "BTN_RequestCompleted"
        Me.BTN_RequestCompleted.Size = New System.Drawing.Size(90, 47)
        Me.BTN_RequestCompleted.TabIndex = 7
        Me.BTN_RequestCompleted.Text = "완료"
        Me.BTN_RequestCompleted.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTN_RequestCompleted.UseVisualStyleBackColor = True
        '
        'BTN_ExcelConvert
        '
        Me.BTN_ExcelConvert.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_ExcelConvert.Enabled = False
        Me.BTN_ExcelConvert.Image = Global.YJ_MMS.My.Resources.Resources.excel2
        Me.BTN_ExcelConvert.Location = New System.Drawing.Point(609, 55)
        Me.BTN_ExcelConvert.Name = "BTN_ExcelConvert"
        Me.BTN_ExcelConvert.Size = New System.Drawing.Size(122, 47)
        Me.BTN_ExcelConvert.TabIndex = 6
        Me.BTN_ExcelConvert.Text = "Excel 전환"
        Me.BTN_ExcelConvert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTN_ExcelConvert.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TextBox1.Location = New System.Drawing.Point(85, 10)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(442, 21)
        Me.TextBox1.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(9, 10)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 21)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "요청번호"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_ItemCode
        '
        Me.TB_ItemCode.BackColor = System.Drawing.SystemColors.Window
        Me.TB_ItemCode.Enabled = False
        Me.TB_ItemCode.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_ItemCode.Location = New System.Drawing.Point(85, 56)
        Me.TB_ItemCode.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_ItemCode.Name = "TB_ItemCode"
        Me.TB_ItemCode.Size = New System.Drawing.Size(442, 21)
        Me.TB_ItemCode.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 56)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 21)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "품번"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TB_OrderIndex
        '
        Me.TB_OrderIndex.BackColor = System.Drawing.SystemColors.Window
        Me.TB_OrderIndex.Enabled = False
        Me.TB_OrderIndex.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TB_OrderIndex.Location = New System.Drawing.Point(85, 33)
        Me.TB_OrderIndex.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TB_OrderIndex.Name = "TB_OrderIndex"
        Me.TB_OrderIndex.Size = New System.Drawing.Size(442, 21)
        Me.TB_OrderIndex.TabIndex = 3
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(9, 33)
        Me.Label17.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(76, 21)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "주문번호"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox2.Enabled = False
        Me.TextBox2.Font = New System.Drawing.Font("굴림", 9.0!)
        Me.TextBox2.Location = New System.Drawing.Point(85, 79)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(442, 21)
        Me.TextBox2.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(9, 79)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 21)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "주문수량"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frm_SMD_Material_Request
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 773)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.TS_MainBar)
        Me.Name = "frm_SMD_Material_Request"
        Me.Text = "SMD 자재 요청"
        Me.TS_MainBar.ResumeLayout(False)
        Me.TS_MainBar.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Grid_RequestList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Grid_MaterialList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TS_MainBar As ToolStrip
    Friend WithEvents BTN_Search As ToolStripButton
    Friend WithEvents Form_CLose As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Grid_MaterialList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel5 As Panel
    Friend WithEvents TB_OrderIndex As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents TB_ItemCode As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CB_S_Status As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TB_S_ItemCode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TB_S_OrderIndex As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Grid_RequestList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BTN_ExcelConvert As Button
    Friend WithEvents BTN_RequestCompleted As Button
    Friend WithEvents TB_S_RequestNo As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label7 As Label
End Class
