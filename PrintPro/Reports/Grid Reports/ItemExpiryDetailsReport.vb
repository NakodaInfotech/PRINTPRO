
Imports BL

Public Class ItemExpiryDetailsReport

    Public WHERECLAUSE As String
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub ItemDetailsReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal WHERECLAUSE As String)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search("  ISNULL(ITEMMASTER.item_fileno, '') AS FILENO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(ITEMMASTER.item_leaflet, '') AS TYPE, ISNULL(COORDINATORMASTER.COORDINATOR_NAME, '') AS COORDINATORNAME, ISNULL(ITEMMASTER.item_artist, '') AS ARTIST, ISNULL(ITEMMASTER.item_links,'') AS LINKS, ISNULL(ITEMMASTER.item_fonts, '') AS FONTS, ISNULL(ITEMMASTER.item_software, '') AS SOFTWARE, ISNULL(PAPERGSMMASTER.PAPERGSM_NAME, '') AS PAPERGSM, ISNULL(ITEMMASTER.item_screen, '') AS SCREEN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(DESIGNMASTER.design_name, '') AS DESIGN, ISNULL(ITEMMASTER.item_pharmacode, '') AS PHARMACODE, ISNULL(ITEMMASTER.item_varnish, '') AS VARNISH, ISNULL(PAPERMATERIALMASTER.PAPERMATERIAL_NAME, '') AS PAPERMATERIALNAME, ISNULL(ITEMMASTER.item_cutsize, '') AS CUTSIZE, ISNULL(ITEMMASTER.item_v, '') AS VERTICAL, ISNULL(ITEMMASTER.item_h, '') AS HORIZONTAL, ISNULL(ITEMMASTER.item_ups, '') AS UPS, ISNULL(PAPERSIZEMASTER.PAPERSIZE_NAME, '') AS PAPERSIZENAME, ISNULL(ITEMMASTER.item_repeatlength, '') AS REPEATLENGTH, ISNULL(GRAINMASTER.grain_name, '') AS GRAIN, ISNULL(ITEMMASTER.ITEM_SIDEPRINT, '') AS SIDEPRINT, ISNULL(ITEMMASTER.item_artwork, '') AS ARTWORK, ISNULL(ITEMMASTER.item_remarks, '') AS REMARKS, ISNULL(TEARTAPEMASTER.TEARTAPE_NAME, '') AS TEARTAPE, ISNULL(ITEMMASTER.ITEM_KNIFE, 0) AS KNIFES, ISNULL(ITEMMASTER.ITEM_MATERIALCODE, '') AS MATERIALCODE, ISNULL(ITEMMASTER.ITEM_PROOFSEND, 0) AS PROOFSEND, ISNULL(ITEMMASTER.ITEM_PROOFOK, 0) AS PROOFOK, ISNULL(ITEMMASTER.ITEM_PERFORATION, 0) AS PERFORATION, ISNULL(ITEMMASTER.ITEM_SHADECARD, 0) AS SHADECARD, ISNULL(ITEMMASTER.ITEM_SHADEAPPROVE, 0) AS SHADEAPPROVE, ISNULL(ITEMMASTER.ITEM_SHADEDATE, '') AS SHADEDATE, ISNULL(ITEMMASTER.item_actualsizewidth, '') AS ACTUALWIDTH, ISNULL(ITEMMASTER.item_actualsizeheight, '') AS ACTUALHEIGHT, ISNULL(ITEMMASTER.item_sizefoldingwidth, '') AS FOLDWIDTH, ISNULL(ITEMMASTER.item_sizefoldingheight, '') AS FOLDHEIGHT, ISNULL(ITEMMASTER.ITEM_ARTWORKDATE, '') AS ARTWORKDATE, ISNULL(ITEMMASTER.ITEM_PROOFSENDDATE, '') AS PROOFSENDDATE, ISNULL(ITEMMASTER.ITEM_PROOFOKDATE, '') AS PROOFOKDATE, ISNULL(ITEMMASTER.ITEM_SHADESENDDATE, '') AS SHADESENDDATE, ISNULL(ITEMMASTER.ITEM_SHADEAPPDATE, '') AS SHADEAPPDATE, ISNULL(ITEMMASTER.ITEM_FOLDED, 0) AS FOLDED, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE ", "", " LEDGERS INNER JOIN ACCOUNTSMASTER_SHADECARD ON LEDGERS.Acc_id = ACCOUNTSMASTER_SHADECARD.ACC_ID INNER JOIN ITEMMASTER ON ACCOUNTSMASTER_SHADECARD.ACC_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN TEARTAPEMASTER ON ITEMMASTER.ITEM_TEARTAPEID = TEARTAPEMASTER.TEARTAPE_ID LEFT OUTER JOIN DESIGNMASTER ON ITEMMASTER.item_designid = DESIGNMASTER.design_id AND ITEMMASTER.item_yearid = DESIGNMASTER.design_yearid LEFT OUTER JOIN PAPERSIZEMASTER ON ITEMMASTER.item_papersizeid = PAPERSIZEMASTER.PAPERSIZE_ID AND ITEMMASTER.item_yearid = PAPERSIZEMASTER.PAPERSIZE_YEARID LEFT OUTER JOIN COLORMASTER ON ITEMMASTER.item_colorid = COLORMASTER.COLOR_id AND ITEMMASTER.item_yearid = COLORMASTER.COLOR_yearid LEFT OUTER JOIN PAPERMATERIALMASTER ON ITEMMASTER.item_papermaterialid = PAPERMATERIALMASTER.PAPERMATERIAL_ID AND ITEMMASTER.item_yearid = PAPERMATERIALMASTER.PAPERMATERIAL_YEARID LEFT OUTER JOIN GRAINMASTER ON ITEMMASTER.item_grainid = GRAINMASTER.grain_id AND ITEMMASTER.item_yearid = GRAINMASTER.grain_yearid LEFT OUTER JOIN COORDINATORMASTER ON ITEMMASTER.item_coordinatorid = COORDINATORMASTER.COORDINATOR_ID AND ITEMMASTER.item_yearid = COORDINATORMASTER.COORDINATOR_YEARID LEFT OUTER JOIN PAPERGSMMASTER ON ITEMMASTER.item_papergsmid = PAPERGSMMASTER.PAPERGSM_ID AND ITEMMASTER.item_yearid = PAPERGSMMASTER.PAPERGSM_YEARID ", WHERECLAUSE & "AND item_yearid = " & YearId & " ORDER BY ITEM_NAME")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then gridbill.FocusedRowHandle = gridbill.RowCount - 1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPRINT.Click
        Try
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Item Expiry Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()
            'For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
            '    proc.Kill()
            'Next

            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Item Expiry Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Item Expiry Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ItemDetailsReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid("" & WHERECLAUSE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSAVE.Click
        Try
            fillgrid("" & WHERECLAUSE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class