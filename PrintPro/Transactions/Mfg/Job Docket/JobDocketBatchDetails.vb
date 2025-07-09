
Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class JobDocketBatchDetails

    Dim USERADD, USEREDIT, USERDELETE, USERVIEW As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub JobDocketBatchDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.E And e.Alt = True Then
                Call PrintToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Keys.R And e.Alt = True Then
                Call ToolStripRefresh_Click(sender, e)
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    Private Sub JobDocketBatchDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            fillgrid(" and dbo.JOBBATCHMASTER.JOB_yearid=" & YearId & " order by dbo.JOBBATCHMASTER.JOB_NO ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Sub fillgrid(ByVal tempcondition)
        Try
            Dim objcmn As New ClsCommon
            Dim dt As DataTable = objcmn.search(" JOBBATCHMASTER.job_no AS TEMPJOBNO, JOBBATCHMASTER.job_date AS JOBDATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(JOBBATCHMASTER.job_pono, '') AS PONO, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ITEMMASTER.item_name AS ITEMNAME, ISNULL(JOBBATCHMASTER.job_qty, 0) AS QTY, ISNULL(JOBBATCHMASTER.job_ordersrno, 0) AS ORDERGRIDNO, JOBBATCHMASTER.JOB_DONE AS DONE ,ISNULL(JOBBATCHMASTER.JOB_ASSEMBLYQTY, 0) AS ASSEMBLYQTY, ISNULL(JOBBATCHMASTER.JOB_DELOUTQTY, 0) AS DELOUTQTY, ISNULL(JOBBATCHMASTER.JOB_TOTAL, 0) AS TOTALSHEET", "", "JOBBATCHMASTER INNER JOIN ITEMMASTER ON JOBBATCHMASTER.job_itemid = ITEMMASTER.item_id INNER JOIN LEDGERS ON JOBBATCHMASTER.JOB_LEDGERID = LEDGERS.Acc_id", tempcondition)
            If ClientName = "AMR" Then
                GTOTALSHEET.Visible = False
                GPRODUCTIONQTY.Visible = False
                GDELOUTQTY.Visible = False

            ElseIf ClientName = "GANESHMUDRA" Then
                GASSEMBLYQTY.Visible = False
            End If
            GRIDJOBDETAILS.DataSource = dt
            If dt.Rows.Count > 0 Then
                GRIDJOB.FocusedRowHandle = GRIDJOB.RowCount - 1
                GRIDJOB.TopRowIndex = GRIDJOB.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal jobno As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And GridJob.RowCount > 0) Then
                Dim objjob As New JobDocketBatch
                objjob.MdiParent = MDIMain
                objjob.edit = editval
                objjob.TEMPJOBNO = jobno
                objjob.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ADDNEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDNEW.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, GRIDJOB.GetFocusedRowCellValue("TEMPJOBNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDJOB_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDJOB.DoubleClick
        Try
            showform(True, GRIDJOB.GetFocusedRowCellValue("TEMPJOBNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\JobDocket Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "JobDocket Details"
            GRIDJOB.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "JobDocket Details", GRIDJOB.VisibleColumns.Count + GRIDJOB.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripRefresh.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgrid(" and dbo.JOBBATCHMASTER.JOB_yearid=" & YearId & " order by dbo.JOBBATCHMASTER.JOB_NO ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub GRIDJOB_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GRIDJOB.RowStyle
        Try
            Dim DT As DataTable = GRIDJOBDETAILS.DataSource
            If e.RowHandle >= 0 Then
                Dim ROW As DataRow = DT.Rows(e.RowHandle)
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("DONE")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 10.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.Yellow
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class