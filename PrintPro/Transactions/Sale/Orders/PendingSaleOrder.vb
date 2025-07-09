Imports BL
Public Class PendingSaleOrder

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Pending Sale Order Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Pending Sale Order Details"
            GridOrder.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Pending Sale Order Details", GridOrder.VisibleColumns.Count + GridOrder.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLADDNEW_Click(sender As Object, e As EventArgs) Handles TOOLADDNEW.Click
        Try
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(sender As Object, e As EventArgs) Handles CMDOK.Click
        Try
            Dim OBJ As New ClsCommon
            For I As Integer = 0 To GridOrder.RowCount - 1
                Dim DTROW As DataRow = GridOrder.GetDataRow(I)
                If Convert.ToBoolean(DTROW("CHK")) = True Then
                    If RBPENDING.Checked = True Then
                        If DTROW("TYPE") = "ORDER" Then Dim DT As DataTable = OBJ.Execute_Any_String("UPDATE ORDERMASTER_DESC SET ORDER_CLOSE = 1 WHERE ORDER_NO  = " & Val(DTROW("ORDERNO")) & " AND ORDER_GRIDSRNO = " & Val(DTROW("SRNO")) & " AND ORDER_YEARID = " & YearId, "", "")
                    Else
                        If DTROW("TYPE") = "ORDER" Then Dim DT As DataTable = OBJ.Execute_Any_String("UPDATE ORDERMASTER_DESC SET ORDER_CLOSE = 0 WHERE ORDER_NO  = " & Val(DTROW("ORDERNO")) & " AND ORDER_GRIDSRNO = " & Val(DTROW("SRNO")) & " AND ORDER_YEARID = " & YearId, "", "")
                    End If
                End If
            Next
            MsgBox("Entries Updated")
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal EDITVAL As Boolean, ByVal GPU As Integer)
        Try


            If (EDITVAL = False) Or (EDITVAL = True And GridOrder.RowCount > 0) Then
                Dim PSO As New Order
                PSO.MdiParent = MDIMain
                PSO.edit = EDITVAL
                PSO.TEMPSONO = GPU
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
            CHKSELECTALL.Checked = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PendingSaleOrder_Load(sender As Object, e As EventArgs) Handles Me.Load
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
            If RBPENDING.Checked = True Then
                DT = OBJ.search(" CAST(0 AS BIT) AS CHK, ORDERMASTER_DESC.ORDER_NO AS ORDERNO, ORDERMASTER_DESC.ORDER_GRIDSRNO AS SRNO , LEDGERS.Acc_cmpname AS NAME, ISNULL(ITEMMASTER.item_fileno,0) AS FILENO, ISNULL(ITEMMASTER.item_code,0) AS CODE, ITEMMASTER.item_name AS ITEMNAME, ITEMMASTER.ITEM_ARTWORKDATE AS ARTDATE, ITEMMASTER.ITEM_PROOFSENDDATE AS PDFSENDDATE, ITEMMASTER.ITEM_PROOFOKDATE AS OK, ITEMMASTER.ITEM_SHADESENDDATE AS SCSDATE, ITEMMASTER.ITEM_SHADEAPPDATE AS SCODATE, ORDERMASTER.ORDER_DTPICKER AS ODATE, ISNULL(ORDERMASTER_DESC.ORDER_QTY,0) AS QUANTITY, ISNULL(ORDERMASTER.ORDER_PONO,0) AS PONO, ORDERMASTER.ORDER_PODATE AS PODATE, ISNULL(ITEMMASTER.ITEM_MATERIALCODE, 0) AS SAPCODE, LOCATION.Acc_cmpname AS LOCATION, ORDERMASTER_DESC.ORDER_SCHDATE AS SCHDATE, ORDERMASTER_DESC.ORDER_CLOSE AS [CLOSE], 'ORDER' AS TYPE ", "", " ORDERMASTER INNER JOIN ORDERMASTER_DESC ON ORDERMASTER.ORDER_NO = ORDERMASTER_DESC.ORDER_NO AND ORDERMASTER.ORDER_YEARID = ORDERMASTER_DESC.ORDER_YEARID INNER JOIN LEDGERS ON ORDERMASTER.ORDER_LEDGERID = LEDGERS.Acc_id AND ORDERMASTER.ORDER_YEARID = LEDGERS.Acc_yearid INNER JOIN ITEMMASTER ON ORDERMASTER_DESC.ORDER_ITEMID = ITEMMASTER.item_id INNER JOIN LEDGERS AS LOCATION ON ORDERMASTER.ORDER_LEDGERID = LOCATION.Acc_id AND ORDERMASTER.ORDER_YEARID = LOCATION.Acc_yearid ", " AND ORDERMASTER_DESC.ORDER_CLOSE ='FALSE' AND ORDERMASTER.ORDER_YEARID =" & YearId & " ORDER BY ORDERMASTER_DESC.ORDER_NO ")
            Else
                DT = OBJ.search(" CAST(0 AS BIT) AS CHK, ORDERMASTER_DESC.ORDER_NO AS ORDERNO, ORDERMASTER_DESC.ORDER_GRIDSRNO AS SRNO , LEDGERS.Acc_cmpname AS NAME, ISNULL(ITEMMASTER.item_fileno,0) AS FILENO, ISNULL(ITEMMASTER.item_code,0) AS CODE, ITEMMASTER.item_name AS ITEMNAME, ITEMMASTER.ITEM_ARTWORKDATE AS ARTDATE, ITEMMASTER.ITEM_PROOFSENDDATE AS PDFSENDDATE, ITEMMASTER.ITEM_PROOFOKDATE AS OK, ITEMMASTER.ITEM_SHADESENDDATE AS SCSDATE, ITEMMASTER.ITEM_SHADEAPPDATE AS SCODATE, ORDERMASTER.ORDER_DTPICKER AS ODATE, ISNULL(ORDERMASTER_DESC.ORDER_QTY,0) AS QUANTITY, ISNULL(ORDERMASTER.ORDER_PONO,0) AS PONO, ORDERMASTER.ORDER_PODATE AS PODATE, ISNULL(ITEMMASTER.ITEM_MATERIALCODE, 0) AS SAPCODE, LOCATION.Acc_cmpname AS LOCATION, ORDERMASTER_DESC.ORDER_SCHDATE AS SCHDATE, ORDERMASTER_DESC.ORDER_CLOSE AS [CLOSE], 'ORDER' AS TYPE ", "", " ORDERMASTER INNER JOIN ORDERMASTER_DESC ON ORDERMASTER.ORDER_NO = ORDERMASTER_DESC.ORDER_NO AND ORDERMASTER.ORDER_YEARID = ORDERMASTER_DESC.ORDER_YEARID INNER JOIN LEDGERS ON ORDERMASTER.ORDER_LEDGERID = LEDGERS.Acc_id AND ORDERMASTER.ORDER_YEARID = LEDGERS.Acc_yearid INNER JOIN ITEMMASTER ON ORDERMASTER_DESC.ORDER_ITEMID = ITEMMASTER.item_id INNER JOIN LEDGERS AS LOCATION ON ORDERMASTER.ORDER_LEDGERID = LOCATION.Acc_id AND ORDERMASTER.ORDER_YEARID = LOCATION.Acc_yearid ", " AND ORDERMASTER_DESC.ORDER_CLOSE ='TRUE' AND ORDERMASTER.ORDER_YEARID =" & YearId & " ORDER BY ORDERMASTER_DESC.ORDER_NO ")
            End If
            GridOrderDetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                GridOrder.FocusedRowHandle = GridOrder.RowCount - 1
                GridOrder.TopRowIndex = GridOrder.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridOrder_DoubleClick(sender As Object, e As EventArgs) Handles GridOrder.DoubleClick
        Try
            showform(True, GridOrder.GetFocusedRowCellValue("ORDERNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PendingSaleOrder_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If UserName = "Admin" Then RBPENTERED.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBPENTERED_CheckedChanged(sender As Object, e As EventArgs) Handles RBPENTERED.CheckedChanged
        Try
            fillgrid()
            CHKSELECTALL.Checked = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(sender As Object, e As EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            If GridOrderDetails.Visible = True Then
                For I As Integer = 0 To GridOrder.RowCount - 1
                    Dim DTROW As DataRow = GridOrder.GetDataRow(I)
                    DTROW("CHK") = CHKSELECTALL.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class