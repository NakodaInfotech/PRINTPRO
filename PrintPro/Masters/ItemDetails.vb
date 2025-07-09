
Imports BL
Imports System.Windows.Forms

Public Class ItemDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub ItemDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        End If
    End Sub

    Private Sub ItemDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If ClientName <> "GANESHMUDRA" Then
                TabControl2.Visible = False
            End If
            FILLGRIDDETAILS()
            fillgridname()
            'fillgridname("and itemmaster.item_yearid= " & YearId & " ordre by itemmaster.item_code")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgridname()
        Try
            Dim objcmn As New ClsCommonMaster
            Dim dt As New DataTable
            dt = objcmn.search("ITEMMASTER.item_id AS ITEMID, ITEMMASTER.item_code AS ITEMCODE, ITEMMASTER.item_fileno AS FILENO, ITEMMASTER.item_name AS ITEMNAME, ISNULL(ITEMMASTER.item_actualsizewidth, '') AS ACTUALSIZEWIDTH, ISNULL(PAPERGSMMASTER.PAPERGSM_NAME,'') AS PAPERGSM, ISNULL(ITEMMASTER.ITEM_BLOCKED,0) AS BLOCKED ", "", "ITEMMASTER LEFT OUTER JOIN PAPERGSMMASTER ON ITEMMASTER.item_papergsmid = PAPERGSMMASTER.PAPERGSM_ID", " AND itemmaster.item_yearid= " & YearId & " ORDER by itemmaster.item_code")
            gridname.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridledger.FocusedRowHandle = gridledger.RowCount - 1
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub getdetails(ByVal ID As Integer)

        If ID = 0 Then Exit Sub
        Dim objClsITEM As New clsItemmaster
        objClsITEM.alParaval.Add(ID)
        objClsITEM.alParaval.Add(CmpId)
        objClsITEM.alParaval.Add(Locationid)
        objClsITEM.alParaval.Add(YearId)
        Dim dttable As DataTable = objClsITEM.GETITEM

        cleartextbox()

        If dttable.Rows.Count > 0 Then
            For Each dr As DataRow In dttable.Rows

                txtitemcode.Text = Convert.ToString(dr("ITEMCODE"))
                txtitemname.Text = Convert.ToString(dr("ITEMNAME"))
                TXTHSNCODE.Text = dr("HSNCODE").ToString
                txtfileno.Text = Convert.ToString(dr("FILENO"))
                txtcoordinator.Text = Convert.ToString(dr("COORDINATORNAME"))
                txtartist.Text = Convert.ToString(dr("ARTIST"))
                txtlinks.Text = Convert.ToString(dr("LINKS"))
                txtfonts.Text = Convert.ToString(dr("FONTS"))
                txtsoftware.Text = Convert.ToString(dr("SOFTWARE"))
                TXTGSM.Text = Convert.ToString(dr("PAPERGSM"))
                txtscreen.Text = Convert.ToString(dr("SCREEN"))
                txtcolor.Text = Convert.ToString(dr("COLOR"))
                TXTACTUALSIZEwidth.Text = Convert.ToString(dr("ACTUALWIDTH"))
                TXTACTUALSIZEHEIGHT.Text = Convert.ToString(dr("ACTUALHEIGHT"))
                TXTDESIGN.Text = Convert.ToString(dr("DESIGN"))
                txtpharmacode.Text = Convert.ToString(dr("PHARMACODE"))
                txtsizefoldingwidth.Text = Convert.ToString(dr("FOLDWIDTH"))
                txtsizefoldingheight.Text = Convert.ToString(dr("FOLDHEIGHT"))
                txtvarnish.Text = Convert.ToString(dr("VARNISH"))
                TXTMATERIAL.Text = Convert.ToString(dr("PAPERMATERIALNAME"))
                txtcutsize.Text = Convert.ToString(dr("CUTSIZE"))
                txtvertical.Text = Convert.ToString(dr("VERTICAL"))
                txthorizontal.Text = Convert.ToString(dr("HORIZONTAL"))
                txtups.Text = Convert.ToString(dr("UPS"))
                txtpaperlength.Text = Convert.ToString(dr("PAPERSIZENAME"))
                txtrepeatlength.Text = Convert.ToString(dr("REPEATLENGTH"))
                TXTGRAIN.Text = Convert.ToString(dr("GRAIN"))
                TXTTEARTAPE.Text = Convert.ToString(dr("TEARTAPE"))
                TXTKNIFE.Text = Convert.ToString(dr("KNIFES"))
                TXTMATERIALCODE.Text = Convert.ToString(dr("MATERIALCODE"))
                CHKBLOCKED.Checked = Convert.ToBoolean(dttable.Rows(0).Item("BLOCKED"))

                If dr("PROOFSEND") = 0 Then
                    CHKPROOFSEND.Checked = False
                Else
                    CHKPROOFSEND.Checked = True
                End If
                If dr("PROOFOK") = 0 Then
                    CHKPROOFOK.Checked = False
                Else
                    CHKPROOFOK.Checked = True
                End If

            Next

        End If

        txtartwork.Text = dttable.Rows(0).Item("ARTWORK").ToString
        txtremarks.Text = dttable.Rows(0).Item("REMARKS").ToString

    End Sub

    Sub cleartextbox()

        txtcoordinator.Text = ""
        txtartist.Clear()
        txtlinks.Clear()
        txtfonts.Clear()
        txtsoftware.Clear()
        TXTGSM.Clear()
        txtscreen.Clear()
        txtcolor.Text = ""
        TXTACTUALSIZEwidth.Clear()
        TXTACTUALSIZEHEIGHT.Clear()
        TXTDESIGN.Text = ""
        txtpharmacode.Clear()
        txtsizefoldingwidth.Clear()
        txtsizefoldingheight.Clear()
        txtvarnish.Clear()
        TXTMATERIAL.Text = ""
        txtcutsize.Clear()
        txtvertical.Clear()
        txthorizontal.Clear()
        txtups.Clear()
        txtpaperlength.Clear()
        txtrepeatlength.Clear()
        TXTGRAIN.Text = ""
        ITEMGROUP.Text = ""
        TXTKNIFE.Clear()
        TXTMATERIALCODE.Clear()

        txtartwork.Clear()
        txtremarks.Clear()

        GRIDBILL.DataSource = Nothing
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridledger.GetFocusedRowCellValue("ITEMID"), gridledger.GetFocusedRowCellValue("ITEMNAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal ID As Integer, ByVal name As String)
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (gridledger.RowCount > 0 And editval = True) Then
                Dim objItemmaster As New ItemMaster
                objItemmaster.MdiParent = MDIMain
                objItemmaster.EDIT = editval
                objItemmaster.TEMPITEMID = ID
                objItemmaster.TEMPITEMNAME = name
                objItemmaster.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.Click
        Try
            getdetails(gridledger.GetFocusedRowCellValue("ITEMID"))
            FILLGRIDBOMDETAILS(gridledger.GetFocusedRowCellValue("ITEMID"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.DoubleClick
        Try
            showform(True, gridledger.GetFocusedRowCellValue("ITEMID"), gridledger.GetFocusedRowCellValue("ITEMNAME"))
        Catch ex As Exception
            Throw ex
        End Try
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
            Dim DT As DataTable = OBJCMN.search(" INVOICEMASTER.INVOICE_PONO AS PONO, INVOICEMASTER.INVOICE_PODATE AS DATE, LEDGERS.Acc_cmpname AS NAME, INVOICEMASTER_DESC.INVOICE_QTY AS QTY,  ORDERMASTER_DESC.ORDER_BASICRATE AS RATE,CAST(YEAR(YEARMASTER.year_startdate) AS VARCHAR(4)) + '-' + CAST(YEAR(YEARMASTER.year_enddate) AS VARCHAR(4)) AS YEARNAME, ITEMMASTER.item_name AS ITEMNAME ", "", " INVOICEMASTER INNER JOIN INVOICEMASTER_DESC ON INVOICEMASTER.invoice_no = INVOICEMASTER_DESC.INVOICE_NO AND INVOICEMASTER.invoice_yearid = INVOICEMASTER_DESC.INVOICE_YEARID INNER JOIN YEARMASTER ON INVOICEMASTER.invoice_yearid = YEARMASTER.year_id INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON INVOICEMASTER_DESC.INVOICE_ITEMNAMEID = ITEMMASTER.item_id INNER JOIN ORDERMASTER_DESC ON INVOICEMASTER.INVOICE_ORDERNO = ORDERMASTER_DESC.ORDER_NO AND INVOICEMASTER.INVOICE_ORDERSRNO = ORDERMASTER_DESC.ORDER_GRIDSRNO ", " AND ITEMMASTER.ITEM_CODE = '" & gridledger.GetFocusedRowCellValue("ITEMCODE") & "' ")
            GRIDBILL.DataSource = DT
            If DT.Rows.Count > 0 Then
                GridView2.FocusedRowHandle = GridView2.RowCount - 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gridledger.FocusedRowChanged
        Try
            getdetails(gridledger.GetFocusedRowCellValue("ITEMID"))
            FILLGRIDBOMDETAILS(gridledger.GetFocusedRowCellValue("ITEMID"))
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
            Dim OBJACC As New ItemDetailsReport
            OBJACC.MdiParent = MDIMain
            OBJACC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ItemDetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "GANESHMUDRA" Then
                TabControl2.Visible = True
                TabControl1.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDBOMDETAILS(ByVal ID As Integer)
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(SUBITEMMASTER.item_code, '') AS BOMDETAILS  ", "", " ITEMMASTER_BOMDETAILS INNER JOIN ITEMMASTER ON ITEMMASTER_BOMDETAILS.ITEM_ID = ITEMMASTER.item_id AND ITEMMASTER_BOMDETAILS.ITEM_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN  ITEMMASTER AS SUBITEMMASTER ON ITEMMASTER_BOMDETAILS.ITEM_SUBITEMID = SUBITEMMASTER.item_id ", " AND ITEMMASTER.ITEM_NAME = '" & gridledger.GetFocusedRowCellValue("ITEMNAME") & "'")
            GridControl1.DataSource = DT
            If DT.Rows.Count > 0 Then
                GridView1.FocusedRowHandle = GridView1.RowCount - 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class

