
Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid


Public Class GRNDetails
    Public edit As Boolean
    Dim USERADD, USEREDIT, USERDELETE, USERVIEW As Boolean

    Private Sub CMDEXIT_Click(sender As Object, e As EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub GRNDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
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
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    'Sub SERVERPROPSELECTED(Optional ByVal INVOICEMAIL As Boolean = False)
    '    Try
    '        Dim ALATTACHMENT As New ArrayList

    '        If INVOICEMAIL = False Then If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
    '        For I As Integer = 0 To Val(GRIDGRN.RowCount - 1)
    '            Dim ROW As DataRow = GRIDGRN.GetDataRow(I)
    '            If ROW("CHK") = True Then
    '                Dim OBJINVOICE As New GRNDesign
    '                OBJINVOICE.MdiParent = MDIMain
    '                OBJINVOICE.DIRECTPRINT = True
    '                OBJINVOICE.FRMSTRING = "GRNDTLS"
    '                OBJINVOICE.DIRECTMAIL = INVOICEMAIL
    '                ' OBJINVOICE.registername = CMBREGISTER.Text.Trim
    '                OBJINVOICE.PRINTSETTING = PRINTDIALOG
    '                OBJINVOICE.GRNNO = Val(ROW("GRNNO"))
    '                OBJINVOICE.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
    '                OBJINVOICE.Show()
    '                OBJINVOICE.Close()
    '                ALATTACHMENT.Add(Application.StartupPath & "\INVOICE_" & Val(ROW("GRNNO")) & ".pdf")
    '            End If
    '        Next

    '        If INVOICEMAIL Then
    '            Dim OBJMAIL As New SendMail
    '            OBJMAIL.ALATTACHMENT = ALATTACHMENT
    '            OBJMAIL.subject = "Invoice"
    '            OBJMAIL.ShowDialog()
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub PRINTTOOL_Click(sender As Object, e As EventArgs) Handles PRINTTOOL.Click
    '    Try
    '        If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso GRIDGRN.SelectedRowsCount = 0 Then Exit Sub


    '        'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
    '        If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
    '            If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
    '                MsgBox("Enter Proper Invoice Nos", MsgBoxStyle.Critical)
    '                Exit Sub
    '            End If
    '            If MsgBox("Wish to Print Invoice from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
    '                SERVERPROPDIRECT()
    '            End If
    '        Else
    '            If MsgBox("Wish to Print Selected Invoice ?", MsgBoxStyle.YesNo) = vbYes Then
    '                CMDEDIT.Focus()
    '                SERVERPROPSELECTED()
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
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

    Private Sub ADDNEW_Click(sender As Object, e As EventArgs) Handles ADDNEW.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            SHOWFORM(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(sender As Object, e As EventArgs) Handles CMDOK.Click
        Try
            SHOWFORM(True, GRIDGRN.GetFocusedRowCellValue("GRNNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GRN'")
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

    Private Sub EXCELEXPORT_Click(sender As Object, e As EventArgs) Handles EXCELEXPORT.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Sale GRN Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Sale GRN Details"
            GRIDGRN.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Sale GRN Details", GRIDGRN.VisibleColumns.Count + GRIDGRN.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()

        Try
            If (USEREDIT = False And USERVIEW = False) Then
                MsgBox("Insuffincient Rights")
                Exit Sub
            End If
            Dim OBJCMN As New ClsCommonMaster
            Dim DT As DataTable = OBJCMN.search(" CAST(0 AS BIT) AS CHK, GRN.GRN_NO AS GRNNO, GRN.GRN_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(GRN.GRN_DELDAYS, 0) AS DELDAYS, GRN.GRN_DELDATE AS DELDATE, GODOWNMASTER.GODOWN_name AS GODOWN, ISNULL(TRANSLEDGER.Acc_cmpname, '') AS TRANSPORT, ISNULL(GRN.GRN_LRNO, '0') AS LRNO, GRN.GRN_LRDATE AS LRDATE, ISNULL(GRN.GRN_PONO, '0') AS PONO, GRN.GRN_PODATE AS PODATE, ISNULL(GRN.GRN_CHALLANNO, 0) AS CHALLANNO, GRN.GRN_CHALLANDATE AS CHALLANDATE, ISNULL(GRN.GRN_REMARKS, '') AS REMARKS, ISNULL(GRN.GRN_TOTALQTY, 0) AS TOTALQTY, ISNULL(GRN.GRN_TOTALSHEETS, 0) AS TOTALSHEETS, ISNULL(GRN.GRN_BILLNO,'') AS BILLNO ", "", " GRN INNER JOIN LEDGERS ON GRN.GRN_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN GODOWNMASTER ON GRN.GRN_GODOWNID = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGER ON GRN.GRN_TRANSID = TRANSLEDGER.Acc_id ", " AND GRN.GRN_YEARID = " & YearId & " ORDER BY GRN.GRN_NO ")
            GridGrnDetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                GRIDGRN.FocusedRowHandle = GRIDGRN.RowCount - 1
                GRIDGRN.TopRowIndex = GRIDGRN.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SHOWFORM(ByVal EDITVAL As Boolean, ByVal GRNNO As Integer)
        Try
            If (EDITVAL = True And USEREDIT = False And USERVIEW = False) Or (EDITVAL = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (EDITVAL = False) Or (EDITVAL = True And GRIDGRN.RowCount > 0) Then
                Dim OBJGRN As New GRN
                OBJGRN.MdiParent = MDIMain
                OBJGRN.EDIT = EDITVAL
                OBJGRN.TEMPGRNNO = GRNNO
                OBJGRN.Show()
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Private Sub TOOLGRIDDETAILS_Click(sender As Object, e As EventArgs) Handles TOOLGRIDDETAILS.Click
        Try
            Dim OBJGRN As New GRNGridDetails
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PRINTTOOL_Click(sender As Object, e As EventArgs) Handles PRINTTOOL.Click

        If (Val(TXTFROM.Text.Trim) = 0 And (Val(TXTTO.Text.Trim) = 0) AndAlso GRIDGRN.SelectedRowsCount = 0) Then Exit Sub
        If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
            If (Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim)) Then
                MsgBox("Pls Enter Proper GRN No.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            If MsgBox("Wish to Print GRN Deails from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
                SERVERPROPDIRECT()
            End If
        Else
            If MsgBox("Wish to Print Selected GRN Details ?", MsgBoxStyle.YesNo) = vbYes Then
                ' CMDEDIT.Focus()
                SERVERPROPSELECTED()
            End If
        End If

    End Sub

    Sub SERVERPROPDIRECT(Optional ByVal INVOICEMAIL As Boolean = False)
        Try
            Dim ALATTACHMENT As New ArrayList
            If INVOICEMAIL = False Then If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
                Dim OBJINVOICE As New GRNDesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.DIRECTPRINT = True
                OBJINVOICE.FRMSTRING = "GRNDTLS"
                OBJINVOICE.DIRECTMAIL = INVOICEMAIL
                '   OBJINVOICE.registername = CMBREGISTER.Text.Trim
                OBJINVOICE.PRINTSETTING = PRINTDIALOG
                OBJINVOICE.WHERECLAUSE = "{GRN.GRN_no}=" & Val(I) & " AND {GRN.GRN_yearid}=" & YearId

                'OBJINVOICE.FORMULA = "{GRN.GRN_NO}=" & Val(I) & " and {GRN.GRN_YEARID}=" & YearId
                OBJINVOICE.GRNNO = Val(I)
                OBJINVOICE.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJINVOICE.Show()
                OBJINVOICE.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\GRNDetails_" & I & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "GRN REPORT"
                OBJMAIL.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SERVERPROPSELECTED(Optional ByVal INVOICEMAIL As Boolean = False)
        Try

            Dim ALATTACHMENT As New ArrayList

            If INVOICEMAIL = False Then If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
            For I As Integer = 0 To Val(GRIDGRN.RowCount - 1)
                Dim ROW As DataRow = GRIDGRN.GetDataRow(I)
                If ROW("CHK") = True Then
                    Dim OBJINVOICE As New GRNDesign
                    OBJINVOICE.MdiParent = MDIMain
                    OBJINVOICE.DIRECTPRINT = True
                    OBJINVOICE.FRMSTRING = "GRNDTLS"
                    OBJINVOICE.DIRECTMAIL = INVOICEMAIL
                    ' OBJINVOICE.registername = CMBREGISTER.Text.Trim
                    OBJINVOICE.PRINTSETTING = PRINTDIALOG
                    OBJINVOICE.WHERECLAUSE = "{GRN.GRN_no}=" & Val(ROW("GRNNO")) & " AND  {GRN.GRN_yearid}=" & YearId
                    OBJINVOICE.GRNNO = Val(ROW("GRNNO"))
                    OBJINVOICE.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                    OBJINVOICE.Show()
                    OBJINVOICE.Close()
                    ALATTACHMENT.Add(Application.StartupPath & "\GRNDetails" & Val(ROW("GRNNO")) & ".pdf")
                End If
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "GRN REPORT"
                OBJMAIL.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub GRIDGRN_DoubleClick(sender As Object, e As EventArgs) Handles GRIDGRN.DoubleClick
        Try
            SHOWFORM(True, GRIDGRN.GetFocusedRowCellValue("GRNNO"))
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
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub GRIDGRN_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GRIDGRN.RowStyle
    '    Try
    '        'Dim DT As DataTable = GridGrnDetails.DataSource
    '        'If e.RowHandle >= 0 Then
    '        '    Dim ROW As DataRow = DT.Rows(e.RowHandle)
    '        '    Dim View As GridView = sender
    '        '    If View.GetRowCellDisplayText(e.RowHandle, View.Columns("DONE")) = "Checked" Then
    '        '        e.Appearance.Font = New System.Drawing.Font("CALIBRI", 10.0F, System.Drawing.FontStyle.Regular)
    '        '        e.Appearance.BackColor = Color.Yellow
    '        '    End If
    '        'End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub


End Class