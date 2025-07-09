Imports BL
Imports System.Windows.Forms
Imports System.IO

Public Class JobDocket

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public TEMPJOBNO, tempprocessno, TEMPBALSHEET, TEMPMSG As Integer
    Public tempprocessname As String
    Public edit As Boolean
    Dim TEMPUPLOADROW As Integer
    Dim gridUPLOADDoubleClick As Boolean

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        jobdate.Focus()
        edit = False
    End Sub

    Sub CLEAR()

        jobdate.Value = Mydate
        txtpono.Clear()
        txtorderno.Clear()
        TXTORDERGSRNO.Clear()
        txtpartyname.Clear()
        txtitemcode.Clear()
        txtitemname.Clear()
        txtfileno.Clear()
        txtqty.Clear()
        txtups.Clear()
        tstxtbillno.Clear()
        CMDSELECTORDER.Enabled = True
        txtpono.Enabled = True
        txtleafletsize.Clear()
        txtfoldingsize.Clear()
        txtpapersize.Clear()
        txtcutsize.Clear()
        txtshadecard.Clear()
        txtmaterial.Clear()
        txtdesign.Clear()
        txtgsm.Clear()
        txtgrain.Clear()
        txttotalsheets.Clear()

        txtsupervisor.Clear()
        txtpapermfg.Clear()
        txtgrade.Clear()
        txttestval.Clear()
        txtmaterialcode.Clear()

        gridjob.RowCount = 0
        tempprocessno = 1
        Selectcase()
        gridUPLOADDoubleClick = False

        TXTUPLOADSRNO.Text = 1
        txtuploadremarks.Clear()
        txtuploadname.Clear()
        PBSOFTCOPY.Image = Nothing
        TXTIMGPATH.Clear()
        gridupload.RowCount = 0

        TabControl1.SelectedIndex = 0
        TXTPERCENTAGE.Text = 10

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
        madedate.Value = Mydate
        txtplatedestroyedby.Clear()
        destroyeddate.Value = Mydate
        txtplateremadeby.Clear()
        remadedate.Value = Mydate

        ''PROCESS PRINTING
        txtname.Clear()
        txtsheetsgiven.Clear()
        givendate.Value = Mydate
        txtbalancesheets.Clear()
        balancedate.Value = Mydate
        txtdestroyedsheets.Clear()

        ''PROCESS FOLDING
        txtcleanedby.Clear()
        txtfoldingname.Clear()
        txtfoldingsheetsgiven.Clear()
        foldinggivendate.Value = Mydate
        txtfoldingv.Clear()
        txtfoldingh.Clear()
        txtsampleappby.Clear()
        txtfoldingbalancesheet.Clear()
        foldingbalancedate.Value = Mydate
        txtfoldingdestroyedsheets.Clear()


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

        GROUPPOSITIVE.Visible = True
        GROUPFINAL.Visible = False
        GROUPFOLDING.Visible = False
        GROUPPACKING.Visible = False
        GROUPPRINT.Visible = False
        GROUPPLATE.Visible = False
        GROUPFINAL.Visible = False
        lbllocked.Visible = False
        PBlock.Visible = False
        getmax_job_no()
        Ep.Clear()


    End Sub

    Sub getmax_job_no()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax("isnull(max(JOB_NO),0) + 1", "JOBMASTER", " AND JOB_YEARID = " & YearId)
        If DTTABLE.Rows.Count > 0 Then
            txtjobdocketno.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub JobDocket_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
                If edit = True Then Call PRINTREPORT(TEMPJOBNO)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JobDocket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DTROW() As DataRow
        DTROW = USERRIGHTS.Select("FormName = 'JOB DOCKET'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        Cursor.Current = Cursors.WaitCursor

        CLEAR()

        If edit = True Then

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJJOB As New ClsJobDocket
            Dim DTTABLE1 As DataTable = OBJJOB.selectNO(TEMPJOBNO, YearId)

            If DTTABLE1.Rows.Count > 0 Then
                For Each DR As DataRow In DTTABLE1.Rows

                    txtjobdocketno.Text = TEMPJOBNO
                    txtorderno.Text = Convert.ToString(DR("ORDERNO"))
                    TXTORDERGSRNO.Text = Convert.ToString(DR("ORDERSRNO"))
                    txtpartyname.Text = Convert.ToString(DR("PARTYNAME"))
                    txtpono.Text = Convert.ToString(DR("PONO"))
                    jobdate.Text = Convert.ToString(DR("DATE"))
                    txtitemcode.Text = Convert.ToString(DR("ITEMCODE"))
                    txtfileno.Text = Convert.ToString(DR("FILENO"))
                    txtitemname.Text = Convert.ToString(DR("ITEMNAME"))
                    txtgsm.Text = Convert.ToString(DR("PPRGSM"))
                    txtmaterial.Text = Convert.ToString(DR("MATERIAL"))
                    txtpapersize.Text = Convert.ToString(DR("PPRSIZE"))
                    txtdesign.Text = Convert.ToString(DR("DESIGN"))
                    txtqty.Text = Format(Val(DR("QTY")), "0")
                    txtshadecard.Text = Convert.ToString(DR("SHADECARD"))
                    txtleafletsize.Text = Convert.ToString(DR("LEAFLETSIZE"))
                    txtfoldingsize.Text = Convert.ToString(DR("FOLDINGSIZE"))
                    txtcutsize.Text = Convert.ToString(DR("CUTSIZE"))
                    txtups.Text = Convert.ToString(DR("UPS"))
                    txtpapermfg.Text = Convert.ToString(DR("PPRMFG"))
                    txtgrade.Text = Convert.ToString(DR("GRADE"))
                    txttestval.Text = Convert.ToString(DR("TESTVALUE"))
                    txttotalsheets.Text = Convert.ToString(DR("TOTALSHEETS"))
                    txtsheetsgiven.Text = Convert.ToString(DR("TOTALSHEETS"))
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


                    If Convert.ToBoolean(DR("DONE")) = True Then
                        lbllocked.Visible = True
                        PBlock.Visible = True
                    End If
                    TXTPERCENTAGE.Text = Convert.ToString(DR("PERCENTAGE"))

                    ''GRID VALUES
                    gridjob.Rows.Add(DR("PROCESS").ToString, DR("SRNO"), DR("COLOR"), DR("PLATECHKBY").ToString, DR("CODECHKBY").ToString, DR("UPSCHKBY").ToString, DR("CORRAPLYBY").ToString, DR("PLATEMADEBY").ToString, DR("MADEDATE").ToString, DR("PLATEDESTROY").ToString, DR("DESTROYDATE").ToString, DR("PLATEREMADE").ToString, DR("REMADEDATE").ToString, DR("NAME").ToString, DR("SHEETSGIVEN"), DR("GIVENDATE").ToString, DR("BALSHEETS"), DR("RETURNDATE").ToString, DR("SHEETSDESTROY"), DR("MACHINCLNBY").ToString, DR("SAMPLE").ToString, DR("TOTALPACKETS"), DR("TOTALSHIPEERS"), DR("PACKETSIZE"), Val(DR("SHORTQTY")), DR("SUPERVISOR").ToString)
                    tempprocessno = tempprocessno + 1
                    'FILLGRID()
                    CMDSELECTORDER.Enabled = False
                    txtpono.Enabled = False
                Next
                'FILLGRID()
                FILLTOTAL()
                Selectcase()
                gridjob.FirstDisplayedScrollingRowIndex = gridjob.RowCount - 1

                '' GRID UPLOAD
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(JOB_UPSRNO, 0) AS SRNO, ISNULL(JOB_UPREMARKS, '') AS REMARKS, ISNULL(JOB_UPNAME, '') AS NAME, JOB_IMGPATH AS IMGPATH", "", "JOBMASTER_UPLOAD", "AND JOBMASTER_UPLOAD.JOB_NO= " & TEMPJOBNO & "  AND JOB_YEARID = " & YearId & " ORDER BY JOBMASTER_UPLOAD.JOB_UPSRNO")
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

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Dim IntResult As Integer
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim ALPARAVAL As New ArrayList
            'ALPARAVAL.Add(txtjobdocketno.Text.Trim)
            ALPARAVAL.Add(Val(txtorderno.Text.Trim))
            ALPARAVAL.Add(Val(TXTORDERGSRNO.Text.Trim))
            ALPARAVAL.Add(txtpartyname.Text.Trim)
            ALPARAVAL.Add(txtpono.Text.Trim)
            ALPARAVAL.Add(jobdate.Value.Date)

            ALPARAVAL.Add(txtitemcode.Text.Trim)
            ALPARAVAL.Add(Val(txtqty.Text.Trim))
            ALPARAVAL.Add(Val(TXTPERCENTAGE.Text.Trim))
            ALPARAVAL.Add(txtshadecard.Text.Trim)
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
            If chkdone.CheckState = True Then
                ALPARAVAL.Add(1)
            Else
                ALPARAVAL.Add(0)
            End If

            ALPARAVAL.Add(txtfoldingv.Text.Trim)
            ALPARAVAL.Add(txtfoldingh.Text.Trim)
            ALPARAVAL.Add(txtshortqty.Text.Trim)

            ALPARAVAL.Add(txtpapermfg.Text.Trim)
            ALPARAVAL.Add(txtgrade.Text.Trim)
            ALPARAVAL.Add(txttestval.Text.Trim)

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)
            ALPARAVAL.Add(0)

            ''GRID PARAMETERS
            Dim PROCESS As String = ""
            Dim SRNO As String = ""
            Dim COLOR As String = ""
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
            Dim NAME As String = ""
            Dim SHEETSGIVEN As String = ""
            Dim GIVENDATE As String = ""
            Dim BALSHEETS As String = ""
            Dim RETURNDATE As String = ""
            Dim SHEETSDESTROY As String = ""
            Dim CLEANBY As String = ""
            Dim SAMPLEAPPBY As String = ""
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
                        NAME = ROW.Cells(Gprintingname.Index).Value.ToString
                        SHEETSGIVEN = ROW.Cells(Gsheetsgiven.Index).Value.ToString
                        GIVENDATE = ROW.Cells(Ggivendate1.Index).Value.ToString
                        BALSHEETS = ROW.Cells(Gbalancesheets.Index).Value.ToString
                        RETURNDATE = ROW.Cells(Greturneddate.Index).Value.ToString
                        SHEETSDESTROY = ROW.Cells(Gsheetsdestroyed.Index).Value.ToString
                        CLEANBY = ROW.Cells(GMachinecleanedby.Index).Value.ToString
                        SAMPLEAPPBY = ROW.Cells(Gsample.Index).Value.ToString
                        TOTALPACKETS = ROW.Cells(Gtotalpackets.Index).Value.ToString
                        TOTALSHIPPERS = ROW.Cells(Gtotalshippers.Index).Value.ToString
                        PACKETSIZE = ROW.Cells(Gpacketsize.Index).Value.ToString
                        SHORTQTY = Val(ROW.Cells(Gshortqty.Index).Value).ToString
                        SUPERVISOR = ROW.Cells(GSupervisor.Index).Value.ToString
                    Else
                        PROCESS = PROCESS & "|" & ROW.Cells(Gprocess.Index).Value.ToString
                        SRNO = SRNO & "|" & ROW.Cells(Gsrno.Index).Value.ToString
                        COLOR = COLOR & "|" & ROW.Cells(Gpcolor.Index).Value.ToString
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
                        NAME = NAME & "|" & ROW.Cells(Gprintingname.Index).Value.ToString
                        SHEETSGIVEN = SHEETSGIVEN & "|" & ROW.Cells(Gsheetsgiven.Index).Value.ToString
                        GIVENDATE = GIVENDATE & "|" & ROW.Cells(Ggivendate1.Index).Value.ToString
                        BALSHEETS = BALSHEETS & "|" & ROW.Cells(Gbalancesheets.Index).Value.ToString
                        RETURNDATE = RETURNDATE & "|" & ROW.Cells(Greturneddate.Index).Value.ToString
                        SHEETSDESTROY = SHEETSDESTROY & "|" & ROW.Cells(Gsheetsdestroyed.Index).Value.ToString
                        CLEANBY = CLEANBY & "|" & ROW.Cells(GMachinecleanedby.Index).Value.ToString
                        SAMPLEAPPBY = SAMPLEAPPBY & "|" & ROW.Cells(Gsample.Index).Value.ToString
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
            ALPARAVAL.Add(NAME)
            ALPARAVAL.Add(SHEETSGIVEN)
            ALPARAVAL.Add(GIVENDATE)
            ALPARAVAL.Add(BALSHEETS)
            ALPARAVAL.Add(RETURNDATE)
            ALPARAVAL.Add(SHEETSDESTROY)
            ALPARAVAL.Add(CLEANBY)
            ALPARAVAL.Add(SAMPLEAPPBY)
            ALPARAVAL.Add(TOTALPACKETS)
            ALPARAVAL.Add(TOTALSHIPPERS)
            ALPARAVAL.Add(PACKETSIZE)
            ALPARAVAL.Add(SHORTQTY)
            ALPARAVAL.Add(SUPERVISOR)

            Dim objjob As New ClsJobDocket
            objjob.alparaval = ALPARAVAL

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dttable As DataTable = objjob.save()
                TEMPJOBNO = dttable.Rows(0).Item(0)
                MessageBox.Show("Deatils Added !!")
                PRINTREPORT(dttable.Rows(0).Item(0))
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                ALPARAVAL.Add(TEMPJOBNO)
                IntResult = objjob.UPDATE()
                MessageBox.Show("Details Updated!!")
                PRINTREPORT(TEMPJOBNO)
                edit = False
            End If

            If gridupload.RowCount > 0 Then SAVEUPLOAD()
            CLEAR()
            'txtjobdocketno.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SAVEUPLOAD()
        Try
            Dim OBJJOB As New ClsJobDocket

            For Each ROW As Windows.Forms.DataGridViewRow In gridupload.Rows
                If ROW.Cells(GUSRNO.Index).Value <> Nothing Then
                    Dim MS As New IO.MemoryStream
                    Dim ALPARAVAL As New ArrayList
                    ALPARAVAL.Add(TEMPJOBNO)
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

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If txtpono.Text.Trim.Length = 0 Then
            Ep.SetError(txtpono, "Select Order for Docket")
            bln = False
        End If

        If gridjob.RowCount = 0 Then
            Ep.SetError(gridjob, "Please fill atleast one Process")
            bln = False
        End If


        If lbllocked.Visible = True Then
            Ep.SetError(lbllocked, "Rec/Return Made , Delete Rec/Return First")
            bln = False
        End If

        If Not datecheck(jobdate.Value) Then
            Ep.SetError(jobdate, "Date Not in Current Accounting Year")
            bln = False
        End If

        'If Val(txtorderno.Text.Trim) > 0 And Val(TXTORDERGSRNO.Text.Trim) > 0 And edit = False Then
        '    Dim OBJCMN As New ClsCommon
        '    Dim dttable As DataTable = OBJCMN.search(" JOB_NO AS JOBNO ", "", " JOBMASTER ", "   AND JOB_ORDERNO=" & Val(txtorderno.Text.Trim) & " AND JOB_ORDERSRNO = " & Val(TXTORDERGSRNO.Text.Trim) & " AND JOB_YEARID = " & YearId)
        '    If dttable.Rows.Count > 0 Then
        '        Ep.SetError(txtpono, "Order No Already Exist")
        '        bln = False
        '    End If
        'End If

        Return bln
    End Function

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                gridjob.RowCount = 0
                TEMPJOBNO = Val(tstxtbillno.Text)
                If TEMPJOBNO > 0 Then
                    edit = True
                    JobDocket_Load(sender, e)
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
            gridjob.RowCount = 0
