

Public Class frm_CodeMapping
    Private Sub frm_CodeMapping_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Console.WriteLine(Load_PHP("http://125.137.78.158:10520/MMPS/AllPartsCheck/feederlist.php?ddMainNo=DD-20240228100726&machineNo=1",
        '                           "feederList",
        '                           "FEEDER_SN")) 'PHP 사용법 예제

    End Sub

    Private Sub Form_CLose_Click(sender As Object, e As EventArgs) Handles Form_CLose.Click

        Me.Dispose()

    End Sub
End Class