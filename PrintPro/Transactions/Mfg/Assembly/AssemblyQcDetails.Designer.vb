<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AssemblyQcDetails
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GRIDJOBDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDJOB = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GORDERNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GORDERSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGBATCHNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGITEMCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGQUANTITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUANTITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPERCENTAGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALSHEET = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUSEDPAPERMATERIAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPAPERGSM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCLOSESIZELABEL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTEXTGRAPHICPICTURES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPHARMACODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUPSNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GVISUALDEFECTS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOLORSHADE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GVARNISH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPERFORATION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOPENSIZELABEL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTICKER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GADHESIVETAPEGLUE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFINALQUANTITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPACKETSTATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHIPPERSTATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLABELSTATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBATCHAPPROVEDREJECTED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQCHEAD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQCDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GINKDETAILS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GORDERTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKEDIT = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.APPROXDATE = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ADDNEW = New System.Windows.Forms.ToolStripLabel()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLEXCEL = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.GMAINITEMCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMAINITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPACKETS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHIPPERS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDJOBDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDJOB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APPROXDATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APPROXDATE.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.Color.White)
        Me.BlendPanel1.Controls.Add(Me.Label14)
        Me.BlendPanel1.Controls.Add(Me.Label15)
        Me.BlendPanel1.Controls.Add(Me.GRIDJOBDETAILS)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(41, 545)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(90, 14)
        Me.Label14.TabIndex = 653
        Me.Label14.Text = "Locked Dockets"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Location = New System.Drawing.Point(19, 544)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(18, 17)
        Me.Label15.TabIndex = 652
        Me.Label15.Text = "   "
        '
        'GRIDJOBDETAILS
        '
        Me.GRIDJOBDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDJOBDETAILS.Location = New System.Drawing.Point(19, 43)
        Me.GRIDJOBDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDJOBDETAILS.MainView = Me.GRIDJOB
        Me.GRIDJOBDETAILS.Name = "GRIDJOBDETAILS"
        Me.GRIDJOBDETAILS.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKEDIT, Me.APPROXDATE})
        Me.GRIDJOBDETAILS.Size = New System.Drawing.Size(1203, 487)
        Me.GRIDJOBDETAILS.TabIndex = 651
        Me.GRIDJOBDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDJOB})
        '
        'GRIDJOB
        '
        Me.GRIDJOB.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDJOB.Appearance.HeaderPanel.Options.UseFont = True
        Me.GRIDJOB.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDJOB.Appearance.Row.Options.UseFont = True
        Me.GRIDJOB.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDJOB.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GRIDJOB.AppearancePrint.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDJOB.AppearancePrint.Row.Options.UseFont = True
        Me.GRIDJOB.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GSRNO, Me.GDATE, Me.GORDERNO, Me.GORDERSRNO, Me.GGBATCHNO, Me.GNAME, Me.GMAINITEMCODE, Me.GMAINITEMNAME, Me.GGITEMCODE, Me.GGITEMNAME, Me.GGQUANTITY, Me.GQUANTITY, Me.GPACKETS, Me.GSHIPPERS, Me.GPERCENTAGE, Me.GTOTALSHEET, Me.GTOTALQTY, Me.GUSEDPAPERMATERIAL, Me.GPAPERGSM, Me.GCLOSESIZELABEL, Me.GTEXTGRAPHICPICTURES, Me.GPHARMACODE, Me.GUPSNO, Me.GVISUALDEFECTS, Me.GCOLORSHADE, Me.GVARNISH, Me.GPERFORATION, Me.GDESIGN, Me.GOPENSIZELABEL, Me.GSTICKER, Me.GADHESIVETAPEGLUE, Me.GFINALQUANTITY, Me.GPACKETSTATUS, Me.GSHIPPERSTATUS, Me.GLABELSTATUS, Me.GBATCHAPPROVEDREJECTED, Me.GQCHEAD, Me.GQCDATE, Me.GINKDETAILS, Me.GREMARKS, Me.GORDERTYPE})
        Me.GRIDJOB.GridControl = Me.GRIDJOBDETAILS
        Me.GRIDJOB.Name = "GRIDJOB"
        Me.GRIDJOB.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDJOB.OptionsBehavior.Editable = False
        Me.GRIDJOB.OptionsView.ColumnAutoWidth = False
        Me.GRIDJOB.OptionsView.ShowAutoFilterRow = True
        Me.GRIDJOB.OptionsView.ShowFooter = True
        '
        'GSRNO
        '
        Me.GSRNO.Caption = "Sr No"
        Me.GSRNO.FieldName = "TEMPASSEMBLYNO"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.OptionsColumn.AllowEdit = False
        Me.GSRNO.Visible = True
        Me.GSRNO.VisibleIndex = 0
        Me.GSRNO.Width = 40
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
        Me.GDATE.VisibleIndex = 1
        Me.GDATE.Width = 80
        '
        'GORDERNO
        '
        Me.GORDERNO.Caption = "Order No"
        Me.GORDERNO.FieldName = "ORDERNO"
        Me.GORDERNO.Name = "GORDERNO"
        Me.GORDERNO.Visible = True
        Me.GORDERNO.VisibleIndex = 2
        Me.GORDERNO.Width = 80
        '
        'GORDERSRNO
        '
        Me.GORDERSRNO.Caption = "Order Sr No"
        Me.GORDERSRNO.FieldName = "ORDERSRNO"
        Me.GORDERSRNO.Name = "GORDERSRNO"
        Me.GORDERSRNO.Visible = True
        Me.GORDERSRNO.VisibleIndex = 3
        '
        'GGBATCHNO
        '
        Me.GGBATCHNO.Caption = "Batch No"
        Me.GGBATCHNO.FieldName = "BATCHNO"
        Me.GGBATCHNO.Name = "GGBATCHNO"
        Me.GGBATCHNO.OptionsColumn.AllowEdit = False
        Me.GGBATCHNO.Visible = True
        Me.GGBATCHNO.VisibleIndex = 4
        Me.GGBATCHNO.Width = 100
        '
        'GNAME
        '
        Me.GNAME.Caption = "Party Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 5
        Me.GNAME.Width = 180
        '
        'GGITEMCODE
        '
        Me.GGITEMCODE.Caption = "Item Code"
        Me.GGITEMCODE.FieldName = "SUBITEMCODE"
        Me.GGITEMCODE.Name = "GGITEMCODE"
        Me.GGITEMCODE.OptionsColumn.AllowEdit = False
        Me.GGITEMCODE.Visible = True
        Me.GGITEMCODE.VisibleIndex = 8
        Me.GGITEMCODE.Width = 180
        '
        'GGITEMNAME
        '
        Me.GGITEMNAME.Caption = "Item Name"
        Me.GGITEMNAME.FieldName = "SUBITEMNAME"
        Me.GGITEMNAME.Name = "GGITEMNAME"
        Me.GGITEMNAME.OptionsColumn.AllowEdit = False
        Me.GGITEMNAME.Visible = True
        Me.GGITEMNAME.VisibleIndex = 9
        Me.GGITEMNAME.Width = 180
        '
        'GGQUANTITY
        '
        Me.GGQUANTITY.Caption = "Qty"
        Me.GGQUANTITY.FieldName = "GRIDQTY"
        Me.GGQUANTITY.Name = "GGQUANTITY"
        Me.GGQUANTITY.OptionsColumn.AllowEdit = False
        Me.GGQUANTITY.Visible = True
        Me.GGQUANTITY.VisibleIndex = 10
        Me.GGQUANTITY.Width = 100
        '
        'GQUANTITY
        '
        Me.GQUANTITY.Caption = "Ready Quantity"
        Me.GQUANTITY.FieldName = "QTY"
        Me.GQUANTITY.Name = "GQUANTITY"
        Me.GQUANTITY.OptionsColumn.AllowEdit = False
        Me.GQUANTITY.Visible = True
        Me.GQUANTITY.VisibleIndex = 11
        Me.GQUANTITY.Width = 100
        '
        'GPERCENTAGE
        '
        Me.GPERCENTAGE.Caption = "Percentage"
        Me.GPERCENTAGE.FieldName = "PERCENTAGE"
        Me.GPERCENTAGE.Name = "GPERCENTAGE"
        Me.GPERCENTAGE.OptionsColumn.AllowEdit = False
        Me.GPERCENTAGE.Visible = True
        Me.GPERCENTAGE.VisibleIndex = 14
        Me.GPERCENTAGE.Width = 80
        '
        'GTOTALSHEET
        '
        Me.GTOTALSHEET.Caption = "Total Sheets"
        Me.GTOTALSHEET.FieldName = "TOTALSHEET"
        Me.GTOTALSHEET.Name = "GTOTALSHEET"
        Me.GTOTALSHEET.OptionsColumn.AllowEdit = False
        Me.GTOTALSHEET.Visible = True
        Me.GTOTALSHEET.VisibleIndex = 15
        Me.GTOTALSHEET.Width = 90
        '
        'GTOTALQTY
        '
        Me.GTOTALQTY.Caption = "Total Qty"
        Me.GTOTALQTY.FieldName = "TOTALQTY"
        Me.GTOTALQTY.Name = "GTOTALQTY"
        Me.GTOTALQTY.OptionsColumn.AllowEdit = False
        Me.GTOTALQTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALQTY.Visible = True
        Me.GTOTALQTY.VisibleIndex = 16
        '
        'GUSEDPAPERMATERIAL
        '
        Me.GUSEDPAPERMATERIAL.Caption = "Used Paper Material"
        Me.GUSEDPAPERMATERIAL.FieldName = "PAPER"
        Me.GUSEDPAPERMATERIAL.Name = "GUSEDPAPERMATERIAL"
        Me.GUSEDPAPERMATERIAL.OptionsColumn.AllowEdit = False
        Me.GUSEDPAPERMATERIAL.Visible = True
        Me.GUSEDPAPERMATERIAL.VisibleIndex = 17
        '
        'GPAPERGSM
        '
        Me.GPAPERGSM.Caption = "Paper GSM"
        Me.GPAPERGSM.FieldName = "GSM"
        Me.GPAPERGSM.Name = "GPAPERGSM"
        Me.GPAPERGSM.OptionsColumn.AllowEdit = False
        Me.GPAPERGSM.Visible = True
        Me.GPAPERGSM.VisibleIndex = 23
        '
        'GCLOSESIZELABEL
        '
        Me.GCLOSESIZELABEL.Caption = "Close Size Label"
        Me.GCLOSESIZELABEL.FieldName = "GRAIN"
        Me.GCLOSESIZELABEL.Name = "GCLOSESIZELABEL"
        Me.GCLOSESIZELABEL.OptionsColumn.AllowEdit = False
        Me.GCLOSESIZELABEL.Visible = True
        Me.GCLOSESIZELABEL.VisibleIndex = 21
        '
        'GTEXTGRAPHICPICTURES
        '
        Me.GTEXTGRAPHICPICTURES.Caption = "Text/Graphic/Pictures"
        Me.GTEXTGRAPHICPICTURES.FieldName = "TEXT"
        Me.GTEXTGRAPHICPICTURES.Name = "GTEXTGRAPHICPICTURES"
        Me.GTEXTGRAPHICPICTURES.OptionsColumn.AllowEdit = False
        Me.GTEXTGRAPHICPICTURES.Visible = True
        Me.GTEXTGRAPHICPICTURES.VisibleIndex = 18
        '
        'GPHARMACODE
        '
        Me.GPHARMACODE.Caption = "Pharma Code"
        Me.GPHARMACODE.FieldName = "PHARMA"
        Me.GPHARMACODE.Name = "GPHARMACODE"
        Me.GPHARMACODE.OptionsColumn.AllowEdit = False
        Me.GPHARMACODE.Visible = True
        Me.GPHARMACODE.VisibleIndex = 24
        '
        'GUPSNO
        '
        Me.GUPSNO.Caption = "UPS No"
        Me.GUPSNO.FieldName = "UPSNO"
        Me.GUPSNO.Name = "GUPSNO"
        Me.GUPSNO.OptionsColumn.AllowEdit = False
        Me.GUPSNO.Visible = True
        Me.GUPSNO.VisibleIndex = 30
        '
        'GVISUALDEFECTS
        '
        Me.GVISUALDEFECTS.Caption = "Visual Defects"
        Me.GVISUALDEFECTS.FieldName = "VISUAL"
        Me.GVISUALDEFECTS.Name = "GVISUALDEFECTS"
        Me.GVISUALDEFECTS.OptionsColumn.AllowEdit = False
        Me.GVISUALDEFECTS.Visible = True
        Me.GVISUALDEFECTS.VisibleIndex = 37
        '
        'GCOLORSHADE
        '
        Me.GCOLORSHADE.Caption = "Color Shade"
        Me.GCOLORSHADE.FieldName = "COLOR"
        Me.GCOLORSHADE.Name = "GCOLORSHADE"
        Me.GCOLORSHADE.OptionsColumn.AllowEdit = False
        Me.GCOLORSHADE.Visible = True
        Me.GCOLORSHADE.VisibleIndex = 28
        '
        'GVARNISH
        '
        Me.GVARNISH.Caption = "Varnish"
        Me.GVARNISH.FieldName = "VARNISH"
        Me.GVARNISH.Name = "GVARNISH"
        Me.GVARNISH.OptionsColumn.AllowEdit = False
        Me.GVARNISH.Visible = True
        Me.GVARNISH.VisibleIndex = 25
        '
        'GPERFORATION
        '
        Me.GPERFORATION.Caption = "Perforation"
        Me.GPERFORATION.FieldName = "PERFORATION"
        Me.GPERFORATION.Name = "GPERFORATION"
        Me.GPERFORATION.OptionsColumn.AllowEdit = False
        Me.GPERFORATION.Visible = True
        Me.GPERFORATION.VisibleIndex = 31
        '
        'GDESIGN
        '
        Me.GDESIGN.Caption = "Design"
        Me.GDESIGN.FieldName = "DESIGN"
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.OptionsColumn.AllowEdit = False
        Me.GDESIGN.Visible = True
        Me.GDESIGN.VisibleIndex = 29
        '
        'GOPENSIZELABEL
        '
        Me.GOPENSIZELABEL.Caption = "Open Size Label"
        Me.GOPENSIZELABEL.FieldName = "SIZE"
        Me.GOPENSIZELABEL.Name = "GOPENSIZELABEL"
        Me.GOPENSIZELABEL.OptionsColumn.AllowEdit = False
        Me.GOPENSIZELABEL.Visible = True
        Me.GOPENSIZELABEL.VisibleIndex = 20
        '
        'GSTICKER
        '
        Me.GSTICKER.Caption = "Sticker"
        Me.GSTICKER.FieldName = "STICKER"
        Me.GSTICKER.Name = "GSTICKER"
        Me.GSTICKER.OptionsColumn.AllowEdit = False
        Me.GSTICKER.Visible = True
        Me.GSTICKER.VisibleIndex = 32
        '
        'GADHESIVETAPEGLUE
        '
        Me.GADHESIVETAPEGLUE.Caption = "Adhesive Tape/Glue"
        Me.GADHESIVETAPEGLUE.FieldName = "ADHESIVE"
        Me.GADHESIVETAPEGLUE.Name = "GADHESIVETAPEGLUE"
        Me.GADHESIVETAPEGLUE.OptionsColumn.AllowEdit = False
        Me.GADHESIVETAPEGLUE.Visible = True
        Me.GADHESIVETAPEGLUE.VisibleIndex = 19
        '
        'GFINALQUANTITY
        '
        Me.GFINALQUANTITY.Caption = "Final Quantity"
        Me.GFINALQUANTITY.FieldName = "FINAL"
        Me.GFINALQUANTITY.Name = "GFINALQUANTITY"
        Me.GFINALQUANTITY.OptionsColumn.AllowEdit = False
        Me.GFINALQUANTITY.Visible = True
        Me.GFINALQUANTITY.VisibleIndex = 26
        '
        'GPACKETSTATUS
        '
        Me.GPACKETSTATUS.Caption = "Packet Status"
        Me.GPACKETSTATUS.FieldName = "PACKET"
        Me.GPACKETSTATUS.Name = "GPACKETSTATUS"
        Me.GPACKETSTATUS.OptionsColumn.AllowEdit = False
        Me.GPACKETSTATUS.Visible = True
        Me.GPACKETSTATUS.VisibleIndex = 27
        '
        'GSHIPPERSTATUS
        '
        Me.GSHIPPERSTATUS.Caption = "Shipper Status"
        Me.GSHIPPERSTATUS.FieldName = "SHIPPER"
        Me.GSHIPPERSTATUS.Name = "GSHIPPERSTATUS"
        Me.GSHIPPERSTATUS.OptionsColumn.AllowEdit = False
        Me.GSHIPPERSTATUS.Visible = True
        Me.GSHIPPERSTATUS.VisibleIndex = 34
        '
        'GLABELSTATUS
        '
        Me.GLABELSTATUS.Caption = "Label Status"
        Me.GLABELSTATUS.FieldName = "LABEL"
        Me.GLABELSTATUS.Name = "GLABELSTATUS"
        Me.GLABELSTATUS.OptionsColumn.AllowEdit = False
        Me.GLABELSTATUS.Visible = True
        Me.GLABELSTATUS.VisibleIndex = 38
        '
        'GBATCHAPPROVEDREJECTED
        '
        Me.GBATCHAPPROVEDREJECTED.Caption = "Batch Approved/Rejected"
        Me.GBATCHAPPROVEDREJECTED.FieldName = "BATCH"
        Me.GBATCHAPPROVEDREJECTED.Name = "GBATCHAPPROVEDREJECTED"
        Me.GBATCHAPPROVEDREJECTED.OptionsColumn.AllowEdit = False
        Me.GBATCHAPPROVEDREJECTED.Visible = True
        Me.GBATCHAPPROVEDREJECTED.VisibleIndex = 22
        '
        'GQCHEAD
        '
        Me.GQCHEAD.Caption = "QC Head"
        Me.GQCHEAD.FieldName = "QCHEAD"
        Me.GQCHEAD.Name = "GQCHEAD"
        Me.GQCHEAD.OptionsColumn.AllowEdit = False
        Me.GQCHEAD.Visible = True
        Me.GQCHEAD.VisibleIndex = 35
        '
        'GQCDATE
        '
        Me.GQCDATE.Caption = "QC Date"
        Me.GQCDATE.FieldName = "QCDATE"
        Me.GQCDATE.Name = "GQCDATE"
        Me.GQCDATE.OptionsColumn.AllowEdit = False
        Me.GQCDATE.Visible = True
        Me.GQCDATE.VisibleIndex = 36
        '
        'GINKDETAILS
        '
        Me.GINKDETAILS.Caption = "Ink Details"
        Me.GINKDETAILS.FieldName = "INKDETAILS"
        Me.GINKDETAILS.Name = "GINKDETAILS"
        Me.GINKDETAILS.OptionsColumn.AllowEdit = False
        Me.GINKDETAILS.Visible = True
        Me.GINKDETAILS.VisibleIndex = 40
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "QCREMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.OptionsColumn.AllowEdit = False
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 39
        Me.GREMARKS.Width = 150
        '
        'GORDERTYPE
        '
        Me.GORDERTYPE.Caption = "Order Type"
        Me.GORDERTYPE.FieldName = "ORDERTYPE"
        Me.GORDERTYPE.Name = "GORDERTYPE"
        Me.GORDERTYPE.Visible = True
        Me.GORDERTYPE.VisibleIndex = 33
        '
        'CHKEDIT
        '
        Me.CHKEDIT.AutoHeight = False
        Me.CHKEDIT.Name = "CHKEDIT"
        Me.CHKEDIT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'APPROXDATE
        '
        Me.APPROXDATE.AutoHeight = False
        Me.APPROXDATE.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.APPROXDATE.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.APPROXDATE.Name = "APPROXDATE"
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(552, 539)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 174
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.Location = New System.Drawing.Point(638, 539)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 175
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ADDNEW, Me.toolStripSeparator, Me.TOOLEXCEL, Me.ToolStripSeparator1, Me.TOOLREFRESH, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 172
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ADDNEW
        '
        Me.ADDNEW.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ADDNEW.Name = "ADDNEW"
        Me.ADDNEW.Size = New System.Drawing.Size(55, 22)
        Me.ADDNEW.Text = "&Add New"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLEXCEL
        '
        Me.TOOLEXCEL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLEXCEL.Image = Global.PrintPro.My.Resources.Resources.Excel_icon
        Me.TOOLEXCEL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLEXCEL.Name = "TOOLEXCEL"
        Me.TOOLEXCEL.Size = New System.Drawing.Size(23, 22)
        Me.TOOLEXCEL.Text = "&Print"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLREFRESH
        '
        Me.TOOLREFRESH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLREFRESH.Image = Global.PrintPro.My.Resources.Resources.refresh1
        Me.TOOLREFRESH.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLREFRESH.Name = "TOOLREFRESH"
        Me.TOOLREFRESH.Size = New System.Drawing.Size(23, 22)
        Me.TOOLREFRESH.Text = "ToolStripButton1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'GMAINITEMCODE
        '
        Me.GMAINITEMCODE.Caption = "Mian Item Code"
        Me.GMAINITEMCODE.FieldName = "ITEMCODE"
        Me.GMAINITEMCODE.Name = "GMAINITEMCODE"
        Me.GMAINITEMCODE.OptionsColumn.AllowEdit = False
        Me.GMAINITEMCODE.Visible = True
        Me.GMAINITEMCODE.VisibleIndex = 6
        Me.GMAINITEMCODE.Width = 180
        '
        'GMAINITEMNAME
        '
        Me.GMAINITEMNAME.Caption = "Main Item Name"
        Me.GMAINITEMNAME.FieldName = "ITEMNAME"
        Me.GMAINITEMNAME.Name = "GMAINITEMNAME"
        Me.GMAINITEMNAME.OptionsColumn.AllowEdit = False
        Me.GMAINITEMNAME.Visible = True
        Me.GMAINITEMNAME.VisibleIndex = 7
        Me.GMAINITEMNAME.Width = 180
        '
        'GPACKETS
        '
        Me.GPACKETS.Caption = "Packets"
        Me.GPACKETS.FieldName = "TOTALPACKETS"
        Me.GPACKETS.Name = "GPACKETS"
        Me.GPACKETS.OptionsColumn.AllowEdit = False
        Me.GPACKETS.Visible = True
        Me.GPACKETS.VisibleIndex = 12
        Me.GPACKETS.Width = 80
        '
        'GSHIPPERS
        '
        Me.GSHIPPERS.Caption = "Shippers"
        Me.GSHIPPERS.FieldName = "TOTALSHIPPERS"
        Me.GSHIPPERS.Name = "GSHIPPERS"
        Me.GSHIPPERS.OptionsColumn.AllowEdit = False
        Me.GSHIPPERS.Visible = True
        Me.GSHIPPERS.VisibleIndex = 13
        Me.GSHIPPERS.Width = 80
        '
        'AssemblyQcDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "AssemblyQcDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "AssemblyQc Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDJOBDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDJOB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APPROXDATE.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APPROXDATE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Private WithEvents GRIDJOBDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDJOB As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQUANTITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPERCENTAGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALSHEET As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGITEMCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGQUANTITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGBATCHNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKEDIT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents APPROXDATE As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents CMDOK As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ADDNEW As ToolStripLabel
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents TOOLEXCEL As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents TOOLREFRESH As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents GUSEDPAPERMATERIAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTEXTGRAPHICPICTURES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GADHESIVETAPEGLUE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOPENSIZELABEL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCLOSESIZELABEL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBATCHAPPROVEDREJECTED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPAPERGSM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPHARMACODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVARNISH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFINALQUANTITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPACKETSTATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOLORSHADE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUPSNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPERFORATION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTICKER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHIPPERSTATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQCHEAD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQCDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVISUALDEFECTS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLABELSTATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GINKDETAILS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GORDERNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GORDERSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GORDERTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMAINITEMCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMAINITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPACKETS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHIPPERS As DevExpress.XtraGrid.Columns.GridColumn
End Class
