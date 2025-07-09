
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient

Public Class DocketDesign

    Public WHERECLAUSE As String
    Public FRMSTRING As String
    Public PERIOD As String
    Public registername As String
    Public FROMDATE As Date
    Public TODATE As Date
    Public strsearch As String
    Public JOBNO As Integer

    Public SHOWHEADER As Boolean
    Public SHOWPRINTDATE As Boolean

    Public NEWPAGE As Boolean
    Public ADDRESS As Boolean


    'VARIABLES FOR JOBDOCKET PRINT
    Public PREJOBNAME As String = ""
    Public PREJOBCODE As String = ""

    Public PAPERCUTTINGPREJOBNAME As String = ""
    Public PAPERCUTTINGPREJOBCODE As String = ""

    Public PRINTEDLEAFLETCUTTINGPREJOBNAME As String = ""
    Public PRINTEDLEAFLETCUTTINGPREJOBCODE As String = ""

    Public PRINTINGPREJOBNAME As String = ""
    Public PRINTINGPREJOBCODE As String = ""

    Public FOLDINGPREJOBNAME As String = ""
    Public FOLDINGPREJOBCODE As String = ""




    'PAPERSHEETCUTTING
    Public CUTTINGGRN As String = ""
    Public CUTTINGMACHINENO As String = ""
    Public CUTTINGBINDERNAME As String = ""
    Public CUTTINGPAPERTYPE As String = ""
    Public CUTTINGSHEETSRECD As String = ""
    Public CUTTINGREMARKS As String = ""
    Public CUTTINGSUPERVISOR As String = ""
    Public CUTTINGDATE As String = ""
    Public CUTTINGGSM As String = ""
    Public CUTTINGQUALITY As String = ""
    '************************


    'PRINTING
    Public PRINTINGMACHINENO As String = ""
    Public PRINTINGNAME As String = ""
    Public PRINTINGCOLOR As String = ""
    Public PRINTINGSHEETSGIVEN As String = ""
    Public PRINTINGSHEETSDESTROYED As String = ""
    Public PRINTINGSHEETSFINAL As String = ""
    Public PRINTINGSHADEAPPBY As String = ""
    Public PRINTINGSUPERVISOR As String = ""
    Public PRINTINGDATE As String = ""
    Public PRINTINGREMARKS As String = ""
    Public PRINTINGINTIME As String = ""
    Public PRINTINGPLATETYPE As String = ""
    Public PRINTINGVARNISH As String = ""
    Public PRINTINGPERFORATION As String = ""
    Public PRINTINGSIZE As String = ""
    Public PRINTINGTEXT As String = ""
    Public PRINTINGSHADE As String = ""
    Public PRINTINGJOBREG As String = ""
    '************************************

    'LEAFLET SORTING
    Public SORTINGTABLENO As String = ""
    Public SORTINGNAME As String = ""
    Public SORTINGSHEETSGIVEN As String = ""
    Public SORTINGSHEETSDESTROYED As String = ""
    Public SORTINGSHEETSFINAL As String = ""
    Public SORTINGSUPERVISOR As String = ""
    Public SORTINGDATE As String = ""
    Public SORTINGREMARKS As String = ""
    '************************************

    'PRINTED LEAFLET CUTTING
    Public LEAFLETCUTMACHINENO As String = ""
    Public LEAFLETCUTNAME As String = ""
    Public LEAFLETCUTSHEETSGIVEN As String = ""
    Public LEAFLETCUTSHEETSDESTROYED As String = ""
    Public LEAFLETCUTSHEETSFINAL As String = ""
    Public LEAFLETCUTSUPERVISOR As String = ""
    Public LEAFLETCUTDATE As String = ""
    Public LEAFLETCUTREMARKS As String = ""
    '************************************

    'MACHINE FOLDING
    Public FOLDMACHINENO As String = ""
    Public FOLDNAME As String = ""
    Public FOLDLEAFLETFEEDINGBY As String = ""
    Public FOLDBUNDLEDBY As String = ""
    Public FOLDPACKEDBY As String = ""
    Public FOLDLABELLEDBY As String = ""
    Public FOLDSAMPLEAPPBY As String = ""
    Public FOLDV As String = ""
    Public FOLDH As String = ""
    Public FOLDSHEETSGIVEN As String = ""
    Public FOLDSHEETSDESTROYED As String = ""
    Public FOLDSHEETSFINAL As String = ""
    Public FOLDSUPERVISOR As String = ""
    Public FOLDDATE As String = ""
    Public FOLDREMARKS As String = ""
    Public FOLD2DCODESTART As String = ""
    Public FOLD2DCODEEND As String = ""
    '************************************


    'UNFOLDING
    Public UNFOLDTABLENO As String = ""
    Public UNFOLDSORTBY As String = ""
    Public UNFOLDCOUNTING As String = ""
    Public UNFOLDPACKEDBY As String = ""
    Public UNFOLDLABELLEDBY As String = ""
    Public UNFOLDSAMPLEAPPBY As String = ""
    Public UNFOLDSHEETSGIVEN As String = ""
    Public UNFOLDSHEETSDESTROYED As String = ""
    Public UNFOLDSHEETSFINAL As String = ""
    Public UNFOLDSUPERVISOR As String = ""
    Public UNFOLDDATE As String = ""
    Public UNFOLDREMARKS As String = ""
    '************************************


    'PACKING
    Public PACKINGPACKBY As String = ""
    Public PACKINGCHECKBY As String = ""
    Public PACKINGSUPERVISOR As String = ""
    '************************************


    Dim RPTDOCKET As New DocketReport
    Dim RPTDOCKET_AMR As New DocketReport_AMR
    Dim RPTDOCKET_RUTVIJ As New DocketReport_Rutvij
    Dim RPTDOCKET_GANESHMUDRA As New DocketReport_GANESHMUDRA
    Dim RPTDELIVERY_GANESHMUDRA As New DeliveryReport_GANESHMUDRA

    Dim RPTBATCH_RUTVIJ As New BatchReport_Rutvij
    Dim RPTBATCH_AMR As New BatchReport_AMR

    Dim RPTJOBDETAILS As New JobDocketDetailsReport
    Dim RPTJOBSUMMRY As New JobDocketSummaryReport
    Dim RPTPARTYDTLS As New JobDocketPartyWiseDetails
    Dim RPTPARTYSUMM As New JobDocketPartyWiseSummary
    Dim RPTITEMDTLS As New JobDocketItemWiseDetails
    Dim RPTITEMSUMM As New JobDocketItemWiseSummary
    Dim RPTMONTHLY As New JobDocketMonthWise
    Dim RPTLINECLEARANCE_RUTVIJ As New LineClearanceReport
    Dim RPTSCHEDULING As New SchedulingReport
    Dim RPTPRODUCTION As New ProductionReport



    Private Sub DocketDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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


            If FRMSTRING = "JOBDTLS" Then crTables = RPTJOBDETAILS.Database.Tables
            If FRMSTRING = "JOBSUMM" Then crTables = RPTJOBSUMMRY.Database.Tables
            If FRMSTRING = "PARTYWISEDTLS" Then crTables = RPTPARTYDTLS.Database.Tables
            If FRMSTRING = "PARTYWISESUMM" Then crTables = RPTPARTYSUMM.Database.Tables

            If FRMSTRING = "ITEMWISEDTLS" Then crTables = RPTITEMDTLS.Database.Tables
            If FRMSTRING = "ITEMWISESUMM" Then crTables = RPTITEMSUMM.Database.Tables
            If FRMSTRING = "MONTHLY" Then crTables = RPTMONTHLY.Database.Tables
            If FRMSTRING = "LINECLEARANCE" Then crTables = RPTLINECLEARANCE_RUTVIJ.Database.Tables
            If FRMSTRING = "SCHEDULING" Then crTables = RPTSCHEDULING.Database.Tables
            If FRMSTRING = "PRODUCTION" Then crTables = RPTPRODUCTION.Database.Tables


            If FRMSTRING = "DOCKET" Then
                If ClientName = "IYMP" Then
                    crTables = RPTDOCKET.Database.Tables
                ElseIf ClientName = "AMR" Then
                    crTables = RPTDOCKET_AMR.Database.Tables
                ElseIf ClientName = "RUTVIJ" Then
                    crTables = RPTDOCKET_RUTVIJ.Database.Tables
                ElseIf ClientName = "GANESHMUDRA" Then
                    crTables = RPTDOCKET_GANESHMUDRA.Database.Tables
                End If
            ElseIf FRMSTRING = "DELIVERY" Then
                If ClientName = "GANESHMUDRA" Then
                    crTables = RPTDOCKET_GANESHMUDRA.Database.Tables
                End If
            End If



            If FRMSTRING = "BATCH" Then
                If ClientName = "AMR" Then
                    crTables = RPTBATCH_AMR.Database.Tables
                Else
                    crTables = RPTBATCH_RUTVIJ.Database.Tables
                End If
            End If


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            CRPO.SelectionFormula = WHERECLAUSE

            If FRMSTRING = "JOBDTLS" Then
                CRPO.ReportSource = RPTJOBDETAILS
                RPTJOBDETAILS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTJOBDETAILS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTJOBDETAILS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTJOBDETAILS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTJOBDETAILS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"
                If ADDRESS = True Then RPTJOBDETAILS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'1'" Else RPTJOBDETAILS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'0'"
                RPTJOBDETAILS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE

            ElseIf FRMSTRING = "JOBSUMM" Then
                CRPO.ReportSource = RPTJOBSUMMRY
                RPTJOBSUMMRY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTJOBSUMMRY.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTJOBSUMMRY.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTJOBSUMMRY.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTJOBSUMMRY.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"

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

            ElseIf FRMSTRING = "MONTHLY" Then
                CRPO.ReportSource = RPTMONTHLY
                RPTMONTHLY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTMONTHLY.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTMONTHLY.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTMONTHLY.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTMONTHLY.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"

            ElseIf FRMSTRING = "DOCKET" Then
                If ClientName = "IYMP" Then
                    CRPO.ReportSource = RPTDOCKET
                ElseIf ClientName = "AMR" Then
                    CRPO.ReportSource = RPTDOCKET_AMR
                ElseIf ClientName = "RUTVIJ" Then
                    CRPO.ReportSource = RPTDOCKET_RUTVIJ
                ElseIf ClientName = "GANESHMUDRA" Then
                    CRPO.ReportSource = RPTDOCKET_GANESHMUDRA
                End If
            ElseIf FRMSTRING = "DELIVERY" Then
                If ClientName = "GANESHMUDRA" Then
                    CRPO.ReportSource = RPTDELIVERY_GANESHMUDRA
                End If
            ElseIf FRMSTRING = "BATCH" Then
                If ClientName = "AMR" Then
                    CRPO.ReportSource = RPTBATCH_AMR
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PREJOBNAME").Text = "'" & PREJOBNAME & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PREJOBCODE").Text = "'" & PREJOBCODE & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PAPERCUTTINGPREJOBNAME").Text = "'" & PAPERCUTTINGPREJOBNAME & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PAPERCUTTINGPREJOBCODE").Text = "'" & PAPERCUTTINGPREJOBCODE & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PRINTINGPREJOBNAME").Text = "'" & PRINTEDLEAFLETCUTTINGPREJOBNAME & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PRINTINGPREJOBCODE").Text = "'" & PRINTEDLEAFLETCUTTINGPREJOBCODE & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PRINTEDLEAFLETCUTTINGPREJOBNAME").Text = "'" & PAPERCUTTINGPREJOBNAME & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PRINTEDLEAFLETCUTTINGPREJOBCODE").Text = "'" & PAPERCUTTINGPREJOBCODE & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("FOLDINGPREJOBNAME").Text = "'" & PAPERCUTTINGPREJOBNAME & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("FOLDINGPREJOBCODE").Text = "'" & PAPERCUTTINGPREJOBCODE & "'"


                    'PAPER SHEET CUTTING 
                    RPTBATCH_AMR.DataDefinition.FormulaFields("CUTTINGGRNNO").Text = "'" & CUTTINGGRN & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("CUTTINGMACHINENO").Text = "'" & CUTTINGMACHINENO & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("CUTTINGBINDERNAME").Text = "'" & CUTTINGBINDERNAME & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("CUTTINGPAPERTYPE").Text = "'" & CUTTINGPAPERTYPE & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("CUTTINGSHEETRECD").Text = "'" & CUTTINGSHEETSRECD & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("CUTTINGREMARKS").Text = "'" & CUTTINGREMARKS & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("CUTTINGSUPERVISOR").Text = "'" & CUTTINGSUPERVISOR & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("CUTTINGDATE").Text = "'" & CUTTINGDATE & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("CUTTINGGSM").Text = "'" & CUTTINGGSM & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("CUTTINGQUALITY").Text = "'" & CUTTINGQUALITY & "'"


                    'PRINTING
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PRINTINGMACHINENO").Text = "'" & PRINTINGMACHINENO & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PRINTINGNAME").Text = "'" & PRINTINGNAME & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PRINTINGCOLORS").Text = "'" & PRINTINGCOLOR & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PRINTINGSHEETSGIVEN").Text = "'" & PRINTINGSHEETSGIVEN & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PRINTINGSHEETSDESTROYED").Text = "'" & PRINTINGSHEETSDESTROYED & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PRINTINGSHEETSFINAL").Text = "'" & PRINTINGSHEETSFINAL & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PRINTINGSHADEAPPBY").Text = "'" & PRINTINGSHADEAPPBY & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PRINTINGSUPERVISOR").Text = "'" & PRINTINGSUPERVISOR & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PRINTINGDATE").Text = "'" & PRINTINGDATE & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PRINTINGREMARKS").Text = "'" & PRINTINGREMARKS & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PRINTINGINTIME").Text = "'" & PRINTINGINTIME & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PRINTINGPLATETYPE").Text = "'" & PRINTINGPLATETYPE & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PRINTINGVARNISH").Text = "'" & PRINTINGVARNISH & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PRINTINGPERFORATION").Text = "'" & PRINTINGPERFORATION & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PRINTINGSIZE").Text = "'" & PRINTINGSIZE & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PRINTINGTEXT").Text = "'" & PRINTINGTEXT & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PRINTINGSHADE").Text = "'" & PRINTINGSHADE & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PRINTINGJOBREG").Text = "'" & PRINTINGJOBREG & "'"


                    'LEAFLET SORTING
                    RPTBATCH_AMR.DataDefinition.FormulaFields("SORTINGTABNO").Text = "'" & SORTINGTABLENO & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("SORTINGNAME").Text = "'" & SORTINGNAME & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("SORTINGSHEETSGIVEN").Text = "'" & SORTINGSHEETSGIVEN & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("SORTINGSHEETSDESTROYED").Text = "'" & SORTINGSHEETSDESTROYED & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("SORTINGSHEETSFINAL").Text = "'" & SORTINGSHEETSFINAL & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("SORTINGSUPERVISOR").Text = "'" & SORTINGSUPERVISOR & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("SORTINGDATE").Text = "'" & SORTINGDATE & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("SORTINGREMARKS").Text = "'" & SORTINGREMARKS & "'"


                    'PRINTED LEAFLET CUTTING
                    RPTBATCH_AMR.DataDefinition.FormulaFields("LEAFLETCUTMACHINENO").Text = "'" & LEAFLETCUTMACHINENO & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("LEAFLETCUTNAME").Text = "'" & LEAFLETCUTNAME & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("LEAFLETCUTSHEETSGIVEN").Text = "'" & LEAFLETCUTSHEETSGIVEN & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("LEAFLETCUTSHEETSDESTROYED").Text = "'" & LEAFLETCUTSHEETSDESTROYED & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("LEAFLETCUTSHEETSFINAL").Text = "'" & LEAFLETCUTSHEETSFINAL & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("LEAFLETCUTSUPERVISOR").Text = "'" & LEAFLETCUTSUPERVISOR & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("LEAFLETCUTDATE").Text = "'" & LEAFLETCUTDATE & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("LEAFLETCUTREMARKS").Text = "'" & LEAFLETCUTREMARKS & "'"


                    'MACHINE FOLDING
                    RPTBATCH_AMR.DataDefinition.FormulaFields("FOLDMACHINENO").Text = "'" & FOLDMACHINENO & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("FOLDNAME").Text = "'" & FOLDNAME & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("FOLDLEAFLETFEEDINGBY").Text = "'" & FOLDLEAFLETFEEDINGBY & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("FOLDBUNDLEDBY").Text = "'" & FOLDBUNDLEDBY & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("FOLDPACKEDBY").Text = "'" & FOLDPACKEDBY & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("FOLDLABELLEDBY").Text = "'" & FOLDLABELLEDBY & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("FOLDSAMPLEAPPBY").Text = "'" & FOLDSAMPLEAPPBY & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("FOLDH").Text = "'" & FOLDH & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("FOLDV").Text = "'" & FOLDV & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("FOLDSHEETSGIVEN").Text = "'" & FOLDSHEETSGIVEN & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("FOLDSHEETSDESTROYED").Text = "'" & FOLDSHEETSDESTROYED & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("FOLDSHEETSFINAL").Text = "'" & FOLDSHEETSFINAL & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("FOLDSUPERVISOR").Text = "'" & FOLDSUPERVISOR & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("FOLDDATE").Text = "'" & FOLDDATE & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("FOLDREMARKS").Text = "'" & FOLDREMARKS & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("FOLD2DCODESTART").Text = "'" & FOLD2DCODESTART & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("FOLD2DCODEEND").Text = "'" & FOLD2DCODEEND & "'"


                    'UNFOLDING
                    RPTBATCH_AMR.DataDefinition.FormulaFields("UNFOLDTABLENO").Text = "'" & UNFOLDTABLENO & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("UNFOLDSORTBY").Text = "'" & UNFOLDSORTBY & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("UNFOLDCOUNTING").Text = "'" & UNFOLDCOUNTING & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("UNFOLDPACKEDBY").Text = "'" & UNFOLDPACKEDBY & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("UNFOLDLABELLEDBY").Text = "'" & UNFOLDLABELLEDBY & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("UNFOLDSAMPLEAPPBY").Text = "'" & UNFOLDSAMPLEAPPBY & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("UNFOLDSHEETSGIVEN").Text = "'" & UNFOLDSHEETSGIVEN & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("UNFOLDSHEETSDESTROYED").Text = "'" & UNFOLDSHEETSDESTROYED & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("UNFOLDSHEETSFINAL").Text = "'" & UNFOLDSHEETSFINAL & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("UNFOLDSUPERVISOR").Text = "'" & UNFOLDSUPERVISOR & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("UNFOLDDATE").Text = "'" & UNFOLDDATE & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("UNFOLDREMARKS").Text = "'" & UNFOLDREMARKS & "'"


                    'PACKING
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PACKINGPACKBY").Text = "'" & PACKINGPACKBY & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PACKINGCHECKBY").Text = "'" & PACKINGCHECKBY & "'"
                    RPTBATCH_AMR.DataDefinition.FormulaFields("PACKINGSUPERVISOR").Text = "'" & PACKINGSUPERVISOR & "'"

                Else
                    CRPO.ReportSource = RPTBATCH_RUTVIJ
                End If
            ElseIf FRMSTRING = "LINECLEARANCE" Then
                CRPO.ReportSource = RPTLINECLEARANCE_RUTVIJ

            ElseIf FRMSTRING = "PRODUCTION" Then
                CRPO.ReportSource = RPTPRODUCTION

            ElseIf FRMSTRING = "SCHEDULING" Then
                CRPO.ReportSource = RPTSCHEDULING
            End If


            CRPO.Zoom(100)
            CRPO.Refresh()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DocketDesign_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub SendMailTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendMailTool.Click
        Try
            Dim emailid As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            TRANSFER()
            Dim TEMPATTACHMENT As String = "DOCKET"
            Try
                Dim objmail As New SendMail
                objmail.attachment = Application.StartupPath & "\" & TEMPATTACHMENT & ".PDF"
                objmail.subject = "DOCKET REPORT"
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

    Sub TRANSFER()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions
            oDfDopt.DiskFileName = Application.StartupPath & "\DOCKET.PDF"

            If FRMSTRING = "DOCKET" Then
                If ClientName = "IYMP" Then
                    expo = RPTDOCKET.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTDOCKET.Export()
                ElseIf ClientName = "AMR" Then
                    expo = RPTDOCKET_AMR.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTDOCKET_AMR.Export()
                ElseIf ClientName = "RUTVIJ" Then
                    expo = RPTDOCKET_RUTVIJ.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTDOCKET_RUTVIJ.Export()
                ElseIf ClientName = "GANESHMUDRA" Then
                    expo = RPTDOCKET_GANESHMUDRA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTDOCKET_GANESHMUDRA.Export()
                End If
            ElseIf FRMSTRING = "DELIVERY" Then
                If ClientName = "GANESHMUDRA" Then
                    expo = RPTDELIVERY_GANESHMUDRA.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTDELIVERY_GANESHMUDRA.Export()
                End If

            ElseIf FRMSTRING = "BATCH" Then
                If ClientName = "AMR" Then
                    expo = RPTBATCH_AMR.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTBATCH_AMR.Export()
                Else
                    expo = RPTBATCH_RUTVIJ.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTBATCH_RUTVIJ.Export()
                End If

            ElseIf FRMSTRING = "LINECLEARANCE" Then
                expo = RPTLINECLEARANCE_RUTVIJ.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTLINECLEARANCE_RUTVIJ.Export()

            ElseIf FRMSTRING = "SCHEDULING" Then
                expo = RPTSCHEDULING.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSCHEDULING.Export()

            ElseIf FRMSTRING = "PRODUCTION" Then
                expo = RPTPRODUCTION.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPRODUCTION.Export()

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

            ElseIf FRMSTRING = "JOBDTLS" Then
                expo = RPTJOBDETAILS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOBDETAILS.Export()

            ElseIf FRMSTRING = "JOBSUMM" Then
                expo = RPTJOBSUMMRY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOBSUMMRY.Export()

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

            ElseIf FRMSTRING = "MONTHLY" Then
                expo = RPTMONTHLY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMONTHLY.Export()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class