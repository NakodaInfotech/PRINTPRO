
Imports BL
Imports System.Windows.Forms

Public Class MRP

    Public edit As Boolean
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT


    Private Sub CMBITEMNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillITEMNAME(CMBITEMNAME, edit)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Validated
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT1 As New DataTable
            DT1 = OBJCMN.search(" ISNULL(item_actualsizewidth, '') AS WIDTH, ISNULL(item_actualsizeheight, '') AS HT, ISNULL(item_ups, 0) AS UPS ", "", " ITEMMASTER ", " AND ITEMMASTER.ITEM_YEARID = " & YearId & "AND ITEMMASTER.ITEM_NAME = '" & CMBITEMNAME.Text.Trim & "'" & "AND ITEMMASTER.ITEM_CODE = '" & CMBITEMCODE.Text.Trim & "'")
            If DT1.Rows.Count > 0 Then

                TXTHT.Text = DT1.Rows(0).Item("HT")
                TXTWIDTH.Text = DT1.Rows(0).Item("WIDTH")
                TXTNOOFUPS.Text = DT1.Rows(0).Item("UPS")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try

            If CMBITEMNAME.Text.Trim <> "" Then ITEMNAMEVALIDATE(CMBITEMNAME, e, Me)

     
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTBATCH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTBATCH.Click
        Try
            'If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
            '    MsgBox("Insufficient Rights")
            '    Exit Sub
            'End If
            Cursor.Current = Cursors.WaitCursor
            Dim OBJSELECTBACTH As New SelectBatch
            OBJSELECTBACTH.ShowDialog()

            Dim ORDERDT As DataTable = OBJSELECTBACTH.DT
            If ORDERDT.Rows.Count > 0 Then

                Dim objcmn As New ClsCommon

                For Each ROW As DataRow In ORDERDT.Rows
                    Dim dt As DataTable = objcmn.search("BATCHMASTER.jobbatch_no AS BATCHNO, ISNULL(BATCHMASTER.jobbatch_docketno, 0) AS JOBDOCKETNO, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(jobbatch_qty,0) AS QTY, ISNULL(jobbatch_percentage,0) AS PERCENTAGE", "", "BATCHMASTER INNER JOIN ITEMMASTER ON BATCHMASTER.jobbatch_yearid = ITEMMASTER.item_yearid AND BATCHMASTER.jobbatch_itemid = ITEMMASTER.item_id", " AND BATCHMASTER.jobbatch_docketno = " & Val(ROW(0)) & " AND BATCHMASTER.jobbatch_no = " & Val(ROW(1)) & " AND BATCHMASTER.JOBBATCH_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        TXTBATCHNO.Text = dt.Rows(0).Item("BATCHNO")
                        TXTLEAFLETS.Text = dt.Rows(0).Item("QTY")
                        TXTPERCENTAGE.Text = dt.Rows(0).Item("PERCENTAGE")
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

    Private Sub CMDSELECTSTOCK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTSTOCK.Click
        Try
            'If CMBGODOWN.Text.Trim = "" And gridCONSUME.RowCount = 0 Then
            '    MsgBox("Please Select Godown First", MsgBoxStyle.Critical)
            '    CMBGODOWN.Focus()
            '    Exit Sub
            'End If

            Dim DTTABLE As New DataTable
            Dim OBJSELECTGDN As New SelectStock
            'OBJSELECTGDN.GODOWN = CMBGODOWN.Text.Trim
            OBJSELECTGDN.TYPE = "CONSUMPTION"
            OBJSELECTGDN.ShowDialog()
            DTTABLE = OBJSELECTGDN.DT

            If DTTABLE.Rows.Count > 0 Then
             

                TXTPAPER.Text = DTTABLE.Rows(0).Item("ITEMNAME")

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNOOFUPS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTNOOFUPS.Validating
        Try
            'Dim OBJCMN As New ClsCommon
            'Dim DTT As DataTable = OBJCMN.search(" ISNULL(JOBBATCHMASTER.job_qty, 0) AS QTY ", "", " JOBBATCHMASTER ", "AND JOBBATCHMASTER.JOB_NO = '" & TXTJOBDOCKETNO.Text.Trim & "' AND JOB_YEARID = " & YearId)
            'If DTT.Rows.Count > 0 Then
            '    If Val(txtqty.Text.Trim) > Val(DTT.Rows(0).Item("QTY")) Then
            '        MsgBox("Total Qty does not match with Order Qty?")
            '        e.Cancel = True
            '    End If
            'End If
            ' txttotalsheets.Text = Format((Val(Val(txtqty.Text) * Val(TXTPERCENTAGE.Text)) / 100 + Val(txtqty.Text)) / Val(txtups.Text), "0")
            TOTOLSHEET()
            TXTSHEETS.Text = Val(TXTSHEETS.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTOLSHEET()
        TXTSHEETS.Text = Format((Val(Val(TXTLEAFLETS.Text) * Val(TXTPERCENTAGE.Text)) / 100 + Val(TXTLEAFLETS.Text)) / Val(TXTNOOFUPS.Text), "0")
    End Sub

    Private Sub cmbitemcode_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITEMCODE.Enter
        Try
            If CMBITEMCODE.Text.Trim = "" Then fillITEMCODE(CMBITEMCODE, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemcode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMCODE.Validating
        Try
            If CMBITEMCODE.Text.Trim <> "" Then ITEMCODEvalidate(CMBITEMCODE, CMBITEMNAME, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


End Class