Imports BL
Public Class POFilter

    Dim edit As Boolean
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
            If CMBNONINVITEM.Text.Trim = "" Then FILLNONINVITEM(CMBNONINVITEM, edit)
            fillform(CHKFORMBOX, edit)

            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" CAST (0 AS BIT) AS CHK,LEDGERS.Acc_cmpname AS NAME, GROUPMASTER.group_secondary AS UNDER, ISNULL(CITYMASTER.city_name, '') AS CITY  ", " ", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id AND LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid LEFT OUTER JOIN CITYMASTER ON LEDGERS.Acc_yearid = CITYMASTER.city_yearid AND LEDGERS.Acc_locationid = CITYMASTER.city_locationid AND LEDGERS.Acc_cmpid = CITYMASTER.city_cmpid AND LEDGERS.Acc_cityid = CITYMASTER.city_id ", " AND (LEDGERS.ACC_CMPID = '" & CmpId & "') AND (LEDGERS.ACC_LOCATIONID = '" & Locationid & "') AND (LEDGERS.ACC_YEARID = '" & YearId & "') and GROUPMASTER.group_secondary='SUNDRY CREDITORS' ORDER BY LEDGERS.Acc_cmpname")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' and LEDGERS.ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBNAME_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtfrom.Value)
        a2 = DatePart(DateInterval.Month, dtfrom.Value)
        a3 = DatePart(DateInterval.Year, dtfrom.Value)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtto.Value)
        a12 = DatePart(DateInterval.Month, dtto.Value)
        a13 = DatePart(DateInterval.Year, dtto.Value)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub


    Private Sub POFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub POFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim OBJPO As New PODesign
            OBJPO.MdiParent = MDIMain
            OBJPO.WHERECLAUSE = " {ALLPURCHASEORDER.PO_cmpid}=" & CmpId & " and {ALLPURCHASEORDER.PO_yearid}=" & YearId

            If chkdate.Checked = True Then
                getFromToDate()
                OBJPO.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
            Else
                OBJPO.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If


            If CMBNAME.Text <> "" Then OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text.Trim & "'"
            If CMBNONINVITEM.Text <> "" Then OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " and {NONINVITEMMASTER.NONINV_name}='" & CMBNONINVITEM.Text.Trim & "'"


            If RDDETAILS.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJPO.FRMSTRING = "PODTLS" Else OBJPO.FRMSTRING = "POSUMM"
                For Each DTROW As DataRowView In CHKFORMBOX.CheckedItems
                    OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " AND {FORMTYPE.FORM_NAME} = '" & DTROW.Item(0) & "'"
                Next

            ElseIf RDBPARTY.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJPO.FRMSTRING = "PARTYWISEDTLS" Else OBJPO.FRMSTRING = "PARTYWISESUMM"
                If CMBNAME.Text <> "" Then OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text.Trim & "'"

            ElseIf RDBITEM.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJPO.FRMSTRING = "ITEMWISEDTLS" Else OBJPO.FRMSTRING = "ITEMWISESUMM"

            ElseIf RBPENDING.Checked = True Then
                OBJPO.FRMSTRING = "PENDINGORDERS"
                OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " AND {ALLPURCHASEORDER_DESC.PO_QTY} - {ALLPURCHASEORDER_DESC.PO_OUTQTY} > 0 AND {ALLPURCHASEORDER_DESC.PO_CLOSE}= False"

            ElseIf RBCLOSED.Checked = True Then
                OBJPO.FRMSTRING = "CLOSEDORDERS"
                OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " AND {ALLPURCHASEORDER_DESC.PO_CLOSE}= True "

            ElseIf RBCOMPLETED.Checked = True Then
                OBJPO.FRMSTRING = "COMPLETEORDERS"
                OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & " AND {ALLPURCHASEORDER_DESC.PO_QTY} - {ALLPURCHASEORDER_DESC.PO_OUTQTY} <= 0 AND {ALLPURCHASEORDER_DESC.PO_CLOSE}= False"

            End If

            gridbill.ClearColumnsFilter()

            Dim NAMECLAUSE As String = ""
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If NAMECLAUSE = "" Then
                        NAMECLAUSE = " AND ({LEDGERS.ACC_CMPNAME} = '" & dtrow("NAME") & "'"
                    Else
                        NAMECLAUSE = NAMECLAUSE & " OR {LEDGERS.ACC_CMPNAME} = '" & dtrow("NAME") & "'"
                    End If
                End If
            Next

            If NAMECLAUSE <> "" Then
                NAMECLAUSE = NAMECLAUSE & ")"
                OBJPO.WHERECLAUSE = OBJPO.WHERECLAUSE & NAMECLAUSE
            End If

            OBJPO.SHOWHEADER = CHKHEADER.CheckState
            OBJPO.SHOWPRINTDATE = CHKPRINTDATE.CheckState
            OBJPO.NEWPAGE = CHKGROUPONNEWPG.CheckState
            If CHKADDRESS.Checked = True Then OBJPO.ADDRESS = 1 Else OBJPO.ADDRESS = 0

            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNONINVITEM_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNONINVITEM.Enter
        Try
            If CMBNONINVITEM.Text.Trim = "" Then FILLNONINVITEM(CMBNONINVITEM, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNONINVITEM_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNONINVITEM.Validating
        Try
            If CMBNONINVITEM.Text.Trim <> "" Then NONINVITEMVALIDATE(CMBNONINVITEM, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            If gridbilldetails.Visible = True Then
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    dtrow("CHK") = CHKSELECTALL.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBSELECTED_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSELECTED.CheckedChanged
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" CAST (0 AS BIT) AS CHK,LEDGERS.Acc_cmpname AS NAME, GROUPMASTER.group_secondary AS UNDER, ISNULL(CITYMASTER.city_name, '') AS CITY  ", " ", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id AND LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid LEFT OUTER JOIN CITYMASTER ON LEDGERS.Acc_yearid = CITYMASTER.city_yearid AND LEDGERS.Acc_locationid = CITYMASTER.city_locationid AND LEDGERS.Acc_cmpid = CITYMASTER.city_cmpid AND LEDGERS.Acc_cityid = CITYMASTER.city_id ", " AND (LEDGERS.ACC_CMPID = '" & CmpId & "') AND (LEDGERS.ACC_LOCATIONID = '" & Locationid & "') AND (LEDGERS.ACC_YEARID = '" & YearId & "') and GROUPMASTER.group_secondary='SUNDRY CREDITORS' ORDER BY LEDGERS.Acc_cmpname")
            gridbilldetails.DataSource = dt

            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

  
End Class