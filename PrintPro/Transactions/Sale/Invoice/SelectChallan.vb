Imports System.Windows.Forms
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class SelectChallan
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

    Private Sub SelectChallan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub SelectChallan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FILLGRID()
    End Sub

    Sub FILLGRID()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" DISTINCT CAST(0 AS BIT) AS CHK, ISNULL(challanmaster.challan_no, 0) AS CHALLANNO, ISNULL(challanmaster.challan_pono, '') AS PONO, challanmaster.challan_date AS DATE, ISNULL(itemmaster.item_code, '') AS ITEMCODE, ISNULL(challanmaster_DESC.CHALLAN_QTY, 0) AS QTY, LEDGERS.ACC_CMPNAME AS NAME", "", " challanmaster INNER JOIN CHALLANMASTER_DESC ON challanmaster.challan_no = CHALLANMASTER_DESC.CHALLAN_NO AND challanmaster.challan_yearid = CHALLANMASTER_DESC.CHALLAN_YEARID INNER JOIN itemmaster ON CHALLANMASTER_DESC.CHALLAN_ITEMID = itemmaster.item_id AND CHALLANMASTER_DESC.CHALLAN_YEARID = itemmaster.item_yearid INNER JOIN LEDGERS ON CHALLAN_LEDGERID = LEDGERS.ACC_ID ", " AND CHALLANMASTER.CHALLAN_DONE = 0 AND CHALLANMASTER.CHALLAN_YEARID = " & YearId & " ORDER BY ISNULL(challanmaster.challan_no, 0)")
            gridchallandetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridchallan.FocusedRowHandle = gridchallan.RowCount - 1
                gridchallan.TopRowIndex = gridchallan.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Dim COUNT As Integer
            For i As Integer = 0 To gridchallan.RowCount - 1
                Dim dtrow As DataRow = gridchallan.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    COUNT = COUNT + 1
                End If
            Next
            If ClientName <> "AMR" Then
                If COUNT > 1 Then
                    MsgBox("You Can Select Only One Challan No")
                    Exit Sub
                End If
            End If

            DT.Columns.Add("CHALLANNO")
            DT.Columns.Add("PONO")

            For i As Integer = 0 To gridchallan.RowCount - 1
                Dim dtrow As DataRow = gridchallan.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(dtrow("CHALLANNO"), dtrow("PONO"))
                End If
            Next

            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class