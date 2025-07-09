Imports BL
Imports System.Windows.Forms

Public Class PlateDestroyedDetails
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub PlateDestroyedDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub PlateDestroyedDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        fillgrid(" AND PLATEDESTROYED.DESTROYE_yearid=" & YearId & " order by PLATEDESTROYED.DESTROYE_no ")
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search("   PLATEDESTROYED.DESTROYE_NO AS SRNO, PLATEDESTROYED.DESTROYE_DATE AS DATE, ISNULL(PLATEDESTROYED.DESTROYE_DESTROYEDBY, '') 
                      AS DESTROYEDBY, ISNULL(PLATEDESTROYED.DESTROYE_APPROVEDBY, '') AS APPROVEDBY, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, 
                      ISNULL(PLATEDESTROYED.DESTROYE_TOTALQTY, 0) AS TOTALQTY, ISNULL(PLATEDESTROYED.DESTROYE_remarks, '') AS REMARKS, 
                      ISNULL(PLATEDESTROYED_DESC.DESTROYE_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(PLATEDESTROYED_DESC.DESTROYE_QTY, 0) AS QTY, 
                       ISNULL(PLATEDESTROYED_DESC.DESTROYE_RATE, 0) AS RATE, ISNULL(PLATEDESTROYED_DESC.DESTROYE_AMOUNT, 0) AS AMOUNT,
                      ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS NONINVITEM, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT ", "", "   PLATEDESTROYED INNER JOIN
                      PLATEDESTROYED_DESC ON PLATEDESTROYED.DESTROYE_NO = PLATEDESTROYED_DESC.DESTROYE_no AND 
                      PLATEDESTROYED.DESTROYE_yearid = PLATEDESTROYED_DESC.DESTROYE_yearid INNER JOIN
                      GODOWNMASTER ON PLATEDESTROYED.DESTROYE_GODOWNID = GODOWNMASTER.GODOWN_id INNER JOIN
                      NONINVITEMMASTER ON PLATEDESTROYED_DESC.DESTROYE_NONINVID = NONINVITEMMASTER.NONINV_ID LEFT OUTER JOIN
                      UNITMASTER ON PLATEDESTROYED_DESC.DESTROYE_UNITID = UNITMASTER.unit_id  ", tepmcondition)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal DESTROYENO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objREQ As New PlateDestroyed
                objREQ.MdiParent = MDIMain
                objREQ.EDIT = editval
                objREQ.TEMPDESTROYENO = DESTROYENO
                objREQ.Show()

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

            Dim PATH As String = Application.StartupPath & "\Plate Return Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Plate Return Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Plate Return Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid(" AND PLATEDESTROYED.DESTROYE_yearid=" & YearId & " order by PLATEDESTROYED.DESTROYE_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class