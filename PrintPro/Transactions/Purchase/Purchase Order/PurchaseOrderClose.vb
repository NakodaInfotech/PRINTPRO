
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class PurchaseOrderClose

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub PurchaseOrderClose_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Space And e.Control = True Then
                'SELECT ALL DATA
                For i As Integer = 0 To GridInvoice.RowCount - 1
                    Dim dtrow As DataRow = GridInvoice.GetDataRow(i)
                    dtrow("CLOSE") = Not Convert.ToBoolean(dtrow("CLOSE"))
                Next
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PurchaseOrderClose_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE ORDER'")
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
            Dim objclsCMST As New ClsCommonMaster
            Dim DT As New DataTable
            If RBPENDING.Checked = True Then
                'dt = objclsCMST.search(" CAST( 0 AS BIT) AS CHK, PURCHASEORDER.PO_NO AS PONO, PURCHASEORDER.PO_DATE AS DATE,  ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(PURCHASEORDER.PO_DELDAYS, 0) AS DELDAYS, PURCHASEORDER.PO_DELDATE AS DELDATE,  ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME, ISNULL(PURCHASEORDER_DESC.PO_SIZE, '') AS SIZE,ISNULL(PURCHASEORDER_DESC.PO_WT, 0) AS WT,  ISNULL(PURCHASEORDER_DESC.PO_QTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(PURCHASEORDER_DESC.PO_RATE, 0) AS RATE,ISNULL(PURCHASEORDER_DESC.PO_AMOUNT, 0) AS AMOUNT, ISNULL(PURCHASEORDER_DESC.PO_DESC, '') AS [DESC], ISNULL(PURCHASEORDER_DESC.PO_OUTQTY, 0) AS OUTQTY, ISNULL(PURCHASEORDER_DESC.PO_CLOSE, 0) AS [CLOSE],  ISNULL(PURCHASEORDER.PO_TOTALAMT, 0) AS TOTALAMT,  ISNULL(PURCHASEORDER.PO_SHEETSPERREAM,0) AS SHEETSPERREAM, ISNULL(PURCHASEORDER.PO_REMARKS, '') AS REMARKS , PURCHASEORDER_DESC.PO_SRNO as POGRIDSRNO, 'PURCHASEORDER' AS TYPE, (PURCHASEORDER_DESC.PO_QTY-PURCHASEORDER_DESC.PO_OUTQTY) AS BALQTY ", "  ", "   PURCHASEORDER INNER JOIN PURCHASEORDER_DESC ON PURCHASEORDER.PO_NO = PURCHASEORDER_DESC.PO_NO AND PURCHASEORDER.PO_YEARID = PURCHASEORDER_DESC.PO_YEARID INNER JOIN LEDGERS ON PURCHASEORDER.PO_LEDGERID = LEDGERS.Acc_id AND PURCHASEORDER.PO_YEARID = LEDGERS.Acc_yearid INNER JOIN UNITMASTER ON PURCHASEORDER_DESC.PO_UNITID = UNITMASTER.unit_id AND PURCHASEORDER_DESC.PO_YEARID = UNITMASTER.unit_yearid INNER JOIN NONINVITEMMASTER ON PURCHASEORDER_DESC.PO_ITEMID = NONINVITEMMASTER.NONINV_ID AND PURCHASEORDER_DESC.PO_YEARID = NONINVITEMMASTER.NONINV_YEARID ", " AND  PURCHASEORDER_DESC.PO_CLOSE = 'FALSE' and (PURCHASEORDER_DESC.PO_QTY-PURCHASEORDER_DESC.PO_OUTQTY)>0 AND PURCHASEORDER.PO_yearid=" & YearId & " ORDER BY PONO, POGRIDSRNO")
                DT = objclsCMST.search(" CAST( 0 AS BIT) AS CHK, ALLPURCHASEORDER.PO_NO AS PONO, ALLPURCHASEORDER.PO_DATE AS DATE,  ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ALLPURCHASEORDER.PO_DELDAYS, 0) AS DELDAYS, ALLPURCHASEORDER.PO_DELDATE AS DELDATE,  ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME, ISNULL(ALLPURCHASEORDER_DESC.PO_SIZE, '') AS SIZE,ISNULL(ALLPURCHASEORDER_DESC.PO_WT, 0) AS WT,  ISNULL(ALLPURCHASEORDER_DESC.PO_QTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(ALLPURCHASEORDER_DESC.PO_RATE, 0) AS RATE,ISNULL(ALLPURCHASEORDER_DESC.PO_AMOUNT, 0) AS AMOUNT, ISNULL(ALLPURCHASEORDER_DESC.PO_DESC, '') AS [DESC], ISNULL(ALLPURCHASEORDER_DESC.PO_OUTQTY, 0) AS OUTQTY, ISNULL(ALLPURCHASEORDER_DESC.PO_CLOSE, 0) AS [CLOSE],  ISNULL(ALLPURCHASEORDER.PO_TOTALAMT, 0) AS TOTALAMT,  ISNULL(ALLPURCHASEORDER.PO_SHEETSPERREAM,0) AS SHEETSPERREAM, ISNULL(ALLPURCHASEORDER.PO_REMARKS, '') AS REMARKS , ALLPURCHASEORDER_DESC.PO_SRNO as POGRIDSRNO, (ALLPURCHASEORDER_DESC.PO_QTY-ALLPURCHASEORDER_DESC.PO_OUTQTY) AS BALQTY, ALLPURCHASEORDER.TYPE AS TYPE ", "  ", "   ALLPURCHASEORDER INNER JOIN ALLPURCHASEORDER_DESC ON ALLPURCHASEORDER.PO_NO = ALLPURCHASEORDER_DESC.PO_NO AND ALLPURCHASEORDER.PO_YEARID = ALLPURCHASEORDER_DESC.PO_YEARID INNER JOIN LEDGERS ON ALLPURCHASEORDER.PO_LEDGERID = LEDGERS.Acc_id AND ALLPURCHASEORDER.PO_YEARID = LEDGERS.Acc_yearid INNER JOIN UNITMASTER ON ALLPURCHASEORDER_DESC.PO_UNITID = UNITMASTER.unit_id AND ALLPURCHASEORDER_DESC.PO_YEARID = UNITMASTER.unit_yearid INNER JOIN NONINVITEMMASTER ON ALLPURCHASEORDER_DESC.PO_ITEMID = NONINVITEMMASTER.NONINV_ID AND ALLPURCHASEORDER_DESC.PO_YEARID = NONINVITEMMASTER.NONINV_YEARID ", " AND  ALLPURCHASEORDER_DESC.PO_CLOSE = 'FALSE' and (ALLPURCHASEORDER_DESC.PO_QTY-ALLPURCHASEORDER_DESC.PO_OUTQTY)>0 AND ALLPURCHASEORDER.PO_yearid=" & YearId & " ORDER BY PONO, POGRIDSRNO")
            Else
                'dt = objclsCMST.search(" CAST( 0 AS BIT) AS CHK, PURCHASEORDER.PO_NO AS PONO, PURCHASEORDER.PO_DATE AS DATE,  ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(PURCHASEORDER.PO_DELDAYS, 0) AS DELDAYS, PURCHASEORDER.PO_DELDATE AS DELDATE,  ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME, ISNULL(PURCHASEORDER_DESC.PO_SIZE, '') AS SIZE,ISNULL(PURCHASEORDER_DESC.PO_WT, 0) AS WT,  ISNULL(PURCHASEORDER_DESC.PO_QTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(PURCHASEORDER_DESC.PO_RATE, 0) AS RATE,ISNULL(PURCHASEORDER_DESC.PO_AMOUNT, 0) AS AMOUNT, ISNULL(PURCHASEORDER_DESC.PO_DESC, '') AS [DESC], ISNULL(PURCHASEORDER_DESC.PO_OUTQTY, 0) AS OUTQTY, ISNULL(PURCHASEORDER_DESC.PO_CLOSE, 0) AS [CLOSE],  ISNULL(PURCHASEORDER.PO_TOTALAMT, 0) AS TOTALAMT,  ISNULL(PURCHASEORDER.PO_SHEETSPERREAM,0) AS SHEETSPERREAM, ISNULL(PURCHASEORDER.PO_REMARKS, '') AS REMARKS , PURCHASEORDER_DESC.PO_SRNO as POGRIDSRNO, 'PURCHASEORDER' AS TYPE, (PURCHASEORDER_DESC.PO_QTY-PURCHASEORDER_DESC.PO_OUTQTY) AS BALQTY ", "  ", "   PURCHASEORDER INNER JOIN PURCHASEORDER_DESC ON PURCHASEORDER.PO_NO = PURCHASEORDER_DESC.PO_NO AND PURCHASEORDER.PO_YEARID = PURCHASEORDER_DESC.PO_YEARID INNER JOIN LEDGERS ON PURCHASEORDER.PO_LEDGERID = LEDGERS.Acc_id AND PURCHASEORDER.PO_YEARID = LEDGERS.Acc_yearid INNER JOIN UNITMASTER ON PURCHASEORDER_DESC.PO_UNITID = UNITMASTER.unit_id AND PURCHASEORDER_DESC.PO_YEARID = UNITMASTER.unit_yearid INNER JOIN NONINVITEMMASTER ON PURCHASEORDER_DESC.PO_ITEMID = NONINVITEMMASTER.NONINV_ID AND PURCHASEORDER_DESC.PO_YEARID = NONINVITEMMASTER.NONINV_YEARID ", " AND  PURCHASEORDER_DESC.PO_CLOSE = 'TRUE' and PURCHASEORDER.PO_yearid=" & YearId & " ORDER BY PONO, POGRIDSRNO")
                DT = objclsCMST.search(" CAST( 0 AS BIT) AS CHK, ALLPURCHASEORDER.PO_NO AS PONO, ALLPURCHASEORDER.PO_DATE AS DATE,  ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ALLPURCHASEORDER.PO_DELDAYS, 0) AS DELDAYS, ALLPURCHASEORDER.PO_DELDATE AS DELDATE,  ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME, ISNULL(ALLPURCHASEORDER_DESC.PO_SIZE, '') AS SIZE,ISNULL(ALLPURCHASEORDER_DESC.PO_WT, 0) AS WT,  ISNULL(ALLPURCHASEORDER_DESC.PO_QTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(ALLPURCHASEORDER_DESC.PO_RATE, 0) AS RATE,ISNULL(ALLPURCHASEORDER_DESC.PO_AMOUNT, 0) AS AMOUNT, ISNULL(ALLPURCHASEORDER_DESC.PO_DESC, '') AS [DESC], ISNULL(ALLPURCHASEORDER_DESC.PO_OUTQTY, 0) AS OUTQTY, ISNULL(ALLPURCHASEORDER_DESC.PO_CLOSE, 0) AS [CLOSE],  ISNULL(ALLPURCHASEORDER.PO_TOTALAMT, 0) AS TOTALAMT,  ISNULL(ALLPURCHASEORDER.PO_SHEETSPERREAM,0) AS SHEETSPERREAM, ISNULL(ALLPURCHASEORDER.PO_REMARKS, '') AS REMARKS , ALLPURCHASEORDER_DESC.PO_SRNO as POGRIDSRNO, (ALLPURCHASEORDER_DESC.PO_QTY-ALLPURCHASEORDER_DESC.PO_OUTQTY) AS BALQTY, ALLPURCHASEORDER.TYPE AS TYPE ", "  ", "   ALLPURCHASEORDER INNER JOIN ALLPURCHASEORDER_DESC ON ALLPURCHASEORDER.PO_NO = ALLPURCHASEORDER_DESC.PO_NO AND ALLPURCHASEORDER.PO_YEARID = ALLPURCHASEORDER_DESC.PO_YEARID INNER JOIN LEDGERS ON ALLPURCHASEORDER.PO_LEDGERID = LEDGERS.Acc_id AND ALLPURCHASEORDER.PO_YEARID = LEDGERS.Acc_yearid INNER JOIN UNITMASTER ON ALLPURCHASEORDER_DESC.PO_UNITID = UNITMASTER.unit_id AND ALLPURCHASEORDER_DESC.PO_YEARID = UNITMASTER.unit_yearid INNER JOIN NONINVITEMMASTER ON ALLPURCHASEORDER_DESC.PO_ITEMID = NONINVITEMMASTER.NONINV_ID AND ALLPURCHASEORDER_DESC.PO_YEARID = NONINVITEMMASTER.NONINV_YEARID ", " AND  ALLPURCHASEORDER_DESC.PO_CLOSE = 'TRUE' and ALLPURCHASEORDER.PO_yearid=" & YearId & " ORDER BY PONO, POGRIDSRNO")
            End If
            GridPODetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                GridInvoice.FocusedRowHandle = GridInvoice.RowCount - 1
                GridInvoice.TopRowIndex = GridInvoice.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Dim OBJCMN As New ClsCommon
            For I As Integer = 0 To GridInvoice.RowCount - 1
                Dim DTROW As DataRow = GridInvoice.GetDataRow(I)
                If Convert.ToBoolean(DTROW("CHK")) = True Then
                    If RBPENDING.Checked = True Then
                        If DTROW("TYPE") = "PURCHASEORDER" Then Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE PURCHASEORDER_DESC SET PO_CLOSE = 1 WHERE PO_NO = " & Val(DTROW("PONO")) & " AND PO_SRNO = " & Val(DTROW("POGRIDSRNO")) & " AND PO_YEARID = " & YearId, "", "") Else Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE OPENINGPURCHASEORDER_DESC SET OPO_CLOSE = 1 WHERE OPO_NO = " & Val(DTROW("PONO")) & " AND OPO_SRNO = " & Val(DTROW("POGRIDSRNO")) & " AND OPO_YEARID = " & YearId, "", "")
                    Else
                        If DTROW("TYPE") = "PURCHASEORDER" Then Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE PURCHASEORDER_DESC SET PO_CLOSE = 0 WHERE PO_NO = " & Val(DTROW("PONO")) & " AND PO_SRNO = " & Val(DTROW("POGRIDSRNO")) & " AND PO_YEARID = " & YearId, "", "") Else Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE OPENINGPURCHASEORDER_DESC SET OPO_CLOSE = 0 WHERE OPO_NO = " & Val(DTROW("PONO")) & " AND OPO_SRNO = " & Val(DTROW("POGRIDSRNO")) & " AND OPO_YEARID = " & YearId, "", "")
                    End If
                End If
            Next
            MsgBox("Entries Updated")
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("CLOSE")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.Yellow
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EXCELEXPORT_Click(sender As Object, e As EventArgs) Handles EXCELEXPORT.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Purchase Order Close Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Purchase Order Close Details"
            GridInvoice.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Purchase Order Close Details", GridInvoice.VisibleColumns.Count + GridInvoice.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            If GridPODetails.Visible = True Then
                For i As Integer = 0 To GridInvoice.RowCount - 1
                    Dim dtrow As DataRow = GridInvoice.GetDataRow(i)
                    dtrow("CHK") = CHKSELECTALL.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        FILLGRID()
    End Sub

    Private Sub GridInvoice_DoubleClick(sender As Object, e As EventArgs) Handles GridInvoice.DoubleClick
        Try
            showform(True, GridInvoice.GetFocusedRowCellValue("PONO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        If (Val(TXTFROM.Text.Trim) = 0 And (Val(TXTTO.Text.Trim) = 0) AndAlso GridInvoice.SelectedRowsCount = 0) Then Exit Sub
        If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
            If (Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim)) Then
                MsgBox("Pls Enter Proper Order No.", MsgBoxStyle.Critical)
                Exit Sub
            End If
            If MsgBox("Wish to Print Order from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
                SERVERPROPDIRECT()
            End If
        Else
            If MsgBox("Wish to Print Selected Order ?", MsgBoxStyle.YesNo) = vbYes Then
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
                OBJMAIL.subject = "Purchase Order"
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
                    ALATTACHMENT.Add(Application.StartupPath & "\PURCAHASE" & Val(ROW("PONO")) & ".pdf")
                End If
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "Purchase Order"
                OBJMAIL.ShowDialog()
            End If
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

    Private Sub PurchaseOrderClose_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            If UserName = "Admin" Then RBENTERED.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBENTERED_CheckedChanged(sender As Object, e As EventArgs) Handles RBPENDING.CheckedChanged, RBENTERED.CheckedChanged
        FILLGRID()
    End Sub
End Class