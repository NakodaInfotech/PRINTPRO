
Imports BL

Public Class PendingForApproval
    Private Sub PendingForApproval_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Pending For Approval Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Pending For Approval Details"
            GridPending.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Pending For Approval Details", GridPending.VisibleColumns.Count + GridPending.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
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

            Dim OBJ As New ClsCommonMaster
            Dim DT As DataTable
            DT = OBJ.search(" ISNULL(ITEMMASTER.item_code, 0) AS ITEMCODE, ITEMMASTER.item_name AS ITEMNAME, ISNULL(ITEMMASTER.item_fileno, 0) AS FILENO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ITEMMASTER.ITEM_ARTWORKDATE AS ARTDATE, ITEMMASTER.ITEM_PROOFSENDDATE AS PDFSENDDATE, ITEMMASTER.ITEM_PROOFOKDATE AS OK, ITEMMASTER.ITEM_SHADESENDDATE AS SCSDATE, ITEMMASTER.ITEM_SHADEAPPDATE AS SCADATE, ITEMMASTER.ITEM_SHADEDATE AS VALIDTILL  ", "", " ITEMMASTER LEFT OUTER JOIN LEDGERS ON ITEMMASTER.ITEM_LEDGERID = LEDGERS.Acc_id ", "  AND ITEMMASTER.item_yearid =" & YearId & " ORDER BY ITEMMASTER.item_code ")
            GridOrderDetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                GridPending.FocusedRowHandle = GridPending.RowCount - 1
                GridPending.TopRowIndex = GridPending.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
End Class