Imports BL
Public Class OpeningPurchaseOrder

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK, gridUPLOADDoubleClick As Boolean
    Dim TEMPROW, PURREGID As Integer
    Dim TEMPPARTYBILLNO, TEMPFORM As String
    Public EDIT As Boolean
    Public TEMPPONO As Integer
    Public frmstring As String
    Dim PURREGABBR, PURREGINITIAL As String
    Dim tempUPLOADrow As Integer

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Sub CLEAR()

        tstxtbillno.Clear()
        TXTPONO.Clear()
        DTPODATE.Value = Mydate
        CMBNAME.Text = ""
        TXTDELDAYS.Clear()
        DTDELDATE.Value = Mydate
        TXTSHEETSPERREAM.Text = 500
        txtremarks.Clear()

        gridbill.RowCount = 0

        TXTSRNO.Clear()
        CMBNONINVITEM.Text = ""
        txtsize.Clear()
        txtwt.Clear()
        txtqty.Clear()
        CMBUNIT.Text = ""
        txtrate.Clear()
        txtamount.Clear()
        TXTDESC.Clear()

        TXTSRNO.Text = 1

        GETMAX_PO_NO()
        EP.Clear()
        lbllocked.Visible = False
        PBlock.Visible = False
        LBLCLOSED.Visible = False

        lbltotalqty.Text = 0.0
        lbltotalamt.Text = 0.0

        GRIDDOUBLECLICK = False
        gridUPLOADDoubleClick = False

        TXTUPLOADSRNO.Text = 1
        txtuploadremarks.Clear()
        txtuploadname.Clear()
        PBSOFTCOPY.Image = Nothing
        TXTIMGPATH.Clear()
        gridupload.RowCount = 0


        If gridbill.RowCount > 0 Then
            TXTSRNO.Text = Val(gridbill.Rows(gridbill.RowCount - 1).Cells(0).Value) + 1
        Else
            TXTSRNO.Text = 1
        End If

    End Sub

    Sub GETMAX_PO_NO()
        Dim DTTABLE As DataTable = getmax(" ISNULL(MAX(OPO_NO),0) + 1 ", " OPENINGPURCHASEORDER ", " AND OPO_YEARID=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTPONO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        EDIT = False
        CMBNAME.Focus()
    End Sub

    Private Sub PurchaseOrder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                'If errorvalid() = True Then
                '    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                '    If tempmsg = vbYes Then cmdok_Click(sender, e)
                'End If
                Me.Close()
            ElseIf e.KeyCode = Keys.F8 Then
                gridbill.Focus()
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
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        If CMBNONINVITEM.Text.Trim = "" Then FILLNONINVITEM(CMBNONINVITEM, EDIT)
        'If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        If CMBUNIT.Text.Trim = "" Then fillUNIT(CMBUNIT)

    End Sub

    Private Sub PurchaseOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
                Dim OBJPONO As New ClsOpeningPurchaseOrder

                OBJPONO.alParaval.Add(TEMPPONO)
                OBJPONO.alParaval.Add(CmpId)
                OBJPONO.alParaval.Add(YearId)
                DT = OBJPONO.selectopningpurchaseorder()

                If DT.Rows.Count > 0 Then

                    CMBNAME.Focus()

                    TXTPONO.Text = TEMPPONO
                    DTPODATE.Value = DT.Rows(0).Item("DATE")

                    CMBNAME.Text = DT.Rows(0).Item("NAME").ToString
                    'CMBNAME.Enabled = False
                    TXTDELDAYS.Text = DT.Rows(0).Item("DELDAYS")
                    DTDELDATE.Value = DT.Rows(0).Item("DELDATE")
                    TXTSHEETSPERREAM.Text = Val(DT.Rows(0).Item("SHEETSPERREAM"))
                    txtremarks.Text = DT.Rows(0).Item("REMARKS").ToString
                    lbltotalqty.Text = DT.Rows(0).Item("TOTALQTY")
                    lbltotalamt.Text = DT.Rows(0).Item("TOTALAMT")


                    'ITEM GRID
                    For Each ROW As DataRow In DT.Rows
                        gridbill.Rows.Add(Val(ROW("SRNO")), ROW("ITEMNAME"), ROW("SIZE"), Format(Val(ROW("WT")), "0.00"), Format(Val(ROW("QTY")), "0.00"), ROW("UNIT"), Format(Val(ROW("RATE")), "0.000"), Format(Val(ROW("AMOUNT")), "0.000"), ROW("DESC"), Format(Val(ROW("OUTQTY")), "0.00"))
                        If (ROW("OUTQTY")) > 0 Then
                            lbllocked.Visible = True
                            gridbill.Rows(gridbill.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                        End If
                        If ROW("CLOSED") = True Then
                            LBLCLOSED.Visible = True
                            gridbill.Rows(gridbill.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGreen
                        End If
                    Next

                    Dim OBJCMNN As New ClsCommon
                    Dim DTTABLE As DataTable = OBJCMNN.search("ISNULL(OPO_UPSRNO, 0) AS SRNO, ISNULL(OPO_UPREMARKS, '') AS REMARKS, ISNULL(OPO_UPNAME, '') AS NAME, OPO_IMGPATH AS IMGPATH", "", "OPENINGPURCHASEORDER_UPLOAD", " AND OPENINGPURCHASEORDER_UPLOAD.OPO_NO= " & TEMPPONO & "  AND OPENINGPURCHASEORDER_UPLOAD.OPO_YEARID = " & YearId & " ORDER BY OPENINGPURCHASEORDER_UPLOAD.OPO_UPSRNO")
                    If DTTABLE.Rows.Count > 0 Then
                        For Each DTR As DataRow In DTTABLE.Rows
                            gridupload.Rows.Add(DTR("SRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                        Next
                    End If
                End If


                CMBNAME.Focus()
                total()
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

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(DTPODATE.Value.Date)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(TXTDELDAYS.Text.Trim)
            alParaval.Add(DTDELDATE.Value.Date)
            alParaval.Add(Val(TXTSHEETSPERREAM.Text.Trim))
            alParaval.Add(Val(lbltotalqty.Text.Trim))
            alParaval.Add(Val(lbltotalamt.Text.Trim))
            alParaval.Add(txtremarks.Text.Trim)

            Dim ITEMSRNO As String = ""
            Dim ITEMNAME As String = ""
            Dim SIZE As String = ""
            Dim WT As String = ""
            Dim QTY As String = ""
            Dim UNIT As String = ""
            Dim RATE As String = ""
            Dim AMOUNT As String = ""
            Dim DESC As String = ""
            Dim OUTQTY As String = ""
            Dim CLOSED As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridbill.Rows
                If row.Cells(gsrno.Index).Value <> Nothing Then
                    If ITEMSRNO = "" Then
                        ITEMSRNO = row.Cells(gsrno.Index).Value
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                        SIZE = row.Cells(GSIZE.Index).Value.ToString
                        WT = Val(row.Cells(GWT.Index).Value)
                        QTY = Val(row.Cells(GQTY.Index).Value)
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        RATE = Val(row.Cells(GRATE.Index).Value)
                        AMOUNT = Val(row.Cells(GAMT.Index).Value)
                        DESC = row.Cells(GDESC.Index).Value.ToString
                        OUTQTY = Val(row.Cells(GOUTQTY.Index).Value)
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = 1 Else CLOSED = 0

                    Else
                        ITEMSRNO = ITEMSRNO & "|" & row.Cells(gsrno.Index).Value
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GITEMNAME.Index).Value.ToString
                        SIZE = SIZE & "|" & row.Cells(GSIZE.Index).Value.ToString
                        WT = WT & "|" & Val(row.Cells(GWT.Index).Value)
                        QTY = QTY & "|" & Val(row.Cells(GQTY.Index).Value)
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value.ToString
                        RATE = RATE & "|" & Val(row.Cells(GRATE.Index).Value)
                        AMOUNT = AMOUNT & "|" & Val(row.Cells(GAMT.Index).Value)
                        DESC = DESC & "|" & row.Cells(GDESC.Index).Value.ToString
                        OUTQTY = OUTQTY & "|" & Val(row.Cells(GOUTQTY.Index).Value)
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = CLOSED & "|" & "1" Else CLOSED = CLOSED & "|" & "0"

                    End If
                End If
            Next

            alParaval.Add(ITEMSRNO)
            alParaval.Add(ITEMNAME)
            alParaval.Add(SIZE)
            alParaval.Add(WT)
            alParaval.Add(QTY)
            alParaval.Add(UNIT)
            alParaval.Add(RATE)
            alParaval.Add(AMOUNT)
            alParaval.Add(DESC)
            alParaval.Add(OUTQTY)
            alParaval.Add(CLOSED)

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim OBJPO As New ClsOpeningPurchaseOrder
            OBJPO.alParaval = alParaval


            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DT As DataTable = OBJPO.save()
                TEMPPONO = DT.Rows(0).Item(0)
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPPONO)
                IntResult = OBJPO.update()
                EDIT = False
                MsgBox("Details Updated")
            End If
            PRINTREPORT()
            If gridupload.RowCount > 0 Then SAVEUPLOAD()
            CLEAR()
            CMBNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub PRINTREPORT()
        Try
            If MsgBox("Wish to Print PO?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim OBJPRINT As New PODesign
            OBJPRINT.MdiParent = MDIMain
            OBJPRINT.FRMSTRING = "PO"
            OBJPRINT.WHERECLAUSE = " {OPENINGPURCHASEORDER.OPO_NO}=" & TEMPPONO & " and {OPENINGPURCHASEORDER.OPO_yearid}=" & YearId
            OBJPRINT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SAVEUPLOAD()
        Try
            Dim OBJORDER As New ClsOpeningPurchaseOrder

            For Each ROW As Windows.Forms.DataGridViewRow In gridupload.Rows
                Dim MS As New IO.MemoryStream
                Dim ALPARAVAL As New ArrayList
                If ROW.Cells(GUSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(TEMPPONO)
                    ALPARAVAL.Add(ROW.Cells(GUSRNO.Index).Value)
                    ALPARAVAL.Add(ROW.Cells(GUREMARKS.Index).Value)
                    ALPARAVAL.Add(ROW.Cells(GUNAME.Index).Value)

                    PBSOFTCOPY.Image = ROW.Cells(GUIMGPATH.Index).Value
                    PBSOFTCOPY.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    ALPARAVAL.Add(MS.ToArray)
                    ALPARAVAL.Add(YearId)

                    OBJORDER.alParaval = ALPARAVAL
                    Dim INTRESULT As Integer = OBJORDER.SAVEUPLOAD()
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillupload()

        If gridUPLOADDoubleClick = False Then
            gridupload.Rows.Add(Val(TXTUPLOADSRNO.Text.Trim), txtuploadremarks.Text.Trim, txtuploadname.Text.Trim, PBSOFTCOPY.Image)
            getsrno(gridupload)
        ElseIf gridUPLOADDoubleClick = True Then

            gridupload.Item(GUSRNO.Index, tempUPLOADrow).Value = Val(TXTUPLOADSRNO.Text.Trim)
            gridupload.Item(GUREMARKS.Index, tempUPLOADrow).Value = txtuploadremarks.Text.Trim
            gridupload.Item(GUNAME.Index, tempUPLOADrow).Value = txtuploadname.Text.Trim
            gridupload.Item(GUIMGPATH.Index, tempUPLOADrow).Value = PBSOFTCOPY.Image

            gridUPLOADDoubleClick = False
        End If
        gridupload.FirstDisplayedScrollingRowIndex = gridupload.RowCount - 1

        TXTUPLOADSRNO.Text = gridupload.RowCount + 1
        txtuploadremarks.Clear()
        txtuploadname.Clear()
        PBSOFTCOPY.Image = Nothing
        TXTIMGPATH.Clear()

        txtuploadremarks.Focus()
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, "Please Enter Name")
            bln = False
        End If

        If gridbill.RowCount = 0 Then
            EP.SetError(CMBNAME, "Please Enter Item Details")
            bln = False
        End If

        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, "Rec/Return Made , Delete Rec/Return First")
            bln = False
        End If

        If LBLCLOSED.Visible = True Then
            EP.SetError(LBLCLOSED, "PO Closed")
            bln = False
        End If

        If Not datecheck(DTPODATE.Value) Then
            EP.SetError(DTPODATE, "Date not in Accounting Year")
            bln = False
        End If

        Return bln
    End Function

    Private Sub TXTDESC_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTDESC.Validating
        Try
            If CMBNONINVITEM.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 And CMBUNIT.Text.Trim <> "" Then
                fillgrid()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()

        gridbill.Enabled = True

        If GRIDDOUBLECLICK = False Then
            gridbill.Rows.Add(Val(TXTSRNO.Text.Trim), CMBNONINVITEM.Text.Trim, txtsize.Text.Trim, Format(Val(txtwt.Text.Trim), "0.00"), Format(Val(txtqty.Text.Trim), "0.00"), CMBUNIT.Text.Trim, Format(Val(txtrate.Text.Trim), "0.000"), Format(Val(txtamount.Text.Trim), "0.000"), TXTDESC.Text.Trim, 0, 0)
            getsrno(gridbill)
        ElseIf GRIDDOUBLECLICK = True Then
            gridbill.Item(gsrno.Index, TEMPROW).Value = Val(TXTSRNO.Text)
            gridbill.Item(GITEMNAME.Index, TEMPROW).Value = CMBNONINVITEM.Text
            gridbill.Item(GSIZE.Index, TEMPROW).Value = txtsize.Text
            gridbill.Item(GWT.Index, TEMPROW).Value = Format(Val(txtwt.Text), "0.00")
            gridbill.Item(GQTY.Index, TEMPROW).Value = Format(Val(txtqty.Text), "0.00")
            gridbill.Item(GUNIT.Index, TEMPROW).Value = CMBUNIT.Text
            gridbill.Item(GRATE.Index, TEMPROW).Value = Format(Val(txtrate.Text), "0.000")
            gridbill.Item(GAMT.Index, TEMPROW).Value = Format(Val(txtamount.Text), "0.000")
            gridbill.Item(GDESC.Index, TEMPROW).Value = TXTDESC.Text.Trim
            GRIDDOUBLECLICK = False
        End If
        total()
        gridbill.FirstDisplayedScrollingRowIndex = gridbill.RowCount - 1

        CMBNONINVITEM.Text = ""
        CMBUNIT.Text = ""
        txtsize.Clear()
        txtwt.Clear()
        txtqty.Clear()
        txtrate.Clear()
        txtamount.Clear()
        TXTDESC.Clear()
        TXTSRNO.Text = Val(gridbill.RowCount)
        CMBNONINVITEM.Focus()

    End Sub

    Private Sub TXTSRNO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTSRNO.Enter
        If GRIDDOUBLECLICK = False Then
            If gridbill.RowCount > 0 Then
                TXTSRNO.Text = Val(gridbill.Rows(gridbill.RowCount - 1).Cells(gsrno.Index).Value) + 1
            Else
                TXTSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, txtadd, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTs'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDELDAYS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDELDAYS.KeyPress
        numkeypress(e, TXTDELDAYS, Me)
    End Sub

    Sub total()

        lbltotalqty.Text = "0.00"
        lbltotalamt.Text = "0.00"

        For Each row As DataGridViewRow In gridbill.Rows
            lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(row.Cells(GQTY.Index).EditedFormattedValue), "0.00")
            lbltotalamt.Text = Format(Val(lbltotalamt.Text) + Val(row.Cells(GAMT.Index).EditedFormattedValue), "0.000")
        Next

    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress
        numdot(e, txtqty, Me)
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrate.KeyPress
        numdot(e, txtrate, Me)
    End Sub

    Private Sub gridbill_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridbill.CellDoubleClick
        EDITROW()
    End Sub

    Sub EDITROW()
        Try
            If gridbill.CurrentRow.Index >= 0 And gridbill.Item(gsrno.Index, gridbill.CurrentRow.Index).Value <> Nothing Then
                If (gridbill.Rows(gridbill.CurrentRow.Index).Cells(GOUTQTY.Index).Value) > 0 Then
                    MsgBox("Order Locked!", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If Convert.ToBoolean(gridbill.Rows(gridbill.CurrentRow.Index).Cells(GCLOSED.Index).Value) = True Then
                    MsgBox("Order Closed", MsgBoxStyle.Critical)
                    Exit Sub
                End If


                GRIDDOUBLECLICK = True
                TXTSRNO.Text = gridbill.Item(gsrno.Index, gridbill.CurrentRow.Index).Value
                CMBNONINVITEM.Text = gridbill.Item(GITEMNAME.Index, gridbill.CurrentRow.Index).Value.ToString
                txtsize.Text = gridbill.Item(GSIZE.Index, gridbill.CurrentRow.Index).Value.ToString
                txtwt.Text = gridbill.Item(GWT.Index, gridbill.CurrentRow.Index).Value
                txtqty.Text = gridbill.Item(GQTY.Index, gridbill.CurrentRow.Index).Value
                CMBUNIT.Text = gridbill.Item(GUNIT.Index, gridbill.CurrentRow.Index).Value.ToString
                txtrate.Text = gridbill.Item(GRATE.Index, gridbill.CurrentRow.Index).Value
                txtamount.Text = gridbill.Item(GAMT.Index, gridbill.CurrentRow.Index).Value
                TXTDESC.Text = gridbill.Item(GDESC.Index, gridbill.CurrentRow.Index).Value.ToString

                TEMPROW = gridbill.CurrentRow.Index
                CMBNONINVITEM.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try

LINE1:
            TEMPPONO = Val(TXTPONO.Text) - 1
Line2:
            If TEMPPONO > 0 Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" OPO_NO ", "", "  OPENINGPURCHASEORDER ", " AND  OPO_NO = " & TEMPPONO & " AND OPO_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    EDIT = True
                    PurchaseOrder_Load(sender, e)
                Else
                    TEMPPONO = Val(TEMPPONO - 1)
                    GoTo Line2
                End If
            Else
                CLEAR()
                EDIT = False
            End If

            If gridbill.RowCount = 0 And TEMPPONO > 1 Then
                TXTPONO.Text = TEMPPONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            gridbill.RowCount = 0
LINE1:
            TEMPPONO = Val(TXTPONO.Text) + 1
            GETMAX_PO_NO()
            Dim MAXNO As Integer = TXTPONO.Text.Trim
            CLEAR()
            If Val(TXTPONO.Text) - 1 >= TEMPPONO Then
                EDIT = True
                PurchaseOrder_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If gridbill.RowCount = 0 And TEMPPONO < MAXNO Then
                TXTPONO.Text = TEMPPONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tstxtbillno.KeyPress
        numkeypress(e, tstxtbillno, Me)
    End Sub

    Private Sub tstxtbillno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstxtbillno.Validated
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            gridbill.RowCount = 0
            TEMPPONO = Val(tstxtbillno.Text)
            If TEMPPONO > 0 Then
                EDIT = True
                PurchaseOrder_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
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

            Dim OBJPO As New OpeningPurchaseOrderDetails
            OBJPO.MdiParent = MDIMain
            OBJPO.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNONINVITEM_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNONINVITEM.Enter
        Try
            If CMBNONINVITEM.Text.Trim = "" Then FILLNONINVITEM(CMBNONINVITEM, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNONINVITEM_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNONINVITEM.Validating
        Try
            If CMBNONINVITEM.Text.Trim <> "" Then NONINVITEMVALIDATE(CMBNONINVITEM, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNONINVITEM_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNONINVITEM.Validated
        Try
            If CMBNONINVITEM.Text.Trim = "" Then txtremarks.Focus() Else WTCALC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub WTCALC()
        Try
            If LCase(CMBUNIT.Text.Trim) = "reams" Then
                'get SIZE AND GSM FROM NONINV MASTER AND CALC WT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(NONINV_LENGTH,0) AS LENGTH, ISNULL(NONINV_WIDTH,0) AS WIDTH, ISNULL(NONINV_GSM,0) AS GSM ", "", " NONINVITEMMASTER ", " AND NONINV_NAME = '" & CMBNONINVITEM.Text.Trim & "' AND NONINV_YEARID = " & YearId)
                If Val(DT.Rows(0).Item("LENGTH")) > 0 And Val(DT.Rows(0).Item("WIDTH")) > 0 And Val(DT.Rows(0).Item("GSM")) > 0 Then
                    txtwt.Text = Format(((((Val(DT.Rows(0).Item("LENGTH")) * Val(DT.Rows(0).Item("WIDTH")) * Val(DT.Rows(0).Item("GSM"))) / 3100) / 500) * Val(TXTSHEETSPERREAM.Text.Trim)) * (Val(txtqty.Text.Trim)), "0.000")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALC()
        Try
            If LCase(CMBUNIT.Text.Trim) = "reams" Then txtamount.Text = Format(Val(txtwt.Text.Trim) * Val(txtrate.Text.Trim), "0.000") Else txtamount.Text = Format(Val(txtqty.Text.Trim) * Val(txtrate.Text.Trim), "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtqty_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqty.Validated
        WTCALC()
        CALC()
    End Sub

    Private Sub txtrate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtrate.Validating
        WTCALC()
        CALC()
    End Sub

    Private Sub TXTDELDAYS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTDELDAYS.Validating
        Try
            If (Val(TXTDELDAYS.Text.Trim)) > 0 Then DTDELDATE.Value = DateAdd(DateInterval.Day, Val(TXTDELDAYS.Text.Trim), DTPODATE.Value.Date)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DTDELDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DTDELDATE.Validating
        Try
            If DTDELDATE.Value.Date < DTPODATE.Value.Date Then
                MsgBox("Enter Proper Date !")
                e.Cancel = True
            End If
            TXTDELDAYS.Clear()
            TXTDELDAYS.Text = DTDELDATE.Value.Date.Subtract(DTPODATE.Value.Date).Days
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtwt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtwt.KeyPress
        numdot(e, txtwt, Me)
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(e, sender)
    End Sub

    Private Sub CMDUPLOAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDUPLOAD.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        TXTIMGPATH.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If TXTIMGPATH.Text.Trim.Length <> 0 Then PBSOFTCOPY.ImageLocation = TXTIMGPATH.Text.Trim
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If gridupload.SelectedRows.Count > 0 Then
                Dim objVIEW As New ViewImage
                objVIEW.pbsoftcopy.Image = PBSOFTCOPY.Image
                objVIEW.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREMOVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREMOVE.Click
        Try
            PBSOFTCOPY.Image = Nothing
            TXTIMGPATH.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtuploadname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuploadname.Validating
        Try
            If txtuploadremarks.Text.Trim <> "" And txtuploadname.Text.Trim <> "" And PBSOFTCOPY.ImageLocation <> "" Then
                fillupload()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTUPLOADSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTUPLOADSRNO.GotFocus
        If gridUPLOADDoubleClick = False Then
            If gridupload.RowCount > 0 Then
                TXTUPLOADSRNO.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
            Else
                TXTUPLOADSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub gridupload_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If e.RowIndex >= 0 Then PBSOFTCOPY.Image = gridupload.Rows(e.RowIndex).Cells(GUIMGPATH.Index).Value
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridupload.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridupload.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If gridUPLOADDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                gridupload.Rows.RemoveAt(gridupload.CurrentRow.Index)
                getsrno(gridupload)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLOSE.Click
        Try

            If EDIT = True Then
                If (gridbill.CurrentRow.Cells(GOUTQTY.Index).Value) > 0 Then
                    MsgBox("Order Locked!", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If LBLCLOSED.Visible = True Then
                    MsgBox("Order CLosed !", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Wish to Close Purchase Order No " & Val(TEMPPONO) & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If MsgBox("Are you sure?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Dim OBJCMN As New ClsCommon
                        Dim DT As DataTable
                        DT = OBJCMN.Execute_Any_String("UPDATE OPENINGPURCHASEORDER SET OPO_CLOSE =1 WHERE OPO_NO =  " & Val(TEMPPONO) & " AND OPO_YEARID = " & YearId, "", "")
                        MsgBox("Order Closed")
                        gridbill.CurrentRow.DefaultCellStyle.BackColor = Color.LightGreen
                    End If
                End If
            End If
            EDIT = False
            CLEAR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Unable To Delete, Order Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If LBLCLOSED.Visible = True Then
                    MsgBox("Unable To Delete, Order Closed", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If (gridbill.CurrentRow.Cells(GOUTQTY.Index).Value) > 0 Then
                    MsgBox("Order Locked!", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Wish to Delete Order.?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If MsgBox("Are you Sure?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        Dim alParaval As New ArrayList
                        alParaval.Add(TXTPONO.Text.Trim)
                        alParaval.Add(YearId)
                        alParaval.Add(Userid)

                        Dim clspo As New ClsOpeningPurchaseOrder()
                        clspo.alParaval = alParaval
                        Dim IntResult As Integer = clspo.Delete()
                        MsgBox("Order Deleted")
                        CLEAR()
                        EDIT = False
                    End If
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub


    Private Sub gridupload_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Sub
            If e.RowIndex >= 0 And gridupload.Item(GUSRNO.Index, e.RowIndex).Value <> Nothing Then

                gridUPLOADDoubleClick = True
                TXTUPLOADSRNO.Text = gridupload.Item(GUSRNO.Index, e.RowIndex).Value
                txtuploadremarks.Text = gridupload.Item(GUREMARKS.Index, e.RowIndex).Value
                txtuploadname.Text = gridupload.Item(GUNAME.Index, e.RowIndex).Value
                PBSOFTCOPY.Image = gridupload.Item(GUIMGPATH.Index, e.RowIndex).Value

                tempUPLOADrow = e.RowIndex
                txtuploadremarks.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUNIT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBUNIT.Enter
        Try
            If CMBUNIT.Text.Trim = "" Then fillUNIT(CMBUNIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUNIT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBUNIT.Validating
        Try
            If CMBUNIT.Text.Trim <> "" Then unitvalidate(CMBUNIT, e, Me)
            WTCALC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridbill.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridbill.RowCount > 0 Then
                If (gridbill.CurrentRow.Cells(GOUTQTY.Index).Value) > 0 Then
                    MsgBox("Order Locked!", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If Convert.ToBoolean(gridbill.CurrentRow.Cells(GCLOSED.Index).Value) = True Then
                    MsgBox("Order CLosed", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                gridbill.Rows.RemoveAt(gridbill.CurrentRow.Index)
                total()
                getsrno(gridbill)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtwt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtwt.Validated
        WTCALC()
    End Sub

    Private Sub TXTSHEETSPERREAM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTSHEETSPERREAM.KeyPress
        numkeypress(e, TXTSHEETSPERREAM, Me)
    End Sub

    Private Sub TXTSHEETSPERREAM_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSHEETSPERREAM.Validated
        WTCALC()
    End Sub

    Private Sub TOOLPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLPRINT.Click
        If EDIT = True Then PRINTREPORT()
    End Sub
End Class