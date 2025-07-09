
Imports BL

Public Class Purchase_Invoice_Filter
    Dim edit As Boolean
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
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

    Sub FILLCMB()
        Try
            If CMBNAME.Text.Trim <> "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
            If CMBITEMNAME.Text.Trim = "" Then FILLNONINVITEM(CMBITEMNAME, edit)
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
            fillregister(cmbregister, " AND REGISTER_TYPE = 'PURCHASE'")
            fillform(CHKFORMBOX, edit)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub Purchase_Invoice_Filter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FILLCMB()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Purchase_Invoice_Filter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim OBJPUR As New PurchaseInvoiceDesign
            OBJPUR.MdiParent = MDIMain
            OBJPUR.WHERECLAUSE = " {PURCHASEMASTER.BILL_yearid}=" & YearId

            If chkdate.Checked = True Then
                getFromToDate()
                OBJPUR.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJPUR.WHERECLAUSE = OBJPUR.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
            Else
                OBJPUR.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If cmbregister.Text.Trim <> "" Then OBJPUR.WHERECLAUSE = OBJPUR.WHERECLAUSE & " AND {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "'"
            If CMBNAME.Text <> "" Then OBJPUR.WHERECLAUSE = OBJPUR.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text.Trim & "'"
            If cmbtrans.Text <> "" Then OBJPUR.WHERECLAUSE = OBJPUR.WHERECLAUSE & " and {transledgers.ACC_CMPNAME}='" & cmbtrans.Text.Trim & "'"
            If CMBITEMNAME.Text <> "" Then OBJPUR.WHERECLAUSE = OBJPUR.WHERECLAUSE & " and {NONINVITEMMASTER.NONINV_NAME}='" & CMBITEMNAME.Text.Trim & "'"
            If CMBGODOWN.Text <> "" Then OBJPUR.WHERECLAUSE = OBJPUR.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text.Trim & "'"


            If RDDETAILS.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJPUR.FRMSTRING = "PURCHASEDTLS" Else OBJPUR.FRMSTRING = "PURCHASESUMM"
                For Each DTROW As DataRowView In CHKFORMBOX.CheckedItems
                    OBJPUR.WHERECLAUSE = OBJPUR.WHERECLAUSE & " AND {FORMTYPE.FORM_NAME} = '" & DTROW.Item(0) & "'"
                Next

            ElseIf RDBPARTY.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJPUR.FRMSTRING = "PARTYWISEDTLS" Else OBJPUR.FRMSTRING = "PARTYWISESUMM"

            ElseIf RDBTRANS.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJPUR.FRMSTRING = "TRANSWISEDTLS" Else OBJPUR.FRMSTRING = "TRANSWISESUMM"

            ElseIf RDITEM.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJPUR.FRMSTRING = "ITEMWISEDTLS" Else OBJPUR.FRMSTRING = "ITEMWISESUMM"

            ElseIf RDBGODOWN.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJPUR.FRMSTRING = "GODOWNWISEDTLS" Else OBJPUR.FRMSTRING = "GODOWNWISESUMM"

            ElseIf RDBMONTHLY.Checked = True Then
                OBJPUR.FRMSTRING = "MONTHLY"
            End If

            If TXTAMT.Text <> "" And CMBSIGN.Text <> "" Then
                If CMBSIGN.Text = "=" Then OBJPUR.WHERECLAUSE = OBJPUR.WHERECLAUSE & " and {PURCHASEMASTER.BILL_GTOTAL}=" & TXTAMT.Text.Trim & ""
                If CMBSIGN.Text = ">" Then OBJPUR.WHERECLAUSE = OBJPUR.WHERECLAUSE & " and {PURCHASEMASTER.BILL_GTOTAL}>" & TXTAMT.Text.Trim & ""
                If CMBSIGN.Text = "<" Then OBJPUR.WHERECLAUSE = OBJPUR.WHERECLAUSE & " and {PURCHASEMASTER.BILL_GTOTAL}<" & TXTAMT.Text.Trim & ""
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
                OBJPUR.WHERECLAUSE = OBJPUR.WHERECLAUSE & NAMECLAUSE
            End If

            OBJPUR.SHOWHEADER = CHKHEADER.CheckState
            OBJPUR.SHOWPRINTDATE = CHKPRINTDATE.CheckState
            OBJPUR.NEWPAGE = CHKGROUPONNEWPG.CheckState
            OBJPUR.ADDRESS = CHKADDRESS.CheckState
            'If CHKADDRESS.Checked = True Then OBJPUR.ADDRESS = 1 Else OBJPUR.ADDRESS = 0

            OBJPUR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAMT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAMT.KeyPress
        Try
            numkeypress(e, TXTAMT, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then FILLNONINVITEM(CMBITEMNAME, edit)
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

    Private Sub TXTRATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress
        numdotkeypress(e, TXTRATE, Me)
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

    Private Sub cmbregister_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, "AND REGISTER_TYPE = 'PURCHASE'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class