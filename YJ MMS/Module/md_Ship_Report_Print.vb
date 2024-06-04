Imports CrystalDecisions.CrystalReports.Engine
Imports MySql.Data.MySqlClient

Module md_Ship_Report_Print
    Public Sub Ship_Report_Print(ByVal deliveryNo As String)

        Dim strSQL As String = String.Empty

        'MySQL DB에서 정보를 불러오기전에 기존 내용 삭제
        Mdbconnect()

        Dim sqlTran_MDB As OleDb.OleDbTransaction
        Dim sqlCmd_MDB As OleDb.OleDbCommand

        sqlTran_MDB = mdbConnection1.BeginTransaction

        Try
            '기존 저장 데이터를 삭제
            strSQL = "delete from tb_mms_delivery_history;"

            sqlCmd_MDB = New OleDb.OleDbCommand(strSQL, mdbConnection1)
            sqlCmd_MDB.Transaction = sqlTran_MDB
            sqlCmd_MDB.ExecuteNonQuery()

            strSQL = "delete from tb_mms_delivery_history_content;"

            sqlCmd_MDB = New OleDb.OleDbCommand(strSQL, mdbConnection1)
            sqlCmd_MDB.Transaction = sqlTran_MDB
            sqlCmd_MDB.ExecuteNonQuery()

            sqlTran_MDB.Commit()

        Catch ex As OleDb.OleDbException
            sqlTran_MDB.Rollback()
            MsgBox(ex.Message, MsgBoxStyle.Critical, msg_form)
            Exit Sub
        End Try

        '새로운 데이터를 MySQL에서 가져온다.
        sqlTran_MDB = mdbConnection1.BeginTransaction

        Try
            DBConnect()

            strSQL = "call sp_mms_delivery(1"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ",'" & deliveryNo & "'"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ")"

            Dim sqlCmd As New MySqlCommand(strSQL, dbConnection1)
            Dim sqlDR As MySqlDataReader = sqlCmd.ExecuteReader
            '''' 서브도 집어 넣어야 된다!!!!
            Do While sqlDR.Read
                strSQL = "insert into tb_mms_delivery_history("
                strSQL += "delivery_no, customer_name, write_date, write_id"
                strSQL += ") values("
                strSQL += "'" & sqlDR("delivery_no") & "'"
                strSQL += ",'" & sqlDR("customer_name") & "'"
                strSQL += ",'" & sqlDR("write_date") & "'"
                strSQL += ",'" & sqlDR("write_id") & "'"
                strSQL += ");"

                sqlCmd_MDB = New OleDb.OleDbCommand(strSQL, mdbConnection1)
                sqlCmd_MDB.Transaction = sqlTran_MDB
                sqlCmd_MDB.ExecuteNonQuery()
            Loop
            sqlDR.Close()

            strSQL = "call sp_mms_delivery(2"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ",'" & deliveryNo & "'"
            strSQL += ", null"
            strSQL += ", null"
            strSQL += ")"

            sqlCmd = New MySqlCommand(strSQL, dbConnection1)
            sqlDR = sqlCmd.ExecuteReader
            '''' 서브도 집어 넣어야 된다!!!!
            Do While sqlDR.Read
                strSQL = "insert into tb_mms_delivery_history_content("
                strSQL += "delivery_no, po_split, delivery_qty, history_note, item_code, item_name, item_spec"
                strSQL += ") values("
                strSQL += "'" & sqlDR("delivery_no") & "'"
                strSQL += ",'" & sqlDR("po_split") & "'"
                strSQL += "," & sqlDR("delivery_qty") & ""
                strSQL += ",'" & sqlDR("history_note") & "'"
                strSQL += ",'" & sqlDR("item_code") & "'"
                strSQL += ",'" & sqlDR("item_name").replace("'", "") & "'"
                strSQL += ",'" & sqlDR("item_spec") & "'"
                strSQL += ");"

                sqlCmd_MDB = New OleDb.OleDbCommand(strSQL, mdbConnection1)
                sqlCmd_MDB.Transaction = sqlTran_MDB
                sqlCmd_MDB.ExecuteNonQuery()
            Loop
            sqlDR.Close()

            DBClose()

            sqlTran_MDB.Commit()

        Catch ex As OleDb.OleDbException
            sqlTran_MDB.Rollback()
            MsgBox(ex.Message, MsgBoxStyle.Critical, msg_form)
            Exit Sub
        End Try

        MDBClose()

        '크리스탈 레포트에서 인쇄하는 규칙
        Try
            Dim rptPath As String = Application.StartupPath & "\Reports\rpt_PO_Delivery.rpt"

            Dim ds As DataSet = New DataSet

            Dim connection As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath + "\TempDB\TempDB.mdb" & ";Jet OLEDB:Database Password='dbwlspark'")
            connection.Open()

            Dim strQuery As String = " SELECT `tb_mms_delivery_history`.`delivery_no`, `tb_mms_delivery_history`.`write_date`"
            strQuery += ", `tb_mms_delivery_history_content`.`po_split`, `tb_mms_delivery_history_content`.`delivery_qty`"
            strQuery += ", `tb_mms_delivery_history_content`.`history_note`, `tb_mms_delivery_history`.`customer_name`"
            strQuery += ", `tb_mms_delivery_history_content`.`item_code`, `tb_mms_delivery_history_content`.`item_name`"
            strQuery += ", `tb_mms_delivery_history_content`.`item_spec`"
            strQuery += " FROM   `tb_mms_delivery_history` `tb_mms_delivery_history`"
            strQuery += " INNER JOIN `tb_mms_delivery_history_content` `tb_mms_delivery_history_content`"
            strQuery += " ON `tb_mms_delivery_history`.`delivery_no`=`tb_mms_delivery_history_content`.`delivery_no`"

            Console.WriteLine(strQuery)

            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(strQuery, connection)
            da.Fill(ds)

            Dim rDOC As ReportDocument = New ReportDocument

            rDOC.Load(rptPath)
            rDOC.SetDataSource(ds)
            'rDOC.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape '용지방향 설정
            frm_DeviceData_Report.CrystalReportViewer1.ReportSource = Nothing
            frm_DeviceData_Report.CrystalReportViewer1.ReportSource = rDOC

            If MsgBox("인쇄 미리보기를 하시겠습니까?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, msg_form) = MsgBoxResult.Yes Then
                frm_DeviceData_Report.ShowDialog()
            Else
                rDOC.PrintToPrinter(1, True, 0, 0)
            End If

            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, msg_form)
        End Try

    End Sub
End Module
