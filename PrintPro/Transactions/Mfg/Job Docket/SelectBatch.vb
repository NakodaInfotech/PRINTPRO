
Imports System.Windows.Forms
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class SelectBatch
    Dim addcol As Integer = 0
    Public DT As New DataTable
    Dim N As Integer = 0
    Dim tempindex, i As Integer
    Dim col As New DataGridViewCheckBoxColumn  'Dim dt As New DataTable
    Public ENQname As String = ""  'for whereclause in fillgrid
    Public TEMPBATCHNO As Integer
    Public TYPE As String = ""
    Public FRMSTRING As String = ""
    Public PARTYNAME As String = ""



    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectBatch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub fillgrid(Optional ByVal where As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If PARTYNAME <> "" Then where = where & " AND LEDGERS.Acc_cmpname='" & PARTYNAME & "'"
            Dim objcmn As New ClsCommon
            Dim dt As DataTable
            'If TYPE = "PLATEISSUE" Then
            '    dt = objcmn.search(" CAST(0 AS BIT) AS CHK,  ISNULL(JOBBATCHMASTER.job_no, 0) AS JOBBATCHNO, ISNULL(BATCHMASTER.jobbatch_no, 0) AS BATCHNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(JOBBATCHMASTER.job_pono, '') AS PONO, BATCHMASTER.jobbatch_date AS BATCHDATE, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE,ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(BATCHMASTER.jobbatch_madeqty, 0) AS QTY", "", "   BATCHMASTER INNER JOIN JOBBATCHMASTER ON BATCHMASTER.jobbatch_docketno = JOBBATCHMASTER.job_no AND BATCHMASTER.jobbatch_yearid = JOBBATCHMASTER.job_yearid INNER JOIN ITEMMASTER ON BATCHMASTER.jobbatch_itemid = ITEMMASTER.item_id AND BATCHMASTER.jobbatch_yearid = ITEMMASTER.item_yearid INNER JOIN LEDGERS ON JOBBATCHMASTER.JOB_LEDGERID = LEDGERS.Acc_id AND JOBBATCHMASTER.job_yearid = LEDGERS.Acc_yearid ", " AND BATCHMASTER.JOBBATCH_tempprocessno < 11 AND AND (BATCHMASTER.JOBBATCH_MADEQTY) > 0 AND BATCHMASTER.JOBBATCH_DONE = 0 AND BATCHMASTER.JOBBATCH_YEARID=" & YearId & " ORDER BY JOBBATCHMASTER.JOB_NO ")
            'Else

            If TYPE = "CHALLAN" Then
                If ClientName = "AMR" Then
                    dt = objcmn.search(" CAST(0 AS BIT) AS CHK,  ISNULL(JOBBATCHMASTER.job_no, 0) AS JOBBATCHNO, ISNULL(BATCHMASTER.jobbatch_no, 0) AS BATCHNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(JOBBATCHMASTER.job_pono, '') AS PONO, BATCHMASTER.jobbatch_date AS BATCHDATE, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE,ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(BATCHMASTER.jobbatch_madeqty, 0) AS QTY", "", "   BATCHMASTER INNER JOIN JOBBATCHMASTER ON BATCHMASTER.jobbatch_docketno = JOBBATCHMASTER.job_no AND BATCHMASTER.jobbatch_yearid = JOBBATCHMASTER.job_yearid INNER JOIN ITEMMASTER ON BATCHMASTER.jobbatch_itemid = ITEMMASTER.item_id AND BATCHMASTER.jobbatch_yearid = ITEMMASTER.item_yearid INNER JOIN LEDGERS ON JOBBATCHMASTER.JOB_LEDGERID = LEDGERS.Acc_id AND JOBBATCHMASTER.job_yearid = LEDGERS.Acc_yearid ", " AND BATCHMASTER.JOBBATCH_tempprocessno = 10 AND (BATCHMASTER.JOBBATCH_MADEQTY)>0 AND BATCHMASTER.JOBBATCH_DONE = 0 AND BATCHMASTER.JOBBATCH_QCDONE = 'TRUE' AND BATCHMASTER.JOBBATCH_YEARID=" & YearId & " ORDER BY JOBBATCHMASTER.JOB_NO ")

                Else
                    dt = objcmn.search(" CAST(0 AS BIT) AS CHK,  ISNULL(JOBBATCHMASTER.job_no, 0) AS JOBBATCHNO, ISNULL(BATCHMASTER.jobbatch_no, 0) AS BATCHNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(JOBBATCHMASTER.job_pono, '') AS PONO, BATCHMASTER.jobbatch_date AS BATCHDATE, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE,ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(BATCHMASTER.jobbatch_madeqty, 0) AS QTY", "", "   BATCHMASTER INNER JOIN JOBBATCHMASTER ON BATCHMASTER.jobbatch_docketno = JOBBATCHMASTER.job_no AND BATCHMASTER.jobbatch_yearid = JOBBATCHMASTER.job_yearid INNER JOIN ITEMMASTER ON BATCHMASTER.jobbatch_itemid = ITEMMASTER.item_id AND BATCHMASTER.jobbatch_yearid = ITEMMASTER.item_yearid INNER JOIN LEDGERS ON JOBBATCHMASTER.JOB_LEDGERID = LEDGERS.Acc_id AND JOBBATCHMASTER.job_yearid = LEDGERS.Acc_yearid ", " AND BATCHMASTER.JOBBATCH_tempprocessno = 11 AND (BATCHMASTER.JOBBATCH_MADEQTY)>0 AND BATCHMASTER.JOBBATCH_DONE = 0 AND BATCHMASTER.JOBBATCH_YEARID=" & YearId & " ORDER BY JOBBATCHMASTER.JOB_NO ")
                End If
            ElseIf FRMSTRING = "ASSEMBLY" Then
                dt = objcmn.search("  CAST(0 AS BIT) AS CHK, ISNULL(BATCHMASTER.jobbatch_no, 0) AS BATCHNO, ISNULL(BATCHMASTER.jobbatch_docketno, 0) AS JOBBATCHNO, ISNULL(BATCHMASTER.jobbatch_qty, 0) AS QTY, ISNULL(BATCHMASTER.jobbatch_percentage, 0) AS PERCENTAGE, ISNULL(BATCHMASTER.JOBBATCH_TOTALSHEETS, 0) AS TOTALSHEET, ISNULL(MAINTITEMASTER.item_name, '') AS ITEMNAME, ISNULL(MAINTITEMASTER.item_code, '') AS ITEMCODE, ISNULL(SUBITEMMASTER.item_name, '') AS SUBITEM, ISNULL(SUBITEMMASTER.item_code, '') AS SUBITEMCODE, BATCHMASTER.jobbatch_date AS BATCHDATE, LEDGERS.Acc_cmpname AS NAME, JOBBATCHMASTER.job_pono AS PONO", "", " BATCHMASTER INNER JOIN ITEMMASTER AS MAINTITEMASTER ON BATCHMASTER.jobbatch_itemid = MAINTITEMASTER.item_id INNER JOIN JOBBATCHMASTER ON BATCHMASTER.jobbatch_no = JOBBATCHMASTER.job_no AND BATCHMASTER.jobbatch_yearid = JOBBATCHMASTER.job_yearid LEFT OUTER JOIN LEDGERS ON JOBBATCHMASTER.JOB_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN ITEMMASTER AS SUBITEMMASTER ON BATCHMASTER.JOBBATCH_SUBITEMID = SUBITEMMASTER.item_id ", " AND  BATCHMASTER.jobbatch_yearid=" & YearId & where & " ORDER BY BATCHMASTER.jobbatch_no ")
            Else
                GSUBITEMCODE.Visible = False
                GSUBITEMNAME.Visible = False
                'dt = objcmn.search(" CAST(0 AS BIT) AS CHK,  ISNULL(JOBBATCHMASTER.job_no, 0) AS JOBBATCHNO, ISNULL(BATCHMASTER.jobbatch_no, 0) AS BATCHNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(JOBBATCHMASTER.job_pono, '') AS PONO, BATCHMASTER.jobbatch_date AS BATCHDATE, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE,ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(BATCHMASTER.jobbatch_madeqty, 0) AS QTY ,ISNULL(ITEMMASTER_1.item_code,'') AS SUBITEM", "", " BATCHMASTER INNER JOIN  JOBBATCHMASTER ON BATCHMASTER.jobbatch_docketno = JOBBATCHMASTER.job_no AND  BATCHMASTER.jobbatch_yearid = JOBBATCHMASTER.job_yearid INNER JOIN ITEMMASTER ON BATCHMASTER.jobbatch_itemid = ITEMMASTER.item_id AND BATCHMASTER.jobbatch_yearid = ITEMMASTER.item_yearid INNER JOIN LEDGERS ON JOBBATCHMASTER.JOB_LEDGERID = LEDGERS.Acc_id AND JOBBATCHMASTER.job_yearid = LEDGERS.Acc_yearid LEFT OUTER JOIN  ITEMMASTER AS ITEMMASTER_1 ON BATCHMASTER.JOBBATCH_SUBITEMID = ITEMMASTER_1.item_id ", " AND BATCHMASTER.JOBBATCH_tempprocessno < 11 AND (BATCHMASTER.JOBBATCH_MADEQTY)>0 AND BATCHMASTER.JOBBATCH_DONE = 0 AND BATCHMASTER.JOBBATCH_YEARID=" & YearId & " ORDER BY JOBBATCHMASTER.JOB_NO ")
                dt = objcmn.search(" CAST(0 AS BIT) AS CHK, ISNULL(JOBBATCHMASTER.job_no, 0) AS JOBBATCHNO, ISNULL(BATCHMASTER.jobbatch_no, 0) AS BATCHNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(JOBBATCHMASTER.job_pono, '')  AS PONO, BATCHMASTER.jobbatch_date AS BATCHDATE, ISNULL(BATCHMASTER.jobbatch_qty, 0) AS QTY, ISNULL(COALESCE(SUBITEMMASTER.item_code, ITEMMASTER.item_code),'')  AS ITEMCODE, ISNULL(COALESCE(SUBITEMMASTER.item_name, ITEMMASTER.item_name),'')  AS ITEMNAME ", "", " BATCHMASTER INNER JOIN JOBBATCHMASTER ON BATCHMASTER.jobbatch_docketno = JOBBATCHMASTER.job_no AND BATCHMASTER.jobbatch_yearid = JOBBATCHMASTER.job_yearid INNER JOIN ITEMMASTER ON BATCHMASTER.jobbatch_itemid = ITEMMASTER.item_id AND BATCHMASTER.jobbatch_yearid = ITEMMASTER.item_yearid INNER JOIN LEDGERS ON JOBBATCHMASTER.JOB_LEDGERID = LEDGERS.Acc_id AND JOBBATCHMASTER.job_yearid = LEDGERS.Acc_yearid LEFT OUTER JOIN ITEMMASTER AS SUBITEMMASTER ON BATCHMASTER.JOBBATCH_SUBITEMID = SUBITEMMASTER.item_id  ", " AND BATCHMASTER.JOBBATCH_tempprocessno < 11  AND BATCHMASTER.JOBBATCH_DONE = 0 AND BATCHMASTER.JOBBATCH_YEARID=" & YearId & " ORDER BY JOBBATCHMASTER.JOB_NO ")
            End If
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

    Private Sub SelectBatch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            If TYPE = "CHALLAN" And ClientName <> "AMR" Then


                Dim n As String = ""
                Dim M As String = ""
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If n <> "" Then
                            If n = (dtrow("JOBBATCHNO")) Then
                                GoTo Line1
                            Else
                                MsgBox("Pls select same Job Batch No !")
                                Exit Sub
                            End If
                        End If
Line1:
                        n = (dtrow("JOBBATCHNO"))
                    End If
                Next

                DT.Columns.Add("JOBBATCHNO")
                DT.Columns.Add("BATCHNO")
                DT.Columns.Add("ITEMCODE")
                DT.Columns.Add("ITEMNAME")

                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        DT.Rows.Add(dtrow("JOBBATCHNO"), dtrow("BATCHNO"), dtrow("ITEMCODE"), dtrow("ITEMNAME"))
                    End If
                Next

                Me.Close()

            ElseIf ClientName = "AMR" And FRMSTRING <> "PLATEISSUE" Then
                If TYPE = "CHALLAN" Then
                    Dim COUNT As Integer = 0
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

                    DT.Columns.Add("BATCHNO")
                    DT.Columns.Add("JOBBATCHNO")
                    DT.Columns.Add("QTY")
                    DT.Columns.Add("PERCENTAGE")
                    DT.Columns.Add("TOTALSHEET")
                    DT.Columns.Add("ITEMNAME")
                    DT.Columns.Add("ITEMCODE")
                    DT.Columns.Add("SUBITEM")
                    DT.Columns.Add("SUBITEMCODE")

                    For i As Integer = 0 To gridbill.RowCount - 1
                        Dim dtrow As DataRow = gridbill.GetDataRow(i)
                        If Convert.ToBoolean(dtrow("CHK")) = True Then
                            DT.Rows.Add(dtrow("BATCHNO"), dtrow("JOBBATCHNO"), dtrow("QTY"), dtrow("PERCENTAGE"), dtrow("TOTALSHEET"), dtrow("ITEMNAME"), dtrow("ITEMCODE"), dtrow("SUBITEM"), dtrow("SUBITEMCODE"))
                        End If
                    Next

                    Me.Close()


                ElseIf FRMSTRING = "ASSEMBLY" Then

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

                    DT.Columns.Add("BATCHNO")
                    DT.Columns.Add("JOBBATCHNO")
                    DT.Columns.Add("QTY")
                    DT.Columns.Add("PERCENTAGE")
                    DT.Columns.Add("TOTALSHEET")
                    DT.Columns.Add("ITEMNAME")
                    DT.Columns.Add("ITEMCODE")
                    DT.Columns.Add("SUBITEM")
                    DT.Columns.Add("SUBITEMCODE")

                    For i As Integer = 0 To gridbill.RowCount - 1
                        Dim dtrow As DataRow = gridbill.GetDataRow(i)
                        If Convert.ToBoolean(dtrow("CHK")) = True Then
                            DT.Rows.Add(dtrow("BATCHNO"), dtrow("JOBBATCHNO"), dtrow("QTY"), dtrow("PERCENTAGE"), dtrow("TOTALSHEET"), dtrow("ITEMNAME"), dtrow("ITEMCODE"), dtrow("SUBITEM"), dtrow("SUBITEMCODE"))
                        End If
                    Next

                    Me.Close()
                Else

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

                    DT.Columns.Add("JOBBATCHNO")
                    DT.Columns.Add("BATCHNO")
                    DT.Columns.Add("ITEMCODE")
                    DT.Columns.Add("ITEMNAME")

                    For i As Integer = 0 To gridbill.RowCount - 1
                        Dim dtrow As DataRow = gridbill.GetDataRow(i)
                        If Convert.ToBoolean(dtrow("CHK")) = True Then
                            DT.Rows.Add(dtrow("JOBBATCHNO"), dtrow("BATCHNO"), dtrow("ITEMCODE"), dtrow("ITEMNAME"))
                        End If
                    Next

                    Me.Close()
                End If
            End If






        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class