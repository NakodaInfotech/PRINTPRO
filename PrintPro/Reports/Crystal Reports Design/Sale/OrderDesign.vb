
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class OrderDesign
    Public FRMSTRING As String
    Public WHERECLAUSE As String
    Public PERIOD As String

    Public SHOWHEADER As Boolean
    Public SHOWPRINTDATE As Boolean
    'Public SHOWADDRESS As Boolean
    Public NEWPAGE As Boolean
    Public ADDRESS As Boolean


    Dim RPTORDERDETAILS As New OrdersDetails
    Dim RPTORDERSUMMRY As New OrdersSummary
    Dim RPTPARTYDTLS As New OrdersPartywiseDetails
    Dim RPTPARTYSUMM As New OrdersPartywiseSummary
    Dim RPTITEMDTLS As New OrdersItemWiseDetails
    Dim RPTITEMSUMM As New OrdersItemWiseSummary
    Dim RPTPENDING As New OrdersPending
    Dim RPTORDERNOTDESPATCHED As New OrdersNotDespatched
    Dim RPTCLOSED As New OrdersClosed
    Dim RPTCOMPLETED As New OrdersComplete
    Dim RPTMONTHLY As New OrdersMonthwiseDetails


    Private Sub OrderDesign_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub OrderDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            If FRMSTRING = "ORDERDTLS" Then crTables = RPTORDERDETAILS.Database.Tables
            If FRMSTRING = "ORDERSUMM" Then crTables = RPTORDERSUMMRY.Database.Tables
            If FRMSTRING = "PARTYWISEDTLS" Then crTables = RPTPARTYDTLS.Database.Tables
            If FRMSTRING = "PARTYWISESUMM" Then crTables = RPTPARTYSUMM.Database.Tables

            If FRMSTRING = "ITEMWISEDTLS" Then crTables = RPTITEMDTLS.Database.Tables
            If FRMSTRING = "ITEMWISESUMM" Then crTables = RPTITEMSUMM.Database.Tables

            If FRMSTRING = "PENDINGORDERS" Then crTables = RPTPENDING.Database.Tables
            If FRMSTRING = "ORDERNOTDESPATCHED" Then crTables = RPTORDERNOTDESPATCHED.Database.Tables
            If FRMSTRING = "CLOSEDORDERS" Then crTables = RPTCLOSED.Database.Tables
            If FRMSTRING = "COMPLETEORDERS" Then crTables = RPTCOMPLETED.Database.Tables
            If FRMSTRING = "MONTHLY" Then crTables = RPTMONTHLY.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            CRPO.SelectionFormula = WHERECLAUSE

            If FRMSTRING = "ORDERDTLS" Then
                CRPO.ReportSource = RPTORDERDETAILS
                RPTORDERDETAILS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTORDERDETAILS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTORDERDETAILS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTORDERDETAILS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTORDERDETAILS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"
                If ADDRESS = True Then RPTORDERDETAILS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'1'" Else RPTORDERDETAILS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'0'"
                RPTORDERDETAILS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE

            ElseIf FRMSTRING = "ORDERSUMM" Then
                CRPO.ReportSource = RPTORDERSUMMRY
                RPTORDERSUMMRY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTORDERSUMMRY.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTORDERSUMMRY.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTORDERSUMMRY.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTORDERSUMMRY.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"

            ElseIf FRMSTRING = "PARTYWISEDTLS" Then
                CRPO.ReportSource = RPTPARTYDTLS
                RPTPARTYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTPARTYDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTPARTYDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTPARTYDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTPARTYDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"
                If ADDRESS = True Then RPTPARTYDTLS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'1'" Else RPTPARTYDTLS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'0'"
                RPTPARTYDTLS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE

            ElseIf FRMSTRING = "PARTYWISESUMM" Then
                CRPO.ReportSource = RPTPARTYSUMM
                RPTPARTYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTPARTYSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTPARTYSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTPARTYSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTPARTYSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"

            ElseIf FRMSTRING = "ITEMWISEDTLS" Then
                CRPO.ReportSource = RPTITEMDTLS
                RPTITEMDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTITEMDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTITEMDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTITEMDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTITEMDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"
                If ADDRESS = True Then RPTITEMDTLS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'1'" Else RPTITEMDTLS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'0'"
                RPTITEMDTLS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE

            ElseIf FRMSTRING = "ITEMWISESUMM" Then
                CRPO.ReportSource = RPTITEMSUMM
                RPTITEMSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTITEMSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTITEMSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTITEMSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTITEMSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"

            ElseIf FRMSTRING = "PENDINGORDERS" Then
                CRPO.ReportSource = RPTPENDING
                RPTPENDING.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTPENDING.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTPENDING.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTPENDING.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTPENDING.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"

            ElseIf FRMSTRING = "ORDERNOTDESPATCHED" Then
                CRPO.ReportSource = RPTORDERNOTDESPATCHED
                RPTPENDING.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                
            ElseIf FRMSTRING = "CLOSEDORDERS" Then
                CRPO.ReportSource = RPTCLOSED
                RPTCLOSED.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTCLOSED.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTCLOSED.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTCLOSED.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTCLOSED.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"


            ElseIf FRMSTRING = "COMPLETEORDERS" Then
                CRPO.ReportSource = RPTCOMPLETED
                RPTCOMPLETED.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTCOMPLETED.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTCOMPLETED.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTCOMPLETED.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTCOMPLETED.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"

            ElseIf FRMSTRING = "MONTHLY" Then
                CRPO.ReportSource = RPTMONTHLY
                RPTMONTHLY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTMONTHLY.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTMONTHLY.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTMONTHLY.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTMONTHLY.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"

            End If

            CRPO.Zoom(100)
            CRPO.Refresh()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub SENDMAILTOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SENDMAILTOOL.Click
        Try
            Dim emailid As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()
            Dim TEMPATTACHMENT As String = "ORDER"
            Try
                Dim objmail As New SendMail
                objmail.attachment = Application.StartupPath & "\" & TEMPATTACHMENT & ".PDF"
                objmail.subject = "ORDER REPORT"
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
            oDfDopt.DiskFileName = Application.StartupPath & "\ORDER.pdf"

            If FRMSTRING = "PARTYWISEDTLS" Then
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

            ElseIf FRMSTRING = "ORDERDTLS" Then
                expo = RPTORDERDETAILS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTORDERDETAILS.Export()
            ElseIf FRMSTRING = "ORDERSUMM" Then
                expo = RPTORDERSUMMRY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTORDERSUMMRY.Export()

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
            ElseIf FRMSTRING = "ORDERNOTDESPATCHED" Then
                expo = RPTORDERNOTDESPATCHED.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTORDERNOTDESPATCHED.Export()
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

            ElseIf FRMSTRING = "MONTHLY" Then
                expo = RPTMONTHLY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMONTHLY.Export()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class