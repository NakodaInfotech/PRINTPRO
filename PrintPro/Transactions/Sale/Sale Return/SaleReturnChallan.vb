

Imports System.ComponentModel
Imports BL

Public Class SaleReturnChallan

    Dim GRIDDOUBLECLICK As Boolean
    Public EDIT As Boolean
    Public ALLOWLRRECD As Boolean
    Public TEMPSRCHNO, TEMPROW As Integer
    Public USERGODOWN As String = ""
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT


    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub CLEAR()

        TXTFROM.Clear()
        TXTTO.Clear()
        tstxtbillno.Clear()
        EP.Clear()
        SRCHDATE.Text = Now.Date
        CMBNAME.Text = ""
        If USERGODOWN <> "" Then cmbGodown.Text = USERGODOWN Else cmbGodown.Text = ""
        TXTLOTNO.Clear()
        TXTCHALLANNO.Clear()
        CHALLANDATE.Value = Now.Date
        TXTSRNO.Text = 1
        CMBITEMNAME.Text = ""
        CMBITEMCODE.Text = ""
        TXTBATCHNO.Clear()
        TXTMATERIALCODE.Clear()
        TXTQTY.Text = 1
        TXTQTY.Clear()
        TXTRATE.Clear()
        TXTSHIPPERS.Clear()
        TXTPACKETS.Clear()
        TXTAMOUNT.Text = ""
        TXTAMOUNT.Clear()
        GRIDSR.RowCount = 0
        TXTREMARKS.Clear()
        lbllocked.Visible = False
        PBlock.Visible = False
        GRIDDOUBLECLICK = False
        GETMAXNO()
        LBLTOTALQTY.Text = 0
        LBLTOTALAMT.Text = 0
        LBLWHATSAPP.Visible = False
        TXTNOOFPACKETS.Clear()
        CMBTRANSPORTNAME.Text = ""
        TXTLRNO.Clear()
        DTLRDATE.Text = Now.Date
        CHKLRRECD.CheckState = CheckState.Unchecked
    End Sub

    Sub TOTAL()
        Try
            'LBLTOTALMTRS.Text = 0.0
            LBLTOTALQTY.Text = 0
            LBLTOTALAMT.Text = 0.0
            For Each ROW As DataGridViewRow In GRIDSR.Rows
                If ROW.Cells(GSRNO.Index).Value <> Nothing Then
                    ' If ROW.Cells(gcut.Index).EditedFormattedValue > 0 Then ROW.Cells(GMTRS.Index).Value = ROW.Cells(gQty.Index).EditedFormattedValue * ROW.Cells(gcut.Index).EditedFormattedValue
                    LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0")
                    'LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    'If ROW.Cells(GPER.Index).Value = "Mtrs" Then
                    If Val(ROW.Cells(GRATE.Index).EditedFormattedValue) > 0 Then ROW.Cells(GAMOUNT.Index).Value = Format(Val(ROW.Cells(GRATE.Index).EditedFormattedValue) * Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0.00")
                Else
                    If Val(ROW.Cells(GRATE.Index).EditedFormattedValue) > 0 Then ROW.Cells(GAMOUNT.Index).Value = Format(Val(ROW.Cells(GRATE.Index).EditedFormattedValue) * Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0.00")
                End If
                LBLTOTALAMT.Text = Format(Val(LBLTOTALAMT.Text) + Val(ROW.Cells(GAMOUNT.Index).EditedFormattedValue), "0.00")
                'End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        CLEAR()
        EDIT = False
        CMBNAME.Focus()
    End Sub

    Sub GETMAXNO()
        Try
            Dim DTTABLE As New DataTable
            DTTABLE = getmax(" isnull(max(SRCH_no),0) + 1 ", " SALERETURNCHALLAN ", " and SRCH_yearid=" & YearId)
            If DTTABLE.Rows.Count > 0 Then TXTSRCHNO.Text = DTTABLE.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function errorvalid() As Boolean
        Try

            Dim bln As Boolean = True

            If cmbGodown.Text.Trim.Length = 0 Then
                EP.SetError(cmbGodown, " Please Select Godown")
                bln = False
            End If


            If UserName <> "Admin" And lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Item Used, Item Locked")
                bln = False
            End If

            If GRIDSR.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            'If ClientName <> "CC" And ClientName <> "C3" And ClientName <> "MOMAI" And ClientName <> "AXIS" And ClientName <> "GELATO" Then
            '    For Each ROW As DataGridViewRow In GRIDSR.Rows
            '        If ROW.Cells(GMTRS.Index).Value = 0 Then
            '            EP.SetError(TXTMTRS, "Mtrs Cannot be 0")
            '            bln = False
            '        End If

            '        'If ITEMCOSTCENTRE = True And Val(ROW.Cells(GRATE.Index).Value) = 0 Then
            '        '    EP.SetError(CMBNAME, "Rate Cannot be 0")
            '        '    bln = False
            '        'End If
            '    Next
            'End If


            If SRCHDATE.Text = "__/__/____" Then
                EP.SetError(SRCHDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(SRCHDATE.Text) Then
                    EP.SetError(SRCHDATE, "Date not in Accounting Year")
                    bln = False
                End If

                If Convert.ToDateTime(SRCHDATE.Text).Date < SALERETCHBLOCKDATE.Date Then
                    EP.SetError(SRCHDATE, "Date is Blocked, Please make entries after " & Format(SALERETCHBLOCKDATE.Date, "dd/MM/yyyy"))
                    bln = False
                End If
            End If

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(Format(Convert.ToDateTime(SRCHDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(cmbGodown.Text.Trim)
            alParaval.Add(TXTLOTNO.Text.Trim)
            alParaval.Add(TXTCHALLANNO.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(CHALLANDATE.Value).Date, "MM/dd/yyyy"))
            alParaval.Add(Val(LBLTOTALQTY.Text))
            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim GRIDSRNO As String = ""
            Dim ITEMCODE As String = ""
            Dim ITEMNAME As String = ""
            Dim MATERIALCODE As String = ""
            Dim QTY As String = ""
            Dim BATCHNO As String = ""
            Dim SHIPPERS As String = ""
            Dim PACKETS As String = ""
            Dim RATE As String = ""
            Dim AMOUNT As String = ""
            Dim DONE As String = ""
            Dim OUTQTY As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDSR.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(row.Cells(GSRNO.Index).Value)
                        ITEMCODE = row.Cells(GITEMCODE.Index).Value.ToString
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                        MATERIALCODE = row.Cells(GMATERIALCODE.Index).Value.ToString
                        QTY = Val(row.Cells(GQTY.Index).Value).ToString
                        BATCHNO = row.Cells(GBATCHNO.Index).Value.ToString
                        SHIPPERS = row.Cells(GShippers.Index).Value.ToString
                        PACKETS = row.Cells(GPackets.Index).Value.ToString
                        RATE = Val(row.Cells(GRATE.Index).Value).ToString
                        AMOUNT = Val(row.Cells(GAMOUNT.Index).Value).ToString
                        If row.Cells(GDONE.Index).Value = True Then DONE = 1 Else DONE = 0
                        OUTQTY = Val(row.Cells(GOUTQTY.Index).Value)
                    Else
                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(GSRNO.Index).Value)
                        ITEMCODE = ITEMCODE & "|" & row.Cells(GITEMCODE.Index).Value.ToString
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GITEMNAME.Index).Value
                        MATERIALCODE = MATERIALCODE & "|" & row.Cells(GMATERIALCODE.Index).Value.ToString
                        QTY = QTY & "|" & Val(row.Cells(GQTY.Index).Value).ToString
                        BATCHNO = BATCHNO & "|" & row.Cells(GBATCHNO.Index).Value.ToString
                        SHIPPERS = SHIPPERS & "|" & row.Cells(GShippers.Index).Value.ToString
                        PACKETS = PACKETS & "|" & row.Cells(GPackets.Index).Value.ToString
                        RATE = RATE & "|" & Val(row.Cells(GRATE.Index).Value).ToString
                        AMOUNT = AMOUNT & "|" & Val(row.Cells(GAMOUNT.Index).Value).ToString
                        If row.Cells(GDONE.Index).Value = True Then
                            DONE = DONE & "|" & "1"
                        Else
                            DONE = DONE & "|" & "0"
                        End If
                        OUTQTY = OUTQTY & "|" & Val(row.Cells(GOUTQTY.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(ITEMCODE)
            alParaval.Add(ITEMNAME)
            alParaval.Add(MATERIALCODE)
            alParaval.Add(QTY)
            alParaval.Add(BATCHNO)
            alParaval.Add(SHIPPERS)
            alParaval.Add(PACKETS)
            alParaval.Add(RATE)
            alParaval.Add(AMOUNT)
            alParaval.Add(DONE)
            alParaval.Add(OUTQTY)


            alParaval.Add(Val(TXTNOOFPACKETS.Text.Trim))
            alParaval.Add(CMBTRANSPORTNAME.Text.Trim)
            alParaval.Add(TXTLRNO.Text.Trim)
            alParaval.Add(DTLRDATE.Text)
            alParaval.Add(LBLTOTALAMT.Text.Trim)
            If CHKLRRECD.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            Dim OBJSR As New ClsSaleReturnChallan()
            OBJSR.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = OBJSR.SAVE()
                MsgBox("Details Added")
                TXTSRCHNO.Text = Val(DTTABLE.Rows(0).Item(0))
                TEMPSRCHNO = Val(DTTABLE.Rows(0).Item(0))

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPSRCHNO)
                Dim IntResult As Integer = OBJSR.UPDATE()
                MsgBox("Details Updated")
            End If
            PRINTREPORT(TEMPSRCHNO)
            EDIT = False
            CLEAR()
            CMBNAME.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PRINTREPORT(ByVal SRNO As Integer)
        Try
            If MsgBox("Wish to Print Sale Return?", MsgBoxStyle.YesNo) = vbYes Then
                Dim OBJPUR As New SaleReturnDesign
                OBJPUR.MdiParent = MDIMain
                OBJPUR.FRMSTRING = "SALERETURNCHALLAN"
                OBJPUR.SALRETNO = Val(SRNO)
                OBJPUR.WHERECLAUSE = "{SALERETURNCHALLAN.SRCH_NO}=" & Val(SRNO) & " and {SALERETURNCHALLAN.SRCH_yearid}=" & YearId
                OBJPUR.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaleReturnChallan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.KeyCode = Windows.Forms.Keys.F5 Then       'Grid Focus
                GRIDSR.Focus()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1 Then       'for Delete
                TabControl1.SelectedIndex = (0)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2 Then       'for Delete
                TabControl1.SelectedIndex = (1)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolprevious_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.P Then
                'Call PrintToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaleReturnChallan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'SALE RETURN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            FILLCMB()
            CLEAR()
            CMBNAME.Enabled = True
            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJSR As New ClsSaleReturnChallan()
                OBJSR.alParaval.Add(TEMPSRCHNO)
                OBJSR.alParaval.Add(YearId)
                Dim dttable As DataTable = OBJSR.SELECTSALERETURNCHALLAN()
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTSRCHNO.Text = TEMPSRCHNO
                        TXTSRCHNO.ReadOnly = True
                        SRCHDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        CMBNAME.Text = Convert.ToString(dr("NAME"))
                        cmbGodown.Text = dr("GODOWN")
                        TXTLOTNO.Text = dr("LOTNO")
                        TXTCHALLANNO.Text = dr("CHALLANNO")
                        CHALLANDATE.Value = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")
                        LBLTOTALQTY.Text = Format(Val(dr("TOTALQTY")), "0.00")
                        TXTREMARKS.Text = Convert.ToString(dr("remarks").ToString)
                        If Convert.ToBoolean(dr("SENDWHATSAPP")) = True Then LBLWHATSAPP.Visible = True
                        TXTNOOFPACKETS.Text = Val(dr("NOOFPACKETS"))
                        CMBTRANSPORTNAME.Text = dr("TRANSNAME")
                        TXTLRNO.Text = dr("LRNO")
                        DTLRDATE.Text = dr("LRDATE")
                        LBLTOTALAMT.Text = dr("TOTALAMOUNT")


                        'Item Grid
                        GRIDSR.Rows.Add(dr("GRIDSRNO").ToString, dr("ITEMCODE"), dr("ITEMNAME").ToString, dr("MATERIALCODE").ToString, Format(Val(dr("QTY")), "0.00"), dr("BATCHNO").ToString, dr("SHIPPERS").ToString, dr("PACKETS").ToString, Format(Val(dr("RATE")), "0.00"), Format(Val(dr("AMOUNT")), "0.00"), dr("DONE"), dr("OUTQTY"))

                        If Val(dr("OUTQTY")) > 0 Then
                            GRIDSR.Rows(GRIDSR.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If
                        CHKLRRECD.Checked = Convert.ToBoolean(dr("LRRECD"))

                        'If Convert.ToBoolean(dr("BARCODEPRINTED")) = True Then LBLBARCODEPRINTED.Visible = True
                    Next

                    TOTAL()
                    GRIDSR.FirstDisplayedScrollingRowIndex = GRIDSR.RowCount - 1
                Else
                    EDIT = False
                    CLEAR()
                End If

            End If

            TXTSRNO.Text = GRIDSR.RowCount

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub FILLCMB()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors'")
            If cmbGodown.Text.Trim = "" Then fillGODOWN(cmbGodown, EDIT)
            If CMBITEMCODE.Text.Trim = "" Then fillITEMCODE(CMBITEMCODE, EDIT, " and ITEMMASTER.ITEM_MATERIALTYPE = 'FINISHED'")
            If CMBITEMNAME.Text.Trim = "" Then fillITEMNAME(CMBITEMNAME, EDIT, " and ITEMMASTER.ITEM_MATERIALTYPE = 'FINISHED'")

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGodown.Enter
        Try
            If cmbGodown.Text.Trim = "" Then fillGODOWN(cmbGodown, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbGodown.Validating
        Try
            If cmbGodown.Text.Trim <> "" Then GODOWNVALIDATE(cmbGodown, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJSR As New SaleReturnChallanDetails
            OBJSR.MdiParent = MDIMain
            OBJSR.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDSR.RowCount = 0
                TEMPSRCHNO = Val(tstxtbillno.Text)
                If TEMPSRCHNO > 0 Then
                    EDIT = True
                    SaleReturnChallan_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            GRIDSR.Enabled = True
            If GRIDDOUBLECLICK = False Then
                GRIDSR.Rows.Add(Val(TXTSRNO.Text.Trim), CMBITEMCODE.Text.Trim, CMBITEMNAME.Text.Trim, TXTMATERIALCODE.Text.Trim, Val(TXTQTY.Text.Trim), TXTBATCHNO.Text.Trim, TXTSHIPPERS.Text.Trim, TXTPACKETS.Text.Trim, Val(TXTRATE.Text.Trim), Val(TXTAMOUNT.Text.Trim), 0, 0)
                getsrno(GRIDSR)
            ElseIf GRIDDOUBLECLICK = True Then
                GRIDSR.Item(GSRNO.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
                GRIDSR.Item(GITEMCODE.Index, TEMPROW).Value = CMBITEMCODE.Text.Trim
                GRIDSR.Item(GITEMNAME.Index, TEMPROW).Value = CMBITEMNAME.Text.Trim
                GRIDSR.Item(GMATERIALCODE.Index, TEMPROW).Value = TXTMATERIALCODE.Text.Trim
                GRIDSR.Item(GQTY.Index, TEMPROW).Value = Val(TXTQTY.Text.Trim)
                GRIDSR.Item(GBATCHNO.Index, TEMPROW).Value = TXTBATCHNO.Text.Trim
                GRIDSR.Item(GShippers.Index, TEMPROW).Value = TXTSHIPPERS.Text.Trim
                GRIDSR.Item(GPackets.Index, TEMPROW).Value = TXTPACKETS.Text.Trim
                GRIDSR.Item(GRATE.Index, TEMPROW).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
                GRIDSR.Item(GAMOUNT.Index, TEMPROW).Value = Format(Val(TXTAMOUNT.Text.Trim), "0.00")
                GRIDDOUBLECLICK = False
            End If
            TOTAL()
            GRIDSR.FirstDisplayedScrollingRowIndex = GRIDSR.RowCount - 1

            TXTSRNO.Text = GRIDSR.RowCount + 1
            CMBITEMCODE.Text = ""
            CMBITEMNAME.Text = ""
            TXTMATERIALCODE.Clear()
            TXTQTY.Clear()
            TXTBATCHNO.Clear()
            TXTSHIPPERS.Clear()
            TXTPACKETS.Clear()
            TXTRATE.Clear()
            TXTAMOUNT.Clear()

            CMBITEMCODE.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDSR.RowCount = 0
LINE1:
            TEMPSRCHNO = Val(TXTSRCHNO.Text) - 1
            If TEMPSRCHNO > 0 Then
                EDIT = True
                SaleReturnChallan_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDSR.RowCount = 0 And TEMPSRCHNO > 1 Then
                TXTSRCHNO.Text = TEMPSRCHNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            GRIDSR.RowCount = 0
LINE1:
            TEMPSRCHNO = Val(TXTSRCHNO.Text) + 1
            GETMAXNO()
            Dim MAXNO As Integer = TXTSRCHNO.Text.Trim
            CLEAR()
            If Val(TXTSRCHNO.Text) - 1 >= TEMPSRCHNO Then
                EDIT = True
                SaleReturnChallan_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDSR.RowCount = 0 And TEMPSRCHNO < MAXNO Then
                TXTSRCHNO.Text = TEMPSRCHNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            Dim IntResult As Integer
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Sale Return Challan Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Delete Sale Return Challan?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim alParaval As New ArrayList
                alParaval.Add(Val(TXTSRCHNO.Text.Trim))
                alParaval.Add(Userid)
                alParaval.Add(YearId)

                Dim OBJSR As New ClsSaleReturnChallan()
                OBJSR.alParaval = alParaval
                IntResult = OBJSR.DELETE()
                MsgBox("Sale Return Challan Deleted")
                CLEAR()
                EDIT = False

            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    Private Sub GRIDSR_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs)
        Try
            Dim colNum As Integer = GRIDSR.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GQTY.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDSR.CurrentCell.Value = Nothing Then GRIDSR.CurrentCell.Value = "0.00"
                        GRIDSR.CurrentCell.Value = Convert.ToDecimal(GRIDSR.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        TOTAL()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If

            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If GRIDSR.CurrentRow.Index >= 0 And GRIDSR.Item(GSRNO.Index, GRIDSR.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDSR.Item(GSRNO.Index, GRIDSR.CurrentRow.Index).Value.ToString
                CMBITEMCODE.Text = GRIDSR.Item(GITEMCODE.Index, GRIDSR.CurrentRow.Index).Value.ToString
                CMBITEMNAME.Text = GRIDSR.Item(GITEMNAME.Index, GRIDSR.CurrentRow.Index).Value.ToString
                TXTMATERIALCODE.Text = GRIDSR.Item(GMATERIALCODE.Index, GRIDSR.CurrentRow.Index).Value.ToString
                TXTQTY.Text = GRIDSR.Item(GQTY.Index, GRIDSR.CurrentRow.Index).Value.ToString
                TXTBATCHNO.Text = GRIDSR.Item(GBATCHNO.Index, GRIDSR.CurrentRow.Index).Value.ToString
                TXTSHIPPERS.Text = GRIDSR.Item(GShippers.Index, GRIDSR.CurrentRow.Index).Value.ToString
                TXTPACKETS.Text = GRIDSR.Item(GPackets.Index, GRIDSR.CurrentRow.Index).Value.ToString
                TXTRATE.Text = Val(GRIDSR.Item(GRATE.Index, GRIDSR.CurrentRow.Index).Value)
                TXTAMOUNT.Text = Val(GRIDSR.Item(GAMOUNT.Index, GRIDSR.CurrentRow.Index).Value)

                TEMPROW = GRIDSR.CurrentRow.Index
                CMBITEMCODE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If e.KeyCode = Keys.Delete And GRIDSR.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'end of block
                GRIDSR.Rows.RemoveAt(GRIDSR.CurrentRow.Index)
                getsrno(GRIDSR)
                TOTAL()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillITEMNAME(CMBITEMNAME, EDIT, " and ITEMMASTER.ITEM_MATERIALTYPE = 'FINISHED'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then ITEMNAMEVALIDATE(CMBITEMNAME, e, Me, " and ITEMMASTER.ITEM_MATERIALTYPE = 'FINISHED'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTRATE.Validated
        If CMBITEMCODE.Text.Trim <> "" And CMBITEMNAME.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 Then
            FILLGRID()
            CALC()
        Else
            If CMBITEMCODE.Text.Trim = "" Then
                MsgBox("Enter Itemcode", MsgBoxStyle.Critical)
                CMBITEMCODE.Focus()
            ElseIf CMBITEMNAME.Text.Trim = "" Then
                MsgBox("Enter Item Name", MsgBoxStyle.Critical)
                CMBITEMNAME.Focus()
            ElseIf Val(TXTQTY.Text.Trim) = 0 Then
                MsgBox("Enter Quantity", MsgBoxStyle.Critical)
                TXTQTY.Focus()
            End If
        End If
    End Sub

    Sub CALC()
        Try
            TXTAMOUNT.Text = 0.0
            If Val(TXTQTY.Text.Trim) > 0 Then Format(Val(TXTQTY.Text.Trim) * Val(TXTRATE.Text.Trim), "0.00")
            If Val(TXTRATE.Text.Trim) > 0 Then
                TXTAMOUNT.Text = Format(Val(TXTQTY.Text.Trim) * Val(TXTRATE.Text.Trim), "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SRCHDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SRCHDATE.GotFocus
        SRCHDATE.SelectionStart = 0
    End Sub

    Private Sub SRCHDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SRCHDATE.Validating
        Try
            If SRCHDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(SRCHDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry debtors'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        If EDIT = True Then
            PRINTREPORT(TEMPSRCHNO)
        End If
    End Sub

    Private Sub cmbname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            namevalidate(CMBNAME, CMBCODE, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry debtors'", "Sundry debtors", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaleReturnChallan_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            'If ClientName = "MIDAS" Or ClientName = "YASHVI" Or ClientName = "KCRAYON" Or ClientName = "SBA" Or ClientName = "AVIS" Or ClientName = "KARAN" Or ClientName = "SMS" Or ClientName = "SAKARIA" Or ClientName = "SUPRIYA" Then TXTQTY.ReadOnly = False
            'If ClientName = "YASHVI" Then
            '    CMBPIECETYPE.TabStop = False
            '    CMBITEMNAME.TabStop = False
            '    CMBITEMCODE.TabStop = False
            '    CMBDESIGN.TabStop = False
            '    TXTGRIDREMARKS.TabStop = False
            '    CMBCOLOR.TabStop = False
            'End If

            'If ClientName = "SOFTAS" Or ClientName = "SHREENAKODA" Then
            '    TXTLOTNO.TabStop = False
            '    CMBITEMCODE.TabStop = False
            '    TXTGRIDREMARKS.TabStop = False
            '    TXTBATCHNO.TabStop = False
            '    TXTMATERIALCODE.TabStop = False
            'End If

            'If ClientName = "AVIS" Or ClientName = "KRISHNA" Then
            '    CMBITEMNAME.TabStop = False
            '    CMBITEMCODE.TabStop = False
            '    TXTGRIDREMARKS.TabStop = False
            '    CMBQTYUNIT.Text = "LUMP"
            '    CMBRACK.TabStop = False
            '    CMBPIECETYPE.TabStop = False
            '    cmbGodown.TabStop = False
            'End If

            CHKLRRECD.Enabled = ALLOWLRRECD

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            Dim DT As New DataTable
            Dim OBJCMN As New ClsCommon
            If EDIT = True Then SENDWHATSAPP(TEMPSRCHNO)
            DT = OBJCMN.Execute_Any_String("UPDATE SALERETURNCHALLAN SET SRCH_SENDWHATSAPP = 1 WHERE SRCH_NO = " & TEMPSRCHNO & " AND SRCH_YEARID = " & YearId, "", "")
            LBLWHATSAPP.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub SENDWHATSAPP(SRNO As Integer)
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            If Not CHECKWHASTAPPEXP() Then
                MsgBox("Whatsapp Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Send Whatsapp?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim WHATSAPPNO As String = ""
            Dim OBJSR As New SaleReturnDesign
            OBJSR.MdiParent = MDIMain
            'OBJSR.DIRECTPRINT = True
            OBJSR.FRMSTRING = "SALERETURNCHALLAN"
            OBJSR.DIRECTMAIL = True
            OBJSR.WHERECLAUSE = "{SALERETURNCHALLAN.SRCH_NO}=" & Val(SRNO) & " and {SALERETURNCHALLAN.SRCH_yearid}=" & YearId
            OBJSR.SALRETNO = SRNO
            OBJSR.NOOFCOPIES = 1
            OBJSR.Show()
            OBJSR.Close()

            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PARTYNAME = CMBNAME.Text.Trim
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\SALRET_" & Val(SRNO) & ".pdf")
            OBJWHATSAPP.FILENAME.Add("SALRET_" & Val(SRNO) & ".pdf")
            OBJWHATSAPP.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tstxtbillno.KeyPress, TXTFROM.KeyPress, TXTTO.KeyPress, TXTNOOFPACKETS.KeyPress, TXTSHIPPERS.KeyPress, TXTPACKETS.KeyPress, TXTBATCHNO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTQTY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTRATE.KeyPress, TXTQTY.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CMBTRANSPORTNAME_KeyDown(sender As Object, e As KeyEventArgs) Handles CMBTRANSPORTNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'"
                OBJLEDGER.ShowDialog()
                'If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBTRANSPORTNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANSPORTNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBTRANSPORTNAME.Validating
        Try
            If CMBTRANSPORTNAME.Text.Trim <> "" Then namevalidate(CMBTRANSPORTNAME, CMBCODE, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "TRANSPORT")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DTLRDATE_Validating(sender As Object, e As CancelEventArgs) Handles DTLRDATE.Validating
        Try
            If DTLRDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(DTLRDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMCODE_Enter(sender As Object, e As EventArgs) Handles CMBITEMCODE.Enter
        Try
            If CMBITEMCODE.Text.Trim = "" Then fillITEMCODE(CMBITEMCODE, EDIT, " and ITEMMASTER.ITEM_MATERIALTYPE = 'FINISHED'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMCODE_Validating(sender As Object, e As CancelEventArgs) Handles CMBITEMCODE.Validating
        Try
            If CMBITEMCODE.Text.Trim <> "" Then ITEMCODEvalidate(CMBITEMCODE, CMBITEMNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANSPORTNAME_Enter(sender As Object, e As EventArgs) Handles CMBTRANSPORTNAME.Enter
        Try
            If CMBTRANSPORTNAME.Text.Trim = "" Then fillname(CMBTRANSPORTNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSR_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDSR.CellDoubleClick
        EDITROW()
    End Sub
End Class