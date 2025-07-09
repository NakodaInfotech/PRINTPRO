Imports BL
Imports System.Windows.Forms

Public Class PlateReturned
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim tempRow As Integer
    Public EDIT As Boolean
    Public TEMPRETURNNO As String
    Public tempMsg As Integer

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            CLEAR()
            EDIT = False
            TXTTAKENBY.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        TXTTAKENBY.Clear()
        CMBDEPARTMENT.Text = ""
        TXTGIVENBY.Clear()
        TXTBATCHNO.Clear()
        CMBGODOWN.Text = ""
        TXTITEMCODE.Clear()
        TXTITEMNAME.Clear()
        CMDSELECTBATCH.Enabled = True

        DTRETURNDATE.Value = Mydate
        GRIDPLATE.RowCount = 0
        lbltotalqty.Text = "0.00"
        EP.CLEAR()

        GETMAX_RETURN_NO()
        tstxtbillno.Clear()
    End Sub

    Sub GETMAX_RETURN_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" ISNULL(MAX(RETURN_NO),0) + 1 ", "PLATERETURN", " AND RETURN_YEARID=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTRETURNNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Sub FILLCMB()
        If CMBDEPARTMENT.Text.Trim = "" Then FILLDEPARTMNET(CMBDEPARTMENT, EDIT)
        If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
    End Sub

    Private Sub PlateReturned_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then CMDOK_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.F8 Then
                GRIDPLATE.Focus()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then
                tstxtbillno.Focus()
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call toolprevious_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call toolnext_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PlateReturned_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'CONSUMPTION'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCMB()
            CLEAR()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim ALPARAVAL As New ArrayList
                Dim OBJPLATEISSUE As New ClsPlateReturn

                ALPARAVAL.Add(TEMPRETURNNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(YearId)

                OBJPLATEISSUE.alParaval = ALPARAVAL
                Dim dt As DataTable = OBJPLATEISSUE.SELECTPLATERETURN()

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTRETURNNO.Text = TEMPRETURNNO
                        DTRETURNDATE.Value = Convert.ToDateTime(dr("DATE"))
                        TXTTAKENBY.Text = Convert.ToString(dr("TAKENBY"))
                        TXTGIVENBY.Text = Convert.ToString(dr("GIVENBY"))
                        TXTBATCHNO.Text = Convert.ToString(dr("BATCHNO"))
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN"))
                        CMBDEPARTMENT.Text = Convert.ToString(dr("DEPARTMENT"))
                        TXTITEMCODE.Text = Convert.ToString(dr("ITEMCODE"))
                        TXTITEMNAME.Text = Convert.ToString(dr("ITEMNAME"))
                        lbltotalqty.Text = Format(Val(dr("TOTALQTY")), "0.00")
                        txtremarks.Text = Convert.ToString(dr("remarks"))
                        TXTCHALLANNO.Text = Convert.ToString(dr("CHALLANNO"))


                        GRIDPLATE.Rows.Add(Val(dr("SRNO")), dr("NONINVITEM").ToString, Format(Val(dr("QTY").ToString), "0.00"), Format(Val(dr("RATE").ToString), "0.00"), Format(Val(dr("AMOUNT").ToString), "0.00"), Val(dr("OUTQTY")), Val(dr("ISSUENO")), Val(dr("ISSUESRNO")), dr("UNIT"))
                    Next
                    GRIDPLATE.FirstDisplayedScrollingRowIndex = GRIDPLATE.RowCount - 1
                End If
                CMDSELECTBATCH.Enabled = False
                TOTAL()
            Else
                EDIT = False
                CLEAR()
                TXTTAKENBY.Focus()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Dim IntResult As Integer
        Try
            Cursor.Current = Cursors.WaitCursor
            Ep.Clear()

            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(DTRETURNDATE.Value.Date)
            ALPARAVAL.Add(TXTTAKENBY.Text.Trim)
            ALPARAVAL.Add(CMBDEPARTMENT.Text.Trim)
            ALPARAVAL.Add(TXTGIVENBY.Text.Trim)
            ALPARAVAL.Add(TXTBATCHNO.Text.Trim)
            ALPARAVAL.Add(CMBGODOWN.Text.Trim)
            ALPARAVAL.Add(TXTITEMNAME.Text.Trim)
            ALPARAVAL.Add(Val(lbltotalqty.Text.Trim))
            ALPARAVAL.Add(txtremarks.Text.Trim)
            ALPARAVAL.Add(TXTCHALLANNO.Text.Trim)


            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            '' GRID PARAMETERS
            Dim GRIDSRNO As String = ""
            Dim GRIDITEMNAME As String = ""
            Dim GRIDQTY As String = ""
            Dim GRIDRATE As String = ""
            Dim GRIDAMOUNT As String = ""
            Dim GRIDOUTQTY As String = ""
            Dim GRIDISSUENO As String = ""
            Dim GRIDISSUESRNO As String = ""
            Dim UNIT As String = ""

            For Each ROW As Windows.Forms.DataGridViewRow In GRIDPLATE.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = ROW.Cells(gsrno.Index).Value
                        GRIDITEMNAME = ROW.Cells(GITEMNAME.Index).Value.ToString
                        GRIDQTY = Val(ROW.Cells(gQty.Index).Value)
                        GRIDRATE = Val(ROW.Cells(GRATE.Index).Value)
                        GRIDAMOUNT = Val(ROW.Cells(GAMOUNT.Index).Value)
                        GRIDOUTQTY = Val(ROW.Cells(GOUTQTY.Index).Value)
                        GRIDISSUENO = Val(ROW.Cells(GISSUENO.Index).Value)
                        GRIDISSUESRNO = Val(ROW.Cells(GISSUESRNO.Index).Value)
                        UNIT = ROW.Cells(GUNIT.Index).Value.ToString

                    Else
                        GRIDSRNO = GRIDSRNO & "|" & ROW.Cells(gsrno.Index).Value
                        GRIDITEMNAME = GRIDITEMNAME & "|" & ROW.Cells(GITEMNAME.Index).Value.ToString
                        GRIDQTY = GRIDQTY & "|" & Val(ROW.Cells(gQty.Index).Value)
                        GRIDRATE = GRIDRATE & "|" & Val(ROW.Cells(GRATE.Index).Value)
                        GRIDAMOUNT = GRIDAMOUNT & "|" & Val(ROW.Cells(GAMOUNT.Index).Value)
                        GRIDOUTQTY = GRIDOUTQTY & "|" & Val(ROW.Cells(GOUTQTY.Index).Value)
                        GRIDISSUENO = GRIDISSUENO & "|" & Val(ROW.Cells(GISSUENO.Index).Value)
                        GRIDISSUESRNO = GRIDISSUESRNO & "|" & Val(ROW.Cells(GISSUESRNO.Index).Value)
                        UNIT = UNIT & "|" & ROW.Cells(GUNIT.Index).Value.ToString
                    End If
                End If
            Next
            ALPARAVAL.Add(GRIDSRNO)
            ALPARAVAL.Add(GRIDITEMNAME)
            ALPARAVAL.Add(GRIDQTY)
            ALPARAVAL.Add(GRIDRATE)
            ALPARAVAL.Add(GRIDAMOUNT)
            ALPARAVAL.Add(GRIDOUTQTY)
            ALPARAVAL.Add(GRIDISSUENO)
            ALPARAVAL.Add(GRIDISSUESRNO)
            ALPARAVAL.Add(UNIT)

            Dim OBJISSUE As New ClsPlateReturn
            OBJISSUE.alParaval = ALPARAVAL

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTT As DataTable = OBJISSUE.save()
                TEMPRETURNNO = DTT.Rows(0).Item(0)
                MsgBox("Deatils Added !!")
                'PRINTREPORT(TEMPISSUENO)

            Else

                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                ALPARAVAL.Add(TEMPRETURNNO)
                IntResult = OBJISSUE.update()
                MsgBox("Details Updated")
                'PRINTREPORT(TEMPBILLNO)
                EDIT = False

            End If
            CLEAR()
            TXTTAKENBY.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(gsrno.Index).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub TOTAL()
        lbltotalqty.Text = 0.0
        For Each row As DataGridViewRow In GRIDPLATE.Rows
            If Val(row.Cells(gQty.Index).Value) <> 0 Then
                lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(row.Cells(gQty.Index).EditedFormattedValue), "0.00")
                row.Cells(GAMOUNT.Index).Value = Format(row.Cells(gQty.Index).EditedFormattedValue * Val(row.Cells(GRATE.Index).EditedFormattedValue), "0.00")
            End If
        Next
    End Sub

    Private Function ERRORVALID() As Boolean
        Dim BLN As Boolean = True

        If TXTTAKENBY.Text.Trim = "" Then
            Ep.SetError(TXTTAKENBY, "Please Enter Name")
            BLN = False
        End If

        If TXTGIVENBY.Text.Trim = "" Then
            Ep.SetError(TXTGIVENBY, "Please Enter Name")
            BLN = False
        End If

        If CMBGODOWN.Text.Trim = "" Then
            Ep.SetError(CMBGODOWN, "Please Enter Godown Name")
            BLN = False
        End If
        If CMBDEPARTMENT.Text.Trim = "" Then
            Ep.SetError(CMBDEPARTMENT, "Please Enter Department Name")
            BLN = False
        End If

        If GRIDPLATE.RowCount = 0 Then
            Ep.SetError(TXTTAKENBY, "Enter Plate/Batch Details")
            BLN = False
        End If

        If GRIDPLATE.RowCount > 0 And EDIT = False Then
            For Each ROW As DataGridViewRow In GRIDPLATE.Rows
                Dim OBJCMN As New ClsCommonMaster
                Dim DT As DataTable = OBJCMN.search("ISNULL(ISSUE_QTY,0) AS QTY", "", "PLATEISSUE_DESC INNER JOIN NONINVITEMMASTER ON PLATEISSUE_DESC.ISSUE_NONINVID = NONINVITEMMASTER.NONINV_ID INNER JOIN UNITMASTER ON PLATEISSUE_DESC.ISSUE_UNITID = UNITMASTER.unit_id ", "AND PLATEISSUE_DESC.ISSUE_NO = " & ROW.Cells(GISSUENO.Index).Value & " AND PLATEISSUE_DESC.ISSUE_GRIDSRNO = " & ROW.Cells(GISSUESRNO.Index).Value & " and NONINV_NAME = '" & ROW.Cells(GITEMNAME.Index).Value & "' AND UNIT_ABBR = '" & ROW.Cells(GUNIT.Index).Value & "'  AND PLATEISSUE_DESC.ISSUE_Yearid = " & YearId)
                If DT.Rows.Count <= 0 Then GoTo LINE1
                If Val(ROW.Cells(gQty.Index).Value) > Val(DT.Rows(0).Item(0)) Then
