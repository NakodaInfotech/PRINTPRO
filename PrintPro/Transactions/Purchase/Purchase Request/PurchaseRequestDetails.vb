Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class PurchaseRequestDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Public TEMPREQNO As String
    Public EDIT As Boolean

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub PurchaseRequestDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE REQUEST'")
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

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs)
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("TEMPREQNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    'Private Sub TOOLEXCEL_Click(sender As Object, e As EventArgs) Handles TOOLEXCEL.Click
    '    Try

    '        Dim PATH As String = Application.StartupPath & "\PROD ISSUE Details.XLS"
    '        Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
    '        opti.ShowGridLines = True
    '        opti.SheetName = "PROD ISSUE Details"
    '        gridbill.ExportToXls(PATH, opti)
    '        EXCELCMPHEADER(PATH, "PROD ISSUE Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
    '    Catch ex As Exception
    '        MsgBox("PROD ISSUE Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
    '    End Try
    'End Sub
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
    '            Dim OBJPO As New ProductionDesign
    '            OBJPO.MdiParent = MDIMain
    '            OBJPO.DIRECTPRINT = True
    '            OBJPO.FRMSTRING = "PRODISS"
    '            OBJPO.DIRECTMAIL = INVOICEMAIL
    '            OBJPO.DIRECTWHATSAPP = WHATSAPP
    '            OBJPO.PRINTSETTING = PrintDialog
    '            'OBJPO.PRINTPARTYDESIGN = PRINTPARTYDESIGN
    '            OBJPO.FORMULA = "{PRODUCTISSUE.ISS_NO}=" & Val(I) & " and {PRODUCTISSUE.ISS_YEARID}=" & YearId
    '            OBJPO.PRODNO = Val(I)
    '            OBJPO.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
    '            OBJPO.Show()
    '            OBJPO.Close()

    '            ALATTACHMENT.Add(Application.StartupPath & "\ProdIssReport_" & I & ".pdf")
    '            FILENAME.Add("ProdIssReport_" & I & ".pdf")
    '        Next

    '        If INVOICEMAIL Then
    '            Dim OBJMAIL As New SendMail
    '            OBJMAIL.ALATTACHMENT = ALATTACHMENT
    '            OBJMAIL.subject = "PRODUCTION"
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

    '            Dim OBJPO As New ProductionDesign
    '            OBJPO.MdiParent = MDIMain
    '            OBJPO.DIRECTPRINT = True
    '            OBJPO.FRMSTRING = "PRODISS"
    '            OBJPO.DIRECTMAIL = INVOICEMAIL
    '            OBJPO.DIRECTWHATSAPP = WHATSAPP
    '            OBJPO.PRINTSETTING = PrintDialog
    '            OBJPO.FORMULA = "{PRODUCTISSUE.ISS_NO}=" & Val(ROW("ISSNO")) & " and {PRODUCTISSUE.ISS_YEARID}=" & YearId
    '            OBJPO.PRODNO = Val(ROW("ISSNO"))
    '            OBJPO.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
    '            OBJPO.Show()
    '            OBJPO.Close()
    '            ALATTACHMENT.Add(Application.StartupPath & "\ProdIssReport_" & Val(ROW("ISSNO")) & ".pdf")
    '            FILENAME.Add("ProdIssReport_" & Val(ROW("ISSNO")) & ".pdf")
    '        Next

    '        If INVOICEMAIL Then
    '            Dim OBJMAIL As New SendMail
    '            OBJMAIL.ALATTACHMENT = ALATTACHMENT
    '            OBJMAIL.subject = "PRODUCTION"
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
            Dim OBJDEPT As New ClsPurchaseReq
            Dim DT As DataTable = OBJDEPT.SELECTPURCHASEREQ(0, CmpId, YearId)
            gridbilldetails.DataSource = DT
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub showform(ByVal editval As Boolean, ByVal TEMPREQNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objgdn As New PurchaseRequest
                objgdn.MdiParent = MDIMain
                objgdn.EDIT = editval
                objgdn.TEMPREQNO = TEMPREQNO
                objgdn.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub gridbilldetails_Click(sender As Object, e As EventArgs) Handles gridbilldetails.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("TEMPREQNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TXTFROM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFROM.KeyPress, TXTTO.KeyPress
        numkeypress(e, sender, Me)
    End Sub
End Class