LINE1:
            TEMPJOBNO = Val(txtjobdocketno.Text) - 1
            If TEMPJOBNO > 0 Then
                edit = True
                JobDocket_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If
            If gridjob.RowCount = 0 And TEMPJOBNO > 1 Then
                txtjobdocketno.Text = TEMPJOBNO
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
            gridjob.RowCount = 0
LINE1:
            TEMPJOBNO = Val(txtjobdocketno.Text) + 1
            getmax_job_no()
            Dim MAX As Integer = txtjobdocketno.Text.Trim
            CLEAR()
            If Val(txtjobdocketno.Text) - 1 >= TEMPJOBNO Then
                edit = True
                JobDocket_Load(sender, e)
            Else
                edit = False
                CLEAR()
            End If
            If gridjob.RowCount = 0 And TEMPJOBNO < MAX Then
                txtjobdocketno.Text = TEMPJOBNO
                GoTo LINE1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Sub FETCHDATA(ByVal PONO As String, ByVal ORDERNO As Integer, ByVal ORDERSRNO As Integer)
        Try
            Dim objcmn As New ClsCommon
            'Dim dt As DataTable = objcmn.search(" ISNULL(ORDERMASTER.ORDER_NO,0) AS ORDERNO, ISNULL(ORDERMASTER_DESC.ORDER_GRIDSRNO,0) AS ORDERSRNO,ISNULL(LEDGERS.Acc_cmpname,'') AS PARTYNAME,ISNULL(ORDERMASTER.ORDER_pono,'') AS ORDERPONO, ISNULL(ORDERMASTER.ORDER_SHADECARD,'') AS SHADECARD, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_fileno, '') AS FILENO, ISNULL(ORDERMASTER_DESC.ORDER_QTY, 0)-ISNULL(ORDERMASTER_DESC.ORDER_OUTQTY, 0)  AS QUANTITY, ISNULL(ITEMMASTER.item_name,'') AS ITEMNAME, ISNULL(PAPERGSMMASTER.PAPERGSM_NAME, '') AS PAPERGSM, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR,ISNULL(ITEMMASTER.item_actualsize, '') AS LEAFLETSIZE, ISNULL(ITEMMASTER.item_sizefolding, '') AS FOLDINGSIZE, ISNULL(PAPERMATERIALMASTER.PAPERMATERIAL_NAME, '') AS MATERIAL, ISNULL(ITEMMASTER.item_cutsize, '') AS CUTSIZE, ISNULL(ITEMMASTER.item_ups, '')AS NOOFUPS, ISNULL(PAPERSIZEMASTER.PAPERSIZE_NAME, '') AS PAPERSIZE, ISNULL(grainmaster.grain_name, '') AS GRAIN, ISNULL(designmaster.design_name,'') AS DESIGN", "", "ORDERMASTER INNER JOIN ORDERMASTER_DESC ON ORDERMASTER.ORDER_NO = ORDERMASTER_DESC.ORDER_NO AND ORDERMASTER.ORDER_YEARID = ORDERMASTER_DESC.ORDER_YEARID INNER JOIN LEDGERS ON ORDERMASTER.ORDER_LEDGERID = LEDGERS.Acc_id AND ORDERMASTER.ORDER_YEARID = LEDGERS.Acc_yearid LEFT OUTER JOIN ITEMMASTER ON ORDERMASTER_DESC.ORDER_ITEMID = ITEMMASTER.item_id AND ORDERMASTER_DESC.ORDER_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN COLORMASTER ON ITEMMASTER.item_colorid = COLORMASTER.COLOR_id AND ITEMMASTER.item_yearid = COLORMASTER.COLOR_yearid LEFT OUTER JOIN grainmaster ON ITEMMASTER.item_grainid = grainmaster.grain_id AND ITEMMASTER.item_yearid = grainmaster.grain_yearid LEFT OUTER JOIN designmaster ON ITEMMASTER.item_designid = designmaster.design_id AND ITEMMASTER.item_yearid = designmaster.design_yearid LEFT OUTER JOIN PAPERSIZEMASTER ON ITEMMASTER.item_papersizeid = PAPERSIZEMASTER.PAPERSIZE_ID AND ITEMMASTER.item_yearid = PAPERSIZEMASTER.PAPERSIZE_YEARID LEFT OUTER JOIN PAPERMATERIALMASTER ON ITEMMASTER.item_papermaterialid = PAPERMATERIALMASTER.PAPERMATERIAL_ID AND ITEMMASTER.item_yearid = PAPERMATERIALMASTER.PAPERMATERIAL_YEARID LEFT OUTER JOIN PAPERGSMMASTER ON ITEMMASTER.item_papergsmid = PAPERGSMMASTER.PAPERGSM_ID AND ITEMMASTER.item_yearid = PAPERGSMMASTER.PAPERGSM_YEARID AND ITEMMASTER.item_yearid = PAPERGSMMASTER.PAPERGSM_YEARID", "AND ORDERMASTER.ORDER_NO =" & ORDERDT.Rows(0).Item(0) & " AND ORDERMASTER_DESC.ORDER_GRIDSRNO = " & ORDERDT.Rows(0).Item(1))
            Dim dt As DataTable = objcmn.search("ISNULL(ORDERMASTER.ORDER_NO, 0) AS ORDERNO, ISNULL(ORDERMASTER_DESC.ORDER_GRIDSRNO, 0) AS ORDERSRNO, ISNULL(LEDGERS.Acc_cmpname, '') AS PARTYNAME, ISNULL(ORDERMASTER.ORDER_PONO, '') AS ORDERPONO, ISNULL(ORDERMASTER.ORDER_SHADECARD, '') AS SHADECARD, ISNULL(itemmaster.item_code, '') AS ITEMCODE, ISNULL(itemmaster.item_fileno, '') AS FILENO, ISNULL(ORDERMASTER_DESC.ORDER_QTY, 0) - ISNULL(ORDERMASTER_DESC.ORDER_OUTQTY, 0) AS QUANTITY, ISNULL(itemmaster.item_name, '') AS ITEMNAME, ISNULL(PAPERGSMMASTER.PAPERGSM_NAME, '') AS PAPERGSM, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(itemmaster.item_actualsizewidth, '') AS LEAFLETSIZE, ISNULL(itemmaster.item_sizefoldingwidth, '') AS FOLDINGSIZE, ISNULL(PAPERMATERIALMASTER.PAPERMATERIAL_NAME, '') AS MATERIAL,ISNULL(itemmaster.item_cutsize, '') AS CUTSIZE, ISNULL(itemmaster.item_ups, '') AS NOOFUPS,ISNULL(itemmaster.item_materialcode, '') AS MATERIALCODE, ISNULL(PAPERSIZEMASTER.PAPERSIZE_NAME, '') AS PAPERSIZE, ISNULL(grainmaster.grain_name, '') AS GRAIN, ISNULL(designmaster.design_name, '') AS DESIGN", "", " ORDERMASTER INNER JOIN ORDERMASTER_DESC ON ORDERMASTER.ORDER_NO = ORDERMASTER_DESC.ORDER_NO AND ORDERMASTER.ORDER_YEARID = ORDERMASTER_DESC.ORDER_YEARID INNER JOIN LEDGERS ON ORDERMASTER.ORDER_LEDGERID = LEDGERS.Acc_id AND ORDERMASTER.ORDER_YEARID = LEDGERS.Acc_yearid LEFT OUTER JOIN itemmaster ON ORDERMASTER_DESC.ORDER_ITEMID = itemmaster.item_id AND ORDERMASTER_DESC.ORDER_YEARID = itemmaster.item_yearid LEFT OUTER JOIN COLORMASTER ON itemmaster.item_colorid = COLORMASTER.COLOR_id AND itemmaster.item_yearid = COLORMASTER.COLOR_yearid LEFT OUTER JOIN grainmaster ON itemmaster.item_grainid = grainmaster.grain_id AND itemmaster.item_yearid = grainmaster.grain_yearid LEFT OUTER JOIN designmaster ON itemmaster.item_designid = designmaster.design_id AND itemmaster.item_yearid = designmaster.design_yearid LEFT OUTER JOIN PAPERSIZEMASTER ON itemmaster.item_papersizeid = PAPERSIZEMASTER.PAPERSIZE_ID AND itemmaster.item_yearid = PAPERSIZEMASTER.PAPERSIZE_YEARID LEFT OUTER JOIN PAPERMATERIALMASTER ON itemmaster.item_papermaterialid = PAPERMATERIALMASTER.PAPERMATERIAL_ID AND itemmaster.item_yearid = PAPERMATERIALMASTER.PAPERMATERIAL_YEARID LEFT OUTER JOIN PAPERGSMMASTER ON itemmaster.item_papergsmid = PAPERGSMMASTER.PAPERGSM_ID AND itemmaster.item_yearid = PAPERGSMMASTER.PAPERGSM_YEARID AND itemmaster.item_yearid = PAPERGSMMASTER.PAPERGSM_YEARID", " AND ORDERMASTER.ORDER_PONO = '" & PONO & "' AND ORDERMASTER.ORDER_NO = " & ORDERNO & " AND ORDERMASTER_DESC.ORDER_GRIDSRNO = " & ORDERSRNO & " AND ORDERMASTER.ORDER_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                For Each DR As DataRow In dt.Rows
                    txtorderno.Text = Convert.ToString(DR("ORDERNO"))
                    TXTORDERGSRNO.Text = Convert.ToString(DR("ORDERSRNO"))
                    txtpartyname.Text = Convert.ToString(DR("PARTYNAME"))
                    txtpono.Text = Convert.ToString(DR("ORDERPONO"))
                    txtshadecard.Text = Convert.ToString(DR("SHADECARD"))
                    txtitemcode.Text = Convert.ToString(DR("ITEMCODE"))
                    txtfileno.Text = Convert.ToString(DR("FILENO"))
                    txtqty.Text = Format(Val(DR("QUANTITY")), "0")
                    txtitemname.Text = Convert.ToString(DR("ITEMNAME"))
                    txtgsm.Text = Convert.ToString(DR("PAPERGSM"))
                    txtcolor.Text = Convert.ToString(DR("COLOR"))
                    txtleafletsize.Text = Convert.ToString(DR("LEAFLETSIZE"))
                    txtfoldingsize.Text = Convert.ToString(DR("FOLDINGSIZE"))
                    txtmaterial.Text = Convert.ToString(DR("MATERIAL"))
                    txtcutsize.Text = Convert.ToString(DR("CUTSIZE"))
                    txtups.Text = Convert.ToString(DR("NOOFUPS"))
                    txtpapersize.Text = Convert.ToString(DR("PAPERSIZE"))
                    txtgrain.Text = Convert.ToString(DR("GRAIN"))
                    txtdesign.Text = Convert.ToString(DR("DESIGN"))
                    txtsrno.Text = Convert.ToString(DR("FILENO"))
                    txtmaterialcode.Text = Convert.ToString(DR("MATERIALCODE"))

                    'txttotalsheets.Text = Format(Val(Val(Val(txtqty.Text) * Val(TXTPERCENTAGE.Text)) / 100 + Val(txtqty.Text)) / Val(txtups.Text), "0")
                    TOTOLSHEET()
                    txtsheetsgiven.Text = Val(txttotalsheets.Text)
                    txtbalancesheets.Text = Val(txttotalsheets.Text)
                    CMDSELECTORDER.Enabled = False
                    txtpono.Enabled = False
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTORDER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTORDER.Click
        Try
            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            Dim OBJSELECTORDER As New SelectOrder
            OBJSELECTORDER.ShowDialog()
            Dim ORDERDT As DataTable = OBJSELECTORDER.DT
            'If ORDERDT.Rows.Count > 0 Then FETCHDATA(ORDERDT.Rows(0).Item(0))
            If ORDERDT.Rows.Count > 0 Then FETCHDATA(ORDERDT.Rows(0).Item(0), ORDERDT.Rows(0).Item(1), ORDERDT.Rows(0).Item(2))
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub Selectcase()

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
                GROUPPRINT.Enabled = False
                GROUPFOLDING.Enabled = False
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
                madedate.Value = Mydate
                txtplatedestroyedby.Clear()
                destroyeddate.Value = Mydate
                txtplateremadeby.Clear()
                remadedate.Value = Mydate
                txtsupervisor.Clear()

                GROUPPLATE.Visible = True
                GROUPPLATE.Enabled = True

                GROUPPOSITIVE.Enabled = False
                GROUPPRINT.Enabled = False
                GROUPFOLDING.Enabled = False
                GROUPPACKING.Enabled = False
                GROUPFINAL.Enabled = False

                GROUPPLATE.BringToFront()
                cmbdamage.Focus()
                LBLPAPERMFG.Visible = False
                txtpapermfg.Visible = False
                LBLGRADENO.Visible = False
                txtgrade.Visible = False
                LBLTEST.Visible = False
                txttestval.Visible = False

            Case 3
                lblprocess.Text = "PRINTING"
                tempprocessname = "PRINITNG"
                lblbalancesheet.Text = "Bal Sheets Ret."
                txtname.Clear()
                txtsheetsgiven.Clear()
                txtsheetsgiven.Text = Val(txttotalsheets.Text)
                givendate.Value = Mydate
                txtbalancesheets.Text = Val(txttotalsheets.Text)
                balancedate.Value = Mydate
                txtdestroyedsheets.Clear()
                txtsupervisor.Clear()

                GROUPPRINT.Visible = True
                GROUPPRINT.Enabled = True


                GROUPPOSITIVE.Enabled = False
                GROUPPLATE.Enabled = False
                GROUPFOLDING.Enabled = False
                GROUPPACKING.Enabled = False
                GROUPFINAL.Enabled = False

                GROUPPRINT.BringToFront()
                txtname.Focus()
                LBLPAPERMFG.Visible = True
                txtpapermfg.Visible = True
                LBLGRADENO.Visible = True
                txtgrade.Visible = True
                LBLTEST.Visible = True
                txttestval.Visible = True

            Case 4
                lblprocess.Text = "SORTING"
                tempprocessname = "SORTING"
                lblbalancesheet.Text = "Bal Sheets Ret."
                txtname.Clear()
                txtsheetsgiven.Clear()
                txtsheetsgiven.Text = Val(TEMPBALSHEET)
                givendate.Value = Mydate
                txtsupervisor.Clear()
                'txtbalancesheets.Clear()
                txtbalancesheets.Text = Val(TEMPBALSHEET)
                balancedate.Value = Mydate
                txtdestroyedsheets.Clear()

                GROUPPRINT.Visible = True
                GROUPPRINT.Enabled = True


                GROUPPOSITIVE.Enabled = False
                GROUPPLATE.Enabled = False
                GROUPFOLDING.Enabled = False
                GROUPPACKING.Enabled = False
                GROUPFINAL.Enabled = False

                GROUPPRINT.BringToFront()
                txtname.Focus()
                LBLPAPERMFG.Visible = True
                txtpapermfg.Visible = True
                LBLGRADENO.Visible = True
                txtgrade.Visible = True
                LBLTEST.Visible = True
                txttestval.Visible = True

            Case 5
                lblprocess.Text = "CUTTING"
                tempprocessname = "CUTTING"
                lblbalancesheet.Text = "Bal Leaflet Ret."
                lbldestroyedsheets.Text = "Destoyed Leaflet"
                txtname.Clear()
                txtsheetsgiven.Clear()
                txtsheetsgiven.Text = Val(TEMPBALSHEET)
                givendate.Value = Mydate
                txtbalancesheets.Text = (Val(txtsheetsgiven.Text) * Val(txtups.Text))
                balancedate.Value = Mydate
                txtdestroyedsheets.Clear()
                txtsupervisor.Clear()

                GROUPPRINT.Visible = True
                GROUPPRINT.Enabled = True


                GROUPPOSITIVE.Enabled = False
                GROUPPLATE.Enabled = False
                GROUPFOLDING.Enabled = False
                GROUPPACKING.Enabled = False
                GROUPFINAL.Enabled = False

                GROUPPRINT.BringToFront()
                txtname.Focus()
                LBLPAPERMFG.Visible = True
                txtpapermfg.Visible = True
                LBLGRADENO.Visible = True
                txtgrade.Visible = True
                LBLTEST.Visible = True
                txttestval.Visible = True

            Case 6
                lblprocess.Text = "FOLDING"
                tempprocessname = "FOLDING"
                txtcleanedby.Clear()
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

                GROUPFOLDING.Visible = True
                GROUPFOLDING.Enabled = True


                GROUPPOSITIVE.Enabled = False
                GROUPPLATE.Enabled = False
                GROUPPRINT.Enabled = False
                GROUPPACKING.Enabled = False
                GROUPFINAL.Enabled = False

                GROUPFOLDING.BringToFront()
                txtcleanedby.Focus()
                LBLPAPERMFG.Visible = True
                txtpapermfg.Visible = True
                LBLGRADENO.Visible = True
                txtgrade.Visible = True
                LBLTEST.Visible = True
                txttestval.Visible = True

            Case 7
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
                GROUPFINAL.Enabled = False

                GROUPPACKING.BringToFront()
                txtpackingname.Focus()

                LBLPAPERMFG.Visible = True
                txtpapermfg.Visible = True
                LBLGRADENO.Visible = True
                txtgrade.Visible = True
                LBLTEST.Visible = True
                txttestval.Visible = True

            Case 8
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

                GROUPFINAL.BringToFront()
                txtshortqty.Focus()

                LBLPAPERMFG.Visible = True
                txtpapermfg.Visible = True
                LBLGRADENO.Visible = True
                txtgrade.Visible = True
                LBLTEST.Visible = True
                txttestval.Visible = True

            Case 9
                lblprocess.Text = "COMPLETED"
        End Select
    End Sub

    Sub FILLGRID()

        If tempprocessno = 1 Then
            gridjob.Rows.Add("POSITIVE", txtsrno.Text.Trim, txtcolor.Text.Trim, txtplatecheckedby.Text.Trim, txtcodecheckedby.Text.Trim, txtupscheckedby.Text.Trim, txtcorrectionappby.Text.Trim, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", txtsupervisor.Text.Trim)
            tempprocessno = tempprocessno + 1
            Selectcase()

        ElseIf tempprocessno = 2 Then
            gridjob.Rows.Add("PLATE", "", "", "", "", "", "", txtplatecheckedby.Text.Trim, Format(madedate.Value, "dd/MM/yyyy"), txtplatedestroyedby.Text.Trim, Format(destroyeddate.Value, "dd/MM/yyyy"), txtplateremadeby.Text.Trim, Format(remadedate.Value, "dd/MM/yyyy"), "", "", "", "", "", "", "", "", "", "", "", "", txtsupervisor.Text.Trim)
            tempprocessno = tempprocessno + 1
            Selectcase()

        ElseIf tempprocessno = 3 Then
            'Dim SHEETGIVEN As String
            gridjob.Rows.Add("PRINTING", "", "", "", "", "", "", "", "", "", "", "", "", txtname.Text.Trim, txtsheetsgiven.Text.Trim, Format(givendate.Value, "dd/MM/yyyy"), txtbalancesheets.Text.Trim, Format(balancedate.Value, "dd/MM/yyyy"), txtdestroyedsheets.Text.Trim, "", "", "", "", "", "", txtsupervisor.Text.Trim)
            tempprocessno = tempprocessno + 1
            TEMPBALSHEET = Val(txtbalancesheets.Text)
            Selectcase()

        ElseIf tempprocessno = 4 Then
            gridjob.Rows.Add("SORTING", "", "", "", "", "", "", "", "", "", "", "", "", txtname.Text.Trim, txtsheetsgiven.Text.Trim, Format(givendate.Value, "dd/MM/yyyy"), txtbalancesheets.Text.Trim, Format(balancedate.Value, "dd/MM/yyyy"), txtdestroyedsheets.Text.Trim, "", "", "", "", "", "", txtsupervisor.Text.Trim)
            tempprocessno = tempprocessno + 1
            TEMPBALSHEET = Val(txtbalancesheets.Text)
            Selectcase()

        ElseIf tempprocessno = 5 Then
            gridjob.Rows.Add("CUTTING", "", "", "", "", "", "", "", "", "", "", "", "", txtname.Text.Trim, txtsheetsgiven.Text.Trim, Format(givendate.Value, "dd/MM/yyyy"), txtbalancesheets.Text.Trim, Format(balancedate.Value, "dd/MM/yyyy"), txtdestroyedsheets.Text.Trim, "", "", "", "", "", "", txtsupervisor.Text.Trim)
            tempprocessno = tempprocessno + 1
            TEMPBALSHEET = Val(txtbalancesheets.Text)
            Selectcase()

        ElseIf tempprocessno = 6 Then
            gridjob.Rows.Add("FOLDING", "", "", "", "", "", "", "", "", "", "", "", "", txtfoldingname.Text.Trim, txtfoldingsheetsgiven.Text.Trim, Format(foldinggivendate.Value, "dd/MM/yyyy"), txtfoldingbalancesheet.Text.Trim, Format(foldingbalancedate.Value, "dd/MM/yyyy"), txtfoldingdestroyedsheets.Text.Trim, txtcleanedby.Text.Trim, txtsampleappby.Text.Trim, "", "", "", "", txtsupervisor.Text.Trim)
            tempprocessno = tempprocessno + 1
            TEMPBALSHEET = Val(txtfoldingbalancesheet.Text)
            Selectcase()

        ElseIf tempprocessno = 7 Then
            If Val(txtptotal.Text) = Val(txtstotal.Text) Then
                gridjob.Rows.Add("PACKING", "", "", "", "", "", "", "", "", "", "", "", "", txtpackingname.Text.Trim, "", "", "", "", "", "", "", txttotalpacket.Text.Trim, txttotalshipper.Text.Trim, txtpacketsize.Text.Trim, "", txtsupervisor.Text.Trim)
                tempprocessno = tempprocessno + 1
                Selectcase()
            Else
                MsgBox("Total Does Not Match", MsgBoxStyle.Critical)
                txtpacketitem1.Focus()
                Exit Sub
            End If

        ElseIf tempprocessno = 8 Then
            gridjob.Rows.Add("FINAL", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", Val(txtshortqty.Text.Trim), txtsupervisor.Text.Trim)
            tempprocessno = tempprocessno + 1
            Selectcase()
        End If
    End Sub

    Private Sub TXTBARCODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBARCODE.TextChanged
        Try
            If TXTBARCODE.Text.Trim.Length > 0 Then

                'GET DATA FROM BARCODE
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" JOB_NO AS JOBNO", "", "JOBMASTER", " AND JOB_BARCODE = '" & TXTBARCODE.Text.Trim & "' AND JOB_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    Dim OBJJOB As New ClsJobDocket
                    Dim DTTABLE1 As DataTable = OBJJOB.selectNO(Val(DT.Rows(0).Item("JOBNO")), YearId)
                    If DTTABLE1.Rows.Count > 0 Then
                        For Each DR As DataRow In DTTABLE1.Rows

                            txtjobdocketno.Text = TEMPJOBNO
                            txtorderno.Text = Convert.ToString(DR("ORDERNO"))
                            TXTORDERGSRNO.Text = Convert.ToString(DR("ORDERSRNO"))
                            txtpartyname.Text = Convert.ToString(DR("PARTYNAME"))
                            txtpono.Text = Convert.ToString(DR("PONO"))
                            jobdate.Text = Convert.ToString(DR("DATE"))
                            txtitemcode.Text = Convert.ToString(DR("ITEMCODE"))
                            txtfileno.Text = Convert.ToString(DR("FILENO"))
                            txtitemname.Text = Convert.ToString(DR("ITEMNAME"))
                            txtgsm.Text = Convert.ToString(DR("PPRGSM"))
                            txtmaterial.Text = Convert.ToString(DR("MATERIAL"))
                            txtpapersize.Text = Convert.ToString(DR("PPRSIZE"))
                            txtdesign.Text = Convert.ToString(DR("DESIGN"))
                            txtqty.Text = Format(Val(DR("QTY")), "0")
                            txtshadecard.Text = Convert.ToString(DR("SHADECARD"))
                            txtleafletsize.Text = Convert.ToString(DR("LEAFLETSIZE"))
                            txtfoldingsize.Text = Convert.ToString(DR("FOLDINGSIZE"))
                            txtcutsize.Text = Convert.ToString(DR("CUTSIZE"))
                            txtups.Text = Convert.ToString(DR("UPS"))
                            txtpapermfg.Text = Convert.ToString(DR("PPRMFG"))
                            txtgrade.Text = Convert.ToString(DR("GRADE"))
                            txttestval.Text = Convert.ToString(DR("TESTVALUE"))
                            txttotalsheets.Text = Convert.ToString(DR("TOTALSHEETS"))
                            txtsheetsgiven.Text = Convert.ToString(DR("TOTALSHEETS"))
                            txtshortqty.Text = Convert.ToString(DR("SHORTQTY"))
                            txtsrno.Text = Convert.ToString(DR("FILENO"))
                            txtcolor.Text = Convert.ToString(DR("COLOR"))

                            If Convert.ToBoolean(DR("DONE")) = True Then
                                lbllocked.Visible = True
                                PBlock.Visible = True
                            End If
                            TXTPERCENTAGE.Text = Convert.ToString(DR("PERCENTAGE"))

                            ''GRID VALUES
                            gridjob.Rows.Add(DR("PROCESS").ToString, DR("SRNO"), DR("COLOR"), DR("PLATECHKBY").ToString, DR("CODECHKBY").ToString, DR("UPSCHKBY").ToString, DR("CORRAPLYBY").ToString, DR("PLATEMADEBY").ToString, DR("MADEDATE").ToString, DR("PLATEDESTROY").ToString, DR("DESTROYDATE").ToString, DR("PLATEREMADE").ToString, DR("REMADEDATE").ToString, DR("NAME").ToString, DR("SHEETSGIVEN"), DR("GIVENDATE").ToString, DR("BALSHEETS"), DR("RETURNDATE").ToString, DR("SHEETSDESTROY"), DR("MACHINCLNBY").ToString, DR("SAMPLE").ToString, DR("TOTALPACKETS"), DR("TOTALSHIPEERS"), DR("PACKETSIZE"), Val(DR("SHORTQTY")), DR("SUPERVISOR").ToString)
                            tempprocessno = tempprocessno + 1
                            Selectcase()
                            'FILLGRID()
                            CMDSELECTORDER.Enabled = False
                        Next
                        gridjob.FirstDisplayedScrollingRowIndex = gridjob.RowCount - 1

                        '' GRID UPLOAD
                        DT = OBJCMN.search("ISNULL(JOB_UPSRNO, 0) AS SRNO, ISNULL(JOB_UPREMARKS, '') AS REMARKS, ISNULL(JOB_UPNAME, '') AS NAME, JOB_IMGPATH AS IMGPATH", "", "JOBMASTER_UPLOAD", "AND JOBMASTER_UPLOAD.JOB_NO= " & TEMPJOBNO & "  AND JOB_YEARID = " & YearId & " ORDER BY JOBMASTER_UPLOAD.JOB_UPSRNO")
                        If DT.Rows.Count > 0 Then
                            For Each DTR As DataRow In DT.Rows
                                gridupload.Rows.Add(DTR("SRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                            Next
                        End If
                    End If


                    TXTBARCODE.Clear()

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBARCODE.Validating
        Try
            If TXTBARCODE.Text.Trim <> "" Then
                'CHECKING WHETHER IS IS GONE OUT OR NOT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("JOB_NO AS JOBNO ", "", " JOBMASTER", " AND JOB_BARCODE = '" & TXTBARCODE.Text.Trim & "' AND JOB_YEARID = " & YearId)
                If DT.Rows.Count = 0 Then MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
                TXTBARCODE.Clear()
                e.Cancel = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpacketitem1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpacketitem1.KeyPress
        numkeypress(e, txtpacketitem1, Me)
    End Sub

    Private Sub txtpacketitem2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpacketitem2.KeyPress
        numkeypress(e, txtpacketitem2, Me)
    End Sub

    Private Sub txtpacketitem3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpacketitem3.KeyPress
        numkeypress(e, txtpacketitem3, Me)
    End Sub

    Private Sub txtpacket1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpacket1.KeyPress
        numkeypress(e, txtpacket1, Me)
    End Sub

    Private Sub txtpacket2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpacket2.KeyPress
        numkeypress(e, txtpacket2, Me)
    End Sub

    Private Sub txtpacket3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpacket3.KeyPress
        numkeypress(e, txtpacket3, Me)
    End Sub

    Private Sub txtpackettotal1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpackettotal1.KeyPress
        numkeypress(e, txtpackettotal1, Me)
    End Sub

    Private Sub txtpackettotal2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpackettotal2.KeyPress
        numkeypress(e, txtpackettotal2, Me)
    End Sub

    Private Sub txtpackettotal3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpackettotal3.KeyPress
        numkeypress(e, txtpackettotal3, Me)
    End Sub

    Private Sub txttotalpacket_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttotalpacket.KeyPress
        numkeypress(e, txttotalpacket, Me)
    End Sub

    Private Sub txtptotal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtptotal.KeyPress
        numkeypress(e, txtptotal, Me)
    End Sub

    Private Sub txtshipperitem1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtshipperitem1.KeyPress
        numkeypress(e, txtshipperitem1, Me)
    End Sub

    Private Sub txtshipperitem2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtshipperitem2.KeyPress
        numkeypress(e, txtshipperitem1, Me)
    End Sub

    Private Sub txtshipperitem3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtshipperitem3.KeyPress
        numkeypress(e, txtshipperitem2, Me)
    End Sub

    Private Sub txtshipper1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtshipper1.KeyPress
        numkeypress(e, txtshipper1, Me)
    End Sub

    Private Sub txtshipper2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtshipper2.KeyPress
        numkeypress(e, txtshipper2, Me)
    End Sub

    Private Sub txtshipper3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtshipper3.KeyPress
        numkeypress(e, txtshipper3, Me)
    End Sub

    Private Sub txttotalshipper_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttotalshipper.KeyPress
        numkeypress(e, txttotalshipper, Me)
    End Sub

    Private Sub txtshippertotal1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtshippertotal1.KeyPress
        numkeypress(e, txtshippertotal1, Me)
    End Sub

    Private Sub txtshippertotal2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtshippertotal2.KeyPress
        numkeypress(e, txtshippertotal2, Me)
    End Sub

    Private Sub txtshippertotal3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtshippertotal3.KeyPress
        numkeypress(e, txtshippertotal3, Me)
    End Sub

    Private Sub txtstotal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtstotal.KeyPress
        numkeypress(e, txtstotal, Me)
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress
        numdot(e, txtqty, Me)
    End Sub

    Private Sub txtpono_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpono.KeyDown
        Try
            If e.KeyCode = Keys.F1 And edit = False Then CMDSELECTORDER_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtbalancesheets_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtbalancesheets.Validating
        If Val(txtbalancesheets.Text) = "0" Then
            txtdestroyedsheets.Text = "0"
        Else
            If tempprocessno = 5 Then
                If Val(txtbalancesheets.Text) <= (Val(txtsheetsgiven.Text) * Val(txtups.Text)) Then
                    txtdestroyedsheets.Text = (Val(txtsheetsgiven.Text) * Val(txtups.Text)) - Val(txtbalancesheets.Text)
                Else
                    MessageBox.Show("Invalid No. of Sheets")
                    txtbalancesheets.Focus()
                    e.Cancel = True
                End If
            Else
                If Val(txtbalancesheets.Text) <= Val(txtsheetsgiven.Text) Then
                    txtdestroyedsheets.Text = Val(txtsheetsgiven.Text) - Val(txtbalancesheets.Text)
                Else
                    MessageBox.Show("Invalid No. of Sheets")
                    txtbalancesheets.Focus()
                    e.Cancel = True
                End If
            End If
        End If
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

    Private Sub txtpacket1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpacket1.Validating
        Try
            If Val(txtpacketitem1.Text) > 0 And Val(txtpacket1.Text) > 0 Then
                txtpackettotal1.Text = Val(txtpacketitem1.Text) * Val(txtpacket1.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpacket2_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpacket2.Validating
        Try
            If Val(txtpacketitem2.Text) <> "0" And Val(txtpacket2.Text) <> "0" Then
                txtpackettotal2.Text = Val(txtpacketitem2.Text) * Val(txtpacket2.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpacket3_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpacket3.Validating
        Try
            If Val(txtpacketitem3.Text) <> "0" And Val(txtpacket3.Text) <> "0" Then
                txtpackettotal3.Text = Val(txtpacketitem3.Text) * Val(txtpacket3.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpacketitem1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpacketitem1.Validating
        Try
            If Val(txtpacketitem1.Text) <> "0" And Val(txtpacket1.Text) <> "0" Then
                txtpackettotal1.Text = Val(txtpacketitem1.Text) * Val(txtpacket1.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpacketitem2_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpacketitem2.Validating
        Try
            If Val(txtpacketitem2.Text) <> "0" And Val(txtpacket2.Text) <> "0" Then
                txtpackettotal2.Text = Val(txtpacketitem2.Text) * Val(txtpacket2.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpacketitem3_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpacketitem3.Validating
        Try
            If Val(txtpacketitem3.Text) <> "0" And Val(txtpacket3.Text) <> "0" Then
                txtpackettotal3.Text = Val(txtpacketitem3.Text) * Val(txtpacket3.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtshipperitem1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtshipperitem1.Validating
        Try
            If Val(txtshipperitem1.Text) <> "0" And Val(txtshipper1.Text) <> "0" Then
                txtshippertotal1.Text = Val(txtshipperitem1.Text) * Val(txtshipper1.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtshipperitem2_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtshipperitem2.Validating
        Try
            If Val(txtshipperitem2.Text) <> "0" And Val(txtshipper2.Text) <> "0" Then
                txtshippertotal2.Text = Val(txtshipperitem2.Text) * Val(txtshipper2.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtshipperitem3_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtshipperitem3.Validating
        Try
            If Val(txtshipperitem3.Text) <> "0" And Val(txtshipper3.Text) <> "0" Then
                txtshippertotal3.Text = Val(txtshipperitem3.Text) * Val(txtshipper3.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtshipper1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtshipper1.Validating
        Try
            If Val(txtshipperitem1.Text) <> "0" And Val(txtshipper1.Text) <> "0" Then
                txtshippertotal1.Text = Val(txtshipperitem1.Text) * Val(txtshipper1.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtshipper2_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtshipper2.Validating
        Try
            If Val(txtshipperitem2.Text) <> "0" And Val(txtshipper2.Text) <> "0" Then
                txtshippertotal2.Text = Val(txtshipperitem2.Text) * Val(txtshipper2.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtshipper3_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtshipper3.Validating
        Try
            If Val(txtshipperitem3.Text) <> "0" And Val(txtshipper3.Text) <> "0" Then
                txtshippertotal3.Text = Val(txtshipperitem3.Text) * Val(txtshipper3.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdproceed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdproceed.Click
        If tempprocessno > 8 Then
            MessageBox.Show("Could Not Proceed, Job Completed")
        Else
            'CHECKING WHETHER PACKETS OR SHIPPER ARE GREATER THAN FOLDING'S BALANCE QTY OR NOT
            If tempprocessno = 7 Then If Val(txtptotal.Text) <> Val(gridjob.Rows(gridjob.RowCount - 1).Cells(Gbalancesheets.Index).Value) Then If MsgBox("Total Does Not Match with Folding Leaflets, there are " & Val(gridjob.Rows(gridjob.RowCount - 1).Cells(Gbalancesheets.Index).Value) & " Leaflets, With to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            FILLGRID()
        End If
    End Sub

    Private Sub cmdskip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdskip.Click

        If tempprocessno > 8 Then
            MessageBox.Show("Could Not Proceed, Job Completed")
        Else
            TEMPBALSHEET = Val(txtbalancesheets.Text)
            tempprocessno = tempprocessno + 1
            Selectcase()
        End If

    End Sub

    Private Sub gridjob_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridjob.KeyDown
        If e.KeyCode = Keys.Delete Then
            If gridjob.CurrentRow.Index = gridjob.RowCount - 1 Then

                If gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "POSITIVE" Then
                    tempprocessno = 1
                ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "PLATE" Then
                    tempprocessno = 2
                ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "PRINTING" Then
                    tempprocessno = 3
                ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "SORTING" Then
                    tempprocessno = 4
                    TEMPBALSHEET = Val(txtsheetsgiven.Text.Trim)
                ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "CUTTING" Then
                    tempprocessno = 5
                    TEMPBALSHEET = Format(Val(txtfoldingsheetsgiven.Text) / Val(txtups.Text), "0")
                ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "FOLDING" Then
                    tempprocessno = 6
                    txtfoldingsheetsgiven.Text = Val(txtstotal.Text)
                ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = "PACKING" Then
                    tempprocessno = 7
                    TEMPBALSHEET = Val(txtstotal.Text)
                ElseIf gridjob.CurrentRow.Cells(Gprocess.Index).Value.ToString = " FINAL" Then
                    tempprocessno = 8
                End If
                Selectcase()
                gridjob.Rows.RemoveAt(gridjob.CurrentRow.Index)
                FILLTOTAL()
            Else
                MessageBox.Show("Only Last Process Can be Removed", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub txtfoldingbalancesheet_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtfoldingbalancesheet.Validating
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

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJJOB As New JobDocketDetails
            OBJJOB.MdiParent = MDIMain
            OBJJOB.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTOLSHEET()
        txttotalsheets.Text = Format((Val(Val(txtqty.Text) * Val(TXTPERCENTAGE.Text)) / 100 + Val(txtqty.Text)) / Val(txtups.Text), "0")
    End Sub

    Private Sub txtqty_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtqty.Validating
        Try
            Dim OBJCMN As New ClsCommon
            Dim DTT As DataTable = OBJCMN.search("ORDERMASTER.ORDER_TOTALQTY, ORDERMASTER.ORDER_NO", "", "ORDERMASTER INNER JOIN jobmaster ON ORDERMASTER.ORDER_NO = jobmaster.job_orderno AND ORDERMASTER.ORDER_YEARID = jobmaster.job_yearid", "AND ORDERMASTER.ORDER_NO = '" & txtorderno.Text.Trim & "' AND ORDER_YEARID = " & YearId)
            If DTT.Rows.Count > 0 Then
                If Val(txtqty.Text.Trim) > Val(DTT.Rows(0).Item(0)) Then
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
                TEMPMSG = MsgBox("Wish to Delete Docket.?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    TEMPMSG = MsgBox("Are you Sure?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then

                        Dim ALPARAVAL As New ArrayList
                        ALPARAVAL.Add(txtjobdocketno.Text.Trim)
                        ALPARAVAL.Add(tempprocessno)
                        ALPARAVAL.Add(YearId)
                        ALPARAVAL.Add(Userid)

                        Dim OBJJOB As New ClsJobDocket
                        OBJJOB.alParaval = ALPARAVAL
                        Dim INTRESULT As Integer = OBJJOB.delete()
                        MsgBox("JobDocket is Deleted")
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

    Private Sub jobdate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles jobdate.Validating
        If Not datecheck(jobdate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call CMDDELETE_Click(sender, e)
    End Sub

    Private Sub txtfoldingbalancesheet_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfoldingbalancesheet.KeyPress
        numkeypress(e, txtfoldingbalancesheet, Me)
    End Sub

    Private Sub foldinggivendate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles foldinggivendate.Validating
        If Not datecheck(foldinggivendate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub foldingbalancedate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles foldingbalancedate.Validating
        If Not datecheck(foldingbalancedate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub txtbalancesheets_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbalancesheets.KeyPress
        numkeypress(e, txtbalancesheets, Me)
    End Sub

    Private Sub givendate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles givendate.Validating
        If Not datecheck(givendate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub balancedate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles balancedate.Validating
        If Not datecheck(balancedate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub madedate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles madedate.Validating
        If Not datecheck(madedate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub destroyeddate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles destroyeddate.Validating
        If Not datecheck(destroyeddate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub remadedate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles remadedate.Validating
        If Not datecheck(remadedate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub


    Private Sub txtplatecheckedby_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtplatecheckedby.Validated
        pcase(txtplatecheckedby)
    End Sub

    Private Sub txtcodecheckedby_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcodecheckedby.Validated
        pcase(txtcodecheckedby)
    End Sub

    Private Sub txtupscheckedby_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtupscheckedby.Validated
        pcase(txtupscheckedby)
    End Sub

    Private Sub txtcorrectionappby_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcorrectionappby.Validated
        pcase(txtcorrectionappby)
    End Sub

    Private Sub txtsupervisor_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsupervisor.Validated
        pcase(txtsupervisor)
    End Sub

    Private Sub txtpapermfg_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpapermfg.Validated
        pcase(txtpapermfg)
    End Sub

    Private Sub txtgrade_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtgrade.Validated
        pcase(txtgrade)
    End Sub

    Private Sub txttestval_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttestval.Validated
        pcase(txttestval)
    End Sub

    Private Sub txtcleanedby_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcleanedby.Validated
        pcase(txtcleanedby)
    End Sub

    Sub PRINTREPORT(ByVal JOBNO As Integer)
        Try
            TEMPMSG = MsgBox("Wish to Print?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJJOB As New DocketDesign
                OBJJOB.MdiParent = MDIMain
                OBJJOB.FRMSTRING = "DOCKET"
                OBJJOB.WHERECLAUSE = "{JOBMASTER.JOB_NO}=" & Val(JOBNO) & "AND {JOBMASTER.JOB_YEARID}=" & YearId
                OBJJOB.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then PRINTREPORT(TEMPJOBNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
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

    Private Sub gridupload_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If e.RowIndex >= 0 Then PBSOFTCOPY.Image = gridupload.Rows(e.RowIndex).Cells(GUIMGPATH.Index).Value
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

    Private Sub TXTPERCENTAGE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTPERCENTAGE.Validating
        If Val(TXTPERCENTAGE.Text.Trim) > 100 Then
            e.Cancel = True
            MsgBox("% Cannot be greater than 100 ", MsgBoxStyle.Critical)
            Exit Sub
        Else
            TOTOLSHEET()
        End If
    End Sub

    Private Sub TXTPERCENTAGE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPERCENTAGE.KeyPress
        numdot3(e, TXTPERCENTAGE, Me)
    End Sub

    Private Sub txtpono_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpono.Validating

        ''-------------''
        'Try
        '    If txtpono.Text.Trim <> "" Then
        '        FETCHDATA(txtpono.Text.Trim, Val(txtorderno.Text.Trim), Val(TXTORDERGSRNO.Text.Trim))
        '        If txtitemname.Text.Trim = "" Then
        '            MsgBox("Invalid P.O. No", MsgBoxStyle.Critical)
        '            txtpono.Clear()
        '            e.Cancel = True
        '            Exit Sub
        '        Else
        '            CMDSELECTORDER.Enabled = False
        '            txtpono.Enabled = False
        '        End If
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

End Class