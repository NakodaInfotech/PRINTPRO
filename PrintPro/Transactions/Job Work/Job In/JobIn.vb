Imports BL
Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel

Public Class JobIn

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE, GRIDSHIFTDOUBLECLICK As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Dim GRIDUPLOADDOUBLECLICK As Boolean
    Dim temprow As Integer
    Dim TEMPSHIFTROW As Integer
    Public edit As Boolean
    Public TEMPJONO As Integer
    Dim EXPIRY As Boolean = False

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        edit = False
    End Sub

    Sub CLEAR()
        GRIDDOUBLECLICK = False
        GRIDUPLOADDOUBLECLICK = False
        TXTJONO.ReadOnly = True
        DTDATE.Text = Now.Date
        GRIDJO.RowCount = 0
        GETMAX_NO()
        tstxtbillno.Clear()
        TXTVEHICLENO.Clear()
        TXTMOBILENO.Clear()
        TXTJOBDOCKETNO.Clear()
        TXTPARTYNAME.Clear()
        TXTBOMITEMCODE.Clear()
        TXTMAINITEM.Clear()
        TXTQTY.Clear()
        CMBJOBBERNAME.Text = ""
        CMBPROCESS.Text = ""
        TXTCHALLANNO.Clear()
        TXTORDERTYPE.Clear()
        CMBGODOWN.Text = ""
        CMBTRANSPORT.Text = ""
        TXTREMARKS.Clear()
        LBLTOTALWT.Text = 0.0
        LBLTOTALAMOUNT.Text = 0.0
        LBLTOTALINQTY.Text = 0.0
        LBLTOTALCHECKQTY.Text = 0.0
        LBLTOTALCHECKQTY.Text = 0.0
        LBLTOTALWASTAGEQTY.Text = 0.0
        LBLTOTALFINALQTY.Text = 0.0
        LBLTOTALGOODQTY.Text = 0.0
        EP.Clear()
        TXTSRNO.Clear()
        TXTPAPERGSM.Clear()
        TXTLOTNO.Clear()
        TXTWT.Clear()
        TXTINQTY.Clear()
        TXTCHECKQTY.Clear()
        TXTGOODQTY.Clear()
        TXTWASTAGEQTY.Clear()
        TXTFINALQTY.Clear()
        TXTRATE.Clear()
        TXTAMOUNT.Clear()
        CMBITEMNAME.Text = ""
        CMBUNIT.Text = ""
        TXTJOBOUTNO.Clear()
        CMDSELECTJOBOUT.Enabled = True

    End Sub

    Sub GETMAX_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(JI_NO),0) + 1 ", "JOBIN", "  AND JI_cmpid=" & CmpId & " and JI_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTJONO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Sub FILLCMB()
        'If CMBPROCESS.Text.Trim = "" Then fillname(CMBPROCESS, edit, "AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
        If CMBJOBBERNAME.Text.Trim = "" Then fillname(CMBJOBBERNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        If CMBTRANSPORT.Text.Trim = "" Then fillname(CMBTRANSPORT, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'TRANSPORT' ")

    End Sub

    Private Sub JobIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'JOBIN'")

            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            Cursor.Current = Cursors.WaitCursor

            FILLCMB()
            CLEAR()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJCMN As New ClsCommon
                Dim OBJCLSINCENTIVE As New ClsJobIn
                Dim dttable As New DataTable

                dttable = OBJCLSINCENTIVE.SELECTJOBIN(TEMPJONO, CmpId, YearId)
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
                        TXTQTY.Text = Format(Val(dr("QTY")), "0")
                        TXTCHALLANNO.Text = dr("CHALLANNO")
                        TXTMOBILENO.Text = dr("MOBILENO")
                        TXTORDERTYPE.Text = dr("ORDERTYPE")
                        TXTVEHICLENO.Text = dr("VEHICLENO")
                        LBLTOTALWT.Text = Val(dr("TOTALWT"))
                        LBLTOTALAMOUNT.Text = Val(dr("TOTALAMOUNT"))
                        TXTREMARKS.Text = dr("REMARKS")
                        TXTJOBOUTNO.Text = dr("JOBOUTNO")
                        LBLTOTALINQTY.Text = Val(dr("TOTALINQTY"))
                        LBLTOTALCHECKQTY.Text = Val(dr("TOTALCHECKQTY"))
                        LBLTOTALGOODQTY.Text = Val(dr("TOTALGOODQTY"))
                        LBLTOTALWASTAGEQTY.Text = Val(dr("TOTALWASTAGEQTY"))
                        LBLTOTALFINALQTY.Text = Val(dr("TOTALFINALQTY"))

                        GRIDJO.Rows.Add(dr("GRIDSRNO").ToString, dr("ITEM").ToString, dr("PAPERGSM").ToString, dr("LOTNO").ToString, Format(dr("WT"), "0.00"), dr("UNIT").ToString, Format(dr("INQTY"), "0.00"), Format(dr("CHECKQTY"), "0.00"), Format(dr("GOODQTY"), "0.00"), Format(dr("WASTAGEQTY"), "0.00"), Format(dr("FINALQTY"), "0.00"), Val(dr("RATE")), Format(Val(dr("AMOUNT")), "0.00"), dr("TYPE"), Format(dr("OUTQTY"), "0.00"), dr("JODONE"))

                    Next

                    GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1
                    CMDSELECTJOBOUT.Enabled = False
                Else
                    edit = False
                    CLEAR()
                    TOTAL()
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
            alParaval.Add(Val(LBLTOTALWT.Text))
            alParaval.Add(Val(LBLTOTALAMOUNT.Text))
            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(TXTJOBOUTNO.Text.Trim)
            alParaval.Add(Val(LBLTOTALINQTY.Text))
            alParaval.Add(Val(LBLTOTALCHECKQTY.Text))
            alParaval.Add(Val(LBLTOTALGOODQTY.Text))
            alParaval.Add(Val(LBLTOTALWASTAGEQTY.Text))
            alParaval.Add(Val(LBLTOTALFINALQTY.Text))

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            ' GRID PARAMETERS
            Dim GRIDSRNO As String = ""
            Dim ITEM As String = ""
            Dim PAPERGSM As String = ""
            Dim LOTNO As String = ""
            Dim WT As String = ""
            Dim UNIT As String = ""
            Dim INQTY As String = ""
            Dim CHECKQTY As String = ""
            Dim GOODQTY As String = ""
            Dim WASTAGEQTY As String = ""
            Dim FINALQTY As String = ""
            Dim RATE As String = ""
            Dim AMOUNT As String = ""
            Dim TYPE As String = ""
            Dim OUTQTY As String = ""
            Dim JODONE As String = ""

            For Each ROW As Windows.Forms.DataGridViewRow In GRIDJO.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(ROW.Cells(GSRNO.Index).Value)
                        ITEM = ROW.Cells(GITEM.Index).Value.ToString
                        PAPERGSM = ROW.Cells(GPAPERGSM.Index).Value.ToString
                        LOTNO = ROW.Cells(GLOTNO.Index).Value.ToString
                        WT = Val(ROW.Cells(GWT.Index).Value)
                        UNIT = ROW.Cells(GUNIT.Index).Value.ToString
                        INQTY = Val(ROW.Cells(GINQTY.Index).Value)
                        CHECKQTY = Val(ROW.Cells(GCHECKQTY.Index).Value)
                        GOODQTY = Val(ROW.Cells(GGOODQTY.Index).Value)
                        WASTAGEQTY = Val(ROW.Cells(GWASTAGEQTY.Index).Value)
                        FINALQTY = Val(ROW.Cells(GFINALQTY.Index).Value)
                        RATE = Val(ROW.Cells(GRATE.Index).Value)
                        AMOUNT = Val(ROW.Cells(GAMOUNT.Index).Value)
                        TYPE = ROW.Cells(GTYPE.Index).Value.ToString
                        OUTQTY = Val(ROW.Cells(GOUTQTY.Index).Value)
                        JODONE = ROW.Cells(GJODONE.Index).Value

                    Else

                        GRIDSRNO = GRIDSRNO & "|" & Val(ROW.Cells(GSRNO.Index).Value)
                        ITEM = ITEM & "|" & ROW.Cells(GITEM.Index).Value.ToString
                        PAPERGSM = PAPERGSM & "|" & ROW.Cells(GPAPERGSM.Index).Value.ToString
                        LOTNO = LOTNO & "|" & ROW.Cells(GLOTNO.Index).Value.ToString
                        WT = WT & "|" & Val(ROW.Cells(GWT.Index).Value)
                        UNIT = UNIT & "|" & ROW.Cells(GUNIT.Index).Value.ToString
                        INQTY = INQTY & "|" & Val(ROW.Cells(GINQTY.Index).Value)
                        CHECKQTY = CHECKQTY & "|" & Val(ROW.Cells(GCHECKQTY.Index).Value)
                        GOODQTY = GOODQTY & "|" & Val(ROW.Cells(GGOODQTY.Index).Value)
                        WASTAGEQTY = WASTAGEQTY & "|" & Val(ROW.Cells(GWASTAGEQTY.Index).Value)
                        FINALQTY = FINALQTY & "|" & Val(ROW.Cells(GFINALQTY.Index).Value)
                        RATE = RATE & "|" & Val(ROW.Cells(GRATE.Index).Value)
                        AMOUNT = AMOUNT & "|" & Val(ROW.Cells(GAMOUNT.Index).Value)
                        TYPE = TYPE & "|" & ROW.Cells(GTYPE.Index).Value.ToString
                        OUTQTY = OUTQTY & "|" & Val(ROW.Cells(GOUTQTY.Index).Value)
                        JODONE = JODONE & "|" & ROW.Cells(GJODONE.Index).Value

                    End If
                End If
            Next
            alParaval.Add(GRIDSRNO)
            alParaval.Add(ITEM)
            alParaval.Add(PAPERGSM)
            alParaval.Add(LOTNO)
            alParaval.Add(WT)
            alParaval.Add(UNIT)
            alParaval.Add(INQTY)
            alParaval.Add(CHECKQTY)
            alParaval.Add(GOODQTY)
            alParaval.Add(WASTAGEQTY)
            alParaval.Add(FINALQTY)
            alParaval.Add(RATE)
            alParaval.Add(AMOUNT)
            alParaval.Add(TYPE)
            alParaval.Add(OUTQTY)
            alParaval.Add(JODONE)

            Dim objclsPurord As New ClsJobIn()
            objclsPurord.alParaval = alParaval

            If edit = False Then
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
                edit = False
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
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
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
                edit = True
                JobIn_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If

            If GRIDJO.RowCount = 0 And TEMPJONO > 1 Then
                TXTJONO.Text = TEMPJONO
                GoTo LINE1
            End If

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
                edit = True
                JobIn_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If
            If GRIDJO.RowCount = 0 And TEMPJONO < MAXNO Then
                TXTJONO.Text = TEMPJONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstxtbillno.Validated
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDJO.RowCount = 0
            TEMPJONO = Val(tstxtbillno.Text)
            If TEMPJONO > 0 Then
                edit = True
                JobIn_Load(sender, e)
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

            Dim OBJGRN As New JobInDetails
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

                If MsgBox("Wish to Delete Job In.?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If MsgBox("Are you Sure?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        Dim alParaval As New ArrayList
                        alParaval.Add(TXTJONO.Text.Trim)
                        alParaval.Add(YearId)


                        Dim clspo As New ClsJobIn()
                        clspo.alParaval = alParaval
                        Dim IntResult As Integer = clspo.Delete()
                        MsgBox("Job In Deleted")
                        CLEAR()
                        edit = False
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

    Sub Fillgrid()
        Try
            If GRIDDOUBLECLICK = False Then
                GRIDJO.Rows.Add(Val(TXTSRNO.Text.Trim), CMBITEMNAME.Text.Trim, TXTPAPERGSM.Text.Trim, TXTLOTNO.Text.Trim, TXTWT.Text.Trim, CMBUNIT.Text.Trim, TXTINQTY.Text.Trim, TXTCHECKQTY.Text.Trim, TXTGOODQTY.Text.Trim, TXTWASTAGEQTY.Text.Trim, TXTFINALQTY.Text.Trim, TXTRATE.Text.Trim, TXTAMOUNT.Text.Trim, "", 0, 0)
                getsrno(GRIDJO)
            ElseIf GRIDDOUBLECLICK = True Then
                GRIDJO.Item(GSRNO.Index, temprow).Value = Val(TXTSRNO.Text.Trim)
                GRIDJO.Item(GITEM.Index, temprow).Value = CMBITEMNAME.Text.Trim
                GRIDJO.Item(GPAPERGSM.Index, temprow).Value = TXTLOTNO.Text.Trim
                GRIDJO.Item(GLOTNO.Index, temprow).Value = TXTLOTNO.Text.Trim
                GRIDJO.Item(GWT.Index, temprow).Value = TXTWT.Text.Trim
                GRIDJO.Item(GUNIT.Index, temprow).Value = CMBUNIT.Text.Trim
                GRIDJO.Item(GINQTY.Index, temprow).Value = TXTINQTY.Text.Trim
                GRIDJO.Item(GCHECKQTY.Index, temprow).Value = TXTCHECKQTY.Text.Trim
                GRIDJO.Item(GGOODQTY.Index, temprow).Value = TXTGOODQTY.Text.Trim
                GRIDJO.Item(GWASTAGEQTY.Index, temprow).Value = TXTWASTAGEQTY.Text.Trim
                GRIDJO.Item(GFINALQTY.Index, temprow).Value = TXTFINALQTY.Text.Trim
                GRIDJO.Item(GRATE.Index, temprow).Value = TXTRATE.Text.Trim
                GRIDJO.Item(GAMOUNT.Index, temprow).Value = TXTAMOUNT.Text.Trim

                GRIDDOUBLECLICK = False

            End If

            TOTAL()
            GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1

            TXTSRNO.Text = GRIDJO.RowCount + 1
            CMBITEMNAME.Text = ""
            TXTLOTNO.Clear()
            TXTWT.Clear()
            TXTLOTNO.Clear()
            CMBUNIT.Text = ""
            TXTINQTY.Clear()
            TXTCHECKQTY.Clear()
            TXTGOODQTY.Clear()
            TXTWASTAGEQTY.Clear()
            TXTFINALQTY.Clear()
            TXTRATE.Clear()
            TXTAMOUNT.Clear()

            CMBITEMNAME.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If GRIDJO.CurrentRow.Index >= 0 And GRIDJO.Item(GSRNO.Index, GRIDJO.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDJO.Item(GSRNO.Index, GRIDJO.CurrentRow.Index).Value.ToString
                CMBITEMNAME.Text = GRIDJO.Item(GITEM.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTPAPERGSM.Text = GRIDJO.Item(GPAPERGSM.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTLOTNO.Text = GRIDJO.Item(GLOTNO.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTWT.Text = GRIDJO.Item(GWT.Index, GRIDJO.CurrentRow.Index).Value.ToString
                CMBUNIT.Text = GRIDJO.Item(GUNIT.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTINQTY.Text = GRIDJO.Item(GINQTY.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTCHECKQTY.Text = GRIDJO.Item(GCHECKQTY.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTGOODQTY.Text = GRIDJO.Item(GGOODQTY.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTWASTAGEQTY.Text = GRIDJO.Item(GWASTAGEQTY.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTFINALQTY.Text = GRIDJO.Item(GFINALQTY.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTRATE.Text = GRIDJO.Item(GRATE.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTAMOUNT.Text = GRIDJO.Item(GAMOUNT.Index, GRIDJO.CurrentRow.Index).Value.ToString

                temprow = GRIDJO.CurrentRow.Index
                CMBITEMNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub GRIDJO_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDJO.CellDoubleClick
        Try
            EDITROW()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub tstxtbillno_Validating(sender As Object, e As CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDJO.RowCount = 0
                TEMPJONO = Val(tstxtbillno.Text)
                If TEMPJONO > 0 Then
                    edit = True
                    JobIn_Load(sender, e)
                Else
                    CLEAR()
                    edit = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTJOBOUT_Click(sender As Object, e As EventArgs) Handles CMDSELECTJOBOUT.Click
        Try
            EP.Clear()

            Dim OBJSO As New SelectJobOut
            OBJSO.ShowDialog()
            Dim DT As DataTable = OBJSO.DT
            If DT.Rows.Count > 0 Then

                'FETCH Data FROM JOBOUT WITH RESPECT TO SELECTED JONO
                TXTJOBOUTNO.Text = Val(DT.Rows(0).Item("TEMPJONO"))
                TXTJOBDOCKETNO.Text = Val(DT.Rows(0).Item("JOBDOCKETNO"))
                TXTPARTYNAME.Text = DT.Rows(0).Item("PARTYNAME")
                TXTBOMITEMCODE.Text = DT.Rows(0).Item("BOMITEMCODE")
                TXTMAINITEM.Text = DT.Rows(0).Item("MAINITEM")
                TXTQTY.Text = DT.Rows(0).Item("QTY")
                CMBGODOWN.Text = DT.Rows(0).Item("GODOWN")
                CMBJOBBERNAME.Text = DT.Rows(0).Item("JOBBERNAME")
                CMBTRANSPORT.Text = DT.Rows(0).Item("TRANSPORT")

                Dim OBJCMN As New ClsCommon
                Dim DTSO As DataTable = OBJCMN.search(" JOBOUT_DESC.JO_NO AS JONO, JOBOUT_DESC.JO_GRIDSRNO AS GRIDSRNO, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEM, ISNULL(JOBOUT_DESC.JO_PAPERGSM, '') AS PAPERGSM, ISNULL(JOBOUT_DESC.JO_LOTNO, '') AS LOTNO, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(JOBOUT_DESC.JO_GQTY, 0) AS GQTY, ISNULL(JOBOUT_DESC.JO_WT, 0) AS WT, ISNULL(JOBOUT_DESC.JO_RATE, 0) AS RATE, ISNULL(JOBOUT_DESC.JO_AMOUNT, 0) AS AMOUNT", "", "JOBOUT_DESC LEFT OUTER JOIN UNITMASTER ON JOBOUT_DESC.JO_UNITID = UNITMASTER.unit_id LEFT OUTER JOIN NONINVITEMMASTER ON JOBOUT_DESC.JO_ITEMID = NONINVITEMMASTER.NONINV_ID", " AND JOBOUT_DESC.JO_NO = " & Val(TXTJOBOUTNO.Text.Trim) & " AND JOBOUT_DESC.JO_yearid = " & YearId)
                If DTSO.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DTSO.Rows
                        GRIDJO.Rows.Add(0, DTROW("ITEM").ToString, DTROW("PAPERGSM").ToString, DTROW("LOTNO").ToString, DTROW("WT"), DTROW("UNIT").ToString, DTROW("GQTY").ToString, 0, 0, 0, 0, DTROW("RATE").ToString, DTROW("AMOUNT").ToString, 0, 0, 0)
                    Next
                End If

                getsrno(GRIDJO)
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
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            LBLTOTALWT.Text = 0.0
            LBLTOTALAMOUNT.Text = 0.0
            LBLTOTALINQTY.Text = 0.0
            LBLTOTALCHECKQTY.Text = 0.0
            LBLTOTALGOODQTY.Text = 0.0
            LBLTOTALWASTAGEQTY.Text = 0.0
            LBLTOTALFINALQTY.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDJO.Rows
                If ROW.Cells(GSRNO.Index).Value <> Nothing Then

                    LBLTOTALWT.Text = Format(Val(LBLTOTALWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")
                    LBLTOTALAMOUNT.Text = Format(Val(LBLTOTALAMOUNT.Text) + Val(ROW.Cells(GAMOUNT.Index).EditedFormattedValue), "0.00")
                    LBLTOTALINQTY.Text = Format(Val(LBLTOTALINQTY.Text) + Val(ROW.Cells(GINQTY.Index).EditedFormattedValue), "0.00")
                    LBLTOTALCHECKQTY.Text = Format(Val(LBLTOTALCHECKQTY.Text) + Val(ROW.Cells(GCHECKQTY.Index).EditedFormattedValue), "0.00")
                    LBLTOTALGOODQTY.Text = Format(Val(LBLTOTALGOODQTY.Text) + Val(ROW.Cells(GGOODQTY.Index).EditedFormattedValue), "0.00")
                    LBLTOTALWASTAGEQTY.Text = Format(Val(LBLTOTALWASTAGEQTY.Text) + Val(ROW.Cells(GWASTAGEQTY.Index).EditedFormattedValue), "0.00")
                    LBLTOTALFINALQTY.Text = Format(Val(LBLTOTALFINALQTY.Text) + Val(ROW.Cells(GFINALQTY.Index).EditedFormattedValue), "0.00")

                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBJOBBERNAME_Enter(sender As Object, e As EventArgs) Handles CMBJOBBERNAME.Enter
        Try
            If CMBJOBBERNAME.Text.Trim = "" Then fillname(CMBJOBBERNAME, edit, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")

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

    Private Sub TXTAMOUNT_Validated(sender As Object, e As EventArgs) Handles TXTAMOUNT.Validated
        Try
            If CMBITEMNAME.Text.Trim <> "" And Val(TXTINQTY.Text.Trim) > 0 And CMBUNIT.Text.Trim <> "" Then Fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGOODQTY_Validated(sender As Object, e As EventArgs) Handles TXTGOODQTY.Validated
        Try
            TXTFINALQTY.Text = Format(Val(TXTINQTY.Text) - Val(TXTWASTAGEQTY.Text.Trim), "0.00")
            TXTWASTAGEQTY.Text = Format(Val(TXTINQTY.Text) - Val(TXTGOODQTY.Text.Trim), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JobIn_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()

            ElseIf e.Alt = True And e.KeyCode = Keys.P Then
                ' Call PrintToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolprevious_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F5 Then
                GRIDJO.Focus()
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for Delete
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class