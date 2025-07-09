Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class PurchaseOrderGridDetails
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT


    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub showform(ByVal EDITVAL As Boolean, ByVal PONO As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim OBJPO As New PurchaseOrder
            OBJPO.EDIT = EDITVAL
            OBJPO.MdiParent = MDIMain
            OBJPO.TEMPPONO = PONO
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseOrderDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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


    Private Sub PurchaseOrderDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            Dim OBJPO As New ClsPurchaseOrder
            OBJPO.alParaval.Add(0)
            OBJPO.alParaval.Add(CmpId)
            OBJPO.alParaval.Add(YearId)
            Dim dttable As DataTable = OBJPO.selectpurchaseorder()
            GridPODetails.DataSource = dttable
            If dttable.Rows.Count > 0 Then
                GridInvoice.FocusedRowHandle = GridInvoice.RowCount - 1
                GridInvoice.TopRowIndex = GridInvoice.RowCount - 15
            End If
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
            showform(True, GridInvoice.GetFocusedRowCellValue("PONO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub GridPODetails_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPODetails.DoubleClick
        Try
            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(True, GridInvoice.GetFocusedRowCellValue("PONO"))
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

            Dim PATH As String = Application.StartupPath & "\PurchaseOrder Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "PurchaseOrder  Details"
            GridInvoice.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "PurchaseOrder  Details", GridInvoice.VisibleColumns.Count + GridInvoice.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridInvoice_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridInvoice.RowStyle
        Try
            Dim DT As DataTable = GridPODetails.DataSource
            If e.RowHandle >= 0 Then
                Dim ROW As DataRow = DT.Rows(e.RowHandle)
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("CLOSED")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 10.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.LightGreen
                ElseIf Val(View.GetRowCellDisplayText(e.RowHandle, View.Columns("OUTQTY"))) > 0 Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 10.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.Yellow
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class