<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JobDocketBatchDetails
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
        Me.GJOBNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOBDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUANTITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALSHEET = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPRODUCTIONQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GASSEMBLYQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDELOUTQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRIDSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDONE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKEDIT = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.APPROXDATE = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ADDNEW = New System.Windows.Forms.ToolStripLabel()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
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
        Me.BlendPanel1.TabIndex = 1
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
        Me.Label15.Location = New System.Drawing.Point(19, 543)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(18, 15)
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
        Me.GRIDJOBDETAILS.Size = New System.Drawing.Size(1192, 492)
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
        Me.GRIDJOB.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GJOBNO, Me.GJOBDATE, Me.GNAME, Me.GPONO, Me.GITEMCODE, Me.GITEMNAME, Me.GQUANTITY, Me.GTOTALSHEET, Me.GPRODUCTIONQTY, Me.GASSEMBLYQTY, Me.GDELOUTQTY, Me.GRIDSRNO, Me.GDONE})
        Me.GRIDJOB.GridControl = Me.GRIDJOBDETAILS
        Me.GRIDJOB.Name = "GRIDJOB"
        Me.GRIDJOB.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDJOB.OptionsBehavior.Editable = False
        Me.GRIDJOB.OptionsView.ColumnAutoWidth = False
        Me.GRIDJOB.OptionsView.ShowAutoFilterRow = True
        Me.GRIDJOB.OptionsView.ShowFooter = True
        '
        'GJOBNO
        '
        Me.GJOBNO.Caption = "Job No"
        Me.GJOBNO.FieldName = "TEMPJOBNO"
        Me.GJOBNO.Name = "GJOBNO"
        Me.GJOBNO.OptionsColumn.AllowEdit = False
        Me.GJOBNO.Visible = True
        Me.GJOBNO.VisibleIndex = 0
        Me.GJOBNO.Width = 55
        '
        'GJOBDATE
        '
        Me.GJOBDATE.Caption = "Job Date"
        Me.GJOBDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GJOBDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GJOBDATE.FieldName = "JOBDATE"
        Me.GJOBDATE.Name = "GJOBDATE"
        Me.GJOBDATE.OptionsColumn.AllowEdit = False
        Me.GJOBDATE.Visible = True
        Me.GJOBDATE.VisibleIndex = 1
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
        'GPONO
        '
        Me.GPONO.Caption = "PO No"
        Me.GPONO.FieldName = "PONO"
        Me.GPONO.Name = "GPONO"
        Me.GPONO.OptionsColumn.AllowEdit = False
        Me.GPONO.Visible = True
        Me.GPONO.VisibleIndex = 3
        Me.GPONO.Width = 200
        '
        'GITEMCODE
        '
        Me.GITEMCODE.Caption = "Item Code"
        Me.GITEMCODE.FieldName = "ITEMCODE"
        Me.GITEMCODE.Name = "GITEMCODE"
        Me.GITEMCODE.OptionsColumn.AllowEdit = False
        Me.GITEMCODE.Visible = True
        Me.GITEMCODE.VisibleIndex = 4
        Me.GITEMCODE.Width = 120
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 5
        Me.GITEMNAME.Width = 200
        '
        'GQUANTITY
        '
        Me.GQUANTITY.Caption = "Qty"
        Me.GQUANTITY.DisplayFormat.FormatString = "0"
        Me.GQUANTITY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GQUANTITY.FieldName = "QTY"
        Me.GQUANTITY.Name = "GQUANTITY"
        Me.GQUANTITY.OptionsColumn.AllowEdit = False
        Me.GQUANTITY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GQUANTITY.Visible = True
        Me.GQUANTITY.VisibleIndex = 6
        Me.GQUANTITY.Width = 60
        '
        'GTOTALSHEET
        '
        Me.GTOTALSHEET.Caption = "Total Sheet"
        Me.GTOTALSHEET.FieldName = "TOTALSHEET"
        Me.GTOTALSHEET.Name = "GTOTALSHEET"
        Me.GTOTALSHEET.OptionsColumn.AllowEdit = False
        Me.GTOTALSHEET.Visible = True
        Me.GTOTALSHEET.VisibleIndex = 7
        Me.GTOTALSHEET.Width = 100
        '
        'GPRODUCTIONQTY
        '
        Me.GPRODUCTIONQTY.Caption = "Production Qty"
        Me.GPRODUCTIONQTY.FieldName = "ASSEMBLYQTY"
        Me.GPRODUCTIONQTY.Name = "GPRODUCTIONQTY"
        Me.GPRODUCTIONQTY.OptionsColumn.AllowEdit = False
        Me.GPRODUCTIONQTY.Visible = True
        Me.GPRODUCTIONQTY.VisibleIndex = 8
        Me.GPRODUCTIONQTY.Width = 100
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
        Me.GASSEMBLYQTY.VisibleIndex = 9
        Me.GASSEMBLYQTY.Width = 100
        '
        'GDELOUTQTY
        '
        Me.GDELOUTQTY.Caption = "Delivery Qty"
        Me.GDELOUTQTY.FieldName = "DELOUTQTY"
        Me.GDELOUTQTY.Name = "GDELOUTQTY"
        Me.GDELOUTQTY.OptionsColumn.AllowEdit = False
        Me.GDELOUTQTY.Visible = True
        Me.GDELOUTQTY.VisibleIndex = 10
        Me.GDELOUTQTY.Width = 100
        '
        'GRIDSRNO
        '
        Me.GRIDSRNO.Caption = "Grid Sr No"
        Me.GRIDSRNO.FieldName = "ORDERGIRDSRNO"
        Me.GRIDSRNO.Name = "GRIDSRNO"
        Me.GRIDSRNO.OptionsColumn.AllowEdit = False
        '
        'GDONE
        '
        Me.GDONE.Caption = "DONE"
        Me.GDONE.FieldName = "DONE"
        Me.GDONE.Name = "GDONE"
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
        Me.CMDOK.Location = New System.Drawing.Point(546, 543)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 174
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.Location = New System.Drawing.Point(632, 543)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 175
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ADDNEW, Me.toolStripSeparator, Me.PrintToolStripButton, Me.ToolStripSeparator1, Me.ToolStripRefresh, Me.ToolStripSeparator2})
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
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = Global.PrintPro.My.Resources.Resources.Excel_icon
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
        Me.ToolStripRefresh.Image = Global.PrintPro.My.Resources.Resources.refresh1
        Me.ToolStripRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripRefresh.Name = "ToolStripRefresh"
        Me.ToolStripRefresh.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripRefresh.Text = "ToolStripButton1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'JobDocketBatchDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "JobDocketBatchDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Job Docket Batch Details"
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
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Private WithEvents GRIDJOBDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDJOB As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GJOBNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOBDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQUANTITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRIDSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDONE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKEDIT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents APPROXDATE As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ADDNEW As System.Windows.Forms.ToolStripLabel
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GTOTALSHEET As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPRODUCTIONQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDELOUTQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GASSEMBLYQTY As DevExpress.XtraGrid.Columns.GridColumn
End Class
