
Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class AccountsDetails

    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub AccountsDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.P And (e.Alt = True) Then
            Call PBEXCEL_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub AccountsDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgridname()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Sub fillgridname(Optional ByVal whereclause As String = "")
        Try
            Dim ALPARAVAL As New ArrayList
            Dim OBJACC As New ClsAccountsMaster

            ALPARAVAL.Add("")
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            OBJACC.alParaval = ALPARAVAL
            Dim dttable As DataTable = OBJACC.GETACCOUNTS
            gridname.DataSource = dttable

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getdetails(ByRef name As String)

        Dim OBJACC As New ClsAccountsMaster
        Dim ALPARAVAL As New ArrayList

        If name = Nothing Then Exit Sub

        ALPARAVAL.Add(name)
        ALPARAVAL.Add(CmpId)
        ALPARAVAL.Add(Locationid)
        ALPARAVAL.Add(YearId)

        OBJACC.alParaval = ALPARAVAL
        Dim dttable As DataTable = OBJACC.GETACCOUNTS

        cleartextbox()

        If dttable.Rows.Count > 0 Then
            txtcmpname.Text = dttable.Rows(0).Item("CMPNAME").ToString
            txtcusname.Text = dttable.Rows(0).Item("NAME").ToString
            txtgroup.Text = dttable.Rows(0).Item("GROUPNAME").ToString
            txtopbal.Text = Val(dttable.Rows(0).Item("OPBAL").ToString)
            txtdrcr.Text = dttable.Rows(0).Item("DRCR").ToString
            txtadd1.Text = dttable.Rows(0).Item("ADD1").ToString
            txtadd2.Text = dttable.Rows(0).Item("ADD2").ToString
            txtarea.Text = dttable.Rows(0).Item("AREA").ToString
            txtcity.Text = dttable.Rows(0).Item("CITY").ToString
            txtstate.Text = dttable.Rows(0).Item("STATE").ToString
            txtzipcode.Text = dttable.Rows(0).Item("ZIPCODE").ToString
            txtcountry.Text = dttable.Rows(0).Item("COUNTRY").ToString
            txtstd.Text = dttable.Rows(0).Item("STD").ToString
            txtresino.Text = dttable.Rows(0).Item("RESINO").ToString
            txtaltno.Text = dttable.Rows(0).Item("ALTNO").ToString
            txttel1.Text = dttable.Rows(0).Item("PHONE").ToString
            txtmobile.Text = dttable.Rows(0).Item("MOBILE").ToString
            txtfax.Text = dttable.Rows(0).Item("FAX").ToString
            txtwebsite.Text = dttable.Rows(0).Item("WEBSITE").ToString
            txtemail.Text = dttable.Rows(0).Item("EMAIL").ToString
            txtcrdays.Text = Val(dttable.Rows(0).Item("CRDAYS").ToString)
            txtcrlimit.Text = Val(dttable.Rows(0).Item("CRLIMIT").ToString)
            txtpanno.Text = dttable.Rows(0).Item("PANNO").ToString
            txtexciseno.Text = dttable.Rows(0).Item("EXCISENO").ToString
            txtrange.Text = dttable.Rows(0).Item("RANGE").ToString
            txtdivision.Text = dttable.Rows(0).Item("DIVISION").ToString
            txtcstno.Text = dttable.Rows(0).Item("CSTNO").ToString
            txttinno.Text = dttable.Rows(0).Item("TINNO").ToString
            txtstno.Text = dttable.Rows(0).Item("STNO").ToString
            txtvatno.Text = dttable.Rows(0).Item("VATNO").ToString
            TXTGSTIN.Text = dttable.Rows(0).Item("GSTIN").ToString
            txtadd.Text = dttable.Rows(0).Item("ADD").ToString
            txtshipadd.Text = dttable.Rows(0).Item("SHIPPINGADD").ToString
            txtnotes.Text = dttable.Rows(0).Item("REMARKS").ToString
            txtcode.Text = dttable.Rows(0).Item("CODE").ToString
        End If

    End Sub

    Sub cleartextbox()
        txtcmpname.Clear()
        txtcusname.Clear()
        txtgroup.Clear()
        txtopbal.Clear()
        txtdrcr.Clear()
        txtadd1.Clear()
        txtadd2.Clear()
        txtarea.Clear()
        txtcity.Clear()
        txtzipcode.Clear()
        txtstate.Clear()
        txtcountry.Clear()
        txtstd.Clear()
        txtresino.Clear()
        txtaltno.Clear()
        txttel1.Clear()
        txtmobile.Clear()
        txtfax.Clear()
        txtwebsite.Clear()
        txtemail.Clear()
        txtcrdays.Clear()
        txtcrlimit.Clear()
        txtpanno.Clear()
        txtexciseno.Clear()
        txtrange.Clear()
        txtdivision.Clear()
        txtcstno.Clear()
        txttinno.Clear()
        txtstno.Clear()
        txtvatno.Clear()
        TXTGSTIN.Clear()
        txtadd.Clear()
        txtshipadd.Clear()
        txtnotes.Clear()
        txtcode.Clear()
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            'If Convert.ToBoolean(gridledger.GetFocusedRowCellValue("ISLOCKED")) = True Then
            '    MsgBox("Fixed Ledger Can't Edit", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If
            showform(True, gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridledger.RowCount > 0) Then
                Dim objaccountsmaster As New AccountsMaster
                objaccountsmaster.MdiParent = MDIMain
                objaccountsmaster.edit = editval
                objaccountsmaster.frmstring = frmstring
                objaccountsmaster.tempAccountsName = name
                objaccountsmaster.Show()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            showform(False, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridledger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.Click
        Try
            getdetails(gridledger.GetFocusedRowCellValue("NAME"))
            'gettrans(gridledger.GetFocusedRowCellValue("Name"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.DoubleClick
        Try
            'If Convert.ToBoolean(gridledger.GetFocusedRowCellValue("ISLOCKED")) = True Then
            '    MsgBox("Fixed Ledger Can't Edit", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If
            showform(True, gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gridledger.FocusedRowChanged
        Try
            getdetails(gridledger.GetFocusedRowCellValue("NAME"))
            'gettrans(gridledger.GetFocusedRowCellValue("Name"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtzipcode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtzipcode.KeyPress
        numdotkeypress(e, txtzipcode, Me)
    End Sub

    Private Sub txtstd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtstd.KeyPress
        numdotkeypress(e, txtstd, Me)
    End Sub

    Private Sub txtresino_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtresino.KeyPress
        numdotkeypress(e, txtresino, Me)
    End Sub

    Private Sub txtaltno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtaltno.KeyPress
        numdotkeypress(e, txtaltno, Me)
    End Sub

    Private Sub txttel1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttel1.KeyPress
        numdotkeypress(e, txttel1, Me)
    End Sub

    Private Sub txtmobile_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmobile.KeyPress
        numdotkeypress(e, txtmobile, Me)
    End Sub

    Private Sub txtfax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfax.KeyPress
        numdotkeypress(e, txtfax, Me)
    End Sub

    Private Sub txtcrdays_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcrdays.KeyPress
        numdotkeypress(e, txtcrdays, Me)
    End Sub

    Private Sub txtcrlimit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcrlimit.KeyPress
        numdotkeypress(e, txtcrlimit, Me)
    End Sub

    Private Sub BlendPanel3_Click(sender As Object, e As EventArgs) Handles BlendPanel3.Click

    End Sub

    Private Sub PBENVELOP_Click(sender As Object, e As EventArgs) Handles PBENVELOP.Click
        Dim TEMPMSG2 As Integer = MsgBox("Wish to Print Envelope?", MsgBoxStyle.YesNo)
        If TEMPMSG2 = vbYes Then
            Dim OBJENV As New payment_advice
            OBJENV.WHERECLAUSE = " {LEDGERS.Acc_cmpname} = '" & gridledger.GetFocusedRowCellValue("NAME") & "' and {LEDGERS.ACC_YEARID} = " & YearId
            OBJENV.FRMSTRING = "ENVELOPE"
            OBJENV.MdiParent = MDIMain
            OBJENV.Show()
        End If
    End Sub




    Private Sub CMDSHOWDATA_Click(sender As Object, e As EventArgs) Handles CMDSHOWDATA.Click
        Try
            'GET ALL DATA FROM ORDERS WITH RESPECT TO SELECTED ITEM, IRRESPECTIVE TO YEAR
            FILLGRIDDETAILS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDDETAILS()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(ITEMMASTER.item_actualsizewidth, '') AS SIZE1, ISNULL(ITEMMASTER.item_actualsizeheight, '') AS SIZE2, ISNULL(ITEMMASTER.item_sizefoldingwidth, '') AS FOLDINGSIZE, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(STATEMASTER.state_name, '') AS STATE, SUM(ISNULL(ORDERMASTER_DESC.ORDER_QTY, 0))  AS QTY, ISNULL(ORDERMASTER_DESC.ORDER_BASICRATE, 0) AS RATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME ", "", " ORDERMASTER INNER JOIN ORDERMASTER_DESC ON ORDERMASTER.ORDER_NO = ORDERMASTER_DESC.ORDER_NO AND ORDERMASTER.ORDER_YEARID = ORDERMASTER_DESC.ORDER_YEARID INNER JOIN ITEMMASTER ON ORDERMASTER_DESC.ORDER_ITEMID = ITEMMASTER.item_id INNER JOIN LEDGERS ON ORDERMASTER.ORDER_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id LEFT OUTER JOIN COLORMASTER ON ITEMMASTER.item_colorid = COLORMASTER.COLOR_id", " AND LEDGERS.ACC_CMPNAME = '" & gridledger.GetFocusedRowCellValue("NAME") & "' GROUP BY ISNULL(ITEMMASTER.item_code, ''), ISNULL(ITEMMASTER.item_name, ''), ISNULL(ITEMMASTER.item_actualsizewidth, ''), ISNULL(ITEMMASTER.item_actualsizeheight, ''), ISNULL(ITEMMASTER.item_sizefoldingwidth, ''), ISNULL(COLORMASTER.COLOR_name, ''), ISNULL(STATEMASTER.state_name, ''), ISNULL(ORDERMASTER_DESC.ORDER_BASICRATE, 0), ISNULL(LEDGERS.Acc_cmpname, '')")
            GRIDBILLDETAILS.DataSource = DT
            If DT.Rows.Count > 0 Then
                GRIDBILL.FocusedRowHandle = GRIDBILL.RowCount - 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgridname()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PBEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBEXCEL.Click
        Try
            Dim OBJACC As New LedgerDetailsReport
            OBJACC.MdiParent = MDIMain
            OBJACC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridledger.RowStyle
        Try
            Dim DT As DataTable = gridname.DataSource
            If e.RowHandle >= 0 Then
                Dim ROW As DataRow = DT.Rows(e.RowHandle)
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("ISLOCKED")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 10.0F, System.Drawing.FontStyle.Regular)
                    e.Appearance.BackColor = Color.Yellow
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class