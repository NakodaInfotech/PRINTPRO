Imports BL
Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel
Public Class Delivery
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE, GRIDSHIFTDOUBLECLICK As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim gridUPLOADDoubleClick As Boolean
    Dim temprow As Integer
    Dim TEMPSHIFTROW, TEMPMSG As Integer
    Public edit As Boolean
    Public TEMPCHALLANNO As Integer
    Dim EXPIRY As Boolean = False
    Private Sub cmdclear_Click(sender As Object, e As EventArgs) Handles cmdclear.Click
        CLEAR()
        edit = False
        CMBNAME.Focus()
    End Sub

    Private Sub Delivery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'PRODUCTION'")

            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            Cursor.Current = Cursors.WaitCursor
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' AND ACC_TYPE = 'ACCOUNTS'")
            CLEAR()
            CMBNAME.Enabled = True
            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJCMN As New ClsCommon
                Dim OBJCLSINCENTIVE As New ClsDelivery
                Dim dttable As New DataTable

                dttable = OBJCLSINCENTIVE.SELECTDELIVERY(TEMPCHALLANNO, CmpId, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTCHALLANNO.Text = TEMPCHALLANNO
                        TXTCHALLANNO.ReadOnly = True
                        DTDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        CMBNAME.Text = Convert.ToString(dr("NAME"))
                        TXTSHIPTO.Text = dr("SHIPTO")
                        LBLTOTALEACH.Text = dr("TOTALEACH")
                        LBLTOTALNOOFBOXES.Text = dr("TOTALNOOFBOXES")
                        LBLTOTALQTY.Text = dr("TOTALQTY")
                        TXTREMARKS.Text = dr("REMARKS")
                        LBLTOTAL.Text = dr("TOTAL")
                        TXTITEMCODE.Text = Convert.ToString(dr("MAINITEMCODE"))
                        TXTITEMNAME.Text = Convert.ToString(dr("MAINITEMNAME"))
                        TXTREADYQTY.Text = Convert.ToString(dr("READYQTY"))
                        TXTORDERQTY.Text = Convert.ToString(dr("ORDERQTY"))
                        TXTORDERNO.Text = Convert.ToString(dr("ORDERNO"))
                        TXTORDERSRNO.Text = Convert.ToString(dr("ORDERSRNO"))
                        TXTORDERTYPE.Text = Convert.ToString(dr("ORDERTYPE"))
                        TXTDELIVERDQTY.Text = Convert.ToString(dr("DELQTY"))
                        TXTBALREADYQTY.Text = Convert.ToString(dr("BALREADYQTY"))
                        TXTDELIVERYQTY.Text = Convert.ToString(dr("DELIVERYQTY"))



                        gridorders.Rows.Add(Val(dr("SRNO")), dr("ITEMCODE").ToString, dr("ITEMNAME").ToString, dr("PONO").ToString, Format(Val(dr("QTY")), "0.00"), dr("UNIT").ToString, Val(dr("NOOFBOXES")), Val(dr("EACH")), Val(dr("GRIDTOTAL")), Val(dr("JOBDOCKETNO")), Val(dr("ORDERNO")), Val(dr("ORDERSRNO")), dr("ORDERTYPE").ToString)
                    Next

                    gridorders.FirstDisplayedScrollingRowIndex = gridorders.RowCount - 1
                    TOTAL()
                    ' CMDSELECTORDER.Enabled = False
                    CMBNAME.Focus()
                Else
                    edit = False
                    CLEAR()
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        If ISLOCKYEAR = True Then
            MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Try

            Cursor.Current = Cursors.WaitCursor

            Dim IntResult As Integer
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList
            alParaval.Add(Val(TXTCHALLANNO.Text.Trim))
            alParaval.Add(Format(Convert.ToDateTime(DTDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(TXTSHIPTO.Text.Trim)
            alParaval.Add(LBLTOTALEACH.Text.Trim)
            alParaval.Add(LBLTOTALNOOFBOXES.Text.Trim)
            alParaval.Add(LBLTOTALQTY.Text.Trim)
            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(LBLTOTAL.Text.Trim)
            alParaval.Add(TXTITEMCODE.Text.Trim)
            alParaval.Add(TXTITEMNAME.Text.Trim)
            alParaval.Add(TXTORDERQTY.Text.Trim)
            alParaval.Add(TXTREADYQTY.Text.Trim)
            alParaval.Add(TXTORDERNO.Text.Trim)
            alParaval.Add(TXTORDERSRNO.Text.Trim)
            alParaval.Add(TXTORDERTYPE.Text.Trim)

            alParaval.Add(TXTDELIVERYQTY.Text.Trim)
            alParaval.Add(TXTDELIVERDQTY.Text.Trim)
            alParaval.Add(TXTBALREADYQTY.Text.Trim)


            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            'ADDING GRID
            Dim SRNO As String = ""
            Dim ITEMCODE As String = ""
            Dim ITEMNAME As String = ""
            Dim PONO As String = ""
            Dim QTY As String = ""
            Dim UNIT As String = ""
            Dim NOOFBOXES As String = ""
            Dim EACHBOX As String = ""
            Dim GRIDTOTAL As String = ""
            Dim JOBDOCKETNO As String = ""
            Dim ORDERNO As String = ""
            Dim ORDERSRNO As String = ""
            Dim ORDERTYPE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridorders.Rows
                If row.Cells(0).Value <> Nothing Then
                    If SRNO = "" Then
                        SRNO = Val(row.Cells(GSRNO.Index).Value)
                        ITEMCODE = row.Cells(Gitemcode.Index).Value.ToString
                        ITEMNAME = row.Cells(Gitemname.Index).Value.ToString
                        PONO = row.Cells(GPONO.Index).Value.ToString
                        QTY = Val(row.Cells(GQty.Index).Value)
                        UNIT = row.Cells(Gunit.Index).Value
                        NOOFBOXES = Val(row.Cells(GNOOFBOXES.Index).Value)
                        EACHBOX = Val(row.Cells(GEACH.Index).Value)
                        GRIDTOTAL = Val(row.Cells(GGRIDTOTAL.Index).Value)
                        JOBDOCKETNO = Val(row.Cells(GJOBDOCKETNO.Index).Value)
                        ORDERNO = Val(row.Cells(GORDERNO.Index).Value)
                        ORDERSRNO = Val(row.Cells(GORDERSRNO.Index).Value)
                        ORDERTYPE = row.Cells(GORDERTYPE.Index).Value.ToString


                    Else
                        SRNO = SRNO & "|" & Val(row.Cells(GSRNO.Index).Value)
                        ITEMCODE = ITEMCODE & "|" & row.Cells(Gitemcode.Index).Value.ToString
                        ITEMNAME = ITEMNAME & "|" & row.Cells(Gitemname.Index).Value.ToString
                        PONO = PONO & "|" & row.Cells(GPONO.Index).Value.ToString
                        QTY = QTY & "|" & Val(row.Cells(GQty.Index).Value)
                        UNIT = UNIT & "|" & row.Cells(Gunit.Index).Value
                        NOOFBOXES = NOOFBOXES & "|" & Val(row.Cells(GNOOFBOXES.Index).Value)
                        EACHBOX = EACHBOX & "|" & Val(row.Cells(GEACH.Index).Value)
                        GRIDTOTAL = GRIDTOTAL & "|" & Val(row.Cells(GGRIDTOTAL.Index).Value)
                        JOBDOCKETNO = JOBDOCKETNO & "|" & Val(row.Cells(GJOBDOCKETNO.Index).Value)
                        ORDERNO = ORDERNO & "|" & Val(row.Cells(GORDERNO.Index).Value)
                        ORDERSRNO = ORDERSRNO & "|" & Val(row.Cells(GORDERSRNO.Index).Value)
                        ORDERTYPE = ORDERTYPE & "|" & row.Cells(GORDERTYPE.Index).Value.ToString

                    End If
                End If
            Next
            alParaval.Add(SRNO)
            alParaval.Add(ITEMCODE)
            alParaval.Add(ITEMNAME)
            alParaval.Add(PONO)
            alParaval.Add(QTY)
            alParaval.Add(UNIT)
            alParaval.Add(NOOFBOXES)
            alParaval.Add(EACHBOX)
            alParaval.Add(GRIDTOTAL)
            alParaval.Add(JOBDOCKETNO)
            alParaval.Add(ORDERNO)
            alParaval.Add(ORDERSRNO)
            alParaval.Add(ORDERTYPE)


            Dim objclsPurord As New ClsDelivery()
            objclsPurord.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = objclsPurord.SAVE()
                MessageBox.Show("Details Added")
                TEMPCHALLANNO = DT.Rows(0).Item(0)
                PRINTREPORT(DT.Rows(0).Item(0))

            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPCHALLANNO)
                IntResult = objclsPurord.UPDATE()
                MessageBox.Show("Details Updated")
                PRINTREPORT(TEMPCHALLANNO)
                edit = False
            End If
            CMBNAME.Focus()
            CLEAR()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Try
            gridorders.RowCount = 0
LINE1:
            TEMPCHALLANNO = Val(TXTCHALLANNO.Text) - 1
            If TEMPCHALLANNO > 0 Then
                edit = True
                Delivery_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If

            If gridorders.RowCount = 0 And TEMPCHALLANNO > 1 Then
                TXTCHALLANNO.Text = TEMPCHALLANNO
                GoTo LINE1
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Try
            gridorders.RowCount = 0

LINE1:
            TEMPCHALLANNO = Val(TXTCHALLANNO.Text) + 1
            GETMAX_NO()
            Dim MAXNO As Integer = TXTCHALLANNO.Text.Trim
            CLEAR()
            If Val(TXTCHALLANNO.Text) - 1 >= TEMPCHALLANNO Then
                edit = True
                Delivery_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If
            If gridorders.RowCount = 0 And TEMPCHALLANNO < MAXNO Then
                TXTCHALLANNO.Text = TEMPCHALLANNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub



    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If DTDATE.Text = "__/__/____" Then
            EP.SetError(DTDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(DTDATE.Text) Then
                EP.SetError(DTDATE, "Date Not In Accounting Year")
                bln = False
            End If
        End If

        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, " Please Fill Party Name ")
            bln = False
        End If

        If gridorders.RowCount = 0 Then
            EP.SetError(gridorders, " Please Enter Proper Details ")
            bln = False
        End If



        For Each ROW As DataGridViewRow In gridorders.Rows
            If ROW.Cells(GGRIDTOTAL.Index).Value = "0" Then
                EP.SetError(CMBNAME, "The Value Of Grid Total Qty Sholud be Greater 0")
                bln = False
            End If
        Next

        'If TXTBOX.Text.Trim = "" And TXTEACH.Text.Trim = "" Then
        '    EP.SetError(TXTEACH, "Please Enter the Details Properly")
        '    bln = False
        'End If
        'If TXTINDENTNO.Text.Trim = "" Then
        '    EP.SetError(TXTINDENTNO, "Please Enter the Indent No")
        '    bln = False
        'End If
        'If TXTJOBDOCKETNO.Text.Trim = "" Then
        '    EP.SetError(TXTJOBDOCKETNO, "Please Enter the Job Docket No")
        '    bln = False
        'End If

        Return bln
    End Function

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub cmddelete_Click(sender As Object, e As EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                'If lbllocked.Visible = True Then
                '    MsgBox("Unable To Delete", MsgBoxStyle.Critical)
                '    Exit Sub
                'End If

                If MsgBox("Wish To Delete Challan?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If MsgBox("Are you Sure?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        Dim alParaval As New ArrayList
                        alParaval.Add(TXTCHALLANNO.Text.Trim)
                        alParaval.Add(YearId)

                        Dim clspo As New ClsDelivery()
                        clspo.alParaval = alParaval
                        Dim IntResult As Integer = clspo.Delete()
                        MsgBox("Challan Deleted")
                        CLEAR()
                        edit = False
                    End If
                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub CLEAR()
        CMBNAME.Text = ""
        TXTCHALLANNO.ReadOnly = True
        DTDATE.Text = Now.Date
        LBLTOTALQTY.Text = 0
        LBLTOTALNOOFBOXES.Text = 0
        LBLTOTALEACH.Text = 0
        LBLTOTAL.Text = 0
        TXTSHIPTO.Clear()
        TXTREMARKS.Clear()
        GETMAX_NO()
        gridorders.RowCount = 0
        tstxtbillno.Clear()
        EP.Clear()
        TXTITEMCODE.Clear()
        TXTITEMNAME.Clear()
        TXTORDERQTY.Clear()
        TXTREADYQTY.Clear()

        TXTORDERNO.Clear()
        TXTORDERSRNO.Clear()
        TXTORDERTYPE.Clear()
        TXTDELIVERYQTY.Clear()
        TXTBALREADYQTY.Clear()
        TXTDELIVERDQTY.Clear()

    End Sub


    Private Sub Print_Click(sender As Object, e As EventArgs) Handles Print.Click
        Try
            If edit = True Then PRINTREPORT(TEMPCHALLANNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal JOBNO As Integer)
        Try
            TEMPMSG = MsgBox("Wish to Print Delivery?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim OBJJOB As New ChallanDesign
                OBJJOB.MdiParent = MDIMain
                OBJJOB.FRMSTRING = "DELIVERY"
                OBJJOB.WHERECLAUSE = "{DELIVERY.DEL_CHALLANNO}=" & Val(TEMPCHALLANNO) & " AND {DELIVERY.DEL_YEARID} =" & YearId
                OBJJOB.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETMAX_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(DEL_CHALLANNO),0) + 1 ", "DELIVERY", "  AND DEL_cmpid=" & CmpId & " and DEL_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTCHALLANNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub



    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In gridorders.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub Delivery_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()

            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
                'ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1) Then       'for CLEAR
                '    TabControl1.SelectedIndex = (0)
                'ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2) Then       'for CLEAR
                '    TabControl1.SelectedIndex = (1)
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call ToolStripButton6_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call ToolStripButton7_Click(sender, e)
            ElseIf e.KeyCode = Windows.Forms.Keys.F1 And e.Alt = True Then
                Call ToolStripButton1_Click(sender, e)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub cmbname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub cmbname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJGRN As New DeliveryDetails
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTORDER_Click(sender As Object, e As EventArgs) Handles CMDSELECTORDER.Click
        Try
            EP.Clear()
            If CMBNAME.Text.Trim = "" Then
                MsgBox("Please Fill Party Name", MsgBoxStyle.Critical)
                CMBNAME.Focus()
                Exit Sub
            End If

            Dim OBJSO As New SelectOrder
            OBJSO.FRMSTRING = "DILEVERY"
            OBJSO.PARTYNAME = CMBNAME.Text.Trim
            OBJSO.ShowDialog()
            Dim DT As DataTable = OBJSO.DT
            If DT.Rows.Count > 0 Then

                'FETCH DATA FROM BATCHMASTE WITH RESPECT TO SELECTED SONO
                '  TXTQTY.Text = DT.Rows(0).Item("QUANTITY")
                TXTITEMNAME.Text = DT.Rows(0).Item("ITEMNAME")
                TXTITEMCODE.Text = DT.Rows(0).Item("ITEMCODE")
                TXTORDERNO.Text = Val(DT.Rows(0).Item("ORDERNO"))
                TXTORDERSRNO.Text = DT.Rows(0).Item("ORDERSRNO")
                TXTORDERTYPE.Text = DT.Rows(0).Item("ORDERTYPE")
                TXTORDERQTY.Text = DT.Rows(0).Item("QUANTITY")
                TXTDELIVERDQTY.Text = DT.Rows(0).Item("DELQTY")



                Dim MIN As Integer = 0

                Dim OBJCMN As New ClsCommon
                Dim DTSO As DataTable = OBJCMN.search(" ISNULL(COALESCE(SUBITEMMATSER.item_code, ITEMMASTER.item_code),'')  AS ITEMCODE, ISNULL(COALESCE(SUBITEMMATSER.item_name, ITEMMASTER.item_name),'')  AS ITEMNAME, ISNULL(ALLORDERMASTER.ORDER_PONO, '') AS PONO, ISNULL(JOBBATCHMASTER.JOB_ASSEMBLYQTY -JOBBATCHMASTER.JOB_DELOUTQTY, 0) AS QUANTITY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(JOBBATCHMASTER.job_orderno, 0) AS ORDERNO, ISNULL(JOBBATCHMASTER.job_ordersrno, 0) AS ORDERSRNO, ISNULL(JOBBATCHMASTER.JOB_ORDERTYPE, '') AS ORDERTYPE,ISNULL(JOBBATCHMASTER.job_no, 0) AS JOBDOCKETNO ", "", " ALLORDERMASTER INNER JOIN ALLORDERMASTER_DESC ON ALLORDERMASTER.ORDER_NO = ALLORDERMASTER_DESC.ORDER_NO AND ALLORDERMASTER.ORDER_YEARID = ALLORDERMASTER_DESC.ORDER_YEARID AND  ALLORDERMASTER.TYPE = ALLORDERMASTER_DESC.TYPE INNER JOIN JOBBATCHMASTER ON ALLORDERMASTER_DESC.TYPE = JOBBATCHMASTER.JOB_ORDERTYPE AND ALLORDERMASTER_DESC.ORDER_NO = JOBBATCHMASTER.job_orderno AND  ALLORDERMASTER_DESC.ORDER_GRIDSRNO = JOBBATCHMASTER.job_ordersrno LEFT OUTER JOIN UNITMASTER ON ALLORDERMASTER_DESC.ORDER_UNITID = UNITMASTER.unit_id LEFT OUTER JOIN ITEMMASTER AS SUBITEMMATSER ON JOBBATCHMASTER.JOB_SUBITEMID = SUBITEMMATSER.item_id LEFT OUTER JOIN ITEMMASTER ON JOBBATCHMASTER.job_itemid = ITEMMASTER.item_id ", " AND (JOBBATCHMASTER.JOB_ASSEMBLYQTY - JOBBATCHMASTER.JOB_DELOUTQTY > 0) AND ALLORDERMASTER.ORDER_NO = " & Val(DT.Rows(0).Item("ORDERNO")) & " AND ALLORDERMASTER_DESC.ORDER_GRIDSRNO = " & Val(DT.Rows(0).Item("ORDERSRNO")) & "  AND ALLORDERMASTER_DESC.TYPE = '" & DT.Rows(0).Item("ORDERTYPE") & "'  And ALLORDERMASTER.ORDER_YEARID = " & YearId & "  ORDER BY ALLORDERMASTER.ORDER_NO")
                If DTSO.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DTSO.Rows
                        gridorders.Rows.Add(0, DTROW("ITEMCODE").ToString, DTROW("ITEMNAME").ToString, DTROW("PONO").ToString, DTROW("QUANTITY").ToString, DTROW("UNIT").ToString, 0, 0, 0, Val(DTROW("JOBDOCKETNO")), Val(DTROW("ORDERNO")), Val(DTROW("ORDERSRNO")), DTROW("ORDERTYPE").ToString)

                        If MIN = 0 Then
                            MIN = Val(DTROW("QUANTITY"))
                        Else
                            If MIN > Val(DTROW("QUANTITY").ToString) Then
                                MIN = DTROW("QUANTITY").ToString
                            End If
                        End If
                    Next
                    TXTREADYQTY.Text = Val(MIN)
                    TOTAL()

                    Dim DTSO1 As DataTable = OBJCMN.search(" ISNULL(SUM(DELIVERY.DEL_READYQTY),0 ) AS READYQTY ", "", " DELIVERY ", "  AND DELIVERY.DEL_MORDERNO = " & Val(DT.Rows(0).Item("ORDERNO")) & " AND DELIVERY.DEL_MORDERSRNO = " & Val(DT.Rows(0).Item("ORDERSRNO")) & "  AND DELIVERY.DEL_MORDERTYPE = '" & DT.Rows(0).Item("ORDERTYPE") & "'  And DELIVERY.DEL_YEARID = " & YearId & " ")

                    ' TXTREADYQTY.Text = Val(DTSO1.Rows(0).Item("READYQTY") + Val(MIN))

                    ' TXTREADYQTY.Text = Val(MIN)
                End If

                getsrno(gridorders)
                TOTAL()
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub



    Private Sub cmbname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " And GroupMaster.GROUP_SECONDARY = 'Sundry DEBTORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validated(sender As Object, e As EventArgs) Handles tstxtbillno.Validated
        Try
            If tstxtbillno.Text.Trim.Length = 0 Then Exit Sub
            gridorders.RowCount = 0
            TEMPCHALLANNO = Val(tstxtbillno.Text)
            If TEMPCHALLANNO > 0 Then
                edit = True
                Delivery_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub



    Sub TOTAL()
        Try
            LBLTOTALQTY.Text = 0.0
            LBLTOTALNOOFBOXES.Text = 0.0
            LBLTOTALEACH.Text = 0.0
            LBLTOTAL.Text = 0.0


            For Each ROW As DataGridViewRow In gridorders.Rows
                If ROW.Cells(GSRNO.Index).Value <> Nothing Then
                    LBLTOTALQTY.Text = Val(LBLTOTALQTY.Text) + Val(ROW.Cells(GQty.Index).EditedFormattedValue)
                    LBLTOTALNOOFBOXES.Text = Val(LBLTOTALNOOFBOXES.Text) + Val(ROW.Cells(GNOOFBOXES.Index).EditedFormattedValue)
                    LBLTOTALEACH.Text = Val(LBLTOTALEACH.Text) + Val(ROW.Cells(GEACH.Index).EditedFormattedValue)
                    LBLTOTAL.Text = Val(LBLTOTAL.Text) + Val(ROW.Cells(GGRIDTOTAL.Index).EditedFormattedValue)
                    ROW.Cells(GGRIDTOTAL.Index).Value = Val(ROW.Cells(GNOOFBOXES.Index).EditedFormattedValue) * Val(ROW.Cells(GEACH.Index).EditedFormattedValue)
                End If
            Next




            For Each ROW As DataGridViewRow In gridorders.Rows
                If ROW.Cells(GSRNO.Index).Value <> Nothing Then
                    TXTDELIVERYQTY.Text = ROW.Cells(GGRIDTOTAL.Index).Value
                End If
            Next
            TXTBALREADYQTY.Text = Format(Val(TXTREADYQTY.Text.Trim) - Val(TXTDELIVERYQTY.Text.Trim))

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridorders_KeyDown(sender As Object, e As KeyEventArgs) Handles gridorders.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridorders.RowCount > 0 Then
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                gridorders.Rows.RemoveAt(gridorders.CurrentRow.Index)
                TOTAL()
                getsrno(gridorders)
            ElseIf e.KeyCode = Keys.F5 Then
                ' EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridorders_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles gridorders.CellValidating
        Dim colNum As Integer = gridorders.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
        Select Case colNum

            Case GQty.Index, GNOOFBOXES.Index, GEACH.Index, GGRIDTOTAL.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If gridorders.CurrentCell.Value = Nothing Then gridorders.CurrentCell.Value = "0.00"
                    gridorders.CurrentCell.Value = Convert.ToDecimal(gridorders.Item(colNum, e.RowIndex).Value)
                    TOTAL()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                    'Exit Sub
                End If


        End Select

        For I As Integer = gridorders.CurrentRow.Index + 1 To gridorders.RowCount - 1
            gridorders.Item(GNOOFBOXES.Index, I).Value = gridorders.Item(GNOOFBOXES.Index, I - 1).EditedFormattedValue
            gridorders.Item(GEACH.Index, I).Value = gridorders.Item(GEACH.Index, I - 1).EditedFormattedValue
            gridorders.Item(GGRIDTOTAL.Index, I).Value = gridorders.Item(GGRIDTOTAL.Index, I - 1).EditedFormattedValue
        Next
        TOTAL()

    End Sub

    Private Sub TXTDELIVERDQTY_Validated(sender As Object, e As EventArgs) Handles TXTDELIVERYQTY.Validated
        TOTAL()
    End Sub
End Class