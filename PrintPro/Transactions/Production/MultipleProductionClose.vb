Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid


Public Class MultipleProductionClose
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT



    Private Sub MultipleProductionClose_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PRODUCTION'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As New DataTable
            If RBPENDING.Checked = True Then
                'dt = objclsCMST.search(" ISNULL(JOBBATCHMASTER.job_orderno, 0) AS ORDERNO, ISNULL(JOBBATCHMASTER.job_no, 0) AS JOBDOCKETNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(SUBITEMMASTER.item_name, '') AS SUBITEM, ISNULL(JOBBATCHMASTER.JOB_JOBQTY, 0) AS QTY, ISNULL(JOBBATCHMASTER.JOB_PRODFINISHQTY, 0) AS PRODUCTIONQTY, ISNULL(JOBBATCHMASTER.JOB_CLOSE, 0) AS JOBCLOSE ", "", " ITEMMASTER AS SUBITEMMASTER RIGHT OUTER JOIN JOBBATCHMASTER ON SUBITEMMASTER.item_id = JOBBATCHMASTER.JOB_SUBITEMID LEFT OUTER JOIN ITEMMASTER ON JOBBATCHMASTER.JOB_MAINITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS ON JOBBATCHMASTER.JOB_LEDGERID = LEDGERS.Acc_id ", " AND JOBBATCHMASTER.JOB_CLOSE = 0 AND JOBBATCHMASTER.JOB_FINISHED = 0 and JOBBATCHMASTER.JOB_YEARID=" & YearId & "  ORDER BY JOBBATCHMASTER.job_orderno")
                dt = objclsCMST.search("ISNULL(PRODUCTION.PROD_NO, 0) AS PRODUCTIONNO, ISNULL(PRODUCTION_DESC.PROD_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(PRODUCTION_DESC.PROD_ORDERNO, 0) AS ORDERNO, ISNULL(PRODUCTION_DESC.PROD_JOBNO, 0) AS JOBNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(PRODUCTION_DESC.PROD_ITEMNAME, '') AS ITEMNAME, ISNULL(PRODUCTION_DESC.PROD_GOODQTY, 0) AS QTY  ", "", " PRODUCTION INNER JOIN PRODUCTION_DESC ON PRODUCTION.PROD_NO = PRODUCTION_DESC.PROD_NO AND PRODUCTION.PROD_YEARID = PRODUCTION_DESC.PROD_YEARID LEFT OUTER JOIN LEDGERS ON PRODUCTION_DESC.PROD_CLIENTID = LEDGERS.Acc_id ", "  AND PRODUCTION.PROD_CLOSE = 0 AND PRODUCTION.PROD_TOPRODUCTIONTYPE = 'Final' AND (PRODUCTION.PROD_YEARID = " & YearId & ")")
            Else
                'dt = objclsCMST.search(" ISNULL(JOBBATCHMASTER.job_orderno, 0) AS ORDERNO, ISNULL(JOBBATCHMASTER.job_no, 0) AS JOBDOCKETNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(SUBITEMMASTER.item_name, '') AS SUBITEM, ISNULL(JOBBATCHMASTER.JOB_JOBQTY, 0) AS QTY, ISNULL(JOBBATCHMASTER.JOB_PRODFINISHQTY, 0) AS PRODUCTIONQTY , ISNULL(JOBBATCHMASTER.JOB_CLOSE, 0) AS JOBCLOSE ", "", " ITEMMASTER AS SUBITEMMASTER RIGHT OUTER JOIN JOBBATCHMASTER ON SUBITEMMASTER.item_id = JOBBATCHMASTER.JOB_SUBITEMID LEFT OUTER JOIN ITEMMASTER ON JOBBATCHMASTER.JOB_MAINITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS ON JOBBATCHMASTER.JOB_LEDGERID = LEDGERS.Acc_id ", " AND JOBBATCHMASTER.JOB_CLOSE = 1 and JOBBATCHMASTER.JOB_YEARID=" & YearId & "  ORDER BY JOBBATCHMASTER.job_orderno")
                dt = objclsCMST.search("ISNULL(PRODUCTION.PROD_NO, 0) AS PRODUCTIONNO, ISNULL(PRODUCTION_DESC.PROD_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(PRODUCTION_DESC.PROD_ORDERNO, 0) AS ORDERNO, ISNULL(PRODUCTION_DESC.PROD_JOBNO, 0) AS JOBNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(PRODUCTION_DESC.PROD_ITEMNAME, '') AS ITEMNAME, ISNULL(PRODUCTION_DESC.PROD_GOODQTY, 0) AS QTY  ", "", " PRODUCTION INNER JOIN PRODUCTION_DESC ON PRODUCTION.PROD_NO = PRODUCTION_DESC.PROD_NO AND PRODUCTION.PROD_YEARID = PRODUCTION_DESC.PROD_YEARID LEFT OUTER JOIN LEDGERS ON PRODUCTION_DESC.PROD_CLIENTID = LEDGERS.Acc_id ", "  AND PRODUCTION.PROD_CLOSE = 1 AND PRODUCTION.PROD_TOPRODUCTIONTYPE = 'Final' AND (PRODUCTION.PROD_YEARID = " & YearId & ")")

            End If
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrinToExcel_Click(sender As Object, e As EventArgs) Handles PrinToExcel.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Close Production Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Close Production Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Close Production Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Close Production Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            'PENDING
            If RBPENDING.Checked = True Then
                Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
                For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                    Dim DTROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))
                    DT = OBJCMN.Execute_Any_String(" UPDATE PRODUCTION SET PROD_CLOSE = 1 WHERE PROD_NO = " & Val(DTROW("PRODUCTIONNO")) & " AND  PROD_yearid = " & YearId, "", "")
                Next
                MsgBox("Details Updated Successfully")
                FILLGRID()
                gridbill.Focus()
            End If

            'ENTERED
            If RBENTERED.Checked = True Then
                If MsgBox("You have trying to Re-Open Close Job Docket Batch, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
                For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                    Dim DTROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))
                    DT = OBJCMN.Execute_Any_String(" UPDATE PRODUCTION SET PROD_CLOSE = 0 WHERE PROD_NO = " & Val(DTROW("PRODUCTIONNO")) & " AND  PROD_yearid = " & YearId, "", "")
                Next
                MsgBox("Details Updated Successfully")
                FILLGRID()
                gridbill.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBPENDING_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBPENDING.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBENTERED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBENTERED.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class