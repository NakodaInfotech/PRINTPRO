Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid


Public Class BatchGridDetails

    Dim USERADD, USEREDIT, USERDELETE, USERVIEW As Boolean
    Dim TEMPBATCHNO As Integer

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
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

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub ADDNEW_Click(sender As Object, e As EventArgs) Handles ADDNEW.Click
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

    Private Sub ToolStripRefresh_Click(sender As Object, e As EventArgs) Handles ToolStripRefresh.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgrid()
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

    Sub fillgrid()
        Try
            Dim OBJPO As New ClsBatch
            OBJPO.alParaval.Add(0)
            '' OBJPO.alParaval.Add(CmpId)
            OBJPO.alParaval.Add(YearId)
            Dim dttable As DataTable = OBJPO.selectNO
            GRIDJOBDETAILS.DataSource = dttable
            If dttable.Rows.Count > 0 Then
                GRIDJOB.FocusedRowHandle = GRIDJOB.RowCount - 1
                GRIDJOB.TopRowIndex = GRIDJOB.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(sender As Object, e As EventArgs) Handles CMDOK.Click
        Try
            showform(True, GRIDJOB.GetFocusedRowCellValue("BATCHNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDJOB_DoubleClick(sender As Object, e As EventArgs) Handles GRIDJOB.DoubleClick
        Try
            showform(True, GRIDJOB.GetFocusedRowCellValue("BATCHNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BatchGridDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            Throw ex
        End Try
    End Sub

    Private Sub BatchGridDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'JOB DOCKET'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BatchGridDetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If HIDEAUDITREMARKS = True Then
                GPLATEREMARKS.Visible = False
                GFOLDREMARKS.Visible = False
                ' GPAPERREMARKS.Visible = False
                GPRINTREMARKS.Visible = False
                GSORTREMARKS.Visible = False
                'GUNFOLDREMARKS.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class