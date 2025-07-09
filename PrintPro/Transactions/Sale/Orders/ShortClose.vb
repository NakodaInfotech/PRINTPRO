Imports System.Windows.Forms
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class ShortClose

    Public DT As New DataTable
    Dim tempindex, i As Integer
    'Dim col As New DataGridViewCheckBoxColumn  'Dim dt As New DataTable
    Public TEMPORERNO As Integer
    Dim SALEREGID As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub ShortClose_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ShortClose_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DTROW() As DataRow
        DTROW = USERRIGHTS.Select("FormName = 'SALE INVOICE'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)
        FILLGRID()
    End Sub

    Sub FILLGRID()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim objcmn As New ClsCommon
            Dim dt As DataTable
            dt = objcmn.search(" ISNULL(ORDERMASTER.ORDER_NO,0) AS ORDERNO, ORDERMASTER.ORDER_PONO AS PONO, ORDERMASTER.ORDER_DTPICKER AS DATE, ISNULL(itemmaster.item_code, '') AS ITEMCODE, ISNULL(ORDERMASTER_DESC.ORDER_QTY - ORDERMASTER_DESC.ORDER_OUTQTY, 0) AS QUANTITY,ISNULL(ORDERMASTER_DESC.ORDER_GRIDSRNO,0) AS ORDERSRNO,ISNULL(ORDERMASTER_DESC.ORDER_CLOSE,0) AS CHK", "", "ORDERMASTER INNER JOIN ORDERMASTER_DESC ON ORDERMASTER.ORDER_NO = ORDERMASTER_DESC.ORDER_NO AND ORDERMASTER.ORDER_YEARID = ORDERMASTER_DESC.ORDER_YEARID INNER JOIN LEDGERS ON ORDERMASTER.ORDER_LEDGERID = LEDGERS.Acc_id AND ORDERMASTER.ORDER_YEARID = LEDGERS.Acc_yearid INNER JOIN itemmaster ON ORDERMASTER_DESC.ORDER_ITEMID = itemmaster.item_id AND ORDERMASTER_DESC.ORDER_YEARID = itemmaster.item_yearid", "and ISNULL(ORDERMASTER_DESC.ORDER_QTY - ORDERMASTER_DESC.ORDER_OUTQTY, 0)>0 AND ISNULL(ORDERMASTER_DESC.ORDER_CLOSE, 0) = 0 and ORDERMASTER.order_YEARID=" & YearId & " ORDER BY ORDERMASTER.ORDER_NO ")

            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub SHOWFORM(ByVal EDITVAL As Boolean, ByVal ORDERNO As Integer)
        Try
            If (EDITVAL = True And USEREDIT = False And USERVIEW = False) Or (EDITVAL = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (EDITVAL = False) Or (EDITVAL = True And gridbill.RowCount > 0) Then
                Dim OBJORDER As New Order
                OBJORDER.MdiParent = MDIMain
                OBJORDER.edit = EDITVAL
                OBJORDER.tempsono = ORDERNO
                OBJORDER.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            SHOWFORM(True, gridbill.GetFocusedRowCellValue("ORDERNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub gridbill_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
    '    Try
    '        If e.RowHandle >= 0 Then
    '            Dim View As GridView = sender
    '            If View.GetRowCellDisplayText(e.RowHandle, View.Columns("CHK")) = "Checked" Then
    '                e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
    '                e.Appearance.BackColor = Color.Orange
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub gridbill_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gridbill.CellValueChanged
    '    If IsDBNull(e.Value) = True Then Exit Sub
    '    Dim ROW As DataRow = gridbill.GetFocusedDataRow
    '    Dim OBJCMN As New ClsCommon
    '    Dim DT As New DataTable
    '    On Error Resume Next
    '    If ROW("CHK") = True Then
    '        DT = OBJCMN.Execute_Any_String("UPDATE ORDERMASTER_DESC SET ORDER_CLOSE = 1 WHERE INVOICE_YEARID = " & YearId, "", "")
    '        FILLGRID()
    '    Else
    '        DT = OBJCMN.Execute_Any_String("UPDATE ORDERMASTER_DESC SET ORDER_CLOSE = 0 WHERE INVOICE_YEARID = " & YearId, "", "")
    '        FILLGRID()
    '    End If
    'End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Dim OBJCMN As New ClsCommon

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT = OBJCMN.Execute_Any_String("UPDATE ORDERMASTER_DESC SET ORDER_CLOSE =1 WHERE ORDER_NO =  " & Val(dtrow("ORDERNO")) & "  AND ORDER_GRIDSRNO = " & Val(dtrow("ORDERSRNO")) & " AND ORDER_YEARID = " & YearId, "", "")
                Else
                    DT = OBJCMN.Execute_Any_String("UPDATE ORDERMASTER_DESC SET ORDER_CLOSE =0 WHERE ORDER_NO =  " & Val(dtrow("ORDERNO")) & "  AND ORDER_GRIDSRNO = " & Val(dtrow("ORDERSRNO")) & " AND ORDER_YEARID = " & YearId, "", "")
                End If
            Next
            FILLGRID()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class