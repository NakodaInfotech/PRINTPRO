
Imports System.Windows.Forms
Imports BL
Imports DevExpress.XtraGrid.Views.Grid


Public Class SelectAssembly

    Public DT As New DataTable
    Dim col As New DataGridViewCheckBoxColumn  'Dim dt As New DataTable
    Public TYPE As String = ""


    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectAssembly_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectAssembly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub FILLGRID()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            If ClientName = "AMR" Then
                'DT = OBJCMN.search("CAST (0 AS BIT) AS CHK,ISNULL(jobmaster.job_no, 0) AS JOBNO, ISNULL(jobmaster.job_pono, '') AS PONO, LEDGERS.ACC_CMPNAME AS NAME, jobmaster.job_date AS DATE, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ITEM_NAME AS ITEMNAME, ISNULL(jobmaster.job_MADEQTY, 0) AS QTY", "", " jobmaster INNER JOIN ITEMMASTER ON jobmaster.job_itemid = ITEMMASTER.item_id AND jobmaster.job_yearid = ITEMMASTER.item_yearid INNER JOIN LEDGERS ON JOB_LEDGERID = LEDGERS.ACC_ID", " and JOBMASTER.JOB_DONE = 0 AND JOBMASTER.job_tempprocessno = 10 AND (jobmaster.job_MADEQTY)>0 AND JOBMASTER.JOB_YEARID=" & YearId & " ORDER BY JOBMASTER.JOB_NO ")
                '  DT = OBJCMN.search("CAST (0 AS BIT) AS CHK,ISNULL(ASSEMBLYQC.AS_NO, 0) AS ASNO, ASSEMBLYQC.AS_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS PARTYNAME, ISNULL(LEDGERS.Acc_add, '') AS ADDRESS, ISNULL(ITEMMASTER.item_code, '')  AS ITEMCODE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(ITEMMASTER.ITEM_MATERIALCODE, '') AS MCODE, ISNULL(ASSEMBLYQC.AS_BATCHNO, 0) AS BATCHNO,  ISNULL(ASSEMBLYQC.AS_TOTALPACKETS, 0) AS PACKETS, ISNULL(ASSEMBLYQC.AS_TOTALSHIPPERS, 0) AS SHIPPERS, ISNULL(ASSEMBLYQC.AS_QTY, '') AS QTY, ISNULL(ALLORDERMASTER.ORDER_PONO, '') AS PONO,  ALLORDERMASTER.ORDER_PODATE AS PODATE, ISNULL(ALLORDERMASTER.ORDER_REFNO, '') AS REFNO, ISNULL(ASSEMBLYQC.AS_ORDERNO, 0) AS ORDERNO, ISNULL(ASSEMBLYQC.AS_ORDERSRNO, 0)  AS ORDERSRNO ", "", " ASSEMBLYQC INNER JOIN ALLORDERMASTER ON ASSEMBLYQC.AS_ORDERNO = ALLORDERMASTER.ORDER_NO LEFT OUTER JOIN ITEMMASTER ON ASSEMBLYQC.AS_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS ON ASSEMBLYQC.AS_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN ALLORDERMASTER_DESC ON ALLORDERMASTER.ORDER_NO = ALLORDERMASTER_DESC.ORDER_NO AND ALLORDERMASTER.ORDER_YEARID = ALLORDERMASTER_DESC.ORDER_YEARID ", " and ASSEMBLYQC.AS_DONE = 0 AND ASSEMBLYQC.AS_YEARID=" & YearId & " ORDER BY ASSEMBLYQC.AS_NO ")
                DT = OBJCMN.search("CAST(0 AS BIT) AS CHK, ISNULL(ASSEMBLYQC.AS_NO, 0) AS ASNO, ASSEMBLYQC.AS_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS PARTYNAME, ISNULL(LEDGERS.Acc_add, '') AS ADDRESS,  ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(ITEMMASTER.ITEM_MATERIALCODE, '') AS MCODE, ISNULL(ASSEMBLYQC.AS_BATCHNO, 0) AS BATCHNO, ISNULL(ASSEMBLYQC.AS_TOTALPACKETS, 0) AS PACKETS, ISNULL(ASSEMBLYQC.AS_TOTALSHIPPERS, 0) AS SHIPPERS, ISNULL(ASSEMBLYQC.AS_QTY, '') AS QTY, ISNULL(ALLORDERMASTER.ORDER_PONO, '') AS PONO,  ALLORDERMASTER.ORDER_PODATE AS PODATE, ISNULL(ALLORDERMASTER.ORDER_REFNO, '') AS REFNO, ISNULL(ASSEMBLYQC.AS_ORDERNO, 0) AS ORDERNO, ISNULL(ASSEMBLYQC.AS_ORDERSRNO, 0)  AS ORDERSRNO", "", "  ASSEMBLYQC INNER JOIN ALLORDERMASTER ON ASSEMBLYQC.AS_ORDERNO = ALLORDERMASTER.ORDER_NO INNER JOIN ALLORDERMASTER_DESC ON ASSEMBLYQC.AS_ORDERSRNO = ALLORDERMASTER_DESC.ORDER_GRIDSRNO AND ALLORDERMASTER.ORDER_NO = ALLORDERMASTER_DESC.ORDER_NO AND  ALLORDERMASTER.ORDER_YEARID = ALLORDERMASTER_DESC.ORDER_YEARID AND ALLORDERMASTER.TYPE = ALLORDERMASTER_DESC.TYPE AND  ASSEMBLYQC.AS_YEARID = ALLORDERMASTER_DESC.ORDER_YEARID LEFT OUTER JOIN ITEMMASTER ON ASSEMBLYQC.AS_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS ON ASSEMBLYQC.AS_LEDGERID = LEDGERS.Acc_id", " and ASSEMBLYQC.AS_DONE = 0 AND ASSEMBLYQC.AS_YEARID=" & YearId & " ORDER BY ASSEMBLYQC.AS_NO ")

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

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try
            Dim COUNT As Integer
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    COUNT = COUNT + 1
                End If
            Next

            If COUNT > 1 Then
                MsgBox("You Can Select Only One Assembly")
                Exit Sub
            End If

            DT.Columns.Add("JOBNO")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("ASNO"))
                End If
            Next

            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class