
Imports BL
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Net
Imports System.IO

Public Class AccountsMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public frmstring As String        'Used from Displaying Customer, Vendor, Employee Master
    Public edit As Boolean
    Public tempAccountsName As String
    Public TEMPGROUPNAME As String
    Public tempAccountsCode As String
    Public tempTYPE As String = "ACCOUNTS"
    Public tempISAGENT As String = ""
    Public tempISTRANS As String = ""
    Dim tempAccountId As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public TEMPGSTIN As String           'Used for edit name

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub AccountsMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub FILLCMPNAME()
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable = objclscommon.search("acc_cmpname", "", " ACCOUNTSMaster ", " and acc_cmpid = " & CmpId & " and acc_locationid = " & Locationid & " and acc_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "acc_cmpname"
                cmbcmpname.DataSource = dt
                cmbcmpname.DisplayMember = "acc_cmpname"
                cmbcmpname.Text = tempAccountsName
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLCMPCODE()
        Try
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable = objclscommon.search("acc_CODE", "", " ACCOUNTSMaster ", " and acc_cmpid = " & CmpId & " and acc_locationid = " & Locationid & " and acc_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "acc_CODE"
                CMBCODE.DataSource = dt
                CMBCODE.DisplayMember = "acc_CODE"
                CMBCODE.Text = tempAccountsCode
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLCMB()

        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable

        dt = objclscommon.search("area_name", "", "AreaMaster", " and area_cmpid =" & CmpId & " and area_Locationid =" & Locationid & " and area_Yearid =" & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "area_name"
            cmbarea.DataSource = dt
            cmbarea.DisplayMember = "area_name"
            cmbarea.Text = ""
        End If

        dt = objclscommon.search("city_name", "", "CityMaster", " and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "City_name"
            cmbcity.DataSource = dt
            cmbcity.DisplayMember = "city_name"
            cmbcity.Text = ""
        End If

        dt = objclscommon.search("country_name", "", "CountryMaster", " and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "country_name"
            cmbcountry.DataSource = dt
            cmbcountry.DisplayMember = "country_name"
            cmbcountry.Text = ""
        End If

        dt = objclscommon.search("group_name", "", "GroupMaster", " and group_cmpid = " & CmpId & " and group_Locationid = " & Locationid & " and group_Yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "Group_name"
            cmbgroup.DataSource = dt
            cmbgroup.DisplayMember = "group_name"
            cmbgroup.Text = ""
        End If

        dt = objclscommon.search("state_name", "", "StateMaster", " and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "state_name"
            cmbstate.DataSource = dt
            cmbstate.DisplayMember = "state_name"
            cmbstate.Text = ""
        End If

        If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'  AND LEDGERS.ACC_TYPE='TRANSPORT'")
        If CMBGROUPOFCOMPANIES.Text.Trim = "" Then FILLGROUPCOMPANY(CMBGROUPOFCOMPANIES)
        If CMBPARTYBANK.Text = "" Then fillPARTYBANK(CMBPARTYBANK, edit)
        If CMBBANKCITY.Text.Trim = "" Then fillCITY(CMBBANKCITY, edit)
        fillDEDUCTEETYPE(CMBDEDUCTEETYPE)
        If CMBITEMCODE.Text.Trim = "" Then fillITEMCODE(CMBITEMCODE, edit)
        fillname(CMBTDSDEDUCTEDAC, "False", " AND LEDGERS.ACC_TDSAC = 1")

    End Sub

    Private Sub AccountsMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillcmb()
            FILLCMPNAME()
            FILLCMPCODE()
            clear()

            cmbgroup.Text = TEMPGROUPNAME
            CMBTYPE.Text = tempTYPE

            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster

            Dim OBJACC As New ClsAccountsMaster
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(tempAccountsName)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            OBJACC.alParaval = ALPARAVAL
            If edit = True Then dttable = OBJACC.GETACCOUNTS

            If dttable.Rows.Count > 0 Then

                If edit = True Then
                    If USEREDIT = False And USERVIEW = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    If dttable.Rows.Count > 0 Then
                        tempAccountId = Val(dttable.Rows(0).Item("ACCID"))
                        cmbcmpname.Text = dttable.Rows(0).Item("CMPNAME").ToString
                        txtname.Text = dttable.Rows(0).Item("NAME").ToString
                        cmbgroup.Text = dttable.Rows(0).Item("GROUPNAME").ToString

                        'FILLING REGISTER
                        If cmbgroup.Text.Trim <> "" Then
                            'CHECK GROUP_SECONDARY
                            Dim OBJCMN As New ClsCommon
                            Dim DT As DataTable = OBJCMN.search(" GROUP_SECONDARY ", "", " GROUPMASTER ", " AND GROUP_NAME = '" & cmbgroup.Text.Trim & "' AND GROUP_CMPID = " & CmpId & " AND GROUP_LOCATIONID = " & Locationid & " AND GROUP_YEARID = " & YearId)
                            If DT.Rows.Count > 0 Then
                                If DT.Rows(0).Item(0) = "Sundry Creditors" Then
                                    fillregister(cmbregister, " and register_type = 'PURCHASE'")
                                ElseIf DT.Rows(0).Item(0) = "Sundry Debtors" Then
                                    fillregister(cmbregister, " and register_type = 'SALE'")
                                End If
                            End If
                        End If


                        txtopbal.Text = Val(dttable.Rows(0).Item("OPBAL").ToString)
                        cmbdrcrrs.Text = dttable.Rows(0).Item("DRCR").ToString
                        txtadd1.Text = dttable.Rows(0).Item("ADD1").ToString
                        txtadd2.Text = dttable.Rows(0).Item("ADD2").ToString
                        TXTLANDMARK.Text = dttable.Rows(0).Item("LANDMARK").ToString
                        cmbarea.Text = dttable.Rows(0).Item("AREA").ToString
                        'CMBSTREET.Text = dttable.Rows(0).Item("STREET").ToString
                        cmbcity.Text = dttable.Rows(0).Item("CITY").ToString
                        cmbstate.Text = dttable.Rows(0).Item("STATE").ToString
                        txtzipcode.Text = dttable.Rows(0).Item("ZIPCODE").ToString
                        cmbcountry.Text = dttable.Rows(0).Item("COUNTRY").ToString
                        txtstd.Text = dttable.Rows(0).Item("STD").ToString
                        txtresino.Text = dttable.Rows(0).Item("RESINO").ToString
                        txtaltno.Text = dttable.Rows(0).Item("ALTNO").ToString
                        txttel1.Text = dttable.Rows(0).Item("PHONE").ToString
                        txtmobile.Text = dttable.Rows(0).Item("MOBILE").ToString
                        txtfax.Text = dttable.Rows(0).Item("FAX").ToString
                        txtwebsite.Text = dttable.Rows(0).Item("WEBSITE").ToString
                        cmbemail.Text = dttable.Rows(0).Item("EMAIL").ToString
                        CMBTRANS.Text = dttable.Rows(0).Item("TRANS").ToString
                        CMBAGENT.Text = dttable.Rows(0).Item("AGENT").ToString
                        TXTAGENTCOMM.Text = dttable.Rows(0).Item("AGENTCOMM").ToString
                        TXTDISC.Text = dttable.Rows(0).Item("DISC").ToString
                        TXTCDPER.Text = dttable.Rows(0).Item("CDPER").ToString
                        txtcrdays.Text = Val(dttable.Rows(0).Item("CRDAYS").ToString)
                        txtcrlimit.Text = Val(dttable.Rows(0).Item("CRLIMIT").ToString)
                        CMBADDLESS.Text = dttable.Rows(0).Item("ADDLESS").ToString
                        txtpanno.Text = dttable.Rows(0).Item("PANNO").ToString
                        txtexciseno.Text = dttable.Rows(0).Item("EXCISENO").ToString
                        txtrange.Text = dttable.Rows(0).Item("RANGE").ToString
                        txtdivision.Text = dttable.Rows(0).Item("DIVISION").ToString
                        txtcstno.Text = dttable.Rows(0).Item("CSTNO").ToString
                        txttinno.Text = dttable.Rows(0).Item("TINNO").ToString
                        txtstno.Text = dttable.Rows(0).Item("STNO").ToString
                        txtvatno.Text = dttable.Rows(0).Item("VATNO").ToString

                        TXTGSTIN.Text = dttable.Rows(0).Item("GSTIN").ToString
                        TEMPGSTIN = dttable.Rows(0).Item("GSTIN").ToString

                        cmbregister.Text = dttable.Rows(0).Item("REGISTERNAME").ToString
                        TXTSIZETOLERANCE.Text = dttable.Rows(0).Item("SIZETOLERANCE").ToString
                        TXTGSMTOLERANCE.Text = dttable.Rows(0).Item("GSMTOLERANCE").ToString
                        TXTPATTERNTOLERANCE.Text = dttable.Rows(0).Item("PATTERNTOLERANCE").ToString
                        TXTACCESSQUANTITY.Text = dttable.Rows(0).Item("ACCESSQUANTITY").ToString
                        txtadd.Text = dttable.Rows(0).Item("ADD").ToString
                        txtshipadd.Text = dttable.Rows(0).Item("SHIPPINGADD").ToString
                        txtremarks.Text = dttable.Rows(0).Item("REMARKS").ToString

                        CMBGROUPOFCOMPANIES.Text = dttable.Rows(0).Item("GOC").ToString
                        TXTMSMENO.Text = dttable.Rows(0).Item("MSMENO").ToString
                        CMBMSMETYPE.Text = dttable.Rows(0).Item("MSMETYPE").ToString

                        CMBCODE.Text = dttable.Rows(0).Item("CODE").ToString
                        tempAccountsCode = dttable.Rows(0).Item("CODE").ToString

                        CMBPARTYBANK.Text = dttable.Rows(0).Item("PARTYBANKNAME").ToString
                        TXTACCTYPE.Text = dttable.Rows(0).Item("ACCTYPE").ToString
                        TXTACCNO.Text = dttable.Rows(0).Item("ACCNO").ToString
                        TXTIFSC.Text = dttable.Rows(0).Item("IFSCCODE").ToString
                        TXTBRANCH.Text = dttable.Rows(0).Item("BRANCH").ToString
                        CMBBANKCITY.Text = dttable.Rows(0).Item("BANKCITY").ToString


                        CHKRCM.Checked = Convert.ToBoolean(dttable.Rows(0).Item("RCM"))
                        CHKBLOCKED.Checked = Convert.ToBoolean(dttable.Rows(0).Item("BLOCKED"))
                        TXTKMS.Text = Val(dttable.Rows(0).Item("KMS"))
                        TXTDELIVERYPINCODE.Text = dttable.Rows(0).Item("DELIVERYPINCODE")


                        If dttable.Rows(0).Item("DEDUCTEETYPE") <> "" Then
                            CHKTDSAPP.CheckState = CheckState.Checked
                            CMBDEDUCTEETYPE.Text = dttable.Rows(0).Item("DEDUCTEETYPE")
                            If dttable.Rows(0).Item("ISLOWER") = True Then
                                CMBISLOWER.Text = "Yes"
                                CMBSECTION.Enabled = True
                            Else
                                CMBISLOWER.Text = "No"
                            End If
                            CMBSECTION.Text = dttable.Rows(0).Item("SECTION")
                            TXTTDSRATE.Text = Format(Val(dttable.Rows(0).Item("TDSRATE")), "0.00")
                            TXTTDSPER.Text = Format(Val(dttable.Rows(0).Item("TDSPER")), "0.00")
                            If CMBSECTION.Text.Trim = "197" Then
                                TXTTDSRATE.Enabled = True
                            Else
                                TXTTDSRATE.Enabled = False
                            End If
                            If dttable.Rows(0).Item("SURCHARGE") = True Then
                                CMBSURCHARGE.Text = "Yes"
                            Else
                                CMBSURCHARGE.Text = "No"
                            End If
                            TXTLIMIT.Text = dttable.Rows(0).Item("LIMIT")
                        Else
                            CHKTDSAPP.CheckState = CheckState.Unchecked
                        End If

                        CHKTDS.Checked = Convert.ToBoolean(dttable.Rows(0).Item("TDSAC"))
                        CMBSEZTYPE.Text = dttable.Rows(0).Item("SEZTYPE")
                        CMBNATURE.Text = dttable.Rows(0).Item("NATURE")
                        CMBTYPE.Text = dttable.Rows(0).Item("TYPE")

                        CMBTDSDEDUCTEDAC.Text = dttable.Rows(0).Item("TDSDEDUCTEDAC").ToString
                        CMBCALC.Text = dttable.Rows(0).Item("CALC")
                        CHKTCS.Checked = Convert.ToBoolean(dttable.Rows(0).Item("TCS"))
                        CHKPARTYTDS.Checked = Convert.ToBoolean(dttable.Rows(0).Item("PARTYTDS"))
                        CHKTDSONGTOTAL.Checked = Convert.ToBoolean(dttable.Rows(0).Item("TDSONGTOTAL"))

                        If Convert.ToBoolean(dttable.Rows(0).Item("GSTINVERIFIED")) = True Then
                            CHKGSTINVERIFIED.CheckState = CheckState.Checked
                            PBSUCCESS.Visible = True
                        End If

                        CMBTDSFORM.Text = dttable.Rows(0).Item("TDSFORM")
                        CMBTDSCOMPANY.Text = dttable.Rows(0).Item("TDSCOMPANY")
                        TXTINTPER.Text = Val(dttable.Rows(0).Item("INTPER"))


                        If Convert.ToBoolean(dttable.Rows(0).Item("LOCKED")) = True Then cmbcmpname.Enabled = False Else cmbcmpname.Enabled = True
                    End If
                End If
            End If

            'FILL GRID SHADE
            Dim OBJCM As New ClsCommon
            Dim DT1 As DataTable = OBJCM.search(" ISNULL(ACCOUNTSMASTER_SHADECARD.ACC_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ACCOUNTSMASTER_SHADECARD.ACC_SUBMITDATE, GETDATE()) AS SUBMITDATE, ISNULL(ACCOUNTSMASTER_SHADECARD.ACC_APVDATE, GETDATE()) AS APPROVEDATE, ISNULL(ACCOUNTSMASTER_SHADECARD.ACC_EXPDATE, GETDATE()) AS EXPIRYDATE ", "", "  ACCOUNTSMASTER_SHADECARD INNER JOIN ACCOUNTSMASTER ON ACCOUNTSMASTER_SHADECARD.ACC_ID = ACCOUNTSMASTER.Acc_id AND ACCOUNTSMASTER_SHADECARD.ACC_YEARID = ACCOUNTSMASTER.Acc_yearid INNER JOIN ITEMMASTER ON ACCOUNTSMASTER_SHADECARD.ACC_ITEMID = ITEMMASTER.item_id", " AND ACCOUNTSMASTER_SHADECARD.ACC_ID = " & tempAccountId & "  AND ACCOUNTSMASTER_SHADECARD.ACC_CMPID = " & CmpId & " AND ACCOUNTSMASTER_SHADECARD.ACC_YEARID = " & YearId & " ORDER BY GRIDSRNO")
            If DT1.Rows.Count > 0 Then
                For Each dr As DataRow In DT1.Rows
                    GRIDSHADE.Rows.Add(dr("GRIDSRNO").ToString, dr("ITEMCODE").ToString, Format(Convert.ToDateTime(dr("SUBMITDATE")).Date, "dd/MM/yyyy"), Format(Convert.ToDateTime(dr("APPROVEDATE")).Date, "dd/MM/yyyy"), Format(Convert.ToDateTime(dr("EXPIRYDATE")).Date, "dd/MM/yyyy"))
                Next
                GRIDSHADE.FirstDisplayedScrollingRowIndex = GRIDSHADE.RowCount - 1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbregister.Enter
        Try
            If cmbregister.Text.Trim = "" Then
                'CHECK GROUP_SECONDARY
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" GROUP_SECONDARY ", "", " GROUPMASTER ", " AND GROUP_NAME = '" & cmbgroup.Text.Trim & "' AND GROUP_CMPID = " & CmpId & " AND GROUP_LOCATIONID = " & Locationid & " AND GROUP_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item(0) = "Sundry Creditors" Then
                        fillregister(cmbregister, " and register_type = 'PURCHASE'")
                    ElseIf DT.Rows(0).Item(0) = "Sundry Debtors" Then
                        fillregister(cmbregister, " and register_type = 'SALE'")
                    End If
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbregister_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbregister.Validating
        Try
            If cmbregister.Text.Trim.Length > 0 Then
                'clear()
                cmbregister.Text = UCase(cmbregister.Text)
                'CHECK GROUP_SECONDARY
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" GROUP_SECONDARY ", "", " GROUPMASTER ", " AND GROUP_NAME = '" & cmbgroup.Text.Trim & "' AND GROUP_CMPID = " & CmpId & " AND GROUP_LOCATIONID = " & Locationid & " AND GROUP_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item(0) = "Sundry Creditors" Then
                        DT = OBJCMN.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'PURCHASE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
                    ElseIf DT.Rows(0).Item(0) = "Sundry Debtors" Then
                        DT = OBJCMN.search(" register_abbr, register_initials, register_id", "", " RegisterMaster", " and register_name ='" & cmbregister.Text.Trim & "' and register_type = 'SALE' and register_cmpid = " & CmpId & " AND REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
                    End If
                    If DT.Rows.Count = 0 Then
                        MsgBox("Register Not Present, Add New from Master Module")
                        cmbregister.Text = ""
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGROUPOFCOMPANIES_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGROUPOFCOMPANIES.Enter
        Try
            If CMBGROUPOFCOMPANIES.Text.Trim = "" Then FILLGROUPCOMPANY(CMBGROUPOFCOMPANIES)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGROUPOFCOMPANIES_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGROUPOFCOMPANIES.Validating
        Try
            If CMBGROUPOFCOMPANIES.Text.Trim <> "" Then GROUPCOMPANYVALIDATE(CMBGROUPOFCOMPANIES, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub add()
        txtadd.Clear()
        If txtadd1.Text.Trim <> "" Then txtadd.Text = txtadd.Text & txtadd1.Text.Trim & vbNewLine
        If txtadd2.Text.Trim <> "" Then txtadd.Text = txtadd.Text & txtadd2.Text.Trim & vbNewLine

        If cmbarea.Text.Trim <> "" Then txtadd.Text = txtadd.Text & "" & cmbarea.Text.Trim

        txtadd.Text = txtadd.Text & "" & cmbcity.Text.Trim

        If txtzipcode.Text.Trim <> "" Then
            txtadd.Text = txtadd.Text & " - " & txtzipcode.Text.Trim & vbNewLine
        Else
            txtadd.Text = txtadd.Text & vbNewLine
        End If

        If cmbstate.Text.Trim <> "" Then
            txtadd.Text = txtadd.Text & "" & cmbstate.Text.Trim
        Else
            txtadd.Text = txtadd.Text & vbNewLine
        End If

        If cmbcountry.Text.Trim <> "" Then
            txtadd.Text = txtadd.Text & " " & cmbcountry.Text.Trim
        End If
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            'CODE DONE BY GULKIT DONT TOUCH STRICTLY
            'IF COMMON FOR ALL IS SELECTED THEN WE NEED TO LOOP FOR ALL COMPANYIES WITH SAME ACCOUNTING YEAR
            'BEFORE THIS SAVE WE NEED TO CHECK WHETHER SAME GROUPNAME AND STATE IS PRESENT IN THAT YEAR OR NOT
            'IF NOT PRESENT THEN DONT SAVE
            If CHKCOMMON.CheckState = CheckState.Unchecked Then
                If edit = False Then SAVEUPDATE(CmpId, YearId, 0) Else SAVEUPDATE(CmpId, YearId, tempAccountId)
            Else
                Dim OBJCMN As New ClsCommon
                Dim DTCMP As DataTable = OBJCMN.search("YEAR_CMPID AS CMPID, YEAR_ID AS YEARID ", "", " YEARMASTER ", " AND YEAR_STARTDATE = '" & Format(Convert.ToDateTime(AccFrom.Date), "MM/dd/yyyy") & "' ORDER BY YEAR_ID")
                For Each DTROW As DataRow In DTCMP.Rows
                    'BEFORE SAVING WE WILL CHECK WHETHER CMPNAME OR GROUPNAME AND STATE IS PRESENT IN THAY UYEAR OR NOT
                    'IF NOT THEN GOTONEXTLINE
                    'IF CMPNAME IS ALREADY PRESENT THEN SKIP
                    Dim DTTEMP As DataTable

                    DTTEMP = OBJCMN.search("GROUP_ID AS GROUPID", "", "GROUPMASTER ", " AND GROUP_NAME = '" & cmbgroup.Text.Trim & "' AND GROUP_YEARID = " & Val(DTROW("YEARID")))
                    If DTTEMP.Rows.Count = 0 Then GoTo NEXTLINE

                    'CHECK STATE
                    DTTEMP = OBJCMN.search("STATE_ID AS STATEID", "", "STATEMASTER ", " AND STATE_NAME = '" & cmbstate.Text.Trim & "' AND STATE_YEARID = " & Val(DTROW("YEARID")))
                    If DTTEMP.Rows.Count = 0 Then GoTo NEXTLINE

                    If edit = False Then
                        If YearId <> DTROW("YEARID") Then
                            DTTEMP = OBJCMN.search("ACC_ID AS ACCID", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbcmpname.Text.Trim & "' AND ACC_YEARID = " & Val(DTROW("YEARID")))
                            If DTTEMP.Rows.Count > 0 Then GoTo NEXTLINE
                        End If
                        SAVEUPDATE(DTROW("CMPID"), DTROW("YEARID"), 0)
                    Else

                        DTTEMP = OBJCMN.search("ACC_ID AS ACCID", "", "LEDGERS", " AND ACC_CMPNAME = '" & cmbcmpname.Text.Trim & "' AND ACC_ID <> " & tempAccountId & " AND ACC_YEARID = " & Val(DTROW("YEARID")))
                        If DTTEMP.Rows.Count > 0 Then GoTo NEXTLINE

                        'FIRST GET THE ACCOUNTID FROM YEARID AND THEN PASS IT IN THE UPDATE QUERY
                        DTTEMP = OBJCMN.search("ACC_ID AS ACCID", "", "LEDGERS", " AND ACC_CMPNAME = '" & tempAccountsName & "' AND ACC_YEARID = " & Val(DTROW("YEARID")))
                        If DTTEMP.Rows.Count > 0 Then SAVEUPDATE(DTROW("CMPID"), DTROW("YEARID"), Val(DTTEMP.Rows(0).Item("ACCID")))
                    End If
NEXTLINE:
                Next
            End If

            If edit = False Then MsgBox("Details Added") Else MsgBox("Details Updated")
            CLEAR()
            tempAccountsName = ""
            edit = False
            cmbcmpname.Focus()


        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub SAVEUPDATE(ByVal TCMPID As Integer, ByVal TYEARID As Integer, ByVal TACCID As Integer)
        Try

            Dim IntResult As Integer
            Dim alParaval As New ArrayList
            alParaval.Add(UCase(cmbcmpname.Text.Trim))
            alParaval.Add(txtname.Text.Trim)
            alParaval.Add(cmbgroup.Text.Trim)

            'DONT SAVE OR UPDATE OPBAL FOR ALL COMPANY
            If TYEARID = YearId Then
                alParaval.Add(Val(txtopbal.Text.Trim))
                alParaval.Add(cmbdrcrrs.Text.Trim)
            Else
                'GET OPBAL OF THAT YEAR AND PASS THAT VALUE
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("ISNULL(ACC_OPBAL,0) AS OPBAL, ACC_DRCR AS DRCR ", "", "LEDGERS", "AND ACC_ID = " & TACCID)
                If DT.Rows.Count > 0 Then
                    alParaval.Add(Val(DT.Rows(0).Item("OPBAL")))
                    alParaval.Add(DT.Rows(0).Item("DRCR"))
                Else
                    alParaval.Add(0)
                    alParaval.Add("")
                End If
            End If

            alParaval.Add(txtadd1.Text.Trim)
            alParaval.Add(txtadd2.Text.Trim)
            alParaval.Add(TXTLANDMARK.Text.Trim)
            alParaval.Add(cmbarea.Text.Trim)
            alParaval.Add(txtstd.Text.Trim)
            alParaval.Add(cmbcity.Text.Trim)
            alParaval.Add(txtzipcode.Text.Trim)
            alParaval.Add(cmbstate.Text.Trim)
            alParaval.Add(cmbcountry.Text.Trim)
            alParaval.Add(txtcrdays.Text.Trim)
            alParaval.Add(txtcrlimit.Text.Trim)
            alParaval.Add(CMBADDLESS.Text.Trim)
            alParaval.Add(txtresino.Text.Trim)
            alParaval.Add(txtaltno.Text.Trim)
            alParaval.Add(txttel1.Text.Trim)
            alParaval.Add(txtmobile.Text.Trim)
            alParaval.Add(txtfax.Text.Trim)
            alParaval.Add(txtwebsite.Text.Trim)
            alParaval.Add(cmbemail.Text.Trim)

            alParaval.Add(CMBPARTYBANK.Text.Trim)
            alParaval.Add(TXTACCTYPE.Text.Trim)
            alParaval.Add(TXTACCNO.Text.Trim)
            alParaval.Add(TXTIFSC.Text.Trim)
            alParaval.Add(TXTBRANCH.Text.Trim)
            alParaval.Add(CMBBANKCITY.Text.Trim)

            alParaval.Add(CMBTRANS.Text.Trim)
            alParaval.Add(CMBAGENT.Text.Trim)
            alParaval.Add(Val(TXTAGENTCOMM.Text.Trim))
            alParaval.Add(Val(TXTDISC.Text.Trim))
            alParaval.Add(Val(TXTCDPER.Text.Trim))
            alParaval.Add(txtpanno.Text.Trim)
            alParaval.Add(txtexciseno.Text.Trim)
            alParaval.Add(txtrange.Text.Trim)
            alParaval.Add(txtdivision.Text.Trim)
            alParaval.Add(txttinno.Text.Trim)
            alParaval.Add(txtcstno.Text.Trim)
            alParaval.Add(txtvatno.Text.Trim)
            alParaval.Add(TXTGSTIN.Text.Trim)
            alParaval.Add(txtstno.Text.Trim)
            alParaval.Add(cmbregister.Text.Trim)
            alParaval.Add(TXTSIZETOLERANCE.Text.Trim)
            alParaval.Add(TXTGSMTOLERANCE.Text.Trim)
            alParaval.Add(TXTPATTERNTOLERANCE.Text.Trim)
            alParaval.Add(TXTACCESSQUANTITY.Text.Trim)
            alParaval.Add(txtadd.Text.Trim)
            alParaval.Add(txtshipadd.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(TCMPID)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(TYEARID)
            alParaval.Add(0)
            alParaval.Add(UCase(CMBCODE.Text.Trim))

            'BOOKING DETAILS
            Dim gridsrno As String = ""
            Dim ITEMCODE As String = ""
            Dim SUBMITDATE As String = ""
            Dim APPROVEDATE As String = ""
            Dim EXPIRYDATE As String = ""


            'FOR SHADE GRID
            '***************************
            For Each row As Windows.Forms.DataGridViewRow In GRIDSHADE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = Val(row.Cells(GSRNO.Index).Value.ToString)
                        ITEMCODE = row.Cells(GITEMCODE.Index).Value.ToString
                        SUBMITDATE = Format(Convert.ToDateTime(row.Cells(GSUBMITDATE.Index).Value).Date, "MM/dd/yyyy")
                        APPROVEDATE = Format(Convert.ToDateTime(row.Cells(GAPPROVEDATE.Index).Value).Date, "MM/dd/yyyy")
                        EXPIRYDATE = Format(Convert.ToDateTime(row.Cells(GEXPIRYDATE.Index).Value).Date, "MM/dd/yyyy")

                    Else

                        gridsrno = gridsrno & "|" & Val(row.Cells(GSRNO.Index).Value)
                        ITEMCODE = ITEMCODE & "|" & row.Cells(GITEMCODE.Index).Value.ToString
                        SUBMITDATE = SUBMITDATE & "|" & Format(Convert.ToDateTime(row.Cells(GSUBMITDATE.Index).Value).Date, "MM/dd/yyyy")
                        APPROVEDATE = APPROVEDATE & "|" & Format(Convert.ToDateTime(row.Cells(GAPPROVEDATE.Index).Value).Date, "MM/dd/yyyy")
                        EXPIRYDATE = EXPIRYDATE & "|" & Format(Convert.ToDateTime(row.Cells(GEXPIRYDATE.Index).Value).Date, "MM/dd/yyyy")

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(ITEMCODE)
            alParaval.Add(SUBMITDATE)
            alParaval.Add(APPROVEDATE)
            alParaval.Add(EXPIRYDATE)


            'TDS
            '*******************************
            alParaval.Add(CHKTDSAPP.CheckState)
            alParaval.Add(CMBDEDUCTEETYPE.Text.Trim)

            If CMBISLOWER.Text.Trim = "Yes" Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(CMBSECTION.Text.Trim)
            alParaval.Add(Val(TXTTDSRATE.Text.Trim))
            alParaval.Add(Val(TXTTDSPER.Text.Trim))

            If CMBSURCHARGE.Text.Trim = "Yes" Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If
            alParaval.Add(Val(TXTLIMIT.Text.Trim))
            '*******************************


            alParaval.Add(CHKTDS.CheckState)
            alParaval.Add(CMBNATURE.Text.Trim)
            alParaval.Add(CMBTYPE.Text.Trim)


            alParaval.Add(CHKRCM.CheckState)
            alParaval.Add(CHKBLOCKED.CheckState)
            alParaval.Add(Val(TXTKMS.Text.Trim))
            alParaval.Add(TXTDELIVERYPINCODE.Text.Trim)
            alParaval.Add(CMBSEZTYPE.Text.Trim)


            alParaval.Add(CMBTDSDEDUCTEDAC.Text.Trim)
            alParaval.Add(CMBCALC.Text.Trim)
            alParaval.Add(CHKTCS.CheckState)
            alParaval.Add(CHKPARTYTDS.CheckState)
            alParaval.Add(CHKTDSONGTOTAL.Checked)
            If CHKGSTINVERIFIED.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If
            alParaval.Add(CMBTDSFORM.Text.Trim)
            alParaval.Add(CMBTDSCOMPANY.Text.Trim)

            alParaval.Add(CMBGROUPOFCOMPANIES.Text.Trim)
            alParaval.Add(TXTMSMENO.Text.Trim)
            alParaval.Add(CMBMSMETYPE.Text.Trim)
            alParaval.Add(Val(TXTINTPER.Text.Trim))


            Dim objAccountsMaster As New ClsAccountsMaster
            objAccountsMaster.alParaval = alParaval
            objAccountsMaster.frmstring = frmstring

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objAccountsMaster.SAVE()
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TACCID)
                IntResult = objAccountsMaster.UPDATE()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()

        TXTSRNO.Clear()
        CMBITEMCODE.Text = ""
        DTSUBMITDATE.Text = Mydate
        DTAPPROVEDATE.Text = Mydate
        DTEXPIRYDATE.Text = Mydate
        GRIDSHADE.RowCount = 0

        'TDS
        CHKTDS.CheckState = CheckState.Unchecked
        CMBNATURE.Text = ""
        CHKTDSAPP.CheckState = CheckState.Unchecked
        GROUPTDS.Enabled = False
        CMBDEDUCTEETYPE.Text = ""
        CMBISLOWER.SelectedIndex = 0
        CMBSECTION.SelectedIndex = 0
        TXTTDSRATE.Clear()
        TXTTDSPER.Clear()
        CMBSURCHARGE.SelectedIndex = 0
        TXTTDSRATE.Enabled = False
        CMBSECTION.Enabled = False
        cmbregister.Text = ""


        txtadd.Clear()
        txtadd1.Clear()
        txtadd2.Clear()
        txtaltno.Clear()
        cmbcmpname.Text = ""
        cmbcmpname.Enabled = True

        txtcrdays.Clear()
        txtcrlimit.Clear()
        txtcstno.Clear()
        txtdivision.Clear()
        TXTLANDMARK.Clear()

        cmbemail.Text = ""
        CMBTRANS.Text = ""
        CMBAGENT.Text = ""
        TXTAGENTCOMM.Clear()

        txtexciseno.Clear()
        txtfax.Clear()
        TXTGSTIN.Clear()
        txtmobile.Clear()
        txtname.Clear()
        txtopbal.Clear()
        txtpanno.Clear()
        txtrange.Clear()
        txtremarks.Clear()
        txtresino.Clear()
        txtshipadd.Clear()
        txtstd.Clear()
        txtstno.Clear()
        txttel1.Clear()
        txttinno.Clear()
        txtvatno.Clear()
        txtwebsite.Clear()
        txtzipcode.Clear()
        TXTSIZETOLERANCE.Clear()
        TXTGSMTOLERANCE.Clear()
        TXTPATTERNTOLERANCE.Clear()
        TXTACCESSQUANTITY.Clear()
        cmbarea.Text = ""

        TXTACCTYPE.Clear()
        CMBPARTYBANK.Text = ""
        TXTACCNO.Clear()
        TXTIFSC.Clear()
        TXTBRANCH.Clear()
        CMBBANKCITY.Text = ""

        cmbcity.Text = ""
        cmbcountry.Text = ""
        cmbdrcrrs.Text = ""
        cmbgroup.Text = ""
        cmbstate.Text = CMPSTATENAME
        CMBCODE.Text = ""
        cmbcmpname.Text = ""
        CMBPARTYBANK.Text = ""
        CMBTYPE.SelectedIndex = 0
        CMBGROUPOFCOMPANIES.Text = ""
        TXTMSMENO.Clear()
        CMBMSMETYPE.Text = ""
        TXTINTPER.Clear()

        CHKRCM.CheckState = CheckState.Unchecked
        CHKBLOCKED.CheckState = CheckState.Unchecked
        TXTKMS.Clear()
        TXTDELIVERYPINCODE.Clear()

        'CMBCALC.Text = dttable.Rows(0).Item("CALC")
        'CMBTDSDEDUCTEDAC.Text = dttable.Rows(0).Item("TDSDEDUCTEDAC").ToString
        CHKTCS.CheckState = CheckState.Unchecked
        CHKTDS.CheckState = CheckState.Unchecked
        CHKTDSONGTOTAL.CheckState = CheckState.Unchecked
        PBSUCCESS.Visible = False
        PBFAILED.Visible = False
        CHKGSTINVERIFIED.CheckState = CheckState.Unchecked
    End Sub

    Function CHECKDUPLICATE() As Boolean
        Try
            Dim BLN As Boolean = True
            pcase(cmbcmpname)
            CMBCODE.Text = cmbcmpname.Text.Trim
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If (edit = False) Or (edit = True And LCase(cmbcmpname.Text) <> LCase(tempAccountsName)) Then
                dt = objclscommon.search("ACC_CMPNAME", "", " LEDGERS", " AND ACC_CMPNAME = '" & cmbcmpname.Text.Trim & "' and LEDGERS.acc_cmpid = " & CmpId & " AND LEDGERS.ACC_LOCATIONID = " & Locationid & " AND LEDGERS.ACC_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("Name Already Exists", MsgBoxStyle.Critical, "EASYBIZ")
                    BLN = False
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If cmbcmpname.Text.Trim.Length = 0 Then
            Ep.SetError(cmbcmpname, "Fill Company Name")
            bln = False
        End If
        If Not CHECKDUPLICATE() Then
            Ep.SetError(cmbcmpname, "Name Already Exists")
            bln = False
        End If

        If CMBTYPE.Text.Trim.Length = 0 Then
            Ep.SetError(CMBTYPE, "Select Type")
            bln = False
        End If

        If cmbstate.Text.Trim.Length = 0 Then
            Ep.SetError(cmbstate, "Select State")
            bln = False
        End If

        If CHKTDS.CheckState = CheckState.Unchecked Then CMBNATURE.Text = ""

        If CHKTDS.CheckState = CheckState.Checked And CMBNATURE.Text.Trim = "" Then
            Ep.SetError(CMBNATURE, "Select Nature Of Payment")
            bln = False
        End If


        If CMBCODE.Text.Trim.Length = 0 Then
            Ep.SetError(CMBCODE, "Fill Company Code")
            bln = False
        End If


        If cmbgroup.Text.Trim.Length = 0 Then
            Ep.SetError(cmbgroup, "Select Group")
            bln = False
        End If


        If CMBTRANS.Text.Trim = cmbcmpname.Text.Trim Then
            Ep.SetError(CMBTRANS, "Transport Name cannot be same as Company Name")
            bln = False
        End If

        If CMBAGENT.Text.Trim = cmbcmpname.Text.Trim Then
            Ep.SetError(CMBAGENT, "Agent Name cannot be same as Company Name")
            bln = False
        End If

        If Val(TXTACCESSQUANTITY.Text.Trim) > 100 Then
            Ep.SetError(TXTACCESSQUANTITY, "ACCESS QUANTITY CANNOT BE GREATER THAN 100")
            bln = False
        End If

        If txtpanno.Text.Trim <> "" Then

            If CMBDEDUCTEETYPE.Text.Trim = "" Then
                Ep.SetError(txtpanno, "Select Company Type")
                bln = False
            End If

            If txtpanno.Text.Trim.Length <> 10 Then
                Ep.SetError(txtpanno, "Insert Proper PAN No")
                bln = False
            Else
                'validating PAN NO
                For x = 1 To Len(txtpanno.Text.Trim)
                    If x <= 5 Or x = 10 Then
                        If Asc(txtpanno.Text.Substring(x - 1, 1)) < 65 Or Asc(txtpanno.Text.Substring(x - 1, 1)) > 90 Then
                            Ep.SetError(txtpanno, "Insert Proper PAN No")
                            bln = False
                        End If
                    Else
                        If Asc(txtpanno.Text.Substring(x - 1, 1)) < 48 Or Asc(txtpanno.Text.Substring(x - 1, 1)) > 57 Then
                            Ep.SetError(txtpanno, "Insert Proper PAN No")
                            bln = False
                        End If
                    End If
                    'CHECKING 4TH ALPHABET WITH DEDUCTEETYPE
                    If x = 4 Then

                        If CMBDEDUCTEETYPE.Text.Trim = "Individual" Then
                            If txtpanno.Text.Substring(x - 1, 1) <> "P" Then
                                Ep.SetError(txtpanno, "Insert Proper PAN No")
                                bln = False
                            End If
                        ElseIf CMBDEDUCTEETYPE.Text.Trim = "Firm" Then
                            If txtpanno.Text.Substring(x - 1, 1) <> "F" Then
                                Ep.SetError(txtpanno, "Insert Proper PAN No")
                                bln = False
                            End If
                        ElseIf CMBDEDUCTEETYPE.Text = "Company" Then
                            If txtpanno.Text.Substring(x - 1, 1) <> "C" Then
                                Ep.SetError(txtpanno, "Insert Proper PAN No")
                                bln = False
                            End If

                        ElseIf CMBDEDUCTEETYPE.Text = "HUF" Then
                            If txtpanno.Text.Substring(x - 1, 1) <> "H" Then
                                Ep.SetError(txtpanno, "Insert Proper PAN No")
                                bln = False
                            End If
                        End If
                    End If
                Next x
            End If
        End If


        'CHECKING 1ST TWO ALPHABETS WITH STATE
        If cmbstate.Text.Trim <> "" And TXTGSTIN.Text.Trim <> "" Then
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" cast(state_remark as varchar(5)) AS STATECODE ", "", " STATEMASTER", " AND state_name = '" & cmbstate.Text.Trim & "' and STATE_YEARID = " & YearId)
            If DT.Rows(0).Item("STATECODE") <> TXTGSTIN.Text.Substring(0, 2) Then
                Ep.SetError(TXTGSTIN, "State Code does not match with GST No")
                bln = False
            End If
        End If


        If TXTGSTIN.Text.Trim.Length > 0 Then
            If TXTGSTIN.Text.Trim.Length <> 15 Then
                Ep.SetError(TXTGSTIN, "Enter Proper GST No")
                bln = False
            End If

            'do not VALIDATE GSTIN JUST GIVE INTIMATION WISH TO PROCEED
            'DONE BY GULKIT
            If (edit = False) Or (edit = True And TEMPGSTIN <> TXTGSTIN.Text.Trim) Then
                Dim objcmn As New ClsCommon
                Dim DT As DataTable = objcmn.search("ACC_GSTIN AS GSTIN", "", "LEDGERS", " and LEDGERS.acc_GSTIN = '" & TXTGSTIN.Text.Trim & "' and ACC_yearid = " & YearId)
                If DT.Rows.Count > 0 Then
                    If MsgBox("Ledger With same GSTIN is already present, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Ep.SetError(TXTGSTIN, "GSTIN Already Exists")
                        bln = False
                    End If
                End If
            End If
        End If



        If UserName <> "Admin" Then
            Dim bln_4_case As Boolean = True
            Select Case tempAccountsName
                Case "Transport Charges"
                    ' Str = "Turquoise"
                    bln_4_case = False
                Case "Other Charges"
                    bln_4_case = False
                Case "S.T. 1.03%"
                    bln_4_case = False
                Case "PURCHASE"
                    bln_4_case = False
                Case "SALE"
                    bln_4_case = False
                Case "T.D.S."
                    bln_4_case = False
                Case "Cash In Hand"
                    bln_4_case = False
                Case "Petty Cash"
                    bln_4_case = False
                Case "Round Off"
                    bln_4_case = False
                Case "Discount Recd"
                    bln_4_case = False
                Case "Commission Recd"
                    bln_4_case = False
                Case "Discount Given"
                    bln_4_case = False
                Case "Commission A/C"
                    bln_4_case = False
                Case "Agent Commission"
                    bln_4_case = False
                Case "Profit & Loss A/C"
                    bln_4_case = False
                Case "Opening A/C"
                    bln_4_case = False

            End Select

            If bln_4_case = False Then
                Ep.SetError(cmbcmpname, "Build In Ledger Cannot edit")
                bln = False
            End If

            If CHKPARTYTDS.CheckState = CheckState.Checked And CHKTCS.CheckState = CheckState.Checked Then
                Ep.SetError(CHKTCS, "TCS And TDS Cannot be selected Together")
                bln = False
            End If

        End If
        Return bln
    End Function

    Private Sub cmbgroup_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgroup.GotFocus
        Try
            If cmbgroup.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("group_name", "", "GroupMaster", " and group_cmpid = " & CmpId & " and group_Locationid = " & Locationid & " and group_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Group_name"
                    cmbgroup.DataSource = dt
                    cmbgroup.DisplayMember = "group_name"
                    cmbgroup.Text = ""
                End If
                cmbgroup.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcity.GotFocus
        Try
            If cmbcity.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "City_name"
                    cmbcity.DataSource = dt
                    cmbcity.DisplayMember = "city_name"
                    cmbcity.Text = ""
                End If
                cmbcity.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcity_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcity.Validating
        Try
            If cmbcity.Text.Trim <> "" Then
                pcase(cmbcity)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_name = '" & cmbcity.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbcity.Text.Trim
                    Dim tempmsg As Integer = MsgBox("City not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbcity.Text = a
                        objyearmaster.savecity(cmbcity.Text.Trim, CmpId, Locationid, Userid, YearId, " and city_name = '" & cmbcity.Text.Trim & "' and city_cmpid = " & CmpId & " and city_Locationid = " & Locationid & " and city_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbcity.DataSource
                        If cmbcity.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(cmbcity.Text)
                                cmbcity.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbstate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbstate.GotFocus
        Try
            If cmbstate.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("state_name", "", "StateMaster", " and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "state_name"
                    cmbstate.DataSource = dt
                    cmbstate.DisplayMember = "state_name"
                    cmbstate.Text = ""
                End If
                cmbstate.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbstate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbstate.Validating
        Try
            If cmbstate.Text.Trim <> "" Then

                pcase(cmbstate)
                Dim objClsCommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objClsCommon.search("state_name", "", "StateMaster", " and state_name = '" & cmbstate.Text.Trim & "' and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbstate.Text.Trim
                    Dim tempmsg As Integer = MsgBox("State not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbstate.Text = a
                        objyearmaster.savestate(cmbstate.Text.Trim, CmpId, Locationid, Userid, YearId, " and state_name = '" & cmbstate.Text.Trim & "' and state_cmpid = " & CmpId & " and state_Locationid = " & Locationid & " and state_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbstate.DataSource
                        If cmbstate.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(cmbstate.Text)
                                cmbstate.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcountry_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcountry.GotFocus
        Try
            If cmbcountry.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("country_name", "", "CountryMaster", " and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "country_name"
                    cmbcountry.DataSource = dt
                    cmbcountry.DisplayMember = "country_name"
                    cmbcountry.Text = ""
                End If
                cmbcountry.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcountry_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcountry.Validating
        Try
            If cmbcountry.Text.Trim <> "" Then
                pcase(cmbcountry)
                Dim objClsCommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objClsCommon.search("Country_name", "", "CountryMaster", " and Country_name = '" & cmbcountry.Text.Trim & "' and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbcountry.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Country not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbcountry.Text = a
                        objyearmaster.savecountry(cmbcountry.Text.Trim, CmpId, Locationid, Userid, YearId, " and Country_name = '" & cmbcountry.Text.Trim & "' and country_cmpid = " & CmpId & " and country_Locationid = " & Locationid & " and country_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbcountry.DataSource
                        If cmbcountry.DataSource <> Nothing Then
                            If dt1.Rows.Count > 0 Then
Line1:
                                dt1.Rows.Add(cmbcountry.Text)
                                cmbcountry.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo Line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    'Private Sub txtcmpname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    Try

    '        pcase(cmbcmpname)
    '        If (edit = False) Or (edit = True And tempAccountsName <> cmbcmpname.Text.Trim) Then
    '            'for search
    '            Dim objclscommon As New ClsCommonMaster
    '            Dim dt As New DataTable
    '            If frmstring = "CUSTOMER" Then
    '                dt = objclscommon.search("customer_cmpname", "", "CustomerMaster", " and customer_cmpname = '" & cmbcmpname.Text.Trim & "' and customer_cmpid =" & CmpId & " and customer_Locationid =" & Locationid & " and customer_Yearid =" & YearId)
    '            ElseIf frmstring = "VENDOR" Then
    '                dt = objclscommon.search("Vendor_cmpname", "", "VendorMaster", " and Vendor_cmpname = '" & cmbcmpname.Text.Trim & "' and Vendor_cmpid = " & CmpId & " and Vendor_Locationid = " & Locationid & " and Vendor_Yearid = " & YearId)
    '            ElseIf frmstring = "ACCOUNTS" Then
    '                dt = objclscommon.search("acc_cmpname", "", "AccountsMaster", " and acc_cmpname = '" & cmbcmpname.Text.Trim & "' and acc_cmpid = " & CmpId & " and acc_Locationid = " & Locationid & " and acc_Yearid = " & YearId)
    '            ElseIf frmstring = "EMPLOYEE" Then
    '                dt = objclscommon.search("Emp_cmpname", "", "EmployeeMaster", " and Emp_cmpname = '" & cmbcmpname.Text.Trim & "' and Emp_cmpid = " & CmpId & " and Emp_Locationid = " & Locationid & " and Emp_Yearid = " & YearId)
    '            End If
    '            If dt.Rows.Count > 0 Then
    '                MsgBox("Company Name Already Exists", MsgBoxStyle.Critical, "PrintPro")
    '                e.Cancel = True
    '            End If
    '        End If
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub

    Private Sub cmbarea_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbarea.GotFocus
        Try
            If cmbarea.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("area_name", "", "AreaMaster", " and area_cmpid = " & CmpId & " and area_Locationid = " & Locationid & " and area_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "area_name"
                    cmbarea.DataSource = dt
                    cmbarea.DisplayMember = "area_name"
                    cmbarea.Text = ""
                End If
                cmbarea.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbstreet_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'Try
        '    If CMBSTREET.Text.Trim = "" Then
        '        Dim objclscommon As New ClsCommonMaster
        '        Dim dt As DataTable
        '        dt = objclscommon.search("street_name", "", "streetMaster", " and street_Yearid = " & YearId)
        '        If dt.Rows.Count > 0 Then
        '            dt.DefaultView.Sort = "street_name"
        '            CMBSTREET.DataSource = dt
        '            CMBSTREET.DisplayMember = "street_name"
        '            CMBSTREET.Text = ""
        '        End If
        '        CMBSTREET.SelectAll()
        '    End If
        'Catch ex As Exception
        '    If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        'End Try
    End Sub

    Private Sub cmbarea_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbarea.Validating
        Try
            If cmbarea.Text.Trim <> "" Then
                pcase(cmbarea)
                Dim objClsCommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objClsCommon.search("area_name", "", "areaMaster", " and area_name = '" & cmbarea.Text.Trim & "' and area_cmpid = " & CmpId & " and area_Locationid = " & Locationid & " and area_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbarea.Text.Trim
                    Dim tempmsg As Integer = MsgBox("area not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        cmbarea.Text = a
                        objyearmaster.savearea(cmbarea.Text.Trim, CmpId, Locationid, Userid, YearId, " and area_name = '" & cmbarea.Text.Trim & "' and area_cmpid = " & CmpId & " and area_Locationid = " & Locationid & " and area_Yearid = " & YearId)
                        Dim dt1 As New DataTable
                        dt1 = cmbarea.DataSource
                        If cmbarea.DataSource <> Nothing Then
line1:
                            If dt1.Rows.Count > 0 Then
                                dt1.Rows.Add(cmbarea.Text)
                                cmbarea.Text = a
                            End If
                        End If
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbstreet_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        '        Try
        '            If CMBSTREET.Text.Trim <> "" Then
        '                pcase(CMBSTREET)
        '                Dim objClsCommon As New ClsCommonMaster
        '                Dim objyearmaster As New ClsYearMaster
        '                Dim dt As DataTable
        '                dt = objClsCommon.search("street_name", "", "streetMaster", " and street_name = '" & CMBSTREET.Text.Trim & "' and street_Yearid = " & YearId)
        '                If dt.Rows.Count = 0 Then
        '                    Dim a As String = CMBSTREET.Text.Trim
        '                    Dim tempmsg As Integer = MsgBox("Street not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
        '                    If tempmsg = vbYes Then
        '                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
        '                        If DTROW(0).Item(1) = False Then
        '                            MsgBox("Insufficient Rights")
        '                            Exit Sub
        '                        End If
        '                        CMBSTREET.Text = a
        '                        objyearmaster.savestreet(CMBSTREET.Text.Trim, CmpId, Locationid, Userid, YearId, " and street_name = '" & CMBSTREET.Text.Trim & "' and street_Yearid = " & YearId)
        '                        Dim dt1 As New DataTable
        '                        dt1 = CMBSTREET.DataSource
        '                        If CMBSTREET.DataSource <> Nothing Then
        'line1:
        '                            If dt1.Rows.Count > 0 Then
        '                                dt1.Rows.Add(CMBSTREET.Text)
        '                                CMBSTREET.Text = a
        '                            End If
        '                        End If
        '                    Else
        '                        e.Cancel = True
        '                    End If
        '                End If
        '            End If
        '        Catch ex As Exception
        '            GoTo line1
        '            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        '        End Try
    End Sub

    Private Sub cmbgroup_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbgroup.Validated
        Try
            If cmbgroup.Text.Trim <> "" Then
                'CHECK GROUP_SECONDARY
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" GROUP_SECONDARY ", "", " GROUPMASTER ", " AND GROUP_NAME = '" & cmbgroup.Text.Trim & "' AND GROUP_CMPID = " & CmpId & " AND GROUP_LOCATIONID = " & Locationid & " AND GROUP_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    cmbregister.Text = ""
                    If DT.Rows(0).Item(0) = "Sundry Creditors" Then
                        fillregister(cmbregister, " and register_type = 'PURCHASE'")
                    ElseIf DT.Rows(0).Item(0) = "Sundry Debtors" Then
                        fillregister(cmbregister, " and register_type = 'SALE'")
                    Else
                        cmbregister.DataSource = Nothing
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbgroup_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbgroup.Validating
        Try
            If cmbgroup.Text.Trim <> "" Then
                pcase(cmbgroup)
                Dim objClsCommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objClsCommon.search("group_name", "", "groupMaster", " and group_name = '" & cmbgroup.Text.Trim & "' and group_cmpid = " & CmpId & " and group_Locationid = " & Locationid & " and group_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbgroup.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Group not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        cmbgroup.Text = a
                        Dim objgroupmaster As New GroupMaster
                        objgroupmaster.txtname.Text = cmbgroup.Text.Trim()
                        objgroupmaster.ShowDialog()
                        dt = objClsCommon.search("group_name", "", "groupMaster", " and group_name = '" & cmbgroup.Text.Trim & "' and group_cmpid = " & CmpId & " and group_Locationid = " & Locationid & " and group_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = cmbgroup.DataSource
                            If cmbgroup.DataSource <> Nothing Then
line1:
                                dt1.Rows.Add(cmbgroup.Text)
                                cmbgroup.Text = a
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        pcase(txtname)
    End Sub

    Private Sub txtadd1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtadd1.Validating
        pcase(txtadd1)
    End Sub

    Private Sub txtadd2_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtadd2.Validating
        pcase(txtadd2)
    End Sub

    Private Sub txtcrdays_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcrdays.KeyPress, txtzipcode.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub txtcrlimit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcrlimit.KeyPress, TXTACCESSQUANTITY.KeyPress, TXTAGENTCOMM.KeyPress, TXTTDSPER.KeyPress, TXTLIMIT.KeyPress, TXTTDSRATE.KeyPress, txtopbal.KeyPress, TXTINTPER.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub


    Private Sub cmbcmpname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcmpname.Enter
        Try
            If cmbcmpname.Text.Trim = "" Then
                FILLCMPNAME()
                cmbcmpname.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcmpname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbcmpname.KeyDown
        If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
        If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True
    End Sub

    Private Sub cmbcmpname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcmpname.Validating
        Try
            If cmbcmpname.Text.Trim <> "" Then
                pcase(cmbcmpname)
                If CMBCODE.Text.Trim = "" Then CMBCODE.Text = cmbcmpname.Text.Trim
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(cmbcmpname.Text) <> LCase(tempAccountsName)) Then
                    dt = objclscommon.search("ACC_CMPNAME", "", " LEDGERS", " AND ACC_CMPNAME = '" & cmbcmpname.Text.Trim & "' and LEDGERS.acc_cmpid = " & CmpId & " AND LEDGERS.ACC_LOCATIONID = " & Locationid & " AND LEDGERS.ACC_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Name Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Function DELETEERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True
            Dim bln_4_case As Boolean = True
            Select Case tempAccountsName
                Case "Transport Charges"
                    ' Str = "Turquoise"
                    bln_4_case = False
                Case "Other Charges"
                    bln_4_case = False
                Case "PURCHASE"
                    bln_4_case = False
                Case "SALE"
                    bln_4_case = False
                Case "T.D.S."
                    bln_4_case = False
                Case "Cash In Hand"
                    bln_4_case = False
                Case "Petty Cash"
                    bln_4_case = False
                Case "Round Off"
                    bln_4_case = False
                Case "Discount Recd"
                    bln_4_case = False
                Case "Commission Recd"
                    bln_4_case = False
                Case "Discount Given"
                    bln_4_case = False
                Case "Commission A/C"
                    bln_4_case = False
                Case "Profit & Loss A/C"
                    bln_4_case = False
                Case "Opening A/C"
                    bln_4_case = False
            End Select

            If bln_4_case = False Then
                Ep.SetError(cmbcmpname, "Build In Ledger Cannot Delete")
                BLN = False
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then

                Ep.Clear()
                If Not DELETEERRORVALID() Then
                    Exit Sub
                End If

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(tempAccountsName)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                Dim OBJACC As New ClsAccountsMaster
                OBJACC.alParaval = ALPARAVAL
                OBJACC.frmstring = frmstring
                Dim DT As DataTable = OBJACC.DELETE
                If DT.Rows.Count > 0 Then
                    MsgBox(DT.Rows(0).Item(0))
                    CLEAR()
                    edit = False
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCODE.Enter
        Try
            If CMBCODE.Text.Trim = "" Then
                FILLCMPCODE()
                CMBCODE.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCODE.Validating
        Try
            If CMBCODE.Text.Trim <> "" Then
                pcase(CMBCODE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(CMBCODE.Text) <> LCase(tempAccountsCode)) Then
                    dt = objclscommon.search("ACC_CODE", "", " LEDGERS", " AND ACC_CODE = '" & CMBCODE.Text.Trim & "' and LEDGERS.acc_cmpid = " & CmpId & " AND LEDGERS.ACC_LOCATIONID = " & Locationid & " AND LEDGERS.ACC_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Code Already Exists", MsgBoxStyle.Critical, "PrintPro")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub chkcopy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkcopy.CheckedChanged
        Try
            txtadd.Clear()
            If chkcopy.CheckState = CheckState.Checked Then
                If txtadd1.Text.Trim <> "" Then txtadd.Text = txtadd.Text & txtadd1.Text.Trim & vbNewLine
                'If CMBSTREET.Text.Trim <> "" Then txtadd.Text = txtadd.Text & CMBSTREET.Text.Trim & vbNewLine
                If cmbarea.Text.Trim <> "" Then txtadd.Text = txtadd.Text & "" & cmbarea.Text.Trim
                If cmbcity.Text.Trim <> "" Then txtadd.Text = txtadd.Text & ", " & cmbcity.Text.Trim

                If txtzipcode.Text.Trim <> "" Then
                    txtadd.Text = txtadd.Text & " - " & txtzipcode.Text.Trim & "," & vbNewLine
                Else
                    txtadd.Text = txtadd.Text & vbNewLine
                End If

                If cmbstate.Text.Trim <> "" Then
                    txtadd.Text = txtadd.Text & "" & cmbstate.Text.Trim & ","
                Else
                    txtadd.Text = txtadd.Text & vbNewLine
                End If

                If cmbcountry.Text.Trim <> "" Then
                    txtadd.Text = txtadd.Text & " " & cmbcountry.Text.Trim & "."
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDBILL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDBILL.Click
        Try
            If edit = True Then
                Dim OBJOPENING As New OpeningBills
                OBJOPENING.MdiParent = MDIMain
                OBJOPENING.TEMPNAME = cmbcmpname.Text.Trim
                OBJOPENING.FRMSTRING = "OPENINGBILLS"
                OBJOPENING.Show()
            Else
                MsgBox("Entry Allowed in Edit mode only", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKTDSAPP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKTDSAPP.CheckedChanged
        Try
            If cmbgroup.Text.Trim <> "" Then
                Dim objcmn As New ClsCommon
                Dim DT As DataTable = objcmn.search(" GROUP_SECONDARY", "", " GROUPMASTER", " AND GROUP_NAME = '" & cmbgroup.Text.Trim & "' AND GROUP_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item(0) = "Sundry Creditors" Or DT.Rows(0).Item(0) = "Sundry Debtors" Or DT.Rows(0).Item(0) = "Provisions" Or DT.Rows(0).Item(0) = "Loans" Or DT.Rows(0).Item(0) = "Unsecured Loans" Or DT.Rows(0).Item(0) = "Secured Loans" Or DT.Rows(0).Item(0) = "Loans & Advances" Then
                        GROUPTDS.Enabled = CHKTDSAPP.CheckState
                        'DONE BY GULKIT
                        'Else
                        '    MsgBox("Not Applicable for this Group")
                        '    CHKTDSAPP.CheckState = CheckState.Unchecked
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub CMBDEDUCTEETYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDEDUCTEETYPE.Enter
    '    Try
    '        If CMBDEDUCTEETYPE.Text.Trim = "" Then fillDEDUCTEETYPE(CMBDEDUCTEETYPE)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub cmbitemcode_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBITEMCODE.Enter
        Try
            If CMBITEMCODE.Text.Trim = "" Then fillITEMCODE(CMBITEMCODE, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemcode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMCODE.Validating
        Try
            If CMBITEMCODE.Text.Trim <> "" Then ITEMCODEvalidate(CMBITEMCODE, CMBITEMNAME, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    Private Sub CMBSECTION_Validating(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSECTION.Validating
        Try
            TXTTDSRATE.Clear()
            If CMBSECTION.Text = "194C" Then
                TXTTDSRATE.Enabled = True
                TXTTDSRATE.Focus()
                LBLLIMIT.Visible = True
                TXTLIMIT.Visible = True
            Else
                TXTTDSRATE.Enabled = False
                LBLLIMIT.Visible = False
                TXTLIMIT.Visible = False
                TXTLIMIT.Clear()
                TXTTDSRATE.Clear()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtpanno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpanno.Validating
        Try
            If txtpanno.Text.Trim > "" Then

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNATURE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNATURE.Enter
        Try
            If CMBNATURE.Text.Trim = "" Then FILLNATURE(CMBNATURE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNATURE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNATURE.Validating
        Try
            If CMBNATURE.Text.Trim <> "" Then NATUREVALIDATE(CMBNATURE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANS.Enter
        Try
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND  LEDGERS.ACC_TYPE='TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANS.Validating
        Try
            If CMBTRANS.Text.Trim <> "" Then namevalidate(CMBTRANS, cmbhotelcode, e, Me, TXTHOTELADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "SUNDRY CREDITORS", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbagent_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBAGENT.Enter
        Try
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='AGENT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbagent_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAGENT.Validating
        Try
            If CMBAGENT.Text.Trim <> "" Then namevalidate(CMBAGENT, cmbhotelcode, e, Me, TXTHOTELADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "SUNDRY CREDITORS", "AGENT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPARTYBANK_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPARTYBANK.Enter
        Try
            If CMBPARTYBANK.Text.Trim = "" Then fillPARTYBANK(CMBPARTYBANK, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPARTYBANK_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPARTYBANK.Validating
        Try
            If CMBPARTYBANK.Text.Trim <> "" Then PARTYBANKvalidate(CMBPARTYBANK, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBANKCITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBANKCITY.Enter
        Try
            If CMBBANKCITY.Text.Trim = "" Then fillCITY(CMBBANKCITY, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBANKCITY_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBANKCITY.Validating
        Try
            If CMBBANKCITY.Text.Trim <> "" Then CITYVALIDATE(CMBBANKCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Ep.Clear()

            If GRIDDOUBLECLICK = False Then
                GRIDSHADE.Rows.Add(Val(TXTSRNO.Text.Trim), CMBITEMCODE.Text.Trim, Format(DTSUBMITDATE.Value.Date, "dd/MM/yyyy"), Format(DTAPPROVEDATE.Value.Date, "dd/MM/yyyy"), Format(DTEXPIRYDATE.Value.Date, "dd/MM/yyyy"))
                getsrno(GRIDSHADE)
            ElseIf GRIDDOUBLECLICK = True Then
                GRIDSHADE.Item(GSRNO.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
                GRIDSHADE.Item(GITEMCODE.Index, TEMPROW).Value = CMBITEMCODE.Text.Trim
                GRIDSHADE.Item(GSUBMITDATE.Index, TEMPROW).Value = Format(DTSUBMITDATE.Value.Date, "dd/MM/yyyy")
                GRIDSHADE.Item(GAPPROVEDATE.Index, TEMPROW).Value = Format(DTAPPROVEDATE.Value.Date, "dd/MM/yyyy")
                GRIDSHADE.Item(GEXPIRYDATE.Index, TEMPROW).Value = Format(DTEXPIRYDATE.Value.Date, "dd/MM/yyyy")

                GRIDDOUBLECLICK = False
            End If

            GRIDSHADE.FirstDisplayedScrollingRowIndex = GRIDSHADE.RowCount - 1

            TXTSRNO.Text = Val(GRIDSHADE.RowCount - 1) + 1
            CMBITEMCODE.Text = ""
            DTSUBMITDATE.Value = Mydate
            DTAPPROVEDATE.Value = Mydate
            DTEXPIRYDATE.Value = Mydate

            'TEMPROW = 0
            CMBITEMCODE.Focus()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSHADE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSHADE.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDSHADE.Item(GSRNO.Index, e.RowIndex).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDSHADE.Item(GSRNO.Index, e.RowIndex).Value.ToString
                CMBITEMCODE.Text = GRIDSHADE.Item(GITEMCODE.Index, e.RowIndex).Value.ToString
                DTSUBMITDATE.Value = GRIDSHADE.Item(GSUBMITDATE.Index, e.RowIndex).Value
                DTAPPROVEDATE.Value = GRIDSHADE.Item(GAPPROVEDATE.Index, e.RowIndex).Value
                DTEXPIRYDATE.Value = GRIDSHADE.Item(GEXPIRYDATE.Index, e.RowIndex).Value

                TEMPROW = GRIDSHADE.CurrentRow.Index
                TXTSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DTEXPIRYDATE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DTEXPIRYDATE.Validating
        'Try
        '    If TXTITEMCODE.Text.Trim <> "" Then
        '        FILLGRID()
        '    Else
        '        MsgBox("Enter Proper Details", MsgBoxStyle.Critical, "PRINTPRO")
        '        Exit Sub
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub cmbregister_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbregister.SelectedIndexChanged

    End Sub

    Private Sub GRIDSHADE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSHADE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSHADE.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDSHADE.Rows.RemoveAt(GRIDSHADE.CurrentRow.Index)
                'total()
                getsrno(GRIDSHADE)

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DTEXPIRYDATE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTEXPIRYDATE.Validated
        Try
            If CMBITEMCODE.Text.Trim <> "" Then
                If Not CHECKGRID() Then
                    MsgBox("Item Code for This Item Already Exist in Grid below", MsgBoxStyle.Critical)
                    CMBITEMCODE.Focus()
                    Exit Sub
                End If

                'If (Format(DTAPPROVEDATE.Value.Date, "MM/dd/yyyy") >= Format(DTSUBMITDATE.Value.Date, "MM/dd/yyyy") And Format(DTEXPIRYDATE.Value.Date, "MM/dd/yyyy") >= Format(DTAPPROVEDATE.Value.Date, "MM/dd/yyyy")) Then

                If (Format(DTAPPROVEDATE.Value.Date, "mm/dd/YYYY") >= Format(DTSUBMITDATE.Value.Date, "mm/dd/YYYY") And Format(DTEXPIRYDATE.Value.Date, "mm/dd/YYYY") >= Format(DTAPPROVEDATE.Value.Date, "mm/dd/YYYY")) Then

                    FILLGRID()
                Else
                    MsgBox("Enter Proper Dates", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
            End If
            CMBITEMCODE.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKGRID() As Boolean
        Try
            Dim BLN As Boolean = True

            'For I As Integer = 0 To GRIDSHADE.RowCount - 1
            '    Dim ROW As DataRow = GRIDSHADE.Rows(I)
            '    If (GRIDDOUBLECLICK = False And ROW("ITEMCODE") = TXTITEMCODE.Text.Trim And ROW("E")) Or (GRIDDOUBLECLICK = True And I <> TEMPROW And ROW("ITEMCODE") = TXTITEMCODE.Text.Trim) Then
            '        BLN = False
            '    End If
            'Next

            For Each ROW As Windows.Forms.DataGridViewRow In GRIDSHADE.Rows
                If (GRIDDOUBLECLICK = False And ROW.Cells(GITEMCODE.Index).Value.ToString = CMBITEMCODE.Text.Trim And Format(Convert.ToDateTime(ROW.Cells(GEXPIRYDATE.Index).Value).Date, "MM/dd/yyyy") >= Format(DTEXPIRYDATE.Value.Date, "MM/dd/yyyy")) Or (GRIDDOUBLECLICK = True And GRIDSHADE.CurrentRow.Index <> TEMPROW And ROW.Cells(GITEMCODE.Index).Value.ToString = CMBITEMCODE.Text.Trim And Format(Convert.ToDateTime(ROW.Cells(GEXPIRYDATE.Index).Value).Date, "MM/dd/yyyy") >= Format(DTEXPIRYDATE.Value.Date, "MM/dd/yyyy")) Then
                    BLN = False
                End If
            Next
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub TXTACCESSQUANTITY_Validating(sender As Object, e As CancelEventArgs) Handles TXTACCESSQUANTITY.Validating
        Try
            errorvalid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTDSDEDUCTEDAC_Enter(sender As Object, e As EventArgs) Handles CMBTDSDEDUCTEDAC.Enter
        Try
            If CMBTDSDEDUCTEDAC.Text.Trim = "" Then fillname(CMBTDSDEDUCTEDAC, "FALSE", " AND LEDGERS.ACC_TDSAC = 1")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTDSDEDUCTEDAC_Validating(sender As Object, e As CancelEventArgs) Handles CMBTDSDEDUCTEDAC.Validating
        Try
            If CMBTDSDEDUCTEDAC.Text.Trim <> "" Then namevalidate(CMBTDSDEDUCTEDAC, CMBTDSDEDUCTEDAC, e, Me, txtadd, " AND LEDGERS.ACC_TDSAC = 1")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVERIFY_DockChanged(sender As Object, e As EventArgs) Handles CMDVERIFY.DockChanged
        Try
            If TXTGSTIN.Text.Trim <> "" Then VERIFYGSTIN()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Sub VERIFYGSTIN()
        Try
            'CHECKING COUNTER AND VALIDATE WHETHER EWAY BILL WILL BE ALLOWED OR NOT, FOR EACH EWAY BILL WE NEED TO 2 API COUNTS (1 FOR TOKEN AND ANOTHER FOR EWB)
            If CMPEWAYCOUNTER = 0 Then
                MsgBox("EWay Bill Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'GET USED EWAYCOUNTER
            Dim USEDEWAYCOUNTER As Integer = 0
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("COUNT(COUNTERID) AS EWAYCOUNT", "", "EWAYENTRY", " AND CMPID =" & CmpId)
            If DT.Rows.Count > 0 Then USEDEWAYCOUNTER = Val(DT.Rows(0).Item("EWAYCOUNT"))

            'IF COUNTERS ARE FINISHED
            If CMPEWAYCOUNTER - USEDEWAYCOUNTER <= 0 Then
                MsgBox("EWay Bill Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'IF DATE HAS EXPIRED
            If Now.Date > EWAYEXPDATE Then
                MsgBox("EWay Bill Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'IF BALANCECOUNTERS ARE .10 THEN INTIMATE
            If CMPEWAYCOUNTER - USEDEWAYCOUNTER < Format((CMPEWAYCOUNTER * 0.1), "0") Then
                MsgBox("Only " & (CMPEWAYCOUNTER - USEDEWAYCOUNTER) & " API's Left, Kindly contact Nakoda Infotech for Renewal of GST API Package", MsgBoxStyle.Critical)
            End If

            Dim URL As New Uri("https://gstapi.charteredinfo.com/commonapi/v1.1/search?aspid=1602611918&password=infosys123&Action=TP&Gstin=" & CMPGSTIN & "&SearchGstin=" & TXTGSTIN.Text.Trim)
            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Dim REQUEST As WebRequest
            Dim RESPONSE As WebResponse
            REQUEST = WebRequest.CreateDefault(URL)

            REQUEST.Method = "GET"
            Try
                RESPONSE = REQUEST.GetResponse()
            Catch ex As WebException
                RESPONSE = ex.Response
            End Try
            Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
            Dim REQUESTEDTEXT As String = READER.ReadToEnd()

            'IF STATUS IS NOT 1 THEN TOKEN IS NOT GENERATED
            Dim STARTPOS As Integer = 0
            Dim TEMPSTATUS As String = ""
            'Dim TOKEN As String = ""
            'Dim ENDPOS As Integer = 0

            STARTPOS = REQUESTEDTEXT.IndexOf(TXTGSTIN.Text.Trim)
            If STARTPOS >= 0 Then
                TEMPSTATUS = "SUCCESS"
                PBSUCCESS.Visible = True
                PBFAILED.Visible = False
                CHKGSTINVERIFIED.CheckState = CheckState.Checked
            Else
                TEMPSTATUS = "FAILED"
                PBSUCCESS.Visible = False
                PBFAILED.Visible = True
                CHKGSTINVERIFIED.CheckState = CheckState.Unchecked
            End If

            DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & 0 & ",'GSTIN SEARCH','','" & TXTGSTIN.Text.Trim & "','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class