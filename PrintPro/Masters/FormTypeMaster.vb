
Imports BL

Public Class FormTypeMaster

    Public EDIT As Boolean              'Used for edit
    Public TEMPNAME As String           'Used for edit name
    Public TEMPID As Integer            'Used for edit id
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(TXTFORMTYPE.Text.Trim)
            alParaval.Add(TXTREMARKS.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim OBJFORMTYPE As New Clsformtype
            OBJFORMTYPE.alParaval = alParaval

            If EDIT = False Then
                'If USERADD = False Then
                '    MsgBox("Insufficient Rights")
                '    Exit Sub
                'End If
                IntResult = OBJFORMTYPE.SAVE()
                MsgBox("Form Added")
            ElseIf EDIT = True Then
                'If USEREDIT = False Then
                '    MsgBox("Insufficient Rights")
                '    Exit Sub
                'End If
                alParaval.Add(TEMPID)
                OBJFORMTYPE.alParaval = alParaval
                IntResult = OBJFORMTYPE.UPDATE()
                MsgBox("Form Updated")
            End If

            clear()
            TXTFORMTYPE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If TXTFORMTYPE.Text.Trim.Length = 0 Then
            EP.SetError(TXTFORMTYPE, "Fill Name")
            bln = False
        End If

        Return bln
    End Function

    Sub clear()
        TXTFORMTYPE.Clear()
        TXTREMARKS.Clear()
    End Sub

    Private Sub FormTypeMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        End If
    End Sub

    Private Sub FormTypeMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'PURCHASE INVOICE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If EDIT = True Then
                'If USEREDIT = False And USERVIEW = False Then
                '    MsgBox("Insufficient Rights")
                '    Exit Sub
                'End If
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" FORM_NAME AS FORMNAME, FORM_REMARK AS REMARKS", "", "FORMTYPE", " and FORM_ID = " & TEMPID & " and FORM_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTFORMTYPE.Text = DT.Rows(0).Item("FORMNAME")
                    TXTREMARKS.Text = DT.Rows(0).Item("REMARKS")
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub TXTFORMTYPE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTFORMTYPE.Validating

        Try

            If (EDIT = False) Or (EDIT = True And LCase(TEMPNAME) <> LCase(TXTFORMTYPE.Text.Trim)) Then
                ' search duplication 
                If TXTFORMTYPE.Text.Trim <> Nothing Then
                    Dim OBJCMN As New ClsCommon
                    Dim dt As DataTable = OBJCMN.search("FORm_name", "", "formtype", " and FORm_name = '" & TXTFORMTYPE.Text.Trim & "'and FORm_cmpid = " & CmpId & " and FORm_Locationid = " & Locationid & " and FORm_yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Form Name Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class