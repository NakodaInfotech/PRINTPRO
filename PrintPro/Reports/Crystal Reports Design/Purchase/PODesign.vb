Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class PODesign
    Public FRMSTRING As String
    Public WHERECLAUSE As String
    Public PERIOD As String
    Public SHOWHEADER As Boolean
    Public SHOWPRINTDATE As Boolean
    Public SHOWADDRESS As Boolean
    Public NEWPAGE As Boolean
    Public ADDRESS As Boolean
    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public PRINTSETTING As Object = Nothing
    Public INVNO As Integer = 0
    Public NOOFCOPIES As Integer = 1

    Dim RPTPO As New POReport


    Dim RPTPODETAILS As New PODetailReport
    Dim RPTPOSUMMRY As New POSummaryReport
    Dim RPTPARTYDTLS As New POPartyWiseDetails
    Dim RPTPARTYSUMM As New POPartyWiseSummary
    Dim RPTITEMDTLS As New POItemWiseDetails
    Dim RPTITEMSUMM As New POItemWiseSummary
    Dim RPTPENDING As New POPendingOrders
    Dim RPTCLOSED As New POClosedOrders
    Dim RPTCOMPLETED As New POCompletedOrders


    Private Sub PODesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub PODesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            If FRMSTRING = "PO" Then crTables = RPTPO.Database.Tables
            If FRMSTRING = "PODTLS" Then crTables = RPTPODETAILS.Database.Tables
            If FRMSTRING = "POSUMM" Then crTables = RPTPOSUMMRY.Database.Tables
            If FRMSTRING = "PARTYWISEDTLS" Then crTables = RPTPARTYDTLS.Database.Tables
            If FRMSTRING = "PARTYWISESUMM" Then crTables = RPTPARTYSUMM.Database.Tables

            If FRMSTRING = "ITEMWISEDTLS" Then crTables = RPTITEMDTLS.Database.Tables
            If FRMSTRING = "ITEMWISESUMM" Then crTables = RPTITEMSUMM.Database.Tables

            If FRMSTRING = "PENDINGORDERS" Then crTables = RPTPENDING.Database.Tables
            If FRMSTRING = "CLOSEDORDERS" Then crTables = RPTCLOSED.Database.Tables
            If FRMSTRING = "COMPLETEORDERS" Then crTables = RPTCOMPLETED.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = WHERECLAUSE


            If FRMSTRING = "PO" Then
                crpo.ReportSource = RPTPO

            ElseIf FRMSTRING = "PODTLS" Then
                crpo.ReportSource = RPTPODETAILS
                RPTPODETAILS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTPODETAILS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTPODETAILS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTPODETAILS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTPODETAILS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"
                If SHOWADDRESS = True Then RPTPODETAILS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'1'" Else RPTPODETAILS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'0'"
                RPTPODETAILS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE

            ElseIf FRMSTRING = "POSUMM" Then
                crpo.ReportSource = RPTPOSUMMRY
                RPTPOSUMMRY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTPOSUMMRY.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTPOSUMMRY.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTPOSUMMRY.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTPOSUMMRY.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"

            ElseIf FRMSTRING = "PARTYWISEDTLS" Then
                crpo.ReportSource = RPTPARTYDTLS
                RPTPARTYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTPARTYDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTPARTYDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTPARTYDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTPARTYDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"
                If SHOWADDRESS = True Then RPTPARTYDTLS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'1'" Else RPTPARTYDTLS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'0'"
                RPTPARTYDTLS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE

            ElseIf FRMSTRING = "PARTYWISESUMM" Then
                crpo.ReportSource = RPTPARTYSUMM
                RPTPARTYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTPARTYSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTPARTYSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTPARTYSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTPARTYSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"

            ElseIf FRMSTRING = "ITEMWISEDTLS" Then
                crpo.ReportSource = RPTITEMDTLS
                RPTITEMDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTITEMDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTITEMDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTITEMDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTITEMDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"
                If SHOWADDRESS = True Then RPTITEMDTLS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'1'" Else RPTITEMDTLS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'0'"
                RPTITEMDTLS.GroupFooterSection2.SectionFormat.EnableNewPageAfter = NEWPAGE

            ElseIf FRMSTRING = "ITEMWISESUMM" Then
                crpo.ReportSource = RPTITEMSUMM
                RPTITEMSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTITEMSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTITEMSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTITEMSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTITEMSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"

            ElseIf FRMSTRING = "PENDINGORDERS" Then
                crpo.ReportSource = RPTPENDING
                RPTPENDING.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "CLOSEDORDERS" Then
                crpo.ReportSource = RPTCLOSED
                RPTCLOSED.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "COMPLETEORDERS" Then
                crpo.ReportSource = RPTCOMPLETED
                RPTCOMPLETED.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            End If

            crpo.Zoom(100)
            crpo.Refresh()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub


    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Try
            Dim emailid As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()
            Dim TEMPATTACHMENT As String = "PURCHASE ORDER"
            Try
                Dim objmail As New SendMail
                objmail.attachment = Application.StartupPath & "\" & TEMPATTACHMENT & ".PDF"
                objmail.subject = "PURCHASE ORDER"
                If emailid <> "" Then
                    objmail.cmbfirstadd.Text = emailid
                End If
                objmail.Show()
                objmail.BringToFront()
            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions
            oDfDopt.DiskFileName = Application.StartupPath & "\PURCHASE ORDER.pdf"

            If FRMSTRING = "PO" Then
                expo = RPTPO.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPO.Export()
            ElseIf FRMSTRING = "PARTYWISEDTLS" Then
                expo = RPTPARTYDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPARTYDTLS.Export()
            ElseIf FRMSTRING = "PARTYWISESUMM" Then
                expo = RPTPARTYSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPARTYSUMM.Export()

            ElseIf FRMSTRING = "PODTLS" Then
                expo = RPTPODETAILS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPODETAILS.Export()
            ElseIf FRMSTRING = "POSUMM" Then
                expo = RPTPOSUMMRY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPOSUMMRY.Export()

            ElseIf FRMSTRING = "ITEMWISEDTLS" Then
                expo = RPTITEMDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTITEMDTLS.Export()
            ElseIf FRMSTRING = "ITEMWISESUMM" Then
                expo = RPTITEMSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTITEMSUMM.Export()

            ElseIf FRMSTRING = "PENDINGORDERS" Then
                expo = RPTPENDING.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPENDING.Export()
            ElseIf FRMSTRING = "CLOSEDORDERS" Then
                expo = RPTCLOSED.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCLOSED.Export()
            ElseIf FRMSTRING = "COMPLETEORDERS" Then
                expo = RPTCOMPLETED.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCOMPLETED.Export()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class