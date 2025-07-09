
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient

Public Class ConsumptionReturnDesign

    Public WHERECLAUSE As String
    Public FRMSTRING As String
    Public PERIOD As String

    Dim RPTCONSUMPTIONRETURNDTLS As New ConsumptionReturnDetialReport
    Dim RPTCONSUMPTIONRETURNSUMM As New ConsumptionReturnSummaryReport

    Dim RPTCONSUMPTIONRTNGODOWNWISEDTLS As New ConsumptionReturnGodownwiseDetails
    Dim RPTCONSUMPTIONRTNGODOWNWISESUMM As New ConsumptionReturnGodownwiseSummary
    Dim RPTCONSUMPTIONRTNITEMWISEDTLS As New ConsumptionReturnItemwiseDetials
    Dim RPTCONSUMPTIONRTNITEMWISESUMM As New ConsumptionReturnItemwiseSummary




    Private Sub ConsumptionReturnDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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


    Private Sub ConsumptionReturnDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            If FRMSTRING = "CONSUMPTIONRETURNDTLS" Then crTables = RPTCONSUMPTIONRETURNDTLS.Database.Tables
            If FRMSTRING = "CONSUMPTIONRETURNSUMM" Then crTables = RPTCONSUMPTIONRETURNSUMM.Database.Tables
            If FRMSTRING = "GODOWNWISEDTLS" Then crTables = RPTCONSUMPTIONRTNGODOWNWISEDTLS.Database.Tables
            If FRMSTRING = "GODOWNWISESUMM" Then crTables = RPTCONSUMPTIONRTNGODOWNWISESUMM.Database.Tables
            If FRMSTRING = "ITEMWISEDTLS" Then crTables = RPTCONSUMPTIONRTNITEMWISEDTLS.Database.Tables
            If FRMSTRING = "ITEMWISESUMM" Then crTables = RPTCONSUMPTIONRTNITEMWISESUMM.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            CRPO.SelectionFormula = WHERECLAUSE

            If FRMSTRING = "CONSUMPTIONRETURNDTLS" Then
                CRPO.ReportSource = RPTCONSUMPTIONRETURNDTLS
                RPTCONSUMPTIONRETURNDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "CONSUMPTIONRETURNSUMM" Then
                CRPO.ReportSource = RPTCONSUMPTIONRETURNSUMM
                RPTCONSUMPTIONRETURNSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "GODOWNWISEDTLS" Then
                CRPO.ReportSource = RPTCONSUMPTIONRTNGODOWNWISEDTLS
                RPTCONSUMPTIONRTNGODOWNWISEDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "GODOWNWISESUMM" Then
                CRPO.ReportSource = RPTCONSUMPTIONRTNGODOWNWISESUMM
                RPTCONSUMPTIONRTNGODOWNWISESUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMWISEDTLS" Then
                CRPO.ReportSource = RPTCONSUMPTIONRTNITEMWISEDTLS
                RPTCONSUMPTIONRTNITEMWISEDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMWISESUMM" Then
                CRPO.ReportSource = RPTCONSUMPTIONRTNITEMWISESUMM
                RPTCONSUMPTIONRTNITEMWISESUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            End If

            CRPO.Zoom(100)
            CRPO.Refresh()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
End Class