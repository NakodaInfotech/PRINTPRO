
Imports BL

Public Class OpeningStockGridReport
    Public EDIT As Boolean
    Dim temppreqno As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Opening Stock Grid Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Opening Stock Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Opening Stock Grid Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            MsgBox("Opening Stock Grid Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub OpeningStockGridReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'OPENING'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search("  STOCKMASTER.SM_GRIDSRNO AS SRNO, STOCKMASTER.SM_DATE AS DATE, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(STOCKMASTER.SM_WT, 0) AS WT, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(SHELFMASTER.SHELF_name, '') AS SHELF, ISNULL(STOCKMASTER.SM_SIZE, '') AS SIZE, ISNULL(STOCKMASTER.SM_PPRSRNO, '') AS PPRSRNO, ISNULL(STOCKMASTER.SM_BATCHNO, '') AS BATCHNO, ISNULL(STOCKMASTER.SM_QTY, 0) AS QTY, ISNULL(STOCKMASTER.SM_TYPE, '') AS TYPE, STOCKMASTER.SM_YEARID, STOCKMASTER.SM_CMPID, STOCKMASTER.SM_LOCATIONID, STOCKMASTER.SM_USERID, ISNULL(STOCKMASTER.SM_NO, 0) AS SMNO ", "", " STOCKMASTER LEFT OUTER JOIN SHELFMASTER ON STOCKMASTER.SM_SHELFID = SHELFMASTER.SHELF_id LEFT OUTER JOIN LEDGERS ON STOCKMASTER.SM_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN UNITMASTER ON STOCKMASTER.SM_UNITID = UNITMASTER.unit_id LEFT OUTER JOIN GODOWNMASTER ON STOCKMASTER.SM_GODOWNID = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN NONINVITEMMASTER ON STOCKMASTER.SM_ITEMID = NONINVITEMMASTER.NONINV_INVITEMID", " and dbo.STOCKMASTER.SM_yearid=" & YearId & " order by dbo.STOCKMASTER.SM_no ")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Opening_Stock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class