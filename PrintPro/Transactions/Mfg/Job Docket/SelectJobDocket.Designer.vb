<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectJobDocket
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
        Me.CHKEDIT = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CHKALL = New System.Windows.Forms.CheckBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSUBITEMCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPAPERNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUANTITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALCUTSHEET = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGOODQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPRODUCTIONSHEET = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMAININGSHEET = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSIZE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUPS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPRODUCTIONTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lbl = New System.Windows.Forms.Label()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CHKEDIT
        '
        Me.CHKEDIT.AutoHeight = False
        Me.CHKEDIT.Name = "CHKEDIT"
        Me.CHKEDIT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.Color.White)
        Me.BlendPanel1.Controls.Add(Me.CHKALL)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 2
        '
        'CHKALL
        '
        Me.CHKALL.AutoSize = True
        Me.CHKALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKALL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKALL.Location = New System.Drawing.Point(34, 37)
        Me.CHKALL.Name = "CHKALL"
        Me.CHKALL.Size = New System.Drawing.Size(76, 19)
        Me.CHKALL.TabIndex = 653
        Me.CHKALL.Text = "Select All"
        Me.CHKALL.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(636, 544)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(97, 28)
        Me.cmdexit.TabIndex = 652
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(551, 544)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(97, 28)
        Me.cmdok.TabIndex = 651
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(8, 62)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1214, 471)
        Me.gridbilldetails.TabIndex = 650
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GSRNO, Me.GDATE, Me.GNAME, Me.GPONO, Me.GITEMCODE, Me.GITEMNAME, Me.GSUBITEMCODE, Me.GPAPERNAME, Me.GQUANTITY, Me.GTOTALCUTSHEET, Me.GGOODQTY, Me.GPRODUCTIONSHEET, Me.GREMAININGSHEET, Me.GSIZE, Me.GUPS, Me.GPRODUCTIONTYPE})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GCHK
        '
        Me.GCHK.ColumnEdit = Me.CHKEDIT
        Me.GCHK.FieldName = "CHK"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.OptionsColumn.ShowCaption = False
        Me.GCHK.Visible = True
        Me.GCHK.VisibleIndex = 0
        Me.GCHK.Width = 41
        '
        'GSRNO
        '
        Me.GSRNO.Caption = "Job Docket No"
        Me.GSRNO.FieldName = "JOBDOCKETNO"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.OptionsColumn.AllowEdit = False
        Me.GSRNO.Visible = True
        Me.GSRNO.VisibleIndex = 1
        Me.GSRNO.Width = 90
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "JOBDOCKETDATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.OptionsColumn.AllowEdit = False
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 2
        Me.GDATE.Width = 80
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
        'GPONO
        '
        Me.GPONO.Caption = "P.O. No"
        Me.GPONO.FieldName = "PONO"
        Me.GPONO.Name = "GPONO"
        Me.GPONO.OptionsColumn.AllowEdit = False
        Me.GPONO.Visible = True
        Me.GPONO.VisibleIndex = 4
        Me.GPONO.Width = 120
        '
        'GITEMCODE
        '
        Me.GITEMCODE.Caption = "Item Code"
        Me.GITEMCODE.FieldName = "ITEMCODE"
        Me.GITEMCODE.Name = "GITEMCODE"
        Me.GITEMCODE.OptionsColumn.AllowEdit = False
        Me.GITEMCODE.Visible = True
        Me.GITEMCODE.VisibleIndex = 5
        Me.GITEMCODE.Width = 150
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Desc"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.OptionsColumn.AllowEdit = False
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 6
        Me.GITEMNAME.Width = 250
        '
        'GSUBITEMCODE
        '
        Me.GSUBITEMCODE.Caption = "Sub Item Name"
        Me.GSUBITEMCODE.FieldName = "SUBITEMCODE"
        Me.GSUBITEMCODE.Name = "GSUBITEMCODE"
        Me.GSUBITEMCODE.OptionsColumn.AllowEdit = False
        Me.GSUBITEMCODE.Visible = True
        Me.GSUBITEMCODE.VisibleIndex = 7
        Me.GSUBITEMCODE.Width = 150
        '
        'GPAPERNAME
        '
        Me.GPAPERNAME.Caption = "Paper Name"
        Me.GPAPERNAME.FieldName = "PAPERNAME"
        Me.GPAPERNAME.Name = "GPAPERNAME"
        Me.GPAPERNAME.OptionsColumn.AllowEdit = False
        Me.GPAPERNAME.Visible = True
        Me.GPAPERNAME.VisibleIndex = 8
        Me.GPAPERNAME.Width = 200
        '
        'GQUANTITY
        '
        Me.GQUANTITY.Caption = "Qty"
        Me.GQUANTITY.DisplayFormat.FormatString = "0"
        Me.GQUANTITY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GQUANTITY.FieldName = "QTY"
        Me.GQUANTITY.Name = "GQUANTITY"
        Me.GQUANTITY.OptionsColumn.AllowEdit = False
        Me.GQUANTITY.Visible = True
        Me.GQUANTITY.VisibleIndex = 9
        Me.GQUANTITY.Width = 80
        '
        'GTOTALCUTSHEET
        '
        Me.GTOTALCUTSHEET.Caption = "Total Cut Sheet"
        Me.GTOTALCUTSHEET.FieldName = "TOTALCUTSHEET"
        Me.GTOTALCUTSHEET.Name = "GTOTALCUTSHEET"
        Me.GTOTALCUTSHEET.OptionsColumn.AllowEdit = False
        Me.GTOTALCUTSHEET.Visible = True
        Me.GTOTALCUTSHEET.VisibleIndex = 10
        Me.GTOTALCUTSHEET.Width = 100
        '
        'GGOODQTY
        '
        Me.GGOODQTY.Caption = "Good Qty"
        Me.GGOODQTY.FieldName = "GOODQTY"
        Me.GGOODQTY.Name = "GGOODQTY"
        Me.GGOODQTY.OptionsColumn.AllowEdit = False
        Me.GGOODQTY.Visible = True
        Me.GGOODQTY.VisibleIndex = 11
        Me.GGOODQTY.Width = 90
        '
        'GPRODUCTIONSHEET
        '
        Me.GPRODUCTIONSHEET.Caption = "Production Done"
        Me.GPRODUCTIONSHEET.DisplayFormat.FormatString = "0"
        Me.GPRODUCTIONSHEET.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPRODUCTIONSHEET.FieldName = "PRODUCTIONDONE"
        Me.GPRODUCTIONSHEET.Name = "GPRODUCTIONSHEET"
        Me.GPRODUCTIONSHEET.OptionsColumn.AllowEdit = False
        Me.GPRODUCTIONSHEET.Visible = True
        Me.GPRODUCTIONSHEET.VisibleIndex = 12
        Me.GPRODUCTIONSHEET.Width = 110
        '
        'GREMAININGSHEET
        '
        Me.GREMAININGSHEET.Caption = "Remaining Sheets"
        Me.GREMAININGSHEET.DisplayFormat.FormatString = "0"
        Me.GREMAININGSHEET.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GREMAININGSHEET.FieldName = "REMAININGSHEETS"
        Me.GREMAININGSHEET.Name = "GREMAININGSHEET"
        Me.GREMAININGSHEET.OptionsColumn.AllowEdit = False
        Me.GREMAININGSHEET.Visible = True
        Me.GREMAININGSHEET.VisibleIndex = 13
        Me.GREMAININGSHEET.Width = 120
        '
        'GSIZE
        '
        Me.GSIZE.Caption = "Size"
        Me.GSIZE.FieldName = "SIZE"
        Me.GSIZE.Name = "GSIZE"
        Me.GSIZE.OptionsColumn.AllowEdit = False
        '
        'GUPS
        '
        Me.GUPS.Caption = "UPS"
        Me.GUPS.DisplayFormat.FormatString = "0"
        Me.GUPS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GUPS.FieldName = "UPS"
        Me.GUPS.Name = "GUPS"
        '
        'GPRODUCTIONTYPE
        '
        Me.GPRODUCTIONTYPE.Caption = "Production Type"
        Me.GPRODUCTIONTYPE.FieldName = "TOPRODUCTIONTYPE"
        Me.GPRODUCTIONTYPE.Name = "GPRODUCTIONTYPE"
        Me.GPRODUCTIONTYPE.OptionsColumn.AllowEdit = False
        Me.GPRODUCTIONTYPE.Visible = True
        Me.GPRODUCTIONTYPE.VisibleIndex = 14
        Me.GPRODUCTIONTYPE.Width = 100
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(18, 11)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(148, 23)
        Me.lbl.TabIndex = 263
        Me.lbl.Text = "Select Job Docket"
        '
        'SelectJobDocket
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SelectJobDocket"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Select Job Docket"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQUANTITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents GSUBITEMCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPAPERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSIZE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKALL As CheckBox
    Friend WithEvents GTOTALCUTSHEET As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPRODUCTIONSHEET As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMAININGSHEET As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGOODQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUPS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKEDIT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GPRODUCTIONTYPE As DevExpress.XtraGrid.Columns.GridColumn
End Class
