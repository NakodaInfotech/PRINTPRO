
Imports System.ComponentModel
Imports BL

Public Class PurchaseReturnChallan

    Dim GRIDDOUBLECLICK As Boolean
    Public EDIT As Boolean
    Public TEMPPRCHNO, TEMPROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub CMDEXIT_Click(sender As Object, e As EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub CLEAR()

        tstxtbillno.Clear()
        Ep.Clear()
        PRCHDATE.Text = Now.Date
        CMBNAME.Text = ""
        cmbGodown.Text = ""
        TXTLOTNO.Clear()
        TXTCHALLANNO.Clear()
        TXTSRNO.Text = 1
        CMBITEMNAME.Text = ""
        TXTSIZE.Clear()
        TXTWT.Clear()
        TXTQTY.Clear()
        CMBUNIT.Text = ""
        GRIDPR.RowCount = 0
        TXTREMARKS.Clear()
        lbllocked.Visible = False
        PBlock.Visible = False
        GRIDDOUBLECLICK = False
        GETMAXNO()
        LBLTOTALQTY.Text = 0
        TXTNOOFBALES.Clear()
        CMBTRANSPORTNAME.Text = ""
        PRLRDATE.Text = Now.Date
        TXTLRNO.Clear()
        TXTRATE.Clear()
        TXTAMOUNT.Clear()
        LBLTOTALAMT.Text = 0.0

    End Sub

    Sub TOTAL()
        Try
            LBLTOTALQTY.Text = 0
            LBLTOTALAMT.Text = 0.0
            For Each ROW As DataGridViewRow In GRIDPR.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(ROW.Cells(gQty.Index).EditedFormattedValue), "0")
                    ROW.Cells(GAMOUNT.Index).Value = Format(Val(ROW.Cells(gQty.Index).EditedFormattedValue) * Val(ROW.Cells(GRATE.Index).EditedFormattedValue), "0.00")
                End If
                'TXTAMOUNT.Text = Format(Val(TXTQTY.Text) * Val(TXTRATE), "0.00")
                LBLTOTALAMT.Text = Format(Val(LBLTOTALAMT.Text) + Val(ROW.Cells(GAMOUNT.Index).EditedFormattedValue), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Sub GETMAXNO()
        Try
            Dim DTTABLE As New DataTable
            DTTABLE = getmax(" isnull(max(PRCH_no),0) + 1 ", " PURCHASERETURNCHALLAN ", " and PRCH_yearid=" & YearId)
            If DTTABLE.Rows.Count > 0 Then TXTPRCHNO.Text = DTTABLE.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function ERRORVALID() As Boolean
        Try

            Dim bln As Boolean = True

            If cmbGodown.Text.Trim.Length = 0 Then
                Ep.SetError(cmbGodown, " Please Select Godown")
                bln = False
            End If

            If CMBNAME.Text.Trim.Length = 0 Then
                Ep.SetError(CMBNAME, " Please Fill Company Name ")
                bln = False
            End If


            If lbllocked.Visible = True Then
                Ep.SetError(lbllocked, "Item Used, Item Locked")
                bln = False
            End If

            If GRIDPR.RowCount = 0 Then
                Ep.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If



            If PRCHDATE.Text = "__/__/____" Then
                Ep.SetError(PRCHDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(PRCHDATE.Text) Then
                    Ep.SetError(PRCHDATE, "Date not in Accounting Year")
                    bln = False
                End If

                If Convert.ToDateTime(PRCHDATE.Text).Date < PURRETCHBLOCKDATE.Date Then
                    Ep.SetError(PRCHDATE, "Date is Blocked, Please make entries after " & Format(PURRETCHBLOCKDATE.Date, "dd/MM/yyyy"))
                    bln = False
                End If
            End If

            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    'Sub PRINTREPORT(ByVal SRNO As Integer)
    '    Try
    '        If MsgBox("Wish to Print Purchase Return?", MsgBoxStyle.YesNo) = vbYes Then
    '            Dim OBJPUR As New PurchaseInvoiceDesign
    '            OBJPUR.MdiParent = MDIMain
    '            OBJPUR.FRMSTRING = "PURRETURNCHALLAN"
    '            OBJPUR.PURRETNO = Val(SRNO)
    '            OBJPUR.WHERECLAUSE = "{PURCHASERETURNCHALLAN.PRCH_NO}=" & Val(SRNO) & " and {PURCHASERETURNCHALLAN.PRCH_yearid}=" & YearId
    '            OBJPUR.Show()
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub PurchaseReturnChallan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then CMDOK_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.KeyCode = Windows.Forms.Keys.F5 Then       'Grid Focus
                GRIDPR.Focus()
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
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseReturnChallan_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'PURCHASE RETURN'")
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

                Dim OBJSR As New ClsPurchaseReturnChallan()
                OBJSR.alParaval.Add(TEMPPRCHNO)
                OBJSR.alParaval.Add(YearId)
                Dim dttable As DataTable = OBJSR.SELECTPURCHASERETURNCHALLAN()
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTPRCHNO.Text = TEMPPRCHNO
                        TXTPRCHNO.ReadOnly = True

                        PRCHDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        CMBNAME.Text = Convert.ToString(dr("NAME"))
                        cmbGodown.Text = dr("GODOWN")
                        TXTLOTNO.Text = dr("LOTNO")
                        TXTCHALLANNO.Text = dr("CHALLANNO")

                        LBLTOTALQTY.Text = Format(Val(dr("TOTALQTY")), "0.00")

                        TXTREMARKS.Text = Convert.ToString(dr("remarks").ToString)
                        TXTNOOFBALES.Text = Val(dr("NOOFBALES"))
                        CMBTRANSPORTNAME.Text = dr("TRANSNAME")
                        TXTLRNO.Text = dr("LRNO")
                        PRLRDATE.Text = dr("LRDATE")
                        LBLTOTALAMT.Text = Format(Val(dr("TOTALAMOUNT")), "0.00")

                        'Item Grid
                        GRIDPR.Rows.Add(dr("GRIDSRNO").ToString, dr("ITEM").ToString, dr("SIZE").ToString, dr("WT").ToString, Format(Val(dr("QTY")), "0.00"), dr("UNIT").ToString, Format(Val(dr("RATE")), "0.00"), Format(Val(dr("AMOUNT")), "0.00"), dr("FROMNO"), dr("FROMSRNO"), dr("TYPE"), dr("GRIDDONE"))

                        If Convert.ToBoolean(dr("DONE")) = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                    GRIDPR.FirstDisplayedScrollingRowIndex = GRIDPR.RowCount - 1
                    TOTAL()
                    CMBNAME.Focus()
                Else
                    EDIT = False
                    CLEAR()
                End If
            End If

            ''  TXTSRNO.Text = GRIDPR.RowCount

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLCMB()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " And GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
            If cmbGodown.Text.Trim = "" Then fillGODOWN(cmbGodown, EDIT)
            If CMBITEMNAME.Text.Trim = "" Then FILLNONINVITEM(CMBITEMNAME, EDIT)
            If CMBUNIT.Text.Trim = "" Then fillUNIT(CMBUNIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbGodown_Enter(sender As Object, e As EventArgs) Handles cmbGodown.Enter
        Try
            If cmbGodown.Text.Trim = "" Then fillGODOWN(cmbGodown, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbGodown_Validating(sender As Object, e As CancelEventArgs) Handles cmbGodown.Validating
        Try
            If cmbGodown.Text.Trim <> "" Then GODOWNVALIDATE(cmbGodown, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(sender As Object, e As EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJSR As New PurchaseReturnChallanDetail
            OBJSR.MdiParent = MDIMain
            OBJSR.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In GRIDPR.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(sender As Object, e As CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDPR.RowCount = 0
                TEMPPRCHNO = Val(tstxtbillno.Text)
                If TEMPPRCHNO > 0 Then
                    EDIT = True
                    PurchaseReturnChallan_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            GRIDPR.Enabled = True

            If GRIDDOUBLECLICK = False Then
                GRIDPR.Rows.Add(Val(TXTSRNO.Text.Trim), CMBITEMNAME.Text.Trim, TXTSIZE.Text.Trim, TXTWT.Text.Trim, Format(Val(TXTQTY.Text.Trim), "0.00"), CMBUNIT.Text.Trim, Format(Val(TXTRATE.Text.Trim), "0.00"), Format(Val(TXTAMOUNT.Text.Trim), "0.00"), 0, 0, "", 0)
                getsrno(GRIDPR)

            ElseIf GRIDDOUBLECLICK = True Then
                GRIDPR.Item(gsrno.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
                GRIDPR.Item(gitemname.Index, TEMPROW).Value = CMBITEMNAME.Text.Trim
                GRIDPR.Item(GSIZE.Index, TEMPROW).Value = TXTSIZE.Text.Trim
                GRIDPR.Item(GWT.Index, TEMPROW).Value = TXTWT.Text.Trim
                GRIDPR.Item(gQty.Index, TEMPROW).Value = Val(TXTQTY.Text.Trim)
                GRIDPR.Item(GUNIT.Index, TEMPROW).Value = CMBUNIT.Text.Trim
                GRIDPR.Item(GRATE.Index, TEMPROW).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
                GRIDPR.Item(GAMOUNT.Index, TEMPROW).Value = Format(Val(TXTAMOUNT.Text.Trim), "0.00")

                GRIDDOUBLECLICK = False
            End If

            TOTAL()

            GRIDPR.FirstDisplayedScrollingRowIndex = GRIDPR.RowCount - 1
            CMBITEMNAME.Text = ""
            TXTSIZE.Clear()
            TXTWT.Clear()
            TXTRATE.Clear()
            TXTQTY.Clear()
            CMBUNIT.Text = ""
            TXTRATE.Clear()
            TXTAMOUNT.Clear()


            TXTSRNO.Text = GRIDPR.RowCount + 1

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPR_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPR.CellDoubleClick
        EDITROW()
    End Sub



    Private Sub tooldelete_Click(sender As Object, e As EventArgs) Handles tooldelete.Click
        Try
            Call CMDDELETE_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub CMBUNIT_Enter(sender As Object, e As EventArgs) Handles CMBUNIT.Enter
        Try
            If CMBUNIT.Text.Trim = "" Then fillUNIT(CMBUNIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUNIT_Validating(sender As Object, e As CancelEventArgs) Handles CMBUNIT.Validating
        Try
            If CMBUNIT.Text.Trim <> "" Then unitvalidate(CMBUNIT, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSR_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDPR.CellValidating
        Try
            Dim colNum As Integer = GRIDPR.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GWT.Index, gQty.Index, GRATE.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDPR.CurrentCell.Value = Nothing Then GRIDPR.CurrentCell.Value = "0.00"
                        GRIDPR.CurrentCell.Value = Convert.ToDecimal(GRIDPR.Item(colNum, e.RowIndex).Value)
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
            If GRIDPR.CurrentRow.Index >= 0 And GRIDPR.Item(gsrno.Index, GRIDPR.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDPR.Item(gsrno.Index, GRIDPR.CurrentRow.Index).Value.ToString
                CMBITEMNAME.Text = GRIDPR.Item(gitemname.Index, GRIDPR.CurrentRow.Index).Value.ToString
                TXTSIZE.Text = GRIDPR.Item(GSIZE.Index, GRIDPR.CurrentRow.Index).Value.ToString
                TXTWT.Text = GRIDPR.Item(GWT.Index, GRIDPR.CurrentRow.Index).Value.ToString
                TXTQTY.Text = GRIDPR.Item(gQty.Index, GRIDPR.CurrentRow.Index).Value.ToString
                CMBUNIT.Text = GRIDPR.Item(GUNIT.Index, GRIDPR.CurrentRow.Index).Value.ToString
                TXTRATE.Text = GRIDPR.Item(GRATE.Index, GRIDPR.CurrentRow.Index).Value.ToString
                TXTAMOUNT.Text = GRIDPR.Item(GAMOUNT.Index, GRIDPR.CurrentRow.Index).Value.ToString
                TEMPROW = GRIDPR.CurrentRow.Index
                CMBITEMNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPR.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDPR.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'end of block
                GRIDPR.Rows.RemoveAt(GRIDPR.CurrentRow.Index)
                getsrno(GRIDPR)
                TOTAL()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub










    'Private Sub cmbGodown_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    Try
    '        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
    '        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

    '        If e.KeyCode = Keys.F1 Then
    '            Dim OBJGODOWN As New SelectGodown
    '            OBJGODOWN.FRMSTRING = "GODOWN"
    '            OBJGODOWN.ShowDialog()
    '            If OBJGODOWN.TEMPNAME <> "" Then cmbGodown.Text = OBJGODOWN.TEMPNAME
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub




    Private Sub txtremarks_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTREMARKS.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJREMARKS As New SelectRemarks
                OBJREMARKS.FRMSTRING = "NARRATION"
                OBJREMARKS.ShowDialog()
                If OBJREMARKS.TEMPNAME <> "" Then TXTREMARKS.Text = OBJREMARKS.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub PRCHDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PRCHDATE.GotFocus
        PRCHDATE.SelectionStart = 0
    End Sub

    Private Sub SRCHDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Try
            If PRCHDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(PRCHDATE.Text, TEMP) Then
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

    'Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs)
    '    If EDIT = True Then
    '        PRINTREPORT(TEMPPRCHNO)
    '    End If
    'End Sub

    Private Sub cmbname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            namevalidate(CMBNAME, CMBCODE, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'", "Sundry Creditors", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tstxtbillno.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    '    Private Sub CMDSELECTSTOCK_Click(sender As Object, e As EventArgs)
    '        Try
    '            Dim DTJO As New DataTable
    '            Dim OBJSELECTGDN As New SelectStockGDN
    '            OBJSELECTGDN.GODOWN = cmbGodown.Text.Trim
    '            If ALLOWPACKINGSLIP = True And ClientName <> "MARKIN" Then OBJSELECTGDN.FILTER = " AND BARCODE = ''"
    '            OBJSELECTGDN.ShowDialog()
    '            DTJO = OBJSELECTGDN.DT
    '            If DTJO.Rows.Count > 0 Then
    '                For Each DTROWPS As DataRow In DTJO.Rows

    '                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
    '                    For Each ROW As DataGridViewRow In GRIDPR.Rows
    '                        If DTROWPS("BARCODE") <> "" And LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(DTROWPS("BARCODE")) Then GoTo LINE1
    '                    Next

    '                    If ClientName = "BARKHA" Or ClientName = "MAHAJAN" Or ClientName = "SHUBHI" Or ClientName = "SUBHLAXMI" Then
    '                        GRIDPR.Rows.Add(0, DTROWPS("PIECETYPE"), DTROWPS("ITEMNAME"), DTROWPS("QUALITY"), DTROWPS("DESIGNNO"), "", DTROWPS("COLOR"), DTROWPS("BALENO"), Val(DTROWPS("CUT")), Val(DTROWPS("PCS")), DTROWPS("UNIT"), Format(Val(DTROWPS("MTRS")), "0.00"), 0, "Mtrs", 0, DTROWPS("BARCODE"), Val(DTROWPS("FROMNO")), Val(DTROWPS("FROMSRNO")), DTROWPS("TYPE"), 0)
    '                    Else
    '                        GRIDPR.Rows.Add(0, DTROWPS("PIECETYPE"), DTROWPS("ITEMNAME"), DTROWPS("QUALITY"), DTROWPS("DESIGNNO"), "", DTROWPS("COLOR"), DTROWPS("BALENO"), 0, Val(DTROWPS("PCS")), DTROWPS("UNIT"), Format(Val(DTROWPS("MTRS")), "0.00"), 0, "Mtrs", 0, DTROWPS("BARCODE"), Val(DTROWPS("FROMNO")), Val(DTROWPS("FROMSRNO")), DTROWPS("TYPE"), 0)
    '                    End If
    '                    If ClientName <> "AVIS" Then TXTLOTNO.Text = DTROWPS("LOTNO")
    'LINE1:
    '                Next
    '                getsrno(GRIDPR)
    '                TOTAL()
    '                GRIDPR.FirstDisplayedScrollingRowIndex = GRIDPR.RowCount - 1
    '            End If
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Sub



    Private Sub CMBTRANSPORTNAME_Enter(sender As Object, e As EventArgs) Handles CMBTRANSPORTNAME.Enter
        Try
            If CMBTRANSPORTNAME.Text.Trim = "" Then fillname(CMBTRANSPORTNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT' ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(sender As Object, e As EventArgs) Handles CMDOK.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            Ep.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(Val(TXTPRCHNO.Text.Trim))
            alParaval.Add(Format(Convert.ToDateTime(PRCHDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(cmbGodown.Text.Trim)
            alParaval.Add(TXTLOTNO.Text.Trim)
            alParaval.Add(TXTCHALLANNO.Text.Trim)
            alParaval.Add(Val(LBLTOTALQTY.Text))
            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(Val(TXTNOOFBALES.Text.Trim))
            alParaval.Add(CMBTRANSPORTNAME.Text.Trim)
            alParaval.Add(TXTLRNO.Text.Trim)
            alParaval.Add(PRLRDATE.Text)
            alParaval.Add(Val(LBLTOTALAMT.Text.Trim))
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim GRIDSRNO As String = ""
            Dim ITEMNAME As String = ""
            Dim SIZE As String = ""
            Dim WT As String = ""
            Dim QTY As String = ""
            Dim UNIT As String = ""
            Dim RATE As String = ""
            Dim AMOUNT As String = ""
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim TYPE As String = ""
            Dim DONE As String = ""



            For Each row As Windows.Forms.DataGridViewRow In GRIDPR.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(row.Cells(gsrno.Index).Value)
                        ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                        SIZE = row.Cells(GSIZE.Index).Value.ToString
                        WT = row.Cells(GWT.Index).Value.ToString
                        QTY = Val(row.Cells(gQty.Index).Value)
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        RATE = row.Cells(GRATE.Index).Value
                        AMOUNT = row.Cells(GAMOUNT.Index).Value
                        FROMNO = row.Cells(GFROMNO.Index).Value
                        If row.Cells(GFROMSRNO.Index).Value <> Nothing Then
                            FROMSRNO = row.Cells(GFROMSRNO.Index).Value
                        Else
                            FROMSRNO = 0
                        End If
                        TYPE = row.Cells(GTYPE.Index).Value
                        If row.Cells(GDONE.Index).Value = True Then DONE = 1 Else DONE = 0

                    Else

                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(gsrno.Index).Value)
                        ITEMNAME = ITEMNAME & "|" & row.Cells(gitemname.Index).Value
                        SIZE = SIZE & "|" & row.Cells(GSIZE.Index).Value.ToString
                        WT = WT & "|" & row.Cells(GWT.Index).Value.ToString
                        QTY = QTY & "|" & Val(row.Cells(gQty.Index).Value)
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value
                        RATE = RATE & "|" & row.Cells(GRATE.Index).Value
                        AMOUNT = AMOUNT & "|" & row.Cells(GAMOUNT.Index).Value
                        FROMNO = FROMNO & "|" & row.Cells(GFROMNO.Index).Value
                        If row.Cells(GFROMSRNO.Index).Value <> Nothing Then
                            FROMSRNO = FROMSRNO & "|" & Val(row.Cells(GFROMSRNO.Index).Value)
                        Else
                            FROMSRNO = FROMSRNO & "|" & " 0"
                        End If
                        TYPE = TYPE & "|" & row.Cells(GTYPE.Index).Value
                        If row.Cells(GDONE.Index).Value = True Then
                            DONE = DONE & "|" & "1"
                        Else
                            DONE = DONE & "|" & "0"
                        End If

                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(ITEMNAME)
            alParaval.Add(SIZE)
            alParaval.Add(WT)
            alParaval.Add(QTY)
            alParaval.Add(UNIT)
            alParaval.Add(RATE)
            alParaval.Add(AMOUNT)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(TYPE)
            alParaval.Add(DONE)



            Dim OBJSR As New ClsPurchaseReturnChallan()
            OBJSR.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = OBJSR.SAVE()
                MsgBox("Details Added")
                ' TXTPRCHNO.Text = Val(DTTABLE.Rows(0).Item(0))
                TEMPPRCHNO = Val(DTTABLE.Rows(0).Item(0))

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPPRCHNO)
                Dim IntResult As Integer = OBJSR.UPDATE()
                MsgBox("Details Updated")
            End If
            '   PRINTREPORT(TEMPPRCHNO)

            EDIT = False
            CLEAR()
            CMBNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub toolprevious_Click(sender As Object, e As EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDPR.RowCount = 0
LINE1:
            TEMPPRCHNO = Val(TXTPRCHNO.Text) - 1
            If TEMPPRCHNO > 0 Then
                EDIT = True
                PurchaseReturnChallan_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDPR.RowCount = 0 And TEMPPRCHNO > 1 Then
                TXTPRCHNO.Text = TEMPPRCHNO
                GoTo LINE1
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub toolnext_Click(sender As Object, e As EventArgs) Handles toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            GRIDPR.RowCount = 0
LINE1:
            TEMPPRCHNO = Val(TXTPRCHNO.Text) + 1
            GETMAXNO()
            Dim MAXNO As Integer = TXTPRCHNO.Text.Trim
            CLEAR()
            If Val(TXTPRCHNO.Text) - 1 >= TEMPPRCHNO Then
                EDIT = True
                PurchaseReturnChallan_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDPR.RowCount = 0 And TEMPPRCHNO < MAXNO Then
                TXTPRCHNO.Text = TEMPPRCHNO
                GoTo LINE1
            End If
        Catch ex As Exception
            Throw ex
        End Try
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
                '  If OBJLEDGER.TEMPNAME <> "" Then cmbtrans.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub CMDDELETE_Click(sender As Object, e As EventArgs) Handles CMDDELETE.Click
        Try
            Dim IntResult As Integer
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Purchase Return Challan Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Delete Purchase Return Challan?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim alParaval As New ArrayList
                alParaval.Add(Val(TXTPRCHNO.Text.Trim))
                alParaval.Add(Userid)
                alParaval.Add(YearId)

                Dim OBJSR As New ClsPurchaseReturnChallan()
                OBJSR.alParaval = alParaval
                IntResult = OBJSR.DELETE()
                MsgBox("Purchase Return Challan Deleted")
                CLEAR()
                EDIT = False

            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(sender As Object, e As EventArgs) Handles CMDCLEAR.Click
        CLEAR()
        EDIT = False
        CMBNAME.Focus()
    End Sub

    Private Sub PRLRDATE_Validating(sender As Object, e As CancelEventArgs) Handles PRLRDATE.Validating
        Try
            If PRLRDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(PRLRDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    'Private Sub TXTAMOUNT_Validated(sender As Object, e As EventArgs) Handles TXTAMOUNT.Validated
    '    Try
    '        If CMBITEMNAME.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 And CMBUNIT.Text.Trim <> "" Then
    '            fillgrid()
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub CMBITEMNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then NONINVITEMVALIDATE(CMBITEMNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTSTOCK_Click(sender As Object, e As EventArgs) Handles CMDSELECTSTOCK.Click
        Try

            Dim DTTABLE As New DataTable
            Dim OBJSELECTGDN As New SelectStock
            OBJSELECTGDN.GODOWN = cmbGodown.Text.Trim
            OBJSELECTGDN.ShowDialog()
            DTTABLE = OBJSELECTGDN.DT

            If DTTABLE.Rows.Count > 0 Then
                For Each dr As DataRow In DTTABLE.Rows
                    GRIDPR.Rows.Add(0, dr("ITEMNAME"), dr("PAPERGSM"), Format(Val(dr("WT")), "0.00"), Format(Val(dr("QTY")), "0.00"), dr("UNIT"), 0, 0, 0, 0, "", 0)
                Next
                GRIDPR.FirstDisplayedScrollingRowIndex = GRIDPR.RowCount - 1
                getsrno(GRIDPR)
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Enter(sender As Object, e As EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then FILLNONINVITEM(CMBITEMNAME, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANSPORTNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBTRANSPORTNAME.Validating
        Try
            If CMBTRANSPORTNAME.Text.Trim <> "" Then namevalidate(CMBTRANSPORTNAME, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'  AND LEDGERS.ACC_TYPE = 'TRANSPORT'", "SUNDRY CREDITORS", "TRANSPORT")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_Validated(sender As Object, e As EventArgs) Handles TXTRATE.Validated
        TOTAL()
        If CMBITEMNAME.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 And CMBUNIT.Text.Trim <> "" Then
            fillgrid()
            CMBITEMNAME.Focus()
        End If
    End Sub

    Private Sub TXTQTY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTQTY.KeyPress
        numkeypress(e, sender, Me)
    End Sub
End Class