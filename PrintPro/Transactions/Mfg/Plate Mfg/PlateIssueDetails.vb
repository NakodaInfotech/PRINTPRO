
Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class PlateIssueDetails
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub PlateIssueDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                CMDOK_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PlateIssueDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DTROW() As DataRow
        DTROW = USERRIGHTS.Select("FormName = 'CONSUMPTION'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        fillgrid(" AND PLATEISSUE.ISSUE_yearid=" & YearId & " order by PLATEISSUE.ISSUE_no ")
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search("  ISNULL(DEPARTMENTMASTER.DEPARTMENT_name, '') AS DEPARTMENT, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(PLATEISSUE.ISSUE_NO, 0) AS SRNO, PLATEISSUE.ISSUE_DATE AS DATE, ISNULL(PLATEISSUE.ISSUE_ISSUEDBY, '') AS ISSUEBY, ISNULL(PLATEISSUE.ISSUE_ISSUEDTO, '') AS ISSUETO, ISNULL(PLATEISSUE_DESC.ISSUE_QTY, 0) AS QTY, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS PLATENO, ISNULL(PLATEISSUE_DESC.ISSUE_RATE, 0) AS RATE, ISNULL(PLATEISSUE_DESC.ISSUE_AMOUNT, 0) AS AMOUNT", "", " PLATEISSUE INNER JOIN PLATEISSUE_DESC ON PLATEISSUE.ISSUE_yearid = PLATEISSUE_DESC.ISSUE_yearid AND PLATEISSUE.ISSUE_NO = PLATEISSUE_DESC.ISSUE_no INNER JOIN DEPARTMENTMASTER ON PLATEISSUE.ISSUE_DEPARTMENTID = DEPARTMENTMASTER.DEPARTMENT_id INNER JOIN GODOWNMASTER ON PLATEISSUE.ISSUE_GODOWNID = GODOWNMASTER.GODOWN_id INNER JOIN ITEMMASTER ON PLATEISSUE.ISSUE_ITEMID = ITEMMASTER.item_id INNER JOIN NONINVITEMMASTER ON PLATEISSUE_DESC.ISSUE_NONINVID = NONINVITEMMASTER.NONINV_ID", tepmcondition)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal ISSUENO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objREQ As New PlateIssue
                objREQ.MdiParent = MDIMain
                objREQ.edit = editval
                objREQ.TEMPISSUENO = ISSUENO
                objREQ.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLADDNEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLADDNEW.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = "D:\Plate Issue Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Plate Issue Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Plate Issue Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid(" AND PLATEISSUE.ISSUE_yearid=" & YearId & " order by PLATEISSUE.ISSUE_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        'Try
        '    Dim DT As DataTable = gridbilldetails.DataSource
        '    If e.RowHandle >= 0 Then
        '        Dim ROW As DataRow = DT.Rows(e.RowHandle)
        '        Dim View As GridView = sender
        '        If Val(View.GetRowCellDisplayText(e.RowHandle, View.Columns("OUTQTY"))) > 0 Then
        '            e.Appearance.Font = New System.Drawing.Font("CALIBRI", 10.0F, System.Drawing.FontStyle.Regular)
        '            e.Appearance.BackColor = Color.Yellow
        '        End If
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub
End Class