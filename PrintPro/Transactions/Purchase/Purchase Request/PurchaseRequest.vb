Imports System.ComponentModel
Imports BL


Public Class PurchaseRequest
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE, GRIDDOUBLECLICK As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean
    Public TEMPREQNO As String
    Public TEMPMSG As Integer



    Private Sub cmdclear_Click(sender As Object, e As EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        TXTREQDONEBY.Focus()
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        TXTSRNO.ReadOnly = True
        TXTREQDONEBY.Text = ""
        DTDATE.Text = Now.Date
        getmax_REQNO()
        tstxtbillno.Clear()
        EP.Clear()
        LBLTOTALQTY.Text = 0.0
        LBLEXTRAQTY.Text = 0
        LBLFINALQTY.Text = 0
        GRIDJO.RowCount = 0
        GRIDPURCHASE.RowCount = 0


    End Sub
    Sub getmax_REQNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(REQ_NO),0) + 1 ", "PURCHASEREQUEST", "  AND REQ_cmpid=" & CmpId & " and REQ_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTSRNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub GRIDJO_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDJO.KeyDown
        'DONT ALLOW TO DELETE ITEMS FROM UPPER GRID, COZ THIS WILL CREATE ISSUE IN BELOW GRID... DONE BY GULKIT
        'Try
        '    If e.KeyCode = Keys.Delete And GRIDJO.RowCount > 0 Then
        '        If GRIDDOUBLECLICK = True Then
        '            MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
        '            Exit Sub
        '        End If
        '        GRIDJO.Rows.RemoveAt(GRIDJO.CurrentRow.Index)
        '        TOTAL()
        '        getsrno(GRIDJO)
        '    End If
        'Catch ex As Exception
        '    If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        'End Try
    End Sub

    Private Sub PurchaseRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE REQUEST'")

            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            Cursor.Current = Cursors.WaitCursor

            clear()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJCMN As New ClsCommon
                Dim OBJCLSINCENTIVE As New ClsPurchaseReq
                Dim dttable As New DataTable

                dttable = OBJCLSINCENTIVE.SELECTPURCHASEREQ(TEMPREQNO, CmpId, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTSRNO.Text = TEMPREQNO
                        TXTSRNO.ReadOnly = True
                        DTDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        TXTREQDONEBY.Text = dr("REQDONEBY")
                        LBLEXTRAQTY.Text = dr("TOTALEXTRAQTY")
                        LBLFINALQTY.Text = dr("TOTALFINALQTY")


                        GRIDJO.Rows.Add(dr("GRIDSRNO").ToString, dr("JOBDOCKETNO").ToString, dr("PARTYNAME").ToString, dr("MAINITEMNAME").ToString, dr("SUBITEMNAME").ToString, dr("PAPERNAME").ToString, dr("QTY").ToString, dr("DONE").ToString)
                        'If Convert.ToBoolean(dr("CLOSED")) = True Then
                        '    GRIDJO.Rows(GRIDJO.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                        '    lbllocked.Visible = True
                        '    PBlock.Visible = True
                        'End If

                    Next
                    'PURCHASE Grid
                    Dim OBJPRI As New ClsCommon
                    dttable = OBJPRI.search("ISNULL(NONINVITEMMASTER.NONINV_NAME, '') AS PURPAPERNAME, ISNULL(PURCHASEREQUEST_REQ.REQ_REQQTY, 0) AS REQQTY, ISNULL(PURCHASEREQUEST_REQ.REQ_STOCKQTY, 0) AS STOCKQTY, ISNULL(PURCHASEREQUEST_REQ.REQ_ORDERQTY, 0) AS ORDERQTY, ISNULL(PURCHASEREQUEST_REQ.REQ_TOTALQTY, 0) AS TOTALQTY,  ISNULL(PURCHASEREQUEST_REQ.REQ_EXTRAQTY, 0) AS EXTRAQTY, ISNULL(PURCHASEREQUEST_REQ.REQ_FINALQTY, 0) AS FINALQTY ", "", "PURCHASEREQUEST_REQ LEFT OUTER JOIN NONINVITEMMASTER ON PURCHASEREQUEST_REQ.REQ_YEARID = NONINVITEMMASTER.NONINV_YEARID AND PURCHASEREQUEST_REQ.REQ_PURPAPERNAMEID = NONINVITEMMASTER.NONINV_ID", " AND REQ_NO = " & TEMPREQNO & " AND REQ_CMPID = " & CmpId & " AND REQ_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        For Each dr As DataRow In dttable.Rows
                            GRIDPURCHASE.Rows.Add(dr("PURPAPERNAME").ToString, dr("REQQTY").ToString, dr("STOCKQTY").ToString, dr("ORDERQTY").ToString, dr("TOTALQTY").ToString, dr("EXTRAQTY").ToString, dr("FINALQTY").ToString)
                        Next
                    End If


                    GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1
                    TOTAL()
                    ' CMDSELECTSO.Enabled = False
                    'CMDSELECTSTOCK.Enabled = False
                    'CMBWASTAGETYPE.Focus()
                Else
                    EDIT = False
                    clear()
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(TXTSRNO.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(DTDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(TXTREQDONEBY.Text.Trim)
            alParaval.Add(LBLEXTRAQTY.Text.Trim)
            alParaval.Add(LBLFINALQTY.Text.Trim)


            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim GRIDSRNO As String = ""
            Dim JOBDOCKETNO As String = ""
            Dim PARTYNAME As String = ""
            Dim MAINITEMNAME As String = ""
            Dim BOMITEMNAME As String = ""
            Dim PAPERNAME As String = ""
            Dim QTY As String = ""
            Dim DONE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDJO.Rows
                If row.Cells(GGRIDSRNO.Index).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = row.Cells(GGRIDSRNO.Index).Value
                        JOBDOCKETNO = Val(row.Cells(GJOBDOCKETNO.Index).Value)
                        PARTYNAME = row.Cells(GPARTYNAME.Index).Value.ToString
                        MAINITEMNAME = row.Cells(GMAINITEM.Index).Value.ToString
                        BOMITEMNAME = row.Cells(GBOMITEM.Index).Value.ToString
                        PAPERNAME = row.Cells(GPAPERNAME.Index).Value.ToString
                        QTY = Val(row.Cells(GQTYFULLSHEETS.Index).Value)
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = 1
                        Else
                            DONE = 0
                        End If

                    Else
                        GRIDSRNO = GRIDSRNO & "|" & row.Cells(GGRIDSRNO.Index).Value
                        JOBDOCKETNO = JOBDOCKETNO & "|" & Val(row.Cells(GJOBDOCKETNO.Index).Value)
                        PARTYNAME = PARTYNAME & "|" & row.Cells(GPARTYNAME.Index).Value.ToString
                        MAINITEMNAME = MAINITEMNAME & "|" & row.Cells(GMAINITEM.Index).Value.ToString
                        BOMITEMNAME = BOMITEMNAME & "|" & row.Cells(GBOMITEM.Index).Value.ToString
                        PAPERNAME = PAPERNAME & "|" & row.Cells(GPAPERNAME.Index).Value.ToString
                        QTY = QTY & "|" & Val(row.Cells(GQTYFULLSHEETS.Index).Value)
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = DONE & "|" & "1"
                        Else
                            DONE = DONE & "|" & "0"
                        End If

                    End If
                End If
            Next


            alParaval.Add(GRIDSRNO)
            alParaval.Add(JOBDOCKETNO)
            alParaval.Add(PARTYNAME)
            alParaval.Add(MAINITEMNAME)
            alParaval.Add(BOMITEMNAME)
            alParaval.Add(PAPERNAME)
            alParaval.Add(QTY)
            alParaval.Add(DONE)


            'For Issue Grid
            Dim ISSUEPAPERNAME As String = ""
            Dim REQQTY As String = ""
            Dim STOCKQTY As String = ""
            Dim ORDERQTY As String = ""
            Dim TOTALQTY As String = ""
            Dim EXTRAQTY As String = ""
            Dim FINALQTY As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDPURCHASE.Rows
                If row.Cells(GISSUEPAPERNAME.Index).Value <> Nothing Then
                    If ISSUEPAPERNAME = "" Then
                        ISSUEPAPERNAME = row.Cells(GISSUEPAPERNAME.Index).Value.ToString
                        REQQTY = Val(row.Cells(GREQQTY.Index).Value)
                        STOCKQTY = Val(row.Cells(GSTOCKQTY.Index).Value)
                        ORDERQTY = Val(row.Cells(GORDERQTY.Index).Value)
                        TOTALQTY = Val(row.Cells(GTOTALQTY.Index).Value)
                        EXTRAQTY = Val(row.Cells(GEXTRAQTY.Index).Value)
                        FINALQTY = Val(row.Cells(GFINALQTY.Index).Value)

                    Else
                        ISSUEPAPERNAME = ISSUEPAPERNAME & "|" & row.Cells(GISSUEPAPERNAME.Index).Value.ToString
                        REQQTY = REQQTY & "|" & Val(row.Cells(GREQQTY.Index).Value)
                        STOCKQTY = STOCKQTY & "|" & Val(row.Cells(GSTOCKQTY.Index).Value)
                        ORDERQTY = ORDERQTY & "|" & Val(row.Cells(GORDERQTY.Index).Value)
                        TOTALQTY = TOTALQTY & "|" & Val(row.Cells(GTOTALQTY.Index).Value)
                        EXTRAQTY = EXTRAQTY & "|" & Val(row.Cells(GEXTRAQTY.Index).Value)
                        FINALQTY = FINALQTY & "|" & Val(row.Cells(GFINALQTY.Index).Value)


                    End If
                End If


            Next

            alParaval.Add(ISSUEPAPERNAME)
            alParaval.Add(REQQTY)
            alParaval.Add(STOCKQTY)
            alParaval.Add(ORDERQTY)
            alParaval.Add(TOTALQTY)
            alParaval.Add(EXTRAQTY)
            alParaval.Add(FINALQTY)


            Dim OBJPO As New ClsPurchaseReq
            OBJPO.alParaval = alParaval


            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DT As DataTable = OBJPO.SAVE()
                TEMPREQNO = DT.Rows(0).Item(0)
                MsgBox("Details Added")


                If Val(LBLFINALQTY.Text) <> 0 Then
                    Dim OBJPOF As New PurchaseOrder
                    OBJPOF.MdiParent = MDIMain
                    OBJPOF.TEMPPOF = TEMPREQNO
                    OBJPOF.Show()
                End If


            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPREQNO)
                IntResult = OBJPO.UPDATE()
                EDIT = False
                MsgBox("Details Updated")
            End If
            clear()
            TXTREQDONEBY.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub



    Private Function ERRORVALID() As Boolean

        Dim bln As Boolean = True
        If TXTREQDONEBY.Text.Trim.Length = 0 Then
            EP.SetError(TXTREQDONEBY, " Please Fill Req Done By ")
            bln = False
        End If

        If DTDATE.Text = "__/__/____" Then
            EP.SetError(DTDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(DTDATE.Text) Then
                EP.SetError(DTDATE, "Date not in Accounting Year")
                bln = False
            End If
        End If


        'If GRIDPRODISSUE.RowCount = 0 Then
        '    EP.SetError(GRIDPRODISSUE, " Please Enter Proper Details ")
        '    bln = False
        'End If

        'WE WILL HAVE TO SKIP THIS COZ WE WILL ISSSUE THE ENTRIES AND SAVE IT.... THAT TIME OURWT WILL BE 0
        'For Each row As DataGridViewRow In GRIDPRODISSUE.Rows
        '    If Val(row.Cells(GOURQTY.Index).Value) = 0 Then
        '        EP.SetError(LBLTOTALOURQTY, "Our Qty Cannot be 0")
        '        bln = False
        '    End If
        'Next

        'WE WILL HAVE TO SKIP THIS COZ WE WILL ISSSUE THE ENTRIES AND SAVE IT.... THAT TIME EVERYTHING WILL BE SHOWN IN DIFF
        'If Val(LBLTOTALDIFF.Text) <> Val(LBLTOTALWT.Text) Then
        '    EP.SetError(LBLTOTALWT, "Diff And Total Wastage Value Does Not Match ")
        '    bln = False
        'End If


        Return bln
    End Function

    Private Sub toolprevious_Click(sender As Object, e As EventArgs) Handles toolprevious.Click
        Try
            GRIDJO.RowCount = 0
LINE1:
            TEMPREQNO = Val(TXTSRNO.Text) - 1
            If TEMPREQNO > 0 Then
                EDIT = True
                PurchaseRequest_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If

            If GRIDJO.RowCount = 0 And TEMPREQNO > 1 Then
                TXTSRNO.Text = TEMPREQNO
                GoTo LINE1
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(sender As Object, e As EventArgs) Handles toolnext.Click
        Try
            GRIDJO.RowCount = 0
LINE1:
            TEMPREQNO = Val(TXTSRNO.Text) + 1
            getmax_REQNO()
            Dim MAXNO As Integer = TXTSRNO.Text.Trim
            clear()
            If Val(TXTSRNO.Text) - 1 >= TEMPREQNO Then
                EDIT = True
                PurchaseRequest_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDJO.RowCount = 0 And TEMPREQNO < MAXNO Then
                TXTSRNO.Text = TEMPREQNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        Try
            cmdok_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(sender As Object, e As EventArgs) Handles cmddelete.Click
        Dim IntResult As Integer
        Try

            If EDIT = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                TEMPMSG = MsgBox("Delete Purchase Request?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTSRNO.Text.Trim)
                    alParaval.Add(YearId)

                    Dim ClsINCTAG As New ClsPurchaseReq()
                    ClsINCTAG.alParaval = alParaval
                    IntResult = ClsINCTAG.Delete()
                    MsgBox("Purchase Request Deleted")
                    clear()
                    EDIT = False
                End If
            Else
                MsgBox("Delete Is only In Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            LBLTOTALQTY.Text = 0.0
            LBLEXTRAQTY.Text = 0.0
            LBLFINALQTY.Text = 0.0

            'GRIDPURCHASE.RowCount = 0
            Dim DONE As Boolean = False
            Dim TEMPSTOCK As Integer
            Dim TEMPPO As Integer
            Dim OBJCMN As New ClsCommon

            For Each REQROW As DataGridViewRow In GRIDPURCHASE.Rows
                REQROW.Cells(GREQQTY.Index).Value = 0
            Next

            For Each ROW As DataGridViewRow In GRIDJO.Rows
                LBLTOTALQTY.Text = Val(LBLTOTALQTY.Text) + Val(ROW.Cells(GQTYFULLSHEETS.Index).EditedFormattedValue)

                DONE = False

                'GET STOCK
                TEMPSTOCK = 0
                Dim DTSTOCK As DataTable = OBJCMN.search(" ITEMNAME,ISNULL(SUM( QTY),0) AS STOCKQTY", "", " STOCKVIEW ", " AND YEARID = " & YearId & " AND ITEMNAME='" & (ROW.Cells(GPAPERNAME.Index).Value & "' GROUP BY ITEMNAME"))
                If DTSTOCK.Rows.Count > 0 Then TEMPSTOCK = Val(DTSTOCK.Rows(0).Item("STOCKQTY"))

                'GET PENING PURCHASE ORDER
                TEMPPO = 0
                Dim DTPO As DataTable = OBJCMN.search("ISNULL(SUM(ALLPURCHASEORDER_DESC.PO_QTY- ALLPURCHASEORDER_DESC.PO_OUTQTY),0) AS ORDERQTY, NONINVITEMMASTER.NONINV_NAME", "", " ALLPURCHASEORDER_DESC LEFT OUTER JOIN NONINVITEMMASTER ON ALLPURCHASEORDER_DESC.PO_ITEMID = NONINVITEMMASTER.NONINV_ID", " AND ALLPURCHASEORDER_DESC.PO_YEARID = " & YearId & " AND NONINVITEMMASTER.NONINV_NAME='" & (ROW.Cells(GPAPERNAME.Index).Value) & "' GROUP BY NONINVITEMMASTER.NONINV_NAME HAVING ISNULL(SUM(ALLPURCHASEORDER_DESC.PO_QTY- ALLPURCHASEORDER_DESC.PO_OUTQTY),0) > 0")
                If DTPO.Rows.Count > 0 Then TEMPPO = Val(DTPO.Rows(0).Item("ORDERQTY"))

                If GRIDPURCHASE.RowCount = 0 Then
                    GRIDPURCHASE.Rows.Add(ROW.Cells(GPAPERNAME.Index).Value, Format(Val(ROW.Cells(GQTYFULLSHEETS.Index).EditedFormattedValue), "0"), Format(Val(TEMPSTOCK), "0"), Format(Val(TEMPPO), "0"), Format(Val(ROW.Cells(GQTYFULLSHEETS.Index).EditedFormattedValue) - Val(TEMPPO) - Val(TEMPSTOCK), "0"), 0, Format(Val(ROW.Cells(GQTYFULLSHEETS.Index).EditedFormattedValue) - Val(TEMPPO) - Val(TEMPSTOCK), "0"))
                Else
                    For Each REQROW As DataGridViewRow In GRIDPURCHASE.Rows
                        If REQROW.Cells(GISSUEPAPERNAME.Index).Value = ROW.Cells(GPAPERNAME.Index).Value Then
                            REQROW.Cells(GREQQTY.Index).Value = Format(Val(REQROW.Cells(GREQQTY.Index).Value) + Val(ROW.Cells(GQTYFULLSHEETS.Index).EditedFormattedValue), "0")
                            DONE = True
                        End If
                    Next
                    If DONE = False Then GRIDPURCHASE.Rows.Add(ROW.Cells(GPAPERNAME.Index).Value, Format(Val(ROW.Cells(GQTYFULLSHEETS.Index).EditedFormattedValue), "0"), TEMPSTOCK, TEMPPO, Format(Val(ROW.Cells(GQTYFULLSHEETS.Index).EditedFormattedValue) - Val(TEMPPO) - Val(TEMPSTOCK), "0"), 0, Format(Val(ROW.Cells(GQTYFULLSHEETS.Index).EditedFormattedValue) - Val(TEMPPO) - Val(TEMPSTOCK), "0"))
                    'If DONE = False Then GRIDPURCHASE.Rows.Add(ROW.Cells(GPAPERNAME.Index).Value, Format(Val(ROW.Cells(GQTYFULLSHEETS.Index).EditedFormattedValue), "0.00"), Format(Val(DTSTOCK.Rows(0).Item("STOCKQTY")), "0.00"), Format(Val(DTPO.Rows(0).Item("ORDERQTY")), "0.00"), Format(Val(ROW.Cells(GQTYFULLSHEETS.Index).EditedFormattedValue) - Val(DTSTOCK.Rows(0).Item("STOCKQTY")) - Val(DTPO.Rows(0).Item("ORDERQTY")), "0.00"), 0, Format(Val(ROW.Cells(GQTYFULLSHEETS.Index).EditedFormattedValue) - Val(TEMPPO) - Val(TEMPSTOCK), "0.00"))
                End If

            Next

            For Each REQROW As DataGridViewRow In GRIDPURCHASE.Rows
                REQROW.Cells(GTOTALQTY.Index).Value = Format(Val(REQROW.Cells(GREQQTY.Index).EditedFormattedValue) - Val(REQROW.Cells(GSTOCKQTY.Index).EditedFormattedValue) - Val(REQROW.Cells(GORDERQTY.Index).EditedFormattedValue), "0.00")
                If REQROW.Cells(GTOTALQTY.Index).Value > 0 Or REQROW.Cells(GEXTRAQTY.Index).Value > 0 Then
                    REQROW.Cells(GFINALQTY.Index).Value = Format(Val(REQROW.Cells(GTOTALQTY.Index).EditedFormattedValue) + Val(REQROW.Cells(GEXTRAQTY.Index).EditedFormattedValue), "0")
                Else
                    REQROW.Cells(GFINALQTY.Index).Value = 0
                End If
                LBLEXTRAQTY.Text = Val(LBLEXTRAQTY.Text) + Val(REQROW.Cells(GEXTRAQTY.Index).EditedFormattedValue)
                LBLFINALQTY.Text = Val(LBLFINALQTY.Text) + Val(REQROW.Cells(GFINALQTY.Index).EditedFormattedValue)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(sender As Object, e As EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim objgrndetails As New PurchaseRequestDetails
            objgrndetails.MdiParent = MDIMain
            objgrndetails.Show()
            objgrndetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub GETSRNO(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTSO_Click(sender As Object, e As EventArgs) Handles CMDSELECTSO.Click
        Try

            Cursor.Current = Cursors.WaitCursor
            Dim DTTABLE As DataTable
            Dim OBJSELECTJD As New SelectJobDocket
            OBJSELECTJD.FRMSTRING = "PURCHASEREQUEST"
            OBJSELECTJD.ShowDialog()

            DTTABLE = OBJSELECTJD.DT


            Dim i As Integer = 0
            If DTTABLE.Rows.Count > 0 Then

                Dim TEMPJOBNO As String = ""

                ''  GETTING DISTINCT JOBDOCKET NO IN TEXTBOX
                Dim DV As DataView = DTTABLE.DefaultView
                Dim NEWDT As DataTable = DV.ToTable(True, "JOBDOCKETNO")
                For Each DTR As DataRow In NEWDT.Rows
                    If TEMPJOBNO.Trim = "" Then
                        TEMPJOBNO = DTR("JOBDOCKETNO").ToString
                    Else
                        TEMPJOBNO = TEMPJOBNO & "," & DTR("JOBDOCKETNO").ToString
                    End If
                Next

                Dim OBJCMN As New ClsCommon()
                Dim DT As DataTable = OBJCMN.search(" SUM(STOCKMASTER.SM_QTY) AS STOCKQTY, JOBBATCHMASTER.job_no AS JOBDOCKETNO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(MAINITEMMASTER.item_code, '') AS MAINITEMNAME, ISNULL(PAPERNONINVITEMMASTER.NONINV_NAME, '') AS PAPERNAME, ISNULL(JOBBATCHMASTER.JOB_COLORSHEET, 0) AS QTY, JOBBATCHMASTER.job_date AS JOBDOCKETDATE, ISNULL(JOBBATCHMASTER.job_pono, '') AS PONO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(PURCHASEMASTER.bill_totalqty, 0) AS ORDERQTY , ISNULL(SUBITEMMASTER.item_code, '') AS SUBITEMNAME ", "", "  PURCHASEMASTER INNER JOIN PURCHASEMASTER_DESC ON PURCHASEMASTER.bill_no = PURCHASEMASTER_DESC.bill_no AND PURCHASEMASTER.bill_yearid = PURCHASEMASTER_DESC.bill_yearid RIGHT OUTER JOIN ITEMMASTER AS MAINITEMMASTER INNER JOIN JOBBATCHMASTER INNER JOIN LEDGERS ON JOBBATCHMASTER.JOB_LEDGERID = LEDGERS.Acc_id ON MAINITEMMASTER.item_id = JOBBATCHMASTER.JOB_MAINITEMID LEFT OUTER JOIN ITEMMASTER AS SUBITEMMASTER ON JOBBATCHMASTER.JOB_SUBITEMID = SUBITEMMASTER.item_id ON PURCHASEMASTER_DESC.bill_NONINVITEMID = JOBBATCHMASTER.JOB_NONINVITEMID LEFT OUTER JOIN STOCKMASTER RIGHT OUTER JOIN NONINVITEMMASTER AS PAPERNONINVITEMMASTER ON STOCKMASTER.SM_YEARID = PAPERNONINVITEMMASTER.NONINV_YEARID AND STOCKMASTER.SM_ITEMID = PAPERNONINVITEMMASTER.NONINV_ID ON  JOBBATCHMASTER.JOB_NONINVITEMID = PAPERNONINVITEMMASTER.NONINV_ID LEFT OUTER JOIN ITEMMASTER ON JOBBATCHMASTER.job_itemid = ITEMMASTER.item_id ", " AND  JOBBATCHMASTER.JOB_YEARID =" & YearId & " AND  JOBBATCHMASTER.JOB_NO IN (" & TEMPJOBNO & ")  GROUP BY JOBBATCHMASTER.job_no, ISNULL(LEDGERS.Acc_cmpname, ''), ISNULL(MAINITEMMASTER.item_code, ''), ISNULL(PAPERNONINVITEMMASTER.NONINV_NAME, ''),  ISNULL(JOBBATCHMASTER.job_COLORSHEET, 0), JOBBATCHMASTER.job_date, ISNULL(JOBBATCHMASTER.job_pono, ''), ISNULL(ITEMMASTER.item_name, ''),  ISNULL(PURCHASEMASTER.bill_totalqty, 0) , ISNULL(SUBITEMMASTER.item_code, '')")
                If DT.Rows.Count > 0 Then
                    For Each dr As DataRow In DT.Rows
                        GRIDJO.Rows.Add(0, dr("JOBDOCKETNO"), dr("NAME"), dr("MAINITEMNAME"), dr("SUBITEMNAME"), dr("PAPERNAME"), (dr("QTY")))
                    Next
                    GETSRNO(GRIDJO)
                    TOTAL()
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub PurchaseRequest_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()

            ElseIf e.Alt = True And e.KeyCode = Keys.P Then
                ' Call PrintToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolprevious_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F5 Then
                GRIDJO.Focus()
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for Delete
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(sender As Object, e As CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDJO.RowCount = 0
                TEMPREQNO = Val(tstxtbillno.Text)
                If TEMPREQNO > 0 Then
                    EDIT = True
                    PurchaseRequest_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDPURCHASE_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GRIDPURCHASE.CellValidating
        Dim colNum As Integer = GRIDPURCHASE.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
        Select Case colNum

            Case GEXTRAQTY.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If GRIDPURCHASE.CurrentCell.Value = Nothing Then GRIDPURCHASE.CurrentCell.Value = "0.00"
                    GRIDPURCHASE.CurrentCell.Value = Convert.ToDecimal(GRIDPURCHASE.Item(colNum, e.RowIndex).Value)
                    TOTAL()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                    'Exit Sub
                End If

        End Select
    End Sub
End Class

