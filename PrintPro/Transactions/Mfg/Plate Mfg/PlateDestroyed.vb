
Imports BL

Public Class PlateDestroyed
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim tempRow As Integer
    Public EDIT As Boolean
    Public TEMPDESTROYENO As String
    Public tempMsg As Integer

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            CLEAR()
            EDIT = False
            TXTDESTROYEDBY.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        TXTDESTROYEDBY.Clear()
        TXTAPPROVEDBY.Clear()
        CMBGODOWN.Text = ""
        txtremarks.Clear()
        DTDESTROYEDATE.Value = Mydate
        GRIDPLATE.RowCount = 0
        lbltotalqty.Text = "0.00"
        EP.CLEAR()
        CMDSELECTPLATE.Enabled = True
        GETMAX_DESTROYED_NO()
        tstxtbillno.Clear()
        TXTCHALLANNO.Clear()

    End Sub

    Sub GETMAX_DESTROYED_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" ISNULL(MAX(DESTROYE_NO),0) + 1 ", "PLATEDESTROYED", " AND DESTROYE_YEARID=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTDESTROYEDNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Sub FILLCMB()
        If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
    End Sub

    Private Sub PlateDestroyed_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub PlateDestroyed_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'CONSUMPTION'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            FILLCMB()
            CLEAR()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable
                Dim ALPARAVAL As New ArrayList
                Dim OBJDES As New ClsPlateDestroyed

                ALPARAVAL.Add(TEMPDESTROYENO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(YearId)

                OBJDES.alParaval = ALPARAVAL
                DT = OBJDES.SELECTPLATEDESTROYED()

                If DT.Rows.Count > 0 Then
                    For Each DR As DataRow In DT.Rows

                        TXTDESTROYEDNO.Text = TEMPDESTROYENO
                        DTDESTROYEDATE.Value = DT.Rows(0).Item("DATE")
                        TXTDESTROYEDBY.Text = DT.Rows(0).Item("DESTROYEDBY")
                        TXTAPPROVEDBY.Text = DT.Rows(0).Item("APPROVEDBY")
                        CMBGODOWN.Text = DR("GODOWN")
                        lbltotalqty.Text = DT.Rows(0).Item("TOTALQTY")
                        txtremarks.Text = DT.Rows(0).Item("REMARKS")
                        TXTCHALLANNO.Text = Convert.ToString(DR("CHALLANNO"))


                        GRIDPLATE.Rows.Add(Val(dr("SRNO")), dr("PLATENO").ToString, Format(Val(dr("QTY").ToString), "0.00"), dr("UNIT").ToString, Format(Val(dr("RATE").ToString), "0.00"), Format(Val(dr("AMOUNT").ToString), "0.00"))
                    Next
                    GRIDPLATE.FirstDisplayedScrollingRowIndex = GRIDPLATE.RowCount - 1
                End If
                CMDSELECTPLATE.Enabled = False
                TOTAL()
            Else
                EDIT = False
                CLEAR()
                TXTDESTROYEDBY.Focus()
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

            ALPARAVAL.Add(DTDESTROYEDATE.Value.Date)
            ALPARAVAL.Add(TXTDESTROYEDBY.Text.Trim)
            ALPARAVAL.Add(TXTAPPROVEDBY.Text.Trim)
            ALPARAVAL.Add(CMBGODOWN.Text.Trim)
            ALPARAVAL.Add(lbltotalqty.Text.Trim)
            ALPARAVAL.Add(txtremarks.Text.Trim)
            ALPARAVAL.Add(TXTCHALLANNO.Text.Trim)


            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            '' GRID PARAMETERS
            Dim GRIDSRNO As String = ""
            Dim GRIDPLATENO As String = ""
            Dim GRIDQTY As String = ""
            Dim GRIDUNIT As String = ""
            Dim GRIDRATE As String = ""
            Dim GRIDAMOUNT As String = ""

            For Each ROW As Windows.Forms.DataGridViewRow In GRIDPLATE.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = ROW.Cells(gsrno.Index).Value
                        GRIDPLATENO = ROW.Cells(GPLATENO.Index).Value.ToString
                        GRIDQTY = Val(ROW.Cells(gQty.Index).Value)
                        GRIDUNIT = ROW.Cells(GUNIT.Index).Value.ToString
                        GRIDRATE = Val(ROW.Cells(GRATE.Index).Value)
                        GRIDAMOUNT = Val(ROW.Cells(GAMOUNT.Index).Value)
                    Else
                        GRIDSRNO = GRIDSRNO & "|" & ROW.Cells(gsrno.Index).Value
                        GRIDPLATENO = GRIDPLATENO & "|" & ROW.Cells(GPLATENO.Index).Value.ToString
                        GRIDQTY = GRIDQTY & "|" & Val(ROW.Cells(gQty.Index).Value)
                        GRIDUNIT = GRIDUNIT & "|" & ROW.Cells(GUNIT.Index).Value.ToString
                        GRIDRATE = GRIDRATE & "|" & Val(ROW.Cells(GRATE.Index).Value)
                        GRIDAMOUNT = GRIDAMOUNT & "|" & Val(ROW.Cells(GAMOUNT.Index).Value)
                    End If
                End If
            Next
            ALPARAVAL.Add(GRIDSRNO)
            ALPARAVAL.Add(GRIDPLATENO)
            ALPARAVAL.Add(GRIDQTY)
            ALPARAVAL.Add(GRIDUNIT)
            ALPARAVAL.Add(GRIDRATE)
            ALPARAVAL.Add(GRIDAMOUNT)

            Dim OBJISSUE As New ClsPlateDestroyed
            OBJISSUE.alParaval = ALPARAVAL

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTT As DataTable = OBJISSUE.save()
                TEMPDESTROYENO = DTT.Rows(0).Item(0)
                MsgBox("Deatils Added !!")
                'PRINTREPORT(TEMPISSUENO)

            Else

                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                ALPARAVAL.Add(TEMPDESTROYENO)
                IntResult = OBJISSUE.update()
                MsgBox("Details Updated")
                'PRINTREPORT(TEMPBILLNO)
                EDIT = False

            End If
            CLEAR()
            TXTDESTROYEDBY.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub TOTAL()
        lbltotalqty.Text = "0.00"
        For Each row As DataGridViewRow In GRIDPLATE.Rows
            If Val(row.Cells(gQty.Index).Value) <> 0 Then
                lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(row.Cells(gQty.Index).EditedFormattedValue), "0.00")
                row.Cells(GAMOUNT.Index).Value = Format(row.Cells(gQty.Index).EditedFormattedValue * Val(row.Cells(GRATE.Index).EditedFormattedValue), "0.00")
            End If
        Next
    End Sub

    Private Function ERRORVALID() As Boolean
        Dim BLN As Boolean = True

        If TXTDESTROYEDBY.Text.Trim = "" Then
            Ep.SetError(TXTDESTROYEDBY, "Please Enter Name")
            BLN = False
        End If

        If TXTAPPROVEDBY.Text.Trim = "" Then
            Ep.SetError(TXTAPPROVEDBY, "Please Enter Name")
            BLN = False
        End If

        If CMBGODOWN.Text.Trim = "" Then
            Ep.SetError(CMBGODOWN, "Please Enter Godown Name")
            BLN = False
        End If

        If GRIDPLATE.RowCount = 0 Then
            Ep.SetError(TXTDESTROYEDBY, "Enter Plate Details")
            BLN = False
        End If

        For Each row As DataGridViewRow In GRIDPLATE.Rows
            If Val(row.Cells(gQty.Index).Value) <= 0 Then
                Ep.SetError(lbltotalqty, "Quantity cannot be 0 or less")
                BLN = False
            End If
        Next

        If GRIDPLATE.RowCount > 0 And EDIT = False Then
            For Each ROW As DataGridViewRow In GRIDPLATE.Rows
                Dim OBJCMN As New ClsCommonMaster
                Dim DT As DataTable = OBJCMN.search("SUM(QTY)AS QTY", "", "STOCKVIEW", "AND GODOWN='" & CMBGODOWN.Text.Trim & "' AND ITEMNAME = '" & ROW.Cells(GPLATENO.Index).Value & "' AND UNIT = '" & ROW.Cells(GUNIT.Index).Value & "' AND YEARID = " & YearId & " AND CMPID = " & CmpId)
                If DT.Rows.Count <= 0 Then GoTo LINE1
                If Val(ROW.Cells(gQty.Index).Value) > Val(DT.Rows(0).Item(0)) Then
