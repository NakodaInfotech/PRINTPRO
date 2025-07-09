
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class GRNDesign

    Public FRMSTRING As String
    Public WHERECLAUSE As String
    Public PERIOD As String
    Public SHOWHEADER As Boolean
    Public SHOWPRINTDATE As Boolean
    Public SHOWADDRESS As Boolean
    Public NEWPAGE As Boolean
    Public DIRECTPRINT As Boolean
    Public DIRECTMAIL As Boolean = False
    Public DIRECTWHATSAPP As Boolean = False
    Public PRINTSETTING As Object = Nothing
    Public NOOFCOPIES As Integer = 1
    Public GRNNO As Integer = 0




    Dim RPTDTLS As New GRNDetailReport
    Dim RPTSUMM As New GRNSummary
    Dim RPTPARTYDTLS As New GRNPartyWiseDetails
    Dim RPTPARTYSUMM As New GRNPartyWiseSummary
    Dim RPTGODOWNDTLS As New GRNGodownWiseDetails
    Dim RPTGODOWNSUMM As New GRNGodownWiseSummary
    Dim RPTITEMDTLS As New GRNItemWiseDetails
    Dim RPTItemSUMM As New GRNItemWiseSummary
    Dim RPTTRANSDTLS As New GRNTransWiseDetails
    Dim RPTTRANSSUMM As New GRNTransWiseSummary
    Dim RPTMONTHLY As New GRNMonthWise
    Dim RPTQTYWISE As New GRNGodownQtyWise
    Dim RPTGRN_UNDERTEST As New GRNReport
    Dim RPTGRN_RUTVIJ As New GRNReport_Rutvij

    Dim RPTGRN As New StoresInwardReport

    Private Sub GRNDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub


    Private Sub GRNDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If DIRECTPRINT = True Then
                PRINTDIRECTADVICE()
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

            If FRMSTRING = "GRN" Then
                If ClientName = "RUTVIJ" Then
                    crTables = RPTGRN_RUTVIJ.Database.Tables
                ElseIf ClientName = "AMR" Then
                    crTables = RPTGRN_UNDERTEST.Database.Tables
                Else
                    crTables = RPTGRN.Database.Tables
                End If
            End If

            If FRMSTRING = "GRNDTLS" Then crTables = RPTDTLS.Database.Tables
            If FRMSTRING = "GRNSUMM" Then crTables = RPTSUMM.Database.Tables

            If FRMSTRING = "PARTYWISEDTLS" Then crTables = RPTPARTYDTLS.Database.Tables
            If FRMSTRING = "PARTYWISESUMM" Then crTables = RPTPARTYSUMM.Database.Tables

            If FRMSTRING = "GODOWNWISEDTLS" Then crTables = RPTGODOWNDTLS.Database.Tables
            If FRMSTRING = "GODOWNWISESUMM" Then crTables = RPTGODOWNSUMM.Database.Tables

            If FRMSTRING = "ITEMWISEDTLS" Then crTables = RPTITEMDTLS.Database.Tables
            If FRMSTRING = "ITEMWISESUMM" Then crTables = RPTItemSUMM.Database.Tables

            If FRMSTRING = "TRANSWISEDTLS" Then crTables = RPTTRANSDTLS.Database.Tables
            If FRMSTRING = "TRANSWISESUMM" Then crTables = RPTTRANSSUMM.Database.Tables


            If FRMSTRING = "MONTHLY" Then crTables = RPTMONTHLY.Database.Tables

            If FRMSTRING = "QTYWISE" Then crTables = RPTQTYWISE.Database.Tables

            'Dim OBJ As New Object
            'If FRMSTRING = "GRNDTLS" Then
            '    OBJ = New GRNDetailReport
            'End If
            'crTables = OBJ.Database.Tables


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = WHERECLAUSE
            'If DIRECTMAIL = False And DIRECTWHATSAPP = False Then
            '    OBJ.PrintOptions.PrinterName = PRINTSETTING.PrinterSettings.PrinterName
            '    OBJ.PrintToPrinter(Val(NOOFCOPIES), True, 0, 0)
            'Else
            '    Dim expo As New ExportOptions
            '    Dim oDfDopt As New DiskFileDestinationOptions
            '    oDfDopt.DiskFileName = Application.StartupPath & "\GRN_" & GRNNO & ".pdf"

            '    'CHECK WHETHER FILE IS PRESENT OR NOT, IF PRESENT THEN DELETE FIRST AND THEN EXPORT
            '    If File.Exists(oDfDopt.DiskFileName) Then File.Delete(oDfDopt.DiskFileName)
            '    OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
            '    expo = OBJ.ExportOptions
            '    expo.ExportDestinationType = ExportDestinationType.DiskFile
            '    expo.ExportFormatType = ExportFormatType.PortableDocFormat
            '    expo.DestinationOptions = oDfDopt
            '    OBJ.Export()
            '    OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = "0"
            'End If


            If FRMSTRING = "GRN" Then
                If ClientName = "RUTVIJ" Then
                    crpo.ReportSource = RPTGRN_RUTVIJ
                ElseIf ClientName = "AMR" Then
                    crpo.ReportSource = RPTGRN_UNDERTEST
                Else
                    crpo.ReportSource = RPTGRN
                End If

            ElseIf FRMSTRING = "GRNDTLS" Then
                crpo.ReportSource = RPTDTLS
                RPTDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"

            ElseIf FRMSTRING = "GRNSUMM" Then
                crpo.ReportSource = RPTSUMM
                RPTSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"

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

            ElseIf FRMSTRING = "GODOWNWISEDTLS" Then
                crpo.ReportSource = RPTGODOWNDTLS
                RPTGODOWNDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTGODOWNDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTGODOWNDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTGODOWNDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTGODOWNDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"
                If SHOWADDRESS = True Then RPTGODOWNDTLS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'1'" Else RPTGODOWNDTLS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'0'"
                RPTGODOWNDTLS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE

            ElseIf FRMSTRING = "GODOWNWISESUMM" Then
                crpo.ReportSource = RPTGODOWNSUMM
                RPTGODOWNSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTGODOWNSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTGODOWNSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTGODOWNSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTGODOWNSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"


            ElseIf FRMSTRING = "ITEMWISEDTLS" Then
                crpo.ReportSource = RPTITEMDTLS
                RPTITEMDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTITEMDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTITEMDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTITEMDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTITEMDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"
                If SHOWADDRESS = True Then RPTITEMDTLS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'1'" Else RPTITEMDTLS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'0'"
                RPTITEMDTLS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE

            ElseIf FRMSTRING = "ITEMWISESUMM" Then
                crpo.ReportSource = RPTItemSUMM
                RPTItemSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTItemSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTItemSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTItemSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTItemSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"

            ElseIf FRMSTRING = "TRANSWISEDTLS" Then
                crpo.ReportSource = RPTTRANSDTLS
                RPTTRANSDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTTRANSDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTTRANSDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTTRANSDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTTRANSDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"
                If SHOWADDRESS = True Then RPTTRANSDTLS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'1'" Else RPTTRANSDTLS.DataDefinition.FormulaFields("SHOWADDRESS").Text = "'0'"
                RPTTRANSDTLS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE

            ElseIf FRMSTRING = "TRANSWISESUMM" Then
                crpo.ReportSource = RPTTRANSSUMM
                RPTTRANSSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTTRANSSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTTRANSSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTTRANSSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTTRANSSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"


            ElseIf FRMSTRING = "ITEMWISEDTLS" Then
                crpo.ReportSource = RPTITEMDTLS
                RPTITEMDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTITEMDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTITEMDTLS.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTITEMDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTITEMDTLS.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"
                RPTITEMDTLS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE

            ElseIf FRMSTRING = "ITEMWISESUMM" Then
                crpo.ReportSource = RPTItemSUMM
                RPTItemSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTItemSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTItemSUMM.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTItemSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTItemSUMM.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"

            ElseIf FRMSTRING = "MONTHLY" Then
                crpo.ReportSource = RPTMONTHLY
                RPTMONTHLY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTMONTHLY.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTMONTHLY.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTMONTHLY.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTMONTHLY.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"

            ElseIf FRMSTRING = "QTYWISE" Then
                crpo.ReportSource = RPTQTYWISE
                RPTQTYWISE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWHEADER = True Then RPTQTYWISE.DataDefinition.FormulaFields("SHOWHEADER").Text = "'1'" Else RPTQTYWISE.DataDefinition.FormulaFields("SHOWHEADER").Text = "'0'"
                If SHOWPRINTDATE = True Then RPTQTYWISE.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'1'" Else RPTQTYWISE.DataDefinition.FormulaFields("SHOWPRINTDATE").Text = "'0'"
                RPTQTYWISE.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE

            End If

            crpo.Zoom(100)
            crpo.Refresh()



        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Sub PRINTDIRECTADVICE()
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


            Dim OBJ As New Object

            If FRMSTRING = "GRN" Then
                OBJ = New GRNReport

            ElseIf FRMSTRING = "GRNDTLS" Then
                OBJ = New GRNDetailReport
            End If


            crTables = OBJ.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            OBJ.RecordSelectionFormula = WHERECLAUSE

            If DIRECTMAIL = False And DIRECTWHATSAPP = False Then
                OBJ.PrintOptions.PrinterName = PRINTSETTING.PrinterSettings.PrinterName
                OBJ.PrintToPrinter(Val(NOOFCOPIES), True, 0, 0)
            Else
                Dim expo As New ExportOptions
                Dim oDfDopt As New DiskFileDestinationOptions
                oDfDopt.DiskFileName = Application.StartupPath & "\GRN_" & GRNNO & ".pdf"

                'CHECK WHETHER FILE IS PRESENT OR NOT, IF PRESENT THEN DELETE FIRST AND THEN EXPORT
                If File.Exists(oDfDopt.DiskFileName) Then File.Delete(oDfDopt.DiskFileName)
                OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                expo = OBJ.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJ.Export()
                OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = "0"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Try
            Dim emailid As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()
            Dim TEMPATTACHMENT As String = "GRN"
            Try
                Dim objmail As New SendMail
                objmail.attachment = Application.StartupPath & "\" & TEMPATTACHMENT & ".PDF"
                objmail.subject = "GRN REPORT"
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
            oDfDopt.DiskFileName = Application.StartupPath & "\GRN.pdf"


            If FRMSTRING = "GRN=" Then
                If ClientName = "RUTVIJ" Then
                    expo = RPTGRN_RUTVIJ.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTGRN_RUTVIJ.Export()
                ElseIf ClientName = "AMR" Then
                    expo = RPTGRN_UNDERTEST.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTGRN_UNDERTEST.Export()
                Else
                    expo = RPTGRN.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTGRN.Export()
                End If

            ElseIf FRMSTRING = "GRNDTLS" Then
                expo = RPTDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDTLS.Export()
            ElseIf FRMSTRING = "GRNSUMM" Then
                expo = RPTSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSUMM.Export()
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
            ElseIf FRMSTRING = "GODOWNWISEDTLS" Then
                expo = RPTGODOWNDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGODOWNDTLS.Export()
            ElseIf FRMSTRING = "GODOWNWISESUMM" Then
                expo = RPTGODOWNSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGODOWNSUMM.Export()
            ElseIf FRMSTRING = "ITEMWISEDTLS" Then
                expo = RPTITEMDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTITEMDTLS.Export()
            ElseIf FRMSTRING = "ITEMWISESUMM" Then
                expo = RPTItemSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTItemSUMM.Export()

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

            ElseIf FRMSTRING = "MONTHLY" Then
                expo = RPTMONTHLY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMONTHLY.Export()
            ElseIf FRMSTRING = "QTYWISE" Then
                expo = RPTQTYWISE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTQTYWISE.Export()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class