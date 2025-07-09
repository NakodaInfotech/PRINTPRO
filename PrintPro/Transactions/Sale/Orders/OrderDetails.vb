
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class OrderDetails

    Dim USERADD, USEREDIT, USERDELETE, USERVIEW As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub OrderDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
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
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OrderDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE ORDER'")
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
            Dim OBJCMN As New ClsCommonMaster
            Dim DT As DataTable = OBJCMN.search("ORDERMASTER.ORDER_NO AS ORDERNO, LEDGERS.Acc_cmpname AS NAME, ORDERMASTER.ORDER_DTPICKER AS DATE, ISNULL(ORDERMASTER.ORDER_REMARKS, '') AS REMARKS, ISNULL(ORDERMASTER.ORDER_TOTALAMT, 0) AS TOTALAMT, ISNULL(ORDERMASTER.ORDER_TOTALQTY, 0) AS TOTALQTY, ISNULL(ORDERMASTER.ORDER_PONO, '') AS PONO, ORDERMASTER.ORDER_PODATE AS PODATE, ISNULL(ORDERMASTER.ORDER_SHADECARD, '') AS SHADECARD, ISNULL(ORDERMASTER.ORDER_MULTIUPS, '') AS MULTIUPS, ISNULL(ORDERMASTER.ORDER_POSITIVENEGATIVE, '') AS POSNEG, ORDERMASTER.ORDER_DELDATE AS DELDATE, ITEMMASTER.item_code AS ITEMCODE, ITEMMASTER.item_name AS ITEMNAME, ORDERMASTER_DESC.ORDER_CLOSE AS CLOSED, ORDERMASTER_DESC.ORDER_OUTQTY AS OUTQTY, ORDERMASTER_DESC.ORDER_SCHDATE AS SCHDATE, ISNULL(LEDGERSSHIPTO.Acc_cmpname,'') AS SHIPTO , ISNULL(ORDERMASTER_DESC.ORDER_BASICRATE, 0) AS RATE , ISNULL(ORDERMASTER_DESC.ORDER_ASSEMBLYOUTQTY, 0) AS ASSEMBLYQTY, ISNULL(ORDERMASTER_DESC.ORDER_DELOUTQTY, 0) AS DELQTY ,ISNULL((ORDERMASTER.ORDER_TOTALQTY - ORDERMASTER_DESC.ORDER_DELOUTQTY), 0) AS BALDELQTY ", "", " ORDERMASTER INNER JOIN LEDGERS ON ORDERMASTER.ORDER_LEDGERID = LEDGERS.Acc_id INNER JOIN ORDERMASTER_DESC ON ORDERMASTER.ORDER_NO = ORDERMASTER_DESC.ORDER_NO AND ORDERMASTER.ORDER_YEARID = ORDERMASTER_DESC.ORDER_YEARID INNER JOIN ITEMMASTER ON ITEMMASTER.item_id = ORDERMASTER_DESC.ORDER_ITEMID LEFT OUTER JOIN LEDGERS AS LEDGERSSHIPTO ON ORDERMASTER.ORDER_SHIPTOID = LEDGERSSHIPTO.Acc_id", " AND ORDERMASTER.ORDER_YEARID = " & YearId & " ORDER BY ORDERMASTER.ORDER_NO")
            If ClientName = "GANESHMUDRA" Then
                GASSEMBLYQTY.Visible = False
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

    Sub SHOWFROM(ByVal EDITVAL As Boolean, ByVal ORDERNO As Integer)
        Try
            If (EDITVAL = True And USEREDIT = False And USERVIEW = False) Or (EDITVAL = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (EDITVAL = False) Or (EDITVAL = True And GridOrder.RowCount > 0) Then
                Dim OBJORDER As New Order
                OBJORDER.MdiParent = MDIMain
                OBJORDER.edit = EDITVAL
                OBJORDER.TEMPSONO = ORDERNO
                OBJORDER.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLADDNEW.Click
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

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            SHOWFROM(True, GridOrder.GetFocusedRowCellValue("ORDERNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridOrder_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridOrder.DoubleClick
        Try
            SHOWFROM(True, GridOrder.GetFocusedRowCellValue("ORDERNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Try
            Dim OBJR As New PendingSaleOrder
            OBJR.MdiParent = MDIMain
            OBJR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Sale Order Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Sale Order Details"
            GridOrder.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Sale Order Details", GridOrder.VisibleColumns.Count + GridOrder.GroupCount)
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
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridOrder_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridOrder.RowStyle
        Try
            Dim DT As DataTable = GridOrderDetails.DataSource
            If e.RowHandle >= 0 Then
                Dim ROW As DataRow = DT.Rows(e.RowHandle)
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("CLOSED")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 10.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.LightGreen
                ElseIf Val(View.GetRowCellDisplayText(e.RowHandle, View.Columns("OUTQTY"))) > 0 Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 10.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.Yellow
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class