LINE1:
                    Ep.SetError(lbltotalqty, "Plate Not Present ! ")
                    GRIDPLATE.CurrentRow.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                    BLN = False
                End If
            Next
        End If


        If GRIDPLATE.RowCount > 0 And EDIT = True Then
            For Each ROW As DataGridViewRow In GRIDPLATE.Rows
                Dim BALQTY As Double = 0
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search("ISNULL((PLATEISSUE_DESC.ISSUE_QTY - PLATEISSUE_DESC.ISSUE_OUTQTY), 0) AS QTY ", "", "PLATEISSUE_DESC", "AND PLATEISSUE_DESC.ISSUE_NO= " & ROW.Cells(GISSUENO.Index).Value & " AND PLATEISSUE_DESC.ISSUE_GRIDSRNO= " & ROW.Cells(GISSUESRNO.Index).Value & " AND PLATEISSUE_DESC.ISSUE_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then BALQTY = Format(Val(dt.Rows(0).Item(0)), "0.00")

                dt = objclscommon.search(" ISNULL(RETURN_QTY,0) AS QTY ", "", "  PLATERETURN_DESC ", " AND PLATERETURN_DESC.RETURN_NO = " & TEMPRETURNNO & " and PLATERETURN_DESC.RETURN_ISSUENO = " & ROW.Cells(GISSUENO.Index).Value & " AND PLATERETURN_DESC.RETURN_ISSUESRNO = " & ROW.Cells(GISSUESRNO.Index).Value & " and PLATERETURN_DESC.RETURN_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then BALQTY = BALQTY + Val(dt.Rows(0).Item(0))

                If Val(ROW.Cells(gQty.Index).Value) > BALQTY Then
                    Ep.SetError(lbltotalqty, "Plates are exceeds than Issued! " & BALQTY)
                    GRIDPLATE.CurrentRow.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                    BLN = False
                End If
                BALQTY = 0
            Next
        End If

        For Each row As DataGridViewRow In GRIDPLATE.Rows
            If Val(row.Cells(gQty.Index).Value) <= 0 Then
                Ep.SetError(lbltotalqty, "Quantity cannot be 0 or less")
                BLN = False
            End If
        Next
        If Not datecheck(DTRETURNDATE.Value) Then BLN = False

        Return BLN
    End Function

    Private Sub CMBDEPARTMENT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDEPARTMENT.Enter
        Try
            If CMBDEPARTMENT.Text.Trim = "" Then FILLDEPARTMNET(CMBDEPARTMENT, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEPARTMENT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDEPARTMENT.Validating
        Try
            If CMBDEPARTMENT.Text.Trim <> "" Then DEPARTMENTVALIDATE(CMBDEPARTMENT, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If EDIT = True Then
                Dim BLN As Boolean = True
                Dim TEMPMSG As Integer = MsgBox("Delete Return Item?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    Dim ALPARAVAL As New ArrayList
                    Dim OBJISSUE As New ClsPlateReturn

                    ALPARAVAL.Add(TEMPRETURNNO)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)

                    OBJISSUE.alParaval = ALPARAVAL
                    Dim IntResult As Integer = OBJISSUE.delete()
                    MsgBox("Returned Item Deleted")
                    CLEAR()

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJPLATERETURNED As New PlateReturnedDetails
            OBJPLATERETURNED.MdiParent = MDIMain
            OBJPLATERETURNED.Show()
            OBJPLATERETURNED.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
LINE1:
            TEMPRETURNNO = Val(TXTRETURNNO.Text) - 1
Line2:
            If TEMPRETURNNO > 0 Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" RETURN_NO ", "", " PLATERETURN", " AND RETURN_NO = '" & TEMPRETURNNO & "' AND RETURN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    EDIT = True
                    PlateReturned_Load(sender, e)
                Else
                    TEMPRETURNNO = Val(TEMPRETURNNO - 1)
                    GoTo Line2
                End If
            Else
                CLEAR()
                EDIT = False
            End If

            If GRIDPLATE.RowCount = 0 And TEMPRETURNNO > 1 Then
                TXTRETURNNO.Text = TEMPRETURNNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDPLATE.RowCount = 0
LINE1:
            TEMPRETURNNO = Val(TXTRETURNNO.Text) + 1
            GETMAX_RETURN_NO()
            Dim MAXNO As Integer = TXTRETURNNO.Text.Trim
            CLEAR()
            If Val(TXTRETURNNO.Text) - 1 >= TEMPRETURNNO Then
                EDIT = True
                PlateReturned_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDPLATE.RowCount = 0 And TEMPRETURNNO < MAXNO Then
                TXTRETURNNO.Text = TEMPRETURNNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub DTRETURNDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DTRETURNDATE.Validating
        If Not datecheck(DTRETURNDATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub tstxtbillno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstxtbillno.Validated
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDPLATE.RowCount = 0
            TEMPRETURNNO = Val(tstxtbillno.Text)
            If TEMPRETURNNO > 0 Then
                EDIT = True
                PlateReturned_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call CMDOK_Click(sender, e)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call CMDDELETE_Click(sender, e)
    End Sub

    Private Sub tstxtbillno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tstxtbillno.KeyPress
        numkeypress(e, tstxtbillno, Me)
    End Sub

    Private Sub GRIDPLATE_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDPLATE.CellValidating
        'TOTAL()
        Try
            Dim colNum As Integer = GRIDPLATE.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case gQty.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDPLATE.CurrentCell.Value = Nothing Then GRIDPLATE.CurrentCell.Value = "0.00"
                        GRIDPLATE.CurrentCell.Value = Convert.ToDecimal(GRIDPLATE.Item(colNum, e.RowIndex).Value)
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

    Private Sub GRIDPLATE_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDPLATE.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                GRIDPLATE.Rows.RemoveAt(GRIDPLATE.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDPLATE)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTBATCH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTBATCH.Click
        Try
            If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJSELECTPLATE As New SelectPlateIssued
            Dim DTPR As DataTable = OBJSELECTPLATE.DT
            OBJSELECTPLATE.ShowDialog()

            Dim i As Integer = 0
            If DTPR.Rows.Count > 0 Then
                Dim OBJCMN As New ClsCommon

                For Each DTROW As DataRow In DTPR.Rows

                    Dim DT As DataTable = OBJCMN.search("  ISNULL(PLATEISSUE.ISSUE_NO, 0) AS PLATENO, ISNULL(PLATEISSUE_DESC.ISSUE_GRIDSRNO, 0) AS SRNO, ISNULL(PLATEISSUE.ISSUE_BATCHNO, 0) AS BATCHNO, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, PLATEISSUE.ISSUE_DATE AS DATE, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(DEPARTMENTMASTER.DEPARTMENT_name, '') AS DEPARTMENT, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS NONINVITEM, ISNULL(PLATEISSUE_DESC.ISSUE_QTY - PLATEISSUE_DESC.ISSUE_OUTQTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(PLATEISSUE_DESC.ISSUE_RATE, 0) AS RATE, ISNULL(PLATEISSUE_DESC.ISSUE_AMOUNT, 0) AS AMOUNT , ISNULL(PLATEISSUE.ISSUE_CHALLANNO, '') AS CHALLANNO ", "", " PLATEISSUE INNER JOIN PLATEISSUE_DESC ON PLATEISSUE.ISSUE_NO = PLATEISSUE_DESC.ISSUE_no AND PLATEISSUE.ISSUE_yearid = PLATEISSUE_DESC.ISSUE_yearid INNER JOIN DEPARTMENTMASTER ON PLATEISSUE.ISSUE_DEPARTMENTID = DEPARTMENTMASTER.DEPARTMENT_id AND PLATEISSUE.ISSUE_yearid = DEPARTMENTMASTER.DEPARTMENT_yearid INNER JOIN GODOWNMASTER ON PLATEISSUE.ISSUE_GODOWNID = GODOWNMASTER.GODOWN_id AND PLATEISSUE.ISSUE_yearid = GODOWNMASTER.GODOWN_yearid INNER JOIN NONINVITEMMASTER ON PLATEISSUE_DESC.ISSUE_NONINVID = NONINVITEMMASTER.NONINV_ID AND PLATEISSUE_DESC.ISSUE_yearid = NONINVITEMMASTER.NONINV_YEARID INNER JOIN ITEMMASTER ON PLATEISSUE.ISSUE_ITEMID = ITEMMASTER.item_id AND PLATEISSUE.ISSUE_yearid = ITEMMASTER.item_yearid INNER JOIN UNITMASTER ON PLATEISSUE_DESC.ISSUE_UNITID = UNITMASTER.unit_id", " AND PLATEISSUE.ISSUE_NO = " & Val(DTROW(0)) & " AND PLATEISSUE_DESC.ISSUE_GRIDSRNO = " & Val(DTROW(1)) & " AND PLATEISSUE.ISSUE_yearid = " & YearId)
                    If DT.Rows.Count > 0 Then

                        'CMBGODOWN.Enabled = False
                        CMBGODOWN.Text = DT.Rows(0).Item("GODOWN").ToString
                        TXTBATCHNO.Text = DT.Rows(0).Item("BATCHNO").ToString
                        CMBDEPARTMENT.Text = DT.Rows(0).Item("DEPARTMENT").ToString
                        TXTITEMNAME.Text = DT.Rows(0).Item("ITEMNAME").ToString
                        TXTITEMCODE.Text = DT.Rows(0).Item("ITEMCODE").ToString
                        TXTCHALLANNO.Text = DT.Rows(0).Item("CHALLANNO").ToString



                        'ITEM GRID
                        For Each ROW As DataRow In DT.Rows
                            GRIDPLATE.Rows.Add(0, ROW("NONINVITEM"), Format(Val(ROW("QTY")), "0.00"), Format(Val(ROW("RATE")), "0.00"), Format(Val(ROW("AMOUNT")), "0.00"), 0, Val(ROW("PLATENO")), Val(ROW("SRNO")), ROW("UNIT"))
                        Next
                        TOTAL()
                        getsrno(GRIDPLATE)
                        CMDSELECTBATCH.Enabled = False
                        'TXTRETURNNO.Focus()
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class