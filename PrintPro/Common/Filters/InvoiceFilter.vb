Imports BL

Public Class InvoiceFilter
    Dim edit As Boolean
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub fillcmb()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND ACC_TYPE = 'ACCOUNTS'")
            If CMBITEMNAME.Text.Trim = "" Then fillITEMNAME(CMBITEMNAME, edit)
            If CMBREGISTER.Text.Trim = "" Then fillregister(CMBREGISTER, "")
            fillform(CHKFORMBOX, edit)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' and LEDGERS.ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "Sundry DEBTORS", "ACCOUNTS")
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
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillITEMNAME(CMBITEMNAME, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then ITEMNAMEVALIDATE(CMBITEMNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITEMCODE.Enter
        Try
            If CMBITEMCODE.Text.Trim = "" Then fillITEMCODE(CMBITEMCODE, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMCODE.Validating
        Try
            If CMBITEMCODE.Text.Trim <> "" Then ITEMCODEvalidate(CMBITEMCODE, CMBITEMNAME, e, Me)
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

    Private Sub InvoiceFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then   'for Exit
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


    Private Sub InvoiceFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim OBJORDER As New SaleInvoiceDesign
            OBJORDER.MdiParent = MDIMain
            OBJORDER.WHERECLAUSE = " {INVOICEMASTER.INVOICE_cmpid}=" & CmpId & " and {INVOICEMASTER.INVOICE_yearid}=" & YearId

            If chkdate.Checked = True Then
                getFromToDate()
                OBJORDER.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJORDER.WHERECLAUSE = OBJORDER.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
            Else
                OBJORDER.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If


            If CMBNAME.Text <> "" Then OBJORDER.WHERECLAUSE = OBJORDER.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text.Trim & "'"
            If CMBITEMNAME.Text <> "" Then OBJORDER.WHERECLAUSE = OBJORDER.WHERECLAUSE & " and {ITEMMASTER.ITEM_name}='" & CMBITEMNAME.Text.Trim & "'"
            If CMBITEMCODE.Text <> "" Then OBJORDER.WHERECLAUSE = OBJORDER.WHERECLAUSE & " and {ITEMMASTER.ITEM_CODE}='" & CMBITEMCODE.Text.Trim & "'"
            If CMBREGISTER.Text <> "" Then OBJORDER.WHERECLAUSE = OBJORDER.WHERECLAUSE & " AND {REGISTERMASTER.REGISTER_NAME}='" & CMBREGISTER.Text.Trim & "'"


            If RDDETAILS.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJORDER.FRMSTRING = "INVOICEDTLS" Else OBJORDER.FRMSTRING = "INVOICESUMM"

            ElseIf RDBPARTY.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJORDER.FRMSTRING = "PARTYWISEDTLS" Else OBJORDER.FRMSTRING = "PARTYWISESUMM"

            ElseIf RDBITEM.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJORDER.FRMSTRING = "ITEMWISEDTLS" Else OBJORDER.FRMSTRING = "ITEMWISESUMM"

            ElseIf RDBMONTH.Checked = True Then
                OBJORDER.FRMSTRING = "MONTHLY"

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
                OBJORDER.WHERECLAUSE = OBJORDER.WHERECLAUSE & NAMECLAUSE
            End If

            OBJORDER.SHOWHEADER = CHKHEADER.CheckState
            OBJORDER.SHOWPRINTDATE = CHKPRINTDATE.CheckState
            OBJORDER.NEWPAGE = CHKGROUPONNEWPG.CheckState
            OBJORDER.ADDRESS = CHKADDRESS.CheckState
            'If CHKADDRESS.Checked = True Then OBJORDER.ADDRESS = 1 Else OBJORDER.ADDRESS = 0

            OBJORDER.Show()
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
            Dim dt As DataTable = objclsCMST.search(" CAST (0 AS BIT) AS CHK,LEDGERS.Acc_cmpname AS NAME, GROUPMASTER.group_secondary AS UNDER, ISNULL(CITYMASTER.city_name, '') AS CITY  ", " ", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id AND LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid LEFT OUTER JOIN CITYMASTER ON LEDGERS.Acc_yearid = CITYMASTER.city_yearid AND LEDGERS.Acc_locationid = CITYMASTER.city_locationid AND LEDGERS.Acc_cmpid = CITYMASTER.city_cmpid AND LEDGERS.Acc_cityid = CITYMASTER.city_id ", " AND (LEDGERS.ACC_CMPID = '" & CmpId & "') AND (LEDGERS.ACC_LOCATIONID = '" & Locationid & "') AND (LEDGERS.ACC_YEARID = '" & YearId & "') and GROUPMASTER.group_secondary='SUNDRY DEBTORS' ORDER BY LEDGERS.Acc_cmpname")
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