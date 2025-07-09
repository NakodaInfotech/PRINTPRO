

Imports BL

Public Class StoreStockRecoInDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub StockRecoInDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub StockRecoInDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            Dim dt As DataTable = objclsCMST.search(" ISNULL(STORESTOCKADJUSTMENT_INDESC.SA_NO, 0) AS SANO,ISNULL(STORESTOCKADJUSTMENT_INDESC.SA_INGRIDSRNO, 0) AS GRIDSRNO, ISNULL(STORESTOCKADJUSTMENT_INDESC.SA_INLOTNO, '') AS INLOTNO, ISNULL(STORESTOCKADJUSTMENT_INDESC.SA_INDESC, '') AS INDESC, ISNULL(STORESTOCKADJUSTMENT_INDESC.SA_INQTY, 0) AS INQTY, ISNULL(STORESTOCKADJUSTMENT.SA_CHALLANNO, '') AS CHALLANNO, ISNULL(STORESTOCKADJUSTMENT_INDESC.SA_INWT, 0) AS INWT, ISNULL(STORESTOCKADJUSTMENT_INDESC.SA_INSIZE, '') AS INSIZE, ISNULL(STORESTOCKADJUSTMENT_INDESC.SA_INSHEETS, 0) AS INSHEETS, STORESTOCKADJUSTMENT.SA_date AS DATE, ISNULL(UNITMASTER.unit_abbr, '') AS INUNIT, ISNULL(NONINVITEMMASTER.NONINV_NAME,'') AS INITEMNAME", "", "  STORESTOCKADJUSTMENT INNER JOIN STORESTOCKADJUSTMENT_INDESC ON STORESTOCKADJUSTMENT.SA_no = STORESTOCKADJUSTMENT_INDESC.SA_NO AND  STORESTOCKADJUSTMENT.SA_yearid = STORESTOCKADJUSTMENT_INDESC.SA_YEARID LEFT OUTER JOIN UNITMASTER ON STORESTOCKADJUSTMENT_INDESC.SA_UNITID = UNITMASTER.unit_id LEFT OUTER JOIN NONINVITEMMASTER ON STORESTOCKADJUSTMENT_INDESC.SA_INITEMID = NONINVITEMMASTER.NONINV_ID ", " AND STORESTOCKADJUSTMENT.SA_yearid=" & YearId & " order by STORESTOCKADJUSTMENT.SA_NO")
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
            showform(True, gridbill.GetFocusedRowCellValue("GRIDSRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("GRIDSRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Store Stock Adjustment In Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = " Store Stock Adjustment In Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Store Stock Adjustment In Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Store Stock Adjustment In Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

End Class