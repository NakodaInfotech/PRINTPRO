Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class AssemblyQcDetails
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean
    Public TEMPASSEMBLYNO As Integer
    Dim GRIDDOUBLECLICK As Boolean


    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub TOOLEXCEL_Click(sender As Object, e As EventArgs) Handles TOOLEXCEL.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Assembly Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Assembly Details"
            GRIDJOB.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Assembly Details", GRIDJOB.VisibleColumns.Count + GRIDJOB.GroupCount)
        Catch ex As Exception
            MsgBox("Assembly Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub AssemblyQcDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'ASSEMBLY'")
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

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AssemblyQcDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(sender As Object, e As EventArgs) Handles CMDOK.Click
        Try
            showform(True, GRIDJOB.GetFocusedRowCellValue("TEMPASSEMBLYNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub FILLGRID()
        Try
            Dim OBJDEPT As New ClsAssembly
            Dim DT As DataTable = OBJDEPT.SELELECTASSEMBLY(0, YearId)
            GRIDJOBDETAILS.DataSource = DT
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub showform(ByVal editval As Boolean, ByVal TEMPASSEMBLYNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And GRIDJOB.RowCount > 0) Then
                Dim objgdn As New AssemblyQc
                objgdn.MdiParent = MDIMain
                objgdn.edit = editval
                objgdn.TEMPASSEMBLYNO = TEMPASSEMBLYNO
                objgdn.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDJOBDETAILS_DoubleClick(sender As Object, e As EventArgs) Handles GRIDJOBDETAILS.DoubleClick
        Try
            showform(True, GRIDJOB.GetFocusedRowCellValue("TEMPASSEMBLYNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class