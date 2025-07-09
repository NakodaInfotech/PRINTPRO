
Imports System.ComponentModel
Imports BL

Public Class GRN

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK, gridUPLOADDoubleClick As Boolean
    Dim TEMPROW, PURREGID As Integer
    Dim TEMPPARTYBILLNO, TEMPFORM As String
    Public EDIT As Boolean
    Public TEMPGRNNO, TEMPREGNAME As String
    Public frmstring As String
    Dim PURREGABBR, PURREGINITIAL As String
    Dim tempUPLOADrow As Integer

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Sub CLEAR()
        CMBNAME.Text = ""
        CMBGODOWN.Text = ""
        CMBNONINVITEM.Text = ""
        CMBUNIT.Text = ""
        CMBTRANS.Text = ""

        DTDELDATE.Value = Mydate
        DTLRDATE.Value = Mydate
        DTGRNDATE.Value = Mydate
        DTPODATE.Value = Mydate
        DTCHALLANDATE.Value = Mydate

        TXTDELDAYS.Clear()
        TXTLRNO.Clear()
        TXTLOTNO.Clear()
        txtremarks.Clear()
        TXTPONO.Clear()
        TXTCHALLANNO.Clear()
        If ClientName = "AMR" Then TXTSHEETSPERREAM.Text = 500 Else TXTSHEETSPERREAM.Clear()

        GRIDGRN.RowCount = 0
        gridupload.RowCount = 0
        GRIDDOUBLECLICK = False
        gridUPLOADDoubleClick = False
        CMDSELECTPO.Enabled = True
        LBLTOTALQTY.Text = 0.0
        LBLTOTALSHEETS.Text = 0
        TXTSRNO.Text = 1
        txtsize.Clear()
        txtwt.Clear()
        txtqty.Clear()
        CMBUNIT.Text = ""
        TXTSHEETS.Clear()
        TXTDESC.Clear()

        GETMAX_GRN_NO()
        Ep.Clear()
        lbllocked.Visible = False
        PBlock.Visible = False
        TXTBILLNO.Clear()

        TXTUPLOADSRNO.Text = 1
        txtuploadremarks.Clear()
        txtuploadname.Clear()
        PBSOFTCOPY.Image = Nothing
        TXTIMGPATH.Clear()
        gridupload.RowCount = 0
        TXTRATE.Clear()
        TXTAMOUNT.Clear()
        TXTGSM.Clear()
    End Sub

    Sub GETMAX_GRN_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(GRN_no),0) + 1 ", " GRN ", " AND GRN_YEARID = " & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTGRNNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        EDIT = False
        CMBNAME.Focus()
    End Sub

    Private Sub GRN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.F8 Then
                GRIDGRN.Focus()
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
        If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        If CMBNONINVITEM.Text.Trim = "" Then FILLNONINVITEM(CMBNONINVITEM, EDIT)
        If CMBUNIT.Text.Trim = "" Then fillUNIT(CMBUNIT)
        If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, EDIT, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'TRANSPORT'")
    End Sub

    Private Sub GRN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            If ClientName = "IYMP" Then
                TXTSRNO.Visible = False
                CMBNONINVITEM.Visible = False
                txtsize.Visible = False
                txtwt.Visible = False
                txtqty.Visible = False
                TXTDESC.Visible = False
                CMBUNIT.Visible = False
                TXTLOTNO.Visible = False
                GLOTNO.ReadOnly = False
                GQTY.ReadOnly = False
            End If

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable
                Dim ALPARAVAL As New ArrayList
                Dim OBJGRN As New ClsGRN

                ALPARAVAL.Add(TEMPGRNNO)
                ALPARAVAL.Add(YearId)

                OBJGRN.alParaval = ALPARAVAL
                DT = OBJGRN.selectGRN()

                If DT.Rows.Count > 0 Then
                    For Each DR As DataRow In DT.Rows

                        TXTGRNNO.Text = TEMPGRNNO
                        DTGRNDATE.Value = DT.Rows(0).Item("DATE")
                        CMBNAME.Text = Convert.ToString(DR("NAME"))
                        TXTDELDAYS.Text = DT.Rows(0).Item("DELDAYS")
                        DTDELDATE.Value = DT.Rows(0).Item("DELDATE")
                        CMBGODOWN.Text = DT.Rows(0).Item("GODOWN")
                        CMBTRANS.Text = DT.Rows(0).Item("TRANS")
                        TXTLRNO.Text = DT.Rows(0).Item("LRNO")
                        DTLRDATE.Value = DT.Rows(0).Item("LRDATE")
                        TXTPONO.Text = DT.Rows(0).Item("PONO")
                        DTPODATE.Value = DT.Rows(0).Item("PODATE")
                        TXTCHALLANNO.Text = DT.Rows(0).Item("CHALLANNO")
                        DTCHALLANDATE.Value = DT.Rows(0).Item("CHALLANDATE")
                        TXTSHEETSPERREAM.Text = Val(DT.Rows(0).Item("SHEETSPERREAM"))



                        LBLTOTALQTY.Text = DT.Rows(0).Item("TOTALQTY")
                        LBLTOTALSHEETS.Text = DT.Rows(0).Item("TOTALSHEETS")
                        txtremarks.Text = DT.Rows(0).Item("REMARKS")
                        TXTBILLNO.Text = DR("BILLNO")

                        If DT.Rows(0).Item("DONE") = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        '' grid 
                        GRIDGRN.Rows.Add(DR("SRNO").ToString, DR("ITEMNAME").ToString, DR("LOTNO").ToString, Val(DR("GSM")), DR("SIZE").ToString, Format(Val(DR("WT")), "0.00"), Format(Val(DR("QTY")), "0.00"), DR("UNIT").ToString, Val(DR("SHEETS")), DR("DESC"), Val(DR("RATE")), Val(DR("AMOUNT")), Val(DR("PONO")), Val(DR("POSRNO")), DR("TYPE"), Val(DR("OUTQTY")))
                        If (DR("OUTQTY")) > 0 Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                            GRIDGRN.Rows(GRIDGRN.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                        End If

                    Next

                    '' GRID UPLOAD
                    Dim OBJCMNN As New ClsCommon
                    Dim DTTABLE As DataTable = OBJCMNN.search("ISNULL(GRN_UPSRNO, 0) AS SRNO, ISNULL(GRN_UPREMARKS, '') AS REMARKS, ISNULL(GRN_UPNAME, '') AS NAME, GRN_IMGPATH AS IMGPATH", "", "GRN_UPLOAD", "AND GRN_UPLOAD.GRN_NO= " & TEMPGRNNO & "  AND GRN_YEARID = " & YearId & " ORDER BY GRN_UPLOAD.GRN_UPSRNO")
                    If DTTABLE.Rows.Count > 0 Then
                        For Each DTR As DataRow In DTTABLE.Rows
                            gridupload.Rows.Add(DTR("SRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                        Next
                    End If
                    GRIDGRN.FirstDisplayedScrollingRowIndex = GRIDGRN.RowCount - 1
                End If
                CMDSELECTPO.Enabled = False
                CMBNAME.Focus()
                TOTAL()
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
        Dim IntResult As Integer
        Try
            Cursor.Current = Cursors.WaitCursor
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(DTGRNDATE.Value.Date)
            ALPARAVAL.Add(CMBNAME.Text.Trim)
            ALPARAVAL.Add(TXTDELDAYS.Text.Trim)
            ALPARAVAL.Add(DTDELDATE.Value.Date)
            ALPARAVAL.Add(CMBGODOWN.Text.Trim)
            ALPARAVAL.Add(CMBTRANS.Text.Trim)
            ALPARAVAL.Add(TXTLRNO.Text.Trim)
            ALPARAVAL.Add(DTLRDATE.Value.Date)
            ALPARAVAL.Add(TXTPONO.Text.Trim)
            ALPARAVAL.Add(DTPODATE.Value.Date)
            ALPARAVAL.Add(TXTCHALLANNO.Text.Trim)
            ALPARAVAL.Add(DTCHALLANDATE.Value.Date)
            ALPARAVAL.Add(Val(TXTSHEETSPERREAM.Text.Trim))
            ALPARAVAL.Add(Val(LBLTOTALQTY.Text.Trim))
            ALPARAVAL.Add(Val(LBLTOTALSHEETS.Text.Trim))
            ALPARAVAL.Add(txtremarks.Text.Trim)
            If chkdone.CheckState = True Then
                ALPARAVAL.Add(1)
            Else
                ALPARAVAL.Add(0)
            End If

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            '' GRID PARAMETERS
            Dim SRNO As String = ""
            Dim NONINVITEM As String = ""
            Dim LOTNO As String = ""
            Dim GSM As String = ""
            Dim SIZE As String = ""
            Dim WT As String = ""
            Dim QTY As String = ""
            Dim UNIT As String = ""
            Dim SHEETS As String = ""
            Dim DESC As String = ""
            Dim RATE As String = ""
            Dim AMOUNT As String = ""
            Dim PONO As String = ""
            Dim POSRNO As String = ""
            Dim TYPE As String = ""
            Dim OUTQTY As String = ""


            For Each ROW As Windows.Forms.DataGridViewRow In GRIDGRN.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If SRNO = "" Then
                        SRNO = ROW.Cells(gsrno.Index).Value
                        NONINVITEM = ROW.Cells(GITEMNAME.Index).Value.ToString
                        LOTNO = ROW.Cells(GLOTNO.Index).Value.ToString
                        GSM = Val(ROW.Cells(GGSM.Index).Value)
                        SIZE = ROW.Cells(gbillsize.Index).Value.ToString
                        WT = Val(ROW.Cells(gWt.Index).Value)
                        QTY = Val(ROW.Cells(GQTY.Index).Value)
                        UNIT = ROW.Cells(GUNIT.Index).Value.ToString
                        SHEETS = Val(ROW.Cells(GSHEETS.Index).Value)
                        DESC = ROW.Cells(GDESC.Index).Value.ToString
                        RATE = Val(ROW.Cells(GRATE.Index).Value)
                        AMOUNT = Val(ROW.Cells(GAMOUNT.Index).Value)
                        PONO = Val(ROW.Cells(GPONO.Index).Value)
                        POSRNO = Val(ROW.Cells(GPOSRNO.Index).Value)
                        TYPE = ROW.Cells(GTYPE.Index).Value.ToString
                        OUTQTY = Val(ROW.Cells(GOUTQTY.Index).Value)

                    Else

                        SRNO = SRNO & "|" & ROW.Cells(gsrno.Index).Value
                        NONINVITEM = NONINVITEM & "|" & ROW.Cells(GITEMNAME.Index).Value.ToString
                        LOTNO = LOTNO & "|" & ROW.Cells(GLOTNO.Index).Value.ToString
                        GSM = GSM & "|" & Val(ROW.Cells(GGSM.Index).Value)
                        SIZE = SIZE & "|" & ROW.Cells(gbillsize.Index).Value.ToString
                        WT = WT & "|" & Val(ROW.Cells(gWt.Index).Value)
                        QTY = QTY & "|" & Val(ROW.Cells(GQTY.Index).Value)
                        UNIT = UNIT & "|" & ROW.Cells(GUNIT.Index).Value.ToString
                        SHEETS = SHEETS & "|" & Val(ROW.Cells(GSHEETS.Index).Value)
                        DESC = DESC & "|" & ROW.Cells(GDESC.Index).Value.ToString
                        RATE = RATE & "|" & Val(ROW.Cells(GRATE.Index).Value)
                        AMOUNT = AMOUNT & "|" & Val(ROW.Cells(GAMOUNT.Index).Value)
                        PONO = PONO & "|" & Val(ROW.Cells(GPONO.Index).Value)
                        POSRNO = POSRNO & "|" & Val(ROW.Cells(GPOSRNO.Index).Value)
                        TYPE = TYPE & "|" & ROW.Cells(GTYPE.Index).Value.ToString
                        OUTQTY = OUTQTY & "|" & Val(ROW.Cells(GOUTQTY.Index).Value)
                    End If
                End If
            Next
            ALPARAVAL.Add(SRNO)
            ALPARAVAL.Add(NONINVITEM)
            ALPARAVAL.Add(LOTNO)
            ALPARAVAL.Add(GSM)
            ALPARAVAL.Add(SIZE)
            ALPARAVAL.Add(WT)
            ALPARAVAL.Add(QTY)
            ALPARAVAL.Add(UNIT)
            ALPARAVAL.Add(SHEETS)
            ALPARAVAL.Add(DESC)
            ALPARAVAL.Add(RATE)
            ALPARAVAL.Add(AMOUNT)
            ALPARAVAL.Add(PONO)
            ALPARAVAL.Add(POSRNO)
            ALPARAVAL.Add(TYPE)
            ALPARAVAL.Add(OUTQTY)

            ALPARAVAL.Add(TXTBILLNO.Text.Trim)


            Dim OBJGRN As New ClsGRN
            OBJGRN.alParaval = ALPARAVAL

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTTABLE As DataTable = OBJGRN.SAVE()
                MsgBox("Details Added !!")

                If ClientName = "GANESHMUDRA" Then
                    If MsgBox("Wish to GRN Checking Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then DIRECTGRNCHECKING()
                End If

                TEMPGRNNO = DTTABLE.Rows(0).Item(0)
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                ALPARAVAL.Add(TEMPGRNNO)
                IntResult = OBJGRN.UPDATE()
                MsgBox("Details Updated")
                EDIT = False
            End If
            PRINTREPORT(TEMPGRNNO)
            If gridupload.RowCount > 0 Then SAVEUPLOAD()
            CLEAR()
            CMBNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub DIRECTGRNCHECKING()
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(Format(Convert.ToDateTime(DTGRNDATE.Text).Date, "MM/dd/yyyy"))
            ALPARAVAL.Add(CMBNAME.Text.Trim)
            ALPARAVAL.Add(UserName)     'CHECKEDBY
            ALPARAVAL.Add(CMBGODOWN.Text.Trim)

            ALPARAVAL.Add(Val(TXTGRNNO.Text.Trim))
            ALPARAVAL.Add(Format(Convert.ToDateTime(DTGRNDATE.Text).Date, "MM/dd/yyyy"))
            ALPARAVAL.Add(txtremarks.Text.Trim)
            ALPARAVAL.Add(LBLTOTALQTY.Text.Trim)
            ALPARAVAL.Add(LBLTOTALQTY.Text.Trim)    'ACCQTY
            ALPARAVAL.Add(0)              'REJQTY

            ALPARAVAL.Add(TXTCHALLANNO.Text.Trim)
            ALPARAVAL.Add(DTCHALLANDATE.Value.Date)
            ALPARAVAL.Add(Val(TXTSHEETSPERREAM.Text.Trim))

            'FOR CHECKBOX
            ALPARAVAL.Add(0)  'CHKCHALLANNO
            ALPARAVAL.Add(0) 'CHKCHALLANDATE
            ALPARAVAL.Add(0) 'CHKMATERIALNAME
            ALPARAVAL.Add(0) 'CHKSUPPLIERMFGNAME
            ALPARAVAL.Add(0) 'CHKNOOFREAM
            ALPARAVAL.Add(0) 'CHKDATEOFRECEIPT
            ALPARAVAL.Add(0) 'CHKPACKINGOFPAPER
            ALPARAVAL.Add(0) 'CHKLABELLINGONCONSIGNMENT
            ALPARAVAL.Add(0) 'CHKPHYSICALCONDITION
            ALPARAVAL.Add(0) 'CHKNAMEOFMFG
            ALPARAVAL.Add(0) 'CHKTEXTMATTER
            ALPARAVAL.Add(0) 'CHKGRIPPER
            ALPARAVAL.Add(0) 'CHKREGISTRATIONMARK
            ALPARAVAL.Add(0) 'CHKACCEPTED

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)


            '' GRID PARAMETERS
            Dim SRNO As String = ""
            Dim NONINVITEM As String = ""
            Dim LOTNO As String = ""
            Dim GSM As String = ""
            Dim SIZE As String = ""
            Dim WT As String = ""
            Dim QTY As String = ""
            Dim ACCQTY As String = ""
            Dim REJQTY As String = ""
            Dim UNIT As String = ""
            Dim SHEETS As String = ""
            Dim DESC As String = ""
            Dim RATE As String = ""
            Dim AMOUNT As String = ""
            Dim GRNNO As String = ""
            Dim GRNSRNO As String = ""
            Dim OUTQTY As String = ""
            Dim TYPE As String = ""

            Dim PRESENT As Boolean = False
            For Each ROW As Windows.Forms.DataGridViewRow In GRIDGRN.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If SRNO = "" Then
                        SRNO = ROW.Cells(gsrno.Index).Value
                        NONINVITEM = ROW.Cells(GITEMNAME.Index).Value.ToString
                        LOTNO = ROW.Cells(GLOTNO.Index).Value.ToString
                        GSM = Val(ROW.Cells(GGSM.Index).Value)
                        SIZE = ROW.Cells(gbillsize.Index).Value.ToString
                        WT = Val(ROW.Cells(gWt.Index).Value)
                        QTY = Val(ROW.Cells(GQTY.Index).Value)
                        ACCQTY = Val(ROW.Cells(GQTY.Index).Value)
                        REJQTY = 0
                        UNIT = ROW.Cells(GUNIT.Index).Value.ToString
                        SHEETS = Val(ROW.Cells(GSHEETS.Index).Value)
                        DESC = ROW.Cells(GDESC.Index).Value.ToString
                        RATE = Val(ROW.Cells(GRATE.Index).Value)
                        AMOUNT = Val(ROW.Cells(GAMOUNT.Index).Value)
                        GRNNO = Val(TXTGRNNO.Text.Trim)
                        GRNSRNO = Val(ROW.Cells(gsrno.Index).Value)
                        OUTQTY = 0
                        TYPE = "GRN"

                    Else
                        SRNO = SRNO & "|" & ROW.Cells(gsrno.Index).Value
                        NONINVITEM = NONINVITEM & "|" & ROW.Cells(GITEMNAME.Index).Value.ToString
                        LOTNO = LOTNO & "|" & ROW.Cells(GLOTNO.Index).Value.ToString
                        GSM = GSM & "|" & Val(ROW.Cells(GGSM.Index).Value)
                        SIZE = SIZE & "|" & ROW.Cells(gbillsize.Index).Value.ToString
                        WT = WT & "|" & Val(ROW.Cells(gWt.Index).Value)
                        QTY = QTY & "|" & Val(ROW.Cells(GQTY.Index).Value)
                        ACCQTY = ACCQTY & "|" & Val(ROW.Cells(GQTY.Index).Value)
                        REJQTY = REJQTY & "|0"
                        UNIT = UNIT & "|" & ROW.Cells(GUNIT.Index).Value.ToString
                        SHEETS = SHEETS & "|" & Val(ROW.Cells(GSHEETS.Index).Value)
                        DESC = DESC & "|" & ROW.Cells(GDESC.Index).Value.ToString
                        RATE = RATE & "|" & Val(ROW.Cells(GRATE.Index).Value)
                        AMOUNT = AMOUNT & "|" & Val(ROW.Cells(GAMOUNT.Index).Value)
                        GRNNO = GRNNO & "|" & Val(TXTGRNNO.Text.Trim)
                        GRNSRNO = GRNSRNO & "|" & Val(ROW.Cells(gsrno.Index).Value)
                        OUTQTY = OUTQTY & "|0"
                        TYPE = TYPE & "|" & "GRN"
                    End If
                End If
            Next
            ALPARAVAL.Add(SRNO)
            ALPARAVAL.Add(NONINVITEM)
            ALPARAVAL.Add(LOTNO)
            ALPARAVAL.Add(GSM)
            ALPARAVAL.Add(SIZE)
            ALPARAVAL.Add(WT)
            ALPARAVAL.Add(QTY)
            ALPARAVAL.Add(ACCQTY)
            ALPARAVAL.Add(REJQTY)
            ALPARAVAL.Add(UNIT)
            ALPARAVAL.Add(SHEETS)
            ALPARAVAL.Add(DESC)
            ALPARAVAL.Add(RATE)
            ALPARAVAL.Add(AMOUNT)
            ALPARAVAL.Add(GRNNO)
            ALPARAVAL.Add(GRNSRNO)
            ALPARAVAL.Add(OUTQTY)
            ALPARAVAL.Add(TYPE)




            ALPARAVAL.Add("")   'OBSRNO
            ALPARAVAL.Add("")   'OBGSM
            ALPARAVAL.Add("")   'OBSIZE

            ALPARAVAL.Add(TXTBILLNO.Text.Trim)
            ALPARAVAL.Add(Val(TXTPONO.Text.Trim))


            Dim OBJGRN As New ClsGRNChecking
            OBJGRN.alParaval = ALPARAVAL
            Dim DT As DataTable = OBJGRN.SAVE()
            MsgBox("Checking Saved Successfully!")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal GRNNO As Integer)
        Try
            If MsgBox("Print GRN Report", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim OBJGRN As New GRNDesign
            OBJGRN.FRMSTRING = "GRN"
            OBJGRN.WHERECLAUSE = "{GRN.GRN_NO} = " & GRNNO & " AND {GRN.GRN_YEARID} = " & YearId
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SAVEUPLOAD()
        Try
            Dim OBJGRN As New ClsGRN

            For Each ROW As Windows.Forms.DataGridViewRow In gridupload.Rows
                Dim MS As New IO.MemoryStream
                Dim ALPARAVAL As New ArrayList
                If ROW.Cells(GUSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(TEMPGRNNO)
                    ALPARAVAL.Add(ROW.Cells(GUSRNO.Index).Value)
                    ALPARAVAL.Add(ROW.Cells(GUREMARKS.Index).Value)
                    ALPARAVAL.Add(ROW.Cells(GUNAME.Index).Value)

                    PBSOFTCOPY.Image = ROW.Cells(GUIMGPATH.Index).Value
                    PBSOFTCOPY.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    ALPARAVAL.Add(MS.ToArray)
                    ALPARAVAL.Add(YearId)

                    OBJGRN.alParaval = ALPARAVAL
                    Dim INTRESULT As Integer = OBJGRN.SAVEUPLOAD()
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
            Ep.SetError(CMBNAME, "Please Enter Name")
            bln = False
        End If

        If CMBGODOWN.Text.Trim.Length = 0 Then
            Ep.SetError(CMBGODOWN, "Please Enter Godown Name")
            bln = False
        End If

        If GRIDGRN.RowCount = 0 Then
            Ep.SetError(CMBNAME, "Please Enter Item Details")
            bln = False
        End If

        If lbllocked.Visible = True Then
            Ep.SetError(lbllocked, "Checking Done, Delete Checking First")
            bln = False
        End If

        If ClientName = "IYMP" Then
            For Each row As DataGridViewRow In GRIDGRN.Rows
                If Val(row.Cells(GPONO.Index).Value) = 0 Then
                    Ep.SetError(CMBNAME, "Invalid Entry!")
                    bln = False
                End If

                If Val(row.Cells(GQTY.Index).Value) = 0 Then
                    Ep.SetError(CMBNAME, "Qty cannot be 0!")
                    bln = False
                End If
            Next
        End If


        If Not datecheck(DTGRNDATE.Value) Then
            Ep.SetError(DTGRNDATE, "Date not in Accounting Year")
            bln = False
        End If


        If Convert.ToDateTime(DTGRNDATE.Text).Date < GRNBLOCKDATE.Date Then
            Ep.SetError(DTGRNDATE, "Date is Blocked, Please make entries after " & Format(GRNBLOCKDATE.Date, "dd/MM/yyyy"))
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

    Sub TOTAL()
        Try
            LBLTOTALQTY.Text = 0
            LBLTOTALSHEETS.Text = 0
            For Each ROW As DataGridViewRow In GRIDGRN.Rows
                LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0.00")
                LBLTOTALSHEETS.Text = Format(Val(LBLTOTALSHEETS.Text) + Val(ROW.Cells(GSHEETS.Index).EditedFormattedValue), "0")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSRNO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTSRNO.Enter
        If GRIDDOUBLECLICK = False Then TXTSRNO.Text = GRIDGRN.RowCount + 1
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

    Sub fillgrid()

        GRIDGRN.Enabled = True

        If GRIDDOUBLECLICK = False Then
            GRIDGRN.Rows.Add(Val(TXTSRNO.Text.Trim), CMBNONINVITEM.Text.Trim, TXTLOTNO.Text.Trim, Format(Val(TXTGSM.Text.Trim), "0.00"), txtsize.Text.Trim, Format(Val(txtwt.Text.Trim), "0.00"), Format(Val(txtqty.Text.Trim), "0.00"), CMBUNIT.Text.Trim, Val(TXTSHEETS.Text.Trim), TXTDESC.Text.Trim, Format(Val(TXTRATE.Text.Trim), "0.00"), Format(Val(TXTAMOUNT.Text.Trim), "0.00"), 0, 0, "", 0)
            getsrno(GRIDGRN)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDGRN.Item(gsrno.Index, TEMPROW).Value = Val(TXTSRNO.Text)
            GRIDGRN.Item(GITEMNAME.Index, TEMPROW).Value = CMBNONINVITEM.Text
            GRIDGRN.Item(GLOTNO.Index, TEMPROW).Value = TXTLOTNO.Text
            GRIDGRN.Item(GGSM.Index, TEMPROW).Value = Format(Val(TXTGSM.Text), "0.00")
            GRIDGRN.Item(gbillsize.Index, TEMPROW).Value = txtsize.Text
            GRIDGRN.Item(gWt.Index, TEMPROW).Value = Format(Val(txtwt.Text), "0.00")
            GRIDGRN.Item(GQTY.Index, TEMPROW).Value = Format(Val(txtqty.Text), "0.00")
            GRIDGRN.Item(GUNIT.Index, TEMPROW).Value = CMBUNIT.Text
            GRIDGRN.Item(GSHEETS.Index, TEMPROW).Value = Format(Val(TXTSHEETS.Text), "0")
            GRIDGRN.Item(GDESC.Index, TEMPROW).Value = TXTDESC.Text
            GRIDGRN.Item(GRATE.Index, TEMPROW).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
            GRIDGRN.Item(GAMOUNT.Index, TEMPROW).Value = Format(Val(TXTAMOUNT.Text.Trim), "0.00")



            GRIDDOUBLECLICK = False
        End If
        TOTAL()
        GRIDGRN.FirstDisplayedScrollingRowIndex = GRIDGRN.RowCount - 1

        CMBNONINVITEM.Text = ""
        CMBUNIT.Text = ""
        TXTLOTNO.Clear()
        TXTGSM.Clear()
        txtsize.Clear()
        txtwt.Clear()
        TXTDESC.Clear()
        TXTRATE.Clear()
        TXTAMOUNT.Clear()
        txtqty.Clear()
        TXTSHEETS.Clear()
        TXTSRNO.Text = Val(GRIDGRN.RowCount) + 1
        CMBNONINVITEM.Focus()

    End Sub

    Sub CALC()
        Try
            If ClientName = "AMR" And UCase(CMBUNIT.Text.Trim) = "REAMS" And Val(TXTSHEETSPERREAM.Text.Trim) > 0 Then TXTSHEETS.Text = Format(Val(txtqty.Text.Trim) * Val(TXTSHEETSPERREAM.Text.Trim), "0")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDELDAYS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTDELDAYS.Validating
        Try
            If (Val(TXTDELDAYS.Text.Trim)) > 0 Then DTDELDATE.Value = DateAdd(DateInterval.Day, Val(TXTDELDAYS.Text.Trim), DTGRNDATE.Value.Date)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DTDELDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DTDELDATE.Validating
        Try
            If DTDELDATE.Value.Date < DTGRNDATE.Value.Date Then
                MsgBox("Enter Proper Date !")
                e.Cancel = True
            End If
            TXTDELDAYS.Clear()
            TXTDELDAYS.Text = DTDELDATE.Value.Date.Subtract(DTGRNDATE.Value.Date).Days
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try

LINE1:
            TEMPGRNNO = Val(TXTGRNNO.Text) - 1
Line2:
            If TEMPGRNNO > 0 Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" GRN_NO ", "", "  GRN", " And GRN_NO = '" & TEMPGRNNO & "' AND GRN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    EDIT = True
                    GRN_Load(sender, e)
                Else
                    TEMPGRNNO = Val(TEMPGRNNO - 1)
                    GoTo Line2
                End If
            Else
                CLEAR()
                EDIT = False
            End If

            If GRIDGRN.RowCount = 0 And TEMPGRNNO > 1 Then
                TXTGRNNO.Text = TEMPGRNNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDGRN.RowCount = 0
LINE1:
            TEMPGRNNO = Val(TXTGRNNO.Text) + 1
            GETMAX_GRN_NO()
            Dim MAXNO As Integer = TXTGRNNO.Text.Trim
            CLEAR()
            If Val(TXTGRNNO.Text) - 1 >= TEMPGRNNO Then
                EDIT = True
                GRN_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDGRN.RowCount = 0 And TEMPGRNNO < MAXNO Then
                TXTGRNNO.Text = TEMPGRNNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstxtbillno.Validated
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDGRN.RowCount = 0
            TEMPGRNNO = Val(tstxtbillno.Text)
            If TEMPGRNNO > 0 Then
                EDIT = True
                GRN_Load(sender, e)
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

            Dim OBJGRN As New GRNDetails
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub tstxtbillno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tstxtbillno.KeyPress, TXTSHEETS.KeyPress, TXTDELDAYS.KeyPress, txtqty.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANS_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTRANS.Enter
        Try
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, EDIT, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANS_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBTRANS.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBTRANS.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANS.Validating
        Try
            If CMBTRANS.Text.Trim <> "" Then namevalidate(CMBTRANS, CMBCODE, e, Me, txtadd, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "TRANSPORT")
        Catch ex As Exception
            Throw ex
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
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDGRN.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDGRN.Rows.RemoveAt(GRIDGRN.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDGRN)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTPO.Click
        Try

            If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If CMBNAME.Text.Trim <> "" Then

                Dim OBJSELECTPO As New SelectPO
                OBJSELECTPO.PARTYNAME = CMBNAME.Text
                Dim DTPO As DataTable = OBJSELECTPO.DT
                OBJSELECTPO.ShowDialog()


                Dim i As Integer = 0
                If DTPO.Rows.Count > 0 Then

                    Dim OBJCMN As New ClsCommon

                    For Each DTROW As DataRow In DTPO.Rows
                        Dim DT As DataTable

                        'DT = OBJCMN.search(" ISNULL(PURCHASEORDER.PO_NO, 0) AS PONO, ISNULL(PURCHASEORDER_DESC.PO_SRNO, 0) AS POSRNO, PURCHASEORDER.PO_DATE AS DATE, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME, ISNULL(PURCHASEORDER_DESC.PO_SIZE, '0') AS SIZE, ISNULL(PURCHASEORDER_DESC.PO_WT, 0) AS WT, ISNULL(PURCHASEORDER_DESC.PO_QTY - PURCHASEORDER_DESC.PO_OUTQTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(PURCHASEORDER.PO_SHEETSPERREAM,0) AS SHEETSPERREAM, (ISNULL(PURCHASEORDER.PO_SHEETSPERREAM,0) * (ISNULL(PURCHASEORDER_DESC.PO_QTY - PURCHASEORDER_DESC.PO_OUTQTY, 0))) TOTALSHEETS  ", "", "   PURCHASEORDER INNER JOIN PURCHASEORDER_DESC ON PURCHASEORDER.PO_NO = PURCHASEORDER_DESC.PO_NO AND PURCHASEORDER.PO_YEARID = PURCHASEORDER_DESC.PO_YEARID INNER JOIN NONINVITEMMASTER ON PURCHASEORDER_DESC.PO_ITEMID = NONINVITEMMASTER.NONINV_ID AND PURCHASEORDER_DESC.PO_YEARID = NONINVITEMMASTER.NONINV_YEARID INNER JOIN UNITMASTER ON PURCHASEORDER_DESC.PO_UNITID = UNITMASTER.unit_id AND PURCHASEORDER_DESC.PO_YEARID = UNITMASTER.unit_yearid", " AND PURCHASEORDER.PO_NO = " & Val(DTROW(0)) & " AND PURCHASEORDER_DESC.PO_SRNO = " & Val(DTROW(1)) & " AND PURCHASEORDER.PO_YEARID = " & YearId)
                        DT = OBJCMN.search(" ISNULL(ALLPURCHASEORDER.PO_NO, 0) AS PONO, ISNULL(ALLPURCHASEORDER_DESC.PO_SRNO, 0) AS POSRNO, ALLPURCHASEORDER.PO_DATE AS DATE, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME, ISNULL(ALLPURCHASEORDER_DESC.PO_SIZE, '0') AS SIZE, ISNULL(ALLPURCHASEORDER_DESC.PO_WT, 0) AS WT, ISNULL(ALLPURCHASEORDER_DESC.PO_QTY - ALLPURCHASEORDER_DESC.PO_OUTQTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(ALLPURCHASEORDER.PO_SHEETSPERREAM,0) AS SHEETSPERREAM, (ISNULL(ALLPURCHASEORDER.PO_SHEETSPERREAM,0) * (ISNULL(ALLPURCHASEORDER_DESC.PO_QTY - ALLPURCHASEORDER_DESC.PO_OUTQTY, 0))) TOTALSHEETS, ALLPURCHASEORDER.TYPE AS TYPE , ISNULL(ALLPURCHASEORDER_DESC.PO_RATE, 0) AS RATE, ISNULL(ALLPURCHASEORDER_DESC.PO_GSM, 0) AS GSM ", "", "   ALLPURCHASEORDER INNER JOIN ALLPURCHASEORDER_DESC ON ALLPURCHASEORDER.PO_NO = ALLPURCHASEORDER_DESC.PO_NO AND ALLPURCHASEORDER.PO_YEARID = ALLPURCHASEORDER_DESC.PO_YEARID INNER JOIN NONINVITEMMASTER ON ALLPURCHASEORDER_DESC.PO_ITEMID = NONINVITEMMASTER.NONINV_ID AND ALLPURCHASEORDER_DESC.PO_YEARID = NONINVITEMMASTER.NONINV_YEARID INNER JOIN UNITMASTER ON ALLPURCHASEORDER_DESC.PO_UNITID = UNITMASTER.unit_id AND ALLPURCHASEORDER_DESC.PO_YEARID = UNITMASTER.unit_yearid", " AND ALLPURCHASEORDER.PO_NO = " & Val(DTROW("PONO")) & " AND ALLPURCHASEORDER_DESC.PO_SRNO = " & Val(DTROW("POSRNO")) & " AND   ALLPURCHASEORDER.TYPE = '" & DTROW("TYPE") & "' AND ALLPURCHASEORDER.PO_YEARID = " & YearId)

                        If DT.Rows.Count > 0 Then

                            TXTPONO.Text = DT.Rows(0).Item(0)
                            DTPODATE.Text = DT.Rows(0).Item("DATE")
                            TXTSHEETSPERREAM.Text = Val(DT.Rows(0).Item("SHEETSPERREAM"))

                            'ITEM GRID
                            Dim SHEETS As Double = 0
                            For Each ROW As DataRow In DT.Rows
                                GRIDGRN.Rows.Add(0, ROW("ITEMNAME"), "", Val(ROW("GSM")), ROW("SIZE"), Format(Val(ROW("WT")), "0.00"), Format(Val(ROW("QTY")), "0.00"), ROW("UNIT"), 0, "", Format(Val(ROW("RATE")), "0.00"), 0, Val(ROW("PONO")), Val(ROW("POSRNO")), ROW("TYPE"), 0)
                            Next
                            getsrno(GRIDGRN)
                            TOTAL()
                            CMBUNIT_Validated(sender, e)
                            CMBNAME.Focus()
                            DTPODATE.Enabled = False
                            CMDSELECTPO.Enabled = False
                        End If
                    Next
                End If
            Else
                MsgBox("Enter Party Name")
                CMBNAME.Focus()
            End If


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
            If LCase(CMBUNIT.Text.Trim) = "sheets" Then
                'get SIZE AND GSM FROM NONINV MASTER AND CALC WT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(NONINV_LENGTH,0) AS LENGTH, ISNULL(NONINV_WIDTH,0) AS WIDTH, ISNULL(NONINV_GSM,0) AS GSM ", "", " NONINVITEMMASTER ", " AND NONINV_NAME = '" & CMBNONINVITEM.Text.Trim & "' AND NONINV_YEARID = " & YearId)
                If Val(DT.Rows(0).Item("LENGTH")) > 0 And Val(DT.Rows(0).Item("WIDTH")) > 0 And Val(DT.Rows(0).Item("GSM")) > 0 Then
                    txtwt.Text = Format(((((Val(DT.Rows(0).Item("LENGTH")) * Val(DT.Rows(0).Item("WIDTH")) * Val(DT.Rows(0).Item("GSM"))) / 3100) / 500) * Val(TXTSHEETS.Text.Trim)), "0.000")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDUPLOAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDUPLOAD.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        TXTIMGPATH.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If TXTIMGPATH.Text.Trim.Length <> 0 Then PBSOFTCOPY.ImageLocation = TXTIMGPATH.Text.Trim
    End Sub

    Private Sub CMDREMOVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREMOVE.Click
        Try
            PBSOFTCOPY.Image = Nothing
            TXTIMGPATH.Clear()
        Catch ex As Exception
            Throw ex
        End Try
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

    Private Sub gridupload_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If e.RowIndex >= 0 Then PBSOFTCOPY.Image = gridupload.Rows(e.RowIndex).Cells(GUIMGPATH.Index).Value
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTUPLOADSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTUPLOADSRNO.GotFocus
        If gridUPLOADDoubleClick = False Then TXTUPLOADSRNO.Text = gridupload.RowCount + 1
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

                If MsgBox("Wish to Delete GRN.?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If MsgBox("Are you Sure?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        Dim alParaval As New ArrayList
                        alParaval.Add(TXTGRNNO.Text.Trim)
                        alParaval.Add(YearId)
                        alParaval.Add(Userid)

                        Dim clspo As New ClsGRN()
                        clspo.alParaval = alParaval
                        Dim IntResult As Integer = clspo.delete()
                        MsgBox("GRN Deleted")
                        CLEAR()
                        EDIT = False
                    End If
                End If

            End If

        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    'Private Sub TXTDESC_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTDESC.Validating
    '    Try
    '        If CMBNONINVITEM.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 And CMBUNIT.Text.Trim <> "" And TXTRATE.Text.Trim > 0 Then
    '            fillgrid()
    '        Else
    '            MsgBox("Enter Proper Details")
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub gridbill_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDGRN.CellDoubleClick
        Try
            If ClientName = "IYMP" Then Exit Sub
            If GRIDGRN.CurrentRow.Index >= 0 And GRIDGRN.Item(gsrno.Index, GRIDGRN.CurrentRow.Index).Value <> Nothing Then

                If (GRIDGRN.Rows(e.RowIndex).Cells(GOUTQTY.Index).Value) > 0 Then
                    MsgBox("GRN locked!", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDGRN.Item(gsrno.Index, GRIDGRN.CurrentRow.Index).Value
                CMBNONINVITEM.Text = GRIDGRN.Item(GITEMNAME.Index, GRIDGRN.CurrentRow.Index).Value.ToString
                TXTLOTNO.Text = GRIDGRN.Item(GLOTNO.Index, GRIDGRN.CurrentRow.Index).Value.ToString
                TXTGSM.Text = GRIDGRN.Item(GGSM.Index, GRIDGRN.CurrentRow.Index).Value.ToString
                txtsize.Text = GRIDGRN.Item(gbillsize.Index, GRIDGRN.CurrentRow.Index).Value.ToString
                txtwt.Text = GRIDGRN.Item(gWt.Index, GRIDGRN.CurrentRow.Index).Value
                txtqty.Text = GRIDGRN.Item(GQTY.Index, GRIDGRN.CurrentRow.Index).Value
                CMBUNIT.Text = GRIDGRN.Item(GUNIT.Index, GRIDGRN.CurrentRow.Index).Value.ToString
                TXTSHEETS.Text = GRIDGRN.Item(GSHEETS.Index, GRIDGRN.CurrentRow.Index).Value
                TXTDESC.Text = GRIDGRN.Item(GDESC.Index, GRIDGRN.CurrentRow.Index).Value.ToString
                TXTRATE.Text = GRIDGRN.Item(GRATE.Index, GRIDGRN.CurrentRow.Index).Value.ToString
                TXTAMOUNT.Text = GRIDGRN.Item(GAMOUNT.Index, GRIDGRN.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDGRN.CurrentRow.Index
                CMBNONINVITEM.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
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

    Private Sub txtwt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtwt.KeyPress
        numdotkeypress(e, txtwt, Me)
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPGRNNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUNIT_Validated(sender As Object, e As EventArgs) Handles CMBUNIT.Validated, txtqty.Validated
        Try
            WTCALC()
            CALC()
            CAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAMOUNT_Validating(sender As Object, e As CancelEventArgs) Handles TXTAMOUNT.Validating
        Try
            If CMBNONINVITEM.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 And CMBUNIT.Text.Trim <> "" And TXTRATE.Text.Trim <> "" Then
                fillgrid()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CAL()
        Try
            TXTAMOUNT.Text = 0.0
            If LCase(CMBUNIT.Text.Trim) = "reams" Or LCase(CMBUNIT.Text.Trim) = "sheets" Or LCase(CMBUNIT.Text.Trim) = "reel" Or LCase(CMBUNIT.Text.Trim) = "ton" Then TXTAMOUNT.Text = Format(Val(txtwt.Text.Trim) * Val(TXTRATE.Text.Trim), "0.000") Else TXTAMOUNT.Text = Format(Val(txtqty.Text.Trim) * Val(TXTRATE.Text.Trim), "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGSM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTGSM.KeyPress, TXTRATE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTRATE_Validated(sender As Object, e As EventArgs) Handles TXTRATE.Validated
        Try
            CAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRN_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "GANESHMUDRA" Then
                TXTSHEETSPERREAM.Visible = False
                Label7.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSHEETS_Validated(sender As Object, e As EventArgs) Handles TXTSHEETS.Validated
        Try
            If ClientName = "GANESHMUDRA" Then WTCALC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHALLANNO_Validating(sender As Object, e As CancelEventArgs) Handles TXTCHALLANNO.Validating
        Try
            If TXTCHALLANNO.Text.Trim.Length > 0 Then
                If EDIT = False Then
                    'for search
                    Dim objclscommon As New ClsCommon()
                    Dim dt As New DataTable
                    dt = objclscommon.search(" GRN.GRN_challanno, LEDGERS.ACC_cmpname", "", " GRN INNER JOIN LEDGERS ON LEDGERS.Acc_id = GRN.GRN_LEDGERID AND LEDGERS.Acc_cmpid = GRN.GRN_CMPID AND LEDGERS.Acc_yearid = GRN.GRN_YEARID", " and GRN.GRN_challanno = '" & TXTCHALLANNO.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & CMBNAME.Text.Trim & "' AND GRN_CMPID =" & CmpId & "  AND GRN_YEARID =" & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Challan No. Already Exists", MsgBoxStyle.Critical, "PRINTPRO")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    'Private Sub TXTRATE_Validating(sender As Object, e As CancelEventArgs) Handles TXTRATE.Validating
    '    Try
    '        If CMBNONINVITEM.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 And CMBUNIT.Text.Trim <> "" Then
    '            fillgrid()
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Sub

End Class