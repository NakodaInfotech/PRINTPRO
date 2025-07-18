
Imports System.ComponentModel
Imports BL

Public Class Consumption
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim tempRow As Integer
    Public edit As Boolean
    Public TEMPCONSUMENO As String
    Public tempMsg As Integer
    Public FRMSTRING As String

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        CLEAR()
        edit = False
    End Sub

    Sub CLEAR()
        TXTMATERIALGIVENBY.Clear()
        TXTMATERIALGIVENTO.Clear()
        CMBDEPARTMENT.Text = ""
        CMBGODOWN.Text = ""
        tstxtbillno.Clear()
        CONSUMEdate.Value = Mydate

        gridCONSUME.RowCount = 0
        cmbitemname.Text = ""
        CMBMACHINE.Text = ""
        cmbshelf.Text = ""
        cmbunit.Text = ""
        TXTSIZE.Clear()
        TXTBATCHNO.Clear()
        TXTQTY.Clear()
        TXTWT.Clear()
        lbltotalqty.Text = "0.00"
        txtremarks.Clear()
        TXTBATCHNO.Clear()
        TXTCHALLANNO.Clear()



        gridDoubleClick = False
        Ep.Clear()
        CMDSELECTSTOCK.Enabled = True
        CMDSELECTBATCH.Enabled = True

        If gridCONSUME.RowCount > 0 Then
            TXTITEMSRNO.Text = Val(gridCONSUME.Rows(gridCONSUME.RowCount - 1).Cells(gsrno.Index).Value) + 1
        Else
            TXTITEMSRNO.Text = 1
        End If
        GETMAX_CONSUME_NO()
    End Sub

    Sub GETMAX_CONSUME_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(CONSUME_no),0) + 1 ", "CONSUMPTION", " AND CONSUME_cmpid=" & CmpId & " and CONSUME_LOCATIONID=" & Locationid & " and CONSUME_YEARID=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTCONSUMENO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Sub FILLCMB()
        If CMBDEPARTMENT.Text.Trim = "" Then FILLDEPARTMNET(CMBDEPARTMENT, edit)
        If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
        If CMBMACHINE.Text.Trim = "" Then FILLMACHINE(CMBMACHINE)

    End Sub

    Private Sub Consumption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            Me.Text = "Consumption - " & FRMSTRING
            LBLCONSUMPTION.Text = "Consumption - " & FRMSTRING

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim ALPARAVAL As New ArrayList
                Dim objclsCONSUME As New ClsConsumption

                ALPARAVAL.Add(TEMPCONSUMENO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                objclsCONSUME.alParaval = ALPARAVAL
                Dim dt As DataTable = objclsCONSUME.selectconsume()

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        TXTCONSUMENO.Text = TEMPCONSUMENO
                        CONSUMEdate.Value = Convert.ToDateTime(dr("CONSUMEDATE"))
                        TXTMATERIALGIVENBY.Text = Convert.ToString(dr("MATERIALBY"))
                        TXTMATERIALGIVENTO.Text = Convert.ToString(dr("MATERIALTO"))
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN"))
                        CMBDEPARTMENT.Text = Convert.ToString(dr("DEPARTMENT"))
                        TXTBATCHNO.Text = Convert.ToString(dr("BATCHNO"))
                        lbltotalqty.Text = Format(Val(dr("TOTALQTY")), "0.00")
                        txtremarks.Text = Convert.ToString(dr("remarks"))
                        CMBMACHINE.Text = Convert.ToString(dr("MACHINE"))
                        TXTCHALLANNO.Text = Convert.ToString(dr("CHALLANNO"))



                        gridCONSUME.Rows.Add(Val(dr("gridsrno")), dr("ITEMNAME").ToString, dr("LOTNO").ToString, dr("UNIT").ToString, Format(Val(dr("QTY")), "0.00"), Format(Val(dr("WT")), "0.00"), 0, Format(Val(dr("RATE")), "0.00"), Format(Val(dr("AMOUNT")), "0.00"))

                    Next
                    gridCONSUME.FirstDisplayedScrollingRowIndex = gridCONSUME.RowCount - 1
                End If
                CMDSELECTBATCH.Enabled = False
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

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Dim IntResult As Integer
        Try
            Cursor.Current = Cursors.WaitCursor
            Ep.Clear()

            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(CONSUMEdate.Value.Date)
            ALPARAVAL.Add(TXTMATERIALGIVENBY.Text.Trim)
            ALPARAVAL.Add(TXTMATERIALGIVENTO.Text.Trim)
            ALPARAVAL.Add(CMBGODOWN.Text.Trim)
            ALPARAVAL.Add(CMBDEPARTMENT.Text.Trim)
            ALPARAVAL.Add(Val(TXTBATCHNO.Text.Trim))
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
            Dim GRIDSRNO As String = ""
            'Dim PARTYNAME As String = ""
            Dim ITEM As String = ""
            'Dim SHELF As String = ""
            ' Dim SIZE As String = ""
            ' Dim WT As String = ""
            Dim LOTNO As String = ""
            Dim UNIT As String = ""
            Dim QTY As String = ""
            Dim WT As String = ""
            Dim OUTQTY As String = ""
            Dim RATE As String = ""
            Dim AMOUNT As String = ""

            For Each ROW As Windows.Forms.DataGridViewRow In gridCONSUME.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = ROW.Cells(gsrno.Index).Value
                        'PARTYNAME = ROW.Cells(GPARTYNAME.Index).Value.ToString
                        ITEM = ROW.Cells(gitemname.Index).Value.ToString
                        'SHELF = ROW.Cells(gshelf.Index).Value.ToString
                        'SIZE = ROW.Cells(GSize.Index).Value.ToString
                        'WT = Val(ROW.Cells(gWt.Index).Value)
                        LOTNO = ROW.Cells(GLOTNO.Index).Value.ToString
                        UNIT = ROW.Cells(gunit.Index).Value.ToString
                        QTY = Val(ROW.Cells(gQty.Index).Value)
                        WT = Val(ROW.Cells(GWT.Index).Value)
                        OUTQTY = Val(ROW.Cells(GOUTQTY.Index).Value)
                        RATE = Val(ROW.Cells(GRATE.Index).Value)
                        AMOUNT = Val(ROW.Cells(GAMOUNT.Index).Value)

                    Else
                        GRIDSRNO = GRIDSRNO & "|" & ROW.Cells(gsrno.Index).Value
                        'PARTYNAME = PARTYNAME & "|" & ROW.Cells(GPARTYNAME.Index).Value.ToString
                        ITEM = ITEM & "|" & ROW.Cells(gitemname.Index).Value.ToString
                        'SHELF = SHELF & "|" & ROW.Cells(gshelf.Index).Value.ToString
                        'SIZE = SIZE & "|" & ROW.Cells(GSize.Index).Value.ToString
                        'WT = WT & "|" & Val(ROW.Cells(gWt.Index).Value)
                        LOTNO = LOTNO & "|" & ROW.Cells(GLOTNO.Index).Value.ToString
                        UNIT = UNIT & "|" & ROW.Cells(gunit.Index).Value.ToString
                        QTY = QTY & "|" & Val(ROW.Cells(gQty.Index).Value)
                        WT = WT & "|" & Val(ROW.Cells(GWT.Index).Value)
                        OUTQTY = OUTQTY & "|" & Val(ROW.Cells(GOUTQTY.Index).Value)
                        RATE = RATE & "|" & Val(ROW.Cells(GRATE.Index).Value)
                        AMOUNT = AMOUNT & "|" & Val(ROW.Cells(GAMOUNT.Index).Value)

                    End If
                End If
            Next
            ALPARAVAL.Add(GRIDSRNO)
            ' ALPARAVAL.Add(PARTYNAME)
            ALPARAVAL.Add(ITEM)
            'ALPARAVAL.Add(SHELF)
            'ALPARAVAL.Add(SIZE)
            'ALPARAVAL.Add(WT)
            ALPARAVAL.Add(LOTNO)
            ALPARAVAL.Add(UNIT)
            ALPARAVAL.Add(QTY)
            ALPARAVAL.Add(WT)
            ALPARAVAL.Add(OUTQTY)
            ALPARAVAL.Add(RATE)
            ALPARAVAL.Add(AMOUNT)

            Dim OBJCONSUME As New ClsConsumption
            OBJCONSUME.alParaval = ALPARAVAL

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTT As DataTable = OBJCONSUME.SAVE()

                MsgBox("Details Added !!")
                PRINTREPORT(DTT.Rows(0).Item(0))

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
            TXTMATERIALGIVENBY.Focus()

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
                If LCase(row.Cells(gunit.Index).Value) = "reams" Then
                    'get SIZE AND GSM FROM NONINV MASTER AND CALC WT
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("ISNULL(NONINV_LENGTH,0) AS LENGTH, ISNULL(NONINV_WIDTH,0) AS WIDTH, ISNULL(NONINV_GSM,0) AS GSM ", "", " NONINVITEMMASTER ", " AND NONINV_NAME = '" & row.Cells(gitemname.Index).Value & "' AND NONINV_YEARID = " & YearId)
                    If Val(DT.Rows(0).Item("LENGTH")) > 0 And Val(DT.Rows(0).Item("WIDTH")) > 0 And Val(DT.Rows(0).Item("GSM")) > 0 Then
                        row.Cells(GWT.Index).Value = Format(((((Val(DT.Rows(0).Item("LENGTH")) * Val(DT.Rows(0).Item("WIDTH")) * Val(DT.Rows(0).Item("GSM"))) / 3100) / 500) * Val(TXTSHEETSPERREAM.Text.Trim)) * (Val(row.Cells(gQty.Index).EditedFormattedValue)), "0.000")
                    End If
                ElseIf LCase(row.Cells(gunit.Index).Value) = "sheets" Then
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("ISNULL(NONINV_LENGTH,0) AS LENGTH, ISNULL(NONINV_WIDTH,0) AS WIDTH, ISNULL(NONINV_GSM,0) AS GSM ", "", " NONINVITEMMASTER ", " AND NONINV_NAME = '" & row.Cells(gitemname.Index).Value & "' AND NONINV_YEARID = " & YearId)
                    If Val(DT.Rows(0).Item("LENGTH")) > 0 And Val(DT.Rows(0).Item("WIDTH")) > 0 And Val(DT.Rows(0).Item("GSM")) > 0 Then
                        TXTWT.Text = Format(((((Val(DT.Rows(0).Item("LENGTH")) * Val(DT.Rows(0).Item("WIDTH")) * Val(DT.Rows(0).Item("GSM")) / 3100) / 500) * Val(TXTSHEETSPERREAM.Text.Trim))), "0.000")
                    End If
                End If
                row.Cells(GAMOUNT.Index).Value = Format(row.Cells(gQty.Index).EditedFormattedValue * Val(row.Cells(GRATE.Index).EditedFormattedValue), "0.00")
                lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(row.Cells(gQty.Index).EditedFormattedValue), "0.00")
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
        'EDITROW()
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

    Private Sub Consumption_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

        If TXTMATERIALGIVENBY.Text.Trim = "" Then
            Ep.SetError(TXTMATERIALGIVENBY, "Please Enter Name")
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
        If CMBDEPARTMENT.Text.Trim = "" Then
            Ep.SetError(CMBDEPARTMENT, "Please Enter Department Name")
            BLN = False
        End If


        If CMBMACHINE.Text.Trim = "" Then
            Ep.SetError(CMBMACHINE, "Please Enter Machine No")
            BLN = False
        End If

        If gridCONSUME.RowCount = 0 Then
            Ep.SetError(TXTMATERIALGIVENBY, "Enter Item Details")
            BLN = False
        End If

        For Each row As DataGridViewRow In gridCONSUME.Rows
            If Val(row.Cells(gQty.Index).Value) <= 0 Then
                Ep.SetError(lbltotalqty, "Quantity cannot be 0 or less")
                BLN = False
            End If

        Next

        If gridCONSUME.RowCount > 0 And edit = False Then
            For Each ROW As DataGridViewRow In gridCONSUME.Rows
                Dim OBJCMN As New ClsCommonMaster
                Dim DT As DataTable = OBJCMN.search("SUM(QTY)AS QTY", "", "STOCKVIEW", "AND GODOWN='" & CMBGODOWN.Text.Trim & "' AND ITEMNAME = '" & ROW.Cells(gitemname.Index).Value & "'  AND CHALLANNO = '" & TXTCHALLANNO.Text.Trim & "' AND YEARID = " & YearId)
                If DT.Rows.Count <= 0 Then GoTo LINE1
                If Val(ROW.Cells(gQty.Index).Value) > Val(DT.Rows(0).Item(0)) Then
