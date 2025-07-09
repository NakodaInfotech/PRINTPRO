
Imports BL
Imports System.Windows.Forms

Public Class PlateIssue

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim tempRow As Integer
    Public EDIT As Boolean
    Public TEMPISSUENO As String
    Public tempMsg As Integer

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Try
            CLEAR()
            EDIT = False
            TXTISSUEDBY.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()

        TXTISSUEDBY.Clear()
        TXTISSUEDTO.Clear()
        TXTBATCHNO.Clear()
        CMBGODOWN.Text = ""
        CMBDEPARTMENT.Text = ""
        TXTITEMCODE.Clear()
        TXTITEMNAME.Clear()
        TXTREMARKS.Clear()
        TXTJOBDOCKET.Clear()


        DTISSUEDATE.Value = Mydate
        GRIDPLATE.RowCount = 0
        lbltotalqty.Text = "0.00"
        Ep.Clear()
        CMDSELECTBATCH.Enabled = True
        CMDSELECTPLATE.Enabled = True
        lbllocked.Visible = False
        PBlock.Visible = False

        GETMAX_ISSUE_NO()
        tstxtbillno.Clear()
        TXTCHALLANNO.Clear()


    End Sub

    Sub GETMAX_ISSUE_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" ISNULL(MAX(ISSUE_NO),0) + 1 ", "PLATEISSUE", " AND ISSUE_YEARID=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTISSUENO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Sub FILLCMB()
        If CMBDEPARTMENT.Text.Trim = "" Then FILLDEPARTMNET(CMBDEPARTMENT, EDIT)
        If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
    End Sub

    Private Sub PlateIssue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                Dim OBJPLATEISSUE As New ClsPLATEISSUE

                ALPARAVAL.Add(TEMPISSUENO)
                ALPARAVAL.Add(CmpId)
                ' ALPARAVAL.Add(Userid)
                ALPARAVAL.Add(YearId)

                OBJPLATEISSUE.alParaval = ALPARAVAL
                Dim dt As DataTable = OBJPLATEISSUE.SELECTPLATEISSUE()

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTISSUENO.Text = TEMPISSUENO
                        DTISSUEDATE.Value = Convert.ToDateTime(dr("DATE"))
                        TXTISSUEDBY.Text = Convert.ToString(dr("ISSUEBY"))
                        TXTISSUEDTO.Text = Convert.ToString(dr("ISSUETO"))
                        TXTBATCHNO.Text = Convert.ToString(dr("BATCHNO"))
                        TXTJOBDOCKET.Text = Convert.ToString(dr("JOBDOCKETNO"))
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN"))
                        CMBDEPARTMENT.Text = Convert.ToString(dr("DEPT"))
                        TXTITEMCODE.Text = Convert.ToString(dr("ITEMCODE"))
                        TXTITEMNAME.Text = Convert.ToString(dr("ITEMNAME"))
                        lbltotalqty.Text = Format(Val(dr("TOTALQTY")), "0.00")
                        TXTREMARKS.Text = Convert.ToString(dr("REMARKS"))
                        TXTCHALLANNO.Text = Convert.ToString(dr("CHALLANNO"))


                        GRIDPLATE.Rows.Add(Val(dr("SRNO")), dr("PLATENO").ToString, Format(Val(dr("QTY").ToString), "0.00"), dr("UNIT"), Format(Val(dr("OUTQTY").ToString), "0.00"), Format(Val(dr("RATE")), "0.00"), Format(Val(dr("AMOUNT")), "0.00"))
                        If (dr("OUTQTY")) > 0 Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                            GRIDPLATE.Rows(GRIDPLATE.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                        End If

                    Next
                    GRIDPLATE.FirstDisplayedScrollingRowIndex = GRIDPLATE.RowCount - 1
                    TOTAL()

                End If
                CMDSELECTBATCH.Enabled = False
                CMDSELECTPLATE.Enabled = False
            Else
                EDIT = False
                CLEAR()
                TXTISSUEDBY.Focus()
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

            ALPARAVAL.Add(DTISSUEDATE.Value.Date)
            ALPARAVAL.Add(TXTISSUEDBY.Text.Trim)
            ALPARAVAL.Add(CMBDEPARTMENT.Text.Trim)
            ALPARAVAL.Add(TXTISSUEDTO.Text.Trim)
            ALPARAVAL.Add(TXTBATCHNO.Text.Trim)
            ALPARAVAL.Add(TXTJOBDOCKET.Text.Trim)
            ALPARAVAL.Add(CMBGODOWN.Text.Trim)
            ALPARAVAL.Add(TXTITEMNAME.Text.Trim)
            ALPARAVAL.Add(lbltotalqty.Text.Trim)
            ALPARAVAL.Add(TXTREMARKS.Text.Trim)
            ALPARAVAL.Add(TXTCHALLANNO.Text.Trim)


            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            '' GRID PARAMETERS
            Dim GRIDSRNO As String = ""
            Dim GRIDPLATENO As String = ""
            Dim GRIDQTY As String = ""
            Dim GRIDOUTQTY As String = ""
            Dim UNIT As String = ""
            Dim RATE As String = ""
            Dim AMOUNT As String = ""

            For Each ROW As Windows.Forms.DataGridViewRow In GRIDPLATE.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = ROW.Cells(gsrno.Index).Value
                        GRIDPLATENO = ROW.Cells(GPLATENO.Index).Value.ToString
                        GRIDQTY = Val(ROW.Cells(gQty.Index).Value)
                        GRIDOUTQTY = Val(ROW.Cells(GOUTQTY.Index).Value)
                        UNIT = ROW.Cells(gunit.Index).Value.ToString
                        RATE = Val(ROW.Cells(GRATE.Index).Value)
                        AMOUNT = Val(ROW.Cells(GAMOUNT.Index).Value)
                    Else
                        GRIDSRNO = GRIDSRNO & "|" & ROW.Cells(gsrno.Index).Value
                        GRIDPLATENO = GRIDPLATENO & "|" & ROW.Cells(GPLATENO.Index).Value.ToString
                        GRIDQTY = GRIDQTY & "|" & Val(ROW.Cells(gQty.Index).Value)
                        GRIDOUTQTY = GRIDOUTQTY & "|" & Val(ROW.Cells(GOUTQTY.Index).Value)
                        UNIT = UNIT & "|" & ROW.Cells(gunit.Index).Value.ToString
                        RATE = RATE & "|" & Val(ROW.Cells(GRATE.Index).Value)
                        AMOUNT = AMOUNT & "|" & Val(ROW.Cells(GAMOUNT.Index).Value)
                    End If
                End If
            Next
            ALPARAVAL.Add(GRIDSRNO)
            ALPARAVAL.Add(GRIDPLATENO)
            ALPARAVAL.Add(GRIDQTY)
            ALPARAVAL.Add(GRIDOUTQTY)
            ALPARAVAL.Add(UNIT)
            ALPARAVAL.Add(RATE)
            ALPARAVAL.Add(AMOUNT)

            Dim OBJISSUE As New ClsPLATEISSUE
            OBJISSUE.alParaval = ALPARAVAL

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTT As DataTable = OBJISSUE.save()
                TEMPISSUENO = DTT.Rows(0).Item(0)
                MsgBox("Deatils Added !!")
                'PRINTREPORT(TEMPISSUENO)

            Else

                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                ALPARAVAL.Add(TEMPISSUENO)
                IntResult = OBJISSUE.UPDATE()
                MsgBox("Details Updated")
                'PRINTREPORT(TEMPBILLNO)
                EDIT = False

            End If
            CLEAR()
            TXTISSUEDBY.Focus()

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
        lbltotalqty.Text = "0.00"
        For Each row As DataGridViewRow In GRIDPLATE.Rows
            If Val(row.Cells(gQty.Index).Value) <> 0 Then
                lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(row.Cells(gQty.Index).EditedFormattedValue), "0.00")
                row.Cells(GAMOUNT.Index).Value = Format(row.Cells(gQty.Index).EditedFormattedValue * Val(row.Cells(GRATE.Index).EditedFormattedValue), "0.00")
            End If
        Next
    End Sub

    Private Sub PlateIssue_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                If errorvalid() = True Then
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

    Private Function ERRORVALID() As Boolean
        Dim BLN As Boolean = True

        If TXTISSUEDBY.Text.Trim = "" Then
            Ep.SetError(TXTISSUEDBY, "Please Enter Name")
            BLN = False
        End If

        If TXTISSUEDTO.Text.Trim = "" Then
            Ep.SetError(TXTISSUEDTO, "Please Enter Name")
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
            Ep.SetError(TXTISSUEDBY, "Enter Plate/Batch Details")
            BLN = False
        End If

        If TXTBATCHNO.Text.Trim = "" Then
            Ep.SetError(TXTBATCHNO, "Select Batch")
            BLN = False
        End If


        If PBlock.Visible = True Then
            Ep.SetError(PBlock, "Issue Lock !!   First Delete Plate Return")
            BLN = False
        End If


        For Each row As DataGridViewRow In GRIDPLATE.Rows
            If Val(row.Cells(gQty.Index).Value) <= 0 Then
                Ep.SetError(lbltotalqty, "Quantity cannot be 0 or less")
                BLN = False
            End If
        Next



        If Not datecheck(DTISSUEDATE.Value) Then BLN = False


        'in PLATE stock (edit  = false )
        If GRIDPLATE.RowCount > 0 And EDIT = False Then
            For Each ROW As DataGridViewRow In GRIDPLATE.Rows
                Dim OBJCMN As New ClsCommonMaster
                Dim DT As DataTable = OBJCMN.search("SUM(QTY)AS QTY", "", "STOCKVIEW", "AND GODOWN='" & CMBGODOWN.Text.Trim & "' AND ITEMNAME = '" & ROW.Cells(GPLATENO.Index).Value & "' AND UNIT = '" & ROW.Cells(gunit.Index).Value & "' AND YEARID = " & YearId & " AND CMPID = " & CmpId)
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
                Dim dt As DataTable = objclscommon.search("SUM(QTY)AS QTY", "", "STOCKVIEW", "AND GODOWN='" & CMBGODOWN.Text.Trim & "' AND ITEMNAME = '" & ROW.Cells(GPLATENO.Index).Value & "'AND UNIT = '" & ROW.Cells(gunit.Index).Value & "' AND YEARID = " & YearId & " AND CMPID = " & CmpId)
                If dt.Rows.Count > 0 Then BALQTY = Format(Val(dt.Rows(0).Item(0)), "0.00")

                dt = objclscommon.search(" ISNULL(ISSUE_QTY,0) AS QTY ", "", "  PLATEISSUE_DESC INNER JOIN NONINVITEMMASTER ON PLATEISSUE_DESC.ISSUE_NONINVID = NONINVITEMMASTER.NONINV_ID INNER JOIN UNITMASTER ON PLATEISSUE_DESC.ISSUE_UNITID = UNITMASTER.unit_id", " AND PLATEISSUE_DESC.ISSUE_NO = " & TEMPISSUENO & " and NONINV_NAME = '" & ROW.Cells(GPLATENO.Index).Value & "' AND UNIT_ABBR = '" & ROW.Cells(gunit.Index).Value & "'  AND PLATEISSUE_DESC.ISSUE_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then BALQTY = BALQTY + Val(dt.Rows(0).Item(0))

                If Val(ROW.Cells(gQty.Index).Value) > BALQTY Then
                    Ep.SetError(lbltotalqty, "Stock Not Present! " & BALQTY)
                    GRIDPLATE.CurrentRow.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                    BLN = False
                End If
                BALQTY = 0
            Next
        End If


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
                Dim TEMPMSG As Integer = MsgBox("Delete Isuued Item?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    Dim ALPARAVAL As New ArrayList
                    Dim OBJISSUE As New ClsPLATEISSUE

                    ALPARAVAL.Add(TEMPISSUENO)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)

                    OBJISSUE.alParaval = ALPARAVAL
                    Dim IntResult As Integer = OBJISSUE.Delete()
                    MsgBox("Isuued Item Deleted")
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

            Dim OBJPLATEISSUE As New PlateIssueDetails
            OBJPLATEISSUE.MdiParent = MDIMain
            OBJPLATEISSUE.Show()
            OBJPLATEISSUE.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try

LINE1:
            TEMPISSUENO = Val(TXTISSUENO.Text) - 1
Line2:
            If TEMPISSUENO > 0 Then

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISSUE_NO ", "", " PLATEISSUE", " AND ISSUE_NO = '" & TEMPISSUENO & "' AND ISSUE_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    EDIT = True
                    PlateIssue_Load(sender, e)
                Else
                    TEMPISSUENO = Val(TEMPISSUENO - 1)
                    GoTo Line2
                End If
            Else
                CLEAR()
                EDIT = False
            End If

            If GRIDPLATE.RowCount = 0 And TEMPISSUENO > 1 Then
                TXTISSUENO.Text = TEMPISSUENO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub DTISSUEDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DTISSUEDATE.Validating
        If Not datecheck(DTISSUEDATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            GRIDPLATE.RowCount = 0
LINE1:
            TEMPISSUENO = Val(TXTISSUENO.Text) + 1
            GETMAX_ISSUE_NO()
            Dim MAXNO As Integer = TXTISSUENO.Text.Trim
            CLEAR()
            If Val(TXTISSUENO.Text) - 1 >= TEMPISSUENO Then
                EDIT = True
                PlateIssue_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDPLATE.RowCount = 0 And TEMPISSUENO < MAXNO Then
                TXTISSUENO.Text = TEMPISSUENO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstxtbillno.Validated
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            GRIDPLATE.RowCount = 0
            TEMPISSUENO = Val(tstxtbillno.Text)
            If TEMPISSUENO > 0 Then
                EDIT = True
                PlateIssue_Load(sender, e)
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
            ' If ClientName = "IYMP" Then
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
            ' End If
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
            Cursor.Current = Cursors.WaitCursor
            Dim OBJSELECTBACTH As New SelectBatch
            OBJSELECTBACTH.TYPE = "PLATEISSUE"
            OBJSELECTBACTH.ShowDialog()

            Dim ORDERDT As DataTable = OBJSELECTBACTH.DT
            If ORDERDT.Rows.Count > 0 Then

                TXTJOBDOCKET.Text = ORDERDT.Rows(0).Item("JOBBATCHNO")
                TXTBATCHNO.Text = ORDERDT.Rows(0).Item("BATCHNO")
                TXTITEMCODE.Text = ORDERDT.Rows(0).Item("ITEMCODE")
                TXTITEMNAME.Text = ORDERDT.Rows(0).Item("ITEMNAME")

                'Dim objcmn As New ClsCommon

                'For Each ROW As DataRow In ORDERDT.Rows
                '    Dim dt As DataTable = objcmn.search("BATCHMASTER.jobbatch_no AS BATCHNO, ISNULL(BATCHMASTER.jobbatch_docketno, 0) AS JOBDOCKETNO, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME", "", "BATCHMASTER INNER JOIN ITEMMASTER ON BATCHMASTER.jobbatch_yearid = ITEMMASTER.item_yearid AND BATCHMASTER.jobbatch_itemid = ITEMMASTER.item_id", " AND BATCHMASTER.jobbatch_docketno = " & Val(ROW(0)) & " AND BATCHMASTER.jobbatch_no = " & Val(ROW(1)) & " AND BATCHMASTER.JOBBATCH_YEARID = " & YearId)
                '    If dt.Rows.Count > 0 Then


                '    End If
                'Next
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CMDSELECTPLATE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTPLATE.Click
        Try
            If CMBGODOWN.Text.Trim = "" And GRIDPLATE.RowCount = 0 Then
                MsgBox("Please Select Godown First", MsgBoxStyle.Critical)
                CMBGODOWN.Focus()
                Exit Sub
            End If

            If Val(TXTBATCHNO.Text.Trim) = 0 And TXTITEMCODE.Text.Trim = "" Then
                MsgBox("Please Select Batch first", MsgBoxStyle.Critical)
                CMBGODOWN.Focus()
                Exit Sub
            End If

            Dim DTTABLE As New DataTable
            Dim OBJSELECTGDN As New SelectStock
            OBJSELECTGDN.GODOWN = CMBGODOWN.Text.Trim
            OBJSELECTGDN.ITEMCODE = TXTITEMCODE.Text.Trim
            OBJSELECTGDN.ShowDialog()
            DTTABLE = OBJSELECTGDN.DT

            If DTTABLE.Rows.Count > 0 Then
                TXTCHALLANNO.Text = DTTABLE.Rows(0).Item("CHALLANNO").ToString

                For Each dr As DataRow In DTTABLE.Rows
                    GRIDPLATE.Rows.Add(0, dr("ITEMNAME"), dr("QTY"), dr("UNIT"), 0, Format(Val(dr("RATE")), "0.00"))
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