LINE1:
                    Ep.SetError(lbltotalqty, "Stock Not Present ! ")
                    GRIDPLATE.CurrentRow.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                    BLN = False
                End If
            Next
        End If


        If GRIDPLATE.RowCount > 0 And EDIT = True Then
            For Each ROW As DataGridViewRow In GRIDPLATE.Rows
                Dim BALQTY As Double = 0
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search("SUM(QTY)AS QTY", "", "STOCKVIEW", "AND GODOWN='" & CMBGODOWN.Text.Trim & "' AND ITEMNAME = '" & ROW.Cells(GPLATENO.Index).Value & "'AND UNIT = '" & ROW.Cells(GUNIT.Index).Value & "' AND YEARID = " & YearId & " AND CMPID = " & CmpId)
                If dt.Rows.Count > 0 Then BALQTY = Format(Val(dt.Rows(0).Item(0)), "0.00")

                dt = objclscommon.search(" ISNULL(DESTROYE_QTY,0) AS QTY ", "", "    PLATEDESTROYED_DESC INNER JOIN NONINVITEMMASTER ON PLATEDESTROYED_DESC.DESTROYE_NONINVID = NONINVITEMMASTER.NONINV_ID AND PLATEDESTROYED_DESC.DESTROYE_yearid = NONINVITEMMASTER.NONINV_YEARID LEFT OUTER JOIN UNITMASTER ON PLATEDESTROYED_DESC.DESTROYE_UNITID = UNITMASTER.unit_id", " AND PLATEDESTROYED_DESC.DESTROYE_NO = " & TEMPDESTROYENO & " and NONINV_NAME = '" & ROW.Cells(GPLATENO.Index).Value & "' AND UNIT_ABBR = '" & ROW.Cells(GUNIT.Index).Value & "'  AND PLATEDESTROYED_DESC.DESTROYE_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then BALQTY = BALQTY + Val(dt.Rows(0).Item(0))

                If Val(ROW.Cells(gQty.Index).Value) > BALQTY Then
                    Ep.SetError(lbltotalqty, "Stock Not Present! " & BALQTY)
                    GRIDPLATE.CurrentRow.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                    BLN = False
                End If
                BALQTY = 0
            Next
        End If


        If Not datecheck(DTDESTROYEDATE.Value) Then BLN = False

        Return BLN
    End Function

    Private Sub CMBGODOWN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
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
                Dim TEMPMSG As Integer = MsgBox("Delete Destroyed Item?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    Dim ALPARAVAL As New ArrayList
                    Dim OBJISSUE As New ClsPlateDestroyed

                    ALPARAVAL.Add(TEMPDESTROYENO)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)

                    OBJISSUE.alParaval = ALPARAVAL
                    Dim IntResult As Integer = OBJISSUE.delete()
                    MsgBox("Destroyed Item Deleted")
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

            Dim OBJPLATEDEST As New PlateDestroyedDetails
            OBJPLATEDEST.MdiParent = MDIMain
            OBJPLATEDEST.Show()
            OBJPLATEDEST.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            GRIDPLATE.RowCount = 0
LINE1:
            TEMPDESTROYENO = Val(TXTDESTROYEDNO.Text) - 1
            If TEMPDESTROYENO > 0 Then
                EDIT = True
                PlateDestroyed_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDPLATE.RowCount = 0 And TEMPDESTROYENO > 1 Then
                TXTDESTROYEDNO.Text = TEMPDESTROYENO
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
            TEMPDESTROYENO = Val(TXTDESTROYEDNO.Text) + 1
            GETMAX_DESTROYED_NO()
            Dim MAXNO As Integer = TXTDESTROYEDNO.Text.Trim
            CLEAR()
            If Val(TXTDESTROYEDNO.Text) - 1 >= TEMPDESTROYENO Then
                EDIT = True
                PlateDestroyed_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDPLATE.RowCount = 0 And TEMPDESTROYENO < MAXNO Then
                TXTDESTROYEDNO.Text = TEMPDESTROYENO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub DTDESTROYEDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DTDESTROYEDATE.Validating
        If Not datecheck(DTDESTROYEDATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub tstxtbillno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstxtbillno.Validated
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDPLATE.RowCount = 0
            TEMPDESTROYENO = Val(tstxtbillno.Text)
            If TEMPDESTROYENO > 0 Then
                EDIT = True
                PlateDestroyed_Load(sender, e)
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

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(gsrno.Index).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTBATCH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTPLATE.Click
        'Try
        '    If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
        '        MsgBox("Insufficient Rights")
        '        Exit Sub
        '    End If

        '    Dim OBJSELECTPLATE As New SelectStock
        '    Dim DTPR As DataTable = OBJSELECTPLATE.DT
        '    OBJSELECTPLATE.ShowDialog()

        '    Dim i As Integer = 0
        '    If DTPR.Rows.Count > 0 Then
        '        Dim OBJCMN As New ClsCommon

        '        For Each DTROW As DataRow In DTPR.Rows

        '            Dim DT As DataTable = OBJCMN.search(" ISNULL(PLATEISSUE.ISSUE_NO, 0) AS PLATENO, ISNULL(PLATEISSUE_DESC.ISSUE_GRIDSRNO, 0) AS SRNO, ISNULL(PLATEISSUE.ISSUE_BATCHNO, 0)  AS BATCHNO, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, PLATEISSUE.ISSUE_DATE AS DATE, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(DEPARTMENTMASTER.DEPARTMENT_name, '') AS DEPARTMENT, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS NONINVITEM, ISNULL(PLATEISSUE_DESC.ISSUE_QTY, 0) AS QTY,ISNULL(UNITMASTER.unit_abbr, '')  AS UNIT", "", "    PLATEISSUE INNER JOIN PLATEISSUE_DESC ON PLATEISSUE.ISSUE_NO = PLATEISSUE_DESC.ISSUE_no AND PLATEISSUE.ISSUE_yearid = PLATEISSUE_DESC.ISSUE_yearid INNER JOIN DEPARTMENTMASTER ON PLATEISSUE.ISSUE_DEPARTMENTID = DEPARTMENTMASTER.DEPARTMENT_id AND PLATEISSUE.ISSUE_yearid = DEPARTMENTMASTER.DEPARTMENT_yearid INNER JOIN  GODOWNMASTER ON PLATEISSUE.ISSUE_GODOWNID = GODOWNMASTER.GODOWN_id AND PLATEISSUE.ISSUE_yearid = GODOWNMASTER.GODOWN_yearid INNER JOIN NONINVITEMMASTER ON PLATEISSUE_DESC.ISSUE_NONINVID = NONINVITEMMASTER.NONINV_ID AND  PLATEISSUE_DESC.ISSUE_yearid = NONINVITEMMASTER.NONINV_YEARID INNER JOIN ITEMMASTER ON PLATEISSUE.ISSUE_ITEMID = ITEMMASTER.item_id AND PLATEISSUE.ISSUE_yearid = ITEMMASTER.item_yearid INNER JOIN UNITMASTER ON PLATEISSUE_DESC.ISSUE_UNITID = UNITMASTER.unit_id", " AND PLATEISSUE.ISSUE_NO = " & Val(DTROW(0)) & " AND PLATEISSUE_DESC.ISSUE_GRIDSRNO = " & Val(DTROW(1)) & " AND PLATEISSUE.ISSUE_yearid = " & YearId)
        '            If DT.Rows.Count > 0 Then

        '                'CMBGODOWN.Enabled = False
        '                CMBGODOWN.Text = DT.Rows(0).Item("GODOWN").ToString

        '                'ITEM GRID
        '                For Each ROW As DataRow In DT.Rows
        '                    GRIDPLATE.Rows.Add(0, ROW("NONINVITEM"), Format(Val(ROW("QTY")), "0.00"), 0, Val(ROW("PLATENO")), Val(ROW("SRNO")), ROW("UNIT"))
        '                Next
        '                TOTAL()
        '                getsrno(GRIDPLATE)
        '                CMDSELECTPLATE.Enabled = False
        '                'TXTRETURNNO.Focus()
        '            End If
        '        Next
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try

        Try
            If CMBGODOWN.Text.Trim = "" And GRIDPLATE.RowCount = 0 Then
                MsgBox("Please Select Godown First", MsgBoxStyle.Critical)
                CMBGODOWN.Focus()
                Exit Sub
            End If

            Dim DTTABLE As New DataTable
            Dim OBJSELECTGDN As New SelectStock
            OBJSELECTGDN.GODOWN = CMBGODOWN.Text.Trim
            OBJSELECTGDN.ShowDialog()
            DTTABLE = OBJSELECTGDN.DT

            If DTTABLE.Rows.Count > 0 Then
                TXTCHALLANNO.Text = DTTABLE.Rows(0).Item("CHALLANNO").ToString
                For Each dr As DataRow In DTTABLE.Rows
                    GRIDPLATE.Rows.Add(0, dr("ITEMNAME"), dr("QTY"), dr("UNIT"), dr("RATE"), 0)
                Next
                GRIDPLATE.FirstDisplayedScrollingRowIndex = GRIDPLATE.RowCount - 1
                getsrno(GRIDPLATE)
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class