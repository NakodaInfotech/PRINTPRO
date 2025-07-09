
Imports BL
Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel

Public Class Scheduling


    Dim USERADD, USEREDIT, USERVIEW, USERDELETE, GRIDSHIFTDOUBLECLICK As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim gridUPLOADDoubleClick As Boolean
    Dim temprow As Integer
    Dim TEMPSHIFTROW As Integer
    Public EDIT As Boolean
    Public TEMPSCHNO As Integer
    Dim EXPIRY As Boolean = False

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        edit = False
        TXTSCHEDULINGDONEBY.Focus()
    End Sub

    Sub CLEAR()

        TXTSCHNO.ReadOnly = True
        DTDATE.Text = Now.Date
        TXTSCHEDULINGDONEBY.Clear()
        GRIDSCH.RowCount = 0
        TXTREMARKS.Clear()
        CMBSCHEDULING.Text = ""
        GETMAX_NO()
        tstxtbillno.Clear()
        LBLTOTALJOBCARDQTY.Text = 0.0
        LBLTOTALPRINTEDQTY.Text = 0.0
        LBLTOTALREMAINIGQTY.Text = 0.0
        LBLTOTALSTOCK.Text = 0.0
        LBLTOTALORDER.Text = 0.0
        LBLTOTALBALANCE.Text = 0.0
        LBLTOTALPLATES.Text = 0.0
        EP.Clear()

    End Sub

    Sub GETMAX_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(SCH_NO),0) + 1 ", "SCHEDULING", "  AND SCH_cmpid=" & CmpId & " and SCH_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTSCHNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub Scheduling_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.F8 Then
                GRIDSCH.Focus()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1) Then       'for CLEAR
                TabControl1.SelectedIndex = (0)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2) Then       'for CLEAR
                TabControl1.SelectedIndex = (1)
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call toolprevious_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call toolnext_Click(sender, e)
            ElseIf e.KeyCode = Windows.Forms.Keys.F1 And e.Alt = True Then
                Call OpenToolStripButton_Click(sender, e)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Scheduling_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'SCHEDULING'")

            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            Cursor.Current = Cursors.WaitCursor

            CLEAR()

            CMBSCHEDULING.Text = "Printing"



            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJCMN As New ClsCommon
                Dim OBJCLSINCENTIVE As New ClsScheduling
                Dim dttable As New DataTable

                dttable = OBJCLSINCENTIVE.SELECTSCHEDULING(TEMPSCHNO, CmpId, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTSCHNO.Text = TEMPSCHNO
                        TXTSCHNO.ReadOnly = True
                        'DTDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        DTDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        TXTSCHEDULINGDONEBY.Text = dr("SCHEDULINGDONEBY")
                        TXTREMARKS.Text = dr("REMARKS")
                        CMBSCHEDULING.Text = dr("SCHEDULINGTYPE")
                        LBLTOTALJOBCARDQTY.Text = dr("TOTALJOBCARDQTY")
                        LBLTOTALPRINTEDQTY.Text = dr("TOTALPRINTEDQTY")
                        LBLTOTALREMAINIGQTY.Text = dr("TOTALREMAININGQTY")
                        LBLTOTALSTOCK.Text = dr("TOTALSTOCK")
                        LBLTOTALORDER.Text = dr("TOTALORDER")
                        LBLTOTALBALANCE.Text = dr("TOTALBALANCE")
                        LBLTOTALPLATES.Text = dr("TOTALPLATES")
                        LBLTOTALPLATES.Text = dr("TOTALWASTAGE")



                        GRIDSCH.Rows.Add(dr("GRIDSRNO").ToString, dr("JOBNO").ToString, dr("CLIENT").ToString, dr("JOBCARDQTY").ToString, dr("DATE").ToString, dr("STATUS").ToString, dr("PRINTEDQTY").ToString, dr("REMAININGQTY").ToString, dr("ITEMNAME").ToString, dr("CUTSHEET").ToString, dr("CUTSIZE").ToString, dr("FULLSHEET").ToString, dr("STOCK").ToString, dr("ORDERS").ToString, dr("BALANCE").ToString, dr("NONINVITEM").ToString, dr("COLOR1").ToString, dr("COLOR2").ToString, dr("COLOR1PLATES").ToString, dr("COLOR2PLATES").ToString, dr("COLOR1TYPE").ToString, dr("COLOR2TYPE").ToString, dr("MODE").ToString, dr("SIDE").ToString, dr("IMP").ToString, dr("FINALIMP").ToString, dr("READYTIME").ToString, dr("FINISHTIME").ToString, dr("REMARKS").ToString, dr("LAMINATIONDATE").ToString, dr("LAMINATIONSHEETS").ToString, dr("TOTALDONE").ToString, dr("TODO").ToString, dr("FILM").ToString, dr("WIDTH").ToString, dr("LENGTH").ToString, dr("DONE").ToString, dr("GSM").ToString, dr("MAKEREADY").ToString, dr("WASTAGE").ToString)

                        If dr("JOBDOCKETDONE") = 1 Then
                            'lbllocked.Visible = True
                            GRIDSCH.Rows(GRIDSCH.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                        End If
                    Next

                    GRIDSCH.FirstDisplayedScrollingRowIndex = GRIDSCH.RowCount - 1
                    CMDSELECTJOBDOCKET.Enabled = True
                Else
                    TOTAL()
                    edit = False
                    CLEAR()
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try
            If ISLOCKYEAR = True Then
                MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If


            Dim IntResult As Integer
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList
            alParaval.Add(Val(TXTSCHNO.Text.Trim))

            alParaval.Add(Format(Convert.ToDateTime(DTDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(TXTSCHEDULINGDONEBY.Text.Trim)
            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(CMBSCHEDULING.Text.Trim)
            alParaval.Add(Val(LBLTOTALJOBCARDQTY.Text.Trim))
            alParaval.Add(Val(LBLTOTALPRINTEDQTY.Text.Trim))
            alParaval.Add(Val(LBLTOTALREMAINIGQTY.Text.Trim))
            alParaval.Add(Val(LBLTOTALSTOCK.Text.Trim))
            alParaval.Add(Val(LBLTOTALORDER.Text.Trim))
            alParaval.Add(Val(LBLTOTALBALANCE.Text.Trim))
            alParaval.Add(Val(LBLTOTALPLATES.Text.Trim))
            alParaval.Add(Val(LBLTOTALWASTAGE.Text.Trim))
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            ' GRID PARAMETERS
            Dim GRIDSRNO As String = ""
            Dim JOBNO As String = ""
            Dim CLIENT As String = ""
            Dim JOBCARDQTY As String = ""
            Dim SCHDATE As String = ""
            Dim STATUS As String = ""
            Dim PRINTEDQTY As String = ""
            Dim REMAININGQTY As String = ""
            Dim JOBDESC As String = ""
            Dim CUTSHEET As String = ""
            Dim CUTSIZE As String = ""
            Dim FULLSHEET As String = ""
            Dim STOCK As String = ""
            Dim ORDER As String = ""
            Dim BALANCE As String = ""
            Dim GSMPAPERSIZE As String = ""
            Dim COLOR1 As String = ""
            Dim COLOR2 As String = ""
            Dim COLOR1PLATES As String = ""
            Dim COLOR2PLATES As String = ""
            Dim COLOR1TYPE As String = ""
            Dim COLOR2TYPE As String = ""
            Dim MODE As String = ""
            Dim PLATES As String = ""
            Dim PLATETYPE As String = ""
            Dim SIDE As String = ""
            Dim IMP As String = ""
            Dim FINALIMP As String = ""
            Dim READYTIME As String = ""
            Dim FINISHTIME As String = ""
            Dim REMARK As String = ""
            Dim LAMINATIONDATE As String = ""
            Dim LAMINATIONSHEETS As String = ""
            Dim TOTALDONE As String = ""
            Dim TODO As String = ""
            Dim FLIM As String = ""
            Dim WIDTH As String = ""
            Dim LENGTH As String = ""
            Dim DONE As String = ""
            Dim GSM As String = ""
            Dim MAKEREADY As String = ""
            Dim WASTAGE As String = ""




            For Each ROW As Windows.Forms.DataGridViewRow In GRIDSCH.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(ROW.Cells(GSRNO.Index).Value)
                        JOBNO = Val(ROW.Cells(GJOBNO.Index).Value)
                        CLIENT = ROW.Cells(GCLIENT.Index).Value.ToString
                        JOBCARDQTY = Val(ROW.Cells(GJOBCARDQTY.Index).Value)
                        SCHDATE = Format(Convert.ToDateTime(ROW.Cells(GSCHDATE.Index).Value).Date, "MM/dd/yyyy")
                        STATUS = ROW.Cells(GSTATUS.Index).Value.ToString
                        PRINTEDQTY = Val(ROW.Cells(GPRINTEDQTY.Index).Value)
                        REMAININGQTY = Val(ROW.Cells(GREMAINIGQTY.Index).Value)
                        JOBDESC = ROW.Cells(GJOBDESC.Index).Value.ToString
                        CUTSHEET = Val(ROW.Cells(GCUTSHEET.Index).Value)
                        CUTSIZE = ROW.Cells(GCUTSIZE.Index).Value.ToString
                        FULLSHEET = Val(ROW.Cells(GFULLSHEET.Index).Value)
                        STOCK = ROW.Cells(GSTOCK.Index).Value.ToString
                        ORDER = Val(ROW.Cells(GORDER.Index).Value)
                        BALANCE = Val(ROW.Cells(GBALANCE.Index).Value)
                        GSMPAPERSIZE = ROW.Cells(GGSMPAPERSIZE.Index).Value.ToString
                        COLOR1 = ROW.Cells(GCOLOR1.Index).Value.ToString
                        COLOR2 = ROW.Cells(GCOLOR2.Index).Value.ToString
                        COLOR1PLATES = ROW.Cells(GCOLOR1PLATES.Index).Value.ToString
                        COLOR2PLATES = ROW.Cells(GCOLOR1PLATES.Index).Value.ToString
                        COLOR1TYPE = ROW.Cells(GCOLOR1TYPE.Index).Value.ToString
                        COLOR2TYPE = ROW.Cells(GCOLOR2TYPE.Index).Value.ToString
                        MODE = ROW.Cells(GMODE.Index).Value.ToString
                        SIDE = Val(ROW.Cells(GSIDE.Index).Value)
                        IMP = Val(ROW.Cells(GIMP.Index).Value)
                        FINALIMP = ROW.Cells(GFINALIMP.Index).Value.ToString
                        READYTIME = ROW.Cells(GREADYTIME.Index).Value.ToString
                        FINISHTIME = ROW.Cells(GFINISHTIME.Index).Value.ToString
                        REMARK = ROW.Cells(GREMARK.Index).Value.ToString
                        LAMINATIONDATE = ROW.Cells(GLAMINATIONDATE.Index).Value.ToString
                        LAMINATIONSHEETS = Val(ROW.Cells(GLAMINATIONSHEETS.Index).Value)
                        TOTALDONE = Val(ROW.Cells(GTOTALDONE.Index).Value)
                        TODO = Val(ROW.Cells(GTODO.Index).Value)
                        FLIM = ROW.Cells(GFLIM.Index).Value.ToString
                        WIDTH = Val(ROW.Cells(GWIDTH.Index).Value)
                        LENGTH = Val(ROW.Cells(GLENGTH.Index).Value)
                        DONE = Val(ROW.Cells(GDONE.Index).Value)
                        GSM = Val(ROW.Cells(GGSM.Index).Value)
                        MAKEREADY = Val(ROW.Cells(GMAKEREADY.Index).Value)
                        WASTAGE = Val(ROW.Cells(GWASTAGE.Index).Value)
                    Else

                        GRIDSRNO = GRIDSRNO & "|" & Val(ROW.Cells(GSRNO.Index).Value)
                        JOBNO = JOBNO & "|" & Val(ROW.Cells(GJOBNO.Index).Value)
                        CLIENT = CLIENT & "|" & ROW.Cells(GCLIENT.Index).Value.ToString
                        JOBCARDQTY = JOBCARDQTY & "|" & Val(ROW.Cells(GJOBCARDQTY.Index).Value)
                        SCHDATE = SCHDATE & "|" & Format(Convert.ToDateTime(ROW.Cells(GSCHDATE.Index).Value).Date, "MM/dd/yyyy")
                        STATUS = STATUS & "|" & ROW.Cells(GSTATUS.Index).Value.ToString
                        PRINTEDQTY = PRINTEDQTY & "|" & Val(ROW.Cells(GPRINTEDQTY.Index).Value)
                        REMAININGQTY = REMAININGQTY & "|" & Val(ROW.Cells(GREMAINIGQTY.Index).Value)
                        JOBDESC = JOBDESC & "|" & ROW.Cells(GJOBDESC.Index).Value.ToString
                        CUTSHEET = CUTSHEET & "|" & Val(ROW.Cells(GCUTSHEET.Index).Value)
                        CUTSIZE = CUTSIZE & "|" & ROW.Cells(GCUTSIZE.Index).Value.ToString
                        FULLSHEET = FULLSHEET & "|" & Val(ROW.Cells(GFULLSHEET.Index).Value)
                        STOCK = STOCK & "|" & Val(ROW.Cells(GSTOCK.Index).Value)
                        ORDER = ORDER & "|" & Val(ROW.Cells(GORDER.Index).Value)
                        BALANCE = BALANCE & "|" & Val(ROW.Cells(GBALANCE.Index).Value)
                        GSMPAPERSIZE = GSMPAPERSIZE & "|" & ROW.Cells(GGSMPAPERSIZE.Index).Value.ToString
                        COLOR1 = COLOR1 & "|" & ROW.Cells(GCOLOR1.Index).Value.ToString
                        COLOR2 = COLOR2 & "|" & ROW.Cells(GCOLOR2.Index).Value.ToString
                        COLOR1PLATES = COLOR1PLATES & "|" & ROW.Cells(GCOLOR1PLATES.Index).Value.ToString
                        COLOR2PLATES = COLOR2PLATES & "|" & ROW.Cells(GCOLOR2PLATES.Index).Value.ToString
                        COLOR1TYPE = COLOR1TYPE & "|" & ROW.Cells(GCOLOR1TYPE.Index).Value.ToString
                        COLOR2TYPE = COLOR2TYPE & "|" & ROW.Cells(GCOLOR2TYPE.Index).Value.ToString
                        MODE = MODE & "|" & ROW.Cells(GMODE.Index).Value.ToString
                        SIDE = SIDE & "|" & Val(ROW.Cells(GSIDE.Index).Value)
                        IMP = IMP & "|" & Val(ROW.Cells(GIMP.Index).Value)
                        FINALIMP = FINALIMP & "|" & ROW.Cells(GFINALIMP.Index).Value.ToString
                        READYTIME = READYTIME & "|" & ROW.Cells(GREADYTIME.Index).Value.ToString
                        FINISHTIME = FINISHTIME & "|" & ROW.Cells(GFINISHTIME.Index).Value.ToString
                        REMARK = REMARK & "|" & ROW.Cells(GREMARK.Index).Value.ToString
                        LAMINATIONDATE = LAMINATIONDATE & "|" & ROW.Cells(GLAMINATIONDATE.Index).Value.ToString
                        LAMINATIONSHEETS = LAMINATIONSHEETS & "|" & Val(ROW.Cells(GLAMINATIONSHEETS.Index).Value)
                        TOTALDONE = TOTALDONE & "|" & Val(ROW.Cells(GTOTALDONE.Index).Value)
                        TODO = TODO & "|" & Val(ROW.Cells(GTODO.Index).Value)
                        FLIM = FLIM & "|" & ROW.Cells(GFLIM.Index).Value.ToString
                        WIDTH = WIDTH & "|" & Val(ROW.Cells(GWIDTH.Index).Value)
                        LENGTH = LENGTH & "|" & Val(ROW.Cells(GLENGTH.Index).Value)
                        DONE = DONE & "|" & Val(ROW.Cells(GDONE.Index).Value)
                        GSM = GSM & "|" & Val(ROW.Cells(GGSM.Index).Value)
                        MAKEREADY = MAKEREADY & "|" & Val(ROW.Cells(GMAKEREADY.Index).Value)
                        WASTAGE = WASTAGE & "|" & Val(ROW.Cells(GWASTAGE.Index).Value)



                    End If
                End If
            Next
            alParaval.Add(GRIDSRNO)
            alParaval.Add(JOBNO)
            alParaval.Add(CLIENT)
            alParaval.Add(JOBCARDQTY)
            alParaval.Add(SCHDATE)
            alParaval.Add(STATUS)
            alParaval.Add(PRINTEDQTY)
            alParaval.Add(REMAININGQTY)
            alParaval.Add(JOBDESC)
            alParaval.Add(CUTSHEET)
            alParaval.Add(CUTSIZE)
            alParaval.Add(FULLSHEET)
            alParaval.Add(STOCK)
            alParaval.Add(ORDER)
            alParaval.Add(BALANCE)
            alParaval.Add(GSMPAPERSIZE)
            alParaval.Add(COLOR1)
            alParaval.Add(COLOR2)
            alParaval.Add(COLOR1PLATES)
            alParaval.Add(COLOR2PLATES)
            alParaval.Add(COLOR1TYPE)
            alParaval.Add(COLOR2TYPE)
            alParaval.Add(MODE)
            alParaval.Add(SIDE)
            alParaval.Add(IMP)
            alParaval.Add(FINALIMP)
            alParaval.Add(READYTIME)
            alParaval.Add(FINISHTIME)
            alParaval.Add(REMARK)
            alParaval.Add(LAMINATIONDATE)
            alParaval.Add(LAMINATIONSHEETS)
            alParaval.Add(TOTALDONE)
            alParaval.Add(TODO)
            alParaval.Add(FLIM)
            alParaval.Add(WIDTH)
            alParaval.Add(LENGTH)
            alParaval.Add(DONE)
            alParaval.Add(GSM)
            alParaval.Add(MAKEREADY)
            alParaval.Add(WASTAGE)


            Dim objclsPurord As New ClsScheduling()
            objclsPurord.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = objclsPurord.SAVE()
                MessageBox.Show("Details Added")
                TEMPSCHNO = DT.Rows(0).Item(0)

            Else


                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPSCHNO)
                IntResult = objclsPurord.UPDATE()
                MessageBox.Show("Details Updated")
                edit = False
            End If

            If MsgBox("Wish to Print Scheduling?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then PRINTREPORT(TEMPSCHNO)


            CLEAR()
            TXTSCHEDULINGDONEBY.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True


        If DTDATE.Text = "__/__/____" Then
            EP.SetError(DTDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(DTDATE.Text) Then
                EP.SetError(DTDATE, "Date Not In Accounting Year")
                bln = False
            End If
        End If

        If GRIDSCH.RowCount = 0 Then
            EP.SetError(GRIDSCH, " Please Enter Proper Details ")
            bln = False
        End If
        If CMBSCHEDULING.Text.Trim.Length = 0 Then
            EP.SetError(CMBSCHEDULING, " Please Fill Scheduling Type ")
            bln = False
        End If

        Return bln
    End Function

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDSCH.RowCount = 0
LINE1:
            TEMPSCHNO = Val(TXTSCHNO.Text) - 1
            If TEMPSCHNO > 0 Then
                edit = True
                Scheduling_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If

            If GRIDSCH.RowCount = 0 And TEMPSCHNO > 1 Then
                TXTSCHNO.Text = TEMPSCHNO
                GoTo LINE1
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDSCH.RowCount = 0
LINE1:
            TEMPSCHNO = Val(TXTSCHNO.Text) + 1
            GETMAX_NO()
            Dim MAXNO As Integer = TXTSCHNO.Text.Trim
            CLEAR()
            If Val(TXTSCHNO.Text) - 1 >= TEMPSCHNO Then
                edit = True
                Scheduling_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If
            If GRIDSCH.RowCount = 0 And TEMPSCHNO < MAXNO Then
                TXTSCHNO.Text = TEMPSCHNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstxtbillno.Validated
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDSCH.RowCount = 0
            TEMPSCHNO = Val(tstxtbillno.Text)
            If TEMPSCHNO > 0 Then
                edit = True
                Scheduling_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJGRN As New SchedulingDetails
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub


    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Unable To Delete", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Wish To Delete Scheduling.?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If MsgBox("Are you Sure?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        Dim alParaval As New ArrayList
                        alParaval.Add(TXTSCHNO.Text.Trim)
                        alParaval.Add(YearId)
                        alParaval.Add(Userid)

                        Dim clspo As New ClsScheduling()
                        clspo.alParaval = alParaval
                        Dim IntResult As Integer = clspo.Delete()
                        MsgBox("Scheduling Deleted")
                        CLEAR()
                        edit = False
                    End If
                End If

            End If

        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Private Sub GRIDSCH_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDSCH.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSCH.RowCount > 0 Then
                If gridDoubleClick = True Then
                    MessageBox.Show("Row Is In Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDSCH.Rows.RemoveAt(GRIDSCH.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDSCH)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then PRINTREPORT(TEMPSCHNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal SCHNO As Integer)
        Try
            ' If MsgBox("Print Scheduling Report?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim OBJRPT As New clsReportDesigner("SCHEDULING", System.AppDomain.CurrentDomain.BaseDirectory & "SCHEDULING.xlsx", 2)
            OBJRPT.SCHEDULING_EXCEL(TEMPSCHNO, CmpId, YearId)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTORDER_Click(sender As Object, e As EventArgs) Handles CMDSELECTJOBDOCKET.Click
        Try
            EP.Clear()
            If CMBSCHEDULING.Text.Trim = "" Then
                MsgBox("Please Fill Scheduling Type", MsgBoxStyle.Critical)
                CMBSCHEDULING.Focus()
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor
            Dim SIDE As Integer
            Dim IMP As Integer
            Dim OBJSO As New SelectJobDocket
            OBJSO.FRMSTRING = "SCHEDULING"
            OBJSO.SCHEDULINGTYPE = CMBSCHEDULING.Text.Trim
            Dim DT As DataTable = OBJSO.DT
            OBJSO.ShowDialog()

            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    If DTROW("MODE") = "F" Or DTROW("MODE") = "B" Then
                        SIDE = 1
                        IMP = DTROW("TOTALCUTSHEET") * SIDE
                    Else
                        SIDE = 2
                        IMP = Format(Val(DTROW("TOTALCUTSHEET") * SIDE), "0.00")
                    End If

                    If CMBSCHEDULING.Text = "Lamination (THERMAL)" Or CMBSCHEDULING.Text = "Lamination (COLD)" Then
                        GRIDSCH.Rows.Add(0, Val(DTROW("JOBDOCKETNO")), DTROW("NAME"), DTROW("QTY"), DTROW("JOBDOCKETDATE"), "", DTROW("PRODUCTIONDONE"), DTROW("REMAININGSHEETS"), DTROW("ITEMNAME"), DTROW("TOTALCUTSHEET"), "", DTROW("FULLSHEET"), 0, 0, 0, DTROW("PAPERNAME"), "", "", "", "", "", "", DTROW("MODE"), Val(SIDE), Val(IMP), "", "", "", "", "", DTROW("SHEETS"), 0, 0, DTROW("FILM"), DTROW("WIDTH"), DTROW("LENGTH1"), 0, 0, 0, 0)
                    ElseIf CMBSCHEDULING.Text = "Punching" Then
                        GRIDSCH.Rows.Add(0, Val(DTROW("JOBDOCKETNO")), DTROW("NAME"), DTROW("QTY"), DTROW("JOBDOCKETDATE"), "", DTROW("PRODUCTIONDONE"), DTROW("REMAININGSHEETS"), DTROW("ITEMNAME"), DTROW("TOTALCUTSHEET"), "", DTROW("FULLSHEET"), 0, 0, 0, DTROW("PAPERNAME"), "", "", "", "", "", "", "", 0, 0, "", "", "", "", "", DTROW("SHEETS"), 0, 0, "", 0, 0, 0, 0, 0, 0)
                    ElseIf CMBSCHEDULING.Text = "Folding" Then
                        GRIDSCH.Rows.Add(0, Val(DTROW("JOBDOCKETNO")), DTROW("NAME"), DTROW("QTY"), DTROW("JOBDOCKETDATE"), "", DTROW("PRODUCTIONDONE"), DTROW("REMAININGSHEETS"), DTROW("ITEMNAME"), DTROW("TOTALCUTSHEET"), "", DTROW("FULLSHEET"), 0, 0, 0, DTROW("PAPERNAME"), "", "", "", "", "", "", "", 0, 0, "", "", "", "", "", 0, 0, 0, "", 0, 0, 0, 0, 0, 0)
                    Else
                        GRIDSCH.Rows.Add(0, Val(DTROW("JOBDOCKETNO")), DTROW("NAME"), DTROW("QTY"), DTROW("JOBDOCKETDATE"), "", DTROW("PRODUCTIONDONE"), Val(DTROW("REMAININGSHEETS")), DTROW("ITEMNAME"), DTROW("TOTALCUTSHEET"), DTROW("CUTSIZE"), DTROW("FULLSHEET"), 0, 0, 0, DTROW("PAPERNAME"), DTROW("COLOR1"), DTROW("COLOR2"), DTROW("COLOR1PLATES"), DTROW("COLOR2PLATES"), DTROW("COLOR1TYPE"), DTROW("COLOR2TYPE"), DTROW("MODE"), Val(SIDE), Val(IMP), "", "", "", "", "", 0, 0, 0, "", 0, 0, 0, 0, 0, 0)
                    End If
                Next
            End If


            TOTAL()
            getsrno(GRIDSCH)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(sender As Object, e As CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                'GRIDSHIFT.RowCount = 0
                TEMPSCHNO = Val(tstxtbillno.Text)
                If TEMPSCHNO > 0 Then
                    EDIT = True
                    Scheduling_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    Private Sub GRIDSCH_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GRIDSCH.CellValidating
        Dim colNum As Integer = GRIDSCH.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
        Select Case colNum

            Case GJOBCARDQTY.Index
            Case GPRINTEDQTY.Index
            Case GREMAINIGQTY.Index
            Case GSTOCK.Index
            Case GORDER.Index
            Case GBALANCE.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If GRIDSCH.CurrentCell.Value = Nothing Then GRIDSCH.CurrentCell.Value = "0.00"
                    GRIDSCH.CurrentCell.Value = Convert.ToDecimal(GRIDSCH.Item(colNum, e.RowIndex).Value)

                    TOTAL()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                    'Exit Sub
                End If


        End Select
    End Sub

    Sub TOTAL()
        Try
            LBLTOTALJOBCARDQTY.Text = 0.0
            LBLTOTALPRINTEDQTY.Text = 0.0
            LBLTOTALREMAINIGQTY.Text = 0.0
            LBLTOTALSTOCK.Text = 0.0
            LBLTOTALORDER.Text = 0.0
            LBLTOTALBALANCE.Text = 0.0
            LBLTOTALPLATES.Text = 0.0
            LBLTOTALWASTAGE.Text = 0.0



            For Each ROW As DataGridViewRow In GRIDSCH.Rows
                ROW.Cells(GBALANCE.Index).Value = Format(Val(ROW.Cells(GSTOCK.Index).EditedFormattedValue) - Val(ROW.Cells(GORDER.Index).EditedFormattedValue), "0.00")
                If Val(ROW.Cells(GJOBCARDQTY.Index).EditedFormattedValue) > 0 Then LBLTOTALJOBCARDQTY.Text = Format(Val(LBLTOTALJOBCARDQTY.Text) + Val(ROW.Cells(GJOBCARDQTY.Index).EditedFormattedValue), "0.00")
                If Val(ROW.Cells(GPRINTEDQTY.Index).EditedFormattedValue) > 0 Then LBLTOTALPRINTEDQTY.Text = Format(Val(LBLTOTALPRINTEDQTY.Text) + Val(ROW.Cells(GPRINTEDQTY.Index).EditedFormattedValue), "0.00")
                If Val(ROW.Cells(GREMAINIGQTY.Index).EditedFormattedValue) > 0 Then LBLTOTALREMAINIGQTY.Text = Format(Val(LBLTOTALREMAINIGQTY.Text) + Val(ROW.Cells(GREMAINIGQTY.Index).EditedFormattedValue), "0.00")
                If Val(ROW.Cells(GSTOCK.Index).EditedFormattedValue) > 0 Then LBLTOTALSTOCK.Text = Format(Val(LBLTOTALSTOCK.Text) + Val(ROW.Cells(GSTOCK.Index).EditedFormattedValue), "0.00")
                If Val(ROW.Cells(GORDER.Index).EditedFormattedValue) > 0 Then LBLTOTALORDER.Text = Format(Val(LBLTOTALORDER.Text) + Val(ROW.Cells(GORDER.Index).EditedFormattedValue), "0.00")
                If Val(ROW.Cells(GBALANCE.Index).EditedFormattedValue) > 0 Then LBLTOTALBALANCE.Text = Format(Val(LBLTOTALBALANCE.Text) + Val(ROW.Cells(GBALANCE.Index).EditedFormattedValue), "0.00")
                If Val(ROW.Cells(GWASTAGE.Index).EditedFormattedValue) > 0 Then LBLTOTALWASTAGE.Text = Format(Val(LBLTOTALWASTAGE.Text) + Val(ROW.Cells(GWASTAGE.Index).EditedFormattedValue), "0.00")

            Next


        Catch ex As Exception
            Throw ex
        End Try
    End Sub



End Class