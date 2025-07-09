Imports BL
Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel

Public Class GRNChecking
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK, gridUPLOADDoubleClick, GRIDOBSERVATIONDOUBLECLICK As Boolean
    Dim TEMPROW, PURREGID As Integer
    Public EDIT As Boolean
    Public TEMPGRNCHKNO, TEMPMSG As String
    Public frmstring As String
    Dim tempUPLOADrow, TEMPOBSERVATIONROW As Integer

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Sub CLEAR()
        TXTNAME.Clear()
        TXTCHECKEDBY.Clear()

        TXTGODOWN.Clear()
        TXTGRNNO.Clear()
        DTGRNDATE.Value = Mydate
        TXTCHKNO.Clear()
        DTCHKDATE.Value = Mydate
        txtremarks.Clear()
        TXTCHALLANNO.Clear()
        DTCHALLANDATE.Value = Mydate
        TXTSHEETSPERREAM.Clear()
        CHKCHALLANNO.Checked = False
        CHKCHALLANDATE.Checked = False
        CHKMATERIALNAME.Checked = False
        CHKSUPPLIERMFGNAME.Checked = False
        CHKNOOFREAM.Checked = False
        CHKDATEOFRECEIPT.Checked = False
        CHKPACKINGOFPAPER.Checked = False
        CHKLABELLINGONCONSIGNMENT.Checked = False
        CHKPHYSICALCONDITION.Checked = False
        CHKNAMEOFMFG.Checked = False
        CHKTEXTMATTER.Checked = False
        CHKGRIPPER.Checked = False
        CHKREGISTRATIONMARK.Checked = False
        CHKACCEPTED.Checked = False

        LBLTOTALQTY.Text = 0.0
        LBLTOTALACCQTY.Text = 0.0
        LBLTOTALREJQTY.Text = 0.0
        GRIDOBSERVATION.RowCount = 0


        GRIDGRNCHECKING.RowCount = 0
        gridupload.RowCount = 0
        GRIDDOUBLECLICK = False
        gridUPLOADDoubleClick = False
        CMDSELECTGRN.Enabled = True

        GETMAX_GRNCHK_NO()

        EP.Clear()
        'PBDN.Visible = False
        'PBPAID.Visible = False
        'PBTDS.Visible = False
        lbllocked.Visible = False


        TXTUPLOADSRNO.Text = 1
        txtuploadremarks.Clear()
        txtuploadname.Clear()
        PBSOFTCOPY.Image = Nothing
        TXTIMGPATH.Clear()
        gridupload.RowCount = 0

        TXTOBSRNO.Text = 1
        TXTOBGSM.Clear()
        TXTOBSIZE.Clear()
        TXTBILLNO.Clear()
        tstxtbillno.Clear()
        TXTPONO.Clear()

    End Sub

    Sub GETMAX_GRNCHK_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(CHECK_no),0) + 1 ", "GRNCHECKING", " AND CHECK_YEARID = " & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTCHKNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        EDIT = False
        CMDSELECTGRN.Focus()
    End Sub

    Private Sub GRNChecking_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.F8 Then
                GRIDGRNCHECKING.Focus()
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
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNChecking_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE INVOICE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            CLEAR()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable
                Dim ALPARAVAL As New ArrayList
                Dim OBJGRNCHK As New ClsGRNChecking

                ALPARAVAL.Add(TEMPGRNCHKNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(YearId)

                OBJGRNCHK.alParaval = ALPARAVAL
                DT = OBJGRNCHK.selectGRNCHK()

                If DT.Rows.Count > 0 Then
                    For Each DR As DataRow In DT.Rows

                        TXTCHKNO.Text = TEMPGRNCHKNO
                        DTCHKDATE.Value = DT.Rows(0).Item("DATE")
                        TXTNAME.Text = DT.Rows(0).Item("NAME")
                        TXTCHECKEDBY.Text = DT.Rows(0).Item("CHECKEDBY")
                        TXTGODOWN.Text = DT.Rows(0).Item("GODOWN")
                        TXTGRNNO.Text = DT.Rows(0).Item("GRNNO")
                        DTGRNDATE.Value = DT.Rows(0).Item("GRNDATE")
                        LBLTOTALQTY.Text = DT.Rows(0).Item("TOTALQTY")
                        LBLTOTALACCQTY.Text = DT.Rows(0).Item("TOTALACCQTY")
                        LBLTOTALREJQTY.Text = DT.Rows(0).Item("TOTALREJQTY")
                        txtremarks.Text = DT.Rows(0).Item("REMARKS")

                        TXTCHALLANNO.Text = DT.Rows(0).Item("CHALLANNO")
                        DTCHALLANDATE.Value = DT.Rows(0).Item("CHALLANDATE")
                        TXTSHEETSPERREAM.Text = DT.Rows(0).Item("SHEETSPERREAM")
                        CHKCHALLANNO.Checked = (DR("CHKCHALLANNO"))
                        CHKCHALLANDATE.Checked = (DR("CHKCHALLANDATE"))
                        CHKMATERIALNAME.Checked = (DR("MATERIALNAME"))
                        CHKSUPPLIERMFGNAME.Checked = (DR("SUPPLIER"))
                        CHKNOOFREAM.Checked = (DR("NOOFREAM"))
                        CHKDATEOFRECEIPT.Checked = (DR("DATEOFRECEIPT"))
                        CHKPACKINGOFPAPER.Checked = (DR("PACKINGOFPAPER"))
                        CHKLABELLINGONCONSIGNMENT.Checked = (DR("LABELLINGONCONSIGNMENT"))
                        CHKPHYSICALCONDITION.Checked = (DR("PHYSICALCOC"))
                        CHKNAMEOFMFG.Checked = (DR("NAMEOFMFG"))
                        CHKTEXTMATTER.Checked = (DR("TEXTMATTER"))
                        CHKGRIPPER.Checked = (DR("GRIPPER"))
                        CHKREGISTRATIONMARK.Checked = (DR("REGISTRATIONMARK"))
                        CHKACCEPTED.Checked = (DR("ACCEPTED"))
                        TXTBILLNO.Text = DR("BILLNO")
                        TXTPONO.Text = DR("PONO")


                        '' grid 
                        GRIDGRNCHECKING.Rows.Add(DR("SRNO").ToString, DR("ITEMNAME").ToString, DR("LOTNO").ToString, Val(DR("GSM")), DR("SIZE").ToString, Format(Val(DR("WT")), "0.00"), Format(Val(DR("QTY")), "0.00"), Format(Val(DR("ACCQTY")), "0.00"), Format(Val(DR("REJQTY")), "0.00"), DR("UNIT").ToString, Val(DR("SHEETS")), DR("DESC"), Val(DR("RATE")), Val(DR("AMOUNT")), Val(DR("GRNNO")), Val(DR("GRNSRNO")), Val(DR("OUTQTY")), DR("TYPE"))
                        'TabControl1.SelectedIndex = (0)


                    Next

                    ' GRID UPLOAD
                    Dim OBJCMNN As New ClsCommon
                    Dim DTTABLE As DataTable = OBJCMNN.search("ISNULL(CHECK_UPSRNO, 0) AS SRNO, ISNULL(CHECK_UPREMARKS, '') AS REMARKS, ISNULL(CHECK_UPNAME, '') AS NAME, CHECK_IMGPATH AS IMGPATH", "", "GRNCHECKING_UPLOAD", "AND GRNCHECKING_UPLOAD.CHECK_NO= " & TEMPGRNCHKNO & "  AND CHECK_YEARID = " & YearId & " ORDER BY GRNCHECKING_UPLOAD.CHECK_UPSRNO")
                    If DTTABLE.Rows.Count > 0 Then
                        For Each DTR As DataRow In DTTABLE.Rows
                            gridupload.Rows.Add(DTR("SRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                        Next
                    End If
                    Dim OBJOB As New ClsCommon
                    Dim DTOB As DataTable = OBJCMNN.search(" ISNULL(GRNCHECKING_OBSERVATION.CHECK_SRNO, '0') AS SRNO, ISNULL(CHECK_GSM, '') AS OBGSM, ISNULL(CHECK_SIZE, '') AS OBSIZE ", "", "GRNCHECKING_OBSERVATION", "AND GRNCHECKING_OBSERVATION.CHECK_NO= " & TEMPGRNCHKNO & "  AND CHECK_YEARID = " & YearId & " ORDER BY GRNCHECKING_OBSERVATION.CHECK_SRNO")
                    If DTOB.Rows.Count > 0 Then
                        For Each DTR As DataRow In DTOB.Rows
                            GRIDOBSERVATION.Rows.Add(DTR("SRNO"), DTR("OBGSM"), DTR("OBSIZE"))
                            GRIDGRNCHECKING.FirstDisplayedScrollingRowIndex = GRIDGRNCHECKING.RowCount - 1
                        Next
                    End If
                End If
                CMDSELECTGRN.Enabled = False
                'CMBNAME.Focus()
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


        'WHILE ADDING COLUMN IN GRNCHECKING DONT FORGET TO ADD SAME COLUMNS IN FORMS GIVEN BELOW
        '1) GRN -- DIRECTGRNCHECKING 

        Dim IntResult As Integer
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(DTCHKDATE.Value.Date)
            ALPARAVAL.Add(TXTNAME.Text.Trim)
            ALPARAVAL.Add(TXTCHECKEDBY.Text.Trim)
            ALPARAVAL.Add(TXTGODOWN.Text.Trim)
            ALPARAVAL.Add(TXTGRNNO.Text.Trim)
            ALPARAVAL.Add(DTGRNDATE.Value.Date)
            ALPARAVAL.Add(txtremarks.Text.Trim)
            ALPARAVAL.Add(LBLTOTALQTY.Text.Trim)
            ALPARAVAL.Add(LBLTOTALACCQTY.Text.Trim)
            ALPARAVAL.Add(LBLTOTALREJQTY.Text.Trim)

            ALPARAVAL.Add(TXTCHALLANNO.Text.Trim)
            ALPARAVAL.Add(DTCHALLANDATE.Value.Date)
            ALPARAVAL.Add(TXTSHEETSPERREAM.Text.Trim)

            'FOR CHECKBOX
            If CHKCHALLANNO.Checked = True Then
                ALPARAVAL.Add(1)
            Else
                ALPARAVAL.Add(0)
            End If

            If CHKCHALLANDATE.Checked = True Then
                ALPARAVAL.Add(1)
            Else
                ALPARAVAL.Add(0)
            End If

            If CHKMATERIALNAME.Checked = True Then
                ALPARAVAL.Add(1)
            Else
                ALPARAVAL.Add(0)
            End If

            If CHKSUPPLIERMFGNAME.Checked = True Then
                ALPARAVAL.Add(1)
            Else
                ALPARAVAL.Add(0)
            End If

            If CHKNOOFREAM.Checked = True Then
                ALPARAVAL.Add(1)
            Else
                ALPARAVAL.Add(0)
            End If

            If CHKDATEOFRECEIPT.Checked = True Then
                ALPARAVAL.Add(1)
            Else
                ALPARAVAL.Add(0)
            End If

            If CHKPACKINGOFPAPER.Checked = True Then
                ALPARAVAL.Add(1)
            Else
                ALPARAVAL.Add(0)
            End If

            If CHKLABELLINGONCONSIGNMENT.Checked = True Then
                ALPARAVAL.Add(1)
            Else
                ALPARAVAL.Add(0)
            End If

            If CHKPHYSICALCONDITION.Checked = True Then
                ALPARAVAL.Add(1)
            Else
                ALPARAVAL.Add(0)
            End If

            If CHKNAMEOFMFG.Checked = True Then
                ALPARAVAL.Add(1)
            Else
                ALPARAVAL.Add(0)
            End If

            If CHKTEXTMATTER.Checked = True Then
                ALPARAVAL.Add(1)
            Else
                ALPARAVAL.Add(0)
            End If

            If CHKGRIPPER.Checked = True Then
                ALPARAVAL.Add(1)
            Else
                ALPARAVAL.Add(0)
            End If

            If CHKREGISTRATIONMARK.Checked = True Then
                ALPARAVAL.Add(1)
            Else
                ALPARAVAL.Add(0)
            End If

            If CHKACCEPTED.Checked = True Then
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


            For Each ROW As Windows.Forms.DataGridViewRow In GRIDGRNCHECKING.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If SRNO = "" Then
                        SRNO = ROW.Cells(GSRNO.Index).Value
                        NONINVITEM = ROW.Cells(GITEMNAME.Index).Value.ToString
                        LOTNO = ROW.Cells(GLOTNO.Index).Value.ToString
                        GSM = Val(ROW.Cells(GGSM.Index).Value)
                        SIZE = ROW.Cells(GBILLSIZE.Index).Value.ToString
                        WT = Val(ROW.Cells(GWT.Index).Value)
                        QTY = Val(ROW.Cells(Gqty.Index).Value)
                        ACCQTY = Val(ROW.Cells(GACCQTY.Index).Value)
                        REJQTY = Val(ROW.Cells(GREJQTY.Index).Value)
                        UNIT = ROW.Cells(GUNIT.Index).Value.ToString
                        SHEETS = Val(ROW.Cells(GSHEETS.Index).Value)
                        DESC = ROW.Cells(gdesc.Index).Value.ToString
                        RATE = Val(ROW.Cells(GRATE.Index).Value)
                        AMOUNT = Val(ROW.Cells(GAMOUNT.Index).Value)
                        GRNNO = Val(ROW.Cells(GGRNNO.Index).Value)
                        GRNSRNO = Val(ROW.Cells(ggrnsrno.Index).Value)
                        OUTQTY = Val(ROW.Cells(GOUTQTY.Index).Value)
                        TYPE = ROW.Cells(GTYPE.Index).Value.ToString

                    Else
                        SRNO = SRNO & "|" & ROW.Cells(GSRNO.Index).Value
                        NONINVITEM = NONINVITEM & "|" & ROW.Cells(GITEMNAME.Index).Value.ToString
                        LOTNO = LOTNO & "|" & ROW.Cells(GLOTNO.Index).Value.ToString
                        GSM = GSM & "|" & Val(ROW.Cells(GGSM.Index).Value)
                        SIZE = SIZE & "|" & ROW.Cells(GBILLSIZE.Index).Value.ToString
                        WT = WT & "|" & Val(ROW.Cells(GWT.Index).Value)
                        QTY = QTY & "|" & Val(ROW.Cells(Gqty.Index).Value)
                        ACCQTY = ACCQTY & "|" & Val(ROW.Cells(GACCQTY.Index).Value)
                        REJQTY = REJQTY & "|" & Val(ROW.Cells(GREJQTY.Index).Value)
                        UNIT = UNIT & "|" & ROW.Cells(GUNIT.Index).Value.ToString
                        SHEETS = SHEETS & "|" & Val(ROW.Cells(GSHEETS.Index).Value)
                        DESC = DESC & "|" & ROW.Cells(gdesc.Index).Value.ToString
                        RATE = RATE & "|" & Val(ROW.Cells(GRATE.Index).Value)
                        AMOUNT = AMOUNT & "|" & Val(ROW.Cells(GAMOUNT.Index).Value)
                        GRNNO = GRNNO & "|" & Val(ROW.Cells(GGRNNO.Index).Value)
                        GRNSRNO = GRNSRNO & "|" & Val(ROW.Cells(ggrnsrno.Index).Value)
                        OUTQTY = OUTQTY & "|" & Val(ROW.Cells(GOUTQTY.Index).Value)
                        TYPE = TYPE & "|" & ROW.Cells(GTYPE.Index).Value.ToString
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



            '' OBERVATION GRID PARAMETERS
            Dim OBSRNO As String = ""
            Dim OBGSM As String = ""
            Dim OBSIZE As String = ""

            For Each ROW As Windows.Forms.DataGridViewRow In GRIDOBSERVATION.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If OBSRNO = "" Then
                        OBSRNO = ROW.Cells(GOSRNO.Index).Value
                        OBGSM = ROW.Cells(GOGSM.Index).Value.ToString
                        OBSIZE = ROW.Cells(GOSIZE.Index).Value.ToString
                    Else
                        OBSRNO = OBSRNO & "|" & ROW.Cells(GOSRNO.Index).Value
                        OBGSM = OBGSM & "|" & ROW.Cells(GOGSM.Index).Value.ToString
                        OBSIZE = OBSIZE & "|" & ROW.Cells(GOSIZE.Index).Value.ToString
                    End If
                End If
            Next
            ALPARAVAL.Add(OBSRNO)
            ALPARAVAL.Add(OBGSM)
            ALPARAVAL.Add(OBSIZE)
            ALPARAVAL.Add(TXTBILLNO.Text.Trim)
            ALPARAVAL.Add(TXTPONO.Text.Trim)


            Dim OBJGRNCHK As New ClsGRNChecking
            OBJGRNCHK.alParaval = ALPARAVAL

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTTABLE As DataTable = OBJGRNCHK.SAVE()
                MsgBox("Details Added !!")
                TEMPGRNCHKNO = DTTABLE.Rows(0).Item(0)
                PRINTREPORT(TEMPGRNCHKNO)

                'If CHKTDS.CheckState = CheckState.Checked Then
                '    Dim OBJTDS As New DeductTDS
                '    OBJTDS.BILLNO = DTTABLE.Rows(0).Item(0)
                '    OBJTDS.REGISTER = cmbregister.Text.Trim
                '    OBJTDS.ShowDialog()
                'End If
            Else

                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                ALPARAVAL.Add(TEMPGRNCHKNO)
                IntResult = OBJGRNCHK.UPDATE()
                MsgBox("Details Updated")
                PRINTREPORT(TEMPGRNCHKNO)
                EDIT = False

            End If
            If gridupload.RowCount > 0 Then SAVEUPLOAD()
            CLEAR()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub SAVEUPLOAD()
        Try
            Dim OBJGRNCHK As New ClsGRNChecking

            For Each ROW As Windows.Forms.DataGridViewRow In gridupload.Rows
                Dim MS As New IO.MemoryStream
                Dim ALPARAVAL As New ArrayList
                If ROW.Cells(GUSRNO.Index).Value <> Nothing Then
                    ALPARAVAL.Add(TEMPGRNCHKNO)
                    ALPARAVAL.Add(ROW.Cells(GUSRNO.Index).Value)
                    ALPARAVAL.Add(ROW.Cells(GUREMARKS.Index).Value)
                    ALPARAVAL.Add(ROW.Cells(GUNAME.Index).Value)

                    PBSOFTCOPY.Image = ROW.Cells(GUIMGPATH.Index).Value
                    PBSOFTCOPY.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    ALPARAVAL.Add(MS.ToArray)
                    ALPARAVAL.Add(YearId)

                    OBJGRNCHK.alParaval = ALPARAVAL
                    Dim INTRESULT As Integer = OBJGRNCHK.SAVEUPLOAD()
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

        If TXTCHECKEDBY.Text.Trim.Length = 0 Then
            EP.SetError(TXTCHECKEDBY, "Please Enter Name")
            bln = False
        End If

        If GRIDGRNCHECKING.RowCount = 0 Then
            EP.SetError(TXTNAME, "Please Enter Item Details")
            bln = False
        End If

        For Each row As DataGridViewRow In GRIDGRNCHECKING.Rows

            If Val(row.Cells(GACCQTY.Index).Value) = 0 And Val(row.Cells(GREJQTY.Index).Value) = 0 Then
                MessageBox.Show("Accepted and Rejected Qty Cannot be 0")
                bln = False
            End If
        Next

        If GRIDGRNCHECKING.RowCount > 0 Then
            For Each ROW As DataGridViewRow In GRIDGRNCHECKING.Rows
                If Val(ROW.Cells(Gqty.Index).Value) < (Val(ROW.Cells(GACCQTY.Index).Value) + Val(ROW.Cells(GREJQTY.Index).Value)) Then
                    MessageBox.Show("Invalid QTY Entered")
                    bln = False
                End If
            Next
        End If


        If GRIDGRNCHECKING.RowCount > 0 And EDIT = False Then
            For Each row As DataGridViewRow In GRIDGRNCHECKING.Rows

                If Val(row.Cells(GGRNNO.Index).Value) > 0 And (row.Cells(ggrnsrno.Index).Value) > 0 And Val(row.Cells(Gqty.Index).Value) > 0 And row.Cells(GTYPE.Index).Value.ToString <> "" Then
                    Dim STRFROMNO As Integer
                    Dim STRFROMSRNO As Integer
                    Dim STRQTY As Double
                    Dim STRTYPE As String


                    STRFROMNO = Val(row.Cells(GGRNNO.Index).Value)
                    STRFROMSRNO = Val(row.Cells(ggrnsrno.Index).Value)
                    STRQTY = Val(row.Cells(Gqty.Index).Value)
                    STRTYPE = row.Cells(GTYPE.Index).Value.ToString

                    Dim objclscommon As New ClsCommonMaster
                    Dim dt As DataTable
                    If STRTYPE = "GRN" Then
                        dt = objclscommon.search(" ISNULL(GRN_QTY,0) - ISNULL(GRN_OUTQTY,0) AS QTY  ", "", " GRN_DESC", " AND GRN_NO= " & STRFROMNO & " AND GRN_SRNO= " & STRFROMSRNO & " AND GRN_cmpid = " & CmpId & " and GRN_Yearid = " & YearId)
                    Else
                        dt = objclscommon.search(" ISNULL(SM_QTY,0) - ISNULL(SM_OUTQTY,0) AS QTY  ", "", " STOCKMASTER", " AND SM_NO= " & STRFROMNO & " AND SM_cmpid = " & CmpId & " and SM_Yearid = " & YearId)
                    End If
                    If dt.Rows.Count <= 0 Then GoTo LINE1
                    If STRQTY > Format(Val(dt.Rows(0).Item(0)), "0.000") Then
LINE1:
                        EP.SetError(LBLTOTALQTY, "Stock Not Present ! ")
                        GRIDGRNCHECKING.CurrentRow.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                        bln = False
                    End If
                End If
            Next
        End If


        If GRIDGRNCHECKING.RowCount > 0 And EDIT = True Then
            For Each row As DataGridViewRow In GRIDGRNCHECKING.Rows

                If Val(row.Cells(GGRNNO.Index).Value) > 0 And (row.Cells(ggrnsrno.Index).Value) > 0 And Val(row.Cells(Gqty.Index).Value) > 0 And row.Cells(GTYPE.Index).Value.ToString <> "" Then
                    Dim STRFROMNO As Integer
                    Dim STRFROMSRNO As Integer
                    Dim STRQTY As Double
                    Dim STRTYPE As String
                    Dim BALQTY As Double

                    STRFROMNO = Val(row.Cells(GGRNNO.Index).Value)
                    STRFROMSRNO = Val(row.Cells(ggrnsrno.Index).Value)
                    STRQTY = Val(row.Cells(Gqty.Index).Value)
                    STRTYPE = row.Cells(GTYPE.Index).Value.ToString


                    Dim objclscommon As New ClsCommonMaster
                    Dim dt As DataTable
                    If STRTYPE = "GRN" Then
                        dt = objclscommon.search(" ISNULL(GRN_QTY,0) - ISNULL(GRN_OUTQTY,0) AS QTY  ", "", " GRN_DESC", " AND GRN_NO= " & STRFROMNO & " AND GRN_SRNO= " & STRFROMSRNO & " AND GRN_cmpid = " & CmpId & " and GRN_Yearid = " & YearId)
                    Else
                        dt = objclscommon.search(" ISNULL(SM_QTY,0) - ISNULL(SM_OUTQTY,0) AS QTY  ", "", " STOCKMASTER", " AND SM_NO= " & STRFROMNO & " AND SM_cmpid = " & CmpId & " and SM_Yearid = " & YearId)
                    End If
                    If dt.Rows.Count > 0 Then
                        BALQTY = Format(Val(dt.Rows(0).Item(0)), "0.000")
                    End If

                    Dim dt1 As DataTable = objclscommon.search(" isnull((GRNCHECKING_DESC.CHECK_QTY),0) AS QTY ", "", " GRNCHECKING_DESC ", " AND CHECK_NO= " & TEMPGRNCHKNO & " AND CHECK_GRNNO= " & Val(STRFROMNO) & " AND CHECK_GRNSRNO = " & Val(STRFROMSRNO) & " and CHECK_Yearid = " & YearId)
                    If dt1.Rows.Count > 0 Then
                        BALQTY = BALQTY + Val(dt1.Rows(0).Item(0))
                    End If

                    If STRQTY > BALQTY Then
                        EP.SetError(LBLTOTALQTY, "Stock Not Present,You Can Select Only " & BALQTY)
                        GRIDGRNCHECKING.CurrentRow.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                        bln = False
                    End If
                    BALQTY = 0
                End If

            Next
        End If

        If Not datecheck(DTCHKDATE.Value) Then
            EP.SetError(DTCHKDATE, "Date not in Accounting Year")
            bln = False
        End If

        If Not datecheck(DTGRNDATE.Value) Then
            EP.SetError(DTGRNDATE, "Date not in Accounting Year")
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
            LBLTOTALACCQTY.Text = 0.0
            LBLTOTALREJQTY.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDGRNCHECKING.Rows
                LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(ROW.Cells(Gqty.Index).Value), "0.00")
                LBLTOTALACCQTY.Text = Format(Val(LBLTOTALACCQTY.Text) + Val(ROW.Cells(GACCQTY.Index).EditedFormattedValue), "0.00")
                LBLTOTALREJQTY.Text = Format(Val(LBLTOTALREJQTY.Text) + Val(ROW.Cells(GREJQTY.Index).EditedFormattedValue), "0.00")
                ROW.Cells(GAMOUNT.Index).Value = Format(ROW.Cells(Gqty.Index).EditedFormattedValue * Val(ROW.Cells(GRATE.Index).EditedFormattedValue), "0.00")
                If LCase(ROW.Cells(GUNIT.Index).Value) = "reams" Then
                    'get SIZE AND GSM FROM NONINV MASTER AND CALC WT
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("ISNULL(NONINV_LENGTH,0) AS LENGTH, ISNULL(NONINV_WIDTH,0) AS WIDTH, ISNULL(NONINV_GSM,0) AS GSM ", "", " NONINVITEMMASTER ", " AND NONINV_NAME = '" & ROW.Cells(GITEMNAME.Index).Value & "' AND NONINV_YEARID = " & YearId)
                    If Val(DT.Rows(0).Item("LENGTH")) > 0 And Val(DT.Rows(0).Item("WIDTH")) > 0 And Val(DT.Rows(0).Item("GSM")) > 0 Then
                        ROW.Cells(GWT.Index).Value = Format(((((Val(DT.Rows(0).Item("LENGTH")) * Val(DT.Rows(0).Item("WIDTH")) * Val(DT.Rows(0).Item("GSM"))) / 3100) / 500) * Val(TXTSHEETSPERREAM.Text.Trim)) * (Val(ROW.Cells(GACCQTY.Index).Value)), "0.000")

                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSRNO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If GRIDDOUBLECLICK = False Then
            'If GRIDGRNCHECKING.RowCount > 0 Then
            '    TXTSRNO.Text = Val(GRIDGRNCHECKING.Rows(GRIDGRNCHECKING.RowCount - 1).Cells(gsrno.Index).Value) + 1
            'Else
            '    TXTSRNO.Text = 1
            'End If
        End If
    End Sub

    Sub fillobservation()
        If GRIDOBSERVATIONDOUBLECLICK = False Then
            GRIDOBSERVATION.Rows.Add(Val(TXTOBSRNO.Text.Trim), TXTOBGSM.Text.Trim, TXTOBSIZE.Text.Trim)
            getsrno(GRIDOBSERVATION)
        ElseIf GRIDOBSERVATIONDOUBLECLICK = True Then

            GRIDOBSERVATION.Item(GOSRNO.Index, TEMPOBSERVATIONROW).Value = Val(TXTOBSRNO.Text.Trim)
            GRIDOBSERVATION.Item(GOGSM.Index, TEMPOBSERVATIONROW).Value = TXTOBGSM.Text.Trim
            GRIDOBSERVATION.Item(GOSIZE.Index, TEMPOBSERVATIONROW).Value = TXTOBSIZE.Text.Trim


            GRIDOBSERVATIONDOUBLECLICK = False
        End If
        GRIDOBSERVATION.FirstDisplayedScrollingRowIndex = GRIDOBSERVATION.RowCount - 1

        TXTOBSRNO.Text = GRIDOBSERVATION.RowCount + 1
        TXTOBGSM.Clear()
        TXTOBSIZE.Clear()


        TXTOBGSM.Focus()
    End Sub

    Sub fillgrid()

        'GRIDGRNCHECKING.Enabled = True

        'If GRIDDOUBLECLICK = False Then
        '    GRIDGRNCHECKING.Rows.Add(Val(TXTSRNO.Text.Trim), CMBNONINVITEM.Text.Trim, txtsize.Text.Trim, Format(Val(txtwt.Text.Trim), "0.00"), Format(Val(txtqty.Text.Trim), "0.00"), Format(Val(TXTACCQTY.Text.Trim), "0.00"), Format(Val(TXTREJQTY.Text.Trim), "0.00"), CMBUNIT.Text.Trim, TXTDESC.Text.Trim, 0, 0, 0)
        '    getsrno(GRIDGRNCHECKING)
        'ElseIf GRIDDOUBLECLICK = True Then
        '    GRIDGRNCHECKING.Item(gsrno.Index, TEMPROW).Value = Val(TXTSRNO.Text)
        '    GRIDGRNCHECKING.Item(GITEMNAME.Index, TEMPROW).Value = CMBNONINVITEM.Text
        '    GRIDGRNCHECKING.Item(gbillsize.Index, TEMPROW).Value = txtsize.Text
        '    GRIDGRNCHECKING.Item(gWt.Index, TEMPROW).Value = Format(Val(txtwt.Text), "0.00")
        '    GRIDGRNCHECKING.Item(GQTY.Index, TEMPROW).Value = Format(Val(txtqty.Text), "0.00")
        '    GRIDGRNCHECKING.Item(GACCQTY.Index, TEMPROW).Value = Format(Val(TXTACCQTY.Text), "0.00")
        '    GRIDGRNCHECKING.Item(GREJQTY.Index, TEMPROW).Value = Format(Val(TXTREJQTY.Text), "0.00")
        '    GRIDGRNCHECKING.Item(GUNIT.Index, TEMPROW).Value = CMBUNIT.Text
        '    GRIDGRNCHECKING.Item(GDESC.Index, TEMPROW).Value = TXTDESC.Text

        '    GRIDDOUBLECLICK = False
        'End If
        'TOTAL()
        'GRIDGRNCHECKING.FirstDisplayedScrollingRowIndex = GRIDGRNCHECKING.RowCount - 1

        'CMBNONINVITEM.Text = ""
        'CMBUNIT.Text = ""
        'txtsize.Clear()
        'txtwt.Clear()
        'txtqty.Clear()
        'TXTACCQTY.Clear()
        'TXTREJQTY.Clear()
        'CMBUNIT.Text = ""
        'TXTDESC.Clear()
        'txtqty.Clear()
        'TXTSRNO.Text = Val(GRIDGRNCHECKING.RowCount)
        'CMBNONINVITEM.Focus()

    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try

LINE1:
            TEMPGRNCHKNO = Val(TXTCHKNO.Text) - 1
Line2:
            If TEMPGRNCHKNO > 0 Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" CHECK_NO ", "", "  GRNCHECKING", " AND CHECK_NO = '" & TEMPGRNCHKNO & "' AND CHECK_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    EDIT = True
                    GRNChecking_Load(sender, e)
                Else
                    TEMPGRNCHKNO = Val(TEMPGRNCHKNO - 1)
                    GoTo Line2
                End If
            Else
                CLEAR()
                EDIT = False
            End If

            If GRIDGRNCHECKING.RowCount = 0 And TEMPGRNCHKNO > 1 Then
                TXTCHKNO.Text = TEMPGRNCHKNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDGRNCHECKING.RowCount = 0
LINE1:
            TEMPGRNCHKNO = Val(TXTCHKNO.Text) + 1
            GETMAX_GRNCHK_NO()
            Dim MAXNO As Integer = TXTCHKNO.Text.Trim
            CLEAR()
            If Val(TXTCHKNO.Text) - 1 >= TEMPGRNCHKNO Then
                EDIT = True
                GRNChecking_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDGRNCHECKING.RowCount = 0 And TEMPGRNCHKNO < MAXNO Then
                TXTGRNNO.Text = TEMPGRNCHKNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstxtbillno.Validated
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDGRNCHECKING.RowCount = 0
            TEMPGRNCHKNO = Val(tstxtbillno.Text)
            If TEMPGRNCHKNO > 0 Then
                EDIT = True
                GRNChecking_Load(sender, e)
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

            Dim OBJGRN As New GRNCheckingDetails
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

    Private Sub tstxtbillno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tstxtbillno.KeyPress
        numkeypress(e, tstxtbillno, Me)
    End Sub

    Private Sub CMBNONINVITEM_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        '    If CMBNONINVITEM.Text.Trim = "" Then FILLNONINVITEM(CMBNONINVITEM, EDIT)
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub CMBNONINVITEM_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        'Try
        '    If CMBNONINVITEM.Text.Trim <> "" Then NONINVITEMVALIDATE(CMBNONINVITEM, e, Me)
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub CMBUNIT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        '    If CMBUNIT.Text.Trim = "" Then fillUNIT(CMBUNIT)
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub CMBUNIT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        'Try
        '    If CMBUNIT.Text.Trim <> "" Then unitvalidate(CMBUNIT, e, Me)
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub gridbill_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDGRNCHECKING.CellValidating

        Try
            Dim colNum As Integer = GRIDGRNCHECKING.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case Gqty.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDGRNCHECKING.CurrentCell.Value = Nothing Then GRIDGRNCHECKING.CurrentCell.Value = "0.00"
                        GRIDGRNCHECKING.CurrentCell.Value = Convert.ToDecimal(GRIDGRNCHECKING.Item(colNum, e.RowIndex).Value)
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

    Private Sub gridbill_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If e.KeyCode = Keys.Delete Then
                GRIDGRNCHECKING.Rows.RemoveAt(GRIDGRNCHECKING.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDGRNCHECKING)
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

                'If Val(GOUTQTY.Index) > 0 Then
                '    MsgBox("Unable To Delete", MsgBoxStyle.Critical)
                '    Exit Sub
                'End If

                If MsgBox("Wish to Delete GRN Checking.?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If MsgBox("Are you Sure?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        Dim alParaval As New ArrayList
                        alParaval.Add(TXTCHKNO.Text.Trim)
                        alParaval.Add(YearId)
                        alParaval.Add(Userid)

                        Dim clsGRNCHK As New ClsGRNChecking()
                        clsGRNCHK.alParaval = alParaval
                        Dim IntResult As Integer = clsGRNCHK.delete()
                        MsgBox("GRN Checking Deleted")
                        CLEAR()
                        EDIT = False
                    End If
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
        If gridUPLOADDoubleClick = False Then
            If gridupload.RowCount > 0 Then
                TXTUPLOADSRNO.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
            Else
                TXTUPLOADSRNO.Text = 1
            End If
        End If
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

    Private Sub gridbill_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        editrow()
    End Sub

    Sub editrow()
        'Try
        '    If GRIDGRNCHECKING.CurrentRow.Index >= 0 And GRIDGRNCHECKING.Item(gsrno.Index, GRIDGRNCHECKING.CurrentRow.Index).Value <> Nothing Then

        '        GRIDDOUBLECLICK = True
        '        TXTSRNO.Text = GRIDGRNCHECKING.Item(gsrno.Index, GRIDGRNCHECKING.CurrentRow.Index).Value
        '        CMBNONINVITEM.Text = GRIDGRNCHECKING.Item(GITEMNAME.Index, GRIDGRNCHECKING.CurrentRow.Index).Value.ToString
        '        txtsize.Text = GRIDGRNCHECKING.Item(gbillsize.Index, GRIDGRNCHECKING.CurrentRow.Index).Value.ToString
        '        txtwt.Text = GRIDGRNCHECKING.Item(gWt.Index, GRIDGRNCHECKING.CurrentRow.Index).Value
        '        txtqty.Text = GRIDGRNCHECKING.Item(GQTY.Index, GRIDGRNCHECKING.CurrentRow.Index).Value
        '        TXTACCQTY.Text = GRIDGRNCHECKING.Item(GACCQTY.Index, GRIDGRNCHECKING.CurrentRow.Index).Value
        '        TXTREJQTY.Text = GRIDGRNCHECKING.Item(GREJQTY.Index, GRIDGRNCHECKING.CurrentRow.Index).Value
        '        CMBUNIT.Text = GRIDGRNCHECKING.Item(GUNIT.Index, GRIDGRNCHECKING.CurrentRow.Index).Value.ToString
        '        TXTDESC.Text = GRIDGRNCHECKING.Item(GDESC.Index, GRIDGRNCHECKING.CurrentRow.Index).Value.ToString

        '        TEMPROW = GRIDGRNCHECKING.CurrentRow.Index
        '        TXTSRNO.Focus()

        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub TXTDESC_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        'Try
        '    If CMBNONINVITEM.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 And CMBUNIT.Text.Trim <> "" Then
        '        fillgrid()

        '    Else
        '        MsgBox("Enter Proper Details")
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub GRIDGRNCHECKING_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDGRNCHECKING.CellValidating

        Try
            Dim colNum As Integer = GRIDGRNCHECKING.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case Gqty.Index, GACCQTY.Index, GREJQTY.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDGRNCHECKING.CurrentCell.Value = Nothing Then GRIDGRNCHECKING.CurrentCell.Value = "0.00"
                        GRIDGRNCHECKING.CurrentCell.Value = Convert.ToDecimal(GRIDGRNCHECKING.Item(colNum, e.RowIndex).Value)
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

    Private Sub GRIDGRNCHECKING_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDGRNCHECKING.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                GRIDGRNCHECKING.Rows.RemoveAt(GRIDGRNCHECKING.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDGRNCHECKING)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPGRNCHKNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal GRNCHKNO As Integer)
        Try
            If MsgBox("Wish to Print QC Approved Label?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim OBJGRN As New GRNCheckingDesign
                OBJGRN.MdiParent = MDIMain
                OBJGRN.FRMSTRING = "QCREPORT"
                OBJGRN.WHERECLAUSE = "{GRNCHECKING.CHECK_NO}=" & Val(GRNCHKNO) & " AND {GRNCHECKING.CHECK_YEARID}=" & YearId
                OBJGRN.Show()
            End If

            If MsgBox("Wish to Paper Test Report?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim OBJGRN As New GRNCheckingDesign
                OBJGRN.MdiParent = MDIMain
                OBJGRN.FRMSTRING = "PAPERTESTREPORT"
                OBJGRN.WHERECLAUSE = "{GRNCHECKING.CHECK_NO}=" & Val(GRNCHKNO) & " AND {GRNCHECKING.CHECK_YEARID}=" & YearId
                OBJGRN.Show()
            End If

            If MsgBox("Wish to Print Raw Material Check-List?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim OBJGRN As New GRNCheckingDesign
                OBJGRN.MdiParent = MDIMain
                OBJGRN.FRMSTRING = "CHECKLIST"
                OBJGRN.WHERECLAUSE = "{GRNCHECKING.CHECK_NO}=" & Val(GRNCHKNO) & " AND {GRNCHECKING.CHECK_YEARID}=" & YearId
                OBJGRN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub CMDSELECTGRN_Click(sender As Object, e As EventArgs) Handles CMDSELECTGRN.Click

        Try

            If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            'If CMBNAME.Text.Trim <> "" Then

            Dim OBJSELECTGRN As New SelectGRN
            'OBJSELECTGRN.PARTYNAME = CMBNAME.Text
            OBJSELECTGRN.FORMNAME = "CHECKING"
            Dim DTGRN As DataTable = OBJSELECTGRN.DT
            OBJSELECTGRN.ShowDialog()


            Dim i As Integer = 0
            If DTGRN.Rows.Count > 0 Then

                Dim OBJCMN As New ClsCommon

                For Each DTROW As DataRow In DTGRN.Rows
                    Dim DT As DataTable
                    If DTROW(2) = "GRN" Then
                        DT = OBJCMN.search(" GRN.GRN_NO AS GRNNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(GRN.GRN_CHALLANNO, '') AS CHALLANNO, GRN.GRN_CHALLANDATE AS CHALLANDATE, ISNULL(GRN.GRN_SHEETSPERREAM, 0) AS SHEETSPERREAM, ISNULL(GRN_DESC.GRN_SHEETS, '') AS SHEETS, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(TRANSPORT.Acc_cmpname, '') AS TRANSPORT, GRN.GRN_DATE AS GRNDATE, GRN_DESC.GRN_SRNO AS GRNSRNO, ISNULL(GRN_DESC.GRN_LOTNO, 0) AS LOTNO, ISNULL(GRN_DESC.GRN_GSM, 0) AS GSM, ISNULL(GRN_DESC.GRN_SIZE, 0) AS SIZE, ISNULL(GRN_DESC.GRN_WT, 0) AS WT, ISNULL(GRN_DESC.GRN_QTY - GRN_DESC.GRN_OUTQTY, 0) AS QTY, '" & DTROW(2) & "' AS TYPE, ISNULL(GRN.GRN_BILLNO, '') AS BILLNO,ISNULL(GRN.GRN_PONO, 0) AS PONO,  ISNULL(GRN_DESC.GRN_RATE, 0) AS RATE, ISNULL(GRN_DESC.GRN_AMOUNT, 0) AS AMOUNT ", "", " GRN INNER JOIN GRN_DESC ON GRN.GRN_NO = GRN_DESC.GRN_NO AND GRN.GRN_YEARID = GRN_DESC.GRN_YEARID INNER JOIN LEDGERS ON GRN.GRN_LEDGERID = LEDGERS.Acc_id INNER JOIN GODOWNMASTER ON GRN.GRN_GODOWNID = GODOWNMASTER.GODOWN_id INNER JOIN NONINVITEMMASTER ON GRN_DESC.GRN_ITEMID = NONINVITEMMASTER.NONINV_ID INNER JOIN UNITMASTER ON GRN_DESC.GRN_UNITID = UNITMASTER.unit_id LEFT OUTER JOIN LEDGERS AS TRANSPORT ON GRN.GRN_TRANSID = TRANSPORT.Acc_id ", " AND GRN.GRN_NO = " & Val(DTROW(0)) & " AND GRN_DESC.GRN_SRNO = " & Val(DTROW(1)) & " AND GRN.GRN_YEARID = " & YearId)
                    Else
                        DT = OBJCMN.search(" STOCKMASTER.SM_NO AS GRNNO,ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, 0 AS SHEETS, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, STOCKMASTER.SM_DATE AS GRNDATE, STOCKMASTER.SM_GRIDSRNO AS GRNSRNO, ISNULL(STOCKMASTER.SM_BATCHNO, '') AS LOTNO, ISNULL(STOCKMASTER.SM_SIZE, '') AS SIZE, ISNULL(STOCKMASTER.SM_WT, 0) AS WT, ISNULL((STOCKMASTER.SM_QTY - STOCKMASTER.SM_OUTQTY),0 ) AS QTY ,'" & DTROW(2) & "'AS TYPE ", "", "STOCKMASTER INNER JOIN LEDGERS ON STOCKMASTER.SM_LEDGERID = LEDGERS.Acc_id INNER JOIN GODOWNMASTER ON STOCKMASTER.SM_GODOWNID = GODOWNMASTER.GODOWN_id INNER JOIN NONINVITEMMASTER ON STOCKMASTER.SM_ITEMID = NONINVITEMMASTER.NONINV_ID INNER JOIN UNITMASTER ON STOCKMASTER.SM_UNITID = UNITMASTER.unit_id", "AND STOCKMASTER.SM_NO = " & Val(DTROW(0)) & " AND STOCKMASTER.SM_GRIDSRNO = " & Val(DTROW(1)) & " AND STOCKMASTER.SM_YEARID = " & YearId)
                    End If
                    If DT.Rows.Count > 0 Then

                        TXTGRNNO.Text = DT.Rows(0).Item(0)
                        DTGRNDATE.Text = DT.Rows(0).Item("GRNDATE")
                        TXTNAME.Text = DT.Rows(0).Item("NAME")
                        TXTGODOWN.Text = DT.Rows(0).Item("GODOWN")
                        TXTCHALLANNO.Text = DT.Rows(0).Item("CHALLANNO")
                        DTCHALLANDATE.Text = DT.Rows(0).Item("CHALLANDATE")
                        TXTSHEETSPERREAM.Text = DT.Rows(0).Item("SHEETSPERREAM")
                        TXTBILLNO.Text = DT.Rows(0).Item("BILLNO")
                        TXTPONO.Text = DT.Rows(0).Item("PONO")

                        'ITEM GRID
                        For Each ROW As DataRow In DT.Rows
                            GRIDGRNCHECKING.Rows.Add(0, ROW("ITEMNAME"), ROW("LOTNO").ToString, Format(Val(ROW("GSM")), "0.00"), ROW("SIZE"), Format(Val(ROW("WT")), "0.00"), Format(Val(ROW("QTY")), "0.00"), 0, 0, ROW("UNIT"), Val(ROW("SHEETS")), "", Format(Val(ROW("RATE")), "0.00"), Format(Val(ROW("AMOUNT")), "0.00"), Val(ROW("GRNNO")), Val(ROW("GRNSRNO")), 0, ROW("TYPE"))
                        Next

                        TOTAL()
                        getsrno(GRIDGRNCHECKING)
                        'CMBNONINVITEM.Focus()
                        DTGRNDATE.Enabled = False
                        CMDSELECTGRN.Enabled = False
                    End If
                Next
            End If

            'Else
            'MsgBox("Enter Party Name")
            'CMBNAME.Focus()
            'End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTOBSIZE_Validating(sender As Object, e As CancelEventArgs) Handles TXTOBSIZE.Validating
        Try
            If TXTOBGSM.Text.Trim <> "" And TXTOBSIZE.Text.Trim <> "" Then
                fillobservation()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDOBSERVATION_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDOBSERVATION.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Sub
            If e.RowIndex >= 0 And GRIDOBSERVATION.Item(GOSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDOBSERVATIONDOUBLECLICK = True
                TXTOBSRNO.Text = GRIDOBSERVATION.Item(GOSRNO.Index, e.RowIndex).Value
                TXTOBGSM.Text = GRIDOBSERVATION.Item(GOGSM.Index, e.RowIndex).Value
                TXTOBSIZE.Text = GRIDOBSERVATION.Item(GOSIZE.Index, e.RowIndex).Value


                TEMPOBSERVATIONROW = e.RowIndex
                TXTOBGSM.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDOBSERVATION_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDOBSERVATION.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDOBSERVATION.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If GRIDOBSERVATIONDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDOBSERVATION.Rows.RemoveAt(GRIDOBSERVATION.CurrentRow.Index)
                getsrno(GRIDOBSERVATION)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBILLNO_Validating(sender As Object, e As CancelEventArgs) Handles TXTBILLNO.Validating
        Try

            '---ITS DONE BY GULKIT NO NEEED VALIDATION FOR AMR

            'If TXTBILLNO.Text.Trim <> "" Then
            '    Dim OBJGRNCHECK As New ClsCommon
            '    Dim DT As DataTable
            '    DT = OBJGRNCHECK.search(" GRNCHECKING.CHECK_BILLNO, LEDGERS.ACC_CMPNAME ", "", " LEDGERS INNER JOIN GRNCHECKING ON LEDGERS.Acc_id = GRNCHECKING.CHECK_LEDGERID ", " AND GRNCHECKING.CHECK_BILLNO = '" & TXTBILLNO.Text.Trim & "' and LEDGERS.ACC_CMPNAME = '" & TXTNAME.Text.Trim & "' and GRNCHECKING.CHECK_YEARID = '" & YearId & "' ")
            '    If DT.Rows.Count > 0 Then
            '        MsgBox("Bill No Already Present", MsgBoxStyle.Critical, "PrintPro")
            '        e.Cancel = True
            '    End If
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class

