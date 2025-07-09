
Imports BL
Imports System.ComponentModel

Public Class Production

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE, GRIDSHIFTDOUBLECLICK As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim gridUPLOADDoubleClick As Boolean
    Dim temprow As Integer
    Dim TEMPSHIFTROW As Integer
    Public EDIT As Boolean
    Public TEMPRODNO As Integer
    Dim EXPIRY As Boolean = False

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        edit = False
        TXTPRODUCTIONDONEBY.Focus()
    End Sub

    Sub CLEAR()

        TXTPRODNO.ReadOnly = True
        DTDATE.Text = Now.Date
        CMBPRODUCTIONTYPE.Enabled = True
        CMBTOPRODUCTIONTYPE.Enabled = True
        TXTPRODUCTIONDONEBY.Clear()
        GRIDPROD.RowCount = 0
        TXTREMARKS.Clear()
        CMBPRODUCTIONTYPE.Text = ""
        cmbname.Text = ""
        CMBTOPRODUCTIONTYPE.Text = "Printing"
        GETMAX_NO()
        tstxtbillno.Clear()
        CMBPRODUCTIONTYPE.Text = ""
        CMBPRODUCTIONMACHINE.Text = ""

        GEXTRASHEET.ReadOnly = False
        LBLTOTALJOBCARDQTY.Text = 0.0
        LBLTOTALPRINTEDQTY.Text = 0.0
        LBLTOTALREMAINIGQTY.Text = 0.0
        LBLTOTALSTOCK.Text = 0.0
        LBLTOTALORDER.Text = 0.0
        LBLTOTALBALANCE.Text = 0.0
        LBLTOTALPLATES.Text = 0.0
        LBLTOTALWASTAGE.Text = 0.0
        LBLTOTALGOODQTY.Text = 0.0
        CMDSELECTJOBDOCKET.Enabled = True
        LBLTOTALEXTRASHEET.Text = 0.0
        TXTOUTQTY.Clear()
        TXTUPS.Clear()



        CMDSELECTJOBDOCKET.Enabled = True


        EP.Clear()
        lbllocked.Visible = False
        PBlock.Visible = False

    End Sub

    Sub GETMAX_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(PROD_NO),0) + 1 ", "PRODUCTION", "  AND PROD_cmpid=" & CmpId & " and PROD_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTPRODNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub Production_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.F8 Then
                GRIDPROD.Focus()
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

    Private Sub Production_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'PRODUCTION'")

            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            Cursor.Current = Cursors.WaitCursor

            CLEAR()
            FILLCMB()

            CMBPRODUCTIONTYPE.Text = ""
            CMBTOPRODUCTIONTYPE.Text = "Printing"



            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJCMN As New ClsCommon
                Dim OBJCLSINCENTIVE As New ClsProduction
                Dim dttable As New DataTable

                dttable = OBJCLSINCENTIVE.SELECTSPRODUCTION(TEMPRODNO, CmpId, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        CMDSELECTJOBDOCKET.Enabled = False

                        TXTPRODNO.Text = TEMPRODNO
                        TXTPRODNO.ReadOnly = True
                        DTDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        TXTPRODUCTIONDONEBY.Text = dr("PRODUCTIONDONEBY")
                        TXTREMARKS.Text = dr("REMARKS")
                        CMBPRODUCTIONTYPE.Text = dr("PRODUCTIONTYPE")
                        CMBTOPRODUCTIONTYPE.Text = dr("TOPRODUCTIONTYPE")

                        CMBPRODUCTIONTYPE.Enabled = False
                        CMBTOPRODUCTIONTYPE.Enabled = False

                        LBLTOTALJOBCARDQTY.Text = dr("TOTALJOBCARDQTY")
                        LBLTOTALPRINTEDQTY.Text = dr("TOTALPRINTEDQTY")
                        LBLTOTALREMAINIGQTY.Text = dr("TOTALREMAININGQTY")
                        LBLTOTALSTOCK.Text = dr("TOTALSTOCK")
                        LBLTOTALORDER.Text = dr("TOTALORDER")
                        LBLTOTALBALANCE.Text = dr("TOTALBALANCE")
                        LBLTOTALPLATES.Text = dr("TOTALPLATES")
                        LBLTOTALWASTAGE.Text = dr("TOTALWASTAGE")
                        LBLTOTALGOODQTY.Text = dr("TOTALGOODQTY")
                        CMBPRODUCTIONMACHINE.Text = dr("MACHINE")
                        cmbname.Text = dr("NAME")
                        LBLTOTALEXTRASHEET.Text = dr("TOTALEXTRASHEET")
                        TXTOUTQTY.Text = dr("OUTQTY")
                        TXTUPS.Text = dr("UPS")




                        GRIDPROD.Rows.Add(dr("GRIDSRNO").ToString, dr("JOBNO").ToString, dr("CLIENT").ToString, dr("JOBCARDQTY").ToString, dr("SCHDATE").ToString, dr("STATUS").ToString, Val(dr("PRINTEDQTY").ToString), Val(dr("EXTRASHEET").ToString), Val(dr("GOODQTY").ToString), Val(dr("WASTAGE").ToString), Val(dr("REMAINIGQTY").ToString), dr("ITEMNAME").ToString, dr("CUTSHEET").ToString, dr("CUTSIZE").ToString, dr("FULLSHEET").ToString, dr("STOCK").ToString, dr("ORDERS").ToString, dr("BALANCE").ToString, dr("NONINVITEM").ToString, dr("COLOR1").ToString, dr("COLOR2").ToString, dr("COLOR1PLATES").ToString, dr("COLOR2PLATES").ToString, dr("COLOR1TYPE").ToString, dr("COLOR2TYPE").ToString, dr("MODE").ToString, dr("SIDE").ToString, dr("IMP").ToString, dr("FINALIMP").ToString, dr("READYTIME").ToString, dr("FINISHTIME").ToString, dr("REMARKS").ToString, dr("LAMINATIONDATE").ToString, dr("LAMINATIONSHEETS").ToString, dr("TOTALDONE").ToString, dr("TODO").ToString, dr("FLIM").ToString, dr("WIDTH").ToString, dr("LENGTH").ToString, dr("DONE").ToString, dr("GSM").ToString, dr("MAKEREADY").ToString, dr("WASTAGE").ToString, dr("FROMNO"), dr("FROMSRNO"), dr("FROMTYPE"), dr("ORDERNO"), dr("ORDERSRNO"), dr("ORDERTYPE"))

                        If dr("OUTQTY") > 0 Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                            GRIDPROD.Rows(GRIDPROD.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                        End If
                    Next
                    GRIDPROD.FirstDisplayedScrollingRowIndex = GRIDPROD.RowCount - 1
                Else
                    TOTAL()
                    edit = False
                    CLEAR()
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLCMB()
        If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
    End Sub

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        If ISLOCKYEAR = True Then
            MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Try

            Cursor.Current = Cursors.WaitCursor

            Dim IntResult As Integer
            EP.Clear()

            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList
            ' If TXTLABNO.ReadOnly = False Then
            alParaval.Add(Val(TXTPRODNO.Text.Trim))
            'Else
            ' alParaval.Add(0)
            ' End If

            alParaval.Add(Format(Convert.ToDateTime(DTDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(TXTPRODUCTIONDONEBY.Text.Trim)
            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(CMBPRODUCTIONTYPE.Text.Trim)
            alParaval.Add(CMBTOPRODUCTIONTYPE.Text.Trim)
            alParaval.Add(CMBPRODUCTIONMACHINE.Text.Trim)
            alParaval.Add(Val(LBLTOTALJOBCARDQTY.Text.Trim))
            alParaval.Add(Val(LBLTOTALPRINTEDQTY.Text.Trim))
            alParaval.Add(Val(LBLTOTALREMAINIGQTY.Text.Trim))
            alParaval.Add(Val(LBLTOTALSTOCK.Text.Trim))
            alParaval.Add(Val(LBLTOTALORDER.Text.Trim))
            alParaval.Add(Val(LBLTOTALBALANCE.Text.Trim))
            alParaval.Add(Val(LBLTOTALPLATES.Text.Trim))
            alParaval.Add(Val(LBLTOTALWASTAGE.Text.Trim))
            alParaval.Add(Val(LBLTOTALGOODQTY.Text.Trim))
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(Val(TXTOUTQTY.Text.Trim))
            alParaval.Add(Val(LBLTOTALEXTRASHEET.Text.Trim))
            alParaval.Add(Val(TXTUPS.Text.Trim))


            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            ' GRID PARAMETERS
            Dim GRIDSRNO As String = ""
            Dim JOBNO As String = ""
            Dim CLIENT As String = ""
            Dim JOBCARDQTY As String = ""
            Dim SCHDATE As String = ""
            Dim STATUS As String = ""
            Dim PRINTEDQTY As String = ""
            Dim EXTRASHEET As String = ""
            Dim GOODQTY As String = ""
            Dim WASTAGE As String = ""
            Dim REMAININGQTY As String = ""
            Dim JOBDESC As String = ""
            Dim CUTSHEET As String = ""
            Dim CUTSIZE As String = ""
            Dim FULLSHEET As String = ""
            Dim STOCK As String = ""
            Dim ORDER As String = ""
            Dim BALANCE As String = ""
            Dim GSMPAPERSIZE As String = ""
            Dim COLOR1 As String = ""
            Dim COLOR2 As String = ""
            Dim COLOR1PLATES As String = ""
            Dim COLOR2PLATES As String = ""
            Dim COLOR1TYPE As String = ""
            Dim COLOR2TYPE As String = ""
            Dim MODE As String = ""
            Dim SIDE As String = ""
            Dim IMP As String = ""
            Dim FINALIMP As String = ""
            Dim READYTIME As String = ""
            Dim FINISHTIME As String = ""
            Dim REMARK As String = ""
            Dim LAMINATIONDATE As String = ""
            Dim LAMINATIONSHEETS As String = ""
            Dim TOTALDONE As String = ""
            Dim TODO As String = ""
            Dim FLIM As String = ""
            Dim WIDTH As String = ""
            Dim LENGTH As String = ""
            Dim DONE As String = ""
            Dim GSM As String = ""
            Dim MAKEREADY As String = ""
            Dim PRINTINGDONE As String = ""
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""
            Dim ORDERNO As String = ""
            Dim ORDERSRNO As String = ""
            Dim ORDERTYPE As String = ""


            For Each ROW As Windows.Forms.DataGridViewRow In GRIDPROD.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(ROW.Cells(GSRNO.Index).Value)
                        JOBNO = Val(ROW.Cells(GJOBNO.Index).Value)
                        CLIENT = ROW.Cells(GCLIENT.Index).Value.ToString
                        JOBCARDQTY = Val(ROW.Cells(GJOBCARDQTY.Index).Value)
                        SCHDATE = Format(Convert.ToDateTime(ROW.Cells(GSCHDATE.Index).Value).Date, "MM/dd/yyyy")
                        STATUS = ROW.Cells(GSTATUS.Index).Value.ToString
                        PRINTEDQTY = Val(ROW.Cells(GPRINTEDQTY.Index).Value)
                        EXTRASHEET = Val(ROW.Cells(GEXTRASHEET.Index).Value)
                        GOODQTY = Val(ROW.Cells(GGOODQTY.Index).Value)
                        WASTAGE = Val(ROW.Cells(GWASTAGE.Index).Value)
                        REMAININGQTY = Val(ROW.Cells(GREMAINIGQTY.Index).Value)
                        JOBDESC = ROW.Cells(GJOBDESC.Index).Value.ToString.Trim
                        CUTSHEET = Val(ROW.Cells(GCUTSHEET.Index).Value)
                        CUTSIZE = ROW.Cells(GCUTSIZE.Index).Value.ToString
                        FULLSHEET = Val(ROW.Cells(GFULLSHEET.Index).Value)
                        STOCK = Val(ROW.Cells(GSTOCK.Index).Value)
                        ORDER = Val(ROW.Cells(GORDER.Index).Value)
                        BALANCE = Val(ROW.Cells(GBALANCE.Index).Value)
                        GSMPAPERSIZE = ROW.Cells(GGSMPAPERSIZE.Index).Value.ToString
                        COLOR1 = ROW.Cells(GCOLOR1.Index).Value.ToString
                        COLOR2 = ROW.Cells(GCOLOR2.Index).Value.ToString
                        COLOR1PLATES = ROW.Cells(GCOLOR1PLATES.Index).Value.ToString
                        COLOR2PLATES = ROW.Cells(GCOLOR1PLATES.Index).Value.ToString
                        COLOR1TYPE = ROW.Cells(GCOLOR1TYPE.Index).Value.ToString
                        COLOR2TYPE = ROW.Cells(GCOLOR2TYPE.Index).Value.ToString
                        MODE = ROW.Cells(GMODE.Index).Value.ToString
                        SIDE = Val(ROW.Cells(GSIDE.Index).Value)
                        IMP = Val(ROW.Cells(GIMP.Index).Value)
                        FINALIMP = ROW.Cells(GFINALIMP.Index).Value.ToString
                        READYTIME = ROW.Cells(GREADYTIME.Index).Value.ToString
                        FINISHTIME = ROW.Cells(GFINISHTIME.Index).Value.ToString
                        REMARK = ROW.Cells(GREMARK.Index).Value.ToString
                        LAMINATIONDATE = ROW.Cells(GLAMINATIONDATE.Index).Value.ToString
                        LAMINATIONSHEETS = ROW.Cells(GLAMINATIONSHEETS.Index).Value.ToString
                        TOTALDONE = Val(ROW.Cells(GTOTALDONE.Index).Value)
                        TODO = ROW.Cells(GTODO.Index).Value.ToString
                        FLIM = ROW.Cells(GFLIM.Index).Value.ToString
                        WIDTH = Val(ROW.Cells(GWIDTH.Index).Value)
                        LENGTH = Val(ROW.Cells(GLENGTH.Index).Value)
                        DONE = Val(ROW.Cells(GDONE.Index).Value)
                        GSM = ROW.Cells(GGSM.Index).Value.ToString
                        MAKEREADY = ROW.Cells(GMAKEREADY.Index).Value.ToString
                        PRINTINGDONE = Val(ROW.Cells(GPRINTINGDONE.Index).Value)
                        FROMNO = Val(ROW.Cells(GFROMNO.Index).Value)
                        FROMSRNO = Val(ROW.Cells(GFROMSRNO.Index).Value)
                        FROMTYPE = ROW.Cells(GFROMTYPE.Index).Value.ToString
                        ORDERNO = Val(ROW.Cells(GORDERNO.Index).Value)
                        ORDERSRNO = Val(ROW.Cells(GORDERSRNO.Index).Value)
                        ORDERTYPE = ROW.Cells(GORDERTYPE.Index).Value.ToString

                    Else

                        GRIDSRNO = GRIDSRNO & "|" & Val(ROW.Cells(GSRNO.Index).Value)
                        JOBNO = JOBNO & "|" & Val(ROW.Cells(GJOBNO.Index).Value)
                        CLIENT = CLIENT & "|" & ROW.Cells(GCLIENT.Index).Value.ToString
                        JOBCARDQTY = JOBCARDQTY & "|" & Val(ROW.Cells(GJOBCARDQTY.Index).Value)
                        SCHDATE = SCHDATE & "|" & Format(Convert.ToDateTime(ROW.Cells(GSCHDATE.Index).Value).Date, "MM/dd/yyyy")
                        STATUS = STATUS & "|" & ROW.Cells(GSTATUS.Index).Value.ToString
                        PRINTEDQTY = PRINTEDQTY & "|" & Val(ROW.Cells(GPRINTEDQTY.Index).Value)
                        EXTRASHEET = EXTRASHEET & "|" & Val(ROW.Cells(GEXTRASHEET.Index).Value)
                        GOODQTY = GOODQTY & "|" & Val(ROW.Cells(GGOODQTY.Index).Value)
                        WASTAGE = WASTAGE & "|" & ROW.Cells(GWASTAGE.Index).Value.ToString
                        REMAININGQTY = REMAININGQTY & "|" & Val(ROW.Cells(GREMAINIGQTY.Index).Value)
                        JOBDESC = JOBDESC & "|" & ROW.Cells(GJOBDESC.Index).Value.ToString.Trim
                        CUTSHEET = CUTSHEET & "|" & Val(ROW.Cells(GCUTSHEET.Index).Value)
                        CUTSIZE = CUTSIZE & "|" & ROW.Cells(GCUTSIZE.Index).Value.ToString
                        FULLSHEET = FULLSHEET & "|" & Val(ROW.Cells(GFULLSHEET.Index).Value)
                        STOCK = STOCK & "|" & Val(ROW.Cells(GSTOCK.Index).Value)
                        ORDER = ORDER & "|" & Val(ROW.Cells(GORDER.Index).Value)
                        BALANCE = BALANCE & "|" & Val(ROW.Cells(GBALANCE.Index).Value)
                        GSMPAPERSIZE = GSMPAPERSIZE & "|" & ROW.Cells(GGSMPAPERSIZE.Index).Value.ToString
                        COLOR1 = COLOR1 & "|" & ROW.Cells(GCOLOR1.Index).Value.ToString
                        COLOR2 = COLOR2 & "|" & ROW.Cells(GCOLOR2.Index).Value.ToString
                        COLOR1PLATES = COLOR1PLATES & "|" & ROW.Cells(GCOLOR1PLATES.Index).Value.ToString
                        COLOR2PLATES = COLOR2PLATES & "|" & ROW.Cells(GCOLOR2PLATES.Index).Value.ToString
                        COLOR1TYPE = COLOR1TYPE & "|" & ROW.Cells(GCOLOR1TYPE.Index).Value.ToString
                        COLOR2TYPE = COLOR2TYPE & "|" & ROW.Cells(GCOLOR2TYPE.Index).Value.ToString
                        MODE = MODE & "|" & ROW.Cells(GMODE.Index).Value.ToString
                        SIDE = SIDE & "|" & Val(ROW.Cells(GSIDE.Index).Value)
                        IMP = IMP & "|" & Val(ROW.Cells(GIMP.Index).Value)
                        FINALIMP = FINALIMP & "|" & ROW.Cells(GFINALIMP.Index).Value.ToString
                        READYTIME = READYTIME & "|" & ROW.Cells(GREADYTIME.Index).Value.ToString
                        FINISHTIME = FINISHTIME & "|" & ROW.Cells(GFINISHTIME.Index).Value.ToString
                        REMARK = REMARK & "|" & ROW.Cells(GREMARK.Index).Value.ToString
                        LAMINATIONDATE = LAMINATIONDATE & "|" & ROW.Cells(GLAMINATIONDATE.Index).Value.ToString
                        LAMINATIONSHEETS = LAMINATIONSHEETS & "|" & ROW.Cells(GLAMINATIONSHEETS.Index).Value.ToString
                        TOTALDONE = TOTALDONE & "|" & ROW.Cells(GTOTALDONE.Index).Value.ToString
                        TODO = TODO & "|" & ROW.Cells(GTODO.Index).Value.ToString
                        FLIM = FLIM & "|" & ROW.Cells(GFLIM.Index).Value.ToString
                        WIDTH = WIDTH & "|" & Val(ROW.Cells(GWIDTH.Index).Value)
                        LENGTH = LENGTH & "|" & Val(ROW.Cells(GLENGTH.Index).Value)
                        DONE = DONE & "|" & ROW.Cells(GDONE.Index).Value.ToString
                        GSM = GSM & "|" & ROW.Cells(GGSM.Index).Value.ToString
                        MAKEREADY = MAKEREADY & "|" & ROW.Cells(GMAKEREADY.Index).Value.ToString
                        PRINTINGDONE = PRINTINGDONE & "|" & ROW.Cells(GPRINTINGDONE.Index).Value.ToString
                        FROMNO = FROMNO & "|" & ROW.Cells(GFROMNO.Index).Value.ToString
                        FROMSRNO = FROMSRNO & "|" & ROW.Cells(GFROMSRNO.Index).Value.ToString
                        FROMTYPE = FROMTYPE & "|" & ROW.Cells(GFROMTYPE.Index).Value.ToString
                        ORDERNO = ORDERNO & "|" & ROW.Cells(GORDERNO.Index).Value.ToString
                        ORDERSRNO = ORDERSRNO & "|" & ROW.Cells(GORDERSRNO.Index).Value.ToString
                        ORDERTYPE = ORDERTYPE & "|" & ROW.Cells(GORDERTYPE.Index).Value.ToString


                    End If
                End If
            Next
            alParaval.Add(GRIDSRNO)
            alParaval.Add(JOBNO)
            alParaval.Add(CLIENT)
            alParaval.Add(JOBCARDQTY)
            alParaval.Add(SCHDATE)
            alParaval.Add(STATUS)
            alParaval.Add(PRINTEDQTY)
            alParaval.Add(EXTRASHEET)
            alParaval.Add(GOODQTY)
            alParaval.Add(WASTAGE)
            alParaval.Add(REMAININGQTY)
            alParaval.Add(JOBDESC)
            alParaval.Add(CUTSHEET)
            alParaval.Add(CUTSIZE)
            alParaval.Add(FULLSHEET)
            alParaval.Add(STOCK)
            alParaval.Add(ORDER)
            alParaval.Add(BALANCE)
            alParaval.Add(GSMPAPERSIZE)
            alParaval.Add(COLOR1)
            alParaval.Add(COLOR2)
            alParaval.Add(COLOR1PLATES)
            alParaval.Add(COLOR2PLATES)
            alParaval.Add(COLOR1TYPE)
            alParaval.Add(COLOR2TYPE)
            alParaval.Add(MODE)
            alParaval.Add(SIDE)
            alParaval.Add(IMP)
            alParaval.Add(FINALIMP)
            alParaval.Add(READYTIME)
            alParaval.Add(FINISHTIME)
            alParaval.Add(REMARK)
            alParaval.Add(LAMINATIONDATE)
            alParaval.Add(LAMINATIONSHEETS)
            alParaval.Add(TOTALDONE)
            alParaval.Add(TODO)
            alParaval.Add(FLIM)
            alParaval.Add(WIDTH)
            alParaval.Add(LENGTH)
            alParaval.Add(DONE)
            alParaval.Add(GSM)
            alParaval.Add(MAKEREADY)
            alParaval.Add(PRINTINGDONE)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(FROMTYPE)
            alParaval.Add(ORDERNO)
            alParaval.Add(ORDERSRNO)
            alParaval.Add(ORDERTYPE)

            Dim objclsPurord As New ClsProduction()
            objclsPurord.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = objclsPurord.SAVE()
                MessageBox.Show("Details Added")
                TEMPRODNO = DT.Rows(0).Item(0)
            Else


                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPRODNO)
                IntResult = objclsPurord.UPDATE()
                MessageBox.Show("Details Updated")
                EDIT = False
            End If
            If MsgBox("Wish to Print Production?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then PRINTREPORT(TEMPRODNO)
            TXTPRODUCTIONDONEBY.Focus()
            CLEAR()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub


    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True


        If DTDATE.Text = "__/__/____" Then
            EP.SetError(DTDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(DTDATE.Text) Then
                EP.SetError(DTDATE, "Date Not In Accounting Year")
                bln = False
            End If
        End If

        If GRIDPROD.RowCount = 0 Then
            EP.SetError(GRIDPROD, " Please Enter Proper Details ")
            bln = False
        End If
        If CMBTOPRODUCTIONTYPE.Text.Trim.Length = 0 Then
            EP.SetError(CMBTOPRODUCTIONTYPE, " Please Fill Production Type ")
            bln = False
        End If

        If CMBPRODUCTIONMACHINE.Text.Trim.Length = 0 Then
            EP.SetError(CMBPRODUCTIONMACHINE, " Please Fill Machine ")
            bln = False
        End If

        If lbllocked.Visible = True Or PBlock.Visible = True Then
            EP.SetError(PBlock, " Production used ")
            bln = False
        End If

        'CHECKING IF GOODQTY = 0
        For Each ROW As DataGridViewRow In GRIDPROD.Rows
            If ROW.Cells(GGOODQTY.Index).Value = "0" Then
                EP.SetError(CMBTOPRODUCTIONTYPE, "The Value Of Good Qty Sholud be Greater 0")
                bln = False
            End If
        Next



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

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDPROD.RowCount = 0
LINE1:
            TEMPRODNO = Val(TXTPRODNO.Text) - 1
            If TEMPRODNO > 0 Then
                EDIT = True
                Production_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If

            If GRIDPROD.RowCount = 0 And TEMPRODNO > 1 Then
                TXTPRODNO.Text = TEMPRODNO
                GoTo LINE1
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDPROD.RowCount = 0
LINE1:
            TEMPRODNO = Val(TXTPRODNO.Text) + 1
            GETMAX_NO()
            Dim MAXNO As Integer = TXTPRODNO.Text.Trim
            CLEAR()
            If Val(TXTPRODNO.Text) - 1 >= TEMPRODNO Then
                EDIT = True
                Production_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDPROD.RowCount = 0 And TEMPRODNO < MAXNO Then
                TXTPRODNO.Text = TEMPRODNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstxtbillno.Validated
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDPROD.RowCount = 0
            TEMPRODNO = Val(tstxtbillno.Text)
            If TEMPRODNO > 0 Then
                EDIT = True
                Production_Load(sender, e)
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

            Dim OBJGRN As New ProductionDetails
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub


    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Call cmddelete_Click(sender, e)
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

                If MsgBox("Wish To Delete Production.?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    Dim alParaval As New ArrayList
                        alParaval.Add(TXTPRODNO.Text.Trim)
                        alParaval.Add(YearId)
                        alParaval.Add(Userid)

                        Dim clspo As New ClsProduction()
                        clspo.alParaval = alParaval
                        Dim IntResult As Integer = clspo.Delete()
                        MsgBox("production Deleted")
                        CLEAR()
                        EDIT = False
                    End If
                End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPROD_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDPROD.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDPROD.RowCount > 0 Then
                If gridDoubleClick = True Then
                    MessageBox.Show("Row Is In Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDPROD.Rows.RemoveAt(GRIDPROD.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDPROD)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTORDER_Click(sender As Object, e As EventArgs) Handles CMDSELECTJOBDOCKET.Click
        Try
            If CMBPRODUCTIONTYPE.Text.Trim = CMBTOPRODUCTIONTYPE.Text.Trim Then
                MsgBox("Select Proper Processes", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim OBJSO As New SelectJobDocket
            OBJSO.FRMSTRING = "PRODUCTION"
            OBJSO.TEMPPRODUCTTYPE = CMBPRODUCTIONTYPE.Text.Trim
            OBJSO.TEMPTOPRODUCTTYPE = CMBTOPRODUCTIONTYPE.Text.Trim
            Dim DT As DataTable = OBJSO.DT
            OBJSO.ShowDialog()

            If DT.Rows.Count > 0 And CMBPRODUCTIONTYPE.Text = "" Then
                For Each DTROW As DataRow In DT.Rows
                    GRIDPROD.Rows.Add(0, Val(DTROW("JOBDOCKETNO")), DTROW("NAME"), DTROW("QTY"), Format(Convert.ToDateTime(DTROW("JOBDOCKETDATE")), "dd/MM/yyyy"), "", DTROW("TOTALCUTSHEET"), 0, 0, 0, 0, DTROW("ITEMNAME"), DTROW("CUTSHEET"), DTROW("CUTSIZE"), DTROW("FULLSHEET"), DTROW("STOCK"), DTROW("ORDERQTY"), 0, DTROW("PAPERNAME"), DTROW("COLOR1"), DTROW("COLOR2"), DTROW("COLOR1PLATES"), DTROW("COLOR2PLATES"), DTROW("COLOR1TYPE"), DTROW("COLOR2TYPE"), DTROW("MODE"), 0, 0, "", "", "", "", "", DTROW("SHEETS"), 0, 0, DTROW("FLIM"), Val(DTROW("WIDTH")), Val(DTROW("LENGTH")), 0, 0, 0, 0, Val(DTROW("JOBDOCKETNO")), 0, "JOBDOCKET", Val(DTROW("ORDERNO")), Val(DTROW("ORDERSRNO")), DTROW("ORDERTYPE"))
                Next
                TXTUPS.Text = 1
            ElseIf DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    GRIDPROD.Rows.Add(0, Val(DTROW("JOBDOCKETNO")), DTROW("NAME"), Val(DTROW("QTY")), Format(Convert.ToDateTime(DTROW("JOBDOCKETDATE")), "dd/MM/yyyy"), DTROW("STATUS"), Val(DTROW("GOODQTY")), 0, 0, 0, 0, DTROW("ITEMNAME"), DTROW("CUTSHEET"), DTROW("CUTSIZE"), DTROW("FULLSHEET"), Val(DTROW("STOCK")), Val(DTROW("ORDERQTY")), Val(DTROW("BALANCE")), DTROW("PAPERNAME"), DTROW("COLOR1"), DTROW("COLOR2"), DTROW("COLOR1PLATES"), DTROW("COLOR2PLATES"), DTROW("COLOR1TYPE"), DTROW("COLOR2TYPE"), DTROW("MODE"), Val(DTROW("SIDE")), Val(DTROW("IMP")), DTROW("FINALIMP"), DTROW("READYTIME"), DTROW("FINISHTIME"), DTROW("GRIDREMARKS"), DTROW("LAMINATIONDATE"), Val(DTROW("SHEETS")), Val(DTROW("GOODQTY")), Val(DTROW("TODO")), DTROW("FLIM"), Val(DTROW("WIDTH")), Val(DTROW("LENGTH")), 0, Val(DTROW("GSM")), 0, Val(DTROW("DONE")), Val(DTROW("FROMNO")), Val(DTROW("FROMSRNO")), "PRODUCTION", Val(DTROW("ORDERNO")), Val(DTROW("ORDERSRNO")), DTROW("ORDERTYPE"))
                Next
                TXTUPS.Text = Val(DT.Rows(0).Item("UPS"))


            End If

            If DT.Rows.Count <> 0 Then
                CMDSELECTJOBDOCKET.Enabled = False
            End If
            TOTAL()
            getsrno(GRIDPROD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(sender As Object, e As CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                'GRIDSHIFT.RowCount = 0
                TEMPRODNO = Val(tstxtbillno.Text)
                If TEMPRODNO > 0 Then
                    EDIT = True
                    Production_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPRODNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub PRINTREPORT(ByVal PRODNO As Integer)
        'Try
        '    If MsgBox("Print Production Report?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        '    Dim OBJDOCKET As New DocketDesign
        '    OBJDOCKET.WHERECLAUSE = "{PRODUCTION.PROD_NO}=" & Val(PRODNO) & " AND {PRODUCTION.PROD_YEARID} =" & YearId
        '    OBJDOCKET.FRMSTRING = "PRODUCTION"
        '    OBJDOCKET.MdiParent = MDIMain
        '    OBJDOCKET.Show()

        'Catch ex As Exception
        '    Throw ex
        'End Try
        Try
            If MsgBox("Print Production Report?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim OBJRPT As New clsReportDesigner("PRODUCTION", System.AppDomain.CurrentDomain.BaseDirectory & "PRODUCTION.xlsx", 2)
            OBJRPT.PRODUCTION_EXCEL(TEMPRODNO, CmpId, YearId)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub GRIDPROD_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GRIDPROD.CellValidating
        Dim colNum As Integer = GRIDPROD.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
        Select Case colNum

            Case GPRINTEDQTY.Index, GEXTRASHEET.Index, GGOODQTY.Index, GREMAINIGQTY.Index, GWASTAGE.Index

                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If GRIDPROD.CurrentCell.Value = Nothing Then GRIDPROD.CurrentCell.Value = "0.00"
                    GRIDPROD.CurrentCell.Value = Convert.ToDecimal(GRIDPROD.Item(colNum, e.RowIndex).Value)

                    TOTAL()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                    'Exit Sub
                End If
        End Select
    End Sub

    Sub TOTAL()
        Try
            LBLTOTALJOBCARDQTY.Text = 0.0
            LBLTOTALPRINTEDQTY.Text = 0.0
            LBLTOTALREMAINIGQTY.Text = 0.0
            LBLTOTALSTOCK.Text = 0.0
            LBLTOTALORDER.Text = 0.0
            LBLTOTALBALANCE.Text = 0.0
            LBLTOTALPLATES.Text = 0.0
            LBLTOTALWASTAGE.Text = 0.0
            LBLTOTALGOODQTY.Text = 0.0
            LBLTOTALEXTRASHEET.Text = 0.0



            For Each ROW As DataGridViewRow In GRIDPROD.Rows
                'ROW.Cells(GBALANCE.Index).Value = Format(Val(ROW.Cells(GSTOCK.Index).EditedFormattedValue) - Val(ROW.Cells(GORDER.Index).EditedFormattedValue), "0.00")

                ROW.Cells(GREMAINIGQTY.Index).Value = Format(Val(ROW.Cells(GPRINTEDQTY.Index).EditedFormattedValue) + Val(ROW.Cells(GEXTRASHEET.Index).EditedFormattedValue) - Val(ROW.Cells(GGOODQTY.Index).EditedFormattedValue) - Val(ROW.Cells(GWASTAGE.Index).EditedFormattedValue), "0.00")

                If Val(ROW.Cells(GJOBCARDQTY.Index).EditedFormattedValue) > 0 Then LBLTOTALJOBCARDQTY.Text = Format(Val(LBLTOTALJOBCARDQTY.Text) + Val(ROW.Cells(GJOBCARDQTY.Index).EditedFormattedValue), "0.00")
                If Val(ROW.Cells(GPRINTEDQTY.Index).EditedFormattedValue) > 0 Then LBLTOTALPRINTEDQTY.Text = Format(Val(LBLTOTALPRINTEDQTY.Text) + Val(ROW.Cells(GPRINTEDQTY.Index).EditedFormattedValue), "0.00")
                If Val(ROW.Cells(GREMAINIGQTY.Index).EditedFormattedValue) > 0 Then LBLTOTALREMAINIGQTY.Text = Format(Val(LBLTOTALREMAINIGQTY.Text) + Val(ROW.Cells(GREMAINIGQTY.Index).EditedFormattedValue), "0.00")
                If Val(ROW.Cells(GSTOCK.Index).EditedFormattedValue) > 0 Then LBLTOTALSTOCK.Text = Format(Val(LBLTOTALSTOCK.Text) + Val(ROW.Cells(GSTOCK.Index).EditedFormattedValue), "0.00")
                If Val(ROW.Cells(GORDER.Index).EditedFormattedValue) > 0 Then LBLTOTALORDER.Text = Format(Val(LBLTOTALORDER.Text) + Val(ROW.Cells(GORDER.Index).EditedFormattedValue), "0.00")
                If Val(ROW.Cells(GBALANCE.Index).EditedFormattedValue) > 0 Then LBLTOTALBALANCE.Text = Format(Val(LBLTOTALBALANCE.Text) + Val(ROW.Cells(GBALANCE.Index).EditedFormattedValue), "0.00")
                If Val(ROW.Cells(GWASTAGE.Index).EditedFormattedValue) > 0 Then LBLTOTALWASTAGE.Text = Format(Val(LBLTOTALWASTAGE.Text) + Val(ROW.Cells(GWASTAGE.Index).EditedFormattedValue), "0.00")
                If Val(ROW.Cells(GGOODQTY.Index).EditedFormattedValue) > 0 Then LBLTOTALGOODQTY.Text = Format(Val(LBLTOTALGOODQTY.Text) + Val(ROW.Cells(GGOODQTY.Index).EditedFormattedValue), "0.00")
                If Val(ROW.Cells(GEXTRASHEET.Index).EditedFormattedValue) > 0 Then LBLTOTALEXTRASHEET.Text = Format(Val(LBLTOTALEXTRASHEET.Text) + Val(ROW.Cells(GEXTRASHEET.Index).EditedFormattedValue), "0.00")


            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(sender As Object, e As CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, CMBCODE, e, Me, TXTADD, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(sender As Object, e As EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPRODUCTIONTYPE_Validated(sender As Object, e As EventArgs) Handles CMBPRODUCTIONTYPE.Validated
        Try
            If CMBPRODUCTIONTYPE.Text.Trim <> "" Then GEXTRASHEET.ReadOnly = True Else GEXTRASHEET.ReadOnly = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class