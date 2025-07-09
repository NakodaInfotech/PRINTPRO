

Imports BL
    Imports System.Windows.Forms
    Imports System.IO
    Imports System.ComponentModel

Public Class JobOut

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE, GRIDSHIFTDOUBLECLICK As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Dim GRIDUPLOADDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public EDIT As Boolean
    Public TEMPJONO As Integer

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        EDIT = False
    End Sub

    Sub CLEAR()
        GRIDDOUBLECLICK = False
        GRIDUPLOADDOUBLECLICK = False
        TXTJONO.ReadOnly = True
        DTDATE.Text = Now.Date
        GRIDJO.RowCount = 0
        GETMAX_NO()
        GETMAX_CHNO()
        tstxtbillno.Clear()
        TXTJOBDOCKETNO.Clear()
        TXTPARTYNAME.Clear()
        TXTBOMITEMCODE.Clear()
        TXTMAINITEM.Clear()
        TXTQTY.Clear()
        TXTSIZE.Clear()
        CMBJOBBERNAME.Text = ""
        CMBPROCESS.Text = ""
        TXTORDERTYPE.Clear()
        CMBGODOWN.Text = ""
        CMBTRANSPORT.Text = ""
        TXTREMARKS.Clear()
        LBLTOTALWT.Text = 0.0
        LBLTOTALAMOUNT.Text = 0.0
        EP.Clear()
        LBLTOTALQTY.Text = 0.0
        CMDSELECTSTOCK.Enabled = True
        CMDSELECTJOBDOCKET.Enabled = True
        TXTMOBILENO.Clear()
        TXTVEHICLENO.Clear()
    End Sub

    Sub GETMAX_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(JO_NO),0) + 1 ", "JOBOUT", "  AND JO_cmpid=" & CmpId & " and JO_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTJONO.Text = DTTABLE.Rows(0).Item(0)
    End Sub
    Sub GETMAX_CHNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(JO_CHALLANNO),0) + 1 ", "JOBOUT", "  AND JO_cmpid=" & CmpId & " and JO_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTCHALLANNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub JobOut_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.F8 Then
                GRIDJO.Focus()
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

    Sub FILLCMB()
        If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        If CMBJOBBERNAME.Text.Trim = "" Then fillname(CMBJOBBERNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        If CMBTRANSPORT.Text.Trim = "" Then fillname(CMBTRANSPORT, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'TRANSPORT' ")
    End Sub

    Private Sub JobOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'JOBOUT'")

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

                Dim OBJCMN As New ClsCommon
                Dim OBJCLSINCENTIVE As New ClsJobOut
                Dim dttable As New DataTable

                dttable = OBJCLSINCENTIVE.SELECTJOBOUT(TEMPJONO, CmpId, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTJONO.Text = TEMPJONO
                        TXTJONO.ReadOnly = True
                        DTDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        CMBPROCESS.Text = Convert.ToString(dr("PROCESS").ToString)
                        CMBJOBBERNAME.Text = Convert.ToString(dr("JOBBERNAME").ToString)
                        CMBTRANSPORT.Text = dr("TRANSPORT").ToString
                        TXTJOBDOCKETNO.Text = dr("JOBDOCKETNO").ToString
                        TXTPARTYNAME.Text = Convert.ToString(dr("PARTYNAME").ToString)
                        TXTBOMITEMCODE.Text = Convert.ToString(dr("BOMITEMCODE"))
                        TXTMAINITEM.Text = Convert.ToString(dr("MAINITEM"))
                        TXTQTY.Text = Format(Val(dr("QTY")))
                        TXTCHALLANNO.Text = dr("CHALLANNO")
                        TXTMOBILENO.Text = dr("MOBILENO")
                        TXTORDERTYPE.Text = dr("ORDERTYPE")
                        TXTVEHICLENO.Text = dr("VEHICLENO")
                        LBLTOTALQTY.Text = Val(dr("TOTALQTY"))
                        LBLTOTALWT.Text = Val(dr("TOTALWT"))
                        LBLTOTALAMOUNT.Text = Val(dr("TOTALAMOUNT"))
                        TXTREMARKS.Text = dr("REMARKS")
                        TXTSIZE.Text = dr("JOSIZE")

                        GRIDJO.Rows.Add(dr("GRIDSRNO").ToString, dr("ITEM").ToString, dr("PAPERGSM").ToString, dr("LOTNO").ToString, dr("UNIT").ToString, Format(dr("GQTY"), "0.00"), Format(dr("WT"), "0.00"), Val(dr("RATE")), Format(Val(dr("AMOUNT")), "0.00"), dr("FROMNO"), dr("FROMSRNO"), dr("FROMTYPE"), Format(dr("OUTQTY"), "0.00"), dr("JODONE"))

                        If Val(dr("JODONE")) = True Then
                            GRIDJO.Rows(GRIDJO.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next

                    GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1
                    CMDSELECTJOBDOCKET.Enabled = True
                Else
                    EDIT = False
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
        If ISLOCKYEAR = True Then
            MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Try

            Cursor.Current = Cursors.WaitCursor

            Dim IntResult As Integer
            EP.Clear()

            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList
            If TXTJONO.ReadOnly = False Then
                alParaval.Add(Val(TXTJONO.Text.Trim))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Format(Convert.ToDateTime(DTDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(CMBPROCESS.Text.Trim)
            alParaval.Add(CMBJOBBERNAME.Text.Trim)
            alParaval.Add(CMBTRANSPORT.Text.Trim)
            alParaval.Add(TXTJOBDOCKETNO.Text.Trim)
            alParaval.Add(TXTPARTYNAME.Text.Trim)
            alParaval.Add(TXTBOMITEMCODE.Text.Trim)
            alParaval.Add(TXTMAINITEM.Text.Trim)
            alParaval.Add(Val(TXTQTY.Text.Trim))
            alParaval.Add(TXTCHALLANNO.Text.Trim)
            alParaval.Add(TXTMOBILENO.Text.Trim)
            alParaval.Add(TXTORDERTYPE.Text.Trim)
            alParaval.Add(TXTVEHICLENO.Text.Trim)
            alParaval.Add(Val(LBLTOTALQTY.Text))
            alParaval.Add(Val(LBLTOTALWT.Text))
            alParaval.Add(Val(LBLTOTALAMOUNT.Text))
            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(TXTSIZE.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            ' GRID PARAMETERS
            Dim GRIDSRNO As String = ""
            Dim ITEM As String = ""
            Dim PAPERGSM As String = ""
            Dim LOTNO As String = ""
            Dim UNIT As String = ""
            Dim QTY As String = ""
            Dim WT As String = ""
            Dim RATE As String = ""
            Dim AMOUNT As String = ""
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""
            Dim OUTQTY As String = ""
            Dim JODONE As String = ""

            For Each ROW As Windows.Forms.DataGridViewRow In GRIDJO.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(ROW.Cells(GSRNO.Index).Value)
                        ITEM = ROW.Cells(GITEM.Index).Value.ToString
                        PAPERGSM = ROW.Cells(GPAPERGSM.Index).Value.ToString
                        LOTNO = ROW.Cells(GLOTNO.Index).Value.ToString
                        UNIT = ROW.Cells(GUNIT.Index).Value.ToString
                        QTY = Val(ROW.Cells(GQTY.Index).Value)
                        WT = Val(ROW.Cells(GWT.Index).Value)
                        RATE = Val(ROW.Cells(GRATE.Index).Value)
                        AMOUNT = Val(ROW.Cells(GAMOUNT.Index).Value)
                        FROMNO = Val(ROW.Cells(GFROMNO.Index).Value)
                        FROMSRNO = Val(ROW.Cells(GFROMSRNO.Index).Value)
                        FROMTYPE = ROW.Cells(GFROMTYPE.Index).Value.ToString
                        OUTQTY = Val(ROW.Cells(GOUTQTY.Index).Value)
                        JODONE = ROW.Cells(GJODONE.Index).Value

                    Else

                        GRIDSRNO = GRIDSRNO & "|" & Val(ROW.Cells(GSRNO.Index).Value)
                        ITEM = ITEM & "|" & ROW.Cells(GITEM.Index).Value.ToString
                        PAPERGSM = PAPERGSM & "|" & ROW.Cells(GPAPERGSM.Index).Value.ToString
                        LOTNO = LOTNO & "|" & ROW.Cells(GLOTNO.Index).Value.ToString
                        UNIT = UNIT & "|" & ROW.Cells(GUNIT.Index).Value.ToString
                        QTY = QTY & "|" & Val(ROW.Cells(GQTY.Index).Value)
                        WT = WT & "|" & Val(ROW.Cells(GWT.Index).Value)
                        RATE = RATE & "|" & Val(ROW.Cells(GRATE.Index).Value)
                        AMOUNT = AMOUNT & "|" & Val(ROW.Cells(GAMOUNT.Index).Value)
                        FROMNO = FROMNO & "|" & Val(ROW.Cells(GFROMNO.Index).Value)
                        FROMSRNO = FROMSRNO & "|" & Val(ROW.Cells(GFROMSRNO.Index).Value)
                        FROMTYPE = FROMTYPE & "|" & ROW.Cells(GFROMTYPE.Index).Value.ToString
                        OUTQTY = OUTQTY & "|" & Val(ROW.Cells(GOUTQTY.Index).Value)
                        JODONE = JODONE & "|" & ROW.Cells(GJODONE.Index).Value

                    End If
                End If
            Next
            alParaval.Add(GRIDSRNO)
            alParaval.Add(ITEM)
            alParaval.Add(PAPERGSM)
            alParaval.Add(LOTNO)
            alParaval.Add(UNIT)
            alParaval.Add(QTY)
            alParaval.Add(WT)
            alParaval.Add(RATE)
            alParaval.Add(AMOUNT)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(FROMTYPE)
            alParaval.Add(OUTQTY)
            alParaval.Add(JODONE)

            Dim objclsPurord As New ClsJobOut()
            objclsPurord.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = objclsPurord.SAVE()
                MessageBox.Show("Details Added")
                TEMPJONO = DT.Rows(0).Item(0)
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPJONO)
                IntResult = objclsPurord.UPDATE()
                MessageBox.Show("Details Updated")
                EDIT = False
            End If
            TXTPARTYNAME.Focus()
            CLEAR()
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
                EP.SetError(DTDATE, "Date not in Accounting Year")
                bln = False
            End If
        End If

        If GRIDJO.RowCount = 0 Then
            EP.SetError(GRIDJO, " Please Enter Proper Details ")
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

    Private Sub CMBGODOWN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDJO.RowCount = 0
LINE1:
            TEMPJONO = Val(TXTJONO.Text) - 1
            If TEMPJONO > 0 Then
                EDIT = True
                JobOut_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If

            If GRIDJO.RowCount = 0 And TEMPJONO > 1 Then
                TXTJONO.Text = TEMPJONO
                GoTo LINE1
            End If
            CMDSELECTSTOCK.Enabled = False
            CMDSELECTJOBDOCKET.Enabled = False
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDJO.RowCount = 0
LINE1:
            TEMPJONO = Val(TXTJONO.Text) + 1
            GETMAX_NO()
            Dim MAXNO As Integer = TXTJONO.Text.Trim
            CLEAR()
            If Val(TXTJONO.Text) - 1 >= TEMPJONO Then
                EDIT = True
                JobOut_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDJO.RowCount = 0 And TEMPJONO < MAXNO Then
                TXTJONO.Text = TEMPJONO
                GoTo LINE1
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

            Dim OBJGRN As New JobOutDetails
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
            If EDIT = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Unable To Delete", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Wish to Delete JobOut.?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If MsgBox("Are you Sure?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        Dim alParaval As New ArrayList
                        alParaval.Add(TXTJONO.Text.Trim)
                        alParaval.Add(YearId)
                        alParaval.Add(Userid)

                        Dim clspo As New ClsJobOut()
                        clspo.alParaval = alParaval
                        Dim IntResult As Integer = clspo.Delete()
                        MsgBox("JobOut Deleted")
                        CLEAR()
                        EDIT = False
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function CloneWithValues(ByVal row As DataGridViewRow) As DataGridViewRow
        CloneWithValues = CType(row.Clone(), DataGridViewRow)
        For index As Int32 = 0 To row.Cells.Count - 1
            CloneWithValues.Cells(index).Value = row.Cells(index).Value
        Next
    End Function

    Private Sub tstxtbillno_Validating(sender As Object, e As CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDJO.RowCount = 0
                TEMPJONO = Val(tstxtbillno.Text)
                If TEMPJONO > 0 Then
                    EDIT = True
                    JobOut_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTJOBDOCKET_Click(sender As Object, e As EventArgs) Handles CMDSELECTJOBDOCKET.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim OBJSO As New SelectJobDocket
            OBJSO.FRMSTRING = "JOBOUT"
            OBJSO.ShowDialog()
            Dim DT As DataTable = OBJSO.DT
            If DT.Rows.Count > 0 Then
                TXTJOBDOCKETNO.Text = Val(DT.Rows(0).Item("JOBDOCKETNO"))
                TXTPARTYNAME.Text = DT.Rows(0).Item("NAME")
                TXTORDERTYPE.Text = DT.Rows(0).Item("ORDERTYPE")
                TXTBOMITEMCODE.Text = DT.Rows(0).Item("SUBITEMCODE")
                TXTMAINITEM.Text = DT.Rows(0).Item("ITEMNAME")
                TXTSIZE.Text = DT.Rows(0).Item("SIZE")

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CMDSELECTSTOCK_Click(sender As Object, e As EventArgs) Handles CMDSELECTSTOCK.Click
        Try
            If CMBGODOWN.Text.Trim = "" And GRIDJO.RowCount = 0 Then
                MsgBox("Please Select Godown First", MsgBoxStyle.Critical)
                CMBGODOWN.Focus()
                Exit Sub
            End If

            Dim DTTABLE As New DataTable
            Dim OBJSELECTGDN As New SelectStock
            OBJSELECTGDN.GODOWN = CMBGODOWN.Text.Trim
            OBJSELECTGDN.ShowDialog()
            DTTABLE = OBJSELECTGDN.DT

            If DTTABLE.Rows.Count > 0 Then
                For Each dr As DataRow In DTTABLE.Rows
                    GRIDJO.Rows.Add(0, dr("ITEMNAME"), dr("PAPERGSM"), dr("LOTNO"), dr("UNIT"), Format(Val(dr("QTY")), "0.00"), Format(Val(dr("WT")), "0.00"), Format(Val(dr("RATE")), "0.00"), 0, 0, 0, "", 0, 0)
                Next
                GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1
                getsrno(GRIDJO)
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDJO_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDJO.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDJO.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'end of block
                GRIDJO.Rows.RemoveAt(GRIDJO.CurrentRow.Index)
                getsrno(GRIDJO)
                TOTAL()
            ElseIf e.KeyCode = Keys.F5 Then
                'EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            LBLTOTALQTY.Text = 0.0
            LBLTOTALWT.Text = 0.0
            LBLTOTALAMOUNT.Text = 0.0
            For Each ROW As DataGridViewRow In GRIDJO.Rows
                If ROW.Cells(GSRNO.Index).Value <> Nothing Then
                    LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0.00")
                    LBLTOTALWT.Text = Format(Val(LBLTOTALWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")
                    ROW.Cells(GAMOUNT.Index).Value = Format(ROW.Cells(GQTY.Index).EditedFormattedValue * Val(ROW.Cells(GRATE.Index).EditedFormattedValue), "0.00")
                    LBLTOTALAMOUNT.Text = Format(Val(LBLTOTALAMOUNT.Text) + Val(ROW.Cells(GAMOUNT.Index).EditedFormattedValue), "0.00")
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBJOBBERNAME_Enter(sender As Object, e As EventArgs) Handles CMBJOBBERNAME.Enter
        Try
            If CMBJOBBERNAME.Text.Trim = "" Then fillname(CMBJOBBERNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBJOBBERNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBJOBBERNAME.Validating
        Try
            If CMBJOBBERNAME.Text.Trim <> "" Then namevalidate(CMBJOBBERNAME, CMBCODE, e, Me, TXTADD, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTMOBILENO_KeyPress(sender As Object, e As KeyPressEventArgs)
        numkeypress(e, TXTMOBILENO, Me)
    End Sub

    Private Sub TXTQTY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTQTY.KeyPress
        numdot(e, TXTQTY, Me)
    End Sub

    Private Sub CMBTRANSPORT_Enter(sender As Object, e As EventArgs) Handles CMBTRANSPORT.Enter
        Try
            If CMBTRANSPORT.Text.Trim = "" Then fillname(CMBTRANSPORT, EDIT, "AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTRANSPORT_Validating(sender As Object, e As CancelEventArgs) Handles CMBTRANSPORT.Validating
        Try
            If CMBTRANSPORT.Text.Trim <> "" Then namevalidate(CMBTRANSPORT, CMBCODE, e, Me, TXTADD, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tstxtbillno.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub GRIDJO_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GRIDJO.CellValidating
        Try
            Dim colNum As Integer = GRIDJO.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
            Select Case colNum

                Case GQTY.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDJO.CurrentCell.Value = Nothing Then GRIDJO.CurrentCell.Value = "0.00"
                        GRIDJO.CurrentCell.Value = Convert.ToDecimal(GRIDJO.Item(colNum, e.RowIndex).Value)
                        TOTAL()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        'Exit Sub
                    End If
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class