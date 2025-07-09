
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient

Public Class ChallanDesign

    Public WHERECLAUSE As String
    Public FRMSTRING As String
    Public PERIOD As String
    Public registername As String
    Public FROMDATE As Date
    Public TODATE As Date
    Public strsearch As String
    Public INVNO As Integer
    Public SHOWHEADER As Boolean
    Public SHOWPRINTDATE As Boolean
    Public SHOWADDRESS As Boolean
    Public NEWPAGE As Boolean
    Public ADDRESS As Boolean

    Dim RPTCHALLAN As New ChallanDesignReport
    Dim RPTCHALLAN_AMR As New ChallanDesignReport_AMR
    Dim RPTCHDETAILS As New ChallanDetailsReport
    Dim RPTCHSUMM As New ChallanSummaryReport
    Dim RPTDAILYDES As New ChallanDailyDespatch
    Dim RPTDAILYDES_RUTVIJ As New ChallanDailyDespatch_Rutvij
    Dim RPTGOODDESPTCH As New ChallanGoodDespatchDetails
    Dim RPTITEMDTLS As New ChallanItemWiseDetails
    Dim RPTITEMSUMM As New ChallanItemWiseSummary
    Dim RPTMONTH As New ChallanMonthWiseDetails
    Dim RPTPARTYDTLS As New ChallanPartyWiseDetails
    Dim RPTPARTYSUMM As New ChallanPartyWiseSummary
    Dim RPTTRANSDTLS As New ChallanTransWiseDetails
    Dim RPTTRANSSUMM As New ChallanTransWiseSummary
    Dim RPTCHALLANRUTVIJ As New ChallanDesignReport_Rutvij
    Dim RPTASSEMBLYQC As New AssemblyReport
    Dim RPTDELIVERYREPORT As New DeliveryDetailsReport





    Private Sub ChallanDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            If FRMSTRING = "Challan" Then
                If ClientName = "IYMP" Then
                    crTables = RPTCHALLAN.Database.Tables
                ElseIf ClientName = "AMR" Then
                    crTables = RPTCHALLAN_AMR.Database.Tables
                Else
                    crTables = RPTCHALLANRUTVIJ.Database.Tables
                End If
            End If



            If FRMSTRING = "CHDTLS" Then crTables = RPTCHDETAILS.Database.Tables
            If FRMSTRING = "CHSUMM" Then crTables = RPTCHSUMM.Database.Tables
            If FRMSTRING = "PARTYWISEDTLS" Then crTables = RPTPARTYDTLS.Database.Tables
            If FRMSTRING = "PARTYWISESUMM" Then crTables = RPTPARTYSUMM.Database.Tables

            If FRMSTRING = "ITEMWISEDTLS" Then crTables = RPTITEMDTLS.Database.Tables
            If FRMSTRING = "ITEMWISESUMM" Then crTables = RPTITEMSUMM.Database.Tables

            If FRMSTRING = "DAILYDESPATCH" Then
                If ClientName = "RUTVIJ" Then
                    crTables = RPTDAILYDES_RUTVIJ.Database.Tables
                Else
                    crTables = RPTDAILYDES.Database.Tables
                End If
            End If
            If FRMSTRING = "GOODDESPATCH" Then crTables = RPTGOODDESPTCH.Database.Tables

            If FRMSTRING = "TRANSWISEDTLS" Then crTables = RPTTRANSDTLS.Database.Tables
            If FRMSTRING = "TRANSWISESUMM" Then crTables = RPTTRANSSUMM.Database.Tables
            If FRMSTRING = "ASSEMBLYQC" Then crTables = RPTASSEMBLYQC.Database.Tables
            If FRMSTRING = "DELIVERY" Then crTables = RPTDELIVERYREPORT.Database.Tables



            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            CRPO.SelectionFormula = WHERECLAUSE
            If FRMSTRING = "Challan" Then
                If ClientName = "IYMP" Then
                    CRPO.ReportSource = RPTCHALLAN
                ElseIf ClientName = "AMR" Then
                    CRPO.ReportSource = RPTCHALLAN_AMR
                Else
                    CRPO.ReportSource = RPTCHALLANRUTVIJ
                End If
            End If

            If FRMSTRING = "CHDTLS" Then
                CRPO.ReportSource = RPTCHDETAILS
                RPTCHDETAILS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTCHDETAILS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTCHDETAILS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTCHDETAILS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTCHDETAILS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"
                If SHOWADDRESS = True Then RPTCHDETAILS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'1'" Else RPTCHDETAILS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'0'"
                RPTCHDETAILS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE

            ElseIf FRMSTRING = "CHSUMM" Then
                CRPO.ReportSource = RPTCHSUMM
                RPTCHSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTCHDETAILS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTCHSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTCHDETAILS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTCHSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"


            ElseIf FRMSTRING = "PARTYWISEDTLS" Then
                CRPO.ReportSource = RPTPARTYDTLS
                RPTPARTYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTPARTYDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTPARTYDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTPARTYDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTPARTYDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"
                If SHOWADDRESS = True Then RPTPARTYDTLS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'1'" Else RPTPARTYDTLS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'0'"
                RPTPARTYDTLS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE

            ElseIf FRMSTRING = "PARTYWISESUMM" Then
                CRPO.ReportSource = RPTPARTYSUMM
                RPTPARTYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTPARTYSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTPARTYSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTPARTYSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTPARTYSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"


            ElseIf FRMSTRING = "TRANSWISEDTLS" Then
                CRPO.ReportSource = RPTTRANSDTLS
                RPTTRANSDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTTRANSDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTTRANSDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTTRANSDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTTRANSDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"
                If SHOWADDRESS = True Then RPTTRANSDTLS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'1'" Else RPTTRANSDTLS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'0'"
                RPTTRANSDTLS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE

            ElseIf FRMSTRING = "TRANSWISESUMM" Then
                CRPO.ReportSource = RPTTRANSSUMM
                RPTTRANSSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTTRANSSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTTRANSSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTTRANSSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTTRANSSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"


            ElseIf FRMSTRING = "ITEMWISEDTLS" Then
                CRPO.ReportSource = RPTITEMDTLS
                RPTITEMDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTITEMDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTITEMDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTITEMDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTITEMDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"
                If SHOWADDRESS = True Then RPTITEMDTLS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'1'" Else RPTITEMDTLS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'0'"
                RPTITEMDTLS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE

            ElseIf FRMSTRING = "ITEMWISESUMM" Then
                CRPO.ReportSource = RPTITEMSUMM
                RPTITEMSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTITEMSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTITEMSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTITEMSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTITEMSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"

            ElseIf FRMSTRING = "DAILYDESPATCH" Then
                If ClientName = "RUTVIJ" Then
                    CRPO.ReportSource = RPTDAILYDES_RUTVIJ
                Else
                    CRPO.ReportSource = RPTDAILYDES
                End If
                RPTDAILYDES.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "GOODDESPATCH" Then
                CRPO.ReportSource = RPTGOODDESPTCH

            ElseIf FRMSTRING = "ASSEMBLYQC" Then
                CRPO.ReportSource = RPTASSEMBLYQC

            ElseIf FRMSTRING = "DELIVERY" Then
                CRPO.ReportSource = RPTDELIVERYREPORT
            End If


            CRPO.Zoom(100)
            CRPO.Refresh()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChallanDesign_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub SendMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendMail.Click
        Dim emailid As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        TRANSFER()
        Dim tempattachment As String = "CHALLAN"

        'If FRMSTRING = "Challan" Then
        'tempattachment = "CHALLANREPORT"
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
            oDfDopt.DiskFileName = Application.StartupPath & "\CHALLAN.PDF"

            If ClientName = "IYMP" Then
                If FRMSTRING = "Challan" Then
                    expo = RPTCHALLAN.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTCHALLAN.Export()
                End If
            Else
                If FRMSTRING = "Challan" Then
                    expo = RPTCHALLANRUTVIJ.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTCHALLANRUTVIJ.Export()
                End If
            End If

            If FRMSTRING = "CHDTLS" Then
                expo = RPTCHDETAILS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCHDETAILS.Export()

            ElseIf FRMSTRING = "CHSUMM" Then
                expo = RPTCHSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCHSUMM.Export()
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

            ElseIf FRMSTRING = "TRANSWISEDTLS" Then
                expo = RPTTRANSDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTTRANSDTLS.Export()
            ElseIf FRMSTRING = "TRANSWISESUMM" Then
                expo = RPTTRANSSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTTRANSSUMM.Export()

            ElseIf FRMSTRING = "DAILYDISPATCH" Then
                If ClientName = "RUTVIJ" Then
                    expo = RPTDAILYDES_RUTVIJ.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTDAILYDES_RUTVIJ.Export()
                Else
                    expo = RPTDAILYDES.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTDAILYDES.Export()
                End If


            ElseIf FRMSTRING = "MONTHLY" Then
                expo = RPTMONTH.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMONTH.Export()

            ElseIf FRMSTRING = "ASSEMBLYQC" Then
                expo = RPTASSEMBLYQC.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTASSEMBLYQC.Export()

            ElseIf FRMSTRING = "DELIVERY" Then
                expo = RPTDELIVERYREPORT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDELIVERYREPORT.Export()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class