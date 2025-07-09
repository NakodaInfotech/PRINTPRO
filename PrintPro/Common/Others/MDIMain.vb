
Imports BL
Imports System.Windows.Forms

Public Class MDIMain

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    'Sub SCROLLERS()
    '    Try
    '        LBLSCROLLER.Left = Me.Width
    '        LBLSCROLLER.Top = StatusStrip1.Top + 2

    '        Dim objclsCMST As New ClsCommonMaster
    '        Dim SCROLLERDATA As String = ""

    '        'PROOF NOT SENT
    '        Dim dt As DataTable
    '        'dt = objclsCMST.search(" top 100 ITEM_CODE AS ITEMCODE", "", " ITEMMASTER ", " AND ISNULL(ITEM_PROOFSEND,0) = 0 AND ITEM_YEARID =" & YearId)
    '        'If dt.Rows.Count > 0 Then
    '        '    SCROLLERDATA = ""
    '        '    For Each ROW As DataRow In dt.Rows
    '        '        SCROLLERDATA = SCROLLERDATA & "Proof Not Sent :- " & ROW("ITEMCODE") & "                        "
    '        '    Next
    '        'End If
    '        'LBLSCROLLER.Text = SCROLLERDATA

    '        'APPROVAL OF PROOF NOT RECD
    '        'dt = objclsCMST.search("top 50 ITEM_CODE AS ITEMCODE", "", " ITEMMASTER ", " AND ISNULL(ITEM_PROOFSEND,0) = 1 AND ISNULL(ITEM_PROOFOK,0) = 0 AND ITEM_YEARID =" & YearId)
    '        'If dt.Rows.Count > 0 Then
    '        '    SCROLLERDATA = ""
    '        '    For Each ROW As DataRow In dt.Rows
    '        '        SCROLLERDATA = SCROLLERDATA & "Approval of Proof Not Recd :- " & ROW("ITEMCODE") & "                        "
    '        '    Next
    '        'End If
    '        'LBLSCROLLER.Text = LBLSCROLLER.Text & SCROLLERDATA


    '        'SHADECARD NOT SENT
    '        'dt = objclsCMST.search(" top 50 ITEM_CODE AS ITEMCODE", "", " ITEMMASTER ", " AND ISNULL(ITEM_PROOFSEND,0) = 1 AND ISNULL(ITEM_PROOFOK,0) = 0 AND ITEM_YEARID =" & YearId)
    '        'If dt.Rows.Count > 0 Then
    '        '    SCROLLERDATA = ""
    '        '    For Each ROW As DataRow In dt.Rows
    '        '        SCROLLERDATA = SCROLLERDATA & "Shade Card Not Sent :- " & ROW("ITEMCODE") & "                        "
    '        '    Next
    '        'End If
    '        'LBLSCROLLER.Text = LBLSCROLLER.Text & SCROLLERDATA


    '        'APPROVAL OF SHADECARD NOT RECD
    '        'dt = objclsCMST.search(" top 50 ITEM_CODE AS ITEMCODE", "", " ITEMMASTER ", " AND ISNULL(ITEM_PROOFSEND,0) = 1 AND ISNULL(ITEM_PROOFOK,0) = 1 AND ISNULL(ITEM_SHADECARD,0) = 1 AND ISNULL(ITEM_SHADECARD,0) = 1 AND ISNULL(ITEM_SHADEAPPROVE,0) = 0 AND ITEM_YEARID =" & YearId)
    '        'If dt.Rows.Count > 0 Then
    '        '    SCROLLERDATA = ""
    '        '    For Each ROW As DataRow In dt.Rows
    '        '        SCROLLERDATA = SCROLLERDATA & "Approval of Shade Not Recd :- " & ROW("ITEMCODE") & "                        "
    '        '    Next
    '        'End If
    '        'LBLSCROLLER.Text = LBLSCROLLER.Text & SCROLLERDATA



    '        ' EXPIRAY OF SHADE CARD 
    '        dt = objclsCMST.search(" TOP(30) ISNULL(ITEMMASTER.item_code, 0) AS ITEMCODE, ITEMMASTER.ITEM_SHADEDATE AS VALIDTILL ", "", " ITEMMASTER ", "   And ITEM_SHADEDATE IS NOT NULL AND ITEMMASTER.item_yearid = " & YearId & " AND CAST(ITEM_SHADEDATE AS DATE) BETWEEN DATEADD(DAY, -7, CAST(GETDATE() AS DATE)) AND CAST(GETDATE() AS DATE)  ORDER BY ITEMMASTER.item_code")
    '        If dt.Rows.Count > 0 Then
    '            SCROLLERDATA = ""
    '            For Each ROW As DataRow In dt.Rows
    '                SCROLLERDATA = SCROLLERDATA & "Shade Card :- " & ROW("ITEMCODE") & " Expires On :- " & ROW("VALIDTILL") & "          "
    '            Next
    '        End If
    '        LBLSCROLLER.Text = LBLSCROLLER.Text & SCROLLERDATA

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

    '    LBLSCROLLER.Left = LBLSCROLLER.Left - 1
    '    LBLSCROLLER.Top = StatusStrip1.Top + 2

    '    If LBLSCROLLER.Left < 0 - LBLSCROLLER.Width Then
    '        SCROLLERS()
    '        LBLSCROLLER.Left = Me.Width
    '    End If
    'End Sub

    Private Sub MDIMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = CmpName & "(" & AccFrom & " - " & AccTo & ")"
        If HIDEAUDITREMARKS = True Then AUDITREMARKS_MASTER.Text = "Remarks (Not visible)" Else AUDITREMARKS_MASTER.Text = "Remarks (Visible)"

        GETCONN()
        SETENABILITY()
        If ClientName = "AMR" Then
            Timer1.Enabled = True
            LBLSCROLLER.Visible = True
            Timer1.Interval = 15
        End If

        'GET COMPANY'S DATA FOR VALIDATIONS OF EWB AND GST
        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable = OBJCMN.search("ISNULL(CMP_EWBUSER,'') AS EWBUSER, ISNULL(CMP_EWBPASS,'') AS EWBPASS, ISNULL(CMP_GSTIN,'') AS CMPGSTIN, ISNULL(CMP_ZIPCODE,'') AS CMPPINCODE, ISNULL(CITY_NAME,'') AS CITYNAME, CAST(STATE_NAME AS VARCHAR(100)) AS STATENAME, CAST(STATE_REMARK AS VARCHAR(5)) AS STATECODE, ISNULL(NOOFEWAYBILLS,0) AS EWAYCOUNTER", "", " STATEMASTER INNER JOIN CMPMASTER ON STATE_ID = CMP_STATEID LEFT OUTER JOIN CITYMASTER ON CMP_FROMCITYID = CITY_ID LEFT OUTER JOIN EWAYCOUNTER ON CMP_ID = EWAYCOUNTER.CMPID ", " AND CMP_ID = " & CmpId)
        If DT.Rows.Count > 0 Then
            CMPEWBUSER = DT.Rows(0).Item("EWBUSER")
            CMPEWBPASS = DT.Rows(0).Item("EWBPASS")
            CMPGSTIN = DT.Rows(0).Item("CMPGSTIN")
            CMPPINCODE = DT.Rows(0).Item("CMPPINCODE")
            CMPCITYNAME = DT.Rows(0).Item("CITYNAME")
            CMPSTATENAME = DT.Rows(0).Item("STATENAME")
            CMPSTATECODE = DT.Rows(0).Item("STATECODE")

            DT = OBJCMN.search("ISNULL(SUM(NOOFEWAYBILLS),0) AS EWAYCOUNTER", "", " EWAYCOUNTER ", " AND CMPID = " & CmpId)
            CMPEWAYCOUNTER = Val(DT.Rows(0).Item("EWAYCOUNTER"))
            DT = OBJCMN.search("ISNULL(MAX(DATE), GETDATE()) AS EWAYEXPDATE", "", " EWAYCOUNTER ", " AND CMPID = " & CmpId)
            EWAYEXPDATE = Convert.ToDateTime(DT.Rows(0).Item("EWAYEXPDATE")).Date.AddYears(1)


            DT = OBJCMN.search("ISNULL(SUM(NOOFEINVOICE),0) AS EINVOICECOUNTER", "", " EINVOICECOUNTER ", " AND CMPID = " & CmpId)
            CMPEINVOICECOUNTER = Val(DT.Rows(0).Item("EINVOICECOUNTER"))
            DT = OBJCMN.search("ISNULL(MAX(DATE), GETDATE()) AS EINVOICEEXPDATE", "", " EINVOICECOUNTER ", " AND CMPID = " & CmpId)
            EINVOICEEXPDATE = Convert.ToDateTime(DT.Rows(0).Item("EINVOICEEXPDATE")).Date.AddYears(1)

        End If

        'BLOCKTRANSFER VARIABLES
        BLOCKMASTERTRANSFER = False
        BLOCKOTHERTRANSFER = False
        BLOCKACCDATATRANSFER = False
        BLOCKSTOCKSTRANSFER = False


        DT = OBJCMN.search("ISNULL(BLOCK_LEDGER,0) AS BLOCKMASTER, ISNULL(BLOCK_OTHER,0) AS BLOCKOTHERMASTER, ISNULL(BLOCK_DATA,0) AS BLOCKACCDATA, ISNULL(BLOCK_STOCK,0) AS BLOCKSTOCK", "", " BLOCKDATA ", " AND BLOCK_YEARID = " & YearId)
        If DT.Rows.Count > 0 Then
            BLOCKMASTERTRANSFER = Convert.ToBoolean(DT.Rows(0).Item("BLOCKMASTER"))
            BLOCKOTHERTRANSFER = Convert.ToBoolean(DT.Rows(0).Item("BLOCKOTHERMASTER"))
            BLOCKACCDATATRANSFER = Convert.ToBoolean(DT.Rows(0).Item("BLOCKACCDATA"))
            BLOCKSTOCKSTRANSFER = Convert.ToBoolean(DT.Rows(0).Item("BLOCKSTOCK"))
        End If

        'CHECKING BLOCKDATE FOR BACK DATED ENTRIES
        DT = OBJCMN.search("*", "", "BLOCKDATE", " AND YEARID = " & YearId)
        If DT.Rows.Count > 0 Then
            SALEBLOCKDATE = DT.Rows(0).Item("SALEDATE")
            PURBLOCKDATE = DT.Rows(0).Item("PURDATE")
            CNBLOCKDATE = DT.Rows(0).Item("CNDATE")
            DNBLOCKDATE = DT.Rows(0).Item("DNDATE")
            EXPBLOCKDATE = DT.Rows(0).Item("EXPDATE")
            GRNBLOCKDATE = DT.Rows(0).Item("GRNDATE")
            SALERETCHBLOCKDATE = DT.Rows(0).Item("SRCHALLANDATE")
            PURRETCHBLOCKDATE = DT.Rows(0).Item("PRCHALLANDATE")
            POBLOCKDATE = DT.Rows(0).Item("PODATE")
            SOBLOCKDATE = DT.Rows(0).Item("SODATE")

        Else

            SALEBLOCKDATE = AccFrom.Date
            PURBLOCKDATE = AccFrom.Date
            CNBLOCKDATE = AccFrom.Date
            CNBLOCKDATE = AccFrom.Date
            EXPBLOCKDATE = AccFrom.Date
            GRNBLOCKDATE = AccFrom.Date
            SALERETCHBLOCKDATE = AccFrom.Date
            PURRETCHBLOCKDATE = AccFrom.Date
            POBLOCKDATE = AccFrom.Date
            SOBLOCKDATE = AccFrom.Date

        End If


    End Sub

    Sub SETENABILITY()
        Try

            If UserName = "Admin" Then
                CMP_MASTER.Visible = True
                YEAR_MASTER.Visible = True
                ADMIN_MASTER.Enabled = True
                MERGELEDGER.Visible = True
                GODOWN_MASTER.Visible = True
                USERTRANSFER_MENU.Enabled = True
                YEARTRANSFER_MENU.Enabled = True
                STOCKTRANSFER_MENU.Enabled = True
                SUPPROCESSCONFIG_MASTER.Enabled = True
                RECODATA_MASTER.Enabled = True
            Else
                'ONLY TO CHANGE PASSWORD
                ADMIN_MASTER.Enabled = True
                USERADD.Enabled = False
                USEREDIT.Enabled = True
            End If

            If ClientName = "IYMP" Then
                JOBBATCHADD.Visible = False
                JOBBATCHEDIT.Visible = False
                TOOLSTRIPJOBBATCH.Visible = False
                BATCHADD.Visible = False
                BATCHEDIT.Visible = False
                TOOLSTRIPBATCH.Visible = False
                BATCH_TOOL.Visible = False
                BATCHTOOLSTRIP.Visible = False
            ElseIf ClientName = "GANESHMUDRA" Then
                BATCH_TOOL.Text = "Pur Req"
                CHALLAN_TOOL.Text = "Scheduling"
                SALE_TOOL.Text = "Production"
                ' ToolStripSeparator21.Visible = True
                ToolStripSeparator31.Visible = False
                ToolStripSeparator32.Visible = False
                ToolStripSeparator35.Visible = False
                ToolStripSeparator37.Visible = False
                ToolStripSeparator2.Visible = False
                ToolStripSeparator20.Visible = False
                LABEL_TOOL.Visible = False
                REC_TOOL.Visible = False
                PAY_TOOL.Visible = False
                CONTRA_TOOL.Visible = False
                JV_TOOL.Visible = False
                JOBDOCKETADD.Visible = False
                JOBDOCKETEDIT.Visible = False
                TOOLSTRIPJOB.Visible = False
                BATCHADD.Visible = False
                BATCHEDIT.Visible = False
                TOOLSTRIPBATCH.Visible = False
                ACC_TOOL.Text = "Job Docket"
                ITEM_TOOL.Text = "Purchase Req"
                PURINV_TOOL.Text = "Purchase Order"
                JOBDOCKET_TOOL.Text = "Grn"
                BATCH_TOOL.Text = "Grn Checking"
                FinishJobDocketBatchToolStripMenuItem.Enabled = True

                ASB_TOOL.Text = "Schedulling"
                CHALLAN_TOOL.Text = "Production"
                SALE_TOOL.Text = "delivery"
                COA_TOOL.Visible = False

            ElseIf ClientName = "AMR" Then
                PurchaseRequestToolStripMenuItem.Visible = False
                SchedulingToolStripMenuItem.Visible = False
                ProductionToolStripMenuItem.Visible = False
                DeliveryToolStripMenuItem.Visible = False
                JobWorkToolStripMenuItem.Visible = False
                ToolStripSeparator16.Visible = False
                FinishJobDocketBatchToolStripMenuItem.Enabled = False

            Else
                JOBDOCKETADD.Visible = False
                JOBDOCKETEDIT.Visible = False
                TOOLSTRIPJOB.Visible = False
            End If

            For Each DTROW As DataRow In USERRIGHTS.Rows

                'MASTERS
                If DTROW(0).ToString = "GROUP MASTER" Then
                    If DTROW(1).ToString = True Then
                        GROUP_MASTER.Enabled = True
                        GROUPADD.Enabled = True
                    Else
                        GROUPADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        GROUP_MASTER.Enabled = True
                        GROUPEDIT.Enabled = True
                    Else
                        GROUPEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "ACCOUNTS MASTER" Then
                    If DTROW(1).ToString = True Then
                        ACC_MASTER.Enabled = True
                        ACCADD.Enabled = True
                        ACC_TOOL.Enabled = True
                        NARRATION_MASTER.Enabled = True
                        NARRATIONADD.Enabled = True
                        PARTYBANK_MASTER.Enabled = True
                        PARTYBANKADD.Enabled = True
                        SUPERVISOR_MASTER.Enabled = True
                        SUPERVISORADD.Enabled = True
                    Else
                        ACCADD.Enabled = False
                        NARRATIONADD.Enabled = False
                        PARTYBANKADD.Enabled = False
                        SUPERVISORADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        ACC_MASTER.Enabled = True
                        ACCEDIT.Enabled = True
                        ACC_TOOL.Enabled = True
                        NARRATION_MASTER.Enabled = True
                        NARRATIONEDIT.Enabled = True
                        PARTYBANK_MASTER.Enabled = True
                        PARTYBANKEDIT.Enabled = True
                        SUPERVISOR_MASTER.Enabled = True
                        SUPERVISOREDIT.Enabled = True
                    Else
                        ACCEDIT.Enabled = False
                        NARRATIONEDIT.Enabled = False
                        PARTYBANKEDIT.Enabled = False
                        SUPERVISOREDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "EMPLOYEE MASTER" Then
                    If DTROW(1).ToString = True Then
                        EMPLOYEE_MASTER.Enabled = True
                        EMPLOYEEADD.Enabled = True
                    Else
                        EMPLOYEEADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        EMPLOYEE_MASTER.Enabled = True
                        EMPLOYEEEDIT.Enabled = True
                    Else
                        EMPLOYEEEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "REGISTER MASTER" Then
                    If DTROW(1).ToString = True Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        REG_MASTER.Enabled = True
                    End If

                ElseIf DTROW(0).ToString = "ITEM MASTER" Then
                    If DTROW(1).ToString = True Then
                        ITEM_MASTER.Enabled = True
                        ITEMADD.Enabled = True
                        ITEM_TOOL.Enabled = True
                        PAPERMAT_MASTER.Enabled = True
                        PAPERMATADD.Enabled = True
                        PAPERDESIGN_MASTER.Enabled = True
                        PAPERDESIGNADD.Enabled = True
                        PAPERSIZE_MASTER.Enabled = True
                        PAPERSIZEADD.Enabled = True
                        PAPERGSM_MASTER.Enabled = True
                        PAPERGSMADD.Enabled = True
                        GRAIN_MASTER.Enabled = True
                        GRAINADD.Enabled = True
                        COORDINATOR_MASTER.Enabled = True
                        COORDINATORADD.Enabled = True
                        COLOR_MASTER.Enabled = True
                        COLORADD.Enabled = True
                        TEARTAPE_MASTER.Enabled = True
                        TEARTAPEADD.Enabled = True
                        SHELF_MASTER.Enabled = True
                        SHELFADD.Enabled = True
                        CATEGORY_MASTER.Enabled = True
                        CATEGORYADD.Enabled = True
                        NONINV_MASTER.Enabled = True
                        NONINVADD.Enabled = True
                    Else
                        ITEMADD.Enabled = False
                        PAPERMATADD.Enabled = False
                        PAPERDESIGNADD.Enabled = False
                        PAPERSIZEADD.Enabled = False
                        PAPERGSMADD.Enabled = False
                        GRAINADD.Enabled = False
                        COORDINATORADD.Enabled = False
                        COLORADD.Enabled = False
                        TEARTAPEADD.Enabled = False
                        SHELFADD.Enabled = False
                        CATEGORYADD.Enabled = False
                        NONINVADD.Enabled = False

                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        ITEM_MASTER.Enabled = True
                        ITEMEDIT.Enabled = True
                        ITEM_TOOL.Enabled = True
                        PAPERMAT_MASTER.Enabled = True
                        PAPERMATEDIT.Enabled = True
                        PAPERDESIGN_MASTER.Enabled = True
                        PAPERDESIGNEDIT.Enabled = True
                        PAPERSIZE_MASTER.Enabled = True
                        PAPERSIZEEDIT.Enabled = True
                        PAPERGSM_MASTER.Enabled = True
                        PAPERGSMEDIT.Enabled = True
                        GRAIN_MASTER.Enabled = True
                        GRAINEDIT.Enabled = True
                        COORDINATOR_MASTER.Enabled = True
                        COORDINATOREDIT.Enabled = True
                        COLOR_MASTER.Enabled = True
                        COLOREDIT.Enabled = True
                        TEARTAPE_MASTER.Enabled = True
                        TEARTAPEEDIT.Enabled = True
                        SHELF_MASTER.Enabled = True
                        SHELFEDIT.Enabled = True
                        CATEGORY_MASTER.Enabled = True
                        CATEGORYEDIT.Enabled = True
                        NONINV_MASTER.Enabled = True
                        NONINVEDIT.Enabled = True
                    Else
                        ITEMEDIT.Enabled = False
                        PAPERMATEDIT.Enabled = True
                        PAPERMATEDIT.Enabled = False
                        PAPERDESIGNEDIT.Enabled = False
                        PAPERSIZEEDIT.Enabled = False
                        PAPERGSMEDIT.Enabled = False
                        GRAINEDIT.Enabled = False
                        COORDINATOREDIT.Enabled = False
                        COLOREDIT.Enabled = False
                        TEARTAPEEDIT.Enabled = False
                        SHELFEDIT.Enabled = False
                        CATEGORYEDIT.Enabled = False
                        NONINVEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "TAX MASTER" Then
                    If DTROW(1).ToString = True Then
                        TAX_MASTER.Enabled = True
                        TAXADD.Enabled = True
                    Else
                        TAXADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        TAX_MASTER.Enabled = True
                        TAXEDIT.Enabled = True
                    Else
                        TAXEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "UNIT MASTER" Then
                    If DTROW(1).ToString = True Then
                        UNIT_MASTER.Enabled = True
                        UNITADD.Enabled = True
                    Else
                        UNITADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        UNIT_MASTER.Enabled = True
                        UNITEDIT.Enabled = True
                    Else
                        UNITEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "LOCATION MASTER" Then
                    If DTROW(1).ToString = True Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        LOC_MASTER.Enabled = True
                    End If


                ElseIf DTROW(0).ToString = "OPENING" Then
                    If DTROW(1).ToString = True Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        OPENINGBILL_MASTER.Enabled = True
                        OPENINGSTOCK.Enabled = True
                        OPENINGSTOCKVALUE.Enabled = True
                    End If


                    'PURCHASE
                ElseIf DTROW(0).ToString = "PURCHASE ORDER" Then
                    If DTROW(1).ToString = True Then
                        PO_MASTER.Enabled = True
                        POADD.Enabled = True
                    Else
                        POADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        PO_MASTER.Enabled = True
                        POEDIT.Enabled = True
                    Else
                        POEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "GRN" Then
                    If DTROW(1).ToString = True Then
                        GRN_MASTER.Enabled = True
                        GRNADD.Enabled = True
                    Else
                        GRNADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        GRN_MASTER.Enabled = True
                        GRNEDIT.Enabled = True
                    Else
                        GRNEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "GRN CHECKING" Then
                    If DTROW(1).ToString = True Then
                        GRNCHECKING_MASTER.Enabled = True
                        GRNCHECKINGADD.Enabled = True
                    Else
                        GRNCHECKINGADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        GRNCHECKING_MASTER.Enabled = True
                        GRNCHECKINGEDIT.Enabled = True
                    Else
                        GRNCHECKINGEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "PURCHASE INVOICE" Then
                    If DTROW(1).ToString = True Then
                        PURINV_MASTER.Enabled = True
                        PURINVADD.Enabled = True
                        PURINV_TOOL.Enabled = True
                    Else
                        PURINVADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        PURINV_MASTER.Enabled = True
                        PURINVEDIT.Enabled = True
                        PURINV_TOOL.Enabled = True
                    Else
                        PURINVEDIT.Enabled = False
                    End If


                    'SALE
                ElseIf DTROW(0).ToString = "CONSUMPTION" Then
                    If DTROW(1).ToString = True Then
                        CONSUMPTION_MASTER.Enabled = True
                        CONSUMPTIONRET_MASTER.Enabled = True
                        CONSUMPTIONADD.Enabled = True
                        CONSUMPTIONOTHERADD.Enabled = True
                        CONSUMPTIONRETADD.Enabled = True
                        PLATEISSUE_MASTER.Enabled = True
                        PLATEISSUEADD.Enabled = True
                        PLATERETURN_MASTER.Enabled = True
                        PLATERETURNADD.Enabled = True
                        PLATEDESTROYED_MASTER.Enabled = True
                        PLATEDESTROYEDADD.Enabled = True
                    Else
                        CONSUMPTIONADD.Enabled = False
                        CONSUMPTIONOTHERADD.Enabled = False
                        CONSUMPTIONRETADD.Enabled = False
                        PLATEISSUEADD.Enabled = False
                        PLATERETURNADD.Enabled = False
                        PLATEDESTROYEDADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        CONSUMPTION_MASTER.Enabled = True
                        CONSUMPTIONRET_MASTER.Enabled = True
                        CONSUMPTIONEDIT.Enabled = True
                        CONSUMPTIONRETEDIT.Enabled = True
                        PLATEISSUE_MASTER.Enabled = True
                        PLATEISSUEEDIT.Enabled = True
                        PLATERETURN_MASTER.Enabled = True
                        PLATERETURNEDIT.Enabled = True
                        PLATEDESTROYED_MASTER.Enabled = True
                        PLATEDESTROYEDEDIT.Enabled = True
                    Else
                        CONSUMPTIONEDIT.Enabled = False
                        CONSUMPTIONRETEDIT.Enabled = False
                        PLATEISSUEEDIT.Enabled = False
                        PLATERETURNEDIT.Enabled = False
                        PLATEDESTROYEDEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "SALE ORDER" Then
                    If DTROW(1).ToString = True Then
                        SO_MASTER.Enabled = True
                        SOADD.Enabled = True
                        SO_TOOL.Enabled = True
                    Else
                        SOADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        SO_MASTER.Enabled = True
                        SOEDIT.Enabled = True
                        SO_TOOL.Enabled = True
                    Else
                        SOEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "CHALLAN" Then
                    If DTROW(1).ToString = True Then
                        CHALLAN_MASTER.Enabled = True
                        CHALLANADD.Enabled = True
                        CHALLAN_TOOL.Enabled = True
                    Else
                        CHALLANADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        CHALLAN_MASTER.Enabled = True
                        CHALLANEDIT.Enabled = True
                        CHALLAN_TOOL.Enabled = True
                    Else
                        CHALLANEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "SALE INVOICE" Then
                    If DTROW(1).ToString = True Then
                        SALE_MASTER.Enabled = True
                        SALEADD.Enabled = True
                        COA_TOOL.Enabled = True
                        LABEL_TOOL.Enabled = True
                        SALE_TOOL.Enabled = True
                    Else
                        SALEADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        SALE_MASTER.Enabled = True
                        SALEEDIT.Enabled = True
                        COA_TOOL.Enabled = True
                        LABEL_TOOL.Enabled = True
                        SALE_TOOL.Enabled = True
                    Else
                        SALEEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "JOB DOCKET" Then
                    If DTROW(1).ToString = True Then
                        JOBDOCKET_MASTER.Enabled = True
                        JOBDOCKETADD.Enabled = True
                        JOBDOCKET_TOOL.Enabled = True
                        BATCH_TOOL.Enabled = True
                        JOBBATCHADD.Enabled = True
                        BATCHADD.Enabled = True
                    Else
                        JOBDOCKETADD.Enabled = False
                        JOBBATCHADD.Enabled = False
                        BATCHADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        JOBDOCKET_MASTER.Enabled = True
                        JOBDOCKETEDIT.Enabled = True
                        JOBDOCKET_TOOL.Enabled = True
                        BATCH_TOOL.Enabled = True
                        JOBBATCHEDIT.Enabled = True
                        BATCHEDIT.Enabled = True
                    Else
                        JOBDOCKETEDIT.Enabled = False
                        JOBBATCHEDIT.Enabled = False
                        BATCHEDIT.Enabled = False
                    End If


                    'ACCOUNTS
                ElseIf DTROW(0).ToString = "PAYMENT" Then
                    If DTROW(1).ToString = True Then
                        PAY_MASTER.Enabled = True
                        PAYADD.Enabled = True
                        PAY_TOOL.Enabled = True
                    Else
                        PAYADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        PAY_MASTER.Enabled = True
                        PAYEDIT.Enabled = True
                        PAY_TOOL.Enabled = True
                    Else
                        PAYEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "RECEIPT" Then
                    If DTROW(1).ToString = True Then
                        REC_MASTER.Enabled = True
                        RECADD.Enabled = True
                        REC_TOOL.Enabled = True
                    Else
                        RECADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        REC_MASTER.Enabled = True
                        RECEDIT.Enabled = True
                        REC_TOOL.Enabled = True
                    Else
                        RECEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "CONTRA VOUCHER" Then
                    If DTROW(1).ToString = True Then
                        CONTRA_MASTER.Enabled = True
                        CONTRAADD.Enabled = True
                        CONTRA_TOOL.Enabled = True
                    Else
                        CONTRAADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        CONTRA_MASTER.Enabled = True
                        CONTRAEDIT.Enabled = True
                        CONTRA_TOOL.Enabled = True
                    Else
                        CONTRAEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "JOURNAL VOUCHER" Then
                    If DTROW(1).ToString = True Then
                        JV_MASTER.Enabled = True
                        JVADD.Enabled = True
                        JV_TOOL.Enabled = True
                    Else
                        JVADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        JV_MASTER.Enabled = True
                        JVEDIT.Enabled = True
                        JV_TOOL.Enabled = True
                    Else
                        JVEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "DEBIT NOTE" Then
                    If DTROW(1).ToString = True Then
                        DEBIT_MASTER.Enabled = True
                        DEBITADD.Enabled = True
                    Else
                        DEBITADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        DEBIT_MASTER.Enabled = True
                        DEBITEDIT.Enabled = True
                    Else
                        DEBITEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "CREDIT NOTE" Then
                    If DTROW(1).ToString = True Then
                        CREDIT_MASTER.Enabled = True
                        CREDITADD.Enabled = True
                    Else
                        CREDITADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        CREDIT_MASTER.Enabled = True
                        CREDITEDIT.Enabled = True
                    Else
                        CREDITEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "VOUCHER ENTRY" Then
                    If DTROW(1).ToString = True Then
                        VOUCHER_MASTER.Enabled = True
                        VOUCHERADD.Enabled = True
                    Else
                        VOUCHERADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        VOUCHER_MASTER.Enabled = True
                        VOUCHEREDIT.Enabled = True
                    Else
                        VOUCHEREDIT.Enabled = False
                    End If

                    'REPORTS
                ElseIf DTROW(0).ToString = "PURCHASE REPORTS" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        PUR_REPORTS.Enabled = True
                    End If


                ElseIf DTROW(0).ToString = "SALE REPORTS" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        SALE_REPORTS.Enabled = True
                    End If


                ElseIf DTROW(0).ToString = "JOB REPORTS" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        JOB_REPORTS.Enabled = True
                    End If

                ElseIf DTROW(0).ToString = "ACCOUNT REPORTS" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        REGISTER_MAIN.Enabled = True
                        ACCOUNTREPORT_MAIN.Enabled = True
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GROUPADD.Click
        Try
            Dim objGroupMaster As New GroupMaster
            objGroupMaster.MdiParent = Me
            objGroupMaster.Show()
            objGroupMaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewCityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewCityToolStripMenuItem.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "CITYMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewStateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewStateToolStripMenuItem.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "STATEMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewCountryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewCountryToolStripMenuItem.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "COUNTRYMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewAreaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewAreaToolStripMenuItem.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "AREAMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub AddNewAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACCADD.Click
        Try
            Dim objAccountMaster As New AccountsMaster
            objAccountMaster.MdiParent = Me
            objAccountMaster.frmstring = "ACCOUNTS"
            objAccountMaster.Show()
            objAccountMaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GROUPEDIT.Click
        Try
            Dim objGroupDetails As New GroupDetails
            objGroupDetails.MdiParent = Me
            objGroupDetails.Show()
            objGroupDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingAccoutsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACCEDIT.Click
        Try
            Dim objAccountDetails As New AccountsDetails
            objAccountDetails.MdiParent = Me
            objAccountDetails.frmstring = "ACCOUNTS"
            objAccountDetails.Show()
            objAccountDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingAreaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingAreaToolStripMenuItem.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "AREAMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingCityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingCityToolStripMenuItem.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "CITYMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingStateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingStateToolStripMenuItem.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "STATEMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingCountryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingCountryToolStripMenuItem.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "COUNTRYMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub addUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USERADD.Click
        Try
            Dim objuser As New UserMaster
            objuser.MdiParent = Me
            objuser.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub editUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USEREDIT.Click
        Try
            Dim objuser As New UserDetails
            objuser.MdiParent = Me
            objuser.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub opencmp(ByVal CMP As String)
        Try

            Dim objcmn As New ClsCommon
            Dim DT As DataTable

            DT = objcmn.search("CMPMASTER.CMP_NAME, YEARMASTER.YEAR_DBNAME, CMPMASTER.CMP_ID, YEARMASTER.YEAR_STARTDATE, YEARMASTER.YEAR_ENDDATE, YEARMASTER.YEAR_ID", "", " CMPMASTER INNER JOIN YEARMASTER ON YEARMASTER.YEAR_CMPID = CMPMASTER.CMP_ID", " AND CMPMASTER.CMP_NAME = '" & CMP & "'")
            CmpName = DT.Rows(0).Item(0).ToString
            CmpId = DT.Rows(0).Item(2).ToString
            AccFrom = DT.Rows(0).Item(3)
            AccTo = DT.Rows(0).Item(4)
            YearId = DT.Rows(0).Item(5).ToString
            Cmppassword.cmdback.Visible = False
            Cmppassword.lblretype.Visible = False
            Cmppassword.txtretypepassword.Visible = False
            Cmppassword.cmdnext.Text = "&Ok"
            Cmppassword.ShowDialog()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewRegisterToolStripMenuItem.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "PURCHASE"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem14.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "SALE"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem17.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "JOURNAL"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem19.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "CONTRA"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem21.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "PAYMENT"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem23.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "RECEIPT"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TAXADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TAXADD.Click
        Try
            Dim OBJTAX As New Taxmaster
            OBJTAX.MdiParent = Me
            OBJTAX.Show()
            OBJTAX.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TAXEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TAXEDIT.Click
        Try
            Dim OBJTAXDETAILS As New TaxDetails
            OBJTAXDETAILS.MdiParent = Me
            OBJTAXDETAILS.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewExpenseRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewExpenseRegisterToolStripMenuItem.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "EXPENSE"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewRegisterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewRegisterToolStripMenuItem1.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "CREDITNOTE"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewRegisterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewRegisterToolStripMenuItem2.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "DEBITNOTE"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ChangeCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeCompany.Click
        Try
            'close all child forms
            Dim frm As Form
            For Each frm In MdiChildren
                frm.Close()
            Next

            Me.Dispose()
            Cmpdetails.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChangeUserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeUserToolStripMenuItem.Click
        Try
            'close all child forms
            Dim frm As Form
            For Each frm In MdiChildren
                frm.Close()
            Next

            Me.Dispose()
            Login.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMPEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMPEDIT.Click
        Try
            Cmpmaster.edit = True
            Cmpmaster.TEMPCMPNAME = CmpName
            Cmpmaster.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMPADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMPADD.Click
        Try
            Dim obj As New Cmpmaster
            obj.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub DayBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DayBookToolStripMenuItem.Click
        Try
            Dim OBJDAYBOOK As New DayBook
            OBJDAYBOOK.MdiParent = Me
            OBJDAYBOOK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgerBookToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerBookToolStripMenuItem1.Click
        Try
            Dim objledgerbook As New RegisterDetails
            objledgerbook.MdiParent = Me
            objledgerbook.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgerBillWiseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerBillWiseToolStripMenuItem.Click
        Try
            Dim OBJBILL As New LedgerBillwise
            OBJBILL.MdiParent = Me
            OBJBILL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub LEDGEROUTSTANDING_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LEDGEROUTSTANDING.Click
    '    Try
    '        Dim OBJLEDGER As New LedgerOutstandingReport
    '        OBJLEDGER.MdiParent = Me
    '        OBJLEDGER.Show()
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub PurchaseRegisterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseRegisterToolStripMenuItem2.Click
        Try
            Dim objpurreg As New PurchaseRegister
            objpurreg.MdiParent = Me
            objpurreg.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaleRegisterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaleRegisterToolStripMenuItem2.Click
        Try
            If ClientName = "AMR" AndAlso InputBox("Enter Password") <> "Infosys@123" Then Exit Sub

            Dim objsalereg As New SaleRegister
            objsalereg.MdiParent = Me
            objsalereg.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JournalRegisterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournalRegisterToolStripMenuItem2.Click
        Try
            Dim OBJJVREG As New JournalRegister
            OBJJVREG.MdiParent = Me
            OBJJVREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ContraRegisterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContraRegisterToolStripMenuItem2.Click
        Try
            Dim OBJCONTRAREG As New ContraRegister
            OBJCONTRAREG.MdiParent = Me
            OBJCONTRAREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DebitNoteRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebitNoteRegisterToolStripMenuItem.Click
        Try
            Dim OBJDNREG As New DNRegister
            OBJDNREG.MdiParent = Me
            OBJDNREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CreditNoteRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditNoteRegisterToolStripMenuItem.Click
        Try
            Dim OBJCNREG As New CNRegister
            OBJCNREG.MdiParent = Me
            OBJCNREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BankBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankBookToolStripMenuItem.Click
        Try
            Dim OBJBANKREG As New BankRegister
            OBJBANKREG.MdiParent = Me
            OBJBANKREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CashBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashBookToolStripMenuItem.Click
        Try
            Dim OBJCASHREG As New cashregister1
            OBJCASHREG.MdiParent = Me
            OBJCASHREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GroupSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupSummaryToolStripMenuItem.Click
        Try
            Dim OBJGROUP As New GroupRegister
            OBJGROUP.MdiParent = Me
            OBJGROUP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TrialBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrialBalanceToolStripMenuItem.Click
        Try
            Dim OBJTB As New TB
            OBJTB.MdiParent = Me
            OBJTB.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ProfitLossToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProfitLossToolStripMenuItem.Click
        Try
            Dim objpl As New PL
            objpl.MdiParent = Me
            objpl.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BalanceSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalanceSheetToolStripMenuItem.Click
        Try
            Dim OBJBALANCESHEET As New BS
            OBJBALANCESHEET.MdiParent = Me
            OBJBALANCESHEET.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MDIMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If MsgBox("Wish to Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                'End
            Else
                e.Cancel = True
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PAYADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAYADD.Click
        Try
            Dim OBJPAY As New PaymentMaster
            OBJPAY.MdiParent = Me
            OBJPAY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PAYEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAYEDIT.Click
        Try
            Dim OBJPAY As New PaymentDetails
            OBJPAY.MdiParent = Me
            OBJPAY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RECADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECADD.Click
        Try
            Dim OBJREC As New Receipt
            OBJREC.MdiParent = Me
            OBJREC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RECEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECEDIT.Click
        Try
            Dim OBJREC As New ReceiptDetails
            OBJREC.MdiParent = Me
            OBJREC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CONTRAADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONTRAADD.Click
        Try
            Dim OBJCON As New ContraEntry
            OBJCON.MdiParent = Me
            OBJCON.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CONTRAEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONTRAEDIT.Click
        Try
            Dim OBJCON As New ContraDetails
            OBJCON.MdiParent = Me
            OBJCON.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JVEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JVADD.Click
        Try
            Dim OBJJV As New journal
            OBJJV.MdiParent = Me
            OBJJV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingJournalEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JVEDIT.Click
        Try
            Dim OBJJV As New JournalDetails
            OBJJV.MdiParent = Me
            OBJJV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CREDITADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CREDITADD.Click
        Try
            Dim OBJCN As New CREDITNOTE
            OBJCN.MdiParent = Me
            OBJCN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CREDITEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CREDITEDIT.Click
        Try
            Dim OBJCN As New CreditNoteDetails
            OBJCN.MdiParent = Me
            OBJCN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DEBITADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEBITADD.Click
        Try
            Dim OBJDN As New DebitNote
            OBJDN.MdiParent = Me
            OBJDN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DEBITEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEBITEDIT.Click
        Try
            Dim OBJDN As New DebitNoteDetails
            OBJDN.MdiParent = Me
            OBJDN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VOUCHERADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VOUCHERADD.Click
        Try
            Dim OBJEXP As New ExpenseVoucher
            OBJEXP.MdiParent = Me
            OBJEXP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VOUCHEREDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VOUCHEREDIT.Click
        Try
            Dim OBJEXP As New ExpenseVoucherDetails
            OBJEXP.MdiParent = Me
            OBJEXP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OPENINGBILL_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPENINGBILL_MASTER.Click
        Try
            Dim OBJOP As New OpeningBills
            OBJOP.FRMSTRING = "OPENINGBILLS"
            OBJOP.MdiParent = Me
            OBJOP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BackupCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupCompany.Click
        Try
            backup()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub backup()
        Try
            'TAKE BACKUP
            Dim TEMPMSG As Integer = MsgBox("Create Backup?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then

                'CHECKING FOR BACKUP FOLDER
                If FileIO.FileSystem.DirectoryExists("C:\YARNTRADEBACKUP") = False Then FileIO.FileSystem.CreateDirectory("C:\YARNTRADEBACKUP")

                'IF SAME DATE'S BACKUP EXIST THEN DELETE IT THEN RECREATE IT
                If FileIO.FileSystem.FileExists("C:\YARNTRADEBACKUP\BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak") Then FileIO.FileSystem.DeleteFile("D:\YARNTRADEBACKUP\BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak")

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.Execute_Any_String(" backup database PrintPro to disk='C:\YARNTRADEBACKUP\BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak'", "", "")
                MsgBox("Backup Completed")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgerOnScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerOnScreenToolStripMenuItem.Click
        Try
            Dim objledger As New LedgerSummary
            objledger.MdiParent = Me
            objledger.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TDSCHALLAN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim OBJTDS As New TDSChallan1
            OBJTDS.MdiParent = Me
            OBJTDS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MERGELEDGER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MERGELEDGER.Click
        Try
            Dim OBJMERGE As New MergeLedger
            OBJMERGE.MdiParent = Me
            OBJMERGE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReceivableOutstandingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceivableOutstandingToolStripMenuItem.Click
        Try
            Dim OBJOUT As New OutstandingFilter
            OBJOUT.FRMSTRING = "RECOUTSTANDING"
            OBJOUT.MdiParent = Me
            OBJOUT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PayableOutstandingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PayableOutstandingToolStripMenuItem.Click
        Try
            Dim OBJOUT As New OutstandingFilter
            OBJOUT.FRMSTRING = "PAYOUTSTANDING"
            OBJOUT.MdiParent = Me
            OBJOUT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OutstandingFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutstandingFilterToolStripMenuItem.Click
        Try
            Dim OBJOP As New OutstandingFilter
            OBJOP.MdiParent = Me
            OBJOP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OutstandingGridReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutstandingGridReportToolStripMenuItem.Click
        Try
            Dim OBJOUT As New OutstandingReport
            OBJOUT.MdiParent = Me
            OBJOUT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MergeParameterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MergeParameterToolStripMenuItem.Click
        Try
            Dim OBJmerger As New MergeParameter
            OBJmerger.MdiParent = Me
            OBJmerger.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgersToolStripMenuItem.Click
        Try
            Dim OBJLEDGER As New LedgerFilter
            OBJLEDGER.MdiParent = Me
            OBJLEDGER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub NARRATIONADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NARRATIONADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "NARRATION"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PARTYBANKADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PARTYBANKADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "PARTYBANK"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub NARRATIONEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NARRATIONEDIT.Click
        Try
            Dim objCategory As New CategoryDetails
            objCategory.frmstring = "NARRATION"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PARTYBANKEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PARTYBANKEDIT.Click
        Try
            Dim objCategory As New CategoryDetails
            objCategory.frmstring = "PARTYBANK"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub DefaultRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefaultRegisterToolStripMenuItem.Click
        Try
            Dim objCategory As New DefaultRegister
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAY_TOOL.Click
        Try
            Dim OBJPAY As New PaymentMaster
            OBJPAY.MdiParent = Me
            OBJPAY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REC_TOOL.Click
        Try
            Dim OBJREC As New Receipt
            OBJREC.MdiParent = Me
            OBJREC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolstripOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SO_TOOL.Click
        Try
            Dim OBJREC As New Order
            OBJREC.MdiParent = Me
            OBJREC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ITEMADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEMADD.Click
        Try
            Dim OBJITEM As New ItemMaster
            OBJITEM.MdiParent = Me
            OBJITEM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ITEMEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEMEDIT.Click
        Try
            Dim OBJITEM As New ItemDetails
            OBJITEM.MdiParent = Me
            OBJITEM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolstripItemCentre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEM_TOOL.Click
        Try
            If ClientName = "GANESHMUDRA" Then
                Dim OBJBATCH As New PurchaseRequest
                OBJBATCH.MdiParent = Me
                OBJBATCH.Show()
            Else

                Dim OBJITEM As New ItemDetails
                OBJITEM.MdiParent = Me
                OBJITEM.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PURINVADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PURINVADD.Click
        Try

            If ClientName = "GANESHMUDRA" Then
                Dim OBJJOBD As New PurchaseOrder
                OBJJOBD.MdiParent = Me
                OBJJOBD.Show()
            Else

                Dim OBJPUR As New PurchaseMaster
                OBJPUR.MdiParent = Me
                OBJPUR.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolstripPurchaseBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PURINV_TOOL.Click
        Try
            If ClientName = "GANESHMUDRA" Then
                Dim OBJJOBD As New PurchaseOrder
                OBJJOBD.MdiParent = Me
                OBJJOBD.Show()
            Else
                Dim OBJPUR As New PurchaseMaster
                OBJPUR.MdiParent = Me
                OBJPUR.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolstripAccountsCentre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACC_TOOL.Click
        Try
            If ClientName = "GANESHMUDRA" Then
                Dim OBJJOBD As New JobDocketBatch
                OBJJOBD.MdiParent = Me
                OBJJOBD.Show()
            Else

                Dim objAccountMaster As New AccountsDetails
                objAccountMaster.MdiParent = Me
                objAccountMaster.frmstring = "ACCOUNTS"
                objAccountMaster.Show()
                'objAccountMaster.BringToFront()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PURINVEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PURINVEDIT.Click
        Try
            Dim OBJPUR As New PurchaseMasterDetails
            OBJPUR.MdiParent = Me
            OBJPUR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolstripJobDocket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JOBDOCKET_TOOL.Click
        Try
            If ClientName = "IYMP" Then
                Dim OBJJOBD As New JobDocket
                OBJJOBD.MdiParent = Me
                OBJJOBD.Show()
            ElseIf ClientName = "GANESHMUDRA" Then
                Dim OBJJOBD As New GRN
                OBJJOBD.MdiParent = Me
                OBJJOBD.Show()
            Else
                Dim OBJJOBD As New JobDocketBatch
                OBJJOBD.MdiParent = Me
                OBJJOBD.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolstripInvoiceChallan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHALLAN_TOOL.Click
        Try
            If ClientName = "GANESHMUDRA" Then
                Dim OBJINV As New Production
                OBJINV.MdiParent = Me
                OBJINV.Show()
            Else
                Dim OBJCHALLAN As New Challan
                OBJCHALLAN.MdiParent = Me
                OBJCHALLAN.Show()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewJobDocketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JOBDOCKETADD.Click
        Try
            Dim OBJJOBD As New JobDocket
            OBJJOBD.MdiParent = Me
            OBJJOBD.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingJobDocketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JOBDOCKETEDIT.Click
        Try
            Dim OBJJOB As New JobDocketDetails
            OBJJOB.MdiParent = Me
            OBJJOB.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolstripInvoices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALE_TOOL.Click
        Try
            If ClientName = "GANESHMUDRA" Then
                Dim OBJINV As New Delivery
                OBJINV.MdiParent = Me
                OBJINV.Show()
            Else
                Dim OBJINV As New Invoice
                OBJINV.MdiParent = Me
                OBJINV.Show()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SALEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALEADD.Click
        Try
            Dim OBJINV As New Invoice
            OBJINV.MdiParent = Me
            OBJINV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SALEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALEEDIT.Click
        Try
            Dim OBJINV As New InvoiceDetails
            OBJINV.MdiParent = Me
            OBJINV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewChallanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHALLANADD.Click
        Try
            Dim OBJINV As New Challan
            OBJINV.MdiParent = Me
            OBJINV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingChallanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHALLANEDIT.Click
        Try
            Dim OBJINV As New ChallanDetails
            OBJINV.MdiParent = Me
            OBJINV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PAPERMATADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAPERMATADD.Click
        Try
            Dim OBJPPR As New PaperMaterialMaster
            OBJPPR.frmString = "PAPERMATERIAL"
            OBJPPR.MdiParent = Me
            OBJPPR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PAPERDESIGNADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAPERDESIGNADD.Click
        Try
            Dim OBJPPR As New PaperMaterialMaster
            OBJPPR.frmString = "PAPERDESIGN"
            OBJPPR.MdiParent = Me
            OBJPPR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PAPERMATEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAPERMATEDIT.Click
        Try
            Dim OBJPPR As New PaperMaterialDetails
            OBJPPR.FRMSTRING = "PAPERMATERIAL"
            OBJPPR.MdiParent = Me
            OBJPPR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PAPERDESIGNEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAPERDESIGNEDIT.Click
        Try
            Dim OBJPPR As New PaperMaterialDetails
            OBJPPR.FRMSTRING = "PAPERDESIGN"
            OBJPPR.MdiParent = Me
            OBJPPR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PAPERSIZEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAPERSIZEADD.Click
        Try
            Dim OBJPPR As New PaperMaterialMaster
            OBJPPR.frmString = "PAPERSIZE"
            OBJPPR.MdiParent = Me
            OBJPPR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PAPERSIZEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAPERSIZEEDIT.Click
        Try
            Dim OBJPPR As New PaperMaterialDetails
            OBJPPR.FRMSTRING = "PAPERSIZE"
            OBJPPR.MdiParent = Me
            OBJPPR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PAPERGSMADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAPERGSMADD.Click
        Try
            Dim OBJPPR As New PaperMaterialMaster
            OBJPPR.frmString = "PAPERGSM"
            OBJPPR.MdiParent = Me
            OBJPPR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PAPERGSMEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAPERGSMEDIT.Click
        Try
            Dim OBJPPR As New PaperMaterialDetails
            OBJPPR.FRMSTRING = "PAPERGSM"
            OBJPPR.MdiParent = Me
            OBJPPR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRAINADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRAINADD.Click
        Try
            Dim OBJPPR As New PaperMaterialMaster
            OBJPPR.frmString = "GRAINDIRECTION"
            OBJPPR.MdiParent = Me
            OBJPPR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRAINEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRAINEDIT.Click
        Try
            Dim OBJPPR As New PaperMaterialDetails
            OBJPPR.FRMSTRING = "GRAINDIRECTION"
            OBJPPR.MdiParent = Me
            OBJPPR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SOEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SOEDIT.Click
        Try
            Dim OBJORDER As New OrderDetails
            OBJORDER.MdiParent = Me
            OBJORDER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SOADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SOADD.Click
        Try
            Dim OBJORDER As New Order
            OBJORDER.MdiParent = Me
            OBJORDER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewUnitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UNITADD.Click
        Try
            Dim OBJORUNIT As New UnitMaster
            OBJORUNIT.MdiParent = Me
            OBJORUNIT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingUnitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UNITEDIT.Click
        Try
            Dim OBJORUNIT As New UnitDetails
            OBJORUNIT.MdiParent = Me
            OBJORUNIT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddCoOrdinatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COORDINATORADD.Click
        Try
            Dim OBJCOORDINATOR As New CoordinatorMaster
            OBJCOORDINATOR.MdiParent = Me
            OBJCOORDINATOR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COORDINATOREDIT.Click
        Try
            Dim OBJCOORDINATOR As New CoordinatorDetails
            OBJCOORDINATOR.MdiParent = Me
            OBJCOORDINATOR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewColorMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COLORADD.Click
        Try
            Dim OBJPPR As New PaperMaterialMaster
            OBJPPR.frmString = "COLOR"
            OBJPPR.MdiParent = Me
            OBJPPR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COLOREDIT.Click
        Try
            Dim OBJPPR As New PaperMaterialDetails
            OBJPPR.FRMSTRING = "COLOR"
            OBJPPR.MdiParent = Me
            OBJPPR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YEAREDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YEAREDIT.Click
        'Try
        '    YearMaster.EDIT = True
        '    YearMaster.TEMPCMPNAME = CmpName
        '    YearMaster.ShowDialog()
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub YEARADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YEARADD.Click
        Try
            Dim TEMPMSG As Integer = MsgBox("Create New Accounting Year?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim obj As New YearMaster
                obj.cmdback.Visible = False
                obj.EDIT = False
                obj.FRMSTRING = "ADDYEAR"
                obj.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewTearTapeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEARTAPEADD.Click
        Try
            Dim OBJPPR As New PaperMaterialMaster
            OBJPPR.frmString = "TEARTAPE"
            OBJPPR.MdiParent = Me
            OBJPPR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExixtingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEARTAPEEDIT.Click
        Try
            Dim OBJPPR As New PaperMaterialDetails
            OBJPPR.FRMSTRING = "TEARTAPE"
            OBJPPR.MdiParent = Me
            OBJPPR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewShelfToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SHELFADD.Click
        Try
            Dim OBJPPR As New PaperMaterialMaster
            OBJPPR.frmString = "SHELF"
            OBJPPR.MdiParent = Me
            OBJPPR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingShelfToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SHELFEDIT.Click
        Try
            Dim OBJPPR As New PaperMaterialDetails
            OBJPPR.FRMSTRING = "SHELF"
            OBJPPR.MdiParent = Me
            OBJPPR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpeningStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPENINGSTOCK.Click
        Try
            Dim objstock As New OpeningStock
            objstock.MdiParent = Me
            objstock.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddConsumptionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONSUMPTIONADD.Click
        Try
            Dim objconsume As New Consumption
            objconsume.MdiParent = Me
            objconsume.FRMSTRING = "PAPER"
            objconsume.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingConsumptionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONSUMPTIONEDIT.Click
        Try
            Dim objconsume As New ConsumptionDetails
            objconsume.MdiParent = Me
            objconsume.FRMSTRING = "PAPER"
            objconsume.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewCaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CATEGORYADD.Click
        Try
            Dim OBJPPR As New PaperMaterialMaster
            OBJPPR.frmString = "CATEGORY"
            OBJPPR.MdiParent = Me
            OBJPPR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CATEGORYEDIT.Click
        Try
            Dim OBJPPR As New PaperMaterialDetails
            OBJPPR.FRMSTRING = "CATEGORY"
            OBJPPR.MdiParent = Me
            OBJPPR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONSUMPTIONRETADD.Click
        Try
            Dim objconsume As New ConsumptionReturn
            objconsume.MdiParent = Me
            objconsume.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONSUMPTIONRETEDIT.Click
        Try
            Dim objconsume As New ConsumptionReturnDetails
            objconsume.MdiParent = Me
            objconsume.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STORESTOCKFILTER.Click
        Try
            Dim OBJSTOCK As New StockFilter
            OBJSTOCK.MdiParent = Me
            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewNonInvItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NONINVADD.Click
        Try
            Dim OBJSTOCK As New NonInvItemMaster
            OBJSTOCK.MdiParent = Me
            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JV_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JV_TOOL.Click
        Try
            Dim OBJJV As New journal
            OBJJV.MdiParent = Me
            OBJJV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NONINVEDIT.Click
        Try
            Dim OBJSTOCK As New NonInvItemMasterDetails
            OBJSTOCK.MdiParent = Me
            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewGodownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewGodownToolStripMenuItem.Click
        Try
            Dim OBJPPR As New PaperMaterialMaster
            OBJPPR.frmString = "GODOWN"
            OBJPPR.MdiParent = Me
            OBJPPR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingGodownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingGodownToolStripMenuItem.Click
        Try
            Dim OBJPPR As New PaperMaterialDetails
            OBJPPR.FRMSTRING = "GODOWN"
            OBJPPR.MdiParent = Me
            OBJPPR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TDSEFilingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim OBJTDS1 As New TDS
            OBJTDS1.MdiParent = Me
            OBJTDS1.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CONTRA_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONTRA_TOOL.Click
        Try
            Dim OBJCONTRA As New ContraEntry
            OBJCONTRA.MdiParent = Me
            OBJCONTRA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LABEL_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LABEL_TOOL.Click
        Try
            Dim OBJCHALLAN As New ChallanDetails
            OBJCHALLAN.MdiParent = Me
            OBJCHALLAN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub COA_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COA_TOOL.Click
        Try
            Dim OBJINV As New InvoiceDetails
            OBJINV.MdiParent = Me
            OBJINV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddPurchaseOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POADD.Click
        Try
            Dim OBJPO As New PurchaseOrder
            OBJPO.MdiParent = Me
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub EditExistingPurchaseOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POEDIT.Click
        Try
            Dim OBJPO As New PurchaseOrderDetails
            OBJPO.MdiParent = Me
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub AddNewGRNToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRNADD.Click
        Try
            Dim OBjGRN As New GRN
            OBjGRN.MdiParent = Me
            OBjGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingGRNToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRNEDIT.Click
        Try
            Dim OBjGRN As New GRNDetails
            OBjGRN.MdiParent = Me
            OBjGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddGRNCheckingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRNCHECKINGADD.Click
        Try
            Dim OBjGRNCHK As New GRNChecking
            OBjGRNCHK.MdiParent = Me
            OBjGRNCHK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub EditExisitingGRNCheckingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRNCHECKINGEDIT.Click
        Try
            Dim OBjGRNCHK As New GRNCheckingDetails
            OBjGRNCHK.MdiParent = Me
            OBjGRNCHK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseOrderFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseOrderFilterToolStripMenuItem.Click
        Try
            Dim OBJPO As New POFilter
            OBJPO.MdiParent = Me
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub GRNFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRNFilterToolStripMenuItem.Click
        Try
            Dim OBJGRN As New GRNFilter
            OBJGRN.MdiParent = Me
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseInvoiceToolStripMenuItem.Click
        Try
            Dim OBJPINV As New Purchase_Invoice_Filter
            OBJPINV.MdiParent = Me
            OBJPINV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseInvoiceFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseInvoiceFilterToolStripMenuItem.Click
        Try
            Dim OBJPGRNCHEK As New GRNCheckingFilter
            OBJPGRNCHEK.MdiParent = Me
            OBJPGRNCHEK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PLATEISSUEADD.Click
        Try
            Dim OBJPLATEISSUE As New PlateIssue
            OBJPLATEISSUE.MdiParent = Me
            OBJPLATEISSUE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PLATEISSUEEDIT.Click
        Try
            Dim OBJPLATEISSUE As New PlateIssueDetails
            OBJPLATEISSUE.MdiParent = Me
            OBJPLATEISSUE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewEntryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PLATERETURNADD.Click
        Try
            Dim OBJPLATERETURN As New PlateReturned
            OBJPLATERETURN.MdiParent = Me
            OBJPLATERETURN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PLATERETURNEDIT.Click
        Try
            Dim OBJPLATERETURN As New PlateReturnedDetails
            OBJPLATERETURN.MdiParent = Me
            OBJPLATERETURN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewEntryToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PLATEDESTROYEDADD.Click
        Try
            Dim OBJDESTRYOED As New PlateDestroyed
            OBJDESTRYOED.MdiParent = Me
            OBJDESTRYOED.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingEntryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PLATEDESTROYEDEDIT.Click
        Try
            Dim OBJDESTRYOED As New PlateDestroyedDetails
            OBJDESTRYOED.MdiParent = Me
            OBJDESTRYOED.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AdvancesSettlementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvancesSettlementToolStripMenuItem.Click
        Try
            Dim OBJADV As New Adv_Receivable_settlement
            OBJADV.flag_adv_settlement = True
            OBJADV.MdiParent = Me
            OBJADV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReceivableSettlementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceivableSettlementToolStripMenuItem.Click
        Try
            Dim OBJADV As New Adv_Receivable_settlement
            OBJADV.flag_Rec_settlement = True
            OBJADV.MdiParent = Me
            OBJADV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddJobDocketBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JOBBATCHADD.Click
        Try
            Dim OBJJOBDOCKEKBTACH As New JobDocketBatch
            OBJJOBDOCKEKBTACH.MdiParent = Me
            OBJJOBDOCKEKBTACH.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingJobDocketBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JOBBATCHEDIT.Click

        Try
            Dim OBJJOBDOCKEKBTACH As New JobDocketBatchDetails
            OBJJOBDOCKEKBTACH.MdiParent = Me
            OBJJOBDOCKEKBTACH.Show()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SaleOrderFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaleOrderFilterToolStripMenuItem.Click
        Try
            Dim OBJORDER As New OrderFilter
            OBJORDER.MdiParent = Me
            OBJORDER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub ChallanFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChallanFilterToolStripMenuItem.Click
        Try
            Dim OBJCHALLAN As New ChallanFilter
            OBJCHALLAN.MdiParent = Me
            OBJCHALLAN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaleInvoiceFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaleInvoiceFilterToolStripMenuItem.Click
        Try
            Dim OBJINVOICE As New InvoiceFilter
            OBJINVOICE.MdiParent = Me
            OBJINVOICE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewBatcToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BATCHADD.Click
        Try
            Dim OBJBATCH As New Batch
            OBJBATCH.MdiParent = Me
            OBJBATCH.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JobDocketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JOB_REPORTS.Click
        Try
            Dim OBJJOB As New JobDocketFilter
            OBJJOB.MdiParent = Me
            OBJJOB.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BATCHEDIT.Click
        Try
            Dim OBJBATCH As New BatchDetails
            OBJBATCH.MdiParent = Me
            OBJBATCH.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PlateIssuedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlateIssuedToolStripMenuItem.Click
        Try
            Dim OBJPLATE As New PlateIssueFilter
            OBJPLATE.MdiParent = Me
            OBJPLATE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PlateRecdFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlateRecdFilterToolStripMenuItem.Click
        Try
            Dim OBJPLATERTN As New PlateReturnFilter
            OBJPLATERTN.MdiParent = Me
            OBJPLATERTN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ConsimptionFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsimptionFilterToolStripMenuItem.Click
        Try
            Dim OBJCONSUME As New ConsumptionFilter
            OBJCONSUME.MdiParent = Me
            OBJCONSUME.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DeleteLogsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteLogsToolStripMenuItem.Click
        Try
            Dim OBJDELETE As New DeleteDetails
            OBJDELETE.MdiParent = Me
            OBJDELETE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UpdateLogsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateLogsToolStripMenuItem.Click
        Try
            Dim OBJUPDATE As New UpdateDetails
            OBJUPDATE.MdiParent = Me
            OBJUPDATE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ConsumptionReturnFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsumptionReturnFilterToolStripMenuItem.Click
        Try
            Dim OBJCONSUMPTIONRTN As New ConsumptionReturnFilter
            OBJCONSUMPTIONRTN.MdiParent = Me
            OBJCONSUMPTIONRTN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseTaxRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim OBJTAX As New TaxFilter
            OBJTAX.MdiParent = Me
            OBJTAX.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YEARTRANSFER_MENU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YEARTRANSFER_MENU.Click
        Try
            Dim OBJYEAR As New YearTransfer
            OBJYEAR.MdiParent = Me
            OBJYEAR.FRMSTRING = "YEARTRANSFER"
            OBJYEAR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TransferUserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USERTRANSFER_MENU.Click
        Try
            Dim OBJYEAR As New YearTransfer
            OBJYEAR.FRMSTRING = "USERTRANSFER"
            OBJYEAR.MdiParent = Me
            OBJYEAR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STOCKTRANSFER_MENU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCKTRANSFER_MENU.Click
        Try
            Dim OBJYEAR As New YearTransfer
            OBJYEAR.MdiParent = Me
            OBJYEAR.FRMSTRING = "STOCKTRANSFER"
            OBJYEAR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BLOCKUSER_MENU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BLOCKUSER_MENU.Click
        Try
            'Dim OBJUSER As New BlockUser
            'OBJUSER.MdiParent = Me
            'OBJUSER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OPENINGSTOCKVALUE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPENINGSTOCKVALUE.Click
        Try
            Dim OBJOP As New OpeningClosingStock
            OBJOP.MdiParent = Me
            OBJOP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BATCH_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BATCH_TOOL.Click
        Try
            If ClientName = "GANESHMUDRA" Then
                Dim OBJBATCH As New GRNChecking
                OBJBATCH.MdiParent = Me
                OBJBATCH.Show()
            Else
                Dim OBJBATCH As New Batch
                OBJBATCH.MdiParent = Me
                OBJBATCH.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub POReplacementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POReplacementToolStripMenuItem.Click
        Try
            Dim OBJPO As New UpdatePoNo
            OBJPO.MdiParent = Me
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LRNoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LRNoToolStripMenuItem.Click
        Try
            Dim OBJLRNO As New LRNoEditing
            OBJLRNO.MdiParent = Me
            OBJLRNO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SUPERVISORADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SUPERVISORADD.Click
        Try
            Dim OBJSUP As New SupervisorMaster
            OBJSUP.MdiParent = Me
            OBJSUP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SUPERVISOREDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SUPERVISOREDIT.Click
        Try
            Dim OBJSUP As New SupervisorDetails
            OBJSUP.MdiParent = Me
            OBJSUP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ItemCodeDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemCodeDetailsToolStripMenuItem.Click
        Try
            Dim OBJITEM As New ItemCodeDetailsFilter
            OBJITEM.MdiParent = Me
            OBJITEM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChangeSupervisorPasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeSupervisorPasswordToolStripMenuItem.Click
        Try
            Dim OBJITEM As New ChangeSupervisorPassword
            OBJITEM.MdiParent = Me
            OBJITEM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SUPPROCESSCONFIG_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SUPPROCESSCONFIG_MASTER.Click
        Try
            Dim OBJSUPCONF As New SupervisorProcessConfig
            OBJSUPCONF.MdiParent = Me
            OBJSUPCONF.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HSNADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HSNADD.Click
        Try
            Dim OBJHSN As New HSNMaster
            OBJHSN.MdiParent = Me
            OBJHSN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HSNEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HSNEDIT.Click
        Try
            Dim OBJHSN As New HSNDetails
            OBJHSN.MdiParent = Me
            OBJHSN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GSTTaxRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GSTTaxRegister.Click
        Try
            Dim OBJTAX As New GSTTaxFilter
            OBJTAX.MdiParent = Me
            OBJTAX.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RECODATA_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECODATA_MASTER.Click
        Try
            Dim OBJRECO As New ReconcileData
            OBJRECO.MdiParent = Me
            OBJRECO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MRP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MRP.Click
        Try
            Dim OBJRECO As New MRP
            OBJRECO.MdiParent = Me
            OBJRECO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UPDATEQC_MASTER_Click(sender As Object, e As EventArgs) Handles UPDATEQC_MASTER.Click
        Try
            Dim OBJQC As New PendingQC
            OBJQC.MdiParent = Me
            OBJQC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PurchaseToolStripMenuItem1.Click
        Try
            Dim OBJCAPO As New PurchaseOrderClose
            OBJCAPO.MdiParent = Me
            OBJCAPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PROBLEMADD_Click(sender As Object, e As EventArgs) Handles PROBLEMADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "PROBLEMMASTER"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PROBLEMEDIT_Click(sender As Object, e As EventArgs) Handles PROBLEMEDIT.Click
        Try
            Dim objCategory As New CategoryDetails
            objCategory.frmstring = "PROBLEMMASTER"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub REASONADD_Click(sender As Object, e As EventArgs) Handles REASONADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "REASONMASTER"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub REASONEDIT_Click(sender As Object, e As EventArgs) Handles REASONEDIT.Click
        Try
            Dim objCategory As New CategoryDetails
            objCategory.frmstring = "REASONMASTER"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PlateInwardRegister_Click(sender As Object, e As EventArgs) Handles PlateInwardRegister.Click
        Try
            Dim OBJQC As New PlateInwardregister
            OBJQC.MdiParent = Me
            OBJQC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PaperInwardRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaperInwardRegisterToolStripMenuItem.Click
        Try
            Dim OBJ As New PaperInwardRegister
            OBJ.MdiParent = Me
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaleOrderPlateDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaleOrderPlateDetailToolStripMenuItem.Click
        Try
            Dim obj As New SaleOrderPlateDetails
            obj.MdiParent = Me
            obj.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PendingOrderDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PendingOrderDetailsToolStripMenuItem.Click
        Try
            Dim pod As New PendingSaleOrder
            pod.MdiParent = Me
            pod.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub COMPLAINADD_Click(sender As Object, e As EventArgs) Handles COMPLAINADD.Click
        Try
            Dim OBJCMP As New ComplaintMaster
            OBJCMP.MdiParent = Me
            OBJCMP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChallanReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChallanReportToolStripMenuItem.Click
        Try
            Dim OBJCM As New DispatchReport
            OBJCM.MdiParent = Me
            OBJCM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub COMPLAINEDIT_Click(sender As Object, e As EventArgs) Handles COMPLAINEDIT.Click
        Try
            Dim obj As New ComplaintMasterGridDetails
            obj.MdiParent = Me
            obj.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OPERATORADD_Click(sender As Object, e As EventArgs) Handles OPERATORADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "OPERATORMASTER"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OPERATOREDIT_Click(sender As Object, e As EventArgs) Handles OPERATOREDIT.Click
        Try
            Dim objCategory As New CategoryDetails
            objCategory.frmstring = "OPERATORMASTER"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AUDITREMARKS_MASTER_Click(sender As Object, e As EventArgs) Handles AUDITREMARKS_MASTER.Click
        Try
            If UserName = "Admin" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable
                If HIDEAUDITREMARKS = True Then
                    DT = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_HIDEAUDITREMARKS = 0", "", "")
                Else
                    DT = OBJCMN.Execute_Any_String("UPDATE VERSION SET VERSION_HIDEAUDITREMARKS = 1", "", "")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CONSUMPTIONOTHERADD_Click(sender As Object, e As EventArgs) Handles CONSUMPTIONOTHERADD.Click
        Try
            Dim objconsume As New Consumption
            objconsume.MdiParent = Me
            objconsume.FRMSTRING = "OTHER"
            objconsume.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewOrderToolStripMenuItem.Click
        Try
            Dim OBJOPENINGPURCHASEORDER As New OpeningPurchaseOrder
            OBJOPENINGPURCHASEORDER.MdiParent = Me
            OBJOPENINGPURCHASEORDER.Show()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub EditExistingOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExistingOrderToolStripMenuItem.Click
        Try
            Dim OBJOPENINGPURCHASEORDERDETAIL As New OpeningPurchaseOrderDetails
            OBJOPENINGPURCHASEORDERDETAIL.MdiParent = Me
            OBJOPENINGPURCHASEORDERDETAIL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EInvoiceEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EInvoiceEntryToolStripMenuItem.Click
        Try
            Dim OBJEINV As New EInvoiceCounterReport
            OBJEINV.MdiParent = Me
            OBJEINV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLUPLOAD_Click(sender As Object, e As EventArgs) Handles TOOLUPLOAD.Click
        Try
            Dim OBJSIGN As New UploadSign
            OBJSIGN.MdiParent = Me
            OBJSIGN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewEmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EMPLOYEEADD.Click
        Try
            Dim OBJEMP As New EmployeeMaster
            OBJEMP.MdiParent = Me
            OBJEMP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingEmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EMPLOYEEEDIT.Click
        Try
            Dim OBJEMP As New EmployeeDetails
            OBJEMP.MdiParent = Me
            OBJEMP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewStockAdjToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewStockAdjToolStripMenuItem.Click
        Try
            Dim OBJSA As New StoreStockReco
            OBJSA.MdiParent = Me
            OBJSA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpeningBankRecoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpeningBankRecoToolStripMenuItem.Click
        Try
            Dim OBJSA As New OpeningBankReco
            OBJSA.MdiParent = Me
            OBJSA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OPENINGSTOCK_REPORT_Click(sender As Object, e As EventArgs) Handles OPENINGSTOCK_REPORT.Click
        Try
            Dim OBJSA As New OpeningStockGridReport
            OBJSA.MdiParent = Me
            OBJSA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub EditExistingStockAdjToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExistingStockAdjToolStripMenuItem.Click
        Try
            Dim OBJSA As New StoreStockRecoDetails
            OBJSA.MdiParent = Me
            OBJSA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InterestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InterestToolStripMenuItem.Click
        Try
            Dim OBJINTCALC As New InterestCalc
            OBJINTCALC.MdiParent = Me
            OBJINTCALC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub IntrestCalculatorSummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IntrestCalculatorSummaryToolStripMenuItem.Click
        Try
            Dim OBJINTCALC As New InterestCalc_Summary
            OBJINTCALC.MdiParent = Me
            OBJINTCALC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InterestCalculatorBillWiseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InterestCalculatorBillWiseToolStripMenuItem.Click
        Try
            Dim OBJINT As New InterestCalc_BillWise
            OBJINT.MdiParent = Me
            OBJINT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub AddNewEntryToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AddNewEntryToolStripMenuItem.Click
        Try
            Dim OBJSA As New JobOut
            OBJSA.MdiParent = Me
            OBJSA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingEntryToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles EditExistingEntryToolStripMenuItem.Click
        Try
            Dim OBJSA As New JobOutDetails
            OBJSA.MdiParent = Me
            OBJSA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewEntryToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles AddNewEntryToolStripMenuItem1.Click
        Try
            Dim OBJSA As New JobIn
            OBJSA.MdiParent = Me
            OBJSA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingEntryToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles EditExistingEntryToolStripMenuItem1.Click
        Try
            Dim OBJSA As New JobInDetails
            OBJSA.MdiParent = Me
            OBJSA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewPurchaseRequestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewPurchaseRequestToolStripMenuItem.Click
        Try
            Dim OBJPR As New PurchaseRequest
            OBJPR.MdiParent = Me
            OBJPR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingPurchaseRequestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExistingPurchaseRequestToolStripMenuItem.Click
        Try
            Dim OBJSA As New PurchaseRequestDetails
            OBJSA.MdiParent = Me
            OBJSA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CloseJobOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseJobOutToolStripMenuItem.Click
        Try
            Dim OBJSA As New CloseJobOut
            OBJSA.MdiParent = Me
            OBJSA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PendingWorkOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PendingWorkOrderToolStripMenuItem.Click
        Try
            Dim OBJSA As New PendingWorkOrder
            OBJSA.MdiParent = Me
            OBJSA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewProductionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewProductionToolStripMenuItem.Click
        Try
            Dim OBJSA As New Production
            OBJSA.MdiParent = Me
            OBJSA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingProductionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExistingProductionToolStripMenuItem.Click
        Try
            Dim OBJSA As New ProductionDetails
            OBJSA.MdiParent = Me
            OBJSA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewDeliveryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewDeliveryToolStripMenuItem.Click
        Try
            Dim OBJSA As New Delivery
            OBJSA.MdiParent = Me
            OBJSA.Show()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub AddNewSchedulingToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AddNewSchedulingToolStripMenuItem.Click
        Try
            Dim OBJSA As New Scheduling
            OBJSA.MdiParent = Me
            OBJSA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExixtingSchedulingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExixtingSchedulingToolStripMenuItem.Click
        Try
            Dim OBJSA As New SchedulingDetails
            OBJSA.MdiParent = Me
            OBJSA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub EditExistingDeliveryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExistingDeliveryToolStripMenuItem.Click
        Try
            Dim OBJSA As New DeliveryDetails
            OBJSA.MdiParent = Me
            OBJSA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingAssemblyQCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExistingAssemblyQCToolStripMenuItem.Click
        Try
            Dim OBJSA As New AssemblyQcDetails
            OBJSA.MdiParent = Me
            OBJSA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewAsseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewAsseToolStripMenuItem.Click
        Try
            Dim OBJASSY As New AssemblyQc
            OBJASSY.MdiParent = Me
            OBJASSY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FinishJobDocketBatchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinishJobDocketBatchToolStripMenuItem.Click
        Try
            Dim OBJASSY As New FinishJobDocketBatch
            OBJASSY.MdiParent = Me
            OBJASSY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CloseJobDocketBatchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseJobDocketBatchToolStripMenuItem.Click
        Try
            Dim OBJASSY As New CloseJobDocketBatch
            OBJASSY.MdiParent = Me
            OBJASSY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub ASB_TOOL_Click(sender As Object, e As EventArgs) Handles ASB_TOOL.Click
        Try

            If ClientName = "GANESHMUDRA" Then
                Dim OBJJOBD As New Scheduling
                OBJJOBD.MdiParent = Me
                OBJJOBD.Show()
            Else

                Dim OBJINV As New AssemblyQc
                OBJINV.MdiParent = Me
                OBJINV.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MultipleProductionCloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MultipleProductionCloseToolStripMenuItem.Click
        Try
            Dim OBJINV As New MultipleProductionClose
            OBJINV.MdiParent = Me
            OBJINV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewEntryToolStripMenuItem2_Click_1(sender As Object, e As EventArgs) Handles AddNewEntryToolStripMenuItem2.Click
        Try
            Dim OBJSA As New StockReco
            OBJSA.MdiParent = Me
            OBJSA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingEntryToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles EditExistingEntryToolStripMenuItem2.Click
        Try
            Dim OBJSA As New StockRecoDetails
            OBJSA.MdiParent = Me
            OBJSA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BlockDateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BlockDateToolStripMenuItem.Click
        Try
            Dim OBJBLOCK As New BlockDateEntry
            OBJBLOCK.MdiParent = Me
            OBJBLOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BlockUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BlockUserToolStripMenuItem.Click
        Try
            Dim OBJUSER As New BlockUser
            OBJUSER.MdiParent = Me
            OBJUSER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BlockDataStockTransferToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BlockDataStockTransferToolStripMenuItem.Click
        Try
            Dim OBJBLOCK As New BlockDataTransfer
            OBJBLOCK.MdiParent = Me
            OBJBLOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BlockDateToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles BlockDateToolStripMenuItem.Click
        Try
            Dim OBJBLOCK As New BlockDateEntry
            OBJBLOCK.MdiParent = Me
            OBJBLOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddManualMatchingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddManualMatchingToolStripMenuItem.Click
        Try
            Dim OBJMATCH As New ManualMatching
            OBJMATCH.MdiParent = Me
            OBJMATCH.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ManualMatchingDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManualMatchingDetailToolStripMenuItem.Click
        Try
            Dim OBJMATCH As New ManualMatchingDetails
            OBJMATCH.MdiParent = Me
            OBJMATCH.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewEntryToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles AddNewEntryToolStripMenuItem3.Click
        Try
            Dim OBJITC As New PurchaseReturnChallan
            OBJITC.MdiParent = Me
            OBJITC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingEntryToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles EditExistingEntryToolStripMenuItem3.Click
        Try
            Dim OBJITC As New PurchaseReturnChallanDetail
            OBJITC.MdiParent = Me
            OBJITC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewEntryToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles AddNewEntryToolStripMenuItem4.Click
        Try
            Dim OBJITC As New SaleReturnChallan
            OBJITC.MdiParent = Me
            OBJITC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingEntryToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles EditExistingEntryToolStripMenuItem4.Click
        Try
            Dim OBJITC As New SaleReturnChallanDetails
            OBJITC.MdiParent = Me
            OBJITC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewReturnToolStripMenuItem.Click
        Try
            Dim ObjPurchaseReturn As New PurchaseReturn
            ObjPurchaseReturn.MdiParent = Me
            ObjPurchaseReturn.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingReturnToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles EditExistingReturnToolStripMenuItem.Click
        Try
            Dim ObjPRDetails As New PurchaseReturnDetails
            ObjPRDetails.MdiParent = Me
            ObjPRDetails.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewEntryToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles AddNewEntryToolStripMenuItem5.Click
        Try
            Dim ObjPurchaseReturn As New SaleReturn
            ObjPurchaseReturn.MdiParent = Me
            ObjPurchaseReturn.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingEntryToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles EditExistingEntryToolStripMenuItem5.Click
        Try
            Dim ObjPurchaseReturn As New SaleReturnDetails
            ObjPurchaseReturn.MdiParent = Me
            ObjPurchaseReturn.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewMachineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewMachineToolStripMenuItem.Click
        Try
            Dim objMACHINE As New MachineMaster
            objMACHINE.MdiParent = Me
            objMACHINE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingMachineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExistingMachineToolStripMenuItem.Click
        Try
            Dim objMACHINE As New MachineDetails
            objMACHINE.MdiParent = Me
            objMACHINE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UploadAccountsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UPLOADACCOUNTSMENU.Click
        Try
            If InputBox("Enter Master Password") <> "Infosys@123" Then Exit Sub

            '************************************ LEDGER UPLOAD ****************************
            'upload the files data
            ''Reading from Excel Woorkbook
            Dim cPart As Microsoft.Office.Interop.Excel.Range
            Dim oExcel As Microsoft.Office.Interop.Excel.Application = CreateObject("Excel.Application")
            Dim oBook As Microsoft.Office.Interop.Excel.Workbook = oExcel.Workbooks.Open("E:\" & InputBox("Enter File Name").ToString.Trim, , False)
            Dim oSheet As New Microsoft.Office.Interop.Excel.Worksheet
            oSheet = oBook.Worksheets("Sheet1")

            'GRID

            Dim DTSAVE As New System.Data.DataTable
            DTSAVE.Columns.Add("CODE")
            DTSAVE.Columns.Add("COMPANYNAME")
            DTSAVE.Columns.Add("ADD1")
            DTSAVE.Columns.Add("ADD2")
            DTSAVE.Columns.Add("ADDRESS")
            DTSAVE.Columns.Add("CITYNAME")
            DTSAVE.Columns.Add("PINNO")
            DTSAVE.Columns.Add("STATE")
            DTSAVE.Columns.Add("COUNTRY")
            DTSAVE.Columns.Add("PHONENO")
            DTSAVE.Columns.Add("MOBILENO")
            DTSAVE.Columns.Add("GSTIN")
            DTSAVE.Columns.Add("GROUPNAME")
            DTSAVE.Columns.Add("PANNO")
            DTSAVE.Columns.Add("BROKER")
            DTSAVE.Columns.Add("TRANSPORT")
            DTSAVE.Columns.Add("EMAIL")
            DTSAVE.Columns.Add("CRDAYS")
            DTSAVE.Columns.Add("SALESMAN")
            DTSAVE.Columns.Add("TDSPER")
            DTSAVE.Columns.Add("TDSSECTION")
            DTSAVE.Columns.Add("CMPNONCMP")
            DTSAVE.Columns.Add("DISCOUNT")
            DTSAVE.Columns.Add("CASHDISC")
            DTSAVE.Columns.Add("COMMISSION")
            DTSAVE.Columns.Add("SHIPPINGADD")
            DTSAVE.Columns.Add("RESINO")
            DTSAVE.Columns.Add("ALTNO")
            DTSAVE.Columns.Add("FAX")
            DTSAVE.Columns.Add("WEBSITE")
            DTSAVE.Columns.Add("REMARKS")
            DTSAVE.Columns.Add("INTPER")
            DTSAVE.Columns.Add("DELIVERYAT")
            DTSAVE.Columns.Add("DELIVERYPINCODE")
            DTSAVE.Columns.Add("KMS")
            DTSAVE.Columns.Add("BROKERAGECOMM")
            DTSAVE.Columns.Add("WHATSAPPNO")
            DTSAVE.Columns.Add("AREA")
            DTSAVE.Columns.Add("TYPE")
            DTSAVE.Columns.Add("SIZETOLERANCE")
            DTSAVE.Columns.Add("GSMTOLERANCE")
            DTSAVE.Columns.Add("PATTERNTOLERANCE")
            DTSAVE.Columns.Add("EXCESSQTY")
            DTSAVE.Columns.Add("SEZTYPE")

            Dim ARR As New ArrayList
            Dim COLIND As Integer = 0
            Dim DTROWSAVE As System.Data.DataRow = DTSAVE.NewRow()

            Dim FROMROWNO As Integer = Val(InputBox("Enter Start Row No"))
            Dim TOROWNO As Integer = Val(InputBox("Enter End Row No"))

            For I As Integer = FROMROWNO To TOROWNO

                If IsDBNull(oSheet.Range("A" & I.ToString).Text) = False Then
                    DTROWSAVE("CODE") = oSheet.Range("A" & I.ToString).Text
                Else
                    DTROWSAVE("CODE") = ""
                End If

                If IsDBNull(oSheet.Range("B" & I.ToString).Text) = False Then
                    DTROWSAVE("COMPANYNAME") = oSheet.Range("B" & I.ToString).Text
                Else
                    DTROWSAVE("COMPANYNAME") = ""
                End If

                If IsDBNull(oSheet.Range("C" & I.ToString).Text) = False Then
                    DTROWSAVE("ADD1") = oSheet.Range("C" & I.ToString).Text
                Else
                    DTROWSAVE("ADD1") = ""
                End If

                If IsDBNull(oSheet.Range("D" & I.ToString).Text) = False Then
                    DTROWSAVE("ADD2") = oSheet.Range("D" & I.ToString).Text
                Else
                    DTROWSAVE("ADD2") = ""
                End If

                If IsDBNull(oSheet.Range("E" & I.ToString).Text) = False Then
                    DTROWSAVE("ADDRESS") = oSheet.Range("E" & I.ToString).Text
                Else
                    DTROWSAVE("ADDRESS") = ""
                End If

                If IsDBNull(oSheet.Range("F" & I.ToString).Text) = False Then
                    DTROWSAVE("CITYNAME") = oSheet.Range("F" & I.ToString).Text
                Else
                    DTROWSAVE("CITYNAME") = ""
                End If

                If IsDBNull(oSheet.Range("G" & I.ToString).Text) = False Then
                    DTROWSAVE("PINNO") = oSheet.Range("G" & I.ToString).Text
                Else
                    DTROWSAVE("PINNO") = 0
                End If

                If IsDBNull(oSheet.Range("H" & I.ToString).Text) = False Then
                    DTROWSAVE("STATE") = oSheet.Range("H" & I.ToString).Text
                Else
                    DTROWSAVE("STATE") = ""
                End If

                If IsDBNull(oSheet.Range("I" & I.ToString).Text) = False Then
                    DTROWSAVE("COUNTRY") = oSheet.Range("I" & I.ToString).Text
                Else
                    DTROWSAVE("COUNTRY") = ""
                End If

                If IsDBNull(oSheet.Range("J" & I.ToString).Text) = False Then
                    DTROWSAVE("PHONENO") = oSheet.Range("J" & I.ToString).Text
                Else
                    DTROWSAVE("PHONENO") = ""
                End If

                If IsDBNull(oSheet.Range("K" & I.ToString).Text) = False Then
                    DTROWSAVE("MOBILENO") = oSheet.Range("K" & I.ToString).Text
                Else
                    DTROWSAVE("MOBILENO") = 0
                End If


                If IsDBNull(oSheet.Range("L" & I.ToString).Text) = False Then
                    DTROWSAVE("GSTIN") = oSheet.Range("L" & I.ToString).Text
                Else
                    DTROWSAVE("GSTIN") = ""
                End If

                If IsDBNull(oSheet.Range("M" & I.ToString).Text) = False Then
                    DTROWSAVE("GROUPNAME") = oSheet.Range("M" & I.ToString).Text
                Else
                    DTROWSAVE("GROUPNAME") = ""
                End If

                If IsDBNull(oSheet.Range("N" & I.ToString).Text) = False Then
                    DTROWSAVE("PANNO") = oSheet.Range("N" & I.ToString).Text
                Else
                    DTROWSAVE("PANNO") = ""
                End If

                If IsDBNull(oSheet.Range("O" & I.ToString).Text) = False Then
                    DTROWSAVE("BROKER") = oSheet.Range("O" & I.ToString).Text
                Else
                    DTROWSAVE("BROKER") = ""
                End If

                If IsDBNull(oSheet.Range("P" & I.ToString).Text) = False Then
                    DTROWSAVE("TRANSPORT") = oSheet.Range("P" & I.ToString).Text
                Else
                    DTROWSAVE("TRANSPORT") = ""
                End If

                If IsDBNull(oSheet.Range("Q" & I.ToString).Text) = False Then
                    DTROWSAVE("EMAIL") = oSheet.Range("Q" & I.ToString).Text
                Else
                    DTROWSAVE("EMAIL") = ""
                End If

                If IsDBNull(oSheet.Range("R" & I.ToString).Text) = False Then
                    DTROWSAVE("CRDAYS") = oSheet.Range("R" & I.ToString).Text
                Else
                    DTROWSAVE("CRDAYS") = ""
                End If

                If IsDBNull(oSheet.Range("S" & I.ToString).Text) = False Then
                    DTROWSAVE("SALESMAN") = oSheet.Range("S" & I.ToString).Text
                Else
                    DTROWSAVE("SALESMAN") = ""
                End If

                If IsDBNull(oSheet.Range("T" & I.ToString).Text) = False Then
                    DTROWSAVE("TDSPER") = oSheet.Range("T" & I.ToString).Text
                Else
                    DTROWSAVE("TDSPER") = ""
                End If

                If IsDBNull(oSheet.Range("U" & I.ToString).Text) = False Then
                    DTROWSAVE("TDSSECTION") = oSheet.Range("U" & I.ToString).Text
                Else
                    DTROWSAVE("TDSSECTION") = ""
                End If

                If IsDBNull(oSheet.Range("V" & I.ToString).Text) = False Then
                    DTROWSAVE("CMPNONCMP") = oSheet.Range("V" & I.ToString).Text
                Else
                    DTROWSAVE("CMPNONCMP") = ""
                End If

                If IsDBNull(oSheet.Range("W" & I.ToString).Text) = False Then
                    DTROWSAVE("DISCOUNT") = oSheet.Range("W" & I.ToString).Text
                Else
                    DTROWSAVE("DISCOUNT") = ""
                End If

                If IsDBNull(oSheet.Range("X" & I.ToString).Text) = False Then
                    DTROWSAVE("CASHDISC") = oSheet.Range("X" & I.ToString).Text
                Else
                    DTROWSAVE("CASHDISC") = ""
                End If

                If IsDBNull(oSheet.Range("Y" & I.ToString).Text) = False Then
                    DTROWSAVE("COMMISSION") = oSheet.Range("Y" & I.ToString).Text
                Else
                    DTROWSAVE("COMMISSION") = ""
                End If

                If IsDBNull(oSheet.Range("Z" & I.ToString).Text) = False Then
                    DTROWSAVE("SHIPPINGADD") = oSheet.Range("Z" & I.ToString).Text
                Else
                    DTROWSAVE("SHIPPINGADD") = ""
                End If

                If IsDBNull(oSheet.Range("AA" & I.ToString).Text) = False Then
                    DTROWSAVE("RESINO") = oSheet.Range("AA" & I.ToString).Text
                Else
                    DTROWSAVE("RESINO") = ""
                End If

                If IsDBNull(oSheet.Range("AB" & I.ToString).Text) = False Then
                    DTROWSAVE("ALTNO") = oSheet.Range("AB" & I.ToString).Text
                Else
                    DTROWSAVE("ALTNO") = ""
                End If

                If IsDBNull(oSheet.Range("AC" & I.ToString).Text) = False Then
                    DTROWSAVE("FAX") = oSheet.Range("AC" & I.ToString).Text
                Else
                    DTROWSAVE("FAX") = ""
                End If

                If IsDBNull(oSheet.Range("AD" & I.ToString).Text) = False Then
                    DTROWSAVE("WEBSITE") = oSheet.Range("AD" & I.ToString).Text
                Else
                    DTROWSAVE("WEBSITE") = ""
                End If

                If IsDBNull(oSheet.Range("AE" & I.ToString).Text) = False Then
                    DTROWSAVE("REMARKS") = oSheet.Range("AE" & I.ToString).Text
                Else
                    DTROWSAVE("REMARKS") = ""
                End If

                If IsDBNull(oSheet.Range("AF" & I.ToString).Text) = False Then
                    DTROWSAVE("INTPER") = Val(oSheet.Range("AF" & I.ToString).Text)
                Else
                    DTROWSAVE("INTPER") = 0
                End If

                If IsDBNull(oSheet.Range("AG" & I.ToString).Text) = False Then
                    DTROWSAVE("DELIVERYAT") = oSheet.Range("AG" & I.ToString).Text
                Else
                    DTROWSAVE("DELIVERYAT") = ""
                End If

                If IsDBNull(oSheet.Range("AH" & I.ToString).Text) = False Then
                    DTROWSAVE("DELIVERYPINCODE") = oSheet.Range("AH" & I.ToString).Text
                Else
                    DTROWSAVE("DELIVERYPINCODE") = ""
                End If

                If IsDBNull(oSheet.Range("AI" & I.ToString).Text) = False Then
                    DTROWSAVE("KMS") = Val(oSheet.Range("AI" & I.ToString).Text)
                Else
                    DTROWSAVE("KMS") = 0
                End If

                If IsDBNull(oSheet.Range("AJ" & I.ToString).Text) = False Then
                    DTROWSAVE("BROKERAGECOMM") = Val(oSheet.Range("AJ" & I.ToString).Text)
                Else
                    DTROWSAVE("BROKERAGECOMM") = 0
                End If

                If IsDBNull(oSheet.Range("AK" & I.ToString).Text) = False Then
                    DTROWSAVE("WHATSAPPNO") = oSheet.Range("AK" & I.ToString).Text
                Else
                    DTROWSAVE("WHATSAPPNO") = ""
                End If

                If IsDBNull(oSheet.Range("AL" & I.ToString).Text) = False Then
                    DTROWSAVE("AREA") = oSheet.Range("AL" & I.ToString).Text
                Else
                    DTROWSAVE("AREA") = ""
                End If

                If IsDBNull(oSheet.Range("AM" & I.ToString).Text) = False Then
                    DTROWSAVE("TYPE") = oSheet.Range("AM" & I.ToString).Text
                Else
                    DTROWSAVE("TYPE") = ""
                End If

                If IsDBNull(oSheet.Range("AN" & I.ToString).Text) = False Then
                    DTROWSAVE("SIZETOLERANCE") = oSheet.Range("AN" & I.ToString).Text
                Else
                    DTROWSAVE("SIZETOLERANCE") = ""
                End If

                If IsDBNull(oSheet.Range("AO" & I.ToString).Text) = False Then
                    DTROWSAVE("GSMTOLERANCE") = oSheet.Range("AO" & I.ToString).Text
                Else
                    DTROWSAVE("GSMTOLERANCE") = ""
                End If

                If IsDBNull(oSheet.Range("AP" & I.ToString).Text) = False Then
                    DTROWSAVE("PATTERNTOLERANCE") = oSheet.Range("AP" & I.ToString).Text
                Else
                    DTROWSAVE("PATTERNTOLERANCE") = ""
                End If

                If IsDBNull(oSheet.Range("AQ" & I.ToString).Text) = False Then
                    DTROWSAVE("EXCESSQTY") = oSheet.Range("AQ" & I.ToString).Text
                Else
                    DTROWSAVE("EXCESSQTY") = ""
                End If

                If IsDBNull(oSheet.Range("AR" & I.ToString).Text) = False Then
                    DTROWSAVE("SEZTYPE") = oSheet.Range("AR" & I.ToString).Text
                Else
                    DTROWSAVE("SEZTYPE") = ""
                End If


                Dim ALPARAVAL As New ArrayList
                Dim OBJCMN As New ClsCommon
                Dim DTTABLE As DataTable = OBJCMN.search("CITY_ID AS CITYID", "", "CITYMASTER ", "AND CITY_NAME = '" & DTROWSAVE("CITYNAME") & "' AND CITY_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW CITYNAME
                    Dim objyearmaster As New ClsYearMaster
                    objyearmaster.savecity(DTROWSAVE("CITYNAME"), CmpId, Locationid, Userid, YearId, " and city_name = '" & DTROWSAVE("CITYNAME") & "' AND CITY_CMPID = " & CmpId & " AND CITY_LOCATIONID = " & Locationid & " AND CITY_YEARID = " & YearId)
                End If


                DTTABLE = OBJCMN.search("CITY_ID AS CITYID", "", "CITYMASTER ", "AND CITY_NAME = '" & DTROWSAVE("DELIVERYAT") & "' AND CITY_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW CITYNAME
                    Dim objyearmaster As New ClsYearMaster
                    objyearmaster.savecity(DTROWSAVE("DELIVERYAT"), CmpId, Locationid, Userid, YearId, " and city_name = '" & DTROWSAVE("DELIVERYAT") & "' AND CITY_CMPID = " & CmpId & " AND CITY_LOCATIONID = " & Locationid & " AND CITY_YEARID = " & YearId)
                End If


                DTTABLE = OBJCMN.search("AREA_ID AS AREAID", "", "AREAMASTER ", "AND AREA_NAME = '" & DTROWSAVE("AREA") & "' AND AREA_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW AREA
                    Dim objyearmaster As New ClsYearMaster
                    objyearmaster.savearea(DTROWSAVE("AREA"), CmpId, Locationid, Userid, YearId, " and AREA_name = '" & DTROWSAVE("AREA") & "' AND AREA_CMPID = " & CmpId & " AND AREA_LOCATIONID = " & Locationid & " AND AREA_YEARID = " & YearId)
                End If


                DTTABLE = OBJCMN.search("STATE_ID AS STATEID", "", "STATEMASTER ", "AND STATE_NAME = '" & DTROWSAVE("STATE") & "' AND STATE_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW STATE
                    Dim objyearmaster As New ClsYearMaster
                    objyearmaster.savestate(DTROWSAVE("STATE"), CmpId, Locationid, Userid, YearId, " and STATE_name = '" & DTROWSAVE("STATE") & "' AND STATE_YEARID = " & YearId)
                End If


                DTTABLE = OBJCMN.search("COUNTRY_ID AS COUNTRYID", "", "COUNTRYMASTER ", "AND COUNTRY_NAME = '" & DTROWSAVE("COUNTRY") & "' AND COUNTRY_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW COUNTRY
                    Dim objyearmaster As New ClsYearMaster
                    objyearmaster.savecountry(DTROWSAVE("COUNTRY"), CmpId, Locationid, Userid, YearId, " and COUNTRY_name = '" & DTROWSAVE("COUNTRY") & "' AND COUNTRY_YEARID = " & YearId)
                End If


                'check whether ITEMNAME is already present or not
                DTTABLE = OBJCMN.search("ACC_CMPNAME AS COMPANYNAME", "", "LEDGERS ", " AND ACC_CMPNAME = '" & DTROWSAVE("COMPANYNAME") & "' AND ACC_YEARID = " & YearId)
                If DTTABLE.Rows.Count > 0 Then GoTo SKIPLINE



                'ADD IN ACCOUNTSMASTER
                ALPARAVAL.Clear()
                Dim OBJSM As New ClsAccountsMaster

                ALPARAVAL.Add(DTROWSAVE("COMPANYNAME"))
                ALPARAVAL.Add("")   'NAME
                ALPARAVAL.Add(DTROWSAVE("GROUPNAME"))
                ALPARAVAL.Add(0)    'OPBAL
                ALPARAVAL.Add("Cr.")
                ALPARAVAL.Add(DTROWSAVE("ADD1"))
                ALPARAVAL.Add(DTROWSAVE("ADD2"))
                ALPARAVAL.Add("")   'LANDMARK
                ALPARAVAL.Add(DTROWSAVE("AREA"))   'AREA
                ALPARAVAL.Add("")   'STD
                ALPARAVAL.Add(DTROWSAVE("CITYNAME"))
                ALPARAVAL.Add(DTROWSAVE("PINNO"))
                ALPARAVAL.Add(DTROWSAVE("STATE"))
                ALPARAVAL.Add(DTROWSAVE("COUNTRY"))
                ALPARAVAL.Add(Val(DTROWSAVE("CRDAYS")))
                ALPARAVAL.Add(0)    'CRLIMIT
                ALPARAVAL.Add("")   'ADDLESS
                ALPARAVAL.Add(DTROWSAVE("RESINO"))   'RESI
                ALPARAVAL.Add(DTROWSAVE("ALTNO"))   'ALT
                ALPARAVAL.Add(DTROWSAVE("PHONENO"))
                ALPARAVAL.Add(DTROWSAVE("MOBILENO"))
                ALPARAVAL.Add(DTROWSAVE("FAX"))   'FAX
                ALPARAVAL.Add(DTROWSAVE("WEBSITE"))   'WEBSITE
                ALPARAVAL.Add(DTROWSAVE("EMAIL"))   'EMAIL

                ALPARAVAL.Add("")   'PARTYBANK
                ALPARAVAL.Add("")   'ACCTYPE
                ALPARAVAL.Add("")   'ACCNO
                ALPARAVAL.Add("")   'IFSCCODE
                ALPARAVAL.Add("")   'BRANCH
                ALPARAVAL.Add("")   'BANKCITY


                ALPARAVAL.Add(DTROWSAVE("TRANSPORT"))   'TRANS
                ALPARAVAL.Add(DTROWSAVE("BROKER"))   'AGENT
                ALPARAVAL.Add(Val(DTROWSAVE("COMMISSION")))    'AGENTCOM
                ALPARAVAL.Add(Val(DTROWSAVE("DISCOUNT")))    'DISC
                ALPARAVAL.Add(Val(DTROWSAVE("CASHDISC")))    'CDPER

                ALPARAVAL.Add(DTROWSAVE("PANNO"))   'PAN
                ALPARAVAL.Add("")   'EXISE
                ALPARAVAL.Add("")   'RANGE
                ALPARAVAL.Add("")   'DIVISION
                ALPARAVAL.Add("")   'TIN
                ALPARAVAL.Add("")   'CST


                ALPARAVAL.Add("")   'VAT
                ALPARAVAL.Add(DTROWSAVE("GSTIN"))
                ALPARAVAL.Add("")   'ST
                ALPARAVAL.Add("")   'REGISTER
                ALPARAVAL.Add(DTROWSAVE("SIZETOLERANCE"))   'SIZETOLERAMCE
                ALPARAVAL.Add(DTROWSAVE("GSMTOLERANCE"))   'GSMTOLERANCE
                ALPARAVAL.Add(DTROWSAVE("PATTERNTOLERANCE"))   'PATTERNTOLERANCE
                ALPARAVAL.Add(DTROWSAVE("EXCESSQTY"))   'ACCESSQTY


                ALPARAVAL.Add(DTROWSAVE("ADDRESS"))
                ALPARAVAL.Add(DTROWSAVE("SHIPPINGADD"))   'SHIPADD
                ALPARAVAL.Add(DTROWSAVE("REMARKS"))   'REMARKS

                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(Userid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(0)    'TRANSFER
                ALPARAVAL.Add(DTROWSAVE("CODE"))

                ALPARAVAL.Add("")    'GRIDSRNO
                ALPARAVAL.Add("")    'ITEMCODE
                ALPARAVAL.Add("")    'SUBMITDATE
                ALPARAVAL.Add("")    'APPROVEDATE
                ALPARAVAL.Add("")    'EXPIREDATE


                'TDS
                '*******************************
                ALPARAVAL.Add(0)    'ISTDS
                ALPARAVAL.Add("")   'DEDUCTEETYPE
                ALPARAVAL.Add(0)    'ISLOWER

                ALPARAVAL.Add(DTROWSAVE("TDSSECTION"))   'SECTION
                ALPARAVAL.Add(Val(0))   'TDSRATE
                ALPARAVAL.Add(Val(DTROWSAVE("TDSPER")))    'TDSPER
                ALPARAVAL.Add(0) 'SURCHARGE
                ALPARAVAL.Add(0) 'LIMIT
                ALPARAVAL.Add(0)    'TDSAC
                ALPARAVAL.Add(DTROWSAVE("CMPNONCMP"))   'NATUREOFPAY
                If DTROWSAVE("TYPE") <> "" Then ALPARAVAL.Add(DTROWSAVE("TYPE")) Else ALPARAVAL.Add("ACCOUNTS")   'TYPE


                ALPARAVAL.Add(0)   'RCM
                ALPARAVAL.Add(0)   'BLOCKED
                ALPARAVAL.Add(0)   'KMS
                ALPARAVAL.Add(DTROWSAVE("PINNO"))       'DELIVERYPINCODE (SAME AS PINCODE WHILE UPLOADING)
                ALPARAVAL.Add(DTROWSAVE("SEZTYPE"))    'SEZTYPE


                ALPARAVAL.Add("")   'TDSDEDUCTEDAC
                ALPARAVAL.Add("")   'CALC
                ALPARAVAL.Add(0)    'TCS
                ALPARAVAL.Add(0)   'PARTYTDS
                ALPARAVAL.Add(0)    'TDSONGTOTAL
                ALPARAVAL.Add(0)   'GSTINVERIFIED
                ALPARAVAL.Add("")   'TDSFORM
                ALPARAVAL.Add("")   'TDSCOMPANY


                ALPARAVAL.Add("")   'GROUP OF COMPANIES
                ALPARAVAL.Add("")   'MSME
                ALPARAVAL.Add("")   'MSME TYPE
                ALPARAVAL.Add(0)   'INTPER


                OBJSM.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJSM.SAVE()

                DTROWSAVE = DTSAVE.NewRow()

SKIPLINE:
            Next

            oBook.Close()

            Exit Sub

            '************************************ END OF CODE FOR LEDGER UPLOAD ****************************



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UPLOADITEMMENU_Click(sender As Object, e As EventArgs) Handles UPLOADITEMMENU.Click
        Try
            If InputBox("Enter Master Password") <> "Infosys@123" Then Exit Sub

            '************************************ LEDGER UPLOAD ****************************
            'upload the files data
            ''Reading from Excel Woorkbook
            Dim cPart As Microsoft.Office.Interop.Excel.Range
            Dim oExcel As Microsoft.Office.Interop.Excel.Application = CreateObject("Excel.Application")
            Dim oBook As Microsoft.Office.Interop.Excel.Workbook = oExcel.Workbooks.Open("E:\" & InputBox("Enter File Name").ToString.Trim, , False)
            Dim oSheet As New Microsoft.Office.Interop.Excel.Worksheet
            oSheet = oBook.Worksheets("Sheet1")

            'GRID

            Dim DTSAVE As New System.Data.DataTable
            DTSAVE.Columns.Add("ITEMCODE")
            DTSAVE.Columns.Add("FILENO")
            DTSAVE.Columns.Add("ITEMNAME")
            DTSAVE.Columns.Add("LEAFLET")
            DTSAVE.Columns.Add("COORDINATOR")
            DTSAVE.Columns.Add("PAPERGSM")
            DTSAVE.Columns.Add("COLOR")
            DTSAVE.Columns.Add("DESIGN")
            DTSAVE.Columns.Add("PHARMACODE")
            DTSAVE.Columns.Add("VARNISH")
            DTSAVE.Columns.Add("PAPERMATERIAL")
            DTSAVE.Columns.Add("CUTSIZE")
            DTSAVE.Columns.Add("VERTICAL")
            DTSAVE.Columns.Add("HORIZONTAL")
            DTSAVE.Columns.Add("UPS")
            DTSAVE.Columns.Add("PAPERSIZE")
            DTSAVE.Columns.Add("GRAIN")
            DTSAVE.Columns.Add("SIDEPRINT")
            DTSAVE.Columns.Add("TEARTAPE")
            DTSAVE.Columns.Add("KNIFES")
            DTSAVE.Columns.Add("PROOFSEND")
            DTSAVE.Columns.Add("PROOFOK")
            DTSAVE.Columns.Add("PERFORATION")
            DTSAVE.Columns.Add("SHADECARD")
            DTSAVE.Columns.Add("SHADEAPPROVE")
            DTSAVE.Columns.Add("SHADEDATE")
            DTSAVE.Columns.Add("ACTUALWIDTH")
            DTSAVE.Columns.Add("ACTUALHEIGHT")
            DTSAVE.Columns.Add("FOLDWIDTH")
            DTSAVE.Columns.Add("FOLDHEIGHT")
            DTSAVE.Columns.Add("ARTWORKDATE")
            DTSAVE.Columns.Add("PROOFSENDDATE")
            DTSAVE.Columns.Add("PROOFOKDATE")
            DTSAVE.Columns.Add("SHADESENDDATE")
            DTSAVE.Columns.Add("SHADEAPPDATE")
            DTSAVE.Columns.Add("FOLDED")
            DTSAVE.Columns.Add("HSNCODE")
            DTSAVE.Columns.Add("2DCODE")
            DTSAVE.Columns.Add("POSITIVESENDDATE")
            DTSAVE.Columns.Add("POSITIVERECDATE")
            DTSAVE.Columns.Add("CGSTPER")
            DTSAVE.Columns.Add("SGSTPER")
            DTSAVE.Columns.Add("IGSTPER")

            Dim ARR As New ArrayList
            Dim COLIND As Integer = 0
            Dim DTROWSAVE As System.Data.DataRow = DTSAVE.NewRow()

            Dim FROMROWNO As Integer = Val(InputBox("Enter Start Row No"))
            Dim TOROWNO As Integer = Val(InputBox("Enter End Row No"))

            For I As Integer = FROMROWNO To TOROWNO

                If IsDBNull(oSheet.Range("A" & I.ToString).Text) = False Then
                    DTROWSAVE("ITEMCODE") = oSheet.Range("A" & I.ToString).Text
                Else
                    DTROWSAVE("ITEMCODE") = ""
                End If

                If IsDBNull(oSheet.Range("B" & I.ToString).Text) = False Then
                    DTROWSAVE("FILENO") = oSheet.Range("B" & I.ToString).Text
                Else
                    DTROWSAVE("FILENO") = ""
                End If

                If IsDBNull(oSheet.Range("C" & I.ToString).Text) = False Then
                    DTROWSAVE("ITEMNAME") = oSheet.Range("C" & I.ToString).Text
                Else
                    DTROWSAVE("ITEMNAME") = ""
                End If

                If IsDBNull(oSheet.Range("D" & I.ToString).Text) = False Then
                    DTROWSAVE("LEAFLET") = oSheet.Range("D" & I.ToString).Text
                Else
                    DTROWSAVE("LEAFLET") = ""
                End If

                If IsDBNull(oSheet.Range("E" & I.ToString).Text) = False Then
                    DTROWSAVE("COORDINATOR") = oSheet.Range("E" & I.ToString).Text
                Else
                    DTROWSAVE("COORDINATOR") = ""
                End If

                If IsDBNull(oSheet.Range("F" & I.ToString).Text) = False Then
                    DTROWSAVE("PAPERGSM") = oSheet.Range("F" & I.ToString).Text
                Else
                    DTROWSAVE("PAPERGSM") = ""
                End If

                If IsDBNull(oSheet.Range("G" & I.ToString).Text) = False Then
                    DTROWSAVE("COLOR") = oSheet.Range("G" & I.ToString).Text
                Else
                    DTROWSAVE("COLOR") = ""
                End If

                If IsDBNull(oSheet.Range("H" & I.ToString).Text) = False Then
                    DTROWSAVE("DESIGN") = oSheet.Range("H" & I.ToString).Text
                Else
                    DTROWSAVE("DESIGN") = ""
                End If

                If IsDBNull(oSheet.Range("I" & I.ToString).Text) = False Then
                    DTROWSAVE("PHARMACODE") = oSheet.Range("I" & I.ToString).Text
                Else
                    DTROWSAVE("PHARMACODE") = ""
                End If

                If IsDBNull(oSheet.Range("J" & I.ToString).Text) = False Then
                    DTROWSAVE("VARNISH") = oSheet.Range("J" & I.ToString).Text
                Else
                    DTROWSAVE("VARNISH") = ""
                End If

                If IsDBNull(oSheet.Range("K" & I.ToString).Text) = False Then
                    DTROWSAVE("PAPERMATERIAL") = oSheet.Range("K" & I.ToString).Text
                Else
                    DTROWSAVE("PAPERMATERIAL") = ""
                End If


                If IsDBNull(oSheet.Range("L" & I.ToString).Text) = False Then
                    DTROWSAVE("CUTSIZE") = oSheet.Range("L" & I.ToString).Text
                Else
                    DTROWSAVE("CUTSIZE") = ""
                End If

                If IsDBNull(oSheet.Range("M" & I.ToString).Text) = False Then
                    DTROWSAVE("VERTICAL") = oSheet.Range("M" & I.ToString).Text
                Else
                    DTROWSAVE("VERTICAL") = ""
                End If

                If IsDBNull(oSheet.Range("N" & I.ToString).Text) = False Then
                    DTROWSAVE("HORIZONTAL") = oSheet.Range("N" & I.ToString).Text
                Else
                    DTROWSAVE("HORIZONTAL") = ""
                End If

                If IsDBNull(oSheet.Range("O" & I.ToString).Text) = False Then
                    DTROWSAVE("UPS") = oSheet.Range("O" & I.ToString).Text
                Else
                    DTROWSAVE("UPS") = ""
                End If

                If IsDBNull(oSheet.Range("P" & I.ToString).Text) = False Then
                    DTROWSAVE("PAPERSIZE") = oSheet.Range("P" & I.ToString).Text
                Else
                    DTROWSAVE("PAPERSIZE") = ""
                End If

                If IsDBNull(oSheet.Range("Q" & I.ToString).Text) = False Then
                    DTROWSAVE("GRAIN") = oSheet.Range("Q" & I.ToString).Text
                Else
                    DTROWSAVE("GRAIN") = ""
                End If

                If IsDBNull(oSheet.Range("R" & I.ToString).Text) = False Then
                    DTROWSAVE("SIDEPRINT") = oSheet.Range("R" & I.ToString).Text
                Else
                    DTROWSAVE("SIDEPRINT") = ""
                End If

                If IsDBNull(oSheet.Range("S" & I.ToString).Text) = False Then
                    DTROWSAVE("TEARTAPE") = oSheet.Range("S" & I.ToString).Text
                Else
                    DTROWSAVE("TEARTAPE") = ""
                End If

                If IsDBNull(oSheet.Range("T" & I.ToString).Text) = False Then
                    DTROWSAVE("KNIFES") = Val(oSheet.Range("T" & I.ToString).Text)
                Else
                    DTROWSAVE("KNIFES") = 0
                End If

                If IsDBNull(oSheet.Range("U" & I.ToString).Text) = False Then
                    DTROWSAVE("PROOFSEND") = Val(oSheet.Range("U" & I.ToString).Text)
                Else
                    DTROWSAVE("PROOFSEND") = 0
                End If

                If IsDBNull(oSheet.Range("V" & I.ToString).Text) = False Then
                    DTROWSAVE("PROOFOK") = Val(oSheet.Range("V" & I.ToString).Text)
                Else
                    DTROWSAVE("PROOFOK") = 0
                End If

                If IsDBNull(oSheet.Range("W" & I.ToString).Text) = False Then
                    DTROWSAVE("PERFORATION") = Val(oSheet.Range("W" & I.ToString).Text)
                Else
                    DTROWSAVE("PERFORATION") = 0
                End If

                If IsDBNull(oSheet.Range("X" & I.ToString).Text) = False Then
                    DTROWSAVE("SHADECARD") = Val(oSheet.Range("X" & I.ToString).Text)
                Else
                    DTROWSAVE("SHADECARD") = 0
                End If

                If IsDBNull(oSheet.Range("Y" & I.ToString).Text) = False Then
                    DTROWSAVE("SHADEAPPROVE") = Val(oSheet.Range("Y" & I.ToString).Text)
                Else
                    DTROWSAVE("SHADEAPPROVE") = 0
                End If

                If IsDBNull(oSheet.Range("Z" & I.ToString).Text) = False Then
                    DTROWSAVE("SHADEDATE") = oSheet.Range("Z" & I.ToString).Text
                Else
                    DTROWSAVE("SHADEDATE") = ""
                End If

                If IsDBNull(oSheet.Range("AA" & I.ToString).Text) = False Then
                    DTROWSAVE("ACTUALWIDTH") = oSheet.Range("AA" & I.ToString).Text
                Else
                    DTROWSAVE("ACTUALWIDTH") = ""
                End If

                If IsDBNull(oSheet.Range("AB" & I.ToString).Text) = False Then
                    DTROWSAVE("ACTUALHEIGHT") = oSheet.Range("AB" & I.ToString).Text
                Else
                    DTROWSAVE("ACTUALHEIGHT") = ""
                End If

                If IsDBNull(oSheet.Range("AC" & I.ToString).Text) = False Then
                    DTROWSAVE("FOLDWIDTH") = oSheet.Range("AC" & I.ToString).Text
                Else
                    DTROWSAVE("FOLDWIDTH") = ""
                End If

                If IsDBNull(oSheet.Range("AD" & I.ToString).Text) = False Then
                    DTROWSAVE("FOLDHEIGHT") = oSheet.Range("AD" & I.ToString).Text
                Else
                    DTROWSAVE("FOLDHEIGHT") = ""
                End If

                If IsDBNull(oSheet.Range("AE" & I.ToString).Text) = False Then
                    DTROWSAVE("ARTWORKDATE") = oSheet.Range("AE" & I.ToString).Text
                Else
                    DTROWSAVE("ARTWORKDATE") = ""
                End If

                If IsDBNull(oSheet.Range("AF" & I.ToString).Text) = False Then
                    DTROWSAVE("PROOFSENDDATE") = oSheet.Range("AF" & I.ToString).Text
                Else
                    DTROWSAVE("PROOFSENDDATE") = ""
                End If

                If IsDBNull(oSheet.Range("AG" & I.ToString).Text) = False Then
                    DTROWSAVE("PROOFOKDATE") = oSheet.Range("AG" & I.ToString).Text
                Else
                    DTROWSAVE("PROOFOKDATE") = ""
                End If

                If IsDBNull(oSheet.Range("AH" & I.ToString).Text) = False Then
                    DTROWSAVE("SHADESENDDATE") = oSheet.Range("AH" & I.ToString).Text
                Else
                    DTROWSAVE("SHADESENDDATE") = ""
                End If

                If IsDBNull(oSheet.Range("AI" & I.ToString).Text) = False Then
                    DTROWSAVE("SHADEAPPDATE") = oSheet.Range("AI" & I.ToString).Text
                Else
                    DTROWSAVE("SHADEAPPDATE") = ""
                End If

                If IsDBNull(oSheet.Range("AJ" & I.ToString).Text) = False Then
                    DTROWSAVE("FOLDED") = oSheet.Range("AJ" & I.ToString).Text
                Else
                    DTROWSAVE("FOLDED") = ""
                End If

                If IsDBNull(oSheet.Range("AK" & I.ToString).Text) = False Then
                    DTROWSAVE("HSNCODE") = oSheet.Range("AK" & I.ToString).Text
                Else
                    DTROWSAVE("HSNCODE") = ""
                End If

                If IsDBNull(oSheet.Range("AL" & I.ToString).Text) = False Then
                    DTROWSAVE("2DCODE") = oSheet.Range("AL" & I.ToString).Text
                Else
                    DTROWSAVE("2DCODE") = ""
                End If

                If IsDBNull(oSheet.Range("AM" & I.ToString).Text) = False Then
                    DTROWSAVE("POSITIVESENDDATE") = oSheet.Range("AM" & I.ToString).Text
                Else
                    DTROWSAVE("POSITIVESENDDATE") = ""
                End If

                If IsDBNull(oSheet.Range("AN" & I.ToString).Text) = False Then
                    DTROWSAVE("POSITIVERECDATE") = oSheet.Range("AN" & I.ToString).Text
                Else
                    DTROWSAVE("POSITIVERECDATE") = ""
                End If

                If IsDBNull(oSheet.Range("AO" & I.ToString).Text) = False Then
                    DTROWSAVE("CGSTPER") = Val(oSheet.Range("AO" & I.ToString).Text)
                Else
                    DTROWSAVE("CGSTPER") = 0
                End If

                If IsDBNull(oSheet.Range("AP" & I.ToString).Text) = False Then
                    DTROWSAVE("SGSTPER") = Val(oSheet.Range("AP" & I.ToString).Text)
                Else
                    DTROWSAVE("SGSTPER") = 0
                End If

                If IsDBNull(oSheet.Range("AQ" & I.ToString).Text) = False Then
                    DTROWSAVE("IGSTPER") = Val(oSheet.Range("AQ" & I.ToString).Text)
                Else
                    DTROWSAVE("IGSTPER") = 0
                End If


                Dim OBJCMN As New ClsCommon
                Dim DTTABLE As DataTable = OBJCMN.search("ITEM_CODE AS ITEMCODE", "", "ITEMMASTER", " AND ITEM_CODE = '" & DTROWSAVE("ITEMCODE") & "' AND ITEM_YEARID = " & YearId)
                If DTTABLE.Rows.Count > 0 Then GoTo SKIPLINE



                Dim ALPARAVAL As New ArrayList
                'COORDINATOR
                DTTABLE = OBJCMN.search("COORDINATOR_ID AS COORDINATORID", "", "COORDINATORMASTER ", "AND COORDINATOR_NAME = '" & DTROWSAVE("COORDINATOR") & "' AND COORDINATOR_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW CATEGORY
                    Dim OBJCOORDINATOR As New ClsCoordinatorMaster
                    OBJCOORDINATOR.alParaval.Add(DTROWSAVE("COORDINATOR"))
                    OBJCOORDINATOR.alParaval.Add("")   'TEL
                    OBJCOORDINATOR.alParaval.Add("")   'EXT
                    OBJCOORDINATOR.alParaval.Add("")   'MOBILE
                    OBJCOORDINATOR.alParaval.Add("")   'AREA
                    OBJCOORDINATOR.alParaval.Add("")   'EMAIL
                    OBJCOORDINATOR.alParaval.Add("")   'REMARKS
                    OBJCOORDINATOR.alParaval.Add(CmpId)
                    OBJCOORDINATOR.alParaval.Add(0)
                    OBJCOORDINATOR.alParaval.Add(Userid)
                    OBJCOORDINATOR.alParaval.Add(YearId)
                    OBJCOORDINATOR.alParaval.Add(0)
                    Dim INTRESCAT As Integer = OBJCOORDINATOR.save()
                End If



                'PAPERGSM
                DTTABLE = OBJCMN.search("PAPERGSM_ID AS PAPERGSMID", "", "PAPERGSMMASTER", "AND PAPERGSM_NAME = '" & DTROWSAVE("PAPERGSM") & "' AND PAPERGSM_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW CATEGORY
                    Dim OBJPAPERGSM As New ClsPaperMaterial
                    OBJPAPERGSM.alParaval.Add(DTROWSAVE("PAPERGSM"))
                    OBJPAPERGSM.alParaval.Add("")   'REMARKS
                    OBJPAPERGSM.alParaval.Add(CmpId)
                    OBJPAPERGSM.alParaval.Add(0)
                    OBJPAPERGSM.alParaval.Add(Userid)
                    OBJPAPERGSM.alParaval.Add(YearId)
                    OBJPAPERGSM.alParaval.Add(0)
                    OBJPAPERGSM.alParaval.Add("PAPERGSM") 'FRMSTRING

                    Dim INTRESCAT As Integer = OBJPAPERGSM.save()
                End If


                'COLOR
                DTTABLE = OBJCMN.search("COLOR_ID AS COLORID", "", "COLORMASTER", "AND COLOR_name = '" & DTROWSAVE("COLOR") & "' AND COLOR_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW CATEGORY
                    Dim OBJCOLOR As New ClsPaperMaterial
                    OBJCOLOR.alParaval.Add(DTROWSAVE("COLOR"))
                    OBJCOLOR.alParaval.Add("")   'REMARKS
                    OBJCOLOR.alParaval.Add(CmpId)
                    OBJCOLOR.alParaval.Add(0)
                    OBJCOLOR.alParaval.Add(Userid)
                    OBJCOLOR.alParaval.Add(YearId)
                    OBJCOLOR.alParaval.Add(0)
                    OBJCOLOR.alParaval.Add("COLOR") 'FRMSTRING

                    Dim INTRESCAT As Integer = OBJCOLOR.save()
                End If




                'DESIGN
                DTTABLE = OBJCMN.search("DESIGN_ID AS DESIGNID", "", "DESIGNMASTER", "AND DESIGN_name = '" & DTROWSAVE("DESIGN") & "' AND DESIGN_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW CATEGORY
                    Dim OBJDESIGN As New ClsPaperMaterial
                    OBJDESIGN.alParaval.Add(DTROWSAVE("DESIGN"))
                    OBJDESIGN.alParaval.Add("")   'REMARKS
                    OBJDESIGN.alParaval.Add(CmpId)
                    OBJDESIGN.alParaval.Add(0)
                    OBJDESIGN.alParaval.Add(Userid)
                    OBJDESIGN.alParaval.Add(YearId)
                    OBJDESIGN.alParaval.Add(0)
                    OBJDESIGN.alParaval.Add("PAPERDESIGN") 'FRMSTRING

                    Dim INTRESCAT As Integer = OBJDESIGN.save()
                End If



                'PAPERMATERIAL
                DTTABLE = OBJCMN.search("PAPERMATERIAL_ID AS PAPERMATERIALID", "", "PAPERMATERIALMASTER", "AND PAPERMATERIAL_NAME = '" & DTROWSAVE("PAPERMATERIAL") & "' AND PAPERMATERIAL_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW CATEGORY
                    Dim OBJPAPERMATERIAL As New ClsPaperMaterial
                    OBJPAPERMATERIAL.alParaval.Add(DTROWSAVE("PAPERMATERIAL"))
                    OBJPAPERMATERIAL.alParaval.Add("")   'REMARKS
                    OBJPAPERMATERIAL.alParaval.Add(CmpId)
                    OBJPAPERMATERIAL.alParaval.Add(0)
                    OBJPAPERMATERIAL.alParaval.Add(Userid)
                    OBJPAPERMATERIAL.alParaval.Add(YearId)
                    OBJPAPERMATERIAL.alParaval.Add(0)
                    OBJPAPERMATERIAL.alParaval.Add("PAPERMATERIAL") 'FRMSTRING

                    Dim INTRESCAT As Integer = OBJPAPERMATERIAL.save()
                End If



                'PAPERSIZE
                DTTABLE = OBJCMN.search("PAPERSIZE_ID AS PAPERSIZEID", "", "PAPERSIZEMASTER", "AND PAPERSIZE_NAME = '" & DTROWSAVE("PAPERSIZE") & "' AND PAPERSIZE_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW CATEGORY
                    Dim OBJPAPERSIZE As New ClsPaperMaterial
                    OBJPAPERSIZE.alParaval.Add(DTROWSAVE("PAPERSIZE"))
                    OBJPAPERSIZE.alParaval.Add("")   'REMARKS
                    OBJPAPERSIZE.alParaval.Add(CmpId)
                    OBJPAPERSIZE.alParaval.Add(0)
                    OBJPAPERSIZE.alParaval.Add(Userid)
                    OBJPAPERSIZE.alParaval.Add(YearId)
                    OBJPAPERSIZE.alParaval.Add(0)
                    OBJPAPERSIZE.alParaval.Add("PAPERSIZE") 'FRMSTRING

                    Dim INTRESCAT As Integer = OBJPAPERSIZE.save()
                End If



                'TEARTAPE
                DTTABLE = OBJCMN.search("TEARTAPE_ID AS TEARTAPEID", "", "TEARTAPEMASTER", "AND TEARTAPE_NAME = '" & DTROWSAVE("TEARTAPE") & "' AND TEARTAPE_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW CATEGORY
                    Dim OBJTEARTAPE As New ClsPaperMaterial
                    OBJTEARTAPE.alParaval.Add(DTROWSAVE("TEARTAPE"))
                    OBJTEARTAPE.alParaval.Add("")   'REMARKS
                    OBJTEARTAPE.alParaval.Add(CmpId)
                    OBJTEARTAPE.alParaval.Add(0)
                    OBJTEARTAPE.alParaval.Add(Userid)
                    OBJTEARTAPE.alParaval.Add(YearId)
                    OBJTEARTAPE.alParaval.Add(0)
                    OBJTEARTAPE.alParaval.Add("TEARTAPE") 'FRMSTRING

                    Dim INTRESCAT As Integer = OBJTEARTAPE.save()
                End If





                'GRAINMASTER
                DTTABLE = OBJCMN.search("GRAIN_ID AS GRAINID", "", "GRAINMASTER", "AND grain_name = '" & DTROWSAVE("GRAIN") & "' AND GRAIN_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW CATEGORY
                    Dim OBJGRAIN As New ClsPaperMaterial
                    OBJGRAIN.alParaval.Add(DTROWSAVE("GRAIN"))
                    OBJGRAIN.alParaval.Add("")   'REMARKS
                    OBJGRAIN.alParaval.Add(CmpId)
                    OBJGRAIN.alParaval.Add(0)
                    OBJGRAIN.alParaval.Add(Userid)
                    OBJGRAIN.alParaval.Add(YearId)
                    OBJGRAIN.alParaval.Add(0)
                    OBJGRAIN.alParaval.Add("GRAINDIRECTION") 'FRMSTRING

                    Dim INTRESCAT As Integer = OBJGRAIN.save()
                End If





                'HSN SAVE
                If DTROWSAVE("HSNCODE") <> "" And Val(DTROWSAVE("CGSTPER")) > 0 And Val(DTROWSAVE("SGSTPER")) > 0 And Val(DTROWSAVE("IGSTPER")) > 0 Then
                    DTTABLE = OBJCMN.search("HSN_ID AS HSNCODEID", "", "HSNMASTER", " AND HSN_CODE = '" & DTROWSAVE("HSNCODE") & "' AND HSN_YEARID = " & YearId)
                    If DTTABLE.Rows.Count = 0 Then
                        'ADD NEW HSN
                        Dim OBJHSN As New ClsHSNMaster
                        OBJHSN.alParaval.Add("Goods")    'HSNTYPE
                        OBJHSN.alParaval.Add(UCase(DTROWSAVE("HSNCODE")))   'CODE
                        OBJHSN.alParaval.Add(UCase(DTROWSAVE("HSNCODE")))   'ITEMDESC
                        OBJHSN.alParaval.Add("") 'DESC
                        OBJHSN.alParaval.Add(Val(DTROWSAVE("CGSTPER")))  'GRIDCGST
                        OBJHSN.alParaval.Add(Val(DTROWSAVE("SGSTPER")))  'GRIDSGST
                        OBJHSN.alParaval.Add(Val(DTROWSAVE("IGSTPER")))  'GRIDIGST

                        OBJHSN.alParaval.Add(CmpId)
                        OBJHSN.alParaval.Add(Userid)
                        OBJHSN.alParaval.Add(YearId)

                        OBJHSN.alParaval.Add(0)  'EXPCGST
                        OBJHSN.alParaval.Add(0)  'EXPSGST
                        OBJHSN.alParaval.Add(0)  'EXPIGST

                        Dim INTRESCAT As Integer = OBJHSN.SAVE()
                    End If
                End If



                'ADD IN ITEMMASTER  
                ALPARAVAL.Clear()
                Dim OBJSM As New clsItemmaster

                ALPARAVAL.Add(DTROWSAVE("ITEMCODE"))
                ALPARAVAL.Add(DTROWSAVE("FILENO"))
                ALPARAVAL.Add(DTROWSAVE("ITEMNAME"))
                ALPARAVAL.Add(DTROWSAVE("HSNCODE"))
                ALPARAVAL.Add("FINISHED")  'TYPE
                ALPARAVAL.Add(DTROWSAVE("PROOFSEND"))
                ALPARAVAL.Add(DTROWSAVE("PROOFSENDDATE"))
                ALPARAVAL.Add(DTROWSAVE("PROOFOK"))
                ALPARAVAL.Add(DTROWSAVE("PROOFOKDATE"))
                ALPARAVAL.Add(DTROWSAVE("PERFORATION"))
                ALPARAVAL.Add(DTROWSAVE("SHADECARD"))
                ALPARAVAL.Add(DTROWSAVE("SHADESENDDATE"))
                ALPARAVAL.Add(DTROWSAVE("SHADEAPPROVE"))
                ALPARAVAL.Add(DTROWSAVE("SHADEAPPDATE"))
                ALPARAVAL.Add(DTROWSAVE("SHADEDATE"))
                ALPARAVAL.Add(DTROWSAVE("COORDINATOR"))
                ALPARAVAL.Add("")  ' ARTIST
                ALPARAVAL.Add("")  ' LINKS
                ALPARAVAL.Add("")  ' FONTS
                ALPARAVAL.Add("")  ' SOFTWARE
                ALPARAVAL.Add(DTROWSAVE("PAPERGSM"))
                ALPARAVAL.Add("")  ' SCREEN
                ALPARAVAL.Add(DTROWSAVE("COLOR"))
                ALPARAVAL.Add(DTROWSAVE("ACTUALWIDTH"))
                ALPARAVAL.Add(DTROWSAVE("ACTUALHEIGHT"))
                ALPARAVAL.Add(DTROWSAVE("DESIGN"))
                ALPARAVAL.Add(DTROWSAVE("PHARMACODE"))
                ALPARAVAL.Add(DTROWSAVE("FOLDWIDTH"))
                ALPARAVAL.Add(DTROWSAVE("FOLDHEIGHT"))
                ALPARAVAL.Add(DTROWSAVE("VARNISH"))
                ALPARAVAL.Add(DTROWSAVE("PAPERMATERIAL"))
                ALPARAVAL.Add(DTROWSAVE("CUTSIZE"))
                ALPARAVAL.Add(DTROWSAVE("VERTICAL"))
                ALPARAVAL.Add(DTROWSAVE("HORIZONTAL"))
                ALPARAVAL.Add(DTROWSAVE("UPS"))
                ALPARAVAL.Add(DTROWSAVE("PAPERSIZE"))
                ALPARAVAL.Add("")  ' LENGTH
                ALPARAVAL.Add(DTROWSAVE("GRAIN"))
                ALPARAVAL.Add(DTROWSAVE("KNIFES"))
                ALPARAVAL.Add("")  ' MATERIALCODE
                ALPARAVAL.Add(DTROWSAVE("TEARTAPE"))
                ALPARAVAL.Add(DTROWSAVE("SIDEPRINT"))
                ALPARAVAL.Add(DTROWSAVE("ARTWORKDATE"))
                ALPARAVAL.Add("")  ' ARTWORK
                ALPARAVAL.Add("")  ' REMARKS
                ALPARAVAL.Add(DTROWSAVE("POSITIVESENDDATE"))
                ALPARAVAL.Add(DTROWSAVE("POSITIVERECDATE"))
                ALPARAVAL.Add(DTROWSAVE("FOLDED"))
                ALPARAVAL.Add(DTROWSAVE("2DCODE"))
                ALPARAVAL.Add("")  ' MATERILTYPE
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(Userid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(0)  ' BLOCKED
                ALPARAVAL.Add(0)  ' NAME



                'SUMITEM
                ' ***************************
                ALPARAVAL.Add("")    'BOMSRNO
                ALPARAVAL.Add("")    'SUBITEMNAME

                OBJSM.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJSM.SAVE()

                DTROWSAVE = DTSAVE.NewRow()

SKIPLINE:
            Next

            oBook.Close()

            Exit Sub

            '************************************ END OF CODE FOR LEDGER UPLOAD ****************************



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UPLOADNONINVITEMMENU_Click(sender As Object, e As EventArgs) Handles UPLOADNONINVITEMMENU.Click
        Try
            If InputBox("Enter Master Password") <> "Infosys@123" Then Exit Sub

            '************************************ LEDGER UPLOAD ****************************
            'upload the files data
            ''Reading from Excel Woorkbook
            Dim cPart As Microsoft.Office.Interop.Excel.Range
            Dim oExcel As Microsoft.Office.Interop.Excel.Application = CreateObject("Excel.Application")
            Dim oBook As Microsoft.Office.Interop.Excel.Workbook = oExcel.Workbooks.Open("E:\" & InputBox("Enter File Name").ToString.Trim, , False)
            Dim oSheet As New Microsoft.Office.Interop.Excel.Worksheet
            oSheet = oBook.Worksheets("Sheet1")

            'GRID

            Dim DTSAVE As New System.Data.DataTable
            DTSAVE.Columns.Add("NONINVITEMNAME")
            DTSAVE.Columns.Add("CATEGORY")
            DTSAVE.Columns.Add("LENGTH")
            DTSAVE.Columns.Add("WIDTH")
            DTSAVE.Columns.Add("GSM")
            DTSAVE.Columns.Add("REMARKS")
            DTSAVE.Columns.Add("HSNCODE")
            DTSAVE.Columns.Add("ITEMCODE")
            DTSAVE.Columns.Add("PAPERMILL")
            DTSAVE.Columns.Add("PAPERMATERIAL")
            DTSAVE.Columns.Add("CGSTPER")
            DTSAVE.Columns.Add("SGSTPER")
            DTSAVE.Columns.Add("IGSTPER")

            Dim ARR As New ArrayList
            Dim COLIND As Integer = 0
            Dim DTROWSAVE As System.Data.DataRow = DTSAVE.NewRow()

            Dim FROMROWNO As Integer = Val(InputBox("Enter Start Row No"))
            Dim TOROWNO As Integer = Val(InputBox("Enter End Row No"))

            For I As Integer = FROMROWNO To TOROWNO

                If IsDBNull(oSheet.Range("A" & I.ToString).Text) = False Then
                    DTROWSAVE("NONINVITEMNAME") = oSheet.Range("A" & I.ToString).Text
                Else
                    DTROWSAVE("NONINVITEMNAME") = ""
                End If

                If IsDBNull(oSheet.Range("B" & I.ToString).Text) = False Then
                    DTROWSAVE("CATEGORY") = oSheet.Range("B" & I.ToString).Text
                Else
                    DTROWSAVE("CATEGORY") = ""
                End If

                If IsDBNull(oSheet.Range("C" & I.ToString).Text) = False Then
                    DTROWSAVE("LENGTH") = Val(oSheet.Range("C" & I.ToString).Text)
                Else
                    DTROWSAVE("LENGTH") = 0
                End If

                If IsDBNull(oSheet.Range("D" & I.ToString).Text) = False Then
                    DTROWSAVE("WIDTH") = Val(oSheet.Range("D" & I.ToString).Text)
                Else
                    DTROWSAVE("WIDTH") = 0
                End If

                If IsDBNull(oSheet.Range("E" & I.ToString).Text) = False Then
                    DTROWSAVE("GSM") = Val(oSheet.Range("E" & I.ToString).Text)
                Else
                    DTROWSAVE("GSM") = 0
                End If

                If IsDBNull(oSheet.Range("F" & I.ToString).Text) = False Then
                    DTROWSAVE("REMARKS") = oSheet.Range("F" & I.ToString).Text
                Else
                    DTROWSAVE("REMARKS") = ""
                End If

                If IsDBNull(oSheet.Range("G" & I.ToString).Text) = False Then
                    DTROWSAVE("HSNCODE") = oSheet.Range("G" & I.ToString).Text
                Else
                    DTROWSAVE("HSNCODE") = ""
                End If

                If IsDBNull(oSheet.Range("H" & I.ToString).Text) = False Then
                    DTROWSAVE("ITEMCODE") = oSheet.Range("H" & I.ToString).Text
                Else
                    DTROWSAVE("ITEMCODE") = ""
                End If

                If IsDBNull(oSheet.Range("I" & I.ToString).Text) = False Then
                    DTROWSAVE("PAPERMILL") = oSheet.Range("I" & I.ToString).Text
                Else
                    DTROWSAVE("PAPERMILL") = ""
                End If

                If IsDBNull(oSheet.Range("J" & I.ToString).Text) = False Then
                    DTROWSAVE("PAPERMATERIAL") = oSheet.Range("J" & I.ToString).Text
                Else
                    DTROWSAVE("PAPERMATERIAL") = ""
                End If

                If IsDBNull(oSheet.Range("K" & I.ToString).Text) = False Then
                    DTROWSAVE("CGSTPER") = Val(oSheet.Range("K" & I.ToString).Text)
                Else
                    DTROWSAVE("CGSTPER") = 0
                End If

                If IsDBNull(oSheet.Range("L" & I.ToString).Text) = False Then
                    DTROWSAVE("SGSTPER") = Val(oSheet.Range("L" & I.ToString).Text)
                Else
                    DTROWSAVE("SGSTPER") = 0
                End If

                If IsDBNull(oSheet.Range("M" & I.ToString).Text) = False Then
                    DTROWSAVE("IGSTPER") = Val(oSheet.Range("M" & I.ToString).Text)
                Else
                    DTROWSAVE("IGSTPER") = 0
                End If


                Dim OBJCMN As New ClsCommon
                Dim DTTABLE As DataTable = OBJCMN.search("NONINV_NAME AS NONINVITEMNAME", "", "NONINVITEMMASTER", " AND NONINV_NAME = '" & DTROWSAVE("NONINVITEMNAME") & "' AND NONINV_YEARID = " & YearId)
                If DTTABLE.Rows.Count > 0 Then GoTo SKIPLINE



                Dim ALPARAVAL As New ArrayList

                'CATEGORY
                DTTABLE = OBJCMN.search("CATEGORY_ID AS CATEGORYID", "", "CATEGORYMASTER", " AND CATEGORY_NAME = '" & DTROWSAVE("CATEGORY") & "' AND CATEGORY_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW CATEGORY
                    Dim OBJPAPERGSM As New ClsPaperMaterial
                    OBJPAPERGSM.alParaval.Add(DTROWSAVE("CATEGORY"))
                    OBJPAPERGSM.alParaval.Add("")   'REMARKS
                    OBJPAPERGSM.alParaval.Add(CmpId)
                    OBJPAPERGSM.alParaval.Add(0)
                    OBJPAPERGSM.alParaval.Add(Userid)
                    OBJPAPERGSM.alParaval.Add(YearId)
                    OBJPAPERGSM.alParaval.Add(0)
                    OBJPAPERGSM.alParaval.Add("CATEGORY") 'FRMSTRING

                    Dim INTRESCAT As Integer = OBJPAPERGSM.save()
                End If





                'PAPERMATERIAL
                DTTABLE = OBJCMN.search("PAPERMATERIAL_ID AS PAPERMATERIALID", "", "PAPERMATERIALMASTER", "AND PAPERMATERIAL_NAME = '" & DTROWSAVE("PAPERMATERIAL") & "' AND PAPERMATERIAL_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW CATEGORY
                    Dim OBJPAPERMATERIAL As New ClsPaperMaterial
                    OBJPAPERMATERIAL.alParaval.Add(DTROWSAVE("PAPERMATERIAL"))
                    OBJPAPERMATERIAL.alParaval.Add("")   'REMARKS
                    OBJPAPERMATERIAL.alParaval.Add(CmpId)
                    OBJPAPERMATERIAL.alParaval.Add(0)
                    OBJPAPERMATERIAL.alParaval.Add(Userid)
                    OBJPAPERMATERIAL.alParaval.Add(YearId)
                    OBJPAPERMATERIAL.alParaval.Add(0)
                    OBJPAPERMATERIAL.alParaval.Add("PAPERMATERIAL") 'FRMSTRING

                    Dim INTRESCAT As Integer = OBJPAPERMATERIAL.save()
                End If



                'PAPERSIZE
                DTTABLE = OBJCMN.search("PAPERMILL_ID AS PAPERMILLID", "", "PAPERMILLMASTER ", "AND PAPERMILL_NAME = '" & DTROWSAVE("PAPERMILL") & "' AND PAPERMILL_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW CATEGORY
                    Dim OBJPAPERSIZE As New ClsPaperMaterial
                    OBJPAPERSIZE.alParaval.Add(DTROWSAVE("PAPERMILL"))
                    OBJPAPERSIZE.alParaval.Add("")   'REMARKS
                    OBJPAPERSIZE.alParaval.Add(CmpId)
                    OBJPAPERSIZE.alParaval.Add(0)
                    OBJPAPERSIZE.alParaval.Add(Userid)
                    OBJPAPERSIZE.alParaval.Add(YearId)
                    OBJPAPERSIZE.alParaval.Add(0)
                    OBJPAPERSIZE.alParaval.Add("PAPERMILL") 'FRMSTRING

                    Dim INTRESCAT As Integer = OBJPAPERSIZE.save()
                End If



                'HSN SAVE
                If DTROWSAVE("HSNCODE") <> "" And Val(DTROWSAVE("CGSTPER")) > 0 And Val(DTROWSAVE("SGSTPER")) > 0 And Val(DTROWSAVE("IGSTPER")) > 0 Then
                    DTTABLE = OBJCMN.search("HSN_ID AS HSNCODEID", "", "HSNMASTER", " AND HSN_CODE = '" & DTROWSAVE("HSNCODE") & "' AND HSN_YEARID = " & YearId)
                    If DTTABLE.Rows.Count = 0 Then
                        'ADD NEW HSN
                        Dim OBJHSN As New ClsHSNMaster
                        OBJHSN.alParaval.Add("Goods")    'HSNTYPE
                        OBJHSN.alParaval.Add(UCase(DTROWSAVE("HSNCODE")))   'CODE
                        OBJHSN.alParaval.Add(UCase(DTROWSAVE("HSNCODE")))   'ITEMDESC
                        OBJHSN.alParaval.Add("") 'DESC
                        OBJHSN.alParaval.Add(Val(DTROWSAVE("CGSTPER")))  'GRIDCGST
                        OBJHSN.alParaval.Add(Val(DTROWSAVE("SGSTPER")))  'GRIDSGST
                        OBJHSN.alParaval.Add(Val(DTROWSAVE("IGSTPER")))  'GRIDIGST

                        OBJHSN.alParaval.Add(CmpId)
                        OBJHSN.alParaval.Add(Userid)
                        OBJHSN.alParaval.Add(YearId)

                        OBJHSN.alParaval.Add(0)  'EXPCGST
                        OBJHSN.alParaval.Add(0)  'EXPSGST
                        OBJHSN.alParaval.Add(0)  'EXPIGST

                        Dim INTRESCAT As Integer = OBJHSN.SAVE()
                    End If
                End If



                'ADD IN ITEMMASTER  
                ALPARAVAL.Clear()
                Dim OBJSM As New ClsNoninvItemmaster

                ALPARAVAL.Add(DTROWSAVE("NONINVITEMNAME"))
                ALPARAVAL.Add(DTROWSAVE("HSNCODE"))
                ALPARAVAL.Add(DTROWSAVE("CATEGORY"))
                ALPARAVAL.Add(DTROWSAVE("LENGTH"))
                ALPARAVAL.Add(DTROWSAVE("WIDTH"))
                ALPARAVAL.Add(DTROWSAVE("GSM"))
                ALPARAVAL.Add(DTROWSAVE("ITEMCODE"))
                ALPARAVAL.Add(DTROWSAVE("REMARKS"))
                ALPARAVAL.Add(0)  ' ISPLATE
                ALPARAVAL.Add(0)  ' ISPAPER
                ALPARAVAL.Add(DTROWSAVE("PAPERMATERIAL"))
                ALPARAVAL.Add(DTROWSAVE("PAPERMILL"))
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(Userid)
                ALPARAVAL.Add(YearId)

                OBJSM.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJSM.save()

                DTROWSAVE = DTSAVE.NewRow()

SKIPLINE:
            Next

            oBook.Close()

            Exit Sub

            '************************************ END OF CODE FOR NONINVITEM UPLOAD ****************************



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UPLOADSTORESTOCKMENU_Click(sender As Object, e As EventArgs) Handles UPLOADSTORESTOCKMENU.Click

        'ONE TIME DATA UPLOAD FOR SAFFRON FROM CBS
        Try
            If InputBox("Enter Master Password") <> "Infosys@123" Then Exit Sub
            'upload the files data
            ''Reading from Excel Woorkbook
            Dim cPart As Microsoft.Office.Interop.Excel.Range
            Dim oExcel As Microsoft.Office.Interop.Excel.Application = CreateObject("Excel.Application")
            Dim oBook As Microsoft.Office.Interop.Excel.Workbook = oExcel.Workbooks.Open("E:\" & InputBox("Enter File Name").ToString.Trim, , False)
            Dim oSheet As New Microsoft.Office.Interop.Excel.Worksheet
            oSheet = oBook.Worksheets("Sheet1")

            'GRID
            Dim ADDITEM As Boolean = True
            Dim TEMPITEMNAME As String = ""

            Dim DTSAVE As New System.Data.DataTable
            DTSAVE.Columns.Add("GODOWN")
            DTSAVE.Columns.Add("ITEMNAME")
            DTSAVE.Columns.Add("QTY")
            DTSAVE.Columns.Add("UNIT")
            DTSAVE.Columns.Add("WT")


            Dim ARR As New ArrayList
            Dim COLIND As Integer = 0
            Dim DTROWSAVE As System.Data.DataRow = DTSAVE.NewRow()


            Dim FROMROWNO As Integer = Val(InputBox("Enter Start Row No"))
            Dim TOROWNO As Integer = Val(InputBox("Enter End Row No"))

            For I As Integer = FROMROWNO To TOROWNO

                If IsDBNull(oSheet.Range("A" & I.ToString).Text) = False Then
                    DTROWSAVE("GODOWN") = oSheet.Range("A" & I.ToString).Text
                Else
                    DTROWSAVE("GODOWN") = ""
                End If

                If IsDBNull(oSheet.Range("B" & I.ToString).Text) = False Then
                    DTROWSAVE("ITEMNAME") = oSheet.Range("B" & I.ToString).Text
                Else
                    DTROWSAVE("ITEMNAME") = ""
                End If


                If IsDBNull(oSheet.Range("C" & I.ToString).Text) = False Then
                    DTROWSAVE("QTY") = Val(oSheet.Range("C" & I.ToString).Text)
                Else
                    DTROWSAVE("QTY") = 0
                End If


                If IsDBNull(oSheet.Range("D" & I.ToString).Text) = False Then
                    DTROWSAVE("UNIT") = oSheet.Range("D" & I.ToString).Text
                Else
                    DTROWSAVE("UNIT") = ""
                End If

                If IsDBNull(oSheet.Range("E" & I.ToString).Text) = False Then
                    DTROWSAVE("WT") = Val(oSheet.Range("E" & I.ToString).Text)
                Else
                    DTROWSAVE("WT") = 0
                End If



                If Val(DTROWSAVE("QTY")) <= 0 Then GoTo SKIPLINE


                Dim ALPARAVAL As New ArrayList
                'CHECK WHETHER ITEMNAME IS PRESENT OR NOT IF NOT PRESENT THEN ADD NEW
                Dim OBJCMN As New ClsCommon
                Dim DTTABLE As New DataTable



                'ADD IN STOCKMASTER
                ALPARAVAL.Clear()
                Dim OBJSM As New ClsStockMaster

                ALPARAVAL.Add(AccFrom.Date)
                ALPARAVAL.Add(I)
                ALPARAVAL.Add("")               'NAME
                ALPARAVAL.Add(DTROWSAVE("GODOWN"))         'GODOWN
                ALPARAVAL.Add("")               'SHELF
                ALPARAVAL.Add(DTROWSAVE("ITEMNAME"))
                ALPARAVAL.Add("")               'SIZE
                ALPARAVAL.Add(DTROWSAVE("WT"))
                ALPARAVAL.Add("")               'PPRNO
                ALPARAVAL.Add("")               'BATCHNO
                ALPARAVAL.Add(DTROWSAVE("UNIT"))
                ALPARAVAL.Add(DTROWSAVE("QTY"))
                ALPARAVAL.Add("Accepted")       'TYPE
                ALPARAVAL.Add(0)                 'OUTQTY

                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(Userid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(0)

                ALPARAVAL.Add(0)    'RATE
                ALPARAVAL.Add(0)    'AMT

                OBJSM.alParaval = ALPARAVAL
                DTTABLE = OBJSM.SAVE()

                DTROWSAVE = DTSAVE.NewRow()

SKIPLINE:
            Next

            oBook.Close()

            Exit Sub
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PendingForApprovalsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PendingForApprovalsToolStripMenuItem.Click
        Try
            Dim OBJITEM As New PendingForApproval
            OBJITEM.MdiParent = Me
            OBJITEM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
