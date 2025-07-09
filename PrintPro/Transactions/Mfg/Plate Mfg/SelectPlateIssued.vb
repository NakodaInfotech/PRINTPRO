
Imports BL
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Controls

Public Class SelectPlateIssued
    Public DT As New DataTable
    Dim CONSUMESELECTED As Boolean
    Dim PLATEISSUENO As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectPlateIssued_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectPlateIssued_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FILLGRID("")
    End Sub

    Sub FILLGRID(ByVal WHERE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("CAST(0 AS BIT) AS CHK, ISNULL(PLATEISSUE.ISSUE_NO, 0) AS PLATENO, ISNULL(PLATEISSUE_DESC.ISSUE_GRIDSRNO, 0) AS SRNO, PLATEISSUE.ISSUE_DATE AS DATE, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(DEPARTMENTMASTER.DEPARTMENT_name, '') AS DEPARTMENT, ISNULL(PLATEISSUE.ISSUE_ISSUEDTO, '') AS ISSUETO, ISNULL(PLATEISSUE.ISSUE_ISSUEDBY, '') AS ISSUEBY, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME, ISNULL(PLATEISSUE.ISSUE_BATCHNO, 0) AS BATCHNO, ISNULL(PLATEISSUE_DESC.ISSUE_QTY - PLATEISSUE_DESC.ISSUE_OUTQTY, 0) AS QTY, ISNULL(PLATEISSUE.ISSUE_CHALLANNO, '') AS CHALLANNO ", "", "   PLATEISSUE INNER JOIN PLATEISSUE_DESC ON PLATEISSUE.ISSUE_NO = PLATEISSUE_DESC.ISSUE_no AND PLATEISSUE.ISSUE_yearid = PLATEISSUE_DESC.ISSUE_yearid INNER JOIN DEPARTMENTMASTER ON PLATEISSUE.ISSUE_DEPARTMENTID = DEPARTMENTMASTER.DEPARTMENT_id AND PLATEISSUE.ISSUE_yearid = DEPARTMENTMASTER.DEPARTMENT_yearid INNER JOIN GODOWNMASTER ON PLATEISSUE.ISSUE_GODOWNID = GODOWNMASTER.GODOWN_id AND PLATEISSUE.ISSUE_yearid = GODOWNMASTER.GODOWN_yearid INNER JOIN NONINVITEMMASTER ON PLATEISSUE_DESC.ISSUE_NONINVID = NONINVITEMMASTER.NONINV_ID AND PLATEISSUE_DESC.ISSUE_yearid = NONINVITEMMASTER.NONINV_YEARID", "AND (PLATEISSUE_DESC.ISSUE_QTY - PLATEISSUE_DESC.ISSUE_OUTQTY) > 0 AND PLATEISSUE.ISSUE_YEARID = " & YearId & " ORDER BY PLATEISSUE.ISSUE_NO")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Dim N As String = ""
            For I As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(I)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If N <> "" Then
                        If N = (dtrow("PLATENO")) Then
                            GoTo Line1
                        Else
                            MsgBox("Pls select same Consumption !")
                            Exit Sub
                        End If
                    End If
Line1:
                    N = (dtrow("PLATENO"))
                End If
            Next

            DT.Columns.Add("PLATENO")
            DT.Columns.Add("SRNO")
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("PLATENO"), dtrow("SRNO"))
                End If
            Next
            Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class