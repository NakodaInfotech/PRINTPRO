
Imports BL
Imports System.Windows.Forms
Imports System.Data
Imports System.ComponentModel

Public Class ItemMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim IntResult As Integer
    Public EDIT As Boolean
    Public TEMPITEMNAME As String

    Public TEMPFILENO As String
    Public TEMPITEMCODE As String
    Public TEMPITEMID As Integer
    Public frmstring As String
    Dim TEMPUPLOADROW As Integer
    Dim TEMPBOMROW As Integer
    Dim gridUPLOADDoubleClick As Boolean
    Dim GRIDBOMDOUBLECLICK As Boolean


    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        txtitemcode.Focus()
    End Sub

    Sub CLEAR()

        txtitemcode.Clear()
        txtfileno.Clear()
        cmbitemname.Text = ""
        CMBSUBITEM.Text = ""
        CMBHSNCODE.Text = ""
        cmbcoordinator.Text = ""
        txtartist.Clear()
        txtlinks.Clear()
        txtfonts.Clear()
        txtsoftware.Clear()
        CMBPAPERGSM.Text = ""
        txtscreen.Clear()
        cmbcolor.Text = ""
        txtactualsizewidth.Clear()
        txtactualsizeheight.Clear()
        cmbdesign.Text = ""
        txtpharmacode.Clear()
        txtsizefoldingwidth.Clear()
        txtsizefoldingheight.Clear()
        txtvarnish.Clear()
        cmbmaterial.Text = ""
        txtcutsize.Clear()
        txtvertical.Clear()
        txthorizontal.Clear()
        txtups.Clear()
        CMBPAPERSIZE.Text = ""
        txtrepeatlength.Clear()
        cmbgrain.Text = ""
        CMBTAPETYPE.Text = ""
        CMBSIDE.SelectedIndex = 0
        rbleaflet.Checked = True
        rbcarton.Checked = False
        RBMEDGUIDE.Checked = False

        Ep.Clear()

        CHKPROOFSEND.Checked = False
        PROOFSENDDATE.Clear()
        CHKPROOFOK.Checked = False
        PROOFOKDATE.Clear()
        CHKPERFORATION.Checked = False
        CHKSHADEAPPROVE.Checked = False
        CHK2DCODE.Checked = False
        SHADESENDDATE.Clear()
        CHKSHADECARD.Checked = False
        SHADEAPPDATE.Clear()
        SHADEVALIDTILL.Clear()
        POSITIVESENTDATE.Clear()
        POSITIVERECDDATE.Clear()

        TXTKNIFE.Clear()
        TXTMATERIALCODE.Clear()
        CHKFOLDED.Checked = False

        gridUPLOADDoubleClick = False

        TXTUPLOADSRNO.Text = 1
        txtuploadremarks.Clear()
        txtuploadname.Clear()
        PBSOFTCOPY.Image = Nothing
        TXTIMGPATH.Clear()

        gridupload.RowCount = 0

        TabControl1.SelectedIndex = 0

        ARTWORKDATE.Clear()
        txtartwork.Clear()
        txtremarks.Clear()
        GRIDBOMDETAILS.RowCount = 0
        CHKBLOCKED.CheckState = CheckState.Unchecked

        CMBNAME.Text = ""



    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try

            ' IF ANY CHANGES DONE HERE PLEASE CHANGE ON MDI UPLOAD ITEM SECTION 
            ' UTILITIES > UPLOAD ITEM

            Cursor.Current = Cursors.WaitCursor
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList


            alParaval.Add(UCase(txtitemcode.Text.Trim))
            alParaval.Add(txtfileno.Text.Trim)
            alParaval.Add(UCase(cmbitemname.Text.Trim))
            alParaval.Add(CMBHSNCODE.Text.Trim)

            If rbleaflet.Checked = True Then
                alParaval.Add("Leaflet")
            ElseIf rbcarton.Checked = True Then
                alParaval.Add("Carton")
            Else
                alParaval.Add("Medguide")
            End If

            If CHKPROOFSEND.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If
            alParaval.Add(PROOFSENDDATE.Text.Trim)

            If CHKPROOFOK.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If
            alParaval.Add(PROOFOKDATE.Text.Trim)

            If CHKPERFORATION.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If


            If CHKSHADECARD.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If
            alParaval.Add(SHADESENDDATE.Text.Trim)

            If CHKSHADEAPPROVE.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If
            alParaval.Add(SHADEAPPDATE.Text.Trim)
            alParaval.Add(SHADEVALIDTILL.Text.Trim)


            alParaval.Add(cmbcoordinator.Text.Trim)
            alParaval.Add(txtartist.Text.Trim)
            alParaval.Add(txtlinks.Text.Trim)
            alParaval.Add(txtfonts.Text.Trim)
            alParaval.Add(txtsoftware.Text.Trim)
            alParaval.Add(CMBPAPERGSM.Text.Trim)
            alParaval.Add(txtscreen.Text.Trim)
            alParaval.Add(cmbcolor.Text.Trim)
            alParaval.Add(txtactualsizewidth.Text.Trim)
            alParaval.Add(txtactualsizeheight.Text.Trim)
            alParaval.Add(cmbdesign.Text.Trim)
            alParaval.Add(txtpharmacode.Text.Trim)
            alParaval.Add(txtsizefoldingwidth.Text.Trim)
            alParaval.Add(txtsizefoldingheight.Text.Trim)
            alParaval.Add(txtvarnish.Text.Trim)
            alParaval.Add(cmbmaterial.Text.Trim)
            alParaval.Add(txtcutsize.Text.Trim)
            alParaval.Add(txtvertical.Text.Trim)
            alParaval.Add(txthorizontal.Text.Trim)
            alParaval.Add(Val(txtups.Text.Trim))
            alParaval.Add(CMBPAPERSIZE.Text.Trim)
            alParaval.Add(txtrepeatlength.Text.Trim)
            alParaval.Add(cmbgrain.Text.Trim)
            alParaval.Add(Val(TXTKNIFE.Text.Trim))
            alParaval.Add(TXTMATERIALCODE.Text.Trim)
            alParaval.Add(CMBTAPETYPE.Text.Trim)
            alParaval.Add(CMBSIDE.Text.Trim)
            alParaval.Add(ARTWORKDATE.Text.Trim)
            alParaval.Add(txtartwork.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(POSITIVESENTDATE.Text.Trim)
            alParaval.Add(POSITIVERECDDATE.Text.Trim)

            If CHKFOLDED.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            If CHK2DCODE.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If
            alParaval.Add(CMBMATERIALTYPE.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(CHKBLOCKED.CheckState)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(TXTBOXSIZE.Text.Trim)
            alParaval.Add(TXTBUNDEL.Text.Trim)
            alParaval.Add(TXTBOXQTY.Text.Trim)
            alParaval.Add(TXTTRAYQTY.Text.Trim)


            Dim BOMSRNO As String = ""
            Dim SUBITEM As String = ""

            For Each ROW As DataGridViewRow In GRIDBOMDETAILS.Rows
                If ROW.Cells(GDESC.Index).Value <> Nothing Then
                    If SUBITEM = "" Then
                        BOMSRNO = Val(ROW.Cells(GBOMSRNO.Index).Value)
                        SUBITEM = ROW.Cells(GDESC.Index).Value.ToString
                    Else
                        BOMSRNO = BOMSRNO & "|" & Val(ROW.Cells(GBOMSRNO.Index).Value)
                        SUBITEM = SUBITEM & "|" & ROW.Cells(GDESC.Index).Value.ToString
                    End If
                End If
            Next


            alParaval.Add(BOMSRNO)
            alParaval.Add(SUBITEM)

            Dim objclsItemMaster As New clsItemmaster
            objclsItemMaster.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsItemMaster.save()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPITEMID)
                IntResult = objclsItemMaster.update()
                MsgBox("Details Updated")
            End If

            If gridupload.RowCount > 0 Then SAVEUPLOAD()


            EDIT = False
            CLEAR()
            txtitemcode.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub SAVEUPLOAD()
        Try
            Dim OBJITEM As New clsItemmaster

            For Each ROW As Windows.Forms.DataGridViewRow In gridupload.Rows
                If ROW.Cells(GUSRNO.Index).Value <> Nothing Then
                    Dim MS As New IO.MemoryStream
                    Dim ALPARAVAL As New ArrayList
                    ALPARAVAL.Add(cmbitemname.Text.Trim)
                    ALPARAVAL.Add(ROW.Cells(GUSRNO.Index).Value)
                    ALPARAVAL.Add(ROW.Cells(GUREMARKS.Index).Value)
                    ALPARAVAL.Add(ROW.Cells(GUNAME.Index).Value)

                    PBSOFTCOPY.Image = ROW.Cells(GUIMGPATH.Index).Value
                    PBSOFTCOPY.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                    ALPARAVAL.Add(MS.ToArray)
                    ALPARAVAL.Add(YearId)

                    OBJITEM.alParaval = ALPARAVAL
                    Dim INTRESULT As Integer = OBJITEM.SAVEUPLOAD()
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If txtitemcode.Text.Trim.Length = 0 Then
            Ep.SetError(txtitemcode, "Fill Item Code")
            bln = False
        End If

        If CMBSIDE.Text.Trim = "" Then
            Ep.SetError(CMBSIDE, "Select Side to Print")
            bln = False
        End If

        If cmbitemname.Text.Trim.Length = 0 Then
            Ep.SetError(cmbitemname, "Fill Item Name")
            bln = False
        End If

        If CMBMATERIALTYPE.Text.Trim.Length = 0 Then
            Ep.SetError(CMBMATERIALTYPE, "Fill Material Type")
            bln = False
        End If

        If ClientName <> "GANESHMUDRA" Then
            If txtfileno.Text.Trim.Length = 0 Then
                Ep.SetError(txtfileno, "Fill File No.")
                bln = False
            End If

            If CHKPROOFSEND.Checked = True Then
                If PROOFSENDDATE.Text = "  /  /" Then
                    Ep.SetError(PROOFSENDDATE, "Please Enter Proof Send Date")
                    bln = False
                End If
            End If

            If CHKPROOFOK.Checked = True Then
                If CHKPROOFSEND.Checked = False Then
                    Ep.SetError(CHKPROOFSEND, "Please Check Proof Send First")
                    bln = False
                End If

                If PROOFOKDATE.Text = "  /  /" Then
                    Ep.SetError(PROOFOKDATE, "Please Enter Proof Ok Date")
                    bln = False
                End If
            End If

            If CHKSHADECARD.Checked = True Then
                If SHADESENDDATE.Text = "  /  /" Then
                    Ep.SetError(SHADESENDDATE, "Please Enter Shade Card Send Date")
                    bln = False
                End If
            End If


            If CHKSHADEAPPROVE.Checked = True Then
                If SHADEAPPDATE.Text = "  /  /" Then
                    Ep.SetError(SHADEAPPDATE, "Please Enter Shade Card Approved Date")
                    bln = False
                End If

                If SHADEVALIDTILL.Text = "  /  /" Then
                    Ep.SetError(SHADEVALIDTILL, "Please Fill Shade Card Valid till Date")
                    bln = False
                End If
            End If
        End If



        Return bln
    End Function

    Private Sub cmbdesign_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdesign.Validating
        Try
            If cmbdesign.Text.Trim <> "" Then DESIGNVALIDATE(cmbdesign, e, Me)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ItemMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1) Then       'for CLEAR
            TabControl1.SelectedIndex = (0)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2) Then       'for CLEAR
            TabControl1.SelectedIndex = (1)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub fillcmb()
        Try
            If cmbitemname.Text.Trim = "" Then fillITEMNAME(cmbitemname, EDIT, " and ITEMMASTER.ITEM_MATERIALTYPE = 'FINISHED' ")
            If cmbcoordinator.Text.Trim = "" Then fillCOORDINATOR(cmbcoordinator, EDIT)
            If CMBPAPERGSM.Text.Trim = "" Then fillPAPERGSM(CMBPAPERGSM, EDIT)
            If cmbcolor.Text.Trim = "" Then fillCOLOR(cmbcolor)
            If cmbdesign.Text.Trim = "" Then fillDESIGN(cmbdesign, EDIT)
            If cmbmaterial.Text.Trim = "" Then fillMATERIAL(cmbmaterial, EDIT)
            If CMBPAPERSIZE.Text.Trim = "" Then FILLPAPERSIZE(CMBPAPERSIZE, EDIT)
            If cmbgrain.Text.Trim = "" Then fillGRAIN(cmbgrain, EDIT)
            If CMBTAPETYPE.Text.Trim = "" Then fillTEARTAPE(CMBTAPETYPE, EDIT)
            If CMBHSNCODE.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNCODE)
            If ClientName = "AMR" Then
                If CMBSUBITEM.Text.Trim = "" Then FILLSUBITEMCODE(CMBSUBITEM, EDIT, " and ITEMMASTER.ITEM_MATERIALTYPE = 'RAW MATERIAL' ")
            Else
                If CMBSUBITEM.Text.Trim = "" Then FILLSUBITEMCODE(CMBSUBITEM, EDIT)
            End If
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub FILLHSNITEMDESC(ByRef CMBHSNCODE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" ISNULL(HSN_CODE, '') AS HSNCODE ", "", " HSNMASTER ", " AND HSN_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "HSNCODE"
                CMBHSNCODE.DataSource = dt
                CMBHSNCODE.DisplayMember = "HSNCODE"
                CMBHSNCODE.Text = ""
            End If
            CMBHSNCODE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBHSNCODE.Enter
        Try
            If CMBHSNCODE.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNCODE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ItemMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            Cursor.Current = Cursors.WaitCursor

            fillcmb()
            CLEAR()

            txtitemcode.Text = TEMPITEMCODE
            cmbitemname.Text = TEMPITEMNAME

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim objITEMMASTER As New clsItemmaster
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(TEMPITEMID)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                objITEMMASTER.alParaval = ALPARAVAL
                Dim dttable As DataTable = objITEMMASTER.GETITEM()

                If dttable.Rows.Count > 0 Then
                    For Each DR As DataRow In dttable.Rows

                        txtitemcode.Text = Convert.ToString(DR("ITEMCODE"))
                        TEMPITEMCODE = Convert.ToString(DR("ITEMCODE"))

                        txtfileno.Text = Convert.ToString(DR("FILENO"))
                        TEMPFILENO = Convert.ToString(DR("FILENO"))

                        cmbitemname.Text = Convert.ToString(DR("ITEMNAME"))
                        CMBHSNCODE.Text = DR("HSNCODE").ToString

                        If Convert.ToString(DR("TYPE")) = "Leaflet" Or Convert.ToString(DR("TYPE")) = "1" Then
                            rbleaflet.Checked = True
                        ElseIf Convert.ToString(DR("TYPE")) = "Carton" Or Convert.ToString(DR("TYPE")) = "1" Then
                            rbcarton.Checked = True
                        Else
                            RBMEDGUIDE.Checked = True
                        End If

                        cmbcoordinator.Text = Convert.ToString(DR("COORDINATORNAME"))
                        txtartist.Text = Convert.ToString(DR("ARTIST"))
                        txtlinks.Text = Convert.ToString(DR("LINKS"))
                        txtfonts.Text = Convert.ToString(DR("FONTS"))
                        txtsoftware.Text = Convert.ToString(DR("SOFTWARE"))
                        CMBPAPERGSM.Text = Convert.ToString(DR("PAPERGSM"))
                        txtscreen.Text = Convert.ToString(DR("SCREEN"))
                        cmbcolor.Text = Convert.ToString(DR("COLOR"))
                        txtactualsizewidth.Text = Convert.ToString(DR("ACTUALWIDTH"))
                        txtactualsizeheight.Text = Convert.ToString(DR("ACTUALHEIGHT"))
                        cmbdesign.Text = Convert.ToString(DR("DESIGN"))
                        txtpharmacode.Text = Convert.ToString(DR("PHARMACODE"))
                        txtsizefoldingwidth.Text = Convert.ToString(DR("FOLDWIDTH"))
                        txtsizefoldingheight.Text = Convert.ToString(DR("FOLDHEIGHT"))
                        txtvarnish.Text = Convert.ToString(DR("VARNISH"))
                        cmbmaterial.Text = Convert.ToString(DR("PAPERMATERIALNAME"))
                        txtcutsize.Text = Convert.ToString(DR("CUTSIZE"))
                        txtvertical.Text = Convert.ToString(DR("VERTICAL"))
                        txthorizontal.Text = Convert.ToString(DR("HORIZONTAL"))
                        txtups.Text = Convert.ToString(DR("UPS"))
                        CMBPAPERSIZE.Text = Convert.ToString(DR("PAPERSIZENAME"))
                        txtrepeatlength.Text = Convert.ToString(DR("REPEATLENGTH"))
                        cmbgrain.Text = Convert.ToString(DR("GRAIN"))
                        txtartwork.Text = Convert.ToString(DR("ARTWORK"))
                        txtremarks.Text = Convert.ToString(DR("REMARKS"))
                        CMBTAPETYPE.Text = Convert.ToString(DR("TEARTAPE"))
                        CMBSIDE.Text = DR("SIDEPRINT")
                        TXTKNIFE.Text = Convert.ToString(DR("knifes"))
                        TXTMATERIALCODE.Text = Convert.ToString(DR("MATERIALCODE"))
                        CHKBLOCKED.Checked = Convert.ToBoolean(dttable.Rows(0).Item("BLOCKED"))
                        CMBNAME.Text = Convert.ToString(DR("NAME"))

                        TXTBOXSIZE.Text = Convert.ToString(DR("BOXSIZE"))
                        TXTBUNDEL.Text = Convert.ToString(DR("BUNDEL"))
                        TXTBOXQTY.Text = Val(DR("BOXQTY"))
                        TXTTRAYQTY.Text = Val(DR("TRAYQTY"))

                        If DR("PROOFSEND") = 0 Then
                            CHKPROOFSEND.Checked = False
                        Else
                            CHKPROOFSEND.Checked = True
                        End If
                        PROOFSENDDATE.Text = DR("PROOFSENDDATE")

                        If DR("PROOFOK") = 0 Then
                            CHKPROOFOK.Checked = False
                        Else
                            CHKPROOFOK.Checked = True
                        End If
                        PROOFOKDATE.Text = DR("PROOFOKDATE")

                        If DR("PERFORATION") = 0 Then
                            CHKPERFORATION.Checked = False
                        Else
                            CHKPERFORATION.Checked = True
                        End If

                        If DR("SHADECARD") = 0 Then
                            CHKSHADECARD.Checked = False
                        Else
                            CHKSHADECARD.Checked = True
                        End If
                        SHADESENDDATE.Text = DR("SHADESENDDATE")

                        If DR("SHADEAPPROVE") = 0 Then
                            CHKSHADEAPPROVE.Checked = False
                        Else
                            CHKSHADEAPPROVE.Checked = True
                        End If
                        SHADEAPPDATE.Text = DR("SHADEAPPDATE")

                        SHADEVALIDTILL.Text = DR("SHADEDATE")
                        ARTWORKDATE.Text = DR("ARTWORKDATE")

                        POSITIVESENTDATE.Text = DR("POSITIVESENTDATE")
                        POSITIVERECDDATE.Text = DR("POSITIVERECDDATE")

                        CHK2DCODE.Checked = Convert.ToBoolean(DR("2DCODE"))
                        CMBMATERIALTYPE.Text = Convert.ToString(DR("MATERIALTYPE"))


                    Next

                    '' GRID UPLOAD
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("ISNULL(ITEM_UPSRNO, 0) AS SRNO, ISNULL(ITEM_UPREMARKS, '') AS REMARKS, ISNULL(ITEM_UPNAME, '') AS NAME, ITEM_IMGPATH AS IMGPATH", "", "ITEMMASTER_UPLOAD", "AND ITEMMASTER_UPLOAD.ITEM_ID= " & TEMPITEMID & "  AND ITEM_YEARID = " & YearId & " ORDER BY ITEMMASTER_UPLOAD.ITEM_UPSRNO")
                    If DT.Rows.Count > 0 Then
                        For Each DTR As DataRow In DT.Rows
                            gridupload.Rows.Add(DTR("SRNO"), DTR("REMARKS"), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))))
                        Next
                    End If

                    '' GRID BOM
                    Dim OBJCM As New ClsCommon
                    Dim DT1 As DataTable = OBJCMN.search("ISNULL(ITEMMASTER_BOMDETAILS.ITEM_BOMSRNO, 0) AS BOMSRNO, ISNULL(SUBITEMMASTER.item_code, '') AS SUBITEM", "", "ITEMMASTER_BOMDETAILS INNER JOIN ITEMMASTER ON ITEMMASTER_BOMDETAILS.ITEM_ID = ITEMMASTER.item_id AND ITEMMASTER_BOMDETAILS.ITEM_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN ITEMMASTER AS SUBITEMMASTER ON ITEMMASTER_BOMDETAILS.ITEM_SUBITEMID = SUBITEMMASTER.item_id ", "AND ITEMMASTER_BOMDETAILS.ITEM_ID= " & TEMPITEMID & "  AND ITEMMASTER_BOMDETAILS.ITEM_YEARID = " & YearId & " ORDER BY ITEMMASTER_BOMDETAILS.ITEM_BOMSRNO")
                    If DT1.Rows.Count > 0 Then
                        For Each DTR As DataRow In DT1.Rows
                            GRIDBOMDETAILS.Rows.Add(DTR("BOMSRNO"), DTR("SUBITEM"))
                        Next
                    End If

                End If
            Else
                EDIT = False
                'clear()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then uppercase(cmbitemname)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbmaterial_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbmaterial.Validating
        Try
            If cmbmaterial.Text.Trim <> "" Then MATERIALVALIDATE(cmbmaterial, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbgrain_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbgrain.Validating
        Try
            If cmbgrain.Text.Trim <> "" Then GRAINVALIDATE(cmbgrain, e, Me)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub txtfileno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtfileno.Validating
        Try
            If txtfileno.Text.Trim <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (EDIT = False) Or (EDIT = True And LCase(txtfileno.Text) <> LCase(TEMPFILENO)) Then
                    dt = objclscommon.search("item_FILENO", "", "ItemMaster", " and item_FILENO = '" & txtfileno.Text.Trim & "' And item_yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("File No. Already Exists", MsgBoxStyle.Critical, "PRINTPRO")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtitemcode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtitemcode.Validating
        Try
            If txtitemcode.Text.Trim <> "" Then
                pcase(txtitemcode)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (EDIT = False) Or (EDIT = True And LCase(txtitemcode.Text) <> LCase(TEMPITEMCODE)) Then
                    dt = objclscommon.search("item_CODE", "", "ItemMaster", " and item_CODE = '" & txtitemcode.Text.Trim & "' And item_yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Item Code Already Exists", MsgBoxStyle.Critical, "PRINTPRO")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcoordinator_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcoordinator.Validating
        Try
            If cmbcoordinator.Text.Trim <> "" Then COORDINATORVALIDAT(cmbcoordinator, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtups_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtups.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            If cmbcolor.Text.Trim <> "" Then COLORvalidate(cmbcolor, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbdesign_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdesign.Enter
        Try
            If cmbdesign.Text.Trim = "" Then fillDESIGN(cmbdesign, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtvertical_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvertical.KeyPress
        'Try
        '    numdot(e, txtvertical, Me)
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub txthorizontal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthorizontal.KeyPress
        'Try
        '    numdot(e, txthorizontal, Me)
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    'Private Sub txtrepeatlength_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrepeatlength.KeyPress
    '    Try
    '        numdot(e, txtrepeatlength, Me)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub cmbcolor_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcolor.Enter
        Try
            If cmbcolor.Text.Trim = "" Then fillCOLOR(cmbcolor)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcoordinator_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcoordinator.Enter
        Try
            If cmbcoordinator.Text.Trim = "" Then fillCOORDINATOR(cmbcoordinator, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbmaterial_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbmaterial.Enter
        Try
            If cmbmaterial.Text.Trim = "" Then fillMATERIAL(cmbmaterial, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbgrain_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbgrain.Enter
        Try
            If cmbgrain.Text.Trim = "" Then fillGRAIN(cmbgrain, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPAPERGSM_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPAPERGSM.Validating
        Try
            If CMBPAPERGSM.Text.Trim <> "" Then PAPERGSMVALIDATE(CMBPAPERGSM, e, Me)
            'If CMBPAPERGSM.Text.Trim <> "" Then
            '    pcase(CMBPAPERGSM)
            '    CMBPAPERGSM.Text = CMBPAPERGSM.Text.Trim
            '    Dim objclscommon As New ClsCommonMaster
            '    Dim dt As DataTable
            '    If (EDIT = False) Then
            '        dt = objclscommon.search("PAPERGSM_NAME", "", "PAPERGSMMASTER", " and PAPERGSM_NAME = '" & CMBPAPERGSM.Text.Trim & "' and PAPERGSM_YEARID = " & YearId)
            '        If dt.Rows.Count > 0 Then
            '            MsgBox("PAPERGSM Already Exists")
            '            e.Cancel = True
            '        End If
            '    End If
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPAPERSIZE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPAPERSIZE.Validating
        Try
            If CMBPAPERSIZE.Text.Trim <> "" Then PAPERSIZEVALIDATE(CMBPAPERSIZE, e, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If MsgBox("Wish to Delete Item ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If MsgBox("Are you Sure?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Dim ALPARAVAL As New ArrayList
                        ALPARAVAL.Add(TEMPITEMID)
                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(YearId)

                        Dim OBJITEM As New clsItemmaster
                        OBJITEM.alParaval = ALPARAVAL
                        Dim DT As DataTable = OBJITEM.DELETE()
                        If DT.Rows.Count > 0 Then
                            MsgBox("Item " & DT.Rows(0).Item(0) & " Deleted!")
                        End If
                    End If
                End If
                EDIT = False
                clear()
            Else
                MsgBox("Delete is in Edit Mode Only")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then fillITEMNAME(cmbitemname, EDIT, " and ITEMMASTER.ITEM_MATERIALTYPE = 'FINISHED' ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPAPERGSM_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPAPERGSM.Enter
        Try
            If CMBPAPERGSM.Text.Trim = "" Then fillPAPERGSM(CMBPAPERGSM, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillupload()

        If gridUPLOADDoubleClick = False Then
            gridupload.Rows.Add(Val(TXTUPLOADSRNO.Text.Trim), txtuploadremarks.Text.Trim, txtuploadname.Text.Trim, PBSOFTCOPY.Image)
            getsrno(gridupload)
        ElseIf gridUPLOADDoubleClick = True Then
            gridupload.Item(GUSRNO.Index, TEMPUPLOADROW).Value = Val(TXTUPLOADSRNO.Text.Trim)
            gridupload.Item(GUREMARKS.Index, TEMPUPLOADROW).Value = txtuploadremarks.Text.Trim
            gridupload.Item(GUNAME.Index, TEMPUPLOADROW).Value = txtuploadname.Text.Trim
            gridupload.Item(GUIMGPATH.Index, TEMPUPLOADROW).Value = PBSOFTCOPY.Image

            gridUPLOADDoubleClick = False
        End If
        gridupload.FirstDisplayedScrollingRowIndex = gridupload.RowCount - 1

        TXTUPLOADSRNO.Text = gridupload.RowCount + 1
        txtuploadremarks.Clear()
        txtuploadname.Clear()
        PBSOFTCOPY.Image = Nothing
        TXTIMGPATH.Clear()
        txtuploadremarks.Focus()
    End Sub

    Private Sub CMBPAPERSIZE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBPAPERSIZE.Enter
        Try
            If CMBPAPERSIZE.Text.Trim = "" Then FILLPAPERSIZE(CMBPAPERSIZE, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtuploadname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuploadname.Validating
        Try
            If txtuploadremarks.Text.Trim <> "" And txtuploadname.Text.Trim <> "" And PBSOFTCOPY.ImageLocation <> "" Then
                fillupload()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridupload.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridupload.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If gridUPLOADDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                gridupload.Rows.RemoveAt(gridupload.CurrentRow.Index)
                getsrno(gridupload)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If e.RowIndex >= 0 Then PBSOFTCOPY.Image = gridupload.Rows(e.RowIndex).Cells(GUIMGPATH.Index).Value
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDUPLOAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDUPLOAD.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        TXTIMGPATH.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If TXTIMGPATH.Text.Trim.Length <> 0 Then PBSOFTCOPY.ImageLocation = TXTIMGPATH.Text.Trim
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If gridupload.SelectedRows.Count > 0 Then
                Dim objVIEW As New ViewImage
                objVIEW.pbsoftcopy.Image = PBSOFTCOPY.Image
                objVIEW.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREMOVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREMOVE.Click
        Try
            PBSOFTCOPY.Image = Nothing
            TXTIMGPATH.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTUPLOADSRNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTUPLOADSRNO.GotFocus
        If gridUPLOADDoubleClick = False Then
            If gridupload.RowCount > 0 Then
                TXTUPLOADSRNO.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
            Else
                TXTUPLOADSRNO.Text = 1
            End If
        End If
    End Sub

    Private Sub gridupload_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
        Try
            If e.RowIndex >= 0 And gridupload.Item(GUSRNO.Index, e.RowIndex).Value <> Nothing Then

                gridUPLOADDoubleClick = True
                TXTUPLOADSRNO.Text = gridupload.Item(GUSRNO.Index, e.RowIndex).Value
                txtuploadremarks.Text = gridupload.Item(GUREMARKS.Index, e.RowIndex).Value
                txtuploadname.Text = gridupload.Item(GUNAME.Index, e.RowIndex).Value
                PBSOFTCOPY.Image = gridupload.Item(GUIMGPATH.Index, e.RowIndex).Value

                TEMPUPLOADROW = e.RowIndex
                txtuploadremarks.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTAPETYPE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBTAPETYPE.Enter
        Try
            If CMBTAPETYPE.Text.Trim = "" Then fillTEARTAPE(CMBTAPETYPE, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTAPETYPE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTAPETYPE.Validating
        Try
            If CMBTAPETYPE.Text.Trim <> "" Then TEARTAPEVALIDATE(CMBTAPETYPE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTKNIFE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTKNIFE.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub SHADEVALIDTILL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SHADEVALIDTILL.Validating
        Try
            If SHADEVALIDTILL.Text <> "  /  /" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(SHADEVALIDTILL.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ARTWORKDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ARTWORKDATE.Validating
        Try
            If ARTWORKDATE.Text <> "  /  /" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(ARTWORKDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PROOFSENDDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PROOFSENDDATE.Validating
        Try
            If PROOFSENDDATE.Text <> "  /  /" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(PROOFSENDDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PROOFOKDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PROOFOKDATE.Validating
        Try
            If PROOFOKDATE.Text <> "  /  /" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(PROOFOKDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SHADESENDDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SHADESENDDATE.Validating
        Try
            If SHADESENDDATE.Text <> "  /  /" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(SHADESENDDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SHADEAPPDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SHADEAPPDATE.Validating
        Try
            If SHADEAPPDATE.Text <> "  /  /" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(SHADEAPPDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNCODE_Validating(sender As Object, e As CancelEventArgs) Handles CMBHSNCODE.Validating
        Try
            If CMBHSNCODE.Text.Trim <> "" Then HSNITEMDESCVALIDATE(CMBHSNCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub POSITIVERECDDATE_Validating(sender As Object, e As CancelEventArgs) Handles POSITIVERECDDATE.Validating
        Try
            If POSITIVERECDDATE.Text <> "  /  /" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(POSITIVERECDDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub POSITIVESENTDATE_Validating(sender As Object, e As CancelEventArgs) Handles POSITIVESENTDATE.Validating
        Try
            If POSITIVESENTDATE.Text <> "  /  /" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(POSITIVESENTDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ItemMaster_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "GANESHMUDRA" Then
                'TabControl1.Visible = False
                'TabControl2.Visible = True
                GroupBox2.Visible = False
                GroupBox6.Visible = False
                CHKPERFORATION.Visible = False
                cmbitemname.Enabled = False
            End If

            If ClientName = "AMR" Then
                GroupBox3.Visible = False
            Else
                GroupBox3.Visible = True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtitemcode_Validated(sender As Object, e As EventArgs) Handles txtitemcode.Validated
        Try
            If ClientName = "GANESHMUDRA" And cmbitemname.Text.Trim = "" And txtitemcode.Text.Trim <> "" Then cmbitemname.Text = txtitemcode.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillBOM()

        If GRIDBOMDOUBLECLICK = False Then
            GRIDBOMDETAILS.Rows.Add(Val(TXTBOMSRNO.Text.Trim), CMBSUBITEM.Text)
            getsrno(GRIDBOMDETAILS)
        ElseIf GRIDBOMDOUBLECLICK = True Then
            GRIDBOMDETAILS.Item(GBOMSRNO.Index, TEMPBOMROW).Value = Val(TXTBOMSRNO.Text.Trim)
            GRIDBOMDETAILS.Item(GDESC.Index, TEMPBOMROW).Value = CMBSUBITEM.Text.Trim

            GRIDBOMDOUBLECLICK = False
        End If
        GRIDBOMDETAILS.FirstDisplayedScrollingRowIndex = GRIDBOMDETAILS.RowCount - 1

        TXTBOMSRNO.Text = GRIDBOMDETAILS.RowCount + 1
        CMBSUBITEM.Text = ""
        CMBSUBITEM.Focus()

    End Sub

    Private Sub GRIDBOMDETAILS_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDBOMDETAILS.CellDoubleClick

        Try
            If e.RowIndex >= 0 AndAlso GRIDBOMDETAILS.Item(GBOMSRNO.Index, e.RowIndex).Value <> Nothing Then
                GRIDBOMDOUBLECLICK = True
                TEMPBOMROW = e.RowIndex
                TXTBOMSRNO.Text = Val(GRIDBOMDETAILS.Item(GBOMSRNO.Index, e.RowIndex).Value)
                CMBSUBITEM.Text = GRIDBOMDETAILS.Item(GDESC.Index, e.RowIndex).Value

                CMBSUBITEM.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub GRIDBOMDETAILS_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDBOMDETAILS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDBOMDETAILS.RowCount > 0 Then
                If GRIDBOMDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                GRIDBOMDETAILS.Rows.RemoveAt(GRIDBOMDETAILS.CurrentRow.Index)
                getsrno(GRIDBOMDETAILS)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSUBITEM_Validated(sender As Object, e As EventArgs) Handles CMBSUBITEM.Validated
        Try
            If CMBSUBITEM.Text <> "" Then
                fillBOM()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSUBITEM_Validating(sender As Object, e As CancelEventArgs) Handles CMBSUBITEM.Validating
        Try
            If ClientName = "AMR" Then
                If CMBSUBITEM.Text.Trim <> "" Then SUBITEMCODEVALIDATE(CMBSUBITEM, e, Me, " and ITEMMASTER.ITEM_MATERIALTYPE = 'RAW MATERIAL' ")
                If GRIDBOMDETAILS.RowCount > 0 Then
                    If CMBSUBITEM.Text = GRIDBOMDETAILS.Item(GDESC.Index, TEMPBOMROW).Value Then
                        MsgBox("Sub Item Already Exists", MsgBoxStyle.Critical, "PRINTPRO")
                        e.Cancel = True
                    End If
                End If
            Else
                If CMBSUBITEM.Text.Trim <> "" Then SUBITEMCODEVALIDATE(CMBSUBITEM, e, Me)
                If GRIDBOMDETAILS.RowCount > 0 Then
                    If CMBSUBITEM.Text = GRIDBOMDETAILS.Item(GDESC.Index, TEMPBOMROW).Value Then
                        MsgBox("Sub Item Already Exists", MsgBoxStyle.Critical, "PRINTPRO")
                        e.Cancel = True
                    End If
                End If
            End If


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSUBITEM_Enter(sender As Object, e As EventArgs) Handles CMBSUBITEM.Enter
        Try
            If ClientName = "AMR" Then
                If CMBSUBITEM.Text.Trim = "" Then FILLSUBITEMCODE(CMBSUBITEM, EDIT, " and ITEMMASTER.ITEM_MATERIALTYPE = 'RAW MATERIAL' ")
            Else
                If CMBSUBITEM.Text.Trim = "" Then FILLSUBITEMCODE(CMBSUBITEM, EDIT)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, txtdeladd, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(sender As Object, e As EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, "and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBOXQTY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTBOXQTY.KeyPress, TXTTRAYQTY.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

End Class