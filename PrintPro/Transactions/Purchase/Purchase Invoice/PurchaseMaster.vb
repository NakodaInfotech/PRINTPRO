
Imports BL
Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel

Public Class PurchaseMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK, gridUPLOADDoubleClick As Boolean
    Dim TEMPROW, PURREGID As Integer
    Dim TEMPPARTYBILLNO, TEMPFORM As String
    Public EDIT As Boolean
    Public TEMPBILLNO, TEMPREGNAME As String
    Public frmstring As String
    Dim PURREGABBR, PURREGINITIAL As String
    Dim tempUPLOADrow As Integer

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Sub CLEAR()

        If ALLOWMANUALBILLNO = True Then
            TXTBILLNO.ReadOnly = False
            TXTBILLNO.BackColor = Color.LemonChiffon
        Else
            TXTBILLNO.ReadOnly = True
            TXTBILLNO.BackColor = Color.Linen
        End If
        cmbname.Text = ""
        TXTSTATECODE.Clear()
        TXTGSTIN.Clear()
        txtadd.Clear()
        CMBADDSUB.Text = ""
        TXTSHEETSPERREAM.Clear()
        cmbtrans.Text = ""
        TXTVEHICLENO.Clear()
        txtlrno.Clear()
        lrdate.Value = Mydate
        TXTEWAYBILLNO.Clear()

        CMBFROMCITY.Text = ""
        CMBTOCITY.Text = ""

        PURDATE.Value = Mydate
        TXTPARTYBILLNO.Clear()
        TXTCRDAYS.Clear()
        PARTYBILLDATE.Value = Mydate
        TXTGRNNO.Clear()
        gridbill.RowCount = 0
        TXTBATCHNO.Clear()
        TXTPPRSRNO.Clear()
        CMBUNIT.Text = ""
        CMBSHELF.Text = ""
        CMBGODOWN.Text = ""

        TXTSRNO.Clear()
        CMBNONINVITEM.Text = ""
        TXTHSNCODE.Clear()
        txtsize.Clear()
        txtwt.Clear()
        txtqty.Clear()
        txtrate.Clear()
        txtamount.Clear()

        TXTOTHERAMT.Clear()
        TXTTAXABLEAMT.Clear()
        TXTCGSTPER.Clear()
        TXTCGSTAMT.Clear()
        TXTSGSTPER.Clear()
        TXTSGSTAMT.Clear()
        TXTIGSTPER.Clear()
        TXTIGSTAMT.Clear()
        TXTGRIDTOTAL.Clear()
        tstxtbillno.Clear()


        CMDSELECTGRN.Enabled = True
        CMBTAX.Text = ""
        CMBADDSUB.Text = ""

        'TXTSRNO.Text = 1

        For I As Integer = 0 To CHKFORMBOX.Items.Count - 1
            Dim DTR As DataRowView = CHKFORMBOX.Items(I)
            CHKFORMBOX.SetItemCheckState(I, CheckState.Unchecked)
        Next

        GETMAX_PO_NO()
        Ep.Clear()
        PBDN.Visible = False
        PBPAID.Visible = False
        PBTDS.Visible = False
        lbllocked.Visible = False
        PBlock.Visible = False
        CMDSHOWDETAILS.Visible = False
        CHKMANUALTCS.Checked = False

        txtpanno.Clear()
        txtcstno.Clear()
        txttinno.Clear()
        txtvatno.Clear()

        txtremarks.Clear()
        txtinwords.Clear()

        txttranschg.Text = 0.0
        txtexcise.Text = 0.0
        CMBEXTRACHGSNAME.Text = ""
        TXTEXTRACHGS.Text = 0.0
        txtsubtotal.Text = 0.0
        txttax.Clear()
        CMBOTHERCHGSNAME.Text = ""
        TXTOTHERCHGS.Text = 0.0
        txtroundoff.Text = 0.0
        txtgtotal.Text = 0.0

        lbltotalqty.Text = 0.0
        lbltotalamt.Text = 0.0

        LBLTOTALTAXABLEAMT.Text = 0.0
        LBLTOTALCGSTAMT.Text = 0.0
        LBLTOTALSGSTAMT.Text = 0.0
        LBLTOTALIGSTAMT.Text = 0.0
        LBLTOTALGRIDAMT.Text = 0.0

        CHKRCM.CheckState = CheckState.Unchecked
        CHKMANUAL.CheckState = CheckState.Unchecked

        GRIDDOUBLECLICK = False
        gridUPLOADDoubleClick = False

        TXTUPLOADSRNO.Text = 1
        txtuploadremarks.Clear()
        txtuploadname.Clear()
        PBSOFTCOPY.Image = Nothing
        TXTIMGPATH.Clear()
        gridupload.RowCount = 0
        CMDSELECTGRN.Enabled = True

        TXTSRNO.Text = 1

        CHKTCS.Checked = False
        TXTTCSPER.Clear()
        TXTTCSAMT.Clear()

    End Sub

    Sub GETMAX_PO_NO()
        Dim DTTABLE As New DataTable
        If cmbregister.Text <> "" Then
            DTTABLE = getmax(" isnull(max(bill_no),0) + 1 ", "  PURCHASEMASTER LEFT OUTER JOIN REGISTERMASTER ON PURCHASEMASTER.bill_registerid = REGISTERMASTER.register_id AND PURCHASEMASTER.bill_yearid = REGISTERMASTER.register_yearid", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE = 'PURCHASE' AND  BILL_YEARID = " & YearId)
            If DTTABLE.Rows.Count > 0 Then
                TXTBILLNO.Text = DTTABLE.Rows(0).Item(0)
            End If
        End If
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        EDIT = False
        cmbregister.Enabled = True
        cmbregister.Focus()
    End Sub

    Private Sub PurchaseMaster_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.F8 Then
                gridbill.Focus()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1) Then       'for CLEAR
                TabControl1.SelectedIndex = (0)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2) Then       'for CLEAR
                TabControl1.SelectedIndex = (1)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D3) Then       'for CLEAR
                TabControl1.SelectedIndex = (2)
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
        If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        If CMBEXTRACHGSNAME.Text.Trim = "" Then fillname(CMBEXTRACHGSNAME, EDIT, " and (GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses') ")
        If CMBOTHERCHGSNAME.Text.Trim = "" Then fillname(CMBOTHERCHGSNAME, EDIT, " and (GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses') ")
        If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'PURCHASE'")
        If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'TRANSPORT'")
        If CMBTAX.Text.Trim = "" Then filltax(CMBTAX, EDIT)
        If CMBFROMCITY.Text.Trim = "" Then fillCITY(CMBFROMCITY, EDIT)
        If CMBTOCITY.Text.Trim = "" Then fillCITY(CMBTOCITY, EDIT)
        If CMBNONINVITEM.Text.Trim = "" Then FILLNONINVITEM(CMBNONINVITEM, EDIT)
        If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        If CMBSHELF.Text.Trim = "" Then fillSHELF(CMBSHELF, EDIT)
        If CMBUNIT.Text.Trim = "" Then fillUNIT(CMBUNIT)
        fillform(CHKFORMBOX, EDIT)

    End Sub

    Private Sub PurchaseMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                Dim OBJPUR As New ClsPurchaseMaster

                ALPARAVAL.Add(TEMPBILLNO)
                ALPARAVAL.Add(TEMPREGNAME)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(YearId)

                OBJPUR.alParaval = ALPARAVAL
                DT = OBJPUR.selectpurchase()

                If DT.Rows.Count > 0 Then
                    For Each DR As DataRow In DT.Rows

                        TXTBILLNO.Text = TEMPBILLNO
                        TXTBILLNO.ReadOnly = True

                        cmbregister.Text = TEMPREGNAME
                        PURDATE.Value = Format(Convert.ToDateTime(DR("DATE")).Date, "dd/MM/yyyy")
                        cmbname.Text = Convert.ToString(DR("NAME"))
                        TXTSTATECODE.Text = DR("STATECODE")
                        TXTGSTIN.Text = DR("GSTIN")
                        txtadd.Text = Convert.ToString(DR("ADDRESS"))
                        txtpanno.Text = Convert.ToString(DR("PANNO"))
                        txtcstno.Text = Convert.ToString(DR("CSTNO"))
                        txttinno.Text = Convert.ToString(DR("TINNO"))
                        txtvatno.Text = Convert.ToString(DR("VATNO"))

                        CMBGODOWN.Text = Convert.ToString(DR("GODOWN"))
                        CMBSHELF.Text = Convert.ToString(DR("SHELF"))
                        TXTSHEETSPERREAM.Text = Convert.ToString(DR("SHEETSPERREAM"))

                        TXTPARTYBILLNO.Text = Convert.ToString(DR("PARTYBILLNO"))
                        PARTYBILLDATE.Value = Format(Convert.ToDateTime(DR("PARTYBILLDATE")).Date, "dd/MM/yyyy")
                        TXTCRDAYS.Text = Convert.ToString(DR("CRDAYS"))
                        DueDate.Value = Format(Convert.ToDateTime(DR("DUEDATE")).Date, "dd/MM/yyyy")

                        cmbtrans.Text = Convert.ToString(DR("TRANSNAME"))
                        TXTVEHICLENO.Text = Convert.ToString(DR("VEHICLENO"))
                        txtlrno.Text = Convert.ToString(DR("LRNO"))
                        lrdate.Value = Format(Convert.ToDateTime(DR("LRDATE")).Date, "dd/MM/yyyy")

                        TXTEWAYBILLNO.Text = Convert.ToString(DR("EWAYBILLNO"))
                        CMBFROMCITY.Text = Convert.ToString(DR("FROMCITY"))
                        CMBTOCITY.Text = Convert.ToString(DR("TOCITY"))

                        txtremarks.Text = Convert.ToString(DR("REMARKS"))
                        TXTGRNNO.Text = Convert.ToString(DR("GRNNO"))
                        txttranschg.Text = Val(DR("TRANSCHGS"))
                        txtexcise.Text = Val(DR("EXCISE"))

                        CMBEXTRACHGSNAME.Text = DT.Rows(0).Item("EXTRACHGSNAME")
                        If Val(DR("EXTRACHGS")) > 0 Then
                            TXTEXTRACHGS.Text = Val(DR("EXTRACHGS"))
                            CMBEXTRAADDSUB.Text = "Add"
                        Else
                            TXTEXTRACHGS.Text = Val(DR("EXTRACHGS")) * (-1)
                            CMBEXTRAADDSUB.Text = "Sub."
                        End If

                        txtsubtotal.Text = Val(DR("SUBTOTAL"))
                        CMBTAX.Text = DR("TAXNAME")
                        txttax.Text = Val(DR("TAXAMT"))

                        CMBOTHERCHGSNAME.Text = DT.Rows(0).Item("OTHERCHGSNAME")
                        If Val(DR("OTHERCHGS")) > 0 Then
                            TXTOTHERCHGS.Text = Val(DR("OTHERCHGS"))
                            CMBADDSUB.Text = "Add"
                        Else
                            TXTOTHERCHGS.Text = Val(DR("OTHERCHGS")) * (-1)
                            CMBADDSUB.Text = "Sub."
                        End If

                        txtgtotal.Text = Convert.ToString(DR("GRANDTOTAL"))

                        TXTAMTREC.Text = Val(DR("AMTREC"))
                        TXTEXTRAAMT.Text = Val(DR("EXTRAAMT"))
                        txtreturn.Text = Val(DR("RETURN"))
                        TXTBAL.Text = Val(DR("BALANCE"))


                        If DR("BILLCHK") = 0 Then
                            CHKBILLCHECKED.Checked = False
                        Else
                            CHKBILLCHECKED.Checked = True
                        End If

                        If DR("BILLDISPUTE") = 0 Then
                            CHKDISPUTE.Checked = False
                        Else
                            CHKDISPUTE.Checked = True
                        End If

                        If Convert.ToBoolean(DR("RCM")) = False Then CHKRCM.Checked = False Else CHKRCM.Checked = True
                        If Convert.ToBoolean(DR("MANUALGST")) = False Then CHKMANUAL.Checked = False Else CHKMANUAL.Checked = True


                        '' grid 
                        gridbill.Rows.Add(DR("GRIDSRNO").ToString, DR("ITEMNAME").ToString, DR("HSNCODE").ToString, DR("SIZE").ToString, Format(Val(DR("WT")), "0.00"), DR("BATCHNO").ToString, DR("PPRSRNO").ToString, DR("UNIT").ToString, Format(Val(DR("QTY")), "0.00"), Format(Val(DR("RATE")), "0.0000"), Format(Val(DR("AMOUNT")), "0.00"), DR("OTHERAMT").ToString, DR("TAXABLEAMT").ToString, DR("CGSTPER").ToString, DR("CGSTAMT").ToString, DR("SGSTPER").ToString, DR("SGSTAMT").ToString, DR("IGSTPER").ToString, DR("IGSTAMT").ToString, DR("GRIDTOTAL").ToString)
                        TabControl1.SelectedIndex = (0)


                        If DR("MANUALTCS") = 0 Then CHKMANUALTCS.Checked = False Else CHKMANUALTCS.Checked = True
                        If DR("APPLYTCS") = 0 Then CHKTCS.Checked = False Else CHKTCS.Checked = True
                        TXTTCSPER.Text = Val(DR("TCSPER"))
                        TXTTCSAMT.Text = Val(DR("TCSAMT"))

                        'CHECKING WHETHER TDS IS DEDUCTED OR NOT
                        Dim OBJCMNTDS As New ClsCommon
                        Dim DTTDS As DataTable = OBJCMNTDS.search(" ISNULL(SUM(JOURNALMASTER.journal_credit),0) AS TDS", "", " JOURNALMASTER INNER JOIN PURCHASEMASTER ON JOURNALMASTER.journal_refno = PURCHASEMASTER.BILL_INITIALS AND  JOURNALMASTER.journal_yearid = PURCHASEMASTER.BILL_YEARID INNER JOIN LEDGERS ON JOURNALMASTER.journal_ledgerid = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id ", " AND (LEDGERS.ACC_TDSAC = 'True') AND BILL_NO = " & TEMPBILLNO & " AND REGISTER_NAME = '" & TEMPREGNAME & "' AND BILL_YEARID = " & YearId)
                        If DTTDS.Rows.Count > 0 Then
                            If Val(DTTDS.Rows(0).Item("TDS")) > 0 Then
                                TXTTDSAMT.Text = Format(Val(DTTDS.Rows(0).Item("TDS")), "0.00")
                                CMDSHOWDETAILS.Visible = True
                                PBTDS.Visible = True
                                lbllocked.Visible = True
                                PBlock.Visible = True
                            End If
                        End If

                        If PBTDS.Visible = False And Val(DR("AMTREC")) > 0 Or Val(DR("EXTRAAMT")) > 0 Then
                            CMDSHOWDETAILS.Visible = True
                            PBPAID.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If Val(DR("RETURN")) > 0 Then
                            CMDSHOWDETAILS.Visible = True
                            PBDN.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next

                    Dim OBJCMN As New ClsCommon
                    Dim DTT As DataTable = OBJCMN.search("ISNULL(FORMTYPE.FORM_NAME, '') AS FORMNAME", "", "PURCHASEMASTER_FORMTYPE INNER JOIN REGISTERMASTER ON PURCHASEMASTER_FORMTYPE.BILL_REGISTERID = REGISTERMASTER.register_id AND PURCHASEMASTER_FORMTYPE.BILL_YEARID = REGISTERMASTER.register_yearid INNER JOIN FORMTYPE ON PURCHASEMASTER_FORMTYPE.BILL_FORMID = FORMTYPE.FORM_ID", "AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTERMASTER.REGISTER_TYPE = 'PURCHASE' AND PURCHASEMASTER_FORMTYPE.BILL_NO = " & TEMPBILLNO & " AND PURCHASEMASTER_FORMTYPE.BILL_YEARID= " & YearId)
                    If DTT.Rows.Count > 0 Then
                        For Each ROW As DataRow In DTT.Rows
                            For I As Integer = 0 To CHKFORMBOX.Items.Count - 1
                                Dim DTR As DataRowView = CHKFORMBOX.Items(I)
                                If ROW("FORMNAME") = DTR.Item(0) Then
                                    CHKFORMBOX.SetItemCheckState(I, CheckState.Checked)
                                End If
                            Next
                        Next
                    End If

                    '' GRID UPLOAD
                    Dim DTTABLE As DataTable = OBJCMN.search("ISNULL(BILL_UPSRNO, 0) AS SRNO, ISNULL(BILL_UPREMARKS, '') AS REMARKS, ISNULL(BILL_UPNAME, '') AS NAME, BILL_IMGPATH AS IMGPATH", "", "PURCHASEMASTER_UPLOAD", "AND PURCHASEMASTER_UPLOAD.BILL_NO= " & TEMPBILLNO & "  AND BILL_YEARID = " & YearId & " ORDER BY PURCHASEMASTER_UPLOAD.BILL_UPSRNO")
                    If DTTABLE.Rows.Count > 0 Then
                        For Each DTR As DataRow In DTTABLE.Rows
                            gridupload.Rows.Add(DTR("SRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                        Next
                    End If


                    Dim dtID As DataTable = OBJCMN.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'PURCHASE' and register_YEARid = " & YearId)
                    If dtID.Rows.Count > 0 Then
                        PURREGABBR = dtID.Rows(0).Item(0).ToString
                        PURREGINITIAL = dtID.Rows(0).Item(1).ToString
                        PURREGID = dtID.Rows(0).Item(2)
                    End If

                    gridbill.FirstDisplayedScrollingRowIndex = gridbill.RowCount - 1
                End If
                cmbregister.Enabled = False
                CMDSELECTGRN.Enabled = False
                cmbname.Focus()
                TOTAL()
                getsrno(gridbill)

                If ALLOWMANUALBILLNO = True Then
                    gridbill.ReadOnly = False
                    gRate.ReadOnly = False
                End If

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
            If ALLOWMANUALBILLNO = True Then
                ALPARAVAL.Add(Val(TXTBILLNO.Text.Trim))
            Else
                ALPARAVAL.Add(0)
            End If
            ALPARAVAL.Add(cmbregister.Text.Trim)
            ALPARAVAL.Add(PURDATE.Value.Date)
            ALPARAVAL.Add(cmbname.Text.Trim)
            ALPARAVAL.Add(CMBGODOWN.Text.Trim)
            ALPARAVAL.Add(CMBSHELF.Text.Trim)
            ALPARAVAL.Add(Val(TXTSHEETSPERREAM.Text.Trim))
            ALPARAVAL.Add(TXTPARTYBILLNO.Text.Trim)
            ALPARAVAL.Add(PARTYBILLDATE.Value)
            ALPARAVAL.Add(Val(TXTCRDAYS.Text.Trim))
            ALPARAVAL.Add(DueDate.Value.Date)

            ALPARAVAL.Add(cmbtrans.Text.Trim)
            ALPARAVAL.Add(TXTVEHICLENO.Text.Trim)
            ALPARAVAL.Add(txtlrno.Text.Trim)
            ALPARAVAL.Add(lrdate.Value)

            ALPARAVAL.Add(TXTEWAYBILLNO.Text.Trim)
            ALPARAVAL.Add(CMBFROMCITY.Text.Trim)
            ALPARAVAL.Add(CMBTOCITY.Text.Trim)

            ALPARAVAL.Add(txtremarks.Text.Trim)
            ALPARAVAL.Add(Val(TXTGRNNO.Text.Trim))
            ALPARAVAL.Add(Val(lbltotalqty.Text.Trim))
            ALPARAVAL.Add(Val(lbltotalamt.Text.Trim))

            ALPARAVAL.Add(Val(LBLTOTALTAXABLEAMT.Text.Trim))
            ALPARAVAL.Add(Val(LBLTOTALCGSTAMT.Text.Trim))
            ALPARAVAL.Add(Val(LBLTOTALSGSTAMT.Text.Trim))
            ALPARAVAL.Add(Val(LBLTOTALIGSTAMT.Text.Trim))
            ALPARAVAL.Add(Val(LBLTOTALGRIDAMT.Text.Trim))

            If CHKMANUALTCS.Checked = True Then ALPARAVAL.Add(1) Else ALPARAVAL.Add(0)
            If CHKTCS.Checked = True Then ALPARAVAL.Add(1) Else ALPARAVAL.Add(0)
            ALPARAVAL.Add(Val(TXTTCSPER.Text.Trim))
            ALPARAVAL.Add(Val(TXTTCSAMT.Text.Trim))


            ALPARAVAL.Add(Val(txttranschg.Text.Trim))
            ALPARAVAL.Add(Val(txtexcise.Text.Trim))

            ALPARAVAL.Add(CMBEXTRACHGSNAME.Text.Trim)
            If CMBEXTRAADDSUB.Text.Trim = "Add" Then
                ALPARAVAL.Add(Val(TXTEXTRACHGS.Text.Trim))
            ElseIf CMBEXTRAADDSUB.Text.Trim = "Sub." Then
                ALPARAVAL.Add(Val((TXTEXTRACHGS.Text.Trim) * (-1)))
            Else
                ALPARAVAL.Add(0)
            End If

            ALPARAVAL.Add(Val(txtsubtotal.Text.Trim))
            ALPARAVAL.Add(CMBTAX.Text.Trim)
            ALPARAVAL.Add(Val(txttax.Text.Trim))

            ALPARAVAL.Add(CMBOTHERCHGSNAME.Text.Trim)
            If CMBADDSUB.Text.Trim = "Add" Then
                ALPARAVAL.Add(Val(TXTOTHERCHGS.Text.Trim))
            ElseIf CMBADDSUB.Text.Trim = "Sub." Then
                ALPARAVAL.Add(Val((TXTOTHERCHGS.Text.Trim) * (-1)))
            Else
                ALPARAVAL.Add(0)
            End If

            ALPARAVAL.Add(Val(txtroundoff.Text.Trim))
            ALPARAVAL.Add(Val(txtgtotal.Text.Trim))

            ALPARAVAL.Add(Val(TXTAMTREC.Text.Trim))
            ALPARAVAL.Add(Val(TXTEXTRAAMT.Text.Trim))
            ALPARAVAL.Add(Val(txtreturn.Text.Trim))
            ALPARAVAL.Add(Val(TXTBAL.Text.Trim))

            ALPARAVAL.Add(txtinwords.Text.Trim)

            If CHKBILLCHECKED.Checked = True Then
                ALPARAVAL.Add(1)
            Else
                ALPARAVAL.Add(0)
            End If

            If CHKDISPUTE.Checked = True Then
                ALPARAVAL.Add(1)
            Else
                ALPARAVAL.Add(0)
            End If

            If CHKRCM.Checked = True Then ALPARAVAL.Add(1) Else ALPARAVAL.Add(0)
            If CHKMANUAL.Checked = True Then ALPARAVAL.Add(1) Else ALPARAVAL.Add(0)

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            'ADDING FORM TYPE
            Dim FORMTYPE As String = ""
            For Each DTROW As DataRowView In CHKFORMBOX.CheckedItems
                If FORMTYPE = "" Then
                    FORMTYPE = DTROW.Item(0)
                Else
                    FORMTYPE = FORMTYPE & "|" & DTROW.Item(0)
                End If
            Next

            ALPARAVAL.Add(FORMTYPE)

            '' GRID PARAMETERS
            Dim SRNO As String = ""
            Dim NONINVITEM As String = ""
            Dim HSNCODE As String = ""

            Dim SIZE As String = ""
            Dim WT As String = ""
            Dim BATCHNO As String = ""
            Dim PPRSRNO As String = ""
            Dim UNIT As String = ""
            Dim QTY As String = ""
            Dim RATE As String = ""
            Dim AMT As String = ""

            Dim OTHERAMT As String = ""
            Dim TAXABLEAMT As String = ""
            Dim CGSTPER As String = ""
            Dim CGSTAMT As String = ""
            Dim SGSTPER As String = ""
            Dim SGSTAMT As String = ""
            Dim IGSTPER As String = ""
            Dim IGSTAMT As String = ""
            Dim GRIDTOTAL As String = ""
            ' Dim GRNNO As String = ""

            For Each ROW As Windows.Forms.DataGridViewRow In gridbill.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If SRNO = "" Then
                        SRNO = ROW.Cells(gsrno.Index).Value
                        NONINVITEM = ROW.Cells(gdescription.Index).Value.ToString
                        HSNCODE = ROW.Cells(GHSNCODE.Index).Value.ToString

                        SIZE = ROW.Cells(gbillsize.Index).Value.ToString
                        WT = Val(ROW.Cells(gWt.Index).Value)
                        BATCHNO = ROW.Cells(GBATCHNO.Index).Value.ToString
                        PPRSRNO = ROW.Cells(GPPRSRNO.Index).Value.ToString
                        UNIT = ROW.Cells(GUNIT.Index).Value.ToString
                        QTY = Val(ROW.Cells(gQty.Index).Value)
                        RATE = Val(ROW.Cells(gRate.Index).Value)
                        AMT = Val(ROW.Cells(gamount.Index).Value)

                        If ROW.Cells(GOTHERAMT.Index).Value <> Nothing Then
                            OTHERAMT = ROW.Cells(GOTHERAMT.Index).Value
                        Else
                            AMT = "0"
                        End If

                        TAXABLEAMT = ROW.Cells(GTAXABLEAMT.Index).Value
                        CGSTPER = ROW.Cells(GCGSTPER.Index).Value
                        CGSTAMT = ROW.Cells(GCGSTAMT.Index).Value
                        SGSTPER = ROW.Cells(GSGSTPER.Index).Value
                        SGSTAMT = ROW.Cells(GSGSTAMT.Index).Value
                        IGSTPER = ROW.Cells(GIGSTPER.Index).Value
                        IGSTAMT = ROW.Cells(GIGSTAMT.Index).Value
                        GRIDTOTAL = ROW.Cells(GGRIDTOTAL.Index).Value
                        'GRNNO = Val(ROW.Cells(GGRNNO.Index).Value)

                    Else
                        SRNO = SRNO & "|" & ROW.Cells(gsrno.Index).Value
                        NONINVITEM = NONINVITEM & "|" & ROW.Cells(gdescription.Index).Value.ToString
                        HSNCODE = HSNCODE & "|" & ROW.Cells(GHSNCODE.Index).Value

                        SIZE = SIZE & "|" & ROW.Cells(gbillsize.Index).Value.ToString
                        WT = WT & "|" & Val(ROW.Cells(gWt.Index).Value)
                        BATCHNO = BATCHNO & "|" & ROW.Cells(GBATCHNO.Index).Value.ToString
                        PPRSRNO = PPRSRNO & "|" & ROW.Cells(GPPRSRNO.Index).Value.ToString
                        UNIT = UNIT & "|" & ROW.Cells(GUNIT.Index).Value.ToString
                        QTY = QTY & "|" & Val(ROW.Cells(gQty.Index).Value)
                        RATE = RATE & "|" & Val(ROW.Cells(gRate.Index).Value)
                        AMT = AMT & "|" & Val(ROW.Cells(gamount.Index).Value)

                        OTHERAMT = OTHERAMT & "|" & ROW.Cells(GOTHERAMT.Index).Value
                        TAXABLEAMT = TAXABLEAMT & "|" & ROW.Cells(GTAXABLEAMT.Index).Value
                        CGSTPER = CGSTPER & "|" & ROW.Cells(GCGSTPER.Index).Value
                        CGSTAMT = CGSTAMT & "|" & ROW.Cells(GCGSTAMT.Index).Value
                        SGSTPER = SGSTPER & "|" & ROW.Cells(GSGSTPER.Index).Value
                        SGSTAMT = SGSTAMT & "|" & ROW.Cells(GSGSTAMT.Index).Value
                        IGSTPER = IGSTPER & "|" & ROW.Cells(GIGSTPER.Index).Value
                        IGSTAMT = IGSTAMT & "|" & ROW.Cells(GIGSTAMT.Index).Value
                        GRIDTOTAL = GRIDTOTAL & "|" & ROW.Cells(GGRIDTOTAL.Index).Value
                        'GRNNO = GRNNO & "|" & Val(ROW.Cells(GGRNNO.Index).Value)
                    End If
                End If
            Next
            ALPARAVAL.Add(SRNO)
            ALPARAVAL.Add(NONINVITEM)
            ALPARAVAL.Add(HSNCODE)

            ALPARAVAL.Add(SIZE)
            ALPARAVAL.Add(WT)
            ALPARAVAL.Add(BATCHNO)
            ALPARAVAL.Add(PPRSRNO)
            ALPARAVAL.Add(UNIT)
            ALPARAVAL.Add(QTY)
            ALPARAVAL.Add(RATE)
            ALPARAVAL.Add(AMT)

            ALPARAVAL.Add(OTHERAMT)
            ALPARAVAL.Add(TAXABLEAMT)
            ALPARAVAL.Add(CGSTPER)
            ALPARAVAL.Add(CGSTAMT)
            ALPARAVAL.Add(SGSTPER)
            ALPARAVAL.Add(SGSTAMT)
            ALPARAVAL.Add(IGSTPER)
            ALPARAVAL.Add(IGSTAMT)
            ALPARAVAL.Add(GRIDTOTAL)
            ' ALPARAVAL.Add(GRNNO)

            ALPARAVAL.Add(Val(LBLTOTALOTHERAMT.Text.Trim))

            Dim OBJPUR As New ClsPurchaseMaster
            OBJPUR.alParaval = ALPARAVAL

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTTABLE As DataTable = OBJPUR.SAVE()
                MsgBox("Details Added !!")
                TXTBILLNO.Text = DTTABLE.Rows(0).Item(0)

                If CHKTDS.CheckState = CheckState.Checked Then
                    Dim OBJTDS As New DeductTDS
                    OBJTDS.BILLNO = DTTABLE.Rows(0).Item(0)
                    OBJTDS.REGISTER = cmbregister.Text.Trim
                    OBJTDS.ShowDialog()
                End If
            Else

                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                ALPARAVAL.Add(TEMPBILLNO)
                IntResult = OBJPUR.UPDATE()
                MsgBox("Details Updated")
                EDIT = False

            End If
            If gridupload.RowCount > 0 Then SAVEUPLOAD()
            CLEAR()
            cmbname.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub SAVEUPLOAD()
        Try
            Dim OBJORDER As New ClsPurchaseMaster

            For Each ROW As Windows.Forms.DataGridViewRow In gridupload.Rows
                Dim MS As New IO.MemoryStream
                Dim ALPARAVAL As New ArrayList
                If ROW.Cells(GUSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(TXTBILLNO.Text.Trim)
                    ALPARAVAL.Add(cmbregister.Text.Trim)
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

    Sub PRINTREPORT(ByVal PONO As Integer)
        'Try    
        '    tempMsg = MsgBox("Wish to Print PO?", MsgBoxStyle.YesNo)
        '    If tempMsg = vbYes Then
        '        Dim obhpurchorderform As New PurchaseOrderDesign
        '        obhpurchorderform.PONo = tempono
        '        obhpurchorderform.MdiParent = MDIMain
        '        obhpurchorderform.selfor_po = "{PURCHASEORDER.po_no}=" & tempono & " and {PURCHASEORDER.po_cmpid}=" & CmpId & " and {PURCHASEORDER.po_locationid}=" & Locationid & " and {PURCHASEORDER.po_yearid}=" & YearId
        '        obhpurchorderform.vendorname = cmbname.Text.Trim
        '        obhpurchorderform.FRMSTRING = "PURCHASEORDER"
        '        obhpurchorderform.Show()
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If cmbname.Text.Trim.Length = 0 Then
            Ep.SetError(cmbname, "Please Enter Name")
            bln = False
        End If

        If PBPAID.Visible = True Then
            Ep.SetError(lbllocked, "Payment Made, Delete Payment First")
            bln = False
        End If

        If PBTDS.Visible = True Then
            Ep.SetError(lbllocked, "T.D.S. Dudected, Delete Journal First")
            bln = False
        End If

        If PBDN.Visible = True Then
            Ep.SetError(lbllocked, "Debit Note Made, Delete Debit Note First")
            bln = False
        End If

        If cmbregister.Text.Trim.Length = 0 Then
            Ep.SetError(cmbregister, "Please Enter Register")
            bln = False
        End If

        If TXTPARTYBILLNO.Text.Trim.Length = 0 Then
            Ep.SetError(TXTPARTYBILLNO, "Please Enter Party Bill No")
            bln = False
        End If

        'Dim FORMTYPE As String = ""
        'For Each DTROW As DataRowView In CHKFORMBOX.CheckedItems
        '    If FORMTYPE = "" Then
        '        FORMTYPE = DTROW.Item(0)
        '    Else
        '        Ep.SetError(CHKFORMBOX, "Select Only One Form Type")
        '        bln = False
        '    End If
        'Next
        'If FORMTYPE = Nothing Then
        '    Ep.SetError(CHKFORMBOX, "Please Select Form Type")
        '    bln = False
        'End If

        If gridbill.RowCount = 0 Then
            Ep.SetError(cmbname, "Please Enter Item Details")
            bln = False
        End If

        If Not datecheck(PURDATE.Value) Then
            Ep.SetError(PURDATE, "Date not in Accounting Year")
            bln = False
        End If

        If Not datecheck(PARTYBILLDATE.Value) Then
            Ep.SetError(PARTYBILLDATE, "Date not in Accounting Year")
            bln = False
        End If

        If Convert.ToDateTime(PURDATE.Text).Date >= "01/07/2017" Then
            'If TXTSTATECODE.Text.Trim.Length = 0 Then
            '    Ep.SetError(TXTSTATECODE, "Please enter the state code from State Master... ")
            '    bln = False
            'End If

            If TXTGSTIN.Text.Trim.Length = 0 Then
                If MsgBox("GSTIN Not Entered, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Ep.SetError(TXTSTATECODE, "Please enter the state code from State Master... ")
                    bln = False
                End If
            End If

            If CMPSTATECODE <> TXTSTATECODE.Text.Trim And (Val(LBLTOTALCGSTAMT.Text) > 0 Or Val(LBLTOTALSGSTAMT.Text.Trim) > 0) Then
                Ep.SetError(TXTSTATECODE, "Invaid Entry Done in CGST/SGST")
                bln = False
            End If

            If CMPSTATECODE = TXTSTATECODE.Text.Trim And Val(LBLTOTALIGSTAMT.Text) > 0 Then
                Ep.SetError(TXTSTATECODE, "Invaid Entry Done in IGST")
                bln = False
            End If
        End If

        If Convert.ToDateTime(PARTYBILLDATE.Text).Date >= "01/02/2018" Then
            If Val(txtgtotal.Text.Trim) > 50000 And TXTEWAYBILLNO.Text.Trim = "" Then
                If MsgBox("Eway Bill No Not Entered, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    bln = False
                End If
            End If
        End If

        Dim OBJCMN As New ClsCommon
        Dim DT As New DataTable
        If ALLOWMANUALBILLNO = True Then
            If TXTBILLNO.Text <> "" And cmbname.Text.Trim <> "" And EDIT = False Then
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(INVOICEMASTER.INVOICE_NO, '') AS INVOICENO, REGISTERMASTER.register_name AS REGNAME ", "", " INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.register_id AND INVOICEMASTER.INVOICE_CMPID = REGISTERMASTER.register_cmpid AND INVOICEMASTER.INVOICE_LOCATIONID = REGISTERMASTER.register_locationid AND INVOICEMASTER.INVOICE_YEARID = REGISTERMASTER.register_yearid ", "  AND INVOICE_NO = " & Val(TXTBILLNO.Text.Trim) & " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICEMASTER.INVOICE_CMPID = " & CmpId & " AND INVOICEMASTER.INVOICE_LOCATIONID = " & Locationid & " AND INVOICEMASTER.INVOICE_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    Ep.SetError(TXTBILLNO, "Invoice No Already Exist")
                    bln = False
                End If
            End If
        End If


        If Convert.ToDateTime(PURDATE.Text).Date < PURBLOCKDATE.Date Then
            Ep.SetError(PURDATE, "Date is Blocked, Please make entries after " & Format(PURBLOCKDATE.Date, "dd/MM/yyyy"))
            bln = False
        End If


        Return bln
    End Function

    Sub TOTAL()

        lbltotalqty.Text = "0.00"
        lbltotalamt.Text = "0.00"
        LBLTOTALOTHERAMT.Text = "0.0"
        LBLTOTALTAXABLEAMT.Text = "0.0"
        LBLTOTALCGSTAMT.Text = "0.0"
        LBLTOTALSGSTAMT.Text = "0.0"
        LBLTOTALIGSTAMT.Text = "0.0"
        LBLTOTALGRIDAMT.Text = "0.0"
        txtsubtotal.Text = 0
        'txtotherchgS.Text = 0
        txttax.Text = "0.00"
        txtgtotal.Text = 0
        If CHKMANUALTCS.Checked = False Then TXTTCSAMT.Text = 0


        'FETCH TCSPERCENT WITH RESPECT TO DATE
        Dim OBJCMN As New ClsCommon
        Dim DTTCS As DataTable = OBJCMN.search("TOP 1 ISNULL(TCSPER,0) AS TCSPER", "", "TCSPERCENT", " AND TCSDATE <= '" & Format(PARTYBILLDATE.Value.Date, "MM/dd/yyyy") & "' ORDER BY TCSDATE DESC")
        If DTTCS.Rows.Count > 0 Then TXTTCSPER.Text = Val(DTTCS.Rows(0).Item("TCSPER"))


        If gridbill.RowCount > 0 Then
            For Each row As DataGridViewRow In gridbill.Rows

                row.Cells(gamount.Index).Value = (row.Cells(gQty.Index).EditedFormattedValue * row.Cells(gRate.Index).EditedFormattedValue)

                row.Cells(GTAXABLEAMT.Index).Value = Format(Val(row.Cells(gamount.Index).EditedFormattedValue) + Val(row.Cells(GOTHERAMT.Index).EditedFormattedValue), "0.00")
                'row.Cells(GCGSTAMT.Index).Value = Format((Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) * Val(row.Cells(GCGSTPER.Index).EditedFormattedValue) / 100), "0.00")
                'row.Cells(GSGSTAMT.Index).Value = Format((Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) * Val(row.Cells(GSGSTPER.Index).EditedFormattedValue) / 100), "0.00")
                'row.Cells(GIGSTAMT.Index).Value = Format((Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) * Val(row.Cells(GIGSTPER.Index).EditedFormattedValue) / 100), "0.00")

                row.Cells(GGRIDTOTAL.Index).Value = Format(Val(row.Cells(gamount.Index).EditedFormattedValue) + Val(row.Cells(GOTHERAMT.Index).EditedFormattedValue) + Val(row.Cells(GCGSTAMT.Index).EditedFormattedValue) + Val(row.Cells(GSGSTAMT.Index).EditedFormattedValue) + Val(row.Cells(GIGSTAMT.Index).EditedFormattedValue), "0.00")

                'FOR MANUALGST TO BE VERIFIED BY SIR
                If CHKMANUAL.CheckState = CheckState.Unchecked Then
                    row.Cells(GCGSTAMT.Index).Value = Format((Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) * Val(row.Cells(GCGSTPER.Index).EditedFormattedValue) / 100), "0.00")
                    row.Cells(GSGSTAMT.Index).Value = Format((Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) * Val(row.Cells(GSGSTPER.Index).EditedFormattedValue) / 100), "0.00")
                    row.Cells(GIGSTAMT.Index).Value = Format((Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) * Val(row.Cells(GIGSTPER.Index).EditedFormattedValue) / 100), "0.00")
                End If
                row.Cells(GGRIDTOTAL.Index).Value = Format(Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue) + Val(row.Cells(GCGSTAMT.Index).EditedFormattedValue) + Val(row.Cells(GSGSTAMT.Index).EditedFormattedValue) + Val(row.Cells(GIGSTAMT.Index).EditedFormattedValue), "0.00")


                If Val(row.Cells(gQty.Index).Value) > 0 Then lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(row.Cells(gQty.Index).EditedFormattedValue), "0")
                If Val(row.Cells(gamount.Index).Value) > 0 Then lbltotalamt.Text = Format(Val(lbltotalamt.Text) + Val(row.Cells(gamount.Index).EditedFormattedValue), "0.00")

                If Val(row.Cells(GOTHERAMT.Index).Value) <> 0 Then LBLTOTALOTHERAMT.Text = Format(Val(LBLTOTALOTHERAMT.Text) + Val(row.Cells(GOTHERAMT.Index).EditedFormattedValue), "0.00")
                If Val(row.Cells(GTAXABLEAMT.Index).Value) > 0 Then LBLTOTALTAXABLEAMT.Text = Format(Val(LBLTOTALTAXABLEAMT.Text) + Val(row.Cells(GTAXABLEAMT.Index).EditedFormattedValue), "0.00")

                If Val(row.Cells(GCGSTAMT.Index).Value) > 0 Then LBLTOTALCGSTAMT.Text = Format(Val(LBLTOTALCGSTAMT.Text) + Val(row.Cells(GCGSTAMT.Index).EditedFormattedValue), "0.00")
                If Val(row.Cells(GSGSTAMT.Index).Value) > 0 Then LBLTOTALSGSTAMT.Text = Format(Val(LBLTOTALSGSTAMT.Text) + Val(row.Cells(GSGSTAMT.Index).EditedFormattedValue), "0.00")
                If Val(row.Cells(GIGSTAMT.Index).Value) > 0 Then LBLTOTALIGSTAMT.Text = Format(Val(LBLTOTALIGSTAMT.Text) + Val(row.Cells(GIGSTAMT.Index).EditedFormattedValue), "0.00")

                If Val(row.Cells(GGRIDTOTAL.Index).Value) > 0 Then LBLTOTALGRIDAMT.Text = Format(Val(LBLTOTALGRIDAMT.Text) + Val(row.Cells(GGRIDTOTAL.Index).EditedFormattedValue), "0.00")

                If Val(row.Cells(GGRIDTOTAL.Index).Value) > 0 Then txtsubtotal.Text = Format(Val(txtsubtotal.Text) + Val(row.Cells(GGRIDTOTAL.Index).EditedFormattedValue), "0.00")

            Next
        End If


        If CHKTCS.CheckState = CheckState.Checked And CHKMANUALTCS.CheckState = CheckState.Unchecked Then TXTTCSAMT.Text = Format((Val(LBLTOTALGRIDAMT.Text.Trim) * Val(TXTTCSPER.Text.Trim)) / 100, "0.00")

        If CMBEXTRAADDSUB.Text = "Add" Then
            txtsubtotal.Text = Format(Val(LBLTOTALGRIDAMT.Text) + Val(TXTTCSAMT.Text.Trim) + Val(txttranschg.Text) + Val(txtexcise.Text) + Val(TXTEXTRACHGS.Text), "0.00")
        Else
            txtsubtotal.Text = Format((Val(LBLTOTALGRIDAMT.Text) + Val(TXTTCSAMT.Text.Trim) + Val(txttranschg.Text) + Val(txtexcise.Text)) - Val(TXTEXTRACHGS.Text), "0.00")

        End If

        Dim dt As New DataTable
        dt = OBJCMN.search("tax_name, tax_tax as tax", "", " taxmaster", "and TAXMASTER.tax_name = '" & CMBTAX.Text.Trim & "' and tax_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            txttax.Text = Format((Val(dt.Rows(0).Item(1)) * Val(txtsubtotal.Text)) / 100, "0.00")
        End If

        If CMBADDSUB.Text = "Add" Then
            txtgtotal.Text = Format(Val(txtsubtotal.Text) + Val(txttax.Text) + Val(TXTOTHERCHGS.Text), "0")
            txtroundoff.Text = Format(Val(txtgtotal.Text) - (Val(txtsubtotal.Text) + Val(txttax.Text) + Val(TXTOTHERCHGS.Text)), "0.00")
        Else
            txtgtotal.Text = Format(Val(txtsubtotal.Text) + Val(txttax.Text) - Val(TXTOTHERCHGS.Text), "0")
            txtroundoff.Text = Format(Val(txtgtotal.Text) - ((Val(txtsubtotal.Text) + Val(txttax.Text)) - Val(TXTOTHERCHGS.Text)), "0.00")
        End If

        txtgtotal.Text = Format(Val(txtgtotal.Text), "0.00")
        If Val(txtgtotal.Text) <> 0 Then txtinwords.Text = CurrencyToWord(txtgtotal.Text)

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

    Private Sub TXTSRNO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTSRNO.Enter
        If GRIDDOUBLECLICK = False Then
            If gridbill.RowCount > 0 Then
                TXTSRNO.Text = Val(gridbill.Rows(gridbill.RowCount - 1).Cells(gsrno.Index).Value) + 1
            Else
                TXTSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub cmbname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, CMBCODE, e, Me, txtadd, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        gridbill.Enabled = True

        If GRIDDOUBLECLICK = False Then
            gridbill.Rows.Add(Val(TXTSRNO.Text.Trim), CMBNONINVITEM.Text.Trim, TXTHSNCODE.Text.Trim, txtsize.Text.Trim, Format(Val(txtwt.Text.Trim), "0.00"), TXTBATCHNO.Text.Trim, TXTPPRSRNO.Text.Trim, CMBUNIT.Text.Trim, Format(Val(txtqty.Text.Trim), "0.00"), Format(Val(txtrate.Text.Trim), "0.0000"), Format(Val(txtamount.Text.Trim), "0.00"), Format(Val(TXTOTHERAMT.Text.Trim), "0.00"), Format(Val(TXTTAXABLEAMT.Text.Trim), "0.00"), Format(Val(TXTCGSTPER.Text.Trim), "0.00"), Format(Val(TXTCGSTAMT.Text.Trim), "0.00"), Format(Val(TXTSGSTPER.Text.Trim), "0.00"), Format(Val(TXTSGSTAMT.Text.Trim), "0.00"), Format(Val(TXTIGSTPER.Text.Trim), "0.00"), Format(Val(TXTIGSTAMT.Text.Trim), "0.00"), Format(Val(TXTGRIDTOTAL.Text.Trim), "0.00"))
            getsrno(gridbill)
        ElseIf GRIDDOUBLECLICK = True Then
            gridbill.Item(gsrno.Index, TEMPROW).Value = Val(TXTSRNO.Text)
            gridbill.Item(gdescription.Index, TEMPROW).Value = CMBNONINVITEM.Text
            gridbill.Item(GHSNCODE.Index, TEMPROW).Value = TXTHSNCODE.Text.Trim

            gridbill.Item(gbillsize.Index, TEMPROW).Value = txtsize.Text
            gridbill.Item(gWt.Index, TEMPROW).Value = Format(Val(txtwt.Text), "0.00")
            gridbill.Item(GBATCHNO.Index, TEMPROW).Value = TXTBATCHNO.Text
            gridbill.Item(GPPRSRNO.Index, TEMPROW).Value = TXTPPRSRNO.Text.Trim
            gridbill.Item(GUNIT.Index, TEMPROW).Value = CMBUNIT.Text
            gridbill.Item(gQty.Index, TEMPROW).Value = Format(Val(txtqty.Text), "0.00")
            gridbill.Item(gRate.Index, TEMPROW).Value = Format(Val(txtrate.Text), "0.0000")
            gridbill.Item(gamount.Index, TEMPROW).Value = Format(Val(txtamount.Text), "0.00")

            gridbill.Item(GOTHERAMT.Index, TEMPROW).Value = Format(Val(TXTOTHERAMT.Text.Trim), "0.00")
            gridbill.Item(GTAXABLEAMT.Index, TEMPROW).Value = Format(Val(TXTTAXABLEAMT.Text.Trim), "0.00")
            gridbill.Item(GCGSTPER.Index, TEMPROW).Value = Format(Val(TXTCGSTPER.Text.Trim), "0.00")
            gridbill.Item(GCGSTAMT.Index, TEMPROW).Value = Format(Val(TXTCGSTAMT.Text.Trim), "0.00")
            gridbill.Item(GSGSTPER.Index, TEMPROW).Value = Format(Val(TXTSGSTPER.Text.Trim), "0.00")
            gridbill.Item(GSGSTAMT.Index, TEMPROW).Value = Format(Val(TXTSGSTAMT.Text.Trim), "0.00")
            gridbill.Item(GIGSTPER.Index, TEMPROW).Value = Format(Val(TXTIGSTPER.Text.Trim), "0.00")
            gridbill.Item(GIGSTAMT.Index, TEMPROW).Value = Format(Val(TXTIGSTAMT.Text.Trim), "0.00")
            gridbill.Item(GGRIDTOTAL.Index, TEMPROW).Value = Format(Val(TXTGRIDTOTAL.Text.Trim), "0.00")
            GRIDDOUBLECLICK = False
        End If
        'txtamount.ReadOnly = True
        TOTAL()
        gridbill.FirstDisplayedScrollingRowIndex = gridbill.RowCount - 1

        CMBNONINVITEM.Text = ""
        TXTHSNCODE.Clear()
        txtsize.Clear()
        txtwt.Clear()
        TXTBATCHNO.Clear()
        TXTPPRSRNO.Clear()
        txtqty.Clear()
        txtrate.Clear()
        txtamount.Clear()

        TXTOTHERAMT.Clear()
        TXTTAXABLEAMT.Clear()
        TXTCGSTPER.Clear()
        TXTCGSTAMT.Clear()
        TXTSGSTPER.Clear()
        TXTSGSTAMT.Clear()
        TXTIGSTPER.Clear()
        TXTIGSTAMT.Clear()
        TXTGRIDTOTAL.Clear()

        TXTSRNO.Text = Val(gridbill.RowCount)
        CMBNONINVITEM.Focus()

    End Sub

    Private Sub gridbill_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridbill.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        editrow()
    End Sub

    Sub editrow()
        Try
            If gridbill.CurrentRow.Index >= 0 And gridbill.Item(gsrno.Index, gridbill.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                TXTSRNO.Text = gridbill.Item(gsrno.Index, gridbill.CurrentRow.Index).Value
                CMBNONINVITEM.Text = gridbill.Item(gdescription.Index, gridbill.CurrentRow.Index).Value.ToString
                TXTHSNCODE.Text = gridbill.Item(GHSNCODE.Index, gridbill.CurrentRow.Index).Value.ToString
                txtsize.Text = gridbill.Item(gbillsize.Index, gridbill.CurrentRow.Index).Value.ToString
                txtwt.Text = gridbill.Item(gWt.Index, gridbill.CurrentRow.Index).Value
                TXTBATCHNO.Text = gridbill.Item(GBATCHNO.Index, gridbill.CurrentRow.Index).Value.ToString
                TXTPPRSRNO.Text = gridbill.Item(GPPRSRNO.Index, gridbill.CurrentRow.Index).Value
                CMBUNIT.Text = gridbill.Item(GUNIT.Index, gridbill.CurrentRow.Index).Value.ToString
                txtqty.Text = gridbill.Item(gQty.Index, gridbill.CurrentRow.Index).Value
                txtrate.Text = gridbill.Item(gRate.Index, gridbill.CurrentRow.Index).Value
                txtamount.Text = gridbill.Item(gamount.Index, gridbill.CurrentRow.Index).Value

                TXTOTHERAMT.Text = Val(gridbill.Item(GOTHERAMT.Index, gridbill.CurrentRow.Index).Value)
                TXTTAXABLEAMT.Text = Val(gridbill.Item(GTAXABLEAMT.Index, gridbill.CurrentRow.Index).Value)
                TXTCGSTPER.Text = Val(gridbill.Item(GCGSTPER.Index, gridbill.CurrentRow.Index).Value)
                TXTCGSTAMT.Text = Val(gridbill.Item(GCGSTAMT.Index, gridbill.CurrentRow.Index).Value)
                TXTSGSTPER.Text = Val(gridbill.Item(GSGSTPER.Index, gridbill.CurrentRow.Index).Value)
                TXTSGSTAMT.Text = Val(gridbill.Item(GSGSTAMT.Index, gridbill.CurrentRow.Index).Value)

                TXTIGSTPER.Text = Val(gridbill.Item(GIGSTPER.Index, gridbill.CurrentRow.Index).Value)
                TXTIGSTAMT.Text = Val(gridbill.Item(GIGSTAMT.Index, gridbill.CurrentRow.Index).Value)
                TXTGRIDTOTAL.Text = Val(gridbill.Item(GGRIDTOTAL.Index, gridbill.CurrentRow.Index).Value)


                TEMPROW = gridbill.CurrentRow.Index
                CMBNONINVITEM.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROMCITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBFROMCITY.Enter
        Try
            If CMBFROMCITY.Text.Trim <> "" Then fillCITY(CMBTOCITY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROMCITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFROMCITY.Validating
        Try
            If CMBFROMCITY.Text.Trim <> "" Then CITYVALIDATE(CMBFROMCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOCITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTOCITY.Enter
        Try
            If CMBFROMCITY.Text.Trim = "" Then fillCITY(CMBTOCITY, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOCITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTOCITY.Validating
        Try
            If CMBTOCITY.Text.Trim <> "" Then CITYVALIDATE(CMBTOCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtrans.Validating
        Try
            If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, CMBCODE, e, Me, TXTTRANSADD, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "TRANSPORT")

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'PURCHASE'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
            GETMAX_PO_NO()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 And EDIT = False Then
                'clear()
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    PURREGABBR = dt.Rows(0).Item(0).ToString
                    PURREGINITIAL = dt.Rows(0).Item(1).ToString
                    PURREGID = dt.Rows(0).Item(2)
                    GETMAX_PO_NO()
                    cmbregister.Enabled = False
                Else
                    MsgBox("Register Not Present, Add New from Master Module")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtamount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtamount.Validating
        'If CMBNONINVITEM.Text.Trim <> "" And CMBUNIT.Text.Trim <> "" Then
        '    If Val(txtqty.Text.Trim) > 0 And Val(txtrate.Text.Trim) > 0 And Val(txtamount.Text.Trim) > 0 Then
        '        fillgrid()
        '        total()
        '    Else
        '        If Val(txtqty.Text.Trim) <= 0 Then
        '            MsgBox("Please Fill Qty ")
        '            txtqty.Focus()
        '            Exit Sub
        '        End If

        '        If Val(txtrate.Text.Trim) <= 0 Then
        '            MsgBox("Please Fill Rate ")
        '            txtrate.Focus()
        '            Exit Sub
        '        End If
        '    End If

        'ElseIf CMBNONINVITEM.Text.Trim <> "" And Val(txtamount.Text.Trim) > 0 Then
        '    fillgrid()
        '    total()
        'Else

        '    'If CMBNONINVITEM.Text.Trim = "" Then
        '    '    MsgBox("Please Fill Description ")
        '    '    CMBNONINVITEM.Focus()
        '    '    Exit Sub
        '    'End If

        '    'If CMBUNIT.Text.Trim = "" Then
        '    '    MsgBox("Please Fill Unit ")
        '    '    CMBUNIT.Focus()
        '    '    Exit Sub
        '    'End If

        '    'If Val(txtqty.Text.Trim) = 0 Then
        '    '    MsgBox("Please Fill Quantity ")
        '    '    txtqty.Focus()
        '    '    Exit Sub
        '    'End If
        '    'If Val(txtrate.Text.Trim) = 0 Then
        '    '    MsgBox("Please Fill Rate ")
        '    '    txtrate.Focus()
        '    '    Exit Sub
        '    'End If
        '    If CMBNONINVITEM.Text.Trim = "" Then
        '        MsgBox("Please Fill Description ")
        '        CMBNONINVITEM.Focus()
        '        Exit Sub
        '    End If
        '    If Val(txtamount.Text.Trim) <= 0 Then
        '        MsgBox("Please Fill Amt ")
        '        txtamount.Focus()
        '        Exit Sub
        '    End If
        'End If
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

    Sub calc()
        Try
            If Val(txtqty.Text.Trim) > 0 And Val(txtrate.Text.Trim) > 0 Then
                txtamount.Text = "0.00"
                If LCase(CMBUNIT.Text.Trim) = "reams" Then txtamount.Text = Format(Val(txtwt.Text.Trim) * Val(txtrate.Text.Trim), "0.000") Else txtamount.Text = Format(Val(txtqty.Text.Trim) * Val(txtrate.Text.Trim), "0.000")
            End If

            txtamount.Text = 0.0
            TXTGRIDTOTAL.Text = 0.0
            'TXTCGSTAMT.Text = 0.0
            'TXTSGSTAMT.Text = 0.0
            'TXTIGSTAMT.Text = 0.0

            If CHKMANUAL.CheckState = CheckState.Unchecked Then
                TXTCGSTAMT.Text = 0.0
                TXTSGSTAMT.Text = 0.0
                TXTIGSTAMT.Text = 0.0
            End If

            If Val(txtrate.Text.Trim) > 0 And Val(txtqty.Text.Trim) > 0 Then

                txtamount.Text = Format(Val(txtqty.Text) * Val(txtrate.Text), "0.00")

            End If
            TXTTAXABLEAMT.Text = Format((Val(txtamount.Text.Trim) + Val(TXTOTHERAMT.Text.Trim)), "0.00")

            If CHKMANUAL.CheckState = CheckState.Unchecked Then
                TXTCGSTAMT.Text = Format(Val(TXTCGSTPER.Text) / 100 * Val(TXTTAXABLEAMT.Text), "0.00")
                TXTSGSTAMT.Text = Format(Val(TXTSGSTPER.Text) / 100 * Val(TXTTAXABLEAMT.Text), "0.00")
                TXTIGSTAMT.Text = Format(Val(TXTIGSTPER.Text) / 100 * Val(TXTTAXABLEAMT.Text), "0.00")
            End If

            'TXTCGSTAMT.Text = Format(Val(TXTCGSTPER.Text) / 100 * Val(TXTTAXABLEAMT.Text), "0.00")
            'TXTSGSTAMT.Text = Format(Val(TXTSGSTPER.Text) / 100 * Val(TXTTAXABLEAMT.Text), "0.00")
            'TXTIGSTAMT.Text = Format(Val(TXTIGSTPER.Text) / 100 * Val(TXTTAXABLEAMT.Text), "0.00")
            TXTGRIDTOTAL.Text = Format(Val(TXTTAXABLEAMT.Text) + Val(TXTCGSTAMT.Text) + Val(TXTSGSTAMT.Text) + Val(TXTIGSTAMT.Text), "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtqty_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqty.Validated, txtrate.Validated
        WTCALC()
        calc()
    End Sub

    Private Sub txtwt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtwt.KeyPress, txtqty.KeyPress, txttranschg.KeyPress, txtexcise.KeyPress
        numdot(e, sender, Me)
    End Sub

    Private Sub TXTCRDAYS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCRDAYS.Validating
        Try
            If (Val(TXTCRDAYS.Text.Trim)) > 0 Then DueDate.Value = DateAdd(DateInterval.Day, Val(TXTCRDAYS.Text.Trim), PARTYBILLDATE.Value.Date)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txttranschg_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttranschg.Validated, TXTEXTRAAMT.Validated, TXTOTHERCHGS.Validating, CMBADDSUB.Validating, CMBTAX.Validated, txttax.Validated, TXTOTHERCHGS.Validating, CMBEXTRAADDSUB.Validated, CMBEXTRACHGSNAME.Validated, TXTEXTRACHGS.Validated
        TOTAL()
    End Sub

    Private Sub PARTYBILLDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PARTYBILLDATE.Validating
        If Not datecheck(PARTYBILLDATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
        Try
            If PARTYBILLDATE.Value.Date > PURDATE.Value.Date Then
                MsgBox("Enter Proper Date !")
                e.Cancel = True
            End If
            If Val(TXTCRDAYS.Text.Trim) > 0 Then DueDate.Value = DateAdd(DateInterval.Day, Val(TXTCRDAYS.Text), PARTYBILLDATE.Value.Date) Else DueDate.Value = PARTYBILLDATE.Value
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPARTYBILLNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPARTYBILLNO.Validating
        Try
            If TXTPARTYBILLNO.Text.Trim <> "" Then
                If EDIT = False Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("PURCHASEMASTER.bill_initials AS BILLNO", "", "PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.bill_ledgerid = LEDGERS.Acc_id AND PURCHASEMASTER.bill_yearid = LEDGERS.Acc_yearid", "AND LEDGERS.Acc_CMPNAME = '" & cmbname.Text.Trim & "' AND BILL_PARTYBILLNO = '" & TXTPARTYBILLNO.Text.Trim & "' AND BILL_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        MsgBox("Party Bill NO Already Exists in Entry No" & DT.Rows(0).Item("BILLNO"))
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbname.Validated
        Try
            If cmbname.Text.Trim <> "" Then
                Dim objcmn As New ClsCommon
                Dim dt As DataTable = objcmn.search(" ISNULL(LEDGERS.Acc_panno, '') AS PANNO, ISNULL(LEDGERS.Acc_tinno, '') AS TINNO, ISNULL(LEDGERS.Acc_cstno, '') AS CSTNO, ISNULL(LEDGERS.Acc_vatno, '') AS VATNO, ISNULL(ACC_CRDAYS,0) AS CRDAYS, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN, ISNULL(LEDGERS.ACC_TDSAC,0) AS TDSPER ", "", "LEDGERS LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", "AND LEDGERS.acc_cmpname = '" & cmbname.Text.Trim & "'AND acc_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    'txtadd.Text = dt.Rows(0).Item("ADDRESS")
                    txtpanno.Text = dt.Rows(0).Item("PANNO")
                    txtcstno.Text = dt.Rows(0).Item("CSTNO")
                    txttinno.Text = dt.Rows(0).Item("TINNO")
                    txtvatno.Text = dt.Rows(0).Item("VATNO")
                    TXTCRDAYS.Text = Val(dt.Rows(0).Item("CRDAYS"))

                    TXTSTATECODE.Text = dt.Rows(0).Item("STATECODE")
                    TXTGSTIN.Text = dt.Rows(0).Item("GSTIN")

                    DueDate.Value = DateAdd(DateInterval.Day, Val(TXTCRDAYS.Text.Trim), PARTYBILLDATE.Value.Date)

                    If Val(dt.Rows(0).Item("TDSPER")) > 0 Then
                        CHKTDS.CheckState = CheckState.Checked
                        TXTTDSPER.Text = Val(dt.Rows(0).Item("TDSPER"))
                    End If

                End If


            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            gridbill.RowCount = 0
Line1:
            TEMPBILLNO = Val(TXTBILLNO.Text) - 1
            TEMPREGNAME = cmbregister.Text.Trim
            If TEMPBILLNO > 0 Then
                EDIT = True
                PurchaseMaster_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If gridbill.RowCount = 0 And TEMPBILLNO > 1 Then
                TXTBILLNO.Text = TEMPBILLNO
                GoTo Line1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            gridbill.RowCount = 0
LINE1:
            TEMPBILLNO = Val(TXTBILLNO.Text) + 1
            TEMPREGNAME = cmbregister.Text.Trim
            GETMAX_PO_NO()
            Dim MAXNO As Integer = TXTBILLNO.Text.Trim
            CLEAR()
            If Val(TXTBILLNO.Text) - 1 >= TEMPBILLNO Then
                EDIT = True
                PurchaseMaster_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If gridbill.RowCount = 0 And TEMPBILLNO < MAXNO Then
                TXTBILLNO.Text = TEMPBILLNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            gridbill.RowCount = 0
            TEMPBILLNO = Val(tstxtbillno.Text)
            TEMPREGNAME = cmbregister.Text.Trim
            If TEMPBILLNO > 0 Then
                EDIT = True
                PurchaseMaster_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If lbllocked.Visible = True Then
                Ep.SetError(lbllocked, "Invoice Locked")
                Exit Sub
            End If

            If EDIT = True Then
                Dim intresult As Integer
                Dim objpur As New ClsPurchaseMaster()
                Dim TEMPMSG As Integer = MsgBox("Wish to Delete?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alparaval As New ArrayList
                    alparaval.Add(TEMPBILLNO)
                    alparaval.Add(TEMPREGNAME)
                    alparaval.Add(CmpId)
                    alparaval.Add(YearId)
                    alparaval.Add(Userid)

                    objpur.alParaval = alparaval
                    intresult = objpur.delete
                    MsgBox("Purchase Invoice Deleted!!!")
                    CLEAR()
                    EDIT = False
                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim objpurinv As New PurchaseMasterDetails
            objpurinv.MdiParent = MDIMain
            objpurinv.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lrdate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles lrdate.Validating
        If Not datecheck(lrdate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub PURDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PURDATE.Validating
        If Not datecheck(PURDATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub cmbtax_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTAX.Validating
        Try
            If CMBTAX.Text.Trim <> "" Then TAXvalidate(CMBTAX, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtax_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTAX.Enter
        Try
            If CMBTAX.Text.Trim = "" Then filltax(CMBTAX, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, "AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbname.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTs'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbname.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbtrans.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'"
                OBJLEDGER.ShowDialog()
                'If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then cmbtrans.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROMCITY_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBFROMCITY.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCITY As New SelectCity
                OBJCITY.FRMSTRING = "CITY"
                OBJCITY.ShowDialog()
                If OBJCITY.TEMPNAME <> "" Then CMBFROMCITY.Text = OBJCITY.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOCITY_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBTOCITY.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCITY As New SelectCity
                OBJCITY.FRMSTRING = "CITY"
                OBJCITY.ShowDialog()
                If OBJCITY.TEMPNAME <> "" Then CMBTOCITY.Text = OBJCITY.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridbill.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridbill.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                gridbill.Rows.RemoveAt(gridbill.CurrentRow.Index)
                TOTAL()
                getsrno(gridbill)
                TOTAL()

            ElseIf e.KeyCode = Keys.F8 Then
                editrow()
                'ElseIf e.KeyCode = Keys.F12 And gridorders.RowCount > 0 Then
                '    If gridorders.CurrentRow.Cells(GQUALITY.Index).Value <> "" Then gridorders.Rows.Add(CloneWithValues(gridorders.CurrentRow))
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTCRDAYS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCRDAYS.KeyPress, TXTBILLNO.KeyPress
        numkeypress(e, TXTCRDAYS, Me)
    End Sub

    Private Sub txtotherchgS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTOTHERCHGS.KeyPress, TXTEXTRACHGS.KeyPress, txtrate.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
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

    Private Sub CMBSHELF_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSHELF.Enter
        Try
            If CMBSHELF.Text.Trim = "" Then fillSHELF(CMBSHELF, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHELF_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSHELF.Validating
        Try
            If CMBSHELF.Text.Trim <> "" Then SHELFVALIDATE(CMBSHELF, e, Me)
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

    Private Sub CMBUNIT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBUNIT.Enter
        Try
            If CMBUNIT.Text.Trim = "" Then fillUNIT(CMBUNIT)
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

    Private Sub CMBNONINVITEM_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNONINVITEM.Validated
        Try
            If CMBNONINVITEM.Text.Trim = "" Then txttranschg.Focus()

            TXTHSNCODE.Clear()
            TXTCGSTPER.Clear()
            TXTCGSTAMT.Clear()
            TXTSGSTPER.Clear()
            TXTSGSTAMT.Clear()
            TXTIGSTPER.Clear()
            TXTIGSTAMT.Clear()

            If CMBNONINVITEM.Text.Trim <> "" And Convert.ToDateTime(PURDATE.Text).Date >= "01/07/2017" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("  ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER ", "", "HSNMASTER INNER JOIN NONINVITEMMASTER ON HSNMASTER.HSN_ID = NONINVITEMMASTER.NONINV_HSNCODEID AND HSNMASTER.HSN_YEARID = NONINVITEMMASTER.NONINV_yearid ", " AND NONINVITEMMASTER.NONINV_NAME= '" & CMBNONINVITEM.Text.Trim & "' AND HSNMASTER.HSN_CMPID='" & CmpId & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                If DT.Rows.Count > 0 Then
                    TXTHSNCODE.Text = DT.Rows(0).Item("HSNCODE")
                    If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                        TXTIGSTPER.Text = 0
                        TXTCGSTPER.Text = Val(DT.Rows(0).Item("CGSTPER"))
                        TXTSGSTPER.Text = Val(DT.Rows(0).Item("SGSTPER"))
                    Else
                        TXTCGSTPER.Text = 0
                        TXTSGSTPER.Text = 0
                        TXTIGSTPER.Text = Val(DT.Rows(0).Item("IGSTPER"))
                    End If
                End If
                calc()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNONINVITEM_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNONINVITEM.Validating
        Try
            If CMBNONINVITEM.Text <> "" Then NONINVITEMVALIDATE(CMBNONINVITEM, e, Me)
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

    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        Try
            Dim OBJRECPAY As New ShowRecPay
            OBJRECPAY.MdiParent = MDIMain

            OBJRECPAY.PURBILLINITIALS = PURREGINITIAL & "-" & TEMPBILLNO
            OBJRECPAY.SALEBILLINITIALS = PURREGINITIAL & "-" & TEMPBILLNO
            OBJRECPAY.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLDN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDN.Click
        Try
            If PBPAID.Visible = True Then
                MsgBox("Pay made, Delete Pay First", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If lbllocked.Visible = True Or PBlock.Visible = True Then
                MsgBox("Booking Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If EDIT = True Then
                Dim TEMPMSG As Integer = MsgBox("Wish to create Debit Note?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJdN As New DebitNote
                    OBJdN.MdiParent = MDIMain
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" REGISTER_INITIALS AS INITIALS", "", " REGISTERMASTER ", " AND REGISTER_NAME  = '" & cmbregister.Text.Trim & "' AND REGISTER_YEARID = " & YearId)
                    OBJdN.BILLNO = DT.Rows(0).Item("INITIALS") & "-" & Val(TXTBILLNO.Text.Trim)
                    OBJdN.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOTHERCHGSNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBOTHERCHGSNAME.Enter
        Try
            If CMBOTHERCHGSNAME.Text.Trim = "" Then fillname(CMBOTHERCHGSNAME, EDIT, "  and (GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses') ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOTHERCHGSNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBOTHERCHGSNAME.Validating
        Try
            If CMBOTHERCHGSNAME.Text.Trim <> "" Then namevalidate(CMBOTHERCHGSNAME, CMBCODE, e, Me, txtadd, "  and (GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses') ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtrate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtrate.Validating
        'If Val(txtqty.Text) <= 0 And Val(txtrate.Text) <= 0 Then txtamount.ReadOnly = False
    End Sub

    Private Sub CHKTCS_CheckedChanged(sender As Object, e As EventArgs) Handles CHKTCS.CheckedChanged
        If CHKTCS.Checked = False Then
            CHKMANUALTCS.Checked = False
            TXTTCSAMT.Text = 0.0
        End If
        TOTAL()
    End Sub

    Private Sub txtwt_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtwt.Validating
        WTCALC()
        calc()
    End Sub

    Private Sub TXTSHEETSPERREAM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTSHEETSPERREAM.KeyPress
        numkeypress(e, TXTSHEETSPERREAM, Me)
    End Sub

    Private Sub CHKMANUALTCS_CheckedChanged(sender As Object, e As EventArgs) Handles CHKMANUALTCS.CheckedChanged
        If CHKMANUALTCS.Checked = True Then
            TXTTCSAMT.ReadOnly = False
            TXTTCSAMT.BackColor = Color.LemonChiffon
        Else
            TXTTCSAMT.ReadOnly = True
            TXTTCSAMT.BackColor = Color.Linen
            TOTAL()
        End If
    End Sub


    Private Sub TXTSHEETSPERREAM_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSHEETSPERREAM.Validated
        WTCALC()
    End Sub

    Private Sub CMDSELECTGRN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTGRN.Click
        Try

            If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If cmbname.Text.Trim <> "" Then

                Dim OBJSELECTGRN As New SelectGRN
                OBJSELECTGRN.PARTYNAME = cmbname.Text
                Dim DTGRN As DataTable = OBJSELECTGRN.DT
                OBJSELECTGRN.ShowDialog()


                If DTGRN.Rows.Count > 0 Then
                    Dim OBJCMN As New ClsCommon
                    For Each DTROW As DataRow In DTGRN.Rows
                        Dim DT As DataTable = OBJCMN.search(" GRN.GRN_NO AS GRNNO,  ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(TRANSPORT.Acc_cmpname, '') AS TRANSPORT, GRN.GRN_DATE AS GRNDATE, GRN_DESC.GRN_SRNO AS GRNSRNO, ISNULL(GRN_DESC.GRN_SIZE,0) AS SIZE, ISNULL(GRN_DESC.GRN_WT,0) AS WT, ISNULL(GRN_DESC.GRN_QTY, 0) AS QTY, '" & DTROW("TYPE") & "'AS TYPE, ISNULL(HSN_CODE,'') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER ", "", " GRN INNER JOIN GRN_DESC ON GRN.GRN_NO = GRN_DESC.GRN_NO AND GRN.GRN_YEARID = GRN_DESC.GRN_YEARID INNER JOIN LEDGERS ON GRN.GRN_LEDGERID = LEDGERS.Acc_id INNER JOIN GODOWNMASTER ON GRN.GRN_GODOWNID = GODOWNMASTER.GODOWN_id INNER JOIN NONINVITEMMASTER ON GRN_DESC.GRN_ITEMID = NONINVITEMMASTER.NONINV_ID INNER JOIN UNITMASTER ON GRN_DESC.GRN_UNITID = UNITMASTER.unit_id LEFT OUTER JOIN LEDGERS AS TRANSPORT ON GRN.GRN_TRANSID = TRANSPORT.Acc_id LEFT OUTER JOIN HSNMASTER ON NONINVITEMMASTER.NONINV_HSNCODEID = HSNMASTER.HSN_ID ", " AND GRN.GRN_NO = " & Val(DTROW("GRNNO")) & " AND GRN_DESC.GRN_SRNO = " & Val(DTROW("GRNSRNO")) & " AND GRN.GRN_YEARID = " & YearId & " ORDER BY GRN.GRN_NO")
                        If DT.Rows.Count > 0 Then

                            CMBGODOWN.Text = DT.Rows(0).Item("GODOWN")
                            TXTGRNNO.Text = DT.Rows(0).Item("GRNNO")

                            'ITEM GRID
                            For Each ROW As DataRow In DT.Rows
                                If ROW("ITEMNAME").ToString <> "" And Convert.ToDateTime(PURDATE.Text).Date >= "01/07/2017" Then
                                    If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                        gridbill.Rows.Add(0, ROW("ITEMNAME"), ROW("HSNCODE"), ROW("SIZE"), Format(Val(ROW("WT")), "0.00"), "", "", ROW("UNIT"), Format(Val(ROW("QTY")), "0.00"), 0, 0, 0, 0, ROW("CGSTPER"), 0, ROW("SGSTPER"), 0, 0, 0, 0, 0)
                                    Else
                                        gridbill.Rows.Add(0, ROW("ITEMNAME"), ROW("HSNCODE"), ROW("SIZE"), Format(Val(ROW("WT")), "0.00"), "", "", ROW("UNIT"), Format(Val(ROW("QTY")), "0.00"), 0, 0, 0, 0, 0, 0, 0, 0, ROW("IGSTPER"), 0, 0, 0)
                                    End If
                                Else
                                    gridbill.Rows.Add(0, ROW("ITEMNAME").ToString, "", ROW("SIZE"), Format(Val(ROW("WT")), "0.00"), "", "", ROW("UNIT"), Format(Val(ROW("QTY")), "0.00"), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                                End If
                            Next

                            TOTAL()
                            getsrno(gridbill)
                            CMDSELECTGRN.Enabled = False
                        End If
                    Next
                End If


                If gridbill.RowCount > 0 Then
                    gridbill.Focus()
                    gridbill.CurrentCell = gridbill.Rows(0).Cells(gRate.Index)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub txtamount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtamount.KeyPress
        numkeypress(e, txtamount, Me)
    End Sub

    Private Sub TXTGRIDTOTAL_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTGRIDTOTAL.Validating
        If CMBNONINVITEM.Text.Trim <> "" And CMBUNIT.Text.Trim <> "" Then
            If Val(txtqty.Text.Trim) > 0 And Val(txtrate.Text.Trim) > 0 And Val(txtamount.Text.Trim) > 0 And Val(TXTTAXABLEAMT.Text.Trim) <> 0 And Val(TXTGRIDTOTAL.Text.Trim) <> 0 Then
                fillgrid()
                TOTAL()
            Else
                If Val(txtqty.Text.Trim) <= 0 Then
                    MsgBox("Please Fill Qty ")
                    txtqty.Focus()
                    Exit Sub
                End If

                If Val(txtrate.Text.Trim) <= 0 Then
                    MsgBox("Please Fill Rate ")
                    txtrate.Focus()
                    Exit Sub
                End If
            End If

        ElseIf CMBNONINVITEM.Text.Trim <> "" And Val(txtamount.Text.Trim) > 0 Then
            fillgrid()
            TOTAL()
        Else

            'If CMBNONINVITEM.Text.Trim = "" Then
            '    MsgBox("Please Fill Description ")
            '    CMBNONINVITEM.Focus()
            '    Exit Sub
            'End If

            'If CMBUNIT.Text.Trim = "" Then
            '    MsgBox("Please Fill Unit ")
            '    CMBUNIT.Focus()
            '    Exit Sub
            'End If

            'If Val(txtqty.Text.Trim) = 0 Then
            '    MsgBox("Please Fill Quantity ")
            '    txtqty.Focus()
            '    Exit Sub
            'End If
            'If Val(txtrate.Text.Trim) = 0 Then
            '    MsgBox("Please Fill Rate ")
            '    txtrate.Focus()
            '    Exit Sub
            'End If
            If CMBNONINVITEM.Text.Trim = "" Then
                MsgBox("Please Fill Description ")
                CMBNONINVITEM.Focus()
                Exit Sub
            End If
            If Val(txtamount.Text.Trim) <= 0 Then
                MsgBox("Please Fill Amt ")
                txtamount.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub TXTOTHERAMT_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTOTHERAMT.Validated, TXTOTHERAMT.Validated, TXTCGSTAMT.Validated, TXTSGSTAMT.Validated, TXTIGSTAMT.Validated
        Try
            calc()

            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKMANUAL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKMANUAL.CheckedChanged
        Try
            If CHKMANUAL.Checked = True Then
                TXTCGSTAMT.ReadOnly = False
                TXTCGSTAMT.TabStop = True
                TXTCGSTAMT.BackColor = Color.LemonChiffon
                TXTSGSTAMT.ReadOnly = False
                TXTSGSTAMT.TabStop = True
                TXTSGSTAMT.BackColor = Color.LemonChiffon
                TXTIGSTAMT.ReadOnly = False
                TXTIGSTAMT.TabStop = True
                TXTIGSTAMT.BackColor = Color.LemonChiffon
            Else
                TXTCGSTAMT.ReadOnly = True
                TXTCGSTAMT.TabStop = False
                TXTCGSTAMT.BackColor = Color.Linen
                TXTSGSTAMT.ReadOnly = True
                TXTSGSTAMT.TabStop = False
                TXTSGSTAMT.BackColor = Color.Linen
                TXTIGSTAMT.ReadOnly = True
                TXTIGSTAMT.TabStop = False
                TXTIGSTAMT.BackColor = Color.Linen
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBILLNO_Validating(sender As Object, e As CancelEventArgs) Handles TXTBILLNO.Validating
        Try
            If ALLOWMANUALBILLNO = True Then
                If (Val(TXTBILLNO.Text.Trim) <> 0 And cmbregister.Text.Trim <> "" And EDIT = False) Or (EDIT = True And TEMPBILLNO <> Val(TXTBILLNO.Text.Trim)) Then
                    Dim OBJCMN As New ClsCommon
                    Dim dttable As DataTable = OBJCMN.search(" ISNULL(INVOICEMASTER.INVOICE_NO,0)  AS INVNO", "", " INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID AND INVOICE_CMPID = REGISTER_CMPID AND INVOICE_LOCATIONID = REGISTER_LOCATIONID AND INVOICE_YEARID = REGISTER_YEARID ", "  AND INVOICEMASTER.INVOICE_NO=" & TXTBILLNO.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICEMASTER.INVOICE_CMPID = " & CmpId & " AND INVOICEMASTER.INVOICE_LOCATIONID = " & Locationid & " AND INVOICEMASTER.INVOICE_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        MsgBox("Invoice No Already Exist")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles gridbill.CellValidating
        Try
            Dim colNum As Integer = gridbill.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case gQty.Index, gRate.Index, GOTHERAMT.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If gridbill.CurrentCell.Value = Nothing Then gridbill.CurrentCell.Value = "0.000"
                        gridbill.CurrentCell.Value = Convert.ToDecimal(gridbill.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        TOTAL()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                    End If
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class