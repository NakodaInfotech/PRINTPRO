Imports BL
Public Class SelectJobDocketMudra

    Dim addcol As Integer = 0
    Public DT As New DataTable
    Dim N As Integer = 0
    Dim tempindex, i As Integer
    Dim col As New DataGridViewCheckBoxColumn  'Dim dt As New DataTable
    Public ENQname As String = ""  'for whereclause in fillgrid
    Public TEMPJOBDOCKETNO As Integer

    Private Sub cmdexit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectJobDocketMudra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub fillgrid()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim objcmn As New ClsCommon
            Dim dt As DataTable
            'dt = objcmn.search(" CAST(0 AS BIT) AS CHK, ORDERMASTER.ORDER_NO AS ORDERNO, ORDERMASTER.ORDER_PONO AS PONO, ORDERMASTER.ORDER_DTPICKER AS DATE,ORDERMASTER_DESC.ORDER_GRIDSRNO AS ORDERSRNO, ISNULL(itemmaster.item_code, '') AS ITEMCODE, ISNULL(itemmaster.item_NAME, '') AS ITEMNAME, ISNULL(ORDERMASTER_DESC.ORDER_QTY - ORDERMASTER_DESC.ORDER_OUTQTY, 0) AS QUANTITY, LEDGERS.ACC_CMPNAME AS NAME", "", " ORDERMASTER INNER JOIN ORDERMASTER_DESC ON ORDERMASTER.ORDER_NO = ORDERMASTER_DESC.ORDER_NO AND ORDERMASTER.ORDER_YEARID = ORDERMASTER_DESC.ORDER_YEARID INNER JOIN LEDGERS ON ORDERMASTER.ORDER_LEDGERID = LEDGERS.Acc_id INNER JOIN itemmaster ON ORDERMASTER_DESC.ORDER_ITEMID = itemmaster.item_id AND ORDERMASTER_DESC.ORDER_YEARID = itemmaster.item_yearid ", "and ISNULL(ORDERMASTER_DESC.ORDER_QTY - ORDERMASTER_DESC.ORDER_OUTQTY, 0)>0 AND ISNULL(ORDERMASTER_DESC.ORDER_CLOSE,0)=0 and ORDERMASTER.order_YEARID=" & YearId & " ORDER BY ORDERMASTER.ORDER_NO ")
            dt = objcmn.search(" CAST(0 AS BIT) AS CHK,JOBBATCHMASTERMUDRA.JOB_DATE AS DATE, ISNULL(JOBBATCHMASTERMUDRA.JOB_QTY, 0) AS QTY, ROUND(JOBBATCHMASTERMUDRA.JOB_OUTQTY - JOBBATCHMASTERMUDRA.JOB_OUTQTY, 0) AS REMQTY, ISNULL(JOBBATCHMASTERMUDRA.JOB_NO, 0) AS JOBNO, ISNULL(LEDGERS.Acc_cmpname, '') AS PARTYNAME, ISNULL(ITEMMASTER.item_name, '') AS MAINITEMNAME, ISNULL(SUBITEMMASTER.item_code, '') AS ITEMNAME", "", "  JOBBATCHMASTERMUDRA INNER JOIN ITEMMASTER_BOMDETAILS ON JOBBATCHMASTERMUDRA.JOB_ITEMNAMEID = ITEMMASTER_BOMDETAILS.ITEM_ID INNER JOIN ITEMMASTER AS SUBITEMMASTER ON ITEMMASTER_BOMDETAILS.ITEM_SUBITEMID = SUBITEMMASTER.item_id LEFT OUTER JOIN ITEMMASTER ON JOBBATCHMASTERMUDRA.JOB_MAINITEMNAMEID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS ON JOBBATCHMASTERMUDRA.JOB_LEDGERID = LEDGERS.Acc_id", " AND (JOBBATCHMASTERMUDRA.job_qty - JOBBATCHMASTERMUDRA.JOB_OUTQTY)> 0  and JOBBATCHMASTERMUDRA.JOB_YEARID=" & YearId & " ORDER BY JOBBATCHMASTERMUDRA.JOB_NO ")
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

    Private Sub SelectJobDocketMudra_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillgrid()
    End Sub

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Dim COUNT As Integer = 0
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    COUNT = COUNT + 1
                End If
            Next

            If COUNT > 1 Then
                MsgBox("You Can Select Only One Docket")

                Exit Sub
            End If

            DT.Columns.Add("JOBNO")
            DT.Columns.Add("PARTYNAME")
            DT.Columns.Add("MAINITEMNAME")
            DT.Columns.Add("QTY")
            DT.Columns.Add("DATE")
            DT.Columns.Add("REMQTY")
            DT.Columns.Add("ITEMNAME")


            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("JOBNO"), dtrow("PARTYNAME"), dtrow("MAINITEMNAME"), dtrow("QTY"), dtrow("DATE"), dtrow("REMQTY"), dtrow("ITEMNAME"))
                End If
            Next

            Me.Close()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class