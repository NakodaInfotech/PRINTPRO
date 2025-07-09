
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports BL

Public Class PacketDesign

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

    Dim RPTPACKET As New PacketReport
    Dim RPTPACKET_AMR As New PacketReport_AMR
    Dim RPTPACKETRUTVIJ As New PacketReportforRutvij

    Private Sub PacketDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub PacketDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor.Current = Cursors.WaitCursor



            Dim OBJCMN As New ClsCommon
            Dim DTNEW As New DataTable
            Dim DT As DataTable = OBJCMN.Execute_Any_String("DELETE FROM TEMPPACKETS", " ", " WHERE TEMPPACKETS.CHALLAN_YEARID = " & YearId)
            'DONE BY GULKIT
            'DT = OBJCMN.search("CHALLANMASTER_DESC.CHALLAN_ITEMID AS ITEMID, CHALLANMASTER.challan_pono AS PONO, CHALLANMASTER.challan_podate AS PODATE, CHALLANMASTER.CHALLAN_QTY AS QTY, CHALLANMASTER.challan_no AS CHALLANNO, CHALLANMASTER.challan_date AS CHALLANDATE, CHALLANMASTER_DESC.CHALLAN_BATCHNO AS BATCHNO,CHALLANMASTER_DESC.CHALLAN_PACKETS AS PACKETS, CHALLANMASTER.challan_ledgerid AS LEDGERID, CHALLANMASTER.challan_cmpid as cmpid, CHALLANMASTER.challan_yearid as yearid ", "", "CHALLANMASTER INNER JOIN CHALLANMASTER_DESC ON CHALLANMASTER.challan_no = CHALLANMASTER_DESC.CHALLAN_NO AND CHALLANMASTER.challan_yearid = CHALLANMASTER_DESC.CHALLAN_YEARID", "AND CHALLANMASTER.CHALLAN_NO = " & CHNO & " AND CHALLANMASTER.CHALLAN_CMPID = " & CmpId & " AND CHALLANMASTER.CHALLAN_YEARID = " & YearId)
            'If DT.Rows.Count > 0 Then
            '    For I As Integer = 1 To Val(DT.Rows(0).Item("PACKETS"))
            '        Dim DTNEW As DataTable = OBJCMN.Execute_Any_String(" INSERT INTO TEMPPACKETS VALUES (" & DT.Rows(0).Item("CHALLANNO") & ",'" & Format(Convert.ToDateTime(DT.Rows(0).Item("CHALLANDATE")).Date, "MM/dd/yyyy") & "', " & DT.Rows(0).Item("LEDGERID") & ",'" & DT.Rows(0).Item("PONO") & "','" & DT.Rows(0).Item("PODATE") & "'," & DT.Rows(0).Item("ITEMID") & "," & DT.Rows(0).Item("QTY") & ",'" & DT.Rows(0).Item("BATCHNO") & "','" & I & "/" & Val(DT.Rows(0).Item("PACKETS")) & "'," & DT.Rows(0).Item("CMPID") & "," & DT.Rows(0).Item("YEARID") & ") ", "", "")
            '    Next
            'End If


            '******** START OF NEW CODE *************
            If ClientName = "IYMP" Then
                DT = OBJCMN.search(" job_packetitem1, job_packetitem2, job_packetitem3, job_packet1, job_packet2, job_packet3 ", "", " jobmaster ", " and job_no = " & JOBNO & " and job_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    Dim K As Integer = 1
                    For i = 3 To 5
                        For j = 1 To Val(DT.Rows(0).Item(i))
                            DTNEW = OBJCMN.search("CHALLANMASTER_DESC.CHALLAN_ITEMID AS ITEMID, CHALLANMASTER.challan_pono AS PONO, CHALLANMASTER.challan_podate AS PODATE, CHALLANMASTER.CHALLAN_QTY AS QTY, CHALLANMASTER.challan_no AS CHALLANNO, CHALLANMASTER.challan_date AS CHALLANDATE, CHALLANMASTER_DESC.CHALLAN_BATCHNO AS BATCHNO,CHALLANMASTER.CHALLAN_PACKETS AS PACKETS, CHALLANMASTER.challan_ledgerid AS LEDGERID, CHALLANMASTER.challan_cmpid as cmpid, CHALLANMASTER.challan_yearid as yearid ", "", "CHALLANMASTER INNER JOIN CHALLANMASTER_DESC ON CHALLANMASTER.challan_no = CHALLANMASTER_DESC.CHALLAN_NO AND CHALLANMASTER.challan_yearid = CHALLANMASTER_DESC.CHALLAN_YEARID", " AND CHALLANMASTER.CHALLAN_NO = " & CHNO & " AND CHALLANMASTER.CHALLAN_CMPID = " & CmpId & " AND CHALLANMASTER.CHALLAN_YEARID = " & YearId & " ORDER BY CHALLANMASTER.CHALLAN_NO ")
                            'Dim DTINSERT As DataTable = OBJCMN.Execute_Any_String(" INSERT INTO TEMPPACKETS VALUES (" & DTNEW.Rows(0).Item("CHALLANNO") & ",'" & Format(Convert.ToDateTime(DTNEW.Rows(0).Item("CHALLANDATE")).Date, "MM/dd/yyyy") & "', " & DTNEW.Rows(0).Item("LEDGERID") & ",'" & DTNEW.Rows(0).Item("PONO") & "','" & DTNEW.Rows(0).Item("PODATE") & "'," & DTNEW.Rows(0).Item("ITEMID") & "," & Val(DT.Rows(0).Item(i - 3)) & ",'" & DTNEW.Rows(0).Item("BATCHNO") & "','" & j & "/" & Val(DT.Rows(0).Item(i)) & "'," & DTNEW.Rows(0).Item("CMPID") & "," & DTNEW.Rows(0).Item("YEARID") & "," & j & ") ", "", "")
                            Dim DTINSERT As DataTable = OBJCMN.Execute_Any_String(" INSERT INTO TEMPPACKETS VALUES (" & DTNEW.Rows(0).Item("CHALLANNO") & ",'" & Format(Convert.ToDateTime(DTNEW.Rows(0).Item("CHALLANDATE")).Date, "MM/dd/yyyy") & "', " & DTNEW.Rows(0).Item("LEDGERID") & ",'" & DTNEW.Rows(0).Item("PONO") & "','" & Format(Convert.ToDateTime(DTNEW.Rows(0).Item("PODATE")).Date, "MM/dd/yyyy") & "'," & DTNEW.Rows(0).Item("ITEMID") & "," & Val(DT.Rows(0).Item(i - 3)) & ",'" & DTNEW.Rows(0).Item("BATCHNO") & "','" & K & "/" & Val(DTNEW.Rows(0).Item("PACKETS")) & "'," & DTNEW.Rows(0).Item("CMPID") & "," & DTNEW.Rows(0).Item("YEARID") & "," & K & ") ", "", "")
                            K = K + 1
                        Next
                    Next
                End If
            Else
                Dim OBJCHALLAN As New Challan
                If DTBATCH.Rows.Count > 0 Then
                    For Each ROW As DataRow In DTBATCH.Rows
                        DT = OBJCMN.search(" jobbatch_packetitem1, jobbatch_packetitem2, jobbatch_packetitem3, jobbatch_packet1, jobbatch_packet2, jobbatch_packet3 ", "", " BATCHMASTER ", " and jobbatch_no = " & ROW("CBATCHNO") & " and jobbatch_YEARID = " & YearId)
                        If DT.Rows.Count > 0 Then
                            Dim K As Integer = 1
                            For i = 3 To 5
                                For j = 1 To Val(DT.Rows(0).Item(i))
                                    DTNEW = OBJCMN.search("CHALLANMASTER_DESC.CHALLAN_ITEMID AS ITEMID, CHALLANMASTER.challan_pono AS PONO, CHALLANMASTER.challan_podate AS PODATE, CHALLANMASTER.CHALLAN_QTY AS QTY, CHALLANMASTER.challan_no AS CHALLANNO, CHALLANMASTER.challan_date AS CHALLANDATE, CHALLANMASTER_DESC.CHALLAN_BATCHNO AS BATCHNO,CHALLANMASTER_DESC.CHALLAN_PACKETS AS PACKETS, CHALLANMASTER.challan_ledgerid AS LEDGERID, CHALLANMASTER.challan_cmpid as cmpid, CHALLANMASTER.challan_yearid as yearid ", "", "CHALLANMASTER INNER JOIN CHALLANMASTER_DESC ON CHALLANMASTER.challan_no = CHALLANMASTER_DESC.CHALLAN_NO AND CHALLANMASTER.challan_yearid = CHALLANMASTER_DESC.CHALLAN_YEARID", " AND CHALLANMASTER.CHALLAN_NO = " & CHNO & " AND CHALLANMASTER.CHALLAN_CMPID = " & CmpId & " AND CHALLANMASTER.CHALLAN_YEARID = " & YearId & " ORDER BY CHALLANMASTER_DESC.CHALLAN_SRNO ")
                                    'Dim DTINSERT As DataTable = OBJCMN.Execute_Any_String(" INSERT INTO TEMPPACKETS VALUES (" & DTNEW.Rows(0).Item("CHALLANNO") & ",'" & Format(Convert.ToDateTime(DTNEW.Rows(0).Item("CHALLANDATE")).Date, "MM/dd/yyyy") & "', " & DTNEW.Rows(0).Item("LEDGERID") & ",'" & DTNEW.Rows(0).Item("PONO") & "','" & DTNEW.Rows(0).Item("PODATE") & "'," & DTNEW.Rows(0).Item("ITEMID") & "," & Val(DT.Rows(0).Item(i - 3)) & ",'" & DTNEW.Rows(0).Item("BATCHNO") & "','" & K & "/" & Val(DTNEW.Rows(0).Item("PACKETS")) & "'," & DTNEW.Rows(0).Item("CMPID") & "," & DTNEW.Rows(0).Item("YEARID") & "," & K & ") ", "", "")
                                    Dim DTINSERT As DataTable = OBJCMN.Execute_Any_String(" INSERT INTO TEMPPACKETS VALUES (" & DTNEW.Rows(0).Item("CHALLANNO") & ",'" & Format(Convert.ToDateTime(DTNEW.Rows(0).Item("CHALLANDATE")).Date, "MM/dd/yyyy") & "', " & DTNEW.Rows(0).Item("LEDGERID") & ",'" & DTNEW.Rows(0).Item("PONO") & "','" & Format(Convert.ToDateTime(DTNEW.Rows(0).Item("PODATE")).Date, "MM/dd/yyyy") & "'," & DTNEW.Rows(0).Item("ITEMID") & "," & Val(DT.Rows(0).Item(i - 3)) & ",'" & ROW("CBATCHNO") & "','" & K & "/" & Val(DTNEW.Rows(0).Item("PACKETS")) & "'," & DTNEW.Rows(0).Item("CMPID") & "," & DTNEW.Rows(0).Item("YEARID") & "," & K & ") ", "", "")
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

                If FRMSTRING = "PACKET" Then
                    If ClientName = "RUTVIJ" Then
                        crTables = RPTPACKETRUTVIJ.Database.Tables
                    ElseIf ClientName = "AMR" Then
                        crTables = RPTPACKET_AMR.Database.Tables
                    Else
                        crTables = RPTPACKET.Database.Tables
                    End If
                End If

                For Each crTable In crTables
                    crtableLogonInfo = crTable.LogOnInfo
                    crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                    crTable.ApplyLogOnInfo(crtableLogonInfo)
                Next

                CRPO.SelectionFormula = WHERECLAUSE

                If FRMSTRING = "PACKET" Then
                    If ClientName = "RUTVIJ" Then
                        CRPO.ReportSource = RPTPACKETRUTVIJ
                    ElseIf ClientName = "AMR" Then
                        CRPO.ReportSource = RPTPACKET_AMR
                    Else
                        CRPO.ReportSource = RPTPACKET
                    End If

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

        If FRMSTRING = "PACKET" Then tempattachment = "PACKET"

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

            If FRMSTRING = "PACKET" Then
                If ClientName = "RUTVIJ" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\PACKET.PDF"
                    expo = RPTPACKETRUTVIJ.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTPACKETRUTVIJ.Export()
                ElseIf ClientName = "AMR" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\PACKET.PDF"
                    expo = RPTPACKET_AMR.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTPACKET_AMR.Export()
                Else
                    oDfDopt.DiskFileName = Application.StartupPath & "\PACKET.PDF"
                    expo = RPTPACKET.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTPACKET.Export()
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class