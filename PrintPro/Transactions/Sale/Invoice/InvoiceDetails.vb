
Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class InvoiceDetails
    Dim TEMPREGID As Integer
    Dim USERADD, USEREDIT, USERDELETE, USERVIEW As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub InvoicemasterDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.E And e.Alt = True Then
                Call PrintToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Keys.R And e.Alt = True Then
                Call ToolStripRefresh_Click(sender, e)
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                SHOWFROM(False, 0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            SHOWFROM(True, GridInvoice.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID(ByVal TEMPCONDITION)
        Try
            Dim OBJCMN As New ClsCommonMaster
            'Dim DT As DataTable = OBJCMN.search(" INVOICEMASTER.invoice_no AS SRNO, LEDGERS.Acc_cmpname AS NAME, INVOICEMASTER.invoice_date AS DATE, INVOICEMASTER.INVOICE_PONO AS PONO, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(INVOICEMASTER_DESC.INVOICE_QTY, 0) AS QTY,ISNULL(INVOICEMASTER.invoice_processing, 0) AS PROCHGS, ISNULL(OTHERCHGSLEDGER.Acc_cmpname, '') AS OTHERCHGSNAME, ISNULL(INVOICEMASTER.invoice_OTHERCHGS, 0) AS OTHERCHGSAMT, ISNULL(INVOICEMASTER.invoice_pakagingchgs, 0) AS PACKAGCHGS, ISNULL(INVOICEMASTER.INVOICE_SUBTOTAL, 0) AS SUBTOTAL, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, ISNULL(INVOICEMASTER.INVOICE_TAXAMT, 0) AS TAXAMT, ISNULL(EXTRACHGSLEDGERS.Acc_cmpname, '') AS EXTRACHGSNAME, ISNULL(INVOICEMASTER.INVOICE_EXTRACHGS, 0) AS EXTRACHGSAMT, ISNULL(INVOICEMASTER.invoice_roundoff, 0) AS ROUNDOFF, ISNULL(INVOICEMASTER.INVOICE_TOTALAMT, 0) AS TOTALAMT, ISNULL(INVOICEMASTER.invoice_grandtotal, 0) AS GRANDTOTAL", "", " INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICEMASTER.invoice_registerid = REGISTERMASTER.register_id INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id INNER JOIN INVOICEMASTER_DESC ON INVOICEMASTER.invoice_no = INVOICEMASTER_DESC.INVOICE_NO AND INVOICEMASTER.invoice_registerid = INVOICEMASTER_DESC.INVOICE_REGISTERID AND INVOICEMASTER.invoice_yearid = INVOICEMASTER_DESC.INVOICE_YEARID INNER JOIN ITEMMASTER ON INVOICEMASTER_DESC.INVOICE_ITEMNAMEID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS AS EXTRACHGSLEDGERS ON INVOICEMASTER.INVOICE_EXTRACHGSNAME = EXTRACHGSLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS OTHERCHGSLEDGER ON INVOICEMASTER.INVOICE_OTHERCHGSNAME = OTHERCHGSLEDGER.Acc_id LEFT OUTER JOIN TAXMASTER ON INVOICEMASTER.INVOICE_TAXID = TAXMASTER.tax_id ", TEMPCONDITION)
            'Dim DT As DataTable = OBJCMN.search(" INVOICEMASTER.invoice_no AS SRNO, LEDGERS.Acc_cmpname AS NAME, INVOICEMASTER.invoice_date AS DATE, INVOICEMASTER.INVOICE_PONO AS PONO, ISNULL(INVOICEMASTER.INVOICE_EWAYBILLNO,'') AS EWAYBILLNO, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(INVOICEMASTER_DESC.INVOICE_QTY, 0) AS QTY, ISNULL(INVOICEMASTER.invoice_processing, 0) AS PROCHGS, ISNULL(OTHERCHGSLEDGER.Acc_cmpname, '') AS OTHERCHGSNAME, ISNULL(INVOICEMASTER.invoice_OTHERCHGS, 0) AS OTHERCHGSAMT, ISNULL(INVOICEMASTER.invoice_pakagingchgs, 0) AS PACKAGCHGS, ISNULL(INVOICEMASTER.INVOICE_SUBTOTAL, 0) AS SUBTOTAL, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, ISNULL(INVOICEMASTER.INVOICE_TAXAMT, 0) AS TAXAMT, ISNULL(EXTRACHGSLEDGERS.Acc_cmpname, '') AS EXTRACHGSNAME, ISNULL(INVOICEMASTER.INVOICE_EXTRACHGS, 0) AS EXTRACHGSAMT, ISNULL(INVOICEMASTER.invoice_roundoff, 0) AS ROUNDOFF, ISNULL(INVOICEMASTER.INVOICE_TOTALAMT, 0) AS TOTALAMT, ISNULL(INVOICEMASTER.invoice_grandtotal, 0) AS GRANDTOTAL, ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) AS TOTALTAXABLEAMT, ISNULL(INVOICEMASTER.INVOICE_TOTALCGSTAMT, 0) AS TOTALCGSTAMT, ISNULL(INVOICEMASTER.INVOICE_TOTALSGSTAMT, 0) AS TOTALSGSTAMT, ISNULL(INVOICEMASTER.INVOICE_TOTALIGSTAMT, 0) AS TOTALIGSTAMT", "", " INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICEMASTER.invoice_registerid = REGISTERMASTER.register_id INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id INNER JOIN INVOICEMASTER_DESC ON INVOICEMASTER.invoice_no = INVOICEMASTER_DESC.INVOICE_NO AND INVOICEMASTER.invoice_registerid = INVOICEMASTER_DESC.INVOICE_REGISTERID AND INVOICEMASTER.invoice_yearid = INVOICEMASTER_DESC.INVOICE_YEARID INNER JOIN ITEMMASTER ON INVOICEMASTER_DESC.INVOICE_ITEMNAMEID = ITEMMASTER.item_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN CITYMASTER ON LEDGERS.Acc_cityid = CITYMASTER.city_id LEFT OUTER JOIN LEDGERS AS EXTRACHGSLEDGERS ON INVOICEMASTER.INVOICE_EXTRACHGSNAME = EXTRACHGSLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS OTHERCHGSLEDGER ON INVOICEMASTER.INVOICE_OTHERCHGSNAME = OTHERCHGSLEDGER.Acc_id LEFT OUTER JOIN TAXMASTER ON INVOICEMASTER.INVOICE_TAXID = TAXMASTER.tax_id ", TEMPCONDITION)
            Dim DT As DataTable = OBJCMN.search("INVOICEMASTER.invoice_no AS SRNO, LEDGERS.Acc_cmpname AS NAME, INVOICEMASTER.invoice_date AS DATE, INVOICEMASTER.INVOICE_PONO AS PONO, ISNULL(INVOICEMASTER.INVOICE_EWAYBILLNO,'') AS EWAYBILLNO, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(INVOICEMASTER_DESC.INVOICE_QTY, 0) AS QTY, ISNULL(INVOICEMASTER.invoice_processing, 0) AS PROCHGS, ISNULL(OTHERCHGSLEDGER.Acc_cmpname, '') AS OTHERCHGSNAME, ISNULL(INVOICEMASTER.invoice_OTHERCHGS, 0) AS OTHERCHGSAMT, ISNULL(INVOICEMASTER.invoice_pakagingchgs, 0) AS PACKAGCHGS, ISNULL(INVOICEMASTER.INVOICE_SUBTOTAL, 0) AS SUBTOTAL, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, ISNULL(INVOICEMASTER.INVOICE_TAXAMT, 0) AS TAXAMT, ISNULL(EXTRACHGSLEDGERS.Acc_cmpname, '') AS EXTRACHGSNAME, ISNULL(INVOICEMASTER.INVOICE_EXTRACHGS, 0) AS EXTRACHGSAMT, ISNULL(INVOICEMASTER.invoice_roundoff, 0) AS ROUNDOFF, ISNULL(INVOICEMASTER.INVOICE_TOTALAMT, 0) AS TOTALAMT, ISNULL(INVOICEMASTER.invoice_grandtotal, 0) AS GRANDTOTAL, ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) AS TOTALTAXABLEAMT, ISNULL(INVOICEMASTER.INVOICE_TOTALCGSTAMT, 0) AS TOTALCGSTAMT, ISNULL(INVOICEMASTER.INVOICE_TOTALSGSTAMT, 0) AS TOTALSGSTAMT, ISNULL(INVOICEMASTER.INVOICE_TOTALIGSTAMT, 0) AS TOTALIGSTAMT , ISNULL(INVOICEMASTER.INVOICE_PAPER, '') AS PAPER, ISNULL(INVOICEMASTER.INVOICE_GSM, '') AS GSM, ISNULL(INVOICEMASTER.INVOICE_GRAIN, '') AS GRAIN, ISNULL(INVOICEMASTER.INVOICE_TEXT, '') AS TEXT, ISNULL(INVOICEMASTER.INVOICE_PHARMA, '') AS PHARMA, ISNULL(INVOICEMASTER.INVOICE_UPSNO, 0) AS UPSNO, ISNULL(INVOICEMASTER.INVOICE_VISUAL, '') AS VISUAL, ISNULL(INVOICEMASTER.INVOICE_COLOR, '') AS COLOR, ISNULL(INVOICEMASTER.INVOICE_VARNISH, '') AS VARNISH, ISNULL(INVOICEMASTER.INVOICE_PERFORATION, '') AS PERFORATION, ISNULL(INVOICEMASTER.INVOICE_DESIGN, '') AS DESIGN, ISNULL(INVOICEMASTER.INVOICE_SIZE, '') AS SIZE, ISNULL(INVOICEMASTER.INVOICE_STICKER, '') AS STICKER, ISNULL(INVOICEMASTER.INVOICE_ADHESIVE, '') AS ADHESIVE, ISNULL(INVOICEMASTER.INVOICE_FINAL, '') AS FINAL, ISNULL(INVOICEMASTER.INVOICE_PACKET, '') AS PACKET, ISNULL(INVOICEMASTER.INVOICE_SHIPPER, '') AS SHIPPER, ISNULL(INVOICEMASTER.INVOICE_LABEL, '') AS LABEL, ISNULL(INVOICEMASTER.INVOICE_BATCH, '') AS BATCH, ISNULL(INVOICEMASTER.INVOICE_QCHEAD, '') AS QCHEAD, ISNULL(INVOICEMASTER.INVOICE_QCDATE, GETDATE()) AS QCDATE, ISNULL(INVOICEMASTER.INVOICE_QCREMARKS, '') AS QCREMARKS , ISNULL(INVOICEMASTER.INVOICE_IRNNO,'') AS IRNNO ", "", " INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICEMASTER.invoice_registerid = REGISTERMASTER.register_id INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id INNER JOIN INVOICEMASTER_DESC ON INVOICEMASTER.invoice_no = INVOICEMASTER_DESC.INVOICE_NO AND INVOICEMASTER.invoice_registerid = INVOICEMASTER_DESC.INVOICE_REGISTERID AND INVOICEMASTER.invoice_yearid = INVOICEMASTER_DESC.INVOICE_YEARID INNER JOIN ITEMMASTER ON INVOICEMASTER_DESC.INVOICE_ITEMNAMEID = ITEMMASTER.item_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN CITYMASTER ON LEDGERS.Acc_cityid = CITYMASTER.city_id LEFT OUTER JOIN LEDGERS AS EXTRACHGSLEDGERS ON INVOICEMASTER.INVOICE_EXTRACHGSNAME = EXTRACHGSLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS OTHERCHGSLEDGER ON INVOICEMASTER.INVOICE_OTHERCHGSNAME = OTHERCHGSLEDGER.Acc_id LEFT OUTER JOIN TAXMASTER ON INVOICEMASTER.INVOICE_TAXID = TAXMASTER.tax_id ", TEMPCONDITION)

            GridInvoiceDetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                GridInvoice.FocusedRowHandle = GridInvoice.RowCount - 1
                GridInvoice.TopRowIndex = GridInvoice.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SHOWFROM(ByVal EDITVAL As Boolean, ByVal INVNO As Integer)
        Try
            If (EDITVAL = True And USEREDIT = False And USERVIEW = False) Or (EDITVAL = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (EDITVAL = False) Or (EDITVAL = True And GridInvoice.RowCount > 0) Then
                Dim OBJINV As New Invoice
                OBJINV.MdiParent = MDIMain
                OBJINV.edit = EDITVAL
                OBJINV.TEMPINVOICENO = INVNO
                OBJINV.TEMPREGNAME = cmbregister.Text.Trim
                OBJINV.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolAddnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            SHOWFROM(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridInvoice_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridInvoice.DoubleClick
        Try
            SHOWFROM(True, GridInvoice.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE INVOICE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If cmbregister.Text.Trim.Length > 0 Then
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'SALE' and register_cmpid = " & CmpId & "  and register_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    TEMPREGID = dt.Rows(0).Item(0)
                    FILLGRID(" AND invoicemaster.INVOICE_registerid = " & TEMPREGID & " order by dbo.invoicemaster.INVOICE_no ")
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, "AND REGISTER_TYPE='SALE'")

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable
            DT = OBJCMN.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'SALE' and register_cmpid = " & CmpId & " and register_yearid = " & YearId)
            If DT.Rows.Count > 0 Then
                cmbregister.Text = DT.Rows(0).Item(0).ToString
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            Dim PATH As String = "D:\Invoice Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Invoice Details"
            GridInvoice.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Invoice Details", GridInvoice.VisibleColumns.Count + GridInvoice.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            FILLGRID(" AND dbo.invoicemaster.INVOICE_cmpid=" & CmpId & "  AND invoicemaster.INVOICE_yearid = " & YearId & " AND invoicemaster.INVOICE_registerid = " & TEMPREGID & " order by dbo.invoicemaster.INVOICE_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExcelToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCELEXPORT.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Invoice Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Invoice Details"
            GridInvoice.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Invoice Details", GridInvoice.VisibleColumns.Count + GridInvoice.GroupCount)
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
            FILLGRID(" AND invoicemaster.INVOICE_yearid = " & YearId & " AND invoicemaster.INVOICE_registerid = " & TEMPREGID & " order by dbo.invoicemaster.INVOICE_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PRINTTOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTTOOL.Click
        Try
            Dim OBJSALEDESIGN As New SaleInvoiceDesign
            OBJSALEDESIGN.MdiParent = MDIMain
            If CMBPRINTLIST.Text = "Common COA" Then
                OBJSALEDESIGN.FRMSTRING = "COMMONCOA"
                OBJSALEDESIGN.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & GridInvoice.GetFocusedRowCellValue("SRNO") & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                OBJSALEDESIGN.Show()
            ElseIf CMBPRINTLIST.Text = "COA Report - CIPLA" Then
                OBJSALEDESIGN.FRMSTRING = "COA"
                OBJSALEDESIGN.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & GridInvoice.GetFocusedRowCellValue("SRNO") & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                OBJSALEDESIGN.Show()

            ElseIf CMBPRINTLIST.Text = "IPCA COA Report" Then
                OBJSALEDESIGN.FRMSTRING = "IPCA_COA"
                OBJSALEDESIGN.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & GridInvoice.GetFocusedRowCellValue("SRNO") & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                OBJSALEDESIGN.Show()

            ElseIf CMBPRINTLIST.Text = "SANDOZ COA Report" Then
                OBJSALEDESIGN.FRMSTRING = "SANDOZ_COA"
                OBJSALEDESIGN.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & GridInvoice.GetFocusedRowCellValue("SRNO") & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                OBJSALEDESIGN.Show()

            ElseIf CMBPRINTLIST.Text = "FAMYCARE COA Report" Then
                OBJSALEDESIGN.FRMSTRING = "FAMYCARE_COA"
                OBJSALEDESIGN.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & GridInvoice.GetFocusedRowCellValue("SRNO") & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                OBJSALEDESIGN.Show()

            ElseIf CMBPRINTLIST.Text = "BIOCON COA Report" Then
                OBJSALEDESIGN.FRMSTRING = "BIOCON_COA"
                OBJSALEDESIGN.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & GridInvoice.GetFocusedRowCellValue("SRNO") & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                OBJSALEDESIGN.Show()

            ElseIf CMBPRINTLIST.Text = "ALKEM COA Report" Then
                OBJSALEDESIGN.FRMSTRING = "ALKEM_COA"
                OBJSALEDESIGN.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & GridInvoice.GetFocusedRowCellValue("SRNO") & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                OBJSALEDESIGN.Show()

            ElseIf CMBPRINTLIST.Text = "SUN COA Report" Then
                OBJSALEDESIGN.FRMSTRING = "SUN_COA"
                OBJSALEDESIGN.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & GridInvoice.GetFocusedRowCellValue("SRNO") & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                OBJSALEDESIGN.Show()

            ElseIf CMBPRINTLIST.Text = "SHALINA COA Report" Then
                OBJSALEDESIGN.FRMSTRING = "SHALINA_COA"
                OBJSALEDESIGN.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & GridInvoice.GetFocusedRowCellValue("SRNO") & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                OBJSALEDESIGN.Show()


            ElseIf CMBPRINTLIST.Text = "QC Report" Then
                OBJSALEDESIGN.FRMSTRING = "INVOICEQCREPORT"
                OBJSALEDESIGN.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & GridInvoice.GetFocusedRowCellValue("SRNO") & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                OBJSALEDESIGN.Show()

            ElseIf CMBPRINTLIST.Text = "INVOICE" Then
                OBJSALEDESIGN.FRMSTRING = "INVOICE"
                If MsgBox("Wish to Print Invoice...", MsgBoxStyle.YesNo) = vbYes Then
                    serverprop()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub serverprop()
        'For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
        Dim OBJINVOICE As New SaleInvoiceDesign
        OBJINVOICE.MdiParent = MDIMain
        OBJINVOICE.DIRECTPRINT = True
        OBJINVOICE.FRMSTRING = "INVOICE"
        OBJINVOICE.INVNO = GridInvoice.GetFocusedRowCellValue("SRNO")
        OBJINVOICE.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & GridInvoice.GetFocusedRowCellValue("SRNO") & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
        OBJINVOICE.Show()
        OBJINVOICE.Close()
        'Next

    End Sub


End Class