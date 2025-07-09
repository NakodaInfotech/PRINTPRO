
Imports BL

Public Class SelectGRN

    Public DT As New DataTable
    Public TEMPGRNNO As Integer
    Public PARTYNAME As String = ""
    Public FORMNAME As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectGRN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub SelectGRN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FILLGRID()
    End Sub

    Sub FILLGRID()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable
            If FORMNAME = "CHECKING" Then
                DT = OBJCMN.search("T.CHK,T.GRNNO,T.GRNSRNO,T.GRNDATE,T.NAME,T.ITEMNAME,T.LOTNO,T.SIZE,T.WT,T.QTY,T.UNIT,T.TRANSPORT,T.LRNO,T.LRDATE,T.[DESC],T.TYPE,T.PONO ", "", "(SELECT  CAST (0 AS BIT) AS CHK, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME,ISNULL(GRN_DESC.GRN_LOTNO, 0) AS LOTNO, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(TRANSPORT.Acc_cmpname, '') AS TRANSPORT, GRN.GRN_NO AS GRNNO, GRN.GRN_DATE AS GRNDATE, GRN_DESC.GRN_SRNO AS GRNSRNO, ISNULL(GRN_DESC.GRN_SIZE,0) AS SIZE, ISNULL(GRN_DESC.GRN_WT,0) AS WT, ISNULL((GRN_DESC.GRN_QTY - GRN_DESC.GRN_OUTQTY),0) AS QTY, ISNULL(GRN.GRN_LRNO, '0') AS LRNO, GRN.GRN_LRDATE AS LRDATE, ISNULL(GRN_DESC.GRN_DESC, '') AS [DESC], 'GRN' AS TYPE, ISNULL(GRN.GRN_PONO, '') AS PONO  FROM GRN INNER JOIN GRN_DESC ON GRN.GRN_NO = GRN_DESC.GRN_NO AND GRN.GRN_YEARID = GRN_DESC.GRN_YEARID INNER JOIN LEDGERS ON GRN.GRN_LEDGERID = LEDGERS.Acc_id INNER JOIN GODOWNMASTER ON GRN.GRN_GODOWNID = GODOWNMASTER.GODOWN_id INNER JOIN NONINVITEMMASTER ON GRN_DESC.GRN_ITEMID = NONINVITEMMASTER.NONINV_ID INNER JOIN UNITMASTER ON GRN_DESC.GRN_UNITID = UNITMASTER.unit_id LEFT OUTER JOIN LEDGERS AS TRANSPORT ON GRN.GRN_TRANSID = TRANSPORT.Acc_id WHERE (GRN_DESC.GRN_QTY-GRN_DESC.GRN_OUTQTY)>0  AND GRN.GRN_YEARID=" & YearId & " UNION ALL SELECT  CAST (0 AS BIT) AS CHK, ISNULL(LEDGERS.Acc_cmpname,0)AS NAME, ISNULL(GODOWNMASTER.GODOWN_name,0)AS GODOWN, ISNULL(NONINVITEMMASTER.NONINV_NAME,0)AS ITEMNAME,ISNULL(STOCKMASTER.SM_BATCHNO, '') AS LOTNO, ISNULL(UNITMASTER.unit_abbr,0), '' AS TRANSPORT, STOCKMASTER.SM_NO AS GRNNO, STOCKMASTER.SM_DATE AS GRNDATE, STOCKMASTER.SM_GRIDSRNO AS GRNSRNO, ISNULL(STOCKMASTER.SM_SIZE,0), ISNULL(STOCKMASTER.SM_WT,0), ISNULL((STOCKMASTER.SM_QTY - STOCKMASTER.SM_OUTQTY),0) AS QTY, '' AS LRNO, NULL AS LRDATE, '' AS [DESC], 'OPENING' AS TYPE, '' AS PONO FROM STOCKMASTER INNER JOIN GODOWNMASTER ON STOCKMASTER.SM_GODOWNID = GODOWNMASTER.GODOWN_id INNER JOIN NONINVITEMMASTER ON STOCKMASTER.SM_ITEMID = NONINVITEMMASTER.NONINV_ID INNER JOIN UNITMASTER ON STOCKMASTER.SM_UNITID = UNITMASTER.unit_id LEFT OUTER JOIN LEDGERS ON STOCKMASTER.SM_LEDGERID = LEDGERS.Acc_id  WHERE (STOCKMASTER.SM_QTY-STOCKMASTER.SM_OUTQTY)>0 AND STOCKMASTER.SM_YEARID=" & YearId & " and STOCKMASTER.SM_TYPE= 'On Approval') as t ", " ORDER BY T.GRNNO")
            Else
                DT = OBJCMN.search("  CAST(0 AS BIT) AS CHK, GRN.GRN_NO AS GRNNO, GRN_DESC.GRN_SRNO AS GRNSRNO, GRN.GRN_DATE AS GRNDATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME, ISNULL(GRN_DESC.GRN_LOTNO, 0) AS LOTNO, ISNULL(GRN_DESC.GRN_SIZE, 0) AS SIZE, ISNULL(GRN_DESC.GRN_WT, 0) AS WT, ISNULL(GRN_DESC.GRN_GSM, 0) AS GSM, ISNULL(GRN_DESC.GRN_RATE, 0) AS RATE, ISNULL(GRN_DESC.GRN_AMOUNT, 0) AS AMOUNT, GRN_DESC.GRN_QTY AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT,  ISNULL(TRANSPORT.Acc_cmpname, '') AS TRANSPORT, ISNULL(GRN.GRN_LRNO, '0') AS LRNO, GRN.GRN_LRDATE AS LRDATE, ISNULL(GRN_DESC.GRN_DESC, '')  AS [DESC], 'GRN' AS TYPE, ISNULL(GRN.GRN_PONO, 0) AS PONO ", "", "GRN INNER JOIN GRN_DESC ON GRN.GRN_NO = GRN_DESC.GRN_NO AND GRN.GRN_YEARID = GRN_DESC.GRN_YEARID INNER JOIN LEDGERS ON GRN.GRN_LEDGERID = LEDGERS.Acc_id INNER JOIN GODOWNMASTER ON GRN.GRN_GODOWNID = GODOWNMASTER.GODOWN_id INNER JOIN NONINVITEMMASTER ON GRN_DESC.GRN_ITEMID = NONINVITEMMASTER.NONINV_ID INNER JOIN UNITMASTER ON GRN_DESC.GRN_UNITID = UNITMASTER.unit_id LEFT OUTER JOIN LEDGERS AS TRANSPORT ON GRN.GRN_TRANSID = TRANSPORT.Acc_id", " AND ISNULL(LEDGERS.Acc_cmpname, '') = '" & PARTYNAME & "' AND (GRN.GRN_DONE = 0) AND GRN.GRN_YEARID = " & YearId & " ORDER BY GRN.GRN_NO")
            End If
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Dim n As String = ""
            Dim M As String = ""
            If FORMNAME = "CHECKING" Then
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If n <> "" Then
                            If n = (dtrow("GRNNO")) And M = (dtrow("TYPE")) Then
                                GoTo Line1
                            Else
                                MsgBox("Pls select same GRN !")
                                Exit Sub
                            End If
                        End If
Line1:
                        n = (dtrow("GRNNO"))
                        M = (dtrow("TYPE"))

                    End If
                Next
            End If

            DT.Columns.Add("GRNNO")
            DT.Columns.Add("GRNSRNO")
            DT.Columns.Add("TYPE")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("GRNNO"), dtrow("GRNSRNO"), dtrow("TYPE"))
                End If
            Next

            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class