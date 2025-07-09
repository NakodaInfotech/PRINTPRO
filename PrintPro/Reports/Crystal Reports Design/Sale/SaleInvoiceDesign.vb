
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports BL
Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography
Imports DevExpress.Pdf
Imports DevExpress.XtraEditors
Imports PrintPro.DevExpressTest.Docs.Demos

Public Class SaleInvoiceDesign

    Private Class CertItem
        Private privateName As String
        Public Property Name() As String
            Get
                Return privateName
            End Get
            Set(ByVal value As String)
                privateName = value
            End Set
        End Property

        Private privateCert As X509Certificate2

        Public Property Cert() As X509Certificate2
            Get
                Return privateCert
            End Get
            Set(ByVal value As X509Certificate2)
                privateCert = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class

    Private Shared Function SelectCertificates() As X509Certificate2Collection
        Dim store As New X509Store(StoreName.My, StoreLocation.CurrentUser)
        store.Open(OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly)
        Dim collection As X509Certificate2Collection = store.Certificates
        collection = collection.Find(X509FindType.FindByTimeValid, DateTime.Now, True)
        collection = collection.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, True)
        Return collection
    End Function


    Public WHERECLAUSE As String
    Public FRMSTRING As String
    Public PERIOD As String
    Public registername As String
    Public FROMDATE As Date
    Public TODATE As Date
    Public strsearch As String
    Public INVNO As Integer
    Public SHOWINCHALLANFORMAT As Integer = 0

    Public NEWPAGE As Boolean
    Public ADDRESS As Boolean
    Public SHOWPRINTDATE As Boolean
    Public SHOWHEADER As Boolean
    Public PRINTPACKETDETAILS As Boolean

    Dim RPTINVDTLS As New InvoiceDetailsReport
    Dim RPTINVSUMM As New InvoiceSummary
    Dim RPTPARTYDTLS As New InvoicePartyWiseDetails
    Dim RPTPARTYSUMM As New InvoicePartyWiseSummary
    Dim RPTITEMDTLS As New InvoiceItemWiseDetails
    Dim RPTITEMSUMM As New InvoiceItemWiseSummary
    Dim RPTMONTHLY As New InvoiceMonthWiseDetails


    Dim RPTINVOICE As New InvoiceReportNew
    Dim RPTINVOICEQC As New InvoiceQCReport


    Dim RPTCOAREPORT As New COAReport
    Dim RPTCHALLANCOAREPORT As New ChallanCOAReport
    Dim RPTCOAREPORTRUTVIJ As New COAReportforRutvij
    Dim RPTCOAREPORTAMR As New COAReportforAMR
    Dim RPTMSNCOAREPORTAMR As New MSN_COAReportforAMR

    Dim RPTIPCAREPORT As New IPCA_COAReport
    Dim RPTIPCAREPORTRUTVIJ As New IPCA_COAReport_ForRutvij
    Dim RPTSANDOZREPORT As New SANDOZ_COAReport
    Dim RPTSANDOZREPORT_IYMP As New SANDOZ_COAReport_IYMP
    Dim RPTSANDOZREPORTRUTVIJ As New SANDOZ_COAReport_ForRutvij
    Dim RPTFAMYCAREREPORT As New FAMY_CARE__COAReport
    Dim RPTFAMYCAREREPORTRUTVIJ As New FAMY_CARE__COAReport_ForRutvji
    Dim RPTBIOCONREPORT As New Biocon_COAReport
    Dim RPTMILANCOAREPORT As New MILAN_COA
    Dim RPTALKEMCOAREPORT As New ALKEM_COAReportforAMR
    Dim RPTSUNCOAREPORT As New SUN_COAReportforAMR
    Dim RPTSHALINACOAREPORT As New SHALINA_COAReportforAMR
    Dim RPTASSEMBLYQCREPORT As New AssemblyQCReport


    Public DIRECTPRINT As Boolean = False

    Private Sub SaleInvoiceDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If DIRECTPRINT = True Then
                PRINTDIRECTLYTOPRINTER()
                Exit Sub
            End If


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

            If FRMSTRING = "INVOICEDTLS" Then crTables = RPTINVDTLS.Database.Tables
            If FRMSTRING = "INVOICESUMM" Then crTables = RPTINVSUMM.Database.Tables

            If FRMSTRING = "PARTYWISEDTLS" Then crTables = RPTPARTYDTLS.Database.Tables
            If FRMSTRING = "PARTYWISESUMM" Then crTables = RPTPARTYSUMM.Database.Tables

            If FRMSTRING = "ITEMWISEDTLS" Then crTables = RPTITEMDTLS.Database.Tables
            If FRMSTRING = "ITEMWISESUMM" Then crTables = RPTITEMSUMM.Database.Tables

            If FRMSTRING = "MONTHLY" Then crTables = RPTMONTHLY.Database.Tables
            If FRMSTRING = "INVOICEQCREPORT" Then crTables = RPTINVOICEQC.Database.Tables
            If FRMSTRING = "ASSEMBLYQC" Then crTables = RPTASSEMBLYQCREPORT.Database.Tables


            If FRMSTRING = "INVOICE" Then
                Me.Text = "Sale Invoice"
                crTables = RPTINVOICE.Database.Tables
            End If

            If FRMSTRING = "COA" Then
                Me.Text = "CIPLA COA"
                If ClientName = "RUTVIJ" Then
                    crTables = RPTCOAREPORTRUTVIJ.Database.Tables
                ElseIf ClientName = "AMR" Then
                    crTables = RPTCOAREPORTAMR.Database.Tables
                End If

            ElseIf FRMSTRING = "COMMONCOA" Then
                Me.Text = "COMMON COA"
                crTables = RPTCOAREPORT.Database.Tables

            ElseIf FRMSTRING = "MSNCOA" Then
                Me.Text = "MSN COA"
                crTables = RPTMSNCOAREPORTAMR.Database.Tables

            ElseIf FRMSTRING = "CHALLANCOA" Then
                Me.Text = "COMMON COA"
                crTables = RPTCHALLANCOAREPORT.Database.Tables

            ElseIf FRMSTRING = "IPCA_COA" Then
                Me.Text = "IPCA COA"
                If ClientName = "RUTVIJ" Then
                    crTables = RPTIPCAREPORTRUTVIJ.Database.Tables
                ElseIf ClientName = "AMR" Then
                    crTables = RPTIPCAREPORTRUTVIJ.Database.Tables
                Else
                    crTables = RPTIPCAREPORT.Database.Tables
                End If

            ElseIf FRMSTRING = "SANDOZ_COA" Then
                Me.Text = "SANDOZ COA"
                If ClientName = "RUTVIJ" Then
                    crTables = RPTSANDOZREPORTRUTVIJ.Database.Tables
                ElseIf ClientName = "AMR" Then
                    crTables = RPTSANDOZREPORTRUTVIJ.Database.Tables
                Else
                    crTables = RPTSANDOZREPORT_IYMP.Database.Tables
                End If
            ElseIf FRMSTRING = "FAMYCARE_COA" Then
                Me.Text = "FAMYCARE COA"
                If ClientName = "RUTVIJ" Then
                    crTables = RPTFAMYCAREREPORTRUTVIJ.Database.Tables
                ElseIf ClientName = "AMR" Then
                    crTables = RPTFAMYCAREREPORTRUTVIJ.Database.Tables
                Else
                    crTables = RPTFAMYCAREREPORT.Database.Tables
                End If

            ElseIf FRMSTRING = "BIOCON_COA" Then
                Me.Text = "BIOCON COA"
                crTables = RPTBIOCONREPORT.Database.Tables

            ElseIf FRMSTRING = "ALKEM_COA" Then
                Me.Text = "ALKEM COA"
                crTables = RPTALKEMCOAREPORT.Database.Tables

            ElseIf FRMSTRING = "SUN_COA" Then
                Me.Text = "SUN PHARMA COA"
                crTables = RPTSUNCOAREPORT.Database.Tables

            ElseIf FRMSTRING = "SHALINA_COA" Then
                Me.Text = "SHALINA COA"
                crTables = RPTSHALINACOAREPORT.Database.Tables

            ElseIf FRMSTRING = "MILAN_COA" Then
                Me.Text = "MILAN COA"
                crTables = RPTMILANCOAREPORT.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            CRPO.SelectionFormula = WHERECLAUSE


            If FRMSTRING = "INVOICEDTLS" Then
                CRPO.ReportSource = RPTINVDTLS
                RPTINVDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTINVDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTINVDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTINVDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTINVDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"

            ElseIf FRMSTRING = "INVOICESUMM" Then
                CRPO.ReportSource = RPTINVSUMM
                RPTINVSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTINVSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTINVSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTINVSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTINVSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"

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

            End If


            If FRMSTRING = "INVOICEQCREPORT" Then
                CRPO.ReportSource = RPTINVOICEQC
            End If

            If FRMSTRING = "ASSEMBLYQC" Then
                CRPO.ReportSource = RPTASSEMBLYQCREPORT
            End If


            If FRMSTRING = "INVOICE" Then
                CRPO.ReportSource = RPTINVOICE
                If PRINTPACKETDETAILS = True Then RPTINVOICE.DataDefinition.FormulaFields("PRINTPACKET").Text = "1" Else RPTINVOICE.DataDefinition.FormulaFields("PRINTPACKET").Text = "0"
                RPTINVOICE.DataDefinition.FormulaFields("SHOWINCHALLANFORMAT").Text = SHOWINCHALLANFORMAT
                If ClientName = "AMR" Then RPTINVOICE.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
            End If

            If FRMSTRING = "COA" Then
                If ClientName = "RUTVIJ" Then
                    CRPO.ReportSource = RPTCOAREPORTRUTVIJ
                ElseIf ClientName = "AMR" Then
                    CRPO.ReportSource = RPTCOAREPORTAMR
                End If
            ElseIf FRMSTRING = "COMMONCOA" Then
                CRPO.ReportSource = RPTCOAREPORT

            ElseIf FRMSTRING = "MSNCOA" Then
                CRPO.ReportSource = RPTMSNCOAREPORTAMR

            ElseIf FRMSTRING = "CHALLANCOA" Then
                CRPO.ReportSource = RPTCHALLANCOAREPORT

            ElseIf FRMSTRING = "IPCA_COA" Then
                If ClientName = "RUTVIJ" Then
                    CRPO.ReportSource = RPTIPCAREPORTRUTVIJ
                ElseIf ClientName = "AMR" Then
                    CRPO.ReportSource = RPTIPCAREPORTRUTVIJ
                Else
                    CRPO.ReportSource = RPTIPCAREPORT
                End If
            ElseIf FRMSTRING = "SANDOZ_COA" Then
                If ClientName = "RUTVIJ" Then
                    CRPO.ReportSource = RPTSANDOZREPORTRUTVIJ
                ElseIf ClientName = "AMR" Then
                    CRPO.ReportSource = RPTSANDOZREPORTRUTVIJ
                Else
                    CRPO.ReportSource = RPTSANDOZREPORT_IYMP
                End If

            ElseIf FRMSTRING = "FAMYCARE_COA" Then
                If ClientName = "RUTVIJ" Then
                    CRPO.ReportSource = RPTFAMYCAREREPORTRUTVIJ
                ElseIf ClientName = "AMR" Then
                    CRPO.ReportSource = RPTFAMYCAREREPORTRUTVIJ
                Else
                    CRPO.ReportSource = RPTFAMYCAREREPORT
                End If
            ElseIf FRMSTRING = "BIOCON_COA" Then
                CRPO.ReportSource = RPTBIOCONREPORT

            ElseIf FRMSTRING = "ALKEM_COA" Then
                CRPO.ReportSource = RPTALKEMCOAREPORT

            ElseIf FRMSTRING = "SUN_COA" Then
                CRPO.ReportSource = RPTSUNCOAREPORT

            ElseIf FRMSTRING = "SHALINA_COA" Then
                CRPO.ReportSource = RPTSHALINACOAREPORT

            ElseIf FRMSTRING = "MILAN_COA" Then
                CRPO.ReportSource = RPTMILANCOAREPORT
            End If

            CRPO.Zoom(100)
            CRPO.Refresh()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaleInvoiceDesign_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
        Dim tempattachment As String = ""



        Try
            Dim objmail As New SendMail

            If FRMSTRING = "INVOICE" Then
                tempattachment = "INVOICEREPORT"
                objmail.subject = "Invoice"
            ElseIf FRMSTRING = "INVOICEQCREPORT" Then
                tempattachment = "INVOICEQC"
                objmail.subject = "Invoice QC"
            ElseIf FRMSTRING = "ASSEMBLYQC" Then
                tempattachment = "ASSEMBLYQC"
                objmail.subject = "Invoice QC"
            ElseIf FRMSTRING = "COA" Then
                tempattachment = "COAREPORT"
            ElseIf FRMSTRING = "COMMONCOA" Or "CHALLANCOA" Then
                tempattachment = "COMMONCOA"
            ElseIf FRMSTRING = "MSNCOA" Then
                tempattachment = "MSNCOA"
            ElseIf FRMSTRING = "IPCA_COA" Then
                tempattachment = "IPCAREPORT"
            ElseIf FRMSTRING = "SANDOZ_COA" Then
                tempattachment = "SANDOZREPORT"
            ElseIf FRMSTRING = "FAMYCARE_COA" Then
                tempattachment = "FAMYCAREREPORT"
            ElseIf FRMSTRING = "BIOCON_COA" Then
                tempattachment = "BIOCONREPORT"
            ElseIf FRMSTRING = "ALKEM_COA" Then
                tempattachment = "ALKEMREPORT"
            ElseIf FRMSTRING = "SUN_COA" Then
                tempattachment = "SUNREPORT"
            ElseIf FRMSTRING = "SHALINA_COA" Then
                tempattachment = "SHALINAREPORT"
            ElseIf FRMSTRING = "MILAN_COA" Then
                tempattachment = "MILANREPORT"
            Else
                tempattachment = "INVOICE"
            End If

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

            If FRMSTRING = "INVOICEDTLS" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\INVOICE.pdf"
                expo = RPTINVDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINVDTLS.Export()
            ElseIf FRMSTRING = "INVOICESUMM" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\INVOICE.pdf"
                expo = RPTINVSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINVSUMM.Export()
            ElseIf FRMSTRING = "PARTYWISEDTLS" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\INVOICE.pdf"
                expo = RPTPARTYDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPARTYDTLS.Export()
            ElseIf FRMSTRING = "PARTYWISESUMM" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\INVOICE.pdf"
                expo = RPTPARTYSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPARTYSUMM.Export()

            ElseIf FRMSTRING = "ITEMWISEDTLS" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\INVOICE.pdf"
                expo = RPTITEMDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTITEMDTLS.Export()
            ElseIf FRMSTRING = "ITEMWISESUMM" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\INVOICE.pdf"
                expo = RPTITEMSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTITEMSUMM.Export()



            ElseIf FRMSTRING = "INVOICE" Then
                RPTINVOICE.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                oDfDopt.DiskFileName = Application.StartupPath & "\INVOICEREPORT.PDF"
                expo = RPTINVOICE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINVOICE.Export()
                RPTINVOICE.DataDefinition.FormulaFields("SENDMAIL").Text = 0

            ElseIf FRMSTRING = "INVOICEQCREPORT" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\INVOICEQC.pdf"
                expo = RPTINVOICEQC.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINVOICEQC.Export()

            ElseIf FRMSTRING = "ASSEMBLYQC" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\ASSEMBLYQC.pdf"
                expo = RPTASSEMBLYQCREPORT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTASSEMBLYQCREPORT.Export()

            ElseIf FRMSTRING = "COA" Then
                If ClientName = "RUTVIJ" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\COAREPORT.PDF"
                    expo = RPTCOAREPORTRUTVIJ.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTCOAREPORTRUTVIJ.Export()

                ElseIf ClientName = "AMR" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\COAREPORT.PDF"
                    expo = RPTCOAREPORTAMR.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTCOAREPORTAMR.Export()
                End If

            ElseIf FRMSTRING = "MSNCOA" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\MSNCOA.PDF"
                expo = RPTCOAREPORT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMSNCOAREPORTAMR.Export()

            ElseIf FRMSTRING = "COMMONCOA" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\COMMONCOA.PDF"
                expo = RPTCOAREPORT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCOAREPORT.Export()

            ElseIf FRMSTRING = "CHALLANCOA" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\COMMONCOA.PDF"
                expo = RPTCHALLANCOAREPORT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCHALLANCOAREPORT.Export()

            ElseIf FRMSTRING = "IPCA_COA" Then
                If ClientName = "RUTVIJ" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\IPCAREPORT.PDF"
                    expo = RPTIPCAREPORTRUTVIJ.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTIPCAREPORTRUTVIJ.Export()
                ElseIf ClientName = "AMR" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\IPCAREPORT.PDF"
                    expo = RPTIPCAREPORTRUTVIJ.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTIPCAREPORTRUTVIJ.Export()
                Else
                    oDfDopt.DiskFileName = Application.StartupPath & "\IPCAREPORT.PDF"
                    expo = RPTIPCAREPORT.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTIPCAREPORT.Export()
                End If
            ElseIf FRMSTRING = "SANDOZ_COA" Then
                If ClientName = "RUTVIJ" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\SANDOZREPORT.PDF"
                    expo = RPTSANDOZREPORTRUTVIJ.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTSANDOZREPORTRUTVIJ.Export()
                ElseIf ClientName = "AMR" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\SANDOZREPORT.PDF"
                    expo = RPTSANDOZREPORTRUTVIJ.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTSANDOZREPORTRUTVIJ.Export()
                Else
                    oDfDopt.DiskFileName = Application.StartupPath & "\SANDOZREPORT.PDF"
                    expo = RPTSANDOZREPORT_IYMP.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTSANDOZREPORT_IYMP.Export()
                End If

            ElseIf FRMSTRING = "FAMYCARE_COA" Then
                If ClientName = "RUTVIJ" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\FAMYCAREREPORT.PDF"
                    expo = RPTFAMYCAREREPORTRUTVIJ.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTFAMYCAREREPORTRUTVIJ.Export()
                ElseIf ClientName = "AMR" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\FAMYCAREREPORT.PDF"
                    expo = RPTFAMYCAREREPORTRUTVIJ.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTFAMYCAREREPORTRUTVIJ.Export()
                Else
                    oDfDopt.DiskFileName = Application.StartupPath & "\FAMYCAREREPORT.PDF"
                    expo = RPTFAMYCAREREPORT.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTFAMYCAREREPORT.Export()
                End If


            ElseIf FRMSTRING = "BIOCON_COA" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\BIOCONREPORT.PDF"
                expo = RPTBIOCONREPORT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBIOCONREPORT.Export()

            ElseIf FRMSTRING = "ALKEM_COA" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\ALKEMREPORT.PDF"
                expo = RPTALKEMCOAREPORT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTALKEMCOAREPORT.Export()

            ElseIf FRMSTRING = "SUN_COA" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\SUNREPORT.PDF"
                expo = RPTSUNCOAREPORT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSUNCOAREPORT.Export()

            ElseIf FRMSTRING = "SHALINA_COA" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\SHALINAREPORT.PDF"
                expo = RPTSHALINACOAREPORT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSHALINACOAREPORT.Export()

            ElseIf FRMSTRING = "MILAN_COA" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\MILANREPORT.PDF"
                expo = RPTMILANCOAREPORT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMILANCOAREPORT.Export()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTDIRECTLYTOPRINTER()
        Try
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldDefinition As ParameterFieldDefinition
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue

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

            'strsearch = strsearch & " {HOLIDAYPACKAGEMASTER.BOOKING_NO}= " & BOOKINGNO & " AND {HOLIDAYPACKAGEMASTER.BOOKING_cmpid}=" & CmpId & " and {HOLIDAYPACKAGEMASTER.BOOKING_locationid}=" & Locationid & " and {HOLIDAYPACKAGEMASTER.BOOKING_yearid}=" & YearId
            'strsearch = strsearch & " {HOLIDAYPACKAGEMASTER.BOOKING_NO}= " & BOOKINGNO & " and {HOLIDAYPACKAGEMASTER.BOOKING_yearid}=" & YearId
            'If FRMSTRING = "ASSEMBLYQC" Then
            '    WHERECLAUSE = "{ASSEMBLYQC.AS_NO}=" & INVNO & "  and {ASSEMBLYQC.AS_YEARID}=" & YearId
            'Else
            '    WHERECLAUSE = 
            'End If

            CRPO.SelectionFormula = WHERECLAUSE

            Dim OBJ As New Object
            Dim OBJOLD As New Object
            If FRMSTRING = "INVOICE" Then
                Me.Text = "Sale Invoice"
                OBJ = New InvoiceReportNew
            End If

            'CHECK WHETHER BOOKINGDATE IS IN GST OR OLD FORMAT
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("INVOICE_DATE AS DATE", "", "INVOICEMASTER ", " AND INVOICE_NO = " & Val(INVNO) & " AND INVOICE_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                If Convert.ToDateTime(DT.Rows(0).Item("DATE")).Date <= "2017-06-30" Then
                    crTables = OBJOLD.Database.Tables
                    For Each crTable In crTables
                        crtableLogonInfo = crTable.LogOnInfo
                        crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                        crTable.ApplyLogOnInfo(crtableLogonInfo)
                    Next

                    OBJOLD.RecordSelectionFormula = WHERECLAUSE
                    OBJOLD.PrintToPrinter(1, True, 0, 0)
                Else
                    crTables = OBJ.Database.Tables
                    For Each crTable In crTables
                        crtableLogonInfo = crTable.LogOnInfo
                        crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                        crTable.ApplyLogOnInfo(crtableLogonInfo)
                    Next

                    OBJ.RecordSelectionFormula = WHERECLAUSE
                    OBJ.PrintToPrinter(1, True, 0, 0)
                End If
            Else
                Exit Sub
            End If
            'crTables = OBJ.Database.Tables

            'For Each crTable In crTables
            '    crtableLogonInfo = crTable.LogOnInfo
            '    crtableLogonInfo.ConnectionInfo = crConnecttionInfo
            '    crTable.ApplyLogOnInfo(crtableLogonInfo)
            'Next

            'OBJ.RecordSelectionFormula = strsearch          
            'OBJ.PrintToPrinter(1, True, 0, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLDIGITALSIGN_Click(sender As Object, e As EventArgs) Handles TOOLDIGITALSIGN.Click
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions
            If FRMSTRING = "INVOICE" Then
                RPTINVOICE.DataDefinition.FormulaFields("DIGITALSIGN").Text = 1
                oDfDopt.DiskFileName = Application.StartupPath & "\INVOICEREPORT.PDF"
                expo = RPTINVOICE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINVOICE.Export()
                RPTINVOICE.DataDefinition.FormulaFields("DIGITALSIGN").Text = 0


                For Each cert As X509Certificate2 In SelectCertificates()
                    lbCerts.Items.Add(New CertItem() With {.Name = cert.Subject, .Cert = cert})
                Next cert
                lbCerts.SelectedIndex = 0


                Dim documentProcessor As New PdfDocumentProcessor()
                Dim fileHelper As New PdfFileHelper(documentProcessor, pdfViewer)
                Dim path As String = Application.StartupPath & "\INVOICEREPORT.PDF"
                documentProcessor.LoadDocument(path)
                pdfViewer.LoadDocument(path)

                If Directory.Exists(Application.StartupPath & "\INVOICEPDF") = False Then Directory.CreateDirectory(Application.StartupPath & "\INVOICEPDF")

                Dim fileName As String = Application.StartupPath & "\INVOICEPDF\INVOICE_" & Val(INVNO) & "-" & Val(AccFrom.Year) & ".pdf" 'fileHelper.SaveFileDialog() 'Application.StartupPath & "\INVOICE.pdf"
                If (Not String.IsNullOrEmpty(fileName)) Then
                    documentProcessor.Document.Creator = "Nakoda Infotech"
                    documentProcessor.Document.Producer = "Nakoda Infotech"
                    Dim signature As New PdfSignature((CType(lbCerts.SelectedItem, CertItem)).Cert) With {.Location = "", .ContactInfo = "", .Reason = ""}
                    Try
                        documentProcessor.SaveDocument(fileName, New PdfSaveOptions() With {.Signature = signature})
                    Catch exception As CryptographicException
                        XtraMessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
                MsgBox("Pdf Generated Successfully")
                documentProcessor.Dispose()

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class