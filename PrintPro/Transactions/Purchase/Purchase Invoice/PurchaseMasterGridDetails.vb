Imports BL
Public Class PurchaseMasterGridDetails
    Public edit As Boolean
    Dim TEMPREGID As Integer
    Dim USERADD, USEREDIT, USERDELETE, USERVIEW As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub PurchaseMasterDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Alt = True Then
                SHOWFROM(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID(ByVal TEMPCONDITION)
        Try
            Dim OBJCMN As New ClsCommonMaster
            Dim DT As DataTable = OBJCMN.search(" ISNULL(PURCHASEMASTER_DESC.bill_no, 0) AS SRNO, ISNULL(PURCHASEMASTER_DESC.bill_gsrno, 0) AS GRIDSRNO, ISNULL(REGISTERMASTER.register_name, '') AS REGISTER, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME, ISNULL(HSNMASTER.HSN_TYPE, '') AS HSN, ISNULL(UNITMASTER.unit_name, '') AS UNIT, ISNULL(PURCHASEMASTER_DESC.bill_size, '') AS SIZE, ISNULL(PURCHASEMASTER_DESC.bill_wt, 0) AS WT, ISNULL(PURCHASEMASTER_DESC.BILL_BATCHNO, '') AS BATCHNO, ISNULL(PURCHASEMASTER_DESC.BILL_PPRSRNO, '') AS PPRSRNO, ISNULL(PURCHASEMASTER_DESC.bill_qty, 0) AS QTY, ISNULL(PURCHASEMASTER_DESC.bill_rate, 0) AS RATE, ISNULL(PURCHASEMASTER_DESC.bill_amount, 0) AS AMOUNT, ISNULL(PURCHASEMASTER_DESC.BILL_OTHERAMT, 0) AS OTHERAMT, ISNULL(PURCHASEMASTER_DESC.BILL_TAXABLEAMT, '') AS TAXABLE, ISNULL(PURCHASEMASTER_DESC.BILL_CGSTPER, 0) AS CGST, ISNULL(PURCHASEMASTER_DESC.BILL_CGSTAMT, 0) AS CGSTAMT, ISNULL(PURCHASEMASTER_DESC.BILL_SGSTPER, 0) AS SGST, ISNULL(PURCHASEMASTER_DESC.BILL_SGSTAMT, 0) AS SGSTAMT, ISNULL(PURCHASEMASTER_DESC.BILL_IGSTPER, 0) AS IGST, ISNULL(PURCHASEMASTER_DESC.BILL_GRIDTOTAL, 0) AS GRIDTOTAL, ISNULL(PURCHASEMASTER_DESC.BILL_IGSTAMT, 0) AS IGSTAMT", "", " PURCHASEMASTER_DESC LEFT OUTER JOIN UNITMASTER ON PURCHASEMASTER_DESC.BILL_UNITID = UNITMASTER.unit_id LEFT OUTER JOIN HSNMASTER ON PURCHASEMASTER_DESC.BILL_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN NONINVITEMMASTER ON PURCHASEMASTER_DESC.bill_NONINVITEMID = NONINVITEMMASTER.NONINV_ID RIGHT OUTER JOIN PURCHASEMASTER ON PURCHASEMASTER_DESC.bill_no = PURCHASEMASTER.bill_no LEFT OUTER JOIN REGISTERMASTER ON PURCHASEMASTER_DESC.bill_registerid = REGISTERMASTER.register_id", TEMPCONDITION)
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SHOWFROM(ByVal EDITVAL As Boolean, ByVal BILLNO As Integer)
        Try
            If (EDITVAL = True And USEREDIT = False And USERVIEW = False) Or (EDITVAL = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (EDITVAL = False) Or (EDITVAL = True And gridbill.RowCount > 0) Then
                Dim OBJPURINV As New PurchaseMaster
                OBJPURINV.MdiParent = MDIMain
                OBJPURINV.EDIT = EDITVAL
                OBJPURINV.TEMPBILLNO = BILLNO
                OBJPURINV.TEMPREGNAME = cmbregister.Text.Trim
                OBJPURINV.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            SHOWFROM(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, "AND REGISTER_TYPE='PURCHASE'")

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable
            DT = OBJCMN.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " and register_yearid = " & YearId)
            If DT.Rows.Count > 0 Then
                cmbregister.Text = DT.Rows(0).Item(0).ToString
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE INVOICE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If cmbregister.Text.Trim.Length > 0 Then
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & "  and register_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    TEMPREGID = dt.Rows(0).Item(0)
                    FILLGRID(" AND dbo.PURCHASEMASTER.BILL_cmpid=" & CmpId & "  AND PURCHASEMASTER.BILL_yearid = " & YearId & " AND PURCHASEMASTER.BILL_registerid = " & TEMPREGID & " order by dbo.PURCHASEMASTER.BILL_no ")
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Try
            FILLGRID(" AND dbo.PURCHASEMASTER.BILL_cmpid=" & CmpId & "  AND PURCHASEMASTER.BILL_yearid = " & YearId & " AND PURCHASEMASTER.BILL_registerid = " & TEMPREGID & " order by dbo.PURCHASEMASTER.BILL_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            SHOWFROM(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            SHOWFROM(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = "D:\Purchase Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Purchase Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Purchase Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class