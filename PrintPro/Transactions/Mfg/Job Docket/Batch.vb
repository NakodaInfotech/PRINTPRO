
Imports System.ComponentModel
Imports BL

Public Class Batch

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public TEMPBATCHNO, tempprocessno, TEMPBALSHEET, TEMPMSG, TEMPJOBNO As Integer
    Public tempprocessname As String
    Public edit As Boolean
    Dim TEMPUPLOADROW As Integer
    Dim gridUPLOADDoubleClick As Boolean
    Public PAPERCUTTINGPREJOBNAME As String
    Public PAPERCUTTINGPREJOBCODE As String
    Public PRINTEDLEAFLETCUTTINGPREJOBNAME As String
    Public PRINTEDLEAFLETCUTTINGPREJOBCODE As String
    Public PRINTINGPREJOBCODE As String
    Public PRINTINGPREJOBNAME As String
    Public FOLDINGPREJOBNAME As String
    Public FOLDINGPREJOBCODE As String






    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub GETSUPERVISORNAME()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(SUPERVISORMASTER.SUP_NAME, '') AS NAME ", "", "  SUPERVISORMASTER INNER JOIN SUPERVISORPROCESSCONFIG ON SUPERVISORMASTER.SUP_ID = SUPERVISORPROCESSCONFIG.SUPCONF_SUPID ", " AND SUPCONF_PROCESS = '" & lblprocess.Text.Trim & "' AND SUPCONF_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then txtsupervisor.Text = DT.Rows(0).Item("NAME")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        DTBATCHDATE.Focus()
        edit = False
    End Sub

    Sub CLEAR()
        TXTJOBDOCKETNO.Clear()
        DTJOBDOCKETDATE.Value = Mydate
        DTBATCHDATE.Value = Mydate
        tstxtbillno.Clear()

        txtpartyname.Clear()
        txtpono.Clear()

        TXT2DCODESTART.Clear()
        TXT2DCODEEND.Clear()
        txtsupervisor.Clear()
        txtpapermfg.Clear()
        txtgrade.Clear()
        txttestval.Clear()
        TXTITEMCODE.Clear()
        TXTITEMNAME.Clear()
        txtqty.Clear()
        TXTPERCENTAGE.Clear()
        txtups.Clear()
        txttotalsheets.Clear()
        gridjob.RowCount = 0
        tempprocessno = 1
        gridUPLOADDoubleClick = False
        TXTBATCHNO.ReadOnly = False

        TXTUPLOADSRNO.Text = 1
        txtuploadremarks.Clear()
        txtuploadname.Clear()
        PBSOFTCOPY.Image = Nothing
        TXTIMGPATH.Clear()
        gridupload.RowCount = 0
        TXTBOMITEMCODE.Clear()

        TabControl1.SelectedIndex = 0
        ' ''PROCESS POSITIVE
        txtsrno.Clear()
        txtcolor.Clear()
        txtplatecheckedby.Clear()
        txtcodecheckedby.Clear()
        txtupscheckedby.Clear()
        txtcorrectionappby.Clear()

        ''PROCESS PLATE
        cmbdamage.Text = "NO"
        txtplatemadeby.Clear()
        MADEDATE.Value = Mydate
        txtplatedestroyedby.Clear()
        destroyeddate.Value = Mydate
        txtplateremadeby.Clear()
        remadedate.Value = Mydate
        TXTPLATECHKBY.Clear()

        ''PROCESS PPR CUTTING 
        TXTCUTMACHINENO.Clear()
        TXTCUTTINGNAME.Clear()
        TXTCUTTABLECLEARED.Clear()
        TXTCUTMACHINPLTFORMCLR.Clear()
        TXTCUTDUSTBINFREE.Clear()
        TXTCUTMACHINEAREACLR.Clear()
        TXTCUTMACBELOWAREACLR.Clear()
        TXTCUTREJSHEETS.Clear()

        ''PROCESS PRINTING
        txtname.Clear()
        txtsheetsgiven.Clear()
        givendate.Value = Mydate
        txtbalancesheets.Clear()
        balancedate.Value = Mydate
        txtdestroyedsheets.Clear()

        TXTPRINTMACHINENO.Clear()
        TXTPRINTPLATEREMOVED.Clear()
        TXTPRINTINKPOT.Clear()
        TXTPRINTSHEETS.Clear()
        TXTPRINTPOSITIVE.Clear()
        TXTPRINTNEGATIVE.Clear()
        TXTPRINTSHADECARD.Clear()
        TXTPRINTSAMPLEREMOVE.Clear()
        TXTPRINTREGSHEETS.Clear()
        TXTPRINTFEEDERAREA.Clear()
        TXTPRINTDELIVERAREA.Clear()
        TXTPRINTDUSTBINFREE.Clear()
        TXTPRINTMACHINEAREA.Clear()
        TXTPRINTBELOWAREA.Clear()
        TXTPRINTREGSHEETS.Clear()

        TXTPRINTINGSHIFT1.Clear()
        TXTPRINTINGSHIFT2.Clear()
        TXTPRINTINGSHIFT3.Clear()

        '' PROCESS SORTING 
        TXTSORTINGAREANO.Clear()
        TXTSORTTABLECLR.Clear()
        TXTSORTDUSTBINCLR.Clear()
        TXTSORTCABINAREACLR.Clear()
        TXTSORTREJSHEETS.Clear()

        ''PROCESS FOLDING
        TXTFOLDMACHINEPLTFRMCLR.Clear()
        txtfoldingname.Clear()
        txtfoldingsheetsgiven.Clear()
        foldinggivendate.Value = Mydate
        txtfoldingv.Clear()
        txtfoldingh.Clear()
        txtsampleappby.Clear()
        txtfoldingbalancesheet.Clear()
        foldingbalancedate.Value = Mydate
        txtfoldingdestroyedsheets.Clear()

        CMBFOLDUNFOLD.SelectedIndex = 0
        TXTFOLDMACHINENO.Clear()

        TXTFOLDTABLECLR.Clear()
        TXTFOLDMACHINEPLTFRMCLR.Clear()
        TXTFOLDFEEDERAREA.Clear()
        TXTFOLDCROSSUNIT.Clear()
        TXTFOLD1STKNIFE.Clear()
        TXTFOLD2NDKNIFE.Clear()
        TXTFOLDTAPPINGUNIT.Clear()
        TXTFOLDSTACKER.Clear()
        TXTFOLDDUSTBIN.Clear()
        TXTFOLDMACHINEAREA.Clear()
        TXTFOLDBELOWAREA.Clear()
        TXTFOLDREJSHEETS.Clear()

        TXTFOLDSHIFT1.Clear()
        TXTFOLDSHIFT2.Clear()
        TXTFOLDSHIFT3.Clear()



        ''PROCESS PACKING
        txtpackingname.Clear()
        txtpacketsize.Clear()
        txtpacketitem1.Clear()
        txtpacketitem2.Clear()
        txtpacketitem3.Clear()
        txtpacket1.Clear()
        txtpacket2.Clear()
        txtpacket3.Clear()
        txtpackettotal1.Clear()
        txtpackettotal2.Clear()
        txtpackettotal3.Clear()
        txttotalpacket.Clear()
        txtptotal.Clear()

        txtshipperitem1.Clear()
        txtshipperitem2.Clear()
        txtshipperitem3.Clear()
        txtshipper1.Clear()
        txtshipper2.Clear()
        txtshipper3.Clear()
        txtshippertotal1.Clear()
        txtshippertotal2.Clear()
        txtshippertotal3.Clear()
        txttotalshipper.Clear()
        txtstotal.Clear()

        ''PROCESS FINAL
        txtshortqty.Clear()
        cmbtobeprinted.Text = "NO"

        ''PROCESS COMPLETED
        txtshortqty.Clear()
        cmbtobeprinted.Text = "NO"


        SELECTCASE()
        GETSUPERVISORNAME()

        lbllocked.Visible = False
        PBlock.Visible = False
        CMDSELECTJOBDOCKET.Enabled = True
        LBLASSEBLYDONE.Visible = False

        CMBNEW.SelectedIndex = 0

        getmax_batch_no()
        EP.Clear()
        TXTORDERNO.Clear()
        TXTORDERSRNO.Clear()
        TXTORDERTYPE.Clear()

        TXTBUNDEL.Clear()
        TXTBOXSIZE.Clear()
        TXTTRAYREQ.Clear()
        TXTBOXREQ.Clear()
    End Sub

    Sub getmax_batch_no()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax("isnull(max(JOBBATCH_NO),0) + 1", "BATCHMASTER", " AND JOBBATCH_YEARID = " & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTBATCHNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub Batch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
                'If edit = True Then Call PRINTREPORT(TEMPBATCHNO)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Batch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DTROW() As DataRow
        DTROW = USERRIGHTS.Select("FormName = 'JOB DOCKET'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        Cursor.Current = Cursors.WaitCursor

        TXTBATCHNO.ReadOnly = False

        CLEAR()
        FETCHPREDATA()

        If edit = True Then

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJBATCH As New ClsBatch
            OBJBATCH.alParaval.Add(TEMPBATCHNO)
            OBJBATCH.alParaval.Add(YearId)
            Dim DTTABLE1 As DataTable = OBJBATCH.selectNO()

            If DTTABLE1.Rows.Count > 0 Then
                For Each DR As DataRow In DTTABLE1.Rows

                    TXTBATCHNO.Text = TEMPBATCHNO
                    TXTBATCHNO.ReadOnly = True
                    DTBATCHDATE.Value = DR("BATCHDATE")
                    TXTJOBDOCKETNO.Text = Convert.ToString(DR("JOBDOCKETNO"))
                    DTJOBDOCKETDATE.Text = Convert.ToString(DR("JOBDOCKETDATE"))

                    txtpartyname.Text = Convert.ToString(DR("PARTYNAME"))
                    txtpono.Text = Convert.ToString(DR("PONO"))


                    TXTITEMNAME.Text = Convert.ToString(DR("ITEMNAME"))
                    TXTITEMCODE.Text = Convert.ToString(DR("ITEMCODE"))
                    txtqty.Text = Format(Val(DR("QTY")), "0")
                    TXTPERCENTAGE.Text = Convert.ToString(DR("PERCENTAGE"))
                    txtups.Text = Convert.ToString(DR("UPS"))

                    TXT2DCODESTART.Text = DR("2DCODESTART")
                    TXT2DCODEEND.Text = DR("2DCODEEND")


                    txtpapermfg.Text = Convert.ToString(DR("PPRMFG"))
                    txtgrade.Text = Convert.ToString(DR("GRADE"))
                    txttestval.Text = Convert.ToString(DR("TESTVALUE"))
                    txttotalsheets.Text = Convert.ToString(DR("TOTALSHEETS"))
                    txtsheetsgiven.Text = Convert.ToString(DR("SHEETSGIVEN"))
                    txtshortqty.Text = Convert.ToString(DR("SHORTQTY"))
                    txtsrno.Text = Convert.ToString(DR("FILENO"))
                    txtcolor.Text = Convert.ToString(DR("COLOR"))

                    txtpacketitem1.Text = Val(DR("PACKETITEM1"))
                    txtpacketitem2.Text = Val(DR("PACKETITEM2"))
                    txtpacketitem3.Text = Val(DR("PACKETITEM3"))
                    txtpacket1.Text = Val(DR("PACKET1"))
                    txtpacket2.Text = Val(DR("PACKET2"))
                    txtpacket3.Text = Val(DR("PACKET3"))


                    txtshipperitem1.Text = Val(DR("SHIPPERITEM1"))
                    txtshipperitem2.Text = Val(DR("SHIPPERITEM2"))
                    txtshipperitem3.Text = Val(DR("SHIPPERITEM3"))
                    txtshipper1.Text = Val(DR("SHIPPER1"))
                    txtshipper2.Text = Val(DR("SHIPPER2"))
                    txtshipper3.Text = Val(DR("SHIPPER3"))
                    TEMPBALSHEET = Val(DR("TEMPBALSHEETS"))


                    CMBNEW.Text = DR("NEW")
                    TXTBOMITEMCODE.Text = Convert.ToString(DR("SUBITEMCODE"))
                    TXTORDERNO.Text = Convert.ToString(DR("ORDERNO"))
                    TXTORDERSRNO.Text = Convert.ToString(DR("ORDERSRNO"))
                    TXTORDERTYPE.Text = Convert.ToString(DR("ORDERTYPE"))

                    TXTBUNDEL.Text = DR("BUNDEL")
                    TXTBOXSIZE.Text = DR("BOXSIZE")
                    TXTBOXREQ.Text = Val(DR("BOXREQ"))
                    TXTTRAYREQ.Text = Val(DR("TRAYREQ"))

                    TXTPRINTINGSHIFT1.Text = Val(DR("PRINTINGSHIFT1"))
                    TXTPRINTINGSHIFT2.Text = Val(DR("PRINTINGSHIFT2"))
                    TXTPRINTINGSHIFT3.Text = Val(DR("PRINTINGSHIFT3"))
                    TXTFOLDSHIFT1.Text = Val(DR("FOLDSHIFT1"))
                    TXTFOLDSHIFT2.Text = Val(DR("FOLDSHIFT2"))
                    TXTFOLDSHIFT3.Text = Val(DR("FOLDSHIFT3"))



                    If Convert.ToBoolean(DR("DONE")) = True Then
                        lbllocked.Visible = True
                        PBlock.Visible = True
                        lbllocked.Text = "Locked"
                    End If

                    If Convert.ToBoolean(DR("ASSEMBLYDONE")) = True Then
                        LBLASSEBLYDONE.Visible = True
                        lbllocked.Visible = True
                        PBlock.Visible = True
                    End If


                    If Convert.ToBoolean(DR("QCDONE")) = True Then
                        lbllocked.Visible = True
                        PBlock.Visible = True
                        lbllocked.Text = "QC DONE"
                    End If

                    ''GRID VALUES
                    If DR("PROCESS") <> "" Then gridjob.Rows.Add(DR("PROCESS").ToString, DR("SRNO"), DR("COLOR").ToString, DR("NOOFPLATES").ToString, DR("PLATETYPE").ToString, DR("PLATESIZE").ToString, DR("PLATEQC"), DR("PLATEREMARKS").ToString, DR("PLATEINTIME").ToString, DR("PLATEOUTTIME").ToString, DR("PLATECHKBY").ToString, DR("CODECHKBY").ToString, DR("UPSCHKBY").ToString, DR("CORRAPLYBY").ToString, DR("PLATEMADEBY").ToString, DR("MADEDATE").ToString, DR("PLATEDESTROY").ToString, DR("DESTROYDATE").ToString, DR("PLATEREMADE").ToString, DR("REMADEDATE").ToString, DR("PLTCHKBY").ToString, DR("NAME").ToString, DR("SHEETSGIVEN"), DR("GIVENDATE").ToString, DR("BALSHEETS"), DR("RETURNDATE").ToString, DR("SHEETSDESTROY").ToString, DR("MACHINENO").ToString, DR("TABLECLR").ToString, DR("MACHINEPTFCLR").ToString, DR("DUSTBINFREE").ToString, DR("MACHINESURRAREA").ToString, DR("AREABELOWMACHINE").ToString, DR("REJECTEDSHEETS").ToString, DR("UNFOLDREMOVEJOBDOCKET").ToString, DR("UNFOLDALLTRAY").ToString, DR("UNFOLDSORTINGBY").ToString, DR("UNFOLDCOUNTING").ToString, DR("UNFOLDPACKETBY").ToString, DR("UNFOLDLABELLEDBY").ToString, DR("UNFOLDSAMPLEAPPBY").ToString, Val(DR("UNFOLDSHEETGIVEN")), Val(DR("UNFOLDBALANCESHEET")), Val(DR("UNFOLDDESTROYEDSHEET")), DR("UNFOLDGIVENDATE".ToString), DR("UNFOLDREMARKS".ToString), DR("UNFOLDINTIME".ToString), DR("UNFOLDOUTTIME".ToString), DR("PAPERGRNNO").ToString, DR("PAPERTYPE").ToString, DR("PAPERREMARKS").ToString, DR("PAPERINTIME").ToString, DR("PAPEROUTTIME").ToString, DR("PAPERGSMQC"), DR("PAPERQUALITYQC"), DR("CUTPREJOBSHEET").ToString, DR("CUTLEAFLETSIZE").ToString, DR("SORTFLOORAREA").ToString, DR("SORTPREJOBSHEET").ToString, DR("SORTREMARKS").ToString, DR("SORTINTIME").ToString, DR("SORTOUTTIME").ToString, DR("PLATREMOVED").ToString, DR("INKPOT").ToString, DR("PRINTEDSHEETS").ToString, DR("POSITIVE").ToString, DR("NEGATIVE").ToString, DR("SHADECARD").ToString, DR("SAMPLE").ToString, DR("REGISTERSHEETS").ToString, DR("FEEDERAREA").ToString, DR("DELIVERAREA").ToString, DR("PRINTPLATETYPE").ToString, DR("PRINTREMARKS").ToString, DR("PRINTINTIME").ToString, DR("PRINTOUTTIME").ToString, DR("PRINTVARNISH"), DR("PRINTPERFORATION"), DR("PRINTTEXTMATTER"), DR("PRINTSIZE"), DR("PRINTJOBREG"), DR("PRINTCOLOR"), DR("CROSSUNIT").ToString, DR("FSTKNIFE").ToString, DR("SECONDKNIFE").ToString, DR("TAPPINGUNIT").ToString, DR("STACKERAREA").ToString, DR("FOLDBUNDLEDBY").ToString, DR("FOLDPACKETBY").ToString, DR("FOLDLABELLEDBY").ToString, DR("FOLDREMOVEDOCKET").ToString, DR("FOLDALLTHETRAY").ToString, DR("FOLDBARCODECAMERA").ToString, DR("FOLDREMARKS").ToString, DR("FOLDINTIME").ToString, DR("FOLDOUTTIME").ToString, DR("SAMPLE").ToString, DR("TOTALPACKETS"), DR("TOTALSHIPPERS"), DR("PACKETSIZE"), Val(DR("SHORTQTY")), DR("SUPERVISOR").ToString)
                    tempprocessno = tempprocessno + 1
                    CMDSELECTJOBDOCKET.Enabled = False
                    'txtpono.Enabled = False
                Next
                tempprocessno = DTTABLE1.Rows(0).Item("PROCESSNO")
                FILLTOTAL()
                If gridjob.RowCount = 0 Then tempprocessno = 1
                SELECTCASE()
                GETSUPERVISORNAME()
                If gridjob.RowCount > 0 Then gridjob.FirstDisplayedScrollingRowIndex = gridjob.RowCount - 1

                '' GRID UPLOAD
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(JOBBATCH_UPSRNO, 0) AS SRNO, ISNULL(JOBBATCH_UPREMARKS, '') AS REMARKS, ISNULL(JOBBATCH_UPNAME, '') AS NAME, JOBBATCH_IMGPATH AS IMGPATH", "", "BATCHMASTER_UPLOAD", "AND BATCHMASTER_UPLOAD.JOBBATCH_NO= " & TEMPBATCHNO & "  AND JOBBATCH_YEARID = " & YearId & " ORDER BY BATCHMASTER_UPLOAD.JOBBATCH_UPSRNO")
                If DT.Rows.Count > 0 Then
                    For Each DTR As DataRow In DT.Rows
                        gridupload.Rows.Add(DTR("SRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                    Next
                End If
            End If
        Else
            edit = False
            CLEAR()
        End If
    End Sub

    Sub FETCHPREDATA()

        TXTPREITEMCODE.Clear()
        TXTPREITEMNAME.Clear()
        TXTPREPONO.Clear()

        Dim OBJCMNN As New ClsCommon
        Dim DDT As DataTable
        If edit = False Then
            DDT = OBJCMNN.search("ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(JOBBATCHMASTER.job_pono, '') AS PONO, ISNULL(SUBITEMMASTER.item_code, '') AS SUBITEMCODE", "", " BATCHMASTER INNER JOIN JOBBATCHMASTER ON BATCHMASTER.jobbatch_docketno = JOBBATCHMASTER.job_no AND BATCHMASTER.jobbatch_yearid = JOBBATCHMASTER.job_yearid INNER JOIN ITEMMASTER ON BATCHMASTER.jobbatch_itemid = ITEMMASTER.item_id AND BATCHMASTER.jobbatch_yearid = ITEMMASTER.item_yearid LEFT OUTER JOIN ITEMMASTER AS SUBITEMMASTER ON JOBBATCHMASTER.JOB_SUBITEMID = SUBITEMMASTER.item_id ", "AND BATCHMASTER.JOBBATCH_NO = " & Val(TXTBATCHNO.Text) - 1 & " AND BATCHMASTER.JOBBATCH_YEARID = " & YearId)
        Else
            DDT = OBJCMNN.search("ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(JOBBATCHMASTER.job_pono, '') AS PONO, ISNULL(SUBITEMMASTER.item_code, '') AS SUBITEMCODE", "", " BATCHMASTER INNER JOIN JOBBATCHMASTER ON BATCHMASTER.jobbatch_docketno = JOBBATCHMASTER.job_no AND BATCHMASTER.jobbatch_yearid = JOBBATCHMASTER.job_yearid INNER JOIN ITEMMASTER ON BATCHMASTER.jobbatch_itemid = ITEMMASTER.item_id AND BATCHMASTER.jobbatch_yearid = ITEMMASTER.item_yearid LEFT OUTER JOIN ITEMMASTER AS SUBITEMMASTER ON JOBBATCHMASTER.JOB_SUBITEMID = SUBITEMMASTER.item_id ", "AND BATCHMASTER.JOBBATCH_NO = " & Val(TEMPBATCHNO) - 1 & " AND BATCHMASTER.JOBBATCH_YEARID = " & YearId)
        End If
        If DDT.Rows.Count > 0 Then
            TXTPREITEMCODE.Text = DDT.Rows(0).Item("ITEMCODE")
            TXTPREITEMNAME.Text = DDT.Rows(0).Item("ITEMNAME")
            TXTPREPONO.Text = DDT.Rows(0).Item("PONO")
            TXTBOMITEMCODE.Text = DDT.Rows(0).Item("SUBITEMCODE")

        End If

    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Dim IntResult As Integer
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim ALPARAVAL As New ArrayList
            ALPARAVAL.Add(TXTBATCHNO.Text.Trim)
            ALPARAVAL.Add(DTBATCHDATE.Value.Date)
            ALPARAVAL.Add(TXTJOBDOCKETNO.Text.Trim)
            ALPARAVAL.Add(DTJOBDOCKETDATE.Value.Date)
            ALPARAVAL.Add(txtpartyname.Text.Trim)
            ALPARAVAL.Add(txtpono.Text.Trim)
            ALPARAVAL.Add(TXTITEMCODE.Text.Trim)
            ALPARAVAL.Add(Val(txtqty.Text.Trim))
            ALPARAVAL.Add(Val(TXTPERCENTAGE.Text.Trim))
            ALPARAVAL.Add(Val(txttotalsheets.Text.Trim))

            ALPARAVAL.Add(Val(txtpacketitem1.Text.Trim))
            ALPARAVAL.Add(Val(txtpacketitem2.Text.Trim))
            ALPARAVAL.Add(Val(txtpacketitem3.Text.Trim))

            ALPARAVAL.Add(Val(txtpacket1.Text.Trim))
            ALPARAVAL.Add(Val(txtpacket2.Text.Trim))
            ALPARAVAL.Add(Val(txtpacket3.Text.Trim))
            ALPARAVAL.Add(txttotalpacket.Text.Trim)

            ALPARAVAL.Add(Val(txtshipperitem1.Text.Trim))
            ALPARAVAL.Add(Val(txtshipperitem2.Text.Trim))
            ALPARAVAL.Add(Val(txtshipperitem3.Text.Trim))

            ALPARAVAL.Add(Val(txtshipper1.Text.Trim))
            ALPARAVAL.Add(Val(txtshipper2.Text.Trim))
            ALPARAVAL.Add(Val(txtshipper3.Text.Trim))
            ALPARAVAL.Add(txttotalshipper.Text.Trim)

            ALPARAVAL.Add(Val(tempprocessno))

            ALPARAVAL.Add(txtfoldingv.Text.Trim)
            ALPARAVAL.Add(txtfoldingh.Text.Trim)
            ALPARAVAL.Add(txtshortqty.Text.Trim)

            ALPARAVAL.Add(txtpapermfg.Text.Trim)
            ALPARAVAL.Add(txtgrade.Text.Trim)
            ALPARAVAL.Add(txttestval.Text.Trim)
            ALPARAVAL.Add(CMBNEW.Text.Trim)
            ALPARAVAL.Add(TXTBOMITEMCODE.Text.Trim)


            If CHKDONE.CheckState = True Then
                ALPARAVAL.Add(1)
            Else
                ALPARAVAL.Add(0)
            End If

            ALPARAVAL.Add(TXT2DCODESTART.Text.Trim)
            ALPARAVAL.Add(TXT2DCODEEND.Text.Trim)
            ALPARAVAL.Add(txtups.Text.Trim)
            ALPARAVAL.Add(TXTORDERNO.Text.Trim)
            ALPARAVAL.Add(TXTORDERSRNO.Text.Trim)
            ALPARAVAL.Add(TXTORDERTYPE.Text.Trim)




            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)
            ALPARAVAL.Add(TXTBUNDEL.Text.Trim)
            ALPARAVAL.Add(TXTBOXSIZE.Text.Trim)
            ALPARAVAL.Add(TXTBOXREQ.Text.Trim)
            ALPARAVAL.Add(TXTTRAYREQ.Text.Trim)

            ALPARAVAL.Add(TXTPRINTINGSHIFT1.Text.Trim)
            ALPARAVAL.Add(TXTPRINTINGSHIFT2.Text.Trim)
            ALPARAVAL.Add(TXTPRINTINGSHIFT3.Text.Trim)
            ALPARAVAL.Add(TXTFOLDSHIFT1.Text.Trim)
            ALPARAVAL.Add(TXTFOLDSHIFT2.Text.Trim)
            ALPARAVAL.Add(TXTFOLDSHIFT3.Text.Trim)



            ''GRID PARAMETERS
            Dim PROCESS As String = ""
            Dim SRNO As String = ""
            Dim COLOR As String = ""
            Dim NOOFPLATE As String = ""
            Dim PLATETYPE As String = ""
            Dim PLATESIZE As String = ""
            Dim PLATEQC As String = ""
            Dim PLATEREMARKS As String = ""
            Dim PLATEINTIME As String = ""
            Dim PLATEOUTTIME As String = ""
            Dim PLATECHKBY As String = ""
            Dim CODECHKBY As String = ""
            Dim UPSCHKBY As String = ""
            Dim CORECTAPLBY As String = ""
            Dim PLATEMADEBY As String = ""
            Dim MADEDATE As String = ""
            Dim PLATEDESTROYBY As String = ""
            Dim DESTROYDATE As String = ""
            Dim PLATEREMADEBY As String = ""
            Dim REAMDEDATE As String = ""

            Dim PLTCHKBY As String = ""

            Dim NAME As String = ""
            Dim SHEETSGIVEN As String = ""
            Dim GIVENDATE As String = ""
            Dim BALSHEETS As String = ""
            Dim RETURNDATE As String = ""
            Dim UNFOLDREMOVEJOBDOCKET As String = ""
            Dim UNFOLDALLTRAY As String = ""
            Dim UNFOLDSORTINGBY As String = ""
            Dim UNFOLDCOUNTING As String = ""
            Dim UNFOLDPACKETBY As String = ""
            Dim UNFOLDLABELLEDBY As String = ""
            Dim UNFOLDSAMPLEAPPBY As String = ""
            Dim UNFOLDSHEETGIVEN As String = ""
            Dim UNFOLDBALANCESHEET As String = ""
            Dim UNFOLDDESTROYEDSHEET As String = ""
            Dim UNFOLDGIVENDATE As String = ""
            Dim UNFOLDREMARKS As String = ""
            Dim UNFOLDINTIME As String = ""
            Dim UNFOLDOUTTIME As String = ""
            Dim SHEETSDESTROY As String = ""
            ''''''
            Dim MACHINENO As String = ""
            'Dim PREJOBDETAILS As String = ""
            'Dim JOBNAME As String = ""
            Dim PAPERGRNNO As String = ""
            Dim PAPERTYPE As String = ""
            Dim PAPERREMARKS As String = ""
            Dim PAPERINTIME As String = ""
            Dim PAPEROUTTIME As String = ""
            Dim PAPERGSMQC As String = ""
            Dim PAPERQUALITYQC As String = ""
            Dim TABLECLR As String = ""
            Dim MACHINEPTFCLR As String = ""
            Dim DUSTBINCLR As String = ""
            Dim MACHINESURRAREACLR As String = ""
            Dim CUTPREJOBSHEET As String = ""
            Dim CUTLEAFLETSIZE As String = ""
            Dim AREABELOWMACHINE As String = ""
            Dim REJECTSHEETS As String = ""

            Dim SORTFLOORAREA As String = ""
            Dim SORTPREJOBSHEET As String = ""
            Dim SORTREMARKS As String = ""
            Dim SORTINTIME As String = ""
            Dim SORTOUTTIME As String = ""
            Dim PLATEREMOVED As String = ""
            Dim INKPOT As String = ""
            Dim PRINTSHEETSREMOVED As String = ""
            Dim POSITIVEREMOVED As String = ""
            Dim NEGATIVEREMOVED As String = ""
            Dim APPSHADECARD As String = ""
            Dim APPSAMPLE As String = ""
            Dim REGISTERSHEETSREMOVED As String = ""
            Dim FEEDERAREA As String = ""
            Dim DELIVERAREA As String = ""
            Dim PRINTPLATETYPE As String = ""
            Dim PRINTREMARKS As String = ""
            Dim PRINTINTIME As String = ""
            Dim PRINTOUTTIME As String = ""
            Dim PRINTVARNISH As String = ""
            Dim PRINTPERFORATION As String = ""
            Dim PRINTTEXTMATTER As String = ""
            Dim PRINTSIZE As String = ""
            Dim PRINTJOBREG As String = ""
            Dim PRINTCOLOR As String = ""
            Dim CROSSUNITAREA As String = ""
            Dim FSTKNIFEAREA As String = ""
            Dim SECONDKNIFEAREA As String = ""
            Dim TAPPINGUNIT As String = ""
            Dim STACKERAREA As String = ""

            'Dim CLEANBY As String = ""
            Dim SAMPLEAPPBY As String = ""
            Dim FOLDBUNDLEDBY As String = ""
            Dim FOLDPACKETBY As String = ""
            Dim FOLDLABELLEDBY As String = ""
            Dim FOLDREMOVEDOCKET As String = ""
            Dim FOLDALLTHETRAY As String = ""
            Dim FOLDBARCODECAMERA As String = ""
            Dim FOLDREMARKS As String = ""
            Dim FOLDINTIME As String = ""
            Dim FOLDOUTTIME As String = ""
            Dim TOTALPACKETS As String = ""
            Dim TOTALSHIPPERS As String = ""
            Dim PACKETSIZE As String = ""
            Dim SHORTQTY As String = ""
            Dim SUPERVISOR As String = ""

            For Each ROW As Windows.Forms.DataGridViewRow In gridjob.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If PROCESS = "" Then
                        PROCESS = ROW.Cells(Gprocess.Index).Value.ToString
                        SRNO = ROW.Cells(Gsrno.Index).Value.ToString
                        COLOR = ROW.Cells(Gpcolor.Index).Value.ToString
                        NOOFPLATE = ROW.Cells(GNOOFPLATE.Index).Value.ToString
                        PLATETYPE = ROW.Cells(GPLATETYPE.Index).Value.ToString
                        PLATESIZE = ROW.Cells(GPLATESIZE.Index).Value.ToString
                        PLATEQC = ROW.Cells(GPLATEQC.Index).Value
                        PLATEREMARKS = ROW.Cells(GPLATEREMARKS.Index).Value.ToString
                        PLATEINTIME = ROW.Cells(GPLATEINTIME.Index).Value.ToString
                        PLATEOUTTIME = ROW.Cells(GPLATEOUTTIME.Index).Value.ToString
                        PLATECHKBY = ROW.Cells(Gplatecheckedby.Index).Value.ToString
                        CODECHKBY = ROW.Cells(Gcodecheckedby.Index).Value.ToString
                        UPSCHKBY = ROW.Cells(Gupscheckedby.Index).Value.ToString
                        CORECTAPLBY = ROW.Cells(GCorrectionappby.Index).Value.ToString
                        PLATEMADEBY = ROW.Cells(GPlatemadeby.Index).Value.ToString
                        MADEDATE = ROW.Cells(Gplatemadedate.Index).Value.ToString
                        PLATEDESTROYBY = ROW.Cells(Gplatedestroyedby.Index).Value.ToString
                        DESTROYDATE = ROW.Cells(Gplatedestroyeddate.Index).Value.ToString
                        PLATEREMADEBY = ROW.Cells(Gplateremadeby.Index).Value.ToString
                        REAMDEDATE = ROW.Cells(Gplateremadedate.Index).Value.ToString

                        PLTCHKBY = ROW.Cells(GPLTCHKBY.Index).Value.ToString

                        NAME = ROW.Cells(Gprintingname.Index).Value.ToString
                        SHEETSGIVEN = ROW.Cells(Gsheetsgiven.Index).Value.ToString
                        GIVENDATE = ROW.Cells(Ggivendate1.Index).Value.ToString
                        BALSHEETS = ROW.Cells(Gbalancesheets.Index).Value.ToString
                        RETURNDATE = ROW.Cells(Greturneddate.Index).Value.ToString
                        SHEETSDESTROY = ROW.Cells(Gsheetsdestroyed.Index).Value.ToString
                        MACHINENO = ROW.Cells(GMACHINENO.Index).Value.ToString
                        TABLECLR = ROW.Cells(GTABLECLEAR.Index).Value.ToString
                        MACHINEPTFCLR = ROW.Cells(GMACHINEPTFCLR.Index).Value.ToString
                        DUSTBINCLR = ROW.Cells(GDUSTBINCLEAR.Index).Value.ToString
                        MACHINESURRAREACLR = ROW.Cells(GMACHINESURRAREACLR.Index).Value.ToString
                        AREABELOWMACHINE = ROW.Cells(GAREABELOWMACHINECLR.Index).Value.ToString
                        REJECTSHEETS = ROW.Cells(GREGSHEETSREMOVED.Index).Value.ToString


                        UNFOLDREMOVEJOBDOCKET = ROW.Cells(GUNFOLDREMOVEJOBDOCKET.Index).Value.ToString
                        UNFOLDALLTRAY = ROW.Cells(GUNFOLDALLTRAY.Index).Value.ToString
                        UNFOLDSORTINGBY = ROW.Cells(GUNFOLDSORTINGBY.Index).Value.ToString
                        UNFOLDCOUNTING = ROW.Cells(GUNFOLDCOUNTING.Index).Value.ToString
                        UNFOLDPACKETBY = ROW.Cells(GUNFOLDPACKETBY.Index).Value.ToString
                        UNFOLDLABELLEDBY = ROW.Cells(GUNFOLDLABELLEDBY.Index).Value.ToString
                        UNFOLDSAMPLEAPPBY = ROW.Cells(GUNFOLDSAMPLEAPPBY.Index).Value.ToString
                        UNFOLDSHEETGIVEN = ROW.Cells(GUNFOLDSHEETGIVEN.Index).Value.ToString
                        UNFOLDBALANCESHEET = ROW.Cells(GUNFOLDBALANCESHEET.Index).Value.ToString
                        UNFOLDDESTROYEDSHEET = ROW.Cells(GUNFOLDDESTROYEDSHEET.Index).Value.ToString
                        UNFOLDGIVENDATE = ROW.Cells(GUNFOLDGIVENDATE.Index).Value.ToString
                        UNFOLDREMARKS = ROW.Cells(GUNFOLDREMARKS.Index).Value.ToString
                        UNFOLDINTIME = ROW.Cells(GUNFOLDINTIME.Index).Value.ToString
                        UNFOLDOUTTIME = ROW.Cells(GUNFOLDOUTTIME.Index).Value.ToString

                        PAPERGRNNO = ROW.Cells(GPAPERGRNNO.Index).Value.ToString
                        PAPERTYPE = ROW.Cells(GPAPERTYPE.Index).Value.ToString
                        PAPERREMARKS = ROW.Cells(GPAPERREMARKS.Index).Value.ToString
                        PAPERINTIME = ROW.Cells(GPAPERINTIME.Index).Value.ToString
                        PAPEROUTTIME = ROW.Cells(GPAPEROUTTIME.Index).Value.ToString
                        PAPERGSMQC = ROW.Cells(GPAPERGSMQC.Index).Value.ToString
                        PAPERQUALITYQC = ROW.Cells(GPAPERQUALITYQC.Index).Value.ToString
                        CUTPREJOBSHEET = ROW.Cells(GCUTJOBSHEET.Index).Value.ToString
                        CUTLEAFLETSIZE = ROW.Cells(GCUTLEAFLETSIZE.Index).Value.ToString

                        SORTFLOORAREA = ROW.Cells(GSORTFLOORAREA.Index).Value.ToString
                        SORTPREJOBSHEET = ROW.Cells(GSORTPREJOBSHEETS.Index).Value.ToString
                        SORTREMARKS = ROW.Cells(GSORTREMARKS.Index).Value.ToString
                        SORTINTIME = ROW.Cells(GSORTINTIME.Index).Value.ToString
                        SORTOUTTIME = ROW.Cells(GSORTOUTTIME.Index).Value.ToString

                        PLATEREMOVED = ROW.Cells(GPLATEAREREMOVED.Index).Value.ToString
                        INKPOT = ROW.Cells(GINKPOTAREEMPTIEDOUT.Index).Value.ToString
                        PRINTSHEETSREMOVED = ROW.Cells(GPRINTEDSHEETSREMOVED.Index).Value.ToString
                        POSITIVEREMOVED = ROW.Cells(GPOSITIVEREMOVED.Index).Value.ToString
                        NEGATIVEREMOVED = ROW.Cells(GNEGATIVEREMOVED.Index).Value.ToString
                        APPSHADECARD = ROW.Cells(GAPPSHADECARDREMOVED.Index).Value.ToString
                        APPSAMPLE = ROW.Cells(GAPPSAMPLEREMOVED.Index).Value.ToString
                        REGISTERSHEETSREMOVED = ROW.Cells(GREGSHEETSREMOVED.Index).Value.ToString
                        FEEDERAREA = ROW.Cells(GFEDERAREACLR.Index).Value.ToString
                        DELIVERAREA = ROW.Cells(GDELIVERAREACLR.Index).Value.ToString

                        PRINTPLATETYPE = ROW.Cells(GPRINTTYPE.Index).Value.ToString
                        PRINTREMARKS = ROW.Cells(GPRINTREMARKS.Index).Value.ToString
                        PRINTINTIME = ROW.Cells(GPRINTINTIME.Index).Value.ToString
                        PRINTOUTTIME = ROW.Cells(GPRINTOUTTIME.Index).Value.ToString
                        PRINTVARNISH = ROW.Cells(GPRINTVARNISH.Index).Value.ToString
                        PRINTPERFORATION = ROW.Cells(GPRINTPERFORATION.Index).Value.ToString
                        PRINTTEXTMATTER = ROW.Cells(GPRINTTEXTMATTER.Index).Value.ToString
                        PRINTSIZE = ROW.Cells(GPRINTSIZE.Index).Value.ToString
                        PRINTJOBREG = ROW.Cells(GPRINTJOBREG.Index).Value.ToString
                        PRINTCOLOR = ROW.Cells(GPRINTCOLOR.Index).Value.ToString


                        CROSSUNITAREA = ROW.Cells(GCROSSUNITAREACLR.Index).Value.ToString
                        FSTKNIFEAREA = ROW.Cells(G1STKNIFEAREACLR.Index).Value.ToString
                        SECONDKNIFEAREA = ROW.Cells(G2NDKNIFEAREACLR.Index).Value.ToString
                        TAPPINGUNIT = ROW.Cells(GTAPPINGUNITAREACLR.Index).Value.ToString
                        STACKERAREA = ROW.Cells(GSTACKERAREACLR.Index).Value.ToString

                        SAMPLEAPPBY = ROW.Cells(Gsample.Index).Value.ToString
                        FOLDBUNDLEDBY = ROW.Cells(GFOLDBUNDLEDBY.Index).Value.ToString
                        FOLDPACKETBY = ROW.Cells(GFOLDPACKEDBY.Index).Value.ToString
                        FOLDLABELLEDBY = ROW.Cells(GFOLDLABELLEDBY.Index).Value.ToString
                        FOLDREMOVEDOCKET = ROW.Cells(GFOLDREMOVEDOCKET.Index).Value.ToString
                        FOLDALLTHETRAY = ROW.Cells(GFOLDALLTRAYS.Index).Value.ToString
                        FOLDBARCODECAMERA = ROW.Cells(GFOLDBARCODECAMERA.Index).Value.ToString
                        FOLDREMARKS = ROW.Cells(GFOLDREMARKS.Index).Value.ToString
                        FOLDINTIME = ROW.Cells(GFOLDINTIME.Index).Value.ToString
                        FOLDOUTTIME = ROW.Cells(GFOLDOUTTIME.Index).Value.ToString

                        TOTALPACKETS = ROW.Cells(Gtotalpackets.Index).Value.ToString
                        TOTALSHIPPERS = ROW.Cells(Gtotalshippers.Index).Value.ToString
                        PACKETSIZE = ROW.Cells(Gpacketsize.Index).Value.ToString
                        SHORTQTY = Val(ROW.Cells(Gshortqty.Index).Value).ToString
                        SUPERVISOR = ROW.Cells(GSupervisor.Index).Value.ToString
                    Else
                        PROCESS = PROCESS & "|" & ROW.Cells(Gprocess.Index).Value.ToString
                        SRNO = SRNO & "|" & ROW.Cells(Gsrno.Index).Value.ToString
                        COLOR = COLOR & "|" & ROW.Cells(Gpcolor.Index).Value.ToString

                        NOOFPLATE = NOOFPLATE & "|" & ROW.Cells(GNOOFPLATE.Index).Value.ToString
                        PLATETYPE = PLATETYPE & "|" & ROW.Cells(GPLATETYPE.Index).Value.ToString
                        PLATESIZE = PLATESIZE & "|" & ROW.Cells(GPLATESIZE.Index).Value.ToString
                        PLATEQC = PLATEQC & "|" & ROW.Cells(GPLATEQC.Index).Value.ToString
                        PLATEREMARKS = PLATEREMARKS & "|" & ROW.Cells(GPLATEREMARKS.Index).Value.ToString
                        PLATEINTIME = PLATEINTIME & "|" & ROW.Cells(GPLATEINTIME.Index).Value.ToString
                        PLATEOUTTIME = PLATEOUTTIME & "|" & ROW.Cells(GPLATEOUTTIME.Index).Value.ToString

                        PLATECHKBY = PLATECHKBY & "|" & ROW.Cells(Gplatecheckedby.Index).Value.ToString
                        CODECHKBY = CODECHKBY & "|" & ROW.Cells(Gcodecheckedby.Index).Value.ToString
                        UPSCHKBY = UPSCHKBY & "|" & ROW.Cells(Gupscheckedby.Index).Value.ToString
                        CORECTAPLBY = CORECTAPLBY & "|" & ROW.Cells(GCorrectionappby.Index).Value.ToString
                        PLATEMADEBY = PLATEMADEBY & "|" & ROW.Cells(GPlatemadeby.Index).Value.ToString
                        MADEDATE = MADEDATE & "|" & ROW.Cells(Gplatemadedate.Index).Value.ToString
                        PLATEDESTROYBY = PLATEDESTROYBY & "|" & ROW.Cells(Gplatedestroyedby.Index).Value.ToString
                        DESTROYDATE = DESTROYDATE & "|" & ROW.Cells(Gplatedestroyeddate.Index).Value.ToString
                        PLATEREMADEBY = PLATEREMADEBY & "|" & ROW.Cells(Gplateremadeby.Index).Value.ToString
                        REAMDEDATE = REAMDEDATE & "|" & ROW.Cells(Gplateremadedate.Index).Value.ToString

                        PLTCHKBY = PLTCHKBY & "|" & ROW.Cells(GPLTCHKBY.Index).Value.ToString
                        NAME = NAME & "|" & ROW.Cells(Gprintingname.Index).Value.ToString
                        SHEETSGIVEN = SHEETSGIVEN & "|" & ROW.Cells(Gsheetsgiven.Index).Value.ToString
                        GIVENDATE = GIVENDATE & "|" & ROW.Cells(Ggivendate1.Index).Value.ToString
                        BALSHEETS = BALSHEETS & "|" & ROW.Cells(Gbalancesheets.Index).Value.ToString
                        RETURNDATE = RETURNDATE & "|" & ROW.Cells(Greturneddate.Index).Value.ToString
                        SHEETSDESTROY = SHEETSDESTROY & "|" & ROW.Cells(Gsheetsdestroyed.Index).Value.ToString
                        MACHINENO = MACHINENO & "|" & ROW.Cells(GMACHINENO.Index).Value.ToString
                        TABLECLR = TABLECLR & "|" & ROW.Cells(GTABLECLEAR.Index).Value.ToString
                        MACHINEPTFCLR = MACHINEPTFCLR & "|" & ROW.Cells(GMACHINEPTFCLR.Index).Value.ToString
                        DUSTBINCLR = DUSTBINCLR & "|" & ROW.Cells(GDUSTBINCLEAR.Index).Value.ToString
                        MACHINESURRAREACLR = MACHINESURRAREACLR & "|" & ROW.Cells(GMACHINESURRAREACLR.Index).Value.ToString
                        AREABELOWMACHINE = AREABELOWMACHINE & "|" & ROW.Cells(GAREABELOWMACHINECLR.Index).Value.ToString
                        REJECTSHEETS = REJECTSHEETS & "|" & ROW.Cells(GREGSHEETSREMOVED.Index).Value.ToString



                        UNFOLDREMOVEJOBDOCKET = UNFOLDREMOVEJOBDOCKET & "|" & ROW.Cells(GUNFOLDREMOVEJOBDOCKET.Index).Value.ToString
                        UNFOLDALLTRAY = UNFOLDALLTRAY & "|" & ROW.Cells(GUNFOLDALLTRAY.Index).Value.ToString
                        UNFOLDSORTINGBY = UNFOLDSORTINGBY & "|" & ROW.Cells(GUNFOLDSORTINGBY.Index).Value.ToString
                        UNFOLDCOUNTING = UNFOLDCOUNTING & "|" & ROW.Cells(GUNFOLDCOUNTING.Index).Value.ToString
                        UNFOLDPACKETBY = UNFOLDPACKETBY & "|" & ROW.Cells(GUNFOLDPACKETBY.Index).Value.ToString
                        UNFOLDLABELLEDBY = UNFOLDLABELLEDBY & "|" & ROW.Cells(GUNFOLDLABELLEDBY.Index).Value.ToString
                        UNFOLDSAMPLEAPPBY = UNFOLDSAMPLEAPPBY & "|" & ROW.Cells(GUNFOLDSAMPLEAPPBY.Index).Value.ToString
                        UNFOLDSHEETGIVEN = UNFOLDSHEETGIVEN & "|" & ROW.Cells(GUNFOLDSHEETGIVEN.Index).Value.ToString
                        UNFOLDBALANCESHEET = UNFOLDBALANCESHEET & "|" & ROW.Cells(GUNFOLDBALANCESHEET.Index).Value.ToString
                        UNFOLDDESTROYEDSHEET = UNFOLDDESTROYEDSHEET & "|" & ROW.Cells(GUNFOLDDESTROYEDSHEET.Index).Value.ToString
                        UNFOLDGIVENDATE = UNFOLDGIVENDATE & "|" & ROW.Cells(GUNFOLDGIVENDATE.Index).Value.ToString
                        UNFOLDREMARKS = UNFOLDREMARKS & "|" & ROW.Cells(GUNFOLDREMARKS.Index).Value.ToString
                        UNFOLDINTIME = UNFOLDINTIME & "|" & ROW.Cells(GUNFOLDINTIME.Index).Value.ToString
                        UNFOLDOUTTIME = UNFOLDOUTTIME & "|" & ROW.Cells(GUNFOLDOUTTIME.Index).Value.ToString


                        PAPERGRNNO = PAPERGRNNO & "|" & ROW.Cells(GPAPERGRNNO.Index).Value.ToString
                        PAPERTYPE = PAPERTYPE & "|" & ROW.Cells(GPAPERTYPE.Index).Value.ToString
                        PAPERREMARKS = PAPERREMARKS & "|" & ROW.Cells(GPAPERREMARKS.Index).Value.ToString
                        PAPERINTIME = PAPERINTIME & "|" & ROW.Cells(GPAPERINTIME.Index).Value.ToString
                        PAPEROUTTIME = PAPEROUTTIME & "|" & ROW.Cells(GPAPEROUTTIME.Index).Value.ToString
                        PAPERGSMQC = PAPERGSMQC & "|" & ROW.Cells(GPAPERGSMQC.Index).Value.ToString
                        PAPERQUALITYQC = PAPERQUALITYQC & "|" & ROW.Cells(GPAPERQUALITYQC.Index).Value.ToString


                        CUTPREJOBSHEET = CUTPREJOBSHEET & "|" & ROW.Cells(GCUTJOBSHEET.Index).Value.ToString
                        CUTLEAFLETSIZE = CUTLEAFLETSIZE & "|" & ROW.Cells(GCUTLEAFLETSIZE.Index).Value.ToString

                        SORTFLOORAREA = SORTFLOORAREA & "|" & ROW.Cells(GSORTFLOORAREA.Index).Value.ToString
                        SORTPREJOBSHEET = SORTPREJOBSHEET & "|" & ROW.Cells(GSORTPREJOBSHEETS.Index).Value.ToString
                        SORTREMARKS = SORTREMARKS & "|" & ROW.Cells(GSORTREMARKS.Index).Value.ToString
                        SORTINTIME = SORTINTIME & "|" & ROW.Cells(GSORTINTIME.Index).Value.ToString
                        SORTOUTTIME = SORTOUTTIME & "|" & ROW.Cells(GSORTOUTTIME.Index).Value.ToString
                        PLATEREMOVED = PLATEREMOVED & "|" & ROW.Cells(GPLATEAREREMOVED.Index).Value.ToString
                        INKPOT = INKPOT & "|" & ROW.Cells(GINKPOTAREEMPTIEDOUT.Index).Value.ToString
                        PRINTSHEETSREMOVED = PRINTSHEETSREMOVED & "|" & ROW.Cells(GPRINTEDSHEETSREMOVED.Index).Value.ToString
                        POSITIVEREMOVED = POSITIVEREMOVED & "|" & ROW.Cells(GPOSITIVEREMOVED.Index).Value.ToString
                        NEGATIVEREMOVED = NEGATIVEREMOVED & "|" & ROW.Cells(GNEGATIVEREMOVED.Index).Value.ToString
                        APPSHADECARD = APPSHADECARD & "|" & ROW.Cells(GAPPSHADECARDREMOVED.Index).Value.ToString
                        APPSAMPLE = APPSAMPLE & "|" & ROW.Cells(GAPPSAMPLEREMOVED.Index).Value.ToString
                        REGISTERSHEETSREMOVED = REGISTERSHEETSREMOVED & "|" & ROW.Cells(GREGSHEETSREMOVED.Index).Value.ToString
                        FEEDERAREA = FEEDERAREA & "|" & ROW.Cells(GFEDERAREACLR.Index).Value.ToString
                        DELIVERAREA = DELIVERAREA & "|" & ROW.Cells(GDELIVERAREACLR.Index).Value.ToString

                        PRINTPLATETYPE = PRINTPLATETYPE & "|" & ROW.Cells(GPRINTTYPE.Index).Value.ToString
                        PRINTREMARKS = PRINTREMARKS & "|" & ROW.Cells(GPRINTREMARKS.Index).Value.ToString
                        PRINTINTIME = PRINTINTIME & "|" & ROW.Cells(GPRINTINTIME.Index).Value.ToString
                        PRINTOUTTIME = PRINTOUTTIME & "|" & ROW.Cells(GPRINTOUTTIME.Index).Value.ToString
                        PRINTVARNISH = PRINTVARNISH & "|" & ROW.Cells(GPRINTVARNISH.Index).Value.ToString
                        PRINTPERFORATION = PRINTPERFORATION & "|" & ROW.Cells(GPRINTPERFORATION.Index).Value.ToString
                        PRINTTEXTMATTER = PRINTTEXTMATTER & "|" & ROW.Cells(GPRINTTEXTMATTER.Index).Value.ToString
                        PRINTSIZE = PRINTSIZE & "|" & ROW.Cells(GPRINTSIZE.Index).Value.ToString
                        PRINTJOBREG = PRINTJOBREG & "|" & ROW.Cells(GPRINTJOBREG.Index).Value.ToString
                        PRINTCOLOR = PRINTCOLOR & "|" & ROW.Cells(GPRINTCOLOR.Index).Value.ToString

                        CROSSUNITAREA = CROSSUNITAREA & "|" & ROW.Cells(GCROSSUNITAREACLR.Index).Value.ToString
                        FSTKNIFEAREA = FSTKNIFEAREA & "|" & ROW.Cells(G1STKNIFEAREACLR.Index).Value.ToString
                        SECONDKNIFEAREA = SECONDKNIFEAREA & "|" & ROW.Cells(G2NDKNIFEAREACLR.Index).Value.ToString
                        TAPPINGUNIT = TAPPINGUNIT & "|" & ROW.Cells(GTAPPINGUNITAREACLR.Index).Value.ToString
                        STACKERAREA = STACKERAREA & "|" & ROW.Cells(GSTACKERAREACLR.Index).Value.ToString

                        SAMPLEAPPBY = SAMPLEAPPBY & "|" & ROW.Cells(Gsample.Index).Value.ToString
                        FOLDBUNDLEDBY = FOLDBUNDLEDBY & "|" & ROW.Cells(GFOLDBUNDLEDBY.Index).Value.ToString
                        FOLDPACKETBY = FOLDPACKETBY & "|" & ROW.Cells(GFOLDPACKEDBY.Index).Value.ToString
                        FOLDLABELLEDBY = FOLDLABELLEDBY & "|" & ROW.Cells(GFOLDLABELLEDBY.Index).Value.ToString
                        FOLDREMOVEDOCKET = FOLDREMOVEDOCKET & "|" & ROW.Cells(GFOLDREMOVEDOCKET.Index).Value.ToString
                        FOLDALLTHETRAY = FOLDALLTHETRAY & "|" & ROW.Cells(GFOLDALLTRAYS.Index).Value.ToString
                        FOLDBARCODECAMERA = FOLDBARCODECAMERA & "|" & ROW.Cells(GFOLDBARCODECAMERA.Index).Value.ToString
                        FOLDREMARKS = FOLDREMARKS & "|" & ROW.Cells(GFOLDREMARKS.Index).Value.ToString
                        FOLDINTIME = FOLDINTIME & "|" & ROW.Cells(GFOLDINTIME.Index).Value.ToString
                        FOLDOUTTIME = FOLDOUTTIME & "|" & ROW.Cells(GFOLDOUTTIME.Index).Value.ToString
                        TOTALPACKETS = TOTALPACKETS & "|" & ROW.Cells(Gtotalpackets.Index).Value.ToString
                        TOTALSHIPPERS = TOTALSHIPPERS & "|" & ROW.Cells(Gtotalshippers.Index).Value.ToString
                        PACKETSIZE = PACKETSIZE & "|" & ROW.Cells(Gpacketsize.Index).Value.ToString
                        SHORTQTY = SHORTQTY & "|" & Val(ROW.Cells(Gshortqty.Index).Value).ToString
                        SUPERVISOR = SUPERVISOR & "|" & ROW.Cells(GSupervisor.Index).Value.ToString
                    End If
                End If
            Next
            ALPARAVAL.Add(PROCESS)
            ALPARAVAL.Add(SRNO)
            ALPARAVAL.Add(COLOR)
            ALPARAVAL.Add(NOOFPLATE)
            ALPARAVAL.Add(PLATETYPE)
            ALPARAVAL.Add(PLATESIZE)
            ALPARAVAL.Add(PLATEQC)
            ALPARAVAL.Add(PLATEREMARKS)
            ALPARAVAL.Add(PLATEINTIME)
            ALPARAVAL.Add(PLATEOUTTIME)
            ALPARAVAL.Add(PLATECHKBY)
            ALPARAVAL.Add(CODECHKBY)
            ALPARAVAL.Add(UPSCHKBY)
            ALPARAVAL.Add(CORECTAPLBY)
            ALPARAVAL.Add(PLATEMADEBY)
            ALPARAVAL.Add(MADEDATE)
            ALPARAVAL.Add(PLATEDESTROYBY)
            ALPARAVAL.Add(DESTROYDATE)
            ALPARAVAL.Add(PLATEREMADEBY)
            ALPARAVAL.Add(REAMDEDATE)

            ALPARAVAL.Add(PLTCHKBY)

            ALPARAVAL.Add(NAME)
            ALPARAVAL.Add(SHEETSGIVEN)
            ALPARAVAL.Add(GIVENDATE)
            ALPARAVAL.Add(BALSHEETS)
            ALPARAVAL.Add(RETURNDATE)
            ALPARAVAL.Add(SHEETSDESTROY)
            ALPARAVAL.Add(MACHINENO)
            ALPARAVAL.Add(TABLECLR)
            ALPARAVAL.Add(MACHINEPTFCLR)
            ALPARAVAL.Add(DUSTBINCLR)
            ALPARAVAL.Add(MACHINESURRAREACLR)
            ALPARAVAL.Add(AREABELOWMACHINE)
            ALPARAVAL.Add(REJECTSHEETS)


            ALPARAVAL.Add(UNFOLDREMOVEJOBDOCKET)
            ALPARAVAL.Add(UNFOLDALLTRAY)
            ALPARAVAL.Add(UNFOLDSORTINGBY)
            ALPARAVAL.Add(UNFOLDCOUNTING)
            ALPARAVAL.Add(UNFOLDPACKETBY)
            ALPARAVAL.Add(UNFOLDLABELLEDBY)
            ALPARAVAL.Add(UNFOLDSAMPLEAPPBY)
            ALPARAVAL.Add(UNFOLDSHEETGIVEN)
            ALPARAVAL.Add(UNFOLDBALANCESHEET)
            ALPARAVAL.Add(UNFOLDDESTROYEDSHEET)
            ALPARAVAL.Add(UNFOLDGIVENDATE)
            ALPARAVAL.Add(UNFOLDREMARKS)
            ALPARAVAL.Add(UNFOLDINTIME)
            ALPARAVAL.Add(UNFOLDOUTTIME)

            ALPARAVAL.Add(PAPERGRNNO)
            ALPARAVAL.Add(PAPERTYPE)
            ALPARAVAL.Add(PAPERREMARKS)
            ALPARAVAL.Add(PAPERINTIME)
            ALPARAVAL.Add(PAPEROUTTIME)
            ALPARAVAL.Add(PAPERGSMQC)
            ALPARAVAL.Add(PAPERQUALITYQC)

            ALPARAVAL.Add(CUTPREJOBSHEET)
            ALPARAVAL.Add(CUTLEAFLETSIZE)


            ALPARAVAL.Add(SORTFLOORAREA)
            ALPARAVAL.Add(SORTPREJOBSHEET)
            ALPARAVAL.Add(SORTREMARKS)
            ALPARAVAL.Add(SORTINTIME)
            ALPARAVAL.Add(SORTOUTTIME)

            ALPARAVAL.Add(PLATEREMOVED)
            ALPARAVAL.Add(INKPOT)
            ALPARAVAL.Add(PRINTSHEETSREMOVED)
            ALPARAVAL.Add(POSITIVEREMOVED)
            ALPARAVAL.Add(NEGATIVEREMOVED)
            ALPARAVAL.Add(APPSHADECARD)
            ALPARAVAL.Add(APPSAMPLE)
            ALPARAVAL.Add(REGISTERSHEETSREMOVED)
            ALPARAVAL.Add(FEEDERAREA)
            ALPARAVAL.Add(DELIVERAREA)

            ALPARAVAL.Add(PRINTPLATETYPE)
            ALPARAVAL.Add(PRINTREMARKS)
            ALPARAVAL.Add(PRINTINTIME)
            ALPARAVAL.Add(PRINTOUTTIME)
            ALPARAVAL.Add(PRINTVARNISH)
            ALPARAVAL.Add(PRINTPERFORATION)
            ALPARAVAL.Add(PRINTTEXTMATTER)
            ALPARAVAL.Add(PRINTSIZE)
            ALPARAVAL.Add(PRINTJOBREG)
            ALPARAVAL.Add(PRINTCOLOR)

            ALPARAVAL.Add(CROSSUNITAREA)
            ALPARAVAL.Add(FSTKNIFEAREA)
            ALPARAVAL.Add(SECONDKNIFEAREA)
            ALPARAVAL.Add(TAPPINGUNIT)
            ALPARAVAL.Add(STACKERAREA)
            ALPARAVAL.Add(SAMPLEAPPBY)

            ALPARAVAL.Add(FOLDBUNDLEDBY)
            ALPARAVAL.Add(FOLDPACKETBY)
            ALPARAVAL.Add(FOLDLABELLEDBY)
            ALPARAVAL.Add(FOLDREMOVEDOCKET)
            ALPARAVAL.Add(FOLDALLTHETRAY)
            ALPARAVAL.Add(FOLDBARCODECAMERA)
            ALPARAVAL.Add(FOLDREMARKS)
            ALPARAVAL.Add(FOLDINTIME)
            ALPARAVAL.Add(FOLDOUTTIME)

            ALPARAVAL.Add(TOTALPACKETS)
            ALPARAVAL.Add(TOTALSHIPPERS)
            ALPARAVAL.Add(PACKETSIZE)
            ALPARAVAL.Add(SHORTQTY)
            ALPARAVAL.Add(SUPERVISOR)

            Dim objbatch As New ClsBatch
            objbatch.alParaval = ALPARAVAL

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dttable As DataTable = objbatch.SAVE()
                TEMPBATCHNO = dttable.Rows(0).Item(0)
                MessageBox.Show("Deatils Added !!")

                PRINTBARCODE()


                PRINTREPORT(dttable.Rows(0).Item(0))
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                ALPARAVAL.Add(TEMPBATCHNO)
                IntResult = objbatch.UPDATE()
                MessageBox.Show("Details Updated!!")
                PRINTREPORT(TEMPBATCHNO)
                edit = False
            End If

            If gridupload.RowCount > 0 Then SAVEUPLOAD()

            CLEAR()



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTBARCODE()
        Try

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SAVEUPLOAD()
        Try
            Dim OBJJOB As New ClsBatch

            For Each ROW As Windows.Forms.DataGridViewRow In gridupload.Rows
                If ROW.Cells(GUSRNO.Index).Value <> Nothing Then
                    Dim MS As New IO.MemoryStream
                    Dim ALPARAVAL As New ArrayList
                    ALPARAVAL.Add(TEMPBATCHNO)
                    ALPARAVAL.Add(ROW.Cells(GUSRNO.Index).Value)
                    ALPARAVAL.Add(ROW.Cells(GUREMARKS.Index).Value)
                    ALPARAVAL.Add(ROW.Cells(GUNAME.Index).Value)

                    PBSOFTCOPY.Image = ROW.Cells(GUIMGPATH.Index).Value
                    PBSOFTCOPY.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    ALPARAVAL.Add(MS.ToArray)
                    ALPARAVAL.Add(YearId)

                    OBJJOB.alParaval = ALPARAVAL
                    Dim INTRESULT As Integer = OBJJOB.SAVEUPLOAD()
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

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function ERRORVALID() As Boolean
        Dim bln As Boolean = True

        If TXTJOBDOCKETNO.Text.Trim.Length = 0 Then
            EP.SetError(TXTJOBDOCKETNO, "Select Job Docket No.")
            bln = False
        End If

        'ALLOW TO SAVE BLANK BATCH...
        'AS THEY HAVE TO TAKE PRINT OF DOCKET
        'If gridjob.RowCount = 0 Then
        '    Ep.SetError(gridjob, "Please fill atleast one Process")
        '    bln = False
        'End If



        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, "Rec/Return Made , Delete Rec/Return First")
            bln = False
        End If

        If Not datecheck(DTBATCHDATE.Value) Then
            EP.SetError(DTBATCHDATE, "Date Not In Current Accounting Year")
            bln = False
        End If

        If Not datecheck(DTJOBDOCKETDATE.Value) Then
            EP.SetError(DTJOBDOCKETDATE, "Date Not In Current Accounting Year")
            bln = False
        End If

        If DTBATCHDATE.Value < DTJOBDOCKETDATE.Value Then
            EP.SetError(DTBATCHDATE, "Batch Date cannot be before Job Docket Date")
            bln = False
        End If

        'If Val(TXTJOBDOCKETNO.Text.Trim) > 0 And edit = False Then
        '    Dim OBJCMN As New ClsCommon
        '    Dim dttable As DataTable = OBJCMN.search(" JOBBATCH_NO As JOBNO ", "", " BATCHMASTER ", "   And JOBBATCH_DOCKETNO=" & Val(TXTJOBDOCKETNO.Text.Trim) & " And JOBBATCH_YEARID = " & YearId)
        '    If dttable.Rows.Count > 0 Then
        '        EP.SetError(TXTJOBDOCKETNO, "Job Docket No Already Exist")
        '        bln = False
        '    End If
        'End If

        Dim OBJCMN As New ClsCommon
        Dim dttable As New DataTable

        If Val(TXTBATCHNO.Text.Trim) > 0 And edit = False Then
            dttable = OBJCMN.search(" ISNULL(BATCHMASTER. jobbatch_no, 0) As BATCHNO", "", " BATCHMASTER ", "  And BATCHMASTER.jobbatch_NO=" & TXTBATCHNO.Text.Trim & " And BATCHMASTER.jobbatch_YEARID = " & YearId)
            If dttable.Rows.Count > 0 Then
                MsgBox("Batch No Already Exist")
                bln = False
            End If
        End If
        If LBLASSEBLYDONE.Visible = True Then
            EP.SetError(LBLASSEBLYDONE, " Assembly Done..!!")
            bln = False
        End If

        'If lblprocess.Text <> "PLATE" Then
        '    If TXTCUTMACHINENO.Text.Trim = "" Then
        '        EP.SetError(TXTCUTMACHINENO, "Please Enter Machine No")
        '        bln = False
        '    End If

        '    If TXTPRINTMACHINENO.Text.Trim = "" Then
        '        EP.SetError(TXTPRINTMACHINENO, "Please Enter Machine No")
        '        bln = False
        '    End If

        '    If TXTFOLDMACHINENO.Text.Trim = "" Then
        '        EP.SetError(TXTFOLDMACHINENO, "Please Enter Machine No")
        '        bln = False
        '    End If

        'End If



        Return bln
    End Function

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                TXTITEMNAME.Clear()
                TEMPBATCHNO = Val(tstxtbillno.Text)
                If TEMPBATCHNO > 0 Then
                    edit = True
                    Batch_Load(sender, e)
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
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            TXTITEMNAME.Clear()
LINE1:
            TEMPBATCHNO = Val(TXTBATCHNO.Text) - 1
            If TEMPBATCHNO > 0 Then
                edit = True
                Batch_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If
            If TXTITEMNAME.Text = "" And TEMPBATCHNO > 1 Then
                TXTBATCHNO.Text = TEMPBATCHNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            TXTITEMNAME.Clear()
LINE1:
            TEMPBATCHNO = Val(TXTBATCHNO.Text) + 1
            getmax_batch_no()
            Dim MAX As Integer = TXTBATCHNO.Text.Trim
            CLEAR()
            If Val(TXTBATCHNO.Text) - 1 >= TEMPBATCHNO Then
                edit = True
                Batch_Load(sender, e)
            Else
                edit = False
                CLEAR()
            End If
            If TXTITEMNAME.Text = "" And TEMPBATCHNO < MAX Then
                TXTBATCHNO.Text = TEMPBATCHNO
                GoTo LINE1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub CMDSELECTJOBDOCKET_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTJOBDOCKET.Click
        Try
            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub

            End If
            Cursor.Current = Cursors.WaitCursor
            Dim OBJSELECTJOBDOCKET As New SelectJobDocket
            OBJSELECTJOBDOCKET.ShowDialog()
            Dim ORDERDT As DataTable = OBJSELECTJOBDOCKET.DT
            If ORDERDT.Rows.Count > 0 Then

                Dim objcmn As New ClsCommon

                For Each ROW As DataRow In ORDERDT.Rows
                    Dim dt As DataTable = objcmn.search(" JOBBATCHMASTER.job_no As JOBDOCKETNO, JOBBATCHMASTER.job_date As JOBDOCKETDATE, LEDGERS.Acc_cmpname As NAME, ISNULL(JOBBATCHMASTER.job_pono, '') AS PONO, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(JOBBATCHMASTER.job_qty - JOBBATCHMASTER.JOB_OUTQTY, 0) AS QTY, ISNULL(ITEMMASTER.item_fileno, '') AS FILENO, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(JOBBATCHMASTER.JOB_TOTALSHEETS, '') AS TOTALSHEETS, ISNULL(JOBBATCHMASTER.JOB_PERCENTAGE, 0) AS PERCENTAGE, ISNULL(ITEMMASTER.ITEM_2DCODE, 0) AS [2DCODE], ISNULL(SUBITEMITEMMASTER.item_code, '') AS SUBITEMCODE, ISNULL(JOBBATCHMASTER.JOB_UPS, 0) AS UPS ,ISNULL(JOBBATCHMASTER.job_orderno, 0) AS ORDERNO, ISNULL(JOBBATCHMASTER.job_ordersrno, 0) AS ORDERSRNO, ISNULL(JOBBATCHMASTER.JOB_ORDERTYPE, '') AS ORDERTYPE , ISNULL(COALESCE (SUBITEMITEMMASTER.ITEM_BOXSIZE, ITEMMASTER.ITEM_BOXSIZE), '') AS BOXSIZE   , ISNULL(COALESCE (SUBITEMITEMMASTER.ITEM_BUNDEL, ITEMMASTER.ITEM_BUNDEL), '') AS BUNDEL ,ISNULL(JOBBATCHMASTER.JOB_OPENSIZE, '') AS TRAYREQ, ISNULL(JOBBATCHMASTER.JOB_CLOSESIZE, '') AS BOXREQ  ", "", " ITEMMASTER AS SUBITEMITEMMASTER RIGHT OUTER JOIN JOBBATCHMASTER INNER JOIN LEDGERS ON JOBBATCHMASTER.JOB_LEDGERID = LEDGERS.Acc_id ON SUBITEMITEMMASTER.item_id = JOBBATCHMASTER.JOB_SUBITEMID LEFT OUTER JOIN COLORMASTER RIGHT OUTER JOIN ITEMMASTER ON COLORMASTER.COLOR_id = ITEMMASTER.item_colorid ON JOBBATCHMASTER.job_itemid = ITEMMASTER.item_id", "AND (JOBBATCHMASTER.job_qty - JOBBATCHMASTER.JOB_OUTQTY) > 0 AND JOBBATCHMASTER.JOB_NO = " & Val(ROW(0)) & " AND JOBBATCHMASTER.JOB_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then

                        TXTJOBDOCKETNO.Text = dt.Rows(0).Item("JOBDOCKETNO")
                        DTJOBDOCKETDATE.Value = dt.Rows(0).Item("JOBDOCKETDATE")
                        txtsrno.Text = dt.Rows(0).Item("FILENO")
                        txtcolor.Text = dt.Rows(0).Item("COLOR")
                        txttotalsheets.Text = Val(dt.Rows(0).Item("TOTALSHEETS"))
                        TXTITEMCODE.Text = dt.Rows(0).Item("ITEMCODE")
                        TXTITEMNAME.Text = dt.Rows(0).Item("ITEMNAME")
                        txtqty.Text = dt.Rows(0).Item("QTY")
                        txtups.Text = dt.Rows(0).Item("UPS")
                        TXTPERCENTAGE.Text = dt.Rows(0).Item("PERCENTAGE")
                        txtpartyname.Text = dt.Rows(0).Item("NAME")
                        txtpono.Text = dt.Rows(0).Item("PONO")
                        TXTBOMITEMCODE.Text = dt.Rows(0).Item("SUBITEMCODE")
                        txtname.Text = dt.Rows(0).Item("SUBITEMCODE")
                        TXTORDERNO.Text = dt.Rows(0).Item("ORDERNO")
                        TXTORDERSRNO.Text = dt.Rows(0).Item("ORDERSRNO")
                        TXTORDERTYPE.Text = dt.Rows(0).Item("ORDERTYPE")
                        TXTBUNDEL.Text = dt.Rows(0).Item("BUNDEL")
                        TXTBOXSIZE.Text = dt.Rows(0).Item("BOXSIZE")
                        TXTBOXREQ.Text = Val(dt.Rows(0).Item("BOXREQ"))
                        TXTTRAYREQ.Text = Val(dt.Rows(0).Item("TRAYREQ"))







                        CMDSELECTJOBDOCKET.Enabled = False
                            'txtpono.Enabled = False

                            'CHECK WHETHER THIS JOB IS OF 2DCODE OR NOT, IF YES THEN FETCH LAST 2DCODEEND FOR THE SAME ITEMNAME AND SHOW IT IN 2DCODESTART
                            'IRRESPECTIVE TO YEAR
                            'DONT PUT YEAR CLAUSE HERE
                            If Convert.ToBoolean(dt.Rows(0).Item("2DCODE")) = True Then
                                Dim DTOLD2DCODE As DataTable = objcmn.search(" TOP 1 ISNULL(JOBBATCH_2DCODEEND,'') AS [2DCODEEND]", "", " BATCHMASTER INNER JOIN ITEMMASTER ON JOBBATCH_ITEMID = ITEMMASTER.ITEM_ID ", " AND ITEMMASTER.ITEM_CODE = '" & TXTITEMCODE.Text.Trim & "' ORDER BY JOBBATCH_DATE DESC, JOBBATCH_NO DESC")
                                If DTOLD2DCODE.Rows.Count > 0 Then
                                    TXT2DCODESTART.Text = DTOLD2DCODE.Rows(0).Item("2DCODEEND")
                                End If
                            End If

                        End If
                        Next
                        GETSUPERVISORNAME()
                    End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub SELECTCASE()

        'FOR AMR WE HAVE CHANGED THE PROCESS
        If ClientName = "AMR" Then

            Select Case (tempprocessno)

                Case 1
                    lblprocess.Text = "PLATE"
                    tempprocessname = "PLATE"
                    cmbdamage.SelectedIndex = 0
                    txtplatemadeby.Clear()
                    TXTPLATECHKBY.Clear()
                    MADEDATE.Value = Mydate
                    txtplatedestroyedby.Clear()
                    destroyeddate.Value = Mydate
                    txtplateremadeby.Clear()
                    remadedate.Value = Mydate
                    txtsupervisor.Clear()
                    TXTNOOFPLATES.Clear()
                    TXTPLATESIZE.Clear()
                    CHKPLATEQC.CheckState = CheckState.Unchecked
                    TXTPLATEREMARKS.Clear()
                    PLATEINTIME.Clear()
                    PLATEOUTTIME.Clear()

                    GROUPPLATE.Visible = True
                    GROUPPLATE.Enabled = True

                    GROUPPOSITIVE.Enabled = False
                    GROUPPRINT.Enabled = False
                    GROUPCUTTING.Enabled = False
                    GROUPSORTING.Enabled = False
                    GROUPFOLDING.Enabled = False
                    GROUPUNFOLD.Enabled = False
                    GROUPPACKING.Enabled = False
                    GROUPFINAL.Enabled = False

                    GROUPPLATE.BringToFront()
                    TXTNOOFPLATES.Focus()
                    ' LBLPAPERMFG.Visible = False
                    ' txtpapermfg.Visible = False
                    ' LBLGRADENO.Visible = False
                    ' txtgrade.Visible = False
                    ' LBLTEST.Visible = False
                   ' txttestval.Visible = False

                Case 2
                    lblprocess.Text = "PAPER SHEET CUTTING"
                    tempprocessname = "PAPER SHEET CUTTING"

                    TXTCUTTINGNAME.Clear()
                    TXTCUTTINGSHEETGIVEN.Clear()
                    TXTCUTTINGSHEETGIVEN.Text = Val(txttotalsheets.Text)
                    CUTGIVENDATE.Value = Mydate
                    TXTCUTBALANCESSHEETS.Text = Val(txttotalsheets.Text)
                    CUTBALANCEDATE.Value = Mydate
                    TXTCUTDESTROYEDSHEETS.Clear()

                    TXTCUTMACHINENO.Clear()
                    TXTCUTTABLECLEARED.Clear()
                    TXTCUTMACHINPLTFORMCLR.Clear()
                    TXTCUTDUSTBINFREE.Clear()
                    TXTCUTMACHINEAREACLR.Clear()
                    TXTCUTMACBELOWAREACLR.Clear()
                    TXTCUTREJSHEETS.Clear()
                    txtsupervisor.Clear()
                    TXTCUTPAPERGRNNO.Clear()
                    TXTCUTPAPERTYPE.Clear()
                    TXTCUTPAPERREMARKS.Clear()
                    CUTPAPERINTIME.Clear()
                    CUTPAPEROUTTIME.Clear()
                    CHKPAPERGSM.CheckState = CheckState.Unchecked
                    CHKPAPERQUALITY.CheckState = CheckState.Unchecked


                    LBLCUTSURR.Visible = False
                    TXTCUTMACHINEAREACLR.Visible = False
                    LBLCUTPREJOBSHEET.Visible = False
                    TXTCUTPREJOBSHEET.Visible = False
                    LBLCUTMACHINEPLATFORM.Visible = False
                    TXTCUTMACHINPLTFORMCLR.Visible = False
                    LBLCUTLEAFLETSIZE.Visible = False
                    TXTCUTLEAFLETSIZE.Visible = False
                    LBLCUTPAPERGRNNO.Visible = True
                    TXTCUTPAPERGRNNO.Visible = True
                    LBLCUTPAPERTYPE.Visible = True
                    TXTCUTPAPERTYPE.Visible = True
                    CHKPAPERGSM.Visible = True
                    CHKPAPERQUALITY.Visible = True


                    GROUPCUTTING.Visible = True
                    GROUPCUTTING.Enabled = True

                    GROUPPOSITIVE.Enabled = False
                    GROUPPLATE.Enabled = False
                    GROUPPRINT.Enabled = False
                    GROUPSORTING.Enabled = False
                    GROUPFOLDING.Enabled = False
                    GROUPUNFOLD.Enabled = False
                    GROUPPACKING.Enabled = False
                    GROUPFINAL.Enabled = False

                    GROUPCUTTING.BringToFront()
                    TXTCUTTINGNAME.Focus()

                    'LBLPAPERMFG.Visible = True
                    'txtpapermfg.Visible = True
                    'LBLGRADENO.Visible = True
                    'txtgrade.Visible = True
                    'LBLTEST.Visible = True
                    'txttestval.Visible = True

                    CheckBox1.Visible = False
                    CheckBox2.Visible = False
                    CheckBox3.Visible = False
                    CheckBox4.Visible = False
                  '  Call ERRORVALID()



                Case 3
                    lblprocess.Text = "PRINTING"
                    tempprocessname = "PRINITNG"
                    lblbalancesheet.Text = "Bal Sheets Ret."
                    txtname.Clear()
                    txtsheetsgiven.Clear()
                    txtsheetsgiven.Text = Val(TEMPBALSHEET)
                    givendate.Value = Mydate
                    txtbalancesheets.Text = Val(TEMPBALSHEET)
                    balancedate.Value = Mydate
                    txtdestroyedsheets.Clear()
                    txtsupervisor.Clear()

                    TXTPRINTMACHINENO.Clear()
                    TXTPRINTPLATEREMOVED.Clear()
                    TXTPRINTINKPOT.Clear()
                    TXTPRINTSHEETS.Clear()
                    TXTPRINTPOSITIVE.Clear()
                    TXTPRINTNEGATIVE.Clear()
                    TXTPRINTSHADECARD.Clear()
                    TXTPRINTSAMPLEREMOVE.Clear()
                    TXTPRINTREGSHEETS.Clear()
                    TXTPRINTFEEDERAREA.Clear()
                    TXTPRINTDELIVERAREA.Clear()
                    TXTPRINTDUSTBINFREE.Clear()
                    TXTPRINTMACHINEAREA.Clear()
                    TXTPRINTBELOWAREA.Clear()
                    TXTPRINTREGSHEETS.Clear()
                    TXTPRINTREMARKS.Clear()
                    PRINTINTIME.Clear()
                    PRINTOUTTIME.Clear()
                    CHKPRINTVARNISH.CheckState = CheckState.Unchecked
                    CHKPRINTPERFORATION.CheckState = CheckState.Unchecked
                    CHKPRINTTEXTMATTER.CheckState = CheckState.Unchecked
                    CHKPRINTSIZE.CheckState = CheckState.Unchecked
                    CHKPRINTJOBREG.CheckState = CheckState.Unchecked
                    CHKPRINTCOLORSHADE.CheckState = CheckState.Unchecked

                    GROUPPRINT.Visible = True
                    GROUPPRINT.Enabled = True



                    TXTPRINTBELOWAREA.Visible = False
                    TXTPRINTDUSTBINFREE.Visible = False
                    TXTPRINTFEEDERAREA.Visible = False
                    TXTPRINTDELIVERAREA.Visible = False
                    TXTPRINTMACHINEAREA.Visible = False
                    TXTPRINTPLATEREMOVED.Visible = False
                    TXTPRINTREGSHEETS.Visible = False
                    TXTPRINTSHEETS.Visible = False
                    TXTPRINTINKPOT.Visible = False

                    CheckBox25.Visible = True
                    CheckBox26.Visible = True
                    CheckBox27.Visible = True
                    CheckBox28.Visible = True
                    CheckBox29.Visible = True
                    CheckBox30.Visible = True
                    CheckBox31.Visible = True
                    CheckBox32.Visible = True
                    CheckBox33.Visible = True

                    CheckBox25.CheckState = CheckState.Checked
                    CheckBox26.CheckState = CheckState.Checked
                    CheckBox27.CheckState = CheckState.Checked
                    CheckBox28.CheckState = CheckState.Checked
                    CheckBox29.CheckState = CheckState.Checked
                    CheckBox30.CheckState = CheckState.Checked
                    CheckBox31.CheckState = CheckState.Checked
                    CheckBox32.CheckState = CheckState.Checked
                    CheckBox33.CheckState = CheckState.Checked



                    GROUPPOSITIVE.Enabled = False
                    GROUPPLATE.Enabled = False
                    GROUPCUTTING.Enabled = False
                    GROUPSORTING.Enabled = False
                    GROUPFOLDING.Enabled = False
                    GROUPUNFOLD.Enabled = False
                    GROUPPACKING.Enabled = False
                    GROUPFINAL.Enabled = False

                    GROUPPRINT.BringToFront()
                    'TXTPR.Focus()
                    txtname.Focus()
                    'LBLPAPERMFG.Visible = True
                    'txtpapermfg.Visible = True
                    'LBLGRADENO.Visible = True
                    'txtgrade.Visible = True
                    'LBLTEST.Visible = True
                    'txttestval.Visible = True
                    'Call ERRORVALID()

                    Label159.Visible = True
                    Label160.Visible = True
                    Label161.Visible = True
                    TXTPRINTINGSHIFT1.Visible = True
                    TXTPRINTINGSHIFT2.Visible = True
                    TXTPRINTINGSHIFT3.Visible = True



                Case 4
                    lblprocess.Text = "LEAFLET SORTING"
                    tempprocessname = "LEAFLET SORTING"
                    LBLSOETBALANCESHEETS.Text = "Bal Sheets Ret."
                    TXTSORTNAME.Clear()
                    TXTSORTSHEETSGIVEN.Clear()
                    TXTSORTSHEETSGIVEN.Text = Val(TEMPBALSHEET)
                    SORTGIVENDATE.Value = Mydate
                    txtsupervisor.Clear()
                    'txtbalancesheets.Clear()
                    TXTSORTBALANCESHEETS.Text = Val(TEMPBALSHEET)
                    SORTBALANCEDATE.Value = Mydate
                    TXTSORTDESTROYESHEETS.Clear()

                    TXTSORTINGAREANO.Clear()
                    TXTSORTTABLECLR.Clear()
                    TXTSORTDUSTBINCLR.Clear()
                    TXTSORTCABINAREACLR.Clear()
                    TXTSORTREJSHEETS.Clear()
                    TXTSORTFLOORAREACLR.Clear()
                    TXTSORTPREJOBSHEET.Clear()
                    TXTSORTREMARKS.Clear()
                    SORTINTIME.Clear()
                    SORTOUTTIME.Clear()

                    TXTSORTFLOORAREACLR.Visible = False
                    TXTSORTTABLECLR.Visible = False
                    TXTSORTDUSTBINCLR.Visible = False
                    TXTSORTPREJOBSHEET.Visible = False
                    TXTSORTCABINAREACLR.Visible = False
                    TXTSORTREJSHEETS.Visible = False

                    CheckBox10.Visible = True
                    CheckBox11.Visible = True
                    CheckBox12.Visible = True
                    CheckBox13.Visible = True
                    CheckBox14.Visible = True
                    CheckBox15.Visible = True

                    CheckBox10.CheckState = CheckState.Checked
                    CheckBox11.CheckState = CheckState.Checked
                    CheckBox12.CheckState = CheckState.Checked
                    CheckBox13.CheckState = CheckState.Checked
                    CheckBox14.CheckState = CheckState.Checked
                    CheckBox15.CheckState = CheckState.Checked






                    GROUPSORTING.Visible = True
                    GROUPSORTING.Enabled = True

                    GROUPPOSITIVE.Enabled = False
                    GROUPPLATE.Enabled = False
                    GROUPPRINT.Enabled = False
                    GROUPCUTTING.Enabled = False
                    GROUPFOLDING.Enabled = False
                    GROUPUNFOLD.Enabled = False
                    GROUPPACKING.Enabled = False
                    GROUPFINAL.Enabled = False

                    GROUPSORTING.BringToFront()
                    TXTSORTNAME.Focus()
                    LBLPAPERMFG.Visible = True
                    'txtpapermfg.Visible = True
                    'LBLGRADENO.Visible = True
                    'txtgrade.Visible = True
                    'LBLTEST.Visible = True
                    'txttestval.Visible = True


                Case 5
                    lblprocess.Text = "PRINTED LEAFLET CUTTING"
                    tempprocessname = "PRINTED LEAFLET CUTTING"
                    LBLCUTBALANCESHEET.Text = "Bal Leaflet Ret."
                    Label108.Text = "Destoyed Leaflet"

                    TXTCUTBALANCESSHEETS.Clear()
                    givendate.Value = Mydate
                    TXTCUTTINGSHEETGIVEN.Text = Val(TEMPBALSHEET)
                    TXTCUTBALANCESSHEETS.Text = Val(TXTCUTTINGSHEETGIVEN.Text) * Val(txtups.Text)
                    CUTBALANCEDATE.Value = Mydate
                    TXTCUTDESTROYEDSHEETS.Clear()
                    txtsupervisor.Clear()


                    TXTCUTMACHINENO.Clear()
                    TXTCUTTINGNAME.Clear()
                    TXTCUTTABLECLEARED.Clear()
                    TXTCUTMACHINPLTFORMCLR.Clear()
                    TXTCUTDUSTBINFREE.Clear()
                    TXTCUTMACHINEAREACLR.Clear()
                    TXTCUTMACBELOWAREACLR.Clear()
                    TXTCUTREJSHEETS.Clear()
                    TXTCUTPREJOBSHEET.Clear()
                    TXTCUTLEAFLETSIZE.Clear()
                    TXTCUTPAPERGRNNO.Clear()
                    TXTCUTPAPERTYPE.Clear()
                    TXTCUTPAPERREMARKS.Clear()
                    CUTPAPERINTIME.Clear()
                    CUTPAPEROUTTIME.Clear()

                    LBLCUTSURR.Visible = True
                    TXTCUTMACHINEAREACLR.Visible = False
                    LBLCUTPREJOBSHEET.Visible = True
                    TXTCUTPREJOBSHEET.Visible = False
                    LBLCUTMACHINEPLATFORM.Visible = True
                    TXTCUTMACHINPLTFORMCLR.Visible = False
                    LBLCUTLEAFLETSIZE.Visible = True
                    TXTCUTLEAFLETSIZE.Visible = False
                    LBLCUTPAPERGRNNO.Visible = False
                    TXTCUTPAPERGRNNO.Visible = False
                    LBLCUTPAPERTYPE.Visible = False
                    TXTCUTPAPERTYPE.Visible = False
                    CHKPAPERGSM.Visible = False
                    CHKPAPERQUALITY.Visible = False


                    GROUPCUTTING.Visible = True
                    GROUPCUTTING.Enabled = True

                    GROUPPOSITIVE.Enabled = False
                    GROUPPRINT.Enabled = False
                    GROUPSORTING.Enabled = False
                    GROUPPLATE.Enabled = False
                    GROUPFOLDING.Enabled = False
                    GROUPUNFOLD.Enabled = False
                    GROUPPACKING.Enabled = False
                    GROUPFINAL.Enabled = False

                    GROUPCUTTING.BringToFront()
                    TXTCUTTINGNAME.Focus()
                    'LBLPAPERMFG.Visible = True
                    'txtpapermfg.Visible = True
                    'LBLGRADENO.Visible = True
                    'txtgrade.Visible = True
                    'LBLTEST.Visible = True
                    'txttestval.Visible = True
                    CheckBox1.Visible = True
                    CheckBox2.Visible = True
                    CheckBox3.Visible = True
                    CheckBox4.Visible = True

                    CheckBox1.CheckState = CheckState.Checked
                    CheckBox2.CheckState = CheckState.Checked
                    CheckBox3.CheckState = CheckState.Checked
                    CheckBox4.CheckState = CheckState.Checked
                  '  Call ERRORVALID()

                Case 6
                    lblprocess.Text = "MACHINE FOLDING"
                    tempprocessname = "MACHINE FOLDING"
                    TXTFOLDMACHINEPLTFRMCLR.Clear()
                    txtfoldingname.Clear()
                    txtfoldingsheetsgiven.Clear()
                    foldinggivendate.Value = Mydate
                    txtfoldingv.Clear()
                    txtfoldingh.Clear()
                    txtsampleappby.Clear()
                    txtfoldingsheetsgiven.Text = Val(TEMPBALSHEET)
                    'txtfoldingbalancesheet.Clear()
                    txtfoldingbalancesheet.Text = Val(TEMPBALSHEET)
                    foldingbalancedate.Value = Mydate
                    txtfoldingdestroyedsheets.Clear()
                    txtsupervisor.Clear()

                    CMBFOLDUNFOLD.SelectedIndex = 0
                    TXTFOLDMACHINENO.Clear()
                    TXTFOLDTABLECLR.Clear()
                    TXTFOLDMACHINEPLTFRMCLR.Clear()
                    TXTFOLDFEEDERAREA.Clear()
                    TXTFOLDCROSSUNIT.Clear()
                    TXTFOLD1STKNIFE.Clear()
                    TXTFOLD2NDKNIFE.Clear()
                    TXTFOLDTAPPINGUNIT.Clear()
                    TXTFOLDSTACKER.Clear()
                    TXTFOLDDUSTBIN.Clear()
                    TXTFOLDMACHINEAREA.Clear()
                    TXTFOLDBELOWAREA.Clear()
                    TXTFOLDREJSHEETS.Clear()

                    TXTUNFOLDDUSTBIN.Clear()
                    TXTUNFOLDMACHIENNO.Clear()
                    TXTUNFOLDREJSHEETS.Clear()
                    TXTUNFOLDSURRAREA.Clear()
                    TXTUNFOLDTABLECLR.Clear()

                    TXTFOLDBUNDLEDBY.Clear()
                    TXTFOLDPACKETDONEBY.Clear()
                    TXTFOLDLABELLEDBY.Clear()
                    TXTFOLDREMOVEJOBDOCKET.Clear()
                    TXTFOLDALLTRAYEMPTY.Clear()
                    TXTFOLDBARCODECAM.Clear()
                    TXTFOLDREMARKS.Clear()
                    FOLDINTIME.Clear()
                    FOLDOUTTIME.Clear()



                    TXTFOLDTABLECLR.Visible = False
                    TXTFOLDFEEDERAREA.Visible = False
                    TXTFOLDCROSSUNIT.Visible = False
                    TXTFOLDMACHINEAREA.Visible = False
                    TXTFOLDTAPPINGUNIT.Visible = False
                    TXTFOLDREMOVEJOBDOCKET.Visible = False
                    TXTFOLDREJSHEETS.Visible = False
                    TXTFOLDALLTRAYEMPTY.Visible = False
                    TXTFOLDBARCODECAM.Visible = False

                    CheckBox16.Visible = True
                    CheckBox17.Visible = True
                    CheckBox18.Visible = True
                    CheckBox19.Visible = True
                    CheckBox20.Visible = True
                    CheckBox21.Visible = True
                    CheckBox22.Visible = True
                    CheckBox23.Visible = True
                    CheckBox24.Visible = True


                    CheckBox16.CheckState = CheckState.Checked
                    CheckBox17.CheckState = CheckState.Checked
                    CheckBox18.CheckState = CheckState.Checked
                    CheckBox19.CheckState = CheckState.Checked
                    CheckBox20.CheckState = CheckState.Checked
                    CheckBox21.CheckState = CheckState.Checked
                    CheckBox22.CheckState = CheckState.Checked
                    CheckBox23.CheckState = CheckState.Checked
                    CheckBox24.CheckState = CheckState.Checked




                    GROUPFOLDING.Visible = True
                    GROUPFOLDING.Enabled = True

                    GROUPPOSITIVE.Enabled = False
                    GROUPPLATE.Enabled = False
                    GROUPPRINT.Enabled = False
                    GROUPSORTING.Enabled = False
                    GROUPCUTTING.Enabled = False
                    GROUPUNFOLD.Enabled = False
                    GROUPPACKING.Enabled = False
                    GROUPFINAL.Enabled = False

                    GROUPFOLDING.BringToFront()
                    TXTFOLDMACHINENO.Focus()
                    LBLPAPERMFG.Visible = True
                    'txtpapermfg.Visible = True
                    'LBLGRADENO.Visible = True
                    'txtgrade.Visible = True
                    'LBLTEST.Visible = True
                    'txttestval.Visible = True
                    '  Call ERRORVALID()


                    Label164.Visible = True
                    Label163.Visible = True
                    Label162.Visible = True
                    TXTFOLDSHIFT1.Visible = True
                    TXTFOLDSHIFT2.Visible = True
                    TXTFOLDSHIFT3.Visible = True


                Case 7
                    lblprocess.Text = "UNFOLDING"
                    tempprocessname = "UNFOLDING"
                    TXTFOLDMACHINEPLTFRMCLR.Clear()
                    txtfoldingname.Clear()
                    TXTUNFOLDSHEETGIVEN.Clear()
                    foldinggivendate.Value = Mydate
                    txtfoldingv.Clear()
                    txtfoldingh.Clear()
                    txtsampleappby.Clear()
                    TXTUNFOLDSHEETGIVEN.Text = Val(TEMPBALSHEET)
                    'txtfoldingbalancesheet.Clear()
                    TXTUNFOLDBALANCESHEET.Text = Val(TEMPBALSHEET)
                    foldingbalancedate.Value = Mydate
                    TXTUNFOLDDESTROYEDSHEET.Clear()
                    txtsupervisor.Clear()

                    CMBFOLDUNFOLD.SelectedIndex = 0
                    TXTFOLDMACHINENO.Clear()
                    TXTFOLDTABLECLR.Clear()
                    TXTFOLDMACHINEPLTFRMCLR.Clear()
                    TXTFOLDFEEDERAREA.Clear()
                    TXTFOLDCROSSUNIT.Clear()
                    TXTFOLD1STKNIFE.Clear()
                    TXTFOLD2NDKNIFE.Clear()
                    TXTFOLDTAPPINGUNIT.Clear()
                    TXTFOLDSTACKER.Clear()
                    TXTFOLDDUSTBIN.Clear()
                    TXTFOLDMACHINEAREA.Clear()
                    TXTFOLDBELOWAREA.Clear()
                    TXTFOLDREJSHEETS.Clear()

                    TXTUNFOLDDUSTBIN.Clear()
                    TXTUNFOLDMACHIENNO.Clear()
                    TXTUNFOLDREJSHEETS.Clear()
                    TXTUNFOLDSURRAREA.Clear()
                    TXTUNFOLDTABLECLR.Clear()



                    TXTUNFOLDSURRAREA.Visible = False
                    TXTUNFOLDTABLECLR.Visible = False
                    TXTUNFOLDREMOVEJOBDOCKE.Visible = False
                    TXTUNFOLDREJSHEETS.Visible = False
                    TXTUNFOLDALLTRAY.Visible = False

                    CheckBox5.Visible = True
                    CheckBox6.Visible = True
                    CheckBox7.Visible = True
                    CheckBox8.Visible = True
                    CheckBox9.Visible = True


                    CheckBox5.CheckState = CheckState.Checked
                    CheckBox6.CheckState = CheckState.Checked
                    CheckBox7.CheckState = CheckState.Checked
                    CheckBox8.CheckState = CheckState.Checked
                    CheckBox9.CheckState = CheckState.Checked




                    GROUPUNFOLD.Visible = True
                    GROUPUNFOLD.Enabled = True

                    GROUPPOSITIVE.Enabled = False
                    GROUPPLATE.Enabled = False
                    GROUPPRINT.Enabled = False
                    GROUPSORTING.Enabled = False
                    GROUPCUTTING.Enabled = False
                    GROUPFOLDING.Enabled = False
                    GROUPPACKING.Enabled = False
                    GROUPFINAL.Enabled = False

                    GROUPUNFOLD.BringToFront()
                    TXTUNFOLDMACHIENNO.Focus()
                    'LBLPAPERMFG.Visible = True
                    'txtpapermfg.Visible = True
                    'LBLGRADENO.Visible = True
                    'txtgrade.Visible = True
                    'LBLTEST.Visible = True
                    'txttestval.Visible = True

                Case 8
                    lblprocess.Text = "PACKING"
                    tempprocessname = "PACKING"
                    txtpackingname.Clear()
                    txtpacketsize.Clear()
                    txtpacketitem1.Clear()
                    txtpacketitem2.Clear()
                    txtpacketitem3.Clear()
                    txtpacket1.Clear()
                    txtpacket2.Clear()
                    txtpacket3.Clear()
                    txtpackettotal1.Clear()
                    txtpackettotal2.Clear()
                    txtpackettotal3.Clear()
                    txttotalpacket.Clear()
                    txtptotal.Clear()

                    txtshipperitem1.Clear()
                    txtshipperitem2.Clear()
                    txtshipperitem3.Clear()
                    txtshipper1.Clear()
                    txtshipper2.Clear()
                    txtshipper3.Clear()
                    txtshippertotal1.Clear()
                    txtshippertotal2.Clear()
                    txtshippertotal3.Clear()
                    txttotalshipper.Clear()
                    txtstotal.Clear()
                    txtsupervisor.Clear()

                    GROUPPACKING.Visible = True
                    GROUPPACKING.Enabled = True


                    GROUPPOSITIVE.Enabled = False
                    GROUPPLATE.Enabled = False
                    GROUPPRINT.Enabled = False
                    GROUPFOLDING.Enabled = False
                    GROUPUNFOLD.Enabled = False
                    GROUPFINAL.Enabled = False

                    GROUPPACKING.BringToFront()
                    txtpackingname.Focus()

                    'LBLPAPERMFG.Visible = True
                    'txtpapermfg.Visible = True
                    'LBLGRADENO.Visible = True
                    'txtgrade.Visible = True
                    'LBLTEST.Visible = True
                    'txttestval.Visible = True

                Case 9
                    lblprocess.Text = "FINAL"
                    tempprocessname = "FINAL"
                    txtshortqty.Clear()
                    If Val(txtstotal.Text) < Val(txtqty.Text) Then txtshortqty.Text = Val(txtqty.Text) - Val(txtstotal.Text)
                    cmbtobeprinted.SelectedIndex = 0

                    GROUPFINAL.Visible = True
                    GROUPFINAL.Enabled = True

                    GROUPPOSITIVE.Enabled = False
                    GROUPPLATE.Enabled = False
                    GROUPPRINT.Enabled = False
                    GROUPFOLDING.Enabled = False
                    GROUPUNFOLD.Enabled = False
                    GROUPPACKING.Enabled = False

                    GROUPFINAL.BringToFront()
                    txtshortqty.Focus()

                    'LBLPAPERMFG.Visible = True
                    'txtpapermfg.Visible = True
                    'LBLGRADENO.Visible = True
                    'txtgrade.Visible = True
                    'LBLTEST.Visible = True
                    'txttestval.Visible = True

                Case 10
                    lblprocess.Text = "COMPLETED"
            End Select

        Else

            Select Case (tempprocessno)
                Case 1
                    lblprocess.Text = "POSITIVE"
                    tempprocessname = "POSITIVE"
                    txtplatecheckedby.Clear()
                    txtcodecheckedby.Clear()
                    txtupscheckedby.Clear()
                    txtcorrectionappby.Clear()
                    txtsupervisor.Clear()

                    GROUPPOSITIVE.Visible = True
                    GROUPPOSITIVE.Enabled = True

                    GROUPPLATE.Enabled = False
                    GROUPCUTTING.Enabled = False
                    GROUPPRINT.Enabled = False
                    GROUPSORTING.Enabled = False
                    GROUPFOLDING.Enabled = False
                    GROUPUNFOLD.Enabled = False
                    GROUPPACKING.Enabled = False
                    GROUPFINAL.Enabled = False

                    GROUPPOSITIVE.BringToFront()
                    txtsrno.Focus()
                    txtplatecheckedby.Focus()

                    LBLPAPERMFG.Visible = False
                    txtpapermfg.Visible = False
                    LBLGRADENO.Visible = False
                    txtgrade.Visible = False
                    LBLTEST.Visible = False
                    txttestval.Visible = False

                Case 2
                    lblprocess.Text = "PLATE"
                    tempprocessname = "PLATE"
                    cmbdamage.SelectedIndex = 0
                    txtplatemadeby.Clear()
                    TXTPLATECHKBY.Clear()
                    MADEDATE.Value = Mydate
                    txtplatedestroyedby.Clear()
                    destroyeddate.Value = Mydate
                    txtplateremadeby.Clear()
                    remadedate.Value = Mydate
                    txtsupervisor.Clear()
                    TXTNOOFPLATES.Clear()
                    TXTPLATESIZE.Clear()
                    TXTPLATEREMARKS.Clear()

                    GROUPPLATE.Visible = True
                    GROUPPLATE.Enabled = True

                    GROUPPOSITIVE.Enabled = False
                    GROUPPRINT.Enabled = False
                    GROUPCUTTING.Enabled = False
                    GROUPSORTING.Enabled = False
                    GROUPFOLDING.Enabled = False
                    GROUPUNFOLD.Enabled = False
                    GROUPPACKING.Enabled = False
                    GROUPFINAL.Enabled = False

                    GROUPPLATE.BringToFront()
                    TXTNOOFPLATES.Focus()
                    LBLPAPERMFG.Visible = False
                    txtpapermfg.Visible = False
                    LBLGRADENO.Visible = False
                    txtgrade.Visible = False
                    LBLTEST.Visible = False
                    txttestval.Visible = False

                Case 3
                    lblprocess.Text = "PAPER CUTTING"
                    tempprocessname = "PAPER CUTTING"

                    TXTCUTTINGNAME.Clear()
                    TXTCUTTINGSHEETGIVEN.Clear()
                    TXTCUTTINGSHEETGIVEN.Text = Val(txttotalsheets.Text)
                    CUTGIVENDATE.Value = Mydate
                    TXTCUTBALANCESSHEETS.Text = Val(txttotalsheets.Text)
                    CUTBALANCEDATE.Value = Mydate
                    TXTCUTDESTROYEDSHEETS.Clear()

                    TXTCUTMACHINENO.Clear()
                    TXTCUTTABLECLEARED.Clear()
                    TXTCUTMACHINPLTFORMCLR.Clear()
                    TXTCUTDUSTBINFREE.Clear()
                    TXTCUTMACHINEAREACLR.Clear()
                    TXTCUTMACBELOWAREACLR.Clear()
                    TXTCUTREJSHEETS.Clear()
                    txtsupervisor.Clear()

                    GROUPCUTTING.Visible = True
                    GROUPCUTTING.Enabled = True

                    GROUPPOSITIVE.Enabled = False
                    GROUPPLATE.Enabled = False
                    GROUPPRINT.Enabled = False
                    GROUPSORTING.Enabled = False
                    GROUPFOLDING.Enabled = False
                    GROUPUNFOLD.Enabled = False
                    GROUPPACKING.Enabled = False
                    GROUPFINAL.Enabled = False

                    GROUPCUTTING.BringToFront()
                    TXTCUTTINGNAME.Focus()

                    LBLPAPERMFG.Visible = True
                    txtpapermfg.Visible = True
                    LBLGRADENO.Visible = True
                    txtgrade.Visible = True
                    LBLTEST.Visible = True
                    txttestval.Visible = True


                Case 4
                    lblprocess.Text = "PRINTING"
                    tempprocessname = "PRINITNG"
                    lblbalancesheet.Text = "Bal Sheets Ret."
                    txtname.Clear()
                    txtsheetsgiven.Clear()
                    txtsheetsgiven.Text = Val(TEMPBALSHEET)
                    givendate.Value = Mydate
                    txtbalancesheets.Text = Val(TEMPBALSHEET)
                    balancedate.Value = Mydate
                    txtdestroyedsheets.Clear()
                    txtsupervisor.Clear()

                    TXTPRINTMACHINENO.Clear()
                    TXTPRINTPLATEREMOVED.Clear()
                    TXTPRINTINKPOT.Clear()
                    TXTPRINTSHEETS.Clear()
                    TXTPRINTPOSITIVE.Clear()
                    TXTPRINTNEGATIVE.Clear()
                    TXTPRINTSHADECARD.Clear()
                    TXTPRINTSAMPLEREMOVE.Clear()
                    TXTPRINTREGSHEETS.Clear()
                    TXTPRINTFEEDERAREA.Clear()
                    TXTPRINTDELIVERAREA.Clear()
                    TXTPRINTDUSTBINFREE.Clear()
                    TXTPRINTMACHINEAREA.Clear()
                    TXTPRINTBELOWAREA.Clear()
                    TXTPRINTREGSHEETS.Clear()

                    GROUPPRINT.Visible = True
                    GROUPPRINT.Enabled = True


                    GROUPPOSITIVE.Enabled = False
                    GROUPPLATE.Enabled = False
                    GROUPCUTTING.Enabled = False
                    GROUPSORTING.Enabled = False
                    GROUPFOLDING.Enabled = False
                    GROUPUNFOLD.Enabled = False
                    GROUPPACKING.Enabled = False
                    GROUPFINAL.Enabled = False

                    GROUPPRINT.BringToFront()
                    'TXTPR.Focus()
                    txtname.Focus()
                    LBLPAPERMFG.Visible = True
                    txtpapermfg.Visible = True
                    LBLGRADENO.Visible = True
                    txtgrade.Visible = True
                    LBLTEST.Visible = True
                    txttestval.Visible = True

                Case 5
                    lblprocess.Text = "FULL SHEET SORTING"
                    tempprocessname = "FULL SHEET SORTING"
                    LBLSOETBALANCESHEETS.Text = "Bal Sheets Ret."
                    TXTSORTNAME.Clear()
                    TXTSORTSHEETSGIVEN.Clear()
                    TXTSORTSHEETSGIVEN.Text = Val(TEMPBALSHEET)
                    SORTGIVENDATE.Value = Mydate
                    txtsupervisor.Clear()
                    'txtbalancesheets.Clear()
                    TXTSORTBALANCESHEETS.Text = Val(TEMPBALSHEET)
                    SORTBALANCEDATE.Value = Mydate
                    TXTSORTDESTROYESHEETS.Clear()

                    TXTSORTINGAREANO.Clear()
                    TXTSORTTABLECLR.Clear()
                    TXTSORTDUSTBINCLR.Clear()
                    TXTSORTCABINAREACLR.Clear()
                    TXTSORTREJSHEETS.Clear()

                    GROUPSORTING.Visible = True
                    GROUPSORTING.Enabled = True

                    GROUPPOSITIVE.Enabled = False
                    GROUPPLATE.Enabled = False
                    GROUPPRINT.Enabled = False
                    GROUPCUTTING.Enabled = False
                    GROUPFOLDING.Enabled = False
                    GROUPUNFOLD.Enabled = False
                    GROUPPACKING.Enabled = False
                    GROUPFINAL.Enabled = False

                    GROUPSORTING.BringToFront()
                    TXTSORTNAME.Focus()
                    LBLPAPERMFG.Visible = True
                    txtpapermfg.Visible = True
                    LBLGRADENO.Visible = True
                    txtgrade.Visible = True
                    LBLTEST.Visible = True
                    txttestval.Visible = True

                Case 6
                    lblprocess.Text = "LEAFLET FULLSHEET CUTTING"
                    tempprocessname = "LEAFLET FULLSHEET CUTTING"
                    LBLCUTBALANCESHEET.Text = "Bal Leaflet Ret."
                    'lbldestroyedsheets.Text = "Destoyed Leaflet"

                    TXTCUTBALANCESSHEETS.Clear()
                    givendate.Value = Mydate
                    TXTCUTTINGSHEETGIVEN.Text = Val(TEMPBALSHEET)
                    TXTCUTBALANCESSHEETS.Text = Val(TXTCUTTINGSHEETGIVEN.Text) * Val(txtups.Text)
                    CUTBALANCEDATE.Value = Mydate
                    TXTCUTDESTROYEDSHEETS.Clear()
                    txtsupervisor.Clear()


                    TXTCUTMACHINENO.Clear()
                    TXTCUTTINGNAME.Clear()
                    TXTCUTTABLECLEARED.Clear()
                    TXTCUTMACHINPLTFORMCLR.Clear()
                    TXTCUTDUSTBINFREE.Clear()
                    TXTCUTMACHINEAREACLR.Clear()
                    TXTCUTMACBELOWAREACLR.Clear()
                    TXTCUTREJSHEETS.Clear()

                    GROUPCUTTING.Visible = True
                    GROUPCUTTING.Enabled = True
                    GROUPPOSITIVE.Enabled = False
                    GROUPPRINT.Enabled = False
                    GROUPSORTING.Enabled = False
                    GROUPPLATE.Enabled = False
                    GROUPFOLDING.Enabled = False
                    GROUPUNFOLD.Enabled = False
                    GROUPPACKING.Enabled = False
                    GROUPFINAL.Enabled = False

                    GROUPCUTTING.BringToFront()
                    TXTCUTTINGNAME.Focus()
                    LBLPAPERMFG.Visible = True
                    txtpapermfg.Visible = True
                    LBLGRADENO.Visible = True
                    txtgrade.Visible = True
                    LBLTEST.Visible = True
                    txttestval.Visible = True

                Case 7
                    lblprocess.Text = "LEAFLET SORTING"
                    tempprocessname = "LEAFLET SORTING"
                    LBLSOETBALANCESHEETS.Text = "Bal Sheets Ret."
                    TXTSORTNAME.Clear()
                    TXTSORTSHEETSGIVEN.Clear()
                    TXTSORTSHEETSGIVEN.Text = Val(TEMPBALSHEET)
                    SORTGIVENDATE.Value = Mydate
                    txtsupervisor.Clear()
                    'txtbalancesheets.Clear()
                    TXTSORTBALANCESHEETS.Text = Val(TEMPBALSHEET)
                    SORTBALANCEDATE.Value = Mydate
                    TXTSORTDESTROYESHEETS.Clear()

                    TXTSORTINGAREANO.Clear()
                    TXTSORTTABLECLR.Clear()
                    TXTSORTDUSTBINCLR.Clear()
                    TXTSORTCABINAREACLR.Clear()
                    TXTSORTREJSHEETS.Clear()

                    GROUPSORTING.Visible = True
                    GROUPSORTING.Enabled = True

                    GROUPPOSITIVE.Enabled = False
                    GROUPPLATE.Enabled = False
                    GROUPPRINT.Enabled = False
                    GROUPCUTTING.Enabled = False
                    GROUPFOLDING.Enabled = False
                    GROUPUNFOLD.Enabled = False
                    GROUPPACKING.Enabled = False
                    GROUPFINAL.Enabled = False

                    GROUPSORTING.BringToFront()
                    TXTSORTNAME.Focus()
                    LBLPAPERMFG.Visible = True
                    txtpapermfg.Visible = True
                    LBLGRADENO.Visible = True
                    txtgrade.Visible = True
                    LBLTEST.Visible = True
                    txttestval.Visible = True

                Case 8
                    lblprocess.Text = "FOLDING"
                    tempprocessname = "FOLDING"
                    TXTFOLDMACHINEPLTFRMCLR.Clear()
                    txtfoldingname.Clear()
                    txtfoldingsheetsgiven.Clear()
                    foldinggivendate.Value = Mydate
                    txtfoldingv.Clear()
                    txtfoldingh.Clear()
                    txtsampleappby.Clear()
                    txtfoldingsheetsgiven.Text = Val(TEMPBALSHEET)
                    'txtfoldingbalancesheet.Clear()
                    txtfoldingbalancesheet.Text = Val(txtfoldingsheetsgiven.Text)
                    foldingbalancedate.Value = Mydate
                    txtfoldingdestroyedsheets.Clear()
                    txtsupervisor.Clear()

                    CMBFOLDUNFOLD.SelectedIndex = 0
                    TXTFOLDMACHINENO.Clear()
                    TXTFOLDTABLECLR.Clear()
                    TXTFOLDMACHINEPLTFRMCLR.Clear()
                    TXTFOLDFEEDERAREA.Clear()
                    TXTFOLDCROSSUNIT.Clear()
                    TXTFOLD1STKNIFE.Clear()
                    TXTFOLD2NDKNIFE.Clear()
                    TXTFOLDTAPPINGUNIT.Clear()
                    TXTFOLDSTACKER.Clear()
                    TXTFOLDDUSTBIN.Clear()
                    TXTFOLDMACHINEAREA.Clear()
                    TXTFOLDBELOWAREA.Clear()
                    TXTFOLDREJSHEETS.Clear()

                    TXTUNFOLDDUSTBIN.Clear()
                    TXTUNFOLDMACHIENNO.Clear()
                    TXTUNFOLDREJSHEETS.Clear()
                    TXTUNFOLDSURRAREA.Clear()
                    TXTUNFOLDTABLECLR.Clear()

                    GROUPFOLDING.Visible = True
                    GROUPFOLDING.Enabled = True

                    GROUPPOSITIVE.Enabled = False
                    GROUPPLATE.Enabled = False
                    GROUPPRINT.Enabled = False
                    GROUPSORTING.Enabled = False
                    GROUPCUTTING.Enabled = False
                    GROUPUNFOLD.Enabled = False
                    GROUPPACKING.Enabled = False
                    GROUPFINAL.Enabled = False

                    GROUPFOLDING.BringToFront()
                    TXTFOLDMACHINEPLTFRMCLR.Focus()
                    LBLPAPERMFG.Visible = True
                    txtpapermfg.Visible = True
                    LBLGRADENO.Visible = True
                    txtgrade.Visible = True
                    LBLTEST.Visible = True
                    txttestval.Visible = True


                Case 9
                    lblprocess.Text = "PACKING"
                    tempprocessname = "PACKING"
                    txtpackingname.Clear()
                    txtpacketsize.Clear()
                    txtpacketitem1.Clear()
                    txtpacketitem2.Clear()
                    txtpacketitem3.Clear()
                    txtpacket1.Clear()
                    txtpacket2.Clear()
                    txtpacket3.Clear()
                    txtpackettotal1.Clear()
                    txtpackettotal2.Clear()
                    txtpackettotal3.Clear()
                    txttotalpacket.Clear()
                    txtptotal.Clear()

                    txtshipperitem1.Clear()
                    txtshipperitem2.Clear()
                    txtshipperitem3.Clear()
                    txtshipper1.Clear()
                    txtshipper2.Clear()
                    txtshipper3.Clear()
                    txtshippertotal1.Clear()
                    txtshippertotal2.Clear()
                    txtshippertotal3.Clear()
                    txttotalshipper.Clear()
                    txtstotal.Clear()
                    txtsupervisor.Clear()

                    GROUPPACKING.Visible = True
                    GROUPPACKING.Enabled = True


                    GROUPPOSITIVE.Enabled = False
                    GROUPPLATE.Enabled = False
                    GROUPPRINT.Enabled = False
                    GROUPFOLDING.Enabled = False
                    GROUPUNFOLD.Enabled = False
                    GROUPFINAL.Enabled = False

                    GROUPPACKING.BringToFront()
                    txtpackingname.Focus()

                    LBLPAPERMFG.Visible = True
                    txtpapermfg.Visible = True
                    LBLGRADENO.Visible = True
                    txtgrade.Visible = True
                    LBLTEST.Visible = True
                    txttestval.Visible = True

                Case 10
                    lblprocess.Text = "FINAL"
                    tempprocessname = "FINAL"
                    txtshortqty.Clear()
                    If Val(txtstotal.Text) < Val(txtqty.Text) Then txtshortqty.Text = Val(txtqty.Text) - Val(txtstotal.Text)
                    cmbtobeprinted.SelectedIndex = 0

                    GROUPFINAL.Visible = True
                    GROUPFINAL.Enabled = True

                    GROUPPOSITIVE.Enabled = False
                    GROUPPLATE.Enabled = False
                    GROUPPRINT.Enabled = False
                    GROUPFOLDING.Enabled = False
                    GROUPPACKING.Enabled = False
                    GROUPUNFOLD.Enabled = False

                    GROUPFINAL.BringToFront()
                    txtshortqty.Focus()

                    LBLPAPERMFG.Visible = True
                    txtpapermfg.Visible = True
                    LBLGRADENO.Visible = True
                    txtgrade.Visible = True
                    LBLTEST.Visible = True
                    txttestval.Visible = True

                Case 11
                    lblprocess.Text = "COMPLETED"
            End Select

        End If


    End Sub

    Sub FILLGRID()

        If ClientName = "AMR" Then

            If tempprocessno = 1 Then
                gridjob.Rows.Add("PLATE", gridjob.RowCount + 1, "", TXTNOOFPLATES.Text.Trim, CMBPLATETYPE.Text.Trim, TXTPLATESIZE.Text.Trim, CHKPLATEQC.Checked, TXTPLATEREMARKS.Text.Trim, PLATEINTIME.Text, PLATEOUTTIME.Text, "", "", "", "", "", Format(MADEDATE.Value, "dd/MM/yyyy"), txtplatedestroyedby.Text.Trim, Format(destroyeddate.Value, "dd/MM/yyyy"), txtplateremadeby.Text.Trim, Format(remadedate.Value, "dd/MM/yyyy"), txtplatemadeby.Text.Trim, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtsupervisor.Text.Trim)
                tempprocessno = tempprocessno + 1
                SELECTCASE()

            ElseIf tempprocessno = 2 Then
                gridjob.Rows.Add("PAPER SHEET CUTTING", gridjob.RowCount + 1, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", TXTCUTTINGNAME.Text.Trim, TXTCUTTINGSHEETGIVEN.Text.Trim, Format(CUTGIVENDATE.Value, "dd/MM/yyyy"), TXTCUTBALANCESSHEETS.Text.Trim, Format(CUTBALANCEDATE.Value, "dd/MM/yyyy"), TXTCUTDESTROYEDSHEETS.Text.Trim, TXTCUTMACHINENO.Text.Trim, TXTCUTTABLECLEARED.Text.Trim, TXTCUTMACHINPLTFORMCLR.Text.Trim, TXTCUTDUSTBINFREE.Text.Trim, TXTCUTMACHINEAREACLR.Text.Trim, TXTCUTMACBELOWAREACLR.Text.Trim, TXTCUTREJSHEETS.Text.Trim, "", "", "", "", "", "", "", "", "", "", "", "", "", "", TXTCUTPAPERGRNNO.Text.Trim, TXTCUTPAPERTYPE.Text.Trim, TXTCUTPAPERREMARKS.Text.Trim, CUTPAPERINTIME.Text, CUTPAPEROUTTIME.Text, CHKPAPERGSM.Checked, CHKPAPERQUALITY.Checked, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtsupervisor.Text.Trim)
                tempprocessno = tempprocessno + 1
                TEMPBALSHEET = Val(TXTCUTBALANCESSHEETS.Text)
                SELECTCASE()

            ElseIf tempprocessno = 3 Then
                gridjob.Rows.Add("PRINTING", gridjob.RowCount + 1, TXTNOOFCOLORS.Text.Trim, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtname.Text.Trim, txtsheetsgiven.Text.Trim, Format(givendate.Value, "dd/MM/yyyy"), txtbalancesheets.Text.Trim, Format(balancedate.Value, "dd/MM/yyyy"), txtdestroyedsheets.Text.Trim, TXTPRINTMACHINENO.Text.Trim, "", "", TXTPRINTDUSTBINFREE.Text.Trim, TXTPRINTMACHINEAREA.Text.Trim, TXTPRINTBELOWAREA.Text.Trim, TXTPRINTREJSHEET.Text.Trim, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", TXTPRINTPLATEREMOVED.Text.Trim, TXTPRINTINKPOT.Text.Trim, TXTPRINTSHEETS.Text.Trim, TXTPRINTPOSITIVE.Text.Trim, TXTPRINTNEGATIVE.Text.Trim, TXTPRINTSHADECARD.Text.Trim, TXTPRINTSAMPLEREMOVE.Text.Trim, TXTPRINTREGSHEETS.Text.Trim, TXTPRINTFEEDERAREA.Text.Trim, TXTPRINTDELIVERAREA.Text.Trim, CMBPRINTTYPE.Text.Trim, TXTPRINTREMARKS.Text.Trim, PRINTINTIME.Text, PRINTOUTTIME.Text, CHKPRINTVARNISH.Checked, CHKPRINTPERFORATION.Checked, CHKPRINTTEXTMATTER.Checked, CHKPRINTSIZE.Checked, CHKPRINTJOBREG.Checked, CHKPRINTCOLORSHADE.Checked, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtsupervisor.Text.Trim)
                tempprocessno = tempprocessno + 1
                TEMPBALSHEET = Val(txtbalancesheets.Text)
                SELECTCASE()

            ElseIf tempprocessno = 4 Then
                gridjob.Rows.Add("LEAFLET SORTING", gridjob.RowCount + 1, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", TXTSORTNAME.Text.Trim, TXTSORTSHEETSGIVEN.Text.Trim, Format(SORTGIVENDATE.Value, "dd/MM/yyyy"), TXTSORTBALANCESHEETS.Text.Trim, Format(SORTBALANCEDATE.Value, "dd/MM/yyyy"), TXTSORTDESTROYESHEETS.Text.Trim, TXTSORTINGAREANO.Text.Trim, TXTSORTTABLECLR.Text.Trim, TXTSORTCABINAREACLR.Text.Trim, TXTSORTDUSTBINCLR.Text.Trim, "", "", TXTSORTREJSHEETS.Text.Trim, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", TXTSORTFLOORAREACLR.Text.Trim, TXTSORTPREJOBSHEET.Text.Trim, TXTSORTREMARKS.Text.Trim, SORTINTIME.Text, SORTOUTTIME.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtsupervisor.Text.Trim)
                tempprocessno = tempprocessno + 1
                TEMPBALSHEET = Val(TXTSORTBALANCESHEETS.Text)
                SELECTCASE()

            ElseIf tempprocessno = 5 Then
                gridjob.Rows.Add("PRINTED LEAFLET CUTTING", gridjob.RowCount + 1, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", TXTCUTTINGNAME.Text.Trim, TXTCUTTINGSHEETGIVEN.Text.Trim, Format(CUTGIVENDATE.Value, "dd/MM/yyyy"), TXTCUTBALANCESSHEETS.Text.Trim, Format(CUTBALANCEDATE.Value, "dd/MM/yyyy"), TXTCUTDESTROYEDSHEETS.Text.Trim, TXTCUTMACHINENO.Text.Trim, TXTCUTTABLECLEARED.Text.Trim, TXTCUTMACHINPLTFORMCLR.Text.Trim, TXTCUTDUSTBINFREE.Text.Trim, TXTCUTMACHINEAREACLR.Text.Trim, TXTCUTMACBELOWAREACLR.Text.Trim, TXTCUTREJSHEETS.Text.Trim, "", "", "", "", "", "", "", "", "", "", "", "", "", "", TXTCUTPAPERGRNNO.Text.Trim, TXTCUTPAPERTYPE.Text.Trim, TXTCUTPAPERREMARKS.Text.Trim, CUTPAPERINTIME.Text, CUTPAPEROUTTIME.Text, CHKPAPERGSM.Checked, CHKPAPERQUALITY.Checked, TXTCUTPREJOBSHEET.Text.Trim, TXTCUTLEAFLETSIZE.Text.Trim, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtsupervisor.Text.Trim)
                tempprocessno = tempprocessno + 1
                TEMPBALSHEET = Val(TXTCUTBALANCESSHEETS.Text)
                SELECTCASE()

            ElseIf tempprocessno = 6 Then
                gridjob.Rows.Add("MACHINE FOLDING", gridjob.RowCount + 1, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtfoldingname.Text.Trim, txtfoldingsheetsgiven.Text.Trim, Format(foldinggivendate.Value, "dd/MM/yyyy"), txtfoldingbalancesheet.Text.Trim, Format(foldingbalancedate.Value, "dd/MM/yyyy"), txtfoldingdestroyedsheets.Text.Trim, TXTFOLDMACHINENO.Text.Trim, TXTFOLDTABLECLR.Text.Trim, TXTFOLDMACHINEPLTFRMCLR.Text.Trim, TXTFOLDDUSTBIN.Text.Trim, TXTFOLDMACHINEAREA.Text.Trim, TXTFOLDBELOWAREA.Text.Trim, TXTFOLDREJSHEETS.Text.Trim, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", TXTFOLDCROSSUNIT.Text.Trim, txtfoldingv.Text.Trim, txtfoldingh.Text.Trim, TXTFOLDTAPPINGUNIT.Text.Trim, TXTFOLDSTACKER.Text.Trim, TXTFOLDBUNDLEDBY.Text.Trim, TXTFOLDPACKETDONEBY.Text.Trim, TXTFOLDLABELLEDBY.Text.Trim, TXTFOLDREMOVEJOBDOCKET.Text.Trim, TXTFOLDALLTRAYEMPTY.Text.Trim, TXTFOLDBARCODECAM.Text.Trim, TXTFOLDREMARKS.Text.Trim, FOLDINTIME.Text, FOLDOUTTIME.Text, txtsampleappby.Text.Trim, "", "", "", "", txtsupervisor.Text.Trim)
                tempprocessno = tempprocessno + 1
                TEMPBALSHEET = Val(txtfoldingbalancesheet.Text)
                SELECTCASE()

            ElseIf tempprocessno = 7 Then
                gridjob.Rows.Add("UNFOLDING", gridjob.RowCount + 1, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", TXTUNFOLDSHEETGIVEN.Text.Trim, "", TXTUNFOLDBALANCESHEET.Text.Trim, "", TXTUNFOLDDESTROYEDSHEET.Text.Trim, TXTUNFOLDMACHIENNO.Text.Trim, TXTUNFOLDTABLECLR.Text.Trim, "", TXTUNFOLDDUSTBIN.Text.Trim, TXTUNFOLDSURRAREA.Text.Trim, "", TXTUNFOLDREJSHEETS.Text.Trim, TXTUNFOLDREMOVEJOBDOCKE.Text.Trim, TXTUNFOLDALLTRAY.Text.Trim, TXTUNFOLDSORTINGBY.Text.Trim, TXTUNFOLDCOUNTING.Text.Trim, TXTUNFOLDPACKETBY.Text.Trim, TXTUNFOLDLABELLEDBY.Text.Trim, TXTUNFOLDSAMPLEAPPBY.Text.Trim, TXTUNFOLDSHEETGIVEN.Text.Trim, TXTUNFOLDBALANCESHEET.Text.Trim, TXTUNFOLDDESTROYEDSHEET.Text.Trim, Format(UNFOLDGIVENDATE.Value, "dd/MM/yyyy"), TXTUNFOLDREMARKS.Text.Trim, UNFOLDINTIME.Text, UNFOLDOUTTIME.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtsupervisor.Text.Trim)
                tempprocessno = tempprocessno + 1
                TEMPBALSHEET = Val(TXTUNFOLDBALANCESHEET.Text)
                SELECTCASE()

            ElseIf tempprocessno = 8 Then
                If Val(txtptotal.Text) = Val(txtstotal.Text) Then
                    gridjob.Rows.Add("PACKING", gridjob.RowCount + 1, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtpackingname.Text.Trim, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txttotalpacket.Text.Trim, txttotalshipper.Text.Trim, txtpacketsize.Text.Trim, "", txtsupervisor.Text.Trim)
                    tempprocessno = tempprocessno + 1
                    SELECTCASE()
                Else
                    MsgBox("Total Does Not Match", MsgBoxStyle.Critical)
                    txtpacketitem1.Focus()
                    Exit Sub
                End If

            ElseIf tempprocessno = 9 Then
                gridjob.Rows.Add("FINAL", gridjob.RowCount + 1, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", Val(txtshortqty.Text.Trim), txtsupervisor.Text.Trim)
                tempprocessno = tempprocessno + 1
                SELECTCASE()
            End If

        Else

            If tempprocessno = 1 Then
                gridjob.Rows.Add("POSITIVE", gridjob.RowCount + 1, txtcolor.Text.Trim, "", "", "", "", "", "", "", txtplatecheckedby.Text.Trim, txtcodecheckedby.Text.Trim, txtupscheckedby.Text.Trim, txtcorrectionappby.Text.Trim, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtsupervisor.Text.Trim)
                tempprocessno = tempprocessno + 1
                SELECTCASE()

            ElseIf tempprocessno = 2 Then
                gridjob.Rows.Add("PLATE", gridjob.RowCount + 1, "", TXTNOOFPLATES.Text.Trim, CMBPLATETYPE.Text.Trim, TXTPLATESIZE.Text.Trim, CHKPLATEQC.Checked, TXTPLATEREMARKS.Text.Trim, PLATEINTIME.Text, PLATEOUTTIME.Text, "", "", "", "", txtplatecheckedby.Text.Trim, Format(MADEDATE.Value, "dd/MM/yyyy"), txtplatedestroyedby.Text.Trim, Format(destroyeddate.Value, "dd/MM/yyyy"), txtplateremadeby.Text.Trim, Format(remadedate.Value, "dd/MM/yyyy"), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtsupervisor.Text.Trim)
                tempprocessno = tempprocessno + 1
                SELECTCASE()


            ElseIf tempprocessno = 3 Then
                gridjob.Rows.Add("PAPER CUTTING", gridjob.RowCount + 1, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", TXTCUTTINGNAME.Text.Trim, TXTCUTTINGSHEETGIVEN.Text.Trim, Format(CUTGIVENDATE.Value, "dd/MM/yyyy"), TXTCUTBALANCESSHEETS.Text.Trim, Format(CUTBALANCEDATE.Value, "dd/MM/yyyy"), TXTCUTDESTROYEDSHEETS.Text.Trim, TXTCUTMACHINENO.Text.Trim, TXTCUTTABLECLEARED.Text.Trim, TXTCUTMACHINPLTFORMCLR.Text.Trim, TXTCUTDUSTBINFREE.Text.Trim, TXTCUTMACHINEAREACLR.Text.Trim, TXTCUTMACBELOWAREACLR.Text.Trim, TXTCUTREJSHEETS.Text.Trim, "", "", "", "", "", "", "", "", "", "", "", "", "", "", TXTCUTPAPERGRNNO.Text.Trim, TXTCUTPAPERTYPE.Text.Trim, TXTCUTPAPERREMARKS.Text.Trim, CUTPAPERINTIME.Text, CUTPAPEROUTTIME.Text, CHKPAPERGSM.Checked, CHKPAPERQUALITY.Checked, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtsupervisor.Text.Trim)
                tempprocessno = tempprocessno + 1
                TEMPBALSHEET = Val(TXTCUTBALANCESSHEETS.Text)
                SELECTCASE()

            ElseIf tempprocessno = 4 Then
                'Dim SHEETGIVEN As String
                gridjob.Rows.Add("PRINTING", gridjob.RowCount + 1, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtname.Text.Trim, txtsheetsgiven.Text.Trim, Format(givendate.Value, "dd/MM/yyyy"), txtbalancesheets.Text.Trim, Format(balancedate.Value, "dd/MM/yyyy"), txtdestroyedsheets.Text.Trim, TXTPRINTMACHINENO.Text.Trim, "", "", TXTPRINTDUSTBINFREE.Text.Trim, TXTPRINTMACHINEAREA.Text.Trim, TXTPRINTBELOWAREA.Text.Trim, TXTPRINTREJSHEET.Text.Trim, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", TXTPRINTPLATEREMOVED.Text.Trim, TXTPRINTINKPOT.Text.Trim, TXTPRINTSHEETS.Text.Trim, TXTPRINTPOSITIVE.Text.Trim, TXTPRINTNEGATIVE.Text.Trim, TXTPRINTSHADECARD.Text.Trim, TXTPRINTSAMPLEREMOVE.Text.Trim, TXTPRINTREGSHEETS.Text.Trim, TXTPRINTFEEDERAREA.Text.Trim, TXTPRINTDELIVERAREA.Text.Trim, CMBPRINTTYPE.Text.Trim, TXTPRINTREMARKS.Text.Trim, PRINTINTIME.Text, PRINTOUTTIME.Text, CHKPRINTVARNISH.Checked, CHKPRINTPERFORATION.Checked, CHKPRINTTEXTMATTER.Checked, CHKPRINTSIZE.Checked, CHKPRINTJOBREG.Checked, CHKPRINTCOLORSHADE.Checked, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtsupervisor.Text.Trim)
                tempprocessno = tempprocessno + 1
                TEMPBALSHEET = Val(txtbalancesheets.Text)
                SELECTCASE()

            ElseIf tempprocessno = 5 Then
                gridjob.Rows.Add("FULL SHEET SORTING", gridjob.RowCount + 1, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", TXTSORTNAME.Text.Trim, TXTSORTSHEETSGIVEN.Text.Trim, Format(SORTGIVENDATE.Value, "dd/MM/yyyy"), TXTSORTBALANCESHEETS.Text.Trim, Format(SORTBALANCEDATE.Value, "dd/MM/yyyy"), TXTSORTDESTROYESHEETS.Text.Trim, TXTSORTINGAREANO.Text.Trim, TXTSORTTABLECLR.Text.Trim, TXTSORTCABINAREACLR.Text.Trim, TXTSORTDUSTBINCLR.Text.Trim, "", "", TXTSORTREJSHEETS.Text.Trim, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", TXTSORTFLOORAREACLR.Text.Trim, TXTSORTPREJOBSHEET.Text.Trim, TXTSORTREMARKS.Text.Trim, SORTINTIME.Text, SORTOUTTIME.Text, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtsupervisor.Text.Trim)
                tempprocessno = tempprocessno + 1
                TEMPBALSHEET = Val(TXTSORTBALANCESHEETS.Text)
                SELECTCASE()

            ElseIf tempprocessno = 6 Then
                gridjob.Rows.Add("LEAFLET FULLSHEET CUTTING", gridjob.RowCount + 1, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", TXTCUTTINGNAME.Text.Trim, TXTCUTTINGSHEETGIVEN.Text.Trim, Format(CUTGIVENDATE.Value, "dd/MM/yyyy"), TXTCUTBALANCESSHEETS.Text.Trim, Format(CUTBALANCEDATE.Value, "dd/MM/yyyy"), TXTCUTDESTROYEDSHEETS.Text.Trim, TXTCUTMACHINENO.Text.Trim, TXTCUTTABLECLEARED.Text.Trim, TXTCUTMACHINPLTFORMCLR.Text.Trim, TXTCUTDUSTBINFREE.Text.Trim, TXTCUTMACHINEAREACLR.Text.Trim, TXTCUTMACBELOWAREACLR.Text.Trim, TXTCUTREJSHEETS.Text.Trim, "", "", "", "", "", "", "", "", "", "", "", "", "", "", TXTCUTPAPERGRNNO.Text.Trim, TXTCUTPAPERTYPE.Text.Trim, TXTCUTPAPERREMARKS.Text.Trim, CUTPAPERINTIME.Text, CUTPAPEROUTTIME.Text, CHKPAPERGSM.Checked, CHKPAPERQUALITY.Checked, TXTCUTPREJOBSHEET.Text.Trim, TXTCUTLEAFLETSIZE.Text.Trim, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtsupervisor.Text.Trim)
                tempprocessno = tempprocessno + 1
                TEMPBALSHEET = Val(TXTCUTBALANCESSHEETS.Text)
                SELECTCASE()

            ElseIf tempprocessno = 7 Then
                gridjob.Rows.Add("LEAFLET SORTING", gridjob.RowCount + 1, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", TXTSORTNAME.Text.Trim, TXTSORTSHEETSGIVEN.Text.Trim, Format(SORTGIVENDATE.Value, "dd/MM/yyyy"), TXTSORTBALANCESHEETS.Text.Trim, Format(SORTBALANCEDATE.Value, "dd/MM/yyyy"), TXTSORTDESTROYESHEETS.Text.Trim, TXTSORTINGAREANO.Text.Trim, TXTSORTTABLECLR.Text.Trim, TXTSORTCABINAREACLR.Text.Trim, TXTSORTDUSTBINCLR.Text.Trim, "", "", TXTSORTREJSHEETS.Text.Trim, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtsupervisor.Text.Trim)
                tempprocessno = tempprocessno + 1
                TEMPBALSHEET = Val(TXTSORTBALANCESHEETS.Text)
                SELECTCASE()


            ElseIf tempprocessno = 8 Then
                If CMBFOLDUNFOLD.Text.Trim = "FOLDING" Then
                    gridjob.Rows.Add("FOLDING", gridjob.RowCount + 1, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtfoldingname.Text.Trim, txtfoldingsheetsgiven.Text.Trim, Format(foldinggivendate.Value, "dd/MM/yyyy"), txtfoldingbalancesheet.Text.Trim, Format(foldingbalancedate.Value, "dd/MM/yyyy"), txtfoldingdestroyedsheets.Text.Trim, TXTFOLDMACHINENO.Text.Trim, TXTFOLDTABLECLR.Text.Trim, TXTFOLDMACHINEPLTFRMCLR.Text.Trim, TXTFOLDDUSTBIN.Text.Trim, TXTFOLDMACHINEAREA.Text.Trim, TXTFOLDBELOWAREA.Text.Trim, TXTFOLDREJSHEETS.Text.Trim, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", TXTFOLDCROSSUNIT.Text.Trim, TXTFOLD1STKNIFE.Text.Trim, TXTFOLD2NDKNIFE.Text.Trim, TXTFOLDTAPPINGUNIT.Text.Trim, TXTFOLDSTACKER.Text.Trim, txtsampleappby.Text.Trim, TXTFOLDBUNDLEDBY.Text.Trim, TXTFOLDPACKETDONEBY.Text.Trim, TXTFOLDLABELLEDBY.Text.Trim, TXTFOLDREMOVEJOBDOCKET.Text.Trim, TXTFOLDALLTRAYEMPTY.Text.Trim, TXTFOLDBARCODECAM.Text.Trim, TXTFOLDREMARKS.Text.Trim, FOLDINTIME.Text, FOLDOUTTIME.Text, "", "", "", "", txtsupervisor.Text.Trim)
                Else
                    gridjob.Rows.Add("UNFOLDING", gridjob.RowCount + 1, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtfoldingname.Text.Trim, txtfoldingsheetsgiven.Text.Trim, Format(foldinggivendate.Value, "dd/MM/yyyy"), txtfoldingbalancesheet.Text.Trim, Format(foldingbalancedate.Value, "dd/MM/yyyy"), txtfoldingdestroyedsheets.Text.Trim, TXTFOLDMACHINENO.Text.Trim, TXTFOLDTABLECLR.Text.Trim, TXTFOLDMACHINEPLTFRMCLR.Text.Trim, TXTFOLDDUSTBIN.Text.Trim, TXTFOLDMACHINEAREA.Text.Trim, TXTFOLDBELOWAREA.Text.Trim, TXTFOLDREJSHEETS.Text.Trim, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", TXTFOLDCROSSUNIT.Text.Trim, TXTFOLD1STKNIFE.Text.Trim, TXTFOLD2NDKNIFE.Text.Trim, TXTFOLDTAPPINGUNIT.Text.Trim, TXTFOLDSTACKER.Text.Trim, txtsampleappby.Text.Trim, TXTFOLDBUNDLEDBY.Text.Trim, TXTFOLDPACKETDONEBY.Text.Trim, TXTFOLDLABELLEDBY.Text.Trim, TXTFOLDREMOVEJOBDOCKET.Text.Trim, TXTFOLDALLTRAYEMPTY.Text.Trim, TXTFOLDBARCODECAM.Text.Trim, TXTFOLDREMARKS.Text.Trim, FOLDINTIME.Text, FOLDOUTTIME.Text, "", "", "", "", txtsupervisor.Text.Trim)
                End If

                tempprocessno = tempprocessno + 1
                TEMPBALSHEET = Val(txtfoldingbalancesheet.Text)
                SELECTCASE()

            ElseIf tempprocessno = 9 Then
                If Val(txtptotal.Text) = Val(txtstotal.Text) Then
                    gridjob.Rows.Add("PACKING", gridjob.RowCount + 1, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtpackingname.Text.Trim, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txttotalpacket.Text.Trim, txttotalshipper.Text.Trim, txtpacketsize.Text.Trim, "", txtsupervisor.Text.Trim)
                    tempprocessno = tempprocessno + 1
                    SELECTCASE()
                Else
                    MsgBox("Total Does Not Match", MsgBoxStyle.Critical)
                    txtpacketitem1.Focus()
                    Exit Sub
                End If

            ElseIf tempprocessno = 10 Then
                gridjob.Rows.Add("FINAL", gridjob.RowCount + 1, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", Val(txtshortqty.Text.Trim), txtsupervisor.Text.Trim)
                tempprocessno = tempprocessno + 1
                SELECTCASE()
            End If

        End If

        TXTPASSWORD.Clear()
    End Sub

    Private Sub cmdproceed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdproceed.Click
        Try

            'CHECKING WHETHER PLATE IS ISSUED FOR PLATE PROCESS OR NOT
            'IF NOT THEN DONT ALLOW TO PROCEED FURTHER
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            If ClientName = "AMR" And lblprocess.Text = "PLATE" Then
                DT = OBJCMN.search("ISNULL(ISSUE_NO,0) AS ISSNUNO", "", " PLATEISSUE ", " AND ISSUE_BATCHNO = " & Val(TXTBATCHNO.Text.Trim) & " AND ISSUE_YEARID = " & YearId)
                If DT.Rows.Count = 0 Then
                    MsgBox("Plate Not Issued for This Batch, Please Issue Plate first", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If


            If (ClientName = "AMR" And tempprocessno > 9) Or (ClientName <> "AMR" And tempprocessno > 10) Then
                MessageBox.Show("Could Not Proceed, Job Completed")
            Else
                'CHECKING WHETHER PACKETS OR SHIPPER ARE GREATER THAN FOLDING'S BALANCE QTY OR NOT
                If (ClientName = "AMR" And tempprocessno = 8) Or (ClientName <> "AMR" And tempprocessno = 9) Then
                    If Val(txtptotal.Text) <> Val(gridjob.Rows(gridjob.RowCount - 1).Cells(Gbalancesheets.Index).Value) Then If MsgBox("Total Does Not Match with Folding Leaflets, there are " & Val(gridjob.Rows(gridjob.RowCount - 1).Cells(Gbalancesheets.Index).Value) & " Leaflets, With to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                End If


                ''IF WE HAVE CLICKED ON 2DCODE IN ITEMMASTER AND NOT ENTERED 2DCODE THEN DONT SAVE
                If ClientName = "AMR" And tempprocessname = "MACHINE FOLDING" Then
                    DT = OBJCMN.search("ISNULL(ITEM_2DCODE,0) AS [2DCODE]", "", " ITEMMASTER ", " AND ITEM_CODE = '" & TXTITEMCODE.Text.Trim & "' AND ITEM_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        If Convert.ToBoolean(DT.Rows(0).Item("2DCODE")) = True AndAlso (TXT2DCODESTART.Text.Trim = "" Or TXT2DCODEEND.Text.Trim = "") Then
                            MsgBox("Enter 2D-Codes", MsgBoxStyle.Critical)
                            Exit Sub
                        End If
                    End If
                End If


                'CHECK SUPERVISOR IS PRESENT OR NOT, SUPERVISOR IS MANDATE AND VALIDATE THE PASSWORD ALSO
                'IF SUPERVISOR OR PASSWORD FIELD IS BLANK THEN VALIDATE, DONT ALLOW TO PROCEED
                If txtsupervisor.Text.Trim = "" Then
                    'this is WRITTEN HERE SO THAT IF WE HAVE ENTERED THE DATA IN CONFIG WHILE RUNTIME THEN WE WILL GET THE NAME HERE ITSELF
                    GETSUPERVISORNAME()
                    MsgBox("Select Supervisor in Config First", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                If Not AUTHENTICATESUPERVISOR() Then
                    MsgBox("Incorrect Password", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                FILLGRID()
                GETSUPERVISORNAME()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function AUTHENTICATESUPERVISOR() As Boolean
        Try
            Dim BLN As Boolean = True

            Dim objCommon2 As New ClsCommonMaster
            Dim dttable2 As DataTable
            dttable2 = objCommon2.search(" ISNULL(SUP_NAME,''), ISNULL(SUP_PASSWORD,'') ", "", "SUPERVISORMaster", " and SUP_NAME = '" & txtsupervisor.Text.Trim & "' and SUP_YEARID = " & YearId)

            If dttable2.Rows.Count > 0 Then
                If TXTPASSWORD.Text <> dttable2.Rows(0).Item(1).ToString Then

                    BLN = False
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmdskip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdskip.Click
        If (ClientName = "AMR" And tempprocessno > 9) Or (ClientName <> "AMR" And tempprocessno > 10) Then
            MessageBox.Show("Could Not Proceed, Job Completed")
        Else
            'TEMPBALSHEET = Val(txtbalancesheets.Text)
            If tempprocessname = "PRINTED LEAFLET CUTTING" Then
                TEMPBALSHEET = Val(TXTCUTTINGSHEETGIVEN.Text) * Val(txtups.Text)
            End If
            tempprocessno = tempprocessno + 1
            SELECTCASE()
            GETSUPERVISORNAME()
        End If
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If lbllocked.Visible = True Then
                    MsgBox("Unable to Delete", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                TEMPMSG = MsgBox("Wish to Delete Batch?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    TEMPMSG = MsgBox("Are you Sure?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then

                        Dim ALPARAVAL As New ArrayList
                        ALPARAVAL.Add(TEMPBATCHNO)
                        ALPARAVAL.Add(tempprocessno)
                        ALPARAVAL.Add(YearId)
                        ALPARAVAL.Add(Userid)

                        Dim OBJJOB As New ClsBatch
                        OBJJOB.alParaval = ALPARAVAL
                        Dim INTRESULT As Integer = OBJJOB.delete()
                        MsgBox("Batch is Deleted")
                        CLEAR()
                        edit = False
                    End If
                Else
                    MsgBox("Delete is only in Edit Mode")
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

    Private Sub gridupload_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
        Try
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

    Private Sub gridupload_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If e.RowIndex >= 0 Then PBSOFTCOPY.Image = gridupload.Rows(e.RowIndex).Cells(GUIMGPATH.Index).Value
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtuploadname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuploadname.Validating
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

    Private Sub txtsupervisor_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtsupervisor.Validating
        'Try
        '    Dim TEMP As String = txtsupervisor.Text.Trim
        '    Dim TEMPVAR As String
        '    TEMPVAR = TEMP.Substring(2, txtsupervisor.Text.Trim.Length)
        '    txtpapermfg.Text = TEMPVAR
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            Dim OBJJOB As New BatchDetails
            OBJJOB.MdiParent = MDIMain
            OBJJOB.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLTOTAL()

        txttotalpacket.Text = Val(txtpacket1.Text) + Val(txtpacket2.Text) + Val(txtpacket3.Text)
        txtpackettotal1.Text = Val(txtpacketitem1.Text) * Val(txtpacket1.Text)
        txtpackettotal2.Text = Val(txtpacketitem2.Text) * Val(txtpacket2.Text)
        txtpackettotal3.Text = Val(txtpacketitem3.Text) * Val(txtpacket3.Text)
        txtptotal.Text = Val(txtpackettotal1.Text) + Val(txtpackettotal2.Text) + Val(txtpackettotal3.Text)

        txttotalshipper.Text = Val(txtshipper1.Text) + Val(txtshipper2.Text) + Val(txtshipper3.Text)
        txtshippertotal1.Text = Val(txtshipperitem1.Text) * Val(txtshipper1.Text)
        txtshippertotal2.Text = Val(txtshipperitem2.Text) * Val(txtshipper2.Text)
        txtshippertotal3.Text = Val(txtshipperitem3.Text) * Val(txtshipper3.Text)

        txtstotal.Text = Val(txtshippertotal1.Text) + Val(txtshippertotal2.Text) + Val(txtshippertotal3.Text)

    End Sub

    Sub TOTOLSHEET()
        txttotalsheets.Text = Format((Val(Val(txtqty.Text) * Val(TXTPERCENTAGE.Text)) / 100 + Val(txtqty.Text)) / Val(txtups.Text), "0")
    End Sub

    Private Sub txtqty_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtqty.Validating
        Try
            Dim OBJCMN As New ClsCommon
            Dim DTT As DataTable = OBJCMN.search(" ISNULL(JOBBATCHMASTER.job_qty, 0) AS QTY ", "", " JOBBATCHMASTER ", "AND JOBBATCHMASTER.JOB_NO = '" & TXTJOBDOCKETNO.Text.Trim & "' AND JOB_YEARID = " & YearId)
            If DTT.Rows.Count > 0 Then
                If Val(txtqty.Text.Trim) > Val(DTT.Rows(0).Item("QTY")) Then
                    MsgBox("Total Qty does not match with Order Qty?")
                    e.Cancel = True
                End If
            End If
            ' txttotalsheets.Text = Format((Val(Val(txtqty.Text) * Val(TXTPERCENTAGE.Text)) / 100 + Val(txtqty.Text)) / Val(txtups.Text), "0")
            TOTOLSHEET()
            txtsheetsgiven.Text = Val(txttotalsheets.Text)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub txtpacket1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpacket1.Validating
        Try
            If Val(txtpacketitem1.Text) > 0 And Val(txtpacket1.Text) > 0 Then
                txtpackettotal1.Text = Val(txtpacketitem1.Text) * Val(txtpacket1.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpacket2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpacket2.Validating
        Try
            If Val(txtpacketitem2.Text) <> "0" And Val(txtpacket2.Text) <> "0" Then
                txtpackettotal2.Text = Val(txtpacketitem2.Text) * Val(txtpacket2.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpacket3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpacket3.Validating
        Try
            If Val(txtpacketitem3.Text) <> "0" And Val(txtpacket3.Text) <> "0" Then
                txtpackettotal3.Text = Val(txtpacketitem3.Text) * Val(txtpacket3.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpacketitem1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpacketitem1.Validating
        Try
            If Val(txtpacketitem1.Text) <> "0" And Val(txtpacket1.Text) <> "0" Then
                txtpackettotal1.Text = Val(txtpacketitem1.Text) * Val(txtpacket1.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpacketitem2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpacketitem2.Validating
        Try
            If Val(txtpacketitem2.Text) <> "0" And Val(txtpacket2.Text) <> "0" Then
                txtpackettotal2.Text = Val(txtpacketitem2.Text) * Val(txtpacket2.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpacketitem3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpacketitem3.Validating
        Try
            If Val(txtpacketitem3.Text) <> "0" And Val(txtpacket3.Text) <> "0" Then
                txtpackettotal3.Text = Val(txtpacketitem3.Text) * Val(txtpacket3.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub txtshipperitem1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtshipperitem1.Validating
        Try
            If Val(txtshipperitem1.Text) <> "0" And Val(txtshipper1.Text) <> "0" Then
                txtshippertotal1.Text = Val(txtshipperitem1.Text) * Val(txtshipper1.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtshipperitem2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtshipperitem2.Validating
        Try
            If Val(txtshipperitem2.Text) <> "0" And Val(txtshipper2.Text) <> "0" Then
                txtshippertotal2.Text = Val(txtshipperitem2.Text) * Val(txtshipper2.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtshipperitem3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtshipperitem3.Validating
        Try
            If Val(txtshipperitem3.Text) <> "0" And Val(txtshipper3.Text) <> "0" Then
                txtshippertotal3.Text = Val(txtshipperitem3.Text) * Val(txtshipper3.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtshipper1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtshipper1.Validating
        Try
            If Val(txtshipperitem1.Text) <> "0" And Val(txtshipper1.Text) <> "0" Then
                txtshippertotal1.Text = Val(txtshipperitem1.Text) * Val(txtshipper1.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtshipper2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtshipper2.Validating
        Try
            If Val(txtshipperitem2.Text) <> "0" And Val(txtshipper2.Text) <> "0" Then
                txtshippertotal2.Text = Val(txtshipperitem2.Text) * Val(txtshipper2.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtshipper3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtshipper3.Validating
        Try
            If Val(txtshipperitem3.Text) <> "0" And Val(txtshipper3.Text) <> "0" Then
                txtshippertotal3.Text = Val(txtshipperitem3.Text) * Val(txtshipper3.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridjob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridjob.KeyDown
        If e.KeyCode = Keys.Delete Then
            If gridjob.CurrentRow.Index = gridjob.RowCount - 1 Then


                If ClientName = "AMR" Then
                    If gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "PLATE" Then
                        tempprocessno = 1
                    ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "PAPER SHEET CUTTING" Then
                        tempprocessno = 2
                    ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "PRINTING" Then
                        tempprocessno = 3
                        TEMPBALSHEET = Val(gridjob.CurrentRow.Cells(Gsheetsgiven.Index).Value)
                    ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "LEAFLET SORTING" Then
                        tempprocessno = 4
                        TEMPBALSHEET = Val(gridjob.CurrentRow.Cells(Gsheetsgiven.Index).Value)
                    ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "PRINTED LEAFLET CUTTING" Then
                        tempprocessno = 5
                        TEMPBALSHEET = Val(gridjob.CurrentRow.Cells(Gsheetsgiven.Index).Value)
                    ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "MACHINE FOLDING" Then
                        tempprocessno = 6
                        txtfoldingsheetsgiven.Text = Val(gridjob.CurrentRow.Cells(Gsheetsgiven.Index).Value)
                        TEMPBALSHEET = Val(gridjob.CurrentRow.Cells(Gsheetsgiven.Index).Value)
                    ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "UNFOLDING" Then
                        tempprocessno = 7
                        TXTUNFOLDSHEETGIVEN.Text = Val(gridjob.CurrentRow.Cells(GUNFOLDSHEETGIVEN.Index).Value)
                        TEMPBALSHEET = Val(TXTUNFOLDSHEETGIVEN.Text.Trim)
                    ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "PACKING" Then
                        tempprocessno = 8
                        TEMPBALSHEET = Val(txtstotal.Text)
                    ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = " FINAL" Then
                        tempprocessno = 9
                    End If
                Else
                    If gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "POSITIVE" Then
                        tempprocessno = 1
                    ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "PLATE" Then
                        tempprocessno = 2
                    ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "PAPER CUTTING" Then
                        tempprocessno = 3
                        'TEMPBALSHEET = Val(TXTCUTTINGSHEETGIVEN.Text.Trim)
                    ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "PRINTING" Then
                        tempprocessno = 4
                        'TEMPBALSHEET = Val(txtsheetsgiven.Text.Trim)
                    ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "FULL SHEET SORTING" Then
                        tempprocessno = 5
                        TEMPBALSHEET = Format(Val(TXTSORTSHEETSGIVEN.Text.Trim) / Val(txtups.Text), "0")
                    ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "FULL SHEET CUTTING" Then
                        tempprocessno = 6
                        TEMPBALSHEET = Format(Val(txtfoldingsheetsgiven.Text) / Val(txtups.Text), "0")
                    ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "LEAFLET SORTING" Then
                        tempprocessno = 7
                    ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "FOLDING" Then
                        tempprocessno = 8
                        txtfoldingsheetsgiven.Text = Val(txtstotal.Text)
                    ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "PACKING" Then
                        tempprocessno = 9
                        TEMPBALSHEET = Val(txtstotal.Text)
                    ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = " FINAL" Then
                        tempprocessno = 10
                    End If
                End If

                SELECTCASE()
                gridjob.Rows.RemoveAt(gridjob.CurrentRow.Index)
                FILLTOTAL()
                GETSUPERVISORNAME()
            Else
                MessageBox.Show("Only Last Process Can be Removed", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub txtfoldingbalancesheet_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtfoldingbalancesheet.Validating
        If Val(txtfoldingbalancesheet.Text) = "0" Then
            txtfoldingdestroyedsheets.Text = "0"
        Else
            If Val(txtfoldingbalancesheet.Text) <= Val(txtfoldingsheetsgiven.Text) Then
                txtfoldingdestroyedsheets.Text = Val(txtfoldingsheetsgiven.Text) - Val(txtfoldingbalancesheet.Text)
            Else
                MessageBox.Show("Invalid No. of Sheets")
                txtfoldingbalancesheet.Focus()
                e.Cancel = True
            End If

        End If
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call CMDDELETE_Click(sender, e)
    End Sub

    Private Sub TXTPERCENTAGE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPERCENTAGE.Validating
        TOTOLSHEET()
    End Sub

    Private Sub txtbalancesheets_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtbalancesheets.Validating
        If Val(txtbalancesheets.Text) = "0" Then
            txtdestroyedsheets.Text = "0"
        Else
            If Val(txtbalancesheets.Text) <= Val(txtsheetsgiven.Text) Then
                txtdestroyedsheets.Text = Val(txtsheetsgiven.Text) - Val(txtbalancesheets.Text)
            Else
                MessageBox.Show("Invalid No. of Sheets")
                txtbalancesheets.Focus()
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then PRINTREPORT(TEMPJOBNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal BATCH As Integer)
        Try
            TEMPMSG = MsgBox("Wish to Print Batch Docket?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJJOB As New DocketDesign
                OBJJOB.MdiParent = MDIMain
                OBJJOB.FRMSTRING = "BATCH"
                OBJJOB.WHERECLAUSE = "{BATCHMASTER.jobbatch_no}=" & Val(TEMPBATCHNO) & " AND {BATCHMASTER.jobbatch_yearid}=" & YearId

                Dim OBJCMNN As New ClsCommon
                Dim DDT1 As DataTable
                Dim DDT2 As DataTable
                Dim DDT3 As DataTable
                Dim DDT4 As DataTable

                For Each ROW As DataGridViewRow In gridjob.Rows
                    If ROW.Cells(Gprocess.Index).Value = "PAPER SHEET CUTTING" Then
                        DDT1 = OBJCMNN.search(" TOP(1) ISNULL(ITEMMASTER.item_code,'') AS ITEMCODE , ISNULL(ITEMMASTER.item_name,'') AS ITEMNAME ", "", " BATCHMASTER_DESC INNER JOIN BATCHMASTER ON BATCHMASTER_DESC.JOBBATCH_NO = BATCHMASTER.jobbatch_no AND BATCHMASTER_DESC.JOBBATCH_YEARID = BATCHMASTER.jobbatch_yearid LEFT OUTER JOIN ITEMMASTER ON BATCHMASTER.jobbatch_itemid = ITEMMASTER.item_id ", "AND BATCHMASTER_DESC.JOBBATCH_MACHINENO = '" & ROW.Cells(GMACHINENO.Index).Value & "' AND BATCHMASTER.jobbatch_no < " & TXTBATCHNO.Text.Trim & " AND BATCHMASTER_DESC.JOBBATCH_PROCESS = 'PAPER SHEET CUTTING'  AND BATCHMASTER.jobbatch_yearid = " & YearId & " ORDER BY BATCHMASTER.jobbatch_no DESC ")
                        If DDT1.Rows.Count > 0 Then
                            PAPERCUTTINGPREJOBNAME = DDT1.Rows(0).Item("ITEMCODE")
                            PAPERCUTTINGPREJOBCODE = DDT1.Rows(0).Item("ITEMNAME")
                        End If
                    ElseIf ROW.Cells(Gprocess.Index).Value = "PRINTING" Then
                        DDT2 = OBJCMNN.search(" TOP(1) ISNULL(ITEMMASTER.item_code,'') AS ITEMCODE , ISNULL(ITEMMASTER.item_name,'') AS ITEMNAME ", "", " BATCHMASTER_DESC INNER JOIN BATCHMASTER ON BATCHMASTER_DESC.JOBBATCH_NO = BATCHMASTER.jobbatch_no AND BATCHMASTER_DESC.JOBBATCH_YEARID = BATCHMASTER.jobbatch_yearid LEFT OUTER JOIN ITEMMASTER ON BATCHMASTER.jobbatch_itemid = ITEMMASTER.item_id ", "AND BATCHMASTER_DESC.JOBBATCH_MACHINENO = '" & ROW.Cells(GMACHINENO.Index).Value & "' AND BATCHMASTER.jobbatch_no < " & TXTBATCHNO.Text.Trim & " AND BATCHMASTER_DESC.JOBBATCH_PROCESS = 'PRINTING'  AND BATCHMASTER.jobbatch_yearid = " & YearId & " ORDER BY BATCHMASTER.jobbatch_no DESC ")
                        If DDT2.Rows.Count > 0 Then
                            PRINTINGPREJOBNAME = DDT2.Rows(0).Item("ITEMCODE")
                            PRINTINGPREJOBCODE = DDT2.Rows(0).Item("ITEMNAME")
                        End If
                    ElseIf ROW.Cells(Gprocess.Index).Value = "PRINTED LEAFLET CUTTING" Then
                        DDT3 = OBJCMNN.search(" TOP(1) ISNULL(ITEMMASTER.item_code,'') AS ITEMCODE , ISNULL(ITEMMASTER.item_name,'') AS ITEMNAME ", "", " BATCHMASTER_DESC INNER JOIN BATCHMASTER ON BATCHMASTER_DESC.JOBBATCH_NO = BATCHMASTER.jobbatch_no AND BATCHMASTER_DESC.JOBBATCH_YEARID = BATCHMASTER.jobbatch_yearid LEFT OUTER JOIN ITEMMASTER ON BATCHMASTER.jobbatch_itemid = ITEMMASTER.item_id ", "AND BATCHMASTER_DESC.JOBBATCH_MACHINENO = '" & ROW.Cells(GMACHINENO.Index).Value & "' AND BATCHMASTER.jobbatch_no < " & TXTBATCHNO.Text.Trim & " AND BATCHMASTER_DESC.JOBBATCH_PROCESS = 'PRINTED LEAFLET CUTTING'  AND BATCHMASTER.jobbatch_yearid = " & YearId & " ORDER BY BATCHMASTER.jobbatch_no DESC ")
                        If DDT3.Rows.Count > 0 Then
                            PRINTEDLEAFLETCUTTINGPREJOBNAME = DDT3.Rows(0).Item("ITEMCODE")
                            PRINTEDLEAFLETCUTTINGPREJOBCODE = DDT3.Rows(0).Item("ITEMNAME")
                        End If
                    ElseIf ROW.Cells(Gprocess.Index).Value = "MACHINE FOLDING" Then
                        DDT4 = OBJCMNN.search(" TOP(1) ISNULL(ITEMMASTER.item_code,'') AS ITEMCODE , ISNULL(ITEMMASTER.item_name,'') AS ITEMNAME ", "", " BATCHMASTER_DESC INNER JOIN BATCHMASTER ON BATCHMASTER_DESC.JOBBATCH_NO = BATCHMASTER.jobbatch_no AND BATCHMASTER_DESC.JOBBATCH_YEARID = BATCHMASTER.jobbatch_yearid LEFT OUTER JOIN ITEMMASTER ON BATCHMASTER.jobbatch_itemid = ITEMMASTER.item_id ", "AND BATCHMASTER_DESC.JOBBATCH_MACHINENO = '" & ROW.Cells(GMACHINENO.Index).Value & "' AND BATCHMASTER.jobbatch_no < " & TXTBATCHNO.Text.Trim & " AND BATCHMASTER_DESC.JOBBATCH_PROCESS = 'MACHINE FOLDING'  AND BATCHMASTER.jobbatch_yearid = " & YearId & " ORDER BY BATCHMASTER.jobbatch_no DESC ")
                        If DDT4.Rows.Count > 0 Then
                            FOLDINGPREJOBNAME = DDT4.Rows(0).Item("ITEMCODE")
                            FOLDINGPREJOBCODE = DDT4.Rows(0).Item("ITEMNAME")
                        End If
                    End If
                Next
                OBJJOB.PREJOBNAME = TXTPREITEMNAME.Text.Trim
                OBJJOB.PREJOBCODE = TXTPREITEMCODE.Text.Trim

                OBJJOB.PAPERCUTTINGPREJOBNAME = PAPERCUTTINGPREJOBNAME
                OBJJOB.PAPERCUTTINGPREJOBCODE = PAPERCUTTINGPREJOBCODE

                OBJJOB.PRINTINGPREJOBNAME = PRINTINGPREJOBNAME
                OBJJOB.PRINTINGPREJOBCODE = PRINTINGPREJOBCODE


                OBJJOB.PRINTEDLEAFLETCUTTINGPREJOBNAME = PRINTEDLEAFLETCUTTINGPREJOBNAME
                OBJJOB.PRINTEDLEAFLETCUTTINGPREJOBCODE = PRINTEDLEAFLETCUTTINGPREJOBCODE


                OBJJOB.FOLDINGPREJOBNAME = FOLDINGPREJOBNAME
                OBJJOB.FOLDINGPREJOBCODE = FOLDINGPREJOBCODE



                'TRANSFER ALL COLUMN IN PRINT FORMAT
                If ClientName = "AMR" Then
                    For Each ROW As DataGridViewRow In gridjob.Rows
                        If ROW.Cells(Gprocess.Index).Value = "PAPER SHEET CUTTING" Then
                            OBJJOB.CUTTINGGRN = ROW.Cells(GPAPERGRNNO.Index).Value
                            OBJJOB.CUTTINGMACHINENO = ROW.Cells(GMACHINENO.Index).Value
                            OBJJOB.CUTTINGBINDERNAME = ROW.Cells(Gprintingname.Index).Value
                            OBJJOB.CUTTINGPAPERTYPE = ROW.Cells(GPAPERTYPE.Index).Value
                            OBJJOB.CUTTINGSHEETSRECD = ROW.Cells(Gbalancesheets.Index).Value
                            If HIDEAUDITREMARKS = False Then OBJJOB.CUTTINGREMARKS = ROW.Cells(GPAPERREMARKS.Index).Value
                            OBJJOB.CUTTINGSUPERVISOR = ROW.Cells(GSupervisor.Index).Value
                            OBJJOB.CUTTINGDATE = ROW.Cells(Ggivendate1.Index).Value
                            OBJJOB.CUTTINGGSM = ROW.Cells(GPAPERGSMQC.Index).Value
                            OBJJOB.CUTTINGQUALITY = ROW.Cells(GPAPERQUALITYQC.Index).Value

                        End If

                        If ROW.Cells(Gprocess.Index).Value = "PRINTING" Then
                            OBJJOB.PRINTINGMACHINENO = ROW.Cells(GMACHINENO.Index).Value
                            OBJJOB.PRINTINGNAME = ROW.Cells(Gprintingname.Index).Value
                            OBJJOB.PRINTINGCOLOR = ROW.Cells(Gpcolor.Index).Value
                            OBJJOB.PRINTINGSHEETSGIVEN = ROW.Cells(Gsheetsgiven.Index).Value
                            OBJJOB.PRINTINGSHEETSDESTROYED = ROW.Cells(Gsheetsdestroyed.Index).Value
                            OBJJOB.PRINTINGSHEETSFINAL = ROW.Cells(Gbalancesheets.Index).Value
                            OBJJOB.PRINTINGSHADEAPPBY = ROW.Cells(GAPPSHADECARDREMOVED.Index).Value
                            OBJJOB.PRINTINGSUPERVISOR = ROW.Cells(GSupervisor.Index).Value
                            OBJJOB.PRINTINGDATE = ROW.Cells(Greturneddate.Index).Value
                            If HIDEAUDITREMARKS = False Then OBJJOB.PRINTINGREMARKS = ROW.Cells(GPRINTREMARKS.Index).Value
                            OBJJOB.PRINTINGINTIME = ROW.Cells(GPRINTINTIME.Index).Value
                            OBJJOB.PRINTINGPLATETYPE = ROW.Cells(GPRINTTYPE.Index).Value
                            OBJJOB.PRINTINGVARNISH = ROW.Cells(GPRINTVARNISH.Index).Value
                            OBJJOB.PRINTINGPERFORATION = ROW.Cells(GPRINTPERFORATION.Index).Value
                            OBJJOB.PRINTINGSIZE = ROW.Cells(GPRINTSIZE.Index).Value
                            OBJJOB.PRINTINGTEXT = ROW.Cells(GPRINTTEXTMATTER.Index).Value
                            OBJJOB.PRINTINGSHADE = ROW.Cells(GPRINTCOLOR.Index).Value
                            OBJJOB.PRINTINGJOBREG = ROW.Cells(GPRINTJOBREG.Index).Value
                        End If

                        If ROW.Cells(Gprocess.Index).Value = "LEAFLET SORTING" Then
                            OBJJOB.SORTINGTABLENO = ROW.Cells(GMACHINENO.Index).Value
                            OBJJOB.SORTINGNAME = ROW.Cells(Gprintingname.Index).Value
                            OBJJOB.SORTINGSHEETSGIVEN = ROW.Cells(Gsheetsgiven.Index).Value
                            OBJJOB.SORTINGSHEETSDESTROYED = ROW.Cells(Gsheetsdestroyed.Index).Value
                            OBJJOB.SORTINGSHEETSFINAL = ROW.Cells(Gbalancesheets.Index).Value
                            OBJJOB.SORTINGSUPERVISOR = ROW.Cells(GSupervisor.Index).Value
                            OBJJOB.SORTINGDATE = ROW.Cells(Greturneddate.Index).Value
                            If HIDEAUDITREMARKS = False Then OBJJOB.SORTINGREMARKS = ROW.Cells(GSORTREMARKS.Index).Value
                        End If

                        If ROW.Cells(Gprocess.Index).Value = "PRINTED LEAFLET CUTTING" Then
                            OBJJOB.LEAFLETCUTMACHINENO = ROW.Cells(GMACHINENO.Index).Value
                            OBJJOB.LEAFLETCUTNAME = ROW.Cells(Gprintingname.Index).Value
                            OBJJOB.LEAFLETCUTSHEETSGIVEN = ROW.Cells(Gsheetsgiven.Index).Value
                            OBJJOB.LEAFLETCUTSHEETSDESTROYED = ROW.Cells(Gsheetsdestroyed.Index).Value
                            OBJJOB.LEAFLETCUTSHEETSFINAL = ROW.Cells(Gbalancesheets.Index).Value
                            OBJJOB.LEAFLETCUTSUPERVISOR = ROW.Cells(GSupervisor.Index).Value
                            OBJJOB.LEAFLETCUTDATE = ROW.Cells(Ggivendate1.Index).Value
                            If HIDEAUDITREMARKS = False Then OBJJOB.LEAFLETCUTREMARKS = ROW.Cells(GPAPERREMARKS.Index).Value
                        End If

                        If ROW.Cells(Gprocess.Index).Value = "MACHINE FOLDING" Then
                            OBJJOB.FOLDMACHINENO = ROW.Cells(GMACHINENO.Index).Value
                            OBJJOB.FOLDNAME = ROW.Cells(Gprintingname.Index).Value
                            OBJJOB.FOLDLEAFLETFEEDINGBY = ROW.Cells(GMACHINEPTFCLR.Index).Value
                            OBJJOB.FOLDBUNDLEDBY = ROW.Cells(GFOLDBUNDLEDBY.Index).Value
                            OBJJOB.FOLDPACKEDBY = ROW.Cells(GFOLDPACKEDBY.Index).Value
                            OBJJOB.FOLDLABELLEDBY = ROW.Cells(GFOLDLABELLEDBY.Index).Value
                            OBJJOB.FOLDSAMPLEAPPBY = ROW.Cells(Gsample.Index).Value
                            OBJJOB.FOLDV = ROW.Cells(G1STKNIFEAREACLR.Index).Value
                            OBJJOB.FOLDH = ROW.Cells(G2NDKNIFEAREACLR.Index).Value
                            OBJJOB.FOLDSHEETSGIVEN = ROW.Cells(Gsheetsgiven.Index).Value
                            OBJJOB.FOLDSHEETSDESTROYED = ROW.Cells(Gsheetsdestroyed.Index).Value
                            OBJJOB.FOLDSHEETSFINAL = ROW.Cells(Gbalancesheets.Index).Value
                            OBJJOB.FOLDSUPERVISOR = ROW.Cells(GSupervisor.Index).Value
                            OBJJOB.FOLDDATE = ROW.Cells(Greturneddate.Index).Value
                            If HIDEAUDITREMARKS = False Then OBJJOB.FOLDREMARKS = ROW.Cells(GFOLDREMARKS.Index).Value
                            OBJJOB.FOLD2DCODESTART = TXT2DCODESTART.Text.Trim
                            OBJJOB.FOLD2DCODEEND = TXT2DCODEEND.Text.Trim
                        End If


                        If ROW.Cells(Gprocess.Index).Value = "UNFOLDING" Then
                            OBJJOB.UNFOLDTABLENO = ROW.Cells(GMACHINENO.Index).Value
                            OBJJOB.UNFOLDSORTBY = ROW.Cells(GUNFOLDSORTINGBY.Index).Value
                            OBJJOB.UNFOLDCOUNTING = ROW.Cells(GUNFOLDCOUNTING.Index).Value
                            OBJJOB.UNFOLDPACKEDBY = ROW.Cells(GUNFOLDPACKETBY.Index).Value
                            OBJJOB.UNFOLDLABELLEDBY = ROW.Cells(GUNFOLDLABELLEDBY.Index).Value
                            OBJJOB.UNFOLDSAMPLEAPPBY = ROW.Cells(GUNFOLDSAMPLEAPPBY.Index).Value
                            OBJJOB.UNFOLDSHEETSGIVEN = ROW.Cells(Gsheetsgiven.Index).Value
                            OBJJOB.UNFOLDSHEETSDESTROYED = ROW.Cells(Gsheetsdestroyed.Index).Value
                            OBJJOB.UNFOLDSHEETSFINAL = ROW.Cells(Gbalancesheets.Index).Value
                            OBJJOB.UNFOLDSUPERVISOR = ROW.Cells(GSupervisor.Index).Value
                            OBJJOB.UNFOLDDATE = ROW.Cells(GUNFOLDGIVENDATE.Index).Value
                            If HIDEAUDITREMARKS = False Then OBJJOB.UNFOLDREMARKS = ROW.Cells(GUNFOLDREMARKS.Index).Value
                        End If


                        If ROW.Cells(Gprocess.Index).Value = "PACKING" Then
                            OBJJOB.PACKINGPACKBY = ROW.Cells(Gprintingname.Index).Value
                            OBJJOB.PACKINGCHECKBY = ROW.Cells(Gpacketsize.Index).Value
                            OBJJOB.PACKINGSUPERVISOR = ROW.Cells(GSupervisor.Index).Value
                        End If


                    Next
                End If

                OBJJOB.Show()
            End If

            If ClientName <> "AMR" Then
                TEMPMSG = MsgBox("Wish to Print Line Clearance Report?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim OBJJOB As New DocketDesign
                    OBJJOB.MdiParent = MDIMain
                    OBJJOB.FRMSTRING = "LINECLEARANCE"
                    OBJJOB.WHERECLAUSE = "{BATCHMASTER.jobbatch_no}=" & Val(TEMPBATCHNO) & " AND {BATCHMASTER.jobbatch_yearid}=" & YearId
                    OBJJOB.Show()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCUTBALANCESSHEETS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCUTBALANCESSHEETS.Validating
        If Val(TXTCUTBALANCESSHEETS.Text) = "0" Then
            TXTCUTDESTROYEDSHEETS.Text = "0"
        Else
            If (ClientName = "AMR" And tempprocessno = 5) Or (ClientName <> "AMR" And tempprocessno = 6) Then
                If Val(TXTCUTBALANCESSHEETS.Text) <= (Val(TXTCUTTINGSHEETGIVEN.Text) * Val(txtups.Text)) Then
                    TXTCUTDESTROYEDSHEETS.Text = (Val(TXTCUTTINGSHEETGIVEN.Text) * Val(txtups.Text)) - Val(TXTCUTBALANCESSHEETS.Text)
                Else
                    MessageBox.Show("Invalid No. of Sheets")
                    txtbalancesheets.Focus()
                    e.Cancel = True
                End If
            Else
                If Val(TXTCUTBALANCESSHEETS.Text) <= Val(TXTCUTTINGSHEETGIVEN.Text) Then
                    TXTCUTDESTROYEDSHEETS.Text = Val(TXTCUTTINGSHEETGIVEN.Text) - Val(TXTCUTBALANCESSHEETS.Text)
                Else
                    MessageBox.Show("Invalid No. of Sheets")
                    TXTCUTBALANCESSHEETS.Focus()
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub TXTSORTBALANCESHEETS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTSORTBALANCESHEETS.Validating
        If Val(TXTSORTBALANCESHEETS.Text) = "0" Then
            TXTSORTDESTROYESHEETS.Text = "0"
        Else
            If Val(TXTSORTBALANCESHEETS.Text) <= Val(TXTSORTSHEETSGIVEN.Text) Then
                TXTSORTDESTROYESHEETS.Text = Val(TXTSORTSHEETSGIVEN.Text) - Val(TXTSORTBALANCESHEETS.Text)
            Else
                MessageBox.Show("Invalid No. of Sheets")
                TXTSORTBALANCESHEETS.Focus()
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub txttotalsheets_Validated(sender As Object, e As EventArgs) Handles txttotalsheets.Validated
        TXTPERCENTAGE.Text = Format(((Val(txttotalsheets.Text.Trim) * Val(txtups.Text.Trim)) - Val(txtqty.Text.Trim)) / Val(txtqty.Text.Trim) * 100, "0.00")
    End Sub

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        Try
            Batch_Load(sender, e)
            TOTOLSHEET()
            txttotalsheets_Validated(sender, e)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub TXTSORTBALANCESHEETS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTSORTBALANCESHEETS.KeyPress
        numkeypress(e, TXTSORTBALANCESHEETS, Me)
    End Sub

    Private Sub TXTCUTBALANCESSHEETS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCUTBALANCESSHEETS.KeyPress
        numkeypress(e, TXTCUTBALANCESSHEETS, Me)
    End Sub

    Private Sub txtbalancesheets_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbalancesheets.KeyPress
        numkeypress(e, txtbalancesheets, Me)
    End Sub

    Private Sub TXTBATCHNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBATCHNO.Validating
        Try
            If Val(TXTBATCHNO.Text.Trim) > 0 And edit = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(BATCHMASTER. jobbatch_no,0)  AS BATCHNO", "", " BATCHMASTER ", "  AND BATCHMASTER.jobbatch_NO=" & TXTBATCHNO.Text.Trim & " AND BATCHMASTER.jobbatch_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Batch No Already Exist")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBATCHNO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBATCHNO.KeyPress
        numkeypress(e, TXTBATCHNO, Me)
    End Sub

    Private Sub Batch_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try
            txtsupervisor.BackColor = Color.LemonChiffon
            txtsupervisor.ReadOnly = True
            LBLPASSWORD.Visible = True
            TXTPASSWORD.Visible = True

            If ClientName = "AMR" Then
                Gsrno.Visible = False
                Gpcolor.Visible = False
                Gplatecheckedby.Visible = False
                Gcodecheckedby.Visible = False
                Gupscheckedby.Visible = False
                GCorrectionappby.Visible = False
                LBLPAPERMFG.Text = "QC Name"
                TXTCUTMACHINENO.BackColor = Color.LemonChiffon
                TXTFOLDMACHINENO.BackColor = Color.LemonChiffon
                TXTPRINTMACHINENO.BackColor = Color.LemonChiffon


            End If


            If HIDEAUDITREMARKS = True Then
                LBLCUTPAPERREMARKS.Visible = False
                TXTCUTPAPERREMARKS.Visible = False
                GPAPERREMARKS.Visible = False
                LBLFOLDREMARKS.Visible = False
                TXTFOLDREMARKS.Visible = False
                GFOLDREMARKS.Visible = False
                LBLPLATEREMARKS.Visible = False
                TXTPLATEREMARKS.Visible = False
                GPLATEREMARKS.Visible = False
                LBLPRINTREMARKS.Visible = False
                TXTPRINTREMARKS.Visible = False
                GPRINTREMARKS.Visible = False
                LBLSORTREMARKS.Visible = False
                TXTSORTREMARKS.Visible = False
                GSORTREMARKS.Visible = False
                LBLUNFOLDREMARKS.Visible = False
                TXTUNFOLDREMARKS.Visible = False
                GUNFOLDREMARKS.Visible = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTUNFOLDBALANCESHEET_Validating(sender As Object, e As CancelEventArgs) Handles TXTUNFOLDBALANCESHEET.Validating
        If Val(TXTUNFOLDBALANCESHEET.Text) = "0" Then
            TXTUNFOLDDESTROYEDSHEET.Text = "0"
        Else
            If Val(TXTUNFOLDBALANCESHEET.Text) <= Val(TXTUNFOLDSHEETGIVEN.Text) Then
                TXTUNFOLDDESTROYEDSHEET.Text = Val(TXTUNFOLDSHEETGIVEN.Text) - Val(TXTUNFOLDBALANCESHEET.Text)
            Else
                MessageBox.Show("Invalid No. of Sheets")
                TXTUNFOLDBALANCESHEET.Focus()
                e.Cancel = True
            End If

        End If
    End Sub

    Private Sub TXTFOLDSHIFT1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTFOLDSHIFT1.KeyPress, TXTFOLDSHIFT2.KeyPress, TXTFOLDSHIFT3.KeyPress, TXTPRINTINGSHIFT1.KeyPress, TXTPRINTINGSHIFT2.KeyPress, TXTPRINTINGSHIFT3.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub
End Class