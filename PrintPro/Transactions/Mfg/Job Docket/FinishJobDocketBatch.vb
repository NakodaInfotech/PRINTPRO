
Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class FinishJobDocketBatch
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub FinishJobDocketBatch_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub FinishJobDocketBatch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'JOB DOCKET'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As New DataTable
            If RBPENDING.Checked = True Then
                If ClientName = "AMR" Then
                    GREADYQTY.Visible = False
                    dt = objclsCMST.search("ISNULL(JOBBATCHMASTER.job_orderno, 0) AS ORDERNO, ISNULL(JOBBATCHMASTER.job_no, 0) AS JOBDOCKETNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(ITEMCODEITEMMASTER.item_code, '') AS SUBITEM, ISNULL(JOBBATCHMASTER.job_qty, 0) AS ORDERQTY  , ISNULL(JOBBATCHMASTER.job_qty - JOBBATCHMASTER.JOB_ASSEMBLYQTY, 0) AS REMAININGASSEMBLY   ", "", " JOBBATCHMASTER LEFT OUTER JOIN LEDGERS ON JOBBATCHMASTER.JOB_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN ITEMMASTER AS ITEMCODEITEMMASTER ON JOBBATCHMASTER.JOB_SUBITEMID = ITEMCODEITEMMASTER.item_id LEFT OUTER JOIN ITEMMASTER ON JOBBATCHMASTER.job_itemid = ITEMMASTER.item_id ", "  AND (JOBBATCHMASTER.JOB_FINISHED = 0) AND (JOBBATCHMASTER.JOB_CLOSE = 0)  AND (JOBBATCHMASTER.job_yearid = " & YearId & ")  ")
                Else
                    GASSEMBLYREM.Visible = False
                    'dt = objclsCMST.search(" ISNULL(JOBBATCHMASTER.job_orderno, 0) AS ORDERNO, ISNULL(JOBBATCHMASTER.job_no, 0) AS JOBDOCKETNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME,ISNULL(SUBITEMMASTER.item_name, '') AS SUBITEM,ISNULL(JOBBATCHMASTER.JOB_JOBQTY, 0) AS ORDERQTY,SUM(PRODUCTION.PROD_TOTALGOODQTY)/(PRODUCTION.PROD_UPS) AS READYQTY", "", " ITEMMASTER AS SUBITEMMASTER RIGHT OUTER JOIN JOBBATCHMASTER ON SUBITEMMASTER.item_id = JOBBATCHMASTER.JOB_SUBITEMID LEFT OUTER JOIN ITEMMASTER ON JOBBATCHMASTER.JOB_MAINITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS ON JOBBATCHMASTER.JOB_LEDGERID = LEDGERS.Acc_id ", " AND JOBBATCHMASTER.JOB_FINISHED = 0  AND JOBBATCHMASTER.JOB_CLOSE = 0 and JOBBATCHMASTER.JOB_YEARID=" & YearId & "  ORDER BY JOBBATCHMASTER.job_orderno")
                    dt = objclsCMST.search("ISNULL(JOBBATCHMASTER.job_orderno, 0) AS ORDERNO, ISNULL(JOBBATCHMASTER.job_no, 0) AS JOBDOCKETNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME,ISNULL(SUBITEMMASTER.item_name, '') AS SUBITEM,ISNULL(JOBBATCHMASTER.JOB_QTY, 0) AS ORDERQTY,SUM((PRODUCTION.PROD_TOTALGOODQTY)/(PRODUCTION.PROD_UPS) * JOBBATCHMASTER.JOB_OPENUPS) AS READYQTY  ", "", " PRODUCTION INNER JOIN (SELECT DISTINCT PRODUCTION_DESC.PROD_JOBNO, PRODUCTION_DESC.PROD_NO, PRODUCTION_DESC.PROD_YEARID FROM PRODUCTION_DESC) AS PRODUCTION_DESC  ON PRODUCTION_DESC.PROD_NO = PRODUCTION.PROD_NO AND PRODUCTION_DESC.PROD_YEARID = PRODUCTION.PROD_YEARID INNER JOIN JOBBATCHMASTER ON PRODUCTION_DESC.PROD_JOBNO = JOBBATCHMASTER.job_no INNER JOIN LEDGERS ON LEDGERS.Acc_id = JOBBATCHMASTER.JOB_LEDGERID INNER JOIN ITEMMASTER ON JOBBATCHMASTER.JOB_MAINITEMID = ITEMMASTER.item_id LEFT OUTER JOIN ITEMMASTER AS SUBITEMMASTER ON JOBBATCHMASTER.JOB_SUBITEMID = SUBITEMMASTER.item_id  ", "  AND (JOBBATCHMASTER.JOB_FINISHED = 0) AND (JOBBATCHMASTER.JOB_CLOSE = 0) AND (PRODUCTION.PROD_TOTALGOODQTY - PRODUCTION.PROD_OUTQTY > 0) AND (JOBBATCHMASTER.job_yearid = " & YearId & ") GROUP BY ISNULL(JOBBATCHMASTER.job_orderno, 0) , ISNULL(JOBBATCHMASTER.job_no, 0) , ISNULL(LEDGERS.Acc_cmpname, '') , ISNULL(ITEMMASTER.item_name, '') , ISNULL(SUBITEMMASTER.item_name, '') , ISNULL(JOBBATCHMASTER.JOB_QTY, 0) ")
                End If

            Else
                If ClientName = "AMR" Then
                    GREADYQTY.Visible = False
                    dt = objclsCMST.search("ISNULL(JOBBATCHMASTER.job_orderno, 0) AS ORDERNO, ISNULL(JOBBATCHMASTER.job_no, 0) AS JOBDOCKETNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(ITEMCODEITEMMASTER.item_code, '') AS SUBITEM, ISNULL(JOBBATCHMASTER.job_qty, 0) AS ORDERQTY  , ISNULL(JOBBATCHMASTER.job_qty - JOBBATCHMASTER.JOB_ASSEMBLYQTY, 0) AS REMAININGASSEMBLY   ", "", " JOBBATCHMASTER LEFT OUTER JOIN LEDGERS ON JOBBATCHMASTER.JOB_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN ITEMMASTER AS ITEMCODEITEMMASTER ON JOBBATCHMASTER.JOB_SUBITEMID = ITEMCODEITEMMASTER.item_id LEFT OUTER JOIN ITEMMASTER ON JOBBATCHMASTER.job_itemid = ITEMMASTER.item_id ", "  AND (JOBBATCHMASTER.JOB_FINISHED = 1) AND (JOBBATCHMASTER.JOB_CLOSE = 0)  AND (JOBBATCHMASTER.job_yearid = " & YearId & ")  ")
                Else
                    GASSEMBLYREM.Visible = False
                    'dt = objclsCMST.search(" ISNULL(JOBBATCHMASTER.job_orderno, 0) AS ORDERNO, ISNULL(JOBBATCHMASTER.job_no, 0) AS JOBDOCKETNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(SUBITEMMASTER.item_name, '') AS SUBITEM, ISNULL(JOBBATCHMASTER.JOB_JOBQTY, 0) AS QTY, ISNULL(JOBBATCHMASTER.JOB_PRODFINISHQTY, 0) AS PRODUCTIONQTY , ISNULL(JOBBATCHMASTER.JOB_FINISHED, 0) AS FINISHED ", "", " ITEMMASTER AS SUBITEMMASTER RIGHT OUTER JOIN JOBBATCHMASTER ON SUBITEMMASTER.item_id = JOBBATCHMASTER.JOB_SUBITEMID LEFT OUTER JOIN ITEMMASTER ON JOBBATCHMASTER.JOB_MAINITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS ON JOBBATCHMASTER.JOB_LEDGERID = LEDGERS.Acc_id ", " AND JOBBATCHMASTER.JOB_FINISHED = 1  and JOBBATCHMASTER.JOB_YEARID=" & YearId & "  ORDER BY JOBBATCHMASTER.job_orderno")
                    dt = objclsCMST.search("ISNULL(JOBBATCHMASTER.job_orderno, 0) AS ORDERNO, ISNULL(JOBBATCHMASTER.job_no, 0) AS JOBDOCKETNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME,ISNULL(SUBITEMMASTER.item_name, '') AS SUBITEM,ISNULL(JOBBATCHMASTER.JOB_QTY, 0) AS ORDERQTY,SUM((PRODUCTION.PROD_TOTALGOODQTY)/(PRODUCTION.PROD_UPS) * JOBBATCHMASTER.JOB_OPENUPS) AS READYQTY   ", "", " PRODUCTION INNER JOIN (SELECT DISTINCT PRODUCTION_DESC.PROD_JOBNO, PRODUCTION_DESC.PROD_NO, PRODUCTION_DESC.PROD_YEARID FROM PRODUCTION_DESC) AS PRODUCTION_DESC  ON PRODUCTION_DESC.PROD_NO = PRODUCTION.PROD_NO AND PRODUCTION_DESC.PROD_YEARID = PRODUCTION.PROD_YEARID INNER JOIN JOBBATCHMASTER ON PRODUCTION_DESC.PROD_JOBNO = JOBBATCHMASTER.job_no INNER JOIN LEDGERS ON LEDGERS.Acc_id = JOBBATCHMASTER.JOB_LEDGERID INNER JOIN ITEMMASTER ON JOBBATCHMASTER.JOB_MAINITEMID = ITEMMASTER.item_id LEFT OUTER JOIN ITEMMASTER AS SUBITEMMASTER ON JOBBATCHMASTER.JOB_SUBITEMID = SUBITEMMASTER.item_id  ", "  AND (JOBBATCHMASTER.JOB_FINISHED = 1) and (JOBBATCHMASTER.JOB_CLOSE = 0)  AND (PRODUCTION.PROD_TOTALGOODQTY - PRODUCTION.PROD_OUTQTY > 0) AND (JOBBATCHMASTER.job_yearid = " & YearId & ") GROUP BY ISNULL(JOBBATCHMASTER.job_orderno, 0) , ISNULL(JOBBATCHMASTER.job_no, 0) , ISNULL(LEDGERS.Acc_cmpname, '') , ISNULL(ITEMMASTER.item_name, '') , ISNULL(SUBITEMMASTER.item_name, '') , ISNULL(JOBBATCHMASTER.JOB_QTY, 0) ")
                End If

            End If
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrinToExcel_Click(sender As Object, e As EventArgs) Handles PrinToExcel.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Finish Job Docket Batch Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Finish Job Docket Batch Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Finish Job Docket Batch Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Finish Job Docket Batch Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click

        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            'PENDING
            If RBPENDING.Checked = True Then
                Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
                For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                    Dim DTROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))
                    DT = OBJCMN.Execute_Any_String(" UPDATE JOBBATCHMASTER set JOB_FINISHED = 1 WHERE job_no = " & Val(DTROW("JOBDOCKETNO")) & " AND  job_yearid = " & YearId, "", "")
                Next
                MsgBox("Details Updated Successfully")
                FILLGRID()
                gridbill.Focus()
            End If

            'ENTERED
            If RBENTERED.Checked = True Then
                If MsgBox("You have trying to Re-Open Finish Job Docket Batch, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
                For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                    Dim DTROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))
                    DT = OBJCMN.Execute_Any_String("UPDATE JOBBATCHMASTER set JOB_FINISHED = 0 WHERE job_no = " & Val(DTROW("JOBDOCKETNO")) & " AND job_yearid = " & YearId, "", "")
                Next
                MsgBox("Details Updated Successfully")
                FILLGRID()
                gridbill.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBPENDING_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBPENDING.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBENTERED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBENTERED.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    'Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
    '    Try
    '        If e.RowHandle >= 0 Then
    '            Dim View As GridView = sender
    '            If View.GetRowCellDisplayText(e.RowHandle, View.Columns("FINISH")) = "Checked" Then
    '                e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
    '                e.Appearance.BackColor = Color.Yellow
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
    '    Try
    '        If gridbilldetails.Visible = True Then
    '            For i As Integer = 0 To gridbill.RowCount - 1
    '                Dim dtrow As DataRow = gridbill.GetDataRow(i)
    '                dtrow("FINISHED") = CHKSELECTALL.Checked
    '            Next
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub gridbill_KeyDown(sender As Object, e As KeyEventArgs) Handles gridbill.KeyDown
    '    Try
    '        If e.KeyCode = Keys.Space Then
    '            Dim dtrow As DataRow = gridbill.GetFocusedDataRow()
    '            dtrow("FINISHED") = Not dtrow("FINISHED")
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
End Class