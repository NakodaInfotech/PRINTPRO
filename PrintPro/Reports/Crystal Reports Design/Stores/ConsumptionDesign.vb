Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient

Public Class ConsumptionDesign
    Public WHERECLAUSE As String
    Public FRMSTRING As String
    Public PERIOD As String
    Public registername As String
    Public FROMDATE As Date
    Public TODATE As Date
    Public strsearch As String
    Public CONSUMENO As Integer

    Dim RPTCONSUMPTION As New ConsumptionReport
    Dim RPTCONSUMPTIONDTLS As New ConsumptionDetailReport
    Dim RPTCONSUMPTIONSUMM As New ConsumptionSummaryReport

    Dim RPTDEPTWISEDTLS As New ConsumptionDeptwiseDetails
    Dim RPTDEPTWISESUMM As New ConsumptionDeptwiseSummary

    Dim RPTGODOWNWISEDTLS As New ConsumptionGodownwiseDetails
    Dim RPTGODOWNWISESUMM As New ConsumptionGodownwiseSummary

    Dim RPTITEMWISEDTLS As New ConsumptionItemwiseDetails
    Dim RPTITEMWISESUMM As New ConsumptionItemwiseSummary





    Private Sub ConsumptionDesign_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
  
    Private Sub ConsumptionDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            If FRMSTRING = "CONSUMPTION" Then crTables = RPTCONSUMPTION.Database.Tables

            If FRMSTRING = "CONSUMPTIONDTLS" Then crTables = RPTCONSUMPTIONDTLS.Database.Tables
            If FRMSTRING = "CONSUMPTIONSUMM" Then crTables = RPTCONSUMPTIONSUMM.Database.Tables

            If FRMSTRING = "DEPTWISEDTLS" Then crTables = RPTDEPTWISEDTLS.Database.Tables
            If FRMSTRING = "DEPTWISESUMM" Then crTables = RPTDEPTWISESUMM.Database.Tables

            If FRMSTRING = "GODOWNWISEDTLS" Then crTables = RPTGODOWNWISEDTLS.Database.Tables
            If FRMSTRING = "GODOWNWISESUMM" Then crTables = RPTGODOWNWISESUMM.Database.Tables

            If FRMSTRING = "ITEMWISEDTLS" Then crTables = RPTITEMWISEDTLS.Database.Tables
            If FRMSTRING = "ITEMWISESUMM" Then crTables = RPTITEMWISESUMM.Database.Tables


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            CRPO.SelectionFormula = WHERECLAUSE

            If FRMSTRING = "CONSUMPTION" Then
                CRPO.ReportSource = RPTCONSUMPTION
            ElseIf FRMSTRING = "CONSUMPTIONDTLS" Then
                CRPO.ReportSource = RPTCONSUMPTIONDTLS
                RPTCONSUMPTIONDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "CONSUMPTIONSUMM" Then
                CRPO.ReportSource = RPTCONSUMPTIONSUMM
                RPTCONSUMPTIONSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "DEPTWISEDTLS" Then
                CRPO.ReportSource = RPTDEPTWISEDTLS
                RPTDEPTWISEDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "DEPTWISESUMM" Then
                CRPO.ReportSource = RPTDEPTWISESUMM
                RPTDEPTWISESUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "GODOWNWISEDTLS" Then
                CRPO.ReportSource = RPTGODOWNWISEDTLS
                RPTGODOWNWISEDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "GODOWNWISESUMM" Then
                CRPO.ReportSource = RPTGODOWNWISESUMM
                RPTGODOWNWISESUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMWISEDTLS" Then
                CRPO.ReportSource = RPTITEMWISEDTLS
                RPTITEMWISEDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMWISESUMM" Then
                CRPO.ReportSource = RPTITEMWISESUMM
                RPTITEMWISESUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            End If


            CRPO.Zoom(100)
            CRPO.Refresh()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    

    Private Sub SendMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendMail.Click
        Dim emailid As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        TRANSFER()
        Dim tempattachment As String = ""

      
        tempattachment = "CONSUMPTION"
    
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


            oDfDopt.DiskFileName = Application.StartupPath & "\CONSUMPTION.PDF"
            expo = RPTCONSUMPTION.ExportOptions
            expo.ExportDestinationType = ExportDestinationType.DiskFile
            expo.ExportFormatType = ExportFormatType.PortableDocFormat
            expo.DestinationOptions = oDfDopt
            RPTCONSUMPTION.Export()
         

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class