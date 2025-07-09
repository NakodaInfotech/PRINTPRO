
Imports BL
Imports System.Windows.Forms

Public Class PlateReturnedDetails
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub PlateReturnedDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub PlateReturnedDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        fillgrid(" AND PLATERETURN.RETURN_yearid=" & YearId & " order by PLATERETURN.RETURN_no ")
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search("  PLATERETURN.RETURN_NO AS SRNO, PLATERETURN.RETURN_DATE AS DATE, ISNULL(PLATERETURN.RETURN_TAKENBY, '') AS TAKENBY, ISNULL(DEPARTMENTMASTER.DEPARTMENT_name, '') AS DEPARTMENT, ISNULL(PLATERETURN.RETURN_GIVENBY, '') AS GIVENBY, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(PLATERETURN_DESC.RETURN_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS PLATENO, ISNULL(PLATERETURN_DESC.RETURN_QTY, 0) AS QTY , ISNULL(PLATERETURN_DESC.RETURN_RATE, 0) AS RATE, ISNULL(PLATERETURN_DESC.RETURN_AMOUNT, 0) AS AMOUNT ", "", "   PLATERETURN_DESC INNER JOIN PLATERETURN ON PLATERETURN_DESC.RETURN_no = PLATERETURN.RETURN_NO AND PLATERETURN_DESC.RETURN_yearid = PLATERETURN.RETURN_yearid INNER JOIN ITEMMASTER ON PLATERETURN.RETURN_ITEMID = ITEMMASTER.item_id AND PLATERETURN.RETURN_yearid = ITEMMASTER.item_yearid INNER JOIN DEPARTMENTMASTER ON PLATERETURN.RETURN_DEPARTMENTID = DEPARTMENTMASTER.DEPARTMENT_id AND PLATERETURN.RETURN_yearid = DEPARTMENTMASTER.DEPARTMENT_yearid INNER JOIN GODOWNMASTER ON PLATERETURN.RETURN_GODOWNID = GODOWNMASTER.GODOWN_id AND PLATERETURN.RETURN_yearid = GODOWNMASTER.GODOWN_yearid INNER JOIN NONINVITEMMASTER ON PLATERETURN_DESC.RETURN_NONINVID = NONINVITEMMASTER.NONINV_ID AND PLATERETURN_DESC.RETURN_yearid = NONINVITEMMASTER.NONINV_YEARID", tepmcondition)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal RETURNNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objREQ As New PlateReturned
                objREQ.MdiParent = MDIMain
                objREQ.edit = editval
                objREQ.TEMPRETURNNO = RETURNNO
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

            Dim PATH As String = "D:\Plate Return Details.XLS"
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
            fillgrid(" AND PLATERETURN.RETURN_yearid=" & YearId & " order by PLATERETURN.RETURN_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class