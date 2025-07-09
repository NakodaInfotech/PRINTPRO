Imports BL

Public Class ConsumptionReturnFilter
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

    Private Sub ConsumptionReturnFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub ConsumptionReturnFilter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillcmb()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim OBJCONSUMERTN As New ConsumptionReturnDesign
            OBJCONSUMERTN.MdiParent = MDIMain
            OBJCONSUMERTN.WHERECLAUSE = " {CONSUMPTIONRETURN.CONSUMERET_yearid}=" & YearId

            If chkdate.Checked = True Then
                getFromToDate()
                OBJCONSUMERTN.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJCONSUMERTN.WHERECLAUSE = OBJCONSUMERTN.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
            Else
                OBJCONSUMERTN.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If CMBGODOWN.Text.Trim <> "" Then OBJCONSUMERTN.WHERECLAUSE = OBJCONSUMERTN.WHERECLAUSE & " and {GODOWNMASTER.GODOWN_NAME}='" & CMBGODOWN.Text.Trim & "'"
            If CMBITEM.Text.Trim <> "" Then OBJCONSUMERTN.WHERECLAUSE = OBJCONSUMERTN.WHERECLAUSE & " and {NONINVITEMMASTER.NONINV_name}='" & CMBITEM.Text.Trim & "'"

            If RDDETAILS.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJCONSUMERTN.FRMSTRING = "CONSUMPTIONRETURNDTLS" Else OBJCONSUMERTN.FRMSTRING = "CONSUMPTIONRETURNSUMM"
            ElseIf RDBGODOWN.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJCONSUMERTN.FRMSTRING = "GODOWNWISEDTLS" Else OBJCONSUMERTN.FRMSTRING = "GODOWNWISESUMM"
            ElseIf RDBITEM.Checked = True Then
                If CHKSUMMARY.CheckState = CheckState.Unchecked Then OBJCONSUMERTN.FRMSTRING = "ITEMWISEDTLS" Else OBJCONSUMERTN.FRMSTRING = "ITEMWISESUMM"
            End If

            OBJCONSUMERTN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class