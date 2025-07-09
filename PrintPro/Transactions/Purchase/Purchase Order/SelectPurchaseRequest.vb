
Imports System.Windows.Forms
Imports BL
Imports DevExpress.XtraGrid.Views.Grid
Public Class SelectPurchaseRequest

    Public DT As New DataTable

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectPurchaseRequest_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectPurchaseRequest_Load(sender As Object, e As EventArgs) Handles Me.Load
        fillgrid()
    End Sub
    Sub fillgrid(Optional ByVal where As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            'If PARTYNAME <> "" Then where = where & " AND LEDGERS.Acc_cmpname='" & PARTYNAME & "'"

            Dim objcmn As New ClsCommon
            Dim dt As DataTable
            'If FRMSTRING = "ASSEMBLY" Then
            '    dt = objcmn.search("  CAST(0 AS BIT) AS CHK, ISNULL(ALLORDERMASTER.ORDER_NO, 0) AS ORDERNO, ISNULL(ALLORDERMASTER_DESC.ORDER_GRIDSRNO, 0) AS ORDERSRNO, ISNULL(ALLORDERMASTER_DESC.ORDER_QTY, 0) AS QUANTITY, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ALLORDERMASTER.TYPE, '') AS ORDERTYPE,  ISNULL(BATCHMASTER.jobbatch_no, 0) AS BATCHNO, ISNULL(BATCHMASTER.JOBBATCH_TOTALSHEETS, 0) AS TOTALSHEET, ISNULL(BATCHMASTER.jobbatch_docketno, 0) AS JOBDOCKETNO, ISNULL(BATCHMASTER.jobbatch_percentage, 0) AS PERCENTAGE ", "", " ALLORDERMASTER INNER JOIN ALLORDERMASTER_DESC ON ALLORDERMASTER.ORDER_NO = ALLORDERMASTER_DESC.ORDER_NO AND ALLORDERMASTER.ORDER_YEARID = ALLORDERMASTER_DESC.ORDER_YEARID INNER JOIN BATCHMASTER ON ALLORDERMASTER.ORDER_NO = BATCHMASTER.jobbatch_no AND ALLORDERMASTER.ORDER_YEARID = BATCHMASTER.jobbatch_yearid LEFT OUTER JOIN ITEMMASTER ON ALLORDERMASTER_DESC.ORDER_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS ON ALLORDERMASTER.ORDER_LEDGERID = LEDGERS.Acc_id", " AND  ALLORDERMASTER.ORDER_YEARID=" & YearId & where & " ORDER BY ALLORDERMASTER.ORDER_NO ")
            'Else
            dt = objcmn.search("CAST(0 AS BIT) AS CHK, ISNULL(PURCHASEREQUEST_DESC.REQ_JOBDOCKETNO, 0) AS JOBDOCKETNO, ISNULL(LEDGERS.Acc_cmpname, '') AS PARTYNAME, ISNULL(PURCHASEREQUEST_DESC.REQ_QTY, 0) AS QTY,  ISNULL(PURCHASEREQUEST.REQ_NO, 0) AS REQNO, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME", "", "PURCHASEREQUEST_DESC INNER JOIN PURCHASEREQUEST ON PURCHASEREQUEST_DESC.REQ_NO = PURCHASEREQUEST.REQ_NO AND PURCHASEREQUEST_DESC.REQ_YEARID = PURCHASEREQUEST.REQ_YEARID LEFT OUTER JOIN JOBBATCHMASTER ON PURCHASEREQUEST_DESC.REQ_JOBDOCKETNO = JOBBATCHMASTER.job_no AND PURCHASEREQUEST_DESC.REQ_YEARID = JOBBATCHMASTER.job_yearid LEFT OUTER JOIN LEDGERS ON PURCHASEREQUEST_DESC.REQ_YEARID = LEDGERS.Acc_yearid AND PURCHASEREQUEST_DESC.REQ_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN NONINVITEMMASTER ON PURCHASEREQUEST_DESC.REQ_PAPERNAMEID = NONINVITEMMASTER.NONINV_ID", " AND PURCHASEREQUEST_DESC.REQ_DONE = 0 AND  PURCHASEREQUEST_DESC.REQ_YEARID=" & YearId & "  ORDER BY PURCHASEREQUEST_DESC.REQ_JOBDOCKETNO")
            '  End If
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try

            Dim COUNT As Integer = 0
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    COUNT = COUNT + 1
                End If
            Next
            If COUNT > 1 Then
                MsgBox("You Can Select Only One Batch")

                Exit Sub
            End If
            DT.Columns.Add("REQNO")
            DT.Columns.Add("ITEMNAME")
            DT.Columns.Add("QTY")


            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("REQNO"), dtrow("ITEMNAME"), dtrow("QTY"))
                End If
            Next

            Me.Close()



        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class