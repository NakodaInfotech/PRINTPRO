<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SchedulingDetails
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
        Me.GSCHEDULINGDONEBY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOBNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCLIENT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOBCARDQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMAININGQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOBDESC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCUTSHEET = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCUTSIZE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFULLSHEET = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSMPAPERSIZE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOLOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPLATES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.Label14.Location = New System.Drawing.Point(41, 525)
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
        Me.Label15.Location = New System.Drawing.Point(19, 524)
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
        Me.GRIDJOBDETAILS.Size = New System.Drawing.Size(1203, 476)
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
        Me.GRIDJOB.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GSRNO, Me.GDATE, Me.GSCHEDULINGDONEBY, Me.GJOBNO, Me.GCLIENT, Me.GITEMNAME, Me.GJOBCARDQTY, Me.GGDATE, Me.GREMAININGQTY, Me.GJOBDESC, Me.GCUTSHEET, Me.GCUTSIZE, Me.GFULLSHEET, Me.GGSMPAPERSIZE, Me.GCOLOR, Me.GMODE, Me.GPLATES, Me.GREMARKS})
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
        Me.GSRNO.FieldName = "TEMPSCHNO"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.OptionsColumn.AllowEdit = False
        Me.GSRNO.Visible = True
        Me.GSRNO.VisibleIndex = 0
        Me.GSRNO.Width = 55
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
        '
        'GSCHEDULINGDONEBY
        '
        Me.GSCHEDULINGDONEBY.Caption = "Scheduling Done by"
        Me.GSCHEDULINGDONEBY.FieldName = "SCHEDULIGDONEBY"
        Me.GSCHEDULINGDONEBY.Name = "GSCHEDULINGDONEBY"
        Me.GSCHEDULINGDONEBY.OptionsColumn.AllowEdit = False
        Me.GSCHEDULINGDONEBY.Visible = True
        Me.GSCHEDULINGDONEBY.VisibleIndex = 3
        Me.GSCHEDULINGDONEBY.Width = 200
        '
        'GJOBNO
        '
        Me.GJOBNO.Caption = "Job No"
        Me.GJOBNO.FieldName = "JOBNO"
        Me.GJOBNO.Name = "GJOBNO"
        Me.GJOBNO.OptionsColumn.AllowEdit = False
        Me.GJOBNO.Visible = True
        Me.GJOBNO.VisibleIndex = 4
        '
        'GCLIENT
        '
        Me.GCLIENT.Caption = "Client"
        Me.GCLIENT.FieldName = "CLIENT"
        Me.GCLIENT.Name = "GCLIENT"
        Me.GCLIENT.OptionsColumn.AllowEdit = False
        Me.GCLIENT.Visible = True
        Me.GCLIENT.VisibleIndex = 2
        Me.GCLIENT.Width = 120
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "MAINITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.OptionsColumn.AllowEdit = False
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 5
        Me.GITEMNAME.Width = 200
        '
        'GJOBCARDQTY
        '
        Me.GJOBCARDQTY.Caption = "Job Card Qty"
        Me.GJOBCARDQTY.FieldName = "JOBCARDQTY"
        Me.GJOBCARDQTY.Name = "GJOBCARDQTY"
        Me.GJOBCARDQTY.OptionsColumn.AllowEdit = False
        Me.GJOBCARDQTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GJOBCARDQTY.Visible = True
        Me.GJOBCARDQTY.VisibleIndex = 6
        Me.GJOBCARDQTY.Width = 200
        '
        'GGDATE
        '
        Me.GGDATE.Caption = "SCH Date"
        Me.GGDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GGDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GGDATE.FieldName = "SCHDATE"
        Me.GGDATE.Name = "GGDATE"
        Me.GGDATE.OptionsColumn.AllowEdit = False
        Me.GGDATE.Visible = True
        Me.GGDATE.VisibleIndex = 7
        Me.GGDATE.Width = 90
        '
        'GREMAININGQTY
        '
        Me.GREMAININGQTY.Caption = "Remaining Qty"
        Me.GREMAININGQTY.FieldName = "REMAININGQTY"
        Me.GREMAININGQTY.Name = "GREMAININGQTY"
        Me.GREMAININGQTY.OptionsColumn.AllowEdit = False
        Me.GREMAININGQTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GREMAININGQTY.Visible = True
        Me.GREMAININGQTY.VisibleIndex = 8
        Me.GREMAININGQTY.Width = 90
        '
        'GJOBDESC
        '
        Me.GJOBDESC.Caption = "Job Desc"
        Me.GJOBDESC.FieldName = "ITEMNAME"
        Me.GJOBDESC.Name = "GJOBDESC"
        Me.GJOBDESC.OptionsColumn.AllowEdit = False
        Me.GJOBDESC.Visible = True
        Me.GJOBDESC.VisibleIndex = 9
        Me.GJOBDESC.Width = 200
        '
        'GCUTSHEET
        '
        Me.GCUTSHEET.Caption = "Cut Sheet"
        Me.GCUTSHEET.FieldName = "CUTSHEET"
        Me.GCUTSHEET.Name = "GCUTSHEET"
        Me.GCUTSHEET.OptionsColumn.AllowEdit = False
        Me.GCUTSHEET.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GCUTSHEET.Visible = True
        Me.GCUTSHEET.VisibleIndex = 10
        '
        'GCUTSIZE
        '
        Me.GCUTSIZE.Caption = "Cut Size"
        Me.GCUTSIZE.FieldName = "CUTSIZE"
        Me.GCUTSIZE.Name = "GCUTSIZE"
        Me.GCUTSIZE.OptionsColumn.AllowEdit = False
        Me.GCUTSIZE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GCUTSIZE.Visible = True
        Me.GCUTSIZE.VisibleIndex = 11
        '
        'GFULLSHEET
        '
        Me.GFULLSHEET.Caption = "Full Sheet"
        Me.GFULLSHEET.FieldName = "FULLSHEET"
        Me.GFULLSHEET.Name = "GFULLSHEET"
        Me.GFULLSHEET.OptionsColumn.AllowEdit = False
        Me.GFULLSHEET.Visible = True
        Me.GFULLSHEET.VisibleIndex = 12
        '
        'GGSMPAPERSIZE
        '
        Me.GGSMPAPERSIZE.Caption = "GSM/Paper/Size"
        Me.GGSMPAPERSIZE.FieldName = "GSMPAPERSIZE"
        Me.GGSMPAPERSIZE.Name = "GGSMPAPERSIZE"
        Me.GGSMPAPERSIZE.OptionsColumn.AllowEdit = False
        Me.GGSMPAPERSIZE.Visible = True
        Me.GGSMPAPERSIZE.VisibleIndex = 13
        Me.GGSMPAPERSIZE.Width = 100
        '
        'GCOLOR
        '
        Me.GCOLOR.Caption = "Color"
        Me.GCOLOR.FieldName = "COLOR"
        Me.GCOLOR.Name = "GCOLOR"
        Me.GCOLOR.OptionsColumn.AllowEdit = False
        Me.GCOLOR.Visible = True
        Me.GCOLOR.VisibleIndex = 14
        '
        'GMODE
        '
        Me.GMODE.Caption = "Mode"
        Me.GMODE.FieldName = "MODE"
        Me.GMODE.Name = "GMODE"
        Me.GMODE.OptionsColumn.AllowEdit = False
        Me.GMODE.Visible = True
        Me.GMODE.VisibleIndex = 15
        '
        'GPLATES
        '
        Me.GPLATES.Caption = "Plates"
        Me.GPLATES.FieldName = "PLATES"
        Me.GPLATES.Name = "GPLATES"
        Me.GPLATES.OptionsColumn.AllowEdit = False
        Me.GPLATES.Visible = True
        Me.GPLATES.VisibleIndex = 16
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.OptionsColumn.AllowEdit = False
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 17
        Me.GREMARKS.Width = 150
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
        Me.CMDOK.Location = New System.Drawing.Point(506, 525)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 174
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.Location = New System.Drawing.Point(592, 525)
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
        'SchedulingDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SchedulingDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "SchedulingDetails"
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
    Friend WithEvents GSCHEDULINGDONEBY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOBNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCLIENT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOBCARDQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMAININGQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOBDESC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCUTSHEET As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCUTSIZE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKEDIT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents APPROXDATE As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents CMDOK As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ADDNEW As ToolStripLabel
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripRefresh As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents GFULLSHEET As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSMPAPERSIZE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOLOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPLATES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
End Class
