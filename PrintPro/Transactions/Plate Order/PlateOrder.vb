Imports System.ComponentModel
Imports BL

Public Class PlateOrder
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean
    Public EDIT As Boolean
    Public TEMPID As Integer
    Public TEMPNAME As String = ""
    Dim IntResult As Integer

    Private Sub ShelfMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
                Dim DTROW() As DataRow

                DTROW = USERRIGHTS.Select("FormName = 'GDN'")


            FILLCMB()
                CLEAR()


            Dim OBJDEPT As New ClsPlateOrder
            OBJDEPT.alParaval.Add(TEMPID)
            OBJDEPT.alParaval.Add(YearId)
            Dim DT As DataTable = OBJDEPT.SELECTPLATE()
            If DT.Rows.Count > 0 Then
                For Each DR As DataRow In DT.Rows
                    TXTENTRYNO.Text = TEMPID
                    TXTENTRYNO.ReadOnly = True
                    TXTDATE.Text = Format(Convert.ToDateTime(DR("DATE")), "dd/MM/yyyy")
                    cmbname.Text = Convert.ToString(DR("NAME"))
                    CMBITEMCODE.Text = Convert.ToString(DR("ITEMCODE"))
                    CMBPLATE.Text = Convert.ToString(DR("PLATE"))
                    TXTNOOFPLATE.Text = Convert.ToString(DR("NOOFPLATE"))
                    TXTRECDATE.Text = Format(Convert.ToDateTime(DR("RECDATE")), "dd/MM/yyyy")
                    txtremarks.Text = Convert.ToString(DR("REMARKS"))
                Next
            End If



        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub getmax_ORDER_no()
        Dim dttable As DataTable
        dttable = getmax("ISNULL(MAX(ORDER_NO),0)+1", "PLATEORDER", " AND ORDER_CMPID = " & CmpId & " AND ORDER_YEARID = " & YearId)
        If dttable.Rows.Count > 0 Then
            TXTENTRYNO.Text = dttable(0).Item(0)
        End If
    End Sub

    Private Sub ShelfMaster_KEYDOWN(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True
            If cmbname.Text.Trim = "" Then
                EP.SetError(cmbname, "Enter Proper Name")
                BLN = False
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CMDSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(TXTENTRYNO.Text.Trim)
            ALPARAVAL.Add(Format(Convert.ToDateTime(TXTDATE.Text.Trim).Date, "MM/dd/yyyy"))
            ALPARAVAL.Add(cmbname.Text.Trim)
            ALPARAVAL.Add(CMBITEMCODE.Text.Trim)
            ALPARAVAL.Add(CMBPLATE.Text.Trim)
            ALPARAVAL.Add(TXTNOOFPLATE.Text.Trim)
            ALPARAVAL.Add(Format(Convert.ToDateTime(TXTRECDATE.Text.Trim).Date, "MM/dd/yyyy"))
            ALPARAVAL.Add(txtremarks.Text.Trim)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            Dim OBJORDER As New ClsPlateOrder()
            OBJORDER.alParaval = ALPARAVAL

            If EDIT = False Then



                Dim DTT As DataTable = OBJORDER.SAVE()
                MsgBox("Details Added!!")
                'PRINTREPORT(DTT.Rows(0).Item(0))
            Else

                ALPARAVAL.Add(TEMPID)
                IntResult = OBJORDER.UPDATE()
                MsgBox("Details Updated")
            End If


            CLEAR()
            cmbname.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEXIT.Click
        Me.Close()
    End Sub

    Sub CLEAR()
        Try
            cmbname.Text = ""
            CMBITEMCODE.Text = ""
            CMBPLATE.Text = ""
            TXTDATE.Clear()

            getmax_ORDER_no()
            txtremarks.Clear()
            TXTNOOFPLATE.Clear()
            TXTRECDATE.Clear()
            cmbname.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        Try
            CLEAR()
            EDIT = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then
                Dim OBJRACK As New ClsPlateOrder
                OBJRACK.alParaval.Add(TEMPID)
                OBJRACK.alParaval.Add(YearId)

                Dim intResult As Integer = OBJRACK.delete
                MsgBox("Rack Deleted Successfully")
                CLEAR()
                EDIT = False
                cmbname.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub TXTNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
    '    Try
    '        If txtname.Text.Trim <> "" Then
    '            If (EDIT = False) Or (EDIT = True And TEMPRACKNAME.Trim.ToLower <> txtname.Text.Trim.ToLower) Then
    '                Dim OBJCMN As New ClsCommon
    '                Dim DT As DataTable = OBJCMN.search("RACK_ID AS ID", "", "RACKMASTER", " AND RACK_NAME = '" & txtname.Text.Trim & "' AND RACK_YEARID = " & YearId)
    '                If DT.Rows.Count > 0 Then
    '                    MsgBox("Rack Name Already Exists", MsgBoxStyle.Critical)
    '                    e.Cancel = True
    '                    Exit Sub
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Sub

    Private Sub cmbdelivery_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbdelivery_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, CMBCODE, e, Me, TXTADD, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMCODE_Enter(sender As Object, e As EventArgs) Handles CMBITEMCODE.Enter
        Try
            If CMBITEMCODE.Text.Trim = "" Then fillITEMCODE(cmbname, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMCODE.Validating
        Try
            If CMBITEMCODE.Text.Trim <> "" Then ITEMNAMEVALIDATE(CMBITEMCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPLATE_Enter(sender As Object, e As EventArgs) Handles CMBPLATE.Enter
        Try
            If CMBPLATE.Text.Trim = "" Then FILLNONINVITEM(CMBPLATE, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPLATE_Validating(sender As Object, e As CancelEventArgs) Handles CMBPLATE.Validating
        Try
            If CMBPLATE.Text.Trim <> "" Then NONINVITEMVALIDATE(CMBPLATE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLPRIVIOUS_Click(sender As Object, e As EventArgs) Handles TOOLPRIVIOUS.Click
        Try
            cmbname.Text = ""
LINE1:
            TEMPID = Val(TXTENTRYNO.Text) - 1
            If TEMPID > 0 Then
                EDIT = True
                ShelfMaster_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If cmbname.Text.Trim = "" And TEMPID > 1 Then
                TXTENTRYNO.Text = TEMPID
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLNEXT_Click(sender As Object, e As EventArgs) Handles TOOLNEXT.Click
        Try
            cmbname.Text = ""
LINE1:
            TEMPID = Val(TXTENTRYNO.Text) + 1
            ShelfMaster_Load(sender, e)
            Dim MAXNO As Integer = TXTENTRYNO.Text.Trim
            CLEAR()
            If Val(TXTENTRYNO.Text) - 1 >= TEMPID Then
                EDIT = True
                ShelfMaster_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If cmbname.Text.Trim = "" And TEMPID < MAXNO Then
                TXTENTRYNO.Text = TEMPID
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, "AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
        If CMBITEMCODE.Text.Trim = "" Then fillITEMCODE(CMBITEMCODE, EDIT)
        If CMBPLATE.Text.Trim = "" Then FILLNONINVITEM(CMBPLATE, EDIT)
    End Sub
End Class

