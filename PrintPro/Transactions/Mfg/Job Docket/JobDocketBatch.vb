Imports BL
Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel

Public Class JobDocketBatch

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public TEMPJOBNO, tempprocessno, TEMPBALSHEET, TEMPMSG As Integer
    Public tempprocessname As String
    Public edit As Boolean
    Dim gridDoubleClick As Boolean
    Dim temprow As Integer
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
        CMBNONINVITEM.Text = ""
        txtorderno.Clear()
        TXTORDERGSRNO.Clear()
        txtpartyname.Clear()
        txtitemcode.Clear()
        TXTBOMITEMCODE.Clear()
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
        TXTPOSITIVENEGATIVE.Clear()
        txtmaterial.Clear()
        txtdesign.Clear()
        txtgsm.Clear()
        txtgrain.Clear()
        txttotalsheets.Clear()
        txtmaterialcode.Clear()
        TXTPERCENTAGE.Text = 10
        gridDoubleClick = False
        TXTORDERTYPE.Clear()
        txtpono.Clear()
        CMBLAM1.Text = ""
        CMBLAM2.Text = ""
        'GRID
        TXTJOBQTY.Clear()
        TXTCOL1.Clear()
        TXTCOL2.Clear()
        CMBMODE.Text = ""
        TXTCOL1PLATES.Clear()
        TXTCOL2PLATES.Clear()
        CMBCOL1PLATETYPE.Text = ""
        CMBCOL2PLATETYPE.Text = ""
        txtups.Clear()
        TXTCUTSHEET.Clear()
        TXTEXTRA.Clear()
        TXTTOTAL.Clear()
        TXTTIME.Text = 1 'its saved as produced qty
        TXTCUTSIZEG.Clear()
        TXTCOLORUPS.Clear()
        TXTCOLORSHEET.Clear()
        TXTFULLSIZE.Clear()
        TXTSHIPTO.Clear()
        TXTMAINITEM.Clear()
        TXTGUPS.Clear()
        CMBLAMM.Text = ""
        TXTYIELD.Clear()
        TXTSHEETS.Clear()
        TXTFILMSIZE.Clear()
        TXTFILMSIZE2.Clear()
        TXTKGS.Clear()
        CMBLAMINATION.Text = ""
        CMBUV.Text = ""
        CMBPUNCHING.Text = ""
        CMBENVELOPE.Text = ""
        CMBGUMMING.Text = ""
        CMBBINDING.Text = ""
        CMBNUMBERING.Text = ""
        CMBFABRICATION.Text = ""
        CMBPACKING.Text = ""
        DTPREV.Text = Now.Date
        TXTPREVJOBNO.Clear()
        CMBMACHINE.Text = ""
        CMBOUTVENDORNAME.Text = ""
        TXTOPENSIZE.Clear()
        TXTCLOSESIZE.Clear()
        CMBLAMMODE.Text = ""
        CMBLAM.Text = ""
        CMBLUV.Text = ""
        CMBLPUNCHING.Text = ""
        CMBLENVELOPE.Text = ""
        CMBLGUM.Text = ""
        CMBLBINDING.Text = ""
        CMBLNUMBERING.Text = ""
        CMBLFABRICATION.Text = ""
        TXTLAMINATION1.Clear()
        TXTLAMINATION2.Clear()
        CMBVENDOR.Text = ""
        CMBVENDOR1.Text = ""
        CMBLPACKING.Text = ""
        lbllocked.Visible = False
        LBLREQDONE.Visible = False
        LBLPRINTPRODONE.Visible = False
        LBLLAMPRODONE.Visible = False
        LBLLAMCUTPRODONE.Visible = False
        LBLUVPRODONE.Visible = False
        LBLFOILPRODONE.Visible = False
        LBLGUMPRODONE.Visible = False
        LBLPUNCPRODONE.Visible = False
        LBLBINDPRODONE.Visible = False
        LBLENVLPRODONE.Visible = False
        LBLNUMPRODONE.Visible = False
        LBLFABPRODONE.Visible = False
        LBLPACKINGPRODONE.Visible = False
        LBLPROD1DONE.Visible = False
        LBLPROD2DONE.Visible = False
        LBLFOLDINGDONE.Visible = False
        LBLCUTTINGDONE.Visible = False
        LBLCLOSE.Visible = False
        LBLFINISHED.Visible = False
        TXTPRODFINISHQTY.Clear()
        TXTPROPRINTINGQTY.Clear()
        TXTLAMINATIONUPS.Text = 1
        TXTPUNCHINGUPS.Text = 1
        TXTFINALUPS.Text = 1
        TXTFOLDINGUPS.Text = 1
        TXTNUMBERINGUPS.Text = 1
        PBlock.Visible = False
        getmax_job_no()
        EP.Clear()

    End Sub

    Sub getmax_job_no()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax("isnull(max(JOB_NO),0) + 1", "JOBBATCHMASTER", " AND JOB_YEARID = " & YearId)
        If DTTABLE.Rows.Count > 0 Then
            txtjobdocketno.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Sub TOTOLSHEET()
        txttotalsheets.Text = Format((Val(Val(txtqty.Text) * Val(TXTPERCENTAGE.Text)) / 100 + Val(txtqty.Text)) / Val(txtups.Text), "0")
    End Sub


    Private Sub JobDocketBatch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                If ERRORVALID() = True Then
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
                'ElseIf e.Alt = True And e.KeyCode = Keys.P Then
                '    If edit = True Then Call PRINTREPORT(TEMPJOBNO)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JobDocketBatch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'JOB DOCKET'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor


            If ClientName = "RUTVIJ" Or ClientName = "AMR" Then
                txtjobdocketno.ReadOnly = False
            Else
                txtjobdocketno.ReadOnly = True
            End If
            If CMBNONINVITEM.Text.Trim = "" Then FILLNONINVITEM(CMBNONINVITEM, edit)
            CLEAR()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJJOB As New ClsJobDocketBatch
                OBJJOB.alParaval.Add(TEMPJOBNO)
                OBJJOB.alParaval.Add(CmpId)
                OBJJOB.alParaval.Add(YearId)
                Dim DTTABLE1 As DataTable = OBJJOB.selectNO(TEMPJOBNO, CmpId, YearId)

                If DTTABLE1.Rows.Count > 0 Then
                    For Each DR As DataRow In DTTABLE1.Rows

                        txtjobdocketno.Text = TEMPJOBNO
                        txtorderno.Text = Convert.ToString(DR("ORDERNO"))
                        TXTORDERGSRNO.Text = Convert.ToString(DR("ORDERSRNO"))
                        txtpartyname.Text = Convert.ToString(DR("PARTYNAME"))
                        txtpono.Text = Convert.ToString(DR("PONO"))
                        jobdate.Text = Convert.ToString(DR("DATE"))
                        txtitemcode.Text = Convert.ToString(DR("MAINITEMCODE"))
                        txtfileno.Text = Convert.ToString(DR("FILENO"))
                        txtgsm.Text = Convert.ToString(DR("PPRGSM"))
                        txtmaterial.Text = Convert.ToString(DR("MATERIAL"))
                        txtpapersize.Text = Convert.ToString(DR("PPRSIZE"))
                        txtdesign.Text = Convert.ToString(DR("DESIGN"))
                        txtgrain.Text = Convert.ToString(DR("GRAINDIRECTION"))
                        txtmaterialcode.Text = Convert.ToString(DR("MATERIALCODE"))
                        txtqty.Text = Format(Val(DR("QTY")), "0")
                        txtshadecard.Text = Convert.ToString(DR("SHADECARD"))
                        TXTPOSITIVENEGATIVE.Text = DR("POSITIVENEGATIVE")
                        txtleafletsize.Text = Convert.ToString(DR("LEAFLETSIZE"))
                        txtfoldingsize.Text = Convert.ToString(DR("FOLDINGSIZE"))
                        txtcutsize.Text = Convert.ToString(DR("CUTSIZE"))
                        txtups.Text = Convert.ToString(DR("UPS"))
                        txttotalsheets.Text = Convert.ToString(DR("TOTALSHEETS"))
                        If Convert.ToBoolean(DR("DONE")) = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If
                        TXTPERCENTAGE.Text = Convert.ToString(DR("PERCENTAGE"))
                        TXTSHIPTO.Text = Convert.ToString(DR("SHIPTO"))
                        TXTMAINITEM.Text = Convert.ToString(DR("MAINITEMNAME"))
                        TXTORDERTYPE.Text = Convert.ToString(DR("ORDERTYPE"))
                        TXTJOBQTY.Text = Convert.ToString(DR("QTY"))
                        TXTCOL1.Text = Convert.ToString(DR("COL"))
                        TXTCOL2.Text = Convert.ToString(DR("COL2"))
                        CMBMODE.Text = Convert.ToString(DR("MODE"))
                        TXTCOL1PLATES.Text = Convert.ToString(DR("COL1PLATES"))
                        TXTCOL2PLATES.Text = Convert.ToString(DR("COL2PLATES"))
                        CMBCOL1PLATETYPE.Text = Convert.ToString(DR("COL1PLATETYPE"))
                        CMBCOL2PLATETYPE.Text = Convert.ToString(DR("COL2PLATETYPE"))

                        TXTGUPS.Text = Convert.ToString(DR("OPENUPS"))
                        TXTCUTSHEET.Text = Convert.ToString(DR("CUTSHEET"))
                        TXTEXTRA.Text = Convert.ToString(DR("EXTRA"))
                        TXTTOTAL.Text = Convert.ToString(DR("TOTAL"))
                        TXTTIME.Text = Convert.ToString(DR("PRODUCEQTY")) 'its saved as produced qty
                        TXTCUTSIZEG.Text = Convert.ToString(DR("GCUTSIZE"))
                        TXTCOLORUPS.Text = Convert.ToString(DR("COLORUPS"))
                        TXTCOLORSHEET.Text = Convert.ToString(DR("COLORSHEET"))
                        TXTFULLSIZE.Text = Convert.ToString(DR("FULLSIZE"))
                        TXTBOMITEMCODE.Text = Convert.ToString(DR("SUBITEMCODE"))
                        CMBLAMM.Text = Convert.ToString(DR("LAMINATIONON"))
                        TXTYIELD.Text = Convert.ToString(DR("YIELD"))
                        TXTSHEETS.Text = Convert.ToString(DR("SHEETS"))
                        TXTFILMSIZE.Text = Format(Val(DR("FILMSIZE")), "0.00")
                        TXTFILMSIZE2.Text = Format(Val(DR("FILMSIZE2")), "0.00")
                        TXTKGS.Text = Convert.ToString(DR("KGS"))
                        CMBLAMINATION.Text = Convert.ToString(DR("LAMINATION"))
                        CMBUV.Text = Convert.ToString(DR("UV"))
                        CMBPUNCHING.Text = Convert.ToString(DR("PUNCHING"))
                        CMBENVELOPE.Text = Convert.ToString(DR("ENVELOPE"))
                        CMBGUMMING.Text = Convert.ToString(DR("GUMMING"))
                        CMBBINDING.Text = Convert.ToString(DR("BINDING"))
                        CMBNUMBERING.Text = Convert.ToString(DR("NUMBERING"))
                        CMBFABRICATION.Text = Convert.ToString(DR("FABRICATION"))
                        CMBPACKING.Text = Convert.ToString(DR("PACKING"))
                        CMBNONINVITEM.Text = Convert.ToString(DR("NONINVITEM"))
                        TXTPREVJOBNO.Text = Convert.ToString(DR("PREVJOBNO"))
                        DTPREV.Text = Convert.ToString(DR("PREVDATE"))
                        CMBMACHINE.Text = Convert.ToString(DR("MACHINE"))
                        CMBOUTVENDORNAME.Text = Convert.ToString(DR("OUTVENDORNAME"))
                        TXTOPENSIZE.Text = Convert.ToString(DR("OPENSIZE"))
                        TXTCLOSESIZE.Text = Convert.ToString(DR("CLOSESIZE"))
                        CMBLAMMODE.Text = Convert.ToString(DR("LAMMODE"))
                        TXTLAMINATION1.Text = Convert.ToString(DR("LAMINATION1"))
                        TXTLAMINATION2.Text = Convert.ToString(DR("LAMINATION2"))
                        CMBLAM.Text = Convert.ToString(DR("LAM"))
                        CMBLUV.Text = Convert.ToString(DR("LUV"))
                        CMBLPUNCHING.Text = Convert.ToString(DR("LPUNCHING"))
                        CMBLENVELOPE.Text = Convert.ToString(DR("LENVELOPE"))
                        CMBLGUM.Text = Convert.ToString(DR("LGUMMING"))
                        CMBLBINDING.Text = Convert.ToString(DR("LBINDING"))
                        CMBLNUMBERING.Text = Convert.ToString(DR("LNUMBERING"))
                        CMBLFABRICATION.Text = Convert.ToString(DR("LFABRICATION"))
                        CMBVENDOR.Text = Convert.ToString(DR("VENDOR"))
                        CMBVENDOR1.Text = Convert.ToString(DR("VENDOR1"))
                        CMBLPACKING.Text = Convert.ToString(DR("LPACKING"))
                        CMBLAM1.Text = Convert.ToString(DR("MODE1"))
                        CMBLAM2.Text = Convert.ToString(DR("MODE2"))
                        TXTPRODFINISHQTY.Text = Convert.ToString(DR("PRODFINISHQTY"))
                        TXTPROPRINTINGQTY.Text = Convert.ToString(DR("PRODPRINTINGQTY"))

                        TXTLAMINATIONUPS.Text = Convert.ToString(DR("LAMINATIONUPS"))
                        TXTPUNCHINGUPS.Text = Convert.ToString(DR("PUNCHINGUPS"))
                        TXTFINALUPS.Text = Convert.ToString(DR("FINALUPS"))
                        TXTFOLDINGUPS.Text = Convert.ToString(DR("FOLDINGUPS"))
                        TXTNUMBERINGUPS.Text = Convert.ToString(DR("NUMBERINGUPS"))


                        If Convert.ToBoolean(DR("REQDONE")) = True Then
                            LBLREQDONE.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If Convert.ToBoolean(DR("FINISHED")) = True Then
                            LBLFINISHED.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If Val(DR("OUTQTY")) > 0 Then
                            LBLPRINTPRODONE.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If Val(DR("JOBCLOSE")) = True Then
                            LBLCLOSE.Visible = True
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                End If

                CMDSELECTORDER.Enabled = False

            Else
                edit = False
                CLEAR()
            End If

        Catch ex As Exception
            Throw ex
        End Try
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
            ALPARAVAL.Add(txtjobdocketno.Text.Trim)
            ALPARAVAL.Add(Val(txtorderno.Text.Trim))
            ALPARAVAL.Add(Val(TXTORDERGSRNO.Text.Trim))
            ALPARAVAL.Add(txtpartyname.Text.Trim)
            ALPARAVAL.Add(txtpono.Text.Trim)
            ALPARAVAL.Add(jobdate.Value.Date)
            ALPARAVAL.Add(txtitemcode.Text.Trim)
            ALPARAVAL.Add(Val(txtqty.Text.Trim))
            ALPARAVAL.Add(Val(TXTPERCENTAGE.Text.Trim))
            ALPARAVAL.Add(txtshadecard.Text.Trim)
            ALPARAVAL.Add(TXTPOSITIVENEGATIVE.Text.Trim)
            ALPARAVAL.Add(Val(txttotalsheets.Text.Trim))

            If chkdone.CheckState = True Then
                ALPARAVAL.Add(1)
            Else
                ALPARAVAL.Add(0)
            End If
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)
            ALPARAVAL.Add(TXTSHIPTO.Text.Trim)
            ALPARAVAL.Add(TXTMAINITEM.Text.Trim)
            ALPARAVAL.Add(TXTORDERTYPE.Text.Trim)

            ALPARAVAL.Add(Val(TXTJOBQTY.Text.Trim))
            ALPARAVAL.Add(Val(TXTCOL1.Text.Trim))
            ALPARAVAL.Add(Val(TXTCOL2.Text.Trim))
            ALPARAVAL.Add(CMBMODE.Text.Trim)
            ALPARAVAL.Add(Val(TXTCOL1PLATES.Text.Trim))
            ALPARAVAL.Add(Val(TXTCOL2PLATES.Text.Trim))
            ALPARAVAL.Add(CMBCOL1PLATETYPE.Text.Trim)
            ALPARAVAL.Add(CMBCOL2PLATETYPE.Text.Trim)
            ALPARAVAL.Add(Val(TXTGUPS.Text.Trim))
            ALPARAVAL.Add(Val(TXTCUTSHEET.Text.Trim))
            ALPARAVAL.Add(Val(TXTEXTRA.Text.Trim))
            ALPARAVAL.Add(Val(TXTTOTAL.Text.Trim))
            ALPARAVAL.Add(Val(TXTTIME.Text.Trim)) 'its saved as produced qty
            ALPARAVAL.Add(TXTCUTSIZEG.Text.Trim)
            ALPARAVAL.Add(Val(TXTCOLORUPS.Text.Trim))
            ALPARAVAL.Add(Val(TXTCOLORSHEET.Text.Trim))
            ALPARAVAL.Add(TXTFULLSIZE.Text.Trim)
            ALPARAVAL.Add(TXTBOMITEMCODE.Text.Trim)
            ALPARAVAL.Add(CMBLAMM.Text.Trim)
            ALPARAVAL.Add(Val(TXTYIELD.Text.Trim))
            ALPARAVAL.Add(TXTSHEETS.Text.Trim)
            ALPARAVAL.Add(Val(TXTFILMSIZE.Text.Trim))
            ALPARAVAL.Add(Val(TXTFILMSIZE2.Text.Trim))
            ALPARAVAL.Add(Val(TXTKGS.Text.Trim))
            ALPARAVAL.Add(CMBLAMINATION.Text.Trim)
            ALPARAVAL.Add(CMBUV.Text.Trim)
            ALPARAVAL.Add(CMBPUNCHING.Text.Trim)
            ALPARAVAL.Add(CMBENVELOPE.Text.Trim)
            ALPARAVAL.Add(CMBGUMMING.Text.Trim)
            ALPARAVAL.Add(CMBBINDING.Text.Trim)
            ALPARAVAL.Add(CMBNUMBERING.Text.Trim)
            ALPARAVAL.Add(CMBFABRICATION.Text.Trim)
            ALPARAVAL.Add(CMBPACKING.Text.Trim)
            ALPARAVAL.Add(CMBNONINVITEM.Text.Trim)
            ALPARAVAL.Add(Val(TXTPREVJOBNO.Text.Trim))
            ALPARAVAL.Add(Format(Convert.ToDateTime(DTPREV.Text).Date, "MM/dd/yyyy"))
            ALPARAVAL.Add(CMBMACHINE.Text.Trim)
            ALPARAVAL.Add(CMBOUTVENDORNAME.Text.Trim)
            ALPARAVAL.Add(TXTOPENSIZE.Text.Trim)
            ALPARAVAL.Add(TXTCLOSESIZE.Text.Trim)
            ALPARAVAL.Add(CMBLAMMODE.Text.Trim)
            ALPARAVAL.Add(CMBLAM.Text.Trim)
            ALPARAVAL.Add(CMBLUV.Text.Trim)
            ALPARAVAL.Add(CMBLPUNCHING.Text.Trim)
            ALPARAVAL.Add(CMBLENVELOPE.Text.Trim)
            ALPARAVAL.Add(CMBLGUM.Text.Trim)
            ALPARAVAL.Add(CMBLBINDING.Text.Trim)
            ALPARAVAL.Add(CMBLNUMBERING.Text.Trim)
            ALPARAVAL.Add(CMBLFABRICATION.Text.Trim)
            ALPARAVAL.Add(TXTLAMINATION1.Text.Trim)
            ALPARAVAL.Add(TXTLAMINATION2.Text.Trim)
            ALPARAVAL.Add(CMBVENDOR.Text.Trim)
            ALPARAVAL.Add(CMBVENDOR1.Text.Trim)
            ALPARAVAL.Add(CMBLPACKING.Text.Trim)
            ALPARAVAL.Add(CMBLAM1.Text.Trim)
            ALPARAVAL.Add(CMBLAM2.Text.Trim)
            ALPARAVAL.Add(Val(txtups.Text.Trim))
            ALPARAVAL.Add(Val(TXTPRODFINISHQTY.Text.Trim))
            ALPARAVAL.Add(Val(TXTPROPRINTINGQTY.Text.Trim))
            ALPARAVAL.Add(Val(TXTLAMINATIONUPS.Text.Trim))
            ALPARAVAL.Add(Val(TXTPUNCHINGUPS.Text.Trim))
            ALPARAVAL.Add(Val(TXTFINALUPS.Text.Trim))
            ALPARAVAL.Add(Val(TXTFOLDINGUPS.Text.Trim))
            ALPARAVAL.Add(Val(TXTNUMBERINGUPS.Text.Trim))

            Dim objjob As New ClsJobDocketBatch
            objjob.alParaval = ALPARAVAL

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim dttable As DataTable = objjob.SAVE()
                TEMPJOBNO = dttable.Rows(0).Item(0)
                MessageBox.Show("Deatils Added !!")
                'PRINTREPORT(dttable.Rows(0).Item(0))
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                ALPARAVAL.Add(TEMPJOBNO)
                IntResult = objjob.UPDATE()
                MessageBox.Show("Details Updated!!")
                'PRINTREPORT(TEMPJOBNO)
                edit = False
            End If

            CLEAR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function ERRORVALID() As Boolean
        Dim bln As Boolean = True

        If ClientName = "AMR" Then
            If txtjobdocketno.Text.Trim = "" Or TXTMAINITEM.Text.Trim = "" Or txtqty.Text.Trim = "" Or txtups.Text.Trim = "" Or txtorderno.Text.Trim = "" Or TXTORDERGSRNO.Text.Trim = "" Then
                EP.SetError(txtpartyname, " Please Fill Proper details ")
                bln = False
            End If

            If Val(txtups.Text.Trim) = 0 Or txtups.Text.Trim = "" Then
                EP.SetError(txtups, " Please Fill No Ups In Item Master ")
                bln = False
            End If

        End If

        'If txtpono.Text.Trim.Length = 0 Then
        '    EP.SetError(txtpono, "Select Order for Docket")
        '    bln = False
        'End If

        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, " Item is locked. ")
            bln = False
        End If

        If LBLFINISHED.Visible = True Then
            EP.SetError(LBLFINISHED, " Job Finished..!!. ")
            bln = False
        End If



        If LBLREQDONE.Visible = True Then
            EP.SetError(LBLREQDONE, " Purchase Request Done..!!. ")
            bln = False
        End If
        If LBLPRINTPRODONE.Visible = True Then
            EP.SetError(LBLPRINTPRODONE, " Printing Production Done..!!. ")
            bln = False
        End If

        If LBLCLOSE.Visible = True Then
            EP.SetError(LBLCLOSE, "Job Docket Close..!!. ")
            bln = False
        End If

        If Not datecheck(jobdate.Value) Then
            EP.SetError(jobdate, "Date Not in Current Accounting Year")
            bln = False
        End If

        'If Val(txtorderno.Text.Trim) > 0 And Val(TXTORDERGSRNO.Text.Trim) > 0 And edit = False Then
        '    Dim OBJCMN As New ClsCommon
        '    Dim dttable As DataTable = OBJCMN.search(" JOB_NO AS JOBNO ", "", " JOBMASTER ", "   AND JOB_ORDERNO=" & Val(txtorderno.Text.Trim) & " AND JOB_ORDERSRNO = " & Val(TXTORDERGSRNO.Text.Trim) & " AND JOB_YEARID = " & YearId)
        '    If dttable.Rows.Count > 0 Then
        '        EP.SetError(txtpono, "Order No Already Exist")
        '        bln = False
        '    End If
        'End If

        If Val(txtjobdocketno.Text.Trim) > 0 And edit = False Then
            Dim OBJCMN As New ClsCommon
            Dim dttable As DataTable = OBJCMN.search(" ISNULL(JOBBATCHMASTER. job_no,0)  AS JOBBATCHNO", "", " JOBBATCHMASTER ", "  AND JOBBATCHMASTER.job_NO=" & txtjobdocketno.Text.Trim & " AND JOBBATCHMASTER.job_YEARID = " & YearId)
            If dttable.Rows.Count > 0 Then
                MsgBox("Job Batch No Already Exist")
                bln = False
            End If
        End If

        If ClientName = "GANESHMUDRA" Then

            If CMBNONINVITEM.Text.Trim.Length = 0 Or CMBLAMINATION.Text.Trim.Length = 0 Or CMBUV.Text.Trim.Length = 0 Or CMBPUNCHING.Text.Trim.Length = 0 Or CMBENVELOPE.Text.Trim.Length = 0 Or CMBGUMMING.Text.Trim.Length = 0 Or CMBBINDING.Text.Trim.Length = 0 Or CMBNUMBERING.Text.Trim.Length = 0 Or CMBFABRICATION.Text.Trim.Length = 0 Then
                EP.SetError(GroupBox2, " Please Fill details 2 ")
                bln = False
            End If


            If txtqty.Text.Trim = "" And TXTGUPS.Text.Trim = "" Or TXTEXTRA.Text.Trim = "" Or TXTCUTSHEET.Text.Trim = "" Or TXTTOTAL.Text.Trim = "" Or TXTCUTSIZEG.Text.Trim = "" Or TXTCOLORUPS.Text.Trim = "" Or TXTFULLSIZE.Text.Trim = "" Or TXTCOLORSHEET.Text.Trim = "" Then
                EP.SetError(GroupBox2, " Please Fill details 1 ")
                bln = False
            End If

            If CMBLAMINATION.Text = "Yes" Then
                If CMBLAMM.Text.Trim.Length = 0 Or TXTYIELD.Text.Trim = "" Or CMBLAMMODE.Text.Trim.Length = 0 Or TXTSHEETS.Text.Trim = "" Or TXTFILMSIZE.Text.Trim = "" Or TXTFILMSIZE2.Text.Trim = "" Or TXTKGS.Text.Trim = "" Then
                    EP.SetError(CMBLAMM, " Please Fill details ")
                    bln = False
                End If

            End If

        End If

        If Val(TXTLAMINATIONUPS.Text.Trim) = 0 Then TXTLAMINATIONUPS.Text = 1
        If Val(TXTPUNCHINGUPS.Text.Trim) = 0 Then TXTPUNCHINGUPS.Text = 1
        If Val(TXTFINALUPS.Text.Trim) = 0 Then TXTFINALUPS.Text = 1
        If Val(TXTFOLDINGUPS.Text.Trim) = 0 Then TXTFOLDINGUPS.Text = 1
        If Val(TXTNUMBERINGUPS.Text.Trim) = 0 Then TXTNUMBERINGUPS.Text = 1

        Return bln
    End Function

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try

