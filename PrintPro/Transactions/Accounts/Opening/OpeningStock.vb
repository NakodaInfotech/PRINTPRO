
Imports BL
Imports System.Windows.Forms
Imports System.IO
Imports System.Diagnostics

Public Class OpeningStock
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim temprow As Integer
    Dim CLEAR As Boolean = False
    Public edit As Boolean
    Public tempMsg As Integer
    Public FRMSTRING As String

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function ERRORVALIDE() As Boolean

        Dim bln As Boolean = True

        If GRIDSTOCK.RowCount = 0 Then
            Ep.SetError(TXTQTY, "Enter Item Details")
            bln = False
        End If

        For Each row As DataGridViewRow In GRIDSTOCK.Rows
            If row.Cells(GQty.Index).Value = "" Then
                Ep.SetError(TXTQTY, "Quantity cannot be Blank")
                bln = False
            End If

            If row.Cells(GGODOWM.Index).Value = "" Then
                Ep.SetError(CMBGODOWN, "Godown cannot be Blank")
                bln = False
            End If

            If row.Cells(GITEMNAME.Index).Value = "" Then
                Ep.SetError(CMBiTEMNAME, "Item Name cannot be Blank")
                bln = False
            End If

            If row.Cells(GSHELF.Index).Value = "" Then
                Ep.SetError(CMBSHELF, "Shelf Name cannot be Blank")
                bln = False
            End If
        Next
        Return bln
    End Function

    Sub EDITROW()
        Try
            If GRIDSTOCK.CurrentRow.Index >= 0 And GRIDSTOCK.Item(gsrno.Index, GRIDSTOCK.CurrentRow.Index).Value <> Nothing Then


                ' If Convert.ToBoolean(gridstock.Rows(gridstock.CurrentRow.Index).Cells(gdone.Index).Value) = True Then 'If row.Cells(16).Value <> "0" Then 

                'If Convert.ToString(gridstock.Rows(gridstock.CurrentRow.Index).Cells(gdone.Index).Value) = True Then 'If row.Cells(16).Value <> "0" Then 
                '    MsgBox("Item Locked", MsgBoxStyle.Critical)
                '    Exit Sub
                'End If

                gridDoubleClick = True

                TXTSRNO.Text = GRIDSTOCK.Item(gsrno.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                TXTNO.Text = GRIDSTOCK.Item(GNO.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                CMBPARTYNAME.Text = GRIDSTOCK.Item(GPARTYNAME.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                CMBGODOWN.Text = GRIDSTOCK.Item(GGODOWM.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                CMBSHELF.Text = GRIDSTOCK.Item(GSHELF.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                CMBiTEMNAME.Text = GRIDSTOCK.Item(GITEMNAME.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                TXTSIZE.Text = GRIDSTOCK.Item(GSIZE.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                TXTWT.Text = GRIDSTOCK.Item(GWT.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                TXTPPRSRNO.Text = GRIDSTOCK.Item(GPPRSRNO.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                TXTBATCHNO.Text = GRIDSTOCK.Item(GBATCHNO.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                CMBUNIT.Text = GRIDSTOCK.Item(gUNIT.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                TXTQTY.Text = GRIDSTOCK.Item(GQty.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                CMBTYPE.Text = GRIDSTOCK.Item(GTYPE.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                TXTOUTQTY.Text = GRIDSTOCK.Item(GOUTQTY.Index, GRIDSTOCK.CurrentRow.Index).Value
                TXTRATE.Text = GRIDSTOCK.Item(GRATE.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                TXTAMOUNT.Text = GRIDSTOCK.Item(GAMOUNT.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString

                temprow = GRIDSTOCK.CurrentRow.Index
                TXTSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Sub FILLCMB()
        If CMBPARTYNAME.Text.Trim = "" Then fillname(CMBPARTYNAME, edit, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        If CMBiTEMNAME.Text.Trim = "" Then FILLNONINVITEM(CMBiTEMNAME, edit)
        If CMBSHELF.Text.Trim = "" Then fillSHELF(CMBSHELF, edit)
        If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
        If CMBUNIT.Text.Trim = "" Then fillUNIT(CMBUNIT)
    End Sub

    Private Sub CMBiTEMNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBiTEMNAME.Enter
        Try
            If CMBiTEMNAME.Text.Trim = "" Then FILLNONINVITEM(CMBiTEMNAME, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBiTEMNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBiTEMNAME.Validating
        Try
            If CMBiTEMNAME.Text.Trim <> "" Then NONINVITEMVALIDATE(CMBiTEMNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHELF_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSHELF.Validating
        Try
            If CMBSHELF.Text.Trim <> "" Then SHELFVALIDATE(CMBSHELF, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHELF_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBSHELF.Enter
        Try
            If CMBSHELF.Text.Trim = "" Then fillSHELF(CMBSHELF, edit)
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

    Private Sub CMBGODOWN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUNIT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBUNIT.Validating
        Try
            If CMBUNIT.Text.Trim <> "" Then unitvalidate(CMBUNIT, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUNIT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBUNIT.Enter
        Try
            If CMBUNIT.Text.Trim = "" Then fillUNIT(CMBUNIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridstock_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSTOCK.CellDoubleClick
        EDITROW()
    End Sub

    Sub fillgrid()

        GRIDSTOCK.Enabled = True

        If gridDoubleClick = False Then
            GRIDSTOCK.Rows.Add(Val(TXTSRNO.Text.Trim), Val(TXTNO.Text.Trim), CMBPARTYNAME.Text.Trim, CMBGODOWN.Text.Trim, CMBSHELF.Text.Trim, CMBiTEMNAME.Text.Trim, TXTSIZE.Text.Trim, Format(Val(TXTWT.Text.Trim), "0.00"), Val(TXTPPRSRNO.Text.Trim), TXTBATCHNO.Text.Trim, CMBUNIT.Text.Trim, Format(Val(TXTQTY.Text.Trim), "0.00"), CMBTYPE.Text.Trim, 0, Format(Val(TXTRATE.Text.Trim), "0.00"), Format(Val(TXTAMOUNT.Text.Trim), "0.00"))
            getsrno(GRIDSTOCK)
            GRIDSTOCK.FirstDisplayedScrollingRowIndex = GRIDSTOCK.RowCount - 1
        ElseIf gridDoubleClick = True Then
            GRIDSTOCK.Item(gsrno.Index, temprow).Value = Val(TXTSRNO.Text.Trim)
            GRIDSTOCK.Item(GPARTYNAME.Index, temprow).Value = CMBPARTYNAME.Text.Trim
            GRIDSTOCK.Item(GGODOWM.Index, temprow).Value = CMBGODOWN.Text.Trim
            GRIDSTOCK.Item(GSHELF.Index, temprow).Value = CMBSHELF.Text.Trim
            GRIDSTOCK.Item(GITEMNAME.Index, temprow).Value = CMBiTEMNAME.Text.Trim
            GRIDSTOCK.Item(GSIZE.Index, temprow).Value = TXTSIZE.Text.Trim
            GRIDSTOCK.Item(GWT.Index, temprow).Value = Format(Val(TXTWT.Text.Trim), "0.00")
            GRIDSTOCK.Item(GPPRSRNO.Index, temprow).Value = Val(TXTPPRSRNO.Text.Trim)
            GRIDSTOCK.Item(GBATCHNO.Index, temprow).Value = TXTBATCHNO.Text.Trim
            GRIDSTOCK.Item(gUNIT.Index, temprow).Value = CMBUNIT.Text.Trim
            GRIDSTOCK.Item(GQty.Index, temprow).Value = Format(Val(TXTQTY.Text.Trim), "0.00")
            GRIDSTOCK.Item(GTYPE.Index, temprow).Value = CMBTYPE.Text.Trim
            GRIDSTOCK.Item(GOUTQTY.Index, temprow).Value = Val(TXTOUTQTY.Text.Trim)
            GRIDSTOCK.Item(GRATE.Index, temprow).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
            GRIDSTOCK.Item(GAMOUNT.Index, temprow).Value = Format(Val(TXTAMOUNT.Text.Trim), "0.00")

            gridDoubleClick = False
        End If

        'gridstock.FirstDisplayedScrollingRowIndex = gridstock.RowCount - 1
        If CLEAR = True Then
            CMBGODOWN.Text = ""
            CMBPARTYNAME.Text = ""
            CMBiTEMNAME.Text = ""
            CMBUNIT.Text = ""
            CMBSHELF.Text = ""
            CMBTYPE.SelectedIndex = 0
            TXTPPRSRNO.Clear()
            TXTBATCHNO.Clear()
            TXTQTY.Clear()
            TXTSIZE.Clear()
            TXTWT.Clear()
            TXTRATE.Clear()
            TXTAMOUNT.Clear()
            TXTOUTQTY.Clear()
        End If
        TXTSRNO.Text = GRIDSTOCK.RowCount + 1
        TXTSRNO.Focus()

    End Sub

    Private Sub OpeningStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'OPENING'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCMB()
            'TXTSRNO.Focus()
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJCMN As New ClsCommon
            Dim dttable As DataTable = OBJCMN.search("ISNULL(STOCKMASTER.SM_NO, 0) AS SMNO, ISNULL(STOCKMASTER.SM_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(SHELFMASTER.SHELF_name, '') AS SHELF, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME, ISNULL(STOCKMASTER.SM_SIZE, '') AS SIZE, ISNULL(STOCKMASTER.SM_WT, 0) AS WT, ISNULL(STOCKMASTER.SM_PPRSRNO, 0) AS PPRSRNO, ISNULL(STOCKMASTER.SM_BATCHNO, '') AS BATCHNO, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(STOCKMASTER.SM_QTY, 0) AS QTY,ISNULL(STOCKMASTER.SM_TYPE, '') AS TYPE, ISNULL(STOCKMASTER.SM_OUTQTY, 0) AS OUTQTY, ISNULL(STOCKMASTER.SM_RATE, 0) AS RATE, ISNULL(STOCKMASTER.SM_AMOUNT, 0) AS AMOUNT  ", "", "STOCKMASTER LEFT OUTER JOIN LEDGERS ON STOCKMASTER.SM_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN GODOWNMASTER ON STOCKMASTER.SM_GODOWNID = GODOWNMASTER.GODOWN_id INNER JOIN NONINVITEMMASTER ON STOCKMASTER.SM_ITEMID = NONINVITEMMASTER.NONINV_ID LEFT OUTER JOIN UNITMASTER ON STOCKMASTER.SM_UNITID = UNITMASTER.unit_id LEFT OUTER JOIN SHELFMASTER ON STOCKMASTER.SM_SHELFID = SHELFMASTER.SHELF_id ", " AND STOCKMASTER.SM_YEARID = " & YearId & " ORDER BY SM_NO")
            If dttable.Rows.Count > 0 Then
                For Each DR As DataRow In dttable.Rows
                    GRIDSTOCK.Rows.Add(DR("GRIDSRNO"), DR("SMNO"), DR("NAME"), DR("GODOWN"), DR("SHELF"), DR("ITEMNAME"), DR("SIZE"), Format(DR("WT"), "0.00"), DR("PPRSRNO"), DR("BATCHNO"), DR("UNIT"), Format(DR("QTY"), "0.00"), DR("TYPE"), DR("OUTQTY"), Format(DR("RATE"), "0.00"), Format(DR("AMOUNT"), "0.00"))
                Next
                GRIDSTOCK.FirstDisplayedScrollingRowIndex = GRIDSTOCK.RowCount - 1
            End If

            If GRIDSTOCK.RowCount > 0 Then
                TXTSRNO.Text = Val(GRIDSTOCK.Rows(GRIDSTOCK.RowCount - 1).Cells(0).Value) + 1
            Else
                TXTSRNO.Text = 1
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub SAVE()
        Try
            Dim ALPARAVAL As New ArrayList
            Dim OBJSM As New ClsStockMaster

            ALPARAVAL.Add(OPENINGDATE.Value)
            ALPARAVAL.Add(TXTSRNO.Text.Trim)
            ALPARAVAL.Add(CMBPARTYNAME.Text.Trim)
            ALPARAVAL.Add(CMBGODOWN.Text.Trim)
            ALPARAVAL.Add(CMBSHELF.Text.Trim)
            ALPARAVAL.Add(CMBiTEMNAME.Text.Trim)
            ALPARAVAL.Add(TXTSIZE.Text.Trim)
            ALPARAVAL.Add(Val(TXTWT.Text.Trim))
            ALPARAVAL.Add(Val(TXTPPRSRNO.Text.Trim))
            ALPARAVAL.Add(TXTBATCHNO.Text.Trim)
            ALPARAVAL.Add(CMBUNIT.Text.Trim)
            ALPARAVAL.Add(Val(TXTQTY.Text.Trim))
            ALPARAVAL.Add(CMBTYPE.Text.Trim)
            ALPARAVAL.Add(Val(TXTOUTQTY.Text.Trim))

            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)
            ALPARAVAL.Add(0)
            ALPARAVAL.Add(Val(TXTRATE.Text.Trim))
            ALPARAVAL.Add(Val(TXTAMOUNT.Text.Trim))

            OBJSM.alParaval = ALPARAVAL
            If gridDoubleClick = False Then
                Dim DT As DataTable = OBJSM.SAVE()
                If DT.Rows.Count > 0 Then TXTNO.Text = DT.Rows(0).Item(0)
            Else
                ALPARAVAL.Add(TXTNO.Text.Trim)
                Dim INTRES As Integer = OBJSM.UPDATE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridstock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSTOCK.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSTOCK.RowCount > 0 Then
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'If Val(gridstock.Rows(gridstock.CurrentRow.Index).Cells(gOutpcs.Index).Value) > 0 Then
                '    MessageBox.Show("Row Locked, You Cannot Delete This Row")
                '    Exit Sub
                'End If

                Dim TEMPMSG As Integer = MsgBox("Wish To Delete?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                'DELETE FROM STOCKMASTER
                Dim OBJSM As New ClsStockMaster
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(GRIDSTOCK.Rows(GRIDSTOCK.CurrentRow.Index).Cells(GNO.Index).Value)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJSM.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJSM.DELETE()

                GRIDSTOCK.Rows.RemoveAt(GRIDSTOCK.CurrentRow.Index)
                getsrno(GRIDSTOCK)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPARTYNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPARTYNAME.Enter
        Try
            If CMBPARTYNAME.Text.Trim = "" Then fillname(CMBPARTYNAME, edit, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS' ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPARTYNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPARTYNAME.Validating
        Try
            If CMBPARTYNAME.Text.Trim <> "" Then namevalidate(CMBPARTYNAME, CMBACCCODE, e, Me, TXTADD, "AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTQTY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTQTY.Validating
        Try
            If LCase(CMBUNIT.Text.Trim) = "reams" Then
                'get SIZE AND GSM FROM NONINV MASTER AND CALC WT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(NONINV_LENGTH,0) AS LENGTH, ISNULL(NONINV_WIDTH,0) AS WIDTH, ISNULL(NONINV_GSM,0) AS GSM ", "", " NONINVITEMMASTER ", " AND NONINV_NAME = '" & CMBiTEMNAME.Text.Trim & "' AND NONINV_YEARID = " & YearId)
                If Val(DT.Rows(0).Item("LENGTH")) > 0 And Val(DT.Rows(0).Item("WIDTH")) > 0 And Val(DT.Rows(0).Item("GSM")) > 0 Then
                    TXTWT.Text = Format(((((Val(DT.Rows(0).Item("LENGTH")) * Val(DT.Rows(0).Item("WIDTH")) * Val(DT.Rows(0).Item("GSM"))) / 3100) / 500) * Val(TXTSHEETSPERREAM.Text.Trim)) * (Val(TXTQTY.Text.Trim)), "0.000")
                End If
            ElseIf LCase(CMBUNIT.Text.Trim) = "kgs" Then
                'get SIZE AND GSM FROM NONINV MASTER AND CALC WT
                Dim OBJCM As New ClsCommon
                Dim DT1 As DataTable = OBJCM.search("ISNULL(NONINV_LENGTH,0) AS LENGTH, ISNULL(NONINV_WIDTH,0) AS WIDTH, ISNULL(NONINV_GSM,0) AS GSM ", "", " NONINVITEMMASTER ", " AND NONINV_NAME = '" & CMBiTEMNAME.Text.Trim & "' AND NONINV_YEARID = " & YearId)
                If Val(DT1.Rows(0).Item("LENGTH")) > 0 And Val(DT1.Rows(0).Item("WIDTH")) > 0 And Val(DT1.Rows(0).Item("GSM")) > 0 Then
                    TXTWT.Text = Format((((Val(DT1.Rows(0).Item("LENGTH")) * Val(DT1.Rows(0).Item("WIDTH")) * Val(DT1.Rows(0).Item("GSM")) * Val(TXTQTY.Text.Trim)) / 3100) / 500), "0.000")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpeningStock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTWT.KeyPress
        Try
            numdot(e, TXTWT, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTQTY_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTQTY.KeyPress
        Try
            numdot(e, TXTQTY, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAMOUNT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTAMOUNT.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" And CMBiTEMNAME.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 And CMBTYPE.Text.Trim <> "" Then
                SAVE()
                CLEAR = True
                fillgrid()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_Validated(sender As Object, e As EventArgs) Handles TXTRATE.Validated
        Try
            TXTAMOUNT.Text = Val(TXTRATE.Text.Trim) * Val(TXTQTY.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TXTAMOUNT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTAMOUNT.KeyPress, TXTRATE.KeyPress
        numdot(e, TXTAMOUNT, Me)
    End Sub
End Class