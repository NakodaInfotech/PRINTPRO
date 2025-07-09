
Imports BL
Imports System.Windows.Forms

Public Class ConsumptionDetails

    Public FRMSTRING As String
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub ConsumptionDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub ConsumptionDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        fillgrid(" AND dbo.CONSUMPTION.CONSUME_yearid=" & YearId & " order by dbo.CONSUMPTION.CONSUME_no ")
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" CONSUMPTION.CONSUME_NO AS SRNO, CONSUMPTION.CONSUME_DATE AS CONSUMEDATE, ISNULL(CONSUMPTION.CONSUME_MATERIALGIVENBY, '') AS MATERIALBY, ISNULL(CONSUMPTION.CONSUME_MATERIALGIVENTO, '') AS MATERIALTO, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(DEPARTMENTMASTER.DEPARTMENT_name, '') AS DEPARTMENT, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME, ISNULL(CONSUMPTION_DESC.CONSUME_QTY, 0) AS TOTALQTY, ISNULL(CONSUMPTION_DESC.CONSUME_WT, 0) AS WT,  ISNULL(CONSUMPTION.CONSUME_BATCHNO, 0) AS BATCHNO, ISNULL(CONSUMPTION_DESC.CONSUME_LOTNO, '0') AS LOTNO, ISNULL(CONSUMPTION.CONSUME_remarks, '') AS REMARKS, ISNULL(CONSUMPTION_DESC.CONSUME_RATE, 0) AS RATE, ISNULL(CONSUMPTION_DESC.CONSUME_AMOUNT, 0) AS AMOUNT, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, CONSUMPTION.CONSUME_created AS CREATEDDATE ,ISNULL(CONSUMPTION.CONSUME_CHALLANNO,'') AS CHALLANNO ", "", " CONSUMPTION INNER JOIN CONSUMPTION_DESC ON CONSUMPTION.CONSUME_NO = CONSUMPTION_DESC.CONSUME_no AND CONSUMPTION.CONSUME_yearid = CONSUMPTION_DESC.CONSUME_yearid INNER JOIN NONINVITEMMASTER ON CONSUMPTION_DESC.CONSUME_ITEMID = NONINVITEMMASTER.NONINV_ID AND CONSUMPTION_DESC.CONSUME_yearid = NONINVITEMMASTER.NONINV_YEARID LEFT OUTER JOIN UNITMASTER ON CONSUMPTION_DESC.CONSUME_UNITID = UNITMASTER.unit_id AND CONSUMPTION_DESC.CONSUME_yearid = UNITMASTER.unit_yearid LEFT OUTER JOIN GODOWNMASTER ON CONSUMPTION.CONSUME_GODOWNID = GODOWNMASTER.GODOWN_id AND CONSUMPTION.CONSUME_yearid = GODOWNMASTER.GODOWN_yearid LEFT OUTER JOIN DEPARTMENTMASTER ON CONSUMPTION.CONSUME_DEPARTMENTID = DEPARTMENTMASTER.DEPARTMENT_id AND CONSUMPTION.CONSUME_yearid = DEPARTMENTMASTER.DEPARTMENT_yearid ", tepmcondition)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal CONSUMENO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objREQ As New Consumption
                objREQ.MdiParent = MDIMain
                objREQ.edit = editval
                objREQ.TEMPCONSUMENO = CONSUMENO
                objREQ.FRMSTRING = FRMSTRING
                objREQ.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
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

            Dim PATH As String = "D:\Consumption Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Consumption Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Consumption Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid(" and dbo.CONSUMPTION.CONSUME_CMPID=" & CmpId & " and dbo.CONSUMPTION.CONSUME_locationid=" & Locationid & " and dbo.CONSUMPTION.CONSUME_yearid=" & YearId & " order by dbo.CONSUMPTION.CONSUME_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

 
End Class