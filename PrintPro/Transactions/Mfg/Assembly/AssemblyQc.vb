Imports BL
Imports System.IO
Imports System.Net
Imports System.ComponentModel
Imports RestSharp
Imports Newtonsoft.Json
Imports TaxProEInvoice.API


Public Class AssemblyQc
    Dim INTRESULT As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public TEMPMSG, TEMPASSEMBLYNO As Integer
    Public tempprocessname As String
    Public edit As Boolean
    Dim GRIDDOUBLECLICK As Boolean




    Private Sub CMDDELETE_Click(sender As Object, e As EventArgs) Handles CMDDELETE.Click
        Try
            If edit = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Unable to Delete", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Wish to Delete Assembly.?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    TEMPMSG = MsgBox("Are you Sure?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then

                        Dim ALPARAVAL As New ArrayList
                        ALPARAVAL.Add(TXTASSYNO.Text.Trim)
                        ALPARAVAL.Add(YearId)

                        Dim OBJJOB As New ClsAssembly
                        OBJJOB.alParaval = ALPARAVAL
                        Dim INTRESULT As Integer = OBJJOB.delete()
                        MsgBox("Assembly is Deleted")
                        CLEAR()
                        edit = False
                    Else
                        MsgBox("Delete is only in Edit Mode")
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        TXTASSYNO.Clear()
        'txtbatchno.Clear()
        'txtchallan.ReadOnly = False
        DTASSYDATE.Value = Mydate
        CMBNAME.Text = ""
        TXTITEMCODE.Clear()
        TXTITEMNAME.Clear()
        TXTJOBDOCKETNO.Text = ""
        TXTBATCHNO.Clear()
        TXTQTY.Text = ""
        TXTPERCENTAGE.Clear()
        TXTTOTALSHEETS.Clear()
        tstxtbillno.Clear()

        TXTQCPAPER.Clear()
        TXTQCGSM.Clear()
        TXTQCGRAIN.Clear()
        TXTQCTEXT.Visible = False
        TXTQCPHARMA.Visible = False
        TXTQCUPS.Clear()
        TXTQCVISUAL.Clear()
        TXTQCCOLOR.Clear()
        TXTQCVARNISH.Clear()
        TXTQCPERFOR.Clear()
        TXTQCDESIGN.Clear()
        TXTQCSIZE.Clear()
        TXTQCSTICKER.Clear()
        TXTQCADHESIVE.Clear()
        TXTQCFINALAMT.Clear()
        TXTQCPACKET.Clear()
        TXTQCSHIPPER.Clear()
        TXTQCLABEL.Clear()
        TXTQCBATCH.Clear()
        TXTQCHEAD.Clear()
        QCDATE.Value = Mydate
        TXTQCREMARKS.Clear()
        TXTINKDETAILS.Clear()
        TXTORDERNO.Clear()
        TXTORDERSRNO.Clear()
        TXTORDERTYPE.Clear()

        CMDSELECTBATCH.Enabled = True
        GRIDASSEMBLY.RowCount = 0
        LBLTOTALQTY.Text = "0"
        Ep.Clear()


        getmax_ASSEMBLY_no()
        'gridUPLOADDoubleClick = False

        TabControl1.SelectedIndex = 0


        txtpackingname.Clear()
        TXTSHIPPERNAME.Clear()
        txtpacketitem1.Clear()
        txtpacketitem2.Clear()
        txtpacketitem3.Clear()
        txtpacket1.Clear()
        txtpacket2.Clear()
        txtpacket3.Clear()
        txtpackettotal1.Clear()
        txtpackettotal2.Clear()
        txtpackettotal3.Clear()
        txttotalpacket.Clear()
        txtptotal.Clear()

        txtshipperitem1.Clear()
        txtshipperitem2.Clear()
        txtshipperitem3.Clear()
        txtshipper1.Clear()
        txtshipper2.Clear()
        txtshipper3.Clear()
        txtshippertotal1.Clear()
        txtshippertotal2.Clear()
        txtshippertotal3.Clear()
        txttotalshipper.Clear()
        txtstotal.Clear()
        GRIDSUMM.RowCount = 0



        lbllocked.Visible = False
        PBlock.Visible = False
        LBLCHALLANDONE.Visible = False

    End Sub

    Private Sub TOOLPREVIOUS_Click(sender As Object, e As EventArgs) Handles TOOLPREVIOUS.Click
        Try
            GRIDASSEMBLY.RowCount = 0
LINE1:
            TEMPASSEMBLYNO = Val(TXTASSYNO.Text) - 1
            If TEMPASSEMBLYNO > 0 Then
                edit = True
                AssemblyQc_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If

            If GRIDASSEMBLY.RowCount = 0 And TEMPASSEMBLYNO > 1 Then
                TXTASSYNO.Text = TEMPASSEMBLYNO
                GoTo LINE1
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLNEXT_Click(sender As Object, e As EventArgs) Handles TOOLNEXT.Click
        Try
            GRIDASSEMBLY.RowCount = 0
