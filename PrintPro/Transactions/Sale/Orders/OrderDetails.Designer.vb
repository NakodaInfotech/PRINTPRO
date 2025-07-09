<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrderDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OrderDetails))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TOOLADDNEW = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.GridOrderDetails = New DevExpress.XtraGrid.GridControl()
        Me.GridOrder = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GORDERNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHIPTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gpono = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPODATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHADECARD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMULTIUPS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPOSNEG = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDELDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTotalQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GASSEMBLYQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDELIVERYQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALDELQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTotalAmt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCLOSED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOUTQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSCHDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.GridOrderDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.Color.White)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.Label14)
        Me.BlendPanel1.Controls.Add(Me.Label15)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.GridOrderDetails)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(159, 523)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 14)
        Me.Label1.TabIndex = 657
        Me.Label1.Text = "Closed Orders"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(137, 522)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 17)
        Me.Label2.TabIndex = 656
        Me.Label2.Text = "   "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(40, 523)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 14)
        Me.Label14.TabIndex = 655
        Me.Label14.Text = "Locked Orders"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Location = New System.Drawing.Point(18, 522)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(18, 17)
        Me.Label15.TabIndex = 654
        Me.Label15.Text = "   "
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TOOLADDNEW, Me.toolStripSeparator, Me.PrintToolStripButton, Me.ToolStripSeparator1, Me.ToolStripRefresh, Me.ToolStripSeparator2, Me.ToolStripButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 256
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TOOLADDNEW
        '
        Me.TOOLADDNEW.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TOOLADDNEW.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLADDNEW.Name = "TOOLADDNEW"
        Me.TOOLADDNEW.Size = New System.Drawing.Size(55, 22)
        Me.TOOLADDNEW.Text = "Add New"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripRefresh
        '
        Me.ToolStripRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripRefresh.Image = CType(resources.GetObject("ToolStripRefresh.Image"), System.Drawing.Image)
        Me.ToolStripRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripRefresh.Name = "ToolStripRefresh"
        Me.ToolStripRefresh.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripRefresh.Text = "Refresh"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(116, 22)
        Me.ToolStripButton2.Text = "Pending Sale Order"
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(534, 522)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 11
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.Location = New System.Drawing.Point(620, 522)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 12
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'GridOrderDetails
        '
        Me.GridOrderDetails.Location = New System.Drawing.Point(18, 37)
        Me.GridOrderDetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridOrderDetails.MainView = Me.GridOrder
        Me.GridOrderDetails.Name = "GridOrderDetails"
        Me.GridOrderDetails.Size = New System.Drawing.Size(1213, 479)
        Me.GridOrderDetails.TabIndex = 1
        Me.GridOrderDetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridOrder})
        '
        'GridOrder
        '
        Me.GridOrder.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridOrder.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridOrder.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridOrder.Appearance.Row.Options.UseFont = True
        Me.GridOrder.AppearancePrint.Preview.BackColor = System.Drawing.Color.White
        Me.GridOrder.AppearancePrint.Preview.Options.UseBackColor = True
        Me.GridOrder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GORDERNO, Me.GDATE, Me.GNAME, Me.GSHIPTO, Me.gpono, Me.GPODATE, Me.GITEMCODE, Me.GITEMNAME, Me.GSHADECARD, Me.GMULTIUPS, Me.GPOSNEG, Me.GDELDATE, Me.GTotalQty, Me.GASSEMBLYQTY, Me.GDELIVERYQTY, Me.GBALDELQTY, Me.GRATE, Me.GTotalAmt, Me.GCLOSED, Me.GOUTQTY, Me.GBALQTY, Me.GSCHDATE})
        Me.GridOrder.GridControl = Me.GridOrderDetails
        Me.GridOrder.Name = "GridOrder"
        Me.GridOrder.OptionsBehavior.Editable = False
        Me.GridOrder.OptionsView.ColumnAutoWidth = False
        Me.GridOrder.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GridOrder.OptionsView.ShowAutoFilterRow = True
        Me.GridOrder.OptionsView.ShowFooter = True
        Me.GridOrder.PaintStyleName = "Skin"
        '
        'GORDERNO
        '
        Me.GORDERNO.Caption = "Order No"
        Me.GORDERNO.FieldName = "ORDERNO"
        Me.GORDERNO.Name = "GORDERNO"
        Me.GORDERNO.Visible = True
        Me.GORDERNO.VisibleIndex = 0
        Me.GORDERNO.Width = 50
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 1
        Me.GDATE.Width = 80
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 2
        Me.GNAME.Width = 250
        '
        'GSHIPTO
        '
        Me.GSHIPTO.Caption = "Ship To"
        Me.GSHIPTO.FieldName = "SHIPTO"
        Me.GSHIPTO.Name = "GSHIPTO"
        Me.GSHIPTO.Visible = True
        Me.GSHIPTO.VisibleIndex = 4
        Me.GSHIPTO.Width = 250
        '
        'gpono
        '
        Me.gpono.Caption = "PO No"
        Me.gpono.FieldName = "PONO"
        Me.gpono.Name = "gpono"
        Me.gpono.Visible = True
        Me.gpono.VisibleIndex = 3
        Me.gpono.Width = 180
        '
        'GPODATE
        '
        Me.GPODATE.Caption = "PO Date"
        Me.GPODATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GPODATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GPODATE.FieldName = "PODATE"
        Me.GPODATE.Name = "GPODATE"
        Me.GPODATE.Visible = True
        Me.GPODATE.VisibleIndex = 5
        Me.GPODATE.Width = 80
        '
        'GITEMCODE
        '
        Me.GITEMCODE.Caption = "Item Code"
        Me.GITEMCODE.FieldName = "ITEMCODE"
        Me.GITEMCODE.Name = "GITEMCODE"
        Me.GITEMCODE.Visible = True
        Me.GITEMCODE.VisibleIndex = 6
        Me.GITEMCODE.Width = 120
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 7
        Me.GITEMNAME.Width = 200
        '
        'GSHADECARD
        '
        Me.GSHADECARD.Caption = "Shade Card"
        Me.GSHADECARD.FieldName = "SHADECARD"
        Me.GSHADECARD.Name = "GSHADECARD"
        Me.GSHADECARD.Visible = True
        Me.GSHADECARD.VisibleIndex = 8
        '
        'GMULTIUPS
        '
        Me.GMULTIUPS.Caption = "Multi Ups"
        Me.GMULTIUPS.FieldName = "MULTIUPS"
        Me.GMULTIUPS.Name = "GMULTIUPS"
        Me.GMULTIUPS.Visible = True
        Me.GMULTIUPS.VisibleIndex = 9
        Me.GMULTIUPS.Width = 80
        '
        'GPOSNEG
        '
        Me.GPOSNEG.Caption = "Pos/Neg"
        Me.GPOSNEG.FieldName = "POSNEG"
        Me.GPOSNEG.Name = "GPOSNEG"
        Me.GPOSNEG.Visible = True
        Me.GPOSNEG.VisibleIndex = 10
        Me.GPOSNEG.Width = 80
        '
        'GDELDATE
        '
        Me.GDELDATE.Caption = "Del Date"
        Me.GDELDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDELDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDELDATE.FieldName = "DELDATE"
        Me.GDELDATE.Name = "GDELDATE"
        Me.GDELDATE.Visible = True
        Me.GDELDATE.VisibleIndex = 11
        Me.GDELDATE.Width = 80
        '
        'GTotalQty
        '
        Me.GTotalQty.Caption = "Order Qty"
        Me.GTotalQty.DisplayFormat.FormatString = "0"
        Me.GTotalQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTotalQty.FieldName = "TOTALQTY"
        Me.GTotalQty.Name = "GTotalQty"
        Me.GTotalQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTotalQty.Visible = True
        Me.GTotalQty.VisibleIndex = 13
        '
        'GASSEMBLYQTY
        '
        Me.GASSEMBLYQTY.Caption = "Assembly Qty"
        Me.GASSEMBLYQTY.DisplayFormat.FormatString = "0"
        Me.GASSEMBLYQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GASSEMBLYQTY.FieldName = "ASSEMBLYQTY"
        Me.GASSEMBLYQTY.Name = "GASSEMBLYQTY"
        Me.GASSEMBLYQTY.OptionsColumn.AllowEdit = False
        Me.GASSEMBLYQTY.Visible = True
        Me.GASSEMBLYQTY.VisibleIndex = 14
        Me.GASSEMBLYQTY.Width = 90
        '
        'GDELIVERYQTY
        '
        Me.GDELIVERYQTY.Caption = "Delivery Qty"
        Me.GDELIVERYQTY.DisplayFormat.FormatString = "0"
        Me.GDELIVERYQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDELIVERYQTY.FieldName = "DELQTY"
        Me.GDELIVERYQTY.Name = "GDELIVERYQTY"
        Me.GDELIVERYQTY.OptionsColumn.AllowEdit = False
        Me.GDELIVERYQTY.Visible = True
        Me.GDELIVERYQTY.VisibleIndex = 15
        Me.GDELIVERYQTY.Width = 80
        '
        'GBALDELQTY
        '
        Me.GBALDELQTY.Caption = "Bal Delivery Qty"
        Me.GBALDELQTY.DisplayFormat.FormatString = "0"
        Me.GBALDELQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALDELQTY.FieldName = "BALDELQTY"
        Me.GBALDELQTY.Name = "GBALDELQTY"
        Me.GBALDELQTY.OptionsColumn.AllowEdit = False
        Me.GBALDELQTY.Visible = True
        Me.GBALDELQTY.VisibleIndex = 16
        Me.GBALDELQTY.Width = 100
        '
        'GRATE
        '
        Me.GRATE.Caption = "RATE"
        Me.GRATE.FieldName = "RATE"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.Visible = True
        Me.GRATE.VisibleIndex = 12
        '
        'GTotalAmt
        '
        Me.GTotalAmt.Caption = "Total Amt"
        Me.GTotalAmt.DisplayFormat.FormatString = "0.00"
        Me.GTotalAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTotalAmt.FieldName = "TOTALAMT"
        Me.GTotalAmt.Name = "GTotalAmt"
        Me.GTotalAmt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTotalAmt.Visible = True
        Me.GTotalAmt.VisibleIndex = 17
        Me.GTotalAmt.Width = 90
        '
        'GCLOSED
        '
        Me.GCLOSED.Caption = "Closed"
        Me.GCLOSED.FieldName = "CLOSED"
        Me.GCLOSED.Name = "GCLOSED"
        '
        'GOUTQTY
        '
        Me.GOUTQTY.Caption = "OUTQTY"
        Me.GOUTQTY.FieldName = "OUTQTY"
        Me.GOUTQTY.Name = "GOUTQTY"
        '
        'GBALQTY
        '
        Me.GBALQTY.Caption = "Bal Qty"
        Me.GBALQTY.DisplayFormat.FormatString = "0.00"
        Me.GBALQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALQTY.FieldName = "BALQTY"
        Me.GBALQTY.Name = "GBALQTY"
        '
        'GSCHDATE
        '
        Me.GSCHDATE.Caption = "Sch Date"
        Me.GSCHDATE.FieldName = "SCHDATE"
        Me.GSCHDATE.Name = "GSCHDATE"
        Me.GSCHDATE.Visible = True
        Me.GSCHDATE.VisibleIndex = 18
        '
        'OrderDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "OrderDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Order Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.GridOrderDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents GridOrderDetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridOrder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents GORDERNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTotalQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTotalAmt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TOOLADDNEW As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gpono As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPODATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADECARD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDELDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStripRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GCLOSED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOUTQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GBALQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMULTIUPS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPOSNEG As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents GSCHDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHIPTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GASSEMBLYQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDELIVERYQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALDELQTY As DevExpress.XtraGrid.Columns.GridColumn
End Class
