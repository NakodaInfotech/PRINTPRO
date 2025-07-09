Imports BL
Public Class PendingWorkOrder
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public TEMPPORFORMA As String
    Public TEMPJONO As Integer

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("TEMPJONO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PendingWorkOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'JOBOUT'")
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
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
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

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PendingWorkOrder_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
    Private Sub TOOLEXCEL_Click(sender As Object, e As EventArgs)
        Try

            Dim PATH As String = Application.StartupPath & "\Job Out Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Job Out Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Job Out Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Job Out Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub
    Sub FILLGRID()
        Try
            If CHKPENDING.CheckState = CheckState.Unchecked Then
                Dim objclsCMST As New ClsCommonMaster
                Dim dt As DataTable = objclsCMST.search(" JOBOUT.JO_NO AS JONO, JobOut.JO_JOBDOCKETNO AS JOBDOCKETNO, JobOut.JO_DATE AS DATE, GODOWNMASTER.GODOWN_name AS GODOWN, LEDGERS.Acc_cmpname AS PARTYNAME, ITEMMASTERMAIN.item_code + ' ' + ITEMMASTER.item_code AS ITEMNAME, NONINVITEMMASTER.NONINV_NAME AS PAPERNAME, JOBOUT_DESC.JO_GQTY AS QTY", "", " JOBOUT INNER JOIN JOBOUT_DESC ON JOBOUT.JO_NO = JOBOUT_DESC.JO_NO AND JOBOUT.JO_yearid = JOBOUT_DESC.JO_yearid LEFT OUTER JOIN NONINVITEMMASTER ON JOBOUT_DESC.JO_ITEMID = NONINVITEMMASTER.NONINV_ID LEFT OUTER JOIN ITEMMASTER AS ITEMMASTERMAIN ON JOBOUT.JO_MAINITEMID = ITEMMASTERMAIN.item_id LEFT OUTER JOIN ITEMMASTER ON JOBOUT.JO_BOMITEMCODEID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS ON JOBOUT.JO_PARTYNAMEID = LEDGERS.Acc_id LEFT OUTER JOIN GODOWNMASTER ON JOBOUT.JO_GODOWNID = GODOWNMASTER.GODOWN_id ", " AND  JOBOUT.JO_NO  NOT IN (SELECT JI_JOBOUTNO FROM JOBIN) ")
                gridbilldetails.DataSource = dt
                If dt.Rows.Count > 0 Then
                    gridbill.FocusedRowHandle = gridbill.RowCount - 1
                    gridbill.TopRowIndex = gridbill.RowCount - 15
                End If
            Else
                Dim objclsCMST As New ClsCommonMaster
                Dim dt As DataTable = objclsCMST.search(" JOBOUT.JO_NO AS JONO, JobOut.JO_JOBDOCKETNO AS JOBDOCKETNO, JobOut.JO_DATE AS DATE, GODOWNMASTER.GODOWN_name AS GODOWN, LEDGERS.Acc_cmpname AS PARTYNAME, ITEMMASTERMAIN.item_code + ' ' + ITEMMASTER.item_code AS ITEMNAME, NONINVITEMMASTER.NONINV_NAME AS PAPERNAME, JOBOUT_DESC.JO_GQTY AS QTY", "", " JOBOUT INNER JOIN JOBOUT_DESC ON JOBOUT.JO_NO = JOBOUT_DESC.JO_NO AND JOBOUT.JO_yearid = JOBOUT_DESC.JO_yearid LEFT OUTER JOIN NONINVITEMMASTER ON JOBOUT_DESC.JO_ITEMID = NONINVITEMMASTER.NONINV_ID LEFT OUTER JOIN ITEMMASTER AS ITEMMASTERMAIN ON JOBOUT.JO_MAINITEMID = ITEMMASTERMAIN.item_id LEFT OUTER JOIN ITEMMASTER ON JOBOUT.JO_BOMITEMCODEID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS ON JOBOUT.JO_PARTYNAMEID = LEDGERS.Acc_id LEFT OUTER JOIN GODOWNMASTER ON JOBOUT.JO_GODOWNID = GODOWNMASTER.GODOWN_id ", " AND  JOBOUT.JO_NO   IN (SELECT JI_JOBOUTNO FROM JOBIN) ")
                gridbilldetails.DataSource = dt
                If dt.Rows.Count > 0 Then
                    gridbill.FocusedRowHandle = gridbill.RowCount - 1
                    gridbill.TopRowIndex = gridbill.RowCount - 15
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Sub showform(ByVal editval As Boolean, ByVal TEMPJONO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objgdn As New JobOut
                objgdn.MdiParent = MDIMain
                objgdn.EDIT = editval
                objgdn.TEMPJONO = TEMPJONO
                objgdn.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbilldetails_DoubleClick(sender As Object, e As EventArgs) Handles gridbilldetails.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("TEMPJONO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TXTFROM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFROM.KeyPress, TXTTO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub CHKPENDING_CheckedChanged(sender As Object, e As EventArgs) Handles CHKPENDING.CheckedChanged
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class