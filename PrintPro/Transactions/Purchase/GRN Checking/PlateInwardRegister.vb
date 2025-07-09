Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class PlateInwardregister
    Public edit As Boolean
    Dim USERADD, USEREDIT, USERDELETE, USERVIEW As Boolean

    Private Sub CMDEXIT_Click(sender As Object, e As EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub PlateInwardregister_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.Alt = True And e.KeyCode = Keys.R Then
                Call TOOLREFRESH_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.P Then
                Call EXCELEXPORT_Click(sender, e)
            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ADDNEW_Click(sender As Object, e As EventArgs) Handles ADDNEW.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            SHOWFORM(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EXCELEXPORT_Click(sender As Object, e As EventArgs) Handles EXCELEXPORT.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Plate Inward Register.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Plate Inward Register"
            GRIDPLATEINWARD.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Plate Inward Register", GRIDPLATEINWARD.VisibleColumns.Count + GRIDPLATEINWARD.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
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

    Sub FILLGRID()
        Try
            If (USEREDIT = False And USERVIEW = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim OBJMID As New ClsCommon
            Dim DT As DataTable = OBJMID.search(" GRNCHECKING.CHECK_NO AS CHKNO, ISNULL(LEDGERS.Acc_cmpname, '') AS CMPNAME, GRNCHECKING.CHECK_DATE AS DATE, ISNULL(GRNCHECKING.CHECK_CHECKEDBY, '') AS CHECKEDBY, 
                         ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS ITEMNAME, ISNULL(ITEMMASTER.item_name, '') AS NAME, 
                         ISNULL(ITEMMASTER.item_code, '0') AS ITEMCODE, ISNULL(ITEMMASTER.item_fileno, '0') AS FILENO, ISNULL(GRNCHECKING_DESC.CHECK_LOTNO,0) AS LOTNO, 
                         ISNULL(GRNCHECKING_DESC.CHECK_SIZE,0) AS SIZE, ISNULL(GRNCHECKING_DESC.CHECK_WT,0) AS WT, ISNULL(GRNCHECKING_DESC.CHECK_QTY,0) AS CHECKQTY , ISNULL(GRNCHECKING_DESC.CHECK_ACCQTY,0) AS ACCQTY, ISNULL(GRNCHECKING_DESC.CHECK_REJQTY,0) AS REJQTY , ISNULL(GRNCHECKING.CHECK_TEXTMATTER, 0) AS TEXTMATTER, ISNULL(GRNCHECKING.CHECK_GRIPPER, 0) AS GRIPPER,
                         ISNULL(GRNCHECKING.CHECK_REGISTRATIONMARK, 0) AS REGISTRATIONMARK, ISNULL(GRNCHECKING.CHECK_ACCEPTED, 0) AS ACCEPTED, ISNULL(GRNCHECKING_DESC.CHECK_DESC, '') AS GRIDREMARKS ", "", " GRNCHECKING INNER JOIN GRNCHECKING_DESC ON GRNCHECKING.CHECK_NO = GRNCHECKING_DESC.CHECK_NO INNER JOIN LEDGERS ON GRNCHECKING.CHECK_LEDGERID = LEDGERS.Acc_id INNER JOIN NONINVITEMMASTER ON NONINVITEMMASTER.NONINV_ID = GRNCHECKING_DESC.CHECK_ITEMID LEFT OUTER JOIN ITEMMASTER ON NONINVITEMMASTER.NONINV_INVITEMID = ITEMMASTER.item_id ", " AND NONINV_ISPLATE = 'TRUE'  and GRNCHECKING.CHECK_yearid = " & YearId & " ORDER BY GRNCHECKING.CHECK_NO ")
            PLATEINWARD.DataSource = DT
            If DT.Rows.Count > 0 Then
                GRIDPLATEINWARD.FocusedRowHandle = -1
                GRIDPLATEINWARD.TopRowIndex = -15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(sender As Object, e As EventArgs) Handles CMDOK.Click
        Try
            SHOWFORM(True, GRIDPLATEINWARD.GetFocusedRowCellValue("CHKNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SHOWFORM(ByVal EDITVAL As Boolean, ByVal CHKNO As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim OBJGRNCHK As New GRNChecking
            OBJGRNCHK.EDIT = EDITVAL
            OBJGRNCHK.MdiParent = MDIMain
            OBJGRNCHK.TEMPGRNCHKNO = CHKNO
            OBJGRNCHK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPLATEINWARD_DoubleClick(sender As Object, e As EventArgs) Handles GRIDPLATEINWARD.DoubleClick
        Try
            SHOWFORM(True, GRIDPLATEINWARD.GetFocusedRowCellValue("CHKNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PlateInwardregister_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'PURCHASE INVOICE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class