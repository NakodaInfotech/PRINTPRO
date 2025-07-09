Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class GRNCheckingDetails
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub showform(ByVal EDITVAL As Boolean, ByVal CHKNO As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim OBJGRNCHK As New GRNChecking
            OBJGRNCHK.EDIT = EDITVAL
            OBJGRNCHK.MdiParent = MDIMain
            OBJGRNCHK.TEMPGRNCHKNO = CHKNO
            OBJGRNCHK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNCheckingDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.Alt = True And e.KeyCode = Keys.R Then
            Call ToolStripRefresh_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.P Then
            Call EXCELEXPORT_Click(sender, e)
        ElseIf e.KeyCode = Keys.OemQuotes Then
            e.SuppressKeyPress = True
        End If
    End Sub


    Private Sub GRNCheckingDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE INVOICE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim OBJGRNCHK As New ClsGRNChecking
            OBJGRNCHK.alParaval.Add(0)
            OBJGRNCHK.alParaval.Add(CmpId)
            OBJGRNCHK.alParaval.Add(YearId)
            Dim dttable As DataTable = OBJGRNCHK.selectGRNCHK()
            GridGRNCHKDetails.DataSource = dttable
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(True, GridInvoice.GetFocusedRowCellValue("CHKNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridGRNCHKDetails_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridGRNCHKDetails.DoubleClick
        Try
            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(True, GridInvoice.GetFocusedRowCellValue("CHKNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMDADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDADD.Click
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

    Private Sub ToolStripRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripRefresh.Click
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

    Private Sub EXCELEXPORT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCELEXPORT.Click
        Try

            Dim PATH As String = "D:\GRNChecking Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "GRNChecking Details"
            GridInvoice.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "GRNChecking Details", GridInvoice.VisibleColumns.Count + GridInvoice.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    'Private Sub GridInvoice_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridInvoice.RowStyle
    '    Try
    '        Dim DT As DataTable = GridGRNCHKDetails.DataSource
    '        If e.RowHandle >= 0 Then
    '            Dim ROW As DataRow = DT.Rows(e.RowHandle)
    '            Dim View As GridView = sender
    '            If View.GetRowCellDisplayText(e.RowHandle, View.Columns("CLOSE")) = "Checked" Then
    '                e.Appearance.Font = New System.Drawing.Font("CALIBRI", 10.0F, System.Drawing.FontStyle.Regular)
    '                e.Appearance.BackColor = Color.LightGreen
    '            ElseIf Val(View.GetRowCellDisplayText(e.RowHandle, View.Columns("OUTQTY"))) > 0 Then
    '                e.Appearance.Font = New System.Drawing.Font("CALIBRI", 10.0F, System.Drawing.FontStyle.Regular)
    '                e.Appearance.BackColor = Color.Yellow
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
End Class