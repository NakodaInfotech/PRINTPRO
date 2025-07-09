<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpeningPurchaseOrderGridDetails
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
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EXCELEXPORT = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolEXCELSHEET = New System.Windows.Forms.ToolStrip()
        Me.ToolStripRefresh = New System.Windows.Forms.ToolStripButton()
        Me.GCLOSE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOUTQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridInvoice = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridPODetails = New DevExpress.XtraGrid.GridControl()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.CMDADD = New System.Windows.Forms.Button()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
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
        Me.ToolEXCELSHEET.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator, Me.EXCELEXPORT, Me.ToolStripSeparator1, Me.ToolStripRefresh, Me.ToolStripSeparator2})
        Me.ToolEXCELSHEET.Location = New System.Drawing.Point(0, 0)
        Me.ToolEXCELSHEET.Name = "ToolEXCELSHEET"
        Me.ToolEXCELSHEET.Size = New System.Drawing.Size(1234, 25)
        Me.ToolEXCELSHEET.TabIndex = 258
        Me.ToolEXCELSHEET.Text = "ToolStrip1"
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
        'GCLOSE
        '
        Me.GCLOSE.Caption = "CLOSE"
        Me.GCLOSE.FieldName = "CLOSED"
        Me.GCLOSE.Name = "GCLOSE"
        Me.GCLOSE.Visible = True
        Me.GCLOSE.VisibleIndex = 11
        '
        'GDESC
        '
        Me.GDESC.Caption = "Desc."
        Me.GDESC.FieldName = "DESC"
        Me.GDESC.Name = "GDESC"
        Me.GDESC.Visible = True
        Me.GDESC.VisibleIndex = 10
        Me.GDESC.Width = 150
        '
        'GAMT
        '
        Me.GAMT.Caption = "Amount"
        Me.GAMT.DisplayFormat.FormatString = "0.00"
        Me.GAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAMT.FieldName = "AMOUNT"
        Me.GAMT.Name = "GAMT"
        Me.GAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GAMT.Visible = True
        Me.GAMT.VisibleIndex = 9
        Me.GAMT.Width = 80
        '
        'GRATE
        '
        Me.GRATE.Caption = "Rate"
        Me.GRATE.DisplayFormat.FormatString = "0.00"
        Me.GRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRATE.FieldName = "RATE"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.Visible = True
        Me.GRATE.VisibleIndex = 8
        Me.GRATE.Width = 80
        '
        'GUNIT
        '
        Me.GUNIT.Caption = "Unit"
        Me.GUNIT.FieldName = "UNIT"
        Me.GUNIT.Name = "GUNIT"
        Me.GUNIT.Visible = True
        Me.GUNIT.VisibleIndex = 7
        Me.GUNIT.Width = 80
        '
        'GBALQTY
        '
        Me.GBALQTY.Caption = "Bal Qty"
        Me.GBALQTY.FieldName = "BALQTY"
        Me.GBALQTY.Name = "GBALQTY"
        Me.GBALQTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GBALQTY.Visible = True
        Me.GBALQTY.VisibleIndex = 6
        '
        'GOUTQTY
        '
        Me.GOUTQTY.Caption = "OUTQTY"
        Me.GOUTQTY.FieldName = "OUTQTY"
        Me.GOUTQTY.Name = "GOUTQTY"
        Me.GOUTQTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GOUTQTY.Visible = True
        Me.GOUTQTY.VisibleIndex = 5
        '
        'GQTY
        '
        Me.GQTY.Caption = "Qty."
        Me.GQTY.FieldName = "QTY"
        Me.GQTY.Name = "GQTY"
        Me.GQTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GQTY.Visible = True
        Me.GQTY.VisibleIndex = 4
        Me.GQTY.Width = 80
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 3
        Me.GITEMNAME.Width = 200
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 1
        '
        'GSRNO
        '
        Me.GSRNO.Caption = "Sr No"
        Me.GSRNO.FieldName = "SRNO"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.Width = 50
        '
        'GPONO
        '
        Me.GPONO.Caption = "P.O. No."
        Me.GPONO.FieldName = "PONO"
        Me.GPONO.Name = "GPONO"
        Me.GPONO.Visible = True
        Me.GPONO.VisibleIndex = 0
        '
        'GridInvoice
        '
        Me.GridInvoice.AppearancePrint.Preview.BackColor = System.Drawing.Color.White
        Me.GridInvoice.AppearancePrint.Preview.Options.UseBackColor = True
        Me.GridInvoice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GPONO, Me.GSRNO, Me.GDATE, Me.GNAME, Me.GITEMNAME, Me.GQTY, Me.GOUTQTY, Me.GBALQTY, Me.GUNIT, Me.GRATE, Me.GAMT, Me.GDESC, Me.GCLOSE})
        Me.GridInvoice.GridControl = Me.GridPODetails
        Me.GridInvoice.Name = "GridInvoice"
        Me.GridInvoice.OptionsBehavior.Editable = False
        Me.GridInvoice.OptionsView.ColumnAutoWidth = False
        Me.GridInvoice.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GridInvoice.OptionsView.ShowAutoFilterRow = True
        Me.GridInvoice.OptionsView.ShowFooter = True
        Me.GridInvoice.PaintStyleName = "Skin"
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 2
        Me.GNAME.Width = 200
        '
        'GridPODetails
        '
        Me.GridPODetails.Location = New System.Drawing.Point(15, 43)
        Me.GridPODetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridPODetails.MainView = Me.GridInvoice
        Me.GridPODetails.Name = "GridPODetails"
        Me.GridPODetails.Size = New System.Drawing.Size(1153, 466)
        Me.GridPODetails.TabIndex = 1
        Me.GridPODetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridInvoice})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(78, 548)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 14)
        Me.Label4.TabIndex = 862
        Me.Label4.Text = "Locked (Order Closed)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.LightGreen
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Location = New System.Drawing.Point(59, 547)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(18, 17)
        Me.Label12.TabIndex = 861
        Me.Label12.Text = "   "
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(78, 525)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(115, 14)
        Me.Label21.TabIndex = 860
        Me.Label21.Text = "Locked (Grn Raised)"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Location = New System.Drawing.Point(59, 524)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(18, 17)
        Me.Label22.TabIndex = 859
        Me.Label22.Text = "   "
        '
        'CMDADD
        '
        Me.CMDADD.BackColor = System.Drawing.Color.Transparent
        Me.CMDADD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDADD.FlatAppearance.BorderSize = 0
        Me.CMDADD.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDADD.ForeColor = System.Drawing.Color.Black
        Me.CMDADD.Location = New System.Drawing.Point(491, 525)
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
        Me.CMDOK.Location = New System.Drawing.Point(577, 525)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 2
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.Location = New System.Drawing.Point(663, 525)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 3
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.Color.White)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.Label21)
        Me.BlendPanel1.Controls.Add(Me.Label22)
        Me.BlendPanel1.Controls.Add(Me.CMDADD)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.GridPODetails)
        Me.BlendPanel1.Controls.Add(Me.ToolEXCELSHEET)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 571)
        Me.BlendPanel1.TabIndex = 2
        '
        'OpeningPurchaseOrderGridDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 571)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "OpeningPurchaseOrderGridDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Opening Purchase Order GridDetails"
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
    Friend WithEvents GCLOSE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOUTQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridInvoice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridPODetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents Label4 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents CMDADD As Button
    Friend WithEvents CMDOK As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
End Class
