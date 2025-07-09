
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO
Imports BL

Public Class ItemCodeDesign

    Dim RPTALLDATA As New ItemCodeAllDataReport
    Dim RPTITEMCODE As New ItemCodeDetailsReport
    Dim RPTITEMPARTY As New ItemCodeReport

    Public WHERECLAUSE As String
    Public FRMSTRING As String
    Public PERIOD As String
    Public FROMDATE As Date
    Public TODATE As Date
    Dim tempattachment As String
    Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
    Dim expo As New ExportOptions
    Dim oDfDopt As New DiskFileDestinationOptions

    Private Sub ItemCodeDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            If FRMSTRING = "ALLDATA" Then
                crTables = RPTALLDATA.Database.Tables
                RPTALLDATA.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMCODE" Then
                crTables = RPTITEMCODE.Database.Tables
                RPTITEMCODE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PARTYWISEDTLS" Then
                crTables = RPTITEMPARTY.Database.Tables
                RPTITEMPARTY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            End If


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            CRPO.SelectionFormula = WHERECLAUSE

            If FRMSTRING = "ALLDATA" Then
                CRPO.ReportSource = RPTALLDATA
                RPTALLDATA.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTALLDATA.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTALLDATA.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
            ElseIf FRMSTRING = "ITEMCODE" Then
                CRPO.ReportSource = RPTITEMCODE
                RPTITEMCODE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTITEMCODE.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTITEMCODE.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
            ElseIf FRMSTRING = "PARTYWISEDTLS" Then
                CRPO.ReportSource = RPTITEMPARTY
                RPTITEMPARTY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTITEMPARTY.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                RPTITEMPARTY.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
            End If

            CRPO.Zoom(100)
            CRPO.Refresh()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ItemCodeDesign_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
End Class