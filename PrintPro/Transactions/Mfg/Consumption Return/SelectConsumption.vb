
Imports BL
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Controls

Public Class SelectConsumption
    Public DT As New DataTable
    Dim CONSUMESELECTED As Boolean
    Dim CONSUMENO As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectConsumption_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectConsumption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FILLGRID("")
    End Sub

    Sub FILLGRID(ByVal WHERE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" CAST(0 AS BIT) AS CHK, ISNULL(CONSUMPTION.CONSUME_NO, 0) AS CONSUMENO, ISNULL(CONSUMPTION_DESC.CONSUME_GRIDSRNO, 0) AS SRNO, CONSUMPTION.CONSUME_DATE AS DATE, ISNULL(CONSUMPTION.CONSUME_MATERIALGIVENBY, '') AS MATERIALGIVENBY, ISNULL(CONSUMPTION.CONSUME_MATERIALGIVENTO, '') AS MATERIALGIVENTO, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(DEPARTMENTMASTER.DEPARTMENT_name, '') AS DEPARTMENT, ISNULL(CONSUMPTION_DESC.CONSUME_QTY - CONSUMPTION_DESC.CONSUME_OUTQTY, 0) AS QTY, ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME, ISNULL(CONSUMPTION_DESC.CONSUME_RATE, 0) AS RATE", "", "  CONSUMPTION_DESC INNER JOIN CONSUMPTION ON CONSUMPTION_DESC.CONSUME_no = CONSUMPTION.CONSUME_NO AND CONSUMPTION_DESC.CONSUME_yearid = CONSUMPTION.CONSUME_yearid INNER JOIN NONINVITEMMASTER ON CONSUMPTION_DESC.CONSUME_ITEMID = NONINVITEMMASTER.NONINV_ID AND CONSUMPTION_DESC.CONSUME_yearid = NONINVITEMMASTER.NONINV_YEARID INNER JOIN GODOWNMASTER ON CONSUMPTION.CONSUME_GODOWNID = GODOWNMASTER.GODOWN_id AND CONSUMPTION.CONSUME_yearid = GODOWNMASTER.GODOWN_yearid INNER JOIN DEPARTMENTMASTER ON CONSUMPTION.CONSUME_DEPARTMENTID = DEPARTMENTMASTER.DEPARTMENT_id AND CONSUMPTION.CONSUME_yearid = DEPARTMENTMASTER.DEPARTMENT_yearid", "AND (CONSUMPTION_DESC.CONSUME_QTY - CONSUMPTION_DESC.CONSUME_OUTQTY) > 0 AND CONSUMPTION.CONSUME_YEARID = " & YearId)

            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Dim N As String = ""
            For I As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(I)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If N <> "" Then
                        If N = (dtrow("CONSUMENO")) Then
                            GoTo Line1
                        Else
                            MsgBox("Pls select same Consumption !")
                            Exit Sub
                        End If
                    End If
Line1:
                    N = (dtrow("CONSUMENO"))
                End If
            Next

                DT.Columns.Add("CONSUMENO")
                DT.Columns.Add("SRNO")
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        DT.Rows.Add(dtrow("CONSUMENO"), dtrow("SRNO"))
                    End If
                Next
                Me.Close()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class