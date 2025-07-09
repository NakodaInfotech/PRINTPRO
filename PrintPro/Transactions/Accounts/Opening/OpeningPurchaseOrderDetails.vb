Imports BL
Public Class OpeningPurchaseOrderDetails
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
            Dim OBJPO As New OpeningPurchaseOrder
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
            If (USEREDIT = False And USERVIEW = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim OBJMID As New ClsCommon
            Dim DT As DataTable = OBJMID.search(" CAST(0 AS BIT) AS CHK,OPENINGPURCHASEORDER.OPO_NO AS PONO, OPENINGPURCHASEORDER.OPO_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, OPENINGPURCHASEORDER.OPO_DELDAYS AS DELDAYS, OPENINGPURCHASEORDER.OPO_DELDATE AS DELDATE, OPENINGPURCHASEORDER.OPO_SHEETSPERREAM AS SHEETSPERREAM, OPENINGPURCHASEORDER.OPO_TOTALQTY AS TOTALQTY, OPENINGPURCHASEORDER.OPO_TOTALAMT AS TOTALAMT, OPENINGPURCHASEORDER.OPO_REMARKS AS REMARKS ", "", " OPENINGPURCHASEORDER INNER JOIN LEDGERS ON OPENINGPURCHASEORDER.OPO_LEDGERID = LEDGERS.Acc_id  ", "  AND OPENINGPURCHASEORDER.OPO_YEARID = " & YearId & " ORDER BY OPENINGPURCHASEORDER.OPO_NO ")
            GridPODetails.DataSource = DT
            If DT.Rows.Count > 0 Then
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

    Private Sub TOOLMAIL_Click(sender As Object, e As EventArgs) Handles TOOLMAIL.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso GridInvoice.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Invoice Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Mail Invoice from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT(True)
                End If
            Else
                If MsgBox("Wish to Mail Selected Invoice ?", MsgBoxStyle.YesNo) = vbYes Then
                    'CMDEDIT.Focus()
                    SERVERPROPSELECTED(True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLGRIDDETAILS_Click(sender As Object, e As EventArgs) Handles TOOLGRIDDETAILS.Click
        Try
            Dim OBJMIGD As New OpeningPurchaseOrderGridDetails
            OBJMIGD.MdiParent = MDIMain
            OBJMIGD.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EXCELEXPORT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCELEXPORT.Click
        Try

            Dim PATH As String = Application.StartupPath & "\OpeningPurchase Order Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "OpeningPurchase Order  Details"
            GridInvoice.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "OpeningPurchase Order  Details", GridInvoice.VisibleColumns.Count + GridInvoice.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        If (Val(TXTFROM.Text.Trim) = 0 And (Val(TXTTO.Text.Trim) = 0) AndAlso GridInvoice.SelectedRowsCount = 0) Then Exit Sub
        If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
            If (Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim)) Then
                MsgBox("Pls Enter Proper Invoice No.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            If MsgBox("Wish to Print Invoice from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
                SERVERPROPDIRECT()
            End If
        Else
            If MsgBox("Wish to Print Selected Invoice ?", MsgBoxStyle.YesNo) = vbYes Then
                ' CMDEDIT.Focus()
                SERVERPROPSELECTED()
            End If
        End If
    End Sub

    Private Sub GridInvoice_DoubleClick(sender As Object, e As EventArgs) Handles GridInvoice.DoubleClick
        Try
            showform(True, GridInvoice.GetFocusedRowCellValue("PONO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub SERVERPROPDIRECT(Optional ByVal INVOICEMAIL As Boolean = False)
        Try
            Dim ALATTACHMENT As New ArrayList
            If INVOICEMAIL = False Then If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
                Dim OBJINVOICE As New PODesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.DIRECTPRINT = True
                OBJINVOICE.FRMSTRING = "PO"
                OBJINVOICE.DIRECTMAIL = INVOICEMAIL
                '   OBJINVOICE.registername = CMBREGISTER.Text.Trim
                OBJINVOICE.PRINTSETTING = PRINTDIALOG
                OBJINVOICE.INVNO = Val(I)
                OBJINVOICE.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJINVOICE.Show()
                OBJINVOICE.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\PURCHASE_" & I & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "Sale Order"
                OBJMAIL.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SERVERPROPSELECTED(Optional ByVal INVOICEMAIL As Boolean = False)
        Try

            Dim ALATTACHMENT As New ArrayList

            If INVOICEMAIL = False Then If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            For I As Integer = 0 To Val(GridInvoice.RowCount - 1)
                Dim ROW As DataRow = GridInvoice.GetDataRow(I)
                If ROW("CHK") = True Then
                    Dim OBJINVOICE As New PODesign
                    OBJINVOICE.MdiParent = MDIMain
                    OBJINVOICE.DIRECTPRINT = True
                    OBJINVOICE.FRMSTRING = "PO"
                    OBJINVOICE.DIRECTMAIL = INVOICEMAIL
                    ' OBJINVOICE.registername = CMBREGISTER.Text.Trim
                    OBJINVOICE.PRINTSETTING = PRINTDIALOG
                    OBJINVOICE.INVNO = Val(ROW("PONO"))
                    OBJINVOICE.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                    OBJINVOICE.Show()
                    OBJINVOICE.Close()
                    ALATTACHMENT.Add(Application.StartupPath & "\PURCAHSE" & Val(ROW("PONO")) & ".pdf")
                End If
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "Sale Order"
                OBJMAIL.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class