
Imports BL

Public Class SupervisorMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Public frmString As String       'Used for form Category or GRade
    Public TempName As String        'Used for tempname while edit mode
    Public TempID As Integer         'Used for tempname while edit mode
    Public edit As Boolean           'Used for edit

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(TXTSUPERVISOR.Text.Trim)
            alParaval.Add(TXTPASSWORD.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            ' alParaval.Add(0)
            If PBPHOTO.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBPHOTO.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                alParaval.Add(MS.ToArray)
            Else
                alParaval.Add(DBNull.Value)
            End If

            Dim OBJ As New ClsSupervisorMaster
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

            clear()
            TXTSUPERVISOR.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If TXTSUPERVISOR.Text.Trim.Length = 0 Then
            EP.SetError(TXTSUPERVISOR, "Fill Name")
            bln = False
        Else
            If (edit = False) Or (edit = True And LCase(TempName) <> LCase(TXTSUPERVISOR.Text.Trim)) Then

                ' search duplication 
                Dim OBJCMN As New ClsCommon
                Dim dt As New DataTable
                dt = OBJCMN.search(" SUP_NAME ", "", " SUPERVISORMaster ", " AND SUP_NAME = '" & TXTSUPERVISOR.Text.Trim & "' AND  SUP_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    EP.SetError(TXTSUPERVISOR, "Supervisor Name Already Exists")
                    bln = False
                End If
                uppercase(TXTSUPERVISOR)
            End If
        End If

        If TXTPASSWORD.Text.Trim.Length = 0 Then
            EP.SetError(TXTPASSWORD, "Fill Password")
            bln = False
        End If
        Return bln

    End Function

    Sub clear()
        EP.Clear()
        TXTSUPERVISOR.Clear()
        TXTPASSWORD.Clear()
        TXTPHOTOIMGPATH.Clear()
        PBPHOTO.Image = Nothing
    End Sub

    Private Sub SupervisorMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub SupervisorMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

           
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If edit = True Then
                dttable = objCommon.search(" ISNULL(SUP_NAME,''), ISNULL(SUP_PASSWORD,''), SUP_PHOTO   AS IMGPATH  ", "", "SUPERVISORMASTER", " and SUP_ID = " & TempID & " and SUP_YEARID = " & YearId)
            End If

            If dttable.Rows.Count > 0 Then
                TXTSUPERVISOR.Text = dttable.Rows(0).Item(0).ToString
                TempName = dttable.Rows(0).Item(0).ToString
                TXTPASSWORD.Text = dttable.Rows(0).Item(1).ToString
                If IsDBNull(dttable.Rows(0).Item("IMGPATH")) = False Then
                    PBPHOTO.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH"), Byte())))
                    TXTPHOTOIMGPATH.Text = dttable.Rows(0).Item("IMGPATH").ToString
                Else
                    PBPHOTO.Image = Nothing
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDPHOTOUPLOAD_Click(sender As Object, e As EventArgs) Handles CMDPHOTOUPLOAD.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png"
        OpenFileDialog1.ShowDialog()
        TXTPHOTOIMGPATH.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If TXTPHOTOIMGPATH.Text.Trim.Length <> 0 Then PBPHOTO.ImageLocation = TXTPHOTOIMGPATH.Text.Trim
    End Sub

    Private Sub CMDPHOTOREMOVE_Click(sender As Object, e As EventArgs) Handles CMDPHOTOREMOVE.Click
        Try
            PBPHOTO.Image = Nothing
            TXTPHOTOIMGPATH.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub TXTSUPERVISOR_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTSUPERVISOR.Validating
        Try

            If (edit = False) Or (edit = True And LCase(TempName) <> LCase(TXTSUPERVISOR.Text.Trim)) Then
                ' search duplication 
                If TXTSUPERVISOR.Text.Trim <> Nothing Then
                    Dim OBJCMN As New ClsCommonMaster
                    Dim dt As New DataTable
                    dt = OBJCMN.search(" SUP_NAME ", "", " SUPERVISORMaster ", " AND SUP_NAME = '" & TXTSUPERVISOR.Text.Trim & "' AND  SUP_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Name Already Exists", MsgBoxStyle.Critical, "PRINTPRO")
                        e.Cancel = True
                    End If
                    uppercase(TXTSUPERVISOR)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSHOWPASS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSHOWPASS.CheckedChanged
        Try
            If CHKSHOWPASS.Checked = True Then TXTPASSWORD.PasswordChar = "" Else TXTPASSWORD.PasswordChar = "*"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        TXTSUPERVISOR.Focus()
    End Sub
End Class