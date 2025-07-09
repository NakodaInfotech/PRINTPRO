
Imports BL

Public Class StoreStockRecoOutDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub StockRecoOutDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub StockRecoOutDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DTROW() As DataRow
        DTROW = USERRIGHTS.Select("FormName = 'STOCKRECO'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        FILLGRID()
    End Sub

    Sub FILLGRID()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" ISNULL(STORESTOCKADJUSTMENT.SA_no, 0) AS SANO, STORESTOCKADJUSTMENT.SA_date AS DATE, ISNULL(STORESTOCKADJUSTMENT_DESC.SA_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(STORESTOCKADJUSTMENT.SA_CHALLANNO, 0) AS CHALLANNO, ISNULL(STORESTOCKADJUSTMENT_DESC.SA_RATE, 0) AS RATE, ISNULL(STORESTOCKADJUSTMENT_DESC.SA_AMOUNT, 0) AS AMOUNT, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(STORESTOCKADJUSTMENT_DESC.SA_QTY, 0) AS QTY, ISNULL(STORESTOCKADJUSTMENT_DESC.SA_SIZE, '') AS SIZE, ISNULL(STORESTOCKADJUSTMENT_DESC.SA_WT, 0) AS WT, ISNULL(STORESTOCKADJUSTMENT_DESC.SA_LOTNO, '') AS LOTNO, ISNULL(STORESTOCKADJUSTMENT.SA_remarks, '') AS REMARKS", "", "STORESTOCKADJUSTMENT_DESC LEFT OUTER JOIN STORESTOCKADJUSTMENT ON STORESTOCKADJUSTMENT_DESC.SA_NO = STORESTOCKADJUSTMENT.SA_no AND  STORESTOCKADJUSTMENT_DESC.SA_YEARID = STORESTOCKADJUSTMENT.SA_yearid LEFT OUTER JOIN LEDGERS ON STORESTOCKADJUSTMENT.SA_TRANSID = LEDGERS.Acc_id LEFT OUTER JOIN NONINVITEMMASTER ON STORESTOCKADJUSTMENT_DESC.SA_ITEMID = NONINVITEMMASTER.NONINV_ID LEFT OUTER JOIN GODOWNMASTER ON STORESTOCKADJUSTMENT.SA_GODOWNID = GODOWNMASTER.GODOWN_id  ", " AND dbo.STORESTOCKADJUSTMENT.SA_yearid=" & YearId & " order by dbo.STORESTOCKADJUSTMENT.SA_no ")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal RECONO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objSTOCK As New StoreStockReco
                objSTOCK.MdiParent = MDIMain
                objSTOCK.EDIT = editval
                objSTOCK.TEMPRECONO = RECONO
                objSTOCK.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
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

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbilldetails_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbilldetails.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SANO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SANO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Store Stock Adjustment Out Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Store Stock Adjustment Out Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Store Stock Adjustment Out Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Store Stock Adjustment Out Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

End Class