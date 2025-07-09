Imports BL
Public Class PaperInwardRegister
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub Showform(ByVal EDITVAL As Boolean, ByVal CHKNO As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim OBJGRN As New GRNChecking
            OBJGRN.EDIT = EDITVAL
            OBJGRN.MdiParent = MDIMain
            OBJGRN.TEMPGRNCHKNO = CHKNO
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PaperInwardRegister_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.Alt = True And e.KeyCode = Keys.R Then
            Call ToolStripRefresh_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.P Then
            Call EXCELEXPORT_Click(sender, e)
        ElseIf e.KeyCode = Keys.OemQuotes Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub PaperInwardRegister_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GRN CHECKING'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            If (USEREDIT = False And USERVIEW = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim OBJ As New ClsCommonMaster
            Dim DT As DataTable = OBJ.search(" GRNCHECKING_DESC.CHECK_NO AS CHKNO, GRNCHECKING_DESC.CHECK_SRNO AS SRNO, GRNCHECKING.CHECK_DATE AS [DATE], ISNULL(GRNCHECKING.CHECK_GRNNO, 0) AS GRNNO , LEDGERS.Acc_cmpname AS NAME, ISNULL(GRNCHECKING.CHECK_CHALLANNO,0) AS CHALLANNO , GRNCHECKING.CHECK_CHALLANDATE AS CHALLANDATE, NONINVITEMMASTER.NONINV_NAME AS ITEMNAME, ISNULL(GRNCHECKING_DESC.CHECK_LOTNO, 0) AS LOTNO, ISNULL(NONINVITEMMASTER.NONINV_GSM,'') AS GSM, ISNULL(GRNCHECKING_DESC.CHECK_SIZE,'') AS SIZE, ISNULL(GRNCHECKING_DESC.CHECK_WT,0) AS WT, ISNULL(GRNCHECKING_DESC.CHECK_ACCQTY,0) AS RECQTY, GRNCHECKING.CHECK_ACCEPTED AS ACCEPTED , ISNULL(GRNCHECKING.CHECK_CHECKEDBY,'') AS INSPECTEDBY, ISNULL(GRNCHECKING_DESC.CHECK_DESC,'') AS REMARKS, ITEMMASTER.item_name AS INVITEM, ISNULL(GRNCHECKING.CHECK_BILLNO,'') AS BILLNO , CATEGORYMASTER.category_name AS [TYPE] ", "", " GRNCHECKING INNER JOIN GRNCHECKING_DESC ON GRNCHECKING.CHECK_NO = GRNCHECKING_DESC.CHECK_NO INNER JOIN LEDGERS ON GRNCHECKING.CHECK_LEDGERID = LEDGERS.Acc_id INNER JOIN NONINVITEMMASTER ON GRNCHECKING_DESC.CHECK_ITEMID = NONINVITEMMASTER.NONINV_ID LEFT OUTER JOIN CATEGORYMASTER ON NONINVITEMMASTER.NONINV_CATEGORYID = CATEGORYMASTER.category_id LEFT OUTER JOIN ITEMMASTER ON NONINVITEMMASTER.NONINV_INVITEMID = ITEMMASTER.item_id ", " AND GRNCHECKING.CHECK_YEARID =" & YearId & " AND NONINV_ISPAPER = 'TRUE' AND GRNCHECKING_DESC.CHECK_YEARID =" & YearId & " ORDER BY GRNCHECKING_DESC.CHECK_NO ")
            GRIDGrnDetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                GridGrn.FocusedRowHandle = GridGrn.RowCount - 1
                GridGrn.TopRowIndex = GridGrn.RowCount - 17
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(sender As Object, e As EventArgs) Handles CMDOK.Click
        Try
            If USEREDIT = False Then
                MsgBox("Insufficent Rights")
                Exit Sub
            End If
            Showform(True, GridGrn.GetFocusedRowCellValue("CHKNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDGrnDetails_DoubleClick(sender As Object, e As EventArgs) Handles GRIDGrnDetails.DoubleClick
        Try
            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Showform(True, GridGrn.GetFocusedRowCellValue("CHKNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDADD_Click(sender As Object, e As EventArgs) Handles CMDADD.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripRefresh_Click(sender As Object, e As EventArgs) Handles ToolStripRefresh.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub EXCELEXPORT_Click(sender As Object, e As EventArgs) Handles EXCELEXPORT.Click
        Try

            Dim PATH As String = Application.StartupPath & "\ GRNChecking Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "GRNChecking Details"
            GridGrn.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "GRNChecking Details", GridGrn.VisibleColumns.Count + GridGrn.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class