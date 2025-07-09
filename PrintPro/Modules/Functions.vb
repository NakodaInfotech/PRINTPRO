
Imports System.Net.Mail
Imports BL
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports Newtonsoft.Json
Imports System.Web
Imports WAProAPI

Module Functions

    Sub VIEWFORM(ByVal TYPE As String, ByVal EDIT As Boolean, ByVal BILLNO As Integer, ByVal REGTYPE As String)
        Try
            If TYPE = "PURCHASE" Then

                Dim OBJPURCHASE As New PurchaseMaster
                OBJPURCHASE.MdiParent = MDIMain
                OBJPURCHASE.EDIT = EDIT
                OBJPURCHASE.TEMPBILLNO = BILLNO
                OBJPURCHASE.TEMPREGNAME = REGTYPE
                OBJPURCHASE.Show()

            ElseIf TYPE = "SALE" Then

                Dim OBJSALE As New Invoice
                OBJSALE.MdiParent = MDIMain
                OBJSALE.edit = EDIT
                OBJSALE.TEMPINVOICENO = BILLNO
                OBJSALE.TEMPREGNAME = REGTYPE
                OBJSALE.Show()

            ElseIf TYPE = "PAYMENT" Then

                Dim OBJPAYMENT As New PaymentMaster
                OBJPAYMENT.MdiParent = MDIMain
                OBJPAYMENT.edit = EDIT
                OBJPAYMENT.TEMPPAYMENTNO = BILLNO
                OBJPAYMENT.TEMPREGNAME = REGTYPE
                OBJPAYMENT.Show()

            ElseIf TYPE = "RECEIPT" Then

                Dim OBJREC As New Receipt
                OBJREC.MdiParent = MDIMain
                OBJREC.EDIT = EDIT
                OBJREC.TEMPRECEIPTNO = BILLNO
                OBJREC.TEMPREGNAME = REGTYPE
                OBJREC.Show()

            ElseIf TYPE = "JOURNAL" Then

                Dim OBJJV As New journal
                OBJJV.MdiParent = MDIMain
                OBJJV.edit = EDIT
                OBJJV.tempjvno = BILLNO
                OBJJV.TEMPREGNAME = REGTYPE
                OBJJV.Show()

            ElseIf TYPE = "DEBITNOTE" Then

                Dim OBJDN As New DebitNote
                OBJDN.MdiParent = MDIMain
                OBJDN.edit = EDIT
                OBJDN.TEMPDNNO = BILLNO
                OBJDN.TEMPREGNAME = REGTYPE
                OBJDN.Show()

            ElseIf TYPE = "CREDITNOTE" Then

                Dim OBJCN As New CREDITNOTE
                OBJCN.MdiParent = MDIMain
                OBJCN.edit = EDIT
                OBJCN.TEMPCNNO = BILLNO
                OBJCN.TEMPREGNAME = REGTYPE
                OBJCN.Show()

            ElseIf TYPE = "CONTRA" Then

                Dim OBJCON As New ContraEntry
                OBJCON.MdiParent = MDIMain
                OBJCON.edit = EDIT
                OBJCON.tempcontrano = BILLNO
                OBJCON.TEMPREGNAME = REGTYPE
                OBJCON.Show()

            ElseIf TYPE = "EXPENSE" Then

                Dim OBJEXP As New ExpenseVoucher
                OBJEXP.MdiParent = MDIMain
                OBJEXP.edit = EDIT
                OBJEXP.TEMPEXPNO = BILLNO
                OBJEXP.TEMPREGNAME = REGTYPE
                OBJEXP.FRMSTRING = "NONPURCHASE"
                OBJEXP.Show()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub filldepartment(ByRef CMBDEPARTMENT As ComboBox, ByRef edit As Boolean)
        Try
            If CMBDEPARTMENT.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" DEPARTMENT_name ", "", " DEPARTMENTMaster", " and DEPARTMENT_cmpid=" & CmpId & " AND DEPARTMENT_LOCATIONID = " & Locationid & " AND DEPARTMENT_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "DEPARTMENT_name"
                    CMBDEPARTMENT.DataSource = dt
                    CMBDEPARTMENT.DisplayMember = "DEPARTMENT_name"
                    If edit = False Then CMBDEPARTMENT.Text = ""
                End If
                CMBDEPARTMENT.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub filldesignation(ByRef cmbdesignation As ComboBox)
        Try
            If cmbdesignation.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" designation_NAME ", "", " designationMaster ", " And designation_cmpid=" & CmpId & " And designation_locationid = " & Locationid & " And designation_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "designation_NAME"
                    cmbdesignation.DataSource = dt
                    cmbdesignation.DisplayMember = "designation_NAME"
                    cmbdesignation.Text = ""
                End If
                cmbdesignation.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Sub designationvalidate(ByRef cmbdesignation As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If cmbdesignation.Text.Trim <> "" Then
                uppercase(cmbdesignation)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" designation_NAME ", "", "designationMaster", " and designation_NAME = '" & cmbdesignation.Text.Trim & "' and designation_cmpid = " & CmpId & " and designation_locationid = " & Locationid & " and designation_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("designation not present, Add New?", MsgBoxStyle.YesNo, "PRINTPRO")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(cmbdesignation.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objdesignation As New ClsdesignationMaster
                        objdesignation.alParaval = alParaval
                        Dim IntResult As Integer = objdesignation.save()
                        'e.Cancel = True
                    Else
                        cmbdesignation.Focus()
                        cmbdesignation.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub serverprop(ByVal fromno As Integer, ByVal tono As Integer, Optional ByVal NOOFCOPIES As Integer = 1)

        For I As Integer = fromno To tono
            Dim OBJINV As New SaleInvoiceDesign
            Dim RPTINV As New InvoiceReportNew

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

            crTables = RPTINV.Database.Tables
            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            OBJINV.MdiParent = MDIMain
            RPTINV.PrintOptions.PaperSize = PaperSize.DefaultPaperSize
            RPTINV.RecordSelectionFormula = "{INVOICEMASTER.INVOICE_no}=" & Val(I) & " and {INVOICEMASTER.INVOICE_cmpid}=" & CmpId & " and {INVOICEMASTER.INVOICE_yearid}=" & YearId
            RPTINV.PrintToPrinter(NOOFCOPIES, True, 0, 0)

        Next
    End Sub

    Function ErrHandle(ByVal Errcode As Integer) As Boolean
        Dim bln As Boolean = False
        If Errcode = -675406840 Then
            MsgBox("Check Internet Connection")
            bln = True
        End If
        Return bln
    End Function

    Public Sub pcase(ByRef txt As Object)
        txt.Text = StrConv(txt.Text, VbStrConv.ProperCase)
    End Sub

    Public Sub uppercase(ByRef txt As Object)
        txt.Text = StrConv(txt.Text, VbStrConv.Uppercase)
    End Sub

    Public Sub lowercase(ByRef txt As Object)
        txt.Text = StrConv(txt.Text, VbStrConv.Lowercase)
    End Sub

#Region "IN WORDS FUNCTION"

    Function CurrencyToWord(ByVal Num As Decimal) As String

        'I have created this function for converting amount in indian rupees (INR). 
        'You can manipulate as you wish like decimal setting, Doller (any currency) Prefix.

        Dim strNum As String
        Dim strNumDec As String
        Dim StrWord As String
        strNum = Num

        If InStr(1, strNum, ".") <> 0 Then
            strNumDec = Mid(strNum, InStr(1, strNum, ".") + 1)

            If Len(strNumDec) = 1 Then
                strNumDec = strNumDec + "0"
            End If
            If Len(strNumDec) > 2 Then
                strNumDec = Mid(strNumDec, 1, 2)
            End If

            strNum = Mid(strNum, 1, InStr(1, strNum, ".") - 1)
            StrWord = IIf(CDbl(strNum) = 1, " Rupee ", " Rupees ") + NumToWord(CDbl(strNum)) + IIf(CDbl(strNumDec) > 0, " and Paise" + cWord3(CDbl(strNumDec)), "")
        Else
            StrWord = IIf(CDbl(strNum) = 1, " Rupee ", " Rupees ") + NumToWord(CDbl(strNum))
        End If
        CurrencyToWord = StrWord & " Only"
        Return CurrencyToWord

    End Function

    Function NumToWord(ByVal Num As Decimal) As String

        'I divided this function in two part.
        '1. Three or less digit number.
        '2. more than three digit number.
        Dim strNum As String
        Dim StrWord As String
        strNum = Num

        If Len(strNum) <= 3 Then
            StrWord = cWord3(CDbl(strNum))
        Else
            StrWord = cWordG3(CDbl(Mid(strNum, 1, Len(strNum) - 3))) + " " + cWord3(CDbl(Mid(strNum, Len(strNum) - 2)))
        End If
        NumToWord = StrWord

    End Function

    Function cWordG3(ByVal Num As Decimal) As String

        '2. more than three digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        strNum = Num
        If Len(strNum) Mod 2 <> 0 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            If readNum <> "0" Then
                StrWord = retWord(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 1) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 2)
        End If
        While Not Len(strNum) = 0
            readNum = CDbl(Mid(strNum, 1, 2))
            If readNum <> "0" Then
                StrWord = StrWord + " " + cWord3(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 2) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 3)
        End While
        cWordG3 = StrWord
        Return cWordG3

    End Function

    Function strReplicate(ByVal str As String, ByVal intD As Integer) As String

        'This fucntion padded "0" after the number to evaluate hundred, thousand and on....
        'using this function you can replicate any Charactor with given string.
        strReplicate = ""
        For i As Integer = 1 To intD
            strReplicate = strReplicate + str
        Next
        Return strReplicate

    End Function

    Function cWord3(ByVal Num As Decimal) As String

        '1. Three or less digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        If Num < 0 Then Num = Num * -1
        strNum = Num

        If Len(strNum) = 3 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            StrWord = retWord(readNum) + " Hundred"
            strNum = Mid(strNum, 2, Len(strNum))
        End If

        If Len(strNum) <= 2 Then
            If CDbl(strNum) >= 0 And CDbl(strNum) <= 20 Then
                StrWord = StrWord + " " + retWord(CDbl(strNum))
            Else
                StrWord = StrWord + " " + retWord(CDbl(Mid(strNum, 1, 1) + "0")) + " " + retWord(CDbl(Mid(strNum, 2, 1)))
            End If
        End If

        strNum = CStr(Num)
        cWord3 = StrWord
        Return cWord3

    End Function

    Function retWord(ByVal Num As Decimal) As String
        'This two dimensional array store the primary word convertion of number.
        retWord = ""
        Dim ArrWordList(,) As Object = {{0, ""}, {1, "One"}, {2, "Two"}, {3, "Three"}, {4, "Four"},
                                        {5, "Five"}, {6, "Six"}, {7, "Seven"}, {8, "Eight"}, {9, "Nine"},
                                        {10, "Ten"}, {11, "Eleven"}, {12, "Twelve"}, {13, "Thirteen"}, {14, "Fourteen"},
                                        {15, "Fifteen"}, {16, "Sixteen"}, {17, "Seventeen"}, {18, "Eighteen"}, {19, "Nineteen"},
                                        {20, "Twenty"}, {30, "Thirty"}, {40, "Forty"}, {50, "Fifty"}, {60, "Sixty"},
                                        {70, "Seventy"}, {80, "Eighty"}, {90, "Ninety"}, {100, "Hundred"}, {1000, "Thousand"},
                                        {100000, "Lakh"}, {10000000, "Crore"}}

        For i As Integer = 0 To UBound(ArrWordList)
            If Num = ArrWordList(i, 0) Then
                retWord = ArrWordList(i, 1)
                Exit For
            End If
        Next
        Return retWord

    End Function

