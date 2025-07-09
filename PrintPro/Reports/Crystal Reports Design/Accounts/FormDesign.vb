
Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms

Public Class FormDesign

    Dim RPTCFORMLETTER As New CFormLetterReport

    Dim RPTCFORMPENDINGDTLS As New CFormPendingReport_Details
    Dim RPTCFORMPENDINGSUMM As New CFormPendingReport_Summary
    Dim RPTCFORMRECDDTLS As New CFormRecdReport_Details
    Dim RPTCFORMRECDSUMM As New CFormRecdReport_Summary
    Dim RPTCFORMALLDTLS As New CFormAllReport_Details
    Dim RPTCFORMALLSUMM As New CFormAllReport_Summary


    Public FORMNO As String
    Public STRSEARCH As String
    Public FRMSTRING As String
    Public REPORTTITLE As String
    Public PERIOD As String
    Public NEWPAGE As Boolean

    Public FROMDATE As Date
    Public TODATE As Date
    Public CHECK As Boolean
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, FROMDATE)
        a2 = DatePart(DateInterval.Month, FROMDATE)
        a3 = DatePart(DateInterval.Year, FROMDATE)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, TODATE)
        a12 = DatePart(DateInterval.Month, TODATE)
        a13 = DatePart(DateInterval.Year, TODATE)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Private Sub crpo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles crpo.Load
        Try

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

            If FRMSTRING = "LETTER" Then
                crTables = RPTCFORMLETTER.Database.Tables
            ElseIf FRMSTRING = "PENDINGDTLS" Then
                crTables = RPTCFORMPENDINGDTLS.Database.Tables
            ElseIf FRMSTRING = "PENDINGSUMM" Then
                crTables = RPTCFORMPENDINGSUMM.Database.Tables
            ElseIf FRMSTRING = "RECDDTLS" Then
                crTables = RPTCFORMRECDDTLS.Database.Tables
            ElseIf FRMSTRING = "RECDSUMM" Then
                crTables = RPTCFORMRECDSUMM.Database.Tables
            ElseIf FRMSTRING = "ALLDTLS" Then
                crTables = RPTCFORMALLDTLS.Database.Tables
            ElseIf FRMSTRING = "ALLSUMM" Then
                crTables = RPTCFORMALLSUMM.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            '************************ END *******************
            getFromToDate()

            crpo.SelectionFormula = STRSEARCH
            If FRMSTRING = "LETTER" Then
                RPTCFORMLETTER.DataDefinition.FormulaFields("FORMNO").Text = "'" & FORMNO & "'"
                RPTCFORMLETTER.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTCFORMLETTER.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                crpo.ReportSource = RPTCFORMLETTER
            ElseIf FRMSTRING = "PENDINGDTLS" Then
                RPTCFORMPENDINGDTLS.DataDefinition.FormulaFields("REPORTTITLE").Text = "'" & REPORTTITLE & "'"
                RPTCFORMPENDINGDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTCFORMPENDINGDTLS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                crpo.ReportSource = RPTCFORMPENDINGDTLS
            ElseIf FRMSTRING = "PENDINGSUMM" Then
                RPTCFORMPENDINGSUMM.DataDefinition.FormulaFields("REPORTTITLE").Text = "'" & REPORTTITLE & "'"
                RPTCFORMPENDINGSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTCFORMPENDINGSUMM
            ElseIf FRMSTRING = "RECDDTLS" Then
                RPTCFORMRECDDTLS.DataDefinition.FormulaFields("REPORTTITLE").Text = "'" & REPORTTITLE & "'"
                RPTCFORMRECDDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTCFORMRECDDTLS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                crpo.ReportSource = RPTCFORMRECDDTLS
            ElseIf FRMSTRING = "RECDSUMM" Then
                RPTCFORMRECDSUMM.DataDefinition.FormulaFields("REPORTTITLE").Text = "'" & REPORTTITLE & "'"
                RPTCFORMRECDSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTCFORMRECDSUMM
            ElseIf FRMSTRING = "ALLDTLS" Then
                RPTCFORMALLDTLS.DataDefinition.FormulaFields("REPORTTITLE").Text = "'" & REPORTTITLE & "'"
                RPTCFORMALLDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTCFORMALLDTLS.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
                crpo.ReportSource = RPTCFORMALLDTLS
            ElseIf FRMSTRING = "ALLSUMM" Then
                RPTCFORMALLSUMM.DataDefinition.FormulaFields("REPORTTITLE").Text = "'" & REPORTTITLE & "'"
                RPTCFORMALLSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTCFORMALLSUMM
           End If

            crpo.Zoom(100)
            crpo.Refresh()

        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Dim emailid As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Transfer()
        Dim tempattachment As String = ""

        If FRMSTRING = "Letter Format" Then
            tempattachment = "Form Letter"
        ElseIf FRMSTRING = "FORMPURCHASESUMMARY" Then
            tempattachment = "FORM-PURCHASE"
        ElseIf FRMSTRING = "FORMSALESUMMARY" Then
            tempattachment = "FORM-SALE"
        End If

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

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions

            If FRMSTRING = "Letter Format" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Form Letter.PDF"
                expo = RPTCFORMLETTER.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCFORMLETTER.Export()
             End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub CFormDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class