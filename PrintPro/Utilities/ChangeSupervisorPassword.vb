
Imports BL

Public Class ChangeSupervisorPassword

    Public edit As Boolean
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public TempID As Integer         'Used for tempname while edit mode
    Public TempName As String        'Used for tempname while edit mode

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChangeSupervisorPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
           
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.C Then       'for Clear
                Call cmdclear_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
           
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If CMBSUPERVISOR.Text.Trim.Length = 0 Then
            EP.SetError(CMBSUPERVISOR, "Enter Supervisor Name")
            bln = False
        End If

        If TXTOLDPASSWORD.Text.Trim.Length = 0 Then
            EP.SetError(TXTOLDPASSWORD, "Enter Old Password")
            bln = False
        End If

        If TXTNEWPASSWORD.Text.Trim.Length = 0 Then
            EP.SetError(TXTNEWPASSWORD, "Enter New Password")
            bln = False
        End If

        If TXTNEWPASSWORD.Text.Trim <> TXTCONFIRMPASSWORD.Text.Trim Then
            EP.SetError(TXTCONFIRMPASSWORD, "Password Does not Match")
            TXTNEWPASSWORD.Clear()
            TXTCONFIRMPASSWORD.Clear()
            bln = False
        End If


        Dim objCommon2 As New ClsCommonMaster
        Dim dttable2 As DataTable
        dttable2 = objCommon2.search(" ISNULL(SUP_NAME,''), ISNULL(SUP_PASSWORD,'') ", "", "SUPERVISORMaster", " and SUP_ID = " & TempID & " and SUP_YEARID = " & YearId)

        If dttable2.Rows.Count > 0 Then
            If TXTOLDPASSWORD.Text <> dttable2.Rows(0).Item(1).ToString Then
                MsgBox("Wrong Password!")
                bln = False
            End If
        End If
        Return bln

    End Function

    Private Sub ChangeSupervisorPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCMB()
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If


            'dttable = objCommon.search(" ISNULL(SUP_NAME,''), ISNULL(SUP_PASSWORD,'') ", "", "SUPERVISORMaster", " and SUP_ID = " & TempID & " and SUP_CMPID = " & CmpId & " and SUP_YEARID = " & YearId)

            'CMBSUPERVISOR.Text = TempName



            'If dttable.Rows.Count > 0 Then
            '    TXTSUPERVISOR.Text = dttable.Rows(0).Item(0).ToString
            '    TXTPASSWORD.Text = dttable.Rows(0).Item(1).ToString
            'End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        CMBSUPERVISOR.Focus()
    End Sub

    Sub clear()
        Try
            EP.Clear()
            CMBSUPERVISOR.Text = ""
            TXTOLDPASSWORD.Clear()
            TXTNEWPASSWORD.Clear()
            TXTCONFIRMPASSWORD.Clear()
            CMBSUPERVISOR.Enabled = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(CMBSUPERVISOR.Text.Trim)
            alParaval.Add(TXTNEWPASSWORD.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim OBJ As New ClsSupervisorMaster
            OBJ.alParaval = alParaval

            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            'IntResult = OBJ.save()
            'MsgBox("Details Added")

            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            alParaval.Add(TempID)
            IntResult = OBJ.update()
            edit = False
            MsgBox("Details Updated")


            clear()
            CMBSUPERVISOR.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSUPERVISOR_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSUPERVISOR.Enter
        Try
            If CMBSUPERVISOR.Text.Trim <> "" Then FILLSUPERVISOR(CMBSUPERVISOR, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSUPERVISOR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSUPERVISOR.Validating
        Try
            If CMBSUPERVISOR.Text.Trim <> "" Then SUPERVISORVALIDATE(CMBSUPERVISOR, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        If CMBSUPERVISOR.Text.Trim = "" Then FILLSUPERVISOR(CMBSUPERVISOR, edit)
    End Sub

    Private Sub TXTOLDPASSWORD_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTOLDPASSWORD.Validating
        Try
            Dim objCommon As New ClsCommonMaster
            Dim dttable As DataTable
            dttable = objCommon.search(" ISNULL(SUP_NAME,''), ISNULL(SUP_PASSWORD,'') ", "", "SUPERVISORMaster", " and SUP_ID = " & TempID & " and SUP_YEARID = " & YearId)

            If dttable.Rows.Count > 0 Then
                If TXTOLDPASSWORD.Text <> dttable.Rows(0).Item(1).ToString Then MsgBox("Wrong Password!")
                'e.Cancel = True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSUPERVISOR_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSUPERVISOR.Validated
        Try
            If CMBSUPERVISOR.Text.Trim <> "" Then
                CMBSUPERVISOR.Enabled = False

                Dim objCommon1 As New ClsCommonMaster
                Dim dttable1 As DataTable
                dttable1 = objCommon1.search(" ISNULL(SUP_ID, 0) AS SUPID ", "", "SUPERVISORMASTER", " and SUP_NAME = '" & CMBSUPERVISOR.Text.Trim & "' and SUP_YEARID = " & YearId)
                TempID = Val(dttable1.Rows(0).Item(0).ToString)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class