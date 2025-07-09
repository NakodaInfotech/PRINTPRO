Imports BL
Imports System.Windows.Forms
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class PlateOrderDetails
    Public EDIT As Boolean
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SaleGatePassDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaleGatePassDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GDN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            fillgrid(" and PLATEORDER.ORDER_yearid=" & YearId & "order by PLATEORDER.ORDER_NO ")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" ISNULL(PLATEORDER.ORDER_NO, 0) AS TEMPID,    PLATEORDER.ORDER_DATE AS DATE,  LEDGERS.Acc_cmpname AS NAME,ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS PLATE, ISNULL(PLATEORDER.ORDER_NOOFPLATE, 0)  AS NOOFPLATE, PLATEORDER.ORDER_RECDATE AS RECDATE, ISNULL(PLATEORDER.ORDER_REMARKS, '') AS REMARKS", "", "PLATEORDER INNER JOIN LEDGERS ON PLATEORDER.ORDER_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN  ITEMMASTER ON PLATEORDER.ORDER_ITEMCODEID = ITEMMASTER.item_id LEFT OUTER JOIN NONINVITEMMASTER ON PLATEORDER.ORDER_PLATEID = NONINVITEMMASTER.NONINV_ID", tepmcondition)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Sub FILLGRID()
    '    Try
    '        Dim OBJDEPT As New ClsPlateOrder
    '        OBJDEPT.alParaval.Add(0)
    '        OBJDEPT.alParaval.Add(YearId)
    '        Dim DT As DataTable = OBJDEPT.SELECTPLATE()
    '        gridbilldetails.DataSource = DT
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    Sub showform(ByVal editval As Boolean, ByVal ID As Integer)
        Try
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objgdn As New PlateOrder
                objgdn.MdiParent = MDIMain
                objgdn.EDIT = editval
                objgdn.TEMPID = ID
                objgdn.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
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
    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid(" and PLATEORDER.ORDER_yearid=" & YearId & " order by PLATEORDER.ORDER_NO ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("ID"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("ID"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Sample Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Sample Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Sample Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class


