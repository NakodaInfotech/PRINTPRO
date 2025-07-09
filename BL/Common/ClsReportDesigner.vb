
Imports Excel
'Imports DB
'Imports AsianERPBL.ModGeneral
'Imports AsianERPBL.Account
Imports System.Data
Imports Microsoft.Office.Interop


'Imports Microsoft.Office.Interop.Excel


Public Class clsReportDesigner
    'Private objDBOperation As DB.DBOperation

    'Public objUserDetails As ObjUser
    'Private objRepCenter As New clsRepCenter
    Dim dsResult As New DataSet
    Public ALPARAVAL As New ArrayList
    Dim dv As New DataView

    Public Sub New()
        Try
            'objDBOperation = New DB.DBOperation
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region " INTERNAL MANAGEMENT DECLARATIONS ............. "


#Region "Private Declarations..."
    Private objColumn As New Hashtable
    Private objSheet As Excel.Worksheet
    Private objExcel As Excel.Application
    Private objBook As Excel.Workbook
    'Private objUser As New clsUser
    Private RowIndex As Integer
    Private currentColumn As String
    Private _Report_Title As String
    Private _SaveFilePath As String
    Private _PreviewOption As Integer
#End Region

    Public Sub New(ByVal Report_Title As String, ByVal SaveFilePath As String, ByVal PreivewOption As Integer)
        Dim proc As System.Diagnostics.Process
        Try
            _Report_Title = Report_Title
            _SaveFilePath = SaveFilePath
            _PreviewOption = PreivewOption
            Try
                For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                    proc.Kill()
                Next
            Catch ex As Exception

            End Try
            ' try{
            '    foreach (Process thisproc in Process.GetProcessesByName(processName)) {
            'if(!thisproc.CloseMainWindow()){
            '//If closing is not successful or no desktop window handle, then force termination.
            'thisproc.Kill();
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetWorkSheet()
        Try
            objExcel = New Excel.Application
            If Not objExcel Is Nothing Then
                objBook = objExcel.Workbooks.Add
                objSheet = DirectCast(objBook.ActiveSheet, Excel.Worksheet)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Quit()
        Try
            objSheet = Nothing
            objBook.Close()
            ReleaseObject(objBook)
            objExcel.Quit()
            ReleaseObject(objExcel)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub SaveAndClose()
        Try
            objExcel.AlertBeforeOverwriting = False
            objExcel.DisplayAlerts = False
            objSheet.SaveAs(_SaveFilePath)

            If _PreviewOption = 1 Then 'Open In Web Browser                
                objBook.WebPagePreview()
            ElseIf _PreviewOption = 2 Then 'Open In Excel                
                objExcel.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Try
                If _PreviewOption <> 2 Then Quit()
            Catch ex As Exception
            End Try
        End Try
    End Sub

    Private Sub SetColumn(ByVal Key As String, ByVal ForColumn As String)
        Try
            objColumn.Add(Key, ForColumn)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReSetColumn()
        Try
            objColumn.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private ReadOnly Property Column(ByVal Key As String) As String
        Get
            Try
                Return objColumn.Item(Key).ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Get
    End Property

    Private ReadOnly Property Range(ByVal Key As String) As String
        Get
            Try
                Return objColumn.Item(Key).ToString & RowIndex.ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Get
    End Property

    Private Sub Write(ByVal Text As Object, ByVal Range As String, ByVal Align As Excel.XlHAlign, _
        Optional ByVal ToRange As String = Nothing, Optional ByVal FontBold As Boolean = False, _
        Optional ByVal FontSize As Int16 = 9, Optional ByVal WrapText As Boolean = False, Optional ByVal _
fontItalic As Boolean = False)
        Try
            objSheet.Range(Range).FormulaR1C1 = Text
            'objSheet.Range(Range).BorderAround()
            If Not ToRange Is Nothing Then
                objSheet.Range(Range, ToRange).Merge()
                'objSheet.Range(Range, ToRange).BorderAround()
            End If
            objSheet.Range(Range).HorizontalAlignment = Align
            If FontBold Then objSheet.Range(Range).Font.Bold = True
            If FontSize > 0 Then objSheet.Range(Range).Font.Size = FontSize
            If WrapText Then objSheet.Range(Range).WrapText = True
            If fontItalic Then objSheet.Range(Range).Font.Italic = True


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FORMULA(ByVal Text As Object, ByVal Range As String, ByVal Align As Excel.XlHAlign, _
       Optional ByVal ToRange As String = Nothing, Optional ByVal FontBold As Boolean = False, _
       Optional ByVal FontSize As Int16 = 9, Optional ByVal WrapText As Boolean = False, Optional ByVal _
fontItalic As Boolean = False)
        Try
            objSheet.Range(Range).Formula = Text
            'objSheet.Range(Range).BorderAround()
            If Not ToRange Is Nothing Then
                objSheet.Range(Range, ToRange).Merge()
                'objSheet.Range(Range, ToRange).BorderAround()
            End If
            objSheet.Range(Range).HorizontalAlignment = Align
            If FontBold Then objSheet.Range(Range).Font.Bold = True
            If FontSize > 0 Then objSheet.Range(Range).Font.Size = FontSize
            If WrapText Then objSheet.Range(Range).WrapText = True
            If fontItalic Then objSheet.Range(Range).Font.Italic = True


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LOCKCELLS(ByVal VALUE As Boolean, ByVal Range As String, Optional ByVal ToRange As String = Nothing)
        Try
            If Not ToRange Is Nothing Then
                objSheet.Range(Range, ToRange).Locked = VALUE
            Else
                objSheet.Range(Range).Locked = VALUE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetBorder(ByVal RowIndex As Integer, Optional ByVal Range As String = Nothing, Optional ByVal ToRange As String = Nothing)

        Dim intI As Integer = 0
        ''RowIndex = 0
        'obj()
        'objSheet.Selec
        'objExcel.Selection("A1:N17").ToString()
        objSheet.Range(Range, ToRange).Select()
        objSheet.Range(Range, ToRange).BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )
        'For intI = 1 To RowIndex
        '    objSheet.Range(Range, ToRange).Select()
        '    objSheet.Range(Range, ToRange).BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )
        '    intI += 1
        'Next
    End Sub

    Private Sub SetColumnWidth(ByVal Range As String, ByVal width As Integer)
        'objSheet.Range(Range).BorderAround()
        objSheet.Range(Range).ColumnWidth = width
        '  = objSheet.Range(Range).Select()
        'objSheet.Range(Range).EditionOptions(XlEditionType.xlPublisher, XlEditionOptionsOption.xlAutomaticUpdate, , , XlPictureAppearance.xlScreen, XlPictureAppearance.xlScreen)
    End Sub

    Private Function NextColumn() As String
        Dim nxtColumn As String = String.Empty
        Try
            Dim i As Integer = 0
            Dim length As Integer = currentColumn.Length
            For i = length - 1 To 0 Step -1
                If Not (currentColumn(i).ToString.ToUpper = "Z") Then
                    Dim substr As String = String.Empty
                    If i > 0 Then
                        substr = currentColumn.Substring(0, i)
                    End If
                    nxtColumn = Convert.ToString(Convert.ToChar(Convert.ToInt32(currentColumn(i)) + 1)) & nxtColumn
                    nxtColumn = substr & nxtColumn
                    Exit For
                ElseIf currentColumn(i).ToString.ToUpper = "Z" Then
                    nxtColumn = "A" & nxtColumn
                End If
                If i = 0 Then
                    If Convert.ToString(currentColumn(i)).ToUpper = "Z" Then
                        nxtColumn = "A" & nxtColumn
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
        currentColumn = nxtColumn
        Return nxtColumn
    End Function

    Private Sub MeargeCell(ByVal StartCol As String, ByVal StartRow As String, ByVal EndCol As String, ByVal EndRow As String)
        Try

            'objSheet.Range(StartCol & StartRow & ":" & EndCol & EndRow).Merge()
            objSheet.Range(StartCol, EndCol).Merge()

            'With objSheet.Selection                
            '    .WrapText = False
            '    .Orientation = 0
            '    .AddIndent = False
            '    .IndentLevel = 0
            '    .ShrinkToFit = False                
            '    .MergeCells = True
            'End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Sample"

    Public Function RPT_SampleGeneral_Loading(ByVal intPDIID As Integer, ByVal strPUser As String) As Object
        Try
            Dim id As Integer = 0
            Dim intJ As Integer = 0
            Dim intTotal As Integer = 0
            Dim intSrNo As Integer = 0
            Dim intRowStart, intRowEnd As Integer
            Dim drRow As DataRow
            Dim drNew As System.Data.DataRow = Nothing
            Dim dtTable As New System.Data.DataTable
            Dim dtSetItem As New System.Data.DataTable
            Dim dtChild As New System.Data.DataTable
            Dim objDispatch As New Object()

            'BrandPromotion.clsSampleDispatch()
            'Dim Tot1, Tot2, tot3, Tot4 As Double
            'Dim Gt1, Gt2, Gt3 As Double
            'Dim dvTemp As DataView
            'dtTable = objDispatch.DispatchChitReport(intPDIID)
            'If dtTable.Rows.Count = 0 Then Return Nothing
            'dtChild = objDispatch.DispatchChitReportCHILD(intPDIID)
            'dtSetItem = objDispatch.DispatchChitReportItem(intPDIID)




            SetWorkSheet()
            SetColumn("1", "A")
            SetColumn("2", "B")
            SetColumn("3", "C")
            SetColumn("4", "D")
            SetColumn("5", "E")
            SetColumn("6", "F")
            SetColumn("7", "G")
            SetColumn("8", "H")
            SetColumn("9", "I")
            'SetColumn("10", "J")
            'SetColumn("11", "K")
            'SetColumn("12", "L")
            'SetColumn("13", "M")
            'SetColumn("14", "N")
            'SetColumn("15", "O")
            SetColumnWidth("A1", 50)

            objSheet.Range("A1").Select()
            objSheet.Range("A1").BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )

            '''''''''''Report Title
            RowIndex += 3
            Write(_Report_Title, Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 12)
            RowIndex += 1
            Write("FER 2006 Regulation 27(1)(b) and (c)", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
            RowIndex += 1
            Write("WEEKLY / MONTLY RETURN FOR SALES OF FOREIGN CURRENCIES(OURFLOWS) ", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 0)
            '''''''''''Report Title Over
            RowIndex += 1
            Write("TEMPLATE - VERSION 1.0", Range("4"), XlHAlign.xlHAlignLeft, Range("5"), , 0)

            RowIndex += 1
            'Write("Date of period", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), , 0)
            Write("Date of period", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("Week / Month ending", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Year", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Bureaux / Money remitters name", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1


            Write("Purpose of Funds", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            Write("USD", Range("2"), XlHAlign.xlHAlignLeft, , True, )
            Write("Stg", Range("3"), XlHAlign.xlHAlignLeft, , True, )
            Write("EURO", Range("4"), XlHAlign.xlHAlignLeft, , True, )
            Write("KShs", Range("5"), XlHAlign.xlHAlignLeft, , True, )
            Write("Tz", Range("6"), XlHAlign.xlHAlignLeft, , True, )
            Write("SAR", Range("7"), XlHAlign.xlHAlignLeft, , True, )
            Write("Other(in USD)8", Range("8"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("1. Domestic Transactions", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a)Transaction between Ugandan Residents", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b)Currency Holdings / Deposits e.g. Savings", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("2. Exports of Goods", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Gold Exports (non-monetary gold)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Repairs on goods", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(c) Goods procured in ports by carriers", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(d) Goods for processing", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(e) Coffee and other Exports", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("3. Income Receipts", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Interest received on External assets", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Dividends / profits received", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(c) Wages / Salaries", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("4. Service Receipts", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Transportation", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(a1) Freight", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(a2) Passenger", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(a3) Other", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Communication services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(c) Construction services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(d) Insurance & Re-inssurance", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(e) Financial services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(f) Travel", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(f1) Business / Official", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(f2) Education", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(f3) Medical", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("(f4) Other Personal", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(g) Computer and information services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(h) Royalties and license fees", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(i) Other business services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(j) Personal, cultural, and recreational serives", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(k) Government services, n.i.e.", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("5. Transfers", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) NGO inflows", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Government Grants", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(c) Worker's remittances", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(d) Other transfers", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("6. Foreign Direct Equity Investment", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("7. Portfolio Investment", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Government", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Bank", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(c) Other", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("8. Loans", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Loan Received", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a1) By commercial Banks", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("Short term (<1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("Long term (>1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(a2) Others", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(i) Private", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("Short term (<1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("Long term (>1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(ii) Goverment", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Loan Repayment (Principal)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("Bank / bureaux", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Interbureaux", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Other (Please specify)", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("TOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("UGANDA SHILLING EQUIVALENT", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("* Other currencies traded should be reported in USDollar equivalent.", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("This return should be submitted not later than three o'clock in the afternoon of every first business day following the week and not later than five days after the end of the month to which it pertains.", Range("1"), XlHAlign.xlHAlignLeft, , True, )


            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Private Sub FetchData(ByVal fromDate As Date, ByVal toDate As Date, ByVal sp_name As String)
        Try
            'Dim conn As New SqlClient.SqlConnection("Data Source=DELL-B0BA70D352\SQLDELL;Initial Catalog=Forex;Integrated Security=True;uid=sa;pwd=admin123;")
            'Dim conn As New SqlClient.SqlConnection("Data Source=.\SQLDELL;Initial Catalog=Project;Integrated Security=True;")
            Dim conn As New SqlClient.SqlConnection(System.Configuration.ConfigurationSettings.AppSettings("ConnectionString").ToString())


            Dim comm As New SqlClient.SqlCommand()
            conn.Open()
            comm.Connection = conn
            comm.CommandType = CommandType.StoredProcedure
            comm.CommandText = sp_name
            comm.Parameters.Add(New SqlClient.SqlParameter("@FromDate", fromDate))
            comm.Parameters.Add(New SqlClient.SqlParameter("@ToDate", toDate))
            comm.CommandTimeout = 1000
            Dim adap As New SqlClient.SqlDataAdapter(comm)
            adap.Fill(dsResult)
            conn.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillAmount()
        Try

            If dv.Count > 0 Then
                For index As Integer = 1 To dv.Count
                    If dv.Item(index - 1)("CurrencyId") = 1 Then
                        Write(dv.Item(index - 1)("Amount"), Range("2"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 2 Then
                        Write(dv.Item(index - 1)("Amount"), Range("3"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 3 Then
                        Write(dv.Item(index - 1)("Amount"), Range("4"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 4 Then
                        Write(dv.Item(index - 1)("Amount"), Range("5"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 5 Then
                        Write(dv.Item(index - 1)("Amount"), Range("6"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 7 Then
                        Write(dv.Item(index - 1)("Amount"), Range("7"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 9 Then
                        Write(dv.Item(index - 1)("Amount"), Range("2"), XlHAlign.xlHAlignLeft, , False, )
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function RPT_Sales_Report(ByVal fromDate As Date, ByVal toDate As Date) As Object
        Try
            Me.FetchData(fromDate, toDate, "SP_SELECTSO_FOR_EDIT")

            SetWorkSheet()
            SetColumn("1", "A")
            SetColumn("2", "B")
            SetColumn("3", "C")
            SetColumn("4", "D")
            SetColumn("5", "E")
            SetColumn("6", "F")
            SetColumn("7", "G")
            SetColumn("8", "H")
            SetColumn("9", "I")

            SetColumnWidth("A1", 50)
            objSheet.Range("A1").Select()
            objSheet.Range("A1").BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )

            '''''''''''Report Title
            RowIndex += 3
            Write("FORM P(Sales)", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 12)
            RowIndex += 1
            Write("FER 2006 Regulation 27(1)(b) and (c)", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 10, , True)
            RowIndex += 1
            Write("WEEKLY / MONTLY RETURN FOR SALES OF FOREIGN CURRENCIES(OURFLOWS) ", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 0)
            '''''''''''Report Title Over
            RowIndex += 1
            Write("TEMPLATE - VERSION 1.0", Range("4"), XlHAlign.xlHAlignLeft, Range("5"), , 0)

            RowIndex += 1
            'Write("Date of period", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), , 0)
            Write("Date of period", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("Week / Month ending", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Year", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Bureaux / Money remitters name", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1


            Write("Purpose of Funds", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            Write("USD", Range("2"), XlHAlign.xlHAlignLeft, , True, )
            Write("Stg", Range("3"), XlHAlign.xlHAlignLeft, , True, )
            Write("EURO", Range("4"), XlHAlign.xlHAlignLeft, , True, )
            Write("KShs", Range("5"), XlHAlign.xlHAlignLeft, , True, )
            Write("Tz", Range("6"), XlHAlign.xlHAlignLeft, , True, )
            Write("SAR", Range("7"), XlHAlign.xlHAlignLeft, , True, )
            Write("Other(in USD)8", Range("8"), XlHAlign.xlHAlignLeft, , True, )

            dv = dsResult.Tables(0).DefaultView

            RowIndex += 1
            Write("1. Domestic Transactions", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a)Transaction between Ugandan Residents", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransBetweenUgandaRes'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b)Currency Holdings / Deposits e.g. Savings", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='CurrencyHoldingDiposits'"
            Me.FillAmount()

            RowIndex += 1
            Write("2. Import of Goods", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("(a) Govt imports (Incl. Govt. Projects)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='GovtImports'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Private Imports (Incl. Parastatal & NGOs)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='PrivateImports'"
            Me.FillAmount()

            RowIndex += 1
            Write("(i) Oil Imports", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='OilImports'"
            Me.FillAmount()

            RowIndex += 1
            Write("(ii) Gold Imports", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='GoldImports'"
            Me.FillAmount()

            RowIndex += 1
            Write("(iii) Repairs", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='Repairs'"
            Me.FillAmount()

            RowIndex += 1
            Write("(iv) Goods procured in ports by carriers", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='GoodsProPortsByCarrier'"
            Me.FillAmount()

            RowIndex += 1
            Write("(v) Goods for processing", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='GoodsForProcessig'"
            Me.FillAmount()

            RowIndex += 1
            Write("Income Payments", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("(a) Interest received on External liabilities", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='InterestPaidOnExternalLib'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Dividends / profits paid", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='DividentProfitPaid'"
            Me.FillAmount()

            RowIndex += 1
            Write("(c) Wages / Salaries", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='WagesSalaries'"
            Me.FillAmount()

            RowIndex += 1
            Write("Service Receipts", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Transportation", Range("1"), XlHAlign.xlHAlignLeft, , False, )


            RowIndex += 1
            Write("(a1) Freight", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransFreight'"
            Me.FillAmount()

            RowIndex += 1
            Write("(a2) Passenger", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransPassanger'"
            Me.FillAmount()

            RowIndex += 1
            Write("(a3) Other", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransOther'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Communication services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='CommunicationService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(c) Construction services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='ConstructionService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(d) Insurance & Re-inssurance", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='InsuranceDeInsu'"
            Me.FillAmount()

            RowIndex += 1
            Write("(e) Financial services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='FinancialService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(f) Travel", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransBetweenUgandaRes'"
            Me.FillAmount()

            RowIndex += 1
            Write("(f1) Business / Official", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TravelBusinessOfficial'"
            Me.FillAmount()

            RowIndex += 1
            Write("(f2) Education", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TravelEducation'"
            Me.FillAmount()

            RowIndex += 1
            Write("(f3) Medical", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TravelMedical'"
            Me.FillAmount()

            RowIndex += 1
            Write("(f4) Other Personal", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TravelOtherPersonal'"
            Me.FillAmount()

            RowIndex += 1
            Write("(g) Computer and information services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='CompAndInfoService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(h) Royalties and licence fees", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='RoyaliAndLicenceFees'"
            Me.FillAmount()

            RowIndex += 1
            Write("(i) Other business services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='OtherBusinessService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(j) Personal, cultural, and recreational serives", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='PersonalCultAndReceService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(k) Government services, n.i.e.", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='GovtServices'"
            Me.FillAmount()

            RowIndex += 1
            Write("Transfers", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("(a) NGO Outflows", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransNGOOutFlows'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Government Grants", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransGovtGrants'"
            Me.FillAmount()

            RowIndex += 1
            Write("(c) Worker's remittances", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='TransWorkerRemitance'"
            Me.FillAmount()

            RowIndex += 1
            Write("(d) Other transfers", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='TransOtherTransfer'"
            Me.FillAmount()

            RowIndex += 1
            Write("Foreign Direct Equity Investment", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='ForeignDirectEquityInvestment'"
            Me.FillAmount()

            RowIndex += 1
            Write("Portfolio Investment", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("(a) By Government", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='PortInvestByGovernment'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) By Bank", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='PortInvestByBanks'"
            Me.FillAmount()

            RowIndex += 1
            Write("(c) By Other", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='PortInvestByOthers'"
            Me.FillAmount()

            RowIndex += 1
            Write("Loans", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("(a) Loans Extended abroad", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("(a1) By commercial Banks", Range("1"), XlHAlign.xlHAlignLeft, , False, )


            RowIndex += 1
            Write("Short term (<1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='LoanByCommBankShortTerm'"
            Me.FillAmount()

            RowIndex += 1
            Write("Long term (>1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='LoanByCommBankLongTerm'"
            Me.FillAmount()

            RowIndex += 1
            Write("(a2) Others", Range("1"), XlHAlign.xlHAlignLeft, , False, )


            RowIndex += 1
            Write("(i) Private", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("Short term (<1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='LoanByPrivateShortTerm'"
            Me.FillAmount()

            RowIndex += 1
            Write("Long term (>1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='LoanByPrivateLongTerm'"
            Me.FillAmount()

            RowIndex += 1
            Write("(ii) Goverment", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='LoanOtherGovernment'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Loan Repayment (Principal)", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='LoanRepaymentPrincipal'"
            Me.FillAmount()

            RowIndex += 1
            Write("Bank / bureaux", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='BankBureaux'"
            Me.FillAmount()

            RowIndex += 1
            Write("Inerbank", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='InterBank'"
            Me.FillAmount()

            RowIndex += 1
            Write("Interbureaux", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='InterBureaux'"
            Me.FillAmount()

            RowIndex += 1
            Write("UGANDA SHILLING EQUIVALENT", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("* Other currencies traded should be reported in USDollar equivalent.", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("This return should be submitted not later than three o'clock in the afternoon of every first business day following the week and not later than five days after the end of the month to which it pertains.", Range("1"), XlHAlign.xlHAlignLeft, , True, )


            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing

    End Function

#End Region

#Region "CMPHEADER"

    Sub CMPHEADER(ByVal CMPID As Integer, ByVal REPORTTITLE As String)
        Try
            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write(REPORTTITLE, Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("6").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("6").ToString & 8).Application.ActiveWindow.FreezePanes = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "INVOICE SUMMARY REPORT"

    Public Function INVOICE_SUMMARY_EXCEL(ByVal CONDITION As String) As Object
        Try
            Dim objCMN As New ClsCommon

            Dim DT As System.Data.DataTable = objCMN.search(" INVOICEMASTER.INVOICE_NO AS INVOICENO, INVOICEMASTER.INVOICE_DATE AS DATE, CUSTOMERMASTER.Customer_cmpname AS NAME, INVOICEMASTER.INVOICE_ORDERNO AS PONO, INVOICEMASTER.INVOICE_ORDERDATE AS PODATE, SUM(INVOICEMASTER_DESC.INVOICE_QTY) AS TOTALSETS, INVOICEMASTER.INVOICE_GRANDTOTAL AS TOTALAMT, (CASE WHEN SUM(INVOICE_QTY) < SALEORDER.SO_TOTALQTY THEN 'PENDING' ELSE 'COMPLETED' END) AS STATUS, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS ", "", " INVOICEMASTER_DESC INNER JOIN INVOICEMASTER ON INVOICEMASTER_DESC.INVOICE_NO = INVOICEMASTER.INVOICE_NO AND INVOICEMASTER_DESC.INVOICE_REGISTERID = INVOICEMASTER.INVOICE_REGISTERID AND INVOICEMASTER_DESC.INVOICE_INITIALS = INVOICEMASTER.INVOICE_INITIALS AND INVOICEMASTER_DESC.INVOICE_CMPID = INVOICEMASTER.INVOICE_CMPID AND INVOICEMASTER_DESC.INVOICE_LOCATIONID = INVOICEMASTER.INVOICE_LOCATIONID AND INVOICEMASTER_DESC.INVOICE_YEARID = INVOICEMASTER.INVOICE_YEARID INNER JOIN CUSTOMERMASTER ON INVOICEMASTER.INVOICE_LEDGERID = CUSTOMERMASTER.Customer_id AND INVOICEMASTER.INVOICE_CMPID = CUSTOMERMASTER.Customer_cmpid AND INVOICEMASTER.INVOICE_LOCATIONID = CUSTOMERMASTER.Customer_locationid AND INVOICEMASTER.INVOICE_YEARID = CUSTOMERMASTER.Customer_yearid INNER JOIN CMPMASTER ON INVOICEMASTER.INVOICE_CMPID = CMPMASTER.cmp_id LEFT OUTER JOIN SALEORDER ON INVOICEMASTER.INVOICE_YEARID = SALEORDER.so_yearid AND INVOICEMASTER.INVOICE_LOCATIONID = SALEORDER.so_locationid AND INVOICEMASTER.INVOICE_CMPID = SALEORDER.so_cmpid AND INVOICEMASTER.INVOICE_ORDERNO = SALEORDER.so_pono", CONDITION & " GROUP BY INVOICEMASTER.INVOICE_NO, INVOICEMASTER.INVOICE_DATE, CUSTOMERMASTER.Customer_cmpname, INVOICEMASTER.INVOICE_ORDERNO, INVOICEMASTER.INVOICE_ORDERDATE, INVOICEMASTER.INVOICE_GRANDTOTAL, SALEORDER.so_totalqty, CMPMASTER.cmp_name, CMPMASTER.cmp_add1, CMPMASTER.cmp_add2, CMPMASTER.cmp_invinitials")

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 6)
            Next

            SetColumnWidth("H1", 15)
            SetColumnWidth("E1", 15)
            'SetColumnWidth("T1", 7)
            'SetColumnWidth("U1", 10)


            '''''''''''Report Title
            'CMPNAME
            RowIndex += 1
            Write(DT.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("25"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("25"))

            'ADD1
            RowIndex += 1
            Write(DT.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("25"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("25"))

            'ADD2
            RowIndex += 1
            Write(DT.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("25"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("25"))

            RowIndex += 1
            Write("INVOICE SUMMARY", Range("1"), XlHAlign.xlHAlignCenter, Range("25"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("25"))


            RowIndex += 2
            Write("Inv No.", Range("1"), XlHAlign.xlHAlignCenter, Range("2"), True, 10)
            Write("Date", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 10)
            Write("Customer", Range("5"), XlHAlign.xlHAlignCenter, Range("7"), True, 10)
            Write("PO No", Range("8"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            Write("PO Date", Range("11"), XlHAlign.xlHAlignCenter, Range("12"), True, 10)
            Write("Total Sets", Range("13"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
            Write("Total Amt", Range("15"), XlHAlign.xlHAlignCenter, Range("16"), True, 10)
            Write("Transport Name", Range("17"), XlHAlign.xlHAlignCenter, Range("19"), True, 10)
            Write("LR No", Range("20"), XlHAlign.xlHAlignCenter, Range("21"), True, 10)
            Write("LR Date", Range("22"), XlHAlign.xlHAlignCenter, Range("23"), True, 10)
            Write("Status", Range("24"), XlHAlign.xlHAlignCenter, Range("25"), True, 10)

            SetBorder(RowIndex, Range("1"), Range("25"))

            For Each dr As DataRow In DT.Rows
                RowIndex += 1
                Write(dr("INVOICENO"), Range("1"), XlHAlign.xlHAlignCenter, Range("2"), False, 10)
                Write(dr("DATE"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                Write(dr("NAME"), Range("5"), XlHAlign.xlHAlignLeft, Range("7"), False, 10)
                Write(dr("PONO"), Range("8"), XlHAlign.xlHAlignLeft, Range("10"), False, 10)
                Write(dr("PODATE"), Range("11"), XlHAlign.xlHAlignLeft, Range("12"), False, 10)
                Write(dr("TOTALSETS"), Range("13"), XlHAlign.xlHAlignRight, Range("14"), False, 10)
                Write(dr("TOTALAMT"), Range("15"), XlHAlign.xlHAlignRight, Range("16"), False, 10)
            Next

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex - DT.Rows.Count, Range("2"))
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex - DT.Rows.Count, Range("4"))
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex - DT.Rows.Count, Range("7"))
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex - DT.Rows.Count, Range("10"))
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex - DT.Rows.Count, Range("12"))
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex - DT.Rows.Count, Range("14"))
            SetBorder(RowIndex, objColumn.Item("15").ToString & RowIndex - DT.Rows.Count, Range("16"))
            SetBorder(RowIndex, objColumn.Item("17").ToString & RowIndex - DT.Rows.Count, Range("19"))
            SetBorder(RowIndex, objColumn.Item("20").ToString & RowIndex - DT.Rows.Count, Range("21"))
            SetBorder(RowIndex, objColumn.Item("22").ToString & RowIndex - DT.Rows.Count, Range("23"))
            SetBorder(RowIndex, objColumn.Item("24").ToString & RowIndex - DT.Rows.Count, Range("25"))

            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("12"))

            Write(DT.Compute("sum(TOTALSETS)", ""), Range("13"), XlHAlign.xlHAlignRight, Range("14"), True, 10)
            Write(DT.Compute("sum(TOTALAMT)", ""), Range("15"), XlHAlign.xlHAlignRight, Range("16"), True, 10)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, Range("14"))
            SetBorder(RowIndex, objColumn.Item("15").ToString & RowIndex, Range("16"))
            SetBorder(RowIndex, objColumn.Item("17").ToString & RowIndex, Range("25"))


            RowIndex += 1
            Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            Write(DT.Rows(0).Item("STATUS"), Range("13"), XlHAlign.xlHAlignLeft, Range("25"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

            objSheet.Range(objColumn.Item("13").ToString & 1, objColumn.Item("13").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("15").ToString & 1, objColumn.Item("15").ToString & RowIndex).NumberFormat = "0.00"

            objBook.Application.ActiveWindow.Zoom = 95

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 144
                .LeftMargin = 50.4
                .RightMargin = 0
                .BottomMargin = 0
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("25").ToString & RowIndex + 2)
            SaveAndClose()


        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "SALES TAX DETAILS REPORT"

    Public Function SALES_TAX_DETAILS_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            Dim objCMN As New ClsCommon
            'Dim DTVAL As System.Data.DataTable
            Dim DT As System.Data.DataTable = objCMN.search(" * ", "", " (SELECT HOTELBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLNO, HOTELBOOKINGMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, HOTELBOOKINGMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, HOTELBOOKINGMASTER.BOOKING_TOTALSALEAMT AS NETT, HOTELBOOKINGMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, HOTELBOOKINGMASTER.BOOKING_TAXID AS TAXID, HOTELBOOKINGMASTER.BOOKING_TAX AS TAXAMT, HOTELBOOKINGMASTER.BOOKING_ADDTAXID AS ADDTAXID, HOTELBOOKINGMASTER.BOOKING_ADDTAX AS ADDTAXAMT, HOTELBOOKINGMASTER.BOOKING_OTHERCHGS AS OTHERCHGS, HOTELBOOKINGMASTER.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, HOTELBOOKINGMASTER.BOOKING_NO AS BILL, 'HOTELBOOKING' AS [TYPE], BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID , BOOKING_YEARID AS YEARID  FROM HOTELBOOKINGMASTER INNER JOIN CMPMASTER ON HOTELBOOKINGMASTER.BOOKING_CMPID = CMPMASTER.cmp_id LEFT OUTER JOIN LEDGERS ON HOTELBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOTELBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOTELBOOKINGMASTER.BOOKING_PURLEDGERID = LEDGERS.Acc_id WHERE BOOKING_BOOKTYPE = 'BOOKING' AND BOOKING_CANCELLED = 'FALSE' AND BOOKING_AMD_DONE = 'FALSE' UNION ALL SELECT HOLIDAYPACKAGEMASTER.BOOKING_SALEBILLINITIALS AS BILLNO, HOLIDAYPACKAGEMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, HOLIDAYPACKAGEMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, HOLIDAYPACKAGEMASTER.BOOKING_TOTALSALEAMT AS NETT, HOLIDAYPACKAGEMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, HOLIDAYPACKAGEMASTER.BOOKING_TAXID AS TAXID, HOLIDAYPACKAGEMASTER.BOOKING_TAX AS TAXAMT, HOLIDAYPACKAGEMASTER.BOOKING_ADDTAXID AS ADDTAXID, HOLIDAYPACKAGEMASTER.BOOKING_ADDTAX AS ADDTAXAMT, HOLIDAYPACKAGEMASTER.BOOKING_OTHERCHGS AS OTHERCHGS, HOLIDAYPACKAGEMASTER.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, HOLIDAYPACKAGEMASTER.BOOKING_NO AS BILL, 'PACKAGE' AS [TYPE], BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID , BOOKING_YEARID AS YEARID FROM HOLIDAYPACKAGEMASTER INNER JOIN LEDGERS ON HOLIDAYPACKAGEMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id AND HOLIDAYPACKAGEMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOLIDAYPACKAGEMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN CMPMASTER ON HOLIDAYPACKAGEMASTER.BOOKING_CMPID = CMPMASTER.cmp_id WHERE BOOKING_CANCELLED = 'FALSE' AND BOOKING_AMD_DONE = 'FALSE' UNION ALL SELECT INTERNATIONALBOOKINGMASTER.BOOKING_SALEBILLINITIALS AS BILLNO, INTERNATIONALBOOKINGMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, INTERNATIONALBOOKINGMASTER.BOOKING_GRANDTOTAL AS GRANDTOTAL, INTERNATIONALBOOKINGMASTER.BOOKING_TOTALSALEAMT AS NETT, INTERNATIONALBOOKINGMASTER.BOOKING_SUBTOTAL AS SUBTOTAL, INTERNATIONALBOOKINGMASTER.BOOKING_TAXID AS TAXID, INTERNATIONALBOOKINGMASTER.BOOKING_TAX AS TAXAMT, INTERNATIONALBOOKINGMASTER.BOOKING_ADDTAXID AS ADDTAXID, INTERNATIONALBOOKINGMASTER.BOOKING_ADDTAX AS ADDTAXAMT, INTERNATIONALBOOKINGMASTER.BOOKING_OTHERCHGS AS OTHERCHGS, INTERNATIONALBOOKINGMASTER.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, INTERNATIONALBOOKINGMASTER.BOOKING_NO AS BILL, 'INTERNATIONAL' AS [TYPE], BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID , BOOKING_YEARID AS YEARID FROM INTERNATIONALBOOKINGMASTER INNER JOIN LEDGERS ON INTERNATIONALBOOKINGMASTER.BOOKING_LEDGERID = LEDGERS.Acc_id AND INTERNATIONALBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND INTERNATIONALBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN CMPMASTER ON INTERNATIONALBOOKINGMASTER.BOOKING_CMPID = CMPMASTER.cmp_id WHERE BOOKING_CANCELLED = 'FALSE' AND BOOKING_AMD_DONE = 'FALSE' union all SELECT CN_initials AS BILLNO, CN_date AS DATE, LEDGERS.Acc_cmpname AS NAME, (CN_GTOTAL * (-1)) AS GRANDTOTAL, (CN_TOTALAMT * (-1)) AS NETT  , (CN_SUBTOTAL * (-1)) AS SUBTOTAL,	CN_TAXID AS TAXID, (CN_TAX * (-1)) AS TAXAMT, CN_ADDTAXID AS ADDTAXID, (CN_ADDTAX  * (-1)) AS ADDTAXAMT, (CN_OTHERCHGS * (-1)) AS OTHERCHGS, (CN_ROUNDOFF *(-1)) AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, CN_no AS BILL, 'CREDITNOTE' AS TYPE, CN_cmpid AS CMPID, CN_locationid AS LOCATIONID, CN_yearid AS YEARID FROM CREDITNOTEMASTER INNER JOIN LEDGERS ON Acc_id = CN_LEDGERID AND Acc_cmpid =  CN_cmpid AND Acc_locationid = CN_locationid AND Acc_yearid = CN_yearid INNER JOIN CMPMASTER ON CN_cmpid = cmp_id ) AS T ", CONDITION & " ORDER BY T.TYPE,T.DATE, T.BILL ")
            'Dim DT As System.Data.DataTable = objCMN.search(" PURCHASEMASTER.BILL_NO AS BILLNO, PURCHASEMASTER.BILL_DATE AS DATE, VENDORMASTER.VENDOR_cmpname AS NAME, PURCHASEMASTER.BILL_GRANDTOTAL AS GRANDTOTAL, PURCHASEMASTER.BILL_NETT AS NETT, (PURCHASEMASTER.BILL_NETT + PURCHASEMASTER.BILL_EXCISEAMT + PURCHASEMASTER.BILL_EDUCESSAMT + PURCHASEMASTER.BILL_HSECESSAMT) AS SUBTOTAL, ISNULL(PURCHASEMASTER.BILL_EXCISEID,'') AS EXCISEID, ISNULL(PURCHASEMASTER.BILL_EXCISEAMT,0) AS EXCISEAMT, ISNULL(PURCHASEMASTER.BILL_EDUCESSAMT,0) AS EDUCESSAMT, ISNULL(PURCHASEMASTER.BILL_HSECESSAMT,0) AS HSECESSAMT , ISNULL(PURCHASEMASTER.BILL_TAXID,'') AS TAXID, ISNULL(PURCHASEMASTER.BILL_TAXAMT,0) AS TAXAMT , ISNULL(PURCHASEMASTER.BILL_ADDTAXID,'') AS ADDTAXID, ISNULL(PURCHASEMASTER.BILL_ADDTAXAMT,0) AS ADDTAXAMT , PURCHASEMASTER.BILL_FREIGHT AS FREIGHT, PURCHASEMASTER.BILL_OCTROIAMT AS OCTROIAMT, PURCHASEMASTER.BILL_INSAMT AS INSAMT, PURCHASEMASTER.BILL_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS ", "", " PURCHASEMASTER INNER JOIN CMPMASTER ON PURCHASEMASTER.BILL_CMPID = CMPMASTER.cmp_id INNER JOIN VENDORMASTER ON VENDORMASTER.VENDOR_id = PURCHASEMASTER.BILL_LEDGERID AND VENDORMASTER.VENDOR_cmpid = PURCHASEMASTER.BILL_CMPID AND VENDORMASTER.VENDOR_locationid = PURCHASEMASTER.BILL_LOCATIONID AND VENDORMASTER.VENDOR_yearid = PURCHASEMASTER.BILL_YEARID", CONDITION & " ORDER BY BILL_NO")

            If DT.Rows.Count > 0 Then


                'FOR TAXAMT
                Dim DTTAX As System.Data.DataTable = objCMN.search(" DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER ", " AND TAX_ID IN (SELECT BOOKING_TAXID FROM HOTELBOOKINGMASTER UNION ALL SELECT BOOKING_TAXID  FROM HOLIDAYPACKAGEMASTER UNION ALL  SELECT BOOKING_TAXID FROM INTERNATIONALBOOKINGMASTER) AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
                If DTTAX.Rows.Count > 0 Then
                    For Each DRTAX As DataRow In DTTAX.Rows
                        DT.Columns.Add("SUBTOTAL " & DRTAX("TAXNAME"))
                        DT.Columns.Add(DRTAX("TAXNAME"))
                        For Each DR As DataRow In DT.Select("TAXID = " & DRTAX("TAXID"))
                            'DTVAL = objCMN.search("PURCHASEMASTER.BILL_TAXAMT AS TAXAMT", "", " PURCHASEMASTER", " AND BILL_NO = " & DR("BILLNO") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = DR("SUBTOTAL")
                            'DR("SUBTOTAL " & DRTAX("TAXNAME")) = 0
                            'For i As Integer = 16 To DT.Columns.Count - 1
                            '    If IsDBNull(DR(i)) = False Then DR("SUBTOTAL " & DRTAX("TAXNAME")) = Convert.ToDouble(DR("SUBTOTAL " & DRTAX("TAXNAME"))) + Convert.ToDouble(DR(i))
                            'Next
                            'DR("SUBTOTAL " & DRTAX("TAXNAME")) = DR("SUBTOTAL " & DRTAX("TAXNAME")) + DR("NETT")
                            DR(DRTAX("TAXNAME")) = DR("TAXAMT")
                        Next
                    Next
                End If



                'FOR ADDTAXAMT
                Dim DTADDTAX As System.Data.DataTable = objCMN.search(" DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER ", " AND TAX_ID IN (SELECT BOOKING_ADDTAXID FROM HOTELBOOKINGMASTER UNION ALL SELECT BOOKING_ADDTAXID  FROM HOLIDAYPACKAGEMASTER UNION ALL  SELECT BOOKING_ADDTAXID FROM INTERNATIONALBOOKINGMASTER) AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
                If DTADDTAX.Rows.Count > 0 Then
                    For Each DRADDTAX As DataRow In DTADDTAX.Rows
                        DT.Columns.Add(DRADDTAX("TAXNAME"))
                        For Each DR As DataRow In DT.Select("ADDTAXID = " & DRADDTAX("TAXID"))
                            'DTVAL = objCMN.search("PURCHASEMASTER.BILL_ADDTAXAMT AS TAXAMT", "", " PURCHASEMASTER", " AND BILL_NO = " & DR("BILLNO") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                            DR(DRADDTAX("TAXNAME")) = DR("ADDTAXAMT")
                        Next
                    Next
                End If



                SetWorkSheet()
                For I As Integer = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next


                RowIndex = 1
                For i As Integer = 1 To 26
                    SetColumnWidth(Range(i), 11)
                Next

                SetColumnWidth("A1", 6)
                SetColumnWidth("B1", 10)
                SetColumnWidth("C1", 30)



                'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
                'COZ HERE WE DONT KNOW NO OF COLUMS
                RowIndex += 6
                Write("Inv No.", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Date", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Name", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("G. Total", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Nett Total", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
                Dim T As Integer = 6
                For S As Integer = 21 To DT.Columns.Count - 1
                    Write(DT.Columns(S).ColumnName, Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                    T = T + 1
                Next
                Write("Other Charges", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                T = T + 1
                Write("Round Off", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)


                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & RowIndex)


                For Each dr As DataRow In DT.Rows
                    RowIndex += 1
                    Write(dr("BILLNO"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(dr("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("GRANDTOTAL"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(dr("NETT"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                    Dim R As Integer = 6
                    For I As Integer = 21 To DT.Columns.Count - 1
                        Write(dr(I), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                        objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                        R = R + 1
                    Next

                    Write(dr("OTHERCHGS"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                    R = R + 1

                    Write(dr("ROUNDOFF"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"

                Next

                For I As Integer = 1 To DT.Columns.Count - 14
                    SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & RowIndex - DT.Rows.Count, objColumn.Item(I.ToString).ToString & RowIndex + 1)
                Next


                RowIndex += 1
                Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 9)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("3"))

                Write(DT.Compute("sum(GRANDTOTAL)", ""), Range("4"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
                Write(DT.Compute("sum(NETT)", ""), Range("5"), XlHAlign.xlHAlignRight, Range("5"), True, 9)
                SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, Range("4"))
                SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, Range("5"))

                Dim M As Integer = 6
                For I As Integer = 21 To DT.Columns.Count - 1
                    FORMULA("=SUM(" & objColumn.Item(M.ToString).ToString & RowIndex - DT.Rows.Count & ":" & objColumn.Item(M.ToString).ToString & RowIndex - 1 & ")", Range(M.ToString), XlHAlign.xlHAlignRight, , True, 9)
                    SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                    M = M + 1
                Next

                Write(DT.Compute("sum(OTHERCHGS)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 9)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                M = M + 1
                Write(DT.Compute("sum(ROUNDOFF)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 9)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))


                'RowIndex += 1
                'Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 9)
                'Write(DT.Rows(0).Item("STATUS"), Range("14"), XlHAlign.xlHAlignLeft, Range("25"), True, 9)
                'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

                objSheet.Range(objColumn.Item("4").ToString & 1, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
                objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"


                SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & RowIndex + 2)


                '''''''''''Report Title
                'CMPNAME
                RowIndex = 2
                Write(DT.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 14)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'ADD1
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'ADD2
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))


                RowIndex += 1
                Write("SALES-TAX DETAILS REPORT", Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 12)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'FREEZE TOP 7 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & 8).Select()
                objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True


                objBook.Application.ActiveWindow.Zoom = 95

                With objSheet.PageSetup
                    .Orientation = XlPageOrientation.xlLandscape
                    .TopMargin = 144
                    .LeftMargin = 50.4
                    .RightMargin = 0
                    .BottomMargin = 0
                    .Zoom = False
                    .FitToPagesTall = 1
                    .FitToPagesWide = 1
                End With

                SaveAndClose()

            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "PURCHASE TAX DETAILS REPORT"

    Public Function PURCHASE_TAX_DETAILS_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            Dim objCMN As New ClsCommon
            'Dim DTVAL As System.Data.DataTable
            Dim DT As System.Data.DataTable = objCMN.search(" * ", "", " (SELECT HOTELBOOKINGMASTER.BOOKING_PURBILLINITIALS AS BILLNO, HOTELBOOKINGMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, HOTELBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS GRANDTOTAL, HOTELBOOKINGMASTER.BOOKING_PURSUBTOTAL AS NETT, HOTELBOOKINGMASTER.BOOKING_PURNETTAMT AS SUBTOTAL, HOTELBOOKINGMASTER.BOOKING_PURTAXID AS TAXID, HOTELBOOKINGMASTER.BOOKING_PURTAX AS TAXAMT, HOTELBOOKINGMASTER.BOOKING_PURADDTAXID AS ADDTAXID, HOTELBOOKINGMASTER.BOOKING_PURADDTAX AS ADDTAXAMT, HOTELBOOKINGMASTER.BOOKING_PUROTHERCHGS AS OTHERCHGS, HOTELBOOKINGMASTER.BOOKING_PURROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, HOTELBOOKINGMASTER.BOOKING_NO AS BILL, 'HOTELBOOKING' AS TYPE, BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM HOTELBOOKINGMASTER INNER JOIN CMPMASTER ON HOTELBOOKINGMASTER.BOOKING_CMPID = CMPMASTER.cmp_id LEFT OUTER JOIN LEDGERS ON HOTELBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOTELBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOTELBOOKINGMASTER.BOOKING_PURLEDGERID = LEDGERS.Acc_id WHERE HOTELBOOKINGMASTER.BOOKING_CANCELLED = 'FALSE' AND HOTELBOOKINGMASTER.BOOKING_AMD_DONE = 'FALSE' UNION ALL Select DISTINCT HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURBILLINITIALS AS BILLNO, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_GTOTAL AS GRANDTOTAL, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_SUBTOTAL AS NETT, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_NETT AS SUBTOTAL, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_TAXID AS TAXID, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_TAXAMT AS TAXAMT, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_ADDTAXID AS ADDTAXID, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_ADDTAXAMT AS ADDTAXAMT, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_OTHERCHGS AS OTHERCHGS, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_NO AS BILL, 'PACKAGE' AS TYPE, HOLIDAYPACKAGEMASTER.BOOKING_CMPID AS CMPID, HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID AS LOCATIONID, HOLIDAYPACKAGEMASTER.BOOKING_YEARID AS YEARID FROM HOLIDAYPACKAGEMASTER_PURCHASEDETAILS INNER JOIN CMPMASTER ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = CMPMASTER.cmp_id INNER JOIN LEDGERS ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURLEDGERID = LEDGERS.Acc_id AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN HOLIDAYPACKAGEMASTER ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_NO = HOLIDAYPACKAGEMASTER.BOOKING_NO AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = HOLIDAYPACKAGEMASTER.BOOKING_CMPID AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_YEARID = HOLIDAYPACKAGEMASTER.BOOKING_YEARID WHERE (HOLIDAYPACKAGEMASTER.BOOKING_CANCELLED = 'FALSE') AND (HOLIDAYPACKAGEMASTER.BOOKING_AMD_DONE = 'FALSE') UNION ALL Select DISTINCT INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURBILLINITIALS AS BILLNO, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_GTOTAL AS GRANDTOTAL, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_SUBTOTAL AS NETT, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NETT AS SUBTOTAL, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_TAXID AS TAXID, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_TAXAMT AS TAXAMT, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_ADDTAXID AS ADDTAXID, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_ADDTAXAMT AS ADDTAXAMT, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_OTHERCHGS AS OTHERCHGS, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NO AS BILL, 'INTERNATIONAL' AS TYPE, INTERNATIONALBOOKINGMASTER.BOOKING_CMPID AS CMPID, INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, INTERNATIONALBOOKINGMASTER.BOOKING_YEARID AS YEARID FROM INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS INNER JOIN CMPMASTER ON INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = CMPMASTER.cmp_id INNER JOIN LEDGERS ON INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURLEDGERID = LEDGERS.Acc_id AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = LEDGERS.Acc_cmpid AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN INTERNATIONALBOOKINGMASTER ON INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NO = INTERNATIONALBOOKINGMASTER.BOOKING_NO AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = INTERNATIONALBOOKINGMASTER.BOOKING_CMPID AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID = INTERNATIONALBOOKINGMASTER.BOOKING_YEARID WHERE (INTERNATIONALBOOKINGMASTER.BOOKING_CANCELLED = 'FALSE') AND (INTERNATIONALBOOKINGMASTER.BOOKING_AMD_DONE = 'FALSE')) AS T ", CONDITION & " ORDER BY T.TYPE,T.DATE, T.BILL ")
            'Dim DT As System.Data.DataTable = objCMN.search(" PURCHASEMASTER.BILL_NO AS BILLNO, PURCHASEMASTER.BILL_DATE AS DATE, VENDORMASTER.VENDOR_cmpname AS NAME, PURCHASEMASTER.BILL_GRANDTOTAL AS GRANDTOTAL, PURCHASEMASTER.BILL_NETT AS NETT, (PURCHASEMASTER.BILL_NETT + PURCHASEMASTER.BILL_EXCISEAMT + PURCHASEMASTER.BILL_EDUCESSAMT + PURCHASEMASTER.BILL_HSECESSAMT) AS SUBTOTAL, ISNULL(PURCHASEMASTER.BILL_EXCISEID,'') AS EXCISEID, ISNULL(PURCHASEMASTER.BILL_EXCISEAMT,0) AS EXCISEAMT, ISNULL(PURCHASEMASTER.BILL_EDUCESSAMT,0) AS EDUCESSAMT, ISNULL(PURCHASEMASTER.BILL_HSECESSAMT,0) AS HSECESSAMT , ISNULL(PURCHASEMASTER.BILL_TAXID,'') AS TAXID, ISNULL(PURCHASEMASTER.BILL_TAXAMT,0) AS TAXAMT , ISNULL(PURCHASEMASTER.BILL_ADDTAXID,'') AS ADDTAXID, ISNULL(PURCHASEMASTER.BILL_ADDTAXAMT,0) AS ADDTAXAMT , PURCHASEMASTER.BILL_FREIGHT AS FREIGHT, PURCHASEMASTER.BILL_OCTROIAMT AS OCTROIAMT, PURCHASEMASTER.BILL_INSAMT AS INSAMT, PURCHASEMASTER.BILL_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS ", "", " PURCHASEMASTER INNER JOIN CMPMASTER ON PURCHASEMASTER.BILL_CMPID = CMPMASTER.cmp_id INNER JOIN VENDORMASTER ON VENDORMASTER.VENDOR_id = PURCHASEMASTER.BILL_LEDGERID AND VENDORMASTER.VENDOR_cmpid = PURCHASEMASTER.BILL_CMPID AND VENDORMASTER.VENDOR_locationid = PURCHASEMASTER.BILL_LOCATIONID AND VENDORMASTER.VENDOR_yearid = PURCHASEMASTER.BILL_YEARID", CONDITION & " ORDER BY BILL_NO")

            If DT.Rows.Count > 0 Then


                'FOR TAXAMT
                Dim DTTAX As System.Data.DataTable = objCMN.search(" DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER ", " AND TAX_ID IN (SELECT BOOKING_PURTAXID FROM HOTELBOOKINGMASTER UNION ALL SELECT BOOKING_TAXID  FROM HOLIDAYPACKAGEMASTER_PURCHASEDETAILS UNION ALL  SELECT BOOKING_TAXID FROM INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS) AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
                If DTTAX.Rows.Count > 0 Then
                    For Each DRTAX As DataRow In DTTAX.Rows
                        DT.Columns.Add("SUBTOTAL " & DRTAX("TAXNAME"))
                        DT.Columns.Add(DRTAX("TAXNAME"))
                        For Each DR As DataRow In DT.Select("TAXID = " & DRTAX("TAXID"))
                            'DTVAL = objCMN.search("PURCHASEMASTER.BILL_TAXAMT AS TAXAMT", "", " PURCHASEMASTER", " AND BILL_NO = " & DR("BILLNO") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = DR("SUBTOTAL")
                            'DR("SUBTOTAL " & DRTAX("TAXNAME")) = 0
                            'For i As Integer = 16 To DT.Columns.Count - 1
                            '    If IsDBNull(DR(i)) = False Then DR("SUBTOTAL " & DRTAX("TAXNAME")) = Convert.ToDouble(DR("SUBTOTAL " & DRTAX("TAXNAME"))) + Convert.ToDouble(DR(i))
                            'Next
                            'DR("SUBTOTAL " & DRTAX("TAXNAME")) = DR("SUBTOTAL " & DRTAX("TAXNAME")) + DR("NETT")
                            DR(DRTAX("TAXNAME")) = DR("TAXAMT")
                        Next
                    Next
                End If



                'FOR ADDTAXAMT
                Dim COLINDEX As Integer = 0
                Dim DTADDTAX As System.Data.DataTable = objCMN.search(" DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER ", " AND TAX_ID IN (SELECT BOOKING_PURADDTAXID FROM HOTELBOOKINGMASTER UNION ALL SELECT BOOKING_ADDTAXID  FROM HOLIDAYPACKAGEMASTER_PURCHASEDETAILS UNION ALL  SELECT BOOKING_ADDTAXID FROM INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS) AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
                If DTADDTAX.Rows.Count > 0 Then
                    For Each DRADDTAX As DataRow In DTADDTAX.Rows
                        COLINDEX = DT.Columns.IndexOf(DRADDTAX("TAXNAME"))
                        If COLINDEX = 0 Then DT.Columns.Add(DRADDTAX("TAXNAME"))
                        For Each DR As DataRow In DT.Select("ADDTAXID = " & DRADDTAX("TAXID") & " OR TAXID = " & DRADDTAX("TAXID"))
                            'DTVAL = objCMN.search("PURCHASEMASTER.BILL_ADDTAXAMT AS TAXAMT", "", " PURCHASEMASTER", " AND BILL_NO = " & DR("BILLNO") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                            If IsDBNull(DR(DRADDTAX("TAXNAME"))) = False Then
                                DR(DRADDTAX("TAXNAME")) = Val(DR(DRADDTAX("TAXNAME"))) + DR("ADDTAXAMT")
                            Else
                                DR(DRADDTAX("TAXNAME")) = DR("ADDTAXAMT")
                            End If
                        Next
                    Next
                End If



                SetWorkSheet()
                For I As Integer = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next


                RowIndex = 1
                For i As Integer = 1 To 26
                    SetColumnWidth(Range(i), 11)
                Next

                SetColumnWidth("A1", 6)
                SetColumnWidth("B1", 10)
                SetColumnWidth("C1", 30)



                'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
                'COZ HERE WE DONT KNOW NO OF COLUMS
                RowIndex += 6
                Write("Inv No.", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Date", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Name", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("G. Total", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Nett Total", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
                Dim T As Integer = 6
                For S As Integer = 21 To DT.Columns.Count - 1
                    Write(DT.Columns(S).ColumnName, Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                    T = T + 1
                Next
                Write("Other Charges", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                T = T + 1
                Write("Round Off", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)


                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & RowIndex)


                For Each dr As DataRow In DT.Rows
                    RowIndex += 1
                    Write(dr("BILLNO"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(dr("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("GRANDTOTAL"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(dr("NETT"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                    Dim R As Integer = 6
                    For I As Integer = 21 To DT.Columns.Count - 1
                        Write(dr(I), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                        objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                        R = R + 1
                    Next

                    Write(dr("OTHERCHGS"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                    R = R + 1

                    Write(dr("ROUNDOFF"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"

                Next

                For I As Integer = 1 To DT.Columns.Count - 14
                    SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & RowIndex - DT.Rows.Count, objColumn.Item(I.ToString).ToString & RowIndex + 1)
                Next


                RowIndex += 1
                Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 9)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("3"))

                Write(DT.Compute("sum(GRANDTOTAL)", ""), Range("4"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
                Write(DT.Compute("sum(NETT)", ""), Range("5"), XlHAlign.xlHAlignRight, Range("5"), True, 9)
                SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, Range("4"))
                SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, Range("5"))

                Dim M As Integer = 6
                For I As Integer = 21 To DT.Columns.Count - 1
                    FORMULA("=SUM(" & objColumn.Item(M.ToString).ToString & RowIndex - DT.Rows.Count & ":" & objColumn.Item(M.ToString).ToString & RowIndex - 1 & ")", Range(M.ToString), XlHAlign.xlHAlignRight, , True, 9)
                    SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                    M = M + 1
                Next

                Write(DT.Compute("sum(OTHERCHGS)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 9)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                M = M + 1
                Write(DT.Compute("sum(ROUNDOFF)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 9)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))


                'RowIndex += 1
                'Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 9)
                'Write(DT.Rows(0).Item("STATUS"), Range("14"), XlHAlign.xlHAlignLeft, Range("25"), True, 9)
                'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

                objSheet.Range(objColumn.Item("4").ToString & 1, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
                objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"


                SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & RowIndex + 2)


                '''''''''''Report Title
                'CMPNAME
                RowIndex = 2
                Write(DT.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 14)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'ADD1
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'ADD2
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))


                RowIndex += 1
                Write("Purchase-TAX DETAILS REPORT", Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 12)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'FREEZE TOP 7 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & 8).Select()
                objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True


                objBook.Application.ActiveWindow.Zoom = 95

                With objSheet.PageSetup
                    .Orientation = XlPageOrientation.xlLandscape
                    .TopMargin = 144
                    .LeftMargin = 50.4
                    .RightMargin = 0
                    .BottomMargin = 0
                    .Zoom = False
                    .FitToPagesTall = 1
                    .FitToPagesWide = 1
                End With

                SaveAndClose()

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "SALES TAX SUMMARY REPORT"

    Public Function SALES_TAX_SUMMARY_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            Dim DTMONTH As New System.Data.DataTable
            DTMONTH.Columns.Add("MONTH")

            DTMONTH.Rows.Add(4)
            DTMONTH.Rows.Add(5)
            DTMONTH.Rows.Add(6)
            DTMONTH.Rows.Add(7)
            DTMONTH.Rows.Add(8)
            DTMONTH.Rows.Add(9)
            DTMONTH.Rows.Add(10)
            DTMONTH.Rows.Add(11)
            DTMONTH.Rows.Add(12)
            DTMONTH.Rows.Add(1)
            DTMONTH.Rows.Add(2)
            DTMONTH.Rows.Add(3)

            DTMONTH.Columns.Add("GRANDTOTAL")
            DTMONTH.Columns.Add("NETTAMT")


            Dim objCMN As New ClsCommon
            Dim DTVAL As System.Data.DataTable
            For Each DR As DataRow In DTMONTH.Rows
                DTVAL = objCMN.search(" ISNULL(SUM(HOTELBOOKINGMASTER.BOOKING_GRANDTOTAL),0) AS GRANDTOTAL, ISNULL(SUM(HOTELBOOKINGMASTER.BOOKING_SUBTOTAL),0) AS NETTAMT", "", " HOTELBOOKINGMASTER", " AND BOOKING_BOOKTYPE = 'BOOKING' AND MONTH(BOOKING_DATE) = " & Val(DR("MONTH")) & " AND BOOKING_CMPID = " & CMPID & " AND BOOKING_LOCATIONID = " & LOCATIONID & " AND BOOKING_YEARID = " & YEARID)
                If DTVAL.Rows.Count > 0 Then
                    DR("GRANDTOTAL") = Convert.ToDouble(DTVAL.Rows(0).Item("GRANDTOTAL"))
                    DR("NETTAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("NETTAMT"))
                Else
                    DR("GRANDTOTAL") = 0.0
                    DR("NETTAMT") = 0.0
                End If
            Next


            'FOR EXCISE AMT
            'Dim DTEXCISE As System.Data.DataTable = objCMN.search("DISTINCT EXCISE_ID AS EXCISEID, EXCISE_NAME AS EXCISENAME, EXCISE_EDU AS EDU, EXCISE_HSE AS HSE", "", " EXCISEMASTER RIGHT OUTER JOIN INVOICEMASTER ON EXCISEMASTER.EXCISE_yearid = INVOICEMASTER.INVOICE_YEARID AND EXCISEMASTER.EXCISE_locationid = INVOICEMASTER.INVOICE_LOCATIONID AND EXCISEMASTER.EXCISE_cmpid = INVOICEMASTER.INVOICE_CMPID AND EXCISEMASTER.EXCISE_id = INVOICEMASTER.INVOICE_EXCISEID ", " AND EXCISE_CMPID = " & CMPID & " AND EXCISE_LOCATIONID = " & LOCATIONID & " AND EXCISE_YEARID = " & YEARID)
            'If DTEXCISE.Rows.Count > 0 Then
            '    For Each DREXCISE As DataRow In DTEXCISE.Rows
            '        DTMONTH.Columns.Add("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Sales")
            '        DTMONTH.Columns.Add("Edu Cess @" & DREXCISE("EDU") & "%- Sales")
            '        DTMONTH.Columns.Add("S & H @" & DREXCISE("HSE") & "%- Sales")
            '        For Each DR As DataRow In DTMONTH.Rows
            '            DTVAL = objCMN.search(" ISNULL(SUM(INVOICEMASTER.INVOICE_EXCISEAMT),0) AS EXCISEAMT, ISNULL(SUM(INVOICEMASTER.INVOICE_EDUCESSAMT),0) AS EDUCESSAMT, ISNULL(SUM(INVOICEMASTER.INVOICE_HSECESSAMT),0) AS HSECESSAMT", "", " INVOICEMASTER", " AND INVOICE_EXCISEID = " & DTEXCISE.Rows(0).Item("EXCISEID") & " AND MONTH(INVOICE_DATE) = " & Val(DR("MONTH")) & " AND INVOICE_CMPID = " & CMPID & " AND INVOICE_LOCATIONID = " & LOCATIONID & " AND INVOICE_YEARID = " & YEARID)
            '            If DTVAL.Rows.Count > 0 Then
            '                DR("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Sales") = Convert.ToDouble(DTVAL.Rows(0).Item("EXCISEAMT"))
            '                DR("Edu Cess @" & DREXCISE("EDU") & "%- Sales") = Convert.ToDouble(DTVAL.Rows(0).Item("EDUCESSAMT"))
            '                DR("S & H @" & DREXCISE("HSE") & "%- Sales") = Convert.ToDouble(DTVAL.Rows(0).Item("HSECESSAMT"))
            '            Else
            '                DR("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Sales") = 0.0
            '                DR("Edu Cess @" & DREXCISE("EDU") & "%- Sales") = 0.0
            '                DR("S & H @" & DREXCISE("HSE") & "%- Sales") = 0.0
            '            End If
            '        Next
            '    Next
            'End If



            'FOR TAXAMT
            Dim DTTAX As System.Data.DataTable = objCMN.search("DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER RIGHT OUTER JOIN HOTELBOOKINGMASTER ON TAXMASTER.TAX_yearid = HOTELBOOKINGMASTER.BOOKING_YEARID AND TAXMASTER.TAX_locationid = HOTELBOOKINGMASTER.BOOKING_LOCATIONID AND TAXMASTER.TAX_cmpid = HOTELBOOKINGMASTER.BOOKING_CMPID AND TAXMASTER.TAX_id = HOTELBOOKINGMASTER.BOOKING_TAXID ", " AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
            If DTTAX.Rows.Count > 0 Then
                For Each DRTAX As DataRow In DTTAX.Rows
                    DTMONTH.Columns.Add("SUBTOTAL " & DRTAX("TAXNAME"))
                    DTMONTH.Columns.Add(DRTAX("TAXNAME"))
                    For Each DR As DataRow In DTMONTH.Rows
                        DTVAL = objCMN.search(" ISNULL(SUM(HOTELBOOKINGMASTER.BOOKING_SUBTOTAL),0) AS SUBTOTAL, ISNULL(SUM(HOTELBOOKINGMASTER.BOOKING_TAX),0) AS TAXAMT ", "", " HOTELBOOKINGMASTER", " AND HOTELBOOKINGMASTER.BOOKING_TAXID = " & DRTAX("TAXID") & " AND HOTELBOOKINGMASTER.BOOKING_BOOKTYPE = 'BOOKING' AND MONTH(HOTELBOOKINGMASTER.BOOKING_DATE) = " & Val(DR("MONTH")) & " AND HOTELBOOKINGMASTER.BOOKING_CMPID = " & CMPID & " AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = " & LOCATIONID & " AND HOTELBOOKINGMASTER.BOOKING_YEARID = " & YEARID)
                        If DTVAL.Rows.Count > 0 Then
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("SUBTOTAL"))
                            DR(DRTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("TAXAMT"))
                        Else
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = 0.0
                            DR(DRTAX("TAXNAME")) = 0.0
                        End If
                    Next
                Next
            End If


            ''FOR ADDTAXAMT
            'Dim DTADDTAX As System.Data.DataTable = objCMN.search("DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER RIGHT OUTER JOIN INVOICEMASTER ON TAXMASTER.TAX_yearid = INVOICEMASTER.INVOICE_YEARID AND TAXMASTER.TAX_locationid = INVOICEMASTER.INVOICE_LOCATIONID AND TAXMASTER.TAX_cmpid = INVOICEMASTER.INVOICE_CMPID AND TAXMASTER.TAX_id = INVOICEMASTER.INVOICE_ADDTAXID ", " AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
            'If DTADDTAX.Rows.Count > 0 Then
            '    For Each DRADDTAX As DataRow In DTADDTAX.Rows
            '        DTMONTH.Columns.Add(DRADDTAX("TAXNAME"))
            '        For Each DR As DataRow In DTMONTH.Rows
            '            DTVAL = objCMN.search("ISNULL(SUM(INVOICEMASTER.INVOICE_ADDTAXAMT),0) AS ADDTAXAMT", "", " INVOICEMASTER", " AND INVOICE_ADDTAXID = " & DRADDTAX("TAXID") & " AND MONTH(INVOICE_DATE)= " & DR("MONTH") & " AND INVOICE_CMPID = " & CMPID & " AND INVOICE_LOCATIONID = " & LOCATIONID & " AND INVOICE_YEARID = " & YEARID)
            '            If DTVAL.Rows.Count > 0 Then
            '                DR(DRADDTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("ADDTAXAMT"))
            '            Else
            '                DR(DRADDTAX("TAXNAME")) = 0.0
            '            End If
            '        Next
            '    Next
            'End If


            'DTMONTH.Columns.Add("FREIGHT")
            'DTMONTH.Columns.Add("OCTROIAMT")
            'DTMONTH.Columns.Add("INSAMT")
            'DTMONTH.Columns.Add("ROUNDOFF")
            'For Each DR As DataRow In DTMONTH.Rows
            '    DTVAL = objCMN.search(" ISNULL(SUM(INVOICEMASTER.INVOICE_FREIGHT),0) AS FREIGHT, ISNULL(SUM(INVOICEMASTER.INVOICE_OCTROIAMT),0) AS OCTROIAMT, ISNULL(SUM(INVOICEMASTER.INVOICE_INSAMT),0) AS INSAMT, ISNULL(SUM(INVOICEMASTER.INVOICE_ROUNDOFF),0) AS ROUNDOFF", "", " INVOICEMASTER", " AND MONTH(INVOICE_DATE) = " & Val(DR("MONTH")) & " AND INVOICE_CMPID = " & CMPID & " AND INVOICE_LOCATIONID = " & LOCATIONID & " AND INVOICE_YEARID = " & YEARID)
            '    If DTVAL.Rows.Count > 0 Then
            '        DR("FREIGHT") = Convert.ToDouble(DTVAL.Rows(0).Item("FREIGHT"))
            '        DR("OCTROIAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("OCTROIAMT"))
            '        DR("INSAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("INSAMT"))
            '        DR("ROUNDOFF") = Convert.ToDouble(DTVAL.Rows(0).Item("ROUNDOFF"))
            '    Else
            '        DR("FREIGHT") = 0.0
            '        DR("OCTROIAMT") = 0.0
            '        DR("INSAMT") = 0.0
            '        DR("ROUNDOFF") = 0.0
            '    End If
            'Next



            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 11)
            Next

            SetColumnWidth("A1", 11)



            'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
            'COZ HERE WE DONT KNOW NO OF COLUMS
            RowIndex += 6
            Write("Month", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("G. Total", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Nett Total", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Dim T As Integer = 4
            For S As Integer = 3 To DTMONTH.Columns.Count - 5
                Write(DTMONTH.Columns(S).ColumnName, Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
                T = T + 1
            Next
            'Write("Freight", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            'T = T + 1
            'Write("Octroi", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            'T = T + 1
            'Write("Inspection Charges", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            'T = T + 1
            'Write("Round Off", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((DTMONTH.Columns.Count).ToString).ToString & RowIndex)


            For Each dr As DataRow In DTMONTH.Rows
                RowIndex += 1
                Write(MonthName(dr("MONTH")), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(dr("GRANDTOTAL"), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(dr("NETTAMT"), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Dim R As Integer = 4
                For I As Integer = 3 To DTMONTH.Columns.Count - 5
                    Write(dr(I), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                    R = R + 1
                Next

                'Write(dr("FREIGHT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                'objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                'R = R + 1

                'Write(dr("OCTROIAMT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                'objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                'R = R + 1

                'Write(dr("INSAMT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                'objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                'R = R + 1

                'Write(dr("ROUNDOFF"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                'objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"

            Next

            For I As Integer = 1 To DTMONTH.Columns.Count
                SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & RowIndex - DTMONTH.Rows.Count, objColumn.Item(I.ToString).ToString & RowIndex + 1)
            Next


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("1"))


            Dim M As Integer = 2
            For I As Integer = 1 To DTMONTH.Columns.Count - 1
                FORMULA("=SUM(" & objColumn.Item(M.ToString).ToString & RowIndex - DTMONTH.Rows.Count & ":" & objColumn.Item(M.ToString).ToString & RowIndex - 1 & ")", Range(M.ToString), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                M = M + 1
            Next

            'Write(DTMONTH.Compute("sum(FREIGHT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(OCTROIAMT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(INSAMT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(ROUNDOFF)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))


            'RowIndex += 1
            'Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            'Write(DT.Rows(0).Item("STATUS"), Range("13"), XlHAlign.xlHAlignLeft, Range("25"), True, 10)
            'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

            objSheet.Range(objColumn.Item("2").ToString & 1, objColumn.Item("2").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("3").ToString & 1, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & RowIndex + 2)


            '''''''''''Report Title
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = objCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 14)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            RowIndex += 1
            Write("SALES-TAX SUMMARY REPORT", Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 12)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True


            objBook.Application.ActiveWindow.Zoom = 95

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 144
                .LeftMargin = 50.4
                .RightMargin = 0
                .BottomMargin = 0
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "PURCHASE TAX SUMMARY REPORT"

    Public Function PURCHASE_TAX_SUMMARY_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            Dim DTMONTH As New System.Data.DataTable
            DTMONTH.Columns.Add("MONTH")

            DTMONTH.Rows.Add(4)
            DTMONTH.Rows.Add(5)
            DTMONTH.Rows.Add(6)
            DTMONTH.Rows.Add(7)
            DTMONTH.Rows.Add(8)
            DTMONTH.Rows.Add(9)
            DTMONTH.Rows.Add(10)
            DTMONTH.Rows.Add(11)
            DTMONTH.Rows.Add(12)
            DTMONTH.Rows.Add(1)
            DTMONTH.Rows.Add(2)
            DTMONTH.Rows.Add(3)

            DTMONTH.Columns.Add("GRANDTOTAL")
            DTMONTH.Columns.Add("NETTAMT")


            Dim objCMN As New ClsCommon
            Dim DTVAL As System.Data.DataTable
            For Each DR As DataRow In DTMONTH.Rows
                DTVAL = objCMN.search(" ISNULL(SUM(PURCHASEMASTER.BILL_GRANDTOTAL),0) AS GRANDTOTAL, ISNULL(SUM(PURCHASEMASTER.BILL_NETT),0) AS NETTAMT", "", " PURCHASEMASTER", " AND MONTH(BILL_DATE) = " & Val(DR("MONTH")) & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                If DTVAL.Rows.Count > 0 Then
                    DR("GRANDTOTAL") = Convert.ToDouble(DTVAL.Rows(0).Item("GRANDTOTAL"))
                    DR("NETTAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("NETTAMT"))
                Else
                    DR("GRANDTOTAL") = 0.0
                    DR("NETTAMT") = 0.0
                End If
            Next


            'FOR EXCISE AMT
            Dim DTEXCISE As System.Data.DataTable = objCMN.search("DISTINCT EXCISE_ID AS EXCISEID, EXCISE_NAME AS EXCISENAME, EXCISE_EDU AS EDU, EXCISE_HSE AS HSE", "", " EXCISEMASTER RIGHT OUTER JOIN PURCHASEMASTER ON EXCISEMASTER.EXCISE_yearid = PURCHASEMASTER.BILL_YEARID AND EXCISEMASTER.EXCISE_locationid = PURCHASEMASTER.BILL_LOCATIONID AND EXCISEMASTER.EXCISE_cmpid = PURCHASEMASTER.BILL_CMPID AND EXCISEMASTER.EXCISE_id = PURCHASEMASTER.BILL_EXCISEID ", " AND EXCISE_CMPID = " & CMPID & " AND EXCISE_LOCATIONID = " & LOCATIONID & " AND EXCISE_YEARID = " & YEARID)
            If DTEXCISE.Rows.Count > 0 Then
                For Each DREXCISE As DataRow In DTEXCISE.Rows
                    DTMONTH.Columns.Add("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Purchase")
                    DTMONTH.Columns.Add("Edu Cess @" & DREXCISE("EDU") & "%- Purchase")
                    DTMONTH.Columns.Add("S & H @" & DREXCISE("HSE") & "%- Purchase")
                    For Each DR As DataRow In DTMONTH.Rows
                        DTVAL = objCMN.search(" ISNULL(SUM(PURCHASEMASTER.BILL_EXCISEAMT),0) AS EXCISEAMT, ISNULL(SUM(PURCHASEMASTER.BILL_EDUCESSAMT),0) AS EDUCESSAMT, ISNULL(SUM(PURCHASEMASTER.BILL_HSECESSAMT),0) AS HSECESSAMT", "", " PURCHASEMASTER", " AND BILL_EXCISEID = " & DTEXCISE.Rows(0).Item("EXCISEID") & " AND MONTH(BILL_DATE) = " & Val(DR("MONTH")) & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                        If DTVAL.Rows.Count > 0 Then
                            DR("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Purchase") = Convert.ToDouble(DTVAL.Rows(0).Item("EXCISEAMT"))
                            DR("Edu Cess @" & DREXCISE("EDU") & "%- Purchase") = Convert.ToDouble(DTVAL.Rows(0).Item("EDUCESSAMT"))
                            DR("S & H @" & DREXCISE("HSE") & "%- Purchase") = Convert.ToDouble(DTVAL.Rows(0).Item("HSECESSAMT"))
                        Else
                            DR("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Purchase") = 0.0
                            DR("Edu Cess @" & DREXCISE("EDU") & "%- Purchase") = 0.0
                            DR("S & H @" & DREXCISE("HSE") & "%- Purchase") = 0.0
                        End If
                    Next
                Next
            End If



            'FOR TAXAMT
            Dim DTTAX As System.Data.DataTable = objCMN.search("DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER RIGHT OUTER JOIN PURCHASEMASTER ON TAXMASTER.TAX_yearid = PURCHASEMASTER.BILL_YEARID AND TAXMASTER.TAX_locationid = PURCHASEMASTER.BILL_LOCATIONID AND TAXMASTER.TAX_cmpid = PURCHASEMASTER.BILL_CMPID AND TAXMASTER.TAX_id = PURCHASEMASTER.BILL_TAXID ", " AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
            If DTTAX.Rows.Count > 0 Then
                For Each DRTAX As DataRow In DTTAX.Rows
                    DTMONTH.Columns.Add("SUBTOTAL " & DRTAX("TAXNAME"))
                    DTMONTH.Columns.Add(DRTAX("TAXNAME"))
                    For Each DR As DataRow In DTMONTH.Rows
                        DTVAL = objCMN.search(" ISNULL(SUM(PURCHASEMASTER.BILL_SUBTOTAL),0) AS SUBTOTAL, ISNULL(SUM(PURCHASEMASTER.BILL_TAXAMT),0) AS TAXAMT ", "", " PURCHASEMASTER", " AND BILL_TAXID = " & DTTAX.Rows(0).Item("TAXID") & " AND MONTH(BILL_DATE) = " & Val(DR("MONTH")) & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                        If DTVAL.Rows.Count > 0 Then
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("SUBTOTAL"))
                            DR(DRTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("TAXAMT"))
                        Else
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = 0.0
                            DR(DRTAX("TAXNAME")) = 0.0
                        End If
                    Next
                Next
            End If


            'FOR ADDTAXAMT
            Dim DTADDTAX As System.Data.DataTable = objCMN.search("DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER RIGHT OUTER JOIN PURCHASEMASTER ON TAXMASTER.TAX_yearid = PURCHASEMASTER.BILL_YEARID AND TAXMASTER.TAX_locationid = PURCHASEMASTER.BILL_LOCATIONID AND TAXMASTER.TAX_cmpid = PURCHASEMASTER.BILL_CMPID AND TAXMASTER.TAX_id = PURCHASEMASTER.BILL_ADDTAXID ", " AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
            If DTADDTAX.Rows.Count > 0 Then
                For Each DRADDTAX As DataRow In DTADDTAX.Rows
                    DTMONTH.Columns.Add(DRADDTAX("TAXNAME"))
                    For Each DR As DataRow In DTMONTH.Rows
                        DTVAL = objCMN.search("ISNULL(SUM(PURCHASEMASTER.BILL_ADDTAXAMT),0) AS ADDTAXAMT", "", " PURCHASEMASTER", " AND BILL_ADDTAXID = " & DRADDTAX("TAXID") & " AND MONTH(BILL_DATE)= " & DR("MONTH") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                        If DTVAL.Rows.Count > 0 Then
                            DR(DRADDTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("ADDTAXAMT"))
                        Else
                            DR(DRADDTAX("TAXNAME")) = 0.0
                        End If
                    Next
                Next
            End If


            DTMONTH.Columns.Add("FREIGHT")
            DTMONTH.Columns.Add("OCTROIAMT")
            DTMONTH.Columns.Add("INSAMT")
            DTMONTH.Columns.Add("ROUNDOFF")
            For Each DR As DataRow In DTMONTH.Rows
                DTVAL = objCMN.search(" ISNULL(SUM(PURCHASEMASTER.BILL_FREIGHT),0) AS FREIGHT, ISNULL(SUM(PURCHASEMASTER.BILL_OCTROIAMT),0) AS OCTROIAMT, ISNULL(SUM(PURCHASEMASTER.BILL_INSAMT),0) AS INSAMT, ISNULL(SUM(PURCHASEMASTER.BILL_ROUNDOFF),0) AS ROUNDOFF", "", " PURCHASEMASTER", " AND MONTH(BILL_DATE) = " & Val(DR("MONTH")) & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                If DTVAL.Rows.Count > 0 Then
                    DR("FREIGHT") = Convert.ToDouble(DTVAL.Rows(0).Item("FREIGHT"))
                    DR("OCTROIAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("OCTROIAMT"))
                    DR("INSAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("INSAMT"))
                    DR("ROUNDOFF") = Convert.ToDouble(DTVAL.Rows(0).Item("ROUNDOFF"))
                Else
                    DR("FREIGHT") = 0.0
                    DR("OCTROIAMT") = 0.0
                    DR("INSAMT") = 0.0
                    DR("ROUNDOFF") = 0.0
                End If
            Next



            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 11)
            Next

            SetColumnWidth("A1", 11)



            'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
            'COZ HERE WE DONT KNOW NO OF COLUMS
            RowIndex += 6
            Write("Month", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("G. Total", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Nett Total", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Dim T As Integer = 4
            For S As Integer = 3 To DTMONTH.Columns.Count - 5
                Write(DTMONTH.Columns(S).ColumnName, Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
                T = T + 1
            Next
            Write("Freight", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            T = T + 1
            Write("Octroi", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            T = T + 1
            Write("Inspection Charges", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            T = T + 1
            Write("Round Off", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((DTMONTH.Columns.Count).ToString).ToString & RowIndex)


            For Each dr As DataRow In DTMONTH.Rows
                RowIndex += 1
                Write(MonthName(dr("MONTH")), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(dr("GRANDTOTAL"), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(dr("NETTAMT"), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Dim R As Integer = 4
                For I As Integer = 3 To DTMONTH.Columns.Count - 5
                    Write(dr(I), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                    R = R + 1
                Next

                Write(dr("FREIGHT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                R = R + 1

                Write(dr("OCTROIAMT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                R = R + 1

                Write(dr("INSAMT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                R = R + 1

                Write(dr("ROUNDOFF"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"

            Next

            For I As Integer = 1 To DTMONTH.Columns.Count
                SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & RowIndex - DTMONTH.Rows.Count, objColumn.Item(I.ToString).ToString & RowIndex + 1)
            Next


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("1"))


            Dim M As Integer = 2
            For I As Integer = 1 To DTMONTH.Columns.Count - 1
                FORMULA("=SUM(" & objColumn.Item(M.ToString).ToString & RowIndex - DTMONTH.Rows.Count & ":" & objColumn.Item(M.ToString).ToString & RowIndex - 1 & ")", Range(M.ToString), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                M = M + 1
            Next

            'Write(DTMONTH.Compute("sum(FREIGHT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(OCTROIAMT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(INSAMT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(ROUNDOFF)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))


            'RowIndex += 1
            'Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            'Write(DT.Rows(0).Item("STATUS"), Range("13"), XlHAlign.xlHAlignLeft, Range("25"), True, 10)
            'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

            objSheet.Range(objColumn.Item("2").ToString & 1, objColumn.Item("2").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("3").ToString & 1, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & RowIndex + 2)


            '''''''''''Report Title
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = objCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 14)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            RowIndex += 1
            Write("PURCHASE-TAX SUMMARY REPORT", Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 12)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True


            objBook.Application.ActiveWindow.Zoom = 95

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 144
                .LeftMargin = 50.4
                .RightMargin = 0
                .BottomMargin = 0
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "GROUP WISE TRANS DETAILS REPORT"

    Public Function GROUP_TRANS_DETAILS_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 11)
            Next

            SetColumnWidth("B1", 40)


            'CMPHEADER
            CMPHEADER(CMPID, "GROUP-WISE TRANSACTION REPORT")



            'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
            RowIndex += 1
            Write("Date", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Name", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Type", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Bll No", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Debit", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Credit", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)


            Dim ALCOL(1) As String
            ALCOL(0) = ("ACC_INITIALS")
            ALCOL(1) = ("ACC_BILLNO")

            Dim OBJGROUP As New ClsCommon
            Dim DTALL As System.Data.DataTable = OBJGROUP.search("ACC_BILLDATE AS [DATE], NAME, ACC_TYPE AS [TYPE], ACC_BILLNO, ACC_INITIALS , DR,CR, PRIMARYGROUP ", "", " REGISTER ", CONDITION & " AND ACC_CMPID = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID & " ORDER BY ACC_BILLDATE")
            Dim DTMAIN As System.Data.DataTable = DTALL.DefaultView.ToTable(True, ALCOL)
            Dim DR() As System.Data.DataRow = DTMAIN.Select("ACC_INITIALS <> '0'", "ACC_BILLNO ASC")
            Dim DR1() As System.Data.DataRow
            For I As Integer = 0 To DR.GetUpperBound(0)

                DR1 = DTALL.Select("ACC_INITIALS = '" & DR(I)("ACC_INITIALS") & "'")

                Dim DTINITIALPARTY As System.Data.DataTable = OBJGROUP.search(" TOP(1) NAME", "", " REGISTER", " and acc_cmpid = " & CMPID & " and YEARID = " & YEARID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND name NOT IN (SELECT name FROM REGISTER WHERE REGISTER.acc_cmpid = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND REGISTER.YEARID = " & YEARID & CONDITION & ")  and acc_INITIALS = '" & DR(I)("ACC_INITIALS") & "'")
                If DTINITIALPARTY.Rows.Count > 0 Then
                    RowIndex += 2
                    Write(Format(Convert.ToDateTime(DR1(0)("DATE")).Date, "dd/MM/yyyy"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTINITIALPARTY.Rows(0).Item("NAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DR1(0)("TYPE"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DR1(0)("ACC_INITIALS"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTALL.Compute("SUM(CR)", "ACC_INITIALS = '" & DR(I)("ACC_INITIALS") & "'"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(DTALL.Compute("SUM(DR)", "ACC_INITIALS = '" & DR(I)("ACC_INITIALS") & "'"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)

                    For A As Integer = 0 To DR1.GetUpperBound(0)

                        RowIndex += 1
                        Write(Format(Convert.ToDateTime(DR1(A)("DATE")).Date, "dd/MM/yyyy"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("     " & DR1(A)("NAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10, , True)
                        Write(DR1(A)("TYPE"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DR1(A)("ACC_INITIALS"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DR1(A)("DR"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(DR1(A)("cr"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    Next
                End If

            Next



            For I As Integer = 1 To 6
                SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & 7, objColumn.Item(I.ToString).ToString & RowIndex + 1)
            Next


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("4"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("4"))

            FORMULA("=SUM(" & objColumn.Item("5").ToString & 7 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, Range("5"))

            FORMULA("=SUM(" & objColumn.Item("6").ToString & 7 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, Range("6"))


            objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 1, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("6").ToString & RowIndex + 1)


            objBook.Application.ActiveWindow.Zoom = 95

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 144
                .LeftMargin = 50.4
                .RightMargin = 0
                .BottomMargin = 0
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "TRIALBALANCE"

    Public Function TRIALBALANCE_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("9"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))

            RowIndex += 1
            Write("TRIAL-BALANCE", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("9"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("9").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("9").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("9").ToString & RowIndex + 1)

            RowIndex += 2
            Write("Name", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
            Write("O/P Dr", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("O/P Cr", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Debit", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Credit", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Closing Dr", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Closing Cr", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)


            Dim DT As System.Data.DataTable = OBJCMN.search("*", "", " TEMPTRIALBALANCEPRINT", " ORDER BY ROWNO")

            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("NAME"), Range("1"), XlHAlign.xlHAlignLeft, Range("3"), False, 10)
                If DTROW("OPENINGDR") > 0 Then
                    Write(Format(Val(DTROW("OPENINGDR")), "0.00"), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                End If
                If DTROW("OPENINGCR") > 0 Then
                    Write(Format(Val(DTROW("OPENINGCR")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                End If
                Write(Format(Val(DTROW("DEBIT")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)

                If DTROW("CLOSINGDR") > 0 Then
                    Write(Format(Val(DTROW("CLOSINGDR")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                End If
                If DTROW("CLOSINGCR") > 0 Then
                    Write(Format(Val(DTROW("CLOSINGCR")), "0.00"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                End If
                If Left(DTROW("NAME"), 1) = " " And Left(DTROW("NAME"), 6) <> "      " Then
                    objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green)
                ElseIf Left(DTROW("NAME"), 1) <> " " Then
                    objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Maroon)
                End If

            Next

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)

            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 95

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 10
                .RightMargin = 5
                .BottomMargin = 10
                .Zoom = False
                .FitToPagesTall = 1
                .FitToPagesWide = 1
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "PURCHASE SUMMARY (REGISTER WISE)"

    Public Function REGISTERPURCHASESUMM_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTREG As New System.Data.DataTable

            RowIndex += 6
            'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
            'COZ HERE WE DONT KNOW NO OF COLUMS
            Write("Month", Range("1"), XlHAlign.xlHAlignCenter, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("1"))

            Dim R As Integer = 2

            DTREG = OBJCMN.search("REGISTER_NAME AS REGNAME", "", "REGISTERMASTER", " AND REGISTER_TYPE = 'PURCHASE' AND REGISTER_CMPID = " & CMPID & " AND REGISTER_LOCATIONID = " & LOCATIONID & " AND REGISTER_YEARID = " & YEARID)
            If DTREG.Rows.Count > 0 Then
                R = 2
                For Each DTREGROW As System.Data.DataRow In DTREG.Rows
                    Write(DTREGROW("REGNAME"), Range(R.ToString), XlHAlign.xlHAlignCenter, , False, 10)
                    SetBorder(RowIndex, objColumn.Item(R.ToString).ToString & RowIndex, Range(R.ToString))
                    R += 1
                Next
            End If
            Write("TOTAL PURCHASE", Range((DTREG.Rows.Count + 2).ToString), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, objColumn.Item((DTREG.Rows.Count + 2).ToString).ToString & RowIndex, Range((DTREG.Rows.Count + 2).ToString))


            Dim J As Integer = 0
            For I = 4 To 15

                'FOR GETTING MONTH
                J = I
                If J > 12 Then
                    J -= 12
                End If


                RowIndex += 1
                Write(MonthName(J), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)

                DT = OBJCMN.search(" SUM(REPORT_SP_ACCOUNTS_PURCHASESUMMARY.CREDIT) AS AMOUNT, [REGISTER NAME] AS REGNAME ", "", " REPORT_SP_ACCOUNTS_PURCHASESUMMARY ", CONDITION & " AND MONTH(DATE) = " & J & " AND CMPID = " & CMPID & " AND LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID & "  GROUP BY [REGISTER NAME]")
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        For P As Integer = 2 To DTREG.Rows.Count + 1
                            If objSheet.Range(objColumn.Item(P.ToString).ToString & 7).Text = DTROW("REGNAME") Then
                                Write(DTROW("AMOUNT"), Range(P.ToString), XlHAlign.xlHAlignRight, , False, 10)
                            End If
                        Next
                    Next
                End If

            Next

            RowIndex += 1
            Write("TOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((DTREG.Rows.Count + 2).ToString).ToString & RowIndex)

            For P = 8 To RowIndex - 1
                FORMULA("=SUM(" & objColumn.Item("2").ToString & P & ":" & objColumn.Item(((DTREG.Rows.Count) + 1).ToString).ToString & P & ")", objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & P, XlHAlign.xlHAlignRight, , True, 10)
            Next

            For P = 1 To DTREG.Rows.Count + 2
                If P > 1 Then FORMULA("=SUM(" & objColumn.Item(P.ToString).ToString & RowIndex - 1 & ":" & objColumn.Item(P.ToString).ToString & 8 & ")", Range(P.ToString), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item(P.ToString).ToString & 7, objColumn.Item(P.ToString).ToString & RowIndex)
            Next


            '''''''''''Report Title
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 14)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))

            RowIndex += 1
            Write("PURCHASE SUMMARY", Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 12)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True

            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & RowIndex + 1)

            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 10
                .LeftMargin = 5
                .RightMargin = 5
                .BottomMargin = 10
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "SALE SUMMARY (REGISTER WISE)"

    Public Function REGISTERSALESUMM_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTREG As New System.Data.DataTable

            RowIndex += 6
            'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
            'COZ HERE WE DONT KNOW NO OF COLUMS
            Write("Month", Range("1"), XlHAlign.xlHAlignCenter, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("1"))

            Dim R As Integer = 2

            DTREG = OBJCMN.search("REGISTER_NAME AS REGNAME", "", "REGISTERMASTER", " AND REGISTER_TYPE = 'SALE' AND REGISTER_CMPID = " & CMPID & " AND REGISTER_LOCATIONID = " & LOCATIONID & " AND REGISTER_YEARID = " & YEARID)
            If DTREG.Rows.Count > 0 Then
                R = 2
                For Each DTREGROW As System.Data.DataRow In DTREG.Rows
                    Write(DTREGROW("REGNAME"), Range(R.ToString), XlHAlign.xlHAlignCenter, , False, 10)
                    SetBorder(RowIndex, objColumn.Item(R.ToString).ToString & RowIndex, Range(R.ToString))
                    R += 1
                Next
            End If
            Write("TOTAL SALES", Range((DTREG.Rows.Count + 2).ToString), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, objColumn.Item((DTREG.Rows.Count + 2).ToString).ToString & RowIndex, Range((DTREG.Rows.Count + 2).ToString))


            Dim J As Integer = 0
            For I = 4 To 15

                'FOR GETTING MONTH
                J = I
                If J > 12 Then
                    J -= 12
                End If


                RowIndex += 1
                Write(MonthName(J), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)

                DT = OBJCMN.search(" SUM(REPORT_SP_ACCOUNTS_INVOICESUMMARY.CREDIT) AS AMOUNT, [REGISTER NAME] AS REGNAME ", "", " REPORT_SP_ACCOUNTS_INVOICESUMMARY ", CONDITION & " AND MONTH(DATE) = " & J & " AND CMPID = " & CMPID & " AND LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID & "  GROUP BY [REGISTER NAME]")
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        For P As Integer = 2 To DTREG.Rows.Count + 1
                            If objSheet.Range(objColumn.Item(P.ToString).ToString & 7).Text = DTROW("REGNAME") Then
                                Write(DTROW("AMOUNT"), Range(P.ToString), XlHAlign.xlHAlignRight, , False, 10)
                            End If
                        Next
                    Next
                End If

            Next

            RowIndex += 1
            Write("TOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((DTREG.Rows.Count + 2).ToString).ToString & RowIndex)

            For P = 8 To RowIndex - 1
                FORMULA("=SUM(" & objColumn.Item("2").ToString & P & ":" & objColumn.Item(((DTREG.Rows.Count) + 1).ToString).ToString & P & ")", objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & P, XlHAlign.xlHAlignRight, , True, 10)
            Next

            For P = 1 To DTREG.Rows.Count + 2
                If P > 1 Then FORMULA("=SUM(" & objColumn.Item(P.ToString).ToString & RowIndex - 1 & ":" & objColumn.Item(P.ToString).ToString & 8 & ")", Range(P.ToString), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item(P.ToString).ToString & 7, objColumn.Item(P.ToString).ToString & RowIndex)
            Next

            '''''''''''Report Title
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 14)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))

            RowIndex += 1
            Write("SALE SUMMARY", Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 12)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True

            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & RowIndex + 1)

            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 10
                .LeftMargin = 5
                .RightMargin = 5
                .BottomMargin = 10
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "CST REPORTS"

    Public Function CSTSALE_EXCEL(ByVal WHERECLAUSE As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            SetColumnWidth(Range(4), 40)
            SetColumnWidth(Range(5), 30)



            RowIndex = 1
            Write("SALES DETAILS", Range("1"), XlHAlign.xlHAlignLeft, Range("10"), True, 10)
            objSheet.Range(Range("1"), Range("10")).Interior.Color = RGB(191, 191, 191)
            SetBorder(RowIndex, Range("1"), Range("10"))

            RowIndex += 1
            Write("Invoice No.", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            Write("Invoice Date", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Purchaser Tin No.", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Purchaser Name", Range("4"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("State", Range("5"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Goods with HSN", Range("6"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Value of Goods", Range("7"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Tax", Range("8"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Total", Range("9"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Form Type", Range("10"), XlHAlign.xlHAlignLeft, , True, 10)
            objSheet.Range(Range("1"), Range("10")).Interior.Color = RGB(191, 191, 191)
            SetBorder(RowIndex, Range("1"), Range("10"))


            Dim OBJCMN As New ClsCommon
            Dim DT As System.Data.DataTable = OBJCMN.search("*", "", " REPORT_SP_ACCOUNTS_INVOICESUMMARY ", WHERECLAUSE & " AND CMPID = " & CMPID & " AND LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID)
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("BILL NO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Convert.ToDateTime(DTROW("DATE")).Date, "dd/MM/yyyy"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("PARTYCSTNO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("PARTYSTATENAME"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("COTTON BALES", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Val(DTROW("SUBTOTAL")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("TOTALTAX")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("FORMTYPE"), Range("10"), XlHAlign.xlHAlignLeft, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("10"))
            Next

            objSheet.Range(Range("7")).NumberFormat = "0.00"
            objSheet.Range(Range("8")).NumberFormat = "0.00"
            objSheet.Range(Range("9")).NumberFormat = "0.00"

            objSheet.Range(objColumn.Item("1").ToString & 3, objColumn.Item("1").ToString & RowIndex).Interior.Color = RGB(255, 153, 204)
            objSheet.Range(objColumn.Item("2").ToString & 3, objColumn.Item("2").ToString & RowIndex).Interior.Color = RGB(255, 204, 153)
            objSheet.Range(objColumn.Item("3").ToString & 3, objColumn.Item("3").ToString & RowIndex).Interior.Color = RGB(255, 153, 204)
            objSheet.Range(objColumn.Item("4").ToString & 3, objColumn.Item("4").ToString & RowIndex).Interior.Color = RGB(153, 204, 255)
            objSheet.Range(objColumn.Item("5").ToString & 3, objColumn.Item("5").ToString & RowIndex).Interior.Color = RGB(51, 204, 204)
            objSheet.Range(objColumn.Item("6").ToString & 3, objColumn.Item("9").ToString & RowIndex).Interior.Color = RGB(204, 255, 255)
            objSheet.Range(objColumn.Item("10").ToString & 3, objColumn.Item("10").ToString & RowIndex).Interior.Color = RGB(51, 204, 204)


            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 2, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 2, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 2, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 2, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 2, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 2, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 2, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 2, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 2, objColumn.Item("10").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100



            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 10
                .LeftMargin = 10
                .RightMargin = 10
                .BottomMargin = 10
                .CenterHorizontally = True
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function CSTPURCHASE_EXCEL(ByVal WHERECLAUSE As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            SetColumnWidth(Range(4), 40)
            SetColumnWidth(Range(5), 30)


            RowIndex = 1
            Write("PURCHASE DETAILS", Range("1"), XlHAlign.xlHAlignLeft, Range("10"), True, 10)
            objSheet.Range(Range("1"), Range("10")).Interior.Color = RGB(191, 191, 191)
            SetBorder(RowIndex, Range("1"), Range("10"))

            RowIndex += 1
            Write("Invoice No.", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            Write("Invoice Date", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Seller Tin No.", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Seller Name", Range("4"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("State", Range("5"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Goods with HSN", Range("6"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Value of Goods", Range("7"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Tax", Range("8"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Total", Range("9"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Form Type", Range("10"), XlHAlign.xlHAlignLeft, , True, 10)
            SetBorder(RowIndex, Range("1"), Range("10"))
            objSheet.Range(Range("1"), Range("10")).Interior.Color = RGB(191, 191, 191)


            Dim OBJCMN As New ClsCommon
            Dim DT As System.Data.DataTable = OBJCMN.search("*", "", " REPORT_SP_ACCOUNTS_PURCHASESUMMARY ", WHERECLAUSE & " AND CMPID = " & CMPID & " AND LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID)
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("PARTYBILLNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Convert.ToDateTime(DTROW("PARTYBILLDATE")).Date, "dd/MM/yyyy"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("PARTYCSTNO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("PARTYSTATENAME"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("COTTON BALES", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Val(DTROW("SUBTOTAL")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("TOTALTAX")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("FORMTYPE"), Range("10"), XlHAlign.xlHAlignLeft, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("10"))
            Next

            objSheet.Range(Range("7")).NumberFormat = "0.00"
            objSheet.Range(Range("8")).NumberFormat = "0.00"
            objSheet.Range(Range("9")).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 2, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 2, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 2, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 2, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 2, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 2, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 2, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 2, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 2, objColumn.Item("10").ToString & RowIndex)

            objSheet.Range(objColumn.Item("1").ToString & 3, objColumn.Item("1").ToString & RowIndex).Interior.Color = RGB(255, 153, 204)
            objSheet.Range(objColumn.Item("2").ToString & 3, objColumn.Item("2").ToString & RowIndex).Interior.Color = RGB(255, 204, 153)
            objSheet.Range(objColumn.Item("3").ToString & 3, objColumn.Item("3").ToString & RowIndex).Interior.Color = RGB(255, 153, 204)
            objSheet.Range(objColumn.Item("4").ToString & 3, objColumn.Item("4").ToString & RowIndex).Interior.Color = RGB(153, 204, 255)
            objSheet.Range(objColumn.Item("5").ToString & 3, objColumn.Item("5").ToString & RowIndex).Interior.Color = RGB(51, 204, 204)
            objSheet.Range(objColumn.Item("6").ToString & 3, objColumn.Item("9").ToString & RowIndex).Interior.Color = RGB(204, 255, 255)
            objSheet.Range(objColumn.Item("10").ToString & 3, objColumn.Item("10").ToString & RowIndex).Interior.Color = RGB(51, 204, 204)

            objBook.Application.ActiveWindow.Zoom = 100



            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 10
                .LeftMargin = 10
                .RightMargin = 10
                .BottomMargin = 10
                .CenterHorizontally = True
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function CFORMAPPLICATION(ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            objSheet.Name = "SOR"

            SetColumnWidth(Range(10), 20)
            SetColumnWidth(Range(11), 20)


            Dim OBJCMN As New ClsCommon
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" cmp_displayedname AS NAME, cmp_cstno AS CSTNO, cmp_email AS EMAILID, cmp_tel AS MOBILENO ", "", " CMPMASTER ", " AND CMP_ID = " & CMPID)
            Dim DT As System.Data.DataTable = OBJCMN.search(" LEDGERS.Acc_cmpname AS NAME, ISNULL(STATEMASTER.state_name, '') AS STATE, ISNULL(LEDGERS.Acc_tinno, '') AS CSTNO, COUNT(DISTINCT PURCHASEMASTER.BILL_INITIALS) AS NOOFTRANS, SUM(PURCHASEMASTER.BILL_GTOTAL) AS GRANDTOTAL, ISNULL(LEDGERS.Acc_email, '') AS EMAIL, ISNULL(LEDGERS.Acc_mobile, '') AS MOBILENO ", "", " PURCHASEMASTER INNER JOIN PURCHASEMASTER_FORMTYPE ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_FORMTYPE.BILL_NO AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_FORMTYPE.BILL_REGISTERID INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN FORMTYPE ON PURCHASEMASTER_FORMTYPE.BILL_FORMID = FORMTYPE.FORM_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", " AND PURCHASEMASTER.BILL_YEARID = " & YEARID & " AND FORM_NAME = 'C FORM' AND BILL_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' GROUP BY LEDGERS.Acc_cmpname, ISNULL(STATEMASTER.state_name, ''), ISNULL(LEDGERS.Acc_tinno, ''), ISNULL(LEDGERS.Acc_email, ''), ISNULL(LEDGERS.Acc_mobile, '') ORDER BY LEDGERS.ACC_CMPNAME")



            RowIndex = 1
            Write("Statement of Requirement of Statutory Forms", Range("1"), XlHAlign.xlHAlignCenter, Range("11"), True, 9)
            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("11"))
            RowIndex += 1

            Write("(To Be Filled in Capital Letters)", Range("1"), XlHAlign.xlHAlignCenter, Range("11"), True, 9)
            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("11"))
            RowIndex += 1


            Write("Name of the Form Issueing Dealer", Range("1"), XlHAlign.xlHAlignCenter, Range("2"), True, 9, True)
            objSheet.Range(Range("1"), Range("2")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("1"), Range("2")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("1"), Range("2"))

            Write(DTCMP.Rows(0).Item("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("7"), True, 9)
            SetBorder(RowIndex, Range("3"), Range("7"))

            Write("Email Id", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 9)
            objSheet.Range(Range("8"), Range("8")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("8"), Range("8")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("8"), Range("8"))

            Write(DTCMP.Rows(0).Item("EMAILID"), Range("9"), XlHAlign.xlHAlignLeft, Range("10"), False, 9)
            SetBorder(RowIndex, Range("9"), Range("10"))

            Write("Ver 1.4.0", Range("11"), XlHAlign.xlHAlignLeft, Range("11"), False, 9)
            objSheet.Range(Range("11"), Range("11")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("11"), Range("11")).Font.Color = RGB(0, 0, 255)
            SetBorder(RowIndex, Range("11"), Range("11"))
            RowIndex += 1


            Write("CST TIN", Range("1"), XlHAlign.xlHAlignCenter, Range("2"), True, 9, True)
            objSheet.Range(Range("1"), Range("2")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("1"), Range("2")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("1"), Range("2"))

            Write(DTCMP.Rows(0).Item("CSTNO"), Range("3"), XlHAlign.xlHAlignLeft, Range("5"), True, 9)
            SetBorder(RowIndex, Range("3"), Range("5"))

            Write("Location Of Main POB", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 9, True)
            objSheet.Range(Range("6"), Range("6")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("6"), Range("6")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("6"), Range("6"))


            Write("01-Mazgoan", Range("7"), XlHAlign.xlHAlignLeft, Range("8"), True, 9)
            SetBorder(RowIndex, Range("7"), Range("8"))

            Write("Period", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 9)
            objSheet.Range(Range("9"), Range("9")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("9"), Range("9")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex + 1)

            Write("From Date (DD/MM/YY)", Range("10"), XlHAlign.xlHAlignLeft, Range("10"), True, 9)
            objSheet.Range(Range("10"), Range("10")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("10"), Range("10")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("10"), Range("10"))


            Write("To Date (DD/MM/YY)", Range("11"), XlHAlign.xlHAlignLeft, Range("11"), True, 9)
            objSheet.Range(Range("11"), Range("11")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("11"), Range("11")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("11"), Range("11"))
            RowIndex += 1


            Write("Date Of Application (dd-mmm-yy)", Range("1"), XlHAlign.xlHAlignCenter, Range("2"), True, 9, True)
            objSheet.Range(Range("1"), Range("2")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("2"))

            Write("", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 9, True)
            SetBorder(RowIndex, Range("3"), Range("4"))

            objSheet.Range(Range("5"), Range("5")).Interior.Color = RGB(191, 191, 191)
            SetBorder(RowIndex, Range("5"), Range("5"))

            Write("Mobile No", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 9, True)
            objSheet.Range(Range("6"), Range("6")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("6"), Range("6")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("6"), Range("6"))

            Write(DTCMP.Rows(0).Item("MOBILENO"), Range("7"), XlHAlign.xlHAlignLeft, Range("8"), True, 9)
            SetBorder(RowIndex, Range("7"), Range("8"))

            objSheet.Range(Range("9"), Range("9")).Interior.Color = RGB(198, 239, 206)

            Write(FROMDATE.Date, Range("10"), XlHAlign.xlHAlignLeft, Range("10"), False, 9)
            SetBorder(RowIndex, Range("10"), Range("10"))

            Write(Format(TODATE.Date, "dd/MM/yy"), Range("11"), XlHAlign.xlHAlignLeft, Range("11"), False, 9)
            SetBorder(RowIndex, Range("11"), Range("11"))
            RowIndex += 1


            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(198, 239, 206)
            Write("Form Type", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 9, True)
            SetBorder(RowIndex, Range("1"), Range("1"))

            Write("Name of the Form Accepting Dealer", Range("2"), XlHAlign.xlHAlignCenter, Range("3"), True, 9, True)
            SetBorder(RowIndex, Range("2"), Range("3"))

            Write("State of the form Accepting Dealer", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 9, True)
            SetBorder(RowIndex, Range("4"), Range("4"))

            Write("CST TIN of the Form Accepting Dealer", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 9, True)
            SetBorder(RowIndex, Range("5"), Range("5"))

            Write("Period of Transaction", Range("6"), XlHAlign.xlHAlignCenter, Range("7"), True, 9, True)
            SetBorder(RowIndex, Range("6"), Range("7"))

            Write("Total No Of Transactions", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 9, True)
            SetBorder(RowIndex, Range("8"), Range("8"))

            Write("Total Value Of Transaction Including Tax", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 9, True)
            SetBorder(RowIndex, Range("9"), Range("9"))

            Write("Email Id of Accepting Dealer", Range("10"), XlHAlign.xlHAlignCenter, Range("10"), True, 9, True)
            SetBorder(RowIndex, Range("10"), Range("10"))

            Write("Mobile No Of Accepting Dealer", Range("11"), XlHAlign.xlHAlignCenter, Range("11"), True, 9, True)
            SetBorder(RowIndex, Range("11"), Range("11"))
            RowIndex += 1


            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(198, 239, 206)
            Write("1", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 9, True)
            SetBorder(RowIndex, Range("1"), Range("1"))

            Write("2", Range("2"), XlHAlign.xlHAlignCenter, Range("3"), True, 9, True)
            SetBorder(RowIndex, Range("2"), Range("3"))

            Write("3", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 9, True)
            SetBorder(RowIndex, Range("4"), Range("4"))

            Write("4", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 9, True)
            SetBorder(RowIndex, Range("5"), Range("5"))

            Write("5 (From)", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 9, True)
            SetBorder(RowIndex, Range("6"), Range("6"))

            Write("6 (To)", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 9, True)
            SetBorder(RowIndex, Range("7"), Range("7"))

            Write("7", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 9, True)
            SetBorder(RowIndex, Range("8"), Range("8"))

            Write("8", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 9, True)
            SetBorder(RowIndex, Range("9"), Range("9"))

            Write("9", Range("10"), XlHAlign.xlHAlignCenter, Range("10"), True, 9, True)
            SetBorder(RowIndex, Range("10"), Range("10"))

            Write("10", Range("11"), XlHAlign.xlHAlignCenter, Range("11"), True, 9, True)
            SetBorder(RowIndex, Range("11"), Range("11"))

            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write("C-FORM", Range("1"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("NAME"), Range("2"), XlHAlign.xlHAlignLeft, Range("3"), True, 9)
                Write(DTROW("STATE"), Range("4"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("CSTNO"), Range("5"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(FROMDATE.Date, Range("6"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(Format(TODATE.Date, "dd/MM/yy"), Range("7"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(Val(DTROW("NOOFTRANS")), Range("8"), XlHAlign.xlHAlignRight, , True, 9)
                Write(Val(DTROW("GRANDTOTAL")), Range("9"), XlHAlign.xlHAlignRight, , True, 9)
                Write(DTROW("EMAIL"), Range("10"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("MOBILENO"), Range("11"), XlHAlign.xlHAlignLeft, , True, 9)
                SetBorder(RowIndex, Range("1"), Range("11"))
            Next

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 10
                .LeftMargin = 10
                .RightMargin = 10
                .BottomMargin = 10
                .CenterHorizontally = True
            End With

            objBook.Application.ActiveWindow.Zoom = 100
            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function CFORMAPPLICATION1(ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 10)
            Next

            objSheet.Name = "C FORM DETAILS"

            SetColumnWidth(Range(1), 5)
            'SetColumnWidth(Range(11), 20)


            Dim OBJCMN As New ClsCommon
            Dim DT As System.Data.DataTable = OBJCMN.search(" LEDGERS.Acc_tinno AS TINNO, PURCHASEMASTER.BILL_PARTYBILLNO AS BILLNO, PURCHASEMASTER.BILL_PARTYBILLDATE AS BILLDATE, PURCHASEMASTER.BILL_TOTALAMT AS BILLAMT, PURCHASEMASTER.BILL_TAXAMT AS TAXES, PURCHASEMASTER.BILL_GTOTAL AS GRANDTOTAL, BILL_TOTALQTY AS TOTALQTY  ", "", " PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN PURCHASEMASTER_FORMTYPE ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_FORMTYPE.BILL_NO AND  PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_FORMTYPE.BILL_REGISTERID AND  PURCHASEMASTER.BILL_YEARID = PURCHASEMASTER_FORMTYPE.BILL_YEARID INNER JOIN FORMTYPE ON PURCHASEMASTER_FORMTYPE.BILL_FORMID = FORMTYPE.FORM_ID ", " AND PURCHASEMASTER.BILL_YEARID = " & YEARID & " AND PURCHASEMASTER.BILL_TAXID > 0 AND FORM_NAME = 'C FORM' AND BILL_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' ORDER BY LEDGERS.ACC_CMPNAME, PURCHASEMASTER.BILL_PARTYBILLDATE")



            RowIndex = 1
            objSheet.Range(Range("1"), Range("14")).Interior.Color = RGB(0, 255, 255)
            Write("C/F Form Invoice Wise Details", Range("1"), XlHAlign.xlHAlignCenter, Range("12"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("12"))

            Write("Ver 1.4.0", Range("13"), XlHAlign.xlHAlignLeft, Range("14"), False, 9)
            SetBorder(RowIndex, Range("13"), Range("14"))
            RowIndex += 1


            objSheet.Range(Range("1"), Range("14")).Interior.Color = RGB(0, 255, 255)
            Write("Linking Fields", Range("1"), XlHAlign.xlHAlignCenter, Range("5"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("5"))

            Write("Common Fields", Range("6"), XlHAlign.xlHAlignLeft, Range("14"), False, 9)
            SetBorder(RowIndex, Range("6"), Range("14"))
            RowIndex += 1


            objSheet.Range(Range("1"), Range("14")).Interior.Color = RGB(0, 255, 255)
            Write("Sno", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 9, True)
            SetBorder(RowIndex, Range("1"), Range("1"))

            Write("Form Type Requested", Range("2"), XlHAlign.xlHAlignCenter, Range("2"), True, 9, True)
            SetBorder(RowIndex, Range("2"), Range("2"))

            Write("CST TIN of Form Accepting Dealer", Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 9, True)
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write("Period Of TRansaction (DD-MM-YY)", Range("4"), XlHAlign.xlHAlignCenter, Range("5"), True, 9, True)
            SetBorder(RowIndex, Range("4"), Range("5"))

            Write("Invoice No", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 9, True)
            SetBorder(RowIndex, Range("6"), Range("6"))

            Write("Invoice Date (DD-MM-YY)", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 9, True)
            SetBorder(RowIndex, Range("7"), Range("7"))

            Write("Nett Value Of Invoice", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 9, True)
            SetBorder(RowIndex, Range("8"), Range("8"))

            Write("Tax Amount", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 9, True)
            SetBorder(RowIndex, Range("9"), Range("9"))

            Write("Gross Value Of Invoice", Range("10"), XlHAlign.xlHAlignCenter, Range("10"), True, 9, True)
            SetBorder(RowIndex, Range("10"), Range("10"))

            Write("Description Of Goods", Range("11"), XlHAlign.xlHAlignCenter, Range("11"), True, 9, True)
            SetBorder(RowIndex, Range("11"), Range("11"))

            Write("Quantity Of Goods", Range("12"), XlHAlign.xlHAlignCenter, Range("12"), True, 9, True)
            SetBorder(RowIndex, Range("12"), Range("12"))

            Write("Purpose of Purchase", Range("13"), XlHAlign.xlHAlignCenter, Range("13"), True, 9, True)
            SetBorder(RowIndex, Range("13"), Range("13"))

            Write("Remarks", Range("14"), XlHAlign.xlHAlignCenter, Range("14"), True, 9, True)
            SetBorder(RowIndex, Range("14"), Range("14"))
            RowIndex += 1

            objSheet.Range(Range("1"), Range("14")).Interior.Color = RGB(0, 255, 255)
            SetBorder(RowIndex, Range("1"), Range("1"))
            SetBorder(RowIndex, Range("2"), Range("2"))
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write("From", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 9, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("To", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 9, True)
            SetBorder(RowIndex, Range("5"), Range("5"))

            SetBorder(RowIndex, Range("6"), Range("6"))
            SetBorder(RowIndex, Range("7"), Range("7"))
            SetBorder(RowIndex, Range("8"), Range("8"))
            SetBorder(RowIndex, Range("9"), Range("9"))
            SetBorder(RowIndex, Range("10"), Range("10"))
            SetBorder(RowIndex, Range("11"), Range("11"))
            SetBorder(RowIndex, Range("12"), Range("12"))
            SetBorder(RowIndex, Range("13"), Range("13"))
            SetBorder(RowIndex, Range("14"), Range("14"))


            Dim a As Integer = 1
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(a, Range("1"), XlHAlign.xlHAlignRight, , True, 9)
                Write("C-FORM", Range("2"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("TINNO"), Range("3"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(FROMDATE.Date, Range("4"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(TODATE.Date, Range("5"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(Val(DTROW("BILLNO")), Range("6"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("BILLDATE"), Range("7"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(Val(DTROW("GRANDTOTAL")), Range("8"), XlHAlign.xlHAlignRight, , True, 9)
                Write(Val(DTROW("TAXES")), Range("9"), XlHAlign.xlHAlignRight, , True, 9)
                Write(Val(DTROW("BILLAMT")), Range("10"), XlHAlign.xlHAlignRight, , True, 9)
                Write("YARN", Range("11"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(Val(DTROW("TOTALQTY")), Range("12"), XlHAlign.xlHAlignRight, , True, 9)
                Write("Resale", Range("13"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("14"), XlHAlign.xlHAlignLeft, , True, 9)
                SetBorder(RowIndex, Range("1"), Range("14"))
                a += 1
            Next

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 10
                .LeftMargin = 10
                .RightMargin = 10
                .BottomMargin = 10
                .CenterHorizontally = True
            End With

            objBook.Application.ActiveWindow.Zoom = 100
            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "TAX REPORTS"

    Public Function TAXREPORT_EXCEL(ByVal WHERECLAUSE As String, ByVal PERIOD As String, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 12)
            Next

            SetColumnWidth(Range(1), 30)


            ' **************************** CMPHEADER *************************
            Dim OBJCMN As New ClsCommon
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("8"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("8"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("8"))




            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 9, objColumn.Item("8").ToString & 9).Select()
            objSheet.Range(objColumn.Item("1").ToString & 9, objColumn.Item("8").ToString & 9).Application.ActiveWindow.FreezePanes = True

            ' **************************** CMPHEADER *************************


            RowIndex += 1
            Write(PERIOD, Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("8"))

            RowIndex += 2
            Write("PURCHASE", Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            objSheet.Range(Range("1"), Range("8")).Interior.Color = RGB(213, 228, 248)
            SetBorder(RowIndex, Range("1"), Range("8"))

            RowIndex += 1
            Write("Type Of Purchase", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("Gross Amount", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("1"), Range("2"))
            Write("Other Charges", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("Tax %", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("V.A.T.", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("C.S.T.", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("6"), Range("6"))
            Write("Round Off", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("7"), Range("7"))
            Write("Nett Amount", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("8"), Range("8"))

            objSheet.Range(Range("1"), Range("8")).Interior.Color = RGB(213, 228, 248)

            Dim DT As System.Data.DataTable = OBJCMN.search(" A.REGNAME, SUM(A.GROSSAMT) AS GROSSAMT, sum(A.CHARGES) as CHARGES, A.TAX, SUM(A.VAT) AS VAT, SUM(A.CST) AS CST, SUM(A.ROUNDOFF) AS ROUNDOFF, SUM(A.NETTAMT) AS NETTAMT, A.CMPID, A.YEARID  ", "", " (SELECT T.DATE, T.BILLINITIALS, T.REGNAME, T.GROSSAMT, SUM(T.CHARGES) AS CHARGES, SUM(T.TAX) AS TAX, SUM(T.VAT) AS VAT, SUM(T.CST) AS CST, T.ROUNDOFF, T.NETTAMT, T.CMPID, T.YEARID FROM (SELECT    PURCHASEMASTER.BILL_PARTYBILLDATE AS [DATE], PURCHASEMASTER.BILL_INITIALS AS BILLINITIALS, REGISTERMASTER.register_name AS REGNAME, PURCHASEMASTER.BILL_TOTALAMT AS GROSSAMT, (ISNULL(SUM(PURCHASEMASTER.bill_transchg),0) + ISNULL(SUM(PURCHASEMASTER.bill_excise),0)) AS CHARGES, 0 AS TAX,0 AS VAT,0 AS CST, PURCHASEMASTER.BILL_ROUNDOFF AS ROUNDOFF, PURCHASEMASTER.BILL_GTOTAL AS NETTAMT, PURCHASEMASTER.BILL_CMPID AS CMPID, PURCHASEMASTER.BILL_YEARID AS YEARID FROM PURCHASEMASTER INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id WHERE (ISNULL(BILL_TAXID,0) = 0) GROUP BY PURCHASEMASTER.BILL_PARTYBILLDATE ,PURCHASEMASTER.BILL_INITIALS,REGISTERMASTER.register_name, PURCHASEMASTER.BILL_TOTALAMT, PURCHASEMASTER.BILL_ROUNDOFF, PURCHASEMASTER.BILL_GTOTAL, PURCHASEMASTER.BILL_CMPID , PURCHASEMASTER.BILL_YEARID UNION ALL  SELECT PURCHASEMASTER.BILL_PARTYBILLDATE, PURCHASEMASTER.BILL_INITIALS AS BILLINITIALS,REGISTERMASTER.register_name AS REGNAME, PURCHASEMASTER.BILL_TOTALAMT AS GROSSAMT, (ISNULL(SUM(PURCHASEMASTER.bill_transchg),0) + ISNULL(SUM(PURCHASEMASTER.bill_excise),0)) AS CHARGES, tax_tax AS TAX, SUM(PURCHASEMASTER.BILL_TAXAMT) AS VAT, 0 AS CST, PURCHASEMASTER.BILL_ROUNDOFF AS ROUNDOFF, PURCHASEMASTER.BILL_GTOTAL AS NETTAMT, PURCHASEMASTER.BILL_CMPID AS CMPID, PURCHASEMASTER.BILL_YEARID AS YEARID FROM PURCHASEMASTER INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id INNER JOIN TAXMASTER ON PURCHASEMASTER.BILL_TAXID = TAXMASTER.tax_id WHERE tax_ISVAT = 'TRUE' GROUP BY PURCHASEMASTER.BILL_PARTYBILLDATE, PURCHASEMASTER.BILL_INITIALS, REGISTERMASTER.register_name, PURCHASEMASTER.BILL_TOTALAMT, PURCHASEMASTER.BILL_ROUNDOFF, PURCHASEMASTER.BILL_GTOTAL, tax_tax , PURCHASEMASTER.BILL_CMPID , PURCHASEMASTER.BILL_YEARID UNION ALL SELECT PURCHASEMASTER.BILL_PARTYBILLDATE, PURCHASEMASTER.BILL_INITIALS AS BILLINITIALS, REGISTERMASTER.register_name AS REGNAME, PURCHASEMASTER.BILL_TOTALAMT AS GROSSAMT, (ISNULL(SUM(PURCHASEMASTER.bill_transchg),0) + ISNULL(SUM(PURCHASEMASTER.bill_excise),0)) AS CHARGES, tax_tax AS TAX, 0 AS VAT, SUM(PURCHASEMASTER.BILL_TAXAMT) AS CST, PURCHASEMASTER.BILL_ROUNDOFF AS ROUNDOFF,PURCHASEMASTER.BILL_GTOTAL AS NETTAMT, PURCHASEMASTER.BILL_CMPID AS CMPID, PURCHASEMASTER.BILL_YEARID AS YEARID FROM PURCHASEMASTER INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id INNER JOIN TAXMASTER ON PURCHASEMASTER.BILL_TAXID = TAXMASTER.tax_id WHERE tax_ISCST = 'TRUE' GROUP BY PURCHASEMASTER.BILL_PARTYBILLDATE, PURCHASEMASTER.BILL_INITIALS, REGISTERMASTER.register_name, PURCHASEMASTER.BILL_TOTALAMT, PURCHASEMASTER.BILL_ROUNDOFF, PURCHASEMASTER.BILL_GTOTAL, tax_tax , PURCHASEMASTER.BILL_CMPID , PURCHASEMASTER.BILL_YEARID ) AS T  " & WHERECLAUSE & " GROUP BY T.DATE, T.BILLINITIALS, T.REGNAME, T.CMPID, T.YEARID, T.GROSSAMT, T.ROUNDOFF, T.NETTAMT) AS A ", " GROUP BY A.REGNAME, A.TAX, A.CMPID,A.YEARID ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("REGNAME"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Val(DTROW("GROSSAMT")), "0.00"), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CHARGES")), "0.00"), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("TAX")), "0.00"), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("VAT")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CST")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("ROUNDOFF")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("NETTAMT")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))
            Next
            RowIndex += 1
            FORMULA("=SUM(" & objColumn.Item("2").ToString & 9 & ":" & objColumn.Item("2").ToString & RowIndex - 1 & ")", Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("3").ToString & 9 & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 9 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 9 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 9 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 9 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("1"), Range("8"))



            'SALE DETAILS
            RowIndex += 2
            Write("SALE", Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            Dim SSTART As Integer = RowIndex
            objSheet.Range(Range("1"), Range("8")).Interior.Color = RGB(213, 228, 248)
            SetBorder(RowIndex, Range("1"), Range("8"))
            DT = OBJCMN.search("A.REGNAME, SUM(A.GROSSAMT) AS GROSSAMT, sum(A.CHARGES) as CHARGES, A.TAX, SUM(A.VAT) AS VAT, SUM(A.CST) AS CST, SUM(A.ROUNDOFF) AS ROUNDOFF, SUM(A.NETTAMT) AS NETTAMT, A.CMPID, A.YEARID ", "", " (SELECT T.DATE, T.BILLINITIALS, T.REGNAME, T.GROSSAMT, SUM(T.CHARGES) AS CHARGES, SUM(T.TAX) AS TAX, SUM(T.VAT) AS VAT, SUM(T.CST) AS CST, T.ROUNDOFF, T.NETTAMT, T.CMPID, T.YEARID FROM (SELECT    INVOICEMASTER.INVOICE_DATE AS [DATE], INVOICEMASTER.INVOICE_INITIALS AS BILLINITIALS, REGISTERMASTER.register_name AS REGNAME, INVOICEMASTER.INVOICE_TOTALAMT AS GROSSAMT, (ISNULL(SUM(INVOICEMASTER.invoice_processing),0) + ISNULL(SUM(INVOICEMASTER.invoice_OTHERCHGS),0) + ISNULL(SUM(INVOICEMASTER.invoice_pakagingchgs),0)) AS CHARGES, 0 AS TAX,0 AS VAT,0 AS CST, INVOICEMASTER.INVOICE_ROUNDOFF AS ROUNDOFF, INVOICEMASTER.INVOICE_GRANDTOTAL AS NETTAMT, INVOICEMASTER.INVOICE_CMPID AS CMPID, INVOICEMASTER.INVOICE_YEARID AS YEARID FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.register_id WHERE (ISNULL(INVOICE_TAXID,0) = 0) GROUP BY INVOICEMASTER.INVOICE_DATE ,INVOICEMASTER.INVOICE_INITIALS,REGISTERMASTER.register_name, INVOICEMASTER.INVOICE_TOTALAMT, INVOICEMASTER.INVOICE_ROUNDOFF, INVOICEMASTER.INVOICE_GRANDTOTAL, INVOICEMASTER.INVOICE_CMPID , INVOICEMASTER.INVOICE_YEARID UNION ALL  SELECT INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_INITIALS AS BILLINITIALS,REGISTERMASTER.register_name AS REGNAME, INVOICEMASTER.INVOICE_TOTALAMT AS GROSSAMT, (ISNULL(SUM(INVOICEMASTER.invoice_processing),0) + ISNULL(SUM(INVOICEMASTER.invoice_OTHERCHGS),0) + ISNULL(SUM(INVOICEMASTER.invoice_pakagingchgs),0)) AS CHARGES, tax_tax AS TAX, SUM(INVOICEMASTER.INVOICE_TAXAMT) AS VAT, 0 AS CST, INVOICEMASTER.INVOICE_ROUNDOFF AS ROUNDOFF, INVOICEMASTER.INVOICE_GRANDTOTAL AS NETTAMT, INVOICEMASTER.INVOICE_CMPID AS CMPID, INVOICEMASTER.INVOICE_YEARID AS YEARID FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.register_id INNER JOIN TAXMASTER ON INVOICEMASTER.INVOICE_TAXID = TAXMASTER.tax_id WHERE tax_ISVAT = 'TRUE' GROUP BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_INITIALS, REGISTERMASTER.register_name, INVOICEMASTER.INVOICE_TOTALAMT, INVOICEMASTER.INVOICE_ROUNDOFF, INVOICEMASTER.INVOICE_GRANDTOTAL, tax_tax , INVOICEMASTER.INVOICE_CMPID , INVOICEMASTER.INVOICE_YEARID UNION ALL SELECT INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_INITIALS AS BILLINITIALS, REGISTERMASTER.register_name AS REGNAME, INVOICEMASTER.INVOICE_TOTALAMT AS GROSSAMT, (ISNULL(SUM(INVOICEMASTER.invoice_processing),0) + ISNULL(SUM(INVOICEMASTER.invoice_OTHERCHGS),0) + ISNULL(SUM(INVOICEMASTER.invoice_pakagingchgs),0)) AS CHARGES, tax_tax AS TAX, 0 AS VAT, SUM(INVOICEMASTER.INVOICE_TAXAMT) AS CST, INVOICEMASTER.INVOICE_ROUNDOFF AS ROUNDOFF,INVOICEMASTER.INVOICE_GRANDTOTAL AS NETTAMT, INVOICEMASTER.INVOICE_CMPID AS CMPID, INVOICEMASTER.INVOICE_YEARID AS YEARID FROM INVOICEMASTER INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.register_id INNER JOIN TAXMASTER ON INVOICEMASTER.INVOICE_TAXID = TAXMASTER.tax_id WHERE tax_ISCST = 'TRUE' GROUP BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_INITIALS, REGISTERMASTER.register_name, INVOICEMASTER.INVOICE_TOTALAMT, INVOICEMASTER.INVOICE_ROUNDOFF, INVOICEMASTER.INVOICE_GRANDTOTAL, tax_tax , INVOICEMASTER.INVOICE_CMPID , INVOICEMASTER.INVOICE_YEARID ) AS T " & WHERECLAUSE & " GROUP BY T.DATE, T.BILLINITIALS, T.REGNAME, T.CMPID, T.YEARID, T.GROSSAMT, T.ROUNDOFF, T.NETTAMT) AS A ", " GROUP BY A.REGNAME, A.TAX, A.CMPID,A.YEARID ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("REGNAME"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Val(DTROW("GROSSAMT")), "0.00"), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CHARGES")), "0.00"), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("TAX")), "0.00"), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("VAT")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CST")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("ROUNDOFF")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("NETTAMT")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))
            Next

            objSheet.Range(Range("4")).NumberFormat = "0.00"
            objSheet.Range(Range("5")).NumberFormat = "0.00"
            objSheet.Range(Range("6")).NumberFormat = "0.00"
            objSheet.Range(Range("7")).NumberFormat = "0.00"
            objSheet.Range(Range("8")).NumberFormat = "0.00"

            RowIndex += 1
            FORMULA("=SUM(" & objColumn.Item("2").ToString & SSTART & ":" & objColumn.Item("2").ToString & RowIndex - 1 & ")", Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("3").ToString & SSTART & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & SSTART & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & SSTART & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & SSTART & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & SSTART & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("1"), Range("8"))

            SetBorder(RowIndex, objColumn.Item("1").ToString & 9, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 9, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 9, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 9, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 9, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 9, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 9, objColumn.Item("8").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100



            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 10
                .LeftMargin = 10
                .RightMargin = 10
                .BottomMargin = 10
                .CenterHorizontally = True
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function J1REPORT_EXCEL(ByVal WHERECLAUSE As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 2 To 26
                SetColumnWidth(Range(i), 18)
            Next

            SetColumnWidth(Range("2"), 48)


            RowIndex += 1
            Write("Sales Annexure", Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("7"))

            RowIndex += 1
            Write("Period From", Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 12)
            objSheet.Range(Range("3"), Range("3")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("3"))
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write("Period To", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 12)
            objSheet.Range(Range("4"), Range("4")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("4"))
            SetBorder(RowIndex, Range("5"), Range("6"))


            RowIndex += 1
            Write("TIN", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("1"))
            SetBorder(RowIndex, Range("2"), Range("2"))

            Write(FROMDATE.Date, Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 12)
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write(TODATE.Date, Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 12)
            SetBorder(RowIndex, Range("4"), Range("4"))

            Write("Applicable", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 12)
            objSheet.Range(Range("5"), Range("5")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("5"), Range("5"))
            SetBorder(RowIndex, Range("6"), Range("7"))

            RowIndex += 1
            Write("CUSTOMER-WISE VAT SALES", Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("7"))


            RowIndex += 1
            Write("If you have more that 4999 entries then upload more than one sheet", Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 12)
            objSheet.Range(Range("1"), Range("7")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("1"), Range("7"))


            RowIndex += 1
            Write("Sr.No.", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("Name of Customer", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("TIN of Customer", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("Nett Taxable Amount Rs.", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("V.A.T. Amount Rs.", Range("5"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("Gross Total Rs.", Range("6"), XlHAlign.xlHAlignCenter, Range("7"), True, 12)
            SetBorder(RowIndex, Range("6"), Range("7"))


            RowIndex += 1
            Write("1", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("2", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("3", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("4", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("5", Range("5"), XlHAlign.xlHAlignCenter, , True, 12)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("5", Range("6"), XlHAlign.xlHAlignCenter, Range("7"), True, 12)
            SetBorder(RowIndex, Range("6"), Range("7"))


            Dim OBJCMN As New ClsCommon
            Dim SRNO As Integer = 1
            Dim DT As System.Data.DataTable = OBJCMN.search(" ledgers.acc_cmpname as NAME, LEDGERS.Acc_tinno AS TINNO, SUM(INVOICEMASTER.INVOICE_SUBTOTAL) AS TOTALAMT, SUM(INVOICEMASTER.INVOICE_TAXAMT) AS TAXAMT, SUM(INVOICEMASTER.INVOICE_GRANDTOTAL) AS GTOTAL", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id INNER JOIN TAXMASTER ON INVOICEMASTER.INVOICE_TAXID = TAXMASTER.tax_id ", WHERECLAUSE & " AND tax_ISVAT = 'TRUE' AND INVOICEMASTER.INVOICE_YEARID = " & YEARID & " GROUP BY LEDGERS.Acc_tinno, Acc_cmpname ORDER BY LEDGERS.Acc_cmpname ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , False, 12)
                Write(DTROW("NAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 12, True)
                Write(DTROW("TINNO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 12, True)
                Write(Format(Val(DTROW("TOTALAMT")), "0.00"), Range("4"), XlHAlign.xlHAlignRight, , False, 12)
                Write(Format(Val(DTROW("TAXAMT")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, , False, 12)
                Write(Format(Val(DTROW("GTOTAL")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, Range("7"), False, 12)
                objSheet.Range(Range("6"), Range("7")).Interior.Color = RGB(198, 239, 206)
                SetBorder(RowIndex, Range("1"), Range("7"))
                SRNO += 1
            Next
            RowIndex += 1
            Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , True, 12)
            Write("Gross Total", Range("3"), XlHAlign.xlHAlignLeft, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 9 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 9 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 9 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, Range("7"), True, 12)
            objSheet.Range(Range("4"), Range("7")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("7"))


            objSheet.Range(objColumn.Item("4").ToString & 9, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 9, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 9, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 9, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 9, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 9, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 9, objColumn.Item("6").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 10
                .LeftMargin = 10
                .RightMargin = 10
                .BottomMargin = 10
                .CenterHorizontally = True
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function J2REPORT_EXCEL(ByVal WHERECLAUSE As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 2 To 26
                SetColumnWidth(Range(i), 18)
            Next

            SetColumnWidth(Range("2"), 48)


            RowIndex += 1
            Write("Purchase Annexure", Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("7"))

            RowIndex += 1
            Write("Period From", Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 12)
            objSheet.Range(Range("3"), Range("3")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("3"))
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write("Period To", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 12)
            objSheet.Range(Range("4"), Range("4")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("4"))
            SetBorder(RowIndex, Range("5"), Range("7"))


            RowIndex += 1
            Write("TIN", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("1"))
            SetBorder(RowIndex, Range("2"), Range("2"))

            Write(FROMDATE.Date, Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 12)
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write(TODATE.Date, Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 12)
            SetBorder(RowIndex, Range("4"), Range("4"))

            Write("Applicable", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 12)
            objSheet.Range(Range("5"), Range("5")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("5"), Range("5"))
            SetBorder(RowIndex, Range("6"), Range("6"))
            SetBorder(RowIndex, Range("7"), Range("7"))

            RowIndex += 1
            Write("SUPPLIERS-WISE VAT SALES", Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("7"))


            RowIndex += 1
            Write("If you have more that 4999 entries then upload more than one sheet", Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 12)
            objSheet.Range(Range("1"), Range("7")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("1"), Range("7"))


            RowIndex += 1
            Write("Sr.No.", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("Name of Suppliers", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("TIN of Suppliers", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("Nett Taxable Amount Rs.", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("V.A.T. Amount Rs.", Range("5"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("Gross Total Rs.", Range("6"), XlHAlign.xlHAlignCenter, Range("7"), True, 12)
            SetBorder(RowIndex, Range("6"), Range("7"))


            RowIndex += 1
            Write("1", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("2", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("3", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("4", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("4", Range("5"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("5", Range("6"), XlHAlign.xlHAlignCenter, Range("7"), True, 12)
            SetBorder(RowIndex, Range("6"), Range("7"))


            Dim OBJCMN As New ClsCommon
            Dim SRNO As Integer = 1
            Dim DT As System.Data.DataTable = OBJCMN.search(" LEDGERS.Acc_CMPNAME AS NAME, LEDGERS.Acc_tinno AS TINNO, SUM(PURCHASEMASTER.BILL_SUBTOTAL) AS TOTALAMT, SUM(PURCHASEMASTER.BILL_TAXAMT) AS TAXAMT, SUM(PURCHASEMASTER.BILL_GTOTAL) AS GTOTAL ", "", " PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN TAXMASTER ON PURCHASEMASTER.BILL_TAXID = TAXMASTER.tax_id ", WHERECLAUSE & " AND tax_ISVAT = 'TRUE' AND PURCHASEMASTER.BILL_YEARID = " & YEARID & " GROUP BY LEDGERS.Acc_tinno, Acc_cmpname ORDER BY LEDGERS.Acc_cmpname ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , False, 12)
                Write(DTROW("NAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 12, True)
                Write(DTROW("TINNO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 12, True)
                Write(Format(Val(DTROW("TOTALAMT")), "0.00"), Range("4"), XlHAlign.xlHAlignRight, , False, 12)
                Write(Format(Val(DTROW("TAXAMT")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, , False, 12)
                Write(Format(Val(DTROW("GTOTAL")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, Range("7"), False, 12)
                objSheet.Range(Range("6"), Range("7")).Interior.Color = RGB(198, 239, 206)
                SetBorder(RowIndex, Range("1"), Range("7"))
                SRNO += 1
            Next
            RowIndex += 1
            Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , True, 12)
            Write("Gross Total", Range("2"), XlHAlign.xlHAlignLeft, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 9 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 9 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 9 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, Range("7"), True, 12)
            objSheet.Range(Range("3"), Range("7")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("6"))


            objSheet.Range(objColumn.Item("4").ToString & 9, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 9, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 9, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 9, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 9, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 9, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 9, objColumn.Item("6").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 10
                .LeftMargin = 10
                .RightMargin = 10
                .BottomMargin = 10
                .CenterHorizontally = True
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region


#Region "GST REPORTS"

    Public Function GSTSUMMARY_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("1"), 25)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("7"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("7"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("7"))

            RowIndex += 1
            Write("GST SUMMARY (" & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy") & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("7"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("7").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("7").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("7").ToString & RowIndex + 1)

            RowIndex += 2
            Write("", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("TAXABLE AMT", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CGST", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SGST", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAX C+S", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("IGST", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TOTAL", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)

            'FIRST GET OPENING WITH RESPECT TO FROM DATE
            'FOR NOW OPENING WILL BE BLANK
            RowIndex += 1
            Write("OPENING", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)



            'PURCHASE + CREDIT NOTE (REGISTERED)
            RowIndex += 1
            Write("PURCHASE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" ISNULL(SUM(BILL_TOTALTAXABLEAMT),0) AS TAXABLEAMT, ISNULL(SUM(BILL_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(BILL_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(BILL_TOTALIGSTAMT),0) AS IGST ", "", " PURCHASEMASTER ", " AND BILL_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND BILL_YEARID = " & YEARID & " AND ISNULL(BILL_RCM,0) = 'FALSE'")
            DTNP = OBJCMN.search(" ISNULL(SUM(NP_TOTALTAXABLEAMT),0) AS TAXABLEAMT, ISNULL(SUM(NP_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(NP_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(NP_TOTALIGSTAMT),0) AS IGST ", "", " NONPURCHASE ", " AND NP_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND NP_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "'  AND NP_YEARID = " & YEARID & " AND ISNULL(NP_RCM,0) = 'FALSE'")
            Write(Val(DT.Rows(0).Item("TAXABLEAMT")) + Val(DTNP.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            Write(Val(DT.Rows(0).Item("CGST")) + Val(DTNP.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            Write(Val(DT.Rows(0).Item("SGST")) + Val(DTNP.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            Write(Val(DT.Rows(0).Item("CGST")) + Val(DTNP.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DTNP.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            Write(Val(DT.Rows(0).Item("IGST")) + Val(DTNP.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            Write(Val(DT.Rows(0).Item("CGST")) + Val(DTNP.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DTNP.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")) + Val(DTNP.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)


            'PURCHASE + CREDIT NOTE (URD)
            RowIndex += 1
            Write("PURCHASE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" ISNULL(SUM(BILL_TOTALTAXABLEAMT),0) AS TAXABLEAMT, ISNULL(SUM(BILL_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(BILL_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(BILL_TOTALIGSTAMT),0) AS IGST ", "", " PURCHASEMASTER ", " AND BILL_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND BILL_YEARID = " & YEARID & " AND ISNULL(BILL_RCM,0) = 'TRUE'")
            DTNP = OBJCMN.search(" ISNULL(SUM(NP_TOTALTAXABLEAMT),0) AS TAXABLEAMT, ISNULL(SUM(NP_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(NP_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(NP_TOTALIGSTAMT),0) AS IGST ", "", " NONPURCHASE ", " AND NP_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND NP_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "'AND NP_YEARID = " & YEARID & " AND ISNULL(NP_RCM,0) = 'TRUE'")
            Write(Val(DT.Rows(0).Item("TAXABLEAMT")) + Val(DTNP.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            Write(Val(DT.Rows(0).Item("CGST")) + Val(DTNP.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            Write(Val(DT.Rows(0).Item("SGST")) + Val(DTNP.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            Write(Val(DT.Rows(0).Item("CGST")) + Val(DTNP.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DTNP.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            Write(Val(DT.Rows(0).Item("IGST")) + Val(DTNP.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            Write(Val(DT.Rows(0).Item("CGST")) + Val(DTNP.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DTNP.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")) + Val(DTNP.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)


            'SALE + DEBIT NOTE (REGISTERED)
            RowIndex += 1
            Write("SALE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" ISNULL(SUM(INVOICE_TOTALTAXABLEAMT),0) AS TAXABLEAMT, ISNULL(SUM(INVOICE_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(INVOICE_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(INVOICE_TOTALIGSTAMT),0) AS IGST ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICE_LEDGERID = ACC_ID ", " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') <> ''")
            Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)



            'SALE + DEBIT NOTE (B TO C)
            RowIndex += 1
            Write("SALE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" ISNULL(SUM(INVOICE_TOTALTAXABLEAMT),0) AS TAXABLEAMT, ISNULL(SUM(INVOICE_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(INVOICE_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(INVOICE_TOTALIGSTAMT),0) AS IGST ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICE_LEDGERID = ACC_ID ", " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') = ''")
            Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)


            'CLOSING
            RowIndex += 1
            Write("CLOSING", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("3").ToString & 9 & ":" & objColumn.Item("3").ToString & 10 & ") - SUM(" & objColumn.Item("3").ToString & 11 & ":" & objColumn.Item("3").ToString & 12 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 9 & ":" & objColumn.Item("4").ToString & 10 & ") - SUM(" & objColumn.Item("4").ToString & 11 & ":" & objColumn.Item("4").ToString & 12 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 9 & ":" & objColumn.Item("5").ToString & 10 & ") - SUM(" & objColumn.Item("5").ToString & 11 & ":" & objColumn.Item("5").ToString & 12 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 9 & ":" & objColumn.Item("6").ToString & 10 & ") - SUM(" & objColumn.Item("6").ToString & 11 & ":" & objColumn.Item("6").ToString & 12 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 9 & ":" & objColumn.Item("7").ToString & 10 & ") - SUM(" & objColumn.Item("7").ToString & 11 & ":" & objColumn.Item("7").ToString & 12 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)

            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 20
                .LeftMargin = 10
                .RightMargin = 5
                .BottomMargin = 10
                .Zoom = False
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTSALEDETAILS_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("3"), 25)
            SetColumnWidth(Range("4"), 15)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("14"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("14"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("14"))

            RowIndex += 1
            Write("GST SALE DETAILS (" & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy") & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("14"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("14").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("14").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("14").ToString & RowIndex + 1)

            RowIndex += 2
            Write("INV NO", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("INV DT", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("NAME", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("GSTIN", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("STATE", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CITY", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("QTY", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAXABLE AMT", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CGST", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SGST", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAX C+S", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("IGST", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("OTHER CHGS", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TOTAL", Range("14"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, objColumn.Item("14").ToString & RowIndex)


            'SALE + DEBIT NOTE (REGISTERED)
            RowIndex += 1
            Write("SALE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" INVOICEMASTER.INVOICE_NO AS INVNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY, ISNULL(INVOICEMASTER.INVOICE_TOTALQTY, 0) AS QTY,  ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) AS TAXABLEAMT, ISNULL(INVOICEMASTER.INVOICE_TOTALCGSTAMT, 0) AS CGST, ISNULL(INVOICEMASTER.INVOICE_TOTALSGSTAMT, 0) AS SGST, ISNULL(INVOICEMASTER.INVOICE_TOTALIGSTAMT, 0) AS IGST, ISNULL(INVOICEMASTER.INVOICE_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID ", " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') <> '' ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("QTY")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("13"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("14"), XlHAlign.xlHAlignRight, , True, 10)
            Next



            'SALE + DEBIT NOTE (B TO C)
            RowIndex += 2
            Write("SALE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" INVOICEMASTER.INVOICE_NO AS INVNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY, ISNULL(INVOICEMASTER.INVOICE_TOTALQTY, 0) AS QTY, ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) AS TAXABLEAMT, ISNULL(INVOICEMASTER.INVOICE_TOTALCGSTAMT, 0) AS CGST, ISNULL(INVOICEMASTER.INVOICE_TOTALSGSTAMT, 0) AS SGST, ISNULL(INVOICEMASTER.INVOICE_TOTALIGSTAMT, 0) AS IGST, ISNULL(INVOICEMASTER.INVOICE_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id  LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID", " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') = ''  ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("QTY")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("13"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("14"), XlHAlign.xlHAlignRight, , True, 10)
            Next



            'CLOSING
            RowIndex += 1
            Write("CLOSING", Range("1"), XlHAlign.xlHAlignLeft, Range("4"), True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 9 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 9 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 9 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 9 & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & 9 & ":" & objColumn.Item("11").ToString & RowIndex - 1 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("12").ToString & 9 & ":" & objColumn.Item("12").ToString & RowIndex - 1 & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("13").ToString & 9 & ":" & objColumn.Item("13").ToString & RowIndex - 1 & ")", Range("13"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("14").ToString & 9 & ":" & objColumn.Item("14").ToString & RowIndex - 1 & ")", Range("14"), XlHAlign.xlHAlignRight, , True, 12)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, objColumn.Item("14").ToString & RowIndex)


            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 8, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 8, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & 8, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & 8, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & 8, objColumn.Item("14").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 20
                .LeftMargin = 10
                .RightMargin = 5
                .BottomMargin = 10
                .Zoom = False
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTPURCHASEDETAILS_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("3"), 25)
            SetColumnWidth(Range("4"), 15)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("13"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("13"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("13"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("13"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("13"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("13"))

            RowIndex += 1
            Write("GST PURCHASE DETAILS (" & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy") & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("13"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("13"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("13").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("13").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("13").ToString & RowIndex + 1)

            RowIndex += 2
            Write("BILL NO", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("BILL DT", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("NAME", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("GSTIN", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("STATE", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CITY", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAXABLE AMT", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CGST", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SGST", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAX C+S", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("IGST", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("OTHER CHGS", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TOTAL", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)


            'PURCHASE (REGISTERED)
            RowIndex += 1
            Write("PURCHASE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" PURCHASEMASTER.BILL_PARTYBILLNO AS INVNO, PURCHASEMASTER.BILL_PARTYBILLDATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY,  ISNULL(PURCHASEMASTER.BILL_TOTALTAXABLEAMT, 0)AS TAXABLEAMT, ISNULL(PURCHASEMASTER.BILL_TOTALCGSTAMT, 0) AS CGST, ISNULL(PURCHASEMASTER.BILL_TOTALSGSTAMT, 0) AS SGST, ISNULL(PURCHASEMASTER.BILL_TOTALIGSTAMT, 0) AS IGST, ISNULL(PURCHASEMASTER.BILL_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(PURCHASEMASTER.BILL_GTOTAL, 0) AS GRANDTOTAL  ", "", " PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID ", " AND BILL_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND BILL_YEARID = " & YEARID & " AND ISNULL(PURCHASEMASTER.BILL_RCM,'FALSE') = 'FALSE'  ORDER BY PURCHASEMASTER.BILL_PARTYBILLDATE, PURCHASEMASTER.BILL_PARTYBILLNO ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("13"), XlHAlign.xlHAlignRight, , True, 10)
            Next


            'NONPURCHASE (REGISTERED)
            RowIndex += 2
            Write("NONPURCHASE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" NONPURCHASE.NP_REFNO AS INVNO, NONPURCHASE.NP_PARTYBILLDATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY, ISNULL(NP_TOTALTAXABLEAMT,0) AS TAXABLEAMT, ISNULL(NONPURCHASE.NP_TOTALCGSTAMT, 0) AS CGST, ISNULL(NONPURCHASE.NP_TOTALSGSTAMT, 0) AS SGST, ISNULL(NONPURCHASE.NP_TOTALIGSTAMT, 0) AS IGST, ISNULL(NONPURCHASE.NP_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(NONPURCHASE.NP_GRANDTOTAL, 0) AS GRANDTOTAL  ", "", " NONPURCHASE INNER JOIN LEDGERS ON NONPURCHASE.NP_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID ", " AND NP_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND NP_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND NP_YEARID = " & YEARID & " AND ISNULL(NONPURCHASE.NP_RCM,'FALSE') = 'FALSE'  ORDER BY NONPURCHASE.NP_PARTYBILLDATE, NONPURCHASE.NP_REFNO ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("13"), XlHAlign.xlHAlignRight, , True, 10)
            Next



            'PURCHASE (URD)
            RowIndex += 2
            Write("PURCHASE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" PURCHASEMASTER.BILL_PARTYBILLNO AS INVNO, PURCHASEMASTER.BILL_PARTYBILLDATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY, ISNULL(PURCHASEMASTER.BILL_TOTALTAXABLEAMT, 0)  AS TAXABLEAMT, ISNULL(PURCHASEMASTER.BILL_TOTALCGSTAMT, 0) AS CGST, ISNULL(PURCHASEMASTER.BILL_TOTALSGSTAMT, 0) AS SGST, ISNULL(PURCHASEMASTER.BILL_TOTALIGSTAMT, 0) AS IGST, ISNULL(PURCHASEMASTER.BILL_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(PURCHASEMASTER.BILL_GTOTAL, 0) AS GRANDTOTAL  ", "", " PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID ", " AND BILL_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND BILL_YEARID = " & YEARID & " AND ISNULL(PURCHASEMASTER.BILL_RCM,'FALSE') = 'TRUE' ORDER BY PURCHASEMASTER.BILL_PARTYBILLDATE, PURCHASEMASTER.BILL_PARTYBILLNO ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("13"), XlHAlign.xlHAlignRight, , True, 10)
            Next


            'NONPURCHASE (URD)
            RowIndex += 2
            Write("NONPURCHASE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" NONPURCHASE.NP_REFNO AS INVNO, NONPURCHASE.NP_PARTYBILLDATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY, ISNULL(NONPURCHASE.NP_TOTALTAXABLEAMT, 0) AS TAXABLEAMT, ISNULL(NONPURCHASE.NP_TOTALCGSTAMT, 0) AS CGST, ISNULL(NONPURCHASE.NP_TOTALSGSTAMT, 0) AS SGST, ISNULL(NONPURCHASE.NP_TOTALIGSTAMT, 0) AS IGST, ISNULL(NONPURCHASE.NP_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(NONPURCHASE.NP_GRANDTOTAL, 0) AS GRANDTOTAL  ", "", " NONPURCHASE INNER JOIN LEDGERS ON NONPURCHASE.NP_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID ", " AND NP_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND NP_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND NP_YEARID = " & YEARID & " AND ISNULL(NONPURCHASE.NP_RCM,'FALSE') = 'TRUE'  ORDER BY NONPURCHASE.NP_PARTYBILLDATE, NONPURCHASE.NP_REFNO ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("13"), XlHAlign.xlHAlignRight, , True, 10)
            Next



            'CLOSING
            RowIndex += 1
            Write("CLOSING", Range("1"), XlHAlign.xlHAlignLeft, Range("4"), True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 9 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 9 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 9 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 9 & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & 9 & ":" & objColumn.Item("11").ToString & RowIndex - 1 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("12").ToString & 9 & ":" & objColumn.Item("12").ToString & RowIndex - 1 & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("13").ToString & 9 & ":" & objColumn.Item("13").ToString & RowIndex - 1 & ")", Range("13"), XlHAlign.xlHAlignRight, , True, 12)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)


            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 8, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 8, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & 8, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & 8, objColumn.Item("13").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 20
                .LeftMargin = 10
                .RightMargin = 5
                .BottomMargin = 10
                .Zoom = False
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTB2B_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("2"), 17)
            SetColumnWidth(Range("4"), 17)
            SetColumnWidth(Range("5"), 17)
            SetColumnWidth(Range("8"), 17)
            SetColumnWidth(Range("9"), 10)
            SetColumnWidth(Range("10"), 17)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable

            Write("Summary For B2B (4)", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            objSheet.Range(Range("1"), Range("1")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(0, 128, 255)

            RowIndex += 1
            Write("No Of Receipients", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("No Of Invoices", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Invoice Value", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Taxable Value", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Cess", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            objSheet.Range(Range("1"), Range("11")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(0, 128, 255)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)


            RowIndex += 1
            FORMULA("=SUMPRODUCT((" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "<>"""")/COUNTIF(" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "," & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "&""""))", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            FORMULA("=SUMPRODUCT((" & objColumn.Item("2").ToString & 5 & ":" & objColumn.Item("2").ToString & 40000 & "<>"""")/COUNTIF(" & objColumn.Item("2").ToString & 5 & ":" & objColumn.Item("2").ToString & 40000 & "," & objColumn.Item("2").ToString & 5 & ":" & objColumn.Item("2").ToString & 40000 & "&""""))", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 5 & ":" & objColumn.Item("4").ToString & 40000 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 5 & ":" & objColumn.Item("10").ToString & 40000 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & 5 & ":" & objColumn.Item("11").ToString & 40000 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("4").ToString & 3, objColumn.Item("4").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 3, objColumn.Item("10").ToString & 3).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)



            RowIndex += 1
            Write("GSTIN/UIN Of Receipients", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("Invoice No", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice Date", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice Value", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Place Of Supply", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Reverse Charge", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice Type", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("E-Commerce GSTIN", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Rate", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Taxable Value", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess Amount", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(250, 240, 230)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)



            'SALE(REGISTERED)
            DT = OBJCMN.search(" INVOICEMASTER.INVOICE_INITIALS AS INVNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE,  ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0)  AS TAXABLEAMT, 0 AS GSTPER, ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL  ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID ", " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') <> '' ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("GSTIN"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("INVNO"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GRANDTOTAL"), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("N", Range("6"), XlHAlign.xlHAlignCenter, , False, 10)
                Write("REGULAR", Range("7"), XlHAlign.xlHAlignCenter, , False, 10)
                Write("", Range("8"), XlHAlign.xlHAlignLeft, , False, 10)

                'GET GSTPER FROM 1ST RECORD OF INVOICEDESC AND FETCH FROM HSNCODE
                Dim OBJGST As System.Data.DataTable = OBJCMN.search("HSN_IGST AS GSTPER", "", " INVOICEMASTER_DESC INNER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID ", " AND INVOICE_INITIALS = '" & DTROW("INVNO") & "' AND INVOICE_YEARID = " & YEARID)
                If OBJGST.Rows.Count > 0 Then Write(Val(OBJGST.Rows(0).Item("GSTPER")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("11"), XlHAlign.xlHAlignRight, , False, 10)
            Next

            objSheet.Range(objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 5, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 5, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 5, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 5, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 5, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 5, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 5, objColumn.Item("11").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 20
                .LeftMargin = 10
                .RightMargin = 5
                .BottomMargin = 10
                .Zoom = False
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTB2CL_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("3"), 17)
            SetColumnWidth(Range("4"), 17)
            SetColumnWidth(Range("6"), 17)
            SetColumnWidth(Range("8"), 17)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable

            Write("Summary For B2CL (5)", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            objSheet.Range(Range("1"), Range("1")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(0, 128, 255)

            RowIndex += 1
            Write("No Of Invoices", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("Total Invoice Value", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Taxable Value", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Cess", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            objSheet.Range(Range("1"), Range("8")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("8")).Interior.Color = RGB(0, 128, 255)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)


            RowIndex += 1
            FORMULA("=SUMPRODUCT((" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "<>"""")/COUNTIF(" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "," & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "&""""))", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            FORMULA("=SUMPRODUCT(1/COUNTIF(" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "," & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "&"""")," & objColumn.Item("3").ToString & 5 & ":" & objColumn.Item("3").ToString & 40000 & ")", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 5 & ":" & objColumn.Item("6").ToString & 40000 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 5 & ":" & objColumn.Item("7").ToString & 40000 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("3").ToString & 3, objColumn.Item("3").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 3, objColumn.Item("6").ToString & 3).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)



            RowIndex += 1
            Write("Invoice No", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice Date", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice Value", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Place Of Supply", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Rate", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Taxable Value", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess Amount", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("E-Commerce GSTIN", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("8")).Interior.Color = RGB(250, 240, 230)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)



            'SALE(URD)
            DT = OBJCMN.search(" INVOICEMASTER.INVOICE_INITIALS AS INVNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE,  ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0)AS TAXABLEAMT , 0 AS GSTPER, ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL  ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID ", " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') = '' AND ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) > 250000 ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GRANDTOTAL"), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)

                'GET GSTPER FROM 1ST RECORD OF INVOICEDESC AND FETCH FROM HSNCODE
                Dim OBJGST As System.Data.DataTable = OBJCMN.search("HSN_IGST AS GSTPER", "", " INVOICEMASTER_DESC INNER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID ", " AND INVOICE_INITIALS = '" & DTROW("INVNO") & "' AND INVOICE_YEARID = " & YEARID)
                If OBJGST.Rows.Count > 0 Then Write(Val(OBJGST.Rows(0).Item("GSTPER")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write("", Range("8"), XlHAlign.xlHAlignRight, , False, 10)
            Next

            objSheet.Range(objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 5, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 5, objColumn.Item("8").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 20
                .LeftMargin = 10
                .RightMargin = 5
                .BottomMargin = 10
                .Zoom = False
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTB2CS_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("2"), 17)
            SetColumnWidth(Range("4"), 17)
            SetColumnWidth(Range("6"), 17)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable

            Write("Summary For B2CS (7)", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            objSheet.Range(Range("1"), Range("1")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(0, 128, 255)

            RowIndex += 1
            Write("Total Taxable Value", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Cess", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            objSheet.Range(Range("1"), Range("6")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("6")).Interior.Color = RGB(0, 128, 255)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)


            RowIndex += 1
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 5 & ":" & objColumn.Item("4").ToString & 40000 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 5 & ":" & objColumn.Item("5").ToString & 40000 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("4").ToString & 3, objColumn.Item("4").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 3, objColumn.Item("5").ToString & 3).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)



            RowIndex += 1
            Write("Type", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Place Of Supply", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Rate", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Taxable Value", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess Amount", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("E-Commerce GSTIN", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("8")).Interior.Color = RGB(250, 240, 230)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)



            'SALE(URD)<250000
            DT = OBJCMN.search(" INVOICEMASTER.INVOICE_INITIALS AS INVNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE,ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) AS TAXABLEAMT, 0 AS GSTPER, ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL  ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID ", " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') = '' ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write("OE", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)

                'GET GSTPER FROM 1ST RECORD OF INVOICEDESC AND FETCH FROM HSNCODE
                Dim OBJGST As System.Data.DataTable = OBJCMN.search("HSN_IGST AS GSTPER", "", " INVOICEMASTER_DESC INNER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID ", " AND INVOICE_INITIALS = '" & DTROW("INVNO") & "' AND INVOICE_YEARID = " & YEARID)
                If OBJGST.Rows.Count > 0 Then Write(Val(OBJGST.Rows(0).Item("GSTPER")), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write("", Range("6"), XlHAlign.xlHAlignRight, , False, 10)
            Next

            objSheet.Range(objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 20
                .LeftMargin = 10
                .RightMargin = 5
                .BottomMargin = 10
                .Zoom = False
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTHSN_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 17)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("2"), 25)
            SetColumnWidth(Range("7"), 20)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable

            Write("Summary For HSN (12)", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            objSheet.Range(Range("1"), Range("1")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(0, 128, 255)

            RowIndex += 1
            Write("No Of HSN", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("Total Value", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Taxable Value", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Integrated Tax", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Central Tax", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total State/UT Tax", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Cess", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            objSheet.Range(Range("1"), Range("10")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("10")).Interior.Color = RGB(0, 128, 255)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)


            RowIndex += 1
            FORMULA("=SUMPRODUCT((" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "<>"""")/COUNTIF(" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "," & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "&""""))", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 5 & ":" & objColumn.Item("5").ToString & 40000 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 5 & ":" & objColumn.Item("6").ToString & 40000 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 5 & ":" & objColumn.Item("7").ToString & 40000 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 5 & ":" & objColumn.Item("8").ToString & 40000 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 5 & ":" & objColumn.Item("9").ToString & 40000 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 5 & ":" & objColumn.Item("10").ToString & 40000 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("5").ToString & 3, objColumn.Item("5").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 3, objColumn.Item("6").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("7").ToString & 3, objColumn.Item("7").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 3, objColumn.Item("8").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 3, objColumn.Item("9").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 3, objColumn.Item("10").ToString & 3).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)



            RowIndex += 1
            Write("HSN", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("Description", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("UQC", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Qty", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Value", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Taxable Value", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Integrated Tax Amount", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Central Tax Amount", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("State/UT Tax Amount", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess Amount", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(250, 240, 230)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)



            'SALE(REGISTERED)
            DT = OBJCMN.search(" ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS HSNDESC, SUM(ISNULL(INVOICEMASTER_DESC.INVOICE_QTY, 0)) AS QTY, ROUND(SUM(ISNULL(INVOICEMASTER_DESC.INVOICE_GRIDTOTAL, 0)),0) AS GRANDTOTAL, SUM(ISNULL(INVOICEMASTER_DESC.INVOICE_TAXABLEAMT, 0)) AS TAXABLEAMT, SUM(ISNULL(INVOICEMASTER_DESC.INVOICE_IGSTAMT, 0)) AS IGSTAMT, SUM(ISNULL(INVOICEMASTER_DESC.INVOICE_CGSTAMT, 0)) AS CGSTAMT, SUM(ISNULL(INVOICEMASTER_DESC.INVOICE_SGSTAMT, 0)) AS SGSTAMT  ", "", " INVOICEMASTER_DESC INNER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID INNER JOIN INVOICEMASTER ON INVOICEMASTER_DESC.INVOICE_NO = INVOICEMASTER.INVOICE_NO AND INVOICEMASTER_DESC.INVOICE_REGISTERID = INVOICEMASTER.INVOICE_REGISTERID AND INVOICEMASTER_DESC.INVOICE_YEARID = INVOICEMASTER.INVOICE_YEARID  ", " AND INVOICEMASTER.INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_YEARID = " & YEARID & " GROUP BY ISNULL(HSNMASTER.HSN_CODE, ''), ISNULL(HSNMASTER.HSN_ITEMDESC, '')")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("HSNCODE"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("HSNDESC"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("QTY")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)


                'Dim DTINV As New System.Data.DataTable
                'WE CAN NOT GET GRAND TOTAL IN ABOVE QUERY COZ THIS WIL CALC GRANDTOTAL MULTIPLE TIMES COZ WE HAVE JOIN WITH INVOICEDESC
                'BELOW CODE WASS TAKING TIME 
                'If INVOICESCREENTYPE = "LINE GST" Then
                'Else
                '    DTINV = OBJCMN.search("DISTINCT INVOICEMASTER.INVOICE_NO  ROUND(SUM(ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0)),0) AS GRANDTOTAL, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN SUM(ISNULL(INVOICEMASTER_DESC.INVOICE_TAXABLEAMT, 0)) ELSE SUM(ISNULL(INVOICEMASTER.INVOICE_SUBTOTAL, 0)) END) AS TAXABLEAMT,", "", " INVOICEMASTER_DESC INNER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID INNER JOIN INVOICEMASTER ON INVOICEMASTER_DESC.INVOICE_NO = INVOICEMASTER.INVOICE_NO AND INVOICEMASTER_DESC.INVOICE_REGISTERID = INVOICEMASTER.INVOICE_REGISTERID AND INVOICEMASTER_DESC.INVOICE_YEARID = INVOICEMASTER.INVOICE_YEARID ", " AND INVOICEMASTER.INVOICE_YEARID = " & YEARID & " AND HSN_CODE = '" & DTROW("HSNCODE") & "'")
                'End If

                Write(Val(DTROW("GRANDTOTAL")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGSTAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGSTAMT")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGSTAMT")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("10"), XlHAlign.xlHAlignRight, , False, 10)
            Next

            objSheet.Range(objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("7").ToString & 5, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 5, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 5, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 5, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.00"



            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 5, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 5, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 5, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 5, objColumn.Item("10").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 20
                .LeftMargin = 10
                .RightMargin = 5
                .BottomMargin = 10
                .Zoom = False
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region


#Region "VAT REPORTS"

    Public Function VATSALE_EXCEL(ByVal WHERECLAUSE As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object

        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 17)
            Next

            SetColumnWidth(Range(3), 40)


            RowIndex = 1
            Write("FORM 201A", Range("1"), XlHAlign.xlHAlignLeft, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))

            RowIndex += 1
            Write("Tax Invoice No.", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("Date", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("Name with RC No. of the registered dealer to whom goods sold", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 10, True)
            SetBorder(RowIndex, Range("3"), Range("4"))
            Write("Turnover of Sale of taxable goods", Range("5"), XlHAlign.xlHAlignCenter, Range("9"), True, 10, True)
            SetBorder(RowIndex, Range("5"), Range("9"))
            objSheet.Range(Range("1"), Range("9")).Interior.Color = RGB(191, 191, 191)


            RowIndex += 1
            Write("Sale of Goods to registered dealer", Range("1"), XlHAlign.xlHAlignLeft, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))
            objSheet.Range(Range("1"), Range("9")).Interior.Color = RGB(191, 191, 191)


            RowIndex += 1
            Write("Tax Invoice No.(201A)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Date", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Name", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("R.C. No", Range("4"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Goods with HSN", Range("5"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Value of Goods", Range("6"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Tax", Range("7"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Additional Tax", Range("8"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Total", Range("9"), XlHAlign.xlHAlignLeft, , True, 10)
            objSheet.Range(Range("1"), Range("9")).Interior.Color = RGB(191, 191, 191)
            SetBorder(RowIndex, Range("1"), Range("9"))


            Dim OBJCMN As New ClsCommon
            Dim DT As System.Data.DataTable = OBJCMN.search("*", "", " REPORT_SP_ACCOUNTS_INVOICESUMMARY ", WHERECLAUSE & " AND CMPID = " & CMPID & " AND LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID)
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("BILL NO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Convert.ToDateTime(DTROW("DATE")).Date, "dd/MM/yyyy"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("PARTYVATNO"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("COTTON BALES", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Val(DTROW("SUBTOTAL")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("TAXAMT")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("ADDTAXAMT")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("9"))
            Next

            objSheet.Range(Range("6")).NumberFormat = "0.00"
            objSheet.Range(Range("7")).NumberFormat = "0.00"
            objSheet.Range(Range("8")).NumberFormat = "0.00"
            objSheet.Range(Range("9")).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 4, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 4, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 4, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 4, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 4, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 4, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 4, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 4, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 4, objColumn.Item("9").ToString & RowIndex)

            objSheet.Range(objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex).Interior.Color = RGB(255, 153, 204)
            objSheet.Range(objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex).Interior.Color = RGB(255, 204, 153)
            objSheet.Range(objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex).Interior.Color = RGB(153, 204, 255)
            objSheet.Range(objColumn.Item("4").ToString & 5, objColumn.Item("9").ToString & RowIndex).Interior.Color = RGB(204, 255, 255)


            objBook.Application.ActiveWindow.Zoom = 100



            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 10
                .LeftMargin = 10
                .RightMargin = 10
                .BottomMargin = 10
                .CenterHorizontally = True
            End With

            SaveAndClose()
        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function VATPURCHASE_EXCEL(ByVal WHERECLAUSE As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next

            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 17)
            Next

            SetColumnWidth(Range(3), 40)


            RowIndex = 1
            Write("FORM 201B", Range("1"), XlHAlign.xlHAlignLeft, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))

            RowIndex += 1
            Write("Tax Invoice No.", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("Date", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("Name with RC No. of the registered dealer from whom goods purchased", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 10, True)
            SetBorder(RowIndex, Range("3"), Range("4"))
            Write("Turnover of Purchase of taxable goods", Range("5"), XlHAlign.xlHAlignCenter, Range("9"), True, 10, True)
            SetBorder(RowIndex, Range("5"), Range("9"))
            objSheet.Range(Range("1"), Range("9")).Interior.Color = RGB(191, 191, 191)


            RowIndex += 1
            Write("Purchase of Goods from registered dealer", Range("1"), XlHAlign.xlHAlignLeft, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))
            objSheet.Range(Range("1"), Range("9")).Interior.Color = RGB(191, 191, 191)


            RowIndex += 1
            Write("Tax Invoice No.(201A)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Date", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Name", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("R.C. No", Range("4"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Goods with HSN", Range("5"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Value of Goods", Range("6"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Tax", Range("7"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Additional Tax", Range("8"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Total", Range("9"), XlHAlign.xlHAlignLeft, , True, 10)
            objSheet.Range(Range("1"), Range("9")).Interior.Color = RGB(191, 191, 191)
            SetBorder(RowIndex, Range("1"), Range("9"))


            Dim OBJCMN As New ClsCommon
            Dim DT As System.Data.DataTable = OBJCMN.search("*", "", " REPORT_SP_ACCOUNTS_PURCHASESUMMARY ", WHERECLAUSE & " AND CMPID = " & CMPID & " AND LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID)
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("PARTYBILLNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Convert.ToDateTime(DTROW("PARTYBILLDATE")).Date, "dd/MM/yyyy"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("PARTYVATNO"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("COTTON BALES", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Val(DTROW("SUBTOTAL")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("TAXAMT")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("ADDTAXAMT")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("9"))
            Next

            objSheet.Range(Range("6")).NumberFormat = "0.00"
            objSheet.Range(Range("7")).NumberFormat = "0.00"
            objSheet.Range(Range("8")).NumberFormat = "0.00"
            objSheet.Range(Range("9")).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 4, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 4, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 4, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 4, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 4, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 4, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 4, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 4, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 4, objColumn.Item("9").ToString & RowIndex)

            objSheet.Range(objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex).Interior.Color = RGB(255, 153, 204)
            objSheet.Range(objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex).Interior.Color = RGB(255, 204, 153)
            objSheet.Range(objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex).Interior.Color = RGB(153, 204, 255)
            objSheet.Range(objColumn.Item("4").ToString & 5, objColumn.Item("9").ToString & RowIndex).Interior.Color = RGB(204, 255, 255)


            objBook.Application.ActiveWindow.Zoom = 100



            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 10
                .LeftMargin = 10
                .RightMargin = 10
                .BottomMargin = 10
                .CenterHorizontally = True
            End With

            SaveAndClose()
        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "STATEMENTOFACCOUNTS"

    Public Function STATEMENTOFACCOUNTS_EXCEL(ByVal DV As System.Data.DataView, ByVal NAME As String, ByVal OPDRCR As String, ByVal OPENING As Double, ByVal CLODRCR As String, ByVal CLOSING As Double, ByVal PERIOD As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 12)
            Next

            SetColumnWidth(Range(1), 46)
            SetColumnWidth(Range(2), 7)
            SetColumnWidth(Range(3), 9)
            SetColumnWidth(Range(4), 9)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("STATEMENT OF ACCOUTS", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))


            Dim DTLEDGER As System.Data.DataTable = OBJCMN.search(" ISNULL(Acc_panno,'') AS PANNO, ISNULL(CITY_NAME,'') AS CITYNAME ", "", " LEDGERS LEFT OUTER JOIN CITYMASTER ON ACC_CITYID = CITY_ID ", " AND ACC_CMPNAME = '" & NAME & "' AND ACC_CMPID = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND ACC_YEARID = " & YEARID)
            RowIndex += 1
            Write("NAME" & "          :  " & NAME & "   -   " & UCase(DTLEDGER.Rows(0).Item("CITYNAME")), Range("1"), XlHAlign.xlHAlignLeft, Range("6"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("PAN NO" & "        :  " & DTLEDGER.Rows(0).Item("PANNO"), Range("1"), XlHAlign.xlHAlignLeft, Range("6"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("PERIOD" & "        :  " & PERIOD, Range("1"), XlHAlign.xlHAlignLeft, Range("1"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("1"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("6").ToString & 10).Select()
            objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("6").ToString & 10).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("6").ToString & RowIndex + 1)



            RowIndex += 1
            Write("DESCRIPTION", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TYPE", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("BILL", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("DATE", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("DEBIT", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CREDIT", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)


            RowIndex += 1
            Write("OPENING BALANCE ", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("1"))
            If OPDRCR = "Dr" Then
                Write(OPENING, Range("5"), XlHAlign.xlHAlignRight, Range("5"), False, 10)
            Else
                Write(OPENING, Range("6"), XlHAlign.xlHAlignRight, Range("6"), False, 10)
            End If
            SetBorder(RowIndex, Range("5"), Range("5"))
            SetBorder(RowIndex, Range("6"), Range("6"))


            Dim STARTROWNO As Integer = RowIndex + 1
            Dim DT As System.Data.DataTable = DV.Table


            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                If DTROW("TYPE") = "SALE" Then
                    Write(DTROW("REGTYPE") & "; Due Dt:" & Format(Convert.ToDateTime(DTROW("DUEDATE")).Date, "dd/MM/yyyy"), Range("1"), XlHAlign.xlHAlignLeft, , False, 9)
                Else
                    Write(Convert.ToString(DTROW("REMARKS").ToString), Range("1"), XlHAlign.xlHAlignLeft, , False, 9)
                End If
                Write(DTROW("TYPE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                Write(DTROW("BILL NO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9)
                Write(Format(Convert.ToDateTime(DTROW("DATE")).Date, "dd/MM/yyyy"), Range("4"), XlHAlign.xlHAlignCenter, , False, 9)
                Write(Format(Val(DTROW("DEBIT")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 9)
            Next

            RowIndex += 1
            Write("TOTAL    : ", Range("1"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("4"))
            FORMULA("=SUM(" & objColumn.Item("5").ToString & STARTROWNO & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , False, 9)
            SetBorder(RowIndex, Range("5"), Range("5"))
            FORMULA("=SUM(" & objColumn.Item("6").ToString & STARTROWNO & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , False, 9)
            SetBorder(RowIndex, Range("6"), Range("6"))

            RowIndex += 1
            Write("CLOSING BALANCE    : ", Range("1"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("4"))
            If CLODRCR = "Dr" Then
                Write(CLOSING, Range("5"), XlHAlign.xlHAlignRight, Range("5"), False, 9)
                SetBorder(RowIndex, Range("5"), Range("5"))
            Else
                Write(CLOSING, Range("6"), XlHAlign.xlHAlignRight, Range("6"), False, 9)
                SetBorder(RowIndex, Range("6"), Range("6"))
            End If



            'SET FONT
            objSheet.Range(objColumn.Item("1").ToString & STARTROWNO, objColumn.Item("6").ToString & RowIndex).Font.Name = "Trebuchet MS"
            objSheet.Range(objColumn.Item("1").ToString & STARTROWNO, objColumn.Item("6").ToString & RowIndex).Font.Size = 9


            SetBorder(RowIndex, objColumn.Item("1").ToString & STARTROWNO, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & STARTROWNO, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & STARTROWNO, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & STARTROWNO, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & STARTROWNO, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & STARTROWNO, objColumn.Item("6").ToString & RowIndex)


            objSheet.Range(Range("5")).NumberFormat = "0.00"
            objSheet.Range(Range("6")).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("1").ToString & 1, objColumn.Item("6").ToString & RowIndex).Select()

            objBook.Application.ActiveWindow.Zoom = 100



            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 10
                .LeftMargin = 10
                .RightMargin = 10
                .BottomMargin = 10
                '.Zoom = False
                '.FitToPagesTall = 1
                .FitToPagesWide = 1
                .CenterHorizontally = True
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function STATEMENTOFACCOUNTSDETAILS_EXCEL(ByVal DV As System.Data.DataView, ByVal NAME As String, ByVal OPDRCR As String, ByVal OPENING As Double, ByVal CLODRCR As String, ByVal CLOSING As Double, ByVal PERIOD As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 12)
            Next

            SetColumnWidth(Range(1), 46)
            SetColumnWidth(Range(2), 7)
            SetColumnWidth(Range(3), 9)
            SetColumnWidth(Range(4), 9)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("STATEMENT OF ACCOUTS (DETAILS)", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))


            Dim DTLEDGER As System.Data.DataTable = OBJCMN.search(" ISNULL(Acc_panno,'') AS PANNO, ISNULL(CITY_NAME,'') AS CITYNAME ", "", " LEDGERS LEFT OUTER JOIN CITYMASTER ON ACC_CITYID = CITY_ID ", " AND ACC_CMPNAME = '" & NAME & "' AND ACC_CMPID = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND ACC_YEARID = " & YEARID)
            RowIndex += 1
            Write("NAME" & "          :  " & NAME & "   -   " & UCase(DTLEDGER.Rows(0).Item("CITYNAME")), Range("1"), XlHAlign.xlHAlignLeft, Range("6"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("PAN NO" & "        :  " & DTLEDGER.Rows(0).Item("PANNO"), Range("1"), XlHAlign.xlHAlignLeft, Range("6"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("PERIOD" & "        :  " & PERIOD, Range("1"), XlHAlign.xlHAlignLeft, Range("1"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("1"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("6").ToString & 10).Select()
            objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("6").ToString & 10).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("6").ToString & RowIndex + 1)



            RowIndex += 1
            Write("DESCRIPTION", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TYPE", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("BILL", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("DATE", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("DEBIT", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CREDIT", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)


            RowIndex += 1
            Write("OPENING BALANCE ", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("1"))
            If OPDRCR = "Dr" Then
                Write(OPENING, Range("5"), XlHAlign.xlHAlignRight, Range("5"), False, 10)
            Else
                Write(OPENING, Range("6"), XlHAlign.xlHAlignRight, Range("6"), False, 10)
            End If
            SetBorder(RowIndex, Range("5"), Range("5"))
            SetBorder(RowIndex, Range("6"), Range("6"))


            Dim STARTROWNO As Integer = RowIndex + 1
            Dim DT As System.Data.DataTable = DV.Table


            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                If DTROW("TYPE") = "SALE" Then
                    Write(DTROW("REGTYPE") & "; Due Dt: " & Format(Convert.ToDateTime(DTROW("DUEDATE")).Date, "dd/MM/yyyy") & "; Bales: " & Val(DTROW("TOTALBALES")) & "; Lot No: " & DTROW("LOTNO") & "; " & DTROW("STATION") & "; P.R.No: " & DTROW("PRNO") & "; NW: " & Val(DTROW("NETTWT")) & "; Rt:" & Format(((Val(DTROW("SUBTOTAL")) / 0.2812) / Val(DTROW("NETTWT"))) * 100, "0"), Range("1"), XlHAlign.xlHAlignLeft, , False, 9)
                Else
                    Write(Convert.ToString(DTROW("REMARKS").ToString), Range("1"), XlHAlign.xlHAlignLeft, , False, 9)
                End If
                Write(DTROW("TYPE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                Write(DTROW("BILL NO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9)
                Write(Format(Convert.ToDateTime(DTROW("DATE")).Date, "dd/MM/yyyy"), Range("4"), XlHAlign.xlHAlignCenter, , False, 9)
                Write(Format(Val(DTROW("DEBIT")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 9)
            Next

            RowIndex += 1
            Write("TOTAL    : ", Range("1"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("4"))
            FORMULA("=SUM(" & objColumn.Item("5").ToString & STARTROWNO & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , False, 9)
            SetBorder(RowIndex, Range("5"), Range("5"))
            FORMULA("=SUM(" & objColumn.Item("6").ToString & STARTROWNO & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , False, 9)
            SetBorder(RowIndex, Range("6"), Range("6"))

            RowIndex += 1
            Write("CLOSING BALANCE    : ", Range("1"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("4"))
            If CLODRCR = "Dr" Then
                Write(CLOSING, Range("5"), XlHAlign.xlHAlignRight, Range("5"), False, 9)
                SetBorder(RowIndex, Range("5"), Range("5"))
            Else
                Write(CLOSING, Range("6"), XlHAlign.xlHAlignRight, Range("6"), False, 9)
                SetBorder(RowIndex, Range("6"), Range("6"))
            End If



            'SET FONT
            objSheet.Range(objColumn.Item("1").ToString & STARTROWNO, objColumn.Item("6").ToString & RowIndex).Font.Name = "Trebuchet MS"
            objSheet.Range(objColumn.Item("1").ToString & STARTROWNO, objColumn.Item("6").ToString & RowIndex).Font.Size = 9


            SetBorder(RowIndex, objColumn.Item("1").ToString & STARTROWNO, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & STARTROWNO, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & STARTROWNO, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & STARTROWNO, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & STARTROWNO, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & STARTROWNO, objColumn.Item("6").ToString & RowIndex)


            objSheet.Range(Range("5")).NumberFormat = "0.00"
            objSheet.Range(Range("6")).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("1").ToString & 1, objColumn.Item("6").ToString & RowIndex).Select()

            objBook.Application.ActiveWindow.Zoom = 100



            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlPortrait
                .TopMargin = 10
                .LeftMargin = 10
                .RightMargin = 10
                .BottomMargin = 10
                '.Zoom = False
                '.FitToPagesTall = 1
                .FitToPagesWide = 1
                .CenterHorizontally = True
            End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "BANKRECO"

    Public Function BANKRECO(ByVal NAME As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            Dim OBJRECO As New ClsBankReco
            Dim OBJCMN As New ClsCommon
            Dim ALPARAVAL As New ArrayList
            Dim I As Integer = 0

            ALPARAVAL.Add(NAME)
            ALPARAVAL.Add(FROMDATE)
            ALPARAVAL.Add(TODATE)
            ALPARAVAL.Add(CMPID)
            ALPARAVAL.Add(LOCATIONID)
            ALPARAVAL.Add(YEARID)

            OBJRECO.alParaval = ALPARAVAL
            Dim DT As System.Data.DataTable = OBJRECO.GETDATA()
            Dim DTTOTAL As System.Data.DataTable = OBJRECO.GETTOTAL
            If DT.Rows.Count > 0 Then

                SetWorkSheet()
                For I = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next


                RowIndex = 1
                For I = 1 To 26
                    SetColumnWidth(Range(I), 14)
                Next


                ' **************************** CMPHEADER *************************
                Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

                RowIndex = 2
                Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 14)
                SetBorder(RowIndex, Range("1"), Range("8"))

                'ADD1
                RowIndex += 1
                Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))

                'ADD2
                RowIndex += 1
                Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))




                'FREEZE TOP 7 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("8").ToString & 10).Select()
                objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("8").ToString & 10).Application.ActiveWindow.FreezePanes = True

                ' **************************** CMPHEADER *************************




                RowIndex += 2
                Write("Name : " & NAME, Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("Run Date : " & Now.Date, Range("6"), XlHAlign.xlHAlignLeft, Range("8"), False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))


                RowIndex += 1
                Write("Bank Reconciliation Statement from " & FROMDATE & " to " & TODATE, Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))


                'HEADERS
                RowIndex += 2
                Write("Booking No", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Date", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Name", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 10)
                Write("Chq No", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Reco Date", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Amount", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Balance", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)



                RowIndex += 2
                Write("Bank Balance as per Ledger Book", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                Write(Format(Val(DTTOTAL.Rows(0).Item("BOOKBAL")), "0.00") & "  " & DTTOTAL.Rows(0).Item("BOOKDRCR"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)


                'AS PER JEETU
                'GET ALL DEBIT AMOUNT RECOED
                'I = 0
                'RowIndex += 1
                'Write("Chques Deposited and Cleared :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                'RowIndex += 1
                'For Each DTROW As DataRow In DT.Rows
                '    If Val(DTROW("DR")) <> 0 And IsDBNull(DTROW("RECODATE")) = False Then
                '        I += 1
                '        RowIndex += 1
                '        Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                '        Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                '        Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                '        Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                '        Write(DTROW("RECODATE"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                '        Write(DTROW("DR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                '    End If
                'Next

                'RowIndex += 1
                'Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                'FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                'SetBorder(RowIndex, Range("1"), Range("8"))



                'AS PER JEETU
                'GET ALL CREDIT AMOUNT
                'I = 0
                'RowIndex += 2
                'Write("Chques Issused and Presented :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                'RowIndex += 1
                'For Each DTROW As DataRow In DT.Rows
                '    If Val(DTROW("CR")) <> 0 And IsDBNull(DTROW("RECODATE")) = False Then
                '        I += 1
                '        RowIndex += 1
                '        Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                '        Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                '        Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                '        Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                '        Write(DTROW("RECODATE"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                '        Write(DTROW("CR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                '    End If
                'Next


                'RowIndex += 1
                'Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                'FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                'SetBorder(RowIndex, Range("1"), Range("8"))




                'GET ALL DEBIT AMOUNT
                I = 0
                RowIndex += 1
                Write("Chques Deposited but not Cleared :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                RowIndex += 1
                For Each DTROW As DataRow In DT.Rows

                    If Val(DTROW("DR")) <> 0 And IsDBNull(DTROW("RECODATE")) = True Then
                        I += 1
                        RowIndex += 1
                        Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                        Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(DTROW("DR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                    ElseIf Val(DTROW("DR")) <> 0 And IsDBNull(DTROW("RECODATE")) = False Then
                        If Convert.ToDateTime(DTROW("RECODATE")).Date > TODATE.Date Then
                            I += 1
                            RowIndex += 1
                            Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                            Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                            Write(DTROW("DR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                        End If
                    End If
                Next


                RowIndex += 1
                Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                SetBorder(RowIndex, Range("1"), Range("8"))



                'GET ALL CREDIT AMOUNT
                I = 0
                RowIndex += 2
                Write("Chques Issused but not Presented :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                RowIndex += 1
                For Each DTROW As DataRow In DT.Rows
                    If Val(DTROW("CR")) <> 0 And IsDBNull(DTROW("RECODATE")) = True Then
                        I += 1
                        RowIndex += 1
                        Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                        Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(DTROW("CR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                    ElseIf Val(DTROW("CR")) <> 0 And IsDBNull(DTROW("RECODATE")) = False Then
                        If Convert.ToDateTime(DTROW("RECODATE")).Date > TODATE.Date Then
                            I += 1
                            RowIndex += 1
                            Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                            Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                            Write(DTROW("CR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                        End If
                    End If
                Next


                RowIndex += 1
                Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                SetBorder(RowIndex, Range("1"), Range("8"))


                RowIndex += 2
                Write("Balance as Per Bank Book :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                Write(Format(Val(DTTOTAL.Rows(0).Item("BANKBAL")), "0.00") & "  " & DTTOTAL.Rows(0).Item("BANKDRCR"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)


                SetBorder(RowIndex, objColumn.Item("1").ToString & 9, objColumn.Item("1").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("2").ToString & 9, objColumn.Item("2").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("3").ToString & 9, objColumn.Item("4").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("6").ToString & 9, objColumn.Item("6").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("7").ToString & 9, objColumn.Item("7").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("8").ToString & 9, objColumn.Item("8").ToString & RowIndex)



                objBook.Application.ActiveWindow.Zoom = 95

                With objSheet.PageSetup
                    .Orientation = XlPageOrientation.xlPortrait
                    .TopMargin = 144
                    .LeftMargin = 50.4
                    .RightMargin = 0
                    .BottomMargin = 0
                    .Zoom = False
                    .FitToPagesTall = 1
                    .FitToPagesWide = 1
                End With

                SaveAndClose()

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function BANKSTATEMENT(ByVal NAME As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            Dim OBJRECO As New ClsBankReco
            Dim OBJCMN As New ClsCommon
            Dim ALPARAVAL As New ArrayList
            Dim I As Integer = 0
            Dim BALANCE As Double = 0

            Dim DT As System.Data.DataTable = OBJCMN.search("DISTINCT RecoDate AS RECODATE, acc_initials AS BILLINITIALS, AGAINST AS NAME, ChqNo AS CHQNO, dr AS DR, cr AS CR", "", " BANKRECO", " AND BANKRECO.NAME = '" & NAME & "' AND ACC_CMPID = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID & " AND CAST(RECODATE AS DATE) >= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND CAST(RECODATE AS DATE) <= '" & Format(TODATE, "MM/dd/yyyy") & "'  ORDER BY RECODATE")


            ALPARAVAL.Add(NAME)
            ALPARAVAL.Add(FROMDATE)
            ALPARAVAL.Add(TODATE)
            ALPARAVAL.Add(CMPID)
            ALPARAVAL.Add(LOCATIONID)
            ALPARAVAL.Add(YEARID)

            OBJRECO.alParaval = ALPARAVAL
            Dim DTTOTAL As System.Data.DataTable = OBJRECO.GETTOTAL
            If DT.Rows.Count > 0 Then

                SetWorkSheet()
                For I = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next


                RowIndex = 1
                For I = 1 To 26
                    SetColumnWidth(Range(I), 14)
                Next


                ' **************************** CMPHEADER *************************
                Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

                RowIndex = 2
                Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 14)
                SetBorder(RowIndex, Range("1"), Range("8"))

                'ADD1
                RowIndex += 1
                Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))

                'ADD2
                RowIndex += 1
                Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))




                'FREEZE TOP 7 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("8").ToString & 10).Select()
                objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("8").ToString & 10).Application.ActiveWindow.FreezePanes = True

                ' **************************** CMPHEADER *************************




                RowIndex += 2
                Write("Name : " & NAME, Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("Run Date : " & Now.Date, Range("6"), XlHAlign.xlHAlignLeft, Range("8"), False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))


                RowIndex += 1
                Write("Bank Statement from " & FROMDATE & " to " & TODATE, Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))


                'HEADERS
                RowIndex += 2
                Write("Date", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Booking No", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Name", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 10)
                Write("Chq No", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Debit", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Credit", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Balance", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)



                RowIndex += 2
                Write("Bank Balance as per Bank Pass Book", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                Write(Format(Val(DTTOTAL.Rows(0).Item("BOOKBAL")), "0.00") & "  " & DTTOTAL.Rows(0).Item("BOOKDRCR"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                BALANCE = Val(DTTOTAL.Rows(0).Item("BOOKBAL"))


                'GET ALL DEBIT AMOUNT
                I = 0
                Dim RDATE As Date = Now.Date
                Dim FROW As Boolean = True
                Dim FROMNO As Integer = 0
                RowIndex += 1
                For Each DTROW As DataRow In DT.Rows
                    I += 1
                    RowIndex += 1
                    'GET REOCDATE ONLY ONCE
                    If RDATE <> DTROW("RECODATE") Then
                        If FROW = False Then
                            RowIndex += 1
                            Write(DTROW("RECODATE"), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                            FORMULA("=SUM(" & objColumn.Item("6").ToString & FROMNO & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 12)
                            FORMULA("=SUM(" & objColumn.Item("7").ToString & FROMNO & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)

                            'SET BALANCE
                            BALANCE = (BALANCE + Val(objSheet.Range(Range("7"), Range("7")).Text)) - Val(objSheet.Range(Range("6"), Range("6")).Text)

                            Write(Format(BALANCE, "0.00"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                            SetBorder(RowIndex, Range("1"), Range("8"))
                        End If

                        RowIndex += 2
                        Write(DTROW("RECODATE"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        RDATE = DTROW("RECODATE")
                        'GET TOTAL OF THE PARTICULAR DATE IF NOT FIRST ROW

                        FROMNO = RowIndex
                    End If
                    Write(DTROW("BILLINITIALS"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                    Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(DTROW("DR"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(DTROW("CR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                    FROW = False
                Next


                RowIndex += 1
                Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                SetBorder(RowIndex, Range("1"), Range("8"))




                RowIndex += 2
                Write("Balance as Per Bank Book :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                Write(Format(Val(DTTOTAL.Rows(0).Item("BANKBAL")), "0.00") & "  " & DTTOTAL.Rows(0).Item("BANKDRCR"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)


                SetBorder(RowIndex, objColumn.Item("1").ToString & 9, objColumn.Item("1").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("2").ToString & 9, objColumn.Item("2").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("3").ToString & 9, objColumn.Item("4").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("6").ToString & 9, objColumn.Item("6").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("7").ToString & 9, objColumn.Item("7").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("8").ToString & 9, objColumn.Item("8").ToString & RowIndex)



                objBook.Application.ActiveWindow.Zoom = 95

                With objSheet.PageSetup
                    .Orientation = XlPageOrientation.xlPortrait
                    .TopMargin = 144
                    .LeftMargin = 50.4
                    .RightMargin = 0
                    .BottomMargin = 0
                    .Zoom = False
                    .FitToPagesTall = 1
                    .FitToPagesWide = 1
                End With

                SaveAndClose()

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "TDS REPORTS"

    Public Function TDSCHALLANDETAILS(ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next

            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            objSheet.Name = "CHALLAN DETAILS"
            SetColumnWidth(Range(8), 25)


            Dim OBJCMN As New ClsCommon
            'WE NEED TO GROUP
            'Dim DT As System.Data.DataTable = OBJCMN.search(" T.DATE, T.NAME, T.[BILLINITIALS], T.BILLAMT, T.TDSAMT, ISNULL(TDSCHALLAN.TDSCHA_CHALLANNO, '') AS CHALLANNO, TDSCHALLAN.TDSCHA_CHALLANDATE AS CHALLANDATE, ISNULL(TDSCHALLAN.TDSCHA_CHQNO, '') AS CHQNO, ISNULL(TDSCHALLAN.TDSCHA_BANKNAME, '') AS BANKNAME, ISNULL(ACCOUNTSMASTER_TDS.ACC_SECTION,'') AS SECTION   ", "", " (SELECT [DATE], NAME, BILLINITIALS, BILLAMT, TDSAMT, CHALLANNO, CHALLANDATE, CHQNO, BANKNAME, BILL, YEARID, TDSLEDGER FROM TDSCHALLANVIEW WHERE YEARID = " & YEARID & " AND DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "') AS T LEFT OUTER JOIN TDSCHALLAN ON T.YEARID = TDSCHALLAN.TDSCHA_YEARID AND T.[BILLINITIALS] = TDSCHALLAN.TDSCHA_BILLNO INNER JOIN ACCOUNTSMASTER ON ACC_CMPNAME = T.NAME AND ACCOUNTSMASTER.ACC_YEARID = T.YEARID LEFT OUTER JOIN ACCOUNTSMASTER_TDS ON ACCOUNTSMASTER.ACC_ID = ACCOUNTSMASTER_TDS.ACC_ID ", " AND ISNULL(TDSCHALLAN.TDSCHA_CHALLANNO, '') <> ''  ORDER BY T.BILL")
            Dim DT As System.Data.DataTable = OBJCMN.search(" SUM(T.TDSAMT) AS TDSAMT, ISNULL(TDSCHALLAN.TDSCHA_CHALLANNO, '') AS CHALLANNO, TDSCHALLAN.TDSCHA_CHALLANDATE AS CHALLANDATE, ISNULL(TDSCHALLAN.TDSCHA_CHQNO, '') AS CHQNO, ISNULL(TDSCHALLAN.TDSCHA_BANKNAME, '') AS BANKNAME, ISNULL(ACCOUNTSMASTER_TDS.ACC_SECTION,'') AS SECTION ", "", " (SELECT [DATE], NAME, BILLINITIALS, BILLAMT, TDSAMT, CHALLANNO, CHALLANDATE, CHQNO, BANKNAME, BILL, YEARID, TDSLEDGER FROM TDSCHALLANVIEW WHERE YEARID = " & YEARID & " AND DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "') AS T LEFT OUTER JOIN TDSCHALLAN ON T.YEARID = TDSCHALLAN.TDSCHA_YEARID AND T.[BILLINITIALS] = TDSCHALLAN.TDSCHA_BILLNO INNER JOIN ACCOUNTSMASTER ON ACC_CMPNAME = T.NAME AND ACCOUNTSMASTER.ACC_YEARID = T.YEARID LEFT OUTER JOIN ACCOUNTSMASTER_TDS ON ACCOUNTSMASTER.ACC_ID = ACCOUNTSMASTER_TDS.ACC_ID ", " AND ISNULL(TDSCHALLAN.TDSCHA_CHALLANNO, '') <> ''  GROUP BY ISNULL(TDSCHALLAN.TDSCHA_CHALLANNO, '') , TDSCHALLAN.TDSCHA_CHALLANDATE , ISNULL(TDSCHALLAN.TDSCHA_CHQNO, '') , ISNULL(TDSCHALLAN.TDSCHA_BANKNAME, '') , ISNULL(ACCOUNTSMASTER_TDS.ACC_SECTION,'') ORDER BY TDSCHALLAN.TDSCHA_CHALLANDATE ")

            RowIndex = 1
            objSheet.Range(Range("1"), Range("14")).Font.Color = RGB(255, 255, 255)

            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(255, 0, 0)
            Write("Challan Serial No. (401)", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10, True)
            SetBorder(RowIndex, Range("1"), Range("1"))


            objSheet.Range(Range("2"), Range("6")).Interior.Color = RGB(102, 102, 153)
            Write("Income Tax (402)", Range("2"), XlHAlign.xlHAlignCenter, Range("2"), True, 10, True)
            SetBorder(RowIndex, Range("2"), Range("2"))

            Write("Interest (403)", Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 10, True)
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write("Fees (404)", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 10, True)
            SetBorder(RowIndex, Range("4"), Range("4"))

            Write("Others/Penalty (405)", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 10, True)
            SetBorder(RowIndex, Range("5"), Range("5"))

            Write("Total Tax Deposited/ Book Adjustment (406)", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 10, True)
            SetBorder(RowIndex, Range("6"), Range("6"))



            objSheet.Range(Range("7"), Range("7")).Interior.Color = RGB(255, 0, 0)
            Write("Whether deposited by book Adjustment Yes/No (407)", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 10, True)
            SetBorder(RowIndex, Range("7"), Range("7"))



            objSheet.Range(Range("8"), Range("8")).Interior.Color = RGB(102, 102, 153)
            Write("BSR Code (408)", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 10, True)
            SetBorder(RowIndex, Range("8"), Range("8"))



            objSheet.Range(Range("9"), Range("10")).Interior.Color = RGB(255, 0, 0)
            Write("Date on which Tax Deposited/ Date of Transfer voucher (410)", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 10, True)
            SetBorder(RowIndex, Range("9"), Range("9"))

            Write("Challan Serial No./DDO Serial No. of Form no. 24G (409)", Range("10"), XlHAlign.xlHAlignCenter, Range("10"), True, 10, True)
            SetBorder(RowIndex, Range("10"), Range("10"))



            objSheet.Range(Range("11"), Range("11")).Interior.Color = RGB(102, 102, 153)
            Write("Receipt No. of form 24G (408)", Range("11"), XlHAlign.xlHAlignCenter, Range("11"), True, 10, True)
            SetBorder(RowIndex, Range("11"), Range("11"))



            objSheet.Range(Range("12"), Range("12")).Interior.Color = RGB(255, 0, 0)
            Write("Minor Head of Challan (411)", Range("12"), XlHAlign.xlHAlignCenter, Range("12"), True, 10, True)
            SetBorder(RowIndex, Range("12"), Range("12"))



            objSheet.Range(Range("13"), Range("14")).Interior.Color = RGB(102, 102, 153)
            Write("Cheque/DD No.", Range("13"), XlHAlign.xlHAlignCenter, Range("13"), True, 10, True)
            SetBorder(RowIndex, Range("13"), Range("13"))

            Write("Section Code For Own Record (It will be import in Remark)", Range("14"), XlHAlign.xlHAlignCenter, Range("14"), True, 10, True)
            SetBorder(RowIndex, Range("14"), Range("14"))



            Dim a As Integer = 1
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(a, Range("1"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DTROW("TDSAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                Write("", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("", Range("4"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("", Range("5"), XlHAlign.xlHAlignLeft, , True, 10)
                Write(Val(DTROW("TDSAMT")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
                Write("No", Range("7"), XlHAlign.xlHAlignLeft, , True, 10)
                Write(DTROW("BANKNAME"), Range("8"), XlHAlign.xlHAlignLeft, , True, 10)
                Write(Convert.ToDateTime(DTROW("CHALLANDATE")).Date, Range("9"), XlHAlign.xlHAlignRight, , True, 10)
                Write(DTROW("CHALLANNO"), Range("10"), XlHAlign.xlHAlignRight, , True, 10)
                Write("", Range("11"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("200", Range("12"), XlHAlign.xlHAlignRight, , True, 10)
                Write(DTROW("CHQNO"), Range("13"), XlHAlign.xlHAlignLeft, , True, 10)
                Write(DTROW("SECTION"), Range("14"), XlHAlign.xlHAlignLeft, , True, 10)
                SetBorder(RowIndex, Range("1"), Range("14"))
                a += 1
            Next

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 10
                .LeftMargin = 10
                .RightMargin = 10
                .BottomMargin = 10
                .CenterHorizontally = True
            End With

            objBook.Application.ActiveWindow.Zoom = 100
            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function TDSDEDUCTEEDETAILS(ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            objSheet.Name = "DEDUCTEE DETAILS"



            Dim OBJCMN As New ClsCommon
            Dim DT As System.Data.DataTable = OBJCMN.search(" ISNULL(ACCOUNTSMASTER_TDS.ACC_SECTION,'') AS SECTION, ACCOUNTSMASTER.Acc_panno AS PANNO,  T.NAME,T.DATE,  T.BILLAMT, CEILING((T.TDSAMT/ T.BILLAMT) * 100) AS TAXPER,  T.TDSAMT, ISNULL(area_name,'') AS AREANAME, ISNULL(CITY_NAME,'') AS CITYNAME, Acc_zipcode AS PIN, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(TDSCHALLAN.TDSCHA_CHALLANNO, '') AS CHALLANNO, TDSCHALLAN.TDSCHA_CHALLANDATE AS CHALLANDATE, ISNULL(TDSCHALLAN.TDSCHA_CHQNO, '') AS CHQNO, ISNULL(TDSCHALLAN.TDSCHA_BANKNAME, '') AS BANKNAME ", "", " (SELECT [DATE], NAME, BILLINITIALS, BILLAMT, TDSAMT, CHALLANNO, CHALLANDATE, CHQNO, BANKNAME, BILL, YEARID, TDSLEDGER FROM TDSCHALLANVIEW  WHERE YEARID = " & YEARID & " AND DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "') AS T  LEFT OUTER JOIN TDSCHALLAN ON T.YEARID = TDSCHALLAN.TDSCHA_YEARID AND T.[BILLINITIALS] = TDSCHALLAN.TDSCHA_BILLNO INNER JOIN ACCOUNTSMASTER ON ACC_CMPNAME = T.NAME AND ACCOUNTSMASTER.ACC_YEARID = T.YEARID LEFT OUTER JOIN ACCOUNTSMASTER_TDS ON ACCOUNTSMASTER.ACC_ID = ACCOUNTSMASTER_TDS.ACC_ID LEFT OUTER JOIN AREAMASTER ON Acc_areaid = area_id LEFT OUTER JOIN CITYMASTER ON Acc_cityid = city_id LEFT OUTER JOIN STATEMASTER ON Acc_stateid = state_id ", " AND ISNULL(TDSCHALLAN.TDSCHA_CHALLANNO, '') <> '' ORDER BY TDSCHALLAN.TDSCHA_CHALLANDATE, T.BILL")

            RowIndex = 1
            objSheet.Range(Range("1"), Range("23")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("2")).Interior.Color = RGB(255, 0, 0)
            Write("Challan Serial No.", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10, True)
            SetBorder(RowIndex, Range("1"), Range("1"))

            Write("Section Code", Range("2"), XlHAlign.xlHAlignCenter, Range("2"), True, 10, True)
            SetBorder(RowIndex, Range("2"), Range("2"))



            objSheet.Range(Range("3"), Range("5")).Interior.Color = RGB(102, 102, 153)
            Write("Type Of Rent", Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 10, True)
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write("PAN Reference No. (In case of No PAN)", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 10, True)
            SetBorder(RowIndex, Range("4"), Range("4"))

            Write("Deductee Reference no. If Available (413)", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 10, True)
            SetBorder(RowIndex, Range("5"), Range("5"))



            objSheet.Range(Range("6"), Range("11")).Interior.Color = RGB(255, 0, 0)
            Write("Deductee Code (414)", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 10, True)
            SetBorder(RowIndex, Range("6"), Range("6"))

            Write("Permanent Account Number (PAN) of deductee (415)", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 10, True)
            SetBorder(RowIndex, Range("7"), Range("7"))

            Write("Name of Deductee (416)", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 10, True)
            SetBorder(RowIndex, Range("8"), Range("8"))

            Write("Date on which Amount paid / credited (418)", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 10, True)
            SetBorder(RowIndex, Range("9"), Range("9"))

            Write("Date on which tax deducted (422)", Range("10"), XlHAlign.xlHAlignCenter, Range("10"), True, 10, True)
            SetBorder(RowIndex, Range("10"), Range("10"))

            Write("Amount of Payment (Rs.) (419)", Range("11"), XlHAlign.xlHAlignCenter, Range("11"), True, 10, True)
            SetBorder(RowIndex, Range("11"), Range("11"))



            objSheet.Range(Range("12"), Range("23")).Interior.Color = RGB(102, 102, 153)
            Write("Rate at which tax deducted (423)", Range("12"), XlHAlign.xlHAlignCenter, Range("12"), True, 10, True)
            SetBorder(RowIndex, Range("12"), Range("12"))

            Write("Amount of tax deducted", Range("13"), XlHAlign.xlHAlignCenter, Range("13"), True, 10, True)
            SetBorder(RowIndex, Range("13"), Range("13"))

            Write("Total Tax Deposited (421)", Range("14"), XlHAlign.xlHAlignCenter, Range("14"), True, 10, True)
            SetBorder(RowIndex, Range("14"), Range("14"))

            Write("Reason for Non-deduction / Lower Deduction, if any (424)", Range("15"), XlHAlign.xlHAlignCenter, Range("15"), True, 10, True)
            SetBorder(RowIndex, Range("15"), Range("15"))

            Write("Certificate No. u/s 197 issued by the AO for non deduction/ lower deduction (425)", Range("16"), XlHAlign.xlHAlignCenter, Range("16"), True, 10, True)
            SetBorder(RowIndex, Range("16"), Range("16"))

            Write("Deductee Flat No.", Range("17"), XlHAlign.xlHAlignCenter, Range("17"), True, 10, True)
            SetBorder(RowIndex, Range("17"), Range("17"))

            Write("Deductee Building Name", Range("18"), XlHAlign.xlHAlignCenter, Range("18"), True, 10, True)
            SetBorder(RowIndex, Range("18"), Range("18"))

            Write("Deductee Street Name", Range("19"), XlHAlign.xlHAlignCenter, Range("19"), True, 10, True)
            SetBorder(RowIndex, Range("19"), Range("19"))

            Write("Deductee Area", Range("20"), XlHAlign.xlHAlignCenter, Range("20"), True, 10, True)
            SetBorder(RowIndex, Range("20"), Range("20"))

            Write("Deductee City/Town", Range("21"), XlHAlign.xlHAlignCenter, Range("21"), True, 10, True)
            SetBorder(RowIndex, Range("21"), Range("21"))

            Write("Deductee PIN", Range("22"), XlHAlign.xlHAlignCenter, Range("22"), True, 10, True)
            SetBorder(RowIndex, Range("22"), Range("22"))

            Write("Deductee State", Range("23"), XlHAlign.xlHAlignCenter, Range("23"), True, 10, True)
            SetBorder(RowIndex, Range("23"), Range("23"))


            Dim a As Integer = 0
            Dim CNO As String = ""
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                If CNO <> DTROW("CHALLANNO") Then
                    a += 1
                    CNO = DTROW("CHALLANNO")
                End If
                Write(a, Range("1"), XlHAlign.xlHAlignRight, , True, 9)
                Write(DTROW("SECTION"), Range("2"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("3"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("4"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("5"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("6"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("PANNO"), Range("7"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("NAME"), Range("8"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("DATE"), Range("9"), XlHAlign.xlHAlignRight, , True, 9)
                Write(DTROW("DATE"), Range("10"), XlHAlign.xlHAlignRight, , True, 9)
                Write(Val(DTROW("BILLAMT")), Range("11"), XlHAlign.xlHAlignRight, , True, 9)
                Write(Val(DTROW("TAXPER")), Range("12"), XlHAlign.xlHAlignRight, , True, 9)
                Write(Val(DTROW("TDSAMT")), Range("13"), XlHAlign.xlHAlignRight, , True, 9)
                Write(Val(DTROW("TDSAMT")), Range("14"), XlHAlign.xlHAlignRight, , True, 9)
                Write("", Range("15"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("16"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("17"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("18"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("19"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("AREANAME"), Range("20"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("CITYNAME"), Range("21"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("PIN"), Range("22"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("STATENAME"), Range("23"), XlHAlign.xlHAlignLeft, , True, 9)
                SetBorder(RowIndex, Range("1"), Range("23"))
            Next

            With objSheet.PageSetup
                .Orientation = XlPageOrientation.xlLandscape
                .TopMargin = 10
                .LeftMargin = 10
                .RightMargin = 10
                .BottomMargin = 10
                .CenterHorizontally = True
            End With

            objBook.Application.ActiveWindow.Zoom = 100
            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

    Public Function SCHEDULING_EXCEL(ByVal TEMPSCHNO As Integer, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next

            For I As Integer = 27 To 52
                SetColumn(I, Chr(65) + Chr(64 + I - 26))
            Next


            RowIndex = 1
            For i As Integer = 1 To 27
                SetColumnWidth(Range(i), 10)
            Next

            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'MACHINTYPE
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" SCH_SCHEDULING AS SCHEDULING,SCH_SCHEDULEDONEBY AS SCHEDULINGDONEBY,SCH_DATE AS DATE,SCH_REMARKS AS REMARKS", "", " SCHEDULING", "  AND SCH_NO =" & TEMPSCHNO & " AND SCH_CMPID = " & CMPID)
            RowIndex = 1
            Write("MACHINE :- " + DTCMP.Rows(0).Item("SCHEDULING"), Range("1"), XlHAlign.xlHAlignCenter, Range("27"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("27"))

            RowIndex += 1
            Write("Operator :- " + DTCMP.Rows(0).Item("SCHEDULINGDONEBY"), Range("1"), XlHAlign.xlHAlignLeft, Range("7"), False, 14)
            SetBorder(RowIndex, Range("1"), Range("7"))

            Write("Binder :- ", Range("8"), XlHAlign.xlHAlignLeft, Range("11"), False, 14)
            SetBorder(RowIndex, Range("8"), Range("11"))

            Write("Date :- " + DTCMP.Rows(0).Item("DATE"), Range("12"), XlHAlign.xlHAlignCenter, Range("20"), False, 14)
            SetBorder(RowIndex, Range("12"), Range("20"))

            Write("Shift : 1st", Range("21"), XlHAlign.xlHAlignCenter, Range("27"), False, 14)
            SetBorder(RowIndex, Range("21"), Range("27"))


            RowIndex += 1
            Write("Sr No", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("Job No", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Client", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Job Card Qty", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Printed Qty", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Remaining Qty", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Job Description", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cut Sheet", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cut Size", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Full Sheet", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("GSM/Paper/Size", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Color 1", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Color 2", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Mode", Range("14"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("color1 Plates", Range("15"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("color2 Plates", Range("16"), XlHAlign.xlHAlignCenter, , True, 10)
            ' Write("Color1 type", Range("17"), XlHAlign.xlHAlignCenter, , True, 10)
            ' Write("Color2 type", Range("18"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Side", Range("17"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Pages", Range("18"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Fold", Range("19"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Imp", Range("20"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Done", Range("21"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Flim", Range("22"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Width", Range("23"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Length", Range("24"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Start Time", Range("25"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Finish Time", Range("26"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Remarks", Range("27"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, objColumn.Item("14").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("15").ToString & RowIndex, objColumn.Item("15").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("16").ToString & RowIndex, objColumn.Item("16").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("17").ToString & RowIndex, objColumn.Item("17").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("18").ToString & RowIndex, objColumn.Item("18").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("19").ToString & RowIndex, objColumn.Item("19").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("20").ToString & RowIndex, objColumn.Item("20").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("21").ToString & RowIndex, objColumn.Item("21").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("22").ToString & RowIndex, objColumn.Item("22").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("23").ToString & RowIndex, objColumn.Item("23").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("24").ToString & RowIndex, objColumn.Item("24").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("25").ToString & RowIndex, objColumn.Item("25").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("26").ToString & RowIndex, objColumn.Item("26").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("27").ToString & RowIndex, objColumn.Item("27").ToString & RowIndex)


            SetColumnWidth(Range("1"), 5)
            SetColumnWidth(Range("2"), 10)
            SetColumnWidth(Range("3"), 30)
            SetColumnWidth(Range("4"), 10)
            SetColumnWidth(Range("5"), 10)
            SetColumnWidth(Range("6"), 15)
            SetColumnWidth(Range("7"), 30)
            SetColumnWidth(Range("8"), 10)
            SetColumnWidth(Range("9"), 10)
            SetColumnWidth(Range("10"), 10)
            SetColumnWidth(Range("11"), 30)
            SetColumnWidth(Range("12"), 10)
            SetColumnWidth(Range("13"), 10)
            SetColumnWidth(Range("14"), 10)
            SetColumnWidth(Range("15"), 12)
            SetColumnWidth(Range("16"), 12)
            SetColumnWidth(Range("17"), 10)
            SetColumnWidth(Range("18"), 10)
            SetColumnWidth(Range("19"), 10)
            SetColumnWidth(Range("20"), 10)
            SetColumnWidth(Range("21"), 10)
            SetColumnWidth(Range("22"), 15)
            SetColumnWidth(Range("23"), 10)
            SetColumnWidth(Range("24"), 10)
            SetColumnWidth(Range("25"), 10)
            SetColumnWidth(Range("26"), 10)
            SetColumnWidth(Range("27"), 20)




            'RowIndex += 1
            DT = OBJCMN.search(" SCHEDULING_DESC.SCH_GRIDSRNO AS SRNO, SCHEDULING_DESC.SCH_JOBNO AS JOBNO, LEDGERS.Acc_cmpname AS NAME, SCHEDULING_DESC.SCH_JOBCARDQTY AS JOBCARDQTY, SCHEDULING_DESC.SCH_PRINTEDQTY AS PRINTEDQTY, SCHEDULING_DESC.SCH_REMAININGQTY AS REMAININGQTY, SCHEDULING_DESC.SCH_ITEMNAME AS ITEMNAME, SCHEDULING_DESC.SCH_CUTSHEET AS CUTSHEET, SCHEDULING_DESC.SCH_CUTSIZE AS CUTSIZE, SCHEDULING_DESC.SCH_FULLSHEET AS FULLSHEET, NONINVITEMMASTER.NONINV_NAME AS PAPER, SCHEDULING_DESC.SCH_COLOR1 AS COLOR1, SCHEDULING_DESC.SCH_COLOR2 AS COLOR2, SCHEDULING_DESC.SCH_COLOR1PLATES AS COLOR1PLATES, SCHEDULING_DESC.SCH_COLOR2PLATES AS COLOR2PLATES, SCHEDULING_DESC.SCH_COLOR1TYPE AS COLOR1TYPE, SCHEDULING_DESC.SCH_COLOR2TYPE AS COLOR2TYPE, SCHEDULING_DESC.SCH_MODE AS MODE, SCHEDULING_DESC.SCH_SIDE AS SIDE, SCHEDULING_DESC.SCH_IMP AS IMP, SCHEDULING_DESC.SCH_READYTIME AS READYTIME, SCHEDULING_DESC.SCH_FINISHTIME AS FINISHTIME , SCHEDULING_DESC.SCH_FLIM AS FLIM, SCHEDULING_DESC.SCH_WIDTH AS WIDTH, SCHEDULING_DESC.SCH_LENGTH AS LENGTH ", "", " SCHEDULING_DESC LEFT OUTER JOIN NONINVITEMMASTER ON SCHEDULING_DESC.SCH_NONINVITEMID = NONINVITEMMASTER.NONINV_ID LEFT OUTER JOIN LEDGERS ON SCHEDULING_DESC.SCH_CLIENTID = LEDGERS.Acc_id ", "  AND SCHEDULING_DESC.SCH_YEARID = " & YEARID & " AND SCHEDULING_DESC.SCH_NO = " & TEMPSCHNO & "  ORDER BY SCHEDULING_DESC.SCH_GRIDSRNO ")
            For Each DTROW As DataRow In DT.Rows

                RowIndex += 1
                Write(DTROW("SRNO"), Range("1"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("JOBNO"), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("JOBCARDQTY"), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("PRINTEDQTY"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("REMAININGQTY"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("ITEMNAME"), Range("7"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("CUTSHEET")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("CUTSIZE"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("FULLSHEET")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("PAPER"), Range("11"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("COLOR1")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("COLOR2")), Range("13"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("MODE"), Range("14"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("COLOR1PLATES")), Range("15"), XlHAlign.xlHAlignRight, , True, 10)
                Write(DTROW("COLOR2PLATES"), Range("16"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("SIDE"), Range("17"), XlHAlign.xlHAlignRight, , False, 10)
                '  Write(DTROW("PAGES"), Range("18"), XlHAlign.xlHAlignLeft, , False, 10)
                ' Write(DTROW("FOLD"), Range("19"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("IMP"), Range("20"), XlHAlign.xlHAlignRight, , False, 10)
                ' Write(DTROW("DONE"), Range("21"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("FLIM"), Range("22"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("WIDTH"), Range("23"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("LENGTH"), Range("24"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("READYTIME"), Range("25"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("FINISHTIME"), Range("26"), XlHAlign.xlHAlignRight, , False, 10)
                '   Write(Val(DTROW("REMARK")), Range("27"), XlHAlign.xlHAlignRight, , False, 10)


                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, objColumn.Item("14").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("15").ToString & RowIndex, objColumn.Item("15").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("16").ToString & RowIndex, objColumn.Item("16").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("17").ToString & RowIndex, objColumn.Item("17").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("18").ToString & RowIndex, objColumn.Item("18").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("19").ToString & RowIndex, objColumn.Item("19").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("20").ToString & RowIndex, objColumn.Item("20").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("21").ToString & RowIndex, objColumn.Item("21").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("22").ToString & RowIndex, objColumn.Item("22").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("23").ToString & RowIndex, objColumn.Item("23").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("24").ToString & RowIndex, objColumn.Item("24").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("25").ToString & RowIndex, objColumn.Item("25").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("26").ToString & RowIndex, objColumn.Item("26").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("27").ToString & RowIndex, objColumn.Item("27").ToString & RowIndex)




            Next

            RowIndex += 1
            Write("Total :", Range("3"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & "4" & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)



            RowIndex += 2
            Write("REMARKS :- " + DTCMP.Rows(0).Item("REMARKS"), Range("1"), XlHAlign.xlHAlignLeft, Range("27"), False, 10)
            ' SetBorder(RowIndex, Range("1"), Range("29"))



            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function
    Public Function PRODUCTION_EXCEL(ByVal TEMPRODNO As Integer, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next

            For I As Integer = 27 To 52
                SetColumn(I, Chr(65) + Chr(64 + I - 26))
            Next


            RowIndex = 1
            For i As Integer = 1 To 32
                SetColumnWidth(Range(i), 10)
            Next

            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'MACHINTYPE
            Dim DTCMP As System.Data.DataTable = OBJCMN.search("PRODUCTION.PROD_DATE AS DATE, PRODUCTION.PROD_PRODUCTIONDONEBY AS PRODUCTIONDONEBY, PRODUCTION.PROD_REMARKS AS REMARKS, PRODUCTION.PROD_MACHINE AS PRODUCTIONMACHINE, PRODUCTION.PROD_PRODUCTIONTYPE AS PRODUCTIONTYPE, PRODUCTION.PROD_TOPRODUCTIONTYPE AS TOPRODUCTIONTYPE, LEDGERS.Acc_cmpname AS OUTSOURCE", "", " PRODUCTION LEFT OUTER JOIN LEDGERS ON PRODUCTION.PROD_LEDGERID = LEDGERS.Acc_id", "  AND PROD_NO =" & TEMPRODNO & " AND PROD_CMPID = " & CMPID)

            RowIndex = 1
            Write("MACHINE :-  " + DTCMP.Rows(0).Item("PRODUCTIONMACHINE"), Range("1"), XlHAlign.xlHAlignCenter, Range("32"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("32"))
            'objSheet.Range(Range("1"), Range("29")).Interior.Color = RGB(255, 255, 255)

            'RowIndex += 2
            'Write("From Production:-  " + DTCMP.Rows(0).Item("PRODUCTIONTYPE"), Range("1"), XlHAlign.xlHAlignCenter, Range("29"), True, 14)
            'SetBorder(RowIndex, Range("1"), Range("29"))

            RowIndex += 2
            Write("Production:-  " + DTCMP.Rows(0).Item("TOPRODUCTIONTYPE"), Range("1"), XlHAlign.xlHAlignCenter, Range("32"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("32"))

            RowIndex += 1
            Write("Out Source:-  " + DTCMP.Rows(0).Item("OUTSOURCE"), Range("1"), XlHAlign.xlHAlignCenter, Range("32"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("32"))

            RowIndex += 1
            Write("Operator :- " + DTCMP.Rows(0).Item("PRODUCTIONDONEBY"), Range("1"), XlHAlign.xlHAlignCenter, Range("9"), False, 14)
            SetBorder(RowIndex, Range("1"), Range("9"))

            Write("Binder :- ", Range("9"), XlHAlign.xlHAlignLeft, Range("12"), False, 14)
            SetBorder(RowIndex, Range("9"), Range("12"))

            Write("Date :- " + DTCMP.Rows(0).Item("DATE"), Range("13"), XlHAlign.xlHAlignCenter, Range("22"), False, 14)
            SetBorder(RowIndex, Range("13"), Range("22"))

            Write("Shift : 1st", Range("23"), XlHAlign.xlHAlignCenter, Range("31"), False, 14)
            SetBorder(RowIndex, Range("23"), Range("31"))


            RowIndex += 1
            Write("Sr No", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("Job No", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Client", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Job Card Qty", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Produce Qty", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Extra Sheet", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Good Qty", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Wastage Qty", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Remaining Qty", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Job Description", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cut Sheet", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cut Size", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Full Sheet", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("GSM/Paper/Size", Range("14"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Color 1", Range("15"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Color 2", Range("16"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Mode", Range("17"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("color1 Plates", Range("18"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("color2 Plates", Range("19"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Color1 type", Range("20"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Color2 type", Range("21"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Side", Range("22"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Pages", Range("23"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Fold", Range("24"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Imp", Range("25"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Done", Range("26"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Flim", Range("27"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Width", Range("28"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Length", Range("29"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Start Time", Range("30"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Finish Time", Range("31"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Remarks", Range("32"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, objColumn.Item("14").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("15").ToString & RowIndex, objColumn.Item("15").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("16").ToString & RowIndex, objColumn.Item("16").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("17").ToString & RowIndex, objColumn.Item("17").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("18").ToString & RowIndex, objColumn.Item("18").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("19").ToString & RowIndex, objColumn.Item("19").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("20").ToString & RowIndex, objColumn.Item("20").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("21").ToString & RowIndex, objColumn.Item("21").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("22").ToString & RowIndex, objColumn.Item("22").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("23").ToString & RowIndex, objColumn.Item("23").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("24").ToString & RowIndex, objColumn.Item("24").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("25").ToString & RowIndex, objColumn.Item("25").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("26").ToString & RowIndex, objColumn.Item("26").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("27").ToString & RowIndex, objColumn.Item("27").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("28").ToString & RowIndex, objColumn.Item("28").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("29").ToString & RowIndex, objColumn.Item("29").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("30").ToString & RowIndex, objColumn.Item("30").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("31").ToString & RowIndex, objColumn.Item("31").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("32").ToString & RowIndex, objColumn.Item("32").ToString & RowIndex)



            SetColumnWidth(Range("1"), 5)
            SetColumnWidth(Range("2"), 10)
            SetColumnWidth(Range("3"), 30)
            SetColumnWidth(Range("4"), 10)
            SetColumnWidth(Range("5"), 10)
            SetColumnWidth(Range("6"), 10)
            SetColumnWidth(Range("7"), 10)
            SetColumnWidth(Range("8"), 10)
            SetColumnWidth(Range("9"), 15)
            SetColumnWidth(Range("10"), 30)
            SetColumnWidth(Range("11"), 10)
            SetColumnWidth(Range("12"), 10)
            SetColumnWidth(Range("13"), 10)
            SetColumnWidth(Range("14"), 30)
            SetColumnWidth(Range("15"), 10)
            SetColumnWidth(Range("16"), 10)
            SetColumnWidth(Range("17"), 10)
            SetColumnWidth(Range("18"), 12)
            SetColumnWidth(Range("19"), 12)
            SetColumnWidth(Range("20"), 15)
            SetColumnWidth(Range("21"), 15)
            SetColumnWidth(Range("22"), 10)
            SetColumnWidth(Range("23"), 10)
            SetColumnWidth(Range("24"), 10)
            SetColumnWidth(Range("25"), 10)
            SetColumnWidth(Range("26"), 10)
            SetColumnWidth(Range("27"), 15)
            SetColumnWidth(Range("28"), 10)
            SetColumnWidth(Range("29"), 10)
            SetColumnWidth(Range("30"), 10)
            SetColumnWidth(Range("31"), 10)
            SetColumnWidth(Range("32"), 20)
            SetColumnWidth(Range("32"), 20)





            'RowIndex += 1
            DT = OBJCMN.search(" PRODUCTION_DESC.PROD_GRIDSRNO AS SRNO, PRODUCTION_DESC.PROD_JOBNO AS JOBNO, LEDGERS.Acc_cmpname AS NAME, PRODUCTION_DESC.PROD_JOBCARDQTY AS JOBCARDQTY,  PRODUCTION_DESC.PROD_PRINTEDQTY AS PRINTEDQTY, PRODUCTION_DESC.PROD_REMAININGQTY AS REMAININGQTY, PRODUCTION_DESC.PROD_ITEMNAME AS ITEMNAME, PRODUCTION_DESC.PROD_CUTSHEET AS CUTSHEET, PRODUCTION_DESC.PROD_CUTSIZE AS CUTSIZE, PRODUCTION_DESC.PROD_FULLSHEET AS FULLSHEET, NONINVITEMMASTER.NONINV_NAME AS PAPER, PRODUCTION_DESC.PROD_COLOR1 AS COLOR1, PRODUCTION_DESC.PROD_COLOR2 AS COLOR2, PRODUCTION_DESC.PROD_MODE AS MODE, PRODUCTION_DESC.PROD_COLOR1PLATES AS COLOR1PLATES, PRODUCTION_DESC.PROD_COLOR2PLATES AS COLOR2PLATES, PRODUCTION_DESC.PROD_COLOR1TYPE AS COLOR1TYPE, PRODUCTION_DESC.PROD_COLOR2TYPE AS COLOR2TYPE, PRODUCTION_DESC.PROD_SIDE AS SIDE, PRODUCTION_DESC.PROD_IMP AS IMP, PRODUCTION_DESC.PROD_FLIM AS FLIM, PRODUCTION_DESC.PROD_WIDTH AS WIDTH, PRODUCTION_DESC.PROD_LENGTH AS LENGTH, PRODUCTION_DESC.PROD_FINISHTIME AS FINISHTIME, PRODUCTION_DESC.PROD_READYTIME AS READYTIME,PRODUCTION_DESC.PROD_GOODQTY AS GOODQTY,PRODUCTION_DESC.PROD_WASTAGE AS WASTAGEQTY , PRODUCTION_DESC.PROD_EXTRASHEET AS EXTRASHEETS ", "", " PRODUCTION_DESC LEFT OUTER JOIN NONINVITEMMASTER ON PRODUCTION_DESC.PROD_NONINVITEMID = NONINVITEMMASTER.NONINV_ID LEFT OUTER JOIN LEDGERS ON PRODUCTION_DESC.PROD_CLIENTID = LEDGERS.Acc_id ", "  AND PRODUCTION_DESC.PROD_YEARID = " & YEARID & " AND PRODUCTION_DESC.PROD_NO = " & TEMPRODNO & "  ORDER BY PRODUCTION_DESC.PROD_GRIDSRNO ")
            For Each DTROW As DataRow In DT.Rows

                RowIndex += 1
                Write(DTROW("SRNO"), Range("1"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("JOBNO"), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("JOBCARDQTY"), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("PRINTEDQTY"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("EXTRASHEETS"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("GOODQTY"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("WASTAGEQTY"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("REMAININGQTY"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("ITEMNAME"), Range("10"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("CUTSHEET")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("CUTSIZE"), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("FULLSHEET")), Range("13"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("PAPER"), Range("14"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("COLOR1")), Range("15"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("COLOR2")), Range("16"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("MODE"), Range("17"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("COLOR1PLATES")), Range("18"), XlHAlign.xlHAlignRight, , True, 10)
                Write(DTROW("COLOR2PLATES"), Range("19"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("COLOR1TYPE"), Range("20"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("COLOR2TYPE"), Range("21"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("SIDE"), Range("22"), XlHAlign.xlHAlignRight, , False, 10)
                '  Write(DTROW("PAGES"), Range("23"), XlHAlign.xlHAlignLeft, , False, 10)
                ' Write(DTROW("FOLD"), Range("24"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("IMP"), Range("25"), XlHAlign.xlHAlignRight, , False, 10)
                ' Write(DTROW("DONE"), Range("26"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("FLIM"), Range("27"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("WIDTH"), Range("28"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("LENGTH"), Range("29"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("READYTIME"), Range("30"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("FINISHTIME"), Range("31"), XlHAlign.xlHAlignRight, , False, 10)
                '   Write(Val(DTROW("REMARK")), Range("32"), XlHAlign.xlHAlignRight, , False, 10)


                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, objColumn.Item("14").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("15").ToString & RowIndex, objColumn.Item("15").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("16").ToString & RowIndex, objColumn.Item("16").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("17").ToString & RowIndex, objColumn.Item("17").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("18").ToString & RowIndex, objColumn.Item("18").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("19").ToString & RowIndex, objColumn.Item("19").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("20").ToString & RowIndex, objColumn.Item("20").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("21").ToString & RowIndex, objColumn.Item("21").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("22").ToString & RowIndex, objColumn.Item("22").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("23").ToString & RowIndex, objColumn.Item("23").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("24").ToString & RowIndex, objColumn.Item("24").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("25").ToString & RowIndex, objColumn.Item("25").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("26").ToString & RowIndex, objColumn.Item("26").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("27").ToString & RowIndex, objColumn.Item("27").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("28").ToString & RowIndex, objColumn.Item("28").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("29").ToString & RowIndex, objColumn.Item("29").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("30").ToString & RowIndex, objColumn.Item("30").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("31").ToString & RowIndex, objColumn.Item("31").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("32").ToString & RowIndex, objColumn.Item("32").ToString & RowIndex)





            Next

            RowIndex += 2
            Write("Total :", Range("3"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & "4" & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)

            FORMULA("=SUM(" & objColumn.Item("5").ToString & "4" & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 12)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)

            FORMULA("=SUM(" & objColumn.Item("6").ToString & "6" & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 12)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)

            FORMULA("=SUM(" & objColumn.Item("7").ToString & "7" & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)

            'FORMULA("=SUM(" & objColumn.Item("8").ToString & "8" & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
            'SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)

            'FORMULA("=SUM(" & objColumn.Item("9").ToString & "9" & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 12)
            'SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)



            RowIndex += 2
            Write("REMARKS :- " + DTCMP.Rows(0).Item("REMARKS"), Range("1"), XlHAlign.xlHAlignLeft, Range("32"), False, 10)
            ' SetBorder(RowIndex, Range("1"), Range("29"))



            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function


End Class
