Imports BL

Public Class ConsumptionFilter
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
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
            If CMBDEPT.Text.Trim = "" Then FILLDEPARTMNET(CMBDEPT, edit)
            If CMBITEM.Text.Trim = "" Then FILLNONINVITEM(CMBITEM, edit, " AND ISNULL(NonInvItemMaster.NONINV_ISPLATE,0) = 0")

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Private Sub CMBDEPT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDEPT.Enter
        Try
            If CMBDEPT.Text.Trim = "" Then FILLDEPARTMNET(CMBDEPT, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEPT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDEPT.Validating
        Try
            If CMBDEPT.Text.Trim <> "" Then DEPARTMENTVALIDATE(CMBDEPT, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBITEM_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITEM.Enter
        Try
            If CMBITEM.Text.Trim = "" Then FILLNONINVITEM(CMBITEM, edit, " AND NonInvItemMaster.NONINV_ISPLATE = 0")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEM_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEM.Validating
        Try
            If CMBITEM.Text.Trim = "" Then NONINVITEMVALIDATE(CMBITEM, e, Me)
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

    Private Sub ConsumptionFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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


    Private Sub ConsumptionFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim OBJCONSUME As New ConsumptionDesign
            OBJCONSUME.MdiParent = MDIMain
            OBJCONSUME.WHERECLAUSE = " {CONSUMPTION.CONSUME_yearid}=" & YearId

            If chkdate.Checked = True Then
                getFromToDate()
                OBJCONSUME.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJCONSUME.WHERECLAUSE = OBJCONSUME.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
            Else
                OBJCONSUME.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If CMBGODOWN.Text.Trim <> "" Then OBJCONSUME.WHERECLAUSE = OBJCONSUME.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text.Trim & "'"
            If CMBDEPT.Text.Trim <> "" Then OBJCONSUME.WHERECLAUSE = OBJCONSUME.WHERECLAUSE & " and {DEPARTMENTMASTER.DEPARTMENT_NAME}='" & CMBDEPT.Text.Trim & "'"
            If CMBITEM.Text.Trim <> "" Then OBJCONSUME.WHERECLAUSE = OBJCONSUME.WHERECLAUSE & " and {NONINVITEMMASTER.NONINV_name}='" & CMBITEM.Text.Trim & "'"

            If RDDETAILS.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJCONSUME.FRMSTRING = "CONSUMPTIONDTLS" Else OBJCONSUME.FRMSTRING = "CONSUMPTIONSUMM"
            ElseIf RDBDEPT.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJCONSUME.FRMSTRING = "DEPTWISEDTLS" Else OBJCONSUME.FRMSTRING = "DEPTWISESUMM"
            ElseIf RDBGODOWN.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJCONSUME.FRMSTRING = "GODOWNWISEDTLS" Else OBJCONSUME.FRMSTRING = "GODOWNWISESUMM"
            ElseIf RDBITEM.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJCONSUME.FRMSTRING = "ITEMWISEDTLS" Else OBJCONSUME.FRMSTRING = "ITEMWISESUMM"
            End If

            OBJCONSUME.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class