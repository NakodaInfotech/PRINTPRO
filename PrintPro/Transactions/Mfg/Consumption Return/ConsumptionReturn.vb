
Imports BL
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class ConsumptionReturn
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim tempRow As Integer
    Public edit As Boolean
    Public TEMPCONSUMENO As String
    Public tempMsg As Integer

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        CLEAR()
        edit = False
    End Sub

    Sub CLEAR()
        TXTMATERIALRETURNBY.Clear()
        TXTMATERIALGIVENTO.Clear()
        'CMBDEPARTMENT.Text = ""
        TXTCONUSMENO.Clear()
        TXTDEPARTMENT.Clear()
        CMBGODOWN.Text = ""
        tstxtbillno.Clear()
        CONSUMERETDATE.Value = Mydate

        gridCONSUME.RowCount = 0
        cmbitemname.Text = ""
        cmbshelf.Text = ""
        cmbunit.Text = ""
        TXTSIZE.Clear()
        TXTBATCHNO.Clear()
        TXTQTY.Clear()
        TXTWT.Clear()
        lbltotalqty.Text = 0.0

        lbllocked.Visible = False
        PBlock.Visible = False
        gridDoubleClick = False
        CMDSELECTCONSUMPTION.Enabled = True
        CMBGODOWN.Enabled = True
        Ep.Clear()
        txtremarks.Clear()
        TXTCHALLANNO.Clear()
        CMBMACHINE.Text = ""



        CONSUMERETDATE.Value = Mydate

        If gridCONSUME.RowCount > 0 Then
            TXTITEMSRNO.Text = Val(gridCONSUME.Rows(gridCONSUME.RowCount - 1).Cells(gsrno.Index).Value) + 1
        Else
            TXTITEMSRNO.Text = 1
        End If
        GETMAX_CONSUMERETURN_NO()
    End Sub

    Sub GETMAX_CONSUMERETURN_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(CONSUMERET_no),0) + 1 ", "CONSUMPTIONRETURN", " AND CONSUMERET_YEARID=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTCONSUMERETURNNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Sub FILLCMB()
        If cmbitemname.Text.Trim = "" Then FILLNONINVITEM(cmbitemname, edit)
        'If CMBDEPARTMENT.Text.Trim = "" Then FILLDEPARTMNET(CMBDEPARTMENT, edit)
        If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
        If cmbshelf.Text.Trim = "" Then fillSHELF(cmbshelf, edit)
        If cmbunit.Text.Trim = "" Then fillUNIT(cmbunit)
        If CMBMACHINE.Text.Trim = "" Then FILLMACHINE(CMBMACHINE)

    End Sub

    Private Sub Consumption_Return_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim ALPARAVAL As New ArrayList
                Dim objclsCONSUME As New ClsConsumptionReturn

                ALPARAVAL.Add(TEMPCONSUMENO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                objclsCONSUME.alParaval = ALPARAVAL
                Dim dt As DataTable = objclsCONSUME.selectconsume()

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTCONSUMERETURNNO.Text = TEMPCONSUMENO
                        CONSUMERETDATE.Value = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        TXTCONUSMENO.Text = Convert.ToString(dr("CONSUMENO"))
                        TXTMATERIALRETURNBY.Text = Convert.ToString(dr("MATERIALBY"))
                        TXTMATERIALGIVENTO.Text = Convert.ToString(dr("MATERIALTO"))
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN"))
                        TXTDEPARTMENT.Text = Convert.ToString(dr("DEPARTMENT"))
                        lbltotalqty.Text = Format(Val(dr("TOTALQTY")), "0.00")
                        txtremarks.Text = Convert.ToString(dr("remarks"))
                        CMBMACHINE.Text = Convert.ToString(dr("MACHINE"))
                        TXTCHALLANNO.Text = Convert.ToString(dr("CHALLANNO"))

                        'gridCONSUME.Rows.Add(Val(dr("SRNO")), dr("ITEMNAME").ToString, dr("SHELF").ToString, dr("SIZE").ToString, Format(Val(dr("WT").ToString), "0.00"), dr("BATCHNO").ToString, dr("UNIT").ToString, Format(Val(dr("QTY").ToString), "0.00"), Val(dr("CONSUMENO")), Val(dr("CONSUMESRNO")))
                        gridCONSUME.Rows.Add(Val(dr("SRNO")), dr("ITEMNAME").ToString, dr("LOTNO").ToString, dr("UNIT").ToString, Format(Val(dr("QTY").ToString), "0.00"), Format(Val(dr("WT").ToString), "0.00"), Val(dr("CONSUMENO")), Val(dr("CONSUMESRNO")), 0, Format(Val(dr("RATE").ToString), "0.00"), Format(Val(dr("AMOUNT").ToString), "0.00"))

                    Next
                    gridCONSUME.FirstDisplayedScrollingRowIndex = gridCONSUME.RowCount - 1
                End If
                CMDSELECTCONSUMPTION.Enabled = False
                TOTAL()
            End If

            'If gridDoubleClick = False Then
            If gridCONSUME.RowCount > 0 Then
                TXTITEMSRNO.Text = Val(gridCONSUME.Rows(gridCONSUME.RowCount - 1).Cells(gsrno.Index).Value) + 1
            Else
                TXTITEMSRNO.Text = 1
            End If
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then FILLNONINVITEM(cmbitemname, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub CMBDEPARTMENT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        If CMBDEPARTMENT.Text.Trim = "" Then FILLDEPARTMNET(CMBDEPARTMENT, edit)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub cmbshelf_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbshelf.Enter
        Try
            If cmbshelf.Text.Trim = "" Then fillSHELF(cmbshelf, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbunit_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbunit.Enter
        Try
            If cmbunit.Text.Trim = "" Then fillUNIT(cmbunit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then NONINVITEMVALIDATE(cmbitemname, e, Me)
        Catch ex As Exception
            Throw ex
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

            ALPARAVAL.Add(CONSUMERETDATE.Value)
            ALPARAVAL.Add(TXTCONUSMENO.Text.Trim)
            ALPARAVAL.Add(TXTMATERIALRETURNBY.Text.Trim)
            ALPARAVAL.Add(TXTMATERIALGIVENTO.Text.Trim)
            ALPARAVAL.Add(CMBGODOWN.Text.Trim)
            ALPARAVAL.Add(TXTDEPARTMENT.Text.Trim)
            ALPARAVAL.Add(lbltotalqty.Text.Trim)
            ALPARAVAL.Add(txtremarks.Text.Trim)
            ALPARAVAL.Add(CMBMACHINE.Text.Trim)
            ALPARAVAL.Add(TXTCHALLANNO.Text.Trim)

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)
            ALPARAVAL.Add(0)


            '' GRID PARAMETERS
            Dim SRNO As String = ""
            Dim ITEM As String = ""
            'Dim SHELF As String = ""
            'Dim SIZE As String = ""
            Dim LOTNO As String = ""
            Dim UNIT As String = ""
            Dim QTY As String = ""
            Dim WT As String = ""
            Dim CONSUMENO As String = ""
            Dim CONSUMESRNO As String = ""
            Dim RATE As String = ""
            Dim AMOUNT As String = ""



            For Each ROW As Windows.Forms.DataGridViewRow In gridCONSUME.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If SRNO = "" Then
                        SRNO = ROW.Cells(gsrno.Index).Value
                        ITEM = ROW.Cells(gitemname.Index).Value.ToString
                        'SHELF = ROW.Cells(gshelf.Index).Value.ToString
                        'SIZE = ROW.Cells(GSize.Index).Value.ToString
                        LOTNO = ROW.Cells(GLOTNO.Index).Value.ToString
                        UNIT = ROW.Cells(gunit.Index).Value.ToString
                        QTY = Val(ROW.Cells(gQty.Index).Value)
                        WT = Val(ROW.Cells(GWT.Index).Value)
                        CONSUMENO = Val(ROW.Cells(GCONSUMENO.Index).Value)
                        CONSUMESRNO = Val(ROW.Cells(GCONSUMESRNO.Index).Value)
                        RATE = Val(ROW.Cells(GRATE.Index).Value)
                        AMOUNT = Val(ROW.Cells(GAMOUNT.Index).Value)

                    Else
                        SRNO = SRNO & "|" & ROW.Cells(gsrno.Index).Value
                        ITEM = ITEM & "|" & ROW.Cells(gitemname.Index).Value.ToString
                        'SHELF = SHELF & "|" & ROW.Cells(gshelf.Index).Value.ToString
                        'SIZE = SIZE & "|" & ROW.Cells(GSize.Index).Value.ToString
                        LOTNO = LOTNO & "|" & ROW.Cells(GLOTNO.Index).Value.ToString
                        UNIT = UNIT & "|" & ROW.Cells(gunit.Index).Value.ToString
                        QTY = QTY & "|" & Val(ROW.Cells(gQty.Index).Value)
                        WT = WT & "|" & Val(ROW.Cells(GWT.Index).Value)
                        CONSUMENO = CONSUMENO & "|" & Val(ROW.Cells(GCONSUMENO.Index).Value)
                        CONSUMESRNO = CONSUMESRNO & "|" & Val(ROW.Cells(GCONSUMESRNO.Index).Value)
                        RATE = RATE & "|" & Val(ROW.Cells(GRATE.Index).Value)
                        AMOUNT = AMOUNT & "|" & Val(ROW.Cells(GAMOUNT.Index).Value)
                    End If
                End If
            Next
            ALPARAVAL.Add(SRNO)
            ALPARAVAL.Add(ITEM)
            'ALPARAVAL.Add(SHELF)
            'ALPARAVAL.Add(SIZE)
            ALPARAVAL.Add(LOTNO)
            ALPARAVAL.Add(UNIT)
            ALPARAVAL.Add(QTY)
            ALPARAVAL.Add(WT)
            ALPARAVAL.Add(CONSUMENO)
            ALPARAVAL.Add(CONSUMESRNO)
            ALPARAVAL.Add(RATE)
            ALPARAVAL.Add(AMOUNT)

            Dim OBJCONSUME As New ClsConsumptionReturn
            OBJCONSUME.alParaval = ALPARAVAL

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                IntResult = OBJCONSUME.SAVE()
                MsgBox("Deatils Added !!")
            Else

                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                ALPARAVAL.Add(TEMPCONSUMENO)
                IntResult = OBJCONSUME.UPDATE()
                MsgBox("Details Updated")
                'PRINTREPORT(TEMPBILLNO)
                edit = False

            End If
            CLEAR()
            TXTMATERIALRETURNBY.Focus()

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

    Sub FILLGRID()
        gridCONSUME.Enabled = True

        If gridDoubleClick = False Then
            gridCONSUME.Rows.Add(Val(TXTITEMSRNO.Text.Trim), cmbitemname.Text.Trim, cmbshelf.Text.Trim, TXTSIZE.Text.Trim, Format(Val(TXTWT.Text.Trim), "0.00"), TXTBATCHNO.Text.Trim, cmbunit.Text.Trim, Format(Val(TXTQTY.Text.Trim), "0.00"))
            getsrno(gridCONSUME)
        ElseIf gridDoubleClick = True Then
            gridCONSUME.Item(gsrno.Index, tempRow).Value = Val(TXTITEMSRNO.Text)
            gridCONSUME.Item(gitemname.Index, tempRow).Value = cmbitemname.Text.Trim
            'gridCONSUME.Item(gshelf.Index, tempRow).Value = cmbshelf.Text.Trim
            'gridCONSUME.Item(GSize.Index, tempRow).Value = TXTSIZE.Text.Trim
            'gridCONSUME.Item(gWt.Index, tempRow).Value = Format(Val(TXTWT.Text), "0.00")
            'gridCONSUME.Item(Gbatchno.Index, tempRow).Value = TXTBATCHNO.Text.Trim
            gridCONSUME.Item(gunit.Index, tempRow).Value = cmbunit.Text.Trim
            gridCONSUME.Item(gQty.Index, tempRow).Value = Format(Val(TXTQTY.Text.Trim), "0.00")

            gridDoubleClick = False
        End If
        TOTAL()
        gridCONSUME.FirstDisplayedScrollingRowIndex = gridCONSUME.RowCount - 1

        cmbitemname.Text = ""
        cmbshelf.Text = ""
        TXTSIZE.Clear()
        TXTWT.Clear()
        TXTQTY.Clear()
        TXTBATCHNO.Clear()
        cmbunit.Text = ""
        If gridCONSUME.RowCount > 0 Then
            TXTITEMSRNO.Text = Val(gridCONSUME.Rows(gridCONSUME.RowCount - 1).Cells(gsrno.Index).Value) + 1
        Else
            TXTITEMSRNO.Text = 1
        End If

    End Sub

    Sub TOTAL()
        lbltotalqty.Text = "0.00"
        For Each row As DataGridViewRow In gridCONSUME.Rows
            If Val(row.Cells(gQty.Index).Value) <> 0 Then
                lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(row.Cells(gQty.Index).EditedFormattedValue), "0.00")
                row.Cells(GAMOUNT.Index).Value = Format(row.Cells(gQty.Index).EditedFormattedValue * Val(row.Cells(GRATE.Index).EditedFormattedValue), "0.00")
            End If
        Next
    End Sub

    Sub EDITROW()
        Try
            If gridCONSUME.CurrentRow.Index >= 0 And gridCONSUME.Item(gsrno.Index, gridCONSUME.CurrentRow.Index).Value <> Nothing Then

                gridDoubleClick = True
                TXTITEMSRNO.Text = gridCONSUME.Item(gsrno.Index, gridCONSUME.CurrentRow.Index).Value
                cmbitemname.Text = gridCONSUME.Item(gitemname.Index, gridCONSUME.CurrentRow.Index).Value.ToString
                'cmbshelf.Text = gridCONSUME.Item(gshelf.Index, gridCONSUME.CurrentRow.Index).Value.ToString
                'TXTSIZE.Text = gridCONSUME.Item(GSize.Index, gridCONSUME.CurrentRow.Index).Value.ToString
                'TXTWT.Text = gridCONSUME.Item(gWt.Index, gridCONSUME.CurrentRow.Index).Value
                'TXTBATCHNO.Text = gridCONSUME.Item(Gbatchno.Index, gridCONSUME.CurrentRow.Index).Value.ToString
                cmbunit.Text = gridCONSUME.Item(gunit.Index, gridCONSUME.CurrentRow.Index).Value.ToString
                TXTQTY.Text = gridCONSUME.Item(gQty.Index, gridCONSUME.CurrentRow.Index).Value.ToString

                tempRow = gridCONSUME.CurrentRow.Index
                TXTITEMSRNO.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridCONSUME_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridCONSUME.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub TXTQTY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTQTY.Validating
        Try
            If cmbitemname.Text.Trim <> "" And cmbshelf.Text.Trim <> "" And cmbunit.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 Then
                FILLGRID()
                TOTAL()
            Else
                If cmbitemname.Text.Trim.Length = 0 Then
                    MsgBox("Please Enter Item Name")
                    cmbitemname.Focus()
                End If

                If cmbshelf.Text.Trim.Length = 0 Then
                    MsgBox("Please Enter Shelf Name")
                    cmbshelf.Focus()
                End If

                If cmbunit.Text.Trim.Length = 0 Then
                    MsgBox("Please Enter Unit")
                    cmbunit.Focus()
                End If

                If Val(TXTQTY.Text.Trim) = 0 Then
                    MsgBox("Please Enter Qty")
                    TXTQTY.Focus()
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Consumption_Return_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then CMDOK_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.F8 Then
                gridCONSUME.Focus()
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

        If TXTMATERIALRETURNBY.Text.Trim = "" Then
            Ep.SetError(TXTMATERIALRETURNBY, "Please Enter Name")
            BLN = False
        End If

        If TXTMATERIALGIVENTO.Text.Trim = "" Then
            Ep.SetError(TXTMATERIALGIVENTO, "Please Enter Name")
            BLN = False
        End If

        If CMBGODOWN.Text.Trim = "" Then
            Ep.SetError(CMBGODOWN, "Please Enter Godown Name")
            BLN = False
        End If
        'If CMBDEPARTMENT.Text.Trim = "" Then
        '    Ep.SetError(CMBDEPARTMENT, "Please Enter Department Name")
        '    BLN = False
        'End If

        If gridCONSUME.RowCount = 0 Then
            Ep.SetError(TXTQTY, "Enter Item Details")
            BLN = False
        End If

        If lbllocked.Visible = True Then
            Ep.SetError(lbllocked, "Quotation Raised, Delete Quotation First")
            BLN = False
        End If
        If CMBMACHINE.Text.Trim = "" Then
            Ep.SetError(CMBMACHINE, "Please Enter Machine No")
            BLN = False
        End If

        If gridCONSUME.RowCount > 0 And edit = False Then
            For Each ROW As DataGridViewRow In gridCONSUME.Rows

                If (ROW.Cells(gitemname.Index).Value) <> "" And Val(ROW.Cells(gQty.Index).Value) > 0 And Val(ROW.Cells(GCONSUMENO.Index).Value) > 0 And Val(ROW.Cells(GCONSUMESRNO.Index).Value) > 0 Then
                    Dim STRITEM As String
                    Dim STRQTY As Double
                    Dim STRFROMNO As Integer
                    Dim STRFROMSRNO As Integer

                    STRITEM = ROW.Cells(gitemname.Index).Value
                    STRQTY = ROW.Cells(gQty.Index).Value
                    STRFROMNO = ROW.Cells(GCONSUMENO.Index).Value
                    STRFROMSRNO = ROW.Cells(GCONSUMESRNO.Index).Value

                    Dim OBJCMN As New ClsCommonMaster
                    Dim DT As DataTable = OBJCMN.search(" ISNULL(CONSUMPTION_DESC.CONSUME_QTY, 0) AS QTY", "", "CONSUMPTION_DESC", " AND CONSUMPTION_DESC.CONSUME_NO= " & STRFROMNO & " AND CONSUMPTION_DESC.CONSUME_GRIDSRNO= " & STRFROMSRNO & " AND CONSUMPTION_DESC.CONSUME_Yearid = " & YearId)
                    If DT.Rows.Count <= 0 Then GoTo LINE1
                    If STRQTY > Val(DT.Rows(0).Item(0)) Then
LINE1:
                        Ep.SetError(lbltotalqty, "Qty are exceeds than consumption! ")
                        gridCONSUME.CurrentRow.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                        BLN = False
                    End If
                End If
            Next
        End If

        ''EDIT = TRUE
        If gridCONSUME.RowCount > 0 And edit = True Then
            For Each ROW As DataGridViewRow In gridCONSUME.Rows

                If (ROW.Cells(gitemname.Index).Value) <> "" And Val(ROW.Cells(gQty.Index).Value) > 0 And Val(ROW.Cells(GCONSUMENO.Index).Value) > 0 And Val(ROW.Cells(GCONSUMESRNO.Index).Value) > 0 Then
                    Dim STRITEM As String
                    Dim STRQTY As Double
                    Dim STRFROMNO As Integer
                    Dim STRFROMSRNO As Integer
                    Dim BALQTY As Double

                    STRITEM = ROW.Cells(gitemname.Index).Value
                    STRQTY = ROW.Cells(gQty.Index).Value
                    STRFROMNO = ROW.Cells(GCONSUMENO.Index).Value
                    STRFROMSRNO = ROW.Cells(GCONSUMESRNO.Index).Value

                    Dim objclscommon As New ClsCommonMaster
                    Dim dt As DataTable = objclscommon.search(" ISNULL((CONSUMPTION_DESC.CONSUME_QTY - CONSUMPTION_DESC.CONSUME_OUTQTY), 0) AS QTY ", "", "CONSUMPTION_DESC ", " AND CONSUMPTION_DESC.CONSUME_NO= " & STRFROMNO & " AND CONSUMPTION_DESC.CONSUME_GRIDSRNO= " & STRFROMSRNO & " AND CONSUMPTION_DESC.CONSUME_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        BALQTY = Format(Val(dt.Rows(0).Item(0)), "0.000")
                    End If

                    Dim dt1 As DataTable = objclscommon.search(" ISNULL( CONSUMERET_QTY,0) AS QTY ", "", "CONSUMPTIONRETURN_DESC ", " AND CONSUMPTIONRETURN_DESC.CONSUMERET_NO = " & TEMPCONSUMENO & " AND CONSUMPTIONRETURN_DESC.CONSUMERET_CONSUMENO = " & Val(STRFROMNO) & " AND CONSUMPTIONRETURN_DESC.CONSUMERET_CONSUMESRNO = " & Val(STRFROMSRNO) & " and CONSUMPTIONRETURN_DESC.CONSUMERET_Yearid = " & YearId)
                    If dt1.Rows.Count > 0 Then
                        BALQTY = BALQTY + Val(dt1.Rows(0).Item(0))
                    End If

                    If STRQTY > BALQTY Then
                        Ep.SetError(lbltotalqty, "Qty are exceeds than consumption! " & BALQTY)
                        gridCONSUME.CurrentRow.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                        BLN = False
                    End If
                    BALQTY = 0
                End If
            Next
        End If

        If Not datecheck(CONSUMERETDATE.Value) Then BLN = False

        Return BLN
    End Function

    Private Sub TXTITEMSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTITEMSRNO.GotFocus
        If gridDoubleClick = False Then
            If gridCONSUME.RowCount > 0 Then
                TXTITEMSRNO.Text = Val(gridCONSUME.Rows(gridCONSUME.RowCount - 1).Cells(gsrno.Index).Value) + 1
            Else
                TXTITEMSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If edit = True Then
                Dim BLN As Boolean = True
                Dim TEMPMSG As Integer = MsgBox("Delete CONSUME?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    Dim ALPARAVAL As New ArrayList
                    Dim OBJPR As New ClsConsumptionReturn

                    ALPARAVAL.Add(TEMPCONSUMENO)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)

                    OBJPR.alParaval = ALPARAVAL
                    Dim IntResult As Integer = OBJPR.Delete()
                    MsgBox("CONSUMEUEST Deleted")
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

            Dim objprdetails As New ConsumptionReturnDetails
            objprdetails.MdiParent = MDIMain
            objprdetails.Show()
            objprdetails.BringToFront()
            'Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            gridCONSUME.RowCount = 0
Line1:
            TEMPCONSUMENO = Val(TXTCONSUMERETURNNO.Text) - 1
            If TEMPCONSUMENO > 0 Then
                edit = True
                Consumption_Return_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If
            If gridCONSUME.RowCount = 0 And TEMPCONSUMENO > 1 Then
                TXTCONSUMERETURNNO.Text = TEMPCONSUMENO
                GoTo Line1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            gridCONSUME.RowCount = 0
LINE1:
            TEMPCONSUMENO = Val(TXTCONSUMERETURNNO.Text) + 1
            GETMAX_CONSUMERETURN_NO()
            Dim MAXNO As Integer = TXTCONSUMERETURNNO.Text.Trim
            CLEAR()
            If Val(TXTCONSUMERETURNNO.Text) - 1 >= TEMPCONSUMENO Then
                edit = True
                Consumption_Return_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If
            If gridCONSUME.RowCount = 0 And TEMPCONSUMENO < MAXNO Then
                TXTCONSUMERETURNNO.Text = TEMPCONSUMENO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call CMDOK_Click(sender, e)
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click

    End Sub

    Private Sub CONSUMERETDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CONSUMERETDATE.Validating
        If Not datecheck(CONSUMERETDATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            gridCONSUME.RowCount = 0
            TEMPCONSUMENO = Val(tstxtbillno.Text)
            If TEMPCONSUMENO > 0 Then
                edit = True
                Consumption_Return_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWT.KeyPress
        numdot3(e, TXTWT, Me)
    End Sub

    Private Sub TXTQTY_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTQTY.KeyPress
        numdot3(e, TXTQTY, Me)
    End Sub

    Private Sub gridCONSUME_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridCONSUME.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridCONSUME.RowCount > 0 Then
                gridCONSUME.Rows.RemoveAt(gridCONSUME.CurrentRow.Index)
                TOTAL()
                getsrno(gridCONSUME)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub gridCONSUME_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridCONSUME.CellValidating
        Try
            Dim colNum As Integer = gridCONSUME.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case gQty.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If gridCONSUME.CurrentCell.Value = Nothing Then gridCONSUME.CurrentCell.Value = "0.00"
                        gridCONSUME.CurrentCell.Value = Convert.ToDecimal(gridCONSUME.Item(colNum, e.RowIndex).Value)
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

    Private Sub CMDSELECTCONSUMPTION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTCONSUMPTION.Click
        Try
            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJSELECTCON As New SelectConsumption
            Dim DTPR As DataTable = OBJSELECTCON.DT
            OBJSELECTCON.ShowDialog()

            Dim i As Integer = 0
            If DTPR.Rows.Count > 0 Then
                Dim OBJCMN As New ClsCommon

                For Each DTROW As DataRow In DTPR.Rows

                    Dim DT As DataTable = OBJCMN.search("  CONSUMPTION.CONSUME_NO AS CONSUMENO, CONSUMPTION.CONSUME_DATE AS CONSUMEDATE, ISNULL(CONSUMPTION.CONSUME_MATERIALGIVENTO, '') AS MATERIALGIVENBY, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(DEPARTMENTMASTER.DEPARTMENT_name, '') AS DEPARTMENT, ISNULL(CONSUMPTION_DESC.CONSUME_LOTNO, '') AS LOTNO,  ISNULL(CONSUMPTION_DESC.CONSUME_GRIDSRNO, 0) AS SRNO, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT,  ISNULL(CONSUMPTION_DESC.CONSUME_QTY - CONSUMPTION_DESC.CONSUME_OUTQTY, 0) AS QTY, ISNULL(CONSUMPTION_DESC.CONSUME_WT, 0) AS WT, ISNULL(CONSUMPTION_DESC.CONSUME_RATE, 0) AS RATE,  ISNULL(CONSUMPTION.CONSUME_CHALLANNO, '') AS CHALLANNO, ISNULL(MACHINEMASTER.MACHINE_NAME, '') AS MACHINE  ", "", "   CONSUMPTION INNER JOIN CONSUMPTION_DESC ON CONSUMPTION.CONSUME_NO = CONSUMPTION_DESC.CONSUME_no AND CONSUMPTION.CONSUME_yearid = CONSUMPTION_DESC.CONSUME_yearid INNER JOIN GODOWNMASTER ON CONSUMPTION.CONSUME_GODOWNID = GODOWNMASTER.GODOWN_id AND CONSUMPTION.CONSUME_yearid = GODOWNMASTER.GODOWN_yearid INNER JOIN DEPARTMENTMASTER ON CONSUMPTION.CONSUME_DEPARTMENTID = DEPARTMENTMASTER.DEPARTMENT_id AND CONSUMPTION.CONSUME_yearid = DEPARTMENTMASTER.DEPARTMENT_yearid INNER JOIN NONINVITEMMASTER ON CONSUMPTION_DESC.CONSUME_ITEMID = NONINVITEMMASTER.NONINV_ID AND CONSUMPTION_DESC.CONSUME_yearid = NONINVITEMMASTER.NONINV_YEARID LEFT OUTER JOIN MACHINEMASTER ON CONSUMPTION.CONSUME_MACHINEID = MACHINEMASTER.MACHINE_ID LEFT OUTER JOIN UNITMASTER ON CONSUMPTION_DESC.CONSUME_yearid = UNITMASTER.unit_yearid AND CONSUMPTION_DESC.CONSUME_UNITID = UNITMASTER.unit_id  ", " AND CONSUMPTION.CONSUME_NO = " & Val(DTROW(0)) & " AND CONSUMPTION_DESC.CONSUME_GRIDSRNO = " & Val(DTROW(1)) & " AND CONSUMPTION.CONSUME_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then

                        CMBGODOWN.Enabled = False
                        CMBGODOWN.Text = DT.Rows(0).Item("GODOWN").ToString
                        TXTCONUSMENO.Text = DT.Rows(0).Item("CONSUMENO").ToString
                        TXTDEPARTMENT.Text = DT.Rows(0).Item("DEPARTMENT").ToString
                        TXTMATERIALRETURNBY.Text = DT.Rows(0).Item("MATERIALGIVENBY").ToString
                        CMBMACHINE.Text = DT.Rows(0).Item("MACHINE").ToString
                        TXTCHALLANNO.Text = DT.Rows(0).Item("CHALLANNO").ToString


                        'ITEM GRID
                        For Each ROW As DataRow In DT.Rows
                            gridCONSUME.Rows.Add(0, ROW("ITEMNAME").ToString, ROW("LOTNO").ToString, ROW("UNIT").ToString, Format(Val(ROW("QTY")), "0.00"), Format(Val(ROW("WT")), "0.00"), Val(ROW("CONSUMENO")), Val(ROW("SRNO")), 0, Format(Val(ROW("RATE")), "0.00"))
                        Next
                        CMDSELECTCONSUMPTION.Enabled = False
                        TOTAL()
                        getsrno(gridCONSUME)
                        TXTCONSUMERETURNNO.Focus()
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call CMDDELETE_Click(sender, e)
    End Sub

    Private Sub TXTCHALLANNO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCHALLANNO.KeyPress
        numkeypress(e, TXTCHALLANNO, Me)
    End Sub


    Private Sub CMBMACHINE_Enter(sender As Object, e As EventArgs) Handles CMBMACHINE.Enter
        Try
            If CMBMACHINE.Text.Trim = "" Then FILLMACHINE(CMBMACHINE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMACHINE_Validating(sender As Object, e As CancelEventArgs) Handles CMBMACHINE.Validating
        Try
            If CMBMACHINE.Text.Trim <> "" Then MACHINEVALIDATE(CMBMACHINE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class