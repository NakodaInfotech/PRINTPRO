Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class BatchDetails

    Dim USERADD, USEREDIT, USERDELETE, USERVIEW As Boolean

    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub BatchDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub BatchDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            fillgrid(" and dbo.BATCHMASTER.JOBBATCH_yearid=" & YearId & " order by dbo.BATCHMASTER.JOBBATCH_NO ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tempcondition)
        Try
            Dim objcmn As New ClsCommon
            Dim dt As DataTable = objcmn.search("BATCHMASTER.jobbatch_no AS BATCHNO, BATCHMASTER.jobbatch_date AS BATCHDATE, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE,ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(BATCHMASTER.jobbatch_qty, 0) AS QTY, ISNULL(BATCHMASTER.jobbatch_madeqty, 0) AS MADEQTY, ISNULL((CASE WHEN BATCHMASTER.jobbatch_tempprocessno = 1 THEN 'Positive' WHEN BATCHMASTER.jobbatch_tempprocessno = 2 THEN 'Plate' WHEN BATCHMASTER.jobbatch_tempprocessno = 3 THEN 'Paper Cutting' WHEN BATCHMASTER.jobbatch_tempprocessno = 4 THEN 'Printing' WHEN BATCHMASTER.jobbatch_tempprocessno = 5 THEN 'Full Sheet Sorting' WHEN BATCHMASTER.jobbatch_tempprocessno = 6 THEN 'Leaflet Full Sheet Cutting' WHEN BATCHMASTER.jobbatch_tempprocessno = 7 THEN 'Leaflet Sorting' WHEN BATCHMASTER.jobbatch_tempprocessno = 8 THEN 'Folding' WHEN BATCHMASTER.jobbatch_tempprocessno = 9 THEN 'Packing' WHEN BATCHMASTER.jobbatch_tempprocessno = 10 THEN 'Final' WHEN BATCHMASTER.jobbatch_tempprocessno = 11 THEN 'Completed' END), 0) AS PROCESSNO, BATCHMASTER.jobbatch_DONE AS DONE, ISNULL(ORDERMASTER_DESC.ORDER_BASICRATE, 0) AS RATE, (ISNULL(ORDERMASTER_DESC.ORDER_BASICRATE, 0)*ISNULL(BATCHMASTER.jobbatch_qty, 0)) AS AMOUNT, ISNULL(LEDGERS.ACC_CMPNAME,'') AS NAME, ISNULL(BATCHMASTER.JOBBATCH_PONO,'') AS PONO, ORDERMASTER.ORDER_DELDATE AS DELDATE, BATCHMASTER.jobbatch_modified AS PROCESSDATE", "", "  BATCHMASTER LEFT OUTER JOIN JOBBATCHMASTER ON BATCHMASTER.jobbatch_docketno = JOBBATCHMASTER.job_no AND BATCHMASTER.jobbatch_yearid = JOBBATCHMASTER.job_yearid LEFT OUTER JOIN ITEMMASTER ON BATCHMASTER.jobbatch_itemid = ITEMMASTER.item_id LEFT OUTER JOIN ORDERMASTER_DESC ON JOBBATCHMASTER.job_orderno = ORDERMASTER_DESC.ORDER_NO AND JOBBATCHMASTER.job_ordersrno = ORDERMASTER_DESC.ORDER_GRIDSRNO AND  JOBBATCHMASTER.job_yearid = ORDERMASTER_DESC.ORDER_YEARID LEFT OUTER JOIN ORDERMASTER ON ORDERMASTER_DESC.ORDER_NO = ORDERMASTER.ORDER_NO AND ORDERMASTER_DESC.ORDER_YEARID = ORDERMASTER.ORDER_YEARID LEFT OUTER JOIN LEDGERS ON BATCHMASTER.JOBBATCH_LEDGERID = LEDGERS.Acc_id ", tempcondition)
            GRIDJOBDETAILS.DataSource = dt
            If dt.Rows.Count > 0 Then
                GridJob.FocusedRowHandle = GridJob.RowCount - 1
                GridJob.TopRowIndex = GridJob.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal batchno As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And GRIDJOB.RowCount > 0) Then
                Dim objjob As New Batch
                objjob.MdiParent = MDIMain
                objjob.edit = editval
                objjob.TEMPBATCHNO = batchno
                objjob.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ADDNEW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ADDNEW.Click
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

    Private Sub CMDOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, GRIDJOB.GetFocusedRowCellValue("BATCHNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDJOB_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDJOB.DoubleClick
        Try
            showform(True, GRIDJOB.GetFocusedRowCellValue("BATCHNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLGRIDDETAILS_Click(sender As Object, e As EventArgs) Handles TOOLGRIDDETAILS.Click
        Try
            Dim OBJBTH As New BatchGridDetails
            OBJBTH.MdiParent = MDIMain
            OBJBTH.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Batch Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Batch Details"
            GRIDJOB.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Batch Details", GRIDJOB.VisibleColumns.Count + GRIDJOB.GroupCount)
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
            fillgrid(" and dbo.BATCHMASTER.JOBBATCH_yearid=" & YearId & " order by dbo.BATCHMASTER.JOBBATCH_NO ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDJOB_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GRIDJOB.RowStyle
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