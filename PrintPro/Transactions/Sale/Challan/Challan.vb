
Imports BL
Imports System.IO
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class Challan

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim gridUPLOADDoubleClick As Boolean
    Dim temprow As Integer
    Dim TEMPUPLOADROW As Integer
    Public edit As Boolean
    Public TEMPCHALLANNO As Integer
    Dim tempMsg As Integer
    Public DTBATCH As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
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

    Sub getmax_challan_no()
        Dim dttable As DataTable
        dttable = getmax("ISNULL(MAX(CHALLAN_NO),0)+1", "CHALLANMASTER", " AND CHALLAN_CMPID = " & CmpId & " AND CHALLAN_YEARID = " & YearId)
        If dttable.Rows.Count > 0 Then
            txtchallan.Text = dttable(0).Item(0)
        End If
    End Sub

    Sub CLEAR()
        tstxtbillno.Clear()
        'txtbatchno.Clear()
        txtchallan.ReadOnly = False
        CMBNAME.Text = ""
        txtrefno.Clear()
        cmbtrans.Text = ""
        txtlrno.Clear()
        cmbcity.Text = ""
        txtadd.Clear()
        TXTQCGSM.Clear()
        TXTQCDESIGN.Clear()
        TXTQCSIZE.Clear()
        txtpono.Clear()
        lbllocked.Visible = False
        PBlock.Visible = False
        CMDSELECTJOB.Enabled = True
        gridchallan.RowCount = 0
        txtremarks.Clear()
        lbltotalpack.Text = "0"
        lbltotalqty.Text = "0"
        lbltotalship.Text = "0"
        Ep.Clear()
        txtlrno.Clear()
        PODATE.Value = Mydate
        TXTSHIPPER1.Clear()
        TXTSHIPPER2.Clear()
        TXTSHIPPER3.Clear()

        getmax_challan_no()
        gridUPLOADDoubleClick = False
        challandate.Value = Mydate
        lrdate.Value = Mydate
        MFGDATE.Value = Mydate
        TXTUPLOADSRNO.Text = 1
        txtuploadremarks.Clear()
        txtuploadname.Clear()
        PBSOFTCOPY.Image = Nothing
        TXTIMGPATH.Clear()
        gridupload.RowCount = 0

        TabControl1.SelectedIndex = 0
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        edit = False
        challandate.Focus()
    End Sub

    Private Sub Challan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then CMDOK_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Left And e.Alt Then
                toolprevious_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt Then
                toolnext_Click(sender, e)
            ElseIf e.KeyCode = Keys.D1 And e.Alt Then
                TabControl1.SelectedIndex = 0
            ElseIf e.KeyCode = Keys.D2 And e.Alt Then
                TabControl1.SelectedIndex = 1
            ElseIf e.KeyCode = Keys.F2 Then
                tstxtbillno.Focus()
            ElseIf e.Alt = True And e.KeyCode = Keys.P Then
                If edit = True Then Call PRINTREPORT(TEMPCHALLANNO)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Challan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'CHALLAN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            CLEAR()
            If ClientName <> "IYMP" Then
                gBatch.ReadOnly = True
                CMDSELECTJOB.Text = "Select Batch"
            Else
                gBatch.ReadOnly = False
                CMDSELECTJOB.Text = "Select Job"
            End If
            FILLCMB()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJCHALLAN As New ClsChallan
                Dim DT As DataTable = OBJCHALLAN.selectNO(TEMPCHALLANNO, YearId)

                If DT.Rows.Count > 0 Then
                    For Each DR As DataRow In DT.Rows
                        txtchallan.Text = TEMPCHALLANNO
                        txtchallan.ReadOnly = True
                        challandate.Value = Format(Convert.ToDateTime(DR("DATE")).Date, "dd/MM/yyyy")
                        MFGDATE.Value = Format(Convert.ToDateTime(DR("MFGDATE")).Date, "dd/MM/yyyy")
                        txtorderno.Text = Convert.ToString(DR("ORDERNO"))
                        TXTORDERGSRNO.Text = Convert.ToString(DR("ORDERSRNO"))
                        TXTJOBNO.Text = Convert.ToString(DR("JOBNO"))
                        txtpono.Text = Convert.ToString(DR("PONO"))
                        CMBNAME.Text = Convert.ToString(DR("NAME"))
                        PODATE.Value = Format(Convert.ToDateTime(DR("PODATE")).Date, "dd/MM/yyyy")
                        txtrefno.Text = Convert.ToString(DR("REFNO"))
                        cmbtrans.Text = Convert.ToString(DR("TRANSPORTNAME"))
                        txtlrno.Text = Convert.ToString(DR("LRNO"))
                        lrdate.Value = Format(Convert.ToDateTime(DR("LRDATE")).Date, "dd/MM/yyyy")
                        cmbcity.Text = Convert.ToString(DR("CITYNAME"))
                        txtadd.Text = Convert.ToString(DR("ADDRESS"))
                        TXTLOTNO.Text = Convert.ToString(DR("LOTNO"))
                        TXTQCDESIGN.Text = Convert.ToString(DR("DESIGN"))
                        TXTQCSIZE.Text = Convert.ToString(DR("SIZE"))
                        TXTQCGSM.Text = Convert.ToString(DR("GSM"))
                        txtremarks.Text = Convert.ToString(DR("REMARKS"))
                        lbltotalqty.Text = Convert.ToString(DR("QTY"))
                        lbltotalship.Text = Convert.ToString(DR("SHIPPERS"))
                        lbltotalpack.Text = Convert.ToString(DR("PACKET"))

                        ''GRID VALUES
                        gridchallan.Rows.Add(Val(DR("SRNO")), DR("ITEMNAME").ToString, DR("ITEMCODE").ToString, Val(DR("CHALLANQTY")), DR("MCODE").ToString, DR("BATCHNO").ToString, Format(Val(DR("SHIPPER")), "0"), Format(Val(DR("PACKETS")), "0"), Val(DR("JOBBATCHNO")))

                        TXTSHIPPER1.Text = DR("SHIPPER1")
                        TXTSHIPPER2.Text = DR("SHIPPER2")
                        TXTSHIPPER3.Text = DR("SHIPPER3")

                        If Convert.ToBoolean(DR("DONE")) = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next

                    '' GRID UPLOAD
                    Dim OBJCMN As New ClsCommon
                    Dim DTT As DataTable = OBJCMN.search("ISNULL(CHALLAN_UPSRNO, 0) AS SRNO, ISNULL(CHALLAN_UPREMARKS, '') AS REMARKS, ISNULL(CHALLAN_UPNAME, '') AS NAME, CHALLAN_IMGPATH AS IMGPATH", "", "CHALLANMASTER_UPLOAD", "AND CHALLANMASTER_UPLOAD.CHALLAN_NO= " & TEMPCHALLANNO & "  AND CHALLAN_YEARID = " & YearId & " ORDER BY CHALLANMASTER_UPLOAD.CHALLAN_UPSRNO")
                    If DTT.Rows.Count > 0 Then
                        For Each DTR As DataRow In DTT.Rows
                            gridupload.Rows.Add(DTR("SRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                        Next
                    End If
                    gridchallan.FirstDisplayedScrollingRowIndex = gridchallan.RowCount - 1
                    'TOTAL()
                    CMDSELECTJOB.Enabled = False
                End If
            Else
                edit = False
                CLEAR()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, edit, "AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
        If cmbcity.Text.Trim = "" Then fillCITY(cmbcity, edit)
        If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' AND ACC_TYPE = 'ACCOUNTS'")

    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                gridchallan.RowCount = 0
                TEMPCHALLANNO = Val(tstxtbillno.Text)

                If TEMPCHALLANNO > 0 Then
                    edit = True
                    Challan_Load(sender, e)
                Else
                    edit = False
                    CLEAR()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            gridchallan.RowCount = 0
line1:
            TEMPCHALLANNO = Val(txtchallan.Text) - 1
            If TEMPCHALLANNO > 0 Then
                edit = True
                Challan_Load(sender, e)
            Else
                edit = False
                CLEAR()
            End If
            If gridchallan.RowCount = 0 And TEMPCHALLANNO > 1 Then
                txtchallan.Text = TEMPCHALLANNO
                GoTo line1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            gridchallan.RowCount = 0
line1:
            TEMPCHALLANNO = Val(txtchallan.Text) + 1
            getmax_challan_no()
            Dim maxNO As Integer = txtchallan.Text.Trim
            CLEAR()
            If Val(txtchallan.Text) - 1 >= TEMPCHALLANNO Then
                edit = True
                Challan_Load(sender, e)
            Else
                edit = False
                CLEAR()
            End If
            If gridchallan.RowCount = 0 And TEMPCHALLANNO < maxNO Then
                txtchallan.Text = TEMPCHALLANNO
                GoTo line1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FETCHDATA(ByVal JOBNO As Integer)
        Try
            Dim objcmn As New ClsCommon
            Dim dt As DataTable = objcmn.search("ISNULL(jobmaster.job_no, 0) AS JOBNO, ISNULL(jobmaster.job_orderno, 0) AS ORDERNO, ISNULL(jobmaster.job_ordersrno, 0) AS ORDERSRNO, ISNULL(ORDERMASTER.ORDER_PONO, '') AS PONO, ORDERMASTER.ORDER_PODATE AS DATE, ISNULL(ORDERMASTER.ORDER_REFNO, 0) AS REFNO, ISNULL(LEDGERS.Acc_cmpname, '') AS PARTYNAME, ISNULL(LEDGERS.Acc_add, '') AS ADDRESS, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME,ISNULL(ITEMMASTER.ITEM_MATERIALCODE,'')AS MCODE ,ISNULL(jobmaster.job_madeqty, 0) AS QTY,ISNULL(jobmaster.JOB_TOTALSHIPPERS, 0) AS SHIPPERS ,ISNULL(jobmaster.JOB_TOTALPACKETS, 0) AS PACKETS ", "", "jobmaster INNER JOIN LEDGERS ON jobmaster.JOB_LEDGERID = LEDGERS.Acc_id AND jobmaster.job_yearid = LEDGERS.Acc_yearid INNER JOIN ITEMMASTER ON jobmaster.job_itemid = ITEMMASTER.item_id AND jobmaster.job_yearid = ITEMMASTER.item_yearid INNER JOIN ORDERMASTER ON jobmaster.job_orderno = ORDERMASTER.ORDER_NO AND jobmaster.job_yearid = ORDERMASTER.ORDER_YEARID", " AND JOBMASTER.JOB_NO = " & JOBNO & " AND JOBMASTER.JOB_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                For Each DR As DataRow In dt.Rows
                    TXTJOBNO.Text = Convert.ToString(DR("JOBNO"))
                    txtorderno.Text = Convert.ToString(DR("ORDERNO"))
                    TXTORDERGSRNO.Text = Convert.ToString(DR("ORDERSRNO"))
                    txtpono.Text = Convert.ToString(DR("PONO"))
                    PODATE.Text = DR("DATE")
                    txtrefno.Text = Convert.ToString(DR("REFNO"))
                    CMBNAME.Text = Convert.ToString(DR("PARTYNAME"))
                    txtadd.Text = Convert.ToString(DR("ADDRESS"))
                    lbltotalqty.Text = Convert.ToString(DR("QTY"))
                    lbltotalship.Text = Convert.ToString(DR("SHIPPERS"))
                    lbltotalpack.Text = Convert.ToString(DR("PACKETS"))

                    ''GRID VALUE
                    gridchallan.Rows.Add(0, DR("ITEMNAME").ToString, DR("ITEMCODE").ToString, Val(DR("QTY")), DR("MCODE").ToString, "", DR("SHIPPERS").ToString, DR("PACKETS").ToString)
                    getsrno(gridchallan)
                    CMDSELECTJOB.Enabled = False
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTORDER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTJOB.Click
        Try
            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor

            If ClientName = "IYMP" Then

                Dim OBJSELECTJOB As New SelectJob
                OBJSELECTJOB.ShowDialog()
                Dim ORDERDT As DataTable = OBJSELECTJOB.DT
                If ORDERDT.Rows.Count > 0 Then FETCHDATA(ORDERDT.Rows(0).Item(0))


            ElseIf ClientName = "AMR" Then

                Dim OBJASSEMBLY As New SelectAssembly
                Dim DTASEMMBLY As DataTable = OBJASSEMBLY.DT
                OBJASSEMBLY.ShowDialog()

                Dim i As Integer = 0
                If DTASEMMBLY.Rows.Count > 0 Then
                    Dim objcmn As New ClsCommon
                    For Each DTROW As DataRow In DTASEMMBLY.Rows
                        Dim dt As DataTable = objcmn.search("ISNULL(ASSEMBLYQC.AS_NO, 0) AS ASNO, ASSEMBLYQC.AS_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS PARTYNAME, ISNULL(LEDGERS.Acc_add, '') AS ADDRESS, ISNULL(ITEMMASTER.item_code, '')  AS ITEMCODE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(ITEMMASTER.ITEM_MATERIALCODE, '') AS MCODE, ISNULL(ASSEMBLYQC.AS_BATCHNO, 0) AS BATCHNO,  ISNULL(ASSEMBLYQC.AS_TOTALPACKETS, 0) AS PACKETS, ISNULL(ASSEMBLYQC.AS_TOTALSHIPPERS, 0) AS SHIPPERS, ISNULL(ASSEMBLYQC.AS_QTY, '') AS QTY, ISNULL(ALLORDERMASTER.ORDER_PONO, '') AS PONO,  ALLORDERMASTER.ORDER_PODATE AS PODATE, ISNULL(ALLORDERMASTER.ORDER_REFNO, '') AS REFNO, ISNULL(ASSEMBLYQC.AS_ORDERNO, 0) AS ORDERNO, ISNULL(ASSEMBLYQC.AS_ORDERSRNO, 0)  AS ORDERSRNO ", "", " ASSEMBLYQC INNER JOIN ALLORDERMASTER ON ASSEMBLYQC.AS_ORDERNO = ALLORDERMASTER.ORDER_NO AND ASSEMBLYQC.AS_YEARID = ALLORDERMASTER.ORDER_YEARID INNER JOIN ALLORDERMASTER_DESC ON ASSEMBLYQC.AS_ORDERSRNO = ALLORDERMASTER_DESC.ORDER_GRIDSRNO AND ALLORDERMASTER.ORDER_NO = ALLORDERMASTER_DESC.ORDER_NO AND  ALLORDERMASTER.ORDER_YEARID = ALLORDERMASTER_DESC.ORDER_YEARID LEFT OUTER JOIN ITEMMASTER ON ASSEMBLYQC.AS_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS ON ASSEMBLYQC.AS_LEDGERID = LEDGERS.Acc_id   ", " AND ASSEMBLYQC.AS_NO = " & Val(DTROW(0)) & " AND ASSEMBLYQC.AS_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then

                            txtorderno.Text = dt.Rows(0).Item("ORDERNO")
                            TXTORDERGSRNO.Text = dt.Rows(0).Item("ORDERSRNO")
                            TXTJOBNO.Text = dt.Rows(0).Item("ASNO")                               '' WE USED TXTJOBNO TEXTBOX FOR ASSEMBLYNO
                            txtpono.Text = dt.Rows(0).Item("PONO")
                            PODATE.Text = dt.Rows(0).Item("PODATE")
                            txtrefno.Text = dt.Rows(0).Item("REFNO")
                            CMBNAME.Text = dt.Rows(0).Item("PARTYNAME")
                            txtadd.Text = dt.Rows(0).Item("ADDRESS")

                            ''GRID VALUE
                            For Each DR As DataRow In dt.Rows
                                gridchallan.Rows.Add(0, DR("ITEMNAME").ToString, DR("ITEMCODE").ToString, Format(Val(DR("QTY")), "0"), DR("MCODE").ToString, DR("BATCHNO"), Format(Val(DR("SHIPPERS")), "0").ToString, Format(Val(DR("PACKETS"))), "")
                            Next
                            If TXTLOTNO.Text.Trim = "" Then
                                Dim DTT As DataTable = objcmn.search("ISNULL(CONSUMPTION_DESC.CONSUME_LOTNO, '') AS LOTNO", "", "CONSUMPTION INNER JOIN CONSUMPTION_DESC ON CONSUMPTION.CONSUME_NO = CONSUMPTION_DESC.CONSUME_no AND CONSUMPTION.CONSUME_yearid = CONSUMPTION_DESC.CONSUME_yearid", " AND CONSUMPTION.CONSUME_BATCHNO = '" & dt.Rows(0).Item("BATCHNO") & "'  AND CONSUMPTION.CONSUME_YEARID = " & YearId)
                                If DTT.Rows.Count > 0 Then
                                    TXTLOTNO.Text = DTT.Rows(0).Item("LOTNO")
                                End If
                            End If

                            TOTAL()
                            getsrno(gridchallan)
                            CMDSELECTJOB.Enabled = False
                        End If
                    Next
                End If

            Else

                Dim OBJSELECTBATCH As New SelectBatch
                Dim DTBATCH As DataTable = OBJSELECTBATCH.DT
                OBJSELECTBATCH.TYPE = "CHALLAN"
                OBJSELECTBATCH.ShowDialog()

                Dim i As Integer = 0
                If DTBATCH.Rows.Count > 0 Then
                    Dim objcmn As New ClsCommon
                    For Each DTROW As DataRow In DTBATCH.Rows
                        Dim dt As DataTable = objcmn.search("ISNULL(BATCHMASTER.jobbatch_no, 0) AS BATCHNO, ISNULL(BATCHMASTER.jobbatch_docketno, '0') AS JOBDOCKETNO, ISNULL(ORDERMASTER.ORDER_PONO, '0') AS PONO,ISNULL(JOBBATCHMASTER.JOB_ORDERNO, '0') AS ORDERNO,ISNULL(JOBBATCHMASTER.JOB_ORDERSRNO, '0') AS ORDERSRNO, ORDERMASTER.ORDER_PODATE AS PODATE, ISNULL(ORDERMASTER.ORDER_REFNO, '') AS REFNO, ISNULL(LEDGERS.Acc_cmpname, '') AS PARTYNAME, ISNULL(LEDGERS.Acc_add, '') AS ADDRESS, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(ITEMMASTER.ITEM_MATERIALCODE, '') AS MCODE, ISNULL(BATCHMASTER.jobbatch_totalpackets, '0') AS PACKETS, ISNULL(BATCHMASTER.jobbatch_totalshippers, 0) AS SHIPPERS, ISNULL(BATCHMASTER.jobbatch_madeqty, 0) AS QTY", "", " ITEMMASTER INNER JOIN LEDGERS INNER JOIN JOBBATCHMASTER INNER JOIN BATCHMASTER ON JOBBATCHMASTER.job_no = BATCHMASTER.jobbatch_docketno AND JOBBATCHMASTER.job_yearid = BATCHMASTER.jobbatch_yearid ON LEDGERS.Acc_id = JOBBATCHMASTER.JOB_LEDGERID AND LEDGERS.Acc_yearid = JOBBATCHMASTER.job_yearid ON ITEMMASTER.item_id = BATCHMASTER.jobbatch_itemid AND ITEMMASTER.item_yearid = BATCHMASTER.jobbatch_yearid INNER JOIN ORDERMASTER ON JOBBATCHMASTER.job_orderno = ORDERMASTER.ORDER_NO AND JOBBATCHMASTER.job_yearid = ORDERMASTER.ORDER_YEARID ", " AND JOBBATCHMASTER.JOB_NO = " & Val(DTROW(0)) & " AND  BATCHMASTER.JOBBATCH_NO= " & Val(DTROW(1)) & " AND JOBBATCHMASTER.JOB_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then

                            txtorderno.Text = dt.Rows(0).Item("ORDERNO")
                            TXTORDERGSRNO.Text = dt.Rows(0).Item("ORDERSRNO")
                            TXTJOBNO.Text = dt.Rows(0).Item("JOBDOCKETNO")
                            txtpono.Text = dt.Rows(0).Item("PONO")
                            PODATE.Text = dt.Rows(0).Item("PODATE")
                            txtrefno.Text = dt.Rows(0).Item("REFNO")
                            CMBNAME.Text = dt.Rows(0).Item("PARTYNAME")
                            txtadd.Text = dt.Rows(0).Item("ADDRESS")

                            ''GRID VALUE
                            For Each DR As DataRow In dt.Rows
                                gridchallan.Rows.Add(0, DR("ITEMNAME").ToString, DR("ITEMCODE").ToString, Format(Val(DR("QTY")), "0"), DR("MCODE").ToString, DR("BATCHNO"), Format(Val(DR("SHIPPERS")), "0").ToString, Format(Val(DR("PACKETS"))), DR("JOBDOCKETNO").ToString)
                            Next
                            If TXTLOTNO.Text.Trim = "" Then
                                Dim DTT As DataTable = objcmn.search("ISNULL(CONSUMPTION_DESC.CONSUME_LOTNO, '') AS LOTNO", "", "CONSUMPTION INNER JOIN CONSUMPTION_DESC ON CONSUMPTION.CONSUME_NO = CONSUMPTION_DESC.CONSUME_no AND CONSUMPTION.CONSUME_yearid = CONSUMPTION_DESC.CONSUME_yearid", " AND CONSUMPTION.CONSUME_BATCHNO = '" & dt.Rows(0).Item("BATCHNO") & "'  AND CONSUMPTION.CONSUME_YEARID = " & YearId)
                                If DTT.Rows.Count > 0 Then
                                    TXTLOTNO.Text = DTT.Rows(0).Item("LOTNO")
                                End If
                            End If

                            TOTAL()
                            getsrno(gridchallan)
                            CMDSELECTJOB.Enabled = False
                        End If
                    Next
                End If
            End If


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub TOTAL()
        Try
            lbltotalqty.Text = 0
            lbltotalpack.Text = 0.0
            lbltotalship.Text = 0.0
            For Each ROW As DataGridViewRow In gridchallan.Rows
                lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(ROW.Cells(gQty.Index).Value), "0")
                lbltotalpack.Text = Format(Val(lbltotalpack.Text) + Val(ROW.Cells(gPackets.Index).EditedFormattedValue), "0")
                lbltotalship.Text = Format(Val(lbltotalship.Text) + Val(ROW.Cells(gShippers.Index).EditedFormattedValue), "0")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ERRORVALID() As Boolean
        Dim bln As Boolean = True

        If txtpono.Text.Trim.Length = 0 Then
            Ep.SetError(txtpono, "Select Docket for Challan")
            bln = False
        End If

        If cmbtrans.Text.Trim.Length = 0 Then
            Ep.SetError(cmbtrans, "Enter Transport Name")
            bln = False
        End If

        If lbllocked.Visible = True Then
            Ep.SetError(lbllocked, "Rec/Return Made , Delete Rec/Return First")
            bln = False
        End If

        If Not datecheck(challandate.Value) Then
            Ep.SetError(challandate, "Date Not In Accounting Year")
            bln = False
        End If

        If Not datecheck(MFGDATE.Value) Then
            Ep.SetError(MFGDATE, "Date Not In Accounting Year")
            bln = False
        End If


        Dim OBJCMN As New ClsCommon
        Dim dttable As New DataTable
        If Val(txtchallan.Text.Trim) <> 0 And edit = False Then
            dttable = OBJCMN.search(" ISNULL(CHALLANMASTER.CHALLAN_NO,0)  AS CHALLANNO", "", " CHALLANMASTER ", "  AND CHALLANMASTER.CHALLAN_NO=" & txtchallan.Text.Trim & " AND CHALLANMASTER.CHALLAN_YEARID = " & YearId)
            If dttable.Rows.Count > 0 Then
                Ep.SetError(txtchallan, "Challan No Already Exist")
                bln = False
            End If
        End If


        'LOCK EXCESS QTY IF % MENTIONED IN PARTY MASTER
        'WE WILL GET ORDER QTY FROM ORDERMASTER 
        'WE WILL CHECK THE TOTALQTY DISPATCHED FOR THIS ORDER AND THEN ON THIS TOTAL CALC, EXCESS %
        Dim EXCESSPER As Double = 0
        Dim TOTALORDERQTY As Double = 0
        Dim TOTALDISPATCHEDQTY As Double = 0
        dttable = OBJCMN.search("ISNULL(LEDGERS.ACC_ACCESSQUANTITY,0) AS EXCESSQTY", "", " LEDGERS ", " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
        If dttable.Rows.Count > 0 Then
            EXCESSPER = Val(dttable.Rows(0).Item("EXCESSQTY"))

            If EXCESSPER > 0 Then
                'GET TOTAL ORDERED QTY FROM ORDERMASTER
                dttable = OBJCMN.search("ISNULL(ORDERMASTER.ORDER_TOTALQTY,0) AS ORDERQTY", "", " ORDERMASTER ", " AND ORDERMASTER.ORDER_PONO = '" & txtpono.Text.Trim & "' AND ORDERMASTER.ORDER_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then TOTALORDERQTY = Val(dttable.Rows(0).Item("ORDERQTY")) + ((Val(dttable.Rows(0).Item("ORDERQTY")) * EXCESSPER) / 100)


                'GET TOTAL CHALLANQTY FOR THIS PONO
                dttable = OBJCMN.search("ISNULL(SUM(CHALLANMASTER.CHALLAN_QTY),0) AS DISPATCHQTY", "", " CHALLANMASTER ", " AND CHALLANMASTER.CHALLAN_PONO = '" & txtpono.Text.Trim & "' AND CHALLANMASTER.CHALLAN_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then TOTALDISPATCHEDQTY = Val(dttable.Rows(0).Item("DISPATCHQTY"))

                If Val(TOTALDISPATCHEDQTY) + Val(lbltotalqty.Text.Trim) > Val(TOTALORDERQTY) Then
                    Ep.SetError(CMBNAME, "Excess Qty Not Allowed")
                    bln = False
                End If
            End If

        End If

        Return bln

    End Function

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Dim INTRESULT As Integer
        Try
            Cursor.Current = Cursors.WaitCursor
            Ep.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim ALPARAVAL As New ArrayList
            ALPARAVAL.Add(Val(txtchallan.Text.Trim))
            ALPARAVAL.Add(challandate.Value.Date)
            ALPARAVAL.Add(MFGDATE.Value.Date)
            ALPARAVAL.Add(txtorderno.Text.Trim)
            ALPARAVAL.Add(TXTORDERGSRNO.Text.Trim)
            ALPARAVAL.Add(TXTJOBNO.Text.Trim)
            ALPARAVAL.Add(txtpono.Text.Trim)
            ALPARAVAL.Add(CMBNAME.Text.Trim)
            ALPARAVAL.Add(PODATE.Value.Date)
            ALPARAVAL.Add(txtrefno.Text.Trim)
            ALPARAVAL.Add(cmbtrans.Text.Trim)
            ALPARAVAL.Add(txtlrno.Text.Trim)
            ALPARAVAL.Add(lrdate.Value.Date)
            ALPARAVAL.Add(cmbcity.Text.Trim)
            ALPARAVAL.Add(txtadd.Text.Trim)
            ALPARAVAL.Add(TXTLOTNO.Text.Trim)
            ALPARAVAL.Add(TXTQCDESIGN.Text.Trim)
            ALPARAVAL.Add(TXTQCSIZE.Text.Trim)
            ALPARAVAL.Add(TXTQCGSM.Text.Trim)
            ALPARAVAL.Add(txtremarks.Text.Trim)
            ALPARAVAL.Add(Val(lbltotalqty.Text.Trim))
            ALPARAVAL.Add(Val(lbltotalship.Text.Trim))
            ALPARAVAL.Add(Val(lbltotalpack.Text.Trim))

            If chkdone.CheckState = True Then
                ALPARAVAL.Add(1)
            Else
                ALPARAVAL.Add(0)
            End If

            ALPARAVAL.Add(ClientName)
            ALPARAVAL.Add(TXTSHIPPER1.Text.Trim)
            ALPARAVAL.Add(TXTSHIPPER2.Text.Trim)
            ALPARAVAL.Add(TXTSHIPPER3.Text.Trim)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)
            ALPARAVAL.Add(0)

            '' GRID PARAMETERS
            Dim SRNO As String = ""
            Dim ITEMCODE As String = ""
            Dim QTY As String = ""
            Dim BATCHNO As String = ""
            Dim SHIPPERS As String = ""
            Dim PACKETS As String = ""
            Dim JOBBATCHNO As String = ""

            For Each ROW As Windows.Forms.DataGridViewRow In gridchallan.Rows
                If ROW.Cells(0).Value.ToString <> Nothing Then
                    If SRNO = "" Then
                        SRNO = Val(ROW.Cells(GSRNO.Index).Value)
                        ITEMCODE = ROW.Cells(gitemcode.Index).Value.ToString
                        QTY = Val(ROW.Cells(gQty.Index).Value).ToString
                        If ROW.Cells(gBatch.Index).Value = Nothing Then BATCHNO = "" Else BATCHNO = ROW.Cells(gBatch.Index).Value.ToString
                        SHIPPERS = Val(ROW.Cells(gShippers.Index).Value).ToString
                        PACKETS = Val(ROW.Cells(gPackets.Index).Value).ToString
                        JOBBATCHNO = Val(ROW.Cells(GJOBBATCHNO.Index).Value)
                    Else
                        SRNO = SRNO & "|" & Val(ROW.Cells(GSRNO.Index).Value)
                        ITEMCODE = ITEMCODE & "|" & ROW.Cells(gitemcode.Index).Value.ToString
                        QTY = QTY & "|" & Val(ROW.Cells(gQty.Index).Value).ToString
                        If ROW.Cells(gBatch.Index).Value = Nothing Then BATCHNO = BATCHNO & "" Else BATCHNO = BATCHNO & "|" & ROW.Cells(gBatch.Index).Value.ToString
                        SHIPPERS = SHIPPERS & "|" & Val(ROW.Cells(gShippers.Index).Value).ToString
                        PACKETS = PACKETS & "|" & Val(ROW.Cells(gPackets.Index).Value).ToString
                        JOBBATCHNO = JOBBATCHNO & "|" & Val(ROW.Cells(GJOBBATCHNO.Index).Value)
                    End If
                End If
            Next
            ALPARAVAL.Add(SRNO)
            ALPARAVAL.Add(ITEMCODE)
            ALPARAVAL.Add(QTY)
            ALPARAVAL.Add(BATCHNO)
            ALPARAVAL.Add(SHIPPERS)
            ALPARAVAL.Add(PACKETS)
            ALPARAVAL.Add(JOBBATCHNO)

            Dim OBJCHLN As New ClsChallan
            OBJCHLN.alParaval = ALPARAVAL

            If edit = False Then
                If USERADD = False Then
                    MessageBox.Show("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTT As DataTable = OBJCHLN.SAVE()
                TEMPCHALLANNO = DTT.Rows(0).Item(0)
                MsgBox("Details Added")
                PRINTREPORT(TEMPCHALLANNO)

            Else
                edit = True
                If USERADD = False Then
                    MessageBox.Show("Insufficient Rights")
                    Exit Sub
                End If
                ALPARAVAL.Add(TEMPCHALLANNO)
                INTRESULT = OBJCHLN.UPDATE()
                MessageBox.Show("Details Updated")
                PRINTREPORT(TEMPCHALLANNO)
                edit = False

            End If

            If gridupload.RowCount > 0 Then SAVEUPLOAD()
            CLEAR()
            txtchallan.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SAVEUPLOAD()
        Try
            Dim OBJCHALLAN As New ClsChallan

            For Each ROW As Windows.Forms.DataGridViewRow In gridupload.Rows
                If ROW.Cells(GUSRNO.Index).Value.ToString <> Nothing Then
                    Dim MS As New IO.MemoryStream
                    Dim ALPARAVAL As New ArrayList

                    ALPARAVAL.Add(txtchallan.Text.Trim)
                    ALPARAVAL.Add(ROW.Cells(GUSRNO.Index).Value)
                    ALPARAVAL.Add(ROW.Cells(GUREMARKS.Index).Value)
                    ALPARAVAL.Add(ROW.Cells(GUNAME.Index).Value)

                    PBSOFTCOPY.Image = ROW.Cells(GUIMGPATH.Index).Value
                    PBSOFTCOPY.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    ALPARAVAL.Add(MS.ToArray)
                    ALPARAVAL.Add(YearId)

                    OBJCHALLAN.alParaval = ALPARAVAL
                    Dim INTRESULT As Integer = OBJCHALLAN.SAVEUPLOAD()
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

    Private Sub cmbtrans_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, edit, "AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtrans.Validating
        Try
            If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, CMBCODE, e, Me, TXTTRANSADD, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "TRANSPORT")

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcity_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcity.Enter
        Try
            If cmbcity.Text.Trim = "" Then fillCITY(cmbcity, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJCHLN As New ChallanDetails
            OBJCHLN.MdiParent = MDIMain
            OBJCHLN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpono_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpono.KeyDown
        Try
            If e.KeyCode = Keys.F1 And edit = False Then CMDSELECTORDER_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
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
                tempMsg = MsgBox("Wish to Delete Challan?", MsgBoxStyle.YesNo)
                If tempMsg = vbYes Then
                    tempMsg = MsgBox("Are you Sure?", MsgBoxStyle.YesNo)
                    If tempMsg = vbYes Then
                        Dim ALPARAVAL As New ArrayList
                        ALPARAVAL.Add(txtchallan.Text.Trim)
                        ALPARAVAL.Add(ClientName)
                        ALPARAVAL.Add(YearId)
                        ALPARAVAL.Add(Userid)

                        Dim OBJCHALLAN As New ClsChallan
                        OBJCHALLAN.alParaval = ALPARAVAL
                        Dim INTRESULT As Integer = OBJCHALLAN.DELETE()
                        MsgBox("Challan is Deleted!!")
                        CLEAR()
                        edit = False
                    End If
                End If
            Else
                MsgBox("Delete is only Edit Mode!")
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

    Private Sub cmbcity_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcity.Validating
        Try
            If cmbcity.Text.Trim <> "" Then CITYVALIDATE(cmbcity, e, Me)
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

    Private Sub challandate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles challandate.Validating
        If Not datecheck(challandate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub MFGDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MFGDATE.Validating
        If Not datecheck(MFGDATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub cmbcity_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbcity.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJCITY As New SelectCity
                OBJCITY.FRMSTRING = "CITY"
                OBJCITY.ShowDialog()
                If OBJCITY.TEMPNAME <> "" Then cmbcity.Text = OBJCITY.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tstxtbillno.KeyPress
        numkeypress(e, tstxtbillno, Me)
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call CMDOK_Click(sender, e)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call CMDDELETE_Click(sender, e)
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then PRINTREPORT(TEMPCHALLANNO)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal CHALLNNO As Integer)
        Try
            If ClientName = "IYMP" Then
                If MsgBox("Wish to Print Challan?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim OBJGDN As New ChallanDesign
                    OBJGDN.MdiParent = MDIMain
                    OBJGDN.FRMSTRING = "Challan"
                    OBJGDN.WHERECLAUSE = "{CHALLANMASTER.CHALLAN_NO}=" & Val(CHALLNNO) & "  and {CHALLANMASTER.CHALLAN_yearid}=" & YearId
                    OBJGDN.Show()
                End If

                If MsgBox("Wish to Print Shipper?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim OBJSHPER As New ShipperDesign
                    OBJSHPER.CHNO = Val(CHALLNNO)
                    OBJSHPER.JOBNO = Val(TXTJOBNO.Text.Trim)
                    OBJSHPER.MdiParent = MDIMain
                    If MsgBox("Print Biocon Shipper?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        OBJSHPER.FRMSTRING = "BIOCON_SHIPPER"
                    ElseIf MsgBox("Print Sandoz Shipper?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        OBJSHPER.FRMSTRING = "SANDOZ_SHIPPER"
                    Else
                        OBJSHPER.FRMSTRING = "SHIPPER"
                    End If
                    OBJSHPER.WHERECLAUSE = "{TEMPSHIPPER.CHALLAN_NO}=" & Val(CHALLNNO) & "  and {TEMPSHIPPER.CHALLAN_yearid}=" & YearId
                    OBJSHPER.Show()
                End If

                If MsgBox("Wish to Print Packets?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim OBJPACKET As New PacketDesign
                    OBJPACKET.CHNO = Val(CHALLNNO)
                    OBJPACKET.JOBNO = Val(TXTJOBNO.Text.Trim)
                    OBJPACKET.MdiParent = MDIMain
                    OBJPACKET.FRMSTRING = "PACKET"
                    OBJPACKET.WHERECLAUSE = "{TEMPPACKETS.CHALLAN_NO}=" & Val(CHALLNNO) & "  and {TEMPPACKETS.CHALLAN_yearid}=" & YearId
                    OBJPACKET.Show()
                End If

            Else

                'MILAN COA
                If ClientName = "AMR" Then
                    If MsgBox("Wish to Print COA-MILAN Report?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Dim OBJINVOICE As New SaleInvoiceDesign
                        OBJINVOICE.MdiParent = MDIMain
                        OBJINVOICE.FRMSTRING = "MILAN_COA"
                        OBJINVOICE.WHERECLAUSE = "{CHALLANMASTER.CHALLAN_NO}=" & Val(CHALLNNO) & " and {CHALLANMASTER.CHALLAN_yearid}=" & YearId
                        OBJINVOICE.Show()
                    End If

                    If MsgBox("Wish to Print Common COA Report?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Dim OBJINVOICE As New SaleInvoiceDesign
                        OBJINVOICE.MdiParent = MDIMain
                        OBJINVOICE.FRMSTRING = "CHALLANCOA"
                        OBJINVOICE.WHERECLAUSE = "{CHALLANMASTER.CHALLAN_NO}=" & Val(CHALLNNO) & " and {CHALLANMASTER.CHALLAN_yearid}=" & YearId
                        OBJINVOICE.Show()
                    End If

                End If



                If MsgBox("Wish to Print Challan?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim OBJGDN As New ChallanDesign
                    OBJGDN.MdiParent = MDIMain
                    OBJGDN.FRMSTRING = "Challan"
                    OBJGDN.WHERECLAUSE = "{CHALLANMASTER.CHALLAN_NO}=" & Val(CHALLNNO) & "  and {CHALLANMASTER.CHALLAN_yearid}=" & YearId
                    OBJGDN.Show()
                End If

                If MsgBox("Wish to Print Shipper?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim OBJSHPER As New ShipperDesign
                    OBJSHPER.CHNO = Val(CHALLNNO)
                    Dim OBJCMN As New ClsCommon
                    DTBATCH = OBJCMN.search("CHALLAN_BATCHNO AS CBATCHNO", "", "CHALLANMASTER_DESC", "AND CHALLANMASTER_DESC.CHALLAN_NO = " & Val(txtchallan.Text.Trim) & " AND CHALLANMASTER_DESC.CHALLAN_YEARID = " & YearId)
                    OBJSHPER.DTBATCH = DTBATCH
                    OBJSHPER.MdiParent = MDIMain
                    If MsgBox("Print Biocon Shipper?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        OBJSHPER.FRMSTRING = "BIOCON_SHIPPER"
                    ElseIf MsgBox("Print Sandoz Shipper?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        OBJSHPER.FRMSTRING = "SANDOZ_SHIPPER"
                    Else
                        OBJSHPER.FRMSTRING = "SHIPPER"
                    End If
                    OBJSHPER.WHERECLAUSE = "{TEMPSHIPPER.CHALLAN_NO}=" & Val(CHALLNNO) & "  and {TEMPSHIPPER.CHALLAN_yearid}=" & YearId
                    OBJSHPER.Show()
                End If

                If MsgBox("Wish to Print Packets?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim OBJPACKET As New PacketDesign
                    OBJPACKET.CHNO = Val(CHALLNNO)
                    Dim OBJCMN As New ClsCommon
                    DTBATCH = OBJCMN.search("CHALLAN_BATCHNO AS CBATCHNO", "", "CHALLANMASTER_DESC", "AND CHALLANMASTER_DESC.CHALLAN_NO = " & Val(txtchallan.Text.Trim) & " AND CHALLANMASTER_DESC.CHALLAN_YEARID = " & YearId)
                    OBJPACKET.DTBATCH = DTBATCH
                    OBJPACKET.MdiParent = MDIMain
                    OBJPACKET.FRMSTRING = "PACKET"
                    OBJPACKET.WHERECLAUSE = "{TEMPPACKETS.CHALLAN_NO}=" & Val(CHALLNNO) & "  and {TEMPPACKETS.CHALLAN_yearid}=" & YearId
                    OBJPACKET.Show()
                End If
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

    Private Sub CMDSELECTSTOCK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTSTOCK.Click
        Try

            Dim DTTABLE As New DataTable
            Dim OBJSELECTGDN As New SelectStock
            OBJSELECTGDN.TYPE = "MAINSTOCK"
            OBJSELECTGDN.ShowDialog()
            DTTABLE = OBJSELECTGDN.DT

            If DTTABLE.Rows.Count > 0 Then
                For Each dr As DataRow In DTTABLE.Rows
                    gridchallan.Rows.Add(0, dr("ITEMNAME"), dr("ITEMCODE"), Format(Val(dr("QTY")), "0.00"), "", "", "", "")
                Next
                gridchallan.FirstDisplayedScrollingRowIndex = gridchallan.RowCount - 1
                getsrno(gridchallan)
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtchallan_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtchallan.Validating
        Try
            If Val(txtchallan.Text.Trim) > 0 And edit = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(CHALLANMASTER.CHALLAN_NO,0)  AS CHALLANNO", "", " CHALLANMASTER ", "  AND CHALLANMASTER.CHALLAN_NO=" & txtchallan.Text.Trim & " AND CHALLANMASTER.CHALLAN_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Challan No Already Exist")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtchallan_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtchallan.KeyPress
        numkeypress(e, txtchallan, Me)
    End Sub

    Private Sub Challan_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If ClientName = "AMR" Then
            CMDSELECTJOB.Text = "Select Assembly"
        End If
    End Sub

    Private Sub gridchallan_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles gridchallan.CellValidating
        Dim colNum As Integer = gridchallan.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

        Select Case colNum

            Case gShippers.Index, gPackets.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If gridchallan.CurrentCell.Value = Nothing Then gridchallan.CurrentCell.Value = "0.00"
                    gridchallan.CurrentCell.Value = Convert.ToDecimal(gridchallan.Item(colNum, e.RowIndex).Value)
                    '' everything is good
                    TOTAL()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                    Exit Sub
                End If

        End Select
    End Sub

    Private Sub CMBNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, txtadd, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(sender As Object, e As EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validated(sender As Object, e As EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then

                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable

                DT = OBJCMN.search("  ISNULL(LEDGERS.Acc_add,'') AS ADDRESS", "", " LEDGERS", " AND LEDGERS.ACC_CMPNAME = '" & CMBNAME.Text.Trim & "'  AND LEDGERS.Acc_yearid = " & YearId & " ")
                If DT.Rows.Count > 0 Then txtadd.Text = DT.Rows(0).Item("ADDRESS")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class