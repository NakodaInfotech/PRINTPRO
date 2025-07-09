
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports BL

Public Class ShipperDesign

    Public WHERECLAUSE As String
    Public FRMSTRING As String
    Public PERIOD As String
    Public registername As String
    Public FROMDATE As Date
    Public TODATE As Date
    Public strsearch As String
    Public CHNO As Integer
    Public JOBNO As Integer
    Public DTBATCH As DataTable
    

    Dim RPTSHIPPER As New ShipperReport
    Dim RPTSHIPPER_AMR As New ShipperReport_AMR
    Dim RPTSHIPPER_RUTVIJ As New ShipperReport_Rutvij
    Dim RPTBIOCONSHIPPER As New BioconShipperReport
    Dim RPTSANDOZSHIPPER As New SandozShipperReport
    Dim RPTBIOCONSHIPPER_AMR As New BioconShipperReport_AMR

    Private Sub ShipperDesign_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub ShipperDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim OBJCMN As New ClsCommon
            Dim DTNEW As New DataTable
            Dim DT As DataTable = OBJCMN.Execute_Any_String("DELETE FROM TEMPSHIPPER", " ", " WHERE TEMPSHIPPER.CHALLAN_YEARID = " & YearId)

            'DONE BY GULKIT
            'DT = OBJCMN.search("CHALLANMASTER_DESC.CHALLAN_ITEMID AS ITEMID, CHALLANMASTER.challan_pono AS PONO, CHALLANMASTER.challan_podate AS PODATE, CHALLANMASTER.CHALLAN_QTY AS QTY,CHALLANMASTER.CHALLAN_ORDERNO AS ORDERNO, CHALLANMASTER.challan_no AS CHALLANNO, CHALLANMASTER.challan_date AS CHALLANDATE, CHALLANMASTER_DESC.CHALLAN_BATCHNO AS BATCHNO,CHALLANMASTER_DESC.CHALLAN_SHIPPER AS SHIPPERS, CHALLANMASTER.challan_ledgerid AS LEDGERID, CHALLANMASTER.challan_cmpid as cmpid, CHALLANMASTER.challan_yearid as yearid ", "", "CHALLANMASTER INNER JOIN CHALLANMASTER_DESC ON CHALLANMASTER.challan_no = CHALLANMASTER_DESC.CHALLAN_NO AND CHALLANMASTER.challan_yearid = CHALLANMASTER_DESC.CHALLAN_YEARID", "AND CHALLANMASTER.CHALLAN_NO = " & CHNO & " AND CHALLANMASTER.CHALLAN_CMPID = " & CmpId & " AND CHALLANMASTER.CHALLAN_YEARID = " & YearId)
            'If DT.Rows.Count > 0 Then
            '    For I As Integer = 1 To Val(DT.Rows(0).Item("SHIPPERS"))
            '        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String(" INSERT INTO TEMPSHIPPER VALUES (" & DT.Rows(0).Item("CHALLANNO") & ",'" & Format(Convert.ToDateTime(DT.Rows(0).Item("CHALLANDATE")).Date, "MM/dd/yyyy") & "', " & DT.Rows(0).Item("LEDGERID") & "," & DT.Rows(0).Item("ORDERNO") & ",'" & DT.Rows(0).Item("PONO") & "','" & Format(Convert.ToDateTime(DT.Rows(0).Item("PODATE")).Date, "dd/MM/yyyy") & "'," & DT.Rows(0).Item("ITEMID") & "," & DT.Rows(0).Item("QTY") & ",'" & DT.Rows(0).Item("BATCHNO") & "','" & I & "/" & Val(DT.Rows(0).Item("SHIPPERS")) & "'," & DT.Rows(0).Item("CMPID") & "," & DT.Rows(0).Item("YEARID") & ") ", "", "")
            '    Next
            'End If

            '******** START OF NEW CODE *************
            If ClientName = "IYMP" Then
                DT = OBJCMN.search(" job_shipperitem1, job_shipperitem2, job_shipperitem3, job_shipper1, job_shipper2, job_shipper3 ", "", " jobmaster ", " and job_no = " & JOBNO & " and job_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    Dim K As Integer = 1
                    For i = 3 To 5
                        For j = 1 To Val(DT.Rows(0).Item(i))
                            DTNEW = OBJCMN.search("CHALLANMASTER_DESC.CHALLAN_ITEMID AS ITEMID, CHALLANMASTER.challan_pono AS PONO, CHALLANMASTER.challan_podate AS PODATE, CHALLANMASTER.CHALLAN_QTY AS QTY,CHALLANMASTER.CHALLAN_ORDERNO AS ORDERNO, CHALLANMASTER.challan_no AS CHALLANNO, CHALLANMASTER.challan_date AS CHALLANDATE, CHALLANMASTER_DESC.CHALLAN_BATCHNO AS BATCHNO,CHALLANMASTER.CHALLAN_SHIPPERS AS SHIPPERS, CHALLANMASTER.challan_ledgerid AS LEDGERID, CHALLANMASTER.challan_cmpid as cmpid, CHALLANMASTER.challan_yearid as yearid, ISNULL(CHALLANMASTER.CHALLAN_MFGDATE,CHALLANMASTER.CHALLAN_DATE) AS MFGDATE ", "", "CHALLANMASTER INNER JOIN CHALLANMASTER_DESC ON CHALLANMASTER.challan_no = CHALLANMASTER_DESC.CHALLAN_NO AND CHALLANMASTER.challan_yearid = CHALLANMASTER_DESC.CHALLAN_YEARID", "AND CHALLANMASTER.CHALLAN_NO = " & CHNO & " AND CHALLANMASTER.CHALLAN_CMPID = " & CmpId & " AND CHALLANMASTER.CHALLAN_YEARID = " & YearId & " ORDER BY CHALLANMASTER_DESC.CHALLAN_SRNO ")
                            'Dim DTINSERT As DataTable = OBJCMN.Execute_Any_String(" INSERT INTO TEMPSHIPPER VALUES (" & DTNEW.Rows(0).Item("CHALLANNO") & ",'" & Format(Convert.ToDateTime(DTNEW.Rows(0).Item("CHALLANDATE")).Date, "MM/dd/yyyy") & "', " & DTNEW.Rows(0).Item("LEDGERID") & "," & DTNEW.Rows(0).Item("ORDERNO") & ",'" & DTNEW.Rows(0).Item("PONO") & "','" & Format(Convert.ToDateTime(DTNEW.Rows(0).Item("PODATE")).Date, "dd/MM/yyyy") & "'," & DTNEW.Rows(0).Item("ITEMID") & "," & Val(DT.Rows(0).Item(i - 3)) & ",'" & DTNEW.Rows(0).Item("BATCHNO") & "','" & j & "/" & Val(DT.Rows(0).Item(i)) & "'," & DTNEW.Rows(0).Item("CMPID") & "," & DTNEW.Rows(0).Item("YEARID") & "," & j & ") ", "", "")
                            Dim DTINSERT As DataTable = OBJCMN.Execute_Any_String(" INSERT INTO TEMPSHIPPER VALUES (" & DTNEW.Rows(0).Item("CHALLANNO") & ",'" & Format(Convert.ToDateTime(DTNEW.Rows(0).Item("CHALLANDATE")).Date, "MM/dd/yyyy") & "','" & Format(Convert.ToDateTime(DTNEW.Rows(0).Item("MFGDATE")).Date, "MM/dd/yyyy") & "', " & DTNEW.Rows(0).Item("LEDGERID") & "," & DTNEW.Rows(0).Item("ORDERNO") & ",'" & DTNEW.Rows(0).Item("PONO") & "','" & Format(Convert.ToDateTime(DTNEW.Rows(0).Item("PODATE")).Date, "MM/dd/yyyy") & "'," & DTNEW.Rows(0).Item("ITEMID") & "," & Val(DT.Rows(0).Item(i - 3)) & ",'" & DTNEW.Rows(0).Item("BATCHNO") & "','" & K & "/" & Val(DTNEW.Rows(0).Item("SHIPPERS")) & "'," & DTNEW.Rows(0).Item("CMPID") & "," & DTNEW.Rows(0).Item("YEARID") & "," & K & ",'', '') ", "", "")
                            K = K + 1
                        Next
                    Next
                End If
            Else
                Dim OBJCHALLAN As New Challan
                If DTBATCH.Rows.Count > 0 Then
                    For Each ROW As DataRow In DTBATCH.Rows
                        DT = OBJCMN.search(" jobbatch_shipperitem1, jobbatch_shipperitem2, jobbatch_shipperitem3, jobbatch_shipper1, jobbatch_shipper2, jobbatch_shipper3, jobbatch_packetitem1, jobbatch_packetitem2, jobbatch_packetitem3, jobbatch_packet1, jobbatch_packet2, jobbatch_packet3 ", "", " BATCHMASTER ", " and jobbatch_no = " & ROW("CBATCHNO") & " and jobbatch_YEARID = " & YearId)
                        If DT.Rows.Count > 0 Then
                            Dim K As Integer = 1
                            For i = 3 To 5
                                For j = 1 To Val(DT.Rows(0).Item(i))
                                    DTNEW = OBJCMN.search("CHALLANMASTER_DESC.CHALLAN_ITEMID AS ITEMID, CHALLANMASTER.challan_pono AS PONO, CHALLANMASTER.challan_podate AS PODATE, CHALLANMASTER.CHALLAN_QTY AS QTY,CHALLANMASTER.CHALLAN_ORDERNO AS ORDERNO, CHALLANMASTER.challan_no AS CHALLANNO, CHALLANMASTER.challan_date AS CHALLANDATE, CHALLANMASTER_DESC.CHALLAN_BATCHNO AS BATCHNO,CHALLANMASTER.CHALLAN_SHIPPERS AS SHIPPERS, CHALLANMASTER.challan_ledgerid AS LEDGERID, CHALLANMASTER.challan_cmpid as cmpid, CHALLANMASTER.challan_yearid as yearid, cmp_invinitials AS CMPINITIALS, ISNULL(CHALLANMASTER.CHALLAN_MFGDATE, CHALLANMASTER.CHALLAN_DATE) AS MFGDATE, CHALLANMASTER.CHALLAN_SHIPPER1 AS SHIPPER1, CHALLANMASTER.CHALLAN_SHIPPER2 AS SHIPPER2, CHALLANMASTER.CHALLAN_SHIPPER3 AS SHIPPER3 ", "", "CHALLANMASTER INNER JOIN CHALLANMASTER_DESC ON CHALLANMASTER.challan_no = CHALLANMASTER_DESC.CHALLAN_NO AND CHALLANMASTER.challan_yearid = CHALLANMASTER_DESC.CHALLAN_YEARID INNER JOIN CMPMASTER ON CHALLANMASTER.CHALLAN_CMPID = CMP_ID INNER JOIN YEARMASTER ON CHALLANMASTER.CHALLAN_YEARID = YEAR_ID", "AND CHALLANMASTER.CHALLAN_NO = " & CHNO & " AND CHALLANMASTER.CHALLAN_CMPID = " & CmpId & " AND CHALLANMASTER.CHALLAN_YEARID = " & YearId & " ORDER BY CHALLANMASTER_DESC.CHALLAN_SRNO ")
                                    Dim DTINSERT As New DataTable
                                    If i = 3 Then
                                        DTINSERT = OBJCMN.Execute_Any_String(" INSERT INTO TEMPSHIPPER VALUES (" & DTNEW.Rows(0).Item("CHALLANNO") & ",'" & Format(Convert.ToDateTime(DTNEW.Rows(0).Item("CHALLANDATE")).Date, "MM/dd/yyyy") & "','" & Format(Convert.ToDateTime(DTNEW.Rows(0).Item("MFGDATE")).Date, "MM/dd/yyyy") & "', " & DTNEW.Rows(0).Item("LEDGERID") & "," & DTNEW.Rows(0).Item("ORDERNO") & ",'" & DTNEW.Rows(0).Item("PONO") & "','" & Format(Convert.ToDateTime(DTNEW.Rows(0).Item("PODATE")).Date, "MM/dd/yyyy") & "'," & DTNEW.Rows(0).Item("ITEMID") & "," & Val(DT.Rows(0).Item(i - 3)) & ",'" & DTNEW.Rows(0).Item("CMPINITIALS") & "/" & Format(Convert.ToDateTime(AccFrom).Date, "yy") & "-" & Format(Convert.ToDateTime(AccTo).Date, "yy") & "/" & Val(ROW("CBATCHNO")).ToString("0000") & "','" & K & "/" & Val(DTNEW.Rows(0).Item("SHIPPERS")) & "'," & DTNEW.Rows(0).Item("CMPID") & "," & DTNEW.Rows(0).Item("YEARID") & "," & K & "," & "'" & DTNEW.Rows(0).Item("SHIPPER1") & "'" & ", '') ", "", "")
                                    ElseIf i = 4 Then
                                        DTINSERT = OBJCMN.Execute_Any_String(" INSERT INTO TEMPSHIPPER VALUES (" & DTNEW.Rows(0).Item("CHALLANNO") & ",'" & Format(Convert.ToDateTime(DTNEW.Rows(0).Item("CHALLANDATE")).Date, "MM/dd/yyyy") & "','" & Format(Convert.ToDateTime(DTNEW.Rows(0).Item("MFGDATE")).Date, "MM/dd/yyyy") & "', " & DTNEW.Rows(0).Item("LEDGERID") & "," & DTNEW.Rows(0).Item("ORDERNO") & ",'" & DTNEW.Rows(0).Item("PONO") & "','" & Format(Convert.ToDateTime(DTNEW.Rows(0).Item("PODATE")).Date, "MM/dd/yyyy") & "'," & DTNEW.Rows(0).Item("ITEMID") & "," & Val(DT.Rows(0).Item(i - 3)) & ",'" & DTNEW.Rows(0).Item("CMPINITIALS") & "/" & Format(Convert.ToDateTime(AccFrom).Date, "yy") & "-" & Format(Convert.ToDateTime(AccTo).Date, "yy") & "/" & Val(ROW("CBATCHNO")).ToString("0000") & "','" & K & "/" & Val(DTNEW.Rows(0).Item("SHIPPERS")) & "'," & DTNEW.Rows(0).Item("CMPID") & "," & DTNEW.Rows(0).Item("YEARID") & "," & K & "," & "'" & DTNEW.Rows(0).Item("SHIPPER2") & "'" & ", '') ", "", "")
                                    Else
                                        DTINSERT = OBJCMN.Execute_Any_String(" INSERT INTO TEMPSHIPPER VALUES (" & DTNEW.Rows(0).Item("CHALLANNO") & ",'" & Format(Convert.ToDateTime(DTNEW.Rows(0).Item("CHALLANDATE")).Date, "MM/dd/yyyy") & "','" & Format(Convert.ToDateTime(DTNEW.Rows(0).Item("MFGDATE")).Date, "MM/dd/yyyy") & "', " & DTNEW.Rows(0).Item("LEDGERID") & "," & DTNEW.Rows(0).Item("ORDERNO") & ",'" & DTNEW.Rows(0).Item("PONO") & "','" & Format(Convert.ToDateTime(DTNEW.Rows(0).Item("PODATE")).Date, "MM/dd/yyyy") & "'," & DTNEW.Rows(0).Item("ITEMID") & "," & Val(DT.Rows(0).Item(i - 3)) & ",'" & DTNEW.Rows(0).Item("CMPINITIALS") & "/" & Format(Convert.ToDateTime(AccFrom).Date, "yy") & "-" & Format(Convert.ToDateTime(AccTo).Date, "yy") & "/" & Val(ROW("CBATCHNO")).ToString("0000") & "','" & K & "/" & Val(DTNEW.Rows(0).Item("SHIPPERS")) & "'," & DTNEW.Rows(0).Item("CMPID") & "," & DTNEW.Rows(0).Item("YEARID") & "," & K & "," & "'" & DTNEW.Rows(0).Item("SHIPPER3") & "'" & ", '') ", "", "")
                                    End If
                                    K = K + 1
                                Next
                            Next
                        End If
                    Next
                End If
            End If
            '******** END OF NEW CODE *************

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

            If FRMSTRING = "SHIPPER" Then
                If ClientName = "AMR" Then
                    crTables = RPTSHIPPER_AMR.Database.Tables
                ElseIf ClientName = "RUTVIJ" Then
                    crTables = RPTSHIPPER_RUTVIJ.Database.Tables
                Else
                    crTables = RPTSHIPPER.Database.Tables
                End If

            ElseIf FRMSTRING = "BIOCON_SHIPPER" Then
                If ClientName = "AMR" Then
                    crTables = RPTBIOCONSHIPPER_AMR.Database.Tables
                Else
                    crTables = RPTBIOCONSHIPPER.Database.Tables
                End If

            ElseIf FRMSTRING = "SANDOZ_SHIPPER" Then
                crTables = RPTSANDOZSHIPPER.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            CRPO.SelectionFormula = WHERECLAUSE

            If FRMSTRING = "SHIPPER" Then
                If ClientName = "AMR" Then
                    CRPO.ReportSource = RPTSHIPPER_AMR
                ElseIf ClientName = "RUTVIJ" Then
                    CRPO.ReportSource = RPTSHIPPER_RUTVIJ
                Else
                    CRPO.ReportSource = RPTSHIPPER
                End If
            ElseIf FRMSTRING = "BIOCON_SHIPPER" Then
                If ClientName = "AMR" Then
                    CRPO.ReportSource = RPTBIOCONSHIPPER_AMR
                Else
                    CRPO.ReportSource = RPTBIOCONSHIPPER
                End If
            ElseIf FRMSTRING = "SANDOZ_SHIPPER" Then
                CRPO.ReportSource = RPTSANDOZSHIPPER
            End If
            CRPO.Zoom(100)
            CRPO.Refresh()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SendMailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendMailtool.Click
        Dim emailid As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        TRANSFER()
        Dim tempattachment As String = ""

        tempattachment = "SHIPPER"

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
            oDfDopt.DiskFileName = Application.StartupPath & "\SHIPPER.PDF"

            If FRMSTRING = "SHIPPER" Then
                If ClientName = "AMR" Then
                    expo = RPTSHIPPER_AMR.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTSHIPPER_AMR.Export()
                ElseIf ClientName = "RUTVIJ" Then
                    expo = RPTSHIPPER_RUTVIJ.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTSHIPPER_RUTVIJ.Export()
                Else
                    expo = RPTSHIPPER.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTSHIPPER.Export()
                End If
            ElseIf FRMSTRING = "BIOCON SHIPPER" Then
                If ClientName = "AMR" Then
                    expo = RPTBIOCONSHIPPER_AMR.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTBIOCONSHIPPER_AMR.Export()
                Else
                    expo = RPTBIOCONSHIPPER.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTBIOCONSHIPPER.Export()

                End If

            ElseIf FRMSTRING = "SANDOZ SHIPPER" Then
                expo = RPTSANDOZSHIPPER.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSANDOZSHIPPER.Export()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class