LINE1:
            TEMPJOBNO = Val(txtjobdocketno.Text) - 1
Line2:
            If TEMPJOBNO > 0 Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" job_no ", "", " JOBBATCHMASTER", " AND job_no = '" & TEMPJOBNO & "' AND job_yearid = " & YearId)
                If DT.Rows.Count > 0 Then
                    edit = True
                    JobDocketBatch_Load(sender, e)
                Else
                    TEMPJOBNO = Val(TEMPJOBNO - 1)
                    GoTo Line2
                End If
            Else
                CLEAR()
                edit = False
            End If

            'If GRIDPLATE.RowCount = 0 And TEMPISSUENO > 1 Then
            '    TXTISSUENO.Text = TEMPISSUENO
            '    GoTo LINE1
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub
  Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            txtpartyname.Clear()
LINE1:
            TEMPJOBNO = Val(txtjobdocketno.Text) + 1
            getmax_job_no()
            Dim MAX As Integer = txtjobdocketno.Text.Trim
            CLEAR()
            If Val(txtjobdocketno.Text) - 1 >= TEMPJOBNO Then
                edit = True
                JobDocketBatch_Load(sender, e)
            Else
                edit = False
                CLEAR()
            End If
            If txtpartyname.Text = "" And TEMPJOBNO < MAX Then
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

    Sub FETCHDATA(ByVal PONO As String, ByVal ORDERNO As Integer, ByVal ORDERSRNO As Integer, ByVal TYPE As String, ByVal SUBITEMCODE As String)
        Try
            Dim objcmn As New ClsCommon
            'Dim dt As DataTable = objcmn.search(" ISNULL(ORDERMASTER.ORDER_NO,0) AS ORDERNO, ISNULL(ORDERMASTER_DESC.ORDER_GRIDSRNO,0) AS ORDERSRNO,ISNULL(LEDGERS.Acc_cmpname,'') AS PARTYNAME,ISNULL(ORDERMASTER.ORDER_pono,'') AS ORDERPONO, ISNULL(ORDERMASTER.ORDER_SHADECARD,'') AS SHADECARD, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_fileno, '') AS FILENO, ISNULL(ORDERMASTER_DESC.ORDER_QTY, 0)-ISNULL(ORDERMASTER_DESC.ORDER_OUTQTY, 0)  AS QUANTITY, ISNULL(ITEMMASTER.item_name,'') AS ITEMNAME, ISNULL(PAPERGSMMASTER.PAPERGSM_NAME, '') AS PAPERGSM, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR,ISNULL(ITEMMASTER.item_actualsize, '') AS LEAFLETSIZE, ISNULL(ITEMMASTER.item_sizefolding, '') AS FOLDINGSIZE, ISNULL(PAPERMATERIALMASTER.PAPERMATERIAL_NAME, '') AS MATERIAL, ISNULL(ITEMMASTER.item_cutsize, '') AS CUTSIZE, ISNULL(ITEMMASTER.item_ups, '')AS NOOFUPS, ISNULL(PAPERSIZEMASTER.PAPERSIZE_NAME, '') AS PAPERSIZE, ISNULL(grainmaster.grain_name, '') AS GRAIN, ISNULL(designmaster.design_name,'') AS DESIGN", "", "ORDERMASTER INNER JOIN ORDERMASTER_DESC ON ORDERMASTER.ORDER_NO = ORDERMASTER_DESC.ORDER_NO AND ORDERMASTER.ORDER_YEARID = ORDERMASTER_DESC.ORDER_YEARID INNER JOIN LEDGERS ON ORDERMASTER.ORDER_LEDGERID = LEDGERS.Acc_id AND ORDERMASTER.ORDER_YEARID = LEDGERS.Acc_yearid LEFT OUTER JOIN ITEMMASTER ON ORDERMASTER_DESC.ORDER_ITEMID = ITEMMASTER.item_id AND ORDERMASTER_DESC.ORDER_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN COLORMASTER ON ITEMMASTER.item_colorid = COLORMASTER.COLOR_id AND ITEMMASTER.item_yearid = COLORMASTER.COLOR_yearid LEFT OUTER JOIN grainmaster ON ITEMMASTER.item_grainid = grainmaster.grain_id AND ITEMMASTER.item_yearid = grainmaster.grain_yearid LEFT OUTER JOIN designmaster ON ITEMMASTER.item_designid = designmaster.design_id AND ITEMMASTER.item_yearid = designmaster.design_yearid LEFT OUTER JOIN PAPERSIZEMASTER ON ITEMMASTER.item_papersizeid = PAPERSIZEMASTER.PAPERSIZE_ID AND ITEMMASTER.item_yearid = PAPERSIZEMASTER.PAPERSIZE_YEARID LEFT OUTER JOIN PAPERMATERIALMASTER ON ITEMMASTER.item_papermaterialid = PAPERMATERIALMASTER.PAPERMATERIAL_ID AND ITEMMASTER.item_yearid = PAPERMATERIALMASTER.PAPERMATERIAL_YEARID LEFT OUTER JOIN PAPERGSMMASTER ON ITEMMASTER.item_papergsmid = PAPERGSMMASTER.PAPERGSM_ID AND ITEMMASTER.item_yearid = PAPERGSMMASTER.PAPERGSM_YEARID AND ITEMMASTER.item_yearid = PAPERGSMMASTER.PAPERGSM_YEARID", "AND ORDERMASTER.ORDER_NO =" & ORDERDT.Rows(0).Item(0) & " AND ORDERMASTER_DESC.ORDER_GRIDSRNO = " & ORDERDT.Rows(0).Item(1))
            'Dim dt As DataTable = objcmn.search("ISNULL(LEDGERS.Acc_cmpname, '') AS PARTYNAME, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(PAPERGSMMASTER.PAPERGSM_NAME, '') AS PAPERGSM, ISNULL(PAPERSIZEMASTER.PAPERSIZE_NAME, '') AS PAPERSIZE, ISNULL(DESIGNMASTER.design_name, '') AS DESIGN, ISNULL(PAPERMATERIALMASTER.PAPERMATERIAL_NAME, '') AS MATERIAL, ISNULL(ALLORDERMASTER.ORDER_NO, 0) AS ORDERNO, ISNULL(ALLORDERMASTER_DESC.ORDER_GRIDSRNO, 0) AS ORDERSRNO, ISNULL(ALLORDERMASTER.ORDER_PONO, '0') AS ORDERPONO, ISNULL(ALLORDERMASTER.ORDER_SHADECARD, '') AS SHADECARD, ISNULL(ALLORDERMASTER.ORDER_POSITIVENEGATIVE, '') AS POSITIVENEGATIVE, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_fileno, '') AS FILENO, ISNULL(ITEMMASTER.item_actualsizewidth, '') AS LEAFLETSIZE, ISNULL(ITEMMASTER.item_sizefoldingwidth, '') AS FOLDINGSIZE, ISNULL(ITEMMASTER.item_cutsize, '') AS CUTSIZE, ISNULL(ITEMMASTER.item_ups, '') AS NOOFUPS, ISNULL(ITEMMASTER.ITEM_MATERIALCODE, '') AS MATERIALCODE, ISNULL(GRAINMASTER.grain_name, '') AS GRAIN, ISNULL(ALLORDERMASTER_DESC.ORDER_QTY, 0) - ISNULL(ALLORDERMASTER_DESC.ORDER_OUTQTY, 0) AS QUANTITY, ISNULL(SHIPTOLEDGERS.Acc_cmpname, '') AS SHIPTO, ISNULL(ALLORDERMASTER.TYPE, '') AS TYPE", "", "  LEDGERS AS SHIPTOLEDGERS RIGHT OUTER JOIN ALLORDERMASTER INNER JOIN ALLORDERMASTER_DESC ON ALLORDERMASTER.ORDER_NO = ALLORDERMASTER_DESC.ORDER_NO AND ALLORDERMASTER.ORDER_YEARID = ALLORDERMASTER_DESC.ORDER_YEARID LEFT OUTER JOIN LEDGERS ON ALLORDERMASTER.ORDER_LEDGERID = LEDGERS.Acc_id AND ALLORDERMASTER.ORDER_YEARID = LEDGERS.Acc_yearid ON SHIPTOLEDGERS.Acc_id = ALLORDERMASTER.ORDER_SHIPTOID AND  SHIPTOLEDGERS.Acc_yearid = ALLORDERMASTER.ORDER_YEARID LEFT OUTER JOIN GRAINMASTER RIGHT OUTER JOIN ITEMMASTER ON GRAINMASTER.grain_id = ITEMMASTER.item_grainid AND GRAINMASTER.grain_yearid = ITEMMASTER.item_yearid LEFT OUTER JOIN PAPERMATERIALMASTER ON ITEMMASTER.item_papermaterialid = PAPERMATERIALMASTER.PAPERMATERIAL_ID AND ITEMMASTER.item_yearid = PAPERMATERIALMASTER.PAPERMATERIAL_YEARID LEFT OUTER JOIN DESIGNMASTER ON ITEMMASTER.item_designid = DESIGNMASTER.design_id AND ITEMMASTER.item_yearid = DESIGNMASTER.design_yearid LEFT OUTER JOIN PAPERSIZEMASTER ON ITEMMASTER.item_papersizeid = PAPERSIZEMASTER.PAPERSIZE_ID AND ITEMMASTER.item_yearid = PAPERSIZEMASTER.PAPERSIZE_YEARID LEFT OUTER JOIN PAPERGSMMASTER ON ITEMMASTER.item_papergsmid = PAPERGSMMASTER.PAPERGSM_ID AND ITEMMASTER.item_yearid = PAPERGSMMASTER.PAPERGSM_YEARID LEFT OUTER JOIN COLORMASTER ON ITEMMASTER.item_colorid = COLORMASTER.COLOR_id AND ITEMMASTER.item_yearid = COLORMASTER.COLOR_yearid ON ALLORDERMASTER_DESC.ORDER_ITEMID = ITEMMASTER.item_id AND  ALLORDERMASTER_DESC.ORDER_YEARID = ITEMMASTER.item_yearid ", "  AND ALLORDERMASTER.ORDER_PONO = '" & PONO & "' AND ALLORDERMASTER.ORDER_NO = " & ORDERNO & " AND ALLORDERMASTER_DESC.ORDER_GRIDSRNO = " & ORDERSRNO & " AND ALLORDERMASTER.ORDER_YEARID = " & YearId)
            ' Dim dt As DataTable = objcmn.search("ISNULL(LEDGERS.Acc_cmpname, '') AS PARTYNAME, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(PAPERGSMMASTER.PAPERGSM_NAME, '') AS PAPERGSM, ISNULL(PAPERSIZEMASTER.PAPERSIZE_NAME, '') AS PAPERSIZE, ISNULL(DESIGNMASTER.design_name, '') AS DESIGN, ISNULL(PAPERMATERIALMASTER.PAPERMATERIAL_NAME, '') AS MATERIAL, ISNULL(ALLORDERMASTER.ORDER_NO, 0) AS ORDERNO, ISNULL(ALLORDERMASTER_DESC.ORDER_GRIDSRNO, 0) AS ORDERSRNO, ISNULL(ALLORDERMASTER.ORDER_PONO, '0') AS ORDERPONO, ISNULL(ALLORDERMASTER.ORDER_SHADECARD, '') AS SHADECARD, ISNULL(ALLORDERMASTER.ORDER_POSITIVENEGATIVE, '') AS POSITIVENEGATIVE, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_fileno, '') AS FILENO, ISNULL(ITEMMASTER.item_actualsizewidth, '') AS LEAFLETSIZE, ISNULL(ITEMMASTER.item_sizefoldingwidth, '') AS FOLDINGSIZE, ISNULL(ITEMMASTER.item_cutsize, '') AS CUTSIZE, ISNULL(ITEMMASTER.ITEM_MATERIALCODE, '') AS MATERIALCODE, ISNULL(GRAINMASTER.grain_name, '') AS GRAIN, ISNULL(ALLORDERMASTER_DESC.ORDER_QTY, 0) - ISNULL(ALLORDERMASTER_DESC.ORDER_OUTQTY, 0) AS QUANTITY, ISNULL(SHIPTOLEDGERS.Acc_cmpname, '') AS SHIPTO, ISNULL(ALLORDERMASTER.TYPE, '') AS TYPE, ISNULL(SUBITEMMASTER.item_code, '') AS SUBITEMCODE, ISNULL(COALESCE(SUBITEMMASTER.item_UPS, ITEMMASTER.item_ups),'')  AS NOOFUPS ", "", " PAPERGSMMASTER RIGHT OUTER JOIN ITEMMASTER_BOMDETAILS LEFT OUTER JOIN ITEMMASTER AS SUBITEMMASTER ON ITEMMASTER_BOMDETAILS.ITEM_SUBITEMID = SUBITEMMASTER.item_id RIGHT OUTER JOIN ITEMMASTER ON ITEMMASTER_BOMDETAILS.ITEM_ID = ITEMMASTER.item_id LEFT OUTER JOIN GRAINMASTER ON ITEMMASTER.item_grainid = GRAINMASTER.grain_id AND ITEMMASTER.item_yearid = GRAINMASTER.grain_yearid LEFT OUTER JOIN PAPERMATERIALMASTER ON ITEMMASTER.item_papermaterialid = PAPERMATERIALMASTER.PAPERMATERIAL_ID AND ITEMMASTER.item_yearid = PAPERMATERIALMASTER.PAPERMATERIAL_YEARID LEFT OUTER JOIN DESIGNMASTER ON ITEMMASTER.item_designid = DESIGNMASTER.design_id AND ITEMMASTER.item_yearid = DESIGNMASTER.design_yearid LEFT OUTER JOIN PAPERSIZEMASTER ON ITEMMASTER.item_papersizeid = PAPERSIZEMASTER.PAPERSIZE_ID AND ITEMMASTER.item_yearid = PAPERSIZEMASTER.PAPERSIZE_YEARID ON  PAPERGSMMASTER.PAPERGSM_ID = ITEMMASTER.item_papergsmid AND PAPERGSMMASTER.PAPERGSM_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN COLORMASTER ON ITEMMASTER.item_colorid = COLORMASTER.COLOR_id AND ITEMMASTER.item_yearid = COLORMASTER.COLOR_yearid RIGHT OUTER JOIN LEDGERS AS SHIPTOLEDGERS RIGHT OUTER JOIN ALLORDERMASTER INNER JOIN ALLORDERMASTER_DESC ON ALLORDERMASTER.ORDER_NO = ALLORDERMASTER_DESC.ORDER_NO AND ALLORDERMASTER.ORDER_YEARID = ALLORDERMASTER_DESC.ORDER_YEARID LEFT OUTER JOIN LEDGERS ON ALLORDERMASTER.ORDER_LEDGERID = LEDGERS.Acc_id AND ALLORDERMASTER.ORDER_YEARID = LEDGERS.Acc_yearid ON SHIPTOLEDGERS.Acc_id = ALLORDERMASTER.ORDER_SHIPTOID AND  SHIPTOLEDGERS.Acc_yearid = ALLORDERMASTER.ORDER_YEARID ON ITEMMASTER.item_id = ALLORDERMASTER_DESC.ORDER_ITEMID AND ITEMMASTER.item_yearid = ALLORDERMASTER_DESC.ORDER_YEARID ", "  AND ALLORDERMASTER.ORDER_PONO = '" & PONO & "' AND ALLORDERMASTER.ORDER_NO = " & ORDERNO & " AND ALLORDERMASTER_DESC.ORDER_GRIDSRNO = " & ORDERSRNO & " AND ISNULL(SUBITEMMASTER.item_code,'') = '" & SUBITEMCODE & "' AND ALLORDERMASTER.ORDER_YEARID = " & YearId)
            ' Dim dt As DataTable = objcmn.search(" ISNULL(LEDGERS.Acc_cmpname, '') AS PARTYNAME, ISNULL(SHIPTOLEDGERS.Acc_cmpname, '') AS SHIPTO, ISNULL(SUBITEMMASTER.item_name, '') AS SUBITEMNAME,  ISNULL(COALESCE (BOMPAPERGSM.PAPERGSM_NAME, PAPERGSMMASTER.PAPERGSM_NAME), '') AS PAPERGSM, ISNULL(COALESCE (BOMGRAIN.grain_name, GRAINMASTER.grain_name), '') AS GRAIN, ISNULL(COALESCE (BOMPAPERSIZEMASTER.PAPERSIZE_NAME, PAPERSIZEMASTER.PAPERSIZE_NAME), '') AS PAPERSIZE, ISNULL(COALESCE (BOMPAPERMATERIALMASTER.PAPERMATERIAL_NAME,  PAPERMATERIALMASTER.PAPERMATERIAL_NAME), '') AS MATERIAL, ISNULL(COALESCE (BOMCOLOR.COLOR_name, COLORMASTER.COLOR_name), '') AS COLOR, ISNULL(COALESCE (BOMDESIGNMASTER.design_name, DESIGNMASTER.design_name), '') AS DESIGN, ISNULL(ALLORDERMASTER_DESC.ORDER_GRIDSRNO, 0) AS ORDERSRNO, ISNULL(ALLORDERMASTER.ORDER_NO, 0) AS ORDERNO, ISNULL(ALLORDERMASTER.ORDER_PONO, '') AS ORDERPONO, ISNULL(ALLORDERMASTER.ORDER_SHADECARD, '') AS SHADECARD, ISNULL(ALLORDERMASTER.ORDER_POSITIVENEGATIVE, '') AS POSITIVENEGATIVE,  ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(SUBITEMMASTER.item_code, '') AS SUBITEMCODE,  ISNULL(COALESCE (SUBITEMMASTER.ITEM_MATERIALCODE, ITEMMASTER.ITEM_MATERIALCODE), '') AS MATERIALCODE, ISNULL(COALESCE (SUBITEMMASTER.item_fileno, ITEMMASTER.item_fileno), '') AS FILENO,  ISNULL(COALESCE (SUBITEMMASTER.item_actualsizewidth, ITEMMASTER.item_actualsizewidth), '') AS LEAFLETSIZE, ISNULL(COALESCE (SUBITEMMASTER.item_sizefoldingwidth, ITEMMASTER.item_sizefoldingwidth), '')  AS FOLDINGSIZE, ISNULL(COALESCE (SUBITEMMASTER.item_cutsize, ITEMMASTER.item_cutsize), '') AS CUTSIZE, ISNULL(COALESCE (SUBITEMMASTER.item_ups, ITEMMASTER.item_ups), '') AS NOOFUPS,  ISNULL(ALLORDERMASTER_DESC.ORDER_QTY, 0) - ISNULL(ALLORDERMASTER_DESC.ORDER_OUTQTY, 0) AS QUANTITY, ISNULL(ALLORDERMASTER.TYPE, '') AS TYPE  ", "", " ALLORDERMASTER INNER JOIN ALLORDERMASTER_DESC ON ALLORDERMASTER.ORDER_YEARID = ALLORDERMASTER_DESC.ORDER_YEARID LEFT OUTER JOIN ITEMMASTER ON ALLORDERMASTER_DESC.ORDER_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS AS SHIPTOLEDGERS ON ALLORDERMASTER.ORDER_SHIPTOID = SHIPTOLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS ON ALLORDERMASTER.ORDER_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN JOBBATCHMASTER ON ALLORDERMASTER_DESC.ORDER_NO = JOBBATCHMASTER.job_orderno AND ALLORDERMASTER_DESC.ORDER_GRIDSRNO = JOBBATCHMASTER.job_ordersrno LEFT OUTER JOIN ITEMMASTER_BOMDETAILS ON ITEMMASTER.item_id = ITEMMASTER_BOMDETAILS.ITEM_ID LEFT OUTER JOIN ITEMMASTER AS SUBITEMMASTER ON ITEMMASTER_BOMDETAILS.ITEM_SUBITEMID = SUBITEMMASTER.item_id LEFT OUTER JOIN GRAINMASTER ON ITEMMASTER.item_grainid = GRAINMASTER.grain_id AND ITEMMASTER.item_yearid = GRAINMASTER.grain_yearid LEFT OUTER JOIN GRAINMASTER AS BOMGRAIN ON SUBITEMMASTER.item_grainid = BOMGRAIN.grain_id AND SUBITEMMASTER.item_yearid = BOMGRAIN.grain_yearid LEFT OUTER JOIN  PAPERGSMMASTER ON ITEMMASTER.item_papergsmid = PAPERGSMMASTER.PAPERGSM_ID AND ITEMMASTER.item_yearid = PAPERGSMMASTER.PAPERGSM_YEARID LEFT OUTER JOIN PAPERGSMMASTER AS BOMPAPERGSM ON SUBITEMMASTER.item_papergsmid = BOMPAPERGSM.PAPERGSM_ID AND SUBITEMMASTER.item_yearid = BOMPAPERGSM.PAPERGSM_YEARID LEFT OUTER JOIN PAPERSIZEMASTER ON ITEMMASTER.item_yearid = PAPERSIZEMASTER.PAPERSIZE_YEARID AND ITEMMASTER.item_papersizeid = PAPERSIZEMASTER.PAPERSIZE_ID LEFT OUTER JOIN PAPERSIZEMASTER AS BOMPAPERSIZEMASTER ON SUBITEMMASTER.item_papersizeid = BOMPAPERSIZEMASTER.PAPERSIZE_ID AND  SUBITEMMASTER.item_yearid = BOMPAPERSIZEMASTER.PAPERSIZE_YEARID LEFT OUTER JOIN PAPERMATERIALMASTER ON ITEMMASTER.item_papermaterialid = PAPERMATERIALMASTER.PAPERMATERIAL_ID AND ITEMMASTER.item_yearid = PAPERMATERIALMASTER.PAPERMATERIAL_YEARID LEFT OUTER JOIN PAPERMATERIALMASTER AS BOMPAPERMATERIALMASTER ON SUBITEMMASTER.item_papermaterialid = BOMPAPERMATERIALMASTER.PAPERMATERIAL_ID AND SUBITEMMASTER.item_yearid = BOMPAPERMATERIALMASTER.PAPERMATERIAL_YEARID LEFT OUTER JOIN COLORMASTER ON ITEMMASTER.item_colorid = COLORMASTER.COLOR_id AND ITEMMASTER.item_yearid = COLORMASTER.COLOR_yearid LEFT OUTER JOIN COLORMASTER AS BOMCOLOR ON SUBITEMMASTER.item_colorid = BOMCOLOR.COLOR_id AND SUBITEMMASTER.item_yearid = BOMCOLOR.COLOR_yearid LEFT OUTER JOIN DESIGNMASTER ON ITEMMASTER.item_designid = DESIGNMASTER.design_id AND ITEMMASTER.item_yearid = DESIGNMASTER.design_yearid LEFT OUTER JOIN DESIGNMASTER AS BOMDESIGNMASTER ON SUBITEMMASTER.item_designid = BOMDESIGNMASTER.design_id AND SUBITEMMASTER.item_yearid = BOMDESIGNMASTER.design_yearid ", "  AND ALLORDERMASTER.ORDER_PONO = '" & PONO & "' AND ALLORDERMASTER.ORDER_NO = " & ORDERNO & " AND ALLORDERMASTER_DESC.ORDER_GRIDSRNO = " & ORDERSRNO & " AND ISNULL(SUBITEMMASTER.item_code,'') = '" & SUBITEMCODE & "' AND ALLORDERMASTER.ORDER_YEARID = " & YearId)
            Dim dt As DataTable = objcmn.search(" ISNULL(LEDGERS.Acc_cmpname, '') AS PARTYNAME, ISNULL(SHIPTOLEDGERS.Acc_cmpname, '') AS SHIPTO, ISNULL(SUBITEMMASTER.item_name, '') AS SUBITEMNAME,  ISNULL(COALESCE (BOMPAPERGSM.PAPERGSM_NAME, PAPERGSMMASTER.PAPERGSM_NAME), '') AS PAPERGSM, ISNULL(COALESCE (BOMGRAIN.grain_name, GRAINMASTER.grain_name), '') AS GRAIN, ISNULL(COALESCE (BOMPAPERSIZEMASTER.PAPERSIZE_NAME, PAPERSIZEMASTER.PAPERSIZE_NAME), '') AS PAPERSIZE, ISNULL(COALESCE (BOMPAPERMATERIALMASTER.PAPERMATERIAL_NAME,  PAPERMATERIALMASTER.PAPERMATERIAL_NAME), '') AS MATERIAL, ISNULL(COALESCE (BOMCOLOR.COLOR_name, COLORMASTER.COLOR_name), '') AS COLOR, ISNULL(COALESCE (BOMDESIGNMASTER.design_name, DESIGNMASTER.design_name), '') AS DESIGN, ISNULL(ALLORDERMASTER_DESC.ORDER_GRIDSRNO, 0) AS ORDERSRNO, ISNULL(ALLORDERMASTER.ORDER_NO, 0) AS ORDERNO, ISNULL(ALLORDERMASTER.ORDER_PONO, '') AS ORDERPONO, ISNULL(ALLORDERMASTER.ORDER_SHADECARD, '') AS SHADECARD, ISNULL(ALLORDERMASTER.ORDER_POSITIVENEGATIVE, '') AS POSITIVENEGATIVE,  ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(SUBITEMMASTER.item_code, '') AS SUBITEMCODE,  ISNULL(COALESCE (SUBITEMMASTER.ITEM_MATERIALCODE, ITEMMASTER.ITEM_MATERIALCODE), '') AS MATERIALCODE, ISNULL(COALESCE (SUBITEMMASTER.item_fileno, ITEMMASTER.item_fileno), '') AS FILENO,  ISNULL(COALESCE (SUBITEMMASTER.item_actualsizewidth, ITEMMASTER.item_actualsizewidth), '') AS LEAFLETSIZE, ISNULL(COALESCE (SUBITEMMASTER.item_sizefoldingwidth, ITEMMASTER.item_sizefoldingwidth), '')  AS FOLDINGSIZE, ISNULL(COALESCE (SUBITEMMASTER.item_cutsize, ITEMMASTER.item_cutsize), '') AS CUTSIZE, ISNULL(COALESCE (SUBITEMMASTER.item_ups, ITEMMASTER.item_ups), '') AS NOOFUPS,  ISNULL(ALLORDERMASTER_DESC.ORDER_QTY, 0) - ISNULL(ALLORDERMASTER_DESC.ORDER_OUTQTY, 0) AS QUANTITY, ISNULL(ALLORDERMASTER.TYPE, '') AS TYPE , ROUND(ISNULL(ALLORDERMASTER_DESC.ORDER_QTY / ITEMMASTER.ITEM_BOXQTY,''),2) AS BOXREQ ,ROUND(ISNULL(ALLORDERMASTER_DESC.ORDER_QTY / ITEMMASTER.ITEM_TRAYQTY, ''),2) AS TRAYREQ  ", "", " ITEMMASTER AS SUBITEMMASTER left OUTER JOIN ITEMMASTER_BOMDETAILS ON SUBITEMMASTER.item_yearid = ITEMMASTER_BOMDETAILS.ITEM_YEARID AND SUBITEMMASTER.item_id = ITEMMASTER_BOMDETAILS.ITEM_SUBITEMID RIGHT OUTER JOIN ALLORDERMASTER INNER JOIN ALLORDERMASTER_DESC ON ALLORDERMASTER.ORDER_YEARID = ALLORDERMASTER_DESC.ORDER_YEARID AND ALLORDERMASTER.ORDER_NO = ALLORDERMASTER_DESC.ORDER_NO LEFT OUTER JOIN ITEMMASTER ON ALLORDERMASTER_DESC.ORDER_YEARID = ITEMMASTER.item_yearid AND ALLORDERMASTER_DESC.ORDER_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS AS SHIPTOLEDGERS ON ALLORDERMASTER.ORDER_SHIPTOID = SHIPTOLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS ON ALLORDERMASTER.ORDER_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN JOBBATCHMASTER ON ALLORDERMASTER_DESC.ORDER_NO = JOBBATCHMASTER.job_orderno AND ALLORDERMASTER_DESC.ORDER_GRIDSRNO = JOBBATCHMASTER.job_ordersrno ON  ITEMMASTER_BOMDETAILS.ITEM_ID = ITEMMASTER.item_id LEFT OUTER JOIN GRAINMASTER ON ITEMMASTER.item_grainid = GRAINMASTER.grain_id AND ITEMMASTER.item_yearid = GRAINMASTER.grain_yearid LEFT OUTER JOIN GRAINMASTER AS BOMGRAIN ON SUBITEMMASTER.item_grainid = BOMGRAIN.grain_id AND SUBITEMMASTER.item_yearid = BOMGRAIN.grain_yearid LEFT OUTER JOIN PAPERGSMMASTER ON ITEMMASTER.item_papergsmid = PAPERGSMMASTER.PAPERGSM_ID AND ITEMMASTER.item_yearid = PAPERGSMMASTER.PAPERGSM_YEARID LEFT OUTER JOIN PAPERGSMMASTER AS BOMPAPERGSM ON SUBITEMMASTER.item_papergsmid = BOMPAPERGSM.PAPERGSM_ID AND SUBITEMMASTER.item_yearid = BOMPAPERGSM.PAPERGSM_YEARID LEFT OUTER JOIN PAPERSIZEMASTER ON ITEMMASTER.item_yearid = PAPERSIZEMASTER.PAPERSIZE_YEARID AND ITEMMASTER.item_papersizeid = PAPERSIZEMASTER.PAPERSIZE_ID LEFT OUTER JOIN PAPERSIZEMASTER AS BOMPAPERSIZEMASTER ON SUBITEMMASTER.item_papersizeid = BOMPAPERSIZEMASTER.PAPERSIZE_ID AND  SUBITEMMASTER.item_yearid = BOMPAPERSIZEMASTER.PAPERSIZE_YEARID LEFT OUTER JOIN PAPERMATERIALMASTER ON ITEMMASTER.item_papermaterialid = PAPERMATERIALMASTER.PAPERMATERIAL_ID AND ITEMMASTER.item_yearid = PAPERMATERIALMASTER.PAPERMATERIAL_YEARID LEFT OUTER JOIN PAPERMATERIALMASTER AS BOMPAPERMATERIALMASTER ON SUBITEMMASTER.item_papermaterialid = BOMPAPERMATERIALMASTER.PAPERMATERIAL_ID AND  SUBITEMMASTER.item_yearid = BOMPAPERMATERIALMASTER.PAPERMATERIAL_YEARID LEFT OUTER JOIN COLORMASTER ON ITEMMASTER.item_colorid = COLORMASTER.COLOR_id AND ITEMMASTER.item_yearid = COLORMASTER.COLOR_yearid LEFT OUTER JOIN COLORMASTER AS BOMCOLOR ON SUBITEMMASTER.item_colorid = BOMCOLOR.COLOR_id AND SUBITEMMASTER.item_yearid = BOMCOLOR.COLOR_yearid LEFT OUTER JOIN DESIGNMASTER ON ITEMMASTER.item_designid = DESIGNMASTER.design_id AND ITEMMASTER.item_yearid = DESIGNMASTER.design_yearid LEFT OUTER JOIN DESIGNMASTER AS BOMDESIGNMASTER ON SUBITEMMASTER.item_designid = BOMDESIGNMASTER.design_id AND SUBITEMMASTER.item_yearid = BOMDESIGNMASTER.design_yearid  ", "  AND ALLORDERMASTER.ORDER_PONO = '" & PONO & "' AND ALLORDERMASTER.ORDER_NO = " & ORDERNO & " AND ALLORDERMASTER_DESC.ORDER_GRIDSRNO = " & ORDERSRNO & " AND ISNULL(SUBITEMMASTER.item_code,'') = '" & SUBITEMCODE & "' AND ALLORDERMASTER.ORDER_YEARID = " & YearId)



            If dt.Rows.Count > 0 Then
                For Each DR As DataRow In dt.Rows
                    txtorderno.Text = Convert.ToString(DR("ORDERNO"))
                    TXTORDERGSRNO.Text = Convert.ToString(DR("ORDERSRNO"))
                    txtpartyname.Text = Convert.ToString(DR("PARTYNAME"))
                    txtpono.Text = Convert.ToString(DR("ORDERPONO"))
                    txtshadecard.Text = Convert.ToString(DR("SHADECARD"))
                    TXTPOSITIVENEGATIVE.Text = Convert.ToString(DR("POSITIVENEGATIVE"))
                    txtitemcode.Text = Convert.ToString(DR("ITEMCODE"))
                    txtfileno.Text = Convert.ToString(DR("FILENO"))
                    txtqty.Text = Format(Val(DR("QUANTITY")), "0")
                    TXTMAINITEM.Text = Convert.ToString(DR("ITEMNAME"))
                    txtgsm.Text = Convert.ToString(DR("PAPERGSM"))
                    'txtcolor.Text = Convert.ToString(DR("COLOR"))
                    txtleafletsize.Text = Convert.ToString(DR("LEAFLETSIZE"))
                    txtfoldingsize.Text = Convert.ToString(DR("FOLDINGSIZE"))
                    txtmaterial.Text = Convert.ToString(DR("MATERIAL"))
                    txtcutsize.Text = Convert.ToString(DR("CUTSIZE"))
                    txtups.Text = Convert.ToString(DR("NOOFUPS"))
                    txtpapersize.Text = Convert.ToString(DR("PAPERSIZE"))
                    txtgrain.Text = Convert.ToString(DR("GRAIN"))
                    txtdesign.Text = Convert.ToString(DR("DESIGN"))
                    'txtsrno.Text = Convert.ToString(DR("FILENO"))
                    txtmaterialcode.Text = Convert.ToString(DR("MATERIALCODE"))
                    ' TXTMAINITEM.Text = Convert.ToString(DR("MAINITEMNAME"))
                    TXTSHIPTO.Text = Convert.ToString(DR("SHIPTO"))
                    TXTORDERTYPE.Text = Convert.ToString(DR("TYPE"))
                    TXTBOMITEMCODE.Text = Convert.ToString(DR("SUBITEMCODE"))
                    TXTJOBQTY.Text = Format(Val(DR("QUANTITY")), "0")
                    TXTCLOSESIZE.Text = Convert.ToString(DR("BOXREQ"))
                    TXTOPENSIZE.Text = Convert.ToString(DR("TRAYREQ"))


                    txttotalsheets.Text = Format(Val(Val(Val(txtqty.Text) * Val(TXTPERCENTAGE.Text)) / 100 + Val(txtqty.Text)) / Val(txtups.Text), "0")
                    TOTOLSHEET()
                    'txtsheetsgiven.Text = Val(txttotalsheets.Text)
                    'txtbalancesheets.Text = Val(txttotalsheets.Text)
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
            If ORDERDT.Rows.Count > 0 Then FETCHDATA(ORDERDT.Rows(0).Item(0), ORDERDT.Rows(0).Item(1), ORDERDT.Rows(0).Item(2), ORDERDT.Rows(0).Item(3), ORDERDT.Rows(0).Item(4))
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub txtpono_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpono.KeyDown

        Try
            If e.KeyCode = Keys.F1 And edit = False Then CMDSELECTORDER_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call CMDDELETE_Click(sender, e)
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
                        ALPARAVAL.Add(YearId)
                        ALPARAVAL.Add(Userid)

                        Dim OBJJOB As New ClsJobDocketBatch
                        OBJJOB.alParaval = ALPARAVAL
                        Dim INTRESULT As Integer = OBJJOB.delete()
                        MsgBox("JobDocket is Deleted")
                        CLEAR()
                        edit = False
                    Else
                        MsgBox("Delete is only in Edit Mode")
                    End If
                End If
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

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            Dim OBJJOB As New JobDocketBatchDetails
            OBJJOB.MdiParent = MDIMain
            OBJJOB.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                ' gridjob.RowCount = 0
                TEMPJOBNO = Val(tstxtbillno.Text)
                If TEMPJOBNO > 0 Then
                    edit = True
                    JobDocketBatch_Load(sender, e)
                Else
                    edit = False
                    CLEAR()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpono_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpono.Validating
        'Try
        '    If txtpono.Text.Trim <> "" Then
        '        FETCHDATA(txtpono.Text.Trim, 0, 0)
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

    'Private Sub txtqty_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtqty.Validating
    '    Try
    '        Dim OBJCMN As New ClsCommon
    '        Dim DTT As DataTable = OBJCMN.search("ORDERMASTER.ORDER_TOTALQTY, ORDERMASTER.ORDER_NO", "", "ORDERMASTER INNER JOIN jobmaster ON ORDERMASTER.ORDER_NO = jobmaster.job_orderno AND ORDERMASTER.ORDER_YEARID = jobmaster.job_yearid", "AND ORDERMASTER.ORDER_NO = '" & txtorderno.Text.Trim & "' AND ORDER_YEARID = " & YearId)
    '        If DTT.Rows.Count > 0 Then
    '            If Val(txtqty.Text.Trim) > Val(DTT.Rows(0).Item(0)) Then
    '                MsgBox("Total Qty does not match with Order Qty?")
    '                e.Cancel = True
    '            End If
    '        End If
    '        ' txttotalsheets.Text = Format((Val(Val(txtqty.Text) * Val(TXTPERCENTAGE.Text)) / 100 + Val(txtqty.Text)) / Val(txtups.Text), "0")
    '        TOTOLSHEET()
    '        'txtsheetsgiven.Text = Val(txttotalsheets.Text)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub


    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then PRINTREPORT(TEMPJOBNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal JOBNO As Integer)
        Try
            TEMPMSG = MsgBox("Wish to Print?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJJOB As New DocketDesign
                OBJJOB.MdiParent = MDIMain
                OBJJOB.FRMSTRING = "DOCKET"
                OBJJOB.WHERECLAUSE = "{JOBBATCHMASTER.job_no}=" & Val(TEMPJOBNO) & " AND {JOBBATCHMASTER.job_YEARID} =" & YearId
                OBJJOB.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtjobdocketno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtjobdocketno.Validating
        Try
            If Val(txtjobdocketno.Text.Trim) > 0 And edit = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(JOBBATCHMASTER. job_no,0)  AS JOBBATCHNO", "", " JOBBATCHMASTER ", "  AND JOBBATCHMASTER.job_NO=" & txtjobdocketno.Text.Trim & " AND JOBBATCHMASTER.job_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Job Batch No Already Exist")
                    e.Cancel = True
                End If
            End If
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
    Private Sub TXTQTY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtqty.KeyPress, TXTYIELD.KeyPress, TXTTIME.KeyPress, TXTCUTSHEET.KeyPress, TXTCOLORSHEET.KeyPress, TXTEXTRA.KeyPress, TXTCOL1.KeyPress, TXTCOL2.KeyPress, TXTCOL1PLATES.KeyPress, TXTGUPS.KeyPress, TXTCOLORUPS.KeyPress, TXTSHEETS.KeyPress
        numkeypress(e, txtqty, Me)
    End Sub
    Private Sub TXTTOTAL_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTTOTAL.KeyPress, TXTKGS.KeyPress, txtcutsize.KeyPress, TXTFILMSIZE.KeyPress, TXTFILMSIZE2.KeyPress
        numdotkeypress(e, TXTTOTAL, Me)
    End Sub

    Private Sub TXTEXTRA_Validated(sender As Object, e As EventArgs) Handles TXTEXTRA.Validated
        Try
            If Val(TXTCUTSHEET.Text.Trim) > 0 And Val(TXTEXTRA.Text.Trim) > 0 Then TXTTOTAL.Text = Format(Val(TXTCUTSHEET.Text.Trim) + Val(TXTEXTRA.Text.Trim), "0")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCOLORUPS_Validated(sender As Object, e As EventArgs) Handles TXTCOLORUPS.Validated
        Try
            If Val(TXTCOLORUPS.Text.Trim) > 0 And Val(TXTTOTAL.Text.Trim) > 0 Then TXTCOLORSHEET.Text = Format(Val(TXTTOTAL.Text.Trim) / Val(TXTCOLORUPS.Text.Trim), "0")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub JobDocketBatch_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "GANESHMUDRA" Then
                GroupBox1.Visible = False
                GroupBox2.Visible = True
                LBLMACHINE.Visible = True
                LBLPREV.Visible = True
                LBLPREVDATE.Visible = True
                CMBMACHINE.Visible = True
                DTPREV.Visible = True
                TXTPREVJOBNO.Visible = True
                LBLCLOSESIZE.Visible = True
                LBLOPENSIZE.Visible = True
                TXTOPENSIZE.Visible = True
                TXTCLOSESIZE.Visible = True
                LBLVENDORNAME.Visible = True
                CMBOUTVENDORNAME.Visible = True
                Label31.Visible = False
                txtups.Visible = False
                Label19.Visible = False
                TXTSHIPTO.Visible = False
                Label22.Visible = False
                TXTORDERTYPE.Visible = False
                Label3.Visible = False
                txtfileno.Visible = False
                Label64.Visible = False
                txtpono.Visible = False
                Label2.Visible = False
                txtitemcode.Visible = False
            End If

            If ClientName = "AMR" Or ClientName = "RUTVIJ" Then
                txtups.ReadOnly = True
                Label26.Visible = False
                TXTGUPS.Visible = False
                Label66.Text = "Party Name"
                Label18.Text = "Item Name"
                Label1.Text = "Bom Item Name"
                LBLPRINTPRODONE.Text = "BATCH CREATED"
                LBLCLOSESIZE.Text = "Box Req"
                LBLOPENSIZE.Text = "Tray Req"
                TXTOPENSIZE.ReadOnly = True
                TXTCLOSESIZE.ReadOnly = True
                LBLCLOSESIZE.Visible = True
                LBLOPENSIZE.Visible = True
                TXTCLOSESIZE.Visible = True
                TXTOPENSIZE.Visible = True




            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGUPS_Validated(sender As Object, e As EventArgs) Handles TXTGUPS.Validated
        Try
            If Val(txtqty.Text.Trim) > 0 Then TXTCUTSHEET.Text = Format(Val(txtqty.Text.Trim) / Val(TXTGUPS.Text.Trim), "0")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNONINVITEM_Enter(sender As Object, e As EventArgs) Handles CMBNONINVITEM.Enter
        Try
            If CMBNONINVITEM.Text.Trim = "" Then FILLNONINVITEM(CMBNONINVITEM, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBNONINVITEM_Validating(sender As Object, e As CancelEventArgs) Handles CMBNONINVITEM.Validating
        Try
            If CMBNONINVITEM.Text.Trim <> "" Then NONINVITEMVALIDATE(CMBNONINVITEM, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBVENDOR_Enter(sender As Object, e As EventArgs) Handles CMBVENDOR.Enter
        Try
            If CMBVENDOR.Text.Trim = "" Then fillname(CMBVENDOR, edit, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub CMBVENDOR_Validating(sender As Object, e As CancelEventArgs) Handles CMBVENDOR.Validating
        Try
            If CMBVENDOR.Text.Trim = "" Then namevalidate(CMBVENDOR, CMBCODE, e, Me, txtadd, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLAM_Enter(sender As Object, e As EventArgs) Handles CMBLAM.Enter
        Try
            If CMBLAM.Text.Trim = "" Then fillname(CMBLAM, edit, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLFABRICATION_Enter(sender As Object, e As EventArgs) Handles CMBLFABRICATION.Enter
        Try
            If CMBLFABRICATION.Text.Trim = "" Then fillname(CMBLFABRICATION, edit, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLGUM_Enter(sender As Object, e As EventArgs) Handles CMBLGUM.Enter
        Try
            If CMBLGUM.Text.Trim = "" Then fillname(CMBLGUM, edit, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CMBLNUMBERING_Enter(sender As Object, e As EventArgs) Handles CMBLNUMBERING.Enter
        Try
            If CMBLNUMBERING.Text.Trim = "" Then fillname(CMBLNUMBERING, edit, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CMBLPACKING_Enter(sender As Object, e As EventArgs) Handles CMBLPACKING.Enter
        Try
            If CMBLPACKING.Text.Trim = "" Then fillname(CMBLPACKING, edit, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CMBLPUNCHING_Enter(sender As Object, e As EventArgs) Handles CMBLPUNCHING.Enter
        Try
            If CMBLPUNCHING.Text.Trim = "" Then fillname(CMBLPUNCHING, edit, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CMBLUV_Enter(sender As Object, e As EventArgs) Handles CMBLUV.Enter
        Try
            If CMBLUV.Text.Trim = "" Then fillname(CMBLUV, edit, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CMBVENDOR1_Enter(sender As Object, e As EventArgs) Handles CMBVENDOR1.Enter
        Try
            If CMBVENDOR1.Text.Trim = "" Then fillname(CMBVENDOR1, edit, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CMBLENVELOPE_Enter(sender As Object, e As EventArgs) Handles CMBLENVELOPE.Enter
        Try
            If CMBLENVELOPE.Text.Trim = "" Then fillname(CMBLENVELOPE, edit, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CMBLBINDING_Enter(sender As Object, e As EventArgs) Handles CMBLBINDING.Enter
        Try
            If CMBLBINDING.Text.Trim = "" Then fillname(CMBLBINDING, edit, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CMBOUTVENDORNAME_Enter(sender As Object, e As EventArgs) Handles CMBOUTVENDORNAME.Enter
        Try
            If CMBOUTVENDORNAME.Text.Trim = "" Then fillname(CMBOUTVENDORNAME, edit, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CMBLAM_Validating(sender As Object, e As CancelEventArgs) Handles CMBLAM.Validating

        Try
            If CMBLAM.Text.Trim = "" Then namevalidate(CMBLAM, CMBCODE, e, Me, txtadd, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CMBLFABRICATION_Validating(sender As Object, e As CancelEventArgs) Handles CMBLFABRICATION.Validating
        Try
            If CMBLFABRICATION.Text.Trim = "" Then namevalidate(CMBLFABRICATION, CMBCODE, e, Me, txtadd, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CMBLGUM_Validating(sender As Object, e As CancelEventArgs) Handles CMBLGUM.Validating
        Try
            If CMBLGUM.Text.Trim = "" Then namevalidate(CMBLGUM, CMBCODE, e, Me, txtadd, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CMBLNUMBERING_Validating(sender As Object, e As CancelEventArgs) Handles CMBLNUMBERING.Validating
        Try
            If CMBLNUMBERING.Text.Trim = "" Then namevalidate(CMBLNUMBERING, CMBCODE, e, Me, txtadd, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CMBLPACKING_Validating(sender As Object, e As CancelEventArgs) Handles CMBLPACKING.Validating
        Try
            If CMBLPACKING.Text.Trim = "" Then namevalidate(CMBLPACKING, CMBCODE, e, Me, txtadd, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CMBLPUNCHING_Validating(sender As Object, e As CancelEventArgs) Handles CMBLPUNCHING.Validating
        Try
            If CMBLPUNCHING.Text.Trim = "" Then namevalidate(CMBLPUNCHING, CMBCODE, e, Me, txtadd, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CMBVENDOR1_Validating(sender As Object, e As CancelEventArgs) Handles CMBVENDOR1.Validating
        Try
            If CMBVENDOR1.Text.Trim = "" Then namevalidate(CMBVENDOR1, CMBCODE, e, Me, txtadd, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CMBLUV_Validating(sender As Object, e As CancelEventArgs) Handles CMBLUV.Validating
        Try
            If CMBLUV.Text.Trim = "" Then namevalidate(CMBLUV, CMBCODE, e, Me, txtadd, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CMBLENVELOPE_Validating(sender As Object, e As CancelEventArgs) Handles CMBLENVELOPE.Validating
        Try
            If CMBLENVELOPE.Text.Trim = "" Then namevalidate(CMBLENVELOPE, CMBCODE, e, Me, txtadd, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CMBLBINDING_Validating(sender As Object, e As CancelEventArgs) Handles CMBLBINDING.Validating
        Try
            If CMBLBINDING.Text.Trim = "" Then namevalidate(CMBLBINDING, CMBCODE, e, Me, txtadd, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS")
        Catch ex As Exception
        End Try
    End Sub



    Private Sub CMBOUTVENDORNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBOUTVENDORNAME.Validating
        Try
            If CMBOUTVENDORNAME.Text.Trim <> "" Then namevalidate(CMBOUTVENDORNAME, CMBCODE, e, Me, txtadd, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CMBMACHINE_Validated(sender As Object, e As EventArgs) Handles CMBMACHINE.Validated
        Try
            If CMBMACHINE.Text = "MTB" Then CMBOUTVENDORNAME.Text = "GANESH MUDRA"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLAMM_Validated(sender As Object, e As EventArgs) Handles CMBLAMM.Validated
        Try
            If CMBLAMM.Text.Trim <> "" Then TXTSHEETS.Text = TXTTOTAL.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPREVJOBNO_Validated(sender As Object, e As EventArgs) Handles TXTPREVJOBNO.Validated
        Try
            If Val(TXTPREVJOBNO.Text.Trim) > 0 And edit = False Then
                If MsgBox("Wish to Copy JOB No " & Val(TXTPREVJOBNO.Text.Trim) & "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim objclsSO As New ClsJobDocketBatch()
                Dim dt_po As DataTable = objclsSO.selectNO(TXTPREVJOBNO.Text.Trim, CmpId, YearId)
                If dt_po.Rows.Count > 0 Then
                    For Each DR As DataRow In dt_po.Rows

                        getmax_job_no()
                        ' txtorderno.Text = Convert.ToString(DR("ORDERNO"))
                        ' TXTORDERGSRNO.Text = Convert.ToString(DR("ORDERSRNO"))
                        '  txtpartyname.Text = Convert.ToString(DR("PARTYNAME"))
                        txtpono.Text = Convert.ToString(DR("PONO"))
                        jobdate.Value = Mydate
                        ' txtitemcode.Text = Convert.ToString(DR("MAINITEMCODE"))
                        txtfileno.Text = Convert.ToString(DR("FILENO"))
                        txtgsm.Text = Convert.ToString(DR("PPRGSM"))
                        txtmaterial.Text = Convert.ToString(DR("MATERIAL"))
                        txtpapersize.Text = Convert.ToString(DR("PPRSIZE"))
                        txtdesign.Text = Convert.ToString(DR("DESIGN"))
                        txtgrain.Text = Convert.ToString(DR("GRAINDIRECTION"))
                        txtmaterialcode.Text = Convert.ToString(DR("MATERIALCODE"))
                        '  txtqty.Text = Format(Val(DR("QTY")), "0")
                        txtshadecard.Text = Convert.ToString(DR("SHADECARD"))
                        TXTPOSITIVENEGATIVE.Text = DR("POSITIVENEGATIVE")
                        txtleafletsize.Text = Convert.ToString(DR("LEAFLETSIZE"))
                        txtfoldingsize.Text = Convert.ToString(DR("FOLDINGSIZE"))
                        txtcutsize.Text = Convert.ToString(DR("CUTSIZE"))
                        txtups.Text = Convert.ToString(DR("UPS"))
                        txttotalsheets.Text = Convert.ToString(DR("TOTALSHEETS"))
                        'If Convert.ToBoolean(DR("DONE")) = True Then
                        '    lbllocked.Visible = True
                        '    PBlock.Visible = True
                        'End If
                        TXTPERCENTAGE.Text = Convert.ToString(DR("PERCENTAGE"))
                        TXTSHIPTO.Text = Convert.ToString(DR("SHIPTO"))
                        '  TXTMAINITEM.Text = Convert.ToString(DR("MAINITEMNAME"))
                        TXTORDERTYPE.Text = Convert.ToString(DR("ORDERTYPE"))
                        '  TXTJOBQTY.Text = Format(Val(DR("QTY")), "0")
                        TXTCOL1.Text = Convert.ToString(DR("COL"))
                        TXTCOL2.Text = Convert.ToString(DR("COL2"))
                        CMBMODE.Text = Convert.ToString(DR("MODE"))
                        TXTCOL1PLATES.Text = Convert.ToString(DR("COL1PLATES"))
                        TXTCOL2PLATES.Text = Convert.ToString(DR("COL2PLATES"))
                        CMBCOL1PLATETYPE.Text = Convert.ToString(DR("COL1PLATETYPE"))
                        CMBCOL2PLATETYPE.Text = Convert.ToString(DR("COL2PLATETYPE"))
                        TXTGUPS.Text = Convert.ToString(DR("OPENUPS"))
                        TXTCUTSHEET.Text = Convert.ToString(DR("CUTSHEET"))
                        TXTEXTRA.Text = Convert.ToString(DR("EXTRA"))
                        TXTTOTAL.Text = Convert.ToString(DR("TOTAL"))
                        TXTTIME.Text = Convert.ToString(DR("PRODUCEQTY")) 'its saved as produced qty
                        TXTCUTSIZEG.Text = Convert.ToString(DR("GCUTSIZE"))
                        TXTCOLORUPS.Text = Convert.ToString(DR("COLORUPS"))
                        TXTCOLORSHEET.Text = Convert.ToString(DR("COLORSHEET"))
                        TXTFULLSIZE.Text = Convert.ToString(DR("FULLSIZE"))
                        'TXTBOMITEMCODE.Text = Convert.ToString(DR("SUBITEMCODE"))
                        CMBLAMM.Text = Convert.ToString(DR("LAMINATIONON"))
                        TXTYIELD.Text = Convert.ToString(DR("YIELD"))
                        TXTSHEETS.Text = Convert.ToString(DR("SHEETS"))
                        TXTFILMSIZE.Text = Format(Val(DR("FILMSIZE")), "0.00")
                        TXTFILMSIZE2.Text = Format(Val(DR("FILMSIZE2")), "0.00")
                        TXTKGS.Text = Convert.ToString(DR("KGS"))
                        CMBLAMINATION.Text = Convert.ToString(DR("LAMINATION"))
                        CMBUV.Text = Convert.ToString(DR("UV"))
                        CMBPUNCHING.Text = Convert.ToString(DR("PUNCHING"))
                        CMBENVELOPE.Text = Convert.ToString(DR("ENVELOPE"))
                        CMBGUMMING.Text = Convert.ToString(DR("GUMMING"))
                        CMBBINDING.Text = Convert.ToString(DR("BINDING"))
                        CMBNUMBERING.Text = Convert.ToString(DR("NUMBERING"))
                        CMBFABRICATION.Text = Convert.ToString(DR("FABRICATION"))
                        CMBPACKING.Text = Convert.ToString(DR("PACKING"))
                        CMBNONINVITEM.Text = Convert.ToString(DR("NONINVITEM"))
                        TXTPREVJOBNO.Text = TXTPREVJOBNO.Text.Trim
                        DTPREV.Text = Format(Convert.ToDateTime(DR("DATE")), "dd/MM/yyyy")
                        CMBMACHINE.Text = Convert.ToString(DR("MACHINE"))
                        CMBOUTVENDORNAME.Text = Convert.ToString(DR("OUTVENDORNAME"))
                        TXTOPENSIZE.Text = Convert.ToString(DR("OPENSIZE"))
                        TXTCLOSESIZE.Text = Convert.ToString(DR("CLOSESIZE"))
                        CMBLAMMODE.Text = Convert.ToString(DR("LAMMODE"))
                        TXTLAMINATION1.Text = Convert.ToString(DR("LAMINATION1"))
                        TXTLAMINATION2.Text = Convert.ToString(DR("LAMINATION2"))
                        CMBLAM.Text = Convert.ToString(DR("LAM"))
                        CMBLUV.Text = Convert.ToString(DR("LUV"))
                        CMBLPUNCHING.Text = Convert.ToString(DR("LPUNCHING"))
                        CMBLENVELOPE.Text = Convert.ToString(DR("LENVELOPE"))
                        CMBLGUM.Text = Convert.ToString(DR("LGUMMING"))
                        CMBLBINDING.Text = Convert.ToString(DR("LBINDING"))
                        CMBLNUMBERING.Text = Convert.ToString(DR("LNUMBERING"))
                        CMBLFABRICATION.Text = Convert.ToString(DR("LFABRICATION"))
                        CMBVENDOR.Text = Convert.ToString(DR("VENDOR"))
                        CMBVENDOR1.Text = Convert.ToString(DR("VENDOR1"))
                        CMBLPACKING.Text = Convert.ToString(DR("LPACKING"))
                        'If Convert.ToBoolean(DR("REQDONE")) = True Then
                        '    LBLREQDONE.Visible = True
                        'End If

                        'If Convert.ToBoolean(DR("SCHDONE")) = True Then
                        '    LBLREQDONE.Visible = True
                        'End If
                    Next

                    'Else
                    '    edit = False
                    CLEAR()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtups_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtups.KeyPress, TXTLAMINATIONUPS.KeyPress, TXTPUNCHINGUPS.KeyPress, TXTFINALUPS.KeyPress
        numkeypress(e, txtqty, Me)
    End Sub

    Private Sub TXTTIME_Validated(sender As Object, e As EventArgs) Handles TXTTIME.Validated
        Try
            If TXTFILMSIZE2.Text.Trim <> "" Then TXTKGS.Text = Format(Val((TXTFILMSIZE.Text.Trim * TXTFILMSIZE2.Text.Trim * TXTSHEETS.Text.Trim / 1550) / TXTYIELD.Text.Trim * TXTTIME.Text.Trim), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class