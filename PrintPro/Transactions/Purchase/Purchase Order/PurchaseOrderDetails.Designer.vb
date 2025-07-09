<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseOrderDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PurchaseOrderDetails))
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EXCELEXPORT = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolEXCELSHEET = New System.Windows.Forms.ToolStrip()
        Me.TOOLMAIL = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLGRIDDETAILS = New System.Windows.Forms.ToolStripButton()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridInvoice = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDELDAYS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDELDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHEETSPERREAM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GVERIFIED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridPODetails = New DevExpress.XtraGrid.GridControl()
        Me.CMDADD = New System.Windows.Forms.Button()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTCOPIES = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTTO = New System.Windows.Forms.TextBox()
        Me.TXTFROM = New System.Windows.Forms.TextBox()
        Me.PRINTDOC = New System.Drawing.Printing.PrintDocument()
        Me.PRINTDIALOG = New System.Windows.Forms.PrintDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ToolEXCELSHEET.SuspendLayout()
        CType(Me.GridInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridPODetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ToolEXCELSHEET
        '
        Me.ToolEXCELSHEET.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator, Me.EXCELEXPORT, Me.ToolStripSeparator1, Me.TOOLMAIL, Me.PrintToolStripButton, Me.ToolStripSeparator2, Me.ToolStripRefresh, Me.ToolStripSeparator3, Me.TOOLGRIDDETAILS})
        Me.ToolEXCELSHEET.Location = New System.Drawing.Point(0, 0)
        Me.ToolEXCELSHEET.Name = "ToolEXCELSHEET"
        Me.ToolEXCELSHEET.Size = New System.Drawing.Size(1234, 25)
        Me.ToolEXCELSHEET.TabIndex = 258
        Me.ToolEXCELSHEET.Text = "ToolStrip1"
        '
        'TOOLMAIL
        '
        Me.TOOLMAIL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLMAIL.Image = Global.PrintPro.My.Resources.Resources.MAIL_IMAGE1
        Me.TOOLMAIL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLMAIL.Name = "TOOLMAIL"
        Me.TOOLMAIL.Size = New System.Drawing.Size(23, 22)
        Me.TOOLMAIL.Text = "Mail Invoice Directly"
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'ToolStripRefresh
        '
        Me.ToolStripRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripRefresh.Image = Global.PrintPro.My.Resources.Resources.refresh1
        Me.ToolStripRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripRefresh.Name = "ToolStripRefresh"
        Me.ToolStripRefresh.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripRefresh.Text = "ToolStripButton2"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLGRIDDETAILS
        '
        Me.TOOLGRIDDETAILS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOOLGRIDDETAILS.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLGRIDDETAILS.Name = "TOOLGRIDDETAILS"
        Me.TOOLGRIDDETAILS.Size = New System.Drawing.Size(77, 22)
        Me.TOOLGRIDDETAILS.Text = "Grid Details"
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 3
        Me.GNAME.Width = 200
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.OptionsColumn.AllowEdit = False
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 2
        Me.GDATE.Width = 90
        '
        'GPONO
        '
        Me.GPONO.Caption = "P.O. No."
        Me.GPONO.FieldName = "PONO"
        Me.GPONO.Name = "GPONO"
        Me.GPONO.OptionsColumn.AllowEdit = False
        Me.GPONO.Visible = True
        Me.GPONO.VisibleIndex = 1
        '
        'GridInvoice
        '
        Me.GridInvoice.AppearancePrint.Preview.BackColor = System.Drawing.Color.White
        Me.GridInvoice.AppearancePrint.Preview.Options.UseBackColor = True
        Me.GridInvoice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GPONO, Me.GDATE, Me.GNAME, Me.GDELDAYS, Me.GDELDATE, Me.GSHEETSPERREAM, Me.GTOTALQTY, Me.GTOTALAMT, Me.GREMARKS, Me.GVERIFIED})
        Me.GridInvoice.GridControl = Me.GridPODetails
        Me.GridInvoice.Name = "GridInvoice"
        Me.GridInvoice.OptionsView.ColumnAutoWidth = False
        Me.GridInvoice.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GridInvoice.OptionsView.ShowAutoFilterRow = True
        Me.GridInvoice.OptionsView.ShowFooter = True
        Me.GridInvoice.PaintStyleName = "Skin"
        '
        'GCHK
        '
        Me.GCHK.Caption = "Chk"
        Me.GCHK.FieldName = "CHK"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.Visible = True
        Me.GCHK.VisibleIndex = 0
        Me.GCHK.Width = 30
        '
        'GDELDAYS
        '
        Me.GDELDAYS.Caption = "Del Days"
        Me.GDELDAYS.FieldName = "DELDAYS"
        Me.GDELDAYS.Name = "GDELDAYS"
        Me.GDELDAYS.OptionsColumn.AllowEdit = False
        Me.GDELDAYS.Visible = True
        Me.GDELDAYS.VisibleIndex = 4
        '
        'GDELDATE
        '
        Me.GDELDATE.Caption = "Del Date"
        Me.GDELDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDELDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDELDATE.FieldName = "DELDATE"
        Me.GDELDATE.Name = "GDELDATE"
        Me.GDELDATE.OptionsColumn.AllowEdit = False
        Me.GDELDATE.Visible = True
        Me.GDELDATE.VisibleIndex = 5
        Me.GDELDATE.Width = 90
        '
        'GSHEETSPERREAM
        '
        Me.GSHEETSPERREAM.Caption = "Sheets / Ream"
        Me.GSHEETSPERREAM.FieldName = "SHEETSPERREAM"
        Me.GSHEETSPERREAM.Name = "GSHEETSPERREAM"
        Me.GSHEETSPERREAM.OptionsColumn.AllowEdit = False
        Me.GSHEETSPERREAM.Visible = True
        Me.GSHEETSPERREAM.VisibleIndex = 6
        Me.GSHEETSPERREAM.Width = 100
        '
        'GTOTALQTY
        '
        Me.GTOTALQTY.Caption = "Total Qty"
        Me.GTOTALQTY.FieldName = "TOTALQTY"
        Me.GTOTALQTY.Name = "GTOTALQTY"
        Me.GTOTALQTY.OptionsColumn.AllowEdit = False
        Me.GTOTALQTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALQTY.Visible = True
        Me.GTOTALQTY.VisibleIndex = 7
        Me.GTOTALQTY.Width = 100
        '
        'GTOTALAMT
        '
        Me.GTOTALAMT.Caption = "Total Amt"
        Me.GTOTALAMT.FieldName = "TOTALAMT"
        Me.GTOTALAMT.Name = "GTOTALAMT"
        Me.GTOTALAMT.OptionsColumn.AllowEdit = False
        Me.GTOTALAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALAMT.Visible = True
        Me.GTOTALAMT.VisibleIndex = 8
        Me.GTOTALAMT.Width = 100
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.OptionsColumn.AllowEdit = False
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 9
        Me.GREMARKS.Width = 200
        '
        'GVERIFIED
        '
        Me.GVERIFIED.Caption = "Verified"
        Me.GVERIFIED.FieldName = "VERIFIED"
        Me.GVERIFIED.Name = "GVERIFIED"
        Me.GVERIFIED.OptionsColumn.AllowEdit = False
        Me.GVERIFIED.Visible = True
        Me.GVERIFIED.VisibleIndex = 10
        '
        'GridPODetails
        '
        Me.GridPODetails.Location = New System.Drawing.Point(12, 34)
        Me.GridPODetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridPODetails.MainView = Me.GridInvoice
        Me.GridPODetails.Name = "GridPODetails"
        Me.GridPODetails.Size = New System.Drawing.Size(1210, 491)
        Me.GridPODetails.TabIndex = 1
        Me.GridPODetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridInvoice})
        '
        'CMDADD
        '
        Me.CMDADD.BackColor = System.Drawing.Color.Transparent
        Me.CMDADD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDADD.FlatAppearance.BorderSize = 0
        Me.CMDADD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDADD.ForeColor = System.Drawing.Color.Black
        Me.CMDADD.Location = New System.Drawing.Point(513, 539)
        Me.CMDADD.Name = "CMDADD"
        Me.CMDADD.Size = New System.Drawing.Size(80, 28)
        Me.CMDADD.TabIndex = 674
        Me.CMDADD.Text = "&Add New"
        Me.CMDADD.UseVisualStyleBackColor = False
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(599, 539)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 2
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.Location = New System.Drawing.Point(685, 539)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 3
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.Color.White)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.Label22)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTCOPIES)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.TXTTO)
        Me.BlendPanel1.Controls.Add(Me.TXTFROM)
        Me.BlendPanel1.Controls.Add(Me.CMDADD)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.GridPODetails)
        Me.BlendPanel1.Controls.Add(Me.ToolEXCELSHEET)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(398, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 14)
        Me.Label4.TabIndex = 901
        Me.Label4.Text = "Copies"
        '
        'TXTCOPIES
        '
        Me.TXTCOPIES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOPIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOPIES.Location = New System.Drawing.Point(448, 2)
        Me.TXTCOPIES.Name = "TXTCOPIES"
        Me.TXTCOPIES.Size = New System.Drawing.Size(29, 22)
        Me.TXTCOPIES.TabIndex = 900
        Me.TXTCOPIES.Text = "1"
        Me.TXTCOPIES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(310, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(19, 14)
        Me.Label9.TabIndex = 899
        Me.Label9.Text = "To"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(204, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 14)
        Me.Label10.TabIndex = 898
        Me.Label10.Text = "From"
        '
        'TXTTO
        '
        Me.TXTTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTO.Location = New System.Drawing.Point(335, 2)
        Me.TXTTO.Name = "TXTTO"
        Me.TXTTO.Size = New System.Drawing.Size(57, 22)
        Me.TXTTO.TabIndex = 897
        Me.TXTTO.TabStop = False
        Me.TXTTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTFROM
        '
        Me.TXTFROM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTFROM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFROM.Location = New System.Drawing.Point(244, 2)
        Me.TXTFROM.Name = "TXTFROM"
        Me.TXTFROM.Size = New System.Drawing.Size(57, 22)
        Me.TXTFROM.TabIndex = 896
        Me.TXTFROM.TabStop = False
        Me.TXTFROM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PRINTDIALOG
        '
        Me.PRINTDIALOG.AllowSelection = True
        Me.PRINTDIALOG.AllowSomePages = True
        Me.PRINTDIALOG.ShowHelp = True
        Me.PRINTDIALOG.UseEXDialog = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(1157, 539)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 14)
        Me.Label1.TabIndex = 814
        Me.Label1.Text = "PO Verified"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Location = New System.Drawing.Point(1133, 538)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(18, 17)
        Me.Label22.TabIndex = 813
        Me.Label22.Text = "   "
        '
        'PurchaseOrderDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PurchaseOrderDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Purchase Order Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolEXCELSHEET.ResumeLayout(False)
        Me.ToolEXCELSHEET.PerformLayout()
        CType(Me.GridInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridPODetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents EXCELEXPORT As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents ToolEXCELSHEET As ToolStrip
    Friend WithEvents ToolStripRefresh As ToolStripButton
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridInvoice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridPODetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents CMDADD As Button
    Friend WithEvents CMDOK As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents GDELDAYS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDELDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHEETSPERREAM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TOOLGRIDDETAILS As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TOOLMAIL As ToolStripButton
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents Label4 As Label
    Friend WithEvents TXTCOPIES As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TXTTO As TextBox
    Friend WithEvents TXTFROM As TextBox
    Friend WithEvents PRINTDOC As Printing.PrintDocument
    Friend WithEvents PRINTDIALOG As PrintDialog
    Friend WithEvents GVERIFIED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents Label22 As Label
End Class