LINE1:
                    Ep.SetError(lbltotalqty, "Stock Not Present ! ")
                    gridCONSUME.CurrentRow.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                    BLN = False
                End If
            Next
        End If

        If gridCONSUME.RowCount > 0 And edit = True Then
            For Each ROW As DataGridViewRow In gridCONSUME.Rows
                Dim BALQTY As Double = 0
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search("SUM(QTY)AS QTY", "", "STOCKVIEW", "AND GODOWN='" & CMBGODOWN.Text.Trim & "' AND CHALLANNO = '" & TXTCHALLANNO.Text.Trim & "'  AND ITEMNAME = '" & ROW.Cells(gitemname.Index).Value & "' AND YEARID = " & YearId)
                If dt.Rows.Count > 0 Then BALQTY = Format(Val(dt.Rows(0).Item(0)), "0.000")

                dt = objclscommon.search(" ISNULL(CONSUMPTION_DESC.CONSUME_QTY, 0) AS QTY ", "", " CONSUMPTION_DESC INNER JOIN NONINVITEMMASTER ON CONSUMPTION_DESC.CONSUME_ITEMID = NONINVITEMMASTER.NONINV_ID AND CONSUMPTION_DESC.CONSUME_yearid = NONINVITEMMASTER.NONINV_YEARID INNER JOIN CONSUMPTION ON CONSUMPTION_DESC.CONSUME_no = CONSUMPTION.CONSUME_NO AND CONSUMPTION_DESC.CONSUME_yearid = CONSUMPTION.CONSUME_yearid", " AND CONSUMPTION_DESC.CONSUME_NO = " & TEMPCONSUMENO & " and NONINVITEMMASTER.NONINV_NAME = '" & ROW.Cells(gitemname.Index).Value & "' AND CONSUMPTION.CONSUME_CHALLANNO = '" & TXTCHALLANNO.Text.Trim & "'  AND CONSUMPTION_DESC.CONSUME_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then BALQTY = BALQTY + Val(dt.Rows(0).Item(0))

                If Val(ROW.Cells(gQty.Index).Value) > BALQTY Then
                    Ep.SetError(lbltotalqty, "Stock Not Present! " & BALQTY)
                    gridCONSUME.CurrentRow.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                    BLN = False
                End If
                BALQTY = 0
            Next
        End If

        If Not datecheck(CONSUMEdate.Value) Then BLN = False

        Return BLN
    End Function

    Private Sub CMBGODOWN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
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

    Private Sub CMBDEPARTMENT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDEPARTMENT.Enter
        Try
            If CMBDEPARTMENT.Text.Trim = "" Then FILLDEPARTMNET(CMBDEPARTMENT, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEPARTMENT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDEPARTMENT.Validating
        Try
            If CMBDEPARTMENT.Text.Trim <> " " Then DEPARTMENTVALIDATE(CMBDEPARTMENT, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then FILLNONINVITEM(cmbitemname, edit)
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

    Private Sub cmbshelf_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbshelf.Enter
        Try
            If cmbshelf.Text.Trim = "" Then fillSHELF(cmbshelf, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbshelf_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbshelf.Validating
        Try
            If cmbshelf.Text.Trim <> "" Then SHELFVALIDATE(cmbshelf, e, Me)
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

    Private Sub cmbunit_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunit.Validating
        Try
            If cmbunit.Text.Trim <> "" Then unitvalidate(cmbunit, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

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
                Dim TEMPMSG As Integer = MsgBox("Delete Consume Item?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    Dim ALPARAVAL As New ArrayList
                    Dim OBJPR As New ClsConsumption

                    ALPARAVAL.Add(TEMPCONSUMENO)
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(Locationid)
                    ALPARAVAL.Add(YearId)
                    ALPARAVAL.Add(Userid)

                    OBJPR.alParaval = ALPARAVAL
                    Dim IntResult As Integer = OBJPR.Delete()
                    MsgBox("Consumption Item Deleted")
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

            Dim objprdetails As New ConsumptionDetails
            objprdetails.MdiParent = MDIMain
            objprdetails.FRMSTRING = FRMSTRING
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
            TEMPCONSUMENO = Val(TXTCONSUMENO.Text) - 1
            If TEMPCONSUMENO > 0 Then
                edit = True
                Consumption_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If
            If gridCONSUME.RowCount = 0 And TEMPCONSUMENO > 1 Then
                TXTCONSUMENO.Text = TEMPCONSUMENO
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
            TEMPCONSUMENO = Val(TXTCONSUMENO.Text) + 1
            GETMAX_CONSUME_NO()
            Dim MAXNO As Integer = TXTCONSUMENO.Text.Trim
            CLEAR()
            If Val(TXTCONSUMENO.Text) - 1 >= TEMPCONSUMENO Then
                edit = True
                Consumption_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If
            If gridCONSUME.RowCount = 0 And TEMPCONSUMENO < MAXNO Then
                TXTCONSUMENO.Text = TEMPCONSUMENO
                GoTo LINE1
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

    Private Sub CONSUMEdate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CONSUMEdate.Validating
        If Not datecheck(CONSUMEdate.Value) Then
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
                Consumption_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWT.KeyPress
        numdot(e, TXTWT, Me)
    End Sub

    Private Sub TXTQTY_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTQTY.KeyPress
        numdot(e, TXTQTY, Me)
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

    Private Sub CMDSELECTSTOCK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTSTOCK.Click
        Try
            If CMBGODOWN.Text.Trim = "" And gridCONSUME.RowCount = 0 Then
                MsgBox("Please Select Godown First", MsgBoxStyle.Critical)
                CMBGODOWN.Focus()
                Exit Sub
            End If

            Dim DTTABLE As New DataTable
            Dim OBJSELECTGDN As New SelectStock
            OBJSELECTGDN.GODOWN = CMBGODOWN.Text.Trim
            OBJSELECTGDN.TYPE = FRMSTRING
            OBJSELECTGDN.ShowDialog()
            DTTABLE = OBJSELECTGDN.DT

            If DTTABLE.Rows.Count > 0 Then
                TXTCHALLANNO.Text = DTTABLE.Rows(0).Item("CHALLANNO").ToString

                For Each dr As DataRow In DTTABLE.Rows
                    gridCONSUME.Rows.Add(0, dr("ITEMNAME"), dr("LOTNO"), dr("UNIT"), Format(Val(dr("QTY")), "0.00"), Format(Val(dr("WT")), "0.00"), 0, Format(Val(dr("RATE")), "0.00"))
                Next
                gridCONSUME.FirstDisplayedScrollingRowIndex = gridCONSUME.RowCount - 1
                getsrno(gridCONSUME)
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click

        Try
            If edit = True Then PRINTREPORT(TEMPCONSUMENO)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Sub PRINTREPORT(ByVal CONSUMENO As Integer)
        Try
            tempMsg = MsgBox("Wish to Print Consumption Details?", MsgBoxStyle.YesNo)
            If tempMsg = vbYes Then
                Dim OBJGDN As New ConsumptionDesign
                OBJGDN.MdiParent = MDIMain
                OBJGDN.FRMSTRING = "CONSUMPTION"
                OBJGDN.WHERECLAUSE = "{CONSUMPTION.CONSUME_NO}=" & Val(CONSUMENO) & "  and {CONSUMPTION.CONSUME_yearid}=" & YearId
                OBJGDN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBATCHNO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBATCHNO.KeyPress, TXTCHALLANNO.KeyPress
        numkeypress(e, TXTBATCHNO, Me)
    End Sub

    Private Sub CMDSELECTBATCH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTBATCH.Click
        Try
            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            Dim OBJSELECTBACTH As New SelectBatch
            OBJSELECTBACTH.ShowDialog()

            Dim ORDERDT As DataTable = OBJSELECTBACTH.DT
            If ORDERDT.Rows.Count > 0 Then

                Dim objcmn As New ClsCommon

                For Each ROW As DataRow In ORDERDT.Rows
                    Dim dt As DataTable = objcmn.search("BATCHMASTER.jobbatch_no AS BATCHNO, ISNULL(BATCHMASTER.jobbatch_docketno, 0) AS JOBDOCKETNO, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME", "", "BATCHMASTER INNER JOIN ITEMMASTER ON BATCHMASTER.jobbatch_yearid = ITEMMASTER.item_yearid AND BATCHMASTER.jobbatch_itemid = ITEMMASTER.item_id", " AND BATCHMASTER.jobbatch_docketno = " & Val(ROW(0)) & " AND BATCHMASTER.jobbatch_no = " & Val(ROW(1)) & " AND BATCHMASTER.JOBBATCH_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        TXTBATCHNO.Text = dt.Rows(0).Item("BATCHNO")
                    End If
                Next
                CMDSELECTBATCH.Enabled = False
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
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