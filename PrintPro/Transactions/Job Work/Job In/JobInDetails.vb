Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class JobInDetails


    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    'Public TEMPJONO As String


    Public TEMPPORFORMA As String
    Public TEMPJONO As Integer

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
    Private Sub JobInDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'JOBOUT'")
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

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
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


    Private Sub JobInDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("TEMPJONO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TOOLEXCEL_Click(sender As Object, e As EventArgs)
        Try

            Dim PATH As String = Application.StartupPath & "\Job In Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Job In Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Job in Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Job In Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub
    'Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
    '    Try
    '        If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub
    '        'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
    '        If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
    '            If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
    '                MsgBox("Enter Proper PO Nos", MsgBoxStyle.Critical)
    '                Exit Sub
    '            Else
    '                If MsgBox("Wish to Whatsapp PO from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
    '                SERVERPROPDIRECT(False, True)
    '            End If
    '        Else
    '            If MsgBox("Wish to Whatsapp Selected PO ?", MsgBoxStyle.YesNo) = vbYes Then
    '                SERVERPROPSELECTED(False, True)
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    'Sub SERVERPROPDIRECT(Optional ByVal INVOICEMAIL As Boolean = False, Optional ByVal WHATSAPP As Boolean = False)
    '    Try
    '        Dim PRINTPARTYDESIGN As Boolean = False
    '        Dim ALATTACHMENT As New ArrayList
    '        Dim FILENAME As New ArrayList
    '        If INVOICEMAIL = False And WHATSAPP = False Then
    '            If PrintDialog.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PrintDialog.PrinterSettings Else Exit Sub
    '        End If
    '        For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
    '            Dim OBJPO As New SaleInvoiceDesign
    '            OBJPO.MdiParent = MDIMain
    '            OBJPO.DIRECTPRINT = True
    '            OBJPO.FRMSTRING = "JOBOUT"
    '            OBJPO.DIRECTMAIL = INVOICEMAIL
    '            OBJPO.DIRECTWHATSAPP = WHATSAPP
    '            OBJPO.PRINTSETTING = PrintDialog
    '            'OBJPO.PRINTPARTYDESIGN = PRINTPARTYDESIGN
    '            OBJPO.FORMULA = "{SALEORDER.SO_NO}=" & Val(I) & " and {SALEORDER.SO_YEARID}=" & YearId
    '            OBJPO.INVNO = Val(I)
    '            OBJPO.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
    '            OBJPO.Show()
    '            OBJPO.Close()

    '            ALATTACHMENT.Add(Application.StartupPath & "\JOREPORT_" & I & ".pdf")
    '            FILENAME.Add("JOREPORT_" & I & ".pdf")
    '        Next

    '        If INVOICEMAIL Then
    '            Dim OBJMAIL As New SendMail
    '            OBJMAIL.ALATTACHMENT = ALATTACHMENT
    '            OBJMAIL.subject = "JOREPORT"
    '            OBJMAIL.ShowDialog()
    '        End If

    '        If WHATSAPP = True Then
    '            Dim OBJWHATSAPP As New SendMultipleWhatsapp
    '            OBJWHATSAPP.PATH = ALATTACHMENT
    '            OBJWHATSAPP.FILENAME = FILENAME
    '            OBJWHATSAPP.ShowDialog()
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Sub SERVERPROPSELECTED(Optional ByVal INVOICEMAIL As Boolean = False, Optional ByVal WHATSAPP As Boolean = False)
    '    Try


    '        Dim ALATTACHMENT As New ArrayList
    '        Dim FILENAME As New ArrayList
    '        If INVOICEMAIL = False And WHATSAPP = False Then
    '            If PrintDialog.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PrintDialog.PrinterSettings Else Exit Sub
    '        End If
    '        Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
    '        For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
    '            Dim ROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))

    '            Dim OBJPO As New SaleInvoiceDesign
    '            OBJPO.MdiParent = MDIMain
    '            OBJPO.DIRECTPRINT = True
    '            OBJPO.FRMSTRING = "JOBOUT"
    '            OBJPO.DIRECTMAIL = INVOICEMAIL
    '            OBJPO.DIRECTWHATSAPP = WHATSAPP
    '            OBJPO.PRINTSETTING = PrintDialog
    '            OBJPO.JONO = Val(ROW("TEMPJONO"))
    '            OBJPO.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
    '            OBJPO.Show()
    '            OBJPO.Close()
    '            ALATTACHMENT.Add(Application.StartupPath & "\JOREPORT_" & Val(ROW("TEMPJONO")) & ".pdf")
    '            FILENAME.Add("JOREPORT_" & Val(ROW("TEMPJONO")) & ".pdf")
    '        Next

    '        If INVOICEMAIL Then
    '            Dim OBJMAIL As New SendMail
    '            OBJMAIL.ALATTACHMENT = ALATTACHMENT
    '            OBJMAIL.subject = "JOREPORT"
    '            OBJMAIL.ShowDialog()
    '        End If

    '        If WHATSAPP = True Then
    '            Dim OBJWHATSAPP As New SendWhatsapp
    '            OBJWHATSAPP.PATH = ALATTACHMENT
    '            OBJWHATSAPP.FILENAME = FILENAME
    '            OBJWHATSAPP.ShowDialog()
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub TOOLMAIL_Click(sender As Object, e As EventArgs) Handles TOOLMAIL.Click
    '    Try
    '        If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub
    '        'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
    '        If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
    '            If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
    '                MsgBox("Enter Proper SO Nos", MsgBoxStyle.Critical)
    '                Exit Sub
    '            Else
    '                If MsgBox("Wish to Mail SO from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
    '                SERVERPROPDIRECT(True)
    '            End If
    '        Else
    '            If MsgBox("Wish to Mail Selected SO ?", MsgBoxStyle.YesNo) = vbYes Then
    '                SERVERPROPSELECTED(True)
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    Sub FILLGRID()
        Try
            Dim OBJDEPT As New ClsJobIn
            Dim DT As DataTable = OBJDEPT.SELECTJOBIN(TEMPJONO, CmpId, YearId)
            gridbilldetails.DataSource = DT
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub





    'Private Sub TOOLPRINT_Click(sender As Object, e As EventArgs) Handles TOOLPRINT.Click
    '    Try
    '        If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub


    '        'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
    '        If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
    '            If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
    '                MsgBox("Enter Proper Sale Order Nos", MsgBoxStyle.Critical)
    '                Exit Sub
    '            End If

    '            If MsgBox("Wish to Print Sale Order from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
    '                SERVERPROPDIRECT()
    '            End If
    '        Else
    '            If MsgBox("Wish to Print Selected Sale Order ?", MsgBoxStyle.YesNo) = vbYes Then
    '                SERVERPROPSELECTED()
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    Sub showform(ByVal editval As Boolean, ByVal TEMPJONO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objgdn As New JobIn
                objgdn.MdiParent = MDIMain
                objgdn.edit = editval
                objgdn.TEMPJONO = TEMPJONO
                objgdn.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub gridbilldetails_DoubleClick(sender As Object, e As EventArgs) Handles gridbilldetails.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("TEMPJONO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TXTFROM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFROM.KeyPress, TXTTO.KeyPress
        numkeypress(e, sender, Me)
    End Sub
End Class
