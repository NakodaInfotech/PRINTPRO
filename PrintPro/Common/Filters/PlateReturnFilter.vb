Imports BL

Public Class PlateReturnFilter
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
            If CMBPLATE.Text.Trim = "" Then FILLNONINVITEM(CMBPLATE, edit, " AND NonInvItemMaster.NONINV_ISPLATE = 1")

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

    Private Sub CMBPLATE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPLATE.Enter
        Try
            If CMBPLATE.Text.Trim = "" Then FILLNONINVITEM(CMBPLATE, edit, " AND NonInvItemMaster.NONINV_ISPLATE = 1")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPLATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPLATE.Validating
        Try
            If CMBPLATE.Text.Trim = "" Then NONINVITEMVALIDATE(CMBPLATE, e, Me)
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


    Private Sub PlateReturnFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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


    Private Sub PlateReturnFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim OBJPLATERTN As New PlateReturnDesign
            OBJPLATERTN.MdiParent = MDIMain
            OBJPLATERTN.WHERECLAUSE = " {PLATERETURN.RETURN_yearid}=" & YearId

            If chkdate.Checked = True Then
                getFromToDate()
                OBJPLATERTN.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJPLATERTN.WHERECLAUSE = OBJPLATERTN.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
            Else
                OBJPLATERTN.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If CMBGODOWN.Text.Trim <> "" Then OBJPLATERTN.WHERECLAUSE = OBJPLATERTN.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text.Trim & "'"
            If CMBPLATE.Text.Trim <> "" Then OBJPLATERTN.WHERECLAUSE = OBJPLATERTN.WHERECLAUSE & " and {NONINVITEMMASTER.NONINV_name}='" & CMBPLATE.Text.Trim & "'"

            If RDDETAILS.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJPLATERTN.FRMSTRING = "PLATERETURNDTLS" Else OBJPLATERTN.FRMSTRING = "PLATERETURNSUMM"
            ElseIf RDBGODOWN.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJPLATERTN.FRMSTRING = "GODOWNWISEDTLS" Else OBJPLATERTN.FRMSTRING = "GODOWNWISESUMM"
            ElseIf RDBPLATE.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJPLATERTN.FRMSTRING = "PLATEWISEDTLS" Else OBJPLATERTN.FRMSTRING = "PLATEWISESUMM"
            End If

            OBJPLATERTN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class