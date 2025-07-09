Imports System.ComponentModel
Imports BL

Public Class ComplaintMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean
    Public EDIT As Boolean
    Dim TEMPROW As Integer
    Dim GRIDDOUBLECLICK
    Public TEMPCOMPLAINTNO, TEMPREGNAME As String

    Private Sub CMDEXIT_Click(sender As Object, e As EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub CLEAR()

        CMBOPERATOR.Text = ""
        DTCOMPLAINTDATE.Value = Mydate
        TXTREMARKS.Clear()

        TXTGRIDSRNO.Text = 1
        CMBPROBLEMMASTER.Text = ""
        CMBREASONMASTER.Text = ""
        TXTGRIDREMARKS.Clear()
        GETMAX_COMPLAIN_NO()
        GRIDDOUBLECLICK = False
        GRIDCOMPLAINT.RowCount = 0
        GETMAX_COMPLAIN_NO()

    End Sub

    Sub GETMAX_COMPLAIN_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(COMPLAIN_NO),0) + 1 ", " COMPLAINTMASTER ", " AND COMPLAIN_YEARID = " & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTCOMPLAINNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Sub getsrno()
        Try
            For Each row As DataGridViewRow In GRIDCOMPLAINT.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If CMBOPERATOR.Text.Trim.Length = 0 Then
            Ep.SetError(CMBOPERATOR, "Please Enter Operator")
            bln = False
        End If

        If GRIDCOMPLAINT.RowCount = 0 Then
            Ep.SetError(CMBPROBLEMMASTER, "Please Enter Details")
            bln = False
        End If

        Return bln
    End Function

    Private Sub CMDSAVE_Click(sender As Object, e As EventArgs) Handles CMDSAVE.Click
        Dim IntResult As Integer
        Try
            Cursor.Current = Cursors.WaitCursor
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(CMBOPERATOR.Text.Trim)
            ALPARAVAL.Add(DTCOMPLAINTDATE.Value.Date)
            ALPARAVAL.Add(TXTREMARKS.Text.Trim)

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            ''GRID PARAMETER
            Dim SRNO As String = ""
            Dim PROBLEM As String = ""
            Dim REASON As String = ""
            Dim REMARKS As String = ""

            For Each ROW As Windows.Forms.DataGridViewRow In GRIDCOMPLAINT.Rows
                If ROW.Cells(0).Value <> Nothing Then


                    If SRNO = "" Then
                        SRNO = ROW.Cells(GSRNO.Index).Value
                        PROBLEM = ROW.Cells(GPROBLEMMASTER.Index).Value.ToString
                        REASON = ROW.Cells(GREASONMASTER.Index).Value.ToString
                        REMARKS = ROW.Cells(GREMARKS.Index).Value.ToString

                    Else
                        SRNO = SRNO & "|" & ROW.Cells(GSRNO.Index).Value
                        PROBLEM = PROBLEM & "|" & ROW.Cells(GPROBLEMMASTER.Index).Value.ToString
                        REASON = REASON & "|" & ROW.Cells(GREASONMASTER.Index).Value.ToString
                        REMARKS = REMARKS & "|" & ROW.Cells(GREMARKS.Index).Value.ToString

                    End If
                End If
            Next
            ALPARAVAL.Add(SRNO)
            ALPARAVAL.Add(PROBLEM)
            ALPARAVAL.Add(REASON)
            ALPARAVAL.Add(REMARKS)

            Dim OBJCOMPLAINT As New ClsComplaintMaster
            OBJCOMPLAINT.alParaval = ALPARAVAL


            If EDIT = False Then
                Dim DTTABLE As DataTable = OBJCOMPLAINT.SAVE()
                MsgBox("Details Added !!")
                TEMPCOMPLAINTNO = DTTABLE.Rows(0).Item(0)
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                ALPARAVAL.Add(TEMPCOMPLAINTNO)
                IntResult = OBJCOMPLAINT.UPDATE()
                MsgBox("Details Updated")
                EDIT = False
            End If
            CLEAR()
            CMBOPERATOR.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        GRIDCOMPLAINT.Enabled = True
        If GRIDDOUBLECLICK = False Then
            GRIDCOMPLAINT.Rows.Add(Val(TXTGRIDSRNO.Text.Trim), CMBPROBLEMMASTER.Text.Trim, CMBREASONMASTER.Text.Trim, TXTGRIDREMARKS.Text.Trim, 0, 0, 0)
            getsrno()
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDCOMPLAINT.Item(GSRNO.Index, TEMPROW).Value = Val(TXTCOMPLAINNO.Text)
            GRIDCOMPLAINT.Item(GPROBLEMMASTER.Index, TEMPROW).Value = CMBPROBLEMMASTER.Text
            GRIDCOMPLAINT.Item(GREASONMASTER.Index, TEMPROW).Value = CMBREASONMASTER.Text
            GRIDCOMPLAINT.Item(GREMARKS.Index, TEMPROW).Value = TXTGRIDREMARKS.Text

            GRIDDOUBLECLICK = False
        End If

        GRIDCOMPLAINT.FirstDisplayedScrollingRowIndex = GRIDCOMPLAINT.RowCount - 1

        CMBPROBLEMMASTER.Text = ""
        CMBREASONMASTER.Text = ""
        TXTGRIDREMARKS.Clear()
        TXTGRIDSRNO.Text = Val(GRIDCOMPLAINT.RowCount) + 1

        CMBPROBLEMMASTER.Focus()
    End Sub

    Private Sub CMBOPERATOR_Enter(sender As Object, e As EventArgs) Handles CMBOPERATOR.Enter
        Try
            If CMBOPERATOR.Text.Trim = "" Then fillOPERATOR(CMBOPERATOR)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOPERATOR_Validating(sender As Object, e As CancelEventArgs) Handles CMBOPERATOR.Validating
        Try
            If CMBOPERATOR.Text.Trim <> "" Then OPERATORVALIDATE(CMBOPERATOR, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPROBLEMMASTER_Enter(sender As Object, e As EventArgs) Handles CMBPROBLEMMASTER.Enter
        Try
            If CMBPROBLEMMASTER.Text.Trim = "" Then fillPROBLEM(CMBPROBLEMMASTER)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPROBLEMMASTER_Validating(sender As Object, e As CancelEventArgs) Handles CMBPROBLEMMASTER.Validating
        Try
            If CMBPROBLEMMASTER.Text.Trim <> "" Then PROBLEMVALIDATE(CMBPROBLEMMASTER, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(sender As Object, e As EventArgs) Handles CMDCLEAR.Click
        CLEAR()
        EDIT = False
        CMBOPERATOR.Focus()
    End Sub

    Private Sub CMBREASONMASTER_Enter(sender As Object, e As EventArgs) Handles CMBREASONMASTER.Enter
        Try
            If CMBREASONMASTER.Text.Trim = "" Then fillREASON(CMBREASONMASTER)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBREASONMASTER_Validating(sender As Object, e As CancelEventArgs) Handles CMBREASONMASTER.Validating
        Try
            If CMBREASONMASTER.Text.Trim <> "" Then REASONVALIDATE(CMBREASONMASTER, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGRIDREMARKS_Validating(sender As Object, e As CancelEventArgs) Handles TXTGRIDREMARKS.Validating
        Try
            If CMBPROBLEMMASTER.Text.Trim <> "" Then
                fillgrid()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCOMPLAINT_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDCOMPLAINT.CellDoubleClick
        Try

            GRIDDOUBLECLICK = True
            TXTGRIDSRNO.Text = GRIDCOMPLAINT.Item(GSRNO.Index, GRIDCOMPLAINT.CurrentRow.Index).Value

            CMBPROBLEMMASTER.Text = GRIDCOMPLAINT.Item(GPROBLEMMASTER.Index, GRIDCOMPLAINT.CurrentRow.Index).Value.ToString
            CMBREASONMASTER.Text = GRIDCOMPLAINT.Item(GREASONMASTER.Index, GRIDCOMPLAINT.CurrentRow.Index).Value.ToString
            TXTGRIDREMARKS.Text = GRIDCOMPLAINT.Item(GREMARKS.Index, GRIDCOMPLAINT.CurrentRow.Index).Value.ToString

            TEMPROW = GRIDCOMPLAINT.CurrentRow.Index
            CMBPROBLEMMASTER.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ComplaintMaster_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE INVOICE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            FILLCMB()
            CLEAR()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable
                Dim ALPARAVAL As New ArrayList
                Dim OBJCOMPLAINT As New ClsComplaintMaster

                ALPARAVAL.Add(TEMPCOMPLAINTNO)
                ALPARAVAL.Add(YearId)

                OBJCOMPLAINT.alParaval = ALPARAVAL
                DT = OBJCOMPLAINT.selectCOMPLAINT()


                If DT.Rows.Count > 0 Then
                    For Each DR As DataRow In DT.Rows

                        TXTCOMPLAINNO.Text = TEMPCOMPLAINTNO
                        DTCOMPLAINTDATE.Text = Format(Convert.ToDateTime(DR("DATE")).Date, "dd/MM/yyyy")
                        CMBOPERATOR.Text = Convert.ToString(DR("OPERATOR"))
                        TXTREMARKS.Text = Convert.ToString(DR("REMARKS"))

                        '' grid 
                        GRIDCOMPLAINT.Rows.Add(Val(DR("SRNO")), DR("PROBLEMNAME").ToString, DR("REASONNAME").ToString, DR("GRIDREMARKS"))

                    Next
                    GRIDCOMPLAINT.FirstDisplayedScrollingRowIndex = GRIDCOMPLAINT.RowCount - 1
                End If
                CMBOPERATOR.Focus()
                getsrno()
            Else
                EDIT = False
                CLEAR()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

    Sub FILLCMB()
        If CMBPROBLEMMASTER.Text.Trim = "" Then fillPROBLEM(CMBPROBLEMMASTER)
        If CMBREASONMASTER.Text.Trim = "" Then fillREASON(CMBREASONMASTER)
    End Sub

    Private Sub CMDDELETE_Click(sender As Object, e As EventArgs) Handles CMDDELETE.Click
        Try
            If EDIT = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If


                If MsgBox("Wish to Delete Complaint.?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If MsgBox("Are you Sure?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        Dim alParaval As New ArrayList
                        alParaval.Add(TXTCOMPLAINNO.Text.Trim)
                        alParaval.Add(YearId)
                        alParaval.Add(Userid)

                        Dim clsco As New ClsComplaintMaster()
                        clsco.alParaval = alParaval
                        Dim IntResult As Integer = clsco.delete()
                        MsgBox("Complaint Deleted")
                        CLEAR()
                        EDIT = False
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCOMPLAINT_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDCOMPLAINT.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDCOMPLAINT.Rows.RemoveAt(GRIDCOMPLAINT.CurrentRow.Index)
                getsrno()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(sender As Object, e As EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJGRN As New ComplaintMasterGridDetails
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(sender As Object, e As EventArgs) Handles toolprevious.Click
        Try
            GRIDCOMPLAINT.RowCount = 0
LINE1:
            TEMPCOMPLAINTNO = Val(TXTCOMPLAINNO.Text) - 1
            If TEMPCOMPLAINTNO > 0 Then
                EDIT = True
                ComplaintMaster_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If

            If GRIDCOMPLAINT.RowCount = 0 And TEMPCOMPLAINTNO > 1 Then
                TXTCOMPLAINNO.Text = TEMPCOMPLAINTNO
                GoTo LINE1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(sender As Object, e As EventArgs) Handles toolnext.Click
        Try
            GRIDCOMPLAINT.RowCount = 0
LINE1:
            TEMPCOMPLAINTNO = Val(TXTCOMPLAINNO.Text) + 1
            GETMAX_COMPLAIN_NO()
            Dim MAXNO As Integer = TXTCOMPLAINNO.Text.Trim
            CLEAR()
            If Val(TXTCOMPLAINNO.Text) - 1 >= TEMPCOMPLAINTNO Then
                EDIT = True
                ComplaintMaster_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDCOMPLAINT.RowCount = 0 And TEMPCOMPLAINTNO < MAXNO Then
                TXTCOMPLAINNO.Text = TEMPCOMPLAINTNO
                GoTo LINE1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBILLNO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTBILLNO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTBILLNO_Validated(sender As Object, e As EventArgs) Handles TXTBILLNO.Validated
        Try
            If TXTBILLNO.Text.Trim.Length = 0 Then Exit Sub
            GRIDCOMPLAINT.RowCount = 0
            TEMPCOMPLAINTNO = Val(TXTBILLNO.Text)
            If TEMPCOMPLAINTNO > 0 Then
                EDIT = True
                ComplaintMaster_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ComplaintMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then CMDSAVE_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.F8 Then
                GRIDCOMPLAINT.Focus()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                TXTBILLNO.Focus()
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call toolprevious_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call toolnext_Click(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class