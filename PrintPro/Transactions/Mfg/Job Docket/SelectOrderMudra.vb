
Imports System.Windows.Forms
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class SelectOrderMudra

    Dim addcol As Integer = 0
    Public DT As New DataTable
    Dim N As Integer = 0
    Dim tempindex, i As Integer
    Dim col As New DataGridViewCheckBoxColumn  'Dim dt As New DataTable
    Public ENQname As String = ""  'for whereclause in fillgrid
    Public TEMPORNO As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectOrderMudra_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectOrderMudra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillgrid()
    End Sub

    Sub fillgrid()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim objcmn As New ClsCommon
            Dim dt As DataTable
            dt = objcmn.search(" CAST(0 AS BIT) AS CHK, ORDERMASTER.ORDER_NO AS ORDERNO, ORDERMASTER_DESC.ORDER_GRIDSRNO AS ORDERSRNO, ISNULL(ORDERMASTER.ORDER_PONO, '') AS PONO, ORDERMASTER.ORDER_PODATE AS PODATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(SHIPTOLEDGERS.Acc_cmpname, '') AS SHIPTO, ISNULL(ITEMMASTER.item_name, '') AS MAINITEMNAME,   ISNULL(ORDERMASTER_DESC.ORDER_QTY, 0) AS QTY, ISNULL(ITEMMASTER_1.item_code, '') AS ITEMNAME", "", "  LEDGERS RIGHT OUTER JOIN LEDGERS AS SHIPTOLEDGERS RIGHT OUTER JOIN ORDERMASTER INNER JOIN ORDERMASTER_DESC ON ORDERMASTER.ORDER_YEARID = ORDERMASTER_DESC.ORDER_YEARID AND ORDERMASTER.ORDER_NO = ORDERMASTER_DESC.ORDER_NO LEFT OUTER JOIN ITEMMASTER_BOMDETAILS RIGHT OUTER JOIN ITEMMASTER ON ITEMMASTER_BOMDETAILS.ITEM_ID = ITEMMASTER.item_id LEFT OUTER JOIN ITEMMASTER AS ITEMMASTER_1 ON ITEMMASTER_BOMDETAILS.ITEM_SUBITEMID = ITEMMASTER_1.item_id ON ORDERMASTER_DESC.ORDER_ITEMID = ITEMMASTER.item_id ON  SHIPTOLEDGERS.Acc_id = ORDERMASTER.ORDER_SHIPTOID ON LEDGERS.Acc_id = ORDERMASTER.ORDER_LEDGERID ", "and ISNULL(ORDERMASTER_DESC.ORDER_QTY - ORDERMASTER_DESC.ORDER_OUTQTY, 0)>0 AND ISNULL(ORDERMASTER_DESC.ORDER_CLOSE,0)=0 and ORDERMASTER.order_YEARID=" & YearId & " ORDER BY ORDERMASTER.ORDER_NO ")
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

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Dim COUNT As Integer = 0
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    COUNT = COUNT + 1
                End If
            Next

            If COUNT > 1 Then
                MsgBox("You Can Select Only One Order")

                Exit Sub
            End If

            DT.Columns.Add("ORDERNO")
            DT.Columns.Add("ORDERSRNO")
            DT.Columns.Add("PONO")
            DT.Columns.Add("PODATE")
            DT.Columns.Add("NAME")
            DT.Columns.Add("SHIPTO")
            DT.Columns.Add("MAINITEMNAME")
            DT.Columns.Add("QTY")
            DT.Columns.Add("ITEMNAME")





            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("ORDERNO"), dtrow("ORDERSRNO"), dtrow("PONO"), dtrow("PODATE"), dtrow("NAME"), dtrow("SHIPTO"), dtrow("MAINITEMNAME"), dtrow("QTY"), dtrow("ITEMNAME"))
                End If
            Next

            Me.Close()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class