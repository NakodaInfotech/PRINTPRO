
Imports BL
Public Class SchedulingDetails
    Dim USERADD, USEREDIT, USERDELETE, USERVIEW As Boolean
    Public TEMPSCHNO As Integer
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
    Private Sub SchedulingDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
    Private Sub SchedulingDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SCHEDULING'")
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
            Dim OBJDEPT As New ClsScheduling
            OBJDEPT.alParaval.Add(0)
            OBJDEPT.alParaval.Add(CmpId)
            OBJDEPT.alParaval.Add(YearId)
            Dim DT As DataTable = OBJDEPT.SELECTSCHEDULING(TEMPSCHNO, CmpId, YearId)
            GRIDJOBDETAILS.DataSource = DT
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub showform(ByVal editval As Boolean, ByVal SCHNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And GRIDJOB.RowCount > 0) Then
                Dim objjob As New Scheduling
                objjob.MdiParent = MDIMain
                objjob.EDIT = editval
                objjob.TEMPSCHNO = SCHNO
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
            showform(True, GRIDJOB.GetFocusedRowCellValue("TEMPSCHNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub GRIDJOB_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRIDJOB.DoubleClick
        Try
            showform(True, GRIDJOB.GetFocusedRowCellValue("TEMPSCHNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Docket Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Docket Details"
            GRIDJOB.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Docket Details", GRIDJOB.VisibleColumns.Count + GRIDJOB.GroupCount)
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
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class