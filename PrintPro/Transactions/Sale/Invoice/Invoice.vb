
Imports BL
Imports System.IO
Imports System.Net
Imports System.ComponentModel
Imports RestSharp
Imports Newtonsoft.Json
Imports TaxProEInvoice.API

Public Class Invoice

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public Shared selectsotable As New DataTable
    Dim gridDoubleClick As Boolean
    Dim gridUPLOADDoubleClick As Boolean
    Dim temprow, SALEREGID As Integer
    Public edit As Boolean
    Public FRMSTRING As String
    Public TEMPINVOICENO, TEMPREGNAME, TEMPACCCODE As String
    Public tempMsg As Integer
    Dim tempUPLOADrow As Integer
    Dim saleregabbr, salereginitial As String
    Public fromno, tono As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        edit = False
        cmbregister.Enabled = True
        cmbregister.Focus()
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

    Sub CLEAR()

        invoicedate.Value = Mydate
        'cmbregister.Text = ""
        TXTINVOICENO.ReadOnly = False
        txtname.Clear()

        TXTSTATECODE.Clear()
        TXTGSTIN.Clear()
        TXTQCPAPER.Clear()
        TXTQCUPS.Clear()
        TXTQCADHESIVE.Clear()
        TXTQCBATCH.Clear()
        TXTQCCOLOR.Clear()
        TXTQCDESIGN.Clear()
        TXTQCFINALAMT.Clear()
        TXTQCGRAIN.Clear()
        TXTQCGSM.Clear()
        TXTQCHEAD.Clear()
        TXTQCLABEL.Clear()
        TXTQCPACKET.Clear()
        TXTQCPAPER.Clear()
        TXTQCPERFOR.Clear()
        TXTQCPHARMA.Clear()
        TXTQCREMARKS.Clear()
        TXTINKDETAILS.Clear()
        TXTQCSHIPPER.Clear()
        TXTQCSIZE.Clear()
        TXTQCSTICKER.Clear()
        TXTQCVARNISH.Clear()
        TXTQCVISUAL.Clear()
        TXTQCTEXT.Clear()

        QCDATE.Value = Mydate

        txtpono.Clear()
        txtpodate.Clear()
        txtchallanno.Clear()
        txtchallanno.Enabled = True
        TXTMULTICHALLANNO.Clear()
        TXTMULTIPONO.Clear()
        TXTEWAYBILLNO.Clear()
        txtchallandate.Clear()
        TXTTRANSNAME.Clear()
        CMBNAME.Text = ""

        txtdeladd.Clear()

        txtremarks.Clear()

        txtprocessing.Clear()
        txtroundoff.Text = "0.00"
        txtreturn.Clear()
        TXTOTHERCHGS.Text = "0.00"
        txtpakagingchgs.Text = "0.00"
        txtprocessing.Text = "0.00"
        CMDSELECTCHALLAN.Enabled = True

        TXTINVOICENO.Clear()
        cmbaddsub.Text = ""
        CMBEXTRAADDSUB.Text = ""

        gridinvoice.RowCount = 0
        GETMAX_INVOICE_NO()
        Ep.Clear()
        PBCN.Visible = False
        PBRECD.Visible = False
        lbllocked.Visible = False
        PBlock.Visible = False
        cmdshowdetails.Visible = False

        TXTEXTRACHGS.Text = "0.00"

        CMBTAX.Text = ""
        cmbregister.Focus()
        txtinwords.Clear()
        txttax.Text = "0.00"
        txtgrandtotal.Text = "0.00"

        gridUPLOADDoubleClick = False

        TXTUPLOADSRNO.Text = 1
        txtuploadremarks.Clear()
        txtuploadname.Clear()
        PBSOFTCOPY.Image = Nothing
        TXTIMGPATH.Clear()
        gridupload.RowCount = 0
        tstxtbillno.Clear()

        txtprintfrom.Clear()
        txtprintto.Clear()
        TabControl1.SelectedIndex = 0

        'For I As Integer = 0 To CHKFORMBOX.Items.Count - 1
        '    Dim DTR As DataRowView = CHKFORMBOX.Items(I)
        '    CHKFORMBOX.SetItemCheckState(I, CheckState.Unchecked)
        'Next
        'CHKFORMBOX.SetItemChecked(CHKFORMBOX.FindStringExact("GST"), True)


        CMBOTHERCHGSNAME.Text = ""
        CMBEXTRACHGSNAME.Text = ""

        CHKMANUAL.CheckState = CheckState.Unchecked
        CHKPACKET.CheckState = CheckState.Unchecked

        LBLTOTALQTY.Text = "0.00"
        lbltotalamt.Text = "0.00"
        LBLTOTALOTHERAMT.Text = "0.00"
        LBLTOTALTAXABLEAMT.Text = "0.00"
        LBLTOTALCGSTAMT.Text = "0.00"
        LBLTOTALSGSTAMT.Text = "0.00"
        LBLTOTALIGSTAMT.Text = "0.00"
        LBLTOTALGRIDAMT.Text = "0.00"
        TXTSUBTOTAL.Text = "0.00"
        cmbstate.Text = ""

        CHKTCS.Checked = False
        TXTTCSPER.Clear()
        TXTTCSAMT.Clear()
        CHKBILLCHECKED.Checked = False
        CHKDISPUTE.Checked = False

        TXTVEHICLENO.Clear()
        TXTLRNO.Clear()
        TXTIRNNO.Clear()
        CMBHSNCODE.Text = ""
        LRDATE.Clear()
        If CMPCITYNAME <> "" Then CMBFROMCITY.Text = CMPCITYNAME Else CMBFROMCITY.Text = ""
        CMBTOCITY.Text = ""
        CHKEXPORTGST.Checked = False

    End Sub

    Sub GETMAX_INVOICE_NO()
        Dim DTTABLE As DataTable
        If cmbregister.Text.Trim <> "" Then
            DTTABLE = getmax("ISNULL(MAX(invoice_no),0)+1", "invoicemaster LEFT OUTER JOIN REGISTERMASTER ON invoicemaster.invoice_registerid = REGISTERMASTER.register_id AND invoicemaster.invoice_yearid = REGISTERMASTER.register_yearid", "AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE = 'SALE' AND  INVOICE_YEARID = " & YearId)
            If DTTABLE.Rows.Count > 0 Then
                TXTINVOICENO.Text = DTTABLE.Rows(0).Item(0)
            End If
        End If
    End Sub

    Private Sub Invoice_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Left And e.Alt Then
                toolprevious_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt Then
                toolnext_Click(sender, e)
            ElseIf e.KeyCode = Keys.F2 Then
                tstxtbillno.Focus()
            ElseIf e.Alt = True And e.KeyCode = Keys.D1 Then
                TabControl1.SelectedIndex = 0
            ElseIf e.Alt = True And e.KeyCode = Keys.D2 Then
                TabControl1.SelectedIndex = 1
            ElseIf e.Alt = True And e.KeyCode = Keys.P Then
                If edit = True Then Call PRINTREPORT(TEMPINVOICENO)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Dim OBJINVDTLS As New InvoiceDetails
                OBJINVDTLS.MdiParent = MDIMain
                OBJINVDTLS.Show()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F5 Then
                gridinvoice.Focus()
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for Delete
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'SALE'")
        If CMBTAX.Text.Trim = "" Then filltax(CMBTAX, edit)
        If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND ACC_TYPE = 'ACCOUNTS'")
        If CMBOTHERCHGSNAME.Text.Trim = "" Then fillname(CMBOTHERCHGSNAME, edit, " AND (GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT INCOME' OR GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT EXPENSES')")
        If CMBEXTRACHGSNAME.Text.Trim = "" Then fillname(CMBEXTRACHGSNAME, edit, " AND (GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT INCOME' OR GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT EXPENSES')")
        fillCITY(CMBFROMCITY, False)
        fillCITY(CMBTOCITY, False)
        fillSTATE(cmbstate)
        FILLHSNITEMDESC(CMBHSNCODE)
    End Sub

    Private Sub Invoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE INVOICE'")
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

                Dim DT As DataTable
                Dim ALPARAVAL As New ArrayList
                Dim OBJINOVCE As New ClsInvoicemaster

                ALPARAVAL.Add(TEMPINVOICENO)
                ALPARAVAL.Add(TEMPREGNAME)
                ALPARAVAL.Add(YearId)

                OBJINOVCE.alParaval = ALPARAVAL
                DT = OBJINOVCE.SELELECTINVOICE()

                If DT.Rows.Count > 0 Then
                    For Each DR As DataRow In DT.Rows
                        TXTINVOICENO.Text = TEMPINVOICENO
                        TXTINVOICENO.ReadOnly = True
                        invoicedate.Value = Format(Convert.ToDateTime(DR("INVDATE")).Date, "dd/MM/yyyy")

                        cmbregister.Text = TEMPREGNAME
                        CMBNAME.Text = Convert.ToString(DR("NAME"))
                        ' TXTTRANSNAME = (DR("TRANSNAME"))

                        TXTSTATECODE.Text = DR("STATECODE")
                        TXTGSTIN.Text = DR("GSTIN")

                        CHKMANUAL.Checked = Convert.ToBoolean(DR("MANUALGST"))

                        txtdeladd.Text = Convert.ToString(DR("ADDRESS"))
                        txtname.Text = Convert.ToString(DR("CHALLANNAME"))
                        txtpono.Text = Convert.ToString(DR("PONO"))
                        TXTMULTIPONO.Text = Convert.ToString(DR("MULTIPONO"))
                        txtpodate.Text = Convert.ToString(DR("PODATE"))
                        TXTCRDAYS.Text = Convert.ToString(DR("CRDAYS"))
                        DueDate.Value = Format(Convert.ToDateTime(DR("DUEDATE")).Date, "dd/MM/yyyy")

                        TXTTRANSNAME.Text = Convert.ToString(DR("TRANSPORT"))
                        txtchallanno.Text = Convert.ToString(DR("CHALLANNO"))
                        txtchallanno.Enabled = False

                        TXTMULTICHALLANNO.Text = Convert.ToString(DR("MULTICHALLANNO"))

                        txtchallandate.Text = Convert.ToString(DR("CHALLANDATE"))

                        TXTEWAYBILLNO.Text = Convert.ToString(DR("EWAYBILLNO"))
                        txtprocessing.Text = Convert.ToString(DR("PROCESSINGCHGS"))
                        CMBOTHERCHGSNAME.Text = DT.Rows(0).Item("OTHERCHGSNAME")
                        If Val(DR("OTHERCHGS")) > 0 Then
                            TXTOTHERCHGS.Text = Val(DR("OTHERCHGS"))
                            cmbaddsub.Text = "Add"
                        Else
                            TXTOTHERCHGS.Text = Val(DR("OTHERCHGS")) * (-1)
                            cmbaddsub.Text = "Sub."
                        End If

                        txtpakagingchgs.Text = Convert.ToString(DR("PACKINGCHGS"))

                        CMBTAX.Text = Convert.ToString(DR("TAXNAME"))

                        CMBEXTRACHGSNAME.Text = DT.Rows(0).Item("EXTRACHGSNAME")
                        If Val(DR("EXTRACHGS")) > 0 Then
                            TXTEXTRACHGS.Text = Val(DR("EXTRACHGS"))
                            CMBEXTRAADDSUB.Text = "Add"
                        Else
                            TXTEXTRACHGS.Text = Val(DR("EXTRACHGS")) * (-1)
                            CMBEXTRAADDSUB.Text = "Sub."
                        End If

                        TXTAMTREC.Text = DR("AMTREC")
                        TXTEXTRAAMT.Text = DR("EXTRAAMT")
                        txtreturn.Text = DR("RETURN")
                        TXTBAL.Text = DR("BALANCE")
                        cmbstate.Text = Convert.ToString(DR("STATE"))
                        txtremarks.Text = Convert.ToString(DR("REMARKS"))
                        TXTJOBNO.Text = Convert.ToString(DR("JOBNO"))
                        txtorderno.Text = Convert.ToString(DR("ORDERNO"))
                        TXTORDERSRNO.Text = Convert.ToString(DR("ORDERSRNO"))

                        If DR("BILLCHECKED") = 0 Then
                            CHKBILLCHECKED.Checked = False
                        Else
                            CHKBILLCHECKED.Checked = True
                        End If
                        If DR("BILLDISPUTE") = 0 Then
                            CHKDISPUTE.Checked = False
                        Else
                            CHKDISPUTE.Checked = True
                        End If

                        TXTQCPAPER.Text = Convert.ToString(DR("PAPER"))
                        TXTQCGSM.Text = Convert.ToString(DR("GSM"))
                        TXTQCGRAIN.Text = Convert.ToString(DR("GRAIN"))
                        TXTQCTEXT.Text = Convert.ToString(DR("TEXT"))
                        TXTQCPHARMA.Text = Convert.ToString(DR("PHARMA"))
                        TXTQCUPS.Text = Convert.ToString(DR("UPSNO"))
                        TXTQCVISUAL.Text = Convert.ToString(DR("VISUAL"))
                        TXTQCCOLOR.Text = Convert.ToString(DR("COLOR"))
                        TXTQCVARNISH.Text = Convert.ToString(DR("VARNISH"))
                        TXTQCPERFOR.Text = Convert.ToString(DR("PERFORATION"))
                        TXTQCDESIGN.Text = Convert.ToString(DR("DESIGN"))
                        TXTQCSIZE.Text = Convert.ToString(DR("SIZE"))
                        TXTQCSTICKER.Text = Convert.ToString(DR("STICKER"))
                        TXTQCADHESIVE.Text = Convert.ToString(DR("ADHESIVE"))
                        TXTQCFINALAMT.Text = Convert.ToString(DR("FINAL"))
                        TXTQCPACKET.Text = Convert.ToString(DR("PACKET"))
                        TXTQCSHIPPER.Text = Convert.ToString(DR("SHIPPER"))
                        TXTQCLABEL.Text = Convert.ToString(DR("LABEL"))
                        TXTQCBATCH.Text = Convert.ToString(DR("BATCH"))
                        TXTQCHEAD.Text = Convert.ToString(DR("QCHEAD"))
                        QCDATE.Value = Format(Convert.ToDateTime(DR("QCDATE")).Date, "dd/MM/yyyy")
                        TXTQCREMARKS.Text = Convert.ToString(DR("QCREMARKS"))


                        TXTVEHICLENO.Text = DR("VEHICLENO")
                        TXTLRNO.Text = DR("LRNO")
                        LRDATE.Text = DR("LRDATE")
                        CMBFROMCITY.Text = DR("FROMCITY")
                        CMBTOCITY.Text = DR("TOCITY")

                        TXTIRNNO.Text = DR("IRNNO")
                        TXTACKNO.Text = DR("ACKNO")
                        ACKDATE.Value = DR("ACKDATE")
                        If IsDBNull(DR("QRCODE")) = False Then
                            PBQRCODE.Image = Image.FromStream(New IO.MemoryStream(DirectCast(DR("QRCODE"), Byte())))
                        Else
                            PBQRCODE.Image = Nothing
                        End If
                        CMBHSNCODE.Text = Convert.ToString(DR("HSNCODE1"))

                        If Convert.ToBoolean(DR("DONE")) = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If


                        ''GRID PARAMETER
                        'gridinvoice.Rows.Add(DR("ITEMCODE").ToString, DR("ITEMNAME").ToString, DR("MATERIALCODE").ToString, Val(DR("QTY")), (DR("BATCHNO")).ToString, Format(Val(DR("RATE")), "0.0000"), Format(Val(DR("AMT")), "0.00"))
                        gridinvoice.Rows.Add(DR("ITEMCODE").ToString, DR("ITEMNAME").ToString, Convert.ToString(DR("HSNCODE")), DR("MATERIALCODE").ToString, Val(DR("QTY")), (DR("BATCHNO")).ToString, Format(Val(DR("RATE")), "0.0000"), Format(Val(DR("AMT")), "0.00"), Format(Val(DR("OTHERAMT")), "0.00"), Format(Val(DR("TAXABLEAMT")), "0.00"), Format(Val(DR("CGSTPER")), "0.00"), Format(Val(DR("CGSTAMT")), "0.00"), Format(Val(DR("SGSTPER")), "0.00"), Format(Val(DR("SGSTAMT")), "0.00"), Format(Val(DR("IGSTPER")), "0.00"), Format(Val(DR("IGSTAMT")), "0.00"), Format(Val(DR("GRIDTOTAL")), "0.00"), Val(DR("GRIDCHALLANNO")))

                        CMDSELECTCHALLAN.Enabled = False

                        If DR("APPLYTCS") = 0 Then CHKTCS.Checked = False Else CHKTCS.Checked = True
                        TXTTCSPER.Text = Val(DR("TCSPER"))
                        TXTTCSAMT.Text = Val(DR("TCSAMT"))
                        CHKEXPORTGST.Checked = Convert.ToBoolean(DR("EXPGST"))


                        If Val(DR("AMTREC")) > 0 Or Val(DR("EXTRAAMT")) > 0 Then
                            cmdshowdetails.Visible = True
                            PBRECD.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If Val(DR("RETURN")) > 0 Then
                            cmdshowdetails.Visible = True
                            PBCN.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If


                    Next
                    gridinvoice.FirstDisplayedScrollingRowIndex = gridinvoice.RowCount - 1

                    Dim OBJFORM As New ClsCommon
                    Dim DTTROW As DataTable = OBJFORM.search(" ISNULL(FORMTYPE.FORM_NAME, '') AS FORMNAME", "", "INVOICEMASTER_FORMTYPE INNER JOIN REGISTERMASTER ON INVOICEMASTER_FORMTYPE.INVOICE_REGISTERID = REGISTERMASTER.register_id AND INVOICEMASTER_FORMTYPE.INVOICE_YEARID = REGISTERMASTER.register_yearid INNER JOIN FORMTYPE ON INVOICEMASTER_FORMTYPE.INVOICE_FORMID = FORMTYPE.FORM_ID ", " AND REGISTERMASTER.REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTERMASTER.REGISTER_TYPE = 'SALE' AND INVOICEMASTER_FORMTYPE.INVOICE_NO = " & TEMPINVOICENO & " AND INVOICEMASTER_FORMTYPE.INVOICE_YEARID= " & YearId)
                    If DTTROW.Rows.Count > 0 Then
                        For Each ROW As DataRow In DTTROW.Rows
                            For I As Integer = 0 To CHKFORMBOX.Items.Count - 1
                                Dim DTR As DataRowView = CHKFORMBOX.Items(I)
                                If ROW("FORMNAME") = DTR.Item(0) Then
                                    CHKFORMBOX.SetItemCheckState(I, CheckState.Checked)
                                End If
                            Next
                        Next
                    End If

                    '' GRID UPLOAD
                    Dim OBJCMN As New ClsCommon
                    Dim DTTABLE As DataTable = OBJCMN.search("ISNULL(INVOICE_UPSRNO, 0) AS SRNO, ISNULL(INVOICE_UPREMARKS, '') AS REMARKS, ISNULL(INVOICE_UPNAME, '') AS NAME, INVOICE_IMGPATH AS IMGPATH", "", "INVOICEMASTER_UPLOAD", "AND INVOICEMASTER_UPLOAD.INVOICE_NO= " & TEMPINVOICENO & "  AND INVOICE_YEARID = " & YearId & " ORDER BY INVOICEMASTER_UPLOAD.INVOICE_UPSRNO")
                    If DTTABLE.Rows.Count > 0 Then
                        For Each DTR As DataRow In DTTABLE.Rows
                            gridupload.Rows.Add(DTR("SRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                        Next
                    End If


                    Dim clscommon As New ClsCommon
                    Dim dtID As DataTable
                    dtID = clscommon.search(" register_abbr, register_initials, register_id ", "", " RegisterMaster ", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'SALE' and register_YEARid = " & YearId)
                    If dtID.Rows.Count > 0 Then
                        saleregabbr = dtID.Rows(0).Item(0).ToString
                        salereginitial = dtID.Rows(0).Item(1).ToString
                        SALEREGID = dtID.Rows(0).Item(2)
                    End If

                End If
                cmbregister.Enabled = False
                CALC()
                TOTAL()
            Else
                edit = False
                CLEAR()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Dim INTRESULT As Integer
        Try
            Cursor.Current = Cursors.WaitCursor
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim ALPARAVAL As New ArrayList
            ALPARAVAL.Add(Val(TXTINVOICENO.Text.Trim))
            ALPARAVAL.Add(cmbregister.Text.Trim)
            ALPARAVAL.Add(invoicedate.Value.Date)

            If CHKMANUAL.Checked = True Then ALPARAVAL.Add(1) Else ALPARAVAL.Add(0)

            ALPARAVAL.Add(CMBNAME.Text.Trim)
            ALPARAVAL.Add(txtname.Text.Trim)
            ALPARAVAL.Add(TXTTRANSNAME.Text.Trim)
            ALPARAVAL.Add(Val(txtchallanno.Text.Trim))
            ALPARAVAL.Add(TXTMULTICHALLANNO.Text.Trim)

            ALPARAVAL.Add(TXTEWAYBILLNO.Text.Trim)
            ALPARAVAL.Add(txtpono.Text.Trim)
            ALPARAVAL.Add(TXTMULTIPONO.Text.Trim)
            If txtpodate.Text = "" Then ALPARAVAL.Add(Format(Convert.ToDateTime(Mydate).Date, "MM/dd/yyyy")) Else ALPARAVAL.Add(Format(Convert.ToDateTime(txtpodate.Text.Trim).Date, "MM/dd/yyyy"))
            ALPARAVAL.Add(Val(TXTCRDAYS.Text.Trim))
            ALPARAVAL.Add(DueDate.Value.Date)

            ALPARAVAL.Add(Val(LBLTOTALQTY.Text.Trim))
            ALPARAVAL.Add(Val(lbltotalamt.Text.Trim))
            ALPARAVAL.Add(Val(LBLTOTALOTHERAMT.Text.Trim))
            ALPARAVAL.Add(Val(LBLTOTALTAXABLEAMT.Text.Trim))
            ALPARAVAL.Add(Val(LBLTOTALCGSTAMT.Text.Trim))
            ALPARAVAL.Add(Val(LBLTOTALSGSTAMT.Text.Trim))
            ALPARAVAL.Add(Val(LBLTOTALIGSTAMT.Text.Trim))
            ALPARAVAL.Add(Val(LBLTOTALGRIDAMT.Text.Trim))


            If CHKTCS.Checked = True Then ALPARAVAL.Add(1) Else ALPARAVAL.Add(0)
            ALPARAVAL.Add(Val(TXTTCSPER.Text.Trim))
            ALPARAVAL.Add(Val(TXTTCSAMT.Text.Trim))


            ALPARAVAL.Add(Val(txtprocessing.Text.Trim))

            ALPARAVAL.Add(CMBOTHERCHGSNAME.Text.Trim)
            If cmbaddsub.Text.Trim = "Add" Then
                ALPARAVAL.Add(Val(TXTOTHERCHGS.Text.Trim))
            ElseIf cmbaddsub.Text.Trim = "Sub." Then
                ALPARAVAL.Add(Val((TXTOTHERCHGS.Text.Trim) * (-1)))
            Else
                ALPARAVAL.Add(0)
            End If

            ALPARAVAL.Add(Val(txtpakagingchgs.Text.Trim))

            ALPARAVAL.Add(Val(TXTSUBTOTAL.Text.Trim))
            ALPARAVAL.Add(CMBTAX.Text.Trim)
            ALPARAVAL.Add(Val(txttax.Text.Trim))

            ALPARAVAL.Add(CMBEXTRACHGSNAME.Text.Trim)
            If CMBEXTRAADDSUB.Text.Trim = "Add" Then
                ALPARAVAL.Add(Val(TXTEXTRACHGS.Text.Trim))
            ElseIf CMBEXTRAADDSUB.Text.Trim = "Sub." Then
                ALPARAVAL.Add(Val((TXTEXTRACHGS.Text.Trim) * (-1)))
            Else
                ALPARAVAL.Add(0)
            End If

            ALPARAVAL.Add(Val(txtroundoff.Text.Trim))
            ALPARAVAL.Add(Val(txtgrandtotal.Text.Trim))

            ALPARAVAL.Add(Val(TXTAMTREC.Text.Trim))
            ALPARAVAL.Add(Val(TXTEXTRAAMT.Text.Trim))
            ALPARAVAL.Add(Val(txtreturn.Text.Trim))
            ALPARAVAL.Add(Val(TXTBAL.Text.Trim))

            ALPARAVAL.Add(txtinwords.Text.Trim)
            ALPARAVAL.Add(cmbstate.Text.Trim)
            ALPARAVAL.Add(txtremarks.Text.Trim)
            ALPARAVAL.Add(Val(TXTJOBNO.Text.Trim))
            ALPARAVAL.Add(Val(txtorderno.Text.Trim))
            ALPARAVAL.Add(Val(TXTORDERSRNO.Text.Trim))


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


            ALPARAVAL.Add(TXTQCPAPER.Text.Trim)
            ALPARAVAL.Add(TXTQCGSM.Text.Trim)
            ALPARAVAL.Add(TXTQCGRAIN.Text.Trim)
            ALPARAVAL.Add(TXTQCTEXT.Text.Trim)
            ALPARAVAL.Add(TXTQCPHARMA.Text.Trim)
            ALPARAVAL.Add(Val(TXTQCUPS.Text.Trim))
            ALPARAVAL.Add(TXTQCVISUAL.Text.Trim)
            ALPARAVAL.Add(TXTQCCOLOR.Text.Trim)
            ALPARAVAL.Add(TXTQCVARNISH.Text.Trim)
            ALPARAVAL.Add(TXTQCPERFOR.Text.Trim)
            ALPARAVAL.Add(TXTQCDESIGN.Text.Trim)
            ALPARAVAL.Add(TXTQCSIZE.Text.Trim)
            ALPARAVAL.Add(TXTQCSTICKER.Text.Trim)
            ALPARAVAL.Add(TXTQCADHESIVE.Text.Trim)
            ALPARAVAL.Add(TXTQCFINALAMT.Text.Trim)
            ALPARAVAL.Add(TXTQCPACKET.Text.Trim)
            ALPARAVAL.Add(TXTQCSHIPPER.Text.Trim)
            ALPARAVAL.Add(TXTQCLABEL.Text.Trim)
            ALPARAVAL.Add(TXTQCBATCH.Text.Trim)
            ALPARAVAL.Add(TXTQCHEAD.Text.Trim)
            ALPARAVAL.Add(QCDATE.Value.Date)
            ALPARAVAL.Add(TXTQCREMARKS.Text.Trim)
            ALPARAVAL.Add(TXTINKDETAILS.Text.Trim)





            If chkdone.CheckState = True Then
                ALPARAVAL.Add(1)
            Else
                ALPARAVAL.Add(0)
            End If

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            'ADDING FORMTYPE
            Dim FORMTYPE As String = ""
            For Each DTROW As DataRowView In CHKFORMBOX.CheckedItems
                If FORMTYPE = "" Then
                    FORMTYPE = DTROW.Item(0)
                Else
                    FORMTYPE = FORMTYPE & "|" & DTROW.Item(0)
                End If
            Next
            ALPARAVAL.Add(FORMTYPE)

            ''GRID VALUE
            Dim ITEMCODE As String = ""
            Dim HSNCODE As String = ""
            Dim QTY As String = ""
            Dim BATCHNO As String = ""
            Dim RATE As String = ""
            Dim AMOUNT As String = ""

            Dim OTHERAMT As String = ""
            Dim TAXABLEAMT As String = ""
            Dim CGSTPER As String = ""
            Dim CGSTAMT As String = ""
            Dim SGSTPER As String = ""
            Dim SGSTAMT As String = ""
            Dim IGSTPER As String = ""
            Dim IGSTAMT As String = ""
            Dim GRIDTOTAL As String = ""
            Dim GRIDCHALLANNO As String = ""

            For Each ROW As Windows.Forms.DataGridViewRow In gridinvoice.Rows
                If ROW.Cells(0).Value.ToString <> "" Then
                    If ITEMCODE = "" Then
                        ITEMCODE = ROW.Cells(GITEMCODE.Index).Value.ToString
                        HSNCODE = ROW.Cells(GHSNCODE.Index).Value.ToString

                        QTY = Val(ROW.Cells(GQTY.Index).Value).ToString
                        BATCHNO = ROW.Cells(GBATCHNO.Index).Value.ToString
                        RATE = Val(ROW.Cells(GRATE.Index).Value).ToString
                        AMOUNT = Val(ROW.Cells(GAMOUNT.Index).Value).ToString

                        OTHERAMT = Val(ROW.Cells(GOTHERAMT.Index).Value)
                        TAXABLEAMT = Val(ROW.Cells(GTAXABLEAMT.Index).Value)
                        CGSTPER = ROW.Cells(GCGSTPER.Index).Value.ToString
                        CGSTAMT = Val(ROW.Cells(GCGSTAMT.Index).Value)
                        SGSTPER = ROW.Cells(GSGSTPER.Index).Value.ToString
                        SGSTAMT = Val(ROW.Cells(GSGSTAMT.Index).Value)
                        IGSTPER = ROW.Cells(GIGSTPER.Index).Value.ToString
                        IGSTAMT = Val(ROW.Cells(GIGSTAMT.Index).Value)
                        GRIDTOTAL = Val(ROW.Cells(GGRIDTOTAL.Index).Value)
                        GRIDCHALLANNO = Val(ROW.Cells(GGRIDCHALLANNO.Index).Value)

                    Else
                        ITEMCODE = ITEMCODE & "|" & ROW.Cells(GITEMCODE.Index).Value.ToString
                        HSNCODE = ROW.Cells(GHSNCODE.Index).Value.ToString

                        QTY = QTY & "|" & Val(ROW.Cells(GQTY.Index).Value).ToString
                        BATCHNO = BATCHNO & "|" & ROW.Cells(GBATCHNO.Index).Value.ToString
                        RATE = RATE & "|" & Val(ROW.Cells(GRATE.Index).Value).ToString
                        AMOUNT = AMOUNT & "|" & Val(ROW.Cells(GAMOUNT.Index).Value).ToString

                        OTHERAMT = OTHERAMT & "|" & Val(ROW.Cells(GOTHERAMT.Index).Value)
                        TAXABLEAMT = TAXABLEAMT & "|" & Val(ROW.Cells(GTAXABLEAMT.Index).Value)
                        CGSTPER = CGSTPER & "|" & ROW.Cells(GCGSTPER.Index).Value
                        CGSTAMT = CGSTAMT & "|" & Val(ROW.Cells(GCGSTAMT.Index).Value)
                        SGSTPER = SGSTPER & "|" & ROW.Cells(GSGSTPER.Index).Value
                        SGSTAMT = SGSTAMT & "|" & Val(ROW.Cells(GSGSTAMT.Index).Value)
                        IGSTPER = IGSTPER & "|" & ROW.Cells(GIGSTPER.Index).Value
                        IGSTAMT = IGSTAMT & "|" & Val(ROW.Cells(GIGSTAMT.Index).Value)
                        GRIDTOTAL = GRIDTOTAL & "|" & Val(ROW.Cells(GGRIDTOTAL.Index).Value)
                        GRIDCHALLANNO = GRIDCHALLANNO & "|" & Val(ROW.Cells(GGRIDCHALLANNO.Index).Value)

                    End If
                End If
            Next
            ALPARAVAL.Add(ITEMCODE)
            ALPARAVAL.Add(HSNCODE)

            ALPARAVAL.Add(QTY)
            ALPARAVAL.Add(BATCHNO)
            ALPARAVAL.Add(RATE)
            ALPARAVAL.Add(AMOUNT)

            ALPARAVAL.Add(OTHERAMT)
            ALPARAVAL.Add(TAXABLEAMT)
            ALPARAVAL.Add(CGSTPER)
            ALPARAVAL.Add(CGSTAMT)
            ALPARAVAL.Add(SGSTPER)
            ALPARAVAL.Add(SGSTAMT)
            ALPARAVAL.Add(IGSTPER)
            ALPARAVAL.Add(IGSTAMT)
            ALPARAVAL.Add(GRIDTOTAL)
            ALPARAVAL.Add(GRIDCHALLANNO)


            ALPARAVAL.Add(TXTVEHICLENO.Text.Trim)
            ALPARAVAL.Add(TXTLRNO.Text.Trim)
            ALPARAVAL.Add(LRDATE.Text)
            ALPARAVAL.Add(CMBFROMCITY.Text.Trim)
            ALPARAVAL.Add(CMBTOCITY.Text.Trim)
            ALPARAVAL.Add(TXTIRNNO.Text.Trim)
            ALPARAVAL.Add(TXTACKNO.Text.Trim)
            ALPARAVAL.Add(Format(ACKDATE.Value.Date, "MM/dd/yyyy"))

            If PBQRCODE.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                ALPARAVAL.Add(MS.ToArray)
            Else
                ALPARAVAL.Add(DBNull.Value)
            End If
            ALPARAVAL.Add(CMBHSNCODE.Text.Trim)
            ALPARAVAL.Add(CHKEXPORTGST.Checked)



            Dim OBJINVOICE As New ClsInvoicemaster()
            OBJINVOICE.alParaval = ALPARAVAL

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTT As DataTable = OBJINVOICE.SAVE()
                MsgBox("Details Added!!")
                PRINTREPORT(DTT.Rows(0).Item(0))
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                ALPARAVAL.Add(TEMPINVOICENO)
                INTRESULT = OBJINVOICE.UPDATE()
                MsgBox("Details Updated!!")
                PRINTREPORT(TEMPINVOICENO)
                edit = False
            End If
            If gridupload.RowCount > 0 Then SAVEUPLOAD()
            CLEAR()
            cmbregister.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SAVEUPLOAD()
        Try
            Dim OBJORDER As New ClsInvoicemaster

            For Each ROW As Windows.Forms.DataGridViewRow In gridupload.Rows
                If ROW.Cells(GUSRNO.Index).Value <> Nothing Then
                    Dim MS As New IO.MemoryStream
                    Dim ALPARAVAL As New ArrayList
                    ALPARAVAL.Add(TXTINVOICENO.Text.Trim)
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

    Sub PRINTREPORT(ByVal INVOICENO As Integer)
        Try
            tempMsg = MsgBox("Wish to Print Invoice?", MsgBoxStyle.YesNo)
            If tempMsg = vbYes Then


                Dim OBJINVOICE As New SaleInvoiceDesign
                If ClientName = "AMR" Then
                    If MsgBox("Show in Challan Format?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then OBJINVOICE.SHOWINCHALLANFORMAT = 1
                End If

                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.PRINTPACKETDETAILS = CHKPACKET.Checked
                OBJINVOICE.FRMSTRING = "INVOICE"
                OBJINVOICE.INVNO = Val(INVOICENO)
                OBJINVOICE.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & Val(INVOICENO) & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                OBJINVOICE.Show()
            End If

            If ClientName = "AMR" Then

                'If MsgBox("Wish to Print Invoice QC Report?", MsgBoxStyle.YesNo) = vbYes Then
                '    Dim OBJINVOICE As New SaleInvoiceDesign
                '    OBJINVOICE.MdiParent = MDIMain
                '    OBJINVOICE.FRMSTRING = "INVOICEQCREPORT"
                '    OBJINVOICE.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & Val(INVOICENO) & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                '    OBJINVOICE.Show()
                'End If

                If MsgBox("Wish to Print Common COA Report?", MsgBoxStyle.YesNo) = vbYes Then
                    Dim OBJINVOICE As New SaleInvoiceDesign
                    OBJINVOICE.MdiParent = MDIMain
                    OBJINVOICE.FRMSTRING = "COMMONCOA"
                    OBJINVOICE.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & Val(INVOICENO) & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                    OBJINVOICE.Show()
                End If

                If MsgBox("Wish to Print MSN COA Report?", MsgBoxStyle.YesNo) = vbYes Then
                    Dim OBJINVOICE As New SaleInvoiceDesign
                    OBJINVOICE.MdiParent = MDIMain
                    OBJINVOICE.FRMSTRING = "MSNCOA"
                    OBJINVOICE.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & Val(INVOICENO) & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                    OBJINVOICE.Show()
                End If



                If MsgBox("Wish to Print ALKEM COA Report?", MsgBoxStyle.YesNo) = vbYes Then
                    Dim OBJINVOICE As New SaleInvoiceDesign
                    OBJINVOICE.MdiParent = MDIMain
                    OBJINVOICE.FRMSTRING = "ALKEM_COA"
                    OBJINVOICE.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & Val(INVOICENO) & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                    OBJINVOICE.Show()
                End If

                If MsgBox("Wish to Print SUN PHARMA COA Report?", MsgBoxStyle.YesNo) = vbYes Then
                    Dim OBJINVOICE As New SaleInvoiceDesign
                    OBJINVOICE.MdiParent = MDIMain
                    OBJINVOICE.FRMSTRING = "SUN_COA"
                    OBJINVOICE.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & Val(INVOICENO) & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                    OBJINVOICE.Show()
                End If

                If MsgBox("Wish to Print SHALINA COA Report?", MsgBoxStyle.YesNo) = vbYes Then
                    Dim OBJINVOICE As New SaleInvoiceDesign
                    OBJINVOICE.MdiParent = MDIMain
                    OBJINVOICE.FRMSTRING = "SHALINA_COA"
                    OBJINVOICE.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & Val(INVOICENO) & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                    OBJINVOICE.Show()
                End If
            End If


            If MsgBox("Wish to Print COA-CIPLA Report?", MsgBoxStyle.YesNo) = vbYes Then
                Dim OBJINVOICE As New SaleInvoiceDesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.FRMSTRING = "COA"
                OBJINVOICE.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & Val(INVOICENO) & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                OBJINVOICE.Show()
            End If

            If MsgBox("Wish to Print IPCA COA Report?", MsgBoxStyle.YesNo) = vbYes Then
                Dim OBJINVOICE As New SaleInvoiceDesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.FRMSTRING = "IPCA_COA"
                OBJINVOICE.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & Val(INVOICENO) & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                OBJINVOICE.Show()
            End If

            If MsgBox("Wish to Print FAMYCARE COA Report?", MsgBoxStyle.YesNo) = vbYes Then
                Dim OBJINVOICE As New SaleInvoiceDesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.FRMSTRING = "FAMYCARE_COA"
                OBJINVOICE.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & Val(INVOICENO) & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                OBJINVOICE.Show()
            End If


            If MsgBox("Wish to Print SANDOZ COA Report?", MsgBoxStyle.YesNo) = vbYes Then
                Dim OBJINVOICE As New SaleInvoiceDesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.FRMSTRING = "SANDOZ_COA"
                OBJINVOICE.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & Val(INVOICENO) & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                OBJINVOICE.Show()
            End If

            If MsgBox("Wish to Print BIOCON COA Report?", MsgBoxStyle.YesNo) = vbYes Then
                Dim OBJINVOICE As New SaleInvoiceDesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.FRMSTRING = "BIOCON_COA"
                OBJINVOICE.WHERECLAUSE = "{INVOICEMASTER.INVOICE_no}=" & Val(INVOICENO) & " and {REGISTERMASTER.REGISTER_NAME} = '" & cmbregister.Text.Trim & "' and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                OBJINVOICE.Show()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If cmbregister.Text.Trim.Length = 0 Then
            Ep.SetError(cmbregister, "Enter Register Name")
            bln = False
        End If

        If ClientName = "IYMP" And gridinvoice.RowCount > 1 Then
            Ep.SetError(CMBNAME, "Multiple Items Not Allowed")
            bln = False
        End If
        'If txtchallanno.Text.Trim.Length = 0 Then
        '    Ep.SetError(txtchallanno, "Select Challan")
        '    bln = False
        'End If

        If CMBOTHERCHGSNAME.Text.Trim.Length = 0 And Val(TXTOTHERCHGS.Text) > 0 Then
            Ep.SetError(CMBOTHERCHGSNAME, "Select Other Charge")
            bln = False
        End If

        If CMBEXTRACHGSNAME.Text.Trim.Length = 0 And Val(TXTEXTRACHGS.Text) > 0 Then
            Ep.SetError(CMBEXTRAADDSUB, "Select Other Charge")
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

        If CMBNAME.Text.Trim.Length = 0 Then
            Ep.SetError(CMBNAME, "Select Name")
            bln = False
        End If

        If lbllocked.Visible = True Then
            Ep.SetError(lbllocked, "Rec/Return Made , Delete Rec/Return First")
            bln = False
        End If

        If Val(TXTINVOICENO.Text.Trim) > 0 And edit = False Then
            Dim OBJCMN As New ClsCommon
            Dim dttable As DataTable = OBJCMN.search(" ISNULL(INVOICEMASTER.INVOICE_NO,0)  AS INVOICENO", "", " INVOICEMASTER inner join REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID ", "  AND INVOICEMASTER.INVOICE_NO=" & TXTINVOICENO.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICEMASTER.INVOICE_YEARID = " & YearId)
            If dttable.Rows.Count > 0 Then
                Ep.SetError(TXTINVOICENO, "Invoice No Already Exist")
                bln = False
            End If
        End If

        If Val(txtchallanno.Text.Trim) > 0 And edit = False Then
            Dim OBJCMN As New ClsCommon
            Dim dttable As DataTable = OBJCMN.search(" ISNULL(INVOICEMASTER.invoice_challanno,0)  AS CHALLANNO", "", " INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICEMASTER.invoice_registerid = REGISTERMASTER.register_id ", "   AND INVOICEMASTER.INVOICE_CHALLANNO=" & txtchallanno.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICEMASTER.INVOICE_YEARID = " & YearId)
            If dttable.Rows.Count > 0 Then
                Ep.SetError(txtchallanno, "Challan No Already Exist")
                bln = False
            End If
        End If

        If Not datecheck(invoicedate.Value) Then
            Ep.SetError(invoicedate, "Date Not in current Accounting Year")
            bln = False
        End If

        If Convert.ToDateTime(invoicedate.Text).Date >= "01/07/2017" Then
            If TXTSTATECODE.Text.Trim.Length = 0 Then
                Ep.SetError(TXTSTATECODE, "Please enter the state code from State Master... ")
                bln = False
            End If

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

        If Convert.ToDateTime(invoicedate.Text).Date >= "01/02/2018" Then
            If Val(txtgrandtotal.Text.Trim) > 50000 And TXTEWAYBILLNO.Text.Trim = "" Then
                If MsgBox("Eway Bill No Not Entered, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    bln = False
                End If
            End If
        End If
        If ClientName = "AMR" Then
            If CMBHSNCODE.Text.Trim.Length = 0 Then
                Ep.SetError(CMBHSNCODE, "Enter HSN Code")
                bln = False
            End If
        End If

        If Convert.ToDateTime(invoicedate.Text).Date < SALEBLOCKDATE.Date Then
            Ep.SetError(invoicedate, "Date is Blocked, Please make entries after " & Format(SALEBLOCKDATE.Date, "dd/MM/yyyy"))
            bln = False
        End If

        Return bln
    End Function

    Sub TOTAL()
        Try

            TXTTCSPER.Text = 0
            TXTTCSAMT.Text = 0

            'FETCH TCSPERCENT WITH RESPECT TO DATE
            Dim OBJCMN As New ClsCommon
            Dim DTTCS As DataTable = OBJCMN.search("TOP 1 ISNULL(TCSPER,0) AS TCSPER", "", "TCSPERCENT", " AND TCSDATE <= '" & Format(Convert.ToDateTime(invoicedate.Text).Date, "MM/dd/yyyy") & "' ORDER BY TCSDATE DESC")
            If DTTCS.Rows.Count > 0 Then TXTTCSPER.Text = Val(DTTCS.Rows(0).Item("TCSPER"))


            LBLTOTALQTY.Text = "0.00"
            lbltotalamt.Text = "0.00"

            LBLTOTALOTHERAMT.Text = "0.0"
            LBLTOTALTAXABLEAMT.Text = "0.0"
            LBLTOTALCGSTAMT.Text = "0.0"
            LBLTOTALSGSTAMT.Text = "0.0"
            LBLTOTALIGSTAMT.Text = "0.0"
            LBLTOTALGRIDAMT.Text = "0.0"

            TXTSUBTOTAL.Text = "0.00"
            txttax.Text = "0.00"
            txtroundoff.Text = 0
            txtgrandtotal.Text = 0

            For Each ROW As Windows.Forms.DataGridViewRow In gridinvoice.Rows
                If Val(ROW.Cells(GQTY.Index).Value).ToString > 0 Then LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0.00")
                If Val(ROW.Cells(GAMOUNT.Index).Value).ToString > 0 Then lbltotalamt.Text = Format(Val(lbltotalamt.Text) + Val(ROW.Cells(GAMOUNT.Index).EditedFormattedValue), "0.00")

                If Val(ROW.Cells(GOTHERAMT.Index).Value) <> 0 Then LBLTOTALOTHERAMT.Text = Format(Val(LBLTOTALOTHERAMT.Text) + Val(ROW.Cells(GOTHERAMT.Index).EditedFormattedValue), "0.00")
                If Val(ROW.Cells(GTAXABLEAMT.Index).Value) <> 0 Then LBLTOTALTAXABLEAMT.Text = Format(Val(LBLTOTALTAXABLEAMT.Text) + Val(ROW.Cells(GTAXABLEAMT.Index).EditedFormattedValue), "0.00")
                If Val(ROW.Cells(GCGSTAMT.Index).Value) <> 0 Then LBLTOTALCGSTAMT.Text = Format(Val(LBLTOTALCGSTAMT.Text) + Val(ROW.Cells(GCGSTAMT.Index).EditedFormattedValue), "0.00")
                If Val(ROW.Cells(GSGSTAMT.Index).Value) <> 0 Then LBLTOTALSGSTAMT.Text = Format(Val(LBLTOTALSGSTAMT.Text) + Val(ROW.Cells(GSGSTAMT.Index).EditedFormattedValue), "0.00")
                If Val(ROW.Cells(GIGSTAMT.Index).Value) <> 0 Then LBLTOTALIGSTAMT.Text = Format(Val(LBLTOTALIGSTAMT.Text) + Val(ROW.Cells(GIGSTAMT.Index).EditedFormattedValue), "0.00")
                If Val(ROW.Cells(GGRIDTOTAL.Index).Value) <> 0 Then LBLTOTALGRIDAMT.Text = Format(Val(LBLTOTALGRIDAMT.Text) + Val(ROW.Cells(GGRIDTOTAL.Index).EditedFormattedValue), "0.00")

            Next

            If CHKTCS.CheckState = CheckState.Checked Then TXTTCSAMT.Text = Format((Val(LBLTOTALGRIDAMT.Text.Trim) * Val(TXTTCSPER.Text.Trim)) / 100, "0.00")


            If cmbaddsub.Text = "Add" Then
                TXTSUBTOTAL.Text = Format(Val(LBLTOTALGRIDAMT.Text) + Val(TXTTCSAMT.Text.Trim) + Val(txtprocessing.Text.Trim) + Val(TXTOTHERCHGS.Text) + Val(txtpakagingchgs.Text.Trim), "0.00")
            Else
                TXTSUBTOTAL.Text = Format((Val(LBLTOTALGRIDAMT.Text) + Val(TXTTCSAMT.Text.Trim) + Val(txtprocessing.Text.Trim) + Val(txtpakagingchgs.Text.Trim)) - Val(TXTOTHERCHGS.Text), "0.00")
            End If


            Dim dt As DataTable = OBJCMN.search("tax_name, tax_tax as tax", "", " taxmaster", "and TAXMASTER.tax_name = '" & CMBTAX.Text.Trim & "' and tax_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                txttax.Text = Format((Val(dt.Rows(0).Item(1)) * Val(TXTSUBTOTAL.Text)) / 100, "0.00")
            End If

            If CMBEXTRAADDSUB.Text = "Add" Then
                txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTEXTRACHGS.Text), "0")
                txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(TXTSUBTOTAL.Text) + Val(txttax.Text) + Val(TXTEXTRACHGS.Text)), "0.00")
            Else
                txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text) + Val(txttax.Text) - Val(TXTEXTRACHGS.Text), "0")
                txtroundoff.Text = Format(Val(txtgrandtotal.Text) - ((Val(TXTSUBTOTAL.Text) + Val(txttax.Text)) - Val(TXTEXTRACHGS.Text)), "0.00")
            End If
            txtgrandtotal.Text = Format(Val(txtgrandtotal.Text), "0.00")
            If Val(txtgrandtotal.Text) > 0 Then txtinwords.Text = CurrencyToWord(txtgrandtotal.Text)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Dim INTRESULT As Integer
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    Ep.SetError(lbllocked, "Rec/Return Made , Delete Rec/Return First")
                    Exit Sub
                End If
                tempMsg = MsgBox("Wish to Delete Invoice.?", MsgBoxStyle.YesNo)
                If tempMsg = vbYes Then
                    tempMsg = MsgBox("Are you Sure?", MsgBoxStyle.YesNo)
                    If tempMsg = vbYes Then
                        Dim ALPARAVAL As New ArrayList
                        ALPARAVAL.Add(TEMPINVOICENO)
                        ALPARAVAL.Add(TEMPREGNAME)
                        ALPARAVAL.Add(YearId)
                        ALPARAVAL.Add(Userid)

                        Dim OBJINVOICE As New ClsInvoicemaster
                        OBJINVOICE.alParaval = ALPARAVAL

                        INTRESULT = OBJINVOICE.delete()
                        MsgBox("Invoice Deleted!")
                        CLEAR()
                        edit = False
                    Else
                        MsgBox("Delete is only Edit Mode")
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            gridinvoice.RowCount = 0
LINE1:
            TEMPINVOICENO = Val(TXTINVOICENO.Text) - 1
            TEMPREGNAME = cmbregister.Text.Trim
            If TEMPINVOICENO > 0 Then
                edit = True
                Invoice_Load(sender, e)
            Else
                edit = False
                CLEAR()
            End If
            If gridinvoice.RowCount = 0 And TEMPINVOICENO > 1 Then
                TXTINVOICENO.Text = TEMPINVOICENO
                GoTo LINE1
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            gridinvoice.RowCount = 0
Line1:
            TEMPINVOICENO = Val(TXTINVOICENO.Text) + 1
            TEMPREGNAME = cmbregister.Text.Trim
            GETMAX_INVOICE_NO()
            Dim MAXNO As Integer = TXTINVOICENO.Text
            CLEAR()
            If Val(TXTINVOICENO.Text) - 1 >= TEMPINVOICENO Then
                edit = True
                Invoice_Load(sender, e)
            Else
                edit = False
                CLEAR()
            End If
            If gridinvoice.RowCount = 0 And TEMPINVOICENO < MAXNO Then
                TXTINVOICENO.Text = TEMPINVOICENO
                GoTo Line1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        cmdok_Click(sender, e)
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJINVOCE As New InvoiceDetails
            OBJINVOCE.MdiParent = MDIMain
            OBJINVOCE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        CMDDELETE_Click(sender, e)
    End Sub

    Private Sub CMDSELECTCHALLAN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTCHALLAN.Click
        Try
            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor

            Dim OBJSELECTCHALLAN As New SelectChallan
            OBJSELECTCHALLAN.ShowDialog()
            Dim CHALLANDT As DataTable = OBJSELECTCHALLAN.DT
            If CHALLANDT.Rows.Count > 0 Then


                ''  GETTING DISTINCT CHALLAN NO IN TEXTBOX
                Dim DV As DataView = CHALLANDT.DefaultView
                Dim NEWDT As DataTable = DV.ToTable(True, "CHALLANNO")
                For Each DTR As DataRow In NEWDT.Rows
                    If TXTMULTICHALLANNO.Text.Trim = "" Then
                        TXTMULTICHALLANNO.Text = DTR("CHALLANNO").ToString
                    Else
                        TXTMULTICHALLANNO.Text = TXTMULTICHALLANNO.Text & "," & DTR("CHALLANNO").ToString
                    End If
                Next


                ''  GETTING DISTINCT CHALLAN NO IN TEXTBOX
                Dim DVPO As DataView = CHALLANDT.DefaultView
                Dim NEWDTPO As DataTable = DVPO.ToTable(True, "PONO")
                For Each DTR As DataRow In NEWDTPO.Rows
                    If TXTMULTIPONO.Text.Trim = "" Then
                        TXTMULTIPONO.Text = DTR("PONO").ToString
                    Else
                        TXTMULTIPONO.Text = TXTMULTIPONO.Text & "," & DTR("PONO").ToString
                    End If
                Next


                For Each DTROW As DataRow In CHALLANDT.Rows
                    FETCHDATA(DTROW("CHALLANNO"))
                Next
                If TXTMULTICHALLANNO.Text.Trim = "" And txtchallanno.Text.Trim <> "" Then TXTMULTICHALLANNO.Text = txtchallanno.Text
                If TXTMULTIPONO.Text.Trim = "" And txtpono.Text.Trim <> "" Then TXTMULTIPONO.Text = txtpono.Text
            End If

            'Dim OBJCMN As New ClsCommon
            'Dim DTT As DataTable = OBJCMN.search("ISNULL(ORDERMASTER_DESC.ORDER_PROCHRGE, 0) AS PROCHARGE", "", "ORDERMASTER_DESC INNER JOIN INVOICEMASTER ON ORDERMASTER_DESC.ORDER_NO = INVOICEMASTER.INVOICE_ORDERNO AND  ORDERMASTER_DESC.ORDER_YEARID = INVOICEMASTER.invoice_yearid INNER JOIN REGISTERMASTER ON INVOICEMASTER.invoice_registerid = REGISTERMASTER.register_id", "AND NOT EXISTS (SELECT * FROM INVOICEMASTER WHERE ORDERMASTER_DESC.ORDER_NO = INVOICEMASTER.INVOICE_ORDERNO AND ORDERMASTER_DESC.ORDER_GRIDSRNO = INVOICEMASTER.INVOICE_ORDERSRNO) ")
            'If DTT.Rows.Count > 0 Then
            '    txtprocessing.Text = ""
            'End If

            CMBNAME.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FETCHDATA(ByVal CHALLANNO As Integer)
        Try

            Dim OBJCMN As New ClsCommon
            'Dim DT As DataTable = OBJCMN.search("ISNULL(challanmaster.challan_no, 0) AS CHALLANNO, ISNULL(challanmaster.CHALLAN_ORDERNO, 0) AS ORDERNO, ISNULL(challanmaster.CHALLAN_ORDERSRNO, 0) AS ORDERSRNO, ISNULL(challanmaster.challan_jobno, 0) AS JOBNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(challanmaster.challan_pono, '') AS PONO, challanmaster.challan_podate AS PODATE, challanmaster.challan_date AS CHALLANDATE, ISNULL(challanmaster.challan_no, 0) AS CHALLANNO, ISNULL(TRANSPORT.Acc_cmpname, '') AS DESPATCHNAME, ISNULL(itemmaster.item_code, '') AS ITEMCODE, ISNULL(itemmaster.item_name, '') AS ITEMNAME,ISNULL(ITEMMASTER.ITEM_MATERIALCODE,'')AS MCODE, ISNULL(challanmaster_DESC.CHALLAN_QTY, 0) AS QTY, ISNULL(CHALLANMASTER_DESC.CHALLAN_BATCHNO, 0) AS BATCHNO, ISNULL(ORDERMASTER_DESC.ORDER_BASICRATE, 0) AS BASICRATE, ISNULL(ORDERMASTER_DESC.ORDER_PROCHRGE, 0) AS PROCHARGE", "", "challanmaster INNER JOIN CHALLANMASTER_DESC ON challanmaster.challan_no = CHALLANMASTER_DESC.CHALLAN_NO AND challanmaster.challan_yearid = CHALLANMASTER_DESC.CHALLAN_YEARID INNER JOIN LEDGERS ON challanmaster.challan_ledgerid = LEDGERS.Acc_id AND challanmaster.challan_yearid = LEDGERS.Acc_yearid INNER JOIN itemmaster ON CHALLANMASTER_DESC.CHALLAN_ITEMID = itemmaster.item_id AND CHALLANMASTER_DESC.CHALLAN_YEARID = itemmaster.item_yearid INNER JOIN ORDERMASTER_DESC ON challanmaster.CHALLAN_ORDERSRNO = ORDERMASTER_DESC.ORDER_GRIDSRNO AND challanmaster.challan_yearid = ORDERMASTER_DESC.ORDER_YEARID AND challanmaster.CHALLAN_ORDERNO = ORDERMASTER_DESC.ORDER_NO LEFT OUTER JOIN LEDGERS AS TRANSPORT ON challanmaster.challan_transid = TRANSPORT.Acc_id AND challanmaster.challan_yearid = TRANSPORT.Acc_yearid", " AND CHALLANMASTER.CHALLAN_NO =" & CHALLANNO & " AND challanmaster.CHALLAN_YEARID = " & YearId)

            Dim DT As DataTable = OBJCMN.search("ISNULL(CHALLANMASTER.challan_no, 0) AS CHALLANNO, ISNULL(CHALLANMASTER.CHALLAN_ORDERNO, 0) AS ORDERNO, ISNULL(CHALLANMASTER.CHALLAN_ORDERSRNO, 0) AS ORDERSRNO, ISNULL(CHALLANMASTER.challan_jobno, 0) AS JOBNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(CHALLANMASTER.challan_pono, '') AS PONO, CHALLANMASTER.challan_podate AS PODATE, CHALLANMASTER.challan_date AS CHALLANDATE, ISNULL(CHALLANMASTER.challan_no, 0) AS CHALLANNO, ISNULL(TRANSPORT.Acc_cmpname, '') AS DESPATCHNAME, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(ITEMMASTER.ITEM_MATERIALCODE, '') AS MCODE, ISNULL(CHALLANMASTER_DESC.CHALLAN_QTY, 0) AS QTY, ISNULL(CHALLANMASTER_DESC.CHALLAN_BATCHNO, 0) AS BATCHNO, ISNULL(ORDERMASTER_DESC.ORDER_BASICRATE, 0) AS BASICRATE, ISNULL(ORDERMASTER_DESC.ORDER_PROCHRGE, 0) AS PROCHARGE, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER, ISNULL(HSNMASTER.HSN_EXPCGST, 0) AS EXPCGSTPER, ISNULL(HSNMASTER.HSN_EXPSGST, 0) AS EXPSGSTPER, ISNULL(HSNMASTER.HSN_EXPIGST, 0) AS EXPIGSTPER, ISNULL(CITYMASTER.CITY_NAME,'') AS CITY", "", " CHALLANMASTER INNER JOIN CHALLANMASTER_DESC ON CHALLANMASTER.challan_no = CHALLANMASTER_DESC.CHALLAN_NO AND CHALLANMASTER.challan_yearid = CHALLANMASTER_DESC.CHALLAN_YEARID INNER JOIN LEDGERS ON CHALLANMASTER.challan_ledgerid = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON CHALLANMASTER_DESC.CHALLAN_ITEMID = ITEMMASTER.item_id INNER JOIN ORDERMASTER_DESC ON CHALLANMASTER.CHALLAN_ORDERSRNO = ORDERMASTER_DESC.ORDER_GRIDSRNO AND CHALLANMASTER.challan_yearid = ORDERMASTER_DESC.ORDER_YEARID AND CHALLANMASTER.CHALLAN_ORDERNO = ORDERMASTER_DESC.ORDER_NO LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN LEDGERS AS TRANSPORT ON CHALLANMASTER.challan_transid = TRANSPORT.Acc_id LEFT OUTER JOIN CITYMASTER ON CHALLAN_CITYID = CITYMASTER.CITY_ID", " AND CHALLANMASTER.CHALLAN_NO =" & CHALLANNO & " AND challanmaster.CHALLAN_YEARID = " & YearId)

            If DT.Rows.Count > 0 Then
                If ClientName <> "AMR" Then gridinvoice.RowCount = 0
                For Each DR As DataRow In DT.Rows
                    txtchallanno.Text = Convert.ToString(DR("CHALLANNO"))
                    ' TXTINVOICENO.Text = Convert.ToString(DR("CHALLANNO"))
                    txtorderno.Text = Convert.ToString(DR("ORDERNO"))
                    TXTORDERSRNO.Text = Convert.ToString(DR("ORDERSRNO"))
                    TXTJOBNO.Text = Convert.ToString(DR("JOBNO"))
                    txtname.Text = Convert.ToString(DR("NAME"))
                    txtpono.Text = Convert.ToString(DR("PONO"))
                    txtpodate.Text = DR("PODATE")
                    txtchallandate.Text = DR("CHALLANDATE")
                    invoicedate.Value = Format(Convert.ToDateTime(DR("CHALLANDATE")).Date, "dd/MM/yyyy")
                    ' txtchallanno.Text = Convert.ToString(DR("CHALLANNO"))

                    TXTTRANSNAME.Text = Convert.ToString(DR("DESPATCHNAME"))
                    CMBTOCITY.Text = DR("CITY")


                    ''GRID PARAMATERS
                    'gridinvoice.Rows.Add(DR("ITEMCODE").ToString, DR("ITEMNAME").ToString, DR("MCODE").ToString, Val(DR("QTY")), DR("BATCHNO").ToString, Format(Val(DR("BASICRATE")), "0.0000", ))

                    If CHKEXPORTGST.Checked = True Then
                        DR("CGSTPER") = DR("EXPCGSTPER")
                        DR("SGSTPER") = DR("EXPSGSTPER")
                        DR("IGSTPER") = DR("EXPIGSTPER")
                    End If


                    If DR("ITEMNAME").ToString <> "" And Convert.ToDateTime(invoicedate.Text).Date >= "01/07/2017" Then
                        If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                            gridinvoice.Rows.Add(DR("ITEMCODE").ToString, DR("ITEMNAME").ToString, DR("HSNCODE").ToString, DR("MCODE").ToString, Val(DR("QTY")), DR("BATCHNO").ToString, Format(Val(DR("BASICRATE")), "0.0000"), 0, Format(Val(DR("PROCHARGE")), "0.0000"), 0, Format(Val(DR("CGSTPER")), "0.00"), 0, Format(Val(DR("SGSTPER")), "0.00"), 0, 0, 0, 0, Val(DR("CHALLANNO")))
                        Else
                            gridinvoice.Rows.Add(DR("ITEMCODE").ToString, DR("ITEMNAME").ToString, DR("HSNCODE").ToString, DR("MCODE").ToString, Val(DR("QTY")), DR("BATCHNO").ToString, Format(Val(DR("BASICRATE")), "0.0000"), 0, Format(Val(DR("PROCHARGE")), "0.0000"), 0, 0, 0, 0, 0, Format(Val(DR("IGSTPER")), "0.00"), 0, 0, Val(DR("CHALLANNO")))

                        End If
                    Else
                        gridinvoice.Rows.Add(DR("ITEMCODE").ToString, DR("ITEMNAME").ToString, DR("HSNCODE").ToString, DR("MCODE").ToString, Val(DR("QTY")), DR("BATCHNO").ToString, Format(Val(DR("BASICRATE")), "0.0000"), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Val(DR("CHALLANNO")))
                    End If

                    CMDSELECTCHALLAN.Enabled = False
                    txtchallanno.Enabled = False

                    Dim DTT As DataTable = OBJCMN.search("ISNULL(ORDERMASTER_DESC.ORDER_PROCHRGE, 0) AS PROCHARGE", "", "INVOICEMASTER INNER JOIN ORDERMASTER_DESC ON INVOICEMASTER.INVOICE_ORDERNO = ORDERMASTER_DESC.ORDER_NO AND INVOICEMASTER.invoice_yearid = ORDERMASTER_DESC.ORDER_YEARID INNER JOIN ITEMMASTER ON ORDERMASTER_DESC.ORDER_ITEMID = ITEMMASTER.item_id AND ORDERMASTER_DESC.ORDER_YEARID = ITEMMASTER.item_yearid INNER JOIN REGISTERMASTER ON INVOICEMASTER.invoice_registerid = REGISTERMASTER.register_id", "AND INVOICEMASTER.INVOICE_PONO = '" & txtpono.Text.Trim & "' AND INVOICEMASTER.INVOICE_ORDERNO = " & Val(txtorderno.Text.Trim) & " AND INVOICEMASTER.INVOICE_ORDERSRNO = " & Val(TXTORDERSRNO.Text.Trim) & "  AND INVOICEMASTER.INVOICE_YEARID = " & YearId)
                    If DTT.Rows.Count > 0 Then
                        txtprocessing.Text = "0.00"
                    End If

                Next
                CALC()
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then fillregister(cmbregister, " and register_type = 'SALE'")

            Dim clscommon As New ClsCommon
            Dim dt As DataTable
            dt = clscommon.search(" register_name,register_id", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'SALE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                cmbregister.Text = dt.Rows(0).Item(0).ToString
            End If
            GETMAX_INVOICE_NO()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 And edit = False Then
                ' CLEAR()
                cmbregister.Text = UCase(cmbregister.Text)
                Dim clscommon As New ClsCommon
                Dim dt As DataTable
                dt = clscommon.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'SALE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    saleregabbr = dt.Rows(0).Item(0).ToString
                    salereginitial = dt.Rows(0).Item(1).ToString
                    GETMAX_INVOICE_NO()
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

    Private Sub gridinvoice_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridinvoice.CellValidating
        Try
            Dim colNum As Integer = gridinvoice.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GQTY.Index, GRATE.Index, GOTHERAMT.Index, GCGSTAMT.Index, GSGSTAMT.Index, GIGSTAMT.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If gridinvoice.CurrentCell.Value = Nothing Then gridinvoice.CurrentCell.Value = "0.000"
                        gridinvoice.CurrentCell.Value = Convert.ToDecimal(gridinvoice.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        CALC()
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

    Private Sub cmbdelivery_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbdelivery_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, txtdeladd, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CALC()
        If gridinvoice.RowCount > 0 Then
            For Each ROW As Windows.Forms.DataGridViewRow In gridinvoice.Rows
                ROW.Cells(GAMOUNT.Index).Value = Format((Val(ROW.Cells(GQTY.Index).EditedFormattedValue) * Val(ROW.Cells(GRATE.Index).EditedFormattedValue)), "0.00")

                ROW.Cells(GTAXABLEAMT.Index).Value = Format((Val(ROW.Cells(GAMOUNT.Index).EditedFormattedValue) + Val(ROW.Cells(GOTHERAMT.Index).EditedFormattedValue)), "0.00")

                If CHKMANUAL.CheckState = CheckState.Unchecked Then

                    ROW.Cells(GCGSTAMT.Index).Value = Format((Val(ROW.Cells(GCGSTPER.Index).EditedFormattedValue) / 100 * Val(ROW.Cells(GTAXABLEAMT.Index).EditedFormattedValue)), "0.00")
                    ROW.Cells(GSGSTAMT.Index).Value = Format((Val(ROW.Cells(GSGSTPER.Index).EditedFormattedValue) / 100 * Val(ROW.Cells(GTAXABLEAMT.Index).EditedFormattedValue)), "0.00")
                    ROW.Cells(GIGSTAMT.Index).Value = Format((Val(ROW.Cells(GIGSTPER.Index).EditedFormattedValue) / 100 * Val(ROW.Cells(GTAXABLEAMT.Index).EditedFormattedValue)), "0.00")
                End If
                ROW.Cells(GGRIDTOTAL.Index).Value = Format((Val(ROW.Cells(GTAXABLEAMT.Index).EditedFormattedValue) + Val(ROW.Cells(GCGSTAMT.Index).EditedFormattedValue) + Val(ROW.Cells(GSGSTAMT.Index).EditedFormattedValue) + Val(ROW.Cells(GIGSTAMT.Index).EditedFormattedValue)), "0.00")
            Next
        End If
    End Sub

    Private Sub txtpakagingchgs_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpakagingchgs.Validated
        TOTAL()
    End Sub

    Private Sub txtotherchg_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTOTHERCHGS.Validated
        TOTAL()
    End Sub

    Private Sub txttax_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttax.Validated
        TOTAL()
    End Sub

    Private Sub TXTEXTRACHARGE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTEXTRACHGS.Validated
        TOTAL()
    End Sub

    Private Sub CMBTAX_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTAX.Validating
        Try
            If CMBTAX.Text.Trim <> "" Then TAXvalidate(CMBTAX, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOTHERCHGSNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBOTHERCHGSNAME.Validated
        TOTAL()
    End Sub

    Private Sub CMBOTHERCHGS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBOTHERCHGSNAME.Validating
        Try
            If CMBOTHERCHGSNAME.Text.Trim <> "" Then namevalidate(CMBOTHERCHGSNAME, CMBCODE, e, Me, txtdeladd, " AND (GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT INCOME' OR GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT EXPENSES')", "INDIRECT INCOME")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbaddsub_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbaddsub.Validated
        TOTAL()
    End Sub

    Private Sub CMBEXTRAADDSUB_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBEXTRAADDSUB.Validated
        TOTAL()
    End Sub

    Private Sub CMBEXTRACHGSNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBEXTRACHGSNAME.Validated
        TOTAL()
    End Sub

    Private Sub CMBEXTRACHARGE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBEXTRACHGSNAME.Validating
        Try
            If CMBEXTRACHGSNAME.Text.Trim <> "" Then namevalidate(CMBEXTRACHGSNAME, CMBCODE, e, Me, txtdeladd, " AND (GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT INCOME' OR GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT EXPENSES') ", "INDIRECT INCOME")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOTHERCHGS_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBOTHERCHGSNAME.Enter
        Try
            If CMBOTHERCHGSNAME.Text.Trim = "" Then fillname(CMBOTHERCHGSNAME, edit, " AND (GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT INCOME' OR GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT EXPENSES')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBEXTRACHARGE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBEXTRACHGSNAME.Enter
        Try
            If CMBEXTRACHGSNAME.Text.Trim = "" Then fillname(CMBEXTRACHGSNAME, edit, " AND (GROUP_SECONDARY = 'INDIRECT INCOME' OR GROUP_SECONDARY = 'DIRECT INCOME' OR GROUP_SECONDARY = 'INDIRECT EXPENSES' OR GROUP_SECONDARY = 'DIRECT EXPENSES')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTAX_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTAX.Enter
        Try
            If CMBTAX.Text.Trim = "" Then filltax(CMBTAX, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTAX_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTAX.Validated
        TOTAL()
    End Sub

    Private Sub CMBNAME_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then
                Dim objcmn As New ClsCommon
                Dim dt As DataTable = objcmn.search(" ISNULL(STATEMASTER.state_name, '') AS STATENAME , ISNULL(LEDGERS.Acc_ADD, '') AS ADDRESS, ISNULL(ACC_CRDAYS,0) AS CRDAYS,  ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN ", "", "LEDGERS LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id", "AND LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "'AND acc_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    txtdeladd.Text = dt.Rows(0).Item("ADDRESS")
                    TXTCRDAYS.Text = Val(dt.Rows(0).Item("CRDAYS"))

                    TXTSTATECODE.Text = dt.Rows(0).Item("STATECODE")
                    TXTGSTIN.Text = dt.Rows(0).Item("GSTIN")
                    cmbstate.Text = dt.Rows(0).Item("STATENAME")

                    DueDate.Value = DateAdd(DateInterval.Day, Val(TXTCRDAYS.Text.Trim), invoicedate.Value.Date)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtotherchg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTOTHERCHGS.KeyPress
        numdot(e, TXTOTHERCHGS, Me)
    End Sub

    Private Sub txtpakagingchgs_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpakagingchgs.KeyPress
        numdot(e, txtpakagingchgs, Me)
    End Sub

    Private Sub TXTEXTRACHARGE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTEXTRACHGS.KeyPress
        numdot(e, TXTEXTRACHGS, Me)
    End Sub

    Private Sub cmbdelivery_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry debtors'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub invoicedate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles invoicedate.Validating
        Try
            If Not datecheck(invoicedate.Value) Then
                MsgBox("Date Not in Current Accounting Year")
                e.Cancel = True
            End If
            If Val(TXTCRDAYS.Text.Trim) > 0 Then DueDate.Value = DateAdd(DateInterval.Day, Val(TXTCRDAYS.Text), invoicedate.Value.Date) Else DueDate.Value = invoicedate.Value
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtchallanno_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtchallanno.KeyDown
        Try
            If e.KeyCode = Keys.F1 And edit = False Then CMDSELECTCHALLAN_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            If edit = False And Val(txtprintfrom.Text) = 0 And Val(txtprintto.Text) = 0 Then Exit Sub
            If Val(txtprintfrom.Text) = 0 And Val(txtprintto.Text) = 0 Then PRINTREPORT(TEMPINVOICENO)
            If Val(txtprintfrom.Text.Trim) > 0 And Val(txtprintto.Text.Trim) > 0 And (Val(txtprintfrom.Text) < Val(txtprintto.Text.Trim)) Then

                'For I As Integer = Val(txtprintfrom.Text) To Val(txtprintto.Text)
                '    TEMPINVOICENO = I
                '    'PRINTREPORT(TEMPINVOICENO)
                'Next
                If Val(txtprintfrom.Text.Trim) > Val(txtprintto.Text.Trim) Then
                    MsgBox("Enter Propoer Invoice Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    fromno = Val(txtprintfrom.Text.Trim)
                    tono = Val(txtprintto.Text.Trim)
                    Dim tempMsg As Integer
                    tempMsg = MsgBox("Wish to Print Invoice from " & fromno & " To " & tono & " ?", MsgBoxStyle.YesNo)
                    If tempMsg = vbYes Then serverprop(fromno, tono, Val(TXTCOPIES.Text.Trim))
                End If

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

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                gridinvoice.RowCount = 0
                TEMPINVOICENO = Val(tstxtbillno.Text)
                TEMPREGNAME = cmbregister.Text.Trim
                If TEMPINVOICENO > 0 Then
                    edit = True
                    Invoice_Load(sender, e)
                Else
                    edit = False
                    CLEAR()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshowdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowdetails.Click
        Try
            Dim OBJRECPAY As New ShowRecPay
            OBJRECPAY.MdiParent = MDIMain
            OBJRECPAY.PURBILLINITIALS = salereginitial & "-" & TEMPINVOICENO
            OBJRECPAY.SALEBILLINITIALS = salereginitial & "-" & TEMPINVOICENO
            OBJRECPAY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtchallanno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtchallanno.KeyPress
        numkeypress(e, txtchallanno, Me)
    End Sub

    Private Sub txtchallanno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtchallanno.Validating
        Try
            If Val(txtchallanno.Text.Trim) > 0 And edit = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(INVOICEMASTER.invoice_challanno,0)  AS CHALLANNO", "", " INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICEMASTER.invoice_registerid = REGISTERMASTER.register_id ", "   AND INVOICEMASTER.INVOICE_CHALLANNO=" & txtchallanno.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICEMASTER.INVOICE_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Challan No Already Exist")
                    e.Cancel = True
                Else
                    FETCHDATA(Val(txtchallanno.Text.Trim))

                    If TXTMULTICHALLANNO.Text.Trim = "" And txtchallanno.Text.Trim <> "" Then TXTMULTICHALLANNO.Text = txtchallanno.Text
                    If TXTMULTIPONO.Text.Trim = "" And txtpono.Text.Trim <> "" Then TXTMULTIPONO.Text = txtpono.Text

                    If gridinvoice.RowCount = 0 Then
                        MsgBox("Invalid Challan No", MsgBoxStyle.Critical)
                        txtchallanno.Clear()
                        e.Cancel = True
                        Exit Sub
                    Else
                        CMDSELECTCHALLAN.Enabled = False
                        txtchallanno.Enabled = False
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtprocessing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtprocessing.KeyPress
        numdotkeypress(e, txtprocessing, Me)
    End Sub



    Private Sub txtprocessing_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtprocessing.Validated
        TOTAL()
    End Sub

    Private Sub TXTCRDAYS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCRDAYS.Validating
        Try
            If (Val(TXTCRDAYS.Text.Trim)) > 0 Then DueDate.Value = DateAdd(DateInterval.Day, Val(TXTCRDAYS.Text.Trim), invoicedate.Value.Date)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKTCS_CheckedChanged(sender As Object, e As EventArgs) Handles CHKTCS.CheckedChanged
        TOTAL()
    End Sub

    Private Sub TOOLEWB_Click(sender As Object, e As EventArgs) Handles TOOLEWB.Click
        Try
            If edit = False Then Exit Sub
            GENERATEEWB()
            PRINTEWB()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GENERATEEWB()
        Try
            If ALLOWEWAYBILL = False Then Exit Sub
            If CMBNAME.Text.Trim = "" Then Exit Sub

            If Val(LBLTOTALCGSTAMT.Text.Trim) = 0 And Val(LBLTOTALSGSTAMT.Text.Trim) = 0 And Val(LBLTOTALIGSTAMT.Text.Trim) = 0 Then Exit Sub


            If TXTLRNO.Text.Trim <> "" AndAlso LRDATE.Text <> "__/__/____" Then
                If Convert.ToDateTime(LRDATE.Text).Date < Convert.ToDateTime(invoicedate.Text).Date Then
                    MsgBox("LR Date cannot be Before Invoice Date", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If

            If CMBFROMCITY.Text.Trim = "" Then
                MsgBox("Enter From City", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If CMBTOCITY.Text.Trim = "" Then
                MsgBox("Enter to City", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Generate E-Way Bill?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If TXTEWAYBILLNO.Text.Trim <> "" Then
                MsgBox("E-Way Bill No Already Generated", MsgBoxStyle.Critical)
                Exit Sub
            End If

            MsgBox("E-Way Bill will not be Generated if there are special characters like {*,/ nb,""""} in Quality Name ", MsgBoxStyle.Critical)

            'BEFORE GENERATING EWAY BILL WE NEED TO VALIDATE WHETHER ALL THE DATA ARE PRESENT OR NOT
            'IF DATA IS NOT PRESENT THEN VALIDATE
            'DATA TO BE CHECKED 
            '   1)CMPEWBUSER | CMPEWBPASS | CMPGSTIN | CMPPINCODE | CMPCITY | CMPSTATE | 
            '   2)PARTYGSTIN | PARTYCITY | PARTYPINCODE | PARTYSTATE | PARTYSTATECODE | PARTYKMS
            '   3)CGST OR SGST OR IGST (ALWAYS USE MTR IN QTYUNIT)
            If CMPEWBUSER = "" Or CMPEWBPASS = "" Or CMPGSTIN = "" Or CMPPINCODE = "" Or CMPCITYNAME = "" Or CMPSTATENAME = "" Then
                MsgBox(" Company Details are not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim TEMPCMPADD1 As String = ""
            Dim TEMPCMPADD2 As String = ""
            Dim PARTYGSTIN As String = ""
            Dim PARTYPINCODE As String = ""
            Dim PARTYSTATECODE As String = ""
            Dim PARTYSTATENAME As String = ""
            Dim SHIPTOGSTIN As String = ""
            Dim SHIPTOSTATECODE As String = ""
            Dim SHIPTOSTATENAME As String = ""
            Dim PARTYKMS As Double = 0
            Dim PARTYADD1 As String = ""
            Dim PARTYADD2 As String = ""
            Dim TRANSGSTIN As String = ""

            Dim OBJCMN As New ClsCommon
            'CMP ADDRESS DETAILS
            Dim DT As DataTable = OBJCMN.search(" ISNULL(CMP_DISPATCHFROM, '') AS ADD1, ISNULL(CMP_ADD2,'') AS ADD2 ", "", " CMPMASTER ", " AND CMP_ID = " & CmpId)
            TEMPCMPADD1 = DT.Rows(0).Item("ADD1")
            TEMPCMPADD2 = DT.Rows(0).Item("ADD2")


            'PARTY GST DETAILS 
            DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN, (CASE WHEN ISNULL(ACC_DELIVERYPINCODE,'') <> '' THEN ISNULL(ACC_DELIVERYPINCODE,'') ELSE ISNULL(ACC_ZIPCODE,'') END) AS PINCODE, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE, ISNULL(ACC_KMS,0) AS KMS, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2 ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID ", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If DT.Rows(0).Item("GSTIN") = "" Or DT.Rows(0).Item("PINCODE") = "" Or DT.Rows(0).Item("STATENAME") = "" Or DT.Rows(0).Item("STATECODE") = "" Or Val(DT.Rows(0).Item("KMS")) = 0 Then
                MsgBox(" Party Details are not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            Else
                PARTYGSTIN = DT.Rows(0).Item("GSTIN")
                SHIPTOGSTIN = DT.Rows(0).Item("GSTIN")
                PARTYSTATENAME = DT.Rows(0).Item("STATENAME")
                PARTYSTATECODE = DT.Rows(0).Item("STATECODE")
                SHIPTOSTATENAME = DT.Rows(0).Item("STATENAME")
                SHIPTOSTATECODE = DT.Rows(0).Item("STATECODE")
                PARTYPINCODE = DT.Rows(0).Item("PINCODE")
                'PARTYKMS = Val(DT.Rows(0).Item("KMS"))
                PARTYADD1 = DT.Rows(0).Item("ADD1")
                PARTYADD2 = DT.Rows(0).Item("ADD2")
            End If


            'FETCH PINCODE / KMS / ADD1 / ADD2 OF SHIPTO IF IT IS NOT SAME AS CMBNAME
            If txtname.Text.Trim <> "" AndAlso CMBNAME.Text.Trim <> txtname.Text.Trim Then
                DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN,  (CASE WHEN ISNULL(ACC_DELIVERYPINCODE,'') <> '' THEN ISNULL(ACC_DELIVERYPINCODE,'') ELSE ISNULL(ACC_ZIPCODE,'') END) AS PINCODE, ISNULL(ACC_KMS,0) AS KMS, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID ", " AND ACC_CMPNAME = '" & txtname.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows(0).Item("PINCODE") = "" Or Val(DT.Rows(0).Item("KMS")) = 0 Then
                    MsgBox(" Party Details are not filled properly ", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    SHIPTOGSTIN = DT.Rows(0).Item("GSTIN")
                    PARTYPINCODE = DT.Rows(0).Item("PINCODE")
                    'PARTYKMS = Val(DT.Rows(0).Item("KMS"))
                    PARTYADD1 = DT.Rows(0).Item("ADD1")
                    PARTYADD2 = DT.Rows(0).Item("ADD2")
                    SHIPTOSTATENAME = DT.Rows(0).Item("STATENAME")
                    SHIPTOSTATECODE = DT.Rows(0).Item("STATECODE")
                End If
            End If


            'TRANSPORT GSTING IS NOT MANDATORY
            'FOR LOCAL TRANSPORT THERE IS NO GSTIN
            'TRANSPORT GSTIN IF TRANSPORT IS PRESENT
            If TXTTRANSNAME.Text.Trim <> "" Then
                DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN ", "", " LEDGERS ", " AND ACC_CMPNAME = '" & TXTTRANSNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then TRANSGSTIN = DT.Rows(0).Item("GSTIN")
                'FOR LOCAL TRANSPORT THERE IS NO GSTIN
                'If TRANSGSTIN = "" Then
                '    MsgBox("Enter Transport GSTIN", MsgBoxStyle.Critical)
                '    Exit Sub
                'End If
            End If



            'CHECKING COUNTER AND VALIDATE WHETHER EWAY BILL WILL BE ALLOWED OR NOT, FOR EACH EWAY BILL WE NEED TO 2 API COUNTS (1 FOR TOKEN AND ANOTHER FOR EWB)
            If CMPEWAYCOUNTER = 0 Then
                MsgBox("EWay Bill Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'GET USED EWAYCOUNTER
            Dim USEDEWAYCOUNTER As Integer = 0
            DT = OBJCMN.search("COUNT(COUNTERID) AS EWAYCOUNT", "", "EWAYENTRY", " AND CMPID =" & CmpId)
            If DT.Rows.Count > 0 Then USEDEWAYCOUNTER = Val(DT.Rows(0).Item("EWAYCOUNT"))

            'IF COUNTERS ARE FINISJED
            If CMPEWAYCOUNTER - USEDEWAYCOUNTER <= 0 Then
                MsgBox("EWay Bill Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'IF DATE HAS EXPIRED
            If Now.Date > EWAYEXPDATE Then
                MsgBox("EWay Bill Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'IF BALANCECOUNTERS ARE .10 THEN INTIMATE
            If CMPEWAYCOUNTER - USEDEWAYCOUNTER < Format((CMPEWAYCOUNTER * 0.1), "0") Then
                MsgBox("Only " & (CMPEWAYCOUNTER - USEDEWAYCOUNTER) & " API's Left, Kindly contact Nakoda Infotech for Renewal of EWB Package", MsgBoxStyle.Critical)
            End If


            'FOR GENERATING EWAY BILL WE NEED TO FIRST GENERATE THE TOKEN
            'THIS IS FOR SANDBOX TEST
            'Dim URL As New Uri("https://gstsandbox.charteredinfo.com/ewaybillapi/dec/v1.03/auth?action=ACCESSTOKEN&aspid=1602611918&password=infosys123&gstin=34AACCC1596Q002&username=TaxProEnvPON&ewbpwd=abc34*")
            Dim URL As New Uri("https://einvapi.charteredinfo.com/v1.03/dec/auth?action=ACCESSTOKEN&aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&username=" & CMPEWBUSER & "&ewbpwd=" & CMPEWBPASS)

            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Dim REQUEST As WebRequest
            Dim RESPONSE As WebResponse
            REQUEST = WebRequest.CreateDefault(URL)

            REQUEST.Method = "GET"
            Try
                RESPONSE = REQUEST.GetResponse()
            Catch ex As WebException
                RESPONSE = ex.Response
            End Try
            Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
            Dim REQUESTEDTEXT As String = READER.ReadToEnd()

            'IF STATUS IS NOT 1 THEN TOKEN IS NOT GENERATED
            Dim STARTPOS As Integer = 0
            Dim TEMPSTATUS As String = ""
            Dim TOKEN As String = ""
            Dim ENDPOS As Integer = 0

            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 3
            TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
            If TEMPSTATUS = "1" Then TEMPSTATUS = "SUCCESS" Else TEMPSTATUS = "FAILED"




            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("authtoken") + Len("AUTHTOKEN") + 3
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS) - 1
            TOKEN = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            'ADD DATA IN EWAYENTRY
            'DONT ADD IN EWAYENTRY, DONE BY GULKIT, IF FAILED THEN ADD
            'DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


            'ONCE WE REC THE TOKEN WE WILL CREATE EWAY BILL
            'IF STATUS IS FAILED THEN ERROR MESSAGE
            If TEMPSTATUS = "FAILED" Then
                MsgBox("Unable to create Eway Bill", MsgBoxStyle.Critical)
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                Exit Sub
            End If



            'GENERATING EWAY BILL 
            'FOR SANBOX TEST
            'Dim FURL As New Uri("https://gstsandbox.charteredinfo.com/ewaybillapi/dec/v1.03/ewayapi?action=GENEWAYBILL&aspid=1602611918&password=infosys123&gstin=34AACCC1596Q002&username=TaxProEnvPON&authtoken=" & TOKEN)
            Dim FURL As New Uri("https://einvapi.charteredinfo.com/v1.03/dec/ewayapi?action=GENEWAYBILL&aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&username=" & CMPEWBUSER & "&authtoken=" & TOKEN)
            REQUEST = WebRequest.CreateDefault(FURL)
            REQUEST.Method = "POST"
            Try
                REQUEST.ContentType = "application/json"


                'For WORKING ON SANDBOX
                'CMPGSTIN = "34AACCC1596Q002"
                'CMPPINCODE = "605001"
                'CMPSTATECODE = "34"


                Dim j As String = ""

                j = "{"
                j = j & """supplyType"":""O"","
                j = j & """subSupplyType"":""4"","
                j = j & """subSupplyDesc"":"""","
                j = j & """docType"":""CHL"","

                'WE NEED TO FETCH CHALLANNO INSTEAD OF PRINTINITIALS
                'AS WE ARE GENERATING EWAY ON CHALLAN NO
                'Dim DTINI As DataTable = OBJCMN.search("INVOICE_PRINTINITIALS AS PRINTINITIALS", "", "INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID", " AND INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId)
                Dim DTINI As DataTable = OBJCMN.search("CMPMASTER.cmp_invinitials + '/' + RIGHT(CONVERT(VARCHAR(8), year_startdate, 1),2) + '-' +RIGHT(CONVERT(VARCHAR(8), year_enddate, 1),2)  + '/' + CAST(INVOICE_CHALLANNO AS VARCHAR(100)) AS PRINTINITIALS", "", "INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID INNER JOIN CMPMASTER ON invoice_cmpid = cmp_id INNER JOIN YEARMASTER ON invoice_yearid = year_id ", " AND INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId)

                j = j & """docNo"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                j = j & """docDate"":""" & invoicedate.Text & """" & ","
                j = j & """fromGstin"":""" & CMPGSTIN & """" & ","
                j = j & """fromTrdName"":""" & CmpName & """" & ","
                j = j & """fromAddr1"":""" & TEMPCMPADD1 & """" & ","
                j = j & """fromAddr2"":""" & TEMPCMPADD2 & """" & ","
                j = j & """fromPlace"":""" & CMBFROMCITY.Text.Trim & """" & ","
                j = j & """fromPincode"":""" & CMPPINCODE & """" & ","
                j = j & """actFromStateCode"":""" & CMPSTATECODE & """" & ","
                j = j & """fromStateCode"":""" & CMPSTATECODE & """" & ","
                j = j & """toGstin"":""" & PARTYGSTIN & """" & ","
                j = j & """toTrdName"":""" & CMBNAME.Text.Trim & """" & ","
                j = j & """toAddr1"":""" & PARTYADD1 & """" & ","
                j = j & """toAddr2"":""" & PARTYADD2 & """" & ","
                j = j & """toPlace"":""" & txtname.Text.Trim & "-" & SHIPTOGSTIN & CMBTOCITY.Text.Trim & """" & ","
                j = j & """toPincode"":""" & PARTYPINCODE & """" & ","
                j = j & """actToStateCode"":""" & SHIPTOSTATECODE & """" & ","
                j = j & """toStateCode"":""" & PARTYSTATECODE & """" & ","

                j = j & """transactionType"":""1"","
                j = j & """dispatchFromGSTIN"":""" & CMPGSTIN & """" & ","
                j = j & """dispatchFromTradeName"":""" & CmpName & """" & ","
                j = j & """shipToGSTIN"":""" & SHIPTOGSTIN & """" & ","
                j = j & """shipToTradeName"":""" & txtname.Text.Trim & """" & ","
                j = j & """otherValue"":""0"","



                j = j & """totalValue"":""" & Val(LBLTOTALTAXABLEAMT.Text.Trim) & """" & ","
                j = j & """cgstValue"":""" & Val(LBLTOTALCGSTAMT.Text.Trim) & """" & ","
                j = j & """sgstValue"":""" & Val(LBLTOTALSGSTAMT.Text.Trim) & """" & ","
                j = j & """igstValue"":""" & Val(LBLTOTALIGSTAMT.Text.Trim) & """" & ","
                j = j & """cessValue"":""" & "0" & """" & ","
                j = j & """cessNonAdvolValue"":""" & "0" & """" & ","
                j = j & """totInvValue"":""" & Val(txtgrandtotal.Text.Trim) & """" & ","
                j = j & """transporterId"":""" & TRANSGSTIN & """" & ","
                j = j & """transporterName"":""" & TXTTRANSNAME.Text.Trim & """" & ","


                'THIS CODE IS WRITTEN COZ WHEN BILLTO AND SHIPTO ARE IN THE SAME PINCODE THEN WE HAVE TO PASS MINIMUM 10 KMS
                'OR ELSE IT WILL GIVE ERROR
                If CMPPINCODE = PARTYPINCODE Then PARTYKMS = 10

                If TXTVEHICLENO.Text.Trim = "" Then
                    j = j & """transDocNo"":"""","
                    j = j & """transMode"":"""","
                    j = j & """transDistance"":""" & PARTYKMS & """" & ","
                    j = j & """transDocDate"":"""","
                    j = j & """vehicleNo"":"""","
                    j = j & """vehicleType"":"""","
                Else
                    j = j & """transDocNo"":""" & TXTLRNO.Text.Trim & """" & ","
                    j = j & """transMode"":""" & "1" & """" & ","
                    j = j & """transDistance"":""" & PARTYKMS & """" & ","
                    If LRDATE.Text <> "__/__/____" Then j = j & """transDocDate"":""" & LRDATE.Text & """" & "," Else j = j & """transDocDate"":"""","
                    j = j & """vehicleNo"":""" & TXTVEHICLENO.Text.Trim & """" & ","
                    j = j & """vehicleType"":""" & "R" & """" & ","
                End If


                j = j & """itemList"":[{"




                'WE NEED TO FETCH SUMMARY OF ITEMS AND HSN TO PASS HERE
                'FETCH FROM DESC TABLE 
                DT = OBJCMN.Execute_Any_String(" SELECT ITEM_NAME AS ITEMNAME, ISNULL(HSN_CODE,'') AS HSNCODE, ISNULL(HSN_CGST,0) AS CGST, ISNULL(HSN_SGST,0) AS SGST, ISNULL(HSN_IGST,0) AS IGST, SUM(INVOICE_QTY) AS QTY, SUM(INVOICE_TAXABLEAMT) AS TAXABLEAMT FROM INVOICEMASTER_DESC INNER JOIN ITEMMASTER ON item_id = INVOICE_ITEMNAMEID INNER JOIN HSNMASTER ON HSN_ID = INVOICE_HSNCODEID INNER JOIN REGISTERMASTER ON INVOICEMASTER_DESC.INVOICE_REGISTERID = REGISTER_ID WHERE INVOICEMASTER_DESC.INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' and INVOICEMASTER_DESC.INVOICE_YEARID = " & YearId & " GROUP BY item_name, ISNULL(HSN_CODE,''), ISNULL(HSN_CGST,0), ISNULL(HSN_SGST,0), ISNULL(HSN_IGST,0) ", "", "")
                Dim CURRROW As Integer = 0
                For Each DTROW As DataRow In DT.Rows
                    If CURRROW > 0 Then j = j & ",{"
                    j = j & """productName"":""" & DTROW("ITEMNAME") & """" & ","
                    j = j & """productDesc"":""" & DTROW("ITEMNAME") & """" & ","
                    j = j & """hsnCode"":""" & CMBHSNCODE.Text.Trim & """" & ","
                    j = j & """quantity"":""" & Val(DTROW("QTY")) & """" & ","
                    j = j & """qtyUnit"":""" & "NOS" & """" & ","
                    j = j & """cgstRate"":""" & Val(gridinvoice.Item(GCGSTPER.Index, CURRROW).Value) & """" & ","
                    j = j & """sgstRate"":""" & Val(gridinvoice.Item(GSGSTPER.Index, CURRROW).Value) & """" & ","
                    j = j & """igstRate"":""" & Val(gridinvoice.Item(GIGSTPER.Index, CURRROW).Value) & """" & ","
                    j = j & """cessRate"":""" & "0" & """" & ","
                    'THIS CODE WAS IN V1.02
                    'j = j & """cessAdvol"":""" & "0" & """" & ","
                    j = j & """cessNonAdvol"":""" & "0" & """" & ","
                    j = j & """taxableAmount"":""" & Val(DTROW("TAXABLEAMT")) & """"
                    j = j & " }"
                    CURRROW += 1
                Next

                j = j & " ]}"

                Dim stream As Stream = REQUEST.GetRequestStream()
                Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(j)
                stream.Write(buffer, 0, buffer.Length)

                'POST request absenden
                RESPONSE = REQUEST.GetResponse()

            Catch ex As WebException
                'RESPONSE = ex.Response
                'MsgBox("Error While Generating EWB, Please check the Data Properly")
                ''ADD DATA IN EWAYENTRY
                'DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','FAILED', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


                RESPONSE = ex.Response
                'ADD DATA IN EWAYENTRY
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','FAILED', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                READER = New StreamReader(RESPONSE.GetResponseStream())
                REQUESTEDTEXT = READER.ReadToEnd()
                Dim ERRORMSG As String = ""
                STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("message") + Len("message") + 5
                ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("}", STARTPOS) - 2
                ERRORMSG = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
                MsgBox("Error While Generating EWB, " & ERRORMSG)

                Exit Sub
            End Try

            READER = New StreamReader(RESPONSE.GetResponseStream())
            REQUESTEDTEXT = READER.ReadToEnd()




            Dim EWBNO As String = ""

            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ewayBillNo") + Len("ewayBillNo") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS)
            EWBNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            TXTEWAYBILLNO.Text = EWBNO

            'WE NEED TO UPDATE THIS EWBNO IN DATABASE ALSO
            DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_EWAYBILLNO = '" & TXTEWAYBILLNO.Text.Trim & "' FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")

            'ADD DATA IN EWAYENTRY
            DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','" & EWBNO & "','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTEWB()
        Try

            If PRINTEWAYBILL = False Then Exit Sub
            If TXTEWAYBILLNO.Text.Trim = "" Then Exit Sub


            If MsgBox("Print EWB?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim TOKENNO As String = ""
            Dim EWBNO As String = ""

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(TOKENNO, '') AS TOKENNO, ISNULL(EWBNO, '') AS EWBNO ", "", " EWAYENTRY ", " AND EWBNO = '" & TXTEWAYBILLNO.Text.Trim & "' And YearId = " & YearId)
            If DT.Rows.Count = 0 Then Exit Sub
            TOKENNO = DT.Rows(0).Item("TOKENNO")
            EWBNO = DT.Rows(0).Item("EWBNO")

            'Dim URL As New Uri("https://gstsandbox.charteredinfo.com/ewaybillapi/dec/v1.03/ewayapi?action=GetEwayBill&aspid=1602611918&password=infosys123&gstin=34AACCC1596Q002&authtoken=" & TOKENNO & "&ewbNo=" & EWBNO)
            Dim URL As New Uri("https://einvapi.charteredinfo.com/v1.03/dec/ewayapi?action=GetEwayBill&aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&authtoken=" & TOKENNO & "&ewbNo=" & EWBNO)


            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Dim REQUEST As WebRequest
            Dim RESPONSE As WebResponse
            REQUEST = WebRequest.CreateDefault(URL)
            REQUEST.Method = "Get"
            Try
                RESPONSE = REQUEST.GetResponse()
            Catch ex As WebException
                RESPONSE = ex.Response
            End Try
            Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
            Dim REQUESTEDTEXT As String = READER.ReadToEnd()
            Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(REQUESTEDTEXT)

            'Dim FURL As New Uri("https://gstsandbox.charteredinfo.com/aspapi/v1.0/printewb?aspid=1602611918&password=infosys123&gstin=34AACCC1596Q002")
            Dim FURL As New Uri("https://einvapi.charteredinfo.com/aspapi/v1.0/printewb?aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN)
            REQUEST = WebRequest.CreateDefault(FURL)
            REQUEST.Method = "POST"
            Try
                REQUEST.ContentType = "application/x-www-form-urlencoded"
                REQUEST.ContentLength = buffer.Length

                Dim stream As Stream = REQUEST.GetRequestStream()
                stream.Write(buffer, 0, buffer.Length)

                'POST request absenden
                RESPONSE = REQUEST.GetResponse()
                Dim STRREADER As Stream = RESPONSE.GetResponseStream()
                Dim BINREADER As New BinaryReader(STRREADER)
                Dim BFFER As Byte() = BINREADER.ReadBytes(CInt(RESPONSE.ContentLength))
                File.WriteAllBytes(Application.StartupPath & "\EWB_" & TXTEWAYBILLNO.Text.Trim & ".pdf", BFFER)
                Process.Start(Application.StartupPath & "\EWB_" & TXTEWAYBILLNO.Text.Trim & ".pdf")

                'ADD DATA IN EWAYENTRY
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKENNO & "','" & EWBNO & "','PRINT SUCCESS1', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKENNO & "','" & EWBNO & "','PRINT SUCCESS2', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

            Catch ex As WebException
                RESPONSE = ex.Response
                MsgBox("Error While Printing EWB, Please check the Data Properly")
                'ADD DATA IN EWAYENTRY
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKENNO & "','" & EWBNO & "','PRINT FAILED1', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKENNO & "','" & EWBNO & "','PRINT FAILED2', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                Exit Sub
            End Try

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtinvoice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTINVOICENO.KeyPress, txtinvoice.KeyPress
        numkeypress(e, TXTINVOICENO, Me)
    End Sub

    Private Sub txtinvoice_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTINVOICENO.Validating, txtinvoice.Validating
        Try
            If Val(TXTINVOICENO.Text.Trim) > 0 And edit = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(INVOICEMASTER.INVOICE_NO,0)  AS INVOICENO", "", " INVOICEMASTER inner join REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID", "  AND INVOICEMASTER.INVOICE_NO=" & TXTINVOICENO.Text.Trim & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICEMASTER.INVOICE_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Invoice No Already Exist")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DueDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DueDate.Validating
        Try
            If DueDate.Value.Date < invoicedate.Value.Date Then
                MsgBox("Enter Proper Date !")
                e.Cancel = True
            End If
            TXTCRDAYS.Clear()
            TXTCRDAYS.Text = DueDate.Value.Date.Subtract(invoicedate.Value.Date).Days
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Invoice_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            If ClientName = "IYMP" Then GRATE.ReadOnly = True
            If ClientName = "AMR" Then
                TXTMULTICHALLANNO.Visible = True
                txtchallanno.Visible = False
                GroupBox1.Visible = False

            End If

            If ClientName = "RUTVIJ" Then
                LBLGRAIN.Text = "Grain Direction"
                LBLDESIGN.Text = "Size After Fold"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDUPLOADIRN_Click(sender As Object, e As EventArgs) Handles CMDUPLOADIRN.Click
        If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        OpenFileDialog1.Filter = "Pictures (*.png)|*.png"
        OpenFileDialog1.ShowDialog()

        OpenFileDialog1.AddExtension = True
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        TXTIMGPATH.Text = OpenFileDialog1.FileName
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & TXTINVOICENO.Text.Trim & TXTUPLOADSRNO.Text.Trim & TXTFILENAME.Text.Trim
        On Error Resume Next

        If TXTIMGPATH.Text.Trim.Length <> 0 Then
            PBQRCODE.ImageLocation = TXTIMGPATH.Text.Trim
            PBQRCODE.Load(TXTIMGPATH.Text.Trim)
        End If
    End Sub

    Private Async Sub CMDGETQRCODE_Click(sender As Object, e As EventArgs) Handles CMDGETQRCODE.Click
        Try
            If edit = True And TXTIRNNO.Text.Trim <> "" And IsNothing(PBQRCODE.Image) = True Then

                'FIRST GETTOKEN AND THEN GET QRCODE
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable

                'Dim URL As New Uri("http://gstsandbox.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=34AACCC1596Q002&user_name=TaxProEnvPON&eInvPwd=abc34*")
                Dim URL As New Uri("https://einvapi.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&eInvPwd=" & CMPEWBPASS)

                ServicePointManager.Expect100Continue = True
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

                Dim REQUEST As WebRequest
                Dim RESPONSE As WebResponse
                REQUEST = WebRequest.CreateDefault(URL)

                REQUEST.Method = "GET"
                Try
                    RESPONSE = REQUEST.GetResponse()
                Catch ex As WebException
                    RESPONSE = ex.Response
                End Try
                Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
                Dim REQUESTEDTEXT As String = READER.ReadToEnd()

                'IF STATUS IS NOT 1 THEN TOKEN IS NOT GENERATED
                Dim STARTPOS As Integer = 0
                Dim TEMPSTATUS As String = ""
                Dim TOKEN As String = ""
                Dim ENDPOS As Integer = 0

                STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 2
                TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
                If TEMPSTATUS = "1" Then TEMPSTATUS = "SUCCESS" Else TEMPSTATUS = "FAILED"




                STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("authtoken") + Len("AUTHTOKEN") + 3
                ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS) - 1
                TOKEN = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

                'ADD DATA IN EINVOICEENTRY
                'DONT ADD IN EINVOICEENTRY, DONE BY GULKIT, IF FAILED THEN ADD
                'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


                'ONCE WE REC THE TOKEN WE WILL CREATE EWAY BILL
                'IF STATUS IS FAILED THEN ERROR MESSAGE
                If TEMPSTATUS = "FAILED" Then
                    MsgBox("Unable to create Eway Bill", MsgBoxStyle.Critical)
                    DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "','" & REQUESTEDTEXT & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                    Exit Sub
                End If


                ''GET SIGNED QRCODE
                Dim req As New RestRequest
                req.AddParameter("application/json", "", RestSharp.ParameterType.RequestBody)
                'Dim client As New RestClient("http://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=34AACCC1596Q002&user_name=TaxProEnvPON&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim client As New RestClient("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim res As IRestResponse = Await client.ExecuteTaskAsync(req)
                Dim respPl = New RespPl()
                respPl = JsonConvert.DeserializeObject(Of RespPl)(res.Content)
                Dim respPlGenIRNDec As New RespPlGenIRNDec()
                respPlGenIRNDec = JsonConvert.DeserializeObject(Of RespPlGenIRNDec)(respPl.Data)
                'MsgBox(respPlGenIRNDec.Irn)
                Dim qrImg As Byte() = Convert.FromBase64String(respPlGenIRNDec.QrCodeImage)
                Dim tc As TypeConverter = TypeDescriptor.GetConverter(GetType(Bitmap))
                Dim bitmap1 As Bitmap = CType(tc.ConvertFrom(qrImg), Bitmap)
                'bitmap1.Save(Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png")

                'GET REGINITIALS AS SAVE WITH IT
                Dim TEMPREG As DataTable = OBJCMN.Execute_Any_String("SELECT REGISTER_INITIALS AS INITIALS FROM REGISTERMASTER WHERE REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE ='SALE' AND REGISTER_YEARID = " & YearId, "", "")
                bitmap1.Save(Application.StartupPath & "\" & TEMPREG.Rows(0).Item("INITIALS") & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\" & TEMPREG.Rows(0).Item("INITIALS") & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png"
                PBQRCODE.Refresh()

                'If PBQRCODE.Image IsNot Nothing Then
                '    Dim OBJINVOICE As New ClsInvoiceMaster
                '    Dim MS As New IO.MemoryStream
                '    PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                '    OBJINVOICE.alParaval.Add(TXTINVOICENO.Text.Trim)
                '    OBJINVOICE.alParaval.Add(cmbregister.Text.Trim)
                '    OBJINVOICE.alParaval.Add(MS.ToArray)
                '    OBJINVOICE.alParaval.Add(YearId)
                '    Dim INTRES As Integer = OBJINVOICE.SAVEQRCODE()
                'End If

                'DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_QRCODE = (SELECT * FROM OPENROWSET(BULK '" & Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png',SINGLE_BLOB) AS IMG) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")

                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                cmdok_Click(sender, e)

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLEINV_Click_1(sender As Object, e As EventArgs) Handles TOOLEINV.Click
        Try
            If edit = False Then Exit Sub
            GENERATEINV()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub GENERATEINV()
        Try
            If ALLOWEINVOICE = False Then Exit Sub
            If CMBNAME.Text.Trim = "" Then Exit Sub


            'THERE IS NO LRDAT COLUMN
            'If TXTLRNO.Text.Trim <> "" AndAlso LRDATE.Text <> "__/__/____" Then
            '    If Convert.ToDateTime(LRDATE.Text).Date < Convert.ToDateTime(INVOICEDATE.Text).Date Then
            '        MsgBox("LR Date cannot be Before Invoice Date", MsgBoxStyle.Critical)
            '        Exit Sub
            '    End If
            'End If

            If CMBFROMCITY.Text.Trim = "" Then
                MsgBox("Enter From City", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If CMBTOCITY.Text.Trim = "" Then
                MsgBox("Enter to City", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If CMBHSNCODE.Text.Trim = "" Then
                MsgBox("Select HSN Code", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Generate E-Invoice?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If TXTIRNNO.Text.Trim <> "" Then
                MsgBox("E-Invoice Already Generated", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'BEFORE GENERATING EINVOICE WE NEED TO VALIDATE WHETHER ALL THE DATA ARE PRESENT OR NOT
            'IF DATA IS NOT PRESENT THEN VALIDATE
            'DATA TO BE CHECKED 
            '   1)CMPEWBUSER | CMPEWBPASS | CMPGSTIN | CMPPINCODE | CMPCITY | CMPSTATE | 
            '   2)PARTYGSTIN | PARTYCITY | PARTYPINCODE | PARTYSTATE | PARTYSTATECODE | PARTYKMS
            '   3)CGST OR SGST OR IGST (ALWAYS USE MTR IN QTYUNIT)
            If CMPEWBUSER = "" Or CMPEWBPASS = "" Or CMPGSTIN = "" Or CMPPINCODE = "" Or CMPCITYNAME = "" Or CMPSTATENAME = "" Then
                MsgBox(" Company Details are not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim TEMPCMPADD1 As String = ""
            Dim TEMPCMPADD2 As String = ""
            Dim PARTYGSTIN As String = ""
            Dim PARTYPINCODE As String = ""
            Dim PARTYSTATECODE As String = ""
            Dim PARTYSTATENAME As String = ""
            Dim SHIPTOGSTIN As String = ""
            Dim SHIPTOSTATECODE As String = ""
            Dim SHIPTOSTATENAME As String = ""
            Dim SHIPTOPINCODE As String = ""
            Dim PARTYKMS As Double = 0
            Dim PARTYADD1 As String = ""
            Dim PARTYADD2 As String = ""
            Dim PARTYSEZ As String = ""
            Dim SHIPTOADD1 As String = ""
            Dim SHIPTOADD2 As String = ""
            Dim TRANSGSTIN As String = ""

            Dim OBJCMN As New ClsCommon
            'CMP ADDRESS DETAILS
            Dim DT As DataTable = OBJCMN.search(" ISNULL(CMP_DISPATCHFROM, '') AS ADD1, ISNULL(CMP_ADD2,'') AS ADD2 ", "", " CMPMASTER ", " AND CMP_ID = " & CmpId)
            TEMPCMPADD1 = DT.Rows(0).Item("ADD1")
            TEMPCMPADD2 = DT.Rows(0).Item("ADD2")

            'PARTY GST DETAILS 
            DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN, ISNULL(ACC_ZIPCODE,'') AS PINCODE, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE, ISNULL(ACC_KMS,0) AS KMS, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2, ISNULL(LEDGERS.ACC_SEZTYPE,'NON SEZ') AS SEZTYPE ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID ", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If (DT.Rows(0).Item("GSTIN") = "" Or DT.Rows(0).Item("PINCODE") = "" Or DT.Rows(0).Item("STATENAME") = "" Or DT.Rows(0).Item("STATECODE") = "" Or Val(DT.Rows(0).Item("KMS")) = 0) And CHKEXPORTGST.Checked = False Then
                MsgBox(" Party Details are not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            Else
                PARTYGSTIN = DT.Rows(0).Item("GSTIN")
                SHIPTOGSTIN = DT.Rows(0).Item("GSTIN")
                PARTYSTATENAME = DT.Rows(0).Item("STATENAME")
                PARTYSTATECODE = DT.Rows(0).Item("STATECODE")
                SHIPTOSTATENAME = DT.Rows(0).Item("STATENAME")
                SHIPTOSTATECODE = DT.Rows(0).Item("STATECODE")
                PARTYPINCODE = DT.Rows(0).Item("PINCODE")
                'PARTYKMS = Val(DT.Rows(0).Item("KMS"))
                PARTYADD1 = DT.Rows(0).Item("ADD1")
                PARTYADD2 = DT.Rows(0).Item("ADD2")
                PARTYSEZ = DT.Rows(0).Item("SEZTYPE")
            End If


            'IF PARTYSEZ IS TRUE THEN GST WILL BE 0
            If Val(LBLTOTALCGSTAMT.Text.Trim) = 0 And Val(LBLTOTALSGSTAMT.Text.Trim) = 0 And Val(LBLTOTALIGSTAMT.Text.Trim) = 0 And PARTYSEZ <> "SEZ" Then Exit Sub


            If CHKEXPORTGST.Checked = True Then
                PARTYGSTIN = "URP"
                SHIPTOGSTIN = "URP"
                PARTYSTATECODE = "96"
                SHIPTOSTATECODE = "96"
                PARTYPINCODE = "999999"
            End If


            If txtname.Text.Trim <> "" AndAlso CMBNAME.Text.Trim <> txtname.Text.Trim Then
                DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN, ISNULL(ACC_ZIPCODE,'') AS PINCODE, ISNULL(ACC_KMS,0) AS KMS, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID ", " AND ACC_CMPNAME = '" & txtname.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows(0).Item("PINCODE") = "" Or Val(DT.Rows(0).Item("KMS")) = 0 Then
                    MsgBox(" Party Details are not filled properly ", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    SHIPTOGSTIN = DT.Rows(0).Item("GSTIN")
                    SHIPTOPINCODE = DT.Rows(0).Item("PINCODE")
                    'PARTYKMS = Val(DT.Rows(0).Item("KMS"))
                    PARTYADD1 = DT.Rows(0).Item("ADD1")
                    PARTYADD2 = DT.Rows(0).Item("ADD2")
                    SHIPTOSTATENAME = DT.Rows(0).Item("STATENAME")
                    SHIPTOSTATECODE = DT.Rows(0).Item("STATECODE")
                End If
            End If


            If CHKEXPORTGST.Checked = True Then
                SHIPTOGSTIN = "URP"
                SHIPTOPINCODE = "999999"
            End If


            'TRANSPORT GSTING IS NOT MANDATORY
            'FOR LOCAL TRANSPORT THERE IS NO GSTIN
            'TRANSPORT GSTIN IF TRANSPORT IS PRESENT
            If TXTTRANSNAME.Text.Trim <> "" Then
                DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN ", "", " LEDGERS ", " AND ACC_CMPNAME = '" & TXTTRANSNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then TRANSGSTIN = DT.Rows(0).Item("GSTIN")
                'FOR LOCAL TRANSPORT THERE IS NO GSTIN
                'If TRANSGSTIN = "" Then
                '    MsgBox("Enter Transport GSTIN", MsgBoxStyle.Critical)
                '    Exit Sub
                'End If
            End If



            'CHECKING COUNTER AND VALIDATE WHETHER EINVOICE WILL BE ALLOWED OR NOT, FOR EACH EINVOICE BILL WE NEED TO 2 API COUNTS (1 FOR TOKEN AND ANOTHER FOR EINVOICE)
            If CMPEINVOICECOUNTER = 0 Then
                MsgBox("E-Invoice Bill Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'GET USED EINVOICECOUNTER
            Dim USEDEINVOICECOUNTER As Integer = 0
            DT = OBJCMN.search("COUNT(COUNTERID) AS EINVOICECOUNT", "", "EINVOICEENTRY", " AND CMPID =" & CmpId)
            If DT.Rows.Count > 0 Then USEDEINVOICECOUNTER = Val(DT.Rows(0).Item("EINVOICECOUNT"))

            'IF COUNTERS ARE FINISJED
            If CMPEINVOICECOUNTER - USEDEINVOICECOUNTER <= 0 Then
                MsgBox("E-Invoice Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'IF DATE HAS EXPIRED
            If Now.Date > EINVOICEEXPDATE Then
                MsgBox("E-Invoice Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'IF BALANCECOUNTERS ARE .10 THEN INTIMATE
            If CMPEINVOICECOUNTER - USEDEINVOICECOUNTER < Format((CMPEINVOICECOUNTER * 0.1), "0") Then
                MsgBox("Only " & (CMPEINVOICECOUNTER - USEDEINVOICECOUNTER) & " API's Left, Kindly contact Nakoda Infotech for Renewal of E-Invoice Package", MsgBoxStyle.Critical)
            End If


            'FOR GENERATING EINVOICE BILL WE NEED TO FIRST GENERATE THE TOKEN
            'THIS IS FOR SANDBOX TEST
            'Dim URL As New Uri("http://gstsandbox.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=34AACCC1596Q002&user_name=TaxProEnvPON&eInvPwd=abc34*")
            Dim URL As New Uri("https://einvapi.charteredinfo.com/eivital/dec/v1.04/auth?aspid=1602611918&password=infosys123&Gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&eInvPwd=" & CMPEWBPASS)

            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Dim REQUEST As WebRequest
            Dim RESPONSE As WebResponse
            REQUEST = WebRequest.CreateDefault(URL)

            REQUEST.Method = "GET"
            Try
                RESPONSE = REQUEST.GetResponse()
            Catch ex As WebException
                RESPONSE = ex.Response
            End Try
            Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
            Dim REQUESTEDTEXT As String = READER.ReadToEnd()

            'IF STATUS IS NOT 1 THEN TOKEN IS NOT GENERATED
            Dim STARTPOS As Integer = 0
            Dim TEMPSTATUS As String = ""
            Dim TOKEN As String = ""
            Dim ENDPOS As Integer = 0

            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 2
            TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
            If TEMPSTATUS = "1" Then TEMPSTATUS = "SUCCESS" Else TEMPSTATUS = "FAILED"




            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("authtoken") + Len("AUTHTOKEN") + 3
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS) - 1
            TOKEN = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            'ADD DATA IN EINVOICEENTRY
            'DONT ADD IN EINVOICEENTRY, DONE BY GULKIT, IF FAILED THEN ADD
            'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


            'ONCE WE REC THE TOKEN WE WILL CREATE EWAY BILL
            'IF STATUS IS FAILED THEN ERROR MESSAGE
            If TEMPSTATUS = "FAILED" Then
                MsgBox("Unable to create Eway Bill", MsgBoxStyle.Critical)
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "','" & REQUESTEDTEXT & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                Exit Sub
            End If

            Dim j As String = ""
            Dim PRINTINITIALS As String = ""

            'GENERATING EINVOICE
            'FOR SANBOX TEST
            'Dim FURL As New Uri("http://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice?aspid=1602611918&password=infosys123&Gstin=34AACCC1596Q002&AuthToken=" & TOKEN & "&user_name=TaxProEnvPON&QrCodeSize=250")
            Dim FURL As New Uri("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice?aspid=1602611918&password=infosys123&Gstin=" & CMPGSTIN & "&AuthToken=" & TOKEN & "&user_name=" & CMPEWBUSER & "&QrCodeSize=250")
            REQUEST = WebRequest.CreateDefault(FURL)
            REQUEST.Method = "POST"
            Try
                REQUEST.ContentType = "application/json"



                j = "{"
                j = j & """Version"": ""1.1"","
                j = j & """TranDtls"": {"
                j = j & """TaxSch"":""GST"","

                If PARTYSEZ = "SEZ" Then
                    j = j & """SupTyp"":""SEZWP"","
                ElseIf CHKEXPORTGST.Checked = True Then
                    j = j & """SupTyp"":""EXPWP"","
                Else
                    j = j & """SupTyp"":""B2B"","
                End If

                j = j & """RegRev"":""N"","
                j = j & """IgstOnIntra"":""N""},"



                'WE NEED TO FETCH INITIALS INSTEAD OF BILLNO
                Dim DTINI As DataTable = OBJCMN.search("INVOICE_PRINTINITIALS AS PRINTINITIALS", "", "INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID", " AND INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId)
                PRINTINITIALS = DTINI.Rows(0).Item("PRINTINITIALS")

                j = j & """DocDtls"": {"
                j = j & """Typ"":""INV"","
                j = j & """No"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                j = j & """Dt"":""" & invoicedate.Text & """" & "},"


                'For WORKING ON SANDBOX
                'CMPGSTIN = "34AACCC1596Q002"
                'CMPPINCODE = "605001"
                'CMPSTATECODE = "34"


                j = j & """SellerDtls"": {"
                j = j & """Gstin"":""" & CMPGSTIN & """" & ","
                j = j & """LglNm"":""" & CmpName & """" & ","
                j = j & """TrdNm"":""" & CmpName & """" & ","
                j = j & """Addr1"":""" & TEMPCMPADD1.Replace(vbCrLf, " ") & """" & ","
                j = j & """Addr2"":""" & TEMPCMPADD2.Replace(vbCrLf, " ") & """" & ","
                j = j & """Loc"":""" & CMBFROMCITY.Text.Trim & """" & ","
                j = j & """Pin"":" & CMPPINCODE & "" & ","
                j = j & """Stcd"":""" & CMPSTATECODE & """" & "},"

                If PARTYADD1 = "" Then PARTYADD1 = PARTYSTATENAME
                If PARTYADD2 = "" Then PARTYADD2 = PARTYSTATENAME

                j = j & """BuyerDtls"": {"
                j = j & """Gstin"":""" & PARTYGSTIN & """" & ","
                j = j & """LglNm"":""" & CMBNAME.Text.Trim & """" & ","
                j = j & """TrdNm"":""" & CMBNAME.Text.Trim & """" & ","
                j = j & """Pos"":""" & PARTYSTATECODE & """" & ","
                j = j & """Addr1"":""" & PARTYADD1.Replace(vbCrLf, " ") & """" & ","
                j = j & """Addr2"":""" & PARTYADD2.Replace(vbCrLf, " ") & """" & ","
                j = j & """Loc"":""" & CMBTOCITY.Text.Trim & """" & ","
                j = j & """Pin"":" & PARTYPINCODE & "" & ","
                j = j & """Stcd"":""" & PARTYSTATECODE & """" & "},"


                j = j & """DispDtls"": {"
                j = j & """Nm"":""" & CmpName & """" & ","
                j = j & """Addr1"":""" & TEMPCMPADD1.Replace(vbCrLf, " ") & """" & ","
                j = j & """Addr2"":""" & TEMPCMPADD2.Replace(vbCrLf, " ") & """" & ","
                j = j & """Loc"":""" & CMBFROMCITY.Text.Trim & """" & ","
                j = j & """Pin"":" & CMPPINCODE & "" & ","
                j = j & """Stcd"":""" & CMPSTATECODE & """" & "},"

                j = j & """ShipDtls"": {"
                If SHIPTOGSTIN <> "" Then j = j & """Gstin"":""" & SHIPTOGSTIN & """" & ","
                j = j & """LglNm"":""" & txtname.Text.Trim & """" & ","
                j = j & """TrdNm"":""" & txtname.Text.Trim & """" & ","
                If SHIPTOADD1 = "" Then j = j & """Addr1"":""" & PARTYADD1.Replace(vbCrLf, " ") & """" & "," Else j = j & """Addr1"":""" & SHIPTOADD1.Replace(vbCrLf, " ") & """" & ","
                If SHIPTOADD2 = "" Then SHIPTOADD2 = " ADDRESS2 "
                j = j & """Addr2"":""" & SHIPTOADD2 & """" & ","
                j = j & """Loc"":""" & CMBTOCITY.Text.Trim & """" & ","
                If SHIPTOPINCODE = "" Then j = j & """Pin"":" & PARTYPINCODE & "" & "," Else j = j & """Pin"":" & SHIPTOPINCODE & "" & ","
                j = j & """Stcd"":""" & SHIPTOSTATECODE & """" & "},"


                j = j & """ItemList"":[{"



                Dim TEMPLINEDISC As Double = 0
                Dim TEMPLINETAXABLEAMT As Double = 0
                Dim TEMPLINECGSTAMT As Double = 0
                Dim TEMPLINESGSTAMT As Double = 0
                Dim TEMPLINEIGSTAMT As Double = 0
                Dim TEMPLINEGRIDTOTALAMT As Double = 0
                Dim TEMPLINECHARGES As Double = 0
                Dim TEMPRATE As Double = 0
                'If Val(LBLTOTALOTHERAMT.Text.Trim) < 0 Then
                '    TEMPLINEDISC = Format(Val(LBLTOTALOTHERAMT.Text.Trim) / Val(LBLTOTALQTY.Text.Trim), "0.0000")
                'Else
                '    TEMPRATE = Format(Val(LBLTOTALOTHERAMT.Text.Trim) / Val(LBLTOTALQTY.Text.Trim), "0.0000")
                'End If


                Dim TEMPTOTALAMT As Double = 0
                Dim TEMPTOTALDISC As Double = 0
                Dim TEMPTOTALTAXABLEAMT As Double = 0
                Dim TEMPTOTALCGSTAMT As Double = 0
                Dim TEMPTOTALSGSTAMT As Double = 0
                Dim TEMPTOTALIGSTAMT As Double = 0
                Dim TEMPGTOTALAMT As Double = 0
                Dim TEMPSRNO As Integer = 0

                'WE NEED TO FETCH ALL ITEMS HERE
                'FETCH FROM DESC TABLE 
                DT = OBJCMN.Execute_Any_String(" SELECT  ISNULL(ITEMMASTER.ITEM_NAME,'') AS ITEMNAME, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER, ISNULL(INVOICEMASTER_DESC.INVOICE_QTY,0) AS PCS, 'NOS' AS PER, ISNULL(INVOICEMASTER_DESC.INVOICE_RATE,0) AS RATE, ISNULL(INVOICEMASTER_DESC.INVOICE_AMT,0) AS TOTALAMT, ISNULL(INVOICEMASTER_DESC.INVOICE_OTHERAMT,0) AS LINEDISC, ISNULL(INVOICEMASTER_DESC.INVOICE_TAXABLEAMT,0) AS LINETAXABLEAMT, ISNULL(INVOICEMASTER_DESC.INVOICE_CGSTAMT,0) AS LINECGSTAMT, ISNULL(INVOICEMASTER_DESC.INVOICE_SGSTAMT,0) AS LINESGSTAMT, ISNULL(INVOICEMASTER_DESC.INVOICE_IGSTAMT,0) AS LINEIGSTAMT, ISNULL(INVOICEMASTER_DESC.INVOICE_GRIDTOTAL,0) AS LINEGRIDTOTAL, ISNULL(HSN_TYPE,'Goods') HSNTYPE FROM INVOICEMASTER INNER JOIN INVOICEMASTER_DESC ON INVOICEMASTER.INVOICE_NO = INVOICEMASTER_DESC.INVOICE_NO AND INVOICEMASTER.INVOICE_REGISTERID = INVOICEMASTER_DESC.INVOICE_REGISTERID AND INVOICEMASTER.INVOICE_YEARID = INVOICEMASTER_DESC.INVOICE_YEARID INNER JOIN ITEMMASTER ON INVOICEMASTER_DESC.INVOICE_ITEMNAMEID = ITEMMASTER.ITEM_ID INNER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTER_ID WHERE INVOICEMASTER.INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' and INVOICEMASTER.INVOICE_YEARID = " & YearId, "", "")
                Dim CURRROW As Integer = 0
                For Each DTROW As DataRow In DT.Rows

                    TEMPSRNO += 1

                    'GET HSNCODE AND HSN DETAILS WITH RESPECT TO EWBHSN
                    Dim DTHSN As DataTable = OBJCMN.search("ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER, ISNULL(HSN_EXPCGST,0) AS EXPCGSTPER, ISNULL(HSN_EXPSGST,0) AS EXPSGSTPER, ISNULL(HSN_EXPIGST,0) AS EXPIGSTPER, ISNULL(HSN_TYPE,'Goods') HSNTYPE", "", " HSNMASTER ", " AND HSN_CODE = '" & CMBHSNCODE.Text.Trim & "' AND HSN_YEARID = " & YearId)
                    If DTHSN.Rows.Count > 0 Then
                        DTROW("HSNCODE") = DTHSN.Rows(0).Item("HSNCODE")
                        DTROW("CGSTPER") = Val(DTHSN.Rows(0).Item("CGSTPER"))
                        DTROW("SGSTPER") = Val(DTHSN.Rows(0).Item("SGSTPER"))
                        DTROW("IGSTPER") = Val(DTHSN.Rows(0).Item("IGSTPER"))
                        DTROW("HSNTYPE") = DTHSN.Rows(0).Item("HSNTYPE")
                    End If


                    If PARTYSEZ = "SEZ" Then
                        DTROW("CGSTPER") = 0
                        DTROW("SGSTPER") = 0
                        DTROW("IGSTPER") = 0
                    End If

                    'FOR EXPORT
                    If CHKEXPORTGST.Checked = True Then
                        DTROW("CGSTPER") = DTHSN.Rows(0).Item("EXPCGSTPER")
                        DTROW("SGSTPER") = DTHSN.Rows(0).Item("EXPSGSTPER")
                        DTROW("IGSTPER") = DTHSN.Rows(0).Item("EXPIGSTPER")
                    End If


                    'TEMPLINECHARGES = Format(Val(TEMPLINEDISC) * Val(DTROW("PCS")), "0.00")
                    'TEMPLINETAXABLEAMT = Format(Val(DTROW("TOTALAMT")) + Val(TEMPLINECHARGES), "0.00")
                    'TEMPLINECGSTAMT = Format(Val(TXTCGSTPER1.Text.Trim) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                    'TEMPLINESGSTAMT = Format(Val(TXTSGSTPER1.Text.Trim) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                    'TEMPLINEIGSTAMT = Format(Val(TXTIGSTPER1.Text.Trim) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                    'TEMPLINEGRIDTOTALAMT = Format(Val(TEMPLINETAXABLEAMT + TEMPLINECGSTAMT + TEMPLINESGSTAMT + TEMPLINEIGSTAMT), "0.00")

                    If CURRROW > 0 Then j = j & ", {"
                    j = j & """SlNo"": """ & TEMPSRNO & """" & ","
                    j = j & """PrdDesc"":""" & DTROW("ITEMNAME") & """" & ","
                    If DTROW("HSNTYPE") = "Goods" Then j = j & """IsServc"":""" & "N" & """" & "," Else j = j & """IsServc"":""" & "Y" & """" & ","
                    j = j & """HsnCd"":""" & DTROW("HSNCODE") & """" & ","
                    j = j & """Barcde"":""REC9999"","
                    j = j & """Qty"":" & Val(DTROW("PCS")) & "" & ","
                    j = j & """FreeQty"":" & "0" & "" & ","
                    j = j & """Unit"":""" & "NOS" & """" & ","


                    If Val(DTROW("LINEDISC")) <= 0 Then

                        j = j & """UnitPrice"":" & Val(DTROW("RATE")) & "" & ","
                        j = j & """TotAmt"":" & Format(Val(DTROW("TOTALAMT")), "0.00") & "" & ","
                        j = j & """Discount"":" & Val(DTROW("LINEDISC")) * -1 & "" & ","
                        j = j & """PreTaxVal"":" & "1" & "" & ","
                        j = j & """AssAmt"":" & Val(DTROW("LINETAXABLEAMT")) & "" & ","
                        j = j & """GstRt"":" & Val(DTROW("IGSTPER")) & "" & ","
                        j = j & """IgstAmt"":" & Val(DTROW("LINEIGSTAMT")) & "" & ","
                        j = j & """CgstAmt"":" & Val(DTROW("LINECGSTAMT")) & "" & ","
                        j = j & """SgstAmt"":" & Val(DTROW("LINESGSTAMT")) & "" & ","

                        j = j & """CesRt"":" & "0" & "" & ","
                        j = j & """CesAmt"":" & "0" & "" & ","
                        j = j & """CesNonAdvlAmt"":" & "0" & "" & ","
                        j = j & """StateCesRt"":" & "0" & "" & ","
                        j = j & """StateCesAmt"":" & "0" & "" & ","
                        j = j & """StateCesNonAdvlAmt"":" & "0" & "" & ","
                        j = j & """OthChrg"":" & "0" & "" & ","

                        j = j & """TotItemVal"":" & Val(DTROW("LINEGRIDTOTAL")) & "" & ","
                        j = j & """OrdLineRef"":"" "","
                        j = j & """OrgCntry"":""IN"","
                        j = j & """PrdSlNo"":""123"","

                        j = j & """BchDtls"": {"
                        j = j & """Nm"":""123"","
                        j = j & """Expdt"":""" & invoicedate.Text & """" & ","
                        j = j & """wrDt"":""" & invoicedate.Text & """" & "},"

                        j = j & """AttribDtls"": [{"
                        j = j & """Nm"":""" & DTROW("ITEMNAME") & """" & ","
                        j = j & """Val"":""" & Val(DTROW("LINEGRIDTOTAL")) & """" & "}]"

                    Else
                        TEMPRATE = Val(DTROW("LINEDISC")) / Val(DTROW("PCS"))
                        j = j & """UnitPrice"":" & Format(Val(DTROW("RATE")) + TEMPRATE, "0.000") & "" & ","

                        TEMPLINETAXABLEAMT = Format(Val(Val(DTROW("RATE")) + TEMPRATE) * Val(DTROW("PCS")), "0.00")

                        If PARTYSTATECODE = CMPSTATECODE Then
                            TEMPLINECGSTAMT = Format(Val(DTROW("CGSTPER")) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                            TEMPLINESGSTAMT = Format(Val(DTROW("SGSTPER")) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                            TEMPLINEIGSTAMT = 0
                        Else
                            TEMPLINECGSTAMT = 0
                            TEMPLINESGSTAMT = 0
                            TEMPLINEIGSTAMT = Format(Val(DTROW("IGSTPER")) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                        End If
                        TEMPLINEGRIDTOTALAMT = Format(Val(TEMPLINETAXABLEAMT + TEMPLINECGSTAMT + TEMPLINESGSTAMT + TEMPLINEIGSTAMT), "0.00")

                        j = j & """TotAmt"":" & Val(TEMPLINETAXABLEAMT) & "" & ","
                        j = j & """Discount"":" & "0" & "" & ","
                        j = j & """PreTaxVal"":" & "1" & "" & ","
                        j = j & """AssAmt"":" & Val(TEMPLINETAXABLEAMT) & "" & ","
                        j = j & """GstRt"":" & Val(DTROW("IGSTPER")) & "" & ","
                        j = j & """IgstAmt"":" & Val(TEMPLINEIGSTAMT) & "" & ","
                        j = j & """CgstAmt"":" & Val(TEMPLINECGSTAMT) & "" & ","
                        j = j & """SgstAmt"":" & Val(TEMPLINESGSTAMT) & "" & ","
                        j = j & """CesRt"":" & "0" & "" & ","
                        j = j & """CesAmt"":" & "0" & "" & ","
                        j = j & """CesNonAdvlAmt"":" & "0" & "" & ","
                        j = j & """StateCesRt"":" & "0" & "" & ","
                        j = j & """StateCesAmt"":" & "0" & "" & ","
                        j = j & """StateCesNonAdvlAmt"":" & "0" & "" & ","
                        j = j & """OthChrg"":" & "0" & "" & ","
                        j = j & """TotItemVal"":" & Val(TEMPLINEGRIDTOTALAMT) & "" & ","
                        j = j & """OrdLineRef"":"" "","
                        j = j & """OrgCntry"":""IN"","
                        j = j & """PrdSlNo"":""123"","

                        j = j & """BchDtls"": {"
                        j = j & """Nm"":""123"","
                        j = j & """Expdt"":""" & invoicedate.Text & """" & ","
                        j = j & """wrDt"":""" & invoicedate.Text & """" & "},"

                        j = j & """AttribDtls"": [{"
                        j = j & """Nm"":""" & DTROW("ITEMNAME") & """" & ","
                        j = j & """Val"":""" & Val(TEMPLINEGRIDTOTALAMT) & """" & "}]"
                    End If



                    j = j & " }"
                    CURRROW += 1


                    'THESE VARIABLES ARE JUST FOR TESTING PURPOSE
                    TEMPTOTALAMT += Val(DTROW("TOTALAMT"))
                    TEMPTOTALDISC += Val(TEMPLINECHARGES)
                    TEMPTOTALTAXABLEAMT += Val(TEMPLINETAXABLEAMT)
                    TEMPTOTALCGSTAMT += Val(TEMPLINECGSTAMT)
                    TEMPTOTALSGSTAMT += Val(TEMPLINESGSTAMT)
                    TEMPTOTALIGSTAMT += Val(TEMPLINEIGSTAMT)
                    TEMPGTOTALAMT += Val(TEMPLINEGRIDTOTALAMT)


                Next

                j = j & " ],"



                j = j & """ValDtls"": {"
                j = j & """AssVal"":" & Val(LBLTOTALTAXABLEAMT.Text.Trim) & "" & ","
                j = j & """CgstVal"":" & Val(LBLTOTALCGSTAMT.Text.Trim) & "" & ","
                j = j & """SgstVal"":" & Val(LBLTOTALSGSTAMT.Text.Trim) & "" & ","
                j = j & """IgstVal"":" & Val(LBLTOTALIGSTAMT.Text.Trim) & "" & ","

                j = j & """CesVal"":" & "0" & "" & ","
                j = j & """StCesVal"":" & "0" & "" & ","
                j = j & """Discount"":" & "0" & "" & ","
                j = j & """OthChrg"":" & Val(TXTTCSAMT.Text.Trim) & "" & ","
                j = j & """RndOffAmt"":" & Val(txtroundoff.Text.Trim) & "" & ","
                j = j & """TotInvVal"":" & Val(txtgrandtotal.Text.Trim) & "" & ","
                j = j & """TotInvValFc"":" & "0" & "" & "},"


                j = j & """PayDtls"": {"
                j = j & """Nm"":"" "","
                j = j & """Accdet"":"" "","
                j = j & """Mode"":""Credit"","
                j = j & """Fininsbr"":"" "","
                j = j & """Payterm"":"" "","
                j = j & """Payinstr"":"" "","
                j = j & """Crtrn"":"" "","
                j = j & """Dirdr"":"" "","
                j = j & """Crday"":" & Val(TXTCRDAYS.Text.Trim) & "" & ","
                j = j & """Paidamt"":" & "0" & "" & ","
                j = j & """Paymtdue"":" & Val(txtgrandtotal.Text.Trim) & "" & "},"


                j = j & """RefDtls"": {"
                j = j & """InvRm"":""TEST"","
                j = j & """DocPerdDtls"": {"
                j = j & """InvStDt"":""" & invoicedate.Text & """" & ","
                j = j & """InvEndDt"":""" & invoicedate.Text & """" & "},"

                j = j & """PrecDocDtls"": [{"
                j = j & """InvNo"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                j = j & """InvDt"":""" & invoicedate.Text & """" & ","
                j = j & """OthRefNo"":"" ""}],"

                j = j & """ContrDtls"": [{"
                j = j & """RecAdvRefr"":"" "","
                j = j & """RecAdvDt"":""" & invoicedate.Text & """" & ","
                j = j & """Tendrefr"":"" "","
                j = j & """Contrrefr"":"" "","
                j = j & """Extrefr"":"" "","
                j = j & """Projrefr"":"" "","
                j = j & """Porefr"":"" "","
                j = j & """PoRefDt"":""" & invoicedate.Text & """" & "}]"
                j = j & "},"




                j = j & """AddlDocDtls"": [{"
                j = j & """Url"":""https://einv-apisandbox.nic.in"","
                j = j & """Docs"":""INVOICE"","
                j = j & """Info"":""INVOICE""}],"




                j = j & """ExpDtls"": {"
                j = j & """ShipBNo"":"" "","
                j = j & """ShipBDt"":""" & invoicedate.Text & """" & ","
                j = j & """Port"":""INBOM1"","
                j = j & """RefClm"":""N"","
                j = j & """ForCur"":""AED"","
                j = j & """CntCode"":""AE""}"


                'THIS CODE IS WRITTEN COZ WHEN BILLTO AND SHIPTO ARE IN THE SAME PINCODE THEN WE HAVE TO PASS MINIMUM 10 KMS
                'OR ELSE IT WILL GIVE ERROR
                If CMPPINCODE = PARTYPINCODE Then PARTYKMS = 10

                If TXTVEHICLENO.Text.Trim <> "" Then
                    j = j & ","
                    j = j & """EwbDtls"": {"
                    j = j & """TransId"":""" & TRANSGSTIN & """" & ","
                    j = j & """TransName"":""" & TXTTRANSNAME.Text.Trim & """" & ","
                    j = j & """Distance"":""" & PARTYKMS & """" & ","
                    j = j & """TransDocNo"":""" & TXTLRNO.Text.Trim & """" & ","
                    j = j & """TransDocDt"":"""","
                    j = j & """VehNo"":""" & TXTVEHICLENO.Text.Trim & """" & ","
                    j = j & """VehType"":""" & "R" & """" & ","
                    j = j & """TransMode"":""1""" & "}"
                End If

                j = j & "}"


                Dim stream As Stream = REQUEST.GetRequestStream()
                Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(j)
                stream.Write(buffer, 0, buffer.Length)

                'POST request absenden
                RESPONSE = REQUEST.GetResponse()







            Catch ex As WebException
                'RESPONSE = ex.Response
                'MsgBox("Error While Generating EWB, Please check the Data Properly")
                ''ADD DATA IN EINVOICEENTRY
                'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','FAILED', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

                RESPONSE = ex.Response
                READER = New StreamReader(RESPONSE.GetResponseStream())
                REQUESTEDTEXT = READER.ReadToEnd()
                GoTo ERRORMESSAGE
            End Try

            READER = New StreamReader(RESPONSE.GetResponseStream())
            REQUESTEDTEXT = READER.ReadToEnd()


            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 3
            TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
            If TEMPSTATUS = "1" Then
                TEMPSTATUS = "SUCCESS"
                MsgBox("E-Invoice Generated Successfully ")

            Else

ERRORMESSAGE:
                TEMPSTATUS = "FAILED"

                Dim ERRORMSG As String = ""
                STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ErrorMessage") + Len("ErrorMessage") + 5
                ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("""", STARTPOS) - 2
                ERRORMSG = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

                'ADD DATA IN EINVOICEENTRY
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','FAILED','" & REQUESTEDTEXT & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

                MsgBox("Error While Generating E-Invoice, " & REQUESTEDTEXT)

                Exit Sub
            End If


            Dim IRNNO As String = ""
            Dim ACKNO As String = ""
            Dim ADATE As String = ""


            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ackno") + Len("ACKNO") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("\", STARTPOS)
            ACKNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            TXTACKNO.Text = ACKNO


            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ackdt") + Len("ACKDT") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("\", STARTPOS)
            ADATE = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            ACKDATE.Value = ADATE

            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("irn") + Len("IRN") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("\", STARTPOS)
            IRNNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            TXTIRNNO.Text = IRNNO

            'WE NEED TO UPDATE THIS IRNNO IN DATABASE ALSO
            DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_IRNNO = '" & TXTIRNNO.Text.Trim & "' FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")

            'ADD DATA IN EINVOICEENTRY
            DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','" & IRNNO & "','" & TEMPSTATUS & "', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


            'ADD DATA IN EINVOICEENTRY FOR QRCODE
            If TEMPSTATUS = "SUCCESS" Then

                ''GET SIGNED QRCODE
                Dim req As New RestRequest
                req.AddParameter("application/json", j, RestSharp.ParameterType.RequestBody)
                'Dim client As New RestClient("http://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=34AACCC1596Q002&user_name=TaxProEnvPON&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim client As New RestClient("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice/irn/" & TXTIRNNO.Text.Trim & "?aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&user_name=" & CMPEWBUSER & "&AuthToken=" & TOKEN & "&QrCodeSize=250")
                Dim res As IRestResponse = Await client.ExecuteTaskAsync(req)
                Dim respPl = New RespPl()
                respPl = JsonConvert.DeserializeObject(Of RespPl)(res.Content)
                Dim respPlGenIRNDec As New RespPlGenIRNDec()
                respPlGenIRNDec = JsonConvert.DeserializeObject(Of RespPlGenIRNDec)(respPl.Data)
                'MsgBox(respPlGenIRNDec.Irn)
                Dim qrImg As Byte() = Convert.FromBase64String(respPlGenIRNDec.QrCodeImage)
                Dim tc As TypeConverter = TypeDescriptor.GetConverter(GetType(Bitmap))
                Dim bitmap1 As Bitmap = CType(tc.ConvertFrom(qrImg), Bitmap)

                'GET REGINITIALS AS SAVE WITH IT
                Dim TEMPREG As DataTable = OBJCMN.Execute_Any_String("SELECT REGISTER_INITIALS AS INITIALS FROM REGISTERMASTER WHERE REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND REGISTER_TYPE ='SALE' AND REGISTER_YEARID = " & YearId, "", "")
                bitmap1.Save(Application.StartupPath & "\" & TEMPREG.Rows(0).Item("INITIALS") & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\" & TEMPREG.Rows(0).Item("INITIALS") & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png"
                PBQRCODE.Refresh()

                If PBQRCODE.Image IsNot Nothing Then
                    Dim OBJINVOICE As New ClsInvoicemaster
                    Dim MS As New IO.MemoryStream
                    PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    OBJINVOICE.alParaval.Add(TXTINVOICENO.Text.Trim)
                    OBJINVOICE.alParaval.Add(cmbregister.Text.Trim)
                    OBJINVOICE.alParaval.Add(MS.ToArray)
                    OBJINVOICE.alParaval.Add(YearId)
                    Dim INTRES As Integer = OBJINVOICE.SAVEQRCODE()
                End If

                'DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_QRCODE = (SELECT * FROM OPENROWSET(BULK '" & Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png',SINGLE_BLOB) AS IMG) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")


                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

            End If




            'STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("QrCodeImage\", 0) + Len("QrCodeImage\") + 5
            'ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("""", STARTPOS)
            ''Dim QRSTREAM As New MemoryStream
            ''Dim bmp As New Bitmap(QRSTREAM)
            ''bmp.Save(QRSTREAM, Drawing.Imaging.ImageFormat.Bmp)
            ''QRSTREAM.Position = STARTPOS
            ''Dim data As Byte()
            ''QRSTREAM.Read(data, STARTPOS, STARTPOS - ENDPOS)

            'Dim bytes() As Byte
            'Dim ImageInStringFormat As String = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
            'Dim MS As System.IO.MemoryStream
            'Dim NewImage As Bitmap

            'Dim nbyte() As Byte = System.Text.Encoding.UTF8.GetBytes(ImageInStringFormat)
            'Dim BASE64STRING As String = Convert.ToBase64String(nbyte)

            'bytes = Convert.FromBase64String(BASE64STRING)
            'NewImage = BytesToBitmap(bytes)
            'MS = New System.IO.MemoryStream(bytes)
            'MS.Write(bytes, 0, bytes.Length)
            'NewImage.Save(MS, Drawing.Imaging.ImageFormat.Bmp)    ' = System.Drawing.Image.FromStream(MS, True)
            'NewImage.Save("d:\qrcode.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)

            'IRNNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            ''ADD data IN EINVOICEENTRY
            'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','" & IRNNO & "','" & TEMPSTATUS & "', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKMANUAL_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHKMANUAL.CheckedChanged
        Try
            If CHKMANUAL.Checked = True Then
                GCGSTAMT.ReadOnly = False
                GSGSTAMT.ReadOnly = False
                GIGSTAMT.ReadOnly = False
            Else
                GCGSTAMT.ReadOnly = True
                GSGSTAMT.ReadOnly = True
                GIGSTAMT.ReadOnly = True

                CALC()
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridinvoice_KeyDown(sender As Object, e As KeyEventArgs) Handles gridinvoice.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridinvoice.RowCount > 0 Then
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                gridinvoice.Rows.RemoveAt(gridinvoice.CurrentRow.Index)
                TOTAL()
                getsrno(gridinvoice)


            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbstate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstate.GotFocus
        Try
            If cmbstate.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("state_name", "", "StateMaster", " and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "state_name"
                    cmbstate.DataSource = dt
                    cmbstate.DisplayMember = "state_name"
                    cmbstate.Text = ""
                End If
                cmbstate.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbstate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbstate.Validating
        Try
            If cmbstate.Text.Trim <> "" Then

                pcase(cmbstate)
                Dim objClsCommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objClsCommon.search("state_name", "", "StateMaster", " and state_name = '" & cmbstate.Text.Trim & "' and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbstate.Text.Trim
                    Dim tempmsg As Integer = MsgBox("State not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbstate.Text = a
                        objyearmaster.savestate(cmbstate.Text.Trim, CmpId, Locationid, Userid, YearId, " and state_name = '" & cmbstate.Text.Trim & "' and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbstate.DataSource
                        If cmbstate.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(cmbstate.Text)
                                cmbstate.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTRANSCITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBFROMCITY.Enter
        Try
            If CMBFROMCITY.Text.Trim = "" Then fillCITY(CMBFROMCITY, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOCITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTOCITY.Enter
        Try
            If CMBTOCITY.Text.Trim = "" Then fillCITY(CMBTOCITY, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROMCITY_Validating(sender As Object, e As CancelEventArgs) Handles CMBFROMCITY.Validating
        Try
            If CMBFROMCITY.Text.Trim <> "" Then CITYVALIDATE(CMBFROMCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOCITY_Validating(sender As Object, e As CancelEventArgs) Handles CMBTOCITY.Validating
        Try
            If CMBTOCITY.Text.Trim <> "" Then CITYVALIDATE(CMBTOCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNCODE_Validating(sender As Object, e As CancelEventArgs) Handles CMBHSNCODE.Validating
        Try
            If CMBHSNCODE.Text.Trim <> "" Then HSNITEMDESCVALIDATE(CMBHSNCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNCODE_Enter(sender As Object, e As EventArgs) Handles CMBHSNCODE.Enter
        Try
            If CMBHSNCODE.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNCODE)
        Catch ex As Exception

        End Try
    End Sub

    Sub FILLHSNITEMDESC(ByRef CMBHSNCODE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" ISNULL(HSN_CODE, '') AS HSNCODE ", "", " HSNMASTER ", " AND HSN_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "HSNCODE"
                CMBHSNCODE.DataSource = dt
                CMBHSNCODE.DisplayMember = "HSNCODE"
            End If
            CMBHSNCODE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class