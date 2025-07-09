
Imports System.Windows.Forms
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class SelectPO
    Public DT As New DataTable
    Public TEMPPONO As Integer
    Public PARTYNAME As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectPO_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub SelectPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FILLGRID("")
    End Sub

    Sub FILLGRID(ByVal WHERE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim OBJCMN As New ClsCommon
            'Dim DT As DataTable = OBJCMN.search("CAST (0 AS BIT) AS CHK,ISNULL(PURCHASEORDER.PO_NO, 0) AS PONO, ISNULL(PURCHASEORDER_DESC.PO_SRNO, 0) AS POSRNO, PURCHASEORDER.PO_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME,  ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME, ISNULL(PURCHASEORDER_DESC.PO_QTY - PURCHASEORDER_DESC.PO_OUTQTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT ", "", " PURCHASEORDER INNER JOIN PURCHASEORDER_DESC ON PURCHASEORDER.PO_NO = PURCHASEORDER_DESC.PO_NO AND  PURCHASEORDER.PO_YEARID = PURCHASEORDER_DESC.PO_YEARID INNER JOIN LEDGERS ON PURCHASEORDER.PO_LEDGERID = LEDGERS.Acc_id AND PURCHASEORDER.PO_YEARID = LEDGERS.Acc_yearid INNER JOIN NONINVITEMMASTER ON PURCHASEORDER_DESC.PO_ITEMID = NONINVITEMMASTER.NONINV_ID AND PURCHASEORDER_DESC.PO_YEARID = NONINVITEMMASTER.NONINV_YEARID INNER JOIN UNITMASTER ON PURCHASEORDER_DESC.PO_UNITID = UNITMASTER.unit_id AND PURCHASEORDER_DESC.PO_YEARID = UNITMASTER.unit_yearid", " and PURCHASEORDER_DESC.PO_CLOSE = 'False' and (PURCHASEORDER_DESC.PO_QTY - PURCHASEORDER_DESC.PO_OUTQTY) > 0 AND LEDGERS.Acc_cmpname = '" & PARTYNAME & "' AND PURCHASEORDER.PO_YEARID=" & YearId & " ORDER BY PURCHASEORDER.PO_NO ")
            Dim DT As DataTable = OBJCMN.search("CAST (0 AS BIT) AS CHK,ISNULL(ALLPURCHASEORDER.PO_NO, 0) AS PONO, ISNULL(ALLPURCHASEORDER_DESC.PO_SRNO, 0) AS POSRNO, ALLPURCHASEORDER.PO_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME,  ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME, ISNULL(ALLPURCHASEORDER_DESC.PO_QTY - ALLPURCHASEORDER_DESC.PO_OUTQTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ALLPURCHASEORDER.TYPE AS TYPE , ISNULL(ALLPURCHASEORDER_DESC.PO_RATE, 0) AS RATE", "", " ALLPURCHASEORDER INNER JOIN ALLPURCHASEORDER_DESC ON ALLPURCHASEORDER.PO_NO = ALLPURCHASEORDER_DESC.PO_NO AND ALLPURCHASEORDER.TYPE = ALLPURCHASEORDER_DESC.TYPE AND  ALLPURCHASEORDER.PO_YEARID = ALLPURCHASEORDER_DESC.PO_YEARID INNER JOIN LEDGERS ON ALLPURCHASEORDER.PO_LEDGERID = LEDGERS.Acc_id AND ALLPURCHASEORDER.PO_YEARID = LEDGERS.Acc_yearid INNER JOIN NONINVITEMMASTER ON ALLPURCHASEORDER_DESC.PO_ITEMID = NONINVITEMMASTER.NONINV_ID AND ALLPURCHASEORDER_DESC.PO_YEARID = NONINVITEMMASTER.NONINV_YEARID INNER JOIN UNITMASTER ON ALLPURCHASEORDER_DESC.PO_UNITID = UNITMASTER.unit_id AND ALLPURCHASEORDER_DESC.PO_YEARID = UNITMASTER.unit_yearid", " and ALLPURCHASEORDER_DESC.PO_CLOSE = 'False' AND ALLPURCHASEORDER.PO_VERIFIED = 'True' and (ALLPURCHASEORDER_DESC.PO_QTY - ALLPURCHASEORDER_DESC.PO_OUTQTY) > 0 AND LEDGERS.Acc_cmpname = '" & PARTYNAME & "' AND ALLPURCHASEORDER.PO_YEARID=" & YearId & " ORDER BY ALLPURCHASEORDER.PO_NO ")
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
            'Dim COUNT As Integer
            'For i As Integer = 0 To gridbill.RowCount - 1
            '    Dim dtrow As DataRow = gridbill.GetDataRow(i)
            '    If Convert.ToBoolean(dtrow("CHK")) = True Then
            '        COUNT = COUNT + 1
            '    End If
            'Next

            'If COUNT > 1 Then
            '    MsgBox("You Can Select Only One Order")
            '    Exit Sub
            'End If

            DT.Columns.Add("PONO")
            DT.Columns.Add("POSRNO")
            DT.Columns.Add("TYPE")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(Val(dtrow("PONO")), Val(dtrow("POSRNO")), dtrow("TYPE"))
                End If
            Next

            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class