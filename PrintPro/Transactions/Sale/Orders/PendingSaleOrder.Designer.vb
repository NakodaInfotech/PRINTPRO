<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PendingSaleOrder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PendingSaleOrder))
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPODATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gpono = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOMPANYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GORDERNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridOrder = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFILENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOLDNEW = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSAPCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCODENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GARTDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPDFSENDDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOKDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHADECARDSEND = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHADECARDOK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GORDERDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUANTITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOCATION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSCHDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCLOSE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridOrderDetails = New DevExpress.XtraGrid.GridControl()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLADDNEW = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.RBPENTERED = New System.Windows.Forms.RadioButton()
        Me.RBPENDING = New System.Windows.Forms.RadioButton()
        Me.CHKSELECTALL = New System.Windows.Forms.CheckBox()
        CType(Me.GridOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridOrderDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.OptionsColumn.AllowEdit = False
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 7
        Me.GITEMNAME.Width = 200
        '
        'GPODATE
        '
        Me.GPODATE.Caption = "PO Date"
        Me.GPODATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GPODATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GPODATE.FieldName = "PODATE"
        Me.GPODATE.Name = "GPODATE"
        Me.GPODATE.OptionsColumn.AllowEdit = False
        Me.GPODATE.Visible = True
        Me.GPODATE.VisibleIndex = 17
        Me.GPODATE.Width = 80
        '
        'gpono
        '
        Me.gpono.Caption = "PO No"
        Me.gpono.FieldName = "PONO"
        Me.gpono.Name = "gpono"
        Me.gpono.OptionsColumn.AllowEdit = False
        Me.gpono.Visible = True
        Me.gpono.VisibleIndex = 16
        Me.gpono.Width = 180
        '
        'GCOMPANYNAME
        '
        Me.GCOMPANYNAME.Caption = "Company Name"
        Me.GCOMPANYNAME.FieldName = "NAME"
        Me.GCOMPANYNAME.Name = "GCOMPANYNAME"
        Me.GCOMPANYNAME.OptionsColumn.AllowEdit = False
        Me.GCOMPANYNAME.Visible = True
        Me.GCOMPANYNAME.VisibleIndex = 2
        Me.GCOMPANYNAME.Width = 250
        '
        'GORDERNO
        '
        Me.GORDERNO.Caption = "Order No"
        Me.GORDERNO.FieldName = "ORDERNO"
        Me.GORDERNO.Name = "GORDERNO"
        Me.GORDERNO.OptionsColumn.AllowEdit = False
        Me.GORDERNO.Visible = True
        Me.GORDERNO.VisibleIndex = 1
        Me.GORDERNO.Width = 60
        '
        'GridOrder
        '
        Me.GridOrder.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridOrder.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridOrder.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridOrder.Appearance.Row.Options.UseFont = True
        Me.GridOrder.AppearancePrint.Preview.BackColor = System.Drawing.Color.White
        Me.GridOrder.AppearancePrint.Preview.Options.UseBackColor = True
        Me.GridOrder.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GORDERNO, Me.GSRNO, Me.GCOMPANYNAME, Me.GFILENO, Me.GOLDNEW, Me.GSAPCODE, Me.GCODENO, Me.GITEMNAME, Me.GARTDATE, Me.GPDFSENDDATE, Me.GOKDATE, Me.GSHADECARDSEND, Me.GSHADECARDOK, Me.GORDERDATE, Me.GQUANTITY, Me.GLOCATION, Me.gpono, Me.GPODATE, Me.GSCHDATE, Me.GCLOSE, Me.GTYPE})
        Me.GridOrder.GridControl = Me.GridOrderDetails
        Me.GridOrder.Name = "GridOrder"
        Me.GridOrder.OptionsView.ColumnAutoWidth = False
        Me.GridOrder.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GridOrder.OptionsView.ShowAutoFilterRow = True
        Me.GridOrder.OptionsView.ShowFooter = True
        Me.GridOrder.PaintStyleName = "Skin"
        '
        'GCHK
        '
        Me.GCHK.Caption = "Chk"
        Me.GCHK.FieldName = "CHK"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.Visible = True
        Me.GCHK.VisibleIndex = 0
        Me.GCHK.Width = 40
        '
        'GSRNO
        '
        Me.GSRNO.Caption = "Sr No"
        Me.GSRNO.FieldName = "SRNO"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.OptionsColumn.AllowEdit = False
        Me.GSRNO.Width = 50
        '
        'GFILENO
        '
        Me.GFILENO.Caption = "File No"
        Me.GFILENO.FieldName = "FILENO"
        Me.GFILENO.Name = "GFILENO"
        Me.GFILENO.OptionsColumn.AllowEdit = False
        Me.GFILENO.Visible = True
        Me.GFILENO.VisibleIndex = 3
        Me.GFILENO.Width = 80
        '
        'GOLDNEW
        '
        Me.GOLDNEW.Caption = "Old / New"
        Me.GOLDNEW.FieldName = "OLDNEW"
        Me.GOLDNEW.Name = "GOLDNEW"
        Me.GOLDNEW.OptionsColumn.AllowEdit = False
        Me.GOLDNEW.Visible = True
        Me.GOLDNEW.VisibleIndex = 4
        Me.GOLDNEW.Width = 80
        '
        'GSAPCODE
        '
        Me.GSAPCODE.Caption = "Sap Code"
        Me.GSAPCODE.FieldName = "SAPCODE"
        Me.GSAPCODE.Name = "GSAPCODE"
        Me.GSAPCODE.OptionsColumn.AllowEdit = False
        Me.GSAPCODE.Visible = True
        Me.GSAPCODE.VisibleIndex = 5
        Me.GSAPCODE.Width = 80
        '
        'GCODENO
        '
        Me.GCODENO.Caption = "Code No."
        Me.GCODENO.FieldName = "CODE"
        Me.GCODENO.Name = "GCODENO"
        Me.GCODENO.OptionsColumn.AllowEdit = False
        Me.GCODENO.Visible = True
        Me.GCODENO.VisibleIndex = 6
        Me.GCODENO.Width = 80
        '
        'GARTDATE
        '
        Me.GARTDATE.Caption = "A/W REC Date"
        Me.GARTDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GARTDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GARTDATE.FieldName = "ARTDATE"
        Me.GARTDATE.Name = "GARTDATE"
        Me.GARTDATE.OptionsColumn.AllowEdit = False
        Me.GARTDATE.Visible = True
        Me.GARTDATE.VisibleIndex = 8
        Me.GARTDATE.Width = 90
        '
        'GPDFSENDDATE
        '
        Me.GPDFSENDDATE.Caption = "PDF Send Date"
        Me.GPDFSENDDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GPDFSENDDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GPDFSENDDATE.FieldName = "PDFSENDDATE"
        Me.GPDFSENDDATE.Name = "GPDFSENDDATE"
        Me.GPDFSENDDATE.OptionsColumn.AllowEdit = False
        Me.GPDFSENDDATE.Visible = True
        Me.GPDFSENDDATE.VisibleIndex = 9
        Me.GPDFSENDDATE.Width = 90
        '
        'GOKDATE
        '
        Me.GOKDATE.Caption = "OK Date"
        Me.GOKDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GOKDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GOKDATE.FieldName = "OK"
        Me.GOKDATE.Name = "GOKDATE"
        Me.GOKDATE.OptionsColumn.AllowEdit = False
        Me.GOKDATE.Visible = True
        Me.GOKDATE.VisibleIndex = 10
        Me.GOKDATE.Width = 90
        '
        'GSHADECARDSEND
        '
        Me.GSHADECARDSEND.Caption = "Shade Card Send"
        Me.GSHADECARDSEND.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GSHADECARDSEND.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GSHADECARDSEND.FieldName = "SCSDATE"
        Me.GSHADECARDSEND.Name = "GSHADECARDSEND"
        Me.GSHADECARDSEND.OptionsColumn.AllowEdit = False
        Me.GSHADECARDSEND.Visible = True
        Me.GSHADECARDSEND.VisibleIndex = 11
        Me.GSHADECARDSEND.Width = 90
        '
        'GSHADECARDOK
        '
        Me.GSHADECARDOK.Caption = "Shade Card Ok"
        Me.GSHADECARDOK.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GSHADECARDOK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GSHADECARDOK.FieldName = "SCODATE"
        Me.GSHADECARDOK.Name = "GSHADECARDOK"
        Me.GSHADECARDOK.OptionsColumn.AllowEdit = False
        Me.GSHADECARDOK.Visible = True
        Me.GSHADECARDOK.VisibleIndex = 12
        Me.GSHADECARDOK.Width = 90
        '
        'GORDERDATE
        '
        Me.GORDERDATE.Caption = "Order Date"
        Me.GORDERDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GORDERDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GORDERDATE.FieldName = "ODATE"
        Me.GORDERDATE.Name = "GORDERDATE"
        Me.GORDERDATE.OptionsColumn.AllowEdit = False
        Me.GORDERDATE.Visible = True
        Me.GORDERDATE.VisibleIndex = 13
        Me.GORDERDATE.Width = 80
        '
        'GQUANTITY
        '
        Me.GQUANTITY.Caption = "Quantity"
        Me.GQUANTITY.FieldName = "QUANTITY"
        Me.GQUANTITY.Name = "GQUANTITY"
        Me.GQUANTITY.OptionsColumn.AllowEdit = False
        Me.GQUANTITY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GQUANTITY.Visible = True
        Me.GQUANTITY.VisibleIndex = 14
        Me.GQUANTITY.Width = 80
        '
        'GLOCATION
        '
        Me.GLOCATION.Caption = "Location"
        Me.GLOCATION.FieldName = "LOCATION"
        Me.GLOCATION.Name = "GLOCATION"
        Me.GLOCATION.OptionsColumn.AllowEdit = False
        Me.GLOCATION.Visible = True
        Me.GLOCATION.VisibleIndex = 15
        Me.GLOCATION.Width = 250
        '
        'GSCHDATE
        '
        Me.GSCHDATE.Caption = "Sch Date"
        Me.GSCHDATE.FieldName = "SCHDATE"
        Me.GSCHDATE.Name = "GSCHDATE"
        Me.GSCHDATE.OptionsColumn.AllowEdit = False
        Me.GSCHDATE.Visible = True
        Me.GSCHDATE.VisibleIndex = 18
        Me.GSCHDATE.Width = 80
        '
        'GCLOSE
        '
        Me.GCLOSE.Caption = "Close"
        Me.GCLOSE.FieldName = "CLOSE"
        Me.GCLOSE.Name = "GCLOSE"
        Me.GCLOSE.Visible = True
        Me.GCLOSE.VisibleIndex = 19
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Type"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.Visible = True
        Me.GTYPE.VisibleIndex = 20
        '
        'GridOrderDetails
        '
        Me.GridOrderDetails.Location = New System.Drawing.Point(12, 60)
        Me.GridOrderDetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridOrderDetails.MainView = Me.GridOrder
        Me.GridOrderDetails.Name = "GridOrderDetails"
        Me.GridOrderDetails.Size = New System.Drawing.Size(1222, 480)
        Me.GridOrderDetails.TabIndex = 1
        Me.GridOrderDetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridOrder})
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(526, 546)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 11
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.Location = New System.Drawing.Point(612, 546)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 12
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLADDNEW
        '
        Me.TOOLADDNEW.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TOOLADDNEW.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLADDNEW.Name = "TOOLADDNEW"
        Me.TOOLADDNEW.Size = New System.Drawing.Size(55, 22)
        Me.TOOLADDNEW.Text = "Add New"
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
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.Color.White)
        Me.BlendPanel1.Controls.Add(Me.RBPENTERED)
        Me.BlendPanel1.Controls.Add(Me.RBPENDING)
        Me.BlendPanel1.Controls.Add(Me.CHKSELECTALL)
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
        'RBPENTERED
        '
        Me.RBPENTERED.AutoSize = True
        Me.RBPENTERED.BackColor = System.Drawing.Color.Transparent
        Me.RBPENTERED.Location = New System.Drawing.Point(191, 36)
        Me.RBPENTERED.Name = "RBPENTERED"
        Me.RBPENTERED.Size = New System.Drawing.Size(66, 19)
        Me.RBPENTERED.TabIndex = 813
        Me.RBPENTERED.Text = "Entered"
        Me.RBPENTERED.UseVisualStyleBackColor = False
        '
        'RBPENDING
        '
        Me.RBPENDING.AutoSize = True
        Me.RBPENDING.BackColor = System.Drawing.Color.Transparent
        Me.RBPENDING.Checked = True
        Me.RBPENDING.Location = New System.Drawing.Point(116, 36)
        Me.RBPENDING.Name = "RBPENDING"
        Me.RBPENDING.Size = New System.Drawing.Size(69, 19)
        Me.RBPENDING.TabIndex = 811
        Me.RBPENDING.TabStop = True
        Me.RBPENDING.Text = "Pending"
        Me.RBPENDING.UseVisualStyleBackColor = False
        '
        'CHKSELECTALL
        '
        Me.CHKSELECTALL.AutoSize = True
        Me.CHKSELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTALL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTALL.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTALL.Location = New System.Drawing.Point(33, 36)
        Me.CHKSELECTALL.Name = "CHKSELECTALL"
        Me.CHKSELECTALL.Size = New System.Drawing.Size(77, 18)
        Me.CHKSELECTALL.TabIndex = 810
        Me.CHKSELECTALL.Text = "Select All"
        Me.CHKSELECTALL.UseVisualStyleBackColor = False
        '
        'PendingSaleOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "PendingSaleOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Pending Sale Order"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GridOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridOrderDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPODATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gpono As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOMPANYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GORDERNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridOrder As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridOrderDetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents CMDOK As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripRefresh As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents TOOLADDNEW As ToolStripButton
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents GFILENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOLDNEW As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSAPCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCODENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GARTDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPDFSENDDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOKDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADECARDSEND As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHADECARDOK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GORDERDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQUANTITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOCATION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSCHDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RBPENDING As RadioButton
    Friend WithEvents CHKSELECTALL As CheckBox
    Friend WithEvents GCLOSE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RBPENTERED As RadioButton
End Class
