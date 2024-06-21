<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Order_Excel_File_Open
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Order_Excel_File_Open))
        Me.Grid_Excel = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Grid_RowMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_StartRow = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_EndRow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_RowDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.Grid_ColMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BTN_ItemCode = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_ItemName = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_StartDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_EndDate = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BTN_POChange = New System.Windows.Forms.Button()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_DateRow = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Grid_Excel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grid_RowMenu.SuspendLayout()
        Me.Grid_ColMenu.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grid_Excel
        '
        Me.Grid_Excel.ColumnInfo = "2,1,0,0,0,100,Columns:"
        Me.Grid_Excel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid_Excel.Location = New System.Drawing.Point(0, 100)
        Me.Grid_Excel.Name = "Grid_Excel"
        Me.Grid_Excel.Rows.Count = 2
        Me.Grid_Excel.Rows.DefaultSize = 20
        Me.Grid_Excel.Size = New System.Drawing.Size(1264, 673)
        Me.Grid_Excel.StyleInfo = resources.GetString("Grid_Excel.StyleInfo")
        Me.Grid_Excel.TabIndex = 25
        '
        'Grid_RowMenu
        '
        Me.Grid_RowMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_StartRow, Me.BTN_EndRow, Me.ToolStripSeparator1, Me.BTN_RowDelete, Me.ToolStripSeparator3, Me.BTN_DateRow})
        Me.Grid_RowMenu.Name = "Grid_RowMenu"
        Me.Grid_RowMenu.Size = New System.Drawing.Size(181, 126)
        '
        'BTN_StartRow
        '
        Me.BTN_StartRow.Name = "BTN_StartRow"
        Me.BTN_StartRow.Size = New System.Drawing.Size(180, 22)
        Me.BTN_StartRow.Text = "시작행"
        '
        'BTN_EndRow
        '
        Me.BTN_EndRow.Name = "BTN_EndRow"
        Me.BTN_EndRow.Size = New System.Drawing.Size(180, 22)
        Me.BTN_EndRow.Text = "종료행"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(177, 6)
        '
        'BTN_RowDelete
        '
        Me.BTN_RowDelete.Name = "BTN_RowDelete"
        Me.BTN_RowDelete.Size = New System.Drawing.Size(180, 22)
        Me.BTN_RowDelete.Text = "행 제외"
        '
        'Grid_ColMenu
        '
        Me.Grid_ColMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTN_ItemCode, Me.BTN_ItemName, Me.ToolStripSeparator2, Me.BTN_StartDate, Me.BTN_EndDate})
        Me.Grid_ColMenu.Name = "Grid_ColMenu"
        Me.Grid_ColMenu.Size = New System.Drawing.Size(111, 98)
        '
        'BTN_ItemCode
        '
        Me.BTN_ItemCode.Name = "BTN_ItemCode"
        Me.BTN_ItemCode.Size = New System.Drawing.Size(110, 22)
        Me.BTN_ItemCode.Text = "품목"
        '
        'BTN_ItemName
        '
        Me.BTN_ItemName.Name = "BTN_ItemName"
        Me.BTN_ItemName.Size = New System.Drawing.Size(110, 22)
        Me.BTN_ItemName.Text = "품목명"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(107, 6)
        '
        'BTN_StartDate
        '
        Me.BTN_StartDate.Name = "BTN_StartDate"
        Me.BTN_StartDate.Size = New System.Drawing.Size(110, 22)
        Me.BTN_StartDate.Text = "시작일"
        '
        'BTN_EndDate
        '
        Me.BTN_EndDate.Name = "BTN_EndDate"
        Me.BTN_EndDate.Size = New System.Drawing.Size(110, 22)
        Me.BTN_EndDate.Text = "종료일"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.BTN_POChange)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1264, 100)
        Me.Panel1.TabIndex = 26
        '
        'BTN_POChange
        '
        Me.BTN_POChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_POChange.Location = New System.Drawing.Point(1151, 29)
        Me.BTN_POChange.Name = "BTN_POChange"
        Me.BTN_POChange.Size = New System.Drawing.Size(101, 54)
        Me.BTN_POChange.TabIndex = 0
        Me.BTN_POChange.Text = "PO 변환하기"
        Me.BTN_POChange.UseVisualStyleBackColor = True
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(177, 6)
        '
        'BTN_DateRow
        '
        Me.BTN_DateRow.Name = "BTN_DateRow"
        Me.BTN_DateRow.Size = New System.Drawing.Size(180, 22)
        Me.BTN_DateRow.Text = "날짜 행"
        '
        'frm_Order_Excel_File_Open
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 773)
        Me.Controls.Add(Me.Grid_Excel)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frm_Order_Excel_File_Open"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "기타 Excel 자료 수정"
        CType(Me.Grid_Excel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grid_RowMenu.ResumeLayout(False)
        Me.Grid_ColMenu.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grid_Excel As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Grid_RowMenu As ContextMenuStrip
    Friend WithEvents BTN_StartRow As ToolStripMenuItem
    Friend WithEvents BTN_EndRow As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BTN_RowDelete As ToolStripMenuItem
    Friend WithEvents Grid_ColMenu As ContextMenuStrip
    Friend WithEvents BTN_ItemCode As ToolStripMenuItem
    Friend WithEvents BTN_ItemName As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents BTN_StartDate As ToolStripMenuItem
    Friend WithEvents BTN_EndDate As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BTN_POChange As Button
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents BTN_DateRow As ToolStripMenuItem
End Class
