Imports System.ComponentModel
Imports BL

Public Class DispatchReport
    Dim saleregabbr, salereginitial As String
    Dim SALEREGID As Integer
    Dim TEMPREGID As Integer

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Despatch Report.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Despatch Report"
            GridOrder.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Despatch Report", GridOrder.VisibleColumns.Count + GridOrder.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLADDNEW_Click(sender As Object, e As EventArgs)
        Try
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(sender As Object, e As EventArgs)
        Try
            showform(True, GridOrder.GetFocusedRowCellValue("INVNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal EDITVAL As Boolean, ByVal GPU As Integer)
        Try
            If (EDITVAL = False) Or (EDITVAL = True And GridOrder.RowCount > 0) Then
                Dim PSO As New Invoice
                PSO.MdiParent = MDIMain
                PSO.edit = EDITVAL
                PSO.TEMPINVOICENO = GPU
                PSO.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub ToolStripRefresh_Click(sender As Object, e As EventArgs) Handles ToolStripRefresh.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim OBJ As New ClsCommon
            Dim DT As DataTable = OBJ.search(" LEDGERS.Acc_cmpname AS NAME, ITEMMASTER.item_fileno AS FILENO, ITEMMASTER.ITEM_MATERIALCODE AS SAPCODE, ITEMMASTER.item_code AS CODE, ITEMMASTER.item_name AS ITEMNAME, ITEMMASTER.ITEM_ARTWORKDATE AS ARTDATE, ITEMMASTER.ITEM_PROOFSENDDATE AS PDFSENDDATE, ITEMMASTER.ITEM_PROOFOKDATE AS OK, ITEMMASTER.ITEM_SHADESENDDATE AS SCSDATE, ITEMMASTER.ITEM_SHADEAPPDATE AS SCODATE, INVOICEMASTER_DESC.INVOICE_QTY AS QUANTITY, LOCATION.Acc_cmpname AS LOCATION, INVOICEMASTER.INVOICE_PONO AS PONO, INVOICEMASTER.INVOICE_PODATE AS PODATE, INVOICEMASTER.invoice_challanno AS CHALLANNO, INVOICEMASTER.invoice_no AS INVNO, INVOICEMASTER.invoice_date AS INVDATE, INVOICEMASTER.INVOICE_SHIPPER AS SHIPPER, INVOICEMASTER.INVOICE_LRNO AS LRNO, INVOICEMASTER.INVOICE_LRDATE AS LRDATE, TRANSPORT.Acc_cmpname AS TRANSPORT, ORDERMASTER.ORDER_DTPICKER AS ODATE, ORDERMASTER_DESC.ORDER_SCHDATE AS SCHDATE ", "", " ORDERMASTER INNER JOIN INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id INNER JOIN INVOICEMASTER_DESC ON INVOICEMASTER.invoice_no = INVOICEMASTER_DESC.INVOICE_NO AND INVOICEMASTER.invoice_yearid = INVOICEMASTER_DESC.INVOICE_YEARID AND INVOICEMASTER.invoice_registerid = INVOICEMASTER_DESC.INVOICE_REGISTERID INNER JOIN ITEMMASTER ON INVOICEMASTER_DESC.INVOICE_ITEMNAMEID = ITEMMASTER.item_id ON ORDERMASTER.ORDER_PONO = INVOICEMASTER.INVOICE_PONO AND ORDERMASTER.ORDER_YEARID = INVOICEMASTER.invoice_yearid INNER JOIN ORDERMASTER_DESC ON ORDERMASTER.ORDER_NO = ORDERMASTER_DESC.ORDER_NO AND ORDERMASTER.ORDER_YEARID = ORDERMASTER_DESC.ORDER_YEARID AND INVOICEMASTER.INVOICE_ORDERSRNO = ORDERMASTER_DESC.ORDER_GRIDSRNO LEFT OUTER JOIN LEDGERS AS TRANSPORT ON INVOICEMASTER.INVOICE_TRANSID = TRANSPORT.Acc_id LEFT OUTER JOIN LEDGERS AS LOCATION ON INVOICEMASTER.INVOICE_LOCATIONLEDGERID = LOCATION.Acc_id ", " AND INVOICEMASTER.invoice_yearid=" & YearId & " ORDER BY INVOICEMASTER.invoice_no")
            GridOrderDetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                GridOrder.FocusedRowHandle = GridOrder.RowCount - 1
                GridOrder.TopRowIndex = GridOrder.RowCount - 15
            End If
            '  FETCHDATAT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChallanReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
