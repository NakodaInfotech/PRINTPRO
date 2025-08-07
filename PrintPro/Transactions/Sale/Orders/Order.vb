
Imports BL
Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel

Public Class Order

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim gridUPLOADDoubleClick As Boolean
    Dim temprow As Integer
    Dim TEMPUPLOADROW As Integer
    Public edit As Boolean
    Dim TEMPPONO As String
    Public TEMPSONO As Integer
    Dim EXPIRY As Boolean = False

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub getmax_no()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(ORDER_NO),0) + 1 ", "ORDERMASTER", " AND ORDER_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTORDERNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Sub clear()

        EP.Clear()
        tstxtbillno.Clear()
        ORDERDATE.Value = Mydate
        CMBNAME.Text = ""
        txtadd.Clear()
        TXTPONO.Clear()
        PODATE.Value = Mydate
        TXTREFNO.Clear()
        TXTCRDAYS.Clear()
        DELDATE.Value = Mydate
        CMBSHADECARD.SelectedIndex = 0
        CMBMULTIUPS.SelectedIndex = 0
        CMBPOSNEG.SelectedIndex = 0
        TXTREMARKS.Clear()
        TXTBUYERNAME.Clear()
        TXTSRNO.Text = 1
        CMBITEMCODE.Text = ""
        CMBITEMNAME.Text = ""
        TXTGRADE.Clear()
        TXTMATERIALCODE.Clear()
        SCHDATE.Clear()
        TXTQTY.Clear()
        CMBUNIT.Text = ""
        TXTRATE.Clear()
        TXTPROCESSINGCHGS.Clear()
        TXTAMT.Clear()
        gridorders.RowCount = 0
        gridDoubleClick = False
        gridUPLOADDoubleClick = False
        TXTUPLOADSRNO.Text = 1
        txtuploadremarks.Clear()
        txtuploadname.Clear()
        PBSOFTCOPY.Image = Nothing
        TXTIMGPATH.Clear()
        gridupload.RowCount = 0
        TabControl1.SelectedIndex = 0
        LBLTOTALAMT.Text = "0.00"
        LBLTOTALQTY.Text = "0.00"
        lbllocked.Visible = False
        PBlock.Visible = False
        LBLASSEBLYDONE.Visible = False
        CMBSHIPTO.Text = ""
        getmax_no()
        LBLJOBDOCKETDONE.Visible = False

        EXPIRY = False

    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        clear()
        edit = False
        CMBNAME.Focus()
    End Sub

    Private Sub Order_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then CMDOK_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F5 Then     'grid focus
                gridorders.Focus()
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call toolprevious_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call toolnext_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.D1 Then
                TabControl1.SelectedIndex = 0
            ElseIf e.Alt = True And e.KeyCode = Keys.D2 Then
                TabControl1.SelectedIndex = 1
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolPREVIOUS_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_CLICK(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' AND ACC_TYPE = 'ACCOUNTS'")
            If CMBSHIPTO.Text.Trim = "" Then fillname(CMBSHIPTO, edit, "AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
            If CMBITEMCODE.Text.Trim = "" Then fillITEMCODE(CMBITEMCODE, edit)
            If CMBUNIT.Text.Trim = "" Then fillUNIT(CMBUNIT)
            If CMBITEMNAME.Text.Trim = "" Then fillITEMNAME(CMBITEMNAME, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub Order_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE ORDER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            FILLCMB()
            clear()
            CMBNAME.Enabled = True

            ''If ClientName = "IYMP" Then
            ''    CMDCLOSE.Visible = False
            ''End If

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim objORDER As New ClsOrder()
                Dim dt_no As DataTable = objORDER.selectNO(TEMPSONO, YearId)
                If dt_no.Rows.Count > 0 Then
                    For Each dr As DataRow In dt_no.Rows
                        TXTORDERNO.Text = TEMPSONO
                        CMBNAME.Text = Convert.ToString(dr("NAME"))
                        TXTPONO.Text = Convert.ToString(dr("PONO"))
                        TEMPPONO = Convert.ToString(dr("PONO"))
                        PODATE.Value = Format(Convert.ToDateTime(dr("PODATE")).Date, "dd/MM/yyyy")
                        CMBSHADECARD.Text = Convert.ToString(dr("SHADECARD"))
                        CMBMULTIUPS.Text = dr("MULTIUPS")
                        CMBPOSNEG.Text = dr("POSNEG")
                        TXTREFNO.Text = Convert.ToString(dr("REFNO"))

                        If Convert.ToString(dr("TYPE")) = "LOCAL" Then
                            RBLOCAL.Checked = True
                        Else
                            RBEXPORT.Checked = True
                        End If

                        ORDERDATE.Value = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        txtadd.Text = Convert.ToString(dr("ADDRESS"))
                        TXTCRDAYS.Text = Convert.ToString(dr("CRDAYS"))
                        DELDATE.Value = Format(Convert.ToDateTime(dr("DELDATE")).Date, "dd/MM/yyyy")
                        TXTREMARKS.Text = Convert.ToString(dr("REMARKS"))
                        TXTBUYERNAME.Text = Convert.ToString(dr("BUYERNAME"))
                        LBLTOTALAMT.Text = Format((Val(dr("TOTALAMT"))), "0.00")
                        LBLTOTALQTY.Text = Format((Val(dr("TOTALQTY"))), "0.00")
                        CMBSHIPTO.Text = Convert.ToString(dr("SHIPTO"))
                        ''GRID ROW
                        gridorders.Rows.Add(Val(dr("SRNO")), dr("ITEMCODE").ToString, dr("ITEMNAME").ToString, dr("GRADE").ToString, dr("MCODE").ToString, dr("SCHDATE").ToString, Format(Val(dr("QTY")), "0.00"), dr("UNIT").ToString, Format(Val(dr("BASICRATE")), "0.0000"), Format(Val(dr("PROCHARGE")), "0.000"), Format(Val(dr("AMT")), "0.000"), dr("DONE"), Val(dr("OUTQTY")), dr("SHORTCLOSE"), Format(Val(dr("JOBQTY"))), Format(Val(dr("DELOUTQTY"))), Format(Val(dr("ASSEMBLYOUTQTY"))), dr("JOBDOCKETDONE"))


                        If (dr("OUTQTY")) > 0 Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                            gridorders.Rows(gridorders.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                        End If

                        If Convert.ToBoolean(dr("SHORTCLOSE")) = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                            gridorders.Rows(gridorders.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGreen
                        End If


                        If (dr("ASSEMBLYOUTQTY")) > 0 Then
                            gridorders.Rows(gridorders.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            LBLASSEBLYDONE.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If Convert.ToBoolean(dr("JOBDOCKETDONE")) = True Then
                            gridorders.Rows(gridorders.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            LBLJOBDOCKETDONE.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                            gridorders.Rows(gridorders.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGreen
                        End If


                        If (dr("DELOUTQTY")) > 0 Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If
                    Next
                    gridorders.FirstDisplayedScrollingRowIndex = gridorders.RowCount - 1

                    '' GRID UPLOAD
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("ISNULL(ORDER_UPSRNO, 0) AS SRNO, ISNULL(ORDER_UPREMARKS, '') AS REMARKS, ISNULL(ORDER_UPNAME, '') AS NAME, ORDER_IMG AS IMGPATH", "", "ORDERMASTER_UPLOAD", "AND ORDERMASTER_UPLOAD.ORDER_NO= " & TEMPSONO & "  AND ORDER_YEARID = " & YearId & " ORDER BY ORDERMASTER_UPLOAD.ORDER_UPSRNO")
                    If DT.Rows.Count > 0 Then
                        For Each DTR As DataRow In DT.Rows
                            gridupload.Rows.Add(DTR("SRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                        Next
                    End If

                    'Dim OBJCM As New ClsCommon
                    'Dim DT3 As DataTable = OBJCM.search("ISNULL(ALLORDERMASTER.ORDER_NO, 0) AS ORDERNO, ISNULL(ALLORDERMASTER.ORDER_PONO, '') AS PONO, ISNULL(ALLORDERMASTER.TYPE, '') AS TYPE, ISNULL(ALLORDERMASTER_DESC.ORDER_GRIDSRNO, 0) AS ORDERSRNO, ISNULL(ALLORDERMASTER_DESC.ORDER_QTY - ALLORDERMASTER_DESC.ORDER_OUTQTY, 0) AS QUANTITY, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE , ISNULL(SUBITEMMASTER.ITEM_CODE,'') AS SUBITEMCODE", "", "ALLORDERMASTER INNER JOIN ALLORDERMASTER_DESC ON ALLORDERMASTER.ORDER_NO = ALLORDERMASTER_DESC.ORDER_NO AND ALLORDERMASTER.TYPE = ALLORDERMASTER_DESC.TYPE AND ALLORDERMASTER.ORDER_YEARID = ALLORDERMASTER_DESC.ORDER_YEARID INNER JOIN ITEMMASTER ON ALLORDERMASTER_DESC.ORDER_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN ITEMMASTER_BOMDETAILS ON ITEMMASTER_BOMDETAILS.ITEM_ID = ITEMMASTER.ITEM_ID LEFT OUTER JOIN ITEMMASTER AS SUBITEMMASTER ON ITEMMASTER_BOMDETAILS.ITEM_SUBITEMID = SUBITEMMASTER.ITEM_ID LEFT OUTER JOIN  LEDGERS ON ALLORDERMASTER.ORDER_LEDGERID = LEDGERS.Acc_id ", " AND ISNULL(SUBITEMMASTER.ITEM_CODE,'') NOT IN (SELECT ISNULL(ITEMMASTER.item_code,'') FROM  JOBBATCHMASTER LEFT OUTER JOIN ITEMMASTER ON JOBBATCHMASTER.JOB_SUBITEMID = ITEMMASTER.item_id )AND ALLORDERMASTER.ORDER_NO= " & TEMPSONO & " AND ALLORDERMASTER.order_YEARID=" & YearId & " ORDER BY ALLORDERMASTER.ORDER_NO ")

                    'If DT3.Rows.Count = 0 Then
                    '    lbllocked.Visible = True
                    '    PBlock.Visible = True
                    'End If

                End If

            Else
                edit = False
                clear()
            End If
            total()

            If gridorders.RowCount > 0 Then
                TXTSRNO.Text = Val(gridorders.Rows(gridorders.RowCount - 1).Cells(0).Value) + 1
            Else
                TXTSRNO.Text = 1
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, txtadd, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS", "ACCOUNTS")
            DUPLICATION()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim IntResult As Integer

            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(TXTPONO.Text.Trim)
            alParaval.Add(PODATE.Value.Date)
            alParaval.Add(CMBSHADECARD.Text.Trim)
            alParaval.Add(CMBMULTIUPS.Text.Trim)
            alParaval.Add(CMBPOSNEG.Text.Trim)
            alParaval.Add(TXTREFNO.Text.Trim)

            If RBLOCAL.Checked = True Then
                alParaval.Add("LOCAL")
            Else
                alParaval.Add("EXPORT")

            End If
            alParaval.Add(ORDERDATE.Value.Date)
            alParaval.Add(txtadd.Text.Trim)
            alParaval.Add(Val(TXTCRDAYS.Text.Trim))
            alParaval.Add(DELDATE.Value.Date)
            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(TXTBUYERNAME.Text.Trim)
            alParaval.Add(Val(LBLTOTALQTY.Text.Trim))
            alParaval.Add(Val(LBLTOTALAMT.Text.Trim))
            alParaval.Add(CMBSHIPTO.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            'ADDING FORMTYPE
            Dim SRNO As String = ""
            Dim ITEMCODE As String = ""
            Dim grade As String = ""
            Dim SCHDATE As String = ""
            Dim quantity As String = ""
            Dim unit As String = ""
            Dim brate As String = ""
            Dim procharge As String = ""
            Dim amount As String = ""
            Dim DONE As String = ""
            Dim OUTQTY As String = ""
            Dim CLOSE As String = ""
            Dim JOBQTY As String = ""
            Dim DELOUTQTY As String = ""
            Dim ASSEMBLYDONE As String = ""
            Dim ASSEMBLYOUTQTY As String = ""







            For Each row As Windows.Forms.DataGridViewRow In gridorders.Rows
                If row.Cells(0).Value <> Nothing Then
                    If SRNO = "" Then
                        SRNO = Val(row.Cells(GSRNO.Index).Value)
                        ITEMCODE = row.Cells(Gitemcode.Index).Value.ToString
                        grade = row.Cells(Ggrade.Index).Value
                        SCHDATE = row.Cells(GSCHDATE.Index).Value
                        quantity = Val(row.Cells(GQty.Index).Value)
                        unit = row.Cells(Gunit.Index).Value
                        brate = Val(row.Cells(Gbasicrate.Index).Value)
                        procharge = Val(row.Cells(Gprocessingchgs.Index).Value)
                        amount = Val(row.Cells(Gamount.Index).Value)
                        If Convert.ToBoolean(row.Cells(Gdone.Index).Value) = True Then
                            DONE = 1
                        Else
                            DONE = 0
                        End If
                        OUTQTY = Val(row.Cells(GOUTQTY.Index).Value)
                        If Convert.ToBoolean(row.Cells(GCLOSE.Index).Value) = True Then
                            CLOSE = 1
                        Else
                            CLOSE = 0
                        End If

                        JOBQTY = Val(row.Cells(GJOBQTY.Index).Value)
                        DELOUTQTY = Val(row.Cells(GDELOUTQTY.Index).Value)
                        ' If Convert.ToBoolean(row.Cells(GASSEMBLYDONE.Index).Value) = 0 The
                        ASSEMBLYOUTQTY = Val(row.Cells(GASSEMBLYOUTQTY.Index).Value)





                        Else
                            SRNO = SRNO & "|" & Val(row.Cells(GSRNO.Index).Value)
                        ITEMCODE = ITEMCODE & "|" & row.Cells(Gitemcode.Index).Value.ToString
                        grade = grade & "|" & row.Cells(Ggrade.Index).Value
                        SCHDATE = SCHDATE & "|" & row.Cells(GSCHDATE.Index).Value
                        quantity = quantity & "|" & Val(row.Cells(GQty.Index).Value)
                        unit = unit & "|" & row.Cells(Gunit.Index).Value
                        brate = brate & "|" & Val(row.Cells(Gbasicrate.Index).Value)
                        procharge = procharge & "|" & Val(row.Cells(Gprocessingchgs.Index).Value)
                        amount = amount & "|" & Val(row.Cells(Gamount.Index).Value)
                        If Convert.ToBoolean(row.Cells(Gdone.Index).Value) = True Then
                            DONE = DONE & "|" & "1"
                        Else
                            DONE = DONE & "|" & "0"
                        End If
                        OUTQTY = OUTQTY & "|" & Val(row.Cells(GOUTQTY.Index).Value)
                        If Convert.ToBoolean(row.Cells(GCLOSE.Index).Value) = True Then
                            CLOSE = CLOSE & "|" & "1"
                        Else
                            CLOSE = CLOSE & "|" & "0"
                        End If
                        JOBQTY = JOBQTY & "|" & Val(row.Cells(GJOBQTY.Index).Value)
                        DELOUTQTY = DELOUTQTY & "|" & Val(row.Cells(GDELOUTQTY.Index).Value)
                        ASSEMBLYOUTQTY = ASSEMBLYOUTQTY & "|" & Val(row.Cells(GASSEMBLYOUTQTY.Index).Value)





                    End If
                End If
            Next
            alParaval.Add(SRNO)
            alParaval.Add(ITEMCODE)
            alParaval.Add(grade)
            alParaval.Add(SCHDATE)
            alParaval.Add(quantity)
            alParaval.Add(unit)
            alParaval.Add(brate)
            alParaval.Add(procharge)
            alParaval.Add(amount)
            alParaval.Add(DONE)
            alParaval.Add(OUTQTY)
            alParaval.Add(CLOSE)
            alParaval.Add(JOBQTY)
            alParaval.Add(DELOUTQTY)
            alParaval.Add(ASSEMBLYOUTQTY)






            Dim OBJORDER As New ClsOrder()
            OBJORDER.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                IntResult = OBJORDER.save()
                MessageBox.Show("Details Added")
            Else
                alParaval.Add(TEMPSONO)
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                IntResult = OBJORDER.update()
                MessageBox.Show("Details Updated")
                edit = False
            End If

            If gridupload.RowCount > 0 Then SAVEUPLOAD()
            clear()
            CMBNAME.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub SAVEUPLOAD()
        Try
            Dim OBJORDER As New ClsOrder

            For Each ROW As Windows.Forms.DataGridViewRow In gridupload.Rows
                If ROW.Cells(GUSRNO.Index).Value <> Nothing Then
                    Dim MS As New IO.MemoryStream
                    Dim ALPARAVAL As New ArrayList
                    ALPARAVAL.Add(Val(TXTORDERNO.Text.Trim))
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

    Private Function ERRORVALID() As Boolean
        Dim bln As Boolean = True


        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, " Please Fill Company Name ")
            bln = False
        End If

        'If ClientName <> "GANESHMUDRA" Then
        '    If TXTPONO.Text.Trim.Length = 0 Then
        '        EP.SetError(TXTPONO, " Please Fill PO NO ")
        '        bln = False
        '    End If
        'End If

        If gridorders.RowCount = 0 Then
            EP.SetError(TXTAMT, "Enter Item Details")
            bln = False
        End If

        For Each row As DataGridViewRow In gridorders.Rows
            If row.Cells(Gitemcode.Index).Value.ToString = "" Then
                EP.SetError(CMBITEMCODE, "ITEMNAME Cannot be Blank")
                bln = False
            End If

            If Val(row.Cells(GQty.Index).Value) = 0 Then
                EP.SetError(TXTQTY, "Qty Cannot be 0")
                bln = False
            End If

            If ClientName <> "GANESHMUDRA" Then
                If Val(row.Cells(Gbasicrate.Index).Value) = 0 Then
                    EP.SetError(TXTRATE, "Rate Cannot be 0")
                    bln = False
                End If
            End If

            Dim OBJ As New ClsCommon
            Dim DT As DataTable = OBJ.search(" LEDGERS.Acc_cmpname AS CMPNAME", "", " LEDGERS INNER JOIN ORDERMASTER ON ORDERMASTER.ORDER_LEDGERID = LEDGERS.Acc_id INNER JOIN ORDERMASTER_DESC ON ORDERMASTER.ORDER_NO = ORDERMASTER_DESC.ORDER_NO INNER JOIN ITEMMASTER ON ORDERMASTER_DESC.ORDER_ITEMID = ITEMMASTER.item_id ", " AND LEDGERS.Acc_cmpname = '" & CMBNAME.Text & "' AND ITEMMASTER.item_code = '" & row.Cells(Gitemcode.Index).Value & "' AND ORDERMASTER.ORDER_YEARID =  " & YearId & " ")
            If DT.Rows.Count = 0 And ClientName <> "GANESHMUDRA" Then
                row.DefaultCellStyle.BackColor = Color.Linen
                If MsgBox("First Time to make This Item, wish To Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    bln = False
                End If
            End If
        Next

        'If lbllocked.Visible = True Then
        '    EP.SetError(lbllocked, "Rec/Return Made , Delete Rec/Return First")
        '    bln = False
        'End If

        If UserName <> "Admin" Then
            If LBLASSEBLYDONE.Visible = True Then
                EP.SetError(LBLASSEBLYDONE, " Assembly Done..!!")
                bln = False
            End If

            If LBLJOBDOCKETDONE.Visible = True Then
                EP.SetError(LBLJOBDOCKETDONE, " Jobdocket Done..!!")
                bln = False
            End If
        End If



        If Not datecheck(ORDERDATE.Value) Then
            EP.SetError(ORDERDATE, "Date Not In Accounting Year")
            bln = False
        End If


        If EXPIRY = True Then
            EP.SetError(TabControl1, " Shade Card expired ")
            bln = False
        End If

        If Convert.ToDateTime(ORDERDATE.Text).Date < SOBLOCKDATE.Date Then
            EP.SetError(ORDERDATE, "Date is Blocked, Please make entries after " & Format(SOBLOCKDATE.Date, "dd/MM/yyyy"))
            bln = False
        End If

        Return bln
    End Function

    Sub total()
        If gridorders.RowCount > 0 Then

            LBLTOTALAMT.Text = "0.00"
            LBLTOTALQTY.Text = "0.00"

            For Each row As DataGridViewRow In gridorders.Rows
                If Val(row.Cells(Gamount.Index).Value) <> 0 Then LBLTOTALAMT.Text = Format(Val(LBLTOTALAMT.Text) + Val(row.Cells(Gamount.Index).Value), "0.000")
                If Val(row.Cells(GQty.Index).Value) <> 0 Then LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(row.Cells(GQty.Index).Value), "0.00")
            Next
        Else
            LBLTOTALAMT.Text = "0.00"
            LBLTOTALQTY.Text = "0.00"
        End If
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

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSRNO.GotFocus
        If gridDoubleClick = False Then
            If gridorders.RowCount > 0 Then
                TXTSRNO.Text = Val(gridorders.Rows(gridorders.RowCount - 1).Cells(GSRNO.Index).Value) + 1
            Else
                TXTSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub cmbitemcode_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITEMCODE.Enter
        Try
            If ClientName = "GANESHMUDRA" Then
                If CMBITEMCODE.Text.Trim = "" Then fillSUBITEMCODE(CMBITEMCODE, edit, " and ITEMMASTER.ITEM_MATERIALTYPE = 'FINISHED'")
            Else
                If CMBITEMCODE.Text.Trim = "" Then fillITEMCODE(CMBITEMCODE, edit)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemcode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMCODE.Validating
        Try
            If CMBITEMCODE.Text.Trim <> "" Then ITEMCODEvalidate(CMBITEMCODE, CMBITEMNAME, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLGRID()

        gridorders.Enabled = True

        If gridDoubleClick = False Then
            gridorders.Rows.Add(Val(TXTSRNO.Text.Trim), CMBITEMCODE.Text.Trim, CMBITEMNAME.Text.Trim, TXTGRADE.Text.Trim, TXTMATERIALCODE.Text.Trim, SCHDATE.Text.Trim, Format(Val(TXTQTY.Text.Trim), "0.00"), CMBUNIT.Text.Trim, Format(Val(TXTRATE.Text.Trim), "0.0000"), Format(Val(TXTPROCESSINGCHGS.Text.Trim), "0.000"), Format(Val(TXTAMT.Text.Trim), "0.000"), 0, 0, 0)
            getsrno(gridorders)
        ElseIf gridDoubleClick = True Then
            gridorders.Item(GSRNO.Index, temprow).Value = Val(TXTSRNO.Text.Trim)
            gridorders.Item(Gitemcode.Index, temprow).Value = CMBITEMCODE.Text.Trim
            gridorders.Item(Gitemname.Index, temprow).Value = CMBITEMNAME.Text.Trim
            gridorders.Item(Ggrade.Index, temprow).Value = TXTGRADE.Text.Trim
            gridorders.Item(GMATERIALCODE.Index, temprow).Value = TXTMATERIALCODE.Text.Trim
            gridorders.Item(GSCHDATE.Index, temprow).Value = SCHDATE.Text.Trim
            gridorders.Item(GQty.Index, temprow).Value = Format(Val(TXTQTY.Text.Trim), "0.00")
            gridorders.Item(Gunit.Index, temprow).Value = CMBUNIT.Text.Trim
            gridorders.Item(Gbasicrate.Index, temprow).Value = Format(Val(TXTRATE.Text.Trim), "0.0000")
            gridorders.Item(Gprocessingchgs.Index, temprow).Value = Format(Val(TXTPROCESSINGCHGS.Text.Trim), "0.000")
            gridorders.Item(Gamount.Index, temprow).Value = Format(Val(TXTAMT.Text.Trim), "0.000")
            gridDoubleClick = False
        End If
        total()
        gridorders.FirstDisplayedScrollingRowIndex = gridorders.RowCount - 1

        TXTSRNO.Clear()
        CMBITEMCODE.Text = ""
        CMBITEMNAME.Text = ""
        TXTGRADE.Clear()
        SCHDATE.Clear()
        TXTQTY.Clear()
        CMBUNIT.Text = ""
        TXTRATE.Clear()
        TXTMATERIALCODE.Clear()
        TXTPROCESSINGCHGS.Clear()
        TXTAMT.Clear()
        TXTSRNO.Text = gridorders.RowCount + 1
        CMBITEMCODE.Focus()


    End Sub

    Sub fillupload()

        If gridUPLOADDoubleClick = False Then
            gridupload.Rows.Add(Val(TXTUPLOADSRNO.Text.Trim), txtuploadremarks.Text.Trim, txtuploadname.Text.Trim, PBSOFTCOPY.Image)
            getsrno(gridupload)
        ElseIf gridUPLOADDoubleClick = True Then
            gridupload.Item(GUSRNO.Index, TEMPUPLOADROW).Value = Val(TXTUPLOADSRNO.Text.Trim)
            gridupload.Item(GUREMARKS.Index, TEMPUPLOADROW).Value = txtuploadremarks.Text.Trim
            gridupload.Item(GUNAME.Index, TEMPUPLOADROW).Value = txtuploadname.Text.Trim
            gridupload.Item(GUIMGPATH.Index, TEMPUPLOADROW).Value = PBSOFTCOPY.Image

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

    Private Sub gridorders_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridorders.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        If e.RowIndex >= 0 And gridorders.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

            If (gridorders.Rows(e.RowIndex).Cells(GOUTQTY.Index).Value) > 0 Then
                MsgBox("Item Locked. First Delete Docket !", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If (gridorders.Rows(e.RowIndex).Cells(GCLOSE.Index).Value) = True Then
                MsgBox("Order Closed !", MsgBoxStyle.Critical)
                Exit Sub
            End If

            gridDoubleClick = True
            TXTSRNO.Text = gridorders.Item(GSRNO.Index, e.RowIndex).Value.ToString
            CMBITEMCODE.Text = gridorders.Item(Gitemcode.Index, e.RowIndex).Value.ToString
            CMBITEMNAME.Text = gridorders.Item(Gitemname.Index, e.RowIndex).Value.ToString
            TXTGRADE.Text = gridorders.Item(Ggrade.Index, e.RowIndex).Value.ToString
            TXTMATERIALCODE.Text = gridorders.Item(GMATERIALCODE.Index, e.RowIndex).Value.ToString
            SCHDATE.Text = gridorders.Item(GSCHDATE.Index, e.RowIndex).Value.ToString
            TXTQTY.Text = gridorders.Item(GQty.Index, e.RowIndex).Value.ToString
            CMBUNIT.Text = gridorders.Item(Gunit.Index, e.RowIndex).Value.ToString
            TXTRATE.Text = gridorders.Item(Gbasicrate.Index, e.RowIndex).Value.ToString
            TXTPROCESSINGCHGS.Text = gridorders.Item(Gprocessingchgs.Index, e.RowIndex).Value.ToString
            TXTAMT.Text = gridorders.Item(Gamount.Index, e.RowIndex).Value.ToString

            temprow = e.RowIndex
            TXTSRNO.Focus()
        End If
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTQTY.KeyPress
        numdot3(e, TXTQTY, Me)
    End Sub

    Private Sub txtbasicrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress
        numdotkeypress(e, TXTRATE, Me)
    End Sub

    Private Sub txtprocessingchgs_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPROCESSINGCHGS.KeyPress
        numdot3(e, TXTPROCESSINGCHGS, Me)
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
            If edit = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Unable To Delete", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                'If Val(GOUTQTY.Index) > 0 Then
                '    MsgBox("Unable To Delete", MsgBoxStyle.Critical)
                '    Exit Sub
                'End If


                If MsgBox("Wish To Delete Order.?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If MsgBox("Are you Sure?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        Dim alParaval As New ArrayList
                        alParaval.Add(TXTORDERNO.Text.Trim)
                        alParaval.Add(YearId)
                        alParaval.Add(Userid)

                        Dim clspo As New ClsOrder()
                        clspo.alParaval = alParaval
                        Dim IntResult As Integer = clspo.Delete()
                        MsgBox("Order Deleted")
                        clear()
                        edit = False
                    End If
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbunit_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBUNIT.Enter
        Try
            If CMBUNIT.Text.Trim = "" Then fillUNIT(CMBUNIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbunit_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBUNIT.Validating
        Try
            If CMBUNIT.Text.Trim <> "" Then unitvalidate(CMBUNIT, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If gridorders.CurrentRow.Index >= 0 And gridorders.Item(GSRNO.Index, gridorders.CurrentRow.Index).Value <> Nothing Then

                If Convert.ToBoolean(gridorders.CurrentRow.Cells(Gdone.Index).Value) = True Then
                    MsgBox("Item Locked, Job Docket Raised", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                gridDoubleClick = True
                TXTSRNO.Text = gridorders.Item(GSRNO.Index, gridorders.CurrentRow.Index).Value.ToString
                CMBITEMCODE.Text = gridorders.Item(Gitemcode.Index, gridorders.CurrentRow.Index).Value.ToString
                CMBITEMNAME.Text = gridorders.Item(Gitemname.Index, gridorders.CurrentRow.Index).Value.ToString
                TXTGRADE.Text = gridorders.Item(Ggrade.Index, gridorders.CurrentRow.Index).Value.ToString
                TXTMATERIALCODE.Text = gridorders.Item(GMATERIALCODE.Index, gridorders.CurrentRow.Index).Value.ToString
                SCHDATE.Text = gridorders.Item(GSCHDATE.Index, gridorders.CurrentRow.Index).Value.ToString
                TXTQTY.Text = Val(gridorders.Item(GQty.Index, gridorders.CurrentRow.Index).Value)
                CMBUNIT.Text = gridorders.Item(Gunit.Index, gridorders.CurrentRow.Index).Value.ToString
                TXTRATE.Text = Val(gridorders.Item(Gbasicrate.Index, gridorders.CurrentRow.Index).Value)
                TXTPROCESSINGCHGS.Text = gridorders.Item(Gprocessingchgs.Index, gridorders.CurrentRow.Index).Value.ToString
                TXTAMT.Text = gridorders.Item(Gamount.Index, gridorders.CurrentRow.Index).Value.ToString

                temprow = gridorders.CurrentRow.Index
                CMBITEMCODE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridorders_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridorders.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridorders.RowCount > 0 Then

                If gridDoubleClick = True Then
                    MessageBox.Show("Row Is In Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                If Convert.ToBoolean(gridorders.CurrentRow.Cells(Gdone.Index).Value) = True Then
                    MsgBox("Item Locked, Job Docket Raised", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                gridorders.Rows.RemoveAt(gridorders.CurrentRow.Index)
                total()
                getsrno(gridorders)
                total()
            End If

            If e.KeyCode = Keys.F8 Then EDITROW()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                gridorders.RowCount = 0
                TEMPSONO = Val(tstxtbillno.Text)
                If TEMPSONO > 0 Then
                    edit = True
                    Order_Load(sender, e)
                Else
                    edit = False
                    clear()
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJORDER As New OrderDetails
            OBJORDER.MdiParent = MDIMain
            OBJORDER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call CMDOK_Click(sender, e)
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            gridorders.RowCount = 0
LINE1:
            TEMPSONO = Val(TXTORDERNO.Text) - 1
            If TEMPSONO > 0 Then
                edit = True
                Order_Load(sender, e)
            Else
                edit = False
                clear()
            End If
            If gridorders.RowCount = 0 And TEMPSONO > 1 Then
                TXTORDERNO.Text = TEMPSONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            gridorders.RowCount = 0
LINE1:
            TEMPSONO = Val(TXTORDERNO.Text) + 1
            getmax_no()
            Dim MAXNO As Integer = TXTORDERNO.Text.Trim
            clear()
            If Val(TXTORDERNO.Text) - 1 >= TEMPSONO Then
                edit = True
                Order_Load(sender, e)
            Else
                edit = False
                clear()
            End If
            If gridorders.RowCount = 0 And TEMPSONO < MAXNO Then
                TXTORDERNO.Text = TEMPSONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub CALC()
        Try
            TXTAMT.Text = 0.0
            If Val(TXTRATE.Text) > 0 And Val(TXTQTY.Text.Trim) > 0 Then TXTAMT.Text = Format(Val((TXTRATE.Text) * Val(TXTQTY.Text)) + Val(TXTPROCESSINGCHGS.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtbasicrate_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTRATE.Validated
        CALC()
    End Sub

    Private Sub txtqty_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTQTY.Validated
        CALC()
    End Sub

    Private Sub txtprocessingchgs_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTPROCESSINGCHGS.Validated
        CALC()
    End Sub

    Private Sub deldate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DELDATE.Validating
        Try
            If DELDATE.Value.Date < ORDERDATE.Value.Date Then
                MsgBox("Enter Proper Date !")
                e.Cancel = True
            End If
            TXTCRDAYS.Clear()
            TXTCRDAYS.Text = DELDATE.Value.Date.Subtract(ORDERDATE.Value.Date).Days

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKITEM() As Boolean
        Try
            Dim BLN As Boolean = True
            For Each ROW As Windows.Forms.DataGridViewRow In gridorders.Rows
                If (gridDoubleClick = False) Or (gridDoubleClick = True And temprow <> ROW.Index) Then
                    If CMBITEMCODE.Text.Trim = ROW.Cells(Gitemcode.Index).Value.ToString Then
                        BLN = False
                    End If
                End If
            Next
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub txtamt_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTAMT.Validating
        If CMBITEMCODE.Text.Trim <> "" And CMBITEMNAME.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 And CMBUNIT.Text.Trim <> "" Then

            If Not CHECKITEM() Then
                MsgBox("Item Code already Present Below", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If ClientName <> "GANESHMUDRA" And Val(TXTRATE.Text.Trim) = 0 Then
                MsgBox("Enter Rate", MsgBoxStyle.Critical)
                Exit Sub
            End If

            fillgrid()
            total()
        Else
            If CMBITEMCODE.Text.Trim = "" Then
                MsgBox("Please Fill Item CODE ")
                CMBITEMCODE.Focus()
                Exit Sub
            End If
            If CMBITEMNAME.Text.Trim = "" Then
                MsgBox("Please Fill Item Name ")
                CMBITEMNAME.Focus()
                Exit Sub
            End If

            If CMBUNIT.Text.Trim = "" Then
                MsgBox("Please Fill Unit")
                CMBUNIT.Focus()
                Exit Sub
            End If

            If Val(TXTQTY.Text.Trim) = 0 Then
                MsgBox("Please Fill Quntity ")
                TXTQTY.Focus()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub CMBITEMNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMCODE.Text.Trim = "" And CMBITEMNAME.Text.Trim = "" Then TXTREMARKS.Focus()
            If CMBITEMNAME.Text.Trim <> "" Then ITEMNAMEVALIDATE(CMBITEMNAME, e, Me)

            'DONE BY MIHIR
            Dim OBJCMN As New ClsCommon
            Dim DT1 As New DataTable
            DT1 = OBJCMN.search(" ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ACCOUNTSMASTER_SHADECARD.ACC_EXPDATE,GETDATE()) AS EXPDATE ", "", " ITEMMASTER INNER JOIN ACCOUNTSMASTER_SHADECARD ON ITEMMASTER.item_id = ACCOUNTSMASTER_SHADECARD.ACC_ITEMID INNER JOIN LEDGERS ON ACCOUNTSMASTER_SHADECARD.ACC_ID = LEDGERS.Acc_id ", "AND ITEMMASTER.ITEM_CODE = '" & CMBITEMCODE.Text.Trim & " 'AND LEDGERS.Acc_cmpname = '" & CMBNAME.Text.Trim & "' AND ACCOUNTSMASTER_SHADECARD.acc_YEARID  = " & YearId & " AND ACCOUNTSMASTER_SHADECARD.Acc_EXPDATE < '" & Format(Convert.ToDateTime(ORDERDATE.Text), " yyyy/MM/dd ") & "'")
            If DT1.Rows.Count > 0 Then
                If MsgBox(" Shade Card Expired for " & CMBITEMCODE.Text.Trim & ", Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    EXPIRY = True
                    e.Cancel = True
                    Exit Sub
                Else
                    EXPIRY = False
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub DUPLICATION()
        Try
            If TXTPONO.Text.Trim <> "" Then
                If (edit = False) Or (edit = True And TXTPONO.Text.Trim <> TEMPPONO) Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search(" ORDERMASTER.ORDER_PONO", "", " ORDERMASTER ", "  AND ORDERMASTER.ORDER_PONO = '" & TXTPONO.Text.Trim & "' AND ORDER_YEARID  = " & YearId)
                    If DT.Rows.Count > 0 Then
                        MsgBox("P.O. No Already Exists")
                        TXTPONO.Focus()
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCRDAYS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCRDAYS.Validating
        Try
            If (Val(TXTCRDAYS.Text.Trim)) > 0 Then DELDATE.Value = DateAdd(DateInterval.Day, Val(TXTCRDAYS.Text.Trim), ORDERDATE.Value.Date)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCRDAYS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCRDAYS.KeyPress
        numkeypress(e, TXTCRDAYS, Me)
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry DEBTORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpono_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPONO.Validating
        Try
            DUPLICATION()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSHORTCLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLOSE.Click
        Try
            If edit = True Then
                If MsgBox("Wish to Close Order No " & Val(TEMPSONO) & " of Item Code " & (gridorders.CurrentRow.Cells(Gitemcode.Index).Value) & " and Qty " & Val(gridorders.CurrentRow.Cells(GQty.Index).Value) & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If MsgBox("Are you sure?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Dim OBJCMN As New ClsCommon
                        Dim DT As DataTable
                        DT = OBJCMN.Execute_Any_String("UPDATE ORDERMASTER_DESC SET ORDER_CLOSE =1 WHERE ORDER_NO =  " & Val(TEMPSONO) & "  AND ORDER_GRIDSRNO = " & Val(gridorders.CurrentRow.Cells(GSRNO.Index).Value) & " AND ORDER_YEARID = " & YearId, "", "")
                        MsgBox("Order Closed")
                        gridorders.CurrentRow.DefaultCellStyle.BackColor = Color.LightGreen
                    End If
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

                TEMPUPLOADROW = e.RowIndex
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

    Private Sub TXTUPLOADSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTUPLOADSRNO.GotFocus
        If gridUPLOADDoubleClick = False Then
            If gridupload.RowCount > 0 Then
                TXTUPLOADSRNO.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
            Else
                TXTUPLOADSRNO.Text = 1
            End If
        End If
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

    Private Sub gridupload_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridupload.KeyDown
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

    Private Sub CMBITEMNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        If CMBITEMNAME.Text.Trim = "" Then fillITEMNAME(CMBITEMNAME, edit)
    End Sub

    Private Sub gridupload_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If e.RowIndex >= 0 Then PBSOFTCOPY.Image = gridupload.Rows(e.RowIndex).Cells(GUIMGPATH.Index).Value
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Validated
        Try
            Dim OBJCMN As New ClsCommon
            If CMBITEMCODE.Text.Trim <> "" Then

                Dim DT As DataTable = OBJCMN.search("ISNULL(ITEM_MATERIALCODE,'') AS MCODE, ITEM_SHADEDATE AS VALIDTILL", "", "ITEMMASTER", "AND ITEMMASTER.ITEM_CODE = '" & CMBITEMCODE.Text.Trim & "' AND ITEM_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    TXTMATERIALCODE.Text = DT.Rows(0).Item("MCODE")
                    'WE ARE CHECKING ITEM SHADE CARD VALIDITY WITH RESPECT TO PARTY NAME BELOW
                    'If DT.Rows(0).Item("VALIDTILL") <> "/  /" Then
                    '    'CHECKING VALIDITY
                    '    If Convert.ToDateTime(DT.Rows(0).Item("VALIDTILL")).Date < ORDERDATE.Value.Date Then
                    '        If MsgBox("Shade Card Validity Has Expired, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    '            CMBITEMNAME.Focus()
                    '            Exit Sub
                    '        End If
                    '    End If
                    'End If
                End If
            End If

            'DONE BY MIHIR
            'Dim DT1 As New DataTable
            'DT1 = OBJCMN.search(" ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ACCOUNTSMASTER_SHADECARD.ACC_EXPDATE,GETDATE()) AS EXPDATE ", "", " ITEMMASTER INNER JOIN ACCOUNTSMASTER_SHADECARD ON ITEMMASTER.item_id = ACCOUNTSMASTER_SHADECARD.ACC_ITEMID INNER JOIN LEDGERS ON ACCOUNTSMASTER_SHADECARD.ACC_ID = LEDGERS.Acc_id ", "AND ITEMMASTER.ITEM_CODE = '" & CMBITEMCODE.Text.Trim & " 'AND LEDGERS.Acc_cmpname = '" & CMBNAME.Text.Trim & "' AND ACCOUNTSMASTER_SHADECARD.acc_YEARID  = " & YearId & " AND ACCOUNTSMASTER_SHADECARD.Acc_EXPDATE < '" & Format(Convert.ToDateTime(ORDERDATE.Text), " yyyy/MM/dd ") & "'")
            'If DT1.Rows.Count > 0 Then
            '    If MsgBox(" Shade Card Expired for " & CMBITEMCODE.Text.Trim & ", Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            '        EXPIRY = True
            '        Exit Sub
            '    Else
            '        EXPIRY = False
            '    End If
            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHIPTO_Enter(sender As Object, e As EventArgs) Handles CMBSHIPTO.Enter
        Try
            If CMBSHIPTO.Text.Trim = "" Then fillname(CMBSHIPTO, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHIPTO_Validating(sender As Object, e As CancelEventArgs) Handles CMBSHIPTO.Validating
        Try
            If CMBSHIPTO.Text.Trim <> "" Then namevalidate(CMBSHIPTO, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Order_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        If ClientName = "GANESHMUDRA" Then
            CMBITEMNAME.Enabled = False
            TXTGRADE.TabStop = False
            TXTMATERIALCODE.TabStop = False
        End If
    End Sub


    Private Sub SCHDATE_Validating(sender As Object, e As CancelEventArgs) Handles SCHDATE.Validating
        Try

            Try
                If SCHDATE.Text.Trim <> "__/__/____" Then
                    'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                    Dim TEMP As DateTime
                    If Not DateTime.TryParse(SCHDATE.Text, TEMP) Then
                        MsgBox("Enter Proper Date")
                        e.Cancel = True

                        'Exit Sub
                    End If
                End If





            Catch ex As Exception
                Throw ex
            End Try

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SCHDATE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SCHDATE.KeyPress
        numkeypress(e, SCHDATE, Me)
    End Sub

    Private Sub CMBITEMCODE_Validated(sender As Object, e As EventArgs) Handles CMBITEMCODE.Validated
        If CMBITEMCODE.Text.Trim <> "" Then
            Dim dt As New DataTable
            Dim OBJCMN As New ClsCommon
            Dim DTTCS As DataTable = OBJCMN.search("  ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE ", "", " ORDERMASTER_DESC LEFT OUTER JOIN ITEMMASTER ON ORDERMASTER_DESC.ORDER_ITEMID = ITEMMASTER.item_id ", " AND ISNULL(ITEMMASTER.ITEM_NAME,'')='" & CMBITEMCODE.Text & "'  AND  ORDERMASTER_DESC.ORDER_YEARID = " & YearId)
            If DTTCS.Rows.Count > 0 Then
                CMBSHADECARD.Text = "No"
                CMBMULTIUPS.Text = "No"
            Else
                CMBSHADECARD.Text = "Yes"
                CMBMULTIUPS.Text = "Yes"
            End If

        End If
    End Sub
End Class