LINE1:
            TEMPASSEMBLYNO = Val(TXTASSYNO.Text) + 1
            getmax_ASSEMBLY_no()
            Dim MAXNO As Integer = TXTASSYNO.Text.Trim
            CLEAR()
            If Val(TXTASSYNO.Text) - 1 >= TEMPASSEMBLYNO Then
                edit = True
                AssemblyQc_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If
            If GRIDASSEMBLY.RowCount = 0 And TEMPASSEMBLYNO < MAXNO Then
                TXTASSYNO.Text = TEMPASSEMBLYNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Call CMDOK_Click(sender, e)

    End Sub

    Private Sub OpenToolStripButton_Click(sender As Object, e As EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJGRN As New AssemblyQcDetails
            OBJGRN.MdiParent = MDIMain
            OBJGRN.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AssemblyQc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'ASSEMBLY'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            CLEAR()
            FILLCMB()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJASSEMBLY As New ClsAssembly
                OBJASSEMBLY.alParaval.Add(TEMPASSEMBLYNO)
                OBJASSEMBLY.alParaval.Add(CmpId)
                OBJASSEMBLY.alParaval.Add(YearId)
                Dim DT As DataTable = OBJASSEMBLY.SELELECTASSEMBLY(TEMPASSEMBLYNO, YearId)

                If DT.Rows.Count > 0 Then
                    For Each DR As DataRow In DT.Rows
                        TXTASSYNO.Text = TEMPASSEMBLYNO
                        TXTASSYNO.ReadOnly = True
                        DTASSYDATE.Value = Format(Convert.ToDateTime(DR("DATE")).Date, "dd/MM/yyyy")
                        CMBNAME.Text = Convert.ToString(DR("NAME"))
                        TXTITEMCODE.Text = Convert.ToString(DR("ITEMCODE"))
                        TXTITEMNAME.Text = Convert.ToString(DR("ITEMNAME"))
                        TXTJOBDOCKETNO.Text = Convert.ToString(DR("JOBDOCKETNO"))
                        TXTBATCHNO.Text = Convert.ToString(DR("BATCHNO"))
                        TXTQTY.Text = Convert.ToString(DR("QTY"))
                        TXTPERCENTAGE.Text = Convert.ToString(DR("PERCENTAGE"))
                        TXTTOTALSHEETS.Text = Convert.ToString(DR("TOTALSHEET"))
                        LBLTOTALQTY.Text = Convert.ToString(DR("TOTALQTY"))


                        TXTQCPAPER.Text = Convert.ToString(DR("PAPER"))
                        TXTQCGSM.Text = Convert.ToString(DR("GSM"))
                        TXTQCGRAIN.Text = Convert.ToString(DR("GRAIN"))
                        TXTQCTEXT.Text = Convert.ToString(DR("TEXT"))
                        TXTQCPHARMA.Text = Convert.ToString(DR("PHARMA"))
                        TXTQCUPS.Text = Convert.ToString(DR("UPSNO"))
                        TXTQCVISUAL.Text = Convert.ToString(DR("VISUAL"))
                        TXTQCCOLOR.Text = Convert.ToString(DR("COLOR"))
                        TXTQCVARNISH.Text = Convert.ToString(DR("VARNISH"))
                        TXTQCPERFOR.Text = Convert.ToString(DR("PERFORATION"))
                        TXTQCDESIGN.Text = Convert.ToString(DR("DESIGN"))
                        TXTQCSIZE.Text = Convert.ToString(DR("SIZE"))
                        TXTQCSTICKER.Text = Convert.ToString(DR("STICKER"))
                        TXTQCADHESIVE.Text = Convert.ToString(DR("ADHESIVE"))
                        TXTQCFINALAMT.Text = Convert.ToString(DR("FINAL"))
                        TXTQCPACKET.Text = Convert.ToString(DR("PACKET"))
                        TXTQCSHIPPER.Text = Convert.ToString(DR("SHIPPER"))
                        TXTQCLABEL.Text = Convert.ToString(DR("LABEL"))
                        TXTQCBATCH.Text = Convert.ToString(DR("BATCH"))
                        TXTQCHEAD.Text = Convert.ToString(DR("QCHEAD"))
                        QCDATE.Value = Format(Convert.ToDateTime(DR("QCDATE")).Date, "dd/MM/yyyy")
                        TXTQCREMARKS.Text = Convert.ToString(DR("QCREMARKS"))
                        TXTORDERNO.Text = Convert.ToString(DR("ORDERNO"))
                        TXTORDERSRNO.Text = Convert.ToString(DR("ORDERSRNO"))
                        TXTORDERTYPE.Text = Convert.ToString(DR("ORDERTYPE"))

                        txtpacketitem1.Text = Val(DR("PACKETITEM1"))
                        txtpacketitem2.Text = Val(DR("PACKETITEM2"))
                        txtpacketitem3.Text = Val(DR("PACKETITEM3"))
                        txtpacket1.Text = Val(DR("PACKET1"))
                        txtpacket2.Text = Val(DR("PACKET2"))
                        txtpacket3.Text = Val(DR("PACKET3"))

                        txtshipperitem1.Text = Val(DR("SHIPPERITEM1"))
                        txtshipperitem2.Text = Val(DR("SHIPPERITEM2"))
                        txtshipperitem3.Text = Val(DR("SHIPPERITEM3"))
                        txtshipper1.Text = Val(DR("SHIPPER1"))
                        txtshipper2.Text = Val(DR("SHIPPER2"))
                        txtshipper3.Text = Val(DR("SHIPPER3"))
                        txttotalpacket.Text = Val(DR("TOTALPACKETS"))
                        txttotalshipper.Text = Val(DR("TOTALSHIPPERS"))

                        txtpackingname.Text = Convert.ToString(DR("PACKINGNAME"))
                        TXTSHIPPERNAME.Text = Convert.ToString(DR("SHIPPERNAME"))

                        txtpackettotal1.Text = Val(DR("PACKETTOTAL1"))
                        txtpackettotal2.Text = Val(DR("PACKETTOTAL2"))
                        txtpackettotal3.Text = Val(DR("PACKETTOTAL3"))
                        txtptotal.Text = Val(DR("PTOTAL"))
                        txtshippertotal1.Text = Val(DR("SHIPPERTOTAL1"))
                        txtshippertotal2.Text = Val(DR("SHIPPERTOTAL2"))
                        txtshippertotal3.Text = Val(DR("SHIPPERTOTAL3"))
                        txtstotal.Text = Val(DR("STOTAL"))





                        ''GRID VALUES
                        If Val(DR("SRNO")) > 0 Then
                            GRIDASSEMBLY.Rows.Add(Val(DR("SRNO")), DR("SUBITEMCODE").ToString, DR("SUBITEMNAME").ToString, Val(DR("GRIDQTY")), DR("GRIDBATCHNO").ToString, Val(DR("GRIDJOBDOCKETNO")), Val(DR("PACKETS")))

                        End If

                        If Convert.ToBoolean(DR("DONE")) = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                            LBLCHALLANDONE.Visible = True

                        End If


                        TOTAL()
                        ' CMDSELECTBATCH.Enabled = False
                    Next
                    GRIDASSEMBLY.FirstDisplayedScrollingRowIndex = GRIDASSEMBLY.RowCount - 1
                    CMDSELECTBATCH.Enabled = True
                Else
                    '  TOTAL()
                    edit = False
                    CLEAR()
                End If
            End If




        Catch ex As Exception

        End Try
    End Sub

    Sub FILLCMB()
        If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND ACC_TYPE = 'ACCOUNTS'")
    End Sub



    Private Sub CMDCLEAR_Click(sender As Object, e As EventArgs) Handles CMDCLEAR.Click
        CLEAR()
        edit = False
        TXTASSYNO.Focus()
    End Sub

    Private Sub CMDOK_Click(sender As Object, e As EventArgs) Handles CMDOK.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Ep.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim ALPARAVAL As New ArrayList
            ALPARAVAL.Add(TXTASSYNO.Text.Trim)
            ALPARAVAL.Add(DTASSYDATE.Value.Date)
            ALPARAVAL.Add(CMBNAME.Text.Trim)
            ALPARAVAL.Add(TXTITEMCODE.Text.Trim)
            ALPARAVAL.Add(TXTITEMNAME.Text.Trim)
            ALPARAVAL.Add(TXTJOBDOCKETNO.Text.Trim)
            ALPARAVAL.Add(TXTBATCHNO.Text.Trim)
            ALPARAVAL.Add(Val(TXTQTY.Text.Trim))
            ALPARAVAL.Add(Val(TXTPERCENTAGE.Text.Trim))
            ALPARAVAL.Add(Val(TXTTOTALSHEETS.Text.Trim))
            ALPARAVAL.Add(Val(LBLTOTALQTY.Text.Trim))

            ALPARAVAL.Add(TXTQCPAPER.Text.Trim)
            ALPARAVAL.Add(TXTQCGSM.Text.Trim)
            ALPARAVAL.Add(TXTQCGRAIN.Text.Trim)
            ALPARAVAL.Add(TXTQCTEXT.Text.Trim)
            ALPARAVAL.Add(TXTQCPHARMA.Text.Trim)
            ALPARAVAL.Add(Val(TXTQCUPS.Text.Trim))
            ALPARAVAL.Add(TXTQCVISUAL.Text.Trim)
            ALPARAVAL.Add(TXTQCCOLOR.Text.Trim)
            ALPARAVAL.Add(TXTQCVARNISH.Text.Trim)
            ALPARAVAL.Add(TXTQCPERFOR.Text.Trim)
            ALPARAVAL.Add(TXTQCDESIGN.Text.Trim)
            ALPARAVAL.Add(TXTQCSIZE.Text.Trim)
            ALPARAVAL.Add(TXTQCSTICKER.Text.Trim)
            ALPARAVAL.Add(TXTQCADHESIVE.Text.Trim)
            ALPARAVAL.Add(TXTQCFINALAMT.Text.Trim)
            ALPARAVAL.Add(TXTQCPACKET.Text.Trim)
            ALPARAVAL.Add(TXTQCSHIPPER.Text.Trim)
            ALPARAVAL.Add(TXTQCLABEL.Text.Trim)
            ALPARAVAL.Add(TXTQCBATCH.Text.Trim)
            ALPARAVAL.Add(TXTQCHEAD.Text.Trim)
            ALPARAVAL.Add(QCDATE.Value.Date)
            ALPARAVAL.Add(TXTQCREMARKS.Text.Trim)
            ALPARAVAL.Add(TXTINKDETAILS.Text.Trim)
            ALPARAVAL.Add(TXTORDERNO.Text.Trim)
            ALPARAVAL.Add(TXTORDERSRNO.Text.Trim)
            ALPARAVAL.Add(TXTORDERTYPE.Text.Trim)

            ALPARAVAL.Add(Val(txtpacketitem1.Text.Trim))
            ALPARAVAL.Add(Val(txtpacketitem2.Text.Trim))
            ALPARAVAL.Add(Val(txtpacketitem3.Text.Trim))
            ALPARAVAL.Add(Val(txtpacket1.Text.Trim))
            ALPARAVAL.Add(Val(txtpacket2.Text.Trim))
            ALPARAVAL.Add(Val(txtpacket3.Text.Trim))
            ALPARAVAL.Add(txttotalpacket.Text.Trim)
            ALPARAVAL.Add(Val(txtshipperitem1.Text.Trim))
            ALPARAVAL.Add(Val(txtshipperitem2.Text.Trim))
            ALPARAVAL.Add(Val(txtshipperitem3.Text.Trim))
            ALPARAVAL.Add(Val(txtshipper1.Text.Trim))
            ALPARAVAL.Add(Val(txtshipper2.Text.Trim))
            ALPARAVAL.Add(Val(txtshipper3.Text.Trim))
            ALPARAVAL.Add(txttotalshipper.Text.Trim)
            ALPARAVAL.Add(txtpackingname.Text.Trim)
            ALPARAVAL.Add(TXTSHIPPERNAME.Text.Trim)

            ALPARAVAL.Add(txtpackettotal1.Text.Trim)
            ALPARAVAL.Add(txtpackettotal2.Text.Trim)
            ALPARAVAL.Add(txtpackettotal3.Text.Trim)
            ALPARAVAL.Add(txtptotal.Text.Trim)

            ALPARAVAL.Add(txtshippertotal1.Text.Trim)
            ALPARAVAL.Add(txtshippertotal2.Text.Trim)
            ALPARAVAL.Add(txtshippertotal2.Text.Trim)
            ALPARAVAL.Add(txtstotal.Text.Trim)




            ' ALPARAVAL.Add(txttotalpacket.Text.Trim)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            ''GRID VALUE
            Dim GRIDSRNO As String = ""
            Dim ITEMCODE As String = ""
            Dim ITEMNAME As String = ""
            Dim GRIDQTY As String = ""
            Dim GRIDBATCHNO As String = ""
            Dim GRIDJOBDOCKETNO As String = ""
            Dim PACKETS As String = ""

            For Each ROW As Windows.Forms.DataGridViewRow In GRIDASSEMBLY.Rows
                If ROW.Cells(0).Value.ToString <> "" Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = ROW.Cells(GSRNO.Index).Value.ToString
                        ITEMCODE = ROW.Cells(GITEMCODE.Index).Value.ToString
                        ITEMNAME = ROW.Cells(GITEMNAME.Index).Value.ToString
                        GRIDQTY = Val(ROW.Cells(GQTY.Index).Value).ToString
                        GRIDBATCHNO = ROW.Cells(GBATCHNO.Index).Value.ToString
                        GRIDJOBDOCKETNO = Val(ROW.Cells(GGRIDJOBDOCKETNO.Index).Value)
                        PACKETS = Val(ROW.Cells(GPACKETS.Index).Value)

                    Else
                        GRIDSRNO = GRIDSRNO & "|" & ROW.Cells(GSRNO.Index).Value.ToString
                        ITEMCODE = ITEMCODE & "|" & ROW.Cells(GITEMCODE.Index).Value.ToString
                        ITEMNAME = ITEMNAME & "|" & ROW.Cells(GITEMNAME.Index).Value.ToString
                        GRIDQTY = GRIDQTY & "|" & Val(ROW.Cells(GQTY.Index).Value).ToString
                        GRIDBATCHNO = GRIDBATCHNO & "|" & ROW.Cells(GBATCHNO.Index).Value.ToString
                        GRIDJOBDOCKETNO = GRIDJOBDOCKETNO & "|" & Val(ROW.Cells(GGRIDJOBDOCKETNO.Index).Value)
                        PACKETS = PACKETS & "|" & Val(ROW.Cells(GPACKETS.Index).Value)

                    End If
                End If
            Next
            ALPARAVAL.Add(GRIDSRNO)
            ALPARAVAL.Add(ITEMCODE)
            ALPARAVAL.Add(ITEMNAME)
            ALPARAVAL.Add(GRIDQTY)
            ALPARAVAL.Add(GRIDBATCHNO)
            ALPARAVAL.Add(GRIDJOBDOCKETNO)
            ALPARAVAL.Add(PACKETS)



            ''SUNNGRID VALUE
            Dim GRIDSUMJOBDOCKETNO As String = ""

            For Each ROW As Windows.Forms.DataGridViewRow In GRIDSUMM.Rows
                If ROW.Cells(0).Value.ToString = "" Then
                    GRIDSUMJOBDOCKETNO = ROW.Cells(SJOBDOCKETNO.Index).Value.ToString

                Else
                    GRIDSUMJOBDOCKETNO = GRIDSUMJOBDOCKETNO & "|" & ROW.Cells(SJOBDOCKETNO.Index).Value.ToString
                End If
            Next
            ALPARAVAL.Add(GRIDSUMJOBDOCKETNO)


            Dim OBJINVOICE As New ClsAssembly()
            OBJINVOICE.alParaval = ALPARAVAL

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTT As DataTable = OBJINVOICE.SAVE()
                MsgBox("Details Added!!")
                TXTASSYNO.Text = DTT.Rows(0).Item(0)
                PRINTREPORT(DTT.Rows(0).Item(0))


            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                ALPARAVAL.Add(TEMPASSEMBLYNO)
                INTRESULT = OBJINVOICE.UPDATE()
                MsgBox("Details Updated!!")
                PRINTREPORT(TEMPASSEMBLYNO)
                edit = False
            End If
            CLEAR()
            CMBNAME.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Function ERRORVALID() As Boolean

        Dim bln As Boolean = True
        If CMBNAME.Text.Trim.Length = 0 Then
            Ep.SetError(CMBNAME, " Please Fill Party Name ")
            bln = False
        End If

        If DTASSYDATE.Text = "__/__/____" Then
            Ep.SetError(DTASSYDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(DTASSYDATE.Text) Then
                Ep.SetError(DTASSYDATE, "Date not in Accounting Year")
                bln = False
            End If
        End If

        If TXTQCPAPER.Text.Trim = "" Then
            Ep.SetError(TXTQCPAPER, " Please Fill QC Paper ")
            bln = False
        End If

        If TXTQCGSM.Text.Trim = "" Then
            Ep.SetError(TXTQCGSM, " Please Fill QC GSM ")
            bln = False
        End If

        If TXTQCDESIGN.Text.Trim = "" Then
            Ep.SetError(TXTQCDESIGN, " Please Fill QC Design ")
            bln = False
        End If

        If TXTQCUPS.Text.Trim = "" Then
            Ep.SetError(TXTQCUPS, " Please Fill  Ups No ")
            bln = False
        End If

        If TXTQCADHESIVE.Text.Trim = "" Then
            Ep.SetError(TXTQCADHESIVE, " Please Fill  Adhesive ")
            bln = False
        End If
        If TXTQCVARNISH.Text.Trim = "" Then
            Ep.SetError(TXTQCVARNISH, " Please Fill  Varnish")
            bln = False
        End If
        If TXTQCPERFOR.Text.Trim = "" Then
            Ep.SetError(TXTQCPERFOR, " Please Fill  Perforation ")
            bln = False
        End If
        If TXTQCFINALAMT.Text.Trim = "" Then
            Ep.SetError(TXTQCFINALAMT, " Please Fill  Final Qty ")
            bln = False
        End If
        If TXTQCPACKET.Text.Trim = "" Then
            Ep.SetError(TXTQCPACKET, " Please Fill  Packet Status")
            bln = False
        End If
        If TXTQCSHIPPER.Text.Trim = "" Then
            Ep.SetError(TXTQCSHIPPER, " Please Fill  Shipper Status")
            bln = False
        End If
        If TXTQCBATCH.Text.Trim = "" Then
            Ep.SetError(TXTQCBATCH, " Please Fill Batch Status ")
            bln = False
        End If
        If TXTQCCOLOR.Text.Trim = "" Then
            Ep.SetError(TXTQCCOLOR, " Please Fill Color ")
            bln = False
        End If
        If TXTQCHEAD.Text.Trim = "" Then
            Ep.SetError(TXTQCHEAD, " Please Fill QC Head ")
            bln = False
        End If

        If GRIDASSEMBLY.RowCount = 0 Then
            Ep.SetError(GRIDASSEMBLY, " Please Enter Proper Details ")
            bln = False
        End If
        'If GRIDLAB.RowCount = 0 Then
        '    EP.SetError(GGRAD, " Please Enter Quality Details ")
        '    bln = False
        'End If
        If Val(TXTQTY.Text.Trim) <> Val(txtptotal.Text.Trim) Or Val(TXTQTY.Text.Trim) <> Val(txtstotal.Text.Trim) Or Val(txtstotal.Text.Trim) <> Val(txtptotal.Text.Trim) Then
            Ep.SetError(txtptotal, " Value Of Ready Qty and Packing and Shipper Should Be Same ")
            bln = False
        End If


        If LBLCHALLANDONE.Visible = True Then
            Ep.SetError(LBLCHALLANDONE, " Challan Done..!!")
            bln = False
        End If


        Return bln
    End Function

    Private Sub CMDSELECTBATCH_Click(sender As Object, e As EventArgs) Handles CMDSELECTBATCH.Click

        Try
            Ep.Clear()
            If CMBNAME.Text.Trim = "" Then
                MsgBox("Please Fill Party Name", MsgBoxStyle.Critical)
                CMBNAME.Focus()
                Exit Sub
            End If

            Dim OBJSO As New SelectOrder
            OBJSO.FRMSTRING = "ASSEMBLY"
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
                TXTTOTALSHEETS.Text = DT.Rows(0).Item("QUANTITY")


                Dim MIN As Integer = 0
                Dim BATCHNO As Integer = 0

                Dim OBJCMN As New ClsCommon
                ' Dim DTSO As DataTable = OBJCMN.search("  ISNULL(SUBITEMMASTER.item_code, '') AS SUBITEMCODE, ISNULL(SUBITEMMASTER.item_name, '') AS SUBITEMNAME, ISNULL(ALLORDERMASTER_DESC.ORDER_QTY, 0) AS GRIDQTY, ISNULL(BATCHMASTER.jobbatch_no, 0) AS BATCHNO, ISNULL(BATCHMASTER.jobbatch_madeqty, 0) AS BATCHQTY ", "", " ITEMMASTER AS SUBITEMMASTER LEFT OUTER JOIN BATCHMASTER ON SUBITEMMASTER.item_id = BATCHMASTER.JOBBATCH_SUBITEMID RIGHT OUTER JOIN ITEMMASTER_BOMDETAILS ON SUBITEMMASTER.item_id = ITEMMASTER_BOMDETAILS.ITEM_SUBITEMID RIGHT OUTER JOIN ITEMMASTER ON ITEMMASTER_BOMDETAILS.ITEM_ID = ITEMMASTER.item_id RIGHT OUTER JOIN ALLORDERMASTER_DESC ON ITEMMASTER.item_id = ALLORDERMASTER_DESC.ORDER_ITEMID RIGHT OUTER JOIN ALLORDERMASTER ON ALLORDERMASTER_DESC.ORDER_NO = ALLORDERMASTER.ORDER_NO AND ALLORDERMASTER_DESC.ORDER_YEARID = ALLORDERMASTER.ORDER_YEARID", " AND ALLORDERMASTER.ORDER_NO = " & Val(DT.Rows(0).Item("ORDERNO")) & " AND ALLORDERMASTER_DESC.ORDER_GRIDSRNO = " & Val(DT.Rows(0).Item("ORDERSRNO")) & "  AND ALLORDERMASTER_DESC.TYPE = '" & DT.Rows(0).Item("ORDERTYPE") & "'  And ALLORDERMASTER.ORDER_YEARID = " & YearId & "  ORDER BY ALLORDERMASTER.ORDER_NO")
                ' Dim DTSO As DataTable = OBJCMN.search("*", "", "(Select DISTINCT ORDER_NO As ORDERNO, ORDER_GRIDSRNO As ORDERSRNO, BOMITEMMASTER.ITEM_CODE As BOMITEMCODE, BOMITEMMASTER.ITEM_NAME As BOMITEMNAME, ORDERMASTER_DESC.ORDER_YEARID As YEARID FROM ORDERMASTER_DESC INNER JOIN ITEMMASTER On ORDER_ITEMID = ITEMMASTER.ITEM_ID INNER JOIN ITEMMASTER_BOMDETAILS On ITEMMASTER.item_id = ITEMMASTER_BOMDETAILS.ITEM_ID INNER JOIN ITEMMASTER As BOMITEMMASTER On ITEMMASTER_BOMDETAILS.ITEM_SUBITEMID = BOMITEMMASTER.ITEM_ID WHERE ORDER_YEARID = 15 ) As FINALORDER WHERE Not EXISTS ( Select * FROM ( Select DISTINCT ORDERNO, ORDERSRNO, MAINITEMCODE, MAINITEMNAME, MAINITEMID, YEARID FROM ( Select DISTINCT ORDER_NO As ORDERNO, ORDER_GRIDSRNO As ORDERSRNO, ITEMMASTER.ITEM_CODE As MAINITEMCODE, ITEMMASTER.ITEM_NAME As MAINITEMNAME, ITEMMASTER.ITEM_ID As MAINITEMID, BOMITEMMASTER.ITEM_CODE As BOMITEMCODE, BOMITEMMASTER.ITEM_NAME As BOMITEMNAME, BOMITEMMASTER.ITEM_ID As BOMITEMID, ORDERMASTER_DESC.ORDER_YEARID As YEARID FROM ORDERMASTER_DESC INNER JOIN ITEMMASTER On ORDER_ITEMID = ITEMMASTER.ITEM_ID INNER JOIN ITEMMASTER_BOMDETAILS On ITEMMASTER.item_id = ITEMMASTER_BOMDETAILS.ITEM_ID INNER JOIN ITEMMASTER As BOMITEMMASTER On ITEMMASTER_BOMDETAILS.ITEM_SUBITEMID = BOMITEMMASTER.ITEM_ID WHERE ORDER_YEARID = 15) As [ORDERMASTER] WHERE Not EXISTS  (Select jobbatch_no As JOBNO, JOBBATCH_ORDERNO As SONO, JOBBATCH_ORDERSRNO As SOSRNO, jobbatch_itemid As MAINTIEMID, JOBBATCH_SUBITEMID As BOMITEMID, jobbatch_yearid As YEARID FROM BATCHMASTER As JOB WHERE jobbatch_yearid = 15 And jobbatch_madeqty > 0 And JOBBATCH_ORDERNO = ORDERMASTER.ORDERNO And JOB.JOBBATCH_ORDERSRNO = ORDERMASTER.ORDERSRNO And jobbatch_itemid = ORDERMASTER.MAINITEMID And JOBBATCH_SUBITEMID = ORDERMASTER.BOMITEMID And jobbatch_yearid = ORDERMASTER.YEARID) ) As INCOMPLETEORDER WHERE  FINALORDER.ORDERNO = INCOMPLETEORDER.ORDERNO And FINALORDER.ORDERSRNO = INCOMPLETEORDER.ORDERSRNO And FINALORDER.YEARID = INCOMPLETEORDER.YEARID ) ", " And ALLORDERMASTER.ORDER_NO = " & Val(DT.Rows(0).Item("ORDERNO")) & " And ALLORDERMASTER_DESC.ORDER_GRIDSRNO = " & Val(DT.Rows(0).Item("ORDERSRNO")) & "  And ALLORDERMASTER_DESC.TYPE = " & Val(DT.Rows(0).Item("ORDERTYPE")) & " And ALLORDERMASTER.ORDER_YEARID = " & YearId & "  ORDER BY ALLORDERMASTER.ORDER_NO")
                ' Dim DTSO As DataTable = OBJCMN.search("  ISNULL(BATCHMASTER.jobbatch_madeqty, 0) AS BATCHQTY, ISNULL(BATCHMASTER.jobbatch_no, 0) AS BATCHNO, ISNULL(COALESCE(SUBITEMMATSER.item_code, ITEMMASTER.item_code),'')  AS SUBITEMCODE, ISNULL(COALESCE(SUBITEMMATSER.item_name, ITEMMASTER.item_name),'')  AS SUBITEMNAME ,ISNULL(BATCHMASTER.jobbatch_docketno, 0) AS GRIDJOBDOCKETNO, ISNULL(BATCHMASTER.jobbatch_totalshippers, 0)  AS SHIPPERS  ", "", " BATCHMASTER INNER JOIN ALLORDERMASTER_DESC INNER JOIN ALLORDERMASTER ON ALLORDERMASTER_DESC.ORDER_NO = ALLORDERMASTER.ORDER_NO AND ALLORDERMASTER_DESC.ORDER_YEARID = ALLORDERMASTER.ORDER_YEARID AND ALLORDERMASTER_DESC.TYPE = ALLORDERMASTER.TYPE ON BATCHMASTER.JOBBATCH_ORDERNO = ALLORDERMASTER_DESC.ORDER_NO AND BATCHMASTER.JOBBATCH_ORDERSRNO = ALLORDERMASTER_DESC.ORDER_GRIDSRNO AND BATCHMASTER.jobbatch_yearid = ALLORDERMASTER_DESC.ORDER_YEARID LEFT OUTER JOIN ITEMMASTER ON BATCHMASTER.jobbatch_itemid = ITEMMASTER.item_id LEFT OUTER JOIN ITEMMASTER AS SUBITEMMATSER ON BATCHMASTER.JOBBATCH_SUBITEMID = SUBITEMMATSER.item_id ", " AND ALLORDERMASTER.ORDER_NO = " & Val(DT.Rows(0).Item("ORDERNO")) & " AND ALLORDERMASTER_DESC.ORDER_GRIDSRNO = " & Val(DT.Rows(0).Item("ORDERSRNO")) & "  AND ALLORDERMASTER_DESC.TYPE = '" & DT.Rows(0).Item("ORDERTYPE") & "'  And ALLORDERMASTER.ORDER_YEARID = " & YearId & " AND  BATCHMASTER.jobbatch_no NOT IN (SELECT AS_GRIDBATCHNO FROM ASSEMBLYQC_DESC WHERE AS_YEARID=" & YearId & ") ORDER BY ALLORDERMASTER.ORDER_NO")
                '  Dim DTSO As DataTable = OBJCMN.search("  ISNULL(BATCHMASTER.jobbatch_madeqty - JOBBATCHMASTER.JOB_ASSEMBLYQTY, 0) AS BATCHQTY, ISNULL(BATCHMASTER.jobbatch_no, 0) AS BATCHNO, ISNULL(COALESCE (SUBITEMMATSER.item_code, ITEMMASTER.item_code), '') AS SUBITEMCODE,  ISNULL(COALESCE (SUBITEMMATSER.item_name, ITEMMASTER.item_name), '') AS SUBITEMNAME, ISNULL(BATCHMASTER.jobbatch_docketno, 0) AS GRIDJOBDOCKETNO, ISNULL(BATCHMASTER.jobbatch_totalshippers, 0)  AS SHIPPERS ", "", " BATCHMASTER INNER JOIN ALLORDERMASTER_DESC INNER JOIN ALLORDERMASTER ON ALLORDERMASTER_DESC.ORDER_NO = ALLORDERMASTER.ORDER_NO AND ALLORDERMASTER_DESC.ORDER_YEARID = ALLORDERMASTER.ORDER_YEARID AND  ALLORDERMASTER_DESC.TYPE = ALLORDERMASTER.TYPE ON BATCHMASTER.JOBBATCH_ORDERNO = ALLORDERMASTER_DESC.ORDER_NO AND BATCHMASTER.JOBBATCH_ORDERSRNO = ALLORDERMASTER_DESC.ORDER_GRIDSRNO AND BATCHMASTER.jobbatch_yearid = ALLORDERMASTER_DESC.ORDER_YEARID LEFT OUTER JOIN JOBBATCHMASTER ON BATCHMASTER.jobbatch_docketno = JOBBATCHMASTER.job_no LEFT OUTER JOIN ITEMMASTER ON BATCHMASTER.jobbatch_itemid = ITEMMASTER.item_id LEFT OUTER JOIN ITEMMASTER AS SUBITEMMATSER ON BATCHMASTER.JOBBATCH_SUBITEMID = SUBITEMMATSER.item_id", " AND BATCHMASTER.jobbatch_madeqty - JOBBATCHMASTER.JOB_ASSEMBLYQTY > 0 AND ALLORDERMASTER.ORDER_NO = " & Val(DT.Rows(0).Item("ORDERNO")) & " AND ALLORDERMASTER_DESC.ORDER_GRIDSRNO = " & Val(DT.Rows(0).Item("ORDERSRNO")) & "  AND ALLORDERMASTER_DESC.TYPE = '" & DT.Rows(0).Item("ORDERTYPE") & "'  And ALLORDERMASTER.ORDER_YEARID = " & YearId & " ORDER BY ALLORDERMASTER.ORDER_NO")
                Dim DTSO As DataTable = OBJCMN.search(" ISNULL(BATCHMASTER.jobbatch_madeqty - BATCHMASTER.JOBBATCH_ASSEMBLYOUTQTY, 0) AS BATCHQTY, ISNULL(BATCHMASTER.jobbatch_no, 0) AS BATCHNO, ISNULL(COALESCE(SUBITEMMATSER.item_code, ITEMMASTER.item_code),'')  AS SUBITEMCODE, ISNULL(COALESCE(SUBITEMMATSER.item_name, ITEMMASTER.item_name),'')  AS SUBITEMNAME ,ISNULL(BATCHMASTER.jobbatch_docketno, 0) AS GRIDJOBDOCKETNO, ISNULL(BATCHMASTER.jobbatch_totalshippers, 0)  AS SHIPPERS   ", "", " BATCHMASTER INNER JOIN ALLORDERMASTER_DESC INNER JOIN ALLORDERMASTER ON ALLORDERMASTER_DESC.ORDER_NO = ALLORDERMASTER.ORDER_NO AND ALLORDERMASTER_DESC.ORDER_YEARID = ALLORDERMASTER.ORDER_YEARID AND ALLORDERMASTER_DESC.TYPE = ALLORDERMASTER.TYPE ON BATCHMASTER.JOBBATCH_ORDERNO = ALLORDERMASTER_DESC.ORDER_NO AND BATCHMASTER.JOBBATCH_ORDERSRNO = ALLORDERMASTER_DESC.ORDER_GRIDSRNO AND BATCHMASTER.jobbatch_yearid = ALLORDERMASTER_DESC.ORDER_YEARID LEFT OUTER JOIN ITEMMASTER ON BATCHMASTER.jobbatch_itemid = ITEMMASTER.item_id LEFT OUTER JOIN ITEMMASTER AS SUBITEMMATSER ON BATCHMASTER.JOBBATCH_SUBITEMID = SUBITEMMATSER.item_id  ", " AND ALLORDERMASTER.ORDER_NO = " & Val(DT.Rows(0).Item("ORDERNO")) & " AND ALLORDERMASTER_DESC.ORDER_GRIDSRNO = " & Val(DT.Rows(0).Item("ORDERSRNO")) & "  AND ALLORDERMASTER_DESC.TYPE = '" & DT.Rows(0).Item("ORDERTYPE") & "'  And ALLORDERMASTER.ORDER_YEARID = " & YearId & " AND (BATCHMASTER.jobbatch_madeqty - BATCHMASTER.JOBBATCH_ASSEMBLYOUTQTY) > 0 ORDER BY ALLORDERMASTER.ORDER_NO")



                If DTSO.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DTSO.Rows
                        GRIDASSEMBLY.Rows.Add(0, DTROW("SUBITEMCODE").ToString, DTROW("SUBITEMNAME").ToString, DTROW("BATCHQTY").ToString, DTROW("BATCHNO").ToString, Val(DTROW("GRIDJOBDOCKETNO")), "", 0)

                        If MIN = 0 Then
                            MIN = Val(DTROW("BATCHQTY"))
                            BATCHNO = Val(DTROW("BATCHNO"))
                        Else
                            If MIN > Val(DTROW("BATCHQTY").ToString) Then
                                MIN = DTROW("BATCHQTY").ToString
                                BATCHNO = Val(DTROW("BATCHNO"))
                            End If
                        End If
                    Next
                    ' TXTQTY.Text = Val(MIN)
                    TXTBATCHNO.Text = Val(BATCHNO)


                    Dim DT1 As DataTable = OBJCMN.search("  ISNULL(jobbatch_packetitem1, 0) AS PACKETITEM1, ISNULL(jobbatch_packetitem2, 0) AS PACKETITEM2, ISNULL(jobbatch_packetitem3, 0) AS PACKETITEM3, ISNULL(jobbatch_packet1, 0) AS PACKET1, ISNULL(jobbatch_packet2, 0) AS PACKET2, ISNULL(jobbatch_packet3, 0) AS PACKET3, ISNULL(jobbatch_totalpackets, '') AS TOTALPACKET, ISNULL(jobbatch_shipperitem1, 0) AS SHIPPERITEM1, ISNULL(jobbatch_shipperitem2, 0) AS SHIPPERITEM2, ISNULL(jobbatch_shipperitem3, 0) AS SHIPPERITEM3, ISNULL(jobbatch_shipper1, 0) AS SHIPPER1, ISNULL(jobbatch_shipper2, 0) AS SHIPPER2, ISNULL(jobbatch_shipper3, 0) AS SHIPPER3, ISNULL(jobbatch_totalshippers, '') AS TOTALSHIPPER ", "", " BATCHMASTER", " AND BATCHMASTER.jobbatch_no = " & Val(BATCHNO) & " And BATCHMASTER.jobbatch_yearid = " & YearId & " ")
                    If DT1.Rows.Count > 0 Then
                        txtpacketitem1.Text = DT1.Rows(0).Item("PACKETITEM1")
                        txtpacketitem2.Text = DT1.Rows(0).Item("PACKETITEM2")
                        txtpacketitem3.Text = DT1.Rows(0).Item("PACKETITEM3")

                        txtpacket1.Text = DT1.Rows(0).Item("PACKET1")
                        txtpacket2.Text = DT1.Rows(0).Item("PACKET2")
                        txtpacket3.Text = DT1.Rows(0).Item("PACKET3")
                        txttotalpacket.Text = DT1.Rows(0).Item("TOTALPACKET")

                        txtshipperitem1.Text = DT1.Rows(0).Item("SHIPPERITEM1")
                        txtshipperitem2.Text = DT1.Rows(0).Item("SHIPPERITEM2")
                        txtshipperitem3.Text = DT1.Rows(0).Item("SHIPPERITEM3")

                        txtshipper1.Text = DT1.Rows(0).Item("SHIPPER1")
                        txtshipper2.Text = DT1.Rows(0).Item("SHIPPER2")
                        txtshipper3.Text = DT1.Rows(0).Item("SHIPPER3")
                        txttotalshipper.Text = DT1.Rows(0).Item("TOTALSHIPPER")
                        FILLTOTAL()


                    End If

                End If

                getsrno(GRIDASSEMBLY)
                TOTAL()
                FILLTOTAL()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In GRIDASSEMBLY.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDEXIT_Click(sender As Object, e As EventArgs) Handles CMDEXIT.Click
        Me.Close()

    End Sub

    Sub getmax_ASSEMBLY_no()
        Dim dttable As DataTable
        dttable = getmax("ISNULL(MAX(AS_NO), 0) + 1", "ASSEMBLYQC", " And AS_CMPID = " & CmpId & " And AS_YEARID = " & YearId)
        If dttable.Rows.Count > 0 Then
            TXTASSYNO.Text = dttable(0).Item(0)
        End If
    End Sub


    Private Sub CMBNAME_Enter(sender As Object, e As EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " And GroupMaster.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validated(sender As Object, e As EventArgs) Handles tstxtbillno.Validated
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDASSEMBLY.RowCount = 0
                TEMPASSEMBLYNO = Val(tstxtbillno.Text)
                If TEMPASSEMBLYNO > 0 Then
                    edit = True
                    AssemblyQc_Load(sender, e)
                Else
                    CLEAR()
                    edit = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    'Private Sub GRIDASSEMBLY_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDASSEMBLY.KeyDown
    '    Try
    '        If e.KeyCode = Keys.Delete And GRIDASSEMBLY.RowCount > 0 Then
    '            If GRIDDOUBLECLICK = True Then
    '                MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
    '                Exit Sub
    '            End If
    '            GRIDASSEMBLY.Rows.RemoveAt(GRIDASSEMBLY.CurrentRow.Index)
    '            TOTAL()
    '            getsrno(GRIDASSEMBLY)
    '        ElseIf e.KeyCode = Keys.F5 Then
    '            ' EDITROW()
    '        End If
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub

    Private Sub TXTQTY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTQTY.KeyPress, TXTQCGSM.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTPERCENTAGE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTPERCENTAGE.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Sub TOTAL()
        Try
            LBLTOTALQTY.Text = 0.0
            GRIDSUMM.RowCount = 0
            Dim DONE As Boolean = False
            Dim MIN As Integer = 0


            For Each ROW As DataGridViewRow In GRIDASSEMBLY.Rows
                DONE = False
                If ROW.Cells(GSRNO.Index).Value <> Nothing Then
                    LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0.00")

                    If Val(ROW.Cells(GGRIDJOBDOCKETNO.Index).EditedFormattedValue) > 0 Then
                        If GRIDSUMM.RowCount = 0 Then
                            GRIDSUMM.Rows.Add(ROW.Cells(GGRIDJOBDOCKETNO.Index).Value, Format(Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0.00"), ROW.Cells(GBATCHNO.Index).Value)
                        Else
                            For Each SUMMROW As DataGridViewRow In GRIDSUMM.Rows
                                If SUMMROW.Cells(SJOBDOCKETNO.Index).Value = ROW.Cells(GGRIDJOBDOCKETNO.Index).Value Then
                                    SUMMROW.Cells(SQTY.Index).Value = Format(Val(SUMMROW.Cells(SQTY.Index).EditedFormattedValue) + Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0.00")
                                    DONE = True
                                End If

                            Next
                            If DONE = False Then GRIDSUMM.Rows.Add(ROW.Cells(GGRIDJOBDOCKETNO.Index).Value, Format(Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0.00"))
                        End If
                    End If

                End If
            Next
            For Each SUMMROW As DataGridViewRow In GRIDSUMM.Rows

                If MIN = 0 Then
                    MIN = Val(SUMMROW.Cells(SQTY.Index).EditedFormattedValue)
                Else
                    If MIN > Val(SUMMROW.Cells(SQTY.Index).EditedFormattedValue) Then
                        MIN = Val(SUMMROW.Cells(SQTY.Index).EditedFormattedValue)
                    End If
                End If
                TXTQTY.Text = Val(MIN)
            Next



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLTOTAL()

        txttotalpacket.Text = Val(txtpacket1.Text) + Val(txtpacket2.Text) + Val(txtpacket3.Text)
        txtpackettotal1.Text = Val(txtpacketitem1.Text) * Val(txtpacket1.Text)
        txtpackettotal2.Text = Val(txtpacketitem2.Text) * Val(txtpacket2.Text)
        txtpackettotal3.Text = Val(txtpacketitem3.Text) * Val(txtpacket3.Text)
        txtptotal.Text = Val(txtpackettotal1.Text) + Val(txtpackettotal2.Text) + Val(txtpackettotal3.Text)

        txttotalshipper.Text = Val(txtshipper1.Text) + Val(txtshipper2.Text) + Val(txtshipper3.Text)
        txtshippertotal1.Text = Val(txtshipperitem1.Text) * Val(txtshipper1.Text)
        txtshippertotal2.Text = Val(txtshipperitem2.Text) * Val(txtshipper2.Text)
        txtshippertotal3.Text = Val(txtshipperitem3.Text) * Val(txtshipper3.Text)

        txtstotal.Text = Val(txtshippertotal1.Text) + Val(txtshippertotal2.Text) + Val(txtshippertotal3.Text)

    End Sub

    Private Sub AssemblyQc_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then CMDOK_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.F8 Then
                GRIDASSEMBLY.Focus()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1) Then       'for CLEAR
                TabControl1.SelectedIndex = (0)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2) Then       'for CLEAR
                TabControl1.SelectedIndex = (1)
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call TOOLPREVIOUS_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call TOOLNEXT_Click(sender, e)
            ElseIf e.KeyCode = Windows.Forms.Keys.F1 And e.Alt = True Then
                Call OpenToolStripButton_Click(sender, e)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub txtpacket1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpacket1.Validating
        Try
            If Val(txtpacketitem1.Text) > 0 And Val(txtpacket1.Text) > 0 Then
                txtpackettotal1.Text = Val(txtpacketitem1.Text) * Val(txtpacket1.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpacket2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpacket2.Validating
        Try
            If Val(txtpacketitem2.Text) <> "0" And Val(txtpacket2.Text) <> "0" Then
                txtpackettotal2.Text = Val(txtpacketitem2.Text) * Val(txtpacket2.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpacket3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpacket3.Validating
        Try
            If Val(txtpacketitem3.Text) <> "0" And Val(txtpacket3.Text) <> "0" Then
                txtpackettotal3.Text = Val(txtpacketitem3.Text) * Val(txtpacket3.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpacketitem1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpacketitem1.Validating
        Try
            If Val(txtpacketitem1.Text) <> "0" And Val(txtpacket1.Text) <> "0" Then
                txtpackettotal1.Text = Val(txtpacketitem1.Text) * Val(txtpacket1.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpacketitem2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpacketitem2.Validating
        Try
            If Val(txtpacketitem2.Text) <> "0" And Val(txtpacket2.Text) <> "0" Then
                txtpackettotal2.Text = Val(txtpacketitem2.Text) * Val(txtpacket2.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpacketitem3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpacketitem3.Validating
        Try
            If Val(txtpacketitem3.Text) <> "0" And Val(txtpacket3.Text) <> "0" Then
                txtpackettotal3.Text = Val(txtpacketitem3.Text) * Val(txtpacket3.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub txtshipperitem1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtshipperitem1.Validating
        Try
            If Val(txtshipperitem1.Text) <> "0" And Val(txtshipper1.Text) <> "0" Then
                txtshippertotal1.Text = Val(txtshipperitem1.Text) * Val(txtshipper1.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtshipperitem2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtshipperitem2.Validating
        Try
            If Val(txtshipperitem2.Text) <> "0" And Val(txtshipper2.Text) <> "0" Then
                txtshippertotal2.Text = Val(txtshipperitem2.Text) * Val(txtshipper2.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PRINTTOOLSTRIP_Click(sender As Object, e As EventArgs) Handles PRINTTOOLSTRIP.Click
        Try
            If edit = True Then PRINTREPORT(TEMPASSEMBLYNO)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    Sub PRINTREPORT(ByVal ASSEMBLYNO As Integer)
        Try
            If MsgBox("Wish to Print AssemblyQc?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim OBJGDN As New ChallanDesign
                OBJGDN.MdiParent = MDIMain
                OBJGDN.FRMSTRING = "ASSEMBLYQC"
                OBJGDN.WHERECLAUSE = "{ASSEMBLYQC.AS_NO}=" & Val(ASSEMBLYNO) & "  and {ASSEMBLYQC.AS_YEARID}=" & YearId
                OBJGDN.Show()
            End If

            If MsgBox("Wish to Print QC Report?", MsgBoxStyle.YesNo) = vbYes Then
                Dim OBJINVOICE As New SaleInvoiceDesign
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.FRMSTRING = "ASSEMBLYQC"
                OBJINVOICE.WHERECLAUSE = "{ASSEMBLYQC.AS_NO}=" & Val(ASSEMBLYNO) & "  and {ASSEMBLYQC.AS_YEARID}=" & YearId
                OBJINVOICE.Show()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub txtshipperitem3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtshipperitem3.Validating
        Try
            If Val(txtshipperitem3.Text) <> "0" And Val(txtshipper3.Text) <> "0" Then
                txtshippertotal3.Text = Val(txtshipperitem3.Text) * Val(txtshipper3.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtshipper1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtshipper1.Validating
        Try
            If Val(txtshipperitem1.Text) <> "0" And Val(txtshipper1.Text) <> "0" Then
                txtshippertotal1.Text = Val(txtshipperitem1.Text) * Val(txtshipper1.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtshipper2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtshipper2.Validating
        Try
            If Val(txtshipperitem2.Text) <> "0" And Val(txtshipper2.Text) <> "0" Then
                txtshippertotal2.Text = Val(txtshipperitem2.Text) * Val(txtshipper2.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtshipper3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtshipper3.Validating
        Try
            If Val(txtshipperitem3.Text) <> "0" And Val(txtshipper3.Text) <> "0" Then
                txtshippertotal3.Text = Val(txtshipperitem3.Text) * Val(txtshipper3.Text)
                FILLTOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class