<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaleOrderPlateDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SaleOrderPlateDetails))
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPODATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.GITEMCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHADECARD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDELDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gpono = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTotalQty = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.GCLOSED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTotalAmt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.GORDERNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridOrder = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPLATENAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOUTQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridOrderDetails = New DevExpress.XtraGrid.GridControl()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.GMULTIUPS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPOSNEG = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.GridOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridOrderDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
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
        'GPODATE
        '
        Me.GPODATE.Caption = "PO Date"
        Me.GPODATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GPODATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GPODATE.FieldName = "PODATE"
        Me.GPODATE.Name = "GPODATE"
        Me.GPODATE.Visible = True
        Me.GPODATE.VisibleIndex = 4
        Me.GPODATE.Width = 80
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(521, 527)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(93, 32)
        Me.CMDOK.TabIndex = 11
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'GITEMCODE
        '
        Me.GITEMCODE.Caption = "Item Code"
        Me.GITEMCODE.FieldName = "ITEMCODE"
        Me.GITEMCODE.Name = "GITEMCODE"
        Me.GITEMCODE.Visible = True
        Me.GITEMCODE.VisibleIndex = 5
        Me.GITEMCODE.Width = 120
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 6
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
        'gpono
        '
        Me.gpono.Caption = "PO No"
        Me.gpono.FieldName = "PONO"
        Me.gpono.Name = "gpono"
        Me.gpono.Visible = True
        Me.gpono.VisibleIndex = 3
        Me.gpono.Width = 180
        '
        'GTotalQty
        '
        Me.GTotalQty.Caption = "Total Qty"
        Me.GTotalQty.DisplayFormat.FormatString = "0"
        Me.GTotalQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTotalQty.FieldName = "TOTALQTY"
        Me.GTotalQty.Name = "GTotalQty"
        Me.GTotalQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTotalQty.Visible = True
        Me.GTotalQty.VisibleIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(185, 603)
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
        Me.Label2.Location = New System.Drawing.Point(160, 602)
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
        Me.Label14.Location = New System.Drawing.Point(47, 603)
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
        Me.Label15.Location = New System.Drawing.Point(21, 602)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(18, 17)
        Me.Label15.TabIndex = 654
        Me.Label15.Text = "   "
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TOOLADDNEW, Me.toolStripSeparator, Me.PrintToolStripButton, Me.ToolStripSeparator1, Me.ToolStripRefresh, Me.ToolStripSeparator2})
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
        'GCLOSED
        '
        Me.GCLOSED.Caption = "Closed"
        Me.GCLOSED.FieldName = "CLOSED"
        Me.GCLOSED.Name = "GCLOSED"
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
        Me.GTotalAmt.VisibleIndex = 13
        Me.GTotalAmt.Width = 90
        '
        'GBALQTY
        '
        Me.GBALQTY.Caption = "Bal Qty"
        Me.GBALQTY.DisplayFormat.FormatString = "0.00"
        Me.GBALQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALQTY.FieldName = "BALQTY"
        Me.GBALQTY.Name = "GBALQTY"
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.Location = New System.Drawing.Point(620, 527)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(93, 32)
        Me.cmdexit.TabIndex = 12
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'GORDERNO
        '
        Me.GORDERNO.Caption = "Order No"
        Me.GORDERNO.FieldName = "ORDERNO"
        Me.GORDERNO.Name = "GORDERNO"
        Me.GORDERNO.Visible = True
        Me.GORDERNO.VisibleIndex = 0
        '
        'GridOrder
        '
        Me.GridOrder.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridOrder.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridOrder.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridOrder.Appearance.Row.Options.UseFont = True
        Me.GridOrder.AppearancePrint.Preview.BackColor = System.Drawing.Color.White
        Me.GridOrder.AppearancePrint.Preview.Options.UseBackColor = True
        Me.GridOrder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GORDERNO, Me.GDATE, Me.GNAME, Me.gpono, Me.GPODATE, Me.GITEMCODE, Me.GITEMNAME, Me.GPLATENAME, Me.GSHADECARD, Me.GMULTIUPS, Me.GPOSNEG, Me.GDELDATE, Me.GTotalQty, Me.GTotalAmt, Me.GCLOSED, Me.GOUTQTY, Me.GBALQTY})
        Me.GridOrder.GridControl = Me.GridOrderDetails
        Me.GridOrder.Name = "GridOrder"
        Me.GridOrder.OptionsBehavior.Editable = False
        Me.GridOrder.OptionsView.ColumnAutoWidth = False
        Me.GridOrder.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GridOrder.OptionsView.ShowAutoFilterRow = True
        Me.GridOrder.OptionsView.ShowFooter = True
        Me.GridOrder.PaintStyleName = "Skin"
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
        'GPLATENAME
        '
        Me.GPLATENAME.Caption = "Plate Name"
        Me.GPLATENAME.FieldName = "PLATENAME"
        Me.GPLATENAME.Name = "GPLATENAME"
        Me.GPLATENAME.Visible = True
        Me.GPLATENAME.VisibleIndex = 7
        Me.GPLATENAME.Width = 200
        '
        'GOUTQTY
        '
        Me.GOUTQTY.Caption = "OUTQTY"
        Me.GOUTQTY.FieldName = "OUTQTY"
        Me.GOUTQTY.Name = "GOUTQTY"
        '
        'GridOrderDetails
        '
        Me.GridOrderDetails.Location = New System.Drawing.Point(12, 28)
        Me.GridOrderDetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridOrderDetails.MainView = Me.GridOrder
        Me.GridOrderDetails.Name = "GridOrderDetails"
        Me.GridOrderDetails.Size = New System.Drawing.Size(1210, 493)
        Me.GridOrderDetails.TabIndex = 1
        Me.GridOrderDetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridOrder})
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
        Me.BlendPanel1.TabIndex = 1
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
        'SaleOrderPlateDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "SaleOrderPlateDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Sale Order Plate Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.GridOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridOrderDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPODATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDOK As Button
    Friend WithEvents GITEMCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADECARD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDELDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gpono As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTotalQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents TOOLADDNEW As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripRefresh As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents GCLOSED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTotalAmt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As Button
    Friend WithEvents GORDERNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridOrder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOUTQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridOrderDetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents GPLATENAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMULTIUPS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPOSNEG As DevExpress.XtraGrid.Columns.GridColumn
End Class
