
Imports System.ComponentModel
    Imports BL

Public Class StockReco
    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Public TEMPRECONO As Integer          'used for editing
    Public EDIT As Boolean          'used for editing
    Dim TEMPROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim ALLOWMANUALRECNO As Boolean = False

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub StockReco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If ERRORVALID() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1 Then       'for Delete
            TabControl1.SelectedIndex = (0)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2 Then       'for Delete
            TabControl1.SelectedIndex = (1)
        ElseIf e.KeyCode = Keys.OemPipe Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
            tstxtbillno.Focus()
            tstxtbillno.SelectAll()
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.KeyCode = Keys.F5 Then     'grid focus
            GRIDSTOCK.Focus()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        End If
    End Sub

    Sub FILLCMB()
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
            If CMBITEMCODE.Text.Trim = "" Then fillITEMCODE(CMBITEMCODE, EDIT, " and ITEMMASTER.ITEM_MATERIALTYPE = 'FINISHED'")
            If CMBITEMNAME.Text.Trim = "" Then fillITEMNAME(CMBITEMNAME, EDIT, " and ITEMMASTER.ITEM_MATERIALTYPE = 'FINISHED'")


            ' If CMBLOTNO.Text.Trim = "" Then fillDESIGN(CMBLOTNO, CMBITEMNAME.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockReco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'STOCKRECO'")
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


                Dim objSTOCK As New ClsStockAdjustment()
                Dim dttable As DataTable = objSTOCK.SELECTSTOCKADJUSTMENT(TEMPRECONO, CmpId, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows
                        TXTRECONO.Text = TEMPRECONO
                        TXTRECONO.ReadOnly = True
                        DTRECODATE.Value = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        cmbtrans.Text = dr("TRANSNAME")
                        txtchallan.Text = dr("CHALLANNO")
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)
                        CMBNAME.Text = dr("NAME")
                        'Item Grid
                        If Val(dr("GRIDSRNO")) > 0 Then GRIDSTOCK.Rows.Add(dr("GRIDSRNO").ToString, dr("ITEMCODE").ToString, dr("ITEMNAME").ToString, Format(Val(dr("QTY")), "0.00"))

                    Next

                    'GET DATA FROM STOCKADJUSTMENT_INDESC
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("ISNULL(STOCKADJUSTMENT_INDESC.SA_INGRIDSRNO, 0) AS GRIDSRNO, ISNULL(ITEMMASTER.item_name, '') AS INITEMNAME, ISNULL(STOCKADJUSTMENT_INDESC.SA_INITEMCODE, '') AS INITEMCODE, ISNULL(STOCKADJUSTMENT_INDESC.SA_INQTY, 0) AS INQTY ", "", " STOCKADJUSTMENT LEFT OUTER JOIN STOCKADJUSTMENT_INDESC ON STOCKADJUSTMENT.SA_no = STOCKADJUSTMENT_INDESC.SA_NO AND STOCKADJUSTMENT.SA_yearid = STOCKADJUSTMENT_INDESC.SA_YEARID LEFT OUTER JOIN ITEMMASTER ON STOCKADJUSTMENT_INDESC.SA_INITEMID = ITEMMASTER.item_id  ", " AND STOCKADJUSTMENT.SA_NO = " & TEMPRECONO & " AND STOCKADJUSTMENT_INDESC.SA_YEARID = " & YearId & " ORDER BY STOCKADJUSTMENT_INDESC.SA_INGRIDSRNO")

                    'Dim DT As DataTable = OBJCMN.search(" ISNULL(STORESTOCKADJUSTMENT_INDESC.SA_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(PIECETYPEMASTER.PIECETYPE_name,'') AS PIECETYPE, ISNULL(ITEMMASTER.item_name, '') AS ITEM, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(STORESTOCKADJUSTMENT_INDESC.SA_BALENO, '') AS BALENO, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(STORESTOCKADJUSTMENT_INDESC.SA_CUT, 0) AS CUT, ISNULL(STORESTOCKADJUSTMENT_INDESC.SA_QTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(STORESTOCKADJUSTMENT_INDESC.SA_MTRS, 0) AS MTRS,ISNULL(STORESTOCKADJUSTMENT_INDESC.SA_RACKID, 0) AS RACK,ISNULL(STORESTOCKADJUSTMENT_INDESC.SA_SHELFID, 0) AS SHELF, ISNULL(STORESTOCKADJUSTMENT_INDESC.SA_BARCODE, '') AS BARCODE, ISNULL(STORESTOCKADJUSTMENT_INDESC.SA_OUTPCS, 0) AS OUTPCS, ISNULL(STORESTOCKADJUSTMENT_INDESC.SA_OUTMTRS, 0) AS OUTMTRS, STORESTOCKADJUSTMENT_INDESC.SA_GRIDDONE AS GRIDDONE ", "", " STORESTOCKADJUSTMENT_INDESC INNER JOIN PIECETYPEMASTER ON STORESTOCKADJUSTMENT_INDESC.SA_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id LEFT OUTER JOIN UNITMASTER ON STORESTOCKADJUSTMENT_INDESC.SA_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN DESIGNMASTER AS DESIGNMASTER ON STORESTOCKADJUSTMENT_INDESC.SA_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON STORESTOCKADJUSTMENT_INDESC.SA_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN COLORMASTER ON STORESTOCKADJUSTMENT_INDESC.SA_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN ITEMMASTER AS ITEMMASTER ON STORESTOCKADJUSTMENT_INDESC.SA_ITEMID = ITEMMASTER.item_id ", " AND SA_NO = " & TEMPRECONO & " AND SA_YEARID = " & YearId)
                    For Each DR As DataRow In DT.Rows
                        'Item Grid
                        GRIDSTOCKIN.Rows.Add(DR("GRIDSRNO").ToString, DR("INITEMCODE").ToString, DR("INITEMNAME").ToString, Format(Val(DR("INQTY")), "0.00"))


                        TabControl1.SelectedIndex = 1
                    Next

                Else
                    EDIT = False
                    CLEAR()
                End If


                TOTAL()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub CLEAR()

        EP.Clear()
        LBLCATEGORY.Text = ""
        txtchallan.Clear()
        DTRECODATE.Value = Now.Date
        tstxtbillno.Clear()
        CMDSELECTSTOCK.Enabled = True
        cmbtrans.Text = ""
        GRIDSTOCK.RowCount = 0
        txtsrno.Text = 1
        CMBITEMNAME.Text = "FRESH"
        CMBITEMNAME.Text = ""
        TXTQTY.Clear()
        TXTNOOFENTRIES.Clear()
        CMBNAME.Text = ""
        GRIDSTOCKIN.RowCount = 0
        GRIDDOUBLECLICK = False
        TabControl1.SelectedIndex = 0
        getmaxno()
        If ALLOWMANUALRECNO = True Then
            TXTRECONO.ReadOnly = False
            TXTRECONO.BackColor = Color.LemonChiffon
        Else
            TXTRECONO.ReadOnly = True
            TXTRECONO.BackColor = Color.Linen
            TXTMTRSDIFF.Clear()
            LBLTOTALOUTQTY.Text = 0.0
            'LBLTOTALSHEETS.Text = 0.0
            LBLTOTALINQTY.Text = 0.0
            'LBLTOTALINSHEETS.Text = 0.0

        End If
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim bln As Boolean = True
            'If ALLOWADJQTYDIFF = False And Val(LBLTOTALINQTY.Text.Trim) < Val(LBLTOTALOUTQTY.Text.Trim) Then
            '    EP.SetError(TXTMTRSDIFF, " In Qty Cannot be Less than Out Qty")
            '    bln = False
            'End If
            If ALLOWMANUALRECNO = True Then
                If Val(TXTRECONO.Text.Trim) <> 0 And EDIT = False Then
                    Dim OBJCMNn As New ClsCommon
                    Dim dttable As DataTable = OBJCMNn.search(" ISNULL(STORESTOCKADJUSTMENT.SA_NO,0)  AS RECONO", "", " STORESTOCKADJUSTMENT ", "  AND STORESTOCKADJUSTMENT.SA_NO=" & Val(TXTRECONO.Text.Trim) & " AND STORESTOCKADJUSTMENT.SA_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        MsgBox("Rec No Already Exist")
                        bln = False
                    End If
                End If
            End If
            If CMBGODOWN.Text.Trim.Length = 0 Then
                EP.SetError(CMBGODOWN, " Please Fill Godown")
                bln = False
            End If



            'If GRIDSTOCK.RowCount = 0 And GRIDSTOCKIN.RowCount = 0 Then
            '    EP.SetError(TabControl1, "Fill Item Details")
            '    bln = False
            'End If
            'CHEKC BARCODE IS PRESENT IN DATABASE OR NOT

            If Not datecheck(DTRECODATE.Text) Then
                EP.SetError(DTRECODATE, "Date not in Accounting Year")
                bln = False
            End If

            'If CMBUNIT.Text = "" And CMBITEMNAME.Text = "" Then
            '    EP.SetError(TabControl1, "Fill Details Properly")
            '    bln = False
            'End If
            'If Convert.ToDateTime(DTRECODATE.Text).Date < STOCKADJBLOCKDATE.Date Then
            '    EP.SetError(DTRECODATE, "Date is Blocked, Please make entries after " & Format(STOCKADJBLOCKDATE.Date, "dd/MM/yyyy"))    UNCOMMENT AFTER ADDING BLOCKDATE
            '    bln = False
            'End If


            If Convert.ToDateTime(DTRECODATE.Text).Date < STOCKADJBLOCKDATE.Date Then
                EP.SetError(DTRECODATE, "Date is Blocked, Please make entries after " & Format(STOCKADJBLOCKDATE.Date, "dd/MM/yyyy"))
                bln = False
            End If


            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function
    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        EDIT = False
        DTRECODATE.Focus()

    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(SA_no),0) + 1 ", " STOCKADJUSTMENT ", " AND SA_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTRECONO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            If TXTRECONO.ReadOnly = False Then
                alParaval.Add(Val(TXTRECONO.Text.Trim))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Format(DTRECODATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(txtchallan.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CMBNAME.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim gridsrno As String = ""
            Dim ITEMCODE As String = ""
            Dim ITEMNAME As String = ""
            Dim QTY As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDSTOCK.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(GSRNO.Index).Value.ToString
                        ITEMCODE = row.Cells(GITEMCODE.Index).Value.ToString
                        ITEMNAME = row.Cells(GMERCHANT.Index).Value.ToString
                        QTY = row.Cells(GQTY.Index).Value.ToString

                    Else
                        gridsrno = gridsrno & "|" & row.Cells(GSRNO.Index).Value.ToString
                        ITEMCODE = ITEMCODE & "|" & row.Cells(GITEMCODE.Index).Value.ToString
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GMERCHANT.Index).Value.ToString
                        QTY = QTY & "|" & row.Cells(GQTY.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(ITEMCODE)
            alParaval.Add(ITEMNAME)
            alParaval.Add(QTY)

            Dim INGRIDSRNO As String = ""
            Dim INITEMCODE As String = ""
            Dim INITEMNAME As String = ""
            Dim INQTY As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDSTOCKIN.Rows
                If row.Cells(0).Value <> Nothing Then
                    If INGRIDSRNO = "" Then
                        INGRIDSRNO = row.Cells(ESRNO.Index).Value.ToString
                        INITEMCODE = row.Cells(EITEMCODE.Index).Value.ToString
                        INITEMNAME = row.Cells(EITEMNAME.Index).Value.ToString
                        INQTY = row.Cells(EQTY.Index).Value.ToString
                    Else
                        INGRIDSRNO = INGRIDSRNO & "|" & row.Cells(ESRNO.Index).Value.ToString
                        INITEMCODE = INITEMCODE & "|" & row.Cells(EITEMCODE.Index).Value.ToString
                        INITEMNAME = INITEMNAME & "|" & row.Cells(EITEMNAME.Index).Value.ToString
                        INQTY = INQTY & "|" & row.Cells(EQTY.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(INGRIDSRNO)
            alParaval.Add(INITEMCODE)
            alParaval.Add(INITEMNAME)
            alParaval.Add(INQTY)

            Dim objSTOCK As New ClsStockAdjustment()
            objSTOCK.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = objSTOCK.SAVE()
                MsgBox("Details Added")
                TXTRECONO.Text = DTTABLE.Rows(0).Item(0)
                TEMPRECONO = DTTABLE.Rows(0).Item(0)
                'PRINTREPORT(DTTABLE.Rows(0).Item(0))

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPRECONO)
                IntResult = objSTOCK.UPDATE()
                MsgBox("Details Updated")
                'PRINTREPORT(TEMPRECONO)
                EDIT = False
            End If


            CLEAR()
            DTRECODATE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Sub GETSRNO(ByRef grid As System.Windows.Forms.DataGridView)
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
            LBLTOTALOUTQTY.Text = 0.0
            'LBLTOTALSHEETS.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDSTOCK.Rows
                If ROW.Cells(GSRNO.Index).Value <> Nothing Then
                    LBLTOTALOUTQTY.Text = Format(Val(LBLTOTALOUTQTY.Text) + Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0.00")
                    'LBLTOTALSHEETS.Text = Format(Val(LBLTOTALSHEETS.Text) + Val(ROW.Cells(GSHEETS.Index).EditedFormattedValue), "0.00")
                End If
            Next

            For Each ROW As DataGridViewRow In GRIDSTOCKIN.Rows
                If ROW.Cells(ESRNO.Index).Value <> Nothing Then
                    LBLTOTALINQTY.Text = Format(Val(LBLTOTALINQTY.Text) + Val(ROW.Cells(EQTY.Index).EditedFormattedValue), "0.00")
                    'LBLTOTALINSHEETS.Text = Format(Val(LBLTOTALINSHEETS.Text) + Val(ROW.Cells(ESHEETS.Index).EditedFormattedValue), "0.00")
                End If
            Next
            'TXTMTRSDIFF.Text = Format(Val(LBLTOTALINQTY.Text) - Val(LBLTOTALINSHEETS.Text), "0.00")
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

    Private Sub cmbtrans_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtrans.Validating
        Try
            If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, CMBCODE, e, Me, TXTTRANSADD, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTSTOCK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTSTOCK.Click
        Try
            If CMBGODOWN.Text.Trim = "" Then
                MsgBox("Please Select Godown First", MsgBoxStyle.Critical)
                CMBGODOWN.Focus()
                Exit Sub
            End If
            Dim DTTABLE As New DataTable
            Dim OBJSELECTGDN As New SelectStock
            OBJSELECTGDN.TYPE = "MAINSTOCK"
            OBJSELECTGDN.GODOWN = CMBGODOWN.Text.Trim
            OBJSELECTGDN.ShowDialog()
            DTTABLE = OBJSELECTGDN.DT

            If DTTABLE.Rows.Count > 0 Then
                For Each dr As DataRow In DTTABLE.Rows
                    GRIDSTOCK.Rows.Add(0, dr("ITEMCODE"), dr("ITEMNAME"), Format(Val(dr("QTY")), "0.00"))
                Next
                GRIDSTOCK.FirstDisplayedScrollingRowIndex = GRIDSTOCK.RowCount - 1
                GETSRNO(GRIDSTOCK)
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)

    End Sub

    Sub FILLGRID()
        Try
            GRIDSTOCKIN.Enabled = True

            If GRIDDOUBLECLICK = False Then
                GRIDSTOCKIN.Rows.Add(Val(txtsrno.Text.Trim), CMBITEMCODE.Text.Trim, CMBITEMNAME.Text.Trim, Format(Val(TXTQTY.Text.Trim), "0.00"))
                GETSRNO(GRIDSTOCKIN)

            ElseIf GRIDDOUBLECLICK = True Then

                GRIDSTOCKIN.Item(ESRNO.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
                GRIDSTOCKIN.Item(EITEMCODE.Index, TEMPROW).Value = CMBITEMCODE.Text.Trim
                GRIDSTOCKIN.Item(EITEMNAME.Index, TEMPROW).Value = CMBITEMNAME.Text.Trim
                GRIDSTOCKIN.Item(EQTY.Index, TEMPROW).Value = Format(Val(TXTQTY.Text.Trim), "0.00")

                GRIDDOUBLECLICK = False
            End If

            TOTAL()

            GRIDSTOCKIN.FirstDisplayedScrollingRowIndex = GRIDSTOCKIN.RowCount - 1

            txtsrno.Text = GRIDSTOCKIN.RowCount + 1
            CMBITEMNAME.Text = ""
            CMBITEMCODE.Text = ""
            TXTQTY.Clear()



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDJOBIN_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSTOCKIN.CellDoubleClick
        EDITROW()
    End Sub

    Sub EDITROW()
        Try
            If GRIDSTOCKIN.CurrentRow.Index >= 0 And GRIDSTOCKIN.Item(GSRNO.Index, GRIDSTOCKIN.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                txtsrno.Text = GRIDSTOCKIN.Item(ESRNO.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                CMBITEMCODE.Text = GRIDSTOCKIN.Item(EITEMCODE.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                CMBITEMNAME.Text = GRIDSTOCKIN.Item(EITEMNAME.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                TXTQTY.Text = GRIDSTOCKIN.Item(EQTY.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString


                TEMPROW = GRIDSTOCKIN.CurrentRow.Index
                txtsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNOOFENTRIES.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTMTRS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTQTY.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub GRIDSTOCK_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDSTOCK.CellValidating
        Try
            Dim colNum As Integer = GRIDSTOCK.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GQTY.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDSTOCK.CurrentCell.Value = Nothing Then GRIDSTOCK.CurrentCell.Value = "0.00"
                        GRIDSTOCK.CurrentCell.Value = Convert.ToDecimal(GRIDSTOCK.Item(colNum, e.RowIndex).Value)
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

    Private Sub GRIDSTOCK_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSTOCK.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSTOCK.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDSTOCK.Rows.RemoveAt(GRIDSTOCK.CurrentRow.Index)
                GETSRNO(GRIDSTOCK)
                TOTAL()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then
                If MsgBox("Wish to Delete Stock Adjustment?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim ALPARAVAL As New ArrayList
                Dim OBSTOCK As New ClsStockAdjustment

                ALPARAVAL.Add(TEMPRECONO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Userid)
                ALPARAVAL.Add(YearId)
                OBSTOCK.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBSTOCK.DELETE()
                MsgBox("Stock Adjustment Deleted Succesfully")
                CLEAR()
                EDIT = False
                DTRECODATE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDJOBIN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSTOCKIN.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSTOCKIN.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'end of block
                GRIDSTOCKIN.Rows.RemoveAt(GRIDSTOCKIN.CurrentRow.Index)
                GETSRNO(GRIDSTOCKIN)
                TOTAL()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Sub CALC()
        'Try
        '    If Val(TXTQTY.Text.Trim) > 0 And Val(TXTQTY.Text.Trim) > 0 Then TXTMTRS.Text = Format(Val(TXTQTY.Text.Trim) * Val(TXTQTY.Text.Trim), "0.00")
        '    If CMBPER.Text = "Mtrs" Then TXTAMOUNT.Text = Format(Val(TXTRATE.Text.Trim) * Val(TXTMTRS.Text.Trim), "0.00") Else TXTAMOUNT.Text = Format(Val(TXTRATE.Text.Trim) * Val(TXTQTY.Text.Trim), "0.00")
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub txtremarks_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtremarks.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJREMARKS As New SelectRemarks
                OBJREMARKS.FRMSTRING = "NARRATION"
                OBJREMARKS.ShowDialog()
                If OBJREMARKS.TEMPNAME <> "" Then txtremarks.Text = OBJREMARKS.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockReco_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        TXTQTY.ReadOnly = False
    End Sub
    Private Sub tstxtbillno_KeyPress(sender As Object, e As KeyPressEventArgs)
        numkeypress(e, sender, Me)
    End Sub
    Private Sub CMBNAME_Enter(sender As Object, e As EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " AND (GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' OR GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS') AND LEDGERS.ACC_TYPE='ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTTRANSADD, " AND (GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' OR GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS') AND LEDGERS.ACC_TYPE='ACCOUNTS'", "", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub toolprevious_Click(sender As Object, e As EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDSTOCK.RowCount = 0
            GRIDSTOCKIN.RowCount = 0
LINE1:
            TEMPRECONO = Val(TXTRECONO.Text) - 1
            If TEMPRECONO > 0 Then
                EDIT = True
                StockReco_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDSTOCK.RowCount = 0 And GRIDSTOCKIN.RowCount = 0 And TEMPRECONO > 1 Then
                TXTRECONO.Text = TEMPRECONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(sender As Object, e As EventArgs) Handles toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
LINE1:
            TEMPRECONO = Val(TXTRECONO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTRECONO.Text.Trim
            CLEAR()
            If Val(TXTRECONO.Text) - 1 >= TEMPRECONO Then
                EDIT = True
                StockReco_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDSTOCK.RowCount = 0 And GRIDSTOCKIN.RowCount = 0 And TEMPRECONO < MAXNO Then
                TXTRECONO.Text = TEMPRECONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTRECONO_Validating(sender As Object, e As CancelEventArgs) Handles TXTRECONO.Validating
        Try
            If Val(TXTRECONO.Text.Trim) <> 0 And EDIT = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(STORESTOCKADJUSTMENT.SA_NO,0)  AS RECONO", "", " STORESTOCKADJUSTMENT ", "  AND STORESTOCKADJUSTMENT.SA_NO=" & Val(TXTRECONO.Text.Trim) & " AND STORESTOCKADJUSTMENT.SA_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Rec No Already Exist")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRECONO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTRECONO.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub GRIDSTOCKIN_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GRIDSTOCKIN.CellValidating
        Try
            Dim colNum As Integer = GRIDSTOCKIN.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case EQTY.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDSTOCKIN.CurrentCell.Value = Nothing Then GRIDSTOCKIN.CurrentCell.Value = "0.00"
                        GRIDSTOCKIN.CurrentCell.Value = Convert.ToDecimal(GRIDSTOCKIN.Item(colNum, e.RowIndex).Value)
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

    Private Sub OpenToolStripButton_Click(sender As Object, e As EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim OBJstock As New StockRecoDetails
            OBJstock.MdiParent = MDIMain
            OBJstock.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Enter(sender As Object, e As EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillITEMNAME(CMBITEMNAME, EDIT, " and ITEMMASTER.ITEM_MATERIALTYPE = 'FINISHED'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then ITEMNAMEVALIDATE(CMBITEMNAME, e, Me, " and ITEMMASTER.ITEM_MATERIALTYPE = 'FINISHED'")

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub



    Private Sub CMBITEMCODE_Validating(sender As Object, e As CancelEventArgs) Handles CMBITEMCODE.Validating
        Try
            If CMBITEMCODE.Text.Trim <> "" Then ITEMCODEvalidate(CMBITEMCODE, CMBITEMNAME, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBITEMCODE_Enter(sender As Object, e As EventArgs) Handles CMBITEMCODE.Enter
        Try
            If CMBITEMCODE.Text.Trim = "" Then fillITEMCODE(CMBITEMCODE, EDIT, " and ITEMMASTER.ITEM_MATERIALTYPE = 'FINISHED'")

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTQTY_Validated(sender As Object, e As EventArgs) Handles TXTQTY.Validated
        If CMBITEMCODE.Text.Trim <> "" And CMBITEMNAME.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 Then
            FILLGRID()
        End If

    End Sub

    Private Sub tstxtbillno_Validated(sender As Object, e As EventArgs) Handles tstxtbillno.Validated
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDSTOCK.RowCount = 0
                GRIDSTOCKIN.RowCount = 0
                TEMPRECONO = Val(tstxtbillno.Text)
                If TEMPRECONO > 0 Then
                    EDIT = True
                    StockReco_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    'Private Sub txtchallan_Validating(sender As Object, e As CancelEventArgs) Handles txtchallan.Validating
    '    Try
    '        If txtchallan.Text.Trim.Length > 0 Then
    '            ' If (EDIT = False) Or (EDIT = True And LCase(PARTYCHALLANNO) <> LCase(txtchallan.Text.Trim)) Then
    '            'for search
    '            Dim objclscommon As New ClsCommon()
    '                Dim dt As New DataTable
    '            dt = objclscommon.search(" ISNULL(STORESTOCKADJUSTMENT.SA_CHALLANNO, '') AS CHALLANNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME", "", " STORESTOCKADJUSTMENT INNER JOIN LEDGERS ON STORESTOCKADJUSTMENT.SA_LEDGERID = LEDGERS.Acc_id AND STORESTOCKADJUSTMENT.SA_yearid = LEDGERS.Acc_yearid AND STORESTOCKADJUSTMENT.SA_cmpid = LEDGERS.Acc_cmpid ", " and STORESTOCKADJUSTMENT.SA_CHALLANNO = '" & txtchallan.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & CMBNAME.Text.Trim & "' AND STORESTOCKADJUSTMENT_CMPID =" & CmpId & " AND STORESTOCKADJUSTMENT_LOCATIONID =" & Locationid & " AND STORESTOCKADJUSTMENT_YEARID =" & YearId)
    '            If dt.Rows.Count > 0 Then
    '                MsgBox("Challan No. Already Exists", MsgBoxStyle.Critical, "PRINTPRO")
    '                e.Cancel = True
    '                End If
    '            End If
    '        '  End If
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub
End Class