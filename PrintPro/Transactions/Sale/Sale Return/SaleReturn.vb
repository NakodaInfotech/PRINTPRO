Imports BL
Imports System.IO
Imports System.ComponentModel
Imports System.Net
Imports RestSharp
Imports TaxProEInvoice.API
Imports Newtonsoft.Json

Public Class SaleReturn

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK, GRIDADJDOUBLECLICK As Boolean
    Dim GRIDUPLOADDOUBLECLICK, GRIDCHGSDOUBLECLICK As Boolean
    Public EDIT As Boolean          'used for editing
    Public TEMPSALRETNO As Integer     'used for poation no while editing
    Public USERGODOWN As String = ""
    Dim TEMPROW, TEMPCHGSROW, TEMPUPLOADROW, TEMPADJROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim PARTYCHALLANNO As String
    Dim a As Integer = 0
    Dim col As New DataGridViewCheckBoxColumn

        Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
            Try
                Me.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Sub CLEAR()
        Try
            EP.Clear()
            TXTFROM.Clear()
            TXTTO.Clear()

            If ALLOWMANUALCNDN = True Then
                TXTSALRETNO.ReadOnly = False
                TXTSALRETNO.BackColor = Color.LemonChiffon
            Else
                TXTSALRETNO.ReadOnly = True
                TXTSALRETNO.BackColor = Color.Linen
            End If
            'TXTSALRETNO.Clear()
            SALRETDATE.Text = Now.Date
            tstxtbillno.Clear()
            TXTCHALLANNO.Clear()
            CHALLANDATE.Value = Now.Date
            TXTACTUALINVNO.Clear()
            ACTUALINVDATE.Text = Now.Date
            TXTINVINITIALS.Clear()
            TXTINVNO.Clear()
            TXTINVREGNAME.Clear()
            INVDATE.Value = Now.Date
            TXTINVTYPE.Clear()
            If USERGODOWN <> "" Then cmbGodown.Text = USERGODOWN Else cmbGodown.Text = ""
            CMBNAME.Enabled = True
            CMBNAME.Text = ""
            CMBPACKING.Text = ""
            TXTCITY.Text = ""
            CMBDEBITLEDGER.Text = ""
            TXTSTATECODE.Clear()
            TXTGSTIN.Clear()
            TXTPARTYREFNO.Clear()
            TXTSRCHNO.Clear()
            txtsrno.Clear()

            txtqty.Clear()
            TXTRATE.Clear()
            TXTAMT.Text = ""
            TXTAMT.Clear()
            GRIDSALRET.RowCount = 0
            CMBAGENT.Text = ""
            txtadd.Clear()
            cmbtrans.Text = ""
            txtlrno.Clear()
            lrdate.Value = Now.Date
            txtremarks.Clear()
            TXTBILLREMARKS.Clear()
            txtuploadsrno.Clear()
            txtuploadname.Clear()
            txtuploadremarks.Clear()
            gridupload.RowCount = 0
            txtimgpath.Clear()
            TXTNEWIMGPATH.Clear()
            TXTFILENAME.Clear()
            PBSoftCopy.ImageLocation = ""
            CHKMANUALROUND.CheckState = CheckState.Unchecked
            lbllocked.Visible = False
            PBlock.Visible = False

            getmaxno()
            lbltotalqty.Text = 0
            LBLTOTALAMT.Text = 0
            LBLENVGENERATED.Visible = False
            ' CHKEXPORTGST.Checked = False
            CHKOVERSEAS.Checked = False
            TXTCGSTPER.Clear()
            TXTCGSTAMT.Clear()
            TXTSGSTPER.Clear()
            TXTSGSTAMT.Clear()
            TXTIGSTPER.Clear()
            TXTIGSTAMT.Clear()
            CHKTCS.Checked = False
            TXTTOTALWITHGST.Clear()
            TXTTCSPER.Clear()
            TXTTCSAMT.Clear()
            txtbillamt.Clear()
            TXTCHARGES.Clear()
            TXTSUBTOTAL.Clear()
            txtroundoff.Clear()
            TXTGRANDTOTAL.Clear()
            CHKMANUAL.CheckState = CheckState.Unchecked
            CHKCD.CheckState = CheckState.Unchecked
            CHKEXPORTGST.CheckState = CheckState.Unchecked

            If GRIDSALRET.RowCount > 0 Then
                txtsrno.Text = Val(GRIDSALRET.Rows(GRIDSALRET.RowCount - 1).Cells(0).Value) + 1
            Else
                txtsrno.Text = 1
            End If

            If gridupload.RowCount > 0 Then
                txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
            Else
                txtuploadsrno.Text = 1
            End If

            TXTCHGSSRNO.Text = 1
            CMBCHARGES.Text = ""
            TXTCHGSPER.Clear()
            TXTCHGSAMT.Clear()

            TXTEWAYBILLNO.Clear()
            TXTCHQBAL.Clear()
            CMBPAYTYPE.SelectedIndex = 0
            CMBBILLNO.Text = ""
            LBLBILLTOTAL.Text = ""
            TXTNARR.Clear()
            TXTADJAMT.Clear()
            TXTADJTOTAL.Clear()
            TXTINVTOTAL.Clear()

            GRIDBILL.DataSource = Nothing
            TXTADJSRNO.Text = 1
            TXTIRNNO.Clear()
            TXTACKNO.Clear()
            ACKDATE.Value = Mydate
            PBQRCODE.Image = Nothing
            TXTSPECIALREMARKS.Clear()
            LBLWHATSAPP.Visible = False

            CMBITEMCODE.Text = ""
            TXTNOOFPACKETS.Clear()
            TXTPACKETS.Clear()
            TXTSHIPPERS.Clear()
            TXTBATCHNO.Clear()

            'GRIDSALRET.RowCount = 0
            'gridupload.RowCount = 0
            GRIDCHGS.RowCount = 0
            GRIDPAYMENT.RowCount = 0
            GRIDBILL.RowCount = 0

            GRIDDOUBLECLICK = False
            GRIDADJDOUBLECLICK = False
            GRIDUPLOADDOUBLECLICK = False
            GRIDCHGSDOUBLECLICK = False

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            'LBLTOTALMTRS.Text = 0.0
            'LBLTOTALWT.Text = 0.0
            lbltotalqty.Text = 0.0
            LBLTOTALAMT.Text = 0.0

            txtbillamt.Text = 0.0
            TXTCHARGES.Text = 0.0
            TXTSUBTOTAL.Text = 0
            If CHKMANUALROUND.CheckState = CheckState.Unchecked Then txtroundoff.Text = 0
            TXTGRANDTOTAL.Text = 0

            TXTINVTOTAL.Text = 0.0
            TXTADJTOTAL.Text = 0.0
            TXTCHQBAL.Text = 0.0

            TXTTCSPER.Text = 0
            TXTTCSAMT.Text = 0

            'FETCH TCSPERCENT WITH RESPECT TO DATE
            Dim OBJCMN As New ClsCommon
            Dim DTTCS As DataTable = OBJCMN.search("TOP 1 ISNULL(TCSPER,0) AS TCSPER", "", "TCSPERCENT", " AND TCSDATE <= '" & Format(Convert.ToDateTime(SALRETDATE.Text).Date, "MM/dd/yyyy") & "' ORDER BY TCSDATE DESC")
            If DTTCS.Rows.Count > 0 Then TXTTCSPER.Text = Val(DTTCS.Rows(0).Item("TCSPER"))


            For Each ROW As DataGridViewRow In GRIDSALRET.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    If Val(ROW.Cells(GRATE.Index).EditedFormattedValue) > 0 Then
                        'If ROW.Cells(GPER.Index).Value = "Mtrs" Then
                        '    ROW.Cells(GAMT.Index).Value = Format(Val(ROW.Cells(GMTRS.Index).EditedFormattedValue * ROW.Cells(GRATE.Index).EditedFormattedValue), "0.00")
                        'Else
                        ROW.Cells(GAMT.Index).Value = Format(Val(ROW.Cells(gQty.Index).EditedFormattedValue * ROW.Cells(GRATE.Index).EditedFormattedValue), "0.00")
                        'End If
                    End If
                    'If ROW.Cells(gcut.Index).EditedFormattedValue > 0 Then ROW.Cells(GMTRS.Index).Value = ROW.Cells(gQty.Index).EditedFormattedValue * ROW.Cells(gcut.Index).EditedFormattedValue
                    If Val(ROW.Cells(GAMT.Index).Value) <> 0 Then txtbillamt.Text = Format(Val(txtbillamt.Text) + Val(ROW.Cells(GAMT.Index).EditedFormattedValue), "0.00")

                    lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(ROW.Cells(gQty.Index).EditedFormattedValue), "0.00")
                    'LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    'LBLTOTALWT.Text = Format(Val(LBLTOTALWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")
                    LBLTOTALAMT.Text = Format(Val(LBLTOTALAMT.Text) + Val(ROW.Cells(GAMT.Index).EditedFormattedValue), "0.00")
                End If
            Next


            If GRIDCHGS.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDCHGS.Rows
                    If SALEAUTODISCOUNT = True And ClientName <> "YASHVI" Then
                        'IF PERCENT IS > 0 THEN GETAUTO CHARGES
                        Dim dt As DataTable = OBJCMN.search("ISNULL(ACC_CALC,'GROSS') AS CALC", "", "LEDGERS", "AND ACC_CMPNAME = '" & row.Cells(ECHARGES.Index).Value & "' AND ACC_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            If dt.Rows(0).Item("CALC") = "GROSS" And Val(row.Cells(EPER.Index).Value) <> 0 Then
                                row.Cells(EAMT.Index).Value = Format((Val(row.Cells(EPER.Index).Value) * Val(txtbillamt.Text.Trim)) / 100, "0.00")
                            ElseIf dt.Rows(0).Item("CALC") = "NETT" And Val(row.Cells(EPER.Index).Value) <> 0 Then
                                TXTNETTAMT.Text = Val(txtbillamt.Text.Trim)
                                For I As Integer = 0 To row.Index - 1
                                    TXTNETTAMT.Text = Format(Val(TXTNETTAMT.Text) + Val(GRIDCHGS.Rows(I).Cells(EAMT.Index).Value), "0.00")
                                Next
                                row.Cells(EAMT.Index).Value = Format((Val(row.Cells(EPER.Index).Value) * Val(TXTNETTAMT.Text.Trim)) / 100, "0.00")
                                'TXTCHGSAMT.Text = Format((Val(TXTNETT.Text) * Val(TXTCHGSPER.Text)) / 100, "0.00")
                                'ElseIf dt.Rows(0).Item("CALC") = "MTRS" And Val(row.Cells(EPER.Index).Value) <> 0 Then
                                '    row.Cells(EAMT.Index).Value = Format(Val(row.Cells(EPER.Index).Value) * Val(LBLTOTALMTRS.Text.Trim), "0.00")
                                'ElseIf dt.Rows(0).Item("CALC") = "PCS" And Val(row.Cells(EPER.Index).Value) <> 0 Then
                                row.Cells(EAMT.Index).Value = Format(Val(row.Cells(EPER.Index).Value) * Val(lbltotalqty.Text.Trim), "0.00")
                            End If
                        End If
                    End If
                    TXTCHARGES.Text = Format(Val(TXTCHARGES.Text) + Val(row.Cells(EAMT.Index).Value), "0.00")
                Next
            End If

            TXTSUBTOTAL.Text = Format(Val(txtbillamt.Text) + Val(TXTCHARGES.Text.Trim), "0.00")

            If CHKMANUAL.CheckState = CheckState.Unchecked Then
                TXTCGSTAMT.Text = Format((Val(TXTSUBTOTAL.Text.Trim) * Val(TXTCGSTPER.Text.Trim)) / 100, "0.00")
                TXTSGSTAMT.Text = Format((Val(TXTSUBTOTAL.Text.Trim) * Val(TXTSGSTPER.Text.Trim)) / 100, "0.00")
                TXTIGSTAMT.Text = Format((Val(TXTSUBTOTAL.Text.Trim) * Val(TXTIGSTPER.Text.Trim)) / 100, "0.00")
            End If

            TXTTOTALWITHGST.Text = Format(Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim), "0.00")
            If CHKTCS.CheckState = CheckState.Checked Then TXTTCSAMT.Text = Format((Val(TXTTOTALWITHGST.Text.Trim) * Val(TXTTCSPER.Text.Trim)) / 100, "0")
            If CHKMANUALROUND.Checked = False Then
                TXTGRANDTOTAL.Text = Format(Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim) + Val(TXTTCSAMT.Text.Trim), "0")
                txtroundoff.Text = Format(Val(TXTGRANDTOTAL.Text) - (Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim) + Val(TXTTCSAMT.Text.Trim)), "0.00")
            Else
                TXTGRANDTOTAL.Text = Format(Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim) + Val(TXTTCSAMT.Text.Trim) + Val(txtroundoff.Text.Trim), "0.00")
            End If
            If Val(TXTGRANDTOTAL.Text) > 0 Then txtinwords.Text = CurrencyToWord(TXTGRANDTOTAL.Text)

            For Each row As DataGridViewRow In GRIDPAYMENT.Rows
                TXTADJTOTAL.Text = Format(Val(TXTADJTOTAL.Text) + row.Cells(GADJAMT.Index).Value, "0.00")
            Next

            For Each row As DataGridViewRow In GRIDBILL.Rows
                If Convert.ToBoolean(row.Cells("INVCHK").Value) = True Then TXTINVTOTAL.Text = Format(Val(TXTINVTOTAL.Text) + row.Cells(GRIDBILL.Columns("INVBALAMT").Index).Value, "0.00")
            Next

            If Val(TXTGRANDTOTAL.Text) > 0 Then TXTCHQBAL.Text = Format(Val(TXTGRANDTOTAL.Text) - Val(TXTADJTOTAL.Text), "0.00")

            'GET ADJAMT
            TXTADJAMT.Text = Val(TXTCHQBAL.Text.Trim)


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMBBILLNO()
        If CMBBILLNO.Items.Count > 0 Then CMBBILLNO.Items.Clear()
        For Each row As DataGridViewRow In GRIDBILL.Rows
            If Convert.ToBoolean(row.Cells(GRIDBILL.Columns("INVCHK").Index).Value) = True Then
                CMBBILLNO.Items.Add(row.Cells(GRIDBILL.Columns("INVBILLINITIALS").Index).Value.ToString())
            End If
        Next
        If CMBBILLNO.Items.Count > 0 Then CMBBILLNO.SelectedIndex = (0)
    End Sub

    Function AMOUNTVALIDATE() As Boolean
        Try
            Dim BLN As Boolean = True
            If EDIT = False Then
                If GRIDADJDOUBLECLICK = False Then
                    'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                    If (Val(TXTADJTOTAL.Text.Trim) + Val(TXTADJAMT.Text)) > Val(TXTGRANDTOTAL.Text) Then
                        EP.SetError(TXTADJAMT, "Amount Exceeds Specified Amt.")
                        BLN = False
                    End If
                Else
                    'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                    If ((Val(TXTADJTOTAL.Text.Trim) + Val(TXTADJAMT.Text)) - Val(GRIDPAYMENT.Item(GADJAMT.Index, TEMPADJROW).Value)) > Val(TXTGRANDTOTAL.Text) Then
                        EP.SetError(TXTADJAMT, "Amount Exceeds Specified Amt.")
                        BLN = False
                    End If

                    If CMBPAYTYPE.Text.Trim = "Against Bill" Then
                        If Val(TXTADJAMT.Text) > Val(LBLBILLTOTAL.Text) Then
                            EP.SetError(TXTADJAMT, "Amount Exceeds Balance Amt.")
                            BLN = False
                        End If

                    End If
                End If

            ElseIf EDIT = True Then
                If GRIDADJDOUBLECLICK = False Then
                    'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                    If (Val(TXTADJTOTAL.Text.Trim) + Val(TXTADJAMT.Text)) > Val(TXTGRANDTOTAL.Text) Then
                        EP.SetError(TXTADJAMT, "Amount Exceeds Specified Amt.")
                        BLN = False
                    End If


                Else
                    'checking WHETHER AMT IS GREATER THEN CHQ AMT OR NOT
                    If ((Val(TXTADJTOTAL.Text.Trim) + Val(TXTADJAMT.Text)) - Val(GRIDPAYMENT.Item(GADJAMT.Index, TEMPADJROW).Value)) > Val(TXTGRANDTOTAL.Text) Then
                        EP.SetError(TXTADJAMT, "Amount Exceeds Specified Amt.")
                        BLN = False
                    End If

                    If CMBPAYTYPE.Text.Trim = "Against Bill" Then
                        Dim MAXALLOWEDVALUE As Double = 0
                        Dim OBJCMN As New ClsCommon
                        Dim DT As DataTable = OBJCMN.search(" ISNULL(SUM(T.RECAMT),0) AS RECAMT", "", " (SELECT SUM(SALERETURN_BILLDESC.SALRET_amt)  AS RECAMT, SALRET_BILLINITIALS AS BILLINITIALS, SALRET_NO as RECNO, SALRET_cmpid AS CMPID, 0 AS LOCATIONID, SALRET_yearid AS YEARID FROM SALERETURN_BILLDESC WHERE SALRET_paytype = 'Against Bill' GROUP BY SALRET_BILLINITIALS, SALRET_no, SALRET_CMPID , SALRET_YEARID) AS T ", " AND T.RECNO =  " & TXTSALRETNO.Text.Trim & " AND T.BILLINITIALS ='" & CMBBILLNO.Text.Trim & "' AND T.YEARID = " & YearId)
                        If DT.Rows.Count > 0 Then
                            MAXALLOWEDVALUE = Val(LBLBILLTOTAL.Text.Trim) + Val(DT.Rows(0).Item("RECAMT"))
                        End If

                        If Val(TXTADJAMT.Text) > Val(MAXALLOWEDVALUE) Then
                            EP.SetError(TXTADJAMT, "Amount Exceeds Balance Amt.")
                            BLN = False
                        End If

                    End If
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub FILLADJGRID()
        Try
            EP.Clear()
            If Not AMOUNTVALIDATE() Then
                TXTADJSRNO.Focus()
                Exit Sub
            End If

            Dim AMT As Double = TXTADJAMT.Text

            'THIS CHANGE IS DONE BY GULKIT TO OPEN TICK ON EDIT MODE
            'If edit = False Then
            If CMBPAYTYPE.Text = "Against Bill" And Val(TXTADJAMT.Text) > Val(LBLBILLTOTAL.Text) And Val(LBLBILLTOTAL.Text) <> 0 Then
                TXTADJAMT.Text = Val(LBLBILLTOTAL.Text)
            End If
            'End If
            If GRIDADJDOUBLECLICK = False Then
                GRIDPAYMENT.Rows.Add(TXTADJSRNO.Text.Trim, CMBPAYTYPE.Text.Trim, CMBBILLNO.Text.Trim, TXTNARR.Text.Trim, Val(TXTADJAMT.Text.Trim), 0, 0, 0, Val(TXTADJAMT.Text.Trim))
                getsrno(GRIDPAYMENT)
            Else
                GRIDPAYMENT.Item(GADJSRNO.Index, TEMPADJROW).Value = TXTADJSRNO.Text.Trim
                GRIDPAYMENT.Item(gpaytype.Index, TEMPADJROW).Value = CMBPAYTYPE.Text.Trim
                GRIDPAYMENT.Item(gbillno.Index, TEMPADJROW).Value = CMBBILLNO.Text.Trim
                GRIDPAYMENT.Item(gdesc.Index, TEMPADJROW).Value = TXTNARR.Text.Trim
                GRIDPAYMENT.Item(GADJAMT.Index, TEMPADJROW).Value = Val(TXTADJAMT.Text.Trim)

                GRIDADJDOUBLECLICK = False
            End If
            'THIS CHANGE IS DONE BY GULKIT TO OPEN TICK ON EDIT MODE
            'If edit = False Then
            TXTADJAMT.Text = Format(Val(AMT) - Val(TXTADJAMT.Text), "0.00")
            'Else
            '    TXTADJAMT.Clear()
            'End If

            TOTAL()
            GRIDPAYMENT.FirstDisplayedScrollingRowIndex = GRIDPAYMENT.RowCount - 1

            TXTADJSRNO.Text = GRIDPAYMENT.RowCount + 1
            CMBPAYTYPE.SelectedIndex = 0
            CMBBILLNO.Text = ""
            LBLBILLTOTAL.Text = ""
            CMBBILLNO.Enabled = False
            TXTNARR.Clear()
            'TXTADJAMT.Clear() DONT CLEAR THE AMT COZ BAL AMT OF THE CHQ COMES AGAIN
            TXTADJSRNO.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub EDITADJROW()
        Try
            If GRIDPAYMENT.CurrentRow.Index >= 0 And GRIDPAYMENT.Item(GADJSRNO.Index, GRIDPAYMENT.CurrentRow.Index).Value <> Nothing Then
                GRIDADJDOUBLECLICK = True
                TEMPADJROW = GRIDPAYMENT.CurrentRow.Index
                TXTADJSRNO.Text = GRIDPAYMENT.Item(GADJSRNO.Index, GRIDPAYMENT.CurrentRow.Index).Value.ToString
                CMBPAYTYPE.Text = GRIDPAYMENT.Item(gpaytype.Index, GRIDPAYMENT.CurrentRow.Index).Value.ToString
                CMBBILLNO.Text = GRIDPAYMENT.Item(gbillno.Index, GRIDPAYMENT.CurrentRow.Index).Value.ToString
                TXTNARR.Text = GRIDPAYMENT.Item(gdesc.Index, GRIDPAYMENT.CurrentRow.Index).Value.ToString
                TXTADJAMT.Text = GRIDPAYMENT.Item(GADJAMT.Index, GRIDPAYMENT.CurrentRow.Index).Value.ToString
                TXTADJSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPAYMENT_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDPAYMENT.CellDoubleClick
        Try
            EDITADJROW()

            If CMBBILLNO.Text.Trim <> "" Then
                CMBBILLNO.Enabled = True

                'GETTING AMT OF THE SELECTED BILL
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" T.BALANCE AS BALANCE", "", " (SELECT BILL_INITIALS AS BILLINITIALS, BILL_BALANCE AS BALANCE, BILL_CMPID AS CMPID , BILL_LOCATIONID AS LOCATIONID , BILL_YEARID AS YEARID FROM OPENINGBILL UNION ALL SELECT INVOICE_INITIALS AS BILLINITIALS, INVOICE_BALANCE AS BALANCE, INVOICE_CMPID AS CMPID, INVOICE_LOCATIONID AS LOCATIONID, INVOICE_YEARID AS YEARID FROM INVOICEMASTER UNION ALL	SELECT JOURNALMASTER.JOURNAL_INITIALS AS BILLINITIALS, (SUM(JOURNAL_DEBIT)-(JOURNAL_AMT + JOURNAL_TDS)) AS BALANCE, JOURNAL_CMPID AS CMPID, JOURNAL_LOCATIONID AS LOCATIONID , JOURNAL_YEARID AS YEARID FROM JOURNALMASTER GROUP BY journal_initials,journal_amt, journal_tds, JOURNAL_CMPID, JOURNAL_LOCATIONID, JOURNAL_YEARID UNION ALL	SELECT NONPURCHASE.NP_INITIALS AS BILLINITIALS, NP_BALANCE AS BALANCE, NP_CMPID AS CMPID, NP_LOCATIONID AS LOCATIONID , NP_YEARID AS YEARID  FROM NONPURCHASE  UNION ALL	SELECT CAST(PAYMENT_GRIDREMARKS AS VARCHAR(100)) AS BILLINITIALS, PAYMENT_BALANCE AS BALANCE, PAYMENT_CMPID AS CMPID, PAYMENT_LOCATIONID AS LOCATIONID , PAYMENT_YEARID AS YEARID  FROM PAYMENTMASTER_DESC WHERE PAYMENT_PAYTYPE = 'New Ref') AS T", " AND T.BILLINITIALS = '" & CMBBILLNO.Text.Trim & "' AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    LBLBILLTOTAL.Text = Format(DT.Rows(0).Item("BALANCE"), "0.00")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPAYMENT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPAYMENT.KeyDown
        If e.KeyCode = Keys.Delete Then

            'if LINE IS IN EDIT MODE (GRIDDOUBLECLICK = TRUE) THEN DONT ALLOW TO DELETE
            If GRIDADJDOUBLECLICK = True Then
                MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                Exit Sub
            End If
            GRIDPAYMENT.Rows.RemoveAt(GRIDPAYMENT.CurrentRow.Index)
            TOTAL()
            getsrno(GRIDPAYMENT)
        ElseIf e.KeyCode = Keys.F5 Then
            EDITADJROW()
        End If
    End Sub

    Private Sub GRIDBILL_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDBILL.KeyDown
        Dim ARGS As New DataGridViewCellEventArgs(GRIDBILL.CurrentCell.ColumnIndex, GRIDBILL.CurrentRow.Index)
        If e.KeyCode = Keys.F8 Then Call GRIDBILL_CellClick(sender, ARGS)
    End Sub

    Private Sub CMBBILLNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBILLNO.Validating
        Try
            LBLBILLTOTAL.Text = ""

            If CMBBILLNO.Text.Trim <> "" Then
                CMBBILLNO.Text = UCase(CMBBILLNO.Text)

                'CHECKING WHETHER THE BILL IS VALID OR NOT
                Dim BLN As Boolean = False
                For Each ITEMS As Object In CMBBILLNO.Items
                    If ITEMS.ToString = CMBBILLNO.Text.Trim Then
                        BLN = True
                    End If
                Next
                If Not BLN Then
                    MsgBox("Invalid Bill No.", MsgBoxStyle.Critical, "TEXTRADE")
                    CMBBILLNO.Focus()
                    Exit Sub
                End If

                'GETTING AMT OF THE SELECTED BILL
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" T.BALANCE AS BALAMT", "", " (SELECT BILL_INITIALS AS BILLINITIALS, BILL_BALANCE AS BALANCE, BILL_CMPID AS CMPID , BILL_LOCATIONID AS LOCATIONID , BILL_YEARID AS YEARID FROM OPENINGBILL UNION ALL SELECT INVOICE_INITIALS AS BILLINITIALS, INVOICE_BALANCE AS BALANCE, INVOICE_CMPID AS CMPID , INVOICE_LOCATIONID AS LOCATIONID , INVOICE_YEARID AS YEARID FROM INVOICEMASTER UNION ALL	SELECT JOURNALMASTER.JOURNAL_INITIALS AS BILLINITIALS, (SUM(JOURNAL_DEBIT)-(JOURNAL_AMT + JOURNAL_TDS)) AS BALANCE, JOURNAL_CMPID AS CMPID, JOURNAL_LOCATIONID AS LOCATIONID , JOURNAL_YEARID AS YEARID FROM JOURNALMASTER GROUP BY journal_initials,journal_amt, journal_tds, JOURNAL_CMPID, JOURNAL_LOCATIONID, JOURNAL_YEARID UNION ALL	SELECT NONPURCHASE.NP_INITIALS AS BILLINITIALS, NP_BALANCE AS BALANCE, NP_CMPID AS CMPID, NP_LOCATIONID AS LOCATIONID , NP_YEARID AS YEARID  FROM NONPURCHASE UNION ALL	SELECT CAST(PAYMENT_GRIDREMARKS AS VARCHAR(100)) AS BILLINITIALS, PAYMENT_BALANCE AS BALANCE, PAYMENT_CMPID AS CMPID, PAYMENT_LOCATIONID AS LOCATIONID , PAYMENT_YEARID AS YEARID  FROM PAYMENTMASTER_DESC WHERE PAYMENT_PAYTYPE = 'New Ref' ) AS T", " AND T.BILLINITIALS = '" & CMBBILLNO.Text.Trim & "' AND T.CMPID = " & CmpId & " AND T.LOCATIONID = " & Locationid & " AND T.YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    LBLBILLTOTAL.Text = Format(DT.Rows(0).Item("BALAMT"), "0.00")
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBILL_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDBILL.CellClick
        Try
            If e.RowIndex >= 0 Then
                With GRIDBILL.Rows(e.RowIndex).Cells(GRIDBILL.Columns("INVCHK").Index)
                    If .Value = True Then
                        .Value = False
                    Else
                        .Value = True

                        'DIRECTLY ADDING IN GRID (AS PER DHARMESH BHAI'S REQ)
                        CMBPAYTYPE.Text = "Against Bill"
                        CMBBILLNO.Text = GRIDBILL.Rows(e.RowIndex).Cells(GRIDBILL.Columns("INVBILLINITIALS").Index).Value
                        CMBBILLNO.Enabled = True
                        TXTNARR.Clear()
                        LBLBILLTOTAL.Text = GRIDBILL.Rows(e.RowIndex).Cells(GRIDBILL.Columns("INVBALAMT").Index).Value

                        Dim A As System.ComponentModel.CancelEventArgs
                        TXTADJAMT_Validating(sender, A)

                    End If
                    TOTAL()
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKTCS_CheckedChanged(sender As Object, e As EventArgs) Handles CHKTCS.CheckedChanged
        TOTAL()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        Try
            CLEAR()
            EDIT = False
            cmbGodown.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getmaxno()
        Try
            Dim DTTABLE As New DataTable
            DTTABLE = getmax(" isnull(max(SALRET_no),0) + 1 ", " SALERETURN ", " AND SALRET_cmpid=" & CmpId & " and SALRET_locationid=" & Locationid & " and SALRET_yearid=" & YearId)
            If DTTABLE.Rows.Count > 0 Then
                TXTSALRETNO.Text = DTTABLE.Rows(0).Item(0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtuploadsrno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuploadsrno.KeyPress
        Try
            enterkeypress(e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function ERRORVALID() As Boolean
        Try

            Dim bln As Boolean = True

            'If ClientName = "SVS" And TXTCHALLANNO.Text.Trim.Length = 0 Then
            '    EP.SetError(TXTCHALLANNO, " Please Fill Challan No. ")
            '    bln = False
            'End If


            'IF BILL NOT ADJUSTED AND GRID IS BLANK THEN MAKE ON ACCOUNT ENTRY
            If TXTINVNO.Text.Trim = "" And GRIDPAYMENT.RowCount = 0 Then
                GRIDPAYMENT.Rows.Add(1, "On Account", "", "", Val(TXTGRANDTOTAL.Text.Trim), 0, 0, 0, Val(TXTGRANDTOTAL.Text.Trim))
                TOTAL()
            End If

            If TXTINVNO.Text.Trim <> "" And GRIDPAYMENT.RowCount > 0 Then
                EP.SetError(TXTINVNO, "Amount cannot be Adjusted against Multiple Bills")
                bln = False
            End If


            If Val(TXTGRANDTOTAL.Text.Trim) <> Val(TXTADJTOTAL.Text.Trim) And GRIDPAYMENT.RowCount > 0 Then
                EP.SetError(TXTGRANDTOTAL, "Total does not match Adjusted Amt")
                bln = False
            End If


            'GET DEFAULT SALEREGISTER IF INVOICENO IS BLANK
            If Convert.ToDateTime(SALRETDATE.Text).Date >= "01/07/2017" And Val(TXTINVNO.Text.Trim) = 0 Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" register_name AS REGNAME ", "", " RegisterMaster ", " and register_default = 'True' and register_type = 'SALE' AND REGISTER_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTINVREGNAME.Text = DT.Rows(0).Item("REGNAME")
                End If
            End If


            If CMBNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBNAME, " Please Select Name ")
                bln = False
            End If

            If CMBDEBITLEDGER.Text.Trim.Length = 0 Then
                EP.SetError(CMBDEBITLEDGER, " Please Select Debit Ledger Name ")
                bln = False
            End If

            If CMBDEBITLEDGER.Text.Trim = CMBNAME.Text.Trim Then
                EP.SetError(CMBDEBITLEDGER, "Credit and Debit Ledger cannot be kept same")
                bln = False
            End If


            If cmbGodown.Text.Trim.Length = 0 Then
                EP.SetError(cmbGodown, " Please Select Godown")
                bln = False
            End If

            'If lbllocked.Visible = True Then
            '    EP.SetError(lbllocked, "Item Used, Item Locked")
            '    bln = False
            'End If

            If GRIDSALRET.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If


            'IF INVOICENO IS NOT BLANK THEN CHECK THAT FIGURES CANNOT BE GREATER THEN BALANCEAMT
            'If Val(TXTINVNO.Text.Trim) > 0 And ClientName <> "CC" And ClientName <> "C3" Then
            '    Dim BALANCE As Double = 0
            '    Dim DT As New DataTable
            '    Dim OBJCMN As New ClsCommon
            '    If TXTINVTYPE.Text.Trim = "INVOICE" Then
            '        DT = OBJCMN.search("INVOICE_BALANCE AS INVBAL", "", "INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID", " AND INVOICE_NO = " & Val(TXTINVNO.Text.Trim) & " AND REGISTER_NAME = '" & TXTINVREGNAME.Text.Trim & "' AND INVOICE_YEARID = " & YearId)
            '    Else
            '        DT = OBJCMN.search("BILL_BALANCE AS INVBAL", "", "OPENINGBILL INNER JOIN REGISTERMASTER ON BILL_REGISTERID = REGISTER_ID INNER JOIN LEDGERS ON ACC_ID = BILL_LEDGERID", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND BILL_NO = " & Val(TXTINVNO.Text.Trim) & " AND REGISTER_NAME = '" & TXTINVREGNAME.Text.Trim & "' AND BILL_YEARID = " & YearId)
            '    End If
            '    BALANCE = Val(DT.Rows(0).Item("INVBAL"))
            '    If EDIT = True Then
            '        Dim DT1 As DataTable = OBJCMN.search("SALRET_GRANDTOTAL AS RETTOTAL", "", "SALERETURN", " AND SALRET_NO = " & Val(TEMPSALRETNO) & " AND SALRET_YEARID = " & YearId)
            '        BALANCE += Val(DT1.Rows(0).Item("RETTOTAL"))
            '    End If
            '    If Val(TXTGRANDTOTAL.Text.Trim) > Val(BALANCE) Then
            '        EP.SetError(TXTGRANDTOTAL, "Amount Greater then Balance Amt, only " & Val(BALANCE) & " can be Used")
            '        bln = False
            '    End If

            'End If

            ''''by guklit sir 

            'If Val(TXTCHALLANNO.Text.Trim) > 0 Then
            '    If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(TXTCHALLANNO.Text.Trim)) Then
            '        'for search
            '        Dim objclscommon As New ClsCommon()
            '        Dim DT As DataTable = objclscommon.search(" SALRET_challanno, LEDGERS.ACC_cmpname", "", " SALERETURN inner join LEDGERS on LEDGERS.ACC_id = SALRET_ledgerid ", " and SALRET_challanno = '" & TXTCHALLANNO.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & cmbname.Text.Trim & "' AND SALRET_YEARID =" & YearId)
            '        If DT.Rows.Count > 0 Then
            '            EP.SetError(TXTCHALLANNO, "Challan No. Already Exists")
            '            bln = False
            '        End If
            '    End If
            'End If

            'DONE BY GULKIT
            'If Convert.ToDateTime(SALRETDATE.Text).Date >= "01/02/2018" And txtgrandtotal.Text > 50000 Then
            '    If TXTEWAYBILLNO.Text.Trim.Length = 0 Then
            '        If MsgBox("E-Way No. Not Entered, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            '            EP.SetError(TXTEWAYBILLNO, " Please Enter E-Way No..... ")
            '            bln = False
            '        End If
            '    End If
            'End If


            If SALRETDATE.Text = "__/__/____" Then
                EP.SetError(SALRETDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(SALRETDATE.Text) Then
                    EP.SetError(SALRETDATE, "Date not in Accounting Year")
                    bln = False
                End If

                If Convert.ToDateTime(SALRETDATE.Text).Date < CNBLOCKDATE.Date Then
                    EP.SetError(SALRETDATE, "Date is Blocked, Please make entries after " & Format(CNBLOCKDATE.Date, "dd/MM/yyyy"))
                    bln = False
                End If
            End If

            If ACTUALINVDATE.Text = "__/__/____" Then
                EP.SetError(ACTUALINVDATE, " Please Enter Proper Date")
                bln = False
                Return bln
                Exit Function
            End If

            'CHEKC BARCODE IS PRESENT IN DATABASE OR NOT
            'If TXTSRCHNO.Text.Trim = "" Then
            '    If Not CHECKBARCODE() Then
            '        bln = False
            '        EP.SetError(TabControl1, "Barcode already present, Please re-enter data")
            '    End If
            'End If


            If Convert.ToDateTime(SALRETDATE.Text).Date >= "01/07/2017" Then
                If TXTSTATECODE.Text.Trim.Length = 0 Then
                    EP.SetError(TXTSTATECODE, "Please enter the state code")
                    bln = False
                End If

                'If TXTGSTIN.Text.Trim.Length = 0 Then
                '    If MsgBox("GSTIN Not Entered, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                '        EP.SetError(CMBNAME, "Enter GSTIN in Party Master")
                '        bln = False
                '    End If
                'End If

                If CMPSTATECODE <> TXTSTATECODE.Text.Trim And (Val(TXTCGSTAMT.Text) > 0 Or Val(TXTSGSTAMT.Text.Trim) > 0) Then
                    EP.SetError(CMBNAME, "Invaid Entry Done in CGST/SGST")
                    bln = False
                End If

                If CMPSTATECODE = TXTSTATECODE.Text.Trim And Val(TXTIGSTAMT.Text) > 0 Then
                    EP.SetError(CMBNAME, "Invaid Entry Done in IGST")
                    bln = False
                End If
            End If

            For Each row As DataGridViewRow In GRIDSALRET.Rows
                'If ClientName <> "MOMAI" And ClientName <> "AXIS" Then
                '    If row.Cells(GMTRS.Index).Value = 0 Then
                '        EP.SetError(CMBNAME, "Mtrs Cannot be 0")
                '        bln = False
                '    End If
                'End If
                If Val(row.Cells(GAMT.Index).Value) = 0 Then
                    EP.SetError(CMBNAME, "Amt Cannot be 0")
                    bln = False
                End If

                If ALLOWMANUALCNDN = True Then
                    If TXTSALRETNO.Text <> "" And CMBNAME.Text.Trim <> "" And EDIT = False Then
                        Dim OBJCMN As New ClsCommon
                        Dim dttable As DataTable = OBJCMN.search(" ISNULL(SALERETURN.SALRET_no, 0) AS SALRETNO, ISNULL(REGISTERMASTER.register_name,'') AS REGNAME", "", " REGISTERMASTER INNER JOIN SALERETURN ON REGISTERMASTER.register_id = SALERETURN.SALRET_INVOICEREGID AND REGISTERMASTER.register_cmpid = SALERETURN.SALRET_CMPID AND REGISTERMASTER.register_yearid = SALERETURN.SALRET_YEARID AND REGISTERMASTER.register_locationid = SALERETURN.SALRET_LOCATIONID", "  AND SALERETURN.SALRET_NO=" & TXTSALRETNO.Text.Trim & " AND REGISTER_NAME = '" & TXTINVREGNAME.Text.Trim & "' AND SALERETURN.SALRET_cmpid = " & CmpId & " AND SALERETURN.SALRET_yearid = " & YearId)
                        If dttable.Rows.Count > 0 Then
                            EP.SetError(TXTSALRETNO, "Bill No Already Exist")
                            bln = False
                        End If
                    End If
                End If

            Next

            For Each ROW As DataGridViewRow In GRIDPAYMENT.Rows
                If ROW.Cells(gpaytype.Index).Value = "Against Bill" And ROW.Cells(gbillno.Index).Value = "" Then
                    EP.SetError(CMBNAME, "Please Enter Ref No, Or Do not select Against Bill/New Ref")
                    bln = False
                End If

                'If ROW.Cells(gpaytype.Index).Value = "New Ref" And ROW.Cells(gdesc.Index).Value = "" Then
                '    EP.SetError(CMBNAME, "Please Enter Ref No, Or Do not select Against Bill/New Ref")
                '    bln = False
                'End If
                If ROW.Cells(gpaytype.Index).Value = "New Ref" Then ROW.Cells(gdesc.Index).Value = "SR-" & Val(TXTSALRETNO.Text.Trim)
            Next


            Return bln

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            EP.Clear()
            'If Not ERRORVALID() Then
            '    Exit Sub
            'End If


            'GET BILLREMARKS
            TXTBILLREMARKS.Clear()
            For Each ROW As DataGridViewRow In GRIDPAYMENT.Rows
                If ROW.Cells(gpaytype.Index).Value = "Against Bill" Then
                    If TXTBILLREMARKS.Text = "" Then
                        TXTBILLREMARKS.Text = "Against Bill - " & ROW.Cells(gbillno.Index).Value
                    Else
                        TXTBILLREMARKS.Text = TXTBILLREMARKS.Text & ", " & ROW.Cells(gbillno.Index).Value
                    End If
                ElseIf ROW.Cells(gpaytype.Index).Value = "" Then
                    ROW.Cells(gpaytype.Index).Value = "On Account"
                End If
            Next

            Dim alParaval As New ArrayList

            If ALLOWMANUALCNDN = True Then
                alParaval.Add(Val(TXTSALRETNO.Text.Trim))
            Else
                alParaval.Add(0)
            End If
            alParaval.Add(Format(Convert.ToDateTime(SALRETDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(cmbGodown.Text.Trim)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBDEBITLEDGER.Text.Trim)
            alParaval.Add(CMBPACKING.Text.Trim)

            alParaval.Add(TXTCHALLANNO.Text.Trim)
            alParaval.Add(CHALLANDATE.Value.Date)

            alParaval.Add(TXTACTUALINVNO.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(ACTUALINVDATE.Text).Date, "MM/dd/yyyy"))

            alParaval.Add(TXTINVNO.Text.Trim)
            alParaval.Add(TXTINVREGNAME.Text.Trim)
            alParaval.Add(INVDATE.Value.Date)
            alParaval.Add(TXTINVTYPE.Text.Trim)
            alParaval.Add(TXTINVINITIALS.Text.Trim)

            alParaval.Add(TXTPARTYREFNO.Text.Trim)
            alParaval.Add(TXTSRCHNO.Text.Trim)
            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(txtlrno.Text.Trim)
            alParaval.Add(lrdate.Value)
            alParaval.Add(CMBAGENT.Text.Trim)
            alParaval.Add(TXTEWAYBILLNO.Text.Trim)

            'alParaval.Add(Val(LBLTOTALWT.Text))
            alParaval.Add(Val(lbltotalqty.Text))
            'alParaval.Add(Val(LBLTOTALMTRS.Text))
            alParaval.Add(Val(LBLTOTALAMT.Text))

            If CHKMANUAL.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Val(TXTCGSTPER.Text.Trim))
            alParaval.Add(Val(TXTCGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTSGSTPER.Text.Trim))
            alParaval.Add(Val(TXTSGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTIGSTPER.Text.Trim))
            alParaval.Add(Val(TXTIGSTAMT.Text.Trim))

            alParaval.Add(Val(txtbillamt.Text.Trim))
            alParaval.Add(Val(TXTCHARGES.Text.Trim))
            alParaval.Add(Val(TXTSUBTOTAL.Text.Trim))

            alParaval.Add(Val(TXTTOTALWITHGST.Text.Trim))
            If CHKTCS.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)
            alParaval.Add(Val(TXTTCSPER.Text.Trim))
            alParaval.Add(Val(TXTTCSAMT.Text.Trim))

            alParaval.Add(Val(txtroundoff.Text.Trim))
            alParaval.Add(Val(TXTGRANDTOTAL.Text.Trim))

            alParaval.Add(txtinwords.Text)

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(TXTBILLREMARKS.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim ITEMCODE As String = ""
            Dim ITEMNAME As String = ""
            Dim HSNCODE As String = ""
            Dim MATERIALCODE As String = ""
            Dim QTY As String = ""
            Dim BATCHNO As String = ""
            Dim SHIPPERS As String = ""
            Dim PACKETS As String = ""
            Dim RATE As String = ""         'value of RATE
            Dim AMOUNT As String = ""         'value of AMT
            Dim DONE As String = ""
            Dim OUTQTY As String = ""
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""

            'Dim FROMTYPE As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDSALRET.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        ITEMCODE = row.Cells(GITEMCODE.Index).Value.ToString
                        ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                        HSNCODE = row.Cells(GHSNCODE.Index).Value.ToString
                        MATERIALCODE = row.Cells(GMATERIALCODE.Index).Value.ToString
                        QTY = row.Cells(gQty.Index).Value.ToString
                        BATCHNO = row.Cells(GBATCHNO.Index).Value.ToString
                        SHIPPERS = row.Cells(GSHIPPERS.Index).Value.ToString
                        PACKETS = row.Cells(GPACKETS.Index).Value
                        RATE = row.Cells(GRATE.Index).Value
                        AMOUNT = row.Cells(GAMT.Index).Value
                        If row.Cells(GDONE.Index).Value = True Then
                            DONE = 1
                        Else
                            DONE = 0
                        End If
                        OUTQTY = row.Cells(GOUTQTY.Index).Value
                        FROMNO = row.Cells(GFROMNO.Index).Value
                        FROMSRNO = row.Cells(GFROMSRNO.Index).Value

                    Else
                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value
                        ITEMCODE = ITEMCODE & "|" & row.Cells(GITEMCODE.Index).Value
                        ITEMNAME = ITEMNAME & "|" & row.Cells(gitemname.Index).Value
                        HSNCODE = HSNCODE & "|" & row.Cells(GHSNCODE.Index).Value.ToString
                        MATERIALCODE = MATERIALCODE & "|" & row.Cells(GMATERIALCODE.Index).Value.ToString
                        QTY = QTY & "|" & row.Cells(gQty.Index).Value
                        BATCHNO = BATCHNO & "|" & row.Cells(GBATCHNO.Index).Value.ToString
                        SHIPPERS = SHIPPERS & "|" & row.Cells(GSHIPPERS.Index).Value.ToString
                        PACKETS = PACKETS & "|" & row.Cells(GPACKETS.Index).Value.ToString
                        RATE = RATE & "|" & row.Cells(GRATE.Index).Value
                        AMOUNT = AMOUNT & "|" & row.Cells(GAMT.Index).Value
                        If row.Cells(GDONE.Index).Value = True Then
                            DONE = DONE & "|" & "1"
                        Else
                            DONE = DONE & "|" & "0"
                        End If
                        OUTQTY = OUTQTY & "|" & row.Cells(GOUTQTY.Index).Value
                        FROMNO = FROMNO & "|" & row.Cells(GFROMNO.Index).Value
                        FROMSRNO = FROMSRNO & "|" & row.Cells(GFROMSRNO.Index).Value
                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(ITEMCODE)
            alParaval.Add(ITEMNAME)
            alParaval.Add(HSNCODE)
            alParaval.Add(MATERIALCODE)
            alParaval.Add(QTY)
            alParaval.Add(BATCHNO)
            alParaval.Add(SHIPPERS)
            alParaval.Add(PACKETS)
            alParaval.Add(RATE)
            alParaval.Add(AMOUNT)
            alParaval.Add(DONE)
            alParaval.Add(OUTQTY)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)


            'SAVING CHGS GRID
            Dim CSRNO As String = ""
            Dim CCHGS As String = ""
            Dim CPER As String = ""
            Dim CAMT As String = ""
            Dim CTAXID As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDCHGS.Rows
                If row.Cells(0).Value <> Nothing Then
                    If CSRNO = "" Then
                        CSRNO = row.Cells(ESRNO.Index).Value.ToString
                        CCHGS = row.Cells(ECHARGES.Index).Value.ToString
                        CPER = row.Cells(EPER.Index).Value.ToString
                        CAMT = Val(row.Cells(EAMT.Index).Value)
                        CTAXID = Val(row.Cells(ETAXID.Index).Value)
                    Else
                        CSRNO = CSRNO & "|" & row.Cells(ESRNO.Index).Value.ToString
                        CCHGS = CCHGS & "|" & row.Cells(ECHARGES.Index).Value.ToString
                        CPER = CPER & "|" & row.Cells(EPER.Index).Value.ToString
                        CAMT = CAMT & "|" & Val(row.Cells(EAMT.Index).Value)
                        CTAXID = CTAXID & "|" & Val(row.Cells(ETAXID.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(CSRNO)
            alParaval.Add(CCHGS)
            alParaval.Add(CPER)
            alParaval.Add(CAMT)
            alParaval.Add(CTAXID)


            Dim griduploadsrno As String = ""
            Dim imgpath As String = ""
            Dim uploadremarks As String = ""
            Dim name As String = ""
            Dim NEWIMGPATH As String = ""
            Dim FILENAME As String = ""

            'Saving Upload Grid
            For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
                If row.Cells(0).Value <> Nothing Then
                    If griduploadsrno = "" Then
                        griduploadsrno = row.Cells(0).Value.ToString
                        uploadremarks = row.Cells(1).Value.ToString
                        name = row.Cells(2).Value.ToString
                        imgpath = row.Cells(3).Value.ToString
                        NEWIMGPATH = row.Cells(GNEWIMGPATH.Index).Value.ToString

                    Else
                        griduploadsrno = griduploadsrno & "|" & row.Cells(0).Value.ToString
                        uploadremarks = uploadremarks & "|" & row.Cells(1).Value.ToString
                        name = name & "|" & row.Cells(2).Value.ToString
                        imgpath = imgpath & "|" & row.Cells(3).Value.ToString
                        NEWIMGPATH = NEWIMGPATH & "|" & row.Cells(GNEWIMGPATH.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(griduploadsrno)
            alParaval.Add(uploadremarks)
            alParaval.Add(name)
            alParaval.Add(imgpath)
            alParaval.Add(NEWIMGPATH)
            alParaval.Add(FILENAME)

            Dim pgridsrno As String = ""
            Dim paytype As String = ""
            Dim billINITIALS As String = ""
            Dim narr As String = ""
            Dim ADJAMT As String = ""
            Dim AMTPAID As String = ""
            Dim EXTRAAMT As String = ""
            Dim RETURNAMT As String = ""
            Dim BALANCE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDPAYMENT.Rows
                If row.Cells(GADJSRNO.Index).Value <> Nothing Then
                    If pgridsrno = "" Then

                        pgridsrno = row.Cells(GADJSRNO.Index).Value.ToString
                        paytype = row.Cells(gpaytype.Index).Value
                        billINITIALS = row.Cells(gbillno.Index).Value.ToString
                        narr = row.Cells(gdesc.Index).Value
                        ADJAMT = Val(row.Cells(GADJAMT.Index).Value)
                        AMTPAID = Val(row.Cells(GAMTPAID.Index).Value)
                        EXTRAAMT = Val(row.Cells(GEXTRAAMT.Index).Value)
                        RETURNAMT = Val(row.Cells(GRETURN.Index).Value)
                        BALANCE = Val(row.Cells(GBALANCE.Index).Value)

                    Else

                        pgridsrno = pgridsrno & "|" & row.Cells(GADJSRNO.Index).Value.ToString
                        paytype = paytype & "|" & row.Cells(gpaytype.Index).Value
                        billINITIALS = billINITIALS & "|" & row.Cells(gbillno.Index).Value.ToString
                        narr = narr & "|" & row.Cells(gdesc.Index).Value
                        ADJAMT = ADJAMT & "|" & Val(row.Cells(GADJAMT.Index).Value)
                        AMTPAID = AMTPAID & "|" & Val(row.Cells(GAMTPAID.Index).Value)
                        EXTRAAMT = EXTRAAMT & "|" & Val(row.Cells(GEXTRAAMT.Index).Value)
                        RETURNAMT = RETURNAMT & "|" & Val(row.Cells(GRETURN.Index).Value)
                        BALANCE = BALANCE & "|" & Val(row.Cells(GBALANCE.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(pgridsrno)
            alParaval.Add(paytype)
            alParaval.Add(billINITIALS)
            alParaval.Add(narr)
            alParaval.Add(ADJAMT)
            alParaval.Add(AMTPAID)
            alParaval.Add(EXTRAAMT)
            alParaval.Add(RETURNAMT)
            alParaval.Add(BALANCE)


            alParaval.Add(TXTIRNNO.Text.Trim)
            alParaval.Add(TXTACKNO.Text.Trim)
            alParaval.Add(Format(ACKDATE.Value.Date, "MM/dd/yyyy"))
            If PBQRCODE.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                alParaval.Add(MS.ToArray)
            Else
                alParaval.Add(DBNull.Value)
            End If

            alParaval.Add(TXTSPECIALREMARKS.Text.Trim)
            If CHKCD.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)

            alParaval.Add(Val(TXTNOOFPACKETS.Text.Trim))
            If CHKEXPORTGST.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If
            If CHKMANUALROUND.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)


            Dim OBJPURCH As New ClsSaleReturn()
            OBJPURCH.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = OBJPURCH.SAVE()
                MsgBox("Details Added")
                TXTSALRETNO.Text = DTTABLE.Rows(0).Item(0)
                PRINTREPORT(DTTABLE.Rows(0).Item(0))
            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPSALRETNO)
                IntResult = OBJPURCH.UPDATE()
                MsgBox("Details Updated")
                PRINTREPORT(TEMPSALRETNO)
            End If

            'PRINTBARCODE()


            EDIT = False

            'COPY SCANNED DOCS FILES 
            For Each ROW As DataGridViewRow In gridupload.Rows
                If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\UPLOADDOCS") = False Then
                    FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\UPLOADDOCS")
                End If
                If FileIO.FileSystem.FileExists(Application.StartupPath & "\UPLOADDOCS") = False Then
                    System.IO.File.Copy(ROW.Cells(GIMGPATH.Index).Value, ROW.Cells(GNEWIMGPATH.Index).Value, True)
                End If
            Next

            CLEAR()
            Call toolnext_Click(sender, e)
            cmbGodown.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '        Sub PRINTBARCODE()
    '            Try
    '                If TXTSRCHNO.Text.Trim <> "" Then Exit Sub
    '                If ALLOWBARCODEPRINT Then

    '                    'PRINT BARCODE
    '                    Dim TEMPMSG As Integer = MsgBox("Wish to Print Barcode?", MsgBoxStyle.YesNo)
    '                    If TEMPMSG = vbNo Then Exit Sub

    '                    GRIDSALRET.RowCount = 0
    '                    Dim OBJPURCH As New ClsSaleReturn
    '                    Dim DTTABLE As DataTable = OBJPURCH.SELECTSALRET(Val(TXTSALRETNO.Text.Trim), CmpId, Locationid, YearId)
    '                    For Each dr As DataRow In DTTABLE.Rows
    '                        GRIDSALRET.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("ITEMNAME").ToString, dr("HSNCODE").ToString, dr("QUALITY").ToString, dr("DESIGN").ToString, dr("COLOR"), dr("BALENO"), Format(Val(dr("CUT")), "0.00"), Format(Val(dr("WT")), "0.00"), Format(Val(dr("qty")), "0.00"), dr("UNIT").ToString, Format(Val(dr("MTRS")), "0.00"), Format(Val(dr("RATE")), "0.00"), dr("PER").ToString, Format(Val(dr("AMT")), "0.00"), dr("RACK").ToString, dr("SHELF").ToString, dr("BARCODE"), dr("GDNBARCODE"), dr("GRIDDONE").ToString, dr("OUTPCS"), dr("OUTMTRS"), dr("FROMNO"), dr("FROMSRNO"))
    '                    Next


    '                    Dim WHOLESALEBARCODE As Integer = 0
    '                    If ClientName = "CC" Or ClientName = "C3" Or ClientName = "SHREEDEV" Then WHOLESALEBARCODE = MsgBox("Wish to Print Wholesale Barcode?", MsgBoxStyle.YesNo)



    '                    Dim TEMPHEADER As String = ""
    '                    If ClientName = "YASHVI" Then
    '                        TEMPHEADER = InputBox("Enter Sticker Type (M/N/Y/B)")
    '                        If TEMPHEADER <> "M" And TEMPHEADER <> "N" And TEMPHEADER <> "Y" And TEMPHEADER <> "B" Then Exit Sub
    '                        If TEMPHEADER = "M" Then TEMPHEADER = "MAFATLAL"
    '                        If TEMPHEADER = "N" Then TEMPHEADER = ""
    '                    End If

    '                    If ClientName = "GELATO" Then
    '                        TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR NORMAL" & Chr(13) & "2 FOR MRP" & Chr(13) & "3 FOR WSP")
    '                        If TEMPHEADER <> "1" And TEMPHEADER <> "2" And TEMPHEADER <> "3" Then Exit Sub
    '                    End If

    '                    If ClientName = "RAJKRIPA" Then
    '                        TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR LUMP" & Chr(13) & "2 FOR CUTPACK")
    '                        If TEMPHEADER <> "1" And TEMPHEADER <> "2" Then Exit Sub
    '                    End If

    '                    If ClientName = "KRISHNA" Then
    '                        TEMPHEADER = InputBox("Enter Sticker Type " & Chr(13) & "1 FOR NORMAL" & Chr(13) & "2 FOR BOX STICKER")
    '                        If TEMPHEADER <> "1" And TEMPHEADER <> "2" Then Exit Sub
    '                    End If


    '                    Dim SUPRIYAHEADER As String = ""
    '                    If ClientName = "SUPRIYA" Then
    '                        TEMPHEADER = InputBox("Enter Sticker Type (1/2/3/4/5/6/7)")
    '                        If TEMPHEADER <> "1" And TEMPHEADER <> "2" And TEMPHEADER <> "3" And TEMPHEADER <> "4" And TEMPHEADER <> "5" And TEMPHEADER <> "6" And TEMPHEADER <> "7" Then Exit Sub
    '                        If TEMPHEADER = "1" Or TEMPHEADER = "6" Then SUPRIYAHEADER = "ROYAL TEX"
    '                        If TEMPHEADER = "2" Or TEMPHEADER = "7" Then SUPRIYAHEADER = "DEEP BLUE"
    '                        If TEMPHEADER = "3" Then SUPRIYAHEADER = ""
    '                        If TEMPHEADER = "4" Then SUPRIYAHEADER = "KAMDHENU"
    '                        If TEMPHEADER = "5" Then SUPRIYAHEADER = "5"
    '                    End If

    '                    For Each ROW As DataGridViewRow In GRIDSALRET.Rows
    '                        'TO PRINT BARCODE FROM SELECTED SRNO
    '                        If (Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0) Then
    '                            If Val(ROW.Cells(gsrno.Index).Value) < Val(TXTFROM.Text.Trim) Or Val(ROW.Cells(gsrno.Index).Value) > Val(TXTTO.Text.Trim) Then GoTo NEXTLINE
    '                        End If
    '                        Dim GRIDDESC As String = ""
    '                        Dim TEMPNAME As String = ""
    '                        If ClientName = "KCRAYON" Or ClientName = "KOTHARI" Or ClientName = "KOTHARINEW" Then GRIDDESC = ROW.Cells(GBALENO.Index).Value
    '                        If ClientName = "RAJKRIPA" Or ClientName = "MOMAI" Then TEMPNAME = CMBNAME.Text.Trim

    '                        'IF barcode is used the BARCODE printING WILL BE BLOCKED
    '                        If Val(ROW.Cells(GOUTMTRS.Index).Value) > 0 Then GoTo NEXTLINE

    '                        BARCODEPRINTING(ROW.Cells(GBARCODE.Index).Value, ROW.Cells(GPIECETYPE.Index).Value, ROW.Cells(gitemname.Index).Value, ROW.Cells(GQUALITY.Index).Value, ROW.Cells(GDESIGN.Index).Value, ROW.Cells(gcolor.Index).Value, ROW.Cells(gqtyunit.Index).Value, "", ROW.Cells(GBALENO.Index).Value, GRIDDESC, Val(ROW.Cells(GMTRS.Index).Value), Val(ROW.Cells(gQty.Index).Value), Val(ROW.Cells(gcut.Index).Value), ROW.Cells(GRACK.Index).Value, TEMPHEADER, SUPRIYAHEADER, WHOLESALEBARCODE, "", TEMPNAME)
    'NEXTLINE:

    '                    Next
    '                End If

    '            Catch ex As Exception
    '                Throw ex
    '            End Try
    '        End Sub

    Private Sub SaleReturn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If ERRORVALID() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Keys.D1 Then
            TabControl1.SelectedIndex = 0
        ElseIf e.Alt = True And e.KeyCode = Keys.D2 Then
            TabControl1.SelectedIndex = 1
        ElseIf e.Alt = True And e.KeyCode = Keys.D3 Then
            TabControl1.SelectedIndex = 2
        ElseIf e.Alt = True And e.KeyCode = Keys.D4 Then
            TabControl1.SelectedIndex = 3
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.F5 Then
            GRIDSALRET.Focus()
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.Alt = True And e.KeyCode = Keys.P Then
            Call PrintToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for Delete
            tstxtbillno.Focus()
            tstxtbillno.SelectAll()
        End If
    End Sub

    Private Sub SaleReturn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'SALE RETURN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            fillcmb()
            CLEAR()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJPURCH As New ClsSaleReturn()
                Dim dttable As DataTable = OBJPURCH.SELECTSALRET(TEMPSALRETNO, CmpId, Locationid, YearId)

                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTSALRETNO.Text = TEMPSALRETNO
                        TXTSALRETNO.ReadOnly = True
                        SALRETDATE.Text = Format(Convert.ToDateTime(dr("SALRETDATE")), "dd/MM/yyyy")

                        TXTINVNO.Text = dr("INVNO")
                        TXTINVREGNAME.Text = Convert.ToString(dr("INVREGNAME").ToString)
                        INVDATE.Text = Format(Convert.ToDateTime(dr("INVDATE")).Date, "dd/MM/yyyy")
                        TXTINVTYPE.Text = Convert.ToString(dr("INVTYPE").ToString)
                        TXTINVINITIALS.Text = Convert.ToString(dr("INVINITIALS").ToString)

                        CHALLANDATE.Value = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")
                        TXTCHALLANNO.Text = dr("CHALLANNO")
                        PARTYCHALLANNO = TXTCHALLANNO.Text.Trim
                        TXTCITY.Text = dr("CITYNAME")

                        ACTUALINVDATE.Text = Format(Convert.ToDateTime(dr("ACTUALINVDATE")), "dd/MM/yyyy")
                        TXTACTUALINVNO.Text = dr("ACTUALINVNO")

                        cmbGodown.Text = Convert.ToString(dr("GODOWN").ToString)
                        CMBNAME.Text = Convert.ToString(dr("NAME").ToString)
                        CMBDEBITLEDGER.Text = dr("DEBITNAME")
                        CMBPACKING.Text = dr("DELIVERYAT")

                        TXTSTATECODE.Text = dr("STATECODE")
                        TXTGSTIN.Text = dr("GSTIN")

                        If TXTINVINITIALS.Text.Trim <> "" Then CMBNAME.Enabled = False

                        TXTPARTYREFNO.Text = dr("PARTYREFNO")
                        TXTSRCHNO.Text = dr("SRCHNO")
                        cmbtrans.Text = dr("TRANSNAME").ToString
                        txtlrno.Text = dr("LRNO").ToString
                        lrdate.Text = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")
                        CMBAGENT.Text = dr("AGENT").ToString
                        TXTEWAYBILLNO.Text = dr("EWAYBILLNO")
                        txtinwords.Text = Convert.ToString(dr("INWORDS").ToString)
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)
                        TXTBILLREMARKS.Text = dr("BILLREMARKS")
                        If Convert.ToBoolean(dr("CD")) = False Then CHKCD.Checked = False Else CHKCD.Checked = True
                        If Convert.ToBoolean(dr("SENDWHATSAPP")) = True Then LBLWHATSAPP.Visible = True

                        TXTNOOFPACKETS.Text = Val(dr("NOOFPACKETS"))
                        If dr("EXPORTGST") = 0 Then CHKEXPORTGST.Checked = False Else CHKEXPORTGST.Checked = True
                        If dr("MANUALGST") = 0 Then CHKMANUAL.Checked = False Else CHKMANUAL.Checked = True
                        'If dr("OVERSEAS") = 0 Then CHKOVERSEAS.Checked = False Else CHKOVERSEAS.Checked = True
                        If Convert.ToBoolean(dr("MANUALROUNDOFF")) = False Then CHKMANUALROUND.Checked = False Else CHKMANUALROUND.Checked = True


                        TXTCGSTPER.Text = Val(dr("TOTALCGSTPER"))
                        TXTSGSTPER.Text = Val(dr("TOTALSGSTPER"))
                        TXTIGSTPER.Text = Val(dr("TOTALIGSTPER"))
                        TXTCGSTAMT.Text = Val(dr("TOTALCGSTAMT"))
                        TXTSGSTAMT.Text = Val(dr("TOTALSGSTAMT"))
                        TXTIGSTAMT.Text = Val(dr("TOTALIGSTAMT"))

                        txtroundoff.Text = Val(dr("ROUNDOFF"))


                        If dr("APPLYTCS") = 0 Then CHKTCS.Checked = False Else CHKTCS.Checked = True
                        TXTTOTALWITHGST.Text = Val(dr("TOTALWITHGST"))
                        TXTTCSPER.Text = Val(dr("TCSPER"))
                        TXTTCSAMT.Text = Val(dr("TCSAMT"))


                        'Item Grid
                        GRIDSALRET.Rows.Add(dr("GRIDSRNO").ToString, dr("ITEMCODE"), dr("ITEMNAME").ToString, dr("HSNCODE").ToString, dr("MATERIALCODE").ToString, dr("QTY").ToString, dr("BATCHNO").ToString, dr("SHIPPERS").ToString, dr("PACKETS").ToString, dr("RATE").ToString, dr("AMT").ToString, dr("GRIDDONE").ToString, dr("OUTQTY"), dr("FROMNO"), dr("FROMSRNO"))

                        If Convert.ToBoolean(dr("GRIDDONE")) = True Then
                            GRIDSALRET.Rows(GRIDSALRET.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If


                        TXTIRNNO.Text = dr("IRNNO")
                        TXTACKNO.Text = dr("ACKNO")
                        ACKDATE.Value = dr("ACKDATE")
                        If IsDBNull(dr("QRCODE")) = False Then
                            PBQRCODE.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dr("QRCODE"), Byte())))
                        Else
                            PBQRCODE.Image = Nothing
                        End If
                        TXTSPECIALREMARKS.Text = dr("SPECIALREMARKS")
                    Next


                    'CHARGES GRID
                    Dim OBJCMN As New ClsCommon
                    Dim dttable1 As DataTable = OBJCMN.search(" SALERETURN_CHGS.SALRET_gridsrno AS GRIDSRNO, LEDGERS.Acc_cmpname AS CHARGES, SALERETURN_CHGS.SALRET_PER AS PER, SALERETURN_CHGS.SALRET_AMT AS AMT, SALERETURN_CHGS.SALRET_TAXID AS TAXID ", "", " SALERETURN_CHGS INNER JOIN LEDGERS ON SALERETURN_CHGS.SALRET_CHARGESID = LEDGERS.Acc_id ", " AND SALERETURN_CHGS.SALRET_NO = " & TEMPSALRETNO & " AND SALERETURN_CHGS.SALRET_YEARID = " & YearId)
                    If dttable1.Rows.Count > 0 Then
                        For Each DTR As DataRow In dttable1.Rows
                            GRIDCHGS.Rows.Add(DTR("GRIDSRNO"), DTR("CHARGES"), DTR("PER"), DTR("AMT"), DTR("TAXID"))
                        Next
                    End If



                    dttable1 = OBJCMN.search(" SALERETURN_BILLDESC.SALRET_GRIDSRNO AS GRIDSRNO, SALERETURN_BILLDESC.SALRET_PAYTYPE AS PAYTYPE, SALERETURN_BILLDESC.SALRET_BILLINITIALS AS BILLINITIALS, SALERETURN_BILLDESC.SALRET_GRIDREMARKS AS NARR, SALERETURN_BILLDESC.SALRET_AMT AS AMT, SALERETURN_BILLDESC.SALRET_AMTPAID AS AMTPAID, SALERETURN_BILLDESC.SALRET_EXTRAAMT AS EXTRAAMT, SALERETURN_BILLDESC.SALRET_RETURN AS [RETURN], SALERETURN_BILLDESC.SALRET_BALANCE AS BALANCE ", "", " SALERETURN_BILLDESC ", " AND SALERETURN_BILLDESC.SALRET_NO = " & TEMPSALRETNO & " AND SALERETURN_BILLDESC.SALRET_YEARID = " & YearId)
                    For Each DR As DataRow In dttable1.Rows
                        GRIDPAYMENT.Rows.Add(DR("GRIDSRNO"), DR("PAYTYPE").ToString, DR("BILLINITIALS").ToString, DR("NARR").ToString, Format(DR("AMT"), "0.00"), Format(DR("AMTPAID"), "0.00"), Format(DR("EXTRAAMT"), "0.00"), Format(DR("RETURN"), "0.00"), Format(DR("BALANCE"), "0.00"))
                        If Val(DR("AMTPAID")) > 0 Or Val(DR("EXTRAAMT")) > 0 Or Val(DR("RETURN")) > 0 Then
                            GRIDPAYMENT.Rows(GRIDPAYMENT.RowCount - 1).DefaultCellStyle.BackColor = Color.Linen
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If
                    Next
                    FILLGRIDINVOICE()
                    GRIDPAYMENT.ClearSelection()
                    TOTAL()
                Else
                    EDIT = False
                    CLEAR()
                End If

            End If

            If GRIDSALRET.RowCount > 0 Then
                txtsrno.Text = Val(GRIDSALRET.Rows(GRIDSALRET.RowCount - 1).Cells(0).Value) + 1
            Else
                txtsrno.Text = 1
            End If

            If TXTIRNNO.Text <> "" And TXTACKNO.Text <> "" Then
                LBLENVGENERATED.Visible = True
            End If


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub fillcmb()
        Try
            If CMBCHARGES.Text.Trim = "" Then fillname(CMBCHARGES, EDIT, " AND (GROUPMASTER.GROUP_SECONDARY ='Indirect Income' OR GROUPMASTER.GROUP_SECONDARY ='Sales A/C' OR GROUPMASTER.GROUP_SECONDARY ='Indirect Expenses' or GROUPMASTER.GROUP_SECONDARY ='Direct Income' OR GROUPMASTER.GROUP_SECONDARY ='Direct Expenses' OR GROUPMASTER.GROUP_SECONDARY ='Duties & Taxes')")
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT'")
            If CMBDEBITLEDGER.Text.Trim = "" Then fillname(CMBDEBITLEDGER, EDIT, "")
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors'")
            If cmbGodown.Text.Trim = "" Then fillGODOWN(cmbGodown, EDIT)
            If CMBITEMCODE.Text.Trim = "" Then fillITEMCODE(CMBITEMCODE, EDIT, " and ITEMMASTER.ITEM_MATERIALTYPE = 'FINISHED'")
            If cmbitemname.Text.Trim = "" Then fillITEMNAME(cmbitemname, EDIT, " and ITEMMASTER.ITEM_MATERIALTYPE = 'FINISHED'")

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDEBITLEDGER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDEBITLEDGER.Enter
        Try
            If CMBDEBITLEDGER.Text.Trim = "" Then fillname(CMBDEBITLEDGER, EDIT, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEBITLEDGER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDEBITLEDGER.Validating
        Try
            If CMBDEBITLEDGER.Text.Trim <> "" Then namevalidate(CMBDEBITLEDGER, CMBCODE, e, Me, txtadd, "")
        Catch ex As Exception
            Throw ex
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

            Dim OBJPURCH As New SaleReturnDetails
            OBJPURCH.MdiParent = MDIMain
            OBJPURCH.Show()
            OBJPURCH.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtrans.Validating
        Try
            If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, CMBCODE, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "TRANSPORT")
        Catch ex As Exception
            Throw ex
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

    Sub uploadgetsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            'If edit = False Then
            Dim i As Integer = 0
            For Each row As DataGridViewRow In grid.Rows
                If row.Visible = True Then
                    row.Cells(GGRIDUPLOADSRNO.Index).Value = i + 1
                    i = i + 1
                End If
            Next
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDSALRET.RowCount = 0
                TEMPSALRETNO = Val(tstxtbillno.Text)
                If TEMPSALRETNO > 0 Then
                    EDIT = True
                    SaleReturn_Load(sender, e)
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
            GRIDSALRET.Enabled = True
            If GRIDDOUBLECLICK = False Then
                GRIDSALRET.Rows.Add(Val(txtsrno.Text.Trim), CMBITEMCODE.Text.Trim, cmbitemname.Text.Trim, TXTHSNCODE.Text.Trim, TXTMATERIALCODE.Text.Trim, Val(txtqty.Text.Trim), Val(TXTBATCHNO.Text.Trim), Val(TXTSHIPPERS.Text.Trim), Val(TXTPACKETS.Text.Trim), Val(TXTRATE.Text.Trim), Val(TXTAMT.Text.Trim), 0, 0, 0, 0)
                getsrno(GRIDSALRET)
            ElseIf GRIDDOUBLECLICK = True Then
                GRIDSALRET.Item(gsrno.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
                GRIDSALRET.Item(GITEMCODE.Index, TEMPROW).Value = CMBITEMCODE.Text.Trim
                GRIDSALRET.Item(gitemname.Index, TEMPROW).Value = cmbitemname.Text.Trim
                GRIDSALRET.Item(GHSNCODE.Index, TEMPROW).Value = TXTHSNCODE.Text.Trim
                GRIDSALRET.Item(GMATERIALCODE.Index, TEMPROW).Value = TXTMATERIALCODE.Text.Trim
                GRIDSALRET.Item(gQty.Index, TEMPROW).Value = Val(txtqty.Text.Trim)
                GRIDSALRET.Item(GBATCHNO.Index, TEMPROW).Value = TXTBATCHNO.Text.Trim
                GRIDSALRET.Item(GSHIPPERS.Index, TEMPROW).Value = TXTSHIPPERS.Text.Trim
                GRIDSALRET.Item(GPACKETS.Index, TEMPROW).Value = TXTPACKETS.Text.Trim
                GRIDSALRET.Item(GRATE.Index, TEMPROW).Value = Val(TXTRATE.Text.Trim)
                GRIDSALRET.Item(GAMT.Index, TEMPROW).Value = Val(TXTAMT.Text.Trim)

                GRIDDOUBLECLICK = False
            End If
            TOTAL()
            GRIDSALRET.FirstDisplayedScrollingRowIndex = GRIDSALRET.RowCount - 1

            'txtsrno.Clear()
            txtsrno.Text = GRIDSALRET.RowCount + 1
            CMBITEMCODE.Text = ""
            cmbitemname.Text = ""
            TXTHSNCODE.Clear()
            TXTMATERIALCODE.Clear()
            txtqty.Clear()
            TXTBATCHNO.Clear()
            TXTSHIPPERS.Clear()
            TXTPACKETS.Clear()
            TXTRATE.Clear()
            TXTAMT.Clear()

            CMBITEMCODE.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgridscan()
        Try
            If GRIDUPLOADDOUBLECLICK = False Then

                gridupload.Rows.Add(Val(txtuploadsrno.Text.Trim), txtuploadremarks.Text.Trim, txtuploadname.Text.Trim, txtimgpath.Text.Trim, TXTNEWIMGPATH.Text.Trim, TXTFILENAME.Text.Trim)
                uploadgetsrno(gridupload)

            ElseIf GRIDUPLOADDOUBLECLICK = True Then

                gridupload.Item(0, TEMPUPLOADROW).Value = txtuploadsrno.Text.Trim
                gridupload.Item(1, TEMPUPLOADROW).Value = txtuploadremarks.Text.Trim
                gridupload.Item(2, TEMPUPLOADROW).Value = txtuploadname.Text.Trim
                gridupload.Item(3, TEMPUPLOADROW).Value = txtimgpath.Text.Trim
                gridupload.Item(GNEWIMGPATH.Index, TEMPUPLOADROW).Value = TXTNEWIMGPATH.Text.Trim
                gridupload.Item(GFILENAME.Index, TEMPUPLOADROW).Value = TXTFILENAME.Text.Trim

                GRIDUPLOADDOUBLECLICK = False

            End If
            gridupload.FirstDisplayedScrollingRowIndex = gridupload.RowCount - 1
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click

        If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png;*.pdf)|*.bmp;*.jpeg;*.png;*.pdf"
        OpenFileDialog1.ShowDialog()

        OpenFileDialog1.AddExtension = True
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        txtimgpath.Text = OpenFileDialog1.FileName
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & TXTSALRETNO.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then
            PBSoftCopy.ImageLocation = txtimgpath.Text.Trim
            PBSoftCopy.Load(txtimgpath.Text.Trim)
            txtuploadsrno.Focus()
        End If
    End Sub

    Private Sub txtuploadname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuploadname.Validating
        Try
            If txtimgpath.Text.Trim <> "" And txtuploadname.Text.Trim <> "" Then
                fillgridscan()
                txtuploadremarks.Clear()
                txtuploadname.Clear()
                txtimgpath.Clear()
                PBSoftCopy.ImageLocation = ""
                txtuploadsrno.Focus()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridupload_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
        Try
            If gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value <> Nothing Then
                GRIDUPLOADDOUBLECLICK = True
                TEMPUPLOADROW = e.RowIndex
                txtuploadsrno.Text = gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value
                txtuploadremarks.Text = gridupload.Rows(e.RowIndex).Cells(GREMARKS.Index).Value
                txtuploadname.Text = gridupload.Rows(e.RowIndex).Cells(GNAME.Index).Value
                txtimgpath.Text = gridupload.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
                TXTNEWIMGPATH.Text = gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value
                TXTFILENAME.Text = gridupload.Rows(e.RowIndex).Cells(GFILENAME.Index).Value
                txtuploadsrno.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridupload.KeyDown
        If e.KeyCode = Keys.Delete And gridupload.RowCount > 0 Then
            Dim TEMPMSG As Integer = MsgBox("This Will Delete File, Wish to Proceed?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                If FileIO.FileSystem.FileExists(gridupload.Rows(gridupload.CurrentRow.Index).Cells(GNEWIMGPATH.Index).Value) Then FileIO.FileSystem.DeleteFile(gridupload.Rows(gridupload.CurrentRow.Index).Cells(GNEWIMGPATH.Index).Value)
                gridupload.Rows.RemoveAt(gridupload.CurrentRow.Index)
                uploadgetsrno(gridupload)
            End If
        End If
    End Sub

    Private Sub gridupload_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If gridupload.RowCount > 0 Then
                If Not FileIO.FileSystem.FileExists(gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value) Then
                    PBSoftCopy.ImageLocation = gridupload.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
                Else
                    PBSoftCopy.ImageLocation = gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtuploadsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtuploadsrno.GotFocus
        If GRIDUPLOADDOUBLECLICK = False Then
            If gridupload.RowCount > 0 Then
                txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(GGRIDUPLOADSRNO.Index).Value) + 1
            Else
                txtuploadsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub GRIDSALRET_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSALRET.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor
            GRIDSALRET.RowCount = 0
LINE1:
            TEMPSALRETNO = Val(TXTSALRETNO.Text) - 1
            If TEMPSALRETNO > 0 Then
                EDIT = True
                SaleReturn_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDSALRET.RowCount = 0 And TEMPSALRETNO > 1 Then
                TXTSALRETNO.Text = TEMPSALRETNO
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
            GRIDSALRET.RowCount = 0
LINE1:
            TEMPSALRETNO = Val(TXTSALRETNO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTSALRETNO.Text.Trim
            CLEAR()
            If Val(TXTSALRETNO.Text) - 1 >= TEMPSALRETNO Then
                EDIT = True
                SaleReturn_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDSALRET.RowCount = 0 And TEMPSALRETNO < MAXNO Then
                TXTSALRETNO.Text = TEMPSALRETNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress
        numkeypress(e, txtqty, Me)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Dim IntResult As Integer
        Try

            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Return Receipt Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If Convert.ToDateTime(SALRETDATE.Text).Date < CNBLOCKDATE.Date Then
                    MsgBox("Date is Blocked, Please Delete entries after " & Format(CNBLOCKDATE.Date, "dd/MM/yyyy"), MsgBoxStyle.Critical)
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Delete Return Receipt?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTSALRETNO.Text.Trim)
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(Userid)
                    alParaval.Add(YearId)

                    Dim OBJPURCH As New ClsSaleReturn()
                    OBJPURCH.alParaval = alParaval
                    IntResult = OBJPURCH.Delete()
                    MsgBox("Return Receipt Deleted")
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


    Private Sub GRIDSALRET_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDSALRET.CellValidating
        Try
            Dim colNum As Integer = GRIDSALRET.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GRATE.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDSALRET.CurrentCell.Value = Nothing Then GRIDSALRET.CurrentCell.Value = "0.00"
                        GRIDSALRET.CurrentCell.Value = Convert.ToDecimal(GRIDSALRET.Item(colNum, e.RowIndex).Value)
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
            If lbllocked.Visible = True Then
                GRIDDOUBLECLICK = False
                Exit Sub
            End If

            If GRIDSALRET.CurrentRow.Index >= 0 And GRIDSALRET.Item(gsrno.Index, GRIDSALRET.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                txtsrno.Text = GRIDSALRET.Item(gsrno.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                CMBITEMCODE.Text = GRIDSALRET.Item(GITEMCODE.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                cmbitemname.Text = GRIDSALRET.Item(gitemname.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                TXTHSNCODE.Text = GRIDSALRET.Item(GHSNCODE.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                TXTMATERIALCODE.Text = GRIDSALRET.Item(GMATERIALCODE.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                txtqty.Text = GRIDSALRET.Item(gQty.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                TXTBATCHNO.Text = GRIDSALRET.Item(GBATCHNO.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                TXTSHIPPERS.Text = GRIDSALRET.Item(GSHIPPERS.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                TXTPACKETS.Text = GRIDSALRET.Item(GPACKETS.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                TXTRATE.Text = GRIDSALRET.Item(GRATE.Index, GRIDSALRET.CurrentRow.Index).Value.ToString
                TXTAMT.Text = GRIDSALRET.Item(GAMT.Index, GRIDSALRET.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDSALRET.CurrentRow.Index
                txtsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSALRET_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSALRET.KeyDown

        Try
            If e.KeyCode = Keys.Delete And GRIDSALRET.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                If e.KeyCode = Keys.Delete And Val(GRIDSALRET.CurrentRow.Cells(GOUTQTY.Index).Value) > 0 Then
                    Exit Sub
                End If

                'end of block
                GRIDSALRET.Rows.RemoveAt(GRIDSALRET.CurrentRow.Index)
                getsrno(GRIDSALRET)
                TOTAL()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            ElseIf e.KeyCode = Keys.F12 And GRIDSALRET.RowCount > 0 Then
                If GRIDSALRET.CurrentRow.Cells(gitemname.Index).Value <> "" Then GRIDSALRET.Rows.Add(CloneWithValues(GRIDSALRET.CurrentRow))

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Public Function CloneWithValues(ByVal row As DataGridViewRow) As DataGridViewRow
        CloneWithValues = CType(row.Clone(), DataGridViewRow)
        For index As Int32 = 0 To row.Cells.Count - 1
            CloneWithValues.Cells(index).Value = row.Cells(index).Value
        Next
    End Function


    Private Sub CMBPACKING_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPACKING.Enter
        Try
            If ClientName = "AVIS" Then
                If CMBPACKING.Text.Trim = "" Then fillname(CMBPACKING, EDIT, " And (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')  AND GROUP_NAME = 'HASTE DEBTORS' AND ACC_TYPE = 'ACCOUNTS'")
            Else
                If CMBPACKING.Text.Trim = "" Then fillname(CMBPACKING, EDIT, " And (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')   AND ACC_TYPE = 'ACCOUNTS'")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPACKING_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPACKING.Validating
        Try
            If CMBPACKING.Text.Trim <> "" Then namevalidate(CMBPACKING, CMBCODE, e, Me, txtadd, " AND  (GROUP_SECONDARY = 'SUNDRY DEBTORS' OR GROUP_SECONDARY = 'SUNDRY CREDITORS')", "Sundry Creditors", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            'If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' OR GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND GROUPMASTER.GROUP_NAME <> 'HASTE DEBTORS' ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "Sundry debtors", "ACCOUNTS", cmbtrans.Text, CMBAGENT.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If txtimgpath.Text.Trim <> "" Then
                If Path.GetExtension(txtimgpath.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(txtimgpath.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.ImageLocation = PBSoftCopy.ImageLocation
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then fillITEMNAME(cmbitemname, EDIT, " and ITEMMASTER.ITEM_MATERIALTYPE = 'FINISHED'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then ITEMNAMEVALIDATE(cmbitemname, e, Me, " and ITEMMASTER.ITEM_MATERIALTYPE = 'FINISHED'")
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
                'OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' or GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS"
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCUT_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        CALC()
    End Sub

    Private Sub txtqty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtqty.Validated
        CALC()
    End Sub

    Sub CALC()
        Try
            TXTAMT.Text = 0.0
            TXTCGSTAMT.Text = 0.0
            TXTSGSTAMT.Text = 0.0
            TXTIGSTAMT.Text = 0.0
            'If Val(txtqty.Text.Trim) > 0 Then TXTMTRS.Text = Format(Val(txtqty.Text.Trim) * Val(TXTCUT.Text.Trim), "0.00")
            If Val(TXTRATE.Text.Trim) > 0 Then

                TXTAMT.Text = Format(Val(txtqty.Text.Trim) * Val(TXTRATE.Text.Trim), "0.00")
            End If
            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub cmbGodown_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbGodown.KeyDown
    '        Try
    '            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
    '            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

    '            If e.KeyCode = Keys.F1 Then
    '                Dim OBJGODOWN As New SelectGodown
    '                OBJGODOWN.FRMSTRING = "GODOWN"
    '                OBJGODOWN.ShowDialog()
    '                If OBJGODOWN.TEMPNAME <> "" Then cmbGodown.Text = OBJGODOWN.TEMPNAME
    '            End If
    '        Catch ex As Exception
    '            Throw ex
    '        End Try
    '    End Sub



    'Private Sub cmbitemname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbitemname.KeyDown
    '    Try
    '        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
    '        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

    '        If e.KeyCode = Keys.F1 Then
    '            Dim OBJItem As New SelectItem
    '            OBJItem.FRMSTRING = "MERCHANT"
    '            OBJItem.STRSEARCH = " and ITEM_cmpid = " & CmpId & " and ITEM_LOCATIONid = " & Locationid & " and ITEM_YEARid = " & YearId
    '            OBJItem.ShowDialog()
    '            If OBJItem.TEMPNAME <> "" Then cmbitemname.Text = OBJItem.TEMPNAME
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

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

    Private Sub CMDSELECTRET_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTRET.Click
        Try
            If CMBNAME.Text.Trim = "" Then
                MsgBox("Please Select Party name First", MsgBoxStyle.Critical)
                CMBNAME.Focus()
                Exit Sub
            End If

            Dim DTRET As New DataTable
            ''Dim OBJSELECTRET As New SelectInvoiceForReturn
            'If ClientName <> "SVS" Then OBJSELECTRET.PARTYNAME = CMBNAME.Text.Trim
            '    OBJSELECTRET.ShowDialog()
            '    DTRET = OBJSELECTRET.DT

            If DTRET.Rows.Count > 0 Then

                Dim objclspreq As New ClsCommon()
                'Dim DT As DataTable = objclspreq.search(" DISTINCT  ISNULL(INVOICEMASTER.INVOICE_NO, 0) AS INVNO, ISNULL(INVOICEMASTER.INVOICE_DATE, GETDATE()) AS INVDATE, ISNULL(INVOICEMASTER.INVOICE_GDNNO, '') AS GDNNO, ISNULL(INVOICEMASTER.INVOICE_GDNDATE, GETDATE()) AS GDNDATE, ISNULL(ITEMMASTER.item_name, '') AS ITEM, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(INVOICEMASTER_DESC.INVOICE_PCS, 0) AS PCS, ISNULL(INVOICEMASTER_DESC.INVOICE_MTRS, 0) AS MTRS, ISNULL(INVOICEMASTER_DESC.INVOICE_RATE, 0) AS RATE, ISNULL(INVOICEMASTER_DESC.INVOICE_PER, '') AS PER, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(INVOICEMASTER.INVOICE_TOTALPCS, 0) AS TOTALPCS, ISNULL(INVOICEMASTER.INVOICE_TOTALMTRS, 0) AS TOTALMTRS ", "", " ITEMMASTER INNER JOIN INVOICEMASTER_DESC ON ITEMMASTER.item_id = INVOICEMASTER_DESC.INVOICE_ITEMID INNER JOIN INVOICEMASTER ON INVOICEMASTER_DESC.INVOICE_NO = INVOICEMASTER.INVOICE_NO AND INVOICEMASTER_DESC.INVOICE_YEARID = INVOICEMASTER.INVOICE_YEARID INNER JOIN QUALITYMASTER ON INVOICEMASTER_DESC.INVOICE_QUALITYID = QUALITYMASTER.QUALITY_id INNER JOIN DESIGNMASTER ON INVOICEMASTER_DESC.INVOICE_DESIGNID = DESIGNMASTER.DESIGN_id INNER JOIN COLORMASTER ON INVOICEMASTER_DESC.INVOICE_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id ", "  AND INVOICEMASTER.INVOICE_NO =" & Val(DTRET.Rows(0).Item("INVNO")) & "  AND INVOICEMASTER.INVOICE_REGISTERID =" & Val(DTRET.Rows(0).Item("REGID")) & "  AND INVOICEMASTER.INVOICE_YEARID = " & YearId & " AND INVOICEMASTER.INVOICE_RETURN = " & 0 & " ORDER BY INVNO")
                Dim DT As New DataTable

                If DTRET.Rows(0).Item("INVOICETYPE") = "INVOICE" Then
                    DT = objclspreq.search(" ISNULL(INVOICEMASTER.INVOICE_NO, 0) AS INVNO, ISNULL(INVOICEMASTER.INVOICE_INITIALS, 0) AS INVINITIALS, ISNULL(INVOICEMASTER.INVOICE_DATE, GETDATE()) AS INVDATE, ISNULL(INVOICEMASTER.INVOICE_GDNNO, '') AS GDNNO, ISNULL(INVOICEMASTER.INVOICE_GDNDATE, GETDATE()) AS GDNDATE, ISNULL(ITEMMASTER.item_name, '') AS ITEM, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(INVOICEMASTER_DESC.INVOICE_PCS, 0) AS PCS, ISNULL(INVOICEMASTER_DESC.INVOICE_MTRS, 0) AS MTRS, ISNULL(INVOICEMASTER_DESC.INVOICE_RATE, 0) AS RATE, ISNULL(INVOICEMASTER_DESC.INVOICE_PER, '') AS PER, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(INVOICEMASTER.INVOICE_TOTALPCS, 0) AS TOTALPCS, ISNULL(INVOICEMASTER.INVOICE_TOTALMTRS, 0) AS TOTALMTRS, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER,  ISNULL(REGISTERMASTER.register_name, '') AS INVREGNAME,ISNULL(AGENTLEDGERS.Acc_cmpname, '') AS AGENT, ISNULL(INVOICEMASTER_DESC.INVOICE_BALENO,'') AS BALENO, REGLEDGERS.Acc_cmpname AS DEBITLEDGER ", "", " ITEMMASTER INNER JOIN INVOICEMASTER_DESC ON ITEMMASTER.item_id = INVOICEMASTER_DESC.INVOICE_ITEMID INNER JOIN INVOICEMASTER ON INVOICEMASTER_DESC.INVOICE_NO = INVOICEMASTER.INVOICE_NO AND INVOICEMASTER_DESC.INVOICE_REGISTERID = INVOICEMASTER.INVOICE_REGISTERID AND INVOICEMASTER_DESC.INVOICE_YEARID = INVOICEMASTER.INVOICE_YEARID INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN COLORMASTER ON INVOICEMASTER_DESC.INVOICE_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNMASTER ON INVOICEMASTER_DESC.INVOICE_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON INVOICEMASTER_DESC.INVOICE_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.register_id  INNER JOIN LEDGERS AS REGLEDGERS ON REGISTERMASTER.register_abbr = REGLEDGERS.Acc_cmpname AND REGISTERMASTER.register_yearid = REGLEDGERS.Acc_yearid LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON INVOICEMASTER.INVOICE_AGENTID = AGENTLEDGERS.Acc_id ", "  AND INVOICEMASTER.INVOICE_NO =" & Val(DTRET.Rows(0).Item("INVNO")) & "  AND INVOICEMASTER.INVOICE_REGISTERID =" & Val(DTRET.Rows(0).Item("REGID")) & "  AND INVOICEMASTER.INVOICE_YEARID = " & YearId & " ORDER BY INVNO")
                Else
                    DT = objclspreq.search(" ISNULL(OPENINGBILL.BILL_NO, 0) AS INVNO, ISNULL(OPENINGBILL.BILL_INITIALS, 0) AS INVINITIALS, ISNULL(OPENINGBILL.BILL_DATE, GETDATE()) AS INVDATE, 0 AS GDNNO, ISNULL(OPENINGBILL.BILL_DATE, GETDATE()) AS GDNDATE, '' AS ITEM, '' AS HSNCODE, '' AS QUALITY, '' AS DESIGN, '' AS COLOR, 0 AS PCS, 0 AS MTRS, 0 AS RATE, 'Mtrs' AS PER, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, 0 AS TOTALPCS, 0 AS TOTALMTRS, 0 AS CGSTPER, 0 AS SGSTPER, 0 AS IGSTPER,  ISNULL(REGISTERMASTER.register_name, '') AS INVREGNAME , ISNULL(AGENTLEDGERS.Acc_cmpname, '') AS AGENT, '' AS BALENO, REGLEDGERS.Acc_cmpname AS DEBITLEDGER ", "", " OPENINGBILL INNER JOIN LEDGERS ON OPENINGBILL.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON OPENINGBILL.BILL_REGISTERID = REGISTERMASTER.register_id  INNER JOIN LEDGERS AS REGLEDGERS ON REGISTERMASTER.register_abbr = REGLEDGERS.Acc_cmpname AND REGISTERMASTER.register_yearid = REGLEDGERS.Acc_yearid  LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON OPENINGBILL.BILL_AGENTID = AGENTLEDGERS.Acc_id", "  AND OPENINGBILL.BILL_INITIALS = '" & DTRET.Rows(0).Item("INVINITIALS") & "' AND OPENINGBILL.BILL_NO =" & Val(DTRET.Rows(0).Item("INVNO")) & "  AND OPENINGBILL.BILL_REGISTERID =" & Val(DTRET.Rows(0).Item("REGID")) & "  AND OPENINGBILL.BILL_YEARID = " & YearId & " ORDER BY INVNO")
                End If
                TXTINVNO.Text = DT.Rows(0).Item("INVNO")
                TXTINVINITIALS.Text = DT.Rows(0).Item("INVINITIALS")
                TXTINVREGNAME.Text = DT.Rows(0).Item("INVREGNAME")
                CMBDEBITLEDGER.Text = DT.Rows(0).Item("DEBITLEDGER")
                TXTINVTYPE.Text = DTRET.Rows(0).Item("INVOICETYPE")
                INVDATE.Text = DT.Rows(0).Item("INVDATE")
                TXTCHALLANNO.Text = DT.Rows(0).Item("GDNNO")
                CHALLANDATE.Text = DT.Rows(0).Item("GDNDATE")
                CMBAGENT.Text = DT.Rows(0).Item("AGENT")

                If TXTINVTYPE.Text.Trim = "INVOICE" And ClientName <> "AVIS" And ClientName <> "SUPRIYA" Then
                    Dim SNO As Integer = 0
                    For Each DTROWPS As DataRow In DT.Rows
                        If EDIT = False Then
                            'GRIDSALRET.Rows.Add(0, "", DTROWPS("ITEM"), DTROWPS("HSNCODE"), DTROWPS("QUALITY"), DTROWPS("DESIGN"), DTROWPS("COLOR"), "0.00", "0.00", Format(Val(DTROWPS("PCS")), "0.00"), "Mtrs", Format(Val(DTROWPS("MTRS")), "0.00"), 0, DTROWPS("PER"), 0, "", "", "SR-" & Val(TXTSALRETNO.Text.Trim) & "/" & SNO + 1 & "/" & YearId, DTROWPS("GDNBARCODE"), 0, 0, 0, DTROWPS("GDNNO"), DTROWPS("SRNO"))
                            GRIDSALRET.Rows.Add(0, "FRESH", DTROWPS("ITEM"), DTROWPS("HSNCODE"), DTROWPS("QUALITY"), DTROWPS("DESIGN"), DTROWPS("COLOR"), DTROWPS("BALENO"), "0.00", "0.00", Format(Val(DTROWPS("PCS")), "0.00"), "Pcs", Format(Val(DTROWPS("MTRS")), "0.00"), Val(DTROWPS("RATE")), DTROWPS("PER"), 0, "", "", "SR-" & Val(TXTSALRETNO.Text.Trim) & "/" & SNO + 1 & "/" & YearId, "", 0, 0, 0, DTROWPS("INVNO"), "")

                        Else
                            GRIDSALRET.Rows.Add(0, "FRESH", DTROWPS("ITEM"), DTROWPS("HSNCODE"), DTROWPS("QUALITY"), DTROWPS("DESIGN"), DTROWPS("COLOR"), DTROWPS("BALENO"), "0.00", "0.00", Format(Val(DTROWPS("PCS")), "0.00"), "Pcs", Format(Val(DTROWPS("MTRS")), "0.00"), Val(DTROWPS("RATE")), DTROWPS("PER"), 0, "", "", "SR-" & Val(TXTSALRETNO.Text.Trim) & "/" & GRIDSALRET.RowCount + 1 & "/" & YearId, "", 0, 0, 0, DTROWPS("INVNO"), DTROWPS("INVNO"))
                        End If
                        SNO += 1

                        If DTROWPS("ITEM").ToString <> "" And Convert.ToDateTime(SALRETDATE.Text).Date >= "01/07/2017" Then
                            If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                TXTCGSTPER.Text = Val(DTROWPS("CGSTPER"))
                                TXTSGSTPER.Text = Val(DTROWPS("SGSTPER"))
                                TXTIGSTPER.Text = 0
                            Else
                                TXTCGSTPER.Text = 0
                                TXTSGSTPER.Text = 0
                                TXTIGSTPER.Text = Val(DTROWPS("IGSTPER"))
                            End If
                        End If
                    Next
                    getsrno(GRIDSALRET)
                    TOTAL()
                End If


                'CHARGES GRID

                Dim dttable As DataTable = objclspreq.search(" INVOICEMASTER_CHGS.INVOICE_gridsrno AS GRIDSRNO, LEDGERS.Acc_cmpname AS CHARGES, INVOICEMASTER_CHGS.INVOICE_PER AS PER, INVOICEMASTER_CHGS.INVOICE_AMT AS AMT, INVOICEMASTER_CHGS.INVOICE_TAXID AS TAXID ", "", " INVOICEMASTER_CHGS INNER JOIN LEDGERS ON INVOICEMASTER_CHGS.INVOICE_CHARGESID = LEDGERS.Acc_id INNER JOIN REGISTERMASTER ON INVOICEMASTER_CHGS.INVOICE_REGISTERID = REGISTERMASTER.register_id ", " AND INVOICEMASTER_CHGS.INVOICE_NO =" & Val(DTRET.Rows(0).Item("INVNO")) & "  AND INVOICEMASTER_CHGS.INVOICE_REGISTERID =" & Val(DTRET.Rows(0).Item("REGID")) & "  AND INVOICEMASTER_CHGS.INVOICE_YEARID = " & YearId & " ORDER BY INVOICEMASTER_CHGS.INVOICE_gridsrno")
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        GRIDCHGS.Rows.Add(DTR("GRIDSRNO"), DTR("CHARGES"), DTR("PER"), 0, DTR("TAXID"))
                    Next
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal SRNO As Integer)
        Try
            TEMPMSG = MsgBox("Wish to Print Sale Return?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJPUR As New SaleReturnDesign
                OBJPUR.MdiParent = MDIMain
                OBJPUR.FRMSTRING = "SALERETURN"
                OBJPUR.SALRETNO = Val(SRNO)
                OBJPUR.WHERECLAUSE = "{SALERETURN.SALRET_NO}=" & Val(SRNO) & " and {SALERETURN.SALRET_yearid}=" & YearId
                OBJPUR.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then
                PRINTREPORT(TEMPSALRETNO)
                'PRINTBARCODE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTRATE.Validated
        If CMBITEMCODE.Text.Trim <> "" And cmbitemname.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 Then
            fillgrid()
            CALC()
            TOTAL()
        Else
            If CMBITEMCODE.Text.Trim = "" Then
                MsgBox("Enter Itemcode", MsgBoxStyle.Critical)
                CMBITEMCODE.Focus()
            ElseIf cmbitemname.Text.Trim = "" Then
                MsgBox("Enter Item Name", MsgBoxStyle.Critical)
                cmbitemname.Focus()
            ElseIf Val(txtqty.Text.Trim) = 0 Then
                MsgBox("Enter Quantity", MsgBoxStyle.Critical)
                txtqty.Focus()
            End If
        End If
    End Sub

    Private Sub TXTRATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTRATE.Validating
        Try
            If TXTRATE.Text = "" Or Val(TXTRATE.Text) < 0 Then TXTAMT.ReadOnly = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress, TXTADJAMT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub SALRETDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SALRETDATE.GotFocus
        SALRETDATE.SelectionStart = 0
    End Sub

    Private Sub SALRETDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SALRETDATE.Validating
        Try
            If SALRETDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(SALRETDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHALLANNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCHALLANNO.Validating
        Try
            If Convert.ToDateTime(SALRETDATE.Text).Date < "01/07/2017" Then
                If TXTCHALLANNO.Text.Trim.Length > 0 Then
                    If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(TXTCHALLANNO.Text.Trim)) Then
                        'for search
                        Dim objclscommon As New ClsCommon()
                        Dim dt As DataTable = objclscommon.search(" SALRET_challanno, LEDGERS.ACC_cmpname", "", " SALERETURN inner join LEDGERS on LEDGERS.ACC_id = SALRET_ledgerid ", " and SALRET_challanno = '" & TXTCHALLANNO.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & CMBNAME.Text.Trim & "' AND SALRET_YEARID =" & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Challan No. Already Exists", MsgBoxStyle.Critical, "TEXTRADE")
                            e.Cancel = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub GETHSNCODE()
        Try


            Dim OBJCMN As New ClsCommon
            Dim DT = OBJCMN.search("  ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER ", "", "HSNMASTER INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND ITEMMASTER.ITEM_NAME= '" & cmbitemname.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
            'Dim DT As DataTable = OBJCMN.search(" TOP 1 ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER_DESC.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST, 0) AS IGSTPER,  ISNULL(HSNMASTER_DESC.HSN_EXPCGST, 0) AS EXPCGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPSGST, 0) AS EXPSGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPIGST, 0) AS EXPIGSTPER ", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(ACTUALINVDATE.Text).Date, "MM/dd/yyyy") & "' AND ITEMMASTER.ITEM_NAME= '" & cmbitemname.Text.Trim & "' AND HSNMASTER.HSN_YEARID=" & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")
            If DT.Rows.Count > 0 Then

                TXTHSNCODE.Clear()
                TXTCGSTPER.Clear()
                TXTCGSTAMT.Clear()
                TXTSGSTPER.Clear()
                TXTSGSTAMT.Clear()
                TXTIGSTPER.Clear()
                TXTIGSTAMT.Clear()

                TXTHSNCODE.Text = DT.Rows(0).Item("HSNCODE")
                If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                    TXTIGSTPER.Text = 0

                    If CHKEXPORTGST.CheckState = CheckState.Unchecked Then
                        TXTCGSTPER.Text = Val(DT.Rows(0).Item("CGSTPER"))
                        TXTSGSTPER.Text = Val(DT.Rows(0).Item("SGSTPER"))
                    Else
                        TXTCGSTPER.Text = Val(DT.Rows(0).Item("EXPCGSTPER"))
                        TXTSGSTPER.Text = Val(DT.Rows(0).Item("EXPSGSTPER"))
                    End If

                Else
                    TXTCGSTPER.Text = 0
                    TXTSGSTPER.Text = 0
                    If CHKEXPORTGST.CheckState = CheckState.Unchecked Then
                        TXTIGSTPER.Text = Val(DT.Rows(0).Item("IGSTPER"))
                    Else
                        TXTIGSTPER.Text = Val(DT.Rows(0).Item("EXPIGSTPER"))
                    End If
                End If
            End If
            CALC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then
                'GET REGISTER , AGENCT AND TRANS
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(LEDGERS_1.ACC_CMPNAME,'') AS TRANSNAME,ISNULL(LEDGERS_2.ACC_CMPNAME,'') AS AGENTNAME, ISNULL(REGISTER_NAME,'') AS REGISTERNAME, ISNULL(STATEMASTER.state_remark, '') AS STATECODE, ISNULL(LEDGERS.ACC_GSTIN,'') AS GSTIN ,ISNULL(CITYMASTER.CITY_NAME,'') AS CITYNAME ", "", "LEDGERS LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_1.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_1.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_2.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_2.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_2.Acc_yearid LEFT OUTER JOIN REGISTERMASTER ON LEDGERS.Acc_cmpid = REGISTERMASTER.register_cmpid AND LEDGERS.Acc_locationid = REGISTERMASTER.register_locationid AND LEDGERS.Acc_yearid = REGISTERMASTER.register_yearid AND LEDGERS.ACC_REGISTERID = REGISTERMASTER.register_id LEFT OUTER JOIN CITYMASTER ON LEDGERS.Acc_cityid = CITYMASTER.city_id ", " and LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTSTATECODE.Text = DT.Rows(0).Item("STATECODE")
                    TXTGSTIN.Text = DT.Rows(0).Item("GSTIN")
                    City.Text = DT.Rows(0).Item("CITYNAME")
                    cmbtrans.Text = DT.Rows(0).Item("TRANSNAME")
                    CMBAGENT.Text = DT.Rows(0).Item("AGENTNAME")
                End If
                GETHSNCODE()
                FILLGRIDINVOICE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDINVOICE()
        Try
            GRIDBILL.DataSource = Nothing
            TXTINVTOTAL.Clear()
            Dim objpayment As New ClsReceiptMaster
            Dim DT As New DataTable
            DT = objpayment.GETBILLS(CmpId, CMBNAME.Text.Trim, Locationid, YearId, Convert.ToDateTime(SALRETDATE.Text).Date)
            If DT.Rows.Count > 0 Then SETGRIDINVOICE(DT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SETGRIDINVOICE(ByVal DT As DataTable)
        Try
            'FOR ADDING NEW CHKCOL IN GRIDBILL

            DT.DefaultView.Sort = "BILLTYPE, BILLNO ASC"
            GRIDBILL.DataSource = DT
            If a = 0 Then
                GRIDBILL.Columns.Insert(0, col)
                a = 1
            End If
            Dim i As Integer = 0

            GRIDBILL.Columns(i).Width = 40
            GRIDBILL.Columns(i).Name = "INVCHK"
            GRIDBILL.Columns(i).HeaderText = ""
            GRIDBILL.Columns(i).ReadOnly = True
            i += 1

            GRIDBILL.Columns(i).Width = 100
            GRIDBILL.Columns(i).Name = "INVBILLINITIALS"
            GRIDBILL.Columns(i).HeaderText = "Bill No."
            GRIDBILL.Columns(i).ReadOnly = True
            i += 1

            GRIDBILL.Columns(i).Width = 80
            GRIDBILL.Columns(i).Name = "REFNO"
            GRIDBILL.Columns(i).HeaderText = "Ref No"
            GRIDBILL.Columns(i).ReadOnly = True
            i += 1

            GRIDBILL.Columns(i).Width = 80
            GRIDBILL.Columns(i).Name = "INVBILLDATE"
            GRIDBILL.Columns(i).HeaderText = "Bill Date"
            GRIDBILL.Columns(i).ReadOnly = True
            i += 1

            GRIDBILL.Columns(i).Width = 100
            GRIDBILL.Columns(i).Name = "INVBALAMT"
            GRIDBILL.Columns(i).HeaderText = "Bal. Amt"
            GRIDBILL.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GRIDBILL.Columns(i).DefaultCellStyle.Format = "N2"
            GRIDBILL.Columns(i).ReadOnly = True
            i += 1

            GRIDBILL.Columns(i).Width = 100
            GRIDBILL.Columns(i).Name = "INVBILLAMT"
            GRIDBILL.Columns(i).HeaderText = "Bill Amt"
            GRIDBILL.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GRIDBILL.Columns(i).DefaultCellStyle.Format = "N2"
            GRIDBILL.Columns(i).ReadOnly = True
            i += 1

            GRIDBILL.Columns(i).Visible = False
            GRIDBILL.Columns(i).Name = "INVBILLTYPE"
            i += 1

            GRIDBILL.Columns(i).Visible = False
            GRIDBILL.Columns(i).Name = "INVBILLNO"
            i += 1

            GRIDBILL.Columns(i).Visible = False
            GRIDBILL.Columns(i).Name = "INVREGNAME"
            i += 1

            GRIDBILL.Columns(i).Visible = False
            GRIDBILL.Columns(i).Name = "INVCUSNAME"
            i += 1

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCHARGES.Enter
        Try
            If CMBCHARGES.Text.Trim = "" Then fillname(CMBCHARGES, EDIT, " and (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Sales A/C' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCHARGES.Validated
        Try
            If CMBCHARGES.Text.Trim <> "" Then
                filltax()

                'GET ADDLESS DONE BY GULKIT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(LEDGERS.ACC_ADDLESS,'ADD') AS ADDLESS ", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBCHARGES.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If UCase(DT.Rows(0).Item("ADDLESS")) = "LESS" Then
                        If Val(TXTCHGSPER.Text.Trim) = 0 Then TXTCHGSPER.Text = "-"
                        If Val(TXTCHGSAMT.Text.Trim) = 0 Then TXTCHGSAMT.Text = "-"
                        TXTCHGSPER.Select(TXTCHGSPER.Text.Length, 0)
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub filltax()
        Try
            TXTCHGSPER.ReadOnly = False
            TXTCHGSAMT.ReadOnly = False
            TXTTAXID.Text = 0
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable = objclscommon.search(" ISNULL(tax_tax, 0) as TAX, TAX_ID AS TAXID ", "", " TAXMASTER", " AND tax_name = '" & CMBCHARGES.Text & "'  AND tax_cmpid=" & CmpId & " AND tax_LOCATIONID = " & Locationid & " AND tax_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                TXTCHGSPER.Text = dt.Rows(0).Item("TAX")
                TXTTAXID.Text = Val(dt.Rows(0).Item("TAXID"))
                If Val(TXTCHGSPER.Text.Trim) > 0 Then TXTCHGSAMT.ReadOnly = True
                TXTCHGSPER.ReadOnly = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCHARGES.Validating
        Try
            If CMBCHARGES.Text.Trim <> "" Then namevalidate(CMBCHARGES, CMBCODE, e, Me, TXTTRANSADD, " AND (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Sales A/C' )")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHGSAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCHGSAMT.KeyPress
        Try
            AMOUNTNUMDOTKYEPRESS(e, TXTCHGSAMT, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub AMOUNTNUMDOTKYEPRESS(ByVal han As KeyPressEventArgs, ByVal sen As Control, ByVal frm As System.Windows.Forms.Form)
        Try
            Dim mypos As Integer

            If AscW(han.KeyChar) >= 48 And AscW(han.KeyChar) <= 57 Or AscW(han.KeyChar) = 8 Or AscW(han.KeyChar) = 45 Then
                han.KeyChar = han.KeyChar
            ElseIf AscW(han.KeyChar) = 46 Or AscW(han.KeyChar) = 45 Then
                mypos = InStr(1, sen.Text, ".")
                If mypos = 0 Then
                    han.KeyChar = han.KeyChar
                Else
                    han.KeyChar = ""
                End If
            Else
                han.KeyChar = ""
            End If

            If AscW(han.KeyChar) = Keys.Escape Then
                frm.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHGSAMT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCHGSAMT.Validating
        Try
            If CMBCHARGES.Text.Trim <> "" And Val(TXTCHGSAMT.Text.Trim) <> 0 Then
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(TXTCHGSAMT.Text.Trim, dDebit)
                If bValid Then
                    TXTCHGSAMT.Text = Convert.ToDecimal(Val(TXTCHGSAMT.Text))
                    ' everything is good
                    fillchgsgrid()
                    TOTAL()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    'e.Cancel = True
                    TXTCHGSAMT.Clear()
                    TXTCHGSAMT.Focus()
                    Exit Sub
                End If
            Else
                If CMBCHARGES.Text.Trim = "" Then
                    MsgBox("Please Fill Charges Name ")
                    CMBCHARGES.Focus()
                    Exit Sub
                ElseIf Val(TXTCHGSPER.Text.Trim) = 0 And Val(TXTCHGSAMT.Text.Trim) = 0 Then
                    MsgBox("Amount can not be zero")
                    TXTCHGSAMT.Clear()
                    TXTCHGSAMT.Focus()
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillchgsgrid()
        If GRIDCHGSDOUBLECLICK = False Then
            GRIDCHGS.Rows.Add(Val(TXTCHGSSRNO.Text.Trim), CMBCHARGES.Text.Trim, Val(TXTCHGSPER.Text.Trim), Val(TXTCHGSAMT.Text.Trim), Val(TXTTAXID.Text.Trim))
            getsrno(GRIDCHGS)
        ElseIf GRIDCHGSDOUBLECLICK = True Then
            GRIDCHGS.Item(ESRNO.Index, TEMPCHGSROW).Value = Val(TXTCHGSSRNO.Text.Trim)
            GRIDCHGS.Item(ECHARGES.Index, TEMPCHGSROW).Value = CMBCHARGES.Text.Trim
            GRIDCHGS.Item(EPER.Index, TEMPCHGSROW).Value = Format(Val(TXTCHGSPER.Text.Trim), "0.00")
            GRIDCHGS.Item(EAMT.Index, TEMPCHGSROW).Value = Format(Val(TXTCHGSAMT.Text.Trim), "0.00")
            GRIDCHGS.Item(ETAXID.Index, TEMPCHGSROW).Value = Format(Val(TXTTAXID.Text.Trim))

            GRIDCHGSDOUBLECLICK = False

        End If
        TOTAL()

        GRIDCHGS.FirstDisplayedScrollingRowIndex = GRIDCHGS.RowCount - 1

        TXTCHGSSRNO.Clear()
        CMBCHARGES.Text = ""
        TXTCHGSPER.Clear()
        TXTCHGSAMT.Clear()
        TXTTAXID.Clear()
        If TXTCHGSPER.ReadOnly = True Then TXTCHGSPER.ReadOnly = False

        If GRIDCHGS.RowCount > 0 Then
            TXTCHGSSRNO.Text = Val(GRIDCHGS.Rows(GRIDCHGS.RowCount - 1).Cells(0).Value) + 1
        Else
            TXTCHGSSRNO.Text = 1
        End If
        TXTCHGSSRNO.Focus()
    End Sub

    Sub EDITCHGSROW()
        Try
            TXTCHGSPER.ReadOnly = False
            TXTCHGSAMT.ReadOnly = False
            If GRIDCHGS.CurrentRow.Index >= 0 And GRIDCHGS.Item(gsrno.Index, GRIDCHGS.CurrentRow.Index).Value <> Nothing Then
                GRIDCHGSDOUBLECLICK = True
                TXTCHGSSRNO.Text = GRIDCHGS.Item(gsrno.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                CMBCHARGES.Text = GRIDCHGS.Item(ECHARGES.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTCHGSPER.Text = GRIDCHGS.Item(EPER.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTCHGSAMT.Text = GRIDCHGS.Item(EAMT.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTTAXID.Text = GRIDCHGS.Item(ETAXID.Index, GRIDCHGS.CurrentRow.Index).Value.ToString

                If Val(TXTCHGSPER.Text.Trim) > 0 Then TXTCHGSAMT.ReadOnly = True

                TEMPCHGSROW = GRIDCHGS.CurrentRow.Index
                TXTCHGSSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCHGS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCHGS.CellDoubleClick
        EDITCHGSROW()
    End Sub

    Private Sub TXTCHGSPER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCHGSPER.KeyPress
        Try
            AMOUNTNUMDOTKYEPRESS(e, TXTCHGSPER, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHGSPER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCHGSPER.Validating
        Try
            Dim dDebit As Decimal
            Dim bValid As Boolean = Decimal.TryParse(TXTCHGSPER.Text.Trim, dDebit)
            If bValid Then
                If Val(TXTCHGSPER.Text) = 0 Then TXTCHGSPER.Text = ""
                TXTCHGSPER.Text = Convert.ToDecimal(Val(TXTCHGSPER.Text))
                '' everything is good
                calchgs()
            ElseIf Val(TXTCHGSPER.Text.Trim) = 0 Then
                TXTCHGSAMT.ReadOnly = False
            Else
                MessageBox.Show("Invalid Number Entered")
                'e.Cancel = True
                TXTCHGSPER.Clear()
                TXTCHGSPER.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub calchgs()
        Try
            If Val(TXTCHGSPER.Text) <> 0 Then
                'before CALC CHECK HOW TO CALC CHARGES
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" (CASE WHEN ISNULL(ACC_CALC,'') = '' THEN 'GROSS' ELSE ACC_CALC END) AS CALC", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBCHARGES.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows(0).Item("CALC") = "GROSS" Then
                    TXTCHGSAMT.Text = Format((Val(txtbillamt.Text) * Val(TXTCHGSPER.Text)) / 100, "0.00")
                ElseIf DT.Rows(0).Item("CALC") = "NETT" Then
                    'FIRST CALC NETT THEN ADD CHARGES ON THAT NETT TOTAL
                    TXTNETTAMT.Text = Val(txtbillamt.Text.Trim)
                    For Each ROW As DataGridViewRow In GRIDCHGS.Rows
                        If GRIDCHGSDOUBLECLICK = True And ROW.Index >= TEMPCHGSROW Then Exit For
                        TXTNETTAMT.Text = Format(Val(TXTNETTAMT.Text) + Val(ROW.Cells(EAMT.Index).Value), "0.00")
                    Next
                    TXTCHGSAMT.Text = Format((Val(TXTNETTAMT.Text) * Val(TXTCHGSPER.Text)) / 100, "0.00")
                ElseIf DT.Rows(0).Item("CALC") = "QTY" Then
                    TXTCHGSAMT.Text = Format((Val(lbltotalqty.Text) * Val(TXTCHGSPER.Text)), "0.00")
                    'ElseIf DT.Rows(0).Item("CALC") = "MTRS" Then
                    '    TXTCHGSAMT.Text = Format((Val(LBLTOTALMTRS.Text) * Val(TXTCHGSPER.Text)), "0.00")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTMTRS_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CALC()
        TOTAL()
    End Sub

    Private Sub CMBPER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Try
            If TXTRATE.Text = "" Or Val(TXTRATE.Text) < 0 Then TXTAMT.ReadOnly = False
            CALC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCHGS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCHGS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDCHGS.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbMERCHANT.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDCHGSDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDCHGS.Rows.RemoveAt(GRIDCHGS.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDCHGS)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITCHGSROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaleReturn_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            'If ClientName = "PARAS" Then LBLCATEGORY.Visible = True
            'If ClientName = "CC" Or ClientName = "C3" Then GBALENO.HeaderText = "Inv Dt"
            'If ClientName = "AVIS" Then
            '    CMBQUALITY.TabStop = False
            '    TXTBATCHNO.TabStop = False
            '    CMBPIECETYPE.TabIndex = False
            '    cmbitemname.TabStop = False
            '    TXTAMT.TabStop = True
            '    txtqty.Text = 1
            'End If
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

    Private Sub TXTCGSTAMT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCGSTAMT.Validated, TXTSGSTAMT.Validated, TXTIGSTAMT.Validated
        TOTAL()
    End Sub

    Private Sub CMDSELECTCHALLAN_Click(sender As Object, e As EventArgs) Handles CMDSELECTCHALLAN.Click
        Try
            Dim OBJCMN As New ClsCommon
            If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If ClientName <> "KCRAYON" And ClientName <> "YASHVI" And ClientName <> "SUPRIYA" Then
                If CMBNAME.Text = "" Then
                    MsgBox("Select Party Name First !", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If


            Dim DTTABLE As DataTable
            Dim OBJSELECTPO As New SelectReturnChallan
            OBJSELECTPO.PARTYNAME = CMBNAME.Text.Trim
            OBJSELECTPO.FRMSTRING = "SALERETURN"
            OBJSELECTPO.ShowDialog()

            DTTABLE = OBJSELECTPO.DT1

            Dim i As Integer = 0
            If DTTABLE.Rows.Count > 0 Then

                ''  GETTING DISTINCT CHALLAN NO IN TEXTBOX
                Dim DV As DataView = DTTABLE.DefaultView
                Dim NEWDT As DataTable = DV.ToTable(True, "SRCHNO")
                For Each DTR As DataRow In NEWDT.Rows
                    If TXTSRCHNO.Text.Trim = "" Then
                        TXTSRCHNO.Text = DTR("SRCHNO").ToString
                    Else
                        TXTSRCHNO.Text = TXTSRCHNO.Text & "," & DTR("SRCHNO").ToString
                    End If
                Next

                CMBNAME.Text = DTTABLE.Rows(0).Item("NAME")
                CMBNAME.Enabled = False
                TXTSTATECODE.Text = DTTABLE.Rows(0).Item("STATECODE")
                TXTGSTIN.Text = DTTABLE.Rows(0).Item("GSTIN")
                TXTNOOFPACKETS.Text = DTTABLE.Rows(0).Item("NOOFBALES")
                cmbtrans.Text = DTTABLE.Rows(0).Item("TRANSNAME")
                txtlrno.Text = DTTABLE.Rows(0).Item("LRNO")
                If DTTABLE.Rows(0).Item("LRDATE") <> "" And DTTABLE.Rows(0).Item("LRDATE") <> "__/__/____" Then lrdate.Text = DTTABLE.Rows(0).Item("LRDATE")

                Dim DT1 As New DataTable
                DT1 = OBJCMN.search(" SALERETURNCHALLAN.SRCH_NO AS SRCHNO, ISNULL(PIECETYPEMASTER.PIECETYPE_name,'') AS PIECETYPE, ISNULL(ITEMMASTER.item_name, '') AS ITEM, '' AS QUALITY, ISNULL(DESIGN_NO,'') AS DESIGN, '' AS COLOR, SUM(ISNULL(SALERETURNCHALLAN_DESC.SRCH_QTY, 0)) AS PCS, SUM(ISNULL(SALERETURNCHALLAN_DESC.SRCH_MTRS, 0)) AS MTRS , ISNULL(HSN_CODE,'') AS HSNCODE, ISNULL(HSN_CGST,0) AS CGSTPER, ISNULL(HSN_SGST,0) AS SGSTPER, ISNULL(HSN_IGST,0) AS IGSTPER, 0 AS GDNSRNO, ISNULL(SALERETURNCHALLAN_DESC.SRCH_BALENO, '') AS BALENO,ISNULL(SALERETURNCHALLAN_DESC.SRCH_GRIDREMARKS, '') AS PRINTDESC, ISNULL(UNIT_ABBR,'') AS UNIT, ISNULL(SALERETURNCHALLAN_DESC.SRCH_RATE,0) AS RATE, ISNULL(SALERETURNCHALLAN_DESC.SRCH_PER,'Mtrs') AS PER, ISNULL(SALERETURNCHALLAN_DESC.SRCH_AMOUNT, 0) AS AMOUNT ", "", " SALERETURNCHALLAN INNER JOIN SALERETURNCHALLAN_DESC ON SALERETURNCHALLAN.SRCH_NO = SALERETURNCHALLAN_DESC.SRCH_NO AND SALERETURNCHALLAN.SRCH_YEARID = SALERETURNCHALLAN_DESC.SRCH_YEARID LEFT OUTER JOIN ITEMMASTER ON SALERETURNCHALLAN_DESC.SRCH_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN DESIGNMASTER ON SALERETURNCHALLAN_DESC.SRCH_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN COLORMASTER ON SALERETURNCHALLAN_DESC.SRCH_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN PIECETYPEMASTER ON SALERETURNCHALLAN_DESC.SRCH_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN UNITMASTER ON SRCH_QTYUNITID = UNIT_ID ", "  and SALERETURNCHALLAN.SRCH_NO IN(" & TXTSRCHNO.Text.Trim & ")  and SALERETURNCHALLAN.SRCH_YEARID = " & YearId & " GROUP BY SALERETURNCHALLAN.SRCH_NO, ISNULL(PIECETYPEMASTER.PIECETYPE_name,'') , ISNULL(ITEMMASTER.item_name, '') ,ISNULL(DESIGN_NO,'') , ISNULL(HSN_CODE,'') , ISNULL(HSN_CGST,0) , ISNULL(HSN_SGST,0) , ISNULL(HSN_IGST,0) ,ISNULL(SALERETURNCHALLAN_DESC.SRCH_BALENO, '') ,ISNULL(SALERETURNCHALLAN_DESC.SRCH_GRIDREMARKS, ''), ISNULL(UNIT_ABBR,''), ISNULL(SALERETURNCHALLAN_DESC.SRCH_RATE,0), ISNULL(SALERETURNCHALLAN_DESC.SRCH_PER,'Mtrs'), ISNULL(SALERETURNCHALLAN_DESC.SRCH_AMOUNT, 0)  order by SALERETURNCHALLAN.SRCH_NO ")
                If DT1.Rows.Count > 0 Then
                    For Each dr As DataRow In DT1.Rows

                        Dim PER As String = dr("PER")
                        Dim INVRATE As Double = dr("RATE")




                        Dim DTRATE As New DataTable




                        Dim BALENO As String = dr("BALENO")



                        GRIDSALRET.Rows.Add(0, dr("ITEMCODE"), dr("ITEMNAME"), dr("HSNCODE"), dr("MATERIALCODE"), Val(dr("QTY")), dr("BATCHNO"), dr("SHIPPERS"), dr("PACKETS"), Val(dr("RATE")), Val(dr("AMT")), 0, 0)

                        If dr("ITEM").ToString <> "" And Convert.ToDateTime(SALRETDATE.Text).Date >= "01/07/2017" Then
                            Dim DTHSN As DataTable = OBJCMN.search(" TOP 1 ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER_DESC.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST, 0) AS IGSTPER,  ISNULL(HSNMASTER_DESC.HSN_EXPCGST, 0) AS EXPCGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPSGST, 0) AS EXPSGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPIGST, 0) AS EXPIGSTPER ", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(ACTUALINVDATE.Text).Date, "MM/dd/yyyy") & "' AND ITEMMASTER.ITEM_NAME= '" & dr("ITEM") & "' AND HSNMASTER.HSN_YEARID=" & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")
                            If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                                TXTIGSTPER.Text = 0

                                If CHKEXPORTGST.CheckState = CheckState.Unchecked Then
                                    TXTCGSTPER.Text = Val(DTHSN.Rows(0).Item("CGSTPER"))
                                    TXTSGSTPER.Text = Val(DTHSN.Rows(0).Item("SGSTPER"))
                                Else
                                    TXTCGSTPER.Text = Val(DTHSN.Rows(0).Item("EXPCGSTPER"))
                                    TXTSGSTPER.Text = Val(DTHSN.Rows(0).Item("EXPSGSTPER"))
                                End If

                            Else
                                TXTCGSTPER.Text = 0
                                TXTSGSTPER.Text = 0
                                If CHKEXPORTGST.CheckState = CheckState.Unchecked Then
                                    TXTIGSTPER.Text = Val(DTHSN.Rows(0).Item("IGSTPER"))
                                Else
                                    TXTIGSTPER.Text = Val(DTHSN.Rows(0).Item("EXPIGSTPER"))
                                End If
                            End If
                        End If

                    Next

                End If
                GRIDSALRET.FirstDisplayedScrollingRowIndex = GRIDSALRET.RowCount - 1
                If GRIDSALRET.RowCount > 0 Then
                    GRIDSALRET.Focus()
                    GRIDSALRET.CurrentCell = GRIDSALRET.Rows(0).Cells(GRATE.Index)
                End If
                getsrno(GRIDSALRET)
                TOTAL()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBAGENT.Enter
        If CMBAGENT.Text.Trim = "" Then fillledger(CMBAGENT, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT'")
    End Sub

    Private Sub CMBAGENT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBAGENT.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT' "
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBAGENT.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAGENT.Validating
        Try
            If CMBAGENT.Text.Trim <> "" Then namevalidate(CMBAGENT, CMBCODE, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'", "Sundry Creditors", "AGENT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            Dim DT As New DataTable
            Dim OBJCMN As New ClsCommon
            If EDIT = True Then SENDWHATSAPP(TEMPSALRETNO)
            DT = OBJCMN.Execute_Any_String("UPDATE SALERETURN SET SALRET_SENDWHATSAPP = 1 WHERE SALRET_NO = " & TEMPSALRETNO & " AND SALRET_YEARID = " & YearId, "", "")
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
            OBJSR.DIRECTPRINT = True
            OBJSR.FRMSTRING = "SALERETURN"
            OBJSR.DIRECTMAIL = True
            OBJSR.WHERECLAUSE = "{SALERETURN.SALRET_NO}=" & Val(SRNO) & " and {SALERETURN.SALRET_yearid}=" & YearId
            OBJSR.SALRETNO = SRNO
            OBJSR.NOOFCOPIES = 1
            OBJSR.Show()
            OBJSR.Close()

            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PARTYNAME = CMBNAME.Text.Trim
            OBJWHATSAPP.AGENTNAME = CMBAGENT.Text.Trim
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\SALRET_" & Val(SRNO) & ".pdf")
            OBJWHATSAPP.FILENAME.Add("SALRET_" & Val(SRNO) & ".pdf")
            OBJWHATSAPP.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RBREMOVEADJ_Click(sender As Object, e As EventArgs) Handles RBREMOVEADJ.Click
        Try
            If TXTINVINITIALS.Text.Trim <> "" Then
                If MsgBox("Wish to Remove the Adjustment?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                TXTINVINITIALS.Clear()
                TXTINVNO.Clear()
                TXTINVREGNAME.Clear()
                TXTINVTYPE.Clear()
                MsgBox("After saving this entry please Reconcile Sale Data to get proper Results", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSALRETNO_Validating(sender As Object, e As CancelEventArgs) Handles TXTSALRETNO.Validating
        Try
            If ALLOWMANUALCNDN = True Then
                If (Val(TXTSALRETNO.Text.Trim) <> 0 And TXTINVREGNAME.Text.Trim <> "" And EDIT = False) Or (EDIT = True And TEMPSALRETNO <> Val(TXTSALRETNO.Text.Trim)) Then
                    Dim OBJCMN As New ClsCommon
                    Dim dttable As DataTable = OBJCMN.search("ISNULL(SALERETURN.SALRET_no, 0) AS SALRETNO, ISNULL(REGISTERMASTER.register_name,'') AS REGNAME", "", " REGISTERMASTER INNER JOIN SALERETURN ON REGISTERMASTER.register_id = SALERETURN.SALRET_INVOICEREGID ", "  AND SALERETURN.SALRET_NO=" & TXTSALRETNO.Text.Trim & " AND REGISTER_NAME = '" & TXTINVREGNAME.Text.Trim & "' AND SALERETURN.SALRET_yearid = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        MsgBox("SalReTurn No Already Exist")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLEINV_Click(sender As Object, e As EventArgs) Handles TOOLEINV.Click
        Try
            If EDIT = False Then Exit Sub
            GENERATEINV()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub GENERATEINV()
        Try
            If ALLOWEINVOICE = False Then Exit Sub
            If CMBNAME.Text.Trim = "" Then Exit Sub

            If Val(TXTCGSTAMT.Text.Trim) = 0 And Val(TXTSGSTAMT.Text.Trim) = 0 And Val(TXTIGSTAMT.Text.Trim) = 0 And CHKOVERSEAS.CheckState = CheckState.Unchecked Then Exit Sub

            If MsgBox("Generate E-Invoice?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If TXTIRNNO.Text.Trim <> "" Then
                MsgBox("E-Invoice Already Generated", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'BEFORE GENERATING EWAY BILL WE NEED TO VALIDATE WHETHER ALL THE DATA ARE PRESENT OR NOT
            'IF DATA IS NOT PRESENT THEN VALIDATE
            'DATA TO BE CHECKED 
            '   1)CMPEWBUSER | CMPEWBPASS | CMPGSTIN | CMPPINCODE | CMPCITY | CMPSTATE | 
            '   2)PARTYGSTIN | PARTYCITY | PARTYPINCODE | PARTYSTATE | PARTYSTATECODE | PARTYKMS
            '   3)CGST OR SGST OR IGST (ALWAYS USE MTR IN QTYUNIT)
            If CMPEWBUSER = "" Or CMPEWBPASS = "" Or CMPGSTIN = "" Or CMPPINCODE = "" Or CMPCITYNAME = "" Or CMPSTATENAME = "" Then
                MsgBox(" Company Details are Not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim TEMPCMPADD1 As String = ""
            Dim TEMPCMPADD2 As String = ""
            Dim TEMPCMPDISPATCHADD1 As String = ""
            Dim PARTYGSTIN As String = ""
            Dim PARTYPINCODE As String = ""
            Dim PARTYSTATECODE As String = ""
            Dim PARTYSTATENAME As String = ""
            Dim SHIPTOGSTIN As String = ""
            Dim SHIPTOSTATECODE As String = ""
            Dim SHIPTOSTATENAME As String = ""
            Dim SHIPTOPINCODE As String = ""
            Dim PARTYCITYNAME As String = ""
            Dim PARTYKMS As Double = 0
            Dim PARTYADD1 As String = ""
            Dim PARTYADD2 As String = ""
            Dim SHIPTOADD1 As String = ""
            Dim SHIPTOADD2 As String = ""
            Dim TRANSGSTIN As String = ""


            Dim OBJCMN As New ClsCommon
            'CMP ADDRESS DETAILS
            Dim DT As DataTable = OBJCMN.search(" ISNULL(CMP_ADD1, '') AS ADD1, ISNULL(CMP_ADD2,'') AS ADD2, ISNULL(CMP_DISPATCHFROM, '') AS DISPATCHADD ", "", " CMPMASTER ", " AND CMP_ID = " & CmpId)
            TEMPCMPADD1 = DT.Rows(0).Item("ADD1")
            TEMPCMPADD2 = DT.Rows(0).Item("ADD2")
            TEMPCMPDISPATCHADD1 = DT.Rows(0).Item("DISPATCHADD")


            'PARTY GST DETAILS 
            DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN, (CASE WHEN ISNULL(ACC_DELIVERYPINCODE,'') <> '' THEN ISNULL(ACC_DELIVERYPINCODE,'') ELSE ISNULL(ACC_ZIPCODE,'') END) AS PINCODE, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE, ISNULL(ACC_KMS,0) AS KMS, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2, ISNULL(CITYMASTER.CITY_NAME,'') AS CITYNAME ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID LEFT OUTER JOIN CITYMASTER ON LEDGERS.ACC_CITYID = CITYMASTER.CITY_ID ", " AND ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If (DT.Rows(0).Item("GSTIN") = "" Or DT.Rows(0).Item("PINCODE") = "" Or DT.Rows(0).Item("STATENAME") = "" Or DT.Rows(0).Item("STATECODE") = "") And CHKEXPORTGST.Checked = False Then
                MsgBox(" Party Details are not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            Else
                PARTYGSTIN = DT.Rows(0).Item("GSTIN")
                SHIPTOGSTIN = DT.Rows(0).Item("GSTIN")
                PARTYSTATENAME = DT.Rows(0).Item("STATENAME")
                PARTYSTATECODE = DT.Rows(0).Item("STATECODE")
                PARTYCITYNAME = DT.Rows(0).Item("CITYNAME")
                SHIPTOSTATENAME = DT.Rows(0).Item("STATENAME")
                SHIPTOSTATECODE = DT.Rows(0).Item("STATECODE")
                PARTYPINCODE = DT.Rows(0).Item("PINCODE")
                'PARTYKMS = Val(DT.Rows(0).Item("KMS"))
                PARTYADD1 = DT.Rows(0).Item("ADD1")
                PARTYADD2 = DT.Rows(0).Item("ADD2")
            End If


            If CHKEXPORTGST.Checked = True And CHKOVERSEAS.Checked = True Then
                PARTYGSTIN = "URP"
                SHIPTOGSTIN = "URP"
                PARTYSTATECODE = "96"
                SHIPTOSTATECODE = "96"
                PARTYPINCODE = "999999"
                SHIPTOPINCODE = "999999"
            End If

            'DELIVERYAT IS NOT PRESENT IN DEBIT NOTE
            ''FETCH PINCODE / KMS / ADD1 / ADD2 OF SHIPTO IF IT IS NOT SAME AS CMBNAME
            'If CMBPACKING.Text.Trim <> "" AndAlso CMBNAME.Text.Trim <> CMBPACKING.Text.Trim Then
            '    DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN,  (CASE WHEN ISNULL(ACC_DELIVERYPINCODE,'') <> '' THEN ISNULL(ACC_DELIVERYPINCODE,'') ELSE ISNULL(ACC_ZIPCODE,'') END) AS PINCODE, ISNULL(ACC_KMS,0) AS KMS, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE, ISNULL(ACC_RANGE,'') AS KOTHARIPLACE ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID ", " AND ACC_CMPNAME = '" & CMBPACKING.Text.Trim & "' AND ACC_YEARID = " & YearId)
            '    If DT.Rows(0).Item("PINCODE") = "" Or Val(DT.Rows(0).Item("KMS")) = 0 Then
            '        MsgBox(" Party Details are not filled properly ", MsgBoxStyle.Critical)
            '        Exit Sub
            '    Else
            '        SHIPTOGSTIN = DT.Rows(0).Item("GSTIN")
            '        SHIPTOPINCODE = DT.Rows(0).Item("PINCODE")
            '        PARTYKMS = Val(DT.Rows(0).Item("KMS"))
            '        SHIPTOADD1 = DT.Rows(0).Item("ADD1")
            '        SHIPTOADD2 = DT.Rows(0).Item("ADD2")
            '        SHIPTOSTATENAME = DT.Rows(0).Item("STATENAME")
            '        SHIPTOSTATECODE = DT.Rows(0).Item("STATECODE")
            '        KOTHARIPLACE = DT.Rows(0).Item("KOTHARIPLACE")
            '    End If
            'End If


            'TRANSPORT GSTING IS NOT MANDATORY
            'FOR LOCAL TRANSPORT THERE IS NO GSTIN
            'TRANSPORT GSTIN IF TRANSPORT IS PRESENT
            'If cmbtrans.Text.Trim <> "" Then
            '    DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN ", "", " LEDGERS ", " AND ACC_CMPNAME = '" & cmbtrans.Text.Trim & "' AND ACC_YEARID = " & YearId)
            '    If DT.Rows.Count > 0 Then TRANSGSTIN = DT.Rows(0).Item("GSTIN")
            '    'FOR LOCAL TRANSPORT THERE IS NO GSTIN
            '    'If TRANSGSTIN = "" Then
            '    '    MsgBox("Enter Transport GSTIN", MsgBoxStyle.Critical)
            '    '    Exit Sub
            '    'End If
            'End If



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
            'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTSALRETNO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


            'ONCE WE REC THE TOKEN WE WILL CREATE EWAY BILL
            'IF STATUS IS FAILED THEN ERROR MESSAGE
            If TEMPSTATUS = "FAILED" Then
                MsgBox("Unable to create E-Invoice", MsgBoxStyle.Critical)
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTSALRETNO.Text.Trim) & ",'SALERETURN','" & TOKEN & "','','" & TEMPSTATUS & "','" & REQUESTEDTEXT & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
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
                If CHKEXPORTGST.Checked = True And CHKOVERSEAS.Checked = True Then j = j & """SupTyp"":""EXPWP""," Else j = j & """SupTyp"":""B2B"","
                j = j & """RegRev"":""N"","
                j = j & """IgstOnIntra"":""N""},"



                'WE NEED TO FETCH INITIALS INSTEAD OF BILLNO
                Dim DTINI As DataTable = OBJCMN.search("SALRET_PRINTINITIALS AS PRINTINITIALS", "", "SALERETURN", " AND SALRET_NO = " & Val(TXTSALRETNO.Text.Trim) & " AND SALRET_YEARID = " & YearId)
                PRINTINITIALS = DTINI.Rows(0).Item("PRINTINITIALS")

                j = j & """DocDtls"": {"
                j = j & """Typ"":""CRN"","
                j = j & """No"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                j = j & """Dt"":""" & SALRETDATE.Text & """" & "},"


                'For WORKING ON SANDBOX
                'CMPGSTIN = "34AACCC1596Q002"
                'CMPPINCODE = "605001"
                'CMPSTATECODE = "34"


                j = j & """SellerDtls"": {"
                j = j & """Gstin"":""" & CMPGSTIN & """" & ","
                j = j & """LglNm"":""" & CmpName & """" & ","
                j = j & """TrdNm"":""" & CmpName & """" & ","
                j = j & """Addr1"":""" & TEMPCMPADD1.Trim.Replace(vbCrLf, " ") & """" & ","
                j = j & """Addr2"":""" & TEMPCMPADD2.Trim.Replace(vbCrLf, " ") & """" & ","
                j = j & """Loc"":""" & CMPCITYNAME & """" & ","
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
                j = j & """Loc"":""" & PARTYCITYNAME & """" & ","
                j = j & """Pin"":" & PARTYPINCODE & "" & ","
                j = j & """Stcd"":""" & PARTYSTATECODE & """" & "},"


                j = j & """DispDtls"": {"
                j = j & """Nm"":""" & CmpName & """" & ","
                j = j & """Addr1"":""" & TEMPCMPDISPATCHADD1.Trim.Replace(vbCrLf, " ") & """" & ","
                j = j & """Addr2"":""" & TEMPCMPADD2.Trim.Replace(vbCrLf, " ") & """" & ","
                j = j & """Loc"":""" & CMPCITYNAME & """" & ","
                j = j & """Pin"":" & CMPPINCODE & "" & ","
                j = j & """Stcd"":""" & CMPSTATECODE & """" & "},"

                j = j & """ShipDtls"": {"
                If SHIPTOGSTIN <> "" Then j = j & """Gstin"":""" & SHIPTOGSTIN & """" & ","
                j = j & """LglNm"":""" & CMBNAME.Text.Trim & """" & ","
                j = j & """TrdNm"":""" & CMBNAME.Text.Trim & """" & ","
                If SHIPTOADD1 = "" Then j = j & """Addr1"":""" & PARTYADD1.Replace(vbCrLf, " ") & """" & "," Else j = j & """Addr1"":""" & SHIPTOADD1.Replace(vbCrLf, " ") & """" & ","
                If SHIPTOADD2 = "" Then SHIPTOADD2 = " ADDRESS2 "
                j = j & """Addr2"":""" & SHIPTOADD2 & """" & ","
                j = j & """Loc"":""" & PARTYCITYNAME & """" & ","
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
                'If Val(TXTCHARGES.Text.Trim) < 0 Then
                '    If GRIDSALRET.Rows(0).Cells(GPER.Index).Value = "Pcs" Then TEMPLINEDISC = Format(Val(TXTCHARGES.Text.Trim) / Val(lbltotalqty.Text.Trim), "0.0000") Else TEMPLINEDISC = Format(Val(TXTCHARGES.Text.Trim) / Val(LBLTOTALMTRS.Text.Trim), "0.0000")
                'Else
                '    If GRIDSALRET.Rows(0).Cells(GPER.Index).Value = "Pcs" Then TEMPRATE = Format(Val(TXTCHARGES.Text.Trim) / Val(lbltotalqty.Text.Trim), "0.0000") Else TEMPRATE = Format(Val(TXTCHARGES.Text.Trim) / Val(LBLTOTALMTRS.Text.Trim), "0.0000")
                'End If


                Dim TEMPTOTALAMT As Double = 0
                Dim TEMPTOTALDISC As Double = 0
                Dim TEMPTOTALTAXABLEAMT As Double = 0
                Dim TEMPTOTALCGSTAMT As Double = 0
                Dim TEMPTOTALSGSTAMT As Double = 0
                Dim TEMPTOTALIGSTAMT As Double = 0
                Dim TEMPGTOTALAMT As Double = 0


                'WE NEED TO FETCH ALL ITEMS HERE
                'FETCH FROM DESC TABLE 
                DT = OBJCMN.Execute_Any_String(" SELECT ISNULL(SALERETURN_DESC.SALRET_GRIDSRNO,0) AS SRNO, ISNULL(ITEMMASTER.item_name,'') AS ITEMNAME, ISNULL(HSN_CODE,'') AS HSNCODE, ISNULL(HSN_CGST,0) AS CGST, ISNULL(HSN_SGST,0) AS SGST, ISNULL(HSN_IGST,0) AS IGST, ISNULL(SALERETURN_DESC.SALRET_QTY,0) AS PCS, ISNULL(SALERETURN_DESC.SALRET_MTRS,0) AS MTRS, ISNULL(SALERETURN_DESC.SALRET_PER,'Mtrs') AS PER, ISNULL(SALERETURN_DESC.SALRET_RATE,0) AS RATE, ISNULL(SALERETURN_DESC.SALRET_AMT,0) AS TOTALAMT, 0 AS LINEDISC, 0 AS LINETAXABLEAMT, 0 AS LINECGSTAMT, 0 AS LINESGSTAMT, 0 AS LINEIGSTAMT, ISNULL(SALERETURN_DESC.SALRET_AMT,0) AS LINEGRIDDTOTAL, ISNULL(HSN_TYPE,'Goods') HSNTYPE FROM SALERETURN INNER JOIN SALERETURN_DESC ON SALERETURN.SALRET_NO = SALERETURN_DESC.SALRET_NO AND SALERETURN.SALRET_YEARID = SALERETURN_DESC.SALRET_YEARID INNER JOIN ITEMMASTER ON item_id = SALRET_ITEMID INNER JOIN HSNMASTER ON HSN_ID = SALRET_HSNCODEID WHERE SALERETURN.SALRET_NO = " & Val(TXTSALRETNO.Text.Trim) & " and SALERETURN.SALRET_YEARID = " & YearId & " ORDER BY SALERETURN_DESC.SALRET_GRIDSRNO", "", "")
                Dim CURRROW As Integer = 0
                For Each DTROW As DataRow In DT.Rows

                    'If GRIDSALRET.Rows(0).Cells(GPER.Index).Value = "Pcs" Then TEMPLINECHARGES = Format(Val(TEMPLINEDISC) * Val(DTROW("PCS")), "0.00") Else TEMPLINECHARGES = Format(Val(TEMPLINEDISC) * Val(DTROW("MTRS")), "0.00")
                    TEMPLINETAXABLEAMT = Format(Val(DTROW("TOTALAMT")) + Val(TEMPLINECHARGES), "0.00")
                    TEMPLINECGSTAMT = Format(Val(TXTCGSTPER.Text.Trim) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                    TEMPLINESGSTAMT = Format(Val(TXTSGSTPER.Text.Trim) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                    TEMPLINEIGSTAMT = Format(Val(TXTIGSTPER.Text.Trim) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                    TEMPLINEGRIDTOTALAMT = Format(Val(TEMPLINETAXABLEAMT + TEMPLINECGSTAMT + TEMPLINESGSTAMT + TEMPLINEIGSTAMT), "0.00")

                    If CURRROW > 0 Then j = j & ", {"
                    j = j & """SlNo"": """ & DTROW("SRNO") & """" & ","
                    j = j & """PrdDesc"":""" & DTROW("ITEMNAME") & """" & ","
                    If DTROW("HSNTYPE") = "Goods" Then j = j & """IsServc"":""" & "N" & """" & "," Else j = j & """IsServc"":""" & "Y" & """" & ","
                    j = j & """HsnCd"":""" & DTROW("HSNCODE") & """" & ","
                    j = j & """Barcde"":""REC9999"","
                    If DTROW("PER") = "Pcs" Then j = j & """Qty"":" & Val(DTROW("PCS")) & "" & "," Else j = j & """Qty"":" & Val(DTROW("MTRS")) & "" & ","
                    j = j & """FreeQty"":" & "0" & "" & ","
                    j = j & """Unit"":""" & "MTR" & """" & ","


                    Dim DTHSN As DataTable = OBJCMN.search(" TOP 1 ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER_DESC.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST, 0) AS IGSTPER,  ISNULL(HSNMASTER_DESC.HSN_EXPCGST, 0) AS EXPCGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPSGST, 0) AS EXPSGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPIGST, 0) AS EXPIGSTPER ", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(SALRETDATE.Text).Date, "MM/dd/yyyy") & "' AND ITEMMASTER.ITEM_NAME= '" & DTROW("ITEMNAME") & "' AND HSNMASTER.HSN_YEARID=" & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")


                    If Val(TXTCHARGES.Text.Trim) <= 0 Then

                        j = j & """UnitPrice"":" & Val(DTROW("RATE")) & "" & ","
                        j = j & """TotAmt"":" & Format(Val(DTROW("TOTALAMT")), "0.00") & "" & ","

                        'If INVOICESCREENTYPE = "LINE GST" Then
                        '    If Val(DTROW("LINEDISC")) < 0 Then j = j & """Discount"":" & Val(DTROW("LINEDISC")) * -1 & "" & "," Else j = j & """Discount"":" & Val(DTROW("LINEDISC")) & "" & ","
                        'Else
                        '    If Val(TEMPLINECHARGES) < 0 Then j = j & """Discount"":" & Val(TEMPLINECHARGES) * -1 & "" & "," Else j = j & """Discount"":" & Val(TEMPLINECHARGES) & "" & ","
                        'End If

                        If Val(TEMPLINECHARGES) < 0 Then j = j & """Discount"":" & Val(TEMPLINECHARGES) * -1 & "" & "," Else j = j & """Discount"":" & Val(TEMPLINECHARGES) & "" & ","
                        j = j & """PreTaxVal"":" & "1" & "" & ","
                        'If INVOICESCREENTYPE = "LINE GST" Then j = j & """AssAmt"":" & Val(DTROW("LINETAXABLEAMT")) & "" & "," Else j = j & """AssAmt"":" & Val(TEMPLINETAXABLEAMT) & "" & ","
                        j = j & """AssAmt"":" & Val(TEMPLINETAXABLEAMT) & "" & ","
                        If CHKEXPORTGST.CheckState = CheckState.Unchecked Then j = j & """GstRt"":" & Val(DTHSN.Rows(0).Item("IGSTPER")) & "" & "," Else j = j & """GstRt"":" & Val(DTHSN.Rows(0).Item("EXPIGSTPER")) & "" & ","

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

                        'If INVOICESCREENTYPE = "LINE GST" Then j = j & """TotItemVal"":" & Val(DTROW("LINEGRIDDTOTAL")) & "" & "," Else j = j & """TotItemVal"":" & Val(TEMPLINEGRIDTOTALAMT) & "" & ","
                        j = j & """TotItemVal"":" & Val(TEMPLINEGRIDTOTALAMT) & "" & ","
                        j = j & """OrdLineRef"":"" "","
                        j = j & """OrgCntry"":""IN"","
                        j = j & """PrdSlNo"":""123"","

                        j = j & """BchDtls"": {"
                        j = j & """Nm"":""123"","
                        j = j & """Expdt"":""" & SALRETDATE.Text & """" & ","
                        j = j & """wrDt"":""" & SALRETDATE.Text & """" & "},"

                        j = j & """AttribDtls"": [{"
                        j = j & """Nm"":""" & DTROW("ITEMNAME") & """" & ","
                        j = j & """Val"":""" & Val(TEMPLINEGRIDTOTALAMT) & """" & "}]"

                    Else

                        j = j & """UnitPrice"":" & Format(Val(DTROW("RATE")) + TEMPRATE, "0.00") & "" & ","
                        If DTROW("PER") = "Pcs" Then TEMPLINETAXABLEAMT = Format(Val(Val(DTROW("RATE")) + TEMPRATE) * Val(DTROW("PCS")), "0.00") Else TEMPLINETAXABLEAMT = Format(Val(Val(DTROW("RATE")) + TEMPRATE) * Val(DTROW("MTRS")), "0.00")

                        TEMPLINECGSTAMT = Format(Val(TXTCGSTPER.Text.Trim) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                        TEMPLINESGSTAMT = Format(Val(TXTSGSTPER.Text.Trim) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                        TEMPLINEIGSTAMT = Format(Val(TXTIGSTPER.Text.Trim) * Val(TEMPLINETAXABLEAMT) / 100, "0.00")
                        TEMPLINEGRIDTOTALAMT = Format(Val(TEMPLINETAXABLEAMT + TEMPLINECGSTAMT + TEMPLINESGSTAMT + TEMPLINEIGSTAMT), "0.00")

                        j = j & """TotAmt"":" & Val(TEMPLINETAXABLEAMT) & "" & ","
                        j = j & """Discount"":" & "0" & "" & ","
                        j = j & """PreTaxVal"":" & "1" & "" & ","
                        j = j & """AssAmt"":" & Val(TEMPLINETAXABLEAMT) & "" & ","
                        If CHKEXPORTGST.CheckState = CheckState.Unchecked Then j = j & """GstRt"":" & Val(DTHSN.Rows(0).Item("IGSTPER")) & "" & "," Else j = j & """GstRt"":" & Val(DTHSN.Rows(0).Item("EXPIGSTPER")) & "" & ","
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
                        j = j & """Expdt"":""" & SALRETDATE.Text & """" & ","
                        j = j & """wrDt"":""" & SALRETDATE.Text & """" & "},"

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
                j = j & """AssVal"":" & Val(TXTSUBTOTAL.Text.Trim) & "" & ","
                j = j & """CgstVal"":" & Val(TXTCGSTAMT.Text.Trim) & "" & ","
                j = j & """SgstVal"":" & Val(TXTSGSTAMT.Text.Trim) & "" & ","
                j = j & """IgstVal"":" & Val(TXTIGSTAMT.Text.Trim) & "" & ","
                j = j & """CesVal"":" & "0" & "" & ","
                j = j & """StCesVal"":" & "0" & "" & ","
                j = j & """Discount"":" & "0" & "" & ","
                j = j & """OthChrg"":" & Val(TXTTCSAMT.Text.Trim) & "" & ","
                j = j & """RndOffAmt"":" & Val(txtroundoff.Text.Trim) & "" & ","
                j = j & """TotInvVal"":" & Val(TXTGRANDTOTAL.Text.Trim) & "" & ","
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
                j = j & """Crday"":" & "0" & "" & ","
                j = j & """Paidamt"":" & "0" & "" & ","
                j = j & """Paymtdue"":" & Val(TXTGRANDTOTAL.Text.Trim) & "" & "},"


                'j = j & """RefDtls"": {"
                'j = j & """InvRm"":""TEST"","
                'j = j & """DocPerdDtls"": {"
                'j = j & """InvStDt"":""" & SALRETDATE.Text & """" & ","
                'j = j & """InvEndDt"":""" & SALRETDATE.Text & """" & "},"

                'j = j & """PrecDocDtls"": [{"
                'j = j & """InvNo"":""" & DTINI.Rows(0).Item("PRINTINITIALS") & """" & ","
                'j = j & """InvDt"":""" & SALRETDATE.Text & """" & ","
                'j = j & """OthRefNo"":"" ""}],"

                'j = j & """ContrDtls"": [{"
                'j = j & """RecAdvRefr"":"" "","
                'j = j & """RecAdvDt"":""" & SALRETDATE.Text & """" & ","
                'j = j & """Tendrefr"":"" "","
                'j = j & """Contrrefr"":"" "","
                'j = j & """Extrefr"":"" "","
                'j = j & """Projrefr"":"" "","
                'j = j & """Porefr"":"" "","
                'j = j & """PoRefDt"":""" & SALRETDATE.Text & """" & "}]"
                'j = j & "},"




                j = j & """AddlDocDtls"": [{"
                j = j & """Url"":""https://einv-apisandbox.nic.in"","
                j = j & """Docs"":""DEBITNOTE"","
                j = j & """Info"":""DEBITNOTE""}],"

                j = j & """TransDocNo"":""   """ & ","



                j = j & """ExpDtls"": {"
                j = j & """ShipBNo"":"" "","
                j = j & """ShipBDt"":""" & SALRETDATE.Text & """" & ","
                j = j & """Port"":""INBOM1"","
                j = j & """RefClm"":""N"","
                j = j & """ForCur"":""AED"","
                j = j & """CntCode"":""AE""}"




                'If TXTVEHICLENO.Text.Trim <> "" Then
                '    j = j & ","
                '    j = j & """EwbDtls"": {"
                '    j = j & """TransId"":""" & TRANSGSTIN & """" & ","
                '    j = j & """TransName"":""" & cmbtrans.Text.Trim & """" & ","
                '    j = j & """Distance"":" & PARTYKMS & "" & ","
                '    If LRDATE.Text <> "__/__/____" Then j = j & """TransDocDt"":""" & LRDATE.Text & """" & "," Else j = j & """TransDocDt"":"""","
                '    j = j & """VehNo"":""" & TXTVEHICLENO.Text.Trim & """" & ","
                '    j = j & """VehType"":""" & "R" & """" & ","
                '    j = j & """TransMode"":""1""" & "}"
                'End If

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
                'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTSALRETNO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','FAILED', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

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
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTSALRETNO.Text.Trim) & ",'SALERETURN','" & TOKEN & "','','FAILED','" & REQUESTEDTEXT & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

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
            DT = OBJCMN.Execute_Any_String("UPDATE SALERETURN SET SALRET_IRNNO = '" & TXTIRNNO.Text.Trim & "', SALRET_ACKNO = '" & TXTACKNO.Text.Trim & "', SALRET_ACKDATE = '" & Format(ACKDATE.Value.Date, "MM/dd/yyyy") & "' WHERE SALRET_NO = " & Val(TXTSALRETNO.Text.Trim) & " AND SALRET_YEARID = " & YearId, "", "")

            'ADD DATA IN EINVOICEENTRY
            DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTSALRETNO.Text.Trim) & ",'SALERETURN','" & TOKEN & "','" & IRNNO & "','" & TEMPSTATUS & "', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


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
                bitmap1.Save(Application.StartupPath & "\SR" & Val(TXTSALRETNO.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\SR" & Val(TXTSALRETNO.Text.Trim) & AccFrom.Year & ".png"
                PBQRCODE.Refresh()

                If PBQRCODE.Image IsNot Nothing Then
                    Dim OBJINVOICE As New ClsSaleReturn
                    Dim MS As New IO.MemoryStream
                    PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    OBJINVOICE.alParaval.Add(TXTSALRETNO.Text.Trim)
                    OBJINVOICE.alParaval.Add(MS.ToArray)
                    OBJINVOICE.alParaval.Add(YearId)
                    Dim INTRES As Integer = OBJINVOICE.SAVEQRCODE()
                End If

                'DT = OBJCMN.Execute_Any_String("UPDATE SALERETURN SET SALRET_QRCODE = (SELECT * FROM OPENROWSET(BULK '" & Application.StartupPath & "\" & Val(TXTSALRETNO.Text.Trim) & AccFrom.Year & ".png',SINGLE_BLOB) AS IMG) FROM SALERETURN INNER JOIN REGISTERMASTER ON SALRET_REGISTERID = REGISTER_ID WHERE SALRET_NO = " & Val(TXTSALRETNO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND SALRET_YEARID = " & YearId, "", "")


                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTSALRETNO.Text.Trim) & ",'SALERETURN','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTSALRETNO.Text.Trim) & ",'SALERETURN','" & TOKEN & "','" & IRNNO & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

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
            'DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTSALRETNO.Text.Trim) & ",'INVOICE','" & TOKEN & "','" & IRNNO & "','" & TEMPSTATUS & "', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDUPLOADIRN_Click(sender As Object, e As EventArgs) Handles CMDUPLOADIRN.Click
        If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        OpenFileDialog1.Filter = "Pictures (*.png)|*.png"
        OpenFileDialog1.ShowDialog()

        OpenFileDialog1.AddExtension = True
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        txtimgpath.Text = OpenFileDialog1.FileName
        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then
            PBQRCODE.ImageLocation = txtimgpath.Text.Trim
            PBQRCODE.Load(txtimgpath.Text.Trim)
        End If
    End Sub

    Private Async Sub CMDGETQRCODE_Click(sender As Object, e As EventArgs) Handles CMDGETQRCODE.Click
        Try
            If EDIT = True And TXTIRNNO.Text.Trim <> "" And IsNothing(PBQRCODE.Image) = True Then

                'FIRST GETTOKEN AND THEN GET QRCODE
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable

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
                    MsgBox("Unable to create E-Invoice", MsgBoxStyle.Critical)
                    DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTSALRETNO.Text.Trim) & ",'SALERETURN','" & TOKEN & "','','" & TEMPSTATUS & "','" & REQUESTEDTEXT & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
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
                bitmap1.Save(Application.StartupPath & "\SR" & Val(TXTSALRETNO.Text.Trim) & AccFrom.Year & ".png")
                PBQRCODE.ImageLocation = Application.StartupPath & "\SR" & Val(TXTSALRETNO.Text.Trim) & AccFrom.Year & ".png"
                PBQRCODE.Refresh()

                If PBQRCODE.Image IsNot Nothing Then
                    Dim OBJINVOICE As New ClsSaleReturn
                    Dim MS As New IO.MemoryStream
                    PBQRCODE.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    OBJINVOICE.alParaval.Add(TXTSALRETNO.Text.Trim)
                    OBJINVOICE.alParaval.Add(MS.ToArray)
                    OBJINVOICE.alParaval.Add(YearId)
                    Dim INTRES As Integer = OBJINVOICE.SAVEQRCODE()
                End If

                'DT = OBJCMN.Execute_Any_String("UPDATE INVOICEMASTER SET INVOICE_QRCODE = (SELECT * FROM OPENROWSET(BULK '" & Application.StartupPath & "\" & Val(TXTINVOICENO.Text.Trim) & AccFrom.Year & ".png',SINGLE_BLOB) AS IMG) FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID WHERE INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND REGISTER_NAME = '" & cmbregister.Text.Trim & "' AND INVOICE_YEARID = " & YearId, "", "")

                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTSALRETNO.Text.Trim) & ",'SALERETURN','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EINVOICEENTRY VALUES (" & Val(TXTSALRETNO.Text.Trim) & ",'SALERETURN','" & TOKEN & "','" & TXTIRNNO.Text.Trim & "','QRCODE SUCCESS1', '', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                'cmdok_Click(sender, e)

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tstxtbillno.KeyPress, TXTFROM.KeyPress, TXTTO.KeyPress, TXTNOOFPACKETS.KeyPress, TXTSHIPPERS.KeyPress, TXTBATCHNO.KeyPress, TXTPACKETS.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTADJAMT_Validating(sender As Object, e As CancelEventArgs) Handles TXTADJAMT.Validating
        Try
            If TXTADJSRNO.Text.Trim.Length = 0 Then TXTADJSRNO_GotFocus(sender, e)

            If TXTADJSRNO.Text.Trim.Length > 0 And Val(TXTADJAMT.Text) > 0 Then
                If CMBPAYTYPE.Text = "Against Bill" And CMBBILLNO.Text.Trim = "" Then
                    MsgBox("Select Bill First", MsgBoxStyle.Critical, "TEXTRADE")
                    CMBPAYTYPE.Focus()
                    Exit Sub
                End If

                If CMBBILLNO.Text.Trim <> "" Then
                    For Each ROW As DataGridViewRow In GRIDPAYMENT.Rows
                        If (ROW.Cells(gbillno.Index).Value = CMBBILLNO.Text.Trim And GRIDADJDOUBLECLICK = False) Or (GRIDADJDOUBLECLICK = True And ROW.Cells(gbillno.Index).Value = CMBBILLNO.Text.Trim And ROW.Index <> TEMPADJROW) Then
                            MsgBox("Bill Already present in Grid below", MsgBoxStyle.Critical, "TEXTRADE")
                            CMBPAYTYPE.Focus()
                            Exit Sub
                        End If
                    Next
                End If

                FILLADJGRID()

            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKEXPORTGST_CheckedChanged(sender As Object, e As EventArgs) Handles CHKEXPORTGST.CheckedChanged
        GETHSNCODE()
    End Sub

    Private Sub TXTADJSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTADJSRNO.GotFocus
        If GRIDADJDOUBLECLICK = False Then TXTADJSRNO.Text = GRIDPAYMENT.RowCount + 1
    End Sub

    Private Sub TXTADJAMT_GotFocus(sender As Object, e As EventArgs) Handles TXTADJAMT.GotFocus
        TXTADJAMT.SelectAll()
    End Sub

    Private Sub CMBPAYTYPE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPAYTYPE.SelectedIndexChanged
        Try
            LBLBILLTOTAL.Text = ""
            CMBBILLNO.Text = ""
            If CMBPAYTYPE.Text = "Against Bill" Then
                CMBBILLNO.Enabled = True
            Else
                CMBBILLNO.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPAYTYPE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPAYTYPE.Validated
        Try
            If CMBPAYTYPE.Text = "Against Bill" Then CMBBILLNO.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ACTUALINVDATE_Validating(sender As Object, e As CancelEventArgs) Handles ACTUALINVDATE.Validating
        Try
            If ACTUALINVDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(ACTUALINVDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ACTUALINVDATE_Validated(sender As Object, e As EventArgs) Handles ACTUALINVDATE.Validated
        Try
            GETHSNCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBILLNO_Enter(sender As Object, e As EventArgs) Handles CMBBILLNO.Enter
        FILLCMBBILLNO()
    End Sub

    Private Sub CHKMANUALROUND_CheckedChanged(sender As Object, e As EventArgs) Handles CHKMANUALROUND.CheckedChanged
            Try
                If CHKMANUALROUND.Checked = True Then
                    txtroundoff.ReadOnly = False
                    txtroundoff.TabStop = True
                Else
                    txtroundoff.ReadOnly = True
                    txtroundoff.TabStop = False
                    TOTAL()
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub txtroundoff_Validated(sender As Object, e As EventArgs) Handles txtroundoff.Validated
            TOTAL()
        End Sub

    Private Sub TXTSHIPPERS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTSHIPPERS.KeyPress
        numdotkeypress(e, sender, Me)
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
            If CMBITEMCODE.Text.Trim <> "" Then ITEMCODEvalidate(CMBITEMCODE, cmbitemname, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validated(sender As Object, e As EventArgs) Handles cmbitemname.Validated
        Try
            If cmbitemname.Text.Trim <> "" And Convert.ToDateTime(SALRETDATE.Text).Date >= "01/07/2017" Then
                GETHSNCODE()
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class