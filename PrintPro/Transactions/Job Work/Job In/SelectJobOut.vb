Imports BL

Public Class SelectJobOut

    Public PARTYNAME As String = ""
    Public FRMSTRING As String = ""
    Public DT As New DataTable
    Public WHERECLAUSE As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectMfgforPS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectMfgforPS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillgrid("")
    End Sub

    Sub fillgrid(ByVal WHERE As String)
        Try

            Dim objclspreq As New ClsCommon()
            Dim DT As DataTable = objclspreq.search(" CAST(0 AS BIT) AS CHK,ISNULL(JOBOUT.JO_NO, 0) AS TEMPJONO, ISNULL(MAINITEMMASTER.item_name, '') AS MAINITEM, ISNULL(BOMITEMMASTER.item_code, '') AS BOMITEMCODE,ISNULL(PARTYMASTER.Acc_cmpname, '') AS PARTYNAME, ISNULL(JOBBERMASTER.Acc_cmpname, '') AS JOBBERNAME,  ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, JOBOUT.JO_DATE AS DATE, ISNULL(JOBOUT.JO_PROCESS, '') AS PROCESS,  ISNULL(JOBOUT.JO_JOBDOCKETNO, 0) AS JOBDOCKETNO, ISNULL(JOBOUT.JO_QTY, 0) AS QTY, ISNULL(JOBOUT.JO_CHALLANNO, '') AS CHALLANNO,  ISNULL(JOBOUT.JO_MOBILENO, 0) AS MOBILENO, ISNULL(JOBOUT.JO_ORDERTYPE, '') AS ORDERTYPE, ISNULL(JOBOUT.JO_VEHICLENO, '') AS VEHICLENO,  ISNULL(JOBOUT.JO_TOTALWT, 0) AS TOTALWT, ISNULL(JOBOUT.JO_TOTALAMOUNT, 0) AS TOTALAMOUNT, ISNULL(JOBOUT.JO_REMARKS, '') AS REMARKS,  ISNULL(JOBOUT_DESC.JO_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEM, ISNULL(JOBOUT_DESC.JO_PAPERGSM, '') AS PAPERGSM, ISNULL(JOBOUT_DESC.JO_LOTNO, '') AS LOTNO,  ISNULL(JOBOUT_DESC.JO_WT, 0) AS WT, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(JOBOUT_DESC.JO_GQTY, 0) AS GQTY,  ISNULL(JOBOUT_DESC.JO_RATE, 0) AS RATE, ISNULL(JOBOUT_DESC.JO_AMOUNT, 0) AS AMOUNT, ISNULL(JOBOUT_DESC.JO_OUTQTY, 0) AS OUTQTY, ISNULL(JOBOUT_DESC.JO_DONE, 0) AS JODONE, ISNULL(JOBOUT.JO_TOTALQTY, 0) AS TOTALQTY,  ISNULL(TRANSPORTMASTER.Acc_cmpname, '') AS TRANSPORT ", "", " UNITMASTER RIGHT OUTER JOIN JOBOUT_DESC INNER JOIN JOBOUT ON JOBOUT_DESC.JO_NO = JOBOUT.JO_NO AND JOBOUT_DESC.JO_yearid = JOBOUT.JO_yearid LEFT OUTER JOIN NONINVITEMMASTER ON JOBOUT_DESC.JO_ITEMID = NONINVITEMMASTER.NONINV_ID ON UNITMASTER.unit_id = JOBOUT_DESC.JO_UNITID LEFT OUTER JOIN LEDGERS AS TRANSPORTMASTER ON JOBOUT.JO_TRANSPORTID = TRANSPORTMASTER.Acc_id LEFT OUTER JOIN GODOWNMASTER ON JOBOUT.JO_GODOWNID = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN LEDGERS AS JOBBERMASTER ON JOBOUT.JO_JOBBERNAMEID = JOBBERMASTER.Acc_id LEFT OUTER JOIN LEDGERS AS PARTYMASTER ON JOBOUT.JO_PARTYNAMEID = PARTYMASTER.Acc_id LEFT OUTER JOIN ITEMMASTER AS BOMITEMMASTER ON JOBOUT.JO_BOMITEMCODEID = BOMITEMMASTER.item_id LEFT OUTER JOIN ITEMMASTER AS MAINITEMMASTER ON JOBOUT.JO_MAINITEMID = MAINITEMMASTER.item_id ", " AND JOBOUT_DESC.JO_DONE = 'FALSE' AND ROUND(JOBOUT_DESC.JO_GQTY - JOBOUT_DESC.JO_OUTQTY,0) > 0 AND JOBOUT.JO_YEARID =" & YearId & " ORDER BY JOBOUT.JO_NO ")
            gridbilldetails.DataSource = DT

            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try


            Dim COUNT As Integer = 0
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    COUNT = COUNT + 1
                End If
            Next
            If COUNT > 1 Then
                MsgBox("You Can Select Only One Job Out")

                Exit Sub
            End If

            DT.Columns.Add("TEMPJONO")
            DT.Columns.Add("JOBDOCKETNO")
            DT.Columns.Add("PARTYNAME")
            DT.Columns.Add("BOMITEMCODE")
            DT.Columns.Add("MAINITEM")
            DT.Columns.Add("QTY")
            DT.Columns.Add("GODOWN")
            DT.Columns.Add("JOBBERNAME")
            DT.Columns.Add("TRANSPORT")
            DT.Columns.Add("ITEM")
            DT.Columns.Add("PAPERGSM")
            DT.Columns.Add("LOTNO")
            DT.Columns.Add("WT")
            DT.Columns.Add("UNIT")
            DT.Columns.Add("GQTY")
            DT.Columns.Add("RATE")
            DT.Columns.Add("AMOUNT")


            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("TEMPJONO"), dtrow("JOBDOCKETNO"), dtrow("PARTYNAME"), dtrow("BOMITEMCODE"), dtrow("MAINITEM"), dtrow("QTY"), dtrow("GODOWN"), dtrow("JOBBERNAME"), dtrow("TRANSPORT"), dtrow("ITEM"), dtrow("PAPERGSM"), dtrow("LOTNO"), dtrow("WT"), dtrow("UNIT"), dtrow("GQTY"), dtrow("RATE"), dtrow("AMOUNT"))
                    ' Me.Close()
                    ' Exit Sub
                End If
            Next
            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            If gridbilldetails.Visible = True Then
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    dtrow("CHK") = CHKSELECTALL.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class