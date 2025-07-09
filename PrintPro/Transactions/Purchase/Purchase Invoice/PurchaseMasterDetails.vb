
Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class PurchaseMasterDetails
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
                CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID(ByVal TEMPCONDITION)
        Try
            Dim OBJCMN As New ClsCommonMaster
            Dim DT As DataTable = OBJCMN.search("   PURCHASEMASTER.bill_no AS SRNO, PURCHASEMASTER.bill_date AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(PURCHASEMASTER.bill_partybillno, 0) AS PARTYBILLNO, PURCHASEMASTER.bill_partybilldate AS PARTYBILLDATE, ISNULL(PURCHASEMASTER.BILL_EWAYBILLNO, 0) AS EWAYBILLNO, ISNULL(PURCHASEMASTER.bill_totalqty, 0) AS TOTALQTY, ISNULL(PURCHASEMASTER.bill_totalamt, 0) AS TOTALAMT, ISNULL(PURCHASEMASTER.bill_transchg, 0) AS TRANSCHG, ISNULL(PURCHASEMASTER.bill_excise, 0) AS EXCISE, ISNULL(PURCHASEMASTER.bill_subtotal, 0) AS SUBTOTAL, ISNULL(TAXMASTER.tax_name, '') AS TAXNAME, ISNULL(PURCHASEMASTER.bill_taxamt, 0) AS TAXAMT, ISNULL(OTHERCHGSNAME.Acc_cmpname, '') AS OTHERCHGSNAME, ISNULL(PURCHASEMASTER.bill_otherchgs, 0) AS OTHERCHGS, ISNULL(PURCHASEMASTER.BILL_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(PURCHASEMASTER.BILL_GRANDTOTAL, 0) AS GRANDTOTAL, ISNULL(PURCHASEMASTER.bill_remarks, '') AS REMARKS, ISNULL(CITYMASTER.city_name, '') AS CITY, ISNULL(STATEMASTER.state_name, '') AS STATENAME, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(PURCHASEMASTER.BILL_TOTALTAXABLEAMT, 0) AS TOTALTAXABLEAMT, ISNULL(PURCHASEMASTER.BILL_TOTALCGSTAMT, 0) AS TOTALCGSTAMT, ISNULL(PURCHASEMASTER.BILL_TOTALSGSTAMT, 0) AS TOTALSGSTAMT, ISNULL(PURCHASEMASTER.BILL_TOTALIGSTAMT, 0) AS TOTALIGSTAMT", "", "  CITYMASTER RIGHT OUTER JOIN PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.bill_ledgerid = LEDGERS.Acc_id AND PURCHASEMASTER.bill_cmpid = LEDGERS.Acc_cmpid AND PURCHASEMASTER.bill_yearid = LEDGERS.Acc_yearid INNER JOIN REGISTERMASTER ON PURCHASEMASTER.bill_registerid = REGISTERMASTER.register_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ON CITYMASTER.city_id = LEDGERS.Acc_cityid LEFT OUTER JOIN TAXMASTER ON PURCHASEMASTER.bill_taxid = TAXMASTER.tax_id LEFT OUTER JOIN LEDGERS AS OTHERCHGSNAME ON PURCHASEMASTER.BILL_OTHERCHGSID = OTHERCHGSNAME.Acc_id", TEMPCONDITION)
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

    Private Sub TOOLGRIDDETAILS_Click(sender As Object, e As EventArgs) Handles TOOLGRIDDETAILS.Click
        Try
            Dim OBJDTLS As New PurchaseMasterGridDetails
            OBJDTLS.MdiParent = MDIMain
            OBJDTLS.Show()
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