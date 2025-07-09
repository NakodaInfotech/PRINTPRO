
Imports System.Windows.Forms
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class SelectJob
    Dim addcol As Integer = 0
    Public DT As New DataTable
    Dim N As Integer = 0
    Dim tempindex, i As Integer
    Dim col As New DataGridViewCheckBoxColumn  'Dim dt As New DataTable
    Public ENQname As String = ""  'for whereclause in fillgrid
    Public TEMPORNO As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectJob_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub SelectJob_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FILLGRID()
    End Sub

    Sub FILLGRID()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            If ClientName = "AMR" Then
                DT = OBJCMN.search("CAST (0 AS BIT) AS CHK,ISNULL(jobmaster.job_no, 0) AS JOBNO, ISNULL(jobmaster.job_pono, '') AS PONO, LEDGERS.ACC_CMPNAME AS NAME, jobmaster.job_date AS DATE, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ITEM_NAME AS ITEMNAME, ISNULL(jobmaster.job_MADEQTY, 0) AS QTY", "", " jobmaster INNER JOIN ITEMMASTER ON jobmaster.job_itemid = ITEMMASTER.item_id AND jobmaster.job_yearid = ITEMMASTER.item_yearid INNER JOIN LEDGERS ON JOB_LEDGERID = LEDGERS.ACC_ID", " and JOBMASTER.JOB_DONE = 0 AND JOBMASTER.job_tempprocessno = 10 AND (jobmaster.job_MADEQTY)>0 AND JOBMASTER.JOB_YEARID=" & YearId & " ORDER BY JOBMASTER.JOB_NO ")
                'DT = OBJCMN.search("CAST (0 AS BIT) AS CHK,ISNULL(ASSEMBLYQC.AS_NO, 0) AS JOBNO, ASSEMBLYQC.AS_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ALLORDERMASTER.ORDER_PONO, '') AS PONO, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(ASSEMBLYQC.AS_QTY, 0) AS QTY", "", " ASSEMBLYQC INNER JOIN ALLORDERMASTER ON ASSEMBLYQC.AS_ORDERNO = ALLORDERMASTER.ORDER_NO LEFT OUTER JOIN ITEMMASTER ON ASSEMBLYQC.AS_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS ON ASSEMBLYQC.AS_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN ALLORDERMASTER_DESC ON ALLORDERMASTER.ORDER_NO = ALLORDERMASTER_DESC.ORDER_NO AND ALLORDERMASTER.ORDER_YEARID = ALLORDERMASTER_DESC.ORDER_YEARID ", " and ASSEMBLYQC.AS_DONE = 0 AND ASSEMBLYQC.AS_YEARID=" & YearId & " ORDER BY ASSEMBLYQC.AS_NO ")

            Else
                DT = OBJCMN.search("CAST (0 AS BIT) AS CHK,ISNULL(jobmaster.job_no, 0) AS JOBNO, ISNULL(jobmaster.job_pono, '') AS PONO, LEDGERS.ACC_CMPNAME AS NAME, jobmaster.job_date AS DATE, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ITEM_NAME AS ITEMNAME, ISNULL(jobmaster.job_MADEQTY, 0) AS QTY", "", " jobmaster INNER JOIN ITEMMASTER ON jobmaster.job_itemid = ITEMMASTER.item_id AND jobmaster.job_yearid = ITEMMASTER.item_yearid INNER JOIN LEDGERS ON JOB_LEDGERID = LEDGERS.ACC_ID", " and JOBMASTER.JOB_DONE = 0 AND JOBMASTER.job_tempprocessno = 9 AND (jobmaster.job_MADEQTY)>0 AND JOBMASTER.JOB_YEARID=" & YearId & " ORDER BY JOBMASTER.JOB_NO ")
            End If
            gridjobdetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridjob.FocusedRowHandle = gridjob.RowCount - 1
                gridjob.TopRowIndex = gridjob.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Dim COUNT As Integer
            For i As Integer = 0 To gridjob.RowCount - 1
                Dim dtrow As DataRow = gridjob.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    COUNT = COUNT + 1
                End If
            Next

            If COUNT > 1 Then
                MsgBox("You Can Select Only One Order")
                Exit Sub
            End If

            DT.Columns.Add("JOBNO")

            For i As Integer = 0 To gridjob.RowCount - 1
                Dim dtrow As DataRow = gridjob.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("JOBNO"))
                End If
            Next

            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class