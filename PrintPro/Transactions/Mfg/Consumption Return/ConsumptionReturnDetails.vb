
Imports BL
Imports System.Windows.Forms

Public Class ConsumptionReturnDetails
    Public edit As Boolean
    Dim TEMPCONSUMENO As Integer
    Public WHERECLAUSE As String
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub ConsumptionReturnDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ConsumptionReturnDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        fillgrid(" and dbo.CONSUMPTIONRETURN.CONSUMERET_CMPID=" & CmpId & "  and dbo.CONSUMPTIONRETURN.CONSUMERET_yearid=" & YearId & " order by dbo.CONSUMPTIONRETURN.CONSUMERET_no ")
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" CONSUMPTIONRETURN.CONSUMERET_no AS SRNO, CONSUMPTIONRETURN.CONSUMERET_date AS CONSUMEDATE, ISNULL(CONSUMPTIONRETURN.CONSUMERET_MATERIALGIVENBY, '') AS MATERIALBY, ISNULL(CONSUMPTIONRETURN.CONSUMERET_MATERIALGIVENTO, '') AS MATERIALTO, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(DEPARTMENTMASTER.DEPARTMENT_name, '') AS DEPARTMENT, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(CONSUMPTIONRETURN.CONSUMERET_TOTALQTY, 0) AS TOTALQTY , ISNULL(CONSUMPTIONRETURN_DESC.CONSUMERET_RATE, 0) AS RATE , ISNULL(CONSUMPTIONRETURN_DESC.CONSUMERET_AMOUNT, 0) AS AMOUNT ,ISNULL(CONSUMPTIONRETURN.CONSUMERET_CHALLANNO,'') AS CHALLANNO  ", "", "    GODOWNMASTER RIGHT OUTER JOIN CONSUMPTIONRETURN INNER JOIN CONSUMPTIONRETURN_DESC ON CONSUMPTIONRETURN.CONSUMERET_NO = CONSUMPTIONRETURN_DESC.CONSUMERET_no AND CONSUMPTIONRETURN.CONSUMERET_YEARID = CONSUMPTIONRETURN_DESC.CONSUMERET_yearid INNER JOIN NONINVITEMMASTER ON CONSUMPTIONRETURN_DESC.CONSUMERET_ITEMID = NONINVITEMMASTER.NONINV_ID AND CONSUMPTIONRETURN_DESC.CONSUMERET_yearid = NONINVITEMMASTER.NONINV_YEARID LEFT OUTER JOIN DEPARTMENTMASTER ON CONSUMPTIONRETURN.CONSUMERET_DEPARTMENTID = DEPARTMENTMASTER.DEPARTMENT_id AND CONSUMPTIONRETURN.CONSUMERET_YEARID = DEPARTMENTMASTER.DEPARTMENT_yearid LEFT OUTER JOIN UNITMASTER ON CONSUMPTIONRETURN_DESC.CONSUMERET_UNITID = UNITMASTER.unit_id AND CONSUMPTIONRETURN_DESC.CONSUMERET_yearid = UNITMASTER.unit_yearid ON GODOWNMASTER.GODOWN_id = CONSUMPTIONRETURN.CONSUMERET_GODOWNID AND GODOWNMASTER.GODOWN_yearid = CONSUMPTIONRETURN.CONSUMERET_YEARID", WHERECLAUSE & tepmcondition)
            If dt.Rows.Count > 0 Then
                gridbilldetails.DataSource = dt
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
                Dim objREQ As New ConsumptionReturn
                objREQ.MdiParent = MDIMain
                objREQ.edit = editval
                objREQ.TEMPCONSUMENO = CONSUMENO
                objREQ.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolADDNEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolADDNEW.Click
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

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = "D:\Consumption Return Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Consumption Return Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Consumption Return Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid(" and dbo.CONSUMPTIONRETURN.CONSUMERET_CMPID=" & CmpId & " and dbo.CONSUMPTIONRETURN.CONSUMERET_yearid=" & YearId & " order by dbo.CONSUMPTIONRETURN.CONSUMERET_no ")
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

End Class