#End Region

    Sub FILLAREA(ByRef cmbname As ComboBox)
        Try
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" AREA_name ", "", " AREAMaster", " and AREA_cmpid=" & CmpId & " AND AREA_LOCATIONID = " & Locationid & " AND AREA_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "AREA_name"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "AREA_name"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub AREAVALIDATE(ByRef CMBAREA As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBAREA.Text.Trim <> "" Then
                uppercase(CMBAREA)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("AREA_name", "", "AREAMaster", " and AREA_name = '" & CMBAREA.Text.Trim & "' AND AREA_CMPID = " & CmpId & " AND AREA_LOCATIONID = " & Locationid & " AND AREA_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBAREA.Text.Trim
                    Dim tempmsg As Integer = MsgBox("AREA not present, Add New?", MsgBoxStyle.YesNo, "PRINTPRO ")
                    If tempmsg = vbYes Then
                        CMBAREA.Text = a
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        objyearmaster.savearea(CMBAREA.Text.Trim, CmpId, Locationid, Userid, YearId, " and AREA_name = '" & CMBAREA.Text.Trim & "' AND AREA_CMPID = " & CmpId & " AND AREA_LOCATIONID = " & Locationid & " AND AREA_YEARID = " & YearId)
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillCOUNTRY(ByRef cmbname As ComboBox)
        Try
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" COUNTRY_name ", "", " COUNTRYMaster", " and COUNTRY_cmpid=" & CmpId & " AND COUNTRY_LOCATIONID = " & Locationid & " AND COUNTRY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "COUNTRY_name"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "COUNTRY_name"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub COUNTRYVALIDATE(ByRef CMBCOUNTRY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCOUNTRY.Text.Trim <> "" Then
                uppercase(CMBCOUNTRY)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("COUNTRY_name", "", "COUNTRYMaster", " and COUNTRY_name = '" & CMBCOUNTRY.Text.Trim & "' AND COUNTRY_CMPID = " & CmpId & " AND COUNTRY_LOCATIONID = " & Locationid & " AND COUNTRY_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBCOUNTRY.Text.Trim
                    Dim tempmsg As Integer = MsgBox("COUNTRY not present, Add New?", MsgBoxStyle.YesNo, " PRINTPRO")
                    If tempmsg = vbYes Then
                        CMBCOUNTRY.Text = a
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        objyearmaster.savecountry(CMBCOUNTRY.Text.Trim, CmpId, Locationid, Userid, YearId, " and COUNTRY_name = '" & CMBCOUNTRY.Text.Trim & "' AND COUNTRY_CMPID = " & CmpId & " AND COUNTRY_LOCATIONID = " & Locationid & " AND COUNTRY_YEARID = " & YearId)
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillSTATE(ByRef cmbname As ComboBox)
        Try
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" STATE_name ", "", " STATEMaster", " and STATE_cmpid=" & CmpId & " AND STATE_LOCATIONID = " & Locationid & " AND STATE_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "STATE_name"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "STATE_name"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub STATEVALIDATE(ByRef CMBSTATE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBSTATE.Text.Trim <> "" Then
                uppercase(CMBSTATE)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("STATE_name", "", "STATEMaster", " and STATE_name = '" & CMBSTATE.Text.Trim & "' AND STATE_CMPID = " & CmpId & " AND STATE_LOCATIONID = " & Locationid & " AND STATE_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBSTATE.Text.Trim
                    Dim tempmsg As Integer = MsgBox("STATE not present, Add New?", MsgBoxStyle.YesNo, "PRINTPRO ")
                    If tempmsg = vbYes Then
                        CMBSTATE.Text = a
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        objyearmaster.savestate(CMBSTATE.Text.Trim, CmpId, Locationid, Userid, YearId, " and STATE_name = '" & CMBSTATE.Text.Trim & "' AND STATE_CMPID = " & CmpId & " AND STATE_LOCATIONID = " & Locationid & " AND STATE_YEARID = " & YearId)
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Function setcolor(ByVal no As Integer) As String
        Try
            Dim str As String = String.Empty
            Dim remainder As Integer
            remainder = no Mod 30
            Select Case remainder
                Case 0
                    str = "Turquoise"
                Case 1
                    str = "LightGreen"
                Case 2
                    str = "LightSkyBlue"
                Case 3
                    str = "Lavender"
                Case 4
                    str = "Plum"
                Case 5
                    str = "Pink"
                Case 6
                    str = "LightCyan"
                Case 7
                    str = "Gold"
                Case 8
                    str = "Silver"
                Case 9
                    str = "Khaki"
                Case 10
                    str = "LIGHTCORAL"
                Case 11
                    str = "MISTYROSE"
                Case 12
                    str = "LIGHTSALMON"
                Case 13
                    str = "SEASHELL"
                Case 14
                    str = "PEACHPUFF"
                Case 15
                    str = "CORNSILK"
                Case 16
                    str = "YELLOWGREEN"
                Case 17
                    str = "HotPink"
                Case 18
                    str = "HONEYDEW"
                Case 19
                    str = "LAVENDER"
                Case 20
                    str = "THISTLE"
                Case 21
                    str = "PINK"
                Case 22
                    str = "GREENYELLOW"
                Case 23
                    str = "SkyBlue"
                Case 24
                    str = "LightCyan"
                Case 25
                    str = "Lime"
                Case 26
                    str = "Wheat"
                Case 27
                    str = "Cornsilk"
                Case 28
                    str = "DarkOrange"
                Case 29
                    str = "PaleVioletRed"
                Case 30
                    str = "LIGHTPINK"

            End Select
            Return str
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Sub fillform(ByRef CHKFORM As CheckedListBox, ByRef edit As Boolean)
        Try
            If CHKFORM.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" form_name ", "", " FORMTYPE", "")
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "FORM_name"
                    CHKFORM.DataSource = dt
                    CHKFORM.DisplayMember = "FORM_name"
                    If edit = False Then CHKFORM.Text = ""
                End If
                CHKFORM.SelectedIndex = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLFORMTYPE(ByRef CMBFORM As ComboBox, ByRef edit As Boolean, Optional ByVal WHERECLAUSE As String = "")
        Try
            If CMBFORM.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" form_name ", "", " FORMTYPE", WHERECLAUSE)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "FORM_name"
                    CMBFORM.DataSource = dt
                    CMBFORM.DisplayMember = "FORM_name"
                    If edit = False Then CMBFORM.Text = ""
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub filltax(ByRef cmbtax As ComboBox, ByRef edit As Boolean)
        Try
            If cmbtax.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" tax_name ", "", " TaxMaster", " and Tax_cmpid=" & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "tax_name"
                    cmbtax.DataSource = dt
                    cmbtax.DisplayMember = "tax_name"
                    If edit = False Then cmbtax.Text = ""
                End If
                cmbtax.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ALPHEBETKEYPRESS(ByVal han As KeyPressEventArgs, ByVal sen As Control, ByVal frm As System.Windows.Forms.Form)
        If (AscW(han.KeyChar) >= 65 And AscW(han.KeyChar) <= 90) Or (AscW(han.KeyChar) >= 97 And AscW(han.KeyChar) <= 122) Or AscW(han.KeyChar) = 8 Then
            han.KeyChar = han.KeyChar
        Else
            han.KeyChar = ""
        End If
        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub

    Sub numdot3(ByVal han As KeyPressEventArgs, ByVal txt As TextBox, ByVal frm As System.Windows.Forms.Form)
        Dim mypos As Integer

        mypos = InStr(1, txt.Text, ".")

        If AscW(han.KeyChar) > 47 And AscW(han.KeyChar) < 58 Or AscW(han.KeyChar) = 8 Or AscW(han.KeyChar) = 46 Then
            han.KeyChar = han.KeyChar
        Else
            han.KeyChar = ""
        End If


        If AscW(han.KeyChar) > 47 And AscW(han.KeyChar) < 58 And mypos <> "0" Then
            If txt.SelectionStart = mypos + 3 Then
                han.KeyChar = ""
            End If
        End If

        If txt.SelectionStart >= mypos Then
            txt.SelectionLength = 1
            han.KeyChar = han.KeyChar
        End If

        If AscW(han.KeyChar) = 46 Then

            'test = True
            mypos = InStr(1, txt.Text, ".")
            If mypos <> "0" Then txt.SelectionStart = mypos
            If mypos = 0 Then
                han.KeyChar = han.KeyChar
            Else
                han.KeyChar = ""
            End If

        End If

        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub

    Sub numdot(ByVal han As KeyPressEventArgs, ByVal txt As TextBox, ByVal frm As System.Windows.Forms.Form)
        Dim mypos As Integer

        mypos = InStr(1, txt.Text, ".")

        If AscW(han.KeyChar) > 47 And AscW(han.KeyChar) < 58 Or AscW(han.KeyChar) = 8 Or AscW(han.KeyChar) = 46 Then
            han.KeyChar = han.KeyChar
        Else
            han.KeyChar = ""
        End If


        If AscW(han.KeyChar) > 47 And AscW(han.KeyChar) < 58 And mypos <> "0" Then
            If txt.SelectionStart = mypos + 2 Then
                han.KeyChar = ""
            End If
        End If

        If txt.SelectionStart >= mypos Then
            txt.SelectionLength = 1
            han.KeyChar = han.KeyChar
        End If

        If AscW(han.KeyChar) = 46 Then

            'test = True
            mypos = InStr(1, txt.Text, ".")
            If mypos <> "0" Then txt.SelectionStart = mypos
            If mypos = 0 Then
                han.KeyChar = han.KeyChar
            Else
                han.KeyChar = ""
            End If

        End If

        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub

    Sub numdotkeypress(ByVal han As KeyPressEventArgs, ByVal sen As Control, ByVal frm As System.Windows.Forms.Form)
        Dim mypos As Integer

        If AscW(han.KeyChar) >= 48 And AscW(han.KeyChar) <= 57 Or AscW(han.KeyChar) = 8 Then
            han.KeyChar = han.KeyChar
        ElseIf AscW(han.KeyChar) = 46 Then
            mypos = InStr(1, sen.Text, ".")
            If mypos = 0 Then
                han.KeyChar = han.KeyChar
            Else
                han.KeyChar = ""
            End If
        Else
            han.KeyChar = ""
        End If

        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub

    Sub numkeypress(ByVal han As KeyPressEventArgs, ByVal sen As Control, ByVal frm As System.Windows.Forms.Form)

        If AscW(han.KeyChar) >= 48 And AscW(han.KeyChar) <= 57 Or AscW(han.KeyChar) = 8 Then
            han.KeyChar = han.KeyChar
        Else
            han.KeyChar = ""
        End If

        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub

    Function getmax(ByVal fldname As String, ByVal tbname As String, Optional ByVal whereclause As String = "") As DataTable
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim DTTABLE As DataTable

            Dim objclscommon As New ClsCommon()
            DTTABLE = objclscommon.GETMAXNO(fldname, tbname, whereclause)

            Return DTTABLE
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Function getfirstdate(ByVal cmpid As Integer, Optional ByVal monthname As String = "", Optional ByVal monthno As Integer = 0) As Date
        Try
            Dim objcmn As New ClsCommon
            Dim ddate As Date
            If monthname <> "" And monthno = 0 Then
                If monthname = "April" Then monthno = 4
                If monthname = "May" Then monthno = 5
                If monthname = "June" Then monthno = 6
                If monthname = "July" Then monthno = 7
                If monthname = "August" Then monthno = 8
                If monthname = "September" Then monthno = 9
                If monthname = "October" Then monthno = 10
                If monthname = "November" Then monthno = 11
                If monthname = "December" Then monthno = 12
                If monthname = "January" Then monthno = 1
                If monthname = "February" Then monthno = 2
                If monthname = "March" Then monthno = 3

                If monthno < 4 Then
                    ddate = (objcmn.getfirstdate(Convert.ToDateTime((monthno & "/01/" & Year(AccTo)))))
                Else
                    ddate = (objcmn.getfirstdate(Convert.ToDateTime((monthno & "/01/" & Year(AccFrom)))))
                End If
            End If
            Return ddate
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function getlastdate(ByVal cmpid As Integer, Optional ByVal monthname As String = "", Optional ByVal monthno As Integer = 0) As Date
        Try
            Dim objcmn As New ClsCommon
            Dim ddate As Date
            If monthname <> "" And monthno = 0 Then
                If monthname = "April" Then monthno = 4
                If monthname = "May" Then monthno = 5
                If monthname = "June" Then monthno = 6
                If monthname = "July" Then monthno = 7
                If monthname = "August" Then monthno = 8
                If monthname = "September" Then monthno = 9
                If monthname = "October" Then monthno = 10
                If monthname = "November" Then monthno = 11
                If monthname = "December" Then monthno = 12
                If monthname = "January" Then monthno = 1
                If monthname = "February" Then monthno = 2
                If monthname = "March" Then monthno = 3

                If monthno < 4 Then
                    ddate = (objcmn.getlastdate(Convert.ToDateTime((monthno & "/01/" & Year(AccTo)))))
                Else
                    ddate = (objcmn.getlastdate(Convert.ToDateTime((monthno & "/01/" & Year(AccFrom)))))
                End If
            End If
            Return ddate
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function datecheck(ByVal dateval As Date) As Boolean
        Dim bln As Boolean = True
        If dateval.Date > AccTo Or dateval.Date < AccFrom Then
            bln = False
        End If
        Return bln
    End Function

    Sub enterkeypress(ByVal han As KeyPressEventArgs, ByVal frm As System.Windows.Forms.Form)
        If AscW(han.KeyChar) = 13 Then
            SendKeys.Send("{Tab}")
            han.KeyChar = ""
        End If
    End Sub

    Sub fillACCCODE(ByRef CMBCODE As ComboBox, Optional ByVal CONDITION As String = "")
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" DISTINCT ACC_CODE ", "", " LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID ", " and ACC_cmpid=" & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & CONDITION)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "ACC_CODE"
                CMBCODE.DataSource = dt
                CMBCODE.DisplayMember = "ACC_CODE"
                CMBCODE.Text = ""
            End If
            CMBCODE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillname(ByRef cmbname As ComboBox, ByRef edit As Boolean, ByVal CONDITION As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" LEDGERS.ACC_cmpname ", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID ", " AND ISNULL(ACC_BLOCKED,0) = 'FALSE' AND LEDGERS.ACC_Yearid=" & YearId & CONDITION)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ACC_cmpname"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "ACC_cmpname"
                    If edit = False Then cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Sub FILLEMP(ByRef CMBEMP As ComboBox, ByRef edit As Boolean)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBEMP.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" EMP_NAME ", "", " EMPLOYEEMASTER", " AND EMP_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "EMP_NAME"
                    CMBEMP.DataSource = dt
                    CMBEMP.DisplayMember = "EMP_NAME"
                    If edit = False Then CMBEMP.Text = ""
                End If
                CMBEMP.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub EMPVALIDATE(ByRef CMBEMP As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBEMP.Text.Trim <> "" Then
                uppercase(CMBEMP)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("EMP_NAME", "", "EMPLOYEEMASTER", " and EMP_NAME = '" & CMBEMP.Text.Trim & "' AND EMP_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBEMP.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Account not present, Add New?", MsgBoxStyle.YesNo, "TEXPRO")
                    If tempmsg = vbYes Then
                        CMBEMP.Text = a
                        Dim OBJEMP As New EmployeeMaster
                        OBJEMP.TEMPEMPNAME = CMBEMP.Text.Trim()
                        OBJEMP.ShowDialog()
                        dt = objclscommon.search("EMP_NAME", "", "EMPLOYEEMASTER", " and EMP_name = '" & CMBEMP.Text.Trim & "' AND EMP_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = CMBEMP.DataSource
                            If CMBEMP.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBEMP.Text.Trim)
                                    CMBEMP.Text = a
                                End If
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
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Sub fillledger(ByRef cmbname As ComboBox, ByRef edit As Boolean, ByVal WHERECLAUSE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" acc_cmpname ", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID", " AND ISNULL(ACC_BLOCKED,0) = 'FALSE' AND ACC_YEARID = " & YearId & WHERECLAUSE)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ACC_cmpname"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "ACC_cmpname"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillCITY(ByRef CMBCITY As ComboBox, ByRef edit As Boolean)
        Try
            If CMBCITY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" CITY_name ", "", " CITYMaster", " and CITY_cmpid=" & CmpId & " AND CITY_LOCATIONID = " & Locationid & " AND CITY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "CITY_name"
                    CMBCITY.DataSource = dt
                    CMBCITY.DisplayMember = "CITY_name"
                    If edit = False Then CMBCITY.Text = ""
                End If
                CMBCITY.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillDESC(ByRef CMBDESC As ComboBox, ByRef edit As Boolean)
        Try
            If CMBDESC.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" distinct  cast (BILL_DESC as varchar(200)) AS DESCRIPTION ", "", " purchasemaster_DESC", " and BILL_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "DESCRIPTION"
                    CMBDESC.DataSource = dt
                    CMBDESC.DisplayMember = "DESCRIPTION"
                    If edit = False Then CMBDESC.Text = ""
                End If
                CMBDESC.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillCATEGORY(ByRef CMBCATEGORY As ComboBox, ByRef edit As Boolean)
        Try
            If CMBCATEGORY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search("category_name", "", "CategoryMaster", " and Category_cmpid = " & CmpId & " AND CATEGORY_LOCATIONID = " & Locationid & " AND CATEGORY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "category_name"
                    CMBCATEGORY.DataSource = dt
                    CMBCATEGORY.DisplayMember = "category_name"
                    If edit = False Then CMBCATEGORY.Text = ""
                End If
                CMBCATEGORY.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillCARTONTYPE(ByRef CMBCARTONTYPE As ComboBox, ByRef edit As Boolean)
        Try
            If CMBCARTONTYPE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search("CARTONTYPE_name", "", "CARTONTYPEMaster", " and CARTONTYPE_cmpid = " & CmpId & " and CARTONTYPE_locationid = " & Locationid & " and CARTONTYPE_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "CARTONTYPE_name"
                    CMBCARTONTYPE.DataSource = dt
                    CMBCARTONTYPE.DisplayMember = "CARTONTYPE_name"
                    If edit = False Then CMBCARTONTYPE.Text = ""
                End If
                CMBCARTONTYPE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillCOORDINATOR(ByRef CMBCOORDINATOR As ComboBox, ByRef edit As Boolean)
        Try
            If CMBCOORDINATOR.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" COORDINATOR_NAME ", "", " COORDINATORMaster ", " and COORDINATOR_cmpid=" & CmpId & " and COORDINATOR_locationid=" & Locationid & " and COORDINATOR_yearid=" & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "COORDINATOR_NAME"
                    CMBCOORDINATOR.DataSource = dt
                    CMBCOORDINATOR.DisplayMember = "COORDINATOR_NAME"
                    CMBCOORDINATOR.Text = ""
                    If edit = False Then CMBCOORDINATOR.Text = ""
                End If
                CMBCOORDINATOR.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillGODOWN(ByRef CMBGODOWN As ComboBox, ByRef edit As Boolean)
        Try
            If CMBGODOWN.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                Dim WHERECLAUSE As String = ""
                dt = objclscommon.search(" GODOWN_name ", "", " GODOWNMaster", WHERECLAUSE & " and GODOWN_cmpid=" & CmpId & " AND GODOWN_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "GODOWN_name"
                    CMBGODOWN.DataSource = dt
                    CMBGODOWN.DisplayMember = "GODOWN_name"
                    If edit = False Then CMBGODOWN.Text = ""
                End If
                CMBGODOWN.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Sub FILLMACHINE(ByRef CMBMACHINE As ComboBox)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBMACHINE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" MACHINE_ID AS ID , MACHINE_NAME AS NAME ", "", " MACHINEMASTER ", " And MACHINE_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "NAME"
                    CMBMACHINE.DataSource = dt
                    CMBMACHINE.DisplayMember = "NAME"
                    CMBMACHINE.ValueMember = "ID"
                    CMBMACHINE.SelectedItem = Nothing
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub MACHINEVALIDATE(ByRef CMBMACHINE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If CMBMACHINE.Text.Trim <> "" Then
                uppercase(CMBMACHINE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" MACHINE_NAME ", "", "MACHINEMASTER", " and MACHINE_NAME = '" & CMBMACHINE.Text.Trim & "' and MACHINE_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Machine No not present, Add New?", MsgBoxStyle.YesNo, "TEXTRADE")
                    If tempmsg = vbYes Then
                        Dim a As String = CMBMACHINE.Text.Trim
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBMACHINE.Text.Trim)
                        alParaval.Add(0)    'AREA
                        alParaval.Add(0)    'LENGTH
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)


                        Dim objRACK As New ClsMachineMaster
                        objRACK.alParaval = alParaval
                        Dim IntResult As Integer = objRACK.SAVE()


                        dt = objclscommon.search(" MACHINE_ID AS ID, MACHINE_NAME AS NAME ", "", "MACHINEMASTER", " and MACHINE_NAME = '" & CMBMACHINE.Text.Trim & "' and MACHINE_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBMACHINE.DataSource
                            If CMBMACHINE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("ID"), CMBMACHINE.Text.Trim)
                                    CMBMACHINE.Text = a
                                End If
                            End If
                        End If

                    Else
                        CMBMACHINE.Focus()
                        CMBMACHINE.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub


    Sub fillDESIGN(ByRef CMBdesign As ComboBox, ByRef edit As Boolean)
        Try
            If CMBdesign.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search("design_name", "", "designMaster", " and design_cmpid = " & CmpId & " and design_locationid = " & Locationid & " and design_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "design_name"
                    CMBdesign.DataSource = dt
                    CMBdesign.DisplayMember = "design_name"
                    CMBdesign.Text = ""
                    If edit = False Then CMBdesign.Text = ""
                End If
                CMBdesign.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillSHELF(ByRef CMBSHELF As ComboBox, ByRef edit As Boolean)
        Try
            If CMBSHELF.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search("SHELF_name", "", "SHELFMaster", " and SHELF_cmpid = " & CmpId & " and SHELF_locationid = " & Locationid & " and SHELF_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "SHELF_name"
                    CMBSHELF.DataSource = dt
                    CMBSHELF.DisplayMember = "SHELF_name"
                    CMBSHELF.Text = ""
                    If edit = False Then CMBSHELF.Text = ""
                End If
                CMBSHELF.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLDEPARTMNET(ByRef CMBDEPARTMENT As ComboBox, ByRef edit As Boolean)
        Try
            If CMBDEPARTMENT.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search("DEPARTMENT_name", "", "DEPARTMENTMaster", " and DEPARTMENT_cmpid = " & CmpId & " and DEPARTMENT_locationid = " & Locationid & " and DEPARTMENT_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "DEPARTMENT_name"
                    CMBDEPARTMENT.DataSource = dt
                    CMBDEPARTMENT.DisplayMember = "DEPARTMENT_name"
                    CMBDEPARTMENT.Text = ""
                    If edit = False Then CMBDEPARTMENT.Text = ""
                End If
                CMBDEPARTMENT.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLNONINVITEM(ByRef CMBNONINVITEMM As ComboBox, ByRef edit As Boolean, Optional ByVal WHERECLAUSE As String = "")
        Try
            If CMBNONINVITEMM.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search("NONINV_name", "", "NONINVITEMMASTER", WHERECLAUSE & " and NONINV_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "NONINV_name"
                    CMBNONINVITEMM.DataSource = dt
                    CMBNONINVITEMM.DisplayMember = "NONINV_name"
                    CMBNONINVITEMM.Text = ""
                    If edit = False Then CMBNONINVITEMM.Text = ""
                End If
                CMBNONINVITEMM.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLINVITEMNAME(ByRef CMBINVITEMNAME As ComboBox, ByRef edit As Boolean, Optional ByVal WHERECLAUSE As String = "")
        Try
            If CMBINVITEMNAME.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search("NONINV_name", "", "NONINVITEMMASTER", WHERECLAUSE & " and NONINV_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "NONINV_name"
                    CMBINVITEMNAME.DataSource = dt
                    CMBINVITEMNAME.DisplayMember = "NONINV_name"
                    CMBINVITEMNAME.Text = ""
                    If edit = False Then CMBINVITEMNAME.Text = ""
                End If
                CMBINVITEMNAME.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillGRAIN(ByRef CMBGRAIN As ComboBox, ByRef edit As Boolean)
        Try
            If CMBGRAIN.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search("GRAIN_name", "", "GRAINMaster", " and GRAIN_cmpid = " & CmpId & " and GRAIN_locationid = " & Locationid & " and GRAIN_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "GRAIN_name"
                    CMBGRAIN.DataSource = dt
                    CMBGRAIN.DisplayMember = "GRAIN_name"
                    CMBGRAIN.Text = ""
                    If edit = False Then CMBGRAIN.Text = ""
                End If
                CMBGRAIN.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillPAPERDESIGN(ByRef CMBpaperdesign As ComboBox, ByRef edit As Boolean)
        Try
            If CMBpaperdesign.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search("paperdesign_name", "", "paperdesignMaster", " and paperdesign_cmpid = " & CmpId & " and paperdesign_locationid = " & Locationid & " and paperdesign_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "paperdesign_name"
                    CMBpaperdesign.DataSource = dt
                    CMBpaperdesign.DisplayMember = "paperdesign_name"
                    If edit = False Then CMBpaperdesign.Text = ""
                End If
                CMBpaperdesign.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillTEARTAPE(ByRef cmbperforatedtape As ComboBox, ByRef edit As Boolean)
        Try
            If cmbperforatedtape.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search("TEARTAPE_name", "", "TEARTAPEMaster", " and TEARTAPE_cmpid = " & CmpId & " and TEARTAPE_locationid = " & Locationid & " and TEARTAPE_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "TEARTAPE_name"
                    cmbperforatedtape.DataSource = dt
                    cmbperforatedtape.DisplayMember = "TEARTAPE_name"
                    If edit = False Then cmbperforatedtape.Text = ""
                End If
                cmbperforatedtape.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillPAPERGSM(ByRef CMBPAPERGSM As ComboBox, ByRef edit As Boolean)
        Try
            If CMBPAPERGSM.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search("PAPERGSM_name", "", "PAPERGSMMaster", " and  PAPERGSM_cmpid = " & CmpId & " AND PAPERGSM_LOCATIONID = " & Locationid & " AND PAPERGSM_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "PAPERGSM_name"
                    CMBPAPERGSM.DataSource = dt
                    CMBPAPERGSM.DisplayMember = "PAPERGSM_name"
                    CMBPAPERGSM.Text = ""
                    If edit = False Then CMBPAPERGSM.Text = ""
                End If
                CMBPAPERGSM.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillMATERIAL(ByRef cmbmaterial As ComboBox, ByRef edit As Boolean)
        Try
            If cmbmaterial.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search("PAPERMATERIAL_name", "", "PAPERMATERIALMaster", " and  PAPERMATERIAL_cmpid = " & CmpId & " AND PAPERMATERIAL_LOCATIONID = " & Locationid & " AND PAPERMATERIAL_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "PAPERMATERIAL_name"
                    cmbmaterial.DataSource = dt
                    cmbmaterial.DisplayMember = "PAPERMATERIAL_name"
                    cmbmaterial.Text = ""
                    If edit = False Then cmbmaterial.Text = ""
                End If
                cmbmaterial.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLPAPERMILL(ByRef cmbmaterial As ComboBox, ByRef edit As Boolean)
        Try
            If cmbmaterial.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search("PAPERMILL_name", "", "PAPERMILLMASTER", " and  PAPERMILL_cmpid = " & CmpId & " AND PAPERMILL_LOCATIONID = " & Locationid & " AND PAPERMILL_YEARID = " & YearId)
                cmbmaterial.DataSource = dt
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "PAPERMILL_name"
                    cmbmaterial.DataSource = dt
                    cmbmaterial.DisplayMember = "PAPERMILL_name"
                    cmbmaterial.Text = ""
                    If edit = False Then cmbmaterial.Text = ""
                End If
                cmbmaterial.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLSUPERVISOR(ByRef CMBSUPERVISOR As ComboBox, ByRef edit As Boolean, Optional ByVal CONDITION As String = "")
        Try
            If CMBSUPERVISOR.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" SUP_NAME ", "", " SUPERVISORMASTER", " and SUP_YEARID = " & YearId & CONDITION)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "SUP_NAME"
                    CMBSUPERVISOR.DataSource = dt
                    CMBSUPERVISOR.DisplayMember = "SUP_NAME"
                    If edit = False Then CMBSUPERVISOR.Text = ""
                End If
                CMBSUPERVISOR.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SUPERVISORVALIDATE(ByRef CMBSUPERVISOR As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBSUPERVISOR.Text.Trim <> "" Then
                uppercase(CMBSUPERVISOR)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" SUP_NAME", "", " SUPERVISORMASTER", " and SUP_NAME = '" & CMBSUPERVISOR.Text.Trim & "' and SUP_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Supervisor not present, Add New?", MsgBoxStyle.YesNo, "PRINTPRO")
                    If tempmsg = vbYes Then
                        Dim OBJGUEST As New SupervisorMaster
                        OBJGUEST.TXTSUPERVISOR.Text = CMBSUPERVISOR.Text.Trim()

                        OBJGUEST.ShowDialog()
                        OBJGUEST.BringToFront()
                        dt = objclscommon.search(" SUP_NAME", "", " SUPERVISORMASTER", " and SUP_NAME = '" & CMBSUPERVISOR.Text.Trim & "' and SUP_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBSUPERVISOR.Text.Trim
                            dt1 = CMBSUPERVISOR.DataSource
                            If CMBSUPERVISOR.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBSUPERVISOR.Text.Trim)
                                    CMBSUPERVISOR.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        CMBSUPERVISOR.Focus()
                        CMBSUPERVISOR.SelectAll()
                        e.Cancel = True
                    End If
                Else
                    CMBSUPERVISOR.Text = dt.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLPAPERSIZE(ByRef CMBPAPERSIZE As ComboBox, ByRef edit As Boolean)
        Try
            If CMBPAPERSIZE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search("PAPERSIZE_name", "", "papersizemaster", " and  PAPERSIZE_cmpid = " & CmpId & " AND PAPERSIZE_LOCATIONID = " & Locationid & " AND PAPERSIZE_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "PAPERSIZE_name"
                    CMBPAPERSIZE.DataSource = dt
                    CMBPAPERSIZE.DisplayMember = "PAPERSIZE_name"
                    CMBPAPERSIZE.Text = ""
                    If edit = False Then CMBPAPERSIZE.Text = ""
                End If
                CMBPAPERSIZE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillPUNCHSPEC(ByRef cmbpunchspec As ComboBox, ByRef edit As Boolean)
        Try
            If cmbpunchspec.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search("PUNCHSPEC_name", "", "PUNCHSPECMaster", " and PUNCHSPEC_cmpid = " & CmpId & " and PUNCHSPEC_locationid = " & Locationid & " and PUNCHSPEC_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "PUNCHSPEC_name"
                    cmbpunchspec.DataSource = dt
                    cmbpunchspec.DisplayMember = "PUNCHSPEC_name"
                    If edit = False Then cmbpunchspec.Text = ""
                End If
                cmbpunchspec.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillLONGGRAIN(ByRef cmblongshort As ComboBox, ByRef edit As Boolean)
        Try
            If cmblongshort.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search("LONGGRAIN_name", "", "LONGGRAINMaster", " and LONGGRAIN_cmpid = " & CmpId & " and LONGGRAIN_locationid = " & Locationid & " and LONGGRAIN_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "LONGGRAIN_name"
                    cmblongshort.DataSource = dt
                    cmblongshort.DisplayMember = "LONGGRAIN_name"
                    If edit = False Then cmblongshort.Text = ""
                End If
                cmblongshort.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillITEMCODE(ByRef CMBITEMCODE As ComboBox, ByRef edit As Boolean, Optional ByVal WHERECLAUSE As String = "")
        Try
            If CMBITEMCODE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" ITEM_CODE ", "", " ITEMMaster", " and ITEM_cmpid=" & CmpId & "  AND ISNULL(ITEM_BLOCKED,0) = 'FALSE' AND ITEM_LOCATIONID = " & Locationid & " AND ITEM_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ITEM_CODE"
                    CMBITEMCODE.DataSource = dt
                    CMBITEMCODE.DisplayMember = "ITEM_CODE"
                    If edit = False Then CMBITEMCODE.Text = ""
                End If
                'CMBITEMCODE.SelectAll()
                CMBITEMCODE.SelectedItem = Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillITEMNAME(ByRef CMBITEMNAME As ComboBox, ByRef edit As Boolean, Optional ByVal WHERECLAUSE As String = "")
        Try
            If CMBITEMNAME.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" ITEM_NAME ", "", " ITEMMaster", " and ITEM_cmpid=" & CmpId & " AND ISNULL(ITEM_BLOCKED,0) = 'FALSE' AND  ITEM_LOCATIONID = " & Locationid & " AND ITEM_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ITEM_NAME"
                    CMBITEMNAME.DataSource = dt
                    CMBITEMNAME.DisplayMember = "ITEM_NAME"
                    CMBITEMNAME.Text = ""

                End If
                CMBITEMNAME.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLSUBITEMCODE(ByRef CMBSUBITEM As ComboBox, ByRef edit As Boolean, Optional ByVal WHERECLAUSE As String = "")
        Try
            If CMBSUBITEM.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" ITEM_CODE ", "", " ITEMMaster", " AND ITEM_YEARID = " & YearId & WHERECLAUSE)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ITEM_CODE"
                    CMBSUBITEM.DataSource = dt
                    CMBSUBITEM.DisplayMember = "ITEM_CODE"
                    CMBSUBITEM.Text = ""

                End If
                CMBSUBITEM.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Sub fillregister(ByRef cmbregister As ComboBox, ByVal condition As String)
        Try
            If cmbregister.Text.Trim = "" Then

                Dim objclscommon As New ClsCommon
                Dim dt As DataTable
                dt = objclscommon.search(" Register_name ", "", "RegisterMaster ", condition & " and Register_cmpid=" & CmpId & " and REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Register_name"
                    cmbregister.DataSource = dt
                    cmbregister.DisplayMember = "Register_name"
                    cmbregister.Text = ""
                End If
                cmbregister.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub namevalidate(ByRef cmbname As ComboBox, ByRef CMBACCCODE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef txtadd As System.Windows.Forms.TextBox, ByVal WHERECLAUSE As String, Optional ByVal GROUPNAME As String = "", Optional ByVal TYPE As String = "ACCOUNTS", Optional ByRef TRANSNAME As String = "", Optional ByRef AGENTNAME As String = "", Optional ByRef WHATSAPPNO As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim <> "" Then
                uppercase(cmbname)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("LEDGERS.acc_add, isnull(LEDGERS.ACC_CODE,'') as CODE,LEDGERS_1.ACC_CMPNAME AS TRANSNAME,LEDGERS_2.ACC_CMPNAME AS AGENTNAME ", "", "    LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_1.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_1.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_2.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_2.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_2.Acc_yearid ", " and LEDGERS.acc_cmpname = '" & cmbname.Text.Trim & "' and LEDGERS.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.acc_YEARid = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbname.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Ledger not present, Add New?", MsgBoxStyle.YesNo, "PRINTPRO")
                    If tempmsg = vbYes Then
                        cmbname.Text = a
                        Dim objVendormaster As New AccountsMaster
                        objVendormaster.frmstring = "ACCOUNTS"
                        objVendormaster.tempAccountsName = cmbname.Text.Trim()
                        objVendormaster.TEMPGROUPNAME = GROUPNAME
                        objVendormaster.tempTYPE = TYPE

                        objVendormaster.ShowDialog()
                        dt = objclscommon.search("LEDGERS.acc_add, isnull(LEDGERS.ACC_CODE,'') as CODE,LEDGERS_1.ACC_CMPNAME AS TRANSNAME,LEDGERS_2.ACC_CMPNAME AS AGENTNAME ", "", "    LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_1.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_1.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_2.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_2.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_2.Acc_yearid ", " and LEDGERS.acc_cmpname = '" & cmbname.Text.Trim & "' and LEDGERS.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.acc_YEARid = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = cmbname.DataSource
                            If cmbname.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbname.Text.Trim)
                                    cmbname.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    txtadd.Text = dt.Rows(0).Item(0).ToString
                    If TRANSNAME = "" Then TRANSNAME = dt.Rows(0).Item(2).ToString
                    If AGENTNAME = "" Then AGENTNAME = dt.Rows(0).Item(3).ToString
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub ledgervalidate(ByRef cmbname As ComboBox, ByVal CMBACCCODE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef txtadd As System.Windows.Forms.TextBox, ByVal WHERECLAUSE As String, Optional ByVal GROUPNAME As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim <> "" Then
                uppercase(cmbname)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("acc_add, isnull( ACC_CODE,''), REGISTER_NAME AS REGISTERNAME", "", " LEDGERS INNER JOIN GROUPMASTER ON GROUPMASTER.group_id = LEDGERS.Acc_groupid AND GROUPMASTER.group_cmpid = LEDGERS.Acc_cmpid AND GROUPMASTER.group_locationid = LEDGERS.Acc_locationid AND GROUPMASTER.group_yearid = LEDGERS.Acc_yearid LEFT OUTER JOIN REGISTERMASTER ON LEDGERS.ACC_REGISTERID = REGISTERMASTER.register_id AND LEDGERS.Acc_cmpid = REGISTERMASTER.register_cmpid AND LEDGERS.Acc_locationid = REGISTERMASTER.register_locationid AND LEDGERS.Acc_yearid = REGISTERMASTER.register_yearid ", " and acc_cmpname = '" & cmbname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbname.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Account not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        cmbname.Text = a
                        Dim objVendormaster As New AccountsMaster
                        objVendormaster.frmstring = "ACCOUNTS"
                        objVendormaster.tempAccountsName = cmbname.Text.Trim()
                        objVendormaster.TEMPGROUPNAME = GROUPNAME
                        objVendormaster.ShowDialog()
                        dt = objclscommon.search("acc_add, REGISTER_NAME AS REGISTERNAME", "", " LEDGERS INNER JOIN GROUPMASTER ON GROUPMASTER.group_id = LEDGERS.Acc_groupid AND GROUPMASTER.group_cmpid = LEDGERS.Acc_cmpid AND GROUPMASTER.group_locationid = LEDGERS.Acc_locationid AND GROUPMASTER.group_yearid = LEDGERS.Acc_yearid LEFT OUTER JOIN REGISTERMASTER ON LEDGERS.ACC_REGISTERID = REGISTERMASTER.register_id AND LEDGERS.Acc_cmpid = REGISTERMASTER.register_cmpid AND LEDGERS.Acc_locationid = REGISTERMASTER.register_locationid AND LEDGERS.Acc_yearid = REGISTERMASTER.register_yearid ", " and acc_cmpname = '" & cmbname.Text.Trim & "' AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            dt1 = cmbname.DataSource
                            If cmbname.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbname.Text.Trim)
                                    cmbname.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                Else
                    txtadd.Text = dt.Rows(0).Item(0).ToString
                    CMBACCCODE.Text = dt.Rows(0).Item(1)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FORMvalidate(ByRef cmbform As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbform.Text.Trim <> "" Then
                uppercase(cmbform)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("FORM_NAME", "", "FORMTYPE", " and FORM_NAME = '" & cmbform.Text.Trim & "'")
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbform.Text.Trim
                    Dim tempmsg As Integer = MsgBox("FORM not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        cmbform.Text = a
                        Dim OBJFORM As New citymaster
                        OBJFORM.frmstring = "FORMTYPE"
                        OBJFORM.txtname.Text = cmbform.Text.Trim()
                        OBJFORM.ShowDialog()
                        dt = objclscommon.search("FORM_name", "", "FORMTYPE", " and FORM_name = '" & cmbform.Text.Trim & "'")
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = cmbform.DataSource
                            If cmbform.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbform.Text.Trim)
                                    cmbform.Text = a
                                End If
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
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub SUBITEMCODEVALIDATE(ByRef CMBSBITEMCODE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, Optional WHERECLAUSE As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBSBITEMCODE.Text.Trim <> "" Then
                uppercase(CMBSBITEMCODE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("ITEM_CODE AS CODE,ITEM_NAME AS ITEMNAME", "", "ITEMMASTER", " and ITEM_CODE = '" & CMBSBITEMCODE.Text.Trim & "' and ITEM_cmpid = " & CmpId & " and ITEM_Locationid = " & Locationid & " and ITEM_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBSBITEMCODE.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Itemcode not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        CMBSBITEMCODE.Text = a
                        Dim OBJitemcode As New ItemMaster
                        OBJitemcode.frmstring = "itemcode"
                        OBJitemcode.TEMPITEMCODE = CMBSBITEMCODE.Text.Trim
                        OBJitemcode.ShowDialog()
                        dt = objclscommon.search("ITEM_CODE AS CODE,ITEM_NAME AS ITEMNAME", "", "itemmaster", " and item_code = '" & CMBSBITEMCODE.Text.Trim & "' and item_cmpid = " & CmpId & " and item_Locationid = " & Locationid & " and item_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBSBITEMCODE.DataSource
                            If CMBSBITEMCODE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBSBITEMCODE.Text.Trim)
                                    CMBSBITEMCODE.Text = a
                                End If
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
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub ITEMCODEvalidate(ByRef cmbITEMCODE As ComboBox, ByRef CMBITEMNAME As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbITEMCODE.Text.Trim <> "" Then
                uppercase(cmbITEMCODE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("ITEM_CODE AS CODE,ITEM_NAME AS ITEMNAME", "", "ITEMMASTER", " and ITEM_CODE = '" & cmbITEMCODE.Text.Trim & "' and ITEM_cmpid = " & CmpId & " AND  ISNULL(ITEM_BLOCKED,0) = 'FALSE' and ITEM_Locationid = " & Locationid & " and ITEM_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbITEMCODE.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Itemcode not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        cmbITEMCODE.Text = a
                        Dim OBJitemcode As New ItemMaster
                        OBJitemcode.frmstring = "itemcode"
                        OBJitemcode.TEMPITEMCODE = cmbITEMCODE.Text.Trim
                        OBJitemcode.ShowDialog()
                        dt = objclscommon.search("ITEM_CODE AS CODE,ITEM_NAME AS ITEMNAME", "", "itemmaster", " and item_code = '" & cmbITEMCODE.Text.Trim & "' and item_cmpid = " & CmpId & " AND  ISNULL(ITEM_BLOCKED,0) = 'FALSE'  AND item_Locationid = " & Locationid & " and item_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = cmbITEMCODE.DataSource
                            If cmbITEMCODE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbITEMCODE.Text.Trim)
                                    cmbITEMCODE.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If

                Else
                    CMBITEMNAME.Text = dt.Rows(0).Item(1)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub ITEMNAMEVALIDATE(ByRef CMBITEMNAME As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, Optional ByVal WHERECLAUSE As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBITEMNAME.Text.Trim <> "" Then
                uppercase(CMBITEMNAME)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("ITEM_CODE AS CODE,ITEM_NAME AS ITEMNAME", "", "ITEMMASTER", " and ITEM_NAME = '" & CMBITEMNAME.Text.Trim & "' and ITEM_cmpid = " & CmpId & " and ITEM_Locationid = " & Locationid & " and ITEM_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBITEMNAME.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Item Name not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        CMBITEMNAME.Text = a
                        Dim OBJitemcode As New ItemMaster
                        OBJitemcode.frmstring = "itemNAME"
                        OBJitemcode.TEMPITEMNAME = CMBITEMNAME.Text.Trim
                        OBJitemcode.ShowDialog()
                        dt = objclscommon.search("ITEM_CODE AS CODE,ITEM_NAME AS ITEMNAME", "", "itemmaster", " and item_NAME = '" & CMBITEMNAME.Text.Trim & "' and item_cmpid = " & CmpId & " and item_Locationid = " & Locationid & " and item_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBITEMNAME.DataSource
                            If CMBITEMNAME.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBITEMNAME.Text.Trim)
                                    CMBITEMNAME.Text = a
                                End If
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
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub MATERIALVALIDATE(ByRef CMBMATERIAL As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBMATERIAL.Text.Trim <> "" Then
                uppercase(CMBMATERIAL)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("papermaterial_name", "", "papermaterialMaster", " and  papermaterial_NAME = '" & CMBMATERIAL.Text.Trim & "' and papermaterial_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Material not present, Add New?", MsgBoxStyle.YesNo, "PRINTPRO")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBMATERIAL.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)
                        alParaval.Add("PAPERMATERIAL")

                        Dim objclspapermat As New ClsPaperMaterial
                        objclspapermat.alParaval = alParaval
                        Dim IntResult As Integer = objclspapermat.save()
                    Else
                        CMBMATERIAL.Focus()
                        CMBMATERIAL.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub


    Sub PAPERMILLVALIDATE(ByRef CMBPAPERMILL As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBPAPERMILL.Text.Trim <> "" Then
                uppercase(CMBPAPERMILL)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("PAPERMILL_name", "", "PAPERMILLMaster", " and  PAPERMILL_NAME = '" & CMBPAPERMILL.Text.Trim & "' and PAPERMILL_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Material not present, Add New?", MsgBoxStyle.YesNo, "PRINTPRO")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBPAPERMILL.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)
                        alParaval.Add("PAPERMILL")

                        Dim objclspapermat As New ClsPaperMaterial
                        objclspapermat.alParaval = alParaval
                        Dim IntResult As Integer = objclspapermat.save()
                    Else
                        CMBPAPERMILL.Focus()
                        CMBPAPERMILL.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub GODOWNVALIDATE(ByRef CMBGODOWN As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBGODOWN.Text.Trim <> "" Then
                uppercase(CMBGODOWN)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("GODOWN_id", "", "GODOWNMaster", " and GODOWN_NAME = '" & CMBGODOWN.Text.Trim & "' and GODOWN_cmpid = " & CmpId & " and GODOWN_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("GODOWN not present, Add New?", MsgBoxStyle.YesNo, "PRINTPRO")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(UCase(CMBGODOWN.Text.Trim))
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsGODOWN As New ClsGodownmaster
                        objclsGODOWN.alParaval = alParaval
                        Dim IntResult As Integer = objclsGODOWN.save()
                    Else
                        CMBGODOWN.Focus()
                        CMBGODOWN.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub GRAINVALIDATE(ByRef CMBGRAIN As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBGRAIN.Text.Trim <> "" Then
                uppercase(CMBGRAIN)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("GRAIN_name", "", "GRAINMaster", " and GRAIN_name = '" & CMBGRAIN.Text.Trim & "' and GRAIN_cmpid = " & CmpId & " and GRAIN_Locationid = " & Locationid & " and GRAIN_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Grain Direction not present, Add New?", MsgBoxStyle.YesNo, "PRINTPRO")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBGRAIN.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)
                        alParaval.Add("GRAINDIRECTION")

                        Dim objclspapermat As New ClsPaperMaterial
                        objclspapermat.alParaval = alParaval
                        Dim IntResult As Integer = objclspapermat.save()
                        'e.Cancel = True
                    Else
                        CMBGRAIN.Focus()
                        CMBGRAIN.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub unitvalidate(ByRef cmbunit As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            Cursor.Current = Cursors.WaitCursor
            If cmbunit.Text.Trim <> "" Then
                lowercase(cmbunit)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" unit_abbr ", "", "UnitMaster", " and unit_abbr = '" & cmbunit.Text.Trim & "' and unit_cmpid = " & CmpId & " and unit_Locationid = " & Locationid & " and unit_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbunit.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Unit not present, Add New?", MsgBoxStyle.YesNo, "PRINTPRO")
                    If tempmsg = vbYes Then
                        cmbunit.Text = a
                        Dim objunitmaster As New UnitMaster
                        objunitmaster.txtabbr.Text = cmbunit.Text.Trim()
                        objunitmaster.ShowDialog()
                        dt = objclscommon.search(" unit_abbr ", "", "UnitMaster", " and unit_abbr = '" & cmbunit.Text.Trim & "' and unit_cmpid = " & CmpId & " and unit_Locationid = " & Locationid & " and unit_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = cmbunit.DataSource
                            If cmbunit.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbunit.Text.Trim)
                                    cmbunit.Text = a
                                End If
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
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub NONINVITEMVALIDATE(ByRef CMBNONINVITEM As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)

        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBNONINVITEM.Text.Trim <> "" Then
                uppercase(CMBNONINVITEM)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" NONINV_NAME ", "", "NONINVITEMMASTER", " and NONINV_NAME = '" & CMBNONINVITEM.Text.Trim & "'  and NONINV_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBNONINVITEM.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Item Name not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        CMBNONINVITEM.Text = a
                        Dim OBJitem As New NonInvItemMaster
                        OBJitem.tempINVITEMname = CMBNONINVITEM.Text.Trim()
                        OBJitem.ShowDialog()
                        dt = objclscommon.search(" NONINV_NAME ", "", "NONINVITEMMASTER", " and NONINV_NAME = '" & CMBNONINVITEM.Text.Trim & "'  and NONINV_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBNONINVITEM.DataSource
                            If CMBNONINVITEM.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBNONINVITEM.Text.Trim)
                                    CMBNONINVITEM.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If

                Else

                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub DESIGNVALIDATE(ByRef cmbdesign As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbdesign.Text.Trim <> "" Then
                uppercase(cmbdesign)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("DESIGN_name", "", "DESIGNMaster", " and DESIGN_name = '" & cmbdesign.Text.Trim & "' and DESIGN_cmpid = " & CmpId & " and DESIGN_Locationid = " & Locationid & " and DESIGN_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("DESIGN not present, Add New?", MsgBoxStyle.YesNo, "PRINTPRO")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(cmbdesign.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)
                        alParaval.Add("PAPERDESIGN")

                        Dim objclspapermat As New ClsPaperMaterial
                        objclspapermat.alParaval = alParaval
                        Dim IntResult As Integer = objclspapermat.save()
                        'e.Cancel = True
                    Else
                        cmbdesign.Focus()
                        cmbdesign.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PAPERGSMVALIDATE(ByRef CMBPAPERGSM As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBPAPERGSM.Text.Trim <> "" Then
                uppercase(CMBPAPERGSM)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("PAPERGSM_name", "", "PAPERGSMMaster", " and PAPERGSM_name = '" & CMBPAPERGSM.Text.Trim & "' and PAPERGSM_cmpid = " & CmpId & " and PAPERGSM_Locationid = " & Locationid & " and PAPERGSM_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("PAPERGSM not present, Add New?", MsgBoxStyle.YesNo, "PRINTPRO")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBPAPERGSM.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)
                        alParaval.Add("PAPERGSM")

                        Dim objclspapermat As New ClsPaperMaterial
                        objclspapermat.alParaval = alParaval
                        Dim IntResult As Integer = objclspapermat.save()
                        'e.Cancel = True
                    Else
                        CMBPAPERGSM.Focus()
                        CMBPAPERGSM.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PAPERSIZEVALIDATE(ByRef CMBPAPERSIZE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBPAPERSIZE.Text.Trim <> "" Then
                uppercase(CMBPAPERSIZE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("PAPERSIZE_name", "", "PAPERSIZEMaster", " AND PAPERSIZE_NAME = '" & CMBPAPERSIZE.Text.Trim & "' and  PAPERSIZE_cmpid = " & CmpId & " and PAPERSIZE_Locationid = " & Locationid & " and PAPERSIZE_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("PAPERSIZE not present, Add New?", MsgBoxStyle.YesNo, "PRINTPRO")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBPAPERSIZE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)
                        alParaval.Add("PAPERSIZE")

                        Dim objclspapermat As New ClsPaperMaterial
                        objclspapermat.alParaval = alParaval
                        Dim IntResult As Integer = objclspapermat.save()
                        'e.Cancel = True
                    Else
                        CMBPAPERSIZE.Focus()
                        CMBPAPERSIZE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub TAXvalidate(ByRef CMBTAX As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBTAX.Text.Trim <> "" Then
                uppercase(CMBTAX)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("TAX_NAME", "", "TAXMaster", " and TAX_NAME = '" & CMBTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBTAX.Text.Trim
                    Dim tempmsg As Integer = MsgBox("TAX not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        CMBTAX.Text = a
                        Dim OBJTAX As New Taxmaster
                        OBJTAX.txtname.Text = CMBTAX.Text.Trim()
                        OBJTAX.ShowDialog()
                        dt = objclscommon.search("TAX_name", "", "TAXMaster", " and TAX_name = '" & CMBTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBTAX.DataSource
                            If CMBTAX.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBTAX.Text.Trim)
                                    CMBTAX.Text = a
                                End If
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
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLNATURE(ByRef CMBNATURE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" PAY_name ", "", " NATUREOFPAYMENTMaster", "")
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "PAY_name"
                CMBNATURE.DataSource = dt
                CMBNATURE.DisplayMember = "PAY_name"
                CMBNATURE.Text = ""
            End If
            CMBNATURE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub NATUREVALIDATE(ByRef CMBNATURE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBNATURE.Text.Trim <> "" Then
                uppercase(CMBNATURE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("PAY_id", "", "NATUREOFPAYMENTMASTER", " and PAY_NAME = '" & CMBNATURE.Text.Trim & "'")
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("NATURE OF PAYMENT not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBNATURE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim OBJNATUREOFPAYMENT As New ClsNatureOfPayment
                        OBJNATUREOFPAYMENT.alParaval = alParaval
                        Dim IntResult As Integer = OBJNATUREOFPAYMENT.SAVE()
                    Else
                        CMBNATURE.Focus()
                        CMBNATURE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillDEDUCTEETYPE(ByRef cmbDEDUCTEE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" DEDUCTEETYPE_name ", "", " DEDUCTEETYPEMaster", "")
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "DEDUCTEETYPE_name"
                cmbDEDUCTEE.DataSource = dt
                cmbDEDUCTEE.DisplayMember = "DEDUCTEETYPE_name"
                cmbDEDUCTEE.Text = ""
            End If
            cmbDEDUCTEE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub DEDUCTEETYPEVALIDATE(ByRef CMBDEDUCTEETYPE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBDEDUCTEETYPE.Text.Trim <> "" Then
                uppercase(CMBDEDUCTEETYPE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("DEDUCTEETYPE_id", "", "DEDUCTEETYPEMASTER", " and DEDUCTEETYPE_NAME = '" & CMBDEDUCTEETYPE.Text.Trim & "'")
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("DEDUCTEETYPE not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBDEDUCTEETYPE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsDEDUCTEETYPE As New ClsDeducteetypeMaster
                        objclsDEDUCTEETYPE.alParaval = alParaval
                        Dim IntResult As Integer = objclsDEDUCTEETYPE.SAVE()
                    Else
                        CMBDEDUCTEETYPE.Focus()
                        CMBDEDUCTEETYPE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub CITYVALIDATE(ByRef CMBCITY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCITY.Text.Trim <> "" Then
                uppercase(CMBCITY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("CITY_id", "", "CITYMaster", " and CITY_NAME = '" & CMBCITY.Text.Trim & "' and CITY_cmpid = " & CmpId & " and CITY_LOCATIONid = " & Locationid & " and CITY_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("CITY not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(UCase(CMBCITY.Text.Trim))
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsCITY As New ClsCityMaster
                        objclsCITY.alParaval = alParaval
                        Dim IntResult As Integer = objclsCITY.save()
                    Else
                        CMBCITY.Focus()
                        CMBCITY.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub COORDINATORVALIDAT(ByRef cmbcoordinator As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            If cmbcoordinator.Text.Trim <> "" Then
                uppercase(cmbcoordinator)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("COORDINATOR_NAME", "", "COORDINATORMaster", " and COORDINATOR_NAME = '" & cmbcoordinator.Text.Trim & "' and COORDINATOR_cmpid = " & CmpId & " and COORDINATOR_locationid = " & Locationid & " and COORDINATOR_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("COORDINATOR not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        Dim objCOORDINATORmaster As New CoordinatorMaster
                        objCOORDINATORmaster.TEMPCOORDINARTOR = cmbcoordinator.Text.Trim()
                        objCOORDINATORmaster.ShowDialog()
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub TEARTAPEVALIDATE(ByRef CMBTAPETYPE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBTAPETYPE.Text.Trim <> "" Then
                uppercase(CMBTAPETYPE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("TEARTAPE_NAME", "", "TEARTAPEMASTER", " and TEARTAPE_NAME = '" & CMBTAPETYPE.Text.Trim & "' and TEARTAPE_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("TEARTAPE not present, Add New?", MsgBoxStyle.YesNo, "PRINTPRO")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBTAPETYPE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)
                        alParaval.Add("TEARTAPE")

                        Dim objclspapermat As New ClsPaperMaterial
                        objclspapermat.alParaval = alParaval
                        Dim IntResult As Integer = objclspapermat.save()
                        'e.Cancel = True
                    Else
                        CMBTAPETYPE.Focus()
                        CMBTAPETYPE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub ACCCODEVALIDATE(ByRef CMBCODE As ComboBox, ByVal CMBACCNAME As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef TXTADD As System.Windows.Forms.TextBox, Optional ByVal WHERECLAUSE As String = "", Optional ByVal GROUPNAME As String = "")
        Try
            If CMBCODE.Text.Trim <> "" Then
                uppercase(CMBCODE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("acc_CMPNAME, ACC_ADD", "", "Ledgers inner join groupmaster on groupmaster.group_id = ledgers.acc_groupid and groupmaster.group_cmpid = ledgers.acc_cmpid and groupmaster.group_locationid = ledgers.acc_locationid and groupmaster.group_yearid = ledgers.acc_yearid", " and acc_cODE = '" & CMBCODE.Text.Trim & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Ledger not present, Add New?", MsgBoxStyle.YesNo, "")
                    If tempmsg = vbYes Then
                        Dim objVendormaster As New AccountsMaster
                        objVendormaster.frmstring = "ACCOUNTS"
                        objVendormaster.tempAccountsCode = CMBCODE.Text.Trim()
                        objVendormaster.TEMPGROUPNAME = GROUPNAME
                        objVendormaster.ShowDialog()
                        dt = objclscommon.search("ACC_CODE", "", "Ledgers inner join groupmaster on groupmaster.group_id = ledgers.acc_groupid and groupmaster.group_cmpid = ledgers.acc_cmpid and groupmaster.group_locationid = ledgers.acc_locationid and groupmaster.group_yearid = ledgers.acc_yearid", " and acc_cODE = '" & CMBCODE.Text.Trim & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBCODE.Text.Trim
                            dt1 = CMBCODE.DataSource
                            If CMBCODE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBCODE.Text.Trim)
                                    CMBCODE.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    CMBACCNAME.Text = dt.Rows(0).Item(0)
                    TXTADD.Text = dt.Rows(0).Item(1)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub FILLBANK(ByRef CMBBANK As ComboBox)
        Try
            If CMBBANK.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" TDSCHA_BANKNAME ", "", " TDSCHALLAN ", " and TDSCHA_CMPID=" & CmpId & " and TDSCHA_LOCATIONID = " & Locationid & " and TDSCHA_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "TDSCHA_BANKNAME"
                    CMBBANK.DataSource = dt
                    CMBBANK.DisplayMember = "TDSCHA_BANKNAME"
                    CMBBANK.Text = ""
                End If
                CMBBANK.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGROUPCOMPANY(ByRef CMBGRPCOMPANY As ComboBox)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBGRPCOMPANY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" GOC_ID AS ID , GOC_NAME AS NAME ", "", "GROUPOFCOMPANIESMASTER", " And GOC_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "NAME"
                    CMBGRPCOMPANY.DataSource = dt
                    CMBGRPCOMPANY.DisplayMember = "NAME"
                    CMBGRPCOMPANY.ValueMember = "ID"
                    CMBGRPCOMPANY.SelectedItem = Nothing
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub GROUPCOMPANYVALIDATE(ByRef CMBGRPCOMPANY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If CMBGRPCOMPANY.Text.Trim <> "" Then
                uppercase(CMBGRPCOMPANY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" GOC_NAME ", "", " GROUPOFCOMPANIESMASTER ", " and GOC_NAME = '" & CMBGRPCOMPANY.Text.Trim & "' and GOC_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Company not present, Add New?", MsgBoxStyle.YesNo, "TEXTRADE")
                    If tempmsg = vbYes Then
                        Dim a As String = CMBGRPCOMPANY.Text.Trim
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBGRPCOMPANY.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)


                        Dim objRACK As New ClsGroupOfCompanies
                        objRACK.alParaval = alParaval
                        Dim IntResult As Integer = objRACK.SAVE()


                        dt = objclscommon.search(" GOC_ID AS ID, GOC_NAME AS NAME ", "", " GROUPOFCOMPANIESMASTER", " and GOC_NAME = '" & CMBGRPCOMPANY.Text.Trim & "' and GOC_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBGRPCOMPANY.DataSource
                            If CMBGRPCOMPANY.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("ID"), CMBGRPCOMPANY.Text.Trim)
                                    CMBGRPCOMPANY.Text = a
                                End If
                            End If
                        End If

                    Else
                        CMBGRPCOMPANY.Focus()
                        CMBGRPCOMPANY.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub fillPARTYBANK(ByRef CMBPARTYBANK As ComboBox, ByRef edit As Boolean)
        Try
            If CMBPARTYBANK.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                Dim WHERECLAUSE As String = ""
                dt = objclscommon.search(" PARTYBANK_name ", "", " PARTYBANKMaster", WHERECLAUSE & " and PARTYBANK_cmpid=" & CmpId & " AND PARTYBANK_Locationid=" & Locationid & " AND PARTYBANK_Yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "PARTYBANK_name"
                    CMBPARTYBANK.DataSource = dt
                    CMBPARTYBANK.DisplayMember = "PARTYBANK_name"
                    If edit = False Then CMBPARTYBANK.Text = ""
                End If
                CMBPARTYBANK.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PARTYBANKvalidate(ByRef CMBPARTYBANK As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If CMBPARTYBANK.Text.Trim <> "" Then
                uppercase(CMBPARTYBANK)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" PARTYBANK_name ", "", "PARTYBANKMaster", " and PARTYBANK_name = '" & CMBPARTYBANK.Text.Trim & "' and PARTYBANK_cmpid = " & CmpId & " and PARTYBANK_locationid = " & Locationid & " and PARTYBANK_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("PARTYBANK Name not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBPARTYBANK.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objPIECETYPE As New ClsPARTYBANKMaster
                        objPIECETYPE.alParaval = alParaval
                        Dim IntResult As Integer = objPIECETYPE.save()
                        'e.Cancel = True
                    Else
                        CMBPARTYBANK.Focus()
                        CMBPARTYBANK.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub HSNITEMDESCVALIDATE(ByRef CMBHSNCODE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBHSNCODE.Text.Trim <> "" Then
                uppercase(CMBHSNCODE)
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable
                dt = OBJCMN.search("   ISNULL(HSN_CODE, '') AS HSNCODE", "", "  HSNMASTER ", "and  HSN_CODE = '" & CMBHSNCODE.Text.Trim & "' and HSN_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBHSNCODE.Text.Trim
                    Dim tempmsg As Integer = MsgBox("HSN/SAC Code Not present, Add New?", MsgBoxStyle.YesNo, CmpName)
                    If tempmsg = vbYes Then
                        CMBHSNCODE.Text = a
                        Dim OBJDELIVERY As New HSNMaster
                        OBJDELIVERY.tempHSNCODE = CMBHSNCODE.Text.Trim()

                        OBJDELIVERY.ShowDialog()
                        dt = OBJCMN.search("   ISNULL(HSN_CODE, '') AS HSNCODE", "", "  HSNMASTER ", " and  HSN_CODE = '" & CMBHSNCODE.Text.Trim & "' and HSN_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBHSNCODE.DataSource
                            If CMBHSNCODE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBHSNCODE.Text.Trim)
                                    CMBHSNCODE.Text = a
                                End If
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
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

#Region "FUNCTION FOR COLOR"

    Sub fillCOLOR(ByRef cmbCOLOR As ComboBox)
        Try
            If cmbCOLOR.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" COLOR_NAME ", "", " COLORMaster ", " and COLOR_cmpid=" & CmpId & " and COLOR_locationid = " & Locationid & " and COLOR_yearid = " & YearId)
                cmbCOLOR.DataSource = dt
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "COLOR_NAME"
                    cmbCOLOR.DisplayMember = "COLOR_NAME"
                    cmbCOLOR.Text = ""
                End If
                cmbCOLOR.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillOPERATOR(ByRef cmbOPERATOR As ComboBox)
        Try
            If cmbOPERATOR.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" OPERATOR_NAME ", "", " OPERATORMASTER ", " and OPERATOR_cmpid=" & CmpId & "  and OPERATOR_yearid = " & YearId)
                cmbOPERATOR.DataSource = dt
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "OPERATOR_NAME"
                    cmbOPERATOR.DisplayMember = "OPERATOR_NAME"
                    cmbOPERATOR.Text = ""
                End If
                cmbOPERATOR.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillPROBLEM(ByRef cmbPROBLEM As ComboBox)
        Try
            If cmbPROBLEM.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" PROBLEM_NAME ", "", " PROBLEMMASTER ", " and PROBLEM_cmpid=" & CmpId & "  and PROBLEM_yearid = " & YearId)
                cmbPROBLEM.DataSource = dt
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "PROBLEM_NAME"
                    cmbPROBLEM.DisplayMember = "PROBLEM_NAME"
                    cmbPROBLEM.Text = ""
                End If
                cmbPROBLEM.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub fillREASON(ByRef cmbREASON As ComboBox)
        Try
            If cmbREASON.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" REASON_NAME ", "", " REASONMASTER ", " and REASON_cmpid=" & CmpId & "  and REASON_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "REASON_NAME"
                    cmbREASON.DataSource = dt
                    cmbREASON.DisplayMember = "REASON_NAME"
                    cmbREASON.Text = ""
                End If
                cmbREASON.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillUNIT(ByRef cmbUNIT As ComboBox)
        Try
            If cmbUNIT.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" UNIT_ABBR ", "", " UNITMaster ", " and UNIT_cmpid=" & CmpId & " and UNIT_locationid = " & Locationid & " and UNIT_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "UNIT_ABBR"
                    cmbUNIT.DataSource = dt
                    cmbUNIT.DisplayMember = "UNIT_ABBR"
                    cmbUNIT.Text = ""
                End If
                cmbUNIT.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub COLORvalidate(ByRef cmbCOLOR As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If cmbCOLOR.Text.Trim <> "" Then
                uppercase(cmbCOLOR)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" COLOR_NAME ", "", "COLORMaster", " and COLOR_NAME = '" & cmbCOLOR.Text.Trim & "' and COLOR_cmpid = " & CmpId & " and COLOR_locationid = " & Locationid & " and COLOR_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Color not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(UCase(cmbCOLOR.Text.Trim))
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)
                        alParaval.Add("COLOR")

                        Dim objclspapermat As New ClsPaperMaterial
                        objclspapermat.alParaval = alParaval
                        Dim IntResult As Integer = objclspapermat.save()
                        'e.Cancel = True
                    Else
                        cmbCOLOR.Focus()
                        cmbCOLOR.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub OPERATORVALIDATE(ByRef cmbOPERATOR As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If cmbOPERATOR.Text.Trim <> "" Then
                uppercase(cmbOPERATOR)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" OPERATOR_NAME ", "", "OPERATORMASTER", " and OPERATOR_NAME = '" & cmbOPERATOR.Text.Trim & "' and OPERATOR_cmpid = " & CmpId & "   and OPERATOR_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("OPERATOR not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(UCase(cmbOPERATOR.Text.Trim))
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim OBJOPERATOR As New ClsOperatorMaster
                        OBJOPERATOR.alParaval = alParaval
                        Dim IntResult As Integer = OBJOPERATOR.save()
                        'e.Cancel = True
                    Else
                        cmbOPERATOR.Focus()
                        cmbOPERATOR.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PROBLEMVALIDATE(ByRef cmbPROBLEM As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            If cmbPROBLEM.Text.Trim <> "" Then
                uppercase(cmbPROBLEM)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" PROBLEM_NAME ", "", "PROBLEMMASTER", " and PROBLEM_NAME = '" & cmbPROBLEM.Text.Trim & "' and PROBLEM_cmpid = " & CmpId & "   and PROBLEM_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Problem not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(UCase(cmbPROBLEM.Text.Trim))
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim OBJPROBLEM As New ClsProblemMaster
                        OBJPROBLEM.alParaval = alParaval
                        Dim IntResult As Integer = OBJPROBLEM.save()
                        'e.Cancel = True
                    Else
                        cmbPROBLEM.Focus()
                        cmbPROBLEM.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub REASONVALIDATE(ByRef cmbREASON As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            If cmbREASON.Text.Trim <> "" Then
                uppercase(cmbREASON)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" REASON_NAME ", "", "REASONMASTER", " and REASON_NAME = '" & cmbREASON.Text.Trim & "' and REASON_cmpid = " & CmpId & "   and REASON_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Reason not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(UCase(cmbREASON.Text.Trim))
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim OBJREASON As New ClsReasonMaster
                        OBJREASON.alParaval = alParaval
                        Dim IntResult As Integer = OBJREASON.save()
                        'e.Cancel = True
                    Else
                        cmbREASON.Focus()
                        cmbREASON.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SHELFVALIDATE(ByRef CMBSHELF As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBSHELF.Text.Trim <> "" Then
                uppercase(CMBSHELF)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("SHELF_NAME", "", "SHELFMASTER", " and SHELF_NAME = '" & CMBSHELF.Text.Trim & "' and SHELF_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("SHELF not present, Add New?", MsgBoxStyle.YesNo, "PRINTPRO")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBSHELF.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)
                        alParaval.Add("SHELF")

                        Dim objclspapermat As New ClsPaperMaterial
                        objclspapermat.alParaval = alParaval
                        Dim IntResult As Integer = objclspapermat.save()
                        'e.Cancel = True
                    Else
                        CMBSHELF.Focus()
                        CMBSHELF.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub DEPARTMENTVALIDATE(ByRef CMBDEPARTMENT As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBDEPARTMENT.Text.Trim <> "" Then
                uppercase(CMBDEPARTMENT)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("Department_NAME", "", "DepartmentMASTER", " and Department_NAME = '" & CMBDEPARTMENT.Text.Trim & "' and Department_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Department not present, Add New?", MsgBoxStyle.YesNo, "PRINTPRO")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBDEPARTMENT.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)
                        alParaval.Add("DEPARTMENT")

                        Dim objclspapermat As New ClsPaperMaterial
                        objclspapermat.alParaval = alParaval
                        Dim IntResult As Integer = objclspapermat.save()
                        'e.Cancel = True
                    Else
                        CMBDEPARTMENT.Focus()
                        CMBDEPARTMENT.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub Categoryvalidate(ByRef cmbcategory As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If cmbcategory.Text.Trim <> "" Then
                uppercase(cmbcategory)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" category_NAME ", "", "CategoryMaster", " and CATEGORY_NAME = '" & cmbcategory.Text.Trim & "' and CatEgory_cmpid = " & CmpId & " and CatEgory_locationid = " & Locationid & " and CatEgory_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Category not present, Add New?", MsgBoxStyle.YesNo, "PrintPro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(UCase(cmbcategory.Text.Trim))
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)
                        alParaval.Add("Category")

                        Dim objclspapermat As New ClsPaperMaterial
                        objclspapermat.alParaval = alParaval
                        Dim IntResult As Integer = objclspapermat.save()
                        'e.Cancel = True
                    Else
                        cmbcategory.Focus()
                        cmbcategory.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "FUNCTION FOR PRODUCT TYPE"

    Sub fillPRODUCTTYPE(ByRef cmbPRODUCTTYPE As ComboBox, ByRef WHERECLAUSE As String)
        Try

            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclscommon.search(" PRODUCT_NAME ", "", " PRODUCTTYPEMaster ", " and PRODUCT_cmpid=" & CmpId & " AND PRODUCT_LOCATIONID = " & Locationid & " AND PRODUCT_YEARID = " & YearId & " " & WHERECLAUSE)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "PRODUCT_NAME"
                cmbPRODUCTTYPE.DataSource = dt
                cmbPRODUCTTYPE.DisplayMember = "PRODUCT_NAME"
                cmbPRODUCTTYPE.Text = ""
            End If
            cmbPRODUCTTYPE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "FUNCTION FOR EMAIL"

    Sub sendemail(ByVal toMail As String, ByVal tempattachment As String, ByVal mailbody As String, ByVal subject As String, Optional ByVal ALATTACHMENT As ArrayList = Nothing, Optional ByVal NOOFATTACHMENTS As Integer = 0, Optional ByVal TEMPATTACHMENT1 As String = "", Optional ByVal TEMPATTACHMENT2 As String = "", Optional ByVal TEMPATTACHMENT3 As String = "", Optional ByVal TEMPATTACHMENT4 As String = "", Optional ByVal TEMPATTACHMENT5 As String = "", Optional ByVal TEMPATTACHMENT6 As String = "")

        'Dim mailBody As String
        Try
            Cursor.Current = Cursors.WaitCursor

            'create the mail message
            Dim mail As New MailMessage
            Dim MAILATTACHMENT As Attachment

            'set the addresses
            mail.From = New MailAddress("siddhivinayaksynthetics@gmail.com", CmpName)
            'mail.From = New MailAddress("gulkitjain@gmail.com", "TexPro V1.0")

            mail.To.Add(toMail)

            '''' GIVING ISSUE IN DIRECT MULTIPLE PRINT IN INVOICE.
            ''set the content
            'mail.Subject = subject
            'mail.Body = mailbody
            'mail.IsBodyHtml = True
            'MAILATTACHMENT = New Attachment(tempattachment)
            'mail.Attachments.Add(MAILATTACHMENT)

            'If TEMPATTACHMENT1 <> "" Then
            '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT1)
            '    mail.Attachments.Add(MAILATTACHMENT)
            'End If

            'If TEMPATTACHMENT2 <> "" Then
            '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT2)
            '    mail.Attachments.Add(MAILATTACHMENT)
            'End If

            'If TEMPATTACHMENT3 <> "" Then
            '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT3)
            '    mail.Attachments.Add(MAILATTACHMENT)
            'End If

            'If TEMPATTACHMENT4 <> "" Then
            '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT4)
            '    mail.Attachments.Add(MAILATTACHMENT)
            'End If


            'If TEMPATTACHMENT5 <> "" Then
            '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT5)
            '    mail.Attachments.Add(MAILATTACHMENT)
            'End If

            'If TEMPATTACHMENT6 <> "" Then
            '    MAILATTACHMENT = New Attachment(TEMPATTACHMENT6)
            '    mail.Attachments.Add(MAILATTACHMENT)
            'End If

            'set the content
            mail.Subject = subject
            mail.Body = mailbody
            mail.IsBodyHtml = True
            If NOOFATTACHMENTS <= 1 Then
                MAILATTACHMENT = New Attachment(tempattachment)
                mail.Attachments.Add(MAILATTACHMENT)
            Else
                For I As Integer = 0 To NOOFATTACHMENTS - 1
                    MAILATTACHMENT = New Attachment(ALATTACHMENT(I))
                    mail.Attachments.Add(MAILATTACHMENT)
                Next
            End If


            'send the message
            Dim smtp As New SmtpClient

            'set username and password
            Dim nc As New System.Net.NetworkCredential


            'GET SMTP, EMAILADD AND PASSWORD FROM USERMASTER
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("USER_SMTP AS SMTP, USER_SMTPEMAIL AS EMAIL, USER_SMTPPASS AS PASS", "", " USERMASTER", " AND USER_NAME = '" & UserName & "' and USER_CMPID = " & CmpId)
            If DT.Rows.Count > 0 Then
                If DT.Rows(0).Item("SMTP") = "" Then smtp.Host = "smtp.gmail.com" Else smtp.Host = DT.Rows(0).Item("SMTP")
                'smtp.Port = (25)
                smtp.Port = (587)

                smtp.EnableSsl = True

                nc.UserName = DT.Rows(0).Item("EMAIL")
                nc.Password = DT.Rows(0).Item("PASS")
            Else

                smtp.Host = "smtp.gmail.com"
                'smtp.Port = (25)
                smtp.Port = (587)
                smtp.EnableSsl = False

                nc.UserName = "gulkitjain@gmail.com"
                nc.Password = "gulkit3042"

            End If


            'smtp.Timeout = 20000
            smtp.Timeout = 50000

            smtp.Credentials = nc
            smtp.Send(mail)
            mail.Dispose()

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

#End Region

    Function checkrowlinedel(ByVal gridsrno As Integer, ByVal txtno As TextBox) As Boolean
        Dim bln As Boolean = True
        If gridsrno = Val(txtno.Text.Trim) Then
            bln = False
        End If
        Return bln
    End Function

    Sub commakeypress(ByVal han As KeyPressEventArgs, ByVal sen As Control, ByVal frm As System.Windows.Forms.Form)
        If AscW(han.KeyChar) = 44 Then
            han.KeyChar = ""
        End If
    End Sub

    Sub fillUSER(ByRef CMBUSER As ComboBox, Optional ByVal CONDITION As String = "")
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" DISTINCT User_Name as [UserName]", "", "USERMASTER", " and USERMASTER.USER_cmpid= " & CmpId & " ORDER BY USER_NAME ")
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "USERNAME"
                CMBUSER.DataSource = dt
                CMBUSER.DisplayMember = "USERNAME"
                CMBUSER.Text = ""
            End If
            CMBUSER.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Async Function SENDWHATSAPPATTACHMENT(WHATSAPPNO As String, PATH As String, FILENAME As String) As Threading.Tasks.Task(Of String)
        Dim RESPONSE As String = ""
        Dim waMediaMsgBody As SendMediaMsgJson = New SendMediaMsgJson()
        Dim Attachment As String = Convert.ToBase64String(File.ReadAllBytes(PATH))
        Dim AttachmentFileName As String = FILENAME
        waMediaMsgBody.base64data = Attachment
        waMediaMsgBody.mimeType = MimeMapping.GetMimeMapping(AttachmentFileName)
        'waMediaMsgBody.caption = "APIMethod SendMediaMessage from CISPLWhatsAppAPI.dll"
        waMediaMsgBody.filename = AttachmentFileName
        Dim txnResp As TxnRespWithSendMessageDtls = Await APIMethods.SendMediaMessageAsync(WHATSAPPNO, waMediaMsgBody)
        RESPONSE = JsonConvert.SerializeObject(txnResp, Formatting.Indented)

        Return RESPONSE
    End Function

#Region "WHATSAPP"

    Function CHECKWHASTAPPEXP() As Boolean
        Dim BLN As Boolean = True
        If Now.Date > WHATSAPPEXPDATE Then
            BLN = False
        End If
        Return BLN
    End Function

    Function GETWHATSAPPBASEURL() As String
        Dim WHATSAPPBASEURL As String = ""

        'READ BASEURL FROM C DRIVE
        If File.Exists("C:\WHATSAPPBASEURL.txt") Then
            Dim oRead As System.IO.StreamReader = File.OpenText("C:\WHATSAPPBASEURL.txt")
            WHATSAPPBASEURL = oRead.ReadToEnd
        End If
        Return WHATSAPPBASEURL
    End Function
    Async Function SENDWHATSAPPMESSAGE(WHATSAPPNO As String, TEXTMESSAGE As String) As Threading.Tasks.Task(Of String)
        Dim RESPONSE As String = ""
        Dim Body As SendTextMsgJson = New SendTextMsgJson()
        Body.text = TEXTMESSAGE
        Dim txnResp As TxnRespWithSendMessageDtls = Await APIMethods.SendTextMessageAsync(WHATSAPPNO, Body)
        RESPONSE = JsonConvert.SerializeObject(txnResp, Formatting.Indented)
        Return RESPONSE
    End Function

    Async Function CHECKMOBILECONNECTSTATUS() As Threading.Tasks.Task(Of String)
        Dim RESPONSE As String = ""
        Dim txnResp As TxnRespWithConnectionState = Await APIMethods.GetConnectionStateAsync()
        RESPONSE = JsonConvert.SerializeObject(txnResp, Formatting.Indented)
        Return RESPONSE
    End Function


#End Region

End Module
