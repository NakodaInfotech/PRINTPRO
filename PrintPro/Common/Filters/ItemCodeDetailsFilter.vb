
Imports BL

Public Class ItemCodeDetailsFilter

    Dim edit As Boolean
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub ItemCodeDetailsFilter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
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

    Sub fillcmb()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND ACC_TYPE = 'ACCOUNTS'")
            If CMBITEMCODE.Text.Trim = "" Then fillITEMCODE(CMBITEMCODE, edit)
            If CMBITEMNAME.Text.Trim = "" Then fillITEMNAME(CMBITEMNAME, edit)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try

            Dim OBJITEM As New ItemCodeDesign
            OBJITEM.MdiParent = MDIMain
            OBJITEM.WHERECLAUSE = " {ACCOUNTSMASTER_SHADECARD.ACC_cmpid}=" & CmpId & " and {ACCOUNTSMASTER_SHADECARD.ACC_yearid}=" & YearId

            If chkdate.Checked = True Then
                getFromToDate()
                OBJITEM.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJITEM.WHERECLAUSE = OBJITEM.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
            Else
                OBJITEM.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If CMBNAME.Text.Trim <> "" Then OBJITEM.WHERECLAUSE = OBJITEM.WHERECLAUSE & " and {LEDGERS.ACC_CMPNAME}='" & CMBNAME.Text.Trim & "'"
            If CMBITEMNAME.Text.Trim <> "" Then OBJITEM.WHERECLAUSE = OBJITEM.WHERECLAUSE & " and {ITEMMASTER.ITEM_name}='" & CMBITEMNAME.Text.Trim & "'"
            If CMBITEMCODE.Text.Trim <> "" Then OBJITEM.WHERECLAUSE = OBJITEM.WHERECLAUSE & " and {ITEMMASTER.ITEM_CODE}='" & CMBITEMCODE.Text.Trim & "'"

            If RDBDETAILS.Checked = True Then
                OBJITEM.FRMSTRING = "ALLDATA"

            ElseIf RDBITEM.Checked = True Then
                OBJITEM.FRMSTRING = "ITEMCODE"

            ElseIf RDBPARTY.Checked = True Then
                OBJITEM.FRMSTRING = "PARTYWISEDTLS"
            End If


            OBJITEM.Show()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ItemCodeDetailsFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDGRID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDGRID.Click
        Try

            Dim OBJORDER As New ItemExpiryDetailsReport
            OBJORDER.MdiParent = MDIMain
            'OBJORDER.WHERECLAUSE = " ITEMMASTER.ITEM_yearid=" & YearId

            If CMBNAME.Text <> "" Then OBJORDER.WHERECLAUSE = OBJORDER.WHERECLAUSE & " and LEDGERS.ACC_CMPNAME='" & CMBNAME.Text.Trim & "'"
            If CMBITEMNAME.Text <> "" Then OBJORDER.WHERECLAUSE = OBJORDER.WHERECLAUSE & " and ITEMMASTER.ITEM_name='" & CMBITEMNAME.Text.Trim & "'"
            If CMBITEMCODE.Text <> "" Then OBJORDER.WHERECLAUSE = OBJORDER.WHERECLAUSE & " and ITEMMASTER.ITEM_CODE='" & CMBITEMCODE.Text.Trim & "'"
            'OBJORDER.WHERECLAUSE = OBJORDER.WHERECLAUSE & " AND ACCOUNTSMASTER_SHADECARD.ACC_EXPDATE <= '" & Format(Convert.ToDateTime(DateAdd(DateInterval.Month, +1, Mydate)).Date, " yyyy/MM/dd ") & "'"
            'OBJORDER.WHERECLAUSE = OBJORDER.WHERECLAUSE & "AND ACCOUNTSMASTER_SHADECARD.ACC_EXPDATE >= '" & Format(Convert.ToDateTime(Mydate).Date, " yyyy/MM/dd ") & "' AND ACCOUNTSMASTER_SHADECARD.ACC_EXPDATE <= '" & Format(Convert.ToDateTime(DateAdd(DateInterval.Month, +1, Mydate)).Date, " yyyy/MM/dd ") & "'"

            If chkdate.Checked = True Then
                OBJORDER.WHERECLAUSE = OBJORDER.WHERECLAUSE & " AND ACCOUNTSMASTER_SHADECARD.ACC_EXPDATE BETWEEN '" & Format(dtfrom.Value, "yyyy/MM/dd") & "' AND '" & Format(dtto.Value, "yyyy/MM/dd") & "'"
            End If
            OBJORDER.Show()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class