Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient

Public Class PlateReturnDesign

    Public WHERECLAUSE As String
    Public FRMSTRING As String
    Public PERIOD As String

    Dim RPTPLATERETURNDTLS As New PlateReturnDetailsReport
    Dim RPTPLATERETURNSUMM As New PlateReturnSummaryReport

    Dim RPTGODOWNWISEDTLS As New PlateReturnGodownwiseDetails
    Dim RPTGODOWNWISESUMM As New PlateReturnGodownwiseSummary

    Dim RPTPLATEWISEDTLS As New PlateReturnPlatewiseDetails
    Dim RPTPLATEWISESUMM As New PlateReturnPlatewiseSummary

    Private Sub PlateReturnDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PlateReturnDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            If FRMSTRING = "PLATERETURNDTLS" Then crTables = RPTPLATERETURNDTLS.Database.Tables
            If FRMSTRING = "PLATERETURNSUMM" Then crTables = RPTPLATERETURNSUMM.Database.Tables

            If FRMSTRING = "GODOWNWISEDTLS" Then crTables = RPTGODOWNWISEDTLS.Database.Tables
            If FRMSTRING = "GODOWNWISESUMM" Then crTables = RPTGODOWNWISESUMM.Database.Tables

            If FRMSTRING = "PLATEWISEDTLS" Then crTables = RPTPLATEWISEDTLS.Database.Tables
            If FRMSTRING = "PLATEWISESUMM" Then crTables = RPTPLATEWISESUMM.Database.Tables


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            CRPO.SelectionFormula = WHERECLAUSE

            If FRMSTRING = "PLATERETURNDTLS" Then
                CRPO.ReportSource = RPTPLATERETURNDTLS
                RPTPLATERETURNDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PLATERETURNSUMM" Then
                CRPO.ReportSource = RPTPLATERETURNSUMM
                RPTPLATERETURNSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "GODOWNWISEDTLS" Then
                CRPO.ReportSource = RPTGODOWNWISEDTLS
                RPTGODOWNWISEDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "GODOWNWISESUMM" Then
                CRPO.ReportSource = RPTGODOWNWISESUMM
                RPTGODOWNWISESUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PLATEWISEDTLS" Then
                CRPO.ReportSource = RPTPLATEWISEDTLS
                RPTPLATEWISEDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PLATEWISESUMM" Then
                CRPO.ReportSource = RPTPLATEWISESUMM
                RPTPLATEWISESUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
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