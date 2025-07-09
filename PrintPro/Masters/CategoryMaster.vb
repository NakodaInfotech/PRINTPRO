Imports BL

Public Class CategoryMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Public frmString As String       'Used for form Category or GRade
    Public TempName As String        'Used for tempname while edit mode
    Public TempID As Integer
    Public edit As Boolean           'Used for edit

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub txtname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            'for search
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If (edit = False) Or (edit = True And LCase(TempName) <> LCase(txtname.Text.Trim)) Then
                If frmString = "NARRATION" Then
                    dt = objclscommon.search("NARRATION_name", "", "NARRATIONMaster", " and NARRATION_name = '" & txtname.Text.Trim & "' and NARRATION_cmpid = " & CmpId & " and NARRATION_Locationid = " & Locationid & " and NARRATION_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("NARRATION Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If
                ElseIf frmString = "PARTYBANK" Then
                    dt = objclscommon.search("PARTYBANK_name", "", "PARTYBANKMaster", " and PARTYBANK_name = '" & txtname.Text.Trim & "' and PARTYBANK_cmpid = " & CmpId & " and PARTYBANK_Locationid = " & Locationid & " and PARTYBANK_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("PARTYBANK Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If
                ElseIf frmString = "PROBLEMMASTER" Then
                    dt = objclscommon.search("PROBLEM_name", "", "PROBLEMMaster", " and PROBLEM_name = '" & txtname.Text.Trim & "' and PROBLEM_cmpid = " & CmpId & " and PROBLEM_Locationid = " & Locationid & " and PROBLEM_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("PROBLEM Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If
                ElseIf frmString = "REASONMASTER" Then
                    dt = objclscommon.search("REASON_name", "", "REASONMaster", " and REASON_name = '" & txtname.Text.Trim & "' and REASON_cmpid = " & CmpId & " and REASON_Locationid = " & Locationid & " and REASON_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("REASON Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If
                ElseIf frmString = "OPERATORMASTER" Then
                    dt = objclscommon.search("OPERATOR_name", "", "OPERATORMASTER", " and OPERATOR_name = '" & txtname.Text.Trim & "' and OPERATOR_cmpid = " & CmpId & " and OPERATOR_Locationid = " & Locationid & " and OPERATOR_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("OPERATOR Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If
                End If
            End If

            pcase(txtname)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(txtname.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            If frmString = "NARRATION" Then
                Dim OBJ As New ClsNarrationMaster
                OBJ.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    edit = False
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "PARTYBANK" Then
                Dim OBJ As New ClsPARTYBANKMaster
                OBJ.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    edit = False
                    MsgBox("Details Updated")
                End If


            ElseIf frmString = "PROBLEMMASTER" Then
                Dim OBJ As New ClsProblemMaster
                OBJ.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    edit = False
                    MsgBox("Details Updated")
                End If


            ElseIf frmString = "REASONMASTER" Then
                Dim OBJ As New ClsReasonMaster
                OBJ.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    edit = False
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "OPERATORMASTER" Then
                Dim OBJ As New ClsOperatorMaster
                OBJ.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    edit = False
                    MsgBox("Details Updated")
                End If
            End If

            clear()
            txtname.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtname.Text.Trim.Length = 0 Then
            Ep.SetError(txtname, "Fill Name")
            bln = False
        End If
        Return bln
    End Function

    Sub clear()
        txtname.Clear()
        txtremarks.Clear()
    End Sub

    Private Sub CategoryMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub CategoryMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster

            If frmString = "NARRATION" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Narration Master"
                lblgroup.Text = "Narration"
                lbl.Text = "Enter Narration " & vbNewLine & "(e.g.  Remarks..., etc. )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" NARRATION_name AS NAME, NARRATION_REMARKS AS REMARKS", "", "NARRATIONMaster", " and NARRATION_id = " & TempID & " and NARRATION_cmpid = " & CmpId & " and NARRATION_Locationid = " & Locationid & " and NARRATION_yearid = " & YearId)

            ElseIf frmString = "PARTYBANK" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "PartyBank Master"
                lblgroup.Text = "Party Bank"
                lbl.Text = "Enter Party Bank " & vbNewLine & "(e.g.  SBI,Canara..., etc. )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" PARTYBANK_name AS NAME, PARTYBANK_REMARKS AS REMARKS ", "", "PARTYBANKMaster", " and PARTYBANK_id = " & TempID & " and PARTYBANK_cmpid = " & CmpId & " and PARTYBANK_Locationid = " & Locationid & " and PARTYBANK_yearid = " & YearId)

            ElseIf frmString = "PROBLEMMASTER" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Problem Master"
                lblgroup.Text = "Problem"
                lbl.Text = "Enter Problem " & vbNewLine & "(e.g.  Remarks..., etc. )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" problem_name AS NAME, PROBLEM_REMARK AS REMARKS ", "", "PROBLEMMaster", " and PROBLEM_id = " & TempID & " and PROBLEM_cmpid = " & CmpId & " and PROBLEM_Locationid = " & Locationid & " and PROBLEM_yearid = " & YearId)

            ElseIf frmString = "REASONMASTER" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Reason Master"
                lblgroup.Text = "Reason"
                lbl.Text = "Enter Reason " & vbNewLine & "(e.g.  Remarks..., etc. )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" Reason_name AS NAME, REASON_REMARK AS REMARKS ", "", "REASONMASTER", " and REASON_id = " & TempID & " and REASON_cmpid = " & CmpId & " and REASON_Locationid = " & Locationid & " and REASON_yearid = " & YearId)

            ElseIf frmString = "OPERATORMASTER" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Operator Master"
                lblgroup.Text = "Operator"
                lbl.Text = "Enter Operator " & vbNewLine & "(e.g.  Remarks..., etc. )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" OPERATOR_name AS NAME, OPERATOR_REMARK AS REMARKS ", "", "OPERATORMASTER", " and OPERATOR_id = " & TempID & " and OPERATOR_cmpid = " & CmpId & " and OPERATOR_Locationid = " & Locationid & " and OPERATOR_yearid = " & YearId)

            End If

            If dttable.Rows.Count > 0 Then
                txtname.Text = TempName
                txtname.Text = dttable.Rows(0).Item("NAME")
                txtremarks.Text = dttable.Rows(0).Item("REMARKS")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class