

Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class GRNCheckingDesign
    Public FRMSTRING As String
    Public WHERECLAUSE As String
    Public PERIOD As String

    Public NEWPAGE As Boolean
    Public ADDRESS As Boolean
    Public SHOWHEADER As Boolean
    Public SHOWPRINTDATE As Boolean

    'PARTY WISE REPORTS
    Dim RPTPARTYDTLS As New CheckPartyWiseDetails
    Dim RPTPARTYSUMM As New CheckPartyWiseSummary

    'DESIGN WISE REPORTS
    Dim RPTDESIGNDTLS As New CheckDesignWiseDetails
    Dim RPTDESIGNSUMM As New CheckDesignWiseSummary
    


    'GODWON WISE REPORTS
    Dim RPTGODOWNDTLS As New CheckGodownWiseDetails
    Dim RPTGODOWNSUMM As New CheckGodownWiseSummary

    'ITEM WISE REPOIRTS
    Dim RPTITEMDTLS As New CheckItemWiseDetails
    Dim RPTITEMSUMM As New CheckItemWiseSummary

    Dim RPTMONTHLY As New CheckMonthWise

    Dim RPTQCREPORT As New QCReport
    Dim RPTPAPERTESTREPORT As New PaperTestReport
    Dim RPTCHECKLIST As New CheckListReport

    Private Sub GRNCheckingDesign_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub GRNCheckingDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            If FRMSTRING = "PARTYWISEDTLS" Then crTables = RPTPARTYDTLS.Database.Tables
            If FRMSTRING = "PARTYWISESUMM" Then crTables = RPTPARTYSUMM.Database.Tables

            If FRMSTRING = "ITEMWISEDTLS" Then crTables = RPTITEMDTLS.Database.Tables
            If FRMSTRING = "ITEMWISESUMM" Then crTables = RPTITEMSUMM.Database.Tables

            If FRMSTRING = "GODOWNWISEDTLS" Then crTables = RPTGODOWNDTLS.Database.Tables
            If FRMSTRING = "GODOWNWISESUMM" Then crTables = RPTGODOWNSUMM.Database.Tables

            If FRMSTRING = "DESIGNWISEDTLS" Then crTables = RPTDESIGNDTLS.Database.Tables
            If FRMSTRING = "DESIGNWISESUMM" Then crTables = RPTDESIGNSUMM.Database.Tables

            If FRMSTRING = "MONTHLY" Then crTables = RPTMONTHLY.Database.Tables


            If FRMSTRING = "QCREPORT" Then crTables = RPTQCREPORT.Database.Tables
            If FRMSTRING = "PAPERTESTREPORT" Then crTables = RPTPAPERTESTREPORT.Database.Tables
            If FRMSTRING = "CHECKLIST" Then crTables = RPTCHECKLIST.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            CRPO.SelectionFormula = WHERECLAUSE

            If FRMSTRING = "PARTYWISEDTLS" Then
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

            ElseIf FRMSTRING = "GODOWNWISEDTLS" Then
                CRPO.ReportSource = RPTGODOWNDTLS
                RPTGODOWNDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTGODOWNDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTGODOWNDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTGODOWNDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTGODOWNDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"
                If ADDRESS = True Then RPTGODOWNDTLS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'1'" Else RPTGODOWNDTLS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'0'"
                RPTGODOWNDTLS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE

            ElseIf FRMSTRING = "GOODWNWISESUMM" Then
                CRPO.ReportSource = RPTGODOWNSUMM
                RPTGODOWNSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTGODOWNDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTGODOWNDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTGODOWNDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTGODOWNDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"


            ElseIf FRMSTRING = "DESIGNWISEDTLS" Then
                CRPO.ReportSource = RPTDESIGNDTLS
                RPTDESIGNDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "DESIGNWISESUMM" Then
                CRPO.ReportSource = RPTDESIGNSUMM
                RPTDESIGNSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "MONTHLY" Then
                CRPO.ReportSource = RPTMONTHLY
                RPTMONTHLY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "QCREPORT" Then
                CRPO.ReportSource = RPTQCREPORT

            ElseIf FRMSTRING = "PAPERTESTREPORT" Then
                CRPO.ReportSource = RPTPAPERTESTREPORT

            ElseIf FRMSTRING = "CHECKLIST" Then
                CRPO.ReportSource = RPTCHECKLIST


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
            Dim TEMPATTACHMENT As String = "GRN"
            Dim objmail As New SendMail
            objmail.attachment = TEMPATTACHMENT
            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
            objmail.Show()
            objmail.BringToFront()
            Windows.Forms.Cursor.Current = Cursors.Arrow
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions
            oDfDopt.DiskFileName = Application.StartupPath & "\GRN.pdf"

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
            ElseIf FRMSTRING = "GODOWNWISEDTLS" Then
                expo = RPTGODOWNDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGODOWNDTLS.Export()
            ElseIf FRMSTRING = "QUALITYWISESUMM" Then
                expo = RPTGODOWNSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGODOWNSUMM.Export()
            ElseIf FRMSTRING = "DESIGNWISEDTLS" Then
                expo = RPTDESIGNDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDESIGNDTLS.Export()
            ElseIf FRMSTRING = "DESIGNWISESUMM" Then
                expo = RPTDESIGNSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDESIGNSUMM.Export()


            ElseIf FRMSTRING = "QCREPORT" Then
                expo = RPTQCREPORT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTQCREPORT.Export()

            ElseIf FRMSTRING = "PAPERTESTREPORT" Then
                expo = RPTPAPERTESTREPORT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPAPERTESTREPORT.Export()

            ElseIf FRMSTRING = "CHECKLIST" Then
                expo = RPTCHECKLIST.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCHECKLIST.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class