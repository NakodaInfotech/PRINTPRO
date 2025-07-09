
Imports BL

Public Class PendingQC

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PendingQC_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PendingQC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As New DataTable
            If RBPENDING.Checked = True Then
                'dt = objclsCMST.search(" ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(JOBBATCHMASTER.job_no, 0) AS BATCHNO, JOBBATCHMASTER.job_date AS DATE, ISNULL(JOBBATCHMASTER.job_qty, 0) AS QTY, ISNULL(JOBBATCHMASTER.JOB_TOTALSHEETS, '') AS TOTALSHEETS, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(JOBBATCHMASTER.job_pono, '') AS PONO, ISNULL(ITEMMASTER.ITEM_MATERIALCODE, '')  AS MATERIALCODE ", "", " JOBBATCHMASTER INNER JOIN LEDGERS ON JOBBATCHMASTER.JOB_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON JOBBATCHMASTER.job_itemid = ITEMMASTER.item_id  ", " AND ISNULL(JOBBATCHMASTER.JOB_QCDONE,'FALSE') = 'FALSE' AND JOBBATCHMASTER.JOB_YEARID=" & YearId & " ORDER BY JOBBATCHMASTER.JOB_NO")
                dt = objclsCMST.search(" ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(BATCHMASTER.jobbatch_no, 0) AS BATCHNO, BATCHMASTER.jobbatch_date AS DATE, ISNULL(BATCHMASTER.jobbatch_qty, 0) AS QTY, ISNULL(BATCHMASTER.jobbatch_TOTALSHEETS, '') AS TOTALSHEETS, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(BATCHMASTER.jobbatch_pono, '') AS PONO, ISNULL(ITEMMASTER.ITEM_MATERIALCODE, '')  AS MATERIALCODE ", "", " BATCHMASTER INNER JOIN LEDGERS ON BATCHMASTER.jobbatch_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON BATCHMASTER.jobbatch_itemid = ITEMMASTER.item_id  ", " AND ISNULL(BATCHMASTER.jobbatch_QCDONE,'FALSE') = 'FALSE' AND BATCHMASTER.jobbatch_YEARID=" & YearId & " ORDER BY BATCHMASTER.jobbatch_NO")
            Else
                'dt = objclsCMST.search(" ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(JOBBATCHMASTER.job_no, 0) AS BATCHNO, JOBBATCHMASTER.job_date AS DATE, ISNULL(JOBBATCHMASTER.job_qty, 0) AS QTY, ISNULL(JOBBATCHMASTER.JOB_TOTALSHEETS, '') AS TOTALSHEETS, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(JOBBATCHMASTER.job_pono, '') AS PONO, ISNULL(ITEMMASTER.ITEM_MATERIALCODE, '')  AS MATERIALCODE ", "", " JOBBATCHMASTER INNER JOIN LEDGERS ON JOBBATCHMASTER.JOB_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON JOBBATCHMASTER.job_itemid = ITEMMASTER.item_id  ", " AND ISNULL(JOBBATCHMASTER.JOB_QCDONE,'FALSE') = 'TRUE' AND JOBBATCHMASTER.JOB_YEARID=" & YearId & " ORDER BY JOBBATCHMASTER.JOB_NO")
                dt = objclsCMST.search(" ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(BATCHMASTER.jobbatch_no, 0) AS BATCHNO, BATCHMASTER.jobbatch_date AS DATE, ISNULL(BATCHMASTER.jobbatch_qty, 0) AS QTY, ISNULL(BATCHMASTER.jobbatch_TOTALSHEETS, '') AS TOTALSHEETS, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(BATCHMASTER.jobbatch_pono, '') AS PONO, ISNULL(ITEMMASTER.ITEM_MATERIALCODE, '')  AS MATERIALCODE ", "", " BATCHMASTER INNER JOIN LEDGERS ON BATCHMASTER.jobbatch_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON BATCHMASTER.jobbatch_itemid = ITEMMASTER.item_id  ", " AND ISNULL(BATCHMASTER.jobbatch_QCDONE,'FALSE') = 'TRUE' AND BATCHMASTER.jobbatch_YEARID=" & YearId & " ORDER BY BATCHMASTER.jobbatch_NO")
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

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Pending QC Entries.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc As System.Diagnostics.Process In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Pending QC Entries"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Pending QC Entries", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            'PENDING
            If RBPENDING.Checked = True Then
                Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
                For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                    Dim DTROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))
                    DT = OBJCMN.Execute_Any_String(" UPDATE BATCHMASTER SET BATCHMASTER.JOBBATCH_QCDONE = 'TRUE' WHERE JOBBATCH_NO = " & Val(DTROW("BATCHNO")) & " AND JOBBATCH_YEARID = " & YearId, "", "")
                Next
                MsgBox("Details Updated Successfully")
                fillgrid()
                gridbill.Focus()
            End If

            'ENTERED
            If RBENTERED.Checked = True Then
                Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
                For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                    Dim DTROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))
                    DT = OBJCMN.Execute_Any_String(" UPDATE BATCHMASTER SET BATCHMASTER.JOBBATCH_QCDONE = 'FALSE' WHERE JOBBATCH_NO = " & Val(DTROW("BATCHNO")) & " AND JOBBATCH_YEARID = " & YearId, "", "")
                Next
                MsgBox("Details Updated Successfully")
                fillgrid()
                gridbill.Focus()
            End If


            'DT = OBJCMN.Execute_Any_String("UPDATE CHALLAN SET CHALLAN.CHALLAN_SIGNRECD = 1 WHERE CHALLAN.CHALLAN_NO = " & Val(dtrow("CHALLANNO")) & "  AND CHALLAN.CHALLAN_YEARID = " & YearId, "", "")


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBPENDING_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBPENDING.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBENTERED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBENTERED.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class