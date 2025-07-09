
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO
Imports BL

Public Class StockDesign
    Dim RPTSTOCKHAND As New StockInHand
    Dim RPTSTOCKREG As New StockRegister
    Dim RPTSTOCKRATEWISE As New StockRegisterRate

    Public WHERECLAUSE As String
    Public FRMSTRING As String
    Public PERIOD As String
    Public FROMDATE As Date
    Public TODATE As Date
    Public SHOWALL As Boolean

    Dim tempattachment As String
    Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
    Dim expo As New ExportOptions
    Dim oDfDopt As New DiskFileDestinationOptions

    Private Sub StockDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor.Current = Cursors.WaitCursor

            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crTables As Tables
            Dim crTable As Table


            With crConnecttionInfo
                .ServerName = SERVERNAME
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            If FRMSTRING = "STOCKINHAND" Then crTables = RPTSTOCKHAND.Database.Tables
            If FRMSTRING = "STOCKREG" Then crTables = RPTSTOCKREG.Database.Tables
            If FRMSTRING = "STOCKRATEWISE" Then crTables = RPTSTOCKRATEWISE.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            CRPO.SelectionFormula = WHERECLAUSE

            If FRMSTRING = "STOCKINHAND" Then
                CRPO.ReportSource = RPTSTOCKHAND
                RPTSTOCKHAND.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWALL = True Then RPTSTOCKHAND.DataDefinition.FormulaFields("SHOWALL").Text = 1 Else RPTSTOCKHAND.DataDefinition.FormulaFields("SHOWALL").Text = 0

            ElseIf FRMSTRING = "STOCKREG" Then
                CRPO.ReportSource = RPTSTOCKREG
                RPTSTOCKREG.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTSTOCKREG.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTSTOCKREG.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"

            ElseIf FRMSTRING = "STOCKRATEWISE" Then
                CRPO.ReportSource = RPTSTOCKRATEWISE
                RPTSTOCKRATEWISE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTSTOCKRATEWISE.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTSTOCKRATEWISE.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
            End If

            CRPO.Zoom(100)
            CRPO.Refresh()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockDesign_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim emailid As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        TRANSFER()
        Dim tempattachment As String = "STOCK"

        'If FRMSTRING = "Challan" Then
        '    tempattachment = "CHALLANREPORT"
        'End If

        Try
            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"
            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
            objmail.Show()
            objmail.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
        Windows.Forms.Cursor.Current = Cursors.Arrow
    End Sub

    Sub TRANSFER()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions
            oDfDopt.DiskFileName = Application.StartupPath & "\STOCK.PDF"

            If FRMSTRING = "STOCKINHAND" Then
                expo = RPTSTOCKHAND.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSTOCKHAND.Export()
            ElseIf FRMSTRING = "STOCKREG" Then
                expo = RPTSTOCKREG.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSTOCKREG.Export()
            ElseIf FRMSTRING = "STOCKRATEWISE" Then
                expo = RPTSTOCKRATEWISE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSTOCKRATEWISE.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class