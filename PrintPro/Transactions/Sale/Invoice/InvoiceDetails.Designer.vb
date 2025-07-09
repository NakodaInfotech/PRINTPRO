<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InvoiceDetails
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvoiceDetails))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMBPRINTLIST = New System.Windows.Forms.ComboBox()
        Me.cmbregister = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.GridInvoiceDetails = New DevExpress.XtraGrid.GridControl()
        Me.GridInvoice = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GINVNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSTIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATENAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTATECODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEWAYBILLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPROCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOTHERCHGSNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOTHERCHGSAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPAKAGINGCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSUBTOTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALTAXABLEAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALCGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALSGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALIGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTAXNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTAXAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEXTRACHGSNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEXTRACHGSAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GROUNDOFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRANDTOTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPAPER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRAIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQCDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRAPHIC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPHARMA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUPSNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GVISUAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOLOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GVARNISH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPERFORATION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSIZE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTICKER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GADHESIVE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFINAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPACKET = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHIPPER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLABEL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBATCH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQCHEAD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQCREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIRNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolEXCELSHEET = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PRINTTOOL = New System.Windows.Forms.ToolStripButton()
        Me.EXCELEXPORT = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GridInvoiceDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolEXCELSHEET.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.Color.White)
        Me.BlendPanel1.Controls.Add(Me.CMBPRINTLIST)
        Me.BlendPanel1.Controls.Add(Me.cmbregister)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.GridInvoiceDetails)
        Me.BlendPanel1.Controls.Add(Me.ToolEXCELSHEET)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMBPRINTLIST
        '
        Me.CMBPRINTLIST.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBPRINTLIST.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPRINTLIST.ForeColor = System.Drawing.Color.Black
        Me.CMBPRINTLIST.FormattingEnabled = True
        Me.CMBPRINTLIST.Items.AddRange(New Object() {"INVOICE", "QC Report", "Common COA", "COA Report - CIPLA", "IPCA COA Report", "SANDOZ COA Report", "FAMYCARE COA Report", "BIOCON COA Report", "ALKEM COA Report", "SUN COA Report", "SHALINA COA Report"})
        Me.CMBPRINTLIST.Location = New System.Drawing.Point(161, 2)
        Me.CMBPRINTLIST.Name = "CMBPRINTLIST"
        Me.CMBPRINTLIST.Size = New System.Drawing.Size(128, 22)
        Me.CMBPRINTLIST.TabIndex = 673
        '
        'cmbregister
        '
        Me.cmbregister.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbregister.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbregister.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbregister.FormattingEnabled = True
        Me.cmbregister.Items.AddRange(New Object() {""})
        Me.cmbregister.Location = New System.Drawing.Point(967, 34)
        Me.cmbregister.Name = "cmbregister"
        Me.cmbregister.Size = New System.Drawing.Size(255, 22)
        Me.cmbregister.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(910, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 14)
        Me.Label1.TabIndex = 672
        Me.Label1.Text = "Register"
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(534, 541)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 2
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.Location = New System.Drawing.Point(620, 541)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 3
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'GridInvoiceDetails
        '
        Me.GridInvoiceDetails.Location = New System.Drawing.Point(20, 62)
        Me.GridInvoiceDetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridInvoiceDetails.MainView = Me.GridInvoice
        Me.GridInvoiceDetails.Name = "GridInvoiceDetails"
        Me.GridInvoiceDetails.Size = New System.Drawing.Size(1202, 473)
        Me.GridInvoiceDetails.TabIndex = 1
        Me.GridInvoiceDetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridInvoice})
        '
        'GridInvoice
        '
        Me.GridInvoice.AppearancePrint.Preview.BackColor = System.Drawing.Color.White
        Me.GridInvoice.AppearancePrint.Preview.Options.UseBackColor = True
        Me.GridInvoice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GINVNO, Me.GNAME, Me.GGSTIN, Me.GCITY, Me.GSTATENAME, Me.GSTATECODE, Me.GDATE, Me.GPONO, Me.GEWAYBILLNO, Me.GITEMCODE, Me.GITEMNAME, Me.GQTY, Me.GAMT, Me.GPROCHGS, Me.GOTHERCHGSNAME, Me.GOTHERCHGSAMT, Me.GPAKAGINGCHGS, Me.GSUBTOTAL, Me.GTOTALTAXABLEAMT, Me.GTOTALCGSTAMT, Me.GTOTALSGSTAMT, Me.GTOTALIGSTAMT, Me.GTAXNAME, Me.GTAXAMT, Me.GEXTRACHGSNAME, Me.GEXTRACHGSAMT, Me.GROUNDOFF, Me.GGRANDTOTAL, Me.GPAPER, Me.GGSM, Me.GGRAIN, Me.GQCDATE, Me.GGRAPHIC, Me.GPHARMA, Me.GUPSNO, Me.GVISUAL, Me.GCOLOR, Me.GVARNISH, Me.GPERFORATION, Me.GDESIGN, Me.GSIZE, Me.GSTICKER, Me.GADHESIVE, Me.GFINAL, Me.GPACKET, Me.GSHIPPER, Me.GLABEL, Me.GBATCH, Me.GQCHEAD, Me.GQCREMARKS, Me.GIRNNO})
        Me.GridInvoice.GridControl = Me.GridInvoiceDetails
        Me.GridInvoice.Name = "GridInvoice"
        Me.GridInvoice.OptionsBehavior.Editable = False
        Me.GridInvoice.OptionsView.ColumnAutoWidth = False
        Me.GridInvoice.OptionsView.ShowAutoFilterRow = True
        Me.GridInvoice.OptionsView.ShowFooter = True
        Me.GridInvoice.PaintStyleName = "Skin"
        '
        'GINVNO
        '
        Me.GINVNO.Caption = "Sr No"
        Me.GINVNO.FieldName = "SRNO"
        Me.GINVNO.Name = "GINVNO"
        Me.GINVNO.Visible = True
        Me.GINVNO.VisibleIndex = 0
        Me.GINVNO.Width = 50
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 1
        Me.GNAME.Width = 200
        '
        'GGSTIN
        '
        Me.GGSTIN.Caption = "GSTIN"
        Me.GGSTIN.FieldName = "GSTIN"
        Me.GGSTIN.Name = "GGSTIN"
        Me.GGSTIN.Visible = True
        Me.GGSTIN.VisibleIndex = 2
        Me.GGSTIN.Width = 100
        '
        'GCITY
        '
        Me.GCITY.Caption = "City"
        Me.GCITY.FieldName = "CITY"
        Me.GCITY.Name = "GCITY"
        Me.GCITY.Visible = True
        Me.GCITY.VisibleIndex = 3
        Me.GCITY.Width = 100
        '
        'GSTATENAME
        '
        Me.GSTATENAME.Caption = "State"
        Me.GSTATENAME.FieldName = "STATENAME"
        Me.GSTATENAME.Name = "GSTATENAME"
        Me.GSTATENAME.Visible = True
        Me.GSTATENAME.VisibleIndex = 4
        '
        'GSTATECODE
        '
        Me.GSTATECODE.Caption = "Code"
        Me.GSTATECODE.FieldName = "STATECODE"
        Me.GSTATECODE.Name = "GSTATECODE"
        Me.GSTATECODE.Visible = True
        Me.GSTATECODE.VisibleIndex = 5
        Me.GSTATECODE.Width = 40
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 6
        '
        'GPONO
        '
        Me.GPONO.Caption = "P.O. No"
        Me.GPONO.FieldName = "PONO"
        Me.GPONO.Name = "GPONO"
        Me.GPONO.Visible = True
        Me.GPONO.VisibleIndex = 7
        Me.GPONO.Width = 200
        '
        'GEWAYBILLNO
        '
        Me.GEWAYBILLNO.Caption = "E Way Bill No."
        Me.GEWAYBILLNO.FieldName = "EWAYBILLNO"
        Me.GEWAYBILLNO.Name = "GEWAYBILLNO"
        Me.GEWAYBILLNO.Visible = True
        Me.GEWAYBILLNO.VisibleIndex = 8
        '
        'GITEMCODE
        '
        Me.GITEMCODE.Caption = "Item Code"
        Me.GITEMCODE.FieldName = "ITEMCODE"
        Me.GITEMCODE.Name = "GITEMCODE"
        Me.GITEMCODE.Visible = True
        Me.GITEMCODE.VisibleIndex = 9
        Me.GITEMCODE.Width = 100
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 10
        Me.GITEMNAME.Width = 200
        '
        'GQTY
        '
        Me.GQTY.Caption = "Qty"
        Me.GQTY.DisplayFormat.FormatString = "0"
        Me.GQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GQTY.FieldName = "QTY"
        Me.GQTY.Name = "GQTY"
        Me.GQTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GQTY.Visible = True
        Me.GQTY.VisibleIndex = 11
        Me.GQTY.Width = 60
        '
        'GAMT
        '
        Me.GAMT.Caption = "Amount"
        Me.GAMT.DisplayFormat.FormatString = "0.00"
        Me.GAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAMT.FieldName = "TOTALAMT"
        Me.GAMT.Name = "GAMT"
        Me.GAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AMT", "")})
        Me.GAMT.Visible = True
        Me.GAMT.VisibleIndex = 12
        '
        'GPROCHGS
        '
        Me.GPROCHGS.Caption = "Pro Chgs."
        Me.GPROCHGS.DisplayFormat.FormatString = "0.00"
        Me.GPROCHGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPROCHGS.FieldName = "PROCHGS"
        Me.GPROCHGS.Name = "GPROCHGS"
        Me.GPROCHGS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPROCHGS.Visible = True
        Me.GPROCHGS.VisibleIndex = 13
        '
        'GOTHERCHGSNAME
        '
        Me.GOTHERCHGSNAME.Caption = "Other Chgs Name"
        Me.GOTHERCHGSNAME.FieldName = "OTHERCHGSNAME"
        Me.GOTHERCHGSNAME.Name = "GOTHERCHGSNAME"
        Me.GOTHERCHGSNAME.Visible = True
        Me.GOTHERCHGSNAME.VisibleIndex = 14
        '
        'GOTHERCHGSAMT
        '
        Me.GOTHERCHGSAMT.Caption = "Other Chgs Amt"
        Me.GOTHERCHGSAMT.DisplayFormat.FormatString = "0.00"
        Me.GOTHERCHGSAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GOTHERCHGSAMT.FieldName = "OTHERCHGSAMT"
        Me.GOTHERCHGSAMT.Name = "GOTHERCHGSAMT"
        Me.GOTHERCHGSAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GOTHERCHGSAMT.Visible = True
        Me.GOTHERCHGSAMT.VisibleIndex = 15
        '
        'GPAKAGINGCHGS
        '
        Me.GPAKAGINGCHGS.Caption = "Packaging Chgs"
        Me.GPAKAGINGCHGS.FieldName = "PACKAGCHGS"
        Me.GPAKAGINGCHGS.Name = "GPAKAGINGCHGS"
        Me.GPAKAGINGCHGS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPAKAGINGCHGS.Visible = True
        Me.GPAKAGINGCHGS.VisibleIndex = 16
        '
        'GSUBTOTAL
        '
        Me.GSUBTOTAL.Caption = "Sub Total"
        Me.GSUBTOTAL.DisplayFormat.FormatString = "0.00"
        Me.GSUBTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSUBTOTAL.FieldName = "SUBTOTAL"
        Me.GSUBTOTAL.Name = "GSUBTOTAL"
        Me.GSUBTOTAL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSUBTOTAL.Visible = True
        Me.GSUBTOTAL.VisibleIndex = 17
        '
        'GTOTALTAXABLEAMT
        '
        Me.GTOTALTAXABLEAMT.Caption = "Total Taxable Amt."
        Me.GTOTALTAXABLEAMT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALTAXABLEAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALTAXABLEAMT.FieldName = "TOTALTAXABLEAMT"
        Me.GTOTALTAXABLEAMT.Name = "GTOTALTAXABLEAMT"
        Me.GTOTALTAXABLEAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALTAXABLEAMT.Visible = True
        Me.GTOTALTAXABLEAMT.VisibleIndex = 18
        Me.GTOTALTAXABLEAMT.Width = 80
        '
        'GTOTALCGSTAMT
        '
        Me.GTOTALCGSTAMT.Caption = "Total CGST Amt."
        Me.GTOTALCGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALCGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALCGSTAMT.FieldName = "TOTALCGSTAMT"
        Me.GTOTALCGSTAMT.Name = "GTOTALCGSTAMT"
        Me.GTOTALCGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALCGSTAMT.Visible = True
        Me.GTOTALCGSTAMT.VisibleIndex = 19
        '
        'GTOTALSGSTAMT
        '
        Me.GTOTALSGSTAMT.Caption = "Total SGST Amt."
        Me.GTOTALSGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALSGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALSGSTAMT.FieldName = "TOTALSGSTAMT"
        Me.GTOTALSGSTAMT.Name = "GTOTALSGSTAMT"
        Me.GTOTALSGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALSGSTAMT.Visible = True
        Me.GTOTALSGSTAMT.VisibleIndex = 20
        Me.GTOTALSGSTAMT.Width = 80
        '
        'GTOTALIGSTAMT
        '
        Me.GTOTALIGSTAMT.Caption = "Total IGST Amt."
        Me.GTOTALIGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GTOTALIGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALIGSTAMT.FieldName = "TOTALIGSTAMT"
        Me.GTOTALIGSTAMT.Name = "GTOTALIGSTAMT"
        Me.GTOTALIGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALIGSTAMT.Visible = True
        Me.GTOTALIGSTAMT.VisibleIndex = 21
        Me.GTOTALIGSTAMT.Width = 80
        '
        'GTAXNAME
        '
        Me.GTAXNAME.Caption = "Tax Name"
        Me.GTAXNAME.FieldName = "TAXNAME"
        Me.GTAXNAME.Name = "GTAXNAME"
        Me.GTAXNAME.Visible = True
        Me.GTAXNAME.VisibleIndex = 22
        '
        'GTAXAMT
        '
        Me.GTAXAMT.Caption = "Tax Amt"
        Me.GTAXAMT.DisplayFormat.FormatString = "0.00"
        Me.GTAXAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTAXAMT.FieldName = "TAXAMT"
        Me.GTAXAMT.Name = "GTAXAMT"
        Me.GTAXAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTAXAMT.Visible = True
        Me.GTAXAMT.VisibleIndex = 23
        '
        'GEXTRACHGSNAME
        '
        Me.GEXTRACHGSNAME.Caption = "Extra Chgs Name"
        Me.GEXTRACHGSNAME.FieldName = "EXTRACHGSNAME"
        Me.GEXTRACHGSNAME.Name = "GEXTRACHGSNAME"
        Me.GEXTRACHGSNAME.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GEXTRACHGSNAME.Visible = True
        Me.GEXTRACHGSNAME.VisibleIndex = 24
        '
        'GEXTRACHGSAMT
        '
        Me.GEXTRACHGSAMT.Caption = "Extra Chgs Amt"
        Me.GEXTRACHGSAMT.DisplayFormat.FormatString = "0.00"
        Me.GEXTRACHGSAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GEXTRACHGSAMT.FieldName = "EXTRACHGSAMT"
        Me.GEXTRACHGSAMT.Name = "GEXTRACHGSAMT"
        Me.GEXTRACHGSAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GEXTRACHGSAMT.Visible = True
        Me.GEXTRACHGSAMT.VisibleIndex = 25
        '
        'GROUNDOFF
        '
        Me.GROUNDOFF.Caption = "Round Off"
        Me.GROUNDOFF.DisplayFormat.FormatString = "0.00"
        Me.GROUNDOFF.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GROUNDOFF.FieldName = "ROUNDOFF"
        Me.GROUNDOFF.Name = "GROUNDOFF"
        Me.GROUNDOFF.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GROUNDOFF.Visible = True
        Me.GROUNDOFF.VisibleIndex = 26
        '
        'GGRANDTOTAL
        '
        Me.GGRANDTOTAL.Caption = "Grand Total"
        Me.GGRANDTOTAL.DisplayFormat.FormatString = "0.00"
        Me.GGRANDTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GGRANDTOTAL.FieldName = "GRANDTOTAL"
        Me.GGRANDTOTAL.Name = "GGRANDTOTAL"
        Me.GGRANDTOTAL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GGRANDTOTAL.Visible = True
        Me.GGRANDTOTAL.VisibleIndex = 27
        '
        'GPAPER
        '
        Me.GPAPER.Caption = "Used Paper Material"
        Me.GPAPER.FieldName = "PAPER"
        Me.GPAPER.Name = "GPAPER"
        Me.GPAPER.Visible = True
        Me.GPAPER.VisibleIndex = 28
        '
        'GGSM
        '
        Me.GGSM.Caption = "Paper GSM"
        Me.GGSM.FieldName = "GSM"
        Me.GGSM.Name = "GGSM"
        Me.GGSM.Visible = True
        Me.GGSM.VisibleIndex = 29
        '
        'GGRAIN
        '
        Me.GGRAIN.Caption = "Grain Direction"
        Me.GGRAIN.FieldName = "GRAIN"
        Me.GGRAIN.Name = "GGRAIN"
        Me.GGRAIN.Visible = True
        Me.GGRAIN.VisibleIndex = 30
        '
        'GQCDATE
        '
        Me.GQCDATE.Caption = "QC Date"
        Me.GQCDATE.FieldName = "QCDATE"
        Me.GQCDATE.Name = "GQCDATE"
        Me.GQCDATE.Visible = True
        Me.GQCDATE.VisibleIndex = 31
        '
        'GGRAPHIC
        '
        Me.GGRAPHIC.Caption = "Graphic"
        Me.GGRAPHIC.FieldName = "TEXT"
        Me.GGRAPHIC.Name = "GGRAPHIC"
        Me.GGRAPHIC.Visible = True
        Me.GGRAPHIC.VisibleIndex = 32
        '
        'GPHARMA
        '
        Me.GPHARMA.Caption = "Pharma Code"
        Me.GPHARMA.FieldName = "PHARMA"
        Me.GPHARMA.Name = "GPHARMA"
        Me.GPHARMA.Visible = True
        Me.GPHARMA.VisibleIndex = 33
        '
        'GUPSNO
        '
        Me.GUPSNO.Caption = "Ups No"
        Me.GUPSNO.FieldName = "UPSNO"
        Me.GUPSNO.Name = "GUPSNO"
        Me.GUPSNO.Visible = True
        Me.GUPSNO.VisibleIndex = 34
        '
        'GVISUAL
        '
        Me.GVISUAL.Caption = "Visual Defects"
        Me.GVISUAL.FieldName = "VISUAL"
        Me.GVISUAL.Name = "GVISUAL"
        Me.GVISUAL.Visible = True
        Me.GVISUAL.VisibleIndex = 35
        '
        'GCOLOR
        '
        Me.GCOLOR.Caption = "Color Shade"
        Me.GCOLOR.FieldName = "COLOR"
        Me.GCOLOR.Name = "GCOLOR"
        Me.GCOLOR.Visible = True
        Me.GCOLOR.VisibleIndex = 36
        '
        'GVARNISH
        '
        Me.GVARNISH.Caption = "varnish"
        Me.GVARNISH.FieldName = "VARNISH"
        Me.GVARNISH.Name = "GVARNISH"
        Me.GVARNISH.Visible = True
        Me.GVARNISH.VisibleIndex = 37
        '
        'GPERFORATION
        '
        Me.GPERFORATION.Caption = "Perforation"
        Me.GPERFORATION.FieldName = "PERFORATION"
        Me.GPERFORATION.Name = "GPERFORATION"
        Me.GPERFORATION.Visible = True
        Me.GPERFORATION.VisibleIndex = 38
        '
        'GDESIGN
        '
        Me.GDESIGN.Caption = "Design"
        Me.GDESIGN.FieldName = "DESIGN"
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.Visible = True
        Me.GDESIGN.VisibleIndex = 39
        '
        'GSIZE
        '
        Me.GSIZE.Caption = "Size"
        Me.GSIZE.FieldName = "SIZE"
        Me.GSIZE.Name = "GSIZE"
        Me.GSIZE.Visible = True
        Me.GSIZE.VisibleIndex = 40
        '
        'GSTICKER
        '
        Me.GSTICKER.Caption = "Sticker"
        Me.GSTICKER.FieldName = "STICKER"
        Me.GSTICKER.Name = "GSTICKER"
        Me.GSTICKER.Visible = True
        Me.GSTICKER.VisibleIndex = 41
        '
        'GADHESIVE
        '
        Me.GADHESIVE.Caption = "Adhesive"
        Me.GADHESIVE.FieldName = "ADHESIVE"
        Me.GADHESIVE.Name = "GADHESIVE"
        Me.GADHESIVE.Visible = True
        Me.GADHESIVE.VisibleIndex = 42
        '
        'GFINAL
        '
        Me.GFINAL.Caption = "Final Quantity"
        Me.GFINAL.FieldName = "FINAL"
        Me.GFINAL.Name = "GFINAL"
        Me.GFINAL.Visible = True
        Me.GFINAL.VisibleIndex = 43
        '
        'GPACKET
        '
        Me.GPACKET.Caption = "Packet Status"
        Me.GPACKET.FieldName = "PACKET"
        Me.GPACKET.Name = "GPACKET"
        Me.GPACKET.Visible = True
        Me.GPACKET.VisibleIndex = 44
        '
        'GSHIPPER
        '
        Me.GSHIPPER.Caption = "Shipper Status"
        Me.GSHIPPER.FieldName = "SHIPPER"
        Me.GSHIPPER.Name = "GSHIPPER"
        Me.GSHIPPER.Visible = True
        Me.GSHIPPER.VisibleIndex = 45
        Me.GSHIPPER.Width = 85
        '
        'GLABEL
        '
        Me.GLABEL.Caption = "Label Status"
        Me.GLABEL.FieldName = "LABEL"
        Me.GLABEL.Name = "GLABEL"
        Me.GLABEL.Visible = True
        Me.GLABEL.VisibleIndex = 46
        '
        'GBATCH
        '
        Me.GBATCH.Caption = "Batch"
        Me.GBATCH.FieldName = "BATCH"
        Me.GBATCH.Name = "GBATCH"
        Me.GBATCH.Visible = True
        Me.GBATCH.VisibleIndex = 47
        '
        'GQCHEAD
        '
        Me.GQCHEAD.Caption = "QC Head"
        Me.GQCHEAD.FieldName = "QCHEAD"
        Me.GQCHEAD.Name = "GQCHEAD"
        Me.GQCHEAD.Visible = True
        Me.GQCHEAD.VisibleIndex = 48
        '
        'GQCREMARKS
        '
        Me.GQCREMARKS.Caption = "Remarks"
        Me.GQCREMARKS.FieldName = "QCREMARKS"
        Me.GQCREMARKS.Name = "GQCREMARKS"
        Me.GQCREMARKS.Visible = True
        Me.GQCREMARKS.VisibleIndex = 49
        Me.GQCREMARKS.Width = 100
        '
        'GIRNNO
        '
        Me.GIRNNO.Caption = "IRN No"
        Me.GIRNNO.FieldName = "IRNNO"
        Me.GIRNNO.Name = "GIRNNO"
        Me.GIRNNO.Visible = True
        Me.GIRNNO.VisibleIndex = 50
        Me.GIRNNO.Width = 80
        '
        'ToolEXCELSHEET
        '
        Me.ToolEXCELSHEET.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.PRINTTOOL, Me.EXCELEXPORT, Me.ToolStripSeparator1, Me.ToolStripRefresh, Me.ToolStripSeparator2})
        Me.ToolEXCELSHEET.Location = New System.Drawing.Point(0, 0)
        Me.ToolEXCELSHEET.Name = "ToolEXCELSHEET"
        Me.ToolEXCELSHEET.Size = New System.Drawing.Size(1234, 25)
        Me.ToolEXCELSHEET.TabIndex = 258
        Me.ToolEXCELSHEET.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripButton1.Text = "Add New"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'PRINTTOOL
        '
        Me.PRINTTOOL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PRINTTOOL.Image = CType(resources.GetObject("PRINTTOOL.Image"), System.Drawing.Image)
        Me.PRINTTOOL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PRINTTOOL.Name = "PRINTTOOL"
        Me.PRINTTOOL.Size = New System.Drawing.Size(23, 22)
        Me.PRINTTOOL.Text = "&Print"
        '
        'EXCELEXPORT
        '
        Me.EXCELEXPORT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EXCELEXPORT.Image = Global.PrintPro.My.Resources.Resources.Excel_icon
        Me.EXCELEXPORT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EXCELEXPORT.Name = "EXCELEXPORT"
        Me.EXCELEXPORT.Size = New System.Drawing.Size(23, 22)
        Me.EXCELEXPORT.Text = "&Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripRefresh
        '
        Me.ToolStripRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripRefresh.Image = Global.PrintPro.My.Resources.Resources.refresh1
        Me.ToolStripRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripRefresh.Name = "ToolStripRefresh"
        Me.ToolStripRefresh.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripRefresh.Text = "&Refresh"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'InvoiceDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "InvoiceDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Invoice Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GridInvoiceDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolEXCELSHEET.ResumeLayout(False)
        Me.ToolEXCELSHEET.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents ToolEXCELSHEET As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GridInvoiceDetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridInvoice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GINVNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmbregister As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EXCELEXPORT As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GITEMCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMBPRINTLIST As System.Windows.Forms.ComboBox
    Friend WithEvents PRINTTOOL As System.Windows.Forms.ToolStripButton
    Friend WithEvents GPROCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOTHERCHGSNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPAKAGINGCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSUBTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEXTRACHGSNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEXTRACHGSAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GROUNDOFF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOTHERCHGSAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRANDTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSTIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATENAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTATECODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALTAXABLEAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALCGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALSGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALIGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEWAYBILLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPAPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRAIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQCDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRAPHIC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPHARMA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUPSNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVISUAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOLOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVARNISH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPERFORATION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSIZE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTICKER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GADHESIVE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFINAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPACKET As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHIPPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLABEL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBATCH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQCHEAD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQCREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIRNNO As DevExpress.XtraGrid.Columns.GridColumn
End Class
