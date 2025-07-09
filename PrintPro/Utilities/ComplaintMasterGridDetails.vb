Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid


Public Class ComplaintMasterGridDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean

    Private Sub CMDEXIT_Click(sender As Object, e As EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub ComplaintMasterGridDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE INVOICE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

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
            Dim PATH As String = "D:\Complaint Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Complaint Details"
            GridComplaint.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "GRNChecking Details", GridComplaint.VisibleColumns.Count + GridComplaint.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Refresh_Click(sender As Object, e As EventArgs) Handles Refresh.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(sender As Object, e As EventArgs) Handles CMDOK.Click
        Try
            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(True, GridComplaint.GetFocusedRowCellValue("COMPNO"))
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
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCOMPCHK As New ClsComplaintMaster
            OBJCOMPCHK.alParaval.Add(0)
            OBJCOMPCHK.alParaval.Add(YearId)
            Dim dttable As DataTable = OBJCOMPCHK.SELECTCOMPLAINT()
            GRIDCOMPLAINTMASTERDETAILS.DataSource = dttable
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal EDITVAL As Boolean, ByVal COMPNO As Integer)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim OBJCOMPM As New ComplaintMaster
            OBJCOMPM.EDIT = EDITVAL
            OBJCOMPM.MdiParent = MDIMain
            OBJCOMPM.TEMPCOMPLAINTNO = COMPNO
            OBJCOMPM.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GRIDCOMPLAINTMASTERDETAILS_DoubleClick(sender As Object, e As EventArgs) Handles GRIDCOMPLAINTMASTERDETAILS.DoubleClick
        Try
            If USEREDIT = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(True, GridComplaint.GetFocusedRowCellValue("COMPNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class