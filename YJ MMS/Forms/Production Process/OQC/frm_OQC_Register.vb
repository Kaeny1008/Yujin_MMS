Imports C1.Win.C1FlexGrid
Imports MySql.Data.MySqlClient

Public Class frm_OQC_Register
    Private Sub frm_OQC_Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Grid_Setting()

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub

    Private Sub Grid_Setting()

        With Grid_History
            .AllowEditing = False
            .AllowFiltering = False
            .AllowSorting = AllowSortingEnum.None
            .AllowFreezing = AllowFreezingEnum.None
            .AllowMergingFixed = AllowMergingEnum.None
            .Rows(0).Height = 40
            .Rows.DefaultSize = 20
            .Cols.Count = 5
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1
            .AutoClipboard = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.TextAlign = TextAlignEnum.CenterCenter
            .ExtendLastCol = True
            .ShowCursor = True
        End With

        Grid_History(0, 0) = "No"
        Grid_History(0, 1) = "출고번호"
        Grid_History(0, 2) = "수량"
        Grid_History(0, 3) = "검사자"
        Grid_History(0, 4) = "비고"

        Grid_History.AutoSizeCols()

    End Sub

    Private Sub Control_Init()

        TB_PONo.Text = String.Empty
        TB_LastProcess.Text = String.Empty
        TB_ItemCode.Text = String.Empty
        TB_ItemName.Text = String.Empty
        TB_ItemSpec.Text = String.Empty
        TB_POQty.Text = String.Empty

    End Sub

    Private Sub TB_MagazineBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles TB_MagazineBarcode.KeyDown

        If e.KeyCode = 13 And Not Trim(TB_MagazineBarcode.Text) = String.Empty Then
            'PO202404010002-0004!WSO2405160856453858!Wave Soldering

            Control_Init()

            Try
                Dim splitBarcode() As String = TB_MagazineBarcode.Text.Split("!")
                TB_PONo.Text = splitBarcode(0)
                TB_LastProcess.Text = splitBarcode(2)
            Catch ex As Exception
                MessageBox.Show(Me,
                                "유진 공정라벨을 스캔하여 주십시오.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                TB_MagazineBarcode.SelectAll()
                TB_MagazineBarcode.Focus()
                Exit Sub
            End Try

            TB_MagazineBarcode.Text = String.Empty

            Load_Po_Information()
            If TB_ItemCode.Text = String.Empty Then
                MessageBox.Show(Me,
                                "모델 정보를 불러오지 못했습니다.",
                                msg_form,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                Control_Init()
                TB_MagazineBarcode.SelectAll()
                TB_MagazineBarcode.Focus()
            End If
        End If

    End Sub

    Private Sub Load_Po_Information()

        Thread_LoadingFormStart()

        DBConnect()

        Dim strSQL As String = "call sp_mms_oqc(0"
        strSQL += ", '" & TB_PONo.Text & "'"
        strSQL += ")"

        Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
        Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader

        Do While sqlDR.Read
            TB_ItemCode.Text = sqlDR("item_code")
            TB_ItemName.Text = sqlDR("item_name")
            TB_ItemSpec.Text = sqlDR("item_spec")
            TB_POQty.Text = sqlDR("modify_order_quantity")
        Loop
        sqlDR.Close()

        DBClose()

        Thread_LoadingFormEnd()

    End Sub
End Class